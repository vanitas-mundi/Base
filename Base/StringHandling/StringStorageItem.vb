Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
#End Region

Namespace StringHandling

	Public Class StringStorageItem(Of T As Structure)

#Region " --------------->> Enumerationen der Klasse "
#End Region  '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Public Property Key As T
		Public Property Value As String
		Public Property CultureCode As CultureCodes
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New()
		End Sub

		Public Sub New(ByVal key As T, ByVal value As String, ByVal cultureCode As CultureCodes)
			Me.Key = key
			Me.Value = value
			Me.CultureCode = cultureCode
		End Sub

		Public Sub New(ByVal key As T, ByVal value As String, ByVal cultureCode As String)
			Me.Key = key
			Me.Value = value
			'de_DE
			Me.CultureCode = If(cultureCode = "", CultureCodes.a_Default, CType([Enum].Parse(GetType(CultureCodes), cultureCode.Replace("-", "_")), CultureCodes))
		End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region  '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region  '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region  '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Overrides Function ToString() As String
			Return Me.Value
		End Function

		Public Function Resolve(ByVal ParamArray args() As String) As String

			Dim sb = New StringBuilder(Me.Value)
			For i = 0 To args.Count - 1
				sb.Replace("{" & i & "}", args(i).ToString)
			Next i
			Return sb.ToString
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace



