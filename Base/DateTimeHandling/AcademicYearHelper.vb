Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports BCW.Foundation.Base.DateTimeHandling.AcademicYearHandling
Imports BCW.Foundation.Base.DateTimeHandling.AcademicYearHandling.Enums
#End Region

Namespace DateTimeHandling

  Public Class AcademicYearHelper

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
    '''<summary>Liefert die Semesterkürzel ab startDate für die nächsten count Semester.</summary>
    Public Function GetSemesterPeriodCodes(ByVal startDate As DateTime, ByVal count As Int32) As String()
      Return GetSemesterPeriodCodes(startDate, count, CodeFormats.YearBlankPeriod)
    End Function


    '''<summary>Liefert die Semesterkürzel ab startDate für die nächsten count Semester.</summary>
    Public Function GetSemesterPeriodCodes(ByVal startDate As DateTime, ByVal count As Int32, ByVal format As CodeFormats) As String()

      Dim result = New List(Of String)

      Dim startSemester = New Semester(startDate)
      For i = 0 To count
        result.Add(startSemester.Add(i).PeriodCode.ToString(format))
      Next i

      Return result.ToArray
    End Function

    '''<summary>Liefert die Trimesterkürzel ab startDate für die nächsten count Trimester.</summary>
    Public Function GetTrimesterPeriodCodes(ByVal startDate As DateTime, ByVal count As Int32) As String()

      Dim result = New List(Of String)

      Dim startTrimester = New Trimester(startDate)
      For i = 0 To count
        result.Add(startTrimester.Add(i).PeriodCode.ToString)
      Next i

      Return result.ToArray
    End Function

    '''<summary>Liefert das aktuelle Studienjahr.</summary>
    Public Function GetAcademicYear() As AcademicYear
      Dim result = AcademicYear.CurrentYear
      Return result
    End Function

    '''<summary>Liefert das Studienjahr des angegebenen Jahres.</summary>
    Public Function GetAcademicYear(ByVal year As Int32) As AcademicYear
      Dim result = AcademicYear.CreateAcademicYear(year)
      Return result
    End Function

    '''<summary>Liefert das aktuelle Semester.</summary>
    Public Function GetSemester() As Semester
      Dim result = New Semester(DateTime.Now)
      Return result
    End Function

    '''<summary>Liefert das Semester des angegebenen Datums.</summary>
    Public Function GetSemester(ByVal d As DateTime) As Semester
      Dim result = New Semester(d)
      Return result
    End Function

    '''<summary>Liefert das Semester der angegebenen Periodenkürzels.</summary>
    Public Function GetSemester(ByVal code As PeriodCode) As Semester
      Dim result = New Semester(code)
      Return result
    End Function

    '''<summary>Liefert das Semester des angegebenen Jahres und Periode.</summary>
    Public Function GetSemester(ByVal year As Int32, ByVal period As Periods) As Semester
      Dim result = New Semester(year, period)
      Return result
    End Function

    '''<summary>Liefert das aktuelle Trimester.</summary>
    Public Function GetTrimester() As Trimester
      Dim result = New Trimester(DateTime.Now)
      Return result
    End Function

    '''<summary>Liefert das Trimester des angegebenen Datums.</summary>
    Public Function GetTrimester(ByVal d As DateTime) As Trimester
      Dim result = New Trimester(d)
      Return result
    End Function

    '''<summary>Liefert das Trimester der angegebenen Periodenkürzels.</summary>
    Public Function GetTrimester(ByVal code As PeriodCode) As Trimester
      Dim result = New Trimester(code)
      Return result
    End Function

    '''<summary>Liefert das Trimester des angegebenen Jahres und Periode.</summary>
    Public Function GetTrimester(ByVal year As Int32, ByVal period As Periods) As Trimester
      Dim result = New Trimester(year, period)
      Return result
    End Function

    '''<summary>Liefert die Differenz zwischen zwei Semestern (z.B. WS 2016 | SS 2017 = 1).</summary>
    Public Function GetSemesterDifference(ByVal firstSemester As Semester, ByVal secondSemester As Semester) As Int32
      Dim result = firstSemester.Difference(secondSemester)
      Return result
    End Function

    '''<summary>Liefert die Differenz zwischen zwei Semestern (z.B. WS 2016 | SS 2017 = 1).</summary>
    Public Function GetTrimesterDifference(ByVal firstTrimester As Trimester, ByVal secondTrimester As Trimester) As Int32
      Dim result = firstTrimester.Difference(secondTrimester)
      Return result
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace

