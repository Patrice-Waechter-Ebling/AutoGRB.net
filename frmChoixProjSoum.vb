Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmChoixProjSoum
	Inherits System.Windows.Forms.Form
	
	Public m_sUserID As String
	Public m_iNoGroupe As Short
	
	Private Sub cmdAchatElec_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAchatElec.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim objAchat As frmAchat
20: Dim bOuvert As Boolean
		
25: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
30: For iCompteur = 0 To My.Application.OpenForms.Count - 1
35: If My.Application.OpenForms.Item(iCompteur).Text = "Achat électrique" Then
40: bOuvert = True
				
45: Exit For
50: End If
55: Next 
		
60: If bOuvert = False Then
65: objAchat = New frmAchat
			
70: Call objAchat.Afficher(ModuleMain.enumCatalogue.ELECTRIQUE)
			
75: g_objAchatElec = objAchat
80: Else
85: My.Application.OpenForms.Item(iCompteur).WindowState = System.Windows.Forms.FormWindowState.Normal
			
90: 'UPGRADE_WARNING: Form method Forms.ZOrder has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			Call My.Application.OpenForms.Item(iCompteur).BringToFront()
			
95: Call Me.Close()
100: End If
		
105: Exit Sub
		
AfficherErreur: 
		
110: Call AfficherErreur("frmChoixProjSoum", "cmdAchatElec_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAchatMec_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAchatMec.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim objAchat As frmAchat
20: Dim bOuvert As Boolean
		
25: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
30: For iCompteur = 0 To My.Application.OpenForms.Count - 1
35: If My.Application.OpenForms.Item(iCompteur).Text = "Achat mécanique" Then
40: bOuvert = True
				
45: Exit For
50: End If
55: Next 
		
60: If bOuvert = False Then
65: objAchat = New frmAchat
			
70: Call objAchat.Afficher(ModuleMain.enumCatalogue.MECANIQUE)
			
75: g_objAchatMec = objAchat
80: Else
85: My.Application.OpenForms.Item(iCompteur).WindowState = System.Windows.Forms.FormWindowState.Normal
			
90: 'UPGRADE_WARNING: Form method Forms.ZOrder has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			Call My.Application.OpenForms.Item(iCompteur).BringToFront()
			
95: Call Me.Close()
100: End If
		
105: Exit Sub
		
AfficherErreur: 
		
110: Call AfficherErreur("frmChoixProjSoum", "cmdAchatMec_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixProjSoum", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub cmdProjSoumElec_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdProjSoumElec.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(FrmProjSoumElec, False)
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixProjSoum", "cmdProjSoumElec_Click", Err, Erl())
	End Sub
	
	Private Sub cmdProjSoumMec_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdProjSoumMec.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(FrmProjSoumMec, False)
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixProjSoum", "cmdProjSoumMec_Click", Err, Erl())
	End Sub
	
	Private Sub cmdReceptionElec_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdReceptionElec.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstGroupe As ADODB.Recordset
		
		'Il faut afficher le login pour faire la réception
15: Call frmLogin.Afficher(Me)
		
		'Si bon password
20: If g_bBonPasswd = True Then
25: g_bBonPasswd = False
			
30: rstGroupe = New ADODB.Recordset
			
35: Call rstGroupe.Open("SELECT ModificationReception FROM GRB_Groupes WHERE IDGroupe = " & m_iNoGroupe, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
40: If rstGroupe.Fields("ModificationReception").Value = True Then
				
				'Ouverture des réceptions
45: Call FrmReceptionElec.Afficher(m_sUserID)
				
50: Call rstGroupe.Close()
55: 'UPGRADE_NOTE: Object rstGroupe may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstGroupe = Nothing
				
60: Call Me.Close()
65: Else
70: Call MsgBox("Accès refusé!", MsgBoxStyle.OKOnly, "Erreur")
				
75: Call rstGroupe.Close()
80: 'UPGRADE_NOTE: Object rstGroupe may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstGroupe = Nothing
85: End If
90: End If
		
95: Exit Sub
		
AfficherErreur: 
		
100: Call AfficherErreur("frmChoixProjSoum", "cmdReceptionElec_Click", Err, Erl())
	End Sub
	
	Private Sub cmdReceptionMec_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdReceptionMec.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstGroupe As ADODB.Recordset
		
		'Il faut afficher le login pour faire la réception
15: Call frmLogin.Afficher(Me)
		
		'Si bon password
20: If g_bBonPasswd = True Then
25: g_bBonPasswd = False
			
30: rstGroupe = New ADODB.Recordset
			
35: Call rstGroupe.Open("SELECT ModificationReception FROM GRB_Groupes WHERE IDGroupe = " & m_iNoGroupe, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
40: If rstGroupe.Fields("ModificationReception").Value = True Then
				'Ouverture des réceptions
45: Call FrmReceptionMec.Afficher(m_sUserID)
				
50: Call rstGroupe.Close()
55: 'UPGRADE_NOTE: Object rstGroupe may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstGroupe = Nothing
				
60: Call Me.Close()
65: Else
70: Call MsgBox("Accès refusé!", MsgBoxStyle.OKOnly, "Erreur")
				
75: Call rstGroupe.Close()
80: 'UPGRADE_NOTE: Object rstGroupe may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstGroupe = Nothing
85: End If
90: End If
		
95: Exit Sub
		
AfficherErreur: 
		
100: Call AfficherErreur("frmChoixProjSoum", "cmdReceptionMec_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixProjSoum_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: lblExemple.Text = "Exemple : " & VB.Right(CStr(Year(Today)), 1) & "XYYY-ZZ"
		
15: lblAnnee.Text = VB.Right(CStr(Year(Today)), 1)
		
20: Call ActiverBoutonsGroupe()
		
25: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixProjSoum", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub ActiverBoutonsGroupe()
		
5: On Error GoTo AfficherErreur
		
10: If g_bAffichageSoumissionsMec = True Or g_bAffichageProjetsMec = True Then
15: cmdProjSoumMec.Enabled = True
20: Else
25: cmdProjSoumMec.Enabled = False
30: End If
		
35: If g_bAffichageSoumissionsElec = True Or g_bAffichageProjetsElec = True Then
40: cmdProjSoumElec.Enabled = True
45: Else
50: cmdProjSoumElec.Enabled = False
55: End If
		
60: If g_bAffichageAchats = True Then
65: cmdAchatElec.Enabled = True
70: cmdAchatMec.Enabled = True
75: Else
80: cmdAchatElec.Enabled = False
85: cmdAchatMec.Enabled = False
90: End If
		
95: If g_bModificationReception = True Then
100: cmdReceptionElec.Enabled = True
105: cmdReceptionMec.Enabled = True
110: Else
115: cmdReceptionElec.Enabled = False
120: cmdReceptionMec.Enabled = False
125: End If
		
130: Exit Sub
		
AfficherErreur: 
		
135: Call AfficherErreur("frmChoixProjSoum", "ActiverBoutonsGroupe", Err, Erl())
	End Sub
End Class