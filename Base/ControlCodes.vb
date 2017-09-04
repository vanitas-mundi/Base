Option Explicit On
Option Infer On
Option Strict On

Public Enum ControlCodes
	'''<summary>Null - Nullzeichen</summary>
	Nul = 0
	'''<summary>Start of Heading - Beginn der Kopfzeile</summary>
	Soh = 1
	'''<summary>Start of Text - Beginn der Nachricht</summary>
	Stx = 2
	'''<summary>End of Text - Ender der Nachricht</summary>
	Ext = 3
	'''<summary>End of Transmission - Ende der Übertragung</summary>
	Eot = 4
	'''<summary>Enquiry - Anfrage</summary>
	Enq = 5
	'''<summary>Acknowledge - Positive Betätigung</summary>
	Ack = 6
	'''<summary>Bell - Tonsignal</summary>
	Bel = 7
	'''<summary>Backspace - Rückschritt</summary>
	Bs = 8
	'''<summary>Horizontal Tab - Horizontaler Tabulator</summary>
	Ht = 9
	'''<summary>Line Feed - Zeilenvorschub</summary>
	Lf = 10
	'''<summary>Vertical Tab - Vertikaler Tabulator</summary>
	Vt = 11
	'''<summary>Form Feed - Seitenvorschub</summary>
	Ff = 12
	'''<summary>Carriage Return - Wagenrücklauf</summary>
	Cr = 13
	'''<summary>Shift Out - Umschaltung</summary>
	So = 14
	'''<summary>Shift In - Rückschaltung</summary>
	Si = 15
	'''<summary>Data Link Escape - Datenverbindungs-Fluchtsymbol</summary>
	Dle = 16
	'''<summary>Device Control - Gerätekontrollzeichen 1</summary>
	Dc1 = 17
	'''<summary>Device Control - Gerätekontrollzeichen 2</summary>
	Dc2 = 18
	'''<summary>Device Control - Gerätekontrollzeichen 3</summary>
	Dc3 = 19
	'''<summary>Device Control - Gerätekontrollzeichen 4</summary>
	Dc4 = 20
	'''<summary>Negative Acknowledge - Negative Bestätigung</summary>
	Nak = 21
	'''<summary>Synchronous Idle - Synchronisierungssignal</summary>
	Syn = 22
	'''<summary>End of Transmission Block - Ende des Übertragungsblockes</summary>
	Etb = 23
	'''<summary>Cancel - Abbruch</summary>
	Can = 24
	'''<summary>End of Medium - Ende des Mediums</summary>
	Em = 25
	'''<summary>Substitute - Ersatz</summary>
	[Sub] = 26
	'''<summary>Escape - Fluchtsymbol</summary>
	Esc = 27
	'''<summary>File Separator - Dateitrenner</summary>
	Fs = 28
	'''<summary>Group Separator - Gruppentrenner</summary>
	Gs = 29
	'''<summary>Recors Separator - Datensatztrenner</summary>
	Rs = 30
	'''<summary>Unit Separator - Einheitentrenner</summary>
	Us = 31
	'''<summary>Delete - Zeichen löschen</summary>
	Del = 127
End Enum