Imports FastColoredTextBoxNS

Public Class UpdateControlStatus

    Public Sub OptionsUpdate()

        'Comprueba que alla un proyecto cargado en el programa.
        If MainForm1.TSSL_Path.Text = "?" Or MainForm1.TSSL_Path.Text = "" Then
            MainForm1.TSB_Close.Enabled = False
            '
            MainForm1.TM_ControlUpdate.Stop()
            '
            MainForm1.TSMI_CloseProject.Enabled = False
            '
            'Opciones del menu proyecto.
            MainForm1.TSMI_ViewExplored.Enabled = False
            MainForm1.TSMI_RefreshProject.Enabled = False
            MainForm1.TSMI_PropertyProject.Enabled = False
            '
            'Opciones del menu Generar.
            MainForm1.TSMI_GenerateLove.Enabled = False
            MainForm1.TSMI_GenerateExe.Enabled = False
            '
            MainForm1.TSB_Refresh.Enabled = False
            '
            MainForm1.TSB_ShowFiles.Enabled = False
            '
            MainForm1.TSB_Property.Enabled = False
            '
            'MainForm.TSMI_RefreshProject.Enabled = False
            '
        Else
            MainForm1.TSB_Close.Enabled = True
            '
            MainForm1.TSMI_CloseProject.Enabled = True
            '
            MainForm1.TSB_Refresh.Enabled = True
            '
            MainForm1.TSB_ShowFiles.Enabled = True
            '
            MainForm1.TSB_Property.Enabled = True
            '
            'MainForm.TSMI_RefreshProject.Enabled = True
            '
            If MainForm1.Key_Run = True Then
                MainForm1.TSB_StartDebugging.Enabled = False
                MainForm1.TSMI_StartDebugging.Enabled = False
            Else
                MainForm1.TSB_StartDebugging.Enabled = True
                MainForm1.TSMI_StartDebugging.Enabled = True
            End If
            '
            'Opciones del menu proyecto.
            MainForm1.TSMI_ViewExplored.Enabled = True
            MainForm1.TSMI_RefreshProject.Enabled = True
            MainForm1.TSMI_PropertyProject.Enabled = True
            '
            'Opciones del menu Generar.
            MainForm1.TSMI_GenerateLove.Enabled = True
            MainForm1.TSMI_GenerateExe.Enabled = True
            '
            MainForm1.TSB_Refresh.Enabled = True
        End If

        'Comprueba que alga pestañas cargadas en el programa.
        If MainForm1.TC_Editor.SelectedIndex >= 0 Then
            MainForm1.TM_ControlUpdate.Start()
            '
            'Opciones del editor de codigo.
            MainForm1.TSMI_CloseTab.Enabled = True '1
            MainForm1.TSMI_CloseAllTab.Enabled = True '2
            MainForm1.TSMI_Save.Enabled = True '3
            MainForm1.TSMI_SaveAll.Enabled = True '4
            MainForm1.TSMI_GotoIn.Enabled = True '5
            MainForm1.TSMI_Find.Enabled = True '6
            MainForm1.TSMI_Replace.Enabled = True '7
            MainForm1.TSMI_SelectAll.Enabled = True '8
            MainForm1.TSB_Save.Enabled = True '9
            MainForm1.TSB_SaveAll.Enabled = True
            '
            MainForm1.TSB_Find.Enabled = True
            MainForm1.TSB_Comment.Enabled = True
            MainForm1.TSB_DesComment.Enabled = True
            MainForm1.TSB_AddBookMark.Enabled = True
            MainForm1.TSB_RemoveBookMark.Enabled = True
            MainForm1.TSB_BookMark.Enabled = True
            MainForm1.TSB_ZoomIn.Enabled = True
            MainForm1.TSB_ZoomOut.Enabled = True
            '
            'ContextMenu para el editor de codigo.
            MainForm1.CMS_GoToLine.Enabled = True
            MainForm1.CMS_Find.Enabled = True
            MainForm1.CMS_Replace.Enabled = True
            MainForm1.CMS_SelectedAll.Enabled = True
            '
            'Comprueba si hay capasidad de deshacer.
            If CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).UndoEnabled = True Then
                MainForm1.TSMI_Undo.Enabled = True
                MainForm1.TSB_Undo.Enabled = True
            Else
                MainForm1.TSMI_Undo.Enabled = False
                MainForm1.TSB_Undo.Enabled = False
            End If
            '
            'Comprueba si hay capasidad de deshacer.
            If CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).RedoEnabled = True Then
                MainForm1.TSMI_Redo.Enabled = True
                MainForm1.TSB_Redo.Enabled = True
            Else
                MainForm1.TSMI_Redo.Enabled = False
                MainForm1.TSB_Redo.Enabled = False
            End If
            '
            'Comprueba que halla texto seleccionado.
            If CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).SelectedText = "" Then
                MainForm1.TSMI_Cut.Enabled = False
                MainForm1.TSMI_Copy.Enabled = False
                MainForm1.TSMI_Delete.Enabled = False
                '
                MainForm1.TSB_Cut.Enabled = False
                MainForm1.TSB_Copy.Enabled = False
                '
                'ContextMenu para el editor de codigo.
                MainForm1.CMS_Cut.Enabled = False
                MainForm1.CMS_Copy.Enabled = False
                MainForm1.CMS_Delete.Enabled = False
            Else
                MainForm1.TSMI_Cut.Enabled = True
                MainForm1.TSMI_Copy.Enabled = True
                MainForm1.TSMI_Delete.Enabled = True
                '
                MainForm1.TSB_Cut.Enabled = True
                MainForm1.TSB_Copy.Enabled = True
                '
                'ContextMenu para el editor de codigo.
                MainForm1.CMS_Cut.Enabled = True
                MainForm1.CMS_Copy.Enabled = True
                MainForm1.CMS_Delete.Enabled = True
            End If

            'Comprueba si hay texto en el clipboard para poder pegarlo.
            If My.Computer.Clipboard.ContainsText = True Then
                MainForm1.TSMI_Paste.Enabled = True
                '
                'ContextMenu para el editor de codigo.
                MainForm1.CMS_Paste.Enabled = True
                '
                MainForm1.TSB_Paste.Enabled = True
            Else
                MainForm1.TSMI_Paste.Enabled = False
                '
                'ContextMenu para el editor de codigo.
                MainForm1.CMS_Paste.Enabled = False
                '
                MainForm1.TSB_Paste.Enabled = False
            End If

            'Comprueba que el zoom sea mayor quel original.
            If MainForm1.Zoom = 13 Then
                MainForm1.TSB_NormalZoom.Enabled = False
            Else
                MainForm1.TSB_NormalZoom.Enabled = True
            End If

        Else
            FindForm1.Close()
            ReplaceForm.Close()
            GoToLineForm1.Close()

            MainForm1.TSMI_Paste.Enabled = False
            'ContextMenu para el editor de codigo.
            MainForm1.CMS_Paste.Enabled = False
            MainForm1.TSB_Paste.Enabled = False
            '
            MainForm1.TSMI_Cut.Enabled = False
            MainForm1.TSMI_Copy.Enabled = False
            MainForm1.TSMI_Delete.Enabled = False
            '
            MainForm1.TSB_Cut.Enabled = False
            MainForm1.TSB_Copy.Enabled = False
            '
            'ContextMenu para el editor de codigo.
            MainForm1.CMS_Cut.Enabled = False
            MainForm1.CMS_Copy.Enabled = False
            MainForm1.CMS_Delete.Enabled = False

            'Opciones para undo y redo.
            MainForm1.TSMI_Undo.Enabled = False
            MainForm1.TSB_Undo.Enabled = False
            '
            MainForm1.TSMI_Redo.Enabled = False
            MainForm1.TSB_Redo.Enabled = False
            '
            '
            'Opciones del editor de codigo.
            MainForm1.TSMI_CloseTab.Enabled = False
            MainForm1.TSMI_CloseAllTab.Enabled = False
            MainForm1.TSMI_Save.Enabled = False
            MainForm1.TSMI_SaveAll.Enabled = False
            MainForm1.TSMI_GotoIn.Enabled = False
            MainForm1.TSMI_Find.Enabled = False
            MainForm1.TSMI_Replace.Enabled = False
            MainForm1.TSMI_SelectAll.Enabled = False
            MainForm1.TSB_Save.Enabled = False
            MainForm1.TSB_SaveAll.Enabled = False
            '
            MainForm1.TSB_Find.Enabled = False
            MainForm1.TSB_Comment.Enabled = False
            MainForm1.TSB_DesComment.Enabled = False
            MainForm1.TSB_AddBookMark.Enabled = False
            MainForm1.TSB_RemoveBookMark.Enabled = False
            MainForm1.TSB_BookMark.Enabled = False
            MainForm1.TSB_ZoomIn.Enabled = False
            MainForm1.TSB_ZoomOut.Enabled = False
            '
            'ContextMenu para el editor de codigo.
            MainForm1.CMS_GoToLine.Enabled = False
            MainForm1.CMS_Find.Enabled = False
            MainForm1.CMS_Replace.Enabled = False
            MainForm1.CMS_SelectedAll.Enabled = False

            MainForm1.TM_ControlUpdate.Stop() 'Optimiza el uso de memoria.
        End If


    End Sub

End Class
