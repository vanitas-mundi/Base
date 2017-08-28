Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Reflection
#End Region

Namespace Events

  Public Class EventHandlerManager

#Region " --------------->> Enumerationen der Klasse "
    Private Enum EventHandlerAccessMethods
      AddMethod
      RemoveMethod
    End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Private _eventHandlersDictionary As New Dictionary(Of Object, List(Of EventHandlerInfo))
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Private Sub New()
    End Sub

    Shared Sub New()
      Instance = New EventHandlerManager
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Shared ReadOnly Property Instance As EventHandlerManager

    '''<summary>Liefert die Anzahl der unterschiedlichen verwalteten Callback-Objekte</summary>
    Public ReadOnly Property CallbackObjectCount As Int32
      Get
        Return _eventHandlersDictionary.Keys.Count
      End Get
    End Property

    Public ReadOnly Property CallbackObjects As Object()
      Get
        Return _eventHandlersDictionary.Keys.ToArray
      End Get
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Function GetEventHandlerInfoListByKey _
    (ByVal callbackObject As Object) As List(Of EventHandlerInfo)

      With _eventHandlersDictionary
        Return If(.Keys.Contains(callbackObject), .Item(callbackObject), Nothing)
      End With
    End Function

    Private Function ExistsInEventHandlersDictionary _
    (ByVal eventHandlerInfo As EventHandlerInfo) As Boolean

      With eventHandlerInfo
        Dim list = GetEventHandlerInfoListByKey(.CallbackObject)
        Return (list IsNot Nothing) AndAlso (list.Any(Function(x) x.IsEqual(eventHandlerInfo)))
      End With
    End Function

    Private Sub UpdateEventHandlersDictionary _
    (ByVal eventHandlerInfo As EventHandlerInfo _
    , ByVal method As EventHandlerAccessMethods)

      With eventHandlerInfo
        Select Case method
          Case EventHandlerAccessMethods.AddMethod
            If Not _eventHandlersDictionary.Keys.Contains(.CallbackObject) Then
              _eventHandlersDictionary.Add(.CallbackObject, New List(Of EventHandlerInfo))
            End If
            _eventHandlersDictionary.Item(.CallbackObject).Add(eventHandlerInfo)
          Case EventHandlerAccessMethods.RemoveMethod
            Dim list = GetEventHandlerInfoListByKey(.CallbackObject)
            Dim info = list.FirstOrDefault(Function(x) x.IsEqual(eventHandlerInfo))

            list.Remove(info)
            If list.Count = 0 Then _eventHandlersDictionary.Remove(.CallbackObject)
          Case Else
            Return
        End Select
      End With
    End Sub

    Private Sub EditEventHandler _
    (ByVal eventHandlerInfo As EventHandlerInfo _
    , ByVal method As EventHandlerAccessMethods)

      With eventHandlerInfo
        Dim eventInfo = .EventObject.GetType.GetEvent(.EventName)

        Dim eventHandlerMethodInfo As MethodInfo = Nothing
        Select Case method
          Case EventHandlerAccessMethods.AddMethod
            eventHandlerMethodInfo = eventInfo.GetAddMethod
          Case EventHandlerAccessMethods.RemoveMethod
            eventHandlerMethodInfo = eventInfo.GetRemoveMethod
          Case Else
            Return
        End Select

        Dim eventHandlerType = eventInfo.EventHandlerType

        Dim flags = BindingFlags.Static Or BindingFlags.Public _
        Or BindingFlags.NonPublic Or BindingFlags.Instance

        Dim callbackMethodInfo = .CallbackObject.GetType.GetMethod _
        (.CallbackMethodName, flags)

        Dim eventHandlerDelegate = System.Delegate.CreateDelegate _
        (eventHandlerType, .CallbackObject, callbackMethodInfo)

        eventHandlerMethodInfo.Invoke _
        (.EventObject, New Object() {eventHandlerDelegate})

        UpdateEventHandlersDictionary(eventHandlerInfo, method)
      End With
    End Sub

    Private Sub EditEventHandlerIfNecessary _
    (ByVal eventHandlerInfo As EventHandlerInfo _
    , ByVal method As EventHandlerAccessMethods)

      Select Case True
        Case (method = EventHandlerAccessMethods.AddMethod) _
        AndAlso (ExistsInEventHandlersDictionary(eventHandlerInfo))
          Return
        Case (method = EventHandlerAccessMethods.RemoveMethod) _
        AndAlso (Not ExistsInEventHandlersDictionary(eventHandlerInfo))
          Return
        Case Else
          EditEventHandler(eventHandlerInfo, method)
      End Select
    End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "

    '''<summary>
    '''Liefert die Anzahl der verwalteten Callback-Methoden
    '''zum angegebenen callbackObject.
    '''</summary>
    Public Function EventHandlerCount(ByVal callbackObject As Object) As Int32

      Dim list = GetEventHandlerInfoListByKey(callbackObject)
      Return If(list Is Nothing, 0, list.Count)
    End Function

    '''<summary>Legt einen Eventhandler, zur angegebenen eventHandlerInfo, an.</summary>
    Public Sub AddEventHandler(ByVal eventHandlerInfo As EventHandlerInfo)

      EditEventHandlerIfNecessary(eventHandlerInfo, EventHandlerAccessMethods.AddMethod)
    End Sub

    '''<summary>Legt einen Eventhandler, zu den angegebenen Parametern, an.</summary>
    Public Sub AddEventHandler _
    (ByVal eventObject As Object _
    , ByVal eventName As String _
    , ByVal callbackObject As Object _
    , ByVal callbackMethodName As String)

      EditEventHandlerIfNecessary(New EventHandlerInfo _
      (eventObject, eventName _
      , callbackObject, callbackMethodName) _
      , EventHandlerAccessMethods.AddMethod)
    End Sub

    '''<summary>Entfernt den Eventhandler zur angegebenen eventHandlerInfo.</summary>
    Public Sub RemoveEventHandler(ByVal eventHandlerInfo As EventHandlerInfo)

      EditEventHandlerIfNecessary(eventHandlerInfo, EventHandlerAccessMethods.RemoveMethod)
    End Sub

    '''<summary>Entfernt den Eventhandler zu den angegebenen Parametern.</summary>
    Public Sub RemoveEventHandler _
    (ByVal eventObject As Object _
    , ByVal eventName As String _
    , ByVal callbackObject As Object _
    , ByVal callbackMethodName As String)

      EditEventHandlerIfNecessary(New EventHandlerInfo _
      (eventObject, eventName _
      , callbackObject, callbackMethodName) _
      , EventHandlerAccessMethods.RemoveMethod)
    End Sub

    '''<summary>Entfernt alle EventHandler zum angegebenen CallBack-Objekt.</summary>
    Public Sub RemoveAtCallbackObjectDispose(ByVal callbackObject As Object)

      Dim list = GetEventHandlerInfoListByKey(callbackObject)
      If list Is Nothing Then Return

      For i = list.Count - 1 To 0 Step -1
        Dim item = list.Item(i)
        Me.RemoveEventHandler(item)
      Next i
    End Sub

#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
