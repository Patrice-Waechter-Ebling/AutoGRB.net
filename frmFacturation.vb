Option Strict Off
Option Explicit On
Friend Class frmFacturation
	Inherits System.Windows.Forms.Form
	
	'Index des colonnes du listview
	Private Const I_LVW_EMPLOYE As Short = 0
	Private Const I_LVW_DATE As Short = 1
	Private Const I_LVW_DEBUT As Short = 2
	Private Const I_LVW_FIN As Short = 3
	Private Const I_LVW_DESCRIPTION As Short = 4
	Private Const I_LVW_TOTAL As Short = 5
	Private Const I_LVW_NO_FACTURE As Short = 6
	Private Const I_LVW_TYPE As Short = 7
	
	
	'Index de optType
	Private Const I_OPT_TYPE_ELECTRIQUE As Short = 0
	Private Const I_OPT_TYPE_MECANIQUE As Short = 1
	Private Const I_OPT_TYPE_TOUS As Short = 2
	
	'Index du combo
	Private Const I_CMB_PROJET As Short = 0
	Private Const I_CMB_SOUMISSION As Short = 1
	
	'Caption du bouton cmdFacturerRectifier
	Private Const S_FACTURER As String = "Facturer"
	Private Const S_RECTIFIER As String = "Rectifier"
	Private Const S_NC As String = "NC"
	
	'Caption des Option Buttons
	'Si c'est un projet
	Private Const S_PROJ_OUVERT As String = "Ouverts"
	Private Const S_PROJ_FERME As String = "Fermés"
	Private Const S_PROJ_TOUS As String = "Tous"
	
	'Si c'est une soumission
	Private Const S_SOUM_OUVERT As String = "Ouvertes"
	Private Const S_SOUM_FERME As String = "Fermées"
	Private Const S_SOUM_TOUS As String = "Toutes"
	
	'Caption de fraMontrer
	Private Const S_FRA_PROJ As String = "Projets"
	Private Const S_FRA_SOUM As String = "Soumissions"
	
	'Index des Option Buttons
	Private Const I_OPT_TOUS As Short = 0
	Private Const I_OPT_OUVERT As Short = 1
	Private Const I_OPT_FERME As Short = 2
	
	Private Enum enumType
		TYPE_PROJET = 0
		TYPE_SOUMISSION = 1
	End Enum
	
	Private m_eType As enumType
	
	Public m_iIDClient As Short
	Public m_sDescription As String
	
	Public m_bModifClient As Boolean
	
	Private m_bLoading As Boolean
	
	'UPGRADE_WARNING: Event cmbNoProjSoum.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbNoProjSoum_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbNoProjSoum.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjSoum As ADODB.Recordset
		
15: rstProjSoum = New ADODB.Recordset
		
20: txtNoProjSoum.Text = cmbNoProjSoum.Text
		
25: Call rstProjSoum.Open("SELECT * FROM GRB_ProjSoum WHERE IDProjSoum = '" & txtNoProjSoum.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
30: If rstProjSoum.Fields("Ouvert").Value = True Then
35: cmdFermerProjSoum.Enabled = True
40: Else
45: cmdFermerProjSoum.Enabled = False
50: End If
		
55: If rstProjSoum.Fields("Verrouillé").Value = True Then
60: If m_eType = enumType.TYPE_SOUMISSION Then
65: cmdVerrouiller.Text = "Déverrouiller Soum"
70: Else
75: cmdVerrouiller.Text = "Déverrouiller Proj"
80: End If
85: Else
90: If m_eType = enumType.TYPE_SOUMISSION Then
95: cmdVerrouiller.Text = "Verrouiller Soum"
100: Else
105: cmdVerrouiller.Text = "Verrouiller Proj"
110: End If
115: End If
		
120: Call rstProjSoum.Close()
125: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjSoum = Nothing
		
130: Call AfficherProjSoum()
		
135: Exit Sub
		
AfficherErreur: 
		
140: Call AfficherErreur("frmFacturation", "cmbNoProjSoum_Click", Err, Erl())
	End Sub
	
	Private Sub cmbNoProjSoum_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles cmbNoProjSoum.KeyUp
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: For iCompteur = 0 To cmbNoProjSoum.Items.Count - 1
20: If UCase(VB6.GetItemString(cmbNoProjSoum, iCompteur)) = UCase(cmbNoProjSoum.Text) Then
25: cmbNoProjSoum.SelectedIndex = iCompteur
				
30: Exit For
35: End If
40: Next 
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmFacturation", "cmbProjSoum_KeyUp", Err, Erl())
	End Sub
	
	
	Private Sub AfficherProjSoum()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjSoum As ADODB.Recordset
15: Dim rstClient As ADODB.Recordset
		
20: rstProjSoum = New ADODB.Recordset
25: rstClient = New ADODB.Recordset
		
30: Call rstProjSoum.Open("SELECT * FROM GRB_ProjSoum WHERE IDProjSoum = '" & txtNoProjSoum.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
35: Call rstClient.Open("SELECT NomClient FROM GRB_Client WHERE IDClient = " & rstProjSoum.Fields("NoClient").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
40: If Not rstClient.EOF Then
45: txtClient.Text = rstClient.Fields("NomClient").Value
50: txtClient.Tag = rstProjSoum.Fields("NoClient").Value
55: End If
		
60: Call rstClient.Close()
65: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient = Nothing
		
70: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjSoum.Fields("DateOuverture").Value) Then
75: txtDateOuverture.Text = rstProjSoum.Fields("DateOuverture").Value
80: Else
85: txtDateOuverture.Text = vbNullString
90: End If
		
95: If optMontrer(I_OPT_TOUS).Checked = True Or optMontrer(I_OPT_FERME).Checked = True Then
100: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("DateFermeture").Value) Then
105: txtDateFermeture.Text = rstProjSoum.Fields("DateFermeture").Value
110: Else
115: txtDateFermeture.Text = vbNullString
120: End If
			
125: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("RaisonFermeture").Value) Then
130: txtRaisonFermeture.Text = rstProjSoum.Fields("RaisonFermeture").Value
135: Else
140: txtRaisonFermeture.Text = vbNullString
145: End If
150: End If
		
155: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjSoum.Fields("Description").Value) Then
160: txtDescription.Text = rstProjSoum.Fields("Description").Value
165: Else
170: txtDescription.Text = vbNullString
175: End If
		
180: Call rstProjSoum.Close()
185: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjSoum = Nothing
		
190: Call RemplirListView()
		
195: Exit Sub
		
AfficherErreur: 
		
200: Call AfficherErreur("frmFacturation", "AfficherProjSoum", Err, Erl())
	End Sub
	
	Private Sub cmd_export_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmd_export.Click
		Call vb_to_excel()
		
	End Sub
	
	Private Sub cmdCommentaire_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCommentaire.Click
		
5: On Error GoTo AfficherErreur
		
10: If cmbProjSoum.SelectedIndex = I_CMB_PROJET Then
15: Call frmCommentairesProjSoum.Afficher(cmbNoProjSoum.Text, True)
20: Else
25: Call frmCommentairesProjSoum.Afficher(cmbNoProjSoum.Text, False)
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmFacturation", "cmdCommentaire_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFacturerRectifier_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFacturerRectifier.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim sNoFacture As String
15: Dim rstFacture As ADODB.Recordset
20: Dim sWhere As String
25: Dim iCompteur As Short
		
30: If cmdFacturerRectifier.Text = S_FACTURER Then
			'Change la valeur du champs "Facturé" dans la table GRB_Punch pour True et
			'ajoute le numéro de la facture dans le champs "NoFacture"
			
35: sNoFacture = InputBox("Entrez le numéro de la facture")
			
			'Le numéro de facture peut être vide, mais si il ne l'est pas, il doit
			'être numérique
40: If sNoFacture <> vbNullString Then
45: If Not IsNumeric(sNoFacture) Then
50: Call MsgBox("Le numéro de facture est invalide", MsgBoxStyle.OKOnly, "Erreur")
					
55: Exit Sub
60: End If
				
65: sWhere = "IDPunch In ("
				
70: For iCompteur = 1 To lvwProjets.Items.Count
					'Si l'élément est sélectionné
75: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvwProjets.Items.Item(iCompteur).Selected = True Then
						'Si la condition where est vide, c'est parce que c'est le premier élément
						'sélectionné
80: If sWhere = "IDPunch In (" Then
85: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							sWhere = sWhere & lvwProjets.Items.Item(iCompteur).Tag
90: Else
95: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							sWhere = sWhere & "," & lvwProjets.Items.Item(iCompteur).Tag
100: End If
105: End If
110: Next 
				
115: sWhere = sWhere & ")"
				
120: rstFacture = New ADODB.Recordset
				
				'Ouverture des enregistrements sélectionnés dans le ListView
125: Call rstFacture.Open("SELECT * FROM GRB_Punch WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
130: Do While Not rstFacture.EOF
					'Mettre la facturation à true et remplir le numéro de facture
135: rstFacture.Fields("Facturé").Value = True
140: rstFacture.Fields("NoFacture").Value = sNoFacture
					
145: Call rstFacture.Update()
					
150: Call rstFacture.MoveNext()
155: Loop 
				
160: Call rstFacture.Close()
165: 'UPGRADE_NOTE: Object rstFacture may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstFacture = Nothing
				
170: Call RemplirListView(lvwProjets.FocusedItem.Index)
175: End If
180: Else
			'Change la valeur du champs "Facturé" dans la table GRB_Punch pour False et
			'ajoute le numéro de la facture dans le champs "NoFacture"
			
185: sWhere = "IDPunch In ("
			
190: For iCompteur = 1 To lvwProjets.Items.Count
				'Si l'élément est sélectionné
195: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwProjets.Items.Item(iCompteur).Selected = True Then
					'Si la condition where est vide, c'est parce que c'est le premier élément
					'sélectionné
200: If sWhere = "IDPunch In (" Then
205: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						sWhere = sWhere & lvwProjets.Items.Item(iCompteur).Tag
210: Else
215: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						sWhere = sWhere & "," & lvwProjets.Items.Item(iCompteur).Tag
220: End If
225: End If
230: Next 
			
235: sWhere = sWhere & ")"
			
240: rstFacture = New ADODB.Recordset
			
			'Ouverture des enregistrements sélectionnés dans le ListView
245: Call rstFacture.Open("SELECT Facturé, NoFacture FROM GRB_Punch WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'Tant que ce n'est pas la fin du recordset
250: Do While Not rstFacture.EOF
				'Mettre la facturation à false et vider le numéro de facture
255: rstFacture.Fields("Facturé").Value = False
260: rstFacture.Fields("NoFacture").Value = vbNullString
				
265: Call rstFacture.Update()
				
270: Call rstFacture.MoveNext()
275: Loop 
			
280: Call rstFacture.Close()
285: 'UPGRADE_NOTE: Object rstFacture may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstFacture = Nothing
			
290: Call RemplirListView(lvwProjets.FocusedItem.Index)
295: End If
		
300: Exit Sub
		
AfficherErreur: 
		
305: Call AfficherErreur("frmFacturation", "cmdFacturerRectifier_Click", Err, Erl())
	End Sub
	
	Private Sub cmdModifier_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdModifier.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPunch As ADODB.Recordset
15: Dim rstProjSoum As ADODB.Recordset
		
20: If PeutModifier = True Then
25: m_bModifClient = True
			
30: Call frmChoixClient.ShowDialog()
			
35: m_bModifClient = False
			
40: If m_iIDClient <> CDbl(txtClient.Tag) Then
45: rstProjSoum = New ADODB.Recordset
				
50: Call rstProjSoum.Open("SELECT * FROM GRB_ProjSoum WHERE IDProjSoum = '" & txtNoProjSoum.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
55: rstProjSoum.Fields("NoClient").Value = m_iIDClient
60: rstProjSoum.Fields("Description").Value = m_sDescription
				
65: Call rstProjSoum.Update()
				
70: Call rstProjSoum.Close()
75: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstProjSoum = Nothing
				
80: rstPunch = New ADODB.Recordset
				
85: Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE NoProjet = '" & txtNoProjSoum.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
90: If Not rstPunch.EOF Then
95: If MsgBox("Voulez-vous modifier tous les punch ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
100: Do While Not rstPunch.EOF
105: rstPunch.Fields("NoClient").Value = m_iIDClient
							
110: Call rstPunch.Update()
							
115: Call rstPunch.MoveNext()
120: Loop 
125: End If
130: End If
				
135: Call rstPunch.Close()
140: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstPunch = Nothing
				
145: Call AfficherProjSoum()
150: End If
155: End If
		
160: Exit Sub
		
AfficherErreur: 
		
165: Call AfficherErreur("frmFacturation", "cmdModifier_Click", Err, Erl())
	End Sub
	
	Private Function PeutModifier() As Boolean
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjSoum As ADODB.Recordset
15: Dim rstProjet As ADODB.Recordset
20: Dim rstSoumission As ADODB.Recordset
25: Dim bPeutModifier As Boolean
		
30: rstProjSoum = New ADODB.Recordset
		
35: Call rstProjSoum.Open("SELECT Ouvert, Type FROM GRB_ProjSoum WHERE IDProjSoum = '" & txtNoProjSoum.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
40: If rstProjSoum.Fields("Ouvert").Value = True Then
45: If rstProjSoum.Fields("Type").Value = "P" Then
50: rstProjet = New ADODB.Recordset
				
55: Call rstProjet.Open("SELECT * FROM GRB_ProjetElec WHERE IDProjet = '" & txtNoProjSoum.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
				
60: If rstProjet.EOF Then
65: Call rstProjet.Close()
					
70: Call rstProjet.Open("SELECT * FROM GRB_ProjetMec WHERE IDProjet = '" & txtNoProjSoum.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
					
75: If rstProjet.EOF Then
80: bPeutModifier = True
85: Else
90: Call MsgBox("Le client doit être modifié dans l'écran des projets mécaniques!", MsgBoxStyle.OKOnly, "Erreur")
						
95: bPeutModifier = False
100: End If
					
105: Call rstProjet.Close()
110: Else
115: Call MsgBox("Le client doit être modifié dans l'écran des projets électriques!", MsgBoxStyle.OKOnly, "Erreur")
					
120: Call rstProjet.Close()
					
125: bPeutModifier = False
130: End If
				
135: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstProjet = Nothing
140: Else
145: rstSoumission = New ADODB.Recordset
				
150: Call rstSoumission.Open("SELECT * FROM GRB_SoumissionElec WHERE IDSoumission = '" & txtNoProjSoum.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
				
155: If rstSoumission.EOF Then
160: Call rstSoumission.Close()
					
165: Call rstSoumission.Open("SELECT * FROM GRB_SoumissionMec WHERE IDSoumission = '" & txtNoProjSoum.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
					
170: If rstSoumission.EOF Then
175: bPeutModifier = True
180: Else
185: Call MsgBox("Le client doit être modifié dans l'écran des soumissions mécaniques!", MsgBoxStyle.OKOnly, "Erreur")
						
190: bPeutModifier = False
195: End If
					
200: Call rstSoumission.Close()
205: Else
210: Call MsgBox("Le client doit être modifié dans l'écran des soumissions électriques!", MsgBoxStyle.OKOnly, "Erreur")
					
215: Call rstSoumission.Close()
					
220: bPeutModifier = False
225: End If
				
230: 'UPGRADE_NOTE: Object rstSoumission may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstSoumission = Nothing
235: End If
240: Else
245: If rstProjSoum.Fields("Type").Value = "P" Then
250: Call MsgBox("Ce projet est fermé!", MsgBoxStyle.OKOnly, "Erreur")
255: Else
260: Call MsgBox("Cette soumission est fermée!", MsgBoxStyle.OKOnly, "Erreur")
265: End If
			
270: bPeutModifier = False
275: End If
		
280: Call rstProjSoum.Close()
285: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjSoum = Nothing
		
290: PeutModifier = bPeutModifier
		
295: Exit Function
		
AfficherErreur: 
		
300: Call AfficherErreur("frmFacturation", "PeutModifier", Err, Erl())
	End Function
	
	Private Sub cmdNCRectifier_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNCRectifier.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstFacture As ADODB.Recordset
15: Dim sWhere As String
20: Dim iCompteur As Short
		
25: If cmdNCRectifier.Text = S_NC Then
			'Change la valeur du champs "Facturé" dans la table GRB_Punch pour True et
			'ajoute NC dans le champs "NoFacture"
30: sWhere = "IDPunch In ("
			
35: For iCompteur = 1 To lvwProjets.Items.Count
				'Si l'élément est sélectionné
40: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwProjets.Items.Item(iCompteur).Selected = True Then
					'Si la condition where est vide, c'est parce que c'est le premier élément
					'sélectionné
45: If sWhere = "IDPunch In (" Then
50: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						sWhere = sWhere & lvwProjets.Items.Item(iCompteur).Tag
55: Else
60: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						sWhere = sWhere & "," & lvwProjets.Items.Item(iCompteur).Tag
65: End If
70: End If
75: Next 
			
80: sWhere = sWhere & ")"
			
85: rstFacture = New ADODB.Recordset
			
			'Ouverture des enregistrements sélectionnés dans le ListView
90: Call rstFacture.Open("SELECT * FROM GRB_Punch WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
95: Do While Not rstFacture.EOF
				'Mettre la facturation à true et remplir le numéro de facture
100: rstFacture.Fields("Facturé").Value = True
105: rstFacture.Fields("NoFacture").Value = "NC"
				
110: Call rstFacture.Update()
				
115: Call rstFacture.MoveNext()
120: Loop 
			
125: Call rstFacture.Close()
130: 'UPGRADE_NOTE: Object rstFacture may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstFacture = Nothing
			
135: Call RemplirListView(lvwProjets.FocusedItem.Index)
140: Else
			'Change la valeur du champs "Facturé" dans la table GRB_Punch pour False et
			'enlève NC
145: sWhere = "IDPunch In ("
			
150: For iCompteur = 1 To lvwProjets.Items.Count
				'Si l'élément est sélectionné
155: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwProjets.Items.Item(iCompteur).Selected = True Then
					'Si la condition where est vide, c'est parce que c'est le premier élément
					'sélectionné
160: If sWhere = "IDPunch In (" Then
165: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						sWhere = sWhere & lvwProjets.Items.Item(iCompteur).Tag
170: Else
175: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						sWhere = sWhere & "," & lvwProjets.Items.Item(iCompteur).Tag
180: End If
185: End If
190: Next 
			
195: sWhere = sWhere & ")"
			
200: rstFacture = New ADODB.Recordset
			
			'Ouverture des enregistrements sélectionnés dans le ListView
205: Call rstFacture.Open("SELECT * FROM GRB_Punch WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'Tant que ce n'est pas la fin du recordset
210: Do While Not rstFacture.EOF
				'Mettre la facturation à false et vider le numéro de facture
215: rstFacture.Fields("Facturé").Value = False
220: rstFacture.Fields("NoFacture").Value = vbNullString
				
225: Call rstFacture.Update()
				
230: Call rstFacture.MoveNext()
235: Loop 
			
240: Call rstFacture.Close()
245: 'UPGRADE_NOTE: Object rstFacture may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstFacture = Nothing
			
250: Call RemplirListView(lvwProjets.FocusedItem.Index)
255: End If
		
260: Exit Sub
		
AfficherErreur: 
		
265: Call AfficherErreur("frmFacturation", "cmdFacturerRectifier_Click", Err, Erl())
	End Sub
	
	Private Sub Cmdfermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cmdfermer.Click
		
5: On Error GoTo AfficherErreur
		
		'Fermer de la fênêtre
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFacturation", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub cmdImprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImprimer.Click
		Dim intdummie As Short
		
		
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.TYPE_PROJET Then
15: Call frmChoixDateImpressionFacturation.Afficher(txtNoProjSoum.Text, True, txtClient.Text, txtDescription.Text)
20: Else
25: Call frmChoixDateImpressionFacturation.Afficher(txtNoProjSoum.Text, False, txtClient.Text, txtDescription.Text)
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmFacturation", "cmdImprimer_Click", Err, Erl())
	End Sub
	
	Private Function vb_to_excel() As Object
		
		
		
6: Dim iCount As Short
10: Dim oXLApp As Excel.Application 'Declare the object variables
15: Dim oXLBook As Excel.Workbook
20: Dim oXLSheet As Excel.Worksheet
		'UPGRADE_WARNING: Lower bound of array data_array was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim data_array(1500, 7) As Object 'modifier pour intégré une nouvelle onglet
		Dim r As Short
25: oXLApp = New Excel.Application 'Create a new instance of Excel
30: oXLBook = oXLApp.Workbooks.Add 'Add a new workbook
35: oXLSheet = oXLBook.Worksheets(1) 'Work with the first worksheet
		oXLApp.Visible = False
		
		'on inscrit les valeurs du listbox dans un tableau
		r = 1
		'UPGRADE_WARNING: IsEmpty was upgraded to IsNothing and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		Do While Not IsNothing(r <= lvwProjets.Items.Count)
			'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 1) = lvwProjets.Items.Item(r).Text
			'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 2) = lvwProjets.Items.Item(r).SubItems(1).Text
			'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 3) = lvwProjets.Items.Item(r).SubItems(2).Text
			'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 4) = lvwProjets.Items.Item(r).SubItems(3).Text
			'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 5) = lvwProjets.Items.Item(r).SubItems(4).Text 'Ajouter la description a la table excel 2017-06-26 GLL
			'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 6) = CDbl(lvwProjets.Items.Item(r).SubItems(5).Text)
			'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 7). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 7) = lvwProjets.Items.Item(r).SubItems(7).Text 'Ajouter pour avoir le tableau complet en Excel
			
			r = r + 1
			
		Loop 
		
		
		
		
		'creation en-tête de colonne
		oXLSheet.Range("A1: G1").Font.Bold = True
		oXLSheet.Range("A:G").HorizontalAlignment = Excel.Constants.xlCenter
		'UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		oXLSheet.Range("A1: G1").Value = New Object(){"Employé", "Date", "Debut", "Fin", "Description", "Total", "Type"} 'GLL
		
		
		'inscription des valeur du tableau dans excel
		oXLSheet.Range("A2").Resize(r, 7).Value = VB6.CopyArray(data_array)
		'ajustement largeur des colonne
		oXLSheet.Range("A:G").Columns.AutoFit()
		oXLApp.Visible = True
		
		
		
		
		
		
		
		
		
	End Function
	
	
	Private Sub cmdOuvrirProjSoum_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOuvrirProjSoum.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim sNumero As String
15: Dim rstProjSoum As ADODB.Recordset
20: Dim sQuestion As String
25: Dim sType As String
30: Dim bNoValide As Boolean
		
35: Select Case m_eType
			Case enumType.TYPE_PROJET
40: sQuestion = "Quel est le numéro du projet?"
45: sType = "P"
50: Case enumType.TYPE_SOUMISSION
55: sQuestion = "Quel est le numéro de la soumission?"
60: sType = "S"
65: End Select
		
70: sNumero = InputBox(sQuestion)
		
75: If sNumero <> vbNullString Then
80: bNoValide = True
			
85: If ValiderFormatNumeroProjSoum(sNumero) = False Then
90: bNoValide = False
95: End If
			
100: If bNoValide = True Then
105: If m_eType = enumType.TYPE_PROJET Then
110: If ValiderFormatProjet(sNumero) = False Then
115: bNoValide = False
120: End If
125: Else
130: If ValiderFormatSoumission(sNumero) = False Then
135: bNoValide = False
140: End If
145: End If
150: End If
			
155: If bNoValide = False Then
160: Exit Sub
165: End If
			
170: Call frmChoixClient.ShowDialog()
			
175: rstProjSoum = New ADODB.Recordset
			
180: Call rstProjSoum.Open("SELECT * FROM GRB_ProjSoum WHERE IDProjSoum = '" & sNumero & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
185: If rstProjSoum.EOF Then
190: Call rstProjSoum.AddNew()
				
195: rstProjSoum.Fields("IDProjSoum").Value = sNumero
200: rstProjSoum.Fields("NoClient").Value = m_iIDClient
205: rstProjSoum.Fields("Description").Value = m_sDescription
210: rstProjSoum.Fields("DateOuverture").Value = ConvertDate(Today)
215: rstProjSoum.Fields("Ouvert").Value = True
220: rstProjSoum.Fields("Type").Value = sType
				
225: Call rstProjSoum.Update()
				
230: Call RemplirComboProjSoum()
235: Else
240: Call MsgBox("Ce numéro existe déjà!", MsgBoxStyle.OKOnly, "Erreur")
245: End If
			
250: Call rstProjSoum.Close()
255: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstProjSoum = Nothing
260: End If
		
265: Exit Sub
		
AfficherErreur: 
		
270: Call AfficherErreur("frmFacturation", "cmdOuvrirProjSoum_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFermerProjSoum_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermerProjSoum.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjSoum As ADODB.Recordset
15: Dim sQuestion As String
20: Dim sRaison As String
		
25: Select Case m_eType
			Case enumType.TYPE_PROJET : sQuestion = "Voulez-vous vraiment fermer ce projet?"
30: Case enumType.TYPE_SOUMISSION : sQuestion = "Voulez-vous vraiment fermer cette soumission?"
35: End Select
		
40: If MsgBox(sQuestion, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
45: rstProjSoum = New ADODB.Recordset
			
50: Call rstProjSoum.Open("SELECT * FROM GRB_ProjSoum WHERE IDProjSoum = '" & txtNoProjSoum.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
55: rstProjSoum.Fields("Ouvert").Value = False
60: rstProjSoum.Fields("DateFermeture").Value = ConvertDate(Today)
			
65: If m_eType = enumType.TYPE_SOUMISSION Then
70: sRaison = InputBox("Quelle est la raison de la fermeture?")
				
75: rstProjSoum.Fields("RaisonFermeture").Value = sRaison
80: End If
			
85: Call rstProjSoum.Update()
			
90: Call rstProjSoum.Close()
95: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstProjSoum = Nothing
			
100: Call RemplirComboProjSoum()
105: End If
		
110: Exit Sub
		
AfficherErreur: 
		
115: Call AfficherErreur("frmFacturation", "cmdFermerProjSoum_Click", Err, Erl())
	End Sub
	
	Private Sub cmdReouverture_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdReouverture.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjSoum As ADODB.Recordset
15: Dim sQuestion As String
		
20: If cmbNoProjSoum.SelectedIndex <> -1 Then
25: Select Case m_eType
				Case enumType.TYPE_PROJET : sQuestion = "Voulez-vous vraiment annuler la fermeture de ce projet?"
30: Case enumType.TYPE_SOUMISSION : sQuestion = "Voulez-vous vraiment annuler la fermeture de cette soumission?"
35: End Select
			
40: If MsgBox(sQuestion, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
45: rstProjSoum = New ADODB.Recordset
				
50: Call rstProjSoum.Open("SELECT * FROM GRB_ProjSoum WHERE IDProjSoum = '" & txtNoProjSoum.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
55: rstProjSoum.Fields("Ouvert").Value = True
60: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				rstProjSoum.Fields("RaisonFermeture").Value = System.DBNull.Value
				
65: Call rstProjSoum.Update()
				
70: Call rstProjSoum.Close()
75: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstProjSoum = Nothing
				
80: Call ViderValeurs()
				
85: Call RemplirComboProjSoum()
90: End If
95: End If
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmFacturation", "cmdReouverture_Click", Err, Erl())
	End Sub
	
	Private Sub cmdSommaire_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSommaire.Click
		
5: On Error GoTo AfficherErreur
		
10: Call frmChoixDateSommairePunch.ShowDialog()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFacturation", "cmdImprimer_Click", Err, Erl())
	End Sub
	
	Private Sub cmdsupprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdsupprimer.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim sMessage As String
15: Dim sErreur As String
		
20: Call RemplirListView()
		
25: If m_eType = enumType.TYPE_PROJET Then
30: sMessage = "Voulez-vous vraiment effacer le projet " & txtNoProjSoum.Text & "?"
35: sErreur = "Impossible de supprimer ce projet car il y a déjà des punchs!"
40: Else
45: sMessage = "Voulez-vous vraiment effacer la soumission " & txtNoProjSoum.Text & "?"
50: sErreur = "Impossible de supprimer cette soumission car il y a déjà des punchs!"
55: End If
		
60: If lvwProjets.Items.Count = 0 Then
65: If MsgBox(sMessage, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
70: Call g_connData.Execute("DELETE * FROM GRB_ProjSoum WHERE IDProjSoum = '" & txtNoProjSoum.Text & "'")
				
75: Call ViderValeurs()
				
80: Call RemplirComboProjSoum()
				
85: If cmbNoProjSoum.Items.Count = 0 Then
90: Call ViderValeurs()
95: End If
100: End If
105: Else
110: Call MsgBox(sErreur, MsgBoxStyle.OKOnly, "Erreur")
115: End If
		
120: Exit Sub
		
AfficherErreur: 
		
125: Call AfficherErreur("frmFacturation", "cmdSupprimer_Click", Err, Erl())
	End Sub
	
	Private Sub ViderValeurs()
		
5: On Error GoTo AfficherErreur
		
10: txtClient.Text = vbNullString
15: txtDescription.Text = vbNullString
20: txtDateOuverture.Text = vbNullString
25: txtDateFermeture.Text = vbNullString
30: txtRaisonFermeture.Text = vbNullString
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmFacturation", "ViderValeurs", Err, Erl())
	End Sub
	
	Private Sub cmdVerrouiller_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVerrouiller.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjSoum As ADODB.Recordset
		
15: rstProjSoum = New ADODB.Recordset
		
20: Call rstProjSoum.Open("SELECT * FROM GRB_ProjSoum WHERE IDProjSoum = '" & txtNoProjSoum.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: Select Case cmdVerrouiller.Text
			Case "Verrouiller Soum" : rstProjSoum.Fields("Verrouillé").Value = True
30: Case "Verrouiller Proj" : rstProjSoum.Fields("Verrouillé").Value = True
35: Case "Déverrouiller Soum" : rstProjSoum.Fields("Verrouillé").Value = False
40: Case "Déverrouiller Proj" : rstProjSoum.Fields("Verrouillé").Value = False
45: End Select
		
50: Call rstProjSoum.Update()
		
55: Call rstProjSoum.Close()
60: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjSoum = Nothing
		
65: Call cmbNoProjSoum_SelectedIndexChanged(cmbNoProjSoum, New System.EventArgs())
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmFacturation", "cmdVerrouiller_Click", Err, Erl())
	End Sub
	
	Private Sub Command1_Click()
		
		Call vb_to_excel()
		
	End Sub
	
	Private Sub frmFacturation_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: m_bLoading = True
		
15: cmbProjSoum.SelectedIndex = I_CMB_PROJET
20: cmdFacturerRectifier.Enabled = False
25: cmdNCRectifier.Enabled = False
30: optMontrer(I_OPT_OUVERT).Checked = True
35: optType(I_OPT_TYPE_TOUS).Checked = True
		
40: m_bLoading = False
		
45: Call RemplirComboProjSoum()
		
50: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmFacturation", "Form_Load", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbProjSoum.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbProjSoum_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbProjSoum.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		'Rempli le cmbNoProjet avec les numéros de projet
10: Select Case cmbProjSoum.SelectedIndex
			Case I_CMB_PROJET
15: m_eType = enumType.TYPE_PROJET
20: lblTitreProjSoum.Text = "Numéro de projet"
25: cmdOuvrirProjSoum.Text = "Ouvrir Projet"
30: cmdFermerProjSoum.Text = "Fermer Projet"
35: fraMontrer.Text = S_FRA_PROJ
40: optMontrer(I_OPT_TOUS).Text = S_PROJ_TOUS
45: optMontrer(I_OPT_OUVERT).Text = S_PROJ_OUVERT
50: optMontrer(I_OPT_FERME).Text = S_PROJ_FERME
				
55: Case I_CMB_SOUMISSION
60: m_eType = enumType.TYPE_SOUMISSION
65: lblTitreProjSoum.Text = "Numéro de soumission"
70: cmdOuvrirProjSoum.Text = "Ouvrir Soum"
75: cmdFermerProjSoum.Text = "Fermer Soum"
80: fraMontrer.Text = S_FRA_SOUM
85: optMontrer(I_OPT_TOUS).Text = S_SOUM_TOUS
90: optMontrer(I_OPT_OUVERT).Text = S_SOUM_OUVERT
95: optMontrer(I_OPT_FERME).Text = S_SOUM_FERME
100: End Select
		
105: Call RemplirComboProjSoum()
		
110: Exit Sub
		
AfficherErreur: 
		
115: Call AfficherErreur("frmFacturation", "cmbProjSoum_Click", Err, Erl())
	End Sub
	
	Private Sub RemplirComboProjSoum()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le cmbNoProjet avec les numéros de projet et soumissions
		'Si bOuvert est à True, on affiche seulement ceux qui sont ouverts actuellement
10: Dim rstProjet As ADODB.Recordset
15: Dim sType As String
20: Dim sWhere As String
		
25: If m_bLoading = False Then
30: Select Case m_eType
				Case enumType.TYPE_PROJET : sType = "P"
35: Case enumType.TYPE_SOUMISSION : sType = "S"
40: End Select
			
45: If optMontrer(I_OPT_TOUS).Checked = True Then
50: sWhere = "Type = '" & sType & "'"
55: Else
60: If optMontrer(I_OPT_OUVERT).Checked = True Then
65: sWhere = "Ouvert = True AND Type = '" & sType & "'"
70: Else
75: sWhere = "Ouvert = False AND Type = '" & sType & "'"
80: End If
85: End If
			
90: If optType(I_OPT_TYPE_ELECTRIQUE).Checked = True Then
95: sWhere = sWhere & " AND Left(IDProjSoum, 1) = 'E'"
100: Else
105: If optType(I_OPT_TYPE_MECANIQUE).Checked = True Then
110: sWhere = sWhere & " AND Left(IDProjSoum, 1) = 'M'"
115: End If
120: End If
			
			'Il faut vider le Combo avant de le remplir
125: Call cmbNoProjSoum.Items.Clear()
			
130: rstProjet = New ADODB.Recordset
			
			'Ouverture d'un recordset contenant les NoProjet
135: Call rstProjet.Open("SELECT IDProjSoum, Ouvert FROM GRB_ProjSoum WHERE " & sWhere & " ORDER BY IDProjSoum", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
140: Do While Not rstProjet.EOF
				'Ajout du numéro de projet dans le Combo
145: Call cmbNoProjSoum.Items.Add(rstProjet.Fields("IDProjSoum").Value)
				
150: Call rstProjet.MoveNext()
155: Loop 
			
160: Call rstProjet.Close()
165: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstProjet = Nothing
			
			'Si il y a des éléments dans le combo, on sélectionne le premier
170: If cmbNoProjSoum.Items.Count > 0 Then
175: cmbNoProjSoum.SelectedIndex = 0
180: Else
185: Call lvwProjets.Items.Clear()
190: End If
195: End If
		
200: Exit Sub
		
AfficherErreur: 
		
205: Call AfficherErreur("frmFacturation", "RemplirComboProjSoum", Err, Erl())
	End Sub
	
	Private Sub RemplirListView(Optional ByVal o_iIndex As Short = 1)
		
5: On Error GoTo AfficherErreur
		
		'Remplissage du listView dépendamment du no de projet choisi
10: Dim rstProjet As ADODB.Recordset
15: Dim itmProjet As System.Windows.Forms.ListViewItem
20: Dim lColor As Integer
25: Dim sDateDebut As String
30: Dim sDateFin As String
35: Dim sTotal As String
		
		'Il faut vider le listView avant de le remplir
40: Call lvwProjets.Items.Clear()
		
45: sDateDebut = "TIMESERIAL(Left(GRB_Punch.HeureDébut,2),RIGHT(GRB_Punch.HeureDébut,2),0)"
		
50: sDateFin = "TIMESERIAL(Left(GRB_Punch.HeureFin,2),RIGHT(GRB_Punch.HeureFin,2),0)"
		
55: sTotal = "((" & sDateFin & " - " & sDateDebut & ")* 24) As Total"
		
		'Ouverture des enregistrements avec comme filtre, le numéro du projet
60: rstProjet = New ADODB.Recordset
		
65: rstProjet.CursorLocation = ADODB.CursorLocationEnum.adUseServer
		
70: Call rstProjet.Open("SELECT GRB_Punch.*, " & sTotal & ", GRB_employés.initiale FROM GRB_employés INNER JOIN GRB_Punch ON GRB_employés.noemploye = GRB_Punch.NoEmploye WHERE NoProjet = '" & txtNoProjSoum.Text & "' ORDER BY [Date], HeureDébut, HeureFin", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
75: Do While Not rstProjet.EOF
			'Vérification du champs "Facturé", si il est à vrai, il faut l'inscrire en
			'rouge dans le ListView, sinon, il faut l'inscrire en noir
80: If rstProjet.Fields("Facturé").Value = "Vrai" Then
85: lColor = COLOR_ROUGE
90: Else
95: lColor = COLOR_NOIR
100: End If
			
105: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwProjets.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmProjet = lvwProjets.Items.Add()
			
110: itmProjet.Tag = rstProjet.Fields("IDPunch").Value
			
			'Initiales de l'employé
115: itmProjet.Text = rstProjet.Fields("Initiale").Value
120: itmProjet.ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'Date
125: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmProjet.SubItems.Count > I_LVW_DATE Then
				itmProjet.SubItems(I_LVW_DATE).Text = rstProjet.Fields("Date").Value
			Else
				itmProjet.SubItems.Insert(I_LVW_DATE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("Date").Value))
			End If
130: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmProjet.SubItems.Item(I_LVW_DATE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'Début
135: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjet.Fields("HeureDébut").Value) Then
140: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_LVW_DEBUT Then
					itmProjet.SubItems(I_LVW_DEBUT).Text = rstProjet.Fields("HeureDébut").Value
				Else
					itmProjet.SubItems.Insert(I_LVW_DEBUT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("HeureDébut").Value))
				End If
145: Else
150: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_LVW_DEBUT Then
					itmProjet.SubItems(I_LVW_DEBUT).Text = vbNullString
				Else
					itmProjet.SubItems.Insert(I_LVW_DEBUT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
155: End If
			
160: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmProjet.SubItems.Item(I_LVW_DEBUT).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'Fin
165: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjet.Fields("HeureFin").Value) Then
170: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_LVW_FIN Then
					itmProjet.SubItems(I_LVW_FIN).Text = rstProjet.Fields("HeureFin").Value
				Else
					itmProjet.SubItems.Insert(I_LVW_FIN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("HeureFin").Value))
				End If
175: Else
180: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_LVW_FIN Then
					itmProjet.SubItems(I_LVW_FIN).Text = vbNullString
				Else
					itmProjet.SubItems.Insert(I_LVW_FIN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
185: End If
			
190: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmProjet.SubItems.Item(I_LVW_FIN).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'Description
195: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjet.Fields("Commentaire").Value) Then
200: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_LVW_DESCRIPTION Then
					itmProjet.SubItems(I_LVW_DESCRIPTION).Text = rstProjet.Fields("Commentaire").Value
				Else
					itmProjet.SubItems.Insert(I_LVW_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("Commentaire").Value))
				End If
205: Else
210: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_LVW_DESCRIPTION Then
					itmProjet.SubItems(I_LVW_DESCRIPTION).Text = vbNullString
				Else
					itmProjet.SubItems.Insert(I_LVW_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
215: End If
			
220: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmProjet.SubItems.Item(I_LVW_DESCRIPTION).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'Total
225: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjet.Fields("Total").Value) Then
230: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_LVW_TOTAL Then
					itmProjet.SubItems(I_LVW_TOTAL).Text = CStr(System.Math.Round(rstProjet.Fields("Total").Value, 2))
				Else
					itmProjet.SubItems.Insert(I_LVW_TOTAL, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, CStr(System.Math.Round(rstProjet.Fields("Total").Value, 2))))
				End If
235: Else
240: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_LVW_TOTAL Then
					itmProjet.SubItems(I_LVW_TOTAL).Text = vbNullString
				Else
					itmProjet.SubItems.Insert(I_LVW_TOTAL, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
245: End If
			
250: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmProjet.SubItems.Item(I_LVW_TOTAL).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'Numéro de facture
255: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjet.Fields("NoFacture").Value) Then
260: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_LVW_NO_FACTURE Then
					itmProjet.SubItems(I_LVW_NO_FACTURE).Text = rstProjet.Fields("NoFacture").Value
				Else
					itmProjet.SubItems.Insert(I_LVW_NO_FACTURE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("NoFacture").Value))
				End If
265: Else
270: 'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_LVW_NO_FACTURE Then
					itmProjet.SubItems(I_LVW_NO_FACTURE).Text = vbNullString
				Else
					itmProjet.SubItems.Insert(I_LVW_NO_FACTURE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
275: End If
			
280: 'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmProjet.SubItems.Item(I_LVW_NO_FACTURE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'Type
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjet.Fields("Type").Value) Then
				'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_LVW_TYPE Then
					itmProjet.SubItems(I_LVW_TYPE).Text = rstProjet.Fields("Type").Value
				Else
					itmProjet.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstProjet.Fields("Type").Value))
				End If
			Else
				'UPGRADE_WARNING: Lower bound of collection itmProjet has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmProjet.SubItems.Count > I_LVW_TYPE Then
					itmProjet.SubItems(I_LVW_TYPE).Text = vbNullString
				Else
					itmProjet.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
			End If
			
			'UPGRADE_WARNING: Lower bound of collection itmProjet.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmProjet.SubItems.Item(I_LVW_TYPE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
285: Call rstProjet.MoveNext()
290: Loop 
		
295: If lvwProjets.Items.Count > 0 Then
300: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: MSComctlLib.IListItem method lvwProjets.ListItems.EnsureVisible has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			Call lvwProjets.Items.Item(o_iIndex).EnsureVisible()
305: End If
		
310: Call rstProjet.Close()
315: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjet = Nothing
		
320: Call CalculerTotaux()
		
325: Exit Sub
		
AfficherErreur: 
		
330: Call AfficherErreur("frmFacturation", "RemplirListView", Err, Erl())
	End Sub
	
	Private Sub CalculerTotaux()
		
5: On Error GoTo AfficherErreur
		
10: Dim dblTotalFacture As Double
15: Dim dblTotalNonFacture As Double
20: Dim iCompteur As Short
		
25: For iCompteur = 1 To lvwProjets.Items.Count
30: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwProjets.Items.Item(iCompteur).SubItems(I_LVW_NO_FACTURE).Text <> vbNullString Then
35: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				dblTotalFacture = dblTotalFacture + CDbl(lvwProjets.Items.Item(iCompteur).SubItems(I_LVW_TOTAL).Text)
40: Else
45: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				dblTotalNonFacture = dblTotalNonFacture + CDbl(lvwProjets.Items.Item(iCompteur).SubItems(I_LVW_TOTAL).Text)
50: End If
55: Next 
		
60: lblHeuresFacturees.Text = CStr(System.Math.Round(dblTotalFacture, 2))
65: lblHeuresNonFacturees.Text = CStr(System.Math.Round(dblTotalNonFacture, 2))
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmFacturation", "CalculerTotaux", Err, Erl())
	End Sub
	
	Private Sub VerifierSelection()
		
5: On Error GoTo AfficherErreur
		
		'D'après les éléments sélectionner dans le ListView, cette méthode active
		'le bon bouton
10: Dim iCompteur As Short
15: Dim iSelected As Short
20: Dim iFacture As Short
25: Dim iNC As Short
30: Dim iNon As Short
		
		'Boucle servant à compter le nombre d'éléments sélectionnés dans le ListView,
		'le nombre d'éléments facturés et nombre d'éléments non facturés
35: For iCompteur = 1 To lvwProjets.Items.Count
40: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwProjets.Items.Item(iCompteur).Selected Then
				'Compte les éléments sélectionnés
45: iSelected = iSelected + 1
				
50: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwProjets.Items.Item(iCompteur).SubItems(I_LVW_NO_FACTURE).Text = "NC" Then
					'Compte les nc
55: iNC = iNC + 1
60: Else
65: 'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwProjets.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvwProjets.Items.Item(iCompteur).SubItems(I_LVW_NO_FACTURE).Text <> vbNullString Then
						'Compte les factures
70: iFacture = iFacture + 1
75: Else
						'Compte les non
80: iNon = iNon + 1
85: End If
90: End If
95: End If
100: Next 
		
		'Si tous les éléments sélectionnés ont été facturés
105: If iSelected = iFacture Then
110: cmdFacturerRectifier.Enabled = True
115: cmdNCRectifier.Enabled = False
			
120: cmdFacturerRectifier.Text = S_RECTIFIER
125: Else
			'Si tous les éléments sélectionnés sont NC
130: If iSelected = iNC Then
135: cmdFacturerRectifier.Enabled = False
140: cmdNCRectifier.Enabled = True
				
145: cmdNCRectifier.Text = S_RECTIFIER
150: Else
				'Si tous les éléments sélectionnés n'ont pas été facturés
155: If iSelected = iNon Then
160: cmdFacturerRectifier.Enabled = True
165: cmdNCRectifier.Enabled = True
					
170: cmdFacturerRectifier.Text = S_FACTURER
175: cmdNCRectifier.Text = S_NC
180: Else
					'Si les éléments sélectionnés sont facturés ou non
185: cmdFacturerRectifier.Enabled = False
190: cmdNCRectifier.Enabled = False
195: End If
200: End If
205: End If
		
210: Exit Sub
		
AfficherErreur: 
		
215: Call AfficherErreur("frmFacturation", "VerifierSelection", Err, Erl())
	End Sub
	
	'UPGRADE_ISSUE: MSComctlLib.ListView event lvwProjets.ItemClick was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub lvwProjets_ItemClick(ByVal Item As System.Windows.Forms.ListViewItem)
		
5: On Error GoTo AfficherErreur
		
		'Vérification de la sélection lorsque un Item dans le ListView est cliqué
10: Call VerifierSelection()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFacturation", "lvwProjets_ItemClick", Err, Erl())
	End Sub
	
	Private Sub lvwProjets_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwProjets.Click
		
5: On Error GoTo AfficherErreur
		
		'Vérification de la sélection lorsque un Item dans le ListView est cliqué
		'Cette méthode est importante puisque si l'utilisateur déclique un Item en tenant
		'la touche "Ctrl" enfoncé, ça ne passe pas dans l'événement ItemClick
10: Call VerifierSelection()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFacturation", "lvwProjets_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event optMontrer.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optMontrer_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optMontrer.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = optMontrer.GetIndex(eventSender)
			
5: On Error GoTo AfficherErreur
			
10: Dim bFermeture As Boolean
			
15: Call ViderValeurs()
			
20: Select Case Index
				Case I_OPT_TOUS
25: Call RemplirComboProjSoum()
					
30: bFermeture = True
					
				Case I_OPT_OUVERT
35: Call RemplirComboProjSoum()
					
40: bFermeture = False
					
				Case I_OPT_FERME
45: Call RemplirComboProjSoum()
					
50: bFermeture = True
55: End Select
			
60: lblDateFermeture.Visible = bFermeture
65: txtDateFermeture.Visible = bFermeture
70: lblRaisonFermeture.Visible = bFermeture
75: txtRaisonFermeture.Visible = bFermeture
			
80: cmdReouverture.Visible = bFermeture
			
85: Exit Sub
			
AfficherErreur: 
			
90: Call AfficherErreur("frmFacturation", "optMontrer_Click", Err, Erl())
		End If
	End Sub
	
	'UPGRADE_WARNING: Event optType.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optType_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optType.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = optType.GetIndex(eventSender)
			
5: On Error GoTo AfficherErreur
			
10: Call RemplirComboProjSoum()
			
15: Exit Sub
			
AfficherErreur: 
			
20: Call AfficherErreur("frmFacturation", "optType_Click", Err, Erl())
		End If
	End Sub
	
	Private Function ValiderFormatSoumission(ByVal sNoSoumission As String) As Boolean
		
5: On Error GoTo AfficherErreur
		
10: If Mid(sNoSoumission, 3, 1) = "1" Then
15: ValiderFormatSoumission = True
20: Else
25: Call MsgBox("Une soumission doit absolument avoir '1' comme 3e caractère !", MsgBoxStyle.OKOnly, "Erreur")
			
30: ValiderFormatSoumission = False
35: End If
		
40: Exit Function
		
AfficherErreur: 
		
45: Call AfficherErreur("FrmFacturation", "ValiderFormatSoumission", Err, Erl())
	End Function
	
	Private Function ValiderFormatProjet(ByVal sNoProjet As String) As Boolean
		
5: On Error GoTo AfficherErreur
		
10: Dim iType As Short
		
15: iType = CShort(Mid(sNoProjet, 3, 1))
		
20: If iType = 4 Or iType = 5 Or iType = 7 Or iType = 9 Then
25: ValiderFormatProjet = True
30: Else
35: Call MsgBox("Un projet ouvert dans cet écran doit absolument avoir '4', '5', '7' ou '9' comme 3e caractère !", MsgBoxStyle.OKOnly, "Erreur")
			
40: ValiderFormatProjet = False
45: End If
		
50: Exit Function
		
AfficherErreur: 
		
55: Call AfficherErreur("FrmFacturationElec", "ValiderFormatProjet", Err, Erl())
	End Function
End Class