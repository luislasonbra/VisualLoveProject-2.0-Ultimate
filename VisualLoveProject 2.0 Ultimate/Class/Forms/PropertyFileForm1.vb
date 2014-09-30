Imports System.IO

Public Class PropertyFileForm
    Public FilePath As String = ""

    'Renombra el archivo.
    Private Sub RenameFile(ByVal Path As String)
        Dim info As New FileInfo(Path)
        Dim saveExtension As String = info.Extension

        Try
            If TextBox1.Text = "" Then
            Else
                My.Computer.FileSystem.RenameFile(Path, TextBox1.Text)
                MainForm1.UpdateProject()
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Abre el formulario con las propiedades del archivo cargado.
    Public Sub PropertyFile(ByVal Path As String)
        ListView1.Items.Clear()

        Dim info As New FileInfo(Path)

        Dim checkFile As System.IO.FileInfo
        checkFile = My.Computer.FileSystem.GetFileInfo(info.FullName)

        'Extraemos los atributos del archivo.
        Dim attributeReader As System.IO.FileAttributes
        attributeReader = checkFile.Attributes

        'Extraemos el icono del archivo.
        Dim IconFile As Icon = Icon.ExtractAssociatedIcon(Path)
        PictureBox1.Image = IconFile.ToBitmap

        'Colocamos el nombre del archivo en el textbox1.
        TextBox1.Text = info.Name

        '=======================Para agregar el tamaño y otras cosas mas.==========================================
        ListView1.Items.Add(info.Extension)

        If (info.Length / 1024) > 1024 Then
            ListView1.Items(0).SubItems.Add(Math.Round(((info.Length / 1024) / 1024), 2).ToString() & " Mb")
        Else
            ListView1.Items(0).SubItems.Add(Math.Round((info.Length / 1024), 2).ToString() & " Kb")
        End If

        ListView1.Items(0).SubItems.Add(info.Directory.FullName)
        '==========================================================================================================

        'Estado de los checkbox
        CheckBox1.Checked = checkFile.IsReadOnly
        If (attributeReader And System.IO.FileAttributes.Hidden) > 0 Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RenameFile(FilePath)
        Me.Close()
    End Sub

    Private Sub PropertyFileForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        FilePath = ""
    End Sub

    Private Sub PropertyFileForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PropertyFile(FilePath)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.Click
        Dim info As New FileInfo(FilePath)

        Dim checkFile As System.IO.FileInfo
        checkFile = My.Computer.FileSystem.GetFileInfo(info.FullName)

        'Extraemos los atributos del archivo.
        Dim attributeReader As System.IO.FileAttributes
        attributeReader = checkFile.Attributes

        'Estado de los checkbox
        checkFile.IsReadOnly = CheckBox1.Checked

        MainForm1.UpdateProject()
    End Sub

    Private Sub CheckBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.Click
        Dim info As New FileInfo(FilePath)

        Dim checkFile As System.IO.FileInfo
        checkFile = My.Computer.FileSystem.GetFileInfo(info.FullName)

        'Extraemos los atributos del archivo.
        Dim attributeReader As System.IO.FileAttributes
        attributeReader = checkFile.Attributes

        'Estado de los checkbox
        If checkFile.Attributes = FileAttributes.Hidden Then
            checkFile.Attributes = FileAttributes.Normal
        Else
            checkFile.Attributes = FileAttributes.Hidden
        End If

        MainForm1.UpdateProject()
    End Sub


End Class