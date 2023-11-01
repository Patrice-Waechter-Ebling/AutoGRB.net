Option Strict Off
Option Explicit On
Friend Class frmSoumissionSectionMec
	Inherits System.Windows.Forms.Form
	
	Private Const I_COL_FRANCAIS As Short = 0
	Private Const I_COL_ANGLAIS As Short = 1
	
	Private m_bAjout As Boolean
	
	Private Sub Sauvegarde()
		
5: On Error GoTo AfficherErreur
		
		'Sauvegarde des données dans l'ordre du lister
10: Dim rstSection As ADODB.Recordset
15: Dim iCompteur As Short
		
20: rstSection = New ADODB.Recordset
		
		'Pour toutes les données dans lister
25: For iCompteur = 1 To lvwSection.Items.Count
30: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Call rstSection.Open("SELECT NomSectionFR, NomSectionEN, Ordre FROM GRB_SoumProjSectionMec WHERE IDSection = " & lvwSection.Items.Item(iCompteur).Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
35: rstSection.Fields("Ordre").Value = iCompteur
			
40: Call rstSection.Update()
			
			'Ferme la table
45: Call rstSection.Close()
50: Next 
		
55: 'UPGRADE_NOTE: Object rstSection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstSection = Nothing
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmSoumissionSectionMec", "Sauvegarde", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewSection()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le ListView des Sections
10: Dim rstSection As ADODB.Recordset
15: Dim itmSection As System.Windows.Forms.ListViewItem
		
20: rstSection = New ADODB.Recordset
		
25: Call rstSection.Open("SELECT * FROM GRB_SoumProjSectionMec ORDER BY Ordre", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Il faut vider le ListView avant de le remplir
30: Call lvwSection.Items.Clear()
		
		'Tant que ce n'est pas la fin des enregistrements
35: Do While Not rstSection.EOF
40: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwSection.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmSection = lvwSection.Items.Add()
			
45: itmSection.Tag = rstSection.Fields("IDSection").Value
			
			'Nom en francais
50: itmSection.Text = rstSection.Fields("NomSectionFR").Value
			
			'Nom en anglais
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstSection.Fields("NomSectionEN").Value) Then
60: 'UPGRADE_WARNING: Lower bound of collection itmSection has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmSection.SubItems.Count > I_COL_ANGLAIS Then
					itmSection.SubItems(I_COL_ANGLAIS).Text = rstSection.Fields("NomSectionEN").Value
				Else
					itmSection.SubItems.Insert(I_COL_ANGLAIS, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstSection.Fields("NomSectionEN").Value))
				End If
65: Else
70: 'UPGRADE_WARNING: Lower bound of collection itmSection has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmSection.SubItems.Count > I_COL_ANGLAIS Then
					itmSection.SubItems(I_COL_ANGLAIS).Text = vbNullString
				Else
					itmSection.SubItems.Insert(I_COL_ANGLAIS, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
75: End If
			
80: Call rstSection.MoveNext()
85: Loop 
		
90: Call rstSection.Close()
95: 'UPGRADE_NOTE: Object rstSection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstSection = Nothing
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmSoumissionSectionMec", "RemplirListViewSection", Err, Erl())
	End Sub
	
	Private Sub CmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdAdd.Click
		
5: On Error GoTo AfficherErreur
		
10: m_bAjout = True
		
15: txtAnglais.Text = vbNullString
20: txtFrancais.Text = vbNullString
		
25: fraAjout.Visible = True
		
30: Call txtFrancais.Focus()
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmSoumissionSectionMec", "CmdAdd_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: fraAjout.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmSoumissionSectionMec", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstSection As ADODB.Recordset
15: Dim rstMaxOrdre As ADODB.Recordset
		
20: If Trim(txtFrancais.Text) = vbNullString Or Trim(txtAnglais.Text) = vbNullString Then
25: Call MsgBox("Le nom en français et en anglais est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
			
30: Exit Sub
35: End If
		
40: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
45: rstSection = New ADODB.Recordset
		
50: If m_bAjout = True Then
			'ouvre la table
55: Call rstSection.Open("SELECT * FROM GRB_SoumProjSectionMec WHERE NomSectionFR = '" & Replace(txtFrancais.Text, "'", "''") & "' OR NomSectionEN = '" & Replace(txtAnglais.Text, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'si n'existe pas
60: If rstSection.EOF Then
65: rstMaxOrdre = New ADODB.Recordset
				
70: Call rstMaxOrdre.Open("SELECT Max(Ordre) as MaxOrdre FROM GRB_SoumProjSectionMec", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
				'ajoute la section
75: Call rstSection.AddNew()
				
80: rstSection.Fields("NomSectionFR").Value = txtFrancais.Text
85: rstSection.Fields("NomSectionEN").Value = txtAnglais.Text
90: rstSection.Fields("Ordre").Value = rstMaxOrdre.Fields("MaxOrdre").Value + 1
				
95: Call rstMaxOrdre.Close()
100: 'UPGRADE_NOTE: Object rstMaxOrdre may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstMaxOrdre = Nothing
				
105: Call rstSection.Update()
				
110: m_bAjout = False
115: Else
120: Call MsgBox("Cette section existe déjà!")
125: End If
			
130: Call rstSection.Close()
135: 'UPGRADE_NOTE: Object rstSection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstSection = Nothing
140: Else
145: Call rstSection.Open("SELECT * FROM GRB_SoumProjSectionMec WHERE IDSection = " & lvwSection.FocusedItem.Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
150: rstSection.Fields("NomSectionFR").Value = txtFrancais.Text
155: rstSection.Fields("NomSectionEN").Value = txtAnglais.Text
			
160: Call rstSection.Update()
			
			'ferme la table
165: Call rstSection.Close()
170: 'UPGRADE_NOTE: Object rstSection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstSection = Nothing
175: End If
		
180: Call RemplirListViewSection()
		
185: fraAjout.Visible = False
		
190: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
195: Exit Sub
		
AfficherErreur: 
		
200: Call AfficherErreur("frmSoumissionSectionMec", "CmdOK_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDown_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDown.Click
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''''''''''''''''''''''
		'descend la selection d'une ligne
		'''''''''''''''''''''''''''''''''''''''''
10: Dim sTagAvant As String
15: Dim sTagApres As String
20: Dim sFrancaisAvant As String
25: Dim sFrancaisApres As String
30: Dim sAnglaisAvant As String
35: Dim sAnglaisApres As String
40: Dim iIndex As Short
		
45: iIndex = lvwSection.FocusedItem.Index
		
50: If iIndex < lvwSection.Items.Count Then
			'garde en memoire les données qui vont se repositionné dans la list
55: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object lvwSection.ListItems().Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			sTagAvant = lvwSection.Items.Item(iIndex).Tag
60: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			sFrancaisAvant = lvwSection.Items.Item(iIndex).Text
65: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			sAnglaisAvant = lvwSection.Items.Item(iIndex).SubItems(I_COL_ANGLAIS).Text
			
70: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object lvwSection.ListItems().Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			sTagApres = lvwSection.Items.Item(iIndex + 1).Tag
75: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			sFrancaisApres = lvwSection.Items.Item(iIndex + 1).Text
80: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			sAnglaisApres = lvwSection.Items.Item(iIndex + 1).SubItems(I_COL_ANGLAIS).Text
			
			'reposition dans la liste
85: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwSection.Items.Item(iIndex).Tag = sTagApres
90: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwSection.Items.Item(iIndex).Text = sFrancaisApres
95: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwSection.Items.Item(iIndex).SubItems.Count > I_COL_ANGLAIS Then
				lvwSection.Items.Item(iIndex).SubItems(I_COL_ANGLAIS).Text = sAnglaisApres
			Else
				lvwSection.Items.Item(iIndex).SubItems.Insert(I_COL_ANGLAIS, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sAnglaisApres))
			End If
			
100: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwSection.Items.Item(iIndex + 1).Tag = sTagAvant
105: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwSection.Items.Item(iIndex + 1).Text = sFrancaisAvant
110: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwSection.Items.Item(iIndex + 1).SubItems.Count > I_COL_ANGLAIS Then
				lvwSection.Items.Item(iIndex + 1).SubItems(I_COL_ANGLAIS).Text = sAnglaisAvant
			Else
				lvwSection.Items.Item(iIndex + 1).SubItems.Insert(I_COL_ANGLAIS, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sAnglaisAvant))
			End If
			
			'descend la selection
115: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwSection.Items.Item(iIndex + 1).Selected = True
			
120: 'UPGRADE_WARNING: MSComctlLib.IListItem method lvwSection.SelectedItem.EnsureVisible has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			Call lvwSection.FocusedItem.EnsureVisible()
125: End If
		
130: Exit Sub
		
AfficherErreur: 
		
135: Call AfficherErreur("frmSoumissionSectionMec", "cmdDown_Click", Err, Erl())
	End Sub
	
	Private Sub cmdUp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUp.Click
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''''''''''''''''''''''
		'monte la selection d'une ligne
		'''''''''''''''''''''''''''''''''''''''''
10: Dim sTagAvant As String
15: Dim sTagApres As String
20: Dim sFrancaisAvant As String
25: Dim sFrancaisApres As String
30: Dim sAnglaisAvant As String
35: Dim sAnglaisApres As String
40: Dim iIndex As Short
		
45: iIndex = lvwSection.FocusedItem.Index
		
50: If iIndex > 1 Then
			'garde en memoire les données qui vont se repositionné dans la list
55: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object lvwSection.ListItems().Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			sTagAvant = lvwSection.Items.Item(iIndex).Tag
60: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			sFrancaisAvant = lvwSection.Items.Item(iIndex).Text
65: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			sAnglaisAvant = lvwSection.Items.Item(iIndex).SubItems(I_COL_ANGLAIS).Text
			
70: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object lvwSection.ListItems().Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			sTagApres = lvwSection.Items.Item(iIndex - 1).Tag
75: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			sFrancaisApres = lvwSection.Items.Item(iIndex - 1).Text
80: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			sAnglaisApres = lvwSection.Items.Item(iIndex - 1).SubItems(I_COL_ANGLAIS).Text
			
			'reposition dans la liste
85: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwSection.Items.Item(iIndex).Tag = sTagApres
90: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwSection.Items.Item(iIndex).Text = sFrancaisApres
95: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwSection.Items.Item(iIndex).SubItems.Count > I_COL_ANGLAIS Then
				lvwSection.Items.Item(iIndex).SubItems(I_COL_ANGLAIS).Text = sAnglaisApres
			Else
				lvwSection.Items.Item(iIndex).SubItems.Insert(I_COL_ANGLAIS, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sAnglaisApres))
			End If
			
100: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwSection.Items.Item(iIndex - 1).Tag = sTagAvant
105: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwSection.Items.Item(iIndex - 1).Text = sFrancaisAvant
110: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwSection.Items.Item(iIndex - 1).SubItems.Count > I_COL_ANGLAIS Then
				lvwSection.Items.Item(iIndex - 1).SubItems(I_COL_ANGLAIS).Text = sAnglaisAvant
			Else
				lvwSection.Items.Item(iIndex - 1).SubItems.Insert(I_COL_ANGLAIS, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sAnglaisAvant))
			End If
			
			'monte la selection
115: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwSection.Items.Item(iIndex - 1).Selected = True
			
120: 'UPGRADE_WARNING: MSComctlLib.IListItem method lvwSection.SelectedItem.EnsureVisible has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			Call lvwSection.FocusedItem.EnsureVisible()
125: End If
		
130: Exit Sub
		
AfficherErreur: 
		
135: Call AfficherErreur("frmSoumissionSectionMec", "cmdUp_Click", Err, Erl())
	End Sub
	
	Private Sub CmdFerme_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdFerme.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Sauvegarde()
		
15: Call Me.Close()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmSoumissionSectionMec", "CmdFerme_Click", Err, Erl())
	End Sub
	
	Private Sub cmdModifier_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdModifier.Click
		
5: On Error GoTo AfficherErreur
		
10: txtFrancais.Text = lvwSection.FocusedItem.Text
15: 'UPGRADE_WARNING: Lower bound of collection lvwSection.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		txtAnglais.Text = lvwSection.FocusedItem.SubItems(I_COL_ANGLAIS).Text
		
20: fraAjout.Visible = True
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmSoumissionSectionMec", "cmdModifier_Click", Err, Erl())
	End Sub
	
	Private Sub CmdSupp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdSupp.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstSoumission As ADODB.Recordset
		
		'fonction qui supprime lenregistrement courant
15: If lvwSection.Items.Count > 0 Then
20: If MsgBox("Etes-vous sur de supprimer cette enregistrement?", MsgBoxStyle.YesNo, "Supprimer") = MsgBoxResult.Yes Then
25: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
30: rstSoumission = New ADODB.Recordset
				
35: Call rstSoumission.Open("SELECT IDSection FROM GRB_Soumission_pieces WHERE IDSection = " & lvwSection.FocusedItem.Tag & " AND Type = 'M'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
40: If rstSoumission.EOF Then
					'Efface l'enregistrement
45: Call g_connData.Execute("DELETE * FROM GRB_SoumProjSectionMec WHERE IDsection = " & lvwSection.FocusedItem.Tag)
					
					'Si le combo n'est pas vide, on sélectionne le premier
50: If lvwSection.Items.Count > 0 Then
55: 'UPGRADE_WARNING: Lower bound of collection lvwSection.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						lvwSection.Items.Item(1).Selected = True
60: End If
65: Else
70: Call MsgBox("Impossible de supprimer une section déjà utilisé dans une soumission!", MsgBoxStyle.OKOnly, "Erreur")
75: End If
				
				'Ferme la table
80: Call rstSoumission.Close()
85: 'UPGRADE_NOTE: Object rstSoumission may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstSoumission = Nothing
				
90: Call RemplirListViewSection()
95: End If
100: Else
105: Call MsgBox("Aucun enregistrement sélectionné!")
110: End If
		
115: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
120: Exit Sub
		
AfficherErreur: 
		
125: Call AfficherErreur("frmSoumissionSectionMec", "CmdSupp_Click", Err, Erl())
	End Sub
	
	Private Sub frmSoumissionSectionMec_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
		'Ouverture de la fenêtre
10: Call RemplirListViewSection()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmSoumissionSectionMec", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub lvwSection_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwSection.Click
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		'met les fleche enabled depandant si au debut ou a la fin
		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
10: If lvwSection.Items.Count > 0 Then
15: If lvwSection.FocusedItem.Index = lvwSection.Items.Count Then
20: cmdDown.Enabled = False
25: Else
30: cmdDown.Enabled = True
35: End If
			
40: If lvwSection.FocusedItem.Index = 1 Then
45: cmdUp.Enabled = False
50: Else
55: cmdUp.Enabled = True
60: End If
65: End If
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmSoumissionSectionMec", "lvwSection_Click", Err, Erl())
	End Sub
	
	Private Sub lvwSection_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwSection.DoubleClick
		
5: On Error GoTo AfficherErreur
		
10: txtFrancais.Text = lvwSection.FocusedItem.Text
15: 'UPGRADE_WARNING: Lower bound of collection lvwSection.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		txtAnglais.Text = lvwSection.FocusedItem.SubItems(I_COL_ANGLAIS).Text
		
20: fraAjout.Visible = True
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmSoumissionSectionMec", "lvwSection_DblClick", Err, Erl())
	End Sub
End Class