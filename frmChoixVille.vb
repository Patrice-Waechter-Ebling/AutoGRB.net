Option Strict Off
Option Explicit On
Friend Class frmChoixVille
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: FrmClient.m_bAnnulerVille = True
15: FrmClient.m_sVille = ""
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixVille", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
10: FrmClient.m_bAnnulerVille = False
15: FrmClient.m_sVille = cmbVille.Text
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixVille", "cmdOK_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixVille_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Call RemplirComboVille()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixVille", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub RemplirComboVille()
		
5: On Error GoTo AfficherErreur
		
		'Remplir le combo des catégories
10: Dim rstVille As ADODB.Recordset
		
		'Il faut vider le combo avant de le remplir
15: Call cmbVille.Items.Clear()
		
20: rstVille = New ADODB.Recordset
		
25: Call rstVille.Open("SELECT DISTINCT VilleLiv FROM GRB_Client ORDER BY VilleLiv", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
50: Do While Not rstVille.EOF
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstVille.Fields("VilleLiv").Value) Then
60: If Trim(rstVille.Fields("VilleLiv").Value) <> "" Then
65: Call cmbVille.Items.Add(rstVille.Fields("VilleLiv").Value)
70: End If
75: End If
			
80: Call rstVille.MoveNext()
85: Loop 
		
90: Call rstVille.Close()
95: 'UPGRADE_NOTE: Object rstVille may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstVille = Nothing
		
		'Si le combo n'est pas vide, on sélectionne le premier
100: If cmbVille.Items.Count > 0 Then
105: cmbVille.SelectedIndex = 0
110: End If
		
115: Exit Sub
		
AfficherErreur: 
		
120: Call AfficherErreur("frmChoixVille", "RemplirComboVille", Err, Erl())
	End Sub
End Class