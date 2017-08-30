Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.Binding
#End Region

Namespace Core

  Public Class ZoomManager

    Inherits NotifyPropertyChangedBase

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Private _zoomFactor As Double = 1
    Public Event ZoomFactorChanged(ByVal sender As Object, ByVal e As ZoomFactorChangedEvenArgs)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Property ZoomFactor As Double
			Get
				Return _zoomFactor
			End Get
			Set(value As Double)
				If _zoomFactor = value Then Return
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Double)(NameOf(Me.ZoomFactor), _zoomFactor, value)
				MyBase.RaisePropertyChanged(NameOf(Me.ZoomInPercent))
				RaiseEvent ZoomFactorChanged(Me, New ZoomFactorChangedEvenArgs(Me))
			End Set
		End Property

		Public ReadOnly Property ZoomInPercent As Int32
			Get
				Return Convert.ToInt32(Me.ZoomFactor * 100)
			End Get
		End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
