Imports FastColoredTextBoxNS

Public Class GoToLineForm1

    Private Sub GoToLineForm1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        TM_ControlTextLine.Stop()
    End Sub

    Private Sub GoToLine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TM_ControlTextLine.Start()

        Dim tbOnline = CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)

        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.Focus()
        Me.BringToFront()
        Me.TopMost = False

        Me.LB_Text.Text = [String].Format("Numero de linea " & "(1 - {0}):", tbOnline.LinesCount)
        Me.TB_LineNumber.Text = tbOnline.Selection.Start.iLine + 1

    End Sub

    Private Sub BT_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Ok.Click
        Dim tbOnline = CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)

        Dim lineas_recortadas As Integer = TB_LineNumber.Text - 1
        tbOnline.Navigate(lineas_recortadas)
        Me.Close()
    End Sub

    Private Sub BT_Cloce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Cloce.Click
        Me.Close()
    End Sub

    Private Sub GoToLine_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Opacity = 100
    End Sub

    Private Sub GoToLine_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Opacity = 0.8
    End Sub

    Private Sub TM_ControlTextLine_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TM_ControlTextLine.Tick
        Try
            Dim tbOnline = CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
            'Me.TB_LineNumber.Text = tbOnline.Selection.Start.iLine + 1
            Me.LB_Text.Text = [String].Format("Numero de linea " & "(1 - {0}):", tbOnline.LinesCount)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TB_LineNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_LineNumber.KeyPress
        'Solo numero en el textbox. 
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        'Solo letras en el textbox. 
        'If Char.IsLetter(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsSeparator(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If

    End Sub

End Class