Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports SSP.Base.Cryptography.Hashes
#End Region

Namespace Cryptography

  Public NotInheritable Class CryptHelper

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Private Const KEY_VALUE As String = "Ar(anus?"
    Private Const IV_VALUE As String = "23422729"

    Private Shared _key As Byte() = Encoding.UTF8.GetBytes(KEY_VALUE)
    Private Shared _iv As Byte() = Encoding.UTF8.GetBytes(IV_VALUE)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Friend Sub New()
    End Sub
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Function CryptStringBase(ByVal bytes As Byte(), ByVal decrypt As Boolean) As Byte()

      Using csp = New DESCryptoServiceProvider With {.Key = _key, .IV = _iv}
        Using ct = If(decrypt, csp.CreateDecryptor(csp.Key, csp.IV), csp.CreateEncryptor(csp.Key, csp.IV))
          Using ms = New MemoryStream
            Using cs = New CryptoStream(ms, ct, CryptoStreamMode.Write)
              cs.Write(bytes, 0, bytes.Length)
              cs.FlushFinalBlock()
              cs.Close()
            End Using
            Return ms.ToArray()
          End Using
        End Using
      End Using
    End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

    '''<summary>Liefert den (MD4) NT-Hash von s.</summary>
    Public Function GetNtHash(ByVal s As String) As String

      Return (New MD4Hash).GetHexHashFromBytes(Encoding.Unicode.GetBytes(s)).ToLower
    End Function

    '''<summary>Verschlüsselt einen Wert.</summary>
    Public Function EncryptString(ByVal value As String) As String
      Return Convert.ToBase64String(CryptStringBase(Encoding.UTF8.GetBytes(value), False))
    End Function

    '''<summary>Entschlüsselt einen zuvor mit EncryptString verschlüsselten Wert.</summary>
    Public Function DecryptString(ByVal value As String) As String
      Return Encoding.UTF8.GetString(CryptStringBase(Convert.FromBase64String(value), True))
    End Function

  End Class

End Namespace
