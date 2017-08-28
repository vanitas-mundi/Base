Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
Imports System.Text.RegularExpressions
#End Region

Namespace StringHandling

  Public NotInheritable Class StringReplace

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
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Maskiert einen String für eine MySQL-Abfrage.</summary>
    Public Function EscapeMySql(ByVal s As String) As String

      Dim sb = New StringBuilder(s)
      Return sb.Replace("\", "\\").Replace("'", "\'").Replace("""", "\""").ToString
    End Function

    '''<summary>Maskiert einen String für eine MsSQL-Abfrage.</summary>
    Public Function EscapeMsSql(ByVal s As String) As String

      Dim sb = New StringBuilder(s)
      Return sb.Replace("\", "\\").Replace("'", "''").ToString
    End Function

    '''<summary>Maskiert einen String für eine AD-Abfrage.</summary>
    Public Function EscapeAD(ByVal s As String) As String

      'Throw New NotImplementedException
      'Hier müssen noch die zu maskierenden Zeichen ermitelt werden
      'für das erste wird einfach der übergebene Parameter s zurückgegeben!
      'Dim sb = New StringBuilder(s)
      'Return sb.Replace("\", "\\").Replace("'", "\'").Replace("""", "\""").ToString
      Return s
    End Function

    '''<summary>Wandelt im String sourceString Kommata in Punkte um und liefert diesen zurück.</summary>
    Public Function CommaToPoint(ByVal sourceString As String) As String

      Return sourceString.Replace(",", ".")
    End Function

    '''<summary>Wandelt im String sourceString Punkte in Kommata um und liefert diesen zurück.</summary>
    Public Function PointToComma(ByVal sourceString As String) As String

      Return sourceString.Replace(".", ",")
    End Function

    '''<summary>
    '''Entfernt aus der Zeichenkette sourceString mehrere aufeinanderfolgende Zeichen value 
    '''und gibt das Ergebnis zurück.
    '''Bsp.: ReplaceDuplicateChars("Das___ist_ein__Beispiel","_"c) -> Das_ist_ein_Beispiel
    '''</summary>
    Public Function DuplicateChars(ByVal sourceString As String, ByVal value As Char) As String

      Dim pattern = String.Concat(value, value)
      While sourceString.IndexOf(pattern) > -1
        sourceString = sourceString.Replace(pattern, value)
      End While

      Return sourceString
    End Function

    '''<summary>
    '''Ersetzt in der Zeichenfolge sourceString Whitespace durch das Zeichen value und liefert diese zurück.  
    '''</summary>
    Public Function WhiteSpace(ByVal sourceString As String, ByVal value As Char) As String
      Dim result = New StringBuilder
      sourceString.ToList.ForEach(Sub(x) result.Append(If(Char.IsWhiteSpace(x), value, x)))
      Return DuplicateChars(result.ToString, value)
    End Function

    '''<summary>
    '''Ersetzt deutsche Umlaute und ß in der Zeichenfolge sourceString (durch ae usw.)
    '''und liefert diese zurück.
    ''' </summary>
    Public Function GermanChars(ByVal sourceString As String) As String

      Dim result = New StringBuilder
      For Each c In sourceString.ToList
        Select Case c
          Case "ä"c
            result.Append("ae")
          Case "Ä"c
            result.Append("Ae")
          Case "ö"c
            result.Append("oe")
          Case "Ö"c
            result.Append("Oe")
          Case "ü"c
            result.Append("ue")
          Case "Ü"c
            result.Append("Ue")
          Case "ß"c
            result.Append("ss")
          Case Else
            result.Append(c)
        End Select
      Next c

      Return result.ToString
    End Function

    '''<summary>
    '''Ersetzt oldString durch newString im sourceString und liefert die ersetzte Zeichenfolge zurück.
    '''Groß-/Kleinschreibung wird nicht berücksichtigung.
    '''</summary>
    Public Function Replace(ByVal sourceString As String, ByVal oldString As String, ByVal newString As String) As String

      Dim regex = New Regex(oldString, RegexOptions.IgnoreCase)
      Return regex.Replace(sourceString, newString)
    End Function

#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace