Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.DateTimeHandling.Interfaces
Imports SSP.Base.StringHandling
#End Region

Namespace DateTimeHandling

  Public MustInherit Class MonthNamesHelperBase

    Implements IMonthNamesHelper

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public MustOverride ReadOnly Property CultureCode As CultureCodes Implements IMonthNamesHelper.CultureCode

    Public MustOverride ReadOnly Property April As String Implements IMonthNamesHelper.April

    Public MustOverride ReadOnly Property AprilShort As String Implements IMonthNamesHelper.AprilShort

    Public MustOverride ReadOnly Property August As String Implements IMonthNamesHelper.August

    Public MustOverride ReadOnly Property AugustShort As String Implements IMonthNamesHelper.AugustShort

    Public MustOverride ReadOnly Property December As String Implements IMonthNamesHelper.December

    Public MustOverride ReadOnly Property DecemberShort As String Implements IMonthNamesHelper.DecemberShort

    Public MustOverride ReadOnly Property February As String Implements IMonthNamesHelper.February

    Public MustOverride ReadOnly Property FebruaryShort As String Implements IMonthNamesHelper.FebruaryShort

    Public MustOverride ReadOnly Property January As String Implements IMonthNamesHelper.January

    Public MustOverride ReadOnly Property JanuaryShort As String Implements IMonthNamesHelper.JanuaryShort

    Public MustOverride ReadOnly Property July As String Implements IMonthNamesHelper.July

    Public MustOverride ReadOnly Property JulyShort As String Implements IMonthNamesHelper.JulyShort

    Public MustOverride ReadOnly Property June As String Implements IMonthNamesHelper.June

    Public MustOverride ReadOnly Property JuneShort As String Implements IMonthNamesHelper.JuneShort

    Public MustOverride ReadOnly Property March As String Implements IMonthNamesHelper.March

    Public MustOverride ReadOnly Property MarchShort As String Implements IMonthNamesHelper.MarchShort

    Public MustOverride ReadOnly Property May As String Implements IMonthNamesHelper.May

    Public MustOverride ReadOnly Property MayShort As String Implements IMonthNamesHelper.MayShort

    Public MustOverride ReadOnly Property November As String Implements IMonthNamesHelper.November

    Public MustOverride ReadOnly Property NovemberShort As String Implements IMonthNamesHelper.NovemberShort

    Public MustOverride ReadOnly Property October As String Implements IMonthNamesHelper.October

    Public MustOverride ReadOnly Property OctoberShort As String Implements IMonthNamesHelper.OctoberShort

    Public MustOverride ReadOnly Property September As String Implements IMonthNamesHelper.September

    Public MustOverride ReadOnly Property SeptemberShort As String Implements IMonthNamesHelper.SeptemberShort
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Function GetMonthNameByIndex(monthIndex As Byte) As String _
    Implements IMonthNamesHelper.GetMonthNameByIndex

      Select Case monthIndex
        Case 1
          Return Me.January
        Case 2
          Return Me.February
        Case 3
          Return Me.March
        Case 4
          Return Me.April
        Case 5
          Return Me.May
        Case 6
          Return Me.June
        Case 7
          Return Me.July
        Case 8
          Return Me.August
        Case 9
          Return Me.September
        Case 10
          Return Me.October
        Case 11
          Return Me.November
        Case 12
          Return Me.December
        Case Else
          Return String.Empty
      End Select
    End Function

    Public Function GetMonthNameShortByIndex(monthIndex As Byte) As String _
    Implements IMonthNamesHelper.GetMonthNameShortByIndex

      Select Case monthIndex
        Case 1
          Return Me.JanuaryShort
        Case 2
          Return Me.FebruaryShort
        Case 3
          Return Me.MarchShort
        Case 4
          Return Me.AprilShort
        Case 5
          Return Me.MayShort
        Case 6
          Return Me.JuneShort
        Case 7
          Return Me.JulyShort
        Case 8
          Return Me.AugustShort
        Case 9
          Return Me.SeptemberShort
        Case 10
          Return Me.OctoberShort
        Case 11
          Return Me.NovemberShort
        Case 12
          Return Me.DecemberShort
        Case Else
          Return String.Empty
      End Select
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
