Option Strict Off
Option Explicit On
Friend Class frmChoixImpressionRetourMarchandise
	Inherits System.Windows.Forms.Form
	
	Public Enum enumImpressionRetour
		MODE_DEMANDE_RETOUR = 0
		MODE_RETOUR = 1
	End Enum
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: frmRetourMarchandise.m_bAnnuleImpression = True
		
15: Call Me.Close()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmChoixImpressionRetourMarchandise", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdImprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImprimer.Click
		
5: On Error GoTo AfficherErreur
		
10: frmRetourMarchandise.m_bAnnuleImpression = False
		
15: If optRetour.Checked = True Then
20: frmRetourMarchandise.m_eTypeImpression = enumImpressionRetour.MODE_RETOUR
25: Else
30: frmRetourMarchandise.m_eTypeImpression = enumImpressionRetour.MODE_DEMANDE_RETOUR
35: End If
		
40: Call Me.Close()
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmChoixImpressionRetourMarchandise", "cmdImprimer_Click", Err, Erl())
	End Sub
End Class