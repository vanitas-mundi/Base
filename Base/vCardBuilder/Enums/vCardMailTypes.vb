Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace vCardBuilder.Enums

  Public Enum vCardMailTypes
    '''<summary>Indicate an Internet addressing type.</summary>
    internet = 0
    '''<summary>Indicate a X.400 addressing type.</summary>
    x400 = 1
    '''<summary>Indicate a preferred-use email address when more than one is specified.</summary>
    pref = 2
  End Enum

End Namespace
