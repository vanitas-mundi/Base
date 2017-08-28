Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
Imports BCW.Foundation.Base.vCardBuilder.Enums
#End Region

Namespace vCardBuilder

  '''<summary>Specify an image or photograph information.</summary>
  Public Class vCardImage

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
    Private _url As String
    Private _image As Byte()
    Private _linkType As vCardImageLinkTypes
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
    End Sub

    Public Sub New(ByVal photo As Byte())
      Me.Image = photo
    End Sub

    Public Sub New(ByVal base64String As String)
      Me.Image = Convert.FromBase64String(base64String)
    End Sub

    Public Sub New(ByVal url As String, ByVal linkType As vCardImageLinkTypes)

      _url = url
      _linkType = linkType
      Dim byteArray = DownLoadFile(_url)

      If linkType = vCardImageLinkTypes.Link Then
        _image = byteArray
      Else
        Me.Image = byteArray
      End If
    End Sub
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Url des Bildes.</summary>
    Public Property Url() As String
      Get
        Return _url
      End Get
      Set(ByVal value As String)
        _url = value
        _linkType = vCardImageLinkTypes.Link
        _image = DownLoadFile(_url)
      End Set
    End Property

    '''<summary>Url des Bildes.</summary>
    Public WriteOnly Property Url(ByVal linkType As vCardImageLinkTypes) As String
      Set(ByVal value As String)

        _url = value
        _linkType = linkType

        Dim byteArray = DownLoadFile(_url)

        If linkType = vCardImageLinkTypes.Link Then
          _image = byteArray
        Else
          Me.Image = byteArray
        End If
      End Set
    End Property

    Public Property Base64String() As String
      Get
        Try
          Return Convert.ToBase64String(_image)
        Catch ex As Exception
          Return Nothing
        End Try
      End Get
      Set(ByVal value As String)
        Me.Image = Convert.FromBase64String(value)
      End Set
    End Property

    Public Property Image() As Byte()
      Get
        Return _image
      End Get
      Set(ByVal value As Byte())
        _url = String.Empty
        _linkType = vCardImageLinkTypes.Embedding
        _image = value
      End Set
    End Property
#End Region

#Region " --------------->> Ereignismethoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
    Private Function DownLoadFile(ByVal Url As String) As Byte()

      With My.Computer.FileSystem
        Dim fileName = .CombinePath(.SpecialDirectories.Temp, .GetTempFileName)
        My.Computer.Network.DownloadFile(Url, fileName)
        Return .ReadAllBytes(fileName)
      End With
    End Function
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Overrides Function ToString() As String

      If _linkType = vCardImageLinkTypes.Embedding Then
        Dim sb = New StringBuilder
        'sb.AppendLine("PHOTO;ENCODING=b;TYPE=JPEG:")
        sb.AppendLine("TYPE=JPEG;ENCODING=BASE64:")
        sb.AppendLine(Me.Base64String)
        sb.AppendLine()
        Return sb.ToString
      Else
        Return $"VALUE=uri:{Me.Url}"
      End If
    End Function
#End Region

  End Class

End Namespace