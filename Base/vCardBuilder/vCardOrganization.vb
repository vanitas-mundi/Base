Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
#End Region

Namespace vCardBuilder

  ''' <summary>Specify the organizational name and units associated with the vCard.</summary>
  Public Class vCardOrganization

#Region " ---------------------- Class Description "
    'Url: http://tools.ietf.org/html/rfc2426#section-3.5.5
    '
    '3.5.5 ORG Type Definition
    '
    'Subject: Registration of text/directory MIME type ORG
    '
    'Type name: ORG
    '
    'Type purpose: To specify the organizational name and units associated
    'with the vCard.
    '
    'Type encoding: 8bit
    '
    'Type value: A single structured text value consisting of components
    'separated the SEMI-COLON character (ASCII decimal 59).
    '
    'Type special notes: The type is based on the X.520 Organization Name
    'and Organization Unit attributes. The type value is a structured type
    'consisting of the organization name, followed by one or more levels
    'of organizational unit names.
    '
    'Type example: A type value consisting of an organizational name,
    'organizational unit #1 name and organizational unit #2 name.
    '   ORG:ABC\, Inc.;North American Division;Marketing
#End Region

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
    End Sub

    Public Sub New(ByVal organizationalName As String, ByVal organizationalUnitNames As IEnumerable(Of String))

      _OrganizationalName = organizationalName
      If organizationalUnitNames Is Nothing Then Return

      _OrganizationalUnitNames.AddRange(organizationalUnitNames)
    End Sub
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Property OrganizationalName() As String

    Public ReadOnly Property OrganizationalUnitNames() As New List(Of String)
#End Region

#Region " --------------->> Ereignismethoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Overrides Function ToString() As String
      Dim sb = New StringBuilder
      sb.Append($"ORG:{_OrganizationalName}")
      _OrganizationalUnitNames.ForEach(Sub(s) sb.Append($";{s}"))
      Return sb.ToString
    End Function
#End Region

  End Class

End Namespace