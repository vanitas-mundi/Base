Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
#End Region

Namespace StringHandling

  Public Class StringChecks

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
    ''' Prüft, ob sourceString mit der Zeichenfolge wildcard übereinstimmt.
    ''' Bsp.: IsLike("Hallo", "*ll*") -> True, IsLike("Hallo", "hal*") -> True, IsLike("Hallo", "hel*") -> False
    ''' </summary>
    Public Function IsLike(ByVal sourceString As String, ByVal wildcard As String) As Boolean

      Return IsLike(sourceString, wildcard, False)
    End Function

    '''<summary>
    '''Prüft, ob sourceString mit der Zeichenfolge wildcard übereinstimmt.
    '''Groß-/Kleinschreibung wird bei ignoreCase = true nicht berücksichtigt. 
    '''Bsp.: IsLike("Hallo", "*LL*", True) -> True, IsLike("Hallo", "hal*", False) -> False, IsLike("Hallo", "hel*") -> False
    '''</summary>
    Public Function IsLike(ByVal sourceString As String, ByVal wildcard As String, ByVal ignoreCase As Boolean) As Boolean

      Return If(ignoreCase, sourceString.ToLower Like wildcard.ToLower, sourceString Like wildcard)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace