Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports "
Imports System.Text
#End Region

Namespace Generators

	Public Class PasswordGenerator

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _rnd As New Random
		Private Shared _lowerCaseList As New List(Of String)
		Private Shared _upperCaseList As New List(Of String)
		Private Shared _numericList As New List(Of String)
		Private Shared _specialCharacterList As New List(Of String)
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			InitializeGenerator()
		End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
		Private Shared Sub InitializeGenerator()
			_lowerCaseList.AddRange(New String() _
			{"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m" _
			, "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"})
			_upperCaseList.AddRange(New String() _
			{"A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N" _
			, "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"})
			_numericList.AddRange(New String() _
			{"1", "2", "3", "4", "5", "6", "7", "8", "9"})
			_specialCharacterList.AddRange(New String() _
			{"!", "§", "$", "%", "&", "(", ")", "=", ".", ",", ":", ";" _
			, "?", "+", "*", "~", "#", "_", "-"})
		End Sub

		Private Shared Function GetChars _
		(ByVal count As Int32, ByVal charList As List(Of String)) As List(Of String)

			Dim list = New List(Of String)

			For i = 1 To count
				list.Add(charList.Item(_rnd.Next(charList.Count)))
			Next i

			Return list
		End Function
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Shared Function Generate() As String

			Return Generate(5, 1, 1, 1)
		End Function

		Public Shared Function Generate _
		(ByVal numberOfLowerCaseLetters As Int32 _
		, ByVal numberOfUpperCaseLetters As Int32 _
		, ByVal numberOfNumericLetters As Int32 _
		, ByVal numberOfSpecialCharacterLetters As Int32) As String

			Dim selectedChars = New List(Of String)

			selectedChars.AddRange(GetChars(numberOfLowerCaseLetters, _lowerCaseList))
			selectedChars.AddRange(GetChars(numberOfUpperCaseLetters, _upperCaseList))
			selectedChars.AddRange(GetChars(numberOfNumericLetters, _numericList))
			selectedChars.AddRange(GetChars(numberOfSpecialCharacterLetters, _specialCharacterList))

			Dim sb = New StringBuilder

			While selectedChars.Count > 0
				Dim index = _rnd.Next(selectedChars.Count)
				sb.Append(selectedChars.Item(index))
				selectedChars.RemoveAt(index)
			End While

			Return sb.ToString
		End Function
#End Region

	End Class

End Namespace
