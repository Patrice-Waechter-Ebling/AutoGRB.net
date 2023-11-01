Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmDetailTemps
	Inherits System.Windows.Forms.Form
	
	Private Const I_COL_EMPLOYE As Short = 0
	Private Const I_COL_TYPE As Short = 1
	Private Const I_COL_HEURES As Short = 2
	
	Private m_sNoProjet As String
	Private m_bProjet As Boolean
	Private m_eType As ModuleMain.enumCatalogue
	
	Public Sub Afficher(ByVal sNoProjet As String, ByVal eType As ModuleMain.enumCatalogue, ByVal bProjet As Boolean)
		
5: On Error GoTo AfficherErreur
		
10: m_eType = eType
		
15: m_sNoProjet = sNoProjet
		
20: m_bProjet = bProjet
		
25: Call RemplirListViewTemps(sNoProjet)
		
30: Call ShowDialog()
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmDetailTemps", "Afficher", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewTemps(ByVal sNoProjet As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPunch As ADODB.Recordset
15: Dim itmPunch As System.Windows.Forms.ListViewItem
20: Dim sFilterNoProjet As String
		
25: If VB.Right(sNoProjet, 2) = "99" Then
30: sFilterNoProjet = "LEFT(NoProjet, 6) = '" & VB.Left(sNoProjet, 6) & "'"
35: Else
40: sFilterNoProjet = "NoProjet = '" & sNoProjet & "'"
45: End If
		
50: rstPunch = New ADODB.Recordset
		
55: Call rstPunch.Open("SELECT Employe, Type, (Sum(TimeSerial(LEFT(HeureFin, 2), RIGHT(HeureFin, 2), 0) - TimeSerial(LEFT(HeureDébut, 2), RIGHT(HeureDébut, 2), 0)) * 24) AS TotalHeures FROM GRB_Punch INNER JOIN GRB_Employés ON GRB_Punch.NoEmploye = GRB_Employés.NoEmploye WHERE HeureDébut is Not Null And HeureFin is Not Null AND " & sFilterNoProjet & " GROUP BY Employe, Type", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
60: Do While Not rstPunch.EOF
65: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwTemps.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmPunch = lvwTemps.Items.Add()
			
70: itmPunch.Text = rstPunch.Fields("Employe").Value
			'Retire pour afficher le type vu au lieu des spécifique GLL
			
75: 'If Not IsNull(rstPunch.Fields("Type")) Then
80: '  If m_eType = ELECTRIQUE Then
85: '    Select Case rstPunch.Fields("Type")
			'      Case "Dessin":        itmPunch.SubItems(I_COL_TYPE) = "Dessin"
90: '      Case "Fabrication":   itmPunch.SubItems(I_COL_TYPE) = "Fabrication"
95: '      Case "Assemblage":    itmPunch.SubItems(I_COL_TYPE) = "Assemblage"
100: '      Case "ProgInterface": itmPunch.SubItems(I_COL_TYPE) = "Programmation d'interface"
105: '      Case "ProgAutomate":  itmPunch.SubItems(I_COL_TYPE) = "Programmation d'automate"
110: '      Case "ProgRobot":     itmPunch.SubItems(I_COL_TYPE) = "Programmation de robot"
115: '      Case "Vision":        itmPunch.SubItems(I_COL_TYPE) = "Vision"
120: '      Case "Test":          itmPunch.SubItems(I_COL_TYPE) = "Test"
125: '      Case "Installation":  itmPunch.SubItems(I_COL_TYPE) = "Installation"
130: '      Case "MiseService":   itmPunch.SubItems(I_COL_TYPE) = "Mise en service"
135: '      Case "Formation":     itmPunch.SubItems(I_COL_TYPE) = "Formation du personnel"
140: '      Case "Gestion":       itmPunch.SubItems(I_COL_TYPE) = "Gestion du projet"
145: '      Case "Shipping":      itmPunch.SubItems(I_COL_TYPE) = "Expédition"
			'      Case "Prototypage-Dévelloppement expérimental":      itmPunch.SubItems(I_COL_TYPE) = "Prototypage-Dévelloppement expérimental"
150: '    End Select
155: '  Else
160: '    Select Case rstPunch.Fields("Type")
			'     Case "Dessin":       itmPunch.SubItems(I_COL_TYPE) = "Conception et dessins"
165: '      Case "Coupe":        itmPunch.SubItems(I_COL_TYPE) = "Coupe et préparation (sauf soudage)"
170: '      Case "Machinage":    itmPunch.SubItems(I_COL_TYPE) = "Machinage"
175: '      Case "Soudure":      itmPunch.SubItems(I_COL_TYPE) = "Coupe, soudure et meulage"
180: '      Case "Assemblage":   itmPunch.SubItems(I_COL_TYPE) = "Assemblage des systèmes"
185: '      Case "Peinture":     itmPunch.SubItems(I_COL_TYPE) = "Peinture et finition"
190: '      Case "Test":         itmPunch.SubItems(I_COL_TYPE) = "Tests finaux"
195: '      Case "Installation": itmPunch.SubItems(I_COL_TYPE) = "Installation"
200: '      Case "Formation":    itmPunch.SubItems(I_COL_TYPE) = "Formation du formation"
205: '      Case "Gestion":      itmPunch.SubItems(I_COL_TYPE) = "Gestion du projet"
210: '      Case "Shipping":     itmPunch.SubItems(I_COL_TYPE) = "Expédition"
			'      Case "Prototypage-Dévelloppement expérimental":     itmPunch.SubItems(I_COL_TYPE) = "Prototypage-Dévelloppement expérimental"
215: '    End Select
220: '  End If
225: 'Else
230: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPunch.SubItems.Count > I_COL_TYPE Then
				itmPunch.SubItems(I_COL_TYPE).Text = rstPunch.Fields("Type").Value
			Else
				itmPunch.SubItems.Insert(I_COL_TYPE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPunch.Fields("Type").Value))
			End If
235: 'End If
			
240: 'UPGRADE_WARNING: Lower bound of collection itmPunch has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPunch.SubItems.Count > I_COL_HEURES Then
				itmPunch.SubItems(I_COL_HEURES).Text = CStr(System.Math.Round(rstPunch.Fields("TotalHeures").Value, 2))
			Else
				itmPunch.SubItems.Insert(I_COL_HEURES, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, CStr(System.Math.Round(rstPunch.Fields("TotalHeures").Value, 2))))
			End If
			
245: Call rstPunch.MoveNext()
250: Loop 
		
255: Call rstPunch.Close()
260: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPunch = Nothing
		
265: Exit Sub
		
AfficherErreur: 
		
270: Call AfficherErreur("frmDetailTemps", "RemplirListViewTemps", Err, Erl())
	End Sub
	
	Private Sub cmdImprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImprimer.Click
		Dim intdummie As Short
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = ModuleMain.enumCatalogue.ELECTRIQUE Then
			
			'demande d'ecriture dans excel
			intdummie = MsgBox("Désirez-vous exporter les données dans Excel ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Exportation dans Excel")
			If intdummie = MsgBoxResult.Yes Then
				Call vb_to_excel()
				
			End If
			
15: Call ImprimerDetailTempsElectriques()
20: Else
			
			'demande d'ecriture dans excel
			intdummie = MsgBox("Désirez-vous exporter les données dans Excel ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Exportation dans Excel")
			If intdummie = MsgBoxResult.Yes Then
				Call vb_to_excel()
				
			End If
			
25: Call ImprimerDetailTempsMecaniques()
30: End If
		
		
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmDetailTemps", "cmdImprimer_Click", Err, Erl())
	End Sub
	
	Private Sub ImprimerDetailTempsElectriques()
		Dim DR_TempsElec As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmploye As ADODB.Recordset
15: Dim rstImpTemps As ADODB.Recordset
20: Dim rstProjSoum As ADODB.Recordset
25: Dim dblTotal As Double
30: Dim sFilterNoProjet As String
		
35: If VB.Right(m_sNoProjet, 2) = "99" Then
40: sFilterNoProjet = "LEFT(NoProjet, 6) = '" & VB.Left(m_sNoProjet, 6) & "'"
45: Else
50: sFilterNoProjet = "NoProjet = '" & m_sNoProjet & "'"
55: End If
		
60: rstEmploye = New ADODB.Recordset
		
65: Call rstEmploye.Open("SELECT Employe, Type, (Sum(TimeSerial(Left(HeureFin,2), RIGHT(HeureFin,2),0) - TimeSerial(Left(HeureDébut,2), RIGHT(HeureDébut,2),0)) * 24) AS TotalHeures FROM GRB_Punch INNER JOIN GRB_Employés ON GRB_Punch.NoEmploye = GRB_Employés.NoEmploye WHERE HeureDébut is Not Null And HeureFin is Not Null AND " & sFilterNoProjet & " GROUP BY Employe, Type", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
70: Call g_connData.Execute("DELETE * FROM GRB_ImpressionDetailTemps")
		
75: rstImpTemps = New ADODB.Recordset
		
80: Call rstImpTemps.Open("SELECT * FROM GRB_ImpressionDetailTemps", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
85: Do While Not rstEmploye.EOF
90: Call rstImpTemps.AddNew()
			
95: rstImpTemps.Fields("Employe").Value = rstEmploye.Fields("Employe").Value
			
100: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstEmploye.Fields("Type").Value) Then
105: 'Retirer pour afficher que le type vu GLL v41 2017-08-23
				'Select Case rstEmploye.Fields("Type")
				'  Case "Dessin":        rstImpTemps.Fields("Type") = "Dessin"
110: '  Case "Fabrication":   rstImpTemps.Fields("Type") = "Fabrication"
115: '  Case "Assemblage":    rstImpTemps.Fields("Type") = "Assemblage"
120: '  Case "ProgInterface": rstImpTemps.Fields("Type") = "Programmation d'interface"
125: '  Case "ProgAutomate":  rstImpTemps.Fields("Type") = "Programmation d'automate"
130: '  Case "ProgRobot":     rstImpTemps.Fields("Type") = "Programmation de robot"
135: '  Case "Vision":        rstImpTemps.Fields("Type") = "Vision"
140: '  Case "Test":          rstImpTemps.Fields("Type") = "Test"
145: '  Case "Installation":  rstImpTemps.Fields("Type") = "Installation"
150: '  Case "MiseService":   rstImpTemps.Fields("Type") = "Mise en service"
155: '  Case "Formation":     rstImpTemps.Fields("Type") = "Formation du personnel"
160: '  Case "Gestion":       rstImpTemps.Fields("Type") = "Gestion du projet"
165: '  Case "Shipping":      rstImpTemps.Fields("Type") = "Expédition"
				'  Case "Prototypage-Dévelloppement expérimental":      rstImpTemps.Fields("Type") = "Prototypage-Dévelloppement expérimental"
170: 'End Select
175: rstImpTemps.Fields("Type").Value = rstEmploye.Fields("Type").Value
176: Else
180: rstImpTemps.Fields("Type").Value = ""
185: End If
			
190: rstImpTemps.Fields("TotalHeures").Value = rstEmploye.Fields("TotalHeures").Value
			
195: Call rstImpTemps.Update()
			
200: Call rstEmploye.MoveNext()
205: Loop 
		
210: Call rstEmploye.Close()
215: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
220: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsElec.DataSource = rstImpTemps
		
225: rstProjSoum = New ADODB.Recordset
		
230: If m_bProjet = True Then
235: Call rstProjSoum.Open("SELECT * FROM GRB_ProjetElec WHERE IDProjet = '" & m_sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
240: Else
245: Call rstProjSoum.Open("SELECT * FROM GRB_SoumissionElec WHERE IDSoumission = '" & m_sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
250: End If
		
		'Affichage du # de projet ou soumissin
255: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsElec.Sections("Section4").Controls("lblNoProjet").Caption = m_sNoProjet
		
260: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjSoum.Fields("TempsDessin").Value) Then
265: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsDessinEstime").Caption = System.Math.Round(rstProjSoum.Fields("TempsDessin").Value, 2)
270: Else
275: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsDessinEstime").Caption = "0"
280: End If
		
285: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjSoum.Fields("TempsFabrication").Value) Then
290: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsFabricationEstime").Caption = System.Math.Round(rstProjSoum.Fields("TempsFabrication").Value, 2)
295: Else
300: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsFabricationEstime").Caption = "0"
305: End If
		
310: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjSoum.Fields("TempsAssemblage").Value) Then
315: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsAssemblageEstime").Caption = System.Math.Round(rstProjSoum.Fields("TempsAssemblage").Value, 2)
320: Else
325: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsAssemblageEstime").Caption = "0"
330: End If
		
335: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjSoum.Fields("TempsProgInterface").Value) Then
340: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsProgInterfaceEstime").Caption = System.Math.Round(rstProjSoum.Fields("TempsProgInterface").Value, 2)
345: Else
350: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsProgInterfaceEstime").Caption = "0"
355: End If
		
360: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjSoum.Fields("TempsProgAutomate").Value) Then
365: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsProgAutomateEstime").Caption = System.Math.Round(rstProjSoum.Fields("TempsProgAutomate").Value, 2)
370: Else
375: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsProgAutomateEstime").Caption = "0"
380: End If
		
385: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjSoum.Fields("TempsProgRobot").Value) Then
390: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsProgRobotEstime").Caption = System.Math.Round(rstProjSoum.Fields("TempsProgRobot").Value, 2)
395: Else
400: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsProgRobotEstime").Caption = "0"
405: End If
		
410: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjSoum.Fields("TempsVision").Value) Then
415: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsVisionEstime").Caption = System.Math.Round(rstProjSoum.Fields("TempsVision").Value, 2)
420: Else
425: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsVisionEstime").Caption = "0"
430: End If
		
435: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjSoum.Fields("TempsTest").Value) Then
440: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsTestEstime").Caption = System.Math.Round(rstProjSoum.Fields("TempsTest").Value, 2)
445: Else
450: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsTestEstime").Caption = "0"
455: End If
		
460: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjSoum.Fields("TempsInstallation").Value) Then
465: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsInstallationEstime").Caption = System.Math.Round(rstProjSoum.Fields("TempsInstallation").Value, 2)
470: Else
475: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsInstallationEstime").Caption = "0"
480: End If
		
485: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjSoum.Fields("TempsMiseService").Value) Then
490: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsMiseServiceEstime").Caption = System.Math.Round(rstProjSoum.Fields("TempsMiseService").Value, 2)
495: Else
500: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsMiseServiceEstime").Caption = "0"
505: End If
		
510: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjSoum.Fields("TempsFormation").Value) Then
515: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsFormationEstime").Caption = System.Math.Round(rstProjSoum.Fields("TempsFormation").Value, 2)
520: Else
525: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsFormationEstime").Caption = "0"
530: End If
		
535: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjSoum.Fields("TempsGestion").Value) Then
540: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsGestionEstime").Caption = System.Math.Round(rstProjSoum.Fields("TempsGestion").Value, 2)
545: Else
550: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsGestionEstime").Caption = "0"
555: End If
		
560: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjSoum.Fields("TempsShipping").Value) Then
565: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsShippingEstime").Caption = System.Math.Round(rstProjSoum.Fields("TempsShipping").Value, 2)
570: Else
575: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTempsShippingEstime").Caption = "0"
580: End If
		
		
		
		
585: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dblTotal = CDbl(DR_TempsElec.Sections("Section4").Controls("lblTempsDessinEstime").Caption) + CDbl(DR_TempsElec.Sections("Section4").Controls("lblTempsFabricationEstime").Caption) + CDbl(DR_TempsElec.Sections("Section4").Controls("lblTempsAssemblageEstime").Caption) + CDbl(DR_TempsElec.Sections("Section4").Controls("lblTempsProgInterfaceEstime").Caption) + CDbl(DR_TempsElec.Sections("Section4").Controls("lblTempsProgAutomateEstime").Caption) + CDbl(DR_TempsElec.Sections("Section4").Controls("lblTempsProgRobotEstime").Caption) + CDbl(DR_TempsElec.Sections("Section4").Controls("lblTempsVisionEstime").Caption) + CDbl(DR_TempsElec.Sections("Section4").Controls("lblTempsTestEstime").Caption) + CDbl(DR_TempsElec.Sections("Section4").Controls("lblTempsInstallationEstime").Caption) + CDbl(DR_TempsElec.Sections("Section4").Controls("lblTempsMiseServiceEstime").Caption) + CDbl(DR_TempsElec.Sections("Section4").Controls("lblTempsFormationEstime").Caption) + CDbl(DR_TempsElec.Sections("Section4").Controls("lblTempsGestionEstime").Caption) + CDbl(DR_TempsElec.Sections("Section4").Controls("lblTempsShippingEstime").Caption)
		
590: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsElec.Sections("Section4").Controls("lblTotalTempsEstime").Caption = dblTotal
		
595: Call rstProjSoum.Close()
600: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjSoum = Nothing
		
605: Call CalculerTempsReelsElec()
		
610: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_TempsElec.Show(VB6.FormShowConstants.Modal)
		
615: Call rstImpTemps.Close()
620: 'UPGRADE_NOTE: Object rstImpTemps may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstImpTemps = Nothing
		
625: Exit Sub
		
AfficherErreur: 
		
630: Call AfficherErreur("frmDetailTemps", "ImprimerDetailTempsElectriques", Err, Erl())
	End Sub
	
	Private Sub ImprimerDetailTempsMecaniques()
		Dim DR_TempsMec As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstEmploye As ADODB.Recordset
15: Dim rstImpTemps As ADODB.Recordset
20: Dim rstProjSoum As ADODB.Recordset
25: Dim rstSoum As ADODB.Recordset
30: Dim dblTotal As Double
35: Dim sFilterNoProjet As String
		
40: If VB.Right(m_sNoProjet, 2) = "99" Then
45: sFilterNoProjet = "LEFT(NoProjet, 6) = '" & VB.Left(m_sNoProjet, 6) & "'"
50: Else
55: sFilterNoProjet = "NoProjet = '" & m_sNoProjet & "'"
60: End If
		
65: rstEmploye = New ADODB.Recordset
		
70: Call rstEmploye.Open("SELECT Employe, Type, (Sum(TimeSerial(Left(HeureFin,2), RIGHT(HeureFin,2),0) - TimeSerial(Left(HeureDébut,2), RIGHT(HeureDébut,2),0)) * 24) AS TotalHeures FROM GRB_Punch INNER JOIN GRB_Employés ON GRB_Punch.NoEmploye = GRB_Employés.NoEmploye WHERE HeureDébut is Not Null And HeureFin is Not Null AND " & sFilterNoProjet & " GROUP BY Employe, Type", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
75: Call g_connData.Execute("DELETE * FROM GRB_ImpressionDetailTemps")
		
80: rstImpTemps = New ADODB.Recordset
		
85: Call rstImpTemps.Open("SELECT * FROM GRB_ImpressionDetailTemps", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
90: Do While Not rstEmploye.EOF
95: Call rstImpTemps.AddNew()
			
100: rstImpTemps.Fields("Employe").Value = rstEmploye.Fields("Employe").Value
			
105: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstEmploye.Fields("Type").Value) Then
110: 'Retirer par GLL V41 2017-08-23
				'Select Case rstEmploye.Fields("Type")
				'  Case "Dessin":       rstImpTemps.Fields("Type") = "Conception et dessins"
115: '  Case "Coupe":        rstImpTemps.Fields("Type") = "Coupe et préparation (sauf soudage)"
120: '  Case "Machinage":    rstImpTemps.Fields("Type") = "Machinage"
125: '  Case "Soudure":      rstImpTemps.Fields("Type") = "Coupe, soudure et meulage"
130: '  Case "Assemblage":   rstImpTemps.Fields("Type") = "Assemblage des systèmes"
135: '  Case "Peinture":     rstImpTemps.Fields("Type") = "Peinture et finition"
140: '  Case "Test":         rstImpTemps.Fields("Type") = "Tests finaux"
145: '  Case "Installation": rstImpTemps.Fields("Type") = "Installation"
150: '  Case "Formation":    rstImpTemps.Fields("Type") = "Formation du personnel"
155: '  Case "Gestion":      rstImpTemps.Fields("Type") = "Gestion du projet"
160: '  Case "Shipping":     rstImpTemps.Fields("Type") = "Expédition"
165: 'End Select
170: rstImpTemps.Fields("Type").Value = rstEmploye.Fields("Type").Value
173: Else
175: rstImpTemps.Fields("Type").Value = ""
180: End If
			
185: rstImpTemps.Fields("TotalHeures").Value = rstEmploye.Fields("TotalHeures").Value
			
190: Call rstImpTemps.Update()
			
195: Call rstEmploye.MoveNext()
200: Loop 
		
205: Call rstEmploye.Close()
210: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
215: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsMec.DataSource = rstImpTemps
		
220: rstProjSoum = New ADODB.Recordset
		
225: If m_bProjet = True Then
230: Call rstProjSoum.Open("SELECT * FROM GRB_ProjetMec WHERE IDProjet = '" & m_sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
235: Else
240: Call rstProjSoum.Open("SELECT * FROM GRB_SoumissionMec WHERE IDSoumission = '" & m_sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
245: End If
		
		'Affichage du # de projet ou soumission
250: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsMec.Sections("Section4").Controls("lblNoProjet").Caption = m_sNoProjet
		
		'Si soumission
255: If m_bProjet = False Then
260: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsDessin").Value) Then
265: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsDessinSoum").Caption = System.Math.Round(rstProjSoum.Fields("TempsDessin").Value, 2)
270: Else
275: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsDessinSoum").Caption = "0"
280: End If
			
285: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsCoupe").Value) Then
290: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeSoum").Caption = System.Math.Round(rstProjSoum.Fields("TempsCoupe").Value, 2)
295: Else
300: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeSoum").Caption = "0"
305: End If
			
310: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsMachinage").Value) Then
315: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageSoum").Caption = System.Math.Round(rstProjSoum.Fields("TempsMachinage").Value, 2)
320: Else
325: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageSoum").Caption = "0"
330: End If
			
335: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsSoudure").Value) Then
340: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureSoum").Caption = System.Math.Round(rstProjSoum.Fields("TempsSoudure").Value, 2)
345: Else
350: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureSoum").Caption = "0"
355: End If
			
360: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsAssemblage").Value) Then
365: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageSoum").Caption = System.Math.Round(rstProjSoum.Fields("TempsAssemblage").Value, 2)
370: Else
375: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageSoum").Caption = "0"
380: End If
			
385: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsPeinture").Value) Then
390: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureSoum").Caption = System.Math.Round(rstProjSoum.Fields("TempsPeinture").Value, 2)
395: Else
400: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureSoum").Caption = "0"
405: End If
			
410: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsTest").Value) Then
415: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsTestSoum").Caption = System.Math.Round(rstProjSoum.Fields("TempsTest").Value, 2)
420: Else
425: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsTestSoum").Caption = "0"
430: End If
			
435: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsInstallation").Value) Then
440: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationSoum").Caption = System.Math.Round(rstProjSoum.Fields("TempsInstallation").Value, 2)
445: Else
450: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationSoum").Caption = "0"
455: End If
			
460: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsFormation").Value) Then
465: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsFormationSoum").Caption = System.Math.Round(rstProjSoum.Fields("TempsFormation").Value, 2)
470: Else
475: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsFormationSoum").Caption = "0"
480: End If
			
485: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsGestion").Value) Then
490: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsGestionSoum").Caption = System.Math.Round(rstProjSoum.Fields("TempsGestion").Value, 2)
495: Else
500: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsGestionSoum").Caption = "0"
505: End If
			
510: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsShipping").Value) Then
515: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsShippingSoum").Caption = System.Math.Round(rstProjSoum.Fields("TempsShipping").Value, 2)
520: Else
525: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsShippingSoum").Caption = "0"
530: End If
			
535: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsDessinProj").Caption = "---"
540: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeProj").Caption = "---"
545: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageProj").Caption = "---"
550: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureProj").Caption = "---"
555: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageProj").Caption = "---"
560: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureProj").Caption = "---"
565: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsTestProj").Caption = "---"
570: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationProj").Caption = "---"
575: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsFormationProj").Caption = "---"
580: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsGestionProj").Caption = "---"
585: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsShippingProj").Caption = "---"
			
590: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsDessinConc").Caption = "---"
595: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeConc").Caption = "---"
600: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageConc").Caption = "---"
605: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureConc").Caption = "---"
610: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageConc").Caption = "---"
615: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureConc").Caption = "---"
620: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsTestConc").Caption = "---"
625: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationConc").Caption = "---"
630: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsFormationConc").Caption = "---"
635: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsGestionConc").Caption = "---"
640: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTempsShippingConc").Caption = "---"
645: Else
650: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("IDSoumission").Value) Then
655: rstSoum = New ADODB.Recordset
				
660: Call rstSoum.Open("SELECT * FROM GRB_SoumissionMec WHERE IDSoumission = '" & m_sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
665: If Not rstSoum.EOF Then
670: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstSoum.Fields("TempsDessin").Value) Then
675: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsDessinSoum").Caption = System.Math.Round(rstSoum.Fields("TempsDessin").Value, 2)
680: Else
685: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsDessinSoum").Caption = "0"
690: End If
					
695: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstSoum.Fields("TempsCoupe").Value) Then
700: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeSoum").Caption = System.Math.Round(rstSoum.Fields("TempsCoupe").Value, 2)
705: Else
710: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeSoum").Caption = "0"
715: End If
					
720: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstSoum.Fields("TempsMachinage").Value) Then
725: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageSoum").Caption = System.Math.Round(rstSoum.Fields("TempsMachinage").Value, 2)
730: Else
735: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageSoum").Caption = "0"
740: End If
					
745: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstSoum.Fields("TempsSoudure").Value) Then
750: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureSoum").Caption = System.Math.Round(rstSoum.Fields("TempsSoudure").Value, 2)
755: Else
760: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureSoum").Caption = "0"
765: End If
					
770: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstSoum.Fields("TempsAssemblage").Value) Then
775: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageSoum").Caption = System.Math.Round(rstSoum.Fields("TempsAssemblage").Value, 2)
780: Else
785: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageSoum").Caption = "0"
790: End If
					
795: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstSoum.Fields("TempsPeinture").Value) Then
800: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureSoum").Caption = System.Math.Round(rstSoum.Fields("TempsPeinture").Value, 2)
805: Else
810: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureSoum").Caption = "0"
815: End If
					
820: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstSoum.Fields("TempsTest").Value) Then
825: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsTestSoum").Caption = System.Math.Round(rstSoum.Fields("TempsTest").Value, 2)
830: Else
835: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsTestSoum").Caption = "0"
840: End If
					
845: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstSoum.Fields("TempsInstallation").Value) Then
850: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationSoum").Caption = System.Math.Round(rstSoum.Fields("TempsInstallation").Value, 2)
855: Else
860: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationSoum").Caption = "0"
865: End If
					
870: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstSoum.Fields("TempsFormation").Value) Then
875: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsFormationSoum").Caption = System.Math.Round(rstSoum.Fields("TempsFormation").Value, 2)
880: Else
885: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsFormationSoum").Caption = "0"
890: End If
					
895: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstSoum.Fields("TempsGestion").Value) Then
900: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsGestionSoum").Caption = System.Math.Round(rstSoum.Fields("TempsGestion").Value, 2)
905: Else
910: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsGestionSoum").Caption = "0"
915: End If
					
920: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstSoum.Fields("TempsShipping").Value) Then
925: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsShippingSoum").Caption = System.Math.Round(rstSoum.Fields("TempsShipping").Value, 2)
930: Else
935: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsShippingSoum").Caption = "0"
940: End If
945: Else
950: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsDessinSoum").Caption = "---"
955: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeSoum").Caption = "---"
960: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageSoum").Caption = "---"
965: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureSoum").Caption = "---"
970: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageSoum").Caption = "---"
975: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureSoum").Caption = "---"
980: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsTestSoum").Caption = "---"
985: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationSoum").Caption = "---"
990: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsFormationSoum").Caption = "---"
995: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsGestionSoum").Caption = "---"
1000: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsShippingSoum").Caption = "---"
1005: End If
				
1010: Call rstSoum.Close()
1015: 'UPGRADE_NOTE: Object rstSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstSoum = Nothing
1020: Else
1025: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsDessinSoum").Caption = "---"
1030: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeSoum").Caption = "---"
1035: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageSoum").Caption = "---"
1040: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureSoum").Caption = "---"
1045: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageSoum").Caption = "---"
1050: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureSoum").Caption = "---"
1055: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsTestSoum").Caption = "---"
1060: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationSoum").Caption = "---"
1065: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsFormationSoum").Caption = "---"
1070: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsGestionSoum").Caption = "---"
1075: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsShippingSoum").Caption = "---"
1080: End If
			
1085: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsDessinProj").Value) Then
1090: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsDessinProj").Caption = System.Math.Round(rstProjSoum.Fields("TempsDessinProj").Value, 2)
1095: Else
1100: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsDessinProj").Caption = "0"
1105: End If
			
1110: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsCoupeProj").Value) Then
1115: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeProj").Caption = System.Math.Round(rstProjSoum.Fields("TempsCoupeProj").Value, 2)
1120: Else
1125: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeProj").Caption = "0"
1130: End If
			
1135: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsMachinageProj").Value) Then
1140: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageProj").Caption = System.Math.Round(rstProjSoum.Fields("TempsMachinageProj").Value, 2)
1145: Else
1150: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageProj").Caption = "0"
1155: End If
			
1160: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsSoudureProj").Value) Then
1165: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureProj").Caption = System.Math.Round(rstProjSoum.Fields("TempsSoudureProj").Value, 2)
1170: Else
1175: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureProj").Caption = "0"
1180: End If
			
1185: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsAssemblageProj").Value) Then
1190: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageProj").Caption = System.Math.Round(rstProjSoum.Fields("TempsAssemblageProj").Value, 2)
1195: Else
1200: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageProj").Caption = "0"
1205: End If
			
1210: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsPeintureProj").Value) Then
1215: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureProj").Caption = System.Math.Round(rstProjSoum.Fields("TempsPeintureProj").Value, 2)
1220: Else
1225: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureProj").Caption = "0"
1230: End If
			
1235: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsTestProj").Value) Then
1240: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsTestProj").Caption = System.Math.Round(rstProjSoum.Fields("TempsTestProj").Value, 2)
1245: Else
1250: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsTestProj").Caption = "0"
1255: End If
			
1260: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsInstallationProj").Value) Then
1265: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationProj").Caption = System.Math.Round(rstProjSoum.Fields("TempsInstallationProj").Value, 2)
1270: Else
1275: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationProj").Caption = "0"
1280: End If
			
1285: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsFormationProj").Value) Then
1290: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsFormationProj").Caption = System.Math.Round(rstProjSoum.Fields("TempsFormationProj").Value, 2)
1295: Else
1300: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsFormationProj").Caption = "0"
1305: End If
			
1310: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsGestionProj").Value) Then
1315: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsGestionProj").Caption = System.Math.Round(rstProjSoum.Fields("TempsGestionProj").Value, 2)
1320: Else
1325: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsGestionProj").Caption = "0"
1330: End If
			
1335: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstProjSoum.Fields("TempsShippingProj").Value) Then
1340: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsShippingProj").Caption = System.Math.Round(rstProjSoum.Fields("TempsShippingProj").Value, 2)
1345: Else
1350: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsShippingProj").Caption = "0"
1355: End If
			
1360: If rstProjSoum.Fields("TempsProjBarré").Value = True Then
1365: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsDessinConc").Value) Then
1370: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsDessinConc").Caption = System.Math.Round(rstProjSoum.Fields("TempsDessinConc").Value, 2)
1375: Else
1380: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsDessinConc").Caption = "0"
1385: End If
				
1390: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsCoupeConc").Value) Then
1395: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeConc").Caption = System.Math.Round(rstProjSoum.Fields("TempsCoupeConc").Value, 2)
1400: Else
1405: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeConc").Caption = "0"
1410: End If
				
1415: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsMachinageConc").Value) Then
1420: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageConc").Caption = System.Math.Round(rstProjSoum.Fields("TempsMachinageConc").Value, 2)
1425: Else
1430: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageConc").Caption = "0"
1435: End If
				
1440: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsSoudureConc").Value) Then
1445: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureConc").Caption = System.Math.Round(rstProjSoum.Fields("TempsSoudureConc").Value, 2)
1450: Else
1455: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureConc").Caption = "0"
1460: End If
				
1465: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsAssemblageConc").Value) Then
1470: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageConc").Caption = System.Math.Round(rstProjSoum.Fields("TempsAssemblageConc").Value, 2)
1475: Else
1480: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageConc").Caption = "0"
1485: End If
				
1490: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsPeintureConc").Value) Then
1495: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureConc").Caption = System.Math.Round(rstProjSoum.Fields("TempsPeintureConc").Value, 2)
1500: Else
1505: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureConc").Caption = "0"
1510: End If
				
1515: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsTestConc").Value) Then
1520: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsTestConc").Caption = System.Math.Round(rstProjSoum.Fields("TempsTestConc").Value, 2)
1525: Else
1530: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsTestConc").Caption = "0"
1535: End If
				
1540: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsInstallationConc").Value) Then
1545: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationConc").Caption = System.Math.Round(rstProjSoum.Fields("TempsInstallationConc").Value, 2)
1550: Else
1555: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationConc").Caption = "0"
1560: End If
				
1565: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsFormationConc").Value) Then
1570: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsFormationConc").Caption = System.Math.Round(rstProjSoum.Fields("TempsFormationConc").Value, 2)
1575: Else
1580: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsFormationConc").Caption = "0"
1585: End If
				
1590: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsGestionConc").Value) Then
1595: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsGestionConc").Caption = System.Math.Round(rstProjSoum.Fields("TempsGestionConc").Value, 2)
1600: Else
1605: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsGestionConc").Caption = "0"
1610: End If
				
1615: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjSoum.Fields("TempsShippingConc").Value) Then
1620: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsShippingConc").Caption = System.Math.Round(rstProjSoum.Fields("TempsShippingConc").Value, 2)
1625: Else
1630: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					DR_TempsMec.Sections("Section4").Controls("lblTempsShippingConc").Caption = "0"
1635: End If
1640: Else
1645: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsDessinConc").Caption = "---"
1650: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeConc").Caption = "---"
1655: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageConc").Caption = "---"
1660: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureConc").Caption = "---"
1665: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageConc").Caption = "---"
1670: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureConc").Caption = "---"
1675: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsTestConc").Caption = "---"
1680: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationConc").Caption = "---"
1685: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsFormationConc").Caption = "---"
1690: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsGestionConc").Caption = "---"
1695: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_TempsMec.Sections("Section4").Controls("lblTempsShippingConc").Caption = "---"
1700: End If
1705: End If
		
1710: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If DR_TempsMec.Sections("Section4").Controls("lblTempsDessinSoum").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeSoum").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageSoum").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureSoum").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageSoum").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureSoum").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsTestSoum").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationSoum").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsFormationSoum").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsGestionSoum").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsShippingSoum").Caption = "---" Then
			
1715: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTotalTempsSoum").Caption = "---"
1720: Else
1725: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsDessinSoum").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeSoum").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageSoum").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureSoum").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageSoum").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureSoum").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsTestSoum").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationSoum").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsFormationSoum").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsGestionSoum").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsShippingSoum").Caption)
			
1730: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTotalTempsSoum").Caption = dblTotal
1735: End If
		
		
1740: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If DR_TempsMec.Sections("Section4").Controls("lblTempsDessinProj").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeProj").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageProj").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureProj").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageProj").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureProj").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsTestProj").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationProj").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsFormationProj").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsGestionProj").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsGestionProj").Caption = "---" Then
			
1745: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTotalTempsProj").Caption = "---"
1750: Else
1755: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsDessinProj").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeProj").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageProj").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureProj").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageProj").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureProj").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsTestProj").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationProj").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsFormationProj").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsGestionProj").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsShippingProj").Caption)
			
1760: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTotalTempsProj").Caption = dblTotal
1765: End If
		
1770: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If DR_TempsMec.Sections("Section4").Controls("lblTempsDessinConc").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeConc").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageConc").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureConc").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageConc").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureConc").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsTestConc").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationConc").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsFormationConc").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsGestionConc").Caption = "---" And DR_TempsMec.Sections("Section4").Controls("lblTempsShippingConc").Caption = "---" Then
			
1775: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTotalTempsConc").Caption = "---"
1780: Else
1785: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsDessinConc").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeConc").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageConc").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureConc").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageConc").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureConc").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsTestConc").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationConc").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsFormationConc").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsGestionConc").Caption) + CDbl(DR_TempsMec.Sections("Section4").Controls("lblTempsShippingConc").Caption)
			
1790: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTotalTempsConc").Caption = dblTotal
1795: End If
		
1800: Call rstProjSoum.Close()
1805: 'UPGRADE_NOTE: Object rstProjSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjSoum = Nothing
		
1810: Call CalculerTempsReelsMec()
		
1815: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_TempsMec.Show(VB6.FormShowConstants.Modal)
		
1820: Call rstImpTemps.Close()
1825: 'UPGRADE_NOTE: Object rstImpTemps may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstImpTemps = Nothing
		
1830: Exit Sub
		
AfficherErreur: 
		
1835: Call AfficherErreur("frmDetailTemps", "ImprimerDetailTempsMecaniques", Err, Erl())
	End Sub
	
	Private Sub CalculerTempsReelsElec()
		Dim DR_TempsElec As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstTotal As ADODB.Recordset
15: Dim sDateDebut As String
20: Dim sDateFin As String
25: Dim sTotal As String
30: Dim sFilterNoProjet As String
		
35: If VB.Right(m_sNoProjet, 2) = "99" Then
40: sFilterNoProjet = "LEFT(NoProjet, 6) = '" & VB.Left(m_sNoProjet, 6) & "'"
45: Else
50: sFilterNoProjet = "NoProjet = '" & m_sNoProjet & "'"
55: End If
		
60: rstTotal = New ADODB.Recordset
		
65: sDateDebut = "TIMESERIAL(Left(GRB_Punch.HeureDébut,2),RIGHT(GRB_Punch.HeureDébut,2),0)"
		
70: sDateFin = "TIMESERIAL(Left(GRB_Punch.HeureFin,2),RIGHT(GRB_Punch.HeureFin,2),0)"
		
75: sTotal = "(SUM(" & sDateFin & " - " & sDateDebut & ")* 24) As Total"
		
80: Call rstTotal.Open("SELECT Type, " & sTotal & " FROM GRB_Punch WHERE " & sFilterNoProjet & " And HeureFin is not null AND HeureDébut is not null GROUP BY Type", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
85: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsElec.Sections("Section4").Controls("lblTempsDessinReel").Caption = "0"
90: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsElec.Sections("Section4").Controls("lblTempsFabricationReel").Caption = "0"
95: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsElec.Sections("Section4").Controls("lblTempsAssemblageReel").Caption = "0"
100: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsElec.Sections("Section4").Controls("lblTempsProgInterfaceReel").Caption = "0"
105: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsElec.Sections("Section4").Controls("lblTempsProgAutomateReel").Caption = "0"
110: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsElec.Sections("Section4").Controls("lblTempsProgRobotReel").Caption = "0"
115: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsElec.Sections("Section4").Controls("lblTempsVisionReel").Caption = "0"
120: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsElec.Sections("Section4").Controls("lblTempsTestReel").Caption = "0"
125: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsElec.Sections("Section4").Controls("lblTempsInstallationReel").Caption = "0"
130: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsElec.Sections("Section4").Controls("lblTempsMiseServiceReel").Caption = "0"
135: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsElec.Sections("Section4").Controls("lblTempsFormationReel").Caption = "0"
140: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsElec.Sections("Section4").Controls("lblTempsGestionReel").Caption = "0"
145: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsElec.Sections("Section4").Controls("lblTempsShippingReel").Caption = "0"
		
150: Do While Not rstTotal.EOF
155: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstTotal.Fields("Total").Value) Then
160: Select Case rstTotal.Fields("Type").Value
					Case "Dessin"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsElec.Sections("Section4").Controls("lblTempsDessinReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
165: Case "Fabrication"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsElec.Sections("Section4").Controls("lblTempsFabricationReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
170: Case "Assemblage"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsElec.Sections("Section4").Controls("lblTempsAssemblageReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
175: Case "ProgInterface"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsElec.Sections("Section4").Controls("lblTempsProgInterfaceReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
180: Case "ProgAutomate"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsElec.Sections("Section4").Controls("lblTempsProgAutomateReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
185: Case "ProgRobot"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsElec.Sections("Section4").Controls("lblTempsProgRobotReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
190: Case "Vision"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsElec.Sections("Section4").Controls("lblTempsVisionReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
195: Case "Test"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsElec.Sections("Section4").Controls("lblTempsTestReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
200: Case "Installation"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsElec.Sections("Section4").Controls("lblTempsInstallationReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
205: Case "MiseService"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsElec.Sections("Section4").Controls("lblTempsMiseServiceReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
210: Case "Formation"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsElec.Sections("Section4").Controls("lblTempsFormationReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
215: Case "Gestion"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsElec.Sections("Section4").Controls("lblTempsGestionReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
220: Case "Shipping"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsElec.Sections("Section4").Controls("lblTempsShippingReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
221: Case "Prototypage-Dévelloppement expérimental"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsElec.Sections("Section4").Controls("lblTempsprototypeReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
						
225: End Select
230: End If
			
235: Call rstTotal.MoveNext()
240: Loop 
		
245: Call rstTotal.Close()
		
250: Call rstTotal.Open("SELECT " & sTotal & " FROM GRB_Punch WHERE " & sFilterNoProjet & " And HeureFin is not null AND HeureDébut is not null", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
255: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstTotal.Fields("Total").Value) Then
260: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTotalTempsReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
265: Else
270: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsElec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsElec.Sections("Section4").Controls("lblTotalTempsReel").Caption = "0"
275: End If
		
280: Call rstTotal.Close()
285: 'UPGRADE_NOTE: Object rstTotal may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstTotal = Nothing
		
290: Exit Sub
		
AfficherErreur: 
		
295: Call AfficherErreur("frmDetailTemps", "CalculerTempsReelsElec", Err, Erl())
	End Sub
	
	Private Sub CalculerTempsReelsMec()
		Dim DR_TempsMec As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstTotal As ADODB.Recordset
15: Dim sDateDebut As String
20: Dim sDateFin As String
25: Dim sTotal As String
30: Dim sFilterNoProjet As String
		
35: If VB.Right(m_sNoProjet, 2) = "99" Then
40: sFilterNoProjet = "LEFT(NoProjet, 6) = '" & VB.Left(m_sNoProjet, 6) & "'"
45: Else
50: sFilterNoProjet = "NoProjet = '" & m_sNoProjet & "'"
55: End If
		
60: rstTotal = New ADODB.Recordset
		
65: sDateDebut = "TIMESERIAL(Left(GRB_Punch.HeureDébut,2),RIGHT(GRB_Punch.HeureDébut,2),0)"
		
70: sDateFin = "TIMESERIAL(Left(GRB_Punch.HeureFin,2),RIGHT(GRB_Punch.HeureFin,2),0)"
		
75: sTotal = "(SUM(" & sDateFin & " - " & sDateDebut & ")* 24) As Total"
		
80: Call rstTotal.Open("SELECT Type, " & sTotal & " FROM GRB_Punch WHERE " & sFilterNoProjet & " And HeureFin is not null AND HeureDébut is not null GROUP BY Type", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
85: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsMec.Sections("Section4").Controls("lblTempsDessinReel").Caption = "0"
90: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeReel").Caption = "0"
95: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageReel").Caption = "0"
100: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureReel").Caption = "0"
105: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageReel").Caption = "0"
110: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureReel").Caption = "0"
115: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsMec.Sections("Section4").Controls("lblTempsTestReel").Caption = "0"
120: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationReel").Caption = "0"
125: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsMec.Sections("Section4").Controls("lblTempsFormationReel").Caption = "0"
130: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsMec.Sections("Section4").Controls("lblTempsGestionReel").Caption = "0"
135: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsMec.Sections("Section4").Controls("lblTempsShippingReel").Caption = "0"
		'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_TempsMec.Sections("Section4").Controls("lblTempsprototypeReel").Caption = "0"
		
		
140: Do While Not rstTotal.EOF
145: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstTotal.Fields("Total").Value) Then
150: Select Case rstTotal.Fields("Type").Value
					Case "Dessin"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsDessinReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
155: Case "Coupe"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsCoupeReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
160: Case "Machinage"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsMachinageReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
165: Case "Soudure"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsSoudureReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
170: Case "Assemblage"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsAssemblageReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
175: Case "Peinture"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsPeintureReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
180: Case "Test"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsTestReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
185: Case "Installation"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsInstallationReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
190: Case "Formation"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsFormationReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
195: Case "Gestion"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsGestionReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
200: Case "Shipping"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsShippingReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
205: Case "Prototypage-Dévelloppement expérimental"
						'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DR_TempsMec.Sections("Section4").Controls("lblTempsPrototypeReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
						
				End Select
210: End If
			
215: Call rstTotal.MoveNext()
220: Loop 
		
225: Call rstTotal.Close()
		
230: Call rstTotal.Open("SELECT " & sTotal & " FROM GRB_Punch WHERE " & sFilterNoProjet & " And HeureFin is not null AND HeureDébut is not null", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
235: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstTotal.Fields("Total").Value) Then
240: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTotalTempsReel").Caption = System.Math.Round(rstTotal.Fields("Total").Value, 2)
245: Else
250: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_TempsMec.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_TempsMec.Sections("Section4").Controls("lblTotalTempsReel").Caption = "0"
255: End If
		
260: Call rstTotal.Close()
265: 'UPGRADE_NOTE: Object rstTotal may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstTotal = Nothing
		
270: Exit Sub
		
AfficherErreur: 
		
275: Call AfficherErreur("frmDetailTemps", "CalculerTempsReelsMec", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmDetailTemps", "cmdOK_Click", Err, Erl())
	End Sub
	
	
	Private Function vb_to_excel() As Object
		
		
5: 
		
6: Dim iCount As Short
10: Dim oXLApp As Excel.Application 'Declare the object variables
15: Dim oXLBook As Excel.Workbook
20: Dim oXLSheet As Excel.Worksheet
		'UPGRADE_WARNING: Lower bound of array data_array was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim data_array(500, 4) As Object
		Dim r As Short
25: oXLApp = New Excel.Application 'Create a new instance of Excel
30: oXLBook = oXLApp.Workbooks.Add 'Add a new workbook
35: oXLSheet = oXLBook.Worksheets(1) 'Work with the first worksheet
		oXLApp.Visible = False
		
		'on inscrit les valeurs du listbox dans un tableau
		r = 1
		'UPGRADE_WARNING: IsEmpty was upgraded to IsNothing and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		Do While Not IsNothing(r <= lvwTemps.Items.Count)
			'UPGRADE_WARNING: Lower bound of collection lvwTemps.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 1) = lvwTemps.Items.Item(r).Text
			'UPGRADE_WARNING: Lower bound of collection lvwTemps.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwTemps.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 2) = lvwTemps.Items.Item(r).SubItems(1).Text
			'UPGRADE_WARNING: Lower bound of collection lvwTemps.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwTemps.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object data_array(r, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			data_array(r, 3) = CDbl(lvwTemps.Items.Item(r).SubItems(2).Text)
			r = r + 1
			
		Loop 
		
		'ajustement largeur des colonne
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLSheet.Columns().ColumnWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLSheet.Columns._Default(1).ColumnWidth = 30
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLSheet.Columns().ColumnWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLSheet.Columns._Default(2).ColumnWidth = 30
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLSheet.Columns().ColumnWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLSheet.Columns._Default(3).ColumnWidth = 10
		
		'creation en-tête de colonne
		oXLSheet.Range("A1: C1").Font.Bold = True
		'UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		oXLSheet.Range("A1: C1").Value = New Object(){"Employé", "Type", "heures"}
		
		'inscription des valeur du tableau dans excel
		oXLSheet.Range("A2").Resize(r, 3).Value = VB6.CopyArray(data_array)
		
		oXLApp.Visible = True
		
		
		
		
		
	End Function
	
	Private Sub Command1_Click()
		
		Call vb_to_excel()
		
		
		
		
		
		
		
		
		
		
	End Sub
End Class