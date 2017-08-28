Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports/ usings "
Imports System.Text
#End Region

Namespace Cryptography.Hashes

	''' <summary>
	''' Copyright (c) 2000 Oren Novotny (osn@po.cwru.edu)
	''' Permission is granted to use this code for anything.
	''' Derived from the RSA Data Security, Inc. MD4 Message-Digest Algorithm. 
	''' http://www.rsasecurity.com">RSA Data Security, Inc. requires 
	''' attribution for any work that is derived from the MD4 Message-Digest 
	''' Algorithm; for details see http://www.roxen.com/rfc/rfc1320.html.
	''' This code is ported from Norbert Hranitzky'''s 
	''' (norbert.hranitzky@mchp.siemens.de)
	''' Java version.
	''' Copyright (c) 2008 Luca Mauri (http://www.lucamauri.com)
	''' The orginal version found at http://www.derkeiler.com/Newsgroups/microsoft.public.dotnet.security/2004-08/0004.html
	''' was not working. I corrected and modified it so the current version is
	''' now calculating proper MD4 checksum.
	''' Implements the MD4 message digest algorithm in VB.Net
	''' Ronald L. Rivest,
	''' http://www.roxen.com/rfc/rfc1320.html
	''' The MD4 Message-Digest Algorithm
	''' IETF RFC-1320 (informational).
	''' </summary>
	''' <remarks></remarks>
	Public Class MD4Hash

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
		Private Const _blockLength As Int32 = 64 ' = 512 / 8
		Private _context(4 - 1) As UInt32
		Private _count As Int64
		Private _buffer(_blockLength - 1) As Byte
		Private _x(16 - 1) As UInt32
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New()
			EngineReset()
		End Sub

		' This constructor is here to implement the clonability of this class
		Private Sub New(ByVal md As MD4Hash)
			Initialize(md)
		End Sub

		Private Sub Initialize(ByVal md As MD4Hash)
			_context = CType(md._context.Clone(), UInt32())
			_buffer = CType(md._buffer.Clone(), Byte())
			_count = md._count
		End Sub
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
		''' <summary>
		''' Resets this object disregarding any temporary data present at the
		''' time of the invocation of this call.
		''' </summary>
		Private Sub EngineReset()
			_context = New UInt32() {1732584193, 4023233417, 2562383102, 271733878}
			_count = 0

			For i = 0 To _blockLength - 1
				_buffer(i) = 0
			Next i
		End Sub

		''' <summary>
		''' Continues an MD4 message digest using the input byte 
		''' </summary>
		''' <param name="b">byte to input</param>
		Private Sub EngineUpdate(ByVal b As Byte)

			' compute number of bytes still unhashed; ie. present in buffer
			Dim i = Convert.ToInt32(_count Mod _blockLength)
			_count += 1 ' update number of bytes
			_buffer(i) = b

			If i = (_blockLength - 1) Then Transform(_buffer, 0)
		End Sub

		''' <summary>
		''' MD4 block update operation
		''' Continues an MD4 message digest operation by filling the buffer, 
		''' transform(ing) data in 512-bit message block(s), updating the variables
		''' context and count, and leaving (buffering) the remaining bytes in buffer
		''' for the next update or finish.
		''' </summary>
		''' <param name="input">input block</param>
		''' <param name="offset">start of meaningful bytes in input</param>
		''' <param name="len">count of bytes in input blcok to consider</param>
		Private Sub EngineUpdate(ByVal input() As Byte, ByVal offset As Int32, ByVal len As Int32)

			' make sure we don't exceed input's allocated size/length
			If ((offset < 0) OrElse (len < 0) OrElse (offset + len > input.Length)) Then
				Throw New ArgumentOutOfRangeException()
			End If

			' compute number of bytes still unhashed; ie. present in buffer
			Dim bufferNdx = Convert.ToInt32(_count Mod _blockLength)
			_count += len ' update number of bytes
			Dim partLen = (_blockLength - bufferNdx)

			Dim i = 0
			If len >= partLen Then
				Array.Copy(input, offset + i, _buffer, bufferNdx, partLen)
				Transform(_buffer, 0)
				i = partLen

				While (i + _blockLength - 1) < len
					Transform(input, offset + i)
					i += _blockLength
				End While
				bufferNdx = 0
			End If

			' buffer remaining input
			If i < len Then Array.Copy(input, offset + i, _buffer, bufferNdx, len - i)
		End Sub

		''' <summary>
		''' Completes the hash computation by performing final operations 
		''' such as padding.  At the return of this engineDigest, the MD 
		''' engine is reset.
		''' </summary>
		''' <returns>returns the array of bytes for the resulting hash value.</returns>
		Private Function EngineDigest() As Byte()

			' pad output to 56 mod 64; as RFC1320 puts it: congruent to 448 mod 512
			Dim bufferNdx = Convert.ToInt32(_count Mod _blockLength)
			Dim padLen As Int32

			padLen = If(bufferNdx < 56, 56, 120) - bufferNdx

			' padding is always binary 1 followed by binary 0's
			Dim tail(padLen + 8 - 1) As Byte
			tail(0) = Convert.ToByte(128)

			' append length before final transform
			' save number of bits, casting the long to an array of 8 bytes
			' save low-order byte first.
			Dim tempArray As Byte()
			tempArray = BitConverter.GetBytes(_count * 8)
			tempArray.CopyTo(tail, padLen)

			EngineUpdate(tail, 0, tail.Length)

			Dim result(16 - 1) As Byte

			For i = 0 To 3
				Dim tempStore(4 - 1) As Byte
				tempStore = BitConverter.GetBytes(_context(i))
				tempStore.CopyTo(result, i * 4)
			Next i

			' reset the engine
			EngineReset()
			Return result
		End Function

		Private Shared Function BytesToHex(ByVal a() As Byte, ByVal len As Int32) As String

			Dim temp = BitConverter.ToString(a)

			' We need to remove the dashes that come from the BitConverter
			' This should be the final size
			Dim sb = New StringBuilder(Convert.ToInt32((len - 2) / 2))

			For i = 0 To temp.Length - 1 Step 1
				If temp(i) <> "-" Then sb.Append(temp(i))
			Next i

			Return sb.ToString()
		End Function

		''' <summary>
		''' MD4 basic transformation
		''' Transforms context based on 512 bits from input block starting
		''' from the offset'th byte.
		''' </summary>
		''' <param name="block">input sub-array</param>
		''' <param name="offset">starting position of sub-array</param>
		Private Sub Transform(ByRef block() As Byte, ByVal offset As Int32)

			' decodes 64 bytes from input block into an array of 16 32-bit
			' entities. Use A as a temp var.
			For i = 0 To 15 Step 1
				If offset >= block.Length Then Exit For

				_x(i) = Convert.ToUInt32((Convert.ToUInt32(block(offset + 0)) And 255) _
				Or (Convert.ToUInt32(block(offset + 1)) And 255) << 8 _
				Or (Convert.ToUInt32(block(offset + 2)) And 255) << 16 _
				Or (Convert.ToUInt32(block(offset + 3)) And 255) << 24)
				offset += 4
			Next i

			Dim a = _context(0)
			Dim b = _context(1)
			Dim c = _context(2)
			Dim d = _context(3)

			a = FF(a, b, c, d, _x(0), 3)
			d = FF(d, a, b, c, _x(1), 7)
			c = FF(c, d, a, b, _x(2), 11)
			b = FF(b, c, d, a, _x(3), 19)
			a = FF(a, b, c, d, _x(4), 3)
			d = FF(d, a, b, c, _x(5), 7)
			c = FF(c, d, a, b, _x(6), 11)
			b = FF(b, c, d, a, _x(7), 19)
			a = FF(a, b, c, d, _x(8), 3)
			d = FF(d, a, b, c, _x(9), 7)
			c = FF(c, d, a, b, _x(10), 11)
			b = FF(b, c, d, a, _x(11), 19)
			a = FF(a, b, c, d, _x(12), 3)
			d = FF(d, a, b, c, _x(13), 7)
			c = FF(c, d, a, b, _x(14), 11)
			b = FF(b, c, d, a, _x(15), 19)

			a = GG(a, b, c, d, _x(0), 3)
			d = GG(d, a, b, c, _x(4), 5)
			c = GG(c, d, a, b, _x(8), 9)
			b = GG(b, c, d, a, _x(12), 13)
			a = GG(a, b, c, d, _x(1), 3)
			d = GG(d, a, b, c, _x(5), 5)
			c = GG(c, d, a, b, _x(9), 9)
			b = GG(b, c, d, a, _x(13), 13)
			a = GG(a, b, c, d, _x(2), 3)
			d = GG(d, a, b, c, _x(6), 5)
			c = GG(c, d, a, b, _x(10), 9)
			b = GG(b, c, d, a, _x(14), 13)
			a = GG(a, b, c, d, _x(3), 3)
			d = GG(d, a, b, c, _x(7), 5)
			c = GG(c, d, a, b, _x(11), 9)
			b = GG(b, c, d, a, _x(15), 13)

			a = HH(a, b, c, d, _x(0), 3)
			d = HH(d, a, b, c, _x(8), 9)
			c = HH(c, d, a, b, _x(4), 11)
			b = HH(b, c, d, a, _x(12), 15)
			a = HH(a, b, c, d, _x(2), 3)
			d = HH(d, a, b, c, _x(10), 9)
			c = HH(c, d, a, b, _x(6), 11)
			b = HH(b, c, d, a, _x(14), 15)
			a = HH(a, b, c, d, _x(1), 3)
			d = HH(d, a, b, c, _x(9), 9)
			c = HH(c, d, a, b, _x(5), 11)
			b = HH(b, c, d, a, _x(13), 15)
			a = HH(a, b, c, d, _x(3), 3)
			d = HH(d, a, b, c, _x(11), 9)
			c = HH(c, d, a, b, _x(7), 11)
			b = HH(b, c, d, a, _x(15), 15)

			_context(0) = TruncateHex(Convert.ToUInt64(_context(0) + Convert.ToInt64(a)))
			_context(1) = TruncateHex(Convert.ToUInt64(_context(1) + Convert.ToInt64(b)))
			_context(2) = TruncateHex(Convert.ToUInt64(_context(2) + Convert.ToInt64(c)))
			_context(3) = TruncateHex(Convert.ToUInt64(_context(3) + Convert.ToInt64(d)))
		End Sub

		Private Function FF _
		(ByVal a As UInt32 _
		, ByVal b As UInt32 _
		, ByVal c As UInt32 _
		, ByVal d As UInt32 _
		, ByVal x As UInt32 _
		, ByVal s As Int32) As UInt32

			Dim t As UInt32

			Try
				t = TruncateHex(Convert.ToUInt64(TruncateHex(Convert.ToUInt64(Convert.ToInt64(a) _
				+ ((b And c) Or ((Not b) And d)))) + Convert.ToInt64(x)))

				Return (t << s) Or (t >> (32 - s))
			Catch ex As Exception
				Return (t << s) Or (t >> (32 - s))
			End Try
		End Function

		Private Function GG _
		(ByVal a As UInt32 _
		, ByVal b As UInt32 _
		, ByVal c As UInt32 _
		, ByVal d As UInt32 _
		, ByVal x As UInt32 _
		, ByVal s As Int32) As UInt32

			Dim t As UInt32

			Try
				t = TruncateHex(CULng(TruncateHex(Convert.ToUInt64(Convert.ToInt64(a) _
				+ ((b And (c Or d)) Or (c And d)))) + Convert.ToInt64(x) + 1518500249)) '&H5A827999

				Return t << s Or t >> (32 - s)
			Catch
				Return t << s Or t >> (32 - s)
			End Try
		End Function

		Private Function HH _
		(ByVal a As UInt32 _
		, ByVal b As UInt32 _
		, ByVal c As UInt32 _
		, ByVal d As UInt32 _
		, ByVal x As UInt32 _
		, ByVal s As Int32) As UInt32

			Dim t As UInt32

			Try
				t = TruncateHex(Convert.ToUInt64(TruncateHex _
				(Convert.ToUInt64(Convert.ToInt64(a) + (b Xor c Xor d))) _
				+ Convert.ToInt64(x) + 1859775393)) '&H6ED9EBA1

				Return t << s Or t >> (32 - s)
			Catch
				Return t << s Or t >> (32 - s)
			End Try
		End Function

		Private Function TruncateHex(ByVal number64 As UInt64) As UInt32

			Dim hexString = number64.ToString("x")

			Dim hexStringLimited = If(hexString.Length < 8 _
			, hexString.PadLeft(8, Convert.ToChar("0")), hexString.Substring(hexString.Length - 8))

			Return UInt32.Parse(hexStringLimited, Globalization.NumberStyles.HexNumber)
		End Function
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Function Clone() As Object
			Return New MD4Hash(Me)
		End Function

		''' <summary>Returns a byte hash from a string</summary>
		''' <param name="s">string to hash</param>
		''' <returns>returns byte-array that contains the hash</returns>
		Public Function GetByteHashFromString(ByVal s As String) As Byte()

			Dim b = Encoding.UTF8.GetBytes(s)
			Dim md4 = New MD4Hash()

			md4.EngineUpdate(b, 0, b.Length)
			Return md4.EngineDigest()
		End Function

		''' <summary>Returns a binary hash from an input byte array</summary>
		''' <param name="b">byte-array to hash</param>
		''' <returns>returns binary hash of input</returns>
		Public Function GetByteHashFromBytes(ByVal b() As Byte) As Byte()

			Dim md4 = New MD4Hash()
			md4.EngineUpdate(b, 0, b.Length)
			Return md4.EngineDigest()
		End Function

		''' <summary>Returns a string that contains the hexadecimal hash</summary>
		''' <param name="b">byte-array to input</param>
		''' <returns>returns String that contains the hex of the hash</returns>
		Public Function GetHexHashFromBytes(ByVal b() As Byte) As String

			Dim e = GetByteHashFromBytes(b)
			Return BytesToHex(e, e.Length)
		End Function

		''' <summary>Returns a byte hash from the input byte</summary>
		''' <param name="b">byte to hash</param>
		''' <returns>returns binary hash of the input byte</returns>
		Public Function GetByteHashFromByte(ByVal b As Byte) As Byte()

			Dim md4 = New MD4Hash()
			md4.EngineUpdate(b)
			Return md4.EngineDigest()
		End Function

		''' <summary>Returns a string that contains the hexadecimal hash</summary>
		''' <param name="b">byte to hash</param>
		''' <returns>returns String that contains the hex of the hash</returns>
		Public Function GetHexHashFromByte(ByVal b As Byte) As String

			Dim e = GetByteHashFromByte(b)
			Return BytesToHex(e, e.Length)
		End Function

		''' <summary>Returns a string that contains the hexadecimal hash</summary>
		''' <param name="s">string to hash</param>
		''' <returns>returns String that contains the hex of the hash</returns>
		Public Function GetHexHashFromString(ByVal s As String) As String

			Dim b = GetByteHashFromString(s)
			Return BytesToHex(b, b.Length)
		End Function
#End Region

	End Class

End Namespace
