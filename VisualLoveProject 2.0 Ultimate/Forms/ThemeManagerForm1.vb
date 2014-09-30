
Public Class ThemeManagerForm1

    Private PathFilePak As String = ""

    Private PakIcoFile As New PakIcoFile
    Private Sub OpenFilePak(ByVal Path As String)

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "Tipe File Pak|*.pak"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PathFilePak = OpenFileDialog1.FileName
            PakIcoFile.ListItemsFiles(ListView1, OpenFileDialog1.FileName, ImageList1)
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            PakIcoFile.ListItemsFiles(OptionsForm.ListView2, PathFilePak, OptionsForm.ImageList2)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Try
            MainForm1.IL_Explored.Images.Clear()
            For i = 0 To ImageList1.Images.Count - 1
                MainForm1.IL_Explored.Images.Add(ImageList1.Images(i))
            Next
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub

End Class