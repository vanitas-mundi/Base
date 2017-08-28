Option Explicit On
Option Infer On
Option Strict On

Namespace Etc

	Public Class Lambda

		Public Shared Function ForEachIndex(ByVal startIndex As Int32, ByVal endIndex As Int32) As List(Of Int32)
			Return Enumerable.Repeat(startIndex, endIndex + 1).Select(Function(x, idx) idx).ToList
		End Function
	End Class

End Namespace
