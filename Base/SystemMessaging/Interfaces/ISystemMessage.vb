Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace SystemMessaging.Interfaces

	Public Interface ISystemMessage

		ReadOnly Property Sender As Object
		ReadOnly Property Data As Object
		ReadOnly Property MessageName As String

	End Interface

End Namespace
