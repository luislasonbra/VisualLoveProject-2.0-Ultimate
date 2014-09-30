Imports FastColoredTextBoxNS
Imports System.IO
Imports System.Text
Imports Ionic.Zip
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports VisualLoveProject_2._0_Ultimate.AutoCompletad

Public Class MainForm1

    'Function para controlar el estado del projecto al cerrarlo.
    Public ControllerStateProject1 As New ControllerStateProject
    Private Help_Function1 As New Help_Function
    Private UpdateProject1 As New UpdateProjectClass
    Private BookMarkCode As New bookmarkCode
    Public resaltado As New SintaxisEditor
    Public SyntaxisStyle1 As New SyntaxisStyle

    'Public AutoCompletado As New AutoCompletad

    Private UploadingFilesAndFolder As New ExploredCode
    Private VLP_Styles As New VLP_Styles
    Private UpdateControlStatus As New UpdateControlStatus
    Private IsDefaultTheme As Boolean = False

    Public Path_Project As String = ""
    Dim KeyCut As Boolean = False
    Dim PathCopy As String = ""
    Dim OuputConsole As String
    Dim proc As New Process
    Dim Key_OptionCompiler As Boolean = False

    Private TimerProsses As Integer = 0
    Public Key_Run As Boolean = False
    Private AutoSaveTime As Integer = 1
    Private AutoSaveTimeStep As Integer = 5000 'Cada 1 segundo se activa esta function.
    Public AutoSaveKey As Boolean = True

    Public Zoom As Integer = 13

    Public IconCompiler As String = ""
    Public LoveVersionProject As String = ""

    'Carga las personalizaciones de los menues y los context menu.
    Class MyToolStripRenderer 'Carga el tema
        Inherits ToolStripProfessionalRenderer
        Public Sub New()
            MyBase.New(New VisualStudio2010())
        End Sub
    End Class

    Private Sub SetDefaultTheme()
        TS_Tool.BackColor = Color.FromKnownColor(KnownColor.Control)
        MS_Menu.BackgroundImage = Nothing
        MS_Menu.BackColor = Color.FromKnownColor(KnownColor.Control)
        GB_Explored.BackColor = Color.FromKnownColor(KnownColor.Control)
        TS_Explored.BackColor = Color.FromKnownColor(KnownColor.Control)
        TSS_Path.BackColor = Color.FromKnownColor(KnownColor.Control)
        Me.BackColor = Color.FromKnownColor(KnownColor.Control)
        Console1.Panel1.BackColor = Color.FromKnownColor(KnownColor.Control)

        GB_Explored.ForeColor = Color.Black
        TS_Explored.ForeColor = Color.Black

        TSSL_Text.ForeColor = Color.Black
        TSSL_Path.ForeColor = Color.Black

        Console1.Label1.ForeColor = Color.Black

        Console1.C_Text.ForeColor = Color.Black
        Console1.C_Text.BackColor = Color.White

        Console1.TabPage1.BackColor = Color.FromKnownColor(KnownColor.Control)

        'TC_Editor.clrColorBackground = Color.FromKnownColor(KnownColor.Control)
        'TC_Editor.clrTabBackgroundColor = New SolidBrush(Color.FromKnownColor(KnownColor.Control))
    End Sub

    'Carga las funciones necesarias.
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Carga el estado del formulario.
        StateLoadMainForm()

        '========================================
        GB_Explored.Visible = False
        Console1.Visible = False
        '========================================

        'Carga los cursores.
        'VLP_Styles.animatedCur(Me)
        'VLP_Styles.animatedCur(TV_Explored)
        'VLP_Styles.animatedCur(CMS_ExploredMenu)

        'Carga los eventos de los controles.
        Event_TV_Explored()
        Event_TC_Editor()

        IsDefaultTheme = False

        'Activa el arrastrado del explorador de soluciones.
        TV_Explored.AllowDrop = True
        TC_Editor.AllowDrop = True

        'Activa las personalisaciones del explorador de soluciones.
        VLP_Styles.SetWindowTheme(TV_Explored.Handle, "explorer", Nothing)

        If IsDefaultTheme = True Then
            SetDefaultTheme()
        Else
            'Aplica las personalizasiones.
            TS_Tool.Renderer = New MyToolStripRenderer
            TS_Explored.Renderer = New MyToolStripRenderer
            MS_Menu.Renderer = New MyToolStripRenderer
            CM_Edit.Renderer = New MyToolStripRenderer
            CMS_ExploredMenu.Renderer = New MyToolStripRenderer
            CMS_TabMenu.Renderer = New MyToolStripRenderer
        End If

        'Carga los proyectos recientes.
        Project_Resent(Nothing, False)

        'Abre el programa con un archivo que halla sido arasrado hacia el.
        If Microsoft.VisualBasic.Interaction.Command() = "" Then
        Else
            OpenCommand()
        End If

    End Sub

    'Abre el programa con un archivo que halla sido arasrado hacia el.
    Private Sub OpenCommand()
        Dim rutaVLP As String = Microsoft.VisualBasic.Interaction.Command()
        Dim PathVLPClear As String = rutaVLP.Replace("""", "")

        ResetProjectClear()
        ResetProjectClearAll()
        Path_Project = PathVLPClear
        TSSL_Path.Text = PathVLPClear

        UploadingFilesAndFolder.PopulateTreeView()
        UploadingFilesAndFolder.CallRecursive(TV_Explored)

        Me.Text = My.Computer.FileSystem.GetName(PathVLPClear) & " - VisualLoveProject 2.0 Ultimate"

        Try
            Open_Project(PathVLPClear, True)
        Catch ex As Exception
        End Try

    End Sub

    'Crea nuevas pestañas para poder editarlas con el editor de codigo.
    Public Sub AddTabPage(ByVal Path As String)

        If InStr(Path, ".lua") Then
            LuaFileAdd(Path)
        ElseIf InStr(Path, ".txt") Then
            NormalFileAdd(Path)
        End If

    End Sub

    ' Function para agregar un tabpage con las functiones de lua y su sintaxis.
    Private Sub LuaFileAdd(ByVal Path As String)
        TC_Editor.ShowToolTips = True
        Dim TabPageFast As New TabPage

        TabPageFast.ImageIndex = 1
        TabPageFast.Text = My.Computer.FileSystem.GetName(Path)
        TabPageFast.ToolTipText = Path

        Dim FastColorTextBox As FastColoredTextBox = New FastColoredTextBox()
        FastColorTextBox.Dock = DockStyle.Fill
        FastColorTextBox.LeftPadding = 22

        'FastColorTextBox.LineInterval = 2

        FastColorTextBox.Language = Language.Custom
        FastColorTextBox.ContextMenuStrip = CM_Edit 'Esta function no se usa.
        FastColorTextBox.Tag = New TbInfo
        FastColorTextBox.ShowFoldingLines = True

        FastColorTextBox.ChangedLineColor = resaltado.ControlChangedLineColor ' Color = Amarillo.
        FastColorTextBox.ChangedLineColor2 = resaltado.ControlChangedLineColor2 ' Color = Verde.

        FastColorTextBox.CurrentLineColor = resaltado.ControlCurrentLineColor ' Color = Amarillo Claro.
        FastColorTextBox.SelectionColor = resaltado.ControlSelectionColor ' Color = Azul Cielo.
        FastColorTextBox.BackColor = resaltado.ControlBackColor
        FastColorTextBox.ForeColor = resaltado.ControlForeColor
        FastColorTextBox.IndentBackColor = resaltado.ControlIndentBackColor
        FastColorTextBox.LineNumberColor = resaltado.ControlLineNumberColor
        FastColorTextBox.ServiceLinesColor = resaltado.ControlServiceLinesColor
        FastColorTextBox.CurrentBoockMarkColor = resaltado.ControlCurrentBoockMarkColor

        FastColorTextBox.BracketsStyle = New MarkerStyle(New SolidBrush(Color.FromArgb(120, Color.Red)))
        FastColorTextBox.BracketsStyle2 = New MarkerStyle(New SolidBrush(Color.FromArgb(120, Color.Green)))

        FastColorTextBox.CaretColor = resaltado.ControlCaretColor
        FastColorTextBox.SelectionColorLostFocus = resaltado.ControlSelectionColorLostFocus

        'FastColorTextBox.FindEndOfFoldingBlockStrategy = FindEndOfFoldingBlockStrategy.Strategy2
        'FastColorTexBox.ServiceLinesColor = Color.FromArgb(100, Color.Black)

        FastColorTextBox.IsChanged = False
        FastColorTextBox.IsChanged2 = False
        FastColorTextBox.AddStyle(New MarkerStyle(New SolidBrush(resaltado.ControlMyColorFind)))
        FastColorTextBox.Font = New Font("Consolas", 9.7F, FontStyle.Bold) ', GraphicsUnit.World)

        'Normaliza el tamaño del bookmark.
        'BookMarkCode.bookmarkSize = New Size(15, 15)

        TabPageFast.Name = Path
        '--------Eventos.
        AddHandler FastColorTextBox.TextChanged, AddressOf resaltado.LuaSyntaxHighlight
        AddHandler FastColorTextBox.VisibleRangeChanged, AddressOf resaltado.VisibleRangeChanged
        AddHandler FastColorTextBox.KeyPressed, AddressOf resaltado.ChangeSaved

        AddHandler FastColorTextBox.MouseClick, AddressOf resaltado.FastColoredTextBox1_MouseClick
        AddHandler FastColorTextBox.MouseDoubleClick, AddressOf resaltado.FastColoredTextBox1_MouseDoubleClick

        AddHandler FastColorTextBox.LineRemoved, New EventHandler(Of LineRemovedEventArgs)(AddressOf BookMarkCode.LineRemoved)

        'Noce utiliza esta linea.
        'AddHandler FastColorTextBox.PaintLine, New EventHandler(Of PaintLineEventArgs)(AddressOf BookMarkCode.FastColoredTextBox1_PaintLine)

        AddHandler FastColorTextBox.SelectionChangedDelayed, New EventHandler(AddressOf resaltado.SelectionChangedDelayed)

        'Eventos para aumentar y disminuir el tamaño del fascoloredtextbox.
        AddHandler FastColorTextBox.ZoomChanged, New EventHandler(AddressOf resaltado.FastColoredTextBox1_ZoomChanged)
        AddHandler FastColorTextBox.PaintLine, New EventHandler(Of PaintLineEventArgs)(AddressOf resaltado.FastColoredTextBox1_PaintLine)

        '--------Cierre de los eventos

        TabPageFast.Controls.Add(FastColorTextBox)
        TC_Editor.TabPages.Add(TabPageFast)
        TC_Editor.SelectedIndex = TC_Editor.TabPages.Count - 1

        Try

            Dim oSW As New StreamReader(Path)

            FastColorTextBox.Text = oSW.ReadToEnd()
            FastColorTextBox.ClearUndo()
            FastColorTextBox.GoHome()
            FastColorTextBox.IsChanged = False
            FastColorTextBox.IsChanged2 = False
            TC_Editor.SelectedTab.ImageIndex = 1

            oSW.Close()
            oSW.Dispose()

            LoadConfigFileFolder()

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        'No borra ha menos que sepas lo que haces.

        ' Codigo para cargar el popuMenu(Dinamic and more) y asignarlos a las pestañas.
        Dim AutoCompletado1 As AutoCompletad = New AutoCompletad
        Dim popupMenu As AutocompleteMenu = New AutocompleteMenu(FastColorTextBox)
        AddHandler popupMenu.Opening, New EventHandler(Of CancelEventArgs)(AddressOf AutoCompletado1.popupMenu_Opening)

        popupMenu.Items.SetAutocompleteItems2(New DynamicCollection(FastColorTextBox, popupMenu))

        TryCast(FastColorTextBox.Tag, TbInfo).popupMenu = popupMenu
        TryCast(FastColorTextBox, FastColoredTextBox).Tag = New TbInfo
    End Sub

    ' Function para agregar un tabpage con las functiones de un archivo normal.
    Private Sub NormalFileAdd(ByVal Path As String)
        TC_Editor.ShowToolTips = True
        Dim TabPageFast As New TabPage

        TabPageFast.ImageIndex = 1
        TabPageFast.Text = My.Computer.FileSystem.GetName(Path)
        TabPageFast.ToolTipText = Path

        Dim FastColorTextBox As FastColoredTextBox = New FastColoredTextBox()
        FastColorTextBox.Dock = DockStyle.Fill
        FastColorTextBox.LeftPadding = 22
        '
        FastColorTextBox.Language = Language.Custom
        FastColorTextBox.ContextMenuStrip = CM_Edit 'Esta function no se usa.
        FastColorTextBox.Tag = New TbInfo
        FastColorTextBox.ShowFoldingLines = False
        FastColorTextBox.ShowLineNumbers = False

        FastColorTextBox.ChangedLineColor = resaltado.ControlChangedLineColor ' Color = Amarillo.
        FastColorTextBox.ChangedLineColor2 = resaltado.ControlChangedLineColor2 ' Color = Verde.

        FastColorTextBox.CurrentLineColor = resaltado.ControlCurrentLineColor ' Color = Amarillo Claro.
        FastColorTextBox.SelectionColor = resaltado.ControlSelectionColor ' Color = Azul Cielo.
        FastColorTextBox.BackColor = resaltado.ControlBackColor
        FastColorTextBox.ForeColor = resaltado.ControlForeColor
        FastColorTextBox.IndentBackColor = resaltado.ControlIndentBackColor
        FastColorTextBox.LineNumberColor = resaltado.ControlLineNumberColor
        FastColorTextBox.ServiceLinesColor = resaltado.ControlServiceLinesColor
        FastColorTextBox.CurrentBoockMarkColor = resaltado.ControlCurrentBoockMarkColor

        FastColorTextBox.BracketsStyle = New MarkerStyle(New SolidBrush(Color.FromArgb(120, Color.Red)))
        FastColorTextBox.BracketsStyle2 = New MarkerStyle(New SolidBrush(Color.FromArgb(120, Color.Green)))

        FastColorTextBox.CaretColor = resaltado.ControlCaretColor
        '
        FastColorTextBox.IsChanged = False
        FastColorTextBox.IsChanged2 = False
        FastColorTextBox.AddStyle(New MarkerStyle(New SolidBrush(resaltado.ControlMyColorFind)))
        FastColorTextBox.Font = New Font("Consolas", 9.7F, FontStyle.Bold) ', GraphicsUnit.World)

        TabPageFast.Name = Path
        '
        ' --------Eventos.
        AddHandler FastColorTextBox.TextChanged, AddressOf resaltado.NormalTextValueChanged
        ' --------Cierre de los Eventos.
        '
        TabPageFast.Controls.Add(FastColorTextBox)
        TC_Editor.TabPages.Add(TabPageFast)
        TC_Editor.SelectedIndex = TC_Editor.TabPages.Count - 1

        Try
            Dim oSW As New StreamReader(Path)

            FastColorTextBox.Text = oSW.ReadToEnd()
            FastColorTextBox.ClearUndo()
            FastColorTextBox.GoHome()
            FastColorTextBox.IsChanged = False
            FastColorTextBox.IsChanged2 = False
            TC_Editor.SelectedTab.ImageIndex = 2

            oSW.Close()
            oSW.Dispose()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    '******************************************No eliminar************************************************************
    'Crea un opening menu customizado.
    Public Sub popupMenu_Opening(ByVal sender As Object, ByVal e As CancelEventArgs)
        Dim bookmark As bookmarkCode = New bookmarkCode
        Dim iGreenStyle As Integer = bookmark.CurrentTB.GetStyleIndex(bookmark.CurrentTB.SyntaxHighlighter.GreenStyle)

        If iGreenStyle <= 0 AndAlso bookmark.CurrentTB.Selection.Start.iChar > 0 Then
            Dim c As FastColoredTextBoxNS.Char = bookmark.CurrentTB(bookmark.CurrentTB.Selection.Start.iLine)(bookmark.CurrentTB.Selection.Start.iChar - 1)
            Dim greenStyleIndex As StyleIndex = Range.ToStyleIndex(iGreenStyle)
            If c.style = greenStyleIndex <> 0 Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    '******************************************************************************************************************

    'Este codigo lo que hace es llamar al codigo de arriba pero sin repetir las pestañas.
    Public Sub AddTabPageNotRepeat(ByVal Path As String)

        Dim i As Integer = 0
        Dim llave As Boolean = False

        For i = 0 To TC_Editor.TabPages.Count - 1
            If TC_Editor.TabPages(i).Name = Path Then
                llave = False
                TC_Editor.SelectedTab = TC_Editor.TabPages(i)
                Exit For
            Else
                llave = True
            End If
        Next

        If llave = False Then
            'MsgBox("El Archivo lla esta abierto.")
        Else
            AddTabPage(Path)
        End If 'Cierre de la function de borrado.

    End Sub

    'Abre los archivos vlp.
    Public Sub Open_Project(ByVal PathProject As String, Optional CommandOpen As Boolean = False)
        If ClosedProjectActual(TC_Editor) = "Cancelar" Then
            '
        Else
            Path_Project = PathProject
            Try
                If UpdateProject1.ReadVlpFunction(PathProject) = True Then
                    IconCompiler = UpdateProject1.ReadIconPath(PathProject)
                    LoveVersionProject = UpdateProject1.ReadLoveVersion(PathProject)
                Else
                    Dim Text_Msg As String = "Este proyecto fue creado con una version anterior, decea actualizar para poder abrirlo."
                    Dim Title_Msg As String = "VisualLoveProject 2.0 Ultimate"
                    Dim Msg_Style As MsgBoxStyle = MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo
                    Dim Msg = MsgBox(Text_Msg, Msg_Style, Title_Msg)

                    If Msg = MsgBoxResult.Yes Then

                        ResetProjectClear()
                        ResetProjectClearAll()

                        Path_Project = PathProject

                        UpdateProject.ShowDialog(Me)
                    Else
                        If CommandOpen = True Then 'Function Temporal.
                            TSSL_Path.Text = "?" '==========================
                            Me.Text = "VisualLoveProject 2.0 Ultimate" '===========
                            Me.Close() '==================================
                        End If '=================================

                        Exit Sub
                    End If
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try

            TM_ControlUpdate.Start() 'Optimiza el uso de memoria.
            Dim cantidad As Integer
            Dim nombre As String
            '-----------------------------------------------------------
            'CerrarProyecto()
            TV_Explored.Nodes.Clear()
            Path_Project = ""

            ResetProjectClear() 'CIerra el proyecto actual.
            ResetProjectClearAll()

            cantidad = Len(PathProject)
            nombre = Mid(PathProject, 1, cantidad - 4)
            Path_Project = nombre

            TSSL_Path.Text = PathProject
            UploadingFilesAndFolder.PopulateTreeView()
            UploadingFilesAndFolder.CallRecursive(TV_Explored)
            'TV_Explored.ExpandAll()
            TV_Explored.Nodes(0).Expand()

            Me.Text = My.Computer.FileSystem.GetName(PathProject) & " - VisualLoveProject 2.0 Ultimate"

            TC_Editor.TabPages.Clear()
            TC_Editor.Visible = True

            '========================================
            GB_Explored.Visible = True
            Console1.Visible = True
            '========================================

            'Guarda los proyectos recientes.
            Project_Resent(PathProject, True)

            'Carga los proyectos recientes.
            Project_Resent(Nothing, False)

            Try
                TV_Explored.SelectedNode = TV_Explored.Nodes(0)
                'CargaVlp()
            Catch ex As Exception
            End Try

            Dim nameFile As String = My.Computer.FileSystem.GetName(PathProject)
            Dim t1 As String = Mid(PathProject, 1, Len(PathProject) - Len(nameFile))
            Dim pathNew As String = t1 & "SettingsProjects"

            If My.Computer.FileSystem.DirectoryExists(pathNew) = True Then
                Try
                    ControllerStateProject1.OpenStateProject(pathNew & "\StateTabPage.cf")
                Catch ex As Exception
                End Try
            Else
                My.Computer.FileSystem.CreateDirectory(pathNew)
                Try
                    ControllerStateProject1.OpenStateProject(pathNew & "\StateTabPage.cf")
                Catch ex As Exception
                End Try
            End If

        End If

    End Sub

    'Actualiza el proyecto.
    Public Sub UpdateProject_Sub()
        'TC_Editor.TabPages.Clear()
        TV_Explored.Nodes.Clear()
        UploadingFilesAndFolder.PopulateTreeView()
        UploadingFilesAndFolder.CallRecursive(TV_Explored)
        'TV_Explored.ExpandAll()
        TV_Explored.Nodes(0).Expand()
    End Sub

    'Eventos del explorador de soluciones.
    Private Sub Event_TV_Explored()

        AddHandler TV_Explored.NodeMouseClick, AddressOf VLP_Styles.TV_Explored_NodeMouseClick

        AddHandler TV_Explored.ItemDrag, AddressOf VLP_Styles.TV_Explored_ItemDrag

        AddHandler TV_Explored.DragOver, AddressOf VLP_Styles.TV_Explored_DragOver

        AddHandler TV_Explored.DragDrop, AddressOf VLP_Styles.TV_Explored_DragDrop

        AddHandler TV_Explored.DragEnter, AddressOf VLP_Styles.TV_Explored_DragEnter

    End Sub

    'Eventos de las pestañas del editor.
    Private Sub Event_TC_Editor()

        AddHandler TC_Editor.HandleCreated, AddressOf VLP_Styles.TC_Editor_HandleCreated

        AddHandler TC_Editor.MouseDown, AddressOf VLP_Styles.TC_Editor_MouseDown

        AddHandler TC_Editor.MouseMove, AddressOf VLP_Styles.TC_Editor_MouseMove

        AddHandler TC_Editor.DragOver, AddressOf VLP_Styles.TC_Editor_DragOver

    End Sub

    'Se encarga de cargar y guardar los proyectos abiertos recientemene.
    Public Sub Project_Resent(ByVal NameProject As String, ByVal Save As Boolean)

        TSMI_RecentProject.DropDownItems.Clear()

        'Guarda los proyectos recientes.
        If Save = True Then

            If My.Settings.My_Proyectos_Recientes.Count <= 0 Then
                My.Settings.My_Proyectos_Recientes.Add(NameProject)
                My.Settings.Save()
            Else
                Dim i As Integer = 0
                Dim llave As Boolean = False
                For i = 0 To My.Settings.My_Proyectos_Recientes.Count - 1
                    If My.Settings.My_Proyectos_Recientes(i) = NameProject Then
                        llave = False
                        Exit For
                    Else
                        llave = True
                    End If
                Next
                If llave = False Then
                    'MsgBox("El nombre lla existe")
                Else
                    My.Settings.My_Proyectos_Recientes.Add(NameProject)
                    My.Settings.Save()
                End If
            End If

            'Carga los proyectos recientes.
        ElseIf Save = False Then

            Dim itemNumber As Integer = 1
            For Each item In My.Settings.My_Proyectos_Recientes
                Dim ItemDrop As New ToolStripMenuItem
                ItemDrop.Text = itemNumber & " " & item
                ItemDrop.Name = item
                ItemDrop.AutoSize = True

                'ItemDrop.ImageIndex = 0
                ItemDrop.Image = IL_Explored.Images(23)

                AddHandler ItemDrop.Click, AddressOf DropDownItems_Click
                itemNumber = itemNumber + 1
                TSMI_RecentProject.DropDownItems.Add(ItemDrop)
            Next

        End If

    End Sub

    'Evento click para los ToolStripItem creados dinamicamente.
    Private Sub DropDownItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ItemSelecteName As ToolStripItem = sender

        Dim title As String = "VisualLoveProject 2.0 Ultimate"
        Dim text As String = "¿El archivo no existe, desea eliminarlo de los proyectos recientes?"
        Dim style As MsgBoxStyle = MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo

        If My.Computer.FileSystem.FileExists(ItemSelecteName.Name) Then
            Open_Project(ItemSelecteName.Name)
        Else

            Dim msg = MsgBox(text, style, title)
            If msg = MsgBoxResult.Yes Then

                Try
                    Dim i As Integer
                    For i = 0 To My.Settings.My_Proyectos_Recientes.Count - 1
                        If My.Settings.My_Proyectos_Recientes(i) = ItemSelecteName.Name Then
                            My.Settings.My_Proyectos_Recientes.RemoveAt(i)
                        End If
                        My.Settings.Save()
                    Next
                Catch ex As Exception
                End Try

                'Carga los proyectos recientes.
                Project_Resent(Nothing, False)
            End If

        End If

    End Sub

    'Abre los archivos vlp del proyecto.
    Private Sub TSMI_OpenProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_OpenProject.Click
        Dim openFile As New OpenFileDialog
        openFile.Title = ""
        openFile.FileName = Nothing
        openFile.Filter = "vlp file|*.vlp*"
        '------------------------------------------------------------
        If openFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            Open_Project(openFile.FileName)
        End If
    End Sub

    'Edita la image con programa en espesifico o por default en paint.
    Private Sub EditImage(ByVal Path As String)
        Dim Process As New Process
        Try
            'System.Diagnostics.Process.Start(TreeView1.SelectedNode.Name)
            'If OpcionesDeImagenEdit.llave_editor = False Then
            Dim exepath As String = "mspaint.exe"
            Dim startinfo As New System.Diagnostics.ProcessStartInfo
            '--------Edita con paint---------------------------------------------------
            Dim cmd As String = Path
            ' all parameters required to run the process
            startinfo.FileName = """" & exepath & """"
            startinfo.Arguments = """" & cmd & """"
            startinfo.UseShellExecute = False
            startinfo.WindowStyle = ProcessWindowStyle.Hidden
            startinfo.RedirectStandardError = True
            startinfo.RedirectStandardOutput = True
            startinfo.CreateNoWindow = True
            Process.StartInfo = startinfo
            Process.Start() ' inicia el proceso.
            'Process.WaitForExit() 'Espera aque la imagen terminada.

            Try

                Dim BytesFile = File.ReadAllBytes(Path)
                Dim ms As New MemoryStream(BytesFile)

                ImageViewForm1.PictureBox1.Image = New Bitmap(ms)

            Catch ex As Exception
            End Try

            'Else
            'Dim exepath As String = OpcionesDeImagenEdit.ruta_editor_exe
            'Dim startinfo As New System.Diagnostics.ProcessStartInfo
            ''----------Edita con-------------------------------------------------
            'Dim cmd As String = Path
            '' all parameters required to run the process
            'startinfo.FileName = """" & exepath & """"
            'startinfo.Arguments = """" & cmd & """"
            'startinfo.UseShellExecute = False
            'startinfo.WindowStyle = ProcessWindowStyle.Hidden
            'startinfo.RedirectStandardError = True
            'startinfo.RedirectStandardOutput = True
            'startinfo.CreateNoWindow = True
            'proc.StartInfo = startinfo
            'proc.Start() ' inicia el proceso.
            'End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    'Muestra las imagenes en un visor de imagenes incorporado en la aplicacion.
    Private Sub ViewImage(ByVal ImagePath As String)
        Dim FileExtencion As New FileInfo(ImagePath)
        '
        If InStr(FileExtencion.Extension, ".png") OrElse _
           InStr(FileExtencion.Extension, ".PNG") OrElse _
           InStr(FileExtencion.Extension, ".jpg") OrElse _
           InStr(FileExtencion.Extension, ".JPG") OrElse _
           InStr(FileExtencion.Extension, ".jpeg") OrElse _
           InStr(FileExtencion.Extension, ".JPEG") OrElse _
           InStr(FileExtencion.Extension, ".bmp") OrElse _
           InStr(FileExtencion.Extension, ".BMP") OrElse _
           InStr(FileExtencion.Extension, ".ico") OrElse _
           InStr(FileExtencion.Extension, ".ICO") OrElse _
           InStr(FileExtencion.Extension, ".gif") OrElse _
           InStr(FileExtencion.Extension, ".GIF") Then
            '
            Dim BytesFile = File.ReadAllBytes(ImagePath)
            Dim ms As New MemoryStream(BytesFile)
            '
            ImageViewForm1.PictureBox1.Image = New Bitmap(ms)
            ImageViewForm1.UpdateOption(ImageViewForm1.PictureBox1)
            ImageViewForm1.Show(Me)
            '
        End If

    End Sub

    'Comprueba si el archivo seleccionado es visible o no visible.
    Private Function CheckVisibility(ByVal e As System.Windows.Forms.TreeViewEventArgs)

        Dim checkFile As System.IO.DirectoryInfo
        checkFile = My.Computer.FileSystem.GetDirectoryInfo(e.Node.Name)
        Dim attributeReader As System.IO.FileAttributes
        attributeReader = checkFile.Attributes

        If (attributeReader And System.IO.FileAttributes.Hidden) > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    'Controla las funciones al abrir nuevos archivos.
    Private Sub TV_Explored_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TV_Explored.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then

            Try
                ViewImage(TV_Explored.SelectedNode.Name)
                If TC_Editor.TabPages.Count <= 0 Then
                    AddTabPage(TV_Explored.SelectedNode.Name)
                    TM_ControlUpdate.Start() 'Optimiza el uso de memoria.
                Else
                    AddTabPageNotRepeat(TV_Explored.SelectedNode.Name)
                    TM_ControlUpdate.Start() 'Optimiza el uso de memoria.
                End If
            Catch ex As Exception
            End Try

        End If
    End Sub

    'Se prduce despues de aberse contraido el nodo seleccionado.
    Private Sub TV_Explored_AfterCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TV_Explored.AfterCollapse
        TV_Explored.Nodes(0).SelectedImageIndex = 4
        TV_Explored.Nodes(0).ImageIndex = 4

        If CheckVisibility(e) = False Then
            e.Node.SelectedImageIndex = 0
            e.Node.ImageIndex = 0
        Else
            e.Node.SelectedImageIndex = 10
            e.Node.ImageIndex = 10
        End If

        TV_Explored.Nodes(0).SelectedImageIndex = 4
        TV_Explored.Nodes(0).ImageIndex = 4
    End Sub

    'Se produce antes de aberse expandido del nodo seleccionado.
    Private Sub TV_Explored_AfterExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TV_Explored.AfterExpand

        TV_Explored.Nodes(0).SelectedImageIndex = 4
        TV_Explored.Nodes(0).ImageIndex = 4

        If CheckVisibility(e) = False Then
            e.Node.SelectedImageIndex = 8
            e.Node.ImageIndex = 8
        Else
            e.Node.SelectedImageIndex = 14
            e.Node.ImageIndex = 14
        End If

        TV_Explored.Nodes(0).SelectedImageIndex = 4
        TV_Explored.Nodes(0).ImageIndex = 4
    End Sub

    'Se produce cuando el mouse se situa encima de un nodo.
    Private Sub TV_Explored_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TV_Explored.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.TV_Explored.SelectedNode = Me.TV_Explored.GetNodeAt(e.X, e.Y)
            If TV_Explored.Nodes.Count = 0 Then
                TV_Explored.ContextMenuStrip = Nothing
            Else
                TV_Explored.ContextMenuStrip = CMS_ExploredMenu
            End If

            '--------------------------------------------------------
            Dim p As Point = Cursor.Position
            p = TV_Explored.PointToClient(p)
            Dim tmpnode As TreeNode = TV_Explored.HitTest(p).Node
            If tmpnode Is Nothing Then
                TV_Explored.ContextMenuStrip = Nothing
            Else
                If tmpnode.Bounds.Contains(p) Then
                    TV_Explored.ContextMenuStrip = CMS_ExploredMenu
                Else
                    TV_Explored.ContextMenuStrip = Nothing
                End If
            End If
        End If
        '--------------------------------------------------------
    End Sub

    'Retorna la extencion de la imagen seleccionado.
    Private Function Extencion(ByVal PathFile As String)
        Dim ExtensionFile As New FileInfo(PathFile)

        Select Case ExtensionFile.Extension
            Case ".png"
                Return ".png"
            Case ".jpg"
                Return ".jpg"
            Case ".jpeg"
                Return ".jpeg"
            Case ".ico"
                Return ".ico"
            Case ".gif"
                Return ".gif"
            Case ".bmp"
                Return ".bmp"
            Case ".PNG"
                Return ".PNG"
            Case ".JPG"
                Return ".JPG"
            Case ".JPEG"
                Return ".JPEG"
            Case ".GIF"
                Return ".GIF"
            Case ".BMP"
                Return ".BMP"
            Case ".ICO"
                Return ".ICO"
        End Select

        Return False

    End Function

    'Se produce cuando se selecciona un nodo.
    Private Sub TV_Explored_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TV_Explored.AfterSelect
        Dim ExtensionFile As New FileInfo(e.Node.Name)

        If ExtensionFile.Attributes = FileAttributes.Directory Then
            TSMI_New.Visible = True
            TSMI_ImportsResoucer.Visible = True

            TSMI_ViewExplored_Tv_Eplored.Visible = True

            If PathCopy = "" Then
                TSMI_Paste_Tv_Explored.Enabled = False
            Else
                TSMI_Paste_Tv_Explored.Enabled = True
            End If

            ToolStripMenuItem10.Visible = True
            ToolStripMenuItem13.Visible = True
        Else
            TSMI_New.Visible = False
            TSMI_ImportsResoucer.Visible = False

            TSMI_Paste_Tv_Explored.Enabled = False
            TSMI_ViewExplored_Tv_Eplored.Visible = False

            ToolStripMenuItem10.Visible = False
            ToolStripMenuItem13.Visible = False
        End If

        '---------------------No Modific--------------------------------------
        If InStr(e.Node.Name, Extencion(e.Node.Name)) Then
            TSMI_EditImage.Visible = True
        ElseIf Extencion(e.Node.Name) = False Then
            TSMI_EditImage.Visible = False
        End If
        '
        If TV_Explored.Nodes(0).IsSelected = True Then
            TSMI_Delete_Tv_Explored.Visible = False
            TSMI_Rename_Tv_Explored.Visible = False

            TSMI_Cut_Tv_Explored.Visible = False
            TSMI_Copy_Tv_Explored.Visible = False

            ToolStripMenuItem12.Visible = False
        Else
            TSMI_Delete_Tv_Explored.Visible = True
            TSMI_Rename_Tv_Explored.Visible = True

            TSMI_Cut_Tv_Explored.Visible = True
            TSMI_Copy_Tv_Explored.Visible = True

            ToolStripMenuItem12.Visible = True
        End If

    End Sub

    'Refresca el proyecto.
    Private Sub TSB_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_Refresh.Click
        UpdateProject_Sub()
    End Sub

    'Controla el cierre de la aplicacion.
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Guarda el estado del formulario.
        StateSaveMainForm()

        Dim text As String = "¿Desea detener la Depuración?"
        Dim title As String = "VisualLoveProject 2.0 Ultimate."
        Dim style As MsgBoxStyle = MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo
        e.Cancel = True


        Dim nameFile As String = My.Computer.FileSystem.GetName(TSSL_Path.Text)
        Dim t1 As String = Mid(TSSL_Path.Text, 1, Len(TSSL_Path.Text) - Len(nameFile))
        Dim pathNew As String = t1 & "SettingsProjects"

        If TSSL_Path.Text <> "?" Or Not TSSL_Path.Text <> "" Then
            If My.Computer.FileSystem.DirectoryExists(pathNew) = True Then
                Try
                    ControllerStateProject1.SaveStateProject(pathNew & "\StateTabPage.cf")
                Catch ex As Exception
                End Try
            Else
                My.Computer.FileSystem.CreateDirectory(pathNew)
                Try
                    ControllerStateProject1.SaveStateProject(pathNew & "\StateTabPage.cf")
                Catch ex As Exception
                End Try
            End If
        End If


        If TSB_StopDebugging.Enabled = True Then
            Dim MsBox = MsgBox(text, style, title)
            If MsBox = MsgBoxResult.Yes Then
                Try
                    '
                    TSB_StartDebugging.Enabled = True
                    TSB_StopDebugging.Enabled = False
                    '
                    TSMI_StartDebugging.Enabled = True
                    TSMI_StopDebugging.Enabled = False
                    '
                    proc.Kill()
                    '
                    CloseTabProject(TC_Editor, e)
                Catch ex As Exception
                End Try
            ElseIf MsBox = MsgBoxResult.No Then
                e.Cancel = True
            End If
        Else
            CloseTabProject(TC_Editor, e)
        End If
    End Sub

    'Controla la seleccion de las pestañas.
    Private Sub TC_Editor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TC_Editor.MouseDown
        Dim pt As New Point(e.X, e.Y)
        Dim tp As TabPage = VLP_Styles.GetTabPageSelected(pt, TC_Editor)
        If tp IsNot Nothing Then

            If e.Button = Windows.Forms.MouseButtons.Right Then
                TC_Editor.SelectedTab = tp
            End If

            If e.Button = Windows.Forms.MouseButtons.Middle Then

                TC_Editor.SelectedTab = tp

                If tp.ImageIndex = 7 Then
                    CloseTabAction(tp)
                Else
                    TC_Editor.Controls.Remove(tp)
                End If

            End If

        End If
    End Sub

    'Guarda las pestañas al cerrarlas.
    Public Sub CloseTabAction(ByVal tp As TabPage)
        Dim title As String = "VisualLoveProject 2.0 Ultimate"
        Dim text As String = "No a guardado los cambios, ¿Desea guardar los cambios?"
        Dim msgStyle As MsgBoxStyle = MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Information
        Dim msgResultYes As MsgBoxResult = MsgBoxResult.Yes
        Dim ms = MsgBox(text, msgStyle)
        If ms = MsgBoxResult.Yes Then 'Accion para el botton yes

            Dim oSW As New StreamWriter(tp.Name)
            Dim Linea As String = CType(tp.Controls.Item(0), FastColoredTextBox).Text
            oSW.WriteLine(Linea)
            'oSW.Flush()
            oSW.Close()

            TC_Editor.Controls.Remove(tp)
        ElseIf ms = MsgBoxResult.No Then 'Accion para el botton no
            TC_Editor.Controls.Remove(tp)
        ElseIf ms = MsgBoxResult.Cancel Then 'Accion para el botton Cancelar
            'Accion para el botton Cancelar
            Exit Sub
        End If
    End Sub

    'Cierra las pestañas del projecto pero si no se an guardado los cambios te tira el mensaje de guardado.
    Public Sub CloseTabProject(ByVal TabControl As TabControl, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        Dim title As String = "VisualLoveProject 2.0 Ultimate" 'Titulo de la ventana de mensage.
        Dim text As String = "No a guardado los cambios, ¿Desea guardar los cambios?" 'Texto que compone el cuerpo del mensage.
        Dim msgStyle As MsgBoxStyle = MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Information 'Estilo del mensage.

        For Each tp In TabControl.TabPages 'Carga todas las pestañas del editor que esten disponibles. 
            e.Cancel = True 'Cancela el cierre del formulario.

            If tp.ImageIndex = 7 Then 'Comprueba que la imagen selecionada sea la de guardado.

                TabControl.SelectedTab = tp 'Selecciona la pestaña indicada.

                Dim ms = MsgBox(text, msgStyle, title) 'Carga el mensage con las configuraciones antes definidas.

                If ms = MsgBoxResult.Yes Then 'Comprueba que la opcion seleccionada sea si o yes.
                    'Codigo para el guardado de los textos del editor.
                    Dim oSW As New StreamWriter(TabControl.SelectedTab.Name)
                    Dim Linea As String = CType(tp.Controls.Item(0), FastColoredTextBox).Text
                    oSW.WriteLine(Linea)
                    oSW.Flush()
                    'Fin del codigo de guardado.

                    'Borra la pestaña seleccionada.
                    TabControl.Controls.Remove(tp)
                ElseIf ms = MsgBoxResult.No Then 'Comprueba que la opcion seleccionada sea no.

                    'Borra la pestaña seleccionada.
                    TabControl.Controls.Remove(tp)

                ElseIf ms = MsgBoxResult.Cancel Then 'Comprueba que la opcion seleccionada sea cancelar.
                    Exit Sub 'Sale del sub.
                End If 'Cierre del if

            End If 'Cierre del if
        Next 'Cierre del for

        'Este codigo se encarga de cerrar las pestañas que no an sido modificadas.
        For Each tp In TabControl.TabPages 'Carga todas las pestañas del editor que esten disponibles. 
            If tp.ImageIndex = 0 Then 'Comprueba que la imagen selecionada sea la normal.
                TabControl.Controls.Remove(tp) 'Borra la pestaña seleccionada.
            End If 'Cierre del if
        Next 'Cierre del for

        e.Cancel = False 'Reanuda la cancelacion del formulario.
    End Sub

    'Borra todos los cambios previamente realizados en el proyecto.
    Private Sub ResetProjectClear()
        If ClosedProjectActual(TC_Editor) = "Cancelar" Then
        Else

            'Codigos para el formulario principal.
            Path_Project = ""
            TSSL_Path.Text = "?"
            Me.Text = "VisualLoveProject 2.0 Ultimate"
            TV_Explored.Nodes.Clear()
            TC_Editor.TabPages.Clear()

            'Codigos para la consola.
            Console1.C_Text.Text = ""

            'Codigos para el FindForm1.
            FindForm1.TB_Find.Text = ""

            'Codigos para el GoToLineForm1.
            GoToLineForm1.TB_LineNumber.Text = ""
            GoToLineForm1.TM_ControlTextLine.Stop()

            'Codigos para el ReplaceForm1.
            ReplaceForm.TB_Find.Text = ""
            ReplaceForm.TB_Replace.Text = ""

            '========================================
            GB_Explored.Visible = False
            Console1.Visible = False
            '========================================

        End If
    End Sub

    'Cierra el proyecto con todo su contenico.
    Private Sub ResetProjectClearAll()

        'Optimiza el rendimiento de la aplicacion.
        TM_ControlUpdate.Enabled = True
        Try
            'Optimiza el rendimiento de la aplicacion.
            TM_ControlUpdate.Enabled = True

            FindForm1.Close()
            GoToLineForm1.Close()
            ImageViewForm1.Close()
            NewProject.Close()
            OptionsForm.Close()
            PropertiesForm.Close()
            ReplaceForm.Close()
            ColorCustomForm1.Close()

            BW_RuningProject.CancelAsync()
            proc.Kill()
        Catch ex As Exception
        End Try

        'Optimiza el rendimiento de la aplicacion.
        TM_ControlUpdate.Enabled = False

        'Desabilita los botones de ejecucion.
        TSB_StartDebugging.Enabled = False
        TSB_StopDebugging.Enabled = False
        '
        TSMI_StartDebugging.Enabled = False
        TSMI_StopDebugging.Enabled = False
        '
        'Desabilita los botones de generar.
        TSMI_GenerateLove.Enabled = False
        TSMI_GenerateExe.Enabled = False
        '
        'Desabilita los botones de pryecto.
        TSMI_ViewExplored.Enabled = False
        TSMI_RefreshProject.Enabled = False
        TSMI_PropertyProject.Enabled = False
        '
        'Desabilita el boton cerra proyecto.
        TSMI_CloseProject.Enabled = False

        'Optimiza el rendimiento de la aplicacion.
        TM_ControlUpdate.Enabled = True

        'Resetea el boton para ver los archivos ocultos.
        TSB_ShowFiles.Checked = False
        UploadingFilesAndFolder.Show_Hide = False

        '========================================
        GB_Explored.Visible = False
        Console1.Visible = False
        '========================================

    End Sub

    'Guarda el archivo seleccionado del editor de codigo.
    Private Sub SaveFile()
        Try

            If InStr(TC_Editor.SelectedTab.Name, ".lua") Then
                TC_Editor.SelectedTab.ImageIndex = 1
            ElseIf InStr(TC_Editor.SelectedTab.Name, ".txt") Then
                TC_Editor.SelectedTab.ImageIndex = 2
            End If

            Dim SW As New StreamWriter(TC_Editor.SelectedTab.Name)
            Dim Linea As String = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).Text
            SW.Write(Linea)

            SW.Close()

            SaveConfigFileFolder()

            CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).IsChanged = False
            CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).Refresh()

            Dim nameFile As String = My.Computer.FileSystem.GetName(TSSL_Path.Text)
            Dim t1 As String = Mid(TSSL_Path.Text, 1, Len(TSSL_Path.Text) - Len(nameFile))
            Dim pathNew As String = t1 & "SettingsProjects"

            If My.Computer.FileSystem.DirectoryExists(pathNew) = True Then
                Try
                    ControllerStateProject1.SaveStateProject(pathNew & "\StateTabPage.cf")
                Catch ex As Exception
                End Try
            Else
                My.Computer.FileSystem.CreateDirectory(pathNew)
                Try
                    ControllerStateProject1.SaveStateProject(pathNew & "\StateTabPage.cf")
                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception
        End Try
    End Sub

    'Guarda todos los pesta archivos abiertos en el editor de codigo.
    Private Sub SaveAllFile()
        Try
            Dim i As Integer = 0
            With TC_Editor

                For i = 0 To .TabPages.Count - 1

                    Dim SW As New StreamWriter(.TabPages(i).Name)
                    Dim Linea As String = CType(.TabPages(i).Controls.Item(0), FastColoredTextBox).Text

                    If InStr(.TabPages(i).Name, ".lua") Then
                        TC_Editor.TabPages(i).ImageIndex = 1
                    ElseIf InStr(.TabPages(i).Name, ".txt") Then
                        TC_Editor.TabPages(i).ImageIndex = 2
                    End If

                    SW.Write(Linea)
                    SW.Flush()
                    SW.Close()

                    CType(TC_Editor.TabPages(i).Controls.Item(0), FastColoredTextBox).IsChanged = False
                    CType(TC_Editor.TabPages(i).Controls.Item(0), FastColoredTextBox).Refresh()

                    If i = .TabPages.Count - 1 Then
                        Exit For
                    End If
                Next

            End With

            SaveConfigFileFolder()

            Dim nameFile As String = My.Computer.FileSystem.GetName(TSSL_Path.Text)
            Dim t1 As String = Mid(TSSL_Path.Text, 1, Len(TSSL_Path.Text) - Len(nameFile))
            Dim pathNew As String = t1 & "SettingsProjects"

            If My.Computer.FileSystem.DirectoryExists(pathNew) = True Then
                Try
                    ControllerStateProject1.SaveStateProject(pathNew & "\StateTabPage.cf")
                Catch ex As Exception
                End Try
            Else
                My.Computer.FileSystem.CreateDirectory(pathNew)
                Try
                    ControllerStateProject1.SaveStateProject(pathNew & "\StateTabPage.cf")
                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception
        End Try
    End Sub

    'Guarda los cambios realizados en los proyectos recientes.
    Public Function ClosedProjectActual(ByVal TabControl As TabControl)
        Dim title As String = "VisualLoveProject 2.0 Ultimate" 'Titulo de la ventana de mensage.
        Dim text As String = "No a guardado los cambios, ¿Desea guardar los cambios?" 'Texto que compone el cuerpo del mensage.
        Dim msgStyle As MsgBoxStyle = MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Information 'Estilo del mensage.

        For Each tp In TabControl.TabPages 'Carga todas las pestañas del editor que esten disponibles. 

            If tp.ImageIndex = 7 Then 'Comprueba que la imagen selecionada sea la de guardado.

                TabControl.SelectedTab = tp 'Selecciona la pestaña indicada.

                Dim ms = MsgBox(text, msgStyle, title) 'Carga el mensage con las configuraciones antes definidas.

                If ms = MsgBoxResult.Yes Then 'Comprueba que la opcion seleccionada sea si o yes.
                    'Codigo para el guardado de los textos del editor.
                    Dim oSW As New StreamWriter(TabControl.SelectedTab.Name)
                    Dim Linea As String = CType(tp.Controls.Item(0), FastColoredTextBox).Text
                    oSW.WriteLine(Linea)
                    oSW.Flush()
                    'Fin del codigo de guardado.

                    'Borra la pestaña seleccionada.
                    TabControl.Controls.Remove(tp)
                ElseIf ms = MsgBoxResult.No Then 'Comprueba que la opcion seleccionada sea no.

                    'Borra la pestaña seleccionada.
                    TabControl.Controls.Remove(tp)
                ElseIf ms = MsgBoxResult.Cancel Then 'Comprueba que la opcion seleccionada sea cancelar.

                    'Debuelve un valor string
                    Return "Cancelar"
                    Exit Function 'Sale de la function.

                End If 'Cierre del if

            End If 'Cierre del if

        Next 'Cierre del for

        'Este codigo se encarga de cerrar las pestañas que no an sido modificadas.
        For Each tp In TabControl.TabPages 'Carga todas las pestañas del editor que esten disponibles. 
            If tp.ImageIndex = 0 Then 'Comprueba que la imagen selecionada sea la normal.
                TabControl.Controls.Remove(tp) 'Borra la pestaña seleccionada.
            End If 'Cierre del if
        Next 'Cierre del for

    End Function

    'Crea el archivo love.
    Public Sub BuilldLoveFile(ByVal Path As String)
        Control.CheckForIllegalCrossThreadCalls = False
        TimerProsses = 0
        Timer_Process.Start()

        Console1.C_Text.Clear()

        Console1.Visible = True
        'Recorta la extencion de la ruta
        Dim nombre_limpio As String = Mid(Path, 1, Len(Path) - 4)
        '------------Recorta el nombre del proyecto------------------------------------------------
        Dim nombreFolder As String = My.Computer.FileSystem.GetName(nombre_limpio)
        Dim recorta As String = Len(nombreFolder)
        Dim Finish As String = Mid(nombre_limpio, 1, Len(nombre_limpio) - recorta)

        'Crea carpeta Builder
        Dim CrearCarpetaBuild As String = Finish & "\Builder\love"
        If My.Computer.FileSystem.DirectoryExists(CrearCarpetaBuild) Then
        Else
            My.Computer.FileSystem.CreateDirectory(CrearCarpetaBuild)
        End If

        Try
            'Crea el archivo love
            Console1.C_Text.Clear()
            Using zip As ZipFile = New ZipFile
                zip.AddDirectory(nombre_limpio, "")
                Console1.C_Text.Text = "> Comprimiendo el archivo ..."

                zip.Save(CrearCarpetaBuild & "\" & nombreFolder & ".love")
            End Using
            Console1.C_Text.Text += " Ok"
            Console1.C_Text.Text += vbNewLine & "> Proceso terminado en " & TimerProsses & " ms."

            Timer_Process.Stop()
        Catch ex As Exception
            Console1.C_Text.Clear()
            Console1.C_Text.Text += vbNewLine & "> Error (#1200) al comprimir el archivo."

            Timer_Process.Stop()

            MsgBox(ex.ToString, vbCritical)
            BW_CompileRun.CancelAsync()
            Exit Sub
        End Try
    End Sub

    'Genera el Archivo exe.
    Public Sub BuilldExeFile(ByVal Path As String)
        Control.CheckForIllegalCrossThreadCalls = False

        'Function para eliminar el archivo exe de la carpeta builder.
        Dim PathClear1 As String = Help_Function1.PathRecort(Path)
        Dim path2 As String = PathClear1 & "Builder\exe\"
        Dim recPath As String = Mid(My.Computer.FileSystem.GetName(Path), 1, Len(My.Computer.FileSystem.GetName(Path)) - 4) & ".exe"
        Dim FullPathDelete As String = path2 & recPath

        If My.Computer.FileSystem.FileExists(FullPathDelete) = True Then
            Try
                My.Computer.FileSystem.DeleteFile(FullPathDelete)
            Catch ex As Exception
                'MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If

        Console1.C_Text.Clear()

        Console1.Visible = True
        Dim nombre_limpio As String = Mid(Path, 1, Len(Path) - 4)
        Dim nombreFolder As String = My.Computer.FileSystem.GetName(nombre_limpio)
        Dim recorta As String = Len(nombreFolder)
        Dim Finish As String = Mid(nombre_limpio, 1, Len(nombre_limpio) - recorta)
        Dim CrearCarpetaBuild As String = Finish & "Builder\exe"
        Dim RutaSalidaLOVE As String = "C:\Windows\Temp\prueba.love"
        Dim rutaLoveEXE As String
        Dim RutaBat As String
        Dim RutaSalidaExe As String = CrearCarpetaBuild & "\" & nombreFolder & ".exe"

        If My.Computer.FileSystem.DirectoryExists(CrearCarpetaBuild) Then
        Else
            My.Computer.FileSystem.CreateDirectory(CrearCarpetaBuild)
        End If

        Try
            'Crea el archivo love
            Using zip As ZipFile = New ZipFile
                zip.AddDirectory(nombre_limpio, "")

                Console1.C_Text.Text += "> Comprimiendo el archivo ..."

                zip.Save(RutaSalidaLOVE)
            End Using

            Console1.C_Text.Text += " Ok"

            rutaLoveEXE = Application.StartupPath & "\Love2d\LOVE " & LoveVersionProject & "\love.exe" 'Application.StartupPath & "\Love2d\LOVE 0.8.0\love.exe"

            Console1.C_Text.Text += vbNewLine & "> Convirtiendo a exe ..."

            'Nuevo metodo para convertir a exe el archivo love.
            Dim BytesExe As Byte() = File.ReadAllBytes(rutaLoveEXE)
            Dim BytesLove As Byte() = File.ReadAllBytes(RutaSalidaLOVE)

            Using sd As FileStream = New FileStream(RutaSalidaExe, FileMode.OpenOrCreate, FileAccess.Write)
                sd.Write(BytesExe, 0, BytesExe.Length)
                sd.Write(BytesLove, 0, BytesLove.Length)
            End Using

            Console1.C_Text.Text += " Ok"

            Dim PathIcoFile As String = IconCompiler 'Application.StartupPath & "\Default-Ico\icon.ico" 'Eliminar y sustituir
            RutaBat = Application.StartupPath & "\Love2d\LOVE " & LoveVersionProject & "\" '"\Love2d\LOVE 0.8.0\"

            Console1.C_Text.Text += vbNewLine & "> Copiando archivos necesarios para la ejecusion:"
            Console1.C_Text.Text += vbNewLine & "----------------------------------------------------------------------"

            For Each item In My.Computer.FileSystem.GetFiles(RutaBat, FileIO.SearchOption.SearchAllSubDirectories, "*.dll")
                Dim My_Nombre As String = My.Computer.FileSystem.GetName(item)
                My.Computer.FileSystem.CopyFile(item, CrearCarpetaBuild & "\" & My_Nombre, True)
                Dim nombreFiles As String = My.Computer.FileSystem.GetName(item)

                Console1.C_Text.Text += vbNewLine & "> " & nombreFiles & " ... Ok"
            Next

            Console1.C_Text.Text += vbNewLine & "----------------------------------------------------------------------"

            Console1.C_Text.Text += vbNewLine & "> Personalizando icono ..."

            'Variable que carga la function para cambiar el icono.
            Dim IcoChanged As New IcoChanged.Modify
            IcoChanged.Modify(RutaSalidaExe, PathIcoFile, RutaSalidaExe)

            Console1.C_Text.Text += " Ok"

            Console1.C_Text.Text += vbNewLine & "> Eliminando archivos temporales ..."

            'Este troso de codigo elimina los archivos temporales.
            Try
                My.Computer.FileSystem.DeleteFile(RutaSalidaLOVE)
                Console1.C_Text.Text += " Ok"
            Catch ex As Exception
                Console1.C_Text.Text += " Error al tratar de eliminar los archivos temporales."
            End Try

            Timer_Process.Stop()

            Console1.C_Text.Text += vbNewLine & "> Proceso terminado en " & TimerProsses & " ms."

        Catch ex As Exception
            Timer_Process.Stop()
            Console1.C_Text.Text += vbNewLine & "> " & ex.Message
            BW_CompileRun.CancelAsync()
            Exit Sub
        End Try

    End Sub

    'Function para ejecuta el proyecto abierto.
    Private Sub RunProject()
        Control.CheckForIllegalCrossThreadCalls = False
        Console1.Visible = True
        '----------------------------------------------------------------------
        Console1.C_Text.Text = "> En ejecusion."
        Me.Text = Me.Text + " Ejecutando."

        Dim ruta_exe As String

        ruta_exe = Application.StartupPath & "\Love2d\LOVE " & LoveVersionProject & "\love.exe" '"\Love2d\LOVE 0.8.0\love.exe"

        Dim nombre As String = TSSL_Path.Text
        Dim nombre_limpio As String = Mid(nombre, 1, Len(nombre) - 4)
        'Dim nombre As String = My.Computer.FileSystem.GetName(ToolStripStatusLabel2.Text)
        'Dim nombre_limpio As String = Mid(nombre, 1, Len(nombre) - 4)
        '----------------------------------------------------------------------------
        Dim recorta2 As String = nombre_limpio
        '----------------------------------------------------------------------
        'Todos los parametros requeridos para la ejecucion.
        proc.StartInfo.FileName = """" & ruta_exe & """"
        proc.StartInfo.Arguments = """" & recorta2 & """"
        proc.StartInfo.RedirectStandardError = True
        proc.StartInfo.RedirectStandardOutput = True
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.CreateNoWindow = True

        Try
            proc.Start()
        Catch ex As Exception
            'MsgBox("", vbCritical)
            Exit Sub
        End Try

        'Guardamos las salidas en un string
        Dim Output As String = proc.StandardOutput.ReadToEnd() & vbCrLf & proc.StandardError.ReadToEnd()
        OuputConsole = Output
        Console1.C_Text.Text = Output

    End Sub

    'Boton iniciar.
    Private Sub StartEjecution()
        Key_Run = True
        '
        TSB_StartDebugging.Enabled = False
        TSB_StopDebugging.Enabled = True
        '
        TSMI_StartDebugging.Enabled = False
        TSMI_StopDebugging.Enabled = True
        '
        OuputConsole = ""
        BW_RuningProject.RunWorkerAsync()
        Console1.C_Text.Clear()
    End Sub

    'Boton detener.
    Private Sub StopEjecution()
        Try
            TSB_StartDebugging.Enabled = True
            TSB_StopDebugging.Enabled = False
            '
            TSMI_StartDebugging.Enabled = True
            TSMI_StopDebugging.Enabled = False
            '
            proc.Kill()
            '
        Catch ex As Exception
            'MsgBox(Texto4, vbCritical)
        End Try
    End Sub

    'Ejecuta el projecto.
    Private Sub BW_RuningProject_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BW_RuningProject.DoWork
        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle

        msg = ""

        style = MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo
        title = "VisualLoveProject 2.0 Ultimate"

        Try
            RunProject()
        Catch ex As Exception
            If MsgBox(msg, style, title) = MsgBoxResult.Yes Then
                'ActualizarVLP()
            Else
                Exit Sub
            End If
        End Try
    End Sub

    'Se ejecuta cuando la ejecucion halla finalizado.
    Private Sub BW_RuningProject_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BW_RuningProject.RunWorkerCompleted
        Key_Run = False

        If TSSL_Path.Text = "" Or TSSL_Path.Text = "?" Then
            TSB_StartDebugging.Enabled = False
            TSB_StopDebugging.Enabled = False

            TSMI_StartDebugging.Enabled = False
            TSMI_StopDebugging.Enabled = False

            TSMI_CloseProject.Enabled = False
        Else
            TSMI_StartDebugging.Enabled = True
            TSMI_StopDebugging.Enabled = False

            TSB_StartDebugging.Enabled = True
            TSB_StopDebugging.Enabled = False

            'TSMI_CloseProject.Enabled=True
        End If

        Me.Text = My.Computer.FileSystem.GetName(TSSL_Path.Text) & " - VisualLoveProject 2.0 Ultimate"

        If OuputConsole = " " Or OuputConsole = Nothing Or OuputConsole = "" Or OuputConsole = vbNewLine Then
            Console1.C_Text.Text = ""
            'Console1.Visible = False
        Else
            Console1.C_Text.Text = OuputConsole
            Console1.Visible = True
        End If
    End Sub

    'Function para implementar autosave.
    Private Sub AutoSave()
        If TC_Editor.TabPages.Count <= 0 Then
            Exit Sub
        End If

        If TSSL_Path.Text = "?" Or TSSL_Path.Text = " " Then
        Else
            AutoSaveTime = AutoSaveTime + 1
        End If

        Try
            If AutoSaveTime >= AutoSaveTimeStep Then
                SaveAllFile()
                AutoSaveTime = 1
            End If
        Catch ex As Exception
            AutoSaveTime = 1
        End Try
        'Me.Text = AutoSaveTime
    End Sub

    'Eventos para el closebutton del UserTabControl.
    Private Sub UserTabControl1_CloseItemsTab(ByVal TabPageClose As TabPage) Handles TC_Editor.CloseItemsTab
        Try
            If TC_Editor.SelectedTab.ImageIndex = 7 Then
                CloseTabAction(TabPageClose)
            Else
                TC_Editor.Controls.Remove(TabPageClose)
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Codigo para visualiza el color seleccionado.
    Private Sub ViewColorSelection(ByVal TextColor As String)
        Try
            Dim ColorMatris() As String = Regex.Split(TextColor, ",")

            If ColorMatris.Count = 3 Then
                Dim RedColor As Integer = ColorMatris(0)
                Dim GreenColor As Integer = ColorMatris(1)
                Dim BlueColor As Integer = ColorMatris(2)
                Dim AlphaColor As Integer = 255

                Dim ColorValue As Color = Color.FromArgb(AlphaColor, RedColor, GreenColor, BlueColor)
                ColorCustomForm1.UserTrackBar1.Value = RedColor
                ColorCustomForm1.UserTrackBar2.Value = GreenColor
                ColorCustomForm1.UserTrackBar3.Value = BlueColor
                ColorCustomForm1.UserTrackBar4.Value = AlphaColor
                ColorCustomForm1.PictureBox1.BackColor = ColorValue

            ElseIf ColorMatris.Count = 4 Then
                Dim RedColor As Integer = ColorMatris(0)
                Dim GreenColor As Integer = ColorMatris(1)
                Dim BlueColor As Integer = ColorMatris(2)
                Dim AlphaColor As Integer = ColorMatris(3)

                Dim ColorValue As Color = Color.FromArgb(AlphaColor, RedColor, GreenColor, BlueColor)
                ColorCustomForm1.UserTrackBar1.Value = RedColor
                ColorCustomForm1.UserTrackBar2.Value = GreenColor
                ColorCustomForm1.UserTrackBar3.Value = BlueColor
                ColorCustomForm1.UserTrackBar4.Value = AlphaColor
                ColorCustomForm1.PictureBox1.BackColor = ColorValue

            Else
                'MsgBox("El codigo que ha seleccionado no es un color valido.", MsgBoxStyle.Critical)
                ColorCustomForm1.Close()
                Exit Sub
            End If

            'If PreviewColorForm1.KeyFormVisible = True Then
            'Else
            ColorCustomForm1.Show(Me)
            'End If
        Catch ex As Exception

        End Try
    End Sub

    'Manipula las funciones del editor de codigo.
#Region "Comandos para el editor de codigo."

    'Deshacer los cambios realizados en el editor de codigo.
    Private Sub Undo()
        Try
            CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).Undo()
        Catch ex As Exception
        End Try
    End Sub

    'Rehacer los cambios eliminados en el editor de codigo.
    Private Sub Redo()
        Try
            CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).Redo()
        Catch ex As Exception
        End Try
    End Sub

    'Cortar el codigo seleccionado.
    Private Sub Cut()
        Try
            CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).Cut()
        Catch ex As Exception
        End Try
    End Sub

    'Copiar el codigo seleccionado.
    Private Sub Copy()
        Try
            CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).Copy()
        Catch ex As Exception
        End Try
    End Sub

    'Pegar el texto copiado o cortado en el editor de codigo.
    Private Sub Paste()
        Try
            CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).Paste()
        Catch ex As Exception
        End Try
    End Sub

    'Seleccionar todo el contnido del editor de codigo.
    Private Sub SelectedAll()
        Try
            CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).SelectAll()
        Catch ex As Exception
        End Try
    End Sub

    'Borrar el texto seleccionado.
    Private Sub DeleteSelectedText()
        Try
            CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).SelectedText = ""
        Catch ex As Exception
        End Try
    End Sub

    'Buscar texto en el editor de codigo.
    Private Sub Find()
        Try
            If CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).SelectedText = "" Then
            Else
                FindForm1.TB_Find.Text = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).SelectedText
            End If
            FindForm1.Show(Me)
        Catch ex As Exception
            FindForm1.TB_Find.Text = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).SelectedText
        End Try
    End Sub

    'Reemplazar texto en el editor de codigo.
    Private Sub Replace()
        Try
            If CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).SelectedText = "" Then
            Else
                ReplaceForm.TB_Find.Text = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).SelectedText
            End If
            ReplaceForm.Show(Me)
        Catch ex As Exception
            ReplaceForm.TB_Find.Text = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).SelectedText
        End Try
    End Sub

    'Ir a la linea deceada en el editor de codigo.
    Private Sub GoToLine()
        Try
            GoToLineForm1.Show(Me)
        Catch ex As Exception
        End Try
    End Sub

    'Abre el proyecto en el explorador de windows.
    Private Sub ViewInExplored()
        Dim nombre As String = TSSL_Path.Text
        Dim nombre_limpio As String = Mid(nombre, 1, Len(nombre) - 4)
        '----------------------------------------------------------------------------
        Dim recorta2 As String = nombre_limpio
        '----------------------------------------------------------------------
        Try
            System.Diagnostics.Process.Start(recorta2)
        Catch ex As Exception
        End Try
    End Sub

    'Comentar la linea seleccionada.
    Private Sub ComentLine()
        Try
            CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).InsertLinePrefix("--")
        Catch ex As Exception
        End Try
    End Sub

    'Descomentar la linea seleccionada.
    Private Sub DescomentLine()
        Try
            CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).RemoveLinePrefix("--")
        Catch ex As Exception
        End Try
    End Sub

    'Add bookmark.
    Private Sub AddBookMark()
        Try
            Dim BookMarkCode As New bookmarkCode
            If BookMarkCode.CurrentTB IsNot Nothing Then
                Dim info As TbInfo = TryCast(BookMarkCode.CurrentTB.Tag, TbInfo)
                Dim id As Integer = BookMarkCode.CurrentTB(BookMarkCode.CurrentTB.Selection.Start.iLine).UniqueId
                If Not info.bookmarksLineId.Contains(id) Then
                    info.bookmarks.Add(id)
                    info.bookmarksLineId.Add(id)
                    BookMarkCode.CurrentTB.Invalidate()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Remove boomark.
    Private Sub RemoveBookMark()
        Try
            Dim BookMarkCode As New bookmarkCode
            If BookMarkCode.CurrentTB IsNot Nothing Then
                Dim info As TbInfo = TryCast(BookMarkCode.CurrentTB.Tag, TbInfo)
                Dim id As Integer = BookMarkCode.CurrentTB(BookMarkCode.CurrentTB.Selection.Start.iLine).UniqueId
                If info.bookmarksLineId.Contains(id) Then
                    info.bookmarks.Remove(id)
                    info.bookmarksLineId.Remove(id)
                    BookMarkCode.CurrentTB.Invalidate()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Clickea en los BookMark agregados.
    Private Sub TSB_BookMark_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSB_BookMark.DropDownOpening
        Try
            Dim BookMarkCode As New bookmarkCode
            TSB_BookMark.DropDownItems.Clear()
            For Each tab As Control In TC_Editor.TabPages
                Dim tb As FastColoredTextBox = TryCast(tab.Controls(0), FastColoredTextBox)
                Dim info As TbInfo = TryCast(tb.Tag, TbInfo)
                For i As Integer = 0 To info.bookmarks.Count - 1
                    Dim item As ToolStripItem = TSB_BookMark.DropDownItems.Add(String.Concat(New Object() {"Bookmark ", TSB_BookMark.DropDownItems.Count, " [", Path.GetFileNameWithoutExtension(TryCast(tab.Text, String)), "]"}))
                    item.Tag = New bookmarkCode.BookmarkInfo() With {.FastColorTexBox = tb, .iBookmark = i}
                    AddHandler item.Click, Sub(o As Object, a As EventArgs)
                                               BookMarkCode.[GoTo](CType(TryCast(o, ToolStripItem).Tag, bookmarkCode.BookmarkInfo))
                                           End Sub
                Next
            Next
        Catch ex As Exception
        End Try
    End Sub

    'Normaliza el zoom de editor de codigo.
    Private Sub NormalZoom()
        Try
            Dim tb = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
            Dim Font1 As New Font("Consolas", 13, FontStyle.Bold, GraphicsUnit.World)
            CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).Font = Font1
            Zoom = 13
            tb.LeftPadding = 20
            'tb.valueMaxClick = 15
            'BookMarkCode.bookmarkSize = 15 'Normaliza el tamaño del bookmark.
            resaltado.bookmarkSize = 15 'Normaliza el tamaño del bookmark.
        Catch ex As Exception
        End Try
    End Sub

#End Region

    Private Sub CMS_Cut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_Cut.Click
        Cut()
    End Sub

    Private Sub CMS_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_Copy.Click
        Copy()
    End Sub

    Private Sub CMS_Paste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_Paste.Click
        Paste()
    End Sub

    Private Sub CMS_SelectedAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_SelectedAll.Click
        SelectedAll()
    End Sub

    Private Sub CMS_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_Delete.Click
        DeleteSelectedText()
    End Sub

    Private Sub CMS_Find_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_Find.Click
        Find()
    End Sub

    Private Sub CMS_Replace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_Replace.Click
        Replace()
    End Sub

    Private Sub CMS_GoToLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_GoToLine.Click
        GoToLine()
    End Sub

    Private Sub T_FunctionUpdate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TM_ControlUpdate.Tick
        UpdateControlStatus.OptionsUpdate()
    End Sub

    Private Sub TSMI_CloseProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_CloseProject.Click
        ResetProjectClear()
        ResetProjectClearAll()
    End Sub

    Private Sub TSMI_CloseTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_CloseTab.Click
        CloseSelectedTab()
    End Sub

    Private Sub TSMI_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Exit.Click
        Me.Close()
    End Sub

    Private Sub TSMI_Undo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Undo.Click
        Dim tb = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
        If tb.Focused = True Then
            Undo()
        End If
    End Sub

    Private Sub TSMI_Redo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Redo.Click
        Dim tb = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
        If tb.Focused = True Then
            Redo()
        End If
    End Sub

    Private Sub TSMI_Cut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Cut.Click
        Dim tb = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
        If tb.Focused = True Then
            Cut()
        End If
    End Sub

    Private Sub TSMI_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Copy.Click
        Dim tb = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
        If tb.Focused = True Then
            Copy()
        End If
    End Sub

    Private Sub TSMI_Paste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Paste.Click
        Dim tb = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
        If tb.Focused = True Then
            Paste()
        End If
    End Sub

    Private Sub TSMI_GotoIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_GotoIn.Click
        'Dim tb = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
        'If tb.Focused = True Then
        GoToLineForm1.Show(Me)
        'End If
    End Sub

    Private Sub TSMI_Find_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Find.Click
        'Dim tb = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
        'If tb.Focused = True Then
        FindForm1.Show(Me)
        'End If
    End Sub

    Private Sub TSB_Find_Click(sender As System.Object, e As System.EventArgs) Handles TSB_Find.Click
        'Dim tb = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
        'If tb.Focused = True Then
        FindForm1.Show(Me)
        'End If
    End Sub

    Private Sub TSMI_Replace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Replace.Click
        'Dim tb = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
        'If tb.Focused = True Then
        ReplaceForm.Show(Me)
        'End If
    End Sub

    Private Sub TSMI_SelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_SelectAll.Click
        Dim tb = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
        If tb.Focused = True Then
            SelectedAll()
        End If
    End Sub

    Private Sub TSMI_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Delete.Click
        DeleteSelectedText()
    End Sub

    Private Sub TSMI_ViewExplored_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_ViewExplored.Click
        ViewInExplored()
    End Sub

    Private Sub TSMI_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Save.Click
        SaveFile()
    End Sub

    Private Sub TSMI_SaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_SaveAll.Click
        SaveAllFile()
    End Sub

    Private Sub TSB_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_Save.Click
        SaveFile()
    End Sub

    Private Sub TSB_SaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_SaveAll.Click
        SaveAllFile()
    End Sub

    Private Sub TSB_Cut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_Cut.Click
        Cut()
    End Sub

    Private Sub TSB_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_Copy.Click
        Copy()
    End Sub

    Private Sub TSB_Paste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_Paste.Click
        Paste()
    End Sub

    Private Sub TSB_Comment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_Comment.Click
        ComentLine()
    End Sub

    Private Sub TSB_DesComment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_DesComment.Click
        DescomentLine()
    End Sub

    Private Sub TSB_AddBookMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_AddBookMark.Click
        AddBookMark()
    End Sub

    Private Sub TSB_RemoveBookMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_RemoveBookMark.Click
        RemoveBookMark()
    End Sub

    Private Sub TSB_Undo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_Undo.Click
        Undo()
    End Sub

    Private Sub TSB_Redo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_Redo.Click
        Redo()
    End Sub

    Private Sub TSB_ZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_ZoomIn.Click
        'ZoomIn()
    End Sub

    Private Sub TSB_ZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_ZoomOut.Click
        'ZoomOut()
    End Sub

    Private Sub TSB_NormalZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_NormalZoom.Click
        NormalZoom()
    End Sub

    'Cierra la pestaña seleccionada.
    Private Sub CloseSelectedTab()
        Try
            If TC_Editor.SelectedTab.ImageIndex = 7 Then
                CloseTabAction(TC_Editor.SelectedTab)
            Else
                TC_Editor.Controls.Remove(TC_Editor.SelectedTab)
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Cierra todas las pestañas.
    Private Sub CloseTabAll() 'Function para cerrar todas las pestañas
        Dim title As String = "VisualLoveProject 2.0 Ultimate"
        Dim text As String = "No a guardado los cambios, ¿Desea guardar los cambios?"
        Dim msgStyle As MsgBoxStyle = MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Information
        Dim msgResultYes As MsgBoxResult = MsgBoxResult.Yes

        For Each tp In TC_Editor.TabPages
            If tp.ImageIndex = 7 Then
                TC_Editor.SelectedTab = tp
                Dim ms = MsgBox(text, msgStyle)

                If ms = MsgBoxResult.Yes Then 'Accion para el botton yes

                    Dim oSW As New StreamWriter(TC_Editor.SelectedTab.Name)
                    Dim Linea As String = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).Text
                    oSW.WriteLine(Linea)
                    'oSW.Flush()
                    oSW.Close()

                    TC_Editor.Controls.Remove(tp)
                ElseIf ms = MsgBoxResult.No Then 'Accion para el botton no
                    TC_Editor.Controls.Remove(tp)
                ElseIf ms = MsgBoxResult.Cancel Then 'Accion para el botton Cancelar
                    'Accion para el botton Cancelar
                    Exit Sub
                End If

            End If
        Next

        For Each tp In TC_Editor.TabPages
            If tp.ImageIndex = 1 Then
                TC_Editor.Controls.Remove(tp)
            End If
        Next

    End Sub

    'Cierra todas las pestañas menos la seleccionada.
    Private Sub CloseAllTabOrSelected()
        Dim TabPageActual = TC_Editor.SelectedTab

        For Each tp In TC_Editor.TabPages
            If tp.text = TabPageActual.Text Then
            Else
                Dim title As String = "VisualLoveProject 2.0 Ultimate"
                Dim text As String = "No a guardado los cambios, ¿Desea guardar los cambios?"
                Dim msgStyle As MsgBoxStyle = MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Information
                Dim msgResultYes As MsgBoxResult = MsgBoxResult.Yes

                If tp.ImageIndex = 7 Then
                    TC_Editor.SelectedTab = tp
                    Dim ms = MsgBox(text, msgStyle)

                    If ms = MsgBoxResult.Yes Then 'Accion para el botton yes

                        Dim oSW As New StreamWriter(TC_Editor.SelectedTab.Name)
                        Dim Linea As String = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).Text
                        oSW.WriteLine(Linea)
                        'oSW.Flush()
                        oSW.Close()

                        TC_Editor.Controls.Remove(tp)
                    ElseIf ms = MsgBoxResult.No Then 'Accion para el botton no
                        TC_Editor.Controls.Remove(tp)
                    ElseIf ms = MsgBoxResult.Cancel Then 'Accion para el botton Cancelar
                        'Accion para el botton Cancelar
                        Exit Sub
                    End If

                End If

                If tp.ImageIndex = 1 Then
                    TC_Editor.Controls.Remove(tp)
                End If

            End If

        Next

    End Sub

    'Abre los archivos vlp.
    Private Sub TSB_OpenProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_OpenProject.Click
        Dim openFile As New OpenFileDialog
        'openFile.Title = ""
        openFile.FileName = Nothing
        openFile.Filter = "vlp file|*.vlp*"
        '------------------------------------------------------------
        If openFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            Open_Project(openFile.FileName)
        End If
    End Sub

    'Boton para generar el archivo love.
    Private Sub TSMI_GenerateLove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_GenerateLove.Click
        TimerProsses = 0
        Timer_Process.Start()
        Key_OptionCompiler = False

        Try
            BW_CompileRun.RunWorkerAsync()
        Catch ex As Exception
            MsgBox("ya hay un proceso en ejeccuion, por favor espere hasta que esté termine.", vbCritical)
        End Try

    End Sub

    'Boton para generar el archivo exe.
    Private Sub TSMI_GenerateExe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_GenerateExe.Click
        TimerProsses = 0
        Timer_Process.Start()
        Key_OptionCompiler = True

        Try
            BW_CompileRun.RunWorkerAsync()
        Catch ex As Exception
            MsgBox("ya hay un proceso en ejeccuion, por favor espere hasta que esté termine.", vbCritical)
        End Try

    End Sub

    'Controlador de las opciones de compilar.
    Private Sub BW_CompileOption_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BW_CompileRun.DoWork
        If Key_OptionCompiler = False Then
            BuilldLoveFile(TSSL_Path.Text)
        Else
            BuilldExeFile(TSSL_Path.Text)
        End If
    End Sub

    'Controla el tiempo de ejecucion al finalizar el proceso.
    Private Sub Timer_Process_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Process.Tick
        TimerProsses = TimerProsses + 1
    End Sub

    'Crea las nuevas carpetas.
    Private Sub NewFolder()

        Dim input As New InputBoxCustom1
        Dim Text As String = "Nombre de la carpeta"
        Dim Title As String = "Nueva carpeta"
        Dim DefaultResponse As String = "Nueva carpeta"
        input.IntputBox(Text, Title, DefaultResponse)

        If input.Respose = True Then
            If input.TB_Text.Text = "" Then
                MsgBox("El nombre no puede estar vacio.")
                NewFolder()
            Else
                Try
                    Dim SelectedPasth As String = TV_Explored.SelectedNode.Name

                    If My.Computer.FileSystem.DirectoryExists(SelectedPasth & "\" & input.TB_Text.Text) Then
                        MsgBox("La carpeta (""" & input.TB_Text.Text & """) ya existe.", vbExclamation)
                        NewFolder()
                    Else
                        My.Computer.FileSystem.CreateDirectory(SelectedPasth & "\" & input.TB_Text.Text)
                        UpdateProject_Sub()
                    End If

                Catch ex As Exception
                End Try
            End If
        Else
            '
        End If

    End Sub

    'Crea los nuevos archivos lua.
    Private Sub NewFileLua()

        Dim input As New InputBoxCustom1
        Dim Text As String = "Nombre del archivo"
        Dim Title As String = "Nuevo archivo"
        Dim DefaultResponse As String = "Nuevo archivo"
        input.IntputBox(Text, Title, DefaultResponse)

        If input.Respose = True Then
            If input.TB_Text.Text = "" Then
                MsgBox("El nombre no puede estar vacio.")
                NewFolder()
            Else
                Try
                    Dim SelectedPasth As String = TV_Explored.SelectedNode.Name

                    If My.Computer.FileSystem.FileExists(SelectedPasth & "\" & input.TB_Text.Text) Then
                        MsgBox("El archivo (""" & input.TB_Text.Text & """) ya existe.", vbExclamation)
                        NewFileLua()
                    Else
                        IO.File.Create(SelectedPasth & "\" & input.TB_Text.Text & ".lua")
                        UpdateProject_Sub()
                    End If

                Catch ex As Exception
                End Try
            End If
        Else
            '
        End If

    End Sub

    'Crea los nuevos archivos txt.
    Private Sub NewFileTxt()

        Dim input As New InputBoxCustom1
        Dim Text As String = "Nombre del archivo"
        Dim Title As String = "Nuevo archivo"
        Dim DefaultResponse As String = "Nuevo archivo"
        input.IntputBox(Text, Title, DefaultResponse)

        If input.Respose = True Then
            If input.TB_Text.Text = "" Then
                MsgBox("El nombre no puede estar vacio.")
                NewFolder()
            Else
                Try
                    Dim SelectedPasth As String = TV_Explored.SelectedNode.Name

                    If My.Computer.FileSystem.FileExists(SelectedPasth & "\" & input.TB_Text.Text) Then
                        MsgBox("El archivo (""" & input.TB_Text.Text & """) ya existe.", vbExclamation)
                        NewFileTxt()
                    Else
                        IO.File.Create(SelectedPasth & "\" & input.TB_Text.Text & ".txt")
                        UpdateProject_Sub()
                    End If

                Catch ex As Exception
                End Try
            End If
        Else
            '
        End If

    End Sub

    'Crea las nuevas imagenes png.
    Private Sub NewImageFile()

        Dim input As New InputBoxCustom1
        Dim Text As String = "Nombre de la Imagen"
        Dim Title As String = "Nueva Imagen"
        Dim DefaultResponse As String = "Nueva Imagen"
        input.IntputBox(Text, Title, DefaultResponse)

        If input.Respose = True Then
            If input.TB_Text.Text = "" Then
                MsgBox("El nombre no puede estar vacio.")
                NewFolder()
            Else
                Try
                    Dim SelectedPasth As String = TV_Explored.SelectedNode.Name

                    If My.Computer.FileSystem.FileExists(SelectedPasth & "\" & input.TB_Text.Text) Then
                        MsgBox("El archivo (""" & input.TB_Text.Text & """) ya existe.", vbExclamation)
                        NewImageFile()
                    Else
                        'IO.File.Create(SelectedPasth & "\" & input.TB_Text.Text & ".png")

                        Dim box As New Bitmap(800, 600)
                        Dim g As Graphics = Graphics.FromImage(box)
                        'g.Clear(Color.White)

                        box.Save(SelectedPasth & "\" & input.TB_Text.Text & ".png", Imaging.ImageFormat.Png)

                        UpdateProject_Sub()
                    End If

                Catch ex As Exception
                End Try
            End If
        Else
            '
        End If

    End Sub

    'Importa los archivos de recursos.
    Private Sub ImportSource()
        Dim ImportImageSourceDialog As New OpenFileDialog
        With ImportImageSourceDialog
            .Title = "Import Image"
            .Filter = "All File Support|*.png; *.jpg; *.ico; *.bmp; *.jpeg; *.lua; *.txt; *.mp3; *.ogg; *.wav|All Files|*.*"
            .Multiselect = True
            Dim g As Graphics
            g = TV_Explored.CreateGraphics
            If .ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim fon As New Font("Consola", 10, FontStyle.Bold)
                Dim poin As New Point(60, 80)
                g.DrawString("Cargando...", fon, Brushes.Black, poin)

                Dim SelectedFolder As String = TV_Explored.SelectedNode.Name

                For Each ItemSource In .FileNames
                    Dim SourceCopyFile As String = ItemSource
                    Dim SelectedFolderName As String = My.Computer.FileSystem.GetName(SourceCopyFile)

                    Try
                        My.Computer.FileSystem.CopyFile(SourceCopyFile, SelectedFolder & "\" & SelectedFolderName)
                    Catch ex As Exception
                        MsgBox(ex.ToString, vbCritical)
                    End Try
                Next
                UpdateProject_Sub()

            End If
        End With

    End Sub

    'Muestra la carpeta seleccionada en el explorador de windows.
    Private Sub ViewExploredSelected()
        Dim SelectedPath As String = TV_Explored.SelectedNode.Name
        Try
            System.Diagnostics.Process.Start(SelectedPath)
        Catch ex As Exception
        End Try
    End Sub

    'Function para renombrar los archivos o carpetas del explorador de soluciones.
    Private Function RenameFileExplored(ByVal Path As String)
        Dim input As New InputBoxCustom1

        Dim PathRenameFile As String = Path
        Dim FileExtencion As FileInfo = New FileInfo(PathRenameFile)
        Dim NewNameFile As String = ""

        Dim DirectoryExtencion As DirectoryInfo = New DirectoryInfo(PathRenameFile)
        Dim ExtencionSave As String = FileExtencion.Extension

        input.IntputBox("Renombrar", "Renombrar", My.Computer.FileSystem.GetName(PathRenameFile))
        NewNameFile = input.TB_Text.Text

        If input.Respose = True Then
            Try
                If DirectoryExtencion.Attributes = FileAttributes.Directory Then
                    My.Computer.FileSystem.RenameDirectory(PathRenameFile, NewNameFile)
                Else
                    If InStr(NewNameFile, ".") Then
                        My.Computer.FileSystem.RenameFile(PathRenameFile, NewNameFile)
                        UpdtaeTabControlFile(Path, NewNameFile) 'Actualiza las pestaña.
                    Else
                        My.Computer.FileSystem.RenameFile(PathRenameFile, NewNameFile & ExtencionSave)
                        UpdtaeTabControlFile(Path, NewNameFile & ExtencionSave) 'Actualiza las pestaña.
                    End If
                End If

                UpdateProject_Sub()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Function

    'Elimina el iten de la pestaña si esta abierta.
    Public Sub DeletItemTab(ByVal PathAndTextItem As String)
        Dim i As Integer = 0
        Dim ret As Long
        With TC_Editor
            For i = 0 To .TabPages.Count - 1
                If .TabPages(i).Name = PathAndTextItem Then
                    .TabPages.Remove(.TabPages(i))
                    i = i - 1
                    ret = ret + 1
                End If
                If i = .TabPages.Count - 1 Then
                    Exit For
                End If
            Next
        End With
    End Sub

    'Recorta la ruta del archivo, para poder renombrarlo.
    Private Function CutNamePath(ByVal PathFile As String, ByVal NewName As String) As String
        Dim t1 As Integer = Len(My.Computer.FileSystem.GetName(PathFile))
        Dim t2 = Mid(PathFile, 1, Len(PathFile) - t1)

        Return t2 & NewName
    End Function

    'Reasigna las propiedades de la pestaña.
    Private Sub UpdtaeTabControlFile(ByVal Path As String, ByVal NewName As String)
        Dim NewPath As String = CutNamePath(Path, NewName)
        For i As Integer = 0 To TC_Editor.TabCount - 1
            If TC_Editor.TabPages(i).Name = Path Then
                TC_Editor.TabPages(i).Name = NewPath 'Nueva ruta de la pestaña.
                TC_Editor.TabPages(i).Text = NewName 'Nuevo nombre de la pestaña.
                Exit For
            End If
        Next
    End Sub

    'Guarar las configuraciones de los folden.
    Private Sub SaveConfigFileFolder()
        Dim XMLFolderSetting As New FileFolderCreator

        Dim NameDirectory As String = My.Computer.FileSystem.GetName(TSSL_Path.Text)
        Dim Result As String = CutNamePath(TSSL_Path.Text, "")

        If My.Computer.FileSystem.DirectoryExists(Result & "SettingsProjects") = True Then
            XMLFolderSetting.SaveXmlFolderSetting(Result & "SettingsProjects" & "\settingFolder.xml")
        Else
            Try
                My.Computer.FileSystem.CreateDirectory(Result & "FolderConf")
                SaveConfigFileFolder()
            Catch ex As Exception
            End Try
        End If
    End Sub

    'Carga las configuraciones de los folden.
    Private Sub LoadConfigFileFolder()
        Dim XMLFolderSetting As New FileFolderCreator

        Dim NameDirectory As String = My.Computer.FileSystem.GetName(TSSL_Path.Text)
        Dim Result As String = CutNamePath(TSSL_Path.Text, "")

        If My.Computer.FileSystem.DirectoryExists(Result & "SettingsProjects") = True Then
            XMLFolderSetting.LoadXmlFolderSetting(Result & "SettingsProjects" & "\settingFolder.xml")
        End If
    End Sub

    'Function para exportar el proyecto a zip.
    Private Sub ExportProjectZip()
        Try
            Dim path1 As String = UpdateProject1.CutPathIconCopy(Path_Project)
            Dim path2 As Integer = Len(path1)
            Dim namePathLen As Integer = Len(My.Computer.FileSystem.GetName(Path_Project))
            Dim clearPath As String = Mid(path1, 1, path2 - 1)

            Using zip As ZipFile = New ZipFile
                zip.AddDirectory(clearPath, "")
                Console1.C_Text.Text = "> Comprimiendo el archivo ..."

                zip.Save(path1 & "Backup.zip")
            End Using

            Console1.C_Text.Text += " Ok"
            Console1.C_Text.Text += vbNewLine & "> Operaion finalizada."
        Catch ex As Exception
        End Try
    End Sub

    'Carga el estado del formulario principal.
    Private Sub StateLoadMainForm()
        If My.Settings.My_StateMainForm = "Maximized" Then
            Me.WindowState = FormWindowState.Maximized
        ElseIf My.Settings.My_StateMainForm = "Normal" Then
            Me.WindowState = FormWindowState.Normal
        End If
        '
        If My.Settings.My_ThemeSelect = 0 Then
            SyntaxisStyle1.SetTheme = SyntaxisStyle.SyntaxisTheme.Default
            SyntaxisStyle1.ApplyTheme()
        ElseIf My.Settings.My_ThemeSelect = 1 Then
            SyntaxisStyle1.SetTheme = SyntaxisStyle.SyntaxisTheme.Black
            SyntaxisStyle1.ApplyTheme()
        Else
            '
        End If
    End Sub

    'Guarda el estado del formulario principal.
    Private Sub StateSaveMainForm()
        If Me.WindowState = FormWindowState.Maximized Then
            My.Settings.My_StateMainForm = "Maximized"
            My.Settings.Save()
        ElseIf Me.WindowState = FormWindowState.Normal Then
            My.Settings.My_StateMainForm = "Normal"
            My.Settings.Save()
        End If
        '
        My.Settings.My_ThemeSelect = SyntaxisStyle1.SetTheme
        My.Settings.Save()
    End Sub
    '=============================================================================================================

    Private Sub TSMI_StartDebugging_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_StartDebugging.Click
        SaveAllFile()
        StartEjecution()
    End Sub

    Private Sub TSB_StartDebugging_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_StartDebugging.Click
        SaveAllFile()
        StartEjecution()
    End Sub

    Private Sub TSMI_StopDebugging_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_StopDebugging.Click
        StopEjecution()
    End Sub

    Private Sub TSB_StopDebugging_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_StopDebugging.Click
        StopEjecution()
    End Sub

    Private Sub TSMI_NewProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_NewProject.Click
        NewProject.ShowDialog()
    End Sub

    Private Sub CMS_TabMenu_CloseTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_TabMenu_CloseTab.Click
        CloseSelectedTab()
    End Sub

    Private Sub CMS_TabMenu_CloseAllTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_TabMenu_CloseAllTab.Click
        CloseTabAll()
    End Sub

    Private Sub CMS_TabMenu_CloseAllTabOrSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMS_TabMenu_CloseAllTabOrSelected.Click
        CloseAllTabOrSelected()
    End Sub

    Private Sub TSMI_CloseAllTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_CloseAllTab.Click
        CloseTabAll()
    End Sub

    Private Sub TSB_ShowFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_ShowFiles.Click
        If UploadingFilesAndFolder.Show_Hide = False Then
            UploadingFilesAndFolder.Show_Hide = True
            TSB_ShowFiles.Checked = True
        Else
            UploadingFilesAndFolder.Show_Hide = False
            TSB_ShowFiles.Checked = False
        End If
        UpdateProject_Sub()
    End Sub

    Private Sub TSMI_RefreshProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_RefreshProject.Click
        UpdateProject_Sub()
    End Sub

    Private Sub TSB_NewProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_NewProject.Click
        NewProject.ShowDialog()
    End Sub

    Private Sub TSB_Help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_Help.Click
        MsgBox("Si necesita ayuda visite el sitio oficial de love2d (www.love2d.org).", vbInformation)
        'ExportProjectZip()
    End Sub

    Private Sub NuevaCarpetaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_NewFolder.Click
        NewFolder()
    End Sub

    Private Sub NuevoArchivoLuaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_NewFileLua.Click
        NewFileLua()
    End Sub

    Private Sub NuevoArchivoTxtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_NewFileTxt.Click
        NewFileTxt()
    End Sub

    Private Sub TSMI_NewImage_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_NewImage.Click
        NewImageFile()
    End Sub

    Private Sub TSMI_ImportsResoucer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_ImportsResoucer.Click
        ImportSource()
    End Sub

    Private Sub TSMI_ViewExplored_Tv_Eplored_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_ViewExplored_Tv_Eplored.Click
        ViewExploredSelected()
    End Sub

    Private Sub TSMI_EditImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_EditImage.Click
        EditImage(TV_Explored.SelectedNode.Name)
    End Sub

    Private Sub TSMI_PropertyProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_PropertyProject.Click
        PropertiesForm.ShowDialog()
    End Sub

    'Corta al estilo explored.
    Private Sub TSMI_Cut_Tv_Explored_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Cut_Tv_Explored.Click
        Try
            KeyCut = True
            PathCopy = TV_Explored.SelectedNode.Name
        Catch ex As Exception

        End Try
    End Sub

    'Copiar alestilo explored.
    Private Sub TSMI_Copy_Tv_Explored_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Copy_Tv_Explored.Click
        Try
            KeyCut = False
            PathCopy = TV_Explored.SelectedNode.Name
        Catch ex As Exception

        End Try
    End Sub

    'Pegar al estilo explored.
    Private Sub TSMI_Paste_Tv_Explored_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Paste_Tv_Explored.Click
        Dim nameFile As String = My.Computer.FileSystem.GetName(PathCopy)
        Dim FileExtencion As New FileInfo(nameFile)

        Try
            If KeyCut = True Then
                If InStr(FileExtencion.Extension, ".") Then
                    IO.File.Move(PathCopy, TV_Explored.SelectedNode.Name & "\" & nameFile)
                Else
                    IO.Directory.Move(PathCopy, TV_Explored.SelectedNode.Name & "\" & nameFile)
                End If
            Else
                If InStr(FileExtencion.Extension, ".") Then
                    IO.File.Copy(PathCopy, TV_Explored.SelectedNode.Name & "\" & nameFile)
                Else
                    My.Computer.FileSystem.CopyDirectory(PathCopy, TV_Explored.SelectedNode.Name & "\" & nameFile)
                End If
            End If

        Catch ex As Exception

            Dim text1 As String = "ya hay un archivo o carpeta con este nombre, ¿Decea sustituirlo?"
            Dim title1 As String = "VisualLoveProject 2.0 Ultimate"
            Dim MsgStyle As MsgBoxStyle = MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo
            Dim msg = MsgBox(text1, MsgStyle, title1)

            If msg = MsgBoxResult.Yes Then
                Try
                    If KeyCut = True Then
                        If InStr(FileExtencion.Extension, ".") Then
                            My.Computer.FileSystem.MoveFile(PathCopy, TV_Explored.SelectedNode.Name & "\" & nameFile, True)
                        Else
                            My.Computer.FileSystem.MoveDirectory(PathCopy, TV_Explored.SelectedNode.Name & "\" & nameFile, True)
                        End If
                    Else
                        If InStr(FileExtencion.Extension, ".") Then
                            My.Computer.FileSystem.CopyFile(PathCopy, TV_Explored.SelectedNode.Name & "\" & nameFile, True)
                        Else
                            My.Computer.FileSystem.CopyDirectory(PathCopy, TV_Explored.SelectedNode.Name & "\" & nameFile, True)
                        End If
                    End If
                Catch ex1 As Exception
                    MsgBox("Nose puede mover un archivo o carpeta a su propio lugar de origen.", MsgBoxStyle.Critical)
                    Exit Sub
                End Try

            ElseIf msg = MsgBoxResult.No Then
                Exit Sub
            End If

        End Try

        UpdateProject_Sub()
    End Sub

    'Borra al estilo explored.
    Private Sub TSMI_Delete_Tv_Explored_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Delete_Tv_Explored.Click
        Dim NameFile1 As String = My.Computer.FileSystem.GetName(TV_Explored.SelectedNode.Name)
        Dim PathFile As String = TV_Explored.SelectedNode.Name
        Dim FileExtencion As New FileInfo(PathFile)

        Dim text1 As String = "¿En realidad decea eliminar """ & NameFile1 & """?"
        Dim title1 As String = "VisualLoveProject 2.0 Ultimate"
        Dim MsgStyle As MsgBoxStyle = MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo
        Dim msg = MsgBox(text1, MsgStyle, title1)

        If msg = MsgBoxResult.Yes Then
            Try
                If FileExtencion.Attributes = FileAttributes.Archive Then
                    DeletItemTab(PathFile)
                    'IO.File.Delete(PathFile)
                    My.Computer.FileSystem.DeleteFile(PathFile)
                Else
                    IO.Directory.Delete(PathFile, True)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, vbExclamation)
            End Try

            UpdateProject_Sub()
        ElseIf msg = MsgBoxResult.No Then
            Exit Sub
        End If
    End Sub

    'Renombrar al estilo explored.
    Private Sub TSMI_Rename_Tv_Explored_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Rename_Tv_Explored.Click
        RenameFileExplored(TV_Explored.SelectedNode.Name)
    End Sub

    '-----------------------Noce utiliza para nada.---------------------------------------------------
    Dim KeyProject As Boolean = False
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        'If KeyProject = False Then
        '    'TC_Editor.Visible = False
        '    'Console1.Visible = False
        '    GB_Explored.Visible = False

        '    KeyProject = True
        'Else
        '    'TC_Editor.Visible = True
        '    'Console1.Visible = True
        '    GB_Explored.Visible = True

        '    KeyProject = False
        'End If

        'LoadConfigFileFolder()

        'ControllerStateProject1.SaveStateProject()
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        'ControllerStateProject1.OpenStateProject()
    End Sub

    'saver si un programa a sido ejecutado como administrador---------------
    Private Function TestAdmin() As Boolean
        My.User.InitializeWithWindowsUser()
        Return My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator)
    End Function

    'Asocia la extencion .vlp al programa.
    Private Sub TSMI_AssosiateExtencion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_AssosiateExtencion.Click
        If TestAdmin() = True Then
            Try
                Dim obj As New AddExtencion
                '
                ' ruta del ejecutable
                obj.FileEjecutable = Application.StartupPath & "\VisualLoveProject 2.0 Ultimate.exe"
                ' ruta del icono
                obj.IconFile = Application.StartupPath & "\Icon\My.ico"
                ' asociar la extension
                obj.AddExtencion()
                '
                MsgBox("Extencion asociada con  exito.", vbInformation)
            Catch ex As Exception
            End Try
        Else
            MsgBox("Este proceso necesita permiso de administrador.", MsgBoxStyle.Critical)
        End If
    End Sub

    'Asocia un comadon en el menu contextual de windows para abrir los archivos .vlp.
    Private Sub TSMI_AttachContextMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_AttachContextMenu.Click
        If TestAdmin() = True Then
            Try
                Dim obj As New AddExtencion
                '
                ' ruta del ejecutable
                obj.FileEjecutable = Application.StartupPath & "\VisualLoveProject 2.0 Ultimate.exe"
                ' ruta del icono
                obj.IconFile = Application.StartupPath & "\Icon\My.ico"
                ' asociar la extension
                obj.AddContextMenuItems()
                '
                MsgBox("Extencion asociada con  exito.", vbInformation)
            Catch ex As Exception
            End Try
        Else
            MsgBox("Este proceso necesita permiso de administrador.", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub TSMI_Options_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Options.Click
        OptionsForm.ShowDialog()
    End Sub

    Private Sub TSB_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_Close.Click
        ResetProjectClear()
        ResetProjectClearAll()
    End Sub

    Private Sub TSMI_AboutMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_AboutMe.Click
        MsgBox("Esta aplicacion fue creada por luislasonbra", MsgBoxStyle.Information)
    End Sub

    Private Sub TSMI_DateOfCreate_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_DateOfCreate.Click
        MsgBox("Esta aplicacion fue creada el (""20/03/12"")", MsgBoxStyle.Information)
    End Sub

    Private Sub TSMI_UltimateRevision_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_UltimateRevision.Click
        MsgBox("2.0.1.44", MsgBoxStyle.Information)
    End Sub

    Private Sub TSMI_VersionApplication_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_VersionApplication.Click
        MsgBox("Version 2.0 Ultimate", MsgBoxStyle.Information)
    End Sub

    'Relog para el auto guardado.
    Private Sub TM_AutoSave_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TM_AutoSave.Tick
        'If AutoSaveKey = True Then
        '    AutoSave()
        'End If
    End Sub

    Private Sub TSB_Property_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_Property.Click
        Try
            PropertyFileForm.FilePath = TV_Explored.SelectedNode.Name
            PropertyFileForm.ShowDialog(Me)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TSMI_Property_Tv_Explored_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Property_Tv_Explored.Click
        Try
            PropertyFileForm.FilePath = TV_Explored.SelectedNode.Name
            PropertyFileForm.ShowDialog(Me)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub VerColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerColorToolStripMenuItem.Click
        Dim fctb = CType(TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
        ViewColorSelection(fctb.SelectedText)
    End Sub

    Private Sub TSMI_Color_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_Color.Click
        ColorCustomForm1.Show(Me)
    End Sub

    'Mover de aqui luego.
    Private Sub TSMI_Package_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_Package.Click
        LanguajeManajerForm1.ShowDialog(Me)
    End Sub

End Class