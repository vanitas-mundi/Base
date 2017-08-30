Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports BCW.Foundation.Base.DateTimeHandling.PublicHolidays
Imports BCW.Foundation.Base.DateTimeHandling.PublicHolidays.Interfaces
Imports BCW.Foundation.Base.StringHandling
#End Region

Namespace DateTimeHandling

  Public Class DateTimePublicHolidays

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Private _logicDictionary As New Dictionary(Of CultureCodes, IPublicHolidaysLogic)
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
      InititialzePublicHolidaysLogic()
    End Sub

    Private Sub InititialzePublicHolidaysLogic()
      Dim [namespace] = GetType(WeekDayNamesHelperBase).Namespace
      Dim publicHolidaysLogicBaseType = GetType(PublicHolidaysLogicBase)

      Dim appTypes = My.Application.GetType.Assembly.GetTypes

      Dim publicHolidaysLogics = appTypes.Where _
      (Function(x) (x.Namespace IsNot Nothing) _
      AndAlso (x.Namespace.StartsWith([namespace])) _
      AndAlso (x.BaseType Is publicHolidaysLogicBaseType)).Select _
      (Function(x) DirectCast(Activator.CreateInstance(x), IPublicHolidaysLogic)).ToList

      publicHolidaysLogics.ForEach(Sub(x) _logicDictionary.Add(x.CultureCode, x))
    End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>
    '''Initialisiert die Feiertage des angegebenen Jahres.
    '''Alternativ kann Logic.Initialize aufgerufen werden.
    '''</summary>
    Public Sub InitializeLogic(ByVal year As Int32)
      Me.Logic.Initialize(year)
    End Sub

    '''<summary>Liefert die Feiertage zum im DateTimeHelper hinterlegten CultureCode.</summary>
    Public Function Logic() As IPublicHolidaysLogic
      Return Logic(Helper.DateTime.CultureCode)
    End Function

    '''<summary>Liefert die Feiertage zum angegebenen CultureCode.</summary>
    Public Function Logic(ByVal cultureCode As CultureCodes) As IPublicHolidaysLogic
      With _logicDictionary
        Return If(.ContainsKey(cultureCode), .Item(cultureCode), .Item(CultureCodes.de_DE))
      End With
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace