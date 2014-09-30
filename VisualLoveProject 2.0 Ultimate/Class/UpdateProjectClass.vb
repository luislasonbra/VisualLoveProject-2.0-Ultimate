Imports System.IO
Imports System.Xml

Public Class UpdateProjectClass

    Public NameProject As String = ""
    Public LoveVersion As String = ""
    Public AppVersion As String = "1.0"
    Public NameCompany As String = ""
    Public NameAuthor As String = ""
    Public PathIcon As String = ""
    Public TimerCreate As String = ""

    'Recorta la ruta del archivo, para poder renombrarlo.
    Public Function CutNamePath(ByVal PathFile As String, ByVal NewName As String) As String
        Dim t1 As Integer = Len(My.Computer.FileSystem.GetName(PathFile))
        Dim t2 = Mid(PathFile, 1, Len(PathFile) - t1)

        Return t2 & NewName
    End Function

    'Remuebe la extencion del archivo. 
    Public Function RemoveExtencion(ByVal NameFile As String) As String
        Dim t2 = Mid(NameFile, 1, Len(NameFile) - 4)

        Return t2
    End Function

    'Recorta la ruta del archivo, para poder renombrarlo.
    Public Function CutPathIconCopy(ByVal PathFile As String) As String
        Dim t1 As Integer = Len(My.Computer.FileSystem.GetName(PathFile))
        Dim t2 = Mid(PathFile, 1, Len(PathFile) - t1)

        Return t2
    End Function

    'Copia el icono a la carpeta del proyecto.
    Public Function CopyIconToFolderProject(ByVal Path As String, ByVal CopyKey As Boolean) As String
        'Dim PathProject As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Visual love project\" & NameProject & "\" & "Icon\"

        Dim PathProject As String = CutPathIconCopy(MainForm1.Path_Project) & "Icon"

        If CopyKey = True Then
            Try
                If My.Computer.FileSystem.DirectoryExists(PathProject) = True Then
                    IO.File.Copy(Path, PathProject & "icon.ico", True)
                Else
                    My.Computer.FileSystem.CreateDirectory(PathProject)
                    IO.File.Copy(Path, PathProject & "icon.ico", True)
                End If
            Catch ex As Exception
                'MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If

        Return PathProject & "icon.ico"
    End Function

    'Abre la imagen y la libera.
    Public Function OpenImageToLiberate(ByVal PathImage As String)
        Dim BytesFile = File.ReadAllBytes(PathImage)
        Dim ms As New MemoryStream(BytesFile)

        Return New Bitmap(ms)
    End Function

    'Guarda la configuracion para el archivo vlp.
    Public Sub SaveLoveSetting()

        'Dim rutaXML As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments _
        '                    & "\Visual love project\" & NameProject & "\" & NameProject & ".vlp"

        Dim rutaXML As String = CutPathIconCopy(MainForm1.Path_Project) & NameProject & ".vlp"

        'Graba las estructuras del vlp.
        Dim ContenidoVLP As String = "<?xml version=" & """1.0""" & " encoding=""utf-8""?>" & vbNewLine & _
        "<VisualLoveProject>" & vbNewLine & vbNewLine & "</VisualLoveProject>"
        Dim sr As New StreamWriter(rutaXML)
        sr.Write(ContenidoVLP)
        sr.Close()

        'Se crea una variable para acceder al documento XML.
        Dim documento_xml As New XmlDocument
        'Se indica la ubicación del fichero y se abre.
        documento_xml.Load(rutaXML)
        Dim FileStart As XmlElement = documento_xml.CreateElement("Conf")
        FileStart.SetAttribute("Love", "Vlp Opciones")

        'Guarda Icono. 
        Dim Icono As XmlElement = documento_xml.CreateElement("Icon")
        Icono.InnerText = PathIcon
        FileStart.AppendChild(Icono)

        'Guarda Autor. 
        Dim Autor As XmlElement = documento_xml.CreateElement("Author")
        Autor.InnerText = NameAuthor
        FileStart.AppendChild(Autor)

        'Guarda la Version de la aplicacion. 
        Dim Version As XmlElement = documento_xml.CreateElement("LoveVersion")
        Version.InnerText = LoveVersion
        FileStart.AppendChild(Version)

        'Guardar la configuracion de la app.
        Dim VersionFile As XmlElement = documento_xml.CreateElement("Version")
        VersionFile.InnerText = AppVersion
        FileStart.AppendChild(VersionFile)

        'Guarda Company. 
        Dim Company As XmlElement = documento_xml.CreateElement("Company")
        Company.InnerText = NameCompany
        FileStart.AppendChild(Company)

        'Guarda Date. 
        Dim Date1 As XmlElement = documento_xml.CreateElement("Date")
        Date1.InnerText = TimerCreate
        FileStart.AppendChild(Date1)

        'Se obtiene el nodo raiz que en este caso se corresponde con la etiqueta articulos.
        Dim nodo_raiz As XmlNode = documento_xml.DocumentElement
        'Se inserta el artículo al final del archivo dentro del nodo raiz.
        nodo_raiz.InsertAfter(FileStart, nodo_raiz.LastChild)
        'Guarda los codigos en el archivo vlp.
        documento_xml.Save(rutaXML)

        UpdateVLP()
    End Sub

    'Modifica el archivo para el archivo vlp.
    Public Sub ModifyLoveSetting()
        'Dim rutaXML As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments _
        '                  & "\Visual love project\" & NameProject & "\" & NameProject & ".vlp"

        Dim rutaXML As String = CutPathIconCopy(MainForm1.Path_Project) & NameProject & ".vlp"
        'Se declara una variable para almacenar el documento XML
        Dim documento_xml As New XmlDocument
        'Cargar en la variable el fichero
        documento_xml.Load(rutaXML)
        'Se define el nodo raiz
        Dim personas As XmlNode = documento_xml.DocumentElement
        For Each persona As XmlElement In personas.ChildNodes
            persona.Item("Icon").InnerText = PathIcon
            persona.Item("Author").InnerText = NameAuthor
            persona.Item("Version").InnerText = AppVersion
            persona.Item("Company").InnerText = NameCompany
            persona.Item("LoveVersion").InnerText = LoveVersion
        Next

        documento_xml.Save(rutaXML)

        UpdateVLP()
    End Sub

    'Carga la configuracion del archivo vlp.
    Public Sub UpdateVLP()
        'Dim rutaXML As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments _
        '                   & "\Visual love project\" & NameProject & "\" & NameProject & ".vlp"

        Dim rutaXML As String = CutPathIconCopy(MainForm1.Path_Project) & NameProject & ".vlp"

        'Se declara una variable para almacenar el documento XML
        Dim documento_xml As New XmlDocument
        'Cargar en la variable el fichero
        documento_xml.Load(rutaXML)
        'Se define el nodo raiz
        Dim personas As XmlNode = documento_xml.DocumentElement
        For Each persona As XmlElement In personas.ChildNodes
            PropertiesForm.TB_Ico.Text = persona.Item("Icon").InnerText
            PropertiesForm.TB_Author.Text = persona.Item("Author").InnerText
            PropertiesForm.TB_Version.Text = persona.Item("Version").InnerText
            PropertiesForm.TB_Company.Text = persona.Item("Company").InnerText
            PropertiesForm.TB_DateCreate.Text = persona.Item("Date").InnerText

            PropertiesForm.CB_LoveVersion.SelectedItem = "Love " & persona.Item("LoveVersion").InnerText
        Next
    End Sub

    'Debuelve la ruta del icono del proyecto.
    Public Function ReadIconPath(ByVal Path As String) As String
        Dim rutaXML As String = Path
        Dim PathExit As String = ""

        'Se declara una variable para almacenar el documento XML
        Dim documento_xml As New XmlDocument

        'Cargar en la variable el fichero
        documento_xml.Load(rutaXML)

        'Se define el nodo raiz
        Dim personas As XmlNode = documento_xml.DocumentElement
        For Each persona As XmlElement In personas.ChildNodes
            PathExit = persona.Item("Icon").InnerText
        Next

        Return PathExit
    End Function

    'Debuelve la ruta del icono del proyecto.
    Public Function ReadLoveVersion(ByVal Path As String) As String
        Dim rutaXML As String = Path
        Dim LoveVersion As String = ""

        'Se declara una variable para almacenar el documento XML
        Dim documento_xml As New XmlDocument

        'Cargar en la variable el fichero
        documento_xml.Load(rutaXML)

        'Se define el nodo raiz
        Dim personas As XmlNode = documento_xml.DocumentElement
        For Each persona As XmlElement In personas.ChildNodes
            LoveVersion = persona.Item("LoveVersion").InnerText
        Next

        Return LoveVersion
    End Function

    'Debuelve la ruta del icono del proyecto.
    Public Function ReadVlpFunction(ByVal Path As String) As Boolean
        Try
            Dim rutaXML As String = Path
            Dim Icon1 As String = ""
            Dim Author1 As String = ""
            Dim Version1 As String = ""
            Dim Company1 As String = ""
            Dim LoveVersion As String = ""

            'Se declara una variable para almacenar el documento XML
            Dim documento_xml As New XmlDocument

            'Cargar en la variable el fichero
            documento_xml.Load(rutaXML)

            'Se define el nodo raiz
            Dim personas As XmlNode = documento_xml.DocumentElement
            For Each persona As XmlElement In personas.ChildNodes
                LoveVersion = persona.Item("LoveVersion").InnerText
                Icon1 = persona.Item("Icon").InnerText
                Author1 = persona.Item("Author").InnerText
                Version1 = persona.Item("Version").InnerText
                Company1 = persona.Item("Company").InnerText
                LoveVersion = persona.Item("LoveVersion").InnerText
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try

        'Return Icon1 & "," & Author1 & "," & Version1 & "," & Company1 & "," & LoveVersion
    End Function

    'Function para copiar el icono a la carpeta del proyecto creado.
    Public Function CopyIconFile(ByVal NameProjectFile As String, ByVal CopyFileIcon As Boolean) As String
        Dim PathFileIcon As String = Application.StartupPath & "\Default-Ico\icon.ico"
        'Dim FullPathFileProject As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & _
        '    "\Visual Love Project\" & NameProjectFile & "\Icon\icon.ico"

        Dim FullPathFileProject As String = CutPathIconCopy(MainForm1.Path_Project) & "Icon\icon.ico"

        Try
            If My.Computer.FileSystem.FileExists(FullPathFileProject) = True Then
                If CopyFileIcon = True Then
                    My.Computer.FileSystem.CopyFile(PathFileIcon, FullPathFileProject)
                End If
            Else
                My.Computer.FileSystem.CreateDirectory(CutPathIconCopy(MainForm1.TSSL_Path.Text) & "Icon")
                If CopyFileIcon = True Then
                    My.Computer.FileSystem.CopyFile(PathFileIcon, FullPathFileProject)
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, vbCritical)
        End Try

        Return FullPathFileProject
    End Function

End Class