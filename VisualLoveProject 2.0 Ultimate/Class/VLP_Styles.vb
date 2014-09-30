Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.IO
Imports FastColoredTextBoxNS

Public Class VLP_Styles

    'Declaramos la function para usar los cursores.
    Private Declare Unicode Function LoadCursorFromFile Lib "user32.dll" Alias "LoadCursorFromFileW" (ByVal filename As String) As IntPtr

    'Carga las funciones del Explorador de soluciones.
    Private UploadingFilesAndFolder As New ExploredCode

    'Estilo nativo de windows.
    <DllImport("uxtheme.dll", CharSet:=CharSet.Unicode)> _
    Public Shared Function SetWindowTheme(ByVal hWnd As IntPtr, ByVal pszSubAppName As String, ByVal pszSubIdList As String) As Integer
    End Function

    'Dim Iconfile As String = Application.StartupPath & "\kaycur1.ico"
    Dim curfile As String = Application.StartupPath & "\Cursors\aero_arrow.cur"
    'Dim Anifile As String = Application.StartupPath & "\RedClockWiseCursor.ani"
    Public Sub animatedCur(ByVal Form As Object)
        If File.Exists(curfile) = True Then
            Dim hcur As IntPtr
            hcur = LoadCursorFromFile(curfile)
            Form.Cursor = New Cursor(hcur)
        Else
            Form.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    'DragAndDrop para los nodos del explorador de soluciones.
#Region "Explored DragAndDrop"

    Public Sub TV_Explored_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs)
        'Comprueva si el click izquierdo del mause se a presionado seleccionar el nodo.
        If e.Button = Windows.Forms.MouseButtons.Right Then
            MainForm1.TV_Explored.SelectedNode = e.Node
        End If
    End Sub

    Public Sub TV_Explored_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs)
        'Mueve el nodo arrastrado cuando el botón izquierdo del ratón.
        If e.Button = MouseButtons.Left Then

            MainForm1.TV_Explored.DoDragDrop(e.Item, DragDropEffects.Move)

            'Copia el nodo arrastrado al pulsar el botón derecho del ratón.

            'ElseIf e.Button = MouseButtons.Right Then
            '    Form1.TV_Explored.DoDragDrop(e.Item, DragDropEffects.Copy)
        End If
    End Sub

    Public Sub TV_Explored_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        'Recuperar las coordenadas de la posición del ratón.
        Dim targetPoint As Point = MainForm1.TV_Explored.PointToClient(New Point(e.X, e.Y))

        'Seleccione el nodo en la posición del ratón.
        MainForm1.TV_Explored.SelectedNode = MainForm1.TV_Explored.GetNodeAt(targetPoint)

    End Sub

    Public Sub TV_Explored_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        Try
            'Recuperar las coordenadas de cliente de la ubicación de destino.
            Dim targetPoint As Point = MainForm1.TV_Explored.PointToClient(New Point(e.X, e.Y))
            'Recuperar el nodo en la ubicación de destino.
            Dim targetNode As TreeNode = MainForm1.TV_Explored.GetNodeAt(targetPoint)
            'Recuperar el nodo que fue arrastrado.
            Dim draggedNode As TreeNode = CType(e.Data.GetData(GetType(TreeNode)), TreeNode)
            'Confirmar que el nodo en la ubicación de destino no es el nodo arrastrado o un descendiente del nodo arrastrado.
            If Not draggedNode.Equals(targetNode) AndAlso Not ContainsNode(draggedNode, targetNode) Then
                ' Si se trata de una operación de mover, eliminar el nodo de su ubicación actual
                ' y añadirlo al nodo en la ubicación de destino.
                If e.Effect = DragDropEffects.Move Then

                    Try
                        'Reparar si da problemas.
                        Dim NameMove As String = My.Computer.FileSystem.GetName(draggedNode.Name)
                        '------------------Divide carpeta y archivos--------------------------------------------------------------------
                        'Comprueba que si el nodo arastrado es un archivo .lua borre las pestañas.
                        If InStr(draggedNode.Name, ".lua") Then

                            draggedNode.Remove()
                            targetNode.Nodes.Add(draggedNode)

                            If InStr(draggedNode.Name, ".") Then
                                My.Computer.FileSystem.MoveFile(draggedNode.Name, targetNode.Name & "\" & NameMove)
                            Else
                                My.Computer.FileSystem.MoveDirectory(draggedNode.Name, targetNode.Name & "\" & NameMove)
                            End If

                            'Este codigo se encarga de guardar los archivos movidos.
                            Dim i As Integer = 0
                            Dim llave As Boolean = False

                            For i = 0 To MainForm1.TC_Editor.TabPages.Count - 1
                                If MainForm1.TC_Editor.TabPages(i).Name = draggedNode.Name Then
                                    llave = False

                                    Exit For
                                Else
                                    llave = True
                                End If
                            Next

                            If llave = False Then

                                If MainForm1.TC_Editor.TabPages(i).ImageIndex = 7 Then
                                    Dim title As String = "VisualLoveProject 2.0 Ultimate"
                                    Dim text As String = "¿Desea guardar los cambios?"
                                    Dim msgStyle As MsgBoxStyle = MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation
                                    Dim ms = MsgBox(text, msgStyle)

                                    If ms = MsgBoxResult.Yes Then 'Accion para el botton yes
                                        Dim FastColorTextBox As FastColoredTextBox = CType(MainForm1.TC_Editor.TabPages(i).Controls.Item(0), FastColoredTextBox)
                                        Dim oSW As New StreamWriter(targetNode.Name & "\" & NameMove)
                                        Dim Linea As String = FastColorTextBox.Text
                                        oSW.WriteLine(Linea)
                                        'oSW.Flush()
                                        oSW.Close()

                                        'MainForm.TC_Editor.TabPages.Remove(MainForm.TC_Editor.TabPages(i))
                                        MainForm1.TC_Editor.TabPages(i).Name = targetNode.Name & "\" & NameMove
                                        MainForm1.TC_Editor.TabPages(i).Text = My.Computer.FileSystem.GetName(targetNode.Name & "\" & NameMove)
                                        MainForm1.TC_Editor.TabPages(i).ImageIndex = 1

                                        FastColorTextBox.ClearUndo()
                                        FastColorTextBox.GoHome()
                                        FastColorTextBox.IsChanged = False


                                    ElseIf ms = MsgBoxResult.No Then 'Accion para el botton no
                                        Dim FastColorTextBox As FastColoredTextBox = CType(MainForm1.TC_Editor.TabPages(i).Controls.Item(0), FastColoredTextBox)
                                        Dim oSW2 As New StreamReader(targetNode.Name & "\" & NameMove)

                                        MainForm1.TC_Editor.TabPages(i).Name = targetNode.Name & "\" & NameMove
                                        MainForm1.TC_Editor.TabPages(i).Text = My.Computer.FileSystem.GetName(targetNode.Name & "\" & NameMove)

                                        FastColorTextBox.Text = oSW2.ReadToEnd
                                        FastColorTextBox.ClearUndo()
                                        FastColorTextBox.GoHome()
                                        FastColorTextBox.IsChanged = False

                                        MainForm1.TC_Editor.TabPages(i).ImageIndex = 1

                                        oSW2.Close()
                                        oSW2.Dispose()
                                        'MainForm.TC_Editor.TabPages.Remove(MainForm.TC_Editor.TabPages(i))

                                        FastColorTextBox.ClearUndo()
                                        FastColorTextBox.GoHome()
                                        FastColorTextBox.IsChanged = False

                                    End If

                                Else

                                    'MainForm.TC_Editor.TabPages.Remove(MainForm.TC_Editor.TabPages(i))
                                    MainForm1.TC_Editor.TabPages(i).Name = targetNode.Name & "\" & NameMove
                                    MainForm1.TC_Editor.TabPages(i).Text = My.Computer.FileSystem.GetName(targetNode.Name & "\" & NameMove)

                                End If

                            Else
                                'MsgBox("El Archivo no esta abierto.")
                            End If 'Cierre de la function de borrado.

                        Else

                            draggedNode.Remove()
                            targetNode.Nodes.Add(draggedNode)

                            If InStr(draggedNode.Name, ".") Then
                                My.Computer.FileSystem.MoveFile(draggedNode.Name, targetNode.Name & "\" & NameMove)
                            Else
                                My.Computer.FileSystem.MoveDirectory(draggedNode.Name, targetNode.Name & "\" & NameMove)
                            End If

                            'CloseTab(MainForm.TC_Editor)

                            Dim title As String = "VisualLoveProject 2.0 Ultimate"
                            Dim text As String = "¿Desea guardar los cambios?"
                            Dim msgStyle As MsgBoxStyle = MsgBoxStyle.YesNo Or MsgBoxStyle.Information
                            Dim msgResultYes As MsgBoxResult = MsgBoxResult.Yes

                            For Each tp In MainForm1.TC_Editor.TabPages
                                If tp.ImageIndex = 7 Then
                                    MainForm1.TC_Editor.SelectedTab = tp
                                    Dim ms = MsgBox(text, msgStyle)

                                    Dim nameFile As String = MainForm1.TC_Editor.SelectedTab.Text

                                    If ms = MsgBoxResult.Yes Then

                                        Dim FastColorTextBox As FastColoredTextBox = CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
                                        Dim oSW As New StreamWriter(targetNode.Name & "\" & NameMove & "\" & nameFile)
                                        Dim Linea As String = FastColorTextBox.Text
                                        oSW.WriteLine(Linea)
                                        'oSW.Flush()
                                        oSW.Close()

                                        MainForm1.TC_Editor.SelectedTab.Name = targetNode.Name & "\" & NameMove & "\" & nameFile
                                        MainForm1.TC_Editor.SelectedTab.Text = My.Computer.FileSystem.GetName(targetNode.Name & "\" & NameMove & "\" & nameFile)
                                        MainForm1.TC_Editor.SelectedTab.ImageIndex = 1

                                        FastColorTextBox.ClearUndo()
                                        FastColorTextBox.GoHome()
                                        FastColorTextBox.IsChanged = False

                                        'MainForm.TC_Editor.Controls.Remove(tp)
                                    ElseIf ms = MsgBoxResult.No Then

                                        Dim FastColorTextBox As FastColoredTextBox = CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
                                        Dim oSW2 As New StreamReader(targetNode.Name & "\" & NameMove & "\" & nameFile)

                                        MainForm1.TC_Editor.SelectedTab.Name = targetNode.Name & "\" & NameMove & "\" & nameFile
                                        MainForm1.TC_Editor.SelectedTab.Text = My.Computer.FileSystem.GetName(targetNode.Name & "\" & NameMove & "\" & nameFile)

                                        FastColorTextBox.Text = oSW2.ReadToEnd
                                        FastColorTextBox.ClearUndo()
                                        FastColorTextBox.GoHome()
                                        FastColorTextBox.IsChanged = False

                                        MainForm1.TC_Editor.SelectedTab.ImageIndex = 1

                                        oSW2.Close()
                                        oSW2.Dispose()


                                        FastColorTextBox.ClearUndo()
                                        FastColorTextBox.GoHome()
                                        FastColorTextBox.IsChanged = False

                                    End If

                                End If
                            Next

                            For Each tp In MainForm1.TC_Editor.TabPages
                                Dim nameFile1 As String = My.Computer.FileSystem.GetName(tp.name)
                                If tp.ImageIndex = 1 Then

                                    If InStr(tp.name, NameMove) Then
                                        tp.Name = targetNode.Name & "\" & NameMove & "\" & nameFile1
                                        tp.Text = My.Computer.FileSystem.GetName(targetNode.Name & "\" & NameMove & "\" & nameFile1)
                                        tp.ImageIndex = 1
                                    End If

                                End If
                            Next

                        End If

                    Catch ex As Exception
                        'MsgBox("Accion no permitida.", vbCritical)
                        'MsgBox("El archivo que decea mover ya se encuentra en esta ubicacion.", vbCritical)
                    End Try
                    '  Si se trata de una operación de copia, clonar el nodo arrastrado
                    'y añadirlo al nodo en la ubicación de destino.
                ElseIf e.Effect = DragDropEffects.Copy Then
                    targetNode.Nodes.Add(CType(draggedNode.Clone(), TreeNode))
                End If
            End If
            ' Expandir el nodo en la ubicación
            'para mostrar el nodo caído.

            Try
                targetNode.Expand()
            Catch ex As Exception
            End Try

            'Actualiza el estado de los nodos.
            MainForm1.UpdateProject_Sub()
        Catch ex As Exception
            'MsgBox("Accion no permitida.", vbCritical)
            ' Accion no permitida.
        End Try
    End Sub

    'Function para cerrar todas las pestañas
    Public Sub CloseTab(ByVal TabControl As TabControl) 'Function para cerrar todas las pestañas
        Dim title As String = "VisualLoveProject 2.0 Ultimate"
        Dim text As String = "No a guardado los cambios desea guardarlos."
        Dim msgStyle As MsgBoxStyle = MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Information
        Dim msgResultYes As MsgBoxResult = MsgBoxResult.Yes

        For Each tp In TabControl.TabPages
            If tp.ImageIndex = 1 Then
                TabControl.SelectedTab = tp
                Dim ms = MsgBox(text, msgStyle)

                If ms = MsgBoxResult.Yes Then
                    TabControl.Controls.Remove(tp)
                ElseIf ms = MsgBoxResult.No Then
                    TabControl.Controls.Remove(tp)
                ElseIf ms = MsgBoxResult.Cancel Then
                    Exit Sub
                End If

            End If
        Next

        For Each tp In TabControl.TabPages
            If tp.ImageIndex = 0 Then
                TabControl.Controls.Remove(tp)
            End If
        Next

    End Sub

    Public Function ContainsNode(ByVal node1 As TreeNode, ByVal node2 As TreeNode) As Boolean
        Try
            'Compruebe el nodo principal del segundo nodo.
            If node2.Parent Is Nothing Then
                Return False
            End If
        Catch ex As Exception
            Return True
        End Try

        If node2.Parent.Equals(node1) Then
            Return True
        End If

        ' Si el nodo padre no es nulo o igual que el primer nodo,
        'llamar al método ContainsNode recursiva utilizando la matriz de
        'el segundo nodo.
        Return ContainsNode(node1, node2.Parent)

    End Function 'ContainsNode

    Public Sub TV_Explored_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        e.Effect = e.AllowedEffect
    End Sub

#End Region

    'DragAndDrop para las pestañas del editor de codigo.
#Region "Pestañas DragAndDrop"

    Private DragStartPosition As Point = Point.Empty

    Public Sub TC_Editor_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs)
        MainForm1.TC_Editor.AllowDrop = True
    End Sub

    Public Sub TC_Editor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        DragStartPosition = New Point(e.X, e.Y)
    End Sub

    Public Sub TC_Editor_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button <> MouseButtons.Left Then Return
        Dim r As Rectangle = New Rectangle(DragStartPosition, Size.Empty)
        r.Inflate(SystemInformation.DragSize)
        Dim tp As TabPage = HoverTab()
        If Not tp Is Nothing Then
            If Not r.Contains(e.X, e.Y) Then
                MainForm1.TC_Editor.DoDragDrop(tp, DragDropEffects.All)
            End If
        End If
        DragStartPosition = Point.Empty
    End Sub

    Public Sub TC_Editor_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        Dim hover_Tab As TabPage = HoverTab()
        If hover_Tab Is Nothing Then
            e.Effect = DragDropEffects.None
        Else
            If e.Data.GetDataPresent(GetType(TabPage)) Then
                e.Effect = DragDropEffects.Move
                Dim drag_tab As TabPage = DirectCast(e.Data.GetData(GetType(TabPage)), TabPage)
                If hover_Tab Is drag_tab Then Return
                Dim TabRect As Rectangle = MainForm1.TC_Editor.GetTabRect(MainForm1.TC_Editor.TabPages.IndexOf(hover_Tab))
                TabRect.Inflate(-3, -3)
                If TabRect.Contains(MainForm1.TC_Editor.PointToClient(New Point(e.X, e.Y))) Then
                    SwapTabPages(drag_tab, hover_Tab)
                    MainForm1.TC_Editor.SelectedTab = drag_tab
                End If
            End If
        End If
    End Sub

    Private Function HoverTab() As TabPage
        For index As Int32 = 0 To MainForm1.TC_Editor.TabCount - 1
            If MainForm1.TC_Editor.GetTabRect(index).Contains(MainForm1.TC_Editor.PointToClient(Cursor.Position)) Then
                Return MainForm1.TC_Editor.TabPages(index)
            End If
        Next
    End Function

    Private Sub SwapTabPages(ByVal tp1 As TabPage, ByVal tp2 As TabPage)
        Try
            Dim Index1 As Integer = MainForm1.TC_Editor.TabPages.IndexOf(tp1)
            Dim Index2 As Integer = MainForm1.TC_Editor.TabPages.IndexOf(tp2)
            MainForm1.TC_Editor.TabPages(Index1) = tp2
            MainForm1.TC_Editor.TabPages(Index2) = tp1
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

#End Region

    'Comprueba si el mouse esta encima de una pestaña y la selecciona. 
    Public Function GetTabPageSelected(ByVal pt As Point, ByVal TabControl As TabControl) As TabPage
        Dim tp As TabPage = Nothing
        For i As Integer = 0 To TabControl.TabPages.Count - 1
            If TabControl.GetTabRect(i).Contains(pt) Then
                tp = TabControl.TabPages(i)
                Exit For
            End If
        Next
        Return tp
    End Function

End Class
