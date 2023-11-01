Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmPhotoProjSoum
	Inherits System.Windows.Forms.Form
	
	Private Enum enumDeplacement
		I_AUCUN = 0
		I_PRECEDENT = 1
		I_SUIVANT = 2
	End Enum
	
	Private m_iIndexPhoto As Short
	
	Public Sub Afficher(ByVal sRepertoire As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim fso As Scripting.FileSystemObject
		
15: fso = CreateObject("Scripting.FileSystemObject")
		
20: If fso.FolderExists(sRepertoire) = True Then
25: filPhotos.Path = sRepertoire
			
30: m_iIndexPhoto = 0
			
35: Call AfficherPhoto(enumDeplacement.I_AUCUN)
			
40: Call Me.ShowDialog()
45: Else
50: Call MsgBox("Accès refusé!")
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmPhotoProjSoum", "Afficher", Err, Erl())
	End Sub
	
	Private Sub AfficherPhoto(ByVal eDeplacement As enumDeplacement)
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim sFile As String
		
20: Dim counter As Short
		Select Case eDeplacement
			Case enumDeplacement.I_AUCUN
25: counter = m_iIndexPhoto
				For iCompteur = counter To filPhotos.Items.Count - 1
30: sFile = filPhotos.Items(iCompteur)
					
35: If UCase(VB.Right(sFile, 3)) = "JPG" Or UCase(VB.Right(sFile, 3)) = "BMP" Then
40: imgProjSoum.Image = System.Drawing.Image.FromFile(filPhotos.Path & "\" & sFile)
						
45: m_iIndexPhoto = iCompteur
						
50: Exit For
55: Else
60: Call MsgBox("Le fichier " & sFile & " n'est pas un fichier valide!", MsgBoxStyle.OKOnly, "Erreur")
65: End If
70: Next 
				
			Case enumDeplacement.I_SUIVANT
75: For iCompteur = m_iIndexPhoto + 1 To filPhotos.Items.Count - 1
80: sFile = filPhotos.Items(iCompteur)
					
85: If UCase(VB.Right(sFile, 3)) = "JPG" Or UCase(VB.Right(sFile, 3)) = "BMP" Then
90: imgProjSoum.Image = System.Drawing.Image.FromFile(filPhotos.Path & "\" & sFile)
						
95: m_iIndexPhoto = iCompteur
						
100: Exit For
105: Else
110: Call MsgBox("Le fichier " & sFile & " n'est pas un fichier valide!", MsgBoxStyle.OKOnly, "Erreur")
115: End If
120: Next 
				
			Case enumDeplacement.I_PRECEDENT
125: If m_iIndexPhoto > 0 Then
130: For iCompteur = m_iIndexPhoto - 1 To 0 Step -1
135: sFile = filPhotos.Items(iCompteur)
						
140: If UCase(VB.Right(sFile, 3)) = "JPG" Or UCase(VB.Right(sFile, 3)) = "BMP" Then
145: imgProjSoum.Image = System.Drawing.Image.FromFile(filPhotos.Path & "\" & sFile)
							
150: m_iIndexPhoto = iCompteur
							
155: Exit For
160: Else
165: Call MsgBox("Le fichier " & sFile & " n'est pas un fichier valide!", MsgBoxStyle.OKOnly, "Erreur")
170: End If
175: Next 
180: End If
185: End Select
		
190: If m_iIndexPhoto = filPhotos.Items.Count - 1 Then
195: cmdSuivant.Enabled = False
200: Else
205: cmdSuivant.Enabled = True
210: End If
		
215: If m_iIndexPhoto = 0 Then
220: cmdPrécédent.Enabled = False
225: Else
230: cmdPrécédent.Enabled = True
235: End If
		
240: Exit Sub
		
AfficherErreur: 
		
245: Call AfficherErreur("frmPhotoProjSoum", "AfficherPhoto", Err, Erl())
	End Sub
	
	Private Sub cmdPrécédent_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrécédent.Click
		
5: On Error GoTo AfficherErreur
		
10: Call AfficherPhoto(enumDeplacement.I_PRECEDENT)
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmPhotoProjSoum", "cmdPrécédent_Click", Err, Erl())
	End Sub
	
	Private Sub cmdSuivant_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSuivant.Click
		
5: On Error GoTo AfficherErreur
		
10: Call AfficherPhoto(enumDeplacement.I_SUIVANT)
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmPhotoProjSoum", "cmdSuivant_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmPhotoProjSoum", "cmdFermer_Click", Err, Erl())
	End Sub
End Class