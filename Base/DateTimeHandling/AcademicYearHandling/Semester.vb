Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.DateTimeHandling.AcademicYearHandling.Enums
Imports SSP.Base.DateTimeHandling.AcademicYearHandling.Interfaces
#End Region

Namespace DateTimeHandling.AcademicYearHandling

  Public Class Semester

    Inherits ClassificationItem

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
      MyBase.New(DateTime.Now)
    End Sub

    Public Sub New(ByVal d As DateTime)
      MyBase.New(d)
    End Sub

    Public Sub New(ByVal year As Int32, period As Periods)
      MyBase.New(New PeriodCode(year, period))
    End Sub

    Public Sub New(ByVal periodCode As PeriodCode)
      MyBase.New(periodCode)
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert das aktuelle Semester.</summary>
    Public Shared ReadOnly Property Current As Semester
      Get
        Return New Semester
      End Get
    End Property

    Protected Overrides ReadOnly Property AcademicYearClassification() As AcademicYearClassification
      Get
        Return Semesters.Instance
      End Get
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Protected Overrides Function GetByDateInternal(ByVal d As Date) As IClassificationItem

      Dim periodItem = Me.AcademicYearClassification.FirstOrDefault(Function(x) x.MonthsInPeriod.Contains(d.Month))
      Dim year = If((periodItem.StartMonth > periodItem.EndMonth) AndAlso (d.Month <= periodItem.EndMonth), d.Year - 1, d.Year)

      Dim result = New Semester(year, periodItem.Period)
      Return result
    End Function

    '''<summary>
    '''Addiert die Anzahl count zur Periode und liefert das Ergebnis als neues Objekt.
    '''</summary>
    Protected Overrides Function AddInternal(count As Integer) As IClassificationItem
      Dim d = GetStartDateNextPeriods(count)
      Dim result = Semesters.GetByDate(d)
      Return result
    End Function

    '''<summary>
    '''Subtrahiert die Anzahl count von der Periode und liefert das Ergebnis als neues Objekt.
    '''</summary>
    Protected Overrides Function SubstractInternal(count As Integer) As IClassificationItem
      Dim result = AddInternal(count * -1)
      Return result
    End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Liefert das Semester des angegebenen Datums.</summary>
    Public Shared Function GetByDate(ByVal d As Date) As Semester
      Dim result = DirectCast(Current.GetByDateInternal(d), Semester)
      Return result
    End Function

    '''<summary>Addiert die Anzahl count zur Periode und liefert das Ergebnis als neues Semester-Objekt.</summary>
    Public Function Add(count As Integer) As Semester
      Return DirectCast(AddInternal(count), Semester)
    End Function

    '''<summary>Subtrahiert die Anzahl count von der Periode und liefert das Ergebnis als neues Semester-Objekt.</summary>
    Public Function Substract(count As Integer) As Semester
      Return DirectCast(SubstractInternal(count), Semester)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace