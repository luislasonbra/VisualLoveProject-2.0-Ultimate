Public Class LanguajeManajerForm1

    Private LangManager As LanguajeManager
    Private Path As String = ""

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        LangManager = New LanguajeManager(Path)
        LangManager.Load()

        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Path = OpenFileDialog1.FileName
        End If
    End Sub

End Class