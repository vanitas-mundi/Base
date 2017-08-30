Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace DateTimeHandling.AcademicYearHandling

  '''<summary>Repräsentiert ein Studienjahr.</summary>
  Public Class AcademicYear

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
      Me.Year = DateTime.Now.Year
    End Sub

    Public Sub New(ByVal year As Int32)
      Me.Year = year
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert das aktuelle Studienjahr.</summary>
    Public Shared ReadOnly Property CurrentYear As New AcademicYear

    '''<summary>Liefert das aktuelle Semester im aktuellen Studienjahr.</summary>
    Public Shared ReadOnly Property CurrentSemester As Semester
      Get
        Return Semesters.Current
      End Get
    End Property

    '''<summary>Liefert das aktuelle Trimester im aktuellen Studienjahr.</summary>
    Public Shared ReadOnly Property CurrentTrimester As Trimester
      Get
        Return Trimesters.Current
      End Get
    End Property

    '''<summary>Das Jahr des Studienjahres.</summary>
    Public ReadOnly Property Year As Int32

    '''<summary>Liefert die Semester des Studienjahres.</summary>
    Public ReadOnly Property Semesters As Semesters = Semesters.Instance

    '''<summary>Liefert die Trimester des Studienjahres.</summary>
    Public ReadOnly Property Trimesters As Trimesters = Trimesters.Instance
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "

#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Liefert das Studienjahr des angegebenen Jahres.</summary>
    Public Shared Function CreateAcademicYear(ByVal year As Int32) As AcademicYear
      Return New AcademicYear(year)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace