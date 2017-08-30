Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports BCW.Foundation.Base.DateTimeHandling.AcademicYearHandling.Enums
#End Region

Namespace DateTimeHandling.AcademicYearHandling

  Public NotInheritable Class Semesters

    Inherits AcademicYearClassification

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Private Sub New()
      Me.Add(New AcademicYearClassificationPeriod(9, 2, Periods.WS))    ' Wintersemester Sep-Feb
      Me.Add(New AcademicYearClassificationPeriod(3, 8, Periods.SS))    ' Sommersemester Mrz-Aug
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Friend Shared ReadOnly Property Instance As New Semesters

    Public Shared ReadOnly Property Current As New Semester
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Liefert das Semester des angegebenen Datums.</summary>
    Public Shared Function GetByDate(ByVal d As DateTime) As Semester
      Return Semester.GetByDate(d)
    End Function

    '''<summary>Liefert das Semester des angegebenen Semesterkürzels.</summary>
    Public Shared Function GetByPeriodCode(ByVal code As PeriodCode) As Semester
      Return New Semester(code)
    End Function

    '''<summary>Liefert das Semester des angegebenen Jahres und Periode.</summary>
    Public Shared Function GetByYearAndPeriod(ByVal year As Int32, period As Periods) As Semester
      Return New Semester(year, period)
    End Function

    '''<summary>Liefert das aktuelle Semester.</summary>
    Public Function GetSemester() As Semester
      Return New Semester(DateTime.Now)
    End Function

    '''<summary>Liefert das Semester des angegebenen Datums.</summary>
    Public Function GetSemester(ByVal d As DateTime) As Semester
      Return New Semester(d)
    End Function

    '''<summary>Liefert das Semester des angegebenen Semesterkürzels.</summary>
    Public Function GetSemester(ByVal code As PeriodCode) As Semester
      Return New Semester(code)
    End Function

    '''<summary>Liefert das Semester des angegebenen Jahres und Periode.</summary>
    Public Function GetSemester(ByVal year As Int32, period As Periods) As Semester
      Return New Semester(year, period)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace