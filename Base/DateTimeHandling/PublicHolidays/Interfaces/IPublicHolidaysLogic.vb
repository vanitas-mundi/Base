Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.StringHandling
#End Region

Namespace DateTimeHandling.PublicHolidays.Interfaces

  Public Interface IPublicHolidaysLogic

    ReadOnly Property CultureCode As CultureCodes

    '''<summary>Liefert das gewählte Betrachtungsjahr.</summary>
    ReadOnly Property CurrentYear As Int32

    '''<summary>Liefert alle Feiertage des gewählten Jahres.</summary>
    ReadOnly Property Holidays As List(Of IPublicHolidayItem)

    '''<summary>Liefert alle beweglichen Feiertage des gewählten Jahres.</summary>
    ReadOnly Property FloatingHolidays() As List(Of IPublicHolidayItem)

    '''<summary>Liefert alle fixen Feiertage des gewählten Jahres.</summary>
    ReadOnly Property FixedHolidays() As List(Of IPublicHolidayItem)

    '''<summary>Liefert alle regionalen Feiertage des gewählten Jahres.</summary>
    ReadOnly Property RegionalHolidays() As List(Of IPublicHolidayItem)

    '''<summary>Liefert alle nicht regionalen Feiertage des gewählten Jahres.</summary>
    ReadOnly Property NotRegionalHolidays() As List(Of IPublicHolidayItem) _

    '''<summary>Liefert das IPublicHolidayItem zum angegebenen Datum validDate.</summary>
    ReadOnly Property Item(ByVal validDate As DateTime) As IPublicHolidayItem

    '''<summary>Prüft ob das übergebene Datum ein Feiertag ist.</summary>
    ReadOnly Property IsPublicHoliday(ByVal validDate As DateTime) As Boolean

    '''<summary>Ermittelt den Namen des Feiertages, des angegebenen Datums.</summary>
    ReadOnly Property PublicHolidayName(ByVal validDate As DateTime) As IPublicHolidayItem

    '''<summary>Initialisiert die Feiertage des angegebenen Jahres</summary>
    Sub Initialize(ByVal year As Int32)
  End Interface

End Namespace

