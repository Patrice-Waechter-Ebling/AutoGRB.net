Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FrmDispatch
	Inherits System.Windows.Forms.Form
	
	Private Sub ActiverBoutonsGroupe()
		
5: On Error GoTo AfficherErreur
		
		'Dépendant le groupe de sécurité contenu dans la table GRB_Groupes
		'met enabled les boutons
10: cmdClient.Enabled = g_bAffichageClients
15: cmdFournisseur.Enabled = g_bAffichageFournisseurs
20: cmdContact.Enabled = g_bAffichageContacts
25: 'GLLcmdVendeur.Enabled = g_bAffichageContactsVendeurs
30: cmdFormulaire.Enabled = g_bAffichageRapports
35: cmdEmploye.Enabled = g_bAffichageEmployes
40: cmdCedule.Enabled = g_bAffichageCedule
45: cmdConfiguration.Enabled = g_bAffichageConfiguration
50: cmdDistList.Enabled = g_bModificationListeDistribution
		
55: If g_bAffichagePunch = True Or g_bModificationFeuillesTemps = True Or g_bModificationFacturation = True Then
60: cmdPunch.Enabled = True
65: Else
70: cmdPunch.Enabled = False
75: End If
		
80: If g_bAffichageSoumissionsMec = True Or g_bAffichageSoumissionsElec = True Or g_bAffichageProjetsMec = True Or g_bAffichageProjetsElec = True Then
85: cmdProjSoum.Enabled = True
90: Else
95: cmdProjSoum.Enabled = False
100: End If
		
105: If g_bAffichageCatalogueMec = True Or g_bAffichageCatalogueElec = True Then
110: cmdCatalogue.Enabled = True
115: Else
120: cmdCatalogue.Enabled = False
125: End If
		
130: If g_bAffichageInventaireMec = True Or g_bAffichageInventaireElec = True Or g_bAffichageOutils = True Then
135: cmdInventaire.Enabled = True
140: Else
145: cmdInventaire.Enabled = False
150: End If
		
155: Exit Sub
		
AfficherErreur: 
		
160: Call AfficherErreur("frmDispatch", "ActiverBoutonsGroupe", Err, Erl())
	End Sub
	
	Private Sub cmdCedule_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCedule.Click
		
5: On Error GoTo AfficherErreur
		
		'Cédule
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(frmCédule, False)
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmDispatch", "cmdCedule_Click", Err, Erl())
	End Sub
	
	Private Sub CmdChangerDB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdChangerDB.Click
		Call FermerConnection() 'Fermer la connection pour pouvoir ouvrir l'autre
		'Si la Base de donné est présentement la base de donné actuel on ouvre l'ancienne
		If BdMaintenant = True Then
			Call OuvrirOldConnection()
			lbldb.Text = "Base de donné:Ancienne"
			BdMaintenant = False
		Else
			'Si la Base de donné est présentement l'ancienne base de donné on ouvre la base de donné actuel
			Call OuvrirConnection()
			BdMaintenant = True
			lbldb.Text = "Base de donné:Actuel"
		End If
		
	End Sub
	
	Private Sub cmdConfiguration_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdConfiguration.Click
		
5: On Error GoTo AfficherErreur
		
		'Configuration
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(FrmPara, True)
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmDispatch", "cmdConfiguration_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDistList_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDistList.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(frmDistList, False)
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmDispatch", "cmdDistList_Click", Err, Erl())
	End Sub
	
	Private Sub cmdEmploye_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEmploye.Click
		
5: On Error GoTo AfficherErreur
		
		'Employés
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(frmemploye, False)
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmDispatch", "cmdEmploye_Click", Err, Erl())
	End Sub
	
	Private Sub cmdInventaire_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdInventaire.Click
		'Magasin
5: On Error GoTo AfficherErreur
		
10: Dim lSize As Integer
15: Dim lLCID As Integer
20: Dim sBuffer As String
		
		'Vérifie si bons paramètres régionaux
25: lLCID = GetUserDefaultLCID
		
30: 'UPGRADE_ISSUE: StrPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		lSize = GetLocaleInfo(lLCID, LOCALE_SDECIMAL, CStr(StrPtr(sBuffer)), lSize)
		
35: sBuffer = Space(lSize)
		
40: lSize = GetLocaleInfo(lLCID, LOCALE_SDECIMAL, sBuffer, lSize)
		
45: sBuffer = Trim(Replace(sBuffer, Chr(0), ""))
		
50: If sBuffer = "," Then
55: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
60: Call OuvrirForm(frmChoixInventaire, True)
65: Else
70: Call MsgBox("Vos paramètres régionaux sont incorrects!" & vbNewLine & "Vous devez avoir la virgule (,) comme symbole de décimal!" & vbNewLine & "Des erreurs vont se produire dans ce formulaire car il contient des montants d'argent!", MsgBoxStyle.OKOnly, "Erreur")
75: End If
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmDispatch", "cmdInventaire_Click", Err, Erl())
	End Sub
	
	Private Sub cmdProjSoum_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdProjSoum.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim lSize As Integer
15: Dim lLCID As Integer
20: Dim sBuffer As String
		
25: 'Vérifie si bons paramètres régionaux
30: lLCID = GetUserDefaultLCID
		
35: 'UPGRADE_ISSUE: StrPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		lSize = GetLocaleInfo(lLCID, LOCALE_SDECIMAL, CStr(StrPtr(sBuffer)), lSize)
		
40: sBuffer = Space(lSize)
		
45: lSize = GetLocaleInfo(lLCID, LOCALE_SDECIMAL, sBuffer, lSize)
		
50: sBuffer = Trim(Replace(sBuffer, Chr(0), ""))
		
55: If sBuffer = "," Then
60: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
65: Call OuvrirForm(frmChoixProjSoum, True)
70: Else
75: Call MsgBox("Vos paramètres régionaux sont incorrects!" & vbNewLine & "Vous devez avoir la virgule (,) comme symbole de décimal!" & vbNewLine & "Des erreurs vont se produire dans ce formulaire car il contient des montants d'argent!", MsgBoxStyle.OKOnly, "Erreur")
80: End If
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("frmDispatch", "cmdProjSoum_Click", Err, Erl())
	End Sub
	
	Private Sub cmdPunch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPunch.Click
		
5: On Error GoTo AfficherErreur
		
		'Punch
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(frmChoixPunch, True)
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmDispatch", "cmdPunch_Click", Err, Erl())
	End Sub
	
	Private Sub ActiverBoutons(ByVal bEnabled As Boolean)
		
5: On Error GoTo AfficherErreur
		
10: cmdCatalogue.Enabled = bEnabled
15: cmdCedule.Enabled = bEnabled
20: cmdClient.Enabled = bEnabled
25: cmdConfiguration.Enabled = bEnabled
30: cmdContact.Enabled = bEnabled
35: cmdEmploye.Enabled = bEnabled
40: cmdFormulaire.Enabled = bEnabled
45: cmdFournisseur.Enabled = bEnabled
50: cmdInventaire.Enabled = bEnabled
55: cmdProjSoum.Enabled = bEnabled
60: cmdPunch.Enabled = bEnabled
65: cmdVendeur.Enabled = bEnabled
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmDispatch", "ActiverBoutons", Err, Erl())
	End Sub
	
	Private Sub cmdVendeur_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVendeur.Click
		
5: On Error GoTo AfficherErreur
		
		'Contacts pour vendeur
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(frmvendeur, False)
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmDispatch", "cmdVendeur_Click", Err, Erl())
	End Sub
	
	Private Sub cmdClient_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClient.Click
		
5: On Error GoTo AfficherErreur
		
		'Clients
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(FrmClient, False)
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmDispatch", "cmdClient_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFournisseur_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFournisseur.Click
		
5: On Error GoTo AfficherErreur
		
		'Founisseurs
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(FrmFRS, False)
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmDispatch", "cmdFournisseur_Click", Err, Erl())
	End Sub
	
	Private Sub cmdContact_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdContact.Click
		
5: On Error GoTo AfficherErreur
		
		'Contacts
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(FrmContact, False)
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmDispatch", "cmdContact_Click", Err, Erl())
	End Sub
	
	Private Sub cmdCatalogue_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCatalogue.Click
		'Magasin
5: On Error GoTo AfficherErreur
		
10: Dim lSize As Integer
15: Dim lLCID As Integer
20: Dim sBuffer As String
		
		'Vérifie si bons paramètres régionaux
25: lLCID = GetUserDefaultLCID
		
30: 'UPGRADE_ISSUE: StrPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		lSize = GetLocaleInfo(lLCID, LOCALE_SDECIMAL, CStr(StrPtr(sBuffer)), lSize)
		
35: sBuffer = Space(lSize)
		
40: lSize = GetLocaleInfo(lLCID, LOCALE_SDECIMAL, sBuffer, lSize)
		
45: sBuffer = Trim(Replace(sBuffer, Chr(0), ""))
		
50: If sBuffer = "," Then
55: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
60: Call OuvrirForm(frmChoixCatalogue, True)
65: Else
70: Call MsgBox("Vos paramètres régionaux sont incorrects!" & vbNewLine & "Vous devez avoir la virgule (,) comme symbole de décimal!" & vbNewLine & "Des erreurs vont se produire dans ce formulaire car il contient des montants d'argent!", MsgBoxStyle.OKOnly, "Erreur")
75: End If
		
80: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("frmDispatch", "cmdCatalogue_Click", Err, Erl())
	End Sub
	
	Private Sub cmdQuitter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdQuitter.Click
		
5: On Error GoTo AfficherErreur
		
		'Quitte l'application
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmDispatch", "cmdQuitter_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFormulaire_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFormulaire.Click
		
5: On Error GoTo AfficherErreur
		
		'Rapport
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(frmreport, False)
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmDispatch", "cmdFormulaire_Click", Err, Erl())
	End Sub
	
	Private Sub FrmDispatch_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		'Vérifie si l'utilisateur peux voir le bouton changement de base de donné
		If g_iNoGroupe = 2 Or g_iNoGroupe = 24 Then 'Or g_iNoGroupe = 22
			lbldb.Text = "Base de données:Actuel" 'ajoute l'information de quel base de donné on active GLL
			lbldb.Visible = True
			g_admin = True
			CmdChangerDB.Visible = True
		Else
			lbldb.Visible = False
			CmdChangerDB.Visible = False
			g_admin = False
		End If
10: Dim sVersion As String
15: Dim rstConfig As ADODB.Recordset
		
20: Call ActiverBoutonsGroupe()
		
		'Caption = Programme + Nom de l'employé
25: Me.Text = "Solution GRB inc. (" & g_sEmploye & ")"
		
30: sVersion = My.Application.Info.Version.Major & "." & VB.Right("0" & My.Application.Info.Version.Minor, 2) & "." & VB.Right("0" & My.Application.Info.Version.Revision, 4)
		
35: lblVersion.Text = "Version " & sVersion
		
40: rstConfig = New ADODB.Recordset
		
45: Call rstConfig.Open("SELECT DerniereVersion FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
50: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("DerniereVersion").Value) Then
55: If rstConfig.Fields("DerniereVersion").Value <> "" Then
60: lblDerniereVersion.Text = "Dernière Version : " & rstConfig.Fields("DerniereVersion").Value
65: Else
70: lblDerniereVersion.Text = ""
75: End If
80: Else
85: lblDerniereVersion.Text = ""
90: End If
		
95: Call rstConfig.Close()
100: 'UPGRADE_NOTE: Object rstConfig may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstConfig = Nothing
		
105: If Trim(Replace(lblDerniereVersion.Text, "Dernière Version : ", "")) = Trim(Replace(lblVersion.Text, "Version", "")) Then
110: lblVersion.ForeColor = System.Drawing.Color.Lime
115: Else
120: lblVersion.ForeColor = System.Drawing.Color.Red
125: End If
		
130: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
135: Exit Sub
		
AfficherErreur: 
		
140: Call AfficherErreur("frmDispatch", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub FrmDispatch_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
		'Ferme les forms invisibles
15: If My.Application.OpenForms.Count > 1 Then
20: iCompteur = 0
			
25: Do While iCompteur <= My.Application.OpenForms.Count - 1
30: If My.Application.OpenForms.Item(iCompteur).Visible = False Then
35: 'UPGRADE_ISSUE: Unload Forms() was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="875EBAD7-D704-4539-9969-BC7DBDAA62A2"'
					Call Unload(My.Application.OpenForms(iCompteur))
40: Else
45: iCompteur = iCompteur + 1
50: End If
55: Loop 
60: End If
		
65: If My.Application.OpenForms.Count > 1 Then
70: If MsgBox("Il y a des formulaires ouverts, êtes-vous certains de vouloir quitter?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
75: If FermerTousLesForms = True Then
80: Call FermerConnection()
					
85: End
90: Else
95: Call MsgBox("Impossible de fermer, un formulaire est encore en modification!", MsgBoxStyle.OKOnly, "Erreur")
					
100: 'UPGRADE_ISSUE: Event parameter Cancel was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
					Cancel = 1
105: End If
110: Else
115: 'UPGRADE_ISSUE: Event parameter Cancel was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
				Cancel = 1
120: End If
125: Else
130: Call Me.Close()
			
135: End
140: End If
		
145: Exit Sub
		
AfficherErreur: 
		
150: Call AfficherErreur("frmDispatch", "Form_Unload", Err, Erl())
	End Sub
	
	Private Function FermerTousLesForms() As Boolean
		
5: On Error GoTo AfficherErreur
		
10: Dim objForm As System.Windows.Forms.Form
15: Dim bFermer As Boolean
		
20: bFermer = True
		
25: For	Each objForm In My.Application.OpenForms
30: If objForm.Name <> Me.Name Then
35: If UCase(objForm.Name) = "FRMPROJSOUMELEC" Or UCase(objForm.Name) = "FRMPROJSOUMMEC" Then
40: 'UPGRADE_ISSUE: Control PeutFermer could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
					bFermer = objForm.PeutFermer
					
45: Exit For
50: End If
55: End If
60: Next objForm
		
65: If bFermer = True Then
70: For	Each objForm In My.Application.OpenForms
75: If objForm.Name <> Me.Name Then
80: Call objForm.Close()
85: End If
90: Next objForm
95: End If
		
100: FermerTousLesForms = bFermer
		
105: Exit Function
		
AfficherErreur: 
		
110: Call AfficherErreur("frmDispatch", "FermerTousLesForms", Err, Erl())
	End Function
	
	Private Sub Label1_Click()
		
	End Sub
	
	Private Sub tmrAlarme_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrAlarme.Tick
		
5: On Error GoTo AfficherErreur
		
10: Dim rstAlarme As ADODB.Recordset
15: Dim rstEmploye As ADODB.Recordset
20: Dim rstConfig As ADODB.Recordset
25: Dim bAfficher As Boolean
30: Dim iNoEmploye As Short
		
35: rstConfig = New ADODB.Recordset
		
40: Call rstConfig.Open("SELECT DerniereVersion FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
45: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstConfig.Fields("DerniereVersion").Value) Then
50: If rstConfig.Fields("DerniereVersion").Value <> "" Then
55: lblDerniereVersion.Text = "Dernière Version : " & rstConfig.Fields("DerniereVersion").Value
60: Else
65: lblDerniereVersion.Text = ""
70: End If
75: Else
80: lblDerniereVersion.Text = ""
85: End If
		
90: Call rstConfig.Close()
95: 'UPGRADE_NOTE: Object rstConfig may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstConfig = Nothing
		
100: If Trim(Replace(lblDerniereVersion.Text, "Dernière Version : ", "")) = Trim(Replace(lblVersion.Text, "Version", "")) Then
105: lblVersion.ForeColor = System.Drawing.Color.Lime
110: Else
115: lblVersion.ForeColor = System.Drawing.Color.Red
120: End If
		
125: rstEmploye = New ADODB.Recordset
		
130: Call rstEmploye.Open("SELECT * FROM GRB_Employés WHERE loginname = '" & g_sUserID & "'", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
135: iNoEmploye = rstEmploye.Fields("NoEmploye").Value
		
140: Call rstEmploye.Close()
145: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
		'Ouverture de la table
150: rstAlarme = New ADODB.Recordset
		
155: Call rstAlarme.Open("SELECT * FROM GRB_Alarmes WHERE NoEmploye = " & iNoEmploye, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
		'Tant qu'il y a des enregistrements
160: Do While Not rstAlarme.EOF
165: bAfficher = False
			
170: If rstAlarme.Fields("Date").Value < ConvertDate(Today) Then
175: bAfficher = True
180: Else
185: If rstAlarme.Fields("Date").Value = ConvertDate(Today) Then
190: If CDate(rstAlarme.Fields("Heure").Value) <= TimeOfDay Then
195: bAfficher = True
200: End If
205: End If
210: End If
			
215: If bAfficher = True Then
220: Call frmAlarme.Afficher(rstAlarme.Fields("IDAlarme").Value)
225: End If
			
230: Call rstAlarme.MoveNext()
235: Loop 
		
240: Call rstAlarme.Close()
245: 'UPGRADE_NOTE: Object rstAlarme may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAlarme = Nothing
		
250: Exit Sub
		
AfficherErreur: 
		
255: Call AfficherErreur("frmDispatch", "tmrAlarme_Timer", Err, Erl())
	End Sub
End Class