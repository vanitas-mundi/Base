Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Diagnostics
Imports SSP.Base.Logging.Enums
#End Region

Namespace Logging

	Public Class EventLogWriter

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _instance As EventLogWriter
		Private _eventLogName As EventLogNames = EventLogNames.Application
		Private _eventLogSource As String = "BCW.Application"
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_instance = New EventLogWriter
		End Sub

		Private Sub New()
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Shared ReadOnly Property Instance As EventLogWriter
			Get
				Return _instance
			End Get
		End Property

		''' <summary>
		''' Liefert den EventLogName oder legt diesen fest.
		''' </summary>
		Public Property EventLogName As EventLogNames
			Get
				Return _eventLogName
			End Get
			Set(value As EventLogNames)
				_eventLogName = value
			End Set
		End Property

		''' <summary>
		''' Liefert die EventLogSource oder legt diese fest.
		''' </summary>
		Public Property EventLogSource As String
			Get
				Return _eventLogSource
			End Get
			Set(value As String)
				_eventLogSource = value
			End Set
		End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		''' <summary>
		''' Schreibt message ins Ereignisprotokoll.
		''' </summary>
		Public Sub WriteToEventLog(ByVal message As String)
			WriteToEventLog(message, EventLogEntryType.Information, 0)
		End Sub

		''' <summary>
		''' Schreibt message ins Ereignisprotokoll.
		''' </summary>
		Public Sub WriteToEventLog(ByVal message As String, ByVal eventLogEntryType As EventLogEntryType)
			WriteToEventLog(message, eventLogEntryType, 0)
		End Sub

		''' <summary>
		''' Schreibt message ins Ereignisprotokoll.
		''' </summary>
		Public Sub WriteToEventLog(ByVal message As String, ByVal eventId As Int32)
			WriteToEventLog(message, EventLogEntryType.Information, eventId)
		End Sub

		''' <summary>
		''' Schreibt message ins Ereignisprotokoll.
		''' </summary>
		Public Sub WriteToEventLog(ByVal message As String, ByVal eventLogEntryType As EventLogEntryType, ByVal eventId As Int32)

			If Not EventLog.SourceExists(Me.EventLogSource) Then
				EventLog.CreateEventSource(Me.EventLogSource, Me.EventLogName.ToString)
			End If

			Using EvtLog = New EventLog
				EvtLog.Source = Me.EventLogSource
				EvtLog.WriteEntry(message, eventLogEntryType, eventId)
			End Using
		End Sub

#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
