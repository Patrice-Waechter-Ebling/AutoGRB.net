Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmCommentairesProjSoum
	Inherits System.Windows.Forms.Form
	
	Public Sub Afficher(ByVal sNoProjSoum As String, ByVal bProjet As Boolean)
		
5: On Error GoTo AfficherErreur
		
10: If bProjet = True Then
15: lblTitreNoProjSoum.Text = "# Projet : "
20: Else
25: lblTitreNoProjSoum.Text = "# Soumission : "
30: End If
		
35: lblNoProjSoum.Text = sNoProjSoum
		
40: Call RemplirTreeView()
		
45: Call Me.ShowDialog()
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmCommentairesProjSoum", "Afficher", Err, Erl())
	End Sub
	
	Private Sub cmdAjouter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAjouter.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstCommentaire As ADODB.Recordset
15: Dim arr_sLigne() As String
20: Dim sLigne As String
25: Dim iKeySection As Short
30: Dim iKeySousSection As Short
35: Dim iCompteur As Short
40: Dim bSousSection As Boolean
		
45: If Trim(txtAjout.Text) <> "" Then
50: If tvwCommentaire.Nodes.Count = 0 Then
55: If VB.Left(Trim(txtAjout.Text), 1) = "-" And VB.Left(Trim(txtAjout.Text), 2) <> "--" Then
60: rstCommentaire = New ADODB.Recordset
					
65: Call rstCommentaire.Open("SELECT * FROM GRB_Commentaires WHERE NoProjSoum = '" & lblNoProjSoum.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
70: arr_sLigne = Split(txtAjout.Text, vbCrLf)
					
75: For iCompteur = 0 To UBound(arr_sLigne)
80: sLigne = Trim(arr_sLigne(iCompteur))
						
85: If sLigne <> "" Then
90: Call rstCommentaire.AddNew()
							
95: rstCommentaire.Fields("NoProjSoum").Value = lblNoProjSoum.Text
100: rstCommentaire.Fields("Index").Value = iCompteur
							
105: If VB.Left(sLigne, 2) = "--" Then
110: bSousSection = True
								
115: rstCommentaire.Fields("SousSection").Value = True
								
120: rstCommentaire.Fields("Relative").Value = iKeySection
								
125: iKeySousSection = iKeySousSection + 1
								
130: rstCommentaire.Fields("Key").Value = iKeySousSection
								
135: rstCommentaire.Fields("Commentaire").Value = VB.Right(sLigne, Len(sLigne) - 2)
140: Else
145: If VB.Left(sLigne, 1) = "-" Then
150: rstCommentaire.Fields("Section").Value = True
									
155: iKeySection = iKeySection + 1
									
160: iKeySousSection = iKeySection * 100
									
165: bSousSection = False
									
170: rstCommentaire.Fields("Key").Value = iKeySection
									
175: rstCommentaire.Fields("Commentaire").Value = VB.Right(sLigne, Len(sLigne) - 1)
180: Else
185: If bSousSection = True Then
190: rstCommentaire.Fields("Relative").Value = iKeySousSection
195: Else
200: rstCommentaire.Fields("Relative").Value = iKeySection
205: End If
									
210: rstCommentaire.Fields("Commentaire").Value = sLigne
215: End If
220: End If
							
225: Call rstCommentaire.Update()
230: End If
235: Next 
					
240: Call rstCommentaire.Close()
245: 'UPGRADE_NOTE: Object rstCommentaire may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstCommentaire = Nothing
					
250: Call RemplirTreeView()
255: Else
260: Call MsgBox("La première ligne doit absolument être une section!", MsgBoxStyle.OKOnly, "Erreur")
265: End If
270: Else
275: Call MsgBox("Impossible d'ajouter les commentaires, la liste doit être vide!", MsgBoxStyle.OKOnly, "Erreur")
280: End If
285: Else
290: Call MsgBox("Rien à ajouter!", MsgBoxStyle.OKOnly, "Erreur")
295: End If
		
300: Exit Sub
		
AfficherErreur: 
		
305: Call AfficherErreur("frmCommentairesProjSoum", "cmdAjouter_Click", Err, Erl())
	End Sub
	
	Private Sub cmdCopier_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCopier.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim nodComment As System.Windows.Forms.TreeNode
		
20: If tvwCommentaire.Nodes.Count > 0 Then
25: txtAjout.Text = ""
			
30: For iCompteur = 1 To tvwCommentaire.Nodes.Count
35: 'UPGRADE_WARNING: Lower bound of collection tvwCommentaire.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				nodComment = tvwCommentaire.Nodes.Item(iCompteur)
				
40: If nodComment.NodeFont.Bold = True Then
45: If txtAjout.Text = "" Then
50: txtAjout.Text = "-" & nodComment.Text
55: Else
60: txtAjout.Text = txtAjout.Text & vbNewLine & "-" & nodComment.Text
65: End If
70: Else
75: If txtAjout.Text = "" Then
80: txtAjout.Text = nodComment.Text
85: Else
90: txtAjout.Text = txtAjout.Text & vbNewLine & nodComment.Text
95: End If
100: End If
105: Next 
110: End If
		
115: Exit Sub
		
AfficherErreur: 
		
120: Call AfficherErreur("frmCommentairesProjSoum", "cmdCopier_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmCommentairesProjSoum", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub cmdSupprimerTout_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSupprimerTout.Click
		
5: On Error GoTo AfficherErreur
		
10: If tvwCommentaire.Nodes.Count > 0 Then
15: If MsgBox("Voulez-vous vraiment effacer tous les commentaires?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
20: Call g_connData.Execute("DELETE * FROM GRB_Commentaires WHERE NoProjSoum = '" & lblNoProjSoum.Text & "'")
				
25: Call tvwCommentaire.Nodes.Clear()
30: End If
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmCommentairesProjSoum", "cmdSupprimerTout_Click", Err, Erl())
	End Sub
	
	Private Sub cmdVider_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVider.Click
		
5: On Error GoTo AfficherErreur
		
10: txtAjout.Text = ""
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmCommentairesProjSoum", "cmdVider_Click", Err, Erl())
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
		
135: Call AfficherErreur("frmCommentairesProjSoum", "RemplirTreeView", Err, Erl())
	End Sub
End Class