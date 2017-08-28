Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Reflection
#End Region

Namespace ReflectionHandling

  Public Class ReflectionConstructor

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
    '''<summary>Ruft den Standard-Konstruktor des Typs type auf und liefert eine neue Instanz.</summary>
    Public Function CreateInstance(ByVal type As Type) As Object
      Return Activator.CreateInstance(type)
    End Function

    '''<summary>Erzeugt eine neue Instanz der Klasse instanceType und liefert diese zurück.</summary>
    Public Function CreateInstance(Of T)(ByVal instanceType As Type, ByVal args As Object()) As T

      Return DirectCast(CreateInstance(instanceType, args), T)
    End Function

    '''<summary>Erzeugt eine neue Instanz der Klasse instanceType und liefert diese zurück.</summary>
    Public Function CreateInstance(ByVal instanceType As Type, ByVal args As Object()) As Object

      Dim flags = BindingFlags.DeclaredOnly _
      Or BindingFlags.Public _
      Or BindingFlags.NonPublic _
      Or BindingFlags.Instance _
      Or BindingFlags.CreateInstance

      Return instanceType.InvokeMember(Nothing, flags, Nothing, Nothing, args)
    End Function

    '''<summary>Liefert alle MethodInfos der Instanz context als Array.</summary>
    Public Function GetConstructorInfos(ByVal context As Object) As ConstructorInfo()

      Dim result = context.GetType.GetConstructors
      Return result.ToArray
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace