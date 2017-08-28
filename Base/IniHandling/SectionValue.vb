Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports "
#End Region

Namespace IniHandling

	Public Class SectionValue

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Property Name As String

    Public Property Value As String

    Public ReadOnly Property ValueUnquoted As String
			Get
				Dim temp = If(_value.StartsWith(""""), _value.Substring(1), _value)
				Return If(temp.EndsWith(""""), temp.Substring(0, temp.Length - 1), temp)
			End Get
		End Property

    Public ReadOnly Property Comments As New List(Of String)

    Public ReadOnly Property CommentString As String
			Get
				Return String.Join(vbCrLf, _comments)
			End Get
		End Property

    '''<summary>Gibt an, ob nur ein Wert existiert.</summary>
    Public Property ValueOnly As Boolean = False

#End Region

#Region " --------------->> Private Methoden der Klasse "
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region

  End Class

End Namespace
