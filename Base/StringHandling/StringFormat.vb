Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
#End Region

Namespace StringHandling

  Public Class StringFormat

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
    ''' <summary>
    ''' Ersetzt die in sourceString vorhandenen Platzhalter {0}, {1} ...
    ''' mit den im ParamArray args angegebenen Werten.
    ''' </summary>
    Public Function GetStringFormat(ByVal sourceString As String, ByVal ParamArray args() As Object) As String

      Dim sb = New StringBuilder(sourceString)

      For i = 0 To args.Count - 1
        sb.Replace("{" & i & "}", args(i).ToString)
      Next i
      Return sb.ToString
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace