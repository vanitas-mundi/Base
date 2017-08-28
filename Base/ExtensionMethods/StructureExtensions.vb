Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Runtime.CompilerServices
#End Region

Namespace ExtensionMethods

	Public Module StructureExtensions

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

#Region " --------------->> Öffentliche Methoden der Klasse "
		<Extension()>
		Public Function IsIn(Of T As Structure) _
		(ByVal v As T, ByVal values As IEnumerable(Of T)) As Boolean

			Return Common.GetIsIn(Of T)(v, values, False)
		End Function

		<Extension()>
		Public Function IsIn(Of T As Structure) _
		(ByVal v As T, ByVal ParamArray values() As T) As Boolean

			Return Common.GetIsIn(Of T)(v, values, False)
		End Function

		<Extension()>
		Public Function IsInRange(Of T As Structure) _
		(ByVal v As T, ByVal min As T, ByVal max As T) As Boolean

			Select Case True
				Case TypeOf v Is Boolean
					Return (v.ToBoolean >= min.ToBoolean) AndAlso (v.ToBoolean <= max.ToBoolean)
				Case TypeOf v Is Byte
					Return (v.ToByte >= min.ToByte) AndAlso (v.ToByte <= max.ToByte)
				Case TypeOf v Is Char
					Return (v.ToChar >= min.ToChar) AndAlso (v.ToChar <= max.ToChar)
				Case TypeOf v Is DateTime
					Return (v.ToDateTime >= min.ToDateTime) AndAlso (v.ToDateTime <= max.ToDateTime)
				Case TypeOf v Is Decimal
					Return (v.ToDecimal >= min.ToDecimal) AndAlso (v.ToDecimal <= max.ToDecimal)
				Case TypeOf v Is Double
					Return (v.ToDouble >= min.ToDouble) AndAlso (v.ToDouble <= max.ToDouble)
				Case TypeOf v Is Int16
					Return (v.ToInt16 >= min.ToInt16) AndAlso (v.ToInt16 <= max.ToInt16)
				Case TypeOf v Is Int32
					Return (v.ToInt32 >= min.ToInt32) AndAlso (v.ToInt32 <= max.ToInt32)
				Case TypeOf v Is Int64
					Return (v.ToInt64 >= min.ToInt64) AndAlso (v.ToInt64 <= max.ToInt64)
				Case TypeOf v Is SByte
					Return (v.ToSByte >= min.ToSByte) AndAlso (v.ToSByte <= max.ToSByte)
				Case TypeOf v Is Single
					Return (v.ToSingle >= min.ToSingle) AndAlso (v.ToSingle <= max.ToSingle)
				Case TypeOf v Is UInt16
					Return (v.ToUInt16 >= min.ToUInt16) AndAlso (v.ToUInt16 <= max.ToUInt16)
				Case TypeOf v Is UInt32
					Return (v.ToInt16 >= min.ToUInt16) AndAlso (v.ToUInt16 <= max.ToUInt16)
				Case TypeOf v Is UInt64
					Return (v.ToInt16 >= min.ToUInt16) AndAlso (v.ToUInt16 <= max.ToUInt16)
				Case Else
					Return False
			End Select

		End Function

		<Extension()>
		Public Function IsNumeric(Of T As Structure)(ByVal v As T) As Boolean

			Return Common.GetIsNumeric(v.ToString)
		End Function

		<Extension()>
		Public Function ToQuotedString(Of T As Structure)(ByVal v As T) As String

			Return String.Format("""{0}""", v.ToString)
		End Function

		<Extension()>
		Public Function ToSingleQuotedString(Of T As Structure)(ByVal v As T) As String

			Return String.Format("'{0}'", v.ToString)
		End Function

		<Extension()>
		Public Function ToBoolean(Of T As Structure)(ByVal v As T) As Boolean

			Return Convert.ToBoolean(v)
		End Function

		<Extension()>
		Public Function ToByte(Of T As Structure)(ByVal v As T) As Byte

			Return Convert.ToByte(v)
		End Function

		<Extension()>
		Public Function ToChar(Of T As Structure)(ByVal v As T) As Char

			Return Convert.ToChar(v)
		End Function

		<Extension()>
		Public Function ToDateTime(Of T As Structure)(ByVal v As T) As DateTime

			Return Convert.ToDateTime(v)
		End Function

		<Extension()>
		Public Function ToDecimal(Of T As Structure)(ByVal v As T) As Decimal

			Return Convert.ToDecimal(v)
		End Function

		<Extension()>
		Public Function ToDouble(Of T As Structure)(ByVal v As T) As Double

			Return Convert.ToDouble(v)
		End Function

		<Extension()>
		Public Function ToInt16(Of T As Structure)(ByVal v As T) As Int16

			Return Convert.ToInt16(v)
		End Function

		<Extension()>
		Public Function ToInt32(Of T As Structure)(ByVal v As T) As Int32

			Return Convert.ToInt32(v)
		End Function

		<Extension()>
		Public Function ToInt64(Of T As Structure)(ByVal v As T) As Int64

			Return Convert.ToInt64(v)
		End Function

		<Extension()>
		Public Function ToSByte(Of T As Structure)(ByVal v As T) As SByte

			Return Convert.ToSByte(v)
		End Function

		<Extension()>
		Public Function ToSingle(Of T As Structure)(ByVal v As T) As Single

			Return Convert.ToSingle(v)
		End Function

		<Extension()>
		Public Function ToUInt16(Of T As Structure)(ByVal v As T) As UInt16

			Return Convert.ToUInt16(v)
		End Function

		<Extension()>
		Public Function ToUInt32(Of T As Structure)(ByVal v As T) As UInt32

			Return Convert.ToUInt32(v)
		End Function

		<Extension()>
		Public Function ToUInt64(Of T As Structure)(ByVal v As T) As UInt64

			Return Convert.ToUInt64(v)
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Module

End Namespace
