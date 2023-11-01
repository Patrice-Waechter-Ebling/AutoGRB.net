Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmreport
	Inherits System.Windows.Forms.Form
	
	Private Const S_SELECT_ALL As String = "Sélectionner tout"
	Private Const S_UNSELECT_ALL As String = "Désélectionner tout"
	
	Private Enum enumLangueFax
		FAX_FRANCAIS = 0
		FAX_ANGLAIS = 1
	End Enum
	
	Public Enum enumForm
		FRM_CLIENTS = 0
		FRM_FRS = 1
		FRM_CONTACTS = 2
	End Enum
	
	Private m_iNoClient As Short
	Private m_iNoClient2 As Short
	Private m_iNoContact As Short
	Private m_iNoGRB As Short
	Private m_iNoFRS As Short
	Private m_iNoFRS2 As Short
	Private m_bSelectAll As Boolean
	
	Private m_sFaxClientFRS As String
	Private m_sFaxContact As String
	
	Private m_sTelClientFRS As String
	Private m_sTelContact As String
	
	Public Sub Afficher(ByVal iNoClientFRS As Object, ByRef iNoContact As Object, ByRef eForm As enumForm)
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: cmdSelect.Text = S_UNSELECT_ALL
		
20: Call cmdselect_Click(cmdselect, New System.EventArgs())
		
25: chkFaxFrancais.CheckState = System.Windows.Forms.CheckState.Checked
		
30: cmbClient.SelectedIndex = -1
35: cmbcontact.SelectedIndex = -1
		
40: cmbFournisseur.SelectedIndex = -1
45: cmbContactFRS.SelectedIndex = -1
		
50: Select Case eForm
			Case enumForm.FRM_CLIENTS
55: For iCompteur = 0 To cmbClient.Items.Count - 1
60: 'UPGRADE_WARNING: Couldn't resolve default property of object iNoClientFRS. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If VB6.GetItemData(cmbClient, iCompteur) = iNoClientFRS Then
65: cmbClient.SelectedIndex = iCompteur
						
70: Exit For
75: End If
80: Next 
				
85: For iCompteur = 0 To cmbcontact.Items.Count - 1
90: 'UPGRADE_WARNING: Couldn't resolve default property of object iNoContact. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If VB6.GetItemData(cmbcontact, iCompteur) = iNoContact Then
95: cmbcontact.SelectedIndex = iCompteur
						
100: Exit For
105: End If
110: Next 
				
			Case enumForm.FRM_FRS
115: For iCompteur = 0 To cmbFournisseur.Items.Count - 1
120: 'UPGRADE_WARNING: Couldn't resolve default property of object iNoClientFRS. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If VB6.GetItemData(cmbFournisseur, iCompteur) = iNoClientFRS Then
125: cmbFournisseur.SelectedIndex = iCompteur
						
130: Exit For
135: End If
140: Next 
				
145: For iCompteur = 0 To cmbContactFRS.Items.Count - 1
150: 'UPGRADE_WARNING: Couldn't resolve default property of object iNoContact. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If VB6.GetItemData(cmbContactFRS, iCompteur) = iNoContact Then
155: cmbContactFRS.SelectedIndex = iCompteur
						
160: Exit For
165: End If
170: Next 
				
			Case enumForm.FRM_CONTACTS
175: For iCompteur = 0 To cmbcontact.Items.Count - 1
180: 'UPGRADE_WARNING: Couldn't resolve default property of object iNoContact. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If VB6.GetItemData(cmbcontact, iCompteur) = iNoContact Then
185: cmbcontact.SelectedIndex = iCompteur
						
190: Exit For
195: End If
200: Next 
205: End Select
		
210: txtMsg.Visible = True
		
215: Call Me.Show()
		
220: Exit Sub
		
AfficherErreur: 
		
225: Call AfficherErreur("frmreport", "Afficher", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkBonLivraison.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkBonLivraison_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkBonLivraison.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_bSelectAll = False Then
15: Call AfficherControles()
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmreport", "chkBonLivraison_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkBonTravail.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkBonTravail_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkBonTravail.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_bSelectAll = False Then
15: Call AfficherControles()
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmreport", "chkBonTravail_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkClient.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkClient_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkClient.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_bSelectAll = False Then
15: Call AfficherControles()
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmreport", "chkClient_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkFourn.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkFourn_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkFourn.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_bSelectAll = False Then
15: Call AfficherControles()
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmreport", "chkFourn_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkConcept.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkConcept_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkConcept.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_bSelectAll = False Then
15: Call AfficherControles()
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmreport", "chkConcept_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkProblemes.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkProblemes_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkProblemes.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_bSelectAll = False Then
15: Call AfficherControles()
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmreport", "chkProblemes_Click", Err, Erl())
		
	End Sub
	
	'UPGRADE_WARNING: Event chkProg.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkProg_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkProg.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_bSelectAll = False Then
15: Call AfficherControles()
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmreport", "chkProg_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkFabFermMéca.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkFabFermMéca_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkFabFermMéca.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_bSelectAll = False Then
15: Call AfficherControles()
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmreport", "chkFabFermMéca_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkFabFerm.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkFabFerm_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkFabFerm.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_bSelectAll = False Then
15: Call AfficherControles()
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmreport", "chkFabFerm_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkFaxFrancais.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkFaxFrancais_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkFaxFrancais.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_bSelectAll = False Then
15: Call AfficherControles()
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmreport", "chkFaxFrancais_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkFaxAnglais.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkFaxAnglais_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkFaxAnglais.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_bSelectAll = False Then
15: Call AfficherControles()
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmreport", "chkFaxAnglais_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbclient.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbclient_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbclient.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: Dim rstClient As ADODB.Recordset
		
15: m_sTelClientFRS = ""
20: m_sTelContact = ""
		
25: m_sFaxClientFRS = ""
30: m_sTelContact = ""
		
		'affiche client selectionné dans textbox
35: If cmbClient.SelectedIndex <> -1 Then
40: rstClient = New ADODB.Recordset
			
45: Call rstClient.Open("SELECT Fax, Telephonne FROM GRB_Client WHERE IDClient = " & VB6.GetItemData(cmbClient, cmbClient.SelectedIndex), g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
50: If Not rstClient.EOF Then
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstClient.Fields("Fax").Value) Then
60: m_sFaxClientFRS = rstClient.Fields("Fax").Value
65: Else
70: m_sFaxClientFRS = vbNullString
75: End If
				
80: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstClient.Fields("Telephonne").Value) Then
85: m_sTelClientFRS = rstClient.Fields("Telephonne").Value
90: Else
95: m_sTelClientFRS = vbNullString
100: End If
105: End If
			
			'ferme la table
110: Call rstClient.Close()
115: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstClient = Nothing
			
120: If cmbClient.SelectedIndex > -1 Then
125: m_iNoClient = VB6.GetItemData(cmbClient, cmbClient.SelectedIndex)
130: End If
			
135: Call RemplirComboContact()
140: End If
		
145: Exit Sub
		
AfficherErreur: 
		
150: Call AfficherErreur("frmreport", "cmbclient_Click", Err, Erl())
	End Sub
	
	Private Sub AfficherControles()
		
5: On Error GoTo AfficherErreur
		
		'Affichage des contrôles selon le rapport choisi
		
		'Met tous les contrôles invisible
10: cmbClient.Visible = False
15: cmbClient2.Visible = False
20: cmbcontact.Visible = False
25: cmbContactFRS.Visible = False
30: cmbFournisseur.Visible = False
35: cmbFournisseur2.Visible = False
40: cmbGRB.Visible = False
		
45: cmdMsg.Visible = False
50: cmdRechercherClient.Visible = False
55: cmdRechercherClient2.Visible = False
60: cmdRechercherFRS.Visible = False
65: cmdRechercherFRS2.Visible = False
		
70: lblClient.Visible = False
75: lblClient2.Visible = False
80: lblContact.Visible = False
85: lblContactFRS.Visible = False
90: lblDate.Visible = False
95: lblDateCommande.Visible = False
100: lblDateDue.Visible = False
105: lblDateLivraison.Visible = False
110: lblDateTravaux.Visible = False
115: lblDe.Visible = False
120: lblFormatDateCommande.Visible = False
125: lblFormatDateTravaux.Visible = False
130: lblFormatHeurePrevue.Visible = False
135: lblFournisseur.Visible = False
140: lblFournisseur2.Visible = False
145: lblGRB.Visible = False
150: lblHeureTravaux.Visible = False
155: lblNoCommande.Visible = False
160: lblNomProjet.Visible = False
165: lblNoProjet.Visible = False
170: lblNoSoumission.Visible = False
175: lblObjet.Visible = False
180: lblPage.Visible = False
185: lblProjetClient.Visible = False
190: lblTransport.Visible = False
		
195: mskDate.Visible = False
200: mskDateCommande.Visible = False
205: mskDateDue.Visible = False
210: mskDateLivraison.Visible = False
215: mskDateTravaux.Visible = False
220: mskHeureTravaux.Visible = False
		
225: txtDe.Visible = False
230: txtMsg.Visible = False
235: txtNoCommande.Visible = False
240: txtNomProjet.Visible = False
245: txtNoProjet.Visible = False
250: txtNoSoumission.Visible = False
255: txtObjet.Visible = False
260: txtPage.Visible = False
265: txtProjetClient.Visible = False
270: txtTransport.Visible = False
		
		'Si c'est le rapport de problèmes
275: If chkProblemes.CheckState = System.Windows.Forms.CheckState.Checked Then
280: lblGRB.Visible = True
285: cmbGRB.Visible = True
			
290: lblNoProjet.Visible = True
295: txtNoProjet.Visible = True
			
300: lblNoSoumission.Visible = True
305: txtNoSoumission.Visible = True
310: End If
		
		'Si c'est client ou fournisseur
315: If ChkClient.CheckState = System.Windows.Forms.CheckState.Checked Or ChkFourn.CheckState = System.Windows.Forms.CheckState.Checked Then
320: lblDateDue.Visible = True
325: mskDateDue.Visible = True
330: End If
		
		'Si c'est bon de travail, bon de livraison, client, fournisseur,
		'conception, programmation, Fermeture mécanique, fermeture, fax
335: If ChkBonTravail.CheckState = System.Windows.Forms.CheckState.Checked Or chkBonLivraison.CheckState = System.Windows.Forms.CheckState.Checked Or ChkClient.CheckState = System.Windows.Forms.CheckState.Checked Or ChkFourn.CheckState = System.Windows.Forms.CheckState.Checked Or ChkConcept.CheckState = System.Windows.Forms.CheckState.Checked Or ChkProg.CheckState = System.Windows.Forms.CheckState.Checked Or ChkFabFermMéca.CheckState = System.Windows.Forms.CheckState.Checked Or ChkFabFerm.CheckState = System.Windows.Forms.CheckState.Checked Or chkFaxFrancais.CheckState = System.Windows.Forms.CheckState.Checked Or chkFaxAnglais.CheckState = System.Windows.Forms.CheckState.Checked Then
			
340: cmbClient.Visible = True
345: lblClient.Visible = True
			
350: cmdRechercherClient.Visible = True
			
355: cmbcontact.Visible = True
360: lblContact.Visible = True
			
365: txtNoProjet.Visible = True
370: lblNoProjet.Visible = True
375: End If
		
		'Si c'est bon de travail ou bon de livraison
380: If ChkBonTravail.CheckState = System.Windows.Forms.CheckState.Checked Or chkBonLivraison.CheckState = System.Windows.Forms.CheckState.Checked Then
385: txtNoCommande.Visible = True
390: lblNoCommande.Visible = True
395: End If
		
		'Si c'est bon de travail
400: If ChkBonTravail.CheckState = System.Windows.Forms.CheckState.Checked Then
405: cmbGRB.Visible = True
410: lblGRB.Visible = True
			
415: mskDateCommande.Visible = True
420: lblDateCommande.Visible = True
425: lblFormatDateCommande.Visible = True
			
430: mskDateTravaux.Visible = True
435: lblDateTravaux.Visible = True
440: lblFormatDateTravaux.Visible = True
			
445: mskHeureTravaux.Visible = True
450: lblHeureTravaux.Visible = True
455: lblFormatHeurePrevue.Visible = True
460: End If
		
		'Si c'est bon de livraison ou fax
465: If chkBonLivraison.CheckState = System.Windows.Forms.CheckState.Checked Or chkFaxFrancais.CheckState = System.Windows.Forms.CheckState.Checked Or chkFaxAnglais.CheckState = System.Windows.Forms.CheckState.Checked Then
			
470: cmbFournisseur.Visible = True
475: lblFournisseur.Visible = True
			
480: cmbContactFRS.Visible = True
485: lblContactFRS.Visible = True
			
490: cmdRechercherFRS.Visible = True
495: End If
		
		'Si c'est bon de livraison
500: If chkBonLivraison.CheckState = System.Windows.Forms.CheckState.Checked Then
505: cmbClient2.Visible = True
510: lblClient2.Visible = True
			
515: cmbFournisseur2.Visible = True
520: lblFournisseur2.Visible = True
			
525: cmdRechercherClient2.Visible = True
530: cmdRechercherFRS2.Visible = True
			
535: txtTransport.Visible = True
540: lblTransport.Visible = True
			
545: mskDateLivraison.Visible = True
550: lblDateLivraison.Visible = True
555: End If
		
		'Si c'est client, fournisseur, conception, programmation, fermeture mécan,
		'fermeture ou fax
560: If ChkClient.CheckState = System.Windows.Forms.CheckState.Checked Or ChkFourn.CheckState = System.Windows.Forms.CheckState.Checked Or ChkConcept.CheckState = System.Windows.Forms.CheckState.Checked Or ChkProg.CheckState = System.Windows.Forms.CheckState.Checked Or ChkFabFermMéca.CheckState = System.Windows.Forms.CheckState.Checked Or ChkFabFerm.CheckState = System.Windows.Forms.CheckState.Checked Or chkFaxFrancais.CheckState = System.Windows.Forms.CheckState.Checked Or chkFaxAnglais.CheckState = System.Windows.Forms.CheckState.Checked Then
			
565: txtNoSoumission.Visible = True
570: lblNoSoumission.Visible = True
575: End If
		
		'Si c'est client, fournisseur, conception, programmation, fermeture mécan,
		'fermeture
580: If ChkClient.CheckState = System.Windows.Forms.CheckState.Checked Or ChkFourn.CheckState = System.Windows.Forms.CheckState.Checked Or ChkConcept.CheckState = System.Windows.Forms.CheckState.Checked Or ChkProg.CheckState = System.Windows.Forms.CheckState.Checked Or ChkFabFermMéca.CheckState = System.Windows.Forms.CheckState.Checked Or ChkFabFerm.CheckState = System.Windows.Forms.CheckState.Checked Then
			
585: txtNomProjet.Visible = True
590: lblNomProjet.Visible = True
			
595: mskDate.Visible = True
600: lblDate.Visible = True
			
605: txtProjetClient.Visible = True
610: lblProjetClient.Visible = True
615: End If
		
		'Si c'est fax
620: If chkFaxFrancais.CheckState = System.Windows.Forms.CheckState.Checked Or chkFaxAnglais.CheckState = System.Windows.Forms.CheckState.Checked Then
625: txtPage.Visible = True
630: lblPage.Visible = True
			
635: txtDe.Visible = True
640: lblDe.Visible = True
			
645: cmdMsg.Visible = True
			
650: txtObjet.Visible = True
655: lblObjet.Visible = True
660: End If
		
665: Exit Sub
		
AfficherErreur: 
		
670: Call AfficherErreur("frmreport", "AfficherControles", Err, Erl())
	End Sub
	
	Private Sub cmdRechercherClient_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercherClient.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim sRecherche As String
		
15: sRecherche = InputBox("Entrez le texte à rechercher.")
		
20: Call RemplirComboClient(sRecherche)
		
25: m_iNoClient = 0
		
30: Call RemplirComboContact()
		
35: Call cmbClient.Focus()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmreport", "cmdRechercherClient_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRechercherClient2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercherClient2.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim sRecherche As String
		
15: sRecherche = InputBox("Entrez le texte à rechercher.")
		
20: Call RemplirComboClient2(sRecherche)
		
25: m_iNoClient2 = 0
		
30: Call cmbClient2.Focus()
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmreport", "cmdRechercherClient2_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRechercherFRS_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercherFRS.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim sRecherche As String
		
15: sRecherche = InputBox("Entrez le texte à rechercher.")
		
20: Call RemplirComboFRS(sRecherche)
		
25: m_iNoFRS = 0
		
30: Call cmbFournisseur.Focus()
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmreport", "cmdRechercherFRS_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRechercherFRS2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercherFRS2.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim sRecherche As String
		
15: sRecherche = InputBox("Entrez le texte à rechercher.")
		
20: Call RemplirComboFRS2(sRecherche)
		
25: m_iNoFRS2 = 0
		
30: Call cmbFournisseur2.Focus()
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmreport", "cmdRechercherFRS2_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbclient2.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbclient2_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbclient2.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		'Affiche client2 selectionné dans textbox
10: If cmbClient2.SelectedIndex > -1 Then
15: m_iNoClient2 = VB6.GetItemData(cmbClient2, cmbClient2.SelectedIndex)
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmreport", "cmbclient2_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbFournisseur2.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbFournisseur2_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbFournisseur2.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		'Affiche client2 selectionné dans textbox
10: If cmbFournisseur2.SelectedIndex > -1 Then
15: m_iNoFRS2 = VB6.GetItemData(cmbFournisseur2, cmbFournisseur2.SelectedIndex)
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmreport", "cmbFournisseur2_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbFournisseur.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbFournisseur_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbFournisseur.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: Dim rstFRS As ADODB.Recordset
		'affiche fournisseur selectionné dans textbox
		
15: m_sFaxContact = ""
20: m_sFaxClientFRS = ""
		
25: m_sTelContact = ""
30: m_sTelClientFRS = ""
		
35: If cmbFournisseur.SelectedIndex <> -1 Then
40: rstFRS = New ADODB.Recordset
			
45: Call rstFRS.Open("SELECT Fax, Telephonne FROM GRB_Fournisseur WHERE IDFRS = " & VB6.GetItemData(cmbFournisseur, cmbFournisseur.SelectedIndex), g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
50: If Not rstFRS.EOF Then
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstFRS.Fields("Fax").Value) Then
60: m_sFaxClientFRS = rstFRS.Fields("Fax").Value
65: Else
70: m_sFaxClientFRS = vbNullString
75: End If
				
80: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstFRS.Fields("Telephonne").Value) Then
85: m_sTelClientFRS = rstFRS.Fields("Telephonne").Value
90: Else
95: m_sTelClientFRS = vbNullString
100: End If
105: End If
			
			'ferme la table
110: Call rstFRS.Close()
115: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstFRS = Nothing
120: End If
		
125: If cmbFournisseur.SelectedIndex > -1 Then
130: m_iNoFRS = VB6.GetItemData(cmbFournisseur, cmbFournisseur.SelectedIndex)
135: End If
		
140: Call RemplirComboContactFRS()
		
145: Exit Sub
		
AfficherErreur: 
		
150: Call AfficherErreur("frmreport", "cmbFournisseur_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbContact.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbContact_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbContact.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: Dim rstContact As ADODB.Recordset
15: Dim sTampon As String
		
20: If cmbcontact.SelectedIndex <> -1 Then
25: m_iNoContact = VB6.GetItemData(cmbcontact, cmbcontact.SelectedIndex)
30: End If
		
35: If cmbcontact.SelectedIndex <> -1 Then
40: sTampon = CStr(VB6.GetItemData(cmbcontact, cmbcontact.SelectedIndex))
			
45: rstContact = New ADODB.Recordset
			
50: Call rstContact.Open("SELECT Telephonne, Fax FROM GRB_contact WHERE IDContact = " & sTampon, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'remplis le champ text, telephone et fax
55: If Not rstContact.EOF Then
60: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If IsDbNull(rstContact.Fields("telephonne").Value) Then
65: m_sTelContact = vbNullString
70: Else
75: m_sTelContact = rstContact.Fields("telephonne").Value
80: End If
				
85: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If IsDbNull(rstContact.Fields("fax").Value) Then
90: m_sFaxContact = vbNullString
95: Else
100: m_sFaxContact = rstContact.Fields("fax").Value
105: End If
110: End If
			
115: Call rstContact.Close()
120: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstContact = Nothing
125: End If
		
130: Exit Sub
		
AfficherErreur: 
		
135: Call AfficherErreur("frmreport", "cmbContact_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbContactFRS.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbContactFRS_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbContactFRS.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: Dim rstContact As ADODB.Recordset
		
30: If cmbContactFRS.SelectedIndex <> -1 Then
			'Si il y a un client de choisi, le fax sera pour le client
35: If cmbcontact.SelectedIndex = -1 Then
40: rstContact = New ADODB.Recordset
				
45: Call rstContact.Open("SELECT Telephonne, Fax FROM GRB_Contact WHERE IDContact = " & VB6.GetItemData(cmbContactFRS, cmbContactFRS.SelectedIndex), g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
				'remplis le champ text, telephone et fax
50: If Not rstContact.EOF Then
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstContact.Fields("telephonne").Value) Then
60: m_sTelContact = rstContact.Fields("telephonne").Value
65: Else
70: m_sTelContact = vbNullString
75: End If
					
80: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstContact.Fields("fax").Value) Then
85: m_sFaxContact = rstContact.Fields("fax").Value
90: Else
95: m_sFaxContact = vbNullString
100: End If
105: End If
				
110: Call rstContact.Close()
115: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstContact = Nothing
120: End If
125: End If
		
130: Exit Sub
		
AfficherErreur: 
		
135: Call AfficherErreur("frmreport", "cmbContactFRS_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbgrb.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbgrb_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbgrb.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		'affiche contactgrb selectionné dans textbox
10: If cmbGRB.SelectedIndex > -1 Then
15: m_iNoGRB = VB6.GetItemData(cmbGRB, cmbGRB.SelectedIndex)
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmreport", "cmbgrb_Click", Err, Erl())
	End Sub
	
	Private Sub cmdmsg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdmsg.Click
		
5: On Error GoTo AfficherErreur
		
10: If txtMsg.Visible = True Then
15: txtMsg.Visible = False
20: Else
25: txtMsg.Visible = True
			
30: Call txtMsg.Focus()
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmreport", "cmdmsg_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmreport", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub ImprimerBonTravail()
		Dim DR_BonTravail As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBonTravail As ADODB.Recordset
		
15: rstBonTravail = New ADODB.Recordset
		
20: Call rstBonTravail.Open("SELECT * FROM GRB_impression_bonlivraison", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Set le rapport
25: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonTravail.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BonTravail.DataSource = rstBonTravail
		
		'Contenu label
30: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonTravail.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BonTravail.Sections(1).Controls("lblClient").Caption = cmbClient.Text
35: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonTravail.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BonTravail.Sections(1).Controls("lblContact").Caption = cmbcontact.Text
40: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonTravail.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BonTravail.Sections(1).Controls("lblTelephone").Caption = m_sTelContact
45: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonTravail.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BonTravail.Sections(1).Controls("lblFax").Caption = m_sFaxContact
50: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonTravail.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BonTravail.Sections(1).Controls("lblRepresentantGRB").Caption = cmbGRB.Text
55: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonTravail.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BonTravail.Sections(1).Controls("lblBonTravail").Caption = txtNoProjet.Text
60: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonTravail.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BonTravail.Sections(1).Controls("lblNoCommandeClient").Caption = txtNoCommande.Text
65: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonTravail.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BonTravail.Sections(1).Controls("lblDateCommande").Caption = mskDateCommande.Text
70: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonTravail.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BonTravail.Sections(1).Controls("lblDateHeure").Caption = mskDateTravaux.Text & " " & mskHeureTravaux.Text
		
		'Affiche rapport
75: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonTravail.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_BonTravail.Show(VB6.FormShowConstants.Modal)
		
80: Call rstBonTravail.Close()
85: 'UPGRADE_NOTE: Object rstBonTravail may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBonTravail = Nothing
		
90: Exit Sub
		
AfficherErreur: 
		
95: Call AfficherErreur("frmreport", "ImprimerBonTravail", Err, Erl())
	End Sub
	
	Private Sub ImprimerBonLivraison()
		Dim DR_BonLivraison As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBonLivraison As ADODB.Recordset
15: Dim rstFournisseur As ADODB.Recordset
20: Dim rstFournisseur2 As ADODB.Recordset
25: Dim rstClient As ADODB.Recordset
30: Dim rstClient2 As ADODB.Recordset
35: Dim rstContact As ADODB.Recordset
40: Dim sTampon As String
		
		'ouvre fenetre bon livraison
		'pour entrer qte
45: Call OuvrirForm(frmbonlivraison, True)
		
50: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
55: rstBonLivraison = New ADODB.Recordset
60: rstFournisseur = New ADODB.Recordset
65: rstFournisseur2 = New ADODB.Recordset
70: rstClient = New ADODB.Recordset
75: rstClient2 = New ADODB.Recordset
		
80: Call rstBonLivraison.Open("SELECT * FROM GRB_impression_bonlivraison WHERE user = '" & g_sUserID & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
85: Call rstFournisseur.Open("SELECT * FROM GRB_Fournisseur WHERE IDFRS = " & m_iNoFRS, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
90: Call rstFournisseur2.Open("SELECT * FROM GRB_Fournisseur WHERE IDFRS = " & m_iNoFRS2, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
95: Call rstClient.Open("SELECT * FROM GRB_client WHERE IDClient = " & m_iNoClient, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
100: Call rstClient2.Open("SELECT * FROM GRB_client WHERE IDClient = " & m_iNoClient2, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'set le rapport
105: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BonLivraison.DataSource = rstBonLivraison
		
		'contenu label
110: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BonLivraison.Sections(1).Controls(34).Caption = txtNoProjet.Text
115: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BonLivraison.Sections(1).Controls(35).Caption = ConvertDate(Today)
		
		'si fournisseur
120: If cmbFournisseur.SelectedIndex <> -1 Then
125: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_BonLivraison.Sections(1).Controls(36).Caption = cmbFournisseur.Text
			
130: If rstFournisseur.EOF Then
135: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_BonLivraison.Sections(1).Controls(37).Caption = vbNullString
140: Else
145: sTampon = vbNullString
				''''''''''''''''''''''''''''''''''''''''''''
				'rempli adresse pay ville prov et codepostal si pas vide
				'''''''''''''''''''''''''''''''''''''''''''''
				'adresse
150: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstFournisseur.Fields("adresse").Value) Then
155: sTampon = rstFournisseur.Fields("adresse").Value
160: End If
				
165: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_BonLivraison.Sections(1).Controls(37).Caption = sTampon
				
170: sTampon = vbNullString
				
				'ville
175: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstFournisseur.Fields("ville").Value) Then
180: sTampon = rstFournisseur.Fields("ville").Value
185: End If
				
				'province
190: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstFournisseur.Fields("Prov/Etat").Value) Then
195: If rstFournisseur.Fields("Prov/Etat").Value <> vbNullString Then
200: sTampon = sTampon & ", " + rstFournisseur.Fields("Prov/Etat").Value
205: End If
210: End If
				
215: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_BonLivraison.Sections(1).Controls(44).Caption = sTampon
				
220: sTampon = vbNullString
				
				'Pays
225: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstFournisseur.Fields("pays").Value) Then
230: sTampon = rstFournisseur.Fields("pays").Value
235: End If
				
				'codepostal
240: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstFournisseur.Fields("codepostal").Value) Then
245: If rstFournisseur.Fields("CodePostal").Value <> vbNullString Then
250: sTampon = sTampon & ", " + rstFournisseur.Fields("codepostal").Value
255: End If
260: End If
				
265: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_BonLivraison.Sections(1).Controls(45).Caption = sTampon
270: End If
			
275: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_BonLivraison.Sections(1).Controls(38).Caption = txtNoCommande.Text
280: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_BonLivraison.Sections(1).Controls(39).Caption = cmbFournisseur2.Text
			
285: If rstFournisseur2.EOF Then
290: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_BonLivraison.Sections(1).Controls(40).Caption = vbNullString
295: Else
300: sTampon = vbNullString
				''''''''''''''''''''''''''''''''''''''''''''
				'rempli adresse pay ville prov et codepostal si pas vide
				'''''''''''''''''''''''''''''''''''''''''''''
				'adresse
305: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstFournisseur2.Fields("adresse").Value) Then
310: sTampon = sTampon + rstFournisseur2.Fields("adresse").Value
315: End If
				
320: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_BonLivraison.Sections(1).Controls(40).Caption = sTampon
				
325: sTampon = vbNullString
				
				'ville
330: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstFournisseur2.Fields("ville").Value) Then
335: sTampon = rstFournisseur2.Fields("ville").Value
340: End If
				
				'prov
345: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstFournisseur2.Fields("prov/etat").Value) Then
350: If rstFournisseur2.Fields("prov/etat").Value <> vbNullString Then
355: sTampon = sTampon & ", " + rstFournisseur2.Fields("prov/etat").Value
360: End If
365: End If
				
370: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_BonLivraison.Sections(1).Controls(46).Caption = sTampon
				
375: sTampon = vbNullString
				
				'pays
380: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstFournisseur2.Fields("pays").Value) Then
385: sTampon = rstFournisseur2.Fields("pays").Value
390: End If
				
				'codepostal
395: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstFournisseur2.Fields("codepostal").Value) Then
400: If rstFournisseur2.Fields("CodePostal").Value <> vbNullString Then
405: sTampon = sTampon & ", " + rstFournisseur2.Fields("codepostal").Value
410: End If
415: End If
				
420: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_BonLivraison.Sections(1).Controls(47).Caption = sTampon
425: End If
			
430: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_BonLivraison.Sections(1).Controls(41).Caption = cmbContactFRS.Text
435: Else
			'si client
440: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_BonLivraison.Sections(1).Controls(36).Caption = cmbClient.Text
			
445: If rstClient.EOF Then
450: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_BonLivraison.Sections(1).Controls(37).Caption = vbNullString
455: Else
460: sTampon = vbNullString
				''''''''''''''''''''''''''''''''''''''''''''
				'rempli adresse pay ville prov et codepostal si pas vide
				'''''''''''''''''''''''''''''''''''''''''''''
				'adresse
465: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstClient.Fields("adresseliv").Value) Then
470: sTampon = sTampon + rstClient.Fields("adresseliv").Value
475: End If
				
480: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_BonLivraison.Sections(1).Controls(37).Caption = sTampon
				
485: sTampon = vbNullString
				
				'ville
490: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstClient.Fields("villeliv").Value) Then
495: sTampon = rstClient.Fields("villeliv").Value
500: End If
				
				'pays
505: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstClient.Fields("paysliv").Value) Then
510: If rstClient.Fields("PaysLiv").Value <> vbNullString Then
515: sTampon = sTampon & ", " + rstClient.Fields("paysliv").Value
520: End If
525: End If
				
530: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_BonLivraison.Sections(1).Controls(44).Caption = sTampon
535: sTampon = vbNullString
				
				'province
540: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstClient.Fields("prov/etatliv").Value) Then
545: sTampon = rstClient.Fields("prov/etatliv").Value
550: End If
				
				'codepostal
555: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstClient.Fields("codepostalliv").Value) Then
560: If rstClient.Fields("CodePostalLiv").Value <> vbNullString Then
565: sTampon = sTampon & ", " + rstClient.Fields("codepostalliv").Value
570: End If
575: End If
				
580: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_BonLivraison.Sections(1).Controls(45).Caption = sTampon
585: End If
			
590: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_BonLivraison.Sections(1).Controls(38).Caption = txtNoCommande.Text
595: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_BonLivraison.Sections(1).Controls(39).Caption = cmbClient2.Text
			
600: If rstClient2.EOF Then
605: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_BonLivraison.Sections(1).Controls(40).Caption = vbNullString
610: Else
615: sTampon = vbNullString
				''''''''''''''''''''''''''''''''''''''''''''
				'rempli adresse pay ville prov et codepostal si pas vide
				'''''''''''''''''''''''''''''''''''''''''''''
				'adresse
620: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstClient2.Fields("adresseliv").Value) Then
625: sTampon = rstClient2.Fields("adresseliv").Value
630: End If
				
635: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_BonLivraison.Sections(1).Controls(40).Caption = sTampon
640: sTampon = vbNullString
				
				'ville
645: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstClient2.Fields("villeliv").Value) Then
650: sTampon = rstClient2.Fields("villeliv").Value
655: End If
				
				'pays
660: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstClient2.Fields("paysliv").Value) Then
665: If rstClient2.Fields("PaysLiv").Value <> vbNullString Then
670: sTampon = sTampon & ", " + rstClient2.Fields("paysliv").Value
675: End If
680: End If
				
685: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_BonLivraison.Sections(1).Controls(46).Caption = sTampon
690: sTampon = vbNullString
				
				'province
695: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstClient2.Fields("prov/etatliv").Value) Then
700: sTampon = rstClient2.Fields("prov/etatliv").Value
705: End If
				
				'codepostal
710: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstClient2.Fields("codepostalliv").Value) Then
715: If rstClient2.Fields("CodePostalLiv").Value <> vbNullString Then
720: sTampon = sTampon & ", " + rstClient2.Fields("codepostalliv").Value
725: End If
730: End If
				
735: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_BonLivraison.Sections(1).Controls(47).Caption = sTampon
740: End If
			
745: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_BonLivraison.Sections(1).Controls(41).Caption = cmbcontact.Text
750: End If
		
755: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BonLivraison.Sections(1).Controls(42).Caption = txtTransport.Text
760: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BonLivraison.Sections(1).Controls(43).Caption = mskDateLivraison.Text
		
		'affiche rapport
765: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BonLivraison.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_BonLivraison.Show(VB6.FormShowConstants.Modal)
		
770: Call rstBonLivraison.Close()
775: 'UPGRADE_NOTE: Object rstBonLivraison may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBonLivraison = Nothing
		
780: Call rstFournisseur.Close()
785: 'UPGRADE_NOTE: Object rstFournisseur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFournisseur = Nothing
		
790: Call rstClient.Close()
795: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient = Nothing
		
800: Call rstClient2.Close()
805: 'UPGRADE_NOTE: Object rstClient2 may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient2 = Nothing
		
810: Exit Sub
		
AfficherErreur: 
		
815: Call AfficherErreur("frmreport", "ImprimerBonLivraison", Err, Erl())
	End Sub
	
	Private Sub ImprimerClient()
		Dim DR_Client As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBonLivraison As ADODB.Recordset
		
15: rstBonLivraison = New ADODB.Recordset
		
20: Call rstBonLivraison.Open("SELECT * FROM GRB_impression_bonlivraison", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'set le rapport
25: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Client.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Client.DataSource = rstBonLivraison
		
		'contenu label
30: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Client.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Client.Sections("Section4").Controls("lblClient").Caption = cmbClient.Text
35: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Client.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Client.Sections("Section4").Controls("lblContact").Caption = cmbcontact.Text
40: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Client.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Client.Sections("Section4").Controls("lblTel").Caption = m_sTelContact
45: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Client.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Client.Sections("Section4").Controls("lblFax").Caption = m_sFaxContact
50: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Client.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Client.Sections("Section4").Controls("lblNoSoum").Caption = txtNoSoumission.Text
55: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Client.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Client.Sections("Section4").Controls("lblNoProj").Caption = txtNoProjet.Text
60: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Client.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Client.Sections("Section4").Controls("lblProjetNom").Caption = txtNomProjet.Text
65: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Client.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Client.Sections("Section4").Controls("lblDate").Caption = mskDate.Text
70: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Client.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Client.Sections("Section4").Controls("lblDateOuverture").Caption = ConvertDate(Today)
75: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Client.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Client.Sections("Section4").Controls("lblDateDue").Caption = mskDateDue.Text
80: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Client.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Client.Sections("Section4").Controls("lblProjet").Caption = txtProjetClient.Text
		
		'affiche rapport
85: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Client.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_Client.Show(VB6.FormShowConstants.Modal)
		
90: Call rstBonLivraison.Close()
95: 'UPGRADE_NOTE: Object rstBonLivraison may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBonLivraison = Nothing
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmreport", "ImprimerClient", Err, Erl())
	End Sub
	
	Private Sub ImprimerFournisseur()
		Dim DR_Fournisseur As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBonLivraison As ADODB.Recordset
		
15: rstBonLivraison = New ADODB.Recordset
		
20: Call rstBonLivraison.Open("SELECT * FROM GRB_impression_bonlivraison", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'set le rapport
25: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fournisseur.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fournisseur.DataSource = rstBonLivraison
		
		'contenu label
30: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fournisseur.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fournisseur.Sections("Section4").Controls("lblClient").Caption = cmbClient.Text
35: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fournisseur.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fournisseur.Sections("Section4").Controls("lblContact").Caption = cmbcontact.Text
40: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fournisseur.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fournisseur.Sections("Section4").Controls("lblTel").Caption = m_sTelContact
45: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fournisseur.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fournisseur.Sections("Section4").Controls("lblFax").Caption = m_sFaxContact
50: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fournisseur.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fournisseur.Sections("Section4").Controls("lblNoSoum").Caption = txtNoSoumission.Text
55: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fournisseur.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fournisseur.Sections("Section4").Controls("lblNoProj").Caption = txtNoProjet.Text
60: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fournisseur.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fournisseur.Sections("Section4").Controls("lblProjetNom").Caption = txtNomProjet.Text
65: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fournisseur.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fournisseur.Sections("Section4").Controls("lblDate").Caption = mskDate.Text
70: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fournisseur.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fournisseur.Sections("Section4").Controls("lblDateOuverture").Caption = ConvertDate(Today)
75: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fournisseur.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fournisseur.Sections("Section4").Controls("lblDateDue").Caption = mskDateDue.Text
80: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fournisseur.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fournisseur.Sections("Section4").Controls("lblProjet").Caption = txtProjetClient.Text
		
		'affiche rapport
85: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fournisseur.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_Fournisseur.Show(VB6.FormShowConstants.Modal)
		
90: Call rstBonLivraison.Close()
95: 'UPGRADE_NOTE: Object rstBonLivraison may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBonLivraison = Nothing
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmreport", "ImprimerFournisseur", Err, Erl())
	End Sub
	
	Private Sub ImprimerConception()
		Dim DR_Conception As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBonLivraison As ADODB.Recordset
		
15: rstBonLivraison = New ADODB.Recordset
		
20: Call rstBonLivraison.Open("SELECT * FROM GRB_impression_bonlivraison", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'set le rapport
25: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Conception.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Conception.DataSource = rstBonLivraison
		
		'contenu label
30: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Conception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Conception.Sections("Section4").Controls(90).Caption = cmbClient.Text
35: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Conception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Conception.Sections("Section4").Controls(91).Caption = cmbcontact.Text
40: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Conception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Conception.Sections("Section4").Controls(92).Caption = m_sTelContact
45: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Conception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Conception.Sections("Section4").Controls(93).Caption = m_sFaxContact
50: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Conception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Conception.Sections("Section4").Controls(94).Caption = txtNoSoumission.Text
55: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Conception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Conception.Sections("Section4").Controls(95).Caption = txtNoProjet.Text
60: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Conception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Conception.Sections("Section4").Controls(96).Caption = txtNomProjet.Text
65: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Conception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Conception.Sections("Section4").Controls(97).Caption = mskDate.Text
70: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Conception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Conception.Sections("Section4").Controls(98).Caption = Trim(VB.Right(CStr(Year(Today)), 2) & "-" & CStr(Month(Today)) & "-" & CStr(VB.Day(Today)))
75: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Conception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Conception.Sections("Section4").Controls(99).Caption = txtProjetClient.Text
		
		'affiche rapport
80: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Conception.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_Conception.Show(VB6.FormShowConstants.Modal)
		
85: Call rstBonLivraison.Close()
90: 'UPGRADE_NOTE: Object rstBonLivraison may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBonLivraison = Nothing
		
95: Exit Sub
		
AfficherErreur: 
		
100: Call AfficherErreur("frmreport", "ImprimerConception", Err, Erl())
	End Sub
	
	Private Sub ImprimerProgrammation()
		Dim DR_Programmation As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBonLivraison As ADODB.Recordset
		
15: rstBonLivraison = New ADODB.Recordset
		
20: Call rstBonLivraison.Open("SELECT * FROM GRB_impression_bonlivraison", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Set le rapport
25: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Programmation.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Programmation.DataSource = rstBonLivraison
		
		'Contenu label
30: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Programmation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Programmation.Sections("Section4").Controls("lblClient").Caption = cmbClient.Text
35: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Programmation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Programmation.Sections("Section4").Controls("lblContact").Caption = cmbcontact.Text
40: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Programmation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Programmation.Sections("Section4").Controls("lblTelephone").Caption = m_sTelContact
45: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Programmation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Programmation.Sections("Section4").Controls("lblFax").Caption = m_sFaxContact
50: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Programmation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Programmation.Sections("Section4").Controls("lblNoSoum").Caption = txtNoSoumission.Text
55: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Programmation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Programmation.Sections("Section4").Controls("lblNoProj").Caption = txtNoProjet.Text
65: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Programmation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Programmation.Sections("Section4").Controls("lblProjetNom").Caption = txtNomProjet.Text
70: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Programmation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Programmation.Sections("Section4").Controls("lblDate").Caption = mskDate.Text
75: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Programmation.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Programmation.Sections("Section4").Controls("lblProjetClient").Caption = txtProjetClient.Text
		
		'Affiche rapport
80: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Programmation.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_Programmation.Show(VB6.FormShowConstants.Modal)
		
85: Call rstBonLivraison.Close()
90: 'UPGRADE_NOTE: Object rstBonLivraison may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBonLivraison = Nothing
		
95: Exit Sub
		
AfficherErreur: 
		
100: Call AfficherErreur("frmreport", "ImprimerProgrammation", Err, Erl())
	End Sub
	
	Private Sub ImprimerFermetureMecanique()
		Dim DR_FermeMeca As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBonLivraison As ADODB.Recordset
		
15: rstBonLivraison = New ADODB.Recordset
		
20: Call rstBonLivraison.Open("SELECT * FROM GRB_impression_bonlivraison", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'set le rapport
25: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FermeMeca.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_FermeMeca.DataSource = rstBonLivraison
		
		'contenu label
30: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FermeMeca.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_FermeMeca.Sections("Section4").Controls("lblClient").Caption = cmbClient.Text
35: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FermeMeca.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_FermeMeca.Sections("Section4").Controls("lblContact").Caption = cmbcontact.Text
40: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FermeMeca.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_FermeMeca.Sections("Section4").Controls("lblTel").Caption = m_sTelContact
45: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FermeMeca.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_FermeMeca.Sections("Section4").Controls("lblFax").Caption = m_sFaxContact
50: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FermeMeca.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_FermeMeca.Sections("Section4").Controls("lblSoum").Caption = txtNoSoumission.Text
55: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FermeMeca.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_FermeMeca.Sections("Section4").Controls("lblProj").Caption = txtNoProjet.Text
60: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FermeMeca.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_FermeMeca.Sections("Section4").Controls("lblProjetNom").Caption = txtNomProjet.Text
65: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FermeMeca.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_FermeMeca.Sections("Section4").Controls("lblDate").Caption = mskDate.Text
70: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FermeMeca.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_FermeMeca.Sections("Section4").Controls("lblDateOuverture").Caption = ConvertDate(Today)
75: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FermeMeca.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_FermeMeca.Sections("Section4").Controls("lblProjet").Caption = txtProjetClient.Text
		
		'affiche rapport
80: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FermeMeca.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_FermeMeca.Show(VB6.FormShowConstants.Modal)
		
85: Call rstBonLivraison.Close()
90: 'UPGRADE_NOTE: Object rstBonLivraison may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBonLivraison = Nothing
		
95: Exit Sub
		
AfficherErreur: 
		
100: Call AfficherErreur("frmreport", "ImprimerFermetureMecanique", Err, Erl())
	End Sub
	
	Private Sub ImprimerFermeture()
		Dim DR_Fermeture As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBonLivraison As ADODB.Recordset
		
15: rstBonLivraison = New ADODB.Recordset
		
20: Call rstBonLivraison.Open("SELECT * FROM GRB_impression_bonlivraison", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'set le rapport
25: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fermeture.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fermeture.DataSource = rstBonLivraison
		
		'contenu label
30: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fermeture.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fermeture.Sections(1).Controls(117).Caption = cmbClient.Text
35: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fermeture.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fermeture.Sections(1).Controls(118).Caption = cmbcontact.Text
40: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fermeture.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fermeture.Sections(1).Controls(119).Caption = m_sTelContact
45: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fermeture.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fermeture.Sections(1).Controls(120).Caption = m_sFaxContact
50: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fermeture.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fermeture.Sections(1).Controls(121).Caption = txtNoSoumission.Text
55: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fermeture.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fermeture.Sections(1).Controls(122).Caption = txtNoProjet.Text
60: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fermeture.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fermeture.Sections(1).Controls(123).Caption = txtNomProjet.Text
65: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fermeture.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fermeture.Sections(1).Controls(124).Caption = mskDate.Text
70: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fermeture.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fermeture.Sections(1).Controls(125).Caption = ConvertDate(Today)
75: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fermeture.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Fermeture.Sections(1).Controls(126).Caption = txtProjetClient.Text
		
		'affiche rapport
80: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Fermeture.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_Fermeture.Show(VB6.FormShowConstants.Modal)
		
85: Call rstBonLivraison.Close()
90: 'UPGRADE_NOTE: Object rstBonLivraison may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBonLivraison = Nothing
		
95: Exit Sub
		
AfficherErreur: 
		
100: Call AfficherErreur("frmreport", "ImprimerFermeture", Err, Erl())
	End Sub
	
	Private Sub ImprimerFinFabrication()
		Dim DR_FinFab As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBonLivraison As ADODB.Recordset
		
15: rstBonLivraison = New ADODB.Recordset
		
20: Call rstBonLivraison.Open("SELECT * FROM GRB_impression_bonlivraison", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'set le rapport
25: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FinFab.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_FinFab.DataSource = rstBonLivraison
		
		'affiche rapport
30: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FinFab.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_FinFab.Show(VB6.FormShowConstants.Modal)
		
35: Call rstBonLivraison.Close()
40: 'UPGRADE_NOTE: Object rstBonLivraison may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBonLivraison = Nothing
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmreport", "ImprimerFinFabrication", Err, Erl())
	End Sub
	
	Private Sub ImprimerFax(ByVal eLangue As enumLangueFax)
		Dim DR_FaxFrancais As Object
		Dim DR_FaxAnglais As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim drFax As MSDataReportLib.DataReport
15: Dim rstBonLivraison As ADODB.Recordset
20: Dim bClient As Boolean
25: Dim bClientTexte As Boolean
30: Dim bClientListIndex As Boolean
35: Dim bFournisseur As Boolean
40: Dim bFournisseurTexte As Boolean
45: Dim bFournisseurListIndex As Boolean
50: Dim bContactClient As Boolean
55: Dim bContactClientTexte As Boolean
60: Dim bContactClientListIndex As Boolean
65: Dim bContactFRS As Boolean
70: Dim bContactFRSTexte As Boolean
75: Dim bContactFRSListIndex As Boolean
80: Dim sMessage As String
		
85: If eLangue = enumLangueFax.FAX_ANGLAIS Then
90: drFax = DR_FaxAnglais
95: Else
100: drFax = DR_FaxFrancais
105: End If
		
110: If cmbClient.SelectedIndex <> -1 Or cmbClient.Text <> "" Then
115: bClient = True
			
120: If cmbClient.SelectedIndex <> -1 Then
125: bClientListIndex = True
130: Else
135: bClientTexte = True
140: End If
145: End If
		
150: If cmbFournisseur.SelectedIndex <> -1 Or cmbFournisseur.Text <> "" Then
155: bFournisseur = True
			
160: If cmbFournisseur.SelectedIndex <> -1 Then
165: bFournisseurListIndex = True
170: Else
175: bFournisseurTexte = True
180: End If
185: End If
		
190: If cmbcontact.SelectedIndex <> -1 Or cmbcontact.Text <> "" Then
195: bContactClient = True
			
200: If cmbcontact.SelectedIndex <> -1 Then
205: bContactClientListIndex = True
210: Else
215: bContactClientTexte = True
220: End If
225: End If
		
230: If cmbContactFRS.SelectedIndex <> -1 Or cmbContactFRS.Text <> "" Then
235: bContactFRS = True
			
240: If cmbContactFRS.SelectedIndex <> -1 Then
245: bContactFRSListIndex = True
250: Else
255: bContactFRSTexte = True
260: End If
265: End If
		
270: If bClient = False And bFournisseur = False And bContactClient = False And bContactFRS = False Then
275: If MsgBox("Voulez-vous choisir un destinataire?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
280: Exit Sub
285: End If
290: End If
		
		'Ce recordset ne sert à rien, il est utilisé uniquement pour le DataSource
		'du DataReport. Un DataReport ne peut être ouvert s'il n'a pas de DataSource
295: rstBonLivraison = New ADODB.Recordset
		
300: Call rstBonLivraison.Open("SELECT * FROM GRB_Impression_BonLivraison", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
305: drFax.DataSource = rstBonLivraison
		
		'Contenu label
310: drFax.Sections(1).Controls("lblDate").Text = ConvertDate(Today)
		
315: If bClient = True Then
320: drFax.Sections(1).Controls("lblAttention").Text = cmbcontact.Text
325: Else
330: If bFournisseur = True Then
335: drFax.Sections(1).Controls("lblAttention").Text = cmbContactFRS.Text
340: Else
345: If bContactClient = True Then
350: drFax.Sections(1).Controls("lblAttention").Text = cmbcontact.Text
355: Else
360: If bContactFRS = True Then
365: drFax.Sections(1).Controls("lblAttention").Text = cmbContactFRS.Text
370: Else
375: drFax.Sections(1).Controls("lblAttention").Text = ""
380: End If
385: End If
390: End If
395: End If
		
400: If bClient = True Then
405: drFax.Sections(1).Controls("lblEntreprise").Text = cmbClient.Text
410: Else
415: If bFournisseur = True Then
420: drFax.Sections(1).Controls("lblEntreprise").Text = cmbFournisseur.Text
425: Else
430: drFax.Sections(1).Controls("lblEntreprise").Text = ""
435: End If
440: End If
		
445: If bClientListIndex = True And bContactClientListIndex = True Then
450: sMessage = "Voulez-vous afficher le numéro de fax du client?" & vbNewLine & "Oui - Fax du client" & vbNewLine & "Non - Fax du contact"
455: Else
460: If bFournisseurListIndex = True And bContactFRSListIndex = True Then
465: sMessage = "Voulez-vous afficher le numéro de fax du fournisseur?" & vbNewLine & "Oui - Fax du fournisseur" & vbNewLine & "Non - Fax du contact"
470: End If
475: End If
		
480: If sMessage = vbNullString Then
485: If bFournisseurListIndex = True Or bClientListIndex = True Then
490: drFax.Sections(1).Controls("lblFax").Text = m_sFaxClientFRS
495: Else
500: drFax.Sections(1).Controls("lblFax").Text = m_sFaxContact
505: End If
510: Else
515: If MsgBox(sMessage, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
520: drFax.Sections(1).Controls("lblFax").Text = m_sFaxClientFRS
525: Else
530: drFax.Sections(1).Controls("lblFax").Text = m_sFaxContact
535: End If
540: End If
		
545: If txtNoProjet.Text <> vbNullString Then
550: drFax.Sections(1).Controls("lblNoProjetSoum").Text = "# Projet:"
555: drFax.Sections(1).Controls("lblProjet").Text = txtNoProjet.Text
560: Else
565: drFax.Sections(1).Controls("lblNoProjetSoum").Text = "# Soumission:"
570: drFax.Sections(1).Controls("lblProjet").Text = txtNoSoumission.Text
575: End If
		
580: drFax.Sections(1).Controls("lblPage").Text = txtPage.Text
585: drFax.Sections(1).Controls("lblDe").Text = txtDe.Text
590: drFax.Sections(1).Controls("lblMessage").Text = txtMsg.Text
595: drFax.Sections(1).Controls("lblSujet").Text = txtObjet.Text
		
		'Affiche rapport
600: drFax.Orientation = MSDataReportLib.OrientationConstants.rptOrientPortrait
		
605: If eLangue = enumLangueFax.FAX_ANGLAIS Then
610: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FaxAnglais.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call DR_FaxAnglais.Show(VB6.FormShowConstants.Modal)
615: Else
620: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FaxFrancais.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call DR_FaxFrancais.Show(VB6.FormShowConstants.Modal)
625: End If
		
630: Call rstBonLivraison.Close()
635: 'UPGRADE_NOTE: Object rstBonLivraison may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBonLivraison = Nothing
		
640: Exit Sub
		
AfficherErreur: 
		
645: Call AfficherErreur("frmreport", "ImprimerFax", Err, Erl())
	End Sub
	
	Private Sub ImprimerProblemes()
		Dim DR_Probleme As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBonLivraison As ADODB.Recordset
		
		'Ce recordset ne sert à rien, il est utilisé uniquement pour le DataSource
		'du DataReport. Un DataReport ne peut être ouvert s'il n'a pas de DataSource
15: rstBonLivraison = New ADODB.Recordset
		
20: Call rstBonLivraison.Open("SELECT * FROM GRB_Impression_BonLivraison", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Probleme.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Probleme.DataSource = rstBonLivraison
		
		'Contenu label
30: If txtNoSoumission.Text <> "" Then
35: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Probleme.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Probleme.Sections("Section4").Controls("lblTitreProjSoum").Caption = "# Soum :"
40: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Probleme.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Probleme.Sections("Section4").Controls("lblNoProjSoum").Caption = txtNoSoumission.Text
45: Else
50: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Probleme.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Probleme.Sections("Section4").Controls("lblTitreProjSoum").Caption = "# Projet :"
55: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Probleme.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Probleme.Sections("Section4").Controls("lblNoProjSoum").Caption = txtNoProjet.Text
60: End If
		
65: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Probleme.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Probleme.Sections("Section4").Controls("lblNomEmploye").Caption = cmbGRB.Text
		
		'Affiche rapport
70: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Probleme.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Probleme.Orientation = MSDataReportLib.OrientationConstants.rptOrientLandscape
		
75: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Probleme.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_Probleme.Show(VB6.FormShowConstants.Modal)
		
80: Call rstBonLivraison.Close()
85: 'UPGRADE_NOTE: Object rstBonLivraison may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBonLivraison = Nothing
		
90: Exit Sub
		
AfficherErreur: 
		
95: Call AfficherErreur("frmreport", "ImprimerProblemes", Err, Erl())
	End Sub
	
	Private Sub cmdreport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdreport.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'rapport bon de travail
15: If ChkBonTravail.CheckState = System.Windows.Forms.CheckState.Checked Then
20: Call ImprimerBonTravail()
25: End If
		
		'rapport bon de livraison
30: If chkBonLivraison.CheckState = System.Windows.Forms.CheckState.Checked Then
35: Call ImprimerBonLivraison()
40: End If
		
		'rapport client
45: If ChkClient.CheckState = System.Windows.Forms.CheckState.Checked Then
50: Call ImprimerClient()
55: End If
		
		'rapport fournisseur
60: If ChkFourn.CheckState = System.Windows.Forms.CheckState.Checked Then
65: Call ImprimerFournisseur()
70: End If
		
		'rapport conception
75: If ChkConcept.CheckState = System.Windows.Forms.CheckState.Checked Then
80: Call ImprimerConception()
85: End If
		
		'rapport programmation
90: If ChkProg.CheckState = System.Windows.Forms.CheckState.Checked Then
95: Call ImprimerProgrammation()
100: End If
		
		'rapport fabrication - fermeture mécanique
105: If ChkFabFermMéca.CheckState = System.Windows.Forms.CheckState.Checked Then
110: Call ImprimerFermetureMecanique()
115: End If
		
		'rapport fabrication - fermeture
120: If ChkFabFerm.CheckState = System.Windows.Forms.CheckState.Checked Then
125: Call ImprimerFermeture()
130: End If
		
		'rapport fin fabrication
135: If ChkFinFab.CheckState = System.Windows.Forms.CheckState.Checked Then
140: Call ImprimerFinFabrication()
145: End If
		
		'rapport de problèmes
150: If chkProblemes.CheckState = System.Windows.Forms.CheckState.Checked Then
155: Call ImprimerProblemes()
160: End If
		
		'rapport fax francais
165: If chkFaxFrancais.CheckState = System.Windows.Forms.CheckState.Checked Then
170: Call ImprimerFax(enumLangueFax.FAX_FRANCAIS)
175: End If
		
		'rapport fax anglais
180: If chkFaxAnglais.CheckState = System.Windows.Forms.CheckState.Checked Then
185: Call ImprimerFax(enumLangueFax.FAX_ANGLAIS)
190: End If
		
195: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
200: Exit Sub
		
AfficherErreur: 
		
205: Call AfficherErreur("frmreport", "cmdreport_Click", Err, Erl())
	End Sub
	
	Private Sub cmdselect_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdselect.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iValue As Short
		
15: If cmdSelect.Text = S_SELECT_ALL Then
20: iValue = System.Windows.Forms.CheckState.Checked
			
25: cmdSelect.Text = S_UNSELECT_ALL
30: Else
35: iValue = System.Windows.Forms.CheckState.Unchecked
			
40: cmdSelect.Text = S_SELECT_ALL
45: End If
		
50: m_bSelectAll = True
		
55: ChkBonTravail.CheckState = iValue
60: ChkClient.CheckState = iValue
65: ChkConcept.CheckState = iValue
70: ChkFabFerm.CheckState = iValue
75: ChkFabFermMéca.CheckState = iValue
80: ChkFinFab.CheckState = iValue
85: ChkFourn.CheckState = iValue
90: ChkProg.CheckState = iValue
95: chkBonLivraison.CheckState = iValue
100: chkProblemes.CheckState = iValue
105: chkFaxFrancais.CheckState = iValue
110: chkFaxAnglais.CheckState = iValue
		
115: Call AfficherControles()
		
120: m_bSelectAll = False
		
125: Exit Sub
		
AfficherErreur: 
		
130: Call AfficherErreur("frmreport", "cmdselect_Click", Err, Erl())
	End Sub
	
	Private Sub frmreport_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: m_iNoClient = 0
15: m_iNoClient2 = 0
20: m_iNoContact = 0
25: m_iNoFRS = 0
30: m_iNoGRB = 0
		
		'rempli les combo
35: Call RemplirComboClient(vbNullString)
40: Call RemplirComboClient2(vbNullString)
45: Call RemplirComboContact()
50: Call RemplirComboGRB()
55: Call RemplirComboFRS(vbNullString)
60: Call RemplirComboFRS2(vbNullString)
		
65: Call AfficherControles()
		
70: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'rempli
75: mskDate.Text = Year(Today) & "-" & VB.Right("0" & Month(Today), 2) & "-" & VB.Right("0" & VB.Day(Today), 2)
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmreport", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub RemplirComboFRS(ByVal sRecherche As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstFournisseur As ADODB.Recordset
		
15: rstFournisseur = New ADODB.Recordset
		
20: Call rstFournisseur.Open("SELECT NomFournisseur, IDFRS FROM GRB_Fournisseur WHERE Instr(1, NomFournisseur, '" & Replace(sRecherche, "'", "''") & "') > 0 AND Supprimé = False ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'vide combo
25: Call cmbFournisseur.Items.Clear()
		
		'rempli les combo tant que pas fin d'enregistrement
30: Do While Not rstFournisseur.EOF
35: Call cmbFournisseur.Items.Add(rstFournisseur.Fields("NomFournisseur").Value)
40: 'UPGRADE_ISSUE: ComboBox property cmbFournisseur.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbFournisseur, cmbFournisseur.NewIndex, rstFournisseur.Fields("IDFRS").Value)
			
			
45: Call rstFournisseur.MoveNext()
50: Loop 
		
55: Call rstFournisseur.Close()
60: 'UPGRADE_NOTE: Object rstFournisseur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFournisseur = Nothing
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmreport", "RemplirComboFRS", Err, Erl())
	End Sub
	
	Private Sub RemplirComboFRS2(ByVal sRecherche As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstFournisseur As ADODB.Recordset
		
15: rstFournisseur = New ADODB.Recordset
		
20: Call rstFournisseur.Open("SELECT NomFournisseur, IDFRS FROM GRB_Fournisseur WHERE Instr(1, NomFournisseur, '" & Replace(sRecherche, "'", "''") & "') > 0 AND Supprimé = False ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'vide combo
25: Call cmbFournisseur2.Items.Clear()
		
		'rempli les combo tant que pas fin d'enregistrement
30: Do While Not rstFournisseur.EOF
35: Call cmbFournisseur2.Items.Add(rstFournisseur.Fields("NomFournisseur").Value)
40: 'UPGRADE_ISSUE: ComboBox property cmbFournisseur2.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbFournisseur2, cmbFournisseur2.NewIndex, rstFournisseur.Fields("IDFRS").Value)
			
			
45: Call rstFournisseur.MoveNext()
50: Loop 
		
55: Call rstFournisseur.Close()
60: 'UPGRADE_NOTE: Object rstFournisseur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFournisseur = Nothing
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmreport", "RemplirComboFRS2", Err, Erl())
	End Sub
	
	Private Sub RemplirComboClient(ByVal sRecherche As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstClient As ADODB.Recordset
		
		'set les tables
15: rstClient = New ADODB.Recordset
		
20: Call rstClient.Open("SELECT NomClient, IDClient FROM GRB_client WHERE Instr(1, NomClient, '" & Replace(sRecherche, "'", "''") & "') > 0 AND Supprimé = False ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'vide combo
25: Call cmbClient.Items.Clear()
		
		'rempli les combo tant que pas fin d'enregistrement
30: Do While Not rstClient.EOF
35: Call cmbClient.Items.Add(rstClient.Fields("nomclient").Value)
40: 'UPGRADE_ISSUE: ComboBox property cmbClient.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbClient, cmbClient.NewIndex, rstClient.Fields("idclient").Value)
			
45: Call rstClient.MoveNext()
50: Loop 
		
55: Call rstClient.Close()
60: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient = Nothing
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmreport", "RemplirComboClient", Err, Erl())
	End Sub
	
	Private Sub RemplirComboClient2(ByVal sRecherche As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstClient As ADODB.Recordset
		
15: rstClient = New ADODB.Recordset
		
20: Call rstClient.Open("SELECT NomClient, IDClient FROM GRB_client WHERE Instr(1, NomClient, '" & Replace(sRecherche, "'", "''") & "') > 0 AND Supprimé = False ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'vide combo
25: Call cmbClient2.Items.Clear()
		
		'rempli les combo tant que pas fin d'enregistrement
30: Do While Not rstClient.EOF
35: Call cmbClient2.Items.Add(rstClient.Fields("nomclient").Value)
40: 'UPGRADE_ISSUE: ComboBox property cmbClient2.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbClient2, cmbClient2.NewIndex, rstClient.Fields("idclient").Value)
			
			
45: Call rstClient.MoveNext()
50: Loop 
		
55: Call rstClient.Close()
60: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient = Nothing
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmreport", "RemplirComboClient2", Err, Erl())
	End Sub
	
	Private Sub RemplirComboContact()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstContact As ADODB.Recordset
		
		'si client de selectionné, remplis les liste contact pour le client
		'sinon met tout les contact
15: rstContact = New ADODB.Recordset
		
20: If m_iNoClient > 0 Then
25: Call rstContact.Open("SELECT GRB_Contact.IDContact, GRB_Contact.NomContact, GRB_ContactClient.NoClient FROM GRB_Contact INNER JOIN GRB_ContactClient ON GRB_Contact.IDContact = GRB_ContactClient.NoContact WHERE CStr(GRB_ContactClient.noclient) = CStr('" & m_iNoClient & "') ORDER BY GRB_contact.NomContact", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
30: Else
35: Call rstContact.Open("SELECT NomContact, IDContact FROM GRB_Contact WHERE Supprimé = False ORDER BY Nomcontact", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
40: End If
		
		'vide combo
45: Call cmbcontact.Items.Clear()
		
		'rempli les combo tant que pas fin d'enregistrement
50: Do While Not rstContact.EOF
			'si trouve le text dans le nom du contact, ajoute dans combo
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("NomContact").Value) Then
60: Call cmbcontact.Items.Add(rstContact.Fields("NomContact").Value)
65: 'UPGRADE_ISSUE: ComboBox property cmbcontact.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				VB6.SetItemData(cmbcontact, cmbcontact.NewIndex, rstContact.Fields("IDContact").Value)
				
70: Call rstContact.MoveNext()
75: End If
80: Loop 
		
85: Call rstContact.Close()
90: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
95: Exit Sub
		
AfficherErreur: 
		
100: Call AfficherErreur("frmreport", "RemplirComboContact", Err, Erl())
	End Sub
	
	Private Sub RemplirComboContactFRS()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstContactFRS As ADODB.Recordset
15: Dim rstContact As ADODB.Recordset
		
		'si fournisseur de selectionné, remplis les liste contact pour le client
		'sinon met tout les contact
20: If m_iNoFRS > 0 Then
25: rstContactFRS = New ADODB.Recordset
			
30: Call rstContactFRS.Open("SELECT * FROM GRB_ContactFRS WHERE NoFRS = " & m_iNoFRS, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
35: Else
40: Exit Sub
45: End If
		
		'vide combo
50: Call cmbContactFRS.Items.Clear()
		
		'rempli les combo tant que pas fin d'enregistrement
55: rstContact = New ADODB.Recordset
		
60: Do While Not rstContactFRS.EOF
65: Call rstContact.Open("SELECT NomContact, IDContact FROM GRB_Contact WHERE IDContact = " & rstContactFRS.Fields("NoContact").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
70: If Not rstContact.EOF Then
75: Call cmbContactFRS.Items.Add(rstContact.Fields("NomContact").Value)
80: 'UPGRADE_ISSUE: ComboBox property cmbContactFRS.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				VB6.SetItemData(cmbContactFRS, cmbContactFRS.NewIndex, rstContact.Fields("IDContact").Value)
85: End If
			
90: Call rstContact.Close()
			
95: Call rstContactFRS.MoveNext()
100: Loop 
		
105: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
110: Call rstContactFRS.Close()
115: 'UPGRADE_NOTE: Object rstContactFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContactFRS = Nothing
		
120: Exit Sub
		
AfficherErreur: 
		
125: Call AfficherErreur("frmreport", "RemplirComboContactFRS", Err, Erl())
	End Sub
	
	Private Sub RemplirComboGRB()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstContactGRB As ADODB.Recordset
		
15: rstContactGRB = New ADODB.Recordset
		
20: Call rstContactGRB.Open("SELECT employe, noEmploye FROM GRB_employés WHERE Actif = true ORDER BY employe", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'vide combo
25: Call cmbGRB.Items.Clear()
		
		'rempli les combo tant que pas fin d'enregistrement
30: Do While Not rstContactGRB.EOF
35: Call cmbGRB.Items.Add(rstContactGRB.Fields("Employe").Value)
40: 'UPGRADE_ISSUE: ComboBox property cmbGRB.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbGRB, cmbGRB.NewIndex, rstContactGRB.Fields("noEmploye").Value)
			
45: Call rstContactGRB.MoveNext()
50: Loop 
		
55: Call rstContactGRB.Close()
60: 'UPGRADE_NOTE: Object rstContactGRB may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContactGRB = Nothing
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmreport", "RemplirComboGRB", Err, Erl())
	End Sub
	
	Private Sub mskDate_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDate.Enter
		
5: On Error GoTo AfficherErreur
		
10: If Len(mskDate.Text) = 10 Then
15: mskDate.Text = VB.Right(mskDate.Text, 8)
20: End If
		
25: mskDate.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmreport", "mskDate_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskDate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDate.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskDate.Mask = vbNullString
		
15: If mskDate.Text = "__-__-__" Then
20: mskDate.Text = vbNullString
25: Else
30: If Len(mskDate.Text) = 8 Then
35: If IsDate(mskDate.Text) Then
40: mskDate.Text = Year(DateSerial(CInt(VB.Left(mskDate.Text, 2)), CInt(Mid(mskDate.Text, 4, 2)), CInt(VB.Right(mskDate.Text, 2)))) & Mid(mskDate.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmreport", "mskDate_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateDue_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateDue.Enter
		
5: On Error GoTo AfficherErreur
		
10: If Len(mskDateDue.Text) = 10 Then
15: mskDateDue.Text = VB.Right(mskDateDue.Text, 8)
20: End If
		
25: mskDateDue.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmreport", "mskDateDue_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateDue_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateDue.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskDateDue.Mask = vbNullString
		
15: If mskDateDue.Text = "__-__-__" Then
20: mskDateDue.Text = vbNullString
25: Else
30: If Len(mskDateDue.Text) = 8 Then
35: If IsDate(mskDateDue.Text) Then
40: mskDateDue.Text = Year(DateSerial(CInt(VB.Left(mskDateDue.Text, 2)), CInt(Mid(mskDateDue.Text, 4, 2)), CInt(VB.Right(mskDateDue.Text, 2)))) & Mid(mskDateDue.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmreport", "mskDateDue_LostFocus", Err, Erl())
	End Sub
	
	
	Private Sub mskdatecommande_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskdatecommande.Enter
		
5: On Error GoTo AfficherErreur
		
10: If Len(mskDateCommande.Text) = 10 Then
15: mskDateCommande.Text = VB.Right(mskDateCommande.Text, 8)
20: End If
		
25: mskDateCommande.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmreport", "mskdatecommande_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskdatecommande_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskdatecommande.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskDateCommande.Mask = vbNullString
		
15: If mskDateCommande.Text = "__-__-__" Then
20: mskDateCommande.Text = vbNullString
25: Else
30: If Len(mskDateCommande.Text) = 8 Then
35: If IsDate(mskDateCommande.Text) Then
40: mskDateCommande.Text = Year(DateSerial(CInt(VB.Left(mskDateCommande.Text, 2)), CInt(Mid(mskDateCommande.Text, 4, 2)), CInt(VB.Right(mskDateCommande.Text, 2)))) & Mid(mskDateCommande.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmreport", "mskdatecommande_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskdatelivraison_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskdatelivraison.Enter
		
5: On Error GoTo AfficherErreur
		
10: If Len(mskDateLivraison.Text) = 10 Then
15: mskDateLivraison.Text = VB.Right(mskDateCommande.Text, 8)
20: End If
		
25: mskDateLivraison.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmreport", "mskdatelivraison_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskdatelivraison_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskdatelivraison.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskDateLivraison.Mask = vbNullString
		
15: If mskDateLivraison.Text = "__-__-__" Then
20: mskDateLivraison.Text = vbNullString
25: Else
30: If Len(mskDateLivraison.Text) = 8 Then
35: If IsDate(mskDateLivraison.Text) Then
40: mskDateLivraison.Text = Year(DateSerial(CInt(VB.Left(mskDateLivraison.Text, 2)), CInt(Mid(mskDateLivraison.Text, 4, 2)), CInt(VB.Right(mskDateLivraison.Text, 2)))) & Mid(mskDateLivraison.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmreport", "mskdatelivraison_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateTravaux_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateTravaux.Enter
		
5: On Error GoTo AfficherErreur
		
10: If Len(mskDateTravaux.Text) = 10 Then
15: mskDateTravaux.Text = VB.Right(mskDateTravaux.Text, 8)
20: End If
		
25: mskDateTravaux.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmreport", "mskDateTravaux_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateTravaux_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateTravaux.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskDateTravaux.Mask = vbNullString
		
15: If mskDateTravaux.Text = "__-__-__" Then
20: mskDateTravaux.Text = vbNullString
25: Else
30: If Len(mskDateTravaux.Text) = 8 Then
35: If IsDate(mskDateTravaux.Text) Then
40: mskDateTravaux.Text = Year(DateSerial(CInt(VB.Left(mskDateTravaux.Text, 2)), CInt(Mid(mskDateTravaux.Text, 4, 2)), CInt(VB.Right(mskDateTravaux.Text, 2)))) & Mid(mskDateTravaux.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmreport", "mskDateTravaux_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskHeureTravaux_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskHeureTravaux.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskHeureTravaux.Mask = "##:##"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmreport", "mskHeureTravaux_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskHeureTravaux_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskHeureTravaux.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskHeureTravaux.Mask = vbNullString
		
15: If mskHeureTravaux.Text = "__:__" Then
20: mskHeureTravaux.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmreport", "mskHeureTravaux_LostFocus", Err, Erl())
	End Sub
End Class