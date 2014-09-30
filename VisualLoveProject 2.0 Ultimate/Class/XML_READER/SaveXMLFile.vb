Imports System.Xml
Imports System.IO

Public Class SaveXMLFile
    'Funtion para crear archivo de lenguajes.
    Public Sub CreateXML(ByVal Path As String)
        Try
            'Graba las estructuras del vlp.
            Dim LangFile As String = "<?xml version=" & """1.0""" & " encoding=""utf-8""?>" & vbNewLine & _
            "<VisualLoveProject>" & vbNewLine & vbNewLine & "</VisualLoveProject>"
            Dim sw As New StreamWriter(Path)
            sw.Write(LangFile)
            sw.Close()
            '---------------------------------------------------------------------------------------------------

            'Se crea una variable para acceder al documento XML.
            Dim Documento_xml As New XmlDocument
            'Se indica la ubicación del fichero y se abre.
            Documento_xml.Load(Path)

            '---------------------------------------------------------------------------------------------------

            Dim NodeRaiz As XmlElement = Documento_xml.CreateElement("Location")
            NodeRaiz.SetAttribute("Language", "Ingles")

            Dim NodeRaiz2 As XmlElement = Documento_xml.CreateElement("Form")
            NodeRaiz2.SetAttribute("FormSelect", "MainForm")

            '=======================================Menu File=========================================================
            'Dim ListViewForm = MainForm1.ListView1.Items

            'Dim TSMI_File As XmlElement = Documento_xml.CreateElement("TSMI_File")
            'TSMI_File.InnerText = ListViewForm(0).Text '"File"
            'NodeRaiz2.AppendChild(TSMI_File)


            'Dim TSMI_NewProject As XmlElement = Documento_xml.CreateElement("TSMI_NewProject")
            'TSMI_NewProject.InnerText = ListViewForm(1).Text '"New Project"
            'NodeRaiz2.AppendChild(TSMI_NewProject)

            '======================================Separador==========================================================

            Dim NotLine As XmlElement = Documento_xml.CreateElement("NotLine")
            NotLine.InnerText = "================================Menu Edit======================================"
            NodeRaiz2.AppendChild(NotLine)

            '=======================================Menu Edit=========================================================

            'Dim TSMI_Edit As XmlElement = Documento_xml.CreateElement("TSMI_Edit")
            'TSMI_Edit.InnerText = ListViewForm(10).Text
            'NodeRaiz2.AppendChild(TSMI_Edit)


            'Dim TSMI_Undo As XmlElement = Documento_xml.CreateElement("TSMI_Undo")
            'TSMI_Undo.InnerText = ListViewForm(11).Text
            'NodeRaiz2.AppendChild(TSMI_Undo)

            '===============================================================================================

            'Se obtiene el nodo raiz que en este caso se corresponde con la etiqueta articulos.
            Dim nodo_raiz As XmlNode = Documento_xml.DocumentElement

            'Se inserta el artículo al final del archivo dentro del nodo raiz.
            nodo_raiz.InsertAfter(NodeRaiz, nodo_raiz.LastChild)

            '=========================================================================
            'Se inserta el artículo al final del archivo dentro del nodo raiz.
            NodeRaiz.InsertAfter(NodeRaiz2, NodeRaiz.LastChild)
            '=========================================================================

            'Guarda los codigos en el archivo vlp.
            Documento_xml.Save(Path)

        Catch ex As Exception
            'Error trapping
            'TextBox2.Text += ex.ToString()
        End Try

    End Sub
End Class
