Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
#End Region

Namespace StringHandling

  Public NotInheritable Class StringHelper

#Region " --------------->> Enumerationen der Klasse "
#End Region  '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Friend Sub New()
    End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>
    '''Stellt Text-Vergleichsfunktionen zur Verfügung. 
    '''Die Funktionen arbeiten nicht binär und ignorieren Groß-/Kleinschreibung.
    '''</summary>
    Public ReadOnly Property TextCompare As New StringTextCompare

    '''<summary>Stellt Ersetzungs-Funktionalität zur Verfügung.'''</summary> 
    Public ReadOnly Property Replace As New StringReplace

    '''<summary>Stellt Formatierungs-Funktionalität zur Verfügung.'''</summary> 
    Public ReadOnly Property Format As New StringFormat

    '''<summary>Stellt Prüfungs-Funktionalität zur Verfügung.'''</summary> 
    Public ReadOnly Property Checks As New StringChecks

    '''<summary>Stellt allgemeine String-Funktionalität zur Verfügung.'''</summary> 
    Public ReadOnly Property Functions As New StringFunctions
#End Region  '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region  '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace

