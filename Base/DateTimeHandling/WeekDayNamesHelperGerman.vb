Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.DateTimeHandling.Enums
Imports SSP.Base.StringHandling
#End Region

Namespace DateTimeHandling

  Public Class WeekDayNamesHelperGerman

    Inherits WeekDayNamesHelperBase

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Overrides ReadOnly Property CultureCode As CultureCodes
      Get
        Return CultureCodes.de_DE
      End Get
    End Property

    Public Overrides ReadOnly Property Friday As String
      Get
        Return WeekDayNamesGerman.Freitag.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property FridayShort As String
      Get
        Return WeekDayNamesShortGerman.Fr.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property Monday As String
      Get
        Return WeekDayNamesGerman.Montag.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property MondayShort As String
      Get
        Return WeekDayNamesShortGerman.Mo.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property Saturday As String
      Get
        Return WeekDayNamesGerman.Samstag.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property SaturdayShort As String
      Get
        Return WeekDayNamesShortGerman.Sa.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property Sunday As String
      Get
        Return WeekDayNamesGerman.Sonntag.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property SundayShort As String
      Get
        Return WeekDayNamesShortGerman.So.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property Thursday As String
      Get
        Return WeekDayNamesGerman.Donnerstag.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property ThursdayShort As String
      Get
        Return WeekDayNamesShortGerman.Do.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property Tuesday As String
      Get
        Return WeekDayNamesGerman.Dienstag.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property TuesdayShort As String
      Get
        Return WeekDayNamesShortGerman.Di.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property Wednesday As String
      Get
        Return WeekDayNamesGerman.Mittwoch.ToString
      End Get
    End Property

    Public Overrides ReadOnly Property WednesdayShort As String
      Get
        Return WeekDayNamesShortGerman.Mi.ToString
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
