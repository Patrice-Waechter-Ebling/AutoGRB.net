Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmChoixImpressionAchat
	Inherits System.Windows.Forms.Form
	
	Private Const I_CATEGORIE_MOIS As Short = 0
	Private Const I_CATEGORIE_80 As Short = 1
	Private Const I_CATEGORIE_83 As Short = 2
	Private Const I_CATEGORIE_85 As Short = 3
	Private Const I_CATEGORIE_95 As Short = 4
	Private Const I_CATEGORIE_97 As Short = 5
	Private Const I_CATEGORIE_98 As Short = 6
	Private Const I_CATEGORIE_99 As Short = 7
	
	Private Enum enumDate
		I_DATE_DEBUT = 0
		I_DATE_FIN = 1
	End Enum
	
	Private m_eDate As enumDate
	Private m_eCatalogue As ModuleMain.enumCatalogue
	Private m_iCategorie As Short
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixImpressionAchat", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDateDebut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDateDebut.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim bAfficherDate As Boolean
		
15: m_eDate = enumDate.I_DATE_DEBUT
		
20: If mskDateDebut.Text <> vbNullString Then
25: If InStr(1, mskDateDebut.Text, "_") = 0 Then
30: mvwDate.Year = CShort(VB.Left(mskDateDebut.Text, 4))
35: mvwDate.Month = CShort(Mid(mskDateDebut.Text, 6, 2))
40: mvwDate.Day = CShort(VB.Right(mskDateDebut.Text, 2))
45: Else
50: bAfficherDate = True
55: End If
60: Else
65: bAfficherDate = True
70: End If
		
75: If bAfficherDate = True Then
80: mvwDate.Year = Year(Today)
85: mvwDate.Month = Month(Today)
90: mvwDate.Day = VB.Day(Today)
95: End If
		
100: mvwDate.Visible = True
		
105: Call mvwDate.Focus()
		
110: Exit Sub
		
AfficherErreur: 
		
115: Call AfficherErreur("frmChoixImpressionAchat", "cmdDateDebut_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDateFin_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDateFin.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim bAfficherDate As Boolean
		
15: m_eDate = enumDate.I_DATE_FIN
		
20: If mskDateFin.Text <> vbNullString Then
25: If InStr(1, mskDateFin.Text, "_") = 0 Then
30: mvwDate.Year = CShort(VB.Left(mskDateDebut.Text, 4))
35: mvwDate.Month = CShort(Mid(mskDateDebut.Text, 6, 2))
40: mvwDate.Day = CShort(VB.Right(mskDateDebut.Text, 2))
45: Else
50: bAfficherDate = True
55: End If
60: Else
65: bAfficherDate = True
70: End If
		
75: If bAfficherDate = True Then
80: mvwDate.Year = Year(Today)
85: mvwDate.Month = Month(Today)
90: mvwDate.Day = VB.Day(Today)
95: End If
		
100: mvwDate.Visible = True
		
105: Call mvwDate.Focus()
		
110: Exit Sub
		
AfficherErreur: 
		
115: Call AfficherErreur("frmChoixImpressionAchat", "cmdDateFin_Click", Err, Erl())
	End Sub
	
	Private Sub cmdImprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImprimer.Click
		Dim DR_ListeAchats As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPiece As ADODB.Recordset
15: Dim rstTotal As ADODB.Recordset
20: Dim sSelect As String
25: Dim sFrom As String
30: Dim sWhere As String
35: Dim sNumeroDebut As String
40: Dim sNumeroFin As String
		
45: If Len(mskDateDebut.Text) <> 10 Or Len(mskDateFin.Text) <> 10 Then
50: Call MsgBox("Date invalide!", MsgBoxStyle.OKOnly, "Erreur")
			
55: Exit Sub
60: End If
		
65: Select Case m_eCatalogue
			Case ModuleMain.enumCatalogue.ELECTRIQUE
70: sNumeroDebut = "E" & Mid(mskDateDebut.Text, 4, 1) & "3000-"
75: sNumeroFin = "E" & Mid(mskDateFin.Text, 4, 1) & "3000-"
				
			Case ModuleMain.enumCatalogue.MECANIQUE
80: sNumeroDebut = "M" & Mid(mskDateDebut.Text, 4, 1) & "3000-"
85: sNumeroFin = "M" & Mid(mskDateFin.Text, 4, 1) & "3000-"
90: End Select
		
95: sSelect = "GRB_Achat.IDAchat, GRB_Achat.IndexAchat, GRB_Achat.Raison, " & "GRB_Achat.DateAchat, GRB_Employés.initiale, " & "GRB_Achat_Pieces.PIECE, GRB_Achat_Pieces.Qté, " & "GRB_Achat_Pieces.Desc_FR, GRB_Achat_Pieces.Manufact, " & "GRB_Achat_Pieces.Prix_list , GRB_Achat_Pieces.Escompte, " & "GRB_Achat_Pieces.Prix_net, GRB_Fournisseur.NomFournisseur, " & "GRB_Achat_Pieces.Prix_total"
		
100: sFrom = "GRB_Fournisseur INNER JOIN " & "(GRB_Employés INNER JOIN " & "(GRB_Achat INNER JOIN GRB_Achat_Pieces ON " & "(GRB_Achat.IndexAchat = GRB_Achat_Pieces.IndexAchat) " & "AND (GRB_Achat.IDAchat = GRB_Achat_Pieces.IDAchat)) " & "ON GRB_Employés.noEmploye = GRB_Achat.Acheteur) " & "ON GRB_Fournisseur.IDFRS = GRB_Achat_Pieces.IDFRS"
		
105: Select Case m_iCategorie
			Case I_CATEGORIE_MOIS
110: sWhere = "GRB_Achat.IDAchat BETWEEN '" & sNumeroDebut & Mid(mskDateDebut.Text, 6, 2) & "' AND '" & sNumeroFin & Mid(mskDateFin.Text, 6, 2) & "' AND DateAchat BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'"
				
			Case I_CATEGORIE_80
115: sWhere = "GRB_Achat.IDAchat BETWEEN '" & sNumeroDebut & "80' AND '" & sNumeroFin & "80' AND DateAchat BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'"
				
			Case I_CATEGORIE_83
120: sWhere = "GRB_Achat.IDAchat BETWEEN '" & sNumeroDebut & "83' AND '" & sNumeroFin & "83' AND DateAchat BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'"
				
			Case I_CATEGORIE_85
125: sWhere = "GRB_Achat.IDAchat BETWEEN '" & sNumeroDebut & "85' AND '" & sNumeroFin & "85' AND DateAchat BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'"
				
			Case I_CATEGORIE_95
130: sWhere = "GRB_Achat.IDAchat BETWEEN '" & sNumeroDebut & "95' AND '" & sNumeroFin & "95' AND DateAchat BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'"
				
			Case I_CATEGORIE_97
135: sWhere = "GRB_Achat.IDAchat BETWEEN '" & sNumeroDebut & "97' AND '" & sNumeroFin & "97' AND DateAchat BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'"
				
			Case I_CATEGORIE_98
140: sWhere = "GRB_Achat.IDAchat BETWEEN '" & sNumeroDebut & "98' AND '" & sNumeroFin & "98' AND DateAchat BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'"
				
			Case I_CATEGORIE_99
145: sWhere = "GRB_Achat.IDAchat BETWEEN '" & sNumeroDebut & "99' AND '" & sNumeroFin & "99' AND DateAchat BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'"
150: End Select
		
155: rstTotal = New ADODB.Recordset
160: rstPiece = New ADODB.Recordset
		
165: Call rstTotal.Open("SELECT SUM(Prix_total) As PrixTotal FROM GRB_Achat_Pieces INNER JOIN GRB_Achat ON (GRB_Achat.IDAchat = GRB_Achat_Pieces.IDAchat) AND (GRB_Achat.IndexAchat = GRB_Achat_Pieces.IndexAchat) WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
170: Call rstPiece.Open("SELECT " & sSelect & " FROM " & sFrom & " WHERE " & sWhere & " ORDER BY GRB_Achat.IndexAchat, PIECE", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
175: If rstPiece.EOF = True Then
180: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			
185: Call MsgBox("Aucun achat à imprimer!", MsgBoxStyle.OKOnly, "Erreur")
			
190: Call rstTotal.Close()
195: 'UPGRADE_NOTE: Object rstTotal may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstTotal = Nothing
			
200: Call rstPiece.Close()
205: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstPiece = Nothing
			
210: Exit Sub
215: End If
		
220: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ListeAchats.Orientation = MSDataReportLib.OrientationConstants.rptOrientLandscape
		
225: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ListeAchats.DataSource = rstPiece
		
230: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ListeAchats.Sections("Section5").Controls("lblTotal").Caption = Conversion_Renamed(Replace(rstTotal.Fields("PrixTotal").Value, ".", ","), ModuleMain.enumConvert.MODE_ARGENT)
		
235: Call rstTotal.Close()
240: 'UPGRADE_NOTE: Object rstTotal may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstTotal = Nothing
		
245: Select Case m_iCategorie
			Case I_CATEGORIE_MOIS
250: If Mid(mskDateDebut.Text, 6, 2) = Mid(mskDateFin.Text, 6, 2) And VB.Left(mskDateDebut.Text, 4) = VB.Left(mskDateFin.Text, 4) Then
255: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ListeAchats.Sections("Section4").Controls("lblNumero").Caption = sNumeroDebut & Mid(mskDateDebut.Text, 6, 2)
260: Else
265: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ListeAchats.Sections("Section4").Controls("lblNumero").Caption = sNumeroDebut & Mid(mskDateDebut.Text, 6, 2) & " à " & sNumeroFin & Mid(mskDateFin.Text, 6, 2)
270: End If
				
			Case I_CATEGORIE_80
275: If VB.Left(mskDateDebut.Text, 4) = VB.Left(mskDateFin.Text, 4) Then
280: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ListeAchats.Sections("Section4").Controls("lblNumero").Caption = sNumeroDebut & "80"
285: Else
290: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ListeAchats.Sections("Section4").Controls("lblNumero").Caption = sNumeroDebut & "80 à " & sNumeroFin & "80"
295: End If
				
300: Case I_CATEGORIE_83
305: If VB.Left(mskDateDebut.Text, 4) = VB.Left(mskDateFin.Text, 4) Then
310: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ListeAchats.Sections("Section4").Controls("lblNumero").Caption = sNumeroDebut & "83"
315: Else
320: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ListeAchats.Sections("Section4").Controls("lblNumero").Caption = sNumeroDebut & "83 à " & sNumeroFin & "83"
325: End If
				
			Case I_CATEGORIE_85
330: If VB.Left(mskDateDebut.Text, 4) = VB.Left(mskDateFin.Text, 4) Then
335: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ListeAchats.Sections("Section4").Controls("lblNumero").Caption = sNumeroDebut & "85"
340: Else
345: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ListeAchats.Sections("Section4").Controls("lblNumero").Caption = sNumeroDebut & "85 à " & sNumeroFin & "85"
350: End If
				
			Case I_CATEGORIE_95
355: If VB.Left(mskDateDebut.Text, 4) = VB.Left(mskDateFin.Text, 4) Then
360: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ListeAchats.Sections("Section4").Controls("lblNumero").Caption = sNumeroDebut & "95"
365: Else
370: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ListeAchats.Sections("Section4").Controls("lblNumero").Caption = sNumeroDebut & "95 à " & sNumeroFin & "95"
375: End If
				
			Case I_CATEGORIE_97
380: If VB.Left(mskDateDebut.Text, 4) = VB.Left(mskDateFin.Text, 4) Then
385: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ListeAchats.Sections("Section4").Controls("lblNumero").Caption = sNumeroDebut & "97"
390: Else
395: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ListeAchats.Sections("Section4").Controls("lblNumero").Caption = sNumeroDebut & "97 à " & sNumeroFin & "97"
400: End If
				
			Case I_CATEGORIE_98
405: If VB.Left(mskDateDebut.Text, 4) = VB.Left(mskDateFin.Text, 4) Then
410: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ListeAchats.Sections("Section4").Controls("lblNumero").Caption = sNumeroDebut & "98"
415: Else
420: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ListeAchats.Sections("Section4").Controls("lblNumero").Caption = sNumeroDebut & "98 à " & sNumeroFin & "98"
425: End If
				
			Case I_CATEGORIE_99
430: If VB.Left(mskDateDebut.Text, 4) = VB.Left(mskDateFin.Text, 4) Then
435: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ListeAchats.Sections("Section4").Controls("lblNumero").Caption = sNumeroDebut & "99"
440: Else
445: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_ListeAchats.Sections("Section4").Controls("lblNumero").Caption = sNumeroDebut & "99 à " & sNumeroFin & "99"
450: End If
455: End Select
		
460: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ListeAchats.Sections("Section4").Controls("lblDate").Caption = "Du " & mskDateDebut.Text & " Au " & mskDateFin.Text
		
465: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_ListeAchats.Sections("Section3").Controls("lblDateImpression").Caption = ConvertDate(Today)
		
470: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_ListeAchats.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_ListeAchats.Show(VB6.FormShowConstants.Modal)
		
475: Call rstPiece.Close()
480: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
485: Call Me.Close()
		
490: Exit Sub
		
AfficherErreur: 
		
495: Call AfficherErreur("frmChoixImpressionAchat", "cmdImprimer_Click", Err, Erl())
	End Sub
	
	Public Sub Afficher(ByVal eCatalogue As ModuleMain.enumCatalogue)
		
5: On Error GoTo AfficherErreur
		
10: optCategorie(I_CATEGORIE_MOIS).Checked = True
		
15: m_eCatalogue = eCatalogue
		
20: Call Me.ShowDialog()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixImpressionAchat", "Afficher", Err, Erl())
	End Sub
	
	Private Sub mskDateDebut_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateDebut.Enter
		
5: On Error GoTo AfficherErreur
		
		'Met l'année sur 2 chiffres
10: If Len(mskDateDebut.Text) = 10 Then
15: mskDateDebut.Text = VB.Right(mskDateDebut.Text, 8)
20: End If
		
25: mskDateDebut.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixImpressionAchat", "mskDateDebut_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateFin_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateFin.Enter
		
5: On Error GoTo AfficherErreur
		
		'Met l'année sur 2 chiffres
10: If Len(mskDateFin.Text) = 10 Then
15: mskDateFin.Text = VB.Right(mskDateFin.Text, 8)
20: End If
		
25: mskDateFin.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixImpressionAchat", "mskDateFin_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateDebut_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateDebut.Leave
		
5: On Error GoTo AfficherErreur
		
10: Dim sDate As String
		
		'Enlève le mask
15: mskDateDebut.Mask = vbNullString
		
20: sDate = mskDateDebut.Text
		
		'Vide le champs si l'utilisateur n'a rien écrit
25: If sDate = "__-__-__" Then
30: mskDateDebut.Text = vbNullString
35: Else
			'Remet l'année sur 8 chiffres
40: If Len(sDate) = 8 Then
45: If IsDate(sDate) Then
50: mskDateDebut.Text = Year(DateSerial(CInt(VB.Left(sDate, 2)), CInt(Mid(sDate, 4, 2)), CInt(VB.Right(sDate, 2)))) & Mid(sDate, 3, 8)
55: End If
60: End If
65: End If
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmChoixImpressionAchat", "mskDateDebut_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateFin_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateFin.Leave
		
5: On Error GoTo AfficherErreur
		
10: Dim sDate As String
		
		'Enlève le mask
15: mskDateFin.Mask = vbNullString
		
20: sDate = mskDateFin.Text
		
		'Vide le champs si l'utilisateur n'a rien écrit
25: If sDate = "__-__-__" Then
30: mskDateFin.Text = vbNullString
35: Else
			'Remet l'année sur 8 chiffres
40: If Len(sDate) = 8 Then
45: If IsDate(sDate) Then
50: mskDateFin.Text = Year(DateSerial(CInt(VB.Left(sDate, 2)), CInt(Mid(sDate, 4, 2)), CInt(VB.Right(sDate, 2)))) & Mid(sDate, 3, 8)
55: End If
60: End If
65: End If
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmChoixImpressionAchat", "mskDateFin_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mvwDate_DateClick(ByVal eventSender As System.Object, ByVal eventArgs As AxMSComCtl2.DMonthViewEvents_DateClickEvent) Handles mvwDate.DateClick
		
5: On Error GoTo AfficherErreur
		
10: Select Case m_eDate
			Case enumDate.I_DATE_DEBUT : mskDateDebut.Text = ConvertDate(eventArgs.DateClicked)
			Case enumDate.I_DATE_FIN : mskDateFin.Text = ConvertDate(eventArgs.DateClicked)
15: End Select
		
20: mvwDate.Visible = False
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixImpressionAchat", "mvwDate_DateClick", Err, Erl())
	End Sub
	
	Private Sub mvwDate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mvwDate.Leave
		
5: On Error GoTo AfficherErreur
		
10: mvwDate.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixImpressionAchat", "mvwDate_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event optCategorie.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optCategorie_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optCategorie.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = optCategorie.GetIndex(eventSender)
			
5: On Error GoTo AfficherErreur
			
10: m_iCategorie = Index
			
15: Exit Sub
			
AfficherErreur: 
			
20: Call AfficherErreur("frmChoixImpressionAchat", "optCategorie_Click", Err, Erl())
		End If
	End Sub
End Class