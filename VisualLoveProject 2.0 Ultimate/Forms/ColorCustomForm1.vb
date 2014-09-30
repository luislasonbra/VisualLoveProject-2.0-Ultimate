Imports System.Drawing.Drawing2D

Public Class ColorCustomForm1

    Private Sub ColorCustomForm1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.Focus()
        Me.BringToFront()
        Me.TopMost = False

        PictureBox1.BackColor = Color.FromArgb(UserTrackBar4.Value, UserTrackBar1.Value, UserTrackBar2.Value, UserTrackBar3.Value)
        TextBox1.Text = UserTrackBar1.Value & ", " & UserTrackBar2.Value & ", " & UserTrackBar3.Value & ", " & UserTrackBar4.Value

        'Dim gp2 As GraphicsPath = New GraphicsPath
        'Dim s As Size = New Size(UserTrackBar1.ThumbSize, UserTrackBar1.Height * 9 / 10)
        'Dim r As New Rectangle(0, 0, 15, s.Height)
        'gp2.AddEllipse(r)

        'UserTrackBar1.ThumbCustomShape = gp2
    End Sub

    Private Sub UserTrackBar1_ValueChanged(sender As Object, e As System.EventArgs) Handles UserTrackBar1.ValueChanged
        PictureBox1.BackColor = Color.FromArgb(UserTrackBar4.Value, UserTrackBar1.Value, UserTrackBar2.Value, UserTrackBar3.Value)
        TextBox1.Text = UserTrackBar1.Value & ", " & UserTrackBar2.Value & ", " & UserTrackBar3.Value & ", " & UserTrackBar4.Value
    End Sub

    Private Sub UserTrackBar2_ValueChanged(sender As Object, e As System.EventArgs) Handles UserTrackBar2.ValueChanged
        PictureBox1.BackColor = Color.FromArgb(UserTrackBar4.Value, UserTrackBar1.Value, UserTrackBar2.Value, UserTrackBar3.Value)
        TextBox1.Text = UserTrackBar1.Value & ", " & UserTrackBar2.Value & ", " & UserTrackBar3.Value & ", " & UserTrackBar4.Value
    End Sub

    Private Sub UserTrackBar3_ValueChanged(sender As Object, e As System.EventArgs) Handles UserTrackBar3.ValueChanged
        PictureBox1.BackColor = Color.FromArgb(UserTrackBar4.Value, UserTrackBar1.Value, UserTrackBar2.Value, UserTrackBar3.Value)
        TextBox1.Text = UserTrackBar1.Value & ", " & UserTrackBar2.Value & ", " & UserTrackBar3.Value & ", " & UserTrackBar4.Value
    End Sub

    Private Sub UserTrackBar4_ValueChanged(sender As Object, e As System.EventArgs) Handles UserTrackBar4.ValueChanged
        PictureBox1.BackColor = Color.FromArgb(UserTrackBar4.Value, UserTrackBar1.Value, UserTrackBar2.Value, UserTrackBar3.Value)
        TextBox1.Text = UserTrackBar1.Value & ", " & UserTrackBar2.Value & ", " & UserTrackBar3.Value & ", " & UserTrackBar4.Value
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class