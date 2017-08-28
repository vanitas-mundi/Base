Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.IO
Imports System.Net.Mail
Imports System.Text
#End Region

Namespace IOHandling

  Public Class FileSystemManipulation

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Friend Sub New()
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>
    '''Prüft, ob das Verzeichnis path im Dateisystem existiert und 
    '''legt diesen ggf. an. Liefert true, wenn die Methode ohne
    '''Fehler beendet wurde.
    '''</summary>
    Public Function CreateFolderIfNotExists(ByVal path As String) As Boolean

      With My.Computer.FileSystem
        If Not .DirectoryExists(path) Then
          Try
            .CreateDirectory(path)
          Catch ex As Exception
            Return False
          End Try
        End If

        Return True
      End With
    End Function

    Public Sub SaveMailMessageObjectToFile(ByVal mailMessage As MailMessage, ByVal fileName As String)
      SaveMailMessageObjectToFile(mailMessage, fileName)
    End Sub

    '''<summary>Speichert ein MailMessage-Objekt in eine eml-Datei.</summary>    
    '''<param name="mailMessage"></param>
    '''<param name="fileName"></param>
    '''<param name="addUnsentHeader">
    '''True = Write the Unsent header to the file so 
    '''the mail client knows this mail must be presented in "New message" mode
    '''</param>
    Public Sub SaveMailMessageObjectToFile(ByVal mailMessage As MailMessage, ByVal fileName As String, ByVal addUnsentHeader As Boolean)

      Using filestream = File.Open(fileName, FileMode.Create)

        If addUnsentHeader Then
          Dim binaryWriter = New BinaryWriter(filestream)
          ' Write the Unsent header to the file so the mail client knows this mail must be presented in "New message" mode
          binaryWriter.Write(Encoding.UTF8.GetBytes($"X-Unsent: 1{vbCrLf}"))
        End If

        Dim assembly = GetType(SmtpClient).Assembly
        Dim mailWriterType = assembly.GetType("System.Net.Mail.MailWriter")

        Dim bindingFlags = System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic

        ' Get reflection info for MailWriter contructor
        Dim mailWriterContructor = mailWriterType.GetConstructor(bindingFlags, Nothing, New Type() {GetType(Stream)}, Nothing)

        ' Construct MailWriter object with our FileStream
        Dim mailWriter = mailWriterContructor.Invoke(New Object() {filestream})

        ' Get reflection info for Send() method on MailMessage
        Dim sendMethod = GetType(MailMessage).GetMethod("Send", bindingFlags)

        sendMethod.Invoke(mailMessage, bindingFlags, Nothing, New Object() {mailWriter, True, True}, Nothing)

        ' Finally get reflection info for Close() method on our MailWriter
        Dim closeMethod = mailWriter.GetType.GetMethod("Close", bindingFlags)

        ' Call close method
        closeMethod.Invoke(mailWriter, bindingFlags, Nothing, New Object() {}, Nothing)
      End Using
    End Sub
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace