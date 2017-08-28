Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Messages.Enums

	Public Enum MessageBoxWin32ApiDefaultButtons
		'''<summary>Legt die erste Schaltfläche als Standard-Schaltfläche fest.</summary>
		Button1 = 0 '&H0
		'''<summary>Legt die zweite Schaltfläche als Standard-Schaltfläche fest.</summary>
		Button2 = 256 '&H100
		'''<summary>Legt die dritte Schaltfläche als Standard-Schaltfläche fest.</summary>
		Button3 = 512 '&H200
		'''<summary>Legt die vierte Schaltfläche als Standard-Schaltfläche fest.</summary>
		Button4 = 768 '&H300
	End Enum

End Namespace
