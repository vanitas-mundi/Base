Option Explicit On
Option Infer On
Option Strict On
Imports System.IO

Namespace Serialization.Interfaces
	Public Interface ISerializationOf(Of T As {Class})

		Sub ObjectToFile(ByVal obj As T, ByVal fileName As String)
		Function ObjectFromFile(ByVal fileName As String) As T
		Sub ObjectToStream(ByVal obj As T, ByVal stream As Stream)
		Function ObjectFromStream(ByVal stream As Stream) As T

		Sub ObjectToFile(ByVal fileName As String)
		Sub ObjectToStream(ByVal stream As Stream)

		Function CloneObject(ByVal obj As T) As T
		Function CloneObject() As T
		Function IsDataEqualTo(ByVal obj As T) As Boolean
		Function IsDataEqualTo(ByVal obj As T, ByVal obj2 As T) As Boolean
	End Interface

End Namespace
