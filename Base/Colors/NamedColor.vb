Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Colors

  Public Class NamedColor

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal rgbArray As Byte())
      Me.New(NamedColorsEnum.Custom, rgbArray(0), rgbArray(1), rgbArray(2))
    End Sub

    Public Sub New(ByVal red As Byte, ByVal green As Byte, ByVal blue As Byte)
      Me.New(NamedColorsEnum.Custom, red, green, blue)
    End Sub

    Friend Sub New(ByVal namedColor As NamedColorsEnum _
    , ByVal red As Byte, ByVal green As Byte, ByVal blue As Byte)
      Me.NamedColor = namedColor
      Me.Red = red
      Me.Green = green
      Me.Blue = blue
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Readonly Property NamedColor As NamedColorsEnum
    Public Readonly Property Red As Byte
    Public Readonly Property Green As Byte
    Public Readonly Property Blue As Byte
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Overrides Function ToString() As String
      Return Me.NamedColor.ToString
    End Function

    Public Function ToStringRGB() As String
      Return ($"{Me.Red}, {Me.Green}, {Me.Blue}")
    End Function

    Public Function ToStringHex() As String
      Return ($"#{Me.Red.ToString("X")}{Me.Green.ToString("X")}{Me.Blue.ToString("X")}")
    End Function

    Public Function ToArrayRGB() As Byte()
      Return New Byte() {Me.Red, Me.Green, Me.Blue}
    End Function

#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
