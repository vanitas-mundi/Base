Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Runtime.CompilerServices
#End Region

Namespace ExtensionMethods

	Public Module CharExtensions

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
		Public Function IsIn(ByVal v As Char _
		, ByVal ignoreCase As Boolean _
		, ByVal values As IEnumerable(Of Char)) As Boolean

			Return Common.GetIsIn(Of Char)(v, values, ignoreCase)
		End Function

		<Extension()>
		Public Function IsIn(ByVal v As Char _
		, ByVal ignoreCase As Boolean _
		, ByVal ParamArray values() As Char) As Boolean

			Return Common.GetIsIn(Of Char)(v, values, ignoreCase)
		End Function

	End Module

End Namespace
