Option Explicit On
Option Infer On
Option Strict On
Imports System.Reflection

#Region " --------------->> Imports/ usings "
#End Region

Namespace ReflectionHandling

  Public Class ReflectionPropertyInfo

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
    '''Liefert alle PropertyInfos des Typs t, welche über ein Attribut von attributeType verfügen als Array.
    '''</summary>
    Public Function GetArrayByAttribute(ByVal t As Type, ByVal attributeType As Type) As PropertyInfo()

      Dim result = t.GetProperties.Where(Function(x) x.GetCustomAttributes(attributeType, False).Any)
      Return result.ToArray
    End Function

    '''<summary>
    ''' Liefert ein Array mit PropertyInfo-Objekten aller Eigenschaften des Objektes context,
    ''' welche über das Attribut vom Typ TAttribute verfügen.
    ''' </summary>
    Public Function GetArrayByAttribute(Of TAttribute As {Attribute})(ByVal context As Object) As PropertyInfo()

      Dim checks = New ReflectionChecks
      Dim result = context.GetType.GetProperties.ToList
      Return result.Where(Function(x) checks.IsPropertyAttribute(Of TAttribute)(context, x.Name)).ToArray
    End Function

    '''<summary>
    ''' Liefert ein Array mit PropertyInfo-Objekten aller Eigenschaften der Klasse TObject,
    ''' welche über das Attribut vom Typ TAttribute verfügen.
    ''' </summary>
    Public Function GetArrayByAttribute(Of TObject As {Class}, TAttribute As {Attribute})() As PropertyInfo()

      Dim checks = New ReflectionChecks
      Dim result = GetType(TObject).GetProperties.ToList
      Return result.Where(Function(x) checks.IsPropertyAttribute(Of TObject, TAttribute)(x.Name)).ToArray
    End Function

    '''<summary>Liefert alle PropertyInfo-Objekte des Typs t als Array.</summary>
    Public Function GetArray(ByVal t As Type) As PropertyInfo()

      Return t.GetProperties
    End Function

    '''<summary>Liefert alle PropertyInfos der Instanz context.</summary>
    Public Function GetArray(ByVal context As Object) As PropertyInfo()

      Dim result = context.GetType.GetProperties
      Return result.ToArray
    End Function

    '''<summary>
    '''Liefert ein PropertyInfo-Objekt für die Eigenschaft propertyName, anhand des übergebenen Objektes context.
    ''' </summary>
    Public Function [Get](ByVal context As Object, ByVal propertyName As String) As PropertyInfo

      Return context.GetType.GetProperty(propertyName)
    End Function

    '''<summary>Liefert ein PropertyInfo-Objekt für die Eigenschaft propertyName, der Klasse TObject.</summary>
    Public Function [Get](Of TObject As {Class})(ByVal propertyName As String) As PropertyInfo

      Return GetType(TObject).GetProperty(propertyName)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace