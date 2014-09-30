Imports System.IO
Imports FastColoredTextBoxNS
Imports System.Text.RegularExpressions

Public Class Console

    Dim Reserved As Integer
    Dim KeyMinimize As Boolean = False
    Private BorderRatios As Integer = 5

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        SetStyle(ControlStyles.AllPaintingInWmPaint Or _
                 ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.ResizeRedraw Or _
                 ControlStyles.SupportsTransparentBackColor Or _
                 ControlStyles.UserPaint, True)

        Me.DoubleBuffered = True

        Dim StyleBorder As New PropertyOptions
        Dim r As New Rectangle(0, 0, Me.Width, Me.Height)
        Me.Region = New Region(StyleBorder.CreateRoundRectGraphicsPath2(r, BorderRatios))

    End Sub

    Private Sub Lb_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lb_Close.Click
        Me.Visible = False
    End Sub

    'Se produce cuando el mouse esta encima del label.
    Private Sub Lb_Close_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lb_Close.MouseHover
        Lb_Close.ForeColor = Color.Black
        Lb_Close.BackColor = Color.FromArgb(255, 243, 209)
    End Sub

    'Se produce cuando el mouse esta fuera del label.
    Private Sub Lb_Close_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lb_Close.MouseLeave
        Lb_Close.ForeColor = Color.White
        Lb_Close.BackColor = Color.FromArgb(66, 86, 122)
    End Sub

    'Se produce cuando el mouse es precionado encima del label.
    Private Sub Lb_Close_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Lb_Close.MouseDown
        Lb_Close.BackColor = Color.FromArgb(255, 232, 166)
    End Sub

    Private Sub CM_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CM_Copy.Click
        Dim C_Text_Control = CType(TabControl1.SelectedTab.Controls.Item(0), TextBox)
        C_Text_Control.Copy()
    End Sub

    Private Sub CM_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CM_Save.Click
        Dim C_Text_Control = CType(TabControl1.SelectedTab.Controls.Item(0), TextBox)
        SaveDialog.FileName = ""

        SaveDialog.Filter = "Txt file|*.txt"

        If SaveDialog.ShowDialog = DialogResult.OK Then
            Try
                Dim ruta As New StreamWriter(SaveDialog.FileName)
                Dim Texto As String = C_Text_Control.Text & vbNewLine
                ruta.Write(Texto)
                ruta.Close()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub TM_Control_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TM_Control.Tick
        Try
            If C_Text.SelectedText = "" Then
                CM_Copy.Enabled = False
            Else
                CM_Copy.Enabled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub C_Text_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_Text.Load
    '    'C_Text.CurrentLineColor = Color.Black
    'End Sub

    Dim PurpleStyle As TextStyle = New TextStyle(Brushes.Purple, Nothing, FontStyle.Regular)
    Dim MagentaStyle As TextStyle = New TextStyle(Brushes.Magenta, Nothing, FontStyle.Regular)
    Dim GreenStyle As TextStyle = New TextStyle(Brushes.Green, Nothing, FontStyle.Regular)
    Dim RedStyle As TextStyle = New TextStyle(Brushes.Red, Nothing, FontStyle.Regular)

    'Private Sub C_Text_TextChanged(ByVal sender As Object, ByVal e As FastColoredTextBoxNS.TextChangedEventArgs) Handles C_Text.TextChanged

    '    'C_Text.LeftBracket = "("
    '    'C_Text.RightBracket = ")"
    '    'C_Text.LeftBracket2 = "{"
    '    'C_Text.RightBracket2 = "}"

    '    ''Borra el cambio de estilo de rango
    '    'e.ChangedRange.ClearStyle(MagentaStyle, GreenStyle, RedStyle, PurpleStyle)
    '    ''---------------------------------------------------------------------------------------------------
    '    'e.ChangedRange.SetStyle(RedStyle, """.*?""|'.+?'")
    '    'e.ChangedRange.SetStyle(MagentaStyle, "\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b")

    '    'e.ChangedRange.SetStyle(RedStyle, "... Ok|>")

    '    ''Comentarios de lua
    '    'e.ChangedRange.SetStyle(GreenStyle, "--.*$", RegexOptions.Multiline)

    '    ''comentarios
    '    'Dim range As Range = TryCast(sender, FastColoredTextBox).VisibleRange
    '    'range.ClearStyle(GreenStyle)
    '    ''destacando comentario
    '    'range.SetStyle(GreenStyle, "--.*$", RegexOptions.Multiline)

    'End Sub

    '-------------------------Botton minimisar--------------------------------------------------------

    'Se produce cuando el mouse esta encima del label.

    Private Sub Lb_Minimize_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lb_Minimize.MouseHover
        Lb_Minimize.ForeColor = Color.Black
        Lb_Minimize.BackColor = Color.FromArgb(255, 243, 209)
    End Sub

    'Se produce cuando el mouse esta fuera del label.
    Private Sub Lb_Minimize_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lb_Minimize.MouseLeave
        Lb_Minimize.ForeColor = Color.White
        Lb_Minimize.BackColor = Color.FromArgb(66, 86, 122)
    End Sub

    'Se produce cuando el mouse es precionado encima del label.
    Private Sub Lb_Minimize_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Lb_Minimize.MouseDown
        Lb_Minimize.BackColor = Color.FromArgb(255, 232, 166)
    End Sub

    Private Sub Lb_Minimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lb_Minimize.Click
        If KeyMinimize = False Then
            Reserved = Me.Height
            Dim i As Integer = 0
            For i = -Me.Height To 18 Step 1
                Me.Size = New Size(Me.Width, i)
            Next
            KeyMinimize = True
        Else
            Dim i As Integer = 0
            For i = 18 To Reserved Step 10
                Me.Size = New Size(Me.Width, i)
            Next
            KeyMinimize = False
        End If
    End Sub

    Private Sub Console_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim StyleBorder As New PropertyOptions
        Dim r As New Rectangle(0, 0, Me.Width, Me.Height)
        Me.Region = New Region(StyleBorder.CreateRoundRectGraphicsPath2(r, BorderRatios))
    End Sub

End Class
