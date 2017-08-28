Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports "
Imports System.Drawing
Imports BCW.Etc.Enums.CommunicationModule
Imports BCW.Etc.Enums
#End Region

Namespace Converter.vCardBuilder

	Public Class vCardContactFactory

		Inherits vCardFactoryBase
		Implements IVCardFactory

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
		Private _contact As Object
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New(ByVal connectionString As String, ByVal contact As Object)
			_contact = contact
			_connectionString = connectionString
		End Sub
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
		Private Function GetPropertyByReflection(Of T) _
		(ByVal o As Object, ByVal propertyName As String) As T
			Return CType(o.GetType.InvokeMember _
			(propertyName, Reflection.BindingFlags.GetProperty, Nothing, o, Nothing), T)
		End Function

		Private Function GetNote() As String
			Dim comment = GetPropertyByReflection(Of Object)(_contact, "Comment")
			Return comment.GetType.InvokeMember _
			("Text", Reflection.BindingFlags.GetProperty, Nothing, comment, Nothing).ToString
		End Function

		Private Sub AddCommunication(ByVal card As vCard, ByVal c As Object)
			Dim value = GetPropertyByReflection(Of String)(c, "Value")
			Dim name = GetPropertyByReflection(Of String)(c, "Name")
			Select Case GetPropertyByReflection(Of CommunicationTypes)(c, "CommunicationType")
			Case CommunicationTypes.EMail
				AddMail(card, value)
			Case CommunicationTypes.Fax
				AddFax(card, name, value)
			Case CommunicationTypes.Messenger
				card.InstantMessengerAddress = value
			Case CommunicationTypes.Mobile
				AddMobile(card, value)
			Case CommunicationTypes.Phone
				AddPhone(card, name, value)
			Case CommunicationTypes.Url
				AddUrl(card, name, value)
			End Select
		End Sub

		Private Sub AddAddress(ByVal card As vCard, ByVal a As Object)

			Dim adr = New vCardAddress
			adr.AddressType.Clear()
			Dim name = GetPropertyByReflection(Of String)(a, "Name")

			Select Case True
			Case IsHome(name)
				adr.AddressType.Add(vCardAddress.vCardAddressTypes.home)
			Case IsWork(name)
				adr.AddressType.Add(vCardAddress.vCardAddressTypes.work)
			End Select

			If GetPropertyByReflection(Of YesNoOptions)(a, "MailingAddress") = YesNoOptions.Yes Then
				adr.AddressType.Add(vCardAddress.vCardAddressTypes.pref)
			End If

			adr.CountryName = GetPropertyByReflection(Of String)(a, "Country")
			adr.ExtendedAddress = GetPropertyByReflection(Of String)(a, "StreetAdditional")
			adr.Locality = GetPropertyByReflection(Of String)(a, "City")
			adr.PostalCode = GetPropertyByReflection(Of String)(a, "Postcode")
			adr.Region = GetPropertyByReflection(Of String)(a, "FederalState")
			adr.Street = GetPropertyByReflection(Of Object)(a, "Street").ToString
			card.Addresses.Add(adr)
		End Sub
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Function Create() As vCard Implements IVCardFactory.Create

			If _contact Is Nothing Then Return Nothing

			Dim card = New vCard

			With _contact.GetType
				card.FullName.FamilyName = GetPropertyByReflection(Of String)(_contact, "LastName")
				card.FullName.GivenName = GetPropertyByReflection(Of String)(_contact, "FirstName")
				card.FullName.HonorificPrefixes.Add(GetPropertyByReflection(Of String)(_contact, "TitleGerman"))
				card.CommonName = String.Concat(card.FullName.FamilyName, ", ", card.FullName.GivenName)
				card.BirthDay = GetPropertyByReflection(Of DateTime)(_contact, "DateOfBirth")
				card.Photo.Image = GetPropertyByReflection(Of Image)(_contact, "Photo")
				card.Note = GetNote()

				GetPropertyByReflection(Of IEnumerable(Of Object))(_contact, "Communications").ToList.ForEach(Sub(c) AddCommunication(card, c))
				GetPropertyByReflection(Of IEnumerable(Of Object))(_contact, "ContactAddresses").ToList.ForEach(Sub(a) AddAddress(card, a))
			End With

			Return card
		End Function
#End Region

	End Class

End Namespace
