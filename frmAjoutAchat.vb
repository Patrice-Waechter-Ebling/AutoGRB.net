Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmAjoutAchat
	Inherits System.Windows.Forms.Form
	
	Private m_objAchat As frmAchat
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: m_objAchat.m_sNoAchat = vbNullString
		
15: m_objAchat.m_bAnnuler = True
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmAjoutAchat", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iNo As Short
		
15: If txtNo.Text = vbNullString Then
20: Call MsgBox("Le numéro est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
			
25: Exit Sub
30: Else
35: If Len(txtNo.Text) = 1 Then
40: Call MsgBox("Le numéro doit absolument avoir 2 chiffres!", MsgBoxStyle.OKOnly, "Erreur")
				
45: Exit Sub
50: End If
55: End If
		
60: If IsNumeric(txtNo.Text) Then
65: iNo = CShort(txtNo.Text)
70: Else
75: Call MsgBox("Numéro non numérique!", MsgBoxStyle.OKOnly, "Erreur")
			
80: Exit Sub
85: End If
		
90: If iNo <= 12 And iNo >= 1 Then
95: If iNo <> Month(Today) Then
100: Call MsgBox("Mois invalide!", MsgBoxStyle.OKOnly, "Erreur")
				
105: Exit Sub
110: End If
115: Else
120: If iNo <> 60 And iNo <> 76 And iNo <> 80 And iNo <> 82 And iNo <> 83 And iNo <> 85 And iNo <> 95 And iNo <> 97 And iNo <> 98 And iNo <> 99 Then
125: Call MsgBox("Numéro invalide!", MsgBoxStyle.OKOnly, "Erreur")
				
130: Exit Sub
135: End If
140: End If
		
145: m_objAchat.m_sNoAchat = Replace(lblNo.Text, " ", vbNullString) & txtNo.Text
		
150: m_objAchat.m_bAnnuler = False
		
155: Call Me.Close()
		
160: Exit Sub
		
AfficherErreur: 
		
165: Call AfficherErreur("frmAjoutAchat", "cmdOK_Click", Err, Erl())
	End Sub
	
	Public Sub Afficher(ByVal eCatalogue As ModuleMain.enumCatalogue)
		
5: On Error GoTo AfficherErreur
		
10: If eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
15: lblNo.Text = "E" & VB.Right(CStr(Year(Today)), 1) & "3000  -  "
			
20: m_objAchat = g_objAchatElec
25: Else
30: lblNo.Text = "M" & VB.Right(CStr(Year(Today)), 1) & "3000 - "
			
35: m_objAchat = g_objAchatMec
40: End If
		
45: Call Me.ShowDialog()
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmAjoutAchat", "Afficher", Err, Erl())
	End Sub
End Class