<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm1))
        Me.TS_Tool = New System.Windows.Forms.ToolStrip()
        Me.TSB_NewProject = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Separator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSB_OpenProject = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Save = New System.Windows.Forms.ToolStripButton()
        Me.TSB_SaveAll = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Separator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSB_Cut = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Copy = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Paste = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Separator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSB_Find = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSB_Comment = New System.Windows.Forms.ToolStripButton()
        Me.TSB_DesComment = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Separator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSB_AddBookMark = New System.Windows.Forms.ToolStripButton()
        Me.TSB_RemoveBookMark = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Separator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSB_ZoomIn = New System.Windows.Forms.ToolStripButton()
        Me.TSB_ZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.TSB_NormalZoom = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Separator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSB_Undo = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Redo = New System.Windows.Forms.ToolStripButton()
        Me.TSB_BookMark = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TSB_Separator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSB_StartDebugging = New System.Windows.Forms.ToolStripButton()
        Me.TSB_StopDebugging = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSB_Help = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Close = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.TSS_Path = New System.Windows.Forms.StatusStrip()
        Me.TSSL_Text = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSL_Path = New System.Windows.Forms.ToolStripStatusLabel()
        Me.IL_Explored = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GB_Explored = New System.Windows.Forms.GroupBox()
        Me.TV_Explored = New System.Windows.Forms.TreeView()
        Me.CMS_ExploredMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSMI_New = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_NewFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_NewFileLua = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_NewFileTxt = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_NewImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_ImportsResoucer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_EditImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Cut_Tv_Explored = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Copy_Tv_Explored = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Paste_Tv_Explored = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_Rename_Tv_Explored = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Delete_Tv_Explored = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_ViewExplored_Tv_Eplored = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_Property_Tv_Explored = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TS_Explored = New System.Windows.Forms.ToolStrip()
        Me.TSB_Property = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Separator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSB_ShowFiles = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Refresh = New System.Windows.Forms.ToolStripButton()
        Me.SP_Separador1 = New System.Windows.Forms.Splitter()
        Me.CM_Edit = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMS_Cut = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_Copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_Paste = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CMS_GoToLine = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_Find = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_Replace = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CMS_SelectedAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TM_ControlUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.CMS_TabMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMS_TabMenu_CloseTab = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_TabMenu_CloseAllTab = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_TabMenu_CloseAllTabOrSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.BW_CompileRun = New System.ComponentModel.BackgroundWorker()
        Me.Timer_Process = New System.Windows.Forms.Timer(Me.components)
        Me.BW_RuningProject = New System.ComponentModel.BackgroundWorker()
        Me.TM_AutoSave = New System.Windows.Forms.Timer(Me.components)
        Me.MS_Menu = New System.Windows.Forms.MenuStrip()
        Me.TSMI_File = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_NewProject = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_OpenProject = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_CloseProject = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_CloseTab = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_CloseAllTab = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_SaveAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_RecentProject = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Undo = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Redo = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_Cut = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Paste = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_GotoIn = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Find = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Replace = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_SelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Project = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_ViewExplored = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_RefreshProject = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_PropertyProject = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Generate = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_GenerateLove = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_GenerateExe = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Debug = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_StartDebugging = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_StopDebugging = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Tool = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Color = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_AssosiateExtencion = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_AttachContextMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Options = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Wiki = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Example = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_HomePage = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Tutorials = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Function = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_AboutMe = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_DateOfCreate = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_UltimateRevision = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_VersionApplication = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Languaje = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Package = New System.Windows.Forms.ToolStripMenuItem()
        Me.IL_AutoCompleted = New System.Windows.Forms.ImageList(Me.components)
        Me.TC_Editor = New VisualLoveProject_2._0_Ultimate.UserTabControl()
        Me.Console1 = New VisualLoveProject_2._0_Ultimate.Console()
        Me.TS_Tool.SuspendLayout()
        Me.TSS_Path.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GB_Explored.SuspendLayout()
        Me.CMS_ExploredMenu.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TS_Explored.SuspendLayout()
        Me.CM_Edit.SuspendLayout()
        Me.CMS_TabMenu.SuspendLayout()
        Me.MS_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TS_Tool
        '
        Me.TS_Tool.BackColor = System.Drawing.Color.FromArgb(CType(CType(186, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.TS_Tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSB_NewProject, Me.TSB_Separator1, Me.TSB_OpenProject, Me.TSB_Save, Me.TSB_SaveAll, Me.TSB_Separator2, Me.TSB_Cut, Me.TSB_Copy, Me.TSB_Paste, Me.TSB_Separator3, Me.TSB_Find, Me.ToolStripSeparator2, Me.TSB_Comment, Me.TSB_DesComment, Me.TSB_Separator4, Me.TSB_AddBookMark, Me.TSB_RemoveBookMark, Me.TSB_Separator5, Me.TSB_ZoomIn, Me.TSB_ZoomOut, Me.TSB_NormalZoom, Me.TSB_Separator6, Me.TSB_Undo, Me.TSB_Redo, Me.TSB_BookMark, Me.TSB_Separator7, Me.TSB_StartDebugging, Me.TSB_StopDebugging, Me.ToolStripSeparator10, Me.TSB_Help, Me.TSB_Close, Me.ToolStripButton2, Me.ToolStripButton1})
        Me.TS_Tool.Location = New System.Drawing.Point(0, 0)
        Me.TS_Tool.Name = "TS_Tool"
        Me.TS_Tool.Size = New System.Drawing.Size(1019, 25)
        Me.TS_Tool.TabIndex = 4
        Me.TS_Tool.Text = "ToolStrip1"
        '
        'TSB_NewProject
        '
        Me.TSB_NewProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_NewProject.Image = CType(resources.GetObject("TSB_NewProject.Image"), System.Drawing.Image)
        Me.TSB_NewProject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_NewProject.Name = "TSB_NewProject"
        Me.TSB_NewProject.Size = New System.Drawing.Size(23, 22)
        Me.TSB_NewProject.Text = "Nuevo Proyecto"
        '
        'TSB_Separator1
        '
        Me.TSB_Separator1.Name = "TSB_Separator1"
        Me.TSB_Separator1.Size = New System.Drawing.Size(6, 25)
        '
        'TSB_OpenProject
        '
        Me.TSB_OpenProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_OpenProject.Image = CType(resources.GetObject("TSB_OpenProject.Image"), System.Drawing.Image)
        Me.TSB_OpenProject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_OpenProject.Name = "TSB_OpenProject"
        Me.TSB_OpenProject.Size = New System.Drawing.Size(23, 22)
        Me.TSB_OpenProject.Text = "Abrir Proyecto"
        '
        'TSB_Save
        '
        Me.TSB_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Save.Enabled = False
        Me.TSB_Save.Image = CType(resources.GetObject("TSB_Save.Image"), System.Drawing.Image)
        Me.TSB_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Save.Name = "TSB_Save"
        Me.TSB_Save.Size = New System.Drawing.Size(23, 22)
        Me.TSB_Save.Text = "Guardar"
        '
        'TSB_SaveAll
        '
        Me.TSB_SaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_SaveAll.Enabled = False
        Me.TSB_SaveAll.Image = CType(resources.GetObject("TSB_SaveAll.Image"), System.Drawing.Image)
        Me.TSB_SaveAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_SaveAll.Name = "TSB_SaveAll"
        Me.TSB_SaveAll.Size = New System.Drawing.Size(23, 22)
        Me.TSB_SaveAll.Text = "Guarda todo"
        '
        'TSB_Separator2
        '
        Me.TSB_Separator2.Name = "TSB_Separator2"
        Me.TSB_Separator2.Size = New System.Drawing.Size(6, 25)
        '
        'TSB_Cut
        '
        Me.TSB_Cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Cut.Enabled = False
        Me.TSB_Cut.Image = CType(resources.GetObject("TSB_Cut.Image"), System.Drawing.Image)
        Me.TSB_Cut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Cut.Name = "TSB_Cut"
        Me.TSB_Cut.Size = New System.Drawing.Size(23, 22)
        Me.TSB_Cut.Text = "Cortar"
        '
        'TSB_Copy
        '
        Me.TSB_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Copy.Enabled = False
        Me.TSB_Copy.Image = CType(resources.GetObject("TSB_Copy.Image"), System.Drawing.Image)
        Me.TSB_Copy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Copy.Name = "TSB_Copy"
        Me.TSB_Copy.Size = New System.Drawing.Size(23, 22)
        Me.TSB_Copy.Text = "Copiar"
        '
        'TSB_Paste
        '
        Me.TSB_Paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Paste.Enabled = False
        Me.TSB_Paste.Image = CType(resources.GetObject("TSB_Paste.Image"), System.Drawing.Image)
        Me.TSB_Paste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Paste.Name = "TSB_Paste"
        Me.TSB_Paste.Size = New System.Drawing.Size(23, 22)
        Me.TSB_Paste.Text = "Pegar"
        '
        'TSB_Separator3
        '
        Me.TSB_Separator3.Name = "TSB_Separator3"
        Me.TSB_Separator3.Size = New System.Drawing.Size(6, 25)
        '
        'TSB_Find
        '
        Me.TSB_Find.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Find.Enabled = False
        Me.TSB_Find.Image = CType(resources.GetObject("TSB_Find.Image"), System.Drawing.Image)
        Me.TSB_Find.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Find.Name = "TSB_Find"
        Me.TSB_Find.Size = New System.Drawing.Size(23, 22)
        Me.TSB_Find.Text = "Buscar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TSB_Comment
        '
        Me.TSB_Comment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Comment.Enabled = False
        Me.TSB_Comment.Image = CType(resources.GetObject("TSB_Comment.Image"), System.Drawing.Image)
        Me.TSB_Comment.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Comment.Name = "TSB_Comment"
        Me.TSB_Comment.Size = New System.Drawing.Size(23, 22)
        Me.TSB_Comment.Text = "Comentar linea"
        '
        'TSB_DesComment
        '
        Me.TSB_DesComment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_DesComment.Enabled = False
        Me.TSB_DesComment.Image = CType(resources.GetObject("TSB_DesComment.Image"), System.Drawing.Image)
        Me.TSB_DesComment.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_DesComment.Name = "TSB_DesComment"
        Me.TSB_DesComment.Size = New System.Drawing.Size(23, 22)
        Me.TSB_DesComment.Text = "Decomentar linea"
        '
        'TSB_Separator4
        '
        Me.TSB_Separator4.Name = "TSB_Separator4"
        Me.TSB_Separator4.Size = New System.Drawing.Size(6, 25)
        '
        'TSB_AddBookMark
        '
        Me.TSB_AddBookMark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_AddBookMark.Enabled = False
        Me.TSB_AddBookMark.Image = CType(resources.GetObject("TSB_AddBookMark.Image"), System.Drawing.Image)
        Me.TSB_AddBookMark.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_AddBookMark.Name = "TSB_AddBookMark"
        Me.TSB_AddBookMark.Size = New System.Drawing.Size(23, 22)
        Me.TSB_AddBookMark.Text = "Añadir marcador"
        '
        'TSB_RemoveBookMark
        '
        Me.TSB_RemoveBookMark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_RemoveBookMark.Enabled = False
        Me.TSB_RemoveBookMark.Image = CType(resources.GetObject("TSB_RemoveBookMark.Image"), System.Drawing.Image)
        Me.TSB_RemoveBookMark.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_RemoveBookMark.Name = "TSB_RemoveBookMark"
        Me.TSB_RemoveBookMark.Size = New System.Drawing.Size(23, 22)
        Me.TSB_RemoveBookMark.Text = "Quitar marcador"
        '
        'TSB_Separator5
        '
        Me.TSB_Separator5.Name = "TSB_Separator5"
        Me.TSB_Separator5.Size = New System.Drawing.Size(6, 25)
        '
        'TSB_ZoomIn
        '
        Me.TSB_ZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_ZoomIn.Enabled = False
        Me.TSB_ZoomIn.Image = CType(resources.GetObject("TSB_ZoomIn.Image"), System.Drawing.Image)
        Me.TSB_ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_ZoomIn.Name = "TSB_ZoomIn"
        Me.TSB_ZoomIn.Size = New System.Drawing.Size(23, 22)
        Me.TSB_ZoomIn.Text = "Agregar zoom"
        Me.TSB_ZoomIn.Visible = False
        '
        'TSB_ZoomOut
        '
        Me.TSB_ZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_ZoomOut.Enabled = False
        Me.TSB_ZoomOut.Image = CType(resources.GetObject("TSB_ZoomOut.Image"), System.Drawing.Image)
        Me.TSB_ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_ZoomOut.Name = "TSB_ZoomOut"
        Me.TSB_ZoomOut.Size = New System.Drawing.Size(23, 22)
        Me.TSB_ZoomOut.Text = "Quitar zoom"
        Me.TSB_ZoomOut.Visible = False
        '
        'TSB_NormalZoom
        '
        Me.TSB_NormalZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_NormalZoom.Enabled = False
        Me.TSB_NormalZoom.Image = CType(resources.GetObject("TSB_NormalZoom.Image"), System.Drawing.Image)
        Me.TSB_NormalZoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_NormalZoom.Name = "TSB_NormalZoom"
        Me.TSB_NormalZoom.Size = New System.Drawing.Size(23, 22)
        Me.TSB_NormalZoom.Text = "Zoom normal"
        '
        'TSB_Separator6
        '
        Me.TSB_Separator6.Name = "TSB_Separator6"
        Me.TSB_Separator6.Size = New System.Drawing.Size(6, 25)
        '
        'TSB_Undo
        '
        Me.TSB_Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Undo.Enabled = False
        Me.TSB_Undo.Image = CType(resources.GetObject("TSB_Undo.Image"), System.Drawing.Image)
        Me.TSB_Undo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Undo.Name = "TSB_Undo"
        Me.TSB_Undo.Size = New System.Drawing.Size(23, 22)
        Me.TSB_Undo.Text = "Undo"
        '
        'TSB_Redo
        '
        Me.TSB_Redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Redo.Enabled = False
        Me.TSB_Redo.Image = CType(resources.GetObject("TSB_Redo.Image"), System.Drawing.Image)
        Me.TSB_Redo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Redo.Name = "TSB_Redo"
        Me.TSB_Redo.Size = New System.Drawing.Size(23, 22)
        Me.TSB_Redo.Text = "Redo"
        '
        'TSB_BookMark
        '
        Me.TSB_BookMark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_BookMark.Enabled = False
        Me.TSB_BookMark.Image = CType(resources.GetObject("TSB_BookMark.Image"), System.Drawing.Image)
        Me.TSB_BookMark.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_BookMark.Name = "TSB_BookMark"
        Me.TSB_BookMark.Size = New System.Drawing.Size(29, 22)
        Me.TSB_BookMark.Text = "Libro de marcadores"
        '
        'TSB_Separator7
        '
        Me.TSB_Separator7.Name = "TSB_Separator7"
        Me.TSB_Separator7.Size = New System.Drawing.Size(6, 25)
        '
        'TSB_StartDebugging
        '
        Me.TSB_StartDebugging.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_StartDebugging.Enabled = False
        Me.TSB_StartDebugging.Image = CType(resources.GetObject("TSB_StartDebugging.Image"), System.Drawing.Image)
        Me.TSB_StartDebugging.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_StartDebugging.Name = "TSB_StartDebugging"
        Me.TSB_StartDebugging.Size = New System.Drawing.Size(23, 22)
        Me.TSB_StartDebugging.Text = "Iniciar Depuracion"
        '
        'TSB_StopDebugging
        '
        Me.TSB_StopDebugging.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_StopDebugging.Enabled = False
        Me.TSB_StopDebugging.Image = CType(resources.GetObject("TSB_StopDebugging.Image"), System.Drawing.Image)
        Me.TSB_StopDebugging.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_StopDebugging.Name = "TSB_StopDebugging"
        Me.TSB_StopDebugging.Size = New System.Drawing.Size(23, 22)
        Me.TSB_StopDebugging.Text = "Detener Depuracion"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'TSB_Help
        '
        Me.TSB_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Help.Image = CType(resources.GetObject("TSB_Help.Image"), System.Drawing.Image)
        Me.TSB_Help.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Help.Name = "TSB_Help"
        Me.TSB_Help.Size = New System.Drawing.Size(23, 22)
        '
        'TSB_Close
        '
        Me.TSB_Close.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TSB_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSB_Close.Enabled = False
        Me.TSB_Close.Image = CType(resources.GetObject("TSB_Close.Image"), System.Drawing.Image)
        Me.TSB_Close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Close.Name = "TSB_Close"
        Me.TSB_Close.Size = New System.Drawing.Size(23, 22)
        Me.TSB_Close.Text = "X"
        Me.TSB_Close.ToolTipText = "Cerrar el proyecto"
        Me.TSB_Close.Visible = False
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(34, 22)
        Me.ToolStripButton2.Text = "Load"
        Me.ToolStripButton2.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripButton1.Text = "Save"
        Me.ToolStripButton1.Visible = False
        '
        'TSS_Path
        '
        Me.TSS_Path.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.TSS_Path.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSL_Text, Me.TSSL_Path})
        Me.TSS_Path.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.TSS_Path.Location = New System.Drawing.Point(0, 587)
        Me.TSS_Path.Name = "TSS_Path"
        Me.TSS_Path.Size = New System.Drawing.Size(1019, 22)
        Me.TSS_Path.TabIndex = 5
        Me.TSS_Path.Text = "StatusStrip1"
        '
        'TSSL_Text
        '
        Me.TSSL_Text.ForeColor = System.Drawing.Color.White
        Me.TSSL_Text.Name = "TSSL_Text"
        Me.TSSL_Text.Size = New System.Drawing.Size(34, 17)
        Me.TSSL_Text.Text = "Ruta:"
        '
        'TSSL_Path
        '
        Me.TSSL_Path.ForeColor = System.Drawing.Color.White
        Me.TSSL_Path.Name = "TSSL_Path"
        Me.TSSL_Path.Size = New System.Drawing.Size(12, 17)
        Me.TSSL_Path.Text = "?"
        '
        'IL_Explored
        '
        Me.IL_Explored.ImageStream = CType(resources.GetObject("IL_Explored.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.IL_Explored.TransparentColor = System.Drawing.Color.Transparent
        Me.IL_Explored.Images.SetKeyName(0, "FolderIco.png")
        Me.IL_Explored.Images.SetKeyName(1, "LuaFile.png")
        Me.IL_Explored.Images.SetKeyName(2, "lua.png")
        Me.IL_Explored.Images.SetKeyName(3, "ImageIco.png")
        Me.IL_Explored.Images.SetKeyName(4, "VSProject_genericproject.ico")
        Me.IL_Explored.Images.SetKeyName(5, "1346073692_music.png")
        Me.IL_Explored.Images.SetKeyName(6, "1346073926_font.png")
        Me.IL_Explored.Images.SetKeyName(7, "saveHS.png")
        Me.IL_Explored.Images.SetKeyName(8, "FolderOpenIco.png")
        Me.IL_Explored.Images.SetKeyName(9, "Propiedades.png")
        Me.IL_Explored.Images.SetKeyName(10, "FolderClose - Hide.bmp")
        Me.IL_Explored.Images.SetKeyName(11, "LuaFile - Hide.png")
        Me.IL_Explored.Images.SetKeyName(12, "FontIco - Hide.png")
        Me.IL_Explored.Images.SetKeyName(13, "SoundIco - Hide.png")
        Me.IL_Explored.Images.SetKeyName(14, "FoldrOpen - Hidden.bmp")
        Me.IL_Explored.Images.SetKeyName(15, "ImageIco - Hide.png")
        Me.IL_Explored.Images.SetKeyName(16, "Sin título.png")
        Me.IL_Explored.Images.SetKeyName(17, "TxtIco - Hide.png")
        Me.IL_Explored.Images.SetKeyName(18, "unknown.png")
        Me.IL_Explored.Images.SetKeyName(19, "UcknawIco - Hide.png")
        Me.IL_Explored.Images.SetKeyName(20, "PSD_File.png")
        Me.IL_Explored.Images.SetKeyName(21, "PSD_File - Hide.png")
        Me.IL_Explored.Images.SetKeyName(22, "My.ico")
        Me.IL_Explored.Images.SetKeyName(23, "Vlp File.png")
        Me.IL_Explored.Images.SetKeyName(24, "VLP_File.ico")
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(186, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.Panel1.Controls.Add(Me.TS_Tool)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1019, 26)
        Me.Panel1.TabIndex = 6
        '
        'GB_Explored
        '
        Me.GB_Explored.Controls.Add(Me.TV_Explored)
        Me.GB_Explored.Controls.Add(Me.Panel2)
        Me.GB_Explored.Cursor = System.Windows.Forms.Cursors.Default
        Me.GB_Explored.Dock = System.Windows.Forms.DockStyle.Right
        Me.GB_Explored.ForeColor = System.Drawing.Color.White
        Me.GB_Explored.Location = New System.Drawing.Point(761, 50)
        Me.GB_Explored.Name = "GB_Explored"
        Me.GB_Explored.Size = New System.Drawing.Size(258, 537)
        Me.GB_Explored.TabIndex = 7
        Me.GB_Explored.TabStop = False
        Me.GB_Explored.Text = "Explorador de soluciones"
        '
        'TV_Explored
        '
        Me.TV_Explored.ContextMenuStrip = Me.CMS_ExploredMenu
        Me.TV_Explored.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TV_Explored.FullRowSelect = True
        Me.TV_Explored.HideSelection = False
        Me.TV_Explored.ImageIndex = 0
        Me.TV_Explored.ImageList = Me.IL_Explored
        Me.TV_Explored.Location = New System.Drawing.Point(3, 41)
        Me.TV_Explored.Name = "TV_Explored"
        Me.TV_Explored.SelectedImageIndex = 0
        Me.TV_Explored.ShowLines = False
        Me.TV_Explored.Size = New System.Drawing.Size(252, 493)
        Me.TV_Explored.TabIndex = 2
        '
        'CMS_ExploredMenu
        '
        Me.CMS_ExploredMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_New, Me.TSMI_ImportsResoucer, Me.ToolStripMenuItem10, Me.TSMI_EditImage, Me.TSMI_Cut_Tv_Explored, Me.TSMI_Copy_Tv_Explored, Me.TSMI_Paste_Tv_Explored, Me.ToolStripMenuItem8, Me.TSMI_Rename_Tv_Explored, Me.TSMI_Delete_Tv_Explored, Me.ToolStripMenuItem12, Me.TSMI_ViewExplored_Tv_Eplored, Me.ToolStripMenuItem13, Me.TSMI_Property_Tv_Explored})
        Me.CMS_ExploredMenu.Name = "CMS_ExploredMenu"
        Me.CMS_ExploredMenu.Size = New System.Drawing.Size(202, 248)
        '
        'TSMI_New
        '
        Me.TSMI_New.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_NewFolder, Me.TSMI_NewFileLua, Me.TSMI_NewFileTxt, Me.TSMI_NewImage})
        Me.TSMI_New.Name = "TSMI_New"
        Me.TSMI_New.Size = New System.Drawing.Size(201, 22)
        Me.TSMI_New.Text = "Nuevo"
        '
        'TSMI_NewFolder
        '
        Me.TSMI_NewFolder.Image = CType(resources.GetObject("TSMI_NewFolder.Image"), System.Drawing.Image)
        Me.TSMI_NewFolder.Name = "TSMI_NewFolder"
        Me.TSMI_NewFolder.Size = New System.Drawing.Size(171, 22)
        Me.TSMI_NewFolder.Text = "Nueva carpeta"
        '
        'TSMI_NewFileLua
        '
        Me.TSMI_NewFileLua.Image = CType(resources.GetObject("TSMI_NewFileLua.Image"), System.Drawing.Image)
        Me.TSMI_NewFileLua.Name = "TSMI_NewFileLua"
        Me.TSMI_NewFileLua.Size = New System.Drawing.Size(171, 22)
        Me.TSMI_NewFileLua.Text = "Nuevo archivo lua"
        '
        'TSMI_NewFileTxt
        '
        Me.TSMI_NewFileTxt.Image = CType(resources.GetObject("TSMI_NewFileTxt.Image"), System.Drawing.Image)
        Me.TSMI_NewFileTxt.Name = "TSMI_NewFileTxt"
        Me.TSMI_NewFileTxt.Size = New System.Drawing.Size(171, 22)
        Me.TSMI_NewFileTxt.Text = "Nuevo archivo txt"
        '
        'TSMI_NewImage
        '
        Me.TSMI_NewImage.Image = CType(resources.GetObject("TSMI_NewImage.Image"), System.Drawing.Image)
        Me.TSMI_NewImage.Name = "TSMI_NewImage"
        Me.TSMI_NewImage.Size = New System.Drawing.Size(171, 22)
        Me.TSMI_NewImage.Text = "Nueva Imagen"
        '
        'TSMI_ImportsResoucer
        '
        Me.TSMI_ImportsResoucer.Name = "TSMI_ImportsResoucer"
        Me.TSMI_ImportsResoucer.Size = New System.Drawing.Size(201, 22)
        Me.TSMI_ImportsResoucer.Text = "Importar Recursos"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(198, 6)
        '
        'TSMI_EditImage
        '
        Me.TSMI_EditImage.Name = "TSMI_EditImage"
        Me.TSMI_EditImage.Size = New System.Drawing.Size(201, 22)
        Me.TSMI_EditImage.Text = "Editar imagen"
        '
        'TSMI_Cut_Tv_Explored
        '
        Me.TSMI_Cut_Tv_Explored.Image = CType(resources.GetObject("TSMI_Cut_Tv_Explored.Image"), System.Drawing.Image)
        Me.TSMI_Cut_Tv_Explored.Name = "TSMI_Cut_Tv_Explored"
        Me.TSMI_Cut_Tv_Explored.Size = New System.Drawing.Size(201, 22)
        Me.TSMI_Cut_Tv_Explored.Text = "Cortar"
        '
        'TSMI_Copy_Tv_Explored
        '
        Me.TSMI_Copy_Tv_Explored.Image = CType(resources.GetObject("TSMI_Copy_Tv_Explored.Image"), System.Drawing.Image)
        Me.TSMI_Copy_Tv_Explored.Name = "TSMI_Copy_Tv_Explored"
        Me.TSMI_Copy_Tv_Explored.Size = New System.Drawing.Size(201, 22)
        Me.TSMI_Copy_Tv_Explored.Text = "Copiar"
        '
        'TSMI_Paste_Tv_Explored
        '
        Me.TSMI_Paste_Tv_Explored.Image = CType(resources.GetObject("TSMI_Paste_Tv_Explored.Image"), System.Drawing.Image)
        Me.TSMI_Paste_Tv_Explored.Name = "TSMI_Paste_Tv_Explored"
        Me.TSMI_Paste_Tv_Explored.Size = New System.Drawing.Size(201, 22)
        Me.TSMI_Paste_Tv_Explored.Text = "Pegar"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(198, 6)
        '
        'TSMI_Rename_Tv_Explored
        '
        Me.TSMI_Rename_Tv_Explored.Name = "TSMI_Rename_Tv_Explored"
        Me.TSMI_Rename_Tv_Explored.Size = New System.Drawing.Size(201, 22)
        Me.TSMI_Rename_Tv_Explored.Text = "Cambiar nombre"
        '
        'TSMI_Delete_Tv_Explored
        '
        Me.TSMI_Delete_Tv_Explored.Image = CType(resources.GetObject("TSMI_Delete_Tv_Explored.Image"), System.Drawing.Image)
        Me.TSMI_Delete_Tv_Explored.Name = "TSMI_Delete_Tv_Explored"
        Me.TSMI_Delete_Tv_Explored.Size = New System.Drawing.Size(201, 22)
        Me.TSMI_Delete_Tv_Explored.Text = "Eliminar"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(198, 6)
        '
        'TSMI_ViewExplored_Tv_Eplored
        '
        Me.TSMI_ViewExplored_Tv_Eplored.Image = CType(resources.GetObject("TSMI_ViewExplored_Tv_Eplored.Image"), System.Drawing.Image)
        Me.TSMI_ViewExplored_Tv_Eplored.Name = "TSMI_ViewExplored_Tv_Eplored"
        Me.TSMI_ViewExplored_Tv_Eplored.Size = New System.Drawing.Size(201, 22)
        Me.TSMI_ViewExplored_Tv_Eplored.Text = "Mostrar en e Explorador"
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(198, 6)
        '
        'TSMI_Property_Tv_Explored
        '
        Me.TSMI_Property_Tv_Explored.Image = CType(resources.GetObject("TSMI_Property_Tv_Explored.Image"), System.Drawing.Image)
        Me.TSMI_Property_Tv_Explored.Name = "TSMI_Property_Tv_Explored"
        Me.TSMI_Property_Tv_Explored.Size = New System.Drawing.Size(201, 22)
        Me.TSMI_Property_Tv_Explored.Text = "Propiedades"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(186, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.Panel2.Controls.Add(Me.TS_Explored)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(252, 25)
        Me.Panel2.TabIndex = 1
        '
        'TS_Explored
        '
        Me.TS_Explored.BackColor = System.Drawing.Color.FromArgb(CType(CType(186, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.TS_Explored.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_Explored.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSB_Property, Me.TSB_Separator11, Me.TSB_ShowFiles, Me.TSB_Refresh})
        Me.TS_Explored.Location = New System.Drawing.Point(0, 0)
        Me.TS_Explored.Name = "TS_Explored"
        Me.TS_Explored.Size = New System.Drawing.Size(252, 25)
        Me.TS_Explored.TabIndex = 1
        Me.TS_Explored.Text = "ToolStrip2"
        '
        'TSB_Property
        '
        Me.TSB_Property.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Property.Enabled = False
        Me.TSB_Property.Image = CType(resources.GetObject("TSB_Property.Image"), System.Drawing.Image)
        Me.TSB_Property.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Property.Name = "TSB_Property"
        Me.TSB_Property.Size = New System.Drawing.Size(23, 22)
        Me.TSB_Property.Text = "Propiedades'"
        '
        'TSB_Separator11
        '
        Me.TSB_Separator11.Name = "TSB_Separator11"
        Me.TSB_Separator11.Size = New System.Drawing.Size(6, 25)
        '
        'TSB_ShowFiles
        '
        Me.TSB_ShowFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_ShowFiles.Enabled = False
        Me.TSB_ShowFiles.Image = CType(resources.GetObject("TSB_ShowFiles.Image"), System.Drawing.Image)
        Me.TSB_ShowFiles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_ShowFiles.Name = "TSB_ShowFiles"
        Me.TSB_ShowFiles.Size = New System.Drawing.Size(23, 22)
        Me.TSB_ShowFiles.Text = "Mostrar todos los archivos"
        '
        'TSB_Refresh
        '
        Me.TSB_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Refresh.Enabled = False
        Me.TSB_Refresh.Image = CType(resources.GetObject("TSB_Refresh.Image"), System.Drawing.Image)
        Me.TSB_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Refresh.Name = "TSB_Refresh"
        Me.TSB_Refresh.Size = New System.Drawing.Size(23, 22)
        Me.TSB_Refresh.Text = "Actualizar"
        '
        'SP_Separador1
        '
        Me.SP_Separador1.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.SP_Separador1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SP_Separador1.Location = New System.Drawing.Point(758, 50)
        Me.SP_Separador1.Name = "SP_Separador1"
        Me.SP_Separador1.Size = New System.Drawing.Size(3, 537)
        Me.SP_Separador1.TabIndex = 9
        Me.SP_Separador1.TabStop = False
        '
        'CM_Edit
        '
        Me.CM_Edit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMS_Cut, Me.CMS_Copy, Me.CMS_Paste, Me.ToolStripMenuItem4, Me.CMS_GoToLine, Me.CMS_Find, Me.CMS_Replace, Me.ToolStripMenuItem3, Me.CMS_SelectedAll, Me.CMS_Delete, Me.VerColorToolStripMenuItem})
        Me.CM_Edit.Name = "MenuFastTextColorBox1"
        Me.CM_Edit.Size = New System.Drawing.Size(165, 214)
        '
        'CMS_Cut
        '
        Me.CMS_Cut.Enabled = False
        Me.CMS_Cut.Image = CType(resources.GetObject("CMS_Cut.Image"), System.Drawing.Image)
        Me.CMS_Cut.Name = "CMS_Cut"
        Me.CMS_Cut.Size = New System.Drawing.Size(164, 22)
        Me.CMS_Cut.Text = "Cortar"
        '
        'CMS_Copy
        '
        Me.CMS_Copy.Enabled = False
        Me.CMS_Copy.Image = CType(resources.GetObject("CMS_Copy.Image"), System.Drawing.Image)
        Me.CMS_Copy.Name = "CMS_Copy"
        Me.CMS_Copy.Size = New System.Drawing.Size(164, 22)
        Me.CMS_Copy.Text = "Copiar"
        '
        'CMS_Paste
        '
        Me.CMS_Paste.Enabled = False
        Me.CMS_Paste.Image = CType(resources.GetObject("CMS_Paste.Image"), System.Drawing.Image)
        Me.CMS_Paste.Name = "CMS_Paste"
        Me.CMS_Paste.Size = New System.Drawing.Size(164, 22)
        Me.CMS_Paste.Text = "Pegar"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(161, 6)
        '
        'CMS_GoToLine
        '
        Me.CMS_GoToLine.Enabled = False
        Me.CMS_GoToLine.Name = "CMS_GoToLine"
        Me.CMS_GoToLine.Size = New System.Drawing.Size(164, 22)
        Me.CMS_GoToLine.Text = "Ir a la linea"
        '
        'CMS_Find
        '
        Me.CMS_Find.Enabled = False
        Me.CMS_Find.Image = CType(resources.GetObject("CMS_Find.Image"), System.Drawing.Image)
        Me.CMS_Find.Name = "CMS_Find"
        Me.CMS_Find.Size = New System.Drawing.Size(164, 22)
        Me.CMS_Find.Text = "Buscar"
        '
        'CMS_Replace
        '
        Me.CMS_Replace.Enabled = False
        Me.CMS_Replace.Name = "CMS_Replace"
        Me.CMS_Replace.Size = New System.Drawing.Size(164, 22)
        Me.CMS_Replace.Text = "Reemplazar"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(161, 6)
        '
        'CMS_SelectedAll
        '
        Me.CMS_SelectedAll.Enabled = False
        Me.CMS_SelectedAll.Name = "CMS_SelectedAll"
        Me.CMS_SelectedAll.Size = New System.Drawing.Size(164, 22)
        Me.CMS_SelectedAll.Text = "Seleccionar todo"
        '
        'CMS_Delete
        '
        Me.CMS_Delete.Enabled = False
        Me.CMS_Delete.Image = CType(resources.GetObject("CMS_Delete.Image"), System.Drawing.Image)
        Me.CMS_Delete.Name = "CMS_Delete"
        Me.CMS_Delete.Size = New System.Drawing.Size(164, 22)
        Me.CMS_Delete.Text = "Eliminar"
        '
        'VerColorToolStripMenuItem
        '
        Me.VerColorToolStripMenuItem.Name = "VerColorToolStripMenuItem"
        Me.VerColorToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.VerColorToolStripMenuItem.Text = "Ver Color"
        '
        'TM_ControlUpdate
        '
        Me.TM_ControlUpdate.Interval = 1
        '
        'CMS_TabMenu
        '
        Me.CMS_TabMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMS_TabMenu_CloseTab, Me.CMS_TabMenu_CloseAllTab, Me.CMS_TabMenu_CloseAllTabOrSelected})
        Me.CMS_TabMenu.Name = "CMS_TabMenu"
        Me.CMS_TabMenu.Size = New System.Drawing.Size(268, 70)
        '
        'CMS_TabMenu_CloseTab
        '
        Me.CMS_TabMenu_CloseTab.Name = "CMS_TabMenu_CloseTab"
        Me.CMS_TabMenu_CloseTab.Size = New System.Drawing.Size(267, 22)
        Me.CMS_TabMenu_CloseTab.Text = "Cerrar Pestaña"
        '
        'CMS_TabMenu_CloseAllTab
        '
        Me.CMS_TabMenu_CloseAllTab.Name = "CMS_TabMenu_CloseAllTab"
        Me.CMS_TabMenu_CloseAllTab.Size = New System.Drawing.Size(267, 22)
        Me.CMS_TabMenu_CloseAllTab.Text = "Cerrar todas las pestañas"
        '
        'CMS_TabMenu_CloseAllTabOrSelected
        '
        Me.CMS_TabMenu_CloseAllTabOrSelected.Name = "CMS_TabMenu_CloseAllTabOrSelected"
        Me.CMS_TabMenu_CloseAllTabOrSelected.Size = New System.Drawing.Size(267, 22)
        Me.CMS_TabMenu_CloseAllTabOrSelected.Text = "Cerrar todas las pestañas menos esta"
        '
        'Splitter1
        '
        Me.Splitter1.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 383)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(758, 3)
        Me.Splitter1.TabIndex = 12
        Me.Splitter1.TabStop = False
        '
        'BW_CompileRun
        '
        Me.BW_CompileRun.WorkerReportsProgress = True
        Me.BW_CompileRun.WorkerSupportsCancellation = True
        '
        'Timer_Process
        '
        Me.Timer_Process.Interval = 1
        '
        'BW_RuningProject
        '
        Me.BW_RuningProject.WorkerReportsProgress = True
        Me.BW_RuningProject.WorkerSupportsCancellation = True
        '
        'TM_AutoSave
        '
        Me.TM_AutoSave.Enabled = True
        Me.TM_AutoSave.Interval = 1
        '
        'MS_Menu
        '
        Me.MS_Menu.BackColor = System.Drawing.Color.Transparent
        Me.MS_Menu.BackgroundImage = CType(resources.GetObject("MS_Menu.BackgroundImage"), System.Drawing.Image)
        Me.MS_Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MS_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_File, Me.TSMI_Edit, Me.TSMI_Project, Me.TSMI_Generate, Me.TSMI_Debug, Me.TSMI_Tool, Me.TSMI_Wiki, Me.TSMI_Languaje})
        Me.MS_Menu.Location = New System.Drawing.Point(0, 0)
        Me.MS_Menu.Name = "MS_Menu"
        Me.MS_Menu.Size = New System.Drawing.Size(1019, 24)
        Me.MS_Menu.TabIndex = 1
        Me.MS_Menu.Text = "MenuStrip1"
        '
        'TSMI_File
        '
        Me.TSMI_File.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_NewProject, Me.TSMI_OpenProject, Me.toolStripSeparator, Me.TSMI_CloseProject, Me.ToolStripMenuItem2, Me.TSMI_CloseTab, Me.TSMI_CloseAllTab, Me.ToolStripMenuItem1, Me.TSMI_Save, Me.TSMI_SaveAll, Me.TSMI_RecentProject, Me.toolStripSeparator1, Me.TSMI_Exit})
        Me.TSMI_File.Name = "TSMI_File"
        Me.TSMI_File.Size = New System.Drawing.Size(55, 20)
        Me.TSMI_File.Text = "Archivo"
        '
        'TSMI_NewProject
        '
        Me.TSMI_NewProject.Image = CType(resources.GetObject("TSMI_NewProject.Image"), System.Drawing.Image)
        Me.TSMI_NewProject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSMI_NewProject.Name = "TSMI_NewProject"
        Me.TSMI_NewProject.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.TSMI_NewProject.Size = New System.Drawing.Size(211, 22)
        Me.TSMI_NewProject.Text = "Nuevo Proyecto"
        '
        'TSMI_OpenProject
        '
        Me.TSMI_OpenProject.Image = CType(resources.GetObject("TSMI_OpenProject.Image"), System.Drawing.Image)
        Me.TSMI_OpenProject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSMI_OpenProject.Name = "TSMI_OpenProject"
        Me.TSMI_OpenProject.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.TSMI_OpenProject.Size = New System.Drawing.Size(211, 22)
        Me.TSMI_OpenProject.Text = "Abrir Proyecto"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(208, 6)
        '
        'TSMI_CloseProject
        '
        Me.TSMI_CloseProject.Enabled = False
        Me.TSMI_CloseProject.Name = "TSMI_CloseProject"
        Me.TSMI_CloseProject.Size = New System.Drawing.Size(211, 22)
        Me.TSMI_CloseProject.Text = "Cerrar Proyecto"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(208, 6)
        '
        'TSMI_CloseTab
        '
        Me.TSMI_CloseTab.Enabled = False
        Me.TSMI_CloseTab.Name = "TSMI_CloseTab"
        Me.TSMI_CloseTab.Size = New System.Drawing.Size(211, 22)
        Me.TSMI_CloseTab.Text = "Cerrar Pestaña"
        '
        'TSMI_CloseAllTab
        '
        Me.TSMI_CloseAllTab.Enabled = False
        Me.TSMI_CloseAllTab.Name = "TSMI_CloseAllTab"
        Me.TSMI_CloseAllTab.Size = New System.Drawing.Size(211, 22)
        Me.TSMI_CloseAllTab.Text = "Cerrar Todas las Pestañas"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(208, 6)
        '
        'TSMI_Save
        '
        Me.TSMI_Save.Enabled = False
        Me.TSMI_Save.Image = CType(resources.GetObject("TSMI_Save.Image"), System.Drawing.Image)
        Me.TSMI_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSMI_Save.Name = "TSMI_Save"
        Me.TSMI_Save.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.TSMI_Save.Size = New System.Drawing.Size(211, 22)
        Me.TSMI_Save.Text = "Guardar"
        '
        'TSMI_SaveAll
        '
        Me.TSMI_SaveAll.Enabled = False
        Me.TSMI_SaveAll.Image = CType(resources.GetObject("TSMI_SaveAll.Image"), System.Drawing.Image)
        Me.TSMI_SaveAll.Name = "TSMI_SaveAll"
        Me.TSMI_SaveAll.Size = New System.Drawing.Size(211, 22)
        Me.TSMI_SaveAll.Text = "Guarda todo"
        '
        'TSMI_RecentProject
        '
        Me.TSMI_RecentProject.Name = "TSMI_RecentProject"
        Me.TSMI_RecentProject.Size = New System.Drawing.Size(211, 22)
        Me.TSMI_RecentProject.Text = "Proyectos recientes"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(208, 6)
        '
        'TSMI_Exit
        '
        Me.TSMI_Exit.Name = "TSMI_Exit"
        Me.TSMI_Exit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.TSMI_Exit.Size = New System.Drawing.Size(211, 22)
        Me.TSMI_Exit.Text = "Salir"
        '
        'TSMI_Edit
        '
        Me.TSMI_Edit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_Undo, Me.TSMI_Redo, Me.toolStripSeparator3, Me.TSMI_Cut, Me.TSMI_Copy, Me.TSMI_Paste, Me.toolStripSeparator4, Me.TSMI_GotoIn, Me.TSMI_Find, Me.TSMI_Replace, Me.ToolStripMenuItem5, Me.TSMI_SelectAll, Me.TSMI_Delete})
        Me.TSMI_Edit.Name = "TSMI_Edit"
        Me.TSMI_Edit.Size = New System.Drawing.Size(47, 20)
        Me.TSMI_Edit.Text = "Editar"
        '
        'TSMI_Undo
        '
        Me.TSMI_Undo.Enabled = False
        Me.TSMI_Undo.Image = CType(resources.GetObject("TSMI_Undo.Image"), System.Drawing.Image)
        Me.TSMI_Undo.Name = "TSMI_Undo"
        Me.TSMI_Undo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.TSMI_Undo.Size = New System.Drawing.Size(203, 22)
        Me.TSMI_Undo.Text = "Deshacer"
        '
        'TSMI_Redo
        '
        Me.TSMI_Redo.Enabled = False
        Me.TSMI_Redo.Image = CType(resources.GetObject("TSMI_Redo.Image"), System.Drawing.Image)
        Me.TSMI_Redo.Name = "TSMI_Redo"
        Me.TSMI_Redo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.TSMI_Redo.Size = New System.Drawing.Size(203, 22)
        Me.TSMI_Redo.Text = "Rehacer"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(200, 6)
        '
        'TSMI_Cut
        '
        Me.TSMI_Cut.Enabled = False
        Me.TSMI_Cut.Image = CType(resources.GetObject("TSMI_Cut.Image"), System.Drawing.Image)
        Me.TSMI_Cut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSMI_Cut.Name = "TSMI_Cut"
        Me.TSMI_Cut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.TSMI_Cut.Size = New System.Drawing.Size(203, 22)
        Me.TSMI_Cut.Text = "Cortar"
        '
        'TSMI_Copy
        '
        Me.TSMI_Copy.Enabled = False
        Me.TSMI_Copy.Image = CType(resources.GetObject("TSMI_Copy.Image"), System.Drawing.Image)
        Me.TSMI_Copy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSMI_Copy.Name = "TSMI_Copy"
        Me.TSMI_Copy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.TSMI_Copy.Size = New System.Drawing.Size(203, 22)
        Me.TSMI_Copy.Text = "Copiar"
        '
        'TSMI_Paste
        '
        Me.TSMI_Paste.Enabled = False
        Me.TSMI_Paste.Image = CType(resources.GetObject("TSMI_Paste.Image"), System.Drawing.Image)
        Me.TSMI_Paste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSMI_Paste.Name = "TSMI_Paste"
        Me.TSMI_Paste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.TSMI_Paste.Size = New System.Drawing.Size(203, 22)
        Me.TSMI_Paste.Text = "Pegar"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(200, 6)
        '
        'TSMI_GotoIn
        '
        Me.TSMI_GotoIn.Enabled = False
        Me.TSMI_GotoIn.Name = "TSMI_GotoIn"
        Me.TSMI_GotoIn.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.TSMI_GotoIn.Size = New System.Drawing.Size(203, 22)
        Me.TSMI_GotoIn.Text = "Ir a la linea"
        '
        'TSMI_Find
        '
        Me.TSMI_Find.Enabled = False
        Me.TSMI_Find.Image = CType(resources.GetObject("TSMI_Find.Image"), System.Drawing.Image)
        Me.TSMI_Find.Name = "TSMI_Find"
        Me.TSMI_Find.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.TSMI_Find.Size = New System.Drawing.Size(203, 22)
        Me.TSMI_Find.Text = "Buscar"
        '
        'TSMI_Replace
        '
        Me.TSMI_Replace.Enabled = False
        Me.TSMI_Replace.Name = "TSMI_Replace"
        Me.TSMI_Replace.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.TSMI_Replace.Size = New System.Drawing.Size(203, 22)
        Me.TSMI_Replace.Text = "Reemplasar"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(200, 6)
        '
        'TSMI_SelectAll
        '
        Me.TSMI_SelectAll.Enabled = False
        Me.TSMI_SelectAll.Name = "TSMI_SelectAll"
        Me.TSMI_SelectAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.TSMI_SelectAll.Size = New System.Drawing.Size(203, 22)
        Me.TSMI_SelectAll.Text = "Seleccionar todo"
        '
        'TSMI_Delete
        '
        Me.TSMI_Delete.Enabled = False
        Me.TSMI_Delete.Image = CType(resources.GetObject("TSMI_Delete.Image"), System.Drawing.Image)
        Me.TSMI_Delete.Name = "TSMI_Delete"
        Me.TSMI_Delete.Size = New System.Drawing.Size(203, 22)
        Me.TSMI_Delete.Text = "Eliminar"
        '
        'TSMI_Project
        '
        Me.TSMI_Project.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_ViewExplored, Me.TSMI_RefreshProject, Me.TSMI_PropertyProject})
        Me.TSMI_Project.Name = "TSMI_Project"
        Me.TSMI_Project.Size = New System.Drawing.Size(62, 20)
        Me.TSMI_Project.Text = "Proyecto"
        '
        'TSMI_ViewExplored
        '
        Me.TSMI_ViewExplored.Enabled = False
        Me.TSMI_ViewExplored.Image = CType(resources.GetObject("TSMI_ViewExplored.Image"), System.Drawing.Image)
        Me.TSMI_ViewExplored.Name = "TSMI_ViewExplored"
        Me.TSMI_ViewExplored.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.TSMI_ViewExplored.Size = New System.Drawing.Size(246, 22)
        Me.TSMI_ViewExplored.Text = "Mostrar en el explorador"
        '
        'TSMI_RefreshProject
        '
        Me.TSMI_RefreshProject.Enabled = False
        Me.TSMI_RefreshProject.Image = CType(resources.GetObject("TSMI_RefreshProject.Image"), System.Drawing.Image)
        Me.TSMI_RefreshProject.Name = "TSMI_RefreshProject"
        Me.TSMI_RefreshProject.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.TSMI_RefreshProject.Size = New System.Drawing.Size(246, 22)
        Me.TSMI_RefreshProject.Text = "Refrescar Proyecto"
        '
        'TSMI_PropertyProject
        '
        Me.TSMI_PropertyProject.Enabled = False
        Me.TSMI_PropertyProject.Image = CType(resources.GetObject("TSMI_PropertyProject.Image"), System.Drawing.Image)
        Me.TSMI_PropertyProject.Name = "TSMI_PropertyProject"
        Me.TSMI_PropertyProject.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.TSMI_PropertyProject.Size = New System.Drawing.Size(246, 22)
        Me.TSMI_PropertyProject.Text = "Propiedades Del Proyecto"
        '
        'TSMI_Generate
        '
        Me.TSMI_Generate.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_GenerateLove, Me.TSMI_GenerateExe})
        Me.TSMI_Generate.Name = "TSMI_Generate"
        Me.TSMI_Generate.Size = New System.Drawing.Size(58, 20)
        Me.TSMI_Generate.Text = "Generar"
        '
        'TSMI_GenerateLove
        '
        Me.TSMI_GenerateLove.Enabled = False
        Me.TSMI_GenerateLove.Image = CType(resources.GetObject("TSMI_GenerateLove.Image"), System.Drawing.Image)
        Me.TSMI_GenerateLove.Name = "TSMI_GenerateLove"
        Me.TSMI_GenerateLove.Size = New System.Drawing.Size(199, 22)
        Me.TSMI_GenerateLove.Text = "Generar Archivo .love"
        '
        'TSMI_GenerateExe
        '
        Me.TSMI_GenerateExe.Enabled = False
        Me.TSMI_GenerateExe.Image = CType(resources.GetObject("TSMI_GenerateExe.Image"), System.Drawing.Image)
        Me.TSMI_GenerateExe.Name = "TSMI_GenerateExe"
        Me.TSMI_GenerateExe.Size = New System.Drawing.Size(199, 22)
        Me.TSMI_GenerateExe.Text = "Generar Aplicación .exe"
        '
        'TSMI_Debug
        '
        Me.TSMI_Debug.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_StartDebugging, Me.TSMI_StopDebugging})
        Me.TSMI_Debug.Name = "TSMI_Debug"
        Me.TSMI_Debug.Size = New System.Drawing.Size(58, 20)
        Me.TSMI_Debug.Text = "Depurar"
        '
        'TSMI_StartDebugging
        '
        Me.TSMI_StartDebugging.Enabled = False
        Me.TSMI_StartDebugging.Image = CType(resources.GetObject("TSMI_StartDebugging.Image"), System.Drawing.Image)
        Me.TSMI_StartDebugging.Name = "TSMI_StartDebugging"
        Me.TSMI_StartDebugging.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.TSMI_StartDebugging.Size = New System.Drawing.Size(200, 22)
        Me.TSMI_StartDebugging.Text = "Iniciar Depuracion"
        '
        'TSMI_StopDebugging
        '
        Me.TSMI_StopDebugging.Enabled = False
        Me.TSMI_StopDebugging.Image = CType(resources.GetObject("TSMI_StopDebugging.Image"), System.Drawing.Image)
        Me.TSMI_StopDebugging.Name = "TSMI_StopDebugging"
        Me.TSMI_StopDebugging.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.TSMI_StopDebugging.Size = New System.Drawing.Size(200, 22)
        Me.TSMI_StopDebugging.Text = "Detener Depuracion"
        '
        'TSMI_Tool
        '
        Me.TSMI_Tool.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_Color, Me.TSMI_AssosiateExtencion, Me.TSMI_AttachContextMenu, Me.TSMI_Options})
        Me.TSMI_Tool.Name = "TSMI_Tool"
        Me.TSMI_Tool.Size = New System.Drawing.Size(83, 20)
        Me.TSMI_Tool.Text = "Herramientas"
        '
        'TSMI_Color
        '
        Me.TSMI_Color.Image = CType(resources.GetObject("TSMI_Color.Image"), System.Drawing.Image)
        Me.TSMI_Color.Name = "TSMI_Color"
        Me.TSMI_Color.Size = New System.Drawing.Size(245, 22)
        Me.TSMI_Color.Text = "Colores"
        '
        'TSMI_AssosiateExtencion
        '
        Me.TSMI_AssosiateExtencion.Name = "TSMI_AssosiateExtencion"
        Me.TSMI_AssosiateExtencion.Size = New System.Drawing.Size(245, 22)
        Me.TSMI_AssosiateExtencion.Text = "Asociar Extencion (.vlp)"
        '
        'TSMI_AttachContextMenu
        '
        Me.TSMI_AttachContextMenu.Name = "TSMI_AttachContextMenu"
        Me.TSMI_AttachContextMenu.Size = New System.Drawing.Size(245, 22)
        Me.TSMI_AttachContextMenu.Text = "Asociar al Menu Contextual (.vlp)"
        '
        'TSMI_Options
        '
        Me.TSMI_Options.Image = CType(resources.GetObject("TSMI_Options.Image"), System.Drawing.Image)
        Me.TSMI_Options.Name = "TSMI_Options"
        Me.TSMI_Options.Size = New System.Drawing.Size(245, 22)
        Me.TSMI_Options.Text = "Opciones"
        '
        'TSMI_Wiki
        '
        Me.TSMI_Wiki.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_Example, Me.ToolStripMenuItem11, Me.TSMI_HomePage, Me.TSMI_Tutorials, Me.TSMI_Function, Me.ToolStripMenuItem6, Me.TSMI_AboutMe, Me.TSMI_DateOfCreate, Me.TSMI_UltimateRevision, Me.ToolStripMenuItem7, Me.TSMI_VersionApplication})
        Me.TSMI_Wiki.Name = "TSMI_Wiki"
        Me.TSMI_Wiki.Size = New System.Drawing.Size(38, 20)
        Me.TSMI_Wiki.Text = "Wiki"
        '
        'TSMI_Example
        '
        Me.TSMI_Example.Name = "TSMI_Example"
        Me.TSMI_Example.Size = New System.Drawing.Size(215, 22)
        Me.TSMI_Example.Text = "Ejemplos"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(212, 6)
        '
        'TSMI_HomePage
        '
        Me.TSMI_HomePage.Name = "TSMI_HomePage"
        Me.TSMI_HomePage.Size = New System.Drawing.Size(215, 22)
        Me.TSMI_HomePage.Text = "Pagina de Inicio (En Ingles)"
        '
        'TSMI_Tutorials
        '
        Me.TSMI_Tutorials.Name = "TSMI_Tutorials"
        Me.TSMI_Tutorials.Size = New System.Drawing.Size(215, 22)
        Me.TSMI_Tutorials.Text = "Tutoriales (En Ingles)"
        '
        'TSMI_Function
        '
        Me.TSMI_Function.Name = "TSMI_Function"
        Me.TSMI_Function.Size = New System.Drawing.Size(215, 22)
        Me.TSMI_Function.Text = "Funciones (En Ingles)"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(212, 6)
        '
        'TSMI_AboutMe
        '
        Me.TSMI_AboutMe.Name = "TSMI_AboutMe"
        Me.TSMI_AboutMe.Size = New System.Drawing.Size(215, 22)
        Me.TSMI_AboutMe.Text = "Acerca de..."
        '
        'TSMI_DateOfCreate
        '
        Me.TSMI_DateOfCreate.Name = "TSMI_DateOfCreate"
        Me.TSMI_DateOfCreate.Size = New System.Drawing.Size(215, 22)
        Me.TSMI_DateOfCreate.Text = "Fecha de creacion"
        '
        'TSMI_UltimateRevision
        '
        Me.TSMI_UltimateRevision.Name = "TSMI_UltimateRevision"
        Me.TSMI_UltimateRevision.Size = New System.Drawing.Size(215, 22)
        Me.TSMI_UltimateRevision.Text = "Ultima Revision"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(212, 6)
        '
        'TSMI_VersionApplication
        '
        Me.TSMI_VersionApplication.Name = "TSMI_VersionApplication"
        Me.TSMI_VersionApplication.Size = New System.Drawing.Size(215, 22)
        Me.TSMI_VersionApplication.Text = "Version de la aplicasion"
        '
        'TSMI_Languaje
        '
        Me.TSMI_Languaje.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_Package})
        Me.TSMI_Languaje.Name = "TSMI_Languaje"
        Me.TSMI_Languaje.Size = New System.Drawing.Size(63, 20)
        Me.TSMI_Languaje.Text = "Lenguaje"
        '
        'TSMI_Package
        '
        Me.TSMI_Package.Name = "TSMI_Package"
        Me.TSMI_Package.Size = New System.Drawing.Size(176, 22)
        Me.TSMI_Package.Text = "Paketes de idiomas"
        '
        'IL_AutoCompleted
        '
        Me.IL_AutoCompleted.ImageStream = CType(resources.GetObject("IL_AutoCompleted.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.IL_AutoCompleted.TransparentColor = System.Drawing.Color.Transparent
        Me.IL_AutoCompleted.Images.SetKeyName(0, "Variables.png")
        Me.IL_AutoCompleted.Images.SetKeyName(1, "Class.png")
        Me.IL_AutoCompleted.Images.SetKeyName(2, "Eventos.png")
        Me.IL_AutoCompleted.Images.SetKeyName(3, "Methodos.png")
        '
        'TC_Editor
        '
        Me.TC_Editor.ContextMenuStrip = Me.CMS_TabMenu
        Me.TC_Editor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TC_Editor.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TC_Editor.Image = CType(resources.GetObject("TC_Editor.Image"), System.Drawing.Image)
        Me.TC_Editor.ImageBackground = True
        Me.TC_Editor.ImageList = Me.IL_Explored
        Me.TC_Editor.ImageRezise = True
        Me.TC_Editor.Location = New System.Drawing.Point(0, 50)
        Me.TC_Editor.Name = "TC_Editor"
        Me.TC_Editor.SelectedIndex = 0
        Me.TC_Editor.Size = New System.Drawing.Size(758, 333)
        Me.TC_Editor.StyleControl = VisualLoveProject_2._0_Ultimate.Help.StyleControl.VS2010
        Me.TC_Editor.TabIndex = 13
        Me.TC_Editor.TextAling = VisualLoveProject_2._0_Ultimate.Help.TextAling.Left
        '
        'Console1
        '
        Me.Console1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Console1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Console1.Location = New System.Drawing.Point(0, 386)
        Me.Console1.Name = "Console1"
        Me.Console1.Size = New System.Drawing.Size(758, 201)
        Me.Console1.TabIndex = 11
        '
        'MainForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1019, 609)
        Me.Controls.Add(Me.TC_Editor)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Console1)
        Me.Controls.Add(Me.SP_Separador1)
        Me.Controls.Add(Me.GB_Explored)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TSS_Path)
        Me.Controls.Add(Me.MS_Menu)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VisualLoveProject 2.0 Ultimate"
        Me.TS_Tool.ResumeLayout(False)
        Me.TS_Tool.PerformLayout()
        Me.TSS_Path.ResumeLayout(False)
        Me.TSS_Path.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GB_Explored.ResumeLayout(False)
        Me.CMS_ExploredMenu.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TS_Explored.ResumeLayout(False)
        Me.TS_Explored.PerformLayout()
        Me.CM_Edit.ResumeLayout(False)
        Me.CMS_TabMenu.ResumeLayout(False)
        Me.MS_Menu.ResumeLayout(False)
        Me.MS_Menu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MS_Menu As System.Windows.Forms.MenuStrip
    Friend WithEvents TSMI_File As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_NewProject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_OpenProject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSMI_CloseProject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSMI_CloseTab As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_CloseAllTab As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSMI_Save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_SaveAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSMI_Exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Undo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Redo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSMI_Cut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Copy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Paste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSMI_GotoIn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Find As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Replace As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSMI_SelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Project As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_ViewExplored As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_RefreshProject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_PropertyProject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Generate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_GenerateLove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_GenerateExe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Debug As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_StartDebugging As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_StopDebugging As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Tool As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Color As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_AssosiateExtencion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_AttachContextMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Options As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Wiki As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Example As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSMI_HomePage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Tutorials As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Function As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSMI_AboutMe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_DateOfCreate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_UltimateRevision As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSMI_VersionApplication As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Languaje As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Package As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TS_Tool As System.Windows.Forms.ToolStrip
    Friend WithEvents TSB_NewProject As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_Separator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSB_OpenProject As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_SaveAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_Separator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSB_Cut As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_Copy As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_Paste As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_Separator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSB_Comment As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_DesComment As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_Separator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSB_AddBookMark As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_RemoveBookMark As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_Separator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSB_Undo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_Redo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_BookMark As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TSB_Separator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSB_StartDebugging As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_StopDebugging As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSB_Help As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSS_Path As System.Windows.Forms.StatusStrip
    Friend WithEvents TSSL_Text As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSL_Path As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents IL_Explored As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GB_Explored As System.Windows.Forms.GroupBox
    Friend WithEvents TS_Explored As System.Windows.Forms.ToolStrip
    Friend WithEvents TSB_Property As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_ShowFiles As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_Refresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TSB_Separator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SP_Separador1 As System.Windows.Forms.Splitter
    Friend WithEvents CM_Edit As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CMS_Cut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_Copy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_Paste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMS_GoToLine As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_Find As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_Replace As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMS_SelectedAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_Delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TV_Explored As System.Windows.Forms.TreeView
    Friend WithEvents TM_ControlUpdate As System.Windows.Forms.Timer
    Friend WithEvents TSMI_RecentProject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Console1 As VisualLoveProject_2._0_Ultimate.Console
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents BW_CompileRun As System.ComponentModel.BackgroundWorker
    Friend WithEvents TSB_ZoomIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_ZoomOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_Separator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSB_NormalZoom As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer_Process As System.Windows.Forms.Timer
    Friend WithEvents BW_RuningProject As System.ComponentModel.BackgroundWorker
    Friend WithEvents CMS_ExploredMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TSMI_New As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_NewFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_NewFileLua As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_NewFileTxt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Cut_Tv_Explored As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Copy_Tv_Explored As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Paste_Tv_Explored As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Rename_Tv_Explored As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Delete_Tv_Explored As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_Property_Tv_Explored As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_EditImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_ImportsResoucer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMS_TabMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CMS_TabMenu_CloseTab As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_TabMenu_CloseAllTab As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_TabMenu_CloseAllTabOrSelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSMI_ViewExplored_Tv_Eplored As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TM_AutoSave As System.Windows.Forms.Timer
    Friend WithEvents TC_Editor As VisualLoveProject_2._0_Ultimate.UserTabControl
    Friend WithEvents VerColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_Find As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSMI_NewImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IL_AutoCompleted As System.Windows.Forms.ImageList

End Class
