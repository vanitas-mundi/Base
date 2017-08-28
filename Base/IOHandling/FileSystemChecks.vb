Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.IO
#End Region

Namespace IOHandling

  Public Class FileSystemChecks

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
    '''<summary>Prüft, ob eine Datei bereits geöffnet ist.</summary>
    Public Function IsFileInUse(ByVal fileName As String) As Boolean

      With My.Computer.FileSystem
        If Not .FileExists(fileName) Then Return False

        Try
          Using file = New FileStream(fileName, FileMode.Append, FileAccess.Write) : End Using
          Return False
        Catch ex As Exception
          Return True
        End Try
      End With
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace