Option Strict Off
Option Explicit On

Public Class AddExtencion

    Public FileEjecutable As String = ""
    Public IconFile As String = ""

    'Asocia un items al contextmenu de windows.
    Public Sub AddContextMenuItems()
        Dim RootClass As String = "HKEY_CLASSES_ROOT\"
        Dim SubClass As String = RootClass & ".vlp"
        Dim SubClass2 As String = RootClass & "VisualLoveProject 2.0"

        Dim DefaultIcon As String = RootClass & "VisualLoveProject 2.0\DefaultIcon"

        Dim Shell As String = RootClass & "VisualLoveProject 2.0\shell"
        Dim SubClass5 As String = RootClass & "VisualLoveProject 2.0\shell\open"
        Dim SubClass6 As String = RootClass & "VisualLoveProject 2.0\shell\open\command"

        Dim SubClass7 As String = RootClass & "VisualLoveProject 2.0\shell\Edit File(.vlp)"
        Dim SubClass8 As String = RootClass & "VisualLoveProject 2.0\shell\Edit File(.vlp)\command"

        Dim TextItems As String = "Open with VisualLoveProject 2.0"
        Dim ItemsIcon As String = IconFile
        Dim PathExe As String = """" & FileEjecutable & """ %1"

        My.Computer.Registry.SetValue(SubClass, "", "VisualLoveProject 2.0", Microsoft.Win32.RegistryValueKind.String)
        My.Computer.Registry.SetValue(SubClass2, "", "Archivo vlp", Microsoft.Win32.RegistryValueKind.String)
        My.Computer.Registry.SetValue(DefaultIcon, "", ItemsIcon, Microsoft.Win32.RegistryValueKind.String)
        My.Computer.Registry.SetValue(Shell, "", "", Microsoft.Win32.RegistryValueKind.ExpandString)
        My.Computer.Registry.SetValue(SubClass7, "", TextItems, Microsoft.Win32.RegistryValueKind.String)
        My.Computer.Registry.SetValue(SubClass7, "Icon", ItemsIcon, Microsoft.Win32.RegistryValueKind.String)
        My.Computer.Registry.SetValue(SubClass8, "", PathExe, Microsoft.Win32.RegistryValueKind.String)

    End Sub

    'Asocia una extencion con un programa.
    Public Sub AddExtencion()
        Dim RootClass As String = "HKEY_CLASSES_ROOT\"

        Dim SubClass6 As String = RootClass & "VisualLoveProject 2.0\shell\open\command"
        Dim SubClass6_2 As String = RootClass & "VisualLoveProject 2.0\open\command"
        Dim DefaultIcon As String = RootClass & "VisualLoveProject 2.0\DefaultIcon"

        Dim ItemsIcon As String = IconFile
        Dim PathExe As String = """" & FileEjecutable & """ %1"

        My.Computer.Registry.SetValue(SubClass6, "", PathExe, Microsoft.Win32.RegistryValueKind.String)
        My.Computer.Registry.SetValue(DefaultIcon, "", ItemsIcon, Microsoft.Win32.RegistryValueKind.String)

    End Sub

    'Remueve todo lo relacionado con el registro de windows, que pueda estar utilizando esta app.
    Private Sub RemoveAllKey()
        Dim SubClass As String = ".vlp"
        Dim SubClass1 As String = "VisualLoveProject 2.0"

        Try
            My.Computer.Registry.ClassesRoot.DeleteSubKeyTree(SubClass)
            My.Computer.Registry.ClassesRoot.DeleteSubKeyTree(SubClass1)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub


End Class