Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.StringHandling
#End Region

Namespace DateTimeHandling.Interfaces

  Public Interface IMonthNamesHelper

    ReadOnly Property CultureCode As CultureCodes

    ReadOnly Property January As String
    ReadOnly Property February As String
    ReadOnly Property March As String
    ReadOnly Property April As String
    ReadOnly Property May As String
    ReadOnly Property June As String
    ReadOnly Property July As String
    ReadOnly Property August As String
    ReadOnly Property September As String
    ReadOnly Property October As String
    ReadOnly Property November As String
    ReadOnly Property December As String

    ReadOnly Property JanuaryShort As String
    ReadOnly Property FebruaryShort As String
    ReadOnly Property MarchShort As String
    ReadOnly Property AprilShort As String
    ReadOnly Property MayShort As String
    ReadOnly Property JuneShort As String
    ReadOnly Property JulyShort As String
    ReadOnly Property AugustShort As String
    ReadOnly Property SeptemberShort As String
    ReadOnly Property OctoberShort As String
    ReadOnly Property NovemberShort As String
    ReadOnly Property DecemberShort As String

    Function GetMonthNameByIndex(ByVal monthIndex As Byte) As String
    Function GetMonthNameShortByIndex(ByVal monthIndex As Byte) As String
  End Interface

End Namespace
