Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace UniversalDrawing

  Public Class ImageSize

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal width As Int32, ByVal height As Int32)
      Me.Width = width
      Me.Height = height
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert die Breite des Bildes.</summary>
    Public ReadOnly Property Width As Int32
    '''<summary>Liefert die Höhe des Bildes.</summary>
    Public ReadOnly Property Height As Int32
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Overrides Function ToString() As String
      Return $"{Me.Width}:{Me.Height}"
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
