Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmLegende
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmLegende", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub frmLegende_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: shpOrange.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_ORANGE)
15: shpOrange.BorderColor = System.Drawing.ColorTranslator.FromOle(COLOR_ORANGE)
		
20: shpVert.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_VERT)
25: shpVert.BorderColor = System.Drawing.ColorTranslator.FromOle(COLOR_VERT)
		
30: shpMagenta.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_MAGENTA)
35: shpMagenta.BorderColor = System.Drawing.ColorTranslator.FromOle(COLOR_MAGENTA)
		
40: shpJaune.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_JAUNE)
45: shpJaune.BorderColor = System.Drawing.ColorTranslator.FromOle(COLOR_JAUNE)
		
50: shpGris.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_GRIS)
55: shpGris.BorderColor = System.Drawing.ColorTranslator.FromOle(COLOR_GRIS)
		
60: shpRed.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_ROUGE)
65: shpRed.BorderColor = System.Drawing.ColorTranslator.FromOle(COLOR_ROUGE)
		
70: shpVertForet.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_VERT_FORET)
75: shpVertForet.BorderColor = System.Drawing.ColorTranslator.FromOle(COLOR_VERT_FORET)
		
80: shpBleu.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_BLEU)
85: shpBleu.BorderColor = System.Drawing.ColorTranslator.FromOle(COLOR_BLEU)
		
90: shpRose.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_ROSE)
95: shpRose.BorderColor = System.Drawing.ColorTranslator.FromOle(COLOR_ROSE)
		
100: shpBrun.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_BRUN)
105: shpBrun.BorderColor = System.Drawing.ColorTranslator.FromOle(COLOR_BRUN)
		
110: Exit Sub
		
AfficherErreur: 
		
115: Call AfficherErreur("frmLegende", "Form_Load", Err, Erl())
	End Sub
End Class