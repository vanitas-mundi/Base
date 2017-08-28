Option Explicit On
Option Infer On
Option Strict On

Namespace StringHandling

#Region "Ignore Inspection"

	''' <summary>
	''' Quelle: ms-help://MS.VSCC.v90/MS.MSDNQTR.v90.de/fxref_mscorlib/html/63c619e3-0969-2f01-a2d4-79d0868a98c6.htm
	''' </summary>
	<CLSCompliant(True)>
	Public Enum CultureCodes
		''' <summary>Standardsprache</summary>
		a_Default = 0
		''' <summary>Afrikaans</summary>
		af = 1
		''' <summary>Afrikaans (Südafrika)</summary>
		af_ZA = 2
		''' <summary>Albanisch</summary>
		sq = 3
		''' <summary>Albanisch (Albanien)</summary>
		sq_AL = 4
		''' <summary>Arabisch</summary>
		ar = 5
		''' <summary>Arabisch (Algerien)</summary>
		ar_DZ = 6
		''' <summary>Arabisch (Bahrain)</summary>
		ar_BH = 7
		''' <summary>Arabisch (Ägypten)</summary>
		ar_EG = 8
		''' <summary>Arabisch (Irak)</summary>
		ar_IQ = 9
		''' <summary>Arabisch (Jordanien)</summary>
		ar_JO = 10
		''' <summary>Arabisch (Kuwait)</summary>
		ar_KW = 11
		''' <summary>Arabisch (Libanon)</summary>
		ar_LB = 12
		''' <summary>Arabisch (Libyen)</summary>
		ar_LY = 13
		''' <summary>Arabisch (Marokko)</summary>
		ar_MA = 14
		''' <summary>Arabisch (Oman)</summary>
		ar_OM = 15
		''' <summary>Arabisch (Katar)</summary>
		ar_QA = 16
		''' <summary>Arabisch (Saudi-Arabien)</summary>
		ar_SA = 17
		''' <summary>Arabisch (Syrien)</summary>
		ar_SY = 18
		''' <summary>Arabisch (Tunesien)</summary>
		ar_TN = 19
		''' <summary>Arabisch (V.A.E.)</summary>
		ar_AE = 20
		''' <summary>Arabisch (Jemen)</summary>
		ar_YE = 21
		''' <summary>Armenisch</summary>
		hy = 22
		''' <summary>Armenisch (Armenien)</summary>
		hy_AM = 23
		''' <summary>Aserbaidschanisch</summary>
		az = 24
		''' <summary>Aserbaidschanisch (Aserbaidschan, Kyrillisch)</summary>
		az_Cyrl_AZ = 25
		''' <summary>Aserbaidschanisch (Aserbaidschan, Lateinisch)</summary>
		az_Latn_AZ = 26
		''' <summary>Baskisch</summary>
		eu = 27
		''' <summary>Baskisch (Baskisch)</summary>
		eu_ES = 28
		''' <summary>Belarussisch</summary>
		be = 29
		''' <summary>Belarussisch (Belarus)</summary>
		be_BY = 30
		''' <summary>Bulgarisch</summary>
		bg = 31
		''' <summary>Bulgarisch (Bulgarien)</summary>
		bg_BG = 32
		''' <summary>Katalanisch</summary>
		ca = 33
		''' <summary>Katalanisch (Katalanisch)</summary>
		ca_ES = 34
		''' <summary>Chinesisch (Hongkong S.A.R., VRC)</summary>
		zh_HK = 35
		''' <summary>Chinesisch (Macau SAR)</summary>
		zh_MO = 36
		''' <summary>Chinesisch (VRC)</summary>
		zh_CN = 37
		''' <summary>Chinesisch (vereinfacht)</summary>
		zh_Hans = 38
		''' <summary>Chinesisch (Singapur)</summary>
		zh_SG = 39
		''' <summary>Chinesisch (Taiwan)</summary>
		zh_TW = 40
		''' <summary>Chinesisch (traditionell)</summary>
		zh_Hant = 41
		''' <summary>Kroatisch</summary>
		hr = 42
		''' <summary>Kroatisch (Kroatien)</summary>
		hr_HR = 43
		''' <summary>Tschechisch</summary>
		cs = 44
		''' <summary>Tschechisch (Tschechische Republik)</summary>
		cs_CZ = 45
		''' <summary>Dänisch</summary>
		da = 46
		''' <summary>Dänisch (Dänemark)</summary>
		da_DK = 47
		''' <summary>Divehi</summary>
		dv = 48
		''' <summary>Divehi (Malediven)</summary>
		dv_MV = 49
		''' <summary>Niederländisch</summary>
		nl = 50
		''' <summary>Niederländisch (Belgien)</summary>
		nl_BE = 51
		''' <summary>Niederländisch (Niederlande)</summary>
		nl_NL = 52
		''' <summary>Englisch</summary>
		en = 53
		''' <summary>Englisch (Australien)</summary>
		en_AU = 54
		''' <summary>Englisch (Belize)</summary>
		en_BZ = 55
		''' <summary>Englisch (Kanada)</summary>
		en_CA = 56
		''' <summary>Englisch (Karibik)</summary>
		en_029 = 57
		''' <summary>Englisch (Irland)</summary>
		en_IE = 58
		''' <summary>Englisch (Jamaika)</summary>
		en_JM = 59
		''' <summary>Englisch (Neuseeland)</summary>
		en_NZ = 60
		''' <summary>Englisch (Philippinen)</summary>
		en_PH = 61
		''' <summary>Englisch (Südafrika)</summary>
		en_ZA = 62
		''' <summary>Englisch (Trinidad und Tobago)</summary>
		en_TT = 63
		''' <summary>Englisch (Großbritannien)</summary>
		en_GB = 64
		''' <summary>Englisch (USA)</summary>
		en_US = 65
		''' <summary>Englisch (Simbabwe)</summary>
		en_ZW = 66
		''' <summary>Estnisch</summary>
		et = 67
		''' <summary>Estnisch (Estland)</summary>
		et_EE = 68
		''' <summary>Färingisch</summary>
		fo = 69
		''' <summary>Färingisch (Färöer)</summary>
		fo_FO = 70
		''' <summary>Farsi</summary>
		fa = 71
		''' <summary>Farsi (Iran)</summary>
		fa_IR = 72
		''' <summary>Finnisch</summary>
		fi = 73
		''' <summary>Finnisch (Finnland)</summary>
		fi_FI = 74
		''' <summary>Französisch</summary>
		fr = 75
		''' <summary>Französisch (Belgien)</summary>
		fr_BE = 76
		''' <summary>Französisch (Kanada)</summary>
		fr_CA = 77
		''' <summary>Französisch (Frankreich)</summary>
		fr_FR = 78
		''' <summary>Französisch (Luxemburg)</summary>
		fr_LU = 79
		''' <summary>Französisch (Monaco)</summary>
		fr_MC = 80
		''' <summary>Französisch (Schweiz)</summary>
		fr_CH = 81
		''' <summary>Galizisch</summary>
		gl = 82
		''' <summary>Galizisch (Spanien)</summary>
		gl_ES = 83
		''' <summary>Georgisch</summary>
		ka = 84
		''' <summary>Georgisch (Georgien)</summary>
		ka_GE = 85
		''' <summary>Deutsch</summary>
		de = 86
		''' <summary>Deutsch (Österreich)</summary>
		de_AT = 87
		''' <summary>Deutsch (Deutschland)</summary>
		de_DE = 88
		''' <summary>Deutsch (Liechtenstein)</summary>
		de_LI = 89
		''' <summary>Deutsch (Luxemburg)</summary>
		de_LU = 90
		''' <summary>Deutsch (Schweiz)</summary>
		de_CH = 91
		''' <summary>Griechisch</summary>
		el = 92
		''' <summary>Griechisch (Griechenland)</summary>
		el_GR = 93
		''' <summary>Gujarati</summary>
		gu = 94
		''' <summary>Gujarati (Indien)</summary>
		gu_IN = 95
		''' <summary>Hebräisch</summary>
		he = 96
		''' <summary>Hebräisch (Israel)</summary>
		he_IL = 97
		''' <summary>Hindi</summary>
		hi = 98
		''' <summary>Hindi (Indien)</summary>
		hi_IN = 99
		''' <summary>Ungarisch</summary>
		hu = 100
		''' <summary>Ungarisch (Ungarn)</summary>
		hu_HU = 101
		''' <summary>Isländisch</summary>
		[is] = 102
		''' <summary>Isländisch (Island)</summary>
		is_IS = 103
		''' <summary>Indonesisch</summary>
		id = 104
		''' <summary>Indonesisch (Indonesien)</summary>
		id_ID = 105
		''' <summary>Italienisch</summary>
		it = 106
		''' <summary>Italienisch (Italien)</summary>
		it_IT = 107
		''' <summary>Italienisch (Schweiz)</summary>
		it_CH = 108
		''' <summary>Japanisch</summary>
		ja = 109
		''' <summary>Japanisch (Japan)</summary>
		ja_JP = 110
		''' <summary>Kannada</summary>
		kn = 111
		''' <summary>Kannada (Indien)</summary>
		kn_IN = 112
		''' <summary>Kasachisch</summary>
		kk = 113
		''' <summary>Kasachisch (Kasachstan)</summary>
		kk_KZ = 114
		''' <summary>Konkani</summary>
		kok = 115
		''' <summary>Konkani (Indien)</summary>
		kok_IN = 116
		''' <summary>Koreanisch</summary>
		ko = 117
		''' <summary>Koreanisch (Korea)</summary>
		ko_KR = 118
		''' <summary>Kirgisisch</summary>
		ky = 119
		''' <summary>Kirgisisch (Kirgisistan)</summary>
		ky_KG = 120
		''' <summary>Lettisch</summary>
		lv = 121
		''' <summary>Lettisch (Lettland)</summary>
		lv_LV = 122
		''' <summary>Litauisch</summary>
		lt = 123
		''' <summary>Litauisch (Litauen)</summary>
		lt_LT = 124
		''' <summary>Mazedonisch</summary>
		mk = 125
		''' <summary>Mazedonisch (Mazedonien, FYROM)</summary>
		mk_MK = 126
		''' <summary>Malaiisch</summary>
		ms = 127
		''' <summary>Malaiisch (Brunei Darussalam)</summary>
		ms_BN = 128
		''' <summary>Malaiisch (Malaysia)</summary>
		ms_MY = 129
		''' <summary>Marathi</summary>
		mr = 130
		''' <summary>Marathi (Indien)</summary>
		mr_IN = 131
		''' <summary>Mongolisch</summary>
		mn = 132
		''' <summary>Mongolisch (Mongolei)</summary>
		mn_MN = 133
		''' <summary>Norwegisch</summary>
		no = 134
		''' <summary>Norwegisch (Bokmål, Norwegen)</summary>
		nb_NO = 135
		''' <summary>Norwegisch (Nynorsk, Norwegen)</summary>
		nn_NO = 136
		''' <summary>Polnisch</summary>
		pl = 137
		''' <summary>Polnisch (Polen)</summary>
		pl_PL = 138
		''' <summary>Portugiesisch</summary>
		pt = 139
		''' <summary>Portugiesisch (Brasilien)</summary>
		pt_BR = 140
		''' <summary>Portugiesisch (Portugal)</summary>
		pt_PT = 141
		''' <summary>Punjabi</summary>
		pa = 142
		''' <summary>Punjabi (Indien)</summary>
		pa_IN = 143
		''' <summary>Rumänisch</summary>
		ro = 144
		''' <summary>Rumänisch (Rumänien)</summary>
		ro_RO = 145
		''' <summary>Russisch</summary>
		ru = 146
		''' <summary>Russisch (Russland)</summary>
		ru_RU = 147
		''' <summary>Sanskrit</summary>
		sa = 148
		''' <summary>Sanskrit (Indien)</summary>
		sa_IN = 149
		''' <summary>Serbisch (Serbien, Kyrillisch)</summary>
		sr_Cyrl_CS = 150
		''' <summary>Serbisch (Serbien, Lateinisch)</summary>
		sr_Latn_CS = 151
		''' <summary>Slowakisch</summary>
		sk = 152
		''' <summary>Slowakisch (Slowakei)</summary>
		sk_SK = 153
		''' <summary>Slowenisch</summary>
		sl = 154
		''' <summary>Slowenisch (Slowenien)</summary>
		sl_SI = 155
		''' <summary>Spanisch</summary>
		es = 156
		''' <summary>Spanisch (Argentinien)</summary>
		es_AR = 157
		''' <summary>Spanisch (Bolivien)</summary>
		es_BO = 158
		''' <summary>Spanisch (Chile)</summary>
		es_CL = 159
		''' <summary>Spanisch (Kolumbien)</summary>
		es_CO = 160
		''' <summary>Spanisch (Costa Rica)</summary>
		es_CR = 161
		''' <summary>Spanisch (Dominikanische Republik)</summary>
		es_DO = 162
		''' <summary>Spanisch (Ecuador)</summary>
		es_EC = 163
		''' <summary>Spanisch (El Salvador)</summary>
		es_SV = 164
		''' <summary>Spanisch (Guatemala)</summary>
		es_GT = 165
		''' <summary>Spanisch (Honduras)</summary>
		es_HN = 166
		''' <summary>Spanisch (Mexiko)</summary>
		es_MX = 167
		''' <summary>Spanisch (Nicaragua)</summary>
		es_NI = 168
		''' <summary>Spanisch (Panama)</summary>
		es_PA = 169
		''' <summary>Spanisch (Paraguay)</summary>
		es_PY = 170
		''' <summary>Spanisch (Peru)</summary>
		es_PE = 171
		''' <summary>Spanisch (Puerto Rico)</summary>
		es_PR = 172
		''' <summary>Spanisch (Spanien)</summary>
		es_ES = 173
		''' <summary>Spanisch (Spanien, herkömmliche Sortierreihenfolge)</summary>
		es_ES_tradnl = 174
		''' <summary>Spanisch (Uruguay)</summary>
		es_UY = 175
		''' <summary>Spanisch (Venezuela)</summary>
		es_VE = 176
		''' <summary>Swahili</summary>
		sw = 177
		''' <summary>Swahili (Kenia)</summary>
		sw_KE = 178
		''' <summary>Schwedisch</summary>
		sv = 179
		''' <summary>Schwedisch (Finnland)</summary>
		sv_FI = 180
		''' <summary>Schwedisch (Schweden)</summary>
		sv_SE = 181
		''' <summary>Syrisch</summary>
		syr = 182
		''' <summary>Syrisch (Syrien)</summary>
		syr_SY = 183
		''' <summary>Tamil</summary>
		ta = 184
		''' <summary>Tamil (Indien)</summary>
		ta_IN = 185
		''' <summary>Tatarisch</summary>
		tt = 186
		''' <summary>Tatarisch (Russland)</summary>
		tt_RU = 187
		''' <summary>Telugu</summary>
		te = 188
		''' <summary>Telugu (Indien)</summary>
		te_IN = 189
		''' <summary>Thai</summary>
		th = 190
		''' <summary>Thai (Thailand)</summary>
		th_TH = 191
		''' <summary>Türkisch</summary>
		tr = 192
		''' <summary>Türkisch (Türkei)</summary>
		tr_TR = 193
		''' <summary>Ukrainisch</summary>
		uk = 194
		''' <summary>Ukrainisch (Ukraine)</summary>
		uk_UA = 195
		''' <summary>Urdu</summary>
		ur = 196
		''' <summary>Urdu (Pakistan)</summary>
		ur_PK = 197
		''' <summary>Usbekisch</summary>
		uz = 198
		''' <summary>Usbekisch (Usbekistan, Kyrillisch)</summary>
		uz_Cyrl_UZ = 199
		''' <summary>Usbekisch (Usbekistan, Lateinisch)</summary>
		uz_Latn_UZ = 200
		''' <summary>Vietnamesisch</summary>
		vi = 201
		''' <summary>Vietnamesisch (Vietnam)</summary>
		vi_VN = 202
	End Enum

#End Region

End Namespace
