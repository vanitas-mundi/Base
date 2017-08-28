Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace IOHandling

  Public Class FileSystemReplace

#Region " Vom Windows Form Designer generierter Code "
#End Region

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
    '''Entfernt alle ungültigen Zeichen aus dem Dateinamen filename
    '''und ersetzt sie duch "_".
    ''' </summary>
    Public Function InvalidFileNameChars(ByVal fileName As String) As String
      Return InvalidFileNameChars(fileName, "_"c)
    End Function

    '''<summary>
    '''Entfernt alle ungültigen Zeichen aus dem Dateinamen filename
    '''und ersetzt sie duch maskChar.
    ''' </summary>
    Public Function InvalidFileNameChars(ByVal fileName As String, ByVal maskChar As Char) As String

      With My.Computer.FileSystem
        Dim naming = New FileSystemNaming
        Dim path = InvalidPathChars(naming.GetPathFromFileName(fileName), maskChar)
        If path.EndsWith(":") Then path &= "\"
        Dim name = String.Join(maskChar, .GetName(fileName).Split(System.IO.Path.GetInvalidFileNameChars))
        Dim result = If(String.IsNullOrEmpty(path), name, .CombinePath(path, name))
        Return Helper.String.Replace.DuplicateChars(result, maskChar)
      End With
    End Function

    '''<summary>
    '''Entfernt alle ungültigen Zeichen aus dem Pfad path und ersetzt sie duch "_".
    ''' </summary>
    Public Function InvalidPathChars(ByVal path As String) As String
      Return InvalidPathChars(path, "_"c)
    End Function

    '''<summary>
    '''Entfernt alle ungültigen Zeichen aus dem Pfad path und ersetzt sie duch maskChar.
    ''' </summary>
    Public Shared Function InvalidPathChars(ByVal path As String, ByVal maskChar As Char) As String

      Dim result = String.Join(maskChar, path.Split(System.IO.Path.GetInvalidPathChars))
      Return Helper.String.Replace.DuplicateChars(result, maskChar)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace