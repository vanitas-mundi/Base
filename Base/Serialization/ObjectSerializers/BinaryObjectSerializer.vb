Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.IO
Imports BCW.Foundation.Base.Serialization.Interfaces
#End Region

Namespace Serialization.ObjectSerializers

	'''<summary>
	'''Für die Verwendung dieses Serialisierers muss die zu 
	'''serialisierende Klasse mit dem Serializable-Attribut 
	'''gekennzeichnet werden
	'''</summary>
	Public Class BinaryObjectSerializer(Of T As {Class})

		Implements ISerializationOf(Of T)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private _contentObject As T
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New()
		End Sub

		Public Sub New(ByVal contentObject As T)
			_contentObject = contentObject
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		'''<summary>Serialisiert das Objekt in eine Datei.</summary>
		Public Sub ObjectToFile(obj As T, fileName As String) _
		Implements ISerializationOf(Of T).ObjectToFile

			Serializer.Binary.ObjectToFile(Of T)(obj, fileName)
		End Sub

		'''<summary>Serialisiert ein Objekt in den übergebenen Stream.</summary>
		Public Sub ObjectToStream(obj As T, stream As Stream) _
		Implements ISerializationOf(Of T).ObjectToStream

			Serializer.Binary.ObjectToStream(Of T)(obj, stream)
		End Sub

		'''<summary>Deserialisiert ein Objekt aus einer Datei.</summary>
		Public Function ObjectFromFile(fileName As String) As T _
		Implements ISerializationOf(Of T).ObjectFromFile

			Return Serializer.Binary.ObjectFromFile(Of T)(fileName)
		End Function

		'''<summary>Deserialisiert ein Objekt aus dem übergebenen Stream.</summary>
		Public Function ObjectFromStream(stream As Stream) As T _
		Implements ISerializationOf(Of T).ObjectFromStream

			Return Serializer.Binary.ObjectFromStream(Of T)(stream)
		End Function

		'''<summary>Serialisiert das Objekt in eine Datei.</summary>
		Public Sub ObjectToFile(fileName As String) _
		Implements ISerializationOf(Of T).ObjectToFile
			ObjectToFile(_contentObject, fileName)
		End Sub

		'''<summary>Serialisiert ein Objekt in den übergebenen Stream.</summary>
		Public Sub ObjectToStream(stream As Stream) _
		Implements ISerializationOf(Of T).ObjectToStream

			ObjectToStream(_contentObject, stream)
		End Sub

		'''<summary>
		'''Serialisiert das Objekt in einen MemoryStream und
		'''erzeugt per Deserialisierung eine Kopie des Objektes
		'''und gibt diese zurück
		'''</summary>
		Public Function CloneObject(obj As T) As T _
		Implements ISerializationOf(Of T).CloneObject

			Return Serializer.Binary.CloneObject(Of T)(obj)
		End Function

		'''<summary>
		'''Serialisiert das Objekt in einen MemoryStream und
		'''erzeugt per Deserialisierung eine Kopie des Objektes
		'''und gibt diese zurück
		'''</summary>
		Public Function CloneObject() As T _
		Implements ISerializationOf(Of T).CloneObject

			Return CloneObject(_contentObject)
		End Function

		'''<summary>
		'''Serialisiert beide Objekte und prüft danach, ob die Daten beider
		'''Objekte identisch sind.
		''' </summary>
		Public Function IsDataEqualTo(obj As T) As Boolean _
		Implements ISerializationOf(Of T).IsDataEqualTo

			Return IsDataEqualTo(_contentObject, obj)
		End Function

		'''<summary>
		'''Serialisiert beide Objekte und prüft danach, ob die Daten beider
		'''Objekte identisch sind.
		''' </summary>
		Public Function IsDataEqualTo(obj As T, obj2 As T) As Boolean _
		Implements ISerializationOf(Of T).IsDataEqualTo

			Return Serializer.Binary.IsDataEqualTo(Of T)(obj, obj2)
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
