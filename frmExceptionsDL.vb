Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmExceptionsDL
	Inherits System.Windows.Forms.Form
	Private Sub cmdAjouter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAjouter.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim sAdresse As String
15: Dim rstExceptions As ADODB.Recordset
		
20: sAdresse = InputBox("Quel est l'adresse à ajouter ?")
		
25: 'UPGRADE_ISSUE: StrPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		If StrPtr(sAdresse) <> 0 Then
30: If ValiderAdresse(sAdresse) = True Then
35: rstExceptions = New ADODB.Recordset
				
40: Call rstExceptions.Open("SELECT * FROM GRB_ExceptionsDL WHERE [Exception] = '" & Replace(sAdresse, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
45: If rstExceptions.EOF Then
50: Call rstExceptions.AddNew()
					
55: rstExceptions.Fields("Exception").Value = sAdresse
					
60: Call rstExceptions.Update()
					
65: Call RemplirListBoxExceptions()
70: Else
75: Call MsgBox("Ce courriel est déjà dans la liste!", MsgBoxStyle.OKOnly, "Erreur")
80: End If
				
85: Call rstExceptions.Close()
90: 'UPGRADE_NOTE: Object rstExceptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstExceptions = Nothing
95: Else
100: Call MsgBox("Adresse invalide!", MsgBoxStyle.OKOnly, "Erreur")
105: End If
110: End If
		
115: Exit Sub
		
AfficherErreur: 
		
120: Call AfficherErreur("frmExceptionsDL", "cmdAjouter_Click", Err, Erl())
	End Sub
	
	Private Function ValiderAdresse(ByVal sAdresse As String) As Boolean
		
5: On Error GoTo AfficherErreur
		
10: Dim bValide As Boolean
		
15: bValide = True
		
20: If Len(sAdresse) < 5 Then
25: bValide = False
30: End If
		
35: If bValide = True Then
40: If InStr(1, sAdresse, "@") = 0 Then
45: bValide = False
50: End If
55: End If
		
60: If bValide = True Then
65: If InStr(InStr(1, sAdresse, "@") + 1, sAdresse, ".") = 0 Then
70: bValide = False
75: End If
80: End If
		
85: If bValide = True Then
90: If VB.Left(sAdresse, 1) = "@" Then
95: bValide = False
100: End If
105: End If
		
110: If bValide = True Then
115: If VB.Right(sAdresse, 1) = "." Then
120: bValide = False
125: End If
130: End If
		
135: ValiderAdresse = bValide
		
		
140: Exit Function
		
AfficherErreur: 
		
145: Call AfficherErreur("frmExceptionsDL", "ValiderAdresse", Err, Erl())
	End Function
	
	
	Private Sub cmdSupprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSupprimer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call SupprimerCourriel()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmExceptionsDL", "cmdSupprimer_Click", Err, Erl())
	End Sub
	
	Private Sub SupprimerCourriel()
		
5: On Error GoTo AfficherErreur
		
10: If lvwExceptions.Items.Count > 0 Then
15: If MsgBox("Voulez-vous vraiment effacer l'adresse " & lvwExceptions.FocusedItem.Text & " ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
20: Call g_connData.Execute("DELETE * FROM GRB_ExceptionsDL WHERE ID = " & lvwExceptions.FocusedItem.Tag)
				
25: Call RemplirListBoxExceptions()
30: End If
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmExceptionsDL", "SupprimerCourriel", Err, Erl())
	End Sub
	
	Private Sub frmExceptionsDL_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Call RemplirListBoxExceptions()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmExceptionsDL", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub RemplirListBoxExceptions()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstExceptions As ADODB.Recordset
15: Dim itmException As System.Windows.Forms.ListViewItem
		
20: Call lvwExceptions.Items.Clear()
		
25: rstExceptions = New ADODB.Recordset
		
30: Call rstExceptions.Open("SELECT * FROM GRB_ExceptionsDL ORDER BY [Exception]", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
35: Do While Not rstExceptions.EOF
40: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwExceptions.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmException = lvwExceptions.Items.Add()
			
45: itmException.Text = rstExceptions.Fields("Exception").Value
50: itmException.Tag = rstExceptions.Fields("ID").Value
			
55: Call rstExceptions.MoveNext()
60: Loop 
		
65: Call rstExceptions.Close()
70: 'UPGRADE_NOTE: Object rstExceptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstExceptions = Nothing
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmExceptionsDL", "RemplirListBoxExceptions", Err, Erl())
	End Sub
	
	Private Sub lvwExceptions_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lvwExceptions.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: If KeyCode = System.Windows.Forms.Keys.Delete Then
15: Call SupprimerCourriel()
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmExceptionsDL", "lvwExceptions_KeyDown", Err, Erl())
	End Sub
End Class