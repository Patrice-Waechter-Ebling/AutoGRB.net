Option Strict Off
Option Explicit On
Friend Class dlgDemandePrix
	Inherits System.Windows.Forms.Form
	
	Private m_objForm As System.Windows.Forms.Form
	
	Public Sub Afficher(ByVal objForm As System.Windows.Forms.Form)
		
5: On Error GoTo AfficherErreur
		
10: m_objForm = objForm
		
15: Call ShowDialog()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("dlgDemandePrix", "Afficher", Err, Erl())
	End Sub
	
	Private Sub cmdNouveau_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNouveau.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_ISSUE: Control m_eDemande could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
		m_objForm.m_eDemande = frmChoixDemande.enumModeDemande.MODE_NOUVELLE
		
15: 'UPGRADE_ISSUE: Control m_bDemandeAnnuler could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
		m_objForm.m_bDemandeAnnuler = False
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("dlgDemandePrix", "cmdNouveau_Click", Err, Erl())
	End Sub
	
	Private Sub cmdPiece_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPiece.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_ISSUE: Control m_eDemande could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
		m_objForm.m_eDemande = frmChoixDemande.enumModeDemande.MODE_PIECE
		
15: 'UPGRADE_ISSUE: Control m_bDemandeAnnuler could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
		m_objForm.m_bDemandeAnnuler = False
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("dlgDemandePrix", "cmdPiece_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFournisseur_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFournisseur.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_ISSUE: Control m_eDemande could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
		m_objForm.m_eDemande = frmChoixDemande.enumModeDemande.MODE_FOURNISSEUR
		
15: 'UPGRADE_ISSUE: Control m_bDemandeAnnuler could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
		m_objForm.m_bDemandeAnnuler = False
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("dlgDemandePrix", "cmdFournisseur_Click", Err, Erl())
	End Sub
	
	Private Sub cmdCategorie_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCategorie.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_ISSUE: Control m_eDemande could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
		m_objForm.m_eDemande = frmChoixDemande.enumModeDemande.MODE_CATEGORIE
		
15: 'UPGRADE_ISSUE: Control m_bDemandeAnnuler could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
		m_objForm.m_bDemandeAnnuler = False
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("dlgDemandePrix", "cmdCategorie_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_ISSUE: Control m_bDemandeAnnuler could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
		m_objForm.m_bDemandeAnnuler = True
		
15: Call Me.Close()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("dlgDemandePrix", "cmdAnnuler_Click", Err, Erl())
	End Sub
End Class