Public Class Help_Function

    'Function para recortar las rutas de acceso e algunos casos.
    Public Function PathRecort(ByVal Path As String)
        Dim NameFileLen As String = Len(My.Computer.FileSystem.GetName(Path))
        Dim pathFull As String = Mid(Path, 1, Len(Path) - NameFileLen)

        Return pathFull
    End Function

End Class
