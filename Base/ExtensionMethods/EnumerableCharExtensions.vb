Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Runtime.CompilerServices
#End Region

Namespace ExtensionMethods

	Public Module EnumerableCharExtensions

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
		Public Function AnyIn(Of T As IEnumerable(Of Char)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal values As IEnumerable(Of Char)) As Boolean

			Return Common.GetIntersection(v, values, ignoreCase).Count > 0
		End Function

		<Extension()>
		Public Function AnyIn(Of T As IEnumerable(Of Char)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal ParamArray values() As Char) As Boolean

			Return Common.GetIntersection(v, values, ignoreCase).Count > 0
		End Function

		<Extension()>
		Public Function MembersMissingIn(Of T As IEnumerable(Of Char)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal values As IEnumerable(Of Char)) As Boolean

			Return Common.GetIntersection(v, values, ignoreCase).Count = 0
		End Function

		<Extension()>
		Public Function MembersMissingIn(Of T As IEnumerable(Of Char)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal ParamArray values() As Char) As Boolean

			Return Common.GetIntersection(v, values, ignoreCase).Count = 0
		End Function

		<Extension()>
		Public Function AllMembersIn(Of T As IEnumerable(Of Char)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal values As IEnumerable(Of Char)) As Boolean

			Return Common.GetAllMembersIn(Of T)(v, values, ignoreCase)
		End Function

		<Extension()>
		Public Function AllMembersIn(Of T As IEnumerable(Of Char)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal ParamArray values() As Char) As Boolean

			Return Common.GetAllMembersIn(Of T)(v, values, ignoreCase)
		End Function

		<Extension()>
		Public Function Intersection(Of T As IEnumerable(Of Char)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal ParamArray values() As Char) As Char()

			Return Array.ConvertAll(Of Object, Char)(Common.GetIntersection(v, values, ignoreCase), Function(o) Char.Parse(o.ToString))
		End Function

		<Extension()>
		Public Function Intersection(Of T As IEnumerable(Of Char)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal values As IEnumerable(Of Char)) As Char()

			Return Array.ConvertAll(Of Object, Char)(Common.GetIntersection(v, values, ignoreCase), Function(o) Char.Parse(o.ToString))
		End Function

		<Extension()>
		Public Function DifferenceQuantity(Of T As IEnumerable(Of Char)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal ParamArray values() As Char) As Char()

			Return Array.ConvertAll(Of Object, Char)(Common.GetDifferenceQuantity(v, values, ignoreCase), Function(o) Char.Parse(o.ToString))
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
		Public Function DifferenceQuantity(Of T As IEnumerable(Of Char)) _
		(ByVal v As T, ByVal ignoreCase As Boolean, ByVal values As IEnumerable(Of Char)) As Char()

			Return Array.ConvertAll(Of Object, Char)(Common.GetDifferenceQuantity(v, values, ignoreCase), Function(o) Char.Parse(o.ToString))
		End Function

	End Module

End Namespace
