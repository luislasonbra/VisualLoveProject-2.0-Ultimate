Imports System.Xml
Imports FastColoredTextBoxNS
Imports System.IO

Public Class FileFolderCreator

    'abre las configuraciones de los folder, las edita y las guarda.
    Private Sub EditAndSaveXML(ByVal Path As String) ', ByVal NameFile As String)
        Dim Tab = MainForm1.TC_Editor
        'Dim fctb = CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)

        Dim m_xmld As XmlDocument
        Dim m_nodelist As XmlNodeList
        'Dim m_node As XmlNode
        m_xmld = New XmlDocument()
        m_xmld.Load(Path)

        'Carga y selecciona la lista 1.
        m_nodelist = m_xmld.SelectNodes("/VisualLoveProject/Conf")


        'For j = 0 To Tab.TabCount - 1
        '    Dim fctb = CType(Tab.TabPages(j).Controls.Item(0), FastColoredTextBox)

        '    For i = 0 To fctb.LinesCount - 1
        '        If fctb.GetVisibleState(i) = VisibleState.StartOfHiddenBlock Then
        '            For Each Id1 As XmlElement In m_nodelist
        '                If Id1.Item("File").InnerText = Tab.TabPages(j).Text Then
        '                    Id1.Item("LineFile").InnerText = i
        '                End If
        '            Next
        '        End If
        '    Next

        'Next

        For j = 0 To Tab.TabCount - 1
            For Each Id1 As XmlElement In m_nodelist
                If Id1.Item("File").InnerText = Tab.TabPages(j).Text Then
                    Id1.Item("LineFile").InnerText = ""
                End If
            Next
        Next

        m_xmld.Save(Path)

    End Sub

    'abre las configuraciones de los folder.
    Private Sub LoadXML(ByVal Path As String)
        Dim Tab = MainForm1.TC_Editor
        'Dim fctb = CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)

        Dim m_xmld As XmlDocument
        Dim m_nodelist As XmlNodeList
        'Dim m_node As XmlNode
        m_xmld = New XmlDocument()
        m_xmld.Load(Path)

        'Carga y selecciona la lista 1.
        m_nodelist = m_xmld.SelectNodes("/VisualLoveProject/Conf")

        For j = 0 To Tab.TabCount - 1
            Dim fctb = CType(Tab.TabPages(j).Controls.Item(0), FastColoredTextBox)

            For Each Id1 As XmlElement In m_nodelist
                If Id1.Item("File").InnerText = Tab.TabPages(j).Text Then
                    fctb.CollapseFoldingBlock(Id1.Item("LineFile").InnerText)
                End If
            Next
        Next

    End Sub

    'Guarda las configuraciones de los folder.
    Private Sub SaveXML(ByVal Path As String, ByVal DataSave As String, ByVal NameFile As String)
        Dim fctb = CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)

        'Se crea una variable para acceder al documento XML.
        Dim Documento_xml As New XmlDocument
        'Se indica la ubicación del fichero y se abre.
        Documento_xml.Load(Path)

        Dim NodeRaiz As XmlElement = Documento_xml.CreateElement("Conf")
        NodeRaiz.SetAttribute("Folder", "Folder Options")

        'Guarda el nombre del archivo. 
        Dim Ico As XmlElement = Documento_xml.CreateElement("File")
        Ico.InnerText = NameFile ' Nombre del archivo.
        NodeRaiz.AppendChild(Ico)

        'Guarda la linea del archivo a guardar. 
        Dim VersionLove As XmlElement = Documento_xml.CreateElement("LineFile")
        VersionLove.InnerText = DataSave
        NodeRaiz.AppendChild(VersionLove)

        'Se obtiene el nodo raiz que en este caso se corresponde con la etiqueta articulos.
        Dim nodo_raiz As XmlNode = Documento_xml.DocumentElement
        'Se inserta el artículo al final del archivo dentro del nodo raiz.
        nodo_raiz.InsertAfter(NodeRaiz, nodo_raiz.LastChild)

        'Guarda los codigos en el archivo vlp.
        Documento_xml.Save(Path)

    End Sub

    'Noce utiliza.
    Private Sub SaveXML_2(ByVal Path As String)
        Dim Tab = MainForm1.TC_Editor
        'Dim fctb = CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)

        Dim m_xmld As XmlDocument
        Dim m_nodelist As XmlNodeList
        'Dim m_node As XmlNode
        m_xmld = New XmlDocument()
        m_xmld.Load(Path)

        'Carga y selecciona la lista 1.
        m_nodelist = m_xmld.SelectNodes("/VisualLoveProject/Conf")

        For j = 0 To Tab.TabCount - 1
            Dim fctb = CType(Tab.TabPages(j).Controls.Item(0), FastColoredTextBox)

            For Each Id1 As XmlElement In m_nodelist
                If Id1.Item("File").InnerText = Tab.TabPages(j).Text Then

                    For i = 0 To fctb.LinesCount - 1
                        If fctb.GetVisibleState(i) = VisibleState.StartOfHiddenBlock Then
                            Id1.Item("LineFile").InnerText = i
                        End If
                    Next

                End If
            Next
        Next

        m_xmld.Save(Path)
    End Sub

    '============================================================================================

    Public Sub SaveXmlFolderSetting(ByVal Path As String)
        Dim Tab = MainForm1.TC_Editor

        'Graba las estructuras del vlp.
        Dim ContenidoVLP As String = "<?xml version=" & """1.0""" & " encoding=""utf-8""?>" & vbNewLine & _
        "<VisualLoveProject>" & vbNewLine & vbNewLine & "</VisualLoveProject>"
        Dim sw As New StreamWriter(Path)
        sw.Write(ContenidoVLP)
        sw.Close()
        '---------------------------------------------------------------------------------------------------

        For j = 0 To Tab.TabCount - 1
            Dim fctb = CType(Tab.TabPages(j).Controls.Item(0), FastColoredTextBox)

            For i = 0 To fctb.LinesCount - 1
                If fctb.GetVisibleState(i) = VisibleState.StartOfHiddenBlock Then
                    SaveXML(Path, i, Tab.TabPages(j).Text)
                End If
            Next
        Next

    End Sub

    Public Sub LoadXmlFolderSetting(ByVal Path As String)
        LoadXML(Path)
    End Sub

End Class
