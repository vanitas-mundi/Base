Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
#End Region

Namespace Logging

  Public NotInheritable Class FileLogger

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Shared Sub New()
      With My.Computer.FileSystem
        _DefaultLogFileName = .CombinePath(.SpecialDirectories.Temp, "bcw.log")
      End With
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Shared Property DefaultLogFileName As String
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Schreibt einen Eintrag message in die angegebene Log-Datei filename.</summary>
    Public Shared Sub Log(ByVal fileName As String, ByVal message As String)
      My.Computer.FileSystem.WriteAllText(fileName, String.Concat(message, vbNewLine), True, Encoding.UTF8)
    End Sub

    '''<summary>Schreibt einen Eintrag message in die Standard-Log-Datei DefaultLogFileName. </summary>
    Public Shared Sub Log(ByVal message As String)
      Log(DefaultLogFileName, message)
    End Sub

    '''<summary>Leert die Log-Datei filename.</summary>
    Public Shared Sub ClearLogFile(ByVal fileName As String)
      My.Computer.FileSystem.WriteAllText(fileName, "", False, Encoding.UTF8)
    End Sub

    '''<summary>Leert die Standard-Log-Datei DefaultLogFileName.</summary>
    Public Shared Sub ClearLogFile()
      ClearLogFile(DefaultLogFileName)
    End Sub

#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace

