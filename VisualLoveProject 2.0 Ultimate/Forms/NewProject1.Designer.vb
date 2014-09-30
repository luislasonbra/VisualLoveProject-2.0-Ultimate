<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewProject
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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Project LÖVE", 0)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewProject))
        Me.LB_Text = New System.Windows.Forms.Label()
        Me.LV_Option = New System.Windows.Forms.ListView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CB_Version = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BT_Cancel = New System.Windows.Forms.Button()
        Me.BT_Ok = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TB_Text = New System.Windows.Forms.TextBox()
        Me.LB_Text2 = New System.Windows.Forms.Label()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LB_Text
        '
        Me.LB_Text.AutoSize = True
        Me.LB_Text.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Text.Location = New System.Drawing.Point(11, 11)
        Me.LB_Text.Name = "LB_Text"
        Me.LB_Text.Size = New System.Drawing.Size(110, 16)
        Me.LB_Text.TabIndex = 3
        Me.LB_Text.Text = "LÖVE Versiones:"
        '
        'LV_Option
        '
        Me.LV_Option.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LV_Option.HideSelection = False
        Me.LV_Option.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.LV_Option.LargeImageList = Me.ImageList1
        Me.LV_Option.Location = New System.Drawing.Point(0, 41)
        Me.LV_Option.MultiSelect = False
        Me.LV_Option.Name = "LV_Option"
        Me.LV_Option.Size = New System.Drawing.Size(576, 314)
        Me.LV_Option.SmallImageList = Me.ImageList1
        Me.LV_Option.TabIndex = 10
        Me.LV_Option.UseCompatibleStateImageBehavior = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "VSProject_genericproject.ico")
        Me.ImageList1.Images.SetKeyName(1, "EntryIcon_100.gif")
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(186, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.LB_Text)
        Me.Panel3.Controls.Add(Me.CB_Version)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(576, 41)
        Me.Panel3.TabIndex = 9
        '
        'CB_Version
        '
        Me.CB_Version.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_Version.FormattingEnabled = True
        Me.CB_Version.Items.AddRange(New Object() {"LOVE 0.8.0", "LOVE 0.7.2"})
        Me.CB_Version.Location = New System.Drawing.Point(127, 8)
        Me.CB_Version.Name = "CB_Version"
        Me.CB_Version.Size = New System.Drawing.Size(263, 24)
        Me.CB_Version.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BT_Cancel)
        Me.Panel2.Controls.Add(Me.BT_Ok)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 310)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(576, 45)
        Me.Panel2.TabIndex = 11
        '
        'BT_Cancel
        '
        Me.BT_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Cancel.ForeColor = System.Drawing.SystemColors.Highlight
        Me.BT_Cancel.Location = New System.Drawing.Point(488, 9)
        Me.BT_Cancel.Name = "BT_Cancel"
        Me.BT_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.BT_Cancel.TabIndex = 1
        Me.BT_Cancel.Text = "Cancelar"
        Me.BT_Cancel.UseVisualStyleBackColor = True
        '
        'BT_Ok
        '
        Me.BT_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT_Ok.ForeColor = System.Drawing.SystemColors.Highlight
        Me.BT_Ok.Location = New System.Drawing.Point(407, 9)
        Me.BT_Ok.Name = "BT_Ok"
        Me.BT_Ok.Size = New System.Drawing.Size(75, 23)
        Me.BT_Ok.TabIndex = 0
        Me.BT_Ok.Text = "Aceptar"
        Me.BT_Ok.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(186, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.Panel1.Controls.Add(Me.TB_Text)
        Me.Panel1.Controls.Add(Me.LB_Text2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 266)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(576, 44)
        Me.Panel1.TabIndex = 12
        '
        'TB_Text
        '
        Me.TB_Text.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_Text.Location = New System.Drawing.Point(79, 10)
        Me.TB_Text.Name = "TB_Text"
        Me.TB_Text.Size = New System.Drawing.Size(485, 22)
        Me.TB_Text.TabIndex = 4
        Me.TB_Text.Text = "Nombre del Proyecto"
        '
        'LB_Text2
        '
        Me.LB_Text2.AutoSize = True
        Me.LB_Text2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Text2.Location = New System.Drawing.Point(10, 13)
        Me.LB_Text2.Name = "LB_Text2"
        Me.LB_Text2.Size = New System.Drawing.Size(63, 16)
        Me.LB_Text2.TabIndex = 4
        Me.LB_Text2.Text = "Nombre: "
        '
        'NewProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 355)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LV_Option)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewProject"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nuevo Proyecto"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LB_Text As System.Windows.Forms.Label
    Friend WithEvents LV_Option As System.Windows.Forms.ListView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents CB_Version As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BT_Cancel As System.Windows.Forms.Button
    Friend WithEvents BT_Ok As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TB_Text As System.Windows.Forms.TextBox
    Friend WithEvents LB_Text2 As System.Windows.Forms.Label
End Class
