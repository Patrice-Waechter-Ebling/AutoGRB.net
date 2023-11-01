Option Strict Off
Option Explicit On
Friend Class frmLogin
	Inherits System.Windows.Forms.Form
	
	Private m_frmSource As System.Windows.Forms.Form
	
	Private Sub cmdcancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdcancel.Click
		
5: On Error GoTo AfficherErreur
		
10: g_bBonPasswd = False
		
		'ferme le login
15: Call Me.Close()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmLogin", "cmdcancel_Click", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmploye As ADODB.Recordset
		
		'Ouverture de la table
15: rstEmploye = New ADODB.Recordset
		
20: Call rstEmploye.Open("SELECT * FROM GRB_employés WHERE loginname = '" & txtlogin.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Si trouve utilisateur
25: If Not rstEmploye.EOF Then
			'si bon mot de passe, save user et quitte loggin
30: If UCase(rstEmploye.Fields("passwd").Value) = UCase(txtpasswd.Text) Then
35: g_bBonPasswd = True
				
40: Call SaveSetting("GRB", "Config", "LoginPunch", txtlogin.Text)
				
45: 'UPGRADE_ISSUE: Control m_iNoGroupe could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
				m_frmSource.m_iNoGroupe = rstEmploye.Fields("Groupe").Value
				
50: 'UPGRADE_ISSUE: Control m_sUserID could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
				m_frmSource.m_sUserID = txtlogin.Text
				
55: Call Me.Close()
60: Else
65: Call MsgBox("Mot de passe invalide!")
70: End If
75: Else
80: Call MsgBox("L'utilisateur n'existe pas!")
85: End If
		
90: Call rstEmploye.Close()
95: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmLogin", "cmdOK_Click", Err, Erl())
	End Sub
	
	Public Sub Afficher(ByVal frmSource As System.Windows.Forms.Form)
		
5: On Error GoTo AfficherErreur
		
10: m_frmSource = frmSource
		
15: Call Me.ShowDialog()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmLogin", "Afficher", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Form event frmLogin.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub frmLogin_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
5: On Error GoTo AfficherErreur
		
10: If txtlogin.Text = "" Then
15: Call txtlogin.Focus()
20: Else
25: Call txtpasswd.Focus()
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmLogin", "Form_Activate", Err, Erl())
	End Sub
	
	Private Sub frmLogin_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: txtlogin.Text = GetSetting("GRB", "Config", "LoginPunch", "")
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmLogin", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub txtlogin_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtlogin.Enter
		
5: On Error GoTo AfficherErreur
		
10: If txtlogin.Text <> "" Then
15: txtlogin.SelectionStart = 0
20: txtlogin.SelectionLength = Len(txtlogin.Text)
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmLogin", "txtlogin_GotFocus", Err, Erl())
	End Sub
End Class