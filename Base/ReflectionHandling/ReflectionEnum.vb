Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports BCW.Foundation.Base.Attributes
#End Region

Namespace ReflectionHandling

  Public Class ReflectionEnum

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
    '''Ermittelt alle EnumDisplayName-Attribute des übergebenen
    '''EnumTypes und liefert deren DisplayName-Eigenschaften oder
    '''den in einen String gewandelten Enum-Wert, wenn das Attribut
    '''nicht gesetzt wurde.
    '''</summary>
    Public Function DisplayNames(ByVal enumType As Type) As String()

      Dim result = New List(Of String)

      System.Enum.GetValues(enumType).OfType(Of Object).ToList.ForEach _
      (Sub(x) result.Add(ValueToDisplayName(x)))

      Return result.ToArray
    End Function

    '''<summary>Liefert den Enum-Value zum angegebenen displayName.</summary>
    Public Function DisplayNameToValue(ByVal enumType As Type, ByVal displayName As String) As Object

      Dim result = New Dictionary(Of String, Object)

      Dim temp = System.Enum.GetValues(enumType).OfType(Of Object).ToList
      temp.ForEach(Sub(x) result.Add(ValueToDisplayName(x), x))

      Return result.Item(displayName)
    End Function

    '''<summary>Liefert den Displayname zum angegebenen Enum-Value.</summary>
    Public Function ValueToDisplayName(ByVal enumValue As Object) As String

      Dim enumField = enumValue.GetType.GetField(enumValue.ToString)
      Dim result = enumField.GetCustomAttributes(False).OfType(Of EnumDisplayNameAttribute).FirstOrDefault?.DisplayName

      Return If(result, enumValue.ToString)
    End Function

    '''<summary>Liefert den Displaynamen zum angegebenen Enum-Value.</summary>
    Public Function GetEnumValueAttribute(Of T As Attribute)(ByVal enumValue As Object) As T

      Dim enumField = enumValue.GetType.GetField(enumValue.ToString)
      Return enumField.GetCustomAttributes(False).OfType(Of T).FirstOrDefault
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
