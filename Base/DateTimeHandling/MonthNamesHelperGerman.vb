Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.DateTimeHandling.Enums
Imports SSP.Base.StringHandling
#End Region

Namespace DateTimeHandling

  Public Class MonthNamesHelperGerman

    Inherits MonthNamesHelperBase

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Overrides ReadOnly Property April As String
      Get
        Return MonthNamesGerman.April.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property AprilShort As String
      Get
        Return MonthNamesShortGerman.Apr.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property August As String
      Get
        Return MonthNamesGerman.August.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property AugustShort As String
      Get
        Return MonthNamesShortGerman.Aug.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property CultureCode As CultureCodes
      Get
        Return CultureCodes.de_DE
      End Get
    End Property

    Public Overrides ReadOnly Property December As String
      Get
        Return MonthNamesGerman.Dezember.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property DecemberShort As String
      Get
        Return MonthNamesShortGerman.Dez.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property February As String
      Get
        Return MonthNamesGerman.Februar.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property FebruaryShort As String
      Get
        Return MonthNamesShortGerman.Febr.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property January As String
      Get
        Return MonthNamesGerman.Januar.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property JanuaryShort As String
      Get
        Return MonthNamesShortGerman.Jan.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property July As String
      Get
        Return MonthNamesGerman.Juli.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property JulyShort As String
      Get
        Return MonthNamesShortGerman.Juli.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property June As String
      Get
        Return MonthNamesGerman.Juni.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property JuneShort As String
      Get
        Return MonthNamesShortGerman.Juni.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property March As String
      Get
        Return MonthNamesGerman.März.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property MarchShort As String
      Get
        Return MonthNamesShortGerman.März.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property May As String
      Get
        Return MonthNamesGerman.Mai.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property MayShort As String
      Get
        Return MonthNamesShortGerman.Mai.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property November As String
      Get
        Return MonthNamesGerman.November.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property NovemberShort As String
      Get
        Return MonthNamesShortGerman.Nov.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property October As String
      Get
        Return MonthNamesGerman.Oktober.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property OctoberShort As String
      Get
        Return MonthNamesShortGerman.Okt.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property September As String
      Get
        Return MonthNamesGerman.September.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property SeptemberShort As String
      Get
        Return MonthNamesShortGerman.Sept.ToString
      End Get
    End Property
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
