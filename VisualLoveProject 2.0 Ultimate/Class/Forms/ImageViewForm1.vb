Public Class ImageViewForm1

    Private Sub ImageViewForm1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        PictureBox1.Image.Dispose()
    End Sub

    Private Sub ImageViewForm1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.Focus()
        Me.BringToFront()
        Me.TopMost = False
    End Sub

    Public Sub UpdateOption(ByVal pic As UserPictureBox)
        Dim Tamanox As Integer = pic.Image.Width
        Dim Tamanoy As Integer = pic.Image.Height

        ToolStripStatusLabel2.Text = Tamanox & " x " & Tamanoy
        Me.Focus()
    End Sub

End Class