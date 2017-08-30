Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.DateTimeHandling.AcademicYearHandling.Enums
#End Region

Namespace DateTimeHandling.AcademicYearHandling.Interfaces

  Public Interface IClassificationItem

    Inherits IComparable
    Inherits IComparer

    ReadOnly Property StartDate As DateTime
    ReadOnly Property EndDate As DateTime
    ReadOnly Property PeriodCode As PeriodCode
    ReadOnly Property PeriodYear As Int32
    ReadOnly Property Period As Periods
    ReadOnly Property PeriodName As PeriodNames
    ReadOnly Property DurationInMonth As Int32
    ReadOnly Property AcademicYearClassification() As AcademicYearClassification

    Function GetByDateInternal(ByVal d As Date) As IClassificationItem
    Function GetStartDateNextPeriods(ByVal count As Int32) As DateTime
    Function AddInternal(ByVal count As Int32) As IClassificationItem
    Function SubstractInternal(ByVal count As Int32) As IClassificationItem
    Function Difference(ByVal periodItem As IClassificationItem) As Int32
  End Interface

End Namespace