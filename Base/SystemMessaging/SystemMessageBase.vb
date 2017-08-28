Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports BCW.Foundation.Base.SystemMessaging.Interfaces
#End Region

Namespace SystemMessaging

  Public Class SystemMessageBase

    Implements ISystemMessage

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal sender As Object, ByVal data As Object, ByVal messageName As String)
      Me.New(sender)
      Me.Data = data
    End Sub

    Public Sub New(ByVal sender As Object, ByVal data As Object)
      Me.New(sender)
      Me.Data = data
    End Sub

    Public Sub New(ByVal sender As Object)
      Me.Sender = sender
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public ReadOnly Property Sender As Object Implements ISystemMessage.Sender

    Public ReadOnly Property Data As Object Implements ISystemMessage.Data

    Public ReadOnly Property MessageName As String Implements ISystemMessage.MessageName
      Get
        Return Me.GetType.Name
      End Get
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
