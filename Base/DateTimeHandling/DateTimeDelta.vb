Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace DateTimeHandling

  Public Class DateTimeDelta

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert die Jahre des Zeit-Deltas oder legt diese fest.</summary>
    Public Property Years As Int32

    '''<summary>Liefert die Monate des Zeit-Deltas oder legt diese fest.</summary>
    Public Property Months As Int32

    '''<summary>Liefert die Tage des Zeit-Deltas oder legt diese fest.</summary>
    Public Property Days As Int32

    '''<summary>Liefert die Stunden des Zeit-Deltas oder legt diese fest.</summary>
    Public Property Hours As Int32

    '''<summary>Liefert die Minuten des Zeit-Deltas oder legt diese fest.</summary>
    Public Property Minutes As Int32

    '''<summary>Liefert die Sekunden des Zeit-Deltas oder legt diese fest.</summary>
    Public Property Seconds As Int32

    '''<summary>Liefert die Millisekunden des Zeit-Deltas oder legt diese fest.</summary>
    Public Property Milliseconds As Int32
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Liefert das DateTimeDelta-Objekt als TimeSpan-Objekt.</summary>
    Public Function ToTimeSpan() As TimeSpan

      Dim temp = DateTime.MinValue
      temp = temp.AddYears(Me.Years)
      temp = temp.AddMonths(Me.Months)
      temp = temp.AddDays(Me.Days)
      temp = temp.AddHours(Me.Hours)
      temp = temp.AddMinutes(Me.Minutes)
      temp.AddSeconds(Me.Seconds)
      temp = temp.AddMilliseconds(Me.Milliseconds)

      Dim result = temp.Subtract(DateTime.MinValue)
      Return result
    End Function

    '''<summary>
    '''Liefert das DateTimeDelta-Objekt als DateTime. Sollte die Umwandlung nicht möglich sein,
    '''dann wird MinValue von DateTime geliefert.
    '''</summary>
    Public Function ToDateTime() As DateTime

      Return If(Helper.DateTime.Checks.IsDateTime(Me), DateTime.Parse(Me.ToDateTimeString), DateTime.MinValue)
    End Function

    '''<summary>Liefert das  DateTimeDelta-Objekt als String im Format DD.MM.YYY hh:mm:ss.</summary>
    ''' <returns></returns>
    Public Function ToDateTimeString() As String
      Return $"{Me.Days}.{Me.Months}.{Me.Years.ToString("0000")} {Me.Hours}:{Me.Minutes}:{Me.Seconds}"
    End Function

    '''<summary>
    '''Wandelt das DateTimeDelta-Objekt als DateTime um und liefert das Ergebnis dessen ToString-Methode. 
    '''Sollte die Umwandlung nicht möglich sein, dann wird ToString von DateTime.MinValue geliefert.
    '''</summary>
    Public Overrides Function ToString() As String

      Return Me.ToString(String.Empty)
    End Function

    '''<summary>
    '''Wandelt das DateTimeDelta-Objekt als DateTime um und liefert das Ergebnis dessen ToString-Methode. 
    '''Sollte die Umwandlung nicht möglich sein, dann wird ToString von DateTime.MinValue geliefert.
    '''</summary>
    Public Overloads Function ToString(ByVal format As String) As String

      Dim result = If(String.IsNullOrEmpty(format), Me.ToDateTime.ToString, Me.ToDateTime.ToString(format))
      Return result
    End Function

#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
