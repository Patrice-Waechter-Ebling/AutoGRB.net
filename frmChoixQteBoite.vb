Option Strict Off
Option Explicit On
Friend Class frmChoixQteBoite
	Inherits System.Windows.Forms.Form
	
	Public Sub Afficher(ByVal sNoPiece As String)
		
5: On Error GoTo AfficherErreur
		
10: lblQuestion.Text = "Quelle est la quantité par boîte pour la pièce " & sNoPiece & "?"
		
15: Call Me.ShowDialog()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmChoixQteBoite", "Afficher", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkQteBoite.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkQteBoite_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkQteBoite.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
10: If chkQteBoite.CheckState = System.Windows.Forms.CheckState.Checked Then
15: txtQteBoite.Enabled = True
20: Else
25: txtQteBoite.Text = ""
			
30: txtQteBoite.Enabled = False
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmChoixQteBoite", "chkQteBoite_Click", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
10: g_sQteBoite = txtQteBoite.Text
		
15: If chkQteBoite.CheckState = System.Windows.Forms.CheckState.Checked Then
20: g_bQteBoite = True
25: Else
30: g_bQteBoite = False
35: End If
		
40: Call Me.Close()
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmChoixQteBoite", "cmdOK_Click", Err, Erl())
	End Sub
	
	Private Sub txtQteBoite_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQteBoite.Leave
		
5: On Error GoTo AfficherErreur
		
10: If chkQteBoite.CheckState = System.Windows.Forms.CheckState.Checked Then
15: txtQteBoite.Text = Replace(txtQteBoite.Text, ".", ",")
			
20: If Not IsNumeric(txtQteBoite.Text) Or txtQteBoite.Text = "0" Then
25: txtQteBoite.Text = "0"
30: End If
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmChoixQteBoite", "txtQteBoite_LostFocus", Err, Erl())
	End Sub
End Class