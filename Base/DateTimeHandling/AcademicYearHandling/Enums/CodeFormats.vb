Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace DateTimeHandling.AcademicYearHandling.Enums

  Public Enum CodeFormats
    '''<summary>2017 SS</summary>
    YearBlankPeriod
    '''<summary>SS 2017</summary>
    PeriodBlankYear
    '''<summary>2017-SS</summary>
    YearHyphenPeriod
    '''<summary>SS-2017</summary>
    PeriodHyphenYear
    '''<summary>2017SS</summary>
    YearPeriod
    '''<summary>SS2017</summary>
    PeriodYear
  End Enum

End Namespace