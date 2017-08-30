Option Explicit On
Option Infer On
Option Strict On

Imports SSP.Base.SystemMessaging
Imports SSP.Base.SystemMessaging.Interfaces
Imports SSP.Base.SystemMessaging.SystemMessages

Module MainModule

    Sub Main()

        Dim subscriber = New MySubscriber("Hansel")
        Dim subscriber2 = New MySubscriber2("Bert")

        Dim d = DateTime.Now
        Console.WriteLine("press any key")
        Console.ReadKey()

        Dim data = New MyData With {.message = "lkflk"}

        SystemMessageQueue.Instance.SendSystemMessage(New CommonSystemMessage(d, data))
        SystemMessageQueue.Instance.SendSystemMessage(New SaveSystemMessage(d, data))

        Console.WriteLine("press any key")
        Console.ReadKey()
    End Sub

End Module


Public Class MyData

    Public target As Object
    Public message As String
    Public name As String

End Class

Public Class SaveSystemMessage

    Inherits SystemMessageBase

    Public Sub New(ByVal sender As Object, ByVal data As Object)
        MyBase.New(sender, data)
    End Sub

    Public ReadOnly Property Dominik As String
        Get
            Return "Save was pressed"
        End Get
    End Property

End Class



Public Class MySubscriber


    Private _name As String

    Public Sub New(ByVal name As String)

        _name = name

        SystemMessageQueue.Instance.AddSubscriber(Of CommonSystemMessage) _
        (Me, AddressOf OnCommonSystemMessageArrived)

        SystemMessageQueue.Instance.AddSubscriber(Of SaveSystemMessage) _
        (Me, AddressOf OnSaveSystemMessageArrived)

    End Sub

    Private Sub OnSaveSystemMessageArrived(ByVal message As ISystemMessage)
        Dim m = DirectCast(message, SaveSystemMessage)

        Console.WriteLine(m.Dominik)

    End Sub


    Private Sub OnCommonSystemMessageArrived(ByVal message As ISystemMessage)

        'Dim m = DirectCast(message, SaveSystemMessage)

        Console.WriteLine(message.Data.ToString & " zu " & _name)
    End Sub

End Class



Public Class MySubscriber2


    Private _name As String

    Public Sub New(ByVal name As String)

        _name = name

        SystemMessageQueue.Instance.AddSubscriber(Of SaveSystemMessage) _
        (Me, AddressOf OnSaveSystemMessageArrived)

    End Sub

    Private Sub OnSaveSystemMessageArrived(ByVal message As ISystemMessage)
        Dim m = DirectCast(message, SaveSystemMessage)

        Console.WriteLine(m.Dominik & " Zusatz")

    End Sub

End Class


