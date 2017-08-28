Option Explicit On
Option Infer On
Option Strict On
Imports System.IO

Namespace Serialization.Interfaces
	Public Interface ISerialization

		Sub ObjectToFile(Of T As {Class})(ByVal obj As T, ByVal fileName As String)
		Function ObjectFromFile(Of T As {Class})(ByVal fileName As String) As T
		Sub ObjectToStream(Of T As {Class})(ByVal obj As T, ByVal stream As Stream)
		Function ObjectFromStream(Of T As {Class})(ByVal stream As Stream) As T
		Function CloneObject(Of T As {Class})(ByVal obj As T) As T
		Function IsDataEqualTo(Of T As {Class})(obj As T, obj2 As T) As Boolean
	End Interface

End Namespace
