<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PropertiesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PropertiesForm))
        Me.LB_Author = New System.Windows.Forms.Label()
        Me.TB_Author = New System.Windows.Forms.TextBox()
        Me.LB_Version = New System.Windows.Forms.Label()
        Me.TB_Company = New System.Windows.Forms.TextBox()
        Me.LB_Company = New System.Windows.Forms.Label()
        Me.TB_Ico = New System.Windows.Forms.TextBox()
        Me.BT_Shared = New System.Windows.Forms.Button()
        Me.LB_Ico = New System.Windows.Forms.Label()
        Me.TB_Version = New System.Windows.Forms.TextBox()
        Me.TB_DateCreate = New System.Windows.Forms.TextBox()
        Me.LB_DateCreation = New System.Windows.Forms.Label()
        Me.BT_Accet = New System.Windows.Forms.Button()
        Me.BT_Cancel = New System.Windows.Forms.Button()
        Me.CB_LoveVersion = New System.Windows.Forms.ComboBox()
        Me.LB_LoveVersion = New System.Windows.Forms.Label()
        Me.PB_Ico = New VisualLoveProject_2._0_Ultimate.UserPictureBox()
        Me.SuspendLayout()
        '
        'LB_Author
        '
        Me.LB_Author.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LB_Author.AutoSize = True
        Me.LB_Author.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Author.ForeColor = System.Drawing.Color.White
        Me.LB_Author.Location = New System.Drawing.Point(96, 109)
        Me.LB_Author.Name = "LB_Author"
        Me.LB_Author.Size = New System.Drawing.Size(42, 16)
        Me.LB_Author.TabIndex = 0
        Me.LB_Author.Text = "Autor:"
        '
        'TB_Author
        '
        Me.TB_Author.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Author.Location = New System.Drawing.Point(144, 108)
        Me.TB_Author.Name = "TB_Author"
        Me.TB_Author.Size = New System.Drawing.Size(431, 20)
        Me.TB_Author.TabIndex = 1
        '
        'LB_Version
        '
        Me.LB_Version.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LB_Version.AutoSize = True
        Me.LB_Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Version.ForeColor = System.Drawing.Color.White
        Me.LB_Version.Location = New System.Drawing.Point(81, 146)
        Me.LB_Version.Name = "LB_Version"
        Me.LB_Version.Size = New System.Drawing.Size(57, 16)
        Me.LB_Version.TabIndex = 2
        Me.LB_Version.Text = "Version:"
        '
        'TB_Company
        '
        Me.TB_Company.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Company.Location = New System.Drawing.Point(144, 181)
        Me.TB_Company.Name = "TB_Company"
        Me.TB_Company.Size = New System.Drawing.Size(431, 20)
        Me.TB_Company.TabIndex = 5
        '
        'LB_Company
        '
        Me.LB_Company.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LB_Company.AutoSize = True
        Me.LB_Company.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Company.ForeColor = System.Drawing.Color.White
        Me.LB_Company.Location = New System.Drawing.Point(65, 181)
        Me.LB_Company.Name = "LB_Company"
        Me.LB_Company.Size = New System.Drawing.Size(73, 16)
        Me.LB_Company.TabIndex = 4
        Me.LB_Company.Text = "Compañia:"
        '
        'TB_Ico
        '
        Me.TB_Ico.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Ico.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Ico.Location = New System.Drawing.Point(144, 48)
        Me.TB_Ico.Name = "TB_Ico"
        Me.TB_Ico.ReadOnly = True
        Me.TB_Ico.Size = New System.Drawing.Size(431, 20)
        Me.TB_Ico.TabIndex = 12
        '
        'BT_Shared
        '
        Me.BT_Shared.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_Shared.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Shared.ForeColor = System.Drawing.SystemColors.Highlight
        Me.BT_Shared.Location = New System.Drawing.Point(581, 46)
        Me.BT_Shared.Name = "BT_Shared"
        Me.BT_Shared.Size = New System.Drawing.Size(44, 23)
        Me.BT_Shared.TabIndex = 8
        Me.BT_Shared.Text = "..."
        Me.BT_Shared.UseVisualStyleBackColor = True
        '
        'LB_Ico
        '
        Me.LB_Ico.AutoSize = True
        Me.LB_Ico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Ico.ForeColor = System.Drawing.Color.White
        Me.LB_Ico.Location = New System.Drawing.Point(271, 29)
        Me.LB_Ico.Name = "LB_Ico"
        Me.LB_Ico.Size = New System.Drawing.Size(139, 16)
        Me.LB_Ico.TabIndex = 9
        Me.LB_Ico.Text = "Icono de la aplicacion"
        '
        'TB_Version
        '
        Me.TB_Version.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Version.Location = New System.Drawing.Point(144, 146)
        Me.TB_Version.Name = "TB_Version"
        Me.TB_Version.Size = New System.Drawing.Size(431, 20)
        Me.TB_Version.TabIndex = 3
        '
        'TB_DateCreate
        '
        Me.TB_DateCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_DateCreate.BackColor = System.Drawing.SystemColors.Window
        Me.TB_DateCreate.Location = New System.Drawing.Point(144, 308)
        Me.TB_DateCreate.Name = "TB_DateCreate"
        Me.TB_DateCreate.ReadOnly = True
        Me.TB_DateCreate.Size = New System.Drawing.Size(431, 20)
        Me.TB_DateCreate.TabIndex = 11
        '
        'LB_DateCreation
        '
        Me.LB_DateCreation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LB_DateCreation.AutoSize = True
        Me.LB_DateCreation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_DateCreation.ForeColor = System.Drawing.Color.White
        Me.LB_DateCreation.Location = New System.Drawing.Point(281, 289)
        Me.LB_DateCreation.Name = "LB_DateCreation"
        Me.LB_DateCreation.Size = New System.Drawing.Size(123, 16)
        Me.LB_DateCreation.TabIndex = 10
        Me.LB_DateCreation.Text = "Fecha de creacion:"
        '
        'BT_Accet
        '
        Me.BT_Accet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_Accet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Accet.ForeColor = System.Drawing.SystemColors.Highlight
        Me.BT_Accet.Location = New System.Drawing.Point(513, 359)
        Me.BT_Accet.Name = "BT_Accet"
        Me.BT_Accet.Size = New System.Drawing.Size(75, 23)
        Me.BT_Accet.TabIndex = 1
        Me.BT_Accet.Text = "Aceptar"
        Me.BT_Accet.UseVisualStyleBackColor = True
        '
        'BT_Cancel
        '
        Me.BT_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BT_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Cancel.ForeColor = System.Drawing.SystemColors.Highlight
        Me.BT_Cancel.Location = New System.Drawing.Point(594, 359)
        Me.BT_Cancel.Name = "BT_Cancel"
        Me.BT_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.BT_Cancel.TabIndex = 13
        Me.BT_Cancel.Text = "Cancelar"
        Me.BT_Cancel.UseVisualStyleBackColor = True
        '
        'CB_LoveVersion
        '
        Me.CB_LoveVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CB_LoveVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_LoveVersion.FormattingEnabled = True
        Me.CB_LoveVersion.Items.AddRange(New Object() {"Love 0.8.0", "Love 0.7.2"})
        Me.CB_LoveVersion.Location = New System.Drawing.Point(144, 240)
        Me.CB_LoveVersion.Name = "CB_LoveVersion"
        Me.CB_LoveVersion.Size = New System.Drawing.Size(431, 21)
        Me.CB_LoveVersion.TabIndex = 17
        '
        'LB_LoveVersion
        '
        Me.LB_LoveVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LB_LoveVersion.AutoSize = True
        Me.LB_LoveVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_LoveVersion.ForeColor = System.Drawing.Color.White
        Me.LB_LoveVersion.Location = New System.Drawing.Point(290, 221)
        Me.LB_LoveVersion.Name = "LB_LoveVersion"
        Me.LB_LoveVersion.Size = New System.Drawing.Size(105, 16)
        Me.LB_LoveVersion.TabIndex = 16
        Me.LB_LoveVersion.Text = "Version de love:"
        '
        'PB_Ico
        '
        Me.PB_Ico.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PB_Ico.Cursor = System.Windows.Forms.Cursors.Default
        Me.PB_Ico.Image = CType(resources.GetObject("PB_Ico.Image"), System.Drawing.Image)
        Me.PB_Ico.Location = New System.Drawing.Point(57, 12)
        Me.PB_Ico.Name = "PB_Ico"
        Me.PB_Ico.Size = New System.Drawing.Size(81, 75)
        Me.PB_Ico.TabIndex = 18
        Me.PB_Ico.ZoomControl = False
        Me.PB_Ico.ZoomFactory = 5.0R
        '
        'PropertiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(681, 394)
        Me.Controls.Add(Me.PB_Ico)
        Me.Controls.Add(Me.CB_LoveVersion)
        Me.Controls.Add(Me.LB_LoveVersion)
        Me.Controls.Add(Me.BT_Cancel)
        Me.Controls.Add(Me.BT_Accet)
        Me.Controls.Add(Me.TB_DateCreate)
        Me.Controls.Add(Me.LB_DateCreation)
        Me.Controls.Add(Me.LB_Ico)
        Me.Controls.Add(Me.BT_Shared)
        Me.Controls.Add(Me.TB_Ico)
        Me.Controls.Add(Me.TB_Company)
        Me.Controls.Add(Me.LB_Company)
        Me.Controls.Add(Me.TB_Version)
        Me.Controls.Add(Me.LB_Version)
        Me.Controls.Add(Me.TB_Author)
        Me.Controls.Add(Me.LB_Author)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PropertiesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Propiedades del proyecto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LB_Author As System.Windows.Forms.Label
    Friend WithEvents TB_Author As System.Windows.Forms.TextBox
    Friend WithEvents LB_Version As System.Windows.Forms.Label
    Friend WithEvents TB_Company As System.Windows.Forms.TextBox
    Friend WithEvents LB_Company As System.Windows.Forms.Label
    Friend WithEvents TB_Ico As System.Windows.Forms.TextBox
    Friend WithEvents BT_Shared As System.Windows.Forms.Button
    Friend WithEvents LB_Ico As System.Windows.Forms.Label
    Friend WithEvents TB_Version As System.Windows.Forms.TextBox
    Friend WithEvents TB_DateCreate As System.Windows.Forms.TextBox
    Friend WithEvents LB_DateCreation As System.Windows.Forms.Label
    Friend WithEvents BT_Accet As System.Windows.Forms.Button
    Friend WithEvents BT_Cancel As System.Windows.Forms.Button
    Friend WithEvents CB_LoveVersion As System.Windows.Forms.ComboBox
    Friend WithEvents LB_LoveVersion As System.Windows.Forms.Label
    Friend WithEvents PB_Ico As VisualLoveProject_2._0_Ultimate.UserPictureBox
End Class
