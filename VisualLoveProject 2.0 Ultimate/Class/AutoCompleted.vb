Imports FastColoredTextBoxNS
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Linq
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms

Public Class AutoCompletad
    'Inherits Form

    Public popupMenu As AutocompleteMenu
    Public items As List(Of AutocompleteItem) = New List(Of AutocompleteItem)()
    Public array As String()

    Public keywords As String() = {"_VERSION", "assert", "collectgarbage", "dofile", "error", "gcinfo", _
        "loadfile", "loadstring", "print", "tonumber", "tostring", "type", _
        "unpack", "_ALERT", "_ERRORMESSAGE", "_INPUT", "_PROMPT", "_OUTPUT", _
        "_STDERR", "_STDIN", "_STDOUT", "call", "dostring", "foreach", _
        "foreachi", "getn", "globals", "newtype", "rawget", "rawset", "require", _
        "sort", "tinsert", "tremove", "_G", "getfenv", "getmetatable", "ipairs", _
        "loadlib", "next", "pairs", "pcall", "rawegal", _
        "setfenv", "setmetatable", "xpcall", "string", "table", _
        "math", "coroutine", "io", "os", "debug", "and", "break", "do", _
        "else", "elseif", "end", "false", "for", "function", "if", "in", _
        "local", "nil", "not", "or", "repeat", "return", "then", "true", _
        "until", "while", "abs", "acos", "asin", "atan", "atan2", "ceil", "cos", _
        "deg", "exp", "floor", "format", "frexp", "gsub", "ldexp", "log", _
        "log10", "max", "min", "mod", "rad", "random", "randomseed", "sin", _
        "sqrt", "strbyte", "strchar", "strfind", "strlen", "strlower", _
        "strrep", "strsub", "strupper", "tan", "string.byte", _
        "string.char", "string.dump", "string.find", "string.len", _
        "string.lower", "string.rep", "string.sub", "string.upper", _
        "string.format", "string.gfind", "string.gsub", "table.concat", _
        "table.foreach", "table.foreachi", "table.getn", "table.sort", _
        "table.insert", "table.remove", "table.setn", "math.abs", _
        "math.acos", "math.asin", "math.atan", "math.atan2", _
        "math.ceil", "math.cos", "math.deg", "math.exp", _
        "math.floor", "math.frexp", "math.ldexp", "math.log", _
        "math.log10", "math.max", "math.min", "math.mod", _
        "math.pi", "math.rad", "math.random", "math.randomseed", _
        "math.sin", "math.sqrt", "math.tan", "openfile", "closefile", _
        "readfrom", "writeto", "appendto", "remove", "rename", _
        "flush", "seek", "tmpfile", "tmpname", "read", "write", "clock", _
        "date", "difftime", "execute", "exit", "getenv", "setlocale", "time", _
        "coroutine.create", "coroutine.resume", "coroutine.status", _
        "coroutine.wrap", "coroutine.yield", "io.close", "io.flush", _
        "io.input", "io.lines", "io.open", "io.output", "io.read", _
        "io.tmpfile", "io.type", "io.write", "io.stdin", "io.stdout", _
        "io.stderr", "os.clock", "os.date", "os.difftime", "os.execute", _
        "os.exit", "os.getenv", "os.remove", "os.rename", "os.setlocale", _
        "os.time", "os.tmpname", "love", "audio", "event", "filesystem", "font", "graphics", _
        "image", "joystick", "keyboard", "mouse", "physics", "sound", _
        "thread", "timer", "getDistanceModel", "getNumSources", "getOrientation", _
        "getPosition", "getVelocity", "getVolume", "newSource", "pause", _
        "play", "resume", "rewind", "setDistanceModel", "setOrientation", _
        "setPosition", "setVelocity", "setVolume", "stop", "clear", _
        "poll", "pump", "push", "quit", "wait", "enumerate", "exists", _
        "getAppdataDirectory", "getLastModified", "getSaveDirectory", _
        "getUserDirectory", "getWorkingDirectory", "init", "isDirectory", _
        "isFile", "lines", "mkdir", "newFile", "newFileData", _
        "read", "remove", "setIdentity", "setSource", "write", _
        "newFontData", "newGlyphData", "newRasterizer", "arc", _
        "checkMode", "circle", "clear", "draw", "drawq", _
        "getBlendMode", "getCanvas", "getCaption", "getColor", "getColorMode", _
        "getFont", "getHeight", "getLineStipple", _
        "getLineStyle", "getLineWidth", "getMaxPointSize", "getMode", _
        "getModes", "getPixelEffect", "getPointSize", "getPointStyle", _
        "getScissor", "getWidth", "hasFocus", "isCreated", "isSupported", _
        "line", "newCanvas", "newFont", "newFramebuffer", "newImage", _
        "newImageFont", "newParticleSystem", "newPixelEffect", _
        "newQuad", "newScreenshot", "newSpriteBatch", "newStencil", _
        "point", "polygon", "pop", "present", "printf", _
        "push", "quad", "rectangle", "reset", "rotate", "scale", _
        "setBackgroundColor", "setBlendMode", "setCanvas", "setCaption", _
        "setColor", "setColorMode", "setDefaultImageFilter", "setFont", _
        "setIcon", "setInvertedStencil", "setLine", "setLineStipple", _
        "setLineStyle", "setLineWidth", "setMode", "setNewFont", _
        "setPixelEffect", "setPoint", "setPointSize", "setPointStyle", _
        "setRenderTarget", "setScissor", "setStencil", "shear", "toggleFullscreen", _
        "translate", "triangle", "newEncodedImageData", "newImageData", _
        "close", "getAxes", "getAxis", "getBall", "getHat", "getName", _
        "getNumAxes", "getNumBalls", "getNumButtons", "getNumHats", _
        "getNumJoysticks", "isDown", "isOpen", "open", "getKeyRepeat", _
        "setKeyRepeat", "getPosition", "getX", "getY", _
        "isGrabbed", "isVisible", "setGrab", "setPosition", _
        "setVisible", "getDistance", "getMeter", "newBody", "newChainShape", _
        "newCircleShape", "newDistanceJoint", "newEdgeShape", "newFixture", _
        "newFrictionJoint", "newGearJoint", "newMouseJoint", "newPolygonShape", _
        "newPrismaticJoint", "newPulleyJoint", "newRectangleShape", _
        "newRevoluteJoint", "newRopeJoint", "newWeldJoint", "newWheelJoint", _
        "newWorld", "setMeter", "newDecoder", "newSoundData", "getThread", _
        "getThreads", "newThread", "getDelta", "getFPS", "getMicroTime", _
        "getTime", "sleep", "step", "focus", "joystickpressed", _
        "joystickreleased", "keypressed", "keyreleased", "shape", "fixture", "body", _
        "mousepressed", "mousereleased", "quit", "run", "update"}

    'Love2d methods
    Public methods As String() = { _
        "love.audio", _
        "love.audio.getDistanceModel", _
        "love.audio.getNumSources", _
        "love.audio.getOrientation", _
        "love.audio.getPosition", _
        "love.audio.getVelocity", _
        "love.audio.getVolume", _
        "love.audio.newSource", _
        "love.audio.pause", _
        "love.audio.play", _
        "love.audio.resume", _
        "love.audio.rewind", _
        "love.audio.setDistanceModel", _
        "love.audio.setOrientation", _
        "love.audio.setPosition", _
        "love.audio.setVelocity", _
        "love.audio.setVolume", _
        "love.audio.stop",
        "love.event", _
        "love.event.clear", _
        "love.event.poll", _
        "love.event.pump", _
        "love.event.push", _
        "love.event.quit", _
        "love.event.wait", _
        "love.filesystem", _
        "love.filesystem.enumerate", _
        "love.filesystem.exists", _
        "love.filesystem.getAppdataDirectory", _
        "love.filesystem.getLastModified", _
        "love.filesystem.getSaveDirectory", _
        "love.filesystem.getUserDirectory", _
        "love.filesystem.getWorkingDirectory", _
        "love.filesystem.init", _
        "love.filesystem.isDirectory", _
        "love.filesystem.isFile", _
        "love.filesystem.lines", _
        "love.filesystem.load", _
        "love.filesystem.mkdir", _
        "love.filesystem.newFile", _
        "love.filesystem.newFileData", _
        "love.filesystem.read", _
        "love.filesystem.remove", _
        "love.filesystem.setIdentity", _
        "love.filesystem.setSource", _
        "love.filesystem.write", _
        "love.font", _
        "love.font.newFontData", _
        "love.font.newGlyphData", _
        "love.font.newRasterizer", _
        "love.graphics", _
        "love.graphics.arc", _
        "love.graphics.circle", _
        "love.graphics.clear", _
        "love.graphics.draw", _
        "love.graphics.drawq", _
        "love.graphics.line", _
        "love.graphics.point", _
        "love.graphics.polygon", _
        "love.graphics.present", _
        "love.graphics.print", _
        "love.graphics.printf", _
        "love.graphics.quad", _
        "love.graphics.rectangle", _
        "love.graphics.triangle", _
        "love.graphics.newCanvas", _
        "love.graphics.newFont", _
        "love.graphics.newFramebuffer", _
        "love.graphics.newImage", _
        "love.graphics.newImageFont", _
        "love.graphics.newParticleSystem", _
        "love.graphics.newPixelEffect", _
        "love.graphics.newQuad", _
        "love.graphics.newScreenshot", _
        "love.graphics.newSpriteBatch", _
        "love.graphics.newStencil", _
        "love.graphics.setNewFont", _
        "love.graphics.getBackgroundColor", _
        "love.graphics.getBlendMode", _
        "love.graphics.getCanvas", _
        "love.graphics.getColor", _
        "love.graphics.getColorMode", _
        "love.graphics.getDefaultImageFilter", _
        "love.graphics.getFont", _
        "love.graphics.getLineStipple", _
        "love.graphics.getLineStyle", _
        "love.graphics.getLineWidth	", _
        "love.graphics.getMaxPointSize", _
        "love.graphics.getPixelEffect", _
        "love.graphics.getPointSize", _
        "love.graphics.getPointStyle", _
        "love.graphics.getScissor", _
        "love.graphics.isSupported", _
        "love.graphics.reset", _
        "love.graphics.setBackgroundColor", _
        "love.graphics.setBlendMode", _
        "love.graphics.setCanvas", _
        "love.graphics.setColor", _
        "love.graphics.setColorMask", _
        "love.graphics.setColorMode", _
        "love.graphics.setDefaultImageFilter", _
        "love.graphics.setFont", _
        "love.graphics.setInvertedStencil", _
        "love.graphics.setLine", _
        "love.graphics.setLineStipple", _
        "love.graphics.setLineStyle", _
        "love.graphics.setLineWidth", _
        "love.graphics.setPixelEffect", _
        "love.graphics.setPoint", _
        "love.graphics.setPointSize", _
        "love.graphics.setPointStyle", _
        "love.graphics.setRenderTarget", _
        "love.graphics.setScissor", _
        "love.graphics.setStencil", _
        "love.graphics.pop", _
        "love.graphics.push", _
        "love.graphics.rotate", _
        "love.graphics.scale", _
        "love.graphics.shear", _
        "love.graphics.translate", _
        "love.graphics.checkMode", _
        "love.graphics.getCaption", _
        "love.graphics.getHeight", _
        "love.graphics.getMode", _
        "love.graphics.getModes", _
        "love.graphics.getWidth", _
        "love.graphics.hasFocus", _
        "love.graphics.isCreated", _
        "love.graphics.setCaption", _
        "love.graphics.setIcon", _
        "love.graphics.setMode", _
        "love.graphics.toggleFullscreen", _
        "love.image", _
        "love.image.newEncodedImageData", _
        "love.image.newImageData", _
        "love.joystick", _
        "love.joystick.close", _
        "love.joystick.getAxes", _
        "love.joystick.getAxis", _
        "love.joystick.getBall", _
        "love.joystick.getHat", _
        "love.joystick.getName", _
        "love.joystick.getNumAxes", _
        "love.joystick.getNumBalls", _
        "love.joystick.getNumButtons", _
        "love.joystick.getNumHats", _
        "love.joystick.getNumJoysticks", _
        "love.joystick.isDown", _
        "love.joystick.isOpen", _
        "love.joystick.open", _
        "love.joystickpressed", _
        "love.joystickreleased", _
        "love.keyboard", _
        "love.keyboard.getKeyRepeat", _
        "love.keyboard.isDown", _
        "love.keyboard.setKeyRepeat", _
        "love.keypressed", _
        "love.keyreleased", _
        "love.mouse", _
        "love.mouse.getPosition", _
        "love.mouse.getX", _
        "love.mouse.getY", _
        "love.mouse.isDown", _
        "love.mouse.isGrabbed", _
        "love.mouse.isVisible", _
        "love.mouse.setGrab", _
        "love.mouse.setPosition", _
        "love.mouse.setVisible", _
        "love.mousepressed", _
        "love.mousereleased", _
        "love.physics", _
        "love.physics.getDistance", _
        "love.physics.getMeter", _
        "love.physics.newBody", _
        "love.physics.newChainShape", _
        "love.physics.newCircleShape", _
        "love.physics.newDistanceJoint", _
        "love.physics.newEdgeShape", _
        "love.physics.newFixture", _
        "love.physics.newFrictionJoint", _
        "love.physics.newGearJoint", _
        "love.physics.newMouseJoint", _
        "love.physics.newPolygonShape", _
        "love.physics.newPrismaticJoint", _
        "love.physics.newPulleyJoint", _
        "love.physics.newRectangleShape", _
        "love.physics.newRevoluteJoint", _
        "love.physics.newRopeJoint", _
        "love.physics.newWeldJoint", _
        "love.physics.newWheelJoint", _
        "love.physics.newWorld", _
        "love.physics.setMeter", _
        "love.sound", _
        "love.sound.newDecoder", _
        "love.sound.newSoundData", _
        "love.thread", _
        "love.thread.getThread", _
        "love.thread.getThreads", _
        "love.thread.newThread", _
        "love.timer", _
        "love.timer.getDelta", _
        "love.timer.getFPS", _
        "love.timer.getMicroTime", _
        "love.timer.getTime", _
        "love.timer.sleep", _
        "love.timer.step"}

    'Public snippets As String() = {"if(^)" & vbLf & "{" & vbLf & ";" & vbLf & "}", _
    '     "if(^)" & vbLf & "{" & vbLf & ";" & vbLf & "}" & vbLf & "else" & vbLf & "{" & vbLf & ";" & vbLf & "}", _
    '     "for(^;;)" & vbLf & "{" & vbLf & ";" & vbLf & "}", _
    '     "while(^)" & vbLf & "{" & vbLf & ";" & vbLf & "}", _
    '     "do${" & vbLf & "^;" & vbLf & "}while();", _
    '     "switch(^)" & vbLf & "{" & vbLf & "case : break;" & vbLf & "}"}
    'Public declarationSnippets As String() = {"function love.draw() ^", _
    '     "function love.focus() ^", _
    '     "function love.joystickpressed() ^", _
    '     "function love.joystickreleased() ^", _
    '     "function love.keypressed() ^", _
    '     "function love.keyreleased() ^", _
    '     "function love.load() ^", _
    '     "function love.mousepressed() ^", _
    '     "function love.mousereleased() ^", _
    '     "function love.quit() ^", _
    '     "function love.run() ^", _
    '     "function love.update() ^"}
   

    Public Sub popupMenu_Opening(ByVal sender As Object, ByVal e As CancelEventArgs)

        Dim bookmark As bookmarkCode = New bookmarkCode
        Dim iGreenStyle As Integer = bookmark.CurrentTB.GetStyleIndex(bookmark.CurrentTB.SyntaxHighlighter.GreenStyle)

        If iGreenStyle <= 0 AndAlso bookmark.CurrentTB.Selection.Start.iChar > 0 Then
            Dim c As FastColoredTextBoxNS.Char = bookmark.CurrentTB(bookmark.CurrentTB.Selection.Start.iLine)(bookmark.CurrentTB.Selection.Start.iChar - 1)
            Dim greenStyleIndex As StyleIndex = Range.ToStyleIndex(iGreenStyle)
            If c.style = greenStyleIndex <> 0 Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If

        'Dim bookmark As bookmarkCode = New bookmarkCode
        'Dim iGreenStyle As Integer = bookmark.CurrentTB.GetStyleIndex(bookmark.CurrentTB.SyntaxHighlighter.GreenStyle)
        'If iGreenStyle >= 0 AndAlso bookmark.CurrentTB.Selection.Start.iChar > 0 Then
        '    Dim c As FastColoredTextBoxNS.Char = bookmark.CurrentTB(bookmark.CurrentTB.Selection.Start.iLine)(bookmark.CurrentTB.Selection.Start.iChar - 1)
        '    Dim greenStyleIndex As StyleIndex = Range.ToStyleIndex(iGreenStyle)
        '    If CUShort(c.style And greenStyleIndex) <> 0 Then
        '        e.Cancel = True
        '    End If
        'End If

    End Sub

    'Function par acrear un menu de auto completado dynamica mente en vb.net
    Friend Class DynamicCollection
        Implements IEnumerable(Of AutocompleteItem)

        '============================================================================================

        Private Class DeclarationSnippet
            Inherits SnippetAutocompleteItem

            Public Sub New(ByVal snippet As String)
                MyBase.New(snippet)
            End Sub

            Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
                Dim pattern As String = Regex.Escape(fragmentText)
                Dim result As CompareResult
                If Regex.IsMatch(Me.Text, "\b" + pattern, RegexOptions.IgnoreCase) Then
                    result = CompareResult.Visible
                Else
                    result = CompareResult.Hidden
                End If
                Return result
            End Function
        End Class

        Private Class InsertSpaceSnippet
            Inherits AutocompleteItem

            Private pattern As String

            Public Overrides Property ToolTipTitle() As String
                Get
                    Return Me.Text
                End Get
                Set(ByVal value As String)

                End Set
            End Property

            Public Sub New(ByVal pattern As String)
                MyBase.New("")
                Me.pattern = pattern
            End Sub

            Public Sub New()
                Me.New("^(\d+)([a-zA-Z_]+)(\d*)$")
            End Sub

            Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
                Dim result As CompareResult
                If Regex.IsMatch(fragmentText, Me.pattern) Then
                    Me.Text = Me.InsertSpaces(fragmentText)
                    If Me.Text <> fragmentText Then
                        result = CompareResult.Visible
                        Return result
                    End If
                End If
                result = CompareResult.Hidden
                Return result
            End Function

            Public Function InsertSpaces(ByVal fragment As String) As String
                Dim i As Match = Regex.Match(fragment, Me.pattern)
                Dim result As String
                If i Is Nothing Then
                    result = fragment
                Else
                    If i.Groups(1).Value = "" AndAlso i.Groups(3).Value = "" Then
                        result = fragment
                    Else
                        result = String.Concat(New String() {i.Groups(1).Value, " ", i.Groups(2).Value, " ", i.Groups(3).Value}).Trim()
                    End If
                End If
                Return result
            End Function

        End Class

        Private Class InsertEnterSnippet
            Inherits AutocompleteItem

            Private enterPlace As Place = Place.Empty

            Public Overrides Property ToolTipTitle() As String
                Get
                    Return "Insert line break after '}'"
                End Get
                Set(ByVal value As String)

                End Set
            End Property

            Public Sub New()
                MyBase.New("[Line break]")
            End Sub

            Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
                Dim r As Range = MyBase.Parent.Fragment.Clone()
                Dim result As CompareResult
                While r.Start.iChar > 0
                    If r.CharBeforeStart = "}" Then
                        Me.enterPlace = r.Start
                        result = CompareResult.Visible
                        Return result
                    End If
                    r.GoLeftThroughFolded()
                End While
                result = CompareResult.Hidden
                Return result
            End Function

            Public Overrides Function GetTextForReplace() As String
                Dim r As Range = MyBase.Parent.Fragment
                Dim [end] As Place = r.[End]
                r.Start = Me.enterPlace
                r.[End] = r.[End]
                Return Environment.NewLine + r.Text
            End Function

            Public Overrides Sub OnSelected(ByVal popupMenu As AutocompleteMenu, ByVal e As SelectedEventArgs)
                MyBase.OnSelected(popupMenu, e)
                If MyBase.Parent.Fragment.tb.AutoIndent Then
                    MyBase.Parent.Fragment.tb.DoAutoIndent()
                End If
            End Sub
        End Class

        '============================================================================================

        Private tb As FastColoredTextBox
        Private CodeSyntaxis As New AutoCompletad

        Private array As String()
        Public items As List(Of AutocompleteItem) = New List(Of AutocompleteItem)()

        Private IsFirsh As Boolean = True

        Public Sub New(ByVal tb As FastColoredTextBox, ByVal popupMenu1 As AutocompleteMenu)
            Me.tb = tb

            If IsFirsh = True Then

                array = CodeSyntaxis.keywords
                For i As Integer = 0 To array.Length - 1
                    Dim item As String = array(i)
                    items.Add(New AutocompleteItem(item) With {.ImageIndex = 1})
                Next

                array = CodeSyntaxis.methods
                For i As Integer = 0 To array.Length - 1
                    Dim item As String = array(i)
                    items.Add(New MethodAutocompleteItem2(item) With {.ImageIndex = 3})
                Next

                'create autocomplete popup menu
                popupMenu1 = New AutocompleteMenu(tb)
                popupMenu1.MinFragmentLength = 2
                popupMenu1.SearchPattern = "[\w\.:=!<>]"
                popupMenu1.Items.ImageList = MainForm1.IL_AutoCompleted
                popupMenu1.Items.MinimumSize = New Size(170, 0)

                AddHandler popupMenu1.Opening, New EventHandler(Of CancelEventArgs)(AddressOf MainForm1.popupMenu_Opening)

                items.Add(New InsertSpaceSnippet())
                items.Add(New InsertSpaceSnippet("^(\w+)([=<>!:]+)(\w+)$"))
                items.Add(New InsertEnterSnippet())

                'set words as autocomplete source
                popupMenu1.Items.SetAutocompleteItems(items)

                IsFirsh = False

            End If

        End Sub

        Public Function GetEnumerator() As IEnumerator(Of AutocompleteItem) Implements IEnumerable(Of AutocompleteItem).GetEnumerator
            Return BuildList().GetEnumerator
        End Function

        Private Function System_Collections_IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return GetEnumerator()
        End Function

        'Iterator
        Private Iterator Function BuildList() As IEnumerable(Of AutocompleteItem)

            'find all words of the text
            Dim words = New Dictionary(Of String, String)()
            For Each m As Match In Regex.Matches(tb.Text, "\b\w+\b")
                words(m.Value) = m.Value
            Next

            For Each word In words.Keys
                items.Add(New AutocompleteItem(word, 0))
            Next

            'Elimina los codigos repetidos de la variable items.
            DeleteRepeadItems()

            ''return autocomplete items
            'For Each word In words.Keys
            '    items.Add(New AutocompleteItem(word))
            '    'Yield (New AutocompleteItem(word, 0))
            'Next

        End Function

        'Elimina los codigos repetidos de la variable items.
        Private Sub DeleteRepeadItems()

            For i = 0 To items.Count - 1 ' Empiesa el recorido de los items del menu AutoCompletado.
                For j = i + 1 To items.Count - 1 ' Empiesa el recorido de los items + 1 del menu AutoCompletado para poder comprobar si hay repetidos.

                    If items(j).ImageIndex = 0 Then ' Comprueba que el items que se balla a eliminar tenga la imagen 3 para poder continuar.
                        If items(i).Text = items(j).Text Then ' Comprueba que el items sea igual al otro.
                            items.RemoveAt(j) ' Remueve el items Que halla repetido.
                            j = j - 1 ' Le quita 1 a la variable j
                        End If

                        If j = items.Count - 1 Then ' Comprueba si el bucle j llega al final de los items.
                            Exit For ' Sale del bucle.
                        End If
                    End If

                Next j
            Next i

        End Sub

    End Class

    ''' <summary>
    ''' This autocomplete item appears after dot
    ''' </summary>
    Public Class MethodAutocompleteItem2
        Inherits MethodAutocompleteItem

        Private firstPart As String
        Private lastPart As String

        Public Sub New(text As String)
            MyBase.New(text)
            Dim i = text.LastIndexOf("."c)
            If i < 0 Then
                firstPart = text
            Else
                firstPart = text.Substring(0, i)
                lastPart = text.Substring(i + 1)
            End If
        End Sub

        Public Overrides Function Compare(fragmentText As String) As CompareResult
            Dim i As Integer = fragmentText.LastIndexOf("."c)

            If i < 0 Then
                If firstPart.StartsWith(fragmentText) AndAlso String.IsNullOrEmpty(lastPart) Then
                    Return CompareResult.VisibleAndSelected
                    'if (firstPart.ToLower().Contains(fragmentText.ToLower()))
                    '  return CompareResult.Visible;
                End If
            Else
                Dim fragmentFirstPart = fragmentText.Substring(0, i)
                Dim fragmentLastPart = fragmentText.Substring(i + 1)


                If firstPart <> fragmentFirstPart Then
                    Return CompareResult.Hidden
                End If

                If lastPart IsNot Nothing AndAlso lastPart.StartsWith(fragmentLastPart) Then
                    Return CompareResult.VisibleAndSelected
                End If

                If lastPart IsNot Nothing AndAlso lastPart.ToLower().Contains(fragmentLastPart.ToLower()) Then
                    Return CompareResult.Visible

                End If
            End If

            Return CompareResult.Hidden
        End Function

        Public Overrides Function GetTextForReplace() As String
            If lastPart Is Nothing Then
                Return firstPart
            End If

            Return firstPart & "." & lastPart
        End Function

        Public Overrides Function ToString() As String
            If lastPart Is Nothing Then
                Return firstPart
            End If

            Return lastPart
        End Function
    End Class

End Class

