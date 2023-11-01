Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmChoixDateImpressionFT
	Inherits System.Windows.Forms.Form
	
	Private Enum enumDate
		AUCUNE = 0
		DEBUT = 1
		Fin = 2
	End Enum
	
	Private m_eDate As enumDate
	Private m_xlsApp As Excel.Application
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDateImpressionFT", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdexporter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdexporter.Click
		
5: On Error GoTo AfficherErreur
		
10: If Len(mskDateDebut.Text) = 8 Then
15: Call mskDateDebut_Leave(mskDateDebut, New System.EventArgs())
20: End If
		
25: If Len(mskDateFin.Text) = 8 Then
30: Call mskDateFin_Leave(mskDateFin, New System.EventArgs())
35: End If
		
40: If ValiderDate(mskDateDebut.Text) = False Then
45: Call MsgBox("Date de début invalide!", MsgBoxStyle.OKOnly, "Erreur")
			
50: Exit Sub
55: End If
		
60: If ValiderDate(mskDateFin.Text) = False Then
65: Call MsgBox("Date de fin invalide!", MsgBoxStyle.OKOnly, "Erreur")
			
70: Exit Sub
75: End If
		
80: If mskDateFin.Text < mskDateDebut.Text Then
85: Call MsgBox("La date de fin doit être plus grande que la date de début!", MsgBoxStyle.OKOnly, "Erreur")
			
90: Exit Sub
95: End If
		
100: Call ExporterPunch()
		
105: Call Me.Close()
		
110: Exit Sub
		
AfficherErreur: 
		
115: Call AfficherErreur("frmChoixDateImpressionFT", "cmdExporter_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixDateImpressionFT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Click
		
5: On Error GoTo AfficherErreur
		
10: mvwDate.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDateImpressionFT", "Form_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixDateImpressionFT_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: m_eDate = enumDate.AUCUNE
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDateImpressionFT", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub mvwDate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mvwDate.Leave
		
5: On Error GoTo AfficherErreur
		
10: mvwDate.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDateImpressionFT", "mvwDate_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mvwDate_DateClick(ByVal eventSender As System.Object, ByVal eventArgs As AxMSComCtl2.DMonthViewEvents_DateClickEvent) Handles mvwDate.DateClick
		
5: On Error GoTo AfficherErreur
		
10: Select Case m_eDate
			Case enumDate.DEBUT : mskDateDebut.Text = ConvertDate(eventArgs.DateClicked)
			Case enumDate.Fin : mskDateFin.Text = ConvertDate(eventArgs.DateClicked)
15: End Select
		
20: m_eDate = enumDate.AUCUNE
		
		'Enlever le calendrier
25: mvwDate.Visible = False
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixDateImpressionFT", "mvwDate_DateClick", Err, Erl())
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
		
35: Call AfficherErreur("frmChoixDateImpressionFT", "mskDateDebut_GotFocus", Err, Erl())
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
		
35: Call AfficherErreur("frmChoixDateImpressionFT", "mskDateFin_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateDebut_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateDebut.Leave
		
5: On Error GoTo AfficherErreur
		
		'Enlève le mask
10: mskDateDebut.Mask = vbNullString
		
		'Vide le champs si l'utilisateur n'a rien écrit
15: If mskDateDebut.Text = "__-__-__" Then
20: mskDateDebut.Text = vbNullString
25: Else
			'Remet l'année sur 8 chiffres
30: If Len(mskDateDebut.Text) = 8 Then
35: If IsDate(mskDateDebut.Text) Then
40: mskDateDebut.Text = Year(DateSerial(CInt(VB.Left(mskDateDebut.Text, 2)), CInt(Mid(mskDateDebut.Text, 4, 2)), CInt(VB.Right(mskDateDebut.Text, 2)))) & Mid(mskDateDebut.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmChoixDateImpressionFT", "mskDateDebut_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateFin_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateFin.Leave
		
5: On Error GoTo AfficherErreur
		
		'Enlève le mask
10: mskDateFin.Mask = vbNullString
		
		'Vide le champs si l'utilisateur n'a rien écrit
15: If mskDateFin.Text = "__-__-__" Then
20: mskDateFin.Text = vbNullString
25: Else
			'Remet l'année sur 8 chiffres
30: If Len(mskDateFin.Text) = 8 Then
35: If IsDate(mskDateFin.Text) Then
40: mskDateFin.Text = Year(DateSerial(CInt(VB.Left(mskDateFin.Text, 2)), CInt(Mid(mskDateFin.Text, 4, 2)), CInt(VB.Right(mskDateFin.Text, 2)))) & Mid(mskDateFin.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmChoixDateImpressionFT", "mskDateFin_LostFocus", Err, Erl())
	End Sub
	
	Private Sub cmdDateDebut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDateDebut.Click
		
5: On Error GoTo AfficherErreur
		'Ouverture du calendrier
		
		'Si il y a une date valide, la date par défaut est celle-ci, sinon c'est la date
		'd'aujourd'hui
10: If Trim(mskDateDebut.Text) <> vbNullString Then
15: If ValiderDate(mskDateDebut.Text) = True Then
20: mvwDate.Value = CDate(mskDateDebut.Text)
25: Else
30: mvwDate.Value = Today
35: End If
40: Else
45: mvwDate.Value = Today
50: End If
		
55: m_eDate = enumDate.DEBUT
		
60: mvwDate.Visible = True
		
65: Call mvwDate.Focus()
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmChoixDateImpressionFT", "cmdDateDebut_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDateFin_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDateFin.Click
		
5: On Error GoTo AfficherErreur
		'Ouverture du calendrier
		
		'Si il y a une date valide, la date par défaut est celle-ci, sinon c'est la date
		'd'aujourd'hui
10: If Trim(mskDateFin.Text) <> vbNullString Then
15: If ValiderDate(mskDateFin.Text) = True Then
20: mvwDate.Value = CDate(mskDateFin.Text)
25: Else
30: mvwDate.Value = Today
35: End If
40: Else
45: mvwDate.Value = Today
50: End If
		
55: m_eDate = enumDate.Fin
		
60: mvwDate.Visible = True
		
65: Call mvwDate.Focus()
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmChoixDateImpressionFT", "cmdDateFin_Click", Err, Erl())
	End Sub
	
	Private Function ValiderDate(ByVal sDate As String) As Boolean
		
5: On Error GoTo AfficherErreur
		
		'Validation des dates
10: If Not IsDate(sDate) Then
15: ValiderDate = False
20: Else
25: ValiderDate = True
30: End If
		
35: Exit Function
		
AfficherErreur: 
		
40: Call AfficherErreur("frmChoixDateImpressionFT", "ValiderDate", Err, Erl())
	End Function
	
	Private Sub ExporterPunch()
		
5: On Error GoTo AfficherErreur
		
		'Impression de la feuille de la liste des pièces
10: Dim rstEmployes As ADODB.Recordset
15: Dim rstProjets As ADODB.Recordset
20: Dim xlsWorkBook As Excel.Workbook
25: Dim iNbreEmployes As Short
30: Dim iNbreProjets As Short
35: Dim iNbrePages As Short
40: Dim iPage As Short
45: Dim sDateDebut As String
50: Dim sDateFin As String
		
55: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
60: rstEmployes = New ADODB.Recordset
65: rstProjets = New ADODB.Recordset
		
70: rstEmployes.CursorLocation = ADODB.CursorLocationEnum.adUseClient
75: rstProjets.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		
80: sDateDebut = mskDateDebut.Text
85: sDateFin = mskDateFin.Text
		
90: Call rstProjets.Open("SELECT DISTINCT NoProjet, RIGHT(NoProjet, 9) FROM GRB_Punch WHERE Date BETWEEN '" & sDateDebut & "' AND '" & sDateFin & "' ORDER BY RIGHT(NoProjet, 9)", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
95: Call rstEmployes.Open("SELECT DISTINCT Employe FROM GRB_Punch INNER JOIN GRB_Employés ON GRB_Employés.NoEmploye = GRB_Punch.NoEmploye WHERE Date BETWEEN '" & sDateDebut & "' AND '" & sDateFin & "'", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
100: iNbreEmployes = rstEmployes.RecordCount
105: iNbreProjets = rstProjets.RecordCount
		
110: If iNbreProjets > 26 Then
115: iNbrePages = Int(iNbreProjets / 26)
			
120: If iNbrePages * 26 < iNbreProjets Then
125: iNbrePages = iNbrePages + 1
130: End If
135: Else
140: iNbrePages = 1
145: End If
		
150: m_xlsApp = New Excel.Application
		
155: xlsWorkBook = m_xlsApp.Workbooks.Add
		
160: For iPage = 1 To iNbrePages
165: Call CreerTableau(rstProjets, rstEmployes, (iPage * 43) - 42, sDateDebut, sDateFin)
170: Next 
		
175: Call rstProjets.Close()
180: Call rstEmployes.Close()
		
185: 'UPGRADE_NOTE: Object rstProjets may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjets = Nothing
190: 'UPGRADE_NOTE: Object rstEmployes may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmployes = Nothing
		
195: Call TransfererValeurs(sDateDebut, sDateFin)
		
200: Call RemplirValeurs(iNbrePages)
		
205: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.ActiveSheet.PageSetup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_xlsApp.ActiveSheet.PageSetup.LeftMargin = m_xlsApp.Application.InchesToPoints(0)
210: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.ActiveSheet.PageSetup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_xlsApp.ActiveSheet.PageSetup.RightMargin = m_xlsApp.Application.InchesToPoints(0)
215: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.ActiveSheet.PageSetup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_xlsApp.ActiveSheet.PageSetup.TopMargin = m_xlsApp.Application.InchesToPoints(0)
220: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.ActiveSheet.PageSetup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_xlsApp.ActiveSheet.PageSetup.BottomMargin = m_xlsApp.Application.InchesToPoints(0)
225: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.ActiveSheet.PageSetup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_xlsApp.ActiveSheet.PageSetup.HeaderMargin = m_xlsApp.Application.InchesToPoints(0)
230: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.ActiveSheet.PageSetup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_xlsApp.ActiveSheet.PageSetup.FooterMargin = m_xlsApp.Application.InchesToPoints(0)
235: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.ActiveSheet.PageSetup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_xlsApp.ActiveSheet.PageSetup.CenterHorizontally = True
240: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.ActiveSheet.PageSetup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_xlsApp.ActiveSheet.PageSetup.CenterVertically = False
245: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.ActiveSheet.PageSetup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_xlsApp.ActiveSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
250: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.ActiveSheet.PageSetup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_xlsApp.ActiveSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal
		
255: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
260: m_xlsApp.Visible = True
		
265: Exit Sub
		
AfficherErreur: 
		
270: Call AfficherErreur("frmChoixDateImpressionFT", "ExporterPunch", Err, Erl())
	End Sub
	
	Private Sub CreerTableau(ByRef rstProjets As ADODB.Recordset, ByRef rstEmployes As ADODB.Recordset, ByVal iDebut As Short, ByVal sDateDebut As String, ByVal sDateFin As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim iNbreProjets As Short
15: Dim iNbreEmployes As Short
20: Dim iCompteur As Short
25: Dim sLettre As String
		
30: iNbreProjets = rstProjets.RecordCount
35: iNbreEmployes = rstEmployes.RecordCount
		
40: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_xlsApp.Cells._Default(iDebut, 1) = "DU " & UCase(GetDateTexte(CDate(sDateDebut))) & " AU " & UCase(GetDateTexte(CDate(sDateFin)))
45: m_xlsApp.Range("A" & iDebut).Font.Bold = True
50: m_xlsApp.Range("A" & iDebut).Font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleSingle
55: m_xlsApp.Range("A" & iDebut).HorizontalAlignment = Excel.Constants.xlCenter
60: m_xlsApp.Range("A" & iDebut).Font.Size = 18
		
65: Call m_xlsApp.Range("A" & iDebut, "AB" & iDebut).Merge()
		
70: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.Columns().ColumnWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_xlsApp.Columns._Default("A:A").ColumnWidth = 21
75: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.Columns().ColumnWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_xlsApp.Columns._Default("B:AB").ColumnWidth = 5
80: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.Columns().ColumnWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_xlsApp.Columns._Default("AB:AB").ColumnWidth = 6.29
		
85: m_xlsApp.Range("B" & iDebut + 3, "AB" & iDebut + 3).HorizontalAlignment = Excel.Constants.xlCenter
90: m_xlsApp.Range("B" & iDebut + 3, "AB" & iDebut + 3).VerticalAlignment = Excel.Constants.xlCenter
95: m_xlsApp.Range("B" & iDebut + 3, "AB" & iDebut + 3).Orientation = 90
		
100: For iCompteur = 2 To 27
105: If rstProjets.EOF = True Then
110: Exit For
115: Else
120: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				m_xlsApp.Cells._Default(iDebut + 3, iCompteur) = rstProjets.Fields("NoProjet").Value
				
125: Call rstProjets.MoveNext()
130: End If
135: Next 
		
140: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_xlsApp.Cells._Default(iDebut + 3, 28) = "TOTAL"
		
145: Call rstEmployes.MoveFirst()
		
150: For iCompteur = 4 To iNbreEmployes + 3
155: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			m_xlsApp.Cells._Default(iDebut + iCompteur, 1) = rstEmployes.Fields("Employe").Value
			
160: Call rstEmployes.MoveNext()
165: Next 
		
170: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_xlsApp.Cells._Default(iDebut + iCompteur, 1) = "TOTAL"
		
		'Ajout des lignes
175: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
180: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).Weight = Excel.XlBorderWeight.xlMedium
185: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).ColorIndex = Excel.Constants.xlAutomatic
		
190: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
195: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = Excel.XlBorderWeight.xlMedium
200: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeTop).ColorIndex = Excel.Constants.xlAutomatic
		
205: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
210: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlMedium
215: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).ColorIndex = Excel.Constants.xlAutomatic
		
220: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
225: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeRight).Weight = Excel.XlBorderWeight.xlMedium
230: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeRight).ColorIndex = Excel.Constants.xlAutomatic
		
235: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous
240: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlInsideVertical).Weight = Excel.XlBorderWeight.xlThin
245: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlInsideVertical).ColorIndex = Excel.Constants.xlAutomatic
		
250: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
255: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlInsideHorizontal).Weight = Excel.XlBorderWeight.xlThin
260: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlInsideHorizontal).ColorIndex = Excel.Constants.xlAutomatic
		
265: m_xlsApp.Range("B" & iDebut + 3 & ":AA" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
270: m_xlsApp.Range("B" & iDebut + 3 & ":AA" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).Weight = Excel.XlBorderWeight.xlMedium
275: m_xlsApp.Range("B" & iDebut + 3 & ":AA" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).ColorIndex = Excel.Constants.xlAutomatic
		
280: m_xlsApp.Range("B" & iDebut + 3 & ":AA" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
285: m_xlsApp.Range("B" & iDebut + 3 & ":AA" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeRight).Weight = Excel.XlBorderWeight.xlMedium
290: m_xlsApp.Range("B" & iDebut + 3 & ":AA" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeRight).ColorIndex = Excel.Constants.xlAutomatic
		
295: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
300: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlMedium
305: m_xlsApp.Range("A" & iDebut + 3 & ":AB" & iDebut + 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).ColorIndex = Excel.Constants.xlAutomatic
		
310: m_xlsApp.Range("A" & iDebut + iNbreEmployes + 4 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
315: m_xlsApp.Range("A" & iDebut + iNbreEmployes + 4 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = Excel.XlBorderWeight.xlMedium
320: m_xlsApp.Range("A" & iDebut + iNbreEmployes + 4 & ":AB" & iDebut + iNbreEmployes + 4).Borders(Excel.XlBordersIndex.xlEdgeTop).ColorIndex = Excel.Constants.xlAutomatic
		
325: For iCompteur = iDebut + 4 To iNbreEmployes + iDebut + 4
330: m_xlsApp.Range("AB" & iCompteur)._Default = "=SUM(B" & iCompteur & ":AA" & iCompteur & ")"
335: Next 
		
340: For iCompteur = 2 To 27
345: Select Case iCompteur
				Case 2 : sLettre = "B"
				Case 3 : sLettre = "C"
				Case 4 : sLettre = "D"
				Case 5 : sLettre = "E"
				Case 6 : sLettre = "F"
				Case 7 : sLettre = "G"
				Case 8 : sLettre = "H"
				Case 9 : sLettre = "I"
				Case 10 : sLettre = "J"
				Case 11 : sLettre = "K"
				Case 12 : sLettre = "L"
				Case 13 : sLettre = "M"
				Case 14 : sLettre = "N"
				Case 15 : sLettre = "O"
				Case 16 : sLettre = "P"
				Case 17 : sLettre = "Q"
				Case 18 : sLettre = "R"
				Case 19 : sLettre = "S"
				Case 20 : sLettre = "T"
				Case 21 : sLettre = "U"
				Case 22 : sLettre = "V"
				Case 23 : sLettre = "W"
				Case 24 : sLettre = "X"
				Case 25 : sLettre = "Y"
				Case 26 : sLettre = "Z"
				Case 27 : sLettre = "AA"
			End Select
			
350: m_xlsApp.Range(sLettre & iDebut + iNbreEmployes + 4)._Default = "=SUM(" & sLettre & (iDebut + 4) & ":" & sLettre & (iDebut + iNbreEmployes + 3) & ")"
355: Next 
		
360: Exit Sub
		
AfficherErreur: 
		
365: Call AfficherErreur("frmChoixDateImpressionFT", "CreerTableau", Err, Erl())
	End Sub
	
	Private Sub TransfererValeurs(ByVal sDateDebut As String, ByVal sDateFin As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstSource As ADODB.Recordset
15: Dim rstDestination As ADODB.Recordset
20: Dim sDate As String
25: Dim sHeure As String
30: Dim sMinute As String
35: Dim dblResult As Double
40: Dim datTemp As Date
		
45: rstSource = New ADODB.Recordset
		
50: Call rstSource.Open("SELECT * FROM GRB_Punch WHERE Date BETWEEN '" & sDateDebut & "' AND '" & sDateFin & "' AND HeureFin Is Not Null", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
55: If Not rstSource.EOF Then
60: Call g_connData.Execute("DELETE * FROM GRB_PunchExcel")
			
65: rstDestination = New ADODB.Recordset
			
70: Call rstDestination.Open("SELECT * FROM GRB_PunchExcel", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
75: Do While Not rstSource.EOF
80: Call rstDestination.AddNew()
				
85: rstDestination.Fields("NoEmploye").Value = rstSource.Fields("NoEmploye").Value
90: rstDestination.Fields("NoProjet").Value = rstSource.Fields("NoProjet").Value
				
95: sHeure = VB.Left(rstSource.Fields("HeureDébut").Value, 2)
100: sMinute = VB.Right(rstSource.Fields("HeureDébut").Value, 2)
				
105: dblResult = CShort(sMinute) / 60
				
110: If dblResult <> 0 Then
115: rstDestination.Fields("HeureDébut").Value = sHeure & "," & VB.Right(CStr(dblResult), Len(CStr(dblResult)) - InStr(1, CStr(dblResult), ","))
120: Else
125: rstDestination.Fields("HeureDébut").Value = CShort(sHeure)
130: End If
				
135: sHeure = VB.Left(rstSource.Fields("HeureFin").Value, 2)
140: sMinute = VB.Right(rstSource.Fields("HeureFin").Value, 2)
				
145: dblResult = CShort(sMinute) / 60
				
150: If dblResult <> 0 Then
155: rstDestination.Fields("HeureFin").Value = CShort(sHeure) & "," & CShort(VB.Right(CStr(dblResult), Len(CStr(dblResult)) - InStr(1, CStr(dblResult), ",")))
160: Else
165: rstDestination.Fields("HeureFin").Value = sHeure
170: End If
				
175: Call rstDestination.Update()
				
180: Call rstSource.MoveNext()
185: Loop 
			
190: Call rstDestination.Close()
195: 'UPGRADE_NOTE: Object rstDestination may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstDestination = Nothing
200: End If
		
205: Call rstSource.Close()
210: 'UPGRADE_NOTE: Object rstSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstSource = Nothing
		
215: Exit Sub
		
AfficherErreur: 
		
220: Call AfficherErreur("frmChoixDateImpressionFT", "TransfererValeurs", Err, Erl())
	End Sub
	
	Private Sub RemplirValeurs(ByVal iNbrePages As Short)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPunch As ADODB.Recordset
15: Dim sNom As String
20: Dim iIndexNom As Short
25: Dim iCompteur As Short
30: Dim iPage As Short
35: Dim iPageRendu As Short
40: Dim iNoRendu As Short
45: Dim iDebutPage As Short
50: Dim iIndexProjet As Short
55: Dim bProjetTrouve As Boolean
		
60: rstPunch = New ADODB.Recordset
		
65: Call rstPunch.Open("SELECT Employe, NoProjet, SUM(HeureFin - HeureDébut) As Total FROM GRB_PunchExcel INNER JOIN GRB_Employés ON GRB_PunchExcel.NoEmploye = GRB_Employés.NoEmploye GROUP BY Employe, NoProjet ORDER BY Employe, RIGHT(NoProjet, 9)", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
70: Dim counter As Short
		If Not rstPunch.EOF Then
75: iIndexNom = 4
			
80: sNom = rstPunch.Fields("Employe").Value
			
85: iPageRendu = 1
90: iNoRendu = 2
			
95: Do While Not rstPunch.EOF
100: If sNom <> rstPunch.Fields("Employe").Value Then
105: sNom = rstPunch.Fields("Employe").Value
					
110: iIndexNom = iIndexNom + 1
					
115: iPageRendu = 1
120: iNoRendu = 2
125: Else
130: If iNoRendu > 2 Then
135: iNoRendu = iNoRendu - 1
140: Else
145: If iPageRendu > 1 Then
150: iPageRendu = iPageRendu - 1
155: iNoRendu = 27
160: End If
165: End If
170: End If
				
175: bProjetTrouve = False
				
180: counter = iPageRendu
				For iPage = counter To iNbrePages
185: If iPageRendu <> iPage Then
190: iNoRendu = 2
195: End If
					
200: iDebutPage = (iPage * 43) - 42
					
205: counter = iNoRendu
					For iCompteur = counter To 27
210: If m_xlsApp.Cells._Default(iDebutPage + 3, iCompteur) = rstPunch.Fields("NoProjet").Value Then
215: iIndexProjet = iCompteur
							
220: iPageRendu = iPage
225: iNoRendu = iCompteur
							
230: bProjetTrouve = True
							
235: Exit For
240: End If
245: Next 
					
250: If bProjetTrouve = True Then
255: Exit For
260: End If
265: Next 
				
270: If bProjetTrouve = False Then
275: Call MsgBox("Le # " & rstPunch.Fields("NoProjet").Value & " n'a pas pu être trouvé pour l'employé " & sNom & "." & vbNewLine & "Son temps de " & rstPunch.Fields("Total").Value & " heures sera ajouté à cet endroit : " & vbNewLine & "Page   : " & iPageRendu & vbNewLine & "Rangée : " & iIndexProjet)
					
280: End If
				
285: 'UPGRADE_WARNING: Couldn't resolve default property of object m_xlsApp.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				m_xlsApp.Cells._Default(iDebutPage + iIndexNom, iIndexProjet) = rstPunch.Fields("Total").Value
				
290: Call rstPunch.MoveNext()
295: Loop 
300: End If
		
305: Call rstPunch.Close()
310: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPunch = Nothing
		
315: Exit Sub
		
AfficherErreur: 
		
320: Call AfficherErreur("frmChoixDateImpressionFT", "RemplirValeurs", Err, Erl())
	End Sub
End Class