Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.DateTimeHandling.Enums
Imports SSP.Base.StringHandling
#End Region

Namespace DateTimeHandling

  Public Class MonthNamesHelperEnglish

    Inherits MonthNamesHelperBase

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Overrides ReadOnly Property April As String
      Get
        Return MonthNamesEnglish.April.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property AprilShort As String
      Get
        Return MonthNamesShortEnglish.Apr.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property August As String
      Get
        Return MonthNamesEnglish.August.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property AugustShort As String
      Get
        Return MonthNamesShortEnglish.Aug.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property CultureCode As CultureCodes
      Get
        Return CultureCodes.en_US
      End Get
    End Property

    Public Overrides ReadOnly Property December As String
      Get
        Return MonthNamesEnglish.December.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property DecemberShort As String
      Get
        Return MonthNamesShortEnglish.Dec.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property February As String
      Get
        Return MonthNamesEnglish.February.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property FebruaryShort As String
      Get
        Return MonthNamesShortEnglish.Feb.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property January As String
      Get
        Return MonthNamesEnglish.January.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property JanuaryShort As String
      Get
        Return MonthNamesShortEnglish.Jan.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property July As String
      Get
        Return MonthNamesEnglish.July.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property JulyShort As String
      Get
        Return MonthNamesShortEnglish.July.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property June As String
      Get
        Return MonthNamesEnglish.June.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property JuneShort As String
      Get
        Return MonthNamesShortEnglish.June.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property March As String
      Get
        Return MonthNamesEnglish.March.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property MarchShort As String
      Get
        Return MonthNamesShortEnglish.Mar.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property May As String
      Get
        Return MonthNamesEnglish.May.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property MayShort As String
      Get
        Return MonthNamesShortEnglish.May.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property November As String
      Get
        Return MonthNamesEnglish.November.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property NovemberShort As String
      Get
        Return MonthNamesShortEnglish.Nov.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property October As String
      Get
        Return MonthNamesEnglish.October.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property OctoberShort As String
      Get
        Return MonthNamesShortEnglish.Oct.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property September As String
      Get
        Return MonthNamesEnglish.September.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property SeptemberShort As String
      Get
        Return MonthNamesShortEnglish.Sept.ToString
      End Get
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
