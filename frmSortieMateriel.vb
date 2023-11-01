Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmSortieMateriel
	Inherits System.Windows.Forms.Form
	
	Private Const I_CMB_NO_ITEM As Short = 0
	Private Const I_CMB_DESCRIPTION As Short = 1
	Private Const I_CMB_MANUFACTURIER As Short = 2
	
	Private Const I_LVW_RECHERCHE_NO_ITEM As Short = 0
	Private Const I_LVW_RECHERCHE_DESCRIPTION As Short = 1
	Private Const I_LVW_RECHERCHE_MANUFACTURIER As Short = 2
	
	Private Enum enumExtra
		AUCUN_EXTRA = 0
		EXTRA_CHARGEABLE = 1
		EXTRA_NON_CHARGEABLE = 2
	End Enum
	
	Private m_eCatalogue As ModuleMain.enumCatalogue
	
	Private Sub cmdEnregistrer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEnregistrer.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstInv As ADODB.Recordset
15: Dim rstSortie As ADODB.Recordset
20: Dim rstProjet As ADODB.Recordset
25: Dim rstHistInv As ADODB.Recordset
30: Dim rstInitiale As ADODB.Recordset
		
35: If txtNoItem.Text <> "" Then
40: If IsNumeric(txtQte.Text) Then
45: If mskNoProjet.Text <> "_____-__" And mskNoProjet.Text <> "M_____-__" Then
50: If ProjetExiste = True Then
55: rstProjet = New ADODB.Recordset
						
60: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
65: Call rstProjet.Open("SELECT Modification, Par FROM GRB_ProjetElec WHERE IDProjet = '" & mskNoProjet.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
70: Else
75: Call rstProjet.Open("SELECT Modification, Par FROM GRB_ProjetMec WHERE IDProjet = '" & mskNoProjet.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
80: End If
						
85: If rstProjet.Fields("Modification").Value = False Then
90: rstInv = New ADODB.Recordset
							
95: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
100: Call rstInv.Open("SELECT * FROM GRB_InventaireElec WHERE NoItem = '" & Replace(txtNoItem.Text, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
105: Else
110: Call rstInv.Open("SELECT * FROM GRB_InventaireMec WHERE NoItem = '" & Replace(txtNoItem.Text, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
115: End If
							
120: If Not rstInv.EOF Then
125: rstSortie = New ADODB.Recordset
								
130: Call rstSortie.Open("SELECT * FROM GRB_SortieMatériel", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
								
135: Call rstSortie.AddNew()
								
140: rstSortie.Fields("Qté").Value = txtQte.Text
145: rstSortie.Fields("Nom").Value = cmbEmployé.Text
150: rstSortie.Fields("NoProjet").Value = mskNoProjet.Text
155: rstSortie.Fields("NoItem").Value = txtNoItem.Text
160: rstSortie.Fields("Date").Value = ConvertDate(Today)
								
165: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
170: rstSortie.Fields("Type").Value = "E"
175: Else
180: rstSortie.Fields("Type").Value = "M"
185: End If
								
190: Call rstSortie.Update()
								
195: Call rstSortie.Close()
200: 'UPGRADE_NOTE: Object rstSortie may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
								rstSortie = Nothing
								
205: rstInv.Fields("QuantitéStock").Value = CDbl(rstInv.Fields("QuantitéStock").Value) - CDbl(txtQte.Text)
								
210: Call rstInv.Update()
								
215: rstHistInv = New ADODB.Recordset
								
220: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
225: Call rstHistInv.Open("SELECT * FROM GRB_InventaireElecModif", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
230: Else
235: Call rstHistInv.Open("SELECT * FROM GRB_InventaireMecModif", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
240: End If
								
245: Call rstHistInv.AddNew()
								
250: rstHistInv.Fields("Date").Value = ConvertDate(Today)
255: rstHistInv.Fields("IDProjet").Value = mskNoProjet.Text
260: rstHistInv.Fields("NoItem").Value = txtNoItem.Text
265: rstHistInv.Fields("Quantité").Value = "-" & System.Math.Abs(CDbl(txtQte.Text))
								
270: rstInitiale = New ADODB.Recordset
								
275: Call rstInitiale.Open("SELECT * FROM GRB_Employés WHERE NoEmploye = " & VB6.GetItemData(cmbEmployé, cmbEmployé.SelectedIndex), g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
								
280: rstHistInv.Fields("User").Value = rstInitiale.Fields("Initiale").Value
								
285: Call rstInitiale.Close()
290: 'UPGRADE_NOTE: Object rstInitiale may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
								rstInitiale = Nothing
								
295: Call rstHistInv.Update()
								
300: Call rstHistInv.Close()
305: 'UPGRADE_NOTE: Object rstHistInv may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
								rstHistInv = Nothing
								
310: Call AjouterDansProjet(mskNoProjet.Text, enumExtra.AUCUN_EXTRA, "")
								
315: Call rstProjet.Close()
								
320: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
325: If CDbl(VB.Right(mskNoProjet.Text, 2)) >= 61 And CDbl(VB.Right(mskNoProjet.Text, 2)) <= 80 Then
330: Call rstProjet.Open("SELECT * FROM GRB_ProjetElec WHERE IDProjet = '" & mskNoProjet.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
										
335: Call AjouterDansProjet(VB.Left(mskNoProjet.Text, Len(mskNoProjet.Text) - 2) & rstProjet.Fields("LiaisonChargeable").Value, enumExtra.EXTRA_CHARGEABLE, VB.Right(mskNoProjet.Text, 2))
										
340: Call rstProjet.Close()
345: Else
350: If CDbl(VB.Right(mskNoProjet.Text, 2)) >= 81 And CDbl(VB.Right(mskNoProjet.Text, 2)) <= 98 Then
355: Call AjouterDansProjet(VB.Left(mskNoProjet.Text, Len(mskNoProjet.Text) - 2) & VB.Right("0" & CDbl(VB.Right(mskNoProjet.Text, 2)) - 80, 2), enumExtra.EXTRA_NON_CHARGEABLE, "")
360: End If
365: End If
370: Else
375: If CDbl(VB.Right(mskNoProjet.Text, 2)) >= 61 And CDbl(VB.Right(mskNoProjet.Text, 2)) <= 80 Then
380: Call rstProjet.Open("SELECT * FROM GRB_ProjetMec WHERE IDProjet = '" & mskNoProjet.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
										
385: Call AjouterDansProjet(VB.Left(mskNoProjet.Text, Len(mskNoProjet.Text) - 2) & rstProjet.Fields("LiaisonChargeable").Value, enumExtra.EXTRA_CHARGEABLE, VB.Right(mskNoProjet.Text, 2))
										
390: Call rstProjet.Close()
395: Else
400: If CDbl(VB.Right(mskNoProjet.Text, 2)) >= 81 And CDbl(VB.Right(mskNoProjet.Text, 2)) <= 98 Then
405: Call AjouterDansProjet(VB.Left(mskNoProjet.Text, Len(mskNoProjet.Text) - 2) & VB.Right("0" & CDbl(VB.Right(mskNoProjet.Text, 2)) - 80, 2), enumExtra.EXTRA_NON_CHARGEABLE, "")
410: End If
415: End If
420: End If
								
425: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
								rstProjet = Nothing
								
430: Call MsgBox("La sortie de matériel a été enregistrée!", MsgBoxStyle.OKOnly, "Erreur")
								
435: Call ViderChamps()
440: Else
445: Call MsgBox("Cette pièce n'existe pas dans l'inventaire!", MsgBoxStyle.OKOnly, "Erreur")
450: End If
							
455: Call rstInv.Close()
460: 'UPGRADE_NOTE: Object rstInv may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
							rstInv = Nothing
465: Else
470: Call MsgBox("Ce projet est en modification par " & rstProjet.Fields("Par").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
							
475: Call rstProjet.Close()
480: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
							rstProjet = Nothing
485: End If
490: Else
495: Call MsgBox("Projet inexistant!", MsgBoxStyle.OKOnly, "Erreur")
500: End If
505: Else
510: Call MsgBox("Le numéro de projet est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
515: End If
520: Else
525: Call MsgBox("Quantité non numérique!", MsgBoxStyle.OKOnly, "Erreur")
530: End If
535: Else
540: Call MsgBox("Le numéro d'item est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
545: End If
		
550: Exit Sub
		
AfficherErreur: 
		
555: Call AfficherErreur("frmSortieMateriel", "cmdEnregistrer_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmSortieMateriel", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub ViderChamps()
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: txtNoItem.Text = ""
20: txtQte.Text = ""
25: txtRecherche.Text = ""
30: cmbRecherche.SelectedIndex = 0
		
35: chkMecanique.CheckState = System.Windows.Forms.CheckState.Unchecked
		
40: mskNoProjet.Text = "_____-__"
		
45: For iCompteur = 0 To cmbEmployé.Items.Count - 1
50: If VB6.GetItemString(cmbEmployé, iCompteur) = g_sEmploye Then
55: cmbEmployé.SelectedIndex = iCompteur
				
60: Exit For
65: End If
70: Next 
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmSortieMateriel", "ViderChamps", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewRecherche()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstInv As ADODB.Recordset
15: Dim itmInv As System.Windows.Forms.ListViewItem
20: Dim sWhere As String
		
25: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
30: Call lvwRecherche.Items.Clear()
		
35: Select Case cmbRecherche.SelectedIndex
			Case I_CMB_NO_ITEM : sWhere = "Instr(1,NoItem,'" & txtRecherche.Text & "') > 0"
40: Case I_CMB_DESCRIPTION : sWhere = "Instr(1,Description,'" & txtRecherche.Text & "') > 0"
45: Case I_CMB_MANUFACTURIER : sWhere = "Instr(1,Manufacturier,'" & txtRecherche.Text & "') > 0"
50: End Select
		
55: rstInv = New ADODB.Recordset
		
60: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
65: Call rstInv.Open("SELECT * FROM GRB_InventaireElec WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
70: Else
75: Call rstInv.Open("SELECT * FROM GRB_InventaireMec WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
80: End If
		
85: Do While Not rstInv.EOF
90: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwRecherche.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmInv = lvwRecherche.Items.Add()
			
95: itmInv.Text = rstInv.Fields("NoItem").Value
100: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmInv.SubItems.Count > I_LVW_RECHERCHE_DESCRIPTION Then
				itmInv.SubItems(I_LVW_RECHERCHE_DESCRIPTION).Text = rstInv.Fields("Description").Value
			Else
				itmInv.SubItems.Insert(I_LVW_RECHERCHE_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstInv.Fields("Description").Value))
			End If
105: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmInv.SubItems.Count > I_LVW_RECHERCHE_MANUFACTURIER Then
				itmInv.SubItems(I_LVW_RECHERCHE_MANUFACTURIER).Text = rstInv.Fields("Manufacturier").Value
			Else
				itmInv.SubItems.Insert(I_LVW_RECHERCHE_MANUFACTURIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstInv.Fields("Manufacturier").Value))
			End If
			
110: Call rstInv.MoveNext()
115: Loop 
		
120: Call rstInv.Close()
125: 'UPGRADE_NOTE: Object rstInv may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstInv = Nothing
		
130: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
135: If lvwRecherche.Items.Count = 0 Then
140: Call MsgBox("Aucun enregistrement trouvé!", MsgBoxStyle.OKOnly, "Erreur")
145: End If
		
150: Exit Sub
		
AfficherErreur: 
		
155: Call AfficherErreur("frmSortieMateriel", "RemplirListViewRecherche", Err, Erl())
	End Sub
	
	Private Sub cmdRechercher_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercher.Click
		
5: On Error GoTo AfficherErreur
		
10: If txtRecherche.Text <> "" Then
15: Call RemplirListViewRecherche()
20: Else
25: Call MsgBox("Rien à rechercher!", MsgBoxStyle.OKOnly, "Erreur")
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmSortieMateriel", "cmdRechercher_Click", Err, Erl())
	End Sub
	
	Private Sub frmSortieMateriel_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Call RemplirComboEmployes()
		
15: Call ViderChamps()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmSortieMateriel", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub RemplirComboEmployes()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmploye As ADODB.Recordset
		
15: rstEmploye = New ADODB.Recordset
		
20: Call rstEmploye.Open("SELECT * FROM GRB_Employés WHERE Actif = True", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: Do While Not rstEmploye.EOF
30: Call cmbEmployé.Items.Add(rstEmploye.Fields("Employe").Value)
			
35: 'UPGRADE_ISSUE: ComboBox property cmbEmployé.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbEmployé, cmbEmployé.NewIndex, rstEmploye.Fields("NoEmploye").Value)
			
40: Call rstEmploye.MoveNext()
45: Loop 
		
50: Call rstEmploye.Close()
55: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmSortieMateriel", "RemplirComboEmployes", Err, Erl())
	End Sub
	
	Private Sub lvwRecherche_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwRecherche.DoubleClick
		
5: On Error GoTo AfficherErreur
		
10: If lvwRecherche.Items.Count > 0 Then
15: txtNoItem.Text = lvwRecherche.FocusedItem.Text
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmSortieMateriel", "lvwRecherche_DblClick", Err, Erl())
	End Sub
	
	Private Sub mskNoProjet_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskNoProjet.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If fraAjout.Visible = True Then
15: If InStr(1, mskNoProjet.Text, "_") = 0 Then
20: Call ProjetExiste()
25: End If
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmSortieMateriel", "mskNoProjet_Change", Err, Erl())
	End Sub
	
	Private Function ProjetExiste() As Boolean
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjSoum As ADODB.Recordset
15: Dim iCompteur As Short
		
20: If CDbl(VB.Right(mskNoProjet.Text, 2)) >= 51 And CDbl(VB.Right(mskNoProjet.Text, 2)) <= 98 Then
25: rstProjSoum = New ADODB.Recordset
			
30: Call rstProjSoum.Open("SELECT * FROM GRB_ProjSoum WHERE IDProjSoum = '" & mskNoProjet.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
35: If Not rstProjSoum.EOF Then
40: If rstProjSoum.Fields("Ouvert").Value = False Then
45: Call MsgBox("Ce projet n'est pas ouvert!", MsgBoxStyle.OKOnly, "Erreur")
					
50: ProjetExiste = False
55: Else
60: ProjetExiste = True
65: End If
70: Else
75: Call MsgBox("Projet inexistant!", MsgBoxStyle.OKOnly, "Erreur")
				
80: ProjetExiste = False
85: End If
			
90: Call rstProjSoum.Close()
95: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstProjSoum = Nothing
100: Else
105: Call MsgBox("Impossible de faire une sortie de matériel sur ce numéro!", MsgBoxStyle.OKOnly, "Erreur")
			
110: ProjetExiste = False
115: End If
		
120: Exit Function
		
AfficherErreur: 
		
125: Call AfficherErreur("frmSortieMateriel", "AfficherClient", Err, Erl())
	End Function
	
	'UPGRADE_WARNING: Event chkMecanique.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkMecanique_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkMecanique.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: Dim sTampon As String
		
15: sTampon = mskNoProjet.Text
		
		'dépendant si coché mécanique affiche le mask
20: If chkMecanique.CheckState = System.Windows.Forms.CheckState.Checked Then
25: mskNoProjet.Mask = "\M#####-##"
			'ajoute le M
30: If Len(sTampon) = 8 Then
35: mskNoProjet.Text = "M" & sTampon
40: End If
45: Else
			'enleve le m
50: mskNoProjet.Mask = "#####-##"
55: mskNoProjet.Text = VB.Right(sTampon, 9)
60: End If
		
65: If fraAjout.Visible = True Then
70: Call mskNoProjet.Focus()
75: End If
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmSortieMateriel", "chkMecanique_Click", Err, Erl())
	End Sub
	
	Public Sub Afficher(ByVal eCatalogue As ModuleMain.enumCatalogue)
		
5: On Error GoTo AfficherErreur
		
10: m_eCatalogue = eCatalogue
		
15: Call frmChoixSortieMateriel.Close()
		
20: Call Me.Show()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmSortieMateriel", "Afficher", Err, Erl())
	End Sub
	
	Private Sub AjouterDansProjet(ByVal sNoProjet As String, ByVal eExtra As enumExtra, ByVal sProvenance As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjet As ADODB.Recordset
15: Dim rstPiece As ADODB.Recordset
20: Dim rstSection As ADODB.Recordset
25: Dim rstInv As ADODB.Recordset
30: Dim iCompteur As Short
35: Dim sSection As String
40: Dim bSkip As Boolean
45: Dim sIDSection As String
50: Dim sOrdre As String
55: Dim sProfit As String
		
60: rstProjet = New ADODB.Recordset
65: rstSection = New ADODB.Recordset
		
70: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
75: Call rstSection.Open("SELECT * FROM GRB_SoumProjSectionElec WHERE NomSectionFR = 'Externe'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
80: Call rstProjet.Open("SELECT * FROM GRB_ProjetElec WHERE IDProjet = '" & sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
85: sProfit = rstProjet.Fields("Profit").Value
			
90: Call rstProjet.Close()
95: Else
100: Call rstSection.Open("SELECT * FROM GRB_SoumProjSectionMec WHERE NomSectionFR = 'Externe'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
105: Call rstProjet.Open("SELECT * FROM GRB_ProjetMec WHERE IDProjet = '" & sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockBatchOptimistic)
			
110: sProfit = rstProjet.Fields("Profit").Value
			
115: Call rstProjet.Close()
120: End If
		
125: sIDSection = rstSection.Fields("IDSection").Value
130: sOrdre = rstSection.Fields("Ordre").Value
		
135: Call rstSection.Close()
140: 'UPGRADE_NOTE: Object rstSection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstSection = Nothing
		
		'Ouverture du recordset sur le projet original
145: rstPiece = New ADODB.Recordset
		
150: Call rstPiece.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = '" & sNoProjet & "' AND IDSection = " & sIDSection & " AND SousSection = 'PAS DE SOUS-SECTION' ORDER BY NuméroLigne", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
155: If Not rstPiece.EOF Then
160: Call rstPiece.MoveLast()
			
165: iCompteur = rstPiece.Fields("NuméroLigne").Value + 1
170: Else
175: iCompteur = 1
180: End If
		
185: rstInv = New ADODB.Recordset
		
190: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
195: Call rstInv.Open("SELECT * FROM GRB_InventaireElec WHERE NoItem = '" & Replace(txtNoItem.Text, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
200: Else
205: Call rstInv.Open("SELECT * FROM GRB_InventaireMec WHERE NoItem = '" & Replace(txtNoItem.Text, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
210: End If
		
215: Call rstPiece.AddNew()
		
220: rstPiece.Fields("IDProjet").Value = sNoProjet
		
225: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
230: rstPiece.Fields("Type").Value = "E"
235: Else
240: rstPiece.Fields("Type").Value = "M"
245: End If
		
250: rstPiece.Fields("Visible").Value = True
		
255: rstPiece.Fields("Facturation").Value = ""
		
265: rstPiece.Fields("IDSection").Value = sIDSection
270: rstPiece.Fields("NumItem").Value = rstInv.Fields("NoItem").Value
275: rstPiece.Fields("Qté").Value = txtQte.Text
280: rstPiece.Fields("Desc_FR").Value = rstInv.Fields("Description").Value
285: rstPiece.Fields("Desc_EN").Value = ""
290: rstPiece.Fields("Manufact").Value = rstInv.Fields("Manufacturier").Value
295: rstPiece.Fields("Prix_list").Value = Conversion_Renamed(rstInv.Fields("Prix liste"), ModuleMain.enumConvert.MODE_PAS_FORMAT, 4)
300: rstPiece.Fields("Escompte").Value = Conversion_Renamed(rstInv.Fields("Escompte"), ModuleMain.enumConvert.MODE_PAS_FORMAT)
305: rstPiece.Fields("Prix_net").Value = Conversion_Renamed(rstInv.Fields("Prix net"), ModuleMain.enumConvert.MODE_PAS_FORMAT, 4)
310: rstPiece.Fields("OrdreSection").Value = sOrdre
315: rstPiece.Fields("NuméroLigne").Value = iCompteur
		
320: rstPiece.Fields("IDFRS").Value = 717
		
325: rstPiece.Fields("Prix_Total").Value = Conversion_Renamed(rstInv.Fields("Prix net").Value * CDbl(txtQte.Text) * CDbl(sProfit), ModuleMain.enumConvert.MODE_PAS_FORMAT)
330: rstPiece.Fields("Profit_argent").Value = Conversion_Renamed(rstPiece.Fields("Prix_Total").Value - (rstInv.Fields("Prix net").Value * CDbl(txtQte.Text)), ModuleMain.enumConvert.MODE_PAS_FORMAT)
335: rstPiece.Fields("SousSection").Value = "PAS DE SOUS-SECTION"
		
340: rstPiece.Fields("PrixOrigine").Value = Replace(CStr(System.Math.Round(CDbl(Replace(rstInv.Fields("Prix liste").Value, ".", ",")), 2)), ".", ",")
		
345: Select Case eExtra
			Case enumExtra.EXTRA_CHARGEABLE
350: rstPiece.Fields("PieceExtraChargeable").Value = True
355: rstPiece.Fields("PieceExtraNonChargeable").Value = False
				
360: Case enumExtra.EXTRA_NON_CHARGEABLE
365: rstPiece.Fields("PieceExtraChargeable").Value = False
370: rstPiece.Fields("PieceExtraNonChargeable").Value = True
				
375: Case enumExtra.AUCUN_EXTRA
380: rstPiece.Fields("PieceExtraChargeable").Value = False
385: rstPiece.Fields("PieceExtraNonChargeable").Value = False
390: End Select
		
395: rstPiece.Fields("Provenance").Value = sProvenance
		
400: Call rstPiece.Update()
		
405: Call rstPiece.Close()
		
410: Call rstInv.Close()
415: 'UPGRADE_NOTE: Object rstInv may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstInv = Nothing
		
420: rstPiece.CursorLocation = ADODB.CursorLocationEnum.adUseServer
		
425: Call rstPiece.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = '" & sNoProjet & "' AND NuméroLigne >= " & iCompteur & " ORDER BY NuméroLigne", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant qu'il y a des enregistrements dans le recordset
430: Do While Not rstPiece.EOF
435: If bSkip = False Then
440: bSkip = True
445: Else
450: rstPiece.Fields("NuméroLigne").Value = rstPiece.Fields("NuméroLigne").Value + 1
				
455: Call rstPiece.Update()
460: End If
			
465: Call rstPiece.MoveNext()
470: Loop 
		
475: Call rstPiece.Close()
480: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
485: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
490: Call CalculerTempsMecRecordset(sNoProjet)
			
495: Call CalculerTotalRecordsetElec(sNoProjet)
500: Else
505: Call CalculerTotalRecordsetMec(sNoProjet)
510: End If
		
515: Exit Sub
		
AfficherErreur: 
		
520: Call AfficherErreur("frmSortieMateriel", "AjouterDansProjet", Err, Erl())
	End Sub
	
	Private Sub CalculerTempsMecRecordset(ByVal sNoProjet As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjet As ADODB.Recordset
15: Dim rstPiece As ADODB.Recordset
20: Dim dblTempsMec As Double
		
		'Ouverture des tables
25: rstProjet = New ADODB.Recordset
30: rstPiece = New ADODB.Recordset
		
35: Call rstProjet.Open("SELECT * FROM GRB_ProjetElec WHERE IDProjet = '" & sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
40: Call rstPiece.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet ='" & sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Pour chaque enregistrement du recordset
45: Do While Not rstPiece.EOF
			'Si le temps total n'est pas vide
50: If Trim(rstPiece.Fields("Temps_total").Value) <> vbNullString Then
				'On additionne le temps
55: dblTempsMec = dblTempsMec + CDbl(Replace(Trim(rstPiece.Fields("Temps_total").Value), ".", ","))
60: End If
			
65: Call rstPiece.MoveNext()
70: Loop 
		
75: rstProjet.Fields("temp_mec").Value = Replace(CStr(dblTempsMec / 10), ".", ",")
		
80: Call rstProjet.Update()
		
85: Call rstPiece.Close()
90: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
95: Call rstProjet.Close()
100: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjet = Nothing
		
105: Exit Sub
		
AfficherErreur: 
		
110: Call AfficherErreur("frmSortieMateriel", "CalculerTempsMecRecordset", Err, Erl())
	End Sub
	
	Private Sub CalculerTotalRecordsetElec(ByVal sNoProjet As String)
		
5: On Error GoTo AfficherErreur
		
		'Méthode pour calculer le prix
10: Dim dblManuel As Double
15: Dim dblCopies As Double
20: Dim dblTempsDessin As Double
25: Dim dblTempsProg As Double
30: Dim dblTempsMec As Double
35: Dim dblTempsElec As Double
40: Dim dblTempsTest As Double
45: Dim dblTempsVision As Double
50: Dim dblPrixPieces As Double
55: Dim dblPrixTotal As Double
60: Dim dblCommission As Double
65: Dim dblTotalTemps As Double
70: Dim dblProfit As Double
75: Dim dblTotalManuel As Double
80: Dim dblTotalPieceImprevue As Double
85: Dim dblGrandTotal As Double
90: Dim rstProjet As ADODB.Recordset
95: Dim rstPiece As ADODB.Recordset
100: Dim rstConfig As ADODB.Recordset
105: Dim sCommission As String
110: Dim sCopieManuel As String
115: Dim sImprevue As String
		
120: rstProjet = New ADODB.Recordset
125: rstPiece = New ADODB.Recordset
130: rstConfig = New ADODB.Recordset
		
135: Call rstConfig.Open("SELECT * FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
140: sCommission = rstConfig.Fields("Commission").Value
145: sImprevue = rstConfig.Fields("Imprévus").Value
150: sCopieManuel = rstConfig.Fields("PrixPagesManuel").Value
		
155: Call rstConfig.Close()
160: 'UPGRADE_NOTE: Object rstConfig may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstConfig = Nothing
		
165: Call rstProjet.Open("SELECT * FROM GRB_ProjetElec WHERE IDProjet = '" & sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
170: If Not rstProjet.EOF Then
			'Validation du nombre de pages
175: If IsNumeric(rstProjet.Fields("Manuel").Value) Then
180: dblManuel = rstProjet.Fields("Manuel").Value
185: Else
190: dblManuel = 0
195: End If
			
			'Validation du nombre de copies
200: If IsNumeric(rstProjet.Fields("copies").Value) Then
205: dblCopies = rstProjet.Fields("copies").Value
210: Else
215: dblCopies = 0
220: End If
			
			'Validation des heures de dessin
225: If IsNumeric(rstProjet.Fields("temp_dessin").Value) Then
230: dblTempsDessin = rstProjet.Fields("temp_dessin").Value
235: Else
240: dblTempsDessin = 0
245: End If
			
			'Validation des heures de prog
250: If IsNumeric(rstProjet.Fields("temp_prog").Value) Then
255: dblTempsProg = rstProjet.Fields("temp_prog").Value
260: Else
265: dblTempsProg = 0
270: End If
			
			'Validation des heures de mec
275: If rstProjet.Fields("SansTemps").Value = True Then
280: dblTempsMec = 0
285: Else
290: dblTempsMec = rstProjet.Fields("temp_mec").Value
295: End If
			
			'Validation des heures d'élec
300: If IsNumeric(rstProjet.Fields("temp_elec").Value) Then
305: dblTempsElec = rstProjet.Fields("temp_elec").Value
310: Else
315: dblTempsElec = 0
320: End If
			
			'Validation des heures de test
325: If IsNumeric(rstProjet.Fields("temp_test").Value) Then
330: dblTempsTest = rstProjet.Fields("temp_test").Value
335: Else
340: dblTempsTest = 0
345: End If
			
			'Validation des heures de vision
350: If IsNumeric(rstProjet.Fields("temp_vision").Value) Then
355: dblTempsVision = rstProjet.Fields("temp_vision").Value
360: Else
365: dblTempsVision = 0
370: End If
			
375: Call rstPiece.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = '" & sNoProjet & "' AND Type = 'E'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'Pour chaque élément du recordset
380: Do While Not rstPiece.EOF
385: If Trim(rstPiece.Fields("Prix_total").Value) <> vbNullString Then
390: 'On additionne le prix total
395: dblPrixPieces = dblPrixPieces + rstPiece.Fields("Prix_total").Value
					
					'On additionne le profit
400: dblProfit = dblProfit + rstPiece.Fields("Profit_Argent").Value
405: End If
				
410: Call rstPiece.MoveNext()
415: Loop 
			
420: Call rstPiece.Close()
425: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstPiece = Nothing
			
			'On additionne les (temps * taux)
430: dblTotalTemps = (dblTempsDessin * CDbl(rstProjet.Fields("taux_dessin").Value)) + (dblTempsProg * CDbl(rstProjet.Fields("taux_prog").Value)) + (dblTempsMec * CDbl(rstProjet.Fields("taux_mec").Value)) + (dblTempsElec * CDbl(rstProjet.Fields("taux_elec").Value)) + (dblTempsTest * CDbl(rstProjet.Fields("taux_test").Value)) + (dblTempsVision * CDbl(rstProjet.Fields("taux_vision").Value))
			
435: dblTotalManuel = dblManuel * dblCopies * CDbl(sCopieManuel)
			
440: dblTotalPieceImprevue = dblPrixPieces * (1 + CDbl(sImprevue))
			
445: dblPrixTotal = dblTotalTemps + dblTotalManuel + dblTotalPieceImprevue
			
			'Le calcul de la commission est sur les manuels (Nbre de page * prix par pages * nbre de copies) + (prix des pièces * pourcentage d'imprévus) + total des temps
450: dblCommission = dblPrixTotal * CDbl(sCommission)
			
			'Le prix total est le calcul des manuels (Nbre de page * prix par pages * nbre de copies) + (prix des pièces * pourcentage d'imprévus) + total des temps + total de la commission
455: dblGrandTotal = dblPrixTotal + dblCommission
			
			'Format monétaires avec 2 chiffres après la virgule
460: rstProjet.Fields("total_commission").Value = dblCommission
465: rstProjet.Fields("Total_manuel").Value = dblTotalManuel
470: rstProjet.Fields("Total_temps").Value = dblTotalTemps
475: rstProjet.Fields("total_imprevue").Value = dblTotalPieceImprevue - dblPrixPieces
480: rstProjet.Fields("total_piece").Value = dblPrixPieces
485: rstProjet.Fields("Total_Commission").Value = Conversion_Renamed(CStr(System.Math.Round(dblCommission, 2)), ModuleMain.enumConvert.MODE_ARGENT)
490: rstProjet.Fields("PrixTotal").Value = Conversion_Renamed(CStr(System.Math.Round(dblGrandTotal, 2)), ModuleMain.enumConvert.MODE_ARGENT)
495: rstProjet.Fields("Total_Profit").Value = Conversion_Renamed(CStr(System.Math.Round(dblProfit, 2)), ModuleMain.enumConvert.MODE_ARGENT)
			
500: Call rstProjet.Update()
505: End If
		
510: Call rstProjet.Close()
515: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjet = Nothing
		
520: Exit Sub
		
AfficherErreur: 
		
525: Call AfficherErreur("frmSortieMateriel", "CalculerTotalRecordset", Err, Erl())
	End Sub
	
	Private Sub CalculerTotalRecordsetMec(ByVal sNoProjet As String)
		
5: On Error GoTo AfficherErreur
		
		'Méthode pour calculer le prix
10: Dim dblPrixPieces As Double
15: Dim dblPrixTotal As Double
20: Dim dblCommission As Double
25: Dim dblTotalTemps As Double
30: Dim dblProfit As Double
35: Dim dblTotalManuel As Double
40: Dim dblTotalImprevue As Double
45: Dim dblGrandTotal As Double
50: Dim dblTotalDessin As Double
55: Dim dblTotalCoupe As Double
60: Dim dblTotalMachinage As Double
65: Dim dblTotalSoudure As Double
70: Dim dblTotalAssemblage As Double
75: Dim dblTotalPeinture As Double
80: Dim dblTotalTest As Double
85: Dim dblTotalInstallation As Double
90: Dim dblTotalFormation As Double
95: Dim dblTotalGestion As Double
100: Dim dblHebergement As Double
105: Dim dblRepas As Double
110: Dim dblTransport As Double
115: Dim dblUniteMobile As Double
120: Dim dblPrixEmballage As Double
125: Dim dblTotalResteTemps As Double
130: Dim iNbrePersonne As Short
135: Dim rstProjet As ADODB.Recordset
140: Dim rstPiece As ADODB.Recordset
145: Dim rstConfig As ADODB.Recordset
150: Dim sCommission As String
155: Dim sImprevue As String
		
160: rstConfig = New ADODB.Recordset
		
165: Call rstConfig.Open("SELECT * FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
170: sCommission = rstConfig.Fields("Commission").Value
175: sImprevue = rstConfig.Fields("Imprévus").Value
		
180: Call rstConfig.Close()
185: 'UPGRADE_NOTE: Object rstConfig may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstConfig = Nothing
		
190: rstProjet = New ADODB.Recordset
195: rstPiece = New ADODB.Recordset
		
200: Call rstProjet.Open("SELECT * FROM GRB_ProjetMec WHERE IDProjet = '" & sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
205: Call rstPiece.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = '" & sNoProjet & "' AND Type = 'M'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Pour chaque élément du recordset
210: Do While Not rstPiece.EOF
215: If Trim(rstPiece.Fields("Prix_total").Value) <> vbNullString Then
				'On additionne le prix total
220: dblPrixPieces = dblPrixPieces + rstPiece.Fields("Prix_total").Value - rstPiece.Fields("Profit_Argent").Value
				
				'On additionne le profit
225: dblProfit = dblProfit + rstPiece.Fields("Profit_Argent").Value
230: End If
			
235: Call rstPiece.MoveNext()
240: Loop 
		
		'Total des temps
245: dblTotalMachinage = CDbl(rstProjet.Fields("TempsMachinage").Value) * CDbl(rstProjet.Fields("TauxMachinage").Value)
250: dblTotalCoupe = CDbl(rstProjet.Fields("TempsCoupe").Value) * CDbl(rstProjet.Fields("TauxCoupePréparation").Value)
255: dblTotalSoudure = CDbl(rstProjet.Fields("TempsSoudure").Value) * CDbl(rstProjet.Fields("TauxAssemblageSoudure").Value)
260: dblTotalAssemblage = CDbl(rstProjet.Fields("TempsAssemblage").Value) * CDbl(rstProjet.Fields("TauxAssemblageSystèmes").Value)
265: dblTotalPeinture = CDbl(rstProjet.Fields("TempsPeinture").Value) * CDbl(rstProjet.Fields("TauxPeintureFinition").Value)
270: dblTotalTest = CDbl(rstProjet.Fields("TempsTest").Value) * CDbl(rstProjet.Fields("TauxTestsFinaux").Value)
275: dblTotalDessin = CDbl(rstProjet.Fields("TempsDessin").Value) * CDbl(rstProjet.Fields("TauxConceptionDessins").Value)
280: dblTotalFormation = CDbl(rstProjet.Fields("TempsFormation").Value) * CDbl(rstProjet.Fields("TauxFormation").Value)
285: dblTotalInstallation = CDbl(rstProjet.Fields("TempsInstallation").Value) * CDbl(rstProjet.Fields("TauxInstallation").Value)
290: dblTotalGestion = CDbl(rstProjet.Fields("TempsGestion").Value) * CDbl(rstProjet.Fields("TauxGestion").Value)
		
295: dblTotalTemps = dblTotalMachinage + dblTotalCoupe + dblTotalSoudure + dblTotalAssemblage + dblTotalPeinture + dblTotalTest + dblTotalDessin + dblTotalFormation + dblTotalInstallation
		
300: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjet.Fields("NbrePersonne").Value) Then
305: If Trim(rstProjet.Fields("NbrePersonne").Value) <> "" Then
310: iNbrePersonne = Int(CDbl(rstProjet.Fields("NbrePersonne").Value))
315: Else
320: iNbrePersonne = 0
325: End If
330: Else
335: iNbrePersonne = 0
340: End If
		
345: Do While iNbrePersonne > 0
350: If iNbrePersonne >= 2 Then
355: dblHebergement = dblHebergement + CDbl(rstProjet.Fields("TempsHebergement").Value) * CDbl(rstProjet.Fields("TauxHebergement2").Value)
				
360: iNbrePersonne = iNbrePersonne - 2
365: Else
370: dblHebergement = dblHebergement + CDbl(rstProjet.Fields("TempsHebergement").Value) * CDbl(rstProjet.Fields("TauxHebergement1").Value)
				
375: iNbrePersonne = iNbrePersonne - 1
380: End If
385: Loop 
		
390: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjet.Fields("NbrePersonne").Value) Then
395: If Trim(rstProjet.Fields("NbrePersonne").Value) <> "" Then
400: dblRepas = CDbl(rstProjet.Fields("TempsRepas").Value) * CDbl(rstProjet.Fields("TauxRepas").Value) * CDbl(rstProjet.Fields("NbrePersonne").Value)
405: Else
410: dblRepas = 0
415: End If
420: Else
425: dblRepas = 0
430: End If
		
435: dblTransport = CDbl(rstProjet.Fields("TempsTransport").Value) * CDbl(rstProjet.Fields("TauxTransport").Value)
440: dblUniteMobile = CDbl(rstProjet.Fields("TempsUniteMobile").Value) * CDbl(rstProjet.Fields("TauxUniteMobile").Value)
		
		'Correction d'un bug de Type Incompatible
445: If IsNumeric(rstProjet.Fields("PrixEmballage").Value) Then
450: dblPrixEmballage = CDbl(rstProjet.Fields("PrixEmballage").Value)
455: Else
460: dblPrixEmballage = 0
465: End If
		
470: dblTotalResteTemps = dblHebergement + dblRepas + dblTransport + dblUniteMobile + dblPrixEmballage
		
475: If IsNumeric(rstProjet.Fields("total_manuel").Value) Then
480: dblTotalManuel = CDbl(rstProjet.Fields("total_manuel").Value)
485: Else
490: dblTotalManuel = 0
495: End If
		
500: dblTotalImprevue = (dblPrixPieces + dblProfit) * CDbl(sImprevue)
		
505: dblPrixTotal = dblPrixPieces + dblProfit + dblTotalTemps + dblTotalImprevue + dblTotalManuel + dblTotalResteTemps
		
		'Le calcul de la commission est sur les manuels (Nbre de page * prix par pages * nbre de copies) + (prix des pièces * pourcentage d'imprévus) + total des temps
510: dblCommission = dblPrixTotal * CDbl(sCommission)
		
		'Le prix total est le calcul des manuels (Nbre de page * prix par pages * nbre de copies) + (prix des pièces * pourcentage d'imprévus) + total des temps + total de la commission
515: dblGrandTotal = dblPrixTotal + dblCommission
		
		'Format monétaires avec 2 chiffres après la virgule
520: rstProjet.Fields("Total_Piece").Value = Conversion_Renamed(CStr(System.Math.Round(dblPrixPieces, 2)), ModuleMain.enumConvert.MODE_ARGENT)
525: rstProjet.Fields("Total_Temps").Value = Conversion_Renamed(CStr(System.Math.Round(dblTotalTemps, 2)), ModuleMain.enumConvert.MODE_ARGENT)
530: rstProjet.Fields("PrixTotal").Value = Conversion_Renamed(CStr(System.Math.Round(dblGrandTotal, 2)), ModuleMain.enumConvert.MODE_ARGENT)
535: rstProjet.Fields("total_Imprevue").Value = Conversion_Renamed(CStr(System.Math.Round(dblTotalImprevue, 2)), ModuleMain.enumConvert.MODE_ARGENT)
540: rstProjet.Fields("total_commission").Value = Conversion_Renamed(CStr(System.Math.Round(dblCommission, 2)), ModuleMain.enumConvert.MODE_ARGENT)
545: rstProjet.Fields("total_profit").Value = Conversion_Renamed(CStr(System.Math.Round(dblProfit, 2)), ModuleMain.enumConvert.MODE_ARGENT)
		
550: Call rstProjet.Update()
		
555: Call rstPiece.Close()
560: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
565: Call rstProjet.Close()
570: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjet = Nothing
		
575: Exit Sub
		
AfficherErreur: 
		
580: Call AfficherErreur("frmSortieMateriel", "CalculerTotalRecordset", Err, Erl())
	End Sub
End Class