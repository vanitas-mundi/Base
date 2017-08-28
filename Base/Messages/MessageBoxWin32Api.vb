Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports BCW.Foundation.Base.Messages.Enums
#End Region

Namespace Messages

	Public NotInheritable Class MessageBoxWin32Api

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Declare Auto Function MessageBox Lib "user32.dll" Alias "MessageBox" _
		(hWnd As IntPtr, text As String, caption As String _
		, options As Int32) As MessageBoxWin32ApiResults

		Private Shared _show As MessageBoxWin32Api
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Private Sub New()
		End Sub

		Shared Sub New()
			_show = New MessageBoxWin32Api
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Shared ReadOnly Property Show As MessageBoxWin32Api
			Get
				Return _show
			End Get
		End Property
		Private ReadOnly Property CurrentAssemblyName As String
			Get
				Return My.Application.Info.AssemblyName
			End Get
		End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
		Private Function YesNoDefaultButtonToDefaultButton _
		(ByVal defaultButton As MessageBoxWin32ApiYesNoDefaultButtons) _
		As MessageBoxWin32ApiDefaultButtons

			Return If(defaultButton = MessageBoxWin32ApiYesNoDefaultButtons.YesButton _
			, MessageBoxWin32ApiDefaultButtons.Button1, MessageBoxWin32ApiDefaultButtons.Button2)
		End Function

		Private Function GetSpecialMessageBoxCaption _
		(ByVal defaultCaption As String) As String

			Return String.Format(defaultCaption, CurrentAssemblyName)
		End Function

		Private Function GetSpecialMessageBoxCaption _
		(ByVal defaultCaption As String, ByVal caption As String) As String

			Return String.Format(defaultCaption, caption)
		End Function

#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "

#Region " Message Overloads "
		'''<summary>Zeigt eine benutzerdefinierte MessageBox.</summary>
		Public Function Message _
		(ByVal text As String, ByVal caption As String _
		, ByVal buttons As MessageBoxWin32ApiButtons _
		, ByVal icon As MessageBoxWin32ApiIcons _
		, ByVal defaultButton As MessageBoxWin32ApiDefaultButtons) _
		As MessageBoxWin32ApiResults

			Dim options = buttons + icon + defaultButton + MessageBoxWin32ApiOptions.TaskModal
			Return MessageBox(IntPtr.Zero, text, caption, options)
		End Function

		'''<summary>Zeigt eine benutzerdefinierte MessageBox.</summary>
		Public Function Message _
		(ByVal text As String, ByVal caption As String _
		, ByVal buttons As MessageBoxWin32ApiButtons _
		, ByVal icon As MessageBoxWin32ApiIcons) _
		As MessageBoxWin32ApiResults

			Return Message(text, caption, buttons, icon, MessageBoxWin32ApiDefaultButtons.Button1)
		End Function

		'''<summary>Zeigt eine benutzerdefinierte MessageBox.</summary>
		Public Function Message _
		(ByVal text As String, ByVal caption As String _
		, ByVal buttons As MessageBoxWin32ApiButtons _
		, ByVal defaultButton As MessageBoxWin32ApiDefaultButtons) _
		As MessageBoxWin32ApiResults

			Return Message(text, caption, buttons, MessageBoxWin32ApiIcons.None, defaultButton)
		End Function

		'''<summary>Zeigt eine benutzerdefinierte MessageBox.</summary>
		Public Function Message _
		(ByVal text As String, ByVal caption As String _
		, ByVal buttons As MessageBoxWin32ApiButtons) _
		As MessageBoxWin32ApiResults

			Return Message(text, caption, buttons _
			, MessageBoxWin32ApiIcons.None, MessageBoxWin32ApiDefaultButtons.Button1)
		End Function

		'''<summary>Zeigt eine benutzerdefinierte MessageBox.</summary>
		Public Function Message _
		(ByVal text As String _
		, ByVal buttons As MessageBoxWin32ApiButtons _
		, ByVal icon As MessageBoxWin32ApiIcons _
		, ByVal defaultButton As MessageBoxWin32ApiDefaultButtons) _
		As MessageBoxWin32ApiResults

			Return Message(text, My.Application.Info.AssemblyName, buttons, icon, defaultButton)
		End Function

		'''<summary>Zeigt eine benutzerdefinierte MessageBox.</summary>
		Public Function Message _
		(ByVal text As String _
		, ByVal buttons As MessageBoxWin32ApiButtons _
		, ByVal icon As MessageBoxWin32ApiIcons) _
		As MessageBoxWin32ApiResults

			Return Message(text, My.Application.Info.AssemblyName _
			, buttons, icon, MessageBoxWin32ApiDefaultButtons.Button1)
		End Function

		'''<summary>Zeigt eine benutzerdefinierte MessageBox.</summary>
		Public Function Message _
		(ByVal text As String _
		, ByVal buttons As MessageBoxWin32ApiButtons _
		, ByVal defaultButton As MessageBoxWin32ApiDefaultButtons) _
		As MessageBoxWin32ApiResults

			Return Message(text, My.Application.Info.AssemblyName, buttons _
			, MessageBoxWin32ApiIcons.None, defaultButton)
		End Function

		'''<summary>Zeigt eine benutzerdefinierte MessageBox.</summary>
		Public Function Message _
		(ByVal text As String _
		, ByVal buttons As MessageBoxWin32ApiButtons) _
		As MessageBoxWin32ApiResults

			Return Message(text, My.Application.Info.AssemblyName _
			, buttons, MessageBoxWin32ApiIcons.None, MessageBoxWin32ApiDefaultButtons.Button1)
		End Function

		'''<summary>Zeigt eine benutzerdefinierte MessageBox.</summary>
		Public Function Message _
		(ByVal text As String, ByVal caption As String _
		, ByVal icon As MessageBoxWin32ApiIcons) _
		As MessageBoxWin32ApiResults

			Return Message(text, caption, MessageBoxWin32ApiButtons.Ok _
			, icon, MessageBoxWin32ApiDefaultButtons.Button1)
		End Function

		'''<summary>Zeigt eine benutzerdefinierte MessageBox.</summary>
		Public Function Message _
		(ByVal text As String, ByVal caption As String) _
		As MessageBoxWin32ApiResults

			Return Message(text, caption, MessageBoxWin32ApiButtons.Ok _
			, MessageBoxWin32ApiIcons.None, MessageBoxWin32ApiDefaultButtons.Button1)
		End Function

		'''<summary>Zeigt eine benutzerdefinierte MessageBox.</summary>
		Public Function Message _
		(ByVal text As String _
		, ByVal icon As MessageBoxWin32ApiIcons) _
		As MessageBoxWin32ApiResults

			Return Message(text, My.Application.Info.AssemblyName _
			, MessageBoxWin32ApiButtons.Ok, icon, MessageBoxWin32ApiDefaultButtons.Button1)
		End Function

		'''<summary>Zeigt eine benutzerdefinierte MessageBox.</summary>
		Public Function Message(ByVal text As String) As MessageBoxWin32ApiResults

			Return Message(text, My.Application.Info.AssemblyName, MessageBoxWin32ApiButtons.Ok _
			, MessageBoxWin32ApiIcons.None, MessageBoxWin32ApiDefaultButtons.Button1)
		End Function
#End Region

#Region " Question Overloads "
		'''<summary>Zeigt eine Frage-MessageBox mit Ja-Nein-Schaltflächen.</summary>
		Public Function Question(ByVal text As String) As MessageBoxWin32ApiResults
			Return Message(text, GetSpecialMessageBoxCaption(My.Settings.MessageBoxWin32ApiQuestionCaption) _
			, MessageBoxWin32ApiButtons.YesNo, MessageBoxWin32ApiIcons.Question)
		End Function

		'''<summary>Zeigt eine Frage-MessageBox mit Ja-Nein-Schaltflächen.</summary>
		Public Function Question _
		(ByVal text As String _
		, ByVal caption As String) _
		As MessageBoxWin32ApiResults

			Return Message(text, GetSpecialMessageBoxCaption _
			(My.Settings.MessageBoxWin32ApiQuestionCaption, caption) _
			, MessageBoxWin32ApiButtons.YesNo, MessageBoxWin32ApiIcons.Question)
		End Function

		'''<summary>Zeigt eine Frage-MessageBox mit Ja-Nein-Schaltflächen.</summary>
		Public Function Question _
		(ByVal text As String _
		, ByVal defaultButton As MessageBoxWin32ApiYesNoDefaultButtons) _
		As MessageBoxWin32ApiResults

			Return Message(text, GetSpecialMessageBoxCaption(My.Settings.MessageBoxWin32ApiQuestionCaption) _
			, MessageBoxWin32ApiButtons.YesNo, MessageBoxWin32ApiIcons.Question _
			, YesNoDefaultButtonToDefaultButton(defaultButton))
		End Function

		'''<summary>Zeigt eine Frage-MessageBox mit Ja-Nein-Schaltflächen.</summary>
		Public Function Question _
		(ByVal text As String _
		, ByVal caption As String _
		, ByVal defaultButton As MessageBoxWin32ApiYesNoDefaultButtons) _
		As MessageBoxWin32ApiResults

			Return Message(text, GetSpecialMessageBoxCaption _
			(My.Settings.MessageBoxWin32ApiQuestionCaption, caption) _
			, MessageBoxWin32ApiButtons.YesNo, MessageBoxWin32ApiIcons.Question _
			, YesNoDefaultButtonToDefaultButton(defaultButton))
		End Function
#End Region

#Region " Information Overloads "
		'''<summary>Zeigt eine Informations-MessageBox mit einer OK-Schaltfläche.</summary>
		Public Sub Information(ByVal text As String)
			Message(text, GetSpecialMessageBoxCaption(My.Settings.MessageBoxWin32ApiInformationCaption) _
			, MessageBoxWin32ApiButtons.Ok, MessageBoxWin32ApiIcons.Information)
		End Sub

		'''<summary>Zeigt eine Informations-MessageBox mit einer OK-Schaltfläche.</summary>
		Public Sub Information(ByVal text As String, ByVal caption As String)

			Message(text, GetSpecialMessageBoxCaption _
			(My.Settings.MessageBoxWin32ApiInformationCaption, caption) _
			, MessageBoxWin32ApiButtons.Ok, MessageBoxWin32ApiIcons.Information)
		End Sub
#End Region

#Region " Exclamation Overloads "
		'''<summary>Zeigt eine Warnungs-MessageBox mit einer OK-Schaltfläche.</summary>
		Public Sub Exclamation(ByVal text As String)

			Message(text, GetSpecialMessageBoxCaption(My.Settings.MessageBoxWin32ApiExclamationCaption) _
			, MessageBoxWin32ApiButtons.Ok, MessageBoxWin32ApiIcons.Exclamation)
		End Sub

		'''<summary>Zeigt eine Warnungs-MessageBox mit einer OK-Schaltfläche.</summary>
		Public Sub Exclamation(ByVal text As String, ByVal caption As String)

			Message(text, GetSpecialMessageBoxCaption _
			(My.Settings.MessageBoxWin32ApiExclamationCaption, caption) _
			, MessageBoxWin32ApiButtons.Ok, MessageBoxWin32ApiIcons.Exclamation)
		End Sub
#End Region

#Region " Error Overloads "
		'''<summary>Zeigt eine Fehler-MessageBox mit einer OK-Schaltfläche.</summary>
		Public Sub [Error](ByVal text As String)
			Message(text, GetSpecialMessageBoxCaption(My.Settings.MessageBoxWin32ApiErrorCaption) _
			, MessageBoxWin32ApiButtons.Ok, MessageBoxWin32ApiIcons.Error)
		End Sub

		'''<summary>Zeigt eine Fehler-MessageBox mit einer OK-Schaltfläche.</summary>
		Public Sub [Error](ByVal text As String, ByVal caption As String)
			Message(text, GetSpecialMessageBoxCaption(My.Settings.MessageBoxWin32ApiErrorCaption, caption) _
			, MessageBoxWin32ApiButtons.Ok, MessageBoxWin32ApiIcons.Error)
		End Sub

		'''<summary>
		'''Zeigt eine Fehler-MessageBox mit einer OK-Schaltfläche.
		'''Zusätzlich wird die Message-Eigenschaft des übergebenen Exception-Objektes angezeigt
		'''</summary>
		Public Sub [Error](ByVal ex As Exception)
			[Error](ex, False)
		End Sub

		'''<summary>
		'''Zeigt eine Fehler-MessageBox mit einer OK-Schaltfläche.
		'''Zusätzlich wird die Message-Eigenschaft des übergebenen Exception-Objektes angezeigt
		'''</summary>
		Public Sub [Error](ByVal text As String, ByVal ex As Exception)
			[Error](text, ex, False)
		End Sub

		'''<summary>
		'''Zeigt eine Fehler-MessageBox mit einer OK-Schaltfläche.
		'''Zusätzlich wird die Message-Eigenschaft des übergebenen Exception-Objektes angezeigt
		'''</summary>
		Public Sub [Error](ByVal text As String, ByVal caption As String, ByVal ex As Exception)
			[Error](text, caption, ex, False)
		End Sub

		'''<summary>
		'''Zeigt eine Fehler-MessageBox mit einer OK-Schaltfläche.
		'''Zusätzlich wird der Stacktrace des übergebenen Exception-Objektes angezeigt,
		'''wenn showStackTrace den Wert true aufweist.
		'''</summary>
		Public Sub [Error](ByVal ex As Exception, ByVal showStackTrace As Boolean)

			Dim list = ErrorHandling.ErrorManager.Instance.GetStackTraceInfoList(ex)
			Dim caption = list.Last.ToString

			If showStackTrace Then
				[Error](list.ToString(True), caption)
			Else
				[Error](ex.Message, caption)
			End If
		End Sub

		'''<summary>
		'''Zeigt eine Fehler-MessageBox mit einer OK-Schaltfläche.
		'''Zusätzlich wird der Stacktrace des übergebenen Exception-Objektes angezeigt,
		'''wenn showStackTrace den Wert true aufweist.
		'''</summary>
		Public Sub [Error](ByVal text As String, ByVal ex As Exception, ByVal showStackTrace As Boolean)

			Dim list = ErrorHandling.ErrorManager.Instance.GetStackTraceInfoList(ex)
			Dim caption = list.Last.ToString

			If showStackTrace Then
				[Error](list.ToString(True), caption)
			Else
				[Error](ex.Message, caption)
			End If
		End Sub

		'''<summary>
		'''Zeigt eine Fehler-MessageBox mit einer OK-Schaltfläche.
		'''Zusätzlich wird der Stacktrace des übergebenen Exception-Objektes angezeigt,
		'''wenn showStackTrace den Wert true aufweist.
		'''</summary>
		Public Sub [Error](ByVal text As String, ByVal caption As String _
		, ByVal ex As Exception, ByVal showStackTrace As Boolean)

			Dim sb = New Text.StringBuilder
			If Not String.IsNullOrEmpty(text) Then
				sb.AppendLine(text)
				sb.AppendLine()
			End If

			Dim list = ErrorHandling.ErrorManager.Instance.GetStackTraceInfoList(ex)

			If String.IsNullOrEmpty(caption) Then
				caption = list.Last.ToString
			End If

			sb.AppendLine(If(showStackTrace, list.ToString(True), ex.Message))

			[Error](sb.ToString, caption)
		End Sub
#End Region

#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
