Public Class UpdateProject

    Private ProgressValue As Integer = 0
    Private UpdateProject1 As New UpdateProjectClass

    Private Sub SaveOptionUpdate()

        Dim NameProject As String = UpdateProject1.RemoveExtencion(My.Computer.FileSystem.GetName(MainForm1.Path_Project))
        UpdateProject1.NameProject = NameProject
        UpdateProject1.LoveVersion = "0.8.0"
        UpdateProject1.AppVersion = "1.0"
        UpdateProject1.NameAuthor = "VisualLoveProject"
        UpdateProject1.NameCompany = "Dark"
        UpdateProject1.PathIcon = UpdateProject1.CopyIconFile(NameProject, True)
        UpdateProject1.TimerCreate = My.Computer.Clock.LocalTime.ToString

        MainForm1.LoveVersionProject = "0.8.0"
        MainForm1.IconCompiler = UpdateProject1.CopyIconFile(NameProject, False)

        UpdateProject1.SaveLoveSetting()

    End Sub

    Private Sub UpdateProject_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Try
            PB_State.Value = ProgressValue
            ProgressValue = ProgressValue + 1
            If ProgressValue >= 99 Then

                SaveOptionUpdate()

                Timer1.Enabled = False
                PB_State.Value = 0
                ProgressValue = 0
                Me.Close()
            End If
        Catch ex As Exception
            Timer1.Stop()
            Me.Close()
        End Try

    End Sub

End Class