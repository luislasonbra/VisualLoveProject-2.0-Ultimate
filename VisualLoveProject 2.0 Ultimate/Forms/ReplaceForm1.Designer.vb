<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReplaceForm
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
        Me.BT_Cloce = New System.Windows.Forms.Button()
        Me.BT_ReplaceAll = New System.Windows.Forms.Button()
        Me.BT_Replace = New System.Windows.Forms.Button()
        Me.BT_FindNext = New System.Windows.Forms.Button()
        Me.TB_Replace = New System.Windows.Forms.TextBox()
        Me.LB_Text2 = New System.Windows.Forms.Label()
        Me.CB_Regex = New System.Windows.Forms.CheckBox()
        Me.CB_WholeWord = New System.Windows.Forms.CheckBox()
        Me.CB_MathCase = New System.Windows.Forms.CheckBox()
        Me.TB_Find = New System.Windows.Forms.TextBox()
        Me.LB_Text = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BT_Cloce
        '
        Me.BT_Cloce.Location = New System.Drawing.Point(393, 159)
        Me.BT_Cloce.Name = "BT_Cloce"
        Me.BT_Cloce.Size = New System.Drawing.Size(75, 23)
        Me.BT_Cloce.TabIndex = 21
        Me.BT_Cloce.Text = "Cerrar"
        Me.BT_Cloce.UseVisualStyleBackColor = True
        '
        'BT_ReplaceAll
        '
        Me.BT_ReplaceAll.Location = New System.Drawing.Point(369, 128)
        Me.BT_ReplaceAll.Name = "BT_ReplaceAll"
        Me.BT_ReplaceAll.Size = New System.Drawing.Size(99, 23)
        Me.BT_ReplaceAll.TabIndex = 20
        Me.BT_ReplaceAll.Text = "Reemplazar todo"
        Me.BT_ReplaceAll.UseVisualStyleBackColor = True
        '
        'BT_Replace
        '
        Me.BT_Replace.Location = New System.Drawing.Point(288, 128)
        Me.BT_Replace.Name = "BT_Replace"
        Me.BT_Replace.Size = New System.Drawing.Size(75, 23)
        Me.BT_Replace.TabIndex = 19
        Me.BT_Replace.Text = "Reemplazar"
        Me.BT_Replace.UseVisualStyleBackColor = True
        '
        'BT_FindNext
        '
        Me.BT_FindNext.Location = New System.Drawing.Point(168, 128)
        Me.BT_FindNext.Name = "BT_FindNext"
        Me.BT_FindNext.Size = New System.Drawing.Size(114, 23)
        Me.BT_FindNext.TabIndex = 18
        Me.BT_FindNext.Text = "Busqueda siguiente"
        Me.BT_FindNext.UseVisualStyleBackColor = True
        '
        'TB_Replace
        '
        Me.TB_Replace.Location = New System.Drawing.Point(103, 79)
        Me.TB_Replace.Name = "TB_Replace"
        Me.TB_Replace.Size = New System.Drawing.Size(365, 20)
        Me.TB_Replace.TabIndex = 17
        '
        'LB_Text2
        '
        Me.LB_Text2.AutoSize = True
        Me.LB_Text2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Text2.Location = New System.Drawing.Point(12, 80)
        Me.LB_Text2.Name = "LB_Text2"
        Me.LB_Text2.Size = New System.Drawing.Size(85, 16)
        Me.LB_Text2.TabIndex = 16
        Me.LB_Text2.Text = "Reemplazar:"
        '
        'CB_Regex
        '
        Me.CB_Regex.AutoSize = True
        Me.CB_Regex.Location = New System.Drawing.Point(369, 47)
        Me.CB_Regex.Name = "CB_Regex"
        Me.CB_Regex.Size = New System.Drawing.Size(57, 17)
        Me.CB_Regex.TabIndex = 15
        Me.CB_Regex.Text = "Regex"
        Me.CB_Regex.UseVisualStyleBackColor = True
        '
        'CB_WholeWord
        '
        Me.CB_WholeWord.AutoSize = True
        Me.CB_WholeWord.Location = New System.Drawing.Point(222, 47)
        Me.CB_WholeWord.Name = "CB_WholeWord"
        Me.CB_WholeWord.Size = New System.Drawing.Size(141, 17)
        Me.CB_WholeWord.TabIndex = 14
        Me.CB_WholeWord.Text = "Sólo palabras completas"
        Me.CB_WholeWord.UseVisualStyleBackColor = True
        '
        'CB_MathCase
        '
        Me.CB_MathCase.AutoSize = True
        Me.CB_MathCase.Location = New System.Drawing.Point(71, 47)
        Me.CB_MathCase.Name = "CB_MathCase"
        Me.CB_MathCase.Size = New System.Drawing.Size(145, 17)
        Me.CB_MathCase.TabIndex = 13
        Me.CB_MathCase.Text = "Mayúsculas y minúsculas"
        Me.CB_MathCase.UseVisualStyleBackColor = True
        '
        'TB_Find
        '
        Me.TB_Find.Location = New System.Drawing.Point(71, 12)
        Me.TB_Find.Name = "TB_Find"
        Me.TB_Find.Size = New System.Drawing.Size(397, 20)
        Me.TB_Find.TabIndex = 12
        '
        'LB_Text
        '
        Me.LB_Text.AutoSize = True
        Me.LB_Text.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Text.Location = New System.Drawing.Point(12, 13)
        Me.LB_Text.Name = "LB_Text"
        Me.LB_Text.Size = New System.Drawing.Size(53, 16)
        Me.LB_Text.TabIndex = 11
        Me.LB_Text.Text = "Buscar:"
        '
        'ReplaceForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 194)
        Me.Controls.Add(Me.BT_Cloce)
        Me.Controls.Add(Me.BT_ReplaceAll)
        Me.Controls.Add(Me.BT_Replace)
        Me.Controls.Add(Me.BT_FindNext)
        Me.Controls.Add(Me.TB_Replace)
        Me.Controls.Add(Me.LB_Text2)
        Me.Controls.Add(Me.CB_Regex)
        Me.Controls.Add(Me.CB_WholeWord)
        Me.Controls.Add(Me.CB_MathCase)
        Me.Controls.Add(Me.TB_Find)
        Me.Controls.Add(Me.LB_Text)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ReplaceForm1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Replace"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BT_Cloce As System.Windows.Forms.Button
    Friend WithEvents BT_ReplaceAll As System.Windows.Forms.Button
    Friend WithEvents BT_Replace As System.Windows.Forms.Button
    Friend WithEvents BT_FindNext As System.Windows.Forms.Button
    Friend WithEvents TB_Replace As System.Windows.Forms.TextBox
    Friend WithEvents LB_Text2 As System.Windows.Forms.Label
    Friend WithEvents CB_Regex As System.Windows.Forms.CheckBox
    Friend WithEvents CB_WholeWord As System.Windows.Forms.CheckBox
    Friend WithEvents CB_MathCase As System.Windows.Forms.CheckBox
    Friend WithEvents TB_Find As System.Windows.Forms.TextBox
    Friend WithEvents LB_Text As System.Windows.Forms.Label
End Class
