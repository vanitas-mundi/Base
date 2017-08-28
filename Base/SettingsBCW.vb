Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports BCW.Foundation.Base.Messages
Imports BCW.Foundation.Base.Messages.Enums
#End Region

'Namespace Models.NewModels

Public NotInheritable Class SettingsBCW

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Private Sub New()
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Shared ReadOnly Property Instance As SettingsBCW = New SettingsBCW

    ''''<summary>Liefert die IP des BCW-SmtpServers.</summary>
    'Public ReadOnly Property SmtpServer As String
    '	Get
    '		Return My.Settings.SettingsBCWSmtpServer
    '	End Get
    'End Property

    ''''<summary>Liefert den Namen des BCW-MailServers.</summary>
    'Public ReadOnly Property MailServer As String
    '	Get
    '		Return My.Settings.SettingsBCWMailServer
    '	End Get
    'End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>
    '''Fragt ab, ob mit Testdaten (oder Echtdaten) gearbeitet werden soll
    '''und liefert true (Testdaten) oder false (Echtdaten) zurück.
    '''</summary>
    Public Function CheckUseDevelopConnectionString() As Boolean

      Dim path = My.Application.Info.DirectoryPath.ToLower

    'Wenn IsDevelopTime oder der Startordner Developsystem ist
    If (Debugger.IsAttached) OrElse (path.Contains(My.Settings.SettingsBCWDevelopPath)) Then
        Dim prompt = "Soll mit Testdaten gearbeitet werden?"
        Dim title = "Server"
        Return (MessageBoxWin32Api.Show.Question(prompt, title) = MessageBoxWin32ApiResults.Yes)
      End If

      Return False
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

'End Namespace
