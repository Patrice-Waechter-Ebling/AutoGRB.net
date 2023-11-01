Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmPunch
	Inherits System.Windows.Forms.Form
	
	'Index de optHeure
	Private Const I_OPT_SYSTEME As Short = 0
	Private Const I_OPT_MANUELLEMENT As Short = 1
	
	'Index de optTypePunch et optPMTypePunch
	Private Const I_OPT_ELECTRIQUE As Short = 0
	Private Const I_OPT_MECANIQUE As Short = 1
	
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
	
	'Index de optHeureDiner
	Private Const I_OPT_30_MINUTES As Short = 0
	Private Const I_OPT_1_HEURE As Short = 1
	
	'Index de lvwJour
	Private Const I_LVW_NOM As Short = 0
	Private Const I_LVW_PROJET As Short = 1
	Private Const I_LVW_DEBUT As Short = 2
	Private Const I_LVW_FIN As Short = 3
	Private Const I_LVW_CLIENT As Short = 4
	Private Const I_LVW_TYPE As Short = 5
	Private Const I_LVW_COMMENTAIRE As Short = 6
	Private Const I_LVW_KM As Short = 7
	
	'Index de lvwJourSemaine
	Private Const I_LVW_INITIALE As Short = 0
	Private Const I_LVW_TEMPS As Short = 1
	
	Private Enum enumPunch
		I_PUNCH_IN = 0
		I_PUNCH_OUT = 1
		I_MODIF_PUNCH_IN = 2
		I_MODIF_PUNCH_OUT = 3
	End Enum
	
	Private m_ePunch As enumPunch
	Private m_iNoEmploye As Short
	Private m_datDateChoisie As Date
	
	Private m_bModifPunch As Boolean
	Private m_bMonthViewHasFocus As Boolean
	
	Public sCommentaire As String
	
	Public Sub Afficher(ByVal sUserID As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmploye As ADODB.Recordset
15: Dim iCompteur As Short
		
20: Call frmChoixPunch.Close()
		
25: rstEmploye = New ADODB.Recordset
		
30: Call rstEmploye.Open("SELECT NoEmploye FROM GRB_Employés WHERE loginname = '" & sUserID & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
35: m_iNoEmploye = rstEmploye.Fields("NoEmploye").Value
		
40: Call rstEmploye.Close()
45: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
50: optHeure(I_OPT_SYSTEME).Checked = True
		
55: mvwSelection.Year = Year(Today)
60: mvwSelection.Month = Month(Today)
65: mvwSelection.Day = VB.Day(Today)
		
70: Call AfficherDate()
		
75: Call RemplirComboEmploye()
		
80: Call cmbHeureSemaine.Items.Clear()
		
85: For iCompteur = 0 To cmbemployé.Items.Count - 1
90: Call cmbHeureSemaine.Items.Add(VB6.GetItemString(cmbemployé, iCompteur))
			
95: 'UPGRADE_ISSUE: ComboBox property cmbHeureSemaine.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbHeureSemaine, cmbHeureSemaine.NewIndex, VB6.GetItemData(cmbemployé, iCompteur))
100: Next 
		
105: cmbHeureSemaine.SelectedIndex = 0
		
110: Call Me.Show()
		
115: Exit Sub
		
AfficherErreur: 
		
120: Call AfficherErreur("frmPunch", "Afficher", Err, Erl())
	End Sub
	
	Private Sub CalculerHeureSemaine()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPunch As ADODB.Recordset
15: Dim dblDebut As Double
20: Dim dblFin As Double
25: Dim dblTotal As Double
30: Dim sDate As String
35: Dim sDebut As String
40: Dim sFin As String
		
45: rstPunch = New ADODB.Recordset
		
50: Call rstPunch.Open("SELECT Date, HeureDébut, HeureFin FROM GRB_Punch WHERE NoEmploye = " & VB6.GetItemData(cmbHeureSemaine, cmbHeureSemaine.SelectedIndex) & " AND Date BETWEEN '" & lvwJourSemaine(1).Tag & "' AND '" & lvwJourSemaine(7).Tag & "'", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
55: Do While Not rstPunch.EOF
60: sDate = rstPunch.Fields("Date").Value
			
65: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("HeureDébut").Value) Then
70: If Trim(rstPunch.Fields("HeureDébut").Value) <> "" Then
75: sDebut = rstPunch.Fields("HeureDébut").Value
80: Else
85: sDebut = ""
90: End If
100: Else
105: sDebut = ""
110: End If
			
115: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("HeureFin").Value) Then
120: If Trim(rstPunch.Fields("HeureFin").Value) <> "" Then
125: sFin = rstPunch.Fields("HeureFin").Value
130: Else
135: sFin = ""
140: End If
145: Else
150: sFin = ""
155: End If
			
160: If sDebut <> "" And sFin <> "" Then
165: dblDebut = CDbl(VB.Left(sDebut, 2)) + CDbl(CDbl(VB.Right(sDebut, 2)) / 60)
170: dblFin = CDbl(VB.Left(sFin, 2)) + CDbl(CDbl(VB.Right(sFin, 2)) / 60)
				
175: dblTotal = dblTotal + (dblFin - dblDebut)
180: End If
			
185: Call rstPunch.MoveNext()
190: Loop 
		
195: Call rstPunch.Close()
200: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPunch = Nothing
		
205: lblNbreHeure.Text = CStr(dblTotal)
		
210: Exit Sub
		
AfficherErreur: 
		
215: Call AfficherErreur("frmPunch", "CalculerHeureSemaine", Err, Erl())
	End Sub
	
	Private Sub AfficherDate()
		
5: On Error GoTo AfficherErreur
		
		'Affiche punch de la journée et de la semaine
		'dépendant la sélection dans le calendrier
10: Dim iCompteur As Short
		
		'date choisie
15: m_datDateChoisie = DateSerial(mvwSelection.Year, mvwSelection.Month, mvwSelection.Day)
		
		'affiche punch jour et semaine
20: Call RemplirListViewJour()
25: Call RemplirListViewJourAutorisation()
30: Call RemplirListViewSemaine(False)
35: Call RemplirListViewSemaineAutorisation(False)
		
		'selectionne jour de la semaine
40: For iCompteur = 1 To 7
45: If CDate(lvwJourSemaine(iCompteur).Tag) = m_datDateChoisie Then
50: lvwJourSemaine(iCompteur).BackColor = System.Drawing.ColorTranslator.FromOle(&HE0E0E0)
55: Else
60: lvwJourSemaine(iCompteur).BackColor = System.Drawing.ColorTranslator.FromOle(&HFFFFFF)
65: End If
70: Next 
		
		'Affiche cedule une journee
75: frajour.Visible = True
80: fraPunch.Visible = False
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("frmPunch", "AfficherDate", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewJour()
		
5: On Error GoTo AfficherErreur
		
		'remplis ListView une journée
10: Dim rstPunch As ADODB.Recordset
15: Dim rstEmploye As ADODB.Recordset
20: Dim rstClient As ADODB.Recordset
25: Dim itmPunch As System.Windows.Forms.ListViewItem
30: Dim lForeColor As Integer
		
		'vide le lister
35: Call lvwJour.Items.Clear()
		
40: rstPunch = New ADODB.Recordset
		
45: Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE Date = '" & ConvertDate(m_datDateChoisie) & "' AND NoEmploye = " & m_iNoEmploye & " ORDER BY HeureDébut", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
50: rstEmploye = New ADODB.Recordset
55: rstClient = New ADODB.Recordset
		
		'tant il y a de employé cedulé , ajoute dans lister
60: Do While Not rstPunch.EOF
65: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwJour.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmPunch = lvwJour.Items.Add()
			
70: Call rstEmploye.Open("SELECT initiale FROM GRB_Employés WHERE NoEmploye = " & m_iNoEmploye, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
75: itmPunch.Text = rstEmploye.Fields("initiale").Value
			
80: Call rstEmploye.Close()
			
85: itmPunch.Tag = rstPunch.Fields("IDPunch").Value
			
90: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("NoProjet").Value) Then
95: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPunch.SubItems.Count > I_LVW_PROJET Then
					itmPunch.SubItems(I_LVW_PROJET).Text = rstPunch.Fields("NoProjet").Value
				Else
					itmPunch.SubItems.Insert(I_LVW_PROJET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("NoProjet").Value))
				End If
100: Else
105: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPunch.SubItems.Count > I_LVW_PROJET Then
					itmPunch.SubItems(I_LVW_PROJET).Text = vbNullString
				Else
					itmPunch.SubItems.Insert(I_LVW_PROJET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
110: End If
			
115: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("HeureDébut").Value) Then
120: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPunch.SubItems.Count > I_LVW_DEBUT Then
					itmPunch.SubItems(I_LVW_DEBUT).Text = rstPunch.Fields("HeureDébut").Value
				Else
					itmPunch.SubItems.Insert(I_LVW_DEBUT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("HeureDébut").Value))
				End If
125: Else
130: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPunch.SubItems.Count > I_LVW_DEBUT Then
					itmPunch.SubItems(I_LVW_DEBUT).Text = vbNullString
				Else
					itmPunch.SubItems.Insert(I_LVW_DEBUT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
135: End If
			
140: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("HeureFin").Value) And rstPunch.Fields("HeureFin").Value <> vbNullString Then
145: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPunch.SubItems.Count > I_LVW_FIN Then
					itmPunch.SubItems(I_LVW_FIN).Text = rstPunch.Fields("HeureFin").Value
				Else
					itmPunch.SubItems.Insert(I_LVW_FIN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("HeureFin").Value))
				End If
150: lForeColor = COLOR_NOIR
155: Else
160: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPunch.SubItems.Count > I_LVW_FIN Then
					itmPunch.SubItems(I_LVW_FIN).Text = vbNullString
				Else
					itmPunch.SubItems.Insert(I_LVW_FIN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
165: lForeColor = COLOR_ROUGE
170: End If
			
175: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("NoClient").Value) And rstPunch.Fields("NoClient").Value <> vbNullString Then
180: Call rstClient.Open("SELECT NomClient FROM GRB_Client WHERE IDClient = " & rstPunch.Fields("NoClient").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
185: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPunch.SubItems.Count > I_LVW_CLIENT Then
					itmPunch.SubItems(I_LVW_CLIENT).Text = rstClient.Fields("NomClient").Value
				Else
					itmPunch.SubItems.Insert(I_LVW_CLIENT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstClient.Fields("NomClient").Value))
				End If
				
190: 'UPGRADE_WARNING: Lower bound of collection itmPunch.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmPunch.SubItems.Item(I_LVW_CLIENT).Tag = rstPunch.Fields("NoClient").Value
				
195: Call rstClient.Close()
200: Else
205: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPunch.SubItems.Count > I_LVW_CLIENT Then
					itmPunch.SubItems(I_LVW_CLIENT).Text = vbNullString
				Else
					itmPunch.SubItems.Insert(I_LVW_CLIENT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
210: End If
			
215: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("Type").Value) Then
220: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If VB.Left(itmPunch.SubItems(I_LVW_PROJET).Text, 1) = "E" Then
225: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_TYPE Then
						itmPunch.SubItems(I_LVW_TYPE).Text = rstPunch.Fields("Type").Value
					Else
						itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("Type").Value))
					End If
					
290: 
295: Else
300: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_TYPE Then
						itmPunch.SubItems(I_LVW_TYPE).Text = rstPunch.Fields("Type").Value
					Else
						itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("Type").Value))
					End If
360: End If
365: End If
			
370: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("Commentaire").Value) And rstPunch.Fields("Commentaire").Value <> vbNullString Then
375: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPunch.SubItems.Count > I_LVW_COMMENTAIRE Then
					itmPunch.SubItems(I_LVW_COMMENTAIRE).Text = rstPunch.Fields("Commentaire").Value
				Else
					itmPunch.SubItems.Insert(I_LVW_COMMENTAIRE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("Commentaire").Value))
				End If
380: Else
385: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPunch.SubItems.Count > I_LVW_COMMENTAIRE Then
					itmPunch.SubItems(I_LVW_COMMENTAIRE).Text = vbNullString
				Else
					itmPunch.SubItems.Insert(I_LVW_COMMENTAIRE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
390: End If
			
395: If rstPunch.Fields("KM").Value = True Then
400: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPunch.Fields("NbreKM").Value) Then
405: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_KM Then
						itmPunch.SubItems(I_LVW_KM).Text = rstPunch.Fields("NbreKM").Value
					Else
						itmPunch.SubItems.Insert(I_LVW_KM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("NbreKM").Value))
					End If
410: Else
415: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_KM Then
						itmPunch.SubItems(I_LVW_KM).Text = CStr(0)
					Else
						itmPunch.SubItems.Insert(I_LVW_KM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, CStr(0)))
					End If
420: End If
425: Else
430: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPunch.SubItems.Count > I_LVW_KM Then
					itmPunch.SubItems(I_LVW_KM).Text = ""
				Else
					itmPunch.SubItems.Insert(I_LVW_KM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
				End If
435: End If
			
440: 'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwJour.Items.Item(itmPunch.Index).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
445: 'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwJour.Items.Item(itmPunch.Index).SubItems.Item(I_LVW_PROJET).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
450: 'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwJour.Items.Item(itmPunch.Index).SubItems.Item(I_LVW_DEBUT).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
455: 'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwJour.Items.Item(itmPunch.Index).SubItems.Item(I_LVW_FIN).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
460: 'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwJour.Items.Item(itmPunch.Index).SubItems.Item(I_LVW_CLIENT).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
465: 'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwJour.Items.Item(itmPunch.Index).SubItems.Item(I_LVW_TYPE).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
470: 'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwJour.Items.Item(itmPunch.Index).SubItems.Item(I_LVW_COMMENTAIRE).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
475: 'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwJour.Items.Item(itmPunch.Index).SubItems.Item(I_LVW_KM).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
			
480: Call rstPunch.MoveNext()
485: Loop 
		
490: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
495: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient = Nothing
		
500: Call rstPunch.Close()
505: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPunch = Nothing
		
510: If lvwJour.Items.Count > 0 Then
515: 'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwJour.Items.Item(lvwJour.Items.Count).Selected = True
520: End If
		
525: Exit Sub
		
AfficherErreur: 
		
530: Call AfficherErreur("frmPunch", "RemplirListViewJour", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewJourAutorisation()
		
5: On Error GoTo AfficherErreur
		
		'Remplis ListView une journée
10: Dim rstPunch As ADODB.Recordset
15: Dim rstEmploye As ADODB.Recordset
20: Dim rstAutorisation As ADODB.Recordset
25: Dim rstClient As ADODB.Recordset
30: Dim itmPunch As System.Windows.Forms.ListViewItem
35: Dim lForeColor As Integer
		
40: rstAutorisation = New ADODB.Recordset
		
45: Call rstAutorisation.Open("SELECT * FROM GRB_AutorisationPunch WHERE AutoriserPar = " & m_iNoEmploye, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
50: rstPunch = New ADODB.Recordset
55: rstEmploye = New ADODB.Recordset
60: rstClient = New ADODB.Recordset
		
65: Do While Not rstAutorisation.EOF
70: Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE Date = '" & ConvertDate(m_datDateChoisie) & "' AND NoEmploye = " & rstAutorisation.Fields("NoEmploye").Value & " ORDER BY HeureDébut", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'tant il y a de employé cedulé , ajoute dans lister
75: Do While Not rstPunch.EOF
80: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwJour.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmPunch = lvwJour.Items.Add()
				
85: Call rstEmploye.Open("SELECT initiale FROM GRB_Employés WHERE NoEmploye = " & rstAutorisation.Fields("NoEmploye").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
90: itmPunch.Text = rstEmploye.Fields("initiale").Value
				
95: Call rstEmploye.Close()
				
100: itmPunch.Tag = rstPunch.Fields("IDPunch").Value
				
105: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPunch.Fields("NoProjet").Value) Then
110: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_PROJET Then
						itmPunch.SubItems(I_LVW_PROJET).Text = rstPunch.Fields("NoProjet").Value
					Else
						itmPunch.SubItems.Insert(I_LVW_PROJET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("NoProjet").Value))
					End If
115: Else
120: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_PROJET Then
						itmPunch.SubItems(I_LVW_PROJET).Text = vbNullString
					Else
						itmPunch.SubItems.Insert(I_LVW_PROJET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
125: End If
				
130: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPunch.Fields("HeureDébut").Value) Then
135: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_DEBUT Then
						itmPunch.SubItems(I_LVW_DEBUT).Text = rstPunch.Fields("HeureDébut").Value
					Else
						itmPunch.SubItems.Insert(I_LVW_DEBUT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("HeureDébut").Value))
					End If
140: Else
145: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_DEBUT Then
						itmPunch.SubItems(I_LVW_DEBUT).Text = vbNullString
					Else
						itmPunch.SubItems.Insert(I_LVW_DEBUT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
150: End If
				
155: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPunch.Fields("HeureFin").Value) And rstPunch.Fields("HeureFin").Value <> vbNullString Then
160: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_FIN Then
						itmPunch.SubItems(I_LVW_FIN).Text = rstPunch.Fields("HeureFin").Value
					Else
						itmPunch.SubItems.Insert(I_LVW_FIN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("HeureFin").Value))
					End If
165: lForeColor = COLOR_NOIR
170: Else
175: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_FIN Then
						itmPunch.SubItems(I_LVW_FIN).Text = vbNullString
					Else
						itmPunch.SubItems.Insert(I_LVW_FIN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
180: lForeColor = COLOR_ROUGE
185: End If
				
190: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPunch.Fields("NoClient").Value) And rstPunch.Fields("NoClient").Value <> vbNullString Then
195: Call rstClient.Open("SELECT NomClient FROM GRB_Client WHERE IDClient = " & rstPunch.Fields("NoClient").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
200: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_CLIENT Then
						itmPunch.SubItems(I_LVW_CLIENT).Text = rstClient.Fields("NomClient").Value
					Else
						itmPunch.SubItems.Insert(I_LVW_CLIENT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstClient.Fields("NomClient").Value))
					End If
					
205: 'UPGRADE_WARNING: Lower bound of collection itmPunch.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmPunch.SubItems.Item(I_LVW_CLIENT).Tag = rstPunch.Fields("NoClient").Value
					
210: Call rstClient.Close()
215: Else
220: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_CLIENT Then
						itmPunch.SubItems(I_LVW_CLIENT).Text = vbNullString
					Else
						itmPunch.SubItems.Insert(I_LVW_CLIENT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
225: End If
				
230: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPunch.Fields("Type").Value) Then
235: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If VB.Left(itmPunch.SubItems(I_LVW_PROJET).Text, 1) = "E" Then
240: Select Case rstPunch.Fields("Type").Value
							Case "Dessin"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Dessins électriques"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Dessins électriques"))
								End If
245: Case "Fabrication"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Fabrication"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Fabrication"))
								End If
250: Case "Assemblage"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Assemblage du panneau"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Assemblage du panneau"))
								End If
255: Case "ProgInterface"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Programmation d'interface"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Programmation d'interface"))
								End If
260: Case "ProgAutomate"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Programmation d'automate"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Programmation d'automate"))
								End If
265: Case "ProgRobot"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Programmation de robot"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Programmation de robot"))
								End If
270: Case "Vision"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Vision artificielle"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Vision artificielle"))
								End If
275: Case "Test"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Tests finaux"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Tests finaux"))
								End If
280: Case "Installation"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Installation"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Installation"))
								End If
285: Case "MiseService"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Mise en service"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Mise en service"))
								End If
290: Case "Formation"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Formation du personnel"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Formation du personnel"))
								End If
295: Case "Gestion"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Gestion du projet"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Gestion du projet"))
								End If
300: Case "Shipping"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Expédition"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Expédition"))
								End If
							Case "Prototypage-Dévelloppement expérimental"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Prototypage-Dévelloppement expérimental"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Prototypage-Dévelloppement expérimental"))
								End If
305: End Select
310: Else
315: Select Case rstPunch.Fields("Type").Value
							Case "Dessin"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Conception et dessins"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Conception et dessins"))
								End If
320: Case "Coupe"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Coupe et préparation (sauf soudage)"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Coupe et préparation (sauf soudage)"))
								End If
325: Case "Machinage"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Machinage"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Machinage"))
								End If
330: Case "Soudure"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Coupe, soudure et meulage"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Coupe, soudure et meulage"))
								End If
335: Case "Assemblage"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Assemblage des systèmes"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Assemblage des systèmes"))
								End If
340: Case "Peinture"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Peinture et finition"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Peinture et finition"))
								End If
345: Case "Test"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Tests finaux"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Tests finaux"))
								End If
350: Case "Installation"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Installation"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Installation"))
								End If
355: Case "Formation"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Formation du personnel"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Formation du personnel"))
								End If
360: Case "Gestion"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Gestion du projet"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Gestion du projet"))
								End If
365: Case "Shipping"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Expédition"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Expédition"))
								End If
							Case "Prototypage-Dévelloppement expérimental"
								'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmPunch.SubItems.Count > I_LVW_TYPE Then
									itmPunch.SubItems(I_LVW_TYPE).Text = "Prototypage-Dévelloppement expérimental"
								Else
									itmPunch.SubItems.Insert(I_LVW_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Prototypage-Dévelloppement expérimental"))
								End If
370: End Select
375: End If
380: End If
				
385: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPunch.Fields("Commentaire").Value) And rstPunch.Fields("Commentaire").Value <> vbNullString Then
390: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_COMMENTAIRE Then
						itmPunch.SubItems(I_LVW_COMMENTAIRE).Text = rstPunch.Fields("Commentaire").Value
					Else
						itmPunch.SubItems.Insert(I_LVW_COMMENTAIRE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("Commentaire").Value))
					End If
395: Else
400: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_COMMENTAIRE Then
						itmPunch.SubItems(I_LVW_COMMENTAIRE).Text = vbNullString
					Else
						itmPunch.SubItems.Insert(I_LVW_COMMENTAIRE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
405: End If
				
410: If rstPunch.Fields("KM").Value = True Then
415: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_KM Then
						itmPunch.SubItems(I_LVW_KM).Text = rstPunch.Fields("NbreKM").Value
					Else
						itmPunch.SubItems.Insert(I_LVW_KM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("NbreKM").Value))
					End If
420: Else
425: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPunch.SubItems.Count > I_LVW_KM Then
						itmPunch.SubItems(I_LVW_KM).Text = vbNullString
					Else
						itmPunch.SubItems.Insert(I_LVW_KM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
430: End If
				
435: 'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvwJour.Items.Item(itmPunch.Index).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
440: 'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvwJour.Items.Item(itmPunch.Index).SubItems.Item(I_LVW_PROJET).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
445: 'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvwJour.Items.Item(itmPunch.Index).SubItems.Item(I_LVW_DEBUT).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
450: 'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvwJour.Items.Item(itmPunch.Index).SubItems.Item(I_LVW_FIN).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
455: 'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvwJour.Items.Item(itmPunch.Index).SubItems.Item(I_LVW_CLIENT).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
460: 'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvwJour.Items.Item(itmPunch.Index).SubItems.Item(I_LVW_TYPE).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
465: 'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvwJour.Items.Item(itmPunch.Index).SubItems.Item(I_LVW_COMMENTAIRE).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
470: 'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwJour.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvwJour.Items.Item(itmPunch.Index).SubItems.Item(I_LVW_KM).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
				
475: Call rstPunch.MoveNext()
480: Loop 
			
485: Call rstPunch.Close()
			
490: Call rstAutorisation.MoveNext()
495: Loop 
		
500: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPunch = Nothing
505: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient = Nothing
510: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
515: Call rstAutorisation.Close()
520: 'UPGRADE_NOTE: Object rstAutorisation may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAutorisation = Nothing
		
525: Call lvwJour_Click(lvwJour, New System.EventArgs())
		
530: Exit Sub
		
AfficherErreur: 
		
535: Call AfficherErreur("frmPunch", "RemplirListViewJourAutorisation", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewSemaine(ByVal bAujourdhui As Boolean)
		
5: On Error GoTo AfficherErreur
		
		'remplis une semaine
		'bAujourdhui sert à savoir si on rafraichit seulement la journée d'aujourd'hui
10: Dim rstPunch As ADODB.Recordset
15: Dim rstEmploye As ADODB.Recordset
20: Dim iJourSemaine As Short
25: Dim datPremiereDate As Date
30: Dim datDerniereDate As Date
35: Dim iCompteur As Short
40: Dim sHeureDebutFin As String
45: Dim itmSemaine As System.Windows.Forms.ListViewItem
50: Dim lForeColor As Integer
		
55: rstPunch = New ADODB.Recordset
60: rstEmploye = New ADODB.Recordset
		
65: If bAujourdhui = False Then
70: For iCompteur = 1 To 7
				'couleur par defaut entete de date
75: lbljour(iCompteur - 1).ForeColor = System.Drawing.Color.White
80: lblNomJour(iCompteur - 1).ForeColor = System.Drawing.Color.White
				
85: Call lvwJourSemaine(iCompteur).Items.Clear()
90: Next 
			
95: iJourSemaine = WeekDay(m_datDateChoisie)
100: datPremiereDate = m_datDateChoisie
105: datDerniereDate = m_datDateChoisie
			
			'Trouve premiere date de la semaine
110: Do While Not WeekDay(datPremiereDate) = 1
115: datPremiereDate = System.Date.FromOADate(datPremiereDate.ToOADate - 1)
120: Loop 
			
			'Trouve derniere date de la semaine
125: Do While Not WeekDay(datDerniereDate) = 7
130: datDerniereDate = System.Date.FromOADate(datDerniereDate.ToOADate + 1)
135: Loop 
			
			'Sélectionne la semaine courante
140: Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE Date BETWEEN '" & ConvertDate(datPremiereDate) & "' AND '" & ConvertDate(datDerniereDate) & "' AND NoEmploye = " & m_iNoEmploye & " ORDER BY HeureDébut", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
145: For iCompteur = 1 To 7
				'Pour écrire le jour
150: lbljour(iCompteur - 1).Text = CStr(VB.Day(System.Date.FromOADate(datPremiereDate.ToOADate + iCompteur - 1)))
				
				'Garde en memoire la date des listers
155: lvwJourSemaine(iCompteur).Tag = CStr(System.Date.FromOADate(datPremiereDate.ToOADate + iCompteur - 1))
160: Next 
			
165: Do While Not rstPunch.EOF
				'ajoute dans le lister, dépendant le jour de la semaine
170: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwJourSemaine.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmSemaine = lvwJourSemaine(WeekDay(rstPunch.Fields("Date").Value)).Items.Add()
				
175: itmSemaine.Tag = rstPunch.Fields("IDPunch").Value
				
180: Call rstEmploye.Open("SELECT initiale FROM GRB_Employés WHERE NoEmploye = " & m_iNoEmploye, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
185: itmSemaine.Text = rstEmploye.Fields("initiale").Value
				
190: Call rstEmploye.Close()
				
195: sHeureDebutFin = Trim(rstPunch.Fields("HeureDébut").Value + "-")
				
200: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPunch.Fields("HeureFin").Value) And rstPunch.Fields("HeureFin").Value <> vbNullString Then
205: sHeureDebutFin = sHeureDebutFin + rstPunch.Fields("HeureFin").Value
210: lForeColor = COLOR_NOIR
215: Else
220: lForeColor = COLOR_ROUGE
225: End If
				
230: 'UPGRADE_WARNING: Lower bound of collection itmSemaine has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmSemaine.SubItems.Count > I_LVW_TEMPS Then
					itmSemaine.SubItems(I_LVW_TEMPS).Text = sHeureDebutFin
				Else
					itmSemaine.SubItems.Insert(I_LVW_TEMPS, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sHeureDebutFin))
				End If
				
235: 'UPGRADE_WARNING: Lower bound of collection lvwJourSemaine().ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvwJourSemaine(WeekDay(rstPunch.Fields("Date").Value)).Items.Item(itmSemaine.Index).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
240: 'UPGRADE_WARNING: Lower bound of collection lvwJourSemaine().ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwJourSemaine().ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvwJourSemaine(WeekDay(rstPunch.Fields("Date").Value)).Items.Item(itmSemaine.Index).SubItems.Item(I_LVW_TEMPS).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
				
245: Call rstPunch.MoveNext()
250: Loop 
			
255: Call rstPunch.Close()
260: Else
265: Call lvwJourSemaine(WeekDay(m_datDateChoisie)).Items.Clear()
			
270: Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE Date = '" & ConvertDate(m_datDateChoisie) & "' AND NoEmploye = " & m_iNoEmploye, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
275: Do While Not rstPunch.EOF
				'ajoute dans le lister, dépendant le jour de la semaine
280: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwJourSemaine.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmSemaine = lvwJourSemaine(WeekDay(rstPunch.Fields("Date").Value)).Items.Add()
				
285: itmSemaine.Tag = rstPunch.Fields("IDPunch").Value
				
290: Call rstEmploye.Open("SELECT initiale FROM GRB_Employés WHERE NoEmploye = " & m_iNoEmploye, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
295: itmSemaine.Text = rstEmploye.Fields("initiale").Value
				
300: Call rstEmploye.Close()
				
305: sHeureDebutFin = Trim(rstPunch.Fields("HeureDébut").Value + "-")
				
310: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPunch.Fields("HeureFin").Value) And rstPunch.Fields("HeureFin").Value <> vbNullString Then
315: sHeureDebutFin = sHeureDebutFin + rstPunch.Fields("HeureFin").Value
320: lForeColor = COLOR_NOIR
325: Else
330: lForeColor = COLOR_ROUGE
335: End If
				
340: 'UPGRADE_WARNING: Lower bound of collection itmSemaine has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmSemaine.SubItems.Count > I_LVW_TEMPS Then
					itmSemaine.SubItems(I_LVW_TEMPS).Text = sHeureDebutFin
				Else
					itmSemaine.SubItems.Insert(I_LVW_TEMPS, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sHeureDebutFin))
				End If
				
345: 'UPGRADE_WARNING: Lower bound of collection lvwJourSemaine().ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvwJourSemaine(WeekDay(m_datDateChoisie)).Items.Item(itmSemaine.Index).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
350: 'UPGRADE_WARNING: Lower bound of collection lvwJourSemaine().ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwJourSemaine().ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvwJourSemaine(WeekDay(m_datDateChoisie)).Items.Item(itmSemaine.Index).SubItems.Item(I_LVW_TEMPS).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
				
355: Call rstPunch.MoveNext()
360: Loop 
			
365: Call rstPunch.Close()
370: End If
		
375: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPunch = Nothing
380: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
385: Exit Sub
		
AfficherErreur: 
		
390: Call AfficherErreur("frmPunch", "RemplirListViewSemaine", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewSemaineAutorisation(ByVal bAujourdhui As Boolean)
		
5: On Error GoTo AfficherErreur
		
		'remplis une semaine
10: Dim rstPunch As ADODB.Recordset
15: Dim rstEmploye As ADODB.Recordset
20: Dim rstAutorisation As ADODB.Recordset
25: Dim iJourSemaine As Short
30: Dim datPremiereDate As Date
35: Dim datDerniereDate As Date
40: Dim iCompteur As Short
45: Dim sHeureDebutFin As String
50: Dim itmSemaine As System.Windows.Forms.ListViewItem
55: Dim lForeColor As Integer
		
60: rstPunch = New ADODB.Recordset
65: rstEmploye = New ADODB.Recordset
70: rstAutorisation = New ADODB.Recordset
		
75: If bAujourdhui = False Then
80: For iCompteur = 1 To 7
				'couleur par defaut entete de date
85: lbljour(iCompteur - 1).ForeColor = System.Drawing.Color.White
90: lblNomJour(iCompteur - 1).ForeColor = System.Drawing.Color.White
95: Next 
			
100: iJourSemaine = WeekDay(m_datDateChoisie)
105: datPremiereDate = m_datDateChoisie
110: datDerniereDate = m_datDateChoisie
			
			'trouve premiere date de la semaine
115: Do While Not WeekDay(datPremiereDate) = 1
120: datPremiereDate = System.Date.FromOADate(datPremiereDate.ToOADate - 1)
125: Loop 
			
			'trouve derniere date de la semaine
130: Do While Not WeekDay(datDerniereDate) = 7
135: datDerniereDate = System.Date.FromOADate(datDerniereDate.ToOADate + 1)
140: Loop 
			
145: For iCompteur = 1 To 7
				'pour ecrire le jour
150: lbljour(iCompteur - 1).Text = CStr(VB.Day(System.Date.FromOADate(datPremiereDate.ToOADate + iCompteur - 1)))
				
				'garde en memoire la date des lister
155: lvwJourSemaine(iCompteur).Tag = CStr(System.Date.FromOADate(datPremiereDate.ToOADate + iCompteur - 1))
160: Next 
			
165: Call rstAutorisation.Open("SELECT * FROM GRB_AutorisationPunch WHERE AutoriserPar = " & m_iNoEmploye, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
170: Do While Not rstAutorisation.EOF
				'selectionne la semaine courante
175: Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE Date BETWEEN '" & ConvertDate(datPremiereDate) & "' AND '" & ConvertDate(datDerniereDate) & "' AND NoEmploye = " & rstAutorisation.Fields("NoEmploye").Value & " ORDER BY HeureDébut", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
180: Do While Not rstPunch.EOF
					'ajoute dans le lister, dépendant le jour de la semaine
185: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwJourSemaine.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					itmSemaine = lvwJourSemaine(WeekDay(rstPunch.Fields("Date").Value)).Items.Add()
					
190: itmSemaine.Tag = rstPunch.Fields("IDPunch").Value
					
195: Call rstEmploye.Open("SELECT initiale FROM GRB_Employés WHERE NoEmploye = " & rstAutorisation.Fields("NoEmploye").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
200: itmSemaine.Text = rstEmploye.Fields("initiale").Value
					
205: Call rstEmploye.Close()
					
210: sHeureDebutFin = Trim(rstPunch.Fields("HeureDébut").Value + "-")
					
215: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstPunch.Fields("HeureFin").Value) And rstPunch.Fields("HeureFin").Value <> vbNullString Then
220: sHeureDebutFin = sHeureDebutFin + rstPunch.Fields("HeureFin").Value
225: lForeColor = COLOR_NOIR
230: Else
235: lForeColor = COLOR_ROUGE
240: End If
					
245: 'UPGRADE_WARNING: Lower bound of collection itmSemaine has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmSemaine.SubItems.Count > I_LVW_TEMPS Then
						itmSemaine.SubItems(I_LVW_TEMPS).Text = sHeureDebutFin
					Else
						itmSemaine.SubItems.Insert(I_LVW_TEMPS, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sHeureDebutFin))
					End If
					
250: 'UPGRADE_WARNING: Lower bound of collection lvwJourSemaine().ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					lvwJourSemaine(WeekDay(rstPunch.Fields("Date").Value)).Items.Item(itmSemaine.Index).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
255: 'UPGRADE_WARNING: Lower bound of collection lvwJourSemaine().ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwJourSemaine().ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					lvwJourSemaine(WeekDay(rstPunch.Fields("Date").Value)).Items.Item(itmSemaine.Index).SubItems.Item(I_LVW_TEMPS).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
					
260: Call rstPunch.MoveNext()
265: Loop 
				
270: Call rstPunch.Close()
				
275: Call rstAutorisation.MoveNext()
280: Loop 
			
285: Call rstAutorisation.Close()
295: Else
300: Call rstAutorisation.Open("SELECT * FROM GRB_AutorisationPunch WHERE AutoriserPar = " & m_iNoEmploye, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
305: Do While Not rstAutorisation.EOF
				'selectionne la semaine courante
310: Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE Date = '" & ConvertDate(m_datDateChoisie) & "' AND NoEmploye = " & rstAutorisation.Fields("NoEmploye").Value & " ORDER BY HeureDébut", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
315: Do While Not rstPunch.EOF
					'ajoute dans le lister, dépendant le jour de la semaine
320: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwJourSemaine.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					itmSemaine = lvwJourSemaine(WeekDay(m_datDateChoisie)).Items.Add()
					
325: itmSemaine.Tag = rstPunch.Fields("IDPunch").Value
					
330: Call rstEmploye.Open("SELECT initiale FROM GRB_Employés WHERE NoEmploye = " & rstAutorisation.Fields("NoEmploye").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
335: itmSemaine.Text = rstEmploye.Fields("initiale").Value
					
340: Call rstEmploye.Close()
					
345: sHeureDebutFin = Trim(rstPunch.Fields("HeureDébut").Value + "-")
					
350: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstPunch.Fields("HeureFin").Value) And rstPunch.Fields("HeureFin").Value <> vbNullString Then
355: sHeureDebutFin = sHeureDebutFin + rstPunch.Fields("HeureFin").Value
360: lForeColor = COLOR_NOIR
365: Else
370: lForeColor = COLOR_ROUGE
375: End If
					
380: 'UPGRADE_WARNING: Lower bound of collection itmSemaine has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmSemaine.SubItems.Count > I_LVW_TEMPS Then
						itmSemaine.SubItems(I_LVW_TEMPS).Text = sHeureDebutFin
					Else
						itmSemaine.SubItems.Insert(I_LVW_TEMPS, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sHeureDebutFin))
					End If
					
385: 'UPGRADE_WARNING: Lower bound of collection lvwJourSemaine().ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					lvwJourSemaine(WeekDay(m_datDateChoisie)).Items.Item(itmSemaine.Index).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
390: 'UPGRADE_WARNING: Lower bound of collection lvwJourSemaine().ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwJourSemaine().ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					lvwJourSemaine(WeekDay(m_datDateChoisie)).Items.Item(itmSemaine.Index).SubItems.Item(I_LVW_TEMPS).ForeColor = System.Drawing.ColorTranslator.FromOle(lForeColor)
					
395: Call rstPunch.MoveNext()
400: Loop 
				
405: Call rstPunch.Close()
				
410: Call rstAutorisation.MoveNext()
415: Loop 
			
420: Call rstAutorisation.Close()
425: End If
		
430: 'UPGRADE_NOTE: Object rstAutorisation may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAutorisation = Nothing
435: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
440: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPunch = Nothing
		
445: Exit Sub
		
AfficherErreur: 
		
450: Call AfficherErreur("frmPunch", "RemplirListViewSemaineAutorisation", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkDiner.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkDiner_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkDiner.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If chkDiner.CheckState = System.Windows.Forms.CheckState.Checked Then
15: optHeureDiner(I_OPT_1_HEURE).Enabled = True
20: optHeureDiner(I_OPT_30_MINUTES).Enabled = True
25: Else
30: optHeureDiner(I_OPT_1_HEURE).Enabled = False
35: optHeureDiner(I_OPT_30_MINUTES).Enabled = False
40: End If
		
45: m_bMonthViewHasFocus = False
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmPunch", "chkDiner_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkPMDiner.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkPMDiner_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkPMDiner.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If chkPMDiner.CheckState = System.Windows.Forms.CheckState.Checked Then
15: optPMHeureDiner(I_OPT_1_HEURE).Enabled = True
20: optPMHeureDiner(I_OPT_30_MINUTES).Enabled = True
25: Else
30: optPMHeureDiner(I_OPT_1_HEURE).Enabled = False
35: optPMHeureDiner(I_OPT_30_MINUTES).Enabled = False
40: End If
		
50: m_bMonthViewHasFocus = False
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmPunch", "chkPMDiner_Click", Err, Erl())
	End Sub
	
	Private Sub chkDiner_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles chkDiner.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: If chkDiner.CheckState = System.Windows.Forms.CheckState.Checked Then
20: chkDiner.CheckState = System.Windows.Forms.CheckState.Unchecked
25: Else
30: chkDiner.CheckState = System.Windows.Forms.CheckState.Checked
35: End If
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmPunch", "chkDiner_MouseUp", Err, Erl())
	End Sub
	
	Private Sub chkPMDiner_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles chkPMDiner.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: If chkPMDiner.CheckState = System.Windows.Forms.CheckState.Checked Then
20: chkPMDiner.CheckState = System.Windows.Forms.CheckState.Unchecked
25: Else
30: chkPMDiner.CheckState = System.Windows.Forms.CheckState.Checked
35: End If
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmPunch", "chkPMDiner_MouseUp", Err, Erl())
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
		
40: m_bMonthViewHasFocus = False
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmPunch", "chkKM_Click", Err, Erl())
	End Sub
	
	Private Sub chkKM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles chkKM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: If chkKM.CheckState = System.Windows.Forms.CheckState.Checked Then
20: chkKM.CheckState = System.Windows.Forms.CheckState.Unchecked
25: Else
30: chkKM.CheckState = System.Windows.Forms.CheckState.Checked
35: End If
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmPunch", "chkKM_MouseUp", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbEmployé.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbEmployé_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbEmployé.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: txtEmploye.Text = cmbemployé.Text
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmPunch", "cmbEmployé_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbHeureSemaine.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbHeureSemaine_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbHeureSemaine.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: Call CalculerHeureSemaine()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmPunch", "cmbHeureSemaine_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: frajour.Visible = True
15: fraPunch.Visible = False
		
20: m_bMonthViewHasFocus = False
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmPunch", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdBrowseComment_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBrowseComment.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim sProjet As String
		
15: If mskNoProjet.Visible = True Then
20: sProjet = mskNoProjet.Text
25: Else
30: sProjet = txtnoprojet.Text
35: End If
		
40: If txtnoprojet.Text <> "" Or mskNoProjet.Text <> "" Then
45: If txtClient.Text <> "" Then
50: Call frmChoixCommentaire.Afficher(sProjet)
				
55: If sCommentaire <> "" Then
60: txtCommentaires.Text = sCommentaire
65: End If
70: Else
75: Call MsgBox("Numéro de projet ou soumission invalide!", MsgBoxStyle.OKOnly, "Erreur")
80: End If
85: Else
90: Call MsgBox("Le numéro de projet ou soumission est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
95: End If
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmPunch", "cmdBrowseComment_Click", Err, Erl())
	End Sub
	
	Private Sub cmdBrowseCommentPM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBrowseCommentPM.Click
		
5: On Error GoTo AfficherErreur
		
10: If mskPMNoProjet.Text <> "" Then
15: If txtPMClient.Text <> "" Then
20: Call frmChoixCommentaire.Afficher(mskPMNoProjet.Text)
				
25: txtCommentaires.Text = sCommentaire
30: Else
35: Call MsgBox("Numéro de projet ou soumission invalide!", MsgBoxStyle.OKOnly, "Erreur")
40: End If
45: Else
50: Call MsgBox("Le numéro de projet ou soumission est obligaoire!", MsgBoxStyle.OKOnly, "Erreur")
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmPunch", "cmdBrowseCommentPM_Click", Err, Erl())
	End Sub
	
	Private Sub cmdPMAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPMAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: frajour.Visible = True
15: fraPunch.Visible = False
20: fraPunchMultiple.Visible = False
		
25: m_bMonthViewHasFocus = False
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmPunch", "cmdPMAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnuler_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdAnnuler.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdAnnuler_Click(cmdAnnuler, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmPunch", "cmdAnnuler_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdPMAnnuler_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdPMAnnuler.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdPMAnnuler_Click(cmdPMAnnuler, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmPunch", "cmdPMAnnuler_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdModifierPunchIn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdModifierPunchIn.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmploye As ADODB.Recordset
15: Dim itmPunch As System.Windows.Forms.ListViewItem
20: Dim iCompteur As Short
		
25: If VerifierModificationDate = True Then
30: itmPunch = lvwJour.FocusedItem
			
35: rstEmploye = New ADODB.Recordset
			
40: Call rstEmploye.Open("SELECT employe FROM GRB_Employés WHERE Initiale = '" & itmPunch.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
45: For iCompteur = 0 To cmbemployé.Items.Count - 1
50: If VB6.GetItemString(cmbemployé, iCompteur) = rstEmploye.Fields("employe").Value Then
55: cmbemployé.SelectedIndex = iCompteur
					
60: Exit For
65: End If
70: Next 
			
75: Call rstEmploye.Close()
80: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstEmploye = Nothing
			
85: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			txtClient.Text = itmPunch.SubItems(I_LVW_CLIENT).Text
			
90: 'UPGRADE_WARNING: Lower bound of collection itmPunch.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			txtClient.Tag = itmPunch.SubItems.Item(I_LVW_CLIENT).Tag
			
95: cmbemployé.Visible = True
100: txtEmploye.Visible = False
			
105: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Select Case VB.Left(itmPunch.SubItems(I_LVW_PROJET).Text, 1)
				Case "E" : optTypePunch(I_OPT_ELECTRIQUE).Checked = True
110: Case "M" : optTypePunch(I_OPT_MECANIQUE).Checked = True
115: End Select
			
120: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			mskNoProjet.Text = VB.Right(itmPunch.SubItems(I_LVW_PROJET).Text, 8)
			
125: m_ePunch = enumPunch.I_MODIF_PUNCH_IN
			
130: Call RemplirComboType()
			
135: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If VB.Left(itmPunch.SubItems(I_LVW_PROJET).Text, 1) = "E" Then
				
140: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(itmPunch.SubItems(I_LVW_TYPE).Text) Then
					'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					cmbType.Text = itmPunch.SubItems(I_LVW_TYPE).Text
				Else
					
					cmbType.SelectedIndex = -1
210: End If
				
215: Else
				'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If Not itmPunch.SubItems(I_LVW_TYPE).Text = "Soumission" Then
					'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(itmPunch.SubItems(I_LVW_TYPE).Text) Then
						'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						cmbType.Text = itmPunch.SubItems(I_LVW_TYPE).Text
						
					Else
						cmbType.SelectedIndex = -1
285: End If
				End If
			End If
			
290: mskNoProjet.Visible = True
295: txtnoprojet.Visible = False
			
300: picTypePunch.Enabled = True
			
305: mskHeure.Mask = "##:##"
310: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			mskHeure.Text = itmPunch.SubItems(I_LVW_DEBUT).Text
			
315: m_bModifPunch = True
			
320: optHeure(I_OPT_MANUELLEMENT).Checked = True
			
325: m_bModifPunch = False
			
330: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			txtCommentaires.Text = itmPunch.SubItems(I_LVW_COMMENTAIRE).Text
			
335: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPunch.SubItems(I_LVW_KM).Text <> "" Then
340: chkKM.CheckState = System.Windows.Forms.CheckState.Checked
345: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				txtKM.Text = itmPunch.SubItems(I_LVW_KM).Text
350: Else
355: chkKM.CheckState = System.Windows.Forms.CheckState.Unchecked
360: txtKM.Text = vbNullString
365: End If
			
370: fraPunch.Text = "Modification du punch in"
			
375: frajour.Visible = False
380: fraPunchMultiple.Visible = False
385: fraPunch.Visible = True
			
390: chkDiner.Visible = False
395: optHeureDiner(I_OPT_30_MINUTES).Visible = False
400: optHeureDiner(I_OPT_1_HEURE).Visible = False
405: End If
		
410: m_bMonthViewHasFocus = False
		
415: Exit Sub
		
AfficherErreur: 
		
420: Call AfficherErreur("frmPunch", "cmdModifierPunchIn_Click", Err, Erl())
	End Sub
	
	Private Sub cmdModifierPunchIn_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdModifierPunchIn.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdModifierPunchIn_Click(cmdModifierPunchIn, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmPunch", "cmdModifierPunchIn_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdModifierPunchOut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdModifierPunchOut.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmploye As ADODB.Recordset
		
15: If VerifierModificationDate = True Then
20: If lvwJour.Items.Count > 0 Then
25: m_ePunch = enumPunch.I_MODIF_PUNCH_OUT
				
30: Call AfficherPunchOut()
				
35: fraPunch.Text = "Modification du punch out"
				
40: chkDiner.Visible = True
45: optHeureDiner(I_OPT_30_MINUTES).Visible = True
50: optHeureDiner(I_OPT_1_HEURE).Visible = True
				
55: rstEmploye = New ADODB.Recordset
				
60: Call rstEmploye.Open("SELECT GRB_Famille.Famille FROM GRB_employés INNER JOIN GRB_Famille ON GRB_employés.Famille = GRB_Famille.IDFamille WHERE employe = '" & m_iNoEmploye & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
65: If Not rstEmploye.EOF Then
70: Select Case rstEmploye.Fields("Famille").Value
						Case "Administration" : optHeureDiner(I_OPT_1_HEURE).Checked = True
75: Case "Technicien" : optHeureDiner(I_OPT_1_HEURE).Checked = True
80: Case Else : optHeureDiner(I_OPT_30_MINUTES).Checked = True
85: End Select
90: Else
95: optHeureDiner(I_OPT_30_MINUTES).Checked = True
100: End If
				
105: Call rstEmploye.Close()
110: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstEmploye = Nothing
				
115: chkDiner.CheckState = System.Windows.Forms.CheckState.Unchecked
				
120: m_bModifPunch = True
				
125: optHeure(I_OPT_MANUELLEMENT).Checked = True
				
130: m_bModifPunch = False
				
135: mskHeure.Mask = "##:##"
140: 'UPGRADE_WARNING: Lower bound of collection lvwJour.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				mskHeure.Text = lvwJour.FocusedItem.SubItems(I_LVW_FIN).Text
145: End If
150: End If
		
155: m_bMonthViewHasFocus = False
		
160: Exit Sub
		
AfficherErreur: 
		
165: Call AfficherErreur("frmPunch", "cmdModifierPunchOut_Click", Err, Erl())
	End Sub
	
	Private Sub cmdModifierPunchOut_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdModifierPunchOut.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdModifierPunchOut_Click(cmdModifierPunchOut, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmPunch", "cmdModifierPunchOut_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdOK_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdOK.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdOK_Click(cmdOK, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmPunch", "cmdOK_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdPMOK_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdPMOK.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdPMOK_Click(cmdPMOK, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmPunch", "cmdPMOK_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdPunchIn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPunchIn.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmploye As ADODB.Recordset
15: Dim iCompteur As Short
		
20: If VerifierModificationDate = True Then
25: mskNoProjet.Mask = vbNullString
30: mskNoProjet.Text = vbNullString
35: mskNoProjet.Mask = "#####-##"
			
40: txtClient.Text = vbNullString
			
45: cmbemployé.Visible = True
50: txtEmploye.Visible = False
			
55: mskNoProjet.Visible = True
60: txtnoprojet.Visible = False
			
65: picTypePunch.Enabled = True
			
70: rstEmploye = New ADODB.Recordset
			
75: Call rstEmploye.Open("SELECT GRB_Famille.Famille FROM GRB_employés INNER JOIN GRB_Famille ON GRB_employés.Famille = GRB_Famille.IDFamille WHERE employe = '" & m_iNoEmploye & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
80: If Not rstEmploye.EOF Then
85: Select Case rstEmploye.Fields("Famille").Value
					Case "Électrique" : optTypePunch(I_OPT_ELECTRIQUE).Checked = True
90: Case "Mécanique" : optTypePunch(I_OPT_MECANIQUE).Checked = True
95: Case Else : optTypePunch(I_OPT_ELECTRIQUE).Checked = True
100: End Select
105: Else
110: optTypePunch(I_OPT_ELECTRIQUE).Checked = True
115: End If
			
120: Call rstEmploye.Close()
125: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstEmploye = Nothing
			
130: cmbType.SelectedIndex = -1
			
			
135: mskHeure.Mask = vbNullString
140: mskHeure.Text = vbNullString
145: mskHeure.Mask = "##:##"
			
150: optHeure(I_OPT_SYSTEME).Checked = True
			
155: txtCommentaires.Text = vbNullString
			
160: chkKM.CheckState = System.Windows.Forms.CheckState.Unchecked
			
165: txtKM.Text = vbNullString
			
170: fraPunch.Text = "Punch in"
			
175: frajour.Visible = False
180: fraPunch.Visible = True
185: fraPunchMultiple.Visible = False
			
190: chkDiner.Visible = False
195: optHeureDiner(I_OPT_30_MINUTES).Visible = False
200: optHeureDiner(I_OPT_1_HEURE).Visible = False
			
205: Call mskNoProjet.Focus()
			
210: m_ePunch = enumPunch.I_PUNCH_IN
215: End If
		
220: m_bMonthViewHasFocus = False
		
225: Exit Sub
		
AfficherErreur: 
		
230: Call AfficherErreur("frmPunch", "cmdPunchIn_Click", Err, Erl())
	End Sub
	
	Private Sub cmdPunchIn_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdPunchIn.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdPunchIn_Click(cmdPunchIn, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmPunch", "cmdPunchIn_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdPunchMultiple_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdPunchMultiple.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdPunchMultiple_Click(cmdPunchMultiple, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmPunch", "cmdPunchMultiple_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdPunchMultiple_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPunchMultiple.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim rstEmploye As ADODB.Recordset
		
20: If VerifierModificationDate = True Then
25: For iCompteur = 1 To lvwEmployes.Items.Count
30: 'UPGRADE_WARNING: Lower bound of collection lvwEmployes.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvwEmployes.Items.Item(iCompteur).Checked = False
35: Next 
			
40: mskPMNoProjet.Mask = vbNullString
45: mskPMNoProjet.Text = vbNullString
50: mskPMNoProjet.Mask = "#####-##"
			
55: rstEmploye = New ADODB.Recordset
			
60: Call rstEmploye.Open("SELECT GRB_Famille.Famille FROM GRB_employés INNER JOIN GRB_Famille ON GRB_employés.Famille = GRB_Famille.IDFamille WHERE employe = '" & m_iNoEmploye & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
65: If Not rstEmploye.EOF Then
70: Select Case rstEmploye.Fields("Famille").Value
					Case "Électrique" : optPMTypePunch(I_OPT_ELECTRIQUE).Checked = True
75: Case "Mécanique" : optPMTypePunch(I_OPT_MECANIQUE).Checked = True
80: Case Else : optPMTypePunch(I_OPT_ELECTRIQUE).Checked = True
85: End Select
90: Else
95: optPMTypePunch(I_OPT_ELECTRIQUE).Checked = True
100: End If
			
105: Call rstEmploye.Close()
110: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstEmploye = Nothing
			
115: mskPMHeureDebut.Mask = vbNullString
120: mskPMHeureDebut.Text = vbNullString
125: mskPMHeureDebut.Mask = "##:##"
			
130: mskPMHeureFin.Mask = vbNullString
135: mskPMHeureFin.Text = vbNullString
140: mskPMHeureFin.Mask = "##:##"
			
145: txtPMCommentaire.Text = vbNullString
			
150: chkPMDiner.CheckState = System.Windows.Forms.CheckState.Unchecked
			
155: fraPunch.Visible = False
160: frajour.Visible = False
165: fraPunchMultiple.Visible = True
170: End If
		
175: m_bMonthViewHasFocus = False
		
180: Exit Sub
		
AfficherErreur: 
		
185: Call AfficherErreur("frmPunch", "cmdPunchMultiple_Click", Err, Erl())
	End Sub
	
	Private Sub cmdPunchOut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPunchOut.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmploye As ADODB.Recordset
		
15: If VerifierModificationDate = True Then
20: If lvwJour.Items.Count > 0 Then
25: If System.Drawing.ColorTranslator.ToOle(lvwJour.FocusedItem.ForeColor) = COLOR_ROUGE Then
30: m_ePunch = enumPunch.I_PUNCH_OUT
					
35: Call AfficherPunchOut()
					
40: fraPunch.Text = "Punch out"
					
45: chkDiner.Visible = True
50: optHeureDiner(I_OPT_30_MINUTES).Visible = True
55: optHeureDiner(I_OPT_1_HEURE).Visible = True
					
60: rstEmploye = New ADODB.Recordset
					
65: Call rstEmploye.Open("SELECT GRB_Famille.Famille FROM GRB_employés INNER JOIN GRB_Famille ON GRB_employés.Famille = GRB_Famille.IDFamille WHERE employe = '" & m_iNoEmploye & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
70: If Not rstEmploye.EOF Then
75: Select Case rstEmploye.Fields("Famille").Value
							Case "Administration" : optHeureDiner(I_OPT_1_HEURE).Checked = True
80: Case "Technicien" : optHeureDiner(I_OPT_1_HEURE).Checked = True
85: Case Else : optHeureDiner(I_OPT_30_MINUTES).Checked = True
90: End Select
95: Else
100: optHeureDiner(I_OPT_30_MINUTES).Checked = True
105: End If
					
110: Call rstEmploye.Close()
115: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstEmploye = Nothing
					
120: chkDiner.CheckState = System.Windows.Forms.CheckState.Unchecked
					
125: mskHeure.Mask = vbNullString
130: mskHeure.Text = vbNullString
135: mskHeure.Mask = "##:##"
					
140: optHeure(I_OPT_SYSTEME).Checked = True
145: Else
150: Call MsgBox("Le punch out a déjà été fait!")
155: End If
160: End If
165: End If
		
170: m_bMonthViewHasFocus = False
		
175: Exit Sub
		
AfficherErreur: 
		
180: Call AfficherErreur("frmPunch", "cmdPunchOut_Click", Err, Erl())
	End Sub
	
	Private Sub AfficherPunchOut()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmploye As ADODB.Recordset
15: Dim rstPunch As ADODB.Recordset
20: Dim rstClient As ADODB.Recordset
25: Dim iCompteur As Short
		Dim G As Short
30: rstPunch = New ADODB.Recordset
35: rstEmploye = New ADODB.Recordset
40: rstClient = New ADODB.Recordset
		
45: Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE IDPunch = " & lvwJour.FocusedItem.Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
50: Call rstEmploye.Open("SELECT employe FROM GRB_Employés WHERE NoEmploye = " & rstPunch.Fields("NoEmploye").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
55: For iCompteur = 0 To cmbemployé.Items.Count - 1
60: If VB6.GetItemString(cmbemployé, iCompteur) = rstEmploye.Fields("Employe").Value Then
65: cmbemployé.SelectedIndex = iCompteur
				
70: Exit For
75: End If
80: Next 
		
85: Call rstEmploye.Close()
90: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
95: Call rstClient.Open("SELECT NomClient FROM GRB_Client WHERE IDClient = " & rstPunch.Fields("NoClient").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
100: txtClient.Text = rstClient.Fields("NomClient").Value
		
105: txtClient.Tag = rstPunch.Fields("NoClient").Value
		
110: Call rstClient.Close()
115: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient = Nothing
		
120: txtnoprojet.Text = VB.Right(rstPunch.Fields("NoProjet").Value, 8)
		
125: Call RemplirComboType()
		
130: Call AfficherTypePunch()
		
135: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPunch.Fields("Commentaire").Value) Then
140: txtCommentaires.Text = rstPunch.Fields("Commentaire").Value
145: Else
150: txtCommentaires.Text = vbNullString
155: End If
		
160: If rstPunch.Fields("KM").Value = True Then
165: chkKM.CheckState = System.Windows.Forms.CheckState.Checked
			
170: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("NbreKM").Value) Then
175: txtKM.Text = rstPunch.Fields("NbreKM").Value
180: Else
185: txtKM.Text = CStr(0)
190: End If
195: Else
200: chkKM.CheckState = System.Windows.Forms.CheckState.Unchecked
205: txtKM.Text = vbNullString
210: End If
		
215: Select Case VB.Left(rstPunch.Fields("NoProjet").Value, 1)
			Case "E" : optTypePunch(I_OPT_ELECTRIQUE).Checked = True
220: Case "M" : optTypePunch(I_OPT_MECANIQUE).Checked = True
225: End Select
		
230: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstPunch.Fields("Type").Value) Then
235: If VB.Left(rstPunch.Fields("NoProjet").Value, 1) = "E" Then
				For G = 0 To cmbType.Items.Count
					If VB6.GetItemString(cmbType, G) = rstPunch.Fields("Type").Value Then
						cmbType.SelectedIndex = G
						Exit For
					End If
				Next 
310: 
315: Else
				For G = 0 To cmbType.Items.Count
					If VB6.GetItemString(cmbType, G) = rstPunch.Fields("Type").Value Then
						cmbType.SelectedIndex = G
						Exit For
					End If
				Next 
385: End If
390: End If
		
395: picTypePunch.Enabled = False
		
400: txtnoprojet.Visible = True
405: mskNoProjet.Visible = False
		
410: txtEmploye.Visible = True
415: cmbemployé.Visible = False
		
420: frajour.Visible = False
425: fraPunch.Visible = True
430: fraPunchMultiple.Visible = False
		
435: Exit Sub
		
AfficherErreur: 
		
440: Call AfficherErreur("frmPunch", "AfficherPunchOut", Err, Erl())
	End Sub
	
	Private Sub RemplirComboEmploye()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmploye As ADODB.Recordset
15: Dim rstAutorisation As ADODB.Recordset
20: Dim itmEmploye As System.Windows.Forms.ListViewItem
		
25: Call cmbemployé.Items.Clear()
30: Call lvwEmployes.Items.Clear()
		
35: rstEmploye = New ADODB.Recordset
40: rstAutorisation = New ADODB.Recordset
		
45: Call rstEmploye.Open("SELECT Employe FROM GRB_Employés WHERE NoEmploye = " & m_iNoEmploye, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
50: Call cmbemployé.Items.Add(rstEmploye.Fields("Employe").Value)
		
55: 'UPGRADE_ISSUE: ComboBox property cmbemployé.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
		VB6.SetItemData(cmbemployé, cmbemployé.NewIndex, m_iNoEmploye)
		
60: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwEmployes.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		itmEmploye = lvwEmployes.Items.Add()
		
65: itmEmploye.Text = rstEmploye.Fields("Employe").Value
70: itmEmploye.Tag = CStr(m_iNoEmploye)
		
75: Call rstEmploye.Close()
		
80: Call rstAutorisation.Open("SELECT * FROM GRB_AutorisationPunch WHERE AutoriserPar = " & m_iNoEmploye, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
85: If Not rstAutorisation.EOF Then
90: Do While Not rstAutorisation.EOF
95: Call rstEmploye.Open("SELECT Employe FROM GRB_Employés WHERE NoEmploye = " & rstAutorisation.Fields("NoEmploye").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
100: Call cmbemployé.Items.Add(rstEmploye.Fields("Employe").Value)
				
105: 'UPGRADE_ISSUE: ComboBox property cmbemployé.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				VB6.SetItemData(cmbemployé, cmbemployé.NewIndex, rstAutorisation.Fields("NoEmploye").Value)
				
110: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwEmployes.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmEmploye = lvwEmployes.Items.Add()
				
115: itmEmploye.Text = rstEmploye.Fields("Employe").Value
120: itmEmploye.Tag = rstAutorisation.Fields("NoEmploye").Value
				
125: Call rstEmploye.Close()
				
130: Call rstAutorisation.MoveNext()
135: Loop 
			
140: cmdPunchMultiple.Visible = True
145: Else
150: cmdPunchMultiple.Visible = False 'Gll
155: End If
		
160: Call rstAutorisation.Close()
165: 'UPGRADE_NOTE: Object rstAutorisation may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAutorisation = Nothing
		
170: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
175: If cmbemployé.Items.Count = 1 Then
180: cmbemployé.SelectedIndex = 0
185: End If
		
190: Exit Sub
		
AfficherErreur: 
		
195: Call AfficherErreur("frmPunch", "RemplirComboEmploye", Err, Erl())
	End Sub
	
	Private Sub cmdPunchOut_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdPunchOut.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdPunchOut_Click(cmdPunchOut, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmPunch", "cmdPunchOut_MouseUp", Err, Erl())
	End Sub
	
	Private Sub frmPunch_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		Call Table_exist()
10: mvwSelection.StartOfWeek = FirstDayOfWeek.Sunday
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmPunch", "Form_Load", Err, Erl())
	End Sub
	Private Sub lvwJour_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwJour.Click
		
5: On Error GoTo AfficherErreur
		
10: If lvwJour.Items.Count > 0 Then
15: If System.Drawing.ColorTranslator.ToOle(lvwJour.FocusedItem.ForeColor) = COLOR_ROUGE Then
20: cmdModifierPunchIn.Enabled = True
25: cmdModifierPunchOut.Enabled = False
30: Else
35: cmdModifierPunchIn.Enabled = True
40: cmdModifierPunchOut.Enabled = True
45: End If
50: Else
55: cmdModifierPunchIn.Enabled = False
60: cmdModifierPunchOut.Enabled = False
65: End If
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmPunch", "lvwJour_Click", Err, Erl())
	End Sub
	
	Private Sub lvwJour_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lvwJour.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: If lvwJour.Items.Count > 0 Then
15: If KeyCode = System.Windows.Forms.Keys.Delete Then
20: If MsgBox("Voulez-vous vraiment effacer ce punch ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
25: Call EffacerPunch()
30: End If
35: End If
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmPunch", "lvwJour_KeyDown", Err, Erl())
	End Sub
	
	Private Sub EffacerPunch()
		
5: On Error GoTo AfficherErreur
		
		'Efface le punch sélectionné
10: Call g_connData.Execute("DELETE * FROM GRB_Punch WHERE IDPunch = " & lvwJour.FocusedItem.Tag)
		
15: Call RemplirListViewSemaine(False)
20: Call RemplirListViewSemaineAutorisation(False)
25: Call RemplirListViewJour()
30: Call RemplirListViewJourAutorisation()
		
35: Call CalculerHeureSemaine()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmPunch", "EffacerPunch", Err, Erl())
	End Sub
	
	Private Sub mskHeure_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskHeure.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskHeure.Mask = "##:##"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmPunch", "mskHeure_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskHeure_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskHeure.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskHeure.Mask = vbNullString
		
15: If mskHeure.Text = "__:__" Then
20: mskHeure.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmPunch", "mskHeure_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskPMHeureDebut_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskPMHeureDebut.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskPMHeureDebut.Mask = "##:##"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmPunch", "mskPMHeureDebut_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskPMHeureDebut_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskPMHeureDebut.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskPMHeureDebut.Mask = vbNullString
		
15: If mskPMHeureDebut.Text = "__:__" Then
20: mskPMHeureDebut.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmPunch", "mskPMHeureDebut_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskPMHeureFin_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskPMHeureFin.Enter
		
5: On Error GoTo AfficherErreur
		
10: mskPMHeureFin.Mask = "##:##"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmPunch", "mskPMHeureFin_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskPMHeureFin_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskPMHeureFin.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskPMHeureFin.Mask = vbNullString
		
15: If mskPMHeureFin.Text = "__:__" Then
20: mskPMHeureFin.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmPunch", "mskPMHeureFin_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskNoProjet_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskNoProjet.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If fraPunch.Visible = True Then
15: If InStr(1, mskNoProjet.Text, "_") = 0 Then
20: Call AfficherTypePunch()
				
25: Call AfficherClient()
30: Else
35: txtClient.Text = vbNullString
40: End If
45: End If
		
50: Call RemplirComboType()
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmPunch", "mskNoProjet_Change", Err, Erl())
	End Sub
	
	Private Sub mskPMNoProjet_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskPMNoProjet.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: If fraPunchMultiple.Visible = True Then
15: If InStr(1, mskPMNoProjet.Text, "_") = 0 Then
20: Call AfficherTypePunch()
				
25: Call AfficherClient()
30: Else
35: txtPMClient.Text = vbNullString
40: End If
45: End If
		
50: Call RemplirComboType()
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmPunch", "mskPMNoProjet_Change", Err, Erl())
	End Sub
	
	Private Sub AfficherTypePunch()
		
5: On Error GoTo AfficherErreur
		
10: Dim sNumero As String
15: Dim sType As String
20: Dim bPM As Boolean
		
25: If fraPunchMultiple.Visible = True Then
30: sNumero = mskPMNoProjet.Text
35: bPM = True
40: Else
45: If mskNoProjet.Text <> "_____-__" Then
50: sNumero = mskNoProjet.Text
55: Else
60: sNumero = txtnoprojet.Text
61: End If
			
62: bPM = False
63: End If
		
64: If VB.Left(sNumero, 5) = VB.Right(CStr(Year(Today)), 1) & "3000" Then
65: Select Case VB.Right(sNumero, 2)
				Case "60" : sType = "Petits outils && fourniture"
70: Case "70" : sType = "Administration de la shop"
75: Case "71" : sType = "Identification de fils, lamicoïdes, etc."
80: Case "72" : sType = "Réception de marchandise"
85: Case "73" : sType = "Support technique informatique et téléphone"
90: Case "74" : sType = "Commissions"
95: Case "75" : sType = "Site web && publications"
100: Case "76" : sType = "Entretien && réparation de la bâtisse"
105: Case "77" : sType = "Ménage général"
110: Case "80" : sType = "Réparation des outils GRB"
115: Case "81" : sType = "Lavage des véhicules"
120: Case "82" : sType = "Entretien && réparation véhicules"
125: Case "83" : sType = "Formation du personnel"
130: Case "85" : sType = "Logiciel interne"
135: Case "95" : sType = "Bâtiment"
140: Case "97" : sType = "Équipement bureau && informatique"
145: Case "99" : sType = "Équipements && outillage"
150: Case Else : sType = vbNullString
155: End Select
			
160: If bPM = True Then
165: lblPMTypePunch.Text = sType
170: Else
175: lblTypePunch.Text = sType
180: End If
185: Else
190: If bPM = True Then
195: lblPMTypePunch.Text = vbNullString
200: Else
205: lblTypePunch.Text = vbNullString
210: End If
215: End If
		
220: Exit Sub
		
AfficherErreur: 
		
225: Call AfficherErreur("frmPunch", "AfficherTypePunch", Err, Erl())
	End Sub
	
	Private Sub AfficherClient()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstProjSoum As ADODB.Recordset
15: Dim rstClient As ADODB.Recordset
20: Dim iCompteur As Short
25: Dim sPrefixe As String
		
30: If fraPunchMultiple.Visible = True Then
35: If optPMTypePunch(I_OPT_ELECTRIQUE).Checked = True Then
40: sPrefixe = "E"
45: Else
50: sPrefixe = "M"
55: End If
60: Else
65: If optTypePunch(I_OPT_ELECTRIQUE).Checked = True Then
70: sPrefixe = "E"
75: Else
80: sPrefixe = "M"
85: End If
90: End If
		
95: rstProjSoum = New ADODB.Recordset
100: rstClient = New ADODB.Recordset
		
105: If fraPunchMultiple.Visible = True Then
110: Call rstProjSoum.Open("SELECT * FROM GRB_ProjSoum WHERE IDProjSoum = '" & sPrefixe & mskPMNoProjet.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
115: Else
120: Call rstProjSoum.Open("SELECT * FROM GRB_ProjSoum WHERE IDProjSoum = '" & sPrefixe & mskNoProjet.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
125: End If
		
130: If Not rstProjSoum.EOF Then
135: Call rstClient.Open("SELECT NomClient FROM GRB_Client WHERE IDClient = " & rstProjSoum.Fields("NoClient").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
140: If fraPunchMultiple.Visible = True Then
145: txtPMClient.Text = rstClient.Fields("NomClient").Value
150: txtPMClient.Tag = rstProjSoum.Fields("NoClient").Value
155: Else
160: txtClient.Text = rstClient.Fields("NomClient").Value
165: txtClient.Tag = rstProjSoum.Fields("NoClient").Value
170: End If
			
175: Call rstClient.Close()
180: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstClient = Nothing
			
185: If rstProjSoum.Fields("Ouvert").Value = False Then
190: If rstProjSoum.Fields("Type").Value = "P" Then
195: Call MsgBox("Ce projet est fermé!", MsgBoxStyle.OKOnly, "Erreur")
200: Else
205: Call MsgBox("Cette soumission est fermée!", MsgBoxStyle.OKOnly, "Erreur")
210: End If
215: End If
220: Else
225: Call MsgBox("Numéro inexistant!", MsgBoxStyle.OKOnly, "Erreur")
			
230: txtClient.Text = ""
235: txtClient.Tag = ""
240: End If
		
245: Call rstProjSoum.Close()
250: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjSoum = Nothing
		
255: Exit Sub
		
AfficherErreur: 
		
260: Call AfficherErreur("frmPunch", "AfficherClient", Err, Erl())
	End Sub
	
	Private Sub mvwSelection_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mvwSelection.Enter
		
		'Cette procédure sert à éliminer un bug du controle Active X MonthView
		'C'est un bug connu pas Microsoft et la solution suivante est proposée
		'Il faut avoir une variable boolean mise à true si le MonthView prend le focus
		'et ensuite, en cliquant sur un bouton, si le MonthView a le focus, on force le clique
		
5: On Error GoTo AfficherErreur
		
10: m_bMonthViewHasFocus = True
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmPunch", "mvwSelection_GotFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event optHeure.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optHeure_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optHeure.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = optHeure.GetIndex(eventSender)
			
5: On Error GoTo AfficherErreur
			
10: If Index = I_OPT_SYSTEME Then
15: mskHeure.Enabled = False
20: Else
25: mskHeure.Enabled = True
				
30: If m_bModifPunch = False Then
35: Call mskHeure.Focus()
40: End If
45: End If
			
50: Exit Sub
			
AfficherErreur: 
			
55: Call AfficherErreur("frmPunch", "optHeure_Click", Err, Erl())
		End If
	End Sub
	
	Private Sub lvwJourSemaine_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwJourSemaine.Click
		Dim Index As Short = lvwJourSemaine.GetIndex(eventSender)
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim sDate As String
20: Dim iNbreJour As Short
		
		'Initialise la couleur en blanc
25: For iCompteur = 1 To 7
30: lvwJourSemaine(iCompteur).BackColor = System.Drawing.ColorTranslator.FromOle(&HFFFFFF)
35: Next 
		
		'Sélectionne jour de semaine
40: lvwJourSemaine(Index).BackColor = System.Drawing.ColorTranslator.FromOle(&HE0E0E0)
		
45: sDate = lvwJourSemaine(Index).Tag
		
50: Select Case Mid(sDate, 6, 2)
			Case "01" : iNbreJour = 31
55: Case "02"
60: If CShort(VB.Left(sDate, 4)) Mod 4 = 0 Then
65: iNbreJour = 29
70: Else
75: iNbreJour = 28
80: End If
				
85: Case "03" : iNbreJour = 31
90: Case "04" : iNbreJour = 30
95: Case "05" : iNbreJour = 31
100: Case "06" : iNbreJour = 30
105: Case "07" : iNbreJour = 31
110: Case "08" : iNbreJour = 31
115: Case "09" : iNbreJour = 30
120: Case "10" : iNbreJour = 31
125: Case "11" : iNbreJour = 30
130: Case "12" : iNbreJour = 31
135: End Select
		
140: Do While mvwSelection.Day >= iNbreJour
145: mvwSelection.Day = mvwSelection.Day - 1
150: Loop 
		
		'Sélectionne dans calendrier
155: mvwSelection.Year = CShort(VB.Left(sDate, 4))
160: mvwSelection.Month = CShort(Mid(sDate, 6, 2))
165: mvwSelection.Day = CShort(VB.Right(sDate, 2))
		
		'Date choisie
170: m_datDateChoisie = DateSerial(mvwSelection.Year, mvwSelection.Month, mvwSelection.Day)
		
		'Affiche horaire jour
175: Call RemplirListViewJour()
180: Call RemplirListViewJourAutorisation()
		
185: frajour.Visible = True
190: fraPunch.Visible = False
		
195: Call lvwJour.Focus()
		
200: Exit Sub
		
AfficherErreur: 
		
205: Call AfficherErreur("frmPunch", "lvwJourSemaine_Click", Err, Erl(), "Date cliquée : " & sDate)
	End Sub
	
	Private Sub mskNoProjet_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles mskNoProjet.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
5: On Error GoTo AfficherErreur
		
		'Pour changer un "m" en un "M"
10: If KeyAscii = 109 Then '109 = m
15: KeyAscii = System.Windows.Forms.Keys.M 'M
20: End If
		
25: GoTo EventExitSub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmPunch", "mskNoProjet_KeyPress", Err, Erl())
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub mskPMNoProjet_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles mskPMNoProjet.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
5: On Error GoTo AfficherErreur
		
		'Pour changer un "m" en un "M"
10: If KeyAscii = 109 Then '109 = m
15: KeyAscii = System.Windows.Forms.Keys.M 'M
20: End If
		
25: GoTo EventExitSub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmPunch", "mskPMNoProjet_KeyPress", Err, Erl())
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
		'Enregistrement du punch in ou du punch out
10: Dim rstPunch As ADODB.Recordset
15: Dim rstProjSoum As ADODB.Recordset
20: Dim sHeure As String
25: Dim bModif As Boolean
30: Dim iCompteur As Short
35: Dim sPrefixe As String
40: Dim sType As String
45: Dim sNoProjet As String
50: Dim bInstallation As Boolean
55: Dim sHeureFin As String
		Dim sNumero As String
		
		
		If m_ePunch = enumPunch.I_MODIF_PUNCH_IN Or m_ePunch = enumPunch.I_PUNCH_IN Then
			sNumero = mskNoProjet.Text
		Else
			
			sNumero = txtnoprojet.Text
		End If
60: m_bMonthViewHasFocus = False
		
65: If optHeure(I_OPT_SYSTEME).Checked = True Then
70: sHeure = GetHeure(CStr(TimeOfDay))
75: bModif = False
80: Else
85: If mskHeure.Text <> vbNullString Then
90: If InStr(1, mskHeure.Text, "_") = 0 Then
95: sHeure = GetHeure(mskHeure.Text)
100: bModif = True
105: Else
110: Call MsgBox("Heure invalide!", MsgBoxStyle.OKOnly, "Erreur")
					
115: Exit Sub
120: End If
125: Else
130: Call MsgBox("Heure invalide!", MsgBoxStyle.OKOnly, "Erreur")
				
135: Exit Sub
140: End If
145: End If
		
150: If sHeure <> "" Then
155: If m_ePunch = enumPunch.I_MODIF_PUNCH_IN Or m_ePunch = enumPunch.I_PUNCH_IN Then
160: If cmbemployé.SelectedIndex = -1 Or InStr(1, mskNoProjet.Text, "_") > 0 Then
165: Call MsgBox("Le nom de l'employé et le numéro de projet sont des champs obligatoires!", MsgBoxStyle.OKOnly, "Erreur")
					
170: Exit Sub
175: End If
180: End If
			
185: If cmbType.SelectedIndex = -1 And cmbType.Visible = True Then
190: Call MsgBox("Le type est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
				
195: Exit Sub
200: End If
			
			'Si c'est une modification de punch in, il faut vérifier l'heure
			'pour être sur qu'elle sont correctes chronologiquement
205: If m_ePunch = enumPunch.I_MODIF_PUNCH_IN Then
210: 'UPGRADE_WARNING: Lower bound of collection lvwJour.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwJour.FocusedItem.SubItems(I_LVW_FIN).Text <> vbNullString Then
215: 'UPGRADE_WARNING: Lower bound of collection lvwJour.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If sHeure > lvwJour.FocusedItem.SubItems(I_LVW_FIN).Text Then
220: Call MsgBox("L'heure de début doit être plus petite que l'heure de fin!", MsgBoxStyle.OKOnly, "Erreur")
						
225: Exit Sub
230: End If
235: End If
240: End If
			
			'Si c'est une modification de punch in, il faut vérifier l'heure
			'pour être sur qu'elle sont correctes chronologiquement
245: If m_ePunch = enumPunch.I_MODIF_PUNCH_OUT Or m_ePunch = enumPunch.I_PUNCH_OUT Then
250: 'UPGRADE_WARNING: Lower bound of collection lvwJour.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If sHeure < lvwJour.FocusedItem.SubItems(I_LVW_DEBUT).Text Then
255: Call MsgBox("L'heure de fin doit être plus grande que l'heure de début!", MsgBoxStyle.OKOnly, "Erreur")
					
260: Exit Sub
265: End If
270: End If
			
			'Si c'est un punch out avec l'heure de diner et que c'est avant l'heure du diner
275: If m_ePunch = enumPunch.I_PUNCH_OUT Or m_ePunch = enumPunch.I_MODIF_PUNCH_OUT Then
280: If chkDiner.CheckState = System.Windows.Forms.CheckState.Checked Then
285: If optHeureDiner(I_OPT_30_MINUTES).Checked = True Then
290: If sHeure < "12:30" Then
295: Call MsgBox("La case à cocher 'Heure du dîner' ne peut être cochée seulement si l'heure de fin est plus grande que 12:30!", MsgBoxStyle.OKOnly, "Erreur")
							
300: Exit Sub
305: Else
310: 'UPGRADE_WARNING: Lower bound of collection lvwJour.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If lvwJour.FocusedItem.SubItems(I_LVW_DEBUT).Text > "12:00" Then
315: Call MsgBox("La case à cocher 'Heure du dîner' ne peut être cochée seulement si l'heure de début est plus petite que 12:00!", MsgBoxStyle.OKOnly, "Erreur")
								
320: Exit Sub
325: End If
330: End If
335: Else
340: If sHeure < "13:00" Then
345: Call MsgBox("La case à cocher 'Heure du dîner' ne peut être cochée seulement si l'heure de fin est plus grande que 13:00!", MsgBoxStyle.OKOnly, "Erreur")
							
350: Exit Sub
355: Else
360: 'UPGRADE_WARNING: Lower bound of collection lvwJour.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If lvwJour.FocusedItem.SubItems(I_LVW_DEBUT).Text > "12:00" Then
365: Call MsgBox("La case à cocher 'Heure du dîner' ne peut être cochée seulement si l'heure de début est plus petite que 12:00!", MsgBoxStyle.OKOnly, "Erreur")
								
370: Exit Sub
375: End If
380: End If
385: End If
390: End If
395: End If
			
400: If optTypePunch(I_OPT_ELECTRIQUE).Checked = True Then
405: sPrefixe = "E"
410: Else
415: sPrefixe = "M"
420: End If
			
425: If m_ePunch = enumPunch.I_MODIF_PUNCH_IN Or m_ePunch = enumPunch.I_PUNCH_IN Then
430: sNoProjet = mskNoProjet.Text
435: Else
440: sNoProjet = txtnoprojet.Text
445: End If
			
450: If cmbType.Visible = True Then
455: If IsNumeric(VB.Right(sNoProjet, 2)) Then
460: If CShort(VB.Right(sNoProjet, 2)) >= 51 And CShort(VB.Right(sNoProjet, 2)) <= 59 Then
465: bInstallation = True
470: Else
475: bInstallation = False
480: End If
485: Else
490: bInstallation = False
495: End If
				
500: If bInstallation = True Then
505: If sPrefixe = "E" Then
510: Select Case cmbType.SelectedIndex
							Case I_TYPE_ELEC_INSTALLATION : sType = "Installation"
515: Case I_TYPE_ELEC_MISE_SERVICE : sType = "MiseService"
520: End Select
525: Else
530: Select Case cmbType.SelectedIndex
							Case I_TYPE_MEC_INSTALLATION : sType = "Installation"
535: End Select
540: End If
545: Else
550: If sPrefixe = "E" Then
555: sType = cmbType.Text
610: 
615: Else
620: 
						sType = cmbType.Text
670: 
675: End If
680: End If
685: End If
			
690: If m_ePunch = enumPunch.I_MODIF_PUNCH_IN Or m_ePunch = enumPunch.I_PUNCH_IN Then
695: rstProjSoum = New ADODB.Recordset
				
700: Call rstProjSoum.Open("SELECT * FROM GRB_ProjSoum WHERE IDProjSoum = '" & sPrefixe & mskNoProjet.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
705: If Not rstProjSoum.EOF Then
710: If txtClient.Text <> "" Then
715: If rstProjSoum.Fields("Ouvert").Value = False Then
720: If rstProjSoum.Fields("Type").Value = "P" Then
725: Call MsgBox("Ce projet est fermé!", MsgBoxStyle.OKOnly, "Erreur")
730: Else
735: Call MsgBox("Cette soumission est fermée!", MsgBoxStyle.OKOnly, "Erreur")
740: End If
							
745: Call rstProjSoum.Close()
750: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
							rstProjSoum = Nothing
							
755: Exit Sub
760: End If
765: Else
770: Call MsgBox("Le client ne doit pas être vide!", MsgBoxStyle.OKOnly, "Erreur")
						
775: Call rstProjSoum.Close()
780: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						rstProjSoum = Nothing
						
785: Exit Sub
790: End If
795: Else
800: Call MsgBox("Numéro inexistant!", MsgBoxStyle.OKOnly, "Erreur")
					
805: Call rstProjSoum.Close()
810: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstProjSoum = Nothing
					
815: Exit Sub
820: End If
				
825: Call rstProjSoum.Close()
830: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstProjSoum = Nothing
835: End If
			
840: If Trim(txtCommentaires.Text) = "" Then
845: Call MsgBox("Le commentaire est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
				
850: Exit Sub
855: End If
			
860: rstPunch = New ADODB.Recordset
			
			'Selon le mode
865: Select Case m_ePunch
				'Si c'est un punch in
				Case enumPunch.I_PUNCH_IN
					'On ouvre le recordset avec la date et le no d'employé
870: Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE NoEmploye = " & VB6.GetItemData(cmbemployé, cmbemployé.SelectedIndex) & " AND Date = '" & ConvertDate(m_datDateChoisie) & "' ORDER BY Date,HeureDébut", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
					'Si il y a des enregistrements
875: If Not rstPunch.EOF Then
						'On va au dernier
880: Call rstPunch.MoveLast()
						
						'On vérifie si le dernier punch out n'a pas été fait
885: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If IsDbNull(rstPunch.Fields("HeureFin").Value) Or rstPunch.Fields("HeureFin").Value = vbNullString Then
							'On fait le punch out
890: rstPunch.Fields("ModifFin").Value = bModif
895: rstPunch.Fields("HeureFin").Value = sHeure
							
900: Call rstPunch.Update()
905: End If
910: End If
					
915: Call rstPunch.AddNew()
					
920: rstPunch.Fields("NoEmploye").Value = VB6.GetItemData(cmbemployé, cmbemployé.SelectedIndex)
925: rstPunch.Fields("NoProjet").Value = sPrefixe & mskNoProjet.Text
930: rstPunch.Fields("Date").Value = ConvertDate(DateSerial(mvwSelection.Year, mvwSelection.Month, mvwSelection.Day))
935: rstPunch.Fields("ModifDébut").Value = bModif
940: rstPunch.Fields("HeureDébut").Value = sHeure
945: rstPunch.Fields("Commentaire").Value = txtCommentaires.Text
950: rstPunch.Fields("NoClient").Value = txtClient.Tag
					
955: If chkKM.CheckState = System.Windows.Forms.CheckState.Checked Then
960: rstPunch.Fields("KM").Value = True
						
965: If txtKM.Text <> "" Then
970: txtKM.Text = Replace(txtKM.Text, ".", ",")
							
975: If IsNumeric(txtKM.Text) Then
980: rstPunch.Fields("NbreKM").Value = txtKM.Text
985: Else
990: rstPunch.Fields("NbreKM").Value = 0
995: End If
1000: Else
1005: rstPunch.Fields("KM").Value = False
1010: rstPunch.Fields("NbreKM").Value = ""
1015: End If
1020: Else
1025: rstPunch.Fields("KM").Value = False
1030: rstPunch.Fields("NbreKM").Value = ""
1035: End If
					If Mid(sNumero, 2, 1) = "1" Then
						rstPunch.Fields("Type").Value = "Soumission"
					Else
1040: rstPunch.Fields("Type").Value = sType
					End If
1045: Call rstPunch.Update()
					
1050: Call rstPunch.Close()
					
					'Si c'est un punch out
1055: Case enumPunch.I_PUNCH_OUT
					'Si l'élément choisi est en noir, le punch out a déjà été fait
1060: If System.Drawing.ColorTranslator.ToOle(lvwJour.FocusedItem.ForeColor) = COLOR_ROUGE Then
						'On ouvre le recordset avec le numéro de punch
1065: Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE IDPunch = " & lvwJour.FocusedItem.Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
						
1070: If chkDiner.CheckState = System.Windows.Forms.CheckState.Checked Then
1075: rstPunch.Fields("ModifFin").Value = False
1080: rstPunch.Fields("HeureFin").Value = "12:00"
1085: Else
1090: rstPunch.Fields("ModifFin").Value = bModif
1095: rstPunch.Fields("HeureFin").Value = sHeure
1100: End If
						
1105: rstPunch.Fields("Commentaire").Value = txtCommentaires.Text
						
1110: If chkKM.CheckState = System.Windows.Forms.CheckState.Checked Then
1115: rstPunch.Fields("KM").Value = True
							
1120: If txtKM.Text <> "" Then
1125: txtKM.Text = Replace(txtKM.Text, ".", ",")
								
1130: If IsNumeric(txtKM.Text) Then
1135: rstPunch.Fields("NbreKM").Value = txtKM.Text
1140: Else
1145: rstPunch.Fields("NbreKM").Value = 0
1150: End If
1155: Else
1160: rstPunch.Fields("KM").Value = False
1165: rstPunch.Fields("NbreKM").Value = ""
1170: End If
1175: Else
1180: rstPunch.Fields("KM").Value = False
1185: rstPunch.Fields("NbreKM").Value = ""
1190: End If
						If Mid(sNumero, 2, 1) = "1" Then
							rstPunch.Fields("Type").Value = "Soumission"
						Else
1195: rstPunch.Fields("Type").Value = sType
						End If
1200: Call rstPunch.Update()
						
1205: If chkDiner.CheckState = System.Windows.Forms.CheckState.Checked Then
1210: Call rstPunch.AddNew()
							
1215: rstPunch.Fields("NoEmploye").Value = VB6.GetItemData(cmbemployé, cmbemployé.SelectedIndex)
							
1220: If mskNoProjet.Text = "_____-__" Then
1225: rstPunch.Fields("NoProjet").Value = sPrefixe & txtnoprojet.Text
1230: Else
1235: rstPunch.Fields("NoProjet").Value = sPrefixe & mskNoProjet.Text
1240: End If
							
1245: rstPunch.Fields("Date").Value = ConvertDate(DateSerial(mvwSelection.Year, mvwSelection.Month, mvwSelection.Day))
1250: rstPunch.Fields("ModifDébut").Value = False
							
1255: If optHeureDiner(I_OPT_30_MINUTES).Checked = True Then
1260: rstPunch.Fields("HeureDébut").Value = "12:30"
1265: Else
1270: rstPunch.Fields("HeureDébut").Value = "13:00"
1275: End If
							
1280: rstPunch.Fields("Commentaire").Value = txtCommentaires.Text
1285: rstPunch.Fields("NoClient").Value = txtClient.Tag
1290: rstPunch.Fields("ModifFin").Value = bModif
1295: rstPunch.Fields("HeureFin").Value = sHeure
							If Mid(sNumero, 2, 1) = "1" Then
								rstPunch.Fields("Type").Value = "Soumission"
							Else
1300: rstPunch.Fields("Type").Value = sType
							End If
1305: Call rstPunch.Update()
1310: End If
						
1315: Call rstPunch.Close()
1320: Else
1325: Call MsgBox("Le punch out a déjà été fait!", MsgBoxStyle.OKOnly, "Erreur")
1330: End If
					
					'Si c'est une modification de punch in
1335: Case enumPunch.I_MODIF_PUNCH_IN
					'On ouvre le recordset avec le numéro de punch
1340: Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE IDPunch = " & lvwJour.FocusedItem.Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
1345: rstPunch.Fields("NoEmploye").Value = VB6.GetItemData(cmbemployé, cmbemployé.SelectedIndex)
1350: rstPunch.Fields("NoProjet").Value = sPrefixe & mskNoProjet.Text
1355: rstPunch.Fields("NoClient").Value = txtClient.Tag
1360: rstPunch.Fields("Date").Value = ConvertDate(DateSerial(mvwSelection.Year, mvwSelection.Month, mvwSelection.Day))
					
1365: If bModif = True Then
1370: If rstPunch.Fields("HeureDébut").Value <> sHeure Then
1375: rstPunch.Fields("ModifDébut").Value = True
1380: Else
1385: rstPunch.Fields("ModifDébut").Value = False
1390: End If
1395: Else
1400: rstPunch.Fields("ModifDébut").Value = False
1405: End If
					
1410: rstPunch.Fields("HeureDébut").Value = sHeure
					
1415: rstPunch.Fields("Commentaire").Value = txtCommentaires.Text
					
1420: If chkKM.CheckState = System.Windows.Forms.CheckState.Checked Then
1425: rstPunch.Fields("KM").Value = True
						
1430: If txtKM.Text <> "" Then
1435: txtKM.Text = Replace(txtKM.Text, ".", ",")
							
1440: If IsNumeric(txtKM.Text) Then
1445: rstPunch.Fields("NbreKM").Value = txtKM.Text
1450: Else
1455: rstPunch.Fields("NbreKM").Value = 0
1460: End If
1465: Else
1470: rstPunch.Fields("KM").Value = False
1475: rstPunch.Fields("NbreKM").Value = 0
1480: End If
1485: Else
1490: rstPunch.Fields("KM").Value = False
1495: rstPunch.Fields("NbreKM").Value = ""
1500: End If
					If Mid(sNumero, 2, 1) = "1" Then
						rstPunch.Fields("Type").Value = "Soumission"
					Else
1505: rstPunch.Fields("Type").Value = sType
					End If
1510: Call rstPunch.Update()
					
1515: Call rstPunch.Close()
					
					'Si c'est une modification de punch out
1520: Case enumPunch.I_MODIF_PUNCH_OUT
					'On ouvre le recordset avec le numéro de punch
1525: Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE IDPunch = " & lvwJour.FocusedItem.Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
1530: If chkDiner.CheckState = System.Windows.Forms.CheckState.Checked Then
1535: sHeureFin = rstPunch.Fields("HeureFin").Value
						
1540: rstPunch.Fields("ModifFin").Value = False
1545: rstPunch.Fields("HeureFin").Value = "12:00"
1550: Else
1555: If bModif = True Then
1560: If rstPunch.Fields("HeureFin").Value <> sHeure Then
1565: rstPunch.Fields("ModifFin").Value = True
1570: Else
1575: rstPunch.Fields("ModifFin").Value = False
1580: End If
1585: Else
1590: rstPunch.Fields("ModifFin").Value = False
1595: End If
						
1600: rstPunch.Fields("HeureFin").Value = sHeure
1605: End If
					
1610: rstPunch.Fields("Commentaire").Value = txtCommentaires.Text
					
1615: If chkKM.CheckState = System.Windows.Forms.CheckState.Checked Then
1620: rstPunch.Fields("KM").Value = True
						
1625: If txtKM.Text <> "" Then
1630: txtKM.Text = Replace(txtKM.Text, ".", ",")
							
1635: If IsNumeric(txtKM.Text) Then
1640: rstPunch.Fields("NbreKM").Value = txtKM.Text
1645: Else
1650: rstPunch.Fields("NbreKM").Value = 0
1655: End If
1660: Else
1665: rstPunch.Fields("KM").Value = False
1670: rstPunch.Fields("NbreKM").Value = ""
1675: End If
1680: Else
1685: rstPunch.Fields("KM").Value = False
1690: rstPunch.Fields("NbreKM").Value = ""
1695: End If
					
					If Mid(sNumero, 2, 1) = "1" Then
						rstPunch.Fields("Type").Value = "Soumission"
					Else
1700: rstPunch.Fields("Type").Value = sType
					End If
1705: Call rstPunch.Update()
					
1710: If chkDiner.CheckState = System.Windows.Forms.CheckState.Checked Then
1715: Call rstPunch.AddNew()
						
1720: rstPunch.Fields("NoEmploye").Value = VB6.GetItemData(cmbemployé, cmbemployé.SelectedIndex)
						
1725: rstPunch.Fields("NoProjet").Value = sPrefixe & txtnoprojet.Text
						
1730: rstPunch.Fields("Date").Value = ConvertDate(DateSerial(mvwSelection.Year, mvwSelection.Month, mvwSelection.Day))
1735: rstPunch.Fields("ModifDébut").Value = False
						
1740: If optHeureDiner(I_OPT_30_MINUTES).Checked = True Then
1745: rstPunch.Fields("HeureDébut").Value = "12:30"
1750: Else
1755: rstPunch.Fields("HeureDébut").Value = "13:00"
1760: End If
						
1765: rstPunch.Fields("Commentaire").Value = txtCommentaires.Text
1770: rstPunch.Fields("NoClient").Value = txtClient.Tag
						
1775: If bModif = True Then
1780: If rstPunch.Fields("HeureFin").Value <> sHeureFin Then
1785: rstPunch.Fields("ModifFin").Value = True
1790: Else
1795: rstPunch.Fields("ModifFin").Value = False
1800: End If
1805: Else
1810: rstPunch.Fields("ModifFin").Value = False
1815: End If
						
1820: rstPunch.Fields("HeureFin").Value = sHeure
						
1825: rstPunch.Fields("Type").Value = sType
						
1830: Call rstPunch.Update()
1835: End If
					
1840: Call rstPunch.Close()
1845: End Select
			
1850: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstPunch = Nothing
			
1855: Call RemplirListViewSemaine(True)
1860: Call RemplirListViewSemaineAutorisation(True)
1865: Call RemplirListViewJour()
1870: Call RemplirListViewJourAutorisation()
			
1875: Call CalculerHeureSemaine()
			
1880: frajour.Visible = True
1885: fraPunch.Visible = False
1890: fraPunchMultiple.Visible = False
1895: End If
		
1900: Exit Sub
		
AfficherErreur: 
		
1905: Call AfficherErreur("frmPunch", "cmdOK_Click", Err, Erl())
	End Sub
	
	Private Sub cmdPMOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPMOK.Click
		
5: On Error GoTo AfficherErreur
		
		'Enregistrement du punch in ou du punch out
10: Dim rstPunch As ADODB.Recordset
15: Dim rstProjSoum As ADODB.Recordset
20: Dim sHeureDebut As String
25: Dim sHeureFin As String
30: Dim iCompteur As Short
35: Dim bSelect As Boolean
40: Dim sPrefixe As String
45: Dim sType As String
50: Dim bInstallation As Boolean
		
55: m_bMonthViewHasFocus = False
		
60: If mskPMHeureDebut.Text <> vbNullString Then
65: If InStr(1, mskPMHeureDebut.Text, "_") = 0 Then
70: sHeureDebut = GetHeure(mskPMHeureDebut.Text)
75: Else
80: Call MsgBox("Heure de début invalide!", MsgBoxStyle.OKOnly, "Erreur")
				
85: Exit Sub
90: End If
95: Else
100: Call MsgBox("Heure de début invalide!", MsgBoxStyle.OKOnly, "Erreur")
			
105: Exit Sub
110: End If
		
115: If mskPMHeureFin.Text <> vbNullString Then
120: If InStr(1, mskPMHeureFin.Text, "_") = 0 Then
125: sHeureFin = GetHeure(mskPMHeureFin.Text)
130: Else
135: Call MsgBox("Heure de fin invalide!", MsgBoxStyle.OKOnly, "Erreur")
				
140: Exit Sub
145: End If
150: Else
155: Call MsgBox("Heure de fin invalide!", MsgBoxStyle.OKOnly, "Erreur")
			
160: Exit Sub
165: End If
		
170: If cmbPMType.SelectedIndex = -1 And cmbPMType.Visible = True Then
175: Call MsgBox("Le type est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
			
180: Exit Sub
185: End If
		
190: For iCompteur = 1 To lvwEmployes.Items.Count
195: 'UPGRADE_WARNING: Lower bound of collection lvwEmployes.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwEmployes.Items.Item(iCompteur).Checked = True Then
200: bSelect = True
				
205: Exit For
210: End If
215: Next 
		
220: If bSelect = False Then
225: Call MsgBox("Vous devez choisir au moins 1 employé!", MsgBoxStyle.OKOnly, "Erreur")
			
230: Exit Sub
235: End If
		
240: If InStr(1, mskPMNoProjet.Text, "_") > 0 Then
245: Call MsgBox("Le numéro de projet est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
			
250: Exit Sub
255: End If
		
260: If sHeureDebut > sHeureFin Then
265: Call MsgBox("L'heure de début doit être plus petite que l'heure de fin!", MsgBoxStyle.OKOnly, "Erreur")
			
270: Exit Sub
275: End If
		
		'Si c'est un punch out avec l'heure de diner et que c'est avant l'heure du diner
280: If chkPMDiner.CheckState = System.Windows.Forms.CheckState.Checked Then
285: If optPMHeureDiner(I_OPT_30_MINUTES).Checked = True Then
290: If sHeureDebut > "12:00" Or sHeureFin < "12:30" Then
295: Call MsgBox("La case à cocher 'Heure du dîner' ne peut être cochée que si l'heure de début est plus petite que 12:00" & vbNewLine & " ou que l'heure de fin est plus grande que 12:30!", MsgBoxStyle.OKOnly, "Erreur")
					
300: Exit Sub
305: End If
310: Else
315: If sHeureDebut > "12:00" Or sHeureFin < "13:00" Then
320: Call MsgBox("La case à cocher 'Heure du dîner' ne peut être cochée que si l'heure de début est plus petite que 12:00" & vbNewLine & " ou que l'heure de fin est plus grande que 13:00!", MsgBoxStyle.OKOnly, "Erreur")
					
325: Exit Sub
330: End If
335: End If
340: End If
		
345: If optPMTypePunch(I_OPT_ELECTRIQUE).Checked = True Then
350: sPrefixe = "E"
355: Else
360: sPrefixe = "M"
365: End If
		
370: If cmbPMType.Visible = True Then
375: If IsNumeric(VB.Right(mskPMNoProjet.Text, 2)) Then
380: If CShort(VB.Right(mskPMNoProjet.Text, 2)) >= 51 And CShort(VB.Right(mskPMNoProjet.Text, 2)) <= 59 Then
385: bInstallation = True
390: Else
395: bInstallation = False
400: End If
405: Else
410: bInstallation = False
415: End If
			
420: If bInstallation = True Then
425: If sPrefixe = "E" Then
430: Select Case cmbPMType.SelectedIndex
						Case I_TYPE_ELEC_INSTALLATION : sType = "Installation"
435: Case I_TYPE_ELEC_MISE_SERVICE : sType = "Formation"
440: End Select
445: Else
450: Select Case cmbPMType.SelectedIndex
						Case I_TYPE_MEC_INSTALLATION : sType = "Installation"
455: End Select
460: End If
465: Else
470: If sPrefixe = "E" Then
					sType = cmbPMType.Text
480: 
530: 
535: Else
540: sType = cmbPMType.Text
					
590: 
595: End If
600: End If
605: End If
		
610: rstProjSoum = New ADODB.Recordset
		
615: Call rstProjSoum.Open("SELECT * FROM GRB_ProjSoum WHERE IDProjSoum = '" & sPrefixe & mskPMNoProjet.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
620: If Not rstProjSoum.EOF Then
625: If txtPMClient.Text <> "" Then
630: If rstProjSoum.Fields("Ouvert").Value = False Then
635: If rstProjSoum.Fields("Type").Value = "P" Then
640: Call MsgBox("Ce projet est fermé!", MsgBoxStyle.OKOnly, "Erreur")
645: Else
650: Call MsgBox("Cette soumission est fermée!", MsgBoxStyle.OKOnly, "Erreur")
655: End If
					
660: Call rstProjSoum.Close()
665: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstProjSoum = Nothing
					
670: Exit Sub
675: End If
680: Else
685: Call MsgBox("Le client ne doit pas être vide!", MsgBoxStyle.OKOnly, "Erreur")
				
690: Call rstProjSoum.Close()
695: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstProjSoum = Nothing
				
700: Exit Sub
705: End If
710: Else
715: Call MsgBox("Numéro inexistant!", MsgBoxStyle.OKOnly, "Erreur")
			
720: Call rstProjSoum.Close()
725: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstProjSoum = Nothing
			
730: Exit Sub
735: End If
		
740: Call rstProjSoum.Close()
745: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjSoum = Nothing
		
750: If Trim(txtPMCommentaire.Text) = "" Then
755: Call MsgBox("Le commentaire est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
			
760: Exit Sub
765: End If
		
770: rstPunch = New ADODB.Recordset
		
775: For iCompteur = 1 To lvwEmployes.Items.Count
780: 'UPGRADE_WARNING: Lower bound of collection lvwEmployes.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwEmployes.Items.Item(iCompteur).Checked = True Then
785: Call rstPunch.Open("SELECT * FROM GRB_Punch", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
790: Call rstPunch.AddNew()
				
795: 'UPGRADE_WARNING: Lower bound of collection lvwEmployes.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Couldn't resolve default property of object lvwEmployes.ListItems().Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				rstPunch.Fields("NoEmploye").Value = lvwEmployes.Items.Item(iCompteur).Tag
800: rstPunch.Fields("NoProjet").Value = sPrefixe & mskPMNoProjet.Text
805: rstPunch.Fields("Date").Value = ConvertDate(DateSerial(mvwSelection.Year, mvwSelection.Month, mvwSelection.Day))
810: rstPunch.Fields("ModifDébut").Value = False
815: rstPunch.Fields("HeureDébut").Value = sHeureDebut
				
820: rstPunch.Fields("ModifFin").Value = False
				
825: If chkPMDiner.CheckState = System.Windows.Forms.CheckState.Checked Then
830: rstPunch.Fields("HeureFin").Value = "12:00"
835: Else
840: rstPunch.Fields("HeureFin").Value = sHeureFin
845: End If
				
850: rstPunch.Fields("Commentaire").Value = txtPMCommentaire.Text
855: rstPunch.Fields("NoClient").Value = txtPMClient.Tag
				
860: rstPunch.Fields("KM").Value = False
865: rstPunch.Fields("NbreKM").Value = ""
				
870: rstPunch.Fields("Type").Value = sType
				
875: Call rstPunch.Update()
				
880: If chkPMDiner.CheckState = System.Windows.Forms.CheckState.Checked Then
885: Call rstPunch.AddNew()
					
890: 'UPGRADE_WARNING: Lower bound of collection lvwEmployes.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Couldn't resolve default property of object lvwEmployes.ListItems().Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					rstPunch.Fields("NoEmploye").Value = lvwEmployes.Items.Item(iCompteur).Tag
895: rstPunch.Fields("NoProjet").Value = sPrefixe & mskPMNoProjet.Text
900: rstPunch.Fields("Date").Value = ConvertDate(DateSerial(mvwSelection.Year, mvwSelection.Month, mvwSelection.Day))
905: rstPunch.Fields("ModifDébut").Value = False
					
910: If optPMHeureDiner(I_OPT_30_MINUTES).Checked = True Then
915: rstPunch.Fields("HeureDébut").Value = "12:30"
920: Else
925: rstPunch.Fields("HeureDébut").Value = "13:00"
930: End If
					
935: rstPunch.Fields("Commentaire").Value = txtPMCommentaire.Text
940: rstPunch.Fields("NoClient").Value = txtPMClient.Tag
945: rstPunch.Fields("ModifFin").Value = False
950: rstPunch.Fields("HeureFin").Value = sHeureFin
					
955: rstPunch.Fields("Type").Value = sType
					
960: Call rstPunch.Update()
965: End If
				
970: Call rstPunch.Update()
				
975: Call rstPunch.Close()
980: End If
985: Next 
		
990: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPunch = Nothing
		
995: Call RemplirListViewSemaine(True)
1000: Call RemplirListViewSemaineAutorisation(True)
1005: Call RemplirListViewJour()
1010: Call RemplirListViewJourAutorisation()
		
1015: Call CalculerHeureSemaine()
		
1020: frajour.Visible = True
1025: fraPunch.Visible = False
1030: fraPunchMultiple.Visible = False
		
1035: Exit Sub
		
AfficherErreur: 
		
1040: Call AfficherErreur("frmPunch", "cmdPMOK_Click", Err, Erl())
	End Sub
	
	Private Function GetHeure(ByVal sHeure As String) As String
		
5: On Error GoTo AfficherErreur
		
10: Dim datHeure As Date
15: Dim b24Heure As Boolean
		
20: If IsNumeric(VB.Left(sHeure, 2)) And IsNumeric(Mid(sHeure, 4, 2)) Then
25: If (CShort(VB.Left(sHeure, 2)) < 0 Or CShort(VB.Left(sHeure, 2)) > 24) Or (CShort(Mid(sHeure, 4, 2)) < 0 Or CShort(Mid(sHeure, 4, 2)) > 59) Then
30: Call MsgBox("Heure incorrecte!", MsgBoxStyle.OKOnly, "Erreur")
				
35: Exit Function
40: End If
45: Else
50: Call MsgBox("Heure incorrecte!", MsgBoxStyle.OKOnly, "Erreur")
			
55: Exit Function
60: End If
		
65: sHeure = Replace(sHeure, "AM", "")
		
70: If InStr(1, sHeure, "PM") > 0 Then
75: sHeure = Trim(Replace(sHeure, "PM", ""))
			
80: sHeure = CShort(VB.Left(sHeure, 2)) + 12 & VB.Right(sHeure, Len(sHeure) - 2)
			
85: b24Heure = True
90: End If
		
95: sHeure = VB.Left(sHeure, 5)
		
100: If sHeure <> "24:00" Then
105: datHeure = CDate(sHeure)
			
110: If Minute(datHeure) <= 5 Then
115: datHeure = TimeSerial(Hour(datHeure), 0, 0)
120: Else
125: If Minute(datHeure) <= 24 Then
130: datHeure = TimeSerial(Hour(datHeure), 15, 0)
135: Else
140: If Minute(datHeure) <= 35 Then
145: datHeure = TimeSerial(Hour(datHeure), 30, 0)
150: Else
155: If Minute(datHeure) <= 54 Then
160: datHeure = TimeSerial(Hour(datHeure), 45, 0)
165: Else
170: datHeure = TimeSerial(Hour(datHeure) + 1, 0, 0)
175: End If
180: End If
185: End If
190: End If
			
195: GetHeure = VB.Right("0" & Hour(datHeure), 2) & ":" & VB.Right("0" & Minute(datHeure), 2)
200: Else
205: GetHeure = sHeure
210: End If
		
215: Exit Function
		
AfficherErreur: 
		
220: Call AfficherErreur("frmPunch", "GetHeure", Err, Erl())
	End Function
	
	Private Sub optHeure_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles optHeure.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = optHeure.GetIndex(eventSender)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: If optHeure(Index).Checked = False Then
20: optHeure(Index).Checked = True
25: End If
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmPunch", "optHeure_MouseUp", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event optTypePunch.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optTypePunch_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optTypePunch.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = optTypePunch.GetIndex(eventSender)
			
5: On Error GoTo AfficherErreur
			
10: If InStr(1, mskNoProjet.Text, "_") = 0 Then
15: Call AfficherTypePunch()
				
20: Call AfficherClient()
25: Else
30: If fraPunch.Visible = True Then
35: Call mskNoProjet.Focus()
40: End If
45: End If
			
50: Select Case Index
				Case I_OPT_ELECTRIQUE : lblPrefixe.Text = "E"
55: Case I_OPT_MECANIQUE : lblPrefixe.Text = "M"
60: End Select
			
65: Call RemplirComboType()
			
70: m_bMonthViewHasFocus = False
			
75: Exit Sub
			
AfficherErreur: 
			
80: Call AfficherErreur("frmPunch", "optTypePunch_Click", Err, Erl())
		End If
	End Sub
	
	Private Sub optTypePunch_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles optTypePunch.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = optTypePunch.GetIndex(eventSender)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call optTypePunch_CheckedChanged(optTypePunch.Item(Index), New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmPunch", "optTypePunch_MouseUp", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event optPMTypePunch.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optPMTypePunch_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optPMTypePunch.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = optPMTypePunch.GetIndex(eventSender)
			
5: On Error GoTo AfficherErreur
			
10: If InStr(1, mskPMNoProjet.Text, "_") = 0 Then
15: Call AfficherTypePunch()
				
20: Call AfficherClient()
25: Else
30: If fraPunchMultiple.Visible = True Then
35: Call mskPMNoProjet.Focus()
40: End If
45: End If
			
50: Select Case Index
				Case I_OPT_ELECTRIQUE : lblPMPrefixe.Text = "E"
55: Case I_OPT_MECANIQUE : lblPMPrefixe.Text = "M"
60: End Select
			
65: Call RemplirComboType()
			
70: m_bMonthViewHasFocus = False
			
75: Exit Sub
			
AfficherErreur: 
			
80: Call AfficherErreur("frmPunch", "optPMTypePunch_Click", Err, Erl())
		End If
	End Sub
	
	Private Sub RemplirComboType()
		
5: On Error GoTo AfficherErreur
		
10: Dim cmbSource As System.Windows.Forms.ComboBox
15: Dim lblSource As System.Windows.Forms.Label
20: Dim sType As String
25: Dim sNumero As String
30: Dim bInstallation As Boolean
		Dim tblremplircombo As ADODB.Recordset
		tblremplircombo = New ADODB.Recordset
		
35: If fraPunchMultiple.Visible = True Then
			
40: cmbSource = cmbPMType
45: lblSource = lblPMType
			
50: sType = lblPMPrefixe.Text
			
55: sNumero = mskPMNoProjet.Text
60: Else
			
65: cmbSource = cmbType
70: lblSource = lblType
			
75: sType = lblPrefixe.Text
			
80: If m_ePunch = enumPunch.I_MODIF_PUNCH_IN Or m_ePunch = enumPunch.I_PUNCH_IN Then
				
85: sNumero = mskNoProjet.Text
90: Else
				
95: sNumero = txtnoprojet.Text
100: End If
105: End If
		
110: Call cmbSource.Items.Clear()
		
115: If Mid(sNumero, 2, 1) = "1" Or Mid(sNumero, 2, 4) = "3000" Then
120: cmbSource.Visible = False
125: lblSource.Visible = False
			
130: Exit Sub
135: Else
			
140: cmbSource.Visible = True
145: lblSource.Visible = True
150: End If
		
155: If IsNumeric(VB.Right(sNumero, 2)) Then
			
160: If CShort(VB.Right(sNumero, 2)) >= 51 And CShort(VB.Right(sNumero, 2)) <= 59 Then
				
165: bInstallation = True
170: Else
				
175: bInstallation = False
180: End If
185: Else
			
190: bInstallation = False
195: End If
		
200: If bInstallation = True Then
			
205: If sType = "E" Then
				
210: Call cmbSource.Items.Add("Installation")
215: Call cmbSource.Items.Add("Mise en service")
220: Else
				
225: Call cmbSource.Items.Add("Installation")
230: End If
235: Else
240: If sType = "E" Then
				
245: Call tblremplircombo.Open("Select * from TBL_Punch_Type WHERE MODE = 'E' Order by name ", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
260: Do While Not tblremplircombo.EOF
265: cmbSource.Items.Add((tblremplircombo.Fields("name").Value))
270: Call tblremplircombo.MoveNext()
275: 
280: Loop 
285: Call tblremplircombo.Close()
290: 'UPGRADE_NOTE: Object tblremplircombo may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				tblremplircombo = Nothing
295: 
				
300: Else
				
305: Call tblremplircombo.Open("Select * from TBL_Punch_Type WHERE MODE = 'M' Order by name ", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
310: Do While Not tblremplircombo.EOF
315: cmbSource.Items.Add((tblremplircombo.Fields("name").Value))
320: Call tblremplircombo.MoveNext()
325: Loop 
330: Call tblremplircombo.Close()
335: 'UPGRADE_NOTE: Object tblremplircombo may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				tblremplircombo = Nothing
340: 
345: 
350: 
				
355: End If
360: End If
		
365: 'UPGRADE_NOTE: Object cmbSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		cmbSource = Nothing
		
370: Exit Sub
		
AfficherErreur: 
		
375: Call AfficherErreur("frmPunch", "RemplirComboType", Err, Erl())
	End Sub
	
	Private Sub optPMTypePunch_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles optPMTypePunch.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = optPMTypePunch.GetIndex(eventSender)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call optPMTypePunch_CheckedChanged(optPMTypePunch.Item(Index), New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmPunch", "optPMTypePunch_MouseUp", Err, Erl())
	End Sub
	
	Private Sub txtKM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtKM.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtKM.Text = Replace(txtKM.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmPunch", "txtKM_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mvwSelection_SelChange(ByVal eventSender As System.Object, ByVal eventArgs As AxMSComCtl2.DMonthViewEvents_SelChangeEvent) Handles mvwSelection.SelChange
		
5: On Error GoTo AfficherErreur
		
10: If Month(m_datDateChoisie) <> mvwSelection.Month Or Year(m_datDateChoisie) <> mvwSelection.Year Or VB.Day(m_datDateChoisie) <> mvwSelection.Day Then
15: Call AfficherDate()
			
20: Call CalculerHeureSemaine()
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmPunch", "mvwSelection_SelChange", Err, Erl())
	End Sub
	
	Private Function VerifierModificationDate() As Boolean
		
5: On Error GoTo AfficherErreur
		
10: Dim bModif As Boolean
15: Dim datSelected As Date
20: Dim datToday As Date
25: Dim datFirstDaySelected As Date
30: Dim datFirstDayToday As Date
		
35: datSelected = mvwSelection.Value
40: datToday = Today
45: datFirstDaySelected = GetFirstDay(datSelected)
50: datFirstDayToday = GetFirstDay(datToday)
		
55: If g_bPunchSemaineAnterieure = False Then
60: If datSelected <> datToday Then
65: If WeekDay(datToday, FirstDayOfWeek.Sunday) = FirstDayOfWeek.Sunday Or WeekDay(datToday, FirstDayOfWeek.Sunday) = FirstDayOfWeek.Monday Then
70: 'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
					If (datFirstDaySelected = datFirstDayToday) Or DateDiff(Microsoft.VisualBasic.DateInterval.Day, datFirstDaySelected, datFirstDayToday) = 7 Then
75: bModif = True
80: Else
85: bModif = False
90: End If
95: Else
100: If datFirstDaySelected = datFirstDayToday Then
105: bModif = True
110: End If
115: End If
120: Else
125: bModif = True
130: End If
135: Else
140: bModif = True
145: End If
		
150: If bModif = False Then
155: Call MsgBox("Impossible de modifier les punchs de cette journée!", MsgBoxStyle.OKOnly, "Erreur")
160: End If
		
165: VerifierModificationDate = bModif
		
170: Exit Function
		
AfficherErreur: 
		
175: Call AfficherErreur("frmPunch", "VerifierModificationDate", Err, Erl())
	End Function
	
	Public Sub Table_exist()
		
		Dim adoxconnection As ADOX.Catalog
		Dim i As Short
		adoxconnection = New ADOX.Catalog
		
		adoxconnection.let_ActiveConnection(g_connData)
		For i = 0 To adoxconnection.Tables.Count - 1
			If LCase(adoxconnection.Tables(i).Name) = LCase("TBL_Punch_Type") Then
				'UPGRADE_NOTE: Object adoxconnection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				adoxconnection = Nothing
				Exit Sub
			End If
		Next 
		Call g_connData.Execute("Create TABLE TBL_Punch_Type (Mode text(1), Name Text (100))")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('E','Dessin Électrique');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('E','Fabrication');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('E','Assemblage du Panneau');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('E','Programmation d''interface');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('E','Programmation d''automate');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('E','Programmation de Robot');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('E','Vision Artificielle');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('E','Test Finaux');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('E','Formation du personnel');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('E','Gestion du projet');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('E','Expédition');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('E','Prototypage-Dévelloppement expérimental');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('M','Conception et dessin');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('M','Coupe et préparation(sauf soudage)');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('M','Machinage');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('M','Coupe,Soudure et meulage');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('M','Assemblage des systèmes');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('M','Peinture et Finition');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('M','Test Finaux');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('M','Formation du personnel');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('M','Gestion du projet');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('M','Expédition');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('M','Prototypage-Dévelloppement expérimental');")
		Call g_connData.Execute("Insert into TBL_Punch_Type (mode, Name) Values ('S','Soumission');")
		'UPGRADE_NOTE: Object adoxconnection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		adoxconnection = Nothing
		
		
	End Sub
End Class