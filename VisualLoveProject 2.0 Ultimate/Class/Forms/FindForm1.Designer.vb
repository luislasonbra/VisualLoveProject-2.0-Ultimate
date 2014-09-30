<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindForm1
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
        Me.CB_Regex = New System.Windows.Forms.CheckBox()
        Me.CB_WholeWord = New System.Windows.Forms.CheckBox()
        Me.CB_MathCase = New System.Windows.Forms.CheckBox()
        Me.TB_Find = New System.Windows.Forms.TextBox()
        Me.LB_Text = New System.Windows.Forms.Label()
        Me.BT_Cloce = New System.Windows.Forms.Button()
        Me.BT_FintNext = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CB_Regex
        '
        Me.CB_Regex.AutoSize = True
        Me.CB_Regex.Location = New System.Drawing.Point(71, 59)
        Me.CB_Regex.Name = "CB_Regex"
        Me.CB_Regex.Size = New System.Drawing.Size(57, 17)
        Me.CB_Regex.TabIndex = 13
        Me.CB_Regex.Text = "Regex"
        Me.CB_Regex.UseVisualStyleBackColor = True
        '
        'CB_WholeWord
        '
        Me.CB_WholeWord.AutoSize = True
        Me.CB_WholeWord.Location = New System.Drawing.Point(229, 36)
        Me.CB_WholeWord.Name = "CB_WholeWord"
        Me.CB_WholeWord.Size = New System.Drawing.Size(141, 17)
        Me.CB_WholeWord.TabIndex = 12
        Me.CB_WholeWord.Text = "Sólo palabras completas"
        Me.CB_WholeWord.UseVisualStyleBackColor = True
        '
        'CB_MathCase
        '
        Me.CB_MathCase.AutoSize = True
        Me.CB_MathCase.Location = New System.Drawing.Point(71, 36)
        Me.CB_MathCase.Name = "CB_MathCase"
        Me.CB_MathCase.Size = New System.Drawing.Size(145, 17)
        Me.CB_MathCase.TabIndex = 11
        Me.CB_MathCase.Text = "Mayúsculas y minúsculas"
        Me.CB_MathCase.UseVisualStyleBackColor = True
        '
        'TB_Find
        '
        Me.TB_Find.Location = New System.Drawing.Point(71, 10)
        Me.TB_Find.Name = "TB_Find"
        Me.TB_Find.Size = New System.Drawing.Size(351, 20)
        Me.TB_Find.TabIndex = 10
        '
        'LB_Text
        '
        Me.LB_Text.AutoSize = True
        Me.LB_Text.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Text.Location = New System.Drawing.Point(12, 11)
        Me.LB_Text.Name = "LB_Text"
        Me.LB_Text.Size = New System.Drawing.Size(53, 16)
        Me.LB_Text.TabIndex = 9
        Me.LB_Text.Text = "Buscar:"
        '
        'BT_Cloce
        '
        Me.BT_Cloce.Location = New System.Drawing.Point(348, 92)
        Me.BT_Cloce.Name = "BT_Cloce"
        Me.BT_Cloce.Size = New System.Drawing.Size(75, 23)
        Me.BT_Cloce.TabIndex = 8
        Me.BT_Cloce.Text = "Cerrar"
        Me.BT_Cloce.UseVisualStyleBackColor = True
        '
        'BT_FintNext
        '
        Me.BT_FintNext.Location = New System.Drawing.Point(229, 92)
        Me.BT_FintNext.Name = "BT_FintNext"
        Me.BT_FintNext.Size = New System.Drawing.Size(113, 23)
        Me.BT_FintNext.TabIndex = 7
        Me.BT_FintNext.Text = "Busqueda siguiente"
        Me.BT_FintNext.UseVisualStyleBackColor = True
        '
        'FindForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 125)
        Me.Controls.Add(Me.CB_Regex)
        Me.Controls.Add(Me.CB_WholeWord)
        Me.Controls.Add(Me.CB_MathCase)
        Me.Controls.Add(Me.TB_Find)
        Me.Controls.Add(Me.LB_Text)
        Me.Controls.Add(Me.BT_Cloce)
        Me.Controls.Add(Me.BT_FintNext)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FindForm1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Buscar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CB_Regex As System.Windows.Forms.CheckBox
    Friend WithEvents CB_WholeWord As System.Windows.Forms.CheckBox
    Friend WithEvents CB_MathCase As System.Windows.Forms.CheckBox
    Friend WithEvents TB_Find As System.Windows.Forms.TextBox
    Friend WithEvents LB_Text As System.Windows.Forms.Label
    Friend WithEvents BT_Cloce As System.Windows.Forms.Button
    Friend WithEvents BT_FintNext As System.Windows.Forms.Button
End Class
