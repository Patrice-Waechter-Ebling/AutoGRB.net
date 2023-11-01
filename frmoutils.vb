Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmoutils
	Inherits System.Windows.Forms.Form
	
	Private m_bDateAchat As Boolean 'date d'achat=true ou horsfonction = false
	Private m_bModeAjouter As Boolean
	
	'UPGRADE_WARNING: Event cmbetiquette.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbetiquette_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbetiquette.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''''''''''''''
		'trouve le prochain no_outils automatique
		''''''''''''''''''''''''''''''''''''''''''
10: Dim rstOutils As ADODB.Recordset
		
15: rstOutils = New ADODB.Recordset
		
20: Call rstOutils.Open("SELECT * FROM GRB_Outils WHERE type_étiquette = '" & cmbetiquette.Text & "' ORDER BY no_outils DESC", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'incremente de un le dernier no outils
25: If Not rstOutils.EOF Then
30: If IsNumeric(rstOutils.Fields("no_outils").Value) Then
35: txtNo.Text = rstOutils.Fields("no_outils").Value + 1
40: Else
45: txtNo.Text = ""
50: End If
55: End If
		
		'ferme la table
60: Call rstOutils.Close()
65: 'UPGRADE_NOTE: Object rstOutils may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstOutils = Nothing
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmoutils", "cmbetiquette_Click", Err, Erl())
	End Sub
	
	Private Sub CmdAnul_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdAnul.Click
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''
		'affiche en mode visualisation
		'''''''''''''''''''''''''''''''
10: Call AfficherListe()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmoutils", "CmdAnul_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDateAchat_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDateAchat.Click
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''''''''''''
		'affiche pour choisir une date
		''''''''''''''''''''''''''''''''
10: m_bDateAchat = True
15: mvwDate.Visible = True
		
		'si pas de date met la date du jour
20: If IsDate(txtachat.Text) = True Then
25: mvwDate.Year = CShort(VB.Left(txtachat.Text, 4))
30: mvwDate.Month = CShort(Mid(txtachat.Text, 6, 2))
35: mvwDate.Day = CShort(VB.Right(txtachat.Text, 2))
40: Else
45: mvwDate.Value = Today
50: End If
		
55: Call mvwDate.Focus()
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmoutils", "cmdDateAchat_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDateHorsfonction_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDateHorsfonction.Click
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''''''''''''
		'affiche pour choisir une date
		''''''''''''''''''''''''''''''''
10: m_bDateAchat = False
		
15: mvwDate.Visible = True
		
		'si pas de date met la date du jour
20: If IsDate(txthorsfonction.Text) = True Then
25: mvwDate.Year = CShort(VB.Left(txthorsfonction.Text, 4))
30: mvwDate.Month = CShort(Mid(txthorsfonction.Text, 6, 2))
35: mvwDate.Day = CShort(VB.Right(txthorsfonction.Text, 2))
40: Else
45: mvwDate.Value = Today
50: End If
		
55: Call mvwDate.Focus()
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmoutils", "cmdDateHorsfonction_Click", Err, Erl())
	End Sub
	
	Private Sub CmdFerme_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdFerme.Click
		
5: On Error GoTo AfficherErreur
		
		'quitte fenetre
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmoutils", "CmdFerme_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRechercher_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercher.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstRecherche As ADODB.Recordset
15: Dim itmOutils As System.Windows.Forms.ListViewItem
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
25: Call lstoutils.Items.Clear()
		
30: rstRecherche = New ADODB.Recordset
		
35: Call rstRecherche.Open("SELECT * FROM GRB_Outils WHERE (Instr(1,CStr(no_outils),'" & txtRecherche.Text & "') > 0 OR Instr(1,nom_outils,'" & txtRecherche.Text & "') > 0) AND Departement = '" & Replace(cmbdepartement.Text, "'", "''") & "' ORDER BY no_outils", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
40: Do While Not rstRecherche.EOF
45: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lstoutils.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmOutils = lstoutils.Items.Add()
			
50: itmOutils.Text = rstRecherche.Fields("no_outils").Value
			
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstRecherche.Fields("nom_outils").Value) Then
60: 'UPGRADE_WARNING: Lower bound of collection itmOutils has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmOutils.SubItems.Count > 1 Then
					itmOutils.SubItems(1).Text = rstRecherche.Fields("nom_outils").Value
				Else
					itmOutils.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstRecherche.Fields("nom_outils").Value))
				End If
65: End If
			
70: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstRecherche.Fields("date_achat").Value) Then
75: 'UPGRADE_WARNING: Lower bound of collection itmOutils has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmOutils.SubItems.Count > 2 Then
					itmOutils.SubItems(2).Text = rstRecherche.Fields("date_achat").Value
				Else
					itmOutils.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstRecherche.Fields("date_achat").Value))
				End If
80: End If
			
85: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstRecherche.Fields("date_hors_fonction").Value) Then
90: 'UPGRADE_WARNING: Lower bound of collection itmOutils has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmOutils.SubItems.Count > 3 Then
					itmOutils.SubItems(3).Text = rstRecherche.Fields("date_hors_fonction").Value
				Else
					itmOutils.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstRecherche.Fields("date_hors_fonction").Value))
				End If
95: End If
			
100: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstRecherche.Fields("cout").Value) Then
105: 'UPGRADE_WARNING: Lower bound of collection itmOutils has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmOutils.SubItems.Count > 4 Then
					itmOutils.SubItems(4).Text = Conversion_Renamed(rstRecherche.Fields("cout"), ModuleMain.enumConvert.MODE_ARGENT)
				Else
					itmOutils.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(rstRecherche.Fields("cout"), ModuleMain.enumConvert.MODE_ARGENT)))
				End If
110: End If
			
115: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstRecherche.Fields("type_étiquette").Value) Then
120: 'UPGRADE_WARNING: Lower bound of collection itmOutils has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmOutils.SubItems.Count > 5 Then
					itmOutils.SubItems(5).Text = rstRecherche.Fields("type_étiquette").Value
				Else
					itmOutils.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstRecherche.Fields("type_étiquette").Value))
				End If
125: End If
			
130: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstRecherche.Fields("commentaire").Value) Then
135: 'UPGRADE_WARNING: Lower bound of collection itmOutils has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmOutils.SubItems.Count > 6 Then
					itmOutils.SubItems(6).Text = rstRecherche.Fields("commentaire").Value
				Else
					itmOutils.SubItems.Insert(6, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstRecherche.Fields("commentaire").Value))
				End If
140: End If
			
145: Call rstRecherche.MoveNext()
150: Loop 
		
155: Call rstRecherche.Close()
160: 'UPGRADE_NOTE: Object rstRecherche may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstRecherche = Nothing
		
165: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
170: Exit Sub
		
AfficherErreur: 
		
175: Call AfficherErreur("frmoutils", "cmdRechercher_Click", Err, Erl())
	End Sub
	
	Private Sub cmdreport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdreport.Click
		Dim DR_Outils_machinerie As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstOutils As ADODB.Recordset
		
15: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
20: rstOutils = New ADODB.Recordset
		
25: Call rstOutils.Open("SELECT * FROM GRB_outils WHERE departement = '" & Replace(cmbdepartement.Text, "'", "''") & "' ORDER BY no_outils", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		''''''''''''''''''''''''''''''''''''''''''
		'rapport liste d'outil pour un departement
		''''''''''''''''''''''''''''''''''''''''''
		
		'set le rapport
30: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Outils_machinerie.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Outils_machinerie.DataSource = rstOutils
		
		'contenu label
35: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Outils_machinerie.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Outils_machinerie.Sections("section2").Controls("lbldepartement").Caption = "Outils & machinerie " & LCase(rstOutils.Fields("departement").Value)
40: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Outils_machinerie.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Outils_machinerie.Sections("section3").Controls("lbldate").Caption = ConvertDate(Today)
45: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Outils_machinerie.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Outils_machinerie.Orientation = MSDataReportLib.OrientationConstants.rptOrientLandscape
		
		'affiche rapport
50: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Outils_machinerie.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_Outils_machinerie.Show(VB6.FormShowConstants.Modal)
		
55: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmoutils", "cmdreport_Click", Err, Erl())
	End Sub
	
	Private Sub frmoutils_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Call RemplirDepartement()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmoutils", "Form_Load", Err, Erl())
	End Sub
	
	Public Sub RemplirDepartement()
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''''''''''''''''''''''''''''''
		'remplis combo departement en mode visualisation
		'''''''''''''''''''''''''''''''''''''''''''''''''
10: Dim rstDepartement As ADODB.Recordset
		
15: rstDepartement = New ADODB.Recordset
		
20: Call rstDepartement.Open("SELECT DISTINCT departement FROM GRB_outils ORDER BY departement", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: Call cmbdepartement.Items.Clear()
		
		'rempli tant il y a des departement
30: Do While Not rstDepartement.EOF
35: Call cmbdepartement.Items.Add(rstDepartement.Fields("departement").Value)
			
40: Call rstDepartement.MoveNext()
45: Loop 
		
		'ferme la table
50: Call rstDepartement.Close()
55: 'UPGRADE_NOTE: Object rstDepartement may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstDepartement = Nothing
		
		'si il y a des departement ,selectionne par defaut
60: If cmbdepartement.Items.Count > 0 Then
65: cmbdepartement.SelectedIndex = 0
70: End If
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmoutils", "RemplirDepartement", Err, Erl())
	End Sub
	
	Public Sub RemplirEtiquette()
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''''''''''''''''',
		'remplis combo etiquette en mode modification
		''''''''''''''''''''''''''''''''''''''''''''''
10: Dim rstEtiquette As ADODB.Recordset
		
15: rstEtiquette = New ADODB.Recordset
		
20: Call rstEtiquette.Open("SELECT DISTINCT type_étiquette FROM GRB_outils ORDER BY type_étiquette", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: Call cmbetiquette.Items.Clear()
		
		'rempli tant il y a des type_étiquette
30: Do While Not rstEtiquette.EOF
35: Call cmbetiquette.Items.Add(rstEtiquette.Fields("type_étiquette").Value)
			
40: Call rstEtiquette.MoveNext()
45: Loop 
		
		'ferme la table
50: Call rstEtiquette.Close()
55: 'UPGRADE_NOTE: Object rstEtiquette may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEtiquette = Nothing
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmoutils", "RemplirEtiquette", Err, Erl())
	End Sub
	
	Public Sub RemplirDepartementModif()
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''''''''''''''''''''''''''''
		'remplis combo departement en mode modification
		'''''''''''''''''''''''''''''''''''''''''''''''
10: Dim rstDepartement As ADODB.Recordset
		
15: rstDepartement = New ADODB.Recordset
		
20: Call rstDepartement.Open("SELECT DISTINCT departement FROM GRB_outils ORDER BY departement", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: Call cmbdepartement_modif.Items.Clear()
		
		'rempli tant il y a des employé
30: Do While Not rstDepartement.EOF
35: Call cmbdepartement_modif.Items.Add(rstDepartement.Fields("departement").Value)
			
40: Call rstDepartement.MoveNext()
45: Loop 
		
		'ferme la table
50: Call rstDepartement.Close()
55: 'UPGRADE_NOTE: Object rstDepartement may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstDepartement = Nothing
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmoutils", "RemplirDepartementModif", Err, Erl())
	End Sub
	
	Public Sub RemplirListViewOutils()
		
5: On Error GoTo AfficherErreur
		
		'remplis lister une journée
10: Dim rstOutils As ADODB.Recordset
15: Dim itmOutils As System.Windows.Forms.ListViewItem
		
		'vide le lister
20: Call lstoutils.Items.Clear()
		
25: 'UPGRADE_ISSUE: MSComctlLib.ListView property lstoutils.Sorted was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		lstoutils.Sorted = False
		
30: rstOutils = New ADODB.Recordset
		
35: Call rstOutils.Open("SELECT * FROM GRB_outils WHERE departement = '" & Replace(cmbdepartement.Text, "'", "''") & "' ORDER BY no_outils", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'tant il y a de employé cedulé , ajoute dans lister
40: Do While Not rstOutils.EOF
45: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lstoutils.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmOutils = lstoutils.Items.Add()
			
50: itmOutils.Text = rstOutils.Fields("no_outils").Value
			
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstOutils.Fields("nom_outils").Value) Then
60: Call itmOutils.SubItems.Add(vbNullString)
65: Else
70: Call itmOutils.SubItems.Add(rstOutils.Fields("nom_outils").Value)
75: End If
			
80: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstOutils.Fields("date_achat").Value) Then
85: Call itmOutils.SubItems.Add(vbNullString)
90: Else
95: Call itmOutils.SubItems.Add(rstOutils.Fields("date_achat").Value)
100: End If
			
105: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstOutils.Fields("date_hors_fonction").Value) Then
110: Call itmOutils.SubItems.Add(vbNullString)
115: Else
120: Call itmOutils.SubItems.Add(rstOutils.Fields("date_hors_fonction").Value)
125: End If
			
130: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstOutils.Fields("cout").Value) Or rstOutils.Fields("Cout").Value = vbNullString Then
135: Call itmOutils.SubItems.Add(vbNullString)
140: Else
145: Call itmOutils.SubItems.Add(Conversion_Renamed(rstOutils.Fields("cout"), ModuleMain.enumConvert.MODE_ARGENT))
150: End If
			
155: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstOutils.Fields("type_étiquette").Value) Then
160: Call itmOutils.SubItems.Add(vbNullString)
165: Else
170: Call itmOutils.SubItems.Add(rstOutils.Fields("type_étiquette").Value)
175: End If
			
180: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstOutils.Fields("commentaire").Value) Then
185: Call itmOutils.SubItems.Add(vbNullString)
190: Else
195: Call itmOutils.SubItems.Add(rstOutils.Fields("commentaire").Value)
200: End If
			
205: Call rstOutils.MoveNext()
210: Loop 
		
		'ferme la table
215: Call rstOutils.Close()
220: 'UPGRADE_NOTE: Object rstOutils may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstOutils = Nothing
		
225: Exit Sub
		
AfficherErreur: 
		
230: Call AfficherErreur("frmoutils", "RemplirListViewOutils", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbdepartement.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbdepartement_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbdepartement.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'remplis le lister outil dependant le departement selectionné
15: Call RemplirListViewOutils()
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmoutils", "cmbdepartement_Click", Err, Erl())
	End Sub
	
	Private Sub CmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdAdd.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'proc qui permet d'ajouter un outils
15: m_bModeAjouter = True
		
		'affiche en mode modification
20: Call AfficherModif()
		
		'remplis les combo en mode modification
25: Call RemplirEtiquette()
30: Call RemplirDepartementModif()
		
		'vide les champs
35: txtachat.Text = vbNullString
40: txtcommentaire.Text = vbNullString
45: txtcout.Text = vbNullString
50: txthorsfonction.Text = vbNullString
55: txtNo.Text = vbNullString
60: txtoutils.Text = vbNullString
		
65: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmoutils", "CmdAdd_Click", Err, Erl())
	End Sub
	
	Private Sub AfficherModif()
		
5: On Error GoTo AfficherErreur
		
		'met visible les champ pour modifié ou ajouté
10: fraModif.Visible = True
15: lstoutils.Visible = False
20: cmbdepartement.Visible = False
25: lbldepartement.Visible = False
30: CmdAdd.Visible = False
35: CmdSupp.Visible = False
40: CmdModif.Visible = False
45: CmdEnr.Visible = True
50: CmdAnul.Visible = True
55: lblRecherche.Visible = False
60: txtRecherche.Visible = False
65: cmdRechercher.Visible = False
70: cmdReport.Visible = False
75: CmdFerme.Visible = False
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmoutils", "AfficherModif", Err, Erl())
	End Sub
	
	Private Sub AfficherListe()
		
5: On Error GoTo AfficherErreur
		
		'met visible les champ pour modifié ou ajouté
10: fraModif.Visible = False
15: lstoutils.Visible = True
20: cmbdepartement.Visible = True
25: lbldepartement.Visible = True
30: CmdAdd.Visible = True
35: CmdSupp.Visible = True
40: CmdModif.Visible = True
45: CmdEnr.Visible = False
50: CmdAnul.Visible = False
55: lblRecherche.Visible = True
60: txtRecherche.Visible = True
65: cmdRechercher.Visible = True
70: cmdReport.Visible = True
75: CmdFerme.Visible = True
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmoutils", "AfficherListe", Err, Erl())
	End Sub
	
	Private Sub CmdModif_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdModif.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstOutils As ADODB.Recordset
		
15: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'proc qui permet d'ajouter un outils
20: m_bModeAjouter = False
		
		'affiche en mode modification
25: Call AfficherModif()
		
		'remplis les combo en mode modification
30: Call RemplirEtiquette()
35: Call RemplirDepartementModif()
		
40: If lstoutils.Items.Count > 0 Then
			'ouvre la table
45: rstOutils = New ADODB.Recordset
			
50: Call rstOutils.Open("SELECT * FROM GRB_outils WHERE no_outils = '" & lstoutils.FocusedItem.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
55: Me.cmbdepartement_modif.Text = rstOutils.Fields("departement").Value
60: Me.cmbetiquette.Text = rstOutils.Fields("type_étiquette").Value
65: Me.txtNo.Text = rstOutils.Fields("no_outils").Value
			
70: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstOutils.Fields("nom_outils").Value) Then
75: txtoutils.Text = vbNullString
80: Else
85: txtoutils.Text = rstOutils.Fields("nom_outils").Value
90: End If
			
95: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstOutils.Fields("cout").Value) Then
100: txtcout.Text = vbNullString
105: Else
110: txtcout.Text = rstOutils.Fields("cout").Value
115: End If
			
120: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstOutils.Fields("date_achat").Value) Then
125: txtachat.Text = rstOutils.Fields("date_achat").Value
130: Else
135: txtachat.Text = vbNullString
140: End If
			
145: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstOutils.Fields("date_hors_fonction").Value) Then
150: txthorsfonction.Text = rstOutils.Fields("date_hors_fonction").Value
155: Else
160: txthorsfonction.Text = vbNullString
165: End If
			
170: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstOutils.Fields("commentaire").Value) Then
175: txtcommentaire.Text = vbNullString
180: Else
185: txtcommentaire.Text = rstOutils.Fields("commentaire").Value
190: End If
			
			'ferme la table
195: Call rstOutils.Close()
200: 'UPGRADE_NOTE: Object rstOutils may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstOutils = Nothing
205: End If
		
210: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
215: Exit Sub
		
AfficherErreur: 
		
220: Call AfficherErreur("frmoutils", "CmdModif_Click", Err, Erl())
	End Sub
	
	Private Sub CmdSupp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdSupp.Click
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''''
		'Supprime l'outils selectionné
		''''''''''''''''''''''''''''''''
10: If lstoutils.Items.Count > 0 Then
15: If MsgBox("Voulez-vous supprimer cette enregistrement?", MsgBoxStyle.YesNo, "Supprimer") = MsgBoxResult.Yes Then
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
25: Call g_connData.Execute("DELETE * FROM GRB_outils WHERE no_outils = '" & lstoutils.FocusedItem.Text & "'")
				
				'mise a jour des lister
30: Call RemplirListViewOutils()
				
35: Call RemplirDepartement()
				
40: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
45: End If
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmoutils", "CmdSupp_Click", Err, Erl())
	End Sub
	
	Private Sub CmdEnr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdEnr.Click
		
5: On Error GoTo AfficherErreur
		
		'enregistre
10: Dim rstOutils As ADODB.Recordset
15: Dim rstVerifModif As ADODB.Recordset
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
25: If cmbdepartement.Text = vbNullString Or cmbetiquette.Text = vbNullString Or txtNo.Text = vbNullString Then
30: Call MsgBox("Champs vide!", MsgBoxStyle.OKOnly, "Erreur")
			
35: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			
40: Exit Sub
45: End If
		
50: If (Len(txtachat.Text) = 0 Or (Len(txtachat.Text) > 1 And IsDate(txtachat.Text))) And (Len(txthorsfonction.Text) = 0 Or (Len(txthorsfonction.Text) > 1 And IsDate(txthorsfonction.Text))) Then
			'ouvre la table
55: rstOutils = New ADODB.Recordset
			
60: If m_bModeAjouter = True Then
65: Call rstOutils.Open("SELECT * FROM GRB_outils WHERE no_outils = '" & txtNo.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
70: If Not rstOutils.EOF Then
75: Call MsgBox("Le numéro d'outils existe déjà!", MsgBoxStyle.OKOnly, "Erreur")
					
80: Call rstOutils.Close()
85: 'UPGRADE_NOTE: Object rstOutils may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstOutils = Nothing
					
90: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
					
95: Exit Sub
100: End If
				
105: Call rstOutils.AddNew()
110: Else
115: Call rstOutils.Open("SELECT * FROM GRB_outils WHERE no_outils = '" & txtNo.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
120: End If
			
			''''''''''''''''''''''''''
			'ajoute l'enregistrement
			''''''''''''''''''''''''''
125: rstOutils.Fields("departement").Value = cmbdepartement_modif.Text
130: rstOutils.Fields("type_étiquette").Value = cmbetiquette.Text
135: rstOutils.Fields("no_outils").Value = txtNo.Text
140: rstOutils.Fields("nom_outils").Value = txtoutils.Text
145: rstOutils.Fields("cout").Value = txtcout.Text
150: rstOutils.Fields("date_achat").Value = txtachat.Text
155: rstOutils.Fields("date_hors_fonction").Value = txthorsfonction.Text
160: rstOutils.Fields("commentaire").Value = txtcommentaire.Text
			
165: Call rstOutils.Update()
			
			'quitte ecran pour ajouté ou modifié
170: Call AfficherListe()
			
175: Call rstOutils.Close()
180: 'UPGRADE_NOTE: Object rstOutils may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstOutils = Nothing
			
			'met a jour l'écran
185: Call RemplirListViewOutils()
			
190: Call RemplirDepartement()
195: Else
200: Call MsgBox("La date est invalide! (aaaa-mm-jj)",  , "Erreur")
205: End If
		
210: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
215: Exit Sub
		
AfficherErreur: 
		
220: Call AfficherErreur("frmoutils", "CmdEnr_Click", Err, Erl())
	End Sub
	
	Private Sub lstoutils_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstoutils.DoubleClick
		
5: On Error GoTo AfficherErreur
		
		'affiche l'écran en mode modification
10: Call CmdModif_Click(CmdModif, New System.EventArgs())
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmoutils", "lstoutils_DblClick", Err, Erl())
	End Sub
	
	Private Sub lstoutils_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lstoutils.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: If lstoutils.Items.Count > 0 Then
15: If KeyCode = System.Windows.Forms.Keys.Delete Then
20: If MsgBox("Voulez-vous supprimer cette enregistrement?", MsgBoxStyle.YesNo, "Supprimer") = MsgBoxResult.Yes Then
25: Call g_connData.Execute("DELETE * FROM GRB_outils WHERE no_outils = '" & lstoutils.FocusedItem.Text & "'")
					
					'mise a jour des lister
30: Call RemplirListViewOutils()
35: End If
40: End If
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmoutils", "lstoutils_KeyDown", Err, Erl())
	End Sub
	
	Private Sub mvwDate_DateClick(ByVal eventSender As System.Object, ByVal eventArgs As AxMSComCtl2.DMonthViewEvents_DateClickEvent) Handles mvwDate.DateClick
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''''''''''''''''''''''
		'affiche dans l'écran la date sélectionné
		'''''''''''''''''''''''''''''''''''''''''
10: Dim sDate As String
		
		'ajoute dans le champ text la date selectionné
15: If m_bDateAchat = True Then
20: txtachat.Text = ConvertDate(eventArgs.DateClicked)
25: Else
30: txthorsfonction.Text = ConvertDate(eventArgs.DateClicked)
35: End If
		
40: mvwDate.Visible = False
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmoutils", "mvwDate_DateClick", Err, Erl())
	End Sub
	
	Private Sub mvwDate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mvwDate.Leave
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''''
		'lorsque clique ailleur cache
		'''''''''''''''''''''''''''''''
10: mvwDate.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmoutils", "mvwDate_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtachat_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtachat.Enter
		
5: On Error GoTo AfficherErreur
		
		'met l'année 2caratere
10: If Len(txtachat.Text) = 10 Then
15: txtachat.Text = VB.Right(txtachat.Text, 8)
20: End If
		
		'met le mask
25: txtachat.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmoutils", "txtachat_GotFocus", Err, Erl())
	End Sub
	
	Private Sub txtachat_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtachat.Leave
		
5: On Error GoTo AfficherErreur
		
		'enleve le mask
10: txtachat.Mask = vbNullString
		
		'losque est vide , enleve les caratere du masque
15: If txtachat.Text = "__-__-__" Then
20: txtachat.Text = vbNullString
25: End If
		
		'met l'année 4 caractere
30: If Len(txtachat.Text) = 8 Then
35: If IsDate(txtachat.Text) Then
40: txtachat.Text = Trim(CStr(Year(DateSerial(CInt(Mid(txtachat.Text, 1, 2)), CInt(Mid(txtachat.Text, 4, 2)), CInt(Mid(txtachat.Text, 7, 2)))))) & Mid(txtachat.Text, 3, 8)
45: End If
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmoutils", "txtachat_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtcout_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtcout.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtcout.Text = Replace(txtcout.Text, ".", ",")
		
15: If Not IsNumeric(txtcout.Text) Then
20: Call MsgBox("Valeur non numérique!", MsgBoxStyle.OKOnly, "Erreur")
			
25: txtcout.Text = ""
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmoutils", "txtcout_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txthorsfonction_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txthorsfonction.Enter
		
5: On Error GoTo AfficherErreur
		
		'met l'année 2caratere
10: If Len(txthorsfonction.Text) = 10 Then
15: txthorsfonction.Text = VB.Right(txthorsfonction.Text, 8)
20: End If
		
		'met le mask
25: txthorsfonction.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmoutils", "txthorsfonction_GotFocus", Err, Erl())
	End Sub
	
	Private Sub txthorsfonction_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txthorsfonction.Leave
		
5: On Error GoTo AfficherErreur
		
		'enleve le mask
10: txthorsfonction.Mask = vbNullString
		
		'losque est vide , enleve les caratere du masque
15: If txthorsfonction.Text = "__-__-__" Then
20: txthorsfonction.Text = vbNullString
25: End If
		
		'met l'année 4 caractere
30: If Len(txthorsfonction.Text) = 8 Then
35: If IsDate(txthorsfonction.Text) Then
40: txthorsfonction.Text = Trim(CStr(Year(DateSerial(CInt(Mid(txthorsfonction.Text, 1, 2)), CInt(Mid(txthorsfonction.Text, 4, 2)), CInt(Mid(txthorsfonction.Text, 7, 2)))))) & Mid(txthorsfonction.Text, 3, 8)
45: End If
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmoutils", "txthorsfonction_LostFocus", Err, Erl())
	End Sub
End Class