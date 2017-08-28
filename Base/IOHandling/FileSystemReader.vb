Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace IOHandling

  Public Class FileSystemReader

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
    '''Liefert den Inhalt der angegebenen Textdatei filename als String zurück.
    '''Als Encoding wird UTF8 benutzt.
    '''</summary>
    Public Function GetString(ByVal fileName As String) As String
      Return GetString(fileName, Text.Encoding.UTF8)
    End Function

    '''<summary>Liefert den Inhalt der angegebenen Textdatei filename als String zurück.</summary>
    Public Function GetString(ByVal fileName As String, ByVal encoding As Text.Encoding) As String
      Return My.Computer.FileSystem.ReadAllText(fileName, encoding)
    End Function

    '''<summary>
    '''Liefert den Inhalt der angegebenen Textdatei filename als String-Array zurück.
    '''Als Encoding wird UTF8 benutzt.
    '''</summary>
    Public Function GetStringArray(ByVal fileName As String) As String()
      Return GetStringArray(fileName, Text.Encoding.UTF8)
    End Function

    '''<summary>Liefert den Inhalt der angegebenen Textdatei filename als String-Array zurück.</summary>
    Public Function GetStringArray(ByVal fileName As String, ByVal encoding As Text.Encoding) As String()
      With My.Computer.FileSystem
        Return .ReadAllText(fileName, encoding).Replace(vbCrLf, vbLf).Split(Convert.ToChar(vbLf))
      End With
    End Function

    '''<summary>
    '''Liefert den Inhalt der angegebenen Textdatei filename als List(of String) zurück.
    '''Als Encoding wird UTF8 benutzt.
    '''</summary>
    Public Function GetStringList(ByVal fileName As String) As List(Of String)
      Return GetStringArray(fileName).ToList
    End Function

    '''<summary>Liefert den Inhalt der angegebenen Textdatei filename als List(of String) zurück.</summary>
    Public Function GetStringList(ByVal fileName As String, ByVal encoding As Text.Encoding) As List(Of String)
      Return GetStringArray(fileName, encoding).ToList
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace