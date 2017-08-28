Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Messages.Enums

	Friend Enum MessageBoxWin32ApiOptions
		'''<summary>Zeigt die MessageBox für den ausführenden Task modal an.</summary>
		TaskModal = 8192 '&H2000

		'ApplicationModal = 0 '&H0
		'SystemModal = 4096 '&H1000
		'ShowHelpButton = 16384 '&H4000
		'NoFocus = 32768 '&H8000
		'SetForeground = 65536 '&H10000
		'DefaultDesktopOnly = 131072 '&H20000
		'Topmost = 262144 '&H40000
		'Right = 524288 '&H80000
		'RTLReading = 1048576 '&H100000
	End Enum

End Namespace
