Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmFeuilleTemps
	Inherits System.Windows.Forms.Form
	
	'Types quand c'est un 51
	Private Const I_TYPE_ELEC_INSTALLATION As Short = 0
	Private Const I_TYPE_ELEC_MISE_SERVICE As Short = 1
	
	'Types quand c'est pas un 51
	Private Const I_TYPE_ELEC_DESSIN As Short = 0
	Private Const I_TYPE_ELEC_FABRICATION As Short = 1
	Private Const I_TYPE_ELEC_ASSEMBLAGE As Short = 2
	Private Const I_TYPE_ELEC_PROG_INTERFACE As Short = 3
	Private Const I_TYPE_ELEC_PROG_AUTOMATE As Short = 4
	Private Const I_TYPE_ELEC_PROG_ROBOT As Short = 5
	Private Const I_TYPE_ELEC_VISION As Short = 6
	Private Const I_TYPE_ELEC_TEST As Short = 7
	Private Const I_TYPE_ELEC_FORMATION As Short = 8
	Private Const I_TYPE_ELEC_GESTION As Short = 9
	Private Const I_TYPE_ELEC_SHIPPING As Short = 10
	Private Const I_TYPE_ELEC_prototypage As Short = 11
	
	'Types quand c'est un 51
	Private Const I_TYPE_MEC_INSTALLATION As Short = 0
	
	'Types quand c'est pas un 51
	Private Const I_TYPE_MEC_DESSIN As Short = 0
	Private Const I_TYPE_MEC_COUPE As Short = 1
	Private Const I_TYPE_MEC_MACHINAGE As Short = 2
	Private Const I_TYPE_MEC_SOUDURE As Short = 3
	Private Const I_TYPE_MEC_ASSEMBLAGE As Short = 4
	Private Const I_TYPE_MEC_PEINTURE As Short = 5
	Private Const I_TYPE_MEC_TEST As Short = 6
	Private Const I_TYPE_MEC_FORMATION As Short = 7
	Private Const I_TYPE_MEC_GESTION As Short = 8
	Private Const I_TYPE_MEC_SHIPPING As Short = 9
	Private Const I_TYPE_MEC_prototypage As Short = 10
	
	Private Const I_LVW_PROJET As Short = 0
	Private Const I_LVW_DATE As Short = 1
	Private Const I_LVW_DEBUT As Short = 2
	Private Const I_LVW_FIN As Short = 3
	Private Const I_LVW_CLIENT As Short = 4
	Private Const I_LVW_TYPE As Short = 5
	Private Const I_LVW_COMMENTAIRE As Short = 6
	
	Private Const I_OPT_ELECTRIQUE As Short = 0
	Private Const I_OPT_MECANIQUE As Short = 1
	
	Private Enum enumMode
		MODE_INACTIF = 0
		MODE_MODIF = 1
		MODE_AJOUT = 2
	End Enum
	
	Private m_lIDPunch As Integer
	Public m_datSemaine As Date
	Private m_bModifProj As Boolean
	Private m_eMode As enumMode
	Private m_bClick As Boolean
	
	Private Sub ActiverControles(ByVal eMode As enumMode)
		
5: On Error GoTo AfficherErreur
		
		'Activation des controles dépendamment du mode choisi
10: Dim bListView As Boolean 'Pour le ListView
15: Dim bEmploye As Boolean 'Pour la liste des employés
20: Dim bSemaine As Boolean 'Pour le bouton de la semaine
25: Dim bChamps As Boolean 'Pour les champs
30: Dim bImprimer As Boolean 'Pour le bouton "Imprimer"
35: Dim bAjouter As Boolean 'Pour le bouton "Ajouter"
40: Dim bAnnuler As Boolean 'Pour le bouton "Annuler"
45: Dim bEnregistrer As Boolean 'Pour le bouton "Enregistrer"
50: Dim bFermer As Boolean 'Pour le bouton "Fermer"
		
55: m_eMode = eMode
		
60: Select Case eMode
			'Mode pour ouverture et après ajout et modif
			Case enumMode.MODE_INACTIF
65: bListView = True
70: bEmploye = True
75: bSemaine = True
80: bImprimer = True
85: bAjouter = True
90: bFermer = True
				
				'Mode pour la modification
95: Case enumMode.MODE_MODIF
100: bListView = True
105: bEmploye = True
110: bSemaine = True
115: bChamps = True
120: bImprimer = True
125: bAjouter = True
130: bAnnuler = True
135: bEnregistrer = True
140: bFermer = True
				
				'Mode pour l'ajout
145: Case enumMode.MODE_AJOUT
150: bChamps = True
155: bAnnuler = True
160: bEnregistrer = True
165: End Select
		
170: lvwPunch.Enabled = bListView
175: cmbemployé.Enabled = bEmploye
180: cmdDateSemaine.Enabled = bSemaine
185: mskNoProjet.Enabled = bChamps
190: mskDate.Enabled = bChamps
195: cmdDate.Enabled = bChamps
200: mskHeureDebut.Enabled = bChamps
205: mskHeureFin.Enabled = bChamps
210: txtCommentaires.Enabled = bChamps
215: cmbType.Enabled = bChamps
220: optTypePunch(I_OPT_ELECTRIQUE).Enabled = bChamps
225: optTypePunch(I_OPT_MECANIQUE).Enabled = bChamps
		
230: If g_bModificationFeuillesTemps = True Or (cmbemployé.Text = g_sEmploye) Then
235: cmdEnregistrer.Enabled = bEnregistrer
			cmdexcel.Enabled = bImprimer
240: cmdImprimer.Enabled = bImprimer
245: Cmdajouter.Enabled = bAjouter
250: Else
255: cmdEnregistrer.Enabled = False
			cmdexcel.Enabled = False
260: cmdImprimer.Enabled = False
265: Cmdajouter.Enabled = False
270: End If
		
275: cmdAnnuler.Visible = bAnnuler
280: Cmdfermer.Visible = bFermer
		
285: Exit Sub
		
AfficherErreur: 
		
290: Call AfficherErreur("frmFeuilleTemps", "ActiverControles", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkKM.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkKM_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkKM.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If chkKM.CheckState = System.Windows.Forms.CheckState.Checked Then
15: txtKM.Enabled = True
20: Else
25: txtKM.Text = ""
30: txtKM.Enabled = False
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmFeuilleTemps", "chkKM_Click", Err, Erl())
	End Sub
	
	Private Sub cmdexcel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdexcel.Click
		Dim xlworksheet As Excel.Workbook
		Dim xlsheet As Excel.Application
		Dim info As ADODB.Recordset
		Dim row As Short
		Dim i As Short
		
		
		
		xlsheet = New Excel.Application
		xlworksheet = xlsheet.Workbooks.Add
		
		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		xlsheet.Cells._Default(1, 1).Value = "Employé"
		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		xlsheet.Cells._Default(1, 4).Value = "Semaine Du:"
		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		xlsheet.Cells._Default(3, 1).Value = "Projet"
		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		xlsheet.Cells._Default(3, 2).Value = "Date"
		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		xlsheet.Cells._Default(3, 3).Value = "Début"
		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		xlsheet.Cells._Default(3, 4).Value = "Fin"
		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		xlsheet.Cells._Default(3, 5).Value = "Client"
		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		xlsheet.Cells._Default(3, 6).Value = "Type"
		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		xlsheet.Cells._Default(3, 7).Value = "Commentaire"
		
		With xlsheet.Range("A1;D1;A3:G3")
			.Font.Bold = True
			.Font.Size = 11
		End With
		
		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		xlsheet.Cells._Default(1, 2).Value = cmbemployé.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		xlsheet.Cells._Default(1, 5).Value = txtSemaine.Text
		
		
		
		row = 4
		For i = 1 To lvwPunch.Items.Count
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(row, 1).Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Lower bound of collection lvwPunch.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			xlsheet.Cells._Default(row, 1).Value = lvwPunch.Items.Item(i).Text
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(row, 2).Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Lower bound of collection lvwPunch.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwPunch.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			xlsheet.Cells._Default(row, 2).Value = lvwPunch.Items.Item(i).SubItems(1).Text
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(row, 3).Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Lower bound of collection lvwPunch.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwPunch.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			xlsheet.Cells._Default(row, 3).Value = lvwPunch.Items.Item(i).SubItems(2).Text
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(row, 4).Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Lower bound of collection lvwPunch.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwPunch.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			xlsheet.Cells._Default(row, 4).Value = lvwPunch.Items.Item(i).SubItems(3).Text
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(row, 5).Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Lower bound of collection lvwPunch.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwPunch.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			xlsheet.Cells._Default(row, 5).Value = lvwPunch.Items.Item(i).SubItems(4).Text
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(row, 6).Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Lower bound of collection lvwPunch.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwPunch.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			xlsheet.Cells._Default(row, 6).Value = lvwPunch.Items.Item(i).SubItems(5).Text
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(row, 7).Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Lower bound of collection lvwPunch.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwPunch.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			xlsheet.Cells._Default(row, 7).Value = lvwPunch.Items.Item(i).SubItems(6).Text
			row = row + 1
		Next 
		xlsheet.Range("A:G").Columns.AutoFit()
		
		
		
		
		
		
		
		xlsheet.Visible = True
		
		'UPGRADE_NOTE: Object xlsheet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		xlsheet = Nothing
		
		
		
	End Sub
	
	Private Sub cmdModifier_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdModifier.Click
		Call FrmModType.ShowDialog()
		
		
		
	End Sub
	
	'UPGRADE_WARNING: Event optTypePunch.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optTypePunch_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optTypePunch.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = optTypePunch.GetIndex(eventSender)
			
5: On Error GoTo AfficherErreur
			
10: If Index = I_OPT_ELECTRIQUE Then
15: lblPrefixe.Text = "E"
20: Else
25: lblPrefixe.Text = "M"
30: End If
			
35: Call RemplirComboType()
			
40: Exit Sub
			
AfficherErreur: 
			
45: Call AfficherErreur("frmFeuilleTemps", "optTypePunch_Click", Err, Erl())
		End If
	End Sub
	
	Private Sub Cmdajouter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cmdajouter.Click
		
5: On Error GoTo AfficherErreur
		
10: Call ViderChamps()
		
15: Call ActiverControles(enumMode.MODE_AJOUT)
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmFeuilleTemps", "cmdAjouter_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
		'Annuler l'ajout ou la modif
10: Call ViderChamps()
		
15: Call ActiverControles(enumMode.MODE_INACTIF)
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmFeuilleTemps", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDateSemaine_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDateSemaine.Click
		
5: On Error GoTo AfficherErreur
		
		'Affichage du calendrier pour choisir une semaine
10: Call OuvrirForm(frmFeuilleTempsCalendrier, True)
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFeuilleTemps", "cmdDateSemaine_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbEmployé.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbEmployé_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbEmployé.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		'Rempli le listview si la semaine a été choisie
10: Call ViderChamps()
		
15: Call ActiverControles(enumMode.MODE_INACTIF)
		
		'Il faut remplir le listview dépendant la semaine
20: If txtSemaine.Text <> vbNullString Then
25: Call RemplirListView()
30: End If
		
35: cmdEnregistrer.Enabled = False
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmFeuilleTemps", "cmbEmployé_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDate.Click
		
5: On Error GoTo AfficherErreur
		'Ouverture du calendrier
		
		'Si il y a une date valide, la date par défaut est celle-ci, sinon c'est la date
		'd'aujourd'hui
10: If Trim(mskDate.Text) <> vbNullString Then
15: If ValiderDate(mskDate.Text) = True Then
20: mvwDate.Value = CDate(mskDate.Text)
25: Else
30: mvwDate.Value = Today
35: End If
40: Else
45: mvwDate.Value = Today
50: End If
		
55: mvwDate.Visible = True
		
60: Call mvwDate.Focus()
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmFeuilleTemps", "cmdDate_Click", Err, Erl())
	End Sub
	
	Private Sub cmdEnregistrer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEnregistrer.Click
		
5: On Error GoTo AfficherErreur
		
		'Enregistrer l'ajout ou la modif
10: Dim rstPunch As ADODB.Recordset
15: Dim rstProjSoum As ADODB.Recordset
20: Dim bInstallation As Boolean
		
25: rstProjSoum = New ADODB.Recordset
		
30: Call rstProjSoum.Open("SELECT * FROM GRB_ProjSoum WHERE IDProjSoum = '" & lblPrefixe.Text & mskNoProjet.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
35: If Not rstProjSoum.EOF Then
40: If rstProjSoum.Fields("Ouvert").Value = False Then
45: Call MsgBox("Ce projet est fermé!", MsgBoxStyle.OKOnly, "Erreur")
				
50: Call rstProjSoum.Close()
55: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstProjSoum = Nothing
				
60: Exit Sub
65: End If
70: Else
75: Call MsgBox("Projet inexistant!", MsgBoxStyle.OKOnly, "Erreur")
			
80: Call rstProjSoum.Close()
85: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstProjSoum = Nothing
			
90: Exit Sub
95: End If
		
100: Call rstProjSoum.Close()
105: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjSoum = Nothing
		
		'Valider l'heure de début
110: If ValiderHeure(mskHeureDebut.Text) = False Then
115: Call MsgBox("L'heure de début est invalide!", MsgBoxStyle.OKOnly, "Erreur")
			
120: Exit Sub
125: Else
130: If mskHeureFin.Text <> "24:00" Then
135: If mskHeureFin.Text <> vbNullString Then
					'Valider l'heure de fin
140: If ValiderHeure(mskHeureFin.Text) = False Then
145: Call MsgBox("L'heure de fin est invalide!", MsgBoxStyle.OKOnly, "Erreur")
						
150: Exit Sub
155: End If
160: End If
165: End If
170: End If
		
		'Valider la date
175: If ValiderDate(mskDate.Text) = False Then
180: Call MsgBox("La date est invalide!", MsgBoxStyle.OKOnly, "Erreur")
			
185: Exit Sub
190: End If
		
		'Si les champs importants ont été rempli
195: If mskNoProjet.Text = vbNullString Or mskDate.Text = vbNullString Or mskHeureDebut.Text = vbNullString Then
200: Call MsgBox("Champs vide!", MsgBoxStyle.OKOnly, "Erreur")
			
205: Exit Sub
210: End If
		
		'Si les champs importants ont été rempli
215: If VB.Right(mskNoProjet.Text, 1) = "_" Then
220: Call MsgBox("Le numéro de projet est invalide!", MsgBoxStyle.OKOnly, "Erreur")
			
225: Exit Sub
230: End If
		
235: If cmbType.Text = "" And cmbType.Visible = True Then
240: Call MsgBox("Le type est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
			
245: Exit Sub
250: End If
		
255: rstPunch = New ADODB.Recordset
		
260: If m_eMode = enumMode.MODE_AJOUT Then
265: Call rstPunch.Open("SELECT * FROM  GRB_Punch", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
270: Call rstPunch.AddNew()
275: Else
280: Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE IDPunch = " & m_lIDPunch, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
285: End If
		
290: rstPunch.Fields("NoEmploye").Value = VB6.GetItemData(cmbemployé, cmbemployé.SelectedIndex)
		
295: rstPunch.Fields("NoProjet").Value = lblPrefixe.Text & mskNoProjet.Text
300: rstPunch.Fields("Date").Value = mskDate.Text
305: rstPunch.Fields("HeureDébut").Value = mskHeureDebut.Text
310: rstPunch.Fields("HeureFin").Value = mskHeureFin.Text
		
315: If chkKM.CheckState = System.Windows.Forms.CheckState.Checked Then
320: rstPunch.Fields("KM").Value = True
			
325: If txtKM.Text <> "" Then
330: txtKM.Text = Replace(txtKM.Text, ".", ",")
				
335: If IsNumeric(txtKM.Text) Then
340: rstPunch.Fields("NbreKM").Value = txtKM.Text
345: Else
350: rstPunch.Fields("NbreKM").Value = 0
355: End If
360: Else
365: txtKM.Text = CStr(0)
370: End If
375: Else
380: rstPunch.Fields("KM").Value = False
385: rstPunch.Fields("NbreKM").Value = ""
390: End If
		
395: If txtClient.Text <> vbNullString Then
400: rstPunch.Fields("NoClient").Value = txtClient.Tag
405: Else
410: rstPunch.Fields("NoClient").Value = vbNullString
415: End If
		
420: If IsNumeric(VB.Right(mskNoProjet.Text, 2)) Then
425: If CShort(VB.Right(mskNoProjet.Text, 2)) >= 51 And CShort(VB.Right(mskNoProjet.Text, 2)) <= 59 Then
430: bInstallation = True
435: Else
440: bInstallation = False
445: End If
450: Else
455: bInstallation = False
460: End If
		
465: If bInstallation = True Then
470: If lblPrefixe.Text = "E" Then
475: Select Case cmbType.SelectedIndex
					Case I_TYPE_ELEC_INSTALLATION : rstPunch.Fields("Type").Value = "Installation"
480: Case I_TYPE_ELEC_MISE_SERVICE : rstPunch.Fields("Type").Value = "MiseService"
485: End Select
490: Else
495: Select Case cmbType.SelectedIndex
					Case I_TYPE_MEC_INSTALLATION : rstPunch.Fields("Type").Value = "Installation"
500: End Select
505: End If
510: Else
515: If lblPrefixe.Text = "E" Then
				rstPunch.Fields("Type").Value = cmbType.Text
580: Else
				rstPunch.Fields("Type").Value = cmbType.Text
640: End If
645: End If
		
650: rstPunch.Fields("Commentaire").Value = txtCommentaires.Text
		
655: Call rstPunch.Update()
		
660: Call rstPunch.Close()
665: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPunch = Nothing
		
670: Call ViderChamps()
		
675: Call ActiverControles(enumMode.MODE_INACTIF)
		
680: Call RemplirListView()
		
685: Exit Sub
		
AfficherErreur: 
		
690: Call AfficherErreur("frmFeuilleTemps", "cmdEnregistrer_Click", Err, Erl())
	End Sub
	
	Private Function ValiderDate(ByVal sDate As String) As Boolean
		
5: On Error GoTo AfficherErreur
		
		'Validation des dates
10: If Not IsDate(sDate) Then
15: ValiderDate = False
20: Else
25: ValiderDate = True
30: End If
		
35: Exit Function
		
AfficherErreur: 
		
40: Call AfficherErreur("frmFeuilleTemps", "ValiderDate", Err, Erl())
	End Function
	
	Private Function ValiderHeure(ByVal sHeure As String) As Boolean
		
5: On Error GoTo AfficherErreur
		
		'validation des heures
10: Dim sHour As String
15: Dim sMinute As String
20: Dim sSecond As String
		
25: sHour = VB.Left(sHeure, 2)
		
30: sMinute = Mid(sHeure, 4, 2)
		
35: sSecond = VB.Right(sHeure, 2)
		
40: ValiderHeure = True
		
		'Si numérique
45: If Not IsNumeric(sHour) Then
50: ValiderHeure = False
			
55: Exit Function
60: Else
			'Si entre 0 et 23
65: If CDbl(sHour) < 0 Or CDbl(sHour) > 23 Then
70: ValiderHeure = False
				
75: Exit Function
80: End If
85: End If
		
		'Si numérique
90: If Not IsNumeric(sMinute) Then
95: ValiderHeure = False
			
100: Exit Function
105: Else
			'Si entre 0 et 59
110: If CDbl(sMinute) < 0 Or CDbl(sMinute) > 59 Then
115: ValiderHeure = False
				
120: Exit Function
125: End If
130: End If
		
		'Si numérique
135: If Not IsNumeric(sSecond) Then
140: ValiderHeure = False
			
145: Exit Function
150: Else
			'Si entre 0 et 59
155: If CDbl(sSecond) < 0 Or CDbl(sSecond) > 59 Then
160: ValiderHeure = False
				
165: Exit Function
170: End If
175: End If
		
180: Exit Function
		
AfficherErreur: 
		
185: Call AfficherErreur("frmFeuilleTemps", "ValiderHeure", Err, Erl())
	End Function
	
	Private Sub ViderChamps()
		
5: On Error GoTo AfficherErreur
		
		'Vider les champs
10: mskNoProjet.Text = "_____-__"
		
15: mskDate.Text = vbNullString
20: mskHeureDebut.Text = vbNullString
25: mskHeureFin.Text = vbNullString
30: txtCommentaires.Text = vbNullString
35: txtClient.Text = vbNullString
40: chkKM.CheckState = System.Windows.Forms.CheckState.Unchecked
45: cmbType.SelectedIndex = -1
		
50: txtKM.Text = vbNullString
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmFeuilleTemps", "ViderChamps", Err, Erl())
	End Sub
	
	Private Sub cmdexporter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdexporter.Click
		
5: On Error GoTo AfficherErreur
		
10: Call frmChoixDateImpressionFT.ShowDialog()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFeuilleTemps", "cmdExporter_Click", Err, Erl())
	End Sub
	
	Private Sub Cmdfermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cmdfermer.Click
		
5: On Error GoTo AfficherErreur
		
		'Fermeture de la fenêtre
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFeuilleTemps", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Public Sub RemplirListView()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le listview selon la semaine et l'employé choisi
10: Dim rstPunch As ADODB.Recordset
15: Dim rstNomClient As ADODB.Recordset
20: Dim itmPunch As System.Windows.Forms.ListViewItem
25: Dim sTemp As String
30: Dim iTemp As Short
35: Dim sDateDebut As String
40: Dim sDateFin As String
		
		'Il faut vider le ListView pour ne pas le remplir plein de fois
45: Call lvwPunch.Items.Clear()
		
50: sDateDebut = ConvertDate(m_datSemaine)
55: sDateFin = ConvertDate(GetLastDay(m_datSemaine))
		
60: rstNomClient = New ADODB.Recordset
65: rstPunch = New ADODB.Recordset
		
70: Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE noEmploye = " & VB6.GetItemData(cmbemployé, cmbemployé.SelectedIndex) & " AND Date BETWEEN '" & sDateDebut & "' AND '" & sDateFin & "' ORDER BY Date, HeureDébut", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
75: Do While Not rstPunch.EOF
80: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPunch.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmPunch = lvwPunch.Items.Add()
			
			'Numéro du projet
85: itmPunch.Text = rstPunch.Fields("noProjet").Value
			
			'IDPunch dans le tag
90: itmPunch.Tag = rstPunch.Fields("IDPunch").Value
			
			'Date
95: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPunch.SubItems.Count > I_LVW_DATE Then
				itmPunch.SubItems(I_LVW_DATE).Text = rstPunch.Fields("Date").Value
			Else
				itmPunch.SubItems.Insert(I_LVW_DATE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("Date").Value))
			End If
			
			'Heure de début
100: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPunch.SubItems.Count > I_LVW_DEBUT Then
				itmPunch.SubItems(I_LVW_DEBUT).Text = rstPunch.Fields("HeureDébut").Value
			Else
				itmPunch.SubItems.Insert(I_LVW_DEBUT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("HeureDébut").Value))
			End If
			
			'Heure de fin
105: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("HeureFin").Value) Then
110: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPunch.SubItems.Count > I_LVW_FIN Then
					itmPunch.SubItems(I_LVW_FIN).Text = rstPunch.Fields("HeureFin").Value
				Else
					itmPunch.SubItems.Insert(I_LVW_FIN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("HeureFin").Value))
				End If
115: Else
120: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPunch.SubItems.Count > I_LVW_FIN Then
					itmPunch.SubItems(I_LVW_FIN).Text = vbNullString
				Else
					itmPunch.SubItems.Insert(I_LVW_FIN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
125: End If
			
130: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("NoClient").Value) And rstPunch.Fields("NoClient").Value > "0" Then
135: Call rstNomClient.Open("SELECT NomClient FROM GRB_Client WHERE IDClient = " & rstPunch.Fields("NoClient").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
140: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPunch.SubItems.Count > I_LVW_CLIENT Then
					itmPunch.SubItems(I_LVW_CLIENT).Text = rstNomClient.Fields("NomClient").Value
				Else
					itmPunch.SubItems.Insert(I_LVW_CLIENT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstNomClient.Fields("NomClient").Value))
				End If
				
145: Call rstNomClient.Close()
150: Else
155: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPunch.SubItems.Count > I_LVW_CLIENT Then
					itmPunch.SubItems(I_LVW_CLIENT).Text = vbNullString
				Else
					itmPunch.SubItems.Insert(I_LVW_CLIENT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
160: End If
			
165: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("Type").Value) Then
170: If VB.Left(itmPunch.Text, 1) = "E" Then
					'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_TYPE Then
						itmPunch.SubItems(I_LVW_TYPE).Text = rstPunch.Fields("Type").Value
					Else
						itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("Type").Value))
					End If
245: Else
					'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_TYPE Then
						itmPunch.SubItems(I_LVW_TYPE).Text = rstPunch.Fields("Type").Value
					Else
						itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("Type").Value))
					End If
310: End If
315: End If
			
320: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("Commentaire").Value) Then
325: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPunch.SubItems.Count > I_LVW_COMMENTAIRE Then
					itmPunch.SubItems(I_LVW_COMMENTAIRE).Text = rstPunch.Fields("Commentaire").Value
				Else
					itmPunch.SubItems.Insert(I_LVW_COMMENTAIRE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("Commentaire").Value))
				End If
330: Else
335: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPunch.SubItems.Count > I_LVW_COMMENTAIRE Then
					itmPunch.SubItems(I_LVW_COMMENTAIRE).Text = vbNullString
				Else
					itmPunch.SubItems.Insert(I_LVW_COMMENTAIRE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
340: End If
			
345: Call rstPunch.MoveNext()
350: Loop 
		
355: Call rstPunch.Close()
360: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPunch = Nothing
		
365: 'UPGRADE_NOTE: Object rstNomClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstNomClient = Nothing
		
370: Exit Sub
		
AfficherErreur: 
		
375: Call AfficherErreur("frmFeuilleTemps", "RemplirListView", Err, Erl())
	End Sub
	
	Private Sub frmFeuilleTemps_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Dim datTemp As Date
15: Dim iNoJour As Short
		Call frmPunch.Table_exist()
20: Call RemplirComboEmploye()
		
		If g_admin = False Then
			Me.Width = VB6.TwipsToPixelsX(7350)
			txtCommentaires.Left = VB6.TwipsToPixelsX(3360)
			cmbType.Left = VB6.TwipsToPixelsX(3360)
			Label7.Left = VB6.TwipsToPixelsX(3360)
			lblType.Left = VB6.TwipsToPixelsX(3360)
			txtClient.Left = VB6.TwipsToPixelsX(3360)
			Label8.Left = VB6.TwipsToPixelsX(3360)
			lvwPunch.Width = VB6.TwipsToPixelsX(6975)
			cmdDateSemaine.Left = VB6.TwipsToPixelsX(6720)
			Cmdfermer.Left = VB6.TwipsToPixelsX(6000)
			cmdAnnuler.Left = VB6.TwipsToPixelsX(6000)
			txtSemaine.Left = VB6.TwipsToPixelsX(5040)
			lblSemaine.Left = VB6.TwipsToPixelsX(4080)
			cmdModifier.Visible = False
		End If
		
		
25: datTemp = Today
		
30: iNoJour = 1
		
		'Pour avoir la date de la semaine précédente
35: Do While iNoJour < 8
40: datTemp = System.Date.FromOADate(datTemp.ToOADate - TimeSerial(24, 0, 0).ToOADate)
			
45: iNoJour = iNoJour + 1
50: Loop 
		
55: m_datSemaine = GetFirstDay(datTemp)
		
		'On affiche le dimanche de la semaine précédente
60: txtSemaine.Text = GetDateTexte(m_datSemaine)
		
65: Call RemplirListView()
		
70: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmFeuilleTemps", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub RemplirComboEmploye()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des employés
10: Dim rstEmploye As ADODB.Recordset
		
		'Il faut vider le combo pour ne pas le remplir plein de fois
15: Call cmbemployé.Items.Clear()
		
20: rstEmploye = New ADODB.Recordset
		
25: Call rstEmploye.Open("SELECT * FROM GRB_Employés WHERE Actif = true", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
30: Do While Not rstEmploye.EOF
			'Ajout du nom de l'employé dans le combo
35: Call cmbemployé.Items.Add(rstEmploye.Fields("employe").Value)
			
			'Ajout du numéro de l'employé dans l'ItemData
40: 'UPGRADE_ISSUE: ComboBox property cmbemployé.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbemployé, cmbemployé.NewIndex, rstEmploye.Fields("noemploye").Value)
			
45: Call rstEmploye.MoveNext()
50: Loop 
		
55: Call rstEmploye.Close()
60: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
		'Si le combo n'est pas vide, on sélectionne le premier
65: If cmbemployé.Items.Count > 0 Then
70: cmbemployé.SelectedIndex = 0
75: End If
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmFeuilleTemps", "RemplirComboEmploye", Err, Erl())
	End Sub
	
	'UPGRADE_ISSUE: MSComctlLib.ListView event lvwPunch.ItemClick was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub lvwPunch_ItemClick(ByVal Item As System.Windows.Forms.ListViewItem)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPunch As ADODB.Recordset
15: Dim iCompteur As Short
		Dim G As Short
		
		
		'Si le ListView n'est pas vide
20: If lvwPunch.Items.Count > 0 Then
			'Pour aller chercher l'index du "punch" cliqué
25: 'UPGRADE_WARNING: Couldn't resolve default property of object Item.Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			m_lIDPunch = Item.Tag
			
30: rstPunch = New ADODB.Recordset
			
35: Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE IDPunch = " & m_lIDPunch, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
40: If VB.Left(rstPunch.Fields("NoProjet").Value, 1) = "E" Then
45: optTypePunch(I_OPT_ELECTRIQUE).Checked = True
50: Else
55: optTypePunch(I_OPT_MECANIQUE).Checked = True
60: End If
			
65: m_bClick = True
			
70: mskNoProjet.Text = VB.Right(rstPunch.Fields("NoProjet").Value, 8)
			
75: m_bClick = False
			
80: If mskDate.Mask = "##-##-##" Then
85: mskDate.Mask = vbNullString
90: End If
			
95: mskDate.Text = rstPunch.Fields("Date").Value
			
100: mskHeureDebut.Text = rstPunch.Fields("HeureDébut").Value
			
105: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("HeureFin").Value) Then
110: If rstPunch.Fields("HeureFin").Value <> "" Then
115: mskHeureFin.Text = rstPunch.Fields("HeureFin").Value
120: Else
125: mskHeureFin.Text = "__:__"
130: End If
135: Else
140: mskHeureFin.Text = "__:__"
145: End If
			
150: txtClient.Text = vbNullString
			
155: Call AfficherClient()
			
160: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("Type").Value) Then
				cmbType.SelectedIndex = -1
				
				If rstPunch.Fields("Type").Value = "Installation" Then
					cmbType.SelectedIndex = 0
					GoTo Fin_De_Type
				End If
				If rstPunch.Fields("Type").Value = "MiseService" Then
					cmbType.SelectedIndex = 1
					GoTo Fin_De_Type
				End If
				
				
165: If VB.Left(rstPunch.Fields("NoProjet").Value, 1) = "E" Then
					For G = 0 To cmbType.Items.Count
						If VB6.GetItemString(cmbType, G) = rstPunch.Fields("Type").Value Then
							cmbType.SelectedIndex = G
							Exit For
						End If
					Next 
245: Else
					For G = 0 To cmbType.Items.Count
						If VB6.GetItemString(cmbType, G) = rstPunch.Fields("Type").Value Then
							cmbType.SelectedIndex = G
							Exit For
						End If
					Next 
				End If
315: Fin_De_Type: 
320: End If
			
325: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("Commentaire").Value) Then
330: txtCommentaires.Text = rstPunch.Fields("Commentaire").Value
335: Else
340: txtCommentaires.Text = vbNullString
345: End If
			
350: If rstPunch.Fields("KM").Value = True Then
355: chkKM.CheckState = System.Windows.Forms.CheckState.Checked
				
360: txtKM.Text = rstPunch.Fields("NbreKM").Value
365: Else
370: chkKM.CheckState = System.Windows.Forms.CheckState.Unchecked
375: txtKM.Text = vbNullString
380: End If
			
385: Call rstPunch.Close()
390: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstPunch = Nothing
			
395: Call ActiverControles(enumMode.MODE_MODIF)
400: End If
		
405: Exit Sub
		
AfficherErreur: 
		
410: Call AfficherErreur("frmFeuilleTemps", "lvwPunch_ItemClick", Err, Erl())
	End Sub
	
	Private Sub lvwPunch_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lvwPunch.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		'Pour permettre d'effacer un enregistrement en appuyant sur "Delete" ou "Suppr"
		
		'Si il y a un enregistrement dans le listview
10: If lvwPunch.Items.Count > 0 Then
			'Si la touche appuyée est "Delete"
15: If KeyCode = System.Windows.Forms.Keys.Delete Then
				'Si l'utilisateur répond oui à "Etes vous sur?"
20: If MsgBox("Voulez-vous vraiment effacer le punch?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
					'Efface
25: Call g_connData.Execute("DELETE * FROM GRB_Punch WHERE IDPunch = " & lvwPunch.FocusedItem.Tag)
					
30: Call RemplirListView()
					
35: Call ViderChamps()
					
40: Call ActiverControles(enumMode.MODE_INACTIF)
					
45: If lvwPunch.Items.Count > 0 Then
						'Sélection du premier ListItem
50: 'UPGRADE_WARNING: Lower bound of collection lvwPunch.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						lvwPunch.Items.Item(1).Selected = True
55: 'UPGRADE_ISSUE: MSComctlLib.ListView event lvwPunch.ItemClick was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
						lvwPunch_ItemClick(lvwPunch.FocusedItem)
60: End If
65: End If
70: End If
75: End If
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmFeuilleTemps", "lvwPunch_KeyDown", Err, Erl())
	End Sub
	
	Private Sub mskNoProjet_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskNoProjet.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If InStr(1, mskNoProjet.Text, "_") = 0 Then
15: Call AfficherClient()
20: Else
25: txtClient.Text = vbNullString
30: End If
		
35: Call RemplirComboType()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmFeuilleTemps", "mskNoProjet_Change", Err, Erl())
	End Sub
	
	Private Sub AfficherClient()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjSoum As ADODB.Recordset
15: Dim rstClient As ADODB.Recordset
20: Dim iCompteur As Short
		
25: If m_bClick = False Then
30: rstProjSoum = New ADODB.Recordset
35: rstClient = New ADODB.Recordset
			
40: Call rstProjSoum.Open("SELECT * FROM GRB_ProjSoum WHERE IDProjSoum = '" & lblPrefixe.Text & mskNoProjet.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
45: If Not rstProjSoum.EOF Then
50: Call rstClient.Open("SELECT NomClient FROM GRB_Client WHERE IDClient = " & rstProjSoum.Fields("NoClient").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
55: txtClient.Text = rstClient.Fields("NomClient").Value
60: txtClient.Tag = rstProjSoum.Fields("NoClient").Value
				
65: Call rstClient.Close()
70: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstClient = Nothing
				
75: If rstProjSoum.Fields("Ouvert").Value = False Then
80: Call MsgBox("Ce projet n'est pas ouvert!", MsgBoxStyle.OKOnly, "Erreur")
85: End If
90: Else
95: Call MsgBox("Projet inexistant!", MsgBoxStyle.OKOnly, "Erreur")
100: End If
			
105: Call rstProjSoum.Close()
110: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstProjSoum = Nothing
115: End If
		
120: Exit Sub
		
AfficherErreur: 
		
125: Call AfficherErreur("frmFeuilleTemps", "AfficherClient", Err, Erl())
	End Sub
	
	Private Sub mvwDate_DateClick(ByVal eventSender As System.Object, ByVal eventArgs As AxMSComCtl2.DMonthViewEvents_DateClickEvent) Handles mvwDate.DateClick
		
5: On Error GoTo AfficherErreur
		
10: mskDate.Text = ConvertDate(eventArgs.DateClicked)
		
		'Enlever le calendrier
15: mvwDate.Visible = False
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmFeuilleTemps", "mvwDate_DateClick", Err, Erl())
	End Sub
	
	Private Sub mvwDate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mvwDate.Leave
		
5: On Error GoTo AfficherErreur
		'Quand le calendrier perd le focus, il faut l'enlever
		
10: mvwDate.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFeuilleTemps", "mvwDate_LostFocus", Err, Erl())
	End Sub
	
	Private Sub cmdImprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImprimer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call frmChoixImpressionFT.Afficher(m_datSemaine, GetLastDay(m_datSemaine))
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFeuilleTemps", "cmdImprimer_Click", Err, Erl())
	End Sub
	
	Private Sub mskDate_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDate.Enter
		
5: On Error GoTo AfficherErreur
		
		'Met l'année sur 2 chiffres
10: If Len(mskDate.Text) = 10 Then
15: mskDate.Text = VB.Right(mskDate.Text, 8)
20: End If
		
25: mskDate.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmFeuilleTemps", "mskDate_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskHeureDebut_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskHeureDebut.Enter
		
5: On Error GoTo AfficherErreur
		
		'Format d'heure
10: mskHeureDebut.Mask = "##:##"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFeuilleTemps", "mskHeureDebut_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskHeureFin_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskHeureFin.Enter
		
5: On Error GoTo AfficherErreur
		
		'Format d'heure
10: mskHeureFin.Mask = "##:##"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFeuilleTemps", "mskHeureFin_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskDate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDate.Leave
		
5: On Error GoTo AfficherErreur
		
		'Enlève le mask
10: mskDate.Mask = vbNullString
		
		'Vide le champs si l'utilisateur n'a rien écrit
15: If mskDate.Text = "__-__-__" Then
20: mskDate.Text = vbNullString
25: Else
			'Remet l'année sur 8 chiffres
30: If Len(mskDate.Text) = 8 Then
35: If IsDate(mskDate.Text) Then
40: mskDate.Text = Year(DateSerial(CInt(VB.Left(mskDate.Text, 2)), CInt(Mid(mskDate.Text, 4, 2)), CInt(VB.Right(mskDate.Text, 2)))) & Mid(mskDate.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmFeuilleTemps", "mskDate_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskHeureDebut_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskHeureDebut.Leave
		Dim heure As Date
5: On Error GoTo AfficherErreur
		
		'Enlève le mask
10: mskHeureDebut.Mask = vbNullString
		
		'Vide le champs si l'utilisateur n'a rien écrit
15: If mskHeureDebut.Text = "__:__" Then
20: mskHeureDebut.Text = vbNullString
25: 
		Else
			
30: heure = CDate(mskHeureDebut.Text)
			
			If Minute(heure) <= 5 Then
35: heure = TimeSerial(Hour(heure), 0, 0)
			Else
40: If Minute(heure) <= 24 Then
45: heure = TimeSerial(Hour(heure), 15, 0)
				Else
					If Minute(heure) <= 35 Then
50: heure = TimeSerial(Hour(heure), 30, 0)
					Else
						If Minute(heure) <= 54 Then
55: heure = TimeSerial(Hour(heure), 45, 0)
						Else
60: heure = TimeSerial(Hour(heure) + 1, 0, 0)
						End If
					End If
				End If
			End If
			
65: mskHeureDebut.Text = VB.Right("0" & Hour(heure), 2) & ":" & VB.Right("0" & Minute(heure), 2)
			
			
			
		End If
		
		
		
		
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmFeuilleTemps", "mskHeureDebut_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskHeureFin_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskHeureFin.Leave
		Dim heure As Date
5: On Error GoTo AfficherErreur
		
		'Enlève le mask
10: mskHeureFin.Mask = vbNullString
		
		'Vide le champs si l'utilisateur n'a rien écrit
15: If mskHeureFin.Text = "__:__" Then
20: mskHeureFin.Text = vbNullString
		Else
25: heure = CDate(mskHeureFin.Text)
			
			If Minute(heure) <= 5 Then
30: heure = TimeSerial(Hour(heure), 0, 0)
			Else
35: If Minute(heure) <= 24 Then
40: heure = TimeSerial(Hour(heure), 15, 0)
				Else
45: If Minute(heure) <= 35 Then
50: heure = TimeSerial(Hour(heure), 30, 0)
					Else
						If Minute(heure) <= 54 Then
55: heure = TimeSerial(Hour(heure), 45, 0)
						Else
60: heure = TimeSerial(Hour(heure) + 1, 0, 0)
						End If
					End If
				End If
			End If
			
65: mskHeureFin.Text = VB.Right("0" & Hour(heure), 2) & ":" & VB.Right("0" & Minute(heure), 2)
			
			
			
		End If
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmFeuilleTemps", "mskHeureFin_LostFocus", Err, Erl())
	End Sub
	
	Private Sub txtKM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtKM.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtKM.Text = Replace(txtKM.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmFeuilleTemps", "txtKM_LostFocus", Err, Erl())
	End Sub
	
	Public Sub RemplirComboType()
		
5: On Error GoTo AfficherErreur
		
10: Dim bInstallation As Boolean
15: Dim bTypeInutile As Boolean
		Dim tbltype As ADODB.Recordset
		tbltype = New ADODB.Recordset
		
20: Call cmbType.Items.Clear()
		
25: If Mid(mskNoProjet.Text, 2, 1) = "1" Then
30: bTypeInutile = True
35: End If
		
40: If IsNumeric(VB.Right(mskNoProjet.Text, 2)) Then
45: If Mid(mskNoProjet.Text, 2, 4) <> "3000" Then
50: If CShort(VB.Right(mskNoProjet.Text, 2)) >= 51 And CShort(VB.Right(mskNoProjet.Text, 2)) <= 59 Then
55: bInstallation = True
60: End If
65: Else
70: bTypeInutile = True
75: End If
80: End If
		
85: If bTypeInutile = False Then
90: lblType.Visible = True
95: cmbType.Visible = True
			
100: If bInstallation = True Then
105: If lblPrefixe.Text = "E" Then
110: Call cmbType.Items.Add("Installation")
115: Call cmbType.Items.Add("Mise en service")
120: Else
125: Call cmbType.Items.Add("Installation")
130: End If
135: Else
140: If lblPrefixe.Text = "E" Then
145: Call tbltype.Open("select * from TBL_Punch_Type Where Mode = 'E' Order by name", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
150: Do While Not tbltype.EOF
155: cmbType.Items.Add((tbltype.Fields("Name").Value))
160: Call tbltype.MoveNext()
165: Loop 
170: Call tbltype.Close()
175: 'UPGRADE_NOTE: Object tbltype may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					tbltype = Nothing
					
					
					
					
200: Else
205: 
210: Call tbltype.Open("select * from TBL_Punch_Type Where Mode = 'M' Order by name ", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
215: Do While Not tbltype.EOF
220: cmbType.Items.Add((tbltype.Fields("Name").Value))
225: Call tbltype.MoveNext()
230: Loop 
235: Call tbltype.Close()
240: 'UPGRADE_NOTE: Object tbltype may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					tbltype = Nothing
255: End If
260: End If
265: Else
270: lblType.Visible = False
275: cmbType.Visible = False
280: End If
		
285: Exit Sub
		
AfficherErreur: 
		
290: Call AfficherErreur("frmFeuilleTemps", "RemplirComboType", Err, Erl())
	End Sub
End Class