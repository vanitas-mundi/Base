Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
Imports BCW.Foundation.Base.vCardBuilder.Enums
#End Region

Namespace vCardBuilder

  '''<summary>Specify the components of the delivery address for the vCard object.</summary>
  Public Class vCardAddress

#Region " ---------------------- Class Description "
    'Url: http://tools.ietf.org/html/rfc2426#section-3.2.1
    '
    '3.2.1 ADR Type Definition

    'Subject: Registration of text/directory MIME type ADR

    'Type name: ADR

    'Type purpose: To specify the components of the delivery address for
    'the vCard object.

    'Type encoding: 8bit

    'Type value: A single structured text value, separated by the
    'SEMI-COLON character (ASCII decimal 59).

    'Type special notes: The structured type value consists of a sequence
    'of address components. The component values MUST be specified in
    'their corresponding position. The structured type value corresponds,
    'in sequence, to the post office box; the extended address; the street
    'address; the locality (e.g., city); the region (e.g., state or
    'province); the postal code; the country name. When a component value
    'is missing, the associated component separator MUST still be
    'specified.

    'The text components are separated by the SEMI-COLON character (ASCII
    'decimal 59). Where it makes semantic sense, individual text
    'components can include multiple text values (e.g., a "street"
    'component with multiple lines) separated by the COMMA character
    '(ASCII decimal 44).

    'The type can include the type parameter "TYPE" to specify the
    'delivery address type. The TYPE parameter values can include "dom" to
    'indicate a domestic delivery address; "intl" to indicate an
    'international delivery address; "postal" to indicate a postal
    'delivery address; "parcel" to indicate a parcel delivery address;
    '"home" to indicate a delivery address for a residence; "work" to
    'indicate delivery address for a place of work; and "pref" to indicate
    'the preferred delivery address when more than one address is
    'specified. These type parameter values can be specified as a
    'parameter list (i.e., "TYPE=dom;TYPE=postal") or as a value list
    '(i.e., "TYPE=dom,postal"). This type is based on semantics of the
    'X.520 geographical and postal addressing attributes. The default is
    '"TYPE=intl,postal,parcel,work". The default can be overridden to some
    'other set of values by specifying one or more alternate values. For
    'example, the default can be reset to "TYPE=dom,postal,work,home" to
    'specify a domestic delivery address for postal delivery to a
    'residence that is also used for work.

    'Type example: In this example the post office box and the extended
    'address are absent.

    '      ADR;TYPE=dom,home,postal,parcel:;;123 Main Street;Any Town;CA;91921-1234
#End Region

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "

    Public Sub New()
    End Sub
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "

    Public ReadOnly Property AddressType() As List(Of vCardAddressTypes) _
    = New List(Of vCardAddressTypes)(New vCardAddressTypes() _
    {vCardAddressTypes.intl, vCardAddressTypes.postal, vCardAddressTypes.parcel, vCardAddressTypes.work})

    Public Property PostOfficeBox() As String

    '''<summary>Anschriftenzusatz.</summary>
    Public Property ExtendedAddress() As String

    '''<summary>Straße der Anschrift.</summary>
    Public Property Street() As String

    '''<summary>Stadt der Anschrift.</summary>
    Public Property Locality() As String  '(e.g., city)

    '''<summary>Kanton oder Bundesland.</summary>
    Public Property Region() As String '(e.g., state or province)

    '''<summary>PLZ der Anschrift.</summary>
    Public Property PostalCode() As String

    '''<summary>Land der Anschrift.</summary>
    Public Property CountryName() As String

    Public ReadOnly Property AddressTypeString() As String
      Get
        Dim result = String.Join(",", _AddressType.Select(Function(x) x.ToString))
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

      Dim sb = New StringBuilder
      sb.Append($"ADR;{Me.AddressTypeString}:")
      sb.Append($"{_PostOfficeBox};")
      sb.Append($"{_ExtendedAddress};")
      sb.Append($"{_Street};")
      sb.Append($"{_Locality};")
      sb.Append($"{_Region};")
      sb.Append($"{_PostalCode};")
      sb.Append($"{_CountryName}")

      Return sb.ToString
    End Function
#End Region

  End Class

End Namespace