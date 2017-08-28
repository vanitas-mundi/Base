Option Explicit On
Option Infer On
Option Strict On
Imports System.Text.RegularExpressions

#Region " --------------->> Imports/ usings "
#End Region

Namespace StringHandling

  Public Class StringTextCompare

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
    '''<summary>Liefert bei Gleichheit beider Stirngs true ansonsten false.</summary>
    Public Function IsEqual(ByVal firstString As String, ByVal secondString As String) As Boolean
      Return String.Compare(firstString, secondString, True) = 0
    End Function

    '''<summary>Vergleicht die angegebenen Strings ohne Berücksichtigung von Groß-/Kleinschreibung.</summary>
    Public Function Compare(ByVal firstString As String, ByVal secondString As String) As Int32
      Return String.Compare(firstString, secondString, True)
    End Function

    '''<summary>
    '''Liefert den ersten Index an welchem die Zeichenfolge value in der Zeichenfolge sourceString auftritt.
    '''Groß-/Kleinschreibung wird nicht berücksichtigung.
    '''</summary>
    Public Function IndexOf(ByVal sourceString As String, ByVal value As String) As Int32

      Return sourceString.IndexOf(value, 0, StringComparison.CurrentCultureIgnoreCase)
    End Function

    '''<summary>
    '''Liefert den letzten Index an welchem die Zeichenfolge value in der Zeichenfolge sourceString auftritt.
    '''Groß-/Kleinschreibung wird nicht berücksichtigung.
    '''</summary>
    Public Function LastIndexOf(ByVal sourceString As String, ByVal value As String) As Int32

      Return sourceString.IndexOf(value, 0, StringComparison.CurrentCultureIgnoreCase)
    End Function

    '''<summary>
    '''Liefert true, wenn value in der Zeichenfolge sourceString enthalten ist, ansonsten false.
    '''Groß-/Kleinschreibung wird nicht berücksichtigung.
    '''</summary>
    Public Function Contains(ByVal sourceString As String, ByVal value As String) As Boolean
      Return IndexOf(sourceString, value) > -1
    End Function

    '''<summary>
    '''Liefert true, wenn sourceString mit der Zeichenfolge value beginnt, ansonsten false.
    '''Groß-/Kleinschreibung wird nicht berücksichtigung.
    '''</summary>
    Public Function StartsWith(ByVal sourceString As String, ByVal value As String) As Boolean
      Return IndexOf(sourceString, value) = 0
    End Function

    '''<summary>
    '''Liefert true, wenn sourceString mit der Zeichenfolge value endet, ansonsten false.
    '''Groß-/Kleinschreibung wird nicht berücksichtigung.
    '''</summary>
    Public Function EndsWith(ByVal sourceString As String, ByVal value As String) As Boolean
      Return (IndexOf(sourceString, value) + value.Length) = sourceString.Length
    End Function

    '''<summary>
    '''Ersetzt oldString durch newString im sourceString und liefert die ersetzte Zeichenfolge zurück.
    '''Groß-/Kleinschreibung wird nicht berücksichtigung.
    '''</summary>
    Public Function Replace(ByVal sourceString As String, ByVal oldString As String, ByVal newString As String) As String

      Return (New StringReplace).Replace(sourceString, oldString, newString)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace