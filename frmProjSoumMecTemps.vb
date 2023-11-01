Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmProjSoumMecTemps
	Inherits System.Windows.Forms.Form
	
	Private Enum enumType
		TYPE_PROJET = 0
		TYPE_SOUMISSION = 1
	End Enum
	
	Private Enum enumMode
		MODE_AJOUT_MODIF = 0
		MODE_INACTIF = 1
	End Enum
	
	Private m_sTauxDessin As String
	Private m_sTauxCoupe As String
	Private m_sTauxMachinage As String
	Private m_sTauxSoudure As String
	Private m_sTauxAssemblage As String
	Private m_sTauxPeinture As String
	Private m_sTauxTest As String
	Private m_sTauxInstallation As String
	Private m_sTauxFormation As String
	Private m_sTauxGestion As String
	Private m_sTauxShipping As String
	Private m_sTauxPrototype As String
	
	Private m_sRepas As String
	Private m_sHebergement1 As String
	Private m_sHebergement2 As String
	Private m_sStandard As String
	Private m_sUniteMobile As String
	
	Private m_sTempsDessinAvant As String
	Private m_sTempsCoupeAvant As String
	Private m_sTempsMachinageAvant As String
	Private m_sTempsSoudureAvant As String
	Private m_sTempsAssemblageAvant As String
	Private m_sTempsPeintureAvant As String
	Private m_sTempsTestAvant As String
	Private m_sTempsInstallationAvant As String
	Private m_sTempsFormationAvant As String
	Private m_sTempsGestionAvant As String
	Private m_sTempsShippingAvant As String
	Private m_sTempsPrototypeAvant As String
	Private m_sTempsTotalRHAvant As String
	
	Private m_sNoProjet As String
	Private m_sNoSoumission As String
	
	Private m_eType As enumType
	
	Private m_eMode As enumMode
	
	Private m_bNouveauTaux As Boolean 'Pour savoir si les nouveaux taux doivent être pris
	Private m_bLocked As Boolean 'Pour savoir si la section projet est barrée ou non
	
	Public Sub Afficher(ByVal sNoProjet As String, ByVal sNoSoumission As String, ByVal iType As Short, ByVal iMode As Short, ByVal bNouveauTaux As Boolean)
		
5: On Error GoTo AfficherErreur
		
10: m_eType = iType
		
15: m_eMode = iMode
		
20: m_sNoProjet = sNoProjet
25: m_sNoSoumission = sNoSoumission
		
30: m_bNouveauTaux = bNouveauTaux
		
35: If bNouveauTaux = True Then
40: Call InitialiserVariablesConfig()
45: Else
50: Call InitialiserVariablesProjSoum()
55: End If
		
60: Call AfficherEnregistrement()
		
65: Call RemplirValeursAvant()
		
70: If m_eMode = enumMode.MODE_AJOUT_MODIF Then
75: Call BarrerChamps(False)
80: Else
85: Call BarrerChamps(True)
90: End If
		
95: Call Me.ShowDialog()
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmProjSoumMecTemps", "Afficher", Err, Erl())
	End Sub
	
	Private Sub RemplirValeursAvant()
		
5: On Error GoTo AfficherErreur
		
10: m_sTempsDessinAvant = txtTempsDessinProj.Text
15: m_sTempsCoupeAvant = txtTempsCoupeProj.Text
20: m_sTempsMachinageAvant = txtTempsMachinageProj.Text
25: m_sTempsSoudureAvant = txtTempsSoudureProj.Text
30: m_sTempsAssemblageAvant = txtTempsAssemblageProj.Text
35: m_sTempsPeintureAvant = txtTempsPeintureProj.Text
40: m_sTempsTestAvant = txtTempsTestProj.Text
45: m_sTempsInstallationAvant = txtTempsInstallationProj.Text
50: m_sTempsFormationAvant = txtTempsFormationProj.Text
55: m_sTempsGestionAvant = txtTempsGestionProj.Text
60: m_sTempsShippingAvant = txtTempsShippingProj.Text
61: m_sTempsPrototypeAvant = txtTempsPrototypeProj.Text
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmProjSoumMecTemps", "RemplirValeursVant", Err, Erl())
	End Sub
	
	Private Sub AfficherEnregistrement()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjSoum As ADODB.Recordset
15: Dim rstSoum As ADODB.Recordset
20: Dim rstPunch As ADODB.Recordset
25: Dim sChamps As String
30: Dim sTable As String
		
35: If m_eType = enumType.TYPE_PROJET Then
40: sChamps = "IDProjet"
45: sTable = "GRB_ProjetMec"
50: Else
55: sChamps = "IDSoumission"
60: sTable = "GRB_SoumissionMec"
65: End If
		
70: rstProjSoum = New ADODB.Recordset
		
75: If m_eType = enumType.TYPE_PROJET Then
80: Call rstProjSoum.Open("SELECT * FROM " & sTable & " WHERE " & sChamps & " = '" & m_sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
85: Else
90: Call rstProjSoum.Open("SELECT * FROM " & sTable & " WHERE " & sChamps & " = '" & m_sNoSoumission & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
95: End If
		
100: If Not rstProjSoum.EOF And FrmProjSoumMec.m_bTempsDejaOuvert = False And m_eMode = enumMode.MODE_INACTIF Then
105: If m_eType = enumType.TYPE_SOUMISSION Then
110: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsDessin").Value) Then
115: txtTempsDessinSoum.Text = rstProjSoum.Fields("TempsDessin").Value
120: Else
125: txtTempsDessinSoum.Text = "0"
130: End If
				
135: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsCoupe").Value) Then
140: txtTempsCoupeSoum.Text = rstProjSoum.Fields("TempsCoupe").Value
145: Else
150: txtTempsCoupeSoum.Text = "0"
155: End If
				
160: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsMachinage").Value) Then
165: txtTempsMachinageSoum.Text = rstProjSoum.Fields("TempsMachinage").Value
170: Else
175: txtTempsMachinageSoum.Text = "0"
180: End If
				
185: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsSoudure").Value) Then
190: txtTempsSoudureSoum.Text = rstProjSoum.Fields("TempsSoudure").Value
195: Else
200: txtTempsSoudureSoum.Text = "0"
205: End If
				
210: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsAssemblage").Value) Then
215: txtTempsAssemblageSoum.Text = rstProjSoum.Fields("TempsAssemblage").Value
220: Else
225: txtTempsAssemblageSoum.Text = "0"
230: End If
				
235: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsPeinture").Value) Then
240: txtTempsPeintureSoum.Text = rstProjSoum.Fields("TempsPeinture").Value
245: Else
250: txtTempsPeintureSoum.Text = "0"
255: End If
				
260: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsTest").Value) Then
265: txtTempsTestSoum.Text = rstProjSoum.Fields("TempsTest").Value
270: Else
275: txtTempsTestSoum.Text = "0"
280: End If
				
285: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsInstallation").Value) Then
290: txtTempsInstallationSoum.Text = rstProjSoum.Fields("TempsInstallation").Value
295: Else
300: txtTempsInstallationSoum.Text = "0"
305: End If
				
310: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsFormation").Value) Then
315: txtTempsFormationSoum.Text = rstProjSoum.Fields("TempsFormation").Value
320: Else
325: txtTempsFormationSoum.Text = "0"
330: End If
				
335: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsGestion").Value) Then
340: txtTempsGestionSoum.Text = rstProjSoum.Fields("TempsGestion").Value
345: Else
350: txtTempsGestionSoum.Text = "0"
355: End If
				
360: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsShipping").Value) Then
365: txtTempsShippingSoum.Text = rstProjSoum.Fields("TempsShipping").Value
370: Else
375: txtTempsShippingSoum.Text = "0"
380: End If
				txtTempsPrototypeSoum.Text = "0"
				
385: Else
390: If m_sNoSoumission <> "" Then
395: rstSoum = New ADODB.Recordset
					
400: Call rstSoum.Open("SELECT * FROM GRB_SoumissionMec WHERE IDSoumission = '" & m_sNoSoumission & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
405: If Not rstSoum.EOF Then
410: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsDessin").Value) Then
415: txtTempsDessinSoum.Text = rstSoum.Fields("TempsDessin").Value
420: Else
425: txtTempsDessinSoum.Text = "0"
430: End If
						
435: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsCoupe").Value) Then
440: txtTempsCoupeSoum.Text = rstSoum.Fields("TempsCoupe").Value
445: Else
450: txtTempsCoupeSoum.Text = "0"
455: End If
						
460: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsMachinage").Value) Then
465: txtTempsMachinageSoum.Text = rstSoum.Fields("TempsMachinage").Value
470: Else
475: txtTempsMachinageSoum.Text = "0"
480: End If
						
485: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsSoudure").Value) Then
490: txtTempsSoudureSoum.Text = rstSoum.Fields("TempsSoudure").Value
495: Else
500: txtTempsSoudureSoum.Text = "0"
505: End If
						
510: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsAssemblage").Value) Then
515: txtTempsAssemblageSoum.Text = rstSoum.Fields("TempsAssemblage").Value
520: Else
525: txtTempsAssemblageSoum.Text = "0"
530: End If
						
535: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsPeinture").Value) Then
540: txtTempsPeintureSoum.Text = rstSoum.Fields("TempsPeinture").Value
545: Else
550: txtTempsPeintureSoum.Text = "0"
555: End If
						
560: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsTest").Value) Then
565: txtTempsTestSoum.Text = rstSoum.Fields("TempsTest").Value
570: Else
575: txtTempsTestSoum.Text = "0"
580: End If
						
585: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsInstallation").Value) Then
590: txtTempsInstallationSoum.Text = rstSoum.Fields("TempsInstallation").Value
595: Else
600: txtTempsInstallationSoum.Text = "0"
605: End If
						
610: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsFormation").Value) Then
615: txtTempsFormationSoum.Text = rstSoum.Fields("TempsFormation").Value
620: Else
625: txtTempsFormationSoum.Text = "0"
630: End If
						
635: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsGestion").Value) Then
640: txtTempsGestionSoum.Text = rstSoum.Fields("TempsGestion").Value
645: Else
650: txtTempsGestionSoum.Text = "0"
655: End If
						
660: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsShipping").Value) Then
665: txtTempsShippingSoum.Text = rstSoum.Fields("TempsShipping").Value
670: Else
675: txtTempsShippingSoum.Text = "0"
680: End If
						txtTempsPrototypeSoum.Text = "0"
						
685: Else
690: txtTempsDessinSoum.Text = CStr(0)
695: txtTempsCoupeSoum.Text = CStr(0)
700: txtTempsMachinageSoum.Text = CStr(0)
705: txtTempsSoudureSoum.Text = CStr(0)
710: txtTempsAssemblageSoum.Text = CStr(0)
715: txtTempsPeintureSoum.Text = CStr(0)
720: txtTempsTestSoum.Text = CStr(0)
725: txtTempsInstallationSoum.Text = CStr(0)
730: txtTempsFormationSoum.Text = CStr(0)
735: txtTempsGestionSoum.Text = CStr(0)
740: txtTempsShippingSoum.Text = CStr(0)
						txtTempsPrototypeSoum.Text = CStr(0)
						
745: End If
					
750: Call rstSoum.Close()
755: 'UPGRADE_NOTE: Object rstSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstSoum = Nothing
760: Else
765: txtTempsDessinSoum.Text = CStr(0)
770: txtTempsCoupeSoum.Text = CStr(0)
775: txtTempsMachinageSoum.Text = CStr(0)
780: txtTempsSoudureSoum.Text = CStr(0)
785: txtTempsAssemblageSoum.Text = CStr(0)
790: txtTempsPeintureSoum.Text = CStr(0)
795: txtTempsTestSoum.Text = CStr(0)
800: txtTempsInstallationSoum.Text = CStr(0)
805: txtTempsFormationSoum.Text = CStr(0)
810: txtTempsGestionSoum.Text = CStr(0)
815: txtTempsShippingSoum.Text = CStr(0)
					txtTempsPrototypeSoum.Text = CStr(0)
820: End If
				
825: m_bLocked = rstProjSoum.Fields("TempsProjBarré").Value
				
830: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsDessinProj").Value) Then
835: txtTempsDessinProj.Text = rstProjSoum.Fields("TempsDessinProj").Value
840: Else
845: txtTempsDessinProj.Text = "0"
850: End If
				
855: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsCoupeProj").Value) Then
860: txtTempsCoupeProj.Text = rstProjSoum.Fields("TempsCoupeProj").Value
865: Else
870: txtTempsCoupeProj.Text = "0"
875: End If
				
880: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsMachinageProj").Value) Then
885: txtTempsMachinageProj.Text = rstProjSoum.Fields("TempsMachinageProj").Value
890: Else
895: txtTempsMachinageProj.Text = "0"
900: End If
				
905: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsSoudureProj").Value) Then
910: txtTempsSoudureProj.Text = rstProjSoum.Fields("TempsSoudureProj").Value
915: Else
920: txtTempsSoudureProj.Text = "0"
925: End If
				
930: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsAssemblageProj").Value) Then
935: txtTempsAssemblageProj.Text = rstProjSoum.Fields("TempsAssemblageProj").Value
940: Else
945: txtTempsAssemblageProj.Text = "0"
950: End If
				
955: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsPeintureProj").Value) Then
960: txtTempsPeintureProj.Text = rstProjSoum.Fields("TempsPeintureProj").Value
965: Else
970: txtTempsPeintureProj.Text = "0"
975: End If
				
980: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsTestProj").Value) Then
985: txtTempsTestProj.Text = rstProjSoum.Fields("TempsTestProj").Value
990: Else
995: txtTempsTestProj.Text = "0"
1000: End If
				
1005: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsInstallationProj").Value) Then
1010: txtTempsInstallationProj.Text = rstProjSoum.Fields("TempsInstallationProj").Value
1015: Else
1020: txtTempsInstallationProj.Text = "0"
1025: End If
				
1030: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsFormationProj").Value) Then
1035: txtTempsFormationProj.Text = rstProjSoum.Fields("TempsFormationProj").Value
1040: Else
1045: txtTempsFormationProj.Text = "0"
1050: End If
				
1055: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsGestionProj").Value) Then
1060: txtTempsGestionProj.Text = rstProjSoum.Fields("TempsGestionProj").Value
1065: Else
1070: txtTempsGestionProj.Text = "0"
1075: End If
				
1080: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsShippingProj").Value) Then
1085: txtTempsShippingProj.Text = rstProjSoum.Fields("TempsShippingProj").Value
1090: Else
1095: txtTempsShippingProj.Text = "0"
1100: End If
				
				txtTempsPrototypeProj.Text = "0"
				
1105: If m_bLocked = False Then
1110: txtTempsDessinConc.Text = vbNullString
1115: txtTempsCoupeConc.Text = vbNullString
1120: txtTempsMachinageConc.Text = vbNullString
1125: txtTempsSoudureConc.Text = vbNullString
1130: txtTempsAssemblageConc.Text = vbNullString
1135: txtTempsPeintureConc.Text = vbNullString
1140: txtTempsTestConc.Text = vbNullString
1145: txtTempsInstallationConc.Text = vbNullString
1150: txtTempsFormationConc.Text = vbNullString
1155: txtTempsGestionConc.Text = vbNullString
1160: txtTempsShippingConc.Text = vbNullString
					txtTempsPrototypeConc.Text = vbNullString
1165: Else
1170: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsDessinConc").Value) Then
1175: txtTempsDessinConc.Text = rstProjSoum.Fields("TempsDessinConc").Value
1180: Else
1185: txtTempsDessinConc.Text = "0"
1190: End If
					
1195: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsCoupeConc").Value) Then
1200: txtTempsCoupeConc.Text = rstProjSoum.Fields("TempsCoupeConc").Value
1205: Else
1210: txtTempsCoupeConc.Text = "0"
1215: End If
					
1220: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsMachinageConc").Value) Then
1225: txtTempsMachinageConc.Text = rstProjSoum.Fields("TempsMachinageConc").Value
1230: Else
1235: txtTempsMachinageConc.Text = "0"
1240: End If
					
1245: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsSoudureConc").Value) Then
1250: txtTempsSoudureConc.Text = rstProjSoum.Fields("TempsSoudureConc").Value
1255: Else
1260: txtTempsSoudureConc.Text = "0"
1265: End If
					
1270: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsAssemblageConc").Value) Then
1275: txtTempsAssemblageConc.Text = rstProjSoum.Fields("TempsAssemblageConc").Value
1280: Else
1285: txtTempsAssemblageConc.Text = "0"
1290: End If
					
1295: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsPeintureConc").Value) Then
1300: txtTempsPeintureConc.Text = rstProjSoum.Fields("TempsPeintureConc").Value
1305: Else
1310: txtTempsPeintureConc.Text = "0"
1315: End If
					
1320: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsTestConc").Value) Then
1325: txtTempsTestConc.Text = rstProjSoum.Fields("TempsTestConc").Value
1330: Else
1335: txtTempsTestConc.Text = "0"
1340: End If
					
1345: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsInstallationConc").Value) Then
1350: txtTempsInstallationConc.Text = rstProjSoum.Fields("TempsInstallationConc").Value
1355: Else
1360: txtTempsInstallationConc.Text = "0"
1365: End If
					
1370: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsFormationConc").Value) Then
1375: txtTempsFormationConc.Text = rstProjSoum.Fields("TempsFormationConc").Value
1380: Else
1385: txtTempsFormationConc.Text = "0"
1390: End If
					
1395: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsGestionConc").Value) Then
1400: txtTempsGestionConc.Text = rstProjSoum.Fields("TempsGestionConc").Value
1405: Else
1410: txtTempsGestionConc.Text = "0"
1415: End If
					
1420: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsShippingConc").Value) Then
1425: txtTempsShippingConc.Text = rstProjSoum.Fields("TempsShippingConc").Value
1430: Else
1435: txtTempsShippingConc.Text = "0"
1440: End If
					txtTempsPrototypeConc.Text = "0"
					
1445: End If
1450: End If
			
1455: If m_eType = enumType.TYPE_PROJET Then
1460: Call AfficherTempsReels()
				
1465: Call CalculerTotalArgent()
1470: End If
			
1475: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("NbrePersonne").Value) Then
1480: txtNbrePersonne.Text = rstProjSoum.Fields("NbrePersonne").Value
1485: Else
1490: txtNbrePersonne.Text = "0"
1495: End If
			
1500: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsHebergement").Value) Then
1505: txtTempsHebergement.Text = rstProjSoum.Fields("TempsHebergement").Value
1510: Else
1515: txtTempsHebergement.Text = "0"
1520: End If
			
1525: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsRepas").Value) Then
1530: txtTempsRepas.Text = rstProjSoum.Fields("TempsRepas").Value
1535: Else
1540: txtTempsRepas.Text = "0"
1545: End If
			
1550: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsTransport").Value) Then
1555: txtTempsDeplacement.Text = rstProjSoum.Fields("TempsTransport").Value
1560: Else
1565: txtTempsDeplacement.Text = "0"
1570: End If
			
1575: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsUniteMobile").Value) Then
1580: txtTempsUniteMobile.Text = rstProjSoum.Fields("TempsUniteMobile").Value
1585: Else
1590: txtTempsUniteMobile.Text = "0"
1595: End If
			
1600: txtPrixEmballage.Text = rstProjSoum.Fields("PrixEmballage").Value
1605: Else
1610: If m_eType = enumType.TYPE_SOUMISSION Then
1615: txtTempsDessinSoum.Text = FrmProjSoumMec.m_sTempsDessin
1620: txtTempsCoupeSoum.Text = FrmProjSoumMec.m_sTempsCoupe
1625: txtTempsMachinageSoum.Text = FrmProjSoumMec.m_sTempsMachinage
1630: txtTempsSoudureSoum.Text = FrmProjSoumMec.m_sTempsSoudure
1635: txtTempsAssemblageSoum.Text = FrmProjSoumMec.m_sTempsAssemblage
1640: txtTempsPeintureSoum.Text = FrmProjSoumMec.m_sTempsPeinture
1645: txtTempsTestSoum.Text = FrmProjSoumMec.m_sTempsTest
1650: txtTempsInstallationSoum.Text = FrmProjSoumMec.m_sTempsInstallation
1655: txtTempsFormationSoum.Text = FrmProjSoumMec.m_sTempsFormation
1660: txtTempsGestionSoum.Text = FrmProjSoumMec.m_sTempsGestion
1665: txtTempsShippingSoum.Text = FrmProjSoumMec.m_sTempsShipping
1670: Else
1675: If m_sNoSoumission <> "" Then
1680: rstSoum = New ADODB.Recordset
					
1685: Call rstSoum.Open("SELECT * FROM GRB_SoumissionMec WHERE IDSoumission = '" & m_sNoSoumission & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
1690: If Not rstSoum.EOF Then
1695: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsDessin").Value) Then
1700: txtTempsDessinSoum.Text = rstSoum.Fields("TempsDessin").Value
1705: Else
1710: txtTempsDessinSoum.Text = "0"
1715: End If
						
1720: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsCoupe").Value) Then
1725: txtTempsCoupeSoum.Text = rstSoum.Fields("TempsCoupe").Value
1730: Else
1735: txtTempsCoupeSoum.Text = "0"
1740: End If
						
1745: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsMachinage").Value) Then
1750: txtTempsMachinageSoum.Text = rstSoum.Fields("TempsMachinage").Value
1755: Else
1760: txtTempsMachinageSoum.Text = "0"
1765: End If
						
1770: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsSoudure").Value) Then
1775: txtTempsSoudureSoum.Text = rstSoum.Fields("TempsSoudure").Value
1780: Else
1785: txtTempsSoudureSoum.Text = "0"
1790: End If
						
1795: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsAssemblage").Value) Then
1800: txtTempsAssemblageSoum.Text = rstSoum.Fields("TempsAssemblage").Value
1805: Else
1810: txtTempsAssemblageSoum.Text = "0"
1815: End If
						
1820: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsPeinture").Value) Then
1825: txtTempsPeintureSoum.Text = rstSoum.Fields("TempsPeinture").Value
1830: Else
1835: txtTempsPeintureSoum.Text = "0"
1840: End If
						
1845: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsTest").Value) Then
1850: txtTempsTestSoum.Text = rstSoum.Fields("TempsTest").Value
1855: Else
1860: txtTempsTestSoum.Text = "0"
1865: End If
						
1870: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsInstallation").Value) Then
1875: txtTempsInstallationSoum.Text = rstSoum.Fields("TempsInstallation").Value
1880: Else
1885: txtTempsInstallationSoum.Text = "0"
1890: End If
						
1895: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsFormation").Value) Then
1900: txtTempsFormationSoum.Text = rstSoum.Fields("TempsFormation").Value
1905: Else
1910: txtTempsFormationSoum.Text = "0"
1915: End If
						
1920: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsGestion").Value) Then
1925: txtTempsGestionSoum.Text = rstSoum.Fields("TempsGestion").Value
1930: Else
1935: txtTempsGestionSoum.Text = "0"
1940: End If
						
1945: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstSoum.Fields("TempsShipping").Value) Then
1950: txtTempsShippingSoum.Text = rstSoum.Fields("TempsShipping").Value
1955: Else
1960: txtTempsShippingSoum.Text = "0"
1965: End If
						txtTempsPrototypeSoum.Text = "0"
1970: Else
1975: txtTempsDessinSoum.Text = CStr(0)
1980: txtTempsCoupeSoum.Text = CStr(0)
1985: txtTempsMachinageSoum.Text = CStr(0)
1990: txtTempsSoudureSoum.Text = CStr(0)
1995: txtTempsAssemblageSoum.Text = CStr(0)
2000: txtTempsPeintureSoum.Text = CStr(0)
2005: txtTempsTestSoum.Text = CStr(0)
2010: txtTempsInstallationSoum.Text = CStr(0)
2015: txtTempsFormationSoum.Text = CStr(0)
2020: txtTempsGestionSoum.Text = CStr(0)
2025: txtTempsShippingSoum.Text = CStr(0)
						txtTempsPrototypeSoum.Text = CStr(0)
2030: End If
					
2035: Call rstSoum.Close()
2040: 'UPGRADE_NOTE: Object rstSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstSoum = Nothing
2045: Else
2050: txtTempsDessinSoum.Text = CStr(0)
2055: txtTempsCoupeSoum.Text = CStr(0)
2060: txtTempsMachinageSoum.Text = CStr(0)
2065: txtTempsSoudureSoum.Text = CStr(0)
2070: txtTempsAssemblageSoum.Text = CStr(0)
2075: txtTempsPeintureSoum.Text = CStr(0)
2080: txtTempsTestSoum.Text = CStr(0)
2085: txtTempsInstallationSoum.Text = CStr(0)
2090: txtTempsFormationSoum.Text = CStr(0)
2095: txtTempsGestionSoum.Text = CStr(0)
2100: txtTempsShippingSoum.Text = CStr(0)
					txtTempsPrototypeSoum.Text = CStr(0)
2105: End If
				
2110: m_bLocked = FrmProjSoumMec.m_bTempsProjLock
				
2115: If m_bLocked = True Then
2120: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsDessinProj").Value) Then
2125: txtTempsDessinProj.Text = rstProjSoum.Fields("TempsDessinProj").Value
2130: Else
2135: txtTempsDessinProj.Text = "0"
2140: End If
					
2145: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsCoupeProj").Value) Then
2150: txtTempsCoupeProj.Text = rstProjSoum.Fields("TempsCoupeProj").Value
2155: Else
2160: txtTempsCoupeProj.Text = "0"
2165: End If
					
2170: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsMachinageProj").Value) Then
2175: txtTempsMachinageProj.Text = rstProjSoum.Fields("TempsMachinageProj").Value
2180: Else
2185: txtTempsMachinageProj.Text = "0"
2190: End If
					
2195: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsSoudureProj").Value) Then
2200: txtTempsSoudureProj.Text = rstProjSoum.Fields("TempsSoudureProj").Value
2205: Else
2210: txtTempsSoudureProj.Text = "0"
2215: End If
					
2220: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsAssemblageProj").Value) Then
2225: txtTempsAssemblageProj.Text = rstProjSoum.Fields("TempsAssemblageProj").Value
2230: Else
2235: txtTempsAssemblageProj.Text = "0"
2240: End If
					
2245: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsPeintureProj").Value) Then
2250: txtTempsPeintureProj.Text = rstProjSoum.Fields("TempsPeintureProj").Value
2255: Else
2260: txtTempsPeintureProj.Text = "0"
2265: End If
					
2270: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsTestProj").Value) Then
2275: txtTempsTestProj.Text = rstProjSoum.Fields("TempsTestProj").Value
2280: Else
2285: txtTempsTestProj.Text = "0"
2290: End If
					
2295: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsInstallationProj").Value) Then
2300: txtTempsInstallationProj.Text = rstProjSoum.Fields("TempsInstallationProj").Value
2305: Else
2310: txtTempsInstallationProj.Text = "0"
2315: End If
					
2320: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsFormationProj").Value) Then
2325: txtTempsFormationProj.Text = rstProjSoum.Fields("TempsFormationProj").Value
2330: Else
2335: txtTempsFormationProj.Text = "0"
2340: End If
					
2345: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsGestionProj").Value) Then
2350: txtTempsGestionProj.Text = rstProjSoum.Fields("TempsGestionProj").Value
2355: Else
2360: txtTempsGestionProj.Text = "0"
2365: End If
					
2370: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstProjSoum.Fields("TempsShippingProj").Value) Then
2375: txtTempsShippingProj.Text = rstProjSoum.Fields("TempsShippingProj").Value
2380: Else
2385: txtTempsShippingProj.Text = "0"
2390: End If
					
					txtTempsPrototypeProj.Text = "0"
					
2395: txtTempsDessinConc.Text = FrmProjSoumMec.m_sTempsDessinConc
2400: txtTempsCoupeConc.Text = FrmProjSoumMec.m_sTempsCoupeConc
2405: txtTempsMachinageConc.Text = FrmProjSoumMec.m_sTempsMachinageConc
2410: txtTempsSoudureConc.Text = FrmProjSoumMec.m_sTempsSoudureConc
2415: txtTempsAssemblageConc.Text = FrmProjSoumMec.m_sTempsAssemblageConc
2420: txtTempsPeintureConc.Text = FrmProjSoumMec.m_sTempsPeintureConc
2425: txtTempsTestConc.Text = FrmProjSoumMec.m_sTempsTestConc
2430: txtTempsInstallationConc.Text = FrmProjSoumMec.m_sTempsInstallationConc
2435: txtTempsFormationConc.Text = FrmProjSoumMec.m_sTempsFormationConc
2440: txtTempsGestionConc.Text = FrmProjSoumMec.m_sTempsGestionConc
2445: txtTempsShippingConc.Text = FrmProjSoumMec.m_sTempsShippingConc
					txtTempsPrototypeConc.Text = FrmProjSoumMec.m_sTempsPrototypeConc
2450: Else
2455: txtTempsDessinProj.Text = FrmProjSoumMec.m_sTempsDessinProj
2460: txtTempsCoupeProj.Text = FrmProjSoumMec.m_sTempsCoupeProj
2465: txtTempsMachinageProj.Text = FrmProjSoumMec.m_sTempsMachinageProj
2470: txtTempsSoudureProj.Text = FrmProjSoumMec.m_sTempsSoudureProj
2475: txtTempsAssemblageProj.Text = FrmProjSoumMec.m_sTempsAssemblageProj
2480: txtTempsPeintureProj.Text = FrmProjSoumMec.m_sTempsPeintureProj
2485: txtTempsTestProj.Text = FrmProjSoumMec.m_sTempsTestProj
2490: txtTempsInstallationProj.Text = FrmProjSoumMec.m_sTempsInstallationProj
2495: txtTempsFormationProj.Text = FrmProjSoumMec.m_sTempsFormationProj
2500: txtTempsGestionProj.Text = FrmProjSoumMec.m_sTempsGestionProj
2505: txtTempsShippingProj.Text = FrmProjSoumMec.m_sTempsShippingProj
					txtTempsPrototypeProj.Text = FrmProjSoumMec.m_sTempsPrototypeProj
2510: End If
2515: End If
			
2520: If m_eType = enumType.TYPE_PROJET Then
2525: Call AfficherTempsReels()
				
2530: Call CalculerTotalArgent()
2535: End If
			
2540: txtNbrePersonne.Text = FrmProjSoumMec.m_sNbrePersonne
2545: txtTempsHebergement.Text = FrmProjSoumMec.m_sTempsHebergement
2550: txtTempsRepas.Text = FrmProjSoumMec.m_sTempsRepas
2555: txtTempsDeplacement.Text = FrmProjSoumMec.m_sTempsTransport
2560: txtTempsUniteMobile.Text = FrmProjSoumMec.m_sTempsUniteMobile
2565: txtPrixEmballage.Text = FrmProjSoumMec.m_sPrixEmballage
2570: End If
		
2575: Call rstProjSoum.Close()
2580: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjSoum = Nothing
		
2585: Exit Sub
		
AfficherErreur: 
		
2590: Call AfficherErreur("frmProjSoumMecTemps", "AfficherEnregistrement", Err, Erl())
	End Sub
	
	Private Sub AfficherTempsReels()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPunch As ADODB.Recordset
15: Dim sDateDebut As String
20: Dim sDateFin As String
25: Dim sTotal As String
30: Dim sFilterNoProjet As String
		
35: sDateDebut = "TIMESERIAL(Left(GRB_Punch.HeureDébut,2),RIGHT(GRB_Punch.HeureDébut,2),0)"
		
40: sDateFin = "TIMESERIAL(Left(GRB_Punch.HeureFin,2),RIGHT(GRB_Punch.HeureFin,2),0)"
		
45: sTotal = "(SUM(" & sDateFin & " - " & sDateDebut & ")* 24) As Total"
		
50: If VB.Right(m_sNoProjet, 2) = "99" Then
55: sFilterNoProjet = "LEFT(NoProjet, 6) = '" & VB.Left(m_sNoProjet, 6) & "'"
60: Else
65: sFilterNoProjet = "NoProjet = '" & m_sNoProjet & "'"
70: End If
		
75: rstPunch = New ADODB.Recordset
		
80: Call rstPunch.Open("SELECT Type, " & sTotal & " FROM GRB_Punch WHERE " & sFilterNoProjet & " And HeureFin is not null AND HeureDébut is not null GROUP BY Type", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
85: lblTempsDessinReel.Text = "0"
90: lblTempsCoupeReel.Text = "0"
95: lblTempsMachinageReel.Text = "0"
100: lblTempsSoudureReel.Text = "0"
105: lblTempsAssemblageReel.Text = "0"
110: lblTempsPeintureReel.Text = "0"
115: lblTempsTestReel.Text = "0"
120: lblTempsInstallationReel.Text = "0"
125: lblTempsFormationReel.Text = "0"
130: lblTempsGestionReel.Text = "0"
135: lblTempsShippingReel.Text = "0"
		lblTempsPrototypeReel.Text = "0"
		
140: Do While Not rstPunch.EOF
145: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("Total").Value) Then
150: Select Case rstPunch.Fields("Type").Value
					Case "Dessin" : lblTempsDessinReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
155: Case "Coupe" : lblTempsCoupeReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
160: Case "Machinage" : lblTempsMachinageReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
165: Case "Soudure" : lblTempsSoudureReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
170: Case "Assemblage" : lblTempsAssemblageReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
175: Case "Peinture" : lblTempsPeintureReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
180: Case "Test" : lblTempsTestReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
185: Case "Installation" : lblTempsInstallationReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
190: Case "Formation" : lblTempsFormationReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
195: Case "Gestion" : lblTempsGestionReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
200: Case "Shipping" : lblTempsShippingReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
					Case "Prototypage-Dévelloppement expérimental" : lblTempsPrototypeReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
205: End Select
210: End If
			
215: Call rstPunch.MoveNext()
220: Loop 
		
225: Call rstPunch.Close()
		
		'Ouverture des enregistrements avec comme filtre, le numéro du projet
230: Call rstPunch.Open("SELECT " & sTotal & " FROM GRB_Punch WHERE " & sFilterNoProjet & " AND HeureFin is not null AND HeureDébut is not null", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
235: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPunch.Fields("Total").Value) Then
240: lblTotalTempsRHReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
245: Else
250: lblTotalTempsRHReel.Text = "0"
255: End If
		
260: Call rstPunch.Close()
265: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPunch = Nothing
		
270: Exit Sub
		
AfficherErreur: 
		
275: Call AfficherErreur("frmProjSoumMecTemps", "AfficherTempsReels", Err, Erl())
	End Sub
	
	Private Sub CalculerTotalArgent()
		
5: On Error GoTo AfficherErreur
		
10: If IsNumeric(lblTempsDessinReel.Text) Then
15: lblPrixDessin.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsDessinReel.Text) * CDbl(m_sTauxDessin)), ".", ",")), 2))
20: Else
25: lblPrixDessin.Text = CStr(0)
30: End If
		
35: If IsNumeric(lblTempsCoupeReel.Text) Then
40: lblPrixCoupe.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsCoupeReel.Text) * CDbl(m_sTauxCoupe)), ".", ",")), 2))
45: Else
50: lblPrixCoupe.Text = CStr(0)
55: End If
		
60: If IsNumeric(lblTempsMachinageReel.Text) Then
65: lblPrixMachinage.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsMachinageReel.Text) * CDbl(m_sTauxMachinage)), ".", ",")), 2))
70: Else
75: lblPrixMachinage.Text = CStr(0)
80: End If
		
85: If IsNumeric(lblTempsSoudureReel.Text) Then
90: lblPrixSoudure.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsSoudureReel.Text) * CDbl(m_sTauxSoudure)), ".", ",")), 2))
95: Else
100: lblPrixSoudure.Text = CStr(0)
105: End If
		
110: If IsNumeric(lblTempsAssemblageReel.Text) Then
115: lblPrixAssemblage.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsAssemblageReel.Text) * CDbl(m_sTauxAssemblage)), ".", ",")), 2))
120: Else
125: lblPrixAssemblage.Text = CStr(0)
130: End If
		
135: If IsNumeric(lblTempsPeintureReel.Text) Then
140: lblPrixPeinture.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsPeintureReel.Text) * CDbl(m_sTauxPeinture)), ".", ",")), 2))
145: Else
150: lblPrixPeinture.Text = CStr(0)
155: End If
		
160: If IsNumeric(lblTempsTestReel.Text) Then
165: lblPrixTest.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsTestReel.Text) * CDbl(m_sTauxTest)), ".", ",")), 2))
170: Else
175: lblPrixTest.Text = CStr(0)
180: End If
		
185: If IsNumeric(lblTempsInstallationReel.Text) Then
190: lblPrixInstallation.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsInstallationReel.Text) * CDbl(m_sTauxInstallation)), ".", ",")), 2))
195: Else
200: lblPrixInstallation.Text = CStr(0)
205: End If
		
210: If IsNumeric(lblTempsFormationReel.Text) Then
215: lblPrixFormation.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsFormationReel.Text) * CDbl(m_sTauxFormation)), ".", ",")), 2))
220: Else
225: lblPrixFormation.Text = CStr(0)
230: End If
		
235: If IsNumeric(lblTempsGestionReel.Text) Then
240: lblPrixGestion.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsGestionReel.Text) * CDbl(m_sTauxGestion)), ".", ",")), 2))
245: Else
250: lblPrixGestion.Text = CStr(0)
255: End If
		
260: If IsNumeric(lblTempsShippingReel.Text) Then
265: lblPrixShipping.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsShippingReel.Text) * CDbl(m_sTauxShipping)), ".", ",")), 2))
270: Else
275: lblPrixShipping.Text = CStr(0)
280: End If
		
		If IsNumeric(lblTempsPrototypeReel.Text) Then
281: lblPrixPrototype.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsPrototypeReel.Text) * CDbl(m_sTauxGestion)), ".", ",")), 2))
282: Else
283: lblPrixPrototype.Text = CStr(0)
284: End If
		
		
285: Call CalculerTotal()
		
290: Exit Sub
		
AfficherErreur: 
		
295: Call AfficherErreur("frmProjSoumMecTemps", "CalculerTotalArgent", Err, Erl())
	End Sub
	
	Private Sub BarrerChamps(ByVal bLocked As Boolean)
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: txtTempsDessinSoum.Enabled = True
20: txtTempsCoupeSoum.Enabled = True
25: txtTempsMachinageSoum.Enabled = True
30: txtTempsSoudureSoum.Enabled = True
35: txtTempsAssemblageSoum.Enabled = True
40: txtTempsPeintureSoum.Enabled = True
45: txtTempsTestSoum.Enabled = True
50: txtTempsInstallationSoum.Enabled = True
55: txtTempsFormationSoum.Enabled = True
60: txtTempsGestionSoum.Enabled = True
65: txtTempsShippingSoum.Enabled = True
			txtTempsPrototypeSoum.Enabled = True
			
			
70: txtTempsDessinSoum.ReadOnly = bLocked
75: txtTempsCoupeSoum.ReadOnly = bLocked
80: txtTempsMachinageSoum.ReadOnly = bLocked
85: txtTempsSoudureSoum.ReadOnly = bLocked
90: txtTempsAssemblageSoum.ReadOnly = bLocked
95: txtTempsPeintureSoum.ReadOnly = bLocked
100: txtTempsTestSoum.ReadOnly = bLocked
105: txtTempsInstallationSoum.ReadOnly = bLocked
110: txtTempsFormationSoum.ReadOnly = bLocked
115: txtTempsGestionSoum.ReadOnly = bLocked
120: txtTempsShippingSoum.ReadOnly = bLocked
			txtTempsPrototypeSoum.ReadOnly = bLocked
			
			
			
125: txtTempsDessinProj.Enabled = False
130: txtTempsCoupeProj.Enabled = False
135: txtTempsMachinageProj.Enabled = False
140: txtTempsSoudureProj.Enabled = False
145: txtTempsAssemblageProj.Enabled = False
150: txtTempsPeintureProj.Enabled = False
155: txtTempsTestProj.Enabled = False
160: txtTempsInstallationProj.Enabled = False
165: txtTempsFormationProj.Enabled = False
170: txtTempsGestionProj.Enabled = False
175: txtTempsShippingProj.Enabled = False
			txtTempsPrototypeProj.Enabled = False
			
180: txtTempsDessinConc.Enabled = False
185: txtTempsCoupeConc.Enabled = False
190: txtTempsMachinageConc.Enabled = False
195: txtTempsSoudureConc.Enabled = False
200: txtTempsAssemblageConc.Enabled = False
205: txtTempsPeintureConc.Enabled = False
210: txtTempsTestConc.Enabled = False
215: txtTempsInstallationConc.Enabled = False
220: txtTempsFormationConc.Enabled = False
225: txtTempsGestionConc.Enabled = False
230: txtTempsShippingConc.Enabled = False
			txtTempsPrototypeConc.Enabled = False
			
			
235: cmdLock.Visible = False
240: cmdUnlock.Visible = False
245: Else
250: If m_bLocked = False Then
255: txtTempsDessinProj.Enabled = True
260: txtTempsCoupeProj.Enabled = True
265: txtTempsMachinageProj.Enabled = True
270: txtTempsSoudureProj.Enabled = True
275: txtTempsAssemblageProj.Enabled = True
280: txtTempsPeintureProj.Enabled = True
285: txtTempsTestProj.Enabled = True
290: txtTempsInstallationProj.Enabled = True
295: txtTempsFormationProj.Enabled = True
300: txtTempsGestionProj.Enabled = True
305: txtTempsShippingProj.Enabled = True
				txtTempsPrototypeProj.Enabled = True
				
				
310: txtTempsDessinProj.ReadOnly = bLocked
315: txtTempsCoupeProj.ReadOnly = bLocked
320: txtTempsMachinageProj.ReadOnly = bLocked
325: txtTempsSoudureProj.ReadOnly = bLocked
330: txtTempsAssemblageProj.ReadOnly = bLocked
335: txtTempsPeintureProj.ReadOnly = bLocked
340: txtTempsTestProj.ReadOnly = bLocked
345: txtTempsInstallationProj.ReadOnly = bLocked
350: txtTempsFormationProj.ReadOnly = bLocked
355: txtTempsGestionProj.ReadOnly = bLocked
360: txtTempsShippingProj.ReadOnly = bLocked
361: txtTempsPrototypeProj.ReadOnly = bLocked
				
				
365: txtTempsDessinSoum.Enabled = False
370: txtTempsCoupeSoum.Enabled = False
375: txtTempsMachinageSoum.Enabled = False
380: txtTempsSoudureSoum.Enabled = False
385: txtTempsAssemblageSoum.Enabled = False
390: txtTempsPeintureSoum.Enabled = False
395: txtTempsTestSoum.Enabled = False
400: txtTempsInstallationSoum.Enabled = False
405: txtTempsFormationSoum.Enabled = False
410: txtTempsGestionSoum.Enabled = False
415: txtTempsShippingSoum.Enabled = False
416: txtTempsPrototypeSoum.Enabled = False
				
				
				
420: txtTempsDessinConc.Enabled = False
425: txtTempsCoupeConc.Enabled = False
430: txtTempsMachinageConc.Enabled = False
435: txtTempsSoudureConc.Enabled = False
440: txtTempsAssemblageConc.Enabled = False
445: txtTempsPeintureConc.Enabled = False
450: txtTempsTestConc.Enabled = False
455: txtTempsInstallationConc.Enabled = False
460: txtTempsFormationConc.Enabled = False
465: txtTempsGestionConc.Enabled = False
470: txtTempsShippingConc.Enabled = False
471: txtTempsPrototypeConc.Enabled = False
				
475: If m_eMode = enumMode.MODE_AJOUT_MODIF Then
480: If g_bVerrouillageTempsProjet = True Then
485: cmdLock.Visible = True
490: Else
495: cmdLock.Visible = False
500: End If
					
505: cmdUnlock.Visible = False
510: Else
515: cmdLock.Visible = False
520: cmdUnlock.Visible = False
525: End If
530: Else
535: txtTempsDessinConc.Enabled = True
540: txtTempsCoupeConc.Enabled = True
545: txtTempsMachinageConc.Enabled = True
550: txtTempsSoudureConc.Enabled = True
555: txtTempsAssemblageConc.Enabled = True
560: txtTempsPeintureConc.Enabled = True
565: txtTempsTestConc.Enabled = True
570: txtTempsInstallationConc.Enabled = True
575: txtTempsFormationConc.Enabled = True
580: txtTempsGestionConc.Enabled = True
585: txtTempsShippingConc.Enabled = True
586: txtTempsPrototypeConc.Enabled = True
				
				
590: txtTempsDessinConc.ReadOnly = bLocked
595: txtTempsCoupeConc.ReadOnly = bLocked
600: txtTempsMachinageConc.ReadOnly = bLocked
605: txtTempsSoudureConc.ReadOnly = bLocked
610: txtTempsAssemblageConc.ReadOnly = bLocked
615: txtTempsPeintureConc.ReadOnly = bLocked
620: txtTempsTestConc.ReadOnly = bLocked
625: txtTempsInstallationConc.ReadOnly = bLocked
630: txtTempsFormationConc.ReadOnly = bLocked
635: txtTempsGestionConc.ReadOnly = bLocked
640: txtTempsShippingConc.ReadOnly = bLocked
641: txtTempsPrototypeConc.ReadOnly = bLocked
				
645: txtTempsDessinSoum.Enabled = False
650: txtTempsCoupeSoum.Enabled = False
655: txtTempsMachinageSoum.Enabled = False
660: txtTempsSoudureSoum.Enabled = False
665: txtTempsAssemblageSoum.Enabled = False
670: txtTempsPeintureSoum.Enabled = False
675: txtTempsTestSoum.Enabled = False
680: txtTempsInstallationSoum.Enabled = False
685: txtTempsFormationSoum.Enabled = False
690: txtTempsGestionSoum.Enabled = False
695: txtTempsShippingSoum.Enabled = False
696: txtTempsPrototypeSoum.Enabled = False
				
				
700: txtTempsDessinProj.Enabled = False
705: txtTempsCoupeProj.Enabled = False
710: txtTempsMachinageProj.Enabled = False
715: txtTempsSoudureProj.Enabled = False
720: txtTempsAssemblageProj.Enabled = False
725: txtTempsPeintureProj.Enabled = False
730: txtTempsTestProj.Enabled = False
735: txtTempsInstallationProj.Enabled = False
740: txtTempsFormationProj.Enabled = False
745: txtTempsGestionProj.Enabled = False
750: txtTempsShippingProj.Enabled = False
751: txtTempsPrototypeProj.Enabled = False
				
				
755: If m_eMode = enumMode.MODE_AJOUT_MODIF Then
760: If g_bDeverrouillageTempsProjet = True Then
765: cmdUnlock.Visible = True
770: Else
775: cmdUnlock.Visible = False
780: End If
					
785: cmdLock.Visible = False
790: Else
795: cmdLock.Visible = False
800: cmdUnlock.Visible = False
805: End If
810: End If
815: End If
		
820: txtNbrePersonne.ReadOnly = bLocked
825: txtTempsHebergement.ReadOnly = bLocked
830: txtTempsRepas.ReadOnly = bLocked
835: txtTempsDeplacement.ReadOnly = bLocked
840: txtTempsUniteMobile.ReadOnly = bLocked
		
845: txtPrixEmballage.ReadOnly = bLocked
		
850: Exit Sub
		
AfficherErreur: 
		
855: Call AfficherErreur("frmProjSoumMecTemps", "BarrerChamps", Err, Erl())
	End Sub
	
	Private Sub cmdDetail_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDetail.Click
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_PROJET Then
15: Call frmDetailTemps.Afficher(m_sNoProjet, ModuleMain.enumCatalogue.MECANIQUE, True)
20: Else
25: Call frmDetailTemps.Afficher(m_sNoSoumission, ModuleMain.enumCatalogue.MECANIQUE, False)
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmProjSoumMecTemps", "cmdDetail_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
10: If m_eMode = enumMode.MODE_AJOUT_MODIF Then
15: Call EnregistrerTemps()
20: End If
		
25: Call Me.Close()
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmProjSoumMecTemps", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub EnregistrerTemps()
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If Trim(txtTempsDessinSoum.Text) <> vbNullString And IsNumeric(txtTempsDessinSoum.Text) Then
20: FrmProjSoumMec.m_sTempsDessin = txtTempsDessinSoum.Text
25: Else
30: FrmProjSoumMec.m_sTempsDessin = "0"
35: End If
			
40: If Trim(txtTempsCoupeSoum.Text) <> vbNullString And IsNumeric(txtTempsCoupeSoum.Text) Then
45: FrmProjSoumMec.m_sTempsCoupe = txtTempsCoupeSoum.Text
50: Else
55: FrmProjSoumMec.m_sTempsCoupe = "0"
60: End If
			
65: If Trim(txtTempsMachinageSoum.Text) <> vbNullString And IsNumeric(txtTempsMachinageSoum.Text) Then
70: FrmProjSoumMec.m_sTempsMachinage = txtTempsMachinageSoum.Text
75: Else
80: FrmProjSoumMec.m_sTempsMachinage = "0"
85: End If
			
90: If Trim(txtTempsSoudureSoum.Text) <> vbNullString And IsNumeric(txtTempsSoudureSoum.Text) Then
95: FrmProjSoumMec.m_sTempsSoudure = txtTempsSoudureSoum.Text
100: Else
105: FrmProjSoumMec.m_sTempsSoudure = "0"
110: End If
			
115: If Trim(txtTempsAssemblageSoum.Text) <> vbNullString And IsNumeric(txtTempsAssemblageSoum.Text) Then
120: FrmProjSoumMec.m_sTempsAssemblage = txtTempsAssemblageSoum.Text
125: Else
130: FrmProjSoumMec.m_sTempsAssemblage = "0"
135: End If
			
140: If Trim(txtTempsPeintureSoum.Text) <> vbNullString And IsNumeric(txtTempsPeintureSoum.Text) Then
145: FrmProjSoumMec.m_sTempsPeinture = txtTempsPeintureSoum.Text
150: Else
155: FrmProjSoumMec.m_sTempsPeinture = "0"
160: End If
			
165: If Trim(txtTempsTestSoum.Text) <> vbNullString And IsNumeric(txtTempsTestSoum.Text) Then
170: FrmProjSoumMec.m_sTempsTest = txtTempsTestSoum.Text
175: Else
180: FrmProjSoumMec.m_sTempsTest = "0"
185: End If
			
190: If Trim(txtTempsInstallationSoum.Text) <> vbNullString And IsNumeric(txtTempsInstallationSoum.Text) Then
195: FrmProjSoumMec.m_sTempsInstallation = txtTempsInstallationSoum.Text
200: Else
205: FrmProjSoumMec.m_sTempsInstallation = "0"
210: End If
			
215: If Trim(txtTempsFormationSoum.Text) <> vbNullString And IsNumeric(txtTempsFormationSoum.Text) Then
220: FrmProjSoumMec.m_sTempsFormation = txtTempsFormationSoum.Text
225: Else
230: FrmProjSoumMec.m_sTempsFormation = "0"
235: End If
			
240: If Trim(txtTempsGestionSoum.Text) <> vbNullString And IsNumeric(txtTempsGestionSoum.Text) Then
245: FrmProjSoumMec.m_sTempsGestion = txtTempsGestionSoum.Text
250: Else
255: FrmProjSoumMec.m_sTempsGestion = "0"
260: End If
			
265: If Trim(txtTempsShippingSoum.Text) <> vbNullString And IsNumeric(txtTempsShippingSoum.Text) Then
270: FrmProjSoumMec.m_sTempsShipping = txtTempsShippingSoum.Text
275: Else
280: FrmProjSoumMec.m_sTempsShipping = "0"
285: End If
290: Else
295: FrmProjSoumMec.m_bTempsProjLock = m_bLocked
			
300: If m_bLocked = False Then
305: If Trim(txtTempsDessinProj.Text) <> vbNullString And IsNumeric(txtTempsDessinProj.Text) Then
310: FrmProjSoumMec.m_sTempsDessinProj = txtTempsDessinProj.Text
315: Else
320: FrmProjSoumMec.m_sTempsDessinProj = "0"
325: End If
				
330: If Trim(txtTempsCoupeProj.Text) <> vbNullString And IsNumeric(txtTempsMachinageProj.Text) Then
335: FrmProjSoumMec.m_sTempsCoupeProj = txtTempsCoupeProj.Text
340: Else
345: FrmProjSoumMec.m_sTempsCoupeProj = "0"
350: End If
				
355: If Trim(txtTempsMachinageProj.Text) <> vbNullString And IsNumeric(txtTempsMachinageProj.Text) Then
360: FrmProjSoumMec.m_sTempsMachinageProj = txtTempsMachinageProj.Text
365: Else
370: FrmProjSoumMec.m_sTempsMachinageProj = "0"
375: End If
				
380: If Trim(txtTempsSoudureProj.Text) <> vbNullString And IsNumeric(txtTempsSoudureProj.Text) Then
385: FrmProjSoumMec.m_sTempsSoudureProj = txtTempsSoudureProj.Text
390: Else
395: FrmProjSoumMec.m_sTempsSoudureProj = "0"
400: End If
				
405: If Trim(txtTempsAssemblageProj.Text) <> vbNullString And IsNumeric(txtTempsAssemblageProj.Text) Then
410: FrmProjSoumMec.m_sTempsAssemblageProj = txtTempsAssemblageProj.Text
415: Else
420: FrmProjSoumMec.m_sTempsAssemblageProj = "0"
425: End If
				
430: If Trim(txtTempsPeintureProj.Text) <> vbNullString And IsNumeric(txtTempsPeintureProj.Text) Then
435: FrmProjSoumMec.m_sTempsPeintureProj = txtTempsPeintureProj.Text
440: Else
445: FrmProjSoumMec.m_sTempsPeintureProj = "0"
450: End If
				
455: If Trim(txtTempsTestProj.Text) <> vbNullString And IsNumeric(txtTempsTestProj.Text) Then
460: FrmProjSoumMec.m_sTempsTestProj = txtTempsTestProj.Text
465: Else
470: FrmProjSoumMec.m_sTempsTestProj = "0"
475: End If
				
480: If Trim(txtTempsInstallationProj.Text) <> vbNullString And IsNumeric(txtTempsInstallationProj.Text) Then
485: FrmProjSoumMec.m_sTempsInstallationProj = txtTempsInstallationProj.Text
490: Else
495: FrmProjSoumMec.m_sTempsInstallationProj = "0"
500: End If
				
505: If Trim(txtTempsFormationProj.Text) <> vbNullString And IsNumeric(txtTempsFormationProj.Text) Then
510: FrmProjSoumMec.m_sTempsFormationProj = txtTempsFormationProj.Text
515: Else
520: FrmProjSoumMec.m_sTempsFormationProj = "0"
525: End If
				
530: If Trim(txtTempsGestionProj.Text) <> vbNullString And IsNumeric(txtTempsGestionProj.Text) Then
535: FrmProjSoumMec.m_sTempsGestionProj = txtTempsGestionProj.Text
540: Else
545: FrmProjSoumMec.m_sTempsGestionProj = "0"
550: End If
				
555: If Trim(txtTempsShippingProj.Text) <> vbNullString And IsNumeric(txtTempsShippingProj.Text) Then
560: FrmProjSoumMec.m_sTempsShippingProj = txtTempsShippingProj.Text
565: Else
570: FrmProjSoumMec.m_sTempsShippingProj = "0"
575: End If
580: Else
585: If Trim(txtTempsDessinConc.Text) <> vbNullString And IsNumeric(txtTempsDessinConc.Text) Then
590: FrmProjSoumMec.m_sTempsDessinConc = txtTempsDessinConc.Text
595: Else
600: FrmProjSoumMec.m_sTempsDessinConc = "0"
605: End If
				
610: If Trim(txtTempsCoupeConc.Text) <> vbNullString And IsNumeric(txtTempsCoupeConc.Text) Then
615: FrmProjSoumMec.m_sTempsCoupeConc = txtTempsCoupeConc.Text
620: Else
625: FrmProjSoumMec.m_sTempsCoupeConc = "0"
630: End If
				
635: If Trim(txtTempsMachinageConc.Text) <> vbNullString And IsNumeric(txtTempsMachinageConc.Text) Then
640: FrmProjSoumMec.m_sTempsMachinageConc = txtTempsMachinageConc.Text
645: Else
650: FrmProjSoumMec.m_sTempsMachinageConc = "0"
655: End If
				
660: If Trim(txtTempsSoudureConc.Text) <> vbNullString And IsNumeric(txtTempsSoudureConc.Text) Then
665: FrmProjSoumMec.m_sTempsSoudureConc = txtTempsSoudureConc.Text
670: Else
675: FrmProjSoumMec.m_sTempsSoudureConc = "0"
680: End If
				
685: If Trim(txtTempsAssemblageConc.Text) <> vbNullString And IsNumeric(txtTempsAssemblageConc.Text) Then
690: FrmProjSoumMec.m_sTempsAssemblageConc = txtTempsAssemblageConc.Text
695: Else
700: FrmProjSoumMec.m_sTempsAssemblageConc = "0"
705: End If
				
710: If Trim(txtTempsPeintureConc.Text) <> vbNullString And IsNumeric(txtTempsPeintureConc.Text) Then
715: FrmProjSoumMec.m_sTempsPeintureConc = txtTempsPeintureConc.Text
720: Else
725: FrmProjSoumMec.m_sTempsPeintureConc = "0"
730: End If
				
735: If Trim(txtTempsTestConc.Text) <> vbNullString And IsNumeric(txtTempsTestConc.Text) Then
740: FrmProjSoumMec.m_sTempsTestConc = txtTempsTestConc.Text
745: Else
750: FrmProjSoumMec.m_sTempsTestConc = "0"
755: End If
				
760: If Trim(txtTempsInstallationConc.Text) <> vbNullString And IsNumeric(txtTempsInstallationConc.Text) Then
765: FrmProjSoumMec.m_sTempsInstallationConc = txtTempsInstallationConc.Text
770: Else
775: FrmProjSoumMec.m_sTempsInstallationConc = "0"
780: End If
				
785: If Trim(txtTempsFormationConc.Text) <> vbNullString And IsNumeric(txtTempsFormationConc.Text) Then
790: FrmProjSoumMec.m_sTempsFormationConc = txtTempsFormationConc.Text
795: Else
800: FrmProjSoumMec.m_sTempsFormationConc = "0"
805: End If
				
810: If Trim(txtTempsGestionConc.Text) <> vbNullString And IsNumeric(txtTempsGestionConc.Text) Then
815: FrmProjSoumMec.m_sTempsGestionConc = txtTempsGestionConc.Text
820: Else
825: FrmProjSoumMec.m_sTempsGestionConc = "0"
830: End If
				
835: If Trim(txtTempsShippingConc.Text) <> vbNullString And IsNumeric(txtTempsShippingConc.Text) Then
840: FrmProjSoumMec.m_sTempsShippingConc = txtTempsShippingConc.Text
845: Else
850: FrmProjSoumMec.m_sTempsShippingConc = "0"
855: End If
860: End If
865: End If
		
870: If Trim(txtNbrePersonne.Text) <> vbNullString And IsNumeric(txtNbrePersonne.Text) Then
875: FrmProjSoumMec.m_sNbrePersonne = txtNbrePersonne.Text
880: Else
885: FrmProjSoumMec.m_sNbrePersonne = "0"
890: End If
		
895: If Trim(txtTempsHebergement.Text) <> vbNullString And IsNumeric(txtTempsHebergement.Text) Then
900: FrmProjSoumMec.m_sTempsHebergement = txtTempsHebergement.Text
905: Else
910: FrmProjSoumMec.m_sTempsHebergement = "0"
915: End If
		
920: If Trim(txtTempsRepas.Text) <> vbNullString And IsNumeric(txtTempsRepas.Text) Then
925: FrmProjSoumMec.m_sTempsRepas = txtTempsRepas.Text
930: Else
935: FrmProjSoumMec.m_sTempsRepas = "0"
940: End If
		
945: If Trim(txtTempsDeplacement.Text) <> vbNullString And IsNumeric(txtTempsDeplacement.Text) Then
950: FrmProjSoumMec.m_sTempsTransport = txtTempsDeplacement.Text
955: Else
960: FrmProjSoumMec.m_sTempsTransport = "0"
965: End If
		
970: If Trim(txtTempsUniteMobile.Text) <> vbNullString And IsNumeric(txtTempsUniteMobile.Text) Then
975: FrmProjSoumMec.m_sTempsUniteMobile = txtTempsUniteMobile.Text
980: Else
985: FrmProjSoumMec.m_sTempsUniteMobile = "0"
990: End If
		
995: If Trim(txtPrixEmballage.Text) <> vbNullString And IsNumeric(txtPrixEmballage.Text) Then
1000: FrmProjSoumMec.m_sPrixEmballage = txtPrixEmballage.Text
1005: Else
1010: FrmProjSoumMec.m_sPrixEmballage = "0"
1015: End If
		
1020: FrmProjSoumMec.m_sTauxHebergement1 = m_sHebergement1
1025: FrmProjSoumMec.m_sTauxHebergement2 = m_sHebergement2
1030: FrmProjSoumMec.m_sTauxRepas = m_sRepas
1035: FrmProjSoumMec.m_sTauxTransport = m_sStandard
1040: FrmProjSoumMec.m_sTauxUniteMobile = m_sUniteMobile
		
1045: Exit Sub
		
AfficherErreur: 
		
1050: Call AfficherErreur("frmProjSoumMecTemps", "EnregistrerTemps", Err, Erl())
	End Sub
	
	Private Sub cmdLock_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLock.Click
		
5: On Error GoTo AfficherErreur
		
10: If m_sTempsDessinAvant <> txtTempsDessinProj.Text Or m_sTempsCoupeAvant <> txtTempsCoupeProj.Text Or m_sTempsMachinageAvant <> txtTempsMachinageProj.Text Or m_sTempsSoudureAvant <> txtTempsSoudureProj.Text Or m_sTempsAssemblageAvant <> txtTempsAssemblageProj.Text Or m_sTempsPeintureAvant <> txtTempsPeintureProj.Text Or m_sTempsTestAvant <> txtTempsTestProj.Text Or m_sTempsInstallationAvant <> txtTempsInstallationProj.Text Or m_sTempsFormationAvant <> txtTempsFormationProj.Text Or m_sTempsGestionAvant <> txtTempsGestionProj.Text Or m_sTempsShippingAvant <> txtTempsShippingProj.Text Then
15: Call MsgBox("Veuillez enregistrer le projet en premier sinon vous allez perdre les informations qui ont été modifiées dans le temps projets!", MsgBoxStyle.OKOnly, "Erreur")
20: Else
25: m_bLocked = True
			
30: Call BarrerChamps(False)
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmProjSoumMecTemps", "cmdLock_Click", Err, Erl())
	End Sub
	
	Private Sub cmdUnlock_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUnlock.Click
		
5: On Error GoTo AfficherErreur
		
10: m_bLocked = False
		
15: Call BarrerChamps(False)
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmProjSoumMecTemps", "cmdUnlock_Click", Err, Erl())
	End Sub
	
	Private Sub InitialiserVariablesConfig()
		
5: On Error GoTo AfficherErreur
		
		'Initialise les variables à partir de la table Config (Pour avoir le taux
		'horaire le plus récent)
10: Dim rstConfig As ADODB.Recordset
		
15: rstConfig = New ADODB.Recordset
		
20: Call rstConfig.Open("SELECT TauxDessinMec, TauxCoupe, TauxMachinage, TauxSoudure, TauxAssemblageMec, TauxPeinture, TauxTestMec, TauxInstallationMec, TauxFormationMec, TauxGestionProjetsMec, TauxShippingMec, Repas, Hebergement1, Hebergement2, Standard, UniteMobile FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxDessinMec").Value) Then
30: m_sTauxDessin = rstConfig.Fields("TauxDessinMec").Value
35: Else
40: m_sTauxDessin = "0"
45: End If
		
50: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxCoupe").Value) Then
55: m_sTauxCoupe = rstConfig.Fields("TauxCoupe").Value
60: Else
65: m_sTauxCoupe = "0"
70: End If
		
75: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxMachinage").Value) Then
80: m_sTauxMachinage = rstConfig.Fields("TauxMachinage").Value
85: Else
90: m_sTauxMachinage = "0"
95: End If
		
100: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxSoudure").Value) Then
105: m_sTauxSoudure = rstConfig.Fields("TauxSoudure").Value
110: Else
115: m_sTauxSoudure = "0"
120: End If
		
125: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxAssemblageMec").Value) Then
130: m_sTauxAssemblage = rstConfig.Fields("TauxAssemblageMec").Value
135: Else
140: m_sTauxAssemblage = "0"
145: End If
		
150: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxPeinture").Value) Then
155: m_sTauxPeinture = rstConfig.Fields("TauxPeinture").Value
160: Else
165: m_sTauxPeinture = "0"
170: End If
		
175: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxTestMec").Value) Then
180: m_sTauxTest = rstConfig.Fields("TauxTestMec").Value
185: Else
190: m_sTauxTest = "0"
195: End If
		
200: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxInstallationMec").Value) Then
205: m_sTauxInstallation = rstConfig.Fields("TauxInstallationMec").Value
210: Else
215: m_sTauxInstallation = "0"
220: End If
		
225: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxFormationMec").Value) Then
230: m_sTauxFormation = rstConfig.Fields("TauxFormationMec").Value
235: Else
240: m_sTauxFormation = "0"
245: End If
		
250: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxGestionProjetsMec").Value) Then
255: m_sTauxGestion = rstConfig.Fields("TauxGestionProjetsMec").Value
260: Else
265: m_sTauxGestion = "0"
270: End If
		
275: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxShippingMec").Value) Then
280: m_sTauxShipping = rstConfig.Fields("TauxShippingMec").Value
285: Else
290: m_sTauxShipping = "0"
295: End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxShippingMec").Value) Then
296: m_sTauxPrototype = rstConfig.Fields("TauxShippingMec").Value
297: Else
298: m_sTauxPrototype = "0"
299: End If
		
		
		
		
300: m_sRepas = rstConfig.Fields("Repas").Value
305: m_sHebergement1 = rstConfig.Fields("Hebergement1").Value
310: m_sHebergement2 = rstConfig.Fields("Hebergement2").Value
315: m_sStandard = rstConfig.Fields("Standard").Value
320: m_sUniteMobile = rstConfig.Fields("UniteMobile").Value
		
325: Call rstConfig.Close()
330: 'UPGRADE_NOTE: Object rstConfig may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstConfig = Nothing
		
335: Exit Sub
		
AfficherErreur: 
		
340: Call AfficherErreur("frmProjSoumMecTemps", "InitialiserVariablesConfig", Err, Erl())
	End Sub
	
	Private Sub InitialiserVariablesProjSoum()
		
5: On Error GoTo AfficherErreur
		
10: m_sTauxDessin = FrmProjSoumMec.m_sTauxDessin
15: m_sTauxCoupe = FrmProjSoumMec.m_sTauxCoupe
20: m_sTauxMachinage = FrmProjSoumMec.m_sTauxMachinage
25: m_sTauxSoudure = FrmProjSoumMec.m_sTauxSoudure
30: m_sTauxAssemblage = FrmProjSoumMec.m_sTauxAssemblage
35: m_sTauxPeinture = FrmProjSoumMec.m_sTauxPeinture
40: m_sTauxTest = FrmProjSoumMec.m_sTauxTest
45: m_sTauxInstallation = FrmProjSoumMec.m_sTauxInstallation
50: m_sTauxFormation = FrmProjSoumMec.m_sTauxFormation
55: m_sTauxGestion = FrmProjSoumMec.m_sTauxGestion
60: m_sTauxShipping = FrmProjSoumMec.m_sTauxShipping
		m_sTauxPrototype = FrmProjSoumMec.m_sTauxShipping
		
65: m_sRepas = FrmProjSoumMec.m_sTauxRepas
70: m_sHebergement1 = FrmProjSoumMec.m_sTauxHebergement1
75: m_sHebergement2 = FrmProjSoumMec.m_sTauxHebergement2
80: m_sStandard = FrmProjSoumMec.m_sTauxTransport
85: m_sUniteMobile = FrmProjSoumMec.m_sTauxUniteMobile
		
90: Exit Sub
		
AfficherErreur: 
		
95: Call AfficherErreur("frmProjSoumMecTemps", "InitialiserVariablesProjSoum", Err, Erl())
	End Sub
	
	Private Sub frmProjSoumMecTemps_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: If FrmProjSoumMec.m_bDroitPrix = False Then
15: fraRessourcesHumaines.Width = VB6.TwipsToPixelsX(4150)
20: fraFraisSubsistences.Width = VB6.TwipsToPixelsX(4150)
			
25: fraFraisSubsistences.Left = VB6.TwipsToPixelsX(4390)
			
30: fraManutention.Visible = False
35: lblTotalPrixRH.Visible = False
			
40: cmdFermer.Left = VB6.TwipsToPixelsX(7320)
			
45: cmdFermer.Top = VB6.TwipsToPixelsY(4200)
			
50: Me.Width = VB6.TwipsToPixelsX(8800)
55: Me.Height = VB6.TwipsToPixelsY(7485)
60: End If
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmProjSoumMecTemps", "Form_Load", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtNbrePersonne.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtNbrePersonne_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtNbrePersonne.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If txtTempsHebergement.Text <> vbNullString Then
15: If IsNumeric(txtNbrePersonne.Text) Then
20: Call CalculerHebergement()
25: Call CalculerRepas()
				
30: Call CalculerTotal()
35: End If
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmProjSoumMecTemps", "txtNbrePersonne_Change", Err, Erl())
	End Sub
	
	Private Sub txtPrixEmballage_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPrixEmballage.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
5: On Error GoTo AfficherErreur
		
10: If KeyAscii = 46 Then 'Si c'est le "."
15: KeyAscii = 44 'Remplace par la ","
20: End If
		
25: GoTo EventExitSub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmProjSoumMecTemps", "lblPrixEmballage_KeyPress", Err, Erl())
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsAssemblageConc.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsAssemblageConc_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsAssemblageConc.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsAssemblageConc_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsAssemblageProj.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsAssemblageProj_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsAssemblageProj.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsAssemblageProj_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsCoupeConc.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsCoupeConc_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsCoupeConc.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsCoupeConc_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsCoupeProj.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsCoupeProj_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsCoupeProj.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsCoupeProj_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsDessinConc.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsDessinConc_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsDessinConc.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsDessinConc_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsDessinProj.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsDessinProj_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsDessinProj.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsDessinProj_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsFormationConc.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsFormationConc_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsFormationConc.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsFormationConc_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsFormationProj.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsFormationProj_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsFormationProj.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsFormationProj_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsGestionConc.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsGestionConc_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsGestionConc.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsGestionConc_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsGestionProj.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsGestionProj_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsGestionProj.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsGestionProj_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsShippingConc.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsShippingConc_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsShippingConc.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsShippingConc_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsShippingProj.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsShippingProj_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsShippingProj.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsShippingProj_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsInstallationConc.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsInstallationConc_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsInstallationConc.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsInstallationConc_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsInstallationProj.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsInstallationProj_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsInstallationProj.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsInstallationProj_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsMachinageConc.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsMachinageConc_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsMachinageConc.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsMachinageConc_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsMachinageProj.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsMachinageProj_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsMachinageProj.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsMachinageProj_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsMachinageSoum.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsMachinageSoum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsMachinageSoum.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If IsNumeric(txtTempsMachinageSoum.Text) Then
20: lblPrixMachinage.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsMachinageSoum.Text) * CDbl(m_sTauxMachinage)), ".", ",")), 2))
25: Else
30: lblPrixMachinage.Text = CStr(0)
35: End If
			
40: Call CalculerTotal()
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsMachinageSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsMachinageSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsMachinageSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsMachinageSoum.Text = Replace(txtTempsMachinageSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsMachinageSoum_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsMachinageProj_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsMachinageProj.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsMachinageProj.Text = Replace(txtTempsMachinageProj.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsMachinageProj_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsMachinageConc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsMachinageConc.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsMachinageConc.Text = Replace(txtTempsMachinageConc.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsMachinageConc_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsCoupeSoum.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsCoupeSoum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsCoupeSoum.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If IsNumeric(txtTempsCoupeSoum.Text) Then
20: lblPrixCoupe.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsCoupeSoum.Text) * CDbl(m_sTauxCoupe)), ".", ",")), 2))
25: Else
30: lblPrixCoupe.Text = CStr(0)
35: End If
			
40: Call CalculerTotal()
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsCoupeSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsCoupeSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsCoupeSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsCoupeSoum.Text = Replace(txtTempsCoupeSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsCoupeSoum_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsCoupeProj_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsCoupeProj.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsCoupeProj.Text = Replace(txtTempsCoupeProj.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsCoupeProj_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsCoupeConc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsCoupeConc.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsCoupeConc.Text = Replace(txtTempsCoupeConc.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsCoupeConc_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsPeintureConc.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsPeintureConc_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsPeintureConc.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsPeintureConc_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsPeintureProj.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsPeintureProj_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsPeintureProj.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsPeintureProj_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsSoudureConc.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsSoudureConc_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsSoudureConc.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsSoudureConc_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsSoudureProj.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsSoudureProj_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsSoudureProj.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsSoudureProj_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsSoudureSoum.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsSoudureSoum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsSoudureSoum.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If IsNumeric(txtTempsSoudureSoum.Text) Then
20: lblPrixSoudure.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsSoudureSoum.Text) * CDbl(m_sTauxSoudure)), ".", ",")), 2))
25: Else
30: lblPrixSoudure.Text = CStr(0)
35: End If
			
40: Call CalculerTotal()
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsSoudureSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsSoudureSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsSoudureSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsSoudureSoum.Text = Replace(txtTempsSoudureSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsSoudureSoum_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsSoudureProj_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsSoudureProj.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsSoudureProj.Text = Replace(txtTempsSoudureProj.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsSoudureProj_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsSoudureConc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsSoudureConc.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsSoudureConc.Text = Replace(txtTempsSoudureConc.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsSoudureConc_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsAssemblageSoum.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsAssemblageSoum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsAssemblageSoum.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If IsNumeric(txtTempsAssemblageSoum.Text) Then
20: lblPrixAssemblage.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsAssemblageSoum.Text) * CDbl(m_sTauxAssemblage)), ".", ",")), 2))
25: Else
30: lblPrixAssemblage.Text = CStr(0)
35: End If
			
40: Call CalculerTotal()
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsAssemblageSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsAssemblageSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsAssemblageSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsAssemblageSoum.Text = Replace(txtTempsAssemblageSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsAssemblageSoum_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsAssemblageProj_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsAssemblageProj.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsAssemblageProj.Text = Replace(txtTempsAssemblageProj.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsAssemblageProj_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsAssemblageConc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsAssemblageConc.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsAssemblageConc.Text = Replace(txtTempsAssemblageConc.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsAssemblageConc_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsPeintureSoum.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsPeintureSoum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsPeintureSoum.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If IsNumeric(txtTempsPeintureSoum.Text) Then
20: lblPrixPeinture.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsPeintureSoum.Text) * CDbl(m_sTauxPeinture)), ".", ",")), 2))
25: Else
30: lblPrixPeinture.Text = CStr(0)
35: End If
			
40: Call CalculerTotal()
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsPeintureSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsPeintureSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsPeintureSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsPeintureSoum.Text = Replace(txtTempsPeintureSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsPeintureSoum_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsPeintureProj_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsPeintureProj.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsPeintureProj.Text = Replace(txtTempsPeintureProj.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsPeintureProj_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsPeintureConc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsPeintureConc.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsPeintureConc.Text = Replace(txtTempsPeintureConc.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsPeintureConc_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsTestConc.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsTestConc_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsTestConc.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsTestConc_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsTestProj.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsTestProj_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsTestProj.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotalTemps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsTestProj_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsTestSoum.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsTestSoum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsTestSoum.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If IsNumeric(txtTempsTestSoum.Text) Then
20: lblPrixTest.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsTestSoum.Text) * CDbl(m_sTauxTest)), ".", ",")), 2))
25: Else
30: lblPrixTest.Text = CStr(0)
35: End If
			
40: Call CalculerTotal()
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsTestSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsTestSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsTestSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsTestSoum.Text = Replace(txtTempsTestSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsTestSoum_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsTestProj_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsTestProj.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsTestProj.Text = Replace(txtTempsTestProj.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsTestProj_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsTestConc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsTestConc.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsTestConc.Text = Replace(txtTempsTestConc.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsTestConc_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsInstallationSoum.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsInstallationSoum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsInstallationSoum.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If IsNumeric(txtTempsInstallationSoum.Text) Then
20: lblPrixInstallation.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsInstallationSoum.Text) * CDbl(m_sTauxInstallation)), ".", ",")), 2))
25: Else
30: lblPrixInstallation.Text = CStr(0)
35: End If
			
40: Call CalculerTotal()
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsInstallationSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsInstallationSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsInstallationSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsInstallationSoum.Text = Replace(txtTempsInstallationSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsInstallationSoum_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsInstallationProj_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsInstallationProj.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsInstallationProj.Text = Replace(txtTempsInstallationProj.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsInstallationProj_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsInstallationConc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsInstallationConc.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsInstallationConc.Text = Replace(txtTempsInstallationConc.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsInstallationConc_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsDessinSoum.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsDessinSoum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsDessinSoum.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If IsNumeric(txtTempsDessinSoum.Text) Then
20: lblPrixDessin.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsDessinSoum.Text) * CDbl(m_sTauxDessin)), ".", ",")), 2))
25: Else
30: lblPrixDessin.Text = CStr(0)
35: End If
			
40: Call CalculerTotal()
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsDessinSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsDessinSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsDessinSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsDessinSoum.Text = Replace(txtTempsDessinSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsDessinSoum_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsDessinProj_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsDessinProj.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsDessinProj.Text = Replace(txtTempsDessinProj.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsDessinProj_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsDessinConc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsDessinConc.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsDessinConc.Text = Replace(txtTempsDessinConc.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsDessinConc_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsFormationSoum.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsFormationSoum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsFormationSoum.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If IsNumeric(txtTempsFormationSoum.Text) Then
20: lblPrixFormation.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsFormationSoum.Text) * CDbl(m_sTauxFormation)), ".", ",")), 2))
25: Else
30: lblPrixFormation.Text = CStr(0)
35: End If
			
40: Call CalculerTotal()
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsFormationSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsFormationSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsFormationSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsFormationSoum.Text = Replace(txtTempsFormationSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsFormationSoum_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsFormationProj_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsFormationProj.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsFormationProj.Text = Replace(txtTempsFormationProj.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsFormationProj_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsFormationConc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsFormationConc.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsFormationConc.Text = Replace(txtTempsFormationConc.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsFormationConc_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsGestionSoum.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsGestionSoum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsGestionSoum.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If IsNumeric(txtTempsGestionSoum.Text) Then
20: lblPrixGestion.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsGestionSoum.Text) * CDbl(m_sTauxGestion)), ".", ",")), 2))
25: Else
30: lblPrixGestion.Text = CStr(0)
35: End If
			
40: Call CalculerTotal()
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsGestionSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsGestionSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsGestionSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsGestionSoum.Text = Replace(txtTempsGestionSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsGestionSoum_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsGestionProj_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsGestionProj.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsGestionProj.Text = Replace(txtTempsGestionProj.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsGestionProj_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsGestionConc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsGestionConc.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsGestionConc.Text = Replace(txtTempsGestionConc.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsGestionConc_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsShippingSoum.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsShippingSoum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsShippingSoum.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If IsNumeric(txtTempsShippingSoum.Text) Then
20: lblPrixShipping.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsShippingSoum.Text) * CDbl(m_sTauxShipping)), ".", ",")), 2))
25: Else
30: lblPrixShipping.Text = CStr(0)
35: End If
			
40: Call CalculerTotal()
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsShippingSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsShippingSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsShippingSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsShippingSoum.Text = Replace(txtTempsShippingSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsShippingSoum_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsShippingProj_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsShippingProj.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsShippingProj.Text = Replace(txtTempsShippingProj.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsShippingProj_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtTempsShippingConc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsShippingConc.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsShippingConc.Text = Replace(txtTempsShippingConc.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsShippingConc_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsHebergement.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsHebergement_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsHebergement.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If IsNumeric(txtTempsHebergement.Text) Then
15: If txtNbrePersonne.Text <> vbNullString Then
20: Call CalculerHebergement()
25: End If
30: End If
		
35: Call CalculerTotal()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsHebergement_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsHebergement_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsHebergement.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsHebergement.Text = Replace(txtTempsHebergement.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsHebergement_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsRepas.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsRepas_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsRepas.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If IsNumeric(txtTempsRepas.Text) Then
15: If txtNbrePersonne.Text <> vbNullString Then
20: Call CalculerRepas()
25: End If
30: End If
		
35: Call CalculerTotal()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsRepas_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsRepas_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsRepas.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsRepas.Text = Replace(txtTempsRepas.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsRepas_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsDeplacement.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsDeplacement_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsDeplacement.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If IsNumeric(txtTempsDeplacement.Text) Then
15: lblPrixDeplacement.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsDeplacement.Text) * CDbl(m_sStandard)), ".", ",")), 2))
20: Else
25: lblPrixDeplacement.Text = CStr(0)
30: End If
		
35: Call CalculerTotal()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsDeplacement_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsDeplacement_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsDeplacement.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsDeplacement.Text = Replace(txtTempsDeplacement.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsDeplacement_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsUniteMobile.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsUniteMobile_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsUniteMobile.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If IsNumeric(txtTempsUniteMobile.Text) Then
15: lblPrixUniteMobile.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsUniteMobile.Text) * CDbl(m_sUniteMobile)), ".", ",")), 2))
20: Else
25: lblPrixUniteMobile.Text = CStr(0)
30: End If
		
35: Call CalculerTotal()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsUniteMobile_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsUniteMobile_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsUniteMobile.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsUniteMobile.Text = Replace(txtTempsUniteMobile.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "txtTempsUniteMobile_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtPrixEmballage.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtPrixEmballage_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrixEmballage.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotal()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumMecTemps", "lblPrixEmballage_Change", Err, Erl())
	End Sub
	
	Private Sub txtPrixEmballage_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrixEmballage.Leave
		
5: On Error GoTo AfficherErreur
		
10: If IsNumeric(txtPrixEmballage.Text) Then
15: txtPrixEmballage.Text = CStr(System.Math.Round(CDbl(Replace(txtPrixEmballage.Text, ".", ",")), 2))
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmProjSoumMecTemps", "lblPrixEmballage_LostFocus", Err, Erl())
	End Sub
	
	Private Sub CalculerHebergement()
		
5: On Error GoTo AfficherErreur
		
10: Dim dblNbreDeux As Double
15: Dim dblHebergement As Double
20: Dim iReste As Short
25: Dim dblNbrePers As Double
30: Dim dblNbreJours As Double
		
35: If IsNumeric(txtNbrePersonne.Text) Then
40: dblNbrePers = CDbl(txtNbrePersonne.Text)
45: Else
50: dblNbrePers = 0
55: End If
		
60: If IsNumeric(txtTempsHebergement.Text) Then
65: dblNbreJours = CDbl(txtTempsHebergement.Text)
70: Else
75: dblNbreJours = 0
80: End If
		
85: dblNbreDeux = Int(dblNbrePers / 2)
		
90: iReste = CShort(dblNbrePers) - (dblNbreDeux * 2)
		
95: dblHebergement = dblNbreJours * ((dblNbreDeux * CDbl(m_sHebergement2)) + (iReste * CDbl(m_sHebergement1)))
		
100: lblPrixHebergement.Text = CStr(System.Math.Round(CDbl(Replace(CStr(dblHebergement), ".", ",")), 2))
		
105: Exit Sub
		
AfficherErreur: 
		
110: Call AfficherErreur("frmProjSoumMecTemps", "CalculerHebergement", Err, Erl())
	End Sub
	
	Private Sub CalculerRepas()
		
5: On Error GoTo AfficherErreur
		
10: Dim dblNbrePers As Double
15: Dim dblRepas As Double
20: Dim dblNbreJours As Double
		
25: If IsNumeric(txtNbrePersonne.Text) Then
30: dblNbrePers = CDbl(txtNbrePersonne.Text)
35: Else
40: dblNbrePers = 0
45: End If
		
50: If IsNumeric(txtTempsRepas.Text) Then
55: dblNbreJours = CDbl(txtTempsRepas.Text)
60: Else
65: dblNbreJours = 0
70: End If
		
75: dblRepas = dblNbreJours * dblNbrePers * CDbl(m_sRepas)
		
80: lblPrixRepas.Text = CStr(System.Math.Round(CDbl(Replace(CStr(dblRepas), ".", ",")), 2))
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("frmProjSoumMecTemps", "CalculerRepas", Err, Erl())
	End Sub
	
	Private Sub CalculerTotal()
		
5: On Error GoTo AfficherErreur
		
10: Dim dblTotal As Double
15: Dim dblPrixEmballage As Double
20: Dim dblTotalArgentRH As Double
25: Dim dblPrixDessin As Double
30: Dim dblPrixCoupe As Double
35: Dim dblPrixMachinage As Double
40: Dim dblPrixSoudure As Double
45: Dim dblPrixAssemblage As Double
50: Dim dblPrixPeinture As Double
55: Dim dblPrixTest As Double
60: Dim dblPrixInstallation As Double
65: Dim dblPrixFormation As Double
70: Dim dblPrixGestion As Double
75: Dim dblPrixShipping As Double
80: Dim dblPrixHebergement As Double
85: Dim dblPrixRepas As Double
90: Dim dblPrixDeplacement As Double
95: Dim dblPrixUniteMobile As Double
		
		'Prix de dessin
100: If IsNumeric(lblPrixDessin.Text) Then
105: dblPrixDessin = CDbl(lblPrixDessin.Text)
110: Else
115: dblPrixDessin = 0
120: End If
		
		'Prix de coupe et préparation
125: If IsNumeric(lblPrixCoupe.Text) Then
130: dblPrixCoupe = CDbl(lblPrixCoupe.Text)
135: Else
140: dblPrixCoupe = 0
145: End If
		
		'Prix de machinage
150: If IsNumeric(lblPrixMachinage.Text) Then
155: dblPrixMachinage = CDbl(lblPrixMachinage.Text)
160: Else
165: dblPrixMachinage = 0
170: End If
		
		'Prix de soudure et meulage
175: If IsNumeric(lblPrixSoudure.Text) Then
180: dblPrixSoudure = CDbl(lblPrixSoudure.Text)
185: Else
190: dblPrixSoudure = 0
195: End If
		
		'Prix d'assemblage du système
200: If IsNumeric(lblPrixAssemblage.Text) Then
205: dblPrixAssemblage = CDbl(lblPrixAssemblage.Text)
210: Else
215: dblPrixAssemblage = 0
220: End If
		
		'Prix de peinture et finition
225: If IsNumeric(lblPrixPeinture.Text) Then
230: dblPrixPeinture = CDbl(lblPrixPeinture.Text)
235: Else
240: dblPrixPeinture = 0
245: End If
		
		'Prix de tests finaux
250: If IsNumeric(lblPrixTest.Text) Then
255: dblPrixTest = CDbl(lblPrixTest.Text)
260: Else
265: dblPrixTest = 0
270: End If
		
		'Prix d'Installation
275: If IsNumeric(lblPrixInstallation.Text) Then
280: dblPrixInstallation = CDbl(lblPrixInstallation.Text)
285: Else
290: dblPrixInstallation = 0
295: End If
		
		'Prix de formation
300: If IsNumeric(lblPrixFormation.Text) Then
305: dblPrixFormation = CDbl(lblPrixFormation.Text)
310: Else
315: dblPrixFormation = 0
320: End If
		
		'Prix de gestion du projet
325: If IsNumeric(lblPrixGestion.Text) Then
330: dblPrixGestion = CDbl(lblPrixGestion.Text)
335: Else
340: dblPrixGestion = 0
345: End If
		
		'Prix de shipping
350: If IsNumeric(lblPrixShipping.Text) Then
355: dblPrixShipping = CDbl(lblPrixShipping.Text)
360: Else
365: dblPrixShipping = 0
370: End If
		
		
		'Prix de dévelloppement prototypage
371: If IsNumeric(lblPrixPrototype.Text) Then
372: 'dblPrixPrototype = CDbl(lblPrixPrototype.Caption)
373: Else
374: 'dblPrixPrototype = 0
		End If
		
		
		
		'Prix d'hébergement
375: If IsNumeric(lblPrixHebergement.Text) Then
380: dblPrixHebergement = CDbl(lblPrixHebergement.Text)
385: Else
390: dblPrixHebergement = 0
395: End If
		
		'Prix des repas
400: If IsNumeric(lblPrixRepas.Text) Then
405: dblPrixRepas = CDbl(lblPrixRepas.Text)
410: Else
415: dblPrixRepas = 0
420: End If
		
		'Prix du déplacement
425: If IsNumeric(lblPrixDeplacement.Text) Then
430: dblPrixDeplacement = CDbl(lblPrixDeplacement.Text)
435: Else
440: dblPrixDeplacement = 0
445: End If
		
		'Prix de l'unité mobile
450: If IsNumeric(lblPrixUniteMobile.Text) Then
455: dblPrixUniteMobile = CDbl(lblPrixUniteMobile.Text)
460: Else
465: dblPrixUniteMobile = 0
470: End If
		
		'Prix de transport et emballage
475: If IsNumeric(txtPrixEmballage.Text) Then
480: dblPrixEmballage = CDbl(txtPrixEmballage.Text)
485: Else
490: dblPrixEmballage = 0
495: End If
		
500: dblTotalArgentRH = dblPrixDessin + dblPrixCoupe + dblPrixMachinage + dblPrixSoudure + dblPrixAssemblage + dblPrixPeinture + dblPrixTest + dblPrixInstallation + dblPrixFormation + dblPrixGestion + dblPrixShipping
		'dblPrixPrototype
		
505: lblTotalPrixRH.Text = Conversion_Renamed(CStr(dblTotalArgentRH), ModuleMain.enumConvert.MODE_DECIMAL)
		
		
510: dblTotal = dblTotalArgentRH + dblPrixHebergement + dblPrixRepas + dblPrixDeplacement + dblPrixUniteMobile + dblPrixEmballage
		
515: lblTotal.Text = Conversion_Renamed(CStr(dblTotal), ModuleMain.enumConvert.MODE_DECIMAL)
		
520: Call CalculerTotalTemps()
		
525: Exit Sub
		
AfficherErreur: 
		
530: Call AfficherErreur("frmProjSoumMecTemps", "CalculerTotal", Err, Erl())
	End Sub
	
	Private Sub CalculerTotalTemps()
		
		
5: On Error GoTo AfficherErreur
		
10: Dim dblTempsDessin As Double
15: Dim dblTempsCoupe As Double
20: Dim dblTempsMachinage As Double
25: Dim dblTempsSoudure As Double
30: Dim dblTempsAssemblage As Double
35: Dim dblTempsPeinture As Double
40: Dim dblTempsTest As Double
45: Dim dblTempsInstallation As Double
50: Dim dblTempsFormation As Double
55: Dim dblTempsGestion As Double
60: Dim dblTempsShipping As Double
65: Dim dblTotalTemps As Double
		
		'SOUMISSION
70: If IsNumeric(txtTempsDessinSoum.Text) Then
75: dblTempsDessin = CDbl(txtTempsDessinSoum.Text)
80: Else
85: dblTempsDessin = 0
90: End If
		
95: If IsNumeric(txtTempsCoupeSoum.Text) Then
100: dblTempsCoupe = CDbl(txtTempsCoupeSoum.Text)
105: Else
110: dblTempsCoupe = 0
115: End If
		
120: If IsNumeric(txtTempsMachinageSoum.Text) Then
125: dblTempsMachinage = CDbl(txtTempsMachinageSoum.Text)
130: Else
135: dblTempsMachinage = 0
140: End If
		
145: If IsNumeric(txtTempsSoudureSoum.Text) Then
150: dblTempsSoudure = CDbl(txtTempsSoudureSoum.Text)
155: Else
160: dblTempsSoudure = 0
165: End If
		
170: If IsNumeric(txtTempsAssemblageSoum.Text) Then
175: dblTempsAssemblage = CDbl(txtTempsAssemblageSoum.Text)
180: Else
185: dblTempsAssemblage = 0
190: End If
		
195: If IsNumeric(txtTempsPeintureSoum.Text) Then
200: dblTempsPeinture = CDbl(txtTempsPeintureSoum.Text)
205: Else
210: dblTempsPeinture = 0
215: End If
		
220: If IsNumeric(txtTempsTestSoum.Text) Then
225: dblTempsTest = CDbl(txtTempsTestSoum.Text)
230: Else
235: dblTempsTest = 0
240: End If
		
245: If IsNumeric(txtTempsInstallationSoum.Text) Then
250: dblTempsInstallation = CDbl(txtTempsInstallationSoum.Text)
255: Else
260: dblTempsInstallation = 0
265: End If
		
270: If IsNumeric(txtTempsFormationSoum.Text) Then
275: dblTempsFormation = CDbl(txtTempsFormationSoum.Text)
280: Else
285: dblTempsFormation = 0
290: End If
		
295: If IsNumeric(txtTempsGestionSoum.Text) Then
300: dblTempsGestion = CDbl(txtTempsGestionSoum.Text)
305: Else
310: dblTempsGestion = 0
315: End If
		
320: If IsNumeric(txtTempsShippingSoum.Text) Then
325: dblTempsShipping = CDbl(txtTempsShippingSoum.Text)
330: Else
335: dblTempsShipping = 0
340: End If
		
345: dblTotalTemps = dblTempsDessin + dblTempsCoupe + dblTempsMachinage + dblTempsSoudure + dblTempsAssemblage + dblTempsPeinture + dblTempsTest + dblTempsInstallation + dblTempsFormation + dblTempsGestion + dblTempsShipping
		
350: lblTotalTempsRHSoum.Text = Conversion_Renamed(dblTotalTemps, ModuleMain.enumConvert.MODE_DECIMAL)
		
		'PROJET
355: If m_eType = enumType.TYPE_PROJET Then
360: If IsNumeric(txtTempsDessinProj.Text) Then
365: dblTempsDessin = CDbl(txtTempsDessinProj.Text)
370: Else
375: dblTempsDessin = 0
380: End If
			
385: If IsNumeric(txtTempsCoupeProj.Text) Then
390: dblTempsCoupe = CDbl(txtTempsCoupeProj.Text)
395: Else
400: dblTempsCoupe = 0
405: End If
			
410: If IsNumeric(txtTempsMachinageProj.Text) Then
415: dblTempsMachinage = CDbl(txtTempsMachinageProj.Text)
420: Else
425: dblTempsMachinage = 0
430: End If
			
435: If IsNumeric(txtTempsSoudureProj.Text) Then
440: dblTempsSoudure = CDbl(txtTempsSoudureProj.Text)
445: Else
450: dblTempsSoudure = 0
455: End If
			
460: If IsNumeric(txtTempsAssemblageProj.Text) Then
465: dblTempsAssemblage = CDbl(txtTempsAssemblageProj.Text)
470: Else
475: dblTempsAssemblage = 0
480: End If
			
485: If IsNumeric(txtTempsPeintureProj.Text) Then
490: dblTempsPeinture = CDbl(txtTempsPeintureProj.Text)
495: Else
500: dblTempsPeinture = 0
505: End If
			
510: If IsNumeric(txtTempsTestProj.Text) Then
515: dblTempsTest = CDbl(txtTempsTestProj.Text)
520: Else
525: dblTempsTest = 0
530: End If
			
535: If IsNumeric(txtTempsInstallationProj.Text) Then
540: dblTempsInstallation = CDbl(txtTempsInstallationProj.Text)
545: Else
550: dblTempsInstallation = 0
555: End If
			
560: If IsNumeric(txtTempsFormationProj.Text) Then
565: dblTempsFormation = CDbl(txtTempsFormationProj.Text)
570: Else
575: dblTempsFormation = 0
580: End If
			
585: If IsNumeric(txtTempsGestionProj.Text) Then
590: dblTempsGestion = CDbl(txtTempsGestionProj.Text)
595: Else
600: dblTempsGestion = 0
605: End If
			
610: If IsNumeric(txtTempsShippingProj.Text) Then
615: dblTempsShipping = CDbl(txtTempsShippingProj.Text)
620: Else
625: dblTempsShipping = 0
630: End If
			
			
631: If IsNumeric(txtTempsPrototypeProj.Text) Then
632: '  dblTempsPrototype = CDbl(txtTempsPrototypeProj.Text)
633: Else
634: '  dblTempsPrototype = 0
			End If
			
			
			
635: dblTotalTemps = dblTempsDessin + dblTempsCoupe + dblTempsMachinage + dblTempsSoudure + dblTempsAssemblage + dblTempsPeinture + dblTempsTest + dblTempsInstallation + dblTempsFormation + dblTempsGestion + dblTempsShipping
			
			'dblTempsPrototype
			
640: lblTotalTempsRHProj.Text = Conversion_Renamed(dblTotalTemps, ModuleMain.enumConvert.MODE_DECIMAL)
645: End If
		
		'CONCEPTION
650: If m_eType = enumType.TYPE_PROJET And m_bLocked = True Then
655: If IsNumeric(txtTempsDessinConc.Text) Then
660: dblTempsDessin = CDbl(txtTempsDessinConc.Text)
665: Else
670: dblTempsDessin = 0
675: End If
			
680: If IsNumeric(txtTempsCoupeConc.Text) Then
685: dblTempsCoupe = CDbl(txtTempsCoupeConc.Text)
690: Else
695: dblTempsCoupe = 0
700: End If
			
705: If IsNumeric(txtTempsMachinageConc.Text) Then
710: dblTempsMachinage = CDbl(txtTempsMachinageConc.Text)
715: Else
720: dblTempsMachinage = 0
725: End If
			
730: If IsNumeric(txtTempsSoudureConc.Text) Then
735: dblTempsSoudure = CDbl(txtTempsSoudureConc.Text)
740: Else
745: dblTempsSoudure = 0
750: End If
			
755: If IsNumeric(txtTempsAssemblageConc.Text) Then
760: dblTempsAssemblage = CDbl(txtTempsAssemblageConc.Text)
765: Else
770: dblTempsAssemblage = 0
775: End If
			
780: If IsNumeric(txtTempsPeintureConc.Text) Then
785: dblTempsPeinture = CDbl(txtTempsPeintureConc.Text)
790: Else
795: dblTempsPeinture = 0
800: End If
			
805: If IsNumeric(txtTempsTestConc.Text) Then
810: dblTempsTest = CDbl(txtTempsTestConc.Text)
815: Else
820: dblTempsTest = 0
825: End If
			
830: If IsNumeric(txtTempsInstallationConc.Text) Then
835: dblTempsInstallation = CDbl(txtTempsInstallationConc.Text)
840: Else
845: dblTempsInstallation = 0
850: End If
			
855: If IsNumeric(txtTempsFormationConc.Text) Then
860: dblTempsFormation = CDbl(txtTempsFormationConc.Text)
865: Else
870: dblTempsFormation = 0
875: End If
			
880: If IsNumeric(txtTempsGestionConc.Text) Then
885: dblTempsGestion = CDbl(txtTempsGestionConc.Text)
890: Else
895: dblTempsGestion = 0
900: End If
			
905: If IsNumeric(txtTempsShippingConc.Text) Then
910: dblTempsShipping = CDbl(txtTempsShippingConc.Text)
915: Else
920: dblTempsShipping = 0
925: End If
			
930: dblTotalTemps = dblTempsDessin + dblTempsCoupe + dblTempsMachinage + dblTempsSoudure + dblTempsAssemblage + dblTempsPeinture + dblTempsTest + dblTempsInstallation + dblTempsFormation + dblTempsGestion + dblTempsShipping
			
935: lblTotalTempsRHConc.Text = Conversion_Renamed(dblTotalTemps, ModuleMain.enumConvert.MODE_DECIMAL)
940: End If
		
945: Exit Sub
		
AfficherErreur: 
		
950: Call AfficherErreur("frmProjSoumMecTemps", "CalculerTotalTemps", Err, Erl())
	End Sub
End Class