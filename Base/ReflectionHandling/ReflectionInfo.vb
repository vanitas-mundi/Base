Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Reflection
Imports System.Text
#End Region

Namespace ReflectionHandling

  '''<summary>
  '''Stellt Funktionalitat zur Verfügung, um alle lesbaren Eigenschaften
  '''eines Objektes auszulesen.
  ''' </summary>
  Public Class ReflectionInfo

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Private _context As Object
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal context As Object)
      _context = context
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Liefert ein Liste von PropertyInfo-Objekten aller lesbaren Eigenschaften.</summary>
    Public Function GetReadablePropertyInfoList() As List(Of PropertyInfo)

      Return _context.GetType.GetProperties.OfType(Of PropertyInfo).Where(Function(x) x.CanRead).ToList
    End Function

    '''<summary>Liefert ein Object-Array der Eigenschaftsnamen.</summary>
    Public Function ToNameArray() As String()

      Return Me.GetReadablePropertyInfoList.Select(Function(x) x.Name).ToArray
    End Function

    '''<summary>Liefert ein Object-Array der Eigenschaftswerte.</summary>
    Public Function ToValueArray() As Object()

      Return Me.GetReadablePropertyInfoList.Select(Function(x) x.GetValue(_context)).ToArray
    End Function

    '''<summary>Liefert ein String-Array mit den in Strings umgewandelten Eigenschaftswerten.</summary>
    '''<param name="nullValueToNullString">
    '''Wenn true wird für Null-Werte "Null" geliefert,
    '''sonst ein Leerstring
    '''</param>
    Public Function ToValueStringArray(ByVal nullValueToNullString As Boolean) As String()

      Dim result = Me.GetReadablePropertyInfoList
      Return result.Select(Function(x) If(x.GetValue(_context) Is Nothing, "Null", x.GetValue(_context).ToString)).ToArray
    End Function

    '''<summary>Liefert einen String der Eigenschaftsnamen.</summary>
    Public Function ToNamesString() As String
      Return ToNamesString(",")
    End Function

    '''<summary>Liefert einen String der Eigenschaftsnamen.</summary>
    Public Function ToNamesString(ByVal delimiter As String) As String

      Dim result = Me.GetReadablePropertyInfoList.Select(Function(x) x.Name).ToArray
      Return String.Join(delimiter, result)
    End Function

    '''<summary>Liefert einen String mit den in Strings umgewandelten Eigenschaftswerten.</summary>
    Public Function ToValuesString() As String

      Return ToValuesString(",")
    End Function

    '''<summary>Liefert einen String mit den in Strings umgewandelten Eigenschaftswerten.</summary>
    Public Function ToValuesString(ByVal delimiter As String) As String

      Dim result = Me.GetReadablePropertyInfoList
      result.Select(Function(x) If(x.GetValue(_context) Is Nothing, "Null", x.GetValue(_context).ToString).Replace(vbCrLf, " ")).ToArray
      Return String.Join(delimiter, result)
    End Function

    '''<summary>
    '''Liefert einen String mit den in Strings umgewandelten Eigenschaftswerten und voran gestelltem Eigenschafts-Namen.
    '''</summary>
    Public Function ToNamesValuesString() As String

      Return ToNamesValuesString(":", ",")
    End Function

    '''<summary>
    '''Liefert einen String mit den in Strings umgewandelten Eigenschaftswerten
    '''und voran gestelltem Eigenschafts-Namen.
    '''</summary>
    Public Function ToNamesValuesString(ByVal nameValueDelimiter As String, ByVal delimiter As String) As String

      Dim result = Me.GetReadablePropertyInfoList
      result.Select(Function(x) $"{ x.Name}{nameValueDelimiter}{If(x.GetValue(_context) Is Nothing, "Null", x.GetValue(_context).ToString)}")
      Return String.Join(delimiter, result)
    End Function

    '''<summary>
    '''Liefert einen String mit den in Strings umgewandelten Eigenschaftswerten und voran gestelltem Eigenschafts-Namen.
    '''</summary>
    Public Function ToCsvString() As String

      Return ToCsvString(",", vbCrLf, True)
    End Function


    '''<summary>
    '''Liefert einen String mit den in Strings umgewandelten Eigenschaftswerten und voran gestelltem Eigenschafts-Namen.
    '''</summary>
    Public Function ToCsvString _
    (ByVal columnDelimiter As String, ByVal rowDelimiter As String, ByVal includePropertyNames As Boolean) As String

      Dim sb = New StringBuilder

      If includePropertyNames Then
        sb.Append(ToNamesString(columnDelimiter))
        sb.Append(rowDelimiter)
      End If

      sb.Append(ToValuesString(columnDelimiter))

      Return sb.ToString
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
