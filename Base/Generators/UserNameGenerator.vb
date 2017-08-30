Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports "
Imports System.Text
Imports SSP.Base.Generators.Interfaces
#End Region

Namespace Generators

	Public Class UserNameGenerator

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _generatorSpecialCharactersDictionary As Dictionary(Of String, String)
		Private Shared _generatorAllowedCharacters As New List(Of Char)
		Private Shared _notAllowedCharacter As Char = "~"c

		Private _firstName As String
		Private _lastName As String
		Private _personId As Int64 = 0
		Private _maxLength As Int32 = 0
		Private _format As UserNameFormats = UserNameFormats.FirstNameLastName
		Private _preWindows2000 As Boolean = False
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			Initialize()
		End Sub

		Public Sub New()
		End Sub

		Public Sub New(ByVal firstName As String, ByVal lastName As String, ByVal personId As Int64)
			_firstName = firstName
			_lastName = lastName
			_personId = personId
		End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Property FirstName As String
			Get
				Return _firstName
			End Get
			Set(value As String)
				_firstName = value
			End Set
		End Property

		Public Property LastName As String
			Get
				Return _lastName
			End Get
			Set(value As String)
				_lastName = value
			End Set
		End Property

		Public Property PersonId As Int64
			Get
				Return _personId
			End Get
			Set(value As Int64)
				_personId = value
			End Set
		End Property

		Public Property MaxLength As Int32
			Get
				If Me.PreWindows2000 Then
					Return 20
				Else
					Return _maxLength
				End If
			End Get
			Set(value As Int32)
				If Me.PreWindows2000 Then Return
				_maxLength = value
			End Set
		End Property

		Public Property Format As UserNameFormats
			Get
				Return _format
			End Get
			Set(value As UserNameFormats)
				_format = value
			End Set
		End Property

		Public Property PreWindows2000 As Boolean
			Get
				Return _preWindows2000
			End Get
			Set(value As Boolean)
				_preWindows2000 = value
			End Set
		End Property

		Public ReadOnly Property PurgedFirstName As String
			Get
				Return GetPurgedFirstName(Me.FirstName)
			End Get
		End Property

		Public ReadOnly Property PurgedLastName As String
			Get
				Return GetPurgeLastName(Me.LastName)
			End Get
		End Property

		Public ReadOnly Property PurgedUserName As String
			Get
				Return GetPurgedUserName(GetPurgedFirstName(Me.FirstName), GetPurgeLastName(Me.LastName))
			End Get
		End Property
#End Region

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
		Private Shared Sub Initialize()
			_generatorSpecialCharactersDictionary = New Dictionary(Of String, String)
			_generatorSpecialCharactersDictionary.Add("À", "A")
			_generatorSpecialCharactersDictionary.Add("Á", "A")
			_generatorSpecialCharactersDictionary.Add("Â", "A")
			_generatorSpecialCharactersDictionary.Add("Ã", "A")
			_generatorSpecialCharactersDictionary.Add("Ä", "Ae")
			_generatorSpecialCharactersDictionary.Add("Å", "A")
			_generatorSpecialCharactersDictionary.Add("Æ", "Ae")
			_generatorSpecialCharactersDictionary.Add("Ç", "C")
			_generatorSpecialCharactersDictionary.Add("È", "E")
			_generatorSpecialCharactersDictionary.Add("É", "E")
			_generatorSpecialCharactersDictionary.Add("Ê", "E")
			_generatorSpecialCharactersDictionary.Add("Ë", "E")
			_generatorSpecialCharactersDictionary.Add("Ì", "I")
			_generatorSpecialCharactersDictionary.Add("Í", "I")
			_generatorSpecialCharactersDictionary.Add("Î", "I")
			_generatorSpecialCharactersDictionary.Add("Ï", "I")
			_generatorSpecialCharactersDictionary.Add("Ð", "D")
			_generatorSpecialCharactersDictionary.Add("Ñ", "N")
			_generatorSpecialCharactersDictionary.Add("Ò", "O")
			_generatorSpecialCharactersDictionary.Add("Ó", "O")
			_generatorSpecialCharactersDictionary.Add("Ô", "O")
			_generatorSpecialCharactersDictionary.Add("Õ", "O")
			_generatorSpecialCharactersDictionary.Add("Ö", "Oe")
			_generatorSpecialCharactersDictionary.Add("×", "x")
			_generatorSpecialCharactersDictionary.Add("Ø", "O")
			_generatorSpecialCharactersDictionary.Add("Ù", "U")
			_generatorSpecialCharactersDictionary.Add("Ú", "U")
			_generatorSpecialCharactersDictionary.Add("Û", "U")
			_generatorSpecialCharactersDictionary.Add("Ü", "Ue")
			_generatorSpecialCharactersDictionary.Add("Ý", "Y")
			_generatorSpecialCharactersDictionary.Add("Þ", "p")
			_generatorSpecialCharactersDictionary.Add("ß", "ss")
			_generatorSpecialCharactersDictionary.Add("à", "a")
			_generatorSpecialCharactersDictionary.Add("á", "a")
			_generatorSpecialCharactersDictionary.Add("â", "a")
			_generatorSpecialCharactersDictionary.Add("ã", "a")
			_generatorSpecialCharactersDictionary.Add("ä", "ae")
			_generatorSpecialCharactersDictionary.Add("å", "a")
			_generatorSpecialCharactersDictionary.Add("æ", "ae")
			_generatorSpecialCharactersDictionary.Add("ç", "c")
			_generatorSpecialCharactersDictionary.Add("è", "e")
			_generatorSpecialCharactersDictionary.Add("é", "e")
			_generatorSpecialCharactersDictionary.Add("ê", "e")
			_generatorSpecialCharactersDictionary.Add("ë", "e")
			_generatorSpecialCharactersDictionary.Add("ì", "i")
			_generatorSpecialCharactersDictionary.Add("í", "i")
			_generatorSpecialCharactersDictionary.Add("î", "i")
			_generatorSpecialCharactersDictionary.Add("ï", "i")
			_generatorSpecialCharactersDictionary.Add("ð", "o")
			_generatorSpecialCharactersDictionary.Add("ñ", "n")
			_generatorSpecialCharactersDictionary.Add("ò", "o")
			_generatorSpecialCharactersDictionary.Add("ó", "o")
			_generatorSpecialCharactersDictionary.Add("ô", "o")
			_generatorSpecialCharactersDictionary.Add("õ", "o")
			_generatorSpecialCharactersDictionary.Add("ö", "oe")
			_generatorSpecialCharactersDictionary.Add("ø", "o")
			_generatorSpecialCharactersDictionary.Add("ù", "u")
			_generatorSpecialCharactersDictionary.Add("ú", "u")
			_generatorSpecialCharactersDictionary.Add("û", "u")
			_generatorSpecialCharactersDictionary.Add("ü", "ue")
			_generatorSpecialCharactersDictionary.Add("ý", "y")
			_generatorSpecialCharactersDictionary.Add("þ", "p")
			_generatorSpecialCharactersDictionary.Add("ÿ", "y")
			_generatorSpecialCharactersDictionary.Add(" ", ".")

			For i = 48 To 57
				_generatorAllowedCharacters.Add(ChrW(i))
			Next i

			For i = 97 To 122
				_generatorAllowedCharacters.Add(ChrW(i))
			Next i

			_generatorAllowedCharacters.Add("."c)
			_generatorAllowedCharacters.Add("-"c)
			_generatorAllowedCharacters.Add("_"c)
		End Sub

		Private Function TruncateUserName() As String

			Dim maxLength = Me.MaxLength
			Dim username = Me.PurgedUserName
			If username.Length <= maxLength Then Return username

			maxLength -= Me.PersonId.ToString.Length

			Dim temp = ""
			Dim firstName = RemovePersonId(Me.PurgedFirstName).Split("-"c).FirstOrDefault
			Dim lastName = RemovePersonId(Me.PurgedLastName)

			temp = firstName & "." & lastName
			If temp.Length <= maxLength Then
				Return GetPurgedUserName(GetPurgedFirstName(firstName), GetPurgeLastName(lastName))
			End If

			lastName = lastName.Split("-"c).ToList.Last
			temp = firstName & "." & lastName
			If temp.Length <= maxLength Then
				Return GetPurgedUserName(GetPurgedFirstName(firstName), GetPurgeLastName(lastName))
			End If

			firstName = If(firstName = "", "", firstName.Substring(0, 1))
			temp = firstName & "." & lastName
			If temp.Length <= maxLength Then
				Return GetPurgedUserName(GetPurgedFirstName(firstName), GetPurgeLastName(lastName))
			End If

			Return GetPurgedUserName(GetPurgedFirstName(firstName), GetPurgeLastName(lastName)).Substring(0, maxLength)
		End Function

		Private Function GetPurgedFirstName(ByVal firstName As String) As String

			Dim temp = ReplaceSpecialCharacters(firstName).Split("."c).FirstOrDefault.ToLower
			Select Case Me.Format
				Case UserNameFormats.FirstNameLastName _
				, UserNameFormats.FirstNameLastNamePersonId
					Return temp
				Case UserNameFormats.FirstNamePersonIdLastName
					Return temp & Me.PersonId
				Case UserNameFormats.FirstLetterFirstNamePersonIdLastName
					Return temp.Substring(0, 1) & Me.PersonId
				Case UserNameFormats.FirstLetterFirstNameLastNamePersonId
					Return temp.Substring(0, 1)
				Case UserNameFormats.LastNamePersonId _
				, UserNameFormats.PersonIdLastName
					Return ""
				Case Else
					Return ""
			End Select
		End Function

		Private Function GetPurgeLastName(ByVal lastName As String) As String
			Dim temp = String.Join("_", ReplaceSpecialCharacters(lastName).Split("."c)).ToLower

			Select Case Me.Format
				Case UserNameFormats.FirstNameLastName _
				, UserNameFormats.FirstNamePersonIdLastName _
				, UserNameFormats.FirstLetterFirstNamePersonIdLastName
					Return temp
				Case UserNameFormats.FirstNameLastNamePersonId _
				, UserNameFormats.FirstLetterFirstNameLastNamePersonId _
				, UserNameFormats.LastNamePersonId
					Return temp & Me.PersonId
				Case UserNameFormats.PersonIdLastName
					Return Me.PersonId & temp
				Case Else
					Return ""
			End Select
		End Function

		Private Function GetPurgedUserName(ByVal purgedFirstName As String, ByVal purgeLastName As String) As String

			Dim userName = String.Format("{0}.{1}", purgedFirstName, purgeLastName).TrimStart("."c)
			Return String.Join("", userName.ToList.Select(Function(c) CharToAllowedChar(c)).ToArray)
		End Function

		Private Function RemovePersonId(ByVal value As String) As String
			Return value.Replace(PersonId.ToString, "")
		End Function

		Private Function CharToAllowedChar(ByVal c As Char) As Char
			Return If(_generatorAllowedCharacters.Contains(c), c, _notAllowedCharacter)
		End Function
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
		''' <summary>
		''' Generiert einen Usernamen anhand der vorgenommenen eingestellten Eigenschaften.
		''' </summary>
		Public Overloads Overrides Function ToString() As String
			Return Generate()
		End Function

		''' <summary>
		''' Tauscht Sonderzeichen durch 7-Bit-Zeichen aus.
		''' </summary>
		Public Shared Function ReplaceSpecialCharacters(ByVal value As String) As String
			Dim sb = New StringBuilder(value)
			_generatorSpecialCharactersDictionary.Keys.ToList.ForEach _
			(Sub(key) sb.Replace(key, _generatorSpecialCharactersDictionary.Item(key)))
			Return sb.ToString
		End Function

		''' <summary>
		''' Generiert einen Usernamen anhand der vorgenommenen eingestellten Eigenschaften.
		''' </summary>
		Public Function Generate() As String
			If Me.MaxLength = 0 Then
				Return Me.PurgedUserName
			Else
				Return TruncateUserName()
			End If
		End Function

		''' <summary>
		''' Generiert für jedes UserName-Format einen Username und gibt diese als Array zurück.
		''' </summary>
		Public Function GenerateAllFormats() As String()

			Return GenerateUserNameAllFormats(Me)
		End Function

		''' <summary>
		''' Generiert für jedes UserName-Format einen Username und gibt diese als Array zurück.
		''' </summary>
		Public Shared Function GenerateUserNameAllFormats _
		(ByVal userNameGenerator As UserNameGenerator) As String()

			Dim list = New List(Of String)

			For Each format As UserNameFormats In System.Enum.GetValues(GetType(UserNameFormats))
				With userNameGenerator
					.Format = format
					list.Add(.ToString)
				End With
			Next format

			Return list.ToArray
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
