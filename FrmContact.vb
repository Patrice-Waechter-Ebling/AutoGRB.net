Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class FrmContact
	Inherits System.Windows.Forms.Form
	
	Private Enum enumMode
		MODE_AJOUT_MODIF = 0
		MODE_INACTIF = 1
	End Enum
	
	Private m_bModeAjout As Boolean
	Private m_bRenommer As Boolean
	Private m_iNoContact As Short
	
	Public m_bAnnulerDistList As Boolean
	Public m_otlDistList As Outlook.DistListItem
	
	Private Sub RemplirComboContact()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des contacts
10: Dim rstContact As ADODB.Recordset
		
		'Ouverture de la table
15: rstContact = New ADODB.Recordset
		
20: Call rstContact.Open("SELECT NomContact, Compagnie, IDContact FROM GRB_Contact WHERE Supprimé = False", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Il faut vider le combo avant de le remplir
25: Call cmbcontact.Items.Clear()
		
		'Tant que ce n'est pas la fin des enregistrements
30: Do While Not rstContact.EOF
			'Ajout du nom du contact dans le combo
35: Call cmbcontact.Items.Add(rstContact.Fields("NomContact").Value & " - " & rstContact.Fields("Compagnie").Value)
			
			'Ajout du numéro du contact dans l'itemData du combo
40: 'UPGRADE_ISSUE: ComboBox property cmbcontact.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbcontact, cmbcontact.NewIndex, rstContact.Fields("IDContact").Value)
			
45: Call rstContact.MoveNext()
50: Loop 
		
55: Call rstContact.Close()
60: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
65: If cmbcontact.Items.Count > 0 Then
70: cmbcontact.SelectedIndex = 0
75: End If
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmContact", "RemplirComboContact", Err, Erl())
	End Sub
	
	Private Sub EnregistrerContact()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstContact As ADODB.Recordset
		
15: rstContact = New ADODB.Recordset
		
20: If m_bModeAjout = True Then
25: Call rstContact.Open("SELECT * FROM GRB_Contact", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
30: Call rstContact.AddNew()
			
35: rstContact.Fields("DateCréation").Value = ConvertDate(Today)
40: rstContact.Fields("UserCréation").Value = g_sInitiale
45: Else
50: Call rstContact.Open("SELECT * FROM GRB_contact WHERE IDContact = " & m_iNoContact, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
55: rstContact.Fields("DateModification").Value = ConvertDate(Today)
60: rstContact.Fields("UserModification").Value = g_sInitiale
65: End If
		
		'Enregistrement du contact
70: rstContact.Fields("NomContact").Value = txtNomContact.Text
75: rstContact.Fields("Compagnie").Value = txtCompagnie.Text
80: rstContact.Fields("Titre").Value = txtTitre.Text
85: rstContact.Fields("Telephonne").Value = mskTelephone.Text
90: rstContact.Fields("Fax").Value = mskFax.Text
95: rstContact.Fields("Pagette").Value = mskPagette.Text
100: rstContact.Fields("Cellulaire").Value = mskCellulaire.Text
105: rstContact.Fields("E-mail").Value = txtEmail.Text
110: rstContact.Fields("NoPoste").Value = txtPoste.Text
115: rstContact.Fields("TelDomicile").Value = mskTelDomicile.Text
120: rstContact.Fields("Commentaire").Value = txtcommentaire.Text
		
125: rstContact.Fields("EntryIDOutlook").Value = ModifierContactExchange(rstContact.Fields("IDContact").Value)
		
130: If m_bModeAjout = True Then
135: m_bModeAjout = False
140: End If
		
145: Call rstContact.Update()
		
150: Call rstContact.Close()
155: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
160: Exit Sub
		
AfficherErreur: 
		
165: Call AfficherErreur("frmContact", "EnregistrerContact", Err, Erl())
	End Sub
	
	Private Function ModifierContactExchange(ByVal iContactID As Short) As String
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim otlContact As Outlook.ContactItem
20: Dim folContact As Outlook.MAPIFolder
25: Dim bDejaOuvert As Boolean
30: Dim sNom() As String
		
35: If m_bModeAjout = True Then
40: lblEtatOutlook.Text = "Ajout du contact dans Outlook ..."
45: Else
50: lblEtatOutlook.Text = "Modification du contact dans Outlook ..."
55: End If
		
60: fraEtatOutlook.Visible = True
		
65: otlApp = OuvrirOutlook(bDejaOuvert)
		
70: folContact = GetFolder(otlApp, "Contacts GRB")
		
75: If m_bModeAjout = True Then
80: otlContact = folContact.Items.Add(Outlook.OlItemType.olContactItem)
			
85: otlContact.User1 = CStr(iContactID)
90: Else
95: otlContact = folContact.Items.Find("[User1] = " & iContactID)
100: End If
		
105: If otlContact Is Nothing Then
110: Call MsgBox("Le contact " & txtNomContact.Text & " n'a pas été trouvé pour la mise à jour Exchange!", MsgBoxStyle.OKOnly, "Erreur")
			
115: fraEtatOutlook.Visible = False
			
120: System.Windows.Forms.Application.DoEvents()
			
125: Exit Function
130: End If
		
135: sNom = Split(Trim(txtNomContact.Text), " ")
		
140: Select Case UBound(sNom)
			Case 0
145: otlContact.FirstName = sNom(0)
				
			Case 1
150: otlContact.FirstName = sNom(0)
155: otlContact.LastName = sNom(1)
				
			Case 2
160: otlContact.FirstName = sNom(0)
165: otlContact.MiddleName = sNom(1)
170: otlContact.LastName = sNom(2)
175: End Select
		
180: otlContact.Title = ""
		
185: otlContact.CompanyName = txtCompagnie.Text
190: otlContact.JobTitle = txtTitre.Text
		
195: If mskTelephone.Text <> "(___) ___-____" Then
200: If Trim(txtPoste.Text) <> "" Then
205: otlContact.BusinessTelephoneNumber = mskTelephone.Text & " Ext : " & txtPoste.Text
210: Else
215: otlContact.BusinessTelephoneNumber = mskTelephone.Text
220: End If
225: End If
		
230: If mskFax.Text <> "(___) ___-____" Then
235: otlContact.BusinessFaxNumber = mskFax.Text
240: End If
		
245: If mskCellulaire.Text <> "(___) ___-____" Then
250: otlContact.MobileTelephoneNumber = mskCellulaire.Text
255: End If
		
260: If mskPagette.Text <> "(___) ___-____" Then
265: otlContact.PagerNumber = mskPagette.Text
270: End If
		
275: otlContact.Email1Address = txtEmail.Text
		
280: If mskTelDomicile.Text <> "(___) ___-____" Then
285: otlContact.HomeTelephoneNumber = mskTelDomicile.Text
290: End If
		
295: If txtcommentaire.Text <> "" Then
300: otlContact.Body = txtcommentaire.Text
305: End If
		
310: Call otlContact.Save()
		
315: ModifierContactExchange = otlContact.EntryID
		
320: If bDejaOuvert = False Then
325: Call otlApp.Quit()
330: End If
		
335: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		otlApp = Nothing
		
340: fraEtatOutlook.Visible = False
		
345: System.Windows.Forms.Application.DoEvents()
		
350: Exit Function
		
AfficherErreur: 
		
355: Call AfficherErreur("frmContact", "ModifierContactExchange", Err, Erl(), "iContactID = " & iContactID)
		
360: fraEtatOutlook.Visible = False
	End Function
	
	Private Sub SupprimerContactExchange(ByVal iContactID As Short)
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim otlContact As Outlook.ContactItem
20: Dim folContact As Outlook.MAPIFolder
25: Dim bDejaOuvert As Boolean
		
30: lblEtatOutlook.Text = "Suppression du contact dans Outlook ..."
35: fraEtatOutlook.Visible = True
		
40: otlApp = OuvrirOutlook(bDejaOuvert)
		
45: folContact = GetFolder(otlApp, "Contacts GRB")
		
50: otlContact = folContact.Items.Find("[User1] = " & iContactID)
		
55: If Not otlContact Is Nothing Then
60: Call otlContact.Delete()
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
		
105: Call AfficherErreur("frmContact", "SupprimerContactExchange", Err, Erl())
		
110: fraEtatOutlook.Visible = False
	End Sub
	
	Private Sub cmdCopier_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCopier.Click
		
5: On Error GoTo AfficherErreur
		
		'Copie un contact
10: Dim sName As String
15: Dim bAjouter As Boolean
		
		'On procede a la saisie du nom et du contact
20: sName = InputBox("Veuillez entrer le nom du contact", "SAISIE DU NOM", "Nom du contact")
		
25: If sName <> vbNullString Then
30: If ExisteDansBD(sName) = True Then
35: If MsgBox("Il y a déjà un contact portant ce nom!" & vbNewLine & "Voulez-vous l'ajouter quand même?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
40: bAjouter = True
45: Else
50: bAjouter = False
55: End If
60: Else
65: If ContientCaracteresIncorrects(sName) = True Then
70: Call MsgBox("Il y a des caractères non permis!", MsgBoxStyle.OKOnly, "Erreur")
					
75: bAjouter = False
80: Else
85: bAjouter = True
90: End If
95: End If
100: Else
105: bAjouter = False
110: End If
		
115: If bAjouter = True Then
120: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
			'On montre seulement les boutton pour enregistrer
125: Call AfficherControles(enumMode.MODE_AJOUT_MODIF)
			
			'On montre les maskEdBox
130: Call HideEdMask(False)
			
135: m_bModeAjout = True
			
			'On affiche le nom du nouveau client dans le textbox
			'pour éviter le ScrollDown durant l'ajout
			
140: txtNomContact.Text = sName
			
145: Call ViderBarrerChamps(False, False)
			
150: Call txtCompagnie.Focus()
			
155: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
160: End If
		
165: Exit Sub
		
AfficherErreur: 
		
170: Call AfficherErreur("frmContact", "cmdCopier_Click", Err, Erl())
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
		
65: Call AfficherErreur("frmContact", "ExisteDansBD", Err, Erl())
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
		
40: Call AfficherErreur("frmContact", "ContientCaracteresIncorrects", Err, Erl())
	End Function
	
	Private Sub cmdFax_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFax.Click
		
5: On Error GoTo AfficherErreur
		
10: If cmbcontact.Items.Count > 0 Then
15: Call frmreport.Afficher(0, m_iNoContact, frmreport.enumForm.FRM_CONTACTS)
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmContact", "cmdFax_Click", Err, Erl())
	End Sub
	
	Private Sub cmdMailList_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMailList.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim folContact As Outlook.MAPIFolder
20: Dim itmContact As Outlook.ContactItem
25: Dim otlRecipient As Outlook.Recipient
30: Dim bDejaOuvert As Boolean
35: Dim rstContact As ADODB.Recordset
40: Dim sIDContact As String
45: Dim sContact As String
		
50: If cmbcontact.SelectedIndex <> -1 Then
55: If Trim(txtEmail.Text) <> "" Then
60: sIDContact = CStr(VB6.GetItemData(cmbcontact, cmbcontact.SelectedIndex))
65: sContact = cmbcontact.Text
70: End If
			
75: If sIDContact <> "" Then
80: otlApp = OuvrirOutlook(bDejaOuvert)
				
85: lblEtatOutlook.Text = "Recherche des listes de distribution..."
				
90: fraEtatOutlook.Visible = True
				
95: Call frmChoixMailList.Afficher(Me, otlApp)
				
100: If m_bAnnulerDistList = False Then
105: lblEtatOutlook.Text = "Ajout du contact dans la liste de distribution..."
					
110: fraEtatOutlook.Visible = True
					
115: folContact = GetFolder(otlApp, "Contacts GRB")
					
120: itmContact = folContact.Items.Find("[User1] = " & sIDContact)
					
125: If Not itmContact Is Nothing Then
130: otlRecipient = otlApp.Session.CreateRecipient(itmContact.Email1DisplayName)
						
135: If otlRecipient.Resolve = True Then
140: Call m_otlDistList.AddMember(otlRecipient)
							
145: Call m_otlDistList.Save()
150: Else
155: Call MsgBox("Impossible de trouver le contact '" & sContact & "' !", MsgBoxStyle.OKOnly, "Erreur")
160: End If
165: Else
170: Call MsgBox("Contact '" & sContact & "' introuvable!", MsgBoxStyle.OKOnly, "Erreur")
175: End If
180: End If
				
185: If bDejaOuvert = False Then
190: Call otlApp.Quit()
195: End If
				
200: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				otlApp = Nothing
				
205: fraEtatOutlook.Visible = False
210: Else
215: Call MsgBox("Le ou les contacts n'ont pas d'email!", MsgBoxStyle.OKOnly, "Erreur")
220: End If
225: Else
230: Call MsgBox("Aucun contact sélectionné!", MsgBoxStyle.OKOnly, "Erreur")
235: End If
		
240: Exit Sub
		
AfficherErreur: 
		
245: If Err.Number = 287 And Erl() = 145 Then
250: Call MsgBox("La liste de distribution est pleine!", MsgBoxStyle.OKOnly, "Erreur")
255: Else
260: Call AfficherErreur("frmContact", "cmdMailList_Click", Err, Erl())
265: End If
		
270: fraEtatOutlook.Visible = False
	End Sub
	
	Private Sub cmdRafraichir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRafraichir.Click
		
5: On Error GoTo AfficherErreur
		
		'Rempli la liste avec tous les contacts après avoir fait une recherche
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call RemplirComboContact()
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmContact", "cmdRafraichir_Click", Err, Erl())
	End Sub
	
	Private Sub cmdreport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdreport.Click
		Dim DR_ListeContact As Object
		
5: On Error GoTo AfficherErreur
		
		'Impression de la liste des contacts
10: Dim rstContact As ADODB.Recordset
		
15: rstContact = New ADODB.Recordset
		
20: If MsgBox("Voulez-vous imprimer ce contact uniquement?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
25: Call rstContact.Open("SELECT * FROM GRB_Contact WHERE IDContact = " & m_iNoContact, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
30: Else
35: If MsgBox("Voulez-vous filtrer par la compagnie '" & txtCompagnie.Text & "'?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
40: Call rstContact.Open("SELECT * FROM GRB_Contact WHERE Compagnie = '" & Replace(txtCompagnie.Text, "'", "''") & "' AND Supprimé = False ORDER BY NomContact", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
45: Else
50: Call rstContact.Open("SELECT * FROM GRB_Contact WHERE Supprimé = False ORDER BY NomContact", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
55: End If
60: End If
		
65: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'set le rapport
70: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeContact.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ListeContact.DataSource = rstContact
		
75: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeContact.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ListeContact.Orientation = MSDataReportLib.OrientationConstants.rptOrientPortrait
		
80: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeContact.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_ListeContact.Show(VB6.FormShowConstants.Modal)
		
85: Call rstContact.Close()
90: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
95: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmContact", "cmdreport_Click", Err, Erl())
	End Sub
	
	Private Sub AfficherControles(ByVal eMode As enumMode)
		
5: On Error GoTo AfficherErreur
		
		'Proc qui fait le switch bouton visible/invible et enabled/disabled
10: Dim bCmbContact As Boolean
15: Dim bTxtNomContact As Boolean
20: Dim bTxtRechercher As Boolean
25: Dim bCmdAdd As Boolean
30: Dim bCmdEnr As Boolean
35: Dim bCmdModif As Boolean
40: Dim bCmdSupp As Boolean
45: Dim bCmdAnul As Boolean
50: Dim bCmdQuit As Boolean
55: Dim bCmdRenommer As Boolean
60: Dim bCmdRafraichir As Boolean
65: Dim bCmdRechercher As Boolean
70: Dim bCmdImprimer As Boolean
75: Dim bCmdCopier As Boolean
80: Dim bFax As Boolean
85: Dim bCmdMailList As Boolean
		
90: Select Case eMode
			Case enumMode.MODE_AJOUT_MODIF
95: bCmdEnr = True
100: bCmdAnul = True
105: bTxtNomContact = True
				
			Case enumMode.MODE_INACTIF
110: bCmbContact = True
115: bTxtRechercher = True
120: bCmdAdd = True
125: bCmdModif = True
130: bCmdSupp = True
135: bCmdQuit = True
140: bCmdRenommer = True
145: bCmdRafraichir = True
150: bCmdImprimer = True
155: bCmdCopier = True
160: bFax = True
165: bCmdMailList = True
				
170: If Len(Trim(txtRechercher.Text)) > 0 Then
175: bCmdRechercher = True
180: End If
185: End Select
		
190: cmbcontact.Visible = bCmbContact
195: txtNomContact.Visible = bTxtNomContact
200: txtRechercher.Enabled = bTxtRechercher
205: CmdAdd.Visible = bCmdAdd
210: CmdEnr.Visible = bCmdEnr
215: CmdModif.Visible = bCmdModif
220: CmdSupp.Visible = bCmdSupp
225: CmdAnul.Visible = bCmdAnul
230: CmdQuit.Visible = bCmdQuit
235: cmdRechercher.Enabled = bCmdRechercher
240: cmdreport.Visible = bCmdImprimer
245: cmdCopier.Visible = bCmdCopier
250: cmdFax.Visible = bFax
255: cmdMailList.Visible = bCmdMailList
		
260: Exit Sub
		
AfficherErreur: 
		
265: Call AfficherErreur("frmContact", "AfficherControles", Err, Erl())
	End Sub
	
	Private Sub CmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdAdd.Click
		
5: On Error GoTo AfficherErreur
		
		'proc qui permet d'ajouter un contact à la BD
10: Dim sName As String
15: Dim bAjouter As Boolean
		
		'On procede a la saisie du nom et du contact
20: sName = InputBox("Veuillez entrer le nom du contact" & vbNewLine & vbNewLine & "SVP, respectez le bon orthographe!", "SAISIE DU NOM", "Nom du contact")
		
25: If sName <> vbNullString Then
30: If ExisteDansBD(sName) = True Then
35: If MsgBox("Il y a déjà un contact portant ce nom!" & vbNewLine & "Voulez-vous l'ajouter quand même?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
40: bAjouter = True
45: Else
50: bAjouter = False
55: End If
60: Else
65: If ContientCaracteresIncorrects(sName) = True Then
70: Call MsgBox("Il y a des caractères non permis!", MsgBoxStyle.OKOnly, "Erreur")
					
75: bAjouter = False
80: Else
85: bAjouter = True
90: End If
95: End If
100: Else
105: bAjouter = False
110: End If
		
115: If bAjouter = True Then
120: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
125: m_bModeAjout = True
			
			'On montre seulement les boutton pour enregistrer
130: Call AfficherControles(enumMode.MODE_AJOUT_MODIF)
			
			'On montre les maskEdBox
135: Call HideEdMask(False)
			
			'On affiche le nom du nouveau client dans le textbox
			'pour éviter le ScrollDown durant l'ajout
			
140: txtNomContact.Text = sName
			
145: Call ViderBarrerChamps(False, True)
			
150: Call txtCompagnie.Focus()
			
155: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
160: End If
		
165: Exit Sub
		
AfficherErreur: 
		
170: Call AfficherErreur("frmContact", "CmdAdd_Click", Err, Erl())
	End Sub
	
	Private Sub ViderBarrerChamps(ByVal bLocked As Boolean, ByVal bVider As Boolean)
		
5: On Error GoTo AfficherErreur
		
10: If bVider = True Then
15: txtCompagnie.Text = vbNullString
20: txtTelephone.Text = vbNullString
25: txtTitre.Text = vbNullString
30: txtPoste.Text = vbNullString
35: txtFax.Text = vbNullString
40: txtPagette.Text = vbNullString
45: txtCellulaire.Text = vbNullString
50: txtEmail.Text = vbNullString
55: txtTelDomicile.Text = vbNullString
60: txtcommentaire.Text = vbNullString
65: lblDateCreation.Text = vbNullString
70: lblUserCreation.Text = vbNullString
75: lblDateModification.Text = vbNullString
80: lblUserModification.Text = vbNullString
85: End If
		
90: txtNomContact.ReadOnly = bLocked
95: txtCompagnie.ReadOnly = bLocked
100: txtTelephone.ReadOnly = bLocked
105: txtTitre.ReadOnly = bLocked
110: txtPoste.ReadOnly = bLocked
115: txtFax.ReadOnly = bLocked
120: txtPagette.ReadOnly = bLocked
125: txtCellulaire.ReadOnly = bLocked
130: txtEmail.ReadOnly = bLocked
135: txtTelDomicile.ReadOnly = bLocked
140: txtcommentaire.ReadOnly = bLocked
		
145: Exit Sub
		
AfficherErreur: 
		
150: Call AfficherErreur("frmContact", "ViderBarrerChamps", Err, Erl())
	End Sub
	
	Private Sub AfficherContact()
		
5: On Error GoTo AfficherErreur
		
		'Affiche le contact sélectionné
10: Dim rstContact As ADODB.Recordset
		
15: rstContact = New ADODB.Recordset
		
20: Call rstContact.Open("SELECT * FROM GRB_Contact WHERE IDContact = " & m_iNoContact, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Compagnie
25: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstContact.Fields("Compagnie").Value) Then
30: txtCompagnie.Text = rstContact.Fields("Compagnie").Value
35: Else
40: txtCompagnie.Text = vbNullString
45: End If
		
		'Titre
50: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstContact.Fields("Titre").Value) Then
55: txtTitre.Text = rstContact.Fields("Titre").Value
60: Else
65: txtTitre.Text = vbNullString
70: End If
		
		'Telephonne
75: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstContact.Fields("Telephonne").Value) Then
80: txtTelephone.Text = rstContact.Fields("Telephonne").Value
85: Else
90: txtTelephone.Text = vbNullString
95: End If
		
		'noPoste
100: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstContact.Fields("noPoste").Value) Then
105: txtPoste.Text = rstContact.Fields("noPoste").Value
110: Else
115: txtPoste.Text = vbNullString
120: End If
		
		'Fax
125: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstContact.Fields("Fax").Value) Then
130: txtFax.Text = rstContact.Fields("Fax").Value
135: Else
140: txtFax.Text = vbNullString
145: End If
		
		'Pagette
150: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstContact.Fields("Pagette").Value) Then
155: txtPagette.Text = rstContact.Fields("Pagette").Value
160: Else
165: txtPagette.Text = vbNullString
170: End If
		
		'Cellulaire
175: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstContact.Fields("Cellulaire").Value) Then
180: txtCellulaire.Text = rstContact.Fields("Cellulaire").Value
185: Else
190: txtCellulaire.Text = vbNullString
195: End If
		
		'teldomicile
200: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstContact.Fields("teldomicile").Value) Then
205: txtTelDomicile.Text = rstContact.Fields("teldomicile").Value
210: Else
215: txtTelDomicile.Text = vbNullString
220: End If
		
		'E-mail
225: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstContact.Fields("E-mail").Value) Then
230: txtEmail.Text = rstContact.Fields("E-mail").Value
235: Else
240: txtEmail.Text = vbNullString
245: End If
		
		'Commentaire
250: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstContact.Fields("Commentaire").Value) Then
255: txtcommentaire.Text = rstContact.Fields("Commentaire").Value
260: Else
265: txtcommentaire.Text = vbNullString
270: End If
		
		'Création
275: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstContact.Fields("DateCréation").Value) Then
280: lblDateCreation.Text = rstContact.Fields("DateCréation").Value
285: Else
290: lblDateCreation.Text = vbNullString
295: End If
		
		'User Création
300: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstContact.Fields("UserCréation").Value) Then
305: lblUserCreation.Text = "Par : " & rstContact.Fields("UserCréation").Value
310: Else
315: lblUserCreation.Text = vbNullString
320: End If
		
		'Modification
325: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstContact.Fields("DateModification").Value) Then
330: lblDateModification.Text = rstContact.Fields("DateModification").Value
335: Else
340: lblDateModification.Text = vbNullString
345: End If
		
		'User Modification
350: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstContact.Fields("UserModification").Value) Then
355: lblUserModification.Text = "Par : " & rstContact.Fields("UserModification").Value
360: Else
365: lblUserModification.Text = vbNullString
370: End If
		
375: Call rstContact.Close()
380: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
385: Exit Sub
		
AfficherErreur: 
		
390: Call AfficherErreur("frmContact", "AfficherContact", Err, Erl())
	End Sub
	
	Private Sub HideEdMask(ByVal bVisible As Boolean)
		
5: On Error GoTo AfficherErreur
		
		'proc qui rend visible/ou non les maskEdBox
		'On en profite pour les nettoyer du dernier Enregistrement
		'et on fait l'inverse avec les textBox
10: If m_bModeAjout = True Then
15: txtTelephone.Text = vbNullString
20: txtCellulaire.Text = vbNullString
25: txtPagette.Text = vbNullString
30: txtFax.Text = vbNullString
35: txtTelDomicile.Text = vbNullString
			
40: mskTelephone.Text = vbNullString
45: mskCellulaire.Text = vbNullString
50: mskPagette.Text = vbNullString
55: mskFax.Text = vbNullString
60: mskTelDomicile.Text = vbNullString
65: Else
70: mskTelephone.Text = txtTelephone.Text
75: mskCellulaire.Text = txtCellulaire.Text
80: mskPagette.Text = txtPagette.Text
85: mskFax.Text = txtFax.Text
90: mskTelDomicile.Text = txtTelDomicile.Text
95: End If
		
100: mskTelephone.Visible = Not bVisible
105: mskCellulaire.Visible = Not bVisible
110: mskPagette.Visible = Not bVisible
115: mskFax.Visible = Not bVisible
120: mskTelDomicile.Visible = Not bVisible
		
125: txtTelephone.Visible = bVisible
130: txtCellulaire.Visible = bVisible
135: txtPagette.Visible = bVisible
140: txtFax.Visible = bVisible
145: txtTelDomicile.Visible = bVisible
		
150: Exit Sub
		
AfficherErreur: 
		
155: Call AfficherErreur("frmContact", "HideEdMask", Err, Erl())
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
20: m_bModeAjout = False
		
		'on retablis les bouttons
25: Call AfficherControles(enumMode.MODE_INACTIF)
		
		'jfc 15oct
		'on affiche les donnée du premier enreg
30: Call cmbContact_SelectedIndexChanged(cmbContact, New System.EventArgs())
		
35: Call ViderBarrerChamps(True, True)
		
40: Call cmbContact_SelectedIndexChanged(cmbContact, New System.EventArgs())
		
45: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmContact", "CmdAnul_Click", Err, Erl())
	End Sub
	
	Private Sub CmdEnr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdEnr.Click
		
5: On Error GoTo AfficherErreur
		
		'Enregistrement d'un contact dnas la BD
10: Dim iCompteur As Short
15: Dim sContact As String
20: Dim bSave As Boolean
		
		'Nom du contact
25: sContact = txtNomContact.Text
		
30: If Trim(txtNomContact.Text) = "" Or Trim(txtCompagnie.Text) = "" Then
35: Call MsgBox("Le nom du contact et la compagnie sont obligatoires!", MsgBoxStyle.OKOnly, "Erreur")
			
40: bSave = False
45: Else
50: If m_bModeAjout = True Then
55: bSave = True
60: Else
65: If Trim(VB.Left(cmbcontact.Text, InStr(1, cmbcontact.Text, " - ") - 1)) = txtNomContact.Text Then
70: bSave = True
75: Else
80: If ExisteDansBD(txtNomContact.Text) = True Then
85: If MsgBox("Il y a déjà un contact portant ce nom!" & vbNewLine & "Voulez-vous l'ajouter quand même?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
90: bSave = True
95: Else
100: bSave = False
105: End If
110: Else
115: bSave = True
120: End If
125: End If
130: End If
135: End If
		
140: If bSave = True Then
145: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
150: Call EnregistrerContact()
			
			'On cache les MaskEdBox
155: Call HideEdMask(True)
			
			'On met a jour le combo
160: Call RemplirComboContact()
			
			'Retablir les boutons
165: Call AfficherControles(enumMode.MODE_INACTIF)
			
170: For iCompteur = 0 To cmbcontact.Items.Count - 1
175: If Trim(VB.Left(VB6.GetItemString(cmbcontact, iCompteur), InStr(1, VB6.GetItemString(cmbcontact, iCompteur), "-") - 1)) = sContact Then
180: cmbcontact.SelectedIndex = iCompteur
					
185: Exit For
190: End If
195: Next 
			
200: Call cmbcontact.Focus()
			
205: Call ViderBarrerChamps(True, False)
			
210: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
215: End If
		
220: Exit Sub
		
AfficherErreur: 
		
225: Call AfficherErreur("frmContact", "CmdEnr_Click", Err, Erl())
	End Sub
	
	Private Sub CmdModif_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdModif.Click
		
5: On Error GoTo AfficherErreur
		
		'Pour modifier l'enregistrement courant
10: If cmbcontact.Items.Count > 0 Then
15: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
20: Call HideEdMask(False)
25: Call AfficherControles(enumMode.MODE_AJOUT_MODIF)
30: Call ViderBarrerChamps(False, False)
35: Call txtCompagnie.Focus()
			
40: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
45: Else
50: Call MsgBox("Aucun enregistrement sélectionné!")
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmContact", "CmdModif_Click", Err, Erl())
	End Sub
	
	Private Sub cmdquit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdquit.Click
		
5: On Error GoTo AfficherErreur
		'Fermeture de la fenêtre
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmContact", "cmdquit_Click", Err, Erl())
	End Sub
	
	Private Sub CmdSupp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdSupp.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjSoum As ADODB.Recordset
15: Dim rstContact As ADODB.Recordset
20: Dim rstLiaison As ADODB.Recordset
25: Dim bPeutEffacer As Boolean
		
		'fonction qui supprime lenregistrement courant
30: If cmbcontact.Items.Count > 0 Then
35: If MsgBox("Etes-vous sur de supprimer cette enregistrement?", MsgBoxStyle.YesNo, "Supprimer") = MsgBoxResult.Yes Then
40: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
				'open table
45: rstProjSoum = New ADODB.Recordset
				
50: Call rstProjSoum.Open("SELECT * FROM GRB_SoumissionMec WHERE IDContact = " & m_iNoContact, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
				'Si existe pas dans soumission, on peut le deleté
55: If rstProjSoum.EOF Then
60: Call rstProjSoum.Close()
					
65: Call rstProjSoum.Open("SELECT * FROM GRB_ProjetMec WHERE IDContact = " & m_iNoContact, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
70: If rstProjSoum.EOF Then
75: Call rstProjSoum.Close()
						
80: Call rstProjSoum.Open("SELECT * FROM GRB_SoumissionElec WHERE IDContact = " & m_iNoContact, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
						
85: If rstProjSoum.EOF Then
90: Call rstProjSoum.Close()
							
95: Call rstProjSoum.Open("SELECT * FROM GRB_ProjetElec WHERE IDContact = " & m_iNoContact, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
							
100: If rstProjSoum.EOF Then
105: bPeutEffacer = True
								
110: Call rstProjSoum.Close()
115: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
								rstProjSoum = Nothing
120: Else
125: bPeutEffacer = False
								
130: Call rstProjSoum.Close()
135: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
								rstProjSoum = Nothing
140: End If
145: Else
150: bPeutEffacer = False
							
155: Call rstProjSoum.Close()
160: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
							rstProjSoum = Nothing
165: End If
170: Else
175: bPeutEffacer = False
						
180: Call rstProjSoum.Close()
185: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						rstProjSoum = Nothing
190: End If
195: Else
200: bPeutEffacer = False
					
205: Call rstProjSoum.Close()
210: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstProjSoum = Nothing
215: End If
220: End If
			
225: Call SupprimerContactExchange(m_iNoContact)
			
230: If bPeutEffacer = True Then
235: Call g_connData.Execute("DELETE * FROM GRB_Contact WHERE IDContact = " & m_iNoContact)
240: Else
245: rstContact = New ADODB.Recordset
				
250: Call rstContact.Open("SELECT * FROM GRB_Contact WHERE IDContact = " & m_iNoContact, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
255: rstContact.Fields("Supprimé").Value = True
				
260: Call rstContact.Update()
				
265: Call rstContact.Close()
270: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstContact = Nothing
275: End If
			
280: rstLiaison = New ADODB.Recordset
			
285: Call rstLiaison.Open("SELECT * FROM GRB_ContactClient WHERE NoContact = " & m_iNoContact, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
290: If Not rstLiaison.EOF Then
295: Do While Not rstLiaison.EOF
300: Call rstLiaison.Delete()
					
305: Call rstLiaison.MoveNext()
310: Loop 
315: End If
			
320: Call rstLiaison.Close()
			
325: Call rstLiaison.Open("SELECT * FROM GRB_ContactFRS WHERE NoContact = " & m_iNoContact, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
330: If Not rstLiaison.EOF Then
335: Do While Not rstLiaison.EOF
340: Call rstLiaison.Delete()
					
345: Call rstLiaison.MoveNext()
350: Loop 
355: End If
			
360: Call rstLiaison.Close()
365: 'UPGRADE_NOTE: Object rstLiaison may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstLiaison = Nothing
			
370: Call RemplirComboContact()
			
375: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
380: Else
385: Call MsgBox("Aucun enregistrement sélectionné!")
390: End If
		
395: Exit Sub
		
AfficherErreur: 
		
400: Call AfficherErreur("frmContact", "CmdSupp_Click", Err, Erl())
	End Sub
	
	Private Sub LierContactClient(ByVal iContactID As Short, ByVal iClientID As Short)
		
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
		
55: otlApp = OuvrirOutlook(bDejaOuvert)
		
65: folClient = GetFolder(otlApp, "Clients GRB")
70: folContact = GetFolder(otlApp, "Contacts GRB")
		
75: rstClient = New ADODB.Recordset
		
80: Call rstClient.Open("SELECT EntryIDOutlook FROM GRB_Client WHERE IDClient = " & iClientID, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
85: itmClient = folClient.Items.Find("[User1] = " & iClientID)
		
90: If Not itmClient Is Nothing Then
95: Do While itmClient.Links.Count > 0
100: 'UPGRADE_WARNING: Couldn't resolve default property of object itmClient.Links.Item().Item.User1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				itmContact = folContact.Items.Find("[User1] = " & itmClient.Links.Item(1).Item.User1)
				
105: For iCompteur = 1 To itmContact.Links.Count
110: 'UPGRADE_WARNING: Couldn't resolve default property of object itmContact.Links.Item(1).Item.User1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If itmContact.Links.Item(1).Item.User1 = itmClient.User1 Then
115: Call itmContact.Links.Remove(iCompteur)
						
120: Call itmContact.Save()
						
125: Exit For
130: End If
135: Next 
				
140: Call itmClient.Links.Remove(1)
145: Loop 
			
150: Call itmClient.Save()
			
155: Call rstClient.Close()
160: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstClient = Nothing
			
165: rstContactClient = New ADODB.Recordset
			
170: Call rstContactClient.Open("SELECT * FROM GRB_ContactClient WHERE NoClient = " & iClientID, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
			
175: Do While Not rstContactClient.EOF
180: If rstContactClient.Fields("NoContact").Value <> iContactID Then
185: itmContact = folContact.Items.Find("[User1] = " & rstContactClient.Fields("NoContact").Value)
					
190: If Not itmContact Is Nothing Then
195: Call itmClient.Links.Add(itmContact)
						
200: Call itmClient.Save()
						
205: Call itmContact.Links.Add(itmClient)
						
210: Call itmContact.Save()
215: End If
220: End If
				
225: Call rstContactClient.MoveNext()
230: Loop 
			
235: Call rstContactClient.Close()
240: 'UPGRADE_NOTE: Object rstContactClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstContactClient = Nothing
245: Else
250: Call MsgBox("Client introuvable!", MsgBoxStyle.OKOnly, "Erreur")
			
255: Call rstClient.Close()
260: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstClient = Nothing
265: End If
		
270: If bDejaOuvert = False Then
275: Call otlApp.Quit()
280: End If
		
285: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		otlApp = Nothing
		
290: System.Windows.Forms.Application.DoEvents()
		
295: Exit Sub
		
AfficherErreur: 
		
300: Call AfficherErreur("frmClient", "LierContactClient", Err, Erl())
		
305: fraEtatOutlook.Visible = False
	End Sub
	
	Private Sub LierContactFournisseur(ByVal iContactID As Short, ByVal iFournisseurID As Short)
		
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
		
55: fraEtatOutlook.Visible = True
		
60: otlApp = OuvrirOutlook(bDejaOuvert)
		
65: folFRS = GetFolder(otlApp, "Fournisseurs GRB")
70: folContact = GetFolder(otlApp, "Contacts GRB")
		
75: rstFRS = New ADODB.Recordset
		
80: Call rstFRS.Open("SELECT EntryIDOutlook FROM GRB_Fournisseur WHERE IDFRS = " & iFournisseurID, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
85: itmFRS = folFRS.Items.Find("[User1] = " & iFournisseurID)
		
90: If Not itmFRS Is Nothing Then
95: Do While itmFRS.Links.Count > 0
100: 'UPGRADE_WARNING: Couldn't resolve default property of object itmFRS.Links.Item().Item.User1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				itmContact = folContact.Items.Find("[User1] = " & itmFRS.Links.Item(1).Item.User1)
				
105: For iCompteur = 1 To itmContact.Links.Count
110: 'UPGRADE_WARNING: Couldn't resolve default property of object itmContact.Links.Item(1).Item.User1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If itmContact.Links.Item(1).Item.User1 = itmFRS.User1 Then
115: Call itmContact.Links.Remove(iCompteur)
						
120: Call itmContact.Save()
						
125: Exit For
130: End If
135: Next 
				
140: Call itmFRS.Links.Remove(1)
145: Loop 
			
150: Call itmFRS.Save()
			
155: Call rstFRS.Close()
160: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstFRS = Nothing
			
165: rstContactFRS = New ADODB.Recordset
			
170: Call rstContactFRS.Open("SELECT * FROM GRB_ContactFRS WHERE NoFRS = " & iFournisseurID, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
			
175: Do While Not rstContactFRS.EOF
180: If rstContactFRS.Fields("NoContact").Value <> iContactID Then
185: itmContact = folContact.Items.Find("[User1] = " & rstContactFRS.Fields("NoContact").Value)
					
190: If Not itmContact Is Nothing Then
195: Call itmFRS.Links.Add(itmContact)
						
200: Call itmFRS.Save()
						
205: Call itmContact.Links.Add(itmFRS)
						
210: Call itmContact.Save()
215: End If
220: End If
				
225: Call rstContactFRS.MoveNext()
230: Loop 
			
235: Call rstContactFRS.Close()
240: 'UPGRADE_NOTE: Object rstContactFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstContactFRS = Nothing
245: Else
250: Call MsgBox("Fournisseur introuvable!", MsgBoxStyle.OKOnly, "Erreur")
			
255: Call rstFRS.Close()
260: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstFRS = Nothing
265: End If
		
270: If bDejaOuvert = False Then
275: Call otlApp.Quit()
280: End If
		
285: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		otlApp = Nothing
		
290: fraEtatOutlook.Visible = False
		
295: System.Windows.Forms.Application.DoEvents()
		
300: Exit Sub
		
AfficherErreur: 
		
305: Call AfficherErreur("frmFRS", "LierContactFournisseur", Err, Erl())
		
310: fraEtatOutlook.Visible = False
	End Sub
	
	
	'UPGRADE_WARNING: Event cmbContact.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Public Sub cmbContact_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbContact.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		'Quand le user selectionne un enregistrement on se posotionne dessus
10: If cmbcontact.Text <> vbNullString Then
15: txtNomContact.Text = Trim(VB.Left(cmbcontact.Text, InStr(1, cmbcontact.Text, " - ") - 1))
20: Else
25: cmbcontact.Text = txtNomContact.Text
30: End If
		
35: If cmbcontact.SelectedIndex > -1 Then
40: If m_bRenommer = False And m_bModeAjout = False Then
45: m_iNoContact = VB6.GetItemData(cmbcontact, cmbcontact.SelectedIndex)
50: End If
55: End If
		
		'remplis le combo dépendant le contact sélectionné
60: Call AfficherContact()
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmContact", "cmbContact_Click", Err, Erl())
	End Sub
	
	Private Sub FrmContact_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Call RemplirComboContact()
		
15: Call HideEdMask(True)
		
20: Call AfficherControles(enumMode.MODE_INACTIF)
		
25: Call ActiverBoutonsGroupe()
		
30: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmContact", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub ActiverBoutonsGroupe()
		
5: On Error GoTo AfficherErreur
		
10: CmdAdd.Enabled = g_bModificationContacts
15: CmdModif.Enabled = g_bModificationContacts
20: CmdSupp.Enabled = g_bModificationContacts
25: cmdCopier.Enabled = g_bModificationContacts
30: cmdMailList.Enabled = g_bModificationListeDistribution
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmContact", "ActiverBoutonsGroupe", Err, Erl())
	End Sub
	
	Private Sub FrmContact_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_NOTE: Object FrmContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Me = Nothing
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmContact", "Form_Unload", Err, Erl())
	End Sub
	Private Sub mskTelephone_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskTelephone.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskTelephone.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmContact", "mskTelephone_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskTelephone_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskTelephone.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskTelephone.Mask = vbNullString
		
15: If mskTelephone.Text = "(___) ___-____" Then
20: mskTelephone.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmContact", "mskTelephone_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskCellulaire_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskCellulaire.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskCellulaire.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmContact", "mskCellulaire_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskCellulaire_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskCellulaire.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskCellulaire.Mask = vbNullString
		
15: If mskCellulaire.Text = "(___) ___-____" Then
20: mskCellulaire.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmContact", "mskCellulaire_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskFax_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskFax.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskFax.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmContact", "mskFax_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskFax_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskFax.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskFax.Mask = vbNullString
		
15: If mskFax.Text = "(___) ___-____" Then
20: mskFax.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmContact", "mskFax_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskPagette_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskPagette.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskPagette.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmContact", "mskPagette_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskPagette_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskPagette.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskPagette.Mask = vbNullString
		
15: If mskPagette.Text = "(___) ___-____" Then
20: mskPagette.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmContact", "mskPagette_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskTelDomicile_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskTelDomicile.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskTelDomicile.Mask = "(###) ###-####"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmContact", "mskTelDomicile_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskTelDomicile_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskTelDomicile.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskTelDomicile.Mask = vbNullString
		
15: If mskTelDomicile.Text = "(___) ___-____" Then
20: mskTelDomicile.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmContact", "mskTelDomicile_LostFocus", Err, Erl())
	End Sub
	
	Private Sub cmdRechercher_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercher.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstContact As ADODB.Recordset
15: Dim sSearch As String
		
20: sSearch = txtRechercher.Text
		
25: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'vide les champs
30: Call ViderBarrerChamps(True, True)
		
		'Filtre pour selection des Nomcontact
35: rstContact = New ADODB.Recordset
		
40: Call rstContact.Open("SELECT NomContact, Compagnie, IDContact FROM GRB_Contact WHERE Instr(1, NomContact,'" & Replace(sSearch, "'", "''") & "') > 0 Or Instr(1, Compagnie, '" & Replace(sSearch, "'", "''") & "') > 0 AND Supprimé = False ORDER BY NomContact", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'vide combo
45: Call cmbcontact.Items.Clear()
		
50: Do While Not rstContact.EOF
55: Call cmbcontact.Items.Add(rstContact.Fields("NomContact").Value & " - " & rstContact.Fields("Compagnie").Value)
60: 'UPGRADE_ISSUE: ComboBox property cmbcontact.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbcontact, cmbcontact.NewIndex, rstContact.Fields("IDContact").Value)
			
65: Call rstContact.MoveNext()
70: Loop 
		
75: Call rstContact.Close()
80: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
85: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
90: If cmbcontact.Items.Count > 0 Then
95: cmbcontact.SelectedIndex = 0
100: End If
		
105: Exit Sub
		
AfficherErreur: 
		
110: Call AfficherErreur("frmContact", "cmdRechercher_Click", Err, Erl())
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
		
40: Call AfficherErreur("frmContact", "txtRechercher_Change", Err, Erl())
	End Sub
End Class