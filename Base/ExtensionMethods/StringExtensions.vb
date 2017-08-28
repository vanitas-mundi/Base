Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
#End Region

Namespace ExtensionMethods

	Public Module StringExtensions

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
		Public Function ShowExclamation(ByVal v As String) As MsgBoxResult

			Return MsgBox(v, MsgBoxStyle.Exclamation)
		End Function

		<Extension()>
		Public Function ShowError(ByVal v As String) As MsgBoxResult

			Return MsgBox(v, MsgBoxStyle.Critical)
		End Function

		<Extension()>
		Public Function ShowInformation(ByVal v As String) As MsgBoxResult

			Return MsgBox(v, MsgBoxStyle.Information)
		End Function

		<Extension()>
		Public Function ShowQuestion(ByVal v As String) As MsgBoxResult

			Return MsgBox(v, MsgBoxStyle.YesNo)
		End Function

		<Extension()>
		Public Function ShowExclamation(ByVal v As String, ByVal title As String) As MsgBoxResult

			Return MsgBox(v, MsgBoxStyle.Exclamation, title)
		End Function

		<Extension()>
		Public Function ShowError(ByVal v As String, ByVal title As String) As MsgBoxResult

			Return MsgBox(v, MsgBoxStyle.Critical, title)
		End Function

		<Extension()>
		Public Function ShowInformation(ByVal v As String, ByVal title As String) As MsgBoxResult

			Return MsgBox(v, MsgBoxStyle.Information, title)
		End Function

		<Extension()>
		Public Function ShowQuestion(ByVal v As String, ByVal title As String) As MsgBoxResult

			Return MsgBox(v, MsgBoxStyle.YesNo, title)
		End Function

		<Extension()>
		Public Function IsIn(ByVal v As String _
		, ByVal ignoreCase As Boolean _
		, ByVal values As IEnumerable(Of String)) As Boolean

			Return Common.GetIsIn(Of String)(v, values, ignoreCase)
		End Function

		<Extension()>
		Public Function IsNumeric(ByVal v As String) As Boolean

			Return Common.GetIsNumeric(v)
		End Function

		<Extension()>
		Public Function IsIn(ByVal v As String _
		, ByVal ignoreCase As Boolean _
		, ByVal ParamArray values() As String) As Boolean

			Return Common.GetIsIn(Of String)(v, values, ignoreCase)
		End Function

		<Extension()>
		Public Function Split(ByVal v As String, ByVal pattern As String) As String()

			Return Regex.Split(v, pattern)
		End Function

		<Extension()>
		Public Function Split(ByVal v As String, ByVal pattern As String, ByVal options As RegexOptions) As String()

			Return Regex.Split(v, pattern, options)
		End Function

		<Extension()>
		Public Function ToFormat(ByVal v As String, ByVal ParamArray values() As String) As String

			Return String.Format(v, values)
		End Function

		<Extension()>
		Public Function ToQuotedString(ByVal v As String) As String

			Return String.Format("""{0}""", v.ToString)
		End Function

		<Extension()>
		Public Function ToSingleQuotedString(ByVal v As String) As String

			Return String.Format("'{0}'", v.ToString)
		End Function

		<Extension()>
		Public Function ToStringBuilder(ByVal v As String) As StringBuilder

			Return New StringBuilder(v)
		End Function

		<Extension()>
		Public Function ToBoolean(ByVal v As String) As Boolean

			Return Convert.ToBoolean(v)
		End Function

		<Extension()>
		Public Function ToByte(ByVal v As String) As Byte

			Return Convert.ToByte(v)
		End Function

		<Extension()>
		Public Function ToChar(ByVal v As String) As Char

			Return Convert.ToChar(v)
		End Function

		<Extension()>
		Public Function ToDateTime(ByVal v As String) As DateTime

			Return Convert.ToDateTime(v)
		End Function

		<Extension()>
		Public Function ToDecimal(ByVal v As String) As Decimal

			Return Convert.ToDecimal(v)
		End Function

		<Extension()>
		Public Function ToDouble(ByVal v As String) As Double

			Return Convert.ToDouble(v)
		End Function

		<Extension()>
		Public Function ToInt16(ByVal v As String) As Int16

			Return Convert.ToInt16(v)
		End Function

		<Extension()>
		Public Function ToInt32(ByVal v As String) As Int32

			Return Convert.ToInt32(v)
		End Function

		<Extension()>
		Public Function ToInt64(ByVal v As String) As Int64

			Return Convert.ToInt64(v)
		End Function

		<Extension()>
		Public Function ToSByte(ByVal v As String) As SByte

			Return Convert.ToSByte(v)
		End Function

		<Extension()>
		Public Function ToSingle(ByVal v As String) As Single

			Return Convert.ToSingle(v)
		End Function

		<Extension()>
		Public Function ToUInt16(ByVal v As String) As UInt16

			Return Convert.ToUInt16(v)
		End Function

		<Extension()>
		Public Function ToUInt32(ByVal v As String) As UInt32

			Return Convert.ToUInt32(v)
		End Function

		<Extension()>
		Public Function ToUInt64(ByVal v As String) As UInt64

			Return Convert.ToUInt64(v)
		End Function

	End Module

End Namespace
