Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

'Namespace
Public NotInheritable Class CB

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
	'''<summary>Leerzeichen</summary>
	Public Shared ReadOnly Property Space As String = " "

	'''<summary>Leer-String</summary>
	Public Shared ReadOnly Property Empty As String = String.Empty

	'''<summary>Null - Nullzeichen</summary>
	Public Shared ReadOnly Property Nul As Char = Convert.ToChar(ControlCodes.Nul)

	'''<summary>Start of Heading - Beginn der Kopfzeile</summary>
	Public Shared ReadOnly Property Soh As Char = Convert.ToChar(ControlCodes.Soh)

	'''<summary>Start of Text - Beginn der Nachricht</summary>
	Public Shared ReadOnly Property Stx As Char = Convert.ToChar(ControlCodes.Stx)

	'''<summary>End of Text - Ender der Nachricht</summary>
	Public Shared ReadOnly Property Ext As Char = Convert.ToChar(ControlCodes.Ext)

	'''<summary>End of Transmission - Ende der Übertragung</summary>
	Public Shared ReadOnly Property Eot As Char = Convert.ToChar(ControlCodes.Eot)

	'''<summary>Enquiry - Anfrage</summary>
	Public Shared ReadOnly Property Enq As Char = Convert.ToChar(ControlCodes.Enq)

	'''<summary>Acknowledge - Positive Betätigung</summary>
	Public Shared ReadOnly Property Ack As Char = Convert.ToChar(ControlCodes.Ack)

	'''<summary>Bell - Tonsignal</summary>
	Public Shared ReadOnly Property Bel As Char = Convert.ToChar(ControlCodes.Bel)

	'''<summary>Backspace - Rückschritt</summary>
	Public Shared ReadOnly Property Bs As Char = Convert.ToChar(ControlCodes.Bs)

	'''<summary>Backspace - Rückschritt</summary>
	Public Shared ReadOnly Property BackSpace As Char = CB.Bs

	'''<summary>Horizontal Tab - Horizontaler Tabulator</summary>
	Public Shared ReadOnly Property Ht As Char = Convert.ToChar(ControlCodes.Ht)

	'''<summary>Horizontal Tab - Horizontaler Tabulator</summary>
	Public Shared ReadOnly Property Tab As Char = CB.Ht

	'''<summary>Line Feed - Zeilenvorschub</summary>
	Public Shared ReadOnly Property Lf As Char = Convert.ToChar(ControlCodes.Lf)

	'''<summary>Vertical Tab - Vertikaler Tabulator</summary>
	Public Shared ReadOnly Property Vt As Char = Convert.ToChar(ControlCodes.Vt)

	'''<summary>Form Feed - Seitenvorschub</summary>
	Public Shared ReadOnly Property Ff As Char = Convert.ToChar(ControlCodes.Ff)

	'''<summary>Carriage Return - Wagenrücklauf</summary>
	Public Shared ReadOnly Property Cr As Char = Convert.ToChar(ControlCodes.Cr)

	'''<summary>Carriage Return + Line Feed - Wagenrücklauf und Zeilenvorschub</summary>
	Public Shared ReadOnly Property CrLf As String = $"{CB.Cr}{CB.Lf}"

	'''<summary>Shift Out - Umschaltung</summary>
	Public Shared ReadOnly Property So As Char = Convert.ToChar(ControlCodes.So)

	'''<summary>Shift In - Rückschaltung</summary>
	Public Shared ReadOnly Property Si As Char = Convert.ToChar(ControlCodes.Si)

	'''<summary>Data Link Escape - Datenverbindungs-Fluchtsymbol</summary>
	Public Shared ReadOnly Property Dle As Char = Convert.ToChar(ControlCodes.Dle)

	'''<summary>Device Control - Gerätekontrollzeichen 1</summary>
	Public Shared ReadOnly Property Dc1 As Char = Convert.ToChar(ControlCodes.Dc1)

	'''<summary>Device Control - Gerätekontrollzeichen 2</summary>
	Public Shared ReadOnly Property Dc2 As Char = Convert.ToChar(ControlCodes.Dc2)

	'''<summary>Device Control - Gerätekontrollzeichen 3</summary>
	Public Shared ReadOnly Property Dc3 As Char = Convert.ToChar(ControlCodes.Dc3)

	'''<summary>Device Control - Gerätekontrollzeichen 4</summary>
	Public Shared ReadOnly Property Dc4 As Char = Convert.ToChar(ControlCodes.Dc4)

	'''<summary>Negative Acknowledge - Negative Bestätigung</summary>
	Public Shared ReadOnly Property Nak As Char = Convert.ToChar(ControlCodes.Nak)

	'''<summary>Synchronous Idle - Synchronisierungssignal</summary>
	Public Shared ReadOnly Property Syn As Char = Convert.ToChar(ControlCodes.Syn)

	'''<summary>End of Transmission Block - Ende des Übertragungsblockes</summary>
	Public Shared ReadOnly Property Etb As Char = Convert.ToChar(ControlCodes.Etb)

	'''<summary>Cancel - Abbruch</summary>
	Public Shared ReadOnly Property Can As Char = Convert.ToChar(ControlCodes.Can)

	'''<summary>End of Medium - Ende des Mediums</summary>
	Public Shared ReadOnly Property Em As Char = Convert.ToChar(ControlCodes.Em)

	'''<summary>Substitute - Ersatz</summary>
	Public Shared ReadOnly Property [Sub] As Char = Convert.ToChar(ControlCodes.Sub)

	'''<summary>Escape - Fluchtsymbol</summary>
	Public Shared ReadOnly Property Esc As Char = Convert.ToChar(ControlCodes.Esc)

	'''<summary>File Separator - Dateitrenner</summary>
	Public Shared ReadOnly Property Fs As Char = Convert.ToChar(ControlCodes.Fs)

	'''<summary>Group Separator - Gruppentrenner</summary>
	Public Shared ReadOnly Property Gs As Char = Convert.ToChar(ControlCodes.Gs)

	'''<summary>Recors Separator - Datensatztrenner</summary>
	Public Shared ReadOnly Property Rs As Char = Convert.ToChar(ControlCodes.Rs)

	'''<summary>Unit Separator - Einheitentrenner</summary>
	Public Shared ReadOnly Property Us As Char = Convert.ToChar(ControlCodes.Us)

	'''<summary>Delete - Zeichen löschen</summary>
	Public Shared ReadOnly Property Del As Char = Convert.ToChar(ControlCodes.Del)

	'''<summary>Liefert NULL/Nothing</summary>
	Public Shared ReadOnly Property Null As Object = CB.Nothing

	'''<summary>Liefert NULL/Nothing</summary>
	Public Shared ReadOnly Property [Nothing] As Object = Nothing

	'''<summary>Liefert DbNull</summary>
	Public Shared ReadOnly Property DbNull As Object = Convert.DBNull
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
	'''<summary>Wandelt ord in ein Unicode-Zeichen um und liefert dieses zurück</summary>
	Public Shared Function Chr(ByVal ord As Int32) As Char
		Return Convert.ToChar(ord)
	End Function

	'''<summary>Wandelt ord in ein Unicode-Zeichen um und liefert dieses als String zurück</summary>
	Public Shared Function Str(ByVal ord As Int32) As String
		Return Chr(ord).ToString
	End Function

	'''<summary>Wandelt das Zeichen c in dessen Oridinalzahl um und liefert dieses zurück</summary>
	Public Shared Function Ord(ByVal c As Char) As Int32
		Return Convert.ToInt32(c)
	End Function

	'''<summary>Wandelt das erste Zeichen des Strings s in dessen Oridinalzahl um und liefert dieses zurück</summary>
	Public Shared Function Ord(ByVal c As String) As Int32
		Return Ord(c.First)
	End Function

	'''<summary>Wandelt das Zeichen c in dess Oridinalzahl um und liefert dieses zurück</summary>
	Public Shared Function Asc(ByVal c As Char) As Int32
		Return Convert.ToInt32(c)
	End Function

	'''<summary>Wandelt das erste Zeichen des Strings s in dessen Oridinalzahl um und liefert dieses zurück</summary>
	Public Shared Function Asc(ByVal c As String) As Int32
		Return Ord(c.First)
	End Function

	Public Sub Haul()

	End Sub
#End Region '{Öffentliche Methoden der Klasse}

End Class


