Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class FrmPara
	Inherits System.Windows.Forms.Form
	
	Private m_iCurrFrame As Short
	
	Private Sub cmdAppliquer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAppliquer.Click
		
5: On Error GoTo AfficherErreur
		
		'Enregistrement des paramètres dans la table GRB_Config
10: If VerifierChamps = True Then
			'Enregistrer les configuration
15: Call EnregistrerConfiguration()
			
			'Fermeture du form
20: Call Me.Close()
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmPara", "cmdAppliquer_Click", Err, Erl())
	End Sub
	
	Private Function VerifierChamps() As Boolean
		
5: On Error GoTo AfficherErreur
		
10: Dim objControl As Object
		
15: VerifierChamps = True
		
		'Si champs vide
20: For	Each objControl In Me.Controls
25: If TypeOf objControl Is System.Windows.Forms.TextBox Then
30: 'UPGRADE_WARNING: Couldn't resolve default property of object objControl.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Trim(objControl.Text) = vbNullString Then
35: Call MsgBox("Vous devez remplir tous les champs!", MsgBoxStyle.OKOnly, "Erreur")
					
40: VerifierChamps = False
					
45: Exit Function
50: Else
55: 'UPGRADE_WARNING: Couldn't resolve default property of object objControl.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If objControl.Name <> "txtCheminSEE4000" Then
60: 'UPGRADE_WARNING: Couldn't resolve default property of object objControl.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						objControl.Text = Replace(objControl.Text, ".", ",")
						
65: 'UPGRADE_WARNING: Couldn't resolve default property of object objControl.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If Not IsNumeric(objControl.Text) Then
70: Call MsgBox("Champs non numérique!", MsgBoxStyle.OKOnly, "Erreur")
							
75: VerifierChamps = False
							
80: Exit Function
85: End If
90: End If
95: End If
100: End If
105: Next objControl
		
		'Profit électrique
110: If CDbl(txtProfitElec.Text) < 1 Then
115: Call MsgBox("Le pourcentage de profit électrique doit être plus grand que 1 !", MsgBoxStyle.OKOnly, "Erreur")
			
120: VerifierChamps = False
			
125: Exit Function
130: End If
		
		'Profit mécanique
135: If CDbl(txtProfitMec.Text) < 1 Then
140: Call MsgBox("Le pourcentage de profit mécanique doit être plus grand que 1 !", MsgBoxStyle.OKOnly, "Erreur")
			
145: VerifierChamps = False
			
150: Exit Function
155: End If
		
160: If CDbl(txtCommission.Text) > 1 Then
165: Call MsgBox("Le pourcentage de commission doit être plus petit que 1 !", MsgBoxStyle.OKOnly, "Erreur")
			
170: VerifierChamps = False
			
175: Exit Function
180: End If
		
185: If CDbl(txtImprevus.Text) > 1 Then
190: Call MsgBox("Le pourcentage d'imprévus doit être plus petit que 1 !", MsgBoxStyle.OKOnly, "Erreur")
			
195: VerifierChamps = False
			
200: Exit Function
205: End If
		
210: Exit Function
		
AfficherErreur: 
		
215: Call AfficherErreur("frmPara", "VerifierChamps", Err, Erl())
	End Function
	
	Private Sub EnregistrerConfiguration()
		
5: On Error GoTo AfficherErreur
		
		'Enregistrement des configurations
10: Dim rstPara As ADODB.Recordset
		
		'Initialisation des variables
15: Call InitialiserVariablesConfiguration()
		
20: rstPara = New ADODB.Recordset
		
		'Enregistrement dans la BD
25: Call rstPara.Open("SELECT * FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
30: rstPara.Fields("ProfitElec").Value = txtProfitElec.Text
35: rstPara.Fields("ProfitMec").Value = txtProfitMec.Text
40: rstPara.Fields("Commission").Value = txtCommission.Text
45: rstPara.Fields("Imprévus").Value = txtImprevus.Text
50: rstPara.Fields("IndiceDessin").Value = txtIndice.Text
55: rstPara.Fields("TauxAmericain").Value = txtTauxAmericain.Text
60: rstPara.Fields("TauxEspagnol").Value = txtTauxEspagnol.Text
65: rstPara.Fields("TauxDessinElec").Value = txtDessinElec.Text
70: rstPara.Fields("TauxProgInterface").Value = txtProgInterface.Text
75: rstPara.Fields("TauxProgAutomate").Value = txtProgAutomate.Text
80: rstPara.Fields("TauxProgRobot").Value = txtProgRobot.Text
85: rstPara.Fields("TauxVision").Value = txtProgVision.Text
90: rstPara.Fields("TauxAssemblageElec").Value = txtAssemblageElec.Text
95: rstPara.Fields("TauxFabrication").Value = txtFabrication.Text
100: rstPara.Fields("TauxTestElec").Value = txtTestElec.Text
105: rstPara.Fields("TauxGestionProjetsElec").Value = txtGestionProjetsElec.Text
110: rstPara.Fields("TauxInstallationElec").Value = txtInstallationElec.Text
115: rstPara.Fields("TauxMiseService").Value = txtMiseEnService.Text
120: rstPara.Fields("TauxFormationElec").Value = txtFormationElec.Text
125: rstPara.Fields("TauxShippingElec").Value = txtShippingElec.Text
130: rstPara.Fields("TauxMachinage").Value = txtMachinage.Text
135: rstPara.Fields("TauxCoupe").Value = txtCoupe.Text
140: rstPara.Fields("TauxSoudure").Value = txtSoudure.Text
145: rstPara.Fields("TauxAssemblageMec").Value = txtAssemblageMec.Text
150: rstPara.Fields("TauxPeinture").Value = txtPeinture.Text
155: rstPara.Fields("TauxTestMec").Value = txtTestMec.Text
160: rstPara.Fields("TauxGestionProjetsMec").Value = txtGestionProjetsMec.Text
165: rstPara.Fields("TauxDessinMec").Value = txtDessinMec.Text
170: rstPara.Fields("TauxFormationMec").Value = txtFormationMec.Text
175: rstPara.Fields("TauxInstallationMec").Value = txtInstallationMec.Text
180: rstPara.Fields("TauxShippingMec").Value = txtShippingMec.Text
185: rstPara.Fields("LeGrand").Value = txtLeGrand.Text
190: rstPara.Fields("Lamine").Value = txtLamine.Text
195: rstPara.Fields("Thermo").Value = txtThermo.Text
200: rstPara.Fields("4em").Value = txt4em.Text
205: rstPara.Fields("fsDixMoins").Value = txtDixMoins.Text
210: rstPara.Fields("fsDix").Value = txtDixQuinze.Text
215: rstPara.Fields("fsQuinze").Value = txtQuinzeVingt.Text
220: rstPara.Fields("fsVingt").Value = txtVingtVingtCinq.Text
225: rstPara.Fields("fsVingtCinq").Value = txtVingtCinqCinquante.Text
230: rstPara.Fields("fsCinquante").Value = txtCinquanteCent.Text
235: rstPara.Fields("fsCent").Value = txtCentPlus.Text
240: rstPara.Fields("CheminSee4000").Value = txtCheminSEE4000.Text
245: rstPara.Fields("Hebergement1").Value = txtHebergement1.Text
250: rstPara.Fields("Hebergement2").Value = txtHebergement2.Text
255: rstPara.Fields("Repas").Value = txtRepas.Text
260: rstPara.Fields("Standard").Value = txtStandard.Text
265: rstPara.Fields("UniteMobile").Value = txtUniteMobile.Text
		
270: Call rstPara.Update()
		
275: Call rstPara.Close()
280: 'UPGRADE_NOTE: Object rstPara may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPara = Nothing
		
285: Exit Sub
		
AfficherErreur: 
		
290: Call AfficherErreur("frmPara", "EnregistrerConfiguration", Err, Erl())
	End Sub
	
	
	Private Sub cmdConfig_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdConfig.Click
		
		Dim sVersion As String
		Dim rstPara As ADODB.Recordset
		
		sVersion = InputBox("Entrer le mot de passe.", "Version")
		If sVersion = "gaetan" Then
			rstPara = New ADODB.Recordset
			sVersion = ""
			Call rstPara.Open("SELECT DerniereVersion FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			sVersion = rstPara.Fields("DerniereVersion").Value
			sVersion = InputBox("Entrer le numéro de version.", "Version", sVersion)
			If Not sVersion = "" Then
				rstPara.Fields("DerniereVersion").Value = sVersion
				rstPara.Update()
			End If
			rstPara.Close()
			'UPGRADE_NOTE: Object rstPara may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstPara = Nothing
		End If
		
	End Sub
	
	Private Sub cmdExportToOutlook_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExportToOutlook.Click
		Call OuvrirForm(frmExportToOutLook, True)
	End Sub
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
		'Fermer la fenêtre
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmPara", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub RemplirValue()
		
5: On Error GoTo AfficherErreur
		
		'On remplir les champs à l'aide de la table GRB_Config
10: Dim rstPara As ADODB.Recordset
		
15: rstPara = New ADODB.Recordset
		
20: Call rstPara.Open("SELECT * FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("ProfitElec").Value) Then
30: txtProfitElec.Text = rstPara.Fields("ProfitElec").Value
35: End If
		
40: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("ProfitMec").Value) Then
45: txtProfitMec.Text = rstPara.Fields("ProfitMec").Value
50: End If
		
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("Commission").Value) Then
60: txtCommission.Text = rstPara.Fields("Commission").Value
65: End If
		
70: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("Imprévus").Value) Then
75: txtImprevus.Text = rstPara.Fields("Imprévus").Value
80: End If
		
85: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("IndiceDessin").Value) Then
90: txtIndice.Text = rstPara.Fields("IndiceDessin").Value
95: End If
		
100: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxAmericain").Value) Then
105: txtTauxAmericain.Text = rstPara.Fields("TauxAmericain").Value
110: End If
		
115: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxEspagnol").Value) Then
120: txtTauxEspagnol.Text = rstPara.Fields("TauxEspagnol").Value
125: End If
		
130: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxDessinElec").Value) Then
135: txtDessinElec.Text = rstPara.Fields("TauxDessinElec").Value
140: End If
		
145: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxProgInterface").Value) Then
150: txtProgInterface.Text = rstPara.Fields("TauxProgInterface").Value
155: End If
		
160: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxProgAutomate").Value) Then
165: txtProgAutomate.Text = rstPara.Fields("TauxProgAutomate").Value
170: End If
		
175: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxProgRobot").Value) Then
180: txtProgRobot.Text = rstPara.Fields("TauxProgRobot").Value
185: End If
		
190: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxVision").Value) Then
195: txtProgVision.Text = rstPara.Fields("TauxVision").Value
200: End If
		
205: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxAssemblageElec").Value) Then
210: txtAssemblageElec.Text = rstPara.Fields("TauxAssemblageElec").Value
215: End If
		
220: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxFabrication").Value) Then
225: txtFabrication.Text = rstPara.Fields("TauxFabrication").Value
230: End If
		
235: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxTestElec").Value) Then
240: txtTestElec.Text = rstPara.Fields("TauxTestElec").Value
245: End If
		
250: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxGestionProjetsElec").Value) Then
255: txtGestionProjetsElec.Text = rstPara.Fields("TauxGestionProjetsElec").Value
260: End If
		
265: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxInstallationElec").Value) Then
270: txtInstallationElec.Text = rstPara.Fields("TauxInstallationElec").Value
275: End If
		
280: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxMiseService").Value) Then
285: txtMiseEnService.Text = rstPara.Fields("TauxMiseService").Value
290: End If
		
295: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxFormationElec").Value) Then
300: txtFormationElec.Text = rstPara.Fields("TauxFormationElec").Value
305: End If
		
310: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxShippingElec").Value) Then
315: txtShippingElec.Text = rstPara.Fields("TauxShippingElec").Value
320: End If
		
325: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxMachinage").Value) Then
330: txtMachinage.Text = rstPara.Fields("TauxMachinage").Value
335: End If
		
340: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxCoupe").Value) Then
345: txtCoupe.Text = rstPara.Fields("TauxCoupe").Value
350: End If
		
355: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxSoudure").Value) Then
360: txtSoudure.Text = rstPara.Fields("TauxSoudure").Value
365: End If
		
370: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxAssemblageMec").Value) Then
375: txtAssemblageMec.Text = rstPara.Fields("TauxAssemblageMec").Value
380: End If
		
385: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxPeinture").Value) Then
390: txtPeinture.Text = rstPara.Fields("TauxPeinture").Value
395: End If
		
400: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxTestMec").Value) Then
405: txtTestMec.Text = rstPara.Fields("TauxTestMec").Value
410: End If
		
415: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxGestionProjetsMec").Value) Then
420: txtGestionProjetsMec.Text = rstPara.Fields("TauxGestionProjetsMec").Value
425: End If
		
430: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxDessinMec").Value) Then
435: txtDessinMec.Text = rstPara.Fields("TauxDessinMec").Value
440: End If
		
445: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxFormationMec").Value) Then
450: txtFormationMec.Text = rstPara.Fields("TauxFormationMec").Value
455: End If
		
460: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxInstallationMec").Value) Then
465: txtInstallationMec.Text = rstPara.Fields("TauxInstallationMec").Value
470: End If
		
475: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("TauxShippingMec").Value) Then
480: txtShippingMec.Text = rstPara.Fields("TauxShippingMec").Value
485: End If
		
490: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("LeGrand").Value) Then
495: txtLeGrand.Text = rstPara.Fields("LeGrand").Value
500: End If
		
505: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("Lamine").Value) Then
510: txtLamine.Text = rstPara.Fields("Lamine").Value
515: End If
		
520: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("Thermo").Value) Then
525: txtThermo.Text = rstPara.Fields("Thermo").Value
530: End If
		
535: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("4em").Value) Then
540: txt4em.Text = rstPara.Fields("4em").Value
545: End If
		
550: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("fsDixMoins").Value) Then
555: txtDixMoins.Text = rstPara.Fields("fsDixMoins").Value
560: End If
		
565: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("fsDix").Value) Then
570: txtDixQuinze.Text = rstPara.Fields("fsDix").Value
575: End If
		
580: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("fsQuinze").Value) Then
585: txtQuinzeVingt.Text = rstPara.Fields("fsQuinze").Value
590: End If
		
595: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("fsVingt").Value) Then
600: txtVingtVingtCinq.Text = rstPara.Fields("fsVingt").Value
605: End If
		
610: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("fsVingtCinq").Value) Then
615: txtVingtCinqCinquante.Text = rstPara.Fields("fsVingtCinq").Value
620: End If
		
625: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("fsCinquante").Value) Then
630: txtCinquanteCent.Text = rstPara.Fields("fsCinquante").Value
635: End If
		
640: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("fsCent").Value) Then
645: txtCentPlus.Text = rstPara.Fields("fsCent").Value
650: End If
		
655: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("CheminSee4000").Value) Then
660: txtCheminSEE4000.Text = rstPara.Fields("CheminSee4000").Value
665: End If
		
670: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("Hebergement1").Value) Then
675: txtHebergement1.Text = rstPara.Fields("Hebergement1").Value
680: End If
		
685: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("Hebergement2").Value) Then
690: txtHebergement2.Text = rstPara.Fields("Hebergement2").Value
695: End If
		
700: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("Repas").Value) Then
705: txtRepas.Text = rstPara.Fields("Repas").Value
710: End If
		
715: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("Standard").Value) Then
720: txtStandard.Text = rstPara.Fields("Standard").Value
725: End If
		
730: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPara.Fields("UniteMobile").Value) Then
735: txtUniteMobile.Text = rstPara.Fields("UniteMobile").Value
740: End If
		
745: Call rstPara.Close()
750: 'UPGRADE_NOTE: Object rstPara may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPara = Nothing
		
755: Exit Sub
		
AfficherErreur: 
		
760: Call AfficherErreur("frmPara", "RemplirValue", Err, Erl())
	End Sub
	
	
	Private Sub FrmPara_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Call RemplirValue()
		
15: Frame1(1).Visible = True
		
20: m_iCurrFrame = 1
		
25: Call TbsPara_ClickEvent(TbsPara, New System.EventArgs())
		
30: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmPara", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub TbsPara_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TbsPara.ClickEvent
		
5: On Error GoTo AfficherErreur
		
		'si on est deja sur le l'onglet voulu on ne fait rien
10: If tbsPara.SelectedItem.Index <> m_iCurrFrame Then
15: Frame1(tbsPara.SelectedItem.Index).Visible = True
20: Frame1(m_iCurrFrame).Visible = False
25: m_iCurrFrame = tbsPara.SelectedItem.Index
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmPara", "TbsPara_Click", Err, Erl())
	End Sub
End Class