Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.StringHandling
#End Region

Namespace DateTimeHandling.Interfaces

  Public Interface IWeekDayNamesHelper

    ReadOnly Property CultureCode As CultureCodes

    ReadOnly Property Monday As String
    ReadOnly Property Tuesday As String
    ReadOnly Property Wednesday As String
    ReadOnly Property Thursday As String
    ReadOnly Property Friday As String
    ReadOnly Property Saturday As String
    ReadOnly Property Sunday As String
    ReadOnly Property MondayShort As String
    ReadOnly Property TuesdayShort As String
    ReadOnly Property WednesdayShort As String
    ReadOnly Property ThursdayShort As String
    ReadOnly Property FridayShort As String
    ReadOnly Property SaturdayShort As String
    ReadOnly Property SundayShort As String
    Function GetDayNameByIndex(ByVal dayIndex As Byte) As String
    Function GetDayNameShortByIndex(ByVal dayIndex As Byte) As String
    Function GetDayNameByDate(ByVal validDate As DateTime) As String
    Function GetDayNameShortByDate(ByVal validDate As DateTime) As String
  End Interface

End Namespace
