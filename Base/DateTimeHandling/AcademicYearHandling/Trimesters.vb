Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports BCW.Foundation.Base.DateTimeHandling.AcademicYearHandling.Enums
#End Region

Namespace DateTimeHandling.AcademicYearHandling

  Public NotInheritable Class Trimesters

    Inherits AcademicYearClassification

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "

#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Private Sub New()
      Me.Add(New AcademicYearClassificationPeriod(1, 3, Periods.WT))   ' Wintertrimester Jan-Mrz
      Me.Add(New AcademicYearClassificationPeriod(4, 6, Periods.FT))   ' Frühjahrstrimester Apr-Jun
      Me.Add(New AcademicYearClassificationPeriod(7, 9, Periods.ST))   ' Sommertrimester Jul-Sep
      Me.Add(New AcademicYearClassificationPeriod(10, 12, Periods.HT)) ' Herbsttrimester Okt-Dez
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Friend Shared ReadOnly Property Instance As New Trimesters

    '''<summary>Liefert das aktuelle Trimester.</summary>
    Public Shared ReadOnly Property Current As New Trimester
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Liefert das Trimester des angegebenen Datums.</summary>
    Public Shared Function GetByDate(ByVal d As DateTime) As Trimester
      Return New Trimester(d)
    End Function

    '''<summary>Liefert das Trimester des angegebenen Trimesterkürzels.</summary>
    Public Shared Function GetByPeriodCode(ByVal code As PeriodCode) As Trimester
      Return New Trimester(code)
    End Function

    '''<summary>Liefert das Trimester des angegebenen Jahres und Periode.</summary>
    Public Shared Function GetByYearAndPeriod(ByVal year As Int32, period As Periods) As Trimester
      Return New Trimester(year, period)
    End Function

    '''<summary>Liefert das aktuelle Trimester.</summary>
    Public Function GetTrimester() As Trimester
      Return New Trimester(DateTime.Now)
    End Function

    '''<summary>Liefert das Trimester des angegebenen Datums.</summary>
    Public Function GetTrimester(ByVal d As DateTime) As Trimester
      Return New Trimester(d)
    End Function

    '''<summary>Liefert das Trimester des angegebenen Trimesterkürzels.</summary>
    Public Function GetTrimester(ByVal code As PeriodCode) As Trimester
      Return New Trimester(code)
    End Function

    '''<summary>Liefert das Trimester des angegebenen Jahres und Periode.</summary>
    Public Function GetTrimester(ByVal year As Int32, period As Periods) As Trimester
      Return New Trimester(year, period)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
