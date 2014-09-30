Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports Microsoft.VisualBasic.Devices
Imports VisualLoveProject_2._0_Ultimate.Help

Public Class UserTabControl
    Inherits TabControl

    Private Mouse_Position As Point
    Private MouseState As Boolean = False
    Private MouseStateClick As Boolean = False

    Private ImageBackground1 As Boolean = True
    Private ImageRezise1 As Boolean = False
    Private Imagen As Image = My.Resources.Fondo_vb_net_2010
    Private BordeRadius As Integer = 2

    Private ItemsTextNormalColor As SolidBrush = New SolidBrush(Color.White)
    Private ItemsTextSelectionColor As SolidBrush = New SolidBrush(Color.Black)
    Private ItemsTextHoverColor As SolidBrush = New SolidBrush(Color.White)

    Private BackgroundItemsNormalColor As SolidBrush = New SolidBrush(Color.FromArgb(43, 60, 89))
    Private BackgroundItemsSelectionColor As SolidBrush = New SolidBrush(Color.FromArgb(255, 250, 236)) ' New SolidBrush(Color.FromArgb(255, 232, 166))
    Private BackgroundItemsHoverColor As SolidBrush = New SolidBrush(Color.White)

    Private BackgroundColor As SolidBrush = New SolidBrush(Color.FromArgb(43, 60, 89))
    'Public BackgroundImageControl As Boolean = False

    'Eventos del botton cerrar.
    Public Event CloseItemsTab(ByVal tp As TabPage)

    Private RectItems As New Rectangle

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.DrawMode = TabDrawMode.OwnerDrawFixed

        SetStyle(ControlStyles.AllPaintingInWmPaint Or _
                  ControlStyles.OptimizedDoubleBuffer Or _
                  ControlStyles.ResizeRedraw Or _
                  ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint, True)

        Me.DoubleBuffered = True
        'Me.ItemSize = New Size(0, 20)

    End Sub


#Region "Metodos Principales"

    Private Const TCM_FIRST As Int32 = &H1300
    Private Const TCM_ADJUSTRECT As Int32 = (TCM_FIRST + 40)
    Private Structure RECT
        Public Left, Top, Right, Bottom As Int32
    End Structure

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If (m.Msg = TCM_ADJUSTRECT) Then
            Dim rc As RECT = DirectCast(m.GetLParam(GetType(RECT)), RECT)
            rc.Left -= 4 '5
            rc.Right += 3.8
            rc.Top -= -2.5 '-2
            rc.Bottom += -4 '1
            Marshal.StructureToPtr(rc, m.LParam, True)
        Else
            'MyBase.WndProc(m)
        End If
        MyBase.WndProc(m)
    End Sub

    'Protected Overrides ReadOnly Property CreateParams As System.Windows.Forms.CreateParams

    '    Get
    '        Dim cp As CreateParams = MyBase.CreateParams
    '        cp.ExStyle = cp.ExStyle Or &H2000000
    '        ' Turn on WS_EX_COMPOSITED
    '        Return cp
    '    End Get

    'End Property

    'Dibuja los bordes del tabItems redondos.
    Private Function CreateRoundRectGraphicsPath(r As Rectangle, ByVal Radius As Integer) As GraphicsPath
        Dim gp As New GraphicsPath()
        'Dim radius As Integer = 2 'r.Width / 2

        'Line Top ===============================================
        gp.AddLine(r.X + Radius, r.Y, (r.Right) - Radius, r.Y)

        If Radius = 2 Or Radius = 3 Then
            gp.AddArc(r.Right - Radius, r.Y, Radius - 1, Radius - 1, 270, 90)
        ElseIf Radius = 1 Then
            gp.AddArc(r.Right - Radius, r.Y, Radius + 1, Radius, 180, 90)
        ElseIf Radius = 10 Then
            gp.AddArc(r.Right - Radius, r.Y, Radius - 1, Radius + 1, 270, 90)
        Else
            gp.AddArc(r.Right - Radius, r.Y, Radius - 1, Radius - 1, 270, 90)
        End If
        '========================================================

        gp.AddLine(r.Right, r.Y + Radius, r.Right, r.Bottom)

        gp.AddLine(r.Right, r.Bottom, r.X, r.Bottom)

        gp.AddLine(r.X, r.Bottom - Radius, r.X, r.Y + Radius)
        gp.AddArc(r.X, r.Y, Radius, Radius, 180, 90)

        gp.CloseFigure()
        Return gp
    End Function

    Private Function CreateRoundRectGraphicsPath2(r As Rectangle, Radius As Integer) As GraphicsPath
        Dim gp As New GraphicsPath()
        gp.AddLine(r.X, r.Bottom, r.X, r.Y + Radius)
        gp.AddArc(r.X, r.Y, Radius * 2, Radius * 2, 180, 90)
        gp.AddLine(r.X + Radius, r.Y, r.Right - Radius, r.Y)
        gp.AddArc(r.Right - Radius * 2, r.Y, Radius * 2, Radius * 2, 270, 90)
        gp.AddLine(r.Right, r.Y + Radius, r.Right, r.Bottom)
        Return gp
    End Function

    Private Function CreateRoundRectGraphicsPath3(r As Rectangle, Radius As Integer) As GraphicsPath
        Dim gp As New GraphicsPath()
        gp.AddLine(r.Right, r.Y, r.Right, r.Bottom - Radius)
        gp.AddArc(r.Right - Radius * 2, r.Bottom - Radius * 2, Radius * 2, Radius * 2, 0, 90)
        gp.AddLine(r.Right - Radius, r.Bottom, r.X + Radius, r.Bottom)
        gp.AddArc(r.X, r.Bottom - Radius * 2, Radius * 2, Radius * 2, 90, 90)
        gp.AddLine(r.X, r.Bottom - Radius, r.X, r.Y)
        Return gp
    End Function

    Private Sub DrawRoundRect(g As Graphics, p As Pen, r As Rectangle, ByVal Radius As Integer)
        Using gp As GraphicsPath = CreateRoundRectGraphicsPath2(r, Radius)
            g.DrawPath(p, gp)
        End Using
    End Sub

    Private Sub FillRoundRect(g As Graphics, b As Brush, r As Rectangle, ByVal Radius As Integer)
        Using gp As GraphicsPath = CreateRoundRectGraphicsPath2(r, Radius)
            g.FillPath(b, gp)
        End Using
    End Sub

    Private Sub FillRoundRectButton(g As Graphics, b As Brush, r As Rectangle, ByVal Radius As Integer)
        Using gp As GraphicsPath = CreateRoundRectGraphicsPath3(r, Radius)
            g.FillPath(b, gp)
        End Using
    End Sub

    Private Sub DrawRoundRectButton(g As Graphics, p As Pen, r As Rectangle, ByVal Radius As Integer)
        Using gp As GraphicsPath = CreateRoundRectGraphicsPath3(r, Radius)
            g.DrawPath(p, gp)
        End Using
    End Sub


#End Region

#Region "Property"

    <Description("Alinea el texto de las pestañas."), Category("Appearance")> _
    Public Property TextAling As TextAling = Help.TextAling.Left

    <Description("Apariencia del control."), Category("Appearance")> _
    Public Property StyleControl As StyleControl = StyleControl.VS2010
    'Public Property Image As Image

    <Description("Le proporciona una imagen de fondo al control tabcontrol."), Category("Appearance")> _
    Public Property Image As Image
        Get
            Return Imagen
        End Get
        Set(value As Image)
            Imagen = value
            Me.Invalidate()
        End Set
    End Property

    <Description("Habilita la imagen de fondo."), Category("Appearance")> _
    Public Property ImageBackground As Boolean
        Get
            Return ImageBackground1
        End Get
        Set(value As Boolean)
            ImageBackground1 = value
            Me.Invalidate()
        End Set
    End Property

    <Description("Permite redimencionar la imagen al tabcontrol."), Category("Appearance")> _
    Public Property ImageRezise As Boolean
        Get
            Return ImageRezise1
        End Get
        Set(value As Boolean)
            ImageRezise1 = value
            Me.Invalidate()
        End Set
    End Property

#End Region

    'Function para dibujar la interfas del control.
    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Dibuja el fondo del tabcontrol.
        BackGrounderDraw(e)

        'Dibuja la pestaña normal.
        TabItemsNormal(e)

        'Dibuja la pestaña seleccionada.
        TabItemsSelection(e)

        'Dibuja la pestaña cuando el mouse esta situado encima.
        TabItemsHover(e)

        'Dibuja las imagenes de las tabItems.
        TabItemsImageDraw(e)

        'Dibuja el botton close en las pestañas.
        TabItemsCloseButtons(e)

        'Dibuja el botton close en las pestañas.2
        TabItemsCloseButtonsSelection(e)

        'Dibuja el botton close en las pestañas.3
        TabItemsCloseButtonsDown(e)

        'Dibuja la linea superior e inferior del tabcontrol.
        DrawLineTab(e)

    End Sub

    'Dibuja la pestaña normal.
    Private Sub TabItemsNormal(ByVal e As Windows.Forms.PaintEventArgs)
        e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.None
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor

        If Me.TabCount - 1 >= 0 Then
            For i = 0 To Me.TabCount - 1
                RectItems = Me.GetTabRect(i)

                'e.Graphics.DrawRectangle(Pens.Aqua, Me.GetTabRect(i))

                'Dibuja el texto en el centro.
                If TextAling = Help.TextAling.Center AndAlso _
                    Me.ImageList IsNot Nothing AndAlso _
                    Me.TabPages(i).ImageIndex = Not Nothing Or _
                    TextAling = Help.TextAling.Center AndAlso _
                    Me.TabPages(i).ImageIndex = Not Nothing Then

                    e.Graphics.DrawString(Me.TabPages(i).Text, Me.Font, ItemsTextNormalColor, TextCenter(i).X, TextCenter(i).Y - 1)

                ElseIf TextAling = Help.TextAling.Center AndAlso _
                         Me.TabPages(i).ImageIndex AndAlso Me.ImageList IsNot Nothing Then

                    e.Graphics.DrawString(Me.TabPages(i).Text, Me.Font, ItemsTextNormalColor, TextCenter(i).X + 15, TextCenter(i).Y - 1)

                ElseIf TextAling = Help.TextAling.Center Then
                    e.Graphics.DrawString(Me.TabPages(i).Text, Me.Font, ItemsTextNormalColor, TextCenter(i).X, TextCenter(i).Y - 1)
                End If

                'Dibuja el texto a la derecha.
                If TextAling = Help.TextAling.Left AndAlso _
                    Me.ImageList IsNot Nothing AndAlso _
                    Me.TabPages(i).ImageIndex = Not Nothing Or _
                    TextAling = Help.TextAling.Left AndAlso _
                    Me.TabPages(i).ImageIndex = Not Nothing Then

                    e.Graphics.DrawString(Me.TabPages(i).Text, Me.Font, ItemsTextNormalColor, RectItems.X + 5, RectItems.Y + 4)

                ElseIf TextAling = Help.TextAling.Left AndAlso _
                         Me.TabPages(i).ImageIndex AndAlso Me.ImageList IsNot Nothing Then

                    e.Graphics.DrawString(Me.TabPages(i).Text, Me.Font, ItemsTextNormalColor, RectItems.X + 20, RectItems.Y + 4)

                ElseIf TextAling = Help.TextAling.Left Then
                    e.Graphics.DrawString(Me.TabPages(i).Text, Me.Font, ItemsTextNormalColor, RectItems.X + 5, RectItems.Y + 4)
                End If

            Next
        End If
    End Sub

    'Dibuja la pestaña seleccionada.
    Private Sub TabItemsSelection(ByVal e As Windows.Forms.PaintEventArgs)

        e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.None
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor

        If Me.SelectedIndex <> -1 Then
            RectItems = Me.GetTabRect(Me.SelectedIndex)

            Dim ColorUp As Color = Color.White 'Color.FromArgb(255, 250, 236)
            Dim colordown As Color = Color.FromArgb(255, 232, 166)
            Dim NewRectColor As New Rectangle(0, 0, RectItems.Width, RectItems.Height + 5)
            '
            Using LineGradiantColor As New LinearGradientBrush(NewRectColor, ColorUp, colordown, 90.0F)
                FillRoundRect(e.Graphics, LineGradiantColor, RectItems, BordeRadius)
            End Using
            '
            Dim Index As Integer = Me.SelectedIndex

            'Dibuja el texto en el centro.
            If TextAling = Help.TextAling.Center AndAlso _
                Me.ImageList IsNot Nothing AndAlso _
                Me.TabPages(Index).ImageIndex = Not Nothing Or _
                TextAling = Help.TextAling.Center AndAlso _
                Me.TabPages(Index).ImageIndex = Not Nothing Then

                e.Graphics.DrawString(Me.TabPages(Index).Text, Me.Font, ItemsTextSelectionColor, TextCenter(Index).X, TextCenter(Index).Y - 1)

            ElseIf TextAling = Help.TextAling.Center AndAlso _
                     Me.TabPages(Index).ImageIndex AndAlso Me.ImageList IsNot Nothing Then

                e.Graphics.DrawString(Me.TabPages(Index).Text, Me.Font, ItemsTextSelectionColor, TextCenter(Index).X + 15, TextCenter(Index).Y - 1)

            ElseIf TextAling = Help.TextAling.Center Then
                e.Graphics.DrawString(Me.TabPages(Index).Text, Me.Font, ItemsTextSelectionColor, TextCenter(Index).X, TextCenter(Index).Y - 1)
            End If

            'Dibuja el texto a la derecha.
            If TextAling = Help.TextAling.Left AndAlso _
                Me.ImageList IsNot Nothing AndAlso _
                Me.TabPages(Index).ImageIndex = Not Nothing Or _
                TextAling = Help.TextAling.Left AndAlso _
                Me.TabPages(Index).ImageIndex = Not Nothing Then

                e.Graphics.DrawString(Me.TabPages(Index).Text, Me.Font, ItemsTextSelectionColor, RectItems.X + 5, RectItems.Y + 4)

            ElseIf TextAling = Help.TextAling.Left AndAlso _
                     Me.TabPages(Index).ImageIndex AndAlso Me.ImageList IsNot Nothing Then

                e.Graphics.DrawString(Me.TabPages(Index).Text, Me.Font, ItemsTextSelectionColor, RectItems.X + 20, RectItems.Y + 4)

            ElseIf TextAling = Help.TextAling.Left Then
                e.Graphics.DrawString(Me.TabPages(Index).Text, Me.Font, ItemsTextSelectionColor, RectItems.X + 5, RectItems.Y + 4)
            End If

        End If
    End Sub

    'Dibuja la pestaña cuando el mouse esta situado encima.
    Private Sub TabItemsHover(ByVal e As Windows.Forms.PaintEventArgs)
        For i As Integer = 0 To Me.TabCount - 1
            Dim RectItems1 As Rectangle = Me.GetTabRect(i)

            Dim ColorUp As Color = Color.White 'Color.FromArgb(255, 250, 236)
            Dim colordown As Color = Color.FromArgb(255, 232, 166)
            Dim NewRectColor As New Rectangle(0, 0, RectItems1.Width, RectItems1.Height + 5)
            '

            Dim ColorBeta As SolidBrush = New SolidBrush(Color.FromArgb(180, 43, 60, 89))
            Dim ColorBeta1 As Pen = New Pen(Color.White)

            If MouseState = True AndAlso RectItems1.Contains(Mouse_Position) = True Then

                If Me.SelectedIndex = i Then
                Else
                    Using LineGradiantColor As New LinearGradientBrush(NewRectColor, ColorUp, colordown, 90.0F)
                        FillRoundRect(e.Graphics, LineGradiantColor, RectItems1, BordeRadius)
                    End Using

                    FillRoundRect(e.Graphics, ColorBeta, RectItems1, BordeRadius)
                    DrawRoundRect(e.Graphics, ColorBeta1, RectItems1, BordeRadius)

                    'Dibuja el texto en el centro.
                    If TextAling = Help.TextAling.Center AndAlso _
                        Me.ImageList IsNot Nothing AndAlso _
                        Me.TabPages(i).ImageIndex = Not Nothing Or _
                        TextAling = Help.TextAling.Center AndAlso _
                        Me.TabPages(i).ImageIndex = Not Nothing Then

                        e.Graphics.DrawString(Me.TabPages(i).Text, Me.Font, ItemsTextHoverColor, TextCenter(i).X, TextCenter(i).Y - 1)

                    ElseIf TextAling = Help.TextAling.Center AndAlso _
                             Me.TabPages(i).ImageIndex AndAlso Me.ImageList IsNot Nothing Then

                        e.Graphics.DrawString(Me.TabPages(i).Text, Me.Font, ItemsTextHoverColor, TextCenter(i).X + 15, TextCenter(i).Y - 1)

                    ElseIf TextAling = Help.TextAling.Center Then
                        e.Graphics.DrawString(Me.TabPages(i).Text, Me.Font, ItemsTextHoverColor, TextCenter(i).X, TextCenter(i).Y - 1)
                    End If

                    'Dibuja el texto a la derecha.
                    If TextAling = Help.TextAling.Left AndAlso _
                        Me.ImageList IsNot Nothing AndAlso _
                        Me.TabPages(i).ImageIndex = Not Nothing Or _
                        TextAling = Help.TextAling.Left AndAlso _
                        Me.TabPages(i).ImageIndex = Not Nothing Then

                        e.Graphics.DrawString(Me.TabPages(i).Text, Me.Font, ItemsTextHoverColor, RectItems1.X + 5, RectItems1.Y + 4)

                    ElseIf TextAling = Help.TextAling.Left AndAlso _
                             Me.TabPages(i).ImageIndex AndAlso Me.ImageList IsNot Nothing Then

                        e.Graphics.DrawString(Me.TabPages(i).Text, Me.Font, ItemsTextHoverColor, RectItems1.X + 20, RectItems1.Y + 4)

                    ElseIf TextAling = Help.TextAling.Left Then
                        e.Graphics.DrawString(Me.TabPages(i).Text, Me.Font, ItemsTextHoverColor, RectItems1.X + 5, RectItems1.Y + 4)
                    End If

                    Try
                        Dim Index As Integer = i
                        Dim rect As Rectangle = Me.GetTabRect(Index)
                        e.Graphics.DrawImage(My.Resources.Close_Normal, (rect.Right) - 20, 5, 16, 16)
                    Catch ex As Exception
                    End Try

                    Dim R1 As Rectangle = Me.GetTabRect(i)
                    Dim R2 As New Rectangle((R1.Right) - 20, 5, 16, 16)

                    If R2.Contains(Mouse_Position) Then
                        e.Graphics.DrawImage(My.Resources.Close_Up, R2)
                    End If
                End If

            End If

        Next
    End Sub

    'Dibuja la linea superior e inferior del tabcontrol.
    Private Sub DrawLineTab(ByVal e As Windows.Forms.PaintEventArgs)
        e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.None
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor

        If Me.TabCount - 1 < 0 Then
        Else
            Dim colordown As Color = Color.FromArgb(255, 232, 166)
            Dim NewRectColor As New Rectangle(0, 22, Me.Width, 5)
            FillRoundRect(e.Graphics, New SolidBrush(colordown), NewRectColor, BordeRadius)

            Dim NewRectColor2 As New Rectangle(0, Me.Height - 8, Me.Width, 5)
            FillRoundRectButton(e.Graphics, New SolidBrush(colordown), NewRectColor2, BordeRadius)
        End If

    End Sub

    'Dibuja el fondo del tabcontrol.
    Private Sub BackGrounderDraw(ByVal e As Windows.Forms.PaintEventArgs)
        Dim rb As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        'If Me.Image IsNot Nothing Then Exit Sub
        Try

            e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.None
            e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor

            If ImageBackground1 = True AndAlso ImageRezise1 = False Then
                e.Graphics.DrawImage(Imagen, 0, 0)
            ElseIf ImageBackground1 = True AndAlso ImageRezise1 = True Then

                'e.Graphics.DrawImage(ImageRezise1, 0, 0)

                Dim DrawRect = New Rectangle(0, 0, Me.Imagen.Width * 2, Me.Imagen.Height * 2)
                e.Graphics.DrawImage(Me.Image, DrawRect)

            Else
                e.Graphics.FillRectangle(BackgroundColor, rb)
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Alinea el Texto de los items en el cento de la pestaña.
    Private Function TextCenter(ByVal Index As Integer) As Point
        RectItems = Me.GetTabRect(Index)

        Dim PointX As Integer = (RectItems.X + Me.TabPages(Index).Text.Length) + 2 '* 2
        Dim PointY As Integer = RectItems.Y * 3

        Return New Point(PointX, PointY)
    End Function

    'Dibuja las imagenes de las tabItems.
    Private Sub TabItemsImageDraw(ByVal e As Windows.Forms.PaintEventArgs)
        e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.None
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor

        Dim tabImage As Image = Nothing
        For i = 0 To Me.TabCount - 1

            If Me.TabPages(i).ImageIndex > -1 AndAlso Me.ImageList IsNot Nothing Then
                tabImage = Me.ImageList.Images(Me.TabPages(i).ImageIndex)
            ElseIf Me.TabPages(i).ImageKey.Trim().Length > 0 AndAlso Me.ImageList IsNot Nothing Then
                tabImage = Me.ImageList.Images(Me.TabPages(i).ImageKey)
            End If

            If tabImage IsNot Nothing Then
                Dim rect As Rectangle = Me.GetTabRect(i)
                e.Graphics.DrawImage(tabImage, rect.X + 2, 5, 16, 16)
            End If

        Next
    End Sub

    'Dibuja el botton close en las pestañas.
    Private Sub TabItemsCloseButtons(ByVal e As Windows.Forms.PaintEventArgs)
        e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.None
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor

        Try
            Dim Index As Integer = Me.SelectedIndex
            Dim rect As Rectangle = Me.GetTabRect(Index)
            e.Graphics.DrawImage(My.Resources.Close_Normal, (rect.Right) - 20, 5, 16, 16)
        Catch ex As Exception
        End Try

    End Sub

    'Dibuja el botton close en las pestañas.
    Private Sub TabItemsCloseButtonsSelection(ByVal e As Windows.Forms.PaintEventArgs)
        e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.None
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor

        Try
            For I As Integer = 0 To TabPages.Count - 1
                Dim R1 As Rectangle = Me.GetTabRect(I)
                Dim R2 As New Rectangle((R1.Right) - 20, 5, 16, 16)

                If MouseState = True Then
                    If R2.Contains(Mouse_Position) AndAlso Me.SelectedIndex = I Then
                        e.Graphics.DrawImage(My.Resources.Close_Up, R2)
                    End If
                End If
            Next
        Catch ex As Exception
        End Try

    End Sub

    'Dibuja el botton close en las pestañas.
    Private Sub TabItemsCloseButtonsDown(ByVal e As Windows.Forms.PaintEventArgs)
        e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.None
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor

        Try
            For I As Integer = 0 To TabPages.Count - 1
                Dim R1 As Rectangle = Me.GetTabRect(I)
                Dim R2 As New Rectangle((R1.Right) - 20, 5, 16, 16)

                If MouseState = True Then
                    If R2.Contains(Mouse_Position) AndAlso MouseStateClick = True AndAlso R2.Contains(Mouse_Position) Then
                        e.Graphics.DrawImage(My.Resources.Close_Down, R2)
                        Me.Invalidate()
                    End If
                Else
                    Exit For
                End If
            Next
        Catch ex As Exception
        End Try

    End Sub

    'Se produce cuando el mouse esta dentro de una pestaña.
    Private Sub DarkUserTabControl_MouseEnter(sender As Object, e As System.EventArgs) Handles Me.MouseEnter
        MouseState = True
        Me.Invalidate()
    End Sub

    'Se produce cuando el mouse deja el control.
    Private Sub DarkUserTabControl_MouseLeave(sender As Object, e As System.EventArgs) Handles Me.MouseLeave
        MouseStateClick = False

        MouseState = False
        Me.Invalidate()
    End Sub

    'Se produce cuando el mouse se mueve dentro del coontrol.
    Private Sub DarkUserTabControl_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Mouse_Position = e.Location
        Me.Invalidate()
    End Sub

    'Se produce cuando el mouse esta sobre el control y se preciona un boton.
    Private Sub DarkUserTabControl_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            MouseStateClick = True
        End If
    End Sub

    'Se produce cuando se suelta un boton del mosue sobre el control.
    Private Sub DarkUserTabControl_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If MouseStateClick = True Then
            CloseTabSelection(e)
        End If

        MouseStateClick = False
        Me.Invalidate()
    End Sub

    'Comprueba si el mouse esta encima de una pestaña y la selecciona. 
    Public Function GetTabPageSelected(ByVal pt As Point, ByVal TabControl As TabControl) As TabPage
        Dim tp As TabPage = Nothing
        For i As Integer = 0 To TabControl.TabPages.Count - 1

            Dim R1 As Rectangle = Me.GetTabRect(i)
            Dim R2 As New Rectangle((R1.Right) - 20, 5, 16, 16)

            If TabControl.GetTabRect(i).Contains(pt) AndAlso R2.Contains(Mouse_Position) Then
                tp = TabControl.TabPages(i)
                Exit For
            End If
        Next
        Return tp
    End Function

    ' Obtiene la pestaña seleccionada.
    Private Sub CloseTabSelection(ByVal e As MouseEventArgs)
        Dim pt As New Point(e.X, e.Y)
        Dim tp As TabPage = GetTabPageSelected(pt, Me)
        If tp IsNot Nothing AndAlso MouseStateClick = True Then
            RaiseEvent CloseItemsTab(tp)
            MouseStateClick = False
        End If
    End Sub

End Class
