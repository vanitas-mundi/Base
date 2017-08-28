Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
Imports BCW.Foundation.Base.vCardBuilder.Enums
#End Region

Namespace vCardBuilder
  '''<summary>Specify a uniform resource locator associated with the object that the vCard refers to.</summary>
  Public Class vCardUrl

#Region " ---------------------- Class Description "
    'Url: http://tools.ietf.org/html/rfc2426#section-3.6.8
    '
    '3.6.8 Url Type Definition
    '
    'Subject: Registration of text/directory MIME type Url
    '
    'Type name: Url
    '
    'Type purpose: To specify a uniform resource locator associated with
    'the object that the vCard refers to.
    '
    'Type encoding: 8bit
    '
    'Type value: A single uri value.
    '
    'Outlook support: 
    'For Outlook support the type can include the type parameter "TYPE" 
    'to specify intended use for the Url. The TYPE parameter values can include:
    '"home" to indicate a Url associated with a residence, "work" to indicate 
    'a telephone number associated with a place of work.
    '
    'Type example:
    '   Url:http://www.swbyps.restaurant.french/~chezchic.html
#End Region

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
    End Sub

    Public Sub New(ByVal url As String)
      _url = url
    End Sub

    Public Sub New(ByVal url As String, ByVal urlType() As vCardUrlTypes)
      Me.New(url)

      If urlType Is Nothing Then Return
      _UrlType.AddRange(urlType)
    End Sub
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Property Url() As String

    Public Property UrlType() As New List(Of vCardUrlTypes)

    Public ReadOnly Property UrlTypeString() As String
      Get
        Dim result = _UrlType.Select(Function(x) x.ToString).ToArray
        Return $"TYPE={String.Join(",", result)}"
      End Get
    End Property
#End Region

#Region " --------------->> Ereignismethoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Overrides Function ToString() As String

      Dim sb = New StringBuilder("Url")
      If _UrlType.Any Then sb.Append($";{Me.UrlTypeString}")
      sb.Append($":{_Url}")
      Return sb.ToString
    End Function
#End Region

  End Class

End Namespace