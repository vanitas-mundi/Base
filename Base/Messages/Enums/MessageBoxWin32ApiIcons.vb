Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Messages.Enums

	Public Enum MessageBoxWin32ApiIcons
		'''<summary>Zeigt kein Icon in der MessageBox an.</summary>
		None = 0
		'''<summary>Zeigt ein Fragezeichen-Icon in der MessageBox an.</summary>
		Question = 32 '&H20
		'''<summary>Zeigt ein Ausrufezeichen-Icon in der MessageBox an.</summary>
		Exclamation = 48 '&H30
		'''<summary>Zeigt ein Informations-Icon in der MessageBox an.</summary>
		Information = 64 '&H40
		'''<summary>Zeigt ein Fehler-Icon in der MessageBox an.</summary>
		[Error] = 16 '&H10

		'Asterisk = Information
		'Warning = Exclamation

		'Hand = [Error]
		'IconStop = [Error]
		'UserIcon = 128 '&H80
	End Enum

End Namespace
