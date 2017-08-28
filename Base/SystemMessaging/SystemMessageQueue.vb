Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Reflection
Imports BCW.Foundation.Base.SystemMessaging.Interfaces
#End Region

Namespace SystemMessaging

	'''<summary>
	'''	Public Sub New(ByVal name As String)
	'''
	'''	MessageQueue.Instance.AddSubscriber(Of CommonSystemMessage) _
	'''	(Me, AddressOf OnCommonSystemMessageArrived)
	'''End Sub
	'''
	'''Private Sub OnCommonSystemMessageArrived(ByVal message As ISystemMessage)
	'''		Console.WriteLine(message.MessageName)
	'''End Sub
	'''</summary>
	Public NotInheritable Class SystemMessageQueue

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Shared Sub New()
			_instance = New SystemMessageQueue
			AddMessageTypes()
		End Sub

		Private Sub New()
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Shared ReadOnly Property Instance As New SystemMessageQueue

    Private Shared ReadOnly Property Messages As New Dictionary(Of Type, Subscribers)
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Shared Sub AddMessageTypes()

			GetAllAssemblies.ForEach(Sub(ass) ass.GetTypes.ToList.Where _
			(Function(x) GetType(ISystemMessage).IsAssignableFrom(x)).ToList.ForEach _
			(Sub(x) AddMessageType(x)))

			_messages.Remove(GetType(ISystemMessage))
		End Sub

		Private Shared Function GetAllAssemblies() As List(Of Assembly)
			Return AppDomain.CurrentDomain.GetAssemblies.ToList
		End Function

		Private Shared Sub AddMessageType(ByVal messageType As Type)

			Dim subscribers = New Subscribers
			_messages.Add(messageType, subscribers)
		End Sub

    Private Function GetMessageSubscribers(Of TMessage As {ISystemMessage})() As Subscribers
      Return _Messages.Item(GetType(TMessage))
    End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>
    '''Fügt den Beobachter subscriber der SystemMessage TMessage hinzu 
    '''und legt die CallBack-Methode messageArrivedAction fest.
    '''</summary>
    Public Sub AddSubscriber(Of TMessage As {ISystemMessage}) _
    (ByVal subscriber As Object, ByVal messageArrivedAction As Action(Of ISystemMessage))

      Dim info = New SubscriberInfo(subscriber, messageArrivedAction)
      GetMessageSubscribers(Of TMessage).Add(info)
    End Sub

    '''<summary>Entfernt den Beobachter subscriber der SystemMessage TMessage.</summary>
    Public Sub RemoveSubscriber(Of TMessage As {ISystemMessage})(ByVal subscriber As Object)

			Dim item = GetMessageSubscribers(Of TMessage).FirstOrDefault(Function(x) x.Subscriber Is subscriber)
			GetMessageSubscribers(Of TMessage).Remove(item)
		End Sub

		'''<summary>Wirft die SystemMessage message und ruft die CallBack-Methode der Beobachter auf.</summary>
		Public Sub SendSystemMessage(ByVal message As ISystemMessage)

      Messages.Item(message.GetType).ForEach(Sub(x) x.MessageArrivedAction.Invoke(message))
    End Sub

		'''<summary>Liefert eine Collection der registrierten SystemMessage-Typen.</summary>
		Public Function GetAddedMessageTypes() As IReadOnlyCollection(Of Type)

      Return Messages.Keys.ToList.AsReadOnly
    End Function

    '''<summary>Liefert eine Colection aller Beobachter der SystemMessage TMessage.</summary>
    Public Function GetAddedSubscribers(Of TMessage As {ISystemMessage})() As IReadOnlyCollection(Of Object)

      Return GetMessageSubscribers(Of TMessage).Select(Function(x) x.Subscriber).ToList.AsReadOnly()
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
