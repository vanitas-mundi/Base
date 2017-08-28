Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports BCW.Foundation.Base.Serialization.ObjectSerializers
#End Region

Namespace Serialization

	Public Class ObjectSerializer(Of T As {Class})

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private _xml As New XmlObjectSerializer(Of T)
		Private _soap As New SoapObjectSerializer(Of T)
		Private _binary As New BinaryObjectSerializer(Of T)
		Private _json As New JsonObjectSerializer(Of T)
		Private _contextObject As T
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New()
			_xml = New XmlObjectSerializer(Of T)
			_soap = New SoapObjectSerializer(Of T)
			_binary = New BinaryObjectSerializer(Of T)
			_json = New JsonObjectSerializer(Of T)
		End Sub

		Public Sub New(ByVal contextObject As Object)
			_contextObject = DirectCast(contextObject, T)
			_xml = New XmlObjectSerializer(Of T)(_contextObject)
			_soap = New SoapObjectSerializer(Of T)(_contextObject)
			_binary = New BinaryObjectSerializer(Of T)(_contextObject)
			_json = New JsonObjectSerializer(Of T)(_contextObject)
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public ReadOnly Property Xml As XmlObjectSerializer(Of T)
			Get
				Return _xml
			End Get
		End Property

		Public ReadOnly Property Soap As SoapObjectSerializer(Of T)
			Get
				Return _soap
			End Get
		End Property

		Public ReadOnly Property Json As JsonObjectSerializer(Of T)
			Get
				Return _json
			End Get
		End Property

		Public ReadOnly Property Binary As BinaryObjectSerializer(Of T)
			Get
				Return _binary
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


