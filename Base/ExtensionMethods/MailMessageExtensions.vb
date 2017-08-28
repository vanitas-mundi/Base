Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Runtime.CompilerServices
Imports System.Net.Mail
#End Region

Namespace ExtensionMethods

  Public Module MailMessageExtensions

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
    '''<summary>Speichert das MailMessage-Objekt als eml-Datei.</summary>
    <Extension()>
    Public Sub Save(ByVal mailMessage As MailMessage, ByVal fileName As String)
      Save(mailMessage, fileName, True)
    End Sub

    '''<summary>Speichert das MailMessage-Objekt als eml-Datei.</summary>
    '''<param name="addUnsentHeader">
    '''True = Write the Unsent header to the file so 
    '''the mail client knows this mail must be presented in "New message" mode
    ''' </param>
    <Extension()>
    Public Sub Save(ByVal mailMessage As MailMessage, ByVal fileName As String, ByVal addUnsentHeader As Boolean)

      Helper.FileSystem.Manipulation.SaveMailMessageObjectToFile(mailMessage, fileName, addUnsentHeader)
    End Sub
#End Region '{Öffentliche Methoden der Klasse}

  End Module

End Namespace
