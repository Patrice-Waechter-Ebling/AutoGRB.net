Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FrmOutils_InOut
	Inherits System.Windows.Forms.Form
	
	'UPGRADE_WARNING: Event chknonRetour.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chknonRetour_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chknonRetour.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'remplis le lister dependant si retourné ou pas
15: Call remplir_lister_outils()
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmOutils_InOut", "chknonRetour_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbEmployé.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbEmployé_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbEmployé.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'remplis le lister dependant l'employé selectionné
15: Call remplir_lister_outils()
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmOutils_InOut", "cmbEmployé_Click", Err, Erl())
	End Sub
	
	Private Sub CmdAnul_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdAnul.Click
		
5: On Error GoTo AfficherErreur
		
		'affiche mode liste
10: fraOutils.Visible = False
15: lstoutils.Visible = True
20: cmbemployé.Visible = True
25: lblemployé.Visible = True
30: chknonRetour.Visible = True
		
		'remplis le lister
35: Call remplir_lister_outils()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmOutils_InOut", "CmdAnul_Click", Err, Erl())
	End Sub
	
	Private Sub cmdConfig_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdConfig.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'affiche ecran pour ajouter modifier un outils
15: Call OuvrirForm(frmoutils, True)
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmOutils_InOut", "cmdConfig_Click", Err, Erl())
	End Sub
	
	Private Sub CmdEnr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdEnr.Click
		
5: On Error GoTo AfficherErreur
		
		'enregistre
10: Dim rstOutils As ADODB.Recordset
15: Dim rstOutilsInOut As ADODB.Recordset
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
25: If IsNumeric(txtno.Text) Then
			'ouvre la table
30: rstOutils = New ADODB.Recordset
			
35: Call rstOutils.Open("SELECT * FROM GRB_outils WHERE no_outils = '" & txtno.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'si existe on peut l'ajouter
40: If Not rstOutils.EOF Then
				'ouvre la table avec une recherche sur l'outils étant non-retourné
45: rstOutilsInOut = New ADODB.Recordset
				
50: Call rstOutilsInOut.Open("SELECT GRB_Outils_In_out.*, GRB_employés.employe FROM GRB_Outils_In_out INNER JOIN GRB_employés ON GRB_Outils_In_out.no_employe = GRB_employés.noemploye WHERE no_outils = " & txtno.Text & " AND retour_date_heure is null", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
55: If rstOutilsInOut.EOF Then
					'ajoute
60: Call rstOutilsInOut.AddNew()
					
65: rstOutilsInOut.Fields("no_outils").Value = txtno.Text
70: rstOutilsInOut.Fields("no_employe").Value = txtemploye.Tag
75: rstOutilsInOut.Fields("depart_date_heure").Value = txtdepart.Text
80: rstOutilsInOut.Fields("commentaire").Value = txtcommentaire.Text
					
85: Call rstOutilsInOut.Update()
					
					'vide les champs
90: Call vider_champs()
95: Else
100: If MsgBox("L'outils n'a pas été retourné par " & rstOutilsInOut.Fields("employe").Value & ", voulez-vous retourner l'outil pour cet employé?", MsgBoxStyle.YesNo, CStr(rstOutils.Fields("no_outils").Value) & " " + rstOutils.Fields("nom_outils").Value) = MsgBoxResult.Yes Then
						'retourne l'outils pour l'employé
105: rstOutilsInOut.Fields("commentaire").Value = "(Retourné par: " & CStr(g_sEmploye) & ") " & CStr(rstOutilsInOut.Fields("commentaire").Value)
110: rstOutilsInOut.Fields("retour_date_heure").Value = CStr(Year(Now)) & "-" & VB.Right("0" & CStr(Month(Now)), 2) & "-" & VB.Right("0" & CStr(VB.Day(Now)), 2) & " " & CStr(TimeOfDay)
						
115: Call rstOutilsInOut.Update()
						
						'ajoute
120: Call rstOutilsInOut.AddNew()
						
125: rstOutilsInOut.Fields("no_outils").Value = txtno.Text
130: rstOutilsInOut.Fields("no_employe").Value = txtemploye.Tag
135: rstOutilsInOut.Fields("depart_date_heure").Value = txtdepart.Text
140: rstOutilsInOut.Fields("commentaire").Value = txtcommentaire.Text
						
145: Call rstOutilsInOut.Update()
						
						'vide les champs
150: Call vider_champs()
155: End If
160: End If
				
				'quitte la table
165: Call rstOutilsInOut.Close()
170: 'UPGRADE_NOTE: Object rstOutilsInOut may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstOutilsInOut = Nothing
				
175: Call txtno.Focus()
180: Else
185: Call MsgBox("Le numéro de l'outil n'existe pas!",  , "Erreur")
190: End If
195: Else
200: Call MsgBox("Le numéro doit être numérique!",  , "Erreur")
205: End If
		
210: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
215: Exit Sub
		
AfficherErreur: 
		
220: Call AfficherErreur("frmOutils_InOut", "CmdEnr_Click", Err, Erl())
	End Sub
	
	Private Sub CmdFerme_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdFerme.Click
		
5: On Error GoTo AfficherErreur
		
		'quitte la fenetre
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmOutils_InOut", "CmdFerme_Click", Err, Erl())
	End Sub
	
	Public Sub remplir_lister_outils()
		
5: On Error GoTo AfficherErreur
		
		'remplis lister une journée
10: Dim rstOutils As ADODB.Recordset
15: Dim rstOutilsInOut As ADODB.Recordset
20: Dim rstEmploye As ADODB.Recordset
25: Dim itmOutils As System.Windows.Forms.ListViewItem
		
		'vide le lister
30: Call lstoutils.Items.Clear()
35: 'UPGRADE_ISSUE: MSComctlLib.ListView property lstoutils.Sorted was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		lstoutils.Sorted = False
		
40: rstOutilsInOut = New ADODB.Recordset
		'affiche tout les employes si = *
45: If cmbemployé.Text = "*" Then
			'affiche les non-retournés si est coché, sinon affiche retourné et non
50: If chknonRetour.CheckState = System.Windows.Forms.CheckState.Checked Then
55: Call rstOutilsInOut.Open("SELECT * FROM GRB_outils_in_out WHERE retour_date_heure is null ORDER BY no_enreg", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
60: Else
65: Call rstOutilsInOut.Open("SELECT * FROM GRB_outils_in_out ORDER BY no_enreg", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
70: End If
75: Else
			'affiche pour un employé et
			'affiche les non-retourné si est coché, sinon affiche retourné et non retourné
80: If chknonRetour.CheckState = System.Windows.Forms.CheckState.Checked Then
85: Call rstOutilsInOut.Open("SELECT * FROM GRB_outils_in_out WHERE CStr(no_employe) = CStr('" & VB6.GetItemData(cmbemployé, cmbemployé.SelectedIndex) & "') AND retour_date_heure is null ORDER BY no_enreg", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
90: Else
95: Call rstOutilsInOut.Open("SELECT * FROM GRB_outils_in_out WHERE CStr(no_employe) = CStr('" & VB6.GetItemData(cmbemployé, cmbemployé.SelectedIndex) & "') ORDER BY no_enreg", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
100: End If
105: End If
		
110: rstOutils = New ADODB.Recordset
115: rstEmploye = New ADODB.Recordset
		
120: Do While Not rstOutilsInOut.EOF
125: Call rstOutils.Open("SELECT * FROM GRB_outils WHERE CStr(no_outils) = CStr('" & rstOutilsInOut.Fields("no_outils").Value & "') ORDER BY no_outils", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
130: Call rstEmploye.Open("SELECT * FROM GRB_employés WHERE CStr(noemploye) = CStr('" & rstOutilsInOut.Fields("no_employe").Value & "') ORDER BY noemploye", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'ajoute dans lister
135: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lstoutils.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmOutils = lstoutils.Items.Add()
			
140: itmOutils.Text = (rstOutils.Fields("no_outils")).Value
145: itmOutils.Tag = rstOutilsInOut.Fields("no_enreg").Value
			
150: Call itmOutils.SubItems.Add(rstOutils.Fields("nom_outils").Value)
155: Call itmOutils.SubItems.Add(rstEmploye.Fields("employe").Value)
160: 'UPGRADE_WARNING: Lower bound of collection itmOutils.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmOutils.SubItems.Item(2).Tag = rstEmploye.Fields("loginname").Value
165: Call itmOutils.SubItems.Add(rstOutilsInOut.Fields("depart_date_heure").Value)
			
170: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstOutilsInOut.Fields("retour_date_heure").Value) Then
175: Call itmOutils.SubItems.Add(vbNullString)
180: Else
185: Call itmOutils.SubItems.Add(rstOutilsInOut.Fields("retour_date_heure").Value)
190: End If
			
195: Call itmOutils.SubItems.Add(rstOutils.Fields("departement").Value)
200: Call itmOutils.SubItems.Add(rstOutilsInOut.Fields("commentaire").Value)
			
205: Call rstOutilsInOut.MoveNext()
			
			'ferme la table
210: Call rstOutils.Close()
215: Call rstEmploye.Close()
220: Loop 
		
225: Call lstoutils.Refresh()
		
230: 'UPGRADE_NOTE: Object rstOutils may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstOutils = Nothing
235: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
		'ferme la table
240: Call rstOutilsInOut.Close()
245: 'UPGRADE_NOTE: Object rstOutilsInOut may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstOutilsInOut = Nothing
		
250: Exit Sub
		
AfficherErreur: 
		
255: Call AfficherErreur("frmOutils_InOut", "remplir_lister_outils", Err, Erl())
	End Sub
	
	Public Sub remplir_cmbemploye()
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''''''''''''''''',
		'remplis combo etiquette en mode modification
		''''''''''''''''''''''''''''''''''''''''''''''
10: Dim rstEmploye As ADODB.Recordset
		
15: rstEmploye = New ADODB.Recordset
		
20: Call rstEmploye.Open("SELECT NoEmploye, Employe FROM GRB_employés WHERE Actif = true ORDER BY employe", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: Call cmbemployé.Items.Clear()
		
30: Call cmbemployé.Items.Add("*")
		'rempli tant il y a des type_étiquette
		
35: Do While Not rstEmploye.EOF
40: Call cmbemployé.Items.Add(rstEmploye.Fields("employe").Value)
45: 'UPGRADE_ISSUE: ComboBox property cmbemployé.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbemployé, cmbemployé.NewIndex, rstEmploye.Fields("noEmploye").Value)
			
50: Call rstEmploye.MoveNext()
55: Loop 
		
		'ferme la table
60: Call rstEmploye.Close()
65: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmOutils_InOut", "remplir_cmbemploye", Err, Erl())
	End Sub
	
	Private Sub cmdreport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdreport.Click
		Dim DR_Outils_in_out As Object
		
5: On Error GoTo AfficherErreur
		
		'affiche rapport filtré par les selection a l'ecran
10: Dim rstOutilsInOut As ADODB.Recordset
		
15: rstOutilsInOut = New ADODB.Recordset
		
		'si tout les employé
20: If cmbemployé.Text = "*" Then
			'affiche les non-retournés si est coché, sinon affiche retourné et non
25: If chknonRetour.CheckState = System.Windows.Forms.CheckState.Checked Then
30: Call rstOutilsInOut.Open("SELECT GRB_Outils_In_out.*, GRB_employés.employe, GRB_Outils.nom_outils, GRB_Outils.departement FROM GRB_employés INNER JOIN (GRB_Outils_In_out INNER JOIN GRB_Outils ON CStr(GRB_Outils_In_out.no_outils) = GRB_Outils.no_outils) ON GRB_employés.noemploye = GRB_Outils_In_out.no_employe WHERE retour_date_heure is null ORDER BY no_enreg", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
35: Else
40: Call rstOutilsInOut.Open("SELECT GRB_Outils_In_out.*, GRB_employés.employe, GRB_Outils.nom_outils, GRB_Outils.departement FROM GRB_employés INNER JOIN (GRB_Outils_In_out INNER JOIN GRB_Outils ON CStr(GRB_Outils_In_out.no_outils) = GRB_Outils.no_outils) ON GRB_employés.noemploye = GRB_Outils_In_out.no_employe ORDER BY no_enreg", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
45: End If
50: Else
			'affiche pour un employé et
			'affiche les non-retourné si est coché, sinon affiche retourné et non retourné
55: If chknonRetour.CheckState = System.Windows.Forms.CheckState.Checked Then
60: Call rstOutilsInOut.Open("SELECT GRB_Outils_In_out.*, GRB_employés.employe, GRB_Outils.nom_outils, GRB_Outils.departement FROM GRB_employés INNER JOIN (GRB_Outils_In_out INNER JOIN GRB_Outils ON CStr(GRB_Outils_In_out.no_outils) = GRB_Outils.no_outils) ON GRB_employés.noemploye = GRB_Outils_In_out.no_employe WHERE CStr(no_employe) = CStr('" & VB6.GetItemData(cmbemployé, cmbemployé.SelectedIndex) & "') AND retour_date_heure is null ORDER BY no_enreg", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
65: Else
70: Call rstOutilsInOut.Open("SELECT GRB_Outils_In_out.*, GRB_employés.employe, GRB_Outils.nom_outils, GRB_Outils.departement FROM GRB_employés INNER JOIN (GRB_Outils_In_out INNER JOIN GRB_Outils ON CStr(GRB_Outils_In_out.no_outils) = GRB_Outils.no_outils) ON GRB_employés.noemploye = GRB_Outils_In_out.no_employe WHERE CStr(no_employe) = CStr('" & VB6.GetItemData(cmbemployé, cmbemployé.SelectedIndex) & "') ORDER BY no_enreg", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
75: End If
80: End If
		
		''''''''''''''''''''''''''''''''''''''''''
		'rapport liste d'outil pour un departement
		''''''''''''''''''''''''''''''''''''''''''
		'set le rapport
85: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Outils_in_out.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Outils_in_out.DataSource = rstOutilsInOut
		
		'contenu label
90: If chknonRetour.CheckState = System.Windows.Forms.CheckState.Checked Then
95: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Outils_in_out.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Outils_in_out.Sections("section2").Controls("lbldepartement").Caption = "Liste des outils non-retourné"
100: Else
105: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Outils_in_out.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Outils_in_out.Sections("section2").Controls("lbldepartement").Caption = "Liste des outils empruntés"
110: End If
		
115: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Outils_in_out.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Outils_in_out.Sections("section3").Controls("lbldate").Caption = CStr(Year(Now)) & "-" & CStr(Month(Now)) & "-" & CStr(VB.Day(Now))
		
120: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Outils_in_out.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Outils_in_out.Orientation = MSDataReportLib.OrientationConstants.rptOrientLandscape
		
		'affiche rapport
125: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Outils_in_out.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_Outils_in_out.Show(VB6.FormShowConstants.Modal)
		
130: Exit Sub
		
AfficherErreur: 
		
135: Call AfficherErreur("frmOutils_InOut", "cmdreport_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRetour_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRetour.Click
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''''''''''''''''
		'retourne les outils selectionné
		'''''''''''''''''''''''''''''''''''
10: Dim rstOutilsInOut As ADODB.Recordset
15: Dim iCompteur As Short
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
25: rstOutilsInOut = New ADODB.Recordset
		
		'tant que pas fin du lister
30: For iCompteur = 1 To lstoutils.Items.Count
			'si l'enreg du lister est selectionné, on modifie dans la bd
35: 'UPGRADE_WARNING: Lower bound of collection lstoutils.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lstoutils.Items.Item(iCompteur).Selected = True Then
				'ouvre la table sur l'enreg selectionné dans le lister
				
40: 'UPGRADE_WARNING: Lower bound of collection lstoutils.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				Call rstOutilsInOut.Open("SELECT * FROM GRB_outils_in_out WHERE CStr(no_enreg) = CStr('" & lstoutils.Items.Item(iCompteur).Tag & "') ORDER BY no_outils", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				'met la date d'aujourd'hui si pas null
				
45: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If IsDbNull(rstOutilsInOut.Fields("retour_date_heure").Value) Then
					'si c'est un autre employé, on ajoute dans commentaire l'employé qui a retourné l'outil
50: 'UPGRADE_WARNING: Lower bound of collection lstoutils.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lstoutils.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If g_sUserID <> lstoutils.Items.Item(iCompteur).SubItems.Item(2).Tag Then
55: rstOutilsInOut.Fields("Commentaire").Value = "(Retourné par: " & g_sEmploye & ")" + rstOutilsInOut.Fields("Commentaire").Value
60: End If
					
65: rstOutilsInOut.Fields("retour_date_heure").Value = CStr(Year(Now)) & "-" & VB.Right("0" & CStr(Month(Now)), 2) & "-" & VB.Right("0" & CStr(VB.Day(Now)), 2) & " " & CStr(TimeOfDay)
					
70: Call rstOutilsInOut.Update()
75: End If
				
				'ferme la table
80: Call rstOutilsInOut.Close()
85: 'UPGRADE_NOTE: Object rstOutilsInOut may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstOutilsInOut = Nothing
90: End If
95: Next 
		
		'met a jour le lister
100: Call remplir_lister_outils()
		
105: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
110: Exit Sub
		
AfficherErreur: 
		
115: Call AfficherErreur("frmOutils_InOut", "cmdretour_Click", Err, Erl())
	End Sub
	
	Private Sub cmdsortie_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdsortie.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'affiche en mode ajout
15: fraOutils.Visible = True
20: lstoutils.Visible = False
25: cmbemployé.Visible = False
30: lblemployé.Visible = False
35: chknonRetour.Visible = False
40: Call txtno.Focus()
		
45: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmOutils_InOut", "cmdsortie_Click", Err, Erl())
	End Sub
	
	Private Sub ActiverBoutonsGroupe()
		
5: On Error GoTo AfficherErreur
		
10: cmdConfig.Enabled = g_bModificationOutils
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmOutils_InOut", "ActiverBoutonsGroupe", Err, Erl())
	End Sub
	
	Private Sub FrmOutils_InOut_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmploye As ADODB.Recordset
15: Dim iCompteur As Short
20: Dim iNoEmploye As Short
25: Dim bEmpExiste As Boolean
		
30: Call frmChoixInventaire.Close()
		
		'rempli le combo employe
35: Call remplir_cmbemploye()
		
		'si il y a des employes ,selectionne par defaut
40: If cmbemployé.Items.Count > 0 Then
45: rstEmploye = New ADODB.Recordset
			
50: Call rstEmploye.Open("SELECT * FROM GRB_employés WHERE loginname = '" & g_sUserID & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'select l'employé logué sinon, affiche tout
55: If rstEmploye.EOF Then
60: bEmpExiste = False
65: Else
70: bEmpExiste = True
				
75: iNoEmploye = rstEmploye.Fields("noEmploye").Value
80: End If
			
85: Call rstEmploye.Close()
90: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstEmploye = Nothing
			
95: If bEmpExiste = False Then
100: cmbemployé.SelectedIndex = 0
105: Else
				'on trouve l'index dans le combo qui contient le noemploye, pour le selectionné
110: For iCompteur = 0 To cmbemployé.Items.Count - 1
					'si trouvé noemploye, on selectione cet index
115: If VB6.GetItemData(cmbemployé, iCompteur) = iNoEmploye Then
120: cmbemployé.SelectedIndex = iCompteur
						
125: Exit For
130: End If
135: Next 
140: End If
145: End If
		
		'met enabled le bouton config dependant le user
150: Call ActiverBoutonsGroupe()
		
155: Exit Sub
		
AfficherErreur: 
		
160: Call AfficherErreur("frmOutils_InOut", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub txtno_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtno.Leave
		
5: On Error GoTo AfficherErreur
		
		
		'affiche automatique le nom de l'outils et l'employé et la date de sortie
10: Dim rstOutils As ADODB.Recordset
15: Dim rstEmploye As ADODB.Recordset
		
20: If IsNumeric(txtno.Text) Then
25: rstOutils = New ADODB.Recordset
			
30: Call rstOutils.Open("SELECT * FROM GRB_outils WHERE no_outils = '" & txtno.Text & "' ORDER BY no_outils", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'si no outils existe
35: If Not rstOutils.EOF Then
				'affiche nom outils et date sortie
40: txtnom.Text = rstOutils.Fields("nom_outils").Value
45: txtdepart.Text = CStr(Year(Now)) & "-" & VB.Right("0" & CStr(Month(Now)), 2) & "-" & VB.Right("0" & CStr(VB.Day(Now)), 2) & " " & CStr(TimeOfDay)
50: txtdepartement.Text = rstOutils.Fields("departement").Value
				
				'affiche l'employe
55: rstEmploye = New ADODB.Recordset
				
60: Call rstEmploye.Open("SELECT * FROM GRB_employés WHERE loginname = '" & g_sUserID & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
65: txtemploye.Text = rstEmploye.Fields("employe").Value
70: txtemploye.Tag = rstEmploye.Fields("noEmploye").Value
				
				'ferme la table
75: Call rstEmploye.Close()
80: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstEmploye = Nothing
85: Else
90: Call vider_champs()
95: End If
			
			'ferme la table
100: Call rstOutils.Close()
105: 'UPGRADE_NOTE: Object rstOutils may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstOutils = Nothing
110: Else
115: Call vider_champs()
120: End If
		
125: Exit Sub
		
AfficherErreur: 
		
130: Call AfficherErreur("frmOutils_InOut", "txtno_LostFocus", Err, Erl())
	End Sub
	
	Private Sub vider_champs()
		
5: On Error GoTo AfficherErreur
		'vide les champs
10: txtcommentaire.Text = vbNullString
15: txtdepart.Text = vbNullString
20: txtdepartement.Text = vbNullString
25: txtemploye.Text = vbNullString
30: txtno.Text = vbNullString
35: txtnom.Text = vbNullString
40: txtsortie.Text = vbNullString
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmOutils_InOut", "vider_champs", Err, Erl())
	End Sub
End Class