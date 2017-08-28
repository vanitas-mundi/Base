Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace IOHandling

  Public Class FileSystemNaming

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
    '''Liefert einen zufälligen, eindeutigen Dateinamen mit der Dateiendung extension
    '''im Dateipfad path.
    '''Bsp.: GetGuidFileName("c:\","txt") -> "c:\4D9D-80C7-02AF85C822A8.txt"
    '''</summary>
    Public Function GetGuidFileName(ByVal path As String, ByVal extension As String) As String
      Return GetGuidFileName(path, extension, String.Empty)
    End Function

    '''<summary>
    '''Liefert einen zufälligen, eindeutigen Dateinamen mit der Dateiendung extension
    '''im Dateipfad path. Hinter der Guid wird suffix angehängt getrennt durch einen Unterstrich.
    '''Bsp.: GetGuidFileName("c:\","txt","MySuffix") -> "c:\4D9D-80C7-02AF85C822A8_MySuffix.txt"
    '''</summary>
    Public Function GetGuidFileName(ByVal path As String, ByVal extension As String, ByVal suffix As String) As String

      With My.Computer.FileSystem
        Dim replacer = New FileSystemReplace

        If String.IsNullOrWhiteSpace(path) Then path = .SpecialDirectories.Temp
        path = replacer.InvalidPathChars(path)

        If String.IsNullOrWhiteSpace(extension) Then extension = "tmp"
        extension = "." & extension.Replace(".", String.Empty)

        If Not String.IsNullOrWhiteSpace(suffix) Then
          suffix = If(suffix.StartsWith("_"), String.Empty, "_") & suffix
        Else
          suffix = suffix.Trim
        End If

        Dim guid = System.Guid.NewGuid.ToString

        Dim name = replacer.InvalidFileNameChars($"{guid}{suffix}{extension}")
        Dim result = .CombinePath(path, name)

        Return result
      End With
    End Function

    '''<summary>Extrahiert den Pfad aus dem Dateinamen fileName und liefert diesen zurück. </summary>
    Public Function GetPathFromFileName(ByVal fileName As String) As String

      Dim parts = fileName.Split("\"c).ToList
      Dim result = parts.TakeWhile(Function(x, i) i < parts.Count - 1).ToArray
      Return String.Join("\", result)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace