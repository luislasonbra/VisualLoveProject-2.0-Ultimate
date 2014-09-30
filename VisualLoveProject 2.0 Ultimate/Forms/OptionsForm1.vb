Imports FastColoredTextBoxNS

Public Class OptionsForm

    'Restaura los iconos del explorador de soluciones a su estado original.
    Private Sub DefaultTheme()
        Dim DefaultPath As String = Application.StartupPath & "\Explorer Theme"
        If My.Computer.FileSystem.DirectoryExists(DefaultPath) Then

        End If
    End Sub

    'Opcion para cargar Los proyectos recientes.
    Private Sub UpdateResentProject()
        ListBox1.Items.Clear()
        For Each item In My.Settings.My_Proyectos_Recientes
            ListBox1.Items.Add(item)
        Next

        Try
            ListBox1.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    'Opcion para eliminar el item seleccionado.
    Private Sub DeleteItemSelect()
        Try
            My.Settings.My_Proyectos_Recientes.RemoveAt(ListBox1.SelectedIndex)
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            My.Settings.Save()

            'Carga los proyectos recientes.
            MainForm1.Project_Resent(Nothing, False)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    'Opcion para eliminar todos los item o proyectos recientes.
    Private Sub DeleteItemAll()
        Try
            My.Settings.My_Proyectos_Recientes.Clear()
            ListBox1.Items.Clear()
            My.Settings.Save()

            'Carga los proyectos recientes.
            MainForm1.Project_Resent(Nothing, False)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    'Actualiza la caja de los colores.
    Private Sub UpdateColorBox()
        PictureBox1.BackColor = My.Settings.My_color_section
        PictureBox2.BackColor = My.Settings.My_color_line
        PictureBox3.BackColor = My.Settings.My_Color_Find
    End Sub

    Private Sub OptionsForm1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UpdateResentProject()
        UpdateColorBox()
    End Sub

    Private Sub BT_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Delete.Click
        Dim NameItemSelect As String = My.Computer.FileSystem.GetName(ListBox1.SelectedItem)
        Dim text1 As String = "Esta seguro que decea eliminar " & "(""" & NameItemSelect & """)" & " de los proyectos recientes."
        Dim title1 As String = "VisualLoveProject 2.0 Ultimate"
        Dim MsgStyle As MsgBoxStyle = MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo
        Dim msg = MsgBox(text1, MsgStyle, title1)

        If msg = MsgBoxResult.Yes Then
            DeleteItemSelect()
        Else
            '
        End If
    End Sub

    Private Sub BT_DeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DeleteAll.Click
        Dim text1 As String = "Esta seguro que decea eliminar todos los proyectos recientes."
        Dim title1 As String = "VisualLoveProject 2.0 Ultimate"
        Dim MsgStyle As MsgBoxStyle = MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo
        Dim msg = MsgBox(text1, MsgStyle, title1)

        If msg = MsgBoxResult.Yes Then
            DeleteItemAll()
        Else
            '
        End If
    End Sub

    'color de fondo del texto seleccionado.
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim colordialog As ColorDialog = New ColorDialog
        If colordialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Settings.My_color_section = colordialog.Color
            My.Settings.Save()

            UpdateColorBox()

            Try
                CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).SelectionColor = colordialog.Color 'Color.FromArgb(60, colordialog.Color)
            Catch ex As Exception
            End Try

        End If
    End Sub

    'fondo de la linea seleccionada.
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim colordialog As ColorDialog = New ColorDialog
        If colordialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Settings.My_color_line = colordialog.Color
            My.Settings.Save()

            UpdateColorBox()

            Try
                CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).CurrentLineColor = colordialog.Color ' Color.FromArgb(60, colordialog.Color)
            Catch ex As Exception
            End Try

        End If
    End Sub

    'resaltado de colores para buscar palabras
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim colordialog As ColorDialog = New ColorDialog

        If colordialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Settings.My_Color_Find = colordialog.Color
            My.Settings.Save()

            UpdateColorBox()

        End If
    End Sub

    Private Sub BT_Accept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Accept.Click
        'MsgBox("Nota: para que los cambios surjan efecto tienes que riniciar el programa.", vbExclamation)
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ThemeManagerForm1.ShowDialog(Me)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        DefaultTheme()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        MainForm1.SyntaxisStyle1.SetTheme = SyntaxisStyle.SyntaxisTheme.Black
        MainForm1.SyntaxisStyle1.ApplyTheme()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        MainForm1.SyntaxisStyle1.SetTheme = SyntaxisStyle.SyntaxisTheme.Default
        MainForm1.SyntaxisStyle1.ApplyTheme()
    End Sub

End Class