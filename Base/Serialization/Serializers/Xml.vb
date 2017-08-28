Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.IO
Imports System.Xml.Serialization
Imports BCW.Foundation.Base.Serialization.Interfaces
Imports BCW.Foundation.Base.ExtensionMethods.EnumerableExtensions
#End Region

Namespace Serialization.Serializers

	Public NotInheritable Class Xml

		Implements ISerialization

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _instance As Xml
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Private Sub New()
		End Sub

		Shared Sub New()
			_instance = New Xml
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Shared ReadOnly Property Instance As Xml
			Get
				Return _instance
			End Get
		End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		'''<summary>Serialisiert das Objekt in eine Datei.</summary>
		Public Sub ObjectToFile(Of T As Class)(obj As T, fileName As String) _
		Implements ISerialization.ObjectToFile

			Using file = New FileStream(fileName, FileMode.Create)
				ObjectToStream(obj, file)
			End Using
		End Sub

		'''<summary>Deserialisiert ein Objekt aus einer Datei.</summary>
		Public Function ObjectFromFile(Of T As Class)(fileName As String) As T _
		Implements ISerialization.ObjectFromFile

			Using file = New FileStream(fileName, FileMode.Open)
				Return ObjectFromStream(Of T)(file)
			End Using
		End Function

		'''<summary>Serialisiert ein Objekt in den übergebenen Stream.</summary>
		Public Sub ObjectToStream(Of T As Class)(obj As T, stream As Stream) _
		Implements ISerialization.ObjectToStream

			Dim serializer = New XmlSerializer(GetType(T))
			serializer.Serialize(stream, obj)
			stream.Seek(0, SeekOrigin.Begin)
		End Sub

		'''<summary>Deserialisiert ein Objekt aus dem übergebenen Stream.</summary>
		Public Function ObjectFromStream(Of T As Class)(ByVal stream As Stream) As T _
		Implements ISerialization.ObjectFromStream

			stream.Seek(0, SeekOrigin.Begin)
			Return DirectCast((New XmlSerializer(GetType(T))).Deserialize(stream), T)
		End Function

		'''<summary>
		'''Serialisiert das Objekt in einen MemoryStream und
		'''erzeugt per Deserialisierung eine Kopie des Objektes
		'''und gibt diese zurück
		'''</summary>
		Public Function CloneObject(Of T As Class)(ByVal obj As T) As T _
		Implements ISerialization.CloneObject

			Using ms = New MemoryStream
				ObjectToStream(Of T)(obj, ms)
				Return ObjectFromStream(Of T)(ms)
			End Using
		End Function

		'''<summary>
		'''Serialisiert beide Objekte und prüft danach, ob die Daten beider
		'''Objekte identisch sind.
		''' </summary>
		Public Function IsDataEqualTo(Of T As Class) _
		(obj As T, obj2 As T) As Boolean _
		Implements ISerialization.IsDataEqualTo

			Dim dataString1 = ""
			Dim dataString2 = ""

			Using ms = New MemoryStream
				ObjectToStream(obj, ms)
				dataString1 = ms.ToArray.ToList.Select _
				(Function(x) x.ToString).EnumerableJoin("")
			End Using

			Using ms = New MemoryStream
				ObjectToStream(obj2, ms)
				dataString2 = ms.ToArray.ToList.Select _
				(Function(x) x.ToString).EnumerableJoin("")
			End Using

			Return dataString1 = dataString2
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
