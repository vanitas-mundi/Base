Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.Logging
#End Region

Namespace ErrorHandling

	Public Class ErrorManager

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _instance As ErrorManager
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_instance = New ErrorManager
		End Sub

		Private Sub New()
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Shared ReadOnly Property Instance As ErrorManager
			Get
				Return _instance
			End Get
		End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		''' <summary>
		''' Schreibt ExceptionMessage und Stacktrace ins EventLog.
		''' </summary>
		Public Sub WriteExceptionToEventLog(ByVal ex As Exception)

			EventLogWriter.Instance.WriteToEventLog(GetStackTraceInfoListString(ex), EventLogEntryType.Error)
		End Sub

		'''<summary>Liefert ExceptionMessage und Stacktrace.</summary>
		Public Function GetStackTraceInfoListString(ByVal ex As Exception) As String
			Return GetStackTraceInfoList(ex).ToString(True)
		End Function

		'''<summary>Liefert eine StaceTraceInfoList.</summary>
		Public Function GetStackTraceInfoList(ByVal ex As Exception) As StackTraceInfoList
			Return (New StackTraceInfoList(ex))
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
