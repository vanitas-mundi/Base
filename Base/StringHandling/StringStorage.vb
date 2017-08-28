Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
#End Region

Namespace StringHandling

	Public Class StringStorage(Of T As Structure)

#Region " --------------->> Enumerationen der Klasse "
#End Region  '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private _storage As New Dictionary(Of CultureCodes, CultureStringStorage(Of T))
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region  '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region  '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
		Private Function IsCultureAvailable(ByVal culture As CultureCodes) As Boolean

			Return _storage.ContainsKey(culture)
		End Function

		Private Function IsKeyAvailable(ByVal culture As CultureCodes, ByVal key As T) As Boolean

			Return IsCultureAvailable(culture) AndAlso _storage.Item(culture).ContainsKey(key)
		End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Function GetStrings() As String()

			Return GetStrings(CultureCodes.a_Default)
		End Function

		Public Function GetStrings(ByVal culture As CultureCodes) As String()

			Return System.Enum.GetValues(GetType(T)).OfType(Of T).Select(Function(key) GetString(key, culture)).ToArray
		End Function

		Public Function GetString(ByVal key As T) As String

			Return GetString(key, CultureCodes.a_Default)
		End Function

		Public Function GetString(ByVal key As T, ByVal ParamArray args() As String) As String

			Return GetString(key, CultureCodes.a_Default, args)
		End Function

		Public Function GetString(ByVal key As T, ByVal culture As CultureCodes) As String
			Select Case True
				Case IsKeyAvailable(culture, key)
					Return _storage.Item(culture).Item(key)
				Case IsKeyAvailable(CultureCodes.a_Default, key)
					Return _storage.Item(CultureCodes.a_Default).Item(key)
				Case Else
					Return String.Format("###{0}.{1}###", culture.ToString, key)
			End Select
		End Function

		Public Function GetString(ByVal key As T, ByVal culture As CultureCodes, ByVal ParamArray args() As String) As String

			Dim sb = New StringBuilder(Me.GetString(key, culture))
			For i = 0 To args.Count - 1
				sb.Replace("{" & i & "}", args(i).ToString)
			Next i
			Return sb.ToString
		End Function

		Public Function GetItems() As StringStorageItem(Of T)()

			Return GetItems(CultureCodes.a_Default)
		End Function

		Public Function GetItems(ByVal culture As CultureCodes) As StringStorageItem(Of T)()

			Return System.Enum.GetValues(GetType(T)).OfType(Of T).Select(Function(key) GetItem(key, culture)).ToArray
		End Function

		Public Function GetItem(ByVal key As T) As StringStorageItem(Of T)

			Return GetItem(key, CultureCodes.a_Default)
		End Function

		Public Function GetItem(ByVal key As T, ByVal culture As CultureCodes) As StringStorageItem(Of T)

			Return New StringStorageItem(Of T)(key, Me.GetString(key, culture), culture)
		End Function

		Public Sub AddRangeToStorage(ByVal items As IEnumerable(Of StringStorageItem(Of T)))
			items.ToList.ForEach(Sub(x) AddToStorage(x))
		End Sub

		Public Sub AddToStorage(ByVal key As T, ByVal value As String)
			AddToStorage(key, value, CultureCodes.a_Default)
		End Sub

		Public Sub AddToStorage(ByVal item As StringStorageItem(Of T))

			Me.AddToStorage(item.Key, item.Value, item.CultureCode)
		End Sub

		Public Sub AddToStorage(ByVal key As T, ByVal value As String, ByVal culture As CultureCodes)

			If Not IsCultureAvailable(culture) Then _storage.Add(culture, New CultureStringStorage(Of T))
			If Not IsKeyAvailable(culture, key) Then _storage.Item(culture).Add(key, "")
			_storage.Item(culture).Item(key) = value
		End Sub
#End Region  '{Öffentliche Methoden der Klasse}

	End Class

End Namespace

