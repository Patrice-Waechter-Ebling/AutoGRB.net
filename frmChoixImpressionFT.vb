Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmChoixImpressionFT
	Inherits System.Windows.Forms.Form
	
	Private m_datDebut As Date
	Private m_datFin As Date
	
	Public Sub Afficher(ByVal datDebut As Date, ByVal datFin As Date)
		
5: On Error GoTo AfficherErreur
		
10: m_datDebut = datDebut
15: m_datFin = datFin
		
20: Call RemplirListViewEmploye()
		
25: Call Me.ShowDialog()
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixImpressionFT", "Afficher", Err, Erl())
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixImpressionFT", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdImprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImprimer.Click
		Dim DR_FeuilleTemps As Object
		
5: On Error GoTo AfficherErreur
		
		'Impression de la feuille de temps
10: Dim rstImpPunch As ADODB.Recordset
15: Dim rstSommeKM As ADODB.Recordset
20: Dim rstPunch As ADODB.Recordset
25: Dim bAnnuler As Boolean
30: Dim iCompteur As Short
35: Dim dblTotal As Double
		
40: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
45: rstImpPunch = New ADODB.Recordset
50: rstSommeKM = New ADODB.Recordset
55: rstPunch = New ADODB.Recordset
		
60: For iCompteur = 1 To lvwEmploye.Items.Count
65: 'UPGRADE_WARNING: Lower bound of collection lvwEmploye.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwEmploye.Items.Item(iCompteur).Checked = True Then
70: dblTotal = 0
				
75: bAnnuler = False
				
80: Call g_connData.Execute("DELETE * FROM GRB_ImpressionPunch")
				
85: 'UPGRADE_WARNING: Lower bound of collection lvwEmploye.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE Date BETWEEN '" & ConvertDate(m_datDebut) & "' AND '" & ConvertDate(m_datFin) & "' AND NoEmploye = " & lvwEmploye.Items.Item(iCompteur).Tag & " ORDER BY Date, HeureDébut, HeureFin", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
				'Vérifie s'il y a des punchs
90: If Not rstPunch.EOF Then
					'Vérifie si le punch out a été fait
95: Do While Not rstPunch.EOF
100: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If IsDbNull(rstPunch.Fields("HeureFin").Value) Or rstPunch.Fields("HeureFin").Value = vbNullString Then
105: 'UPGRADE_WARNING: Lower bound of collection lvwEmploye.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							Call MsgBox("Un punch out n'a pas été fait pour " & lvwEmploye.Items.Item(iCompteur).Text & " !", MsgBoxStyle.OKOnly, "Erreur")
							
110: bAnnuler = True
							
115: Exit Do
120: End If
						
125: Call rstPunch.MoveNext()
130: Loop 
135: Else
140: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
					
145: 'UPGRADE_WARNING: Lower bound of collection lvwEmploye.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call MsgBox("Il n'y a aucun punch à imprimer pour " & lvwEmploye.Items.Item(iCompteur).Text & " !", MsgBoxStyle.OKOnly, "Erreur")
					
150: bAnnuler = True
155: End If
				
160: Call rstPunch.Close()
				
165: If bAnnuler = False Then
170: Call RemplirTableImpressionPunch(iCompteur)
					
175: Call AjouterNomJour()
					
					
180: Call AjouterSéparateur()
					
185: Call CalculerTotal()
					
					'Le nom de l'employé
190: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FeuilleTemps.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Lower bound of collection lvwEmploye.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					DR_FeuilleTemps.Sections("Section4").Controls("lblNom").Caption = lvwEmploye.Items.Item(iCompteur).Text
					
					'La date de début et de fin de la semaine
195: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FeuilleTemps.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_FeuilleTemps.Sections("Section4").Controls("lblDate").Caption = "Semaine du " & GetDateTexte(m_datDebut) & " au " & GetDateTexte(m_datFin)
					
					'Date d'aujourd'hui
200: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FeuilleTemps.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_FeuilleTemps.Sections("Section3").Controls("lblDatePrint").Caption = ConvertDate(Today)
					
205: Call rstImpPunch.Open("SELECT * FROM GRB_ImpressionPunch ORDER BY Date, HeureDébut", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
210: Do While Not rstImpPunch.EOF
215: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(rstImpPunch.Fields("Total").Value) Then
220: If rstImpPunch.Fields("Total").Value <> "" Then
225: dblTotal = dblTotal + CDbl(VB.Left(rstImpPunch.Fields("Total").Value, 2))
230: dblTotal = dblTotal + CDbl(CDbl(VB.Right(rstImpPunch.Fields("Total").Value, 2)) / 60)
235: End If
240: End If
						
245: Call rstImpPunch.MoveNext()
250: Loop 
					
255: Call rstImpPunch.MoveFirst()
					
260: 'UPGRADE_WARNING: Lower bound of collection lvwEmploye.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call rstSommeKM.Open("SELECT SUM(NbreKM) As TotalKM FROM GRB_Punch WHERE Date BETWEEN '" & ConvertDate(m_datDebut) & "' AND '" & ConvertDate(m_datFin) & "' AND NoEmploye = " & lvwEmploye.Items.Item(iCompteur).Tag & " AND KM = True", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
265: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FeuilleTemps.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_FeuilleTemps.DataSource = rstImpPunch
					
					'Le total d'heure dans une semaine
270: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FeuilleTemps.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_FeuilleTemps.Sections("Section5").Controls("lblGrandTotal").Caption = System.Math.Round(dblTotal, 2)
					
275: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstSommeKM.Fields("TotalKM").Value) Then
280: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FeuilleTemps.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_FeuilleTemps.Sections("Section5").Controls("lblGrandTotalKM").Caption = System.Math.Round(rstSommeKM.Fields("TotalKM").Value, 2)
285: Else
290: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FeuilleTemps.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_FeuilleTemps.Sections("Section5").Controls("lblGrandTotalKM").Caption = "0"
295: End If
					
300: 'DR_FeuilleTemps.Orientation = rptOrientLandscape
					
305: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_FeuilleTemps.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call DR_FeuilleTemps.Show(VB6.FormShowConstants.Modal)
					
310: Call rstImpPunch.Close()
315: Call rstSommeKM.Close()
320: End If
325: End If
330: Next 
		
335: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
340: Call Me.Close()
		
345: Exit Sub
		
AfficherErreur: 
		
350: Call AfficherErreur("frmChoixImpressionFT", "cmdImprimer_Click", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewEmploye()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmploye As ADODB.Recordset
15: Dim itmEmploye As System.Windows.Forms.ListViewItem
		
20: rstEmploye = New ADODB.Recordset
		
25: Call rstEmploye.Open("SELECT NoEmploye, Employe FROM GRB_Employés WHERE Actif = True ORDER BY Employe", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
30: Do While Not rstEmploye.EOF
35: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwEmploye.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmEmploye = lvwEmploye.Items.Add()
			
40: itmEmploye.Tag = rstEmploye.Fields("NoEmploye").Value
45: itmEmploye.Text = rstEmploye.Fields("Employe").Value
			
50: Call rstEmploye.MoveNext()
55: Loop 
		
60: Call rstEmploye.Close()
65: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmChoixImpressionFT", "RemplirListViewEmploye", Err, Erl())
	End Sub
	
	Private Sub RemplirTableImpressionPunch(ByVal iIndexListView As Short)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstImpPunch As ADODB.Recordset
15: Dim rstPunch As ADODB.Recordset
20: Dim rstClient As ADODB.Recordset
		
25: rstPunch = New ADODB.Recordset
30: rstImpPunch = New ADODB.Recordset
35: rstClient = New ADODB.Recordset
		
40: 'UPGRADE_WARNING: Lower bound of collection lvwEmploye.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		Call rstPunch.Open("SELECT * FROM GRB_Punch WHERE NoEmploye = " & lvwEmploye.Items.Item(iIndexListView).Tag & " AND Date BETWEEN '" & ConvertDate(m_datDebut) & "' AND '" & ConvertDate(m_datFin) & "' ORDER BY Date, HeureDébut", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
45: Call rstImpPunch.Open("SELECT * FROM GRB_ImpressionPunch", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
50: Do While Not rstPunch.EOF
55: Call rstImpPunch.AddNew()
			
60: rstImpPunch.Fields("NoProjet").Value = rstPunch.Fields("NoProjet").Value
65: rstImpPunch.Fields("Date").Value = rstPunch.Fields("Date").Value
			
70: If rstPunch.Fields("ModifDébut").Value = True Then
75: rstImpPunch.Fields("HeureDébut").Value = VB.Right("0" & rstPunch.Fields("HeureDébut").Value, 5) & "*"
80: Else
85: rstImpPunch.Fields("HeureDébut").Value = VB.Right("0" & rstPunch.Fields("HeureDébut").Value, 5)
90: End If
			
95: If rstPunch.Fields("ModifFin").Value = True Then
100: rstImpPunch.Fields("HeureFin").Value = VB.Right("0" & rstPunch.Fields("HeureFin").Value, 5) & "*"
105: Else
110: rstImpPunch.Fields("HeureFin").Value = VB.Right("0" & rstPunch.Fields("HeureFin").Value, 5)
115: End If
			
120: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPunch.Fields("NoClient").Value) And rstPunch.Fields("NoClient").Value > "0" Then
125: Call rstClient.Open("SELECT NomClient FROM GRB_Client WHERE IDClient = " & rstPunch.Fields("NoClient").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
130: rstImpPunch.Fields("Client").Value = rstClient.Fields("NomClient").Value
				
135: Call rstClient.Close()
140: End If
			
145: rstImpPunch.Fields("Commentaire").Value = rstPunch.Fields("Commentaire").Value
			
			
			'**************************************************************************
			'MODIFIÉ PAR GAÉTAN GINGRAS LE 07 FÉVRIER 2010
			'**************************************************************************
			'ajout
			rstImpPunch.Fields("Type").Value = rstPunch.Fields("Type").Value
			'**************************************************************************
			
			
150: rstImpPunch.Fields("NbreKM").Value = rstPunch.Fields("NbreKM").Value
			
155: Call rstImpPunch.Update()
			
160: Call rstPunch.MoveNext()
165: Loop 
		
170: Call rstPunch.Close()
175: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPunch = Nothing
		
180: Call rstImpPunch.Close()
185: 'UPGRADE_NOTE: Object rstImpPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstImpPunch = Nothing
		
190: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient = Nothing
		
195: Exit Sub
		
AfficherErreur: 
		
200: Call AfficherErreur("frmChoixImpressionFT", "RemplirTableImpressionPunch", Err, Erl())
	End Sub
	
	Private Sub AjouterNomJour()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstImpPunch As ADODB.Recordset
15: Dim sJour As String
20: Dim datTemp As Date
25: Dim sDate As String
		
		'Ouverture du recordset pour ajouter le nom de la journée
30: rstImpPunch = New ADODB.Recordset
		
35: rstImpPunch.CursorLocation = ADODB.CursorLocationEnum.adUseServer
		
40: Call rstImpPunch.Open("SELECT * FROM GRB_ImpressionPunch ORDER BY Date, HeureDébut", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Loop pour ajouter le nom de la journée
45: Do While Not rstImpPunch.EOF
50: sDate = rstImpPunch.Fields("Date").Value
			
55: datTemp = DateSerial(CInt(VB.Left(sDate, 4)), CInt(Mid(sDate, 6, 2)), CInt(VB.Right(sDate, 2)))
			
60: If sJour <> WeekDayName(WeekDay(datTemp)) Then
65: rstImpPunch.Fields("NomJour").Value = UCase(WeekDayName(WeekDay(datTemp)))
70: sJour = WeekDayName(WeekDay(datTemp))
75: Else
80: rstImpPunch.Fields("NomJour").Value = ""
85: End If
			
90: Call rstImpPunch.Update()
			
95: Call rstImpPunch.MoveNext()
100: Loop 
		
105: Call rstImpPunch.Close()
110: 'UPGRADE_NOTE: Object rstImpPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstImpPunch = Nothing
		
115: Exit Sub
		
AfficherErreur: 
		
120: Call AfficherErreur("frmChoixImpressionFT", "AjouterNomJour", Err, Erl())
	End Sub
	
	Private Sub AjouterSéparateur()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstImpPunch As ADODB.Recordset
15: Dim iNoRec As Short
20: Dim sJour As String
25: Dim collDate As Collection
30: Dim sDate As String
35: Dim iCompteur As Short
		
40: collDate = New Collection
		
45: rstImpPunch = New ADODB.Recordset
		
50: Call rstImpPunch.Open("SELECT * FROM GRB_ImpressionPunch ORDER BY Date, HeureDébut", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
55: iNoRec = 1
		
60: Do While Not rstImpPunch.EOF
65: If sJour <> rstImpPunch.Fields("NomJour").Value Then
70: If rstImpPunch.Fields("NomJour").Value <> vbNullString Then
75: If iNoRec > 1 Then
80: sDate = rstImpPunch.Fields("Date").Value
						
85: Call collDate.Add(sDate)
90: End If
95: End If
				
100: If rstImpPunch.Fields("NomJour").Value <> vbNullString Then
105: sJour = rstImpPunch.Fields("NomJour").Value
110: End If
115: End If
			
120: iNoRec = iNoRec + 1
			
125: Call rstImpPunch.MoveNext()
130: Loop 
		
135: For iCompteur = 1 To collDate.Count()
140: Call rstImpPunch.AddNew()
			
145: 'UPGRADE_WARNING: Couldn't resolve default property of object collDate(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rstImpPunch.Fields("Date").Value = collDate.Item(iCompteur)
150: rstImpPunch.Fields("NomJour").Value = vbNullString
155: rstImpPunch.Fields("NoProjet").Value = " "
160: rstImpPunch.Fields("Client").Value = vbNullString
165: rstImpPunch.Fields("Commentaire").Value = vbNullString
170: rstImpPunch.Fields("HeureDébut").Value = " "
175: rstImpPunch.Fields("HeureFin").Value = vbNullString
			
180: Call rstImpPunch.Update()
185: Next 
		
190: Call rstImpPunch.Close()
195: 'UPGRADE_NOTE: Object rstImpPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstImpPunch = Nothing
		
200: Exit Sub
		
AfficherErreur: 
		
205: Call AfficherErreur("frmChoixImpressionFT", "AjouterSéparateur", Err, Erl())
	End Sub
	
	Private Sub CalculerTotal()
		
5: On Error GoTo AfficherErreur
		
		'Calcul le temps entre chaque punch in et punch out
10: Dim rstImpPunch As ADODB.Recordset
15: Dim datDébut As Date
20: Dim datFin As Date
25: Dim datTotal As Date
30: Dim sDate As String
35: Dim sDébut As String
40: Dim sFin As String
		
		'Ouverture de tous les punchs à imprimer
45: rstImpPunch = New ADODB.Recordset
		
50: rstImpPunch.CursorLocation = ADODB.CursorLocationEnum.adUseServer
		
55: Call rstImpPunch.Open("SELECT * FROM GRB_ImpressionPunch", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
60: Do While Not rstImpPunch.EOF
			'Si ce n'est pas un séparateur
65: If Trim(rstImpPunch.Fields("HeureDébut").Value) <> vbNullString Then
70: sDate = rstImpPunch.Fields("Date").Value
75: sDébut = VB.Left(rstImpPunch.Fields("HeureDébut").Value, 5)
80: sFin = VB.Left(rstImpPunch.Fields("HeureFin").Value, 5)
				
85: datDébut = System.Date.FromOADate(DateSerial(CInt(VB.Left(sDate, 4)), CInt(Mid(sDate, 6, 2)), CInt(VB.Right(sDate, 2))).ToOADate + TimeSerial(CShort(VB.Left(sDébut, 2)), CShort(Mid(sDébut, 4, 2)), 0).ToOADate)
90: datFin = System.Date.FromOADate(DateSerial(CInt(VB.Left(sDate, 4)), CInt(Mid(sDate, 6, 2)), CInt(VB.Right(sDate, 2))).ToOADate + TimeSerial(CShort(VB.Left(sFin, 2)), CShort(Mid(sFin, 4, 2)), 0).ToOADate)
				
95: 'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
				If Hour(datDébut) = 0 And Minute(datDébut) = 0 And Second(datDébut) = 0 And Hour(datFin) = 0 And Minute(datFin) = 0 And Second(datFin) = 0 And DateDiff(Microsoft.VisualBasic.DateInterval.Day, datDébut, datFin) = 1 Then
100: rstImpPunch.Fields("Total").Value = "24:00"
105: Else
110: datTotal = System.Date.FromOADate(datFin.ToOADate - datDébut.ToOADate)
					
115: rstImpPunch.Fields("Total").Value = VB.Right("0" & Hour(datTotal), 2) & ":" & VB.Right("0" & Minute(datTotal), 2)
120: End If
				
125: Call rstImpPunch.Update()
130: End If
			
135: Call rstImpPunch.MoveNext()
140: Loop 
		
145: Exit Sub
		
AfficherErreur: 
		
150: Call AfficherErreur("frmChoixImpressionFT", "CalculerTotal", Err, Erl())
	End Sub
	
	Private Sub cmdTous_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTous.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: For iCompteur = 1 To lvwEmploye.Items.Count
20: 'UPGRADE_WARNING: Lower bound of collection lvwEmploye.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwEmploye.Items.Item(iCompteur).Checked = True
25: Next 
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixImpressionFT", "cmdTous_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAucun_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAucun.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: For iCompteur = 1 To lvwEmploye.Items.Count
20: 'UPGRADE_WARNING: Lower bound of collection lvwEmploye.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwEmploye.Items.Item(iCompteur).Checked = False
25: Next 
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixImpressionFT", "cmdAucun_Click", Err, Erl())
	End Sub
End Class