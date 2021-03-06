﻿Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Runtime.CompilerServices
#End Region

Namespace ExtensionMethods

	Public Module ObjectExtensions

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

		<Extension()>
		Public Sub WriteLineStructureToConsole(Of T As Structure)(ByVal v As T)

			Console.WriteLine(v.ToString)
		End Sub

		<Extension()>
		Public Sub WriteStructureToConsole(Of T As Structure)(ByVal v As T)

			Console.Write(v.ToString)
		End Sub

		<Extension()>
		Public Sub WriteLineClassToConsole(Of T As Class)(ByVal v As T)

			Console.WriteLine(v.ToString)
		End Sub

		<Extension()>
		Public Sub WriteClassToConsole(Of T As Class)(ByVal v As T)

			Console.Write(v.ToString)
		End Sub

#End Region '{Öffentliche Methoden der Klasse}

	End Module

End Namespace
