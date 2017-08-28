Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports BCW.Foundation.Base.vCardBuilder.Enums
#End Region

Namespace vCardBuilder

  '''<summary>Specify the telephone number for telephony communication with the object the vCard represents.</summary>
  Public Class vCardPhoneNumber

#Region " ---------------------- Class Description "
    'Url: http://tools.ietf.org/html/rfc2426#section-3.3.1
    '
    ' 3.3.1 TEL Type Definition
    'Type name: TEL
    '
    'Type purpose: To specify the telephone number for telephony
    'communication with the object the vCard represents.
    '
    'Type encoding: 8bit
    '
    'Type value: A single phone-number value.
    '
    'Type special notes: The value of this type is specified in a
    'canonical form in order to specify an unambiguous representation of
    'the globally unique telephone endpoint. This type is based on the
    'X.500 Telephone Number attribute.
    '
    'The type can include the type parameter "TYPE" to specify intended
    'use for the telephone number. The TYPE parameter values can include:
    '"home" to indicate a telephone number associated with a residence,
    '"msg" to indicate the telephone number has voice messaging support,
    '"work" to indicate a telephone number associated with a place of
    'work, "pref" to indicate a preferred-use telephone number, "voice" to
    'indicate a voice telephone number, "fax" to indicate a facsimile
    'telephone number, "cell" to indicate a cellular telephone number,
    '"video" to indicate a video conferencing telephone number, "pager" to
    'indicate a paging device telephone number, "bbs" to indicate a
    'bulletin board system telephone number, "modem" to indicate a MODEM
    'connected telephone number, "car" to indicate a car-phone telephone
    'number, "isdn" to indicate an ISDN service telephone number, "pcs" to
    'indicate a personal communication services telephone number. The
    'default type is "voice". These type parameter values can be specified
    'as a parameter list (i.e., "TYPE=work;TYPE=voice") or as a value list
    '(i.e., "TYPE=work,voice"). The default can be overridden to another
    'set of values by specifying one or more alternate values. For
    'example, the default TYPE of "voice" can be reset to a WORK and HOME,
    'VOICE and FAX telephone number by the value list
    '"TYPE=work,home,voice,fax".
    '
    'Type example:
    '     TEL;TYPE=work,voice,pref,msg:+1-213-555-1234
#End Region

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
    End Sub

    Public Sub New(ByVal phoneNumber As String, ByVal phoneNumberType() As vCardPhoneNumberTypes)

      _PhoneNumber = phoneNumber
      If phoneNumberType Is Nothing Then Return

      _PhoneNumberType.AddRange(phoneNumberType)
    End Sub
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "

    Public Property PhoneNumber() As String

    Public Property PhoneNumberType() As New List(Of vCardPhoneNumberTypes)

    Public ReadOnly Property PhoneNumberTypeString() As String
      Get
        Dim result = String.Join(",", Me.PhoneNumberType.Select(Function(x) x.ToString))
        Return $"TYPE={result}"
      End Get
    End Property
#End Region

#Region " --------------->> Ereignismethoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Overrides Function ToString() As String
      Return $"TEL;{Me.PhoneNumberTypeString}:{_PhoneNumber}"
    End Function
#End Region

  End Class

End Namespace

