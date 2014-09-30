<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputBoxCustom1
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
        Me.Lb_Text = New System.Windows.Forms.Label()
        Me.TB_Text = New System.Windows.Forms.TextBox()
        Me.Bt_Accept = New System.Windows.Forms.Button()
        Me.Bt_Cancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Lb_Text
        '
        Me.Lb_Text.AutoSize = True
        Me.Lb_Text.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Text.Location = New System.Drawing.Point(12, 25)
        Me.Lb_Text.Name = "Lb_Text"
        Me.Lb_Text.Size = New System.Drawing.Size(34, 16)
        Me.Lb_Text.TabIndex = 0
        Me.Lb_Text.Text = "Text"
        '
        'TB_Text
        '
        Me.TB_Text.Location = New System.Drawing.Point(15, 56)
        Me.TB_Text.Name = "TB_Text"
        Me.TB_Text.Size = New System.Drawing.Size(370, 20)
        Me.TB_Text.TabIndex = 1
        '
        'Bt_Accept
        '
        Me.Bt_Accept.Location = New System.Drawing.Point(229, 82)
        Me.Bt_Accept.Name = "Bt_Accept"
        Me.Bt_Accept.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Accept.TabIndex = 2
        Me.Bt_Accept.Text = "Accept"
        Me.Bt_Accept.UseVisualStyleBackColor = True
        '
        'Bt_Cancel
        '
        Me.Bt_Cancel.Location = New System.Drawing.Point(310, 82)
        Me.Bt_Cancel.Name = "Bt_Cancel"
        Me.Bt_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancel.TabIndex = 3
        Me.Bt_Cancel.Text = "Cancel"
        Me.Bt_Cancel.UseVisualStyleBackColor = True
        '
        'InputBoxCustom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 114)
        Me.Controls.Add(Me.Bt_Cancel)
        Me.Controls.Add(Me.Bt_Accept)
        Me.Controls.Add(Me.TB_Text)
        Me.Controls.Add(Me.Lb_Text)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InputBoxCustom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lb_Text As System.Windows.Forms.Label
    Friend WithEvents TB_Text As System.Windows.Forms.TextBox
    Friend WithEvents Bt_Accept As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancel As System.Windows.Forms.Button
End Class
