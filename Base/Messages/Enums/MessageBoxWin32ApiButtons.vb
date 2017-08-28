Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Messages.Enums

	Public Enum MessageBoxWin32ApiButtons
		'''<summary>Zeigt eine OK-Schaltfläche in der MessageBox an.</summary>
		Ok = 0 '&H0
		'''<summary>Zeigt eine OK- und Abbrechen-Schaltfläche in der MessageBox an.</summary>
		OkCancel = 1 '&H1
		'''<summary></summary>
		AbortRetryIgnore = 2 '&H2
		'''<summary>Zeigt eine Ja-, Nein- und Abbrechen-Schaltfläche in der MessageBox an.</summary>
		YesNoCancel = 3 '&H3
		'''<summary>Zeigt eine Ja- und Nein-Schaltfläche in der MessageBox an.</summary>
		YesNo = 4 '&H4
		'''<summary>Zeigt eine Wiederholen- und Abbrechen-Schaltfläche in der MessageBox an.</summary>
		RetryCancel = 5 '&H5
		'''<summary></summary>
		CancelTryContinue = 6 '&H6
	End Enum

End Namespace
