Option Strict Off
Option Explicit On
Friend Class frmChoixClient
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
10: If cmbclient.SelectedIndex <> -1 Then
15: If Trim(txtDescription.Text) <> vbNullString Then
20: frmFacturation.m_iIDClient = VB6.GetItemData(cmbclient, cmbclient.SelectedIndex)
25: frmFacturation.m_sDescription = txtDescription.Text
				
30: Call Me.Close()
35: Else
40: Call MsgBox("La description est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
45: End If
50: Else
55: Call MsgBox("Le client est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
60: End If
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmChoixClient", "cmdOK_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRafraichir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRafraichir.Click
		
5: On Error GoTo AfficherErreur
		
10: Call RemplirComboClient(vbNullString)
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixClient", "cmdRafraichir_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRecherche_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRecherche.Click
		
5: On Error GoTo AfficherErreur
		
10: Call RemplirComboClient(txtRecherche.Text)
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixClient", "cmdRecherche_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixClient_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim sIDClient As String
		
20: Call RemplirComboClient(vbNullString)
		
25: If frmFacturation.m_bModifClient = True Then
30: sIDClient = frmFacturation.txtClient.Tag
			
35: For iCompteur = 0 To cmbclient.Items.Count - 1
40: If VB6.GetItemData(cmbclient, iCompteur) = CDbl(sIDClient) Then
45: cmbclient.SelectedIndex = iCompteur
					
50: Exit For
55: End If
60: Next 
			
65: txtDescription.Text = frmFacturation.txtDescription.Text
70: End If
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmChoixClient", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub RemplirComboClient(ByVal sRecherche As String)
		
5: On Error GoTo AfficherErreur
		
		'Remplir le combo des clients
10: Dim rstClient As ADODB.Recordset
		
		'Il faut vider le combo avant de le remplir
15: Call cmbclient.Items.Clear()
		
20: rstClient = New ADODB.Recordset
		
25: If Trim(sRecherche) = vbNullString Then
30: Call rstClient.Open("SELECT NomClient, IDClient FROM GRB_Client WHERE Supprimé = False ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
35: Else
40: If InStr(1, sRecherche, "'") > 0 Then
45: Call rstClient.Open("SELECT NomClient, IDClient FROM GRB_Client WHERE NomClient LIKE '%" & Replace(sRecherche, "'", "''") & "%' AND Supprimé = False ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
50: Else
55: Call rstClient.Open("SELECT NomClient, IDClient FROM GRB_Client WHERE INSTR(1, NomClient, '" & sRecherche & "') > 0 AND Supprimé = False ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
60: End If
65: End If
		
		'Tant que ce n'est pas la fin des enregistrements
70: Do While Not rstClient.EOF
75: Call cmbclient.Items.Add(rstClient.Fields("NomClient").Value)
			
80: 'UPGRADE_ISSUE: ComboBox property cmbclient.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbclient, cmbclient.NewIndex, rstClient.Fields("IDClient").Value)
			
85: Call rstClient.MoveNext()
90: Loop 
		
95: Call rstClient.Close()
100: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient = Nothing
		
		'Si le combo n'est pas vide, on sélectionne le premier
105: If cmbclient.Items.Count > 0 Then
110: cmbclient.SelectedIndex = 0
115: End If
		
120: Exit Sub
		
AfficherErreur: 
		
125: Call AfficherErreur("frmChoixClient", "RemplirComboClient", Err, Erl())
	End Sub
End Class