Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace EnumHandling

  Public Class EnumMethods

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>
    '''Liefert ein Array mit den einzelnen Enum-Werte eines aus mehreren Enum-Werten 
    '''bestehenden Enum-Wertes, wenn die Enumeration mit dem Flag-Attribut
    '''versehen wurde. 
    '''</summary>
    Public Shared Function GetEnumValuesFromFlaggedEnumValue _
    (Of T As Structure)(ByVal flaggedValue As Int32) As T()

      Dim result = New List(Of T)

      If flaggedValue > 0 Then

        Dim values = New List(Of Int32)

        For Each value In System.Enum.GetValues(GetType(T))
          values.Add(Convert.ToInt32(value))
        Next value

        values = values.OrderByDescending(Function(x) x).Where(Function(x) x > 0).ToList

        For Each value In values
          If flaggedValue \ value > 0 Then
            Dim valueName = System.Enum.GetName(GetType(T), value).ToString
            result.Add(CType(System.Enum.Parse(GetType(T), valueName), T))
            flaggedValue = flaggedValue Mod value
          End If
        Next value
      Else
        Dim valueName = System.Enum.GetName(GetType(T), flaggedValue).ToString
        result.Add(CType(System.Enum.Parse(GetType(T), valueName), T))
      End If
      Return result.ToArray
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace

