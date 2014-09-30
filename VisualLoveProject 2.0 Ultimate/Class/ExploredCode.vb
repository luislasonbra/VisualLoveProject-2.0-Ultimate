Imports System.IO
Imports System.Runtime.InteropServices

Public Class ExploredCode

    'Si es false no se veran los archivos ocultos.
    Public Show_Hide As Boolean = False

    '---carga el directorio y los archivos.
    '
    Public Sub PopulateTreeView()
        Dim rootNode As TreeNode
        Dim info As New DirectoryInfo(MainForm1.Path_Project)

        If info.Exists Then
            rootNode = New TreeNode(info.Name)
            rootNode.Tag = info
            rootNode.Name = info.FullName
            GetDirectories(info.GetDirectories(), rootNode)


            Dim checkFile As System.IO.DirectoryInfo
            checkFile = My.Computer.FileSystem.GetDirectoryInfo(info.FullName)
            Dim attributeReader As System.IO.FileAttributes
            attributeReader = checkFile.Attributes

            If Show_Hide = True Then

                rootNode.ImageIndex = 4
                rootNode.SelectedImageIndex = 4
                MainForm1.TV_Explored.Nodes.Add(rootNode)

            Else

                If (attributeReader And System.IO.FileAttributes.Hidden) > 0 Then
                Else

                    rootNode.ImageIndex = 4
                    rootNode.SelectedImageIndex = 4
                    MainForm1.TV_Explored.Nodes.Add(rootNode)

                End If

            End If

        End If

    End Sub
    '
    Public Sub GetDirectories(ByVal subDirs() As DirectoryInfo, ByVal nodeToAddTo As TreeNode)
        Dim aNode As TreeNode
        Dim subSubDirs() As DirectoryInfo
        Dim subDir As DirectoryInfo

        For Each subDir In subDirs
            aNode = New TreeNode(subDir.Name)
            aNode.Tag = subDir
            aNode.ImageKey = 0
            aNode.Name = subDir.FullName
            subSubDirs = subDir.GetDirectories()

            If subSubDirs.Length <> 0 Then
                GetDirectories(subSubDirs, aNode)
            End If

            Dim checkFile As System.IO.DirectoryInfo
            checkFile = My.Computer.FileSystem.GetDirectoryInfo(subDir.FullName)
            Dim attributeReader As System.IO.FileAttributes
            attributeReader = checkFile.Attributes

            If Show_Hide = True Then

                If (attributeReader And System.IO.FileAttributes.Hidden) > 0 Then
                    aNode.ImageIndex = 10
                    aNode.SelectedImageIndex = 10
                    nodeToAddTo.Nodes.Add(aNode)
                Else
                    aNode.ImageIndex = 0
                    aNode.SelectedImageIndex = 0
                    nodeToAddTo.Nodes.Add(aNode)
                End If

            Else

                If (attributeReader And System.IO.FileAttributes.Hidden) > 0 Then
                Else
                    aNode.ImageIndex = 0
                    aNode.SelectedImageIndex = 0
                    nodeToAddTo.Nodes.Add(aNode)
                End If

            End If

        Next subDir
    End Sub
    '
    Public Sub PrintRecursive(ByVal n As TreeNode)
        Try
            Dim d As New DirectoryInfo(n.Name)
            Dim aNode As TreeNode
            'Imagen para las Sub Carpetas.
            For Each aNode In n.Nodes

                Dim checkFile As System.IO.DirectoryInfo
                checkFile = My.Computer.FileSystem.GetDirectoryInfo(d.FullName)
                Dim attributeReader As System.IO.FileAttributes
                attributeReader = checkFile.Attributes

                'If Show_Hide = True Then

                '    If (attributeReader And System.IO.FileAttributes.Hidden) > 0 Then
                '        PrintRecursive(aNode)
                '    Else
                '        PrintRecursive(aNode)
                '    End If

                'Else

                '    If (attributeReader And System.IO.FileAttributes.Hidden) > 0 Then
                '    Else
                '        PrintRecursive(aNode)
                '    End If

                'End If

                PrintRecursive(aNode)
            Next

            For Each f As FileInfo In d.GetFiles
                Dim item As New TreeNode(f.Name, 18, 18) 'Poner un icono como default.
                item.Name = f.FullName

                Dim infoReader As System.IO.FileInfo
                infoReader = My.Computer.FileSystem.GetFileInfo(f.FullName)
                Dim attributeReader As System.IO.FileAttributes
                attributeReader = infoReader.Attributes

                If Show_Hide = True Then

                    If (attributeReader And System.IO.FileAttributes.Hidden) > 0 Then
                        Option_Hide(item)
                        n.Nodes.Add(item)
                    Else
                        Option_Show(item)
                        n.Nodes.Add(item)
                    End If

                Else

                    If (attributeReader And System.IO.FileAttributes.Hidden) > 0 Then
                    Else
                        Option_Show(item)
                        n.Nodes.Add(item)
                    End If

                End If

            Next
        Catch ex As Exception
        End Try
    End Sub
    '
    Public Sub CallRecursive(ByVal aTreeView As TreeView)
        Try
            Dim n As TreeNode
            For Each n In aTreeView.Nodes
                PrintRecursive(n)
            Next
        Catch ex As Exception
        End Try
    End Sub
    '
    '---------------------------------------------------------------------------------------------
    '
    'Parrametros Ocultos.
    Private Function Option_Hide(ByVal item As TreeNode)
        Dim File As New FileInfo(item.Name)

        'Imagenes para los archivos desconocidos.
        item.ImageIndex = 19
        item.SelectedImageIndex = 19

        Select Case File.Extension
            Case ".ttf"
                item.ImageIndex = 12
                item.SelectedImageIndex = 12
                'Imagenes para los sonidos.
            Case ".ogg"
                item.ImageIndex = 13
                item.SelectedImageIndex = 13
            Case ".wav"
                item.ImageIndex = 13
                item.SelectedImageIndex = 13
            Case ".mp3"
                item.ImageIndex = 13
                item.SelectedImageIndex = 13
            Case ".OGG"
                item.ImageIndex = 13
                item.SelectedImageIndex = 13
            Case ".WAV"
                item.ImageIndex = 13
                item.SelectedImageIndex = 13
            Case ".MP3"
                item.ImageIndex = 13
                item.SelectedImageIndex = 13
                'Imagenes para las imagenes
            Case ".png"
                item.ImageIndex = 15
                item.SelectedImageIndex = 15
            Case ".jpg"
                item.ImageIndex = 15
                item.SelectedImageIndex = 15
            Case ".jpeg"
                item.ImageIndex = 15
                item.SelectedImageIndex = 15
            Case ".png"
                item.ImageIndex = 15
                item.SelectedImageIndex = 15
            Case ".gif"
                item.ImageIndex = 15
                item.SelectedImageIndex = 15
            Case ".bmp"
                item.ImageIndex = 15
                item.SelectedImageIndex = 15
            Case ".PNG"
                item.ImageIndex = 15
                item.SelectedImageIndex = 15
            Case ".JPG"
                item.ImageIndex = 15
                item.SelectedImageIndex = 15
            Case ".JPEG"
                item.ImageIndex = 15
                item.SelectedImageIndex = 15
            Case ".GIF"
                item.ImageIndex = 15
                item.SelectedImageIndex = 15
            Case ".BMP"
                item.ImageIndex = 15
                item.SelectedImageIndex = 15
            Case ".ico"
                item.ImageIndex = 15
                item.SelectedImageIndex = 15
            Case ".ICO"
                item.ImageIndex = 15
                item.SelectedImageIndex = 15
                'Imagenes para los archivo lua, psd y txt.
            Case ".lua"
                item.ImageIndex = 11
                item.SelectedImageIndex = 11
            Case ".LUA"
                item.ImageIndex = 11
                item.SelectedImageIndex = 11
            Case ".txt"
                item.ImageIndex = 17
                item.SelectedImageIndex = 17
            Case ".TXT"
                item.ImageIndex = 17
                item.SelectedImageIndex = 17
            Case ".psd"
                item.ImageIndex = 21
                item.SelectedImageIndex = 21
            Case ".PSD"
                item.ImageIndex = 21
                item.SelectedImageIndex = 21
        End Select

        Return item
    End Function
    '
    'Parrametros Visibles.
    Private Function Option_Show(ByVal item As TreeNode)
        Dim File As New FileInfo(item.Name)

        'Imagenes para los archivos desconocidos.
        item.ImageIndex = 18
        item.SelectedImageIndex = 18

        Select Case File.Extension
            Case ".ttf"
                item.ImageIndex = 6
                item.SelectedImageIndex = 6
                'Imagenes para los sonidos.
            Case ".ogg"
                item.ImageIndex = 5
                item.SelectedImageIndex = 5
            Case ".wav"
                item.ImageIndex = 5
                item.SelectedImageIndex = 5
            Case ".mp3"
                item.ImageIndex = 5
                item.SelectedImageIndex = 5
            Case ".OGG"
                item.ImageIndex = 5
                item.SelectedImageIndex = 5
            Case ".WAV"
                item.ImageIndex = 5
                item.SelectedImageIndex = 5
            Case ".MP3"
                item.ImageIndex = 5
                item.SelectedImageIndex = 5
                'Imagenes para las imagenes
            Case ".png"
                item.ImageIndex = 3
                item.SelectedImageIndex = 3
            Case ".jpg"
                item.ImageIndex = 3
                item.SelectedImageIndex = 3
            Case ".jpeg"
                item.ImageIndex = 3
                item.SelectedImageIndex = 3
            Case ".png"
                item.ImageIndex = 3
                item.SelectedImageIndex = 3
            Case ".gif"
                item.ImageIndex = 3
                item.SelectedImageIndex = 3
            Case ".bmp"
                item.ImageIndex = 3
                item.SelectedImageIndex = 3
            Case ".PNG"
                item.ImageIndex = 3
                item.SelectedImageIndex = 3
            Case ".JPG"
                item.ImageIndex = 3
                item.SelectedImageIndex = 3
            Case ".JPEG"
                item.ImageIndex = 3
                item.SelectedImageIndex = 3
            Case ".GIF"
                item.ImageIndex = 3
                item.SelectedImageIndex = 3
            Case ".BMP"
                item.ImageIndex = 3
                item.SelectedImageIndex = 3
            Case ".ico"
                item.ImageIndex = 3
                item.SelectedImageIndex = 3
            Case ".ICO"
                item.ImageIndex = 3
                item.SelectedImageIndex = 3
                'Imagenes para los archivo lua, psd y txt.
            Case ".lua"
                item.ImageIndex = 1
                item.SelectedImageIndex = 1
            Case ".LUA"
                item.ImageIndex = 1
                item.SelectedImageIndex = 1
            Case ".txt"
                item.ImageIndex = 16
                item.SelectedImageIndex = 16
            Case ".TXT"
                item.ImageIndex = 16
                item.SelectedImageIndex = 16
            Case ".psd"
                item.ImageIndex = 20
                item.SelectedImageIndex = 20
            Case ".PSD"
                item.ImageIndex = 20
                item.SelectedImageIndex = 20
        End Select

        Return item
    End Function

End Class
