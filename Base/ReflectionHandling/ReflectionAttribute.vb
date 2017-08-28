Option Explicit On
Option Infer On
Option Strict On
Imports System.ComponentModel

#Region " --------------->> Imports/ usings "
#End Region

Namespace ReflectionHandling

  Public Class ReflectionAttribute

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
    '''<summary>Liefert ein Array mit allen Attributen der Instanz context, die mit attributeType matchen.</summary>
    Public Function GetArrayByInstance(ByVal context As Object, ByVal attributeType As Type) As Attribute()

      Return GetArrayByType(context.GetType, attributeType)
    End Function

    '''<summary>Liefert ein Array mit allen Attributen des Typs t, die mit attributeType matchen.</summary>
    Public Function GetArrayByType(ByVal t As Type, ByVal attributeType As Type) As Attribute()

      Dim result = t.GetCustomAttributes(True).Cast(Of Attribute).Where(Function(x) x.GetType Is attributeType)
      Return result.ToArray
    End Function

    '''<summary>
    '''Liefert ein Array mit allen Attributen des PropertyDescriptors pd, die mit attributeType matchen.
    '''</summary>
    Public Function GetArrayByPropertyDescriptor(ByVal pd As PropertyDescriptor, ByVal attributeType As Type) As Attribute()

      Dim result = pd.Attributes.Cast(Of Attribute).Where(Function(x) x.GetType Is attributeType)
      Return result.ToArray
    End Function

    '''<summary>
    '''Liefert ein Array mit allen Attributen der Eigenschaft propertyName der Instanz context,
    '''die mit attributeType matchen.
    '''</summary>
    Public Function GetArrayByProperty(ByVal context As Object, ByVal propertyName As String, ByVal attributeType As Type) As Attribute()

      Dim pd = (New ReflectionPropertyDescriptor).Get(context, propertyName)
      Return GetArrayByPropertyDescriptor(pd, attributeType)
    End Function

    ''' <summary>
    ''' Liefert das Attribute vom Typ attributeType des übergebenen Typs t.
    ''' Wurde das Attribut nicht definiert wird Nothing zurückgegeben.
    ''' </summary>
    Public Function GetByType(ByVal t As Type, ByVal attributeType As Type) As Attribute

      Return Attribute.GetCustomAttribute(t, attributeType)
    End Function

    '''<summary>
    '''Liefert den Wert value des übergebenen Attributtypes vom Typ t.
    '''Sollte das Attribut nicht definiert sein wird Nothing geliefert.
    '''</summary>
    Public Function GetValueByType(ByVal t As Type, ByVal attributeType As Type, ByVal value As String) As Object

      Dim att = GetByType(t, attributeType)
      Return If(att Is Nothing, Nothing, GetValue(att, value))
    End Function

    '''<summary>Liefert den Wert value des übergebenen Attributes.</summary>
    Public Function GetValue(ByVal att As Attribute, ByVal value As String) As Object

      Return If(att Is Nothing, Nothing, Helper.Reflection.Property.Get(att, value))
    End Function

    '''<summary>Ermittelt den Wert der Eigenschaft value des Attributes attributeType, von der Instanz context.</summary>
    Public Function GetValue(ByVal context As Object, ByVal attributeType As Type, ByVal value As String) As Object

      Return GetValue([Get](context, attributeType), value)
    End Function

    '''<summary>
    '''Ermittelt den Wert der Eigenschaft value des Attributes vom Type attributeType,
    '''von der Eigenschaft propertyName, der Instanz context.
    '''</summary>
    Public Function GetValue(ByVal context As Object, ByVal propertyName As String, ByVal attributeType As Type, ByVal value As String) As Object

      Return GetValue([Get](context, propertyName, attributeType), value)
    End Function

    '''<summary>
    '''Ermittelt den Wert der Eigenschaft value des Attributes vom Type attributeType,
    '''von der Eigenschaft propertyName, des Typs t.
    '''</summary>
    Public Function GetValue(ByVal t As Type, ByVal propertyName As String, ByVal attributeType As Type, ByVal value As String) As Object

      Dim temp = t.GetProperty(propertyName).GetCustomAttributes(attributeType, False).FirstOrDefault
      Dim att = DirectCast(temp, Attribute)

      Return GetValue(att, value)
    End Function

    '''<summary>
    '''Liefert das Attribut vom Type T, der Eigenschaft propertyDescriptor, der Instanz context.
    '''</summary>
    Public Function [Get](Of T As Attribute)(ByVal context As Object, ByVal propertyDescriptor As PropertyDescriptor) As T

      Return DirectCast([Get](context, propertyDescriptor.Name, GetType(T)), T)
    End Function

    '''<summary>Liefert das Attribut vom Type T, der Eigenschaft propertyName, der Instanz context.</summary>
    Public Function [Get](Of T As Attribute)(ByVal context As Object, ByVal propertyName As String) As T

      Return DirectCast([Get](context, propertyName, GetType(T)), T)
    End Function

    '''<summary>
    '''Liefert das Attribut vom Type attributeType, der Eigenschaft propertyDescriptor, der Instanz context.
    '''</summary>
    Public Function [Get](ByVal context As Object, ByVal propertyDescriptor As PropertyDescriptor, ByVal attributeType As Type) As Attribute

      Return [Get](context, propertyDescriptor, attributeType)
    End Function

    '''<summary>
    '''Liefert das Attribut vom Type attributeType, der Eigenschaft propertyName, der Instanz context.
    '''</summary>
    Public Function [Get](ByVal context As Object, ByVal propertyName As String, ByVal attributeType As Type) As Attribute

      Dim pd = (New ReflectionPropertyDescriptor).Get(context, propertyName)
      Dim attributes = GetArrayByPropertyDescriptor(pd, attributeType)

      Return attributes.FirstOrDefault
    End Function

    '''<summary>Liefert das Attribut vom Type T, der Instanz context.</summary>
    Public Function [Get](Of T As Attribute)(ByVal context As Object) As T

      Return DirectCast([Get](context, GetType(T)), T)
    End Function

    '''<summary>Liefert das Attribut vom Type attributeType, der Instanz context.</summary>
    Public Function [Get](ByVal context As Object, ByVal attributeType As Type) As Attribute

      Return TypeDescriptor.GetAttributes(context).Item(attributeType)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace