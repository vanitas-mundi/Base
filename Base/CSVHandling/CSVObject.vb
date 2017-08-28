Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
Imports Microsoft.VisualBasic.FileIO
#End Region

Namespace CsvHandling

  ''' <summary>
  ''' http://de.wikipedia.org/wiki/CSV_(Dateiformat)
  ''' </summary>
  Public Class CsvObject

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
    Protected _hasColumnsRow As Boolean = True
    Private _columns As New List(Of String)
    Private _rows As New List(Of String())
    Private _columnDelimeter As String = ";"
    ''' <summary>Zeichen zur Trennung von Datensätzen (Zeilen).</summary>
    Private _rowDelimeter As String = vbCrLf
    ''' <summary>
    ''' Feldbegrenzerzeichen (auch: Textbegrenzungszeichen).
    ''' Zeichen, zur Nutzung von Sonderzeichen innerhalb der Daten.
    ''' </summary>
    Private _textDelimeter As String = """"
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
    End Sub

    'Public Sub New(ByVal dt As DataTable)
    '	DataTableToCsv(dt, Me)
    'End Sub

    'Public Sub New(ByVal dr As IDataReader)
    '	DataReaderToCsv(dr, Me)
    'End Sub
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Legt fest, ob Werte getrimmt werden.</summary>
    Public Property TrimWhiteSpace As Boolean = True

    ''' <summary>
    ''' cvs-Datei enthält Spaltenüberschriften in der ersten Zeile.
    ''' </summary>
    Public Property HasColumnsRow As Boolean
      Get
        Return _hasColumnsRow
      End Get
      Set(value As Boolean)
        _hasColumnsRow = value
      End Set
    End Property

    ''' <summary>
    ''' Liefert den Spaltenindex anhand des Spaltennamens.
    ''' </summary>
    Public ReadOnly Property ColumnIndexOf(ByVal name As String) As Int32
      Get
        Return Me.Columns.IndexOf(name)
      End Get
    End Property

    ''' <summary>
    ''' Zeichen zur Trennung von Datenfeldern (Spalten).
    ''' </summary>
    Public Property ColumnDelimeter As String
      Get
        Return _columnDelimeter
      End Get
      Set(value As String)
        _columnDelimeter = value
      End Set
    End Property

    ''' <summary>
    ''' Spalten der csv-Datei.
    ''' </summary>
    Public ReadOnly Property Columns As List(Of String)
      Get
        Return _columns
      End Get
    End Property

    ''' <summary>
    ''' Zeilen der csv-Datei.
    ''' </summary>
    Public ReadOnly Property Rows As List(Of String())
      Get
        Return _rows
      End Get
    End Property
#End Region

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
    ''' <summary>
    ''' Formatiert einen Wert anhand der csv-Spezifikation und liefert diesen zurück.
    ''' </summary>
    Private Function ValueToCsvValue(ByVal value As String, ByVal quotedValue As Boolean) As String

      Dim temp =If(Me.TrimWhiteSpace, value.Trim,value).Replace(vbCrLf, vbLf)
      If quotedValue Then
        Dim ret = temp.Replace(_textDelimeter, String.Format("{0}{0}", _textDelimeter))
        Return String.Format("{0}{1}{0}", _textDelimeter, ret)
      Else
        Return temp
      End If
    End Function

    ''' <summary>
    ''' Konvertiert die Zeile row in einen csv-formatierten String.
    ''' </summary>
    Private Function RowToString _
(ByVal row As IEnumerable(Of String), ByVal quotedValues As Boolean) As String

      Return String.Join(Me._columnDelimeter, row.Select _
  (Function(r) ValueToCsvValue(r, quotedValues)).ToArray)
    End Function
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
    ''' <summary>
    ''' Liefert ein Template-Arry für eine neue Zeile anhand der Spaltenanzahl und initialisert es mit Leerzeichen.
    ''' </summary>
    Public Function NewRow() As String()

      Return NewRow("")
    End Function

    ''' <summary>
    ''' Liefert ein Template-Arry für eine neue Zeile anhand der 
    ''' Spaltenanzahl und initialisert es mit dem Wert von defaultValue.
    ''' </summary>
    Public Function NewRow(ByVal defaultValue As String) As String()

      Return Me.Columns.Select(Function(c) defaultValue).ToArray
    End Function

    ''' <summary>
    ''' Fügt eine Zeile der csv-Datei hinzu.
    ''' </summary>
    Public Sub AddRow(ByVal values() As String)
      If values.Count = Me.Columns.Count Then
        _rows.Add(values)
      Else
        Throw New Exception("Count of columns mismatched.")
      End If
    End Sub

    ''' <summary>
    ''' Entfernt die Zeile aus der csv-Datei des angegebenen Indexes.
    ''' </summary>
    Public Sub RemoveRow(ByVal index As Int32)
      _rows.RemoveAt(index)
    End Sub

    ''' <summary>
    ''' Speichert die csv-Datei unter fileName.
    ''' </summary>
    Public Sub Save(ByVal fileName As String, ByVal writeHeader As Boolean, ByVal quotedValues As Boolean)

      My.Computer.FileSystem.WriteAllText _
(fileName, ToString(writeHeader, quotedValues), False, Encoding.UTF8)
    End Sub

    ''' <summary>
    ''' Speichert die csv-Datei unter fileName.
    ''' </summary>
    Public Sub Save(ByVal fileName As String)

      Save(fileName, _hasColumnsRow, True)
    End Sub

    ''' <summary>
    ''' Lädt eine csv-Datei ins CsvObject.
    ''' </summary>
    Public Sub Load(ByVal fileName As String)
      Load(fileName, Encoding.UTF8)
    End Sub

    ''' <summary>
    ''' Lädt eine csv-Datei ins CsvObject.
    ''' </summary>
    Public Sub Load(ByVal fileName As String, ByVal encoding As Encoding)
      Me.Columns.Clear()
      Me.Rows.Clear()

      Using parser = New TextFieldParser(fileName, encoding)
        parser.SetDelimiters(New String() {Me.ColumnDelimeter})
        parser.TrimWhiteSpace = Me.TrimWhiteSpace
        parser.HasFieldsEnclosedInQuotes = True

        If _hasColumnsRow Then
          Me.Columns.AddRange(parser.ReadFields)
        Else
          Dim row = parser.ReadFields
          Me.Columns.AddRange(row.ToList.Select(Function(c) ""))
          Me.AddRow(row)
        End If

        While Not parser.EndOfData
          Me.AddRow(parser.ReadFields)
        End While
      End Using
    End Sub

    ''' <summary>
    '''Wandelt den Inhalt des CsvObjects in einen csv-formatierten String um und liefert diesen zurück.
    ''' </summary>
    ''' <param name="writeHeader">Legt fest, ob eine Zeile für Spaltennamen zurückgegeben wird.</param>
    ''' <param name="quotedValues">Legt fest, ob Werte in Quoten gesetzt werden. Spaltennamen sind davon unberücksichtigt.</param>
    Public Overloads Function ToString(ByVal writeHeader As Boolean, ByVal quotedValues As Boolean) As String
      Dim sb = New StringBuilder

      If writeHeader Then
        sb.Append(String.Join(Me.ColumnDelimeter, _columns.ToArray) & _rowDelimeter)
      End If

      sb.Append(String.Join(_rowDelimeter, _rows.Select(Function(r) RowToString(r, quotedValues)).ToArray))

      Return sb.ToString
    End Function

    ''' <summary>
    '''Wandelt den Inhalt des CsvObjects in einen csv-formatierten String um und liefert diesen zurück.
    ''' </summary>
    Public Overrides Function ToString() As String

      Return Me.ToString(_hasColumnsRow, True)
    End Function
#End Region

  End Class

End Namespace
