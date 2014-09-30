Imports System.Drawing.Drawing2D
Imports FastColoredTextBoxNS

Public Class bookmarkCode

    Public Property CurrentTB() As FastColoredTextBox
        Get
            Dim result As FastColoredTextBox
            If MainForm1.TC_Editor.SelectedTab Is Nothing Then
                result = Nothing
            Else
                result = TryCast(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
            End If
            Return result
        End Get
        Set(ByVal value As FastColoredTextBox)
            MainForm1.TC_Editor.SelectedTab = TryCast(value.Parent, TabPage)
            value.Focus()
        End Set
    End Property

    Public lastNavigatedDateTime As DateTime = DateTime.Now
    ' Key - Line.UniqueId
    Public bookmarksLineId As New Dictionary(Of Integer, Integer)()
    ' Index - bookmark number, Value - Line.UniqueId
    Public bookmarks As New List(Of Integer)()

    Public Class BookmarkInfo
        Public iBookmark As Integer

        Public FastColorTexBox As FastColoredTextBox
    End Class

    'Public bookmarkSize As Integer = 15
    'Public Sub FastColoredTextBox1_PaintLine(ByVal sender As Object, ByVal e As FastColoredTextBoxNS.PaintLineEventArgs)

    '    Dim Fctb1 = TryCast(sender, FastColoredTextBox)
    '    Dim info As TbInfo = Fctb1.Tag
    '    If info.bookmarksLineId.Contains(Fctb1(e.LineIndex).UniqueId) Then
    '        'Si el valor del bookmarksize es menor o igual a 0 se ejecuta esta function.
    '        If bookmarkSize = 0 Then
    '            bookmarkSize = 5
    '        End If
    '        e.Graphics.FillEllipse(New LinearGradientBrush(New Rectangle(0, e.LineRect.Top, bookmarkSize, bookmarkSize), Color.AliceBlue, Color.DarkBlue, 45.0F), 0, e.LineRect.Top, bookmarkSize, bookmarkSize)
    '        e.Graphics.DrawEllipse(Pens.PowderBlue, 0, e.LineRect.Top, bookmarkSize, bookmarkSize)
    '    End If


    '    'Original code ============================================================================
    '    'Dim info As TbInfo = TryCast(TryCast(sender, FastColoredTextBox).Tag, TbInfo)
    '    'If info.bookmarksLineId.Contains(TryCast(sender, FastColoredTextBox)(e.LineIndex).UniqueId) Then
    '    '    e.Graphics.FillEllipse(New LinearGradientBrush(New Rectangle(0, e.LineRect.Top, 15, 15), Color.AliceBlue, Color.DarkBlue, 45.0F), 0, e.LineRect.Top, 15, 15)
    '    '    e.Graphics.DrawEllipse(Pens.PowderBlue, 0, e.LineRect.Top, 15, 15)
    '    'End If
    '    'Original code ============================================================================


    '    'Dim fctb = TryCast(sender, FastColoredTextBox)
    '    'Dim text = fctb.Lines(e.LineIndex)

    '    'If text.Trim() = "end" Then
    '    '    e.Graphics.DrawLine(Pens.Silver, e.LineRect.Left, e.LineRect.Bottom, e.LineRect.Right, e.LineRect.Bottom)
    '    'End If
    'End Sub

    Public Sub LineRemoved(ByVal sender As Object, ByVal e As LineRemovedEventArgs)
        Dim info As TbInfo = TryCast(TryCast(sender, FastColoredTextBox).Tag, TbInfo)
        For Each id As Integer In e.RemovedLineUniqueIds
            If info.bookmarksLineId.Contains(id) Then
                info.bookmarksLineId.Remove(id)
                info.bookmarks.Remove(id)
            End If
        Next
    End Sub

    Public Sub [GoTo](ByVal bookmark As bookmarkCode.BookmarkInfo)
        Dim info As TbInfo = TryCast(bookmark.FastColorTexBox.Tag, TbInfo)
        Try
            Me.CurrentTB = bookmark.FastColorTexBox
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return
        End Try
        If bookmark.iBookmark >= 0 AndAlso bookmark.iBookmark < info.bookmarks.Count Then
            Dim id As Integer = info.bookmarks(bookmark.iBookmark)
            For i As Integer = 0 To Me.CurrentTB.LinesCount - 1
                If Me.CurrentTB(i).UniqueId = id Then
                    Me.CurrentTB.Selection.Start = New Place(0, i)
                    Me.CurrentTB.DoSelectionVisible()
                    Me.CurrentTB.Invalidate()
                    Exit For
                End If
            Next
        End If
    End Sub

End Class

