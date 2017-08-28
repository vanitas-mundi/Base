Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace ErrorHandling

	Public Class StackTraceInfo

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private _assemblyName As String
		Private _className As String
		Private _methodName As String
		Private _lineNumber As Int32
		Private _columnNumber As Int32
		Private _fileName As String
		Private _exception As Exception
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New(ByVal ex As Exception, ByVal sf As StackFrame)
			Initialize(ex, sf)
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public ReadOnly Property AssemblyName As String
			Get
				Return _assemblyName
			End Get
		End Property

		Public ReadOnly Property ClassName As String
			Get
				Return _className
			End Get
		End Property

		Public ReadOnly Property MethodName As String
			Get
				Return _methodName
			End Get
		End Property

		Public ReadOnly Property LineNumber As Int32
			Get
				Return _lineNumber
			End Get
		End Property

		Public ReadOnly Property ColumnNumber As Int32
			Get
				Return _columnNumber
			End Get
		End Property

		Public ReadOnly Property FullFileName As String
			Get
				Return _fileName
			End Get
		End Property

		Public ReadOnly Property FileName As String
			Get
				Return My.Computer.FileSystem.GetName(_fileName)
			End Get
		End Property

		Public ReadOnly Property Exception As Exception
			Get
				Return _exception
			End Get
		End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
		Private Sub Initialize(ByVal ex As Exception, ByVal sf As StackFrame)
			_assemblyName = sf.GetMethod.ReflectedType.Assembly.GetName.Name
			_className = sf.GetMethod.ReflectedType.Name
			_methodName = sf.GetMethod.Name
			_lineNumber = sf.GetFileLineNumber
			_fileName = sf.GetFileName
			_exception = ex
		End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Overrides Function ToString() As String
			Return String.Concat(Me.AssemblyName, ".", Me.ClassName, ".", Me.MethodName, " - line:", Me.LineNumber, " col:", Me.ColumnNumber)
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
