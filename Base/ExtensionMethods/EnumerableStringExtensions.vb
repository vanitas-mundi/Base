Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Runtime.CompilerServices
#End Region

Namespace ExtensionMethods

	Public Module EnumerableStringExtensions

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
		Public Function AnyIn(Of T As IEnumerable(Of String)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal values As IEnumerable(Of String)) As Boolean

			Return Common.GetIntersection(v, values, ignoreCase).Count > 0
		End Function

		<Extension()>
		Public Function AnyIn(Of T As IEnumerable(Of String)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal ParamArray values() As String) As Boolean

			Return Common.GetIntersection(v, values, ignoreCase).Count > 0
		End Function

		<Extension()>
		Public Function MembersMissingIn(Of T As IEnumerable(Of String)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal values As IEnumerable(Of String)) As Boolean

			Return Common.GetIntersection(v, values, ignoreCase).Count = 0
		End Function

		<Extension()>
		Public Function MembersMissingIn(Of T As IEnumerable(Of String)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal ParamArray values() As String) As Boolean

			Return Common.GetIntersection(v, values, ignoreCase).Count = 0
		End Function

		<Extension()>
		Public Function AllMembersIn(Of T As IEnumerable(Of String)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal values As IEnumerable(Of String)) As Boolean

			Return Common.GetAllMembersIn(Of T)(v, values, ignoreCase)
		End Function

		<Extension()>
		Public Function AllMembersIn(Of T As IEnumerable(Of String)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal ParamArray values() As String) As Boolean

			Return Common.GetAllMembersIn(Of T)(v, values, ignoreCase)
		End Function

		<Extension()>
		Public Function Intersection(Of T As IEnumerable(Of String)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal ParamArray values() As String) As String()

			Return CType(Common.GetIntersection(v, values, ignoreCase), String())
		End Function

		<Extension()>
		Public Function Intersection(Of T As IEnumerable(Of String)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal values As IEnumerable(Of String)) As String()

			Return CType(Common.GetIntersection(v, values, ignoreCase), String())
		End Function

		<Extension()>
		Public Function DifferenceQuantity(Of T As IEnumerable(Of String)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal ParamArray values() As String) As String()

			Return CType(Common.GetDifferenceQuantity(v, values, ignoreCase), String())
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
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal values As IEnumerable(Of String)) As String()

			Return CType(Common.GetDifferenceQuantity(v, values, ignoreCase), String())
		End Function

	End Module

End Namespace
