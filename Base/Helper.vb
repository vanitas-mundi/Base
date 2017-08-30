Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.Cryptography
Imports SSP.Base.DateTimeHandling
Imports SSP.Base.IOHandling
Imports SSP.Base.NumberHandling
Imports SSP.Base.ReflectionHandling
Imports SSP.Base.StringHandling
#End Region

'Namespace
Public NotInheritable Class Helper

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '''<summary>Stellt Datum- und Zeit-Funktionalität zur Verfügung.</summary>
  Public Shared ReadOnly Property DateTime As New DateTimeHelper

  '''<summary>Stellt String-Funktionalität zur Verfügung.</summary>
  Public Shared ReadOnly Property [String] As New StringHelper

  '''<summary>Stellt Funktionalität zur Bearbeitung von Zahlen zur Verfügung.</summary>
  Public Shared ReadOnly Property Number As New NumberHelper

  '''<summary>Stellt Krypthographie-Funktionalität zur Verfügung.</summary>
  Public Shared ReadOnly Property Crypt As New CryptHelper

  '''<summary>Stellt Funktionalität für den Zugriff auf das Dateisystem zur Verfügung.</summary>
  Public Shared ReadOnly Property FileSystem As New FileSystemHelper

  '''<summary>Stellt Refection-Funktionalität zur Verfügung.</summary>
  Public Shared ReadOnly Property Reflection As New ReflectionHelper

#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

End Class

'End Namespace