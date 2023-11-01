Option Strict Off
Option Explicit On
Friend Class frmCategorieClient
	Inherits System.Windows.Forms.Form
	Private Enum enumTypeOuverture
		CLIENT = 0
		IMPRESSION = 1
	End Enum
	
	Private m_eOuverture As enumTypeOuverture
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
10: If m_eOuverture = enumTypeOuverture.CLIENT Then
15: If chkBeton.CheckState = System.Windows.Forms.CheckState.Checked Then
20: FrmClient.m_bCategorieBeton = True
25: Else
30: FrmClient.m_bCategorieBeton = False
35: End If
			
40: If chkPave.CheckState = System.Windows.Forms.CheckState.Checked Then
45: FrmClient.m_bCategoriePave = True
50: Else
55: FrmClient.m_bCategoriePave = False
60: End If
			
65: If chkPharmaceutique.CheckState = System.Windows.Forms.CheckState.Checked Then
70: FrmClient.m_bCategoriePharmaceutique = True
75: Else
80: FrmClient.m_bCategoriePharmaceutique = False
85: End If
			
90: If chkAgroalimentaire.CheckState = System.Windows.Forms.CheckState.Checked Then
95: FrmClient.m_bCategorieAgroalimentaire = True
100: Else
105: FrmClient.m_bCategorieAgroalimentaire = False
110: End If
			
115: If chkMeuble.CheckState = System.Windows.Forms.CheckState.Checked Then
120: FrmClient.m_bCategorieMeuble = True
125: Else
130: FrmClient.m_bCategorieMeuble = False
135: End If
			
140: If chkMeunerie.CheckState = System.Windows.Forms.CheckState.Checked Then
145: FrmClient.m_bCategorieMeunerie = True
150: Else
155: FrmClient.m_bCategorieMeunerie = False
160: End If
			
165: If chkManufacturier.CheckState = System.Windows.Forms.CheckState.Checked Then
170: FrmClient.m_bCategorieManufacturier = True
175: Else
180: FrmClient.m_bCategorieManufacturier = False
185: End If
			
190: If chkConsultant.CheckState = System.Windows.Forms.CheckState.Checked Then
195: FrmClient.m_bCategorieConsultant = True
200: Else
205: FrmClient.m_bCategorieConsultant = False
210: End If
			
215: If chkAsphalte.CheckState = System.Windows.Forms.CheckState.Checked Then
220: FrmClient.m_bCategorieAsphalte = True
225: Else
230: FrmClient.m_bCategorieAsphalte = False
235: End If
			
240: If chkICPI.CheckState = System.Windows.Forms.CheckState.Checked Then
245: FrmClient.m_bCategorieICPI = True
250: Else
255: FrmClient.m_bCategorieICPI = False
260: End If
			
265: If chkProduitsChimiques.CheckState = System.Windows.Forms.CheckState.Checked Then
270: FrmClient.m_bCategorieProduitsChimiques = True
275: Else
280: FrmClient.m_bCategorieProduitsChimiques = False
285: End If
			
290: If chkAutre.CheckState = System.Windows.Forms.CheckState.Checked Then
295: FrmClient.m_bCategorieAutre = True
300: Else
305: FrmClient.m_bCategorieAutre = False
310: End If
315: Else
320: If chkBeton.CheckState = System.Windows.Forms.CheckState.Checked Then
325: FrmClient.m_bImpressionBeton = True
330: Else
335: FrmClient.m_bImpressionBeton = False
340: End If
			
345: If chkPave.CheckState = System.Windows.Forms.CheckState.Checked Then
350: FrmClient.m_bImpressionPave = True
355: Else
360: FrmClient.m_bImpressionPave = False
365: End If
			
370: If chkPharmaceutique.CheckState = System.Windows.Forms.CheckState.Checked Then
375: FrmClient.m_bImpressionPharmaceutique = True
380: Else
385: FrmClient.m_bImpressionPharmaceutique = False
390: End If
			
395: If chkAgroalimentaire.CheckState = System.Windows.Forms.CheckState.Checked Then
400: FrmClient.m_bImpressionAgroAlimentaire = True
405: Else
410: FrmClient.m_bImpressionAgroAlimentaire = False
415: End If
			
420: If chkMeuble.CheckState = System.Windows.Forms.CheckState.Checked Then
425: FrmClient.m_bImpressionMeuble = True
430: Else
435: FrmClient.m_bImpressionMeuble = False
440: End If
			
445: If chkMeunerie.CheckState = System.Windows.Forms.CheckState.Checked Then
450: FrmClient.m_bImpressionMeunerie = True
455: Else
460: FrmClient.m_bImpressionMeunerie = False
465: End If
			
470: If chkManufacturier.CheckState = System.Windows.Forms.CheckState.Checked Then
475: FrmClient.m_bImpressionManufacturier = True
480: Else
485: FrmClient.m_bImpressionManufacturier = False
490: End If
			
495: If chkConsultant.CheckState = System.Windows.Forms.CheckState.Checked Then
500: FrmClient.m_bImpressionConsultant = True
505: Else
510: FrmClient.m_bImpressionConsultant = False
515: End If
			
520: If chkAsphalte.CheckState = System.Windows.Forms.CheckState.Checked Then
525: FrmClient.m_bImpressionAsphalte = True
530: Else
535: FrmClient.m_bImpressionAsphalte = False
540: End If
			
545: If chkICPI.CheckState = System.Windows.Forms.CheckState.Checked Then
550: FrmClient.m_bImpressionICPI = True
555: Else
560: FrmClient.m_bImpressionICPI = False
565: End If
			
570: If chkProduitsChimiques.CheckState = System.Windows.Forms.CheckState.Checked Then
575: FrmClient.m_bImpressionProduitsChimiques = True
580: Else
585: FrmClient.m_bImpressionProduitsChimiques = False
590: End If
			
595: If chkAutre.CheckState = System.Windows.Forms.CheckState.Checked Then
600: FrmClient.m_bImpressionAutre = True
605: Else
610: FrmClient.m_bImpressionAutre = False
615: End If
620: End If
		
625: Call Me.Close()
		
630: Exit Sub
		
AfficherErreur: 
		
635: Call AfficherErreur("frmCategorieClient", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Public Sub AfficherClient()
		
5: On Error GoTo AfficherErreur
		
10: cmdFermer.Text = "Fermer"
		
15: If FrmClient.m_bCategorieBeton = True Then
20: chkBeton.CheckState = System.Windows.Forms.CheckState.Checked
25: Else
30: chkBeton.CheckState = System.Windows.Forms.CheckState.Unchecked
35: End If
		
40: If FrmClient.m_bCategoriePave = True Then
45: chkPave.CheckState = System.Windows.Forms.CheckState.Checked
50: Else
55: chkPave.CheckState = System.Windows.Forms.CheckState.Unchecked
60: End If
		
65: If FrmClient.m_bCategoriePharmaceutique = True Then
70: chkPharmaceutique.CheckState = System.Windows.Forms.CheckState.Checked
75: Else
80: chkPharmaceutique.CheckState = System.Windows.Forms.CheckState.Unchecked
85: End If
		
90: If FrmClient.m_bCategorieAgroalimentaire = True Then
95: chkAgroalimentaire.CheckState = System.Windows.Forms.CheckState.Checked
100: Else
105: chkAgroalimentaire.CheckState = System.Windows.Forms.CheckState.Unchecked
110: End If
		
115: If FrmClient.m_bCategorieMeuble = True Then
120: chkMeuble.CheckState = System.Windows.Forms.CheckState.Checked
125: Else
130: chkMeuble.CheckState = System.Windows.Forms.CheckState.Unchecked
135: End If
		
140: If FrmClient.m_bCategorieMeunerie = True Then
145: chkMeunerie.CheckState = System.Windows.Forms.CheckState.Checked
150: Else
155: chkMeunerie.CheckState = System.Windows.Forms.CheckState.Unchecked
160: End If
		
165: If FrmClient.m_bCategorieManufacturier = True Then
170: chkManufacturier.CheckState = System.Windows.Forms.CheckState.Checked
175: Else
180: chkManufacturier.CheckState = System.Windows.Forms.CheckState.Unchecked
185: End If
		
190: If FrmClient.m_bCategorieConsultant = True Then
195: chkConsultant.CheckState = System.Windows.Forms.CheckState.Checked
200: Else
205: chkConsultant.CheckState = System.Windows.Forms.CheckState.Unchecked
210: End If
		
215: If FrmClient.m_bCategorieAsphalte = True Then
220: chkAsphalte.CheckState = System.Windows.Forms.CheckState.Checked
225: Else
230: chkAsphalte.CheckState = System.Windows.Forms.CheckState.Unchecked
235: End If
		
240: If FrmClient.m_bCategorieICPI = True Then
245: chkICPI.CheckState = System.Windows.Forms.CheckState.Checked
250: Else
255: chkICPI.CheckState = System.Windows.Forms.CheckState.Unchecked
260: End If
		
265: If FrmClient.m_bCategorieProduitsChimiques = True Then
270: chkProduitsChimiques.CheckState = System.Windows.Forms.CheckState.Checked
275: Else
280: chkProduitsChimiques.CheckState = System.Windows.Forms.CheckState.Unchecked
285: End If
		
290: If FrmClient.m_bCategorieAutre = True Then
295: chkAutre.CheckState = System.Windows.Forms.CheckState.Checked
300: Else
305: chkAutre.CheckState = System.Windows.Forms.CheckState.Unchecked
310: End If
		
315: m_eOuverture = enumTypeOuverture.CLIENT
		
320: Call Me.ShowDialog()
		
325: Exit Sub
		
AfficherErreur: 
		
330: Call AfficherErreur("frmCategorieClient", "AfficherClient", Err, Erl())
	End Sub
	
	Public Sub AfficherImpression()
		
5: On Error GoTo AfficherErreur
		
10: cmdFermer.Text = "Imprimer"
		
15: chkBeton.CheckState = System.Windows.Forms.CheckState.Unchecked
20: chkPave.CheckState = System.Windows.Forms.CheckState.Unchecked
25: chkPharmaceutique.CheckState = System.Windows.Forms.CheckState.Unchecked
30: chkAgroalimentaire.CheckState = System.Windows.Forms.CheckState.Unchecked
35: chkMeuble.CheckState = System.Windows.Forms.CheckState.Unchecked
40: chkMeunerie.CheckState = System.Windows.Forms.CheckState.Unchecked
45: chkManufacturier.CheckState = System.Windows.Forms.CheckState.Unchecked
50: chkConsultant.CheckState = System.Windows.Forms.CheckState.Unchecked
55: chkAsphalte.CheckState = System.Windows.Forms.CheckState.Unchecked
60: chkICPI.CheckState = System.Windows.Forms.CheckState.Unchecked
65: chkProduitsChimiques.CheckState = System.Windows.Forms.CheckState.Unchecked
70: chkAutre.CheckState = System.Windows.Forms.CheckState.Unchecked
		
75: m_eOuverture = enumTypeOuverture.IMPRESSION
		
80: Call Me.ShowDialog()
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("frmCategorieClient", "AfficherImpression", Err, Erl())
	End Sub
End Class