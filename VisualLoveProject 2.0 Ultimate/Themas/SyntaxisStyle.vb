Imports FastColoredTextBoxNS

Public Class SyntaxisStyle

    Public Enum SyntaxisTheme
        [Default] = 0
        Black = 1
    End Enum

    Private SelectTheme As SyntaxisTheme
    Public Sub New()
        Me.SetTheme = SyntaxisTheme.Default
    End Sub

    Property SetTheme As SyntaxisTheme
        Get
            Return SelectTheme
        End Get
        Set(value As SyntaxisTheme)
            SelectTheme = value
        End Set
    End Property

    Public Sub ApplyTheme()
        Select Case SelectTheme
            Case SyntaxisTheme.Default
                DefaultTheme()
            Case SyntaxisTheme.Black
                BlackTheme()
        End Select
    End Sub

    Private Sub DefaultTheme()
        MainForm1.resaltado.KeywordStyleColor = New TextStyle(Brushes.Blue, Nothing, FontStyle.Regular)
        MainForm1.resaltado.FunctionStyleColor = New TextStyle(Brushes.RoyalBlue, Nothing, FontStyle.Regular)
        MainForm1.resaltado.LoveFunctionStyleColor = New TextStyle(Brushes.RoyalBlue, Nothing, FontStyle.Regular)
        MainForm1.resaltado.NumericStyleColor = New TextStyle(Brushes.Magenta, Nothing, FontStyle.Regular)
        MainForm1.resaltado.LoveEventStyleColor = New TextStyle(Brushes.Magenta, Nothing, FontStyle.Regular)
        MainForm1.resaltado.CommentStyleColor = New TextStyle(Brushes.Green, Nothing, FontStyle.Regular)
        MainForm1.resaltado.StringStyleColor = New TextStyle(Brushes.Red, Nothing, FontStyle.Regular)
        MainForm1.resaltado.CustomFunctionStyleColor = New TextStyle(Brushes.Maroon, Nothing, FontStyle.Regular)
        MainForm1.resaltado.SpecialCharStyleColor = New TextStyle(Brushes.Black, Nothing, FontStyle.Regular)
        MainForm1.resaltado.PointUnionStyleColor = New TextStyle(Brushes.Gray, Nothing, FontStyle.Regular)
        MainForm1.resaltado.PointUnionStyleColor2 = New TextStyle(Brushes.Orange, Nothing, FontStyle.Regular)
        MainForm1.resaltado.SameWordsStyle = New MarkerStyle(New SolidBrush(Color.FromArgb(40, Color.Gray)))
        MainForm1.resaltado.StringOtherStyleColor = New TextStyle(Brushes.MediumVioletRed, Nothing, FontStyle.Regular)
        MainForm1.resaltado.StringParentStyleColor = New TextStyle(Brushes.Green, Nothing, FontStyle.Regular)
        MainForm1.resaltado.SpecialKeywordStyleColor = New TextStyle(Brushes.Black, Nothing, FontStyle.Bold)

        ' BoockMark Styles.
        MainForm1.resaltado.BookMarckGradientStyleColorUp = Color.AliceBlue
        MainForm1.resaltado.BookMarckGradientStyleColorDown = Color.DarkBlue
        MainForm1.resaltado.BookMarckBorderStyleColor = Color.PowderBlue

        ' Stylos para el control fctb.
        MainForm1.resaltado.ControlChangedLineColor = Color.FromArgb(255, 238, 98) ' Color = Amarillo.
        MainForm1.resaltado.ControlChangedLineColor2 = Color.FromArgb(108, 226, 108) ' Color = Verde.
        MainForm1.resaltado.ControlCurrentLineColor = Color.FromArgb(226, 230, 214) 'Color.FromArgb(255, 255, 192)
        MainForm1.resaltado.ControlSelectionColor = Color.FromArgb(173, 214, 255)
        MainForm1.resaltado.ControlBackColor = Color.White
        MainForm1.resaltado.ControlForeColor = Color.Black
        MainForm1.resaltado.ControlIndentBackColor = Color.White
        MainForm1.resaltado.ControlLineNumberColor = Color.Teal
        MainForm1.resaltado.ControlServiceLinesColor = Color.LightGray
        MainForm1.resaltado.ControlCurrentBoockMarkColor = Color.FromArgb(224, 224, 224)

        MainForm1.resaltado.ControlMyColorFind = Color.FromArgb(150, Color.Green)

        MainForm1.resaltado.ControlCaretColor = Color.Black
        MainForm1.resaltado.ControlSelectionColorLostFocus = Color.FromArgb(255, 229, 235, 241)
    End Sub

    Private Sub BlackTheme()
        MainForm1.resaltado.KeywordStyleColor = New TextStyle(New SolidBrush(Color.FromArgb(249, 38, 114)), Nothing, FontStyle.Bold)
        MainForm1.resaltado.FunctionStyleColor = New TextStyle(New SolidBrush(Color.FromArgb(96, 217, 202)), Nothing, FontStyle.Bold)
        MainForm1.resaltado.LoveFunctionStyleColor = New TextStyle(Brushes.RoyalBlue, Nothing, FontStyle.Bold)
        MainForm1.resaltado.NumericStyleColor = New TextStyle(New SolidBrush(Color.FromArgb(174, 129, 255)), Nothing, FontStyle.Bold)
        MainForm1.resaltado.LoveEventStyleColor = New TextStyle(New SolidBrush(Color.FromArgb(166, 226, 46)), Nothing, FontStyle.Bold)
        MainForm1.resaltado.CommentStyleColor = New TextStyle(New SolidBrush(Color.FromArgb(109, 113, 94)), Nothing, FontStyle.Bold)
        MainForm1.resaltado.StringStyleColor = New TextStyle(New SolidBrush(Color.FromArgb(230, 219, 116)), Nothing, FontStyle.Bold)
        MainForm1.resaltado.CustomFunctionStyleColor = New TextStyle(New SolidBrush(Color.FromArgb(166, 226, 46)), Nothing, FontStyle.Bold)
        MainForm1.resaltado.SpecialCharStyleColor = New TextStyle(Brushes.White, Nothing, FontStyle.Bold)
        MainForm1.resaltado.PointUnionStyleColor = New TextStyle(New SolidBrush(Color.FromArgb(249, 38, 114)), Nothing, FontStyle.Bold)
        MainForm1.resaltado.PointUnionStyleColor2 = New TextStyle(New SolidBrush(Color.FromArgb(174, 129, 255)), Nothing, FontStyle.Bold)
        'MainForm1.resaltado.SameWordsStyle = New MarkerStyle(New SolidBrush(Color.FromArgb(40, Color.Gray)))
        'MainForm1.resaltado.StringOtherStyleColor = New TextStyle(Brushes.Orange, Nothing, FontStyle.Regular)
        MainForm1.resaltado.StringParentStyleColor = New TextStyle(Brushes.Orange, Nothing, FontStyle.Italic)
        MainForm1.resaltado.SpecialKeywordStyleColor = New TextStyle(New SolidBrush(Color.FromArgb(249, 38, 114)), Nothing, FontStyle.Bold)

        ' BoockMark Styles.
        MainForm1.resaltado.BookMarckGradientStyleColorUp = Color.AliceBlue
        MainForm1.resaltado.BookMarckGradientStyleColorDown = Color.DarkBlue
        MainForm1.resaltado.BookMarckBorderStyleColor = Color.Black

        ' Stylos para el control fctb.
        MainForm1.resaltado.ControlChangedLineColor = Color.FromArgb(255, 238, 98) ' Color = Amarillo.
        MainForm1.resaltado.ControlChangedLineColor2 = Color.FromArgb(108, 226, 108) ' Color = Verde.
        MainForm1.resaltado.ControlCurrentLineColor = Color.Transparent
        MainForm1.resaltado.ControlSelectionColor = Color.FromArgb(73, 72, 62) 'Color.FromArgb(173, 214, 255)
        MainForm1.resaltado.ControlBackColor = Color.FromArgb(39, 40, 34)
        MainForm1.resaltado.ControlForeColor = Color.White
        MainForm1.resaltado.ControlIndentBackColor = Color.FromArgb(39, 40, 34)
        MainForm1.resaltado.ControlLineNumberColor = Color.FromArgb(143, 144, 128)
        MainForm1.resaltado.ControlServiceLinesColor = Color.LightGray
        MainForm1.resaltado.ControlCurrentBoockMarkColor = Color.FromArgb(39, 40, 34)

        MainForm1.resaltado.ControlMyColorFind = Color.FromArgb(150, Color.MediumPurple)

        MainForm1.resaltado.ControlCaretColor = Color.White
        MainForm1.resaltado.ControlSelectionColorLostFocus = Color.FromArgb(56, 56, 48)
    End Sub

End Class
