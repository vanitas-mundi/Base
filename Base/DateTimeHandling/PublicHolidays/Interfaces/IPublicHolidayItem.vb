Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace DateTimeHandling.PublicHolidays.Interfaces

  Public Interface IPublicHolidayItem

    ReadOnly Property Name() As String

    ReadOnly Property Comment() As String

    ReadOnly Property IsRegional() As Boolean

    ReadOnly Property ValidDate() As DateTime

    ReadOnly Property IsFix() As Boolean

    ReadOnly Property FederalStates As String()
  End Interface

End Namespace

