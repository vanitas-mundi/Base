Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace ExtensionMethods

	Friend Class Common

#Region " --------------->> Enumerationen der Klasse "
#End Region  '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region  '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region  '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region  '{Private Methoden der Klasse}

#Region " --------------->> Public Methoden  "
		'''<summary></summary>
		Public Shared Function GetIsIn(Of T)(ByVal input As T _
		, ByVal values As IEnumerable(Of T) _
		, ByVal ignoreCase As Boolean) As Boolean

			Return If(ignoreCase _
			, values.Where(Function(v) input.ToString.ToLower = v.ToString.ToLower) _
			, values.Where(Function(v) input.ToString = v.ToString)).Any
		End Function

		'''<summary></summary>
		Public Shared Function GetIsNumeric(ByVal v As String) As Boolean

			v = v.Replace(",", ".")
			Dim parts = v.Split(".")

			Select Case parts.Count
				Case 1, 2
					Return String.Join("", parts).ToCharArray.Where(Function(c) Char.IsNumber(c)).Count = v.Length
				Case Else
					Return False
			End Select
		End Function

		'''<summary></summary>
		Public Shared Function GetAllMembersIn(Of T) _
		(ByVal v As IEnumerable, ByVal values As IEnumerable, ByVal ignoreCase As Boolean) As Boolean

			Return GetIntersection(v, values, ignoreCase).Count = values.ToArrayOf(Of Object).Count
		End Function

		'''<summary></summary>
		Public Shared Function GetIntersection _
		(ByVal v As IEnumerable, ByVal values As IEnumerable, ByVal ignoreCase As Boolean) As Object()

			Dim result = New List(Of Object)

			Dim enumerator = v.GetEnumerator
			While enumerator.MoveNext
				Dim value = enumerator.Current

				Dim enumerator2 = values.GetEnumerator
				enumerator2.Reset()
				While enumerator2.MoveNext
					Dim value2 = enumerator2.Current
					If ((ignoreCase) AndAlso (value.ToString.ToLower = value2.ToString.ToLower)) _
					OrElse (value.ToString = value2.ToString) Then
						result.Add(value)
					End If
				End While

			End While
			enumerator.Reset()

			Return result.ToArray
		End Function

		'''<summary></summary>
		Public Shared Function GetDifferenceQuantity _
		(ByVal v As IEnumerable, ByVal values As IEnumerable, ByVal ignoreCase As Boolean) As Object()

			Dim result = New List(Of Object)
			Dim addItem As Boolean

			Dim enumerator = v.GetEnumerator
			While enumerator.MoveNext
				Dim value = enumerator.Current
				addItem = True

				Dim enumerator2 = values.GetEnumerator
				enumerator2.Reset()
				While enumerator2.MoveNext
					Dim value2 = enumerator2.Current
					If ((ignoreCase) AndAlso (value.ToString.ToLower = value2.ToString.ToLower)) _
					OrElse (value.ToString = value2.ToString) Then
						addItem = False
						Exit While
					End If
				End While

				If addItem Then result.Add(value)
			End While
			enumerator.Reset()

			Return result.ToArray
		End Function

		'''<summary></summary>
		Public Shared Function GetListOf(Of T)(ByVal v As IEnumerable) As List(Of T)

			Dim result = New List(Of T)

			Dim enumerator = v.GetEnumerator
			While enumerator.MoveNext
				Dim value = CType(enumerator.Current, T)
				result.Add(value)
			End While
			enumerator.Reset()

			Return result
		End Function

		'''<summary></summary>
		Public Shared Function GetArrayOf(Of T)(ByVal v As IEnumerable) As T()

			Return GetListOf(Of T)(v).ToArray
		End Function
#End Region

	End Class

End Namespace
