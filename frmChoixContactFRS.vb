Option Strict Off
Option Explicit On
Friend Class frmChoixContactFRS
	Inherits System.Windows.Forms.Form
	
	Private m_iNoFRS As Short
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: frmChoixDemande.m_bAnnulerContact = True
		
15: Call Me.Close()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmChoixContactFRS", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
10: frmChoixDemande.m_bAnnulerContact = False
		
15: frmChoixDemande.m_sContact = cmbContactFRS.Text
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixContactFRS", "cmdOK_Click", Err, Erl())
	End Sub
	
	Private Sub RemplirComboContactFRS()
		
5: On Error GoTo AfficherErreur
		
		'Remplir le combo des contacts
10: Dim rstContactFRS As ADODB.Recordset
15: Dim rstContact As ADODB.Recordset
		
		'Il faut vider le combo avant de le remplir
20: Call cmbContactFRS.Items.Clear()
		
25: rstContactFRS = New ADODB.Recordset
30: rstContact = New ADODB.Recordset
		
35: Call rstContactFRS.Open("SELECT * FROM GRB_ContactFRS WHERE NoFRS = " & m_iNoFRS, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
40: Do While Not rstContactFRS.EOF
45: Call rstContact.Open("SELECT * FROM GRB_Contact WHERE IDContact = " & rstContactFRS.Fields("NoContact").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
50: If Not rstContact.EOF Then
55: Call cmbContactFRS.Items.Add(rstContact.Fields("NomContact").Value)
60: End If
			
65: Call rstContact.Close()
			
70: Call rstContactFRS.MoveNext()
75: Loop 
		
80: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
85: Call rstContactFRS.Close()
90: 'UPGRADE_NOTE: Object rstContactFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContactFRS = Nothing
		
95: Exit Sub
		
AfficherErreur: 
		
100: Call AfficherErreur("frmChoixContactFRS", "RemplirComboContactFRS", Err, Erl())
	End Sub
	
	Public Sub Afficher(ByVal iNoFRS As Short)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstFRS As ADODB.Recordset
		
15: rstFRS = New ADODB.Recordset
		
20: Call rstFRS.Open("SELECT * FROM GRB_Fournisseur WHERE IDFRS = " & iNoFRS, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: lblQuestion.Text = "Qui est le contact pour " & Replace(rstFRS.Fields("NomFournisseur").Value, "&", "&&") & "?"
		
30: Call rstFRS.Close()
35: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
		
40: m_iNoFRS = iNoFRS
		
45: Call RemplirComboContactFRS()
		
50: Call Me.ShowDialog()
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmChoixContactFRS", "Form_Load", Err, Erl())
	End Sub
End Class