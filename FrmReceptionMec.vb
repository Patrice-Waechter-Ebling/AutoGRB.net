Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FrmReceptionMec
	Inherits System.Windows.Forms.Form
	
	'Index des colonnes de lvwSoumission
	Private Const I_COL_QUANTITE As Short = 0
	Private Const I_COL_PIECE As Short = 1
	Private Const I_COL_DESCRIPTION As Short = 2
	Private Const I_COL_MANUFACTURIER As Short = 3
	Private Const I_COL_DISTRIBUTEUR As Short = 4
	Private Const I_COL_DATE_RECEPTION As Short = 5
	Private Const I_COL_DATE_COMMANDE As Short = 6
	Private Const I_COL_DATE_REQUISE As Short = 7
	
	Private Const I_LVW_PROJET As Short = 0
	Private Const I_LVW_QUANTITE As Short = 1
	Private Const I_LVW_PIECE As Short = 2
	Private Const I_LVW_DESCRIPTION As Short = 3
	Private Const I_LVW_FOURNISSEUR As Short = 4
	Private Const I_LVW_DATE_COMMANDE As Short = 5
	Private Const I_LVW_DATE_REQUISE As Short = 6
	
	Private Enum enumType
		PROJET = 0
		ACHAT = 1
	End Enum
	
	Private m_sUserID As String
	Private m_sNoProjet As String
	Private m_sNoAchat As String
	Private m_eType As enumType
	Private m_iIndexReception As Short
	
	'UPGRADE_WARNING: Event chkDateRequise.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkDateRequise_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkDateRequise.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If chkDateRequise.CheckState = System.Windows.Forms.CheckState.Checked Then
15: txtDateRequise.Enabled = True
20: cmdDateRequise.Enabled = True
25: Else
30: txtDateRequise.Enabled = False
35: cmdDateRequise.Enabled = False
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmReceptionMec", "chkDateRequise_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkProjetAchat.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkProjetAchat_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkProjetAchat.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If chkProjetAchat.CheckState = System.Windows.Forms.CheckState.Checked Then
15: txtProjetAchat.Enabled = True
20: Else
25: txtProjetAchat.Enabled = False
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmReceptionMec", "chkProjetAchat_Click", Err, Erl())
	End Sub
	
	Private Sub cmbNoProjet_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles cmbNoProjet.KeyUp
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: For iCompteur = 0 To cmbNoProjet.Items.Count - 1
20: If UCase(VB6.GetItemString(cmbNoProjet, iCompteur)) = UCase(cmbNoProjet.Text) Then
25: cmbNoProjet.SelectedIndex = iCompteur
				
30: Exit For
35: End If
40: Next 
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmReceptionMec", "cmbNoProjet_KeyUp", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbNoProjet.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbNoProjet_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbNoProjet.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjAchat As ADODB.Recordset
15: Dim sNumero As String
		
20: rstProjAchat = New ADODB.Recordset
		
25: sNumero = txtnoprojet.Text
		
30: If m_eType = enumType.ACHAT Then
35: Call rstProjAchat.Open("SELECT * FROM GRB_Achat WHERE IDAchat = '" & VB.Left(cmbNoProjet.Text, 9) & "' AND IndexAchat = " & CShort(VB.Right(cmbNoProjet.Text, 3)), g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
40: Else
45: Call rstProjAchat.Open("SELECT * FROM GRB_ProjetMec WHERE IDProjet = '" & cmbNoProjet.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
50: End If
		
55: If rstProjAchat.Fields("Modification").Value = True Then
60: If m_eType = enumType.ACHAT Then
65: Call MsgBox("Cet achat est en modification par " & rstProjAchat.Fields("Par").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
70: Else
75: Call MsgBox("Ce projet est en modification par " & rstProjAchat.Fields("Par").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
80: End If
			
85: Call rstProjAchat.Close()
90: 'UPGRADE_NOTE: Object rstProjAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstProjAchat = Nothing
			
95: cmbNoProjet.Text = sNumero
			
100: Exit Sub
105: End If
		
110: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
115: m_iIndexReception = 0
		
120: txtnoprojet.Text = cmbNoProjet.Text
		
125: If m_eType = enumType.PROJET Then
			'Rempli les valeurs du projet sélectionné
130: Call RemplirListViewProjet(txtnoprojet.Text)
135: Else
140: Call RemplirListViewAchat(txtnoprojet.Text)
145: End If
		
150: Call VerifierBoutonAnnuler()
		
155: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
160: Exit Sub
		
AfficherErreur: 
		
165: Call AfficherErreur("frmReceptionMec", "cmbNoProjet_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAfficher_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAfficher.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim bRemplir As Boolean
		
15: If chkProjetAchat.CheckState = System.Windows.Forms.CheckState.Checked Then
20: If Trim(txtProjetAchat.Text) <> "" Then
25: If m_eType = enumType.ACHAT Then
30: If Len(Trim(txtProjetAchat.Text)) = 13 Then
35: bRemplir = True
40: Else
45: Call MsgBox("Format de numéro d'achat incorrect!", MsgBoxStyle.OKOnly, "Erreur")
50: End If
55: Else
60: If Len(Trim(txtProjetAchat.Text)) = 9 Then
65: bRemplir = True
70: Else
75: Call MsgBox("Format de numéro de projet incorrect!", MsgBoxStyle.OKOnly, "Erreur")
80: End If
85: End If
90: Else
95: If m_eType = enumType.ACHAT Then
100: Call MsgBox("Le numéro de l'achat est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
105: Else
110: Call MsgBox("Le numéro de projet est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
115: End If
120: End If
125: Else
130: bRemplir = True
135: End If
		
140: If bRemplir = True Then
145: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
150: Call RemplirListePiecesNonRecues()
			
155: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
160: End If
		
165: Exit Sub
		
AfficherErreur: 
		
170: Call AfficherErreur("frmReceptionMec", "cmdAfficher_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.PROJET Then
15: Call AnnulerReceptionProjet()
20: Else
25: Call AnnulerReceptionAchat()
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmReceptionMec", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub AnnulerReceptionProjet()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjet As ADODB.Recordset
15: Dim rstPiece As ADODB.Recordset
20: Dim rstModif As ADODB.Recordset
25: Dim rstEmploye As ADODB.Recordset
		
		'S'il y a des enregistrements
30: If lvwProjet.Items.Count > 0 Then
35: rstProjet = New ADODB.Recordset
			
40: Call rstProjet.Open("SELECT Modification, Par FROM GRB_ProjetMec WHERE IDProjet = '" & txtnoprojet.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
45: If rstProjet.Fields("Modification").Value = False Then
50: rstPiece = New ADODB.Recordset
				
55: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				Call rstPiece.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = '" & txtnoprojet.Text & "' AND Type = 'M' AND NuméroLigne = " & lvwProjet.FocusedItem.SubItems.Item(I_COL_MANUFACTURIER).Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
65: rstPiece.Fields("Recu").Value = False
70: rstPiece.Fields("Commandé").Value = True
				
75: rstPiece.Fields("DateRéception").Value = ""
				
80: Call rstPiece.Update()
				
				'Ajout aux modifs
85: rstModif = New ADODB.Recordset
				
90: Call rstModif.Open("SELECT * FROM GRB_Projet_Modif", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
95: Call rstModif.AddNew()
				
100: rstEmploye = New ADODB.Recordset
				
105: Call rstEmploye.Open("SELECT noEmploye FROM GRB_Employés WHERE loginname = '" & g_sUserID & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
110: rstModif.Fields("Type").Value = "M"
115: rstModif.Fields("IDProjet").Value = txtnoprojet.Text
120: rstModif.Fields("noEmployé").Value = rstEmploye.Fields("noEmploye").Value
125: rstModif.Fields("Date").Value = ConvertDate(Today)
130: rstModif.Fields("Heure").Value = TimeOfDay
135: rstModif.Fields("TypeModif").Value = "RECEPTION"
				
140: Call rstEmploye.Close()
145: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstEmploye = Nothing
				
150: Call rstModif.Update()
				
155: Call rstModif.Close()
160: 'UPGRADE_NOTE: Object rstModif may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstModif = Nothing
				
165: Call rstPiece.Close()
170: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstPiece = Nothing
				
175: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If UCase(lvwProjet.FocusedItem.SubItems(I_COL_DISTRIBUTEUR).Text) = "SOLUTION GRB INC." Then
180: Call AjouterInventaireProjet()
185: End If
				
190: Call SupprimerHistorique()
				
195: m_iIndexReception = lvwProjet.FocusedItem.Index
				
200: Call RemplirListViewProjet(txtnoprojet.Text)
205: Else
210: Call MsgBox("Ce projet est en modification par " & rstProjet.Fields("Par").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
215: End If
			
220: Call rstProjet.Close()
225: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstProjet = Nothing
230: End If
		
235: Exit Sub
		
AfficherErreur: 
		
240: Call AfficherErreur("frmReceptionMec", "AnnulerReceptionProjet", Err, Erl())
	End Sub
	
	Private Sub AnnulerReceptionAchat()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPiece As ADODB.Recordset
15: Dim rstAchat As ADODB.Recordset
20: Dim sIDAchat As String
25: Dim iIndexAchat As Short
		
		'S'il y a des enregistrements
30: If lvwProjet.Items.Count > 0 Then
35: sIDAchat = VB.Left(txtnoprojet.Text, 9)
40: iIndexAchat = CShort(VB.Right(txtnoprojet.Text, 3))
			
45: rstAchat = New ADODB.Recordset
			
50: Call rstAchat.Open("SELECT Modification, Par FROM GRB_Achat WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
55: If rstAchat.Fields("Modification").Value = False Then
60: rstPiece = New ADODB.Recordset
				
65: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				Call rstPiece.Open("SELECT * FROM GRB_Achat_Pieces WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat & " And NuméroLigne = " & lvwProjet.FocusedItem.SubItems.Item(I_COL_MANUFACTURIER).Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
75: rstPiece.Fields("Recu").Value = False
80: rstPiece.Fields("Commandé").Value = True
				
85: rstPiece.Fields("DateRéception").Value = ""
				
90: Call rstPiece.Update()
				
95: If (CShort(VB.Right(sIDAchat, 2)) >= 0 And CShort(VB.Right(sIDAchat, 2)) <= 12) Or rstPiece.Fields("IDFRS").Value = 717 Then
100: Call EnleverInventaireAchat()
105: End If
				
110: Call rstPiece.Close()
115: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstPiece = Nothing
				
120: m_iIndexReception = lvwProjet.FocusedItem.Index
				
125: Call RemplirListViewAchat(txtnoprojet.Text)
130: Else
135: Call MsgBox("Ce projet est en modification par " & rstAchat.Fields("Par").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
140: End If
			
145: Call rstAchat.Close()
150: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstAchat = Nothing
155: End If
		
160: Exit Sub
		
AfficherErreur: 
		
165: Call AfficherErreur("frmReceptionMec", "AnnulerReceptionAchat", Err, Erl())
	End Sub
	
	Private Sub EnleverInventaireAchat()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstInventaire As ADODB.Recordset
15: Dim sQuantite As String
		
20: If MsgBox("Voulez-vous modifier l'inventaire?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
25: rstInventaire = New ADODB.Recordset
			
30: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Call rstInventaire.Open("SELECT * FROM GRB_InventaireMec WHERE NoItem = '" & lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
35: If Not rstInventaire.EOF Then
40: If rstInventaire.Fields("CommandeParBoite").Value = True Then
45: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvwProjet.FocusedItem.SubItems.Item(I_COL_DISTRIBUTEUR).Tag = 717 Then
50: rstInventaire.Fields("QuantitéStock").Value = Replace(CStr(CDbl(rstInventaire.Fields("QuantitéStock").Value) + (CDbl(lvwProjet.FocusedItem.Text) * CDbl(rstInventaire.Fields("QteBoite").Value))), "", ",")
55: Else
60: rstInventaire.Fields("QuantitéStock").Value = Replace(CStr(CDbl(rstInventaire.Fields("QuantitéStock").Value) - (CDbl(lvwProjet.FocusedItem.Text) * CDbl(rstInventaire.Fields("QteBoite").Value))), ".", ",")
65: End If
					
70: sQuantite = CStr(CDbl(lvwProjet.FocusedItem.Text) * CDbl(rstInventaire.Fields("QteBoite").Value))
75: Else
80: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvwProjet.FocusedItem.SubItems.Item(I_COL_DISTRIBUTEUR).Tag = 717 Then
85: rstInventaire.Fields("QuantitéStock").Value = Replace(CStr(CDbl(rstInventaire.Fields("QuantitéStock").Value) + CDbl(lvwProjet.FocusedItem.Text)), "", ",")
90: Else
95: rstInventaire.Fields("QuantitéStock").Value = Replace(CStr(CDbl(rstInventaire.Fields("QuantitéStock").Value) - CDbl(lvwProjet.FocusedItem.Text)), ".", ",")
100: End If
					
105: sQuantite = CStr(CDbl(lvwProjet.FocusedItem.Text))
110: End If
				
115: Call rstInventaire.Update()
120: End If
			
125: Call rstInventaire.Close()
130: 'UPGRADE_NOTE: Object rstInventaire may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstInventaire = Nothing
			
135: Call SupprimerHistorique(sQuantite)
140: End If
		
145: Exit Sub
		
AfficherErreur: 
		
150: Call AfficherErreur("frmReceptionMec", "EnleverInventaireAchat", Err, Erl())
	End Sub
	
	Private Sub AjouterInventaireProjet()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstInventaire As ADODB.Recordset
15: Dim sQuantite As String
		
20: If MsgBox("Voulez-vous modifier l'inventaire?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
25: rstInventaire = New ADODB.Recordset
			
30: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Call rstInventaire.Open("SELECT * FROM GRB_InventaireMec WHERE NoItem = '" & Replace(lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
35: If Not rstInventaire.EOF Then
40: If rstInventaire.Fields("CommandeParBoite").Value = True Then
45: rstInventaire.Fields("QuantitéStock").Value = Replace(CStr(CDbl(rstInventaire.Fields("QuantitéStock").Value) + (CDbl(lvwProjet.FocusedItem.Text) * CDbl(rstInventaire.Fields("QteBoite").Value))), ".", ",")
					
50: sQuantite = CStr(CDbl(lvwProjet.FocusedItem.Text) * CDbl(rstInventaire.Fields("QteBoite").Value))
55: Else
60: rstInventaire.Fields("QuantitéStock").Value = Replace(CStr(CDbl(rstInventaire.Fields("QuantitéStock").Value) + CDbl(lvwProjet.FocusedItem.Text)), ".", ",")
					
65: sQuantite = CStr(CDbl(lvwProjet.FocusedItem.Text))
70: End If
				
75: Call rstInventaire.Update()
80: End If
			
85: Call rstInventaire.Close()
90: 'UPGRADE_NOTE: Object rstInventaire may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstInventaire = Nothing
			
95: Call SupprimerHistorique(sQuantite)
100: End If
		
105: Exit Sub
		
AfficherErreur: 
		
110: Call AfficherErreur("frmReceptionMec", "AjouterInventaireProjet", Err, Erl())
	End Sub
	
	Private Sub cmdDateRequise_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDateRequise.Click
		
5: On Error GoTo AfficherErreur
		
		'Ouverture du calendrier
10: If txtDateRequise.Text <> vbNullString Then
15: mvwDateRequise.Value = CDate(txtDateRequise.Text)
20: Else
25: mvwDateRequise.Value = Today
35: End If
		
40: mvwDateRequise.Visible = True
		
45: Call mvwDateRequise.Focus()
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmReceptionMec", "cmdDateRequise_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFermerPieces_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermerPieces.Click
		
5: On Error GoTo AfficherErreur
		
10: fraPiecesNonRecues.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmReceptionMec", "cmdFermerPieces_Click", Err, Erl())
	End Sub
	
	Private Sub cmdImprimerPieces_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImprimerPieces.Click
		Dim DR_BackOrder As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPiece As ADODB.Recordset
		
15: rstPiece = New ADODB.Recordset
		
20: If m_eType = enumType.PROJET Then
25: If chkDateRequise.CheckState = System.Windows.Forms.CheckState.Checked And chkProjetAchat.CheckState = System.Windows.Forms.CheckState.Checked Then
30: Call rstPiece.Open("SELECT GRB_Projet_Pieces.*, GRB_Fournisseur.NomFournisseur FROM GRB_Projet_Pieces INNER JOIN GRB_Fournisseur ON GRB_Projet_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE Type = 'M' AND Commandé = True AND DateRequise <= '" & txtDateRequise.Text & "' AND IDProjet = '" & txtProjetAchat.Text & "' AND DateRequise <> '' ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
35: Else
40: If chkDateRequise.CheckState = System.Windows.Forms.CheckState.Checked Then
45: Call rstPiece.Open("SELECT GRB_Projet_Pieces.*, GRB_Fournisseur.NomFournisseur FROM GRB_Projet_Pieces INNER JOIN GRB_Fournisseur ON GRB_Projet_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE Type = 'M' AND Commandé = True AND DateRequise <= '" & txtDateRequise.Text & "' AND DateRequise <> '' ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
50: Else
55: If chkProjetAchat.CheckState = System.Windows.Forms.CheckState.Checked Then
60: Call rstPiece.Open("SELECT GRB_Projet_Pieces.*, GRB_Fournisseur.NomFournisseur FROM GRB_Projet_Pieces INNER JOIN GRB_Fournisseur ON GRB_Projet_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE Type = 'M' AND Commandé = True AND IDProjet = '" & txtProjetAchat.Text & "' ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
65: Else
70: Call rstPiece.Open("SELECT GRB_Projet_Pieces.*, GRB_Fournisseur.NomFournisseur FROM GRB_Projet_Pieces INNER JOIN GRB_Fournisseur ON GRB_Projet_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE Type = 'M' AND Commandé = True ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
75: End If
80: End If
85: End If
90: Else
95: If chkDateRequise.CheckState = System.Windows.Forms.CheckState.Checked And chkProjetAchat.CheckState = System.Windows.Forms.CheckState.Checked Then
100: Call rstPiece.Open("SELECT (GRB_Achat_Pieces.IDAchat &  '-' & RIGHT('00' & GRB_Achat_Pieces.IndexAchat,3)) AS NoAchat, GRB_Achat_Pieces.*, GRB_Fournisseur.NomFournisseur FROM GRB_Achat_Pieces INNER JOIN GRB_Fournisseur ON GRB_Achat_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE LEN(IDAchat) = 9 AND Commandé = True AND DateRequise <= '" & txtDateRequise.Text & "' AND IDAchat = '" & VB.Left(txtProjetAchat.Text, 9) & "' AND IndexAchat = " & CShort(VB.Right(txtProjetAchat.Text, 3)) & " AND DateRequise <> '' ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
105: Else
110: If chkDateRequise.CheckState = System.Windows.Forms.CheckState.Checked Then
115: Call rstPiece.Open("SELECT (GRB_Achat_Pieces.IDAchat &  '-' & RIGHT('00' & GRB_Achat_Pieces.IndexAchat,3)) AS NoAchat, GRB_Achat_Pieces.*, GRB_Fournisseur.NomFournisseur FROM GRB_Achat_Pieces INNER JOIN GRB_Fournisseur ON GRB_Achat_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE LEN(IDAchat) = 9 AND Commandé = True AND DateRequise <= '" & txtDateRequise.Text & "' AND DateRequise <> '' ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
120: Else
125: If chkProjetAchat.CheckState = System.Windows.Forms.CheckState.Checked Then
130: Call rstPiece.Open("SELECT (GRB_Achat_Pieces.IDAchat &  '-' & RIGHT('00' & GRB_Achat_Pieces.IndexAchat,3)) AS NoAchat, GRB_Achat_Pieces.*, GRB_Fournisseur.NomFournisseur FROM GRB_Achat_Pieces INNER JOIN GRB_Fournisseur ON GRB_Achat_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE LEN(IDAchat) = 9 AND Commandé = True AND IDAchat = '" & VB.Left(txtProjetAchat.Text, 9) & "' AND IndexAchat = " & CShort(VB.Right(txtProjetAchat.Text, 3)) & " ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
135: Else
140: Call rstPiece.Open("SELECT (GRB_Achat_Pieces.IDAchat &  '-' & RIGHT('00' & GRB_Achat_Pieces.IndexAchat,3)) AS NoAchat, GRB_Achat_Pieces.*, GRB_Fournisseur.NomFournisseur FROM GRB_Achat_Pieces INNER JOIN GRB_Fournisseur ON GRB_Achat_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE LEN(IDAchat) = 9 AND Commandé = True ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
145: End If
150: End If
155: End If
160: End If
		
165: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BackOrder.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BackOrder.DataSource = rstPiece
		
170: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BackOrder.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BackOrder.Orientation = MSDataReportLib.OrientationConstants.rptOrientLandscape
		
175: If m_eType = enumType.PROJET Then
180: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BackOrder.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_BackOrder.Sections("Section4").Controls("lblTitre").Caption = "Projets mécaniques : Pièces non reçues"
			
185: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BackOrder.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_BackOrder.Sections("Section4").Controls("lblTitreProjetAchat").Caption = "Projet : "
190: Else
195: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BackOrder.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_BackOrder.Sections("Section4").Controls("lblTitre").Caption = "Achats mécaniques : Pièces non reçues"
			
200: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BackOrder.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_BackOrder.Sections("Section4").Controls("lblTitreProjetAchat").Caption = "Achat : "
205: End If
		
210: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BackOrder.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BackOrder.Sections("Section4").Controls("lblDate").Caption = txtDateRequise.Text
		
215: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BackOrder.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_BackOrder.Sections("Section4").Controls("lblProjetAchat").Caption = txtProjetAchat.Text
		
220: If m_eType = enumType.ACHAT Then
225: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BackOrder.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_BackOrder.Sections("Section2").Controls("lblTitreNoProjet").Caption = "# Achat"
			
230: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BackOrder.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_BackOrder.Sections("Section1").Controls("txtNoProjAchat").DataField = "NoAchat"
235: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BackOrder.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_BackOrder.Sections("Section1").Controls("txtNoItem").DataField = "PIECE"
240: End If
		
245: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_BackOrder.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_BackOrder.Show(VB6.FormShowConstants.Modal)
		
250: Call rstPiece.Close()
255: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
260: Exit Sub
		
AfficherErreur: 
		
265: Call AfficherErreur("frmReceptionMec", "cmdImprimerPieces_Click", Err, Erl())
	End Sub
	
	Private Sub cmdNonRecu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNonRecu.Click
		
5: On Error GoTo AfficherErreur
		
10: Call lvwPieces.Items.Clear()
		
15: If m_eType = enumType.ACHAT Then
20: chkProjetAchat.Text = "No achat : "
25: Else
30: chkProjetAchat.Text = "No projet : "
35: End If
		
40: fraPiecesNonRecues.Visible = True
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmReceptionMec", "cmdNonRecu_Click", Err, Erl())
	End Sub
	
	Private Sub RemplirListePiecesNonRecues()
		
5: On Error GoTo AfficherErreur
		
10: Dim itmPiece As System.Windows.Forms.ListViewItem
15: Dim rstPiece As ADODB.Recordset
		
20: Call lvwPieces.Items.Clear()
		
25: rstPiece = New ADODB.Recordset
		
30: If m_eType = enumType.PROJET Then
35: If chkDateRequise.CheckState = System.Windows.Forms.CheckState.Checked And chkProjetAchat.CheckState = System.Windows.Forms.CheckState.Checked Then
40: Call rstPiece.Open("SELECT GRB_Projet_Pieces.*, GRB_Fournisseur.NomFournisseur FROM GRB_Projet_Pieces INNER JOIN GRB_Fournisseur ON GRB_Projet_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE Type = 'M' AND Commandé = True AND DateRequise <= '" & txtDateRequise.Text & "' AND IDProjet = '" & txtProjetAchat.Text & "' AND DateRequise <> '' ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
45: Else
50: If chkDateRequise.CheckState = System.Windows.Forms.CheckState.Checked Then
55: Call rstPiece.Open("SELECT GRB_Projet_Pieces.*, GRB_Fournisseur.NomFournisseur FROM GRB_Projet_Pieces INNER JOIN GRB_Fournisseur ON GRB_Projet_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE Type = 'M' AND Commandé = True AND DateRequise <= '" & txtDateRequise.Text & "' AND DateRequise <> '' ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
60: Else
65: If chkProjetAchat.CheckState = System.Windows.Forms.CheckState.Checked Then
70: Call rstPiece.Open("SELECT GRB_Projet_Pieces.*, GRB_Fournisseur.NomFournisseur FROM GRB_Projet_Pieces INNER JOIN GRB_Fournisseur ON GRB_Projet_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE Type = 'M' AND Commandé = True AND IDProjet = '" & txtProjetAchat.Text & "' ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
75: Else
80: Call rstPiece.Open("SELECT GRB_Projet_Pieces.*, GRB_Fournisseur.NomFournisseur FROM GRB_Projet_Pieces INNER JOIN GRB_Fournisseur ON GRB_Projet_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE Type = 'M' AND Commandé = True ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
85: End If
90: End If
95: End If
100: Else
105: If chkDateRequise.CheckState = System.Windows.Forms.CheckState.Checked And chkProjetAchat.CheckState = System.Windows.Forms.CheckState.Checked Then
110: Call rstPiece.Open("SELECT GRB_Achat_Pieces.*, GRB_Fournisseur.NomFournisseur FROM GRB_Achat_Pieces INNER JOIN GRB_Fournisseur ON GRB_Achat_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE LEN(IDAchat) = 9 AND Commandé = True AND DateRequise <= '" & txtDateRequise.Text & "' AND IDAchat = '" & VB.Left(txtProjetAchat.Text, 9) & "' AND IndexAchat = " & CShort(VB.Right(txtProjetAchat.Text, 3)) & " AND DateRequise <> '' ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
115: Else
120: If chkDateRequise.CheckState = System.Windows.Forms.CheckState.Checked Then
125: Call rstPiece.Open("SELECT GRB_Achat_Pieces.*, GRB_Fournisseur.NomFournisseur FROM GRB_Achat_Pieces INNER JOIN GRB_Fournisseur ON GRB_Achat_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE LEN(IDAchat) = 9 AND Commandé = True AND DateRequise <= '" & txtDateRequise.Text & "' AND DateRequise <> '' ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
130: Else
135: If chkProjetAchat.CheckState = System.Windows.Forms.CheckState.Checked Then
140: Call rstPiece.Open("SELECT GRB_Achat_Pieces.*, GRB_Fournisseur.NomFournisseur FROM GRB_Achat_Pieces INNER JOIN GRB_Fournisseur ON GRB_Achat_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE LEN(IDAchat) = 9 AND Commandé = True AND IDAchat = '" & VB.Left(txtProjetAchat.Text, 9) & "' AND IndexAchat = " & CShort(VB.Right(txtProjetAchat.Text, 3)) & " ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
145: Else
150: Call rstPiece.Open("SELECT GRB_Achat_Pieces.*, GRB_Fournisseur.NomFournisseur FROM GRB_Achat_Pieces INNER JOIN GRB_Fournisseur ON GRB_Achat_Pieces.IDFRS = GRB_Fournisseur.IDFRS WHERE LEN(IDAchat) = 9 AND Commandé = True ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
155: End If
160: End If
165: End If
170: End If
		
175: Do While Not rstPiece.EOF
180: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPieces.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmPiece = lvwPieces.Items.Add()
			
185: If m_eType = enumType.PROJET Then
190: itmPiece.Text = rstPiece.Fields("IDProjet").Value
195: Else
200: itmPiece.Text = rstPiece.Fields("IDAchat").Value & "-" & VB.Right("00" & rstPiece.Fields("IndexAchat").Value, 3)
205: End If
			
210: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPiece.SubItems.Count > I_LVW_QUANTITE Then
				itmPiece.SubItems(I_LVW_QUANTITE).Text = rstPiece.Fields("Qté").Value
			Else
				itmPiece.SubItems.Insert(I_LVW_QUANTITE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("Qté").Value))
			End If
			
215: If m_eType = enumType.PROJET Then
220: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_LVW_PIECE Then
					itmPiece.SubItems(I_LVW_PIECE).Text = rstPiece.Fields("NumItem").Value
				Else
					itmPiece.SubItems.Insert(I_LVW_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("NumItem").Value))
				End If
225: Else
230: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_LVW_PIECE Then
					itmPiece.SubItems(I_LVW_PIECE).Text = rstPiece.Fields("PIECE").Value
				Else
					itmPiece.SubItems.Insert(I_LVW_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("PIECE").Value))
				End If
235: End If
			
240: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPiece.SubItems.Count > I_LVW_DESCRIPTION Then
				itmPiece.SubItems(I_LVW_DESCRIPTION).Text = rstPiece.Fields("Desc_FR").Value
			Else
				itmPiece.SubItems.Insert(I_LVW_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("Desc_FR").Value))
			End If
245: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPiece.SubItems.Count > I_LVW_FOURNISSEUR Then
				itmPiece.SubItems(I_LVW_FOURNISSEUR).Text = rstPiece.Fields("NomFournisseur").Value
			Else
				itmPiece.SubItems.Insert(I_LVW_FOURNISSEUR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("NomFournisseur").Value))
			End If
			
250: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPiece.Fields("DateCommande").Value) Then
255: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_LVW_DATE_COMMANDE Then
					itmPiece.SubItems(I_LVW_DATE_COMMANDE).Text = rstPiece.Fields("DateCommande").Value
				Else
					itmPiece.SubItems.Insert(I_LVW_DATE_COMMANDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("DateCommande").Value))
				End If
260: Else
265: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_LVW_DATE_COMMANDE Then
					itmPiece.SubItems(I_LVW_DATE_COMMANDE).Text = ""
				Else
					itmPiece.SubItems.Insert(I_LVW_DATE_COMMANDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
				End If
270: End If
			
275: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPiece.Fields("DateRequise").Value) Then
280: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_LVW_DATE_REQUISE Then
					itmPiece.SubItems(I_LVW_DATE_REQUISE).Text = rstPiece.Fields("DateRequise").Value
				Else
					itmPiece.SubItems.Insert(I_LVW_DATE_REQUISE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("DateRequise").Value))
				End If
285: Else
290: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_LVW_DATE_REQUISE Then
					itmPiece.SubItems(I_LVW_DATE_REQUISE).Text = ""
				Else
					itmPiece.SubItems.Insert(I_LVW_DATE_REQUISE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
				End If
295: End If
			
300: Call rstPiece.MoveNext()
305: Loop 
		
310: Call rstPiece.Close()
315: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
320: Exit Sub
		
AfficherErreur: 
		
325: Call AfficherErreur("frmReceptionMec", "RemplirListePiecesNonRecues", Err, Erl())
	End Sub
	
	Private Sub lvwProjet_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwProjet.Click
		
5: On Error GoTo AfficherErreur
		
10: Call VerifierBoutonAnnuler()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmReceptionMec", "lvwProjet_Click", Err, Erl())
	End Sub
	
	Private Sub lvwProjet_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwProjet.DoubleClick
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.PROJET Then
15: Call ReceptionProjet()
20: Else
25: Call ReceptionAchat()
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmReceptionMec", "Reception", Err, Erl())
	End Sub
	
	Private Sub ReceptionProjet()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPiece As ADODB.Recordset
15: Dim rstCopiePiece As ADODB.Recordset
20: Dim rstProjet As ADODB.Recordset
25: Dim rstModif As ADODB.Recordset
30: Dim rstEmploye As ADODB.Recordset
35: Dim sQuantite As String
40: Dim sTotal As String
45: Dim sProfit As String
50: Dim bSkip As Boolean
		
		'Si il y a des enregistrements
55: If lvwProjet.Items.Count > 0 Then
60: rstProjet = New ADODB.Recordset
			
65: Call rstProjet.Open("SELECT Modification, Par, Profit FROM GRB_ProjetMec WHERE IDProjet = '" & txtnoprojet.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
70: If rstProjet.Fields("Modification").Value = False Then
75: If System.Drawing.ColorTranslator.ToOle(lvwProjet.FocusedItem.ForeColor) = COLOR_ORANGE Or System.Drawing.ColorTranslator.ToOle(lvwProjet.FocusedItem.ForeColor) = COLOR_BLEU Then 'COLOR_ORANGE ou bleu
80: sQuantite = InputBox("Quelle est la quantité recue?")
					
85: sQuantite = Replace(sQuantite, ".", ",")
					
90: sProfit = rstProjet.Fields("Profit").Value
					
95: If sQuantite <> "" Then
100: If IsNumeric(sQuantite) Then
105: If CDbl(sQuantite) > 0 Then
110: rstPiece = New ADODB.Recordset
115: rstModif = New ADODB.Recordset
120: rstEmploye = New ADODB.Recordset
								
125: If CDbl(sQuantite) = CDbl(lvwProjet.FocusedItem.Text) Then
130: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
									Call rstPiece.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = '" & txtnoprojet.Text & "' AND Type = 'M' AND NuméroLigne = " & lvwProjet.FocusedItem.SubItems.Item(I_COL_MANUFACTURIER).Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
									
140: rstPiece.Fields("Recu").Value = True
145: rstPiece.Fields("Commandé").Value = False
150: rstPiece.Fields("DateRéception").Value = txtDateReception.Text
									
155: Call rstPiece.Update()
									
									'Ajout aux modifs
160: Call rstModif.Open("SELECT * FROM GRB_Projet_Modif", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
									
165: Call rstModif.AddNew()
									
170: Call rstEmploye.Open("SELECT noEmploye FROM GRB_Employés WHERE loginname = '" & g_sUserID & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
									
175: rstModif.Fields("Type").Value = "M"
180: rstModif.Fields("IDProjet").Value = txtnoprojet.Text
185: rstModif.Fields("noEmployé").Value = rstEmploye.Fields("noEmploye").Value
190: rstModif.Fields("Date").Value = ConvertDate(Today)
195: rstModif.Fields("Heure").Value = TimeOfDay
200: rstModif.Fields("TypeModif").Value = "RECEPTION"
									
205: Call rstEmploye.Close()
									
210: Call rstModif.Update()
									
215: Call rstModif.Close()
									
220: Call rstPiece.Close()
									
225: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
									If UCase(lvwProjet.FocusedItem.SubItems(I_COL_DISTRIBUTEUR).Text) = "SOLUTION GRB INC." Then
230: Call EnleverInventaireProjet(sQuantite)
235: End If
									
240: m_iIndexReception = lvwProjet.FocusedItem.Index
									
245: Call RemplirListViewProjet(txtnoprojet.Text)
250: Else
255: If CDbl(sQuantite) < CDbl(lvwProjet.FocusedItem.Text) Then
260: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
										Call rstPiece.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = '" & txtnoprojet.Text & "' AND Type = 'M' AND NuméroLigne = " & lvwProjet.FocusedItem.SubItems.Item(I_COL_MANUFACTURIER).Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
										
265: sTotal = rstPiece.Fields("Qté").Value
										
270: rstPiece.Fields("Qté").Value = sQuantite
										
										'Pour le prix total, il faut faire la quantité * prix net * pourcentage de profit
280: rstPiece.Fields("Prix_Total").Value = Conversion_Renamed(CStr(System.Math.Round(CDbl(Replace(rstPiece.Fields("Qté").Value, "*", vbNullString)) * rstPiece.Fields("Prix_net").Value * CSng(sProfit), 2)), ModuleMain.enumConvert.MODE_PAS_FORMAT)
										
										'Pour le profit, c'est le prix total - (prix net * quantité)
285: rstPiece.Fields("Profit_argent").Value = Conversion_Renamed(CStr(System.Math.Round(rstPiece.Fields("Prix_total").Value - (rstPiece.Fields("Prix_net").Value * CDbl(Replace(rstPiece.Fields("Qté").Value, "*", vbNullString))), 2)), ModuleMain.enumConvert.MODE_PAS_FORMAT)
										
290: rstPiece.Fields("Recu").Value = True
295: rstPiece.Fields("Commandé").Value = False
300: rstPiece.Fields("DateRéception").Value = txtDateReception.Text
										
305: Call rstPiece.Update()
										
310: rstCopiePiece = New ADODB.Recordset
										
315: Call rstCopiePiece.Open("SELECT * FROM GRB_Projet_Pieces", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
										
320: Call rstCopiePiece.AddNew()
										
325: rstCopiePiece.Fields("IDProjet").Value = rstPiece.Fields("IDProjet").Value
330: rstCopiePiece.Fields("IDSection").Value = rstPiece.Fields("IDSection").Value
335: rstCopiePiece.Fields("NumItem").Value = rstPiece.Fields("NumItem").Value
340: rstCopiePiece.Fields("Qté").Value = CDbl(sTotal) - CDbl(sQuantite)
345: rstCopiePiece.Fields("Desc_FR").Value = rstPiece.Fields("Desc_FR").Value
350: rstCopiePiece.Fields("Desc_EN").Value = rstPiece.Fields("Desc_EN").Value
355: rstCopiePiece.Fields("Manufact").Value = rstPiece.Fields("Manufact").Value
360: rstCopiePiece.Fields("Prix_List").Value = rstPiece.Fields("Prix_List").Value
365: rstCopiePiece.Fields("Escompte").Value = rstPiece.Fields("Escompte").Value
370: rstCopiePiece.Fields("Prix_net").Value = rstPiece.Fields("Prix_net").Value
375: rstCopiePiece.Fields("IDFRS").Value = rstPiece.Fields("IDFRS").Value
										
										'Pour le prix total, il faut faire la quantité * prix net * pourcentage de profit
380: rstCopiePiece.Fields("Prix_Total").Value = Conversion_Renamed(CStr(System.Math.Round(CDbl(Replace(rstCopiePiece.Fields("Qté").Value, "*", vbNullString)) * rstCopiePiece.Fields("Prix_net").Value * CSng(sProfit), 2)), ModuleMain.enumConvert.MODE_PAS_FORMAT)
										
385: rstCopiePiece.Fields("Profit_Pourcent").Value = rstPiece.Fields("Profit_Pourcent").Value
										
										'Pour le profit, c'est le prix total - (prix net * quantité)
390: rstCopiePiece.Fields("Profit_argent").Value = Conversion_Renamed(CStr(System.Math.Round(rstCopiePiece.Fields("Prix_total").Value - (rstCopiePiece.Fields("Prix_net").Value * CDbl(Replace(rstCopiePiece.Fields("Qté").Value, "*", vbNullString))), 2)), ModuleMain.enumConvert.MODE_PAS_FORMAT)
										
395: rstCopiePiece.Fields("SousSection").Value = rstPiece.Fields("SousSection").Value
400: rstCopiePiece.Fields("OrdreSection").Value = rstPiece.Fields("OrdreSection").Value
405: rstCopiePiece.Fields("NuméroLigne").Value = rstPiece.Fields("NuméroLigne").Value + 1
410: rstCopiePiece.Fields("PrixOrigine").Value = rstPiece.Fields("PrixOrigine").Value
415: rstCopiePiece.Fields("Type").Value = rstPiece.Fields("Type").Value
420: rstCopiePiece.Fields("Visible").Value = rstPiece.Fields("Visible").Value
425: rstCopiePiece.Fields("Commandé").Value = True
430: rstCopiePiece.Fields("Quoté").Value = rstPiece.Fields("Quoté").Value
435: rstCopiePiece.Fields("Recu").Value = False
440: rstCopiePiece.Fields("Retour").Value = False
445: rstCopiePiece.Fields("NoRetour").Value = vbNullString
450: rstCopiePiece.Fields("CommandeAnnulée").Value = False
455: rstCopiePiece.Fields("DateRéception").Value = vbNullString
465: rstCopiePiece.Fields("Facturation").Value = rstPiece.Fields("Facturation").Value
470: rstCopiePiece.Fields("ID").Value = ""
475: rstCopiePiece.Fields("PieceExtra").Value = rstPiece.Fields("PieceExtra").Value
480: rstCopiePiece.Fields("DateCommande").Value = rstPiece.Fields("DateCommande").Value
485: rstCopiePiece.Fields("DateRequise").Value = rstPiece.Fields("DateRequise").Value
490: rstCopiePiece.Fields("MatérielInutile").Value = False
										
495: Call rstCopiePiece.Update()
										
500: Call rstCopiePiece.Close()
505: 'UPGRADE_NOTE: Object rstCopiePiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
										rstCopiePiece = Nothing
										
510: Call rstPiece.Close()
										
515: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
										Call rstPiece.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = '" & txtnoprojet.Text & "' AND Type = 'M' AND NuméroLigne >= " & lvwProjet.FocusedItem.SubItems.Item(I_COL_MANUFACTURIER).Tag + 1, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
										
520: bSkip = False
										
525: Do While Not rstPiece.EOF
530: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
											If ((rstPiece.Fields("NumItem").Value <> lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text) Or (rstPiece.Fields("Qté").Value <> CDbl(sTotal) - CDbl(sQuantite))) Or bSkip = True Then
535: rstPiece.Fields("NuméroLigne").Value = rstPiece.Fields("NuméroLigne").Value + 1
												
540: Call rstPiece.Update()
545: Else
550: bSkip = True
555: End If
											
560: Call rstPiece.MoveNext()
565: Loop 
										
570: Call rstPiece.Close()
										
										'Ajout aux modifs
575: Call rstModif.Open("SELECT * FROM GRB_Projet_Modif", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
										
580: Call rstModif.AddNew()
										
585: Call rstEmploye.Open("SELECT noEmploye FROM GRB_Employés WHERE loginname = '" & g_sUserID & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
										
590: rstModif.Fields("Type").Value = "M"
595: rstModif.Fields("IDProjet").Value = txtnoprojet.Text
600: rstModif.Fields("noEmployé").Value = rstEmploye.Fields("noEmploye").Value
605: rstModif.Fields("Date").Value = ConvertDate(Today)
610: rstModif.Fields("Heure").Value = TimeOfDay
615: rstModif.Fields("TypeModif").Value = "RECEPTION"
										
620: Call rstEmploye.Close()
										
625: Call rstModif.Update()
										
630: Call rstModif.Close()
										
635: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
										If UCase(lvwProjet.FocusedItem.SubItems(I_COL_DISTRIBUTEUR).Text) = "SOLUTION GRB INC." Then
640: Call EnleverInventaireProjet(sQuantite)
645: End If
										
650: m_iIndexReception = lvwProjet.FocusedItem.Index
										
655: Call RemplirListViewProjet(txtnoprojet.Text)
660: Else
665: Call MsgBox("La quantité est trop grande!", MsgBoxStyle.OKOnly, "Erreur")
670: End If
675: End If
								
680: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
								rstPiece = Nothing
685: 'UPGRADE_NOTE: Object rstModif may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
								rstModif = Nothing
690: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
								rstEmploye = Nothing
695: Else
700: Call MsgBox("La quantité doit être plus grande que 0!", MsgBoxStyle.OKOnly, "Erreur")
705: End If
710: Else
715: Call MsgBox("Quantité non numérique!", MsgBoxStyle.OKOnly, "Erreur")
720: End If
725: End If
730: End If
735: Else
740: Call MsgBox("Ce projet est en modification par " & rstProjet.Fields("Par").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
745: End If
			
750: Call rstProjet.Close()
755: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstProjet = Nothing
760: End If
		
765: Exit Sub
		
AfficherErreur: 
		
770: Call AfficherErreur("frmReceptionMec", "Reception", Err, Erl())
	End Sub
	
	Private Sub ReceptionAchat()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPiece As ADODB.Recordset
15: Dim rstCopiePiece As ADODB.Recordset
20: Dim rstAchat As ADODB.Recordset
25: Dim sQuantite As String
30: Dim sIDAchat As String
35: Dim sTotal As String
40: Dim bSkip As Boolean
45: Dim iIndexAchat As Short
50: Dim iIDFRS As Short
		
		'Si il y a des enregistrements
55: If lvwProjet.Items.Count > 0 Then
60: sIDAchat = VB.Left(txtnoprojet.Text, 9)
65: iIndexAchat = CShort(VB.Right(txtnoprojet.Text, 3))
			
70: rstAchat = New ADODB.Recordset
			
75: Call rstAchat.Open("SELECT Modification, Par FROM GRB_Achat WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
80: If rstAchat.Fields("Modification").Value = False Then
85: If System.Drawing.ColorTranslator.ToOle(lvwProjet.FocusedItem.ForeColor) = COLOR_ORANGE Or System.Drawing.ColorTranslator.ToOle(lvwProjet.FocusedItem.ForeColor) = COLOR_BLEU Then 'COLOR_ORANGE ou bleu
90: sQuantite = InputBox("Quelle est la quantité reçue?")
					
95: sQuantite = Replace(sQuantite, ".", ",")
					
100: If sQuantite <> "" Then
105: If IsNumeric(sQuantite) Then
110: If CDbl(sQuantite) > 0 Then
115: rstPiece = New ADODB.Recordset
								
120: If CDbl(sQuantite) = CDbl(lvwProjet.FocusedItem.Text) Then
125: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
									Call rstPiece.Open("SELECT * FROM GRB_Achat_Pieces WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat & " AND NuméroLigne = " & lvwProjet.FocusedItem.SubItems.Item(I_COL_MANUFACTURIER).Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
									
135: rstPiece.Fields("Recu").Value = True
140: rstPiece.Fields("Commandé").Value = False
									
145: rstPiece.Fields("DateRéception").Value = txtDateReception.Text
									
150: Call rstPiece.Update()
									
155: If (CShort(VB.Right(sIDAchat, 2)) >= 0 And CShort(VB.Right(sIDAchat, 2)) <= 12) Or rstPiece.Fields("IDFRS").Value = 717 Then
160: Call AjouterInventaireAchat(sQuantite)
165: End If
									
170: Call rstPiece.Close()
									
175: m_iIndexReception = lvwProjet.FocusedItem.Index
									
180: Call RemplirListViewAchat(txtnoprojet.Text)
185: Else
190: If CDbl(sQuantite) < CDbl(lvwProjet.FocusedItem.Text) Then
195: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
										Call rstPiece.Open("SELECT * FROM GRB_Achat_Pieces WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat & " AND NuméroLigne = " & lvwProjet.FocusedItem.SubItems.Item(I_COL_MANUFACTURIER).Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
										
200: sTotal = rstPiece.Fields("Qté").Value
										
205: rstPiece.Fields("Qté").Value = sQuantite
										
										'Pour le prix total, il faut faire la quantité * prix net * pourcentage de profit
215: rstPiece.Fields("Prix_Total").Value = Conversion_Renamed(CStr(System.Math.Round(CDbl(Replace(rstPiece.Fields("Qté").Value, "*", vbNullString)) * rstPiece.Fields("Prix_net").Value, 2)), ModuleMain.enumConvert.MODE_PAS_FORMAT)
										
220: rstPiece.Fields("Recu").Value = True
225: rstPiece.Fields("Commandé").Value = False
230: rstPiece.Fields("DateRéception").Value = txtDateReception.Text
										
235: Call rstPiece.Update()
										
240: rstCopiePiece = New ADODB.Recordset
										
245: Call rstCopiePiece.Open("SELECT * FROM GRB_Achat_Pieces", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
										
250: Call rstCopiePiece.AddNew()
										
255: rstCopiePiece.Fields("IDAchat").Value = rstPiece.Fields("IDAchat").Value
260: rstCopiePiece.Fields("IndexAchat").Value = rstPiece.Fields("IndexAchat").Value
265: rstCopiePiece.Fields("PIECE").Value = rstPiece.Fields("PIECE").Value
270: rstCopiePiece.Fields("Qté").Value = CDbl(sTotal) - CDbl(sQuantite)
275: rstCopiePiece.Fields("Desc_FR").Value = rstPiece.Fields("Desc_FR").Value
280: rstCopiePiece.Fields("Desc_EN").Value = rstPiece.Fields("Desc_EN").Value
285: rstCopiePiece.Fields("Manufact").Value = rstPiece.Fields("Manufact").Value
290: rstCopiePiece.Fields("Prix_List").Value = rstPiece.Fields("Prix_List").Value
295: rstCopiePiece.Fields("Escompte").Value = rstPiece.Fields("Escompte").Value
300: rstCopiePiece.Fields("Prix_net").Value = rstPiece.Fields("Prix_net").Value
305: rstCopiePiece.Fields("IDFRS").Value = rstPiece.Fields("IDFRS").Value
										
										'Pour le prix total, il faut faire la quantité * prix net * pourcentage de profit
310: rstCopiePiece.Fields("Prix_Total").Value = Conversion_Renamed(CStr(System.Math.Round(CDbl(Replace(rstCopiePiece.Fields("Qté").Value, "*", vbNullString)) * rstCopiePiece.Fields("Prix_net").Value, 2)), ModuleMain.enumConvert.MODE_PAS_FORMAT)
										
315: rstCopiePiece.Fields("NuméroLigne").Value = rstPiece.Fields("NuméroLigne").Value + 1
320: rstCopiePiece.Fields("Type").Value = rstPiece.Fields("Type").Value
325: rstCopiePiece.Fields("Commandé").Value = True
330: rstCopiePiece.Fields("Recu").Value = False
335: rstCopiePiece.Fields("Retour").Value = False
340: rstCopiePiece.Fields("NoRetour").Value = vbNullString
345: rstCopiePiece.Fields("DateRéception").Value = vbNullString
355: rstCopiePiece.Fields("DateCommande").Value = rstPiece.Fields("DateCommande").Value
360: rstCopiePiece.Fields("DateRequise").Value = rstPiece.Fields("DateRequise").Value
										
365: Call rstCopiePiece.Update()
										
370: Call rstCopiePiece.Close()
375: 'UPGRADE_NOTE: Object rstCopiePiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
										rstCopiePiece = Nothing
										
380: iIDFRS = 717
										
385: Call rstPiece.Close()
										
390: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
										Call rstPiece.Open("SELECT * FROM GRB_Achat_Pieces WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat & " AND NuméroLigne >= " & lvwProjet.FocusedItem.SubItems.Item(I_COL_MANUFACTURIER).Tag + 1, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
										
395: bSkip = False
										
400: Do While Not rstPiece.EOF
405: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
											If ((rstPiece.Fields("PIECE").Value <> lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text) Or (rstPiece.Fields("Qté").Value <> CDbl(sTotal) - CDbl(sQuantite))) Or bSkip = True Then
410: rstPiece.Fields("NuméroLigne").Value = rstPiece.Fields("NuméroLigne").Value + 1
												
415: Call rstPiece.Update()
420: Else
425: bSkip = True
430: End If
											
435: Call rstPiece.MoveNext()
440: Loop 
										
445: Call rstPiece.Close()
										
450: If CShort(VB.Right(sIDAchat, 2)) >= 0 And CShort(VB.Right(sIDAchat, 2)) <= 12 Or iIDFRS = 717 Then
455: Call AjouterInventaireAchat(sQuantite)
460: End If
										
465: m_iIndexReception = lvwProjet.FocusedItem.Index
										
470: Call RemplirListViewAchat(txtnoprojet.Text)
475: Else
480: Call MsgBox("La quantité est trop grande!", MsgBoxStyle.OKOnly, "Erreur")
485: End If
490: End If
								
495: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
								rstPiece = Nothing
500: Else
505: Call MsgBox("La quantité doit être plus grande que 0!", MsgBoxStyle.OKOnly, "Erreur")
510: End If
515: Else
520: Call MsgBox("Quantité non numérique!", MsgBoxStyle.OKOnly, "Erreur")
525: End If
530: End If
535: End If
540: Else
545: Call MsgBox("Ce projet est en modification par " & rstAchat.Fields("Par").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
550: End If
			
555: Call rstAchat.Close()
560: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstAchat = Nothing
565: End If
		
570: Exit Sub
		
AfficherErreur: 
		
575: Call AfficherErreur("frmReceptionMec", "ReceptionAchat", Err, Erl())
	End Sub
	
	Private Sub EnleverInventaireProjet(ByVal sQuantite As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstInventaire As ADODB.Recordset
15: Dim rstPieceFRS As ADODB.Recordset
20: Dim rstProjet As ADODB.Recordset
		
25: If MsgBox("Voulez-vous modifier l'inventaire?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
30: rstInventaire = New ADODB.Recordset
			
35: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Call rstInventaire.Open("SELECT * FROM GRB_InventaireMec WHERE NoItem = '" & Replace(lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
40: If rstInventaire.EOF Then
45: Call rstInventaire.AddNew()
				
50: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				rstInventaire.Fields("NoItem").Value = lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text
55: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				rstInventaire.Fields("Description").Value = lvwProjet.FocusedItem.SubItems(I_COL_DESCRIPTION).Text
60: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				rstInventaire.Fields("Manufacturier").Value = lvwProjet.FocusedItem.SubItems(I_COL_MANUFACTURIER).Text
				
65: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				Call frmChoixQteBoite.Afficher(lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text)
				
70: rstInventaire.Fields("CommandeParBoite").Value = g_bQteBoite
75: rstInventaire.Fields("QteBoite").Value = g_sQteBoite
				
80: rstInventaire.Fields("Commentaires").Value = ""
85: rstInventaire.Fields("QuantitéStock").Value = "0"
				
90: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				Call frmChoixLocalisation.Afficher(ModuleMain.enumCatalogue.MECANIQUE, lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text)
				
95: rstInventaire.Fields("Localisation").Value = g_sLocalisation
100: rstInventaire.Fields("Minimum").Value = False
105: rstInventaire.Fields("QuantitéMinimum").Value = ""
110: rstInventaire.Fields("Commande").Value = ""
115: End If
			
120: rstProjet = New ADODB.Recordset
			
125: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Call rstProjet.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = '" & txtnoprojet.Text & "' AND NuméroLigne = " & lvwProjet.FocusedItem.SubItems.Item(I_COL_MANUFACTURIER).Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
130: If rstInventaire.Fields("CommandeParBoite").Value = True Then
135: rstInventaire.Fields("QuantitéStock").Value = Replace(CStr(CDbl(rstInventaire.Fields("QuantitéStock").Value) - (CDbl(sQuantite) * CDbl(rstInventaire.Fields("QteBoite").Value))), ".", ",")
				
140: If rstProjet.Fields("Prix_List").Value <> "" Then
145: If rstInventaire.Fields("QteBoite").Value <> "" Then
150: rstInventaire.Fields("Prix Liste").Value = Replace(CStr(rstProjet.Fields("Prix_List").Value / rstInventaire.Fields("QteBoite").Value), ".", ",")
155: Else
160: rstInventaire.Fields("Prix Liste").Value = rstProjet.Fields("Prix_List").Value
165: End If
170: Else
175: rstInventaire.Fields("Prix Liste").Value = "0"
180: End If
				
185: rstInventaire.Fields("Escompte").Value = rstProjet.Fields("Escompte").Value
				
190: If rstInventaire.Fields("QteBoite").Value <> "" Then
195: rstInventaire.Fields("Prix net").Value = Replace(CStr(rstProjet.Fields("Prix_Net").Value / rstInventaire.Fields("QteBoite").Value), ".", ",")
200: Else
205: rstInventaire.Fields("Prix net").Value = rstProjet.Fields("Prix_Net").Value
210: End If
215: Else
220: rstInventaire.Fields("QuantitéStock").Value = Replace(CStr(CDbl(rstInventaire.Fields("QuantitéStock").Value) - CDbl(sQuantite)), ".", ",")
				
225: If rstProjet.Fields("Prix_List").Value <> "" Then
230: rstInventaire.Fields("Prix Liste").Value = rstProjet.Fields("Prix_List").Value
235: Else
240: rstInventaire.Fields("Prix Liste").Value = ""
245: End If
				
250: rstInventaire.Fields("Escompte").Value = rstProjet.Fields("Escompte").Value
255: rstInventaire.Fields("Prix net").Value = rstProjet.Fields("Prix_Net").Value
260: End If
			
265: Call rstInventaire.Update()
			
270: rstPieceFRS = New ADODB.Recordset
			
275: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Call rstPieceFRS.Open("SELECT * FROM GRB_PiecesFRS WHERE PIECE = '" & Replace(lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text, "'", "''") & "' AND IDFRS = 717", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
280: If rstPieceFRS.EOF Then
285: Call rstPieceFRS.AddNew()
				
290: rstPieceFRS.Fields("IDFRS").Value = 717
295: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				rstPieceFRS.Fields("PIECE").Value = lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text
300: rstPieceFRS.Fields("PERS_RESS").Value = 901
305: rstPieceFRS.Fields("ENTRER_PAR").Value = g_sInitiale
310: rstPieceFRS.Fields("DeviseMonétaire").Value = "CAN"
315: rstPieceFRS.Fields("Type").Value = "M"
320: End If
			
325: rstPieceFRS.Fields("PRIX_LIST").Value = rstProjet.Fields("Prix_List").Value
330: rstPieceFRS.Fields("ESCOMPTE").Value = rstProjet.Fields("Escompte").Value
335: rstPieceFRS.Fields("PRIX_NET").Value = rstProjet.Fields("Prix_net").Value
340: rstPieceFRS.Fields("DATE").Value = txtDateReception.Text
			
345: Call rstPieceFRS.Update()
			
350: Call rstPieceFRS.Close()
355: 'UPGRADE_NOTE: Object rstPieceFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstPieceFRS = Nothing
			
360: Call rstProjet.Close()
365: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstProjet = Nothing
			
370: If rstInventaire.Fields("CommandeParBoite").Value = True Then
375: sQuantite = Replace(CStr(CDbl(sQuantite) * CDbl(rstInventaire.Fields("QteBoite").Value)), ".", ",")
380: End If
			
385: Call rstInventaire.Close()
390: 'UPGRADE_NOTE: Object rstInventaire may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstInventaire = Nothing
			
395: Call AjouterHistorique(sQuantite)
400: End If
		
405: Exit Sub
		
AfficherErreur: 
		
410: Call AfficherErreur("frmReceptionMec", "EnleverInventaireProjet", Err, Erl())
	End Sub
	
	Private Sub AjouterInventaireAchat(ByVal sQuantite As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstInventaire As ADODB.Recordset
15: Dim rstPieceFRS As ADODB.Recordset
20: Dim rstAchat As ADODB.Recordset
25: Dim sIDAchat As String
30: Dim iIndexAchat As Short
35: Dim iCompteur As Short
		
40: If MsgBox("Voulez-vous modifier l'inventaire?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
45: rstInventaire = New ADODB.Recordset
			
50: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Call rstInventaire.Open("SELECT * FROM GRB_InventaireMec WHERE NoItem = '" & Replace(lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
55: If rstInventaire.EOF Then
60: Call rstInventaire.AddNew()
				
65: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				rstInventaire.Fields("NoItem").Value = lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text
70: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				rstInventaire.Fields("Description").Value = lvwProjet.FocusedItem.SubItems(I_COL_DESCRIPTION).Text
75: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				rstInventaire.Fields("Manufacturier").Value = lvwProjet.FocusedItem.SubItems(I_COL_MANUFACTURIER).Text
				
80: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				Call frmChoixQteBoite.Afficher(lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text)
				
85: rstInventaire.Fields("CommandeParBoite").Value = g_bQteBoite
90: rstInventaire.Fields("QteBoite").Value = g_sQteBoite
				
95: rstInventaire.Fields("Commentaires").Value = ""
100: rstInventaire.Fields("QuantitéStock").Value = "0"
				
105: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				Call frmChoixLocalisation.Afficher(ModuleMain.enumCatalogue.MECANIQUE, lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text)
				
110: rstInventaire.Fields("Localisation").Value = g_sLocalisation
115: rstInventaire.Fields("Minimum").Value = False
120: rstInventaire.Fields("QuantitéMinimum").Value = ""
125: rstInventaire.Fields("Commande").Value = ""
130: End If
			
135: sIDAchat = VB.Left(txtnoprojet.Text, 9)
140: iIndexAchat = CShort(VB.Right(txtnoprojet.Text, 3))
			
145: rstAchat = New ADODB.Recordset
			
150: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Call rstAchat.Open("SELECT * FROM GRB_Achat_Pieces WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat & " AND NuméroLigne = " & lvwProjet.FocusedItem.SubItems.Item(I_COL_MANUFACTURIER).Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
155: If rstInventaire.Fields("CommandeParBoite").Value = True Then
160: If rstAchat.Fields("IDFRS").Value = 717 Then
165: rstInventaire.Fields("QuantitéStock").Value = Replace(CStr(CDbl(rstInventaire.Fields("QuantitéStock").Value) - (CDbl(sQuantite) * CDbl(rstInventaire.Fields("QteBoite").Value))), ".", ",")
170: Else
175: rstInventaire.Fields("QuantitéStock").Value = Replace(CStr(CDbl(rstInventaire.Fields("QuantitéStock").Value) + (CDbl(sQuantite) * CDbl(rstInventaire.Fields("QteBoite").Value))), ".", ",")
180: End If
				
185: If rstAchat.Fields("Prix_List").Value <> "" Then
190: If rstInventaire.Fields("QteBoite").Value <> "" Then
195: rstInventaire.Fields("Prix Liste").Value = Replace(CStr(rstAchat.Fields("Prix_List").Value / rstInventaire.Fields("QteBoite").Value), ".", ",")
200: Else
205: rstInventaire.Fields("Prix Liste").Value = rstAchat.Fields("Prix_List").Value
210: End If
215: Else
220: rstInventaire.Fields("Prix Liste").Value = "0"
225: End If
				
230: rstInventaire.Fields("Escompte").Value = rstAchat.Fields("Escompte").Value
				
235: If rstInventaire.Fields("QteBoite").Value <> "" Then
240: rstInventaire.Fields("Prix net").Value = Replace(CStr(rstAchat.Fields("Prix_Net").Value / rstInventaire.Fields("QteBoite").Value), ".", ",")
245: Else
250: rstInventaire.Fields("Prix net").Value = rstAchat.Fields("Prix_Net").Value
255: End If
260: Else
265: If rstAchat.Fields("IDFRS").Value = 717 Then
270: rstInventaire.Fields("QuantitéStock").Value = Replace(CStr(CDbl(rstInventaire.Fields("QuantitéStock").Value) - CDbl(sQuantite)), ".", ",")
275: Else
280: rstInventaire.Fields("QuantitéStock").Value = Replace(CStr(CDbl(rstInventaire.Fields("QuantitéStock").Value) + CDbl(sQuantite)), ".", ",")
285: End If
				
290: If rstAchat.Fields("Prix_List").Value <> "" Then
295: rstInventaire.Fields("Prix Liste").Value = rstAchat.Fields("Prix_List").Value
300: Else
305: rstInventaire.Fields("Prix Liste").Value = "0"
310: End If
				
315: rstInventaire.Fields("Escompte").Value = rstAchat.Fields("Escompte").Value
320: rstInventaire.Fields("Prix net").Value = rstAchat.Fields("Prix_Net").Value
325: End If
			
330: Call rstInventaire.Update()
			
335: rstPieceFRS = New ADODB.Recordset
			
340: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Call rstPieceFRS.Open("SELECT * FROM GRB_PiecesFRS WHERE PIECE = '" & Replace(lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text, "'", "''") & "' AND IDFRS = 717", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
345: If rstPieceFRS.EOF Then
350: Call rstPieceFRS.AddNew()
				
355: rstPieceFRS.Fields("IDFRS").Value = 717
360: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				rstPieceFRS.Fields("PIECE").Value = lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text
365: rstPieceFRS.Fields("PERS_RESS").Value = 901
370: rstPieceFRS.Fields("ENTRER_PAR").Value = g_sInitiale
375: rstPieceFRS.Fields("DeviseMonétaire").Value = "CAN"
380: rstPieceFRS.Fields("Type").Value = "M"
385: End If
			
390: rstPieceFRS.Fields("PRIX_LIST").Value = rstAchat.Fields("Prix_List").Value
395: rstPieceFRS.Fields("ESCOMPTE").Value = rstAchat.Fields("Escompte").Value
400: rstPieceFRS.Fields("PRIX_NET").Value = rstAchat.Fields("Prix_net").Value
405: rstPieceFRS.Fields("DATE").Value = txtDateReception.Text
			
410: Call rstPieceFRS.Update()
			
415: Call rstPieceFRS.Close()
420: 'UPGRADE_NOTE: Object rstPieceFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstPieceFRS = Nothing
			
425: Call rstAchat.Close()
430: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstAchat = Nothing
			
435: If rstInventaire.Fields("CommandeParBoite").Value = True Then
440: sQuantite = CStr(CDbl(sQuantite) * CDbl(rstInventaire.Fields("QteBoite").Value))
445: End If
			
450: Call rstInventaire.Close()
455: 'UPGRADE_NOTE: Object rstInventaire may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstInventaire = Nothing
			
460: Call AjouterHistorique(sQuantite)
465: End If
		
470: Exit Sub
		
AfficherErreur: 
		
475: Call AfficherErreur("frmReceptionMec", "AjouterInventaireAchat", Err, Erl())
	End Sub
	
	Private Sub AjouterHistorique(ByVal sQuantite As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstHist As ADODB.Recordset
		
15: rstHist = New ADODB.Recordset
		
20: Call rstHist.Open("SELECT * FROM GRB_InventaireMecModif", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: Call rstHist.AddNew()
		
30: rstHist.Fields("Date").Value = txtDateReception.Text
35: rstHist.Fields("IDProjet").Value = txtnoprojet.Text
40: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		rstHist.Fields("NoItem").Value = lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text
		
45: If m_eType = enumType.ACHAT Then
50: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwProjet.FocusedItem.SubItems.Item(I_COL_DISTRIBUTEUR).Tag = 717 Then
55: rstHist.Fields("Quantité").Value = "-" & sQuantite
60: Else
65: rstHist.Fields("Quantité").Value = sQuantite
70: End If
75: Else
80: rstHist.Fields("Quantité").Value = "-" & sQuantite
85: End If
		
90: rstHist.Fields("User").Value = g_sInitiale
		
95: Call rstHist.Update()
		
100: Call rstHist.Close()
105: 'UPGRADE_NOTE: Object rstHist may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstHist = Nothing
		
110: Exit Sub
		
AfficherErreur: 
		
115: Call AfficherErreur("frmReceptionMec", "AjouterHistorique", Err, Erl())
	End Sub
	
	Private Sub SupprimerHistorique(Optional ByVal sQuantite As String = "")
		
5: On Error GoTo AfficherErreur
		
10: Dim rstHist As ADODB.Recordset
		
15: rstHist = New ADODB.Recordset
		
20: If m_eType = enumType.ACHAT Then
25: If sQuantite <> "" Then
30: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwProjet.FocusedItem.SubItems.Item(I_COL_DISTRIBUTEUR).Tag = 717 Then
35: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call rstHist.Open("SELECT * FROM GRB_InventaireMecModif WHERE [Date] = '" & lvwProjet.FocusedItem.SubItems(I_COL_DATE_RECEPTION).Text & "' AND IDProjet = '" & txtnoprojet.Text & "' AND NoItem = '" & Replace(lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text, "'", "''") & "' AND Quantité = '-" & sQuantite & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
40: Else
45: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call rstHist.Open("SELECT * FROM GRB_InventaireMecModif WHERE [Date] = '" & lvwProjet.FocusedItem.SubItems(I_COL_DATE_RECEPTION).Text & "' AND IDProjet = '" & txtnoprojet.Text & "' AND NoItem = '" & Replace(lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text, "'", "''") & "' AND Quantité = '" & sQuantite & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
50: End If
55: Else
60: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwProjet.FocusedItem.SubItems.Item(I_COL_DISTRIBUTEUR).Tag = 717 Then
65: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call rstHist.Open("SELECT * FROM GRB_InventaireMecModif WHERE [Date] = '" & lvwProjet.FocusedItem.SubItems(I_COL_DATE_RECEPTION).Text & "' AND IDProjet = '" & txtnoprojet.Text & "' AND NoItem = '" & Replace(lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text, "'", "''") & "' AND Quantité = '-" & lvwProjet.FocusedItem.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
70: Else
75: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call rstHist.Open("SELECT * FROM GRB_InventaireMecModif WHERE [Date] = '" & lvwProjet.FocusedItem.SubItems(I_COL_DATE_RECEPTION).Text & "' AND IDProjet = '" & txtnoprojet.Text & "' AND NoItem = '" & Replace(lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text, "'", "''") & "' AND Quantité = '" & lvwProjet.FocusedItem.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
80: End If
85: End If
90: Else
95: If sQuantite <> "" Then
100: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				Call rstHist.Open("SELECT * FROM GRB_InventaireMecModif WHERE [Date] = '" & lvwProjet.FocusedItem.SubItems(I_COL_DATE_RECEPTION).Text & "' AND IDProjet = '" & txtnoprojet.Text & "' AND NoItem = '" & Replace(lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text, "'", "''") & "' AND Quantité = '" & "-" & sQuantite & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
105: Else
110: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				Call rstHist.Open("SELECT * FROM GRB_InventaireMecModif WHERE [Date] = '" & lvwProjet.FocusedItem.SubItems(I_COL_DATE_RECEPTION).Text & "' AND IDProjet = '" & txtnoprojet.Text & "' AND NoItem = '" & Replace(lvwProjet.FocusedItem.SubItems(I_COL_PIECE).Text, "'", "''") & "' AND Quantité = '" & "-" & lvwProjet.FocusedItem.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
115: End If
120: End If
		
125: If Not rstHist.EOF Then
130: Call rstHist.Delete()
135: End If
		
140: Call rstHist.Close()
145: 'UPGRADE_NOTE: Object rstHist may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstHist = Nothing
		
150: Exit Sub
		
AfficherErreur: 
		
155: Call AfficherErreur("frmReceptionMec", "SupprimerHistorique", Err, Erl())
	End Sub
	
	Private Sub Cmdfermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cmdfermer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmReceptionMec", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub FrmReceptionMec_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: Call frmChoixProjSoum.Close()
		
20: txtDateReception.Text = ConvertDate(Today)
25: txtDateRequise.Text = ConvertDate(Today)
		
30: If m_sNoProjet <> "" Then
35: cmbType.SelectedIndex = 0
			
40: For iCompteur = 0 To cmbNoProjet.Items.Count - 1
45: If VB6.GetItemString(cmbNoProjet, iCompteur) = m_sNoProjet Then
50: cmbNoProjet.SelectedIndex = iCompteur
					
55: Exit For
60: End If
65: Next 
70: Else
75: If m_sNoAchat <> "" Then
80: cmbType.SelectedIndex = 1
				
85: For iCompteur = 0 To cmbNoProjet.Items.Count - 1
90: If VB6.GetItemString(cmbNoProjet, iCompteur) = m_sNoAchat Then
95: cmbNoProjet.SelectedIndex = iCompteur
						
100: Exit For
105: End If
110: Next 
115: Else
120: cmbType.SelectedIndex = 0
125: End If
130: End If
		
135: Exit Sub
		
AfficherErreur: 
		
140: Call AfficherErreur("frmReceptionMec", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub RemplirComboProjet()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des soumissions
10: Dim rstProjet As ADODB.Recordset
		
		'Il faut vider le combo avant de le remplir
15: Call cmbNoProjet.Items.Clear()
		
		'Ouvre le recordset selon le type
20: rstProjet = New ADODB.Recordset
		
25: Call rstProjet.Open("SELECT IDProjet FROM GRB_ProjetMec ORDER BY IDProjet DESC", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
30: Do While Not rstProjet.EOF
35: Call cmbNoProjet.Items.Add(rstProjet.Fields("IDProjet").Value)
			
40: Call rstProjet.MoveNext()
45: Loop 
		
50: Call rstProjet.Close()
55: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjet = Nothing
		
		'Si le combo n'est pas vide, on sélectionne l'item voulu ou le premier
60: If cmbNoProjet.Items.Count > 0 Then
			'On sélectionne le premier
65: cmbNoProjet.SelectedIndex = 0
70: End If
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmReceptionMec", "RemplirComboProjet", Err, Erl())
	End Sub
	
	Private Sub RemplirComboAchat()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des soumissions
10: Dim rstAchat As ADODB.Recordset
		
		'Il faut vider le combo avant de le remplir
15: Call cmbNoProjet.Items.Clear()
		
		'Ouvre le recordset selon le type
20: rstAchat = New ADODB.Recordset
		
25: Call rstAchat.Open("SELECT IDAchat, IndexAchat FROM GRB_Achat WHERE Type = 'M' ORDER BY IDAchat DESC, IndexAchat DESC", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
30: Do While Not rstAchat.EOF
35: Call cmbNoProjet.Items.Add(rstAchat.Fields("IDAchat").Value & "-" & VB.Right("000" & rstAchat.Fields("IndexAchat").Value, 3))
			
40: Call rstAchat.MoveNext()
45: Loop 
		
50: Call rstAchat.Close()
55: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAchat = Nothing
		
		'Si le combo n'est pas vide, on sélectionne l'item voulu ou le premier
60: If cmbNoProjet.Items.Count > 0 Then
			'On sélectionne le premier
65: cmbNoProjet.SelectedIndex = 0
70: End If
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmReceptionMec", "RemplirComboAchat", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewProjet(ByVal sNoProjet As String)
		
5: On Error GoTo AfficherErreur
		
		'Remplis les pièces de la soumission avec la BD
10: Dim rstProjet As ADODB.Recordset
15: Dim rstSection As ADODB.Recordset
20: Dim rstFRS As ADODB.Recordset
25: Dim itmProjet As System.Windows.Forms.ListViewItem
30: Dim bPremierEnr As Boolean
35: Dim iOrdreSection As Short
40: Dim sSousSection As String
45: Dim lColor As Integer
		
50: Call lvwProjet.Items.Clear()
		
55: bPremierEnr = True
		
60: rstProjet = New ADODB.Recordset
65: rstFRS = New ADODB.Recordset
70: rstSection = New ADODB.Recordset
		
75: Call rstProjet.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = '" & sNoProjet & "' ORDER BY NuméroLigne", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
80: Do While Not rstProjet.EOF
85: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwProjet.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmProjet = lvwProjet.Items.Add()
			
			'Si c'est le premier enregistrement, il faut ajouter la section et la sous-section
90: If bPremierEnr = True Then
95: iOrdreSection = rstProjet.Fields("OrdreSection").Value
100: sSousSection = rstProjet.Fields("SousSection").Value
				
				'Pour avoir le nom de la section
105: Call rstSection.Open("SELECT NomSectionFR FROM GRB_SoumProjSectionMec WHERE IDSection = " & rstProjet.Fields("IDSection").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
				'Ajout du nom de la section
110: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSection.Fields("NomSectionFR").Value) Then
115: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems.Count > I_COL_PIECE Then
						itmProjet.SubItems(I_COL_PIECE).Text = rstSection.Fields("NomSectionFR").Value
					Else
						itmProjet.SubItems.Insert(I_COL_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstSection.Fields("NomSectionFR").Value))
					End If
120: Else
125: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems.Count > I_COL_PIECE Then
						itmProjet.SubItems(I_COL_PIECE).Text = vbNullString
					Else
						itmProjet.SubItems.Insert(I_COL_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
130: End If
				
135: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmProjet.SubItems.Item(I_COL_PIECE).Font = VB6.FontChangeBold(itmProjet.SubItems.Item(I_COL_PIECE).Font, True)
				
140: Call rstSection.Close()
				
145: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwProjet.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmProjet = lvwProjet.Items.Add()
				
				'Ajout du nom de la sous-section
150: If sSousSection = "PAS DE SOUS-SECTION" Then
155: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems.Count > I_COL_DESCRIPTION Then
						itmProjet.SubItems(I_COL_DESCRIPTION).Text = vbNullString
					Else
						itmProjet.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
160: Else
165: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems.Count > I_COL_DESCRIPTION Then
						itmProjet.SubItems(I_COL_DESCRIPTION).Text = sSousSection
					Else
						itmProjet.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sSousSection))
					End If
170: End If
				
				'Le tag ne peut pas être remplis si la colonne est vide
175: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_COL_MANUFACTURIER Then
					itmProjet.SubItems(I_COL_MANUFACTURIER).Text = " "
				Else
					itmProjet.SubItems.Insert(I_COL_MANUFACTURIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
				End If
				
180: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmProjet.SubItems.Item(I_COL_DESCRIPTION).Font = VB6.FontChangeBold(itmProjet.SubItems.Item(I_COL_DESCRIPTION).Font, True)
				
185: itmProjet.Tag = rstProjet.Fields("IDSection").Value
				
190: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwProjet.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmProjet = lvwProjet.Items.Add()
				
195: bPremierEnr = False
200: Else
				'Si c'est pas le premier enregistrement, il faut vérifier avec l'ancienne section
205: If iOrdreSection <> rstProjet.Fields("OrdreSection").Value Then
210: iOrdreSection = rstProjet.Fields("OrdreSection").Value
					
215: Call rstSection.Open("SELECT NomSectionFR FROM GRB_SoumProjSectionMec WHERE IDSection = " & rstProjet.Fields("IDSection").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
220: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstSection.Fields("NomSectionFR").Value) Then
225: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmProjet.SubItems.Count > I_COL_PIECE Then
							itmProjet.SubItems(I_COL_PIECE).Text = rstSection.Fields("NomSectionFR").Value
						Else
							itmProjet.SubItems.Insert(I_COL_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstSection.Fields("NomSectionFR").Value))
						End If
230: Else
235: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmProjet.SubItems.Count > I_COL_PIECE Then
							itmProjet.SubItems(I_COL_PIECE).Text = vbNullString
						Else
							itmProjet.SubItems.Insert(I_COL_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
						End If
240: End If
					
245: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmProjet.SubItems.Item(I_COL_PIECE).Font = VB6.FontChangeBold(itmProjet.SubItems.Item(I_COL_PIECE).Font, True)
					
250: Call rstSection.Close()
					
255: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwProjet.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					itmProjet = lvwProjet.Items.Add()
					
260: sSousSection = rstProjet.Fields("SousSection").Value
					
265: If sSousSection = "PAS DE SOUS-SECTION" Then
270: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmProjet.SubItems.Count > I_COL_DESCRIPTION Then
							itmProjet.SubItems(I_COL_DESCRIPTION).Text = vbNullString
						Else
							itmProjet.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
						End If
275: Else
280: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmProjet.SubItems.Count > I_COL_DESCRIPTION Then
							itmProjet.SubItems(I_COL_DESCRIPTION).Text = rstProjet.Fields("SousSection").Value
						Else
							itmProjet.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("SousSection").Value))
						End If
285: End If
					
					'Le tag ne peut pas être remplis si la colonne est vide
290: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems.Count > I_COL_MANUFACTURIER Then
						itmProjet.SubItems(I_COL_MANUFACTURIER).Text = " "
					Else
						itmProjet.SubItems.Insert(I_COL_MANUFACTURIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
					End If
					
295: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmProjet.SubItems.Item(I_COL_DESCRIPTION).Font = VB6.FontChangeBold(itmProjet.SubItems.Item(I_COL_DESCRIPTION).Font, True)
					
300: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwProjet.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					itmProjet = lvwProjet.Items.Add()
305: Else
					'il faut vérifier avec l'ancienne sous-section
310: If sSousSection <> rstProjet.Fields("SousSection").Value Then
315: sSousSection = rstProjet.Fields("SousSection").Value
						
320: If sSousSection = "PAS DE SOUS-SECTION" Then
325: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If itmProjet.SubItems.Count > I_COL_DESCRIPTION Then
								itmProjet.SubItems(I_COL_DESCRIPTION).Text = vbNullString
							Else
								itmProjet.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
							End If
330: Else
335: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If itmProjet.SubItems.Count > I_COL_DESCRIPTION Then
								itmProjet.SubItems(I_COL_DESCRIPTION).Text = sSousSection
							Else
								itmProjet.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sSousSection))
							End If
340: End If
						
345: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						itmProjet.SubItems.Item(I_COL_DESCRIPTION).Font = VB6.FontChangeBold(itmProjet.SubItems.Item(I_COL_DESCRIPTION).Font, True)
						
						'Le tag ne peut pas être remplis si la colonne est vide
350: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmProjet.SubItems.Count > I_COL_MANUFACTURIER Then
							itmProjet.SubItems(I_COL_MANUFACTURIER).Text = " "
						Else
							itmProjet.SubItems.Insert(I_COL_MANUFACTURIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
						End If
						
355: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwProjet.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						itmProjet = lvwProjet.Items.Add()
360: End If
365: End If
370: End If
			
375: If rstProjet.Fields("Commandé").Value = True Then
380: lColor = COLOR_ORANGE 'COLOR_ORANGE
385: Else
390: If rstProjet.Fields("Recu").Value = True Then
395: lColor = COLOR_GRIS
400: Else
405: If rstProjet.Fields("Retour").Value = True Then
410: lColor = COLOR_ROUGE
415: Else
420: lColor = COLOR_NOIR
425: End If
430: End If
435: End If
			
440: itmProjet.Tag = rstProjet.Fields("IDSection").Value
			
			'Quantité
445: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjet.Fields("Qté").Value) Then
450: itmProjet.Text = rstProjet.Fields("Qté").Value
455: Else
460: itmProjet.Text = vbNullString
465: End If
			
470: itmProjet.ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'Numéro d'item
475: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjet.Fields("NumItem").Value) Then
480: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_COL_PIECE Then
					itmProjet.SubItems(I_COL_PIECE).Text = rstProjet.Fields("NumItem").Value
				Else
					itmProjet.SubItems.Insert(I_COL_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("NumItem").Value))
				End If
485: Else
490: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_COL_PIECE Then
					itmProjet.SubItems(I_COL_PIECE).Text = vbNullString
				Else
					itmProjet.SubItems.Insert(I_COL_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
495: End If
			
500: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmProjet.SubItems.Item(I_COL_PIECE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'On met le nom de la sous-section dans le tag du numéro d'item
505: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmProjet.SubItems.Item(I_COL_PIECE).Tag = rstProjet.Fields("SousSection").Value
			
			'Description en francais
510: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjet.Fields("Desc_FR").Value) Then
515: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_COL_DESCRIPTION Then
					itmProjet.SubItems(I_COL_DESCRIPTION).Text = rstProjet.Fields("Desc_FR").Value
				Else
					itmProjet.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("Desc_FR").Value))
				End If
520: Else
525: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_COL_DESCRIPTION Then
					itmProjet.SubItems(I_COL_DESCRIPTION).Text = vbNullString
				Else
					itmProjet.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
530: End If
			
535: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmProjet.SubItems.Item(I_COL_DESCRIPTION).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'On met la description en anglais dans le tag de la description en francais
540: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjet.Fields("Desc_EN").Value) Then
545: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmProjet.SubItems.Item(I_COL_DESCRIPTION).Tag = rstProjet.Fields("Desc_EN").Value
550: Else
555: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmProjet.SubItems.Item(I_COL_DESCRIPTION).Tag = vbNullString
560: End If
			
			'Fabricant
565: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjet.Fields("Manufact").Value) Then
570: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_COL_MANUFACTURIER Then
					itmProjet.SubItems(I_COL_MANUFACTURIER).Text = rstProjet.Fields("Manufact").Value
				Else
					itmProjet.SubItems.Insert(I_COL_MANUFACTURIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("Manufact").Value))
				End If
575: Else
580: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_COL_MANUFACTURIER Then
					itmProjet.SubItems(I_COL_MANUFACTURIER).Text = vbNullString
				Else
					itmProjet.SubItems.Insert(I_COL_MANUFACTURIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
585: End If
			
590: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmProjet.SubItems.Item(I_COL_MANUFACTURIER).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'On met l'ordre de la section dans le tag du fabricant
595: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmProjet.SubItems.Item(I_COL_MANUFACTURIER).Tag = rstProjet.Fields("NuméroLigne").Value
			
			'Fournisseur
600: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjet.Fields("IDFRS").Value) And rstProjet.Fields("IDFRS").Value > 0 Then
605: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems(I_COL_PIECE).Text <> "Texte" Then
610: Call rstFRS.Open("SELECT NomFournisseur FROM GRB_Fournisseur WHERE IDFRS = " & rstProjet.Fields("IDFRS").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
					'On affiche le nom dans la colonne
615: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems.Count > I_COL_DISTRIBUTEUR Then
						itmProjet.SubItems(I_COL_DISTRIBUTEUR).Text = rstFRS.Fields("NomFournisseur").Value
					Else
						itmProjet.SubItems.Insert(I_COL_DISTRIBUTEUR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstFRS.Fields("NomFournisseur").Value))
					End If
					
620: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmProjet.SubItems.Item(I_COL_DISTRIBUTEUR).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
					
					'On affiche l'Id dans le tag
625: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmProjet.SubItems.Item(I_COL_DISTRIBUTEUR).Tag = rstProjet.Fields("IDFRS").Value
					
630: Call rstFRS.Close()
635: End If
640: Else
645: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_COL_DISTRIBUTEUR Then
					itmProjet.SubItems(I_COL_DISTRIBUTEUR).Text = vbNullString
				Else
					itmProjet.SubItems.Insert(I_COL_DISTRIBUTEUR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
650: End If
			
655: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjet.Fields("DateRéception").Value) Then
660: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_COL_DATE_RECEPTION Then
					itmProjet.SubItems(I_COL_DATE_RECEPTION).Text = rstProjet.Fields("DateRéception").Value
				Else
					itmProjet.SubItems.Insert(I_COL_DATE_RECEPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("DateRéception").Value))
				End If
665: Else
670: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_COL_DATE_RECEPTION Then
					itmProjet.SubItems(I_COL_DATE_RECEPTION).Text = vbNullString
				Else
					itmProjet.SubItems.Insert(I_COL_DATE_RECEPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
675: End If
			
680: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmProjet.SubItems.Item(I_COL_DATE_RECEPTION).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
685: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjet.Fields("DateCommande").Value) Then
690: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_COL_DATE_COMMANDE Then
					itmProjet.SubItems(I_COL_DATE_COMMANDE).Text = rstProjet.Fields("DateCommande").Value
				Else
					itmProjet.SubItems.Insert(I_COL_DATE_COMMANDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("DateCommande").Value))
				End If
695: Else
700: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_COL_DATE_COMMANDE Then
					itmProjet.SubItems(I_COL_DATE_COMMANDE).Text = vbNullString
				Else
					itmProjet.SubItems.Insert(I_COL_DATE_COMMANDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
705: End If
			
710: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmProjet.SubItems.Item(I_COL_DATE_COMMANDE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
715: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjet.Fields("DateRequise").Value) Then
720: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_COL_DATE_REQUISE Then
					itmProjet.SubItems(I_COL_DATE_REQUISE).Text = rstProjet.Fields("DateRequise").Value
				Else
					itmProjet.SubItems.Insert(I_COL_DATE_REQUISE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("DateRequise").Value))
				End If
725: Else
730: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_COL_DATE_REQUISE Then
					itmProjet.SubItems(I_COL_DATE_REQUISE).Text = vbNullString
				Else
					itmProjet.SubItems.Insert(I_COL_DATE_REQUISE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
735: End If
			
740: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmProjet.SubItems.Item(I_COL_DATE_REQUISE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
745: Call rstProjet.MoveNext()
750: Loop 
		
755: Call rstProjet.Close()
760: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjet = Nothing
		
765: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
770: 'UPGRADE_NOTE: Object rstSection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstSection = Nothing
		
775: If m_iIndexReception > 0 Then
780: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwProjet.Items.Item(m_iIndexReception).Selected = True
			
785: Call lvwProjet.Focus()
			
790: 'UPGRADE_WARNING: MSComctlLib.IListItem method lvwProjet.SelectedItem.EnsureVisible has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			Call lvwProjet.FocusedItem.EnsureVisible()
795: End If
		
800: Exit Sub
		
AfficherErreur: 
		
805: Call AfficherErreur("frmReceptionMec", "RemplirListViewProjet", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewAchat(ByVal sNoProjet As String)
		
5: On Error GoTo AfficherErreur
		
		'Remplis les pièces de la soumission avec la BD
10: Dim rstAchat As ADODB.Recordset
15: Dim rstFRS As ADODB.Recordset
20: Dim itmAchat As System.Windows.Forms.ListViewItem
25: Dim lColor As Integer
30: Dim sNoAchat As String
35: Dim iIndexAchat As Short
		
40: sNoAchat = VB.Left(sNoProjet, 9)
		
45: iIndexAchat = CShort(VB.Right(sNoProjet, 3))
		
50: Call lvwProjet.Items.Clear()
		
55: rstAchat = New ADODB.Recordset
60: rstFRS = New ADODB.Recordset
		
65: Call rstAchat.Open("SELECT * FROM GRB_Achat_Pieces WHERE IDAchat = '" & sNoAchat & "' AND IndexAchat = " & VB.Right("000" & iIndexAchat, 3) & " ORDER BY NuméroLigne", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
70: Do While Not rstAchat.EOF
75: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwProjet.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmAchat = lvwProjet.Items.Add()
			
80: If rstAchat.Fields("Commandé").Value = True Then
85: lColor = COLOR_ORANGE 'COLOR_ORANGE
90: Else
95: If rstAchat.Fields("Recu").Value = True Then
100: lColor = COLOR_GRIS
105: Else
110: If rstAchat.Fields("Retour").Value = True Then
115: lColor = COLOR_ROUGE
120: Else
125: lColor = COLOR_NOIR
130: End If
135: End If
140: End If
			
			'Quantité
145: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("Qté").Value) Then
150: itmAchat.Text = rstAchat.Fields("Qté").Value
155: Else
160: itmAchat.Text = vbNullString
165: End If
			
170: itmAchat.ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'Numéro d'item
175: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("PIECE").Value) Then
180: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_PIECE Then
					itmAchat.SubItems(I_COL_PIECE).Text = rstAchat.Fields("PIECE").Value
				Else
					itmAchat.SubItems.Insert(I_COL_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("PIECE").Value))
				End If
185: Else
190: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_PIECE Then
					itmAchat.SubItems(I_COL_PIECE).Text = vbNullString
				Else
					itmAchat.SubItems.Insert(I_COL_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
195: End If
			
200: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_PIECE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'Description en francais
205: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("Desc_FR").Value) Then
210: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_DESCRIPTION Then
					itmAchat.SubItems(I_COL_DESCRIPTION).Text = rstAchat.Fields("Desc_FR").Value
				Else
					itmAchat.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("Desc_FR").Value))
				End If
215: Else
220: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_DESCRIPTION Then
					itmAchat.SubItems(I_COL_DESCRIPTION).Text = vbNullString
				Else
					itmAchat.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
225: End If
			
230: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_DESCRIPTION).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'On met la description en anglais dans le tag de la description en francais
235: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("DESC_EN").Value) Then
240: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_DESCRIPTION).Tag = rstAchat.Fields("Desc_EN").Value
245: Else
250: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_DESCRIPTION).Tag = vbNullString
255: End If
			
			'Fabricant
260: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("Manufact").Value) Then
265: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_MANUFACTURIER Then
					itmAchat.SubItems(I_COL_MANUFACTURIER).Text = rstAchat.Fields("Manufact").Value
				Else
					itmAchat.SubItems.Insert(I_COL_MANUFACTURIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("Manufact").Value))
				End If
270: Else
275: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_MANUFACTURIER Then
					itmAchat.SubItems(I_COL_MANUFACTURIER).Text = vbNullString
				Else
					itmAchat.SubItems.Insert(I_COL_MANUFACTURIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
280: End If
			
285: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_MANUFACTURIER).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'On met l'ordre de la section dans le tag du fabricant
290: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_MANUFACTURIER).Tag = rstAchat.Fields("NuméroLigne").Value
			
			'Fournisseur
295: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("IDFRS").Value) And rstAchat.Fields("IDFRS").Value > 0 Then
300: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems(I_COL_PIECE).Text <> "Texte" Then
305: Call rstFRS.Open("SELECT NomFournisseur FROM GRB_Fournisseur WHERE IDFRS = " & rstAchat.Fields("IDFRS").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
					'On affiche le nom dans la colonne
310: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_DISTRIBUTEUR Then
						itmAchat.SubItems(I_COL_DISTRIBUTEUR).Text = rstFRS.Fields("NomFournisseur").Value
					Else
						itmAchat.SubItems.Insert(I_COL_DISTRIBUTEUR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstFRS.Fields("NomFournisseur").Value))
					End If
					
315: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat.SubItems.Item(I_COL_DISTRIBUTEUR).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
					
					'On affiche l'Id dans le tag
320: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat.SubItems.Item(I_COL_DISTRIBUTEUR).Tag = rstAchat.Fields("IDFRS").Value
					
325: Call rstFRS.Close()
330: End If
335: Else
340: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_DISTRIBUTEUR Then
					itmAchat.SubItems(I_COL_DISTRIBUTEUR).Text = vbNullString
				Else
					itmAchat.SubItems.Insert(I_COL_DISTRIBUTEUR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
345: End If
			
350: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("DateRéception").Value) Then
355: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_DATE_RECEPTION Then
					itmAchat.SubItems(I_COL_DATE_RECEPTION).Text = rstAchat.Fields("DateRéception").Value
				Else
					itmAchat.SubItems.Insert(I_COL_DATE_RECEPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("DateRéception").Value))
				End If
360: Else
365: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_DATE_RECEPTION Then
					itmAchat.SubItems(I_COL_DATE_RECEPTION).Text = vbNullString
				Else
					itmAchat.SubItems.Insert(I_COL_DATE_RECEPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
370: End If
			
375: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_DATE_RECEPTION).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
380: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("DateCommande").Value) Then
385: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_DATE_COMMANDE Then
					itmAchat.SubItems(I_COL_DATE_COMMANDE).Text = rstAchat.Fields("DateCommande").Value
				Else
					itmAchat.SubItems.Insert(I_COL_DATE_COMMANDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("DateCommande").Value))
				End If
390: Else
395: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_DATE_COMMANDE Then
					itmAchat.SubItems(I_COL_DATE_COMMANDE).Text = vbNullString
				Else
					itmAchat.SubItems.Insert(I_COL_DATE_COMMANDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
400: End If
			
405: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_DATE_COMMANDE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
410: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("DateRequise").Value) Then
415: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_DATE_REQUISE Then
					itmAchat.SubItems(I_COL_DATE_REQUISE).Text = rstAchat.Fields("DateRequise").Value
				Else
					itmAchat.SubItems.Insert(I_COL_DATE_REQUISE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("DateRequise").Value))
				End If
420: Else
425: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_DATE_REQUISE Then
					itmAchat.SubItems(I_COL_DATE_REQUISE).Text = vbNullString
				Else
					itmAchat.SubItems.Insert(I_COL_DATE_REQUISE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
430: End If
			
435: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_DATE_REQUISE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
440: Call rstAchat.MoveNext()
445: Loop 
		
450: Call rstAchat.Close()
455: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAchat = Nothing
		
460: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
		
465: If m_iIndexReception > 0 Then
470: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwProjet.Items.Item(m_iIndexReception).Selected = True
			
475: Call lvwProjet.Focus()
			
480: 'UPGRADE_WARNING: MSComctlLib.IListItem method lvwProjet.SelectedItem.EnsureVisible has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			Call lvwProjet.FocusedItem.EnsureVisible()
485: End If
		
490: Exit Sub
		
AfficherErreur: 
		
495: Call AfficherErreur("frmReceptionMec", "RemplirListViewAchat", Err, Erl())
	End Sub
	
	'UPGRADE_ISSUE: MSComctlLib.ListView event lvwProjet.ItemClick was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub lvwProjet_ItemClick(ByVal Item As System.Windows.Forms.ListViewItem)
		
5: On Error GoTo AfficherErreur
		
10: Call VerifierBoutonAnnuler()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmReceptionMec", "lvwProjet_ItemClick", Err, Erl())
	End Sub
	
	Private Sub VerifierBoutonAnnuler()
		
5: On Error GoTo AfficherErreur
		
10: If lvwProjet.Items.Count > 0 Then
15: If System.Drawing.ColorTranslator.ToOle(lvwProjet.FocusedItem.ForeColor) = COLOR_GRIS Or System.Drawing.ColorTranslator.ToOle(lvwProjet.FocusedItem.ForeColor) = COLOR_BLEU Then 'Gris ou bleu
20: cmdAnnuler.Enabled = True
25: Else
30: cmdAnnuler.Enabled = False
35: End If
40: Else
45: cmdAnnuler.Enabled = False
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmReceptionMec", "VerifierBoutonAnnuler", Err, Erl())
	End Sub
	
	Public Sub Afficher(ByVal sUserID As String)
		
5: On Error GoTo AfficherErreur
		
10: m_sUserID = sUserID
		
15: Call Me.Show()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmReceptionMec", "Afficher", Err, Erl())
	End Sub
	
	Public Sub AfficherProjet(ByVal sUserID As String, ByVal sNoProjet As String)
		
5: On Error GoTo AfficherErreur
		
10: m_sUserID = sUserID
		
15: m_sNoProjet = sNoProjet
		
20: Call Me.ShowDialog()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmReceptionMec", "AfficherProjet", Err, Erl())
	End Sub
	
	Public Sub AfficherAchat(ByVal sUserID As String, ByVal sNoAchat As String)
		
5: On Error GoTo AfficherErreur
		
10: m_sUserID = sUserID
		
15: m_sNoAchat = sNoAchat
		
20: Call Me.ShowDialog()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmReceptionMec", "AfficherAchat", Err, Erl())
	End Sub
	
	
	Private Sub lvwProjet_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lvwProjet.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: If KeyCode = System.Windows.Forms.Keys.Return Then
15: If m_eType = enumType.PROJET Then
20: Call ReceptionProjet()
25: Else
30: Call ReceptionAchat()
35: End If
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmReceptionMec", "lvwProjet_KeyDown", Err, Erl())
	End Sub
	
	Private Sub mvwDateRequise_DateClick(ByVal eventSender As System.Object, ByVal eventArgs As AxMSComCtl2.DMonthViewEvents_DateClickEvent) Handles mvwDateRequise.DateClick
		
5: On Error GoTo AfficherErreur
		
10: txtDateRequise.Text = ConvertDate(eventArgs.DateClicked)
		
		'Enlever le calendrier
15: mvwDateRequise.Visible = False
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmReceptionMec", "mvwDateRequise_DateClick", Err, Erl())
	End Sub
	
	Private Sub mvwDateRequise_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mvwDateRequise.Leave
		
5: On Error GoTo AfficherErreur
		
10: mvwDateRequise.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmReceptionMec", "mvwDateRequise_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mvwReception_DateClick(ByVal eventSender As System.Object, ByVal eventArgs As AxMSComCtl2.DMonthViewEvents_DateClickEvent) Handles mvwReception.DateClick
		
5: On Error GoTo AfficherErreur
		
10: txtDateReception.Text = ConvertDate(eventArgs.DateClicked)
		
		'Enlever le calendrier
15: mvwReception.Visible = False
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmReceptionMec", "mvwReception_DateClick", Err, Erl())
	End Sub
	
	Private Sub mvwReception_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mvwReception.Leave
		
5: On Error GoTo AfficherErreur
		
10: mvwReception.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmReceptionMec", "mvwReception_LostFocus", Err, Erl())
	End Sub
	
	Private Sub FrmReceptionMec_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Click
		
5: On Error GoTo AfficherErreur
		
10: mvwReception.Visible = False
15: mvwDateRequise.Visible = False
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmReceptionMec", "Form_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDate.Click
		
5: On Error GoTo AfficherErreur
		
		'Ouverture du calendrier
10: If txtDateReception.Text <> vbNullString Then
15: mvwReception.Value = CDate(txtDateReception.Text)
20: Else
25: mvwReception.Value = Today
35: End If
		
40: mvwReception.Visible = True
		
45: Call mvwReception.Focus()
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmReceptionMec", "cmdDate_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbType.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbType_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbType.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: If cmbType.SelectedIndex = 0 Then
15: m_eType = enumType.PROJET
			
20: Call RemplirComboProjet()
25: Else
30: m_eType = enumType.ACHAT
			
35: Call RemplirComboAchat()
40: End If
		
45: If fraPiecesNonRecues.Visible = True Then
50: If m_eType = enumType.ACHAT Then
55: chkProjetAchat.Text = "No achat : "
60: Else
65: chkProjetAchat.Text = "No projet : "
70: End If
75: End If
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmReceptionMec", "cmbType_Click", Err, Erl())
	End Sub
	
	Private Sub cmdImprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImprimer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call ImprimerReception()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmReceptionMec", "cmdImprimer_Click", Err, Erl())
	End Sub
	
	Private Sub ImprimerReception()
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.ACHAT Then
15: Call frmChoixDateImpressionReception.Afficher(txtnoprojet.Text, ModuleMain.enumCatalogue.MECANIQUE, enumType.ACHAT)
20: Else
25: Call frmChoixDateImpressionReception.Afficher(txtnoprojet.Text, ModuleMain.enumCatalogue.MECANIQUE, enumType.PROJET)
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmReceptionMec", "ImprimerReception", Err, Erl())
	End Sub
	
	Private Sub FrmReceptionMec_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'CTRL-I pour imprimer
		
5: On Error GoTo AfficherErreur
		
10: If Shift = VB6.ShiftConstants.CtrlMask Then
15: If KeyCode = System.Windows.Forms.Keys.I Then
20: Call ImprimerReception()
25: End If
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmReceptionMec", "Form_KeyDown", Err, Erl())
	End Sub
End Class