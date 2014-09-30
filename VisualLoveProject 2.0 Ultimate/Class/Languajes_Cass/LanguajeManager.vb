Imports System.Xml

Public Class LanguajeManager

    Private PathLanguajeFile As String = ""
    Private LongRegist As String = ""

    Public Sub New(ByVal PathFileLanguaje As String)
        PathLanguajeFile = PathFileLanguaje
    End Sub

    Public Sub Load()
        'Function para cargar las cosas necesarias para el formulario1.
        LoadMainForm()
    End Sub

    Private Sub LoadMainForm()
        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            'Dim m_node As XmlNode
            m_xmld = New XmlDocument()
            m_xmld.Load(PathLanguajeFile)

            'Carga y seleccionar el MainForm.
            m_nodelist = m_xmld.SelectNodes("/VisualLoveProject/Location/Form")

            'Ponemos un select case para saber que item mostrar.
            Select Case m_nodelist(0).Attributes.GetNamedItem("FormSelect").Value
                Case "MainForm"
                    For Each Id1 As XmlElement In m_nodelist

                        'Carga los textos del Menu Archivo.
                        MainForm1.TSMI_File.Text = Id1.Item("TSMI_File").InnerText
                        MainForm1.TSMI_NewProject.Text = Id1.Item("TSMI_NewProject").InnerText
                        MainForm1.TSMI_OpenProject.Text = Id1.Item("TSMI_OpenProject").InnerText
                        MainForm1.TSMI_CloseProject.Text = Id1.Item("TSMI_CloseProject").InnerText
                        MainForm1.TSMI_CloseTab.Text = Id1.Item("TSMI_CloseTab").InnerText
                        MainForm1.TSMI_CloseAllTab.Text = Id1.Item("TSMI_CloseAllTab").InnerText
                        MainForm1.TSMI_Save.Text = Id1.Item("TSMI_Save").InnerText
                        MainForm1.TSMI_SaveAll.Text = Id1.Item("TSMI_SaveAll").InnerText
                        MainForm1.TSMI_RecentProject.Text = Id1.Item("TSMI_RecentProject").InnerText
                        MainForm1.TSMI_Exit.Text = Id1.Item("TSMI_Exit").InnerText

                        'Carga los textos del Menu Edit.
                        MainForm1.TSMI_Edit.Text = Id1.Item("TSMI_Edit").InnerText
                        MainForm1.TSMI_Undo.Text = Id1.Item("TSMI_Undo").InnerText
                        MainForm1.TSMI_Redo.Text = Id1.Item("TSMI_Redo").InnerText
                        MainForm1.TSMI_Cut.Text = Id1.Item("TSMI_Cut").InnerText
                        MainForm1.TSMI_Copy.Text = Id1.Item("TSMI_Copy").InnerText
                        MainForm1.TSMI_Paste.Text = Id1.Item("TSMI_Paste").InnerText
                        MainForm1.TSMI_GotoIn.Text = Id1.Item("TSMI_GotoIn").InnerText
                        MainForm1.TSMI_Find.Text = Id1.Item("TSMI_Find").InnerText
                        MainForm1.TSMI_Replace.Text = Id1.Item("TSMI_Replace").InnerText
                        MainForm1.TSMI_SelectAll.Text = Id1.Item("TSMI_SelectAll").InnerText
                        MainForm1.TSMI_Delete.Text = Id1.Item("TSMI_Delete").InnerText

                        'Carga los textos del Menu Project.
                        MainForm1.TSMI_Project.Text = Id1.Item("TSMI_Project").InnerText
                        MainForm1.TSMI_ViewExplored.Text = Id1.Item("TSMI_ViewExplored").InnerText
                        MainForm1.TSMI_RefreshProject.Text = Id1.Item("TSMI_RefreshProject").InnerText
                        MainForm1.TSMI_PropertyProject.Text = Id1.Item("TSMI_PropertyProject").InnerText

                        'Carga los textos del Menu Generate.
                        MainForm1.TSMI_Generate.Text = Id1.Item("TSMI_Generate").InnerText
                        MainForm1.TSMI_GenerateLove.Text = Id1.Item("TSMI_GenerateLove").InnerText
                        MainForm1.TSMI_GenerateExe.Text = Id1.Item("TSMI_GenerateExe").InnerText

                        'Carga los textos del Menu Debug.
                        MainForm1.TSMI_Debug.Text = Id1.Item("TSMI_Debug").InnerText
                        MainForm1.TSMI_StartDebugging.Text = Id1.Item("TSMI_StartDebugging").InnerText
                        MainForm1.TSMI_StopDebugging.Text = Id1.Item("TSMI_StopDebugging").InnerText

                        'Carga los textos del Menu Tool.
                        MainForm1.TSMI_Tool.Text = Id1.Item("TSMI_Tool").InnerText
                        MainForm1.TSMI_Color.Text = Id1.Item("TSMI_Color").InnerText
                        MainForm1.TSMI_AssosiateExtencion.Text = Id1.Item("TSMI_AssosiateExtencion").InnerText
                        MainForm1.TSMI_AttachContextMenu.Text = Id1.Item("TSMI_AttachContextMenu").InnerText
                        MainForm1.TSMI_Options.Text = Id1.Item("TSMI_Options").InnerText

                        'Carga los textos del Menu Wiki.
                        MainForm1.TSMI_Wiki.Text = Id1.Item("TSMI_Wiki").InnerText
                        MainForm1.TSMI_Example.Text = Id1.Item("TSMI_Example").InnerText
                        MainForm1.TSMI_HomePage.Text = Id1.Item("TSMI_HomePage").InnerText
                        MainForm1.TSMI_Tutorials.Text = Id1.Item("TSMI_Tutorials").InnerText
                        MainForm1.TSMI_Function.Text = Id1.Item("TSMI_Function").InnerText
                        MainForm1.TSMI_AboutMe.Text = Id1.Item("TSMI_AboutMe").InnerText
                        MainForm1.TSMI_DateOfCreate.Text = Id1.Item("TSMI_DateOfCreate").InnerText
                        MainForm1.TSMI_UltimateRevision.Text = Id1.Item("TSMI_UltimateRevision").InnerText
                        MainForm1.TSMI_VersionApplication.Text = Id1.Item("TSMI_VersionApplication").InnerText

                        'Carga los textos del Menu Languaje.
                        MainForm1.TSMI_Languaje.Text = Id1.Item("TSMI_Languaje").InnerText
                        MainForm1.TSMI_Package.Text = Id1.Item("TSMI_Package").InnerText
                    Next
            End Select

        Catch ex As Exception
            LongRegist = LongRegist & vbCrLf & " LoadMainForm: " & ex.Message
        End Try
    End Sub

End Class
