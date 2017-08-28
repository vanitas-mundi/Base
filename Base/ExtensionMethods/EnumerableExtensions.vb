Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Runtime.CompilerServices
#End Region

Namespace ExtensionMethods

	Public Module EnumerableExtensions

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

		<Extension()>
		Public Function EnumerableJoin(Of T As IEnumerable) _
		(ByVal v As T) As String

			Return v.EnumerableJoin(", ")
		End Function

		<Extension()>
		Public Function EnumerableJoin(Of T As IEnumerable) _
		(ByVal v As T, ByVal delimiter As String) As String

			Return String.Join(delimiter, v.OfType(Of String).ToArray)
		End Function

		<Extension()>
		Public Function AnyIn(Of T As IEnumerable) _
		(ByVal v As T, ByVal values As IEnumerable(Of Object)) As Boolean

			Return Common.GetIntersection(v, values, False).Count > 0
		End Function

		<Extension()>
		Public Function AnyIn(Of T As IEnumerable) _
		(ByVal v As T, ByVal ParamArray values() As Object) As Boolean

			Return Common.GetIntersection(v, values, False).Count > 0
		End Function

		<Extension()>
		Public Function MembersMissingIn(Of T As IEnumerable) _
		(ByVal v As T, ByVal values As IEnumerable(Of Object)) As Boolean

			Return Common.GetIntersection(v, values, False).Count = 0
		End Function

		<Extension()>
		Public Function MembersMissingIn(Of T As IEnumerable) _
		(ByVal v As T, ByVal ParamArray values() As Object) As Boolean

			Return Common.GetIntersection(v, values, False).Count = 0
		End Function

		<Extension()>
		Public Function AllMembersIn(Of T As IEnumerable) _
		(ByVal v As T, ByVal values As IEnumerable(Of Object)) As Boolean

			Return Common.GetAllMembersIn(Of T)(v, values, False)
		End Function

		<Extension()>
		Public Function AllMembersIn(Of T As IEnumerable) _
		(ByVal v As T, ByVal ParamArray values() As Object) As Boolean

			Return Common.GetAllMembersIn(Of T)(v, values, False)
		End Function

		<Extension()>
		Public Function Intersection(Of T As IEnumerable) _
		(ByVal v As T, ByVal ParamArray values() As Object) As Object()

			Return Common.GetIntersection(v, values, False)
		End Function

		<Extension()>
		Public Function Intersection(Of T As IEnumerable) _
		(ByVal v As T, ByVal values As IEnumerable) As Object()

			Return Common.GetIntersection(v, values, False)
		End Function

		<Extension()>
		Public Function DifferenceQuantity(Of T As IEnumerable) _
		(ByVal v As T, ByVal ParamArray values() As Object) As Object()

			Return Common.GetDifferenceQuantity(v, values, False)
		End Function

		''' <summary>
		''' Liefert die Differenzmenge.
		''' </summary>
		''' <typeparam name="T"></typeparam>
		''' <param name="v"></param>
		''' <param name="values"></param>
		''' <returns></returns>
		''' <remarks></remarks>
		<Extension()>
		Public Function DifferenceQuantity(Of T As IEnumerable(Of String)) _
		(ByVal v As T, ByVal values As IEnumerable) As Object()

			Return Common.GetDifferenceQuantity(v, values, False)
		End Function

		<Extension()>
		Public Function ToListOf(Of T As IEnumerable, TOutputType)(ByVal v As T) As List(Of TOutputType)

			Return Common.GetListOf(Of TOutputType)(v)
		End Function

		<Extension()>
		Public Function ToArrayOf(Of T As IEnumerable, TOutputType)(ByVal v As T) As TOutputType()

			Return Common.GetArrayOf(Of TOutputType)(v)
		End Function

	End Module

End Namespace
