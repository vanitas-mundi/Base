Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.DateTimeHandling.PublicHolidays.Interfaces
Imports SSP.Base.StringHandling
#End Region

Namespace DateTimeHandling.PublicHolidays

  Public NotInheritable Class PublicHolidaysLogicGermany

    Inherits PublicHolidaysLogicBase

#Region " --------------->> Enumerationen der Klasse "
    Public Enum FederalStateCodesGermany
      '''<summary>Baden-Württemberg</summary>
      BW
      '''<summary>Bayern</summary>
      BY
      '''<summary>Berlin</summary>
      BE
      '''<summary>Brandenburg</summary>
      BB
      '''<summary>Bremen</summary>
      HB
      '''<summary>Hamburg</summary>
      HH
      '''<summary>Hessen</summary>
      HE
      '''<summary>Mecklenburg-Vorpommern</summary>
      MV
      '''<summary>Niedersachsen</summary>
      NI
      '''<summary>Nordrhein-Westfalen</summary>
      NW
      '''<summary>Rheinland-Pfalz</summary>
      RP
      '''<summary>Saarland</summary>
      SL
      '''<summary>Sachsen</summary>
      SN
      '''<summary>Sachsen-Anhalt</summary>
      ST
      '''<summary>Schleswig-Holstein</summary>
      SH
      '''<summary>Thüringen</summary>
      TH
    End Enum
#End Region

#Region " --------------->> Eigenschaften der Klasse "
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
      InitializeFederalStates()
    End Sub
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Shared ReadOnly Property Instance() As New PublicHolidaysLogicGermany

    Public Overrides ReadOnly Property CultureCode As CultureCodes = CultureCodes.de_DE

    Public ReadOnly Property FederalStates As List(Of String)
      Get
        Return Me.FederalStatesDictionary.Values.ToList
      End Get
    End Property

    Public ReadOnly Property FederalStatesDictionary As New Dictionary(Of FederalStateCodesGermany, String)
#End Region

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
    Private Sub InitializeFederalStates()
      Me.FederalStatesDictionary.Add(FederalStateCodesGermany.BW, "Baden-Württemberg")
      Me.FederalStatesDictionary.Add(FederalStateCodesGermany.BY, "Bayern")
      Me.FederalStatesDictionary.Add(FederalStateCodesGermany.BE, "Berlin")
      Me.FederalStatesDictionary.Add(FederalStateCodesGermany.BB, "Brandenburg")
      Me.FederalStatesDictionary.Add(FederalStateCodesGermany.HB, "Bremen")
      Me.FederalStatesDictionary.Add(FederalStateCodesGermany.HH, "Hamburg")
      Me.FederalStatesDictionary.Add(FederalStateCodesGermany.HE, "Hessen")
      Me.FederalStatesDictionary.Add(FederalStateCodesGermany.MV, "Mecklenburg-Vorpommern")
      Me.FederalStatesDictionary.Add(FederalStateCodesGermany.NI, "Niedersachsen")
      Me.FederalStatesDictionary.Add(FederalStateCodesGermany.NW, "Nordrhein-Westfalen")
      Me.FederalStatesDictionary.Add(FederalStateCodesGermany.RP, "Rheinland-Pfalz")
      Me.FederalStatesDictionary.Add(FederalStateCodesGermany.SL, "Saarland")
      Me.FederalStatesDictionary.Add(FederalStateCodesGermany.SN, "Sachsen")
      Me.FederalStatesDictionary.Add(FederalStateCodesGermany.ST, "Sachsen-Anhalt")
      Me.FederalStatesDictionary.Add(FederalStateCodesGermany.SH, "Schleswig-Holstein")
      Me.FederalStatesDictionary.Add(FederalStateCodesGermany.TH, "Thüringen")
    End Sub

    Protected Overrides Sub InitializePublicHolidays()

      Me.Holidays.Clear()

      Dim federalStates = String.Empty

      With Me.Holidays
        AddFixedNotRegionalPublicDay(GetDateTime(1, 1), "Neujahr")

        federalStates = "Baden-Württemberg, Bayern, Sachsen-Anhalt"
        AddFixedRegionalPublicDay(GetDateTime(1, 6), "Heilige Drei Könige", federalStates)

        AddFixedNotRegionalPublicDay(GetDateTime(5, 1), "Tag der Arbeit")

        federalStates = "Bayern (teilweise), Saarland"
        AddFixedRegionalPublicDay(GetDateTime(8, 15), "Mariä Himmelfahrt", federalStates)

        AddFixedNotRegionalPublicDay(GetDateTime(10, 3), "Tag der dt. Einheit")

        If Me.CurrentYear = 2017 Then 'Zum 500. Jahrestag wurde 2017 der Reformationstag zu einem überregionalen Feiertag
          AddFixedNotRegionalPublicDay(GetDateTime(2017, 10, 31), "Reformationstag")
        Else
          federalStates = "Baden-Württemberg, Brandenburg, Mecklenburg-Vorpommern, Saarland, Sachsen-Anhalt, Thüringen"
          AddFixedRegionalPublicDay(GetDateTime(10, 31), "Reformationstag", federalStates)
        End If

        federalStates = "Baden-Württemberg, Bayern, Nordrhein-Westfalen, Rheinland-Pfalz, Saarland"
        AddFixedRegionalPublicDay(GetDateTime(11, 1), "Allerheiligen", federalStates)

        AddFixedNotRegionalPublicDay(GetDateTime(12, 25), "1. Weihnachtstag")

        AddFixedNotRegionalPublicDay(GetDateTime(12, 26), "2. Weihnachtstag")

        federalStates = "Bayern (ausschließlich im Stadtgebiet Augsburg)"
        AddFixedRegionalPublicDay(GetDateTime(8, 8), "Augsburger Friedensfest", federalStates)

        Dim easterSunday = GetEasterSunday()
        AddNotFixedNotRegionalPublicDay(easterSunday, "Ostersonntag")

        federalStates = "Baden-Württemberg"
        AddNotFixedRegionalPublicDay(easterSunday.AddDays(-3), "Gründonnerstag", federalStates)

        AddNotFixedNotRegionalPublicDay(easterSunday.AddDays(-2), "Karfreitag")

        AddNotFixedNotRegionalPublicDay(easterSunday.AddDays(1), "Ostermontag")

        AddNotFixedNotRegionalPublicDay(easterSunday.AddDays(39), "Christi Himmelfahrt")

        AddNotFixedNotRegionalPublicDay(easterSunday.AddDays(49), "Pfingstsonntag")

        AddNotFixedNotRegionalPublicDay(easterSunday.AddDays(50), "Pfingstmontag")

        federalStates = "Baden-Württemberg, Bayern, Hessen, Nordrhein-Westfalen, Rheinland-Pfalz ,Saarland, Sachsen (teilweise), Thüringen (teilweise)"
        AddNotFixedRegionalPublicDay(easterSunday.AddDays(60), "Fronleichnam", federalStates)

        federalStates = "Bayern, Sachsen"
        AddNotFixedRegionalPublicDay(GetBussUndBettag(Me.CurrentYear), "Buß- und Bettag", federalStates)
      End With
    End Sub

    Private Function GetBussUndBettag(ByVal year As Int32) As DateTime

      Dim validDate = New DateTime(year, 11, 23)
      Select Case validDate.DayOfWeek
        Case DayOfWeek.Monday
          validDate = validDate.AddDays(-5)
        Case DayOfWeek.Tuesday
          validDate = validDate.AddDays(-6)
        Case DayOfWeek.Wednesday
          validDate = validDate.AddDays(-7)
        Case DayOfWeek.Thursday
          validDate = validDate.AddDays(-1)
        Case DayOfWeek.Friday
          validDate = validDate.AddDays(-2)
        Case DayOfWeek.Saturday
          validDate = validDate.AddDays(-3)
        Case DayOfWeek.Sunday
          validDate = validDate.AddDays(-4)
      End Select

      Return validDate
    End Function
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Liefert die Feiertage eines Bundeslandes des gewählten Jahres.</summary>
    Public Function GetHolidaysByFederalState _
    (ByVal federalState As String) As List(Of IPublicHolidayItem)

      Dim result = Me.NotRegionalHolidays
      result.AddRange(Me.RegionalHolidays.Where(Function(x) x.Comment.Contains(federalState)))
      Return result
    End Function

    '''<summary>Liefert die Feiertage eines Bundeslandes des gewählten Jahres.</summary>
    Public Function GetHolidaysByFederalState _
    (ByVal federalStateCode As FederalStateCodesGermany) As List(Of IPublicHolidayItem)

      Return GetHolidaysByFederalState(Me.FederalStatesDictionary(federalStateCode))
    End Function
#End Region

  End Class

End Namespace
