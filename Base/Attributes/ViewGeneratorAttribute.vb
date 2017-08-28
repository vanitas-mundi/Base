Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Attributes

  Public Class ViewGeneratorAttribute

    Inherits Attribute

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "

    Public Property DisplayName As String = ""
    Public Property IsRequired As Boolean = False
    Public Property IsReadonly As Boolean = False
    Public Property IsBrowseable As Boolean = True
    Public Property IsCategoryCollapsed As Boolean = False
    Public Property Category As String = ""
    Public Property StringFormat As String = ""
    Public Property CustomViewOrder As Int32 = Int32.MaxValue

    Public Property ViewType As ViewTypes = ViewTypes.TextBox
    Public Property ImageWidth As Double = 0
    Public Property ImageHeight As Double = 0
    Public Property HidePropertyName As Boolean = False
    Public Property ToolTipText As String = ""
    Public Property CustomEditorType As Type = Nothing
    Public Property ConverterType As Type = Nothing
    Public Property ViewListType As Type = Nothing
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace