Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Messages.Enums

	Public Enum MessageBoxWin32ApiYesNoDefaultButtons
		'''<summary>Legt Ja-Schaltfläche als Standard-Schaltfläche fest.</summary>
		YesButton = 0 '&H0
		'''<summary>Legt Nein-Schaltfläche als Standard-Schaltfläche fest.</summary>
		NoButton = 256 '&H100
	End Enum

End Namespace
