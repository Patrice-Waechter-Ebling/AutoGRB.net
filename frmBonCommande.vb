Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmBonCommande
	Inherits System.Windows.Forms.Form
	
	'Index des colonnes du listview
	Private Const I_COL_QUANTITE As Short = 0
	Private Const I_COL_NO_ITEM As Short = 1
	Private Const I_COL_DESCR As Short = 2
	Private Const I_COL_MANUFACT As Short = 3
	Private Const I_COL_PRIX As Short = 4
	Private Const I_COL_ESCOMPTE As Short = 5
	Private Const I_COL_TOTAL As Short = 6
	
	'Index de optImpression
	Private Const I_IMP_FRANCAIS As Short = 0
	Private Const I_IMP_ANGLAIS As Short = 1
	
	Public Enum enumFormSource
		I_PROJET_MEC = 0
		I_PROJET_ELEC = 1
		I_ACHAT_MEC = 2
		I_ACHAT_ELEC = 3
		I_INVENTAIRE_MEC = 4
		I_INVENTAIRE_ELEC = 5
		I_RETOUR_MARCHANDISE = 6
	End Enum
	
	Private Enum enumLangage
		FRANCAIS = 0
		ANGLAIS = 1
	End Enum
	
	'Pour savoir le no de projet
	Private m_sNoProjet As String
	
	Private m_sNoAchat As String
	Private m_iIndexAchat As Short
	
	'Pour savoir le type (Électrique ou mécanique)
	Public m_eForm As enumFormSource
	
	'Pour savoir si le form vient d'être ouvert
	Private m_bOuverture As Boolean
	
	'No du fournisseur sélectionné dans le combo
	Private m_iNoFRS As Short
	
	'Pièces à partir d'un projet
	Private m_collPieces As Collection
	Private m_collNoLigne As Collection
	
	Private m_sEmploye As String
	
	Private m_eImpRetour As frmChoixImpressionRetourMarchandise.enumImpressionRetour
	
	Private m_eLangage As enumLangage
	
	'UPGRADE_WARNING: Event cmbFournisseur.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbFournisseur_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbFournisseur.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'Il ne faut pas enregistrer les modifications sur l'ouverture du form
		'parce qu'il n'y a pas eu de modifications encore
		
		'Si le form ne vient pas d'etre ouvert
15: If m_bOuverture = False Then
			'On enregistre les modifications
20: Call EnregistrerModifFournisseur()
25: Else
30: m_bOuverture = False
35: End If
		
40: m_iNoFRS = VB6.GetItemData(cmbFournisseur, cmbFournisseur.SelectedIndex)
		
		'Rempli le combo des contacts
45: Call RemplirComboContacts()
		
		'On affiche le contenu du fournisseur sélectionné
50: Call AfficherContenuFournisseur()
		
55: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmBonCommande", "cmbFournisseur_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDate.Click
		
5: On Error GoTo AfficherErreur
		
10: mvwDate.Value = Today
		
15: mvwDate.Visible = True
		
20: Call mvwDate.Focus()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmBonCommande", "cmdDate_Click", Err, Erl())
	End Sub
	
	Private Sub Cmdfermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cmdfermer.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim sNoBC As String
		
15: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
20: sNoBC = txtVotreNoSoum.Text
25: Else
30: sNoBC = txtNoBC.Text
35: End If
		
40: Call g_connData.Execute("DELETE * FROM GRB_BonsCommandes_Pieces WHERE NoBonCommande = '" & sNoBC & "'")
45: Call g_connData.Execute("DELETE * FROM GRB_BonsCommandes WHERE NoBonCommande = '" & sNoBC & "'")
		
50: Call Me.Close()
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmBonCommande", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Public Sub AfficherFormProjetAchat(ByVal sNoProjet As String, ByVal sNoBonCommande As String, ByVal collPiece As Collection, ByVal collNoLigne As Collection, ByVal eForm As enumFormSource, ByVal iLangage As Short)
		
5: On Error GoTo AfficherErreur
		
10: If eForm = enumFormSource.I_ACHAT_ELEC Or eForm = enumFormSource.I_ACHAT_MEC Then
15: m_sNoAchat = VB.Left(sNoProjet, 9)
20: m_iIndexAchat = CShort(VB.Right(sNoProjet, 3))
25: Else
30: m_sNoProjet = sNoProjet
35: End If
		
40: m_eForm = eForm
		
45: m_eLangage = iLangage
		
50: m_collPieces = collPiece
		
55: m_collNoLigne = collNoLigne
		
60: m_bOuverture = True
		
65: txtNoBC.Text = sNoBonCommande
		
70: Call g_connData.Execute("DELETE * FROM GRB_BonsCommandes WHERE NoBonCommande = '" & txtNoBC.Text & "'")
75: Call g_connData.Execute("DELETE * FROM GRB_BonsCommandes_Pieces WHERE NoBonCommande = '" & txtNoBC.Text & "'")
		
		'Enregistrement du bon de commande
80: If eForm = enumFormSource.I_ACHAT_ELEC Or eForm = enumFormSource.I_ACHAT_MEC Then
85: Call EnregistrerBonCommandeAchat()
90: Else
95: Call EnregistrerBonCommandeProjet()
100: End If
		
		'On rempli les fournisseurs
105: Call RemplirComboFournisseurs()
		
		'Affichage du form modalement
110: Call Me.ShowDialog()
		
115: Exit Sub
		
AfficherErreur: 
		
120: Call AfficherErreur("frmBonCommande", "AfficherFormProjet", Err, Erl())
	End Sub
	
	Public Sub AfficherFormRetourMarchandiseProjet(ByVal sNoProjet As String, ByVal sNoBonCommande As String, ByVal collPiece As Collection, ByVal collNoLigne As Collection, ByVal sUserID As String, ByVal eImpRetour As frmChoixImpressionRetourMarchandise.enumImpressionRetour)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmploye As ADODB.Recordset
		
15: Me.Text = "Retour de marchandise"
		
20: lblVotreNoSoum.Text = "Notre # : "
		
25: lblNoBC.Text = "# RMA : "
		
30: m_eImpRetour = eImpRetour
		
35: m_sNoProjet = VB.Right(sNoProjet, Len(sNoProjet) - 1)
		
40: m_eForm = enumFormSource.I_RETOUR_MARCHANDISE
		
45: m_collPieces = collPiece
		
50: m_collNoLigne = collNoLigne
		
55: m_bOuverture = True
		
60: rstEmploye = New ADODB.Recordset
		
65: Call rstEmploye.Open("SELECT Employe FROM GRB_Employés WHERE loginname = '" & sUserID & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
70: m_sEmploye = rstEmploye.Fields("Employe").Value
		
75: Call rstEmploye.Close()
80: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
85: txtVotreNoSoum.Text = sNoBonCommande
		
90: txtVotreNoSoum.ReadOnly = True
		
95: txtNoBC.ReadOnly = False
		
100: Call g_connData.Execute("DELETE * FROM GRB_BonsCommandes WHERE NoBonCommande = '" & txtVotreNoSoum.Text & "'")
105: Call g_connData.Execute("DELETE * FROM GRB_BonsCommandes_Pieces WHERE NoBonCommande = '" & txtVotreNoSoum.Text & "'")
		
		'Enregistrement du bon de commande
110: Call EnregistrerBonCommandeRetourMarchandiseProjet()
		
		'On rempli les fournisseurs
115: Call RemplirComboFournisseurs()
		
		'Affichage du form modalement
120: Call Me.ShowDialog()
		
125: Exit Sub
		
AfficherErreur: 
		
130: Call AfficherErreur("frmBonCommande", "AfficherFormRetourMarchandiseProjet", Err, Erl())
	End Sub
	
	Public Sub AfficherFormRetourMarchandiseAchat(ByVal sNoAchat As String, ByVal iIndexAchat As Short, ByVal sNoBonCommande As String, ByVal collPiece As Collection, ByVal collNoLigne As Collection, ByVal sUserID As String, ByVal eImpRetour As frmChoixImpressionRetourMarchandise.enumImpressionRetour)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmploye As ADODB.Recordset
		
15: Me.Text = "Retour de marchandise"
		
20: lblVotreNoSoum.Text = "Notre # : "
		
25: lblNoBC.Text = "# RMA : "
		
30: m_eImpRetour = eImpRetour
		
35: m_sNoAchat = sNoAchat
40: m_iIndexAchat = iIndexAchat
		
45: m_eForm = enumFormSource.I_RETOUR_MARCHANDISE
		
50: m_collPieces = collPiece
		
55: m_collNoLigne = collNoLigne
		
60: m_bOuverture = True
		
65: rstEmploye = New ADODB.Recordset
		
70: Call rstEmploye.Open("SELECT Employe FROM GRB_Employés WHERE loginname = '" & sUserID & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
75: m_sEmploye = rstEmploye.Fields("Employe").Value
		
80: Call rstEmploye.Close()
85: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
90: txtVotreNoSoum.Text = sNoBonCommande
		
95: txtVotreNoSoum.ReadOnly = True
		
100: txtNoBC.ReadOnly = False
		
105: Call g_connData.Execute("DELETE * FROM GRB_BonsCommandes WHERE NoBonCommande = '" & txtVotreNoSoum.Text & "'")
110: Call g_connData.Execute("DELETE * FROM GRB_BonsCommandes_Pieces WHERE NoBonCommande = '" & txtVotreNoSoum.Text & "'")
		
		'Enregistrement du bon de commande
115: Call EnregistrerBonCommandeRetourMarchandiseAchat()
		
		'On rempli les fournisseurs
120: Call RemplirComboFournisseurs()
		
		'Affichage du form modalement
125: Call Me.ShowDialog()
		
130: Exit Sub
		
AfficherErreur: 
		
135: Call AfficherErreur("frmBonCommande", "AfficherFormRetourMarchandiseAchat", Err, Erl())
	End Sub
	
	
	Private Sub AfficherContenuFournisseur()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBC As ADODB.Recordset
15: Dim rstFRS As ADODB.Recordset
20: Dim sNoBC As String
		
25: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
30: sNoBC = txtVotreNoSoum.Text
35: Else
40: sNoBC = txtNoBC.Text
45: End If
		
50: rstBC = New ADODB.Recordset
		
55: Call rstBC.Open("SELECT * FROM GRB_BonsCommandes WHERE NoFournisseur = " & m_iNoFRS & " AND NoBonCommande = '" & sNoBC & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'À l'attention de
60: If rstBC.Fields("Attention").Value <> vbNullString Then
65: If ComboContient(cmbContact, rstBC.Fields("Attention").Value) = True Then
70: cmbContact.Text = rstBC.Fields("Attention").Value
75: Else
80: cmbContact.SelectedIndex = -1
85: End If
90: Else
95: cmbContact.SelectedIndex = -1
100: End If
		
		'Transport
105: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstBC.Fields("Transport").Value) Or Trim(rstBC.Fields("Transport").Value) <> vbNullString Then
110: txtTransport.Text = rstBC.Fields("Transport").Value
115: Else
120: txtTransport.Text = vbNullString
125: End If
		
		'Date requise
130: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstBC.Fields("DateRequise").Value) Or Trim(rstBC.Fields("DateRequise").Value) <> vbNullString Then
135: txtDateRequise.Text = rstBC.Fields("DateRequise").Value
140: Else
145: txtDateRequise.Text = vbNullString
150: End If
		
		'Votre # Soum
155: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
160: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstBC.Fields("VotreNoSoum").Value) Then
165: txtNoBC.Text = rstBC.Fields("VotreNoSoum").Value
170: Else
175: txtNoBC.Text = vbNullString
180: End If
185: Else
190: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstBC.Fields("VotreNoSoum").Value) Then
195: txtVotreNoSoum.Text = rstBC.Fields("VotreNoSoum").Value
200: Else
205: txtVotreNoSoum.Text = vbNullString
210: End If
215: End If
		
		'Numéro de tel et fax du fournisseur
220: rstFRS = New ADODB.Recordset
		
225: Call rstFRS.Open("SELECT Telephonne, Fax FROM GRB_Fournisseur WHERE IDFRS = " & VB6.GetItemData(cmbFournisseur, cmbFournisseur.SelectedIndex), g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
230: txtTelephone.Text = rstFRS.Fields("Telephonne").Value
235: txtFax.Text = rstFRS.Fields("Fax").Value
		
240: Call rstFRS.Close()
245: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
		
		'Date
250: txtDate.Text = rstBC.Fields("DateCommande").Value
		
		'Commandé par
255: txtComPar.Text = rstBC.Fields("CommandePar").Value
		
		'Commentaire
260: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstBC.Fields("Commentaire").Value) Then
265: txtcommentaire.Text = rstBC.Fields("Commentaire").Value
270: Else
275: txtcommentaire.Text = vbNullString
280: End If
		
		'Total
285: txtTotal.Text = Conversion_Renamed(rstBC.Fields("Total"), ModuleMain.enumConvert.MODE_ARGENT)
		
		'Afficher les instructions de livraison
290: chkAfficherInstructions.CheckState = System.Math.Abs(CShort(rstBC.Fields("AffichageInstructions").Value))
		
		'Langue d'impression
295: If rstBC.Fields("LangueImpression").Value = "Français" Then
300: optImpression(I_IMP_FRANCAIS).Checked = True
305: Else
310: optImpression(I_IMP_ANGLAIS).Checked = True
315: End If
		
320: Call rstBC.Close()
325: 'UPGRADE_NOTE: Object rstBC may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBC = Nothing
		
330: Call RemplirListView()
		
335: Exit Sub
		
AfficherErreur: 
		
340: Call AfficherErreur("frmBonCommande", "AfficherContenuFournisseur", Err, Erl())
	End Sub
	
	Private Sub RemplirListView()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPiece As ADODB.Recordset
15: Dim itmPiece As System.Windows.Forms.ListViewItem
20: Dim iCompteur As Short
25: Dim dblEscompte As Double
30: Dim dblPrix As Double
35: Dim sNoBC As String
		
40: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
45: sNoBC = txtVotreNoSoum.Text
50: Else
55: sNoBC = txtNoBC.Text
60: End If
		
65: Call lvwBonCommande.Items.Clear()
		
70: rstPiece = New ADODB.Recordset
		
75: Call rstPiece.Open("SELECT * FROM GRB_BonsCommandes_Pieces WHERE NoBonCommande = '" & sNoBC & "' AND NoFournisseur = " & m_iNoFRS, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
80: Do While Not rstPiece.EOF
85: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPiece.Fields("Qté").Value) Then
90: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwBonCommande.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmPiece = lvwBonCommande.Items.Add()
				
				'Quantité
95: itmPiece.Text = rstPiece.Fields("Qté").Value
				
100: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPiece.Fields("NuméroLigne").Value) Then
105: itmPiece.Tag = rstPiece.Fields("NuméroLigne").Value
110: End If
				
				'No. Item
115: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_NO_ITEM Then
					itmPiece.SubItems(I_COL_NO_ITEM).Text = rstPiece.Fields("NoItem").Value
				Else
					itmPiece.SubItems.Insert(I_COL_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("NoItem").Value))
				End If
				
				'Description
120: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPiece.Fields("Description").Value) Then
125: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_DESCR Then
						itmPiece.SubItems(I_COL_DESCR).Text = rstPiece.Fields("Description").Value
					Else
						itmPiece.SubItems.Insert(I_COL_DESCR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("Description").Value))
					End If
130: Else
135: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_DESCR Then
						itmPiece.SubItems(I_COL_DESCR).Text = ""
					Else
						itmPiece.SubItems.Insert(I_COL_DESCR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
					End If
140: End If
				
				'Manufacturier
145: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_MANUFACT Then
					itmPiece.SubItems(I_COL_MANUFACT).Text = rstPiece.Fields("Manufact").Value
				Else
					itmPiece.SubItems.Insert(I_COL_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("Manufact").Value))
				End If
				
				'Prix/unité
150: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPiece.Fields("Prix").Value) Then
155: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_PRIX Then
						itmPiece.SubItems(I_COL_PRIX).Text = Conversion_Renamed(rstPiece.Fields("Prix"), ModuleMain.enumConvert.MODE_ARGENT, 4)
					Else
						itmPiece.SubItems.Insert(I_COL_PRIX, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(rstPiece.Fields("Prix"), ModuleMain.enumConvert.MODE_ARGENT, 4)))
					End If
160: Else
165: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_PRIX Then
						itmPiece.SubItems(I_COL_PRIX).Text = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT, 4)
					Else
						itmPiece.SubItems.Insert(I_COL_PRIX, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT, 4)))
					End If
170: End If
				
				'Escompte
175: If Trim(rstPiece.Fields("Escompte").Value) <> vbNullString Then
180: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_ESCOMPTE Then
						itmPiece.SubItems(I_COL_ESCOMPTE).Text = Conversion_Renamed(rstPiece.Fields("Escompte"), ModuleMain.enumConvert.MODE_POURCENT)
					Else
						itmPiece.SubItems.Insert(I_COL_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(rstPiece.Fields("Escompte"), ModuleMain.enumConvert.MODE_POURCENT)))
					End If
185: Else
190: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_ESCOMPTE Then
						itmPiece.SubItems(I_COL_ESCOMPTE).Text = " "
					Else
						itmPiece.SubItems.Insert(I_COL_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
					End If
195: End If
				
				'Total
200: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPiece.Fields("Total").Value) Then
205: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_TOTAL Then
						itmPiece.SubItems(I_COL_TOTAL).Text = Conversion_Renamed(rstPiece.Fields("Total"), ModuleMain.enumConvert.MODE_ARGENT)
					Else
						itmPiece.SubItems.Insert(I_COL_TOTAL, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(rstPiece.Fields("Total"), ModuleMain.enumConvert.MODE_ARGENT)))
					End If
210: Else
215: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_TOTAL Then
						itmPiece.SubItems(I_COL_TOTAL).Text = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
					Else
						itmPiece.SubItems.Insert(I_COL_TOTAL, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)))
					End If
220: End If
225: End If
			
230: Call rstPiece.MoveNext()
235: Loop 
		
240: Call rstPiece.Close()
245: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
250: Exit Sub
		
AfficherErreur: 
		
255: Call AfficherErreur("frmBonCommande", "RemplirListView", Err, Erl())
	End Sub
	
	Private Sub RemplirComboContacts()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstContact As ADODB.Recordset
15: Dim rstContactFRS As ADODB.Recordset
		
20: Call cmbContact.Items.Clear()
		
25: rstContactFRS = New ADODB.Recordset
30: rstContact = New ADODB.Recordset
		
35: Call rstContactFRS.Open("SELECT * FROM GRB_ContactFRS WHERE NoFRS = " & m_iNoFRS, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
40: Do While Not rstContactFRS.EOF
45: Call rstContact.Open("SELECT NomContact FROM GRB_Contact WHERE IDContact = " & rstContactFRS.Fields("NoContact").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
50: If Not rstContact.EOF Then
55: Call cmbContact.Items.Add(rstContact.Fields("NomContact").Value)
60: End If
			
65: Call rstContact.Close()
			
70: Call rstContactFRS.MoveNext()
75: Loop 
		
80: Call rstContactFRS.Close()
		
85: If cmbContact.Items.Count = 0 Then
90: Call rstContact.Open("SELECT NomContact FROM GRB_Contact WHERE Supprimé = False ORDER BY NomContact", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
95: Do While Not rstContact.EOF
100: Call cmbContact.Items.Add(rstContact.Fields("NomContact").Value)
				
105: Call rstContact.MoveNext()
110: Loop 
			
115: Call rstContact.Close()
120: End If
		
125: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
130: Exit Sub
		
AfficherErreur: 
		
135: Call AfficherErreur("frmBonCommande", "RemplirComboContact", Err, Erl())
	End Sub
	
	Private Sub RemplirComboFournisseurs()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBC As ADODB.Recordset
15: Dim sNoBC As String
		
20: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
25: sNoBC = txtVotreNoSoum.Text
30: Else
35: sNoBC = txtNoBC.Text
40: End If
		
45: rstBC = New ADODB.Recordset
		
50: Call rstBC.Open("SELECT NoFournisseur, NomFournisseur FROM GRB_BonsCommandes INNER JOIN GRB_Fournisseur ON GRB_BonsCommandes.NoFournisseur = GRB_Fournisseur.IDFRS WHERE NoBonCommande = '" & sNoBC & "' ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Pour chaque enregistrements du recordset
55: Do While Not rstBC.EOF
			'On ajoute le nom dans le combo
60: Call cmbFournisseur.Items.Add(rstBC.Fields("NomFournisseur").Value)
			
			'On ajoute le no dans l'itemdata du combo
65: 'UPGRADE_ISSUE: ComboBox property cmbFournisseur.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbFournisseur, cmbFournisseur.NewIndex, rstBC.Fields("NoFournisseur").Value)
			
70: Call rstBC.MoveNext()
75: Loop 
		
80: Call rstBC.Close()
85: 'UPGRADE_NOTE: Object rstBC may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBC = Nothing
		
		'Si le combo n'est pas vide
90: If cmbFournisseur.Items.Count > 0 Then
			'On sélectionne le premier enregistrement
95: cmbFournisseur.SelectedIndex = 0
100: End If
		
105: Exit Sub
		
AfficherErreur: 
		
110: Call AfficherErreur("frmBonCommande", "RemplirComboFournisseurs", Err, Erl())
	End Sub
	
	Private Sub cmdImprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImprimer.Click
		Dim DR_Commande_recu As Object
		Dim DR_Commande As Object
		Dim DR_Commande_parcel As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstConfig As ADODB.Recordset
15: Dim rstBC As ADODB.Recordset
20: Dim rstBCPiece As ADODB.Recordset
25: Dim rstFournisseur As ADODB.Recordset
30: Dim bGRB As Boolean
35: Dim iCompteur As Short
40: Dim sNoBC As String
		
45: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
50: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
55: sNoBC = txtVotreNoSoum.Text
60: Else
65: sNoBC = txtNoBC.Text
70: End If
		
		'Sur l'impression, on enregistre une dernière fois le bon de commande
75: Call EnregistrerModifFournisseur()
		
80: rstBC = New ADODB.Recordset
		
85: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
90: If m_eImpRetour = frmChoixImpressionRetourMarchandise.enumImpressionRetour.MODE_RETOUR Then
95: Call rstBC.Open("SELECT * FROM GRB_BonsCommandes WHERE NoBonCommande = '" & sNoBC & "' AND NoFournisseur = " & VB6.GetItemData(cmbFournisseur, cmbFournisseur.SelectedIndex), g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
100: Else
105: Call rstBC.Open("SELECT * FROM GRB_BonsCommandes WHERE NoBonCommande = '" & sNoBC & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
110: End If
115: Else
120: Call rstBC.Open("SELECT * FROM GRB_BonsCommandes WHERE NoBonCommande = '" & sNoBC & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
125: End If
		
130: If m_eForm = enumFormSource.I_ACHAT_ELEC Or m_eForm = enumFormSource.I_PROJET_ELEC Then
135: Do While Not rstBC.EOF
140: If rstBC.Fields("DateRequise").Value = "" Then
145: rstFournisseur = New ADODB.Recordset
					
150: Call rstFournisseur.Open("SELECT NomFournisseur FROM GRB_Fournisseur WHERE IDFRS = " & rstBC.Fields("NoFournisseur").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
155: Call MsgBox("Le date requise est nécessaire pour le fournisseur " & rstFournisseur.Fields("NomFournisseur").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
					
160: Call rstFournisseur.Close()
165: 'UPGRADE_NOTE: Object rstFournisseur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstFournisseur = Nothing
					
170: Call rstBC.Close()
175: 'UPGRADE_NOTE: Object rstBC may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstBC = Nothing
					
180: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
					
185: Exit Sub
190: End If
				
195: Call rstBC.MoveNext()
200: Loop 
			
205: Call rstBC.MoveFirst()
210: End If
		
215: rstBCPiece = New ADODB.Recordset
220: rstFournisseur = New ADODB.Recordset
225: rstConfig = New ADODB.Recordset
		
230: rstBCPiece.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		
235: Dim testgll As String
		Do While Not rstBC.EOF
240: Call rstBCPiece.Open("SELECT * FROM GRB_BonsCommandes_Pieces WHERE NoBonCommande = '" & sNoBC & "' AND NoFournisseur = " & rstBC.Fields("NoFournisseur").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			''''''''''''''''''''''''''''''''''''''''''''''''''''
			' Met au minimum 15 lignes pour un bon de commande '
			''''''''''''''''''''''''''''''''''''''''''''''''''''
245: If rstBCPiece.RecordCount < 15 Then
250: iCompteur = 15 - rstBCPiece.RecordCount
				
255: Do While Not iCompteur = 0
					'Ajoute une ligne vide
260: Call rstBCPiece.AddNew()
					
265: rstBCPiece.Fields("NoBonCommande").Value = rstBC.Fields("NoBonCommande").Value
270: rstBCPiece.Fields("NoFournisseur").Value = rstBC.Fields("NoFournisseur").Value
275: rstBCPiece.Fields("Type").Value = rstBC.Fields("Type").Value
					
280: Call rstBCPiece.Update()
					
285: iCompteur = iCompteur - 1
290: Loop 
295: End If
			
			'Ouvre la table fournisseur
300: Call rstFournisseur.Open("SELECT * FROM GRB_Fournisseur WHERE IDFRS = " & rstBC.Fields("NoFournisseur").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'Ouvre la table config
305: Call rstConfig.Open("SELECT parcel_label_line1, parcel_label_line2, parcel_label_line3, ParcelAssist, ParcelEtat FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			''''''''''''''''''''''''''''''''''''''
			' U.S. PARCEL SERVICE SHIPMENTS ONLY '
			''''''''''''''''''''''''''''''''''''''
310: If rstBC.Fields("AffichageInstructions").Value = True Then
				'Orientation de la page
				'Printer.Orientation = vbPRORPortrait
315: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_parcel.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande_parcel.Orientation = MSDataReportLib.OrientationConstants.rptOrientPortrait
				
				'Affiche les données
320: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_parcel.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande_parcel.Sections("section4").Controls("lblcompagnie").Caption = rstConfig.Fields("parcel_label_line1").Value
325: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_parcel.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande_parcel.Sections("section4").Controls("lbladresse").Caption = rstConfig.Fields("parcel_label_line2").Value
330: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_parcel.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande_parcel.Sections("section4").Controls("lblpays").Caption = rstConfig.Fields("parcel_label_line3").Value
335: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_parcel.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande_parcel.Sections("section4").Controls("lblassist").Caption = "Should you have any questions, do not hesitate to call " & rstConfig.Fields("ParcelAssist").Value & ", it will be our pleasure to assist you."
340: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_parcel.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande_parcel.Sections("section4").Controls("lblreminder").Caption = "Please note that you are shipping to a " & rstConfig.Fields("ParcelEtat").Value & " address and therefore your shipment is considered as domestic."
				
				'Ouvre le rapport
345: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_parcel.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande_parcel.DataSource = rstConfig
				
350: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_parcel.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Call DR_Commande_parcel.Show(VB6.FormShowConstants.Modal)
355: End If
			
			''''''''''''
			' Commande '
			''''''''''''
360: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
365: If m_eImpRetour = frmChoixImpressionRetourMarchandise.enumImpressionRetour.MODE_DEMANDE_RETOUR Then
370: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Caption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande.Caption = "Demande de retour de marchandise"
375: Else
380: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Caption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande.Caption = "Retour de marchandise"
385: End If
390: Else
395: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Caption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Caption = "Commande"
400: End If
			
405: If rstBC.Fields("LangueImpression").Value = "Anglais" Then
410: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
415: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande.Sections("Section2").Controls("lblTitrebc").Caption = "RMA #"
					
420: If m_eImpRetour = frmChoixImpressionRetourMarchandise.enumImpressionRetour.MODE_DEMANDE_RETOUR Then
425: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_Commande.Sections("Section2").Controls("lblTitreCommande").Caption = "RMA REQUEST"
430: Else
435: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_Commande.Sections("Section2").Controls("lblTitreCommande").Caption = "RETURN ORDER"
440: End If
					
445: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande.Sections("section2").Controls("lbltitreNoSoum").Caption = "Our #"
450: Else
455: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande.Sections("Section2").Controls("lbltitrebc").Caption = "PO #"
460: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande.Sections("Section2").Controls("lbltitrecommande").Caption = "PURCHASE ORDER"
465: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande.Sections("section2").Controls("lbltitreNoSoum").Caption = "Your ref #"
470: End If
				
475: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("Section3").Controls("lbltitreCommentaire").Caption = "Comments:"
480: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lbltitrecompar").Caption = "Purchaser:"
485: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lbltitrecontact").Caption = "ATT:"
490: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lbltitredate").Caption = "Date:"
495: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lbltitredatereq").Caption = "Date required"
500: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lbltitredescription").Caption = "Description"
505: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lbltitreescompte").Caption = "Discount"
510: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lbltitrefax").Caption = "Fax"
515: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lbltitrefournisseur").Caption = "SUPPLIER:"
520: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lbltitremanufact").Caption = "Manufacturer"
525: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lbltitrePiece").Caption = "Part Number"
530: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lbltitrepage").Caption = "Page:"
535: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lblPage").Caption = "%p of %P"
540: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lbltitreprix").Caption = "Unit Price"
545: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lbltitreqte").Caption = "Qty"
550: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lbltitretel").Caption = "Telephone"
555: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lbltitretotal").Caption = "Total"
560: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("Section3").Controls("lbltitretotalfin").Caption = "TOTAL"
565: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lbltitretransport").Caption = "TRANSPORT"
570: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("Section3").Controls("lbltypeprix").Caption = rstFournisseur.Fields("pays").Value + " Funds"
575: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("Section3").Controls("lblPiedPage").Caption = "CONFIRM THE ORDER AND SHIPPING DATE"
				
580: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("Section2").Controls("imgLogoFrancais").Visible = False
585: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("Section2").Controls("imgLogoAnglais").Visible = True
590: Else
595: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
600: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande.Sections("Section2").Controls("lblTitreBC").Caption = "# RMA"
					
605: If m_eImpRetour = frmChoixImpressionRetourMarchandise.enumImpressionRetour.MODE_DEMANDE_RETOUR Then
610: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_Commande.Sections("Section2").Controls("lblTitreCommande").Caption = "DEMANDE DE RETOUR DE MARCHANDISE"
615: Else
620: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_Commande.Sections("Section2").Controls("lblTitreCommande").Caption = "RETOUR DE MARCHANDISE"
625: End If
					
630: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande.Sections("Section2").Controls("lblTitreNoSoum").Caption = "Notre #"
635: Else
640: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande.Sections("Section2").Controls("lblTitreBC").Caption = "BC #"
645: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande.Sections("Section2").Controls("lblTitreCommande").Caption = "COMMANDE"
650: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande.Sections("Section2").Controls("lblTitreNoSoum").Caption = "Votre # soum"
655: End If
660: End If
			
665: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
670: If m_eImpRetour = frmChoixImpressionRetourMarchandise.enumImpressionRetour.MODE_RETOUR Then
675: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande.Sections("Section3").Controls("lblCopieCredit").Visible = True
680: End If
685: End If
			
690: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
695: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstBC.Fields("VotreNoSoum").Value) Then
700: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande.Sections("Section2").Controls("lblNoBC").Caption = rstBC.Fields("VotreNoSoum").Value
705: Else
710: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande.Sections("Section2").Controls("lblNoBC").Caption = vbNullString
715: End If
720: Else
725: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lblNoBC").Caption = rstBC.Fields("NoBonCommande").Value
730: End If
			
735: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
740: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("Section3").Controls("lblPiedPage").Visible = False
750: Else
755: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("Section3").Controls("lblPiedPage").Visible = True
765: End If
			
770: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstBC.Fields("Commentaire").Value) Then
775: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("Section3").Controls("lblCommentaire").Caption = rstBC.Fields("Commentaire").Value
780: Else
785: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("Section3").Controls("lblCommentaire").Caption = vbNullString
790: End If
			
795: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.Sections("section2").Controls("lblCommandePar").Caption = rstBC.Fields("CommandePar").Value
			
800: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstBC.Fields("Attention").Value) Then
805: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lblContact").Caption = rstBC.Fields("Attention").Value
810: Else
815: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("Section2").Controls("lblContact").Caption = vbNullString
820: End If
			
825: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.Sections("Section2").Controls("lblDate").Caption = rstBC.Fields("DateCommande").Value
			
830: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstBC.Fields("DateRequise").Value) Then
835: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("Section2").Controls("lblDateRequise").Caption = rstBC.Fields("DateRequise").Value
840: Else
845: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("Section2").Controls("lblDateRequise").Caption = vbNullString
850: End If
			
855: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.Sections("section2").Controls("lblFax").Caption = rstFournisseur.Fields("Fax").Value
860: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.Sections("section2").Controls("lblFournisseur").Caption = rstFournisseur.Fields("NomFournisseur").Value
865: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.Sections("section2").Controls("lblTel").Caption = rstFournisseur.Fields("telephonne").Value
			
870: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
875: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("Section2").Controls("lblNoSoum").Caption = rstBC.Fields("NoBonCommande").Value
880: Else
885: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstBC.Fields("VotreNoSoum").Value) Then
890: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande.Sections("Section2").Controls("lblNoSoum").Caption = rstBC.Fields("VotreNoSoum").Value
895: Else
900: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande.Sections("Section2").Controls("lblNoSoum").Caption = vbNullString
905: End If
910: End If
			
915: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.Sections("Section3").Controls("lblTotalFin").Caption = Conversion_Renamed(rstBC.Fields("total"), ModuleMain.enumConvert.MODE_ARGENT)
			
920: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstBC.Fields("Transport").Value) Then
925: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lblTransport").Caption = rstBC.Fields("Transport").Value
930: Else
935: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("section2").Controls("lblTransport").Caption = " "
940: End If
			
945: If m_eForm = enumFormSource.I_ACHAT_ELEC Or m_eForm = enumFormSource.I_INVENTAIRE_ELEC Or m_eForm = enumFormSource.I_PROJET_ELEC Then
950: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("Section3").Controls("lblCSA").Visible = True
955: End If
			
			'Si on affiche adresse livraison dans commentaire
960: If rstBC.Fields("AffichageInstructions").Value = True Then
965: Call rstConfig.Requery()
				
970: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Commande.Sections("Section3").Controls("lblCommentaire").Caption = "Shipping Address:" & vbNewLine & DR_Commande.Sections("Section3").Controls("lblCommentaire").Caption
975: End If
			rstBCPiece.MoveFirst()
			Do While rstBCPiece.EOF = False
				
				If rstBCPiece.Fields("NoItem").Value <> VariantType.Null Then
					If Len(rstBCPiece.Fields("NoItem").Value) > 26 Then
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_Commande.Sections("section1").Controls("text2").Font.Size = 8
					End If
				End If
				rstBCPiece.MoveNext()
			Loop 
980: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.DataSource = rstBCPiece
			
985: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.Orientation = MSDataReportLib.OrientationConstants.rptOrientLandscape
			
990: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call DR_Commande.Show(VB6.FormShowConstants.Modal)
			
995: If m_eForm <> enumFormSource.I_RETOUR_MARCHANDISE Then
1000: If UCase(rstFournisseur.Fields("NomFournisseur").Value) = "SOLUTION GRB INC." Then
1005: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_recu.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande_recu.Orientation = MSDataReportLib.OrientationConstants.rptOrientLandscape
					
1010: If m_eForm = enumFormSource.I_PROJET_ELEC Or m_eForm = enumFormSource.I_PROJET_MEC Then
1015: Call rstBCPiece.Close()
						
1020: If m_eForm = enumFormSource.I_PROJET_ELEC Then
1025: Call rstBCPiece.Open("SELECT * FROM GRB_BonsCommandes_Pieces LEFT JOIN GRB_InventaireElec ON GRB_BonsCommandes_Pieces.NoItem = GRB_InventaireElec.NoItem WHERE NoBonCommande = '" & sNoBC & "' AND NoFournisseur = " & rstBC.Fields("NoFournisseur").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
1030: Else
1035: Call rstBCPiece.Open("SELECT * FROM GRB_BonsCommandes_Pieces LEFT JOIN GRB_InventaireMec ON GRB_BonsCommandes_Pieces.NoItem = GRB_InventaireMec.NoItem WHERE NoBonCommande = '" & sNoBC & "' AND NoFournisseur = " & rstBC.Fields("NoFournisseur").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
1040: End If
						
1045: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_recu.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_Commande_recu.Sections("Section1").Controls("txtNoItem").DataField = "GRB_BonsCommandes_Pieces.NoItem"
1050: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_recu.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_Commande_recu.Sections("Section1").Controls("txtDescription").DataField = "GRB_BonsCommandes_Pieces.Description"
1055: Else
1060: If m_eForm = enumFormSource.I_ACHAT_ELEC Or m_eForm = enumFormSource.I_ACHAT_MEC Then
1065: Call rstBCPiece.Close()
							
1070: If m_eForm = enumFormSource.I_ACHAT_ELEC Then
1075: Call rstBCPiece.Open("SELECT * FROM GRB_BonsCommandes_Pieces LEFT JOIN GRB_InventaireElec ON GRB_BonsCommandes_Pieces.NoItem = GRB_InventaireElec.NoItem WHERE NoBonCommande = '" & sNoBC & "' AND NoFournisseur = " & rstBC.Fields("NoFournisseur").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
1080: Else
1085: Call rstBCPiece.Open("SELECT * FROM GRB_BonsCommandes_Pieces LEFT JOIN GRB_InventaireMec ON GRB_BonsCommandes_Pieces.NoItem = GRB_InventaireMec.NoItem WHERE NoBonCommande = '" & sNoBC & "' AND NoFournisseur = " & rstBC.Fields("NoFournisseur").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
1090: End If
							testgll = "GRB_BonsCommandes_Pieces.NoItem"
1095: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_recu.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							DR_Commande_recu.Sections("Section1").Controls("txtNoItem").DataField = "GRB_BonsCommandes_Pieces.NoItem"
1100: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_recu.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							DR_Commande_recu.Sections("Section1").Controls("txtDescription").DataField = "GRB_BonsCommandes_Pieces.Description"
							
1105: End If
1110: End If
					
1115: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_recu.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande_recu.DataSource = rstBCPiece
					
1120: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_recu.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande_recu.Sections("Section2").Controls("lblfournisseur").Caption = rstFournisseur.Fields("NomFournisseur").Value
1125: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_recu.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande_recu.Sections("Section2").Controls("lblprojet").Caption = rstBC.Fields("NoProjet").Value
1130: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_recu.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_Commande_recu.Sections("Section5").Controls("lbldatereq").Caption = rstBC.Fields("DateRequise").Value
					
1135: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande_recu.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call DR_Commande_recu.Show(VB6.FormShowConstants.Modal)
1140: End If
1145: Else
1150: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
1155: If m_eImpRetour = frmChoixImpressionRetourMarchandise.enumImpressionRetour.MODE_RETOUR Then
1160: Call ImprimerRetour(rstBC.Fields("NoBonCommande").Value, rstBC.Fields("NoFournisseur").Value, rstBC.Fields("VotreNoSoum").Value)
1165: Call ImprimerRetourDossier(rstBC.Fields("NoBonCommande").Value, rstBC.Fields("NoFournisseur").Value)
1170: End If
1175: End If
1180: End If
			
			'Prochain enregistrement
1185: Call rstBC.MoveNext()
			
1190: Call rstBCPiece.Close()
			
1195: Call rstConfig.Close()
			
1200: Call rstFournisseur.Close()
1205: Loop 
		
1210: 'UPGRADE_NOTE: Object rstFournisseur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFournisseur = Nothing
1215: 'UPGRADE_NOTE: Object rstConfig may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstConfig = Nothing
1220: 'UPGRADE_NOTE: Object rstBCPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBCPiece = Nothing
		
1225: Call g_connData.Execute("DELETE * FROM GRB_BonsCommandes_Pieces WHERE NoBonCommande = '" & sNoBC & "'")
1230: Call g_connData.Execute("DELETE * FROM GRB_BonsCommandes WHERE NoBonCommande = '" & sNoBC & "'")
		
1235: Call Me.Close()
		
1240: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
1245: Exit Sub
		
AfficherErreur: 
		
1250: Call AfficherErreur("frmBonCommande", "cmdImprimer_Click", Err, Erl())
	End Sub
	
	Private Sub ImprimerRetour(ByVal sNoRetour As String, ByVal iNoFRS As Short, ByVal sNoRMA As String)
		Dim DR_Retour As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBCPiece As ADODB.Recordset
15: Dim rstFRS As ADODB.Recordset
		
20: rstBCPiece = New ADODB.Recordset
		
25: Call rstBCPiece.Open("SELECT * FROM GRB_BonsCommandes_Pieces WHERE NoBonCommande = '" & sNoRetour & "' AND NoFournisseur = " & iNoFRS, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
30: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Retour.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Retour.DataSource = rstBCPiece
		
35: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Retour.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Retour.Orientation = MSDataReportLib.OrientationConstants.rptOrientLandscape
		
40: rstFRS = New ADODB.Recordset
		
45: Call rstFRS.Open("SELECT NomFournisseur FROM GRB_Fournisseur WHERE IDFRS = " & iNoFRS, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
50: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Retour.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Retour.Sections("Section2").Controls("lblFournisseur").Caption = rstFRS.Fields("NomFournisseur").Value
		
55: Call rstFRS.Close()
60: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
		
65: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Retour.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Retour.Sections("Section2").Controls("lblNoProjet").Caption = sNoRetour
70: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Retour.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Retour.Sections("Section2").Controls("lblNoRMA").Caption = sNoRMA
75: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Retour.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Retour.Sections("Section2").Controls("lblDate").Caption = ConvertDate(Today)
		
80: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Retour.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_Retour.Show(VB6.FormShowConstants.Modal)
		
85: Call rstBCPiece.Close()
90: 'UPGRADE_NOTE: Object rstBCPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBCPiece = Nothing
		
95: Exit Sub
		
AfficherErreur: 
		
100: Call AfficherErreur("frmBonCommande", "ImprimerRetour", Err, Erl())
	End Sub
	
	Private Sub ImprimerRetourDossier(ByVal sNoRetour As String, ByVal iNoFRS As Short)
		Dim DR_Commande As Object
		Dim DR_Retour As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBC As ADODB.Recordset
15: Dim rstBCPiece As ADODB.Recordset
20: Dim rstFRS As ADODB.Recordset
		
25: rstBC = New ADODB.Recordset
30: rstBCPiece = New ADODB.Recordset
		
35: Call rstBC.Open("SELECT * FROM GRB_BonsCommandes WHERE NoBonCommande = '" & sNoRetour & "' AND NoFournisseur = " & iNoFRS, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
40: Call rstBCPiece.Open("SELECT * FROM GRB_BonsCommandes_Pieces WHERE NoBonCommande = '" & sNoRetour & "' AND NoFournisseur = " & iNoFRS, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
45: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Retour.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Retour.DataSource = rstBCPiece
		
50: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Retour.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Retour.Orientation = MSDataReportLib.OrientationConstants.rptOrientLandscape
		
55: rstFRS = New ADODB.Recordset
		
60: Call rstFRS.Open("SELECT * FROM GRB_Fournisseur WHERE IDFRS = " & iNoFRS, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
65: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Commande.Orientation = MSDataReportLib.OrientationConstants.rptOrientLandscape
		
70: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Caption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Commande.Caption = "Retour de marchandise"
		
75: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Commande.Sections("Section2").Controls("lblTitreBC").Caption = "# RMA"
		
80: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Commande.Sections("Section2").Controls("lblTitreCommande").Caption = "RETOUR DE MARCHANDISE"
		
85: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Commande.Sections("Section2").Controls("lblTitreNoSoum").Caption = "Notre #"
		
90: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstBC.Fields("VotreNoSoum").Value) Then
95: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.Sections("Section2").Controls("lblNoBC").Caption = rstBC.Fields("VotreNoSoum").Value
100: Else
105: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.Sections("Section2").Controls("lblNoBC").Caption = vbNullString
110: End If
		
115: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstBC.Fields("Commentaire").Value) Then
120: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.Sections("Section3").Controls("lblCommentaire").Caption = rstBC.Fields("Commentaire").Value
125: Else
130: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.Sections("Section3").Controls("lblCommentaire").Caption = vbNullString
135: End If
		
140: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Commande.Sections("section2").Controls("lblCommandePar").Caption = rstBC.Fields("CommandePar").Value
		
145: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstBC.Fields("Attention").Value) Then
150: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.Sections("section2").Controls("lblContact").Caption = rstBC.Fields("Attention").Value
155: Else
160: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.Sections("Section2").Controls("lblContact").Caption = vbNullString
165: End If
		
170: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Commande.Sections("section2").Controls("lblDate").Caption = rstBC.Fields("DateCommande").Value
		
175: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstBC.Fields("DateRequise").Value) Then
180: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.Sections("section2").Controls("lblDateRequise").Caption = rstBC.Fields("DateRequise").Value
185: Else
190: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.Sections("section2").Controls("lblDateRequise").Caption = vbNullString
195: End If
		
200: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Commande.Sections("section2").Controls("lblFax").Caption = rstFRS.Fields("Fax").Value
205: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Commande.Sections("section2").Controls("lblFournisseur").Caption = rstFRS.Fields("NomFournisseur").Value
210: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Commande.Sections("section2").Controls("lblTel").Caption = rstFRS.Fields("telephonne").Value
		
215: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Commande.Sections("Section2").Controls("lblNoSoum").Caption = rstBC.Fields("NoBonCommande").Value
		
220: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Commande.Sections("Section3").Controls("lblTotalFin").Caption = Conversion_Renamed(rstBC.Fields("total"), ModuleMain.enumConvert.MODE_ARGENT)
		
225: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstBC.Fields("Transport").Value) Then
230: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.Sections("section2").Controls("lblTransport").Caption = rstBC.Fields("Transport").Value
235: Else
240: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Commande.Sections("section2").Controls("lblTransport").Caption = " "
245: End If
		
250: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Commande.Sections("Section3").Controls("lblPiedPage").Visible = False
		
260: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Commande.DataSource = rstBCPiece
		
265: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_Commande.Show(VB6.FormShowConstants.Modal)
		
270: Call rstFRS.Close()
275: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
		
280: Call rstBC.Close()
285: 'UPGRADE_NOTE: Object rstBC may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBC = Nothing
		
290: Call rstBCPiece.Close()
295: 'UPGRADE_NOTE: Object rstBCPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBCPiece = Nothing
		
300: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
305: Exit Sub
		
AfficherErreur: 
		
310: Call AfficherErreur("frmBonCommande", "ImprimerRetourDossier", Err, Erl())
	End Sub
	
	Private Sub cmdInstructions_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdInstructions.Click
		
5: On Error GoTo AfficherErreur
		
10: Call OuvrirForm(FrmBonCommande_Instruction, True)
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmBonCommande", "cmdInstructions_Click", Err, Erl())
	End Sub
	
	
	
	Private Sub mvwDate_DateClick(ByVal eventSender As System.Object, ByVal eventArgs As AxMSComCtl2.DMonthViewEvents_DateClickEvent) Handles mvwDate.DateClick
		
5: On Error GoTo AfficherErreur
		
10: txtDateRequise.Text = ConvertDate(eventArgs.DateClicked)
		
15: mvwDate.Visible = False
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmBonCommande", "mvwDate_DateClick", Err, Erl())
	End Sub
	
	Private Sub mvwDate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mvwDate.Leave
		
5: On Error GoTo AfficherErreur
		
10: mvwDate.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmBonCommande", "mvwDate_LostFocus", Err, Erl())
	End Sub
	
	Private Sub EnregistrerBonCommandeRetourMarchandiseProjet()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBC As ADODB.Recordset
15: Dim rstBCPiece As ADODB.Recordset
20: Dim rstPiece As ADODB.Recordset
25: Dim rstFRS As ADODB.Recordset
30: Dim iCompteur As Short
35: Dim dblTotal As Double
40: Dim sWhere As String
45: Dim sWherePiece As String
50: Dim sWhereNoLigne As String
55: Dim sEscompte As String
		
		'Recordset source
60: sWhere = "(IDProjet = '" & m_sNoProjet & "')"
		
65: sWherePiece = "GRB_Projet_Pieces.NumItem In ("
70: sWhereNoLigne = "GRB_Projet_Pieces.NuméroLigne In ("
		
75: For iCompteur = 1 To m_collPieces.Count()
80: If iCompteur <> m_collPieces.Count() Then
85: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPieces(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWherePiece = sWherePiece & "'" & Replace(m_collPieces.Item(iCompteur), "'", "''") & "', "
90: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collNoLigne(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWhereNoLigne = sWhereNoLigne & m_collNoLigne.Item(iCompteur) & ", "
95: Else
100: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPieces(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWherePiece = sWherePiece & "'" & Replace(m_collPieces.Item(iCompteur), "'", "''") & "')"
105: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collNoLigne(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWhereNoLigne = sWhereNoLigne & m_collNoLigne.Item(iCompteur) & ")"
110: End If
115: Next 
		
120: rstFRS = New ADODB.Recordset
125: rstBC = New ADODB.Recordset
130: rstPiece = New ADODB.Recordset
135: rstBCPiece = New ADODB.Recordset
		
140: sWhere = sWhere & " AND " & sWherePiece & " AND " & sWhereNoLigne
		
145: Call rstFRS.Open("SELECT DISTINCT GRB_Projet_Pieces.IDFRS, GRB_Fournisseur.CondTransport FROM GRB_Projet_Pieces INNER JOIN GRB_Fournisseur ON GRB_Projet_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Recordsets destinations
150: Call rstBC.Open("SELECT * FROM GRB_BonsCommandes", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
155: Do While Not rstFRS.EOF
160: Call rstBC.AddNew()
			
			'Enregistrement du bon
165: rstBC.Fields("NoBonCommande").Value = txtVotreNoSoum.Text
170: rstBC.Fields("NoFournisseur").Value = rstFRS.Fields("IDFRS").Value
175: rstBC.Fields("NoProjet").Value = m_sNoProjet
180: rstBC.Fields("Attention").Value = ""
			
185: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstFRS.Fields("CondTransport").Value) And rstFRS.Fields("CondTransport").Value <> vbNullString Then
190: rstBC.Fields("Transport").Value = rstFRS.Fields("CondTransport").Value
195: Else
200: rstBC.Fields("Transport").Value = "Votre camion"
205: End If
			
210: rstBC.Fields("DateRequise").Value = ConvertDate(Today)
215: rstBC.Fields("DateCommande").Value = ConvertDate(Today)
			
220: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
225: rstBC.Fields("CommandePar").Value = m_sEmploye
230: Else
235: rstBC.Fields("CommandePar").Value = g_sEmploye
240: End If
			
245: rstBC.Fields("LangueImpression").Value = "Français"
			
250: sWhere = "(IDProjet = '" & m_sNoProjet & "' AND IDFRS = " & rstFRS.Fields("IDFRS").Value & ")"
			
255: sWherePiece = "NumItem In ("
260: sWhereNoLigne = "NuméroLigne In ("
			
265: For iCompteur = 1 To m_collPieces.Count()
270: If iCompteur <> m_collPieces.Count() Then
275: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPieces(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sWherePiece = sWherePiece & "'" & Replace(m_collPieces.Item(iCompteur), "'", "''") & "', "
280: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collNoLigne(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sWhereNoLigne = sWhereNoLigne & m_collNoLigne.Item(iCompteur) & ", "
285: Else
290: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPieces(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sWherePiece = sWherePiece & "'" & Replace(m_collPieces.Item(iCompteur), "'", "''") & "')"
295: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collNoLigne(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sWhereNoLigne = sWhereNoLigne & m_collNoLigne.Item(iCompteur) & ")"
300: End If
305: Next 
			
310: sWhere = sWhere & " AND " & sWherePiece & " AND " & sWhereNoLigne
			
315: Call rstPiece.Open("SELECT * FROM GRB_Projet_Pieces WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
320: dblTotal = 0
			
			'Enregistrement des pièces
325: Do While Not rstPiece.EOF
330: Call rstBCPiece.Open("SELECT * FROM GRB_BonsCommandes_Pieces WHERE NoItem = '" & Replace(rstPiece.Fields("NumItem").Value, "'", "''") & "' AND NoFournisseur = " & rstPiece.Fields("IDFRS").Value & " AND NoBonCommande = '" & txtVotreNoSoum.Text & "' AND Prix = '" & rstPiece.Fields("PrixOrigine").Value & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
335: If Trim(rstPiece.Fields("ESCOMPTE").Value) <> "" Then
340: sEscompte = Replace(Replace(rstPiece.Fields("ESCOMPTE").Value, ".", ","), "%", "")
					
345: Do While CDbl(sEscompte) > 1
350: sEscompte = CStr(CDbl(sEscompte) / 100)
355: Loop 
					
360: dblTotal = dblTotal + CDbl(Conversion_Renamed(CStr((CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * (1 - CDbl(sEscompte))) * CDbl(Replace(rstPiece.Fields("Qté").Value, "-", vbNullString))), ModuleMain.enumConvert.MODE_DECIMAL))
365: Else
370: dblTotal = dblTotal + CDbl(Conversion_Renamed(CStr(CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * CDbl(Replace(rstPiece.Fields("Qté").Value, "-", vbNullString))), ModuleMain.enumConvert.MODE_DECIMAL))
375: End If
				
380: If rstBCPiece.EOF Then
385: Call rstBCPiece.AddNew()
					
390: rstBCPiece.Fields("NoBonCommande").Value = txtVotreNoSoum.Text
395: rstBCPiece.Fields("NoFournisseur").Value = rstPiece.Fields("IDFRS").Value
400: rstBCPiece.Fields("Qté").Value = Replace(rstPiece.Fields("Qté").Value, "-", vbNullString)
					
405: rstBCPiece.Fields("NoItem").Value = rstPiece.Fields("NumItem").Value
					
410: rstBCPiece.Fields("NuméroLigne").Value = rstPiece.Fields("NuméroLigne").Value
					
415: rstBCPiece.Fields("Description").Value = rstPiece.Fields("Desc_fr").Value
420: rstBCPiece.Fields("Manufact").Value = rstPiece.Fields("Manufact").Value
					
425: rstBCPiece.Fields("Prix").Value = rstPiece.Fields("PrixOrigine").Value
					
430: If rstPiece.Fields("Escompte").Value <> vbNullString Then
435: rstBCPiece.Fields("Escompte").Value = rstPiece.Fields("Escompte").Value
440: Else
445: rstBCPiece.Fields("Escompte").Value = "0"
450: End If
					
455: If Trim(rstPiece.Fields("Escompte").Value) <> "" Then
460: sEscompte = Replace(Replace(rstPiece.Fields("ESCOMPTE").Value, ".", ","), "%", "")
						
465: Do While CDbl(sEscompte) > 1
470: sEscompte = CStr(CDbl(sEscompte) / 100)
475: Loop 
						
480: rstBCPiece.Fields("Total").Value = Conversion_Renamed(CStr((CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * (1 - CDbl(sEscompte))) * CDbl(Replace(rstPiece.Fields("Qté").Value, "-", vbNullString))), ModuleMain.enumConvert.MODE_DECIMAL)
485: Else
490: rstBCPiece.Fields("Total").Value = Conversion_Renamed(CStr(CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * CDbl(Replace(rstPiece.Fields("Qté").Value, "-", vbNullString))), ModuleMain.enumConvert.MODE_DECIMAL)
495: End If
500: Else
505: rstBCPiece.Fields("Qté").Value = CDbl(rstBCPiece.Fields("Qté").Value) + CDbl(Replace(rstPiece.Fields("Qté").Value, "-", vbNullString))
					
510: rstBCPiece.Fields("NuméroLigne").Value = rstBCPiece.Fields("NuméroLigne").Value & ", " & rstPiece.Fields("NuméroLigne").Value
					
515: If Trim(rstPiece.Fields("Escompte").Value) <> "" Then
520: sEscompte = Replace(Replace(rstPiece.Fields("ESCOMPTE").Value, ".", ","), "%", "")
						
525: Do While CDbl(sEscompte) > 1
530: sEscompte = CStr(CDbl(sEscompte) / 100)
535: Loop 
						
540: rstBCPiece.Fields("Total").Value = CDbl(Replace(rstBCPiece.Fields("Total").Value, ".", ",")) + (CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * (1 - CDbl(sEscompte)) * CDbl(Replace(rstPiece.Fields("Qté").Value, "-", vbNullString)))
545: Else
550: rstBCPiece.Fields("Total").Value = CDbl(Replace(rstBCPiece.Fields("Total").Value, ".", ",")) + (CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * CDbl(Replace(rstPiece.Fields("Qté").Value, "-", vbNullString)))
555: End If
560: End If
				
565: Call rstBCPiece.Update()
				
570: Call rstBCPiece.Close()
				
575: Call rstPiece.MoveNext()
580: Loop 
			
585: Call rstPiece.Close()
			
590: rstBC.Fields("Total").Value = Conversion_Renamed(CStr(dblTotal), ModuleMain.enumConvert.MODE_DECIMAL)
			
595: Call rstBC.Update()
			
600: Call rstFRS.MoveNext()
605: Loop 
		
610: Call rstFRS.Close()
615: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
		
620: Call rstBC.Close()
625: 'UPGRADE_NOTE: Object rstBC may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBC = Nothing
		
630: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
635: 'UPGRADE_NOTE: Object rstBCPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBCPiece = Nothing
		
640: Exit Sub
		
AfficherErreur: 
		
645: Call AfficherErreur("frmBonCommande", "EnregistrerBonCommandeRetourMarchandiseProjet", Err, Erl())
	End Sub
	
	Private Sub EnregistrerBonCommandeRetourMarchandiseAchat()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBC As ADODB.Recordset
15: Dim rstBCPiece As ADODB.Recordset
20: Dim rstPiece As ADODB.Recordset
25: Dim rstFRS As ADODB.Recordset
30: Dim iCompteur As Short
35: Dim dblTotal As Double
40: Dim sWhere As String
45: Dim sWherePiece As String
50: Dim sWhereNoLigne As String
55: Dim sEscompte As String
		
		'Recordset source
60: sWhere = "(IDAchat = '" & m_sNoAchat & "' AND IndexAchat = " & m_iIndexAchat & ")"
		
65: sWherePiece = "GRB_Achat_Pieces.PIECE In ("
70: sWhereNoLigne = "GRB_Achat_Pieces.NuméroLigne In ("
		
75: For iCompteur = 1 To m_collPieces.Count()
80: If iCompteur <> m_collPieces.Count() Then
85: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPieces(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWherePiece = sWherePiece & "'" & Replace(m_collPieces.Item(iCompteur), "'", "''") & "', "
90: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collNoLigne(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWhereNoLigne = sWhereNoLigne & m_collNoLigne.Item(iCompteur) & ", "
95: Else
100: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPieces(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWherePiece = sWherePiece & "'" & Replace(m_collPieces.Item(iCompteur), "'", "''") & "')"
105: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collNoLigne(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWhereNoLigne = sWhereNoLigne & m_collNoLigne.Item(iCompteur) & ")"
110: End If
115: Next 
		
120: rstFRS = New ADODB.Recordset
125: rstBC = New ADODB.Recordset
130: rstPiece = New ADODB.Recordset
135: rstBCPiece = New ADODB.Recordset
		
140: sWhere = sWhere & " AND " & sWherePiece & " AND " & sWhereNoLigne
		
145: Call rstFRS.Open("SELECT DISTINCT GRB_Achat_Pieces.IDFRS, GRB_Fournisseur.CondTransport FROM GRB_Achat_Pieces INNER JOIN GRB_Fournisseur ON GRB_Achat_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Recordsets destinations
150: Call rstBC.Open("SELECT * FROM GRB_BonsCommandes", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
155: Do While Not rstFRS.EOF
160: Call rstBC.AddNew()
			
			'Enregistrement du bon
165: rstBC.Fields("NoBonCommande").Value = txtVotreNoSoum.Text
170: rstBC.Fields("NoFournisseur").Value = rstFRS.Fields("IDFRS").Value
175: rstBC.Fields("NoProjet").Value = m_sNoAchat & " - " & m_iIndexAchat
180: rstBC.Fields("Attention").Value = ""
			
185: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstFRS.Fields("CondTransport").Value) And rstFRS.Fields("CondTransport").Value <> vbNullString Then
190: rstBC.Fields("Transport").Value = rstFRS.Fields("CondTransport").Value
195: Else
200: rstBC.Fields("Transport").Value = "Votre camion"
205: End If
			
210: rstBC.Fields("DateRequise").Value = ConvertDate(Today)
215: rstBC.Fields("DateCommande").Value = ConvertDate(Today)
			
220: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
225: rstBC.Fields("CommandePar").Value = m_sEmploye
230: Else
235: rstBC.Fields("CommandePar").Value = g_sEmploye
240: End If
			
245: rstBC.Fields("LangueImpression").Value = "Français"
			
250: sWhere = "(IDAchat = '" & m_sNoAchat & "' AND IndexAchat = " & m_iIndexAchat & " AND IDFRS = " & rstFRS.Fields("IDFRS").Value & ")"
			
255: sWherePiece = "PIECE In ("
260: sWhereNoLigne = "NuméroLigne In ("
			
265: For iCompteur = 1 To m_collPieces.Count()
270: If iCompteur <> m_collPieces.Count() Then
275: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPieces(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sWherePiece = sWherePiece & "'" & Replace(m_collPieces.Item(iCompteur), "'", "''") & "', "
280: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collNoLigne(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sWhereNoLigne = sWhereNoLigne & m_collNoLigne.Item(iCompteur) & ", "
285: Else
290: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPieces(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sWherePiece = sWherePiece & "'" & Replace(m_collPieces.Item(iCompteur), "'", "''") & "')"
295: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collNoLigne(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sWhereNoLigne = sWhereNoLigne & m_collNoLigne.Item(iCompteur) & ")"
300: End If
305: Next 
			
310: sWhere = sWhere & " AND " & sWherePiece & " AND " & sWhereNoLigne
			
315: Call rstPiece.Open("SELECT * FROM GRB_Achat_Pieces WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
320: dblTotal = 0
			
			'Enregistrement des pièces
325: Do While Not rstPiece.EOF
330: Call rstBCPiece.Open("SELECT * FROM GRB_BonsCommandes_Pieces WHERE NoItem = '" & Replace(rstPiece.Fields("PIECE").Value, "'", "''") & "' AND NoFournisseur = " & rstPiece.Fields("IDFRS").Value & " AND NoBonCommande = '" & txtVotreNoSoum.Text & "' AND Prix = '" & rstPiece.Fields("PrixOrigine").Value & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
335: If Trim(rstPiece.Fields("ESCOMPTE").Value) <> "" Then
340: sEscompte = Replace(Replace(rstPiece.Fields("ESCOMPTE").Value, ".", ","), "%", "")
					
345: Do While CDbl(sEscompte) > 1
350: sEscompte = CStr(CDbl(sEscompte) / 100)
355: Loop 
					
360: dblTotal = dblTotal + CDbl(Conversion_Renamed(CStr((CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * (1 - CDbl(sEscompte))) * CDbl(Replace(rstPiece.Fields("Qté").Value, "-", vbNullString))), ModuleMain.enumConvert.MODE_DECIMAL))
365: Else
370: dblTotal = dblTotal + CDbl(Conversion_Renamed(CStr(CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * CDbl(Replace(rstPiece.Fields("Qté").Value, "-", vbNullString))), ModuleMain.enumConvert.MODE_DECIMAL))
375: End If
				
380: If rstBCPiece.EOF Then
385: Call rstBCPiece.AddNew()
					
390: rstBCPiece.Fields("NoBonCommande").Value = txtVotreNoSoum.Text
395: rstBCPiece.Fields("NoFournisseur").Value = rstPiece.Fields("IDFRS").Value
400: rstBCPiece.Fields("Qté").Value = Replace(rstPiece.Fields("Qté").Value, "-", vbNullString)
					
405: rstBCPiece.Fields("NoItem").Value = rstPiece.Fields("PIECE").Value
					
410: rstBCPiece.Fields("NuméroLigne").Value = rstPiece.Fields("NuméroLigne").Value
					
415: rstBCPiece.Fields("Description").Value = rstPiece.Fields("Desc_fr").Value
420: rstBCPiece.Fields("Manufact").Value = rstPiece.Fields("Manufact").Value
					
425: rstBCPiece.Fields("Prix").Value = rstPiece.Fields("PrixOrigine").Value
					
430: If rstPiece.Fields("Escompte").Value <> vbNullString Then
435: rstBCPiece.Fields("Escompte").Value = rstPiece.Fields("Escompte").Value
440: Else
445: rstBCPiece.Fields("Escompte").Value = "0"
450: End If
					
455: If Trim(rstPiece.Fields("Escompte").Value) <> "" Then
460: sEscompte = Replace(Replace(rstPiece.Fields("ESCOMPTE").Value, ".", ","), "%", "")
						
465: Do While CDbl(sEscompte) > 1
470: sEscompte = CStr(CDbl(sEscompte) / 100)
475: Loop 
						
480: rstBCPiece.Fields("Total").Value = Conversion_Renamed(CStr((CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * (1 - CDbl(sEscompte))) * CDbl(Replace(rstPiece.Fields("Qté").Value, "-", vbNullString))), ModuleMain.enumConvert.MODE_DECIMAL)
485: Else
490: rstBCPiece.Fields("Total").Value = Conversion_Renamed(CStr(CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * CDbl(Replace(rstPiece.Fields("Qté").Value, "-", vbNullString))), ModuleMain.enumConvert.MODE_DECIMAL)
495: End If
500: Else
505: rstBCPiece.Fields("Qté").Value = CDbl(rstBCPiece.Fields("Qté").Value) + CDbl(Replace(rstPiece.Fields("Qté").Value, "-", vbNullString))
					
510: rstBCPiece.Fields("NuméroLigne").Value = rstBCPiece.Fields("NuméroLigne").Value & ", " & rstPiece.Fields("NuméroLigne").Value
					
515: If Trim(rstPiece.Fields("Escompte").Value) <> "" Then
520: sEscompte = Replace(Replace(rstPiece.Fields("ESCOMPTE").Value, ".", ","), "%", "")
						
525: Do While CDbl(sEscompte) > 1
530: sEscompte = CStr(CDbl(sEscompte) / 100)
535: Loop 
						
540: rstBCPiece.Fields("Total").Value = CDbl(Replace(rstBCPiece.Fields("Total").Value, ".", ",")) + (CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * (1 - CDbl(sEscompte)) * CDbl(Replace(rstPiece.Fields("Qté").Value, "-", vbNullString)))
545: Else
550: rstBCPiece.Fields("Total").Value = CDbl(Replace(rstBCPiece.Fields("Total").Value, ".", ",")) + (CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * CDbl(Replace(rstPiece.Fields("Qté").Value, "-", vbNullString)))
555: End If
560: End If
				
565: Call rstBCPiece.Update()
				
570: Call rstBCPiece.Close()
				
575: Call rstPiece.MoveNext()
580: Loop 
			
585: Call rstPiece.Close()
			
590: rstBC.Fields("Total").Value = Conversion_Renamed(CStr(dblTotal), ModuleMain.enumConvert.MODE_DECIMAL)
			
595: Call rstBC.Update()
			
600: Call rstFRS.MoveNext()
605: Loop 
		
610: Call rstFRS.Close()
615: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
		
620: Call rstBC.Close()
625: 'UPGRADE_NOTE: Object rstBC may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBC = Nothing
		
630: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
635: 'UPGRADE_NOTE: Object rstBCPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBCPiece = Nothing
		
640: Exit Sub
		
AfficherErreur: 
		
645: Call AfficherErreur("frmBonCommande", "EnregistrerBonCommandeRetourMarchandiseAchat", Err, Erl())
	End Sub
	
	Private Sub EnregistrerBonCommandeProjet()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBC As ADODB.Recordset
15: Dim rstBCPiece As ADODB.Recordset
20: Dim rstPiece As ADODB.Recordset
25: Dim rstFRS As ADODB.Recordset
30: Dim iCompteur As Short
35: Dim dblTotal As Double
40: Dim sType As String
45: Dim sWhere As String
50: Dim sWherePiece As String
55: Dim sWhereNoLigne As String
60: Dim sEscompte As String
		
65: If m_eForm = enumFormSource.I_PROJET_ELEC Then
70: sType = "E"
75: Else
80: sType = "M"
85: End If
		
		'Recordset source
90: sWhere = "(IDProjet = '" & m_sNoProjet & "' AND Type = '" & sType & "')"
		
95: sWherePiece = "GRB_Projet_Pieces.NumItem In ("
100: sWhereNoLigne = "GRB_Projet_Pieces.NuméroLigne In ("
		
105: For iCompteur = 1 To m_collPieces.Count()
110: If iCompteur <> m_collPieces.Count() Then
115: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPieces(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWherePiece = sWherePiece & "'" & Replace(m_collPieces.Item(iCompteur), "'", "''") & "', "
120: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collNoLigne(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWhereNoLigne = sWhereNoLigne & m_collNoLigne.Item(iCompteur) & ", "
125: Else
130: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPieces(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWherePiece = sWherePiece & "'" & Replace(m_collPieces.Item(iCompteur), "'", "''") & "')"
135: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collNoLigne(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWhereNoLigne = sWhereNoLigne & m_collNoLigne.Item(iCompteur) & ")"
140: End If
145: Next 
		
150: rstBC = New ADODB.Recordset
155: rstFRS = New ADODB.Recordset
160: rstPiece = New ADODB.Recordset
165: rstBCPiece = New ADODB.Recordset
		
170: sWhere = sWhere & " AND " & sWherePiece & " AND " & sWhereNoLigne
		
175: Call rstFRS.Open("SELECT DISTINCT GRB_Projet_Pieces.IDFRS, GRB_Fournisseur.CondTransport FROM GRB_Projet_Pieces INNER JOIN GRB_Fournisseur ON GRB_Projet_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Recordsets destinations
180: Call rstBC.Open("SELECT * FROM GRB_BonsCommandes", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
185: Do While Not rstFRS.EOF
190: Call rstBC.AddNew()
			
			'Enregistrement du bon
195: rstBC.Fields("NoBonCommande").Value = txtNoBC.Text
200: rstBC.Fields("NoFournisseur").Value = rstFRS.Fields("IDFRS").Value
205: rstBC.Fields("NoProjet").Value = m_sNoProjet
210: rstBC.Fields("Attention").Value = ""
			
215: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstFRS.Fields("CondTransport").Value) And rstFRS.Fields("CondTransport").Value <> vbNullString Then
220: rstBC.Fields("Transport").Value = rstFRS.Fields("CondTransport").Value
225: Else
230: rstBC.Fields("Transport").Value = "Votre camion"
235: End If
			
240: If m_eForm = enumFormSource.I_PROJET_ELEC Then
245: rstBC.Fields("DateRequise").Value = ""
250: Else
255: rstBC.Fields("DateRequise").Value = ConvertDate(Today)
260: End If
			
265: rstBC.Fields("DateCommande").Value = ConvertDate(Today)
270: rstBC.Fields("CommandePar").Value = g_sEmploye
			
275: If m_eLangage = enumLangage.FRANCAIS Then
280: rstBC.Fields("LangueImpression").Value = "Français"
285: Else
290: rstBC.Fields("LangueImpression").Value = "Anglais"
295: End If
			
300: rstBC.Fields("Type").Value = sType
			
305: sWhere = "(IDProjet = '" & m_sNoProjet & "' AND IDFRS = " & rstFRS.Fields("IDFRS").Value & ")"
			
310: sWherePiece = "NumItem In ("
315: sWhereNoLigne = "NuméroLigne In ("
			
320: For iCompteur = 1 To m_collPieces.Count()
325: If iCompteur <> m_collPieces.Count() Then
330: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPieces(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sWherePiece = sWherePiece & "'" & Replace(m_collPieces.Item(iCompteur), "'", "''") & "', "
335: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collNoLigne(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sWhereNoLigne = sWhereNoLigne & m_collNoLigne.Item(iCompteur) & ", "
340: Else
345: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPieces(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sWherePiece = sWherePiece & "'" & Replace(m_collPieces.Item(iCompteur), "'", "''") & "')"
350: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collNoLigne(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sWhereNoLigne = sWhereNoLigne & m_collNoLigne.Item(iCompteur) & ")"
355: End If
360: Next 
			
365: sWhere = sWhere & " AND " & sWherePiece & " AND " & sWhereNoLigne
			
370: Call rstPiece.Open("SELECT * FROM GRB_Projet_Pieces WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
375: dblTotal = 0
			
			'Enregistrement des pièces
380: Do While Not rstPiece.EOF
385: Call rstBCPiece.Open("SELECT * FROM GRB_BonsCommandes_Pieces WHERE NoItem = '" & Replace(rstPiece.Fields("NumItem").Value, "'", "''") & "' AND NoFournisseur = " & rstPiece.Fields("IDFRS").Value & " AND NoBonCommande = '" & txtNoBC.Text & "' AND Prix = '" & rstPiece.Fields("PrixOrigine").Value & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
390: If Trim(rstPiece.Fields("ESCOMPTE").Value) <> "" Then
395: sEscompte = Replace(Replace(rstPiece.Fields("ESCOMPTE").Value, ".", ","), "%", "")
					
400: Do While CDbl(sEscompte) > 1
405: sEscompte = CStr(CDbl(sEscompte) / 100)
410: Loop 
					
415: dblTotal = dblTotal + CDbl(Conversion_Renamed(CStr((CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * (1 - CDbl(sEscompte))) * CDbl(rstPiece.Fields("Qté").Value)), ModuleMain.enumConvert.MODE_DECIMAL))
420: Else
425: dblTotal = dblTotal + CDbl(Conversion_Renamed(CStr(CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * rstPiece.Fields("Qté").Value), ModuleMain.enumConvert.MODE_DECIMAL))
430: End If
				
				'Si la pièce n'existe pas, on l'ajoute
				'sinon, on change la quantité et le total
435: If rstBCPiece.EOF Then
440: Call rstBCPiece.AddNew()
					
445: rstBCPiece.Fields("Type").Value = sType
					
450: rstBCPiece.Fields("NoBonCommande").Value = txtNoBC.Text
455: rstBCPiece.Fields("NoFournisseur").Value = rstPiece.Fields("IDFRS").Value
460: rstBCPiece.Fields("Qté").Value = rstPiece.Fields("Qté").Value
					
465: rstBCPiece.Fields("NoItem").Value = rstPiece.Fields("NumItem").Value
					
470: rstBCPiece.Fields("NuméroLigne").Value = rstPiece.Fields("NuméroLigne").Value
					
475: If rstBC.Fields("LangueImpression").Value = "Français" Then
480: rstBCPiece.Fields("Description").Value = rstPiece.Fields("DESC_FR").Value
485: Else
490: rstBCPiece.Fields("Description").Value = rstPiece.Fields("DESC_EN").Value
495: End If
					
500: rstBCPiece.Fields("Manufact").Value = rstPiece.Fields("Manufact").Value
					
505: rstBCPiece.Fields("Prix").Value = rstPiece.Fields("PrixOrigine").Value
					
510: If rstPiece.Fields("Escompte").Value <> vbNullString Then
515: rstBCPiece.Fields("Escompte").Value = rstPiece.Fields("Escompte").Value
520: Else
525: rstBCPiece.Fields("Escompte").Value = "0"
530: End If
					
535: If Trim(rstPiece.Fields("Escompte").Value) <> "" Then
540: sEscompte = Replace(Replace(rstPiece.Fields("ESCOMPTE").Value, ".", ","), "%", "")
						
545: Do While CDbl(sEscompte) > 1
550: sEscompte = CStr(CDbl(sEscompte) / 100)
555: Loop 
						
560: rstBCPiece.Fields("Total").Value = Conversion_Renamed(CStr((CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * (1 - CDbl(sEscompte))) * CDbl(rstPiece.Fields("Qté").Value)), ModuleMain.enumConvert.MODE_DECIMAL)
565: Else
570: rstBCPiece.Fields("Total").Value = Conversion_Renamed(CStr(CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * rstPiece.Fields("Qté").Value), ModuleMain.enumConvert.MODE_DECIMAL)
575: End If
580: Else
585: rstBCPiece.Fields("Qté").Value = CDbl(rstBCPiece.Fields("Qté").Value) + CDbl(rstPiece.Fields("Qté").Value)
					
590: rstBCPiece.Fields("NuméroLigne").Value = rstBCPiece.Fields("NuméroLigne").Value & ", " & rstPiece.Fields("NuméroLigne").Value
					
595: If Trim(rstPiece.Fields("Escompte").Value) <> "" Then
600: sEscompte = Replace(Replace(rstPiece.Fields("ESCOMPTE").Value, ".", ","), "%", "")
						
605: Do While CDbl(sEscompte) > 1
610: sEscompte = CStr(CDbl(sEscompte) / 100)
615: Loop 
						
620: rstBCPiece.Fields("Total").Value = CDbl(Replace(rstBCPiece.Fields("Total").Value, ".", ",")) + (CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * (1 - CDbl(sEscompte)) * CDbl(rstPiece.Fields("Qté").Value))
625: Else
630: rstBCPiece.Fields("Total").Value = CDbl(Replace(rstBCPiece.Fields("Total").Value, ".", ",")) + (CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * CDbl(rstPiece.Fields("Qté").Value))
635: End If
640: End If
				
645: Call rstBCPiece.Update()
				
650: Call rstBCPiece.Close()
				
655: Call rstPiece.MoveNext()
660: Loop 
			
665: Call rstPiece.Close()
			
670: rstBC.Fields("Total").Value = Conversion_Renamed(CStr(dblTotal), ModuleMain.enumConvert.MODE_DECIMAL)
			
675: Call rstBC.Update()
			
680: Call rstFRS.MoveNext()
685: Loop 
		
690: Call rstFRS.Close()
695: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
		
700: Call rstBC.Close()
705: 'UPGRADE_NOTE: Object rstBC may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBC = Nothing
		
710: 'UPGRADE_NOTE: Object rstBCPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBCPiece = Nothing
715: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
720: Exit Sub
		
AfficherErreur: 
		
725: Call AfficherErreur("frmBonCommande", "EnregistrerBonCommandeProjet", Err, Erl())
	End Sub
	
	Private Sub EnregistrerBonCommandeAchat()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBC As ADODB.Recordset
15: Dim rstBCPiece As ADODB.Recordset
20: Dim rstPiece As ADODB.Recordset
25: Dim rstFRS As ADODB.Recordset
30: Dim iCompteur As Short
35: Dim dblTotal As Double
40: Dim sType As String
45: Dim sWhere As String
50: Dim sWherePiece As String
55: Dim sWhereNoLigne As String
60: Dim sEscompte As String
		
65: If m_eForm = enumFormSource.I_ACHAT_ELEC Then
70: sType = "E"
75: Else
80: sType = "M"
85: End If
		
		'Recordset source
90: sWhere = "(IDAchat = '" & m_sNoAchat & "' AND IndexAchat = " & m_iIndexAchat & ")"
		
95: sWherePiece = "GRB_Achat_Pieces.PIECE In ("
100: sWhereNoLigne = "GRB_Achat_Pieces.NuméroLigne In ("
		
105: For iCompteur = 1 To m_collPieces.Count()
110: If iCompteur <> m_collPieces.Count() Then
115: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPieces(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWherePiece = sWherePiece & "'" & Replace(m_collPieces.Item(iCompteur), "'", "''") & "', "
120: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collNoLigne(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWhereNoLigne = sWhereNoLigne & m_collNoLigne.Item(iCompteur) & ", "
125: Else
130: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPieces(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWherePiece = sWherePiece & "'" & Replace(m_collPieces.Item(iCompteur), "'", "''") & "')"
135: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collNoLigne(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWhereNoLigne = sWhereNoLigne & m_collNoLigne.Item(iCompteur) & ")"
140: End If
145: Next 
		
150: rstFRS = New ADODB.Recordset
155: rstBC = New ADODB.Recordset
160: rstPiece = New ADODB.Recordset
165: rstBCPiece = New ADODB.Recordset
		
170: sWhere = sWhere & " AND " & sWherePiece & " AND " & sWhereNoLigne
		
		'Recordset source
175: Call rstFRS.Open("SELECT DISTINCT GRB_Achat_Pieces.IDFRS, GRB_Fournisseur.CondTransport FROM GRB_Achat_Pieces INNER JOIN GRB_Fournisseur ON GRB_Achat_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Recordsets destinations
180: Call rstBC.Open("SELECT * FROM GRB_BonsCommandes", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
185: Do While Not rstFRS.EOF
190: Call rstBC.AddNew()
			
			'Enregistrement du bon
195: rstBC.Fields("NoBonCommande").Value = txtNoBC.Text
200: rstBC.Fields("NoFournisseur").Value = rstFRS.Fields("IDFRS").Value
205: rstBC.Fields("NoProjet").Value = m_sNoAchat
210: rstBC.Fields("Attention").Value = ""
			
215: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstFRS.Fields("CondTransport").Value) And rstFRS.Fields("CondTransport").Value <> vbNullString Then
220: rstBC.Fields("Transport").Value = rstFRS.Fields("CondTransport").Value
225: Else
230: rstBC.Fields("Transport").Value = "Votre camion"
235: End If
			
240: If m_eForm = enumFormSource.I_ACHAT_ELEC Then
245: rstBC.Fields("DateRequise").Value = ""
250: Else
255: rstBC.Fields("DateRequise").Value = ConvertDate(Today)
260: End If
			
265: rstBC.Fields("DateCommande").Value = ConvertDate(Today)
270: rstBC.Fields("CommandePar").Value = g_sEmploye
275: rstBC.Fields("LangueImpression").Value = "Français"
			
280: rstBC.Fields("Type").Value = sType
			
285: Call rstPiece.Open("SELECT * FROM GRB_Achat_Pieces WHERE " & sWhere & " AND IDFRS = " & rstFRS.Fields("IDFRS").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
290: dblTotal = 0
			
			'Enregistrement des pièces
295: Do While Not rstPiece.EOF
300: Call rstBCPiece.Open("SELECT * FROM GRB_BonsCommandes_Pieces WHERE NoItem = '" & Replace(rstPiece.Fields("PIECE").Value, "'", "''") & "' AND NoFournisseur = " & rstPiece.Fields("IDFRS").Value & " AND NoBonCommande = '" & txtNoBC.Text & "' AND Prix = '" & rstPiece.Fields("PrixOrigine").Value & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
305: If Trim(rstPiece.Fields("ESCOMPTE").Value) <> "" Then
310: sEscompte = Replace(Replace(rstPiece.Fields("ESCOMPTE").Value, ".", ","), "%", "")
					
315: Do While CDbl(sEscompte) > 1
320: sEscompte = CStr(CDbl(sEscompte) / 100)
325: Loop 
					
330: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstPiece.Fields("PrixOrigine").Value) Then
335: dblTotal = dblTotal + CDbl(Conversion_Renamed(CStr((CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * (1 - CDbl(sEscompte))) * CDbl(rstPiece.Fields("Qté").Value)), ModuleMain.enumConvert.MODE_DECIMAL))
340: End If
345: Else
350: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstPiece.Fields("PrixOrigine").Value) Then
355: dblTotal = dblTotal + CDbl(Conversion_Renamed(CStr(CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * rstPiece.Fields("Qté").Value), ModuleMain.enumConvert.MODE_DECIMAL))
360: End If
365: End If
				
				'Si la pièce n'existe pas, on l'ajoute
				'sinon, on change la quantité et le total
370: If rstBCPiece.EOF Then
375: Call rstBCPiece.AddNew()
					
380: rstBCPiece.Fields("Type").Value = sType
					
385: rstBCPiece.Fields("NoBonCommande").Value = txtNoBC.Text
390: rstBCPiece.Fields("NoFournisseur").Value = rstPiece.Fields("IDFRS").Value
395: rstBCPiece.Fields("Qté").Value = rstPiece.Fields("Qté").Value
					
400: rstBCPiece.Fields("NoItem").Value = rstPiece.Fields("PIECE").Value
					
405: rstBCPiece.Fields("NuméroLigne").Value = rstPiece.Fields("NuméroLigne").Value
					
410: rstBCPiece.Fields("Description").Value = rstPiece.Fields("Desc_fr").Value
415: rstBCPiece.Fields("Manufact").Value = rstPiece.Fields("Manufact").Value
					
420: rstBCPiece.Fields("Prix").Value = rstPiece.Fields("PrixOrigine").Value
					
425: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstPiece.Fields("Escompte").Value) And rstPiece.Fields("Escompte").Value <> vbNullString Then
430: rstBCPiece.Fields("Escompte").Value = rstPiece.Fields("Escompte").Value
435: Else
440: rstBCPiece.Fields("Escompte").Value = "0"
445: End If
					
450: If Trim(rstPiece.Fields("Escompte").Value) <> "" Then
455: sEscompte = Replace(Replace(rstPiece.Fields("ESCOMPTE").Value, ".", ","), "%", "")
						
460: Do While CDbl(sEscompte) > 1
465: sEscompte = CStr(CDbl(sEscompte) / 100)
470: Loop 
						
475: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstPiece.Fields("PrixOrigine").Value) Then
480: rstBCPiece.Fields("Total").Value = Conversion_Renamed(CStr((CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * (1 - CDbl(sEscompte))) * CDbl(rstPiece.Fields("Qté").Value)), ModuleMain.enumConvert.MODE_DECIMAL)
485: End If
490: Else
495: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstPiece.Fields("PrixOrigine").Value) Then
500: rstBCPiece.Fields("Total").Value = Conversion_Renamed(CStr(CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * rstPiece.Fields("Qté").Value), ModuleMain.enumConvert.MODE_DECIMAL)
505: End If
510: End If
515: Else
520: rstBCPiece.Fields("Qté").Value = CDbl(rstBCPiece.Fields("Qté").Value) + CDbl(rstPiece.Fields("Qté").Value)
					
525: rstBCPiece.Fields("NuméroLigne").Value = rstBCPiece.Fields("NuméroLigne").Value & ", " & rstPiece.Fields("NuméroLigne").Value
					
530: If Trim(rstPiece.Fields("Escompte").Value) <> "" Then
535: sEscompte = Replace(Replace(rstPiece.Fields("ESCOMPTE").Value, ".", ","), "%", "")
						
540: Do While CDbl(sEscompte) > 1
545: sEscompte = CStr(CDbl(sEscompte) / 100)
550: Loop 
						
555: rstBCPiece.Fields("Total").Value = CDbl(Replace(rstBCPiece.Fields("Total").Value, ".", ",")) + (CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * (1 - CDbl(sEscompte)) * CDbl(rstPiece.Fields("Qté").Value))
560: Else
565: rstBCPiece.Fields("Total").Value = CDbl(Replace(rstBCPiece.Fields("Total").Value, ".", ",")) + (CDbl(Replace(rstPiece.Fields("PrixOrigine").Value, ".", ",")) * CDbl(rstPiece.Fields("Qté").Value))
570: End If
575: End If
				
580: Call rstBCPiece.Update()
				
585: Call rstBCPiece.Close()
				
590: Call rstPiece.MoveNext()
595: Loop 
			
600: rstBC.Fields("Total").Value = Conversion_Renamed(CStr(dblTotal), ModuleMain.enumConvert.MODE_DECIMAL)
			
605: Call rstBC.Update()
			
610: Call rstFRS.MoveNext()
			
615: Call rstPiece.Close()
620: Loop 
		
625: Call rstFRS.Close()
630: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
		
635: Call rstBC.Close()
640: 'UPGRADE_NOTE: Object rstBC may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBC = Nothing
		
645: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
650: 'UPGRADE_NOTE: Object rstBCPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBCPiece = Nothing
		
655: Exit Sub
		
AfficherErreur: 
		
660: Call AfficherErreur("frmBonCommande", "EnregistrerBonCommande", Err, Erl())
	End Sub
	
	Private Sub EnregistrerModifFournisseur()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBC As ADODB.Recordset
15: Dim rstBCPiece As ADODB.Recordset
20: Dim iCompteur As Short
25: Dim itmBC As System.Windows.Forms.ListViewItem
30: Dim sNoBC As String
		
35: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
40: sNoBC = txtVotreNoSoum.Text
45: Else
50: sNoBC = txtNoBC.Text
55: End If
		
60: rstBC = New ADODB.Recordset
		
65: Call rstBC.Open("SELECT * FROM GRB_BonsCommandes WHERE NoBonCommande = '" & sNoBC & "' AND NoFournisseur = " & m_iNoFRS, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Enregistre le bon de commande
70: rstBC.Fields("Attention").Value = cmbContact.Text
75: rstBC.Fields("Transport").Value = txtTransport.Text
80: rstBC.Fields("DateRequise").Value = txtDateRequise.Text
		
85: If m_eForm = enumFormSource.I_RETOUR_MARCHANDISE Then
90: rstBC.Fields("VotreNoSoum").Value = txtNoBC.Text
95: Else
100: rstBC.Fields("VotreNoSoum").Value = txtVotreNoSoum.Text
105: End If
		
110: rstBC.Fields("Commentaire").Value = txtcommentaire.Text
115: rstBC.Fields("Total").Value = Conversion_Renamed(txtTotal.Text, ModuleMain.enumConvert.MODE_PAS_FORMAT)
120: rstBC.Fields("AffichageInstructions").Value = chkAfficherInstructions.CheckState
		
125: If optImpression(I_IMP_FRANCAIS).Checked = True Then
130: rstBC.Fields("LangueImpression").Value = "Français"
135: Else
140: rstBC.Fields("LangueImpression").Value = "Anglais"
145: End If
		
150: Call rstBC.Update()
		
155: Call rstBC.Close()
160: 'UPGRADE_NOTE: Object rstBC may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBC = Nothing
		
165: rstBCPiece = New ADODB.Recordset
		
170: If m_eForm <> enumFormSource.I_PROJET_ELEC And m_eForm <> enumFormSource.I_PROJET_MEC Then
175: For iCompteur = 1 To lvwBonCommande.Items.Count
180: 'UPGRADE_WARNING: Lower bound of collection lvwBonCommande.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmBC = lvwBonCommande.Items.Item(iCompteur)
				
				'Enregistre les pièces
185: 'UPGRADE_WARNING: Lower bound of collection itmBC has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				Call rstBCPiece.Open("SELECT * FROM GRB_BonsCommandes_Pieces WHERE NoBonCommande = '" & sNoBC & "' AND NoFournisseur = " & m_iNoFRS & " AND NoItem = '" & Replace(itmBC.SubItems(I_COL_NO_ITEM).Text, "'", "''") & "' AND NuméroLigne = '" & itmBC.Tag & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
190: If Not rstBCPiece.EOF Then
195: rstBCPiece.Fields("Qté").Value = itmBC.Text
200: 'UPGRADE_WARNING: Lower bound of collection itmBC has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					rstBCPiece.Fields("Total").Value = itmBC.SubItems(I_COL_TOTAL).Text
					
205: Call rstBCPiece.Update()
210: Else
215: Call MsgBox("Impossible d'enregistrer le bon de commande!", MsgBoxStyle.OKOnly, "Erreur")
220: End If
				
225: Call rstBCPiece.Close()
230: Next 
			
235: 'UPGRADE_NOTE: Object rstBCPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstBCPiece = Nothing
240: End If
		
245: Exit Sub
		
AfficherErreur: 
		
250: Call AfficherErreur("frmBonCommande", "EnregistrerModifFournisseur", Err, Erl())
	End Sub
	
	Private Sub txtDateRequise_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtDateRequise.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
5: On Error GoTo AfficherErreur
		
10: If KeyAscii <> System.Windows.Forms.Keys.Delete And KeyAscii <> System.Windows.Forms.Keys.Back Then
15: KeyAscii = 0
20: End If
		
25: GoTo EventExitSub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmBonCommande", "txtDateRequise_KeyPress", Err, Erl())
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class