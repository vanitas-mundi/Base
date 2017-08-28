Option Explicit On
Option Infer On
Option Strict On
Imports System.IO

#Region " --------------->> Imports/ usings "
#End Region

Namespace UniversalDrawing

  Public Class ImageMethods

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Liefert anhand des übergebenen Byte-Arrays die Breite und Höhe eines Bildes.</summary>
    Public Shared Function GetImageSize(ByVal imageArray As Byte()) As ImageSizeInfo

      Using ms = New MemoryStream(imageArray)
        Return GetImageSize(ms)
      End Using

    End Function

    '''<summary>Liefert anhand des übergebenen Filenames die Breite und Höhe eines Bildes.</summary>
    Public Shared Function GetImageSize(ByVal fileName As String) As ImageSizeInfo
      Using stream = New FileStream(fileName, FileMode.Open, FileAccess.Read)
        Return GetImageSize(stream)
      End Using
    End Function

    '''<summary>Liefert anhand des übergebenen Streams die Breite und Höhe eines Bildes.</summary>
    Public Shared Function GetImageSize(ByVal stream As Stream) As ImageSizeInfo

      Dim width = 0
      Dim height = 0
      Dim found = False
      Dim eof = False

      Using reader = New BinaryReader(stream)


        While (Not found) OrElse (eof)

          ' read 0xFF and the type
          reader.ReadByte()
          Dim type = reader.ReadByte()

          ' get length
          Dim len As Int32 = 0
          Select Case type
            Case &HD8, &HD9 ' start and end of the image
              len = 0
            Case &HDD ' restart interval
              len = 2
            Case Else
              ' the next two bytes is the length
              Dim lenHi = reader.ReadByte()
              Dim lenLo = reader.ReadByte()
              len = (lenHi << 8 Or lenLo) - 2
          End Select

          eof = (type = &HD9) ' EOF?

          ' process the data
          If len > 0 Then

            ' read the data
            Dim data = reader.ReadBytes(len)

            ' this is what we are looking for
            If type = &HC0 Then
              width = data(1) << 8 Or data(2)
              height = data(3) << 8 Or data(4)
              found = True
            End If
          End If
        End While

      End Using

      Dim result = New ImageSizeInfo(New ImageSize(width, height), found)
      Return result
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace

