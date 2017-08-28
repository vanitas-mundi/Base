Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Colors

  Public NotInheritable Class NamedColors

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Private Shared _instance As NamedColors
    Private _items As New Dictionary(Of NamedColorsEnum, NamedColor)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
      Initialize()
    End Sub

    Shared Sub New()
      _instance = New NamedColors
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Shared ReadOnly Property Instance As NamedColors
      Get
        Return _instance
      End Get
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Sub Initialize()
      _items.Add(NamedColorsEnum.AliceBlue, New NamedColor(NamedColorsEnum.AliceBlue, 240, 248, 255))
      _items.Add(NamedColorsEnum.AntiqueWhite, New NamedColor(NamedColorsEnum.AntiqueWhite, 250, 235, 215))
      _items.Add(NamedColorsEnum.Aqua, New NamedColor(NamedColorsEnum.Aqua, 0, 255, 255))
      _items.Add(NamedColorsEnum.AquaMarine, New NamedColor(NamedColorsEnum.AquaMarine, 127, 255, 212))
      _items.Add(NamedColorsEnum.Azure, New NamedColor(NamedColorsEnum.Azure, 240, 255, 255))
      _items.Add(NamedColorsEnum.Beige, New NamedColor(NamedColorsEnum.Beige, 245, 245, 220))
      _items.Add(NamedColorsEnum.Bisque, New NamedColor(NamedColorsEnum.Bisque, 255, 228, 196))
      _items.Add(NamedColorsEnum.Black, New NamedColor(NamedColorsEnum.Black, 0, 0, 0))
      _items.Add(NamedColorsEnum.BlanchedAlmond, New NamedColor(NamedColorsEnum.BlanchedAlmond, 255, 235, 205))
      _items.Add(NamedColorsEnum.Blue, New NamedColor(NamedColorsEnum.Blue, 0, 0, 255))
      _items.Add(NamedColorsEnum.BlueViolet, New NamedColor(NamedColorsEnum.BlueViolet, 138, 43, 226))
      _items.Add(NamedColorsEnum.BurlyWood, New NamedColor(NamedColorsEnum.BurlyWood, 222, 184, 135))
      _items.Add(NamedColorsEnum.CadetBlue, New NamedColor(NamedColorsEnum.CadetBlue, 95, 158, 160))
      _items.Add(NamedColorsEnum.Chartreuse, New NamedColor(NamedColorsEnum.Chartreuse, 127, 255, 0))
      _items.Add(NamedColorsEnum.Chocolate, New NamedColor(NamedColorsEnum.Chocolate, 210, 105, 30))
      _items.Add(NamedColorsEnum.Coral, New NamedColor(NamedColorsEnum.Coral, 255, 127, 80))
      _items.Add(NamedColorsEnum.CornflowerBlue, New NamedColor(NamedColorsEnum.CornflowerBlue, 100, 149, 237))
      _items.Add(NamedColorsEnum.Cornsilk, New NamedColor(NamedColorsEnum.Cornsilk, 255, 248, 220))
      _items.Add(NamedColorsEnum.Crimson, New NamedColor(NamedColorsEnum.Crimson, 220, 20, 60))
      _items.Add(NamedColorsEnum.Cyan, New NamedColor(NamedColorsEnum.Cyan, 0, 255, 255))
      _items.Add(NamedColorsEnum.DarkBlue, New NamedColor(NamedColorsEnum.DarkBlue, 0, 0, 139))
      _items.Add(NamedColorsEnum.DarkCyan, New NamedColor(NamedColorsEnum.DarkCyan, 0, 139, 139))
      _items.Add(NamedColorsEnum.DarkGoldenRod, New NamedColor(NamedColorsEnum.DarkGoldenRod, 184, 134, 11))
      _items.Add(NamedColorsEnum.DarkGray, New NamedColor(NamedColorsEnum.DarkGray, 169, 169, 169))
      _items.Add(NamedColorsEnum.DarkGreen, New NamedColor(NamedColorsEnum.DarkGreen, 0, 100, 0))
      _items.Add(NamedColorsEnum.DarkKhaki, New NamedColor(NamedColorsEnum.DarkKhaki, 189, 183, 107))
      _items.Add(NamedColorsEnum.DarkMagenta, New NamedColor(NamedColorsEnum.DarkMagenta, 139, 0, 139))
      _items.Add(NamedColorsEnum.DarkOliveGreen, New NamedColor(NamedColorsEnum.DarkOliveGreen, 85, 107, 47))
      _items.Add(NamedColorsEnum.DarkOrange, New NamedColor(NamedColorsEnum.DarkOrange, 255, 140, 0))
      _items.Add(NamedColorsEnum.DarkOrchid, New NamedColor(NamedColorsEnum.DarkOrchid, 153, 50, 204))
      _items.Add(NamedColorsEnum.DarkRed, New NamedColor(NamedColorsEnum.DarkRed, 139, 0, 0))
      _items.Add(NamedColorsEnum.DarkSalmon, New NamedColor(NamedColorsEnum.DarkSalmon, 233, 150, 122))
      _items.Add(NamedColorsEnum.DarkSeaGreen, New NamedColor(NamedColorsEnum.DarkSeaGreen, 143, 188, 139))
      _items.Add(NamedColorsEnum.DarkSlateBlue, New NamedColor(NamedColorsEnum.DarkSlateBlue, 72, 61, 139))
      _items.Add(NamedColorsEnum.DarkSlateGray, New NamedColor(NamedColorsEnum.DarkSlateGray, 47, 79, 79))
      _items.Add(NamedColorsEnum.DeepPink, New NamedColor(NamedColorsEnum.DeepPink, 255, 20, 147))
      _items.Add(NamedColorsEnum.DarkTurquoise, New NamedColor(NamedColorsEnum.DarkTurquoise, 0, 206, 209))
      _items.Add(NamedColorsEnum.DarkViolet, New NamedColor(NamedColorsEnum.DarkViolet, 148, 0, 211))
      _items.Add(NamedColorsEnum.DeepSkyBlue, New NamedColor(NamedColorsEnum.DeepSkyBlue, 0, 191, 255))
      _items.Add(NamedColorsEnum.DimGray, New NamedColor(NamedColorsEnum.DimGray, 105, 105, 105))
      _items.Add(NamedColorsEnum.DodgerBlue, New NamedColor(NamedColorsEnum.DodgerBlue, 30, 144, 255))
      _items.Add(NamedColorsEnum.FireBrick, New NamedColor(NamedColorsEnum.FireBrick, 178, 34, 34))
      _items.Add(NamedColorsEnum.FloralWhite, New NamedColor(NamedColorsEnum.FloralWhite, 255, 250, 240))
      _items.Add(NamedColorsEnum.ForestGreen, New NamedColor(NamedColorsEnum.ForestGreen, 34, 139, 34))
      _items.Add(NamedColorsEnum.Fuchsia, New NamedColor(NamedColorsEnum.Fuchsia, 255, 0, 255))
      _items.Add(NamedColorsEnum.Gainsboro, New NamedColor(NamedColorsEnum.Gainsboro, 220, 220, 220))
      _items.Add(NamedColorsEnum.GhostWhite, New NamedColor(NamedColorsEnum.GhostWhite, 248, 248, 255))
      _items.Add(NamedColorsEnum.Gold, New NamedColor(NamedColorsEnum.Gold, 255, 215, 0))
      _items.Add(NamedColorsEnum.Goldenrod, New NamedColor(NamedColorsEnum.Goldenrod, 218, 165, 32))
      _items.Add(NamedColorsEnum.Gray, New NamedColor(NamedColorsEnum.Gray, 128, 128, 128))
      _items.Add(NamedColorsEnum.Green, New NamedColor(NamedColorsEnum.Green, 0, 128, 0))
      _items.Add(NamedColorsEnum.GreenYellow, New NamedColor(NamedColorsEnum.GreenYellow, 173, 255, 47))
      _items.Add(NamedColorsEnum.HoneyDew, New NamedColor(NamedColorsEnum.HoneyDew, 240, 255, 240))
      _items.Add(NamedColorsEnum.HotPink, New NamedColor(NamedColorsEnum.HotPink, 255, 105, 180))
      _items.Add(NamedColorsEnum.IndianRed, New NamedColor(NamedColorsEnum.IndianRed, 205, 92, 92))
      _items.Add(NamedColorsEnum.Indigo, New NamedColor(NamedColorsEnum.Indigo, 75, 0, 130))
      _items.Add(NamedColorsEnum.Ivory, New NamedColor(NamedColorsEnum.Ivory, 255, 255, 240))
      _items.Add(NamedColorsEnum.Khaki, New NamedColor(NamedColorsEnum.Khaki, 240, 230, 140))
      _items.Add(NamedColorsEnum.Lavender, New NamedColor(NamedColorsEnum.Lavender, 230, 230, 250))
      _items.Add(NamedColorsEnum.LavenderBlush, New NamedColor(NamedColorsEnum.LavenderBlush, 255, 240, 245))
      _items.Add(NamedColorsEnum.LawnGreen, New NamedColor(NamedColorsEnum.LawnGreen, 124, 252, 0))
      _items.Add(NamedColorsEnum.LemonChiffon, New NamedColor(NamedColorsEnum.LemonChiffon, 255, 250, 205))
      _items.Add(NamedColorsEnum.LightBlue, New NamedColor(NamedColorsEnum.LightBlue, 173, 216, 230))
      _items.Add(NamedColorsEnum.LightCoral, New NamedColor(NamedColorsEnum.LightCoral, 240, 128, 128))
      _items.Add(NamedColorsEnum.LightCyan, New NamedColor(NamedColorsEnum.LightCyan, 224, 255, 255))
      _items.Add(NamedColorsEnum.LightGoldenrodYellow, New NamedColor(NamedColorsEnum.LightGoldenrodYellow, 250, 250, 210))
      _items.Add(NamedColorsEnum.LightGray, New NamedColor(NamedColorsEnum.LightGray, 211, 211, 211))
      _items.Add(NamedColorsEnum.LightGreen, New NamedColor(NamedColorsEnum.LightGreen, 144, 238, 144))
      _items.Add(NamedColorsEnum.LightPink, New NamedColor(NamedColorsEnum.LightPink, 255, 182, 193))
      _items.Add(NamedColorsEnum.LightSalmon, New NamedColor(NamedColorsEnum.LightSalmon, 255, 160, 122))
      _items.Add(NamedColorsEnum.LightSeaGreen, New NamedColor(NamedColorsEnum.LightSeaGreen, 32, 178, 170))
      _items.Add(NamedColorsEnum.LightSkyBlue, New NamedColor(NamedColorsEnum.LightSkyBlue, 135, 206, 250))
      _items.Add(NamedColorsEnum.LightSlateGray, New NamedColor(NamedColorsEnum.LightSlateGray, 119, 136, 153))
      _items.Add(NamedColorsEnum.LightSteelBlue, New NamedColor(NamedColorsEnum.LightSteelBlue, 176, 196, 222))
      _items.Add(NamedColorsEnum.LightYellow, New NamedColor(NamedColorsEnum.LightYellow, 255, 255, 224))
      _items.Add(NamedColorsEnum.Lime, New NamedColor(NamedColorsEnum.Lime, 0, 255, 0))
      _items.Add(NamedColorsEnum.LimeGreen, New NamedColor(NamedColorsEnum.LimeGreen, 50, 205, 50))
      _items.Add(NamedColorsEnum.Linen, New NamedColor(NamedColorsEnum.Linen, 250, 240, 230))
      _items.Add(NamedColorsEnum.Magenta, New NamedColor(NamedColorsEnum.Magenta, 255, 0, 255))
      _items.Add(NamedColorsEnum.Maroon, New NamedColor(NamedColorsEnum.Maroon, 128, 0, 0))
      _items.Add(NamedColorsEnum.MediumAquamarine, New NamedColor(NamedColorsEnum.MediumAquamarine, 102, 205, 170))
      _items.Add(NamedColorsEnum.MediumBlue, New NamedColor(NamedColorsEnum.MediumBlue, 0, 0, 205))
      _items.Add(NamedColorsEnum.MediumOrchid, New NamedColor(NamedColorsEnum.MediumOrchid, 186, 85, 211))
      _items.Add(NamedColorsEnum.MediumPurple, New NamedColor(NamedColorsEnum.MediumPurple, 147, 112, 219))
      _items.Add(NamedColorsEnum.MediumSeaGreen, New NamedColor(NamedColorsEnum.MediumSeaGreen, 60, 179, 113))
      _items.Add(NamedColorsEnum.MediumSpringGreen, New NamedColor(NamedColorsEnum.MediumSpringGreen, 0, 250, 154))
      _items.Add(NamedColorsEnum.MediumSlateBlue, New NamedColor(NamedColorsEnum.MediumSlateBlue, 123, 104, 238))
      _items.Add(NamedColorsEnum.MediumTurquoise, New NamedColor(NamedColorsEnum.MediumTurquoise, 72, 209, 204))
      _items.Add(NamedColorsEnum.MediumVioletRed, New NamedColor(NamedColorsEnum.MediumVioletRed, 199, 21, 133))
      _items.Add(NamedColorsEnum.MidnightBlue, New NamedColor(NamedColorsEnum.MidnightBlue, 25, 25, 112))
      _items.Add(NamedColorsEnum.MintCream, New NamedColor(NamedColorsEnum.MintCream, 245, 255, 250))
      _items.Add(NamedColorsEnum.MistyRose, New NamedColor(NamedColorsEnum.MistyRose, 255, 228, 225))
      _items.Add(NamedColorsEnum.Moccasin, New NamedColor(NamedColorsEnum.Moccasin, 255, 228, 181))
      _items.Add(NamedColorsEnum.NavajoWhite, New NamedColor(NamedColorsEnum.NavajoWhite, 255, 222, 173))
      _items.Add(NamedColorsEnum.Navy, New NamedColor(NamedColorsEnum.Navy, 0, 0, 128))
      _items.Add(NamedColorsEnum.OldLace, New NamedColor(NamedColorsEnum.OldLace, 253, 245, 230))
      _items.Add(NamedColorsEnum.Olive, New NamedColor(NamedColorsEnum.Olive, 128, 128, 0))
      _items.Add(NamedColorsEnum.OliveDrab, New NamedColor(NamedColorsEnum.OliveDrab, 107, 142, 35))
      _items.Add(NamedColorsEnum.Orange, New NamedColor(NamedColorsEnum.Orange, 255, 165, 0))
      _items.Add(NamedColorsEnum.OrangeRed, New NamedColor(NamedColorsEnum.OrangeRed, 255, 69, 0))
      _items.Add(NamedColorsEnum.Orchid, New NamedColor(NamedColorsEnum.Orchid, 218, 112, 214))
      _items.Add(NamedColorsEnum.PaleGoldenRod, New NamedColor(NamedColorsEnum.PaleGoldenRod, 238, 232, 170))
      _items.Add(NamedColorsEnum.PaleGreen, New NamedColor(NamedColorsEnum.PaleGreen, 152, 251, 152))
      _items.Add(NamedColorsEnum.PaleTurquoise, New NamedColor(NamedColorsEnum.PaleTurquoise, 175, 238, 238))
      _items.Add(NamedColorsEnum.PaleVioletRed, New NamedColor(NamedColorsEnum.PaleVioletRed, 219, 112, 147))
      _items.Add(NamedColorsEnum.PapayaWhip, New NamedColor(NamedColorsEnum.PapayaWhip, 255, 239, 213))
      _items.Add(NamedColorsEnum.PeachPuff, New NamedColor(NamedColorsEnum.PeachPuff, 255, 218, 185))
      _items.Add(NamedColorsEnum.Peru, New NamedColor(NamedColorsEnum.Peru, 205, 133, 63))
      _items.Add(NamedColorsEnum.Pink, New NamedColor(NamedColorsEnum.Pink, 255, 192, 203))
      _items.Add(NamedColorsEnum.Plum, New NamedColor(NamedColorsEnum.Plum, 221, 160, 221))
      _items.Add(NamedColorsEnum.PowderBlue, New NamedColor(NamedColorsEnum.PowderBlue, 176, 224, 230))
      _items.Add(NamedColorsEnum.Purple, New NamedColor(NamedColorsEnum.Purple, 128, 0, 128))
      _items.Add(NamedColorsEnum.Red, New NamedColor(NamedColorsEnum.Red, 255, 0, 0))
      _items.Add(NamedColorsEnum.RosyBrown, New NamedColor(NamedColorsEnum.RosyBrown, 188, 143, 143))
      _items.Add(NamedColorsEnum.RoyalBlue, New NamedColor(NamedColorsEnum.RoyalBlue, 65, 105, 225))
      _items.Add(NamedColorsEnum.SaddleBrown, New NamedColor(NamedColorsEnum.SaddleBrown, 139, 69, 19))
      _items.Add(NamedColorsEnum.Salmon, New NamedColor(NamedColorsEnum.Salmon, 250, 128, 114))
      _items.Add(NamedColorsEnum.SandyBrown, New NamedColor(NamedColorsEnum.SandyBrown, 244, 164, 96))
      _items.Add(NamedColorsEnum.SeaGreen, New NamedColor(NamedColorsEnum.SeaGreen, 46, 139, 87))
      _items.Add(NamedColorsEnum.SeaShell, New NamedColor(NamedColorsEnum.SeaShell, 255, 245, 238))
      _items.Add(NamedColorsEnum.Sienna, New NamedColor(NamedColorsEnum.Sienna, 160, 82, 45))
      _items.Add(NamedColorsEnum.Silver, New NamedColor(NamedColorsEnum.Silver, 192, 192, 192))
      _items.Add(NamedColorsEnum.SkyBlue, New NamedColor(NamedColorsEnum.SkyBlue, 135, 206, 235))
      _items.Add(NamedColorsEnum.SlateBlue, New NamedColor(NamedColorsEnum.SlateBlue, 106, 90, 205))
      _items.Add(NamedColorsEnum.SlateGray, New NamedColor(NamedColorsEnum.SlateGray, 112, 128, 144))
      _items.Add(NamedColorsEnum.Snow, New NamedColor(NamedColorsEnum.Snow, 255, 250, 250))
      _items.Add(NamedColorsEnum.SpringGreen, New NamedColor(NamedColorsEnum.SpringGreen, 0, 255, 127))
      _items.Add(NamedColorsEnum.SteelBlue, New NamedColor(NamedColorsEnum.SteelBlue, 70, 130, 180))
      _items.Add(NamedColorsEnum.Tan, New NamedColor(NamedColorsEnum.Tan, 210, 180, 140))
      _items.Add(NamedColorsEnum.Teal, New NamedColor(NamedColorsEnum.Teal, 0, 128, 128))
      _items.Add(NamedColorsEnum.Thistle, New NamedColor(NamedColorsEnum.Thistle, 216, 191, 216))
      _items.Add(NamedColorsEnum.Tomato, New NamedColor(NamedColorsEnum.Tomato, 255, 99, 71))
      _items.Add(NamedColorsEnum.Turquoise, New NamedColor(NamedColorsEnum.Turquoise, 64, 224, 208))
      _items.Add(NamedColorsEnum.Violet, New NamedColor(NamedColorsEnum.Violet, 238, 130, 238))
      _items.Add(NamedColorsEnum.Wheat, New NamedColor(NamedColorsEnum.Wheat, 245, 222, 179))
      _items.Add(NamedColorsEnum.White, New NamedColor(NamedColorsEnum.White, 255, 255, 255))
      _items.Add(NamedColorsEnum.WhiteSmoke, New NamedColor(NamedColorsEnum.WhiteSmoke, 245, 245, 245))
      _items.Add(NamedColorsEnum.Yellow, New NamedColor(NamedColorsEnum.Yellow, 255, 255, 0))
      _items.Add(NamedColorsEnum.YellowGreen, New NamedColor(NamedColorsEnum.YellowGreen, 154, 205, 50))
      _items.Add(NamedColorsEnum.FOM_Green, New NamedColor(NamedColorsEnum.FOM_Green, 28, 153, 138))
      _items.Add(NamedColorsEnum.eufomRed, New NamedColor(NamedColorsEnum.eufomRed, 160, 19, 27))
      _items.Add(NamedColorsEnum.GoBS_Blue, New NamedColor(NamedColorsEnum.GoBS_Blue, 0, 86, 132))
      _items.Add(NamedColorsEnum.VWA_Blue, New NamedColor(NamedColorsEnum.VWA_Blue, 0, 76, 132))
      _items.Add(NamedColorsEnum.BA_Blue, New NamedColor(NamedColorsEnum.BA_Blue, 0, 80, 150))
      _items.Add(NamedColorsEnum.BCW_Orange, New NamedColor(NamedColorsEnum.BCW_Orange, 234, 99, 16))
      _items.Add(NamedColorsEnum.BCW_Group_Blue, New NamedColor(NamedColorsEnum.BCW_Group_Blue, 43, 36, 91))
      _items.Add(NamedColorsEnum.BCW_Group_Gray, New NamedColor(NamedColorsEnum.BCW_Group_Gray, 113, 125, 135))
      _items.Add(NamedColorsEnum.BCW_Group_Gray70, New NamedColor(NamedColorsEnum.BCW_Group_Gray70, 155, 163, 170))
      _items.Add(NamedColorsEnum.BCW_Group_Gray40, New NamedColor(NamedColorsEnum.BCW_Group_Gray40, 198, 203, 207))
      _items.Add(NamedColorsEnum.BCW_Group_Gray25, New NamedColor(NamedColorsEnum.BCW_Group_Gray25, 219, 222, 225))
    End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Function Item(ByVal namedColor As NamedColorsEnum) As NamedColor
      Return _items.Item(namedColor)
    End Function

    Public Function Item(ByVal namedColor As String) As NamedColor
      Dim key = CType(System.Enum.Parse(GetType(NamedColorsEnum), namedColor), NamedColorsEnum)
      Return Item(key)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
