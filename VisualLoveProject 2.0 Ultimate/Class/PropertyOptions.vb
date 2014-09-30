Imports System.Drawing.Drawing2D
Imports System.Drawing

Public Class PropertyOptions

    Public Function CreateRoundRectGraphicsPath2(r As Rectangle, Radius As Integer) As GraphicsPath
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

    Private Function CreateArrowGraphicsPath(r As Rectangle) As GraphicsPath
        Dim gp As New GraphicsPath()
        Dim halfX As Integer = r.Width / 2
        Dim halfY As Integer = r.Height / 2
        gp.AddLine(r.X, r.Y + halfY \ 2, r.X + halfX, r.Y + halfY \ 2)
        gp.AddLine(r.X + halfX, r.Y + halfY \ 2, r.X + halfX, r.Y)
        gp.AddLine(r.X + halfX, r.Y, r.Right, r.Y + halfY)
        gp.AddLine(r.Right, r.Y + halfY, r.X + halfX, r.Bottom)
        gp.AddLine(r.X + halfX, r.Bottom, r.X + halfX, r.Bottom - halfY \ 2)
        gp.AddLine(r.X + halfX, r.Bottom - halfY \ 2, r.X, r.Bottom - halfY \ 2)
        gp.AddLine(r.X, r.Bottom - halfY \ 2, r.X, r.Y + halfY \ 2)
        gp.CloseFigure()
        Return gp
    End Function

    Private Function CreateRoundRectGraphicsPath(r As Rectangle) As GraphicsPath
        Dim gp As New GraphicsPath()
        Dim radius As Integer = r.Width / 2
        gp.AddLine(r.X + radius, r.Y, r.Right - radius, r.Y)
        gp.AddArc(r.Right - radius, r.Y, radius, radius, 270, 90)

        gp.AddLine(r.Right, r.Y + radius, r.Right, r.Bottom - radius)
        gp.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90)

        gp.AddLine(r.Right - radius, r.Bottom, r.X + radius, r.Bottom)
        gp.AddArc(r.X, r.Bottom - radius, radius, radius, 90, 90)

        gp.AddLine(r.X, r.Bottom - radius, r.X, r.Y + radius)
        gp.AddArc(r.X, r.Y, radius, radius, 180, 90)

        gp.CloseFigure()
        Return gp
    End Function

    Public Sub DrawRoundRect(g As Graphics, p As Pen, r As Rectangle)
        Using gp As GraphicsPath = CreateRoundRectGraphicsPath2(r, 4)
            g.DrawPath(p, gp)
        End Using
    End Sub

    Public Sub FillRoundRect(g As Graphics, b As Brush, r As Rectangle)
        Using gp As GraphicsPath = CreateRoundRectGraphicsPath2(r, 4)
            g.FillPath(b, gp)
        End Using
    End Sub

End Class
