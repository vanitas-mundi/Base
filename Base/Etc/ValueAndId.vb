Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Etc

  Public Class ValueAndId

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
    End Sub

    Public Sub New(ByVal value As Object)
      Me.New(Nothing, value)
    End Sub

    Public Sub New(ByVal id As Int64?, ByVal value As Object)
      Me.Id = id
      Me.Value = value
    End Sub

#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Property Id As Int64?
    Public Property Value As Object
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Overrides Function ToString() As String
      Return Me.Value.ToString
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
