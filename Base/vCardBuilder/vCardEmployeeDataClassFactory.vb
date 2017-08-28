Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports "
Imports BCW.Etc.Enums.AddressModule
Imports BCW.Modules.PersonModule
Imports BCW.Data.DataAccess
Imports BCW.Etc.Enums.CommunicationModule
Imports BCW.Etc.Enums
Imports BCW.UI.Forms.UiEditors.Editors
Imports BCW.Foundation.Data.StatementBuilders.StatementBuildersMySql.Core
#End Region

Namespace Converter.vCardBuilder

	Public Class vCardEmployeeFactory

		Inherits vCardFactoryBase
		Implements IVCardFactory

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
		Private _person As Person
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Sub New(ByVal connectionString As String, ByVal dataObject As Person)
			_person = dataObject
			_connectionString = connectionString
		End Sub
#End Region

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
		Private Function GetTitle() As String
			Dim statement = String.Format("SELECT tele_v.GetFieldOfActivity({0})", _person.PersonId)
			Return DbResultMySql.Instance.ExecuteScalar(statement).ToString
		End Function

		Private Function GetAllowedCommunications() As List(Of Modules.CommunicationModule.Communication)

			Dim displayInInternet = BufferedValuesCommunication.DisplayInInternet.ToString
			Dim name = BufferedValuesCommunication.Name.ToString

			Return _person.Communications.Where(Function(c) _
			(c.BufferedValues.Item(displayInInternet).ToString = "Y") _
			OrElse (c.BufferedValues.Item(name).ToString.Contains("ienstlich")) _
			OrElse (c.BufferedValues.Item(name).ToString.Contains("urchwahl"))).ToList
		End Function

		Private Sub AddCommunication(ByVal card As vCard, ByVal c As Modules.CommunicationModule.Communication)

			Dim value = c.Value
			Dim name = c.Name

			Select Case c.CommunicationType
				Case CommunicationTypes.eMail
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

		Private Function GetAllowedAddresses() As List(Of Modules.AddressModule.Address)

			Dim displayInInternet = BufferedValuesAddress.DisplayInInternet.ToString
			Dim name = BufferedValuesAddress.Name.ToString

			Return _person.Addresses.Where(Function(a) _
			(a.BufferedValues.Item(displayInInternet).ToString = "Y") _
			OrElse (a.BufferedValues.Item(name).ToString.Contains("ienstlich"))).ToList
		End Function

		Private Sub AddAddress(ByVal card As vCard, ByVal a As BCW.Modules.AddressModule.Address)

			Dim adr = New vCardAddress
			adr.AddressType.Clear()

			Select Case True
				Case IsHome(a.Name)
					adr.AddressType.Add(vCardAddress.vCardAddressTypes.home)
				Case IsWork(a.Name)
					adr.AddressType.Add(vCardAddress.vCardAddressTypes.work)
			End Select

			If a.MailingAddress = YesNoOptions.Yes Then
				adr.AddressType.Add(vCardAddress.vCardAddressTypes.pref)
			End If

			adr.CountryName = a.Country
			adr.ExtendedAddress = a.StreetAdditional
			adr.Locality = a.City
			adr.PostalCode = a.Postcode
			adr.Region = a.FederalState
			adr.Street = a.Street.ToString
			card.Addresses.Add(adr)
		End Sub

		Private Function GetOrganizationDefaultStatement() As SelectBuilderMySql
			Dim sb = New SelectBuilderMySql
			sb.From.Add("tele_v.t_folders f")
			sb.From.Add("INNER JOIN tele_v.t_folder_items fi")
			sb.From.Add("ON f._rowid = fi.ParentFolderID")
			sb.Where.Add("(fi.Name = 'BCWRegister')")
			sb.Where.Add("AND (fi.ReferenceID = {0})", _person.PersonId)
			Return sb
		End Function

		Private Function GetNote() As String

			Dim sb = GetOrganizationDefaultStatement()
			sb.Select.Add("Comment")
			Dim comment = sb.ExecuteScalar(_connectionString).ToString.Replace(vbLf, vbCrLf)
			Return New Memo(comment).Text
		End Function

		Private Function GetOrganizationalName() As String
			Dim sb = GetOrganizationDefaultStatement()
			sb.Select.Add("datapool.GetAddressFieldByID(f.AnschriftenFID, 'FormatierteAnschrift')")
			Return sb.ExecuteScalar(_connectionString).ToString.Split(Chr(10))(0)
		End Function

		Private Function GetOrganizationalUnitNames() As String
			Dim sb = GetOrganizationDefaultStatement()
			sb.Select.Add("f.Name")
			Return sb.ExecuteScalar(_connectionString).ToString
		End Function
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Function Create() As vCard Implements IVCardFactory.Create

			If _person Is Nothing Then Return Nothing

			Dim card = New vCard

			With _person
				card.FullName.FamilyName = .LastName
				card.FullName.GivenName = .FirstName
				card.FullName.HonorificPrefixes.Add(.FormOfAddress)
				card.CommonName = .ToString
				card.Photo.Image = .Photo
				card.Note = GetNote()
				card.Organization.OrganizationalName = GetOrganizationalName()
				card.Organization.OrganizationalUnitNames.Add(GetOrganizationalUnitNames)
				card.Title = GetTitle()
				GetAllowedCommunications.ForEach(Sub(c) AddCommunication(card, c))
				GetAllowedAddresses.ForEach(Sub(a) AddAddress(card, a))
			End With

			Return card
		End Function
#End Region

	End Class

End Namespace
