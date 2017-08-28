Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
Imports System.Text.RegularExpressions
#End Region

Namespace StringHandling

  Public NotInheritable Class StringFunctions

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    ''''<summary>
    ''''Ermittelt aus der Collection den ersten Index, welcher ab der Position index, rücklaufend den Wert False enthält.
    ''''</summary>
    'Private Function GetBeginOfLastDigitPosition(ByVal isDigitList As List(Of Boolean), ByVal index As Int32) As Int32

    '  If index < 0 Then Return 0 ' Collection enthält kein Element mit dem Wert false

    '  Return If(isDigitList(index), GetBeginOfLastDigitPosition(isDigitList, index - 1), index + 1)
    'End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Zerlegt den String in ein Array.</summary>
    Public Function Split(ByVal s As String, ByVal separator As String) As String()
      Return Regex.Split(s, separator)
    End Function

    ''''<summary>Zerlegt streetString in Straßenname und Hausnummer.</summary>
    'Public Function DivideIntoStreetAndHousenumber(ByVal streetString As String) As (StreetName As String, HouseNumber As String)

    '  Dim result = (StreetName:=String.Empty, HouseNumber:=String.Empty)

    '  ' Ziffern, Leerzeichen und Bindestriche in einer Collection mit dem Wert true speichern, andere Zeichen als false
    '  Dim isDigitList = streetString.ToList.Select(Function(x) Char.IsDigit(x) OrElse Char.IsWhiteSpace(x) OrElse x = "-"c).ToList

    '  ' Den Index des letzten Elementes mit dem Wert true ermitteln
    '  Dim lastDigitIndex = isDigitList.LastIndexOf(True)

    '  If lastDigitIndex >= 0 Then ' streetString enthält Ziffern und/oder Text
    '    Dim len = GetBeginOfLastDigitPosition(isDigitList, lastDigitIndex)
    '    result.StreetName = streetString.Substring(0, len).Trim
    '    result.HouseNumber = streetString.Substring(len).Trim
    '  Else ' streetString enthält keine Ziffern
    '    result.StreetName = streetString.Trim
    '    result.HouseNumber = String.Empty
    '  End If

    '  Return result
    'End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace