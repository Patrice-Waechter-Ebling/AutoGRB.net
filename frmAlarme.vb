Option Strict Off
Option Explicit On
Friend Class frmAlarme
	Inherits System.Windows.Forms.Form
	
	Private m_lIDAlarme As Integer
	
	'UPGRADE_WARNING: Event chkRemind.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkRemind_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkRemind.CheckStateChanged
		'Active ou désactive les champs
		
5: On Error GoTo AfficherErreur
		
10: Call ActiverChamps()
		
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmAlarme", "chkRemind_Click", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstAlarme As ADODB.Recordset
15: Dim sType As String
		
20: rstAlarme = New ADODB.Recordset
		
25: Call rstAlarme.Open("SELECT * FROM GRB_Alarmes WHERE IDAlarme = " & m_lIDAlarme, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
30: sType = rstAlarme.Fields("TypeCédule").Value
		
35: If chkRemind.CheckState = System.Windows.Forms.CheckState.Checked Then
40: If txtDate.Text <> "" Then
45: If mskHeure.Text <> "" Then
50: rstAlarme.Fields("Date").Value = txtDate.Text
55: rstAlarme.Fields("Heure").Value = mskHeure.Text
60: rstAlarme.Fields("JourSemaine").Value = WeekDay(CDate(txtDate.Text))
					
65: Call rstAlarme.Update()
70: Else
75: Call MsgBox("L'heure est invalide!", MsgBoxStyle.OKOnly, "Erreur")
80: End If
85: Else
90: Call MsgBox("La date est invalide!", MsgBoxStyle.OKOnly, "Erreur")
95: End If
100: Else
105: Call rstAlarme.Delete()
			
110: Call rstAlarme.Update()
115: End If
		
120: Call rstAlarme.Close()
125: 'UPGRADE_NOTE: Object rstAlarme may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAlarme = Nothing
		
130: If g_bCeduleOuverte = True Then
135: Call frmCédule.RemplirListerJour()
140: Call frmCédule.RemplirListerSemaine()
145: End If
		
150: Call Me.Close()
		
155: Exit Sub
		
AfficherErreur: 
		
160: Call AfficherErreur("frmAlarme", "cmdOK_Click", Err, Erl())
	End Sub
	
	Private Sub frmAlarme_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Click
		
5: On Error GoTo AfficherErreur
		
10: mvwDate.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmAlarme", "Form_Click", Err, Erl())
	End Sub
	
	Private Sub frmAlarme_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Call ActiverChamps()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmAlarme", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub ActiverChamps()
		'Active ou désactive les champs
		
5: On Error GoTo AfficherErreur
		
10: Dim bActif As Boolean
		
15: If chkRemind.CheckState = System.Windows.Forms.CheckState.Checked Then
20: bActif = True
25: Else
30: bActif = False
35: End If
		
40: txtDate.Enabled = bActif
45: mskHeure.Enabled = bActif
50: cmdDate.Enabled = bActif
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmAlarme", "ActiverChamps", Err, Erl())
	End Sub
	
	Private Sub mvwDate_DateClick(ByVal eventSender As System.Object, ByVal eventArgs As AxMSComCtl2.DMonthViewEvents_DateClickEvent) Handles mvwDate.DateClick
		
5: On Error GoTo AfficherErreur
		
10: txtDate.Text = ConvertDate(eventArgs.DateClicked)
		
15: mvwDate.Visible = False
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmAlarme", "mvwDate_DateClick", Err, Erl())
	End Sub
	
	Private Sub mvwDate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mvwDate.Leave
		
5: On Error GoTo AfficherErreur
		
10: mvwDate.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmAlarme", "mvwDate_LostFocus", Err, Erl())
	End Sub
	
	Public Sub Afficher(ByVal lIDAlarme As Integer)
		'Affichage de l'alarme
		
5: On Error GoTo AfficherErreur
		
10: Dim rstAlarme As ADODB.Recordset
		
15: rstAlarme = New ADODB.Recordset
		
20: m_lIDAlarme = lIDAlarme
		
		'Ouverture de la table
25: Call rstAlarme.Open("SELECT * FROM GRB_Alarmes WHERE IDAlarme = " & lIDAlarme, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
30: txtMessage.Text = rstAlarme.Fields("Message").Value
		
35: Call rstAlarme.Close()
40: 'UPGRADE_NOTE: Object rstAlarme may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAlarme = Nothing
		
45: Call Me.ShowDialog()
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmAlarme", "Afficher", Err, Erl())
	End Sub
	
	Private Sub mskHeure_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskHeure.Enter
		
5: On Error GoTo AfficherErreur
		
		'Format d'heure
10: mskHeure.Mask = "##:##"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmAlarme", "mskHeure_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskHeure_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskHeure.Leave
		
5: On Error GoTo AfficherErreur
		
		'Enlève le mask
10: mskHeure.Mask = vbNullString
		
		'Vide le champs si l'utilisateur n'a rien écrit
15: If mskHeure.Text = "__:__" Then
20: mskHeure.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmAlarme", "mskHeure_LostFocus", Err, Erl())
	End Sub
	
	Private Sub cmdDate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDate.Click
		
5: On Error GoTo AfficherErreur
		
		'Ouverture du calendrier
		
		'S'il y a une date, la date par défaut est celle-ci, sinon c'est la date
		'd'aujourd'hui
10: If Trim(txtDate.Text) <> vbNullString Then
15: mvwDate.Value = CDate(txtDate.Text)
20: Else
25: mvwDate.Value = Today
30: End If
		
35: mvwDate.Visible = True
		
40: Call mvwDate.Focus()
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmAlarme", "cmdDate_Click", Err, Erl())
	End Sub
End Class