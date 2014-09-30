Imports System.Xml
Imports System.IO
Imports System.Text

Public Class PakIcoFile

    Private BytesArray As New ArrayList
    Private Textos1 As New ArrayList
    Private NewMatriz As New ArrayList

    Private PlusNumeric As Integer = 0
    Private NumericFile As Integer = 0
    Private PathFile As String = ""

    Private NameItems As New ArrayList
    Private SizeItems As New ArrayList
    Private StartPositionItems As New ArrayList
    Private EndtPositionItems As New ArrayList

#Region "Estas opciones solo se usan para crear el archivo de temas para el explorador de soluciones"

    'Une el archivo xml y el contenido de los archivos.
    Public Sub Unir(ByVal Path As String)
        'NumericFile = 0
        ''Graba las estructuras del archivo.
        'Dim ContenidoVLP As String = "<?xml version=" & """1.0""" & " encoding=""utf-8""?>" & vbNewLine & _
        '"<FileHistory>" & vbNewLine & vbNewLine & "</FileHistory>"
        'Dim sw As New StreamWriter("History.xml")
        'sw.Write(ContenidoVLP)
        'sw.Close()
        'For i = 0 To ListView1.Items.Count - 1
        '    CreateHistory(ListView1.Items(i).Name, "History.xml")
        'Next
        'UnirAllFile(Path)
    End Sub

    'Lee el archivo xml contenido en el archivo.
    Public Function ReadHistory()
        If My.Computer.FileSystem.DirectoryExists("History") = True Then
            Dim FileRead As New StreamReader("History/History.xml", True)
            Return FileRead.ReadToEnd
        Else
            MsgBox("El archivo no existe.", MsgBoxStyle.Critical)
        End If
    End Function

    'Une los archivos nesesarios.
    Private Sub UnirAllFile(ByVal Path As String)
        Using write As New FileStream(Path, FileMode.Create)
            Try
                Dim HistoryBytes As Byte() = File.ReadAllBytes("History.xml")
                For Each Item In BytesArray
                    write.Write(Item, 0, Item.Length)
                Next
                write.Write(HistoryBytes, 0, HistoryBytes.Length)

                'write.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Using
    End Sub

    'Crea el historial de datos de todos los archivos agregados.
    Public Sub CreateHistory(ByVal Path As String, ByVal DesteniPath As String)
        'NumericFile = NumericFile + 1
        'Dim ValueKey As String = "File" & NumericFile
        ''Se crea una variable para acceder al documento XML.
        'Dim Documento_xml As New XmlDocument
        ''Se indica la ubicación del fichero y se abre.
        'Documento_xml.Load(DesteniPath)
        'Dim NewFileInfo As New FileInfo(Path)
        'Dim NodeRaiz As XmlElement = Documento_xml.CreateElement("History")
        'NodeRaiz.SetAttribute("Files", ValueKey)
        'Dim Files As XmlElement = Documento_xml.CreateElement("Name")
        'Files.InnerText = My.Computer.FileSystem.GetName(Path) ' Nombre del archivo.
        'NodeRaiz.AppendChild(Files)
        'Dim Files1 As XmlElement = Documento_xml.CreateElement("Size")
        'Files1.InnerText = NewFileInfo.Length - 1 ' Tamaño del archivo.
        'NodeRaiz.AppendChild(Files1)
        'Dim Files4 As XmlElement = Documento_xml.CreateElement("StartPosition")
        'Files4.InnerText = ListView1.Items(NumericFile - 1).SubItems(2).Text 'Posicion donde comiensan los bytes del siguiente archivo.
        'NodeRaiz.AppendChild(Files4)
        'Dim Files5 As XmlElement = Documento_xml.CreateElement("EndPosition")
        'Files5.InnerText = ListView1.Items(NumericFile - 1).SubItems(3).Text 'Posicion o tamaño hasta donde se ba a extraer bytes del archivo.
        'NodeRaiz.AppendChild(Files5)
        ''Se obtiene el nodo raiz que en este caso se corresponde con la etiqueta articulos.
        'Dim nodo_raiz As XmlNode = Documento_xml.DocumentElement
        ''Se inserta el artículo al final del archivo dentro del nodo raiz.
        'nodo_raiz.InsertAfter(NodeRaiz, nodo_raiz.LastChild)
        ''Guarda los codigos en el archivo vlp.
        'Documento_xml.Save(DesteniPath)
    End Sub

#End Region

    'Lee el contenido xml del archivo history.
    Public Sub ReadXMLFile(ByVal Path As String)
        Dim m_xmld As XmlDocument
        Dim m_nodelist As XmlNodeList
        Try
            m_xmld = New XmlDocument()
            m_xmld.Load(Path)
            m_nodelist = m_xmld.SelectNodes("/FileHistory/History")
            Select Case m_nodelist(0).Attributes.GetNamedItem("Files").Value
                Case "File1"
                    For Each Id1 As XmlElement In m_nodelist
                        Dim NameItemsXML As String = Id1.Item("Name").InnerText
                        Dim SizeItemsXML As String = Id1.Item("Size").InnerText
                        Dim StartPositionXML As String = Id1.Item("StartPosition").InnerText
                        Dim EndPositionsItemsXML As String = Id1.Item("EndPosition").InnerText
                        AddInfoItems(NameItemsXML, SizeItemsXML, StartPositionXML, EndPositionsItemsXML)
                    Next
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ListItemsFiles(ByVal ListView1 As ListView, ByVal Path As String, ByVal ImageList1 As ImageList)
        ClearVariables()

        ListView1.Items.Clear()

        Open(Path)

        For i = 0 To NameItems.Count - 1
            ImageList1.Images.Add(ExtractedImage(Path, i))
            ListView1.Items.Add(NameItems(i), i)
        Next
    End Sub

    'Extrae el archivo xml.
    Public Function ExtraerHistory(ByVal Path As String)
        Try
            Dim sw As New StreamWriter("History/History.xml", False, Encoding.Default)
            Dim ContenidoVLP As String = "<?xml version=" & """1.0""" & " encoding=""utf-8""?>"

            'Crea la carpetas necesarias para poder escribir en el archivo de texto.
            If My.Computer.FileSystem.DirectoryExists("History") = True Then
            Else
                My.Computer.FileSystem.CreateDirectory("History")
            End If

            'Abre el archivo para su lectura.
            Dim sr As New System.IO.StreamReader(Path, Encoding.UTF8)
            Dim String1 As String = ""

            While sr.Peek() <> -1
                String1 = sr.ReadLine()

                If String.IsNullOrEmpty(String1) Then
                    Continue While
                End If

                Textos1.Add(String1)
            End While

            sr.Close()

            '====================Lee y crea el Historial de los archivos.================================'
            Dim TotalLine As Integer = Textos1.Count - 1
            For i = TotalLine To 0 Step -1
                Dim Contenet As String = Textos1(i)

                NewMatriz.Add(Textos1(i))

                If Contenet.Contains("<FileHistory>") = True Then
                    Exit For
                End If
            Next i

            NewMatriz.Add(ContenidoVLP)

            For j = NewMatriz.Count - 1 To 0 Step -1
                sw.Write(NewMatriz(j) & vbNewLine)
            Next j

            sw.Close()

            Dim sr2 As New StreamReader("History/History.xml", Encoding.Default)
            Dim TotalText As String = sr2.ReadToEnd
            sr2.Close()

            Return TotalText

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    'Agrega la info nesesario en las variables antes declaradas.
    Private Sub AddInfoItems(ByVal Name As String, ByVal Size As Integer, ByVal StartPosition As Integer, ByVal EndtPosition As Integer)
        NameItems.Add(Name)
        SizeItems.Add(Size)
        StartPositionItems.Add(StartPosition)
        EndtPositionItems.Add(EndtPosition)
    End Sub

    'Extrae una imagen de bytes y la convierte en imagen.
    Public Function Extracted(ByVal Path As String, Optional ByVal ExtractedImg As Boolean = False)
        Dim BytesFile As Byte() = File.ReadAllBytes(Path)
        Dim by() As Byte
        Using Read As New FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.Read)

            'Dim Pos As Integer = ListView1.FocusedItem.SubItems(2).Text
            'Dim EndPos As Integer = ListView1.FocusedItem.SubItems(3).Text
            'Read.Seek(Pos, SeekOrigin.Begin)
            'ReDim by(0 To EndPos - 1)
            'Read.Read(by, 0, EndPos)
            'Dim ms As MemoryStream = New MemoryStream(by)

            'If ExtractedImg = True Then
            '    File.WriteAllBytes(ListView1.FocusedItem.Text, by)
            'Else
            '    PictureBox1.Image = New Bitmap(ms)
            'End If

            Return by 'New Bitmap(ms)
        End Using
    End Function

    'Añade los archivos al listview con todos los datos necesarios.
    Public Sub AddItems(ByVal Path As String)
        'Dim SumaTotal As Integer = 0
        'Dim LastItems As Integer = ListView1.Items.Count - 1
        'Dim NewFileInfo As New FileInfo(Path)
        'Dim NewName As String = My.Computer.FileSystem.GetName(Path)
        'Dim NewListViewItems As ListViewItem = New ListViewItem(NewName)
        'NewListViewItems.Name = Path ' Introduce la ruta del archivo.
        'NewListViewItems.SubItems.Add(NewFileInfo.Length)
        'If ListView1.Items.Count <= 0 Then
        '    NewListViewItems.SubItems.Add(0) ' Estar position file.
        'ElseIf ListView1.Items.Count > 1 Then
        '    Dim Value1 As Integer = ListView1.Items(ListView1.Items.Count - 1).SubItems(3).Text
        '    Dim Value2 As Integer = ListView1.Items(ListView1.Items.Count - 1).SubItems(2).Text
        '    SumaTotal = Value1 + Value2
        '    NewListViewItems.SubItems.Add(SumaTotal)
        'Else
        '    NewListViewItems.SubItems.Add(ListView1.Items(LastItems).SubItems(3).Text) ' Estar position file.
        'End If
        'NewListViewItems.SubItems.Add(NewFileInfo.Length) ' End position file.
        'ListView1.Items.Add(NewListViewItems)
        'Dim BytesFiles As Byte() = File.ReadAllBytes(Path)
        'BytesArray.Add(BytesFiles)
    End Sub

    'Opcion que se encarga de leer el archivo history contenido en el archivo .pak
    Public Sub Open(ByVal Path As String)
        ExtraerHistory(Path)
        ReadXMLFile("History/History.xml")
    End Sub

    Private Function ExtractedImage(ByVal Path As String, ByVal Index As Integer) As Image
        Dim BytesFile As Byte() = File.ReadAllBytes(Path)
        Dim by() As Byte
        Using Read As New FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.Read)

            Dim Pos As Integer = StartPositionItems(Index)
            Dim EndPos As Integer = EndtPositionItems(Index)
            Read.Seek(Pos, SeekOrigin.Begin)
            ReDim by(0 To EndPos - 1)
            Read.Read(by, 0, EndPos)
            Dim ms As MemoryStream = New MemoryStream(by)

            Return New Bitmap(ms)
        End Using
    End Function

    'Vuelbe las variables a su estado inicial.
    Private Sub ClearVariables()
        BytesArray.Clear()
        Textos1.Clear()
        NewMatriz.Clear()
        PlusNumeric = 0
        NumericFile = 0
        PathFile = ""

        NameItems.Clear()
        SizeItems.Clear()
        StartPositionItems.Clear()
        EndtPositionItems.Clear()
    End Sub

    Public Sub ReaderAndConfigure(ByVal ImageListControl As ImageList, ByVal PathFile As String)
        Open(PathFile)

        For i = 0 To NameItems.Count - 1
            ImageListControl.Images.Add(ExtractedImage(PathFile, i))
        Next

    End Sub

End Class
