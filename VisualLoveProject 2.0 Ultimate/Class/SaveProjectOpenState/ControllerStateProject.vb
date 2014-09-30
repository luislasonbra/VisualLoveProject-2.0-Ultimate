Imports System.IO
Imports System.Xml

Public Class ControllerStateProject

    Private PathFileConfXML As String
    Private isFirsh As Boolean = True
    Private Sub SaveConfigXML(ByVal PathFile1 As String, ByVal nameFile1 As String, ByVal value As Integer)
        'Se crea una variable para acceder al documento XML.
        Dim Documento_xml As New XmlDocument
        'Se indica la ubicación del fichero y se abre.
        Documento_xml.Load(PathFileConfXML)

        '---------------------------------------------------------------------------------------------------
        Dim NodeRaiz As XmlElement = Documento_xml.CreateElement("TabPage")
        NodeRaiz.SetAttribute("Name", value)

        '================================================================================================
        Dim nameFile As XmlElement = Documento_xml.CreateElement("name")
        nameFile.InnerText = nameFile1
        NodeRaiz.AppendChild(nameFile)

        Dim filePath As XmlElement = Documento_xml.CreateElement("Path")
        filePath.InnerText = PathFile1
        NodeRaiz.AppendChild(filePath)

        '===============================================================================================

        'Se obtiene el nodo raiz que en este caso se corresponde con la etiqueta articulos.
        Dim nodo_raiz As XmlNode = Documento_xml.DocumentElement

        'Se inserta el artículo al final del archivo dentro del nodo raiz.
        nodo_raiz.InsertAfter(NodeRaiz, nodo_raiz.LastChild)

        '================================================================================================

        'Guarda los codigos en el archivo vlp.
        Documento_xml.Save(PathFileConfXML)
    End Sub

    Private Sub LoadConfigXML(ByVal Path As String)
        Dim m_xmld As XmlDocument
        Dim m_nodelist As XmlNodeList
        Try
            m_xmld = New XmlDocument()
            m_xmld.Load(Path)
            m_nodelist = m_xmld.SelectNodes("/VisualLoveProject/TabPage")

            For Each Id1 As XmlElement In m_nodelist
                If My.Computer.FileSystem.FileExists(Id1.Item("Path").InnerText) Then
                    MainForm1.AddTabPage(Id1.Item("Path").InnerText)
                End If
            Next

            'Select Case m_nodelist(0).Attributes.GetNamedItem("Name").Value           
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SaveStateProject(ByVal Path As String)
        PathFileConfXML = Path

        Dim SelectTab As Integer = MainForm1.TC_Editor.SelectedIndex
        If SelectTab < 0 Then SelectTab = 0

        'Graba las estructuras del vlp.
        Dim LangFile As String = "<?xml version=" & """1.0""" & " encoding=""utf-8""?>" & vbNewLine & _
        "<VisualLoveProject>" & vbNewLine & "<SelectedTabPage value=""" & SelectTab & """ />" & vbNewLine & "</VisualLoveProject>"
        Dim sw As New StreamWriter(Path)
        sw.Write(LangFile)
        sw.Close()

        For i = 0 To MainForm1.TC_Editor.TabCount - 1
            SaveConfigXML(MainForm1.TC_Editor.TabPages(i).Name, MainForm1.TC_Editor.TabPages(i).Text, i)
        Next
    End Sub

    Private Sub SelectedTabPage(ByVal Path As String)
        Dim m_xmld As XmlDocument
        Dim m_nodelist As XmlNodeList
        Try
            m_xmld = New XmlDocument()
            m_xmld.Load(Path)
            m_nodelist = m_xmld.SelectNodes("/VisualLoveProject/SelectedTabPage")

            Dim SelectTab As Integer = m_nodelist(0).Attributes.GetNamedItem("value").Value
            If SelectTab < 0 Then SelectTab = 0

            MainForm1.TC_Editor.SelectedIndex = SelectTab

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub OpenStateProject(ByVal Path As String)
        PathFileConfXML = Path
        LoadConfigXML(Path)

        SelectedTabPage(Path)
    End Sub

End Class
