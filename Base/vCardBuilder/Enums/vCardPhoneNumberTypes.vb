Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace vCardBuilder.Enums

  Public Enum vCardPhoneNumberTypes
    '''<summary>Indicate a telephone number associated with a residence.</summary>
    home = 0
    '''<summary>Indicate the telephone number has voice messaging support.</summary>
    msg = 1
    '''<summary>Indicate a telephone number associated with a place of work.</summary>
    work = 2
    '''<summary>Indicate a preferred-use telephone number.</summary>
    pref = 3
    '''<summary>Indicate a voice telephone number.</summary>
    voice = 4
    '''<summary>Indicate a facsimile telephone number.</summary>
    fax = 5
    '''<summary>Indicate a cellular telephone number</summary>
    cell = 6
    '''<summary>Indicate a video conferencing telephone number.</summary>
    video = 7
    '''<summary>Indicate a paging device telephone number.</summary>
    pager = 8
    '''<summary>Indicate a bulletin board system telephone number.</summary>
    bbs = 9
    '''<summary>Indicate a MODEM connected telephone number.</summary>
    modem = 10
    '''<summary>Indicate a car-phone telephone number.</summary>
    car = 11
    '''<summary>Indicate an ISDN service telephone number.</summary>
    isdn = 12
    '''<summary>Indicate a personal communication services telephone number.</summary>
    pcs = 13
  End Enum

End Namespace
