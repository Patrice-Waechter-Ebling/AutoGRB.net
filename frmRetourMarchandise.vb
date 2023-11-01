Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmRetourMarchandise
	Inherits System.Windows.Forms.Form
	
	'Index des colonnes de lvwSoumission
	Private Const I_COL_SOUM_QUANTITE As Short = 0
	Private Const I_COL_SOUM_PIECE As Short = 1
	Private Const I_COL_SOUM_DESCR As Short = 2
	Private Const I_COL_SOUM_MANUFACT As Short = 3
	Private Const I_COL_SOUM_DISTRIB As Short = 4
	Private Const I_COL_SOUM_NO_RETOUR As Short = 5
	Private Const I_COL_SOUM_DATE As Short = 6
	
	Private Enum enumTypeRetour
		PROJET = 0
		ACHAT = 1
	End Enum
	
	Private m_sUserID As String
	
	'Pour l'impression
	Public m_bAnnuleImpression As Boolean
	Public m_eTypeImpression As frmChoixImpressionRetourMarchandise.enumImpressionRetour
	
	Private m_eTypeRetour As enumTypeRetour
	
	Public Sub Afficher(ByVal sNoProjet As String, ByVal sUserID As String)
		
5: On Error GoTo AfficherErreur
		
10: m_eTypeRetour = enumTypeRetour.PROJET
		
15: m_sUserID = sUserID
		
20: Call RemplirComboProjetElec()
25: Call RemplirComboProjetMec()
		
30: Call NouveauRetour(sNoProjet)
		
35: Call Me.ShowDialog()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmRetourMarchandise", "Afficher", Err, Erl())
	End Sub
	
	Public Sub AfficherAchat(ByVal sNoAchat As String, ByVal iIndexAchat As Short, ByVal sUserID As String)
		
5: On Error GoTo AfficherErreur
		
10: m_eTypeRetour = enumTypeRetour.ACHAT
		
15: m_sUserID = sUserID
		
20: Call RemplirComboAchats()
		
25: Call NouveauRetourAchat(sNoAchat, iIndexAchat)
		
30: Call Me.ShowDialog()
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmRetourMarchandise", "AfficherAchat", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbNoProjet.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbNoProjet_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbNoProjet.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: txtnoprojet.Text = cmbNoProjet.Text
		
20: If m_eTypeRetour = enumTypeRetour.ACHAT Then
			'Rempli les valeurs de l'achat sélectionné
25: Call RemplirListViewAchat()
30: Else
			'Rempli les valeurs du projet sélectionné
35: Call RemplirListViewProjet()
40: End If
		
45: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmRetourMarchandise", "cmbNoProjet_Click", Err, Erl())
	End Sub
	
	Private Sub cmdImprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImprimer.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim bChecked As Boolean
20: Dim rstProjet As ADODB.Recordset
25: Dim bRetourPermis As Boolean
		
30: If cmbNoProjet.SelectedIndex > -1 Then
35: rstProjet = New ADODB.Recordset
			
40: If m_eTypeRetour = enumTypeRetour.PROJET Then
45: If VB6.GetItemData(cmbNoProjet, cmbNoProjet.SelectedIndex) = 0 Then
50: Call rstProjet.Open("SELECT Modification, Par FROM GRB_ProjetElec WHERE IDProjet = '" & VB.Right(txtnoprojet.Text, Len(txtnoprojet.Text) - 1) & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
55: Else
60: Call rstProjet.Open("SELECT Modification, Par FROM GRB_ProjetMec WHERE IDProjet = '" & VB.Right(txtnoprojet.Text, Len(txtnoprojet.Text) - 1) & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
65: End If
				
70: If rstProjet.Fields("Modification").Value = False Then
75: bRetourPermis = True
80: Else
85: bRetourPermis = False
90: End If
				
95: Call rstProjet.Close()
100: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstProjet = Nothing
105: Else
110: bRetourPermis = True
115: End If
			
120: If bRetourPermis = True Then
125: For iCompteur = 1 To lvwProjet.Items.Count
130: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvwProjet.Items.Item(iCompteur).Checked = True Then
135: bChecked = True
						
140: Exit For
145: End If
150: Next 
				
155: If bChecked = True Then
160: Call OuvrirForm(frmChoixImpressionRetourMarchandise, True)
					
165: If m_bAnnuleImpression = False Then
170: If m_eTypeImpression = frmChoixImpressionRetourMarchandise.enumImpressionRetour.MODE_DEMANDE_RETOUR Then
175: Call ImprimerDemandeRetour()
180: Else
185: Call ImprimerRetour()
190: End If
195: End If
200: End If
205: Else
210: Call MsgBox("Ce projet est en modification par " & rstProjet.Fields("Par").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
215: End If
220: Else
225: Call MsgBox("Vous devez choisir un numéro de retour!", MsgBoxStyle.OKOnly, "Erreur")
230: End If
		
235: Exit Sub
		
AfficherErreur: 
		
240: Call AfficherErreur("frmRetourMarchandise", "cmdImprimer_Click", Err, Erl())
	End Sub
	
	Private Sub ImprimerRetour()
		
5: On Error GoTo AfficherErreur
		
10: Dim collPiece As Collection
15: Dim collNoLigne As Collection
20: Dim iCompteur As Short
25: Dim sNoBC As String
		
30: sNoBC = InputBox("Quel est le numéro du retour?",  , txtnoprojet.Text)
		
35: If sNoBC <> vbNullString Then
40: collPiece = New Collection
45: collNoLigne = New Collection
			
50: For iCompteur = 1 To lvwProjet.Items.Count
55: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwProjet.Items.Item(iCompteur).Checked = True Then
60: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwProjet.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call collPiece.Add(lvwProjet.Items.Item(iCompteur).SubItems(I_COL_SOUM_PIECE).Text)
65: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call collNoLigne.Add(lvwProjet.Items.Item(iCompteur).Tag)
70: End If
75: Next 
			
80: If m_eTypeRetour = enumTypeRetour.ACHAT Then
85: Call frmBonCommande.AfficherFormRetourMarchandiseAchat(Replace(Trim(VB.Left(txtnoprojet.Text, InStrRev(txtnoprojet.Text, "-") - 1)), "R", ""), CShort(VB.Right(txtnoprojet.Text, 3)), sNoBC, collPiece, collNoLigne, m_sUserID, frmChoixImpressionRetourMarchandise.enumImpressionRetour.MODE_RETOUR)
90: Else
95: Call frmBonCommande.AfficherFormRetourMarchandiseProjet(txtnoprojet.Text, sNoBC, collPiece, collNoLigne, m_sUserID, frmChoixImpressionRetourMarchandise.enumImpressionRetour.MODE_RETOUR)
100: End If
105: End If
		
110: Exit Sub
		
AfficherErreur: 
		
115: Call AfficherErreur("frmRetourMarchandise", "ImprimerRetour", Err, Erl())
	End Sub
	
	Private Sub ImprimerDemandeRetour()
		
5: On Error GoTo AfficherErreur
		
10: Dim collPiece As Collection
15: Dim collNoLigne As Collection
20: Dim iCompteur As Short
25: Dim sNoBC As String
		
30: sNoBC = InputBox("Quel est le numéro de la demande de retour?",  , txtnoprojet.Text)
		
35: If sNoBC <> vbNullString Then
40: collPiece = New Collection
45: collNoLigne = New Collection
			
50: For iCompteur = 1 To lvwProjet.Items.Count
55: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwProjet.Items.Item(iCompteur).Checked = True Then
60: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwProjet.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call collPiece.Add(lvwProjet.Items.Item(iCompteur).SubItems(I_COL_SOUM_PIECE).Text)
65: 'UPGRADE_WARNING: Lower bound of collection lvwProjet.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call collNoLigne.Add(lvwProjet.Items.Item(iCompteur).Tag)
70: End If
75: Next 
			
80: If m_eTypeRetour = enumTypeRetour.ACHAT Then
85: Call frmBonCommande.AfficherFormRetourMarchandiseAchat(Trim(Replace(VB.Left(txtnoprojet.Text, InStrRev(txtnoprojet.Text, "-") - 1), "R", "")), CShort(VB.Right(txtnoprojet.Text, 3)), sNoBC, collPiece, collNoLigne, m_sUserID, frmChoixImpressionRetourMarchandise.enumImpressionRetour.MODE_DEMANDE_RETOUR)
90: Else
95: Call frmBonCommande.AfficherFormRetourMarchandiseProjet(txtnoprojet.Text, sNoBC, collPiece, collNoLigne, m_sUserID, frmChoixImpressionRetourMarchandise.enumImpressionRetour.MODE_DEMANDE_RETOUR)
100: End If
105: End If
		
110: Exit Sub
		
AfficherErreur: 
		
115: Call AfficherErreur("frmRetourMarchandise", "ImprimerDemandeRetour", Err, Erl())
	End Sub
	
	Private Sub NouveauRetour(ByVal sNoProjet As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjet As ADODB.Recordset
15: Dim iCompteur As Short
20: Dim bExiste As Boolean
25: Dim eType As ModuleMain.enumCatalogue
		
30: bExiste = False
		
35: If ComboContient(cmbNoProjet, "R" & sNoProjet) = False Then
40: rstProjet = New ADODB.Recordset
			
45: Call rstProjet.Open("SELECT * FROM GRB_ProjetElec WHERE IDProjet = '" & sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
50: If Not rstProjet.EOF Then
55: bExiste = True
				
60: eType = ModuleMain.enumCatalogue.ELECTRIQUE
65: End If
			
70: Call rstProjet.Close()
			
75: If bExiste = False Then
80: Call rstProjet.Open("SELECT * FROM GRB_ProjetMec WHERE IDProjet = '" & sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
85: If Not rstProjet.EOF Then
90: bExiste = True
					
95: eType = ModuleMain.enumCatalogue.MECANIQUE
100: End If
				
105: Call rstProjet.Close()
110: End If
			
115: If bExiste = True Then
120: Call cmbNoProjet.Items.Add("R" & sNoProjet)
				
125: 'UPGRADE_ISSUE: ComboBox property cmbNoProjet.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				VB6.SetItemData(cmbNoProjet, cmbNoProjet.NewIndex, eType)
				
130: cmbNoProjet.SelectedIndex = -1
135: Else
140: Call MsgBox("Projet inexistant!", MsgBoxStyle.OKOnly, "Erreur")
145: End If
			
150: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstProjet = Nothing
155: End If
		
160: For iCompteur = 0 To cmbNoProjet.Items.Count - 1
165: If VB6.GetItemString(cmbNoProjet, iCompteur) = "R" & sNoProjet Then
170: cmbNoProjet.SelectedIndex = iCompteur
				
175: Exit Sub
180: End If
185: Next 
		
190: Exit Sub
		
AfficherErreur: 
		
195: Call AfficherErreur("frmRetourMarchandise", "NouveauRetour", Err, Erl())
	End Sub
	
	Private Sub NouveauRetourAchat(ByVal sNoAchat As String, ByVal iIndexAchat As Short)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstAchat As ADODB.Recordset
15: Dim iCompteur As Short
20: Dim bExiste As Boolean
25: Dim eType As ModuleMain.enumCatalogue
		
30: bExiste = False
		
35: If ComboContient(cmbNoProjet, "R" & sNoAchat & "-" & VB.Right("000" & iIndexAchat, 3)) = False Then
40: rstAchat = New ADODB.Recordset
			
45: Call rstAchat.Open("SELECT * FROM GRB_Achat WHERE IDAchat = '" & sNoAchat & "' AND IndexAchat = " & iIndexAchat, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
50: If Not rstAchat.EOF Then
55: bExiste = True
				
60: If rstAchat.Fields("Type").Value = "M" Then
65: eType = ModuleMain.enumCatalogue.MECANIQUE
70: Else
75: eType = ModuleMain.enumCatalogue.ELECTRIQUE
80: End If
85: End If
			
90: Call rstAchat.Close()
95: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstAchat = Nothing
			
100: If bExiste = True Then
105: Call cmbNoProjet.Items.Add("R" & sNoAchat & "-" & VB.Right("000" & iIndexAchat, 3))
				
110: 'UPGRADE_ISSUE: ComboBox property cmbNoProjet.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				VB6.SetItemData(cmbNoProjet, cmbNoProjet.NewIndex, eType)
115: Else
120: Call MsgBox("Projet inexistant!", MsgBoxStyle.OKOnly, "Erreur")
125: End If
130: End If
		
135: For iCompteur = 0 To cmbNoProjet.Items.Count - 1
140: If VB6.GetItemString(cmbNoProjet, iCompteur) = "R" & sNoAchat & "-" & VB.Right("000" & iIndexAchat, 3) Then
145: cmbNoProjet.SelectedIndex = iCompteur
				
150: Exit For
155: End If
160: Next 
		
		
165: Exit Sub
		
AfficherErreur: 
		
170: Call AfficherErreur("frmRetourMarchandise", "NouveauRetourAchat", Err, Erl())
	End Sub
	
	Private Sub Cmdfermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cmdfermer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmRetourMarchandise", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub RemplirComboProjetElec()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des projets
10: Dim rstProjet As ADODB.Recordset
		
15: rstProjet = New ADODB.Recordset
		
		'Ouvre le recordset selon le type
20: Call rstProjet.Open("SELECT DISTINCT GRB_ProjetElec.IDProjet FROM GRB_ProjetElec INNER JOIN GRB_Projet_Pieces ON GRB_ProjetElec.IDProjet = GRB_Projet_Pieces.IDProjet WHERE Retour = True ORDER BY GRB_ProjetElec.IDProjet", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
25: Do While Not rstProjet.EOF
30: Call cmbNoProjet.Items.Add("R" & rstProjet.Fields("IDProjet").Value)
			
35: 'UPGRADE_ISSUE: ComboBox property cmbNoProjet.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbNoProjet, cmbNoProjet.NewIndex, 0)
			
40: Call rstProjet.MoveNext()
45: Loop 
		
50: Call rstProjet.Close()
55: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjet = Nothing
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmRetourMarchandise", "RemplirComboProjetElec", Err, Erl())
	End Sub
	
	Private Sub RemplirComboProjetMec()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des projets
10: Dim rstProjet As ADODB.Recordset
		
15: rstProjet = New ADODB.Recordset
		
		'Ouvre le recordset selon le type
20: Call rstProjet.Open("SELECT DISTINCT GRB_ProjetMec.IDProjet FROM GRB_ProjetMec INNER JOIN GRB_Projet_Pieces ON GRB_ProjetMec.IDProjet = GRB_Projet_Pieces.IDProjet WHERE Retour = True  ORDER BY GRB_ProjetMec.IDProjet", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
25: Do While Not rstProjet.EOF
30: Call cmbNoProjet.Items.Add("R" & rstProjet.Fields("IDProjet").Value)
			
35: 'UPGRADE_ISSUE: ComboBox property cmbNoProjet.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbNoProjet, cmbNoProjet.NewIndex, 1)
			
40: Call rstProjet.MoveNext()
45: Loop 
		
50: Call rstProjet.Close()
55: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjet = Nothing
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmRetourMarchandise", "RemplirComboProjetMec", Err, Erl())
	End Sub
	
	Private Sub RemplirComboAchats()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des projets
10: Dim rstAchat As ADODB.Recordset
		
15: rstAchat = New ADODB.Recordset
		
		'Ouvre le recordset selon le type
20: Call rstAchat.Open("SELECT DISTINCT GRB_Achat.IDAchat, GRB_Achat.IndexAchat, GRB_Achat.Type FROM GRB_Achat INNER JOIN GRB_Achat_Pieces ON GRB_Achat.IDAchat = GRB_Achat_Pieces.IDAchat AND GRB_Achat.IndexAchat = GRB_Achat_Pieces.IndexAchat WHERE GRB_Achat_Pieces.Retour = True ORDER BY GRB_Achat.IDAchat, GRB_Achat.IndexAchat", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
25: Do While Not rstAchat.EOF
30: Call cmbNoProjet.Items.Add("R" & rstAchat.Fields("IDAchat").Value & "-" & VB.Right("000" & rstAchat.Fields("IndexAchat").Value, 3))
			
35: If rstAchat.Fields("Type").Value = "E" Then
40: 'UPGRADE_ISSUE: ComboBox property cmbNoProjet.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				VB6.SetItemData(cmbNoProjet, cmbNoProjet.NewIndex, 0)
45: Else
50: 'UPGRADE_ISSUE: ComboBox property cmbNoProjet.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				VB6.SetItemData(cmbNoProjet, cmbNoProjet.NewIndex, 1)
55: End If
			
60: Call rstAchat.MoveNext()
65: Loop 
		
70: Call rstAchat.Close()
75: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAchat = Nothing
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmRetourMarchandise", "RemplirComboAchats", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewProjet()
		
5: On Error GoTo AfficherErreur
		
		'Remplis les pièces de la soumission avec la BD
10: Dim rstProjet As ADODB.Recordset
15: Dim rstFRS As ADODB.Recordset
20: Dim itmProjet As System.Windows.Forms.ListViewItem
25: Dim lColor As Integer
		
30: If cmbNoProjet.SelectedIndex <> -1 Then
35: Call lvwProjet.Items.Clear()
			
40: rstProjet = New ADODB.Recordset
45: rstFRS = New ADODB.Recordset
			
50: Call rstProjet.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = '" & VB.Right(txtnoprojet.Text, Len(txtnoprojet.Text) - 1) & "' AND Left$(Qté,1) = '-' ORDER BY NuméroLigne", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
55: Do While Not rstProjet.EOF
60: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwProjet.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmProjet = lvwProjet.Items.Add()
				
65: itmProjet.Checked = False
				
70: If rstProjet.Fields("Retour").Value = True Then
75: lColor = COLOR_ROUGE
80: Else
85: If rstProjet.Fields("Commandé").Value = True Then
90: lColor = COLOR_ORANGE 'COLOR_ORANGE
95: Else
100: If rstProjet.Fields("Recu").Value = True Then
125: lColor = COLOR_GRIS 'Gris
150: Else
155: If rstProjet.Fields("MatérielInutile").Value = True Then
160: lColor = COLOR_BRUN
165: Else
170: lColor = COLOR_NOIR
175: End If
180: End If
185: End If
190: End If
				
				'No Ligne
195: itmProjet.Tag = rstProjet.Fields("NuméroLigne").Value
				
				'Quantité
200: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjet.Fields("Qté").Value) Then
205: itmProjet.Text = rstProjet.Fields("Qté").Value
210: Else
215: itmProjet.Text = vbNullString
220: End If
				
225: itmProjet.ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
				
				'Numéro d'item
230: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjet.Fields("NumItem").Value) Then
235: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems.Count > I_COL_SOUM_PIECE Then
						itmProjet.SubItems(I_COL_SOUM_PIECE).Text = rstProjet.Fields("NumItem").Value
					Else
						itmProjet.SubItems.Insert(I_COL_SOUM_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("NumItem").Value))
					End If
240: Else
245: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems.Count > I_COL_SOUM_PIECE Then
						itmProjet.SubItems(I_COL_SOUM_PIECE).Text = vbNullString
					Else
						itmProjet.SubItems.Insert(I_COL_SOUM_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
250: End If
				
255: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmProjet.SubItems.Item(I_COL_SOUM_PIECE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
				
				'On met le nom de la sous-section dans le tag du numéro d'item
260: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmProjet.SubItems.Item(I_COL_SOUM_PIECE).Tag = rstProjet.Fields("SousSection").Value
				
				'Description en francais
265: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjet.Fields("Desc_FR").Value) Then
270: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems.Count > I_COL_SOUM_DESCR Then
						itmProjet.SubItems(I_COL_SOUM_DESCR).Text = rstProjet.Fields("Desc_FR").Value
					Else
						itmProjet.SubItems.Insert(I_COL_SOUM_DESCR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("Desc_FR").Value))
					End If
275: Else
280: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems.Count > I_COL_SOUM_DESCR Then
						itmProjet.SubItems(I_COL_SOUM_DESCR).Text = vbNullString
					Else
						itmProjet.SubItems.Insert(I_COL_SOUM_DESCR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
285: End If
				
290: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmProjet.SubItems.Item(I_COL_SOUM_DESCR).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
				
				'On met la description en anglais dans le tag de la description en francais
295: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjet.Fields("DESC_EN").Value) Then
300: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmProjet.SubItems.Item(I_COL_SOUM_DESCR).Tag = rstProjet.Fields("Desc_EN").Value
305: Else
310: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmProjet.SubItems.Item(I_COL_SOUM_DESCR).Tag = vbNullString
315: End If
				
				'Fabricant
320: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjet.Fields("Manufact").Value) Then
325: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems.Count > I_COL_SOUM_MANUFACT Then
						itmProjet.SubItems(I_COL_SOUM_MANUFACT).Text = rstProjet.Fields("Manufact").Value
					Else
						itmProjet.SubItems.Insert(I_COL_SOUM_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("Manufact").Value))
					End If
330: Else
335: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems.Count > I_COL_SOUM_MANUFACT Then
						itmProjet.SubItems(I_COL_SOUM_MANUFACT).Text = vbNullString
					Else
						itmProjet.SubItems.Insert(I_COL_SOUM_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
340: End If
				
345: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmProjet.SubItems.Item(I_COL_SOUM_MANUFACT).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
				
				'Fournisseur
350: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjet.Fields("IDFRS").Value) And rstProjet.Fields("IDFRS").Value > 0 Then
355: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems(I_COL_SOUM_PIECE).Text <> "Texte" Then
360: Call rstFRS.Open("SELECT NomFournisseur FROM GRB_Fournisseur WHERE IDFRS = " & rstProjet.Fields("IDFRS").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
						
						'On affiche le nom dans la colonne
365: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmProjet.SubItems.Count > I_COL_SOUM_DISTRIB Then
							itmProjet.SubItems(I_COL_SOUM_DISTRIB).Text = rstFRS.Fields("NomFournisseur").Value
						Else
							itmProjet.SubItems.Insert(I_COL_SOUM_DISTRIB, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstFRS.Fields("NomFournisseur").Value))
						End If
						
370: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						itmProjet.SubItems.Item(I_COL_SOUM_DISTRIB).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
						
						'On affiche l'Id dans le tag
375: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						itmProjet.SubItems.Item(I_COL_SOUM_DISTRIB).Tag = rstProjet.Fields("IDFRS").Value
						
380: Call rstFRS.Close()
385: End If
390: Else
395: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems.Count > I_COL_SOUM_DISTRIB Then
						itmProjet.SubItems(I_COL_SOUM_DISTRIB).Text = vbNullString
					Else
						itmProjet.SubItems.Insert(I_COL_SOUM_DISTRIB, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
400: End If
				
405: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjet.Fields("NoRetour").Value) Then
410: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems.Count > I_COL_SOUM_NO_RETOUR Then
						itmProjet.SubItems(I_COL_SOUM_NO_RETOUR).Text = rstProjet.Fields("NoRetour").Value
					Else
						itmProjet.SubItems.Insert(I_COL_SOUM_NO_RETOUR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("NoRetour").Value))
					End If
415: Else
420: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems.Count > I_COL_SOUM_NO_RETOUR Then
						itmProjet.SubItems(I_COL_SOUM_NO_RETOUR).Text = vbNullString
					Else
						itmProjet.SubItems.Insert(I_COL_SOUM_NO_RETOUR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
425: End If
				
430: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmProjet.SubItems.Item(I_COL_SOUM_NO_RETOUR).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
				
435: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjet.Fields("DateRetour").Value) Then
440: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems.Count > I_COL_SOUM_DATE Then
						itmProjet.SubItems(I_COL_SOUM_DATE).Text = rstProjet.Fields("DateRetour").Value
					Else
						itmProjet.SubItems.Insert(I_COL_SOUM_DATE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("DateRetour").Value))
					End If
445: Else
450: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmProjet.SubItems.Count > I_COL_SOUM_DATE Then
						itmProjet.SubItems(I_COL_SOUM_DATE).Text = vbNullString
					Else
						itmProjet.SubItems.Insert(I_COL_SOUM_DATE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
455: End If
				
460: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmProjet.SubItems.Item(I_COL_SOUM_DATE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
				
465: Call rstProjet.MoveNext()
470: Loop 
			
475: Call rstProjet.Close()
480: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstProjet = Nothing
			
485: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstFRS = Nothing
490: End If
		
495: Exit Sub
		
AfficherErreur: 
		
500: Call AfficherErreur("frmRetourMarchandise", "RemplirListViewProjet", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewAchat()
		
5: On Error GoTo AfficherErreur
		
		'Remplis les pièces de la soumission avec la BD
10: Dim rstAchat As ADODB.Recordset
15: Dim rstFRS As ADODB.Recordset
20: Dim itmAchat As System.Windows.Forms.ListViewItem
25: Dim lColor As Integer
		
30: If cmbNoProjet.SelectedIndex <> -1 Then
35: Call lvwProjet.Items.Clear()
			
40: rstAchat = New ADODB.Recordset
45: rstFRS = New ADODB.Recordset
			
50: Call rstAchat.Open("SELECT * FROM GRB_Achat_Pieces WHERE IDAchat = '" & Replace(Trim(VB.Left(txtnoprojet.Text, InStrRev(txtnoprojet.Text, "-") - 1)), "R", "") & "' AND IndexAchat = " & CShort(VB.Right(txtnoprojet.Text, 3)) & " AND Left$(Qté,1) = '-' ORDER BY NuméroLigne", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
55: Do While Not rstAchat.EOF
60: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwProjet.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmAchat = lvwProjet.Items.Add()
				
65: itmAchat.Checked = False
				
70: If rstAchat.Fields("Retour").Value = True Then
75: lColor = COLOR_ROUGE
80: Else
85: If rstAchat.Fields("Commandé").Value = True Then
90: lColor = COLOR_ORANGE 'COLOR_ORANGE
95: End If
100: End If
				
				'No Ligne
105: itmAchat.Tag = rstAchat.Fields("NuméroLigne").Value
				
				'Quantité
110: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstAchat.Fields("Qté").Value) Then
115: itmAchat.Text = rstAchat.Fields("Qté").Value
120: Else
125: itmAchat.Text = vbNullString
130: End If
				
135: itmAchat.ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
				
				'Numéro d'item
140: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstAchat.Fields("PIECE").Value) Then
145: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_SOUM_PIECE Then
						itmAchat.SubItems(I_COL_SOUM_PIECE).Text = rstAchat.Fields("PIECE").Value
					Else
						itmAchat.SubItems.Insert(I_COL_SOUM_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("PIECE").Value))
					End If
150: Else
155: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_SOUM_PIECE Then
						itmAchat.SubItems(I_COL_SOUM_PIECE).Text = vbNullString
					Else
						itmAchat.SubItems.Insert(I_COL_SOUM_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
160: End If
				
165: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_SOUM_PIECE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
				
				'Description en francais
170: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstAchat.Fields("DESC_FR").Value) Then
175: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_SOUM_DESCR Then
						itmAchat.SubItems(I_COL_SOUM_DESCR).Text = rstAchat.Fields("DESC_FR").Value
					Else
						itmAchat.SubItems.Insert(I_COL_SOUM_DESCR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("DESC_FR").Value))
					End If
180: Else
185: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_SOUM_DESCR Then
						itmAchat.SubItems(I_COL_SOUM_DESCR).Text = vbNullString
					Else
						itmAchat.SubItems.Insert(I_COL_SOUM_DESCR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
190: End If
				
195: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_SOUM_DESCR).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
				
				'On met la description en anglais dans le tag de la description en francais
200: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstAchat.Fields("DESC_EN").Value) Then
205: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat.SubItems.Item(I_COL_SOUM_DESCR).Tag = rstAchat.Fields("DESC_EN").Value
210: Else
215: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat.SubItems.Item(I_COL_SOUM_DESCR).Tag = vbNullString
220: End If
				
				'Fabricant
225: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstAchat.Fields("Manufact").Value) Then
230: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_SOUM_MANUFACT Then
						itmAchat.SubItems(I_COL_SOUM_MANUFACT).Text = rstAchat.Fields("Manufact").Value
					Else
						itmAchat.SubItems.Insert(I_COL_SOUM_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("Manufact").Value))
					End If
235: Else
240: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_SOUM_MANUFACT Then
						itmAchat.SubItems(I_COL_SOUM_MANUFACT).Text = vbNullString
					Else
						itmAchat.SubItems.Insert(I_COL_SOUM_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
245: End If
				
250: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_SOUM_MANUFACT).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
				
				'Fournisseur
255: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstAchat.Fields("IDFRS").Value) And rstAchat.Fields("IDFRS").Value > 0 Then
260: Call rstFRS.Open("SELECT NomFournisseur FROM GRB_Fournisseur WHERE IDFRS = " & rstAchat.Fields("IDFRS").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
					'On affiche le nom dans la colonne
265: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_SOUM_DISTRIB Then
						itmAchat.SubItems(I_COL_SOUM_DISTRIB).Text = rstFRS.Fields("NomFournisseur").Value
					Else
						itmAchat.SubItems.Insert(I_COL_SOUM_DISTRIB, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstFRS.Fields("NomFournisseur").Value))
					End If
					
270: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat.SubItems.Item(I_COL_SOUM_DISTRIB).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
					
					'On affiche l'Id dans le tag
275: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat.SubItems.Item(I_COL_SOUM_DISTRIB).Tag = rstAchat.Fields("IDFRS").Value
					
280: Call rstFRS.Close()
285: Else
290: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_SOUM_DISTRIB Then
						itmAchat.SubItems(I_COL_SOUM_DISTRIB).Text = vbNullString
					Else
						itmAchat.SubItems.Insert(I_COL_SOUM_DISTRIB, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
295: End If
				
300: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstAchat.Fields("NoRetour").Value) Then
305: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_SOUM_NO_RETOUR Then
						itmAchat.SubItems(I_COL_SOUM_NO_RETOUR).Text = rstAchat.Fields("NoRetour").Value
					Else
						itmAchat.SubItems.Insert(I_COL_SOUM_NO_RETOUR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("NoRetour").Value))
					End If
310: Else
315: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_SOUM_NO_RETOUR Then
						itmAchat.SubItems(I_COL_SOUM_NO_RETOUR).Text = vbNullString
					Else
						itmAchat.SubItems.Insert(I_COL_SOUM_NO_RETOUR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
320: End If
				
325: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_SOUM_NO_RETOUR).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
				
330: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstAchat.Fields("DateRetour").Value) Then
335: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_SOUM_DATE Then
						itmAchat.SubItems(I_COL_SOUM_DATE).Text = rstAchat.Fields("DateRetour").Value
					Else
						itmAchat.SubItems.Insert(I_COL_SOUM_DATE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("DateRetour").Value))
					End If
340: Else
345: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_SOUM_DATE Then
						itmAchat.SubItems(I_COL_SOUM_DATE).Text = vbNullString
					Else
						itmAchat.SubItems.Insert(I_COL_SOUM_DATE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
350: End If
				
355: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_SOUM_DATE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
				
360: Call rstAchat.MoveNext()
365: Loop 
			
370: Call rstAchat.Close()
375: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstAchat = Nothing
			
380: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstFRS = Nothing
385: End If
		
390: Exit Sub
		
AfficherErreur: 
		
395: Call AfficherErreur("frmRetourMarchandise", "RemplirListViewAchat", Err, Erl())
	End Sub
	
	Public Sub Retour()
		Dim DR_Commande As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstBC As ADODB.Recordset
15: Dim rstBCPiece As ADODB.Recordset
20: Dim rstPiece As ADODB.Recordset
25: Dim rstModif As ADODB.Recordset
30: Dim rstInventaire As ADODB.Recordset
35: Dim rstInvModif As ADODB.Recordset
40: Dim rstEmploye As ADODB.Recordset
45: Dim sWhere As String
50: Dim sWherePiece As String
55: Dim sWhereNoLigne As String
60: Dim bPremier As Boolean
65: Dim bPremierNoLigne As Boolean
70: Dim bRetourFait As Boolean
75: Dim sPiece As String
80: Dim sNoLigne As String
85: Dim sNoRetour As String
		
90: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sNoRetour = DR_Commande.Sections("Section2").Controls("lblNoSoum").Caption
		
95: rstBC = New ADODB.Recordset
100: rstBCPiece = New ADODB.Recordset
105: rstPiece = New ADODB.Recordset
		
110: Call rstBC.Open("SELECT * FROM GRB_BonsCommandes WHERE NoBonCommande = '" & sNoRetour & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Pour chaque enregistrement
115: Call rstBCPiece.Open("SELECT NoItem, NuméroLigne FROM GRB_BonsCommandes_Pieces WHERE NoBonCommande = '" & sNoRetour & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
120: If m_eTypeRetour = enumTypeRetour.ACHAT Then
125: sWhere = "(IDAchat = '" & Replace(Trim(VB.Left(txtnoprojet.Text, InStrRev(txtnoprojet.Text, "-") - 1)), "R", "") & "' AND IndexAchat = " & Int(CDbl(VB.Right(txtnoprojet.Text, 3))) & ")"
			
130: sWherePiece = "PIECE In ("
135: sWhereNoLigne = "NuméroLigne In ("
			
140: bPremier = True
			
145: Do While Not rstBCPiece.EOF
150: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstBCPiece.Fields("NoItem").Value) Then
155: sNoLigne = rstBCPiece.Fields("NuméroLigne").Value
					
160: If bPremier = True Then
165: If InStr(1, sNoLigne, ",") = 0 Then
170: sWherePiece = sWherePiece & "'" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
175: sWhereNoLigne = sWhereNoLigne & rstBCPiece.Fields("NuméroLigne").Value
180: Else
185: bPremierNoLigne = True
							
190: Do While InStr(1, sNoLigne, ",") > 0
195: If bPremierNoLigne = True Then
200: sWherePiece = sWherePiece & "'" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
205: sWhereNoLigne = sWhereNoLigne & VB.Left(sNoLigne, InStr(1, sNoLigne, ",") - 1)
									
210: bPremierNoLigne = False
215: Else
220: sWherePiece = sWherePiece & ", '" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
225: sWhereNoLigne = sWhereNoLigne & ", " & VB.Left(sNoLigne, InStr(1, sNoLigne, ",") - 1)
230: End If
								
235: sNoLigne = VB.Right(sNoLigne, Len(sNoLigne) - (InStr(1, sNoLigne, ",") + 1))
240: Loop 
							
245: If Trim(sNoLigne) <> "" Then
250: sWherePiece = sWherePiece & ", '" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
255: sWhereNoLigne = sWhereNoLigne & ", " & sNoLigne
260: End If
265: End If
						
270: bPremier = False
275: Else
280: If InStr(1, sNoLigne, ",") = 0 Then
285: sWherePiece = sWherePiece & ", '" & rstBCPiece.Fields("NoItem").Value & "'"
290: sWhereNoLigne = sWhereNoLigne & ", " & rstBCPiece.Fields("NuméroLigne").Value
295: Else
300: Do While InStr(1, sNoLigne, ",") > 0
305: sWherePiece = sWherePiece & ", '" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
310: sWhereNoLigne = sWhereNoLigne & ", " & VB.Left(sNoLigne, InStr(1, sNoLigne, ",") - 1)
								
315: sNoLigne = VB.Right(sNoLigne, Len(sNoLigne) - (InStr(1, sNoLigne, ",") + 1))
320: Loop 
							
325: If Trim(sNoLigne) <> "" Then
330: sWherePiece = sWherePiece & ", '" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
335: sWhereNoLigne = sWhereNoLigne & ", " & sNoLigne
340: End If
345: End If
350: End If
355: End If
				
360: Call rstBCPiece.MoveNext()
365: Loop 
			
370: sWherePiece = sWherePiece & ")"
375: sWhereNoLigne = sWhereNoLigne & ")"
			
380: sWhere = sWhere & " AND " & sWherePiece & " AND " & sWhereNoLigne
			
385: Call rstPiece.Open("SELECT * FROM GRB_Achat_Pieces WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
390: Else
395: sWhere = "(IDProjet = '" & VB.Right(txtnoprojet.Text, Len(txtnoprojet.Text) - 1) & "')"
			
400: sWherePiece = "NumItem In ("
405: sWhereNoLigne = "NuméroLigne In ("
			
410: bPremier = True
			
415: Do While Not rstBCPiece.EOF
420: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstBCPiece.Fields("NoItem").Value) Then
425: sNoLigne = rstBCPiece.Fields("NuméroLigne").Value
					
430: If bPremier = True Then
435: If InStr(1, sNoLigne, ",") = 0 Then
440: sWherePiece = sWherePiece & "'" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
445: sWhereNoLigne = sWhereNoLigne & rstBCPiece.Fields("NuméroLigne").Value
450: Else
455: bPremierNoLigne = True
							
460: Do While InStr(1, sNoLigne, ",") > 0
465: If bPremierNoLigne = True Then
470: sWherePiece = sWherePiece & "'" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
475: sWhereNoLigne = sWhereNoLigne & VB.Left(sNoLigne, InStr(1, sNoLigne, ",") - 1)
									
480: bPremierNoLigne = False
485: Else
490: sWherePiece = sWherePiece & ", '" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
495: sWhereNoLigne = sWhereNoLigne & ", " & VB.Left(sNoLigne, InStr(1, sNoLigne, ",") - 1)
500: End If
								
505: sNoLigne = VB.Right(sNoLigne, Len(sNoLigne) - (InStr(1, sNoLigne, ",") + 1))
510: Loop 
							
515: If Trim(sNoLigne) <> "" Then
520: sWherePiece = sWherePiece & ", '" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
525: sWhereNoLigne = sWhereNoLigne & ", " & sNoLigne
530: End If
535: End If
						
540: bPremier = False
545: Else
550: If InStr(1, sNoLigne, ",") = 0 Then
555: sWherePiece = sWherePiece & ", '" & rstBCPiece.Fields("NoItem").Value & "'"
560: sWhereNoLigne = sWhereNoLigne & ", " & rstBCPiece.Fields("NuméroLigne").Value
565: Else
570: Do While InStr(1, sNoLigne, ",") > 0
575: sWherePiece = sWherePiece & ", '" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
580: sWhereNoLigne = sWhereNoLigne & ", " & VB.Left(sNoLigne, InStr(1, sNoLigne, ",") - 1)
								
585: sNoLigne = VB.Right(sNoLigne, Len(sNoLigne) - (InStr(1, sNoLigne, ",") + 1))
590: Loop 
							
595: If Trim(sNoLigne) <> "" Then
600: sWherePiece = sWherePiece & ", '" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
605: sWhereNoLigne = sWhereNoLigne & ", " & sNoLigne
610: End If
615: End If
620: End If
625: End If
				
630: Call rstBCPiece.MoveNext()
635: Loop 
			
640: sWherePiece = sWherePiece & ")"
645: sWhereNoLigne = sWhereNoLigne & ")"
			
650: sWhere = sWhere & " AND " & sWherePiece & " AND " & sWhereNoLigne
			
655: Call rstPiece.Open("SELECT * FROM GRB_Projet_Pieces WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
660: End If
		
665: Call rstBCPiece.Close()
670: 'UPGRADE_NOTE: Object rstBCPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBCPiece = Nothing
		
675: rstInventaire = New ADODB.Recordset
680: rstInvModif = New ADODB.Recordset
		
685: Do While Not rstPiece.EOF
690: Call rstBC.MoveFirst()
			
695: Do While Not rstBC.EOF
700: If rstBC.Fields("NoFournisseur").Value = rstPiece.Fields("IDFRS").Value Then
705: If rstPiece.Fields("Retour").Value = True Then
710: bRetourFait = True
715: Else
720: bRetourFait = False
725: End If
					
730: rstPiece.Fields("DateRetour").Value = txtDateRetour.Text
					
735: rstPiece.Fields("Retour").Value = True
740: rstPiece.Fields("NoRetour").Value = rstBC.Fields("NoBonCommande").Value
					
745: If m_eTypeRetour = enumTypeRetour.PROJET Then
750: rstPiece.Fields("MatérielInutile").Value = False
755: End If
					
760: Call rstPiece.Update()
					
765: If bRetourFait = False Then
770: If rstPiece.Fields("IDFRS").Value = 717 Then
775: If m_eTypeRetour = enumTypeRetour.ACHAT Then
780: sPiece = rstPiece.Fields("PIECE").Value
785: Else
790: sPiece = rstPiece.Fields("NumItem").Value
795: End If
							
800: If MsgBox("Voulez vous modifier l'inventaire pour la pièce " & sPiece & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
805: If VB6.GetItemData(cmbNoProjet, cmbNoProjet.SelectedIndex) = 0 Then
810: Call rstInventaire.Open("SELECT * FROM GRB_InventaireElec WHERE NoItem = '" & Replace(sPiece, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
815: Else
820: Call rstInventaire.Open("SELECT * FROM GRB_InventaireMec WHERE NoItem = '" & Replace(sPiece, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
825: End If
								
830: If rstInventaire.EOF Then
835: Call rstInventaire.AddNew()
									
840: rstInventaire.Fields("NoItem").Value = sPiece
845: rstInventaire.Fields("Description").Value = rstPiece.Fields("Desc_FR").Value
850: rstInventaire.Fields("Manufacturier").Value = rstPiece.Fields("Manufact").Value
									
855: Call frmChoixQteBoite.Afficher(rstPiece.Fields("NumItem").Value)
									
860: rstInventaire.Fields("CommandeParBoite").Value = g_bQteBoite
865: rstInventaire.Fields("QteBoite").Value = g_sQteBoite
									
870: rstInventaire.Fields("QuantitéStock").Value = 0
875: rstInventaire.Fields("Commentaires").Value = ""
									
880: If VB6.GetItemData(cmbNoProjet, cmbNoProjet.SelectedIndex) = 0 Then
885: Call frmChoixLocalisation.Afficher(ModuleMain.enumCatalogue.ELECTRIQUE, rstPiece.Fields("NumItem").Value)
890: Else
895: Call frmChoixLocalisation.Afficher(ModuleMain.enumCatalogue.MECANIQUE, rstPiece.Fields("NumItem").Value)
900: End If
									
905: rstInventaire.Fields("Localisation").Value = g_sLocalisation
910: rstInventaire.Fields("Minimum").Value = False
915: rstInventaire.Fields("QuantitéMinimum").Value = ""
920: rstInventaire.Fields("Commande").Value = ""
925: End If
								
930: If rstInventaire.Fields("CommandeParBoite").Value = True Then
935: rstInventaire.Fields("QuantitéStock").Value = Replace(CStr(CDbl(rstInventaire.Fields("QuantitéStock").Value) + (CDbl(Replace(rstPiece.Fields("Qté").Value, "-", "")) * CDbl(rstInventaire.Fields("QteBoite").Value))), ".", ",")
940: Else
945: rstInventaire.Fields("QuantitéStock").Value = Replace(CStr(CDbl(rstInventaire.Fields("QuantitéStock").Value) + CDbl(Replace(rstPiece.Fields("Qté").Value, "-", ""))), ".", ",")
950: End If
								
955: If rstPiece.Fields("Prix_List").Value = "" Then
960: rstInventaire.Fields("Prix Liste").Value = " "
965: Else
970: rstInventaire.Fields("Prix Liste").Value = rstPiece.Fields("Prix_List").Value
975: End If
								
980: rstInventaire.Fields("Escompte").Value = rstPiece.Fields("Escompte").Value
985: rstInventaire.Fields("Prix net").Value = rstPiece.Fields("Prix_Net").Value
								
990: Call rstInventaire.Update()
								
995: Call rstInventaire.Close()
								
1000: If VB6.GetItemData(cmbNoProjet, cmbNoProjet.SelectedIndex) = 0 Then
1005: Call rstInvModif.Open("SELECT * FROM GRB_InventaireElecModif", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
1010: Else
1015: Call rstInvModif.Open("SELECT * FROM GRB_InventaireMecModif", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
1020: End If
								
1025: Call rstInvModif.AddNew()
								
1030: rstInvModif.Fields("Date").Value = txtDateRetour.Text
1035: rstInvModif.Fields("IDProjet").Value = txtnoprojet.Text
1040: rstInvModif.Fields("NoItem").Value = sPiece
								
1045: rstInvModif.Fields("Quantité").Value = Replace(rstPiece.Fields("Qté").Value, "-", "")
								
1050: rstInvModif.Fields("User").Value = g_sInitiale
								
1055: Call rstInvModif.Update()
								
1060: Call rstInvModif.Close()
1065: End If
1070: End If
1075: End If
					
1080: Exit Do
1085: End If
				
1090: Call rstBC.MoveNext()
1095: Loop 
			
1100: Call rstPiece.MoveNext()
1105: Loop 
		
1110: 'UPGRADE_NOTE: Object rstInventaire may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstInventaire = Nothing
1115: 'UPGRADE_NOTE: Object rstInvModif may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstInvModif = Nothing
		
1120: Call rstPiece.Close()
1125: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
1130: Call rstBC.Close()
1135: 'UPGRADE_NOTE: Object rstBC may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBC = Nothing
		
1140: If m_eTypeRetour = enumTypeRetour.ACHAT Then
1145: Call RemplirListViewAchat()
1150: Else
1155: Call RemplirListViewProjet()
			
			'Ajout aux modifs
1160: rstModif = New ADODB.Recordset
1165: rstEmploye = New ADODB.Recordset
			
1170: Call rstModif.Open("SELECT * FROM GRB_Projet_Modif", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
1175: Call rstModif.AddNew()
			
1180: Call rstEmploye.Open("SELECT noEmploye FROM GRB_Employés WHERE loginname = '" & g_sUserID & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
1185: rstModif.Fields("Type").Value = "E"
1190: rstModif.Fields("IDProjet").Value = VB.Right(txtnoprojet.Text, Len(txtnoprojet.Text) - 1)
1195: rstModif.Fields("noEmployé").Value = rstEmploye.Fields("noEmploye").Value
1200: rstModif.Fields("Date").Value = ConvertDate(Today)
1205: rstModif.Fields("Heure").Value = TimeOfDay
1210: rstModif.Fields("TypeModif").Value = "RETOUR"
			
1215: Call rstEmploye.Close()
1220: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstEmploye = Nothing
			
1225: Call rstModif.Update()
			
1230: Call rstModif.Close()
1235: 'UPGRADE_NOTE: Object rstModif may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstModif = Nothing
1240: End If
		
1245: Exit Sub
		
AfficherErreur: 
		
1250: Call AfficherErreur("frmRetourMarchandise", "Retour", Err, Erl())
	End Sub
	
	Private Sub frmRetourMarchandise_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: txtDateRetour.Text = ConvertDate(Today)
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmRetourMarchandise", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub lvwProjet_ItemCheck(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ItemCheckEventArgs) Handles lvwProjet.ItemCheck
		Dim Item As System.Windows.Forms.ListViewItem = lvwProjet.Items(eventArgs.Index)
		
5: On Error GoTo AfficherErreur
		
10: If Item.Text <> vbNullString Then
15: If CDbl(Item.Text) > 0 Then
20: Item.Checked = False
25: End If
30: Else
35: Item.Checked = False
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmRetourMarchandise", "lvwProjet_ItemCheck", Err, Erl())
	End Sub
	
	Private Sub mvwRetour_DateClick(ByVal eventSender As System.Object, ByVal eventArgs As AxMSComCtl2.DMonthViewEvents_DateClickEvent) Handles mvwRetour.DateClick
		
5: On Error GoTo AfficherErreur
		
10: txtDateRetour.Text = ConvertDate(eventArgs.DateClicked)
		
		'Enlever le calendrier
15: mvwRetour.Visible = False
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmRetourMarchandise", "mvwRetour_DateClick", Err, Erl())
	End Sub
	
	Private Sub mvwRetour_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mvwRetour.Leave
		
5: On Error GoTo AfficherErreur
		
10: mvwRetour.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmRetourMarchandise", "mvwRetour_LostFocus", Err, Erl())
	End Sub
	
	Private Sub cmdDate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDate.Click
		
5: On Error GoTo AfficherErreur
		
		'Ouverture du calendrier
10: If txtDateRetour.Text <> vbNullString Then
15: mvwRetour.Value = CDate(txtDateRetour.Text)
20: Else
25: mvwRetour.Value = Today
35: End If
		
40: mvwRetour.Visible = True
		
45: Call mvwRetour.Focus()
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmRetourMarchandise", "cmdDate_Click", Err, Erl())
	End Sub
End Class