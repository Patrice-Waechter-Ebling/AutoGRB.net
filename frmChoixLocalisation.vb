Option Strict Off
Option Explicit On
Friend Class frmChoixLocalisation
	Inherits System.Windows.Forms.Form
	
	Private m_eCatalogue As ModuleMain.enumCatalogue
	
	Public Sub Afficher(ByVal eCatalogue As ModuleMain.enumCatalogue, ByVal sNoPiece As String)
		
5: On Error GoTo AfficherErreur
		
10: m_eCatalogue = eCatalogue
		
15: lblQuestion.Text = "Quelle est la localisation de la pièce " & sNoPiece & "?"
		
20: Call RemplirComboLocalisation()
		
25: Call Me.ShowDialog()
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixLocalisation", "Afficher", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
10: g_sLocalisation = cmbLocalisation.Text
		
15: Call Me.Close()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmChoixLocalisation", "cmdOK_Click", Err, Erl())
	End Sub
	
	Private Sub RemplirComboLocalisation()
		
5: On Error GoTo AfficherErreur
		
		'Remplir le combo des localisations
10: Dim rstInv As ADODB.Recordset
		
		'Il faut vider le combo avant de le remplir
15: Call cmbLocalisation.Items.Clear()
		
20: Call cmbLocalisation.Items.Add("")
		
25: rstInv = New ADODB.Recordset
		
30: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
35: Call rstInv.Open("SELECT DISTINCT Localisation FROM GRB_InventaireElec", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
40: Else
45: Call rstInv.Open("SELECT DISTINCT Localisation FROM GRB_InventaireMec", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
50: End If
		
		'Tant que ce n'est pas la fin des enregistrements
55: Do While Not rstInv.EOF
60: If Trim(rstInv.Fields("Localisation").Value) <> "" Then
65: Call cmbLocalisation.Items.Add(rstInv.Fields("Localisation").Value)
70: End If
			
75: Call rstInv.MoveNext()
80: Loop 
		
85: Call rstInv.Close()
90: 'UPGRADE_NOTE: Object rstInv may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstInv = Nothing
		
95: Exit Sub
		
AfficherErreur: 
		
100: Call AfficherErreur("frmChoixLocalisation", "RemplirComboContactFRS", Err, Erl())
	End Sub
End Class