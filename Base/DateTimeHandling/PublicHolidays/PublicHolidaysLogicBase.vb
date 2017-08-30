Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.DateTimeHandling.PublicHolidays.Interfaces
Imports SSP.Base.StringHandling
#End Region

Namespace DateTimeHandling.PublicHolidays

  Public MustInherit Class PublicHolidaysLogicBase

    Implements IPublicHolidaysLogic

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public MustOverride ReadOnly Property CultureCode As CultureCodes Implements IPublicHolidaysLogic.CultureCode

    '''<summary>Liefert das gewählte Betrachtungsjahr.</summary>
    Public ReadOnly Property CurrentYear() As Int32 Implements IPublicHolidaysLogic.CurrentYear

    '''<summary>Liefert alle Feiertage des gewählten Jahres.</summary>
    Public ReadOnly Property Holidays As New List(Of IPublicHolidayItem) Implements IPublicHolidaysLogic.Holidays

    '''<summary>Liefert alle fixen Feiertage des gewählten Jahres.</summary>
    Public ReadOnly Property FixedHolidays() As List(Of IPublicHolidayItem) _
    Implements IPublicHolidaysLogic.FixedHolidays
      Get
        Return Me.Holidays.FindAll(Function(x As IPublicHolidayItem) x.IsFix)
      End Get
    End Property

    '''<summary>Liefert alle beweglichen Feiertage des gewählten Jahres.</summary>
    Public ReadOnly Property FloatingHolidays() As List(Of IPublicHolidayItem) _
    Implements IPublicHolidaysLogic.FloatingHolidays
      Get
        Return Me.Holidays.FindAll(Function(x As IPublicHolidayItem) Not x.IsFix)
      End Get
    End Property

    '''<summary>Liefert alle regionalen Feiertage des gewählten Jahres.</summary>
    Public ReadOnly Property RegionalHolidays() As List(Of IPublicHolidayItem) _
    Implements IPublicHolidaysLogic.RegionalHolidays
      Get
        Return Me.Holidays.FindAll(Function(x As IPublicHolidayItem) x.IsRegional)
      End Get
    End Property

    '''<summary>Liefert alle nicht regionalen Feiertage des gewählten Jahres.</summary>
    Public ReadOnly Property NotRegionalHolidays() As List(Of IPublicHolidayItem) _
    Implements IPublicHolidaysLogic.NotRegionalHolidays
      Get
        Return Me.Holidays.FindAll(Function(x As IPublicHolidayItem) Not x.IsRegional)
      End Get
    End Property

    '''<summary>Liefert das PublicHolidayItem zum angegebenen Datum validDate oder NULL.</summary>
    Public ReadOnly Property Item(ByVal validDate As DateTime) As IPublicHolidayItem _
    Implements IPublicHolidaysLogic.Item
      Get
        Return Me.Holidays.Find(Function(x As IPublicHolidayItem) Convert.ToBoolean(x.ValidDate = validDate))
      End Get
    End Property

    '''<summary>Prüft ob das übergebene Datum ein Feiertag ist.</summary>
    Public ReadOnly Property IsPublicHoliday(ByVal validDate As DateTime) As Boolean _
    Implements IPublicHolidaysLogic.IsPublicHoliday
      Get
        Return (Me.Holidays.Find(Function(x As IPublicHolidayItem) x.ValidDate.Date = validDate.Date) IsNot Nothing)
      End Get
    End Property

    '''<summary>Ermittelt den Namen des Feiertages, des angegebenen Datums.</summary>
    Public ReadOnly Property PublicHolidayName(ByVal validDate As DateTime) As IPublicHolidayItem _
    Implements IPublicHolidaysLogic.PublicHolidayName
      Get
        Return (Me.Holidays.Find(Function(x As IPublicHolidayItem) x.ValidDate.Date = validDate.Date))
      End Get
    End Property
#End Region

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
    Protected MustOverride Sub InitializePublicHolidays()

    Protected Function GetDateTime(ByVal month As Int32, ByVal day As Int32) As DateTime
      Return New DateTime(Me.CurrentYear, month, day)
    End Function

    Protected Function GetDateTime(ByVal year As Int32, ByVal month As Int32, ByVal day As Int32) As DateTime
      Return New DateTime(year, month, day)
    End Function

    Protected Sub AddFixedNotRegionalPublicDay _
    (ByVal validDate As DateTime, ByVal publicHolidayName As String)

      AddPublicDay(validDate, publicHolidayName, String.Empty, True, False)
    End Sub

    Protected Sub AddFixedRegionalPublicDay _
    (ByVal validDate As DateTime, ByVal publicHolidayName As String, ByVal comment As String)

      AddPublicDay(validDate, publicHolidayName, comment, True, True)
    End Sub

    Protected Sub AddNotFixedNotRegionalPublicDay _
    (ByVal validDate As DateTime, ByVal publicHolidayName As String)

      AddPublicDay(validDate, publicHolidayName, String.Empty, False, False)
    End Sub

    Protected Sub AddNotFixedRegionalPublicDay _
    (ByVal validDate As DateTime, ByVal publicHolidayName As String, ByVal comment As String)

      AddPublicDay(validDate, publicHolidayName, comment, False, True)
    End Sub

    Protected Sub AddPublicDay _
    (ByVal validDate As DateTime, ByVal publicHolidayName As String _
    , ByVal comment As String, ByVal isFix As Boolean, ByVal isRegional As Boolean)

      Dim item = New PublicHolidayItem(validDate, publicHolidayName, comment, isFix, isRegional)
      Me.Holidays.Add(item)
    End Sub

    Protected Function GetEasterSunday() As DateTime
      Dim a = Me.CurrentYear Mod 19
      Dim b = Convert.ToInt32(Me.CurrentYear / 100)
      Dim c = Convert.ToInt32((8 * b + 13) / 25 - 2)
      Dim d = Convert.ToInt32(b - (Me.CurrentYear / 400) - 2)

      Dim e = (Function(x As Int32) As Int32
                 Select Case True
                   Case (x = 28) AndAlso (a > 10) : Return 27
                   Case (x = 29) : Return 28
                   Case Else : Return x
                 End Select
               End Function).Invoke((19 * (Me.CurrentYear Mod 19) + ((15 - c + d) Mod 30)) Mod 30)

      Dim f = (d + 6 * e + 2 * (Me.CurrentYear Mod 4) + 4 * (Me.CurrentYear Mod 7) + 6) Mod 7

      Dim validDate = GetDateTime(3, 1)
      Return validDate.AddDays(Convert.ToDouble(e + f + 21))
    End Function

#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Sub Initialize(ByVal year As Int32) Implements IPublicHolidaysLogic.Initialize

      If year = Me.CurrentYear Then Return

      _CurrentYear = year
      InitializePublicHolidays()
    End Sub
#End Region

  End Class

End Namespace
