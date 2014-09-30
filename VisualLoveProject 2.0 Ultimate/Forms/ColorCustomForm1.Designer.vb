<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColorCustomForm1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ColorCustomForm1))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UserTrackBar4 = New VisualLoveProject_2._0_Ultimate.UserTrackBar()
        Me.UserTrackBar3 = New VisualLoveProject_2._0_Ultimate.UserTrackBar()
        Me.UserTrackBar2 = New VisualLoveProject_2._0_Ultimate.UserTrackBar()
        Me.UserTrackBar1 = New VisualLoveProject_2._0_Ultimate.UserTrackBar()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(283, 136)
        Me.Panel1.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(281, 134)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(238, 281)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(57, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 154)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Rojo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 183)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Verde:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 212)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Azul:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 241)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Alpha:"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(58, 283)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(174, 20)
        Me.TextBox1.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 284)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Code:"
        '
        'UserTrackBar4
        '
        Me.UserTrackBar4.BackColor = System.Drawing.Color.Transparent
        Me.UserTrackBar4.BarInnerColor = System.Drawing.Color.DarkRed
        Me.UserTrackBar4.BarOuterColor = System.Drawing.Color.Red
        Me.UserTrackBar4.BorderRoundRectSize = New System.Drawing.Size(8, 8)
        Me.UserTrackBar4.ColorSchema = VisualLoveProject_2._0_Ultimate.UserTrackBar.ColorSchemas.PerlRedCoral
        Me.UserTrackBar4.DrawFocusRectangle = False
        Me.UserTrackBar4.ElapsedInnerColor = System.Drawing.Color.LightCoral
        Me.UserTrackBar4.ElapsedOuterColor = System.Drawing.Color.Coral
        Me.UserTrackBar4.LargeChange = CType(5UI, UInteger)
        Me.UserTrackBar4.Location = New System.Drawing.Point(64, 241)
        Me.UserTrackBar4.Maximum = 255
        Me.UserTrackBar4.MouseEffects = False
        Me.UserTrackBar4.Name = "UserTrackBar4"
        Me.UserTrackBar4.Size = New System.Drawing.Size(231, 23)
        Me.UserTrackBar4.SmallChange = CType(1UI, UInteger)
        Me.UserTrackBar4.TabIndex = 4
        Me.UserTrackBar4.ThumbRoundRectSize = New System.Drawing.Size(8, 8)
        Me.UserTrackBar4.Value = 255
        '
        'UserTrackBar3
        '
        Me.UserTrackBar3.BackColor = System.Drawing.Color.Transparent
        Me.UserTrackBar3.BorderRoundRectSize = New System.Drawing.Size(8, 8)
        Me.UserTrackBar3.DrawFocusRectangle = False
        Me.UserTrackBar3.ElapsedInnerColor = System.Drawing.SystemColors.Highlight
        Me.UserTrackBar3.ElapsedOuterColor = System.Drawing.SystemColors.HotTrack
        Me.UserTrackBar3.LargeChange = CType(5UI, UInteger)
        Me.UserTrackBar3.Location = New System.Drawing.Point(61, 212)
        Me.UserTrackBar3.Maximum = 255
        Me.UserTrackBar3.MouseEffects = False
        Me.UserTrackBar3.Name = "UserTrackBar3"
        Me.UserTrackBar3.Size = New System.Drawing.Size(234, 23)
        Me.UserTrackBar3.SmallChange = CType(1UI, UInteger)
        Me.UserTrackBar3.TabIndex = 3
        Me.UserTrackBar3.ThumbRoundRectSize = New System.Drawing.Size(8, 8)
        Me.UserTrackBar3.Value = 0
        '
        'UserTrackBar2
        '
        Me.UserTrackBar2.BackColor = System.Drawing.Color.Transparent
        Me.UserTrackBar2.BarInnerColor = System.Drawing.Color.Green
        Me.UserTrackBar2.BarOuterColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.UserTrackBar2.BorderRoundRectSize = New System.Drawing.Size(8, 8)
        Me.UserTrackBar2.DrawFocusRectangle = False
        Me.UserTrackBar2.LargeChange = CType(5UI, UInteger)
        Me.UserTrackBar2.Location = New System.Drawing.Point(61, 183)
        Me.UserTrackBar2.Maximum = 255
        Me.UserTrackBar2.MouseEffects = False
        Me.UserTrackBar2.Name = "UserTrackBar2"
        Me.UserTrackBar2.Size = New System.Drawing.Size(234, 23)
        Me.UserTrackBar2.SmallChange = CType(1UI, UInteger)
        Me.UserTrackBar2.TabIndex = 2
        Me.UserTrackBar2.ThumbRoundRectSize = New System.Drawing.Size(8, 8)
        Me.UserTrackBar2.Value = 0
        '
        'UserTrackBar1
        '
        Me.UserTrackBar1.BackColor = System.Drawing.Color.Transparent
        Me.UserTrackBar1.BarInnerColor = System.Drawing.Color.Maroon
        Me.UserTrackBar1.BarOuterColor = System.Drawing.Color.Maroon
        Me.UserTrackBar1.BorderRoundRectSize = New System.Drawing.Size(8, 8)
        Me.UserTrackBar1.DrawFocusRectangle = False
        Me.UserTrackBar1.ElapsedInnerColor = System.Drawing.Color.Red
        Me.UserTrackBar1.ElapsedOuterColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.UserTrackBar1.LargeChange = CType(5UI, UInteger)
        Me.UserTrackBar1.Location = New System.Drawing.Point(61, 154)
        Me.UserTrackBar1.Maximum = 255
        Me.UserTrackBar1.MouseEffects = False
        Me.UserTrackBar1.Name = "UserTrackBar1"
        Me.UserTrackBar1.Size = New System.Drawing.Size(234, 23)
        Me.UserTrackBar1.SmallChange = CType(1UI, UInteger)
        Me.UserTrackBar1.TabIndex = 0
        Me.UserTrackBar1.ThumbRoundRectSize = New System.Drawing.Size(8, 8)
        Me.UserTrackBar1.Value = 0
        '
        'ColorCustomForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(307, 316)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.UserTrackBar4)
        Me.Controls.Add(Me.UserTrackBar3)
        Me.Controls.Add(Me.UserTrackBar2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.UserTrackBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ColorCustomForm1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Color View"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UserTrackBar1 As VisualLoveProject_2._0_Ultimate.UserTrackBar
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UserTrackBar2 As VisualLoveProject_2._0_Ultimate.UserTrackBar
    Friend WithEvents UserTrackBar3 As VisualLoveProject_2._0_Ultimate.UserTrackBar
    Friend WithEvents UserTrackBar4 As VisualLoveProject_2._0_Ultimate.UserTrackBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
