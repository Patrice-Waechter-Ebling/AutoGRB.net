Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmProjSoumElecTemps
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
	Private m_sTauxFabrication As String
	Private m_sTauxAssemblage As String
	Private m_sTauxProgInterface As String
	Private m_sTauxProgAutomate As String
	Private m_sTauxProgRobot As String
	Private m_sTauxVision As String
	Private m_sTauxTest As String
	Private m_sTauxInstallation As String
	Private m_sTauxMiseService As String
	Private m_sTauxFormation As String
	Private m_sTauxGestion As String
	Private m_sTauxShipping As String
	
	Private m_sRepas As String
	Private m_sHebergement1 As String
	Private m_sHebergement2 As String
	Private m_sStandard As String
	Private m_sUniteMobile As String
	
	Private m_sNoProjSoum As String
	
	Private m_eType As enumType
	
	Private m_eMode As enumMode
	
	Private m_bNouveauTaux As Boolean 'Pour savoir si les nouveaux taux doivent être prit
	
	Private m_bSansTemps As Boolean
	
	Public Sub Afficher(ByVal sNoProjSoum As String, ByVal iType As Short, ByVal iMode As Short, ByVal bNouveauTaux As Boolean)
		
5: On Error GoTo AfficherErreur
		
10: m_eType = iType
		
15: m_eMode = iMode
		
20: m_sNoProjSoum = sNoProjSoum
		
25: m_bNouveauTaux = bNouveauTaux
		
30: If bNouveauTaux = True Then
35: Call InitialiserVariablesConfig()
40: Else
45: Call InitialiserVariablesProjSoum()
50: End If
		
55: If m_eMode = enumMode.MODE_AJOUT_MODIF Then
60: Call BarrerChamps(False)
65: Else
70: Call BarrerChamps(True)
75: End If
		
80: Call AfficherEnregistrement()
		
85: Call Me.ShowDialog()
		
90: Exit Sub
		
AfficherErreur: 
		
95: Call AfficherErreur("frmProjSoumElecTemps", "Afficher", Err, Erl())
	End Sub
	
	Private Sub AfficherEnregistrement()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjSoum As ADODB.Recordset
15: Dim rstSoum As ADODB.Recordset
20: Dim sChamps As String
25: Dim sTable As String
		
30: If m_eType = enumType.TYPE_PROJET Then
35: sChamps = "IDProjet"
40: sTable = "GRB_ProjetElec"
45: Else
50: sChamps = "IDSoumission"
55: sTable = "GRB_SoumissionElec"
60: End If
		
65: rstProjSoum = New ADODB.Recordset
		
70: Call rstProjSoum.Open("SELECT * FROM " & sTable & " WHERE " & sChamps & " = '" & m_sNoProjSoum & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
75: If Not rstProjSoum.EOF And FrmProjSoumElec.m_bTempsDejaOuvert = False And m_eMode = enumMode.MODE_INACTIF Then
80: m_bSansTemps = rstProjSoum.Fields("SansTemps").Value
			
85: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsDessin").Value) Then
90: txtTempsDessinSoum.Text = rstProjSoum.Fields("TempsDessin").Value
95: Else
100: txtTempsDessinSoum.Text = "0"
105: End If
			
110: If m_eType = enumType.TYPE_SOUMISSION Then
115: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsFabrication").Value) Then
120: lblTempsFabricationSoum.Text = rstProjSoum.Fields("TempsFabrication").Value
125: Else
130: lblTempsFabricationSoum.Text = "0"
135: End If
140: Else
145: lblTempsFabricationSoum.Text = CalculerTempsFabrication
150: End If
			
155: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsAssemblage").Value) Then
160: txtTempsAssemblageSoum.Text = rstProjSoum.Fields("TempsAssemblage").Value
165: Else
170: txtTempsAssemblageSoum.Text = "0"
175: End If
			
180: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsProgInterface").Value) Then
185: txtTempsProgInterfaceSoum.Text = rstProjSoum.Fields("TempsProgInterface").Value
190: Else
195: txtTempsProgInterfaceSoum.Text = "0"
200: End If
			
205: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsProgAutomate").Value) Then
210: txtTempsProgAutomateSoum.Text = rstProjSoum.Fields("TempsProgAutomate").Value
215: Else
220: txtTempsProgAutomateSoum.Text = "0"
225: End If
			
230: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsProgRobot").Value) Then
235: txtTempsProgRobotSoum.Text = rstProjSoum.Fields("TempsProgRobot").Value
240: Else
245: txtTempsProgRobotSoum.Text = "0"
250: End If
			
255: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsVision").Value) Then
260: txtTempsVisionSoum.Text = rstProjSoum.Fields("TempsVision").Value
265: Else
270: txtTempsVisionSoum.Text = "0"
275: End If
			
280: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsTest").Value) Then
285: txtTempsTestSoum.Text = rstProjSoum.Fields("TempsTest").Value
290: Else
295: txtTempsTestSoum.Text = "0"
300: End If
			
305: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsInstallation").Value) Then
310: txtTempsInstallationSoum.Text = rstProjSoum.Fields("TempsInstallation").Value
315: Else
320: txtTempsInstallationSoum.Text = "0"
325: End If
			
330: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsMiseService").Value) Then
335: txtTempsMiseServiceSoum.Text = rstProjSoum.Fields("TempsMiseService").Value
340: Else
345: txtTempsMiseServiceSoum.Text = "0"
350: End If
			
355: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsFormation").Value) Then
360: txtTempsFormationSoum.Text = rstProjSoum.Fields("TempsFormation").Value
365: Else
370: txtTempsFormationSoum.Text = "0"
375: End If
			
380: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsGestion").Value) Then
385: txtTempsGestionSoum.Text = rstProjSoum.Fields("TempsGestion").Value
390: Else
395: txtTempsGestionSoum.Text = "0"
400: End If
			
405: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsShipping").Value) Then
410: txtTempsShippingSoum.Text = rstProjSoum.Fields("TempsShipping").Value
415: Else
420: txtTempsShippingSoum.Text = "0"
425: End If
			txtTempsPrototypeSoum.Text = "0"
			
430: If m_bSansTemps = True Then
435: Croix1.Visible = True
440: Croix2.Visible = True
445: Else
450: Croix1.Visible = False
455: Croix2.Visible = False
460: End If
			
465: If VB.Right(m_sNoProjSoum, 2) <> "99" Then
470: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("NbrePersonne").Value) Then
475: txtNbrePersonne.Text = rstProjSoum.Fields("NbrePersonne").Value
480: Else
485: txtNbrePersonne.Text = "0"
490: End If
				
495: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsHebergement").Value) Then
500: txtTempsHebergement.Text = rstProjSoum.Fields("TempsHebergement").Value
505: Else
510: txtTempsHebergement.Text = "0"
515: End If
				
520: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsRepas").Value) Then
525: txtTempsRepas.Text = rstProjSoum.Fields("TempsRepas").Value
530: Else
535: txtTempsRepas.Text = "0"
540: End If
545: Else
550: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TotalHebergement").Value) Then
555: lblPrixHebergement.Text = rstProjSoum.Fields("TotalHebergement").Value
560: End If
				
565: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TotalRepas").Value) Then
570: lblPrixRepas.Text = rstProjSoum.Fields("TotalRepas").Value
575: End If
580: End If
			
585: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsTransport").Value) Then
590: txtTempsDeplacement.Text = rstProjSoum.Fields("TempsTransport").Value
595: Else
600: txtTempsDeplacement.Text = "0"
605: End If
			
610: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsUniteMobile").Value) Then
615: txtTempsUniteMobile.Text = rstProjSoum.Fields("TempsUniteMobile").Value
620: Else
625: txtTempsUniteMobile.Text = "0"
630: End If
			
635: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("PrixEmballage").Value) Then
640: txtPrixEmballage.Text = rstProjSoum.Fields("PrixEmballage").Value
645: Else
650: txtPrixEmballage.Text = "0"
655: End If
660: Else
665: If m_eType = enumType.TYPE_SOUMISSION Then
670: m_bSansTemps = FrmProjSoumElec.m_bSansTemps
				
675: txtTempsDessinSoum.Text = FrmProjSoumElec.m_sTempsDessin
680: lblTempsFabricationSoum.Text = FrmProjSoumElec.m_sTempsFabrication
685: txtTempsAssemblageSoum.Text = FrmProjSoumElec.m_sTempsAssemblage
690: txtTempsProgInterfaceSoum.Text = FrmProjSoumElec.m_sTempsProgInterface
695: txtTempsProgAutomateSoum.Text = FrmProjSoumElec.m_sTempsProgAutomate
700: txtTempsProgRobotSoum.Text = FrmProjSoumElec.m_sTempsProgRobot
705: txtTempsVisionSoum.Text = FrmProjSoumElec.m_sTempsVision
710: txtTempsTestSoum.Text = FrmProjSoumElec.m_sTempsTest
715: txtTempsInstallationSoum.Text = FrmProjSoumElec.m_sTempsInstallation
720: txtTempsMiseServiceSoum.Text = FrmProjSoumElec.m_sTempsMiseService
725: txtTempsFormationSoum.Text = FrmProjSoumElec.m_sTempsFormation
730: txtTempsGestionSoum.Text = FrmProjSoumElec.m_sTempsGestion
735: txtTempsShippingSoum.Text = FrmProjSoumElec.m_sTempsShipping
740: Else
745: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not rstProjSoum.EOF And Not IsDbNull(rstProjSoum.Fields("IDSoumission").Value) Then
750: If rstProjSoum.Fields("IDSoumission").Value <> "" Then
755: rstSoum = New ADODB.Recordset
						
760: Call rstSoum.Open("SELECT * FROM GRB_SoumissionElec WHERE IDSoumission = '" & rstProjSoum.Fields("IDSoumission").Value & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
						
765: If Not rstSoum.EOF Then
770: m_bSansTemps = FrmProjSoumElec.m_bSansTemps
							
775: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
							If Not IsDbNull(rstSoum.Fields("TempsDessin").Value) Then
780: txtTempsDessinSoum.Text = rstSoum.Fields("TempsDessin").Value
785: Else
790: txtTempsDessinSoum.Text = "0"
795: End If
							
800: If m_eType = enumType.TYPE_PROJET Then
805: lblTempsFabricationSoum.Text = CalculerTempsFabrication
810: Else
815: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
								If Not IsDbNull(rstSoum.Fields("TempsFabrication").Value) Then
820: lblTempsFabricationSoum.Text = rstSoum.Fields("TempsFabrication").Value
825: Else
830: lblTempsFabricationSoum.Text = "0"
835: End If
840: End If
							
845: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
							If Not IsDbNull(rstSoum.Fields("TempsAssemblage").Value) Then
850: txtTempsAssemblageSoum.Text = rstSoum.Fields("TempsAssemblage").Value
855: Else
860: txtTempsAssemblageSoum.Text = "0"
865: End If
							
870: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
							If Not IsDbNull(rstSoum.Fields("TempsProgInterface").Value) Then
875: txtTempsProgInterfaceSoum.Text = rstSoum.Fields("TempsProgInterface").Value
880: Else
885: txtTempsProgInterfaceSoum.Text = "0"
890: End If
							
895: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
							If Not IsDbNull(rstSoum.Fields("TempsProgAutomate").Value) Then
900: txtTempsProgAutomateSoum.Text = rstSoum.Fields("TempsProgAutomate").Value
905: Else
910: txtTempsProgAutomateSoum.Text = "0"
915: End If
							
920: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
							If Not IsDbNull(rstSoum.Fields("TempsProgRobot").Value) Then
925: txtTempsProgRobotSoum.Text = rstSoum.Fields("TempsProgRobot").Value
930: Else
935: txtTempsProgRobotSoum.Text = "0"
940: End If
							
945: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
							If Not IsDbNull(rstSoum.Fields("TempsVision").Value) Then
950: txtTempsVisionSoum.Text = rstSoum.Fields("TempsVision").Value
955: Else
960: txtTempsVisionSoum.Text = "0"
965: End If
							
970: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
							If Not IsDbNull(rstSoum.Fields("TempsTest").Value) Then
975: txtTempsTestSoum.Text = rstSoum.Fields("TempsTest").Value
980: Else
985: txtTempsTestSoum.Text = "0"
990: End If
							
995: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
							If Not IsDbNull(rstSoum.Fields("TempsInstallation").Value) Then
1000: txtTempsInstallationSoum.Text = rstSoum.Fields("TempsInstallation").Value
1005: Else
1010: txtTempsInstallationSoum.Text = "0"
1015: End If
							
1020: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
							If Not IsDbNull(rstSoum.Fields("TempsMiseService").Value) Then
1025: txtTempsMiseServiceSoum.Text = rstSoum.Fields("TempsMiseService").Value
1030: Else
1035: txtTempsMiseServiceSoum.Text = "0"
1040: End If
							
1045: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
							If Not IsDbNull(rstSoum.Fields("TempsFormation").Value) Then
1050: txtTempsFormationSoum.Text = rstSoum.Fields("TempsFormation").Value
1055: Else
1060: txtTempsFormationSoum.Text = "0"
1065: End If
							
1070: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
							If Not IsDbNull(rstSoum.Fields("TempsGestion").Value) Then
1075: txtTempsGestionSoum.Text = rstSoum.Fields("TempsGestion").Value
1080: Else
1085: txtTempsGestionSoum.Text = "0"
1090: End If
							
1095: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
							If Not IsDbNull(rstSoum.Fields("TempsShipping").Value) Then
1100: txtTempsShippingSoum.Text = rstSoum.Fields("TempsShipping").Value
1105: Else
1110: txtTempsShippingSoum.Text = "0"
1115: End If
1120: Else
1125: m_bSansTemps = False
							
1130: txtTempsDessinSoum.Text = "0"
1135: lblTempsFabricationSoum.Text = CalculerTempsFabrication
1140: txtTempsAssemblageSoum.Text = "0"
1145: txtTempsProgInterfaceSoum.Text = "0"
1150: txtTempsProgAutomateSoum.Text = "0"
1155: txtTempsProgRobotSoum.Text = "0"
1160: txtTempsVisionSoum.Text = "0"
1165: txtTempsTestSoum.Text = "0"
1170: txtTempsInstallationSoum.Text = "0"
1175: txtTempsMiseServiceSoum.Text = "0"
1180: txtTempsFormationSoum.Text = "0"
1185: txtTempsGestionSoum.Text = "0"
1190: txtTempsShippingSoum.Text = "0"
1195: End If
						
1200: Call rstSoum.Close()
1205: 'UPGRADE_NOTE: Object rstSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						rstSoum = Nothing
1210: Else
1215: m_bSansTemps = False
						
1220: txtTempsDessinSoum.Text = "0"
1225: lblTempsFabricationSoum.Text = CalculerTempsFabrication
1230: txtTempsAssemblageSoum.Text = "0"
1235: txtTempsProgInterfaceSoum.Text = "0"
1240: txtTempsProgAutomateSoum.Text = "0"
1245: txtTempsProgRobotSoum.Text = "0"
1250: txtTempsVisionSoum.Text = "0"
1255: txtTempsTestSoum.Text = "0"
1260: txtTempsInstallationSoum.Text = "0"
1265: txtTempsMiseServiceSoum.Text = "0"
1270: txtTempsFormationSoum.Text = "0"
1275: txtTempsGestionSoum.Text = "0"
1280: txtTempsShippingSoum.Text = "0"
1285: End If
1290: Else
1295: m_bSansTemps = False
					
1300: txtTempsDessinSoum.Text = "0"
1305: lblTempsFabricationSoum.Text = CalculerTempsFabrication
1310: txtTempsAssemblageSoum.Text = "0"
1315: txtTempsProgInterfaceSoum.Text = "0"
1320: txtTempsProgAutomateSoum.Text = "0"
1325: txtTempsProgRobotSoum.Text = "0"
1330: txtTempsVisionSoum.Text = "0"
1335: txtTempsTestSoum.Text = "0"
1340: txtTempsInstallationSoum.Text = "0"
1345: txtTempsMiseServiceSoum.Text = "0"
1350: txtTempsFormationSoum.Text = "0"
1355: txtTempsGestionSoum.Text = "0"
1360: txtTempsShippingSoum.Text = "0"
1365: End If
1370: End If
			
1375: If m_bSansTemps = True Then
1380: Croix1.Visible = True
1385: Croix2.Visible = True
1390: Else
1395: Croix1.Visible = False
1400: Croix2.Visible = False
1405: End If
			
1410: txtNbrePersonne.Text = FrmProjSoumElec.m_sNbrePersonne
1415: txtTempsHebergement.Text = FrmProjSoumElec.m_sTempsHebergement
1420: txtTempsRepas.Text = FrmProjSoumElec.m_sTempsRepas
1425: txtTempsDeplacement.Text = FrmProjSoumElec.m_sTempsTransport
1430: txtTempsUniteMobile.Text = FrmProjSoumElec.m_sTempsUniteMobile
1435: txtPrixEmballage.Text = FrmProjSoumElec.m_sPrixEmballage
1440: End If
		
1445: If m_eType = enumType.TYPE_PROJET Then
1450: Call AfficherTempsReels()
			
1455: Call CalculerTotalArgent()
1460: End If
		
1465: Call rstProjSoum.Close()
1470: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjSoum = Nothing
		
1475: Exit Sub
		
AfficherErreur: 
		
1480: Call AfficherErreur("frmProjSoumElecTemps", "AfficherEnregistrement", Err, Erl())
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
		
50: If VB.Right(m_sNoProjSoum, 2) = "99" Then
55: sFilterNoProjet = "LEFT(NoProjet, 6) = '" & VB.Left(m_sNoProjSoum, 6) & "'"
60: Else
65: sFilterNoProjet = "NoProjet = '" & m_sNoProjSoum & "'"
70: End If
		
75: rstPunch = New ADODB.Recordset
		
80: Call rstPunch.Open("SELECT Type, " & sTotal & " FROM GRB_Punch WHERE " & sFilterNoProjet & " And HeureFin is not null AND HeureDébut is not null GROUP BY Type", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
85: lblTempsDessinReel.Text = "0"
90: lblTempsFabricationReel.Text = "0"
95: lblTempsAssemblageReel.Text = "0"
100: lblTempsProgInterfaceReel.Text = "0"
105: lblTempsProgAutomateReel.Text = "0"
110: lblTempsProgRobotReel.Text = "0"
115: lblTempsVisionReel.Text = "0"
120: lblTempsTestReel.Text = "0"
125: lblTempsInstallationReel.Text = "0"
130: lblTempsMiseServiceReel.Text = "0"
135: lblTempsFormationReel.Text = "0"
140: lblTempsGestionReel.Text = "0"
145: lblTempsShippingReel.Text = "0"
		lblTempsPrototypeReel.Text = "0"
		
150: Do While Not rstPunch.EOF
155: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("Total").Value) Then
160: Select Case rstPunch.Fields("Type").Value
					Case "Dessin" : lblTempsDessinReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
165: Case "Fabrication" : lblTempsFabricationReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
170: Case "Assemblage" : lblTempsAssemblageReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
175: Case "ProgInterface" : lblTempsProgInterfaceReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
180: Case "ProgAutomate" : lblTempsProgAutomateReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
185: Case "ProgRobot" : lblTempsProgRobotReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
190: Case "Vision" : lblTempsVisionReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
195: Case "Test" : lblTempsTestReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
200: Case "Installation" : lblTempsInstallationReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
205: Case "MiseService" : lblTempsMiseServiceReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
210: Case "Formation" : lblTempsFormationReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
215: Case "Gestion" : lblTempsGestionReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
220: Case "Shipping" : lblTempsShippingReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
					Case "Prototypage-Dévelloppement expérimental" : lblTempsPrototypeReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
225: End Select
230: End If
			
235: Call rstPunch.MoveNext()
240: Loop 
		
245: Call rstPunch.Close()
		
		'Ouverture des enregistrements avec comme filtre, le numéro du projet
250: Call rstPunch.Open("SELECT " & sTotal & " FROM GRB_Punch WHERE " & sFilterNoProjet & " And HeureFin is not null AND HeureDébut is not null", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
255: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPunch.Fields("Total").Value) Then
260: lblTotalTempsRHReel.Text = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
265: Else
270: lblTotalTempsRHReel.Text = "0"
275: End If
		
280: Call rstPunch.Close()
285: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPunch = Nothing
		
290: Exit Sub
		
AfficherErreur: 
		
295: Call AfficherErreur("frmProjSoumElecTemps", "AfficherTempsReels", Err, Erl())
	End Sub
	
	Private Sub CalculerTotalArgent()
		
5: On Error GoTo AfficherErreur
		
10: If IsNumeric(lblTempsDessinReel.Text) Then
15: lblPrixDessin.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsDessinReel.Text) * CDbl(m_sTauxDessin)), ".", ",")), 2))
20: Else
25: lblPrixDessin.Text = CStr(0)
30: End If
		
35: If IsNumeric(lblTempsFabricationReel.Text) Then
40: lblPrixFabrication.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsFabricationReel.Text) * CDbl(m_sTauxFabrication)), ".", ",")), 2))
45: Else
50: lblPrixFabrication.Text = CStr(0)
55: End If
		
60: If IsNumeric(lblTempsAssemblageReel.Text) Then
65: lblPrixAssemblage.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsAssemblageReel.Text) * CDbl(m_sTauxAssemblage)), ".", ",")), 2))
70: Else
75: lblPrixAssemblage.Text = CStr(0)
80: End If
		
85: If IsNumeric(lblTempsProgInterfaceReel.Text) Then
90: lblPrixProgInterface.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsProgInterfaceReel.Text) * CDbl(m_sTauxProgInterface)), ".", ",")), 2))
95: Else
100: lblPrixProgInterface.Text = CStr(0)
105: End If
		
110: If IsNumeric(lblTempsProgAutomateReel.Text) Then
115: lblPrixProgAutomate.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsProgAutomateReel.Text) * CDbl(m_sTauxProgAutomate)), ".", ",")), 2))
120: Else
125: lblPrixProgAutomate.Text = CStr(0)
130: End If
		
135: If IsNumeric(lblTempsProgRobotReel.Text) Then
140: lblPrixProgRobot.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsProgRobotReel.Text) * CDbl(m_sTauxProgRobot)), ".", ",")), 2))
145: Else
150: lblPrixProgRobot.Text = CStr(0)
155: End If
		
160: If IsNumeric(lblTempsVisionReel.Text) Then
165: lblPrixVision.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsVisionReel.Text) * CDbl(m_sTauxVision)), ".", ",")), 2))
170: Else
175: lblPrixVision.Text = CStr(0)
180: End If
		
185: If IsNumeric(lblTempsTestReel.Text) Then
190: lblPrixTest.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsTestReel.Text) * CDbl(m_sTauxTest)), ".", ",")), 2))
195: Else
200: lblPrixTest.Text = CStr(0)
205: End If
		
210: If IsNumeric(lblTempsInstallationReel.Text) Then
215: lblPrixInstallation.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsInstallationReel.Text) * CDbl(m_sTauxInstallation)), ".", ",")), 2))
220: Else
225: lblPrixInstallation.Text = CStr(0)
230: End If
		
235: If IsNumeric(lblTempsMiseServiceReel.Text) Then
240: lblPrixMiseService.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsMiseServiceReel.Text) * CDbl(m_sTauxMiseService)), ".", ",")), 2))
245: Else
250: lblPrixMiseService.Text = CStr(0)
255: End If
		
260: If IsNumeric(lblTempsFormationReel.Text) Then
265: lblPrixFormation.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsFormationReel.Text) * CDbl(m_sTauxFormation)), ".", ",")), 2))
270: Else
275: lblPrixFormation.Text = CStr(0)
280: End If
		
285: If IsNumeric(lblTempsGestionReel.Text) Then
290: lblPrixGestion.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsGestionReel.Text) * CDbl(m_sTauxGestion)), ".", ",")), 2))
295: Else
300: lblPrixGestion.Text = CStr(0)
305: End If
		
310: If IsNumeric(lblTempsShippingReel.Text) Then
315: lblPrixShipping.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsShippingReel.Text) * CDbl(m_sTauxShipping)), ".", ",")), 2))
320: Else
325: lblPrixShipping.Text = CStr(0)
330: End If
		
		If IsNumeric(lblTempsPrototypeReel.Text) Then
331: lblPrixPrototype.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsPrototypeReel.Text) * CDbl(m_sTauxGestion)), ".", ",")), 2))
332: Else
333: lblPrixPrototype.Text = CStr(0)
334: End If
		
		
		
		
		
		
335: Call CalculerTotal()
		
340: Exit Sub
		
AfficherErreur: 
		
345: Call AfficherErreur("frmProjSoumElecTemps", "CalculerTotalArgent", Err, Erl())
	End Sub
	
	Private Sub BarrerChamps(ByVal bLocked As Boolean)
		
5: On Error GoTo AfficherErreur
		
10: txtTempsDessinSoum.ReadOnly = bLocked
15: txtTempsAssemblageSoum.ReadOnly = bLocked
20: txtTempsProgInterfaceSoum.ReadOnly = bLocked
25: txtTempsProgAutomateSoum.ReadOnly = bLocked
30: txtTempsProgRobotSoum.ReadOnly = bLocked
35: txtTempsVisionSoum.ReadOnly = bLocked
40: txtTempsTestSoum.ReadOnly = bLocked
45: txtTempsInstallationSoum.ReadOnly = bLocked
50: txtTempsMiseServiceSoum.ReadOnly = bLocked
55: txtTempsFormationSoum.ReadOnly = bLocked
60: txtTempsGestionSoum.ReadOnly = bLocked
65: txtTempsShippingSoum.ReadOnly = bLocked
		
70: txtNbrePersonne.ReadOnly = bLocked
75: txtTempsHebergement.ReadOnly = bLocked
80: txtTempsRepas.ReadOnly = bLocked
85: txtTempsDeplacement.ReadOnly = bLocked
90: txtTempsUniteMobile.ReadOnly = bLocked
		
95: txtPrixEmballage.ReadOnly = bLocked
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmProjSoumElecTemps", "BarrerChamps", Err, Erl())
	End Sub
	
	Private Sub cmdDetail_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDetail.Click
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_PROJET Then
15: Call frmDetailTemps.Afficher(m_sNoProjSoum, ModuleMain.enumCatalogue.ELECTRIQUE, True)
20: Else
25: Call frmDetailTemps.Afficher(m_sNoProjSoum, ModuleMain.enumCatalogue.ELECTRIQUE, False)
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmProjSoumElecTemps", "cmdDetail_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
10: If m_eMode = enumMode.MODE_AJOUT_MODIF Then
15: Call EnregistrerTemps()
20: End If
		
25: Call Me.Close()
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmProjSoumElecTemps", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub EnregistrerTemps()
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If Trim(txtTempsDessinSoum.Text) <> vbNullString And IsNumeric(txtTempsDessinSoum.Text) Then
20: FrmProjSoumElec.m_sTempsDessin = txtTempsDessinSoum.Text
25: Else
30: FrmProjSoumElec.m_sTempsDessin = "0"
35: End If
			
40: If Trim(lblTempsFabricationSoum.Text) <> vbNullString Then
45: FrmProjSoumElec.m_sTempsFabrication = lblTempsFabricationSoum.Text
50: Else
55: FrmProjSoumElec.m_sTempsFabrication = "0"
60: End If
			
65: If Trim(txtTempsAssemblageSoum.Text) <> vbNullString And IsNumeric(txtTempsAssemblageSoum.Text) Then
70: FrmProjSoumElec.m_sTempsAssemblage = txtTempsAssemblageSoum.Text
75: Else
80: FrmProjSoumElec.m_sTempsAssemblage = "0"
85: End If
			
90: If Trim(txtTempsProgInterfaceSoum.Text) <> vbNullString And IsNumeric(txtTempsProgInterfaceSoum.Text) Then
95: FrmProjSoumElec.m_sTempsProgInterface = txtTempsProgInterfaceSoum.Text
100: Else
105: FrmProjSoumElec.m_sTempsProgInterface = "0"
110: End If
			
115: If Trim(txtTempsProgAutomateSoum.Text) <> vbNullString And IsNumeric(txtTempsProgAutomateSoum.Text) Then
120: FrmProjSoumElec.m_sTempsProgAutomate = txtTempsProgAutomateSoum.Text
125: Else
130: FrmProjSoumElec.m_sTempsProgAutomate = "0"
135: End If
			
140: If Trim(txtTempsProgRobotSoum.Text) <> vbNullString And IsNumeric(txtTempsProgRobotSoum.Text) Then
145: FrmProjSoumElec.m_sTempsProgRobot = txtTempsProgRobotSoum.Text
150: Else
155: FrmProjSoumElec.m_sTempsProgRobot = "0"
160: End If
			
165: If Trim(txtTempsVisionSoum.Text) <> vbNullString And IsNumeric(txtTempsVisionSoum.Text) Then
170: FrmProjSoumElec.m_sTempsVision = txtTempsVisionSoum.Text
175: Else
180: FrmProjSoumElec.m_sTempsVision = "0"
185: End If
			
190: If Trim(txtTempsTestSoum.Text) <> vbNullString And IsNumeric(txtTempsTestSoum.Text) Then
195: FrmProjSoumElec.m_sTempsTest = txtTempsTestSoum.Text
200: Else
205: FrmProjSoumElec.m_sTempsTest = "0"
210: End If
			
215: If Trim(txtTempsInstallationSoum.Text) <> vbNullString And IsNumeric(txtTempsInstallationSoum.Text) Then
220: FrmProjSoumElec.m_sTempsInstallation = txtTempsInstallationSoum.Text
225: Else
230: FrmProjSoumElec.m_sTempsInstallation = "0"
235: End If
			
240: If Trim(txtTempsMiseServiceSoum.Text) <> vbNullString And IsNumeric(txtTempsMiseServiceSoum.Text) Then
245: FrmProjSoumElec.m_sTempsMiseService = txtTempsMiseServiceSoum.Text
250: Else
255: FrmProjSoumElec.m_sTempsMiseService = "0"
260: End If
			
265: If Trim(txtTempsFormationSoum.Text) <> vbNullString And IsNumeric(txtTempsFormationSoum.Text) Then
270: FrmProjSoumElec.m_sTempsFormation = txtTempsFormationSoum.Text
275: Else
280: FrmProjSoumElec.m_sTempsFormation = "0"
285: End If
			
290: If Trim(txtTempsGestionSoum.Text) <> vbNullString And IsNumeric(txtTempsGestionSoum.Text) Then
295: FrmProjSoumElec.m_sTempsGestion = txtTempsGestionSoum.Text
300: Else
305: FrmProjSoumElec.m_sTempsGestion = "0"
310: End If
			
315: If Trim(txtTempsShippingSoum.Text) <> vbNullString And IsNumeric(txtTempsShippingSoum.Text) Then
320: FrmProjSoumElec.m_sTempsShipping = txtTempsShippingSoum.Text
325: Else
330: FrmProjSoumElec.m_sTempsShipping = "0"
335: End If
340: End If
		
		
345: If m_bSansTemps = True Then
350: FrmProjSoumElec.m_bSansTemps = True
355: FrmProjSoumElec.tmrTemps.Enabled = True
360: Else
365: FrmProjSoumElec.m_bSansTemps = False
370: FrmProjSoumElec.tmrTemps.Enabled = False
375: FrmProjSoumElec.lblPasTemps.Visible = False
380: End If
		
385: If Trim(txtNbrePersonne.Text) <> vbNullString And IsNumeric(txtNbrePersonne.Text) Then
390: FrmProjSoumElec.m_sNbrePersonne = txtNbrePersonne.Text
395: Else
400: FrmProjSoumElec.m_sNbrePersonne = "0"
405: End If
		
410: If Trim(txtTempsHebergement.Text) <> vbNullString And IsNumeric(txtTempsHebergement.Text) Then
415: FrmProjSoumElec.m_sTempsHebergement = txtTempsHebergement.Text
420: Else
425: FrmProjSoumElec.m_sTempsHebergement = "0"
430: End If
		
435: If Trim(txtTempsRepas.Text) <> vbNullString And IsNumeric(txtTempsRepas.Text) Then
440: FrmProjSoumElec.m_sTempsRepas = txtTempsRepas.Text
445: Else
450: FrmProjSoumElec.m_sTempsRepas = "0"
455: End If
		
460: If Trim(txtTempsDeplacement.Text) <> vbNullString And IsNumeric(txtTempsDeplacement.Text) Then
465: FrmProjSoumElec.m_sTempsTransport = txtTempsDeplacement.Text
470: Else
475: FrmProjSoumElec.m_sTempsTransport = "0"
480: End If
		
485: If Trim(txtTempsUniteMobile.Text) <> vbNullString And IsNumeric(txtTempsUniteMobile.Text) Then
490: FrmProjSoumElec.m_sTempsUniteMobile = txtTempsUniteMobile.Text
495: Else
500: FrmProjSoumElec.m_sTempsUniteMobile = "0"
505: End If
		
510: If Trim(txtPrixEmballage.Text) <> vbNullString And IsNumeric(txtPrixEmballage.Text) Then
515: FrmProjSoumElec.m_sPrixEmballage = txtPrixEmballage.Text
520: Else
525: FrmProjSoumElec.m_sPrixEmballage = "0"
530: End If
		
535: FrmProjSoumElec.m_sTauxHebergement1 = m_sHebergement1
540: FrmProjSoumElec.m_sTauxHebergement2 = m_sHebergement2
545: FrmProjSoumElec.m_sTauxRepas = m_sRepas
550: FrmProjSoumElec.m_sTauxTransport = m_sStandard
555: FrmProjSoumElec.m_sTauxUniteMobile = m_sUniteMobile
		
560: Exit Sub
		
AfficherErreur: 
		
565: Call AfficherErreur("frmProjSoumElecTemps", "EnregistrerTemps", Err, Erl())
	End Sub
	
	Private Sub InitialiserVariablesConfig()
		
5: On Error GoTo AfficherErreur
		
		'Initialise les variables à partir de la table Config (Pour avoir le taux
		'horaire le plus récent)
10: Dim rstConfig As ADODB.Recordset
		
15: rstConfig = New ADODB.Recordset
		
20: Call rstConfig.Open("SELECT TauxDessinElec, TauxFabrication, TauxAssemblageElec, TauxProgInterface, TauxProgAutomate, TauxProgRobot, TauxVision, TauxTestElec, TauxInstallationElec, TauxMiseService, TauxFormationElec, TauxGestionProjetsElec, TauxShippingElec, Repas, Hebergement1, Hebergement2, Standard, UniteMobile FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxDessinElec").Value) Then
30: m_sTauxDessin = rstConfig.Fields("TauxDessinElec").Value
35: Else
40: m_sTauxDessin = "0"
45: End If
		
50: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxFabrication").Value) Then
55: m_sTauxFabrication = rstConfig.Fields("TauxFabrication").Value
60: Else
65: m_sTauxFabrication = "0"
70: End If
		
75: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxAssemblageElec").Value) Then
80: m_sTauxAssemblage = rstConfig.Fields("TauxAssemblageElec").Value
85: Else
90: m_sTauxAssemblage = "0"
95: End If
		
100: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxProgInterface").Value) Then
105: m_sTauxProgInterface = rstConfig.Fields("TauxProgInterface").Value
110: Else
115: m_sTauxProgInterface = "0"
120: End If
		
125: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxProgAutomate").Value) Then
130: m_sTauxProgAutomate = rstConfig.Fields("TauxProgAutomate").Value
135: Else
140: m_sTauxProgAutomate = "0"
145: End If
		
150: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxProgRobot").Value) Then
155: m_sTauxProgRobot = rstConfig.Fields("TauxProgRobot").Value
160: Else
165: m_sTauxProgRobot = "0"
170: End If
		
175: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxVision").Value) Then
180: m_sTauxVision = rstConfig.Fields("TauxVision").Value
185: Else
190: m_sTauxVision = "0"
195: End If
		
200: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxTestElec").Value) Then
205: m_sTauxTest = rstConfig.Fields("TauxTestElec").Value
210: Else
215: m_sTauxTest = "0"
220: End If
		
225: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxInstallationElec").Value) Then
230: m_sTauxInstallation = rstConfig.Fields("TauxInstallationElec").Value
235: Else
240: m_sTauxInstallation = "0"
245: End If
		
250: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxMiseService").Value) Then
255: m_sTauxMiseService = rstConfig.Fields("TauxMiseService").Value
260: Else
265: m_sTauxMiseService = "0"
270: End If
		
275: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxFormationElec").Value) Then
280: m_sTauxFormation = rstConfig.Fields("TauxFormationElec").Value
285: Else
290: m_sTauxFormation = "0"
295: End If
		
300: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxGestionProjetsElec").Value) Then
305: m_sTauxGestion = rstConfig.Fields("TauxGestionProjetsElec").Value
310: Else
315: m_sTauxGestion = "0"
320: End If
		
325: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("TauxShippingElec").Value) Then
330: m_sTauxShipping = rstConfig.Fields("TauxShippingElec").Value
335: Else
340: m_sTauxShipping = "0"
345: End If
		
350: m_sRepas = rstConfig.Fields("Repas").Value
355: m_sHebergement1 = rstConfig.Fields("Hebergement1").Value
360: m_sHebergement2 = rstConfig.Fields("Hebergement2").Value
365: m_sStandard = rstConfig.Fields("Standard").Value
370: m_sUniteMobile = rstConfig.Fields("UniteMobile").Value
		
375: Call rstConfig.Close()
380: 'UPGRADE_NOTE: Object rstConfig may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstConfig = Nothing
		
385: Exit Sub
		
AfficherErreur: 
		
390: Call AfficherErreur("frmProjSoumElecTemps", "InitialiserVariablesConfig", Err, Erl())
	End Sub
	
	Private Sub InitialiserVariablesProjSoum()
		
5: On Error GoTo AfficherErreur
		
10: m_sTauxDessin = FrmProjSoumElec.m_sTauxDessin
15: m_sTauxFabrication = FrmProjSoumElec.m_sTauxFabrication
20: m_sTauxAssemblage = FrmProjSoumElec.m_sTauxAssemblage
25: m_sTauxProgInterface = FrmProjSoumElec.m_sTauxProgInterface
30: m_sTauxProgAutomate = FrmProjSoumElec.m_sTauxProgAutomate
35: m_sTauxProgRobot = FrmProjSoumElec.m_sTauxProgRobot
40: m_sTauxVision = FrmProjSoumElec.m_sTauxVision
45: m_sTauxTest = FrmProjSoumElec.m_sTauxTest
50: m_sTauxInstallation = FrmProjSoumElec.m_sTauxInstallation
55: m_sTauxMiseService = FrmProjSoumElec.m_sTauxMiseService
60: m_sTauxFormation = FrmProjSoumElec.m_sTauxFormation
65: m_sTauxGestion = FrmProjSoumElec.m_sTauxGestion
70: m_sTauxShipping = FrmProjSoumElec.m_sTauxShipping
		
75: m_sRepas = FrmProjSoumElec.m_sTauxRepas
80: m_sHebergement1 = FrmProjSoumElec.m_sTauxHebergement1
85: m_sHebergement2 = FrmProjSoumElec.m_sTauxHebergement2
90: m_sStandard = FrmProjSoumElec.m_sTauxTransport
95: m_sUniteMobile = FrmProjSoumElec.m_sTauxUniteMobile
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmProjSoumElecTemps", "InitialiserVariablesProjSoum", Err, Erl())
	End Sub
	
	Private Sub frmProjSoumElecTemps_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: If FrmProjSoumElec.m_bDroitPrix = False Then
15: Me.Width = VB6.TwipsToPixelsX(3765)
20: cmdFermer.Left = VB6.TwipsToPixelsX(2280)
25: Else
30: Me.Width = VB6.TwipsToPixelsX(11115)
35: cmdFermer.Left = VB6.TwipsToPixelsX(9480)
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmProjSoumElecTemps", "Form_Load", Err, Erl())
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
		
50: Call AfficherErreur("frmProjSoumElecTemps", "txtNbrePersonne_Change", Err, Erl())
	End Sub
	
	Private Sub txtPrixEmballage_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPrixEmballage.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
5: On Error GoTo AfficherErreur
		
10: If KeyAscii = 46 Then 'Si c'est le "."
15: KeyAscii = 44 'Remplace par la ","
20: End If
		
25: GoTo EventExitSub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmProjSoumElecTemps", "lblPrixEmballage_KeyPress", Err, Erl())
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
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
		
45: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsHebergement_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsHebergement_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsHebergement.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsHebergement.Text = Replace(txtTempsHebergement.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsHebergement_LostFocus", Err, Erl())
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
		
45: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsRepas_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsRepas_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsRepas.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsRepas.Text = Replace(txtTempsRepas.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsRepas_LostFocus", Err, Erl())
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
		
45: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsDeplacement_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsDeplacement_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsDeplacement.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsDeplacement.Text = Replace(txtTempsDeplacement.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsDeplacement_LostFocus", Err, Erl())
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
		
45: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsUniteMobile_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsUniteMobile_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsUniteMobile.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsUniteMobile.Text = Replace(txtTempsUniteMobile.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsUniteMobile_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtPrixEmballage.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtPrixEmballage_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrixEmballage.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerTotal()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumElecTemps", "lblPrixEmballage_Change", Err, Erl())
	End Sub
	
	Private Sub txtPrixEmballage_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrixEmballage.Leave
		
5: On Error GoTo AfficherErreur
		
10: If IsNumeric(txtPrixEmballage.Text) Then
15: txtPrixEmballage.Text = CStr(System.Math.Round(CDbl(Replace(txtPrixEmballage.Text, ".", ",")), 2))
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmProjSoumElecTemps", "lblPrixEmballage_LostFocus", Err, Erl())
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
		
55: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsDessinSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsDessinSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsDessinSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsDessinSoum.Text = Replace(txtTempsDessinSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsDessinSoum_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_ISSUE: Label event lblTempsFabricationSoum.Change was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub lblTempsFabricationSoum_Change()
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If m_bSansTemps = False Then
20: If IsNumeric(lblTempsFabricationSoum.Text) Then
25: lblPrixFabrication.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(lblTempsFabricationSoum.Text) * CDbl(m_sTauxFabrication)), ".", ",")), 2))
30: Else
35: lblPrixFabrication.Text = "0"
40: End If
45: Else
50: lblPrixFabrication.Text = "0"
55: End If
			
60: Call CalculerTotal()
65: End If
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsMécanique_Change", Err, Erl())
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
		
55: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsAssemblageSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsAssemblageSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsAssemblageSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsAssemblageSoum.Text = Replace(txtTempsAssemblageSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsAssemblageSoum_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsProgInterfaceSoum.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsProgInterfaceSoum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsProgInterfaceSoum.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If IsNumeric(txtTempsProgInterfaceSoum.Text) Then
20: lblPrixProgInterface.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsProgInterfaceSoum.Text) * CDbl(m_sTauxProgInterface)), ".", ",")), 2))
25: Else
30: lblPrixProgInterface.Text = CStr(0)
35: End If
			
40: Call CalculerTotal()
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsProgInterfaceSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsProgInterfaceSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsProgInterfaceSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsProgInterfaceSoum.Text = Replace(txtTempsProgInterfaceSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsProgInterfaceSoum_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsProgAutomateSoum.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsProgAutomateSoum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsProgAutomateSoum.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If IsNumeric(txtTempsProgAutomateSoum.Text) Then
20: lblPrixProgAutomate.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsProgAutomateSoum.Text) * CDbl(m_sTauxProgAutomate)), ".", ",")), 2))
25: Else
30: lblPrixProgAutomate.Text = CStr(0)
35: End If
			
40: Call CalculerTotal()
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsProgAutomate_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsProgAutomateSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsProgAutomateSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsProgAutomateSoum.Text = Replace(txtTempsProgAutomateSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsProgAutomate_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsProgRobotSoum.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsProgRobotSoum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsProgRobotSoum.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If IsNumeric(txtTempsProgRobotSoum.Text) Then
20: lblPrixProgRobot.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsProgRobotSoum.Text) * CDbl(m_sTauxProgRobot)), ".", ",")), 2))
25: Else
30: lblPrixProgRobot.Text = CStr(0)
35: End If
			
40: Call CalculerTotal()
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsProgRobotSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsProgRobotSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsProgRobotSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsProgRobotSoum.Text = Replace(txtTempsProgRobotSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsProgRobotSoum_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsVisionSoum.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsVisionSoum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsVisionSoum.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If IsNumeric(txtTempsVisionSoum.Text) Then
20: lblPrixVision.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsVisionSoum.Text) * CDbl(m_sTauxVision)), ".", ",")), 2))
25: Else
30: lblPrixVision.Text = CStr(0)
35: End If
			
40: Call CalculerTotal()
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsVisionSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsVisionSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsVisionSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsVisionSoum.Text = Replace(txtTempsVisionSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsVisionSoum_LostFocus", Err, Erl())
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
		
55: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsTestSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsTestSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsTestSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsTestSoum.Text = Replace(txtTempsTestSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsTestSoum_LostFocus", Err, Erl())
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
		
55: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsInstallationSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsInstallationSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsInstallationSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsInstallationSoum.Text = Replace(txtTempsInstallationSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsInstallationSoum_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtTempsMiseServiceSoum.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtTempsMiseServiceSoum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsMiseServiceSoum.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_SOUMISSION Then
15: If IsNumeric(txtTempsMiseServiceSoum.Text) Then
20: lblPrixMiseService.Text = CStr(System.Math.Round(CDbl(Replace(CStr(CDbl(txtTempsMiseServiceSoum.Text) * CDbl(m_sTauxMiseService)), ".", ",")), 2))
25: Else
30: lblPrixMiseService.Text = CStr(0)
35: End If
			
40: Call CalculerTotal()
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsMiseServiceSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsMiseServiceSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsMiseServiceSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsMiseServiceSoum.Text = Replace(txtTempsMiseServiceSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsMiseServiceSoum_LostFocus", Err, Erl())
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
		
55: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsFormationSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsFormationSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsFormationSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsFormationSoum.Text = Replace(txtTempsFormationSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsFormationSoum_LostFocus", Err, Erl())
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
		
55: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsGestionSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsGestionSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsGestionSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsGestionSoum.Text = Replace(txtTempsGestionSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsGestionSoum_LostFocus", Err, Erl())
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
		
55: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsShippingSoum_Change", Err, Erl())
	End Sub
	
	Private Sub txtTempsShippingSoum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTempsShippingSoum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtTempsShippingSoum.Text = Replace(txtTempsShippingSoum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmProjSoumElecTemps", "txtTempsShippingSoum_LostFocus", Err, Erl())
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
		
110: Call AfficherErreur("frmProjSoumElecTemps", "CalculerHebergement", Err, Erl())
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
		
90: Call AfficherErreur("frmProjSoumElecTemps", "CalculerRepas", Err, Erl())
	End Sub
	
	Private Sub CalculerTotal()
		
5: On Error GoTo AfficherErreur
		
10: Dim dblTotal As Double
15: Dim dblPrixEmballage As Double
20: Dim dblTotalArgentRH As Double
25: Dim dblPrixDessin As Double
30: Dim dblPrixFabrication As Double
35: Dim dblPrixAssemblage As Double
40: Dim dblPrixProgInterface As Double
45: Dim dblPrixProgAutomate As Double
50: Dim dblPrixProgRobot As Double
55: Dim dblPrixVision As Double
60: Dim dblPrixTest As Double
65: Dim dblPrixInstallation As Double
70: Dim dblPrixMiseService As Double
75: Dim dblPrixFormation As Double
80: Dim dblPrixGestion As Double
85: Dim dblPrixShipping As Double
		Dim dblPrixPrototype As Double
90: Dim dblPrixHebergement As Double
95: Dim dblPrixRepas As Double
100: Dim dblPrixDeplacement As Double
105: Dim dblPrixUniteMobile As Double
		
		'Prix de dessin
110: If IsNumeric(lblPrixDessin.Text) Then
115: dblPrixDessin = CDbl(lblPrixDessin.Text)
120: Else
125: dblPrixDessin = 0
130: End If
		
		'Prix de Fabrication
135: If IsNumeric(lblPrixFabrication.Text) Then
140: dblPrixFabrication = CDbl(lblPrixFabrication.Text)
145: Else
150: dblPrixFabrication = 0
155: End If
		
		'Prix de Assemblage
160: If IsNumeric(lblPrixAssemblage.Text) Then
165: dblPrixAssemblage = CDbl(lblPrixAssemblage.Text)
170: Else
175: dblPrixAssemblage = 0
180: End If
		
		'Prix de ProgInterface
185: If IsNumeric(lblPrixProgInterface.Text) Then
190: dblPrixProgInterface = CDbl(lblPrixProgInterface.Text)
195: Else
200: dblPrixProgInterface = 0
205: End If
		
		'Prix de ProgAutomate
210: If IsNumeric(lblPrixProgAutomate.Text) Then
215: dblPrixProgAutomate = CDbl(lblPrixProgAutomate.Text)
220: Else
225: dblPrixProgAutomate = 0
230: End If
		
		'Prix de ProgRobot
235: If IsNumeric(lblPrixProgRobot.Text) Then
240: dblPrixProgRobot = CDbl(lblPrixProgRobot.Text)
245: Else
250: dblPrixProgRobot = 0
255: End If
		
		'Prix de vision
260: If IsNumeric(lblPrixVision.Text) Then
265: dblPrixVision = CDbl(lblPrixVision.Text)
270: Else
275: dblPrixVision = 0
280: End If
		
		'Prix de test
285: If IsNumeric(lblPrixTest.Text) Then
290: dblPrixTest = CDbl(lblPrixTest.Text)
295: Else
300: dblPrixTest = 0
305: End If
		
		'Prix de Installation
310: If IsNumeric(lblPrixInstallation.Text) Then
315: dblPrixInstallation = CDbl(lblPrixInstallation.Text)
320: Else
325: dblPrixInstallation = 0
330: End If
		
		'Prix de MiseService
335: If IsNumeric(lblPrixMiseService.Text) Then
340: dblPrixMiseService = CDbl(lblPrixMiseService.Text)
345: Else
350: dblPrixMiseService = 0
355: End If
		
		'Prix de formation
360: If IsNumeric(lblPrixFormation.Text) Then
365: dblPrixFormation = CDbl(lblPrixFormation.Text)
370: Else
375: dblPrixFormation = 0
380: End If
		
		'Prix de Gestion
385: If IsNumeric(lblPrixGestion.Text) Then
390: dblPrixGestion = CDbl(lblPrixGestion.Text)
395: Else
400: dblPrixGestion = 0
405: End If
		
		'Prix de Shipping
410: If IsNumeric(lblPrixShipping.Text) Then
415: dblPrixShipping = CDbl(lblPrixShipping.Text)
420: Else
425: dblPrixShipping = 0
430: End If
		
		
		'Prix de Prototype
431: If IsNumeric(lblPrixPrototype.Text) Then
432: dblPrixPrototype = CDbl(lblPrixPrototype.Text)
433: Else
434: dblPrixPrototype = 0
435: End If
		
		
		
		'Prix d'hébergement
436: If IsNumeric(lblPrixHebergement.Text) Then
440: dblPrixHebergement = CDbl(lblPrixHebergement.Text)
445: Else
450: dblPrixHebergement = 0
455: End If
		
		'Prix des repas
460: If IsNumeric(lblPrixRepas.Text) Then
465: dblPrixRepas = CDbl(lblPrixRepas.Text)
470: Else
475: dblPrixRepas = 0
480: End If
		
		'Prix du déplacement
485: If IsNumeric(lblPrixDeplacement.Text) Then
490: dblPrixDeplacement = CDbl(lblPrixDeplacement.Text)
495: Else
500: dblPrixDeplacement = 0
505: End If
		
		'Prix de l'unité mobile
510: If IsNumeric(lblPrixUniteMobile.Text) Then
515: dblPrixUniteMobile = CDbl(lblPrixUniteMobile.Text)
520: Else
525: dblPrixUniteMobile = 0
530: End If
		
		'Prix de transport et emballage
535: If IsNumeric(txtPrixEmballage.Text) Then
540: dblPrixEmballage = CDbl(txtPrixEmballage.Text)
545: Else
550: dblPrixEmballage = 0
555: End If
		
560: dblTotalArgentRH = dblPrixDessin + dblPrixFabrication + dblPrixAssemblage + dblPrixProgInterface + dblPrixProgAutomate + dblPrixProgRobot + dblPrixVision + dblPrixTest + dblPrixInstallation + dblPrixMiseService + dblPrixFormation + dblPrixGestion + dblPrixShipping + dblPrixPrototype
		
565: lblTotalPrixRH.Text = Conversion_Renamed(CStr(dblTotalArgentRH), ModuleMain.enumConvert.MODE_DECIMAL)
		
570: dblTotal = dblTotalArgentRH + dblPrixHebergement + dblPrixRepas + dblPrixDeplacement + dblPrixUniteMobile + dblPrixEmballage
		
575: lblTotal.Text = Conversion_Renamed(CStr(dblTotal), ModuleMain.enumConvert.MODE_DECIMAL)
		
580: Call CalculerTotalTemps()
		
585: Exit Sub
		
AfficherErreur: 
		
590: Call AfficherErreur("frmProjSoumElecTemps", "CalculerTotal", Err, Erl())
	End Sub
	
	Private Sub CalculerTotalTemps()
		
		
5: On Error GoTo AfficherErreur
		
10: Dim dblTempsDessin As Double
15: Dim dblTempsFabrication As Double
20: Dim dblTempsAssemblage As Double
25: Dim dblTempsProgInterface As Double
30: Dim dblTempsProgAutomate As Double
35: Dim dblTempsProgRobot As Double
40: Dim dblTempsVision As Double
45: Dim dblTempsTest As Double
50: Dim dblTempsInstallation As Double
55: Dim dblTempsMiseService As Double
60: Dim dblTempsFormation As Double
65: Dim dblTempsGestion As Double
70: Dim dblTempsShipping As Double
		Dim dblTempsPrototype As Double
75: Dim dblTotalTemps As Double
		
		'SOUMISSION
80: If IsNumeric(txtTempsDessinSoum.Text) Then
85: dblTempsDessin = CDbl(txtTempsDessinSoum.Text)
90: Else
95: dblTempsDessin = 0
100: End If
		
105: If m_bSansTemps = False Then
110: If IsNumeric(lblTempsFabricationSoum.Text) Then
115: dblTempsFabrication = CDbl(lblTempsFabricationSoum.Text)
120: Else
125: dblTempsFabrication = 0
130: End If
135: Else
140: dblTempsFabrication = 0
145: End If
		
150: If IsNumeric(txtTempsAssemblageSoum.Text) Then
155: dblTempsAssemblage = CDbl(txtTempsAssemblageSoum.Text)
160: Else
165: dblTempsAssemblage = 0
170: End If
		
175: If IsNumeric(txtTempsProgInterfaceSoum.Text) Then
180: dblTempsProgInterface = CDbl(txtTempsProgInterfaceSoum.Text)
185: Else
190: dblTempsProgInterface = 0
195: End If
		
200: If IsNumeric(txtTempsProgAutomateSoum.Text) Then
205: dblTempsProgAutomate = CDbl(txtTempsProgAutomateSoum.Text)
210: Else
215: dblTempsProgAutomate = 0
220: End If
		
225: If IsNumeric(txtTempsProgRobotSoum.Text) Then
230: dblTempsProgRobot = CDbl(txtTempsProgRobotSoum.Text)
235: Else
240: dblTempsProgRobot = 0
245: End If
		
250: If IsNumeric(txtTempsVisionSoum.Text) Then
255: dblTempsVision = CDbl(txtTempsVisionSoum.Text)
260: Else
265: dblTempsVision = 0
270: End If
		
275: If IsNumeric(txtTempsTestSoum.Text) Then
280: dblTempsTest = CDbl(txtTempsTestSoum.Text)
285: Else
290: dblTempsTest = 0
295: End If
		
300: If IsNumeric(txtTempsInstallationSoum.Text) Then
305: dblTempsInstallation = CDbl(txtTempsInstallationSoum.Text)
310: Else
315: dblTempsInstallation = 0
320: End If
		
325: If IsNumeric(txtTempsMiseServiceSoum.Text) Then
330: dblTempsMiseService = CDbl(txtTempsMiseServiceSoum.Text)
335: Else
340: dblTempsMiseService = 0
345: End If
		
350: If IsNumeric(txtTempsFormationSoum.Text) Then
355: dblTempsFormation = CDbl(txtTempsFormationSoum.Text)
360: Else
365: dblTempsFormation = 0
370: End If
		
375: If IsNumeric(txtTempsGestionSoum.Text) Then
380: dblTempsGestion = CDbl(txtTempsGestionSoum.Text)
385: Else
390: dblTempsGestion = 0
395: End If
		
400: If IsNumeric(txtTempsShippingSoum.Text) Then
405: dblTempsShipping = CDbl(txtTempsShippingSoum.Text)
410: Else
415: dblTempsShipping = 0
420: End If
		
		
		If IsNumeric(txtTempsPrototypeSoum.Text) Then
421: dblTempsPrototype = CDbl(txtTempsPrototypeSoum.Text)
422: Else
423: dblTempsPrototype = 0
424: End If
		
425: dblTotalTemps = dblTempsDessin + dblTempsFabrication + dblTempsAssemblage + dblTempsProgInterface + dblTempsProgAutomate + dblTempsProgRobot + dblTempsVision + dblTempsTest + dblTempsInstallation + dblTempsMiseService + dblTempsFormation + dblTempsGestion + dblTempsShipping + dblTempsPrototype
		
430: lblTotalTempsRHSoum.Text = Conversion_Renamed(dblTotalTemps, ModuleMain.enumConvert.MODE_DECIMAL)
		
435: Exit Sub
		
AfficherErreur: 
		
440: Call AfficherErreur("frmProjSoumElecTemps", "CalculerTotalTemps", Err, Erl())
	End Sub
	
	Private Sub lblTempsFabricationSoum_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lblTempsFabricationSoum.Click
		'Active ou désactive le temps des pièces
		
5: On Error GoTo AfficherErreur
		
10: If m_eMode = enumMode.MODE_AJOUT_MODIF Then
15: If m_bSansTemps = True Then
20: Croix1.Visible = False
25: Croix2.Visible = False
				
30: m_bSansTemps = False
35: Else
40: Croix1.Visible = True
45: Croix2.Visible = True
				
50: m_bSansTemps = True
55: End If
			
60: 'UPGRADE_ISSUE: Label event lblTempsFabricationSoum.Change was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
			lblTempsFabricationSoum_Change()
65: End If
		
70: Call CalculerTotal()
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmProjSoumElecTemps", "lblTempsMécanique_Click", Err, Erl())
	End Sub
	
	Private Function CalculerTempsFabrication() As String
		
5: On Error GoTo AfficherErreur
		
10: Dim dblTempsFab As Double
15: Dim iCompteur As Short
		
		'Pour chaque élément du listView
20: For iCompteur = 1 To FrmProjSoumElec.lvwSoumission.Items.Count
25: 'UPGRADE_WARNING: Lower bound of collection FrmProjSoumElec.lvwSoumission.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection FrmProjSoumElec.lvwSoumission.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If Trim(FrmProjSoumElec.lvwSoumission.Items.Item(iCompteur).SubItems(9).Text) <> vbNullString Then
				'On additionne le temps
30: 'UPGRADE_WARNING: Lower bound of collection FrmProjSoumElec.lvwSoumission.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection FrmProjSoumElec.lvwSoumission.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				dblTempsFab = dblTempsFab + CDbl(Replace(Trim(FrmProjSoumElec.lvwSoumission.Items.Item(iCompteur).SubItems(9).Text), ".", ","))
35: End If
40: Next 
		
45: CalculerTempsFabrication = Replace(CStr(dblTempsFab / 10), ".", ",")
		
50: Exit Function
		
AfficherErreur: 
		
55: Call AfficherErreur("frmProjSoumElecTemps", "CalculerTempsFabrication", Err, Erl())
	End Function
End Class