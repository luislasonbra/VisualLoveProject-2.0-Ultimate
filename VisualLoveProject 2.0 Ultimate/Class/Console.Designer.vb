<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Console
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.CMS_Console = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CM_Copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.CM_Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lb_Minimize = New System.Windows.Forms.Label()
        Me.Lb_Close = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.TM_Control = New System.Windows.Forms.Timer(Me.components)
        Me.C_Text = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.CMS_Console.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CMS_Console
        '
        Me.CMS_Console.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CM_Copy, Me.CM_Save})
        Me.CMS_Console.Name = "ContextMenuStrip1"
        Me.CMS_Console.Size = New System.Drawing.Size(117, 48)
        '
        'CM_Copy
        '
        Me.CM_Copy.Name = "CM_Copy"
        Me.CM_Copy.Size = New System.Drawing.Size(116, 22)
        Me.CM_Copy.Text = "Copiar"
        '
        'CM_Save
        '
        Me.CM_Save.Name = "CM_Save"
        Me.CM_Save.Size = New System.Drawing.Size(116, 22)
        Me.CM_Save.Text = "Guardar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Lb_Minimize)
        Me.Panel1.Controls.Add(Me.Lb_Close)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(493, 16)
        Me.Panel1.TabIndex = 5
        '
        'Lb_Minimize
        '
        Me.Lb_Minimize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_Minimize.AutoSize = True
        Me.Lb_Minimize.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Minimize.ForeColor = System.Drawing.Color.White
        Me.Lb_Minimize.Location = New System.Drawing.Point(461, -2)
        Me.Lb_Minimize.Name = "Lb_Minimize"
        Me.Lb_Minimize.Size = New System.Drawing.Size(15, 16)
        Me.Lb_Minimize.TabIndex = 7
        Me.Lb_Minimize.Text = "-"
        Me.Lb_Minimize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Lb_Minimize.Visible = False
        '
        'Lb_Close
        '
        Me.Lb_Close.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_Close.AutoSize = True
        Me.Lb_Close.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Close.ForeColor = System.Drawing.Color.White
        Me.Lb_Close.Location = New System.Drawing.Point(478, -1)
        Me.Lb_Close.Name = "Lb_Close"
        Me.Lb_Close.Size = New System.Drawing.Size(17, 16)
        Me.Lb_Close.TabIndex = 6
        Me.Lb_Close.Text = "X"
        Me.Lb_Close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Consola"
        '
        'TM_Control
        '
        Me.TM_Control.Enabled = True
        Me.TM_Control.Interval = 1
        '
        'C_Text
        '
        Me.C_Text.BackColor = System.Drawing.SystemColors.InfoText
        Me.C_Text.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.C_Text.ContextMenuStrip = Me.CMS_Console
        Me.C_Text.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C_Text.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C_Text.ForeColor = System.Drawing.Color.White
        Me.C_Text.Location = New System.Drawing.Point(3, 3)
        Me.C_Text.Multiline = True
        Me.C_Text.Name = "C_Text"
        Me.C_Text.ReadOnly = True
        Me.C_Text.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.C_Text.Size = New System.Drawing.Size(479, 144)
        Me.C_Text.TabIndex = 7
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 16)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(493, 176)
        Me.TabControl1.TabIndex = 8
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Black
        Me.TabPage1.Controls.Add(Me.C_Text)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(485, 150)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Depurador"
        '
        'Console
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Console"
        Me.Size = New System.Drawing.Size(493, 192)
        Me.CMS_Console.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SaveDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents TM_Control As System.Windows.Forms.Timer
    Friend WithEvents CMS_Console As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CM_Copy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CM_Save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Lb_Close As System.Windows.Forms.Label
    Friend WithEvents Lb_Minimize As System.Windows.Forms.Label
    Friend WithEvents C_Text As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage

End Class
