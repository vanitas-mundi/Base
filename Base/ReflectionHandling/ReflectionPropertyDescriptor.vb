Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.ComponentModel
#End Region

Namespace ReflectionHandling

  Public Class ReflectionPropertyDescriptor

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
    '''<summary>Liefert alle PropertyDescriptoren der Instanz context als Array.</summary>
    Public Function GetArray(ByVal context As Object) As PropertyDescriptor()

      Dim result = TypeDescriptor.GetProperties(context).Cast(Of PropertyDescriptor)
      Return result.ToArray
    End Function

    '''<summary>
    '''Liefert alle PropertyDescriptoren der Instanz context,
    '''welche über das angegebene Attribute verfügen, als Array.
    '''</summary>
    Public Function GetArrayByAttribute(ByVal context As Object, ByVal attribute As Attribute) As PropertyDescriptor()

      Dim result = GetArray(context).Where(Function(x) x.Attributes.Contains(attribute))
      Return result.ToArray
    End Function

    '''<summary>Liefert einen PropertyDescriptor für die Eigenschaft propertyName, der Instanz context.</summary>
    Public Function [Get](ByVal context As Object, ByVal propertyName As String) As PropertyDescriptor

      Return TypeDescriptor.GetProperties(context).Item(propertyName)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace