Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Events

  Public Class EventHandlersDisposerClass

    Implements IDisposable

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Private _disposedValue As Boolean ' Dient zur Erkennung redundanter Aufrufe.
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not _disposedValue Then
        If disposing Then
          EventHandlerManager.Instance.RemoveAtCallbackObjectDispose(Me)
        End If
      End If
      _disposedValue = True
    End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Sub Dispose() Implements IDisposable.Dispose
      Dispose(True)
    End Sub
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
