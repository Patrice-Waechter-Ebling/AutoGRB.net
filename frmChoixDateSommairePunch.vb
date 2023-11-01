Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmChoixDateSommairePunch
	Inherits System.Windows.Forms.Form
	
	Private Const I_OPT_TOUS_LES_PROJETS As Short = 0
	Private Const I_OPT_PROJETS_GRB As Short = 1
	Private Const I_OPT_SOMMAIRE_HEURES As Short = 2
	
	
	Private Enum enumDate
		AUCUNE = 0
		DEBUT = 1
		Fin = 2
	End Enum
	
	Private m_eDate As enumDate
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDateSommairePunch", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdImprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImprimer.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim bChecked As Boolean
		
20: If ValiderDate(mskDateDebut.Text) = False Then
25: Call MsgBox("Date de début invalide!", MsgBoxStyle.OKOnly, "Erreur")
			
30: Exit Sub
35: End If
		
40: If ValiderDate(mskDateFin.Text) = False Then
45: Call MsgBox("Date de fin invalide!", MsgBoxStyle.OKOnly, "Erreur")
			
50: Exit Sub
55: End If
		
60: If mskDateFin.Text < mskDateDebut.Text Then
65: Call MsgBox("La date de fin doit être plus grande que la date de début!", MsgBoxStyle.OKOnly, "Erreur")
			
70: Exit Sub
75: End If
		
		'Si "Projets GRB seulement" est choisi
80: If optProjets(I_OPT_PROJETS_GRB).Checked = True Then
			'Si aucune famille est sélectionnée
85: For iCompteur = 1 To lvwFamille.Items.Count
90: 'UPGRADE_WARNING: Lower bound of collection lvwFamille.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwFamille.Items.Item(iCompteur).Checked = True Then
95: bChecked = True
					
100: Exit For
105: End If
110: Next 
			
115: If bChecked = False Then
120: Call MsgBox("Vous devez choisir au moins une famille d'employés!", MsgBoxStyle.OKOnly, "Erreur")
				
125: Exit Sub
130: End If
135: End If
		
140: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
145: If optProjets(I_OPT_TOUS_LES_PROJETS).Checked = True Then
150: Call ImprimerPunchGeneral()
155: Else
160: If optProjets(I_OPT_PROJETS_GRB).Checked = True Then
165: Call ImprimerPunchGRB()
170: Else
175: Call ImprimerSommaireHeures()
180: End If
185: End If
		
190: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
195: Call Me.Close()
		
200: Exit Sub
		
AfficherErreur: 
		
205: Call AfficherErreur("frmChoixDateSommairePunch", "cmdExporter_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixDateSommairePunch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Click
		
5: On Error GoTo AfficherErreur
		
10: mvwDate.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDateSommairePunch", "Form_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixDateSommairePunch_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: m_eDate = enumDate.AUCUNE
		
15: Call RemplirListViewFamille()
		
20: optProjets(I_OPT_TOUS_LES_PROJETS).Checked = System.Windows.Forms.CheckState.Checked
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixDateSommairePunch", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewFamille()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstFamille As ADODB.Recordset
15: Dim itmFamille As System.Windows.Forms.ListViewItem
		
20: rstFamille = New ADODB.Recordset
		
25: Call rstFamille.Open("SELECT * FROM GRB_Famille ORDER BY Famille", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
30: Do While Not rstFamille.EOF
35: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwFamille.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmFamille = lvwFamille.Items.Add()
			
40: itmFamille.Text = rstFamille.Fields("Famille").Value
45: itmFamille.Tag = rstFamille.Fields("IDFamille").Value
			
50: Call rstFamille.MoveNext()
55: Loop 
		
60: Call rstFamille.Close()
65: 'UPGRADE_NOTE: Object rstFamille may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFamille = Nothing
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmChoixDateSommairePunch", "RemplirListViewFamille", Err, Erl())
	End Sub
	
	Private Sub mvwDate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mvwDate.Leave
		
5: On Error GoTo AfficherErreur
		
10: mvwDate.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDateSommairePunch", "mvwDate_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mvwDate_DateClick(ByVal eventSender As System.Object, ByVal eventArgs As AxMSComCtl2.DMonthViewEvents_DateClickEvent) Handles mvwDate.DateClick
		
5: On Error GoTo AfficherErreur
		
10: Select Case m_eDate
			Case enumDate.DEBUT : mskDateDebut.Text = ConvertDate(eventArgs.DateClicked)
			Case enumDate.Fin : mskDateFin.Text = ConvertDate(eventArgs.DateClicked)
15: End Select
		
20: m_eDate = enumDate.AUCUNE
		
		'Enlever le calendrier
25: mvwDate.Visible = False
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixDateSommairePunch", "mvwDate_DateClick", Err, Erl())
	End Sub
	
	Private Sub mskDateDebut_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateDebut.Enter
		
5: On Error GoTo AfficherErreur
		
		'Met l'année sur 2 chiffres
10: If Len(mskDateDebut.Text) = 10 Then
15: mskDateDebut.Text = VB.Right(mskDateDebut.Text, 8)
20: End If
		
25: mskDateDebut.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixDateSommairePunch", "mskDateDebut_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateFin_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateFin.Enter
		
5: On Error GoTo AfficherErreur
		
		'Met l'année sur 2 chiffres
10: If Len(mskDateFin.Text) = 10 Then
15: mskDateFin.Text = VB.Right(mskDateFin.Text, 8)
20: End If
		
25: mskDateFin.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixDateSommairePunch", "mskDateFin_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateDebut_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateDebut.Leave
		
5: On Error GoTo AfficherErreur
		
		'Enlève le mask
10: mskDateDebut.Mask = vbNullString
		
		'Vide le champs si l'utilisateur n'a rien écrit
15: If mskDateDebut.Text = "__-__-__" Then
20: mskDateDebut.Text = vbNullString
25: Else
			'Remet l'année sur 8 chiffres
30: If Len(mskDateDebut.Text) = 8 Then
35: If IsDate(mskDateDebut.Text) Then
40: mskDateDebut.Text = Year(DateSerial(CInt(VB.Left(mskDateDebut.Text, 2)), CInt(Mid(mskDateDebut.Text, 4, 2)), CInt(VB.Right(mskDateDebut.Text, 2)))) & Mid(mskDateDebut.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmChoixDateSommairePunch", "mskDateDebut_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateFin_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateFin.Leave
		
5: On Error GoTo AfficherErreur
		
		'Enlève le mask
10: mskDateFin.Mask = vbNullString
		
		'Vide le champs si l'utilisateur n'a rien écrit
15: If mskDateFin.Text = "__-__-__" Then
20: mskDateFin.Text = vbNullString
25: Else
			'Remet l'année sur 8 chiffres
30: If Len(mskDateFin.Text) = 8 Then
35: If IsDate(mskDateFin.Text) Then
40: mskDateFin.Text = Year(DateSerial(CInt(VB.Left(mskDateFin.Text, 2)), CInt(Mid(mskDateFin.Text, 4, 2)), CInt(VB.Right(mskDateFin.Text, 2)))) & Mid(mskDateFin.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmChoixDateSommairePunch", "mskDateFin_LostFocus", Err, Erl())
	End Sub
	
	Private Sub cmdDateDebut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDateDebut.Click
		
5: On Error GoTo AfficherErreur
		'Ouverture du calendrier
		
		'Si il y a une date valide, la date par défaut est celle-ci, sinon c'est la date
		'd'aujourd'hui
10: If Trim(mskDateDebut.Text) <> vbNullString Then
15: If ValiderDate(mskDateDebut.Text) = True Then
20: mvwDate.Value = CDate(mskDateDebut.Text)
25: Else
30: mvwDate.Value = Today
35: End If
40: Else
45: mvwDate.Value = Today
50: End If
		
55: m_eDate = enumDate.DEBUT
		
60: mvwDate.Visible = True
		
65: Call mvwDate.Focus()
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmChoixDateSommairePunch", "cmdDateDebut_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDateFin_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDateFin.Click
		
5: On Error GoTo AfficherErreur
		'Ouverture du calendrier
		
		'Si il y a une date valide, la date par défaut est celle-ci, sinon c'est la date
		'd'aujourd'hui
10: If Trim(mskDateFin.Text) <> vbNullString Then
15: If ValiderDate(mskDateFin.Text) = True Then
20: mvwDate.Value = CDate(mskDateFin.Text)
25: Else
30: mvwDate.Value = Today
35: End If
40: Else
45: mvwDate.Value = Today
50: End If
		
55: m_eDate = enumDate.Fin
		
60: mvwDate.Visible = True
		
65: Call mvwDate.Focus()
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmChoixDateSommairePunch", "cmdDateFin_Click", Err, Erl())
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
		
40: Call AfficherErreur("frmChoixDateSommairePunch", "ValiderDate", Err, Erl())
	End Function
	
	Private Sub ImprimerPunchGeneral()
		Dim DR_ListeProjets As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjets As ADODB.Recordset
15: Dim rstHeures As ADODB.Recordset
20: Dim rstSommaire As ADODB.Recordset
25: Dim datDebut As Date
30: Dim datFin As Date
35: Dim dblTotal As Double
40: Dim dblSecondes As Double
45: Dim dblHeures As Double
		
50: Call g_connData.Execute("DELETE * FROM GRB_ImpressionSommairePunchGeneral")
		
55: rstSommaire = New ADODB.Recordset
60: rstProjets = New ADODB.Recordset
65: rstHeures = New ADODB.Recordset
		
70: Call rstSommaire.Open("SELECT * FROM GRB_ImpressionSommairePunchGeneral", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
75: Call rstProjets.Open("SELECT DISTINCT NoProjet FROM GRB_Punch WHERE Date BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
80: Do While Not rstProjets.EOF
85: Call rstSommaire.AddNew()
			
90: rstSommaire.Fields("NoProjet").Value = rstProjets.Fields("NoProjet").Value
			
95: Call rstHeures.Open("SELECT HeureDébut, HeureFin FROM GRB_Punch WHERE NoProjet = '" & rstProjets.Fields("NoProjet").Value & "' AND Date BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' AND HeureFin is not Null", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
100: dblTotal = 0
			
105: Do While Not rstHeures.EOF
110: datDebut = rstHeures.Fields("HeureDébut").Value
				
115: If rstHeures.Fields("HeureFin").Value = "24:00" Then
120: datFin = TimeSerial(24, 0, 0)
125: Else
130: datFin = rstHeures.Fields("HeureFin").Value
135: End If
				
140: 'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
				dblSecondes = DateDiff(Microsoft.VisualBasic.DateInterval.Second, datDebut, datFin)
				
145: dblHeures = Int(dblSecondes / 3600)
				
150: dblSecondes = dblSecondes - (3600 * dblHeures)
				
155: dblTotal = dblTotal + dblHeures + System.Math.Round(dblSecondes / 3600, 2)
				
160: Call rstHeures.MoveNext()
165: Loop 
			
170: Call rstHeures.Close()
			
175: rstSommaire.Fields("Total").Value = dblTotal
			
180: Call rstSommaire.Update()
			
185: Call rstProjets.MoveNext()
190: Loop 
		
195: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeProjets.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ListeProjets.DataSource = rstSommaire
		
200: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeProjets.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ListeProjets.Sections("Section4").Controls("lblDateDebut").Caption = mskDateDebut.Text
205: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeProjets.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ListeProjets.Sections("Section4").Controls("lblDateFin").Caption = mskDateFin.Text
		
210: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeProjets.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_ListeProjets.Show(VB6.FormShowConstants.Modal)
		
215: Call rstSommaire.Close()
		
220: 'UPGRADE_NOTE: Object rstSommaire may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstSommaire = Nothing
225: 'UPGRADE_NOTE: Object rstHeures may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstHeures = Nothing
230: 'UPGRADE_NOTE: Object rstProjets may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjets = Nothing
		
235: Exit Sub
		
AfficherErreur: 
		
240: Call AfficherErreur("frmChoixDateSommairePunch", "ImprimerPunch", Err, Erl())
	End Sub
	
	Private Sub ImprimerPunchGRB()
		Dim DR_SommairePunchGRB As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPunch As ADODB.Recordset
15: Dim rstSommaire As ADODB.Recordset
20: Dim datDebut As Date
25: Dim datFin As Date
30: Dim dblTotal As Double
35: Dim dblSecondes As Double
40: Dim dblHeures As Double
45: Dim dblTotalHeures As Double
50: Dim dblTotalKM As Double
55: Dim sWhere As String
60: Dim sWhereFamille As String
65: Dim iCompteur As Short
		
70: Call g_connData.Execute("DELETE * FROM GRB_ImpressionSommairePunchGRB")
		
75: rstSommaire = New ADODB.Recordset
80: rstPunch = New ADODB.Recordset
		
85: Call rstSommaire.Open("SELECT * FROM GRB_ImpressionSommairePunchGRB", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
90: sWhere = "((Left(NoProjet, 6) = 'E" & VB.Right(CStr(Year(Today)), 1) & "3000' OR Left(NoProjet, 6) = 'M" & VB.Right(CStr(Year(Today)), 1) & "3000') AND Date BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' AND HeureFin Is Not Null)"
		
95: For iCompteur = 1 To lvwFamille.Items.Count
100: 'UPGRADE_WARNING: Lower bound of collection lvwFamille.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwFamille.Items.Item(iCompteur).Checked = True Then
105: If sWhereFamille = "" Then
110: 'UPGRADE_WARNING: Lower bound of collection lvwFamille.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					sWhereFamille = " AND (Famille = " & lvwFamille.Items.Item(iCompteur).Tag
115: Else
120: 'UPGRADE_WARNING: Lower bound of collection lvwFamille.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					sWhereFamille = sWhereFamille & " OR Famille = " & lvwFamille.Items.Item(iCompteur).Tag
125: End If
130: End If
135: Next 
		
140: sWhere = sWhere & sWhereFamille & ")"
		
145: Call rstPunch.Open("SELECT employe, NoProjet, Date, HeureDébut, HeureFin, NbreKM, Commentaire FROM GRB_employés INNER JOIN GRB_Punch ON GRB_employés.noemploye = GRB_Punch.NoEmploye WHERE " & sWhere & " ORDER BY employe, Date, HeureDébut, HeureFin", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
150: Do While Not rstPunch.EOF
155: Call rstSommaire.AddNew()
			
160: rstSommaire.Fields("Employé").Value = rstPunch.Fields("employe").Value
165: rstSommaire.Fields("NoProjet").Value = rstPunch.Fields("NoProjet").Value
170: rstSommaire.Fields("Date").Value = rstPunch.Fields("Date").Value
175: rstSommaire.Fields("Commentaire").Value = rstPunch.Fields("Commentaire").Value
180: rstSommaire.Fields("HeureDébut").Value = rstPunch.Fields("HeureDébut").Value
185: rstSommaire.Fields("HeureFin").Value = rstPunch.Fields("HeureFin").Value
190: rstSommaire.Fields("NbreKM").Value = rstPunch.Fields("NbreKM").Value
			
195: datDebut = rstPunch.Fields("HeureDébut").Value
			
200: If rstPunch.Fields("HeureFin").Value = "24:00" Then
205: datFin = TimeSerial(24, 0, 0)
210: Else
215: datFin = rstPunch.Fields("HeureFin").Value
220: End If
			
225: 'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
			dblSecondes = DateDiff(Microsoft.VisualBasic.DateInterval.Second, datDebut, datFin)
			
230: dblHeures = Int(dblSecondes / 3600)
			
235: dblSecondes = dblSecondes - (3600 * dblHeures)
			
240: dblTotal = dblHeures + System.Math.Round(dblSecondes / 3600, 2)
			
245: dblTotalHeures = dblTotalHeures + dblTotal
			
250: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("NbreKM").Value) Then
255: If Trim(rstPunch.Fields("NbreKM").Value) <> "" Then
260: dblTotalKM = dblTotalKM + rstPunch.Fields("NbreKM").Value
265: End If
270: End If
			
275: rstSommaire.Fields("Total").Value = dblTotal
			
280: Call rstSommaire.Update()
			
285: Call rstPunch.MoveNext()
290: Loop 
		
295: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommairePunchGRB.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommairePunchGRB.DataSource = rstSommaire
		
300: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommairePunchGRB.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommairePunchGRB.Orientation = MSDataReportLib.OrientationConstants.rptOrientLandscape
		
305: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommairePunchGRB.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommairePunchGRB.Sections("Section4").Controls("lblDateDebut").Caption = mskDateDebut.Text
310: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommairePunchGRB.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommairePunchGRB.Sections("Section4").Controls("lblDateFin").Caption = mskDateFin.Text
		
315: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommairePunchGRB.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommairePunchGRB.Sections("Section5").Controls("lblGrandTotal").Caption = dblTotalHeures
320: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommairePunchGRB.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommairePunchGRB.Sections("Section5").Controls("lblGrandTotalKM").Caption = dblTotalKM
		
325: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommairePunchGRB.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_SommairePunchGRB.Show(VB6.FormShowConstants.Modal)
		
330: Call rstSommaire.Close()
		
335: 'UPGRADE_NOTE: Object rstSommaire may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstSommaire = Nothing
340: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPunch = Nothing
		
345: Exit Sub
		
AfficherErreur: 
		
350: Call AfficherErreur("frmChoixDateSommairePunch", "ImprimerPunch", Err, Erl())
	End Sub
	
	Private Sub ImprimerSommaireHeures()
		Dim DR_SommaireHeures As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPunch As ADODB.Recordset
15: Dim datDebut As Date
20: Dim datFin As Date
25: Dim dblSoumElec As Double
30: Dim dblSoumMec As Double
35: Dim dblProjGRBElec As Double
40: Dim dblProjGRBMec As Double
45: Dim dblProjElec As Double
50: Dim dblProjMec As Double
55: Dim dblFabElec As Double
60: Dim dblFabMec As Double
65: Dim dblRechElec As Double
70: Dim dblRechMec As Double
75: Dim dblAppelsElec As Double
80: Dim dblAppelsMec As Double
85: Dim dblGrandTotal As Double
90: Dim dblSecondes As Double
95: Dim dblHeures As Double
100: Dim dblTotalHeures As Double
105: Dim sWhere As String
		
110: rstPunch = New ADODB.Recordset
		
		'Soumissions électriques
115: sWhere = "(LEFT(NoProjet, 1) = 'E' AND MID(NoProjet, 3, 1) = '1' AND Date BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' AND HeureFin Is Not Null)"
		
120: Call rstPunch.Open("SELECT Date, HeureDébut, HeureFin FROM GRB_Punch WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
125: Do While Not rstPunch.EOF
130: datDebut = rstPunch.Fields("HeureDébut").Value
			
135: If rstPunch.Fields("HeureFin").Value = "24:00" Then
140: datFin = TimeSerial(24, 0, 0)
145: Else
150: datFin = rstPunch.Fields("HeureFin").Value
155: End If
			
160: 'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
			dblSecondes = DateDiff(Microsoft.VisualBasic.DateInterval.Second, datDebut, datFin)
			
165: dblHeures = Int(dblSecondes / 3600)
			
170: dblSecondes = dblSecondes - (3600 * dblHeures)
			
175: dblSoumElec = dblSoumElec + (dblHeures + System.Math.Round(dblSecondes / 3600, 2))
			
180: Call rstPunch.MoveNext()
185: Loop 
		
190: Call rstPunch.Close()
		
		'Soumissions mécaniques
195: sWhere = "(LEFT(NoProjet, 1) = 'M' AND MID(NoProjet, 3, 1) = '1' AND Date BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' AND HeureFin Is Not Null)"
		
200: Call rstPunch.Open("SELECT Date, HeureDébut, HeureFin FROM GRB_Punch WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
205: Do While Not rstPunch.EOF
210: datDebut = rstPunch.Fields("HeureDébut").Value
			
215: If rstPunch.Fields("HeureFin").Value = "24:00" Then
220: datFin = TimeSerial(24, 0, 0)
225: Else
230: datFin = rstPunch.Fields("HeureFin").Value
235: End If
			
240: 'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
			dblSecondes = DateDiff(Microsoft.VisualBasic.DateInterval.Second, datDebut, datFin)
			
245: dblHeures = Int(dblSecondes / 3600)
			
250: dblSecondes = dblSecondes - (3600 * dblHeures)
			
255: dblSoumMec = dblSoumMec + (dblHeures + System.Math.Round(dblSecondes / 3600, 2))
			
260: Call rstPunch.MoveNext()
265: Loop 
		
270: Call rstPunch.Close()
		
		'Projets GRB électriques
275: sWhere = "(LEFT(NoProjet, 1) = 'E' AND MID(NoProjet, 3, 4) = '3000' AND Date BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' AND HeureFin Is Not Null)"
		
280: Call rstPunch.Open("SELECT Date, HeureDébut, HeureFin FROM GRB_Punch WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
285: Do While Not rstPunch.EOF
290: datDebut = rstPunch.Fields("HeureDébut").Value
			
295: If rstPunch.Fields("HeureFin").Value = "24:00" Then
300: datFin = TimeSerial(24, 0, 0)
305: Else
310: datFin = rstPunch.Fields("HeureFin").Value
315: End If
			
320: 'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
			dblSecondes = DateDiff(Microsoft.VisualBasic.DateInterval.Second, datDebut, datFin)
			
325: dblHeures = Int(dblSecondes / 3600)
			
330: dblSecondes = dblSecondes - (3600 * dblHeures)
			
335: dblProjGRBElec = dblProjGRBElec + (dblHeures + System.Math.Round(dblSecondes / 3600, 2))
			
340: Call rstPunch.MoveNext()
345: Loop 
		
350: Call rstPunch.Close()
		
		'Projets GRB mécaniques
355: sWhere = "(LEFT(NoProjet, 1) = 'M' AND MID(NoProjet, 3, 4) = '3000' AND Date BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' AND HeureFin Is Not Null)"
		
360: Call rstPunch.Open("SELECT Date, HeureDébut, HeureFin FROM GRB_Punch WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
365: Do While Not rstPunch.EOF
370: datDebut = rstPunch.Fields("HeureDébut").Value
			
375: If rstPunch.Fields("HeureFin").Value = "24:00" Then
380: datFin = TimeSerial(24, 0, 0)
385: Else
390: datFin = rstPunch.Fields("HeureFin").Value
395: End If
			
400: 'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
			dblSecondes = DateDiff(Microsoft.VisualBasic.DateInterval.Second, datDebut, datFin)
			
405: dblHeures = Int(dblSecondes / 3600)
			
410: dblSecondes = dblSecondes - (3600 * dblHeures)
			
415: dblProjGRBMec = dblProjGRBMec + (dblHeures + System.Math.Round(dblSecondes / 3600, 2))
			
420: Call rstPunch.MoveNext()
425: Loop 
		
430: Call rstPunch.Close()
		
		'Projets électriques
435: sWhere = "(LEFT(NoProjet, 1) = 'E' AND MID(NoProjet, 3, 1) = '3' AND MID(NoProjet, 3, 4) <> '3000' AND Date BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' AND HeureFin Is Not Null)"
		
440: Call rstPunch.Open("SELECT Date, HeureDébut, HeureFin FROM GRB_Punch WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
445: Do While Not rstPunch.EOF
450: datDebut = rstPunch.Fields("HeureDébut").Value
			
455: If rstPunch.Fields("HeureFin").Value = "24:00" Then
460: datFin = TimeSerial(24, 0, 0)
465: Else
470: datFin = rstPunch.Fields("HeureFin").Value
475: End If
			
480: 'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
			dblSecondes = DateDiff(Microsoft.VisualBasic.DateInterval.Second, datDebut, datFin)
			
485: dblHeures = Int(dblSecondes / 3600)
			
490: dblSecondes = dblSecondes - (3600 * dblHeures)
			
495: dblProjElec = dblProjElec + (dblHeures + System.Math.Round(dblSecondes / 3600, 2))
			
500: Call rstPunch.MoveNext()
505: Loop 
		
510: Call rstPunch.Close()
		
		'Projets mécaniques
515: sWhere = "(LEFT(NoProjet, 1) = 'M' AND MID(NoProjet, 3, 1) = '3' AND MID(NoProjet, 3, 4) <> '3000' AND Date BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' AND HeureFin Is Not Null)"
		
520: Call rstPunch.Open("SELECT Date, HeureDébut, HeureFin FROM GRB_Punch WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
525: Do While Not rstPunch.EOF
530: datDebut = rstPunch.Fields("HeureDébut").Value
			
535: If rstPunch.Fields("HeureFin").Value = "24:00" Then
540: datFin = TimeSerial(24, 0, 0)
545: Else
550: datFin = rstPunch.Fields("HeureFin").Value
555: End If
			
560: 'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
			dblSecondes = DateDiff(Microsoft.VisualBasic.DateInterval.Second, datDebut, datFin)
			
565: dblHeures = Int(dblSecondes / 3600)
			
570: dblSecondes = dblSecondes - (3600 * dblHeures)
			
575: dblProjMec = dblProjMec + (dblHeures + System.Math.Round(dblSecondes / 3600, 2))
			
580: Call rstPunch.MoveNext()
585: Loop 
		
590: Call rstPunch.Close()
		
		'Fabrication électrique
595: sWhere = "(LEFT(NoProjet, 1) = 'E' AND MID(NoProjet, 3, 1) = '4' AND Date BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' AND HeureFin Is Not Null)"
		
600: Call rstPunch.Open("SELECT Date, HeureDébut, HeureFin FROM GRB_Punch WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
605: Do While Not rstPunch.EOF
610: datDebut = rstPunch.Fields("HeureDébut").Value
			
615: If rstPunch.Fields("HeureFin").Value = "24:00" Then
620: datFin = TimeSerial(24, 0, 0)
625: Else
630: datFin = rstPunch.Fields("HeureFin").Value
635: End If
			
640: 'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
			dblSecondes = DateDiff(Microsoft.VisualBasic.DateInterval.Second, datDebut, datFin)
			
645: dblHeures = Int(dblSecondes / 3600)
			
650: dblSecondes = dblSecondes - (3600 * dblHeures)
			
655: dblFabElec = dblFabElec + (dblHeures + System.Math.Round(dblSecondes / 3600, 2))
			
660: Call rstPunch.MoveNext()
665: Loop 
		
670: Call rstPunch.Close()
		
		'Fabrication mécanique
675: sWhere = "(LEFT(NoProjet, 1) = 'M' AND MID(NoProjet, 3, 1) = '4' AND Date BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' AND HeureFin Is Not Null)"
		
680: Call rstPunch.Open("SELECT Date, HeureDébut, HeureFin FROM GRB_Punch WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
685: Do While Not rstPunch.EOF
690: datDebut = rstPunch.Fields("HeureDébut").Value
			
695: If rstPunch.Fields("HeureFin").Value = "24:00" Then
700: datFin = TimeSerial(24, 0, 0)
705: Else
710: datFin = rstPunch.Fields("HeureFin").Value
715: End If
			
720: 'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
			dblSecondes = DateDiff(Microsoft.VisualBasic.DateInterval.Second, datDebut, datFin)
			
725: dblHeures = Int(dblSecondes / 3600)
			
730: dblSecondes = dblSecondes - (3600 * dblHeures)
			
735: dblFabMec = dblFabMec + (dblHeures + System.Math.Round(dblSecondes / 3600, 2))
			
740: Call rstPunch.MoveNext()
745: Loop 
		
750: Call rstPunch.Close()
		
		'Recherche et développement électrique
755: sWhere = "(LEFT(NoProjet, 1) = 'E' AND MID(NoProjet, 3, 1) = '9' AND Date BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' AND HeureFin Is Not Null)"
		
760: Call rstPunch.Open("SELECT Date, HeureDébut, HeureFin FROM GRB_Punch WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
765: Do While Not rstPunch.EOF
770: datDebut = rstPunch.Fields("HeureDébut").Value
			
775: If rstPunch.Fields("HeureFin").Value = "24:00" Then
780: datFin = TimeSerial(24, 0, 0)
785: Else
790: datFin = rstPunch.Fields("HeureFin").Value
795: End If
			
800: 'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
			dblSecondes = DateDiff(Microsoft.VisualBasic.DateInterval.Second, datDebut, datFin)
			
805: dblHeures = Int(dblSecondes / 3600)
			
810: dblSecondes = dblSecondes - (3600 * dblHeures)
			
815: dblRechElec = dblRechElec + (dblHeures + System.Math.Round(dblSecondes / 3600, 2))
			
820: Call rstPunch.MoveNext()
825: Loop 
		
830: Call rstPunch.Close()
		
		'Recherche et développement mécanique
835: sWhere = "(LEFT(NoProjet, 1) = 'M' AND MID(NoProjet, 3, 1) = '9' AND Date BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' AND HeureFin Is Not Null)"
		
840: Call rstPunch.Open("SELECT Date, HeureDébut, HeureFin FROM GRB_Punch WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
845: Do While Not rstPunch.EOF
850: datDebut = rstPunch.Fields("HeureDébut").Value
			
855: If rstPunch.Fields("HeureFin").Value = "24:00" Then
860: datFin = TimeSerial(24, 0, 0)
865: Else
870: datFin = rstPunch.Fields("HeureFin").Value
875: End If
			
880: 'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
			dblSecondes = DateDiff(Microsoft.VisualBasic.DateInterval.Second, datDebut, datFin)
			
885: dblHeures = Int(dblSecondes / 3600)
			
890: dblSecondes = dblSecondes - (3600 * dblHeures)
			
895: dblRechMec = dblRechMec + (dblHeures + System.Math.Round(dblSecondes / 3600, 2))
			
900: Call rstPunch.MoveNext()
905: Loop 
		
910: Call rstPunch.Close()
		
		'Appels de services électriques
915: sWhere = "(LEFT(NoProjet, 1) = 'E' AND (MID(NoProjet, 3, 1) = '5' OR MID(NoProjet, 3, 1) = '7') AND Date BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' AND HeureFin Is Not Null)"
		
920: Call rstPunch.Open("SELECT Date, HeureDébut, HeureFin FROM GRB_Punch WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
925: Do While Not rstPunch.EOF
930: datDebut = rstPunch.Fields("HeureDébut").Value
			
935: If rstPunch.Fields("HeureFin").Value = "24:00" Then
940: datFin = TimeSerial(24, 0, 0)
945: Else
950: datFin = rstPunch.Fields("HeureFin").Value
955: End If
			
960: 'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
			dblSecondes = DateDiff(Microsoft.VisualBasic.DateInterval.Second, datDebut, datFin)
			
965: dblHeures = Int(dblSecondes / 3600)
			
970: dblSecondes = dblSecondes - (3600 * dblHeures)
			
975: dblAppelsElec = dblAppelsElec + (dblHeures + System.Math.Round(dblSecondes / 3600, 2))
			
980: Call rstPunch.MoveNext()
985: Loop 
		
990: Call rstPunch.Close()
		
		'Appels de services mécaniques
995: sWhere = "(LEFT(NoProjet, 1) = 'M' AND (MID(NoProjet, 3, 1) = '5' OR MID(NoProjet, 3, 1) = '7') AND Date BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "' AND HeureFin Is Not Null)"
		
1000: Call rstPunch.Open("SELECT Date, HeureDébut, HeureFin FROM GRB_Punch WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
1005: Do While Not rstPunch.EOF
1010: datDebut = rstPunch.Fields("HeureDébut").Value
			
1015: If rstPunch.Fields("HeureFin").Value = "24:00" Then
1020: datFin = TimeSerial(24, 0, 0)
1025: Else
1030: datFin = rstPunch.Fields("HeureFin").Value
1035: End If
			
1040: 'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
			dblSecondes = DateDiff(Microsoft.VisualBasic.DateInterval.Second, datDebut, datFin)
			
1045: dblHeures = Int(dblSecondes / 3600)
			
1050: dblSecondes = dblSecondes - (3600 * dblHeures)
			
1055: dblAppelsMec = dblAppelsMec + (dblHeures + System.Math.Round(dblSecondes / 3600, 2))
			
1060: Call rstPunch.MoveNext()
1065: Loop 
		
1070: Call rstPunch.Close()
		
1075: dblGrandTotal = dblSoumElec + dblSoumMec + dblProjGRBElec + dblProjGRBMec + dblProjElec + dblProjMec + dblFabElec + dblFabMec + dblRechElec + dblRechMec + dblAppelsElec + dblAppelsMec
		
		'Ce recordset sert à rien. Il sert seulement à l'ouverture du DataReport.
		'Un DataReport ne peut pas ouvrir s'il n'a pas de DataSource
1080: Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE NoProjet = '0000000'", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
1085: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.DataSource = rstPunch
		
1090: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Orientation = MSDataReportLib.OrientationConstants.rptOrientPortrait
		
1095: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblDateDebut").Caption = mskDateDebut.Text
1100: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblDateFin").Caption = mskDateFin.Text
		
1105: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblSoumElec").Caption = dblSoumElec
1110: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblSoumMec").Caption = dblSoumMec
		
1115: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblTotalSoum").Caption = dblSoumElec + dblSoumMec
		
1120: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblProjGRBElec").Caption = dblProjGRBElec
1125: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblProjGRBMec").Caption = dblProjGRBMec
		
1130: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblTotalProjGRB").Caption = dblProjGRBElec + dblProjGRBMec
		
1135: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblProjElec").Caption = dblProjElec
1140: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblProjMec").Caption = dblProjMec
		
1145: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblTotalProj").Caption = dblProjElec + dblProjMec
		
1150: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblFabElec").Caption = dblFabElec
1155: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblFabMec").Caption = dblFabMec
		
1160: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblTotalFab").Caption = dblFabElec + dblFabMec
		
1165: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblRechElec").Caption = dblRechElec
1170: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblRechMec").Caption = dblRechMec
		
1175: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblTotalRech").Caption = dblRechElec + dblRechMec
		
1180: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblAppelsElec").Caption = dblAppelsElec
1185: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblAppelsMec").Caption = dblAppelsMec
		
1190: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblTotalAppels").Caption = dblAppelsElec + dblAppelsMec
		
1195: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_SommaireHeures.Sections("Section2").Controls("lblGrandTotal").Caption = dblGrandTotal
		
1200: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_SommaireHeures.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_SommaireHeures.Show(VB6.FormShowConstants.Modal)
		
1205: Call rstPunch.Close()
		
1210: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPunch = Nothing
		
1215: Exit Sub
		
AfficherErreur: 
		
1220: Call AfficherErreur("frmChoixDateSommairePunch", "ImprimerSommaireHeures", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event optProjets.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optProjets_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optProjets.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = optProjets.GetIndex(eventSender)
			If optProjets(I_OPT_PROJETS_GRB).Checked = True Then
				fraFamille.Enabled = True
			Else
				fraFamille.Enabled = False
			End If
		End If
	End Sub
End Class