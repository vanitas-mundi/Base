Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports "
#End Region

Namespace IniHandling

	Public Class Section

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
    Private _valueNames As New List(Of String)
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public ReadOnly Property Values As New List(Of SectionValue)

    Public Property Name As String

    Public ReadOnly Property ValueNames As List(Of String)
			Get
        Return Me.Values.Select(Function(x) x.Name).ToList
      End Get
		End Property

    Public ReadOnly Property Comments As New List(Of String)

    Public ReadOnly Property CommentString As String
			Get
        Return String.Join(vbCrLf, Me.Comments)
      End Get
		End Property
#End Region

#Region " --------------->> Private Methoden der Klasse "
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Function ContainsKey(ByVal valueName As String) As Boolean
      Return Me.Values.Any(Function(x) String.Compare(x.Name, valueName, True) = 0)
    End Function

    Public Function Item(ByVal valueName As String) As SectionValue
      Return Me.Values.FirstOrDefault(Function(x) String.Compare(x.Name, valueName, True) = 0)
    End Function

    Public Function Item(ByVal index As Int32) As SectionValue
      Return Me.Values.Item(index)
    End Function
#End Region

  End Class

End Namespace
