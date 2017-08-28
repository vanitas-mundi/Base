Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace NumberHandling

  Public Class NumberChecks


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
    '''Prüft ob der Wert von s eine rationale Zahl (Ganzzahl)
    '''oder eine irrationale Zahl (reelle Zahl) ist.
    '''</summary>
    Public Function IsNumber(ByVal value As String) As Boolean

      Return IsInteger(value) OrElse IsReal(value)
    End Function

    '''<summary>Prüft ob der Wert von s eine irrationale Zahl (reelle Zahl) ist.</summary>
    Public Function IsReal(ByVal value As String) As Boolean

      Dim result As Double
      Return Double.TryParse(value, result)
    End Function

    '''<summary>Prüft ob der Wert von s eine rationale Zahl (Ganzzahl) ist.</summary>
    Public Function IsInteger(ByVal value As String) As Boolean

      Dim result As Int64
      Return Int64.TryParse(value, result)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace


