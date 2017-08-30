Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace DateTimeHandling

  Public Class DateTimeFormat

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
    '''<summary>Formatiert ein Datum in das Datums-Format yyyy-MM-dd.</summary>
    Public Function ToYMD(ByVal obj As Object) As String

      Return Convert.ToDateTime(obj).ToString("yyyy-MM-dd")
    End Function

    '''<summary>Formatiert ein Datum in das Datums-Format dd.MM.yyyy.</summary>
    Public Function ToDMY(ByVal obj As Object) As String

      Return Convert.ToDateTime(obj).ToString("dd.MM.yyyy")
    End Function

    '''<summary>Formatiert ein Datum in das Stunden-Format HH:mm.</summary>
    Public Function ToHM(ByVal obj As Object) As String

      Return Convert.ToDateTime(obj).ToString("HH:mm")
    End Function

    '''<summary>Formatiert ein Datum in das Stunden-Format HH:mm:ss.</summary>
    Public Function ToHMS(ByVal obj As Object) As String

      Return Convert.ToDateTime(obj).ToString("HH:mm:ss")
    End Function

    '''<summary>Formatiert ein Datum in das Datums-Format dd.MM.yyyy..</summary>
    Public Function ToYMDHMS(ByVal obj As Object) As String

      Return Convert.ToDateTime(obj).ToString("yyyy-MM-dd HH:mm:ss")
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace