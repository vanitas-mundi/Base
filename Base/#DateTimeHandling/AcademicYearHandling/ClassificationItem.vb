Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports BCW.Foundation.Base.DateTimeHandling.AcademicYearHandling.Enums
Imports BCW.Foundation.Base.DateTimeHandling.AcademicYearHandling.Interfaces
#End Region

Namespace DateTimeHandling.AcademicYearHandling

  Public MustInherit Class ClassificationItem

    Implements IClassificationItem

#Region " --------------->> Implements IComparable und IComparer "
    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo

      Dim semester = DirectCast(obj, IClassificationItem)
      Dim result = String.Compare(Me.ToString, semester.ToString)
      Return result
    End Function

    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare

      Dim firstSemester = DirectCast(x, IClassificationItem)
      Dim secondSemester = DirectCast(y, IClassificationItem)
      Dim result = 0

      Select Case True
        Case firstSemester.StartDate < secondSemester.StartDate
          result = 1
        Case firstSemester.StartDate > secondSemester.StartDate
          result = -1
        Case Else
          result = 0
      End Select

      Return result
    End Function
#End Region '{Implements IComparable und IComparer}

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
      Me.PeriodCode = Me.GetByDateInternal(DateTime.Now).PeriodCode
    End Sub

    Public Sub New(ByVal d As DateTime)
      Me.PeriodCode = Me.GetByDateInternal(d).PeriodCode
    End Sub

    Public Sub New(ByVal year As Int32, period As Periods)
      Me.New(New PeriodCode(year, period))
    End Sub

    Public Sub New(ByVal periodCode As PeriodCode)
      Me.PeriodCode = periodCode
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Protected MustOverride ReadOnly Property AcademicYearClassification() As AcademicYearClassification _
    Implements IClassificationItem.AcademicYearClassification

    '''<summary>Startdatum des Semesters.</summary>
    Public ReadOnly Property StartDate As Date Implements IClassificationItem.StartDate
      Get
        Return Me.GetStartDate(Me.PeriodCode)
      End Get
    End Property

    '''<summary>Endedatum des Semesters.</summary>
    Public ReadOnly Property EndDate As Date Implements IClassificationItem.EndDate
      Get
        Return Me.GetEndDate(Me.PeriodCode)
      End Get
    End Property

    '''<summary>Kürzel des Semesters.</summary>
    Public ReadOnly Property PeriodCode As PeriodCode Implements IClassificationItem.PeriodCode

    '''<summary>Jahr des Semesters.</summary>
    Public ReadOnly Property PeriodYear As Integer Implements IClassificationItem.PeriodYear
      Get
        Return Me.PeriodCode.Year
      End Get
    End Property

    '''<summary>Periode des Semesters.</summary>
    Public ReadOnly Property Period As Periods Implements IClassificationItem.Period
      Get
        Return Me.PeriodCode.Period
      End Get
    End Property

    '''<summary>Liefert den Namen der Semester-Periode.</summary>
    Public ReadOnly Property PeriodName As PeriodNames Implements IClassificationItem.PeriodName
      Get
        Dim result = CType(Convert.ToInt32(Me.Period), PeriodNames)
        Return result
      End Get
    End Property

    '''<summary>Liefert die Dauer in Monaten.</summary>
    Public ReadOnly Property DurationInMonth As Integer Implements IClassificationItem.DurationInMonth
      Get
        Return Me.AcademicYearClassification.DurationInMonth
      End Get
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Protected MustOverride Function GetByDateInternal(ByVal d As Date) As IClassificationItem Implements IClassificationItem.GetByDateInternal

    Protected MustOverride Function AddInternal(count As Integer) As IClassificationItem Implements IClassificationItem.AddInternal

    Protected MustOverride Function SubstractInternal(count As Integer) As IClassificationItem Implements IClassificationItem.SubstractInternal

    Protected Function GetStartDate(ByVal code As PeriodCode) As DateTime

      Dim periodItem = Me.AcademicYearClassification.FirstOrDefault(Function(x) x.Period = code.Period)
      Dim dateString = $"{code.Year}-{periodItem.StartMonth.ToString("00")}-01"
      Dim result = DateTime.Parse(dateString)
      Return result
    End Function

    Protected Function GetStartDate(ByVal d As Date) As DateTime

      Dim periodItem = Me.AcademicYearClassification.FirstOrDefault(Function(x) x.MonthsInPeriod.Contains(d.Month))
      Dim year = If(periodItem.StartMonth <= d.Month, d.Year, d.Year - 1)
      Dim dateString = $"{year}-{periodItem.StartMonth.ToString("00")}-01"
      Dim result = DateTime.Parse(dateString)
      Return result
    End Function

    Protected Function GetEndDate(ByVal code As PeriodCode) As DateTime

      Dim periodItem = Me.AcademicYearClassification.FirstOrDefault(Function(x) x.Period = code.Period)
      Dim year = If(periodItem.StartMonth <= periodItem.EndMonth, code.Year, code.Year + 1)
      Dim dateString = $"{year}-{periodItem.EndMonth.ToString("00")}-{DateTime.DaysInMonth(year, periodItem.EndMonth)}"
      Dim result = DateTime.Parse(dateString)
      Return result
    End Function

    Protected Function GetEndDate(ByVal d As Date) As DateTime

      Dim periodItem = Me.AcademicYearClassification.FirstOrDefault(Function(x) x.MonthsInPeriod.Contains(d.Month))
      Dim isTrue = (periodItem.StartMonth > periodItem.EndMonth) AndAlso (d.Month > periodItem.StartMonth)
      Dim year = If(isTrue, d.Year + 1, d.Year)
      Dim dateString = $"{year}-{periodItem.EndMonth.ToString("00")}-{DateTime.DaysInMonth(year, periodItem.EndMonth)}"
      Dim result = DateTime.Parse(dateString)
      Return result
    End Function

    Protected Function GetStartDateNextPeriods(ByVal count As Int32) As DateTime Implements IClassificationItem.GetStartDateNextPeriods

      Dim countMonths = count * Me.DurationInMonth
      Dim result = Me.StartDate.AddMonths(countMonths)
      Return result
    End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Overrides Function ToString() As String
      Return Me.PeriodCode.GetFormatedPeriodCode(CodeFormats.YearBlankPeriod)
    End Function

    Public Overloads Function ToString(ByVal format As CodeFormats) As String
      Return Me.PeriodCode.GetFormatedPeriodCode(format)
    End Function

    '''<summary>Ermittlet die Differenz in Perioden.</summary>
    Public Function Difference(periodItem As IClassificationItem) As Integer Implements IClassificationItem.Difference

      Dim factor = If(Me.StartDate <= periodItem.StartDate, 1, -1)
      Dim current As IClassificationItem = Me
      Dim delta = 0

      Do
        If Not current.StartDate = periodItem.StartDate Then
          delta += factor
          current = Me.AddInternal(delta)
        End If
      Loop Until current.StartDate = periodItem.StartDate

      Return delta
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace