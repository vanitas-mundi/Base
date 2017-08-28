Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports "
Imports System.Text.RegularExpressions
Imports System.Text
#End Region

Namespace IniHandling

	Public Class IniParser

#Region " --------------->> Enumerationen der Klasse "
#End Region

#Region " --------------->> Eigenschaften der Klasse "
#End Region

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal iniString As String)
      Me.IniString = iniString
    End Sub

    Public Sub New(ByVal fileName As String, ByVal encoding As Encoding)
      Me.fileName = fileName
      Me.Encoding = encoding
    End Sub
#End Region

#Region " --------------->> Zugriffsmethoden der Klasse "
    Private ReadOnly Property FileName As String = String.Empty

    Private ReadOnly Property Encoding As Encoding = Encoding.Default

    Private ReadOnly Property IniString As String = String.Empty

    '''<summary>Auflistung aller Sektionen.</summary>
    Public ReadOnly Property Sections As New Sections

    '''<summary>Legt das Standard-Kommentarzeichen fest oder gibt dieses zurück.</summary>
    Public Property DefaultCommentChar As String = ";"

    Private ReadOnly Property SectionsPattern As String = "^\[.*\]"

    Private ReadOnly Property CommentPattern As String = "[;\#][^\n]*"
#End Region

#Region " --------------->> Private Methoden der Klasse "
    Private Function GetIniString() As String

			Dim sb = New StringBuilder
      For Each sectionName In Me.Sections.SectionNames
        For Each comment In Me.Sections.Item(sectionName).Comments
          sb.AppendLine($"{_DefaultCommentChar} {comment}")
        Next comment

        sb.AppendLine($"[{sectionName}]")

        For Each valueName In Me.Sections.Item(sectionName).ValueNames
          Dim sectionValue = Me.Sections.Item(sectionName).Item(valueName)

          For Each comment In sectionValue.Comments
            sb.AppendLine($"{_DefaultCommentChar} {comment}")
          Next comment

          sb.AppendLine(If(sectionValue.ValueOnly, sectionValue.Value, $"{sectionValue.Name}={sectionValue.Value}"))
        Next valueName

        sb.AppendLine()
      Next sectionName

      Return sb.ToString
		End Function

    Private Function GetParseString() As String

      With My.Computer.FileSystem
        Dim result = If(String.IsNullOrEmpty(_FileName), Me.IniString, .ReadAllText(_FileName, _Encoding))
        Return result

      End With
    End Function

    Private Sub InsertSections(ByVal parseString As String)

      For Each section In Regex.Matches(parseString, Me.SectionsPattern, RegexOptions.Multiline)
        Dim sectionName = section.ToString.Replace("[", String.Empty).Replace("]", String.Empty)
        Me.Sections.Add(sectionName.ToLower, New Section With {.Name = sectionName})
      Next section
    End Sub

    Private Function GetSectionsValues(ByVal parseString As String) As String()
      Return Regex.Split(parseString, Me.SectionsPattern, RegexOptions.Multiline)
    End Function

		Private Sub GetFirstSectionComment(ByVal sectionsValues As IEnumerable(Of String))

      Dim comments = Regex.Split(sectionsValues.First, "\n", RegexOptions.Multiline).Where _
      (Function(x) (x.Trim.StartsWith(";")) OrElse (x.Trim.StartsWith("#"))).Select _
      (Function(x) x.Substring(1).Trim).ToList()

      If comments.Any Then
				Me.Sections.First.Value.Comments.AddRange(comments)
			End If
		End Sub

    Private Sub InsertSectionValues(ByVal sectionsValues As String())

      Dim comments = New List(Of String)

      For i = 1 To sectionsValues.Count - 1
        Dim sectionValues = Regex.Split(sectionsValues(i), "\n", RegexOptions.Multiline)
        Dim currentSection = Me.Sections.Item(i - 1)

        If comments.Any Then currentSection.Comments.AddRange(comments)
        comments = New List(Of String)

        For Each sectionValueString In sectionValues

          If String.IsNullOrWhiteSpace(sectionValueString) Then Continue For

          If (sectionValueString.Trim.StartsWith(";")) OrElse (sectionValueString.Trim.StartsWith("#")) Then 'Kommentar
            comments.Add(sectionValueString.Substring(1).Trim)
          Else 'Value
            Dim sectionValue = New SectionValue
            If comments.Any Then sectionValue.Comments.AddRange(comments)

            Dim pos = sectionValueString.IndexOf("=")

            If pos = -1 Then
              sectionValue.Name = String.Empty
              sectionValue.Value = sectionValueString
              sectionValue.ValueOnly = True
            Else
              sectionValue.Name = sectionValueString.Substring(0, pos).Trim
              sectionValue.Value = sectionValueString.Substring(pos + 1).Trim
            End If

            currentSection.Values.Add(sectionValue)
            comments = New List(Of String)
          End If

        Next sectionValueString
      Next i
    End Sub
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>liefert die momentane Ini-Datei als String zurück.</summary>
    Public Overrides Function ToString() As String
			Return GetIniString()
		End Function

    '''<summary>
    '''Parsed die angegebene Ini-Datei oder Ini-String und stellt die Daten über den iniParser zur Verfügung.
    '''</summary>
    Public Sub ParseIni()

      Me.Sections.Clear()
      Dim parseString = GetParseString()

      'Kommentare entfernen
      'parseString = Regex.Replace(parseString, _commentPattern, "")

      InsertSections(parseString)
      Dim sectionsValues = GetSectionsValues(parseString)
      GetFirstSectionComment(sectionsValues)
      InsertSectionValues(sectionsValues)
    End Sub

    '''<summary>Setzt den Wert eines Schlüssels.</summary>
    Public Sub SetValue(ByVal sectionName As String, ByVal valueName As String, ByVal newvalue As String)

      Me.GetValue(sectionName, valueName).Value = newvalue
    End Sub

    '''<summary>Löscht einen Schlüssel einer Sektion.</summary>
    Public Sub RemoveValue(ByVal sectionName As String, ByVal valueName As String)

      With Me.Sections.Item(sectionName)
        .Values.Remove(.Item(valueName))
      End With
    End Sub

    '''<summary>Löscht eine Sektion.</summary>
    Public Sub RemoveSection(ByVal sectionName As String)

      Me.Sections.Remove(sectionName)
    End Sub

    '''<summary>Fügt einer Sektion einen Schlüssel hinzu.</summary>
    Public Sub AddValue(ByVal sectionName As String, ByVal valueName As String, ByVal value As String)

      With Me.Sections.Item(sectionName)
        .Values.Add(New SectionValue With {.Name = valueName, .Value = value})
      End With
    End Sub

    '''<summary>Fügt eine neue Sektion hinzu.</summary>
    Public Sub AddSection(ByVal sectionName As String)

      Me.Sections.Add(sectionName.ToLower, New Section With {.Name = sectionName})
    End Sub

    '''<summary>Benennt einer Schlüssel einer Sektion um.</summary>
    Public Sub RenameValue(ByVal sectionName As String, ByVal valueName As String, ByVal newName As String)

      Me.GetValue(sectionName, valueName).Name = newName
    End Sub

    '''<summary>Benennt eine Sektion um.</summary>
    Public Sub RenameSection(ByVal sectionName As String, ByVal newName As String)

      Dim section = Me.Sections.Item(sectionName)
      section.Name = newName

      Me.RemoveSection(sectionName)
      Me.Sections.Add(newName.ToLower, section)
    End Sub

    '''<summary>Speichert alle Änderungen in die, im Konstruktor, angegebene Ini-Datei.</summary>
    Public Sub Save()
			If String.IsNullOrEmpty(_fileName) Then Return
			Save(_fileName)
		End Sub

    ''' <summary>
    ''' Speichert alle Änderungen in die angegebene Ini-Datei.
    ''' </summary>
    Public Sub Save(ByVal fileName As String)
      My.Computer.FileSystem.WriteAllText(fileName, GetIniString, False, _encoding)
    End Sub

    '''<summary>Gibt die angegebene Sektion zurück.</summary>
    Public Function GetSection(ByVal sectionName As String) As Section
      Return Me.Sections.Item(sectionName)
    End Function

    '''<summary>Gibt den angegebenen Schlüssel aus der Sektion zurück.</summary>
    Public Function GetValue(ByVal sectionName As String, ByVal valueName As String) As SectionValue

      Return Me.Sections.Item(sectionName).Item(valueName)
    End Function

    '''<summary>
    '''Prüft ob valueName in der Sektion sectionName vorhanden ist.</summary>
    Public Function ExistValue(ByVal sectionName As String, ByVal valueName As String) As Boolean

      Return Me.Sections.ContainsKey(sectionName) AndAlso Me.Sections.Item(sectionName).ContainsKey(valueName)
    End Function


    '''<summary>
    '''Gibt den angegebenen Schlüssel aus der Sektion zurück, sollte dieser nicht 
    '''vorhanden sein wird ein SectionValue-Objekt mit dem Wert "" geliefert.
    '''</summary>
    Public Function GetValueOrEmpty(ByVal sectionName As String, ByVal valueName As String) As SectionValue

      Dim result = If(ExistValue(sectionName, valueName) _
      , Me.GetValue(sectionName, valueName), New SectionValue With {.Name = valueName, .Value = String.Empty})

      Return result
    End Function

    '''<summary>Gibt die Kommentare einer Sektion zurück.</summary>
    Public Function GetSectionComments(ByVal sectionName As String) As List(Of String)
      Return Me.GetSection(sectionName).Comments
    End Function

    '''<summary>Gibt die Kommentare des angegebenen Schlüssels einer Sektion zurück.</summary>
    Public Function GetValueComments(ByVal sectionName As String, ByVal valueName As String) As List(Of String)
      Return Me.GetValue(sectionName, valueName).Comments
    End Function
#End Region

  End Class

End Namespace
