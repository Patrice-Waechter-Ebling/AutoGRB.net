Option Strict Off
Option Explicit On
Friend Class frmChoixPunch
	Inherits System.Windows.Forms.Form
	
	Public m_sUserID As String 'Sert pour rechercher le userID de l'employé
	Public m_iNoGroupe As Short
	
	Private Sub cmdFeuilleTemps_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFeuilleTemps.Click
		
5: On Error GoTo AfficherErreur
		
		'Ouverture du form pour l'impression des feuilles de temps
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(frmFeuilleTemps, True)
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixPunch", "cmdFeuilleTemps_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFacturation_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFacturation.Click
		
5: On Error GoTo AfficherErreur
		
		'Ouverture du form pour la facturation des clients
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(frmFacturation, True)
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixPunch", "cmdFacturation_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
		'Fermeture de la fenêtre
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixPunch", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub ActiverBoutonsGroupe()
		
5: On Error GoTo AfficherErreur
		
		'Activation des boutons d'après le groupe
		'Bouton Punch
10: cmdPunch.Enabled = g_bAffichagePunch
		
		'Bouton "Facturation"
15: cmdFacturation.Enabled = g_bModificationFacturation
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmChoixPunch", "ActiverBoutonsGroupe", Err, Erl())
	End Sub
	
	Private Sub cmdPunch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPunch.Click
		
5: On Error GoTo AfficherErreur
		
		'Il faut afficher le login pour faire un punch in
10: Call frmLogin.Afficher(Me)
		
		'Si bon password
15: If g_bBonPasswd = True Then
20: g_bBonPasswd = False
			
			'Ouverture du punch
25: Call frmPunch.Afficher(m_sUserID)
			
30: Call Me.Close()
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmChoixPunch", "cmdPunch_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixPunch_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
		'Ouverture de la fenêtre
10: Call ActiverBoutonsGroupe()
		
15: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmChoixPunch", "Form_Load", Err, Erl())
	End Sub
End Class