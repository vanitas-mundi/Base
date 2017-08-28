Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports BCW.Foundation.Base.DateTimeHandling.AcademicYearHandling.Enums
#End Region

Namespace DateTimeHandling.AcademicYearHandling

  '''<summary>Repräsentiert eine Periode (zeitliche Einteilung) in einem Studienjahr (z.B. Semester)</summary>
  Public Class AcademicYearClassificationPeriod

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal startMonth As Int32, ByVal endMonth As Int32, ByVal period As Periods)

      Me.StartMonth = startMonth
      Me.EndMonth = endMonth
      Me.Period = period
      InitializeMonthsInPeriod()
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert den Monat des Semesterstarts.</summary>
    Public ReadOnly Property StartMonth As Int32

    '''<summary>Liefert den Monat des Semesterendes.</summary>
    Public ReadOnly Property EndMonth As Int32

    '''<summary>Liefert die SemesterPeriode.</summary>
    Public ReadOnly Property Period As Periods

    '''<summary>Liefert den Namen der Semesterperiode.</summary>
    Public ReadOnly Property PeriodName As PeriodNames
      Get
        Dim result = CType(Convert.ToInt32(Me.Period), PeriodNames)
        Return result
      End Get
    End Property

    '''<summary>Liefert die Monate der Semester-Periode.</summary>
    Public ReadOnly Property MonthsInPeriod As New List(Of Int32)
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Sub InitializeMonthsInPeriod()

      Dim counter = Me.StartMonth

      Do
        Me.MonthsInPeriod.Add(counter)
        counter += 1
        If counter > 12 Then counter = 1
      Loop Until counter = Me.EndMonth

      Me.MonthsInPeriod.Add(counter)
    End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Overrides Function ToString() As String
      Return $"01.{Me.StartMonth} - {DateTime.DaysInMonth(DateTime.Now.Year, Me.EndMonth)}.{Me.EndMonth}"
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace