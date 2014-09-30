Imports System.Xml

Public Class ReadXMLFile

    Private Sub ReadFileVLP(ByVal Path As String)
        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            'Dim m_node As XmlNode
            m_xmld = New XmlDocument()
            m_xmld.Load(Path)

            'Carga y seleccionar el MainForm.
            m_nodelist = m_xmld.SelectNodes("/VisualLoveProject/Location/Form")

            'Ponemos un select case para saber que item mostrar.
            Select Case m_nodelist(0).Attributes.GetNamedItem("FormSelect").Value
                Case "MainForm"
                    For Each Id1 As XmlElement In m_nodelist

                        'ListViewForm(20).Text = Id1.Item("TSMI_Delete").InnerText

                    Next
                Case ""

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
