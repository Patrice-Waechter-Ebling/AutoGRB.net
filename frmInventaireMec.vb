Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmInventaireMec
	Inherits System.Windows.Forms.Form
	
	'Index des colonnes de lvwHistorique
	Private Const I_HIST_DATE As Short = 0
	Private Const I_HIST_USER As Short = 1
	Private Const I_HIST_PROJET As Short = 2
	Private Const I_HIST_PIECE As Short = 3
	Private Const I_HIST_QUANTITE As Short = 4
	
	'Index des chkChoix
	Private Const I_CHK_CHOIX_PROJET As Short = 0
	Private Const I_CHK_CHOIX_PIECE As Short = 1
	Private Const I_CHK_CHOIX_DATE As Short = 2
	
	'Pour l'impression
	Public m_bAnnuleImpression As Boolean
	Public m_eTypeImpression As frmChoixImpressionInventaire.enumImpressionInventaire
	Public m_typeImpressionExel As Boolean
	
	Private Sub cmdexporter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdexporter.Click
		m_typeImpressionExel = True 'pour l'affichage de Imprimer au lieu de Exporter dans frmchoixImpressionInventaire
		On Error GoTo AfficherErreur
		
		Call frmChoixImpressionInventaire.Afficher(Me)
		
		If m_bAnnuleImpression = False Then
			If m_eTypeImpression = frmChoixImpressionInventaire.enumImpressionInventaire.MODE_AJUST_INV Then
				Call ExporterAjustementInventaire()
			Else
				Call ExporterValeurComptable()
			End If
		End If
		
		Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmInventaireMec", "cmdImprimer_Click", Err, Erl())
	End Sub
	
	Private Sub lvwHistorique_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lvwHistorique.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: If KeyCode = System.Windows.Forms.Keys.Delete Then
15: If MsgBox("Voulez-vous vraiment effacer cet historique?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
20: Call g_connData.Execute("DELETE * FROM GRB_InventaireMecModif WHERE NoEnreg = " & lvwHistorique.FocusedItem.Tag)
				
25: If MsgBox("Voulez-vous modifier la quantité dans l'inventaire?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
30: 'UPGRADE_WARNING: Lower bound of collection lvwHistorique.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call ModifierInventaire(lvwHistorique.FocusedItem.SubItems(I_HIST_PIECE).Text, lvwHistorique.FocusedItem.SubItems(I_HIST_QUANTITE).Text)
35: End If
40: End If
			
45: Call RemplirListViewHistorique()
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmInventaireMec", "lvwHistorique_KeyDown", Err, Erl())
	End Sub
	
	Private Sub ModifierInventaire(ByVal sPiece As String, ByVal sQuantite As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstInv As ADODB.Recordset
		
15: If CDbl(sQuantite) > 0 Then
20: sQuantite = "-" & sQuantite
25: Else
30: sQuantite = Replace(sQuantite, "-", "")
35: End If
		
40: rstInv = New ADODB.Recordset
		
45: Call rstInv.Open("SELECT * FROM GRB_InventaireMec WHERE NoItem = '" & Replace(sPiece, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
50: rstInv.Fields("QuantitéStock").Value = CDbl(rstInv.Fields("QuantitéStock").Value) + CDbl(sQuantite)
		
55: Call rstInv.Update()
		
60: Call rstInv.Close()
65: 'UPGRADE_NOTE: Object rstInv may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstInv = Nothing
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmInventaireMec", "ModifierInventaire", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewHistorique()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le ListView lvwHistorique
10: Dim rstHist As ADODB.Recordset
15: Dim sWhere As String
20: Dim itmHist As System.Windows.Forms.ListViewItem
		
		'Si c'est une recherche avec le no de projet
25: If chkChoix(I_CHK_CHOIX_PROJET).CheckState = System.Windows.Forms.CheckState.Checked Then
30: sWhere = "Left(IDProjet," & Len(txtnoprojet.Text) & ") = '" & txtnoprojet.Text & "' "
35: End If
		
		'Si c'est une recherche avec le no de la piece
40: If chkChoix(I_CHK_CHOIX_PIECE).CheckState = System.Windows.Forms.CheckState.Checked Then
45: If sWhere = vbNullString Then
50: sWhere = "INSTR(1,NoItem,'" & Replace(txtNoPiece.Text, "'", "''") & "') > 0 "
55: Else
60: sWhere = sWhere & " AND INSTR(1,NoItem,'" & Replace(txtNoPiece.Text, "'", "''") & "') > 0 "
65: End If
70: End If
		
		'Si c'est une recherche par date
75: If chkChoix(I_CHK_CHOIX_DATE).CheckState = System.Windows.Forms.CheckState.Checked Then
80: If sWhere = vbNullString Then
85: sWhere = "Date BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'"
90: Else
95: sWhere = sWhere & " AND Date BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'"
100: End If
105: End If
		
110: rstHist = New ADODB.Recordset
		
115: Call rstHist.Open("SELECT * FROM GRB_InventaireMecModif WHERE " & sWhere & " ORDER BY NoEnreg DESC", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Il faut vider le ListView avant de le remplir
120: Call lvwHistorique.Items.Clear()
		
		'Tant que ce n'est pas la fin des enregistrements
125: Do While Not rstHist.EOF
			'On l'ajoute
130: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwHistorique.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmHist = lvwHistorique.Items.Add()
			
			'Date
135: itmHist.Text = rstHist.Fields("Date").Value
140: itmHist.Tag = rstHist.Fields("NoEnreg").Value
			
			'User
145: 'UPGRADE_WARNING: Lower bound of collection itmHist has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmHist.SubItems.Count > I_HIST_USER Then
				itmHist.SubItems(I_HIST_USER).Text = rstHist.Fields("User").Value
			Else
				itmHist.SubItems.Insert(I_HIST_USER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstHist.Fields("User").Value))
			End If
			
			'IDProjet
150: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstHist.Fields("IDProjet").Value) Then
155: If Trim(rstHist.Fields("IDProjet").Value) <> "" Then
160: 'UPGRADE_WARNING: Lower bound of collection itmHist has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmHist.SubItems.Count > I_HIST_PROJET Then
						itmHist.SubItems(I_HIST_PROJET).Text = rstHist.Fields("IDProjet").Value
					Else
						itmHist.SubItems.Insert(I_HIST_PROJET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstHist.Fields("IDProjet").Value))
					End If
165: Else
170: 'UPGRADE_WARNING: Lower bound of collection itmHist has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmHist.SubItems.Count > I_HIST_PROJET Then
						itmHist.SubItems(I_HIST_PROJET).Text = "N/A"
					Else
						itmHist.SubItems.Insert(I_HIST_PROJET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "N/A"))
					End If
175: End If
180: Else
185: 'UPGRADE_WARNING: Lower bound of collection itmHist has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmHist.SubItems.Count > I_HIST_PROJET Then
					itmHist.SubItems(I_HIST_PROJET).Text = "N/A"
				Else
					itmHist.SubItems.Insert(I_HIST_PROJET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "N/A"))
				End If
190: End If
			
			'No Item
195: 'UPGRADE_WARNING: Lower bound of collection itmHist has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmHist.SubItems.Count > I_HIST_PIECE Then
				itmHist.SubItems(I_HIST_PIECE).Text = rstHist.Fields("NoItem").Value
			Else
				itmHist.SubItems.Insert(I_HIST_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstHist.Fields("NoItem").Value))
			End If
			
			'Quantité
200: 'UPGRADE_WARNING: Lower bound of collection itmHist has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmHist.SubItems.Count > I_HIST_QUANTITE Then
				itmHist.SubItems(I_HIST_QUANTITE).Text = rstHist.Fields("Quantité").Value
			Else
				itmHist.SubItems.Insert(I_HIST_QUANTITE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstHist.Fields("Quantité").Value))
			End If
			
205: Call rstHist.MoveNext()
210: Loop 
		
215: Call rstHist.Close()
220: 'UPGRADE_NOTE: Object rstHist may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstHist = Nothing
		
225: Exit Sub
		
AfficherErreur: 
		
230: Call AfficherErreur("frmInventaireMec", "RemplirListViewHistorique", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkChoix.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkChoix_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkChoix.CheckStateChanged
		Dim Index As Short = chkChoix.GetIndex(eventSender)
		
5: On Error GoTo AfficherErreur
		
		'Méthode qui met enabled ou disabled les controles selon le type de recherche
10: Dim bEnabled As Boolean
		
15: If chkChoix(Index).CheckState = System.Windows.Forms.CheckState.Checked Then
20: bEnabled = True
25: Else
30: bEnabled = False
35: End If
		
40: Select Case Index
			Case I_CHK_CHOIX_PROJET
45: fraProjet.Enabled = bEnabled
				
			Case I_CHK_CHOIX_PIECE
50: fraPiece.Enabled = bEnabled
				
			Case I_CHK_CHOIX_DATE
55: fraDate.Enabled = bEnabled
60: End Select
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmInventaireMec", "chkChoix_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAfficherHistorique_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAfficherHistorique.Click
		
5: On Error GoTo AfficherErreur
		
		'Affiche l'historique des modifications de l'inventaire
		
10: If chkChoix(I_CHK_CHOIX_DATE).CheckState = System.Windows.Forms.CheckState.Checked Then
15: If mskDateDebut.Text <> vbNullString And mskDateFin.Text <> vbNullString Then
20: If mskDateDebut.Text > mskDateFin.Text Then
25: Call MsgBox("La date de fin doit être plus petite que la date de début!", MsgBoxStyle.OKOnly, "Erreur")
					
30: Exit Sub
35: End If
40: Else
45: Call MsgBox("Vous devez remplir tous les champs!", MsgBoxStyle.OKOnly, "Erreur")
				
50: Exit Sub
55: End If
60: End If
		
65: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
70: If chkChoix(I_CHK_CHOIX_DATE).CheckState = System.Windows.Forms.CheckState.Checked Or chkChoix(I_CHK_CHOIX_PIECE).CheckState = System.Windows.Forms.CheckState.Checked Or chkChoix(I_CHK_CHOIX_PROJET).CheckState = System.Windows.Forms.CheckState.Checked Then
75: Call RemplirListViewHistorique()
80: Else
85: Call MsgBox("Vous devez choisir au moins une option de recherche!", MsgBoxStyle.OKOnly, "Erreur")
90: End If
		
95: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmInventaireMec", "cmdAfficherHistorique_Click", Err, Erl())
	End Sub
	
	Private Sub cmdImprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImprimer.Click
		m_typeImpressionExel = False 'pour l'affichage de Imprimer au lieu de Exporter dans frmchoixImpressionInventaire
5: On Error GoTo AfficherErreur
		
10: Call frmChoixImpressionInventaire.Afficher(Me)
		
15: If m_bAnnuleImpression = False Then
20: If m_eTypeImpression = frmChoixImpressionInventaire.enumImpressionInventaire.MODE_AJUST_INV Then
25: Call ImprimerAjustementInventaire()
30: Else
35: Call ImprimerValeurComptable()
40: End If
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmInventaireMec", "cmdImprimer_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmInventaireMec", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub frmInventaireMec_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Call frmChoixInventaire.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmInventaireMec", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub lvwHistorique_ColumnClick(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ColumnClickEventArgs) Handles lvwHistorique.ColumnClick
		Dim ColumnHeader As System.Windows.Forms.ColumnHeader = lvwHistorique.Columns(eventArgs.Column)
		
5: On Error GoTo AfficherErreur
		
10: If lvwHistorique.Items.Count > 0 Then
15: lvwHistorique.Sort()
			
20: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwHistorique.SortKey was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			lvwHistorique.SortKey = ColumnHeader.Index - 1
			
25: If lvwHistorique.Sorting = System.Windows.Forms.SortOrder.Ascending Then
30: lvwHistorique.Sorting = System.Windows.Forms.SortOrder.Descending
35: Else
40: lvwHistorique.Sorting = System.Windows.Forms.SortOrder.Ascending
45: End If
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmInventaireMec", "lvwHistorique_ColumnClick", Err, Erl())
	End Sub
	
	Private Sub mskDateDebut_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateDebut.Enter
		
5: On Error GoTo AfficherErreur
		
10: If Len(mskDateDebut.Text) = 10 Then
15: mskDateDebut.Text = VB.Right(mskDateDebut.Text, 8)
20: End If
		
25: mskDateDebut.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmInventaireMec", "mskDateDebut_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateDebut_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateDebut.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskDateDebut.Mask = vbNullString
		
15: If mskDateDebut.Text = "__-__-__" Then
20: mskDateDebut.Text = vbNullString
25: Else
30: If Len(mskDateDebut.Text) = 8 Then
35: If IsDate(mskDateDebut.Text) Then
40: mskDateDebut.Text = Year(DateSerial(CInt(VB.Left(mskDateDebut.Text, 2)), CInt(Mid(mskDateDebut.Text, 4, 2)), CInt(VB.Right(mskDateDebut.Text, 2)))) & Mid(mskDateDebut.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmInventaireMec", "mskDateDebut_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateFin_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateFin.Enter
		
5: On Error GoTo AfficherErreur
		
10: If Len(mskDateFin.Text) = 10 Then
15: mskDateFin.Text = VB.Right(mskDateFin.Text, 8)
20: End If
		
25: mskDateFin.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmInventaireMec", "mskDateFin_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateFin_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateFin.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskDateFin.Mask = vbNullString
		
15: If mskDateFin.Text = "__-__-__" Then
20: mskDateFin.Text = vbNullString
25: Else
30: If Len(mskDateFin.Text) = 8 Then
35: If IsDate(mskDateFin.Text) Then
40: mskDateFin.Text = Year(DateSerial(CInt(VB.Left(mskDateFin.Text, 2)), CInt(Mid(mskDateFin.Text, 4, 2)), CInt(VB.Right(mskDateFin.Text, 2)))) & Mid(mskDateFin.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmInventaireMec", "mskDateFin_LostFocus", Err, Erl())
	End Sub
	
	Private Sub ImprimerAjustementInventaire()
		Dim DR_ListeInventaire As Object
		
5: On Error GoTo AfficherErreur
		
		'Impression de la l'inventaire trié par localisation et par no d'item
10: Dim rstInv As ADODB.Recordset
15: Dim sChamps As String
		
20: rstInv = New ADODB.Recordset
		
25: Call rstInv.Open("SELECT NoItem, QuantitéStock, Description, Manufacturier, Localisation FROM GRB_InventaireMec ORDER BY Localisation, NoItem", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
30: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeInventaire.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ListeInventaire.DataSource = rstInv
		
35: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeInventaire.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ListeInventaire.Sections("Section3").Controls("lblDate").Caption = ConvertDate(Today)
40: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeInventaire.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ListeInventaire.Sections("Section4").Controls("lblTitre").Caption = "Inventaire Mécanique"
		
45: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeInventaire.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_ListeInventaire.Show(VB6.FormShowConstants.Modal)
		
50: Call rstInv.Close()
55: 'UPGRADE_NOTE: Object rstInv may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstInv = Nothing
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmInventaireMec", "ImprimerAjustementInventaire", Err, Erl())
	End Sub
	
	Private Sub ImprimerValeurComptable()
		Dim DR_Inventaire As Object
		
5: On Error GoTo AfficherErreur
		
		'Impression de la l'inventaire trié par localisation et par no d'item
10: Dim rstInv As ADODB.Recordset
15: Dim rstTotal As ADODB.Recordset
		
20: rstInv = New ADODB.Recordset
25: rstTotal = New ADODB.Recordset
		
30: Call rstInv.Open("SELECT NoItem, Description, Manufacturier, [Prix Liste], Escompte, [Prix Net], Localisation, QuantitéStock, [Prix Net] * QuantitéStock As Total FROM GRB_InventaireMec WHERE QuantitéStock <> '0' ORDER BY NoItem", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
35: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Inventaire.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Inventaire.DataSource = rstInv
		
40: Call rstTotal.Open("SELECT SUM([Prix net] * QuantitéStock) As Total FROM GRB_InventaireMec", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
45: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Inventaire.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Inventaire.Sections("Section3").Controls("lblDate").Caption = ConvertDate(Today)
50: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Inventaire.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Inventaire.Sections("Section5").Controls("lblTotal").Caption = Conversion_Renamed(rstTotal.Fields("Total"), ModuleMain.enumConvert.MODE_ARGENT)
55: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Inventaire.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Inventaire.Sections("Section4").Controls("lblTitre").Caption = "Inventaire Mécanique"
		
60: Call rstTotal.Close()
65: 'UPGRADE_NOTE: Object rstTotal may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstTotal = Nothing
		
70: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Inventaire.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Inventaire.Orientation = MSDataReportLib.OrientationConstants.rptOrientLandscape
		
75: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Inventaire.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_Inventaire.Show(VB6.FormShowConstants.Modal)
		
80: Call rstInv.Close()
85: 'UPGRADE_NOTE: Object rstInv may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstInv = Nothing
		
90: Exit Sub
		
AfficherErreur: 
		
95: Call AfficherErreur("frmInventaireMec", "ImprimerValeurComptable", Err, Erl())
	End Sub
	Private Function ExporterAjustementInventaire() As Object
		On Error GoTo AfficherErreur
		
		'Impression de l'inventaire trié par localisation et par no d'item
		Dim rstInv As ADODB.Recordset
		Dim sChamps As String
		Dim oXLApp As Excel.Application 'Declare the object variables
		Dim oXLBook As Excel.Workbook
		Dim oXLSheet As Excel.Worksheet
		'UPGRADE_WARNING: Lower bound of array data_array was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim data_array(2500, 5) As Object
		Dim r As Short
		oXLApp = New Excel.Application 'Create a new instance of Excel
		oXLBook = oXLApp.Workbooks.Add 'Add a new workbook
		oXLSheet = oXLBook.Worksheets(1) 'Work with the first worksheet
		oXLApp.Visible = False
		
		rstInv = New ADODB.Recordset
		
		Call rstInv.Open("SELECT NoItem, QuantitéStock, Description, Manufacturier, Localisation FROM GRB_InventaireMec ORDER BY Localisation, NoItem", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		r = 1
		
		'ajoute les donné dans un tableau
		Do While Not rstInv.EOF
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 1) = rstInv.Fields("NoItem").Value
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 2) = rstInv.Fields("Description").Value
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 3) = rstInv.Fields("Manufacturier").Value
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 4) = rstInv.Fields("Localisation").Value
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 5) = rstInv.Fields("QuantitéStock").Value
			r = r + 1
			Call rstInv.MoveNext()
		Loop 
		
		
		
		
		
		'creation en-tête de colonne
		oXLSheet.Range("A1: E1").Font.Bold = True
		oXLSheet.Range("A:E").HorizontalAlignment = Excel.Constants.xlCenter
		'UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		oXLSheet.Range("A1: E1").Value = New Object(){"NoItem", "Description", "Manufacturier", "Localisation", "QuantitéStock"} 'GLL
		'figer la premiere ligne de la table
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLApp.ActiveSheet.Range. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLApp.ActiveSheet.Range("a2").Select()
		With oXLApp.ActiveWindow
			.FreezePanes = False
			.ScrollRow = 1
			.ScrollColumn = 1
			.FreezePanes = True
			.ScrollRow = 2
		End With
		
		
		'inscription des valeur du tableau dans excel
		oXLSheet.Range("A2").Resize(r, 5).Value = VB6.CopyArray(data_array)
		
		'ajustement largeur des colonne
		oXLSheet.Range("A:I").Columns.AutoFit()
		oXLApp.Visible = True
		
		
		
		
50: Call rstInv.Close()
55: 'UPGRADE_NOTE: Object rstInv may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstInv = Nothing
		
60: Exit Function
		
AfficherErreur: 
		
65: Call AfficherErreur("frmInventaireElec", "cmdExport_Click", Err, Erl())
	End Function
	Private Function ExporterValeurComptable() As Object
		Dim DR_Inventaire As Object
		
		On Error GoTo AfficherErreur
		
		'Impression de la l'inventaire trié par localisation et par no d'item
		Dim rstTotal As ADODB.Recordset
		Dim rstInv As ADODB.Recordset
		rstInv = New ADODB.Recordset
		rstTotal = New ADODB.Recordset
		Dim oXLApp As Excel.Application 'Declare the object variables
		Dim oXLBook As Excel.Workbook
		Dim oXLSheet As Excel.Worksheet
		'UPGRADE_WARNING: Lower bound of array data_array was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim data_array(2500, 9) As Object
		Dim r As Short
		oXLApp = New Excel.Application 'Create a new instance of Excel
		oXLBook = oXLApp.Workbooks.Add 'Add a new workbook
		oXLSheet = oXLBook.Worksheets(1) 'Work with the first worksheet
		oXLApp.Visible = False
		
		Call rstInv.Open("SELECT NoItem, Description, Manufacturier, [Prix Liste], Escompte, [Prix Net], Localisation, QuantitéStock, [Prix Net] * QuantitéStock As Total FROM GRB_InventaireMec WHERE QuantitéStock <> '0' ORDER BY NoItem", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object DR_Inventaire.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Inventaire.DataSource = rstInv
		
		Call rstTotal.Open("SELECT SUM([Prix net] * QuantitéStock) As Total FROM GRB_InventaireMec", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		r = 1
		'Ajouter les valeur lu au tableau
		Do While Not rstInv.EOF
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 1) = rstInv.Fields("NoItem").Value
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 2) = rstInv.Fields("Description").Value
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 3) = rstInv.Fields("manufacturier").Value
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 4) = rstInv.Fields("Localisation").Value
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 5) = rstInv.Fields("QuantitéStock").Value
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 6) = rstInv.Fields("prix liste").Value
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 7). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 7) = rstInv.Fields("escompte").Value
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 8). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 8) = rstInv.Fields("prix net").Value
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 9). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 9) = rstInv.Fields("Total").Value
			r = r + 1
			
			rstInv.MoveNext()
		Loop 
		'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 8). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		data_array(r, 8) = "Grand Total"
		'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 9). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		data_array(r, 9) = rstTotal.Fields("Total").Value
		
		
		
		
		
		'creation en-tête de colonne
		oXLSheet.Range("A1: I1").Font.Bold = True
		oXLSheet.Range("A:E").HorizontalAlignment = Excel.Constants.xlCenter
		'UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		oXLSheet.Range("A1: I1").Value = New Object(){"NoItem", "Description", "Manufacturier", "Localisation", "QuantitéStock", "Prix Lister", "Escompte", "Prix Net", "Total"} 'GLL
		
		'Figer la premiere ligne de la table
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLApp.ActiveSheet.Range. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLApp.ActiveSheet.Range("a2").Select()
		With oXLApp.ActiveWindow
			.FreezePanes = False
			.ScrollRow = 1
			.ScrollColumn = 1
			.FreezePanes = True
			.ScrollRow = 2
		End With
		'transfer le tableau dans la table de excel
		oXLSheet.Range("A2").Resize(r, 9).Value = VB6.CopyArray(data_array)
		oXLSheet.Range("F:F").NumberFormat = "#,##0.00 $"
		oXLSheet.Range("H:I").NumberFormat = "#,##0.00 $"
		
		'ajustement largeur des colonne
		oXLSheet.Range("A:I").Columns.AutoFit()
		oXLApp.Visible = True
		
		Call rstTotal.Close()
		'UPGRADE_NOTE: Object rstTotal may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstTotal = Nothing
		Call rstInv.Close()
		'UPGRADE_NOTE: Object rstInv may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstInv = Nothing
		
		Exit Function
		
AfficherErreur: 
		
		Call AfficherErreur("frmInventaireElec", "cmdexport_Click", Err, Erl())
	End Function
End Class