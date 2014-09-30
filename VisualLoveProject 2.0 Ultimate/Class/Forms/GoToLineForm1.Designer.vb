<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GoToLineForm1
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
        Me.TB_LineNumber = New System.Windows.Forms.TextBox()
        Me.LB_Text = New System.Windows.Forms.Label()
        Me.BT_Cloce = New System.Windows.Forms.Button()
        Me.BT_Ok = New System.Windows.Forms.Button()
        Me.TM_ControlTextLine = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'TB_LineNumber
        '
        Me.TB_LineNumber.Location = New System.Drawing.Point(13, 38)
        Me.TB_LineNumber.Name = "TB_LineNumber"
        Me.TB_LineNumber.Size = New System.Drawing.Size(364, 20)
        Me.TB_LineNumber.TabIndex = 7
        '
        'LB_Text
        '
        Me.LB_Text.AutoSize = True
        Me.LB_Text.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Text.Location = New System.Drawing.Point(13, 17)
        Me.LB_Text.Name = "LB_Text"
        Me.LB_Text.Size = New System.Drawing.Size(107, 16)
        Me.LB_Text.TabIndex = 6
        Me.LB_Text.Text = "Numero de linea"
        '
        'BT_Cloce
        '
        Me.BT_Cloce.Location = New System.Drawing.Point(302, 81)
        Me.BT_Cloce.Name = "BT_Cloce"
        Me.BT_Cloce.Size = New System.Drawing.Size(75, 23)
        Me.BT_Cloce.TabIndex = 5
        Me.BT_Cloce.Text = "Cancelar"
        Me.BT_Cloce.UseVisualStyleBackColor = True
        '
        'BT_Ok
        '
        Me.BT_Ok.Location = New System.Drawing.Point(221, 81)
        Me.BT_Ok.Name = "BT_Ok"
        Me.BT_Ok.Size = New System.Drawing.Size(75, 23)
        Me.BT_Ok.TabIndex = 4
        Me.BT_Ok.Text = "Aceptar"
        Me.BT_Ok.UseVisualStyleBackColor = True
        '
        'TM_ControlTextLine
        '
        Me.TM_ControlTextLine.Enabled = True
        Me.TM_ControlTextLine.Interval = 1
        '
        'GoToLineForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 120)
        Me.Controls.Add(Me.TB_LineNumber)
        Me.Controls.Add(Me.LB_Text)
        Me.Controls.Add(Me.BT_Cloce)
        Me.Controls.Add(Me.BT_Ok)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "GoToLineForm1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "GoToLine"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TB_LineNumber As System.Windows.Forms.TextBox
    Friend WithEvents LB_Text As System.Windows.Forms.Label
    Friend WithEvents BT_Cloce As System.Windows.Forms.Button
    Friend WithEvents BT_Ok As System.Windows.Forms.Button
    Friend WithEvents TM_ControlTextLine As System.Windows.Forms.Timer
End Class
