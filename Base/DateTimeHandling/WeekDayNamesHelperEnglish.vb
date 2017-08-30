Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.DateTimeHandling.Enums
Imports SSP.Base.StringHandling
#End Region

Namespace DateTimeHandling

  Public Class WeekDayNamesHelperEnglish

    Inherits WeekDayNamesHelperBase

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Overrides ReadOnly Property CultureCode As CultureCodes
      Get
        Return CultureCodes.en_US
      End Get
    End Property

    Public Overrides ReadOnly Property Friday As String
      Get
        Return WeekDayNamesEnglish.Friday.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property FridayShort As String
      Get
        Return WeekDayNamesShortEnglish.Fri.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property Monday As String
      Get
        Return WeekDayNamesEnglish.Monday.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property MondayShort As String
      Get
        Return WeekDayNamesShortEnglish.Mon.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property Saturday As String
      Get
        Return WeekDayNamesEnglish.Saturday.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property SaturdayShort As String
      Get
        Return WeekDayNamesShortEnglish.Sat.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property Sunday As String
      Get
        Return WeekDayNamesEnglish.Sunday.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property SundayShort As String
      Get
        Return WeekDayNamesShortEnglish.Sun.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property Thursday As String
      Get
        Return WeekDayNamesEnglish.Thursday.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property ThursdayShort As String
      Get
        Return WeekDayNamesShortEnglish.Thur.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property Tuesday As String
      Get
        Return WeekDayNamesEnglish.Tuesday.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property TuesdayShort As String
      Get
        Return WeekDayNamesShortEnglish.Tue.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property Wednesday As String
      Get
        Return WeekDayNamesEnglish.Wednesday.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property WednesdayShort As String
      Get
        Return WeekDayNamesShortEnglish.Wed.ToString
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
