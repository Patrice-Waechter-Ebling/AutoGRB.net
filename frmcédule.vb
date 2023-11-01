Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmCédule
	Inherits System.Windows.Forms.Form
	
	Private Const I_LVW_JOUR_NO As Short = 0
	Private Const I_LVW_JOUR_NOM As Short = 1
	Private Const I_LVW_JOUR_DEBUT As Short = 2
	Private Const I_LVW_JOUR_FIN As Short = 3
	Private Const I_LVW_JOUR_CLIENT As Short = 4
	Private Const I_LVW_JOUR_TRANSPORT As Short = 5
	
	Private Const I_LVW_SEMAINE_NO As Short = 0
	Private Const I_LVW_SEMAINE_NOM As Short = 1
	Private Const I_LVW_SEMAINE_HEURE As Short = 2
	
	Private m_datDateChoisie As Date
	Private m_bModeAjouter As Boolean
	Private m_bMonthViewHasFocus As Boolean
	
	Private Sub chkfin_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles chkfin.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: If chkfin.CheckState = System.Windows.Forms.CheckState.Checked Then
20: chkfin.CheckState = System.Windows.Forms.CheckState.Unchecked
25: Else
30: chkfin.CheckState = System.Windows.Forms.CheckState.Checked
35: End If
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmCédule", "chkfin_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdAjouterAlarme_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdAjouterAlarme.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdAjouterAlarme_Click(cmdAjouterAlarme, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCédule", "cmdAjouterAlarme_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdAjouterCédule_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdAjouterCédule.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdAjouterCédule_Click(cmdAjouterCédule, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCédule", "cmdAjouterCédule_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdAnnulerAlarme_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdAnnulerAlarme.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdAnnulerAlarme_Click(cmdAnnulerAlarme, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCédule", "cmdAnnulerAlarme_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdAnnulerCédule_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdAnnulerCédule.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdAnnulerCédule_Click(cmdAnnulerCédule, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCédule", "cmdAnnulerCédule_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdCopier_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdCopier.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdCopier_Click(cmdCopier, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCédule", "cmdCopier_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdEnregistrerAlarme_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdEnregistrerAlarme.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdEnregistrerAlarme_Click(cmdEnregistrerAlarme, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCédule", "cmdEnregistrerAlarme_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdEnregistrerCédule_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdEnregistrerCédule.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdEnregistrerCédule_Click(cmdEnregistrerCédule, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCédule", "cmdEnregistrerCédule_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdRafraichir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRafraichir.Click
		
5: On Error GoTo AfficherErreur
		
10: Call RemplirListerClient()
		
15: m_bMonthViewHasFocus = False
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmCédule", "cmdRafraichir_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRafraichir_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdRafraichir.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdRafraichir_Click(cmdRafraichir, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCédule", "cmdRafraichir_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdRechercher_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercher.Click
		
5: On Error GoTo AfficherErreur
		
		'Remplis combo employé
10: Dim rstClient As ADODB.Recordset
15: Dim sRecherche As String
		
20: sRecherche = InputBox("Quel est le texte à rechercher ?")
		
25: If sRecherche <> "" Then
30: rstClient = New ADODB.Recordset
			
35: Call rstClient.Open("SELECT * FROM GRB_Client WHERE INSTR(1, NomClient,'" & sRecherche & "') > 0 AND Supprimé = False ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
40: Call cmbclient.Items.Clear()
			
			'Rempli tant il y a des employé
45: Do While Not rstClient.EOF
50: Call cmbclient.Items.Add(rstClient.Fields("NomClient").Value)
				
55: Call rstClient.MoveNext()
60: Loop 
			
65: Call rstClient.Close()
70: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstClient = Nothing
75: End If
		
80: m_bMonthViewHasFocus = False
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("frmCédule", "cmdRechercher_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRechercher_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdRechercher.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdRechercher_Click(cmdRechercher, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCédule", "cmdRechercher_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdsupprimer_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdsupprimer.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdsupprimer_Click(cmdsupprimer, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCédule", "cmdSupprimer_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdtransport_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdtransport.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdTransport_Click(cmdTransport, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCédule", "cmdTransport_MouseUp", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event frmCédule.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmCédule_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		
5: On Error GoTo AfficherErreur
		
10: Call frasemaine.Refresh()
		
15: Call frajour.Refresh()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmCédule", "Form_Resize", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event chkfin.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkfin_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkfin.CheckStateChanged
		
5: On Error GoTo AfficherErreur
		
		'On change l'affichage sur click
		'Fin projet ou transport
10: If chkfin.CheckState = System.Windows.Forms.CheckState.Unchecked Then
15: Call AfficherTransport()
20: Else
25: Call AfficherProjet()
30: End If
		
35: m_bMonthViewHasFocus = False
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmCédule", "chkfin_Click", Err, Erl())
	End Sub
	
	Private Sub AfficherTransport()
		
5: On Error GoTo AfficherErreur
		
		'Affichage transport
10: lblprojet.Visible = False
15: txtnoprojet.Visible = False
20: cmbtransport.Visible = True
25: cmdtransport.Visible = True
30: lbltransport.Visible = True
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmCédule", "AfficherTransport", Err, Erl())
	End Sub
	
	Private Sub AfficherProjet()
		
5: On Error GoTo AfficherErreur
		
		'Affichage fin de projet
10: lblprojet.Visible = True
15: txtnoprojet.Visible = True
20: cmbtransport.Visible = False
25: cmdtransport.Visible = False
30: lbltransport.Visible = False
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmCédule", "AfficherProjet", Err, Erl())
	End Sub
	
	Private Sub cmdAjouterCédule_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAjouterCédule.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
		'Met en mode ajouter et affiche champ pour entrer des données
15: m_bModeAjouter = True
		
20: fraliste.Visible = False
25: fraAlarme.Visible = False
30: frajour.Visible = True
		
		'Vide champ text
35: cmbemployé.Text = vbNullString
		
40: For iCompteur = 0 To cmbheuredébut.Items.Count - 1
45: If VB6.GetItemString(cmbheuredébut, iCompteur) = "8:00" Then
50: cmbheuredébut.SelectedIndex = iCompteur
				
55: Exit For
60: End If
65: Next 
		
70: For iCompteur = 0 To cmbheurefin.Items.Count - 1
75: If VB6.GetItemString(cmbheurefin, iCompteur) = "17:00" Then
80: cmbheurefin.SelectedIndex = iCompteur
				
85: Exit For
90: End If
95: Next 
		
100: cmbtransport.Text = vbNullString
105: txtnoprojet.Text = vbNullString
110: cmbclient.Text = vbNullString
115: chkfin.CheckState = System.Windows.Forms.CheckState.Unchecked
		
120: m_bMonthViewHasFocus = False
		
125: Exit Sub
		
AfficherErreur: 
		
130: Call AfficherErreur("frmCédule", "cmdAjouter_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAjouterAlarme_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAjouterAlarme.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
		'Met en mode ajouter et affiche champ pour entrer des données
15: m_bModeAjouter = True
		
20: mskHeure.Text = ""
25: txtMessage.Text = ""
		
30: fraliste.Visible = False
35: fraAlarme.Visible = True
40: frajour.Visible = False
		
45: mskHeure.Text = ""
		
50: m_bMonthViewHasFocus = False
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmCédule", "cmdAjouter_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnulerAlarme_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnulerAlarme.Click
		
5: On Error GoTo AfficherErreur
		
		'Quitte écran pour ajouter ou modifier
10: fraliste.Visible = True
15: fraAlarme.Visible = False
20: frajour.Visible = False
		
25: m_bMonthViewHasFocus = False
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmCédule", "cmdAnnulerAlarme_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnulerCédule_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnulerCédule.Click
		
5: On Error GoTo AfficherErreur
		
		'quitte ecran pour ajouté ou modifié
10: fraliste.Visible = True
15: fraAlarme.Visible = False
20: frajour.Visible = False
		
25: m_bMonthViewHasFocus = False
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmCédule", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub CopierAlarme(ByVal datDate As Date)
		
5: On Error GoTo AfficherErreur
		
10: Dim sDate As String
15: Dim rstAlarme As ADODB.Recordset
20: Dim rstCopieAlarme As ADODB.Recordset
25: Dim iCompteur As Short
		
30: sDate = ConvertDate(datDate)
		
35: If sDate <> vbNullString Then
40: datDate = DateSerial(CInt(VB.Left(sDate, 4)), CInt(Mid(sDate, 6, 2)), CInt(VB.Right(sDate, 2)))
			
45: For iCompteur = 1 To Lstjour.Items.Count
50: 'UPGRADE_WARNING: Lower bound of collection Lstjour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If Lstjour.Items.Item(iCompteur).Selected = True Then
					'ouvre la table
55: rstAlarme = New ADODB.Recordset
60: rstCopieAlarme = New ADODB.Recordset
					
65: 'UPGRADE_WARNING: Lower bound of collection Lstjour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call rstAlarme.Open("SELECT * FROM GRB_Alarmes WHERE IDAlarme = " & Lstjour.Items.Item(iCompteur).Text & " ORDER BY Initiale", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
70: Call rstCopieAlarme.Open("SELECT * FROM GRB_Alarmes", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
75: Call rstCopieAlarme.AddNew()
					
					'Ajoute l'enregistrement
80: rstCopieAlarme.Fields("Initiale").Value = rstAlarme.Fields("Initiale").Value
85: rstCopieAlarme.Fields("Date").Value = sDate
90: rstCopieAlarme.Fields("Heure").Value = rstAlarme.Fields("Heure").Value
95: rstCopieAlarme.Fields("JourSemaine").Value = WeekDay(datDate)
100: rstCopieAlarme.Fields("Type").Value = "C"
					
105: Call rstCopieAlarme.Update()
					
					'Quitte l'écran pour ajouté ou modifié
110: fraliste.Visible = True
115: fraAlarme.Visible = False
120: frajour.Visible = False
					
125: Call rstAlarme.Close()
130: 'UPGRADE_NOTE: Object rstAlarme may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstAlarme = Nothing
					
135: Call rstCopieAlarme.Close()
140: 'UPGRADE_NOTE: Object rstCopieAlarme may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstCopieAlarme = Nothing
145: End If
150: Next 
			
			'Met à jour l'écran
155: Call RemplirFinProjet()
160: Call RemplirListerJour()
165: Call RemplirListerSemaine()
170: End If
		
175: Exit Sub
		
AfficherErreur: 
		
180: Call AfficherErreur("frmCédule", "CopierCedule", Err, Erl())
	End Sub
	
	Private Sub CopierCédule(ByVal datDate As Date)
		
5: On Error GoTo AfficherErreur
		
10: Dim sDate As String
15: Dim rstCédule As ADODB.Recordset
20: Dim rstCopieCédule As ADODB.Recordset
25: Dim iCompteur As Short
		
30: sDate = ConvertDate(datDate)
		
35: If sDate <> vbNullString Then
40: datDate = DateSerial(CInt(VB.Left(sDate, 4)), CInt(Mid(sDate, 6, 2)), CInt(VB.Right(sDate, 2)))
			
45: For iCompteur = 1 To Lstjour.Items.Count
50: 'UPGRADE_WARNING: Lower bound of collection Lstjour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If Lstjour.Items.Item(iCompteur).Selected = True Then
					'ouvre la table
55: rstCédule = New ADODB.Recordset
60: rstCopieCédule = New ADODB.Recordset
					
65: 'UPGRADE_WARNING: Lower bound of collection Lstjour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call rstCédule.Open("SELECT * FROM GRB_cédule WHERE noenreg = " & Lstjour.Items.Item(iCompteur).Text & " ORDER BY initiale", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
70: Call rstCopieCédule.Open("SELECT * FROM GRB_cédule", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
75: Call rstCopieCédule.AddNew()
					
					''''''''''''''''''''''''''
					'ajoute l'enregistrement
					''''''''''''''''''''''''''
80: rstCopieCédule.Fields("initiale").Value = rstCédule.Fields("initiale").Value
85: rstCopieCédule.Fields("date_cedulé").Value = sDate
90: rstCopieCédule.Fields("heure_début").Value = rstCédule.Fields("heure_début").Value
95: rstCopieCédule.Fields("heure_fin").Value = rstCédule.Fields("heure_fin").Value
100: rstCopieCédule.Fields("Client").Value = rstCédule.Fields("Client").Value
105: rstCopieCédule.Fields("joursemaine").Value = WeekDay(datDate)
110: rstCopieCédule.Fields("finprojet").Value = rstCédule.Fields("finprojet").Value
115: rstCopieCédule.Fields("transport").Value = rstCédule.Fields("transport").Value
					
120: Call rstCopieCédule.Update()
					
					'quitte l'écran pour ajouté ou modifié
125: fraliste.Visible = True
130: frajour.Visible = False
					
135: Call rstCédule.Close()
140: 'UPGRADE_NOTE: Object rstCédule may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstCédule = Nothing
					
145: Call rstCopieCédule.Close()
150: 'UPGRADE_NOTE: Object rstCopieCédule may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstCopieCédule = Nothing
155: End If
160: Next 
			
			'met a jour l'écran
165: Call RemplirFinProjet()
170: Call RemplirListerJour()
175: Call RemplirListerSemaine()
180: End If
		
185: Exit Sub
		
AfficherErreur: 
		
190: Call AfficherErreur("frmCédule", "CopierCedule", Err, Erl())
	End Sub
	
	Private Sub cmdCopier_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCopier.Click
		
5: On Error GoTo AfficherErreur
		
10: If Lstjour.Items.Count > 0 Then
15: mvwChoixDate.Month = MSComCtl2.MonthConstants.mvwJanuary
20: mvwChoixDate.Day = 1
			
25: mvwChoixDate.Year = mvwSelection.Year
30: mvwChoixDate.Month = mvwSelection.Month
35: mvwChoixDate.Day = mvwSelection.Day
			
40: mvwChoixDate.Visible = True
			
45: Call mvwChoixDate.Focus()
50: End If
		
55: m_bMonthViewHasFocus = False
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmCédule", "cmdCopier_Click", Err, Erl())
	End Sub
	
	Private Sub cmdEnregistrerAlarme_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEnregistrerAlarme.Click
		
5: On Error GoTo AfficherErreur
		
		'Enregistre
10: Dim rstAlarme As ADODB.Recordset
15: Dim rstEmploye As ADODB.Recordset
20: Dim iNoEmploye As Short
		
25: If mskHeure.Text <> "" Then
30: If IsDate(mskHeure.Text) Then
35: If txtMessage.Text <> "" Then
40: rstAlarme = New ADODB.Recordset
45: rstEmploye = New ADODB.Recordset
					
					'Ouvre la table
50: If m_bModeAjouter = True Then
55: Call rstAlarme.Open("SELECT * FROM GRB_Alarmes", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
						
60: m_bModeAjouter = False
						
65: Call rstAlarme.AddNew()
70: Else
75: Call rstAlarme.Open("SELECT * FROM GRB_Alarmes WHERE IDAlarme = " & Lstjour.FocusedItem.Text, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
80: End If
					
85: Call rstEmploye.Open("SELECT * FROM GRB_Employés WHERE loginname = '" & g_sUserID & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
90: iNoEmploye = rstEmploye.Fields("NoEmploye").Value
					
95: Call rstEmploye.Close()
100: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstEmploye = Nothing
					
					'Ajoute l'enregistrement
105: rstAlarme.Fields("NoEmploye").Value = iNoEmploye
110: rstAlarme.Fields("Date").Value = ConvertDate(m_datDateChoisie)
115: rstAlarme.Fields("Heure").Value = mskHeure.Text
120: rstAlarme.Fields("Message").Value = txtMessage.Text
125: rstAlarme.Fields("JourSemaine").Value = WeekDay(m_datDateChoisie)
130: rstAlarme.Fields("TypeCédule").Value = "C"
					
					'Quitte ecran pour ajouté ou modifié
135: fraliste.Visible = True
140: fraAlarme.Visible = False
145: frajour.Visible = False
					
150: Call rstAlarme.Update()
					
155: Call rstAlarme.Close()
160: 'UPGRADE_NOTE: Object rstAlarme may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstAlarme = Nothing
					
					'Met à jour l'écran
165: Call RemplirFinProjet()
170: Call RemplirListerJour()
175: Call RemplirListerSemaine()
180: Else
185: Call MsgBox("Il n'y a pas de message à afficher!", MsgBoxStyle.OKOnly, "Erreur")
190: End If
195: Else
200: Call MsgBox("L'heure est invalide!", MsgBoxStyle.OKOnly, "Erreur")
205: End If
210: Else
215: Call MsgBox("L'heure est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
220: End If
		
225: m_bMonthViewHasFocus = False
		
230: Exit Sub
		
AfficherErreur: 
		
235: Call AfficherErreur("frmCédule", "cmdEnregistrerAlarme_Click", Err, Erl())
	End Sub
	
	Private Sub cmdEnregistrerCédule_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEnregistrerCédule.Click
		
5: On Error GoTo AfficherErreur
		
		'Enregistre
10: Dim rstCédule As ADODB.Recordset
15: Dim rstEmployé As ADODB.Recordset
		
20: If cmbemployé.SelectedIndex <> -1 Then
25: rstCédule = New ADODB.Recordset
30: rstEmployé = New ADODB.Recordset
			
			'Ouvre la table
35: If m_bModeAjouter = True Then
40: Call rstCédule.Open("SELECT * FROM GRB_cédule", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
45: m_bModeAjouter = False
				
50: Call rstCédule.AddNew()
55: Else
60: 'UPGRADE_WARNING: Lower bound of collection Lstjour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				Call rstCédule.Open("SELECT * FROM GRB_cédule WHERE noenreg = " & Lstjour.Items.Item(Lstjour.FocusedItem.Index).Text & " ORDER BY initiale", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
65: End If
			
			'Ajoute l'enregistrement
70: Call rstEmployé.Open("SELECT initiale FROM GRB_employés WHERE noemploye = " & VB6.GetItemData(cmbemployé, cmbemployé.SelectedIndex), g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
75: rstCédule.Fields("initiale").Value = rstEmployé.Fields("initiale").Value
			
80: Call rstEmployé.Close()
85: 'UPGRADE_NOTE: Object rstEmployé may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstEmployé = Nothing
			
90: rstCédule.Fields("date_cedulé").Value = ConvertDate(m_datDateChoisie)
			
95: If cmbheuredébut.Text = vbNullString Then
100: rstCédule.Fields("heure_début").Value = " "
110: Else
115: rstCédule.Fields("heure_début").Value = cmbheuredébut.Text
120: End If
			
125: If cmbheurefin.Text = vbNullString Then
130: rstCédule.Fields("heure_fin").Value = " "
135: Else
140: rstCédule.Fields("heure_fin").Value = cmbheurefin.Text
145: End If
			
150: If cmbclient.Text = vbNullString Then
155: rstCédule.Fields("CLIENT").Value = " "
160: Else
165: rstCédule.Fields("CLIENT").Value = cmbclient.Text
170: End If
			
175: rstCédule.Fields("joursemaine").Value = WeekDay(m_datDateChoisie)
			
180: rstCédule.Fields("finprojet").Value = chkfin.CheckState
			
			'Enregistre le champ finprojet ou transport
185: If chkfin.CheckState = System.Windows.Forms.CheckState.Unchecked Then
190: If cmbtransport.Text = vbNullString Then
195: rstCédule.Fields("transport").Value = " "
200: Else
205: rstCédule.Fields("transport").Value = cmbtransport.Text
210: End If
215: Else
220: If txtnoprojet.Text = vbNullString Then
225: rstCédule.Fields("transport").Value = " "
230: Else
235: rstCédule.Fields("transport").Value = txtnoprojet.Text
240: End If
245: End If
			
250: Call rstCédule.Update()
			
			'Quitte ecran pour ajouté ou modifié
255: fraliste.Visible = True
260: fraAlarme.Visible = False
265: frajour.Visible = False
			
270: Call rstCédule.Close()
275: 'UPGRADE_NOTE: Object rstCédule may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstCédule = Nothing
			
			'Met à jour l'écran
280: Call RemplirFinProjet()
285: Call RemplirListerJour()
290: Call RemplirListerSemaine()
295: Else
300: Call MsgBox("Aucun employé de sélectionné!")
305: End If
		
310: m_bMonthViewHasFocus = False
		
315: Exit Sub
		
AfficherErreur: 
		
320: Call AfficherErreur("frmCédule", "cmdEnregistrerCédule_Click", Err, Erl())
	End Sub
	
	Private Sub cmdsupprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdsupprimer.Click
		
5: On Error GoTo AfficherErreur
		
		'Supprime la cédule selectionnée
10: Dim iCompteur As Short
		
15: If Lstjour.Items.Count > 0 Then
20: If MsgBox("Voulez-vous supprimer ce(ces) rendez-vous?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
25: For iCompteur = 1 To Lstjour.Items.Count
30: 'UPGRADE_WARNING: Lower bound of collection Lstjour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If Lstjour.Items.Item(iCompteur).Selected = True Then
35: 'UPGRADE_WARNING: Lower bound of collection Lstjour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If Lstjour.Items.Item(iCompteur).Tag = "A" Then
40: 'UPGRADE_WARNING: Lower bound of collection Lstjour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							Call g_connData.Execute("DELETE * FROM GRB_Alarmes WHERE IDAlarme = " & Lstjour.Items.Item(iCompteur).Text)
45: Else
50: 'UPGRADE_WARNING: Lower bound of collection Lstjour.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							Call g_connData.Execute("DELETE * FROM GRB_Cédule WHERE noenreg = " & Lstjour.Items.Item(iCompteur).Text)
55: End If
60: End If
65: Next 
				
				'Mise à jour des ListViews
70: Call RemplirFinProjet()
75: Call RemplirListerJour()
80: Call RemplirListerSemaine()
85: End If
90: End If
		
95: m_bMonthViewHasFocus = False
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmCédule", "cmdSupprimer_Click", Err, Erl())
	End Sub
	
	Private Sub cmdTransport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTransport.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstTransport As ADODB.Recordset
15: Dim sTransport As String
20: Dim iCompteur As Short
		
25: sTransport = cmbtransport.Text
		
		'Si'l y a un transport
30: If cmbtransport.Text <> vbNullString Then
			'Si le transport existe, on demande si on veut le supprimer
			'sinon, on demande si on veut l'ajouter
35: If ComboContient(cmbtransport, sTransport) Then
				'Si réponse oui pour supprimer
40: If MsgBox("Voulez-vous supprimer le transport " & cmbtransport.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
45: Call g_connData.Execute("DELETE * FROM GRB_transport WHERE transport = '" & Replace(cmbtransport.Text, "'", "''") & "'")
50: Else
					'Sinon demande si veut ajouter un nouveau transport
55: If MsgBox("Voulez-vous ajouter un transport?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
60: sTransport = InputBox("Veuillez entrer son nom!")
						
						'Si quelque chose d'entrer
65: If sTransport <> vbNullString Then
70: If Not ComboContient(cmbtransport, sTransport) Then
75: rstTransport = New ADODB.Recordset
								
80: Call rstTransport.Open("SELECT * FROM GRB_Transport", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
								
85: Call rstTransport.AddNew()
								
90: rstTransport.Fields("transport").Value = sTransport
								
95: Call rstTransport.Update()
								
100: Call rstTransport.Close()
105: 'UPGRADE_NOTE: Object rstTransport may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
								rstTransport = Nothing
110: Else
115: Call MsgBox("Ce transport existe déjà!")
120: End If
125: End If
130: End If
135: End If
140: Else
				'Demande si veut ajouter un nouveau transport
145: If MsgBox("Voulez-vous ajouter un transport?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
150: sTransport = InputBox("Veuillez entrer son nom!")
					
					'Si quelque chose d'entrer
155: If sTransport <> vbNullString Then
160: If Not ComboContient(cmbtransport, sTransport) Then
165: rstTransport = New ADODB.Recordset
							
170: Call rstTransport.Open("SELECT * FROM GRB_transport", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
							
175: Call rstTransport.AddNew()
180: rstTransport.Fields("transport").Value = sTransport
							
185: Call rstTransport.Update()
							
190: Call rstTransport.Close()
195: 'UPGRADE_NOTE: Object rstTransport may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
							rstTransport = Nothing
200: Else
205: Call MsgBox("Ce transport existe déjà!")
210: End If
215: End If
220: End If
225: End If
230: Else
			'Demande si veut ajouter un nouveau transport
235: If MsgBox("Voulez-vous ajouter un transport?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
240: sTransport = InputBox("Veuillez entrer son nom!")
				
				'Si quelque chose d'entrer
245: If sTransport <> vbNullString Then
250: If Not ComboContient(cmbtransport, sTransport) Then
255: rstTransport = New ADODB.Recordset
						
260: Call rstTransport.Open("SELECT * FROM GRB_transport", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
						
265: Call rstTransport.AddNew()
						
270: rstTransport.Fields("transport").Value = sTransport
						
275: Call rstTransport.Update()
						
280: Call rstTransport.Close()
285: 'UPGRADE_NOTE: Object rstTransport may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						rstTransport = Nothing
290: Else
295: Call MsgBox("Ce transport existe déjà!")
300: End If
305: End If
310: End If
315: End If
		
		'Remplis combo transport
320: Call RemplirTransport()
		
325: For iCompteur = 0 To cmbtransport.Items.Count - 1
330: If VB6.GetItemString(cmbtransport, iCompteur) = sTransport Then
335: cmbtransport.SelectedIndex = iCompteur
				
340: Exit For
345: End If
350: Next 
		
355: If cmbtransport.SelectedIndex = -1 Then
360: cmbtransport.SelectedIndex = 0
365: End If
		
370: m_bMonthViewHasFocus = False
		
375: Exit Sub
		
AfficherErreur: 
		
380: Call AfficherErreur("frmCédule", "cmdtransport_Click", Err, Erl())
	End Sub
	
	Private Sub frmCédule_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: mvwSelection.StartOfWeek = MSComCtl2.DayConstants.mvwSunday
		
20: g_bCeduleOuverte = True
		
		'Met à jour l'écran
25: mvwSelection.Year = Year(Today)
30: mvwSelection.Month = Month(Today)
35: mvwSelection.Day = VB.Day(Today)
		
40: m_datDateChoisie = Today
		
		'Rempli les combos
45: Call RemplirListerEmployé()
50: Call RemplirTransport()
55: Call RemplirListerClient()
60: Call RemplirFinProjet()
		
		'Rempli les ListViews
65: Call RemplirListerJour()
70: Call RemplirListerSemaine()
		
		'Sélectionne le jour de la semaine
75: For iCompteur = 1 To 7
80: If CDate(lstjoursemaine(iCompteur).Tag) = m_datDateChoisie Then
85: lstjoursemaine(iCompteur).BackColor = System.Drawing.ColorTranslator.FromOle(&HE0E0E0)
90: Else
95: lstjoursemaine(iCompteur).BackColor = System.Drawing.ColorTranslator.FromOle(&HFFFFFF)
100: End If
105: Next 
		
110: Call AfficherTransport()
		
115: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
120: Exit Sub
		
AfficherErreur: 
		
125: Call AfficherErreur("frmCédule", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub RemplirFinProjet()
		
5: On Error GoTo AfficherErreur
		
		'Remplis le combo transport
10: Dim rstCedule As ADODB.Recordset
		
15: rstCedule = New ADODB.Recordset
		
20: Call rstCedule.Open("SELECT date_cedulé, transport FROM GRB_cédule WHERE finprojet = 1 ORDER BY date_cedulé", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: Call cmbfinprojet.Items.Clear()
		
		'Rempli tant il y a des employé
30: Do While Not rstCedule.EOF
35: System.Windows.Forms.Application.DoEvents()
			
40: Call cmbfinprojet.Items.Add(Trim(CStr(rstCedule.Fields("transport").Value)) & "     " & ConvertDate(rstCedule.Fields("date_cedulé").Value))
			
45: Call rstCedule.MoveNext()
50: Loop 
		
55: Call rstCedule.Close()
60: 'UPGRADE_NOTE: Object rstCedule may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstCedule = Nothing
		
		'S'il y a des enregistrements, on sélectionne le premier
65: If cmbfinprojet.Items.Count > 0 Then
70: cmbfinprojet.SelectedIndex = 0
75: End If
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmCédule", "RemplirFinProjet", Err, Erl())
	End Sub
	
	Private Sub RemplirTransport()
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''
		'remplis combo transport
		''''''''''''''''''''''''
10: Dim rstTransport As ADODB.Recordset
		
15: rstTransport = New ADODB.Recordset
		
20: Call rstTransport.Open("SELECT * FROM GRB_transport ORDER BY transport", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: Call cmbtransport.Items.Clear()
		
		'rempli tant il y a des employé
30: Do While Not rstTransport.EOF
35: Call cmbtransport.Items.Add(rstTransport.Fields("transport").Value)
			
40: Call rstTransport.MoveNext()
45: Loop 
		
50: Call rstTransport.Close()
55: 'UPGRADE_NOTE: Object rstTransport may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstTransport = Nothing
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmCédule", "RemplirTransport", Err, Erl())
	End Sub
	
	Private Sub RemplirListerEmployé()
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''''''
		' Remplis combo employé '
		'''''''''''''''''''''''''
10: Dim rstEmploye As ADODB.Recordset
		
15: rstEmploye = New ADODB.Recordset
		
20: Call rstEmploye.Open("SELECT * FROM GRB_employés WHERE Actif = True ORDER BY employe", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: Call cmbemployé.Items.Clear()
		
		'rempli tant il y a des employé
30: Do While Not rstEmploye.EOF
35: Call cmbemployé.Items.Add(rstEmploye.Fields("employe").Value)
40: 'UPGRADE_ISSUE: ComboBox property cmbemployé.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbemployé, cmbemployé.NewIndex, rstEmploye.Fields("noEmploye").Value)
			
45: Call rstEmploye.MoveNext()
50: Loop 
		
55: Call rstEmploye.Close()
60: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmCédule", "RemplirListerEmployé", Err, Erl())
	End Sub
	
	Private Sub RemplirListerClient()
		
5: On Error GoTo AfficherErreur
		
		'remplis combo employé
10: Dim rstClient As ADODB.Recordset
		
15: rstClient = New ADODB.Recordset
		
20: Call rstClient.Open("SELECT * FROM GRB_Client WHERE Supprimé = False ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: Call cmbclient.Items.Clear()
		
		'rempli tant il y a des employé
30: Do While Not rstClient.EOF
35: Call cmbclient.Items.Add(rstClient.Fields("nomclient").Value)
			
40: Call rstClient.MoveNext()
45: Loop 
		
50: Call rstClient.Close()
55: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient = Nothing
		
60: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmCédule", "RemplirListerClient", Err, Erl())
	End Sub
	
	Public Sub RemplirListerJour()
		
5: On Error GoTo AfficherErreur
		
		'Remplis lister une journée
10: Dim rstCédule As ADODB.Recordset
15: Dim itmCedule As System.Windows.Forms.ListViewItem
		
		'Vide le lister
20: Call Lstjour.Items.Clear()
		
25: rstCédule = New ADODB.Recordset
		
30: Call rstCédule.Open("SELECT * FROM GRB_cédule WHERE date_cedulé = '" & ConvertDate(m_datDateChoisie) & "' ORDER BY initiale", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant il y a de employé cedulé , ajoute dans lister
35: Do While Not rstCédule.EOF
40: 'UPGRADE_ISSUE: MSComctlLib.ListItems method Lstjour.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmCedule = Lstjour.Items.Add()
			
45: itmCedule.Text = rstCédule.Fields("noenreg").Value
			
50: itmCedule.Tag = "C"
			
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstCédule.Fields("Initiale").Value) Then
60: 'UPGRADE_WARNING: Lower bound of collection itmCedule has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmCedule.SubItems.Count > I_LVW_JOUR_NOM Then
					itmCedule.SubItems(I_LVW_JOUR_NOM).Text = rstCédule.Fields("Initiale").Value
				Else
					itmCedule.SubItems.Insert(I_LVW_JOUR_NOM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstCédule.Fields("Initiale").Value))
				End If
65: Else
70: 'UPGRADE_WARNING: Lower bound of collection itmCedule has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmCedule.SubItems.Count > I_LVW_JOUR_NOM Then
					itmCedule.SubItems(I_LVW_JOUR_NOM).Text = ""
				Else
					itmCedule.SubItems.Insert(I_LVW_JOUR_NOM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
				End If
75: End If
			
80: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstCédule.Fields("heure_début").Value) Then
85: 'UPGRADE_WARNING: Lower bound of collection itmCedule has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmCedule.SubItems.Count > I_LVW_JOUR_DEBUT Then
					itmCedule.SubItems(I_LVW_JOUR_DEBUT).Text = rstCédule.Fields("heure_début").Value
				Else
					itmCedule.SubItems.Insert(I_LVW_JOUR_DEBUT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstCédule.Fields("heure_début").Value))
				End If
90: Else
95: 'UPGRADE_WARNING: Lower bound of collection itmCedule has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmCedule.SubItems.Count > I_LVW_JOUR_DEBUT Then
					itmCedule.SubItems(I_LVW_JOUR_DEBUT).Text = ""
				Else
					itmCedule.SubItems.Insert(I_LVW_JOUR_DEBUT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
				End If
100: End If
			
105: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstCédule.Fields("heure_fin").Value) Then
110: 'UPGRADE_WARNING: Lower bound of collection itmCedule has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmCedule.SubItems.Count > I_LVW_JOUR_FIN Then
					itmCedule.SubItems(I_LVW_JOUR_FIN).Text = rstCédule.Fields("heure_fin").Value
				Else
					itmCedule.SubItems.Insert(I_LVW_JOUR_FIN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstCédule.Fields("heure_fin").Value))
				End If
115: Else
120: 'UPGRADE_WARNING: Lower bound of collection itmCedule has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmCedule.SubItems.Count > I_LVW_JOUR_FIN Then
					itmCedule.SubItems(I_LVW_JOUR_FIN).Text = ""
				Else
					itmCedule.SubItems.Insert(I_LVW_JOUR_FIN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
				End If
125: End If
			
130: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstCédule.Fields("CLIENT").Value) Then
135: 'UPGRADE_WARNING: Lower bound of collection itmCedule has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmCedule.SubItems.Count > I_LVW_JOUR_CLIENT Then
					itmCedule.SubItems(I_LVW_JOUR_CLIENT).Text = rstCédule.Fields("CLIENT").Value
				Else
					itmCedule.SubItems.Insert(I_LVW_JOUR_CLIENT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstCédule.Fields("CLIENT").Value))
				End If
140: Else
145: 'UPGRADE_WARNING: Lower bound of collection itmCedule has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmCedule.SubItems.Count > I_LVW_JOUR_CLIENT Then
					itmCedule.SubItems(I_LVW_JOUR_CLIENT).Text = ""
				Else
					itmCedule.SubItems.Insert(I_LVW_JOUR_CLIENT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
				End If
150: End If
			
			'si fin de projet marque numero de projet sinon transport
155: If rstCédule.Fields("finprojet").Value = 0 Then
160: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstCédule.Fields("transport").Value) Then
165: 'UPGRADE_WARNING: Lower bound of collection itmCedule has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmCedule.SubItems.Count > I_LVW_JOUR_TRANSPORT Then
						itmCedule.SubItems(I_LVW_JOUR_TRANSPORT).Text = rstCédule.Fields("transport").Value
					Else
						itmCedule.SubItems.Insert(I_LVW_JOUR_TRANSPORT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstCédule.Fields("transport").Value))
					End If
170: Else
175: 'UPGRADE_WARNING: Lower bound of collection itmCedule has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmCedule.SubItems.Count > I_LVW_JOUR_TRANSPORT Then
						itmCedule.SubItems(I_LVW_JOUR_TRANSPORT).Text = ""
					Else
						itmCedule.SubItems.Insert(I_LVW_JOUR_TRANSPORT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
					End If
180: End If
				
				'met en rouge ou en noir dépendant si fin de projet
185: 'UPGRADE_WARNING: Lower bound of collection itmCedule.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmCedule.SubItems.Item(I_LVW_JOUR_NOM).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
190: 'UPGRADE_WARNING: Lower bound of collection itmCedule.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmCedule.SubItems.Item(I_LVW_JOUR_DEBUT).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
195: 'UPGRADE_WARNING: Lower bound of collection itmCedule.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmCedule.SubItems.Item(I_LVW_JOUR_FIN).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
200: 'UPGRADE_WARNING: Lower bound of collection itmCedule.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmCedule.SubItems.Item(I_LVW_JOUR_CLIENT).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
205: 'UPGRADE_WARNING: Lower bound of collection itmCedule.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmCedule.SubItems.Item(I_LVW_JOUR_TRANSPORT).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
210: Else
215: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstCédule.Fields("transport").Value) Then
220: 'UPGRADE_WARNING: Lower bound of collection itmCedule has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmCedule.SubItems.Count > I_LVW_JOUR_TRANSPORT Then
						itmCedule.SubItems(I_LVW_JOUR_TRANSPORT).Text = "Fin " + rstCédule.Fields("transport").Value
					Else
						itmCedule.SubItems.Insert(I_LVW_JOUR_TRANSPORT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Fin " + rstCédule.Fields("transport").Value))
					End If
225: Else
230: 'UPGRADE_WARNING: Lower bound of collection itmCedule has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmCedule.SubItems.Count > I_LVW_JOUR_TRANSPORT Then
						itmCedule.SubItems(I_LVW_JOUR_TRANSPORT).Text = "Fin"
					Else
						itmCedule.SubItems.Insert(I_LVW_JOUR_TRANSPORT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Fin"))
					End If
235: End If
				
				'Met en rouge ou en noir dépendant si fin de projet
240: 'UPGRADE_WARNING: Lower bound of collection itmCedule.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmCedule.SubItems.Item(I_LVW_JOUR_NOM).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_ROUGE)
245: 'UPGRADE_WARNING: Lower bound of collection itmCedule.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmCedule.SubItems.Item(I_LVW_JOUR_DEBUT).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_ROUGE)
250: 'UPGRADE_WARNING: Lower bound of collection itmCedule.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmCedule.SubItems.Item(I_LVW_JOUR_FIN).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_ROUGE)
255: 'UPGRADE_WARNING: Lower bound of collection itmCedule.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmCedule.SubItems.Item(I_LVW_JOUR_CLIENT).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_ROUGE)
260: 'UPGRADE_WARNING: Lower bound of collection itmCedule.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmCedule.SubItems.Item(I_LVW_JOUR_TRANSPORT).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_ROUGE)
265: End If
			
270: Call rstCédule.MoveNext()
275: Loop 
		
280: Call rstCédule.Close()
285: 'UPGRADE_NOTE: Object rstCédule may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstCédule = Nothing
		
290: Call RemplirListerJourAlarme()
		
295: Exit Sub
		
AfficherErreur: 
		
300: Call AfficherErreur("frmCédule", "RemplirListerJour", Err, Erl())
	End Sub
	
	Public Sub RemplirListerSemaine()
		
5: On Error GoTo AfficherErreur
		
		'Remplis une semaine
10: Dim rstCédule As ADODB.Recordset
15: Dim iJourSemaine As Short
20: Dim datPremiereDate As Date
25: Dim datDerniereDate As Date
30: Dim iCompteur As Short
35: Dim sHeureDebutFin As String
40: Dim itmSemaine As System.Windows.Forms.ListViewItem
		
45: For iCompteur = 1 To 7
			'couleur par defaut entete de date
50: lbljour(iCompteur - 1).ForeColor = System.Drawing.Color.White
55: lbljourstr(iCompteur - 1).ForeColor = System.Drawing.Color.White
			
60: Call lstjoursemaine(iCompteur).Items.Clear()
65: Next 
		
70: iJourSemaine = WeekDay(m_datDateChoisie)
75: datPremiereDate = m_datDateChoisie
80: datDerniereDate = m_datDateChoisie
		
		'trouve premiere date de la semaine
85: Do While Not WeekDay(datPremiereDate) = 1
90: datPremiereDate = System.Date.FromOADate(datPremiereDate.ToOADate - 1)
95: Loop 
		
		'trouve derniere date de la semaine
100: Do While Not WeekDay(datDerniereDate) = 7
105: datDerniereDate = System.Date.FromOADate(datDerniereDate.ToOADate + 1)
110: Loop 
		
		'selectionne la semaine courante
115: rstCédule = New ADODB.Recordset
		
120: Call rstCédule.Open("SELECT * FROM GRB_cédule WHERE cdate(date_cedulé) <= cdate('" & CStr(datDerniereDate) & "') AND cdate(date_cedulé) >= cdate('" & CStr(datPremiereDate) & "') ORDER BY initiale", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
125: For iCompteur = 1 To 7
			'pour ecrire le jour
130: lbljour(iCompteur - 1).Text = CStr(VB.Day(System.Date.FromOADate(datPremiereDate.ToOADate + iCompteur - 1)))
			
			'garde en memoire la date des lister
135: lstjoursemaine(iCompteur).Tag = CStr(System.Date.FromOADate(datPremiereDate.ToOADate + iCompteur - 1))
140: Next 
		
145: Do While Not rstCédule.EOF
			'ajoute dans le lister, dépendant le jour de la semaine
150: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lstjoursemaine.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmSemaine = lstjoursemaine(rstCédule.Fields("joursemaine")).Items.Add()
			
155: itmSemaine.Text = rstCédule.Fields("noenreg").Value
			
			'si fin de projet marque numero de projet sinon transport
160: If rstCédule.Fields("finprojet").Value = 0 Then
165: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstCédule.Fields("Initiale").Value) Then
170: 'UPGRADE_WARNING: Lower bound of collection itmSemaine has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmSemaine.SubItems.Count > I_LVW_SEMAINE_NOM Then
						itmSemaine.SubItems(I_LVW_SEMAINE_NOM).Text = rstCédule.Fields("Initiale").Value
					Else
						itmSemaine.SubItems.Insert(I_LVW_SEMAINE_NOM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstCédule.Fields("Initiale").Value))
					End If
175: Else
180: 'UPGRADE_WARNING: Lower bound of collection itmSemaine has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmSemaine.SubItems.Count > I_LVW_SEMAINE_NOM Then
						itmSemaine.SubItems(I_LVW_SEMAINE_NOM).Text = ""
					Else
						itmSemaine.SubItems.Insert(I_LVW_SEMAINE_NOM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
					End If
185: End If
				
190: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstCédule.Fields("heure_début").Value) Then
195: sHeureDebutFin = Trim(rstCédule.Fields("heure_début").Value + "-")
200: Else
205: sHeureDebutFin = "-"
210: End If
				
215: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstCédule.Fields("heure_fin").Value) Then
220: sHeureDebutFin = sHeureDebutFin + rstCédule.Fields("heure_fin").Value
225: Else
230: sHeureDebutFin = sHeureDebutFin & " "
235: End If
				
240: 'UPGRADE_WARNING: Lower bound of collection itmSemaine has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmSemaine.SubItems.Count > I_LVW_SEMAINE_HEURE Then
					itmSemaine.SubItems(I_LVW_SEMAINE_HEURE).Text = sHeureDebutFin
				Else
					itmSemaine.SubItems.Insert(I_LVW_SEMAINE_HEURE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sHeureDebutFin))
				End If
				
				'met en noir
245: 'UPGRADE_WARNING: Lower bound of collection itmSemaine.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmSemaine.SubItems.Item(I_LVW_SEMAINE_NOM).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
250: 'UPGRADE_WARNING: Lower bound of collection itmSemaine.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmSemaine.SubItems.Item(I_LVW_SEMAINE_HEURE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
255: Else
260: 'UPGRADE_WARNING: Lower bound of collection itmSemaine has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmSemaine.SubItems.Count > I_LVW_SEMAINE_NOM Then
					itmSemaine.SubItems(I_LVW_SEMAINE_NOM).Text = "Fin"
				Else
					itmSemaine.SubItems.Insert(I_LVW_SEMAINE_NOM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Fin"))
				End If
				
265: lbljour(rstCédule.Fields("joursemaine").Value - 1).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_ROUGE)
270: lbljourstr(rstCédule.Fields("joursemaine").Value - 1).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_ROUGE)
				
275: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstCédule.Fields("transport").Value) Then
280: sHeureDebutFin = rstCédule.Fields("transport").Value
285: Else
290: sHeureDebutFin = " "
295: End If
				
300: 'UPGRADE_WARNING: Lower bound of collection itmSemaine has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmSemaine.SubItems.Count > I_LVW_SEMAINE_HEURE Then
					itmSemaine.SubItems(I_LVW_SEMAINE_HEURE).Text = sHeureDebutFin
				Else
					itmSemaine.SubItems.Insert(I_LVW_SEMAINE_HEURE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sHeureDebutFin))
				End If
				
				'met en rouge
305: 'UPGRADE_WARNING: Lower bound of collection itmSemaine.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmSemaine.SubItems.Item(I_LVW_SEMAINE_NOM).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_ROUGE)
310: 'UPGRADE_WARNING: Lower bound of collection itmSemaine.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmSemaine.SubItems.Item(I_LVW_SEMAINE_HEURE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_ROUGE)
315: End If
			
320: Call rstCédule.MoveNext()
325: Loop 
		
330: Call rstCédule.Close()
335: 'UPGRADE_NOTE: Object rstCédule may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstCédule = Nothing
		
340: Call RemplirListerSemaineAlarme()
		
345: Exit Sub
		
AfficherErreur: 
		
350: Call AfficherErreur("frmCédule", "RemplirListerSemaine", Err, Erl())
	End Sub
	
	Private Sub RemplirListerJourAlarme()
		
5: On Error GoTo AfficherErreur
		
		'Remplis lister une journée
10: Dim rstAlarme As ADODB.Recordset
15: Dim rstEmploye As ADODB.Recordset
20: Dim iNoEmploye As Short
25: Dim itmAlarme As System.Windows.Forms.ListViewItem
		
30: rstEmploye = New ADODB.Recordset
		
35: Call rstEmploye.Open("SELECT * FROM GRB_Employés WHERE loginname = '" & g_sUserID & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
40: iNoEmploye = rstEmploye.Fields("NoEmploye").Value
		
45: Call rstEmploye.Close()
50: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
55: rstAlarme = New ADODB.Recordset
		
60: Call rstAlarme.Open("SELECT * FROM GRB_Alarmes WHERE Date = '" & ConvertDate(m_datDateChoisie) & "' AND NoEmploye = " & iNoEmploye & " AND TypeCédule = 'C' ORDER BY Date, Heure", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant il y a de employé cedulé , ajoute dans lister
65: Do While Not rstAlarme.EOF
70: 'UPGRADE_ISSUE: MSComctlLib.ListItems method Lstjour.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmAlarme = Lstjour.Items.Add()
			
75: itmAlarme.Text = (rstAlarme.Fields("IDAlarme")).Value
80: itmAlarme.Tag = "A"
			
85: 'UPGRADE_WARNING: Lower bound of collection itmAlarme has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAlarme.SubItems.Count > I_LVW_JOUR_NOM Then
				itmAlarme.SubItems(I_LVW_JOUR_NOM).Text = g_sInitiale
			Else
				itmAlarme.SubItems.Insert(I_LVW_JOUR_NOM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, g_sInitiale))
			End If
			
90: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAlarme.Fields("Heure").Value) Then
95: 'UPGRADE_WARNING: Lower bound of collection itmAlarme has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAlarme.SubItems.Count > I_LVW_JOUR_DEBUT Then
					itmAlarme.SubItems(I_LVW_JOUR_DEBUT).Text = rstAlarme.Fields("Heure").Value
				Else
					itmAlarme.SubItems.Insert(I_LVW_JOUR_DEBUT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAlarme.Fields("Heure").Value))
				End If
100: Else
105: 'UPGRADE_WARNING: Lower bound of collection itmAlarme has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAlarme.SubItems.Count > I_LVW_JOUR_DEBUT Then
					itmAlarme.SubItems(I_LVW_JOUR_DEBUT).Text = ""
				Else
					itmAlarme.SubItems.Insert(I_LVW_JOUR_DEBUT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
				End If
110: End If
			
			'Met en rouge ou en noir dépendant si fin de projet
115: 'UPGRADE_WARNING: Lower bound of collection itmAlarme.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAlarme.SubItems.Item(I_LVW_JOUR_NOM).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_BLEU)
120: 'UPGRADE_WARNING: Lower bound of collection itmAlarme.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAlarme.SubItems.Item(I_LVW_JOUR_DEBUT).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_BLEU)
			
125: Call rstAlarme.MoveNext()
130: Loop 
		
135: Call rstAlarme.Close()
140: 'UPGRADE_NOTE: Object rstAlarme may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAlarme = Nothing
		
145: Exit Sub
		
AfficherErreur: 
		
150: Call AfficherErreur("frmCédule", "RemplirListerJourAlarme", Err, Erl())
	End Sub
	
	Private Sub RemplirListerSemaineAlarme()
		
5: On Error GoTo AfficherErreur
		
		'Remplis une semaine
10: Dim rstAlarme As ADODB.Recordset
15: Dim rstEmploye As ADODB.Recordset
20: Dim iNoEmploye As Short
25: Dim iJourSemaine As Short
30: Dim datPremiereDate As Date
35: Dim datDerniereDate As Date
40: Dim iCompteur As Short
45: Dim itmSemaine As System.Windows.Forms.ListViewItem
		
50: iJourSemaine = WeekDay(m_datDateChoisie)
55: datPremiereDate = m_datDateChoisie
60: datDerniereDate = m_datDateChoisie
		
		'Trouve première date de la semaine
65: Do While Not WeekDay(datPremiereDate) = 1
70: datPremiereDate = System.Date.FromOADate(datPremiereDate.ToOADate - 1)
75: Loop 
		
		'Trouve dernière date de la semaine
80: Do While Not WeekDay(datDerniereDate) = 7
85: datDerniereDate = System.Date.FromOADate(datDerniereDate.ToOADate + 1)
90: Loop 
		
95: rstEmploye = New ADODB.Recordset
		
100: Call rstEmploye.Open("SELECT * FROM GRB_Employés WHERE loginname = '" & g_sUserID & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
105: iNoEmploye = rstEmploye.Fields("NoEmploye").Value
		
110: Call rstEmploye.Close()
115: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
		'Sélectionne la semaine courante
120: rstAlarme = New ADODB.Recordset
		
125: Call rstAlarme.Open("SELECT * FROM GRB_Alarmes WHERE Date BETWEEN '" & ConvertDate(datPremiereDate) & "' AND '" & ConvertDate(datDerniereDate) & "' AND NoEmploye = " & iNoEmploye & " AND TypeCédule = 'C' ORDER BY Date, Heure", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'iSemaine est le numero du lister, jour de semaine
130: For iCompteur = 1 To 7
			'pour ecrire le jour
135: lbljour(iCompteur - 1).Text = CStr(VB.Day(System.Date.FromOADate(datPremiereDate.ToOADate + iCompteur - 1)))
			
			'garde en memoire la date des lister
140: lstjoursemaine(iCompteur).Tag = CStr(System.Date.FromOADate(datPremiereDate.ToOADate + iCompteur - 1))
145: Next 
		
150: Do While Not rstAlarme.EOF
			'ajoute dans le lister, dépendant le jour de la semaine
155: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lstjoursemaine.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmSemaine = lstjoursemaine(rstAlarme.Fields("JourSemaine")).Items.Add()
			
160: itmSemaine.Text = rstAlarme.Fields("IDAlarme").Value
			
			'si fin de projet marque numero de projet sinon transport
165: 'UPGRADE_WARNING: Lower bound of collection itmSemaine has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmSemaine.SubItems.Count > I_LVW_SEMAINE_NOM Then
				itmSemaine.SubItems(I_LVW_SEMAINE_NOM).Text = g_sInitiale
			Else
				itmSemaine.SubItems.Insert(I_LVW_SEMAINE_NOM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, g_sInitiale))
			End If
			
170: 'UPGRADE_WARNING: Lower bound of collection itmSemaine has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmSemaine.SubItems.Count > I_LVW_SEMAINE_HEURE Then
				itmSemaine.SubItems(I_LVW_SEMAINE_HEURE).Text = rstAlarme.Fields("Heure").Value
			Else
				itmSemaine.SubItems.Insert(I_LVW_SEMAINE_HEURE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAlarme.Fields("Heure").Value))
			End If
			
			'met en noir
175: 'UPGRADE_WARNING: Lower bound of collection itmSemaine.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmSemaine.SubItems.Item(I_LVW_SEMAINE_NOM).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_BLEU)
180: 'UPGRADE_WARNING: Lower bound of collection itmSemaine.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmSemaine.SubItems.Item(I_LVW_SEMAINE_HEURE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_BLEU)
			
185: Call rstAlarme.MoveNext()
190: Loop 
		
195: Call rstAlarme.Close()
200: 'UPGRADE_NOTE: Object rstAlarme may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAlarme = Nothing
		
205: Exit Sub
		
AfficherErreur: 
		
210: Call AfficherErreur("frmCédule", "RemplirListerSemaineAlarme", Err, Erl())
	End Sub
	
	Private Sub frmCédule_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		
5: On Error GoTo AfficherErreur
		
10: g_bCeduleOuverte = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmCédule", "Form_Unload", Err, Erl())
	End Sub
	
	Private Sub Lstjour_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Lstjour.DoubleClick
		
5: On Error GoTo AfficherErreur
		
10: Dim rstCédule As ADODB.Recordset
15: Dim rstAlarme As ADODB.Recordset
20: Dim rstEmployé As ADODB.Recordset
25: Dim iCompteur As Short
		
		'Affiche en mode modification
30: m_bModeAjouter = False
		
35: If Lstjour.Items.Count > 0 Then
40: fraliste.Visible = False
			
45: If Lstjour.FocusedItem.Tag = "C" Then
50: frajour.Visible = True
55: fraAlarme.Visible = False
				
				'Ouvre la table
60: rstCédule = New ADODB.Recordset
65: rstEmployé = New ADODB.Recordset
				
70: Call rstCédule.Open("SELECT * FROM GRB_cédule WHERE noenreg = " & Lstjour.FocusedItem.Text & " ORDER BY initiale", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
75: Call rstEmployé.Open("SELECT * FROM GRB_employés WHERE initiale = '" & rstCédule.Fields("initiale").Value & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
				'si il y a employé, affiche a l'écran pour modification
80: If Not rstEmployé.EOF Then
85: For iCompteur = 0 To cmbemployé.Items.Count - 1
90: If VB6.GetItemString(cmbemployé, iCompteur) = rstEmployé.Fields("Employe").Value Then
95: cmbemployé.SelectedIndex = iCompteur
							
100: Exit For
105: End If
110: Next 
					
115: cmbheuredébut.Text = rstCédule.Fields("heure_début").Value
120: cmbheurefin.Text = rstCédule.Fields("heure_fin").Value
					
125: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If IsDbNull(rstCédule.Fields("CLIENT").Value) Then
130: cmbclient.Text = " "
135: Else
140: cmbclient.Text = rstCédule.Fields("CLIENT").Value
145: End If
					
150: chkfin.CheckState = rstCédule.Fields("finprojet").Value
					
155: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If IsDbNull(rstCédule.Fields("transport").Value) Then
160: cmbtransport.Text = " "
165: Else
170: cmbtransport.Text = rstCédule.Fields("transport").Value
175: End If
					
180: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If IsDbNull(rstCédule.Fields("transport").Value) Then
185: txtnoprojet.Text = " "
190: Else
195: txtnoprojet.Text = rstCédule.Fields("transport").Value
200: End If
					
					'Affiche fin de projet ou transport
205: If chkfin.CheckState = System.Windows.Forms.CheckState.Unchecked Then
210: Call AfficherTransport()
215: Else
220: Call AfficherProjet()
225: End If
230: End If
				
235: Call rstCédule.Close()
240: 'UPGRADE_NOTE: Object rstCédule may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstCédule = Nothing
				
245: Call rstEmployé.Close()
250: 'UPGRADE_NOTE: Object rstEmployé may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstEmployé = Nothing
255: Else
260: frajour.Visible = False
265: fraAlarme.Visible = True
				
270: mskHeure.Text = ""
275: txtMessage.Text = ""
				
				'Ouvre la table
280: rstAlarme = New ADODB.Recordset
				
285: Call rstAlarme.Open("SELECT * FROM GRB_Alarmes WHERE IDAlarme = " & Lstjour.FocusedItem.Text & " ORDER BY NoEmploye", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
290: mskHeure.Text = rstAlarme.Fields("Heure").Value
				
295: txtMessage.Text = rstAlarme.Fields("Message").Value
				
300: Call rstAlarme.Close()
305: 'UPGRADE_NOTE: Object rstAlarme may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstAlarme = Nothing
310: End If
315: Else
320: fraliste.Visible = True
325: frajour.Visible = False
330: End If
		
335: Exit Sub
		
AfficherErreur: 
		
340: Call AfficherErreur("frmCédule", "Lstjour_DblClick", Err, Erl())
	End Sub
	
	Private Sub Lstjour_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Lstjour.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: If Lstjour.Items.Count > 0 Then
15: If KeyCode = System.Windows.Forms.Keys.Delete Then
20: If MsgBox("Voulez-vous supprimer cette enregistrement?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
25: If Lstjour.FocusedItem.Tag = "A" Then
30: Call g_connData.Execute("DELETE * FROM GRB_Alarmes WHERE IDAlarme = " & Lstjour.FocusedItem.Text)
35: Else
40: Call g_connData.Execute("DELETE * FROM GRB_Cédule WHERE noenreg = " & Lstjour.FocusedItem.Text)
45: End If
					
					'Mise à jour des lister
50: Call RemplirFinProjet()
55: Call RemplirListerJour()
60: Call RemplirListerSemaine()
65: End If
70: End If
75: End If
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmCédule", "Lstjour_KeyDown", Err, Erl())
	End Sub
	
	Private Sub lstjoursemaine_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstjoursemaine.Click
		Dim Index As Short = lstjoursemaine.GetIndex(eventSender)
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim sDate As String
20: Dim iNbreJour As Short
		
		'Initialise la couleur en blanc
25: For iCompteur = 1 To 7
30: lstjoursemaine(iCompteur).BackColor = System.Drawing.ColorTranslator.FromOle(&HFFFFFF)
35: Next 
		
		'Sélectionne jour de semaine
40: lstjoursemaine(Index).BackColor = System.Drawing.ColorTranslator.FromOle(&HE0E0E0)
		
45: sDate = lstjoursemaine(Index).Tag
		
50: Select Case Mid(sDate, 6, 2)
			Case "01" : iNbreJour = 31
55: Case "02"
60: If CShort(VB.Left(sDate, 4)) Mod 4 = 0 Then
65: iNbreJour = 29
70: Else
75: iNbreJour = 28
80: End If
				
85: Case "03" : iNbreJour = 31
90: Case "04" : iNbreJour = 30
95: Case "05" : iNbreJour = 31
100: Case "06" : iNbreJour = 30
105: Case "07" : iNbreJour = 31
110: Case "08" : iNbreJour = 31
115: Case "09" : iNbreJour = 30
120: Case "10" : iNbreJour = 31
125: Case "11" : iNbreJour = 30
130: Case "12" : iNbreJour = 31
135: End Select
		
140: Do While mvwSelection.Day >= iNbreJour
145: mvwSelection.Day = mvwSelection.Day - 1
150: Loop 
		
		'Sélectionne dans calendrier
155: mvwSelection.Year = CShort(VB.Left(sDate, 4))
160: mvwSelection.Month = CShort(Mid(sDate, 6, 2))
165: mvwSelection.Day = CShort(VB.Right(sDate, 2))
		
		'Date choisie
170: m_datDateChoisie = DateSerial(mvwSelection.Year, mvwSelection.Month, mvwSelection.Day)
		
		'Affiche horaire jour
175: Call RemplirListerJour()
		
180: fraliste.Visible = True
185: frajour.Visible = False
		
190: Call Lstjour.Focus()
		
195: Exit Sub
		
AfficherErreur: 
		
200: Call AfficherErreur("frmCédule", "lstjoursemaine_Click", Err, Erl())
	End Sub
	
	Private Sub mvwChoixDate_DateClick(ByVal eventSender As System.Object, ByVal eventArgs As AxMSComCtl2.DMonthViewEvents_DateClickEvent) Handles mvwChoixDate.DateClick
		
5: On Error GoTo AfficherErreur
		
10: If Lstjour.FocusedItem.Tag = "A" Then
15: Call CopierAlarme(eventArgs.DateClicked)
20: Else
25: Call CopierCédule(eventArgs.DateClicked)
30: End If
		
35: mvwChoixDate.Visible = False
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmCédule", "mvwChoixDate_DateClick", Err, Erl())
	End Sub
	
	Private Sub mvwChoixDate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mvwChoixDate.Leave
		
5: On Error GoTo AfficherErreur
		
10: mvwChoixDate.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmCédule", "mvwChoixDate_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskHeure_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskHeure.Enter
		
5: On Error GoTo AfficherErreur
		
		'Format d'heure
10: mskHeure.Mask = "##:##"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmCédule", "mskHeure_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskHeure_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskHeure.Leave
		
5: On Error GoTo AfficherErreur
		
		'Enlève le mask
10: mskHeure.Mask = vbNullString
		
		'Vide le champs si l'utilisateur n'a rien écrit
15: If mskHeure.Text = "__:__" Then
20: mskHeure.Text = vbNullString
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmCédule", "mskHeure_LostFocus", Err, Erl())
	End Sub
	
	Private Sub AfficherDate()
		
5: On Error GoTo AfficherErreur
		
		'Affiche horaire de la journée et de la semaine
		'dépendant la sélection dans le calendrier
10: Dim iCompteur As Short
		
		'Date choisie
15: m_datDateChoisie = DateSerial(mvwSelection.Year, mvwSelection.Month, mvwSelection.Day)
		
		'Affiche horaire jour et semaine
20: Call RemplirListerJour()
25: Call RemplirListerSemaine()
		
		'Sélectionne jour de la semaine
30: For iCompteur = 1 To 7
35: If CDate(lstjoursemaine(iCompteur).Tag) = m_datDateChoisie Then
40: lstjoursemaine(iCompteur).BackColor = System.Drawing.ColorTranslator.FromOle(&HE0E0E0)
45: Else
50: lstjoursemaine(iCompteur).BackColor = System.Drawing.ColorTranslator.FromOle(&HFFFFFF)
55: End If
60: Next 
		
		'Affiche cédule une journée
65: fraliste.Visible = True
70: fraAlarme.Visible = False
75: frajour.Visible = False
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmCédule", "AfficherDate", Err, Erl())
	End Sub
	
	Private Sub mvwSelection_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mvwSelection.Enter
		
5: On Error GoTo AfficherErreur
		
10: m_bMonthViewHasFocus = True
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmCédule", "mvwSelection_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mvwSelection_SelChange(ByVal eventSender As System.Object, ByVal eventArgs As AxMSComCtl2.DMonthViewEvents_SelChangeEvent) Handles mvwSelection.SelChange
		
5: On Error GoTo AfficherErreur
		
10: If Month(m_datDateChoisie) <> mvwSelection.Month Or Year(m_datDateChoisie) <> mvwSelection.Year Or VB.Day(m_datDateChoisie) <> mvwSelection.Day Then
15: Call AfficherDate()
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmCédule", "mvwSelection_SelChange", Err, Erl())
	End Sub
End Class