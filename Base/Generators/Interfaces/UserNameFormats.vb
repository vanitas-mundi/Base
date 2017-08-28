Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Generators.Interfaces

	Public Enum UserNameFormats
		FirstNameLastName = 0
		FirstNamePersonIdLastName = 1
		FirstNameLastNamePersonId = 2
		FirstLetterFirstNamePersonIdLastName = 3
		FirstLetterFirstNameLastNamePersonId = 4
		PersonIdLastName = 5
		LastNamePersonId = 6
	End Enum

End Namespace
