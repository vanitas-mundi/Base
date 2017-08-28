Option Explicit On
Option Infer On
Option Strict On
Imports System.Reflection

#Region " --------------->> Imports/ usings "
#End Region

Namespace ReflectionHandling

  Public Class ReflectionMethod

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
    '''<summary>Ruft die Methode methodName des Objektes context auf.</summary>
    Public Function Execute(context As Object, methodName As String, ByVal args As Object()) As Object
      Return context.GetType.InvokeMember(methodName, BindingFlags.InvokeMethod, Nothing, context, args)
    End Function

    '''<summary>Ruft die Methode methodName der Instanz instance auf.</summary>
    Public Function Execute(Of T)(ByVal context As Object, ByVal methodName As String, ByVal args As Object()) As T

      Return DirectCast(Execute(context, methodName, args), T)
    End Function

    '''<summary>Liefert alle Methodennamen der Instanz context.</summary>
    Public Function Names(ByVal context As Object) As String()

      Dim result = context.GetType.GetMethods.Where(Function(x) x.IsSpecialName).Select(Function(x) x.Name)
      Return result.ToArray
    End Function

    '''<summary>Liefert alle MethodInfos der Instanz context als Array.</summary>
    Public Function GetMethodInfos(ByVal context As Object) As MethodInfo()

      Dim result = context.GetType.GetMethods.Where(Function(x) Not x.IsSpecialName)
      Return result.ToArray
    End Function

    '''<summary>Liefert alle Methoden-Überladungen der Instanz context der Methode methodName als Array.</summary>
    Public Function GetOverloadedMethodInfos(ByVal context As Object, ByVal methodName As String) As MethodInfo()

      Dim result = context.GetType.GetMethods.Where(Function(x) (Not x.IsSpecialName) AndAlso (x.Name = methodName))
      Return result.ToArray
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace