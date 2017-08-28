Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports BCW.Foundation.Base.DateTimeHandling.AcademicYearHandling.Enums
#End Region

Namespace DateTimeHandling.AcademicYearHandling

  '''<summary>Repräsentiert die zeitlichen Einteilungen in einem Studienjahr (z.B. zwei Semester).</summary>
  Public MustInherit Class AcademicYearClassification

    Inherits List(Of AcademicYearClassificationPeriod)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert die Dauer einer Periode (z.B. Semester) in Monaten.</summary>
    Public ReadOnly Property DurationInMonth As Int32
      Get
        Return 12 \ Me.Count
      End Get
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Liefert das AcademicYearClassificationPeriod-Objekt zur angegebenen Periode</summary>
    Public Function GetPeriod(ByVal period As Periods) As AcademicYearClassificationPeriod
      Return Me.Item(period)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace