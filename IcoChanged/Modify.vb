Imports System.IO

Public Class Modify

    Public Sub New()
        If My.Computer.FileSystem.DirectoryExists("C:\Windows\Temp\ResHacker") Then
        Else
            My.Computer.FileSystem.CreateDirectory("C:\Windows\Temp\ResHacker")
            File.WriteAllBytes("C:\Windows\Temp\ResHacker\comctlRH.dll", My.Resources.comctlRH)
            File.WriteAllBytes("C:\Windows\Temp\ResHacker\ResHacker.exe", My.Resources.ResHacker)
        End If
    End Sub

    Public Sub Modify(ByVal PathExe As String, ByVal IcoFile As String, ByVal SaveNewExe As String)
        Dim Path_ResHacker As String = "C:\Windows\Temp\ResHacker\ResHacker.exe"
        Dim Argument As String = " -modify " & PathExe & ", " & SaveNewExe & ", " & IcoFile & ", IconGroup, 1, 0"

        Try
            Dim pObj As New Process()
            pObj.StartInfo.RedirectStandardOutput = True
            pObj.StartInfo.FileName = Path_ResHacker
            pObj.StartInfo.Arguments = Argument
            pObj.StartInfo.UseShellExecute = False
            pObj.StartInfo.CreateNoWindow = True
            pObj.Start()

            Dim outStr As String = pObj.StandardOutput.ReadToEnd()

            pObj.WaitForExit()

        Catch ex As Exception

        End Try

    End Sub

End Class
