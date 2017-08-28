Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports "
#End Region

Namespace IniHandling

	Public Class Sections

		Inherits Dictionary(Of String, Section)

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public ReadOnly Property SectionNames As List(Of String)
			Get
				Return Me.Keys.ToList
			End Get
		End Property

		Default Public Overloads ReadOnly Property Item(ByVal sectionName As String) As Section
			Get
				Return MyBase.Item(sectionName.ToLower)
			End Get
		End Property

		Default Public Overloads ReadOnly Property Item(ByVal index As Int32) As Section
			Get
				Dim i = 0
        Dim key = String.Empty
        For Each name In Me.Keys
					If i = index Then
						key = name
						Exit For
					End If
					i += 1
				Next name
				Return MyBase.Item(key)
			End Get
		End Property
#End Region

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Overloads Function ContainsKey(ByVal sectionName As String) As Boolean
			Return MyBase.ContainsKey(sectionName.ToLower)
		End Function
#End Region

	End Class

End Namespace
