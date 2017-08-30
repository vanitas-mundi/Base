Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.DateTimeHandling.PublicHolidays.Interfaces
Imports SSP.Base.StringHandling
#End Region

Namespace DateTimeHandling.PublicHolidays

  Public NotInheritable Class PublicHolidaysLogicLuxembourg

    Inherits PublicHolidaysLogicBase

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
    End Sub
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Shared ReadOnly Property Instance() As New PublicHolidaysLogicLuxembourg

    Public Overrides ReadOnly Property CultureCode As CultureCodes = CultureCodes.de_LU
#End Region

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
    Protected Overrides Sub InitializePublicHolidays()

      Me.Holidays.Clear()

      With Me.Holidays
        AddFixedNotRegionalPublicDay(GetDateTime(1, 1), "Neujahr")
        AddFixedNotRegionalPublicDay(GetDateTime(5, 1), "Tag der Arbeit")
        AddFixedNotRegionalPublicDay(GetDateTime(6, 23), "Nationalfeiertag")
        AddFixedNotRegionalPublicDay(GetDateTime(8, 15), "Mariä Himmelfahrt")
        AddFixedNotRegionalPublicDay(GetDateTime(11, 1), "Allerheiligen")
        AddFixedNotRegionalPublicDay(GetDateTime(12, 25), "1. Weihnachtsfeiertag")
        AddFixedNotRegionalPublicDay(GetDateTime(12, 26), "2. Weihnachtsfeiertag (Stephanstag)")

        Dim easterSunday = GetEasterSunday()
        AddNotFixedNotRegionalPublicDay(easterSunday.AddDays(1), "Ostermontag")
        AddNotFixedNotRegionalPublicDay(easterSunday.AddDays(39), "Christi Himmelfahrt")
        AddNotFixedNotRegionalPublicDay(easterSunday.AddDays(50), "Pfingstmontag")
      End With
    End Sub
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region

  End Class

End Namespace
