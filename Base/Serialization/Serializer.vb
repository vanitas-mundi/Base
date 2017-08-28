Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports BCW.Foundation.Base.Serialization.Serializers
#End Region

Namespace Serialization

	Public NotInheritable Class Serializer

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Shared ReadOnly Property Xml As Xml
			Get
				Return Xml.Instance
			End Get
		End Property

		Public Shared ReadOnly Property Soap As Soap
			Get
				Return Soap.Instance
			End Get
		End Property

		Public Shared ReadOnly Property Json As Json
			Get
				Return Json.Instance
			End Get
		End Property

		Public Shared ReadOnly Property Binary As Binary
			Get
				Return Binary.Instance
			End Get
		End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace


