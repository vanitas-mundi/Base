Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace DateTimeHandling

  Public Class DateTimeChecks

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Friend Sub New()
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Prüft ob der Wert von s ein Datum/Uhrzeit-Wert ist.</summary>
    Public Function IsDateTime(ByVal value As String) As Boolean

      Dim result As DateTime
      Return DateTime.TryParse(value, result)
    End Function

    '''<summary>Prüft ob das DateTimeDelta-Objekt ein gültiger Datum/Uhrzeit-Wert ist.</summary>
    Public Function IsDateTime(ByVal value As DateTimeDelta) As Boolean

      Dim temp = value.ToDateTimeString
      Dim result As DateTime
      Return DateTime.TryParse(temp, result)
    End Function

    '''<summary>Prüft ob der Wert von s ein Datum ist.</summary>
    Public Function IsDate(ByVal value As String) As Boolean

      Dim result As Boolean
      Return Boolean.TryParse(value, result)
    End Function

    '''<summary>Prüft ob der Wert von s eine Uhrzeit ist.</summary>
    Public Function IsTime(ByVal value As String) As Boolean

      Dim result As DateTime
      Return DateTime.TryParse(value, result)

      Try
        Dim d = Convert.ToDateTime(value)
        Return ((d.Hour <> 0) OrElse (d.Minute <> 0) OrElse (d.Second <> 0) OrElse (d.Millisecond <> 0)) _
        AndAlso ((d.Year = 1) AndAlso (d.Month = 1) AndAlso (d.Day = 1))
      Catch ex As Exception
        Return (False)
      End Try
    End Function

    '''<summary>Prüft, ob das angegebene Datum auf ein Wochenende fällt.</summary>
    Public Function IsWeekEnd(ByVal value As DateTime) As Boolean

      Return (value.DayOfWeek = DayOfWeek.Saturday) OrElse (value.DayOfWeek = DayOfWeek.Sunday)
    End Function

    '''<summary>Prüft, ob das angegebene Datum auf einen Sonn- oder Feiertag fällt.</summary>
    Public Function IsSundayOrPublicHoliday(ByVal value As DateTime) As Boolean

      With Helper.DateTime.PublicHolidays.Logic.Holidays
        Return (value.DayOfWeek = DayOfWeek.Sunday) OrElse (.Any(Function(x) x.ValidDate = value))
      End With
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace