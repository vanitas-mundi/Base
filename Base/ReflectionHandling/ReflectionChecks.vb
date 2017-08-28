Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.ComponentModel
Imports System.Reflection
#End Region

Namespace ReflectionHandling

  Public Class ReflectionChecks

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
    '''Prüft, ob die Eigenschaft propertyName, der Instanz context, ein Attribut vom Type T besitzt.
    '''</summary>
    Public Function ExistsAttribute(Of T As Attribute)(ByVal context As Object, ByVal propertyName As String) As Boolean

      Return ExistsAttribute(context, propertyName, GetType(T))
    End Function

    '''<summary>
    '''Prüft, ob die Eigenschaft propertyName, der Instanz context, ein Attribut vom Type T besitzt.
    '''</summary>
    Public Function ExistsAttribute(Of T As Attribute)(ByVal context As Object, ByVal propertyDescriptor As PropertyDescriptor) As Boolean

      Return ExistsAttribute(context, propertyDescriptor.Name, GetType(T))
    End Function

    '''<summary>
    '''Prüft, ob die Eigenschaft propertyDescriptor, der Instanz context, ein Attribut vom Type attributeType besitzt.
    '''</summary>
    Public Function ExistsAttribute(ByVal context As Object, ByVal propertyDescriptor As PropertyDescriptor, ByVal attributeType As Type) As Boolean

      Dim pd = (New ReflectionPropertyDescriptor).Get(context, propertyDescriptor.Name)
      Return (New ReflectionAttribute).GetArrayByPropertyDescriptor(pd, attributeType).Any
    End Function

    '''<summary>
    '''Prüft, ob die Eigenschaft propertyInfo, des Typs t, ein Attribut vom Type attributeType besitzt.
    '''</summary>
    Public Function ExistsAttribute(ByVal t As Type, ByVal propertyInfo As PropertyInfo, ByVal attributeType As Type) As Boolean

      Return t.GetProperty(propertyInfo.Name).GetCustomAttributes(attributeType, False).Any
    End Function

    '''<summary>
    '''Prüft, ob die Eigenschaft propertyName, der Instanz context, ein Attribut vom Type attributeType besitzt.
    '''</summary>
    Public Function ExistsAttribute(ByVal context As Object, ByVal propertyName As String, ByVal attributeType As Type) As Boolean

      Dim pd = (New ReflectionPropertyDescriptor).Get(context, propertyName)
      Return (New ReflectionAttribute).GetArrayByPropertyDescriptor(pd, attributeType).Any
    End Function

    '''<summary>Prüft, ob der Typ t, ein Attribut vom Type attributeType besitzt.</summary>
    Public Function ExistsAttribute(ByVal t As Type, ByVal attributeType As Type) As Boolean

      Return t.GetCustomAttributes(attributeType, False).Any
    End Function

    '''<summary>Prüft, ob die Instanz context ein Attribut vom Type T besitzt.</summary>
    Public Function ExistsAttribute(Of T As Attribute)(ByVal context As Object) As Boolean

      Return ExistsAttribute(context, GetType(T))
    End Function

    '''<summary>Prüft, ob die Instanz  context ein Attribut vom Type attributeType besitzt.</summary>
    Public Function ExistsAttribute(ByVal context As Object, ByVal attributeType As Type) As Boolean

      Return TypeDescriptor.GetAttributes(context).Item(attributeType) IsNot Nothing
    End Function

    '''<summary>Prüft, ob die Eigenschaft propertyName der Instanz context Attribute besitzt.</summary>
    Public Function ExistsAttributes(ByVal context As Object, ByVal propertyName As String) As Boolean

      Dim desriptor = New ReflectionPropertyDescriptor
      Dim pd = desriptor.Get(context, propertyName)
      Return Attribute.GetCustomAttributes(pd.GetType).Any
    End Function

    '''<summary>Prüft, ob die Instanz context Attribute besitzt.</summary>
    Public Function ExistsAttributes(ByVal context As Object) As Boolean

      Return TypeDescriptor.GetAttributes(context).Count > 0
    End Function

    '''<summary>
    '''Prüft, ob das Attribut vom Objekt context, ein Attribut der Eigenschaft propertyName, der Klasse TObject ist.
    '''</summary>
    Public Function IsPropertyAttribute(Of TAttribute As {Attribute})(ByVal context As Object, ByVal propertyName As String) As Boolean

      Dim info = New ReflectionPropertyInfo
      Dim pi = info.Get(context, propertyName)
      Return If(pi IsNot Nothing, Attribute.IsDefined(pi, GetType(TAttribute)), False)
    End Function

    '''<summary>
    '''Prüft, ob das Attribut vom Type TAttribute, ein Attribut der Eigenschaft propertyName, der Klasse TObject ist.
    '''</summary>
    Public Function IsPropertyAttribute(Of TObject As {Class}, TAttribute As {Attribute})(ByVal propertyName As String) As Boolean

      Dim info = New ReflectionPropertyInfo
      Dim pi = info.Get(Of TObject)(propertyName)
      Return If(pi IsNot Nothing, Attribute.IsDefined(pi, GetType(TAttribute)), False)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace