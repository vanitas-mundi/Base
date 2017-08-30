Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.DateTimeHandling.AcademicYearHandling.Enums
Imports SSP.Base.DateTimeHandling.AcademicYearHandling.Interfaces
#End Region

Namespace DateTimeHandling.AcademicYearHandling

  Public Class Trimester

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

    Public Sub New(ByVal periodYear As Int32, period As Periods)
      MyBase.New(New PeriodCode(periodYear, period))
    End Sub

    Public Sub New(ByVal periodCode As PeriodCode)
      MyBase.New(periodCode)
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert das aktuelle Trimester.</summary>
    Public Shared ReadOnly Property Current As Trimester
      Get
        Return New Trimester
      End Get
    End Property

    Protected Overrides ReadOnly Property AcademicYearClassification() As AcademicYearClassification
      Get
        Return Trimesters.Instance
      End Get
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Protected Overrides Function GetByDateInternal(ByVal d As Date) As IClassificationItem

      Dim period = Me.AcademicYearClassification.FirstOrDefault(Function(x) x.MonthsInPeriod.Contains(d.Month))
      Dim result = New Trimester(d.Year, period.Period)
      Return result
    End Function

    '''<summary>
    '''Addiert die Anzahl count zur Periode und liefert das Ergebnis als neues Objekt.
    '''</summary>
    Protected Overrides Function AddInternal(count As Integer) As IClassificationItem
      Dim d = GetStartDateNextPeriods(count)
      Dim result = Trimesters.GetByDate(d)
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
    '''<summary>Liefert das Trimester des angegebenen Datums.</summary>
    Public Shared Function GetByDate(ByVal d As Date) As Trimester

      Dim result = DirectCast(Current.GetByDateInternal(d), Trimester)
      Return result
    End Function

    '''<summary>Addiert die Anzahl count zur Periode und liefert das Ergebnis als neues Trimester-Objekt.</summary>
    Public Function Add(count As Integer) As Trimester
      Return DirectCast(AddInternal(count), Trimester)
    End Function

    '''<summary>Subtrahiert die Anzahl count von der Periode und liefert das Ergebnis als neues Trimester-Objekt.</summary>
    Public Function Substract(count As Integer) As Trimester
      Return DirectCast(SubstractInternal(count), Trimester)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace