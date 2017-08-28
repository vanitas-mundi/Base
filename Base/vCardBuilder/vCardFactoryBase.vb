Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports "
Imports BCW.Foundation.Base.vCardBuilder.Enums
#End Region

Namespace vCardBuilder

  Public MustInherit Class VCardFactoryBase

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "
    Private ReadOnly Property IsHomeString As String = "privat"
    Private ReadOnly Property IsWorkString As String = "dienstlich"
#End Region

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
    Protected Function IsHome(ByVal s As String) As Boolean
      Return s.ToLower.Contains(Me.IsHomeString)
    End Function

    Protected Function IsWork(ByVal s As String) As Boolean
      Return s.ToLower.Contains(Me.IsWorkString)
    End Function

    Protected Sub AddMail(ByVal card As vCard, ByVal value As String)

      Dim mail = New vCardMaillAddress(value, Nothing)
      mail.MailType.Clear()
      mail.MailType.Add(vCardMailTypes.internet)
      card.MailAddresses.Add(mail)
    End Sub

    Protected Sub AddFax(ByVal card As vCard, ByVal name As String, ByVal value As String)

      Dim fax = New vCardPhoneNumber(value, Nothing)
      fax.PhoneNumberType.Clear()
      fax.PhoneNumberType.Add(vCardPhoneNumberTypes.fax)

      Select Case True
        Case IsHome(name)
          fax.PhoneNumberType.Add(vCardPhoneNumberTypes.home)
        Case IsWork(name)
          fax.PhoneNumberType.Add(vCardPhoneNumberTypes.work)
      End Select

      card.PhoneNumbers.Add(fax)
    End Sub

    Protected Sub AddMobile(ByVal card As vCard, ByVal value As String)

      Dim mobile = New vCardPhoneNumber(value, Nothing)
      mobile.PhoneNumberType.Clear()
      mobile.PhoneNumberType.Add(vCardPhoneNumberTypes.voice)
      mobile.PhoneNumberType.Add(vCardPhoneNumberTypes.cell)
      card.PhoneNumbers.Add(mobile)
    End Sub

    Protected Sub AddPhone(ByVal card As vCard, ByVal name As String, ByVal value As String)

      Dim phone = New vCardPhoneNumber(value, Nothing)
      phone.PhoneNumberType.Clear()
      phone.PhoneNumberType.Add(vCardPhoneNumberTypes.voice)

      Select Case True
        Case IsHome(name)
          phone.PhoneNumberType.Add(vCardPhoneNumberTypes.home)
        Case IsWork(name)
          phone.PhoneNumberType.Add(vCardPhoneNumberTypes.work)
      End Select

      card.PhoneNumbers.Add(phone)
    End Sub

    Protected Sub AddUrl(ByVal card As vCard, ByVal name As String, ByVal value As String)

      Dim Url = New vCardUrl(value)

      Select Case True
        Case IsHome(name)
          Url.UrlType.Add(vCardUrlTypes.Home)
        Case IsWork(name)
          Url.UrlType.Add(vCardUrlTypes.Work)
      End Select

      card.Urls.Add(Url)
    End Sub
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region

  End Class

End Namespace
