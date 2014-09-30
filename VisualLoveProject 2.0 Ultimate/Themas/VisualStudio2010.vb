Imports System.Drawing
Imports System.Windows.Forms

Public Class VisualStudio2010
    Inherits ProfessionalColorTable

#Region "Bordes y botones"
    Public Overrides ReadOnly Property ButtonSelectedHighlight() As Color
        Get
            Return ButtonSelectedGradientMiddle
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonSelectedHighlightBorder() As Color
        Get
            Return ButtonSelectedBorder
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonPressedHighlight() As Color
        Get
            Return ButtonPressedGradientMiddle
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonPressedHighlightBorder() As Color
        Get
            Return ButtonPressedBorder
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonCheckedHighlight() As Color
        Get
            Return ButtonCheckedGradientMiddle
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonCheckedHighlightBorder() As Color
        Get
            Return ButtonSelectedBorder
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonPressedBorder() As Color
        Get
            Return ButtonSelectedBorder
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonSelectedBorder() As Color
        Get
            Return Color.FromArgb(255, 229, 195, 101)
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonCheckedGradientBegin() As Color
        Get
            Return Color.FromArgb(255, 255, 232, 166)
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonCheckedGradientMiddle() As Color
        Get
            Return Color.FromArgb(255, 255, 232, 166)
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonCheckedGradientEnd() As Color
        Get
            Return Color.FromArgb(255, 255, 252, 242)
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonSelectedGradientBegin() As Color
        Get
            Return Color.FromArgb(255, 255, 252, 242)
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonSelectedGradientMiddle() As Color
        Get
            Return Color.FromArgb(255, 255, 245, 217)
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonSelectedGradientEnd() As Color
        Get
            Return Color.FromArgb(255, 255, 236, 181)
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonPressedGradientBegin() As Color
        Get
            Return Color.FromArgb(255, 255, 232, 166)
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonPressedGradientMiddle() As Color
        Get
            Return Color.FromArgb(255, 255, 232, 166)
        End Get
    End Property
    Public Overrides ReadOnly Property ButtonPressedGradientEnd() As Color
        Get
            Return Color.FromArgb(255, 255, 232, 166)
        End Get
    End Property
#End Region

    Public Overrides ReadOnly Property GripDark() As Color
        Get
            Return Color.FromArgb(255, 126, 138, 154)
        End Get
    End Property
    Public Overrides ReadOnly Property GripLight() As Color
        Get
            Return Color.FromName("Black")
        End Get
    End Property

    ' Icon Background Color menu. ============================================
    Public Overrides ReadOnly Property ImageMarginGradientBegin() As Color
        Get
            Return Color.FromArgb(233, 236, 238) 'Color.FromArgb(255, 186, 196, 213)
        End Get
    End Property
    Public Overrides ReadOnly Property ImageMarginGradientMiddle() As Color
        Get
            Return Color.FromArgb(233, 236, 238) 'Color.FromArgb(255, 186, 196, 213)
        End Get
    End Property
    Public Overrides ReadOnly Property ImageMarginGradientEnd() As Color
        Get
            Return Color.FromArgb(233, 236, 238) 'Color.FromArgb(255, 186, 196, 213)
        End Get
    End Property
    ' =======================================================================

    Public Overrides ReadOnly Property MenuItemSelected() As Color 'Menu selection color
        Get
            Return Color.FromArgb(255, 255, 236, 181)
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemBorder() As Color 'Menu selection border color
        Get
            Return Color.FromArgb(255, 229, 195, 101)
        End Get
    End Property
    Public Overrides ReadOnly Property MenuBorder() As Color 'Menu
        Get
            Return Color.FromArgb(255, 105, 119, 135)
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemSelectedGradientBegin() As Color 'Menu
        Get
            Return Color.FromArgb(255, 254, 227, 148)
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemSelectedGradientEnd() As Color 'Menu
        Get
            Return Color.FromArgb(255, 254, 227, 148)
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemPressedGradientBegin() As Color 'Menu
        Get
            Return Color.FromArgb(255, 207, 211, 218)
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemPressedGradientMiddle() As Color 'Menu
        Get
            Return Color.FromArgb(255, 203, 210, 226)
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemPressedGradientEnd() As Color 'Menu
        Get
            Return Color.FromArgb(255, 203, 210, 226)
        End Get
    End Property
    Public Overrides ReadOnly Property SeparatorDark() As Color
        Get
            Return Color.FromArgb(255, 171, 180, 190)
        End Get
    End Property
    Public Overrides ReadOnly Property SeparatorLight() As Color
        Get
            Return Color.FromArgb(255, 117, 128, 145)
        End Get
    End Property
    Public Overrides ReadOnly Property ToolStripBorder() As Color
        Get
            Return Color.FromArgb(255, 99, 109, 126)
        End Get
    End Property
    Public Overrides ReadOnly Property ToolStripDropDownBackground() As Color 'Menu desplasable.
        Get
            Return Color.FromArgb(255, 203, 210, 226)
        End Get
    End Property
  
End Class
