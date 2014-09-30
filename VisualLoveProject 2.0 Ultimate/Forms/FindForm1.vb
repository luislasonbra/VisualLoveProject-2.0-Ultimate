Imports System.Text.RegularExpressions
Imports FastColoredTextBoxNS

Public Class FindForm1

    Private firstSearch As Boolean = True
    Private startPlace As Place

    Public Sub FindNext(ByVal pattern As String, ByVal tb As FastColoredTextBox)
        Dim tbOnline = CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
        Try
            Dim opt As RegexOptions = If(CB_MathCase.Checked, RegexOptions.None, RegexOptions.IgnoreCase)
            If Not CB_Regex.Checked Then
                pattern = Regex.Escape(pattern)
            End If
            '
            If CB_WholeWord.Checked Then
                pattern = "\b" & pattern & "\b"
            End If
            '
            Dim range As Range = tb.Selection.Clone()
            range.Normalize()
            '
            If firstSearch Then

                startPlace = range.Start
                firstSearch = False

            End If
            '
            range.Start = range.[End]
            If range.Start >= startPlace Then
                range.[End] = New Place(tb.GetLineLength(tb.LinesCount - 1), tb.LinesCount - 1)
            Else
                range.[End] = startPlace
            End If
            '
            For Each r In range.GetRangesByLines(pattern, opt)
                tb.Selection = r
                tb.DoSelectionVisible()
                tb.Invalidate()
                Return
            Next
            '
            'ResetSerach()
            firstSearch = True
            '
            If range.Start >= startPlace AndAlso startPlace > Place.Empty Then
                tb.Selection.Start = New Place(0, 0)
                FindNext(pattern, tbOnline)
                Return
            End If
            '
            MessageBox.Show("Not found")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BT_FintNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_FintNext.Click
        Dim tbOnline = CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
        FindNext(TB_Find.Text, tbOnline)
    End Sub

    Private Sub TB_Find_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_Find.KeyPress
        If e.KeyChar = ControlChars.Cr Then
            BT_FintNext.PerformClick()
            e.Handled = True
            Return
        End If
        If e.KeyChar = ChrW(27) Then
            Hide()
            MainForm1.Focus()
            e.Handled = True
            Return
        End If
    End Sub

    Private Sub FindForm1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Opacity = 100
        TB_Find.Focus()
        ResetSerach()
    End Sub

    Private Sub FindForm1_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Opacity = 0.8
    End Sub

    Private Sub FindForm1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            MainForm1.Focus()
            Hide()
        End If
    End Sub

    Private Sub ResetSerach()
        firstSearch = True
    End Sub

    Private Sub CB_MathCase_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CB_MathCase.CheckedChanged
        ResetSerach()
    End Sub

    Private Sub BT_Cloce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Cloce.Click
        Me.Close()
    End Sub

    Private Sub FindForm1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        TB_Find.Focus()
        ResetSerach()
    End Sub

    Private Sub FindForm1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.Focus()
        Me.BringToFront()
        Me.TopMost = False
    End Sub

    Private Sub EfectoFade(ByVal Enable As Boolean)
        If Enable = True Then
            For i = 0.0 To 0.5 Step 0.1
                Me.Opacity = i
                If i = 0.5 Then
                    Exit For
                End If
            Next
        Else
            Me.Opacity = 100
        End If
    End Sub

End Class