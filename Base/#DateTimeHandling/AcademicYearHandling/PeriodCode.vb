Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports BCW.Foundation.Base.DateTimeHandling.AcademicYearHandling.Enums
#End Region

Namespace DateTimeHandling.AcademicYearHandling

  '''<summary>Repräsentiert das Periodenkürzel einer expliziten Periode (z.B. Semester),
  '''der Einteilung des Studienjahres (z.B. 2017 SS).
  '''</summary>
  Public Class PeriodCode

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal year As Int32, ByVal period As Periods)
      Me.Year = year
      Me.Period = period
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Jahr der Periode (bsp. Semesters).</summary>
    Public Property Year As Int32

    '''<summary>Periodenkürzel der Periode (bsp. Semesters).</summary>
    Public Property Period As Periods

#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Liefert das formatierte Periodenkürzel.</summary>
    Public Function GetFormatedPeriodCode(ByVal format As CodeFormats) As String

      Dim result = String.Empty

      Select Case format
        Case CodeFormats.YearBlankPeriod
          result = $"{Me.Year} {Me.Period.ToString}"
        Case CodeFormats.PeriodBlankYear
          result = $"{Me.Period.ToString} {Me.Year}"
        Case CodeFormats.YearHyphenPeriod
          result = $"{Me.Year}-{Me.Period.ToString}"
        Case CodeFormats.PeriodHyphenYear
          result = $"{Me.Period.ToString}-{Me.Year}"
        Case CodeFormats.YearPeriod
          result = $"{Me.Year}{Me.Period.ToString}"
        Case CodeFormats.PeriodYear
          result = $"{Me.Period.ToString}{Me.Year}"
        Case Else
          result = $"{Me.Year} {Me.Period.ToString}"
      End Select

      Return result
    End Function

    Public Overrides Function ToString() As String
      Return GetFormatedPeriodCode(CodeFormats.YearBlankPeriod)
    End Function

    Public Overloads Function ToString(ByVal format As CodeFormats) As String
      Return GetFormatedPeriodCode(format)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace