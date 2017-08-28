Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports "
Imports BCW.Etc.Enums.StatusModule
Imports BCW.Modules.PersonModule
#End Region

Namespace Converter.vCardBuilder

	Public Class vCardFactorySelector

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Shared Function GetFactory _
    (ByVal connectionString As String _
    , ByVal dataObject As Object _
    , ByVal role As Roles) As IVCardFactory

      Select Case role
        Case Roles.ContactPerson
          Return New vCardContactFactory(connectionString, dataObject)
        Case Roles.Employee, Roles.TemporaryPersonnel
          Return New vCardEmployeeFactory(connectionString, TryCast(dataObject, Person))
        Case Roles.Lecturer, Roles.Participant
          Return New vCardPersonFactory(connectionString, TryCast(dataObject, Person))
        Case Else
          Return Nothing
      End Select
    End Function
#End Region

  End Class

End Namespace

