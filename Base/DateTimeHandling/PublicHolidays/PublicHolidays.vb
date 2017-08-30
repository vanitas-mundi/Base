Option Strict On
Option Infer On
Option Explicit On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.DateTimeHandling.PublicHolidays.Interfaces
#End Region

Namespace DateTimeHandling.PublicHolidays

  Public Class PublicHolidayItem

    Implements IPublicHolidayItem
    Implements IComparable(Of PublicHolidayItem)


#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New _
    (ByVal validDate As DateTime _
    , ByVal name As String _
    , ByVal comment As String _
    , ByVal isFix As Boolean _
    , ByVal isRegional As Boolean)

      Me.ValidDate = validDate
      Me.Name = name
      Me.Comment = comment
      Me.IsFix = isFix
      Me.IsRegional = isRegional
    End Sub

#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public ReadOnly Property Name() As String Implements IPublicHolidayItem.Name

    Public ReadOnly Property Comment() As String Implements IPublicHolidayItem.Comment

    Public ReadOnly Property IsRegional() As Boolean Implements IPublicHolidayItem.IsRegional

    Public ReadOnly Property ValidDate() As DateTime Implements IPublicHolidayItem.ValidDate

    Public ReadOnly Property IsFix() As Boolean Implements IPublicHolidayItem.IsFix

    Public ReadOnly Property FederalStates As String() Implements IPublicHolidayItem.FederalStates
      Get
        Return Me.Comment.Split(","c).Select(Function(x) x.Trim).ToArray
      End Get
    End Property
#End Region

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Overloads Overrides Function ToString() As String
      Return Me.ToString(False)
    End Function

    Public Overloads Function ToString(ByVal showValidDate As Boolean) As String
      If showValidDate Then
        Return $"{Helper.DateTime.Format.ToYMD(Me.ValidDate)} - {Me.Name}"
      Else
        Return $"{Me.Name}"
      End If
    End Function

    Public Function CompareTo(ByVal other As PublicHolidayItem) As Int32 _
    Implements IComparable(Of PublicHolidayItem).CompareTo

      Return _ValidDate.Date.CompareTo(other.ValidDate.Date)
    End Function
#End Region

  End Class

End Namespace