Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmChoixDateImpressionFacturation
	Inherits System.Windows.Forms.Form
	
	Private Enum enumDate
		DEBUT = 0
		Fin = 1
	End Enum
	
	Private Const I_OPT_PROJET_ENTIER As Short = 0
	Private Const I_OPT_2_DATES As Short = 1
	
	Private Const I_OPT_LISTE_PUNCH As Short = 0
	Private Const I_OPT_COUTANT As Short = 1
	
	Private m_eDate As enumDate
	Private m_sNoProjSoum As String
	Private m_bProjet As Boolean
	Private m_sClient As String
	Private m_sDescription As String
	
	Public Sub Afficher(ByVal sNoProjSoum As String, ByVal bProjet As Boolean, ByVal sClient As String, ByVal sDescription As String)
		
5: On Error GoTo AfficherErreur
		
10: m_sNoProjSoum = sNoProjSoum
		
15: m_bProjet = bProjet
		
20: If bProjet = True Then
25: optChoix(I_OPT_COUTANT).Enabled = True
30: Else
35: optChoix(I_OPT_COUTANT).Enabled = False
40: End If
		
45: m_sClient = sClient
		
50: m_sDescription = sDescription
		
55: Call Me.ShowDialog()
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmChoixDateImpressionFacturation", "Afficher", Err, Erl())
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDateImpressionFacturation", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdImprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImprimer.Click
		
5: On Error GoTo AfficherErreur
		
10: If optChoixProjetEntier(I_OPT_LISTE_PUNCH).Checked = True Then
15: Call ImprimerListePunch()
20: Else
25: Call ImprimerPrixCoutant()
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmChoixDateImpressionFacturation", "cmdImprimer_Click", Err, Erl())
	End Sub
	
	Private Sub ImprimerListePunch()
		Dim DR_Facturation As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPunch As ADODB.Recordset
15: Dim rstSomme As ADODB.Recordset
20: Dim iCompteur As Short
25: Dim bNonComplet As Boolean
		
30: If optChoix(I_OPT_2_DATES).Checked = True Then
35: If mskDateDebut.Text <> "" Then
40: If mskDateFin.Text <> "" Then
45: If ValiderDate(mskDateDebut.Text) = True Then
50: If ValiderDate(mskDateFin.Text) = True Then
55: If mskDateDebut.Text > mskDateFin.Text Then
60: Call MsgBox("La date de début doit être plus petite que la date de fin!", MsgBoxStyle.OKOnly, "Erreur")
								
65: Exit Sub
70: End If
75: Else
80: Call MsgBox("Date de fin non valide!", MsgBoxStyle.OKOnly, "Erreur")
							
85: Exit Sub
90: End If
95: Else
100: Call MsgBox("Date de début non valide!", MsgBoxStyle.OKOnly, "Erreur")
						
105: Exit Sub
110: End If
115: Else
120: Call MsgBox("La date de fin est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
					
125: Exit Sub
130: End If
135: Else
140: Call MsgBox("La date de début est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
				
145: Exit Sub
150: End If
175: End If
		
		'Si il y a des projets ou des soumissions
180: If m_sNoProjSoum <> "" Then
185: If optChoix(I_OPT_PROJET_ENTIER).Checked = True Then
190: For iCompteur = 1 To frmFacturation.lvwProjets.Items.Count
195: 'UPGRADE_WARNING: Lower bound of collection frmFacturation.lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection frmFacturation.lvwProjets.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If frmFacturation.lvwProjets.Items.Item(iCompteur).SubItems(3).Text = "" Then
200: bNonComplet = True
						
205: Exit For
210: End If
215: Next 
				
220: If bNonComplet = True Then
225: If MsgBox("Les punchs ne sont pas complets!" & vbNewLine & "Voulez-vous imprimer seulement les punchs complets?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
230: Exit Sub
235: End If
240: End If
				
245: rstPunch = New ADODB.Recordset
				
250: rstPunch.CursorLocation = ADODB.CursorLocationEnum.adUseServer
				
				'*************************************************************************
				'ajout du champ type dans la requête PAR GAÉTAN GINGRAS LE 07 FÉVRIER 2010
				If MsgBox("Désirez-vous afficher les commentaires avec le type des travaux?", MsgBoxStyle.YesNo, "Choix d'affichage") = MsgBoxResult.Yes Then
255: Call rstPunch.Open("SELECT (GRB_Punch.Type & ' - ' & GRB_Punch.Commentaire) AS Comment, GRB_Punch.Date, GRB_Punch.HeureDébut, GRB_Punch.HeureFin, GRB_Punch.Facturé, GRB_Punch.NoFacture, GRB_Employés.Initiale, Round((TimeSerial(Left(GRB_Punch.HeureFin,2), RIGHT(GRB_Punch.HeureFin,2),0) - TimeSerial(Left(GRB_Punch.HeureDébut,2), RIGHT(GRB_Punch.HeureDébut,2),0)) * 24, 2) As Total FROM GRB_Punch INNER JOIN GRB_Employés ON GRB_Punch.NoEmploye = GRB_Employés.noEmploye WHERE GRB_Punch.NoProjet = '" & m_sNoProjSoum & "' AND HeureFin IS NOT NULL ORDER BY [Date]", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				Else
					Call rstPunch.Open("SELECT GRB_Punch.Type AS Comment, GRB_Punch.Date, GRB_Punch.HeureDébut, GRB_Punch.HeureFin, GRB_Punch.Commentaire, GRB_Punch.Facturé, GRB_Punch.NoFacture, GRB_Employés.Initiale, Round((TimeSerial(Left(GRB_Punch.HeureFin,2), RIGHT(GRB_Punch.HeureFin,2),0) - TimeSerial(Left(GRB_Punch.HeureDébut,2), RIGHT(GRB_Punch.HeureDébut,2),0)) * 24, 2) As Total FROM GRB_Punch INNER JOIN GRB_Employés ON GRB_Punch.NoEmploye = GRB_Employés.noEmploye WHERE GRB_Punch.NoProjet = '" & m_sNoProjSoum & "' AND HeureFin IS NOT NULL ORDER BY [Date]", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				End If
				'*************************************************************************
				
260: Else
265: For iCompteur = 1 To frmFacturation.lvwProjets.Items.Count
270: 'UPGRADE_WARNING: Lower bound of collection frmFacturation.lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection frmFacturation.lvwProjets.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If frmFacturation.lvwProjets.Items.Item(iCompteur).SubItems(3).Text = "" Then
275: 'UPGRADE_WARNING: Lower bound of collection frmFacturation.lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Lower bound of collection frmFacturation.lvwProjets.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If frmFacturation.lvwProjets.Items.Item(iCompteur).SubItems(1).Text >= mskDateDebut.Text And frmFacturation.lvwProjets.Items.Item(iCompteur).SubItems(1).Text >= mskDateFin.Text Then
280: bNonComplet = True
							
285: Exit For
290: End If
295: End If
300: Next 
				
305: If bNonComplet = True Then
310: If MsgBox("Les punchs ne sont pas complets!" & vbNewLine & "Voulez-vous imprimer seulement les punchs complets?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
315: Exit Sub
320: End If
325: End If
				
330: rstPunch = New ADODB.Recordset
				
335: rstPunch.CursorLocation = ADODB.CursorLocationEnum.adUseServer
				
				'**************************************************************************
				'ajout du champ type dans la requête PAR GAÉTAN GINGRAS LE 07 FÉVRIER 2010
				If MsgBox("Désirez-vous afficher les commentaires avec le type des travaux?", MsgBoxStyle.YesNo, "Choix d'affichage") = MsgBoxResult.Yes Then
340: Call rstPunch.Open("SELECT (GRB_Punch.Type & ' - ' & GRB_Punch.Commentaire) AS Comment, GRB_Punch.Date, GRB_Punch.HeureDébut, GRB_Punch.HeureFin, GRB_Punch.Commentaire, GRB_Punch.Facturé, GRB_Punch.NoFacture, GRB_Employés.Initiale, Round((TimeSerial(Left(GRB_Punch.HeureFin,2), RIGHT(GRB_Punch.HeureFin,2),0) - TimeSerial(Left(GRB_Punch.HeureDébut,2), RIGHT(GRB_Punch.HeureDébut,2),0)) * 24, 2) As Total FROM GRB_Punch INNER JOIN GRB_Employés ON GRB_Punch.NoEmploye = GRB_Employés.noEmploye WHERE GRB_Punch.NoProjet = '" & m_sNoProjSoum & "' AND HeureFin IS NOT NULL AND [GRB_Punch.Date] BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' ORDER BY [Date]", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				Else
					Call rstPunch.Open("SELECT GRB_Punch.Type AS Comment, GRB_Punch.Date, GRB_Punch.HeureDébut, GRB_Punch.HeureFin, GRB_Punch.Commentaire, GRB_Punch.Facturé, GRB_Punch.NoFacture, GRB_Employés.Initiale, Round((TimeSerial(Left(GRB_Punch.HeureFin,2), RIGHT(GRB_Punch.HeureFin,2),0) - TimeSerial(Left(GRB_Punch.HeureDébut,2), RIGHT(GRB_Punch.HeureDébut,2),0)) * 24, 2) As Total FROM GRB_Punch INNER JOIN GRB_Employés ON GRB_Punch.NoEmploye = GRB_Employés.noEmploye WHERE GRB_Punch.NoProjet = '" & m_sNoProjSoum & "' AND HeureFin IS NOT NULL AND [GRB_Punch.Date] BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' ORDER BY [Date]", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				End If
				'**************************************************************************
				
345: End If
			
350: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Facturation.DataSource = rstPunch
			
355: 'DR_Facturation.Orientation = rptOrientLandscape
			
360: If m_bProjet = True Then
365: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section4").Controls("lblTitreNumero").Caption = "Numéro de projet :"
370: Else
375: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section4").Controls("lblTitreNumero").Caption = "Numéro de soumission :"
380: End If
			
385: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Facturation.Sections("Section4").Controls("lblNumero").Caption = m_sNoProjSoum
390: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Facturation.Sections("Section4").Controls("lblClient").Caption = m_sClient
			
			'affiche la date
			'**************************************************
			'ajout par Gaétan Gingras le 20 mai 2009
394: If MsgBox("Désirez-vous afficher la date en bas de page ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Affichage de la date") = MsgBoxResult.Yes Then
395: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section3").Controls("lblDate").Caption = ConvertDate(Today)
396: Else
397: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section3").Controls("lblDate").Caption = " "
398: End If
			
			'**************************************************
			
			'affichage des colonnes facturé et no. de facture
			'**************************************************
			'ajout de Gaétan Gingras le 20 mai 2009
399: If MsgBox("Désirez-vous afficher les colonnes 'facturé' et 'no. facture'?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Affichage de la date") = MsgBoxResult.Yes Then
400: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section1").Controls("text1").Visible = True
401: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section1").Controls("text4").Visible = True
402: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section2").Controls("label4").Visible = True
403: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section2").Controls("label14").Visible = True
404: Else
405: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section1").Controls("text1").Visible = False
406: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section1").Controls("text4").Visible = False
407: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section2").Controls("label4").Visible = False
408: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section2").Controls("label14").Visible = False
409: End If
			'**************************************************
			
410: rstSomme = New ADODB.Recordset
			
413: If optChoix(I_OPT_PROJET_ENTIER).Checked = True Then
414: Call rstSomme.Open("SELECT SUM(TimeSerial(Left(HeureFin,2),RIGHT(HeureFin,2),0) - TimeSerial(Left(HeureDébut,2), RIGHT(HeureDébut,2),0)) As Total FROM GRB_Punch WHERE NoProjet = '" & m_sNoProjSoum & "' AND Facturé = True AND HeureFin IS NOT NULL", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
415: Else
420: Call rstSomme.Open("SELECT SUM(TimeSerial(Left(HeureFin,2),RIGHT(HeureFin,2),0) - TimeSerial(Left(HeureDébut,2), RIGHT(HeureDébut,2),0)) As Total FROM GRB_Punch WHERE NoProjet = '" & m_sNoProjSoum & "' AND Facturé = True AND HeureFin IS NOT NULL AND [Date] BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
425: End If
			
430: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstSomme.Fields("Total").Value) Then
435: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section5").Controls("lblHeuresFacturees").Caption = System.Math.Round(rstSomme.Fields("Total").Value * 24, 4)
440: Else
445: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section5").Controls("lblHeuresFacturees").Caption = "0"
450: End If
			
455: Call rstSomme.Close()
			
460: rstSomme.CursorLocation = ADODB.CursorLocationEnum.adUseServer
			
465: If optChoix(I_OPT_PROJET_ENTIER).Checked = True Then
470: Call rstSomme.Open("SELECT SUM(TimeSerial(Left(HeureFin,2), RIGHT(HeureFin,2),0) - TimeSerial(Left(HeureDébut,2),RIGHT(HeureDébut,2),0)) As Total FROM GRB_Punch WHERE NoProjet = '" & m_sNoProjSoum & "' AND Facturé = False AND HeureFin IS NOT NULL", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
475: Else
480: Call rstSomme.Open("SELECT SUM(TimeSerial(Left(HeureFin,2), RIGHT(HeureFin,2),0) - TimeSerial(Left(HeureDébut,2),RIGHT(HeureDébut,2),0)) As Total FROM GRB_Punch WHERE NoProjet = '" & m_sNoProjSoum & "' AND Facturé = False AND HeureFin IS NOT NULL AND [Date] BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
485: End If
			
490: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstSomme.Fields("Total").Value) Then
495: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section5").Controls("lblHeuresNonFacturees").Caption = System.Math.Round(rstSomme.Fields("Total").Value * 24, 4)
500: Else
505: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section5").Controls("lblHeuresNonFacturees").Caption = "0"
510: End If
			
515: Call rstSomme.Close()
520: 'UPGRADE_NOTE: Object rstSomme may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstSomme = Nothing
			
525: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Facturation.Sections("Section5").Controls("lblGrandTotal").Caption = CDbl(DR_Facturation.Sections("Section5").Controls("lblHeuresFacturees").Caption) + CDbl(DR_Facturation.Sections("Section5").Controls("lblHeuresNonFacturees").Caption)
			
530: If optChoix(I_OPT_PROJET_ENTIER).Checked = True Then
535: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section4").Controls("lblDateDebut").Caption = "N/A"
540: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section4").Controls("lblDateFin").Caption = "N/A"
545: Else
550: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section4").Controls("lblDateDebut").Caption = mskDateDebut.Text
555: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Facturation.Sections("Section4").Controls("lblDateFin").Caption = mskDateFin.Text
560: End If
			
565: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Facturation.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call DR_Facturation.Show(VB6.FormShowConstants.Modal)
			
570: Call rstPunch.Close()
575: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstPunch = Nothing
580: End If
		
585: Call Me.Close()
		
590: Exit Sub
		
AfficherErreur: 
		
595: Call AfficherErreur("frmChoixDateImpressionFacturation", "ImprimerListePunch", Err, Erl())
	End Sub
	
	Private Sub ImprimerPrixCoutant()
		Dim DR_ApercuProjet As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim dblTotal As Double
15: Dim sProjet As String
20: Dim rstDS As ADODB.Recordset
		
25: If optChoix(I_OPT_2_DATES).Checked = True Then
30: If mskDateDebut.Text <> "" Then
35: If mskDateFin.Text <> "" Then
40: If ValiderDate(mskDateDebut.Text) = True Then
45: If ValiderDate(mskDateFin.Text) = True Then
50: If mskDateDebut.Text > mskDateFin.Text Then
55: Call MsgBox("La date de début doit être plus petite que la date de fin!", MsgBoxStyle.OKOnly, "Erreur")
								
60: Exit Sub
65: End If
70: Else
75: Call MsgBox("Date de fin non valide!", MsgBoxStyle.OKOnly, "Erreur")
							
80: Exit Sub
85: End If
90: Else
95: Call MsgBox("Date de début non valide!", MsgBoxStyle.OKOnly, "Erreur")
						
100: Exit Sub
105: End If
110: Else
115: Call MsgBox("La date de fin est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
					
120: Exit Sub
125: End If
130: Else
135: Call MsgBox("La date de début est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
				
140: Exit Sub
145: End If
150: End If
		
155: If Len(m_sNoProjSoum) = 9 Then
160: sProjet = VB.Right(m_sNoProjSoum, 8)
165: Else
170: Call MsgBox("Numéro de projet non valide!", MsgBoxStyle.OKOnly, "Erreur")
			
175: Exit Sub
180: End If
		
		'Ce recordset ne sert absolument à rien,
		'il est seulement utiliser parce que le DR a besoin d'un DataSource pour ouvrir
185: rstDS = New ADODB.Recordset
		
190: Call rstDS.Open("SELECT * FROM GRB_ProjSoum WHERE IDProjSoum = '" & m_sNoProjSoum & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
195: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.DataSource = rstDS
		
200: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblNumero").Caption = sProjet
205: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblClient").Caption = m_sClient
210: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblDescription").Caption = m_sDescription
		
215: If optChoix(I_OPT_PROJET_ENTIER).Checked = True Then
220: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblDate").Caption = ConvertDate(Today)
225: Else
230: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblDate").Caption = "Du " & mskDateDebut.Text & " au " & mskDateFin.Text
235: End If
		
240: Call RemplirRapportElectrique(sProjet)
245: Call RemplirRapportMecanique(sProjet)
		
250: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblForfaitElecSoum").Caption) And IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblForfaitMecSoum").Caption) Then
255: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblForfaitElecSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblForfaitMecSoum").Caption)
260: Else
265: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblForfaitElecSoum").Caption) Then
270: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblForfaitElecSoum").Caption)
275: Else
280: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblForfaitMecSoum").Caption) Then
285: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblForfaitMecSoum").Caption)
290: Else
295: dblTotal = 0
300: End If
305: End If
310: End If
		
315: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblTotalForfaitSoum").Caption = Conversion_Renamed(dblTotal, ModuleMain.enumConvert.MODE_ARGENT)
		
320: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblForfaitElecProj").Caption) And IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblForfaitMecProj").Caption) Then
325: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblForfaitElecProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblForfaitMecProj").Caption)
330: Else
335: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblForfaitElecProj").Caption) Then
340: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblForfaitElecProj").Caption)
345: Else
350: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblForfaitMecProj").Caption) Then
355: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblForfaitMecProj").Caption)
360: Else
365: dblTotal = 0
370: End If
375: End If
380: End If
		
385: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblTotalForfaitProj").Caption = Conversion_Renamed(dblTotal, ModuleMain.enumConvert.MODE_ARGENT)
		
390: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTotalSoum").Caption) And IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTotalSoum").Caption) Then
395: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTotalSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTotalSoum").Caption)
			
400: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblTotalHeuresSoum").Caption = dblTotal
405: Else
410: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTotalSoum").Caption) And Not IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTotalSoum").Caption) Then
415: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblTotalHeuresSoum").Caption = "---"
420: Else
425: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTotalSoum").Caption) Then
430: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblTotalHeuresSoum").Caption = DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTotalSoum").Caption
435: Else
440: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblTotalHeuresSoum").Caption = DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTotalSoum").Caption
445: End If
450: End If
455: End If
		
460: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblTotalElecSoum").Caption) And IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblTotalMecSoum").Caption) Then
465: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblTotalElecSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblTotalMecSoum").Caption)
			
470: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblGrandTotalSoum").Caption = Conversion_Renamed(dblTotal, ModuleMain.enumConvert.MODE_ARGENT)
475: Else
480: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblTotalElecSoum").Caption) And Not IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblTotalMecSoum").Caption) Then
485: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblGrandTotalSoum").Caption = "---"
490: Else
495: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblTotalElecSoum").Caption) Then
500: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblGrandTotalSoum").Caption = DR_ApercuProjet.Sections("Section2").Controls("lblTotalMecSoum").Caption
505: Else
510: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblGrandTotalSoum").Caption = DR_ApercuProjet.Sections("Section2").Controls("lblTotalElecSoum").Caption
515: End If
520: End If
525: End If
		
530: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTotalProj").Caption) And IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTotalProj").Caption) Then
535: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTotalProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTotalProj").Caption)
			
540: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblTotalHeuresProj").Caption = dblTotal
545: Else
550: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTotalProj").Caption) And Not IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTotalProj").Caption) Then
555: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblTotalHeuresProj").Caption = "---"
560: Else
565: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTotalProj").Caption) Then
570: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblTotalHeuresProj").Caption = DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTotalProj").Caption
575: Else
580: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblTotalHeuresProj").Caption = DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTotalProj").Caption
585: End If
590: End If
595: End If
		
600: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblTotalElecProj").Caption) And IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblTotalMecProj").Caption) Then
605: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblTotalElecProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblTotalMecProj").Caption)
			
610: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblGrandTotalProj").Caption = Conversion_Renamed(dblTotal, ModuleMain.enumConvert.MODE_ARGENT)
615: Else
620: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblTotalElecProj").Caption) And Not IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblTotalMecProj").Caption) Then
625: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblGrandTotalProj").Caption = "---"
630: Else
635: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not IsNumeric(DR_ApercuProjet.Sections("Section2").Controls("lblTotalElecProj").Caption) Then
640: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblGrandTotalProj").Caption = DR_ApercuProjet.Sections("Section2").Controls("lblTotalMecProj").Caption
645: Else
650: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblGrandTotalProj").Caption = DR_ApercuProjet.Sections("Section2").Controls("lblTotalElecProj").Caption
655: End If
660: End If
665: End If
		
670: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If DR_ApercuProjet.Sections("Section2").Controls("lblTotalForfaitSoum").Caption <> "---" And DR_ApercuProjet.Sections("Section2").Controls("lblGrandTotalSoum").Caption <> "---" Then
675: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblTotalForfaitSoum").Caption) - CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblGrandTotalSoum").Caption)
680: Else
685: dblTotal = 0
690: End If
		
695: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblProfitSoum").Caption = Conversion_Renamed(dblTotal, ModuleMain.enumConvert.MODE_ARGENT)
		
700: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If DR_ApercuProjet.Sections("Section2").Controls("lblTotalForfaitProj").Caption <> "---" And DR_ApercuProjet.Sections("Section2").Controls("lblGrandTotalProj").Caption <> "---" Then
705: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblTotalForfaitProj").Caption) - CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblGrandTotalProj").Caption)
710: Else
715: dblTotal = 0
720: End If
		
725: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblProfitProj").Caption = Conversion_Renamed(dblTotal, ModuleMain.enumConvert.MODE_ARGENT)
		
730: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_ApercuProjet.Show(VB6.FormShowConstants.Modal)
		
735: Call rstDS.Close()
740: 'UPGRADE_NOTE: Object rstDS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstDS = Nothing
		
745: Call Me.Close()
		
750: Exit Sub
		
AfficherErreur: 
		
755: Call AfficherErreur("frmChoixDateImpressionFacturation", "ImprimerPrixCoutant", Err, Erl())
	End Sub
	
	Private Sub RemplirRapportElectrique(ByVal sProjet As String)
		Dim DR_ApercuProjet As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjetElec As ADODB.Recordset
15: Dim rstSoumElec As ADODB.Recordset
20: Dim rstProjetPieces As ADODB.Recordset
25: Dim dblTotal As Double
30: Dim bSoumission As Boolean
35: Dim iNbrePersonne As Short
40: Dim dblHebergement As Double
45: Dim dblRepas As Double
50: Dim dblTransport As Double
55: Dim dblUniteMobile As Double
60: Dim dblPrixEmballage As Double
65: Dim dblTotalResteTemps As Double
70: Dim dblTotalManuel As Double
75: Dim dblTotalPieces As Double
		
80: rstProjetElec = New ADODB.Recordset
		
85: Call rstProjetElec.Open("SELECT * FROM GRB_ProjetElec WHERE IDProjet = 'E" & sProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
90: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblProjetElec").Caption = "E" & sProjet
		
95: If Not rstProjetElec.EOF Then
100: bSoumission = False
			
105: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetElec.Fields("IDSoumission").Value) Then
110: rstSoumElec = New ADODB.Recordset
				
115: Call rstSoumElec.Open("SELECT * FROM GRB_SoumissionElec WHERE IDSoumission = '" & rstProjetElec.Fields("IDSoumission").Value & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
120: If Not rstSoumElec.EOF Then
125: bSoumission = True
130: Else
135: Call rstSoumElec.Close()
140: 'UPGRADE_NOTE: Object rstSoumElec may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstSoumElec = Nothing
145: End If
150: End If
			
155: If bSoumission = True Then
160: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("MontantForfait").Value) Then
165: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblForfaitElecSoum").Caption = Conversion_Renamed(rstSoumElec.Fields("MontantForfait"), ModuleMain.enumConvert.MODE_ARGENT)
170: Else
175: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblForfaitElecSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
180: End If
				
185: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("TempsDessin").Value) Then
190: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecDessinSoum").Caption = rstSoumElec.Fields("TempsDessin").Value
195: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecDessinSoum").Caption = Conversion_Renamed(CDbl(rstSoumElec.Fields("TempsDessin").Value) * CDbl(rstSoumElec.Fields("TauxDessin").Value), ModuleMain.enumConvert.MODE_ARGENT)
200: Else
205: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecDessinSoum").Caption = "0"
210: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecDessinSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
215: End If
				
220: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("TempsFabrication").Value) Then
225: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFabricationSoum").Caption = rstSoumElec.Fields("TempsFabrication").Value
230: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecFabricationSoum").Caption = Conversion_Renamed(CDbl(rstSoumElec.Fields("TempsFabrication").Value) * CDbl(rstSoumElec.Fields("TauxFabrication").Value), ModuleMain.enumConvert.MODE_ARGENT)
235: Else
240: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFabricationSoum").Caption = "0"
245: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecFabricationSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
250: End If
				
255: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("TempsAssemblage").Value) Then
260: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecAssemblageSoum").Caption = rstSoumElec.Fields("TempsAssemblage").Value
265: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecAssemblageSoum").Caption = Conversion_Renamed(CDbl(rstSoumElec.Fields("TempsAssemblage").Value) * CDbl(rstSoumElec.Fields("TauxAssemblage").Value), ModuleMain.enumConvert.MODE_ARGENT)
270: Else
275: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecAssemblageSoum").Caption = "0"
280: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecAssemblageSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
285: End If
				
290: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("TempsProgInterface").Value) Then
295: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgInterfaceSoum").Caption = rstSoumElec.Fields("TempsProgInterface").Value
300: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgInterfaceSoum").Caption = Conversion_Renamed(CDbl(rstSoumElec.Fields("TempsProgInterface").Value) * CDbl(rstSoumElec.Fields("TauxProgInterface").Value), ModuleMain.enumConvert.MODE_ARGENT)
305: Else
310: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgInterfaceSoum").Caption = "0"
315: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgInterfaceSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
320: End If
				
325: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("TempsProgAutomate").Value) Then
330: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgAutomateSoum").Caption = rstSoumElec.Fields("TempsProgAutomate").Value
335: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgAutomateSoum").Caption = Conversion_Renamed(CDbl(rstSoumElec.Fields("TempsProgAutomate").Value) * CDbl(rstSoumElec.Fields("TauxProgAutomate").Value), ModuleMain.enumConvert.MODE_ARGENT)
340: Else
345: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgAutomateSoum").Caption = "0"
350: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgAutomateSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
355: End If
				
360: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("TempsProgRobot").Value) Then
365: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgRobotSoum").Caption = rstSoumElec.Fields("TempsProgRobot").Value
370: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgRobotSoum").Caption = Conversion_Renamed(CDbl(rstSoumElec.Fields("TempsProgRobot").Value) * CDbl(rstSoumElec.Fields("TauxProgRobot").Value), ModuleMain.enumConvert.MODE_ARGENT)
375: Else
380: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgRobotSoum").Caption = "0"
385: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgRobotSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
390: End If
				
395: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("TempsVision").Value) Then
400: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecVisionSoum").Caption = rstSoumElec.Fields("TempsVision").Value
405: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecVisionSoum").Caption = Conversion_Renamed(CDbl(rstSoumElec.Fields("TempsVision").Value) * CDbl(rstSoumElec.Fields("TauxVision").Value), ModuleMain.enumConvert.MODE_ARGENT)
410: Else
415: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecVisionSoum").Caption = "0"
420: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecVisionSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
425: End If
				
430: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("TempsTest").Value) Then
435: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTestSoum").Caption = rstSoumElec.Fields("TempsTest").Value
440: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecTestSoum").Caption = Conversion_Renamed(CDbl(rstSoumElec.Fields("TempsTest").Value) * CDbl(rstSoumElec.Fields("TauxTest").Value), ModuleMain.enumConvert.MODE_ARGENT)
445: Else
450: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTestSoum").Caption = rstSoumElec.Fields("TempsTest").Value
455: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecTestSoum").Caption = Conversion_Renamed(CDbl(rstSoumElec.Fields("TempsTest").Value) * CDbl(rstSoumElec.Fields("TauxTest").Value), ModuleMain.enumConvert.MODE_ARGENT)
460: End If
				
465: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("TempsInstallation").Value) Then
470: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecInstallationSoum").Caption = rstSoumElec.Fields("TempsInstallation").Value
475: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecInstallationSoum").Caption = Conversion_Renamed(CDbl(rstSoumElec.Fields("TempsInstallation").Value) * CDbl(rstSoumElec.Fields("TauxInstallation").Value), ModuleMain.enumConvert.MODE_ARGENT)
480: Else
485: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecInstallationSoum").Caption = "0"
490: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecInstallationSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
495: End If
				
500: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("TempsMiseService").Value) Then
505: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecMiseServiceSoum").Caption = rstSoumElec.Fields("TempsMiseService").Value
510: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecMiseServiceSoum").Caption = Conversion_Renamed(CDbl(rstSoumElec.Fields("TempsMiseService").Value) * CDbl(rstSoumElec.Fields("TauxMiseService").Value), ModuleMain.enumConvert.MODE_ARGENT)
515: Else
520: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecMiseServiceSoum").Caption = "0"
525: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecMiseServiceSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
530: End If
				
535: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("TempsFormation").Value) Then
540: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFormationSoum").Caption = rstSoumElec.Fields("TempsFormation").Value
545: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecFormationSoum").Caption = Conversion_Renamed(CDbl(rstSoumElec.Fields("TempsFormation").Value) * CDbl(rstSoumElec.Fields("TauxFormation").Value), ModuleMain.enumConvert.MODE_ARGENT)
550: Else
555: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFormationSoum").Caption = "0"
560: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecFormationSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
565: End If
				
570: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("TempsGestion").Value) Then
575: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecGestionSoum").Caption = rstSoumElec.Fields("TempsGestion").Value
580: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecGestionSoum").Caption = Conversion_Renamed(CDbl(rstSoumElec.Fields("TempsGestion").Value) * CDbl(rstSoumElec.Fields("TauxGestion").Value), ModuleMain.enumConvert.MODE_ARGENT)
585: Else
590: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecGestionSoum").Caption = "0"
595: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecGestionSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
600: End If
				
605: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("TempsShipping").Value) Then
610: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecShippingSoum").Caption = rstSoumElec.Fields("TempsShipping").Value
615: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecShippingSoum").Caption = Conversion_Renamed(CDbl(rstSoumElec.Fields("TempsShipping").Value) * CDbl(rstSoumElec.Fields("TauxShipping").Value), ModuleMain.enumConvert.MODE_ARGENT)
620: Else
625: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecShippingSoum").Caption = "0"
630: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecShippingSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
635: End If
				
640: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblPiecesElecSoum").Caption = Conversion_Renamed(rstSoumElec.Fields("total_piece"), ModuleMain.enumConvert.MODE_ARGENT)
645: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblImprevuElecSoum").Caption = Conversion_Renamed(rstSoumElec.Fields("total_imprevue"), ModuleMain.enumConvert.MODE_ARGENT)
				
650: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("NbrePersonne").Value) Then
655: iNbrePersonne = rstSoumElec.Fields("NbrePersonne").Value
660: Else
665: iNbrePersonne = 0
670: End If
				
675: Do While iNbrePersonne > 0
680: If iNbrePersonne >= 2 Then
685: dblHebergement = dblHebergement + rstSoumElec.Fields("TempsHebergement").Value * rstSoumElec.Fields("TauxHebergement2").Value
						
690: iNbrePersonne = iNbrePersonne - 2
695: Else
700: dblHebergement = dblHebergement + rstSoumElec.Fields("TempsHebergement").Value * rstSoumElec.Fields("TauxHebergement1").Value
						
705: iNbrePersonne = iNbrePersonne - 1
710: End If
715: Loop 
				
720: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("TempsRepas").Value) Then
725: dblRepas = CDbl(rstSoumElec.Fields("TempsRepas").Value) * CDbl(rstSoumElec.Fields("TauxRepas").Value) * CDbl(rstSoumElec.Fields("NbrePersonne").Value)
730: Else
735: dblRepas = 0
740: End If
				
745: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("TempsTransport").Value) Then
750: dblTransport = CDbl(rstSoumElec.Fields("TempsTransport").Value) * CDbl(rstSoumElec.Fields("TauxTransport").Value)
755: Else
760: dblTransport = 0
765: End If
				
770: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("TempsUniteMobile").Value) Then
775: dblUniteMobile = CDbl(rstSoumElec.Fields("TempsUniteMobile").Value) * CDbl(rstSoumElec.Fields("TauxUniteMobile").Value)
780: Else
785: dblUniteMobile = 0
790: End If
				
795: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumElec.Fields("PrixEmballage").Value) Then
800: dblPrixEmballage = CDbl(rstSoumElec.Fields("PrixEmballage").Value)
805: Else
810: dblPrixEmballage = 0
815: End If
				
820: dblTotalResteTemps = dblHebergement + dblRepas + dblTransport + dblUniteMobile + dblPrixEmballage
				
825: If IsNumeric(rstSoumElec.Fields("total_manuel").Value) Then
830: dblTotalManuel = CDbl(rstSoumElec.Fields("total_manuel").Value)
835: Else
840: dblTotalManuel = 0
845: End If
				
850: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblAutresElecSoum").Caption = Conversion_Renamed(dblTotalResteTemps + dblTotalManuel, ModuleMain.enumConvert.MODE_ARGENT)
				
855: Call rstSoumElec.Close()
860: 'UPGRADE_NOTE: Object rstSoumElec may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstSoumElec = Nothing
865: Else
870: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecDessinSoum").Caption = "---"
875: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecDessinSoum").Caption = "---"
				
880: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFabricationSoum").Caption = "---"
885: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecFabricationSoum").Caption = "---"
				
890: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecAssemblageSoum").Caption = "---"
895: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecAssemblageSoum").Caption = "---"
				
900: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgInterfaceSoum").Caption = "---"
905: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgInterfaceSoum").Caption = "---"
				
910: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgAutomateSoum").Caption = "---"
915: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgAutomateSoum").Caption = "---"
				
920: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgRobotSoum").Caption = "---"
925: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgRobotSoum").Caption = "---"
				
930: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecVisionSoum").Caption = "---"
935: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecVisionSoum").Caption = "---"
				
940: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTestSoum").Caption = "---"
945: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecTestSoum").Caption = "---"
				
950: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecInstallationSoum").Caption = "---"
955: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecInstallationSoum").Caption = "---"
				
960: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecMiseServiceSoum").Caption = "---"
965: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecMiseServiceSoum").Caption = "---"
				
970: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFormationSoum").Caption = "---"
975: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecFormationSoum").Caption = "---"
				
980: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecGestionSoum").Caption = "---"
985: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecGestionSoum").Caption = "---"
				
990: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecGestionSoum").Caption = "---"
995: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecGestionSoum").Caption = "---"
				
1000: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblPiecesElecSoum").Caption = "---"
1005: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblImprevuElecSoum").Caption = "---"
1010: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblAutresElecSoum").Caption = "---"
1015: End If
			
1020: Call RemplirTempsReelsElec("E" & sProjet)
			
1025: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetElec.Fields("MontantForfait").Value) Then
1030: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblForfaitElecProj").Caption = Conversion_Renamed(rstProjetElec.Fields("MontantForfait"), ModuleMain.enumConvert.MODE_ARGENT)
1035: Else
1040: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblForfaitElecProj").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
1045: End If
			
1050: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetElec.Fields("TauxDessin").Value) Then
1055: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecDessinProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecDessinProj").Caption) * CDbl(rstProjetElec.Fields("TauxDessin")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecDessinProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecDessinProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1060: Else
1065: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecDessinProj").Caption = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
1070: End If
			
1075: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetElec.Fields("TauxFabrication").Value) Then
1080: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecFabricationProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFabricationProj").Caption) * CDbl(rstProjetElec.Fields("TauxFabrication")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecFabricationProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFabricationProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1085: Else
1090: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecFabricationProj").Caption = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
1095: End If
			
1100: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetElec.Fields("TauxAssemblage").Value) Then
1105: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecAssemblageProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecAssemblageProj").Caption) * CDbl(rstProjetElec.Fields("TauxAssemblage")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecAssemblageProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecAssemblageProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1110: Else
1115: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecAssemblageProj").Caption = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
1120: End If
			
1125: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetElec.Fields("TauxProgInterface").Value) Then
1130: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgInterfaceProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgInterfaceProj").Caption) * CDbl(rstProjetElec.Fields("TauxProgInterface")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgInterfaceProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgInterfaceProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1135: Else
1140: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgInterfaceProj").Caption = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
1145: End If
			
1150: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetElec.Fields("TauxProgAutomate").Value) Then
1155: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgAutomateProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgAutomateProj").Caption) * CDbl(rstProjetElec.Fields("TauxProgAutomate")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgAutomateProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgAutomateProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1160: Else
1165: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgAutomateProj").Caption = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
1170: End If
			
1175: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetElec.Fields("TauxProgRobot").Value) Then
1180: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgRobotProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgRobotProj").Caption) * CDbl(rstProjetElec.Fields("TauxProgRobot")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgRobotProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgRobotProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1185: Else
1190: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgRobotProj").Caption = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
1195: End If
			
1200: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetElec.Fields("TauxVision").Value) Then
1205: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecVisionProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecVisionProj").Caption) * CDbl(rstProjetElec.Fields("TauxVision")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecVisionProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecVisionProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1210: Else
1215: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecVisionProj").Caption = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
1220: End If
			
1225: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetElec.Fields("TauxTest").Value) Then
1230: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecTestProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTestProj").Caption) * CDbl(rstProjetElec.Fields("TauxTest")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecTestProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTestProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1235: Else
1240: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecTestProj").Caption = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
1245: End If
			
1250: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetElec.Fields("TauxInstallation").Value) Then
1255: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecInstallationProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecInstallationProj").Caption) * CDbl(rstProjetElec.Fields("TauxInstallation")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecInstallationProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecInstallationProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1260: Else
1265: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecInstallationProj").Caption = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
1270: End If
			
1275: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetElec.Fields("TauxMiseService").Value) Then
1280: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecMiseServiceProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecMiseServiceProj").Caption) * CDbl(rstProjetElec.Fields("TauxMiseService")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecMiseServiceProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecMiseServiceProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1285: Else
1290: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecMiseServiceProj").Caption = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
1295: End If
			
1300: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetElec.Fields("TauxFormation").Value) Then
1305: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecFormationProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFormationProj").Caption) * CDbl(rstProjetElec.Fields("TauxFormation")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecFormationProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFormationProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1310: Else
1315: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecFormationProj").Caption = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
1320: End If
			
1325: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetElec.Fields("TauxGestion").Value) Then
1330: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecGestionProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecGestionProj").Caption) * CDbl(rstProjetElec.Fields("TauxGestion")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecGestionProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecGestionProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1335: Else
1340: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecGestionProj").Caption = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
1345: End If
			
1350: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetElec.Fields("TauxShipping").Value) Then
1355: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecShippingProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecShippingProj").Caption) * CDbl(rstProjetElec.Fields("TauxShipping")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecShippingProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecShippingProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1360: Else
1365: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecShippingProj").Caption = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
1370: End If
			'''''''''''''''''''''''''''''''''
			'''''''''''''''''''''''''''''''''
			' ajout pour développement expérimental
			
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetElec.Fields("TauxGestion").Value) Then
				'DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecRechercheProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecRechercheProj").Caption) * CDbl(rstProjetElec.Fields("TauxGestion")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecRechercheProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecRechercheProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecRechercheProj").Caption = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
			End If
			''''''''''''''''''''''''''''''''''''''
			''''''''''''''''''''''''
			
			
			
			
1375: rstProjetPieces = New ADODB.Recordset
			
1380: If optChoix(I_OPT_PROJET_ENTIER).Checked = True Then
1385: Call rstProjetPieces.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = 'E" & sProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
1390: Else
1395: If VB.Right(sProjet, 2) = "99" Then
1400: Call rstProjetPieces.Open("SELECT * FROM GRB_Projet_Pieces WHERE Left(IDProjet, 6) = '" & VB.Left("E" & sProjet, 6) & "' AND DateRéception BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' AND PieceExtraNonChargeable = False AND PieceExtraChargeable = False", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
1405: Else
1410: Call rstProjetPieces.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = 'E" & sProjet & "' AND DateRéception BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
1415: End If
1420: End If
			
1425: Do While Not rstProjetPieces.EOF
1430: If Trim(rstProjetPieces.Fields("Prix_total").Value) <> vbNullString Then
					'On additionne le prix total
1435: dblTotalPieces = dblTotalPieces + CDbl(rstProjetPieces.Fields("Prix_total").Value) - CDbl(rstProjetPieces.Fields("Profit_Argent").Value)
1440: End If
				
1445: Call rstProjetPieces.MoveNext()
1450: Loop 
			
1455: Call rstProjetPieces.Close()
1460: 'UPGRADE_NOTE: Object rstProjetPieces may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstProjetPieces = Nothing
			
1465: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblPiecesElecProj").Caption = Conversion_Renamed(dblTotalPieces, ModuleMain.enumConvert.MODE_ARGENT)
			'930       DR_ApercuProjet.Sections("Section2").Controls("lblImprevuElecProj").Caption = Conversion(rstProjetElec.Fields("total_imprevue"), MODE_ARGENT)
1470: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblImprevuElecProj").Caption = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
			
1475: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetElec.Fields("PrixEmballage").Value) Then
1480: dblPrixEmballage = CDbl(rstProjetElec.Fields("PrixEmballage").Value)
1485: Else
1490: dblPrixEmballage = 0
1495: End If
			
1500: dblTotalResteTemps = dblPrixEmballage
			
1505: If IsNumeric(rstProjetElec.Fields("total_manuel").Value) Then
1510: dblTotalManuel = CDbl(rstProjetElec.Fields("total_manuel").Value)
1515: Else
1520: dblTotalManuel = 0
1525: End If
			
1530: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblAutresElecProj").Caption = Conversion_Renamed(dblTotalResteTemps + dblTotalManuel, ModuleMain.enumConvert.MODE_ARGENT)
			
			'Calcul des totaux
			
			'Total des temps
1535: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecDessinSoum").Caption <> "---" Then
1540: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecDessinSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFabricationSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecAssemblageSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgInterfaceSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgAutomateSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgRobotSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecVisionSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTestSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecInstallationSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecMiseServiceSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFormationSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecGestionSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecShippingSoum").Caption)
				
1545: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTotalSoum").Caption = dblTotal
1550: Else
1555: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTotalSoum").Caption = "---"
1560: End If
			
1565: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecDessinSoum").Caption <> "---" Then
1570: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecDessinSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecFabricationSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecAssemblageSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgInterfaceSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgAutomateSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgRobotSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecVisionSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecTestSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecInstallationSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecMiseServiceSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecFormationSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecGestionSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecShippingSoum").Caption)
				
1575: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecTotalSoum").Caption = Conversion_Renamed(dblTotal, ModuleMain.enumConvert.MODE_ARGENT)
1580: Else
1585: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecTotalSoum").Caption = "---"
1590: End If
			''''''''''''''
			' calcul du total des heures
			'''''''''''''''''''''
1595: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecDessinProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFabricationProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecAssemblageProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgInterfaceProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgAutomateProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgRobotProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecVisionProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTestProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecInstallationProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecMiseServiceProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFormationProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecGestionProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecShippingProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecRechercheProj").Caption)
			
1600: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTotalProj").Caption = dblTotal
			''''''''''''''''''''''''''''''
			'Calcul du total de l'argent
			'''''''''''''''''''''''''''''''
1605: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecDessinProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecFabricationProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecAssemblageProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgInterfaceProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgAutomateProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecProgRobotProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecVisionProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecTestProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecInstallationProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecMiseServiceProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecFormationProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecGestionProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecShippingProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecRechercheProj").Caption)
			
1610: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecTotalProj").Caption = Conversion_Renamed(dblTotal, ModuleMain.enumConvert.MODE_ARGENT)
			
			'Calcul des prix totaux
1615: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecTotalSoum").Caption <> "---" Then
1620: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecTotalSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblPiecesElecSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblImprevuElecSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblAutresElecSoum").Caption)
				
1625: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblTotalElecSoum").Caption = Conversion_Renamed(dblTotal, ModuleMain.enumConvert.MODE_ARGENT)
1630: Else
1635: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblTotalElecSoum").Caption = "---"
1640: End If
			
1645: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentElecTotalProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblPiecesElecProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblImprevuElecProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblAutresElecProj").Caption)
			
1650: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblTotalElecProj").Caption = Conversion_Renamed(dblTotal, ModuleMain.enumConvert.MODE_ARGENT)
1655: End If
		
1660: Call rstProjetElec.Close()
1665: 'UPGRADE_NOTE: Object rstProjetElec may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjetElec = Nothing
		
1670: Exit Sub
		
AfficherErreur: 
		
1675: Call AfficherErreur("frmChoixDateImpressionFacturation", "RemplirRapportElectrique", Err, Erl())
	End Sub
	
	Private Sub RemplirRapportMecanique(ByVal sProjet As String)
		Dim DR_ApercuProjet As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjetMec As ADODB.Recordset
15: Dim rstSoumMec As ADODB.Recordset
20: Dim rstProjetPieces As ADODB.Recordset
25: Dim dblTotal As Double
30: Dim bSoumission As Boolean
35: Dim iNbrePersonne As Short
40: Dim dblHebergement As Double
45: Dim dblRepas As Double
50: Dim dblTransport As Double
55: Dim dblUniteMobile As Double
60: Dim dblPrixEmballage As Double
65: Dim dblTotalResteTemps As Double
70: Dim dblTotalManuel As Double
75: Dim dblTotalPieces As Double
		
80: rstProjetMec = New ADODB.Recordset
		
85: Call rstProjetMec.Open("SELECT * FROM GRB_ProjetMec WHERE IDProjet = 'M" & sProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
90: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblProjetMec").Caption = "M" & sProjet
		
95: If Not rstProjetMec.EOF Then
100: bSoumission = False
			
105: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetMec.Fields("IDSoumission").Value) Then
110: rstSoumMec = New ADODB.Recordset
				
115: Call rstSoumMec.Open("SELECT * FROM GRB_SoumissionMec WHERE IDSoumission = '" & rstProjetMec.Fields("IDSoumission").Value & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
120: If Not rstSoumMec.EOF Then
125: bSoumission = True
130: Else
135: Call rstSoumMec.Close()
140: 'UPGRADE_NOTE: Object rstSoumMec may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstSoumMec = Nothing
145: End If
150: End If
			
155: If bSoumission = True Then
160: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumMec.Fields("MontantForfait").Value) Then
165: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblForfaitMecSoum").Caption = Conversion_Renamed(rstSoumMec.Fields("MontantForfait"), ModuleMain.enumConvert.MODE_ARGENT)
170: Else
175: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblForfaitMecSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
180: End If
				
185: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumMec.Fields("TempsDessin").Value) Then
190: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecDessinSoum").Caption = rstSoumMec.Fields("TempsDessin").Value
195: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecDessinSoum").Caption = Conversion_Renamed(CDbl(rstSoumMec.Fields("TempsDessin").Value) * CDbl(rstSoumMec.Fields("TauxDessin").Value), ModuleMain.enumConvert.MODE_ARGENT)
200: Else
205: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecDessinSoum").Caption = "0"
210: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecDessinSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
215: End If
				
220: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumMec.Fields("TempsCoupe").Value) Then
225: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecCoupeSoum").Caption = rstSoumMec.Fields("TempsCoupe").Value
230: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecCoupeSoum").Caption = Conversion_Renamed(CDbl(rstSoumMec.Fields("TempsCoupe").Value) * CDbl(rstSoumMec.Fields("TauxCoupe").Value), ModuleMain.enumConvert.MODE_ARGENT)
235: Else
240: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecCoupeSoum").Caption = "0"
245: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecCoupeSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
250: End If
				
255: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumMec.Fields("TempsMachinage").Value) Then
260: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecMachinageSoum").Caption = rstSoumMec.Fields("TempsMachinage").Value
265: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecMachinageSoum").Caption = Conversion_Renamed(CDbl(rstSoumMec.Fields("TempsMachinage").Value) * CDbl(rstSoumMec.Fields("TauxMachinage").Value), ModuleMain.enumConvert.MODE_ARGENT)
270: Else
275: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecMachinageSoum").Caption = "0"
280: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecMachinageSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
285: End If
				
290: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumMec.Fields("TempsSoudure").Value) Then
295: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecSoudureSoum").Caption = rstSoumMec.Fields("TempsSoudure").Value
300: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecSoudureSoum").Caption = Conversion_Renamed(CDbl(rstSoumMec.Fields("TempsSoudure").Value) * CDbl(rstSoumMec.Fields("TauxSoudure").Value), ModuleMain.enumConvert.MODE_ARGENT)
305: Else
310: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecSoudureSoum").Caption = "0"
315: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecSoudureSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
320: End If
				
325: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumMec.Fields("TempsAssemblage").Value) Then
330: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecAssemblageSoum").Caption = rstSoumMec.Fields("TempsAssemblage").Value
335: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecAssemblageSoum").Caption = Conversion_Renamed(CDbl(rstSoumMec.Fields("TempsAssemblage").Value) * CDbl(rstSoumMec.Fields("TauxAssemblage").Value), ModuleMain.enumConvert.MODE_ARGENT)
340: Else
345: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecAssemblageSoum").Caption = "0"
350: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecAssemblageSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
355: End If
				
360: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumMec.Fields("TempsPeinture").Value) Then
365: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecPeintureSoum").Caption = rstSoumMec.Fields("TempsPeinture").Value
370: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecPeintureSoum").Caption = Conversion_Renamed(CDbl(rstSoumMec.Fields("TempsPeinture").Value) * CDbl(rstSoumMec.Fields("TauxPeinture").Value), ModuleMain.enumConvert.MODE_ARGENT)
375: Else
380: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecPeintureSoum").Caption = "0"
385: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecPeintureSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
390: End If
				
395: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumMec.Fields("TempsTest").Value) Then
400: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTestSoum").Caption = rstSoumMec.Fields("TempsTest").Value
405: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecTestSoum").Caption = Conversion_Renamed(CDbl(rstSoumMec.Fields("TempsTest").Value) * CDbl(rstSoumMec.Fields("TauxTest").Value), ModuleMain.enumConvert.MODE_ARGENT)
410: Else
415: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTestSoum").Caption = "0"
420: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecTestSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
425: End If
				
430: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumMec.Fields("TempsInstallation").Value) Then
435: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecInstallationSoum").Caption = rstSoumMec.Fields("TempsInstallation").Value
440: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecInstallationSoum").Caption = Conversion_Renamed(CDbl(rstSoumMec.Fields("TempsInstallation").Value) * CDbl(rstSoumMec.Fields("TauxInstallation").Value), ModuleMain.enumConvert.MODE_ARGENT)
445: Else
450: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecInstallationSoum").Caption = "0"
455: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecInstallationSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
460: End If
				
465: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumMec.Fields("TempsFormation").Value) Then
470: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecFormationSoum").Caption = rstSoumMec.Fields("TempsFormation").Value
475: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecFormationSoum").Caption = Conversion_Renamed(CDbl(rstSoumMec.Fields("TempsFormation").Value) * CDbl(rstSoumMec.Fields("TauxFormation").Value), ModuleMain.enumConvert.MODE_ARGENT)
480: Else
485: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecFormationSoum").Caption = "0"
490: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecFormationSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
495: End If
				
500: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumMec.Fields("TempsGestion").Value) Then
505: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecGestionSoum").Caption = rstSoumMec.Fields("TempsGestion").Value
510: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecGestionSoum").Caption = Conversion_Renamed(CDbl(rstSoumMec.Fields("TempsGestion").Value) * CDbl(rstSoumMec.Fields("TauxGestion").Value), ModuleMain.enumConvert.MODE_ARGENT)
515: Else
520: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecGestionSoum").Caption = "0"
525: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecGestionSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
530: End If
				
535: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSoumMec.Fields("TempsShipping").Value) Then
540: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecShippingSoum").Caption = rstSoumMec.Fields("TempsShipping").Value
545: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecShippingSoum").Caption = Conversion_Renamed(CDbl(rstSoumMec.Fields("TempsShipping").Value) * CDbl(rstSoumMec.Fields("TauxShipping").Value), ModuleMain.enumConvert.MODE_ARGENT)
550: Else
555: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecShippingSoum").Caption = "0"
560: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecShippingSoum").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
565: End If
				
570: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblPiecesMecSoum").Caption = Conversion_Renamed(rstSoumMec.Fields("total_piece"), ModuleMain.enumConvert.MODE_ARGENT)
575: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblImprevuMecSoum").Caption = Conversion_Renamed(rstSoumMec.Fields("total_imprevue"), ModuleMain.enumConvert.MODE_ARGENT)
				
580: iNbrePersonne = rstSoumMec.Fields("NbrePersonne").Value
				
585: Do While iNbrePersonne > 0
590: If iNbrePersonne >= 2 Then
595: dblHebergement = dblHebergement + rstSoumMec.Fields("TempsHebergement").Value * rstSoumMec.Fields("TauxHebergement2").Value
						
600: iNbrePersonne = iNbrePersonne - 2
605: Else
610: dblHebergement = dblHebergement + rstSoumMec.Fields("TempsHebergement").Value * rstSoumMec.Fields("TauxHebergement1").Value
						
615: iNbrePersonne = iNbrePersonne - 1
620: End If
625: Loop 
				
630: dblRepas = CDbl(rstSoumMec.Fields("TempsRepas").Value) * CDbl(rstSoumMec.Fields("TauxRepas").Value) * CDbl(rstSoumMec.Fields("NbrePersonne").Value)
635: dblTransport = CDbl(rstSoumMec.Fields("TempsTransport").Value) * CDbl(rstSoumMec.Fields("TauxTransport").Value)
640: dblUniteMobile = CDbl(rstSoumMec.Fields("TempsUniteMobile").Value) * CDbl(rstSoumMec.Fields("TauxUniteMobile").Value)
				
645: If IsNumeric(rstSoumMec.Fields("PrixEmballage").Value) Then
650: dblPrixEmballage = CDbl(rstSoumMec.Fields("PrixEmballage").Value)
655: Else
660: dblPrixEmballage = 0
665: End If
				
670: dblTotalResteTemps = dblHebergement + dblRepas + dblTransport + dblUniteMobile + dblPrixEmballage
				
675: If IsNumeric(rstSoumMec.Fields("total_manuel").Value) Then
680: dblTotalManuel = CDbl(rstSoumMec.Fields("total_manuel").Value)
685: Else
690: dblTotalManuel = 0
695: End If
				
700: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblAutresMecSoum").Caption = Conversion_Renamed(dblTotalResteTemps + dblTotalManuel, ModuleMain.enumConvert.MODE_ARGENT)
				
705: Call rstSoumMec.Close()
710: 'UPGRADE_NOTE: Object rstSoumMec may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstSoumMec = Nothing
715: Else
720: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecDessinSoum").Caption = "---"
725: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecDessinSoum").Caption = "---"
				
730: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecCoupeSoum").Caption = "---"
735: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecCoupeSoum").Caption = "---"
				
740: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecMachinageSoum").Caption = "---"
745: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecMachinageSoum").Caption = "---"
				
750: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecSoudureSoum").Caption = "---"
755: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecSoudureSoum").Caption = "---"
				
760: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecAssemblageSoum").Caption = "---"
765: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecAssemblageSoum").Caption = "---"
				
770: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecPeintureSoum").Caption = "---"
775: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecPeintureSoum").Caption = "---"
				
780: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTestSoum").Caption = "---"
785: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecTestSoum").Caption = "---"
				
790: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecInstallationSoum").Caption = "---"
795: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecInstallationSoum").Caption = "---"
				
800: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecFormationSoum").Caption = "---"
805: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecFormationSoum").Caption = "---"
				
810: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecGestionSoum").Caption = "---"
815: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecGestionSoum").Caption = "---"
				
820: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecShippingSoum").Caption = "---"
825: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecShippingSoum").Caption = "---"
				
830: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblPiecesMecSoum").Caption = "---"
835: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblImprevuMecSoum").Caption = "---"
840: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblAutresMecSoum").Caption = "---"
845: End If
			
850: Call RemplirTempsReelsMec("M" & sProjet)
			
			'''''''''''''''''''
			'''', calcul de l'argent
			
			
855: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetMec.Fields("MontantForfait").Value) Then
860: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblForfaitMecProj").Caption = Conversion_Renamed(rstProjetMec.Fields("MontantForfait"), ModuleMain.enumConvert.MODE_ARGENT)
865: Else
870: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblForfaitMecProj").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
875: End If
			
880: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetMec.Fields("TauxDessin").Value) Then
885: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecDessinProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecDessinProj").Caption) * CDbl(rstProjetMec.Fields("TauxDessin")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecDessinProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecDessinProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
890: Else
895: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecDessinProj").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
900: End If
			
905: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetMec.Fields("TauxCoupe").Value) Then
910: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecCoupeProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecCoupeProj").Caption) * CDbl(rstProjetMec.Fields("TauxCoupe")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecCoupeProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecCoupeProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
915: Else
920: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecCoupeProj").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
925: End If
			
930: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetMec.Fields("TauxMachinage").Value) Then
935: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecMachinageProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecMachinageProj").Caption) * CDbl(rstProjetMec.Fields("TauxMachinage")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecMachinageProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecMachinageProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
940: Else
945: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecMachinageProj").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
950: End If
			
955: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetMec.Fields("TauxSoudure").Value) Then
960: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecSoudureProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecSoudureProj").Caption) * CDbl(rstProjetMec.Fields("TauxSoudure")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecSoudureProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecSoudureProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
965: Else
970: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecSoudureProj").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
975: End If
			
980: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetMec.Fields("TauxAssemblage").Value) Then
985: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecAssemblageProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecAssemblageProj").Caption) * CDbl(rstProjetMec.Fields("TauxAssemblage")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecAssemblageProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecAssemblageProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
990: Else
995: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecAssemblageProj").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
1000: End If
			
1005: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetMec.Fields("TauxPeinture").Value) Then
1010: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecPeintureProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecPeintureProj").Caption) * CDbl(rstProjetMec.Fields("TauxPeinture")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecPeintureProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecPeintureProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1015: Else
1020: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecPeintureProj").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
1025: End If
			
1030: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetMec.Fields("TauxTest").Value) Then
1035: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecTestProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTestProj").Caption) * CDbl(rstProjetMec.Fields("TauxTest")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecTestProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTestProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1040: Else
1045: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecTestProj").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
1050: End If
			
1055: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetMec.Fields("TauxInstallation").Value) Then
1060: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecInstallationProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecInstallationProj").Caption) * CDbl(rstProjetMec.Fields("TauxInstallation")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecInstallationProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecInstallationProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1065: Else
1070: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecInstallationProj").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
1075: End If
			
1080: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetMec.Fields("TauxFormation").Value) Then
1085: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecFormationProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecFormationProj").Caption) * CDbl(rstProjetMec.Fields("TauxFormation")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecFormationProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecFormationProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1090: Else
1095: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecFormationProj").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
1100: End If
			
1105: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetMec.Fields("TauxGestion").Value) Then
1110: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecGestionProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecGestionProj").Caption) * CDbl(rstProjetMec.Fields("TauxGestion")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecGestionProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecGestionProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1115: Else
1120: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecGestionProj").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
1125: End If
			
1130: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetMec.Fields("TauxShipping").Value) Then
1135: 'DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecShippingProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecShippingProj").Caption) * CDbl(rstProjetMec.Fields("TauxShipping")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecShippingProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecShippingProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
1140: Else
1145: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecShippingProj").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
1150: End If
			
			
			
			''''''',''''''''''''''''''''''''
			''''ajout pour develloppement experimental
			'''''''''''''''''''''''''''''''''''''''
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjetMec.Fields("TauxGestion").Value) Then
				'DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecRechercheProj").Caption = Conversion(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecRechercheProj").Caption) * CDbl(rstProjetMec.Fields("TauxGestion")), MODE_ARGENT)
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecRechercheProj").Caption = Conversion_Renamed(CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecRechercheProj").Caption) * CDbl(50), ModuleMain.enumConvert.MODE_ARGENT)
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecRechercheProj").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
			End If
			
			'''''''''''''''''''''''''''
			'''''''''''''''''''''''''
			
			
			
1155: rstProjetPieces = New ADODB.Recordset
			
1160: If optChoix(I_OPT_PROJET_ENTIER).Checked = True Then
1165: Call rstProjetPieces.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = 'M" & sProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
1170: Else
1175: If VB.Right(sProjet, 2) = "99" Then
1180: Call rstProjetPieces.Open("SELECT * FROM GRB_Projet_Pieces WHERE Left(IDProjet, 6) = '" & VB.Left("M" & sProjet, 6) & "' AND DateRéception BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' AND PieceExtraNonChargeable = False AND PieceExtraChargeable = False", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
1185: Else
1190: Call rstProjetPieces.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = 'M" & sProjet & "' AND DateRéception BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
1195: End If
1200: End If
			
1205: Do While Not rstProjetPieces.EOF
1210: If Trim(rstProjetPieces.Fields("Prix_total").Value) <> vbNullString Then
					'On additionne le prix total
1215: dblTotalPieces = dblTotalPieces + CDbl(rstProjetPieces.Fields("Prix_total").Value) - CDbl(rstProjetPieces.Fields("Profit_argent").Value)
1220: End If
				
1225: Call rstProjetPieces.MoveNext()
1230: Loop 
			
1235: Call rstProjetPieces.Close()
1240: 'UPGRADE_NOTE: Object rstProjetPieces may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstProjetPieces = Nothing
			
1245: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblPiecesMecProj").Caption = Conversion_Renamed(dblTotalPieces, ModuleMain.enumConvert.MODE_ARGENT)
			'675       DR_ApercuProjet.Sections("Section2").Controls("lblImprevuMecProj").Caption = Conversion(rstProjetMec.Fields("total_imprevue"), MODE_ARGENT)
1250: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblImprevuMecProj").Caption = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
			
1255: If IsNumeric(rstProjetMec.Fields("PrixEmballage").Value) Then
1260: dblPrixEmballage = CDbl(rstProjetMec.Fields("PrixEmballage").Value)
1265: Else
1270: dblPrixEmballage = 0
1275: End If
			
1280: dblTotalResteTemps = dblPrixEmballage
			
1285: If IsNumeric(rstProjetMec.Fields("total_manuel").Value) Then
1290: dblTotalManuel = CDbl(rstProjetMec.Fields("total_manuel").Value)
1295: Else
1300: dblTotalManuel = 0
1305: End If
			
1310: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblAutresMecProj").Caption = Conversion_Renamed(dblTotalResteTemps + dblTotalManuel, ModuleMain.enumConvert.MODE_ARGENT)
			
			'Calcul des totaux
			
			'Total des temps
1315: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecDessinSoum").Caption <> "---" Then
1320: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecDessinSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecCoupeSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecMachinageSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecSoudureSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecAssemblageSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecPeintureSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTestSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecInstallationSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecFormationSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecGestionSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecShippingSoum").Caption)
				
1325: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTotalSoum").Caption = dblTotal
1330: Else
1335: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTotalSoum").Caption = "---"
1340: End If
			
1345: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecDessinSoum").Caption <> "---" Then
1350: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecDessinSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecCoupeSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecMachinageSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecSoudureSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecAssemblageSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecPeintureSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecTestSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecInstallationSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecFormationSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecGestionSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecShippingSoum").Caption)
				
1355: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecTotalSoum").Caption = Conversion_Renamed(dblTotal, ModuleMain.enumConvert.MODE_ARGENT)
1360: Else
1365: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecTotalSoum").Caption = "---"
1370: End If
			
			'''''''
			''' Total heure mécanique
			''''''''''''''''''''''
1375: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecDessinProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecCoupeProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecMachinageProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecSoudureProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecAssemblageProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecPeintureProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTestProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecInstallationProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecFormationProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecGestionProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecShippingProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecRechercheProj").Caption)
			
			
1380: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTotalProj").Caption = dblTotal
			'''''''''''''''''''''''
			'''' total argent mécanique
			'''''''''''''''''''''
			
1385: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecDessinProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecCoupeProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecMachinageProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecSoudureProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecAssemblageProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecPeintureProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecTestProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecInstallationProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecFormationProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecGestionProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecShippingProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecRechercheProj").Caption)
			
			
1390: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecTotalProj").Caption = Conversion_Renamed(dblTotal, ModuleMain.enumConvert.MODE_ARGENT)
			
			'Calcul des prix totaux
1395: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecTotalSoum").Caption <> "---" Then
1400: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecTotalSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblPiecesMecSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblImprevuMecSoum").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblAutresMecSoum").Caption)
				
1405: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblTotalMecSoum").Caption = Conversion_Renamed(dblTotal, ModuleMain.enumConvert.MODE_ARGENT)
1410: Else
1415: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_ApercuProjet.Sections("Section2").Controls("lblTotalMecSoum").Caption = "---"
1420: End If
			
1425: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblArgentMecTotalProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblPiecesMecProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblImprevuMecProj").Caption) + CDbl(DR_ApercuProjet.Sections("Section2").Controls("lblAutresMecProj").Caption)
			
1430: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ApercuProjet.Sections("Section2").Controls("lblTotalMecProj").Caption = Conversion_Renamed(dblTotal, ModuleMain.enumConvert.MODE_ARGENT)
1435: End If
		
1440: Exit Sub
		
AfficherErreur: 
		
1445: Call AfficherErreur("frmChoixDateImpressionFacturation", "RemplirRapportMecanique", Err, Erl())
	End Sub
	
	Private Sub RemplirTempsReelsElec(ByVal sProjet As String)
		Dim DR_ApercuProjet As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPunch As ADODB.Recordset
15: Dim sDateDebut As String
20: Dim sDateFin As String
25: Dim sTotal As String
30: Dim sFilterNoProjet As String
		Dim Compile1 As String
		Dim Compile2 As String
		
		Compile1 = CStr(0)
		Compile2 = CStr(0)
		
		
35: If VB.Right(sProjet, 2) = "99" Then
40: sFilterNoProjet = "LEFT(NoProjet, 6) = '" & VB.Left(sProjet, 6) & "'"
45: Else
50: sFilterNoProjet = "NoProjet = '" & sProjet & "'"
55: End If
		
60: sDateDebut = "TIMESERIAL(Left(GRB_Punch.HeureDébut,2),RIGHT(GRB_Punch.HeureDébut,2),0)"
		
65: sDateFin = "TIMESERIAL(Left(GRB_Punch.HeureFin,2),RIGHT(GRB_Punch.HeureFin,2),0)"
		
70: sTotal = "(SUM(" & sDateFin & " - " & sDateDebut & ")* 24) As Total"
		
75: rstPunch = New ADODB.Recordset
		
80: If optChoix(I_OPT_PROJET_ENTIER).Checked = True Then
85: Call rstPunch.Open("SELECT Type, " & sTotal & " FROM GRB_Punch WHERE " & sFilterNoProjet & " And HeureFin is not null AND HeureDébut is not null GROUP BY Type", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
90: Else
95: Call rstPunch.Open("SELECT Type, " & sTotal & " FROM GRB_Punch WHERE " & sFilterNoProjet & " AND HeureFin Is Not Null AND HeureDébut Is not Null AND [Date] BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' GROUP BY Type", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
100: End If
		
105: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecDessinProj").Caption = "0"
110: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFabricationProj").Caption = "0"
115: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecAssemblageProj").Caption = "0"
120: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgInterfaceProj").Caption = "0"
125: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgAutomateProj").Caption = "0"
130: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgRobotProj").Caption = "0"
135: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecVisionProj").Caption = "0"
140: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTestProj").Caption = "0"
145: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecInstallationProj").Caption = "0"
150: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecMiseServiceProj").Caption = "0"
155: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFormationProj").Caption = "0"
160: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecGestionProj").Caption = "0"
165: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecShippingProj").Caption = "0"
		'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecRechercheProj").Caption = "0"
		
170: Do While Not rstPunch.EOF
175: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("Total").Value) Then
180: Select Case rstPunch.Fields("Type").Value
					Case "Dessin"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecDessinProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
185: Case "Fabrication"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFabricationProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
190: Case "Assemblage"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecAssemblageProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
195: Case "ProgInterface"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgInterfaceProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
200: Case "ProgAutomate"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgAutomateProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
205: Case "ProgRobot"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecProgRobotProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
210: Case "Vision"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecVisionProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
215: Case "Test"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecTestProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
220: Case "Installation"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecInstallationProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
225: Case "MiseService"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecMiseServiceProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
230: Case "Formation"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecFormationProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
235: Case "Gestion"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecGestionProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
240: Case "Shipping"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecShippingProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
					Case "Prototypage-Dévelloppement expérimental" : Compile1 = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
					Case "" : Compile2 = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
						
						''''''''''''''''''''''''''''''''''''''''''''
						''''''''''''''''''''''''''''''''''''''''''''
						'ajout prototypage expérimental
						
						
						
						'''''''''''''''''''''' modif alex 6 fevrier 2012
						'''''''''''''''''''''''''''''''''''''''''''''''''''''
						
						
245: End Select
250: End If
			
255: Call rstPunch.MoveNext()
260: Loop 
		
		'''''''''''''''''''''''
		' On addtionne develloppement avec aucun type ensemble
		'''''''''''''''
		'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresElecRechercheProj").Caption = CStr(CDbl(Compile1) + CDbl(Compile2))
		
		
		
265: Call rstPunch.Close()
270: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPunch = Nothing
		
275: Exit Sub
		
AfficherErreur: 
		
280: Call AfficherErreur("frmProjSoumElecTemps", "RemplirTempsReelsElec", Err, Erl())
	End Sub
	
	Private Sub RemplirTempsReelsMec(ByVal sProjet As String)
		Dim DR_ApercuProjet As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPunch As ADODB.Recordset
15: Dim sDateDebut As String
20: Dim sDateFin As String
25: Dim sTotal As String
30: Dim sFilterNoProjet As String
		Dim test As String
		Dim Compile1 As String
		Dim Compile2 As String
		
		Compile1 = CStr(0)
		Compile2 = CStr(0)
		
35: If VB.Right(sProjet, 2) = "99" Then
40: sFilterNoProjet = "LEFT(NoProjet, 6) = '" & VB.Left(sProjet, 6) & "'"
45: Else
50: sFilterNoProjet = "NoProjet = '" & sProjet & "'"
55: End If
		
60: sDateDebut = "TIMESERIAL(Left(GRB_Punch.HeureDébut,2),RIGHT(GRB_Punch.HeureDébut,2),0)"
		
65: sDateFin = "TIMESERIAL(Left(GRB_Punch.HeureFin,2),RIGHT(GRB_Punch.HeureFin,2),0)"
		
70: sTotal = "(SUM(" & sDateFin & " - " & sDateDebut & ")* 24) As Total"
		
75: rstPunch = New ADODB.Recordset
		
80: If optChoix(I_OPT_PROJET_ENTIER).Checked = True Then
85: Call rstPunch.Open("SELECT Type, " & sTotal & " FROM GRB_Punch WHERE " & sFilterNoProjet & " And HeureFin is not null AND HeureDébut is not null GROUP BY Type", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
90: Else
95: Call rstPunch.Open("SELECT Type, " & sTotal & " FROM GRB_Punch WHERE " & sFilterNoProjet & " AND HeureFin Is Not Null AND HeureDébut Is Not Null AND [Date] BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' GROUP BY Type", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
100: End If
		
105: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecDessinProj").Caption = "0"
110: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecCoupeProj").Caption = "0"
115: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecMachinageProj").Caption = "0"
120: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecSoudureProj").Caption = "0"
125: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecAssemblageProj").Caption = "0"
130: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecPeintureProj").Caption = "0"
135: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTestProj").Caption = "0"
140: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecInstallationProj").Caption = "0"
145: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecFormationProj").Caption = "0"
150: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecGestionProj").Caption = "0"
155: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecShippingProj").Caption = "0"
		
160: Do While Not rstPunch.EOF
165: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("Total").Value) Then
170: Select Case rstPunch.Fields("Type").Value
					Case "Dessin"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecDessinProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
175: Case "Coupe"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecCoupeProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
180: Case "Machinage"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecMachinageProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
185: Case "Soudure"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecSoudureProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
190: Case "Assemblage"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecAssemblageProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
195: Case "Peinture"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecPeintureProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
200: Case "Test"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecTestProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
205: Case "Installation"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecInstallationProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
210: Case "Formation"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecFormationProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
215: Case "Gestion"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecGestionProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
220: Case "Shipping"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecShippingProj").Caption = System.Math.Round(rstPunch.Fields("Total").Value, 2)
225: Case "Prototypage-Dévelloppement expérimental" : Compile1 = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
					Case "" : Compile2 = CStr(System.Math.Round(rstPunch.Fields("Total").Value, 2))
						
						
				End Select
230: End If
			
235: Call rstPunch.MoveNext()
240: Loop 
		'''''''''''''''''''''''''''''''''
		' s'il y a  des enregistrement sans type , compile sans develloppement
		
		
		'UPGRADE_WARNING: Couldn't resolve default property of object DR_ApercuProjet.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ApercuProjet.Sections("Section2").Controls("lblHeuresMecRechercheProj").Caption = CStr(CDbl(Compile1) + CDbl(Compile2))
		''''''''''''''''''''''''''''''''''''
		
		
245: Call rstPunch.Close()
250: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPunch = Nothing
		
255: Exit Sub
		
AfficherErreur: 
		
260: Call AfficherErreur("frmChoixDateImpressionFacturation", "RemplirTempsReelsElec", Err, Erl())
	End Sub
	
	
	Private Sub frmChoixDateImpressionFacturation_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Click
		
5: On Error GoTo AfficherErreur
		
10: mvwDate.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDateImpressionFacturation", "Form_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixDateImpressionFacturation_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: optChoix(I_OPT_PROJET_ENTIER).Checked = True
15: optChoixProjetEntier(0).Checked = True
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmChoixDateImpressionFacturation", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub mvwDate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mvwDate.Leave
		
5: On Error GoTo AfficherErreur
		
10: mvwDate.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDateImpressionFacturation", "mvwDate_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mvwDate_DateClick(ByVal eventSender As System.Object, ByVal eventArgs As AxMSComCtl2.DMonthViewEvents_DateClickEvent) Handles mvwDate.DateClick
		
5: On Error GoTo AfficherErreur
		
10: Select Case m_eDate
			Case enumDate.DEBUT : mskDateDebut.Text = ConvertDate(eventArgs.DateClicked)
			Case enumDate.Fin : mskDateFin.Text = ConvertDate(eventArgs.DateClicked)
15: End Select
		
		'Enlever le calendrier
20: mvwDate.Visible = False
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixDateImpressionFacturation", "mvwDate_DateClick", Err, Erl())
	End Sub
	
	Private Sub mskDateDebut_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateDebut.Enter
		
5: On Error GoTo AfficherErreur
		
		'Met l'année sur 2 chiffres
10: If Len(mskDateDebut.Text) = 10 Then
15: mskDateDebut.Text = VB.Right(mskDateDebut.Text, 8)
20: End If
		
25: mskDateDebut.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixDateImpressionFacturation", "mskDateDebut_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateFin_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateFin.Enter
		
5: On Error GoTo AfficherErreur
		
		'Met l'année sur 2 chiffres
10: If Len(mskDateFin.Text) = 10 Then
15: mskDateFin.Text = VB.Right(mskDateFin.Text, 8)
20: End If
		
25: mskDateFin.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixDateImpressionFacturation", "mskDateFin_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateDebut_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateDebut.Leave
		
5: On Error GoTo AfficherErreur
		
		'Enlève le mask
10: mskDateDebut.Mask = vbNullString
		
		'Vide le champs si l'utilisateur n'a rien écrit
15: If mskDateDebut.Text = "__-__-__" Then
20: mskDateDebut.Text = vbNullString
25: Else
			'Remet l'année sur 8 chiffres
30: If Len(mskDateDebut.Text) = 8 Then
35: If IsDate(mskDateDebut.Text) Then
40: mskDateDebut.Text = Year(DateSerial(CInt(VB.Left(mskDateDebut.Text, 2)), CInt(Mid(mskDateDebut.Text, 4, 2)), CInt(VB.Right(mskDateDebut.Text, 2)))) & Mid(mskDateDebut.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmChoixDateImpressionFacturation", "mskDateDebut_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateFin_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateFin.Leave
		
5: On Error GoTo AfficherErreur
		
		'Enlève le mask
10: mskDateFin.Mask = vbNullString
		
		'Vide le champs si l'utilisateur n'a rien écrit
15: If mskDateFin.Text = "__-__-__" Then
20: mskDateFin.Text = vbNullString
25: Else
			'Remet l'année sur 8 chiffres
30: If Len(mskDateFin.Text) = 8 Then
35: If IsDate(mskDateFin.Text) Then
40: mskDateFin.Text = Year(DateSerial(CInt(VB.Left(mskDateFin.Text, 2)), CInt(Mid(mskDateFin.Text, 4, 2)), CInt(VB.Right(mskDateFin.Text, 2)))) & Mid(mskDateFin.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmChoixDateImpressionFacturation", "mskDateFin_LostFocus", Err, Erl())
	End Sub
	
	Private Sub cmdDateDebut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDateDebut.Click
		
5: On Error GoTo AfficherErreur
		'Ouverture du calendrier
		
		'Si il y a une date valide, la date par défaut est celle-ci, sinon c'est la date
		'd'aujourd'hui
10: If Trim(mskDateDebut.Text) <> vbNullString Then
15: If ValiderDate(mskDateDebut.Text) = True Then
20: mvwDate.Value = CDate(mskDateDebut.Text)
25: Else
30: mvwDate.Value = Today
35: End If
40: Else
45: mvwDate.Value = Today
50: End If
		
55: m_eDate = enumDate.DEBUT
		
60: mvwDate.Visible = True
		
65: Call mvwDate.Focus()
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmChoixDateImpressionFacturation", "cmdDateDebut_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDateFin_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDateFin.Click
		
5: On Error GoTo AfficherErreur
		'Ouverture du calendrier
		
		'Si il y a une date valide, la date par défaut est celle-ci, sinon c'est la date
		'd'aujourd'hui
10: If Trim(mskDateFin.Text) <> vbNullString Then
15: If ValiderDate(mskDateFin.Text) = True Then
20: mvwDate.Value = CDate(mskDateFin.Text)
25: Else
30: mvwDate.Value = Today
35: End If
40: Else
45: mvwDate.Value = Today
50: End If
		
55: m_eDate = enumDate.Fin
		
60: mvwDate.Visible = True
		
65: Call mvwDate.Focus()
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmChoixDateImpressionFacturation", "cmdDateFin_Click", Err, Erl())
	End Sub
	
	Private Function ValiderDate(ByVal sDate As String) As Boolean
		
5: On Error GoTo AfficherErreur
		
		'Validation des dates
10: If Not IsDate(sDate) Then
15: ValiderDate = False
20: Else
25: ValiderDate = True
30: End If
		
35: Exit Function
		
AfficherErreur: 
		
40: Call AfficherErreur("frmChoixDateImpressionFacturation", "ValiderDate", Err, Erl())
	End Function
	
	'UPGRADE_WARNING: Event optChoix.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optChoix_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optChoix.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = optChoix.GetIndex(eventSender)
			
5: On Error GoTo AfficherErreur
			
10: If optChoix(I_OPT_PROJET_ENTIER).Checked = True Then
20: fra2Dates.Enabled = False
25: Else
35: fra2Dates.Enabled = True
40: End If
			
45: Exit Sub
			
AfficherErreur: 
			
50: Call AfficherErreur("frmChoixDateImpressionFacturation", "optChoix_Click", Err, Erl())
		End If
	End Sub
End Class