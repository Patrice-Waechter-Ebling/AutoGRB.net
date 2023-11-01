Option Strict Off
Option Explicit On
Friend Class dlgImpressionClient
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdFacturer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFacturer.Click
		
5: On Error GoTo AfficherErreur
		
10: FrmClient.m_bImpressionVille = False
15: FrmClient.m_bImpressionAnnuler = False
20: FrmClient.m_bImpressionCategorie = False
25: FrmClient.m_bImpressionPotentiel = False
30: FrmClient.m_bImpressionFacturer = True
		
35: Call Me.Close()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("dlgImpressionClient", "cmdVille_Click", Err, Erl())
	End Sub
	
	Private Sub cmdPotentiel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPotentiel.Click
		
5: On Error GoTo AfficherErreur
		
10: FrmClient.m_bImpressionVille = False
15: FrmClient.m_bImpressionAnnuler = False
20: FrmClient.m_bImpressionCategorie = False
25: FrmClient.m_bImpressionPotentiel = True
30: FrmClient.m_bImpressionFacturer = False
		
35: Call Me.Close()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("dlgImpressionClient", "cmdVille_Click", Err, Erl())
	End Sub
	
	Private Sub cmdVille_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVille.Click
		
5: On Error GoTo AfficherErreur
		
10: FrmClient.m_bImpressionVille = True
15: FrmClient.m_bImpressionAnnuler = False
20: FrmClient.m_bImpressionCategorie = False
25: FrmClient.m_bImpressionPotentiel = False
30: FrmClient.m_bImpressionFacturer = False
		
35: Call Me.Close()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("dlgImpressionClient", "cmdVille_Click", Err, Erl())
	End Sub
	
	Private Sub cmdTous_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTous.Click
		
5: On Error GoTo AfficherErreur
		
10: FrmClient.m_bImpressionAnnuler = False
15: FrmClient.m_bImpressionVille = False
20: FrmClient.m_bImpressionCategorie = False
25: FrmClient.m_bImpressionPotentiel = False
30: FrmClient.m_bImpressionFacturer = False
		
35: Call Me.Close()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("dlgImpressionClient", "cmdTous_Click", Err, Erl())
	End Sub
	
	Private Sub cmdCategorie_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCategorie.Click
		
5: On Error GoTo AfficherErreur
		
10: FrmClient.m_bImpressionCategorie = True
15: FrmClient.m_bImpressionAnnuler = False
20: FrmClient.m_bImpressionVille = False
25: FrmClient.m_bImpressionPotentiel = False
30: FrmClient.m_bImpressionFacturer = False
		
35: Call Me.Close()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("dlgImpressionClient", "cmdCategorie_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: FrmClient.m_bImpressionAnnuler = True
15: FrmClient.m_bImpressionCategorie = False
20: FrmClient.m_bImpressionVille = False
25: FrmClient.m_bImpressionPotentiel = False
30: FrmClient.m_bImpressionFacturer = False
		
35: Call Me.Close()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("dlgImpressionClient", "cmdAnnuler_Click", Err, Erl())
	End Sub
End Class