Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class FrmFRS
	Inherits System.Windows.Forms.Form
	
	Private Enum enumMode
		MODE_FRS = 0
		MODE_CONTACT = 1
		MODE_INACTIF = 2
	End Enum
	
	Private m_bModeAjoutContact As Boolean
	Private m_bModeAjoutFRS As Boolean
	Private m_bRenommer As Boolean
	Private m_bNewContact As Boolean
	Private m_bCategorie As Boolean
	Private m_iNoContact As Short
	Private m_iNoFournisseur As Short
	Private m_iNoCategorie As Short
	Private m_Tag As String 'V1.44 GLL
	
	Public m_bAnnulerDistList As Boolean
	Public m_otlDistList As Outlook.DistListItem
	
	Private Sub AfficherCatFour() 'V1.44
		'Afficher les fournisseur dans le combobox selon la catégorie choisis
5: On Error GoTo AfficherErreur
10: Dim i As Short
15: Dim sString As String
20: Dim rstlist As ADODB.Recordset
		
25: rstlist = New ADODB.Recordset
30: sString = "Select * from GRB_Fournisseur "
35: Call rstlist.Open(sString, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
40: i = 0
		
45: If Not rstlist.EOF Then
50: Do While Not rstlist.EOF
55: If rstlist.Fields("NomFournisseur").Value = cmbFournisseur.Text Then Exit Do
60: Call rstlist.MoveNext()
65: Loop 
			
70: For i = 1 To Lst_Cat.Items.Count
75: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If rstlist.Fields("Categorie").Value Is System.DBNull.Value Then Exit For 'si aucune catégorie sélectionner on fait rien
				
80: 'UPGRADE_WARNING: Lower bound of collection Lst_Cat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If InStr(1, rstlist.Fields("categorie").Value, Lst_Cat.Items.Item(i).Tag, CompareMethod.Text) > 0 Then
85: 'UPGRADE_WARNING: Lower bound of collection Lst_Cat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Lst_Cat.Items.Item(i).Checked = True
				End If
			Next 
		End If
		Exit Sub
AfficherErreur: 
90: Call AfficherErreur("FrmFRS", "AfficherCatFour", Err, Erl())
	End Sub
	
	Private Sub RemplirComboFournisseur()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des fournisseurs
10: Dim rstFournisseur As ADODB.Recordset
		
15: rstFournisseur = New ADODB.Recordset
		
20: Call rstFournisseur.Open("SELECT NomFournisseur, IDFRS FROM GRB_Fournisseur WHERE Supprimé = False", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Il faut vider le combo avant de le remplir
25: Call cmbFournisseur.Items.Clear()
		
		'Tant que ce n'est pas la fin des enregistrements
30: Do While Not rstFournisseur.EOF
			'Ajout du nom du fournisseur dans le combo
35: Call cmbFournisseur.Items.Add(rstFournisseur.Fields("NomFournisseur").Value)
			
			'Ajout du numéro du fournisseur dans le ItemData du combo
40: 'UPGRADE_ISSUE: ComboBox property cmbFournisseur.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbFournisseur, cmbFournisseur.NewIndex, rstFournisseur.Fields("IDFRS").Value)
			
45: Call rstFournisseur.MoveNext()
50: Loop 
		
55: Call rstFournisseur.Close()
60: 'UPGRADE_NOTE: Object rstFournisseur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFournisseur = Nothing
		
65: If cmbFournisseur.Items.Count > 0 Then
70: cmbFournisseur.SelectedIndex = 0
75: End If
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmFRS", "RemplirComboFournisseur", Err, Erl())
	End Sub
	
	Private Sub AfficherFournisseur()
		
5: On Error GoTo AfficherErreur
		
		'Affiche le fournisseur sélectionné dans le combo
10: Dim rstFournisseur As ADODB.Recordset
		Dim i As Short
		
15: rstFournisseur = New ADODB.Recordset
		
20: Call rstFournisseur.Open("SELECT * FROM GRB_Fournisseur WHERE IDFRS = " & m_iNoFournisseur, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: Call ViderBarrerChamps(True, True)
		
		'Adresse
30: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstFournisseur.Fields("Adresse").Value) Then
35: txtAdresse.Text = rstFournisseur.Fields("Adresse").Value
40: End If
		
		'Ville
45: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstFournisseur.Fields("Ville").Value) Then
50: txtVille.Text = rstFournisseur.Fields("Ville").Value
55: End If
		
		'Prov/Etat
60: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstFournisseur.Fields("Prov/Etat").Value) Then
65: txtProvEtat.Text = rstFournisseur.Fields("Prov/Etat").Value
70: End If
		
		'Pays
75: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstFournisseur.Fields("Pays").Value) Then
80: txtPays.Text = rstFournisseur.Fields("Pays").Value
85: End If
		
		'CodePostal
90: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstFournisseur.Fields("CodePostal").Value) Then
95: txtCP.Text = rstFournisseur.Fields("CodePostal").Value
100: End If
		
		'Telephonne
105: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstFournisseur.Fields("Telephonne").Value) Then
110: txtTelephone.Text = rstFournisseur.Fields("Telephonne").Value
115: End If
		
		'Fax
120: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstFournisseur.Fields("Fax").Value) Then
125: txtFax.Text = rstFournisseur.Fields("Fax").Value
130: End If
		
		'E-mail
135: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstFournisseur.Fields("E-mail").Value) Then
140: txtEmail.Text = rstFournisseur.Fields("E-mail").Value
145: End If
		
		'Site Web
150: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstFournisseur.Fields("SiteWeb").Value) Then
155: txtSiteWeb.Text = rstFournisseur.Fields("SiteWeb").Value
160: End If
		
		'commentaire
165: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstFournisseur.Fields("Commentaire").Value) Then
170: txtcommentaire.Text = rstFournisseur.Fields("Commentaire").Value
175: End If
		
		'Création
180: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstFournisseur.Fields("DateCréation").Value) Then
185: lblDateCreation.Text = rstFournisseur.Fields("DateCréation").Value
190: End If
		
		'User Création
195: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstFournisseur.Fields("UserCréation").Value) Then
200: lblUserCreation.Text = "Par : " & rstFournisseur.Fields("UserCréation").Value
205: End If
		
		'Modification
210: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstFournisseur.Fields("DateModification").Value) Then
215: lblDateModification.Text = rstFournisseur.Fields("DateModification").Value
220: End If
		
		'User Modification
225: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstFournisseur.Fields("UserModification").Value) Then
230: lblUserModification.Text = "Par : " & rstFournisseur.Fields("UserModification").Value
235: End If
		'Catégorie
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstFournisseur.Fields("Categorie").Value) Then
			For i = 0 To cmbcatégorie.Items.Count
				
				If VB6.GetItemString(cmbcatégorie, i) = rstFournisseur.Fields("Categorie").Value Then
					cmbcatégorie.SelectedIndex = (i)
					Exit For
				End If
			Next 
		End If
240: Call rstFournisseur.Close()
245: 'UPGRADE_NOTE: Object rstFournisseur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFournisseur = Nothing
		
250: Exit Sub
		
AfficherErreur: 
		
255: Call AfficherErreur("frmFRS", "AfficherFournisseur", Err, Erl())
	End Sub
	
	Public Sub AfficherContact()
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''''''''''''
		'affiche les contacts de l'employé selectionné'
		''''''''''''''''''''''''''''''''''''''''
10: Dim rstContact As ADODB.Recordset
		
		'Ouverture de la table contact
15: rstContact = New ADODB.Recordset
		
20: Call rstContact.Open("SELECT * FROM GRB_Contact WHERE IDContact = " & m_iNoContact, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
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
		
		'REMPLIS LES CHAMPS s'il y a enregistrement
70: If Not rstContact.EOF Then
75: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("Titre").Value) Then
80: txtContactTitre.Text = rstContact.Fields("Titre").Value
85: End If
			
90: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("cellulaire").Value) Then
95: txtContactCell.Text = rstContact.Fields("cellulaire").Value
100: End If
			
105: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("pagette").Value) Then
110: txtContactPage.Text = rstContact.Fields("pagette").Value
115: End If
			
120: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("telephonne").Value) Then
125: txtContactTel.Text = rstContact.Fields("telephonne").Value
130: End If
			
135: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("fax").Value) Then
140: txtContactFax.Text = rstContact.Fields("fax").Value
145: End If
			
150: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("e-mail").Value) Then
155: txtContactEmail.Text = rstContact.Fields("e-mail").Value
160: End If
			
165: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("noposte").Value) Then
170: txtContactPoste.Text = rstContact.Fields("noposte").Value
175: End If
			
180: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("teldomicile").Value) Then
185: txtContactDom.Text = rstContact.Fields("teldomicile").Value
190: End If
195: End If
		
		'Ferme la table
200: Call rstContact.Close()
205: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
210: Exit Sub
		
AfficherErreur: 
		
215: Call AfficherErreur("frmFRS", "AfficherContact", Err, Erl())
	End Sub
	
	
	
	Private Sub cmb_modAnu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmb_modAnu.Click 'V1.44 GLL
		'Bouton d'annulation des changement apporter a la liste des catégorie
5: On Error GoTo AfficherErreur
10: m_Tag = ""
15: FrmCatMod.Visible = False
20: cmdcatval.Visible = False
25: cmb_modAnu.Visible = False
30: cmdCatAdd.Visible = True
35: cmdcatmod.Visible = True
40: cmdcatenr.Visible = True
45: cmdAnnuller.Visible = True
		Exit Sub
AfficherErreur: 
50: Call AfficherErreur("frmFRS", "cmb_modAnu_Click", Err, Erl())
	End Sub
	
	Private Sub cmb_modCat_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmb_modCat.Click 'V1.44 GLL
		'Bouton pour modifier le nom d'une catégorie
5: On Error GoTo AfficherErreur
		
10: If m_bCategorie = True Then
15: frm_Categorie.Visible = True
20: frm_Categorie.Text = "Catégorie pour :" & cmbFournisseur.Text
25: Call AfficherCatList()
30: Call AfficherCatFour()
35: If Lst_Cat.Items.Count >= 34 Then cmdCatAdd.Enabled = False
		End If
		Exit Sub
AfficherErreur: 
40: Call AfficherErreur("frmFRS", "cmb_modCat_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbcatégorie.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbcatégorie_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbcatégorie.SelectedIndexChanged 'GLL 2017-11-28 V1.44
		'Active la réduction du nombre de fournisseur par catégorie
5: On Error GoTo AfficherErreur
10: If m_bCategorie = False Then
15: If cmbcatégorie.SelectedIndex <> -1 Then
20: m_iNoCategorie = VB6.GetItemData(cmbcatégorie, cmbcatégorie.SelectedIndex)
25: Call AfficherCategorie()
30: End If
35: End If
		Exit Sub
AfficherErreur: 
40: Call AfficherErreur("frmFRS", "cmbCatégorie_Click", Err, Erl())
	End Sub
	
	
	
	
	'UPGRADE_WARNING: Event cmbContact.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbContact_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbContact.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''''''
		'affiche employé sélectioné
		''''''''''''''''''''''''''''''''''
10: If cmbContact.SelectedIndex <> -1 Then
15: m_iNoContact = VB6.GetItemData(cmbContact, cmbContact.SelectedIndex)
20: End If
		
25: Call AfficherContact()
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmFRS", "cmbContact_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnulerContact_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnulerContact.Click
		
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
		
45: txtNomFournisseur.Visible = False
50: txtNomFournisseur.ReadOnly = False
		
		'remplis combo contact
55: Call RemplirComboContact()
		
60: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmFRS", "cmdanulcontact_Click", Err, Erl())
	End Sub
	
	Public Sub RemplirComboContact()
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		'remplis le combo contact dépendant le client sélectionné
		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
10: Dim rstContact As ADODB.Recordset
		
15: rstContact = New ADODB.Recordset
		
20: If m_bModeAjoutContact = True Then
25: Call rstContact.Open("SELECT NomContact, IDContact FROM GRB_Contact WHERE Supprimé = False ORDER BY NomContact", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
30: Else
35: Call rstContact.Open("SELECT GRB_Contact.NomContact, GRB_Contact.IDContact FROM GRB_Contact INNER JOIN GRB_ContactFRS ON GRB_Contact.IDContact = GRB_ContactFRS.NoContact WHERE GRB_ContactFRS.NoFRS = " & m_iNoFournisseur & " ORDER BY NomContact", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
40: End If
		
45: Call cmbContact.Items.Clear()
		
50: Do While Not rstContact.EOF
55: Call cmbContact.Items.Add(rstContact.Fields("NomContact").Value)
60: 'UPGRADE_ISSUE: ComboBox property cmbContact.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbContact, cmbContact.NewIndex, rstContact.Fields("IDContact").Value)
			
65: Call rstContact.MoveNext()
70: Loop 
		
		'Ferme la table "GRB_Contact"
75: Call rstContact.Close()
80: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
		'Affiche le contact de la table client
		'si combo est pas vide, affiche le premier contact, sinon le contact inscrit dans table client
85: If cmbContact.Items.Count > 0 Then
90: cmbContact.SelectedIndex = 0
95: Else
100: txtContactTitre.Text = vbNullString
105: txtContactCell.Text = vbNullString
110: txtContactDom.Text = vbNullString
115: txtContactEmail.Text = vbNullString
120: txtContactFax.Text = vbNullString
125: txtContactPage.Text = vbNullString
130: txtContactPoste.Text = vbNullString
135: txtContactTel.Text = vbNullString
140: End If
		
145: Exit Sub
		
AfficherErreur: 
		
150: Call AfficherErreur("frmFRS", "RemplirComboContact", Err, Erl())
	End Sub
	
	Private Sub EnregistrerFournisseur()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstFournisseur As ADODB.Recordset
		
15: rstFournisseur = New ADODB.Recordset
		
20: If m_bModeAjoutFRS = True Then
25: Call rstFournisseur.Open("SELECT * FROM GRB_Fournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
30: Call rstFournisseur.AddNew()
			
35: rstFournisseur.Fields("DateCréation").Value = ConvertDate(Today)
40: rstFournisseur.Fields("UserCréation").Value = g_sInitiale
45: Else
50: Call rstFournisseur.Open("SELECT * FROM GRB_Fournisseur WHERE IDFRS = " & m_iNoFournisseur, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
55: rstFournisseur.Fields("DateModification").Value = ConvertDate(Today)
60: rstFournisseur.Fields("UserModification").Value = g_sInitiale
65: End If
		
		'Enregistrement du fournisseur
70: rstFournisseur.Fields("NomFournisseur").Value = txtNomFournisseur.Text
75: rstFournisseur.Fields("Adresse").Value = txtAdresse.Text
80: rstFournisseur.Fields("Ville").Value = txtVille.Text
85: rstFournisseur.Fields("Prov/Etat").Value = txtProvEtat.Text
90: rstFournisseur.Fields("Pays").Value = txtPays.Text
95: rstFournisseur.Fields("CodePostal").Value = txtCP.Text
100: rstFournisseur.Fields("Telephonne").Value = mskTelephone.Text
105: rstFournisseur.Fields("Fax").Value = mskFax.Text
110: rstFournisseur.Fields("E-mail").Value = txtEmail.Text
115: rstFournisseur.Fields("siteweb").Value = txtSiteWeb.Text
120: rstFournisseur.Fields("Commentaire").Value = txtcommentaire.Text
		
125: rstFournisseur.Fields("EntryIDOutlook").Value = ModifierFRSExchange(rstFournisseur.Fields("IDFRS").Value)
		
130: If m_bModeAjoutFRS = True Then
135: m_bModeAjoutFRS = False
140: End If
		
145: Call rstFournisseur.Update()
		
150: Call rstFournisseur.Close()
155: 'UPGRADE_NOTE: Object rstFournisseur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFournisseur = Nothing
		
160: Exit Sub
		
AfficherErreur: 
		
165: Call AfficherErreur("frmFRS", "EnregistrerFournisseur", Err, Erl())
	End Sub
	
	Private Sub ModifierNomFRSExchange(ByVal sName As String, ByVal iFournisseurID As Short)
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim otlFRS As Outlook.ContactItem
20: Dim folFRS As Outlook.MAPIFolder
25: Dim bDejaOuvert As Boolean
		
30: lblEtatOutlook.Text = "Modification du nom du fournisseur dans Outlook ..."
35: fraEtatOutlook.Visible = True
		
40: otlApp = OuvrirOutlook(bDejaOuvert)
		
45: folFRS = GetFolder(otlApp, "Fournisseurs GRB")
		
50: otlFRS = folFRS.Items.Find("[User1] = " & iFournisseurID)
		
55: If otlFRS Is Nothing Then
60: Call MsgBox("Le fournisseur " & txtNomFournisseur.Text & " n'a pas été trouvé pour la mise à jour Exchange!", MsgBoxStyle.OKOnly, "Erreur")
			
65: fraEtatOutlook.Visible = False
			
70: System.Windows.Forms.Application.DoEvents()
			
75: Exit Sub
80: End If
		
85: otlFRS.CompanyName = sName
		
90: Call otlFRS.Save()
		
95: If bDejaOuvert = False Then
100: Call otlApp.Quit()
105: End If
		
110: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		otlApp = Nothing
		
115: fraEtatOutlook.Visible = False
		
120: System.Windows.Forms.Application.DoEvents()
		
125: Exit Sub
		
AfficherErreur: 
		
130: Call AfficherErreur("frmFRS", "ModifierNomFRSExchange", Err, Erl(), "iFournisseurID = " & iFournisseurID)
		
135: fraEtatOutlook.Visible = False
	End Sub
	
	Private Sub LierContactFournisseur(ByVal iFournisseurID As Short)
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim itmContact As Outlook.ContactItem
20: Dim itmFRS As Outlook.ContactItem
25: Dim folFRS As Outlook.MAPIFolder
30: Dim folContact As Outlook.MAPIFolder
35: Dim rstContactFRS As ADODB.Recordset
40: Dim rstFRS As ADODB.Recordset
45: Dim bDejaOuvert As Boolean
50: Dim iCompteur As Short
		
55: lblEtatOutlook.Text = "Liaison du contact avec le fournisseur dans Outlook ..."
60: fraEtatOutlook.Visible = True
		
65: otlApp = OuvrirOutlook(bDejaOuvert)
		
70: folFRS = GetFolder(otlApp, "Fournisseurs GRB")
75: folContact = GetFolder(otlApp, "Contacts GRB")
		
80: rstFRS = New ADODB.Recordset
		
85: Call rstFRS.Open("SELECT EntryIDOutlook FROM GRB_Fournisseur WHERE IDFRS = " & m_iNoFournisseur, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
90: itmFRS = folFRS.Items.Find("[User1] = " & iFournisseurID)
		
95: If Not itmFRS Is Nothing Then
100: Do While itmFRS.Links.Count > 0
105: 'UPGRADE_WARNING: Couldn't resolve default property of object itmFRS.Links.Item().Item.User1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				itmContact = folContact.Items.Find("[User1] = " & itmFRS.Links.Item(1).Item.User1)
				
110: For iCompteur = 1 To itmContact.Links.Count
115: 'UPGRADE_WARNING: Couldn't resolve default property of object itmContact.Links.Item(1).Item.User1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If itmContact.Links.Item(1).Item.User1 = itmFRS.User1 Then
120: Call itmContact.Links.Remove(iCompteur)
						
125: Call itmContact.Save()
						
130: Exit For
135: End If
140: Next 
				
145: Call itmFRS.Links.Remove(1)
150: Loop 
			
155: Call itmFRS.Save()
			
160: Call rstFRS.Close()
165: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstFRS = Nothing
			
170: rstContactFRS = New ADODB.Recordset
			
175: Call rstContactFRS.Open("SELECT * FROM GRB_ContactFRS WHERE NoFRS = " & m_iNoFournisseur, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
			
180: Do While Not rstContactFRS.EOF
185: itmContact = folContact.Items.Find("[User1] = " & rstContactFRS.Fields("NoContact").Value)
				
190: If Not itmContact Is Nothing Then
195: Call itmFRS.Links.Add(itmContact)
					
200: Call itmFRS.Save()
					
205: Call itmContact.Links.Add(itmFRS)
					
210: Call itmContact.Save()
215: End If
				
220: Call rstContactFRS.MoveNext()
225: Loop 
			
230: Call rstContactFRS.Close()
235: 'UPGRADE_NOTE: Object rstContactFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstContactFRS = Nothing
240: Else
245: Call MsgBox("Fournisseur introuvable!", MsgBoxStyle.OKOnly, "Erreur")
			
250: Call rstFRS.Close()
255: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstFRS = Nothing
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
305: Call MsgBox("Une erreur est survenue ! " & vbNewLine & vbNewLine & "Pour réparer cette erreur, veuillez suivre les instructions suivantes : " & vbNewLine & vbNewLine & "- Dans Outlook, ouvrez le fournisseur '" & txtNomFournisseur.Text & "' dans Fournisseurs GRB" & vbNewLine & "- Cliquez sur tous les contacts de ce fournisseur 1 à la fois pour trouver le contact incorrect." & vbNewLine & "- Effacez ce contact de la liste des contacts de ce fournisseur." & vbNewLine & "- Dans le logiciel GRB, recommencez l'opération (effacez le contact et l'ajouter de nouveau).", MsgBoxStyle.OKOnly, "Erreur")
310: Else
315: Call AfficherErreur("frmFRS", "LierContactFournisseur", Err, Erl(), txtNomFournisseur.Text)
320: End If
		
325: fraEtatOutlook.Visible = False
	End Sub
	
	Private Function ModifierFRSExchange(ByVal iFournisseurID As Short) As String
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim otlFRS As Outlook.ContactItem
20: Dim folFRS As Outlook.MAPIFolder
25: Dim bDejaOuvert As Boolean
		
30: If m_bModeAjoutFRS = True Then
35: lblEtatOutlook.Text = "Ajout du fournisseur dans Outlook ..."
40: Else
45: lblEtatOutlook.Text = "Modification du fournisseur dans Outlook ..."
50: End If
		
55: fraEtatOutlook.Visible = True
		
60: otlApp = OuvrirOutlook(bDejaOuvert)
		
65: folFRS = GetFolder(otlApp, "Fournisseurs GRB")
		
70: If m_bModeAjoutFRS = True Then
75: otlFRS = folFRS.Items.Add(Outlook.OlItemType.olContactItem)
			
80: otlFRS.User1 = CStr(iFournisseurID)
85: Else
90: otlFRS = folFRS.Items.Find("[User1] = " & iFournisseurID)
95: End If
		
100: If otlFRS Is Nothing Then
105: Call MsgBox("Le fournisseur " & txtNomFournisseur.Text & " n'a pas été trouvé pour la mise à jour Exchange!", MsgBoxStyle.OKOnly, "Erreur")
			
110: fraEtatOutlook.Visible = False
			
115: System.Windows.Forms.Application.DoEvents()
			
120: Exit Function
125: End If
		
130: otlFRS.CompanyName = txtNomFournisseur.Text
		
135: If mskTelephone.Text <> "(___) ___-____" Then
140: otlFRS.BusinessTelephoneNumber = mskTelephone.Text
145: End If
		
150: If mskFax.Text <> "(___) ___-____" Then
155: otlFRS.BusinessFaxNumber = mskFax.Text
160: End If
		
165: otlFRS.Email1Address = txtEmail.Text
170: otlFRS.BusinessAddressStreet = txtAdresse.Text
175: otlFRS.BusinessAddressCity = txtVille.Text
180: otlFRS.BusinessAddressState = txtProvEtat.Text
185: otlFRS.BusinessAddressCountry = txtPays.Text
190: otlFRS.BusinessAddressPostalCode = txtCP.Text
195: otlFRS.Body = txtcommentaire.Text
200: otlFRS.WebPage = txtSiteWeb.Text
		
205: Call otlFRS.Save()
		
210: ModifierFRSExchange = otlFRS.EntryID
		
215: If bDejaOuvert = False Then
220: Call otlApp.Quit()
225: End If
		
230: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		otlApp = Nothing
		
235: fraEtatOutlook.Visible = False
		
240: System.Windows.Forms.Application.DoEvents()
		
245: Exit Function
		
AfficherErreur: 
		
250: Call AfficherErreur("frmFRS", "ModifierFRSExchange", Err, Erl(), "iFournisseurID = " & iFournisseurID)
		
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
		
65: sNom = Split(Trim(txtcontact.Text), " ")
		
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
		
115: otlContact.CompanyName = txtNomFournisseur.Text
120: otlContact.JobTitle = txtContactTitre.Text
		
125: If Trim(mskContactTel.Text) <> "" Then
130: If mskContactTel.Text <> "(___) ___-____" Then
135: If Trim(txtContactPoste.Text) <> "" Then
140: otlContact.BusinessTelephoneNumber = mskContactTel.Text & " Ext : " & txtContactPoste.Text
145: Else
150: otlContact.BusinessTelephoneNumber = mskContactTel.Text
155: End If
160: End If
165: End If
		
170: If mskContactFax.Text <> "(___) ___-____" Then
175: otlContact.BusinessFaxNumber = mskContactFax.Text
180: End If
		
185: If mskContactCell.Text <> "(___) ___-____" Then
190: otlContact.MobileTelephoneNumber = mskContactCell.Text
195: End If
		
200: If mskContactDom.Text <> "(___) ___-____" Then
205: otlContact.HomeTelephoneNumber = mskContactDom.Text
210: End If
		
215: If mskContactPage.Text <> "(___) ___-____" Then
220: otlContact.PagerNumber = mskContactPage.Text
225: End If
		
230: otlContact.Email1Address = txtContactEmail.Text
		
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
		
280: Call AfficherErreur("frmFRS", "AjouterContactExchange", Err, Erl(), "iContactID = " & iContactID)
		
285: fraEtatOutlook.Visible = False
	End Function
	
	Private Sub SupprimerFRSExchange(ByVal iFournisseurID As Short)
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim otlFRS As Outlook.ContactItem
20: Dim folFRS As Outlook.MAPIFolder
25: Dim bDejaOuvert As Boolean
		
30: lblEtatOutlook.Text = "Suppression du fournisseur dans Outlook ..."
35: fraEtatOutlook.Visible = True
		
40: otlApp = OuvrirOutlook(bDejaOuvert)
		
45: folFRS = GetFolder(otlApp, "Fournisseurs GRB")
		
50: otlFRS = folFRS.Items.Find("[User1] = " & iFournisseurID)
		
55: If Not otlFRS Is Nothing Then
60: Call otlFRS.Delete()
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
		
105: Call AfficherErreur("frmFRS", "SupprimerFRSExchange", Err, Erl())
		
110: fraEtatOutlook.Visible = False
	End Sub
	
	Private Sub cmdAnnuller_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuller.Click
		frm_Categorie.Visible = False
		Call RemplirComboCatégorie()
	End Sub
	
	Private Sub cmdCatAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCatAdd.Click 'V1.44 GLL
		'Bouton pour ajouter une catégorie a la base de donné
5: On Error GoTo AfficherErreur
		
10: If Lst_Cat.Items.Count >= 34 Then 'Méthode utilisé pour géré les catégorie on une limite de 34 alors je bloque les futur addition pour ne pas avoir de problème
15: MsgBox("Vous Avez attent le maximum de catégorie")
20: cmdCatAdd.Enabled = False
			Exit Sub
		End If
		
25: m_Tag = ""
		
30: FrmCatMod.Visible = True
35: cmdcatval.Visible = True
40: cmb_modAnu.Visible = True
45: cmdCatAdd.Visible = False
50: cmdcatmod.Visible = False
55: cmdcatenr.Visible = False
60: cmdAnnuller.Visible = False
65: VB6.SetDefault(cmdcatval, True)
		
70: txtmodcat.Focus()
75: FrmCatMod.Text = "Ajouter"
80: txtmodcat.Text = ""
		
		Exit Sub
		
AfficherErreur: 
85: Call AfficherErreur("FrmFRS", "cmdCatAdd_Click", Err, Erl())
		
	End Sub
	
	Private Sub cmdcatenr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdcatenr.Click '1.44 GLL Enregistre les catégorie pour le founisseur
		On Error GoTo AfficherErreur
		
5: Dim rstcat As ADODB.Recordset
10: Dim i As Short
15: Dim sCat As String
		
20: rstcat = New ADODB.Recordset
25: sCat = ""
30: Call rstcat.Open("Select * from Grb_Fournisseur Where NomFournisseur ='" & cmbFournisseur.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
35: If rstcat.EOF Then 'Vérifie si un Fournisseur est sélectionner
40: MsgBox("Erreur aucun fournisseur sélectionner")
			Exit Sub
		End If
		
45: For i = 1 To Lst_Cat.Items.Count 'Fabric le nouveau code pour la catégorie
50: 'UPGRADE_WARNING: Lower bound of collection Lst_Cat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If Lst_Cat.Items.Item(i).Checked Then sCat = sCat & Lst_Cat.Items.Item(i).Tag
		Next 
		
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If sCat = "" Then rstcat.Fields("Categorie").Value = System.DBNull.Value 'si aucune catégorie est selectionner on rend null la case categorie
60: If sCat <> "" Then rstcat.Fields("Categorie").Value = sCat 'On envoie le code dans la catégorie du fournisseur
		
65: Call rstcat.Update()
70: Call rstcat.Close()
75: 'UPGRADE_NOTE: Object rstcat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstcat = Nothing
		
		
80: frm_Categorie.Visible = False
85: Call RemplirComboCatégorie()
		Exit Sub
AfficherErreur: 
90: Call AfficherErreur("frmFrs", "cmdcatenr_click", Err, Erl())
	End Sub
	
	
	Private Sub cmdcatmod_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdcatmod.Click 'V1.44 GLL
		'bouton pour modifier le nom d'une catégorie
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Couldn't resolve default property of object Lst_Cat.SelectedItem.Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_Tag = Lst_Cat.FocusedItem.Tag
15: FrmCatMod.Visible = True
20: cmdcatval.Visible = True
25: cmb_modAnu.Visible = True
30: cmdCatAdd.Visible = False
35: cmdcatmod.Visible = False
40: cmdcatenr.Visible = False
45: cmdAnnuller.Visible = False
50: txtmodcat.Focus()
55: FrmCatMod.Text = "Modifier"
60: txtmodcat.Text = Lst_Cat.FocusedItem.Text
		Exit Sub
AfficherErreur: 
		Call AfficherErreur("FrmFrs", "cmdcatmod_Click", Err, Erl())
	End Sub
	Private Sub cmdcatval_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdcatval.Click 'V1.44 GLL
		'Bouton pour valider l'Additon/modification d'une catégorie
5: On Error GoTo AfficherErreur
10: Dim rstag As ADODB.Recordset
15: Dim bDelete As Boolean
20: rstag = New ADODB.Recordset
25: bDelete = False
		
30: If m_Tag <> "" Then 'pour faire une modification
35: Call rstag.Open("SELECT * FROM TBL_Categorie where Correspondance ='" & m_Tag & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
40: rstag.Fields("Nom").Value = txtmodcat.Text
45: Else
50: Call rstag.Open("SELECT * FROM TBL_Categorie", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
55: Do While Not rstag.EOF
60: If UCase(rstag.Fields("nom").Value) = UCase(txtmodcat.Text) Then 'Vérifie si ce nom de catégorie existe déja
65: MsgBox("vous avez déja cette Categorie")
70: GoTo Fin
				End If
75: Call rstag.MoveNext()
			Loop 
80: rstag.MoveFirst()
			
85: Do While Not rstag.EOF
				
90: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If IsDbNull(rstag.Fields("nom").Value) Then
95: rstag.Fields("Nom").Value = txtmodcat.Text
100: Exit Do
105: End If
				
110: Call rstag.MoveNext()
			Loop 
		End If
		
115: If txtmodcat.Text = "" Then 'Si on a pas miss de text on efface le nom de la catégorie
120: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			rstag.Fields("Nom").Value = System.DBNull.Value
125: bDelete = True
130: End If
		
135: Call rstag.Update()
		
Fin: 
140: Call rstag.Close()
145: 'UPGRADE_NOTE: Object rstag may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstag = Nothing
		
150: If bDelete Then Call DeleteCategorie()
		
155: Call AfficherCatList()
160: Call AfficherCatFour()
		
165: FrmCatMod.Visible = False
170: cmdcatval.Visible = False
175: cmb_modAnu.Visible = False
180: cmdCatAdd.Visible = True
190: cmdcatmod.Visible = True
195: cmdcatenr.Visible = True
200: cmdAnnuller.Visible = True
205: cmdcatmod.Enabled = False
210: m_Tag = ""
		
		Exit Sub
AfficherErreur: 
215: Call AfficherErreur("Frm_FRS", "Cmdcatval_Click", Err, Erl())
	End Sub
	
	Private Sub cmdEnregistrerContact_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEnregistrerContact.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstContactFRS As ADODB.Recordset
15: Dim rstContact As ADODB.Recordset
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
25: rstContactFRS = New ADODB.Recordset
		
30: If m_bNewContact = True Then
35: rstContact = New ADODB.Recordset
			
40: Call rstContact.Open("SELECT * FROM GRB_Contact", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
45: Call rstContact.AddNew()
			
50: rstContact.Fields("NomContact").Value = txtcontact.Text
55: rstContact.Fields("Titre").Value = txtContactTitre.Text
60: rstContact.Fields("Compagnie").Value = txtNomFournisseur.Text
65: rstContact.Fields("Telephonne").Value = mskContactTel.Text
70: rstContact.Fields("Fax").Value = mskContactFax.Text
75: rstContact.Fields("Pagette").Value = mskContactPage.Text
80: rstContact.Fields("Cellulaire").Value = mskContactCell.Text
85: rstContact.Fields("E-mail").Value = txtContactEmail.Text
90: rstContact.Fields("noposte").Value = txtContactPoste.Text
95: rstContact.Fields("teldomicile").Value = mskContactDom.Text
100: rstContact.Fields("UserCréation").Value = g_sInitiale
105: rstContact.Fields("DateCréation").Value = ConvertDate(Today)
			
110: rstContact.Fields("EntryIDOutlook").Value = AjouterContactExchange(rstContact.Fields("IDContact").Value)
			
115: Call rstContact.Update()
			
			'set la table
120: Call rstContactFRS.Open("SELECT * FROM GRB_ContactFRS WHERE NoFRS = " & m_iNoFournisseur & " And NoContact = " & rstContact.Fields("IDContact").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'si pas deja existant, on ajoute dans la table
125: If rstContactFRS.EOF Then
				'ajoute dans la table
130: Call rstContactFRS.AddNew()
				
135: rstContactFRS.Fields("NoFRS").Value = m_iNoFournisseur
140: rstContactFRS.Fields("NoContact").Value = rstContact.Fields("IDContact").Value
				
145: Call rstContactFRS.Update()
150: End If
			
155: Call rstContact.Close()
160: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstContact = Nothing
			
165: m_bNewContact = False
			
170: Call HideEdMaskContact(True)
175: Else
			'set la table
180: Call rstContactFRS.Open("SELECT * FROM GRB_ContactFRS WHERE NoFRS = " & m_iNoFournisseur & " And NoContact = " & m_iNoContact, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'Si pas deja existant, on ajoute dans la table
185: If rstContactFRS.EOF Then
				'ajoute dans la table
190: Call rstContactFRS.AddNew()
				
195: rstContactFRS.Fields("NoFRS").Value = m_iNoFournisseur
200: rstContactFRS.Fields("NoContact").Value = m_iNoContact
				
205: Call rstContactFRS.Update()
210: End If
			
			'Ferme tables et connection
215: Call rstContactFRS.Close()
220: End If
		
225: Call LierContactFournisseur(m_iNoFournisseur)
		
230: 'UPGRADE_NOTE: Object rstContactFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContactFRS = Nothing
		
		'Bouton comme avant(apparait)
235: Call AfficherControles(enumMode.MODE_INACTIF)
		
		'N'est plus en mode ajouter
240: m_bModeAjoutContact = False
		
		'Remplis combo contact
245: Call RemplirComboContact()
		
250: Call ViderBarrerChampsContact(True, False)
		
255: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
260: Exit Sub
		
AfficherErreur: 
		
265: Call AfficherErreur("frmFRS", "cmdEnregistrerContact_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFax_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFax.Click
		
5: On Error GoTo AfficherErreur
		
10: If cmbFournisseur.Items.Count > 0 Then
15: If cmbContact.SelectedIndex > -1 Then
20: Call frmreport.Afficher(VB6.GetItemData(cmbFournisseur, cmbFournisseur.SelectedIndex), VB6.GetItemData(cmbContact, cmbContact.SelectedIndex), frmreport.enumForm.FRM_FRS)
25: Else
30: Call frmreport.Afficher(VB6.GetItemData(cmbFournisseur, cmbFournisseur.SelectedIndex), 0, frmreport.enumForm.FRM_FRS)
35: End If
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmFRS", "cmdFax_Click", Err, Erl())
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
75: Dim sMsgPlein As Boolean
80: Dim iNbreRendu As Short
		
85: If cmbContact.SelectedIndex <> -1 Then
90: bArrayVide = True
			
95: iResult = MsgBox("Voulez-vous ajouter tous les contacts à la liste de distribution?" & vbNewLine & "Oui - Tous les contacts" & vbNewLine & "Non - Contact affiché seulement", MsgBoxStyle.YesNoCancel)
			
100: If iResult = MsgBoxResult.Yes Then
105: rstContact = New ADODB.Recordset
				
110: Call rstContact.Open("SELECT * FROM GRB_ContactFRS INNER JOIN GRB_Contact ON GRB_ContactFRS.NoContact = GRB_Contact.IDContact WHERE GRB_ContactFRS.NoFRS = " & VB6.GetItemData(cmbFournisseur, cmbFournisseur.SelectedIndex) & " ORDER BY NomContact", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
				
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
200: If Trim(txtContactEmail.Text) <> "" Then
205: bArrayVide = False
						
210: ReDim Preserve sIDContact(0)
215: ReDim Preserve itmContact(0)
220: ReDim Preserve sContact(0)
						
225: sIDContact(0) = CStr(VB6.GetItemData(cmbContact, cmbContact.SelectedIndex))
230: sContact(0) = cmbContact.Text
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
420: sMsgPlein = CBool("Les contacts suivants n'ont pas pu être ajouté car la liste contient déjà 10 contacts!" & vbNewLine & vbNewLine)
						
425: iNbreRendu = iCompteur
						
430: For iCompteur = iNbreRendu To UBound(sContact)
435: sMsgPlein = CBool(sMsgPlein & sContact(iCompteur))
							
440: If iCompteur < UBound(sContact) Then
445: sMsgPlein = CBool(sMsgPlein & vbNewLine)
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
550: Call AfficherErreur("frmFRS", "cmdMailListContact_Click", Err, Erl())
555: End If
		
560: fraEtatOutlook.Visible = False
	End Sub
	
	Private Sub cmdMailListFournisseur_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMailListFournisseur.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim folFRS As Outlook.MAPIFolder
20: Dim itmFRS As Outlook.ContactItem
25: Dim otlRecipient As Outlook.Recipient
30: Dim bDejaOuvert As Boolean
		
35: If cmbFournisseur.SelectedIndex <> -1 Then
40: If Trim(txtEmail.Text) <> "" Then
45: otlApp = OuvrirOutlook(bDejaOuvert)
				
55: lblEtatOutlook.Text = "Recherche des listes de distribution..."
				
60: fraEtatOutlook.Visible = True
				
65: Call frmChoixMailList.Afficher(Me, otlApp)
				
70: If m_bAnnulerDistList = False Then
75: lblEtatOutlook.Text = "Ajout du fournisseur dans la liste de distribution..."
					
80: fraEtatOutlook.Visible = True
					
85: If m_otlDistList.MemberCount < 10 Then
90: folFRS = GetFolder(otlApp, "Fournisseurs GRB")
						
95: itmFRS = folFRS.Items.Find("[User1] = " & VB6.GetItemData(cmbFournisseur, cmbFournisseur.SelectedIndex))
						
100: If Not itmFRS Is Nothing Then
105: otlRecipient = otlApp.Session.CreateRecipient(itmFRS.Email1DisplayName)
							
110: If otlRecipient.Resolve = True Then
115: Call m_otlDistList.AddMember(otlRecipient)
								
120: Call m_otlDistList.Save()
125: Else
130: Call MsgBox("Impossible de trouver le fournisseur!", MsgBoxStyle.OKOnly, "Erreur")
135: End If
140: Else
145: Call MsgBox("Fournisseur introuvable!", MsgBoxStyle.OKOnly, "Erreur")
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
205: Call MsgBox("Ce fournisseur n'a pas d'email!", MsgBoxStyle.OKOnly, "Erreur")
210: End If
215: Else
220: Call MsgBox("Aucun fournisseur sélectionné!", MsgBoxStyle.OKOnly, "Erreur")
225: End If
		
230: Exit Sub
		
AfficherErreur: 
		
235: If Err.Number = 287 And Erl() = 115 Then
240: Call MsgBox("La liste de distribution est pleine!", MsgBoxStyle.OKOnly, "Erreur")
245: Else
250: Call AfficherErreur("frmFRS", "cmdMailListFournisseur_Click", Err, Erl())
255: End If
		
260: fraEtatOutlook.Visible = False
	End Sub
	
	Private Sub cmdRafraichir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRafraichir.Click
		
5: On Error GoTo AfficherErreur
		
		'Rafraichir la liste après avoir fait une recherche
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'Remplir le combo
15: Call RemplirComboFournisseur()
16: cmbcatégorie.SelectedIndex = -1
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmFRS", "cmdRafraichir_Click", Err, Erl())
	End Sub
	
	Private Sub ViderBarrerChamps(ByVal bLocked As Boolean, ByVal bVider As Boolean)
		
5: On Error GoTo AfficherErreur
		'Cette procédure vide et unlock tous les textbox pour pouvoir ajouter
		
10: If bVider = True Then
20: txtAdresse.Text = vbNullString
25: txtVille.Text = vbNullString
30: txtProvEtat.Text = vbNullString
35: txtPays.Text = vbNullString
40: txtCP.Text = vbNullString
45: txtEmail.Text = vbNullString
50: txtSiteWeb.Text = vbNullString
55: txtcommentaire.Text = vbNullString
60: txtTelephone.Text = vbNullString
65: txtFax.Text = vbNullString
70: lblDateCreation.Text = vbNullString
75: lblUserCreation.Text = vbNullString
80: lblDateModification.Text = vbNullString
85: lblUserModification.Text = vbNullString
90: End If
		
95: txtAdresse.ReadOnly = bLocked
100: txtVille.ReadOnly = bLocked
105: txtProvEtat.ReadOnly = bLocked
110: txtPays.ReadOnly = bLocked
115: txtCP.ReadOnly = bLocked
120: txtEmail.ReadOnly = bLocked
125: txtSiteWeb.ReadOnly = bLocked
130: txtTelephone.ReadOnly = bLocked
135: txtFax.ReadOnly = bLocked
140: txtcommentaire.ReadOnly = bLocked
		
145: Exit Sub
		
AfficherErreur: 
		
150: Call AfficherErreur("frmFRS", "ViderBarrerChamps", Err, Erl())
	End Sub
	
	Private Sub ViderBarrerChampsContact(ByVal bLocked As Boolean, ByVal bVider As Boolean)
		
5: On Error GoTo AfficherErreur
		'Cette procédure vide et unlock tous les textbox pour pouvoir ajouter
		
10: If bVider = True Then
15: txtContactTitre.Text = vbNullString
20: txtContactCell.Text = vbNullString
25: txtContactDom.Text = vbNullString
30: txtContactEmail.Text = vbNullString
35: txtContactFax.Text = vbNullString
40: txtContactPage.Text = vbNullString
45: txtContactPoste.Text = vbNullString
50: txtContactTel.Text = vbNullString
55: End If
		
60: txtContactTitre.ReadOnly = bLocked
65: txtContactCell.ReadOnly = bLocked
70: txtContactDom.ReadOnly = bLocked
75: txtContactEmail.ReadOnly = bLocked
80: txtContactFax.ReadOnly = bLocked
85: txtContactPage.ReadOnly = bLocked
90: txtContactPoste.ReadOnly = bLocked
95: txtContactTel.ReadOnly = bLocked
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmFRS", "ViderBarrerChampsContact", Err, Erl())
	End Sub
	Private Sub CmdAddCont_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdAddCont.Click
		
5: On Error GoTo AfficherErreur
		
		'Pour faire l'ajout d'un contact
10: Dim sNom As String
15: Dim rstContact As ADODB.Recordset
20: Dim bAjouter As Boolean
		
25: If cmbFournisseur.Items.Count > 0 Then
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
145: txtcontact.Text = sNom
					
150: Call ViderBarrerChampsContact(False, True)
					
155: Call HideEdMaskContact(False)
					
160: Call mskContactTel.Focus()
					
165: txtNomFournisseur.Visible = True
170: txtNomFournisseur.ReadOnly = True
					
					'Remplis le combo avec tous les contacts
175: Call AfficherControles(enumMode.MODE_CONTACT)
					
180: Call txtContactTitre.Focus()
185: End If
190: Else
195: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
200: m_bNewContact = False
				
205: txtNomFournisseur.Visible = True
210: txtNomFournisseur.ReadOnly = True
				
				'Remplis le combo avec tous les contacts
215: Call AfficherControles(enumMode.MODE_CONTACT)
				
220: Call RemplirComboContact()
225: End If
			
230: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
235: Else
240: Call MsgBox("Aucun enregistrement de sélectionné")
245: End If
		
250: Exit Sub
		
AfficherErreur: 
		
255: Call AfficherErreur("frmFRS", "CmdAddCont_Click", Err, Erl())
	End Sub
	
	Private Sub HideEdMask(ByVal bVisible As Boolean)
		
5: On Error GoTo AfficherErreur
		
		'proc qui rend visible/ou non les maskEdBox
		'On en profite pour les nettoyer du dernier Enregistrement
		'et on fait l'inverse avec les textBox
10: If m_bModeAjoutFRS = True Then
15: txtTelephone.Text = vbNullString
20: txtFax.Text = vbNullString
			
25: mskTelephone.Text = vbNullString
30: mskFax.Text = vbNullString
35: Else
40: mskTelephone.Text = txtTelephone.Text
45: mskFax.Text = txtFax.Text
50: End If
		
55: mskTelephone.Visible = Not bVisible
60: txtTelephone.Visible = bVisible
		
65: mskFax.Visible = Not bVisible
70: txtFax.Visible = bVisible
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmFRS", "HideEdMask", Err, Erl())
	End Sub
	
	Private Sub HideEdMaskContact(ByVal bVisible As Boolean)
		
5: On Error GoTo AfficherErreur
		
		'proc qui rend visible/ou non les maskEdBox
		'On en profite pour les nettoyer du dernier Enregistrement
		'et on fait l'inverse avec les textBox
10: If m_bModeAjoutContact = True Then
15: txtContactTel.Text = vbNullString
20: txtContactFax.Text = vbNullString
25: txtContactPage.Text = vbNullString
30: txtContactCell.Text = vbNullString
35: txtContactDom.Text = vbNullString
			
40: mskContactTel.Text = vbNullString
45: mskContactFax.Text = vbNullString
50: mskContactPage.Text = vbNullString
55: mskContactCell.Text = vbNullString
60: mskContactDom.Text = vbNullString
65: End If
		
70: mskContactTel.Visible = Not bVisible
75: txtContactTel.Visible = bVisible
		
80: mskContactFax.Visible = Not bVisible
85: txtContactFax.Visible = bVisible
		
90: mskContactPage.Visible = Not bVisible
95: txtContactPage.Visible = bVisible
		
100: mskContactCell.Visible = Not bVisible
105: txtContactCell.Visible = bVisible
		
110: mskContactDom.Visible = Not bVisible
115: txtContactDom.Visible = bVisible
		
120: Exit Sub
		
AfficherErreur: 
		
125: Call AfficherErreur("frmFRS", "HideEdMaskContact", Err, Erl())
	End Sub
	
	Private Sub cmdreport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdreport.Click
		Dim DR_ListeFournisseur As Object
		
5: On Error GoTo AfficherErreur
		
		'Impression de la liste des fournisseurs
10: Dim rstFournisseur As ADODB.Recordset
		
15: rstFournisseur = New ADODB.Recordset
		
20: If MsgBox("Voulez-vous imprimer ce fournisseur uniquement?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
25: Call rstFournisseur.Open("SELECT * FROM GRB_Fournisseur WHERE IDFRS = " & m_iNoFournisseur, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
30: Else
35: If MsgBox("Voulez-vous filtrer par la ville '" & txtVille.Text & "'?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
40: Call rstFournisseur.Open("SELECT * FROM GRB_Fournisseur WHERE ville = '" & Replace(txtVille.Text, "'", "''") & "' AND Supprimé = False ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
45: Else
50: Call rstFournisseur.Open("SELECT * FROM GRB_Fournisseur WHERE Supprimé = False ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
55: End If
60: End If
		
65: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'Set le rapport
70: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeFournisseur.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ListeFournisseur.DataSource = rstFournisseur
		
75: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeFournisseur.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ListeFournisseur.Orientation = MSDataReportLib.OrientationConstants.rptOrientLandscape
		
80: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeFournisseur.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_ListeFournisseur.Show(VB6.FormShowConstants.Modal)
		
85: Call rstFournisseur.Close()
90: 'UPGRADE_NOTE: Object rstFournisseur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFournisseur = Nothing
		
95: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmFRS", "cmdreport_Click", Err, Erl())
	End Sub
	
	Private Sub AfficherControles(ByVal eMode As enumMode)
		
5: On Error GoTo AfficherErreur
		
		'Proc qui fait le switch boutton visible/invible
		'on utilise le textBox dummy pour montrer contact
10: Dim bCmbFournisseur As Boolean
15: Dim bTxtFournisseur As Boolean
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
115: Dim bMailListFRS As Boolean
120: Dim bMailListContact As Boolean
		
125: Select Case eMode
			Case enumMode.MODE_FRS
130: bTxtFournisseur = True
135: bCmdEnr = True
140: bCmdAnul = True
141: m_bCategorie = True 'GLL 1.44
142: cmb_modCat.Visible = True 'GLL 1.44
				
			Case enumMode.MODE_CONTACT
145: bFraContact = True
150: bTxtFournisseur = True
155: bCmdAnulContact = True
160: bCmdRefCont = True
				
165: If m_bNewContact = True Then
170: bTxtContact = True
175: Else
180: bCmbContact = True
185: End If
				
			Case enumMode.MODE_INACTIF
190: bFraContact = True
195: bCmbFournisseur = True
200: bCmdImprimer = True
205: bTxtRechercher = True
210: bCmdRenommer = True
215: bCmdRafraichir = True
220: bCmdAdd = True
225: bCmdSupp = True
230: bCmdModif = True
235: bCmdQuit = True
240: bCmdAddCont = True
245: bCmdSupContact = True
250: bFax = True
255: bCmbContact = True
260: bMailListContact = True
265: bMailListFRS = True
270: m_bCategorie = False 'GLL V1.44
271: cmb_modCat.Visible = False 'GLL V1.44
275: If Len(txtRechercher.Text) > 0 Then
280: bCmdRechercher = True
285: End If
290: End Select
		
295: cmbFournisseur.Visible = bCmbFournisseur
300: txtNomFournisseur.Visible = bTxtFournisseur
305: fracontact.Visible = bFraContact
310: txtRechercher.Enabled = bTxtRechercher
315: cmdRechercher.Enabled = bCmdRechercher
320: cmdRafraichir.Enabled = bCmdRafraichir
325: cmdrenommer.Enabled = bCmdRenommer
330: cmdReport.Visible = bCmdImprimer
335: CmdAdd.Visible = bCmdAdd
340: CmdSupp.Visible = bCmdSupp
345: CmdModif.Visible = bCmdModif
350: CmdFerme.Visible = bCmdQuit
355: CmdAnul.Visible = bCmdAnul
360: CmdEnr.Visible = bCmdEnr
365: CmdAddCont.Visible = bCmdAddCont
370: cmdsupcontact.Visible = bCmdSupContact
375: cmdAnnulerContact.Visible = bCmdAnulContact
380: cmdEnregistrerContact.Visible = bCmdRefCont
385: cmdFax.Visible = bFax
390: cmbContact.Visible = bCmbContact
395: txtcontact.Visible = bTxtContact
400: cmdMailListFournisseur.Visible = bMailListFRS
405: cmdMailListContact.Visible = bMailListContact
		
410: Exit Sub
		
AfficherErreur: 
		
415: Call AfficherErreur("frmFRS", "AfficherControles", Err, Erl())
	End Sub
	
	Private Sub CmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdAdd.Click
		
5: On Error GoTo AfficherErreur
		'proc qui permet d'ajouter un contact à la BD
10: Dim sName As String
		
15: Call AfficherControles(enumMode.MODE_FRS)
		
20: sName = InputBox("Veuillez entrer le nom du fournisseur" & vbNewLine & vbNewLine & "SVP, respectez le bon orthographe!", "SAISIE DU NOM", "Nom du fournisseur")
		
25: If sName <> vbNullString Then
30: If Not ComboContient(cmbFournisseur, sName) Then
35: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
40: m_bModeAjoutFRS = True
				
				'On montre les maskEdBox
45: Call HideEdMask(False)
				
				'On affiche le nom du nouveau client dans le textbox
				'pour éviter le ScrollDown durant l'ajout
50: txtNomFournisseur.Text = sName
				
55: Call ViderBarrerChamps(False, True)
				
60: Call mskTelephone.Focus()
				
65: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
70: Else
75: Call MsgBox("Ce fournisseur existe déjà!")
				
80: Call AfficherControles(enumMode.MODE_INACTIF)
85: End If
90: Else
95: Call AfficherControles(enumMode.MODE_INACTIF)
100: End If
		
105: Exit Sub
		
AfficherErreur: 
		
110: Call AfficherErreur("frmFRS", "CmdAdd_Click", Err, Erl())
	End Sub
	
	Private Sub CmdAnul_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdAnul.Click
		
5: On Error GoTo AfficherErreur
		
		'Annule l'ajout ou la modif
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'On cache le maskEdBox
15: Call HideEdMask(True)
		
		'commentaire unlock
		'txtNomClient.Visible = False
		
		'on retablis les bouttons
20: Call AfficherControles(enumMode.MODE_INACTIF)
		
25: m_bModeAjoutFRS = False
		
30: Call ViderBarrerChamps(True, True)
		
35: Call cmbFournisseur_SelectedIndexChanged(cmbFournisseur, New System.EventArgs())
		
40: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmFRS", "CmdAnul_Click", Err, Erl())
	End Sub
	
	Private Sub CmdEnr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdEnr.Click
		
5: On Error GoTo AfficherErreur
		
		'Enregistrement d'une modif ou d'un ajout
10: Dim sFournisseur As String
15: Dim iCompteur As Short
		
		'Nom du fournisseur
20: sFournisseur = txtNomFournisseur.Text
		
		'Enregistrement d'un frs dans la BD
25: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
30: Call EnregistrerFournisseur()
		
		'On cache les MaskEdBox
35: Call HideEdMask(True)
		
		'On met a jour le combo
40: Call RemplirComboFournisseur()
		
		'Retablir les boutons
45: Call AfficherControles(enumMode.MODE_INACTIF)
		
50: For iCompteur = 0 To cmbFournisseur.Items.Count - 1
55: If VB6.GetItemString(cmbFournisseur, iCompteur) = sFournisseur Then
60: cmbFournisseur.SelectedIndex = iCompteur
				
65: Exit For
70: End If
75: Next 
		
80: Call cmbFournisseur.Focus()
		
85: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
90: Exit Sub
		
AfficherErreur: 
		
95: Call AfficherErreur("frmFRS", "CmdEnr_Click", Err, Erl())
	End Sub
	
	Private Sub CmdFerme_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdFerme.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFRS", "CmdFerme_Click", Err, Erl())
	End Sub
	
	Private Sub CmdModif_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdModif.Click
		
5: On Error GoTo AfficherErreur
		
10: If cmbFournisseur.Items.Count > 0 Then
15: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
			'proc qui permet de modifier l'enr courant
20: Call HideEdMask(False)
			
25: Call AfficherControles(enumMode.MODE_FRS)
			
30: Call ViderBarrerChamps(False, False)
			
35: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
40: Else
45: Call MsgBox("Aucun enregistrement sélectionné!")
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmFRS", "CmdModif_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRenommer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRenommer.Click
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''''''''''
		'on renomme le nom du FOURNISSEUR
		''''''''''''''''''''''''''''''''''''''''
10: Dim rstFournisseur As ADODB.Recordset
15: Dim sName As String
		
20: If cmbFournisseur.Items.Count > 0 Then
			'Proc qui permet de modifié un CLIENT a la BD
			'On procede a la saisie du nom du CLIENT
25: sName = InputBox("Veuillez entrer le nom du Fournisseur", "Renommer fournisseur", txtNomFournisseur.Text)
			
30: If sName <> vbNullString Then
35: If sName <> txtNomFournisseur.Text Then
40: If Not ComboContient(cmbFournisseur, sName) Then
45: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
						System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
						
50: rstFournisseur = New ADODB.Recordset
						
55: Call rstFournisseur.Open("SELECT IDFrs, NomFournisseur, EntryIDOutlook FROM GRB_Fournisseur WHERE IDFRS = " & m_iNoFournisseur, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
						
60: Call ModifierNomFRSExchange(sName, m_iNoFournisseur)
						
65: txtNomFournisseur.Text = sName
						
						'transfert des donnes
70: rstFournisseur.Fields("NomFournisseur").Value = txtNomFournisseur.Text
						
						'mise a jour de la base de donne
75: Call rstFournisseur.Update()
						
80: Call rstFournisseur.Close()
85: 'UPGRADE_NOTE: Object rstFournisseur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						rstFournisseur = Nothing
						
90: Call RemplirComboFournisseur()
						
95: cmbFournisseur.Text = sName
						
100: m_bRenommer = True
						
105: Call cmbFournisseur_SelectedIndexChanged(cmbFournisseur, New System.EventArgs())
						
110: m_bRenommer = False
						
115: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
						System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
120: Else
125: Call MsgBox("Le fournisseur " & sName & " existe déjà!", MsgBoxStyle.Critical)
130: End If
135: End If
140: End If
145: Else
150: Call MsgBox("Aucun enregistrement de sélectionné!", MsgBoxStyle.OKOnly, "Erreur")
155: End If
		
160: Exit Sub
		
AfficherErreur: 
		
165: Call AfficherErreur("frmFRS", "cmdRenommer_Click", Err, Erl())
	End Sub
	
	Private Sub cmdsupcontact_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdsupcontact.Click
		
5: On Error GoTo AfficherErreur
		
		'Fonction qui supprime l'enregistrement courant
10: If cmbContact.Items.Count > 0 Then
15: If MsgBox("Etes-vous sur de vouloir supprimer cette enregistrement?", MsgBoxStyle.YesNo, "Supprimer") = MsgBoxResult.Yes Then
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
25: Call g_connData.Execute("DELETE * FROM GRB_ContactFRS WHERE NoFRS = " & m_iNoFournisseur & " AND NoContact = " & m_iNoContact)
				
30: Call LierContactFournisseur(m_iNoFournisseur)
				
				'Femplis le combo employé
35: Call RemplirComboContact()
				
40: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
45: End If
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmFRS", "cmdsupcontact_Click", Err, Erl())
	End Sub
	
	Private Sub CmdSupp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdSupp.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjSoum As ADODB.Recordset
15: Dim rstCatalogue As ADODB.Recordset
20: Dim rstFRS As ADODB.Recordset
25: Dim bPeutEffacer As Boolean
		
		'Fonction qui supprime lenregistrement courant
30: If cmbFournisseur.Items.Count > 0 Then
35: If MsgBox("Etes-vous sur de supprimer cette enregistrement?", MsgBoxStyle.YesNo, "Supprimer") = MsgBoxResult.Yes Then
40: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
				'Open table
45: rstProjSoum = New ADODB.Recordset
50: rstCatalogue = New ADODB.Recordset
				
55: Call rstProjSoum.Open("SELECT * FROM GRB_Soumission_Pieces WHERE IDFRS = " & m_iNoFournisseur, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
60: Call rstCatalogue.Open("SELECT * FROM GRB_PiecesFRS WHERE IDFRS = " & m_iNoFournisseur, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
				'si existe pas dans soumission
65: If rstProjSoum.EOF Then
70: Call rstProjSoum.Close()
					'si existe pas dans projet
75: Call rstProjSoum.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDFRS = " & m_iNoFournisseur, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
80: If rstProjSoum.EOF Then
						'si existe pas dans la table fournisseurs pour une piece
85: If rstCatalogue.EOF Then
90: bPeutEffacer = True
95: Else
100: bPeutEffacer = False
105: End If
110: Else
115: bPeutEffacer = False
120: End If
125: Else
130: bPeutEffacer = False
135: End If
				
140: Call rstCatalogue.Close()
145: 'UPGRADE_NOTE: Object rstCatalogue may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstCatalogue = Nothing
				
150: Call rstProjSoum.Close()
155: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstProjSoum = Nothing
				
160: If cmbContact.Items.Count > 0 Then
					'Delete les contact» pour ce fournisseur
165: Call g_connData.Execute("DELETE * FROM GRB_ContactFRS WHERE NoFRS = " & m_iNoFournisseur)
170: End If
				
175: Call SupprimerFRSExchange(m_iNoFournisseur)
				
180: If bPeutEffacer = True Then
185: Call g_connData.Execute("DELETE * FROM GRB_Fournisseur WHERE IDFRS = " & m_iNoFournisseur)
190: Else
195: rstFRS = New ADODB.Recordset
					
200: Call rstFRS.Open("SELECT * FROM GRB_Fournisseur WHERE IDFRS = " & m_iNoFournisseur, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
205: rstFRS.Fields("Supprimé").Value = True
					
210: Call rstFRS.Update()
					
215: Call rstFRS.Close()
220: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstFRS = Nothing
225: End If
				
				'Remplir le combo des fournisseurs
230: Call RemplirComboFournisseur()
				
235: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
240: End If
245: Else
250: Call MsgBox("Aucun enregistrement sélectionné!")
255: End If
		
260: Exit Sub
		
AfficherErreur: 
		
265: Call AfficherErreur("frmFRS", "CmdSupp_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbFournisseur.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbFournisseur_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbFournisseur.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		'Quand le user selectionne un enregistrement on se posotionne dessus
10: If cmbFournisseur.Text <> vbNullString Then
15: txtNomFournisseur.Text = cmbFournisseur.Text
20: Else
25: If ComboContient(cmbFournisseur, txtNomFournisseur.Text) = False Then
30: Call RemplirComboFournisseur()
35: End If
			
40: cmbFournisseur.Text = txtNomFournisseur.Text
45: End If
		
50: If cmbFournisseur.SelectedIndex > -1 Then
55: If m_bRenommer = False And m_bModeAjoutFRS = False Then
60: m_iNoFournisseur = VB6.GetItemData(cmbFournisseur, cmbFournisseur.SelectedIndex)
65: End If
70: End If
		
		'Affiche le fournisseur sélectionné dans le combo
75: Call AfficherFournisseur()
80: Call RemplirComboContact()
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("frmFRS", "cmbFournisseur_Click", Err, Erl())
	End Sub
	
	
	
	
	
	
	Private Sub FrmFRS_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: 
		
15: Call tbl_cat_exist() 'GLL 2017-11-28 V1.44
20: Call FindFieldsExist() 'GLL 2017-11-28 V1.44
		
25: Call RemplirComboFournisseur()
30: Call RemplirComboCatégorie() 'GLL 2017-11-28 V1.44
		
35: Call HideEdMask(True)
		
40: Call AfficherControles(enumMode.MODE_INACTIF)
		
45: Call ActiverBoutonsGroupe()
		
50: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmFRS", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub ActiverBoutonsGroupe()
		
5: On Error GoTo AfficherErreur
		
		'Activation des boutons selon le groupe
10: CmdAdd.Enabled = g_bModificationFournisseurs
15: CmdModif.Enabled = g_bModificationFournisseurs
20: cmdrenommer.Enabled = g_bModificationFournisseurs
25: CmdSupp.Enabled = g_bModificationFournisseurs
30: CmdAddCont.Enabled = g_bModificationFournisseurs
35: cmdsupcontact.Enabled = g_bModificationFournisseurs
40: cmdMailListContact.Enabled = g_bModificationListeDistribution
45: cmdMailListFournisseur.Enabled = g_bModificationListeDistribution
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmFRS", "ActiverBoutonsGroupe", Err, Erl())
	End Sub
	
	Private Sub FrmFRS_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_NOTE: Object FrmFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Me = Nothing
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFRS", "Form_Unload", Err, Erl())
	End Sub
	
	'UPGRADE_ISSUE: MSComctlLib.ListView event Lst_Cat.ItemClick was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub Lst_Cat_ItemClick(ByVal Item As System.Windows.Forms.ListViewItem)
		cmdcatmod.Enabled = True
	End Sub
	
	
	
	Private Sub mskTelephone_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskTelephone.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskTelephone.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFRS", "mskTelephone_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskTelephone_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskTelephone.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskTelephone.Mask = vbNullString
		
15: If mskTelephone.Text = "(___) ___-____" Then
20: mskTelephone.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmFRS", "mskTelephone_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskFax_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskFax.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskFax.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFRS", "mskFax_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskFax_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskFax.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskFax.Mask = vbNullString
		
15: If mskFax.Text = "(___) ___-____" Then
20: mskFax.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmFRS", "mskFax_LostFocus", Err, Erl())
	End Sub
	
	Private Sub cmdRechercher_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercher.Click
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des fournisseurs selon le texte à rechercher
10: Dim rstFournisseur As ADODB.Recordset
15: Dim sSearch As String
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
25: sSearch = txtRechercher.Text
		
		'vide les champs
30: Call ViderBarrerChamps(True, True)
		
		'Filtre pour selection des Nomcontact
35: rstFournisseur = New ADODB.Recordset
		
40: Call rstFournisseur.Open("SELECT NomFournisseur, IDFRS FROM GRB_Fournisseur WHERE Instr(1, NomFournisseur, '" & Replace(sSearch, "'", "''") & "') > 0 AND Supprimé = False ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'vide combo
45: Call cmbFournisseur.Items.Clear()
		
		'Tant que ce n'est pas la fin des enregistrements
50: Do While Not rstFournisseur.EOF
55: Call cmbFournisseur.Items.Add(rstFournisseur.Fields("NomFournisseur").Value)
60: 'UPGRADE_ISSUE: ComboBox property cmbFournisseur.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbFournisseur, cmbFournisseur.NewIndex, rstFournisseur.Fields("IDFRS").Value)
			
65: Call rstFournisseur.MoveNext()
70: Loop 
		
75: Call rstFournisseur.Close()
80: 'UPGRADE_NOTE: Object rstFournisseur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFournisseur = Nothing
		
85: If cmbFournisseur.Items.Count > 0 Then
90: cmbFournisseur.SelectedIndex = 0
95: Else
100: Call cmbContact.Items.Clear()
			
105: txtContactCell.Text = vbNullString
110: txtContactDom.Text = vbNullString
115: txtContactEmail.Text = vbNullString
120: txtContactFax.Text = vbNullString
125: txtContactPage.Text = vbNullString
130: txtContactPoste.Text = vbNullString
135: txtContactTel.Text = vbNullString
140: End If
		
145: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
150: Exit Sub
		
AfficherErreur: 
		
155: Call AfficherErreur("frmFRS", "cmdRechercher_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtRechercher.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtRechercher_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtRechercher.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If Len(Trim(txtRechercher.Text)) > 0 Then
15: cmdRechercher.Enabled = True
20: Else
25: cmdRechercher.Enabled = False
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmFRS", "txtRechercher_Change", Err, Erl())
	End Sub
	
	Private Sub mskContactTel_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactTel.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskContactTel.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFRS", "mskContactTel_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactTel_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactTel.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskContactTel.Mask = vbNullString
		
15: If mskContactTel.Text = "(___) ___-____" Then
20: mskContactTel.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmFRS", "mskContactTel_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactFax_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactFax.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskContactFax.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFRS", "mskContactFax_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactFax_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactFax.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskContactFax.Mask = vbNullString
		
15: If mskContactFax.Text = "(___) ___-____" Then
20: mskContactFax.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmFRS", "mskContactFax_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactCell_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactCell.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskContactCell.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFRS", "mskContactCell_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactCell_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactCell.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskContactCell.Mask = vbNullString
		
15: If mskContactCell.Text = "(___) ___-____" Then
20: mskContactCell.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmFRS", "mskContactCell_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactDom_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactDom.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskContactDom.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFRS", "mskContactDom_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactDom_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactDom.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskContactDom.Mask = vbNullString
		
15: If mskContactDom.Text = "(___) ___-____" Then
20: mskContactDom.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmFRS", "mskContactDom_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactPage_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactPage.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskContactPage.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFRS", "mskContactPage_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskContactPage_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskContactPage.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskContactPage.Mask = vbNullString
		
15: If mskContactPage.Text = "(___) ___-____" Then
20: mskContactPage.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmFRS", "mskContactPage_LostFocus", Err, Erl())
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
		
65: Call AfficherErreur("frmFRS", "ExisteDansBD", Err, Erl())
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
		
40: Call AfficherErreur("frmFRS", "ContientCaracteresIncorrects", Err, Erl())
	End Function
	Private Sub AfficherCategorie() 'GLL 2017-11-28 V1.44
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''''''''''''
		'affiche les contacts selon leur catégorie'
		''''''''''''''''''''''''''''''''''''''''
10: Dim rstcategorie As ADODB.Recordset
15: Dim rstFournisseur As ADODB.Recordset
20: Dim i As Short
25: Dim j As Short
30: Dim id As Short
35: Dim sString As String
40: Dim cString As String
		
45: 'Ouverture de la table contact
50: rstcategorie = New ADODB.Recordset
55: rstFournisseur = New ADODB.Recordset
60: sString = "Select * From Tbl_Categorie where nom <> Null"
65: cmbFournisseur.Items.Clear()
70: Call rstcategorie.Open(sString, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
75: Do While Not rstcategorie.EOF
80: If rstcategorie.Fields("Nom").Value = cmbcatégorie.Text Then sString = rstcategorie.Fields("Correspondance").Value
85: Call rstcategorie.MoveNext()
90: Loop 
95: Call rstcategorie.Close()
100: 'UPGRADE_NOTE: Object rstcategorie may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstcategorie = Nothing
		
105: Call rstFournisseur.Open("Select * From GRB_Fournisseur where categorie <> Null", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
110: Do While Not rstFournisseur.EOF
115: If InStr(1, rstFournisseur.Fields("Categorie").Value, sString, CompareMethod.Text) > 0 Then
120: cmbFournisseur.Items.Add((rstFournisseur.Fields("NomFournisseur").Value))
125: 'UPGRADE_ISSUE: ComboBox property cmbFournisseur.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				VB6.SetItemData(cmbFournisseur, cmbFournisseur.NewIndex, rstFournisseur.Fields("IDFRS").Value)
			End If
130: Call rstFournisseur.MoveNext()
		Loop 
135: Call rstFournisseur.Close()
140: 'UPGRADE_NOTE: Object rstFournisseur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFournisseur = Nothing
		
145: If cmbFournisseur.Items.Count > 0 Then 'Afficher le premier Fournisseur qui est dans cette catégorie
150: cmbFournisseur.SelectedIndex = 0
155: Call cmbFournisseur_SelectedIndexChanged(cmbFournisseur, New System.EventArgs())
160: End If
		
165: Exit Sub
		
AfficherErreur: 
170: Call AfficherErreur("FrmFrs", "AfficherCategorie", Err, Erl())
	End Sub
	Private Sub RemplirComboCatégorie()
5: On Error GoTo AfficherErreur 'GLL 2017-11-28 V1.44
		
		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		'remplis le combo contact dépendant le client sélectionné
		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
10: Dim rstcategorie As ADODB.Recordset
		
15: rstcategorie = New ADODB.Recordset
		
		
35: Call rstcategorie.Open("SELECT  Nom FROM TBL_Categorie where nom <> Null order by Nom", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		
45: Call cmbcatégorie.Items.Clear()
		
50: Do While Not rstcategorie.EOF
55: Call cmbcatégorie.Items.Add(rstcategorie.Fields("nom").Value)
65: Call rstcategorie.MoveNext()
70: Loop 
		
		'Ferme la table "GRB_Contact"
75: Call rstcategorie.Close()
80: 'UPGRADE_NOTE: Object rstcategorie may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstcategorie = Nothing
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("frmFRS", "RemplirComboCatégorie", Err, Erl())
	End Sub
	Private Sub AfficherCatList() 'V1.44 GLL
		On Error GoTo AfficherErreur
		'Affiche dans Rstlist tout les catégorie enregistrer
5: Dim rstlist As ADODB.Recordset
10: Dim itemlist As System.Windows.Forms.ListViewItem
		
15: rstlist = New ADODB.Recordset
20: Call rstlist.Open("Select * from tbl_categorie where nom <> Null order by nom", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
25: Call Lst_Cat.Items.Clear()
		
		
30: Do While Not rstlist.EOF 'Ajoute dans la liste tout le catégorie trouver
35: 'UPGRADE_ISSUE: MSComctlLib.ListItems method Lst_Cat.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itemlist = Lst_Cat.Items.Add()
40: itemlist.Text = rstlist.Fields("Nom").Value
45: itemlist.Tag = rstlist.Fields("Correspondance").Value
50: Call rstlist.MoveNext()
55: Loop 
		Exit Sub
AfficherErreur: 
60: Call AfficherErreur("FrmFRS", "AfficherCatList", Err, Erl())
	End Sub
	Private Sub DeleteCategorie() 'V1.44 GLL
		'efface une catégorie de tout les fournisseur qui la possêde
5: On Error GoTo AfficherErreur
		
10: Dim rstcategorie As ADODB.Recordset
15: Dim sString As String
		
20: rstcategorie = New ADODB.Recordset
25: Call rstcategorie.Open("Select categorie from GRB_Fournisseur where categorie <> Null or categorie ='""'", g_connData, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockPessimistic)
		
30: Do While Not rstcategorie.EOF
			
35: If InStr(1, rstcategorie.Fields("categorie").Value, m_Tag, CompareMethod.Text) > 0 Then
40: sString = rstcategorie.Fields("categorie").Value
45: sString = Replace(sString, m_Tag, "", 1)
				
50: If sString = "" Then
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					rstcategorie.Fields("categorie").Value = System.DBNull.Value
				Else
60: rstcategorie.Fields("categorie").Value = sString
				End If
			End If
65: Call rstcategorie.MoveNext()
		Loop 
		
70: Call rstcategorie.Close()
75: 'UPGRADE_NOTE: Object rstcategorie may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstcategorie = Nothing
		Exit Sub
AfficherErreur: 
80: Call AfficherErreur("FrmFRS", "DeleteCategorie", Err, Erl())
	End Sub
	
	Private Sub tbl_cat_exist() 'V1.44
		'Vérifie si la tbl catégorie exist dans la basse de donné si non elle la crée
		
5: On Error GoTo AfficherErreur
10: Dim adoxconnection As ADOX.Catalog
15: Dim i As Short
		
20: adoxconnection = New ADOX.Catalog
25: adoxconnection.let_ActiveConnection(g_connData)
30: For i = 0 To adoxconnection.Tables.Count - 1
			
35: If LCase(adoxconnection.Tables(i).Name) = LCase("TBL_Categorie") Then 'Si elle exist on sort de la sous routine
40: 'UPGRADE_NOTE: Object adoxconnection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				adoxconnection = Nothing
				Exit Sub
45: End If
		Next 
		
50: Call g_connData.Execute("Create TABLE TBL_Categorie (Correspondance text(1), Nom Text (100))")
55: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('A');")
60: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('B');")
65: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('C');")
70: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('D');")
75: Call g_connData.Execute("Insert into TBL_Categorie (Correspondance) Values ('E');")
80: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('F');")
85: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('G');")
90: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('H');")
95: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('I');")
100: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('J');")
105: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('K');")
110: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('M');")
115: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('N');")
120: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('O');")
125: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('P');")
130: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('Q');")
135: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('R');")
140: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('S');")
145: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('T');")
150: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('U');")
155: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('V');")
160: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('W');")
165: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('X');")
170: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('Y');")
175: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('Z');")
180: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('1');")
185: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('2');")
190: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('3');")
195: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('4');")
200: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('5');")
205: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('6');")
210: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('7');")
215: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('8');")
220: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('9');")
225: Call g_connData.Execute("Insert into TBL_Categorie  (Correspondance) Values ('0');")
230: 'UPGRADE_NOTE: Object adoxconnection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		adoxconnection = Nothing
		Exit Sub
AfficherErreur: 
235: Call AfficherErreur("FrmFrs", "tbl_Cat_exist", Err, Erl())
	End Sub
	
	Private Sub FindFieldsExist() 'V1.44
5: On Error GoTo AfficherErreur
		
10: Dim strName As String
		
15: Dim Findfield As ADODB.Recordset
		
20: Dim i As Short
		
25: Findfield = New ADODB.Recordset
		
30: Call Findfield.Open("Select * from Grb_Fournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
35: For i = 0 To Findfield.Fields.Count - 1
			
40: strName = Findfield.Fields(i).Name
			
45: If strName = "Categorie" Then
				
50: Call Findfield.Close()
				
55: 'UPGRADE_NOTE: Object Findfield may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				Findfield = Nothing
				
60: Exit Sub
				
65: End If
			
70: Next 
		
75: Call Findfield.Close()
		
80: 'UPGRADE_NOTE: Object Findfield may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Findfield = Nothing
		
85: Call g_connData.Execute("ALTER TABLE GRB_Fournisseur Add Categorie Text(40);")
		Exit Sub
		
AfficherErreur: 
90: Call AfficherErreur("frmFRS", "FindFieldsExist()", Err, Erl())
	End Sub
End Class