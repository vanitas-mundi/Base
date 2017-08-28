Option Explicit On
Option Infer On
Option Strict On
Imports System.Reflection

#Region " --------------->> Imports/ usings "
#End Region

Namespace ReflectionHandling

  Public Class ReflectionProperty

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
    '''<summary>Liefert den Wert der Eigenschaft propertyName des Objektes context.</summary>
    Public Function [Get](context As Object, propertyName As String) As Object

      Return context.GetType.InvokeMember(propertyName, BindingFlags.GetProperty, Nothing, context, Nothing)
    End Function

    '''<summary>Liefert den Wert der Eigenschaft propertyName der Objektes context.</summary>
    Public Shared Function [Get](Of T)(ByVal context As Object, ByVal propertyName As String) As T

      Return DirectCast(Helper.Reflection.Property.Get(context, propertyName), T)
    End Function

    '''<summary>Setzt den Wert der Eigenschaft propertyName des Objektes context auf den Wert value.</summary>
    Public Sub [Set](context As Object, propertyName As String, ByVal value As Object)

      context.GetType.InvokeMember(propertyName, BindingFlags.SetProperty, Nothing, context, New Object() {value})
    End Sub





    '''<summary>
    '''Liefert das Attribut TAttribute, der Eigenschaft propertyName,
    '''der Klasse TObject und falls dieses nicht existiert, Null (Nothing).
    '''</summary>
    Public Function GetAttributeOrNothing(Of TAttribute As {Attribute}) _
    (ByVal context As Object, ByVal propertyName As String) As TAttribute

      Dim checks = New ReflectionChecks
      If checks.IsPropertyAttribute(Of TAttribute)(context, propertyName) Then
        Dim info = New ReflectionPropertyInfo
        Dim pi = info.Get(context, propertyName)
        Dim att = pi.GetCustomAttributes(GetType(TAttribute), False)
        Return DirectCast(att.First, TAttribute)
      Else
        Return Nothing
      End If
    End Function

    '''<summary>
    '''Liefert das Attribut TAttribute, der Eigenschaft propertyName,
    '''der Klasse TObject und falls dieses nicht existiert, Null (Nothing).
    '''</summary>
    Public Function GetAttributeOrNothing(Of TObject As {Class}, TAttribute As {Attribute}) _
    (ByVal propertyName As String) As TAttribute

      Dim checks = New ReflectionChecks
      If checks.IsPropertyAttribute(Of TObject, TAttribute)(propertyName) Then
        Dim info = New ReflectionPropertyInfo
        Dim pi = info.Get(Of TObject)(propertyName)
        Dim att = pi.GetCustomAttributes(GetType(TAttribute), False)
        Return DirectCast(att.First, TAttribute)
      Else
        Return Nothing
      End If
    End Function

    ''' <summary>Liefert alle Eigenschaften-Namen der Instanz context als Array.</summary>
    Public Function Names(ByVal context As Object) As String()

      Dim result = context.GetType.GetProperties.Select(Function(x) x.Name).Distinct
      Return result.ToArray
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
