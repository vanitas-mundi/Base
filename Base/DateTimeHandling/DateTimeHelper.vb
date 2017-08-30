Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.StringHandling
#End Region

Namespace DateTimeHandling

  Public NotInheritable Class DateTimeHelper

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Friend Sub New()
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Stellt Prüfungsmethoden für Datum und Zeit bereit.</summary>
    Public ReadOnly Property Checks As New DateTimeChecks

    '''<summary>Stellt Konvertierungsmethoden für Datum und Zeit bereit.</summary>
    Public ReadOnly Property Convert As New DateTimeConvert

    '''<summary></summary>
    Public Property CultureCode As CultureCodes = CultureCodes.a_Default

    '''<summary>Stellt Differenzmethoden für Datum und Zeit zur Verfügung.</summary>
    Public ReadOnly Property Difference As New DateTimeDifferences

    '''<summary>Stellt Formatierungsmethoden für Datum und Zeit zur Verfügung.</summary>
    Public ReadOnly Property Format As New DateTimeFormat

    '''<summary>Stellt allgemeine Datum-, Zeit-Funktionen bereit.</summary>
    Public ReadOnly Property Functions As New DateTimeFunctions

    '''<summary>Stellt lokalisierte Benamungen für Monate und Tage zur Verfügung.</summary>
    Public ReadOnly Property Names As New DateTimeNames

    '''<summary>Stellt Feiertagsfunktionalität bereit.</summary>
    Public ReadOnly Property PublicHolidays As New DateTimePublicHolidays

    '''<summary>Stellt Studienjahr-Funktionalität bereit (Semester, Trimester usw.).</summary>
    Public ReadOnly Property AcademicYears As New AcademicYearHelper
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "

#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
