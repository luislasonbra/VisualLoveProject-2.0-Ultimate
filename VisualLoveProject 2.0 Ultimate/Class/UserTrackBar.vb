Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class UserTrackBar
    Inherits Control

#Region "Events"

    ''' <summary>
    ''' Fires when Slider position has changed
    ''' </summary>
    <Description("Event fires when the Value property changes")> _
    <Category("Action")> _
    Public Event ValueChanged As EventHandler

    ''' <summary>
    ''' Fires when user scrolls the Slider
    ''' </summary>
    <Description("Event fires when the Slider position is changed")> _
    <Category("Behavior")> _
    Public Event Scroll As ScrollEventHandler

#End Region

#Region "Properties"

    Private m_thumbRect As Rectangle
    'bounding rectangle of thumb area
    ''' <summary>
    ''' Gets the thumb rect. Usefull to determine bounding rectangle when creating custom thumb shape.
    ''' </summary>
    ''' <value>The thumb rect.</value>
    <Browsable(False)> _
    Public ReadOnly Property ThumbRect() As Rectangle
        Get
            Return m_thumbRect
        End Get
    End Property

    Private barRect As Rectangle
    'bounding rectangle of bar area
    Private barHalfRect As Rectangle
    Private thumbHalfRect As Rectangle
    Private elapsedRect As Rectangle
    'bounding rectangle of elapsed area
    Private m_thumbSize As Integer = 15
    ''' <summary>
    ''' Gets or sets the size of the thumb.
    ''' </summary>
    ''' <value>The size of the thumb.</value>
    ''' <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when value is lower than zero or grather than half of appropiate dimension</exception>
    <Description("Set Slider thumb size")> _
    <Category("ColorSlider")> _
    <DefaultValue(15)> _
    Public Property ThumbSize() As Integer
        Get
            Return m_thumbSize
        End Get
        Set(value As Integer)
            If value > 0 And value < (If(barOrientation = Orientation.Horizontal, ClientRectangle.Width, ClientRectangle.Height)) Then
                m_thumbSize = value
            Else
                Throw New ArgumentOutOfRangeException("TrackSize has to be greather than zero and lower than half of Slider width")
            End If
            Invalidate()
        End Set
    End Property

    Private m_thumbCustomShape As GraphicsPath = Nothing
    ''' <summary>
    ''' Gets or sets the thumb custom shape. Use ThumbRect property to determine bounding rectangle.
    ''' </summary>
    ''' <value>The thumb custom shape. null means default shape</value>
    <Description("Set Slider's thumb's custom shape")> _
    <Category("ColorSlider")> _
    <Browsable(False)> _
    <DefaultValue(GetType(GraphicsPath), "null")> _
    Public Property ThumbCustomShape() As GraphicsPath
        Get
            Return m_thumbCustomShape
        End Get
        Set(value As GraphicsPath)
            m_thumbCustomShape = value
            m_thumbSize = CInt(If(barOrientation = Orientation.Horizontal, value.GetBounds().Width, value.GetBounds().Height)) + 1
            Invalidate()
        End Set
    End Property

    Private m_thumbRoundRectSize As New Size(8, 8)
    ''' <summary>
    ''' Gets or sets the size of the thumb round rectangle edges.
    ''' </summary>
    ''' <value>The size of the thumb round rectangle edges.</value>
    <Description("Set Slider's thumb round rect size")> _
    <Category("ColorSlider")> _
    <DefaultValue(GetType(Size), "8; 8")> _
    Public Property ThumbRoundRectSize() As Size
        Get
            Return m_thumbRoundRectSize
        End Get
        Set(value As Size)
            Dim h As Integer = value.Height, w As Integer = value.Width
            If h <= 0 Then
                h = 1
            End If
            If w <= 0 Then
                w = 1
            End If
            m_thumbRoundRectSize = New Size(w, h)
            Invalidate()
        End Set
    End Property

    Private m_borderRoundRectSize As New Size(8, 8)
    ''' <summary>
    ''' Gets or sets the size of the border round rect.
    ''' </summary>
    ''' <value>The size of the border round rect.</value>
    <Description("Set Slider's border round rect size")> _
    <Category("ColorSlider")> _
    <DefaultValue(GetType(Size), "8; 8")> _
    Public Property BorderRoundRectSize() As Size
        Get
            Return m_borderRoundRectSize
        End Get
        Set(value As Size)
            Dim h As Integer = value.Height, w As Integer = value.Width
            If h <= 0 Then
                h = 1
            End If
            If w <= 0 Then
                w = 1
            End If
            m_borderRoundRectSize = New Size(w, h)
            Invalidate()
        End Set
    End Property

    Private barOrientation As Orientation = Orientation.Horizontal
    ''' <summary>
    ''' Gets or sets the orientation of Slider.
    ''' </summary>
    ''' <value>The orientation.</value>
    <Description("Set Slider orientation")> _
    <Category("ColorSlider")> _
    <DefaultValue(Orientation.Horizontal)> _
    Public Property Orientation() As Orientation
        Get
            Return barOrientation
        End Get
        Set(value As Orientation)
            If barOrientation <> value Then
                barOrientation = value
                Dim temp As Integer = Width
                Width = Height
                Height = temp
                If m_thumbCustomShape IsNot Nothing Then
                    m_thumbSize = CInt(If(barOrientation = Orientation.Horizontal, m_thumbCustomShape.GetBounds().Width, m_thumbCustomShape.GetBounds().Height)) + 1
                End If
                Invalidate()
            End If
        End Set
    End Property


    Private trackerValue As Integer = 50
    ''' <summary>
    ''' Gets or sets the value of Slider.
    ''' </summary>
    ''' <value>The value.</value>
    ''' <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when value is outside appropriate range (min, max)</exception>
    <Description("Set Slider value")> _
    <Category("ColorSlider")> _
    <DefaultValue(50)> _
    Public Property Value() As Integer
        Get
            Return trackerValue
        End Get
        Set(value As Integer)
            If value >= barMinimum And value <= barMaximum Then
                trackerValue = value
                RaiseEvent ValueChanged(Me, New EventArgs())
                Invalidate()
            Else
                Throw New ArgumentOutOfRangeException("Value is outside appropriate range (min, max)")
            End If
        End Set
    End Property


    Private barMinimum As Integer = 0
    ''' <summary>
    ''' Gets or sets the minimum value.
    ''' </summary>
    ''' <value>The minimum value.</value>
    ''' <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when minimal value is greather than maximal one</exception>
    <Description("Set Slider minimal point")> _
    <Category("ColorSlider")> _
    <DefaultValue(0)> _
    Public Property Minimum() As Integer
        Get
            Return barMinimum
        End Get
        Set(value As Integer)
            If value < barMaximum Then
                barMinimum = value
                If trackerValue < barMinimum Then
                    trackerValue = barMinimum
                    RaiseEvent ValueChanged(Me, New EventArgs())
                End If
                Invalidate()
            Else
                Throw New ArgumentOutOfRangeException("Minimal value is greather than maximal one")
            End If
        End Set
    End Property


    Private barMaximum As Integer = 100
    ''' <summary>
    ''' Gets or sets the maximum value.
    ''' </summary>
    ''' <value>The maximum value.</value>
    ''' <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when maximal value is lower than minimal one</exception>
    <Description("Set Slider maximal point")> _
    <Category("ColorSlider")> _
    <DefaultValue(100)> _
    Public Property Maximum() As Integer
        Get
            Return barMaximum
        End Get
        Set(value As Integer)
            If value > barMinimum Then
                barMaximum = value
                If trackerValue > barMaximum Then
                    trackerValue = barMaximum
                    RaiseEvent ValueChanged(Me, New EventArgs())
                End If
                Invalidate()
            Else
                Throw New ArgumentOutOfRangeException("Maximal value is lower than minimal one")
            End If
        End Set
    End Property

    Private m_smallChange As UInteger = 1
    ''' <summary>
    ''' Gets or sets trackbar's small change. It affects how to behave when directional keys are pressed
    ''' </summary>
    ''' <value>The small change value.</value>
    <Description("Set trackbar's small change")> _
    <Category("ColorSlider")> _
    <DefaultValue(1)> _
    Public Property SmallChange() As UInteger
        Get
            Return m_smallChange
        End Get
        Set(value As UInteger)
            m_smallChange = value
        End Set
    End Property

    Private m_largeChange As UInteger = 5

    ''' <summary>
    ''' Gets or sets trackbar's large change. It affects how to behave when PageUp/PageDown keys are pressed
    ''' </summary>
    ''' <value>The large change value.</value>
    <Description("Set trackbar's large change")> _
    <Category("ColorSlider")> _
    <DefaultValue(5)> _
    Public Property LargeChange() As UInteger
        Get
            Return m_largeChange
        End Get
        Set(value As UInteger)
            m_largeChange = value
        End Set
    End Property

    Private m_drawFocusRectangle As Boolean = True
    ''' <summary>
    ''' Gets or sets a value indicating whether to draw focus rectangle.
    ''' </summary>
    ''' <value><c>true</c> if focus rectangle should be drawn; otherwise, <c>false</c>.</value>
    <Description("Set whether to draw focus rectangle")> _
    <Category("ColorSlider")> _
    <DefaultValue(True)> _
    Public Property DrawFocusRectangle() As Boolean
        Get
            Return m_drawFocusRectangle
        End Get
        Set(value As Boolean)
            m_drawFocusRectangle = value
            Invalidate()
        End Set
    End Property

    Private m_drawSemitransparentThumb As Boolean = True
    ''' <summary>
    ''' Gets or sets a value indicating whether to draw semitransparent thumb.
    ''' </summary>
    ''' <value><c>true</c> if semitransparent thumb should be drawn; otherwise, <c>false</c>.</value>
    <Description("Set whether to draw semitransparent thumb")> _
    <Category("ColorSlider")> _
    <DefaultValue(True)> _
    Public Property DrawSemitransparentThumb() As Boolean
        Get
            Return m_drawSemitransparentThumb
        End Get
        Set(value As Boolean)
            m_drawSemitransparentThumb = value
            Invalidate()
        End Set
    End Property

    Private m_mouseEffects As Boolean = True
    ''' <summary>
    ''' Gets or sets whether mouse entry and exit actions have impact on how control look.
    ''' </summary>
    ''' <value><c>true</c> if mouse entry and exit actions have impact on how control look; otherwise, <c>false</c>.</value>
    <Description("Set whether mouse entry and exit actions have impact on how control look")> _
    <Category("ColorSlider")> _
    <DefaultValue(True)> _
    Public Property MouseEffects() As Boolean
        Get
            Return m_mouseEffects
        End Get
        Set(value As Boolean)
            m_mouseEffects = value
            Invalidate()
        End Set
    End Property

    Private m_mouseWheelBarPartitions As Integer = 10
    ''' <summary>
    ''' Gets or sets the mouse wheel bar partitions.
    ''' </summary>
    ''' <value>The mouse wheel bar partitions.</value>
    ''' <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when value isn't greather than zero</exception>
    <Description("Set to how many parts is bar divided when using mouse wheel")> _
    <Category("ColorSlider")> _
    <DefaultValue(10)> _
    Public Property MouseWheelBarPartitions() As Integer
        Get
            Return m_mouseWheelBarPartitions
        End Get
        Set(value As Integer)
            If value > 0 Then
                m_mouseWheelBarPartitions = value
            Else
                Throw New ArgumentOutOfRangeException("MouseWheelBarPartitions has to be greather than zero")
            End If
        End Set
    End Property

    Private m_thumbOuterColor As Color = Color.White
    ''' <summary>
    ''' Gets or sets the thumb outer color .
    ''' </summary>
    ''' <value>The thumb outer color.</value>
    <Description("Set Slider thumb outer color")> _
    <Category("ColorSlider")> _
    <DefaultValue(GetType(Color), "White")> _
    Public Property ThumbOuterColor() As Color
        Get
            Return m_thumbOuterColor
        End Get
        Set(value As Color)
            m_thumbOuterColor = value
            Invalidate()
        End Set
    End Property


    Private m_thumbInnerColor As Color = Color.Gainsboro
    ''' <summary>
    ''' Gets or sets the inner color of the thumb.
    ''' </summary>
    ''' <value>The inner color of the thumb.</value>
    <Description("Set Slider thumb inner color")> _
    <Category("ColorSlider")> _
    <DefaultValue(GetType(Color), "Gainsboro")> _
    Public Property ThumbInnerColor() As Color
        Get
            Return m_thumbInnerColor
        End Get
        Set(value As Color)
            m_thumbInnerColor = value
            Invalidate()
        End Set
    End Property


    Private m_thumbPenColor As Color = Color.Silver
    ''' <summary>
    ''' Gets or sets the color of the thumb pen.
    ''' </summary>
    ''' <value>The color of the thumb pen.</value>
    <Description("Set Slider thumb pen color")> _
    <Category("ColorSlider")> _
    <DefaultValue(GetType(Color), "Silver")> _
    Public Property ThumbPenColor() As Color
        Get
            Return m_thumbPenColor
        End Get
        Set(value As Color)
            m_thumbPenColor = value
            Invalidate()
        End Set
    End Property


    Private m_barOuterColor As Color = Color.SkyBlue
    ''' <summary>
    ''' Gets or sets the outer color of the bar.
    ''' </summary>
    ''' <value>The outer color of the bar.</value>
    <Description("Set Slider bar outer color")> _
    <Category("ColorSlider")> _
    <DefaultValue(GetType(Color), "SkyBlue")> _
    Public Property BarOuterColor() As Color
        Get
            Return m_barOuterColor
        End Get
        Set(value As Color)
            m_barOuterColor = value
            Invalidate()
        End Set
    End Property


    Private m_barInnerColor As Color = Color.DarkSlateBlue
    ''' <summary>
    ''' Gets or sets the inner color of the bar.
    ''' </summary>
    ''' <value>The inner color of the bar.</value>
    <Description("Set Slider bar inner color")> _
    <Category("ColorSlider")> _
    <DefaultValue(GetType(Color), "DarkSlateBlue")> _
    Public Property BarInnerColor() As Color
        Get
            Return m_barInnerColor
        End Get
        Set(value As Color)
            m_barInnerColor = value
            Invalidate()
        End Set
    End Property


    Private m_barPenColor As Color = Color.Gainsboro
    ''' <summary>
    ''' Gets or sets the color of the bar pen.
    ''' </summary>
    ''' <value>The color of the bar pen.</value>
    <Description("Set Slider bar pen color")> _
    <Category("ColorSlider")> _
    <DefaultValue(GetType(Color), "Gainsboro")> _
    Public Property BarPenColor() As Color
        Get
            Return m_barPenColor
        End Get
        Set(value As Color)
            m_barPenColor = value
            Invalidate()
        End Set
    End Property

    Private m_elapsedOuterColor As Color = Color.DarkGreen
    ''' <summary>
    ''' Gets or sets the outer color of the elapsed.
    ''' </summary>
    ''' <value>The outer color of the elapsed.</value>
    <Description("Set Slider's elapsed part outer color")> _
    <Category("ColorSlider")> _
    <DefaultValue(GetType(Color), "DarkGreen")> _
    Public Property ElapsedOuterColor() As Color
        Get
            Return m_elapsedOuterColor
        End Get
        Set(value As Color)
            m_elapsedOuterColor = value
            Invalidate()
        End Set
    End Property

    Private m_elapsedInnerColor As Color = Color.Chartreuse
    ''' <summary>
    ''' Gets or sets the inner color of the elapsed.
    ''' </summary>
    ''' <value>The inner color of the elapsed.</value>
    <Description("Set Slider's elapsed part inner color")> _
    <Category("ColorSlider")> _
    <DefaultValue(GetType(Color), "Chartreuse")> _
    Public Property ElapsedInnerColor() As Color
        Get
            Return m_elapsedInnerColor
        End Get
        Set(value As Color)
            m_elapsedInnerColor = value
            Invalidate()
        End Set
    End Property

#End Region

#Region "Color schemas"

    'define own color schemas
    Private aColorSchema As Color(,) = New Color(,) {{Color.White, Color.Gainsboro, Color.Silver, Color.SkyBlue, Color.DarkSlateBlue, Color.Gainsboro, _
     Color.DarkGreen, Color.Chartreuse}, {Color.White, Color.Gainsboro, Color.Silver, Color.Red, Color.DarkRed, Color.Gainsboro, _
     Color.Coral, Color.LightCoral}, {Color.White, Color.Gainsboro, Color.Silver, Color.GreenYellow, Color.Yellow, Color.Gold, _
     Color.Orange, Color.OrangeRed}, {Color.White, Color.Gainsboro, Color.Silver, Color.Red, Color.Crimson, Color.Gainsboro, _
     Color.DarkViolet, Color.Violet}}

    Public Enum ColorSchemas
        PerlBlueGreen
        PerlRedCoral
        PerlGold
        PerlRoyalColors
    End Enum

    Private m_colorSchema As ColorSchemas = ColorSchemas.PerlBlueGreen
    ''' <summary>
    ''' Sets color schema. Color generalization / fast color changing. Has no effect when slider colors are changed manually after schema was applied. 
    ''' </summary>
    ''' <value>New color schema value</value>
    <Description("Set Slider color schema. Has no effect when slider colors are changed manually after schema was applied.")> _
    <Category("ColorSlider")> _
    <DefaultValue(GetType(ColorSchemas), "PerlBlueGreen")> _
    Public Property ColorSchema() As ColorSchemas
        Get
            Return m_colorSchema
        End Get
        Set(value As ColorSchemas)
            m_colorSchema = value
            Dim sn As Byte = CByte(value)
            ThumbOuterColor = aColorSchema(sn, 0)
            ThumbInnerColor = aColorSchema(sn, 1)
            ThumbPenColor = aColorSchema(sn, 2)
            BarOuterColor = aColorSchema(sn, 3)
            BarInnerColor = aColorSchema(sn, 4)
            BarPenColor = aColorSchema(sn, 5)
            ElapsedOuterColor = aColorSchema(sn, 6)
            ElapsedInnerColor = aColorSchema(sn, 7)

            Invalidate()
        End Set
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    ''' Initializes a new instance of the <see cref="ColorSlider"/> class.
    ''' </summary>
    ''' <param name="min">The minimum value.</param>
    ''' <param name="max">The maximum value.</param>
    ''' <param name="value">The current value.</param>
    Public Sub New(min As Integer, max As Integer, value__1 As Integer)
        'InitializeComponent()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.Selectable Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserMouse Or ControlStyles.UserPaint, True)
        BackColor = Color.Transparent

        Minimum = min
        Maximum = max
        Value = value__1
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="ColorSlider"/> class.
    ''' </summary>
    Public Sub New()
        Me.New(0, 100, 50)
    End Sub

#End Region

#Region "Paint"

    ''' <summary>
    ''' Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
    ''' </summary>
    ''' <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data.</param>
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        If Not Enabled Then
            Dim desaturatedColors As Color() = DesaturateColors(ThumbOuterColor, ThumbInnerColor, ThumbPenColor, BarOuterColor, BarInnerColor, BarPenColor, _
             ElapsedOuterColor, ElapsedInnerColor)
            DrawColorSlider(e, desaturatedColors(0), desaturatedColors(1), desaturatedColors(2), desaturatedColors(3), desaturatedColors(4), _
             desaturatedColors(5), desaturatedColors(6), desaturatedColors(7))
        Else
            If MouseEffects AndAlso mouseInRegion Then
                Dim lightenedColors As Color() = LightenColors(ThumbOuterColor, ThumbInnerColor, ThumbPenColor, BarOuterColor, BarInnerColor, BarPenColor, _
                 ElapsedOuterColor, ElapsedInnerColor)
                DrawColorSlider(e, lightenedColors(0), lightenedColors(1), lightenedColors(2), lightenedColors(3), lightenedColors(4), _
                 lightenedColors(5), lightenedColors(6), lightenedColors(7))
            Else
                DrawColorSlider(e, ThumbOuterColor, ThumbInnerColor, ThumbPenColor, BarOuterColor, BarInnerColor, _
                 BarPenColor, ElapsedOuterColor, ElapsedInnerColor)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Draws the colorslider control using passed colors.
    ''' </summary>
    ''' <param name="e">The <see cref="T:System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
    ''' <param name="thumbOuterColorPaint">The thumb outer color paint.</param>
    ''' <param name="thumbInnerColorPaint">The thumb inner color paint.</param>
    ''' <param name="thumbPenColorPaint">The thumb pen color paint.</param>
    ''' <param name="barOuterColorPaint">The bar outer color paint.</param>
    ''' <param name="barInnerColorPaint">The bar inner color paint.</param>
    ''' <param name="barPenColorPaint">The bar pen color paint.</param>
    ''' <param name="elapsedOuterColorPaint">The elapsed outer color paint.</param>
    ''' <param name="elapsedInnerColorPaint">The elapsed inner color paint.</param>
    Private Sub DrawColorSlider(e As PaintEventArgs, thumbOuterColorPaint As Color, thumbInnerColorPaint As Color, thumbPenColorPaint As Color, barOuterColorPaint As Color, barInnerColorPaint As Color, _
     barPenColorPaint As Color, elapsedOuterColorPaint As Color, elapsedInnerColorPaint As Color)
        Try
            'set up thumbRect aproprietly
            If barOrientation = Orientation.Horizontal Then
                Dim TrackX As Integer = (((trackerValue - barMinimum) * (ClientRectangle.Width - ThumbSize)) / (barMaximum - barMinimum))
                m_thumbRect = New Rectangle(TrackX, 1, ThumbSize - 1, ClientRectangle.Height - 3)
            Else
                Dim TrackY As Integer = (((trackerValue - barMinimum) * (ClientRectangle.Height - ThumbSize)) / (barMaximum - barMinimum))
                m_thumbRect = New Rectangle(1, TrackY, ClientRectangle.Width - 3, ThumbSize - 1)
            End If

            'adjust drawing rects
            barRect = ClientRectangle
            thumbHalfRect = ThumbRect
            Dim gradientOrientation As LinearGradientMode
            If barOrientation = Orientation.Horizontal Then
                barRect.Inflate(-1, -barRect.Height / 3)
                barHalfRect = barRect
                barHalfRect.Height /= 2
                gradientOrientation = LinearGradientMode.Vertical
                thumbHalfRect.Height /= 2
                elapsedRect = barRect
                elapsedRect.Width = ThumbRect.Left + ThumbSize / 2
            Else
                barRect.Inflate(-barRect.Width / 3, -1)
                barHalfRect = barRect
                barHalfRect.Width /= 2
                gradientOrientation = LinearGradientMode.Horizontal
                thumbHalfRect.Width /= 2
                elapsedRect = barRect
                elapsedRect.Height = ThumbRect.Top + ThumbSize / 2
            End If
            'get thumb shape path 
            Dim thumbPath As GraphicsPath
            If ThumbCustomShape Is Nothing Then
                thumbPath = CreateRoundRectPath(ThumbRect, ThumbRoundRectSize)
            Else
                thumbPath = ThumbCustomShape
                Dim m As New Matrix()
                m.Translate(ThumbRect.Left - thumbPath.GetBounds().Left, ThumbRect.Top - thumbPath.GetBounds().Top)
                thumbPath.Transform(m)
            End If

            'draw bar
            Using lgbBar As New LinearGradientBrush(barHalfRect, barOuterColorPaint, barInnerColorPaint, gradientOrientation)
                lgbBar.WrapMode = WrapMode.TileFlipXY
                e.Graphics.FillRectangle(lgbBar, barRect)
                'draw elapsed bar
                Using lgbElapsed As New LinearGradientBrush(barHalfRect, elapsedOuterColorPaint, elapsedInnerColorPaint, gradientOrientation)
                    lgbElapsed.WrapMode = WrapMode.TileFlipXY
                    If Capture AndAlso DrawSemitransparentThumb Then
                        Dim elapsedReg As New Region(elapsedRect)
                        elapsedReg.Exclude(thumbPath)
                        e.Graphics.FillRegion(lgbElapsed, elapsedReg)
                    Else
                        e.Graphics.FillRectangle(lgbElapsed, elapsedRect)
                    End If
                End Using
                'draw bar band                    
                Using barPen As New Pen(barPenColorPaint, 0.5F)
                    e.Graphics.DrawRectangle(barPen, barRect)
                End Using
            End Using

            'draw thumb
            Dim newthumbOuterColorPaint As Color = thumbOuterColorPaint, newthumbInnerColorPaint As Color = thumbInnerColorPaint
            If Capture AndAlso DrawSemitransparentThumb Then
                newthumbOuterColorPaint = Color.FromArgb(175, thumbOuterColorPaint)
                newthumbInnerColorPaint = Color.FromArgb(175, thumbInnerColorPaint)
            End If
            Using lgbThumb As New LinearGradientBrush(thumbHalfRect, newthumbOuterColorPaint, newthumbInnerColorPaint, gradientOrientation)
                lgbThumb.WrapMode = WrapMode.TileFlipXY
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
                e.Graphics.FillPath(lgbThumb, thumbPath)
                'draw thumb band
                Dim newThumbPenColor As Color = thumbPenColorPaint
                If MouseEffects AndAlso (Capture OrElse mouseInThumbRegion) Then
                    newThumbPenColor = ControlPaint.Dark(newThumbPenColor)
                End If
                Using thumbPen As New Pen(newThumbPenColor)
                    e.Graphics.DrawPath(thumbPen, thumbPath)
                    'gp.Dispose();                    
                    'if (Capture || mouseInThumbRegion)
                    '                        using (LinearGradientBrush lgbThumb2 = new LinearGradientBrush(thumbHalfRect, Color.FromArgb(150, Color.Blue), Color.Transparent, gradientOrientation))
                    '                        {
                    '                            lgbThumb2.WrapMode = WrapMode.TileFlipXY;
                    '                            e.Graphics.FillPath(lgbThumb2, gp);
                    '                        }

                End Using
            End Using

            'draw focusing rectangle
            If Focused And DrawFocusRectangle Then
                Using p As New Pen(Color.FromArgb(200, barPenColorPaint))
                    p.DashStyle = DashStyle.Dot
                    Dim r As Rectangle = ClientRectangle
                    r.Width -= 2
                    r.Height -= 1
                    r.X += 1
                    'ControlPaint.DrawFocusRectangle(e.Graphics, r);                        
                    Using gpBorder As GraphicsPath = CreateRoundRectPath(r, BorderRoundRectSize)
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
                        e.Graphics.DrawPath(p, gpBorder)
                    End Using
                End Using
            End If
        Catch Err As Exception
            'Console.WriteLine(("DrawBackGround Error in " & Name & ":") + Err.Message)
        Finally
        End Try
    End Sub

#End Region

#Region "Overided events"

    Private mouseInRegion As Boolean = False
    ''' <summary>
    ''' Raises the <see cref="E:System.Windows.Forms.Control.EnabledChanged"></see> event.
    ''' </summary>
    ''' <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        MyBase.OnEnabledChanged(e)
        Invalidate()
    End Sub

    ''' <summary>
    ''' Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter"></see> event.
    ''' </summary>
    ''' <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        mouseInRegion = True
        Invalidate()
    End Sub

    ''' <summary>
    ''' Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave"></see> event.
    ''' </summary>
    ''' <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        mouseInRegion = False
        mouseInThumbRegion = False
        Invalidate()
    End Sub

    ''' <summary>
    ''' Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"></see> event.
    ''' </summary>
    ''' <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If e.Button = MouseButtons.Left Then
            Capture = True
            RaiseEvent Scroll(Me, New ScrollEventArgs(ScrollEventType.ThumbTrack, trackerValue))
            RaiseEvent ValueChanged(Me, New EventArgs())
            OnMouseMove(e)
        End If
    End Sub

    Private mouseInThumbRegion As Boolean = False

    ''' <summary>
    ''' Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"></see> event.
    ''' </summary>
    ''' <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        mouseInThumbRegion = IsPointInRect(e.Location, ThumbRect)
        If Capture And e.Button = MouseButtons.Left Then
            Dim [set] As ScrollEventType = ScrollEventType.ThumbPosition
            Dim pt As Point = e.Location
            Dim p As Integer = If(barOrientation = Orientation.Horizontal, pt.X, pt.Y)
            Dim margin As Integer = ThumbSize >> 1
            p -= margin
            Dim coef As Single = CSng(barMaximum - barMinimum) / CSng((If(barOrientation = Orientation.Horizontal, ClientSize.Width, ClientSize.Height)) - 2 * margin)
            trackerValue = CInt(Math.Truncate(p * coef + barMinimum))

            If trackerValue <= barMinimum Then
                trackerValue = barMinimum
                [set] = ScrollEventType.First
            ElseIf trackerValue >= barMaximum Then
                trackerValue = barMaximum
                [set] = ScrollEventType.Last
            End If

            RaiseEvent Scroll(Me, New ScrollEventArgs([set], trackerValue))
            RaiseEvent ValueChanged(Me, New EventArgs())
        End If
        Invalidate()
    End Sub

    ''' <summary>
    ''' Raises the <see cref="E:System.Windows.Forms.Control.MouseUp"></see> event.
    ''' </summary>
    ''' <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        Capture = False
        mouseInThumbRegion = IsPointInRect(e.Location, ThumbRect)
        RaiseEvent Scroll(Me, New ScrollEventArgs(ScrollEventType.EndScroll, trackerValue))
        RaiseEvent ValueChanged(Me, New EventArgs())
        Invalidate()
    End Sub

    ''' <summary>
    ''' Raises the <see cref="E:System.Windows.Forms.Control.MouseWheel"></see> event.
    ''' </summary>
    ''' <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
    Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
        MyBase.OnMouseWheel(e)
        'Dim v As Integer = e.Delta / 120 * (barMaximum - barMinimum) / MouseWheelBarPartitions
        Dim v As Integer = e.Delta / 120 * (barMaximum - barMinimum) / MouseWheelBarPartitions
        If e.Delta > 0 Then
            SetProperValue(Value + MouseWheelBarPartitions)
        Else
            SetProperValue(Value - MouseWheelBarPartitions)
        End If

    End Sub

    ''' <summary>
    ''' Raises the <see cref="E:System.Windows.Forms.Control.GotFocus"></see> event.
    ''' </summary>
    ''' <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    Protected Overrides Sub OnGotFocus(e As EventArgs)
        MyBase.OnGotFocus(e)
        Invalidate()
    End Sub

    ''' <summary>
    ''' Raises the <see cref="E:System.Windows.Forms.Control.LostFocus"></see> event.
    ''' </summary>
    ''' <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    Protected Overrides Sub OnLostFocus(e As EventArgs)
        MyBase.OnLostFocus(e)
        Invalidate()
    End Sub

    ''' <summary>
    ''' Raises the <see cref="E:System.Windows.Forms.Control.KeyUp"></see> event.
    ''' </summary>
    ''' <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs"></see> that contains the event data.</param>
    Protected Overrides Sub OnKeyUp(e As KeyEventArgs)
        MyBase.OnKeyUp(e)
        Select Case e.KeyCode
            Case Keys.Down, Keys.Left
                SetProperValue(Value - CInt(SmallChange))
                RaiseEvent Scroll(Me, New ScrollEventArgs(ScrollEventType.SmallDecrement, Value))
                Exit Select
            Case Keys.Up, Keys.Right
                SetProperValue(Value + CInt(SmallChange))
                RaiseEvent Scroll(Me, New ScrollEventArgs(ScrollEventType.SmallIncrement, Value))
                Exit Select
            Case Keys.Home
                Value = barMinimum
                Exit Select
            Case Keys.[End]
                Value = barMaximum
                Exit Select
            Case Keys.PageDown
                SetProperValue(Value - CInt(LargeChange))
                RaiseEvent Scroll(Me, New ScrollEventArgs(ScrollEventType.LargeDecrement, Value))
                Exit Select
            Case Keys.PageUp
                SetProperValue(Value + CInt(LargeChange))
                RaiseEvent Scroll(Me, New ScrollEventArgs(ScrollEventType.LargeIncrement, Value))
                Exit Select
        End Select
        'If Scroll IsNot Nothing AndAlso Value = barMinimum Then
        '    RaiseEvent Scroll(Me, New ScrollEventArgs(ScrollEventType.First, Value))
        'End If
        'If Scroll IsNot Nothing AndAlso Value = barMaximum Then
        '    RaiseEvent Scroll(Me, New ScrollEventArgs(ScrollEventType.Last, Value))
        'End If
        If Value = barMinimum Then
            RaiseEvent Scroll(Me, New ScrollEventArgs(ScrollEventType.First, Value))
        End If
        If Value = barMaximum Then
            RaiseEvent Scroll(Me, New ScrollEventArgs(ScrollEventType.Last, Value))
        End If
        Dim pt As Point = PointToClient(Cursor.Position)
        OnMouseMove(New MouseEventArgs(MouseButtons.None, 0, pt.X, pt.Y, 0))
    End Sub

    ''' <summary>
    ''' Processes a dialog key.
    ''' </summary>
    ''' <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"></see> values that represents the key to process.</param>
    ''' <returns>
    ''' true if the key was processed by the control; otherwise, false.
    ''' </returns>
    Protected Overrides Function ProcessDialogKey(keyData As Keys) As Boolean
        If keyData = Keys.Tab Or ModifierKeys = Keys.Shift Then
            Return MyBase.ProcessDialogKey(keyData)
        Else
            OnKeyDown(New KeyEventArgs(keyData))
            Return True
        End If
    End Function

#End Region

#Region "Help routines"

    ''' <summary>
    ''' Creates the round rect path.
    ''' </summary>
    ''' <param name="rect">The rectangle on which graphics path will be spanned.</param>
    ''' <param name="size">The size of rounded rectangle edges.</param>
    ''' <returns></returns>
    Public Shared Function CreateRoundRectPath(rect As Rectangle, size As Size) As GraphicsPath
        Dim gp As New GraphicsPath()
        gp.AddLine(CInt(rect.Left + size.Width / 2), CInt(rect.Top), CInt(rect.Right - size.Width / 2), CInt(rect.Top))
        gp.AddArc(rect.Right - size.Width, rect.Top, size.Width, size.Height, 270, 90)

        gp.AddLine(CInt(rect.Right), CInt(rect.Top + size.Height / 2), CInt(rect.Right), CInt(rect.Bottom - size.Width / 2))
        gp.AddArc(rect.Right - size.Width, rect.Bottom - size.Height, size.Width, size.Height, 0, 90)

        gp.AddLine(CInt(rect.Right - size.Width / 2), CInt(rect.Bottom), CInt(rect.Left + size.Width / 2), CInt(rect.Bottom))
        gp.AddArc(rect.Left, rect.Bottom - size.Height, size.Width, size.Height, 90, 90)

        gp.AddLine(CInt(rect.Left), CInt(rect.Bottom - size.Height / 2), CInt(rect.Left), CInt(rect.Top + size.Height / 2))
        gp.AddArc(rect.Left, rect.Top, size.Width, size.Height, 180, 90)
        Return gp
    End Function

    ''' <summary>
    ''' Desaturates colors from given array.
    ''' </summary>
    ''' <param name="colorsToDesaturate">The colors to be desaturated.</param>
    ''' <returns></returns>
    Public Shared Function DesaturateColors(ParamArray colorsToDesaturate As Color()) As Color()
        Dim colorsToReturn As Color() = New Color(colorsToDesaturate.Length - 1) {}
        For i As Integer = 0 To colorsToDesaturate.Length - 1
            'use NTSC weighted avarage
            Dim gray As Integer = CInt(colorsToDesaturate(i).R * 0.3 + colorsToDesaturate(i).G * 0.6 + colorsToDesaturate(i).B * 0.1)
            colorsToReturn(i) = Color.FromArgb(-&H10101 * (255 - gray) - 1)
        Next
        Return colorsToReturn
    End Function

    ''' <summary>
    ''' Lightens colors from given array.
    ''' </summary>
    ''' <param name="colorsToLighten">The colors to lighten.</param>
    ''' <returns></returns>
    Public Shared Function LightenColors(ParamArray colorsToLighten As Color()) As Color()
        Dim colorsToReturn As Color() = New Color(colorsToLighten.Length - 1) {}
        For i As Integer = 0 To colorsToLighten.Length - 1
            colorsToReturn(i) = ControlPaint.Light(colorsToLighten(i))
        Next
        Return colorsToReturn
    End Function

    ''' <summary>
    ''' Sets the trackbar value so that it wont exceed allowed range.
    ''' </summary>
    ''' <param name="val">The value.</param>
    Private Sub SetProperValue(val As Integer)
        If val < barMinimum Then
            Value = barMinimum
        ElseIf val > barMaximum Then
            Value = barMaximum
        Else
            Value = val
        End If
    End Sub

    ''' <summary>
    ''' Determines whether rectangle contains given point.
    ''' </summary>
    ''' <param name="pt">The point to test.</param>
    ''' <param name="rect">The base rectangle.</param>
    ''' <returns>
    ''' 	<c>true</c> if rectangle contains given point; otherwise, <c>false</c>.
    ''' </returns>
    Private Shared Function IsPointInRect(pt As Point, rect As Rectangle) As Boolean
        If pt.X > rect.Left And pt.X < rect.Right And pt.Y > rect.Top And pt.Y < rect.Bottom Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region

End Class
