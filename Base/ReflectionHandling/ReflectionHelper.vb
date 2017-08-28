Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace ReflectionHandling

  Public NotInheritable Class ReflectionHelper

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Friend Sub New()
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Setllt Reflection-Funktionalität für Eigenschaften zur Verfügung.</summary>
    Public ReadOnly Property [Property] As ReflectionProperty = New ReflectionProperty

    '''<summary>Setllt Reflection-Funktionalität für Methoden zur Verfügung.</summary>
    Public ReadOnly Property Method As ReflectionMethod = New ReflectionMethod

    '''<summary>Setllt Reflection-Funktionalität für Methoden zur Verfügung.</summary>
    Public ReadOnly Property Constructor As ReflectionConstructor = New ReflectionConstructor

    '''<summary>Setllt Reflection-Funktionalität für Enums zur Verfügung.</summary>
    Public ReadOnly Property [Enum] As ReflectionEnum = New ReflectionEnum

    '''<summary>Setllt Reflection-Funktionalität für Attribute zur Verfügung.</summary>
    Public ReadOnly Property Attribute As ReflectionAttribute = New ReflectionAttribute

    '''<summary>Setllt Reflection-Funktionalität für die Konvertierung zur Verfügung.</summary>
    Public ReadOnly Property Convert As ReflectionConvert = New ReflectionConvert

    '''<summary>Setllt Reflection-Funktionalität für die Konvertierung zur Verfügung.</summary>
    Public ReadOnly Property Checks As ReflectionChecks = New ReflectionChecks

    '''<summary>Setllt Reflection-Funktionalität für PropertyDescriptor zur Verfügung.</summary>
    Public ReadOnly Property PropertyDescriptor As ReflectionPropertyDescriptor = New ReflectionPropertyDescriptor

    '''<summary>Setllt Reflection-Funktionalität für ReflectionPropertyInfo zur Verfügung.</summary>
    Public ReadOnly Property PropertyInfo As ReflectionPropertyInfo = New ReflectionPropertyInfo

#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
