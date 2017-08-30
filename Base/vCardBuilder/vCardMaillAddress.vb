Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.vCardBuilder.Enums
#End Region

Namespace vCardBuilder

  '''<summary>Specify the electronic mail address for communication with the object the vCard represents.</summary>
  Public Class vCardMaillAddress

#Region " ---------------------- Class Description "
    'Url: http://tools.ietf.org/html/rfc2426#section-3.3.2
    '
    'Type name: EMAIL
    '
    'Type purpose: To specify the electronic mail address for
    'communication with the object the vCard represents.
    '
    'Type encoding: 8bit
    '
    'Type value: A single text value.
    '
    'Type special notes: The type can include the type parameter "TYPE" to
    'specify the format or preference of the electronic mail address. The
    'TYPE parameter values can include: "internet" to indicate an Internet
    'addressing type, "x400" to indicate a X.400 addressing type or "pref"
    'to indicate a preferred-use email address when more than one is
    'specified. Another IANA registered address type can also be
    'specified. The default email type is "internet". A non-standard value
    'can also be specified.
    '
    'Type example:
    '     EMAIL;TYPE=internet:jqpublic@xyz.dom1.com
    '     EMAIL;TYPE=internet:jdoe@isp.net
    '     EMAIL;TYPE=internet,pref:jane_doe@abc.com
#End Region

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
    End Sub

    Public Sub New(ByVal mailAddress As String, ByVal mailType() As vCardMailTypes)
      _MailAddress = mailAddress
      If mailType Is Nothing Then Return

      _MailType.AddRange(mailType)
    End Sub
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Property MailAddress() As String

    Public Property MailType() As New List(Of vCardMailTypes)

    Public ReadOnly Property MailTypeString() As String
      Get
        Dim result = String.Join(",", _MailType.Select(Function(x) x.ToString))
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
      Return $"EMAIL;{Me.MailTypeString}:{_MailAddress}"
    End Function
#End Region

  End Class

End Namespace