Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace ErrorHandling

	Public Class StackTraceInfoList

		Inherits List(Of StackTraceInfo)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private _exception As Exception
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New(ByVal ex As Exception)
			Initialize(ex)
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
		Private Sub Initialize(ByVal ex As Exception)

			_exception = ex
			Dim st = New StackTrace(ex, True)
			For i = 0 To st.FrameCount - 1
				Me.Add(New StackTraceInfo(ex, st.GetFrame(i)))
			Next i
		End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Overloads Overrides Function ToString() As String
			Return Me.ToString(False)
		End Function

		Public Overloads Function ToString(ByVal includeExceptionMessage As Boolean) As String
			Dim msg = If(includeExceptionMessage, _exception.Message & vbCrLf, "")
			Return msg & String.Join(vbCrLf, Me.Select(Function(x) x.ToString).ToArray)
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
