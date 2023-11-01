Option Strict Off
Option Explicit On
Friend Class frmbonlivraison
	Inherits System.Windows.Forms.Form
	
	Private Const I_COL_COMMANDE As Short = 0
	Private Const I_COL_LIVRAISON As Short = 1
	Private Const I_COL_BACK_ORDER As Short = 2
	Private Const I_COL_DESCRIPTION As Short = 3
	Private Const I_COL_MANUFACTURIER As Short = 4
	
	Private m_bModeAjouter As Boolean
	
	Private Sub RemplirListView()
		
5: On Error GoTo AfficherErreur
		
		'rempli le ListView
10: Dim rstImpression As ADODB.Recordset
15: Dim itmImpression As System.Windows.Forms.ListViewItem
		
20: CmdAdd.Visible = True
25: CmdSupp.Visible = True
		
		'vide lister
30: Call lvwBonLivraison.Items.Clear()
		
35: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwBonLivraison.Sorted was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		lvwBonLivraison.Sorted = False
		
		'ouvre la table pour client
40: rstImpression = New ADODB.Recordset
		
45: Call rstImpression.Open("SELECT * FROM GRB_impression_bonlivraison WHERE user = '" & g_sUserID & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'tant que pas a la fin de la table
50: Do While Not rstImpression.EOF
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstImpression.Fields("qte_com").Value) Or Not IsDbNull(rstImpression.Fields("qte_livr").Value) Or Not IsDbNull(rstImpression.Fields("qte_bo").Value) Or Not IsDbNull(rstImpression.Fields("Description").Value) Or Not IsDbNull(rstImpression.Fields("Manufacturier").Value) Then
				'ajoute au lister
60: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwBonLivraison.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmImpression = lvwBonLivraison.Items.Add()
				
				'no du client
65: itmImpression.Tag = rstImpression.Fields("no").Value
				
				'qte_com
70: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstImpression.Fields("qte_com").Value) Then
75: itmImpression.Text = rstImpression.Fields("qte_com").Value
80: Else
85: itmImpression.Text = vbNullString
90: End If
				
				'qte_livr
95: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstImpression.Fields("qte_livr").Value) Then
100: 'UPGRADE_WARNING: Lower bound of collection itmImpression has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmImpression.SubItems.Count > I_COL_LIVRAISON Then
						itmImpression.SubItems(I_COL_LIVRAISON).Text = rstImpression.Fields("qte_livr").Value
					Else
						itmImpression.SubItems.Insert(I_COL_LIVRAISON, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstImpression.Fields("qte_livr").Value))
					End If
105: Else
110: 'UPGRADE_WARNING: Lower bound of collection itmImpression has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmImpression.SubItems.Count > I_COL_LIVRAISON Then
						itmImpression.SubItems(I_COL_LIVRAISON).Text = vbNullString
					Else
						itmImpression.SubItems.Insert(I_COL_LIVRAISON, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
115: End If
				
				'qte_bo
120: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstImpression.Fields("qte_bo").Value) Then
125: 'UPGRADE_WARNING: Lower bound of collection itmImpression has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmImpression.SubItems.Count > I_COL_BACK_ORDER Then
						itmImpression.SubItems(I_COL_BACK_ORDER).Text = rstImpression.Fields("qte_bo").Value
					Else
						itmImpression.SubItems.Insert(I_COL_BACK_ORDER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstImpression.Fields("qte_bo").Value))
					End If
130: Else
135: 'UPGRADE_WARNING: Lower bound of collection itmImpression has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmImpression.SubItems.Count > I_COL_BACK_ORDER Then
						itmImpression.SubItems(I_COL_BACK_ORDER).Text = vbNullString
					Else
						itmImpression.SubItems.Insert(I_COL_BACK_ORDER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
140: End If
				
				'description
145: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstImpression.Fields("Description").Value) Then
150: 'UPGRADE_WARNING: Lower bound of collection itmImpression has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmImpression.SubItems.Count > I_COL_DESCRIPTION Then
						itmImpression.SubItems(I_COL_DESCRIPTION).Text = rstImpression.Fields("Description").Value
					Else
						itmImpression.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstImpression.Fields("Description").Value))
					End If
155: Else
160: 'UPGRADE_WARNING: Lower bound of collection itmImpression has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmImpression.SubItems.Count > I_COL_DESCRIPTION Then
						itmImpression.SubItems(I_COL_DESCRIPTION).Text = vbNullString
					Else
						itmImpression.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
165: End If
				
				'manufacturier
170: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstImpression.Fields("manufacturier").Value) Then
175: 'UPGRADE_WARNING: Lower bound of collection itmImpression has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmImpression.SubItems.Count > I_COL_MANUFACTURIER Then
						itmImpression.SubItems(I_COL_MANUFACTURIER).Text = rstImpression.Fields("Manufacturier").Value
					Else
						itmImpression.SubItems.Insert(I_COL_MANUFACTURIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstImpression.Fields("Manufacturier").Value))
					End If
180: Else
185: 'UPGRADE_WARNING: Lower bound of collection itmImpression has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmImpression.SubItems.Count > I_COL_MANUFACTURIER Then
						itmImpression.SubItems(I_COL_MANUFACTURIER).Text = vbNullString
					Else
						itmImpression.SubItems.Insert(I_COL_MANUFACTURIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
190: End If
195: Else
200: Call rstImpression.Delete()
205: End If
			
			'prochaine enreg
210: Call rstImpression.MoveNext()
215: Loop 
		
		'fermeture table
220: Call rstImpression.Close()
225: 'UPGRADE_NOTE: Object rstImpression may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstImpression = Nothing
		
230: Exit Sub
		
AfficherErreur: 
		
235: Call AfficherErreur("frmbonlivraison", "RemplirListView", Err, Erl())
	End Sub
	
	Private Sub CmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdAdd.Click
		
5: On Error GoTo AfficherErreur
		'ajoute une qte
		'met visible fenetre pour ajouter
10: fraqte.Visible = True
		
		'mode ajoouter ou editer
15: m_bModeAjouter = True
		
		'valeur par defaut sur l'ouverture
20: txtQteCom.Text = vbNullString
25: txtQteLivr.Text = vbNullString
30: txtQteBo.Text = vbNullString
35: txtDescription.Text = vbNullString
40: txtManufacturier.Text = vbNullString
		
45: Call txtQteCom.Focus()
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmbonlivraison", "CmdAdd_Click", Err, Erl())
	End Sub
	
	Private Sub cmdfermerqte_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdfermerqte.Click
		
5: On Error GoTo AfficherErreur
		'quitte liste qte
		'cache fenetre
10: fraqte.Visible = False
		
15: Call RemplirListView()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmbonlivraison", "cmdfermerqte_Click", Err, Erl())
	End Sub
	
	Private Sub cmdquit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdquit.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmbonlivraison", "cmdquit_Click", Err, Erl())
	End Sub
	
	Private Sub cmdsave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdsave.Click
		
5: On Error GoTo AfficherErreur
		
		'pour sauver l'enregistrement
10: Dim rstImpression As ADODB.Recordset
15: Dim iNoIndex As Short
		
20: rstImpression = New ADODB.Recordset
		
		'si le mode est ajouter
25: If m_bModeAjouter = True Then
			'table impression ouvert
30: Call rstImpression.Open("SELECT * FROM GRB_impression_bonlivraison WHERE user = '" & g_sUserID & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
35: If rstImpression.EOF = False Then
40: If rstImpression.RecordCount >= 10 Then
45: With rstImpression
50: Do While Not .EOF
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
							If IsDbNull(.Fields("qte_com").Value) And IsDbNull(.Fields("qte_livr").Value) And IsDbNull(.Fields("qte_bo").Value) And IsDbNull(.Fields("description").Value) And IsDbNull(.Fields("manufacturier").Value) Then
60: iNoIndex = .Fields("No").Value
								
65: Exit Do
70: End If
							
75: Call .MoveNext()
80: Loop 
85: End With
					
90: If iNoIndex = 0 Then
95: iNoIndex = rstImpression.RecordCount + 1
						
100: Call rstImpression.AddNew()
105: End If
110: Else
115: rstImpression.MoveLast()
					
120: iNoIndex = rstImpression.Fields("No").Value + 1
					
125: Call rstImpression.AddNew()
130: End If
135: Else
140: iNoIndex = 1
				
145: Call rstImpression.AddNew()
150: End If
			
155: rstImpression.Fields("no").Value = iNoIndex
160: Else
165: Call rstImpression.Open("SELECT * FROM GRB_Impression_BonLivraison WHERE user = '" & g_sUserID & "' AND [No] = " & lvwBonLivraison.FocusedItem.Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
170: End If
		
175: If txtQteCom.Text = vbNullString Then
180: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			rstImpression.Fields("qte_com").Value = System.DBNull.Value
185: Else
190: rstImpression.Fields("qte_com").Value = txtQteCom.Text
195: End If
		
200: If txtQteLivr.Text = vbNullString Then
205: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			rstImpression.Fields("qte_livr").Value = System.DBNull.Value
210: Else
215: rstImpression.Fields("qte_livr").Value = txtQteLivr.Text
220: End If
		
225: If txtQteBo.Text = vbNullString Then
230: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			rstImpression.Fields("qte_bo").Value = System.DBNull.Value
235: Else
240: rstImpression.Fields("qte_bo").Value = txtQteBo.Text
245: End If
		
250: If txtDescription.Text = vbNullString Then
255: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			rstImpression.Fields("Description").Value = System.DBNull.Value
260: Else
265: rstImpression.Fields("Description").Value = txtDescription.Text
270: End If
		
275: If txtManufacturier.Text = vbNullString Then
280: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			rstImpression.Fields("manufacturier").Value = System.DBNull.Value
285: Else
290: rstImpression.Fields("manufacturier").Value = txtManufacturier.Text
295: End If
		
300: rstImpression.Fields("user").Value = g_sUserID
		
305: Call rstImpression.Update()
		
		'ferme la table
310: Call rstImpression.Close()
315: 'UPGRADE_NOTE: Object rstImpression may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstImpression = Nothing
		
		'cache la petite fenetre
320: fraqte.Visible = False
		
		'rempli le lister
325: Call RemplirListView()
		
330: Exit Sub
		
AfficherErreur: 
		
335: Call AfficherErreur("frmbonlivraison", "cmdsave_Click", Err, Erl())
	End Sub
	
	Private Sub CmdSupp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdSupp.Click
		
5: On Error GoTo AfficherErreur
		'################################################
		'supprime l'enregistrement sélectionné
10: Call g_connData.Execute("DELETE * FROM GRB_impression_bonlivraison")
		
		'initialise le lister
15: Call RemplirListView()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmbonlivraison", "CmdSupp_Click", Err, Erl())
	End Sub
	
	Private Sub frmbonlivraison_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'Remplir lister
15: Call RemplirListView()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmbonlivraison", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub frmbonlivraison_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim iNbreItem As Short
20: Dim rstImpression As ADODB.Recordset
		
		'ouvre les tables
25: rstImpression = New ADODB.Recordset
		
30: Call rstImpression.Open("SELECT * FROM GRB_impression_bonlivraison WHERE user = '" & g_sUserID & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
35: iNbreItem = lvwBonLivraison.Items.Count
		
40: If iNbreItem > 0 Then
45: For iCompteur = iNbreItem + 1 To 10
50: Call rstImpression.AddNew()
				
55: rstImpression.Fields("no").Value = iCompteur
60: rstImpression.Fields("user").Value = g_sUserID
				
65: Call rstImpression.Update()
70: Next 
75: End If
		
80: Call rstImpression.Close()
85: 'UPGRADE_NOTE: Object rstImpression may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstImpression = Nothing
		
90: Exit Sub
		
AfficherErreur: 
		
95: Call AfficherErreur("frmbonlivraison", "Form_Unload", Err, Erl())
	End Sub
	
	Private Sub lvwBonLivraison_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwBonLivraison.DoubleClick
		
5: On Error GoTo AfficherErreur
		'sur dbclick, affiche fenetre pour modifié l'enreg selectionné dans lister
		
		'si lister pas vide
10: If lvwBonLivraison.Items.Count <> 0 Then
			'met fenetre visible
15: fraqte.Visible = True
			
20: txtQteCom.Text = lvwBonLivraison.FocusedItem.Text
25: 'UPGRADE_WARNING: Lower bound of collection lvwBonLivraison.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			txtQteLivr.Text = lvwBonLivraison.FocusedItem.SubItems(I_COL_LIVRAISON).Text
30: 'UPGRADE_WARNING: Lower bound of collection lvwBonLivraison.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			txtQteBo.Text = lvwBonLivraison.FocusedItem.SubItems(I_COL_BACK_ORDER).Text
35: 'UPGRADE_WARNING: Lower bound of collection lvwBonLivraison.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			txtDescription.Text = lvwBonLivraison.FocusedItem.SubItems(I_COL_DESCRIPTION).Text
40: 'UPGRADE_WARNING: Lower bound of collection lvwBonLivraison.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			txtManufacturier.Text = lvwBonLivraison.FocusedItem.SubItems(I_COL_MANUFACTURIER).Text
			
			'met en mode edition
45: m_bModeAjouter = False
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmbonlivraison", "lvwBonLivraison_DblClick", Err, Erl())
	End Sub
	
	Private Sub lvwBonLivraison_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lvwBonLivraison.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: If lvwBonLivraison.Items.Count > 0 Then
15: If KeyCode = System.Windows.Forms.Keys.Delete Then
20: Call g_connData.Execute("DELETE * FROM GRB_Impression_BonLivraison WHERE [no] = " & lvwBonLivraison.FocusedItem.Tag & " AND User = '" & g_sUserID & "'")
				
25: Call CorrigerNumeros()
				
30: Call RemplirListView()
35: End If
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmbonlivraison", "lvwBonLivraison_KeyDown", Err, Erl())
	End Sub
	
	Private Sub CorrigerNumeros()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstNo As ADODB.Recordset
15: Dim iNo As Short
		
20: rstNo = New ADODB.Recordset
		
25: Call rstNo.Open("SELECT * FROM GRB_Impression_BonLivraison WHERE user = '" & g_sUserID & "' ORDER BY [no]", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
30: iNo = 1
		
35: Do While Not rstNo.EOF
40: rstNo.Fields("No").Value = iNo
			
45: iNo = iNo + 1
			
50: Call rstNo.Update()
			
55: Call rstNo.MoveNext()
60: Loop 
		
65: Call rstNo.Close()
70: 'UPGRADE_NOTE: Object rstNo may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstNo = Nothing
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmbonlivraison", "CorrigerNumeros", Err, Erl())
	End Sub
End Class