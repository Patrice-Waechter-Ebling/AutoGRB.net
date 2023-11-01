Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FrmCatalogueElec
	Inherits System.Windows.Forms.Form
	
	'Numéros de colonne du ListView pour la recherche par description
	Private Const I_COL_DES_DESCR_FR As Short = 0
	Private Const I_COL_DES_DESCR_EN As Short = 1
	Private Const I_COL_DES_FABRICANT As Short = 2
	Private Const I_COL_DES_PIECE As Short = 3
	
	'Numéros de colonne du ListView pour la recherche par pièce
	Private Const I_COL_PIECE_PIECE As Short = 0
	Private Const I_COL_PIECE_FABRICANT As Short = 1
	Private Const I_COL_PIECE_DESCR_FR As Short = 2
	Private Const I_COL_PIECE_DESCR_EN As Short = 3
	
	'Numéros de colonne du ListView pour la recherche par manufacturier
	Private Const I_COL_MAN_FABRICANT As Short = 0
	Private Const I_COL_MAN_PIECE As Short = 1
	Private Const I_COL_MAN_DESCR_FR As Short = 2
	Private Const I_COL_MAN_DESCR_EN As Short = 3
	
	'Numéros de colonne du ListView pour les fournisseurs
	Private Const I_COL_FRS_FRS As Short = 0
	Private Const I_COL_FRS_PERS_RESS As Short = 1
	Private Const I_COL_FRS_DATE As Short = 2
	Private Const I_COL_FRS_ENTRER_PAR As Short = 3
	Private Const I_COL_FRS_VALIDE As Short = 4
	Private Const I_COL_FRS_PRIX_LIST As Short = 5
	Private Const I_COL_FRS_ESCOMPTE As Short = 6
	Private Const I_COL_FRS_PRIX_NET As Short = 7
	Private Const I_COL_FRS_PRIX_SP As Short = 8
	Private Const I_COL_FRS_QUOTER As Short = 9
	
	'Numéro de colonne du ListView pour la recherche dans les jobs
	Private Const I_COL_JOB_NUMERO As Short = 0
	Private Const I_COL_JOB_QUANTITE As Short = 1
	
	Private Const I_COL_ACHAT_NUMERO As Short = 0
	Private Const I_COL_ACHAT_QUANTITE As Short = 1
	
	Public Enum enumModeCatalogueElec
		MODE_AJOUT_MODIF_ELEC = 0
		MODE_INACTIF = 1
		MODE_AJOUT_MODIF_FRS = 2
	End Enum
	
	Public m_eDemande As frmChoixDemande.enumModeDemande
	Public m_bDemandeAnnuler As Boolean
	Public m_bAjout As Boolean
	Public m_bAnnulerCopie As Boolean
	Public m_sCategorieCopie As String
	Public m_bPieceEffacée As Boolean
	Private m_bRempliManuel As Boolean
	Private m_sNoItem As String
	Private m_eMode As enumModeCatalogueElec
	Private m_bBloqueDescription As Boolean
	Private m_collPieceDescFR As Collection
	
	'Pour pouvoir comparer la quantité stock avant et après une modification
	'pour savoir que c'est de l'ajustement d'inventaire
	Private m_sQteStockAvant As String
	
	'Pour pouvoir choisir lors du remplissage
	Public m_sSelectCategorie As String
	Public m_sSelectFabricant As String
	Public m_sSelectNoItem As String
	
	Private m_bCopiePiece As Boolean
	'utilisé pour créer la condition pour les recordsets si on choisi tous les fabricant
	Public sChoisirTous As String
	
	
	Public Sub ViderChamps_frs()
		
5: On Error GoTo AfficherErreur
		
		'Enlever la sélection dans le combo
10: cmbfrs.SelectedIndex = -1
		
		'Vide les champs pieces
15: txtPrixSpecial.Text = vbNullString
20: cmbPersRess.SelectedIndex = -1
25: txtPrixList.Text = vbNullString
30: mskEscompte.Text = vbNullString
35: txtPrixNet.Text = vbNullString
40: mskValide.Text = vbNullString
		
		'Enlève le check
45: chkquoter.CheckState = System.Windows.Forms.CheckState.Unchecked
50: optCAN.Checked = True
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmCatalogueElec", "ViderChamps_frs", Err, Erl())
	End Sub
	
	Public Sub ViderChamps_piece()
		
5: On Error GoTo AfficherErreur
		
		'Vide les champs pieces
10: txtNoItemGRB.Text = vbNullString
15: txtDescriptionEN.Text = vbNullString
20: txtTemps.Text = vbNullString
25: txtComment.Text = vbNullString
30: txtQuantitéBoite.Text = vbNullString
35: txtQuantiteCommande.Text = vbNullString
40: txtQuantiteMinimum.Text = vbNullString
45: txtQuantiteStock.Text = vbNullString
50: txtLocalisation.Text = vbNullString
		
55: cmbLocalisation.SelectedIndex = -1
		
		'Enlève le check
60: chkBoite.CheckState = System.Windows.Forms.CheckState.Unchecked
65: chkInventaire.CheckState = System.Windows.Forms.CheckState.Unchecked
70: chkMinimum.CheckState = System.Windows.Forms.CheckState.Unchecked
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmCatalogueElec", "ViderChamps_piece", Err, Erl())
	End Sub
	
	Public Sub BarrerChamps_piece(ByVal bLocked As Boolean)
		
5: On Error GoTo AfficherErreur
		
		'Barre les champs
10: txtNoItem.ReadOnly = bLocked
15: txtNoItemGRB.ReadOnly = bLocked
20: txtDescriptionEN.ReadOnly = bLocked
25: txtDescriptionFR.ReadOnly = bLocked
30: txtTemps.ReadOnly = bLocked
60: txtComment.ReadOnly = bLocked
65: frafournisseur.Enabled = bLocked
70: chkInventaire.Enabled = Not bLocked
		
75: If chkInventaire.Enabled = True Then
80: If chkInventaire.CheckState = System.Windows.Forms.CheckState.Checked Then
85: fraQuantité.Enabled = True
90: Else
95: fraQuantité.Enabled = False
100: End If
105: Else
110: fraQuantité.Enabled = False
115: End If
		
120: Exit Sub
		
AfficherErreur: 
		
125: Call AfficherErreur("frmCatalogueElec", "BarrerChamps_piece", Err, Erl())
	End Sub
	
	Public Sub MontrerControles(ByVal eMode As enumModeCatalogueElec)
		
5: On Error GoTo AfficherErreur
		
		'Mets des champs visible et d'autres invisible
10: Dim bCategorie As Boolean
15: Dim bFabricant As Boolean
20: Dim bNoItem As Boolean
25: Dim bLocalisation As Boolean
30: Dim bCmdAddFRS As Boolean
35: Dim bCmdModifFRS As Boolean
40: Dim bCmdSuppFRS As Boolean
45: Dim bCmdEnrFRS As Boolean
50: Dim bCmdAnnulFRS As Boolean
55: Dim bCmdAdd As Boolean
60: Dim bCmdModif As Boolean
65: Dim bCmdSupp As Boolean
70: Dim bCmdFermer As Boolean
75: Dim bCmdEnr As Boolean
80: Dim bCmdAnnul As Boolean
85: Dim bFraFRS As Boolean
90: Dim bLvwFRS As Boolean
95: Dim bCmdSearchMan As Boolean
100: Dim bCmdSearchPiece As Boolean
105: Dim bCmdSearchDescr As Boolean
110: Dim bCmdDemande As Boolean
115: Dim bCmbDescFR As Boolean
120: Dim bCopier As Boolean
125: Dim bChangerCat As Boolean
130: Dim bInventaire As Boolean
		
135: m_eMode = eMode
		
140: Select Case eMode
			Case enumModeCatalogueElec.MODE_INACTIF
145: bCategorie = True
150: bFabricant = True
155: bNoItem = True
160: bCmdAddFRS = True
165: bCmdModifFRS = True
170: bCmdSuppFRS = True
175: bCmdAdd = True
180: bCmdModif = True
185: bCmdSupp = True
190: bCmdFermer = True
195: bFraFRS = True
200: bLvwFRS = True
205: bCmdSearchMan = True
210: bCmdSearchPiece = True
215: bCmdSearchDescr = True
220: bCmdDemande = True
225: bCopier = True
230: bInventaire = True
235: bCmbDescFR = True
				
240: Case enumModeCatalogueElec.MODE_AJOUT_MODIF_ELEC
245: bCmdAddFRS = True
250: bCmdModifFRS = True
255: bCmdSuppFRS = True
260: bCmdEnr = True
				bFabricant = True 'GLL 2017-09-01
				txtFabricant.Enabled = True
265: bCmdAnnul = True
270: bLvwFRS = True
275: bCmdSearchDescr = True
280: bLocalisation = True
285: bChangerCat = True
				
290: Case enumModeCatalogueElec.MODE_AJOUT_MODIF_FRS
295: bCmdEnrFRS = True
300: bCmdAnnulFRS = True
305: bFraFRS = True
310: End Select
		
315: cmbCategorie.Visible = bCategorie
320: txtCategorie.Visible = Not bCategorie
		
325: cmbDescriptionFR.Visible = bCmbDescFR
330: txtDescriptionFR.Visible = Not bCmbDescFR
		
335: cmbFabricant.Visible = bFabricant
340: txtFabricant.Visible = bFabricant
		
345: cmbNoItem.Visible = bNoItem
350: txtNoItem.Visible = Not bNoItem
		
355: cmbLocalisation.Visible = bLocalisation
360: txtLocalisation.Visible = Not bLocalisation
		
365: frafournisseur.Enabled = bFraFRS
		
370: lvwfournisseur.Visible = bLvwFRS
		
375: cmdAddFrs.Visible = bCmdAddFRS
380: cmdModifFrs.Visible = bCmdModifFRS
385: cmdSuppFrs.Visible = bCmdSuppFRS
390: cmdEnrFrs.Visible = bCmdEnrFRS
395: cmdAnnulFrs.Visible = bCmdAnnulFRS
400: CmdAdd.Visible = bCmdAdd
405: CmdModif.Visible = bCmdModif
410: CmdSupp.Visible = bCmdSupp
415: CmdFerme.Visible = bCmdFermer
420: CmdEnr.Visible = bCmdEnr
425: CmdAnul.Visible = bCmdAnnul
430: cmdDemande.Visible = bCmdDemande
435: cmdCopier.Visible = bCopier
440: cmdRechercheDescrFR.Enabled = bCmdSearchDescr
445: cmdRechercherPiece.Enabled = bCmdSearchPiece
450: cmdRechercherManufacturier.Enabled = bCmdSearchMan
455: cmdChangerCategorie.Visible = bChangerCat
460: cmdRechercheInventaire.Visible = bInventaire
		
		
465: lblDevise1.Visible = False
470: txtTauxChange.Visible = False
475: lblDevise2.Visible = False
		
480: Exit Sub
		
AfficherErreur: 
		
485: Call AfficherErreur("frmCatalogueElec", "MontrerControles", Err, Erl())
	End Sub
	
	Private Sub RemplirComboPersRess()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstContactFRS As ADODB.Recordset
15: Dim rstContact As ADODB.Recordset
		
20: Call cmbPersRess.Items.Clear()
		
25: rstContactFRS = New ADODB.Recordset
		
30: Call rstContactFRS.Open("SELECT * FROM GRB_ContactFRS WHERE NoFRS = " & VB6.GetItemData(cmbfrs, cmbfrs.SelectedIndex), g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
35: rstContact = New ADODB.Recordset
		
40: Do While Not rstContactFRS.EOF
45: Call rstContact.Open("SELECT IDContact, NomContact FROM GRB_Contact WHERE IDContact = " & rstContactFRS.Fields("NoContact").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
50: If Not rstContact.EOF Then
55: Call cmbPersRess.Items.Add(rstContact.Fields("NomContact").Value)
				
60: 'UPGRADE_ISSUE: ComboBox property cmbPersRess.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				VB6.SetItemData(cmbPersRess, cmbPersRess.NewIndex, rstContact.Fields("IDContact").Value)
65: End If
			
70: Call rstContact.Close()
			
75: Call rstContactFRS.MoveNext()
80: Loop 
		
85: If cmbPersRess.Items.Count = 0 Then
90: Call rstContact.Open("SELECT NomContact, IDContact FROM GRB_Contact WHERE Supprimé = False ORDER BY NomContact", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
95: Do While Not rstContact.EOF
100: Call cmbPersRess.Items.Add(rstContact.Fields("NomContact").Value)
				
105: 'UPGRADE_ISSUE: ComboBox property cmbPersRess.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				VB6.SetItemData(cmbPersRess, cmbPersRess.NewIndex, rstContact.Fields("IDContact").Value)
				
110: Call rstContact.MoveNext()
115: Loop 
			
120: Call rstContact.Close()
125: End If
		
130: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
135: Exit Sub
		
AfficherErreur: 
		
140: Call AfficherErreur("frmCatalogueElec", "RemplirComboPersRess", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkBoite.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkBoite_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkBoite.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eMode = enumModeCatalogueElec.MODE_AJOUT_MODIF_ELEC Then
15: If chkBoite.CheckState = System.Windows.Forms.CheckState.Checked Then
20: txtQuantitéBoite.Enabled = True
25: Else
30: txtQuantitéBoite.Enabled = False
35: End If
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmCatalogueElec", "chkBoite_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkInventaire.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkInventaire_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkInventaire.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eMode = enumModeCatalogueElec.MODE_AJOUT_MODIF_ELEC Then
15: If chkInventaire.CheckState = System.Windows.Forms.CheckState.Checked Then
20: fraQuantité.Enabled = True
25: cmbLocalisation.Enabled = True
30: Else
35: fraQuantité.Enabled = False
40: cmbLocalisation.Enabled = False
45: End If
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmCatalogueElec", "chkInventaire_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkMinimum.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkMinimum_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkMinimum.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eMode = enumModeCatalogueElec.MODE_AJOUT_MODIF_ELEC Then
15: If chkMinimum.CheckState = System.Windows.Forms.CheckState.Checked Then
20: txtQuantiteMinimum.Enabled = True
25: txtQuantiteCommande.Enabled = True
30: Else
35: txtQuantiteMinimum.Enabled = False
40: txtQuantiteCommande.Enabled = False
45: End If
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmCatalogueElec", "chkMinimum_Click", Err, Erl())
	End Sub
	
	Private Sub RemplirComboDescription()
		
5: On Error GoTo AfficherErreur
		
		'Remplir le combo des descriptions
10: Dim rstCatElec As ADODB.Recordset
15: Dim sPiece As String
20: Dim sCategorie As String
21: Dim sFabricant As String
		
25: Do While m_collPieceDescFR.Count() > 0
30: Call m_collPieceDescFR.Remove(1)
35: Loop 
		
40: Call cmbDescriptionFR.Items.Clear()
		
45: sCategorie = Replace(cmbCategorie.Text, "'", "''")
46: sFabricant = Replace(cmbFabricant.Text, "'", "''")
		
50: rstCatElec = New ADODB.Recordset
		
41: If sFabricant = "-- CHOISIR TOUS --" Then
			If cmbCategorie.Text = "DIVERS" Or sChoisirTous = ")" Then
				Call rstCatElec.Open("SELECT * FROM GRB_CatalogueElec WHERE CATEGORIE = '" & sCategorie & "' ORDER BY TRIM(PIECE)", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
54: Else
				Call rstCatElec.Open("SELECT * FROM GRB_CatalogueElec WHERE CATEGORIE = '" & sCategorie & "'" & sChoisirTous & " ORDER BY TRIM(PIECE)", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
55: End If
		Else
			
56: Call rstCatElec.Open("SELECT * FROM GRB_CatalogueElec WHERE CATEGORIE = '" & sCategorie & "' AND FABRICANT = '" & sFabricant & "' ORDER BY TRIM(PIECE)", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
57: 
		End If
		
		
60: Do While Not rstCatElec.EOF
65: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstCatElec.Fields("DESC_FR").Value) Then
70: If rstCatElec.Fields("DESC_FR").Value <> vbNullString Then
75: Call cmbDescriptionFR.Items.Add(Trim(rstCatElec.Fields("DESC_FR").Value))
					
80: sPiece = Trim(rstCatElec.Fields("PIECE").Value)
					
85: Call m_collPieceDescFR.Add(sPiece)
90: End If
95: End If
			
100: Call rstCatElec.MoveNext()
105: Loop 
		
110: Call rstCatElec.Close()
115: 'UPGRADE_NOTE: Object rstCatElec may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstCatElec = Nothing
		
120: Exit Sub
		
AfficherErreur: 
		
125: Call AfficherErreur("frmCatalogueElec", "RemplirComboDescription", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbDescriptionFR.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbDescriptionFR_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbDescriptionFR.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: Dim rstCatElec As ADODB.Recordset
15: Dim sNoItem As String
20: Dim sFabricant As String
25: Dim iCompteur As Short
		
30: txtDescriptionFR.Text = cmbDescriptionFR.Text
		
35: If m_bBloqueDescription = False Then
40: For iCompteur = 0 To cmbNoItem.Items.Count - 1
45: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPieceDescFR(cmbDescriptionFR.ListIndex + 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If VB6.GetItemString(cmbNoItem, iCompteur) = m_collPieceDescFR.Item(cmbDescriptionFR.SelectedIndex + 1) Then
50: cmbNoItem.SelectedIndex = iCompteur
					
55: Exit For
60: End If
65: Next 
70: End If
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmCatalogueElec", "cmbDescriptionFR_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbfrs.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbfrs_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbfrs.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: If cmbfrs.SelectedIndex <> -1 Then
15: cmbfrs.Tag = VB6.GetItemData(cmbfrs, cmbfrs.SelectedIndex)
			
20: Call RemplirComboPersRess()
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmCatalogueElec", "cmbfrs_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbLocalisation.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbLocalisation_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbLocalisation.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: txtLocalisation.Text = cmbLocalisation.Text
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmCatalogueElec", "cmbLocalisation_Click", Err, Erl())
	End Sub
	
	Private Sub CmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdAdd.Click
		
5: On Error GoTo AfficherErreur
		
		'Montre le dialogue pour ajouter un item au catalogue
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: m_bBloqueDescription = True
		
20: Call OuvrirForm(FrmaddItemElec, True)
		
25: m_bBloqueDescription = False
		
30: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmCatalogueElec", "CmdAdd_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAddFrs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAddFrs.Click
		
5: On Error GoTo AfficherErreur
		
10: If cmbNoItem.Items.Count > 0 Then
			'ajoute un fournisseur pour la piece
15: m_bAjout = True
			
20: Call BarrerChamps_piece(True)
			
25: Call ViderChamps_frs()
			
30: Call cmbfrs.Focus()
			
35: Call MontrerControles(enumModeCatalogueElec.MODE_AJOUT_MODIF_FRS)
			
			'affiche drapeau
40: Call AfficherDrapeau()
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmCatalogueElec", "cmdAddFrs_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnulFrs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnulFrs.Click
		
5: On Error GoTo AfficherErreur
		
10: Call MontrerControles(enumModeCatalogueElec.MODE_INACTIF)
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmCatalogueElec", "cmdAnnulFrs_Click", Err, Erl())
	End Sub
	
	Private Sub CmdAnul_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdAnul.Click
		
5: On Error GoTo AfficherErreur
		
10: txtPrixNet.Enabled = True
15: txtPrixSpecial.Enabled = True
		
20: m_bBloqueDescription = True
		txtFabricant.Top = VB6.TwipsToPixelsY(1320) 'GLL 2017-10-10 Modification pour ajouter la modification possible du Manufacturier
		cmbFabricant.Visible = True 'GLL 2017-10-10 Modification pour ajouter la modification possible du Manufacturier
25: Call AfficherItem()
		
30: m_bBloqueDescription = False
		
35: m_bCopiePiece = False
		
		'on cache les combos
40: cmbFabricant.Visible = False
45: cmbNoItem.Visible = False
		
		'on retablis les boutons
50: Call MontrerControles(enumModeCatalogueElec.MODE_INACTIF)
55: Call BarrerChamps_piece(True)
		
60: m_sQteStockAvant = ""
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmCatalogueElec", "CmdAnul_Click", Err, Erl())
	End Sub
	
	Private Sub EnregistrerItem()
		
5: On Error GoTo AfficherErreur
		
		'Enregistrement de l'item dans la BD
10: Dim rstItem As ADODB.Recordset
15: Dim rstItemFRS As ADODB.Recordset
20: Dim rstItemFRSDest As ADODB.Recordset
25: Dim rstVerif As ADODB.Recordset
30: Dim rstInventaire As ADODB.Recordset
35: Dim rstInvModif As ADODB.Recordset
40: Dim sNomFab As String
45: Dim sNoPiece As String
50: Dim iCompteur As Short
55: Dim sPieceModif As String
60: Dim sLettre As String
		
65: sNomFab = txtFabricant.Text
70: sNoPiece = txtNoItem.Text
		
75: If m_bCopiePiece = True Or (m_bCopiePiece = False And (UCase(sNoPiece) <> UCase(m_sNoItem))) Then
80: rstVerif = New ADODB.Recordset
			
85: Call rstVerif.Open("SELECT * FROM GRB_CatalogueElec WHERE PIECE = '" & Replace(sNoPiece, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
90: If Not rstVerif.EOF Then
95: Call MsgBox("Le numéro " & sNoPiece & " existe déjà!", MsgBoxStyle.OKOnly, "Erreur")
				
100: Call rstVerif.Close()
105: 'UPGRADE_NOTE: Object rstVerif may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstVerif = Nothing
				
110: Exit Sub
115: End If
			
120: Call rstVerif.Close()
125: 'UPGRADE_NOTE: Object rstVerif may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstVerif = Nothing
130: End If
		
135: If txtFabricant.Text = vbNullString Or txtNoItem.Text = vbNullString Or txtDescriptionFR.Text = vbNullString Then
140: Call MsgBox("Les champs Manufacturier, Pièce et Desc. FR doivent être remplis!", MsgBoxStyle.OKOnly, "Erreur")
			
145: Exit Sub
150: End If
		
		'Sinon, j'ouvre un recordset contenant le no d'item
155: rstItem = New ADODB.Recordset
		
160: Call rstItem.Open("SELECT * FROM GRB_CatalogueElec WHERE PIECE = '" & Replace(m_sNoItem, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'enregistre le nopiece dans la table distributeur si pas vide
165: rstItemFRS = New ADODB.Recordset
		
170: Call rstItemFRS.Open("SELECT * FROM GRB_PiecesFRS WHERE PIECE = '" & Replace(rstItem.Fields("PIECE").Value, "'", "''") & "' AND Type = 'E'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
175: If m_bCopiePiece = False Then
180: Do While Not rstItemFRS.EOF
185: rstItemFRS.Fields("PIECE").Value = txtNoItem.Text
				
190: Call rstItemFRS.Update()
				
195: Call rstItemFRS.MoveNext()
200: Loop 
205: Else
210: rstItemFRSDest = New ADODB.Recordset
			
215: Call rstItemFRSDest.Open("SELECT * FROM GRB_PiecesFRS", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
220: Do While Not rstItemFRS.EOF
225: Call rstItemFRSDest.AddNew()
				
230: rstItemFRSDest.Fields("IDFRS").Value = rstItemFRS.Fields("IDFRS").Value
235: rstItemFRSDest.Fields("PIECE").Value = sNoPiece
240: rstItemFRSDest.Fields("PRIX_SP").Value = rstItemFRS.Fields("PRIX_SP").Value
245: rstItemFRSDest.Fields("PERS_RESS").Value = rstItemFRS.Fields("PERS_RESS").Value
250: rstItemFRSDest.Fields("PRIX_LIST").Value = rstItemFRS.Fields("PRIX_LIST").Value
255: rstItemFRSDest.Fields("ESCOMPTE").Value = rstItemFRS.Fields("ESCOMPTE").Value
260: rstItemFRSDest.Fields("PRIX_NET").Value = rstItemFRS.Fields("PRIX_NET").Value
265: rstItemFRSDest.Fields("DATE").Value = rstItemFRS.Fields("DATE").Value
270: rstItemFRSDest.Fields("ENTRER_PAR").Value = rstItemFRS.Fields("ENTRER_PAR").Value
275: rstItemFRSDest.Fields("VALIDE").Value = rstItemFRS.Fields("VALIDE").Value
280: rstItemFRSDest.Fields("QUOTER").Value = rstItemFRS.Fields("QUOTER").Value
285: rstItemFRSDest.Fields("DeviseMonétaire").Value = rstItemFRS.Fields("DeviseMonétaire").Value
290: rstItemFRSDest.Fields("Type").Value = rstItemFRS.Fields("Type").Value
				
295: Call rstItemFRSDest.Update()
				
300: Call rstItemFRS.MoveNext()
305: Loop 
			
310: Call rstItemFRSDest.Close()
315: 'UPGRADE_NOTE: Object rstItemFRSDest may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstItemFRSDest = Nothing
320: End If
		
325: Call rstItemFRS.Close()
330: 'UPGRADE_NOTE: Object rstItemFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstItemFRS = Nothing
		
335: If m_bCopiePiece = True Then
340: Call rstItem.AddNew()
345: End If
		
		'Enregistrement des valeurs dans la table catalogue
350: rstItem.Fields("CATEGORIE").Value = txtCategorie.Text
355: rstItem.Fields("PIECE").Value = sNoPiece
		
360: For iCompteur = 1 To Len(sNoPiece)
365: sLettre = Mid(sNoPiece, iCompteur, 1)
			
370: If (Asc(sLettre) >= 48 And Asc(sLettre) <= 57) Or (Asc(sLettre) >= 65 And Asc(sLettre) <= 90) Or (Asc(sLettre) >= 97 And Asc(sLettre) <= 122) Then
375: sPieceModif = sPieceModif & sLettre
380: End If
385: Next 
		
390: rstItem.Fields("PIECE_MODIF").Value = sPieceModif
395: rstItem.Fields("FABRICANT").Value = sNomFab
400: rstItem.Fields("PIECE_GRB").Value = txtNoItemGRB.Text
405: rstItem.Fields("DESC_EN").Value = txtDescriptionEN.Text
410: rstItem.Fields("DESC_FR").Value = txtDescriptionFR.Text
415: rstItem.Fields("TEMPS").Value = txtTemps.Text
420: rstItem.Fields("COMMENTAIRE").Value = txtComment.Text
		
425: Call rstItem.Update()
		
430: Call rstItem.Close()
435: 'UPGRADE_NOTE: Object rstItem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstItem = Nothing
		
440: If chkInventaire.CheckState = System.Windows.Forms.CheckState.Checked Then
445: rstInventaire = New ADODB.Recordset
			
450: If m_bCopiePiece = True Then
455: Call rstInventaire.Open("SELECT * FROM GRB_InventaireElec WHERE NoItem = '" & Replace(sNoPiece, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
460: Else
465: Call rstInventaire.Open("SELECT * FROM GRB_InventaireElec WHERE NoItem = '" & Replace(m_sNoItem, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
470: End If
			
475: If rstInventaire.EOF Then
480: Call rstInventaire.AddNew()
485: End If
			
490: rstInventaire.Fields("NoItem").Value = sNoPiece
			
495: rstInventaire.Fields("Description").Value = txtDescriptionFR.Text
			
500: rstInventaire.Fields("Manufacturier").Value = sNomFab
			
505: If chkBoite.CheckState = System.Windows.Forms.CheckState.Checked Then
510: rstInventaire.Fields("CommandeParBoite").Value = True
515: rstInventaire.Fields("QteBoite").Value = txtQuantitéBoite.Text
520: Else
525: rstInventaire.Fields("CommandeParBoite").Value = False
530: rstInventaire.Fields("QteBoite").Value = ""
535: End If
			
540: rstItemFRS = New ADODB.Recordset
			
545: Call rstItemFRS.Open("SELECT * FROM GRB_PiecesFRS WHERE PIECE = '" & Replace(sNoPiece, "'", "''") & "' AND IDFRS = 717", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
550: If rstItemFRS.EOF Then
555: Call rstItemFRS.AddNew()
				
560: rstItemFRS.Fields("PIECE").Value = sNoPiece
565: rstItemFRS.Fields("IDFRS").Value = 717
570: rstItemFRS.Fields("Type").Value = "E"
575: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				rstItemFRS.Fields("PERS_RESS").Value = System.DBNull.Value
580: rstItemFRS.Fields("PRIX_LIST").Value = "0"
585: rstItemFRS.Fields("ESCOMPTE").Value = "0"
590: rstItemFRS.Fields("PRIX_NET").Value = "0"
595: rstItemFRS.Fields("PrixReel").Value = "0"
600: rstItemFRS.Fields("DATE").Value = ConvertDate(Today)
605: rstItemFRS.Fields("ENTRER_PAR").Value = g_sInitiale
610: rstItemFRS.Fields("DeviseMonétaire").Value = "CAN"
				
615: Call rstItemFRS.Update()
620: End If
			
625: If chkBoite.CheckState = System.Windows.Forms.CheckState.Checked Then
630: If IsNumeric(rstItemFRS.Fields("PRIX_LIST").Value) Then
635: rstInventaire.Fields("Prix Liste").Value = System.Math.Round(rstItemFRS.Fields("PRIX_LIST").Value / CDbl(txtQuantitéBoite.Text), 6)
640: Else
645: rstInventaire.Fields("Prix Liste").Value = "0"
650: End If
				
655: If IsNumeric(rstItemFRS.Fields("ESCOMPTE").Value) Then
660: rstInventaire.Fields("Escompte").Value = rstItemFRS.Fields("Escompte").Value
665: Else
670: rstInventaire.Fields("Escompte").Value = "0"
675: End If
				
680: If IsNumeric(rstItemFRS.Fields("PRIX_NET").Value) Then
685: rstInventaire.Fields("Prix net").Value = System.Math.Round(rstItemFRS.Fields("PRIX_NET").Value / CDbl(txtQuantitéBoite.Text), 6)
690: Else
695: rstInventaire.Fields("Prix net").Value = "0"
700: End If
705: Else
710: rstInventaire.Fields("Prix Liste").Value = rstItemFRS.Fields("PRIX_LIST").Value
715: rstInventaire.Fields("Escompte").Value = rstItemFRS.Fields("Escompte").Value
720: rstInventaire.Fields("Prix net").Value = rstItemFRS.Fields("PRIX_NET").Value
725: End If
			
730: Call rstItemFRS.Close()
735: 'UPGRADE_NOTE: Object rstItemFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstItemFRS = Nothing
			
740: rstInventaire.Fields("Commentaires").Value = txtComment.Text
			
745: rstInventaire.Fields("Localisation").Value = cmbLocalisation.Text
			
750: If Trim(txtQuantiteStock.Text) <> "" Then
755: rstInventaire.Fields("QuantitéStock").Value = txtQuantiteStock.Text
760: Else
765: rstInventaire.Fields("QuantitéStock").Value = "0"
770: End If
			
775: If chkMinimum.CheckState = System.Windows.Forms.CheckState.Checked Then
780: rstInventaire.Fields("Minimum").Value = True
				
785: If Trim(txtQuantiteMinimum.Text) <> "" Then
790: rstInventaire.Fields("QuantitéMinimum").Value = txtQuantiteMinimum.Text
795: Else
800: rstInventaire.Fields("QuantitéMinimum").Value = "0"
805: End If
				
810: If CBool(Trim(txtQuantiteCommande.Text)) = True Then
815: rstInventaire.Fields("Commande").Value = txtQuantiteCommande.Text
820: Else
825: rstInventaire.Fields("Commande").Value = "0"
830: End If
835: Else
840: rstInventaire.Fields("Minimum").Value = False
845: rstInventaire.Fields("QuantitéMinimum").Value = ""
850: rstInventaire.Fields("Commande").Value = ""
855: End If
			
860: Call rstInventaire.Update()
			
865: Call rstInventaire.Close()
870: 'UPGRADE_NOTE: Object rstInventaire may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstInventaire = Nothing
875: Else
880: If m_bCopiePiece = True Then
885: Call g_connData.Execute("DELETE * FROM GRB_InventaireElec WHERE NoItem = '" & Replace(sNoPiece, "'", "''") & "'")
890: Else
895: Call g_connData.Execute("DELETE * FROM GRB_InventaireElec WHERE NoItem = '" & Replace(m_sNoItem, "'", "''") & "'")
900: End If
905: End If
		
910: If m_bCopiePiece = False Then
915: If txtQuantiteStock.Text <> m_sQteStockAvant Or ((m_sQteStockAvant <> "" And m_sQteStockAvant <> "0") And chkInventaire.CheckState = System.Windows.Forms.CheckState.Unchecked) Then
920: If m_sQteStockAvant = "" Then
925: m_sQteStockAvant = "0"
930: End If
				
935: If Not IsNumeric(txtQuantiteStock.Text) Then
940: txtQuantiteStock.Text = "0"
945: End If
				
950: rstInvModif = New ADODB.Recordset
				
955: Call rstInvModif.Open("SELECT * FROM GRB_InventaireElecModif", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
960: Call rstInvModif.AddNew()
				
965: rstInvModif.Fields("Date").Value = ConvertDate(Today)
970: rstInvModif.Fields("IDProjet").Value = InputBox("Précisez l'ajustement d'inventaire")
975: rstInvModif.Fields("NoItem").Value = txtNoItem.Text
				
980: If chkInventaire.CheckState = System.Windows.Forms.CheckState.Checked Then
985: rstInvModif.Fields("Quantité").Value = CDbl(txtQuantiteStock.Text) - CDbl(m_sQteStockAvant)
990: Else
995: rstInvModif.Fields("Quantité").Value = 0 - CDbl(m_sQteStockAvant)
1000: End If
				
1005: rstInvModif.Fields("User").Value = g_sInitiale
				
1010: Call rstInvModif.Update()
				
1015: Call rstInvModif.Close()
1020: 'UPGRADE_NOTE: Object rstInvModif may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstInvModif = Nothing
1025: End If
1030: End If
		
1035: If (UCase(sNoPiece) <> UCase(m_sNoItem)) And m_bCopiePiece = False Then
1040: Call ModifierNoItem(m_sNoItem, sNoPiece)
1045: End If
		
1050: m_sQteStockAvant = ""
		
1055: m_bRempliManuel = True
		
1060: m_sSelectNoItem = sNoPiece
1065: m_sSelectFabricant = sNomFab
		
1070: Call RemplirComboLocalisation()
		
1075: Call RemplirComboFabricant()
		
		'Rétablir les buttons
1080: Call MontrerControles(enumModeCatalogueElec.MODE_INACTIF)
		
1085: Call BarrerChamps_piece(True)
		
1090: Exit Sub
		
AfficherErreur: 
		
1095: Call AfficherErreur("frmCatalogueElec", "EnregistrerItem", Err, Erl())
	End Sub
	
	Private Sub cmdChangerCategorie_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdChangerCategorie.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPiece As ADODB.Recordset
		
15: Call frmChoixCategorie.Afficher(ModuleMain.enumCatalogue.ELECTRIQUE)
		
20: If txtCategorie.Text <> m_sCategorieCopie Then
25: If m_bAnnulerCopie = False Then
30: rstPiece = New ADODB.Recordset
				
35: Call rstPiece.Open("SELECT * FROM GRB_CatalogueElec WHERE PIECE = '" & Replace(cmbNoItem.Text, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
40: rstPiece.Fields("CATEGORIE").Value = m_sCategorieCopie
				
45: Call rstPiece.Update()
				
50: Call rstPiece.Close()
55: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstPiece = Nothing
				
60: Call ViderChamps_piece()
				
65: m_sSelectFabricant = txtFabricant.Text
				
70: Call RemplirComboFabricant()
				
75: Call MontrerControles(enumModeCatalogueElec.MODE_INACTIF)
				
80: Call BarrerChamps_piece(True)
85: End If
90: End If
		
95: Exit Sub
		
AfficherErreur: 
		
100: Call AfficherErreur("frmCatalogueElec", "cmdChangerCategorie_Click", Err, Erl())
	End Sub
	
	Private Sub cmdCopier_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCopier.Click
		
5: On Error GoTo AfficherErreur
		
10: m_bCopiePiece = True
		
15: Call CmdModif_Click(CmdModif, New System.EventArgs())
		
20: chkInventaire.CheckState = System.Windows.Forms.CheckState.Unchecked
25: chkBoite.CheckState = System.Windows.Forms.CheckState.Unchecked
30: chkMinimum.CheckState = System.Windows.Forms.CheckState.Unchecked
		
35: txtQuantitéBoite.Text = ""
40: txtQuantiteStock.Text = ""
45: txtQuantiteMinimum.Text = ""
50: txtQuantiteCommande.Text = ""
55: cmbLocalisation.Text = ""
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmCatalogueElec", "cmdCopier_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDemande_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDemande.Click
		
5: On Error GoTo AfficherErreur
		
10: Call dlgDemandePrix.Afficher(Me)
		
15: If m_bDemandeAnnuler = False Then
20: Call frmChoixDemande.Afficher(ModuleMain.enumCatalogue.ELECTRIQUE, m_eDemande)
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmCatalogueElec", "cmdDemande_Click", Err, Erl())
	End Sub
	
	Private Sub CmdEnr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdEnr.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim bContinuer As Boolean
		
		'Enregistrement d'un item dans la BD
		txtFabricant.Top = VB6.TwipsToPixelsY(1320) 'GLL 2017-10-10 Modification pour ajouter la modification possible du Manufacturier
		cmbFabricant.Visible = True 'GLL 2017-10-10 Modification pour ajouter la modification possible du Manufacturier
20: If (UCase(txtNoItem.Text) <> UCase(m_sNoItem)) And m_bCopiePiece = False Then
25: If MsgBox("Le numéro de pièce sera modifié dans toutes les soumissions, les projets et les achats. " & vbNewLine & "Voulez-vous continuer ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
30: bContinuer = True
35: Else
40: bContinuer = False
45: End If
50: Else
55: bContinuer = True
60: End If
		
65: If bContinuer = True Then
70: Call EnregistrerItem()
			
75: If m_eMode = enumModeCatalogueElec.MODE_INACTIF Then
80: m_bCopiePiece = False
85: End If
			
90: Call RemplirComboDescription()
			
95: m_bBloqueDescription = True
			
100: For iCompteur = 0 To cmbDescriptionFR.Items.Count - 1
105: If VB6.GetItemString(cmbDescriptionFR, iCompteur) = txtDescriptionFR.Text Then
110: cmbDescriptionFR.SelectedIndex = iCompteur
					
115: Exit For
120: End If
125: Next 
			
130: m_bBloqueDescription = False
135: End If
		
140: Exit Sub
		
AfficherErreur: 
		
145: Call AfficherErreur("frmCatalogueElec", "CmdEnr_Click", Err, Erl())
	End Sub
	
	Private Sub ModifierNoItem(ByVal sAncienNoItem As String, ByVal sNouveauNoItem As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim iRecordProjet As Short
15: Dim iRecordSoum As Short
20: Dim iRecordAchat As Short
		
25: Call g_connData.Execute("UPDATE GRB_Projet_Pieces SET NumItem = '" & Replace(sNouveauNoItem, "'", "''") & "' WHERE NumItem = '" & Replace(sAncienNoItem, "'", "''") & "' AND Type = 'E'", iRecordProjet)
30: Call g_connData.Execute("UPDATE GRB_Soumission_Pieces SET NumItem = '" & Replace(sNouveauNoItem, "'", "''") & "' WHERE NumItem = '" & Replace(sAncienNoItem, "'", "''") & "' AND Type = 'E'", iRecordSoum)
		
35: Call g_connData.Execute("UPDATE GRB_Achat_Pieces SET PIECE = '" & Replace(sNouveauNoItem, "'", "''") & "' WHERE PIECE = '" & Replace(sAncienNoItem, "'", "''") & "' AND Left(IDAchat, 1) <> 'M'", iRecordAchat)
		
40: Call g_connData.Execute("UPDATE GRB_InventaireElecModif SET NoItem = '" & Replace(sNouveauNoItem, "'", "''") & "' WHERE NoItem = '" & Replace(sAncienNoItem, "'", "''") & "'")
		
45: Call MsgBox("Numéros de pièces modifiés" & vbNewLine & vbNewLine & "Projets : " & iRecordProjet & vbNewLine & "Soumissions : " & iRecordSoum & vbNewLine & "Achats : " & iRecordAchat, MsgBoxStyle.OKOnly)
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmCatalogueElec", "ModifierNoItem", Err, Erl())
	End Sub
	
	Private Sub cmdEnrFrs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEnrFrs.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		'Enregistrement d'un Item dans la BD
		
15: If Trim(txtPrixList.Text) = "" And Trim(mskEscompte.Text) = "" And Trim(txtPrixNet.Text) = "" And Trim(txtPrixSpecial.Text) = "" Then
20: txtPrixList.Text = "0"
25: mskEscompte.Text = "0"
30: txtPrixNet.Text = "0"
35: End If
		
40: If Trim(txtPrixList.Text) = vbNullString Then
45: If Trim(txtPrixSpecial.Text) = vbNullString Then
50: Call MsgBox("Vous devez remplir le prix listé!", MsgBoxStyle.OKOnly, "Erreur")
				
55: Exit Sub
60: End If
65: End If
		
70: If Trim(txtPrixNet.Text) = vbNullString And Trim(txtPrixSpecial.Text) = vbNullString Then
75: Call MsgBox("Vous devez remplir le prix net ou le prix spécial!", MsgBoxStyle.OKOnly, "Erreur")
			
80: Exit Sub
85: End If
		
90: If optUSA.Checked = True Or optSpain.Checked = True Then
95: If Trim(txtTauxChange.Text) <> vbNullString Then
100: If Not IsNumeric(txtTauxChange.Text) Then
105: Call MsgBox("Le taux de change doit être numérique!", MsgBoxStyle.OKOnly, "Erreur")
					
110: Exit Sub
115: End If
120: Else
125: Call MsgBox("Le taux de change ne doit pas être vide!", MsgBoxStyle.OKOnly, "Erreur")
				
130: Exit Sub
135: End If
140: End If
		
145: If (Trim(txtPrixNet.Text) <> Trim(txtPrixList.Text)) And Trim(txtPrixSpecial.Text) = vbNullString Then
150: Call CalculerPrixNet()
155: End If
		
160: If cmbfrs.SelectedIndex > -1 Then
165: Call EnregistrerFRS()
170: Else
175: Call MsgBox("Vous devez choisir un fournisseur!", MsgBoxStyle.OKOnly, "Erreur")
180: End If
		
185: Exit Sub
		
AfficherErreur: 
		
190: Call AfficherErreur("frmCatalogueElec", "cmdEnrFrs_Click", Err, Erl())
	End Sub
	
	Private Sub EnregistrerFRS()
		
5: On Error GoTo AfficherErreur
		
		'Enregistrement de l'item dans la BD
10: Dim rstItemFRS As ADODB.Recordset
15: Dim rstInv As ADODB.Recordset
20: Dim rstConfig As ADODB.Recordset
25: Dim bDistribExiste As Boolean
30: Dim iCompteur As Short
		
		'Si le PRIX_SP est monétaire
35: If txtPrixSpecial.Text <> vbNullString Then
40: If Not IsNumeric(txtPrixSpecial.Text) Then
45: Call MsgBox("Le prix spécial est invalide!", MsgBoxStyle.OKOnly, "Erreur")
				
50: Exit Sub
55: End If
60: End If
		
		'Si le PRIX_NET est monétaire
65: If txtPrixNet.Text <> vbNullString Then
70: If Not IsNumeric(txtPrixNet.Text) Then
75: Call MsgBox("Le prix net est invalide!", MsgBoxStyle.OKOnly, "Erreur")
				
80: Exit Sub
85: End If
90: End If
		
		'Si le PRIX_LIST est monétaire
95: If txtPrixList.Text <> vbNullString Then
100: If Not IsNumeric(txtPrixList.Text) Then
105: Call MsgBox("Le prix listé est invalide!", MsgBoxStyle.OKOnly, "Erreur")
				
110: Exit Sub
115: End If
120: End If
		
		'Si la date de validité est valide
125: If Trim(mskValide.Text) <> vbNullString Then
130: If IsDate(mskValide.Text) = False Then
135: Call MsgBox("La date de validité est invalide!", MsgBoxStyle.OKOnly, "Erreur")
				
140: Exit Sub
145: End If
150: End If
		
155: bDistribExiste = False
		
160: If m_bAjout = True Then
			'Si le distributeur n'est pas déjà dans le listView
165: If lvwfournisseur.Items.Count > 0 Then
170: For iCompteur = 1 To lvwfournisseur.Items.Count
175: 'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvwfournisseur.Items.Item(iCompteur).Text = cmbfrs.Text Then
180: bDistribExiste = True
						
185: Exit For
190: End If
195: Next 
200: End If
			
205: If bDistribExiste = True Then
210: If txtPrixSpecial.Text <> "" Then
215: 'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvwfournisseur.Items.Item(iCompteur).SubItems(I_COL_FRS_PRIX_SP).Text <> "" Then
220: Call MsgBox("Ce distributeur est déjà ajouté avec un prix spécial", MsgBoxStyle.OKOnly, "Erreur")
						
225: Exit Sub
230: End If
235: Else
240: 'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvwfournisseur.Items.Item(iCompteur).SubItems(I_COL_FRS_PRIX_NET).Text <> "" Then
245: Call MsgBox("Ce distributeur est déjà ajouté avec un prix net", MsgBoxStyle.OKOnly, "Erreur")
						
250: Exit Sub
255: End If
260: End If
265: End If
270: End If
		
275: rstItemFRS = New ADODB.Recordset
		
280: If m_bAjout = True Then
285: Call rstItemFRS.Open("SELECT * FROM GRB_PiecesFRS WHERE PIECE = '" & Replace(txtNoItem.Text, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'si c'est un ajout, j'ouvre un recordset général
290: Call rstItemFRS.AddNew()
			
295: m_bAjout = False
300: Else
305: Call rstItemFRS.Open("SELECT * FROM GRB_PiecesFRS WHERE noEnreg = " & lvwfournisseur.FocusedItem.Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
310: End If
		
		'Enregistrement des valeurs dans la table catalogue
315: rstItemFRS.Fields("PIECE").Value = cmbNoItem.Text
320: rstItemFRS.Fields("IDFRS").Value = VB6.GetItemData(cmbfrs, cmbfrs.SelectedIndex)
325: rstItemFRS.Fields("Type").Value = "E"
		
330: If cmbPersRess.SelectedIndex > -1 Then
335: rstItemFRS.Fields("PERS_RESS").Value = VB6.GetItemData(cmbPersRess, cmbPersRess.SelectedIndex)
340: Else
345: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			rstItemFRS.Fields("PERS_RESS").Value = System.DBNull.Value
350: End If
		
355: rstItemFRS.Fields("PRIX_LIST").Value = txtPrixList.Text
360: rstItemFRS.Fields("ESCOMPTE").Value = mskEscompte.Text
		
365: If txtPrixSpecial.Text <> vbNullString Or txtPrixNet.Text <> vbNullString Then
370: If txtPrixNet.Text <> vbNullString Then
375: rstItemFRS.Fields("PRIX_NET").Value = txtPrixNet.Text
380: rstItemFRS.Fields("PrixReel").Value = txtPrixNet.Text
385: Else
390: rstItemFRS.Fields("PRIX_NET").Value = vbNullString
395: End If
			
400: If txtPrixSpecial.Text <> vbNullString Then
405: rstItemFRS.Fields("PRIX_SP").Value = txtPrixSpecial.Text
410: rstItemFRS.Fields("PrixReel").Value = txtPrixNet.Text
415: Else
420: rstItemFRS.Fields("PRIX_SP").Value = vbNullString
425: End If
430: End If
		
435: rstItemFRS.Fields("DATE").Value = ConvertDate(Today)
440: rstItemFRS.Fields("VALIDE").Value = mskValide.Text
445: rstItemFRS.Fields("ENTRER_PAR").Value = g_sInitiale
		
450: If chkquoter.CheckState = 1 Then
455: rstItemFRS.Fields("quoter").Value = True
460: Else
465: rstItemFRS.Fields("quoter").Value = False
470: End If
		
475: If optCAN.Checked = True Then
480: rstItemFRS.Fields("devisemonétaire").Value = "CAN"
485: Else
490: If optUSA.Checked = True Then
495: rstItemFRS.Fields("DeviseMonétaire").Value = "USA"
500: Else
505: rstItemFRS.Fields("DeviseMonétaire").Value = "SPA"
510: End If
515: End If
		
520: Call rstItemFRS.Update()
		
525: Call rstItemFRS.Close()
530: 'UPGRADE_NOTE: Object rstItemFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstItemFRS = Nothing
		
535: If optUSA.Checked = True Or optSpain.Checked = True Then
540: rstConfig = New ADODB.Recordset
			
545: Call rstConfig.Open("SELECT TauxAmericain, TauxEspagnol FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
550: If optUSA.Checked = True Then
555: rstConfig.Fields("TauxAmericain").Value = txtTauxChange.Text
560: Else
565: rstConfig.Fields("TauxEspagnol").Value = txtTauxChange.Text
570: End If
			
575: Call rstConfig.Update()
			
580: Call rstConfig.Close()
585: 'UPGRADE_NOTE: Object rstConfig may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstConfig = Nothing
590: End If
		
		'Rétablir les boutons
595: Call MontrerControles(enumModeCatalogueElec.MODE_INACTIF)
		
600: If VB6.GetItemData(cmbfrs, cmbfrs.SelectedIndex) = 717 Then
605: rstInv = New ADODB.Recordset
			
610: Call rstInv.Open("SELECT * FROM GRB_InventaireElec WHERE NoItem = '" & Replace(txtNoItem.Text, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
615: If Not rstInv.EOF Then
620: If txtPrixNet.Text <> "" Then
625: If rstInv.Fields("CommandeParBoite").Value = True Then
630: rstInv.Fields("Prix Liste").Value = CDbl(txtPrixList.Text) / rstInv.Fields("QteBoite").Value
635: rstInv.Fields("Escompte").Value = mskEscompte.Text
640: rstInv.Fields("Prix net").Value = CDbl(txtPrixNet.Text) / rstInv.Fields("QteBoite").Value
645: Else
650: rstInv.Fields("Prix Liste").Value = txtPrixList.Text
655: rstInv.Fields("Escompte").Value = mskEscompte.Text
660: rstInv.Fields("Prix net").Value = txtPrixNet.Text
665: End If
670: Else
675: If rstInv.Fields("CommandeParBoite").Value = True Then
680: rstInv.Fields("Prix Liste").Value = CDbl(txtPrixSpecial.Text) / rstInv.Fields("QteBoite").Value
685: rstInv.Fields("Escompte").Value = ""
690: rstInv.Fields("Prix net").Value = CDbl(txtPrixSpecial.Text) / rstInv.Fields("QteBoite").Value
695: Else
700: rstInv.Fields("Prix Liste").Value = txtPrixSpecial.Text
705: rstInv.Fields("Escompte").Value = ""
710: rstInv.Fields("Prix net").Value = txtPrixSpecial.Text
715: End If
720: End If
				
725: Call rstInv.Update()
730: End If
			
735: Call rstInv.Close()
740: 'UPGRADE_NOTE: Object rstInv may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstInv = Nothing
745: End If
		
		'Remplis le ListView
750: Call RemplirListViewFournisseur()
		
755: Exit Sub
		
AfficherErreur: 
		
760: Call AfficherErreur("frmCatalogueElec", "EnregistrerFRS", Err, Erl())
	End Sub
	
	Private Sub CmdFerme_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdFerme.Click
		
5: On Error GoTo AfficherErreur
		
		'Fermeture de la fenêtre
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmCatalogueElec", "CmdFerme_Click", Err, Erl())
	End Sub
	
	Private Sub CmdModif_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdModif.Click
		
5: On Error GoTo AfficherErreur
		
		'procedure qui permet de modifier l'enregistrement courant
		'on montre/cache les maskedBox
10: If cmbNoItem.Items.Count > 0 Then
			
			'Copie le contenu textbox dans les maskbox
15: Call MontrerControles(enumModeCatalogueElec.MODE_AJOUT_MODIF_ELEC)
			txtFabricant.Top = VB6.TwipsToPixelsY(960) 'GLL 2017-10-10 Modification pour ajouter la modification possible du Manufacturier
			cmbFabricant.Visible = False 'GLL 2017-10-10 Modification pour ajouter la modification possible du Manufacturier
			
20: m_sQteStockAvant = txtQuantiteStock.Text
			
25: Call BarrerChamps_piece(False)
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmCatalogueElec", "CmdModif_Click", Err, Erl())
	End Sub
	
	Private Sub cmdModifFrs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdModifFrs.Click
		
5: On Error GoTo AfficherErreur
		
		'modifie un fournisseur pour la piece
10: If lvwfournisseur.Items.Count > 0 Then
15: Call ModifierFournisseur()
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCatalogueElec", "cmdModifFrs_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRechercheCategorie_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercheCategorie.Click
5: On Error GoTo AfficherErreur
		
10: Dim rstcatalog As ADODB.Recordset
15: Dim sDescription As String
20: Dim itmDescription As System.Windows.Forms.ListViewItem
		'ouvre un boite de dialogue pour savoir quoi rechercher
25: sDescription = InputBox("Quelle est la description à rechercher")
		
30: If sDescription <> vbNullString Then 'Si il y a quelque chose a chercher
35: Call lvwCategorie.Items.Clear() 'Vide la liste pour ne pas avoir l'ancienne recherche
			
40: sDescription = Replace(sDescription, "'", "''")
			
45: sDescription = "%" & sDescription & "%"
			
50: rstcatalog = New ADODB.Recordset
			
55: 
			Call rstcatalog.Open("SELECT DISTINCT CATEGORIE FROM GRB_CatalogueElec WHERE  Categorie LIKE '" & sDescription & "'  ORDER BY CATEGORIE", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			'Rempli la liste pour pouvoir le sélectionner
60: Do While Not rstcatalog.EOF
65: itmDescription = lvwCategorie.Items.Add("")
				
70: itmDescription.Tag = rstcatalog.Fields("CATEGORIE").Value
				itmDescription.Text = rstcatalog.Fields("CATEGORIE").Value
				
155: Call rstcatalog.MoveNext()
160: Loop 
			'Fermeture de la table
165: Call rstcatalog.Close()
170: 'UPGRADE_NOTE: Object rstcatalog may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstcatalog = Nothing
			'si il y a des choix posible on les affiche
175: If lvwCategorie.Items.Count > 0 Then
180: lvwCategorie.Visible = True
				
185: Call lvwCategorie.Focus()
190: Else
195: Call MsgBox("Aucun enregistrement trouvé!")
200: End If
205: End If
		
210: Exit Sub
		
AfficherErreur: 
		
215: Call AfficherErreur("frmCatalogueElec", "cmdRechercheDescrFR_Click", Err, Erl())
		
	End Sub
	
	Private Sub cmdRechercheInventaire_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercheInventaire.Click
		
5: On Error GoTo AfficherErreur
		
10: Call frmRechercheInventaire.Afficher(ModuleMain.enumCatalogue.ELECTRIQUE)
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmCatalogueElec", "cmdRechercheInventaire_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRechercheAchat_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercheAchat.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstAchat As ADODB.Recordset
15: Dim itmAchat As System.Windows.Forms.ListViewItem
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
25: Call lvwRechercheAchat.Items.Clear()
		
30: rstAchat = New ADODB.Recordset
		
35: Call rstAchat.Open("SELECT DISTINCT (IDAchat + '-' + RIGHT('00' & IndexAchat,3)) As NumeroAchat, SUM(Qté) As QtéTotale FROM GRB_Achat_Pieces WHERE TRIM(PIECE) = '" & Trim(Replace(txtNoItem.Text, "'", "''")) & "' GROUP BY  (IDAchat + '-' + RIGHT('00' & IndexAchat,3))", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
40: Do While Not rstAchat.EOF
45: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwRechercheAchat.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmAchat = lvwRechercheAchat.Items.Add()
			
50: itmAchat.Text = rstAchat.Fields("NumeroAchat").Value
55: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_QUANTITE Then
				itmAchat.SubItems(I_COL_ACHAT_QUANTITE).Text = rstAchat.Fields("QtéTotale").Value
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_QUANTITE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("QtéTotale").Value))
			End If
			
60: Call rstAchat.MoveNext()
65: Loop 
		
70: Call rstAchat.Close()
75: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAchat = Nothing
		
80: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
85: If lvwRechercheAchat.Items.Count > 0 Then
90: lvwRechercheAchat.Visible = True
			
95: Call lvwRechercheAchat.Focus()
100: Else
105: Call MsgBox("Cette pièce n'a jamais été utilisée dans les achats!", MsgBoxStyle.OKOnly)
110: End If
		
115: Exit Sub
		
AfficherErreur: 
		
120: Call AfficherErreur("frmCatalogueElec", "cmdRechercheAchat_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRechercheJob_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercheJob.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjSoum As ADODB.Recordset
15: Dim itmProjSoum As System.Windows.Forms.ListViewItem
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
25: Call lvwRechercheJob.Items.Clear()
		
30: rstProjSoum = New ADODB.Recordset
		
35: Call rstProjSoum.Open("SELECT DISTINCT IDProjet, SUM(Qté) As QtéTotale FROM GRB_Projet_Pieces WHERE TRIM(NumItem) = '" & Trim(Replace(txtNoItem.Text, "'", "''")) & "' And Type = 'E' GROUP BY IDProjet", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
40: Do While Not rstProjSoum.EOF
45: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwRechercheJob.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmProjSoum = lvwRechercheJob.Items.Add()
			
50: itmProjSoum.Text = rstProjSoum.Fields("IDProjet").Value
55: 'UPGRADE_WARNING: Lower bound of collection itmProjSoum has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmProjSoum.SubItems.Count > I_COL_JOB_QUANTITE Then
				itmProjSoum.SubItems(I_COL_JOB_QUANTITE).Text = rstProjSoum.Fields("QtéTotale").Value
			Else
				itmProjSoum.SubItems.Insert(I_COL_JOB_QUANTITE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjSoum.Fields("QtéTotale").Value))
			End If
			
60: Call rstProjSoum.MoveNext()
65: Loop 
		
70: Call rstProjSoum.Close()
		
75: Call rstProjSoum.Open("SELECT DISTINCT IDSoumission, SUM(Qté) As QtéTotale FROM GRB_Soumission_Pieces WHERE TRIM(NumItem) = '" & Trim(Replace(txtNoItem.Text, "'", "''")) & "' And Type = 'E' GROUP BY IDSoumission", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
80: Do While Not rstProjSoum.EOF
85: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwRechercheJob.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmProjSoum = lvwRechercheJob.Items.Add()
			
90: itmProjSoum.Text = rstProjSoum.Fields("IDSoumission").Value
95: 'UPGRADE_WARNING: Lower bound of collection itmProjSoum has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmProjSoum.SubItems.Count > I_COL_JOB_QUANTITE Then
				itmProjSoum.SubItems(I_COL_JOB_QUANTITE).Text = rstProjSoum.Fields("QtéTotale").Value
			Else
				itmProjSoum.SubItems.Insert(I_COL_JOB_QUANTITE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjSoum.Fields("QtéTotale").Value))
			End If
			
100: Call rstProjSoum.MoveNext()
105: Loop 
		
110: Call rstProjSoum.Close()
115: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjSoum = Nothing
		
120: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
125: If lvwRechercheJob.Items.Count > 0 Then
130: lvwRechercheJob.Visible = True
			
135: Call lvwRechercheJob.Focus()
140: Else
145: Call MsgBox("Cette pièce n'a jamais été utilisée dans les jobs!", MsgBoxStyle.OKOnly)
150: End If
		
155: Exit Sub
		
AfficherErreur: 
		
160: Call AfficherErreur("frmCatalogueElec", "cmdRechercheJob_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRechercherManufacturier_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercherManufacturier.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstManufact As ADODB.Recordset
15: Dim sManufact As String
20: Dim itmManufact As System.Windows.Forms.ListViewItem
		
25: sManufact = InputBox("Quel est le manufacturier à rechercher?")
		
30: sManufact = Replace(sManufact, "'", "''")
		
35: If sManufact <> vbNullString Then
40: Call lvwFabricant.Items.Clear()
			
45: rstManufact = New ADODB.Recordset
			
50: Call rstManufact.Open("SELECT * FROM GRB_CatalogueElec WHERE INSTR(1, FABRICANT, '" & sManufact & "') > 0 ORDER BY FABRICANT", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
55: Do While Not rstManufact.EOF
60: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwFabricant.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmManufact = lvwFabricant.Items.Add()
				
65: itmManufact.Tag = rstManufact.Fields("CATEGORIE").Value
				
70: itmManufact.Text = Trim(rstManufact.Fields("FABRICANT").Value)
				
75: 'UPGRADE_WARNING: Lower bound of collection itmManufact has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmManufact.SubItems.Count > I_COL_MAN_PIECE Then
					itmManufact.SubItems(I_COL_MAN_PIECE).Text = Trim(rstManufact.Fields("PIECE").Value)
				Else
					itmManufact.SubItems.Insert(I_COL_MAN_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Trim(rstManufact.Fields("PIECE").Value)))
				End If
				
80: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstManufact.Fields("DESC_FR").Value) Then
85: 'UPGRADE_WARNING: Lower bound of collection itmManufact has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmManufact.SubItems.Count > I_COL_MAN_DESCR_FR Then
						itmManufact.SubItems(I_COL_MAN_DESCR_FR).Text = Trim(rstManufact.Fields("DESC_FR").Value)
					Else
						itmManufact.SubItems.Insert(I_COL_MAN_DESCR_FR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Trim(rstManufact.Fields("DESC_FR").Value)))
					End If
90: Else
95: 'UPGRADE_WARNING: Lower bound of collection itmManufact has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmManufact.SubItems.Count > I_COL_MAN_DESCR_FR Then
						itmManufact.SubItems(I_COL_MAN_DESCR_FR).Text = vbNullString
					Else
						itmManufact.SubItems.Insert(I_COL_MAN_DESCR_FR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
100: End If
				
105: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstManufact.Fields("DESC_EN").Value) Then
110: 'UPGRADE_WARNING: Lower bound of collection itmManufact has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmManufact.SubItems.Count > I_COL_MAN_DESCR_EN Then
						itmManufact.SubItems(I_COL_MAN_DESCR_EN).Text = Trim(rstManufact.Fields("DESC_EN").Value)
					Else
						itmManufact.SubItems.Insert(I_COL_MAN_DESCR_EN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Trim(rstManufact.Fields("DESC_EN").Value)))
					End If
115: Else
120: 'UPGRADE_WARNING: Lower bound of collection itmManufact has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmManufact.SubItems.Count > I_COL_MAN_DESCR_EN Then
						itmManufact.SubItems(I_COL_MAN_DESCR_EN).Text = vbNullString
					Else
						itmManufact.SubItems.Insert(I_COL_MAN_DESCR_EN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
125: End If
				
130: Call rstManufact.MoveNext()
135: Loop 
			
140: Call rstManufact.Close()
145: 'UPGRADE_NOTE: Object rstManufact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstManufact = Nothing
			
150: If lvwFabricant.Items.Count > 0 Then
155: lvwFabricant.Visible = True
				
160: Call lvwFabricant.Focus()
165: Else
170: Call MsgBox("Aucun enregistrement trouvé!")
175: End If
180: End If
		
185: Exit Sub
		
AfficherErreur: 
		
190: Call AfficherErreur("frmCatalogueElec", "cmdRechercherManufacturier_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRechercherPiece_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercherPiece.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPiece As ADODB.Recordset
15: Dim sPiece As String
20: Dim itmPiece As System.Windows.Forms.ListViewItem
25: Dim iCompteur As Short
30: Dim sPieceModif As String
35: Dim sLettre As String
		
40: sPiece = InputBox("Quelle est la pièce à rechercher?")
		
45: If sPiece <> vbNullString Then
50: For iCompteur = 1 To Len(sPiece)
55: sLettre = Mid(sPiece, iCompteur, 1)
				
60: If (Asc(sLettre) >= 48 And Asc(sLettre) <= 57) Or (Asc(sLettre) >= 65 And Asc(sLettre) <= 90) Or (Asc(sLettre) >= 97 And Asc(sLettre) <= 122) Then
65: sPieceModif = sPieceModif & sLettre
70: End If
75: Next 
			
80: Call lvwPieces.Items.Clear()
			
85: rstPiece = New ADODB.Recordset
			
90: Call rstPiece.Open("SELECT * FROM GRB_CatalogueElec WHERE INSTR(1, PIECE_MODIF, '" & sPieceModif & "') > 0 ORDER BY PIECE", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
95: Do While Not rstPiece.EOF
100: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPieces.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmPiece = lvwPieces.Items.Add()
				
105: itmPiece.Text = Trim(rstPiece.Fields("PIECE").Value)
				
110: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPiece.Fields("FABRICANT").Value) Then
115: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_PIECE_FABRICANT Then
						itmPiece.SubItems(I_COL_PIECE_FABRICANT).Text = Trim(rstPiece.Fields("FABRICANT").Value)
					Else
						itmPiece.SubItems.Insert(I_COL_PIECE_FABRICANT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Trim(rstPiece.Fields("FABRICANT").Value)))
					End If
120: Else
125: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_PIECE_FABRICANT Then
						itmPiece.SubItems(I_COL_PIECE_FABRICANT).Text = vbNullString
					Else
						itmPiece.SubItems.Insert(I_COL_PIECE_FABRICANT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
130: End If
				
135: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPiece.Fields("DESC_FR").Value) Then
140: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_PIECE_DESCR_FR Then
						itmPiece.SubItems(I_COL_PIECE_DESCR_FR).Text = Trim(rstPiece.Fields("DESC_FR").Value)
					Else
						itmPiece.SubItems.Insert(I_COL_PIECE_DESCR_FR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Trim(rstPiece.Fields("DESC_FR").Value)))
					End If
145: Else
150: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_PIECE_DESCR_FR Then
						itmPiece.SubItems(I_COL_PIECE_DESCR_FR).Text = vbNullString
					Else
						itmPiece.SubItems.Insert(I_COL_PIECE_DESCR_FR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
155: End If
				
160: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPiece.Fields("DESC_EN").Value) Then
165: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_PIECE_DESCR_EN Then
						itmPiece.SubItems(I_COL_PIECE_DESCR_EN).Text = Trim(rstPiece.Fields("DESC_EN").Value)
					Else
						itmPiece.SubItems.Insert(I_COL_PIECE_DESCR_EN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Trim(rstPiece.Fields("DESC_EN").Value)))
					End If
170: Else
175: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_PIECE_DESCR_EN Then
						itmPiece.SubItems(I_COL_PIECE_DESCR_EN).Text = vbNullString
					Else
						itmPiece.SubItems.Insert(I_COL_PIECE_DESCR_EN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
180: End If
				
185: itmPiece.Tag = rstPiece.Fields("CATEGORIE").Value
				
190: Call rstPiece.MoveNext()
195: Loop 
			
200: Call rstPiece.Close()
205: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstPiece = Nothing
			
210: If lvwPieces.Items.Count > 0 Then
215: lvwPieces.Visible = True
				
220: Call lvwPieces.Focus()
225: Else
230: Call MsgBox("Aucun enregistrement trouvé!")
235: End If
240: End If
		
245: Exit Sub
		
AfficherErreur: 
		
250: Call AfficherErreur("frmCatalogueElec", "cmdRechercherPiece_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRechercheDescrFR_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercheDescrFR.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstDescription As ADODB.Recordset
15: Dim sDescription As String
20: Dim itmDescription As System.Windows.Forms.ListViewItem
		
25: sDescription = InputBox("Quelle est la description à rechercher")
		
30: If sDescription <> vbNullString Then
35: Call lvwDescription.Items.Clear()
			
40: sDescription = Replace(sDescription, "'", "''")
			
45: sDescription = "%" & sDescription & "%"
			
50: rstDescription = New ADODB.Recordset
			
55: Call rstDescription.Open("SELECT * FROM GRB_CatalogueElec WHERE DESC_FR LIKE '" & sDescription & "' OR DESC_EN LIKE '" & sDescription & "' ORDER BY DESC_FR, DESC_EN", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
60: Do While Not rstDescription.EOF
65: itmDescription = lvwDescription.Items.Add("")
				
70: itmDescription.Tag = rstDescription.Fields("CATEGORIE").Value
				
75: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstDescription.Fields("DESC_FR").Value) Then
80: itmDescription.Text = Trim(rstDescription.Fields("DESC_FR").Value)
85: Else
90: itmDescription.Text = vbNullString
95: End If
				
100: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstDescription.Fields("DESC_EN").Value) Then
105: 'UPGRADE_WARNING: Lower bound of collection itmDescription has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmDescription.SubItems.Count > I_COL_DES_DESCR_EN Then
						itmDescription.SubItems(I_COL_DES_DESCR_EN).Text = Trim(rstDescription.Fields("DESC_EN").Value)
					Else
						itmDescription.SubItems.Insert(I_COL_DES_DESCR_EN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Trim(rstDescription.Fields("DESC_EN").Value)))
					End If
110: Else
115: 'UPGRADE_WARNING: Lower bound of collection itmDescription has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmDescription.SubItems.Count > I_COL_DES_DESCR_EN Then
						itmDescription.SubItems(I_COL_DES_DESCR_EN).Text = vbNullString
					Else
						itmDescription.SubItems.Insert(I_COL_DES_DESCR_EN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
120: End If
				
125: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstDescription.Fields("FABRICANT").Value) Then
130: 'UPGRADE_WARNING: Lower bound of collection itmDescription has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmDescription.SubItems.Count > I_COL_DES_FABRICANT Then
						itmDescription.SubItems(I_COL_DES_FABRICANT).Text = Trim(rstDescription.Fields("FABRICANT").Value)
					Else
						itmDescription.SubItems.Insert(I_COL_DES_FABRICANT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Trim(rstDescription.Fields("FABRICANT").Value)))
					End If
135: Else
140: 'UPGRADE_WARNING: Lower bound of collection itmDescription has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmDescription.SubItems.Count > I_COL_DES_FABRICANT Then
						itmDescription.SubItems(I_COL_DES_FABRICANT).Text = vbNullString
					Else
						itmDescription.SubItems.Insert(I_COL_DES_FABRICANT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
145: End If
				
150: 'UPGRADE_WARNING: Lower bound of collection itmDescription has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmDescription.SubItems.Count > I_COL_DES_PIECE Then
					itmDescription.SubItems(I_COL_DES_PIECE).Text = Trim(rstDescription.Fields("PIECE").Value)
				Else
					itmDescription.SubItems.Insert(I_COL_DES_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Trim(rstDescription.Fields("PIECE").Value)))
				End If
				
155: Call rstDescription.MoveNext()
160: Loop 
			
165: Call rstDescription.Close()
170: 'UPGRADE_NOTE: Object rstDescription may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstDescription = Nothing
			
175: If lvwDescription.Items.Count > 0 Then
180: lvwDescription.Visible = True
				
185: Call lvwDescription.Focus()
190: Else
195: Call MsgBox("Aucun enregistrement trouvé!")
200: End If
205: End If
		
210: Exit Sub
		
AfficherErreur: 
		
215: Call AfficherErreur("frmCatalogueElec", "cmdRechercheDescrFR_Click", Err, Erl())
	End Sub
	
	Private Sub cmdTotal_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTotal.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim sAnnee As String
15: Dim rstTotal As ADODB.Recordset
20: Dim dblTotalProj As Double
25: Dim dblTotalAchat As Double
		
30: sAnnee = InputBox("Pour quelle année? (AAAA)")
		
35: If Len(sAnnee) = 4 Then
40: If IsNumeric(sAnnee) Then
45: If CShort(sAnnee) <= Year(Today) Then
50: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
					
55: rstTotal = New ADODB.Recordset
					
60: Call rstTotal.Open("SELECT SUM(Qté) As Total FROM GRB_Projet_Pieces INNER JOIN GRB_ProjetElec ON GRB_Projet_Pieces.IDProjet = GRB_ProjetElec.IDProjet WHERE TRIM(NumItem) = '" & Trim(Replace(txtNoItem.Text, "'", "''")) & "' AND Type = 'E' AND Left(Creer,4) = '" & sAnnee & "' AND RIGHT(GRB_Projet_Pieces.IDProjet,2) < '60'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
65: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstTotal.Fields("Total").Value) Then
70: dblTotalProj = CDbl(rstTotal.Fields("Total").Value)
75: Else
80: dblTotalProj = 0
85: End If
					
90: Call rstTotal.Close()
					
95: Call rstTotal.Open("SELECT SUM(Qté) As Total FROM GRB_Achat_Pieces INNER JOIN GRB_Achat ON GRB_Achat_Pieces.IDAchat = GRB_Achat.IDAchat AND GRB_Achat_Pieces.IndexAchat = GRB_Achat.IndexAchat WHERE TRIM(PIECE) = '" & Trim(Replace(txtNoItem.Text, "'", "''")) & "' AND Left(DateAchat,4) = '" & sAnnee & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
100: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstTotal.Fields("Total").Value) Then
105: dblTotalAchat = CDbl(rstTotal.Fields("Total").Value)
110: Else
115: dblTotalAchat = 0
120: End If
					
125: Call rstTotal.Close()
130: 'UPGRADE_NOTE: Object rstTotal may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstTotal = Nothing
					
135: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
					
140: Call MsgBox("Quantité utilisée en " & sAnnee & " : " & vbNewLine & vbNewLine & "Projets : " & dblTotalProj & vbNewLine & "Achats : " & dblTotalAchat)
145: Else
150: Call MsgBox("Année trop grande!", MsgBoxStyle.OKOnly, "Erreur")
155: End If
160: Else
165: Call MsgBox("Année non numérique!", MsgBoxStyle.OKOnly, "Erreur")
170: End If
175: Else
180: If Len(sAnnee) <> 0 Then
185: Call MsgBox("L'année doit être sur 4 chiffres!", MsgBoxStyle.OKOnly, "Erreur")
190: End If
195: End If
		
200: Exit Sub
		
AfficherErreur: 
		
205: Call AfficherErreur("frmCatalogueElec", "cmdTotal_Click", Err, Erl())
	End Sub
	
	
	
	Private Sub FrmCatalogueElec_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Click
		
5: On Error GoTo AfficherErreur
		
10: lvwDescription.Visible = False
15: lvwFabricant.Visible = False
20: lvwPieces.Visible = False
25: lvwRechercheJob.Visible = False
30: lvwRechercheAchat.Visible = False
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmCatalogueElec", "Form_Click", Err, Erl())
	End Sub
	
	Private Sub fraApprob_Click()
		
5: On Error GoTo AfficherErreur
		
10: lvwDescription.Visible = False
15: lvwFabricant.Visible = False
20: lvwPieces.Visible = False
25: lvwRechercheJob.Visible = False
30: lvwRechercheAchat.Visible = False
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmCatalogueElec", "fraApprob_Click", Err, Erl())
	End Sub
	
	'UPGRADE_ISSUE: Frame event frafournisseur.Click was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub frafournisseur_Click()
		
5: On Error GoTo AfficherErreur
		
10: lvwDescription.Visible = False
15: lvwFabricant.Visible = False
20: lvwPieces.Visible = False
25: lvwRechercheJob.Visible = False
30: lvwRechercheAchat.Visible = False
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmCatalogueElec", "fraFournisseur_Click", Err, Erl())
	End Sub
	
	'UPGRADE_ISSUE: Frame event fraQuantité.Click was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub fraQuantité_Click()
		
5: On Error GoTo AfficherErreur
		
10: lvwDescription.Visible = False
15: lvwFabricant.Visible = False
20: lvwPieces.Visible = False
25: lvwRechercheJob.Visible = False
30: lvwRechercheAchat.Visible = False
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmCatalogueElec", "fraQuantité_Click", Err, Erl())
	End Sub
	
	
	
	Private Sub lvwCategorie_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwCategorie.DoubleClick
5: 
10: Dim itmDescription As System.Windows.Forms.ListViewItem
15: Dim iCompteur As Short
		
20: If lvwCategorie.Items.Count > 0 Then
25: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
30: itmDescription = lvwCategorie.FocusedItem
			
35: 'm_sSelectCategorie = itmDescription.Tag
40: 'm_sSelectFabricant = Trim$(itmDescription.SubItems(I_COL_DES_FABRICANT))
45: ' m_sSelectNoItem = Trim$(itmDescription.SubItems(I_COL_DES_PIECE))
			
50: 'If m_eMode = MODE_INACTIF Then
55: '  Call RemplirComboCategorie
60: 'Else
65: cmbCategorie.Text = lvwCategorie.FocusedItem.Text
75: 'pour pouvoir
			Call cmbCategorie_SelectedIndexChanged(cmbCategorie, New System.EventArgs())
80: lvwCategorie.Visible = False
			
85: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
90: End If
		
95: Exit Sub
	End Sub
	
	Private Sub lvwCategorie_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwCategorie.Leave
5: On Error GoTo AfficherErreur
		
10: If lvwCategorie.Visible = True Then
15: lvwCategorie.Visible = False
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCatalogueElec", "lvwCategorie_LostFocus", Err, Erl())
	End Sub
	
	Private Sub lvwDescription_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lvwDescription.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: If KeyCode = System.Windows.Forms.Keys.Return Then
15: Call lvwDescription_DoubleClick(lvwDescription, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCatalogueElec", "lvwDescription_KeyDown", Err, Erl())
	End Sub
	
	Private Sub lvwFabricant_ColumnClick(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ColumnClickEventArgs) Handles lvwFabricant.ColumnClick
		Dim ColumnHeader As System.Windows.Forms.ColumnHeader = lvwFabricant.Columns(eventArgs.Column)
		
5: On Error GoTo AfficherErreur
		
10: lvwFabricant.Sort()
		
15: If lvwFabricant.Sorting = System.Windows.Forms.SortOrder.Ascending Then
20: lvwFabricant.Sorting = System.Windows.Forms.SortOrder.Descending
25: Else
30: lvwFabricant.Sorting = System.Windows.Forms.SortOrder.Ascending
35: End If
		
40: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwFabricant.SortKey was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		lvwFabricant.SortKey = ColumnHeader.Index - 1
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmCatalogueElec", "lvwFabricant_ColumnClick", Err, Erl())
	End Sub
	
	Private Sub lvwDescription_ColumnClick(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ColumnClickEventArgs) Handles lvwDescription.ColumnClick
		Dim ColumnHeader As System.Windows.Forms.ColumnHeader = lvwDescription.Columns(eventArgs.Column)
		
5: On Error GoTo AfficherErreur
		
10: lvwDescription.Sort()
		
15: If lvwDescription.Sorting = System.Windows.Forms.SortOrder.Ascending Then
20: lvwDescription.Sorting = System.Windows.Forms.SortOrder.Descending
25: Else
30: lvwDescription.Sorting = System.Windows.Forms.SortOrder.Ascending
35: End If
		
40: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwDescription.SortKey was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		lvwDescription.SortKey = ColumnHeader.Index - 1
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmCatalogueElec", "lvwDescription_ColumnClick", Err, Erl())
	End Sub
	
	Private Sub lvwFabricant_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lvwFabricant.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: If KeyCode = System.Windows.Forms.Keys.Return Then
15: Call lvwFabricant_DoubleClick(lvwFabricant, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCatalogueElec", "lvwFabricant_KeyDown", Err, Erl())
	End Sub
	
	Private Sub lvwPieces_ColumnClick(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ColumnClickEventArgs) Handles lvwPieces.ColumnClick
		Dim ColumnHeader As System.Windows.Forms.ColumnHeader = lvwPieces.Columns(eventArgs.Column)
		
5: On Error GoTo AfficherErreur
		
10: If lvwPieces.Sorting = System.Windows.Forms.SortOrder.Ascending Then
15: lvwPieces.Sorting = System.Windows.Forms.SortOrder.Descending
20: Else
25: lvwPieces.Sorting = System.Windows.Forms.SortOrder.Ascending
30: End If
		
35: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwPieces.SortKey was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		lvwPieces.SortKey = ColumnHeader.Index - 1
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmCatalogueElec", "lvwPieces_ColumnClick", Err, Erl())
	End Sub
	
	Private Sub lvwPieces_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lvwPieces.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: If KeyCode = System.Windows.Forms.Keys.Return Then
15: Call lvwPieces_DoubleClick(lvwPieces, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCatalogueElec", "lvwPieces_KeyDown", Err, Erl())
	End Sub
	
	
	
	Private Sub lvwRechercheJob_ColumnClick(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ColumnClickEventArgs) Handles lvwRechercheJob.ColumnClick
		Dim ColumnHeader As System.Windows.Forms.ColumnHeader = lvwRechercheJob.Columns(eventArgs.Column)
		
5: On Error GoTo AfficherErreur
		
10: If lvwRechercheJob.Sorting = System.Windows.Forms.SortOrder.Ascending Then
15: lvwRechercheJob.Sorting = System.Windows.Forms.SortOrder.Descending
20: Else
25: lvwRechercheJob.Sorting = System.Windows.Forms.SortOrder.Ascending
30: End If
		
35: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwRechercheJob.SortKey was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		lvwRechercheJob.SortKey = ColumnHeader.Index - 1
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmCatalogueElec", "lvwRechercheJob_ColumnClick", Err, Erl())
	End Sub
	
	Private Sub lvwRechercheAchat_ColumnClick(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ColumnClickEventArgs) Handles lvwRechercheAchat.ColumnClick
		Dim ColumnHeader As System.Windows.Forms.ColumnHeader = lvwRechercheAchat.Columns(eventArgs.Column)
		
5: On Error GoTo AfficherErreur
		
10: If lvwRechercheAchat.Sorting = System.Windows.Forms.SortOrder.Ascending Then
15: lvwRechercheAchat.Sorting = System.Windows.Forms.SortOrder.Descending
20: Else
25: lvwRechercheAchat.Sorting = System.Windows.Forms.SortOrder.Ascending
30: End If
		
35: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwRechercheAchat.SortKey was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		lvwRechercheAchat.SortKey = ColumnHeader.Index - 1
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmCatalogueElec", "lvwRechercheAchat_ColumnClick", Err, Erl())
	End Sub
	
	Private Sub lvwFabricant_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwFabricant.DoubleClick
		
5: On Error GoTo AfficherErreur
		
10: Dim itmFabricant As System.Windows.Forms.ListViewItem
15: Dim iCompteur As Short
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
25: itmFabricant = lvwFabricant.FocusedItem
		
30: m_sSelectCategorie = Trim(itmFabricant.Tag)
35: m_sSelectFabricant = Trim(itmFabricant.Text)
40: 'UPGRADE_WARNING: Lower bound of collection itmFabricant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		m_sSelectNoItem = Trim(itmFabricant.SubItems(I_COL_MAN_PIECE).Text)
		
45: Call RemplirComboCategorie()
		
50: For iCompteur = 0 To cmbCategorie.Items.Count - 1
55: If VB6.GetItemString(cmbCategorie, iCompteur) = Trim(itmFabricant.Tag) Then
60: cmbCategorie.SelectedIndex = iCompteur
				
65: Exit For
70: End If
75: Next 
		
80: For iCompteur = 0 To cmbNoItem.Items.Count - 1
85: 'UPGRADE_WARNING: Lower bound of collection itmFabricant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If VB6.GetItemString(cmbNoItem, iCompteur) = Trim(itmFabricant.SubItems(I_COL_MAN_PIECE).Text) Then
90: cmbNoItem.SelectedIndex = iCompteur
				
95: Exit For
100: End If
105: Next 
		
110: lvwFabricant.Visible = False
		
115: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
120: Exit Sub
		
AfficherErreur: 
		
125: Call AfficherErreur("frmCatalogueElec", "lvwFabricant_DblClick", Err, Erl())
	End Sub
	
	Private Sub lvwDescription_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwDescription.DoubleClick
		
5: On Error GoTo AfficherErreur
		
10: Dim itmDescription As System.Windows.Forms.ListViewItem
15: Dim iCompteur As Short
		
20: If lvwDescription.Items.Count > 0 Then
25: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
30: itmDescription = lvwDescription.FocusedItem
			
35: 'UPGRADE_WARNING: Couldn't resolve default property of object itmDescription.Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			m_sSelectCategorie = itmDescription.Tag
40: 'UPGRADE_WARNING: Lower bound of collection itmDescription has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			m_sSelectFabricant = Trim(itmDescription.SubItems(I_COL_DES_FABRICANT).Text)
45: 'UPGRADE_WARNING: Lower bound of collection itmDescription has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			m_sSelectNoItem = Trim(itmDescription.SubItems(I_COL_DES_PIECE).Text)
			
50: If m_eMode = enumModeCatalogueElec.MODE_INACTIF Then
55: Call RemplirComboCategorie()
60: Else
65: txtDescriptionFR.Text = itmDescription.Text
70: 'UPGRADE_WARNING: Lower bound of collection itmDescription has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				txtDescriptionEN.Text = itmDescription.SubItems(I_COL_DES_DESCR_EN).Text
75: End If
			
80: lvwDescription.Visible = False
			
85: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
90: End If
		
95: Exit Sub
		
AfficherErreur: 
		
100: Call AfficherErreur("frmCatalogueElec", "lvwDescription_DblClick", Err, Erl())
	End Sub
	
	Private Sub lvwFabricant_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwFabricant.Leave
		
5: On Error GoTo AfficherErreur
		
10: If lvwFabricant.Visible = True Then
15: lvwFabricant.Visible = False
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCatalogueElec", "lvwFabricant_LostFocus", Err, Erl())
	End Sub
	
	Private Sub lvwPieces_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwPieces.DoubleClick
		
5: On Error GoTo AfficherErreur
		
10: Dim itmPieces As System.Windows.Forms.ListViewItem
15: Dim iCompteur As Short
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
25: itmPieces = lvwPieces.FocusedItem
		
30: m_sSelectCategorie = Trim(itmPieces.Tag)
35: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		m_sSelectFabricant = Trim(itmPieces.SubItems(I_COL_PIECE_FABRICANT).Text)
40: m_sSelectNoItem = Trim(itmPieces.Text)
		
45: Call RemplirComboCategorie()
		
50: lvwPieces.Visible = False
		
55: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmCatalogueElec", "lvwPieces_DblClick", Err, Erl())
	End Sub
	
	Private Sub CmdSupp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdSupp.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim sDescription As String
15: Dim iCompteur As Short
		
20: If cmbNoItem.Items.Count > 0 Then
25: If MsgBox("Voulez-vous vraiment effacer la pièce " & txtNoItem.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
30: If chkInventaire.CheckState = System.Windows.Forms.CheckState.Checked Then
35: Call g_connData.Execute("DELETE * FROM GRB_InventaireElec WHERE NoItem = '" & Replace(cmbNoItem.Text, "'", "''") & "'")
40: End If
				
				'Efface l'enregistrement de catalogue
45: Call g_connData.Execute("DELETE * FROM GRB_CatalogueElec WHERE PIECE = '" & Replace(cmbNoItem.Text, "'", "''") & "'")
				
				'Efface l'enr de la table piece frs
50: Call g_connData.Execute("DELETE * FROM GRB_PiecesFRS WHERE PIECE = '" & Replace(cmbNoItem.Text, "'", "''") & "'")
				
55: m_bRempliManuel = True
				
60: m_sSelectNoItem = vbNullString
				
65: If cmbNoItem.Items.Count > 1 Then
70: m_sSelectFabricant = cmbFabricant.Text
75: Else
80: m_sSelectFabricant = vbNullString
85: End If
				
90: Call RemplirComboFabricant()
				
95: If cmbFabricant.Items.Count = 0 Then
100: Call cmbNoItem.Items.Clear()
					
105: Call cmbCategorie.Items.RemoveAt(cmbCategorie.SelectedIndex)
					
110: If cmbCategorie.Items.Count > 0 Then
115: cmbCategorie.SelectedIndex = 0
120: Else
125: Call ViderChamps_frs()
						
130: Call lvwfournisseur.Items.Clear()
						
135: Call ViderChamps_piece()
140: End If
145: End If
				
150: sDescription = txtDescriptionFR.Text
				
155: For iCompteur = 0 To cmbDescriptionFR.Items.Count - 1
160: If VB6.GetItemString(cmbDescriptionFR, iCompteur) = sDescription Then
165: m_bBloqueDescription = True
						
170: cmbDescriptionFR.SelectedIndex = iCompteur
						
175: m_bBloqueDescription = False
						
180: Exit For
185: End If
190: Next 
195: End If
200: End If
		
205: Exit Sub
		
AfficherErreur: 
		
210: Call AfficherErreur("frmCatalogueElec", "CmdSupp_Click", Err, Erl())
	End Sub
	
	Private Sub AfficherItem()
		
5: On Error GoTo AfficherErreur
		
		'Affichage de l'enregistrement
10: Dim rstItem As ADODB.Recordset
15: Dim rstInventaire As ADODB.Recordset
20: Dim iCompteur As Short
		
		'Il faut mettre le frame enabled pour vérifier si les CheckBox à l'intérieur
		'sont enabled
25: Call ViderChamps_piece()
		
30: rstItem = New ADODB.Recordset
		
35: Call rstItem.Open("SELECT * FROM GRB_CatalogueElec WHERE PIECE = '" & Replace(m_sNoItem, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Si il y a un enregistrement
40: If Not rstItem.EOF Then
			'PIECE_GRB
45: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstItem.Fields("PIECE_GRB").Value) Then
50: txtNoItemGRB.Text = Trim(rstItem.Fields("PIECE_GRB").Value)
55: Else
60: txtNoItemGRB.Text = vbNullString
65: End If
			
			'DESCR_EN
70: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstItem.Fields("DESC_EN").Value) Then
71: txtDescriptionEN.Text = Trim(rstItem.Fields("DESC_EN").Value)
72: Else
73: txtDescriptionEN.Text = vbNullString
74: End If
			
			'FABRICANT
80: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstItem.Fields("FABRICANT").Value) Then
81: txtFabricant.Text = Trim(rstItem.Fields("FABRICANT").Value)
82: Else
83: txtFabricant.Text = vbNullString
84: End If
			
			'DESCR_FR
95: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstItem.Fields("DESC_FR").Value) Then
100: For iCompteur = 0 To cmbDescriptionFR.Items.Count - 1
105: If VB6.GetItemString(cmbDescriptionFR, iCompteur) = Trim(rstItem.Fields("DESC_FR").Value) Then
110: cmbDescriptionFR.SelectedIndex = iCompteur
						
115: Exit For
120: End If
125: Next 
130: Else
135: If cmbDescriptionFR.SelectedIndex = -1 Then
140: Call cmbDescriptionFR_SelectedIndexChanged(cmbDescriptionFR, New System.EventArgs())
145: Else
150: cmbDescriptionFR.SelectedIndex = -1
155: End If
160: End If
			
			'TEMPS
165: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstItem.Fields("TEMPS").Value) Then
170: txtTemps.Text = Trim(rstItem.Fields("TEMPS").Value)
175: Else
180: txtTemps.Text = vbNullString
185: End If
			
			'COMMENT
190: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstItem.Fields("COMMENTAIRE").Value) Then
195: txtComment.Text = Trim(rstItem.Fields("COMMENTAIRE").Value)
200: Else
205: txtComment.Text = vbNullString
210: End If
			
215: Call RemplirListViewFournisseur()
			
220: Else
225: Call MsgBox("Impossible de trouver la pièce!", MsgBoxStyle.OKOnly, "Erreur")
230: End If
		
235: Call rstItem.Close()
240: 'UPGRADE_NOTE: Object rstItem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstItem = Nothing
		
245: rstInventaire = New ADODB.Recordset
		
250: Call rstInventaire.Open("SELECT * FROM GRB_InventaireElec WHERE NoItem = '" & Replace(txtNoItem.Text, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
255: If Not rstInventaire.EOF Then
260: chkInventaire.CheckState = System.Windows.Forms.CheckState.Checked
			
265: chkBoite.CheckState = System.Math.Abs(CShort(rstInventaire.Fields("CommandeParBoite").Value))
			
270: If chkBoite.CheckState = System.Windows.Forms.CheckState.Checked Then
275: txtQuantitéBoite.Text = rstInventaire.Fields("QteBoite").Value
280: End If
			
285: For iCompteur = 0 To cmbLocalisation.Items.Count - 1
290: If VB6.GetItemString(cmbLocalisation, iCompteur) = rstInventaire.Fields("Localisation").Value Then
295: cmbLocalisation.SelectedIndex = iCompteur
					
300: Exit For
305: End If
310: Next 
			
315: txtQuantiteStock.Text = rstInventaire.Fields("QuantitéStock").Value
320: chkMinimum.CheckState = System.Math.Abs(CShort(rstInventaire.Fields("Minimum").Value))
325: txtQuantiteMinimum.Text = rstInventaire.Fields("QuantitéMinimum").Value
330: txtQuantiteCommande.Text = rstInventaire.Fields("Commande").Value
335: End If
		
340: Call rstInventaire.Close()
345: 'UPGRADE_NOTE: Object rstInventaire may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstInventaire = Nothing
		
350: Exit Sub
		
AfficherErreur: 
		
355: Call AfficherErreur("frmCatalogueElec", "AfficherItem", Err, Erl())
	End Sub
	
	Private Sub AfficherFRS()
		
5: On Error GoTo AfficherErreur
		
		'Affichage de l'enregistrement
10: Dim rstItemFRS As ADODB.Recordset
15: Dim iCompteur As Short
		
20: rstItemFRS = New ADODB.Recordset
		
25: Call rstItemFRS.Open("SELECT * FROM GRB_PiecesFRS WHERE NoEnreg = " & lvwfournisseur.FocusedItem.Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Si le champs est Enabled.. c'est parce que le champs existe dans la table
		
		'DISTRIB
30: For iCompteur = 0 To cmbfrs.Items.Count - 1
35: If VB6.GetItemString(cmbfrs, iCompteur) = lvwfournisseur.FocusedItem.Text Then
40: cmbfrs.SelectedIndex = iCompteur
				
45: Exit For
50: End If
55: Next 
		
		'PERS_RESS
60: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstItemFRS.Fields("PERS_RESS").Value) Then
65: For iCompteur = 0 To cmbPersRess.Items.Count - 1
70: If VB6.GetItemData(cmbPersRess, iCompteur) = rstItemFRS.Fields("PERS_RESS").Value Then
75: cmbPersRess.SelectedIndex = iCompteur
					
80: Exit For
85: End If
90: Next 
95: Else
100: cmbPersRess.SelectedIndex = -1
105: End If
		
		'PRIX_LIST
110: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstItemFRS.Fields("PRIX_LIST").Value) Then
115: txtPrixList.Text = rstItemFRS.Fields("PRIX_LIST").Value
120: Else
125: txtPrixList.Text = vbNullString
130: End If
		
		'ESCOMPTE
135: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstItemFRS.Fields("ESCOMPTE").Value) Then
140: mskEscompte.Text = rstItemFRS.Fields("ESCOMPTE").Value
145: Else
150: mskEscompte.Text = vbNullString
155: End If
		
		'PRIX_NET
160: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstItemFRS.Fields("PRIX_NET").Value) Then
165: txtPrixNet.Text = rstItemFRS.Fields("PRIX_NET").Value
170: Else
175: txtPrixNet.Text = vbNullString
180: End If
		
		'PRIX_SP
185: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstItemFRS.Fields("PRIX_SP").Value) Then
190: txtPrixSpecial.Text = rstItemFRS.Fields("PRIX_SP").Value
195: Else
200: txtPrixSpecial.Text = vbNullString
205: End If
		
		
		'VALIDE
210: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstItemFRS.Fields("VALIDE").Value) Then
215: mskValide.Text = rstItemFRS.Fields("VALIDE").Value
220: Else
225: mskValide.Text = vbNullString
230: End If
		
		'QUOTER
235: If rstItemFRS.Fields("quoter").Value = True Then
240: chkquoter.CheckState = System.Windows.Forms.CheckState.Checked
245: Else
250: chkquoter.CheckState = System.Windows.Forms.CheckState.Unchecked
255: End If
		
		'Devise monétaire
260: If rstItemFRS.Fields("DeviseMonétaire").Value = "CAN" Then
265: optCAN.Checked = True
270: Else
275: If rstItemFRS.Fields("DeviseMonétaire").Value = "USA" Then
280: optUSA.Checked = True
285: Else
290: optSpain.Checked = True
295: End If
300: End If
		
		'Affiche Drapeau
305: Call AfficherDrapeau()
		
310: Call rstItemFRS.Close()
315: 'UPGRADE_NOTE: Object rstItemFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstItemFRS = Nothing
		
320: Exit Sub
		
AfficherErreur: 
		
325: Call AfficherErreur("frmCatalogueElec", "AfficherFRS", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbNoItem.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbNoItem_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbNoItem.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		'Affichage de l'enregistrement
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'Il faut mettre le nom de l'élément sélectionné dans le textbox pour ensuite
		'l'utiliser pour les requêtes SQL
15: txtNoItem.Text = cmbNoItem.Text
		
20: m_sNoItem = txtNoItem.Text
		
25: m_bBloqueDescription = True
		
30: Call AfficherItem()
		
35: m_bBloqueDescription = False
		
		'Remplir combo frs
40: Call RemplirComboFRS()
		
45: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmCatalogueElec", "cmbNoItem_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbFabricant.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbFabricant_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbFabricant.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		'quand un manufact est selectionné on remplir le combo des NumItem
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: txtFabricant.Text = cmbFabricant.Text
		
20: Call RemplirComboDescription()
		
25: m_bBloqueDescription = True
		
30: If m_bRempliManuel = True Then
			
35: Call RemplirComboNoItem()
			
40: m_bRempliManuel = False
45: Else
			
50: Call RemplirComboNoItem()
55: End If
		
60: m_bBloqueDescription = False
		
65: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		If sChoisirTous = ")" Then
			Call RemplirComboCategorie()
		End If
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmCatalogueElec", "cmbFabricant_Click", Err, Erl())
	End Sub
	
	Private Sub cmdSuppFrs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSuppFrs.Click
		
5: On Error GoTo AfficherErreur
		
10: If lvwfournisseur.Items.Count > 0 Then
15: Call SupprimerFournisseur()
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCatalogueElec", "cmdSuppFrs_Click", Err, Erl())
	End Sub
	
	Private Sub FrmCatalogueElec_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Call frmChoixCatalogue.Close()
		
15: Call ActiverBoutonsGroupe()
		
20: m_bBloqueDescription = True
		
25: m_collPieceDescFR = New Collection
		
		'Barrer les champs
30: Call BarrerChamps_piece(True)
		
		'Activer ou désactiver certains controles
35: Call MontrerControles(enumModeCatalogueElec.MODE_INACTIF)
		
40: Call RemplirComboLocalisation()
		
		'Rempli le combo des pièces disponibles
45: Call RemplirComboCategorie()
		
50: m_bBloqueDescription = False
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmCatalogueElec", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub ActiverBoutonsGroupe()
		
5: On Error GoTo AfficherErreur
		
10: CmdAdd.Enabled = g_bModificationCatalogueElec
15: CmdSupp.Enabled = g_bModificationCatalogueElec
20: CmdModif.Enabled = g_bModificationCatalogueElec
25: cmdAddFrs.Enabled = g_bModificationCatalogueElec
30: cmdSuppFrs.Enabled = g_bModificationCatalogueElec
35: cmdModifFrs.Enabled = g_bModificationCatalogueElec
40: cmdDemande.Enabled = g_bModificationCatalogueElec
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmCatalogueElec", "ActiverBoutonsGroupe", Err, Erl())
	End Sub
	
	Public Sub RemplirComboFabricant()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des fabricants
10: Dim rstFabricant As ADODB.Recordset
15: Dim sCategorie As String
20: Dim iCompteur As Short
		
25: sCategorie = Replace(cmbCategorie.Text, "'", "''")
		
30: rstFabricant = New ADODB.Recordset
		
35: Call rstFabricant.Open("SELECT DISTINCT FABRICANT FROM GRB_CatalogueElec WHERE CATEGORIE = '" & sCategorie & "' ORDER BY FABRICANT", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Il faut vider le combo avant de le remplir
40: Call cmbFabricant.Items.Clear()
41: sChoisirTous = ""
43: 'on ajoute la possibilité de choisir tout les fabricants
44: Call cmbFabricant.Items.Add("-- CHOISIR TOUS --")
		If Not rstFabricant.EOF Then
			rstFabricant.MoveFirst()
		End If
		'Tant que ce n'est pas la fin des enregistrements
		
46: Do While Not rstFabricant.EOF
			'Si l'élément n'est pas null
			
50: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstFabricant.Fields("Fabricant").Value) Then
				
				'on l'ajoute
55: Call cmbFabricant.Items.Add(Trim(rstFabricant.Fields("FABRICANT").Value))
				If sChoisirTous = "" Then
					sChoisirTous = " AND (FABRICANT = '" & Trim(rstFabricant.Fields("FABRICANT").Value) & "'"
				Else
56: sChoisirTous = sChoisirTous & " OR FABRICANT = '" & Trim(rstFabricant.Fields("FABRICANT").Value) & "'"
				End If
60: End If
			
65: Call rstFabricant.MoveNext()
			
70: Loop 
		
		sChoisirTous = sChoisirTous & ")"
		
75: Call rstFabricant.Close()
80: 'UPGRADE_NOTE: Object rstFabricant may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFabricant = Nothing
		
		'Si le combo n'est pas vide, on sélectionne le premier élément
85: If cmbFabricant.Items.Count > 0 Then
			
90: If m_sSelectFabricant <> vbNullString Then
95: For iCompteur = 0 To cmbFabricant.Items.Count - 1
					
100: If UCase(VB6.GetItemString(cmbFabricant, iCompteur)) = UCase(m_sSelectFabricant) Then
105: cmbFabricant.SelectedIndex = iCompteur
						
110: m_sSelectFabricant = ""
						
115: Exit For
120: End If
125: Next 
				
130: Else
				
135: cmbFabricant.SelectedIndex = 0
				
140: End If
145: Else
			
150: Call cmbNoItem.Items.Clear()
155: Call cmbDescriptionFR.Items.Clear()
160: End If
		
165: Exit Sub
		
AfficherErreur: 
		
170: Call AfficherErreur("frmCatalogueElec", "RemplirComboFabricant", Err, Erl())
	End Sub
	
	Public Sub AfficherForm(ByVal sCategorie As String, ByVal sNomFab As String, ByVal sNoItem As String)
		
5: On Error GoTo AfficherErreur
		
		
10: Dim iCompteur As Short
		'Ouverture de la fenêtre
		
		'Barrer les champs
15: Call BarrerChamps_piece(True)
		
		'Activer ou désactiver certains controles
20: Call MontrerControles(enumModeCatalogueElec.MODE_INACTIF)
		
		'Remplir le combo des pièces disponibles
25: Call RemplirComboCategorie()
		
30: If sCategorie <> "" Then
35: For iCompteur = 0 To cmbCategorie.Items.Count - 1
40: If VB6.GetItemString(cmbCategorie, iCompteur) = sCategorie Then
45: cmbCategorie.SelectedIndex = iCompteur
					
50: Exit For
55: End If
60: Next 
65: End If
		
70: If sNomFab <> "" Then
75: For iCompteur = 0 To cmbFabricant.Items.Count - 1
80: If VB6.GetItemString(cmbFabricant, iCompteur) = sNomFab Then
85: cmbFabricant.SelectedIndex = iCompteur
					
90: Exit For
95: End If
100: Next 
105: End If
		
110: If sNoItem <> "" Then
115: For iCompteur = 0 To cmbNoItem.Items.Count - 1
120: If VB6.GetItemString(cmbNoItem, iCompteur) = sNoItem Then
125: cmbNoItem.SelectedIndex = iCompteur
					
130: Exit For
135: End If
140: Next 
145: End If
		
150: Call Me.Show()
		
155: Exit Sub
		
AfficherErreur: 
		
160: Call AfficherErreur("frmCatalogueElec", "AfficherForm", Err, Erl())
	End Sub
	
	Public Sub RemplirComboNoItem()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo de numéros d'item
10: Dim rstNoItem As ADODB.Recordset
15: Dim sCategorie As String
20: Dim iCompteur As Short
25: Dim sFabricant As String
		
30: sCategorie = Replace(cmbCategorie.Text, "'", "''")
35: sFabricant = Replace(cmbFabricant.Text, "'", "''")
		
40: rstNoItem = New ADODB.Recordset
		If cmbCategorie.Text = "DIVERS" Or sChoisirTous = ")" Then
			Call rstNoItem.Open("SELECT PIECE FROM GRB_CatalogueElec WHERE CATEGORIE = '" & sCategorie & "' ORDER BY TRIM(PIECE)", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
41: Else
			If sFabricant = "-- CHOISIR TOUS --" Then
42: Call rstNoItem.Open("SELECT PIECE FROM GRB_CatalogueElec WHERE CATEGORIE = '" & sCategorie & "'" & sChoisirTous & " ORDER BY TRIM(PIECE)", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
43: Else
44: Call rstNoItem.Open("SELECT PIECE FROM GRB_CatalogueElec WHERE CATEGORIE = '" & sCategorie & "' AND FABRICANT = '" & sFabricant & "' ORDER BY TRIM(PIECE)", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
45: End If
		End If
		'Il faut vider le combo avant de le remplir
50: Call cmbNoItem.Items.Clear()
		
		'Tant que c'est n'est pas la fin des enregistrements
55: Do While Not rstNoItem.EOF
			'Si le champs n'est pas vide
60: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstNoItem.Fields("PIECE").Value) Then
				'On l'ajoute
65: Call cmbNoItem.Items.Add(Trim(rstNoItem.Fields("PIECE").Value))
70: End If
			
75: Call rstNoItem.MoveNext()
80: Loop 
		
85: Call rstNoItem.Close()
90: 'UPGRADE_NOTE: Object rstNoItem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstNoItem = Nothing
		
		'Si le combo n'est pas vide, on sélectionne le premier élément
95: If cmbNoItem.Items.Count > 0 Then
100: If m_sSelectNoItem <> vbNullString Then
105: For iCompteur = 0 To cmbNoItem.Items.Count - 1
110: If VB6.GetItemString(cmbNoItem, iCompteur) = m_sSelectNoItem Then
115: cmbNoItem.SelectedIndex = iCompteur
						
120: m_sSelectNoItem = ""
						
125: Exit For
130: End If
135: Next 
140: Else
				
145: cmbNoItem.SelectedIndex = 0
150: End If
155: End If
		
160: Exit Sub
		
AfficherErreur: 
		
165: Call AfficherErreur("frmCatalogueElec", "RemplirComboNoItem", Err, Erl())
	End Sub
	
	Private Sub CalculerPrixReel(ByVal sNoItem As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPieceFRS As ADODB.Recordset
15: Dim rstConfig As ADODB.Recordset
20: Dim sPrixCalcul As String
25: Dim sTauxUSA As String
30: Dim sTauxSPA As String
		
35: rstConfig = New ADODB.Recordset
		
40: Call rstConfig.Open("SELECT TauxAmericain, TauxEspagnol FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
45: sTauxUSA = rstConfig.Fields("TauxAmericain").Value
50: sTauxSPA = rstConfig.Fields("TauxEspagnol").Value
		
55: Call rstConfig.Close()
60: 'UPGRADE_NOTE: Object rstConfig may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstConfig = Nothing
		
65: rstPieceFRS = New ADODB.Recordset
		
70: rstPieceFRS.CursorLocation = ADODB.CursorLocationEnum.adUseServer
		
75: Call rstPieceFRS.Open("SELECT PrixReel, PRIX_NET, PRIX_SP, DeviseMonétaire FROM GRB_PiecesFRS WHERE PIECE = '" & Replace(sNoItem, "'", "''") & "' AND Type = 'E'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
80: Do While Not rstPieceFRS.EOF
85: If rstPieceFRS.Fields("PRIX_NET").Value <> vbNullString Then
90: sPrixCalcul = Replace(rstPieceFRS.Fields("PRIX_NET").Value, ".", ",")
95: Else
100: If rstPieceFRS.Fields("PRIX_SP").Value <> vbNullString Then
105: sPrixCalcul = Replace(rstPieceFRS.Fields("PRIX_SP").Value, ".", ",")
110: End If
115: End If
			
120: If rstPieceFRS.Fields("DeviseMonétaire").Value = "USA" Then
125: rstPieceFRS.Fields("PrixReel").Value = Conversion_Renamed(CStr(System.Math.Round(CDbl(sPrixCalcul) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_DECIMAL, 4)
130: Else
135: If rstPieceFRS.Fields("DeviseMonétaire").Value = "SPA" Then
140: rstPieceFRS.Fields("PrixReel").Value = Conversion_Renamed(CStr(System.Math.Round(CDbl(sPrixCalcul) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_DECIMAL, 4)
145: Else
150: rstPieceFRS.Fields("PrixReel").Value = Conversion_Renamed(sPrixCalcul, ModuleMain.enumConvert.MODE_DECIMAL, 4)
155: End If
160: End If
			
165: Call rstPieceFRS.Update()
			
170: Call rstPieceFRS.MoveNext()
175: Loop 
		
180: Call rstPieceFRS.Close()
185: 'UPGRADE_NOTE: Object rstPieceFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPieceFRS = Nothing
		
190: Exit Sub
		
AfficherErreur: 
		
195: Call AfficherErreur("frmCatalogueElec", "CalculerPrixReel", Err, Erl())
	End Sub
	
	Public Sub RemplirListViewFournisseur()
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''
		' remplis lister fournisseur '
		''''''''''''''''''''''''''''''
10: Dim rstPieceFRS As ADODB.Recordset
15: Dim rstContact As ADODB.Recordset
20: Dim iCompteur As Short
25: Dim itmFRS As System.Windows.Forms.ListViewItem
30: Dim lCouleur As Integer
		
		'vide le lister
35: Call lvwfournisseur.Items.Clear()
		
40: Call CalculerPrixReel(txtNoItem.Text)
		
45: rstPieceFRS = New ADODB.Recordset
		
50: Call rstPieceFRS.Open("SELECT GRB_PiecesFRS.*, GRB_Fournisseur.NomFournisseur FROM GRB_PiecesFRS INNER JOIN GRB_Fournisseur ON GRB_PiecesFRS.IDFRS = GRB_Fournisseur.IDFRS WHERE GRB_PiecesFRS.PIECE = '" & Replace(txtNoItem.Text, "'", "''") & "' AND Type = 'E' ORDER BY PrixReel", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
55: rstContact = New ADODB.Recordset
		
		'tant il y a des fournisseur de la piece , ajoute dans lister
		
60: Do While Not rstPieceFRS.EOF
65: If rstPieceFRS.Fields("DeviseMonétaire").Value = "CAN" Then
70: lCouleur = COLOR_ROUGE
				
75: Else
80: lCouleur = COLOR_BLEU
				
85: End If
			
90: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwfournisseur.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmFRS = lvwfournisseur.Items.Add()
			
95: itmFRS.Text = rstPieceFRS.Fields("NomFournisseur").Value
100: itmFRS.ForeColor = System.Drawing.ColorTranslator.FromOle(lCouleur)
			
105: itmFRS.Tag = rstPieceFRS.Fields("NoEnreg").Value
			
110: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieceFRS.Fields("PERS_RESS").Value) Then
115: If Trim(rstPieceFRS.Fields("PERS_RESS").Value) <> vbNullString Then
120: Call rstContact.Open("SELECT NomContact FROM GRB_Contact WHERE IDContact = " & rstPieceFRS.Fields("PERS_RESS").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
					If Not rstContact.EOF Then
125: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmFRS.SubItems.Count > I_COL_FRS_PERS_RESS Then
							itmFRS.SubItems(I_COL_FRS_PERS_RESS).Text = rstContact.Fields("NomContact").Value
						Else
							itmFRS.SubItems.Insert(I_COL_FRS_PERS_RESS, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstContact.Fields("NomContact").Value))
						End If
130: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						itmFRS.SubItems.Item(I_COL_FRS_PERS_RESS).ForeColor = System.Drawing.ColorTranslator.FromOle(lCouleur)
					End If
					
135: Call rstContact.Close()
140: End If
145: End If
			
150: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieceFRS.Fields("Date").Value) Then
				
155: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_DATE Then
					itmFRS.SubItems(I_COL_FRS_DATE).Text = rstPieceFRS.Fields("Date").Value
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_DATE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieceFRS.Fields("Date").Value))
				End If
160: Else
				
165: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_DATE Then
					itmFRS.SubItems(I_COL_FRS_DATE).Text = vbNullString
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_DATE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
170: End If
			
175: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmFRS.SubItems.Item(I_COL_FRS_DATE).ForeColor = System.Drawing.ColorTranslator.FromOle(lCouleur)
			
180: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieceFRS.Fields("ENTRER_PAR").Value) Then
185: 
				'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_ENTRER_PAR Then
					itmFRS.SubItems(I_COL_FRS_ENTRER_PAR).Text = rstPieceFRS.Fields("ENTRER_PAR").Value
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_ENTRER_PAR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieceFRS.Fields("ENTRER_PAR").Value))
				End If
190: Else
				
195: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_ENTRER_PAR Then
					itmFRS.SubItems(I_COL_FRS_ENTRER_PAR).Text = vbNullString
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_ENTRER_PAR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
200: End If
			
205: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmFRS.SubItems.Item(I_COL_FRS_ENTRER_PAR).ForeColor = System.Drawing.ColorTranslator.FromOle(lCouleur)
			
210: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieceFRS.Fields("Valide").Value) Then
				
215: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_VALIDE Then
					itmFRS.SubItems(I_COL_FRS_VALIDE).Text = rstPieceFRS.Fields("Valide").Value
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_VALIDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieceFRS.Fields("Valide").Value))
				End If
220: Else
				
225: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_VALIDE Then
					itmFRS.SubItems(I_COL_FRS_VALIDE).Text = vbNullString
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_VALIDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
230: End If
			
235: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmFRS.SubItems.Item(I_COL_FRS_VALIDE).ForeColor = System.Drawing.ColorTranslator.FromOle(lCouleur)
			
240: If rstPieceFRS.Fields("PRIX_LIST").Value <> vbNullString Then
245: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_PRIX_LIST Then
					itmFRS.SubItems(I_COL_FRS_PRIX_LIST).Text = Conversion_Renamed(System.Math.Round(CDbl(Replace(rstPieceFRS.Fields("PRIX_LIST").Value, ".", ",")), 4), ModuleMain.enumConvert.MODE_ARGENT, 4)
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(System.Math.Round(CDbl(Replace(rstPieceFRS.Fields("PRIX_LIST").Value, ".", ",")), 4), ModuleMain.enumConvert.MODE_ARGENT, 4)))
				End If
				
250: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmFRS.SubItems.Item(I_COL_FRS_PRIX_LIST).ForeColor = System.Drawing.ColorTranslator.FromOle(lCouleur)
255: End If
			
260: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieceFRS.Fields("ESCOMPTE").Value) Then
265: If Trim(rstPieceFRS.Fields("ESCOMPTE").Value) <> vbNullString Then
					'Enlève les "_", met un format pourcentage et remplace les "." par des ","
270: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmFRS.SubItems.Count > I_COL_FRS_ESCOMPTE Then
						itmFRS.SubItems(I_COL_FRS_ESCOMPTE).Text = Conversion_Renamed(Replace(Replace(rstPieceFRS.Fields("ESCOMPTE").Value, "_", vbNullString), ".", ","), ModuleMain.enumConvert.MODE_POURCENT)
					Else
						itmFRS.SubItems.Insert(I_COL_FRS_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(Replace(Replace(rstPieceFRS.Fields("ESCOMPTE").Value, "_", vbNullString), ".", ","), ModuleMain.enumConvert.MODE_POURCENT)))
					End If
275: Else
280: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmFRS.SubItems.Count > I_COL_FRS_ESCOMPTE Then
						itmFRS.SubItems(I_COL_FRS_ESCOMPTE).Text = vbNullString
					Else
						itmFRS.SubItems.Insert(I_COL_FRS_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
285: End If
290: Else
295: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_ESCOMPTE Then
					itmFRS.SubItems(I_COL_FRS_ESCOMPTE).Text = vbNullString
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
300: End If
			
305: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmFRS.SubItems.Item(I_COL_FRS_ESCOMPTE).ForeColor = System.Drawing.ColorTranslator.FromOle(lCouleur)
			
310: If rstPieceFRS.Fields("PRIX_NET").Value <> vbNullString Then
315: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_PRIX_NET Then
					itmFRS.SubItems(I_COL_FRS_PRIX_NET).Text = Conversion_Renamed(System.Math.Round(CDbl(Replace(rstPieceFRS.Fields("PRIX_NET").Value, ".", ",")), 4), ModuleMain.enumConvert.MODE_ARGENT, 4)
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(System.Math.Round(CDbl(Replace(rstPieceFRS.Fields("PRIX_NET").Value, ".", ",")), 4), ModuleMain.enumConvert.MODE_ARGENT, 4)))
				End If
320: Else
325: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_PRIX_NET Then
					itmFRS.SubItems(I_COL_FRS_PRIX_NET).Text = vbNullString
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
330: End If
			
335: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmFRS.SubItems.Item(I_COL_FRS_PRIX_NET).ForeColor = System.Drawing.ColorTranslator.FromOle(lCouleur)
			
340: If rstPieceFRS.Fields("PRIX_SP").Value <> vbNullString Then
345: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_PRIX_SP Then
					itmFRS.SubItems(I_COL_FRS_PRIX_SP).Text = Conversion_Renamed(System.Math.Round(rstPieceFRS.Fields("PRIX_SP").Value, 4), ModuleMain.enumConvert.MODE_ARGENT, 4)
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_PRIX_SP, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(System.Math.Round(rstPieceFRS.Fields("PRIX_SP").Value, 4), ModuleMain.enumConvert.MODE_ARGENT, 4)))
				End If
350: Else
355: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_PRIX_SP Then
					itmFRS.SubItems(I_COL_FRS_PRIX_SP).Text = vbNullString
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_PRIX_SP, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
360: End If
			
365: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmFRS.SubItems.Item(I_COL_FRS_PRIX_SP).ForeColor = System.Drawing.ColorTranslator.FromOle(lCouleur)
			
370: If rstPieceFRS.Fields("QUOTER").Value = True Then
375: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_QUOTER Then
					itmFRS.SubItems(I_COL_FRS_QUOTER).Text = "Oui"
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_QUOTER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Oui"))
				End If
380: Else
385: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_QUOTER Then
					itmFRS.SubItems(I_COL_FRS_QUOTER).Text = "Non"
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_QUOTER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Non"))
				End If
390: End If
			
395: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmFRS.SubItems.Item(I_COL_FRS_QUOTER).ForeColor = System.Drawing.ColorTranslator.FromOle(lCouleur)
			
400: Call rstPieceFRS.MoveNext()
405: Loop 
		
		'Ferme la table
410: Call rstPieceFRS.Close()
415: 'UPGRADE_NOTE: Object rstPieceFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPieceFRS = Nothing
		
420: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
425: Exit Sub
		
AfficherErreur: 
		
430: Call AfficherErreur("frmCatalogueElec", "RemplirListViewFournisseur", Err, Erl())
	End Sub
	
	Private Sub lvwDescription_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwDescription.Leave
		
5: On Error GoTo AfficherErreur
		
10: If lvwDescription.Visible = True Then
15: lvwDescription.Visible = False
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCatalogueElec", "lvwDescription_LostFocus", Err, Erl())
	End Sub
	
	Private Sub lvwRechercheJob_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwRechercheJob.Leave
		
5: On Error GoTo AfficherErreur
		
10: If lvwRechercheJob.Visible = True Then
15: lvwRechercheJob.Visible = False
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCatalogueElec", "lvwRechercheJob_LostFocus", Err, Erl())
	End Sub
	
	Private Sub lvwRechercheAchat_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwRechercheAchat.Leave
		
5: On Error GoTo AfficherErreur
		
10: If lvwRechercheAchat.Visible = True Then
15: lvwRechercheAchat.Visible = False
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCatalogueElec", "lvwRechercheAchat_LostFocus", Err, Erl())
	End Sub
	
	Private Sub lvwFournisseur_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwFournisseur.DoubleClick
		
5: On Error GoTo AfficherErreur
		
		'modifie un fournisseur pour la piece
10: If lvwfournisseur.Items.Count > 0 Then
15: Call ModifierFournisseur()
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCatalogueElec", "lvwFournisseur_DblClick", Err, Erl())
	End Sub
	
	Private Sub lvwfournisseur_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lvwfournisseur.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: If lvwfournisseur.Items.Count > 0 Then
15: If KeyCode = System.Windows.Forms.Keys.Delete Then
20: Call SupprimerFournisseur()
25: End If
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmCatalogueElec", "lvwfournisseur_KeyDown", Err, Erl())
	End Sub
	
	Private Sub ModifierFournisseur()
		
5: On Error GoTo AfficherErreur
		
10: Call BarrerChamps_piece(True)
		
		'affiche pour entre des valeurs
15: Call MontrerControles(enumModeCatalogueElec.MODE_AJOUT_MODIF_FRS)
		
20: m_bAjout = False
		
		'affiche les données frs selectionné
25: Call AfficherFRS()
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmCatalogueElec", "ModifierFournisseur", Err, Erl())
	End Sub
	
	Private Sub SupprimerFournisseur()
		
5: On Error GoTo AfficherErreur
		
10: If MsgBox("Voulez-vous vraiment effacer le fournisseur " & lvwfournisseur.FocusedItem.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
			'fonction qui supprime l'enregistrer courant
15: Call g_connData.Execute("DELETE * FROM GRB_PiecesFRS WHERE NoEnreg = " & lvwfournisseur.FocusedItem.Tag)
			
			'remplir le lister des fournisseurs
20: Call RemplirListViewFournisseur()
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmCatalogueElec", "SupprimerFournisseur", Err, Erl())
	End Sub
	
	Private Sub lvwPieces_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwPieces.Leave
		
5: On Error GoTo AfficherErreur
		
10: If lvwPieces.Visible = True Then
15: lvwPieces.Visible = False
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCatalogueElec", "lvwPieces_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskEscompte_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskEscompte.Enter
		
5: On Error GoTo AfficherErreur
		
		'Quand le maskEdit prend le focus, on set le masque
10: If mskEscompte.Enabled = True Then
15: mskEscompte.Mask = "0,####"
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCatalogueElec", "mskEscompte_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskEscompte_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskEscompte.Leave
		
5: On Error GoTo AfficherErreur
		
		'Quand le maskEdit perd le focus, on enlève le mask
10: mskEscompte.Mask = vbNullString
		
		'Si le champs contient 0,____, c'est parce que rien n'a été entré
15: If mskEscompte.Text = "0,____" Then
			'Donc, on le vide
20: mskEscompte.Text = vbNullString
25: End If
		
30: Call CalculerPrixNet()
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmCatalogueElec", "mskEscompte_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event optCAN.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optCAN_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optCAN.CheckedChanged
		If eventSender.Checked Then
			
5: On Error GoTo AfficherErreur
			
			'dependant la devise, affiche le drapeau
10: Call AfficherDrapeau()
			
15: Exit Sub
			
AfficherErreur: 
			
30: Call AfficherErreur("frmCatalogueElec", "optCAN_Click", Err, Erl())
		End If
	End Sub
	
	Private Sub AfficherDrapeau()
		
5: On Error GoTo AfficherErreur
		
		'dependant la devise, affiche le drapeau
10: If optCAN.Checked = True Then
15: imgCanada.Visible = True
20: imgEU.Visible = False
25: imgSpain.Visible = False
			
			
30: lblDevise1.Visible = False
35: txtTauxChange.Visible = False
40: lblDevise2.Visible = False
45: Else
50: If optUSA.Checked = True Then
55: imgEU.Visible = True
60: imgCanada.Visible = False
65: imgSpain.Visible = False
70: Else
75: imgSpain.Visible = True
80: imgCanada.Visible = False
85: imgEU.Visible = False
90: End If
			
95: Call AfficherTauxChange()
100: End If
		
105: Exit Sub
		
AfficherErreur: 
		
110: Call AfficherErreur("frmCatalogueElec", "AfficherDrapeau", Err, Erl())
	End Sub
	
	Private Sub AfficherTauxChange()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstConfig As ADODB.Recordset
		
15: rstConfig = New ADODB.Recordset
		
20: Call rstConfig.Open("SELECT TauxAmericain, TauxEspagnol FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: If optUSA.Checked = True Then
30: lblDevise2.Text = "$ USA"
35: txtTauxChange.Text = rstConfig.Fields("TauxAmericain").Value
40: Else
45: lblDevise2.Text = "$ SPA"
50: txtTauxChange.Text = rstConfig.Fields("TauxEspagnol").Value
55: End If
		
60: lblDevise1.Visible = True
65: txtTauxChange.Visible = True
70: lblDevise2.Visible = True
		
75: Call rstConfig.Close()
80: 'UPGRADE_NOTE: Object rstConfig may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstConfig = Nothing
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("frmCatalogueElec", "AfficherTauxChange", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event optSpain.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optSpain_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optSpain.CheckedChanged
		If eventSender.Checked Then
			
5: On Error GoTo AfficherErreur
			
			'dependant la devise, affiche le drapeau
10: Call AfficherDrapeau()
			
15: Exit Sub
			
AfficherErreur: 
			
20: Call AfficherErreur("frmCatalogueElec", "optSpain_Click", Err, Erl())
		End If
	End Sub
	
	'UPGRADE_WARNING: Event optUSA.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optUSA_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optUSA.CheckedChanged
		If eventSender.Checked Then
			
5: On Error GoTo AfficherErreur
			
			'dependant la devise, affiche le drapeau
10: Call AfficherDrapeau()
			
15: Exit Sub
			
AfficherErreur: 
			
20: Call AfficherErreur("frmCatalogueElec", "optUSA_Click", Err, Erl())
		End If
	End Sub
	
	'UPGRADE_WARNING: Event txtNoItem.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtNoItem_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtNoItem.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If m_eMode = enumModeCatalogueElec.MODE_AJOUT_MODIF_ELEC Then
15: If Len(txtNoItem.Text) > 18 Then
20: txtNoItemGRB.Text = VB.Left(txtNoItem.Text, 18) & "GRB"
25: Else
30: txtNoItemGRB.Text = txtNoItem.Text & "GRB"
35: End If
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmCatalogueElec", "txtNoItem_Change", Err, Erl())
	End Sub
	
	Private Sub txtPrixList_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrixList.Leave
		
5: On Error GoTo AfficherErreur
		
10: If txtPrixList.Text <> vbNullString Then
15: txtPrixList.Text = Replace(txtPrixList.Text, ".", ",")
			
20: If Not IsNumeric(txtPrixList.Text) Then
25: Call MsgBox("Valeur non numérique!", MsgBoxStyle.OKOnly, "Erreur")
30: txtPrixList.Text = vbNullString
35: End If
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmCatalogueElec", "txtPrixList_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtPrixNet.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtPrixNet_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrixNet.TextChanged
		
5: On Error GoTo AfficherErreur
		
		'Quand le contenu du prix net change
		
		'Si la longueur du texte écrit est plus grand que 0
10: If Len(txtPrixNet.Text) > 0 Then
			'On vide le prix spécial et on le désactive
15: txtPrixSpecial.Text = vbNullString
20: txtPrixSpecial.Enabled = False
25: Else
			'Sinon, on active le prix spécial
30: txtPrixSpecial.Enabled = True
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmCatalogueElec", "txtPrixNet_Change", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtPrixSpecial.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtPrixSpecial_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrixSpecial.TextChanged
		
5: On Error GoTo AfficherErreur
		'Quand le contenu du prix spécial change
		
		'Si la longueur du texte écrit est plus grand que 0
10: If Len(txtPrixSpecial.Text) > 0 Then
			'On vide l'escompte, le prix net et on les désactive
15: mskEscompte.Text = vbNullString
20: txtPrixNet.Text = vbNullString
			
25: mskEscompte.Enabled = False
30: txtPrixNet.Enabled = False
35: Else
			'Sinon, on active escompte et prix net
40: mskEscompte.Enabled = True
45: txtPrixNet.Enabled = True
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmCatalogueElec", "txtPrixSpecial_Change", Err, Erl())
	End Sub
	
	Private Sub txtPrixNet_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrixNet.Enter
		
5: On Error GoTo AfficherErreur
		
		'Si le prix net prend le focus
10: Call CalculerPrixNet()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmCatalogueElec", "txtPrixNet_GotFocus", Err, Erl())
	End Sub
	
	Private Sub CalculerPrixNet()
		
5: On Error GoTo AfficherErreur
		
10: Dim dblEscompte As Double
15: Dim dblPrix As Double
		
		'Si le prix net n'est pas barré.. ie.. si le prix spécial est vide
20: If txtPrixNet.ReadOnly = False Then
25: mskEscompte.Text = Replace(mskEscompte.Text, "_", vbNullString)
			
30: mskEscompte.Text = Replace(mskEscompte.Text, ".", ",")
			
35: If mskEscompte.Text <> vbNullString Then
40: dblEscompte = CDbl(mskEscompte.Text)
45: Else
50: dblEscompte = 0
55: End If
			
60: If txtPrixList.Text <> vbNullString Then
65: dblPrix = CDbl(Replace(txtPrixList.Text, ".", ","))
70: Else
75: dblPrix = 0
80: End If
			
			'Calcul du prix net
85: txtPrixNet.Text = CStr(System.Math.Round((dblPrix) * (1 - dblEscompte), 4))
			
90: txtPrixNet.Text = Replace(txtPrixNet.Text, ".", ",")
95: End If
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmCatalogueElec", "CalculerPrixNet", Err, Erl())
	End Sub
	
	Private Sub txtPrixNet_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrixNet.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtPrixNet.Text = Replace(txtPrixNet.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmCatalogueElec", "txtPrixNet_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskValide_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskValide.Enter
		
5: On Error GoTo AfficherErreur
		
		'Si la date est sous le format AAAA-MM-JJ
10: If Len(mskValide.Text) = 10 Then
			'On la met sous le format AA-MM-JJ
15: mskValide.Text = VB.Right(mskValide.Text, 8)
20: End If
		
		'On met le mask
25: mskValide.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmCatalogueElec", "mskValide_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskValide_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskValide.Leave
		
5: On Error GoTo AfficherErreur
		'On enlève le mask
10: mskValide.Mask = vbNullString
		
15: If mskValide.Text = "__-__-__" Then
20: mskValide.Text = vbNullString
25: Else
30: If Len(mskValide.Text) = 8 Then
35: If IsDate(mskValide.Text) Then
					'On la met sous le format AAAA-MM-JJ
40: mskValide.Text = Year(DateSerial(CInt(VB.Left(mskValide.Text, 2)), CInt(Mid(mskValide.Text, 4, 2)), CInt(VB.Right(mskValide.Text, 2)))) & Mid(mskValide.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmCatalogueElec", "mskValide_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbCategorie.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbCategorie_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbCategorie.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		'pour sélectionner la bonne catégorie de pieces
10: txtCategorie.Text = cmbCategorie.Text
		
15: m_bRempliManuel = True
		
20: m_bBloqueDescription = True
		
25: Call cmbFabricant.Items.Clear()
		
30: Call cmbNoItem.Items.Clear()
		
35: Call ViderChamps_piece()
		
40: Call RemplirComboFabricant()
		
45: m_bBloqueDescription = False
		
50: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmCatalogueElec", "cmbCategorie_Click", Err, Erl())
	End Sub
	
	Public Sub RemplirComboCategorie()
		
5: On Error GoTo AfficherErreur
		
		'Remplir le combo des tables (Pièces)
10: Dim rstCatalogueElec As ADODB.Recordset
15: Dim iCompteur As Short
		
		'Il faut vider le combo avant de le remplir
20: Call cmbCategorie.Items.Clear()
		
		'Cette méthode crée un recordset contenant les categorie
		'le nom de toutes les tables de la BD
25: rstCatalogueElec = New ADODB.Recordset
		
30: Call rstCatalogueElec.Open("SELECT DISTINCT CATEGORIE FROM GRB_CatalogueElec ORDER BY CATEGORIE", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
35: Do While Not rstCatalogueElec.EOF
40: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstCatalogueElec.Fields("CATEGORIE").Value) Then
45: Call cmbCategorie.Items.Add(Trim(rstCatalogueElec.Fields("CATEGORIE").Value))
50: End If
			
55: Call rstCatalogueElec.MoveNext()
60: Loop 
		
65: Call rstCatalogueElec.Close()
70: 'UPGRADE_NOTE: Object rstCatalogueElec may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstCatalogueElec = Nothing
		
		'Si le combo n'est pas vide, on sélectionne le premier
75: If cmbCategorie.Items.Count > 0 Then
80: If m_sSelectCategorie <> "" Then
85: For iCompteur = 0 To cmbCategorie.Items.Count - 1
90: If VB6.GetItemString(cmbCategorie, iCompteur) = m_sSelectCategorie Then
95: cmbCategorie.SelectedIndex = iCompteur
						
100: m_sSelectCategorie = ""
						
105: Exit For
110: End If
115: Next 
120: Else
125: cmbCategorie.SelectedIndex = 0
130: End If
135: End If
		
140: Exit Sub
		
AfficherErreur: 
		
145: Call AfficherErreur("frmCatalogueElec", "RemplirComboCategorie", Err, Erl())
	End Sub
	
	Private Sub RemplirComboFRS()
		
5: On Error GoTo AfficherErreur
		
		'Remplir le combo des tables (Pièces)
10: Dim rstPieceFRS As ADODB.Recordset
15: Dim sNomTable As String
		
		'Il faut vider le combo avant de le remplir
20: Call cmbfrs.Items.Clear()
		
		' ouvre la table piece frs
25: rstPieceFRS = New ADODB.Recordset
		
30: Call rstPieceFRS.Open("SELECT * FROM GRB_Fournisseur WHERE Supprimé = False ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
		
35: Do While Not rstPieceFRS.EOF
40: Call cmbfrs.Items.Add(rstPieceFRS.Fields("NomFournisseur").Value)
45: 'UPGRADE_ISSUE: ComboBox property cmbfrs.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbfrs, cmbfrs.NewIndex, rstPieceFRS.Fields("IDFRS").Value)
			
50: Call rstPieceFRS.MoveNext()
55: Loop 
		
60: Call rstPieceFRS.Close()
65: 'UPGRADE_NOTE: Object rstPieceFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPieceFRS = Nothing
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmCatalogueElec", "RemplirComboFRS", Err, Erl())
	End Sub
	
	Private Sub txtPrixSpecial_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrixSpecial.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtPrixSpecial.Text = Replace(txtPrixSpecial.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmCatalogueElec", "txtPrixSpecial_LostFocus", Err, Erl())
	End Sub
	
	Private Sub RemplirComboLocalisation()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo cmbLocalisation
10: Dim rstLocalisation As ADODB.Recordset
		
15: rstLocalisation = New ADODB.Recordset
		
20: Call rstLocalisation.Open("SELECT DISTINCT Localisation FROM GRB_InventaireElec", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Il faut vider le combo avant de le remplir
25: Call cmbLocalisation.Items.Clear()
		
		'Tant que ce n'est pas la fin des enregistrements
30: Do While Not rstLocalisation.EOF
			'Si l'enregistrement n'est pas Null
35: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstLocalisation.Fields("Localisation").Value) Then
40: If Trim(rstLocalisation.Fields("Localisation").Value) <> "" Then
					'On l'ajoute dans le combo
45: Call cmbLocalisation.Items.Add(rstLocalisation.Fields("Localisation").Value)
50: End If
55: End If
			
60: Call rstLocalisation.MoveNext()
65: Loop 
		
70: Call rstLocalisation.Close()
75: 'UPGRADE_NOTE: Object rstLocalisation may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstLocalisation = Nothing
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmCatalogueElec", "RemplirComboLocalisation", Err, Erl())
	End Sub
	
	Private Sub txtQuantitéBoite_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQuantitéBoite.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtQuantitéBoite.Text = Replace(txtQuantitéBoite.Text, ".", ",")
		
15: If Not IsNumeric(txtQuantitéBoite.Text) Or txtQuantitéBoite.Text = "0" Then
20: txtQuantitéBoite.Text = "1"
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmCatalogueElec", "txtQuantitéBoite_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtQuantiteCommande_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQuantiteCommande.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtQuantiteCommande.Text = Replace(txtQuantiteCommande.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmCatalogueElec", "txtQuantiteCommande_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtQuantiteMinimum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQuantiteMinimum.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtQuantiteMinimum.Text = Replace(txtQuantiteMinimum.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmCatalogueElec", "txtQuantiteMinimum_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtQuantiteStock_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQuantiteStock.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtQuantiteStock.Text = Replace(txtQuantiteStock.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmCatalogueElec", "txtQuantiteStock_LostFocus", Err, Erl())
	End Sub
End Class