Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace IOHandling

  '''<summary>Stellt Funktionalität für einen erleichterten Dateizugriff zur Verfügung</summary>
  Public NotInheritable Class FileSystemHelper

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Friend Sub New()
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Stellt Funktionalität zum Lesen einer Datei bereit.</summary>
    Public ReadOnly Property Reader As FileSystemReader = New FileSystemReader

    '''<summary>Stellt Funktionalität zur Manipulations des Dateisystems zur Verfügung.</summary>
    Public ReadOnly Property Manipulation As FileSystemManipulation = New FileSystemManipulation

    '''<summary>Stellt Ersetzungs-Funktionalität zur Verfügung.</summary>
    Public ReadOnly Property Replace As FileSystemReplace = New FileSystemReplace

    '''<summary>Stellt Prüfungs-Funktionalität zur Verfügung.</summary>
    Public ReadOnly Property Checks As FileSystemChecks = New FileSystemChecks

    '''<summary>Stellt Benamungs-Funktionalität zur Verfügung.</summary>
    Public ReadOnly Property Naming As FileSystemNaming = New FileSystemNaming
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
