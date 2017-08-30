Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Globalization
#End Region

Namespace DateTimeHandling

  Public Class DateTimeFunctions

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
    '''<summary>
    '''Liefert von beiden übergebenen Daten das ältere.
    '''Bsp.: MinDate(#01/01/2017#, #01/01/2016#) -> #01/01/2016#
    '''</summary>
    Public Function MinDate(ByVal firstValidDate As DateTime, ByVal secondValidDate As DateTime) As DateTime

      Return If(firstValidDate < secondValidDate, firstValidDate, secondValidDate)
    End Function

    '''<summary>
    '''Liefert von beiden übergebenen Daten das jüngere.
    '''Bsp.: MaxDate(#01/01/2017#, #01/01/2016#) -> #01/01/2017#
    '''</summary>
    Public Function MaxDate(ByVal firstValidDate As DateTime, ByVal secondValidDate As DateTime) As DateTime

      Return If(firstValidDate > secondValidDate, firstValidDate, secondValidDate)
    End Function

    '''<summary>Ermittelt die Kalenderwoche anhand der eingestellten Systemkultur.</summary>
    Public Function WeekOfYearFromCurrentCulture(ByVal validDate As DateTime) As String
      'Wird an vielen Stellen benötigt
      Dim cultureInfo = My.Application.Culture
      Dim calendarWeekRule = cultureInfo.DateTimeFormat.CalendarWeekRule
      Dim firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek

      Return (New GregorianCalendar).GetWeekOfYear(validDate, calendarWeekRule, firstDayOfWeek).ToString
    End Function

    '''<summary>Liefert das Alter anhand des Geburtsdatums birthDay zum heutigen Tage (Systemdatum).</summary>
    Public Function GetAge(ByVal birthDay As DateTime) As Int32

      Return GetAge(DateTime.Now, birthDay)
    End Function

    '''<summary>Liefert das Alter anhand des Geburtsdatums birthDay zum Betrachtungsjahr contemplationYear.</summary>
    Public Function GetAge(ByVal contemplationYear As DateTime, ByVal birthDay As DateTime) As Int32

      Dim differences = New DateTimeDifferences
      Dim result = differences.GetDelta(contemplationYear, birthDay).Years

      Return result
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace