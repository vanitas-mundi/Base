Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
#End Region

Namespace vCardBuilder

  '''<summary>Specify the formatted text corresponding to the name of the object the vCard represents.</summary>
  Public Class vCardFullName

#Region " ---------------------- Class Description "
    'Url: http://tools.ietf.org/html/rfc2426#section-3.1.2
    '
    '3.1.2 N Type Definition
    '
    'Subject: Registration of text/directory MIME type N
    '
    'Type name: N
    '
    'Type purpose: To specify the components of the name of the object the
    'vCard represents.
    '
    'Type encoding: 8bit
    '
    'Type value: A single structured text value. Each component can have
    'multiple values.
    '
    'Type special note: The structured type value corresponds, in
    'sequence, to the Family Name, Given Name, Additional Names, Honorific
    'Prefixes, and Honorific Suffixes. The text components are separated
    'by the SEMI-COLON character (ASCII decimal 59). Individual text
    'components can include multiple text values (e.g., multiple
    'Additional Names) separated by the COMMA character (ASCII decimal
    '44). This type is based on the semantics of the X.520 individual name
    'attributes. The property MUST be present in the vCard object.
    '
    'Type example:
    '  N:Public;John;Quinlan;Mr.;Esq.
    '  N:Stevenson;John;Philip,Paul;Dr.;Jr.,M.D.,A.C.P.
#End Region

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
    End Sub

    Public Sub New _
    (ByVal familyName As String _
    , ByVal givenName As String _
    , ByVal additionalNames As IEnumerable(Of String) _
    , ByVal honorificPrefixes As IEnumerable(Of String) _
    , ByVal honorificSuffixes As IEnumerable(Of String))

      _familyName = familyName
      _givenName = givenName

      If additionalNames IsNot Nothing Then
        _AdditionalNames.AddRange(additionalNames)
      End If

      If honorificPrefixes IsNot Nothing Then
        _HonorificPrefixes.AddRange(honorificPrefixes)
      End If

      If honorificSuffixes IsNot Nothing Then
        _HonorificSuffixes.AddRange(honorificSuffixes)
      End If
    End Sub
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Property FamilyName() As String

    Public Property GivenName() As String

    Public ReadOnly Property AdditionalNames() As New List(Of String)

    Public ReadOnly Property HonorificPrefixes() As New List(Of String)

    Public ReadOnly Property HonorificSuffixes() As New List(Of String)
#End Region

#Region " --------------->> Ereignismethoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Overrides Function ToString() As String
      Dim sb = New StringBuilder
      sb.Append($"N:{_FamilyName};{_GivenName}")

      sb.Append(";")
      If _AdditionalNames.Any Then
        sb.Append(String.Join(",", _AdditionalNames.ToArray))
      End If

      sb.Append(";")
      If _HonorificPrefixes.Any Then
        sb.Append(String.Join(",", _HonorificPrefixes.ToArray))
      End If

      sb.Append(";")
      If _HonorificSuffixes.Any Then
        sb.Append(String.Join(",", _HonorificSuffixes.ToArray))
      End If

      Return sb.ToString
    End Function
#End Region

  End Class

End Namespace