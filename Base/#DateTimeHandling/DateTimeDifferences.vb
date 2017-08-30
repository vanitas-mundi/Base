Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace DateTimeHandling

  Public Class DateTimeDifferences

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
    Private Function TruncateAndConvertToInt32(ByVal value As Double) As Int32

      Return Convert.ToInt32(Math.Truncate(value))
    End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>
    '''Liefert das Delta zwischen zwei Daten als TimeSpan, das Ergebnis ist immer positiv.
    '''Bsp.: GetDateDelta(#01/01/2017#, #01/01/2016#) -> 366 TotalDays,
    '''GetDateDelta(#01/01/2017#, #01/01/2016#) -> 366 TotalDays 
    '''</summary>
    Public Function DateDelta(ByVal firstDate As DateTime, ByVal secondDate As DateTime) As TimeSpan

      Dim functions = New DateTimeFunctions
      Dim maxDate = functions.MaxDate(firstDate, secondDate)
      Dim minDate = functions.MinDate(firstDate, secondDate)

      Return maxDate.Subtract(minDate)
    End Function

    '''<summary>Liefert die Differenz der übergebenen Daten in Wochen.</summary>
    Public Function InWeeks(ByVal firstDate As DateTime, ByVal secondDate As DateTime) As Int32

      Return InDays(firstDate, secondDate) \ 7
    End Function

    '''<summary>Liefert die Differenz der übergebenen Daten in Tagen.</summary>
    Public Function InDays(ByVal firstDate As DateTime, ByVal secondDate As DateTime) As Int32

      Return TruncateAndConvertToInt32(DateDelta(firstDate, secondDate).TotalDays)
    End Function

    '''<summary>Liefert die Differenz der übergebenen Daten in Stunden.</summary>
    Public Function InHours(ByVal firstDate As DateTime, ByVal secondDate As DateTime) As Int32

      Return TruncateAndConvertToInt32(DateDelta(firstDate, secondDate).TotalHours)
    End Function

    '''<summary>Liefert die Differenz der übergebenen Daten in Minuten.</summary>
    Public Function InMinutes(ByVal firstDate As DateTime, ByVal secondDate As DateTime) As Int32

      Return TruncateAndConvertToInt32(DateDelta(firstDate, secondDate).TotalMinutes)
    End Function

    '''<summary>Liefert die Differenz der übergebenen Daten in Sekunden.</summary>
    Public Function InSeconds(ByVal firstDate As DateTime, ByVal secondDate As DateTime) As Int32

      Return TruncateAndConvertToInt32(DateDelta(firstDate, secondDate).TotalSeconds)
    End Function

    '''<summary>Liefert die Differenz der übergebenen Daten als DateTimeDelta-Objekt.</summary>
    Public Function GetDelta(ByVal firstDate As DateTime, ByVal secondDate As DateTime) As DateTimeDelta

      Dim maxDate = Helper.DateTime.Functions.MaxDate(firstDate, secondDate)
      Dim minDate = Helper.DateTime.Functions.MinDate(firstDate, secondDate)
      Dim temp = maxDate - minDate
      Dim delta = DateTime.MinValue + temp

      ' Bemerkung: MinValue ist 1.1.1, deshlab muss subtrahiert werden ...
      Dim result = New DateTimeDelta With
      {.Years = delta.Year - 1,
      .Months = delta.Month - 1,
      .Days = delta.Day - 1,
      .Hours = delta.Hour,
      .Minutes = delta.Minute,
      .Seconds = delta.Second
      }

      Return result
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace