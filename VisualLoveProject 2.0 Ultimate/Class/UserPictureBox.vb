Imports System.Drawing.Imaging

Public Class UserPictureBox

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)

        Me.DoubleBuffered = True
    End Sub

    'Propiedad para cargar la imagen.
    Public Property Image As System.Drawing.Image
        Get
            Return ImageDraping
        End Get
        Set(value As System.Drawing.Image)
            ImageDraping = value
            Try

                ZoomImage = New Size(value.Width, value.Height)

                If ZoomControl = True Then
                    ZoomFactory = 1.0F
                End If

                ZoomFactor = ZoomFactory 'Establece el valor por defecto.
               
                MouseClicked = False
                MouseDownPoint = New Point(0, 0)
                NewPointImage = New Point(0, 0)
                ImageMoved = True
                Me.Cursor = Cursors.Default

                If value.Width < Me.Width And value.Height < Me.Height Then
                    ImageCenter()
                    ImageMoved = False
                ElseIf value.Width < Me.ClientSize.Width Then
                    ImageCenterWidth()
                    ImageMoved = False
                ElseIf value.Height < Me.ClientSize.Height Then
                    ImageCenterHeight()
                    ImageMoved = False
                End If

            Catch ex As Exception
            End Try
            Me.Invalidate()
        End Set
    End Property

    Public Property ZoomFactory As Double
        Get
            Return ZoomFactor
        End Get
        Set(value As Double)
            ZoomFactor = value
            ImageCenter()
            Me.Invalidate()
        End Set
    End Property

    Public Property ZoomControl As Boolean = True

    Private ImageDraping As Image
    Private NewPointImage As Point

    Private ZoomImage As Size
    Private ZoomFactor As Double = 1.0F
    Private PointWheel As Point
    Private ImageMoved As Boolean = False
    Private IsZoom As Boolean = False

    Private MouseClicked As Boolean = False
    Private MouseDownPoint As Point
    Private MousePoint As Point
    Private DrawRect As Rectangle

    'Se produce cuando el mouse es precionado dentro del control.
    Private Sub PictureBox1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Dim NewSizeWidth As Integer = (ZoomImage.Width * ZoomFactor)
        Dim NewSizeHeight As Integer = (ZoomImage.Height * ZoomFactor)

        If e.Button = Windows.Forms.MouseButtons.Left AndAlso ZoomControl = True Then
            MouseClicked = True
            MouseDownPoint = New Point(e.X, e.Y)
            If NewSizeWidth >= Me.ClientSize.Width Or NewSizeHeight >= Me.ClientSize.Height Then
                ImageMoved = True
                Me.Cursor = Cursors.SizeAll
            Else
                ImageMoved = False
            End If
        End If

        Me.Invalidate()
    End Sub

    'Se produce cuando el cursor deja el control.
    Private Sub PictureBox1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        MouseClicked = False
        MouseDownPoint = New Point(0, 0)
        If ImageMoved = True Then
            Me.Cursor = Cursors.Hand
        Else
            Me.Cursor = Cursors.Default
        End If
    End Sub

    'Se ejecuta cuando el control resibe el foco.
    Private Sub PictureBox1_MouseHover(sender As Object, e As System.EventArgs) Handles Me.MouseHover
        Me.Focus()
        IsZoom = True
        Try
            Dim NewSizeWidth As Integer = (ZoomImage.Width * ZoomFactor)
            Dim NewSizeHeight As Integer = (ZoomImage.Height * ZoomFactor)

            If NewSizeWidth > Me.ClientSize.Width Or NewSizeHeight > Me.ClientSize.Height AndAlso ZoomControl = True Then
                Me.Cursor = Cursors.Hand
            Else
                Me.Cursor = Cursors.Default
            End If

        Catch ex As Exception
        End Try
    End Sub

    'Function para poder mover la imagen.
    Private Sub PictureBox1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        MousePoint = e.Location
        Dim Deltax As Integer = MouseDownPoint.X - e.X
        Dim Deltay As Integer = MouseDownPoint.Y - e.Y

        Dim NewSizeWidth As Integer = (ZoomImage.Width * ZoomFactor)
        Dim NewSizeHeight As Integer = (ZoomImage.Height * ZoomFactor)

        If MouseClicked = True And ImageMoved = True AndAlso ZoomControl = True = True Then

            If NewSizeWidth >= Me.ClientSize.Width And NewSizeHeight <= Me.ClientSize.Height Then
                NewPointImage.X = NewPointImage.X - Deltax
            ElseIf NewSizeHeight >= Me.ClientSize.Height And NewSizeWidth <= Me.ClientSize.Width Then
                NewPointImage.Y = NewPointImage.Y - Deltay
            Else
                NewPointImage.X = NewPointImage.X - Deltax
                NewPointImage.Y = NewPointImage.Y - Deltay
            End If

            Try
                If ZoomImage.Width * ZoomFactor >= Me.Width AndAlso ZoomImage.Height * ZoomFactor <= Me.Height Then
                    CheckBoundsWidth()
                End If

                If ZoomImage.Height * ZoomFactor >= Me.Height AndAlso ZoomImage.Width * ZoomFactor <= Me.Width Then
                    CheckBoundsHeight()
                End If

                If ZoomImage.Width * ZoomFactor >= Me.Width AndAlso ZoomImage.Height * ZoomFactor >= Me.Height Then
                    CheckBounds()
                End If
            Catch ex As Exception
            End Try

            MouseDownPoint.X = e.X
            MouseDownPoint.Y = e.Y

            Me.Invalidate()
        End If
    End Sub

    'Function para dibujar la imagen.
    Private Sub PictureBox1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Try
            e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.None
            e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor

            DrawRect = New Rectangle(NewPointImage.X, NewPointImage.Y, ZoomImage.Width * ZoomFactor, ZoomImage.Height * ZoomFactor)
            e.Graphics.DrawImage(Me.Image, DrawRect)

            'e.Graphics.DrawString("ZoomFactor: " & ZoomFactor & vbCrLf & _
            '                      "ZoomFactory: " & ZoomFactory, Me.Font, Brushes.Black, 0, 0)
        Catch ex As Exception
        End Try
    End Sub

    'Se produce cuando la rueda del mouse cambia.
    Private Sub PictureBox1_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        Dim mouse As MouseEventArgs = TryCast(e, MouseEventArgs)
        Dim mP As Point = mouse.Location

        Dim NewSizeWidth As Integer = (ZoomImage.Width * ZoomFactor)
        Dim NewSizeHeight As Integer = (ZoomImage.Height * ZoomFactor)

        If ZoomControl = True Then

            'Zoom In.
            If e.Delta > 0 And IsZoom = True Then
                If ZoomFactor >= 1 AndAlso ZoomFactor <= 40 Then
                    ZoomFactor += 1.0F

                    If NewSizeWidth < Me.ClientSize.Width AndAlso NewSizeHeight < Me.ClientSize.Height Then
                        ImageCenter()
                    Else
                        NewPointImage.X = NewPointImage.X - ((mP.X - NewPointImage.X) / (ZoomFactor - 1))
                        NewPointImage.Y = NewPointImage.Y - ((mP.Y - NewPointImage.Y) / (ZoomFactor - 1))
                    End If

                ElseIf ZoomFactor = 0.9 Then
                    ZoomFactor = ZoomFactor * 2

                    If NewSizeWidth < Me.ClientSize.Width AndAlso NewSizeHeight < Me.ClientSize.Height Then
                        ImageCenter()
                    Else
                        NewPointImage.X = NewPointImage.X - ((mP.X - NewPointImage.X))
                        NewPointImage.Y = NewPointImage.Y - ((mP.Y - NewPointImage.Y))
                    End If

                ElseIf ZoomFactor < 0.9 Then
                    ZoomFactor = ZoomFactor * 2

                    If NewSizeWidth < Me.ClientSize.Width And NewSizeHeight < Me.ClientSize.Height Then
                        ImageCenter()
                    Else
                        NewPointImage.X = NewPointImage.X - ((mP.X - NewPointImage.X))
                        NewPointImage.Y = NewPointImage.Y - ((mP.Y - NewPointImage.Y))
                    End If

                End If

                'Zoom Out.
            ElseIf e.Delta < 0 And IsZoom = True Then
                If ZoomFactor > 2 Then
                    ZoomFactor -= 1.0F

                    If NewSizeWidth < Me.ClientSize.Width And NewSizeHeight < Me.ClientSize.Height Then
                        ImageCenter()
                    Else
                        NewPointImage.X = NewPointImage.X + (((mP.X - NewPointImage.X)) / (ZoomFactor + 1))
                        NewPointImage.Y = NewPointImage.Y + (((mP.Y - NewPointImage.Y)) / (ZoomFactor + 1))
                    End If

                    ReOrganisarImage2()

                ElseIf ZoomFactor = 2 Then
                    ZoomFactor -= 1.0F

                    If NewSizeWidth < Me.ClientSize.Width And NewSizeHeight < Me.ClientSize.Height Then
                        ImageCenter()
                    Else
                        NewPointImage.X = NewPointImage.X + ((mP.X - NewPointImage.X) / 2)
                        NewPointImage.Y = NewPointImage.Y + ((mP.Y - NewPointImage.Y) / 2)
                    End If

                    ReOrganisarImage2()

                ElseIf ZoomFactor <= 1 AndAlso ZoomFactor > 0.2 Then
                    ZoomFactor = ZoomFactor / 2

                    If NewSizeWidth < Me.ClientSize.Width And NewSizeHeight < Me.ClientSize.Height Then
                        ImageCenter()
                    Else
                        NewPointImage.X = NewPointImage.X + ((mP.X - NewPointImage.X) / 2)
                        NewPointImage.Y = NewPointImage.Y + ((mP.Y - NewPointImage.Y) / 2)
                    End If

                    ReOrganisarImage2()

                End If

            End If

            If NewSizeWidth < Me.ClientSize.Width AndAlso NewSizeHeight < Me.ClientSize.Height And IsZoom = True Then
                ReOrganisarImage()
            ElseIf NewSizeWidth < Me.ClientSize.Width And IsZoom = True Then
                ReOrganisarImage2()

            ElseIf IsZoom = True Then
                ReOrganisarImage2()
            End If

            Me.Invalidate()

        End If
    End Sub

    'Function para saber si la imagen sobrepasa el tamaño.
    Private Sub CheckBounds()
        Dim ZoomImageLimit As New Size(ZoomImage.Width * ZoomFactor, ZoomImage.Height * ZoomFactor)

        If Me.Image Is Nothing Then Exit Sub

        ' Hace que la imagen no salga de las fronteras del contenedor.
        If ZoomImageLimit.Width >= 0 AndAlso NewPointImage.X >= 0 Then NewPointImage.X = 0

        ' Hace que la imagen no salga de las fronteras del contenedor.
        If ZoomImageLimit.Height >= 0 AndAlso NewPointImage.Y >= 0 Then NewPointImage.Y = 0
        '=================================================================================

        ' Hace que la imagen no salga de las fronteras del contenedor.
        If NewPointImage.Y <= Me.ClientSize.Height - ZoomImageLimit.Height Then NewPointImage.Y = Me.ClientSize.Height - ZoomImageLimit.Height

        ' Hace que la imagen no salga de las fronteras del contenedor.
        If NewPointImage.X <= Me.ClientSize.Width - ZoomImageLimit.Width Then NewPointImage.X = Me.ClientSize.Width - ZoomImageLimit.Width

        ' Hace que la imagen no salga de las fronteras del contenedor.
        If ZoomImageLimit.Width >= 0 AndAlso NewPointImage.X >= 0 Then NewPointImage.X = 0

        ' Hace que la imagen no salga de las fronteras del contenedor.
        If ZoomImageLimit.Height >= 0 AndAlso NewPointImage.Y >= 0 Then NewPointImage.Y = 0

        Me.Invalidate()
    End Sub

    'Function para saber si la imagen es mayor al tamaño de me.clientsize.width.
    Private Sub CheckBoundsWidth()
        Dim ZoomImageLimit As New Size(ZoomImage.Width * ZoomFactor, ZoomImage.Height * ZoomFactor)

        If Me.Image Is Nothing Then Exit Sub

        ' Hace que la imagen no salga de las fronteras del contenedor.
        If ZoomImageLimit.Width >= 0 AndAlso NewPointImage.X >= 0 Then NewPointImage.X = 0

        '=================================================================================
        'ImageCenter()
        '=================================================================================

        ' Hace que la imagen no salga de las fronteras del contenedor.
        If NewPointImage.X <= Me.ClientSize.Width - ZoomImageLimit.Width Then NewPointImage.X = Me.ClientSize.Width - ZoomImageLimit.Width

        ' Hace que la imagen no salga de las fronteras del contenedor.
        If ZoomImageLimit.Width >= 0 AndAlso NewPointImage.X >= 0 Then NewPointImage.X = 0

        Me.Invalidate()
    End Sub

    'Function para saber si la imagen es mayor al tamaño de me.clientsize.height.
    Private Sub CheckBoundsHeight()
        Dim ZoomImageLimit As New Size(ZoomImage.Width * ZoomFactor, ZoomImage.Height * ZoomFactor)

        If Me.Image Is Nothing Then Exit Sub

        ' Hace que la imagen no salga de las fronteras del contenedor.
        If ZoomImageLimit.Height >= 0 AndAlso NewPointImage.Y >= 0 Then NewPointImage.Y = 0
        '=================================================================================

        ' Hace que la imagen no salga de las fronteras del contenedor.
        If NewPointImage.Y <= Me.ClientSize.Height - ZoomImageLimit.Height Then NewPointImage.Y = Me.ClientSize.Height - ZoomImageLimit.Height

        ' Hace que la imagen no salga de las fronteras del contenedor.
        If ZoomImageLimit.Height >= 0 AndAlso NewPointImage.Y >= 0 Then NewPointImage.Y = 0

        Me.Invalidate()
    End Sub

    'Posiciona la imagen en el centro.
    Private Sub ImageCenter()
        Dim NewSizeWidth As Integer = (ZoomImage.Width * ZoomFactor)
        Dim NewSizeHeight As Integer = (ZoomImage.Height * ZoomFactor)

        Dim px As Integer = (Me.ClientSize.Width / 2) - (NewSizeWidth / 2)
        Dim py As Integer = (Me.ClientSize.Height / 2) - (NewSizeHeight / 2)

        NewPointImage.X = px
        NewPointImage.Y = py

        Me.Invalidate()
    End Sub

    'Posiciona la imagen en el centro de width.
    Private Sub ImageCenterWidth()
        Dim NewSizeWidth As Integer = (ZoomImage.Width * ZoomFactor)

        Dim px As Integer = (Me.Width / 2) - (NewSizeWidth / 2)
        NewPointImage.X = px

        Me.Invalidate()
    End Sub

    'Posiciona la imagen en el centro de height.
    Private Sub ImageCenterHeight()
        Dim NewSizeHeight As Integer = (ZoomImage.Height * ZoomFactor)

        Dim py As Integer = (Me.Height / 2) - (NewSizeHeight / 2)
        NewPointImage.Y = py

        Me.Invalidate()
    End Sub

    'Reorganisa la posicion de la imagen.
    Private Sub ReOrganisarImage()
        MouseDownPoint = New Point(MousePoint.X, MousePoint.Y)

        Dim NewSizeWidth As Integer = (ZoomImage.Width * ZoomFactor)
        Dim NewSizeHeight As Integer = (ZoomImage.Height * ZoomFactor)

        Try
            If NewSizeWidth > Me.Width AndAlso NewSizeHeight < Me.Height Then
                CheckBoundsWidth()
            End If

            If NewSizeHeight > Me.Height AndAlso NewSizeWidth < Me.Width Then
                CheckBoundsHeight()
            End If

            If NewSizeWidth > Me.Width AndAlso NewSizeHeight > Me.Height Then
                CheckBounds()
            End If

            '========================================================================================

            If NewSizeWidth < Me.ClientSize.Width And NewSizeHeight < Me.ClientSize.Height Then
                ImageCenter()
            ElseIf NewSizeWidth < Me.ClientSize.Width Then
                ImageCenterWidth()
            ElseIf NewSizeHeight < Me.ClientSize.Height Then
                ImageCenterHeight()
            Else

                If NewSizeWidth > Me.ClientSize.Width Then
                    ImageCenterWidth()
                ElseIf NewSizeHeight > Me.ClientSize.Height Then
                    ImageCenterHeight()
                End If

                CheckBounds()
            End If

            Me.Invalidate()
        Catch ex As Exception
        End Try
    End Sub

    'Reorganisa la posicion de la imagen2.
    Private Sub ReOrganisarImage2()
        MouseDownPoint = New Point(MousePoint.X, MousePoint.Y)

        Dim NewSizeWidth As Integer = (ZoomImage.Width * ZoomFactor)
        Dim NewSizeHeight As Integer = (ZoomImage.Height * ZoomFactor)

        Try
            If NewSizeWidth > Me.Width AndAlso NewSizeHeight < Me.Height Then
                CheckBoundsWidth()
            End If

            If NewSizeHeight > Me.Height AndAlso NewSizeWidth < Me.Width Then
                CheckBoundsHeight()
            End If

            If NewSizeWidth > Me.Width AndAlso NewSizeHeight > Me.Height Then
                CheckBounds()
            End If

            '========================================================================================

            If NewSizeWidth < Me.ClientSize.Width And NewSizeHeight < Me.ClientSize.Height Then
                ImageCenter()
            ElseIf NewSizeWidth < Me.ClientSize.Width Then
                ImageCenterWidth()
            ElseIf NewSizeHeight < Me.ClientSize.Height Then
                ImageCenterHeight()
            Else

                If NewSizeWidth > Me.ClientSize.Width Then
                    'ImageCenterWidth()
                ElseIf NewSizeHeight > Me.ClientSize.Height Then
                    ImageCenterHeight()
                End If

                CheckBounds()
            End If

            Me.Invalidate()
        Catch ex As Exception
        End Try
    End Sub

    'Ejecuta el reorganizado cuando cambia de tamaño.
    Private Sub UserZoomImage_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ReOrganisarImage2()
    End Sub

    'Ejecuta el reorganizado cuando cambia de tamaño.
    Private Sub UserZoomImage_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        ReOrganisarImage2()
    End Sub

    'Se produce cuando el mouse sale del control.
    Private Sub UserZoomImage_MouseLeave(sender As Object, e As System.EventArgs) Handles Me.MouseLeave
        IsZoom = False
    End Sub

    'Se produce cuando el mouse entra en el control.
    Private Sub UserZoomImage_MouseEnter(sender As Object, e As System.EventArgs) Handles Me.MouseEnter
        IsZoom = True
    End Sub

End Class
