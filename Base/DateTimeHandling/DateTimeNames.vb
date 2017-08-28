Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports BCW.Foundation.Base.DateTimeHandling.Interfaces
Imports BCW.Foundation.Base.DateTimeHandling.PublicHolidays.Interfaces
Imports BCW.Foundation.Base.StringHandling
#End Region

Namespace DateTimeHandling

  Public Class DateTimeNames

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Private _weekDayNamesDictionary As New Dictionary(Of CultureCodes, IWeekDayNamesHelper)
    Private _monthNamesDictionary As New Dictionary(Of CultureCodes, IMonthNamesHelper)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Friend Sub New()
      Inititialze()
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Sub Inititialze()
      InitializeWeekDayNamesHelper()
      InitializeMonthNamesHelper()
    End Sub

    Private Sub InitializeWeekDayNamesHelper()
      Dim [namespace] = GetType(WeekDayNamesHelperBase).Namespace
      Dim WeekDayNamesHelperBaseType = GetType(WeekDayNamesHelperBase)

      Dim appTypes = My.Application.GetType.Assembly.GetTypes

      Dim weekDayNamesHelpers = appTypes.Where _
      (Function(x) (x.Namespace IsNot Nothing) _
      AndAlso (x.Namespace.StartsWith([namespace])) _
      AndAlso (x.BaseType Is WeekDayNamesHelperBaseType)).Select _
      (Function(x) DirectCast(Activator.CreateInstance(x), IWeekDayNamesHelper)).ToList

      weekDayNamesHelpers.ForEach(Sub(x) _weekDayNamesDictionary.Add(x.CultureCode, x))
    End Sub

    Private Sub InitializeMonthNamesHelper()
      Dim [namespace] = GetType(WeekDayNamesHelperBase).Namespace
      Dim monthNamesHelperBaseType = GetType(MonthNamesHelperBase)

      Dim appTypes = My.Application.GetType.Assembly.GetTypes

      Dim monthNamesHelpers = appTypes.Where _
      (Function(x) (x.Namespace IsNot Nothing) _
      AndAlso (x.Namespace.StartsWith([namespace])) _
      AndAlso (x.BaseType Is monthNamesHelperBaseType)).Select _
      (Function(x) DirectCast(Activator.CreateInstance(x), IMonthNamesHelper)).ToList

      monthNamesHelpers.ForEach(Sub(x) _monthNamesDictionary.Add(x.CultureCode, x))
    End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Liefert die Wochentagsnamen zum im DateTimeHelper hinterlegten CultureCode.</summary>
    Public Function WeekDayNames() As IWeekDayNamesHelper
      Return WeekDayNames(Helper.DateTime.CultureCode)
    End Function

    '''<summary>Liefert die Wochentagsnamen zum angegebenen CultureCode.</summary>
    Public Function WeekDayNames(ByVal cultureCode As CultureCodes) As IWeekDayNamesHelper
      With _weekDayNamesDictionary
        Return If(.ContainsKey(cultureCode), .Item(cultureCode), .Item(CultureCodes.de_DE))
      End With
    End Function

    '''<summary>Liefert die Monatsnamen zum im DateTimeHelper hinterlegten CultureCode.</summary>
    Public Function MonthNames() As IMonthNamesHelper
      Return MonthNames(Helper.DateTime.CultureCode)
    End Function

    '''<summary>Liefert die Monatsnamen zum im DateTimeHelper hinterlegten CultureCode.</summary>
    Public Function MonthNames(ByVal cultureCode As CultureCodes) As IMonthNamesHelper
      With _monthNamesDictionary
        Return If(.ContainsKey(cultureCode), .Item(cultureCode), .Item(CultureCodes.de_DE))
      End With
    End Function

#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace