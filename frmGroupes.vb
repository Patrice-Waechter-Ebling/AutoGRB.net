Option Strict Off
Option Explicit On
Friend Class frmGroupes
	Inherits System.Windows.Forms.Form
	
	Private Enum enumMode
		MODE_AJOUT = 0
		MODE_MODIF = 1
		MODE_INACTIF = 2
	End Enum
	
	Private m_bModeAjout As Boolean
	Private m_iNoGroupe As Short
	Private m_iModif As Short
	
	'UPGRADE_WARNING: Event chkClients.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkClients_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkClients.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
		'Si chkClient est cliqué, la modification des clients est permise
10: If chkClients.CheckState = System.Windows.Forms.CheckState.Checked Then
15: chkModificationClients.Enabled = True
20: Else
			'Enlève les crochets
25: chkModificationClients.CheckState = System.Windows.Forms.CheckState.Unchecked
			
30: chkModificationClients.Enabled = False
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmGroupes", "chkClients_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkPunch.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkPunch_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkPunch.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If chkPunch.CheckState = System.Windows.Forms.CheckState.Checked Then
15: chkPunchSemaineAnterieure.Enabled = True
20: Else
25: chkPunchSemaineAnterieure.CheckState = System.Windows.Forms.CheckState.Unchecked
			
30: chkPunchSemaineAnterieure.Enabled = False
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmGroupes", "chkPunch_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkSoumissionMec.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkSoumissionMec_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkSoumissionMec.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
		'Si chkSoumissionMec est cliqué, la modification des soumissions est permise
10: If chkSoumissionMec.CheckState = System.Windows.Forms.CheckState.Checked Then
15: chkModificationSoumissionMec.Enabled = True
20: Else
			'Enlève les crochets
25: chkModificationSoumissionMec.CheckState = System.Windows.Forms.CheckState.Unchecked
			
30: chkModificationSoumissionMec.Enabled = False
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmGroupes", "chkSoumissionMec_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkProjetMec.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkProjetMec_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkProjetMec.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
		'Si chkProjetMec est cliqué, la modification des projets est permise
10: If chkProjetMec.CheckState = System.Windows.Forms.CheckState.Checked Then
15: chkModificationProjetMec.Enabled = True
20: chkVerrouillageTempsProjet.Enabled = True
25: chkDeverrouillageTempsProjet.Enabled = True
30: Else
			'Enlève les crochets
35: chkModificationProjetMec.CheckState = System.Windows.Forms.CheckState.Unchecked
40: chkVerrouillageTempsProjet.CheckState = System.Windows.Forms.CheckState.Unchecked
45: chkDeverrouillageTempsProjet.CheckState = System.Windows.Forms.CheckState.Unchecked
			
50: chkModificationProjetMec.Enabled = False
55: chkVerrouillageTempsProjet.Enabled = False
60: chkDeverrouillageTempsProjet.Enabled = False
65: End If
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmGroupes", "chkProjetMec_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkSoumissionElec.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkSoumissionElec_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkSoumissionElec.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
		'Si chkSoumissionElec est cliqué, la modification des soumissions est permise
10: If chkSoumissionElec.CheckState = System.Windows.Forms.CheckState.Checked Then
15: chkModificationSoumissionElec.Enabled = True
20: Else
			'Enlève les crochets
25: chkModificationSoumissionElec.CheckState = System.Windows.Forms.CheckState.Unchecked
			
30: chkModificationSoumissionElec.Enabled = False
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmGroupes", "chkSoumissionElec_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkProjetElec.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkProjetElec_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkProjetElec.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
		'Si chkProjetElec est cliqué, la modification des projets est permise
10: If chkProjetElec.CheckState = System.Windows.Forms.CheckState.Checked Then
15: chkModificationProjetElec.Enabled = True
20: Else
			'Enlève les crochets
25: chkModificationProjetElec.CheckState = System.Windows.Forms.CheckState.Unchecked
			
30: chkModificationProjetElec.Enabled = False
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmGroupes", "chkProjetElec_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkOutils.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkOutils_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkOutils.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
		'Si chkOutils est cliqué, la modification des outils est permise
10: If chkOutils.CheckState = System.Windows.Forms.CheckState.Checked Then
15: chkModificationOutils.Enabled = True
20: Else
			'Enlève les crochets
25: chkModificationOutils.CheckState = System.Windows.Forms.CheckState.Unchecked
			
30: chkModificationOutils.Enabled = False
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmGroupes", "chkOutils_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkFournisseurs.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkFournisseurs_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkFournisseurs.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
		'Si chkFournisseur est cliqué, la modification des fournisseurs est permise
10: If chkFournisseurs.CheckState = System.Windows.Forms.CheckState.Checked Then
15: chkModificationFRS.Enabled = True
20: Else
			'Enlève les crochets
25: chkModificationFRS.CheckState = System.Windows.Forms.CheckState.Unchecked
			
30: chkModificationFRS.Enabled = False
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmGroupes", "chkFournisseurs_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkContacts.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkContacts_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkContacts.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
		'Si chkContacts est cliqué, la modification des contacts est permise
10: If chkContacts.CheckState = System.Windows.Forms.CheckState.Checked Then
15: chkModificationContacts.Enabled = True
20: Else
			'Enlève les crochets
25: chkModificationContacts.CheckState = System.Windows.Forms.CheckState.Unchecked
			
30: chkModificationContacts.Enabled = False
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmGroupes", "chkContacts_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkEmployes.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkEmployes_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkEmployes.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
		'Si chkEmployes est cliqué, la modification des employes,
		'des groupes et de la liste des punch sont permises
10: If chkEmployes.CheckState = System.Windows.Forms.CheckState.Checked Then
15: chkModificationEmployes.Enabled = True
20: chkModificationGroupes.Enabled = True
25: chkModificationPunchEmployes.Enabled = True
30: Else
			'Enlève les crochets
35: chkModificationEmployes.CheckState = System.Windows.Forms.CheckState.Unchecked
40: chkModificationGroupes.CheckState = System.Windows.Forms.CheckState.Unchecked
45: chkModificationPunchEmployes.CheckState = System.Windows.Forms.CheckState.Unchecked
			
50: chkModificationEmployes.Enabled = False
55: chkModificationGroupes.Enabled = False
60: chkModificationPunchEmployes.Enabled = False
65: End If
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmGroupes", "chkEmployes_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkCatalogueElec.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkCatalogueElec_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkCatalogueElec.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
		'Si chkCatalogueElec est cliqué, la modification des catalogueElec est permise
10: If chkCatalogueElec.CheckState = System.Windows.Forms.CheckState.Checked Then
15: chkModificationCatalogueElec.Enabled = True
20: Else
25: chkModificationCatalogueElec.CheckState = System.Windows.Forms.CheckState.Unchecked
			
30: chkModificationCatalogueElec.Enabled = False
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmGroupes", "chkCatalogueElec_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkCatalogueMec.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkCatalogueMec_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkCatalogueMec.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
		'Si chkCatalogueMec est cliqué, la modification des catalogueMec est permise
10: If chkCatalogueMec.CheckState = System.Windows.Forms.CheckState.Checked Then
15: chkModificationCatalogueMec.Enabled = True
20: Else
25: chkModificationCatalogueMec.CheckState = System.Windows.Forms.CheckState.Unchecked
			
30: chkModificationCatalogueMec.Enabled = False
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmGroupes", "chkCatalogueMec_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkInventaireMec.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkInventaireMec_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkInventaireMec.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
		'Si chkInventaireMec est cliqué, la modification de l'inventaireMec est permise
10: If chkInventaireMec.CheckState = System.Windows.Forms.CheckState.Checked Then
15: chkModificationInventaireMec.Enabled = True
20: Else
25: chkModificationInventaireMec.CheckState = System.Windows.Forms.CheckState.Unchecked
			
30: chkModificationInventaireMec.Enabled = False
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmGroupes", "chkInventaireMec_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkInventaireElec.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkInventaireElec_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkInventaireElec.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
		'Si chkInventairElec est cliqué, la modification de l'inventaireElec est permise
10: If chkInventaireElec.CheckState = System.Windows.Forms.CheckState.Checked Then
15: chkModificationInventaireElec.Enabled = True
20: Else
25: chkModificationInventaireElec.CheckState = System.Windows.Forms.CheckState.Unchecked
			
30: chkModificationInventaireElec.Enabled = False
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmGroupes", "chkInventaireElec_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbGroupe.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbGroupe_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbGroupe.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		'Affiche le groupe sélectionné
10: txtGroupe.Text = cmbGroupe.Text
		
15: m_iNoGroupe = VB6.GetItemData(cmbGroupe, cmbGroupe.SelectedIndex)
		
20: Call AfficherGroupe()
		
25: cmdModifier.Enabled = True
30: cmdsupprimer.Enabled = True
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmGroupes", "cmbGroupe_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAjouter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAjouter.Click
		
5: On Error GoTo AfficherErreur
		
		'Met en mode ajout
10: m_bModeAjout = True
		
15: Call UncheckedAll()
		
20: Call MontrerControles(enumMode.MODE_AJOUT)
		
25: txtGroupe.Text = vbNullString
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmGroupes", "cmdAjouter_Click", Err, Erl())
	End Sub
	
	Private Sub cmdModifier_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdModifier.Click
		
5: On Error GoTo AfficherErreur
		
10: If VB6.GetItemData(cmbGroupe, cmbGroupe.SelectedIndex) <> g_iNoGroupe Then
			'Met en mode modif
15: Call MontrerControles(enumMode.MODE_MODIF)
			
20: Call AfficherGroupe()
			
25: m_iModif = cmbGroupe.SelectedIndex
			
30: m_bModeAjout = False
35: Else
40: Call MsgBox("Impossible de modifier le groupe actuel!", MsgBoxStyle.OKOnly, "Erreur")
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmGroupes", "cmdModifier_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
		'Annule l'ajout ou la modif
10: Call MontrerControles(enumMode.MODE_INACTIF)
		
15: Call AfficherGroupe()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmGroupes", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdSupprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSupprimer.Click
		
5: On Error GoTo AfficherErreur
		
10: If cmbGroupe.Items.Count > 0 Then
			'Met la liste Up to date au cas où il y aurait des nouveaux enregistrements
15: Call AfficherUtilisateurs()
			
20: If txtGroupe.Text <> S_GROUPE_ADMIN And txtGroupe.Text <> S_GROUPE_DEFAUT Then
				'Il ne faut pas effacer un groupe si il y a des utilisateurs dedans
25: If lstUser.Items.Count = 0 Then
					'Efface le groupe
30: Call g_connData.Execute("DELETE * FROM GRB_Groupes WHERE NomGroupe = '" & Replace(cmbGroupe.Text, "'", "''") & "'")
					
35: Call RemplirComboGroupes()
40: Else
45: Call MsgBox("Il y a des utilisateurs dans ce groupe!", MsgBoxStyle.OKOnly, "Erreur")
50: End If
55: Else
60: Call MsgBox("Vous ne pouvez pas effacer ce groupe!", MsgBoxStyle.OKOnly, "Erreur")
65: End If
70: End If
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmGroupes", "cmdSupprimer_Click", Err, Erl())
	End Sub
	
	Private Sub cmdEnregistrer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEnregistrer.Click
		
5: On Error GoTo AfficherErreur
		
		'Enregistre un ajout ou une modif
10: If txtGroupe.Text <> vbNullString Then
15: Call EnregistrerGroupe()
			
20: Call MontrerControles(enumMode.MODE_INACTIF)
			
25: Call RemplirComboGroupes()
			
30: cmbGroupe.SelectedIndex = m_iModif
35: Else
40: Call MsgBox("Le nom du groupe ne peut pas être vide!", MsgBoxStyle.OKOnly, "Erreur")
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmGroupes", "cmdEnregistrer_Click", Err, Erl())
	End Sub
	
	Private Sub EnregistrerGroupe()
		
5: On Error GoTo AfficherErreur
		
		'Enregistre un groupe
10: Dim rstGroupes As ADODB.Recordset
		
15: rstGroupes = New ADODB.Recordset
		
		'Si en mode ajout
20: If m_bModeAjout = True Then
			'Ouverture de la table GRB_Groupes
25: Call rstGroupes.Open("SELECT * FROM GRB_Groupes", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
30: Call rstGroupes.AddNew()
			
35: m_bModeAjout = False
40: Else
			'Ouverture de la table GRB_Groupes avec le numéro du groupe
45: Call rstGroupes.Open("SELECT * FROM GRB_Groupes WHERE IDGroupe = " & m_iNoGroupe, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
50: End If
		
		'Enregistrement des valeurs
55: rstGroupes.Fields("NomGroupe").Value = txtGroupe.Text
60: rstGroupes.Fields("Clients").Value = chkClients.CheckState
65: rstGroupes.Fields("Fournisseurs").Value = chkFournisseurs.CheckState
70: rstGroupes.Fields("Contacts").Value = chkContacts.CheckState
75: rstGroupes.Fields("ContactsVendeurs").Value = chkContactsVendeurs.CheckState
80: rstGroupes.Fields("Rapport").Value = chkRapports.CheckState
85: rstGroupes.Fields("CatalogueMec").Value = chkCatalogueMec.CheckState
90: rstGroupes.Fields("CatalogueElec").Value = chkCatalogueElec.CheckState
95: rstGroupes.Fields("Employes").Value = chkEmployes.CheckState
100: rstGroupes.Fields("Cedule").Value = chkCedule.CheckState
105: rstGroupes.Fields("Configuration").Value = chkConfiguration.CheckState
110: rstGroupes.Fields("Punch").Value = chkPunch.CheckState
115: rstGroupes.Fields("Outils").Value = chkOutils.CheckState
120: rstGroupes.Fields("InventaireMec").Value = chkInventaireMec.CheckState
125: rstGroupes.Fields("SoumissionMec").Value = chkSoumissionMec.CheckState
130: rstGroupes.Fields("ProjetMec").Value = chkProjetMec.CheckState
135: rstGroupes.Fields("InventaireElec").Value = chkInventaireElec.CheckState
140: rstGroupes.Fields("SoumissionElec").Value = chkSoumissionElec.CheckState
145: rstGroupes.Fields("ProjetElec").Value = chkProjetElec.CheckState
150: rstGroupes.Fields("Achat").Value = chkAchat.CheckState
155: rstGroupes.Fields("ModificationClients").Value = chkModificationClients.CheckState
160: rstGroupes.Fields("ModificationFournisseurs").Value = chkModificationFRS.CheckState
165: rstGroupes.Fields("ModificationContacts").Value = chkModificationContacts.CheckState
170: rstGroupes.Fields("ModificationEmployes").Value = chkModificationEmployes.CheckState
175: rstGroupes.Fields("ModificationGroupes").Value = chkModificationGroupes.CheckState
180: rstGroupes.Fields("ModificationFeuillesTemps").Value = chkModificationFeuillesTemps.CheckState
185: rstGroupes.Fields("ModificationOutils").Value = chkModificationOutils.CheckState
190: rstGroupes.Fields("ModificationFacturation").Value = chkModificationFacturation.CheckState
195: rstGroupes.Fields("ModificationInventaireMec").Value = chkModificationInventaireMec.CheckState
200: rstGroupes.Fields("ModificationSoumissionsMec").Value = chkModificationSoumissionMec.CheckState
205: rstGroupes.Fields("ModificationProjetsMec").Value = chkModificationProjetMec.CheckState
210: rstGroupes.Fields("ModificationInventaireElec").Value = chkModificationInventaireElec.CheckState
215: rstGroupes.Fields("ModificationSoumissionsElec").Value = chkModificationSoumissionElec.CheckState
220: rstGroupes.Fields("ModificationProjetsElec").Value = chkModificationProjetElec.CheckState
225: rstGroupes.Fields("ModificationBonsCommandes").Value = chkModificationBonsCommandes.CheckState
230: rstGroupes.Fields("ModificationCatalogueElec").Value = chkModificationCatalogueElec.CheckState
235: rstGroupes.Fields("ModificationCatalogueMec").Value = chkModificationCatalogueMec.CheckState
240: rstGroupes.Fields("ModificationPunchEmployes").Value = chkModificationPunchEmployes.CheckState
245: rstGroupes.Fields("SuppressionProjets").Value = chkSupprimerProjets.CheckState
250: rstGroupes.Fields("ModificationReception").Value = chkReception.CheckState
255: rstGroupes.Fields("ModificationRetourMarchandise").Value = chkRetourMarchandise.CheckState
260: rstGroupes.Fields("ListeDistribution").Value = chkMailingList.CheckState
265: rstGroupes.Fields("PunchSemaineAntérieure").Value = chkPunchSemaineAnterieure.CheckState
270: rstGroupes.Fields("VerrouillageTempsProjet").Value = chkVerrouillageTempsProjet.CheckState
275: rstGroupes.Fields("DéverrouillageTempsProjet").Value = chkDeverrouillageTempsProjet.CheckState
		
280: Call rstGroupes.Update()
		
285: Call rstGroupes.Close()
290: 'UPGRADE_NOTE: Object rstGroupes may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstGroupes = Nothing
		
295: Exit Sub
		
AfficherErreur: 
		
300: Call AfficherErreur("frmGroupes", "EnregistrerGroupe", Err, Erl())
	End Sub
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
		'Fermeture de la fenêtre
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmGroupes", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub frmGroupes_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
		'Ouverture de la fenêtre
10: Call RemplirComboGroupes()
		
15: Call MontrerControles(enumMode.MODE_INACTIF)
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmGroupes", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub RemplirComboGroupes()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des groupes
10: Dim rstGroupes As ADODB.Recordset
		
		'Il faut vider le combo avant de le remplir
15: Call cmbGroupe.Items.Clear()
		
20: rstGroupes = New ADODB.Recordset
		
25: Call rstGroupes.Open("SELECT * FROM GRB_Groupes ORDER BY NomGroupe", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
30: Do While Not rstGroupes.EOF
			'Ajout du nom du groupe dans le combo
35: Call cmbGroupe.Items.Add(rstGroupes.Fields("NomGroupe").Value)
			
			'Ajout du numéro du groupe dans l'ItemData du combo
40: 'UPGRADE_ISSUE: ComboBox property cmbGroupe.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbGroupe, cmbGroupe.NewIndex, rstGroupes.Fields("IDGroupe").Value)
			
45: Call rstGroupes.MoveNext()
50: Loop 
		
55: Call rstGroupes.Close()
60: 'UPGRADE_NOTE: Object rstGroupes may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstGroupes = Nothing
		
		'Si le combo n'est pas vide, on sélectionne le premier élément
65: If cmbGroupe.Items.Count > 0 Then
70: cmbGroupe.SelectedIndex = 0
75: End If
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmGroupes", "RemplirComboGroupes", Err, Erl())
	End Sub
	
	Private Sub MontrerControles(ByVal eMode As enumMode)
		
5: On Error GoTo AfficherErreur
		
		'Met les controles Enabled/Disabled
		'                  Visible/Invisible
		'                  Locked /Unlocked
10: Dim bCmbGroupe As Boolean
15: Dim bTxtGroupe As Boolean
20: Dim bAnnuler As Boolean
25: Dim bEnregistrer As Boolean
30: Dim bQuitter As Boolean
35: Dim bAjouter As Boolean
40: Dim bModifier As Boolean
45: Dim bSupprimer As Boolean
50: Dim bAffichage As Boolean
55: Dim bModification As Boolean
60: Dim bLockedGroupe As Boolean
		
		
65: Select Case eMode
			'En mode ajout, on montre TxtGroupe,les boutons annuler et
			'enregistrer
			Case enumMode.MODE_AJOUT
70: bTxtGroupe = True
75: bAnnuler = True
80: bEnregistrer = True
85: bAffichage = True
90: bModification = True
				
			Case enumMode.MODE_MODIF
95: bTxtGroupe = True
				
100: If txtGroupe.Text = S_GROUPE_DEFAUT Then
105: bLockedGroupe = True
110: End If
				
115: bAnnuler = True
120: bEnregistrer = True
125: bAffichage = True
130: bModification = True
				
				'En mode inactif, on montre cmbGroupe, les boutons Ajouter,
				'Modifier, Supprimer et Quitter
			Case enumMode.MODE_INACTIF
135: bCmbGroupe = True
140: bQuitter = True
145: bAjouter = True
150: bModifier = True
155: bSupprimer = True
160: End Select
		
165: txtGroupe.Visible = bTxtGroupe
170: txtGroupe.ReadOnly = bLockedGroupe
175: cmbGroupe.Visible = bCmbGroupe
180: cmdAnnuler.Visible = bAnnuler
185: cmdEnregistrer.Visible = bEnregistrer
190: cmdFermer.Visible = bQuitter
195: cmdAjouter.Visible = bAjouter
200: cmdModifier.Visible = bModifier
205: cmdsupprimer.Visible = bSupprimer
210: fraAffichage.Enabled = bAffichage
215: fraModification.Enabled = bModification
		
220: Exit Sub
		
AfficherErreur: 
		
225: Call AfficherErreur("frmGroupes", "MontrerControles", Err, Erl())
	End Sub
	
	Private Sub AfficherGroupe()
		
5: On Error GoTo AfficherErreur
		
		'Affiche le groupe selon la sélection dans le combo
10: Dim rstGroupes As ADODB.Recordset
		
15: rstGroupes = New ADODB.Recordset
		
20: Call rstGroupes.Open("SELECT * FROM GRB_Groupes WHERE IDGroupe = " & m_iNoGroupe, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: chkClients.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("Clients").Value))
30: chkFournisseurs.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("Fournisseurs").Value))
35: chkContacts.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("Contacts").Value))
40: chkContactsVendeurs.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ContactsVendeurs").Value))
45: chkRapports.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("Rapport").Value))
50: chkCatalogueMec.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("CatalogueMec").Value))
55: chkCatalogueElec.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("CatalogueElec").Value))
60: chkEmployes.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("Employes").Value))
65: chkCedule.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("Cedule").Value))
70: chkConfiguration.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("Configuration").Value))
75: chkPunch.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("Punch").Value))
80: chkOutils.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("Outils").Value))
85: chkSoumissionMec.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("SoumissionMec").Value))
90: chkProjetMec.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ProjetMec").Value))
95: chkSoumissionElec.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("SoumissionElec").Value))
100: chkProjetElec.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ProjetElec").Value))
105: chkInventaireMec.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("InventaireMec").Value))
110: chkInventaireElec.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("InventaireElec").Value))
115: chkAchat.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("Achat").Value))
120: chkModificationFacturation.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationFacturation").Value))
125: chkModificationClients.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationClients").Value))
130: chkModificationFRS.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationFournisseurs").Value))
135: chkModificationContacts.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationContacts").Value))
140: chkModificationEmployes.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationEmployes").Value))
145: chkModificationGroupes.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationGroupes").Value))
150: chkModificationFeuillesTemps.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationFeuillesTemps").Value))
155: chkModificationOutils.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationOutils").Value))
160: chkModificationSoumissionMec.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationSoumissionsMec").Value))
165: chkModificationProjetMec.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationProjetsMec").Value))
170: chkModificationSoumissionElec.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationSoumissionsElec").Value))
175: chkModificationProjetElec.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationProjetsElec").Value))
180: chkModificationBonsCommandes.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationBonsCommandes").Value))
185: chkModificationCatalogueElec.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationCatalogueElec").Value))
190: chkModificationCatalogueMec.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationCatalogueMec").Value))
195: chkModificationInventaireMec.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationInventaireMec").Value))
200: chkModificationInventaireElec.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationInventaireElec").Value))
205: chkModificationPunchEmployes.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationPunchEmployes").Value))
210: chkSupprimerProjets.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("SuppressionProjets").Value))
215: chkReception.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationReception").Value))
220: chkRetourMarchandise.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ModificationRetourMarchandise").Value))
225: chkMailingList.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("ListeDistribution").Value))
230: chkPunchSemaineAnterieure.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("PunchSemaineAntérieure").Value))
235: chkVerrouillageTempsProjet.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("VerrouillageTempsProjet").Value))
240: chkDeverrouillageTempsProjet.CheckState = System.Math.Abs(CShort(rstGroupes.Fields("DéverrouillageTempsProjet").Value))
		
245: Call rstGroupes.Close()
250: 'UPGRADE_NOTE: Object rstGroupes may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstGroupes = Nothing
		
255: Call AfficherUtilisateurs()
		
260: Exit Sub
		
AfficherErreur: 
		
265: Call AfficherErreur("frmGroupes", "AfficherGroupe", Err, Erl())
	End Sub
	
	Private Sub AfficherUtilisateurs()
		
5: On Error GoTo AfficherErreur
		
		'Affiche les utilisateurs compris dans le groupe
10: Dim rstEmployes As ADODB.Recordset
		
		'Vide la liste
15: Call lstUser.Items.Clear()
		
20: rstEmployes = New ADODB.Recordset
		
25: Call rstEmployes.Open("SELECT * FROM GRB_employés WHERE Groupe = " & VB6.GetItemData(cmbGroupe, cmbGroupe.SelectedIndex) & " AND Actif = true ORDER BY employe", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
30: Do While Not rstEmployes.EOF
			'Ajout du nom de l'employé dans la liste
35: Call lstUser.Items.Add(rstEmployes.Fields("employe").Value)
			
40: Call rstEmployes.MoveNext()
45: Loop 
		
50: Call rstEmployes.Close()
55: 'UPGRADE_NOTE: Object rstEmployes may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmployes = Nothing
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmGroupes", "AfficherUtilisateurs", Err, Erl())
	End Sub
	
	Private Sub UncheckedAll()
		
5: On Error GoTo AfficherErreur
		
		'Enlève tous les crochets des checkbox
10: Dim objControl As Object
		
15: For	Each objControl In Me.Controls
20: If TypeOf objControl Is System.Windows.Forms.CheckBox Then
25: 'UPGRADE_WARNING: Couldn't resolve default property of object objControl.Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				objControl.Value = System.Windows.Forms.CheckState.Unchecked
30: End If
35: Next objControl
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmGroupes", "UncheckedAll", Err, Erl())
	End Sub
End Class