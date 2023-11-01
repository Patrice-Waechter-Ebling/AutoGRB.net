Option Strict Off
Option Explicit On
Friend Class frmemploye
	Inherits System.Windows.Forms.Form
	
	Private Enum enumMode
		MODE_AJOUT = 0
		MODE_MODIF = 1
		MODE_MODIF_NON_AUTORISE = 2
		MODE_INACTIF = 3
	End Enum
	
	Private m_bModeAjouter As Boolean 'Mode ajouter ou non(modifié)
	Private m_iNoEmploye As Short
	Private m_bModifEmploye As Boolean
	
	'UPGRADE_WARNING: Event cmbemploye.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbemploye_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbemploye.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''
		'affiche employé sélectioné'
		''''''''''''''''''''''''''''
		
		'Set du numéro d'employé
10: m_iNoEmploye = VB6.GetItemData(cmbEmploye, cmbEmploye.SelectedIndex)
		
		'Affiche l'employé sélectionné
15: Call AfficherEmploye()
		
		'Si l'employé sélectionné est le même que celui qui s'est loggé
		'la modification est permise
20: If UCase(txtuserid.Text) = UCase(g_sUserID) Then
25: cmdmodifier.Enabled = True
30: Else
			'Sinon, elle ne l'est pas, il faut ré-activer les boutons selon le groupe
35: Call ActiverBoutonsGroupe()
40: End If
		
45: txtemployé.Text = cmbEmploye.Text
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmemploye", "cmbemploye_Click", Err, Erl())
	End Sub
	
	Private Sub RemplirComboGroupe()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des groupes de sécurité
10: Dim rstGroupe As ADODB.Recordset
15: Dim iCompteur As Short
		
		'Il faut vider le groupe avant de le remplir
20: Call cmbGroupe.Items.Clear()
		
		'Ouverture de la table GRB_Groupes
25: rstGroupe = New ADODB.Recordset
		
30: Call rstGroupe.Open("SELECT * FROM GRB_Groupes", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
35: Do While Not rstGroupe.EOF
			'Ajout du nom du groupe dans le combo
40: Call cmbGroupe.Items.Add(rstGroupe.Fields("NomGroupe").Value)
			
			'Ajout du numéro de groupe dans l'ItemData du combo
45: 'UPGRADE_ISSUE: ComboBox property cmbGroupe.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbGroupe, cmbGroupe.NewIndex, rstGroupe.Fields("IDGroupe").Value)
			
			'Si c'est en mode ajout
50: If m_bModeAjouter = True Then
				'On sélectionne le groupe "Par défaut".. par défaut
55: 'UPGRADE_ISSUE: ComboBox property cmbGroupe.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				If VB6.GetItemString(cmbGroupe, cmbGroupe.NewIndex) = S_GROUPE_DEFAUT Then
60: 'UPGRADE_ISSUE: ComboBox property cmbGroupe.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
					cmbGroupe.SelectedIndex = cmbGroupe.NewIndex
65: End If
70: End If
			
75: Call rstGroupe.MoveNext()
80: Loop 
		
85: Call rstGroupe.Close()
90: 'UPGRADE_NOTE: Object rstGroupe may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstGroupe = Nothing
		
95: Exit Sub
		
AfficherErreur: 
		
100: Call AfficherErreur("frmemploye", "RemplirComboGroupe", Err, Erl())
	End Sub
	
	Private Sub RemplirComboFamille()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des Familles de sécurité
10: Dim rstFamille As ADODB.Recordset
15: Dim iCompteur As Short
		
		'Il faut vider le Famille avant de le remplir
20: Call cmbFamille.Items.Clear()
		
		'Ouverture de la table GRB_Familles
25: rstFamille = New ADODB.Recordset
		
30: Call rstFamille.Open("SELECT * FROM GRB_Famille ORDER BY Famille", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
35: Do While Not rstFamille.EOF
			'Ajout du nom du Famille dans le combo
40: Call cmbFamille.Items.Add(rstFamille.Fields("Famille").Value)
			
			'Ajout du numéro de Famille dans l'ItemData du combo
45: 'UPGRADE_ISSUE: ComboBox property cmbFamille.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbFamille, cmbFamille.NewIndex, rstFamille.Fields("IDFamille").Value)
			
50: Call rstFamille.MoveNext()
55: Loop 
		
60: Call rstFamille.Close()
65: 'UPGRADE_NOTE: Object rstFamille may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFamille = Nothing
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmemploye", "RemplirComboFamille", Err, Erl())
	End Sub
	
	Private Sub cmdAjouter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAjouter.Click
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''
		'met en mode ajouter
		'''''''''''''''''''''
10: m_bModeAjouter = True
		
15: Call MontrerControles(enumMode.MODE_AJOUT)
		
20: Call RemplirComboGroupe()
		
25: Call LockedChamps(enumMode.MODE_AJOUT)
		
30: Call ViderChamps()
		
35: Call AfficherMasque()
		
40: txtemployé.Focus()
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmemploye", "cmdAjouter_Click", Err, Erl())
	End Sub
	
	Private Sub AfficherMasque()
		
5: On Error GoTo AfficherErreur
		
10: mskPagette.Text = txtpage.Text
15: mskTelephone.Text = txtTel.Text
20: mskCellulaire.Text = txtCell.Text
		
25: txtpage.Visible = False
30: mskPagette.Visible = True
		
35: txtTel.Visible = False
40: mskTelephone.Visible = True
		
45: txtCell.Visible = False
50: mskCellulaire.Visible = True
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmemploye", "AfficherMasque", Err, Erl())
	End Sub
	
	Private Sub CacherMasque()
		
5: On Error GoTo AfficherErreur
		
10: txtpage.Text = mskPagette.Text
15: txtTel.Text = mskTelephone.Text
20: txtCell.Text = mskCellulaire.Text
		
25: txtpage.Visible = True
30: mskPagette.Visible = False
		
35: txtTel.Visible = True
40: mskTelephone.Visible = False
		
45: txtCell.Visible = True
50: mskCellulaire.Visible = False
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmemploye", "CacherMasque", Err, Erl())
	End Sub
	
	Private Sub ViderChamps()
		
5: On Error GoTo AfficherErreur
		
		'Vide les champs
10: txtemployé.Text = vbNullString
15: txtuserid.Text = vbNullString
20: txtpasswd.Text = vbNullString
25: txtconfirme.Text = vbNullString
30: txtinitiale.Text = vbNullString
35: txtCell.Text = vbNullString
40: txtpage.Text = vbNullString
45: txtTel.Text = vbNullString
		
50: cmbFamille.SelectedIndex = -1
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmemploye", "ViderChamps", Err, Erl())
	End Sub
	
	Private Sub LockedChamps(ByVal eMode As enumMode)
		
5: On Error GoTo AfficherErreur
		
		'On barre les champs par rapport à un mode
10: Dim bIDPassTel As Boolean 'Contient le userID, le password ainsi que Cell, Tel et pagette
15: Dim bNomGroupe As Boolean 'Contient le nom et le groupe
20: Dim bFamille As Boolean
25: Dim bInitiales As Boolean 'Contient les initiales
30: Dim bPunch As Boolean
35: Dim bChkPunch As Boolean
40: Dim bChkActif As Boolean
		
45: Select Case eMode
			Case enumMode.MODE_MODIF
50: bInitiales = True
55: bPunch = True
				
60: Case enumMode.MODE_AJOUT
65: bPunch = True
				
70: Case enumMode.MODE_INACTIF
75: bIDPassTel = True
80: bNomGroupe = True
85: bFamille = True
90: bInitiales = True
95: bPunch = True
100: bChkPunch = True
105: bChkActif = True
				
				'Si le user a le droit de modifié ses infos seulement
110: Case enumMode.MODE_MODIF_NON_AUTORISE
115: bNomGroupe = True
120: bInitiales = True
125: bPunch = True
130: bChkPunch = False
135: bChkActif = False
140: End Select
		
145: txtCell.ReadOnly = bIDPassTel
150: txtinitiale.ReadOnly = bInitiales
155: txtpage.ReadOnly = bIDPassTel
160: txtpasswd.ReadOnly = bIDPassTel
165: txtTel.ReadOnly = bIDPassTel
170: txtuserid.ReadOnly = bIDPassTel
175: 'UPGRADE_ISSUE: ComboBox property cmbGroupe.Locked was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		cmbGroupe.Locked = bNomGroupe
180: 'UPGRADE_ISSUE: ComboBox property cmbFamille.Locked was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		cmbFamille.Locked = bFamille
185: txtemployé.ReadOnly = bNomGroupe
190: txtGroupe.ReadOnly = bNomGroupe
195: chkActif.Enabled = Not bChkActif
		
200: Exit Sub
		
AfficherErreur: 
		
205: Call AfficherErreur("frmemploye", "LockedChamps", Err, Erl())
	End Sub
	
	Private Sub MontrerControles(ByVal eMode As enumMode)
		
5: On Error GoTo AfficherErreur
		
		'Met les controles visible/invisible
10: Dim bCmbGroupe As Boolean
15: Dim bCmbFamille As Boolean
20: Dim bCmbEmploye As Boolean
25: Dim bTxtGroupe As Boolean
30: Dim bTxtFamille As Boolean
35: Dim bTxtEmploye As Boolean
40: Dim bAjouter As Boolean
45: Dim bModifier As Boolean
50: Dim bSupprimer As Boolean
55: Dim bEnregistrer As Boolean
60: Dim bAnnuler As Boolean
65: Dim bQuitter As Boolean
70: Dim bGroupe As Boolean
75: Dim bConfirmPwd As Boolean
80: Dim bPunchPour As Boolean
		
85: Select Case eMode
			Case enumMode.MODE_AJOUT, enumMode.MODE_MODIF
90: bTxtEmploye = True
95: bCmbGroupe = True
100: bCmbFamille = True
105: bEnregistrer = True
110: bAnnuler = True
115: bConfirmPwd = True
				
			Case enumMode.MODE_MODIF_NON_AUTORISE
120: bTxtGroupe = True
125: bTxtFamille = True
130: bTxtEmploye = True
135: bEnregistrer = True
140: bAnnuler = True
145: bConfirmPwd = True
150: bPunchPour = True
				
			Case enumMode.MODE_INACTIF
155: bCmbEmploye = True
160: bTxtGroupe = True
165: bTxtFamille = True
170: bAjouter = True
175: bModifier = True
180: bSupprimer = True
185: bQuitter = True
190: bGroupe = True
195: bPunchPour = True
200: End Select
		
205: txtemployé.Visible = bTxtEmploye
210: cmbEmploye.Visible = bCmbEmploye
		
215: txtGroupe.Visible = bTxtGroupe
220: cmbGroupe.Visible = bCmbGroupe
		
225: txtFamille.Visible = bTxtFamille
230: cmbFamille.Visible = bCmbFamille
		
235: cmdajouter.Visible = bAjouter
240: cmdmodifier.Visible = bModifier
245: cmdsupprimer.Visible = bSupprimer
250: cmdFermer.Visible = bQuitter
255: cmdenregistré.Visible = bEnregistrer
260: cmdannuler.Visible = bAnnuler
265: txtconfirme.Visible = bConfirmPwd
		
270: cmdConfig.Enabled = bGroupe
		
275: lblPunchPour.Visible = bPunchPour
280: cmbEmployePunch.Visible = bPunchPour
285: cmdAjoutPunch.Visible = bPunchPour
290: cmdSupprimePunch.Visible = bPunchPour
		
295: Exit Sub
		
AfficherErreur: 
		
300: Call AfficherErreur("frmemploye", "MontrerControles", Err, Erl())
	End Sub
	
	Private Sub cmdAjoutPunch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAjoutPunch.Click
		
5: On Error GoTo AfficherErreur
		
10: Call RemplirComboEmployeActif()
		
15: fraEmploye.Visible = True
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmemploye", "cmdAjoutPunch_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnulEmploye_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnulEmploye.Click
		
5: On Error GoTo AfficherErreur
		
10: fraEmploye.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmemploye", "cmdAnnulEmploye_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: Call MontrerControles(enumMode.MODE_INACTIF)
		
15: Call LockedChamps(enumMode.MODE_INACTIF)
		
20: Call CacherMasque()
		
25: txtemployé.Text = cmbEmploye.Text
		
30: Call AfficherEmploye()
		
35: Call ActiverBoutonsGroupe()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmemploye", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdConfig_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdConfig.Click
		
5: On Error GoTo AfficherErreur
		
		'Affiche le form pour la configuration des groupes
10: Call OuvrirForm(frmGroupes, True)
		
15: Call AfficherEmploye()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmemploye", "cmdConfig_Click", Err, Erl())
	End Sub
	
	Private Sub cmdenregistré_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdenregistré.Click
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''
		' enregistre nouveau employé '
		''''''''''''''''''''''''''''''
10: Dim rstEmploye As ADODB.Recordset
15: Dim rstUserId As ADODB.Recordset
20: Dim sEmploye As String
25: Dim iCompteur As Short
		
30: sEmploye = txtemployé.Text
		
		'si le nom de l'employé, le User ID, le Password et la confirmation du password ne sont pas vide
35: If Trim(txtemployé.Text) <> vbNullString And Trim(txtuserid.Text) <> vbNullString And Trim(txtpasswd.Text) <> vbNullString And Trim(txtconfirme.Text) <> vbNullString And Trim(txtinitiale.Text) <> vbNullString And cmbFamille.SelectedIndex <> -1 Then
			'Si le password et la confirmation sont pareils
40: If txtpasswd.Text = txtconfirme.Text Then
				'Ouverture de la connection
45: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
50: rstEmploye = New ADODB.Recordset
				
				'Si en mode ajouter
55: If m_bModeAjouter = True Then
					'Si le nom de l'employé ne se trouve pas dans le combo
60: If ComboContient(cmbEmploye, txtemployé.Text) = False Then
						'Ouverture du recordset sur la table GRB_Employé
65: Call rstEmploye.Open("SELECT * FROM GRB_employés", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
						
						'tant que c'est pas la fin du recordset
70: Do While Not rstEmploye.EOF
							'Si les initiales sont les meme que l'employé ajouté
75: If rstEmploye.Fields("Initiale").Value = txtinitiale.Text Then
80: Call MsgBox("Ces initiales existent déjà!")
								
85: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
								System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
								
90: Exit Sub
95: End If
							
							'Si le user id existe déjà
100: If UCase(rstEmploye.Fields("loginname").Value) = UCase(txtuserid.Text) Then
105: Call MsgBox("User ID existant!")
								
110: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
								System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
								
115: Exit Sub
120: End If
							
125: Call rstEmploye.MoveNext()
130: Loop 
						
135: Call rstEmploye.AddNew()
140: Else
145: Call MsgBox("Cet employé existe déjà!")
						
150: Exit Sub
155: End If
160: Else
					'Si ce n'est pas un ajout
					
					'Ouverture du recordset sur la table GRB_Employés ou le no d'employe est = à la variable m_iNoEmploye
165: Call rstEmploye.Open("SELECT * FROM GRB_employés WHERE noemploye = " & m_iNoEmploye, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
					'Si le contenu de txtuserid est différent au contenu du champs loginname
170: If txtuserid.Text <> rstEmploye.Fields("loginname").Value Then
						'Si le contenu de txtuserid est différent de g_sUserID
175: If txtuserid.Text <> g_sUserID Then
180: rstUserId = New ADODB.Recordset
							
185: Call rstUserId.Open("SELECT * FROM GRB_employés", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
							
190: Do While Not rstUserId.EOF
								'Si le loginname du recordest est égal au txtuserid
195: If UCase(rstUserId.Fields("loginname").Value) = UCase(txtuserid.Text) Then
200: Call MsgBox("User ID existant!")
									
205: Call rstUserId.Close()
210: 'UPGRADE_NOTE: Object rstUserId may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
									rstUserId = Nothing
									
215: Call rstEmploye.Close()
220: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
									rstEmploye = Nothing
									
225: Exit Sub
230: End If
								
235: Call rstUserId.MoveNext()
240: Loop 
							
245: Call rstUserId.Close()
250: 'UPGRADE_NOTE: Object rstUserId may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
							rstUserId = Nothing
255: End If
260: End If
265: End If
				
270: rstEmploye.Fields("employe").Value = txtemployé.Text
				
				'Si l'employé fait des modif sur lui-même
275: If g_sUserID = rstEmploye.Fields("loginname").Value Then
280: g_sUserID = txtuserid.Text
285: End If
				
290: rstEmploye.Fields("loginname").Value = txtuserid.Text
295: rstEmploye.Fields("passwd").Value = txtpasswd.Text
300: rstEmploye.Fields("initiale").Value = txtinitiale.Text
305: rstEmploye.Fields("Actif").Value = chkActif.CheckState
				
310: If m_bModeAjouter = False Then
315: If chkActif.CheckState = System.Windows.Forms.CheckState.Unchecked Then
320: Call g_connData.Execute("DELETE * FROM GRB_AutorisationPunch WHERE NoEmploye = " & m_iNoEmploye & " OR AutoriserPar = " & m_iNoEmploye)
325: End If
330: End If
				
335: If mskTelephone.Text = vbNullString Then
340: rstEmploye.Fields("tel").Value = " "
345: Else
350: rstEmploye.Fields("tel").Value = mskTelephone.Text
355: End If
				
360: If mskCellulaire.Text = vbNullString Then
365: rstEmploye.Fields("cell").Value = " "
370: Else
375: rstEmploye.Fields("cell").Value = mskCellulaire.Text
380: End If
				
385: If mskPagette.Text = vbNullString Then
390: rstEmploye.Fields("page").Value = " "
395: Else
400: rstEmploye.Fields("page").Value = mskPagette.Text
405: End If
				
				'Celà veut dire que l'utilisateur a le droit de modifier le groupe
410: If cmbGroupe.Visible = True Then
415: rstEmploye.Fields("groupe").Value = VB6.GetItemData(cmbGroupe, cmbGroupe.SelectedIndex)
420: End If
				
425: If cmbFamille.Visible = True Then
430: If cmbFamille.SelectedIndex <> -1 Then
435: rstEmploye.Fields("Famille").Value = VB6.GetItemData(cmbFamille, cmbFamille.SelectedIndex)
440: End If
445: End If
				
450: Call rstEmploye.Update()
				
455: Call rstEmploye.Close()
460: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstEmploye = Nothing
				
465: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
				
470: Call MontrerControles(enumMode.MODE_INACTIF)
				
475: Call LockedChamps(enumMode.MODE_INACTIF)
				
480: Call ActiverBoutonsGroupe()
				
				'remplis combo
485: Call RemplirComboEmploye()
				
490: Call RemplirComboEmployeActif()
				
495: For iCompteur = 0 To cmbEmploye.Items.Count
500: If VB6.GetItemString(cmbEmploye, iCompteur) = sEmploye Then
505: cmbEmploye.SelectedIndex = iCompteur
						
510: Exit For
515: End If
520: Next 
				
525: m_bModeAjouter = False
530: Else
535: Call MsgBox("Le mot de passe est incorrect!")
540: End If
			
545: Call CacherMasque()
550: Else
555: Call MsgBox("Champs vide!")
560: End If
		
565: Exit Sub
		
AfficherErreur: 
		
570: Call AfficherErreur("frmemploye", "cmdenregistré_Click", Err, Erl())
	End Sub
	
	Private Sub cmdModifier_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdModifier.Click
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''
		'met en mode modifier
		'''''''''''''''''''''
10: Call AfficherMasque()
		
		'Si le user a le droit de modifier les autres user
15: If m_bModifEmploye = True Then
20: Call MontrerControles(enumMode.MODE_MODIF)
25: Call RemplirComboGroupe()
			
30: If txtGroupe.Text <> "" Then
35: cmbGroupe.Text = txtGroupe.Text
40: Else
45: cmbGroupe.SelectedIndex = -1
50: End If
			
55: If txtFamille.Text <> "" Then
60: cmbFamille.Text = txtFamille.Text
65: Else
70: cmbFamille.SelectedIndex = -1
75: End If
			
80: Call LockedChamps(enumMode.MODE_MODIF)
85: Else
90: Call MontrerControles(enumMode.MODE_MODIF_NON_AUTORISE)
95: Call LockedChamps(enumMode.MODE_MODIF_NON_AUTORISE)
100: End If
		
105: txtconfirme.Text = txtpasswd.Text
110: m_bModeAjouter = False
		
115: Exit Sub
		
AfficherErreur: 
		
120: Call AfficherErreur("frmemploye", "cmdModifier_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmemploye", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstAutorisation As ADODB.Recordset
		
15: rstAutorisation = New ADODB.Recordset
		
20: Call rstAutorisation.Open("SELECT * FROM GRB_AutorisationPunch", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: Call rstAutorisation.AddNew()
		
30: rstAutorisation.Fields("NoEmploye").Value = VB6.GetItemData(cmbAjoutEmploye, cmbAjoutEmploye.SelectedIndex)
35: rstAutorisation.Fields("AutoriserPar").Value = VB6.GetItemData(cmbEmploye, cmbEmploye.SelectedIndex)
		
40: Call rstAutorisation.Update()
		
45: Call rstAutorisation.Close()
50: 'UPGRADE_NOTE: Object rstAutorisation may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAutorisation = Nothing
		
55: Call RemplirComboEmployePunch()
		
60: fraEmploye.Visible = False
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmemploye", "cmdOK_Click", Err, Erl())
	End Sub
	
	Private Sub cmdSupprimePunch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSupprimePunch.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iEmploye As Short
15: Dim iPunch As Short
		
20: If cmbEmployePunch.Items.Count > 0 Then
25: iEmploye = VB6.GetItemData(cmbEmploye, cmbEmploye.SelectedIndex)
30: iPunch = VB6.GetItemData(cmbEmployePunch, cmbEmployePunch.SelectedIndex)
			
35: If cmbEmployePunch.SelectedIndex > -1 Then
40: If MsgBox("Êtes vous sûr de vouloir supprimer cet employé?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
45: Call g_connData.Execute("DELETE * FROM GRB_AutorisationPunch WHERE NoEmploye = " & iPunch & " AND AutoriserPar = " & iEmploye)
50: End If
				
55: Call RemplirComboEmployePunch()
60: End If
65: End If
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmemploye", "cmdSupprimePunch_Click", Err, Erl())
	End Sub
	
	Private Sub cmdSupprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSupprimer.Click
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''''''''''''''''
		'supprime employé
		''''''''''''''''''''''''''''''
10: Dim rstProjSoum As ADODB.Recordset
15: Dim rstFT As ADODB.Recordset
20: Dim sTampon As String
		
25: If cmbEmploye.Items.Count > 0 Then
			'si on veut supprimer
30: If MsgBox("Etes-vous sur de supprimer cet enregistrement?", MsgBoxStyle.YesNo, "Supprimer") = MsgBoxResult.Yes Then
35: rstFT = New ADODB.Recordset
				
40: Call rstFT.Open("SELECT * FROM GRB_Punch WHERE NoEmploye = " & m_iNoEmploye, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
45: If rstFT.EOF Then
50: rstProjSoum = New ADODB.Recordset
					
55: Call rstProjSoum.Open("SELECT * FROM GRB_Soumission_Modif WHERE NoEmployé = " & m_iNoEmploye, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
60: If rstProjSoum.EOF Then
65: Call rstProjSoum.Close()
						
70: Call rstProjSoum.Open("SELECT * FROM GRB_Projet_Modif WHERE NoEmployé = " & m_iNoEmploye, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
						
75: If rstProjSoum.EOF Then
							'delete employe
80: Call g_connData.Execute("DELETE * FROM GRB_employés WHERE noemploye = " & m_iNoEmploye)
							
85: Call rstProjSoum.Close()
90: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
							rstProjSoum = Nothing
							
95: Call rstFT.Close()
100: 'UPGRADE_NOTE: Object rstFT may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
							rstFT = Nothing
							
105: Call RemplirComboEmploye()
							
110: If cmbEmploye.Items.Count > 0 Then
115: cmbEmploye.SelectedIndex = 0
120: End If
125: Else
130: Call MsgBox("Impossible d'effacer cet employé, il est utilisé dans le projet " & rstProjSoum.Fields("IDProjet").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
							
135: Call rstProjSoum.Close()
140: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
							rstProjSoum = Nothing
145: End If
150: Else
155: Call MsgBox("Impossible d'effacer cet employé, il est utilisé dans la soumission " & rstProjSoum.Fields("IDSoumission").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
						
160: Call rstProjSoum.Close()
165: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						rstProjSoum = Nothing
170: End If
175: Else
180: Call MsgBox("Impossible d'effacer cet employé, il est utilisé dans les feuilles de temps pour le projet " & rstFT.Fields("NoProjet").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
					
185: Call rstFT.Close()
190: 'UPGRADE_NOTE: Object rstFT may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstFT = Nothing
195: End If
200: End If
205: End If
		
210: Exit Sub
		
AfficherErreur: 
		
215: Call AfficherErreur("frmemploye", "cmdSupprimer_Click", Err, Erl())
	End Sub
	
	Private Sub frmemploye_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
		'remplis combo employe
10: Call RemplirComboEmploye()
		
15: Call RemplirComboFamille()
		
20: Call MontrerControles(enumMode.MODE_INACTIF)
		
25: Call LockedChamps(enumMode.MODE_INACTIF)
		
30: Call ActiverBoutonsGroupe()
		
		'selectionne dans combo employe
35: If cmbEmploye.Items.Count >= 0 Then
40: cmbEmploye.SelectedIndex = 0
45: End If
		
50: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmemploye", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub ActiverBoutonsGroupe()
		
5: On Error GoTo AfficherErreur
		
		'Activation des boutons selon le groupe
10: m_bModifEmploye = g_bModificationEmployes
		
15: cmdajouter.Enabled = m_bModifEmploye
20: cmdmodifier.Enabled = m_bModifEmploye
25: cmdsupprimer.Enabled = m_bModifEmploye
		
30: cmdConfig.Enabled = g_bModificationGroupes
		
35: cmdAjoutPunch.Enabled = g_bModificationPunchEmployes
40: cmdSupprimePunch.Enabled = g_bModificationPunchEmployes
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmemploye", "ActiverBoutonsGroupe", Err, Erl())
	End Sub
	
	Private Sub AfficherEmploye()
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''''''''''''''
		' affiche donne de l'employé selectionné '
		''''''''''''''''''''''''''''''''''''''''''
10: Dim rstEmploye As ADODB.Recordset
15: Dim rstGroupe As ADODB.Recordset
20: Dim rstFamille As ADODB.Recordset
		
25: rstEmploye = New ADODB.Recordset
		
30: Call rstEmploye.Open("SELECT * FROM GRB_employés WHERE NoEmploye = " & m_iNoEmploye, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'REMPLIS LES CHAMPS
35: If Not rstEmploye.EOF Then
40: txtpasswd.Text = rstEmploye.Fields("passwd").Value
45: txtuserid.Text = rstEmploye.Fields("loginname").Value
50: txtinitiale.Text = rstEmploye.Fields("initiale").Value
			
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstEmploye.Fields("groupe").Value) Then
60: txtGroupe.Text = vbNullString
65: Else
70: rstGroupe = New ADODB.Recordset
				
75: Call rstGroupe.Open("SELECT * FROM GRB_Groupes WHERE IDGroupe = " & rstEmploye.Fields("Groupe").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
80: txtGroupe.Text = rstGroupe.Fields("NomGroupe").Value
				
85: Call rstGroupe.Close()
90: 'UPGRADE_NOTE: Object rstGroupe may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstGroupe = Nothing
95: End If
			
100: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstEmploye.Fields("Famille").Value) Then
105: txtFamille.Text = vbNullString
110: Else
115: rstFamille = New ADODB.Recordset
				
120: Call rstFamille.Open("SELECT * FROM GRB_Famille WHERE IDFamille = " & rstEmploye.Fields("Famille").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
125: txtFamille.Text = rstFamille.Fields("Famille").Value
				
130: Call rstFamille.Close()
135: 'UPGRADE_NOTE: Object rstFamille may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstFamille = Nothing
140: End If
			
145: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstEmploye.Fields("cell").Value) Then
150: txtCell.Text = vbNullString
155: Else
160: txtCell.Text = Trim(rstEmploye.Fields("cell").Value)
165: End If
			
170: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstEmploye.Fields("Page").Value) Then
175: txtpage.Text = vbNullString
180: Else
185: txtpage.Text = Trim(rstEmploye.Fields("Page").Value)
190: End If
			
195: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstEmploye.Fields("tel").Value) Then
200: txtTel.Text = vbNullString
205: Else
210: txtTel.Text = Trim(rstEmploye.Fields("tel").Value)
215: End If
			
220: chkActif.CheckState = System.Math.Abs(CShort(rstEmploye.Fields("Actif").Value))
			
225: Call RemplirComboEmployePunch()
230: End If
		
235: Call rstEmploye.Close()
240: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
245: Exit Sub
		
AfficherErreur: 
		
250: Call AfficherErreur("frmemploye", "AfficherEmploye", Err, Erl())
	End Sub
	
	Private Sub RemplirComboEmployePunch()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmployePunch As ADODB.Recordset
15: Dim rstEmploye As ADODB.Recordset
		
20: Call cmbEmployePunch.Items.Clear()
		
25: rstEmployePunch = New ADODB.Recordset
		
30: Call rstEmployePunch.Open("SELECT * FROM GRB_AutorisationPunch WHERE AutoriserPar = " & VB6.GetItemData(cmbEmploye, cmbEmploye.SelectedIndex), g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
35: rstEmploye = New ADODB.Recordset
		
40: Do While Not rstEmployePunch.EOF
45: Call rstEmploye.Open("SELECT Employe, NoEmploye FROM GRB_Employés WHERE NoEmploye = " & rstEmployePunch.Fields("NoEmploye").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
50: Call cmbEmployePunch.Items.Add(rstEmploye.Fields("Employe").Value)
			
55: 'UPGRADE_ISSUE: ComboBox property cmbEmployePunch.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbEmployePunch, cmbEmployePunch.NewIndex, rstEmploye.Fields("NoEmploye").Value)
			
60: Call rstEmploye.Close()
			
65: Call rstEmployePunch.MoveNext()
70: Loop 
		
75: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
80: If cmbEmployePunch.Items.Count > 0 Then
85: cmbEmployePunch.SelectedIndex = 0
90: End If
		
95: Call rstEmployePunch.Close()
100: 'UPGRADE_NOTE: Object rstEmployePunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmployePunch = Nothing
		
105: Exit Sub
		
AfficherErreur: 
		
110: Call AfficherErreur("frmemploye", "RemplirComboEmployePunch", Err, Erl())
	End Sub
	
	Private Sub RemplirComboEmploye()
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''''''
		'rempli le combo employé'
		'''''''''''''''''''''''''
10: Dim rstEmploye As ADODB.Recordset
		
15: rstEmploye = New ADODB.Recordset
		
20: Call rstEmploye.Open("SELECT * FROM GRB_employés ORDER BY employe", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: Call cmbEmploye.Items.Clear()
		
		'remplis le combo employé
30: Do While Not rstEmploye.EOF
35: Call cmbEmploye.Items.Add(rstEmploye.Fields("employe").Value)
			
40: 'UPGRADE_ISSUE: ComboBox property cmbEmploye.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbEmploye, cmbEmploye.NewIndex, rstEmploye.Fields("noEmploye").Value)
			
45: Call rstEmploye.MoveNext()
50: Loop 
		
55: Call rstEmploye.Close()
60: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmemploye", "RemplirComboEmploye", Err, Erl())
	End Sub
	
	Private Sub RemplirComboEmployeActif()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmploye As ADODB.Recordset
15: Dim iCompteur As Short
20: Dim iCompteur2 As Short
25: Dim bSupprimer As Boolean
		
30: rstEmploye = New ADODB.Recordset
		
35: Call rstEmploye.Open("SELECT * FROM GRB_employés WHERE Actif = true ORDER BY employe", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
40: Call cmbAjoutEmploye.Items.Clear()
		
		'rempli le combo employé
45: Do While Not rstEmploye.EOF
50: Call cmbAjoutEmploye.Items.Add(rstEmploye.Fields("employe").Value)
			
55: 'UPGRADE_ISSUE: ComboBox property cmbAjoutEmploye.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbAjoutEmploye, cmbAjoutEmploye.NewIndex, rstEmploye.Fields("noEmploye").Value)
			
60: Call rstEmploye.MoveNext()
65: Loop 
		
70: Call rstEmploye.Close()
75: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
80: iCompteur = 0
		
		'Il faut enlever les employés déjà dans le combo et l'employé en cours
85: Do While iCompteur <= cmbAjoutEmploye.Items.Count - 1
90: bSupprimer = False
			
			'Si c'est l'employé en cours
95: If VB6.GetItemString(cmbAjoutEmploye, iCompteur) = cmbEmploye.Text Then
100: bSupprimer = True
105: Else
110: iCompteur2 = 0
				
				'Si c'est les employés dans le combo
115: Do While iCompteur2 <= cmbEmployePunch.Items.Count - 1
120: If VB6.GetItemString(cmbEmployePunch, iCompteur2) = VB6.GetItemString(cmbAjoutEmploye, iCompteur) Then
125: bSupprimer = True
130: End If
					
135: iCompteur2 = iCompteur2 + 1
140: Loop 
145: End If
			
150: If bSupprimer = True Then
155: Call cmbAjoutEmploye.Items.RemoveAt(iCompteur)
160: Else
165: iCompteur = iCompteur + 1
170: End If
175: Loop 
		
180: If cmbAjoutEmploye.Items.Count > 0 Then
185: cmbAjoutEmploye.SelectedIndex = 0
190: End If
		
195: Exit Sub
		
AfficherErreur: 
		
200: Call AfficherErreur("frmemploye", "RemplirComboEmployeActif", Err, Erl())
	End Sub
	
	Private Sub mskCellulaire_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskCellulaire.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskCellulaire.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmemploye", "mskCellulaire_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskPagette_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskPagette.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskPagette.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmemploye", "mskPagette_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskTelephone_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskTelephone.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskTelephone.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmemploye", "mskTelephone_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskCellulaire_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskCellulaire.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskCellulaire.Mask = vbNullString
		
15: If mskCellulaire.Text = "(___) ___-____" Then
20: mskCellulaire.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmemploye", "mskCellulaire_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskPagette_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskPagette.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskPagette.Mask = vbNullString
		
15: If mskPagette.Text = "(___) ___-____" Then
20: mskPagette.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmemploye", "mskPagette_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskTelephone_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskTelephone.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskTelephone.Mask = vbNullString
		
15: If mskTelephone.Text = "(___) ___-____" Then
20: mskTelephone.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmemploye", "mskTelephone_LostFocus", Err, Erl())
	End Sub
End Class