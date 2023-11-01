Option Strict Off
Option Explicit On
Friend Class frmChoixCommentaire
	Inherits System.Windows.Forms.Form
	Public Sub Afficher(ByVal sNoProjSoum As String)
		
5: On Error GoTo AfficherErreur
		
10: lblNoProjSoum.Text = sNoProjSoum
		
15: Call RemplirTreeView()
		
20: Call Me.ShowDialog()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixCommentaire", "Afficher", Err, Erl())
	End Sub
	
	Private Sub RemplirTreeView()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstCommentaire As ADODB.Recordset
15: Dim itmCommentaire As System.Windows.Forms.TreeNode
		
20: Call tvwCommentaire.Nodes.Clear()
		
25: rstCommentaire = New ADODB.Recordset
		
30: Call rstCommentaire.Open("SELECT * FROM GRB_Commentaires WHERE NoProjSoum = '" & lblNoProjSoum.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
35: Do While Not rstCommentaire.EOF
40: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstCommentaire.Fields("Commentaire").Value) Then
45: If rstCommentaire.Fields("Section").Value = True Then
50: itmCommentaire = tvwCommentaire.Nodes.Add("KEY" & rstCommentaire.Fields("Key").Value, rstCommentaire.Fields("Commentaire").Value)
					
55: itmCommentaire.NodeFont = VB6.FontChangeBold(itmCommentaire.NodeFont, True)
60: Else
65: If rstCommentaire.Fields("SousSection").Value = True Then
70: 'UPGRADE_WARNING: Add method behavior has changed Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DBD08912-7C17-401D-9BE9-BA85E7772B99"'
						itmCommentaire = tvwCommentaire.Nodes.Find("KEY" & rstCommentaire.Fields("Relative").Value, True)(0).Nodes.Add("KEY" & rstCommentaire.Fields("Key").Value, rstCommentaire.Fields("Commentaire").Value)
						
75: itmCommentaire.NodeFont = VB6.FontChangeBold(itmCommentaire.NodeFont, True)
80: Else
85: 'UPGRADE_WARNING: Add method behavior has changed Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DBD08912-7C17-401D-9BE9-BA85E7772B99"'
						itmCommentaire = tvwCommentaire.Nodes.Find("KEY" & rstCommentaire.Fields("Relative").Value, True)(0).Nodes.Add(rstCommentaire.Fields("Commentaire").Value)
90: End If
95: End If
				
100: itmCommentaire.Tag = rstCommentaire.Fields("ID").Value
105: End If
			
110: Call rstCommentaire.MoveNext()
115: Loop 
		
120: Call rstCommentaire.Close()
125: 'UPGRADE_NOTE: Object rstCommentaire may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstCommentaire = Nothing
		
130: Exit Sub
		
AfficherErreur: 
		
135: Call AfficherErreur("frmChoixCommentaire", "RemplirTreeView", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim sCommentaire As String
15: Dim iCompteur As Short
20: Dim sSection As String
25: Dim nodComment As System.Windows.Forms.TreeNode
		
30: If tvwCommentaire.Nodes.Count > 0 Then
35: For iCompteur = 1 To tvwCommentaire.Nodes.Count
40: 'UPGRADE_WARNING: Lower bound of collection tvwCommentaire.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				nodComment = tvwCommentaire.Nodes.Item(iCompteur)
				
45: If nodComment.NodeFont.Bold = True Then
50: If CShort(Replace(nodComment.Name, "KEY", "")) > 100 Then
55: sSection = sSection & " / " & nodComment.Text
60: Else
65: sSection = nodComment.Text
70: End If
75: Else
80: If nodComment.Checked = True Then
85: If sCommentaire = "" Then
90: sCommentaire = sSection & " / " & nodComment.Text
95: Else
100: sCommentaire = sCommentaire & vbNewLine & sSection & " / " & nodComment.Text
105: End If
110: End If
115: End If
120: Next 
			
125: frmPunch.sCommentaire = sCommentaire
130: End If
		
135: Call Me.Close()
		
140: Exit Sub
		
AfficherErreur: 
		
145: Call AfficherErreur("frmChoixCommentaire", "cmdOK_Click", Err, Erl())
	End Sub
End Class