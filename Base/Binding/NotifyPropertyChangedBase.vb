Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.ComponentModel
#End Region

Namespace Binding

	Public MustInherit Class NotifyPropertyChangedBase

		Implements INotifyPropertyChanged

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Public Event PropertyChanged As PropertyChangedEventHandler _
		Implements INotifyPropertyChanged.PropertyChanged
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
		Protected Overridable Function SetPropertyValueAndRaisePropertyChanged(Of T) _
		(ByVal propertyName As String, ByRef oldValue As T, ByVal newValue As T) As Boolean

			If (oldValue IsNot Nothing) AndAlso (oldValue.Equals(newValue)) Then
				Return False
			Else
				oldValue = newValue
				RaisePropertyChanged(propertyName)
				Return True
			End If
		End Function

		Protected Sub RaisePropertyChanged(ByVal propertyName As String)

			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace

