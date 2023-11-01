Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmLoginPrincipal
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmLoginPrincipal", "cmdCancel_Click", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmploye As ADODB.Recordset
		
		'Ouvre la table
15: rstEmploye = New ADODB.Recordset
		
20: Call rstEmploye.Open("SELECT * FROM GRB_Employés WHERE loginname = '" & txtlogin.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Si trouve utilisateur
25: If Not rstEmploye.EOF Then
			'si bon mot de passe, save user et quitte loggin
30: If UCase(rstEmploye.Fields("passwd").Value) = UCase(txtpasswd.Text) Then
35: Call SaveSetting("GRB", "Config", "LoginPrincipal", txtlogin.Text)
				
				'bon_passwd
40: g_bBonPasswd = True
				
				'UserID
45: g_sUserID = txtlogin.Text
				
				'Groupe de securité
50: g_iNoGroupe = rstEmploye.Fields("groupe").Value
				
				'Nom de l'employé
55: g_sEmploye = rstEmploye.Fields("employe").Value
				
60: Call InitialiserVariablesGroupe()
				
				'Initiale de l'employé
65: g_sInitiale = rstEmploye.Fields("initiale").Value
				
70: Call rstEmploye.Close()
75: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstEmploye = Nothing
				
80: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
				'Fermeture du login
85: Call Me.Close()
				
				'Ouverture de Dispatch
90: Call OuvrirForm(FrmDispatch, False)
95: Else
100: Call MsgBox("Mot de passe invalide!")
105: End If
110: Else
115: Call MsgBox("L'utilisateur n'existe pas!")
120: End If
		
		
125: Exit Sub
		
AfficherErreur: 
		
130: Call AfficherErreur("frmLoginPrincipal", "cmdOK_Click", Err, Erl())
		
	End Sub
	
	'UPGRADE_WARNING: Form event frmLoginPrincipal.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub frmLoginPrincipal_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
5: On Error GoTo AfficherErreur
		
10: If txtlogin.Text = "" Then
15: Call txtlogin.Focus()
20: Else
25: Call txtpasswd.Focus()
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmLoginPrincipal", "Form_Activate", Err, Erl())
	End Sub
	
	Private Sub frmLoginPrincipal_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Dim rstConfig As ADODB.Recordset
15: Dim sVersion As String
20: Dim sDerniereVersion As String
		
25: If OuvrirConnection = True Then
30: sVersion = My.Application.Info.Version.Major & "." & VB.Right("0" & My.Application.Info.Version.Minor, 2) & "." & VB.Right("0" & My.Application.Info.Version.Revision, 4)
			
35: rstConfig = New ADODB.Recordset
			
40: Call rstConfig.Open("SELECT DerniereVersion FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
45: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstConfig.Fields("DerniereVersion").Value) Then
50: If rstConfig.Fields("DerniereVersion").Value <> "" Then
55: sDerniereVersion = rstConfig.Fields("DerniereVersion").Value
60: Else
65: sDerniereVersion = ""
70: End If
75: Else
80: sDerniereVersion = ""
85: End If
			
90: Call rstConfig.Close()
95: 'UPGRADE_NOTE: Object rstConfig may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstConfig = Nothing
			
100: If sDerniereVersion <> sVersion Then
105: Call MsgBox("Votre version n'est pas à jour, elle sera installée!", MsgBoxStyle.OKOnly)
				
110: Call ShellExecute(Me.Handle.ToInt32, vbNullString, My.Application.Info.DirectoryPath & "\InstallGRB.exe", vbNullString, "C:\", SW_SHOWNORMAL)
				
115: Call FermerConnection()
				
120: End
125: End If
			
130: txtlogin.Text = GetSetting("GRB", "Config", "LoginPrincipal", "")
135: End If
		
140: Exit Sub
		
AfficherErreur: 
		
145: Call AfficherErreur("frmLoginPrincipal", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub txtlogin_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtlogin.Enter
		
5: On Error GoTo AfficherErreur
		
10: If txtlogin.Text <> "" Then
15: txtlogin.SelectionStart = 0
20: txtlogin.SelectionLength = Len(txtlogin.Text)
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmLoginPrincipal", "txtlogin_GotFocus", Err, Erl())
	End Sub
End Class