Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace DateTimeHandling

  Public Class DateTimeConvert

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
    '''Liefert ein Nullable ohne Wert, wenn obj folgende Werte besitzt:
    '''DBNull, Nothing, 01.01.0001 oder kein Datum ist.
    '''Im anderen Fall wird ein gültiges Datetime geliefert.
    '''</summary>
    Public Function ToNullableDateTime(ByVal obj As Object) As Nullable(Of DateTime)

      Dim result = New Nullable(Of DateTime)
      Dim validDate As DateTime

      If Not ((obj Is Nothing) _
      OrElse (Convert.IsDBNull(obj)) _
      OrElse (Not DateTime.TryParse(obj.ToString, validDate)) _
      OrElse (validDate = DateTime.MinValue)) Then
        result = validDate
      End If

      Return result
    End Function

    '''<summary>
    '''Liefert den Wert von defaultValue, wenn obj folgende Werte besitzt:
    '''DBNull, Nothing, 01.01.0001 oder kein Datum ist.
    '''Im anderen Fall wird ein obj als Datetime geliefert.
    '''</summary>
    Public Function ToDefaultDateTime(ByVal obj As Object, ByVal defaultValue As DateTime) As DateTime

      Dim validDate As DateTime

      If Not ((obj Is Nothing) _
      OrElse (Convert.IsDBNull(obj)) _
      OrElse (Not DateTime.TryParse(obj.ToString, validDate)) _
      OrElse (validDate = DateTime.MinValue)) Then
        Return validDate
      Else
        Return defaultValue
      End If
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace