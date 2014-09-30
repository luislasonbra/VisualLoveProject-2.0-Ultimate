Imports FastColoredTextBoxNS
Imports System.Text.RegularExpressions
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports VisualLoveProject_2._0_Ultimate.AutoCompletad

Public Class SintaxisEditor

    Private BookMarksCode As New bookmarkCode

    'Estos colores se usan para el resatado de sintaxys.
    Public KeywordStyleColor As TextStyle = New TextStyle(Brushes.Blue, Nothing, FontStyle.Regular)
    Public FunctionStyleColor As TextStyle = New TextStyle(Brushes.RoyalBlue, Nothing, FontStyle.Regular)
    Public LoveFunctionStyleColor As TextStyle = New TextStyle(Brushes.RoyalBlue, Nothing, FontStyle.Regular)

    Public NumericStyleColor As TextStyle = New TextStyle(Brushes.Magenta, Nothing, FontStyle.Regular)
    Public LoveEventStyleColor As TextStyle = New TextStyle(Brushes.Magenta, Nothing, FontStyle.Regular)

    Public CommentStyleColor As TextStyle = New TextStyle(Brushes.Green, Nothing, FontStyle.Regular)
    Public StringStyleColor As TextStyle = New TextStyle(Brushes.Red, Nothing, FontStyle.Regular)
    Public CustomFunctionStyleColor As TextStyle = New TextStyle(Brushes.Maroon, Nothing, FontStyle.Regular)
    Public SpecialCharStyleColor As TextStyle = New TextStyle(Brushes.Black, Nothing, FontStyle.Regular)

    Public PointUnionStyleColor As TextStyle = New TextStyle(Brushes.Gray, Nothing, FontStyle.Regular)
    Public PointUnionStyleColor2 As TextStyle = New TextStyle(Brushes.Orange, Nothing, FontStyle.Regular)
    Public SameWordsStyle As MarkerStyle = New MarkerStyle(New SolidBrush(Color.FromArgb(40, Color.Gray)))
    Public StringOtherStyleColor As TextStyle = New TextStyle(Brushes.MediumVioletRed, Nothing, FontStyle.Regular)

    Public StringParentStyleColor As TextStyle = New TextStyle(Brushes.Green, Nothing, FontStyle.Regular)
    Public SpecialKeywordStyleColor As TextStyle = New TextStyle(Brushes.Black, Nothing, FontStyle.Regular)

    ' BoockMark Styles.
    Public BookMarckGradientStyleColorUp As Color = Color.AliceBlue
    Public BookMarckGradientStyleColorDown As Color = Color.DarkBlue
    Public BookMarckBorderStyleColor As Color = Color.PowderBlue

    ' Stylos para el control fctb.
    Public ControlChangedLineColor As Color = Color.FromArgb(255, 238, 98) ' Color = Amarillo.
    Public ControlChangedLineColor2 As Color = Color.FromArgb(108, 226, 108) ' Color = Verde.
    Public ControlCurrentLineColor As Color = Color.FromArgb(255, 255, 192) ' Color = Amarillo Claro.
    Public ControlSelectionColor As Color = Color.FromArgb(173, 214, 255) ' Color = Azul Cielo.
    Public ControlBackColor As Color = Color.White
    Public ControlForeColor As Color = Color.Black
    Public ControlIndentBackColor As Color = Color.White
    Public ControlLineNumberColor As Color = Color.Teal
    Public ControlServiceLinesColor As Color = Color.LightGray
    Public ControlCurrentBoockMarkColor As Color = Color.FromArgb(240, 240, 240)

    Public ControlMyColorFind As Color = Color.FromArgb(150, Color.Green)
    Public ControlCaretColor As Color = Color.Black
    Public ControlSelectionColorLostFocus = Color.FromArgb(255, 229, 235, 241)

    'Sintaxys de love y lua para el editor de codigo.
    Public Sub LuaSyntaxHighlight(ByVal sender As Object, ByVal e As TextChangedEventArgs)
        '
        If MainForm1.TM_ControlUpdate.Enabled = True Then
        Else
            MainForm1.TM_ControlUpdate.Start() 'Optimiza el uso de memoria.
        End If
        '
        If MainForm1.TC_Editor.SelectedTab.ImageIndex = 7 Then
        Else
            MainForm1.TC_Editor.SelectedTab.ImageIndex = 7
        End If
        '
        CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).LeftBracket = "("
        CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).RightBracket = ")"
        CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).LeftBracket2 = "{"
        CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox).RightBracket2 = "}"
        '
        'Borra el cambio de estilo de rango
        e.ChangedRange.ClearStyle(KeywordStyleColor, FunctionStyleColor, LoveFunctionStyleColor, _
        NumericStyleColor, LoveEventStyleColor, CommentStyleColor, StringStyleColor, _
        CustomFunctionStyleColor, SpecialCharStyleColor, PointUnionStyleColor, PointUnionStyleColor2, _
        StringOtherStyleColor, StringParentStyleColor)
        '---------------------------------------------------------------------------------------------------
        '
		' e.ChangedRange.SetStyle(Color1, """.*?""|"".*", RegexOptions.Singleline)
        ' ======================== Eliminar o mover si da problemas.------------------------------------
        'e.ChangedRange.SetStyle(StringStyleColor, """.*?""|'.+?'")
        e.ChangedRange.SetStyle(StringStyleColor, """""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'")
        'e.ChangedRange.SetStyle(StringStyleColor, """.*?""", RegexOptions.RightToLeft Or RegexOptions.Multiline)
        'e.ChangedRange.SetStyle(StringStyleColor, "'.+?'", RegexOptions.RightToLeft Or RegexOptions.Multiline)
        '
        e.ChangedRange.SetStyle(SpecialCharStyleColor, "\(|\)")
        '
        'resaltado nombre de clase
        'e.ChangedRange.SetStyle(CustomFunctionStyleColor, "\b(function)\s+(?<range>.*?[\(])", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(CustomFunctionStyleColor, "^\s*(?<range>function)\s+(?<range>.*?[\(])", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(CustomFunctionStyleColor, "^\s*(?<range>local\s+function)\s+(?<range>.*?[\(])", RegexOptions.Multiline)
        '
        e.ChangedRange.SetStyle(SpecialCharStyleColor, "\(|\)")
        '
        e.ChangedRange.SetStyle(StringParentStyleColor, "^\s*(?<range>function)\s+(?<range>.*?\(.*?\))", RegexOptions.Multiline)
        '
        e.ChangedRange.SetStyle(SpecialCharStyleColor, "\(|\)")
        '
        'e.ChangedRange.SetStyle(StringStyleColor, """.*?""|'.+?'")
        'e.ChangedRange.SetStyle(StringStyleColor, """.*?""", RegexOptions.RightToLeft Or RegexOptions.Multiline)
        'e.ChangedRange.SetStyle(StringStyleColor, "'.+?'", RegexOptions.RightToLeft Or RegexOptions.Multiline)
        e.ChangedRange.SetStyle(NumericStyleColor, "\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b")
        '
        e.ChangedRange.SetStyle(SpecialKeywordStyleColor, "(\=|\*|\+|\#|\-|\/)", RegexOptions.Multiline)
        '        
        e.ChangedRange.SetStyle(SpecialCharStyleColor, "\(|\)")
        '
        e.ChangedRange.SetStyle(StringParentStyleColor, "^\s*(?<range>function)\s+(?<range>.*?\(.*?\))", RegexOptions.Multiline)
        '
        e.ChangedRange.SetStyle(SpecialCharStyleColor, "\(|\)")
        '
        ' Color (67, 165, 23)
        'e.ChangedRange.SetStyle(ParentContentStyleColor, "function\s+(.+)", RegexOptions.Multiline)
        '
        'resaltado de palabras clave
        e.ChangedRange.SetStyle(KeywordStyleColor, "\b(and|break|do|else|elseif|end|false|for|function|if|in|local|nil|not|or|repeat|return|then|true|until|while)\b")
        '-------------coloreado 2----------------------------------------------------------
        e.ChangedRange.SetStyle(FunctionStyleColor, "\b(_VERSION|assert|collectgarbage|dofile|error|gcinfo|loadfile|loadstring|print|tonumber|tostring|type|unpack _ALERT|_ERRORMESSAGE|_INPUT|_PROMPT|_OUTPUT|_STDERR|_STDIN|_STDOUT|call|dostring|foreach|foreachi|getn globals|newtype|rawget|rawset|require|sort|tinsert|tremove|_G|getfenv|getmetatable|ipairs|loadlib|next pairs|pcall|rawegal|rawget|rawset|require|setfenv|setmetatable|xpcall|string|table|math|coroutine|io|os|debug)\b")
        '-------------coloreado 3----------------------------------------------------------
        e.ChangedRange.SetStyle(FunctionStyleColor, "\b(abs|acos|asin|atan|atan2|ceil|cos|deg|exp|floor|format|frexp|gsub|ldexp|log|log10|max|min|mod|rad|random randomseed|sin|sqrt|strbyte|strchar|strfind|strlen|strlower|strrep|strsub|strupper|tan|string.byte|string.char|string.dump|string.find|string.len|string.lower|string.rep|string.sub|string.upper|string.format|string.gfind|string.gsub|table.concat|table.foreach|table.foreachi|table.getn|table.sort|table.insert|table.remove|table.setn|math.abs|math.acos|math.asin|math.atan|math.atan2|math.ceil|math.cos|math.deg|math.exp|math.floor|math.frexp|math.ldexp|math.log|math.log10|math.max|math.min|math.mod|math.pi|math.rad|math.random|math.randomseed|math.sin|math.sqrt|math.tan)\b")
        '-------------coloreado 4----------------------------------------------------------
        e.ChangedRange.SetStyle(FunctionStyleColor, "\b(openfile|closefile|readfrom|writeto|appendto|remove|rename|flush|seek|tmpfile|tmpname|read|write|clock|date|difftime|execute|exit|getenv|setlocale|time|coroutine.create|coroutine.resume|coroutine.status|coroutine.wrap|coroutine.yield|io.close|io.flush|io.input|io.lines|io.open|io.output|io.read|io.tmpfile|io.type|io.write|io.stdin|io.stdout|io.stderr|os.clock|os.date|os.difftime|os.execute|os.exit|os.getenv|os.remove|os.rename|os.setlocale|os.time|os.tmpname)\b")
        '-------------coloreado 5----------------------------------------------------------
        '
        e.ChangedRange.SetStyle(PointUnionStyleColor, "(?<!\.)\.{2}(?!\.)", RegexOptions.Multiline)
        '
        e.ChangedRange.SetStyle(PointUnionStyleColor2, "(?<!\.)\.{3}(?!\.)", RegexOptions.Multiline)
        '
        '-----------------Love2d resaltado de sintaxis (graphics).---------------------------------------
        '
        'Coloreado de love2d functions.
        '
        'Types (Framebuffer) -- Eliminado en la version 0.8.0
        '
        e.ChangedRange.SetStyle(LoveFunctionStyleColor, "\b(Canvas|Drawable|Font|Image|ParticleSystem|PixelEffect|Quad|SpriteBatch)\b")
        '
        'Functions: ***************************************************************************************************** _
        '
        'Drawing
        '
        e.ChangedRange.SetStyle(LoveFunctionStyleColor, "\b(arc|circle|clear|draw|drawq|line|point|polygon|present|print|printf|quad|rectangle|triangle)\b")
        '
        'Object Creation (newFramebuffer) -- Eliminado en la version 0.8.0
        '
        e.ChangedRange.SetStyle(LoveFunctionStyleColor, "\b(newCanvas|newFont|newFramebuffer|newImage|newImageFont|newParticleSystem" _
        & "|newPixelEffect|newQuad|newScreenshot|newSpriteBatch|newStencil|setNewFont)\b")
        '
        'Graphics State (getLineStipple|setRenderTarget) -- Eliminado en la version 0.8.0
        '
        e.ChangedRange.SetStyle(LoveFunctionStyleColor, "\b(getBackgroundColor|getBlendMode|getCanvas|getColor|getColorMode|getDefaultImageFilter" _
        & "|getFont|getLineStipple|getLineStyle|getLineWidth|getMaxPointSize|getPixelEffect|getPointSize|getPointStyle" _
        & "|getScissor|isSupported|reset|setBackgroundColor|setBlendMode|setCanvas|setColor|setColorMask|setColorMode|setDefaultImageFilter" _
        & "|setFont|setInvertedStencil|setLine|setLineStipple|setLineStyle|setLineWidth|setPixelEffect|setPoint|setPointSize" _
        & "|setPointStyle|setRenderTarget|setScissor|setStencil)\b")
        '
        'Coordinate System
        '
        e.ChangedRange.SetStyle(LoveFunctionStyleColor, "\b(pop|push|rotate|scale|shear|translate)\b")
        '
        'Window (moved to love.window in 0.9.0+)
        '
        e.ChangedRange.SetStyle(LoveFunctionStyleColor, "\b(checkMode|getCaption|getHeight|getMode|getModes|getWidth|hasFocus" _
        & "|isCreated|setCaption|setIcon|setMode|toggleFullscreen)\b")
        '
        'Enums
        '
        e.ChangedRange.SetStyle(LoveFunctionStyleColor, "\b(AlignMode|BlendMode|ColorMode|DrawMode|FilterMode|GraphicsFeature|LineStyle" _
        & "|PointStyle|SpriteBatchUsage|WrapMode)\b")
        '
        'Coloreado 1
        e.ChangedRange.SetStyle(LoveEventStyleColor, "\b(love.draw|love.focus|love.joystickpressed)\b")
        'Coloreado 2
        e.ChangedRange.SetStyle(LoveEventStyleColor, "\b(love.joystickreleased|love.keypressed|love.keyreleased)\b")
        'Coloreado 3
        e.ChangedRange.SetStyle(LoveEventStyleColor, "\b(love.load|love.mousepressed|love.mousereleased|love.quit)\b")
        'Coloreado 4
        e.ChangedRange.SetStyle(LoveEventStyleColor, "\b(love.run|love.update|love.conf)\b")
        '
        'Comentarios de lua
        e.ChangedRange.SetStyle(CommentStyleColor, "--.*$", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(CommentStyleColor, "--\[\[.*?\]\]", RegexOptions.Singleline)
        e.ChangedRange.SetStyle(CommentStyleColor, "--\[\[.*?\]\]", RegexOptions.Singleline Or RegexOptions.RightToLeft)
        '
        '
        e.ChangedRange.SetStyle(StringOtherStyleColor, "\[\[.*?\]\]", RegexOptions.Singleline)
        e.ChangedRange.SetStyle(StringOtherStyleColor, "\[\[.*?\]\]", RegexOptions.Singleline Or RegexOptions.RightToLeft)
        '
        '
        'borra las marcas de los folding
        e.ChangedRange.ClearFoldingMarkers()
        '
        'crea los folding
        'e.ChangedRange.SetFoldingMarkers("^\s*(?<range>function|for|if|while)[ \t]+[^\s']+", "^\s*?(?<range>end)\b", RegexOptions.Multiline)
        '
        'e.ChangedRange.SetFoldingMarkers("^\s*(?<range>function|local\s+function|for|if|while)[ \t]+[^\s']+", "^(?!.*--).*\b(end)\b", _
        'RegexOptions.Multiline)
        '
        'e.ChangedRange.SetFoldingMarkers("^\s*(?<range>function|local\s+function|for|if|while)[ \t]+[^\s']+", "^(?!.*--).*\b(end)\b\s*$", _
        'RegexOptions.Multiline)
        '
        'e.ChangedRange.SetFoldingMarkers("^\s*\w*\s*=\s*(?<range>function|local\s+function)|" & _
        '"^\s*(?<range>function|local\s+function|for|if|while)[ \t]+[^\s']+", "^(?!.*--).*\b(end)\b\s*$", _
        'RegexOptions.Multiline)
        '
        e.ChangedRange.SetFoldingMarkers("^\s*\w*.*\s*=\s*(?<range>function|local\s+function)|" & _
        "^\s*(?<range>function|local\s+function|for|if|while)[ \t]+[^\s']+", "^(?!.*--).*\b(end)\b\s*$", _
        RegexOptions.Multiline)
        '
        'e.ChangedRange.SetFoldingMarkers("--\[\[", "^(?!.--).*(--\[\[).*\]]\s*$|^(?!.*--).*\]]\s*$", RegexOptions.Multiline)
        '
        e.ChangedRange.SetFoldingMarkers("^(?!.*--).*\[\[", "^(?!.*--).*\]]\s*$", RegexOptions.Multiline)
        e.ChangedRange.SetFoldingMarkers("^(?!.*--)(?!.*')(?!.*"").*(\{)", "^(?!.*--)(?!.*')(?!.*"").*(\})", RegexOptions.Multiline)
        'e.ChangedRange.SetFoldingMarkers("^(?!.*--).*(\{)", "^(?!.*--).*(\})", RegexOptions.Multiline)
        '
    End Sub

    ' Function para saver si el archivo normal ha sido modificado.
    Public Sub NormalTextValueChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
        '
        If MainForm1.TM_ControlUpdate.Enabled = True Then
        Else
            MainForm1.TM_ControlUpdate.Start() 'Optimiza el uso de memoria.
        End If
        '
        If MainForm1.TC_Editor.SelectedTab.ImageIndex = 7 Then
        Else
            MainForm1.TC_Editor.SelectedTab.ImageIndex = 7
        End If
        '
    End Sub

    'Actualiza el resaltado de los comentarios.
    Public Sub VisibleRangeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim range As Range = TryCast(sender, FastColoredTextBox).VisibleRange
        Dim range As Range = TryCast(sender, FastColoredTextBox).Range
        '
        range.ClearStyle(CommentStyleColor, StringOtherStyleColor, LoveEventStyleColor)
        'destacando comentario
        range.SetStyle(CommentStyleColor, "--.*$", RegexOptions.Multiline)
        range.SetStyle(CommentStyleColor, "(--\[\[.*?\]\])|(--\[\[.*)", RegexOptions.Singleline)
        range.SetStyle(CommentStyleColor, "(--\[\[.*?\]\]/)", RegexOptions.Singleline Or RegexOptions.RightToLeft)
        '
        range.SetStyle(StringOtherStyleColor, "(\[\[.*?\]\])|(\[\[.*)", RegexOptions.Singleline)
        range.SetStyle(StringOtherStyleColor, "(\[\[.*?\]\]/)", RegexOptions.Singleline Or RegexOptions.RightToLeft)
        '
        'Coloreado 1
        range.SetStyle(LoveEventStyleColor, "\b(love.draw|love.focus|love.joystickpressed)\b")
        'Coloreado 2
        range.SetStyle(LoveEventStyleColor, "\b(love.joystickreleased|love.keypressed|love.keyreleased)\b")
        'Coloreado 3
        range.SetStyle(LoveEventStyleColor, "\b(love.load|love.mousepressed|love.mousereleased|love.quit)\b")
        'Coloreado 4
        range.SetStyle(LoveEventStyleColor, "\b(love.run|love.update|love.conf)\b")
        '
    End Sub

    'Codigo para mostrar el ContextMenu en el editor de codigo.no disponible.
    Public Sub FastColoredTextBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'Dim FastColoredTextBox = CType(Form1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)

        'If e.Button = Windows.Forms.MouseButtons.Right Then
        '    Form1.CM_Edit.Show(FastColoredTextBox.PointToScreen(e.Location))

        '    'If FastColoredTextBox.SelectedText = "" Then
        '    'Else
        '    'FastColoredTextBox.SelectionStart = FastColoredTextBox.PointToPosition(e.Location)
        '    'FastColoredTextBox.Invalidate()
        '    'End If

        'End If

    End Sub

    'Comprueba que se algan efectuados cambios en el editor de codigo para poder declarar el guardado del codigo.
    Sub ChangeSaved(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If MainForm1.TC_Editor.SelectedTab.ImageIndex = 7 Then
            Else
                MainForm1.TC_Editor.SelectedTab.ImageIndex = 7
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Busca y resalta la parabra seleccionada.
    Public Sub SelectionChangedDelayed(ByVal sender As Object, ByVal e As EventArgs)

        Dim tb As FastColoredTextBox = TryCast(sender, FastColoredTextBox)
        tb.Range.ClearStyle(New Style() {tb.Styles(0)})
        If tb.Selection.IsEmpty Then
            Dim fragment As Range = tb.Selection.GetFragment("\w")
            Dim text As String = fragment.Text
            If text.Length <> 0 Then
                Dim ranges As Range() = tb.Range.GetRanges("\b" + text + "\b").ToArray()
                If ranges.Length > 1 Then
                    Dim array As Range() = ranges
                    For i As Integer = 0 To array.Length - 1
                        Dim r As Range = array(i)
                        r.SetStyle(tb.Styles(0))
                    Next
                End If
            End If
        End If

        '-------------------Eliminar si da problemas.-------------------------------
        'Dim fragment1 As Range = tb.Selection.GetFragment("\w")
        'Dim text1 As String = fragment1.Text
        ''highlight same words
        'Dim ranges1 As Range()

        ''If text1 = "function" OrElse text1 = "end" Then
        ''    ranges1 = tb.VisibleRange.GetRanges("\b(function|end)\b").ToArray()
        ''Else
        ''    ranges1 = tb.VisibleRange.GetRanges("\b" & text1 & "\b").ToArray()
        ''End If

        'If text1 = "if" OrElse text1 = "then" OrElse text1 = "elseif" OrElse text1 = "else" OrElse text1 = "end" Then
        '    ranges1 = tb.VisibleRange.GetRanges("\b(if|then|elseif|else|end)\b", RegexOptions.Multiline).ToArray()
        'Else
        '    ranges1 = tb.VisibleRange.GetRanges("\b" & text1 & "\b").ToArray()
        'End If

        'If ranges1.Length > 1 Then
        '    For Each r As Range In ranges1
        '        r.SetStyle(tb.Styles(0))
        '    Next
        'End If

    End Sub

    'BookMarks paintline.
    Public bookmarkSize As Integer = 15
    Public Sub FastColoredTextBox1_PaintLine(ByVal sender As Object, ByVal e As FastColoredTextBoxNS.PaintLineEventArgs)
        Dim Fctb1 = TryCast(sender, FastColoredTextBox)
        Dim info As TbInfo = Fctb1.Tag
        If info.bookmarksLineId.Contains(Fctb1(e.LineIndex).UniqueId) Then
            'Si el valor del bookmarksize es menor o igual a 0 se ejecuta esta function.
            If bookmarkSize = 0 Then
                bookmarkSize = 5
            End If
            e.Graphics.FillEllipse(New LinearGradientBrush(New Rectangle(0, e.LineRect.Top, bookmarkSize, bookmarkSize), BookMarckGradientStyleColorUp, BookMarckGradientStyleColorDown, 45.0F), 0, e.LineRect.Top, bookmarkSize, bookmarkSize)
            e.Graphics.DrawEllipse(New Pen(New SolidBrush(BookMarckBorderStyleColor)), 0, e.LineRect.Top, bookmarkSize, bookmarkSize)
        End If
    End Sub

    'Function para aumentar el tamaño del bookmarks.
    Public Sub UpdateSizeBookmarks()
        Dim Fctb1 = CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)
        Dim sizeBookmarks As Integer = Fctb1.Font.Size * 1.5
        bookmarkSize = sizeBookmarks 'Aumenta el tamaño del bookmark.
        ' MainForm1.Text = "Update size bookmarks: " & sizeBookmarks
        MainForm1.Zoom = 2
        If bookmarkSize = 15 Then
            bookmarkSize = 15 'Normaliza el tamaño del bookmark.
            MainForm1.Zoom = 13
        End If
    End Sub

    Public Sub FastColoredTextBox1_ZoomChanged(sender As Object, e As System.EventArgs)
        UpdateSizeBookmarks()
    End Sub

    'Add bookmarks or remove bookmarks.
    Public Sub FastColoredTextBox1_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Dim tb1 = CType(MainForm1.TC_Editor.SelectedTab.Controls.Item(0), FastColoredTextBox)

        Dim BookMarkCode As New bookmarkCode
        Dim info As TbInfo = TryCast(BookMarkCode.CurrentTB.Tag, TbInfo)

        If tb1.CurrentBoockMark.Contains(e.Location) Then
            Dim place = tb1.PointToPlace(e.Location)
            Dim id As Integer = BookMarkCode.CurrentTB(place.iLine).UniqueId

            If info.bookmarksLineId.Contains(id) Then
                'Remove boomark.
                info.bookmarks.Remove(id)
                info.bookmarksLineId.Remove(id)
                BookMarkCode.CurrentTB.Invalidate()
            Else
                'Add bookmark.
                info.bookmarks.Add(id)
                info.bookmarksLineId.Add(id)
                BookMarkCode.CurrentTB.Invalidate()
            End If

        End If

    End Sub

End Class

