Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.Collections.Generic
Imports FastColoredTextBoxNS

Public Class ReplaceForm

    Private firstSearch As Boolean = True
    Private startPlace As Place

    Private Sub BT_FindNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_FindNext.Click
        Try
            If Not Find(TB_Find.Text) Then
                MsgBox("asd", vbExclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Function para buscar todas las palabras.
    Public Function FindAll(ByVal pattern As String) As List(Of Range)
        Dim tbOnline = CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)

        Dim opt As RegexOptions = If(CB_MathCase.Checked, RegexOptions.None, RegexOptions.IgnoreCase)
        If Not CB_Regex.Checked Then
            pattern = Regex.Escape(pattern)
        End If

        If CB_WholeWord.Checked Then
            pattern = "\b" & pattern & "\b"
        End If
        '
        Dim range As Range = tbOnline.Selection.Clone()
        range.Normalize()
        range.Start = range.[End]
        range.[End] = New Place(tbOnline.GetLineLength(tbOnline.LinesCount - 1), tbOnline.LinesCount - 1)
        '
        Dim list As New List(Of Range)()
        For Each r In range.GetRangesByLines(pattern, opt)
            list.Add(r)
        Next

        Return list
    End Function

    'Function para buscar una palabra en especifico.
    Public Function Find(ByVal pattern As String) As Boolean
        Dim tbOnline = CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)

        Dim opt As RegexOptions = If(CB_MathCase.Checked, RegexOptions.None, RegexOptions.IgnoreCase)
        If Not CB_Regex.Checked Then
            pattern = Regex.Escape(pattern)
        End If

        If CB_WholeWord.Checked Then
            pattern = "\b" & pattern & "\b"
        End If
        '
        Dim range As Range = tbOnline.Selection.Clone()
        range.Normalize()
        '
        If firstSearch Then
            startPlace = range.Start
            firstSearch = False
        End If
        '
        range.Start = range.[End]
        If range.Start >= startPlace Then
            range.[End] = New Place(tbOnline.GetLineLength(tbOnline.LinesCount - 1), tbOnline.LinesCount - 1)
        Else
            range.[End] = startPlace
        End If
        '
        For Each r In range.GetRangesByLines(pattern, opt)
            tbOnline.Selection.Start = r.Start
            tbOnline.Selection.[End] = r.[End]
            tbOnline.DoSelectionVisible()
            tbOnline.Invalidate()
            Return True
        Next

        ResetSerach()

        If range.Start >= startPlace AndAlso startPlace > Place.Empty Then
            tbOnline.Selection.Start = New Place(0, 0)
            Return Find(pattern)
        End If
        Return False
    End Function

    Private Sub TB_Find_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_Find.KeyPress
        If e.KeyChar = ControlChars.Cr Then
            BT_FindNext_Click(sender, Nothing)
        End If
        If e.KeyChar = ChrW(27) Then
            Hide()
            MainForm1.Focus()
        End If
    End Sub

    Private Sub ReplaceForm1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Opacity = 100
        TB_Find.Focus()
        ResetSerach()
    End Sub

    Private Sub ReplaceForm1_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Opacity = 0.8
    End Sub

    Private Sub ReplaceForm1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            MainForm1.Focus()
            Hide()
        End If
    End Sub

    Private Sub ReplaceForm1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        TB_Find.Focus()
        ResetSerach()
    End Sub

    Private Sub BT_Replace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Replace.Click
        Dim tbOnline = CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
        Try
            If tbOnline.SelectionLength <> 0 Then
                tbOnline.InsertText(TB_Replace.Text)
            End If
            'BT_FindNext_Click(sender, Nothing)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BT_ReplaceAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ReplaceAll.Click
        Dim tbOnline = CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)

        Try
            tbOnline.Selection.BeginUpdate()
            tbOnline.Selection.Start = New Place(0, 0)
            'search
            Dim ranges = FindAll(TB_Find.Text)
            'replace
            If ranges.Count > 0 Then

                tbOnline.TextSource.Replace(tbOnline, ranges, TB_Replace.Text)

                tbOnline.Selection.Start = New Place(0, 0)

            End If
            '
            tbOnline.Invalidate()
            MessageBox.Show(ranges.Count & " occurrence(s) was replaced.")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        tbOnline.Selection.EndUpdate()
    End Sub

    Private Sub ResetSerach()
        firstSearch = True
    End Sub

    Private Sub CB_MathCase_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_MathCase.CheckedChanged
        ResetSerach()
    End Sub

    Private Sub ReplaceForm1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.Focus()
        Me.BringToFront()
        Me.TopMost = False
    End Sub

    Private Sub BT_Cloce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Cloce.Click
        Me.Close()
    End Sub
End Class