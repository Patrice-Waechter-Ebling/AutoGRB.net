Option Strict Off
Option Explicit On
Friend Class frmChoixImpressionInventaire
	Inherits System.Windows.Forms.Form
	
	Public Enum enumImpressionInventaire
		MODE_AJUST_INV = 0
		MODE_VAL_COMPTABLE = 1
	End Enum
	
	Private m_frmSource As System.Windows.Forms.Form
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_ISSUE: Control m_bAnnuleImpression could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
		m_frmSource.m_bAnnuleImpression = True
		
15: Call Me.Close()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmChoixImpressionInventaire", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdImprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImprimer.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_ISSUE: Control m_bAnnuleImpression could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
		m_frmSource.m_bAnnuleImpression = False
		
15: If optValeurComptable.Checked = True Then
20: 'UPGRADE_ISSUE: Control m_eTypeImpression could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
			m_frmSource.m_eTypeImpression = enumImpressionInventaire.MODE_VAL_COMPTABLE
25: Else
30: 'UPGRADE_ISSUE: Control m_eTypeImpression could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
			m_frmSource.m_eTypeImpression = enumImpressionInventaire.MODE_AJUST_INV
35: End If
		
40: Call Me.Close()
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmChoixImpressionInventaire", "cmdImprimer_Click", Err, Erl())
	End Sub
	
	Public Sub Afficher(ByVal frmSource As System.Windows.Forms.Form)
		
5: On Error GoTo AfficherErreur
		
10: m_frmSource = frmSource
		
15: Call Me.ShowDialog()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmChoixImpressionInventaire", "Afficher", Err, Erl())
	End Sub
	
	Private Sub frmChoixImpressionInventaire_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'UPGRADE_ISSUE: Control m_typeImpressionExel could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
		If m_frmSource.m_typeImpressionExel Then
			cmdImprimer.Text = "Exporter"
		Else
			cmdImprimer.Text = "Imprimer"
		End If
		
	End Sub
End Class