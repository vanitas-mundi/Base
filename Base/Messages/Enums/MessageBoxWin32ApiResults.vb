Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Messages.Enums

	Public Enum MessageBoxWin32ApiResults
		'''<summary>OK wurde geklickt.</summary>
		Ok = 1
		'''<summary>Abbrechen wurde geklickt.</summary>
		Cancel = 2
		Abort = 3
		'''<summary>Wiederholen wurde geklickt.</summary>
		Retry = 4
		'''<summary>Ignorieren wurde geklickt.</summary>
		Ignore = 5
		'''<summary>Ja wurde geklickt.</summary>
		Yes = 6
		'''<summary>Nein wurde geklickt.</summary>
		No = 7
		'''<summary>Schließen wurde geklickt.</summary>
		Close = 8
		'''<summary>Hilfe wurde geklickt.</summary>
		Help = 9
		'''<summary>Neu versuchen wurde geklickt.</summary>
		TryAgain = 10
		'''<summary>Weiter wurde geklickt.</summary>
		[Continue] = 11
		'''<summary>Es ist ein TImeout aufgetreten.</summary>
		Timeout = 32000
	End Enum

End Namespace
