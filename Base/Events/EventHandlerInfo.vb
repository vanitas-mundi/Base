Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Events

  Public Class EventHandlerInfo

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New _
    (ByVal eventObject As Object _
    , ByVal eventName As String _
    , ByVal callbackObject As Object _
    , ByVal callbackMethodName As String)

      Me.EventObject = eventObject
      Me.EventName = eventName
      Me.CallbackObject = callbackObject
      Me.CallbackMethodName = callbackMethodName
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public ReadOnly Property EventObject As Object
    Public ReadOnly Property EventName As String
    Public ReadOnly Property CallbackObject As Object
    Public ReadOnly Property CallbackMethodName As String
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>
    '''Liefert true, wenn die Werte der Eigenschaften von eventHandlerInfo
    '''den Werten der Instanz-Eigenschaften entsprechen.
    '''</summary>
    Public Function IsEqual(ByVal eventHandlerInfo As EventHandlerInfo) As Boolean
      With eventHandlerInfo
        Return (Me.EventObject Is .EventObject) _
        AndAlso (Me.EventName = .EventName) _
        AndAlso (Me.CallbackObject Is .CallbackObject) _
        AndAlso (Me.CallbackMethodName = .CallbackMethodName)
      End With
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
