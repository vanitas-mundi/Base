Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
Imports System.ComponentModel
Imports SSP.Base.vCardBuilder.Enums
#End Region

Namespace vCardBuilder

  ''' <summary>
  ''' Specifies an Internet standards track protocol for the
  ''' Internet community, and requests discussion and suggestions for
  ''' improvements.  Please refer to the current edition of the "Internet
  ''' Official Protocol Standards" (STD 1) for the standardization state
  ''' and status of this protocol.  Distribution of this memo is unlimited.
  ''' </summary>
  <TypeConverter(GetType(ExpandableObjectConverter))>
  Public Class vCard

#Region " ---------------------- Class Description "
    'Url: http://tools.ietf.org/html/rfc2426
    '
    'vCard MIME Directory Profile

    'Status of this Memo

    'This document specifies an Internet standards track protocol for the
    'Internet community, and requests discussion and suggestions for
    'improvements.  Please refer to the current edition of the "Internet
    'Official Protocol Standards" (STD 1) for the standardization state
    'and status of this protocol.  Distribution of this memo is unlimited.

    'Copyright Notice

    'Copyright (C) The Internet Society (1998).  All Rights Reserved.

    'Abstract

    'This memo defines the profile of the MIME Content-Type [MIME-DIR] for
    'directory information for a white-pages person object, based on a
    'vCard electronic business card. The profile definition is independent
    'of any particular directory service or protocol. The profile is
    'defined for representing and exchanging a variety of information
    'about an individual (e.g., formatted and structured name and delivery
    'addresses, email address, multiple telephone numbers, photograph,
    'logo, audio clips, etc.). The directory information used by this
    'profile is based on the attributes for the person object defined in
    'the X.520 and X.521 directory services recommendations. The profile
    'also provides the method for including a [VCARD] representation of a
    'white-pages directory entry within the MIME Content-Type defined by
    'the [MIME-DIR] document.

    'The key words "MUST", "MUST NOT", "REQUIRED", "SHALL", "SHALL NOT",
    '"SHOULD", "SHOULD NOT", "RECOMMENDED", "MAY" and "OPTIONAL" in this
    'document are to be interpreted as described in [RFC 2119].
#End Region

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Shared ReadOnly Property MaskedCrLf() As String
      Get
        Return $"=0D=0A={vbCrLf}"
      End Get
    End Property

    ''' <summary>Registration of text/directory MIME type FN.</summary>
    Public Property CommonName() As String = "CommonName"
    ' Url: http://tools.ietf.org/html/rfc2426#section-3.1.1
    ' 
    '3.1.1 FN Type Definition
    '
    'Subject: Registration of text/directory MIME type FN.
    '
    'Type name:FN
    '
    'Type purpose: To specify the formatted text corresponding to the name
    'of the object the vCard represents.
    '
    'Type encoding: 8bit
    '
    'Type value: A single text value.
    '
    'Type special notes: This type is based on the semantics of the X.520
    'Common Name attribute. The property MUST be present in the vCard
    'object.
    '
    'Type example:
    '   FN:Mr. John Q. Public\, Esq.

    ''' <summary>Registration of text/directory MIME type FN.</summary>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public ReadOnly Property FullName() As vCardFullName _
    = New vCardFullName("FamilyName", "GivenName", Nothing, Nothing, Nothing)

    ''' <summary>Specify the text corresponding to the nickname of the object the vCard represents.</summary>
    Public ReadOnly Property Nicknames() As New List(Of String)
    ' Url: http://tools.ietf.org/html/rfc2426#section-3.1.3
    ' 
    'Type name: NICKNAME
    '
    'Type purpose: To specify the text corresponding to the nickname of
    'the object the vCard represents.
    '
    'Type encoding: 8bit
    '
    'Type value: One or more text values separated by a COMMA character
    '(ASCII decimal 44).
    '
    'Type special note: The nickname is the descriptive name given instead
    'of or in addition to the one belonging to a person, place, or thing.
    'It can also be used to specify a familiar form of a proper name
    'specified by the FN or N types.
    '
    'Type example:
    '   NICKNAME:Robbie
    '   NICKNAME:Jim,Jimmie

    ''' <summary>Registration of text/directory MIME type PHOTO.</summary>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public ReadOnly Property Photo() As New vCardImage
    'Url: http://tools.ietf.org/html/rfc2426#section-3.1.4
    '
    '3.1.4 PHOTO Type Definition
    '
    'Subject: Registration of text/directory MIME type PHOTO
    '
    'Type name: PHOTO
    '
    'Type purpose: To specify an image or photograph information that
    'annotates some aspect of the object the vCard represents.
    '
    'Type encoding: The encoding MUST be reset to "b" using the ENCODING
    'parameter in order to specify inline, encoded binary data. If the
    'value is referenced by a URI value, then the default encoding of 8bit
    'is used and no explicit ENCODING parameter is needed.
    '
    'Type value: A single value. The default is binary value. It can also
    'be reset to uri value. The uri value can be used to specify a value
    'outside of this MIME entity.
    '
    'Type special notes: The type can include the type parameter "TYPE" to
    'specify the graphic image format type. The TYPE parameter values MUST
    'be one of the IANA registered image formats or a non-standard image
    'format.
    '
    'Type example:
    '   PHOTO;VALUE=uri:http://www.abc.com/pub/photos/jqpublic.gif
    '
    '   PHOTO;ENCODING=b;TYPE=JPEG:MIICajCCAdOgAwIBAgICBEUwDQYJKoZIhvcN
    '   AQEEBQAwdzELMAkGA1UEBhMCVVMxLDAqBgNVBAoTI05ldHNjYXBlIENvbW11bm
    '   ljYXRpb25zIENvcnBvcmF0aW9uMRwwGgYDVQQLExNJbmZvcm1hdGlvbiBTeXN0
    '   <...remainder of "B" encoded binary data...>
    '''<summary>Registration of text/directory MIME type BDAY.</summary>
    Public Property BirthDay() As Nullable(Of DateTime) = Nothing
    ' Url: http://tools.ietf.org/html/rfc2426#section-3.1.5
    ' 
    ' Examples:  
    '   BDAY:1996-04-15
    '   BDAY:1953-10-15T23:10:00Z
    '   BDAY:1987-09-27T08:30:00-06:00    

    ''' <summary>Specify the electronic mail address for communication with the object the vCard represents.</summary>
    Public ReadOnly Property Addresses() As New List(Of vCardAddress)

    ''' <summary>
    ''' Specify the formatted text corresponding to delivery
    ''' address of the object the vCard represents.
    ''' </summary>
    Public ReadOnly Property AddressLabel(ByVal adress As vCardAddress) As String
      ' Url: http://tools.ietf.org/html/rfc2426#section-3.2.2
      ' 
      '3.2.2 LABEL Type Definition
      '
      'Subject: Registration of text/directory MIME type LABEL
      '
      'Type name: LABEL
      '
      'Type purpose: To specify the formatted text corresponding to delivery
      'address of the object the vCard represents.
      '
      'Type encoding: 8bit
      '
      'Type value: A single text value.
      '
      'Type special notes: The type value is formatted text that can be used
      'to present a delivery address label for the vCard object. The type
      'can include the type parameter "TYPE" to specify delivery label type.
      'The TYPE parameter values can include "dom" to indicate a domestic
      'delivery label; "intl" to indicate an international delivery label;
      '"postal" to indicate a postal delivery label; "parcel" to indicate a
      'parcel delivery label; "home" to indicate a delivery label for a
      'residence; "work" to indicate delivery label for a place of work; and
      '"pref" to indicate the preferred delivery label when more than one
      'label is specified. These type parameter values can be specified as a
      'parameter list (i.e., "TYPE=dom;TYPE=postal") or as a value list
      '(i.e., "TYPE=dom,postal"). This type is based on semantics of the
      'X.520 geographical and postal addressing attributes. The default is
      '"TYPE=intl,postal,parcel,work". The default can be overridden to some
      'other set of values by specifying one or more alternate values. For
      'example, the default can be reset to "TYPE=intl,post,parcel,home" to
      'specify an international delivery label for both postal and parcel
      'delivery to a residential location.
      '
      'Type example: A multi-line address label.
      '   LABEL;TYPE=dom,home,postal,parcel:Mr.John Q. Public\, Esq.\n
      '   Mail Drop: TNE QB\n123 Main Street\nAny Town\, CA  91921-1234
      '   \nU.S.A.
      Get
        Dim sb = New StringBuilder
        sb.Append($"LABEL;{adress.AddressTypeString};ENCODING=QUOTED-PRINTABLE:")

        If (adress.AddressType.Contains(vCardAddressTypes.work)) _
        AndAlso (Not String.IsNullOrEmpty(Organization.OrganizationalName)) Then
          sb.Append($"{Organization.OrganizationalName}{vCard.MaskedCrLf}")
        End If

        sb.Append($"{_FullName.GivenName} {_FullName.FamilyName}{vCard.MaskedCrLf}")
        sb.Append($"{adress.Street}{vCard.MaskedCrLf}")
        sb.Append($"{adress.PostalCode} {adress.Locality}")

        Return sb.ToString
      End Get
    End Property

    ''' <summary>Specify the telephone number for telephony communication with the object the vCard represents.</summary>
    Public ReadOnly Property PhoneNumbers() As New List(Of vCardPhoneNumber)

    '''<summary>Specify the electronic mail address for communication with the object the vCard represents.</summary>
    Public ReadOnly Property MailAddresses() As New List(Of vCardMaillAddress)

    ''' <summary>Specify the type of electronic mail software that is used by the individual associated with the vCard.</summary>
    Public Property Mailer() As String = String.Empty
    ' Url: http://tools.ietf.org/html/rfc2426#section-3.3.3
    ' 
    '3.3.3 MAILER Type Definition
    '
    'Subject: Registration of text/directory MIME type MAILER
    '
    'Type name: MAILER
    '
    'Type purpose: To specify the type of electronic mail software that is
    'used by the individual associated with the vCard.
    '
    'Type encoding: 8bit
    '
    'Type value: A single text value.
    '
    'Type special notes: This information can provide assistance to a
    'correspondent regarding the type of data representation which can be
    'used, and how they can be packaged. This property is based on the
    'private MIME type X-Mailer that is generally implemented by MIME user
    'agent products.
    '
    'Type example:
    '   MAILER:PigeonMail 2.1


    ''' <summary>Specify the job title, functional position or function of the object the vCard represents.</summary>
    Public Property Title() As String
    ' Url: http://tools.ietf.org/html/rfc2426#section-3.5.1
    ' 
    '3.5.1 TITLE Type Definition
    '
    'Subject: Registration of text/directory MIME type TITLE
    '
    'Type name: TITLE
    '
    'Type purpose: To specify the job title, functional position or
    'function of the object the vCard represents.
    '
    'Type encoding: 8bit
    '
    'Type value: A single text value.
    '
    'Type special notes: This type is based on the X.520 Title attribute.
    '
    'Type(example)
    '   TITLE:Director\, Research and Development

    ''' <summary>Specify information concerning the role, occupation, or business category of the object the vCard represents.</summary>
    Public Property Role() As String
    ' Url: http://tools.ietf.org/html/rfc2426#section-3.5.2
    ' 
    '3.5.2 ROLE Type Definition
    '
    'Subject: Registration of text/directory MIME type ROLE
    '
    'Type name: ROLE
    '
    'Type purpose: To specify information concerning the role, occupation,
    'or business category of the object the vCard represents.
    '
    'Type encoding: 8bit
    '
    'Type value: A single text value.
    '
    'Type special notes: This type is based on the X.520 Business Category
    'explanatory attribute. This property is included as an organizational
    'type to avoid confusion with the semantics of the TITLE type and
    'incorrect usage of that type when the semantics of this type is
    'intended.
    '
    'Type example:
    '   ROLE:Programmer


    ''' <summary>Specify a graphic image of a logo associated with the object the vCard represents.</summary>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public ReadOnly Property Logo() As New vCardImage
    ' Url: http://tools.ietf.org/html/rfc2426#section-3.5.3
    ' 
    '3.5.3 LOGO Type Definition
    '
    'Subject: Registration of text/directory MIME type LOGO
    '
    'Type name: LOGO
    '
    'Type purpose: To specify a graphic image of a logo associated with
    'the object the vCard represents.
    '
    'Type encoding: The encoding MUST be reset to "b" using the ENCODING
    'parameter in order to specify inline, encoded binary data. If the
    'value is referenced by a URI value, then the default encoding of 8bit
    'is used and no explicit ENCODING parameter is needed.
    '
    'Type value: A single value. The default is binary value. It can also
    'be reset to uri value. The uri value can be used to specify a value
    'outside of this MIME entity.
    '
    'Type special notes: The type can include the type parameter "TYPE" to
    'specify the graphic image format type. The TYPE parameter values MUST
    'be one of the IANA registered image formats or a non-standard image
    'format.
    '
    'Type example:
    '   LOGO;VALUE=uri:http://www.abc.com/pub/logos/abccorp.jpg
    '   LOGO;ENCODING=b;TYPE=JPEG:MIICajCCAdOgAwIBAgICBEUwDQYJKoZIhvcN
    '   AQEEBQAwdzELMAkGA1UEBhMCVVMxLDAqBgNVBAoTI05ldHNjYXBlIENvbW11bm
    '   ljYXRpb25zIENvcnBvcmF0aW9uMRwwGgYDVQQLExNJbmZvcm1hdGlvbiBTeXN0
    '   <...the remainder of "B" encoded binary data...>

    ''' <summary>Specify the organizational name and units associated with the vCard.</summary>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public ReadOnly Property Organization() As New vCardOrganization


    ''' <summary>Specify application category information about the vCard.</summary>
    Public ReadOnly Property Categories() As New List(Of String)
    ' Url: http://tools.ietf.org/html/rfc2426#section-3.6.1
    ' 
    '3.6.1 CATEGORIES Type Definition
    '
    'Subject: Registration of text/directory MIME type CATEGORIES
    '
    'Type name: CATEGORIES
    '
    'Type purpose: To specify application category information about the
    'vCard.
    '
    'Type encoding: 8bit
    '
    'Type value: One or more text values separated by a COMMA character
    '(ASCII decimal 44).
    '
    'Type example:
    '   CATEGORIES:TRAVEL AGENT
    '   CATEGORIES:INTERNET,IETF,INDUSTRY,INFORMATION TECHNOLOGY

    ''' <summary>Specify supplemental information or a comment that is associated with the vCard.</summary>
    Public Property Note() As String
    ' Url: http://tools.ietf.org/html/rfc2426#section-3.6.2
    ' 
    '3.6.2 NOTE Type Definition
    '
    'Subject: Registration of text/directory MIME type NOTE
    '
    'Type name: NOTE
    '
    'Type purpose: To specify supplemental information or a comment that
    'is associated with the vCard.
    '
    'Type encoding: 8bit
    '
    'Type value: A single text value.
    '
    'Type special notes: The type is based on the X.520 Description
    'attribute.
    '
    'Type example:
    '   NOTE:This fax number is operational 0800 to 1715
    '   EST\, Mon-Fri.


    ''' <summary>Specify the identifier for the product that created the vCard object.</summary>
    Public Property ProdId() As String = "- ## vCardBuilder ## Ver. 1.0 ## DE ## -"
    ' Url: http://tools.ietf.org/html/rfc2426#section-3.6.3
    ' 
    '3.6.3 PRODID Type Definition
    '
    'Subject: Registration of text/directory MIME type PRODID
    '
    'Type name: PRODID
    '
    'Type purpose: To specify the identifier for the product that created
    'the vCard object.
    '
    'Type encoding: 8-bit
    '
    'Type value: A single text value.
    '
    'Type special notes: Implementations SHOULD use a method such as that
    'specified for Formal Public Identifiers in ISO 9070 to assure that
    'the text value is unique.
    '
    'Type example:
    '   PRODID:-//ONLINE DIRECTORY//NONSGML Version 1//EN


    ''' <summary>Specify revision information about the current.</summary>
    Public Property Revision() As Nullable(Of DateTime) = Nothing
    ' Url: http://tools.ietf.org/html/rfc2426#section-3.6.4
    ' 
    '3.6.4 REV Type Definition
    '
    'Subject: Registration of text/directory MIME type REV
    '
    'Type name: REV
    '
    'Type purpose: To specify revision information about the current
    'vCard.
    '
    'Type encoding: 8-bit
    '
    'Type value: The default is a single date-time value. Can also be
    'reset to a single date value.
    '
    'Type special notes: The value distinguishes the current revision of
    'the information in this vCard for other renditions of the
    'information.
    '
    'Type example:
    '   REV:1995-10-31T22:27:10Z
    '   REV:1997-11-15

    ''' <summary>specify the family name or given name text to be used for national-language-specific sorting of the FN and N types.</summary>
    Public Property SortString() As String
    ' Url: http://tools.ietf.org/html/rfc2426#section-3.6.5
    ' 
    '3.6.5 SORT-STRING Type Definition
    '
    'Subject: Registration of text/directory MIME type SORT-STRING
    '
    'Type Name: SORT-STRING
    '
    'Type purpose: To specify the family name or given name text to be
    'used for national-language-specific sorting of the FN and N types.
    '
    'Type encoding: 8bit
    '
    'Type value: A single text value.
    '
    'Type special notes: The sort string is used to provide family name or
    'given name text that is to be used in locale- or national-language-
    'specific sorting of the formatted name and structured name types.
    'Without this information, sorting algorithms could incorrectly sort
    'this vCard within a sequence of sorted vCards.  When this type is
    'present in a vCard, then this family name or given name value is used
    'for sorting the vCard.
    '
    'Type examples: For the case of family name sorting, the following
    'examples define common sort string usage with the FN and N types.
    '   FN:Rene van der Harten
    '   N:van der Harten;Rene;J.;Sir;R.D.O.N.
    '   SORT-STRING:Harten
    '
    '   FN:Robert Pau Shou Chang
    '   N:Pau;Shou Chang;Robert
    '   SORT-STRING:Pau
    '
    '   FN:Osamu Koura
    '   N:Koura;Osamu
    '   SORT-STRING:Koura
    '
    '   FN:Oscar del Pozo
    '   N:del Pozo Triscon;Oscar
    '   SORT-STRING:Pozo
    '
    '   FN:Chistine d'Aboville
    '   N:d'Aboville;Christine
    '   SORT-STRING:Aboville

    ''' <summary>Specify a value that represents a globally unique identifier corresponding to the individual or resource associated with the vCard.</summary>
    Public Property Uid() As String
    ' Url: http://tools.ietf.org/html/rfc2426#section-3.6.7
    ' 
    '3.6.7 UID Type Definition
    '
    'Subject: Registration of text/directory MIME type UID
    '
    'Type name: UID
    '
    'Type purpose: To specify a value that represents a globally unique
    'identifier corresponding to the individual or resource associated
    'with the vCard.
    '
    'Type encoding: 8bit
    '
    'Type value: A single text value.
    '
    'Type special notes: The type is used to uniquely identify the object
    'that the vCard represents.
    '
    'The type can include the type parameter "TYPE" to specify the format
    'of the identifier. The TYPE parameter value should be an IANA
    'registered identifier format. The value can also be a non-standard
    'format.
    '
    'Type example:
    '   UID:19950401-080045-40000F192713-0052

    ''' <summary>Specify a uniform resource locator associated with the object that the vCard refers to.</summary>
    Public Property Urls() As New List(Of vCardUrl)

    ''' <summary>specify the version of the vCard specification used to format this vCard.</summary>
    Public Property Version() As String = "3.0"
    ' Url: http://tools.ietf.org/html/rfc2426#section-3.6.9
    ' 
    '3.6.9 VERSION Type Definition
    '
    'Subject: Registration of text/directory MIME type VERSION
    '
    'Type name: VERSION
    '
    'Type purpose: To specify the version of the vCard specification used
    'to format this vCard.
    '
    'Type encoding: 8bit
    '
    'Type value: A single text value.
    '
    'Type special notes: The property MUST be present in the vCard object.
    'The value MUST be "3.0" if the vCard corresponds to this
    'specification.
    '
    'Type example:
    '   VERSION:3.0

    ''' <summary>Specify the Instant Messenger Address used by the vCard owner.</summary>
    Public Property InstantMessengerAddress() As String
    'Subject: Registration of text/directory MIME type X-MS-IMADDRESS
    '
    'Type name: X-MS-IMADDRESS
    '
    'Type purpose: To specify the Instant Messenger Address used by the vCard owner.
    '
    'Type encoding: 8bit
    '
    'Type value: A single text value.
    '
    'Type special notes:
    'This type is only implemented for Outlook support.
    '
    'Type example:
    '   X-MS-IMADDRESS:icqUser55
#End Region

#Region " --------------->> Ereignismethoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Overrides Function ToString() As String

      Dim sb = New StringBuilder
      sb.AppendLine("BEGIN:VCARD")
      sb.AppendLine("VERSION:2.1")
      sb.AppendLine($"FN:{_CommonName}")
      sb.AppendLine(_FullName.ToString)

      If _Nicknames.Count > 0 Then sb.AppendLine($"NICKNAME:{String.Join(",", _Nicknames.ToArray)}")
      If _Photo.Image IsNot Nothing Then sb.AppendLine($"PHOTO;{ _Photo.ToString}")
      If _BirthDay.HasValue Then sb.AppendLine($"BDAY:{ _BirthDay.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")}")

      If _Addresses.Any Then

        _Addresses.ForEach _
        (
          Sub(x)
            sb.AppendLine(x.ToString)
            sb.AppendLine(Me.AddressLabel(x))
          End Sub
        )
      End If

      If _PhoneNumbers.Any Then
        _PhoneNumbers.ForEach(Sub(x) sb.AppendLine(x.ToString))
      End If

      If _MailAddresses.Any Then
        _MailAddresses.ForEach(Sub(x) sb.AppendLine(x.ToString))
      End If

      If Not String.IsNullOrEmpty(_Mailer) Then
        sb.AppendLine($"MAILER:{_Mailer}")
      End If

      With TimeZoneInfo.Local.BaseUtcOffset
        sb.AppendLine($"TZ:{ .Hours.ToString("00")}:{ .Minutes.ToString("00")}")
      End With

      If Not String.IsNullOrEmpty(_Title) Then
        sb.AppendLine($"TITLE:{_Title}")
      End If

      If Not String.IsNullOrEmpty(_Role) Then
        sb.AppendLine($"ROLE:{_Role}")
      End If

      If _Logo.Image IsNot Nothing Then
        sb.AppendLine($"LOGO;{_Photo.ToString}")
      End If

      If Not String.IsNullOrEmpty(_Organization.OrganizationalName) Then
        sb.AppendLine(_Organization.ToString)
      End If

      If _Categories.Any Then
        sb.AppendLine($"CATEGORIES:{String.Join(",", _Categories.ToArray)}")
      End If

      If Not String.IsNullOrEmpty(_Note) Then
        sb.AppendLine($"NOTE;ENCODING=QUOTED-PRINTABLE:{_Note.Replace(vbCrLf, vCard.MaskedCrLf)}")
      End If

      sb.AppendLine("PRODID:" & _ProdId)

      If _Revision.HasValue Then
        sb.AppendLine($"REV:{_BirthDay.Value.ToString("yyyy-MM-dd")}")
      End If

      If Not String.IsNullOrEmpty(_SortString) Then
        sb.AppendLine($"SORT-STRING:{_SortString}")
      End If

      If Not String.IsNullOrEmpty(_Uid) Then
        sb.AppendLine($"UID:{_Uid}")
      End If

      If _Urls.Any Then
        _Urls.ForEach(Sub(x) sb.AppendLine(x.ToString))
      End If

      If Not String.IsNullOrEmpty(_InstantMessengerAddress) Then
        sb.AppendLine($"X-MS-IMADDRESS:{_InstantMessengerAddress}")
      End If

      sb.AppendLine($"VERSION:{_Version}")
      sb.AppendLine("END:VCARD")
      Return sb.ToString
    End Function

    '''<summary>Save the vCard.</summary>
    ''' <param name="fileName">The name of the save file.</param>
    Public Sub Save(ByVal fileName As String)

      With My.Computer.FileSystem
        ' UTF8 wäre cooler, aber dann werden die Karten von Outlook nicht mehr erkannt
        .WriteAllText(fileName, Me.ToString, False, Encoding.Default)
      End With
    End Sub
#End Region

  End Class

End Namespace
