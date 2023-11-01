Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class FrmClient
	Inherits System.Windows.Forms.Form
	
	Private Enum enumMode
		MODE_CLIENT = 0
		MODE_CONTACT = 1
		MODE_INACTIF = 2
	End Enum
	
	Public m_bCategorieBeton As Boolean
	Public m_bCategoriePave As Boolean
	Public m_bCategoriePharmaceutique As Boolean
	Public m_bCategorieAgroalimentaire As Boolean
	Public m_bCategorieMeuble As Boolean
	Public m_bCategorieMeunerie As Boolean
	Public m_bCategorieManufacturier As Boolean
	Public m_bCategorieConsultant As Boolean
	Public m_bCategorieAsphalte As Boolean
	Public m_bCategorieICPI As Boolean
	Public m_bCategorieProduitsChimiques As Boolean
	Public m_bCategorieAutre As Boolean
	
	'Choix d'impression
	Public m_bImpressionAnnuler As Boolean
	Public m_bImpressionVille As Boolean
	Public m_bImpressionCategorie As Boolean
	Public m_bImpressionPotentiel As Boolean
	Public m_bImpressionFacturer As Boolean
	
	'Choix d'impression de categorie
	Public m_bImpressionBeton As Boolean
	Public m_bImpressionPave As Boolean
	Public m_bImpressionPharmaceutique As Boolean
	Public m_bImpressionAgroAlimentaire As Boolean
	Public m_bImpressionMeuble As Boolean
	Public m_bImpressionMeunerie As Boolean
	Public m_bImpressionManufacturier As Boolean
	Public m_bImpressionConsultant As Boolean
	Public m_bImpressionAsphalte As Boolean
	Public m_bImpressionICPI As Boolean
	Public m_bImpressionProduitsChimiques As Boolean
	Public m_bImpressionAutre As Boolean
	
	Private m_bModeAjoutContact As Boolean
	Private m_bModeAjoutClient As Boolean
	Private m_iNoContact As Short
	Private m_iNoClient As Short
	Private m_bRenommer As Boolean
	Private m_bNewContact As Boolean
	
	Public m_bAnnulerDistList As Boolean
	Public m_otlDistList As Outlook.DistListItem
	
	Public m_bAnnulerVille As Boolean
	Public m_sVille As String
	
	Private m_eMode As enumMode
	
	Private Sub RemplirComboClient()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des clients
10: Dim rstClient As ADODB.Recordset
		
		'Il faut vider le combo avant de le remplir
15: Call cmbClient.Items.Clear()
		
20: rstClient = New ADODB.Recordset
		
25: Call rstClient.Open("SELECT NomClient, IDClient FROM GRB_Client WHERE Supprimé = False", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
30: Do While Not rstClient.EOF
			'Ajout du nom du client dans le combo
35: Call cmbClient.Items.Add(Trim(rstClient.Fields("NomClient").Value))
			
			'Ajout du numéro du client dans le ItemData du combo
40: 'UPGRADE_ISSUE: ComboBox property cmbClient.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbClient, cmbClient.NewIndex, rstClient.Fields("IDClient").Value)
			
45: Call rstClient.MoveNext()
50: Loop 
		
55: Call rstClient.Close()
60: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient = Nothing
		
65: If cmbClient.Items.Count > 0 Then
70: cmbClient.SelectedIndex = 0
75: End If
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmClient", "RemplirComboClient", Err, Erl())
	End Sub
	
	Private Sub AfficherClient()
		
5: On Error GoTo AfficherErreur
		
		'Affiche le client sélectionné
10: Dim rstClient As ADODB.Recordset
		
15: rstClient = New ADODB.Recordset
		
20: Call rstClient.Open("SELECT * FROM GRB_Client WHERE IDClient = " & m_iNoClient, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: Call ViderBarrerChamps(True, True)
		
		'Telephonne
30: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstClient.Fields("Telephonne").Value) Then
35: txtTelephone.Text = rstClient.Fields("Telephonne").Value
40: End If
		
		'Fax
45: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstClient.Fields("Fax").Value) Then
50: txtFax.Text = rstClient.Fields("Fax").Value
55: End If
		
		'ContactGRB
60: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstClient.Fields("ContactGRB").Value) Then
65: txtContactGRB.Text = rstClient.Fields("ContactGRB").Value
70: End If
		
		'Email
75: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstClient.Fields("Email").Value) Then
80: txtEmail.Text = rstClient.Fields("Email").Value
85: End If
		
		'AdresseLiv
90: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstClient.Fields("AdresseLiv").Value) Then
95: txtAdresse.Text = rstClient.Fields("AdresseLiv").Value
100: End If
		
		'VilleLiv
105: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstClient.Fields("VilleLiv").Value) Then
120: txtVille.Text = rstClient.Fields("VilleLiv").Value
125: End If
		
		'Prov/EtatLiv
130: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstClient.Fields("Prov/EtatLiv").Value) Then
135: txtProvEtat.Text = rstClient.Fields("Prov/EtatLiv").Value
140: End If
		
		'PaysLiv
145: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstClient.Fields("PaysLiv").Value) Then
150: txtPays.Text = rstClient.Fields("PaysLiv").Value
155: End If
		
		'CodePostalLiv
160: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstClient.Fields("CodePostalLiv").Value) Then
165: txtCP.Text = rstClient.Fields("CodePostalLiv").Value
170: End If
		
		'Commentaire
175: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstClient.Fields("Commentaire").Value) Then
180: txtcommentaire.Text = rstClient.Fields("Commentaire").Value
185: End If
		
		'Site Web
190: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstClient.Fields("SiteWeb").Value) Then
195: txtSiteWeb.Text = rstClient.Fields("SiteWeb").Value
200: End If
		
		'Création
205: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstClient.Fields("DateCréation").Value) Then
210: lblDateCreation.Text = rstClient.Fields("DateCréation").Value
215: End If
		
		'User Création
220: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstClient.Fields("UserCréation").Value) Then
225: lblUserCreation.Text = "Par : " & rstClient.Fields("UserCréation").Value
230: End If
		
		'Modification
235: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstClient.Fields("DateModification").Value) Then
240: lblDateModification.Text = rstClient.Fields("DateModification").Value
245: End If
		
		'User Modification
250: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstClient.Fields("UserModification").Value) Then
255: lblUserModification.Text = "Par : " & rstClient.Fields("UserModification").Value
260: End If
		
265: 'Client Potentiel
270: If rstClient.Fields("Potentiel").Value = True Then
275: chkClientPotentiel.CheckState = System.Windows.Forms.CheckState.Checked
280: End If
		
285: m_bCategorieBeton = rstClient.Fields("Béton").Value
290: m_bCategoriePave = rstClient.Fields("Pavé").Value
295: m_bCategoriePharmaceutique = rstClient.Fields("Pharmaceutique").Value
300: m_bCategorieAgroalimentaire = rstClient.Fields("Agroalimentaire").Value
305: m_bCategorieMeuble = rstClient.Fields("Meuble").Value
310: m_bCategorieMeunerie = rstClient.Fields("Meunerie").Value
315: m_bCategorieManufacturier = rstClient.Fields("Manufacturier").Value
320: m_bCategorieConsultant = rstClient.Fields("Consultant").Value
325: m_bCategorieAsphalte = rstClient.Fields("Asphalte").Value
330: m_bCategorieICPI = rstClient.Fields("ICPI").Value
335: m_bCategorieProduitsChimiques = rstClient.Fields("ProduitsChimiques").Value
340: m_bCategorieAutre = rstClient.Fields("Autre").Value
		
345: Call AfficherCategories()
		
350: Call rstClient.Close()
355: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient = Nothing
		
360: Exit Sub
		
AfficherErreur: 
		
365: Call AfficherErreur("frmClient", "AfficherClient", Err, Erl())
	End Sub
	
	Private Sub AfficherCategories()
		
5: On Error GoTo AfficherErreur
		
10: txtCategorie.Text = ""
		
15: If m_bCategorieBeton = True Then
20: txtCategorie.Text = "Béton"
25: End If
		
30: If m_bCategoriePave = True Then
35: If Trim(txtCategorie.Text) <> "" Then
40: txtCategorie.Text = txtCategorie.Text & ", Pavé"
45: Else
50: txtCategorie.Text = "Pavé"
55: End If
60: End If
		
65: If m_bCategoriePharmaceutique = True Then
70: If Trim(txtCategorie.Text) <> "" Then
75: txtCategorie.Text = txtCategorie.Text & ", Pharmaceutique"
80: Else
85: txtCategorie.Text = "Pharmaceutique"
90: End If
95: End If
		
100: If m_bCategorieAgroalimentaire = True Then
105: If Trim(txtCategorie.Text) <> "" Then
110: txtCategorie.Text = txtCategorie.Text & ", Agroalimentaire"
115: Else
120: txtCategorie.Text = "Agroalimentaire"
125: End If
130: End If
		
135: If m_bCategorieMeuble = True Then
140: If Trim(txtCategorie.Text) <> "" Then
145: txtCategorie.Text = txtCategorie.Text & ", Meuble"
150: Else
155: txtCategorie.Text = "Meuble"
160: End If
165: End If
		
170: If m_bCategorieMeunerie = True Then
175: If Trim(txtCategorie.Text) <> "" Then
180: txtCategorie.Text = txtCategorie.Text & ", Meunerie"
185: Else
190: txtCategorie.Text = "Meunerie"
195: End If
200: End If
		
205: If m_bCategorieManufacturier = True Then
210: If Trim(txtCategorie.Text) <> "" Then
215: txtCategorie.Text = txtCategorie.Text & ", Manufacturier"
220: Else
225: txtCategorie.Text = "Manufacturier"
230: End If
235: End If
		
240: If m_bCategorieConsultant = True Then
245: If Trim(txtCategorie.Text) <> "" Then
250: txtCategorie.Text = txtCategorie.Text & ", Consultant"
255: Else
260: txtCategorie.Text = "Consultant"
265: End If
270: End If
		
275: If m_bCategorieAsphalte = True Then
280: If Trim(txtCategorie.Text) <> "" Then
285: txtCategorie.Text = txtCategorie.Text & ", Asphalte"
290: Else
295: txtCategorie.Text = "Asphalte"
300: End If
305: End If
		
310: If m_bCategorieICPI = True Then
315: If Trim(txtCategorie.Text) <> "" Then
320: txtCategorie.Text = txtCategorie.Text & ", ICPI"
325: Else
330: txtCategorie.Text = "ICPI"
335: End If
340: End If
		
345: If m_bCategorieProduitsChimiques = True Then
350: If Trim(txtCategorie.Text) <> "" Then
355: txtCategorie.Text = txtCategorie.Text & ", Produits chimiques"
360: Else
365: txtCategorie.Text = "Produits chimiques"
370: End If
375: End If
		
380: If m_bCategorieAutre = True Then
385: If Trim(txtCategorie.Text) <> "" Then
390: txtCategorie.Text = txtCategorie.Text & ", Autre"
395: Else
400: txtCategorie.Text = "Autre"
405: End If
410: End If
		
415: Exit Sub
		
AfficherErreur: 
		
420: Call AfficherErreur("frmClient", "AfficherCategorie", Err, Erl())
	End Sub
	
	Public Sub AfficherContact()
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''''''''''''
		'affiche les contacts de l'employé selectionné'
		''''''''''''''''''''''''''''''''''''''''
10: Dim rstContact As ADODB.Recordset
		
		'Ouverture de la table contact
15: rstContact = New ADODB.Recordset
		
20: Call rstContact.Open("SELECT * FROM GRB_contact WHERE IDContact = " & m_iNoContact, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'VIDE les champs
25: If m_bModeAjoutContact = True Then
30: If m_bNewContact = True Then
35: Call ViderBarrerChampsContact(False, True)
40: Else
45: Call ViderBarrerChampsContact(True, True)
50: End If
55: Else
60: Call ViderBarrerChampsContact(True, True)
65: End If
		
		
		'REMPLIS LES CHAMPS si il y a enregistrement
70: If Not rstContact.EOF Then
75: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("Titre").Value) Then
80: txtContactTitre.Text = rstContact.Fields("Titre").Value
85: End If
			
90: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("cellulaire").Value) Then
95: txtcontact_cell.Text = rstContact.Fields("cellulaire").Value
100: End If
			
105: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("pagette").Value) Then
110: txtcontact_page.Text = rstContact.Fields("pagette").Value
115: End If
			
120: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("telephonne").Value) Then
125: txtcontact_tel.Text = rstContact.Fields("telephonne").Value
130: End If
			
135: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("fax").Value) Then
140: txtcontact_fax.Text = rstContact.Fields("Fax").Value
145: End If
			
150: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("e-mail").Value) Then
155: txtcontact_email.Text = rstContact.Fields("e-mail").Value
160: End If
			
165: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("noposte").Value) Then
170: txtcontact_poste.Text = rstContact.Fields("noposte").Value
175: End If
			
180: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("teldomicile").Value) Then
185: txtcontact_dom.Text = rstContact.Fields("teldomicile").Value
190: End If
195: End If
		
		'ferme la table
200: Call rstContact.Close()
205: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
210: Exit Sub
		
AfficherErreur: 
		
215: Call AfficherErreur("frmClient", "AfficherContact", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbContact.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbContact_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbContact.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''''''
		'affiche employé sélectioné
		''''''''''''''''''''''''''''''''''
10: If cmbcontact.SelectedIndex <> -1 Then
15: m_iNoContact = VB6.GetItemData(cmbcontact, cmbcontact.SelectedIndex)
20: End If
		
25: Call AfficherContact()
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmClient", "cmbContact_Click", Err, Erl())
	End Sub
	
	Private Sub cmdanulcontact_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdanulcontact.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call AfficherControles(enumMode.MODE_INACTIF)
		
20: If m_bNewContact = True Then
25: Call HideEdMaskContact(True)
			
30: m_bNewContact = False
35: End If
		
		'n'est plus en mode ajouter
40: m_bModeAjoutContact = False
		
45: txtNomClient.Visible = False
50: txtNomClient.ReadOnly = False
		
		'remplis combo contact
55: Call RemplirComboContact()
		
60: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmClient", "cmdanulcontact_Click", Err, Erl())
	End Sub
	
	Private Sub cmdCategorie_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCategorie.Click
		
5: On Error GoTo AfficherErreur
		
10: Call frmCategorieClient.AfficherClient()
		
15: Call AfficherCategories()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmClient", "cmdCategorie_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFax_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFax.Click
		
5: On Error GoTo AfficherErreur
		
10: If cmbClient.Items.Count > 0 Then
15: If cmbcontact.SelectedIndex > -1 Then
20: Call frmreport.Afficher(VB6.GetItemData(cmbClient, cmbClient.SelectedIndex), VB6.GetItemData(cmbcontact, cmbcontact.SelectedIndex), frmreport.enumForm.FRM_CLIENTS)
25: Else
30: Call frmreport.Afficher(VB6.GetItemData(cmbClient, cmbClient.SelectedIndex), 0, frmreport.enumForm.FRM_CLIENTS)
35: End If
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmClient", "cmdFax_Click", Err, Erl())
	End Sub
	
	Private Sub cmdMailListContact_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMailListContact.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim folContact As Outlook.MAPIFolder
20: Dim itmContact() As Outlook.ContactItem
25: Dim otlRecipient As Outlook.Recipient
30: Dim bDejaOuvert As Boolean
35: Dim rstContact As ADODB.Recordset
40: Dim sIDContact() As String
45: Dim sContact() As String
50: Dim iCompteur As Short
55: Dim bArrayVide As Boolean
60: Dim bNouveau As Boolean
65: Dim iResult As Short
70: Dim bPlein As Boolean
75: Dim sMsgPlein As String
80: Dim iNbreRendu As Short
		
85: If cmbcontact.SelectedIndex <> -1 Then
90: bArrayVide = True
			
95: iResult = MsgBox("Voulez-vous ajouter tous les contacts à la liste de distribution?" & vbNewLine & "Oui - Tous les contacts" & vbNewLine & "Non - Contact affiché seulement", MsgBoxStyle.YesNoCancel)
			
100: If iResult = MsgBoxResult.Yes Then
105: rstContact = New ADODB.Recordset
				
110: Call rstContact.Open("SELECT * FROM GRB_ContactClient INNER JOIN GRB_Contact ON GRB_ContactClient.NoContact = GRB_Contact.IDContact WHERE GRB_ContactClient.NoClient = " & VB6.GetItemData(cmbClient, cmbClient.SelectedIndex) & " ORDER BY NomContact", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
				
115: iCompteur = 0
				
120: Do While Not rstContact.EOF
125: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstContact.Fields("E-mail").Value) Then
130: If Trim(rstContact.Fields("E-mail").Value) <> "" Then
135: bArrayVide = False
							
140: ReDim Preserve sIDContact(iCompteur)
145: ReDim Preserve itmContact(iCompteur)
150: ReDim Preserve sContact(iCompteur)
							
155: sIDContact(iCompteur) = rstContact.Fields("IDContact").Value
160: sContact(iCompteur) = rstContact.Fields("NomContact").Value
							
165: iCompteur = iCompteur + 1
170: End If
175: End If
					
180: Call rstContact.MoveNext()
185: Loop 
190: Else
195: If iResult = MsgBoxResult.No Then
200: If Trim(txtcontact_email.Text) <> "" Then
205: bArrayVide = False
						
210: ReDim Preserve sIDContact(0)
215: ReDim Preserve itmContact(0)
220: ReDim Preserve sContact(0)
						
225: sIDContact(0) = CStr(VB6.GetItemData(cmbcontact, cmbcontact.SelectedIndex))
230: sContact(0) = cmbcontact.Text
235: End If
240: Else
245: Exit Sub
250: End If
255: End If
			
260: If bArrayVide = False Then
265: otlApp = OuvrirOutlook(bDejaOuvert)
				
270: lblEtatOutlook.Text = "Recherche des listes de distribution..."
				
275: fraEtatOutlook.Visible = True
				
280: Call frmChoixMailList.Afficher(Me, otlApp)
				
285: If m_bAnnulerDistList = False Then
290: lblEtatOutlook.Text = "Ajout du contact dans la liste de distribution..."
					
295: fraEtatOutlook.Visible = True
					
300: folContact = GetFolder(otlApp, "Contacts GRB")
					
305: For iCompteur = 0 To UBound(sIDContact)
310: itmContact(iCompteur) = folContact.Items.Find("[User1] = " & sIDContact(iCompteur))
315: Next 
					
320: bPlein = False
					
325: For iCompteur = 0 To UBound(itmContact)
330: If Not itmContact(iCompteur) Is Nothing Then
335: If m_otlDistList.MemberCount < 10 Then
340: otlRecipient = otlApp.Session.CreateRecipient(itmContact(iCompteur).Email1DisplayName)
								
345: If otlRecipient.Resolve = True Then
350: Call m_otlDistList.AddMember(otlRecipient)
									
355: Call m_otlDistList.Save()
360: Else
365: Call MsgBox("Impossible d'ajouter le contact '" & sContact(iCompteur) & "' !", MsgBoxStyle.OKOnly, "Erreur")
370: End If
375: Else
380: bPlein = True
								
385: Exit For
390: End If
395: Else
400: Call MsgBox("Contact '" & sContact(iCompteur) & "' introuvable!", MsgBoxStyle.OKOnly, "Erreur")
405: End If
410: Next 
					
415: If bPlein = True Then
420: sMsgPlein = "Les contacts suivants n'ont pas pu être ajouté car la liste contient déjà 10 contacts!" & vbNewLine & vbNewLine
						
425: iNbreRendu = iCompteur
						
430: For iCompteur = iNbreRendu To UBound(sContact)
435: sMsgPlein = sMsgPlein & sContact(iCompteur)
							
440: If iCompteur < UBound(sContact) Then
445: sMsgPlein = sMsgPlein & vbNewLine
450: End If
455: Next 
						
460: Call MsgBox(sMsgPlein, MsgBoxStyle.OKOnly, "Erreur")
465: End If
470: End If
				
475: If bDejaOuvert = False Then
480: Call otlApp.Quit()
485: End If
				
490: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				otlApp = Nothing
				
495: fraEtatOutlook.Visible = False
500: Else
505: Call MsgBox("Le ou les contacts n'ont pas d'email!", MsgBoxStyle.OKOnly, "Erreur")
510: End If
515: Else
520: Call MsgBox("Aucun contact sélectionné!", MsgBoxStyle.OKOnly, "Erreur")
525: End If
		
530: Exit Sub
		
AfficherErreur: 
		
535: If Err.Number = 287 And Erl() = 305 Then
540: Call MsgBox("La liste de distribution est pleine!", MsgBoxStyle.OKOnly, "Erreur")
545: Else
550: Call AfficherErreur("frmClient", "cmdMailListContact_Click", Err, Erl())
555: End If
		
560: fraEtatOutlook.Visible = False
	End Sub
	
	Private Sub cmdMailListClient_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMailListClient.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim folClient As Outlook.MAPIFolder
20: Dim itmClient As Outlook.ContactItem
25: Dim otlRecipient As Outlook.Recipient
30: Dim bDejaOuvert As Boolean
		
35: If cmbClient.SelectedIndex <> -1 Then
40: If Trim(txtEmail.Text) <> "" Then
45: otlApp = OuvrirOutlook(bDejaOuvert)
				
55: lblEtatOutlook.Text = "Recherche des listes de distribution..."
				
60: fraEtatOutlook.Visible = True
				
65: Call frmChoixMailList.Afficher(Me, otlApp)
				
70: If m_bAnnulerDistList = False Then
75: lblEtatOutlook.Text = "Ajout du client dans la liste de distribution..."
					
80: fraEtatOutlook.Visible = True
					
85: If m_otlDistList.MemberCount < 10 Then
90: folClient = GetFolder(otlApp, "Clients GRB")
						
95: itmClient = folClient.Items.Find("[User1] = " & VB6.GetItemData(cmbClient, cmbClient.SelectedIndex))
						
100: If Not itmClient Is Nothing Then
105: otlRecipient = otlApp.Session.CreateRecipient(itmClient.Email1DisplayName)
							
110: If otlRecipient.Resolve = True Then
115: Call m_otlDistList.AddMember(otlRecipient)
								
120: Call m_otlDistList.Save()
125: Else
130: Call MsgBox("Impossible de trouver le client!", MsgBoxStyle.OKOnly, "Erreur")
135: End If
140: Else
145: Call MsgBox("Client introuvable!", MsgBoxStyle.OKOnly, "Erreur")
150: End If
155: Else
160: Call MsgBox("Cette liste de distribution contient déjà 10 contacts!" & vbNewLine & vbNewLine & "Veuillez en choisir une autre.", MsgBoxStyle.OKOnly, "Erreur")
165: End If
170: End If
				
175: If bDejaOuvert = False Then
180: Call otlApp.Quit()
185: End If
				
190: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				otlApp = Nothing
				
195: fraEtatOutlook.Visible = False
200: Else
205: Call MsgBox("Ce client n'a pas d'email!", MsgBoxStyle.OKOnly, "Erreur")
210: End If
215: Else
220: Call MsgBox("Aucun client sélectionné!", MsgBoxStyle.OKOnly, "Erreur")
225: End If
		
230: Exit Sub
		
AfficherErreur: 
		
235: If Err.Number = 287 And Erl() = 115 Then
240: Call MsgBox("La liste de distribution est pleine!", MsgBoxStyle.OKOnly, "Erreur")
245: Else
250: Call AfficherErreur("frmClient", "cmdMailListClient_Click", Err, Erl())
255: End If
		
260: fraEtatOutlook.Visible = False
	End Sub
	
	Private Sub cmdreport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdreport.Click
		Dim DR_ListeClient As Object
		
5: On Error GoTo AfficherErreur
		
		'Impression de la liste des clients
10: Dim rstClient As ADODB.Recordset
15: Dim sWhere As String
		
20: Call dlgImpressionClient.ShowDialog()
		
25: If m_bImpressionAnnuler = False Then
30: rstClient = New ADODB.Recordset
			
35: If m_bImpressionVille = True Then
40: Call frmChoixVille.ShowDialog()
				
45: If m_bAnnulerVille = False Then
50: Call rstClient.Open("SELECT * FROM GRB_Client WHERE VilleLiv = '" & Replace(m_sVille, "'", "''") & "' AND Supprimé = False ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
55: Else
60: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstClient = Nothing
					
65: Exit Sub
70: End If
75: Else
80: If m_bImpressionCategorie = True Then
85: Call frmCategorieClient.AfficherImpression()
					
90: If m_bImpressionBeton = True Then
95: sWhere = "Béton = True"
100: End If
					
105: If m_bImpressionPave = True Then
110: If Trim(sWhere) <> "" Then
115: sWhere = sWhere & " OR Pavé = True"
120: Else
125: sWhere = "Pavé = True"
130: End If
135: End If
					
140: If m_bImpressionPharmaceutique = True Then
145: If Trim(sWhere) <> "" Then
150: sWhere = sWhere & " OR Pharmaceutique = True"
155: Else
160: sWhere = "Pharmaceutique = True"
165: End If
170: End If
					
175: If m_bImpressionAgroAlimentaire = True Then
180: If Trim(sWhere) <> "" Then
185: sWhere = sWhere & " OR Agroalimentaire = True"
190: Else
195: sWhere = "Agroalimentaire = True"
200: End If
205: End If
					
210: If m_bImpressionMeuble = True Then
215: If Trim(sWhere) <> "" Then
220: sWhere = sWhere & " OR Meuble = True"
225: Else
230: sWhere = "Meuble = True"
235: End If
240: End If
					
245: If m_bImpressionMeunerie = True Then
250: If Trim(sWhere) <> "" Then
255: sWhere = sWhere & " OR Meunerie = True"
260: Else
265: sWhere = "Meunerie = True"
270: End If
275: End If
					
280: If m_bImpressionManufacturier = True Then
285: If Trim(sWhere) <> "" Then
290: sWhere = sWhere & " OR Manufacturier = True"
295: Else
300: sWhere = "Manufacturier = True"
305: End If
310: End If
					
315: If m_bImpressionConsultant = True Then
320: If Trim(sWhere) <> "" Then
325: sWhere = sWhere & " OR Consultant = True"
330: Else
335: sWhere = "Consultant = True"
340: End If
345: End If
					
350: If m_bImpressionAsphalte = True Then
355: If Trim(sWhere) <> "" Then
360: sWhere = sWhere & " OR Asphalte = True"
365: Else
370: sWhere = "Asphalte = True"
375: End If
380: End If
					
385: If m_bImpressionICPI = True Then
390: If Trim(sWhere) <> "" Then
395: sWhere = sWhere & " OR ICPI = True"
400: Else
405: sWhere = "ICPI = True"
410: End If
415: End If
					
420: If m_bImpressionProduitsChimiques = True Then
425: If Trim(sWhere) <> "" Then
430: sWhere = sWhere & " OR ProduitsChimiques = True"
435: Else
440: sWhere = "ProduitsChimiques = True"
445: End If
450: End If
					
455: If m_bImpressionAutre = True Then
460: If Trim(sWhere) <> "" Then
465: sWhere = sWhere & " OR Autre = True"
470: Else
475: sWhere = "Autre = True"
480: End If
485: End If
					
490: If Trim(sWhere) <> "" Then
495: Call rstClient.Open("SELECT * FROM GRB_Client WHERE " & sWhere & " AND Supprimé = False ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
500: Else
505: Call rstClient.Open("SELECT * FROM GRB_Client WHERE Supprimé = False ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
510: End If
515: Else
520: If m_bImpressionPotentiel = True Then
525: Call rstClient.Open("SELECT * FROM GRB_Client WHERE Potentiel = True AND Supprimé = False ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
530: Else
535: If m_bImpressionFacturer = True Then
540: Call rstClient.Open("SELECT * FROM GRB_Client WHERE Potentiel = False AND Supprimé = False ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
545: Else
550: Call rstClient.Open("SELECT * FROM GRB_Client WHERE Supprimé = False ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
555: End If
560: End If
565: End If
570: End If
			
575: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
			'set le rapport
580: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeClient.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ListeClient.DataSource = rstClient
			
585: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeClient.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_ListeClient.Orientation = MSDataReportLib.OrientationConstants.rptOrientLandscape
			
590: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeClient.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call DR_ListeClient.Show(VB6.FormShowConstants.Modal)
			
595: Call rstClient.Close()
600: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstClient = Nothing
			
605: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
610: End If
		
615: Exit Sub
		
AfficherErreur: 
		
620: Call AfficherErreur("frmClient", "cmdreport_Click", Err, Erl())
	End Sub
	
	Private Sub AfficherControles(ByVal eMode As enumMode)
		
5: On Error GoTo AfficherErreur
		
		'Activation des controles
10: Dim bCmbClient As Boolean
15: Dim bTxtNomClient As Boolean
20: Dim bCmbContact As Boolean
25: Dim bTxtContact As Boolean
30: Dim bTxtRechercher As Boolean
35: Dim bCmdAdd As Boolean
40: Dim bCmdEnr As Boolean
45: Dim bCmdModif As Boolean
50: Dim bCmdSupp As Boolean
55: Dim bFraContact As Boolean
60: Dim bCmdAnul As Boolean
65: Dim bCmdQuit As Boolean
70: Dim bCmdAddCont As Boolean
75: Dim bCmdSupContact As Boolean
80: Dim bCmdAnulContact As Boolean
85: Dim bCmdRenommer As Boolean
90: Dim bCmdRafraichir As Boolean
95: Dim bCmdImprimer As Boolean
100: Dim bCmdRefCont As Boolean
105: Dim bCmdRechercher As Boolean
110: Dim bFax As Boolean
115: Dim bMailListClient As Boolean
120: Dim bMailListContact As Boolean
125: Dim bCategorie As Boolean
		
130: m_eMode = eMode
		
135: Select Case eMode
			'Mode ajout et modif d'un client
			Case enumMode.MODE_CLIENT
140: bTxtNomClient = True
145: bCmdEnr = True
150: bCmdAnul = True
155: bCategorie = True
				
				'Mode ajout et modif d'un contact
			Case enumMode.MODE_CONTACT
160: bFraContact = True
165: bTxtNomClient = True
170: bCmdAnulContact = True
175: bCmdRefCont = True
				
180: If m_bNewContact = True Then
185: bTxtContact = True
190: Else
195: bCmbContact = True
200: End If
				
			Case enumMode.MODE_INACTIF
205: bFraContact = True
210: bCmbClient = True
215: bCmdImprimer = True
220: bTxtRechercher = True
225: bCmdRenommer = True
230: bCmdRafraichir = True
235: bCmdAdd = True
240: bCmdSupp = True
245: bCmdModif = True
250: bCmdQuit = True
255: bCmdAddCont = True
260: bCmdSupContact = True
265: bFax = True
270: bCmbContact = True
275: bMailListClient = True
280: bMailListContact = True
				
285: If Len(txtRechercher.Text) > 0 Then
290: bCmdRechercher = True
295: End If
300: End Select
		
305: cmbClient.Visible = bCmbClient
310: txtNomClient.Visible = bTxtNomClient
315: fraContact.Visible = bFraContact
320: txtRechercher.Enabled = bTxtRechercher
325: cmdRechercher.Enabled = bCmdRechercher
330: cmdRafraichir.Enabled = bCmdRafraichir
335: cmdrenommer.Enabled = bCmdRenommer
340: cmdreport.Visible = bCmdImprimer
345: CmdAdd.Visible = bCmdAdd
350: CmdSupp.Visible = bCmdSupp
355: CmdModif.Visible = bCmdModif
360: CmdQuit.Visible = bCmdQuit
365: CmdAnul.Visible = bCmdAnul
370: CmdEnr.Visible = bCmdEnr
375: CmdAddCont.Visible = bCmdAddCont
380: cmdsupcontact.Visible = bCmdSupContact
385: cmdanulcontact.Visible = bCmdAnulContact
390: CmdRefCont.Visible = bCmdRefCont
395: cmdFax.Visible = bFax
400: txtContact.Visible = bTxtContact
405: cmbcontact.Visible = bCmbContact
410: cmdMailListClient.Visible = bMailListClient
415: cmdMailListContact.Visible = bMailListContact
420: cmdCategorie.Visible = bCategorie
		
425: Exit Sub
		
AfficherErreur: 
		
430: Call AfficherErreur("frmClient", "AfficherControles", Err, Erl())
	End Sub
	
	Private Sub CmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdAdd.Click
		
5: On Error GoTo AfficherErreur
		
		'proc qui permet dajouter un client a la BD
10: Dim sName As String
		
15: Call AfficherControles(enumMode.MODE_CLIENT)
		
		'On procede a la saisie du nom du du contact
20: sName = InputBox("Veuillez entrer le nom du client" & vbNewLine & vbNewLine & "SVP, respectez le bon orthographe!", "SAISIE DU NOM", "Nom du client")
		
25: If sName <> vbNullString Then
30: If Not ComboContient(cmbClient, sName) Then
35: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
40: m_bModeAjoutClient = True
				
				'On montre les maskEdBox
45: Call HideEdMask(False)
				
				'On affiche le nom du nouveau client dans le textbox
				'pour éviter le ScrollDown durant l'ajout
50: txtNomClient.Text = sName
				
55: Call ViderBarrerChamps(False, True)
				
60: Call mskTelephone.Focus()
				
65: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
70: Else
75: Call MsgBox("Le client " & sName & " existe deja", MsgBoxStyle.Critical)
				
80: Call AfficherControles(enumMode.MODE_INACTIF)
85: End If
90: Else
95: Call AfficherControles(enumMode.MODE_INACTIF)
100: End If
		
105: Exit Sub
		
AfficherErreur: 
		
110: Call AfficherErreur("frmClient", "CmdAdd_Click", Err, Erl())
	End Sub
	
	Private Sub ViderBarrerChamps(ByVal bLocked As Boolean, ByVal bVider As Boolean)
		
5: On Error GoTo AfficherErreur
		
		'Cette procédure vide et unlock tous les textbox pour pouvoir ajouter
10: If bVider = True Then
15: txtTelephone.Text = vbNullString
20: mskTelephone.Text = vbNullString
25: txtFax.Text = vbNullString
30: mskFax.Text = vbNullString
35: txtContactGRB.Text = vbNullString
40: txtEmail.Text = vbNullString
45: txtAdresse.Text = vbNullString
50: txtVille.Text = vbNullString
55: txtProvEtat.Text = vbNullString
60: txtPays.Text = vbNullString
65: txtCP.Text = vbNullString
70: txtcommentaire.Text = vbNullString
75: txtSiteWeb.Text = vbNullString
80: lblDateCreation.Text = vbNullString
85: lblUserCreation.Text = vbNullString
90: lblDateModification.Text = vbNullString
95: lblUserModification.Text = vbNullString
100: txtCategorie.Text = vbNullString
105: chkClientPotentiel.CheckState = System.Windows.Forms.CheckState.Unchecked
			
110: m_bCategorieBeton = False
115: m_bCategoriePave = False
120: m_bCategoriePharmaceutique = False
125: m_bCategorieAgroalimentaire = False
130: m_bCategorieMeuble = False
135: m_bCategorieMeunerie = False
140: m_bCategorieManufacturier = False
145: m_bCategorieConsultant = False
150: m_bCategorieAsphalte = False
155: m_bCategorieICPI = False
160: m_bCategorieProduitsChimiques = False
165: m_bCategorieAutre = False
170: End If
		
175: txtTelephone.ReadOnly = bLocked
180: txtFax.ReadOnly = bLocked
185: txtContactGRB.ReadOnly = bLocked
190: txtEmail.ReadOnly = bLocked
195: txtAdresse.ReadOnly = bLocked
200: txtVille.ReadOnly = bLocked
205: txtProvEtat.ReadOnly = bLocked
210: txtPays.ReadOnly = bLocked
215: txtCP.ReadOnly = bLocked
220: txtcommentaire.ReadOnly = bLocked
225: txtSiteWeb.ReadOnly = bLocked
230: fraPotentiel.Enabled = Not bLocked
		
235: Exit Sub
		
AfficherErreur: 
		
240: Call AfficherErreur("frmClient", "ViderBarrerChamps", Err, Erl())
	End Sub
	
	Private Sub ViderBarrerChampsContact(ByVal bLocked As Boolean, ByVal bVider As Boolean)
		
5: On Error GoTo AfficherErreur
		
10: If bVider = True Then
15: txtContactTitre.Text = vbNullString
20: txtcontact_cell.Text = vbNullString
25: txtcontact_dom.Text = vbNullString
30: txtcontact_email.Text = vbNullString
35: txtcontact_fax.Text = vbNullString
40: txtcontact_page.Text = vbNullString
45: txtcontact_poste.Text = vbNullString
50: txtcontact_tel.Text = vbNullString
55: End If
		
60: txtContactTitre.ReadOnly = bLocked
65: txtcontact_cell.ReadOnly = bLocked
70: txtcontact_dom.ReadOnly = bLocked
75: txtcontact_email.ReadOnly = bLocked
80: txtcontact_fax.ReadOnly = bLocked
85: txtcontact_page.ReadOnly = bLocked
90: txtcontact_poste.ReadOnly = bLocked
95: txtcontact_tel.ReadOnly = bLocked
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmClient", "ViderBarrerChampsContact", Err, Erl())
	End Sub
	
	
	Private Sub CmdAddCont_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdAddCont.Click
		
5: On Error GoTo AfficherErreur
		
		'Pour faire l'ajout d'un contact
10: Dim sNom As String
15: Dim rstContact As ADODB.Recordset
20: Dim bAjouter As Boolean
		
25: If cmbClient.Items.Count > 0 Then
30: m_bModeAjoutContact = True
			
35: If MsgBox("Voulez-vous ajouter un nouveau contact?" & vbNewLine & "Oui - Nouveau contact" & vbNewLine & "Non - Sélection dans la liste des contacts existant", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
40: m_bNewContact = True
				
45: sNom = InputBox("Quel est le nom du nouveau contact?" & vbNewLine & vbNewLine & "SVP, respectez le bon orthographe!")
				
50: If sNom <> vbNullString Then
55: If ExisteDansBD(sNom) = True Then
60: If MsgBox("Il y a déjà un contact portant ce nom!" & vbNewLine & "Voulez-vous l'ajouter quand même?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
65: bAjouter = True
70: Else
75: bAjouter = False
80: End If
85: Else
90: If ContientCaracteresIncorrects(sNom) = True Then
95: Call MsgBox("Il y a des caractères non permis!", MsgBoxStyle.OKOnly, "Erreur")
							
100: bAjouter = False
105: Else
110: bAjouter = True
115: End If
120: End If
125: Else
130: bAjouter = False
135: End If
				
140: If bAjouter = True Then
145: txtContact.Text = sNom
					
150: Call ViderBarrerChampsContact(False, True)
					
155: Call HideEdMaskContact(False)
					
160: Call mskContactTel.Focus()
					
165: txtNomClient.Visible = True
170: txtNomClient.ReadOnly = True
					
					'Remplis combo avec tout les contact existant
175: Call AfficherControles(enumMode.MODE_CONTACT)
					
180: Call txtContactTitre.Focus()
185: End If
190: Else
195: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
				
200: m_bNewContact = False
				
205: txtNomClient.Visible = True
210: txtNomClient.ReadOnly = True
				
				'Remplis combo avec tout les contact existant
215: Call AfficherControles(enumMode.MODE_CONTACT)
				
				'Affiche client no modifiable
220: Call RemplirComboContact()
225: End If
			
230: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
235: Else
240: Call MsgBox("Aucun enregistrement de sélectionné")
245: End If
		
250: Exit Sub
		
AfficherErreur: 
		
255: Call AfficherErreur("frmClient", "CmdAddCont_Click", Err, Erl())
	End Sub
	
	Private Sub CmdAnul_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdAnul.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'On cache le maskEdBox
15: Call HideEdMask(True)
		
		'commentaire unlock
20: txtcommentaire.ReadOnly = True
		
25: m_bModeAjoutClient = False
		
		'on retablis les bouttons
30: Call AfficherControles(enumMode.MODE_INACTIF)
		
		'on affiche les donnée du premier enreg
35: Call ViderBarrerChamps(True, True)
		
40: Call cmbclient_SelectedIndexChanged(cmbclient, New System.EventArgs())
		
45: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmClient", "CmdAnul_Click", Err, Erl())
	End Sub
	
	Private Sub CmdEnr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdEnr.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim sClient As String
15: Dim iCompteur As Short
		
		'Nom du client
20: sClient = txtNomClient.Text
		
		'Enregistrement d'un client dans le BD
25: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
30: Call EnregistrerClient()
		
35: Call ViderBarrerChamps(True, True)
		
		'On cache les MaskEdBox
40: Call HideEdMask(True)
		
		'On met à jour le combo
45: Call RemplirComboClient()
		
		'Retablir les boutons
50: Call AfficherControles(enumMode.MODE_INACTIF)
		
55: For iCompteur = 0 To cmbClient.Items.Count - 1
60: If VB6.GetItemString(cmbClient, iCompteur) = sClient Then
65: cmbClient.SelectedIndex = iCompteur
				
70: Exit For
75: End If
80: Next 
		
85: Call cmbClient.Focus()
		
90: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
95: Exit Sub
		
AfficherErreur: 
		
100: Call AfficherErreur("frmClient", "CmdEnr_Click", Err, Erl())
	End Sub
	
	Private Sub EnregistrerClient()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstClient As ADODB.Recordset
		
15: rstClient = New ADODB.Recordset
		
20: If m_bModeAjoutClient = True Then
25: Call rstClient.Open("SELECT * FROM GRB_Client", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
30: Call rstClient.AddNew()
			
35: rstClient.Fields("DateCréation").Value = ConvertDate(Today)
40: rstClient.Fields("UserCréation").Value = g_sInitiale
45: Else
50: Call rstClient.Open("SELECT * FROM GRB_Client WHERE IDClient = " & m_iNoClient, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
55: rstClient.Fields("DateModification").Value = ConvertDate(Today)
60: rstClient.Fields("UserModification").Value = g_sInitiale
65: End If
		
		'Enregistre le client
70: rstClient.Fields("NomClient").Value = txtNomClient.Text
75: rstClient.Fields("Telephonne").Value = mskTelephone.Text
80: rstClient.Fields("Fax").Value = mskFax.Text
85: rstClient.Fields("ContactGRB").Value = txtContactGRB.Text
90: rstClient.Fields("Email").Value = txtEmail.Text
95: rstClient.Fields("AdresseLiv").Value = txtAdresse.Text
100: rstClient.Fields("VilleLiv").Value = txtVille.Text
105: rstClient.Fields("Prov/EtatLiv").Value = txtProvEtat.Text
110: rstClient.Fields("PaysLiv").Value = txtPays.Text
115: rstClient.Fields("Commentaire").Value = txtcommentaire.Text
120: rstClient.Fields("CodePostalLiv").Value = txtCP.Text
125: rstClient.Fields("SiteWeb").Value = txtSiteWeb.Text
		
130: If chkClientPotentiel.CheckState = System.Windows.Forms.CheckState.Checked Then
135: rstClient.Fields("Potentiel").Value = True
140: Else
145: rstClient.Fields("Potentiel").Value = False
150: End If
		
155: rstClient.Fields("Béton").Value = m_bCategorieBeton
160: rstClient.Fields("Pavé").Value = m_bCategoriePave
165: rstClient.Fields("Pharmaceutique").Value = m_bCategoriePharmaceutique
170: rstClient.Fields("Agroalimentaire").Value = m_bCategorieAgroalimentaire
175: rstClient.Fields("Meuble").Value = m_bCategorieMeuble
180: rstClient.Fields("Meunerie").Value = m_bCategorieMeunerie
185: rstClient.Fields("Manufacturier").Value = m_bCategorieManufacturier
190: rstClient.Fields("Consultant").Value = m_bCategorieConsultant
195: rstClient.Fields("Asphalte").Value = m_bCategorieAsphalte
200: rstClient.Fields("ICPI").Value = m_bCategorieICPI
205: rstClient.Fields("ProduitsChimiques").Value = m_bCategorieProduitsChimiques
210: rstClient.Fields("Autre").Value = m_bCategorieAutre
		
215: rstClient.Fields("EntryIDOutlook").Value = ModifierClientExchange(rstClient.Fields("IDClient").Value)
		
220: If m_bModeAjoutClient = True Then
225: m_bModeAjoutClient = False
230: End If
		
235: Call rstClient.Update()
		
240: Call rstClient.Close()
245: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient = Nothing
		
250: Exit Sub
		
AfficherErreur: 
		
255: Call AfficherErreur("frmClient", "EnregistrerClient", Err, Erl())
	End Sub
	
	Private Sub ModifierNomClientExchange(ByVal sName As String, ByVal iClientID As Short)
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim otlClient As Outlook.ContactItem
20: Dim folClient As Outlook.MAPIFolder
25: Dim bDejaOuvert As Boolean
		
30: lblEtatOutlook.Text = "Modification du nom du client dans Outlook ..."
35: fraEtatOutlook.Visible = True
		
40: otlApp = OuvrirOutlook(bDejaOuvert)
		
45: folClient = GetFolder(otlApp, "Clients GRB")
		
50: otlClient = folClient.Items.Find("[User1] = " & iClientID)
		
55: If otlClient Is Nothing Then
60: Call MsgBox("Le client " & txtNomClient.Text & " n'a pas été trouvé pour la mise à jour Exchange!", MsgBoxStyle.OKOnly, "Erreur")
			
65: fraEtatOutlook.Visible = False
			
70: System.Windows.Forms.Application.DoEvents()
			
75: Exit Sub
80: End If
		
85: otlClient.CompanyName = sName
		
90: Call otlClient.Save()
		
95: If bDejaOuvert = False Then
100: Call otlApp.Quit()
105: End If
		
110: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		otlApp = Nothing
		
115: fraEtatOutlook.Visible = False
		
120: System.Windows.Forms.Application.DoEvents()
		
125: Exit Sub
		
AfficherErreur: 
		
130: Call AfficherErreur("frmClient", "ModifierNomClientExchange", Err, Erl(), "iClientID = " & iClientID)
		
135: fraEtatOutlook.Visible = False
	End Sub
	
	Private Sub LierContactClient(ByVal iClientID As Short)
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim itmContact As Outlook.ContactItem
20: Dim itmClient As Outlook.ContactItem
25: Dim folClient As Outlook.MAPIFolder
30: Dim folContact As Outlook.MAPIFolder
35: Dim rstContactClient As ADODB.Recordset
40: Dim rstClient As ADODB.Recordset
45: Dim bDejaOuvert As Boolean
50: Dim iCompteur As Short
		
55: lblEtatOutlook.Text = "Liaison du contact avec le client dans Outlook ..."
60: fraEtatOutlook.Visible = True
		
65: otlApp = OuvrirOutlook(bDejaOuvert)
		
70: folClient = GetFolder(otlApp, "Clients GRB")
75: folContact = GetFolder(otlApp, "Contacts GRB")
		
80: rstClient = New ADODB.Recordset
		
85: Call rstClient.Open("SELECT EntryIDOutlook FROM GRB_Client WHERE IDClient = " & m_iNoClient, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
90: itmClient = folClient.Items.Find("[User1] = " & iClientID)
		
95: If Not itmClient Is Nothing Then
100: Do While itmClient.Links.Count > 0
105: 'UPGRADE_WARNING: Couldn't resolve default property of object itmClient.Links.Item().Item.User1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				itmContact = folContact.Items.Find("[User1] = " & itmClient.Links.Item(1).Item.User1)
				
110: For iCompteur = 1 To itmContact.Links.Count
115: 'UPGRADE_WARNING: Couldn't resolve default property of object itmContact.Links.Item(1).Item.User1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If itmContact.Links.Item(1).Item.User1 = itmClient.User1 Then
120: Call itmContact.Links.Remove(iCompteur)
						
125: Call itmContact.Save()
						
130: Exit For
135: End If
140: Next 
				
145: Call itmClient.Links.Remove(1)
150: Loop 
			
155: Call itmClient.Save()
			
160: Call rstClient.Close()
165: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstClient = Nothing
			
170: rstContactClient = New ADODB.Recordset
			
175: Call rstContactClient.Open("SELECT * FROM GRB_ContactClient WHERE NoClient = " & m_iNoClient, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
			
180: Do While Not rstContactClient.EOF
185: itmContact = folContact.Items.Find("[User1] = " & rstContactClient.Fields("NoContact").Value)
				
190: If Not itmContact Is Nothing Then
195: Call itmClient.Links.Add(itmContact)
					
200: Call itmClient.Save()
					
205: Call itmContact.Links.Add(itmClient)
					
210: Call itmContact.Save()
215: End If
				
220: Call rstContactClient.MoveNext()
225: Loop 
			
230: Call rstContactClient.Close()
235: 'UPGRADE_NOTE: Object rstContactClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstContactClient = Nothing
240: Else
245: Call MsgBox("Client introuvable!", MsgBoxStyle.OKOnly, "Erreur")
			
250: Call rstClient.Close()
255: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstClient = Nothing
260: End If
		
265: If bDejaOuvert = False Then
270: Call otlApp.Quit()
275: End If
		
280: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		otlApp = Nothing
		
285: fraEtatOutlook.Visible = False
		
290: System.Windows.Forms.Application.DoEvents()
		
295: Exit Sub
		
AfficherErreur: 
		
300: If InStr(1, UCase(Err.Description), "THE OPERATION FAILED") > 0 Then
305: Call MsgBox("Une erreur est survenue ! " & vbNewLine & vbNewLine & "Pour réparer cette erreur, veuillez suivre les instructions suivantes : " & vbNewLine & vbNewLine & "- Dans Outlook, ouvrez le client '" & txtNomClient.Text & "' dans Clients GRB" & vbNewLine & "- Cliquez sur tous les contacts de ce client 1 à la fois pour trouver le contact incorrect." & vbNewLine & "- Effacez ce contact de la liste des contacts de ce client." & vbNewLine & "- Dans le logiciel GRB, recommencez l'opération (effacez le contact et l'ajouter de nouveau).", MsgBoxStyle.OKOnly, "Erreur")
310: Else
315: Call AfficherErreur("frmClient", "LierContactClient", Err, Erl(), txtNomClient.Text)
320: End If
		
325: fraEtatOutlook.Visible = False
	End Sub
	
	Private Function ModifierClientExchange(ByVal iClientID As Short) As String
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim otlClient As Outlook.ContactItem
20: Dim folClient As Outlook.MAPIFolder
25: Dim bDejaOuvert As Boolean
		
30: If m_bModeAjoutClient = True Then
35: lblEtatOutlook.Text = "Ajout du client dans Outlook ..."
40: Else
45: lblEtatOutlook.Text = "Modification du client dans Outlook ..."
50: End If
		
55: fraEtatOutlook.Visible = True
		
60: otlApp = OuvrirOutlook(bDejaOuvert)
		
65: folClient = GetFolder(otlApp, "Clients GRB")
		
70: If m_bModeAjoutClient = True Then
75: otlClient = folClient.Items.Add(Outlook.OlItemType.olContactItem)
			
80: otlClient.User1 = CStr(iClientID)
85: Else
90: otlClient = folClient.Items.Find("[User1] = " & iClientID)
95: End If
		
100: If otlClient Is Nothing Then
105: Call MsgBox("Le client " & txtNomClient.Text & " n'a pas été trouvé pour la mise à jour Exchange!", MsgBoxStyle.OKOnly, "Erreur")
			
110: fraEtatOutlook.Visible = False
			
115: System.Windows.Forms.Application.DoEvents()
			
120: Exit Function
125: End If
		
130: otlClient.CompanyName = txtNomClient.Text
		
135: If mskTelephone.Text <> "(___) ___-____" Then
140: otlClient.BusinessTelephoneNumber = mskTelephone.Text
145: End If
		
150: If mskFax.Text <> "(___) ___-____" Then
155: otlClient.BusinessFaxNumber = mskFax.Text
160: End If
		
165: otlClient.Email1Address = txtEmail.Text
170: otlClient.BusinessAddressStreet = txtAdresse.Text
175: otlClient.BusinessAddressCity = txtVille.Text
180: otlClient.BusinessAddressState = txtProvEtat.Text
185: otlClient.BusinessAddressCountry = txtPays.Text
190: otlClient.BusinessAddressPostalCode = txtCP.Text
195: otlClient.Body = txtcommentaire.Text
200: otlClient.WebPage = txtSiteWeb.Text
		
205: Call otlClient.Save()
		
210: ModifierClientExchange = otlClient.EntryID
		
215: If bDejaOuvert = False Then
220: Call otlApp.Quit()
225: End If
		
230: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		otlApp = Nothing
		
235: fraEtatOutlook.Visible = False
		
240: System.Windows.Forms.Application.DoEvents()
		
245: Exit Function
		
AfficherErreur: 
		
250: Call AfficherErreur("frmClient", "ModifierClientExchange", Err, Erl(), "iClientID = " & iClientID)
		
255: fraEtatOutlook.Visible = False
	End Function
	
	Private Function AjouterContactExchange(ByVal iContactID As Short) As String
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim otlContact As Outlook.ContactItem
20: Dim folContact As Outlook.MAPIFolder
25: Dim bDejaOuvert As Boolean
30: Dim sNom() As String
		
35: lblEtatOutlook.Text = "Ajout du contact dans Outlook ..."
40: fraEtatOutlook.Visible = True
		
45: otlApp = OuvrirOutlook(bDejaOuvert)
		
50: folContact = GetFolder(otlApp, "Contacts GRB")
		
55: otlContact = folContact.Items.Add(Outlook.OlItemType.olContactItem)
		
60: otlContact.User1 = CStr(iContactID)
		
65: sNom = Split(Trim(txtContact.Text), " ")
		
70: Select Case UBound(sNom)
			Case 0
75: otlContact.FirstName = sNom(0)
				
			Case 1
80: otlContact.FirstName = sNom(0)
85: otlContact.LastName = sNom(1)
				
			Case 2
90: otlContact.FirstName = sNom(0)
95: otlContact.MiddleName = sNom(1)
100: otlContact.LastName = sNom(2)
105: End Select
		
110: otlContact.Title = ""
		
115: otlContact.CompanyName = txtNomClient.Text
120: otlContact.JobTitle = txtContactTitre.Text
		
125: If Trim(mskContactTel.Text) <> "" Then
130: If txtTelephone.Text <> "(___) ___-____" Then
135: If Trim(txtcontact_poste.Text) <> "" Then
140: otlContact.BusinessTelephoneNumber = mskContactTel.Text & " Ext : " & txtcontact_poste.Text
145: Else
150: otlContact.BusinessTelephoneNumber = mskContactTel.Text
155: End If
160: End If
165: End If
		
170: If mskContactFax.Text <> "(___) ___-____" Then
175: otlContact.BusinessFaxNumber = mskContactFax.Text
180: End If
		
185: If mskContactDom.Text <> "(___) ___-____" Then
190: otlContact.HomeTelephoneNumber = mskContactDom.Text
195: End If
		
200: If mskContactCell.Text <> "(___) ___-____" Then
205: otlContact.MobileTelephoneNumber = mskContactCell.Text
210: End If
		
215: If mskContactPage.Text <> "(___) ___-____" Then
220: otlContact.PagerNumber = mskContactPage.Text
225: End If
		
230: otlContact.Email1Address = txtcontact_email.Text
		
235: Call otlContact.Save()
		
240: AjouterContactExchange = otlContact.EntryID
		
245: If bDejaOuvert = False Then
250: Call otlApp.Quit()
255: End If
		
260: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		otlApp = Nothing
		
265: fraEtatOutlook.Visible = False
		
270: System.Windows.Forms.Application.DoEvents()
		
275: Exit Function
		
AfficherErreur: 
		
280: Call AfficherErreur("frmClient", "AjouterContactExchange", Err, Erl(), "iContactID = " & iContactID)
		
285: fraEtatOutlook.Visible = False
	End Function
	
	Private Sub SupprimerClientExchange(ByVal iClientID As Short)
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim otlClient As Outlook.ContactItem
20: Dim folClient As Outlook.MAPIFolder
25: Dim bDejaOuvert As Boolean
		
30: lblEtatOutlook.Text = "Suppression du client dans Outlook ..."
35: fraEtatOutlook.Visible = True
		
40: otlApp = OuvrirOutlook(bDejaOuvert)
		
45: folClient = GetFolder(otlApp, "Clients GRB")
		
50: otlClient = folClient.Items.Find("[User1] = " & iClientID)
		
55: If Not otlClient Is Nothing Then
60: Call otlClient.Delete()
65: End If
		
70: If bDejaOuvert = False Then
75: Call otlApp.Quit()
80: End If
		
85: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		otlApp = Nothing
		
90: fraEtatOutlook.Visible = False
		
95: System.Windows.Forms.Application.DoEvents()
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmClient", "SupprimerClientExchange", Err, Erl())
		
110: fraEtatOutlook.Visible = False
	End Sub
	
	Private Sub CmdModif_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdModif.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: If cmbClient.Items.Count > 0 Then
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
			'proc qui permet de modifier l'enr courant
			'on montre/cache des buttons
25: Call HideEdMask(False)
			
30: Call AfficherControles(enumMode.MODE_CLIENT)
			
35: Call ViderBarrerChamps(False, False)
			
			'pour que le nom ne soit pas modifiable
40: txtNomClient.Visible = True
45: txtNomClient.ReadOnly = True
			
50: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
55: Else
60: Call MsgBox("Aucun enregistrement de sélectionné!")
65: End If
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmClient", "CmdModif_Click", Err, Erl())
	End Sub
	
	Private Sub cmdquit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdquit.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmClient", "cmdquit_Click", Err, Erl())
	End Sub
	
	Private Sub CmdRefCont_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdRefCont.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstContactClient As ADODB.Recordset
15: Dim rstContact As ADODB.Recordset
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
25: rstContactClient = New ADODB.Recordset
		
30: If m_bNewContact = True Then
35: rstContact = New ADODB.Recordset
			
40: Call rstContact.Open("SELECT * FROM GRB_Contact", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
45: Call rstContact.AddNew()
			
50: rstContact.Fields("NomContact").Value = txtContact.Text
55: rstContact.Fields("Titre").Value = txtContactTitre.Text
60: rstContact.Fields("Compagnie").Value = txtNomClient.Text
65: rstContact.Fields("Telephonne").Value = mskContactTel.Text
70: rstContact.Fields("Fax").Value = mskContactFax.Text
75: rstContact.Fields("Pagette").Value = mskContactPage.Text
80: rstContact.Fields("Cellulaire").Value = mskContactCell.Text
85: rstContact.Fields("E-mail").Value = txtcontact_email.Text
90: rstContact.Fields("NoPoste").Value = txtcontact_poste.Text
95: rstContact.Fields("TelDomicile").Value = mskContactDom.Text
100: rstContact.Fields("UserCréation").Value = g_sInitiale
105: rstContact.Fields("DateCréation").Value = ConvertDate(Today)
			
110: rstContact.Fields("EntryIDOutlook").Value = AjouterContactExchange(rstContact.Fields("IDContact").Value)
			
115: Call rstContact.Update()
			
			'Set la table
120: Call rstContactClient.Open("SELECT * FROM GRB_ContactClient WHERE NoClient = " & m_iNoClient & " And NoContact = " & rstContact.Fields("IDContact").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'Si pas déjà existant, on ajoute dans la table
125: If rstContactClient.EOF Then
				'Ajoute dans la table
130: Call rstContactClient.AddNew()
				
135: rstContactClient.Fields("NoClient").Value = m_iNoClient
140: rstContactClient.Fields("NoContact").Value = rstContact.Fields("IDContact").Value
				
145: Call rstContactClient.Update()
150: End If
			
155: Call rstContact.Close()
160: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstContact = Nothing
			
165: m_bNewContact = False
			
170: Call HideEdMaskContact(True)
175: Else
			'Set la table
180: Call rstContactClient.Open("SELECT * FROM GRB_ContactClient WHERE NoClient = " & m_iNoClient & " AND NoContact = " & m_iNoContact, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'Si pas déjà existant, on ajoute dans la table
185: If rstContactClient.EOF Then
				'Ajoute dans la table
190: Call rstContactClient.AddNew()
				
195: rstContactClient.Fields("NoClient").Value = m_iNoClient
200: rstContactClient.Fields("NoContact").Value = m_iNoContact
				
205: Call rstContactClient.Update()
210: End If
			
			'Ferme tables et connexion
215: Call rstContactClient.Close()
220: End If
		
225: Call LierContactClient(m_iNoClient)
		
		'Ferme tables et connection
230: 'UPGRADE_NOTE: Object rstContactClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContactClient = Nothing
		
		'Bouton comme avant(apparait)
235: Call AfficherControles(enumMode.MODE_INACTIF)
		
		'n'est plus en mode ajouter
240: m_bModeAjoutContact = False
		
		'remplis combo contact
245: Call RemplirComboContact()
		
250: Call ViderBarrerChampsContact(True, False)
		
255: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
260: Exit Sub
		
AfficherErreur: 
		
265: Call AfficherErreur("frmClient", "CmdRefCont_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRenommer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRenommer.Click
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''''''''''''''''''''
		'on renomme le nom du CLIENT
		''''''''''''''''''''''''''''''''''''''''
10: Dim rstClient As ADODB.Recordset
15: Dim sName As String
		
20: If cmbClient.Items.Count > 0 Then
			'Proc qui permet de modifié un CLIENT a la BD
			'On procède à la saisie du nom du CLIENT
25: sName = InputBox("Veuillez entrer le nom du client", "Renommer client", txtNomClient.Text)
			
30: If sName <> vbNullString Then
35: If sName <> txtNomClient.Text Then
40: rstClient = New ADODB.Recordset
					
45: Call rstClient.Open("SELECT * FROM GRB_Client WHERE NomClient = '" & Replace(sName, "'", "''") & "' AND Supprimé = False", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
50: If rstClient.EOF Then
						'Transfert du nom au premier textBox
60: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
						System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
						
65: Call rstClient.Close()
						
70: Call rstClient.Open("SELECT NomClient, IDClient, EntryIDOutlook FROM GRB_Client WHERE IDClient = " & m_iNoClient, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
						
75: Call ModifierNomClientExchange(sName, m_iNoClient)
						
80: txtNomClient.Text = sName
						
						'Transfert des données
85: rstClient.Fields("NomClient").Value = txtNomClient.Text
						
						'Mise à jour de la base de données
90: Call rstClient.Update()
						
95: Call rstClient.Close()
						
100: Call RemplirComboClient()
						
105: cmbClient.Text = sName
						
110: m_bRenommer = True
						
115: Call cmbclient_SelectedIndexChanged(cmbclient, New System.EventArgs())
						
120: m_bRenommer = False
						
125: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
						System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
130: Else
135: Call MsgBox("Le client " & sName & " existe déjà!", MsgBoxStyle.Critical)
						
140: Call rstClient.Close()
145: End If
					
150: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstClient = Nothing
155: End If
160: End If
165: Else
170: Call MsgBox("Aucun enregistrement de sélectionné!")
175: End If
		
180: Exit Sub
		
AfficherErreur: 
		
185: Call AfficherErreur("frmClient", "cmdRenommer_Click", Err, Erl())
	End Sub
	
	Private Sub cmdsupcontact_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdsupcontact.Click
		
5: On Error GoTo AfficherErreur
		
		'fonction qui supprime l'enregistrement courant
10: If cmbcontact.Items.Count > 0 Then
15: If MsgBox("Etes-vous sur de vouloir supprimer cette enregistrement?", MsgBoxStyle.YesNo, "Supprimer") = MsgBoxResult.Yes Then
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
25: Call g_connData.Execute("DELETE * FROM GRB_ContactClient WHERE NoClient = " & m_iNoClient & " AND NoContact = " & m_iNoContact)
				
30: Call LierContactClient(m_iNoClient)
				
				'remplis le combo employé
35: Call RemplirComboContact()
				
40: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
45: End If
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmClient", "cmdsupcontact_Click", Err, Erl())
	End Sub
	
	Private Sub CmdSupp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdSupp.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjSoum As ADODB.Recordset
15: Dim rstClient As ADODB.Recordset
20: Dim bPeutEffacer As Boolean
		
25: If cmbClient.Items.Count > 0 Then
			'fonction qui supprime l'enregistrement courant
30: If MsgBox("Êtes-vous sûr de supprimer cet enregistrement?", MsgBoxStyle.YesNo, "Supprimer") = MsgBoxResult.Yes Then
35: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
40: rstProjSoum = New ADODB.Recordset
				
				'open table
45: Call rstProjSoum.Open("SELECT * FROM GRB_SoumissionMec WHERE IDClient = " & m_iNoClient, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
				'si existe pas dans soumission, on peut le deleter
50: If rstProjSoum.EOF Then
55: Call rstProjSoum.Close()
					
					'S'il existe pas dans projet, on peut le deleter
60: Call rstProjSoum.Open("SELECT * FROM GRB_ProjetMec WHERE IDClient = " & m_iNoClient, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
65: If rstProjSoum.EOF Then
70: Call rstProjSoum.Close()
						
75: Call rstProjSoum.Open("SELECT * FROM GRB_SoumissionElec WHERE IDClient = " & m_iNoClient, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
						
80: If rstProjSoum.EOF Then
85: Call rstProjSoum.Close()
							
90: Call rstProjSoum.Open("SELECT * FROM GRB_ProjetElec WHERE IDClient = " & m_iNoClient, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
							
95: If rstProjSoum.EOF Then
100: bPeutEffacer = True
								
105: Call rstProjSoum.Close()
110: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
								rstProjSoum = Nothing
115: Else
120: bPeutEffacer = False
								
125: Call rstProjSoum.Close()
130: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
								rstProjSoum = Nothing
135: End If
140: Else
145: bPeutEffacer = False
							
150: Call rstProjSoum.Close()
155: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
							rstProjSoum = Nothing
160: End If
165: Else
170: bPeutEffacer = False
						
175: Call rstProjSoum.Close()
180: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						rstProjSoum = Nothing
185: End If
190: Else
195: bPeutEffacer = False
					
200: Call rstProjSoum.Close()
205: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstProjSoum = Nothing
210: End If
				
215: If cmbcontact.Items.Count > 0 Then
					'Delete les contact pour ce client
220: Call g_connData.Execute("DELETE * FROM GRB_ContactClient WHERE NoClient = " & m_iNoClient)
225: End If
				
230: Call SupprimerClientExchange(m_iNoClient)
				
235: If bPeutEffacer = True Then
					'Delete le client
240: Call g_connData.Execute("DELETE * FROM GRB_Client WHERE IDClient = " & m_iNoClient)
245: Else
250: rstClient = New ADODB.Recordset
					
255: Call rstClient.Open("SELECT * FROM GRB_Client WHERE IDClient = " & m_iNoClient, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
260: rstClient.Fields("Supprimé").Value = True
					
265: Call rstClient.Update()
					
270: Call rstClient.Close()
275: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstClient = Nothing
280: End If
				
285: Call RemplirComboClient()
				
290: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
295: End If
300: Else
305: Call MsgBox("Aucun enregistrement de sélectionné!")
310: End If
		
315: Exit Sub
		
AfficherErreur: 
		
320: Call AfficherErreur("frmClient", "CmdSupp_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbclient.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbclient_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbclient.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		'Quand le user selectionne un enregistrement on se posotionne dessus
10: If cmbClient.Text <> vbNullString Then
15: txtNomClient.Text = cmbClient.Text
20: Else
25: If ComboContient(cmbClient, txtNomClient.Text) = False Then
30: Call RemplirComboClient()
35: End If
			
40: cmbClient.Text = txtNomClient.Text
45: End If
		
50: If cmbClient.SelectedIndex > -1 Then
55: If m_bRenommer = False And m_bModeAjoutClient = False Then
60: m_iNoClient = VB6.GetItemData(cmbClient, cmbClient.SelectedIndex)
65: End If
70: End If
		
		'remplis le combo dépendant le client sélectionné
75: Call AfficherClient()
		
80: Call RemplirComboContact()
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("frmClient", "cmbclient_Click", Err, Erl())
	End Sub
	
	Private Sub FrmClient_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Call RemplirComboClient()
		
15: Call AfficherControles(enumMode.MODE_INACTIF)
		
20: Call ActiverBoutonsGroupe()
		
25: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmClient", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub ActiverBoutonsGroupe()
		
5: On Error GoTo AfficherErreur
		
10: CmdAdd.Enabled = g_bModificationClients
15: CmdAddCont.Enabled = g_bModificationClients
20: CmdModif.Enabled = g_bModificationClients
25: cmdrenommer.Enabled = g_bModificationClients
30: cmdsupcontact.Enabled = g_bModificationClients
35: CmdSupp.Enabled = g_bModificationClients
40: cmdMailListClient.Enabled = g_bModificationListeDistribution
45: cmdMailListContact.Enabled = g_bModificationListeDistribution
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmClient", "ActiverBoutonsGroupe", Err, Erl())
	End Sub
	
	Private Sub HideEdMask(ByVal bVisible As Boolean)
		
5: On Error GoTo AfficherErreur
		
		'proc qui rend visible/ou non les maskEdBox
		'On en profite pour les nettoyer du dernier Enregistrement
		'et on fait l'inverse avec les textBox
10: If m_bModeAjoutClient = True Then
15: txtTelephone.Text = vbNullString
20: txtFax.Text = vbNullString
25: Else
30: mskTelephone.Text = txtTelephone.Text
35: mskFax.Text = txtFax.Text
40: End If
		
45: mskTelephone.Visible = Not bVisible
50: mskFax.Visible = Not bVisible
		
55: txtTelephone.Visible = bVisible
60: txtFax.Visible = bVisible
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmClient", "HideEdMask", Err, Erl())
	End Sub
	
	Private Sub HideEdMaskContact(ByVal bVisible As Boolean)
		
5: On Error GoTo AfficherErreur
		
		'proc qui rend visible/ou non les maskEdBox
		'On en profite pour les nettoyer du dernier Enregistrement
		'et on fait l'inverse avec les textBox
10: If m_bModeAjoutContact = True Then
15: txtcontact_tel.Text = vbNullString
20: txtcontact_fax.Text = vbNullString
25: txtcontact_page.Text = vbNullString
30: txtcontact_cell.Text = vbNullString
35: txtcontact_dom.Text = vbNullString
			
40: mskContactTel.Text = vbNullString
45: mskContactFax.Text = vbNullString
50: mskContactPage.Text = vbNullString
55: mskContactCell.Text = vbNullString
60: mskContactDom.Text = vbNullString
65: End If
		
70: mskContactTel.Visible = Not bVisible
75: txtcontact_tel.Visible = bVisible
		
80: mskContactFax.Visible = Not bVisible
85: txtcontact_fax.Visible = bVisible
		
90: mskContactPage.Visible = Not bVisible
95: txtcontact_page.Visible = bVisible
		
100: mskContactCell.Visible = Not bVisible
105: txtcontact_cell.Visible = bVisible
		
110: mskContactDom.Visible = Not bVisible
115: txtcontact_dom.Visible = bVisible
		
120: Exit Sub
		
AfficherErreur: 
		
125: Call AfficherErreur("frmClient", "HideEdMaskContact", Err, Erl())
	End Sub
	
	Private Sub FrmClient_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_NOTE: Object FrmClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Me = Nothing
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmClient", "Form_Unload", Err, Erl())
	End Sub
	Private Sub mskTelephone_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskTelephone.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskTelephone.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmClient", "mskTelephone_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskTelephone_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskTelephone.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskTelephone.Mask = vbNullString
15: If mskTelephone.Text = "(___) ___-____" Then
20: mskTelephone.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmClient", "mskTelephone_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskFax_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskFax.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskFax.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmClient", "mskFax_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskFax_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskFax.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskFax.Mask = vbNullString
15: If mskFax.Text = "(___) ___-____" Then
20: mskFax.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmClient", "mskFax_LostFocus", Err, Erl())
	End Sub
	
	Public Sub RemplirComboContact()
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		'remplis le combo contact dépendant le client sélectionné
		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
10: Dim rstClient As ADODB.Recordset
15: Dim rstContact As ADODB.Recordset
		
20: rstContact = New ADODB.Recordset
		
25: If m_bModeAjoutContact = True Then
30: Call rstContact.Open("SELECT NomContact, IDContact FROM GRB_contact WHERE Supprimé = False ORDER BY NomContact", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
35: Else
40: Call rstContact.Open("SELECT GRB_Contact.NomContact, GRB_Contact.IDContact FROM GRB_Contact INNER JOIN GRB_ContactClient ON GRB_Contact.IDContact = GRB_ContactClient.NoContact WHERE GRB_ContactClient.NoClient = " & m_iNoClient & " ORDER BY NomContact", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
45: End If
		
50: Call cmbcontact.Items.Clear()
		
55: Do While Not rstContact.EOF
60: Call cmbcontact.Items.Add(Trim(rstContact.Fields("NomContact").Value))
65: 'UPGRADE_ISSUE: ComboBox property cmbcontact.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbcontact, cmbcontact.NewIndex, rstContact.Fields("IDContact").Value)
			
70: Call rstContact.MoveNext()
75: Loop 
		
		'ferme la table "GRB_Contact"
80: Call rstContact.Close()
85: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
		'affiche le contact de la table client
		'si combo est pas vide, affiche le premier contact, sinon le contact inscrit dans table client
90: If cmbcontact.Items.Count > 0 Then
95: cmbcontact.SelectedIndex = 0
100: Else
			'VIDE les champs
105: txtContactTitre.Text = vbNullString
110: txtcontact_cell.Text = vbNullString
115: txtcontact_email.Text = vbNullString
120: txtcontact_fax.Text = vbNullString
125: txtcontact_page.Text = vbNullString
130: txtcontact_poste.Text = vbNullString
135: txtcontact_tel.Text = vbNullString
140: txtcontact_dom.Text = vbNullString
145: End If
		
150: Exit Sub
		
AfficherErreur: 
		
155: Call AfficherErreur("frmClient", "RemplirComboContact", Err, Erl())
	End Sub
	
	Private Sub cmdRechercher_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercher.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstClient As ADODB.Recordset
15: Dim sSearch As String
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
25: sSearch = txtRechercher.Text
		
		'vide les champs
30: Call ViderBarrerChamps(True, True)
		
		'Filtre pour sélection des Nomcontact
		'goSQL = "SELECT * FROM GRB_contact order by NomContact"
35: rstClient = New ADODB.Recordset
		
40: Call rstClient.Open("SELECT NomClient, IDClient FROM GRB_Client WHERE Instr(1, NomClient, '" & Replace(sSearch, "'", "''") & "') > 0 AND Supprimé = False ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'vide combo
45: Call cmbClient.Items.Clear()
		
50: Do While Not rstClient.EOF
55: Call cmbClient.Items.Add(rstClient.Fields("NomClient").Value)
60: 'UPGRADE_ISSUE: ComboBox property cmbClient.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbClient, cmbClient.NewIndex, rstClient.Fields("IDClient").Value)
			
65: Call rstClient.MoveNext()
70: Loop 
		
75: Call rstClient.Close()
80: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient = Nothing
		
85: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
90: If cmbClient.Items.Count > 0 Then
95: cmbClient.SelectedIndex = 0
100: Else
105: Call cmbcontact.Items.Clear()
			
			'VIDE les champs
110: txtContactTitre.Text = vbNullString
115: txtcontact_cell.Text = vbNullString
120: txtcontact_email.Text = vbNullString
125: txtcontact_fax.Text = vbNullString
130: txtcontact_page.Text = vbNullString
135: txtcontact_poste.Text = vbNullString
140: txtcontact_tel.Text = vbNullString
145: txtcontact_dom.Text = vbNullString
150: End If
		
155: Exit Sub
		
AfficherErreur: 
		
160: Call AfficherErreur("frmClient", "cmdRechercher_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRafraichir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRafraichir.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call RemplirComboClient()
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmClient", "cmdRafraichir_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtRechercher.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtRechercher_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtRechercher.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If Len(txtRechercher.Text) > 0 Then
15: cmdRechercher.Enabled = True
20: Else
25: cmdRechercher.Enabled = False
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmClient", "txtRechercher_Change", Err, Erl())
	End Sub
	
	Private Sub mskContactTel_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactTel.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskContactTel.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmClient", "mskContactTel_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactTel_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactTel.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskContactTel.Mask = vbNullString
		
15: If mskContactTel.Text = "(___) ___-____" Then
20: mskContactTel.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmClient", "mskContactTel_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactFax_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactFax.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskContactFax.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmClient", "mskContactFax_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactFax_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactFax.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskContactFax.Mask = vbNullString
		
15: If mskContactFax.Text = "(___) ___-____" Then
20: mskContactFax.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmClient", "mskContactFax_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactCell_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactCell.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskContactCell.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmClient", "mskContactCell_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactCell_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactCell.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskContactCell.Mask = vbNullString
		
15: If mskContactCell.Text = "(___) ___-____" Then
20: mskContactCell.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmClient", "mskContactCell_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactDom_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactDom.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskContactDom.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmClient", "mskContactDom_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactDom_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactDom.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskContactDom.Mask = vbNullString
		
15: If mskContactDom.Text = "(___) ___-____" Then
20: mskContactDom.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmClient", "mskContactDom_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactPage_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactPage.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskContactPage.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmClient", "mskContactPage_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactPage_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactPage.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskContactPage.Mask = vbNullString
		
15: If mskContactPage.Text = "(___) ___-____" Then
20: mskContactPage.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmClient", "mskContactPage_LostFocus", Err, Erl())
	End Sub
	
	Private Function ExisteDansBD(ByVal sName As String) As Boolean
		
5: On Error GoTo AfficherErreur
		
10: Dim rstContact As ADODB.Recordset
		
15: rstContact = New ADODB.Recordset
		
20: Call rstContact.Open("SELECT NomContact FROM GRB_Contact WHERE NomContact = '" & Replace(sName, "'", "''") & "' AND Supprimé = False", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
25: If rstContact.EOF Then
30: ExisteDansBD = False
35: Else
40: ExisteDansBD = True
45: End If
		
50: Call rstContact.Close()
55: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
60: Exit Function
		
AfficherErreur: 
		
65: Call AfficherErreur("frmClient", "ExisteDansBD", Err, Erl())
	End Function
	
	Private Function ContientCaracteresIncorrects(ByVal sName As String) As Boolean
		
5: On Error GoTo AfficherErreur
		
10: If InStr(1, sName, ",") > 0 Or InStr(1, sName, ";") > 0 Or InStr(1, sName, ":") > 0 Or InStr(1, sName, "(") > 0 Or InStr(1, sName, ")") > 0 Then
15: ContientCaracteresIncorrects = True
20: Else
25: ContientCaracteresIncorrects = False
30: End If
		
35: Exit Function
		
AfficherErreur: 
		
40: Call AfficherErreur("frmClient", "ContientCaracteresIncorrects", Err, Erl())
	End Function
End Class