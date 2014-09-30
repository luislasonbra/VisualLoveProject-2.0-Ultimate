Imports System.Xml
Imports System.IO

Public Class PropertiesForm

    Private Sub OpenConfig(ByVal Path As String)
        'Se declara una variable para almacenar el documento XML
        Dim Documento_xml As New XmlDocument

        'Cargar en la variable el fichero
        Documento_xml.Load(Path)

        'Se define el nodo raiz
        Dim Nodos As XmlNode = Documento_xml.DocumentElement

        For Each persona As XmlElement In Nodos.ChildNodes
            TB_Ico.Text = persona.Item("Ico").InnerText
            TB_Author.Text = persona.Item("Author").InnerText
            TB_Version.Text = persona.Item("Version").InnerText
            TB_Company.Text = persona.Item("Company").InnerText
            TB_DateCreate.Text = persona.Item("Date").InnerText
        Next

    End Sub

    Private Sub SaveSetting(ByVal Path As String)
        'Graba las estructuras del vlp.
        Dim ContenidoVLP As String = "<?xml version=" & """1.0""" & " encoding=""utf-8""?>" & vbNewLine & _
        "<VisualLoveProject>" & vbNewLine & vbNewLine & "</VisualLoveProject>"
        Dim sw As New StreamWriter(Path)
        sw.Write(ContenidoVLP)
        sw.Close()
        '---------------------------------------------------------------------------------------------------

        'Se crea una variable para acceder al documento XML.
        Dim Documento_xml As New XmlDocument

        'Se indica la ubicación del fichero y se abre.
        Documento_xml.Load(Path)

        Dim NodeRaiz As XmlElement = Documento_xml.CreateElement("Conf")
        NodeRaiz.SetAttribute("Love", "Vlp Opciones")

        Dim RutaDefault As String = Application.StartupPath & "\Default-Ico\icon.ico"
        'Guarda Icono. 
        Dim Ico As XmlElement = Documento_xml.CreateElement("Ico")
        Ico.InnerText = RutaDefault
        NodeRaiz.AppendChild(Ico)

        'Guarda Autor. 
        Dim Author As XmlElement = Documento_xml.CreateElement("Author")
        Author.InnerText = "VisualLoveProject"
        NodeRaiz.AppendChild(Author)

        'Guarda Version de seleccion. 
        Dim VersionCombox As String = CB_LoveVersion.SelectedItem 'Modificar mas tarde.
        Dim Clear As String = VersionCombox.Remove(0, 5)
        Dim Version As XmlElement = Documento_xml.CreateElement("Version")
        Version.InnerText = Clear
        NodeRaiz.AppendChild(Version)

        'Guarda Company. 
        Dim Company As XmlElement = Documento_xml.CreateElement("Company")
        Company.InnerText = "Dark"
        NodeRaiz.AppendChild(Company)

        'Guarda Date. 
        Dim Date1 As XmlElement = Documento_xml.CreateElement("Date")
        Date1.InnerText = My.Computer.Clock.LocalTime.ToString
        NodeRaiz.AppendChild(Date1)

        'Se obtiene el nodo raiz que en este caso se corresponde con la etiqueta articulos.
        Dim nodo_raiz As XmlNode = Documento_xml.DocumentElement

        'Se inserta el artículo al final del archivo dentro del nodo raiz.
        nodo_raiz.InsertAfter(NodeRaiz, nodo_raiz.LastChild)

        'Guarda los codigos en el archivo vlp.
        Documento_xml.Save(Path)
    End Sub

    'Carga la configuracion del archivo vlp.
    Private Sub UpdateVLP()
        Dim rutaXML As String = MainForm1.TSSL_Path.Text
        'Se declara una variable para almacenar el documento XML
        Dim documento_xml As New XmlDocument
        'Cargar en la variable el fichero
        documento_xml.Load(rutaXML)
        'Se define el nodo raiz
        Dim personas As XmlNode = documento_xml.DocumentElement
        For Each persona As XmlElement In personas.ChildNodes
            Me.TB_Ico.Text = persona.Item("Ico").InnerText '& Environment.NewLine
            Me.TB_Author.Text = persona.Item("Autor").InnerText '& Environment.NewLine
            Me.TB_Version.Text = persona.Item("Version").InnerText '& Environment.NewLine
            Me.TB_Company.Text = persona.Item("Company").InnerText '& Environment.NewLine
            Me.TB_DateCreate.Text = persona.Item("Date").InnerText '& Environment.NewLine
        Next
    End Sub

    Private Sub PropertiesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UpdateVLP()
    End Sub
End Class