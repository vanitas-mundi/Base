Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace vCardBuilder.Enums

  Public Enum vCardAddressTypes
    '''<summary>Indicate a domestic delivery address.</summary>
    dom = 0
    '''<summary>Indicate an international delivery address.</summary>
    intl = 1
    '''<summary>Indicate a postal delivery address.</summary>
    postal = 2
    '''<summary>Indicate a parcel delivery address.</summary>
    parcel = 3
    '''<summary>Indicate a delivery address for a residence.</summary>
    home = 4
    '''<summary>Indicate delivery address for a place of work.</summary>
    work = 5
    '''<summary>Indicate the preferred delivery address.</summary>
    pref = 6
  End Enum

End Namespace
