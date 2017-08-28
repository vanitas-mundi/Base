Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.ComponentModel
Imports System.Reflection
#End Region

Namespace ReflectionHandling

  Public Class ReflectionConvert

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
    '''<summary>Wandelt das PropertyInfo-Objekt pi, der Instanz context, in einen PropertyDescriptor um.</summary>
    Public Function PropertyInfoToPropertyDescriptor _
    (ByVal context As Object, ByVal pi As PropertyInfo) As PropertyDescriptor

      Return TypeDescriptor.GetProperties(context).Item(pi.Name)
    End Function

    '''<summary>Wandelt den PropertyDescriptor pd, der Instanz context, in ein PropertyInfo-Objekt um.</summary>
    Public Function PropertyDescriptorToPropertyInfo _
    (ByVal context As Object, ByVal pd As PropertyDescriptor) As PropertyInfo

      Dim result = context.GetType.GetProperties.Where(Function(x) x.Name = pd.Name).ToArray
      Return If(result.Any, result.First, Nothing)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace