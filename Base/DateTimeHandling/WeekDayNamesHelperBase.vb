Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.DateTimeHandling.Enums
Imports SSP.Base.DateTimeHandling.Interfaces
Imports SSP.Base.StringHandling
#End Region

Namespace DateTimeHandling

  Public MustInherit Class WeekDayNamesHelperBase

    Implements IWeekDayNamesHelper

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public MustOverride ReadOnly Property CultureCode As CultureCodes Implements IWeekDayNamesHelper.CultureCode

    Public MustOverride ReadOnly Property Friday As String Implements IWeekDayNamesHelper.Friday

    Public MustOverride ReadOnly Property FridayShort As String Implements IWeekDayNamesHelper.FridayShort

    Public MustOverride ReadOnly Property Monday As String Implements IWeekDayNamesHelper.Monday

    Public MustOverride ReadOnly Property MondayShort As String Implements IWeekDayNamesHelper.MondayShort

    Public MustOverride ReadOnly Property Saturday As String Implements IWeekDayNamesHelper.Saturday

    Public MustOverride ReadOnly Property SaturdayShort As String Implements IWeekDayNamesHelper.SaturdayShort

    Public MustOverride ReadOnly Property Sunday As String Implements IWeekDayNamesHelper.Sunday

    Public MustOverride ReadOnly Property SundayShort As String Implements IWeekDayNamesHelper.SundayShort

    Public MustOverride ReadOnly Property Thursday As String Implements IWeekDayNamesHelper.Thursday

    Public MustOverride ReadOnly Property ThursdayShort As String Implements IWeekDayNamesHelper.ThursdayShort

    Public MustOverride ReadOnly Property Tuesday As String Implements IWeekDayNamesHelper.Tuesday

    Public MustOverride ReadOnly Property TuesdayShort As String Implements IWeekDayNamesHelper.TuesdayShort

    Public MustOverride ReadOnly Property Wednesday As String Implements IWeekDayNamesHelper.Wednesday

    Public MustOverride ReadOnly Property WednesdayShort As String Implements IWeekDayNamesHelper.WednesdayShort
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Function GetIndexByDate(ByVal validDate As Date) As Byte
      Return If(validDate.DayOfWeek = DayOfWeek.Sunday _
      , Convert.ToByte(WeekDayNamesEnglish.Sunday), Convert.ToByte(validDate.DayOfWeek))
    End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Function GetDayNameByDate(validDate As Date) As String _
    Implements IWeekDayNamesHelper.GetDayNameByDate

      Return GetDayNameByIndex(GetIndexByDate(validDate))
    End Function

    Public Function GetDayNameByIndex(dayIndex As Byte) As String _
    Implements IWeekDayNamesHelper.GetDayNameByIndex

      Select Case dayIndex
        Case 1
          Return Me.Monday
        Case 2
          Return Me.Tuesday
        Case 3
          Return Me.Wednesday
        Case 4
          Return Me.Thursday
        Case 5
          Return Me.Friday
        Case 6
          Return Me.Saturday
        Case 7
          Return Me.Sunday
        Case Else
          Return String.Empty
      End Select
    End Function

    Public Function GetDayNameShortByDate(validDate As Date) As String _
    Implements IWeekDayNamesHelper.GetDayNameShortByDate

      Return GetDayNameShortByIndex(GetIndexByDate(validDate))
    End Function

    Public Function GetDayNameShortByIndex(dayIndex As Byte) As String _
    Implements IWeekDayNamesHelper.GetDayNameShortByIndex

      Select Case dayIndex
        Case 1
          Return Me.MondayShort
        Case 2
          Return Me.TuesdayShort
        Case 3
          Return Me.WednesdayShort
        Case 4
          Return Me.ThursdayShort
        Case 5
          Return Me.FridayShort
        Case 6
          Return Me.SaturdayShort
        Case 7
          Return Me.SundayShort
        Case Else
          Return String.Empty
      End Select

    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
