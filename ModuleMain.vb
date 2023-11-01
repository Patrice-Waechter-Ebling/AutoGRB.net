Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module ModuleMain
	
	Public Const S_GROUPE_DEFAUT As String = "Par défaut"
	Public Const S_GROUPE_ADMIN As String = "Administrateur"
	Public Const S_PASS_DEFAUT As String = "passe"
	Public Const S_CHEMIN_DEFAUT As String = "C:\Users\lapoghys\Desktop\Vb du Logiciel GRB\1.02.047\Data.mdb"
	Public Const CheminOldBd As String = "C:\Users\lapoghys\Desktop\Vb du Logiciel GRB\1.02.047\Data_Old.mdb" 'Chemin pour l'ancienne base de donné
	'Public Const S_CHEMIN_DEFAUT AS String = "\\Serveur\dominich\AutoGRB_final\Data.mdb"
	'POUR TEST GLL Public Const S_CHEMIN_DEFAUT  As String = "C:\Users\lapoghys\Desktop\Data.mdb"
	'Public Const S_CHEMIN_DEFAUT  As String = "C:\data_grb\Data.mdb"
	'Public Const S_CHEMIN_DEFAUT  As String = "\\Serveur\bdgrb\SEEGRB\bd_test\Data.mdb"
	'Public Const S_CHEMIN_DEFAUT  As String = "C:\Documents and Settings\Gaetan\Desktop\Organi-tek\GRBinc\Data.mdb"
	'Public Const s_chemin_defaut As String = "C:\Users\lapoghys\Desktop\Data.mdb"
	
	'Couleurs
	Public Const COLOR_ORANGE As Integer = &H80FF
	'UPGRADE_NOTE: COLOR_VERT was changed from a Constant to a Variable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"'
	Public COLOR_VERT As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Lime)
	'UPGRADE_NOTE: COLOR_MAGENTA was changed from a Constant to a Variable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"'
	Public COLOR_MAGENTA As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Magenta)
	'UPGRADE_NOTE: COLOR_JAUNE was changed from a Constant to a Variable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"'
	Public COLOR_JAUNE As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
	Public Const COLOR_GRIS As Integer = &H808080
	'UPGRADE_NOTE: COLOR_ROUGE was changed from a Constant to a Variable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"'
	Public COLOR_ROUGE As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
	Public Const COLOR_VERT_FORET As Integer = &H4000
	'UPGRADE_NOTE: COLOR_BLEU was changed from a Constant to a Variable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"'
	Public COLOR_BLEU As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue)
	Public Const COLOR_ROSE As Integer = &H8080FF
	Public Const COLOR_BRUN As Integer = &H404080
	'UPGRADE_NOTE: COLOR_NOIR was changed from a Constant to a Variable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"'
	Public COLOR_NOIR As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
	'UPGRADE_NOTE: COLOR_CYAN was changed from a Constant to a Variable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"'
	Public COLOR_CYAN As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Cyan)
	
	'Déclarations d'API de Windows
	Private Declare Function EnumWindows Lib "user32" (ByVal lpEnumFunc As Integer, ByVal lParam As Integer) As Integer
	
	Private Declare Function GetWindowText Lib "user32"  Alias "GetWindowTextA"(ByVal hwnd As Integer, ByVal lpString As String, ByVal cch As Integer) As Integer
	
	Private Declare Function IsWindowVisible Lib "user32" (ByVal hwnd As Integer) As Integer
	
	Private Declare Function GetParent Lib "user32" (ByVal hwnd As Integer) As Integer
	
	Public Declare Function FlashWindow Lib "user32" (ByVal hwnd As Integer, ByVal bInvert As Integer) As Integer
	
	Public Declare Function ShellExecute Lib "shell32.dll"  Alias "ShellExecuteA"(ByVal hwnd As Integer, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer
	
	Public Declare Function GetUserDefaultLCID Lib "kernel32" () As Integer
	
	Public Declare Function GetLocaleInfo Lib "kernel32"  Alias "GetLocaleInfoA"(ByVal Locale As Integer, ByVal LCType As Integer, ByVal lpLCData As String, ByVal cchData As Integer) As Integer
	
	'Pour ShellExecute
	Public Const SW_SHOWNORMAL As Short = 1
	
	'Pour GetLocaleInfo - Decimal separator
	Public Const LOCALE_SDECIMAL As Integer = &HE
	
	'Déclaration des variables globales utilisées par le programme
	Public CheminBD As String 'Contient le chemin de la base de donnée
	Public g_sUserID As String 'Contient le UserID de l'employé connecté
	Public g_sEmploye As String 'Contient le nom de l'employé connecté
	Public g_sInitiale As String 'Contient les initiales de l'employé connecté
	Public g_bBonPasswd As Boolean 'Pour savoir si le mot de passe entré est bon
	Public g_iNoGroupe As Short 'No du groupe de l'employé connecté
	Public BdMaintenant As Boolean 'Savoir si vielle bd ou récente
	Public Enum enumCatalogue
		ELECTRIQUE = 0
		MECANIQUE = 1
	End Enum
	
	Public Enum enumConvert
		MODE_PAS_FORMAT = 0
		MODE_DECIMAL = 1
		MODE_ARGENT = 2
		MODE_POURCENT = 3
	End Enum
	
	'Pour compter le nombre d'applications ouvertes
	Private m_iCmpApp As Short
	
	'Variables contenant les droit d'affichage
	Public g_bAffichageClients As Boolean
	Public g_bAffichageFournisseurs As Boolean
	Public g_bAffichageContacts As Boolean
	Public g_bAffichageContactsVendeurs As Boolean
	Public g_bAffichageRapports As Boolean
	Public g_bAffichageEmployes As Boolean
	Public g_bAffichageCedule As Boolean
	Public g_bAffichageConfiguration As Boolean
	Public g_bAffichagePunch As Boolean
	Public g_bAffichageOutils As Boolean
	Public g_bAffichageInventaireMec As Boolean
	Public g_bAffichageCatalogueMec As Boolean
	Public g_bAffichageSoumissionsMec As Boolean
	Public g_bAffichageProjetsMec As Boolean
	Public g_bAffichageInventaireElec As Boolean
	Public g_bAffichageCatalogueElec As Boolean
	Public g_bAffichageSoumissionsElec As Boolean
	Public g_bAffichageProjetsElec As Boolean
	Public g_bAffichageAchats As Boolean
	
	'Variables contenant les droit de modification
	Public g_bModificationClients As Boolean
	Public g_bModificationFournisseurs As Boolean
	Public g_bModificationContacts As Boolean
	Public g_bModificationEmployes As Boolean
	Public g_bModificationGroupes As Boolean
	Public g_bModificationFeuillesTemps As Boolean
	Public g_bModificationOutils As Boolean
	Public g_bModificationFacturation As Boolean
	Public g_bModificationBC As Boolean
	Public g_bModificationPunchEmployes As Boolean
	Public g_bModificationInventaireMec As Boolean
	Public g_bModificationCatalogueMec As Boolean
	Public g_bModificationSoumissionsMec As Boolean
	Public g_bModificationProjetsMec As Boolean
	Public g_bModificationInventaireElec As Boolean
	Public g_bModificationCatalogueElec As Boolean
	Public g_bModificationSoumissionsElec As Boolean
	Public g_bModificationProjetsElec As Boolean
	Public g_bSuppressionProjets As Boolean
	Public g_bModificationReception As Boolean
	Public g_bModificationRetourMarchandise As Boolean
	Public g_bModificationListeDistribution As Boolean
	Public g_bPunchSemaineAnterieure As Boolean
	Public g_bVerrouillageTempsProjet As Boolean
	Public g_bDeverrouillageTempsProjet As Boolean
	Public g_admin As Boolean
	
	'Pour savoir si la cédule des vendeurs est ouverte
	Public g_bCeduleOuverte As Boolean
	
	'Pour savoir la localisation choisie dans le Form frmChoixLocalisation
	Public g_sLocalisation As String
	
	'Pour savoir la quantité par boite choisie dans le Form frmChoixQteBoite
	Public g_sQteBoite As String
	Public g_bQteBoite As Boolean
	
	Public g_objAchatElec As frmAchat
	Public g_objAchatMec As frmAchat
	
	'UPGRADE_WARNING: Application will terminate when Sub Main() finishes. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E08DDC71-66BA-424F-A612-80AF11498FF8"'
	Public Sub Main()
		
5: On Error GoTo AfficherErreur
		
10: Dim lSize As Integer
15: Dim lLCID As Integer
20: Dim sBuffer As String
		
25: 'UPGRADE_WARNING: Add a delegate for AddressOf EnumWindowProc Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
		Call EnumWindows(AddressOf EnumWindowProc, &H0)
		
		'Si l'application est ouverte plus d'une fois
30: If m_iCmpApp > 1 Then
35: Call MsgBox("Le programme est déjà ouvert!", MsgBoxStyle.Critical, "Erreur")
			
40: Exit Sub
45: End If
		
		'Vérifie si bons paramètres régionaux
50: lLCID = GetUserDefaultLCID
		
55: 'UPGRADE_ISSUE: StrPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		lSize = GetLocaleInfo(lLCID, LOCALE_SDECIMAL, CStr(StrPtr(sBuffer)), lSize)
		
60: sBuffer = Space(lSize)
		
65: lSize = GetLocaleInfo(lLCID, LOCALE_SDECIMAL, sBuffer, lSize)
		
70: sBuffer = Trim(Replace(sBuffer, Chr(0), ""))
		
75: If sBuffer = "." Then
80: Call MsgBox("Vos paramètres régionaux sont incorrects!" & vbNewLine & "Vous devez avoir la virgule (,) comme symbole de décimal!" & vbNewLine & "Des erreurs vont se produire si vous utilisez des formulaires contenants des montants d'argent!", MsgBoxStyle.OKOnly, "Erreur")
85: End If
		
90: Call InitialiserVariablesConfiguration()
		
95: Call OuvrirForm(frmLoginPrincipal, True)
		BdMaintenant = True
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("ModuleMain", "Main", Err, Erl())
	End Sub
	
	Public Sub InitialiserVariablesGroupe()
		'Initialise les variables du groupe de sécurité
		
5: On Error GoTo AfficherErreur
		
10: Dim rstGroupe As ADODB.Recordset
		
15: rstGroupe = New ADODB.Recordset
		
20: Call rstGroupe.Open("SELECT * FROM GRB_Groupes WHERE IDGroupe = " & g_iNoGroupe, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: g_bAffichageClients = rstGroupe.Fields("Clients").Value
30: g_bAffichageFournisseurs = rstGroupe.Fields("Fournisseurs").Value
35: g_bAffichageContacts = rstGroupe.Fields("Contacts").Value
40: g_bAffichageContactsVendeurs = rstGroupe.Fields("ContactsVendeurs").Value
45: g_bAffichageRapports = rstGroupe.Fields("Rapport").Value
50: g_bAffichageCatalogueMec = rstGroupe.Fields("CatalogueMec").Value
55: g_bAffichageCatalogueElec = rstGroupe.Fields("CatalogueElec").Value
60: g_bAffichageEmployes = rstGroupe.Fields("Employes").Value
65: g_bAffichageCedule = rstGroupe.Fields("Cedule").Value
70: g_bAffichageConfiguration = rstGroupe.Fields("Configuration").Value
75: g_bAffichagePunch = rstGroupe.Fields("Punch").Value
80: g_bAffichageOutils = rstGroupe.Fields("Outils").Value
85: g_bAffichageInventaireMec = rstGroupe.Fields("InventaireMec").Value
90: g_bAffichageSoumissionsMec = rstGroupe.Fields("SoumissionMec").Value
95: g_bAffichageProjetsMec = rstGroupe.Fields("ProjetMec").Value
100: g_bAffichageInventaireElec = rstGroupe.Fields("InventaireElec").Value
105: g_bAffichageSoumissionsElec = rstGroupe.Fields("SoumissionElec").Value
110: g_bAffichageProjetsElec = rstGroupe.Fields("ProjetElec").Value
115: g_bAffichageAchats = rstGroupe.Fields("Achat").Value
		
120: g_bModificationClients = rstGroupe.Fields("ModificationClients").Value
125: g_bModificationFournisseurs = rstGroupe.Fields("ModificationFournisseurs").Value
130: g_bModificationContacts = rstGroupe.Fields("ModificationContacts").Value
135: g_bModificationEmployes = rstGroupe.Fields("ModificationEmployes").Value
140: g_bModificationGroupes = rstGroupe.Fields("ModificationGroupes").Value
145: g_bModificationFeuillesTemps = rstGroupe.Fields("ModificationFeuillesTemps").Value
150: g_bModificationOutils = rstGroupe.Fields("ModificationOutils").Value
155: g_bModificationFacturation = rstGroupe.Fields("ModificationFacturation").Value
160: g_bModificationInventaireMec = rstGroupe.Fields("ModificationInventaireMec").Value
165: g_bModificationSoumissionsMec = rstGroupe.Fields("ModificationSoumissionsMec").Value
170: g_bModificationProjetsMec = rstGroupe.Fields("ModificationProjetsMec").Value
175: g_bModificationInventaireElec = rstGroupe.Fields("ModificationInventaireElec").Value
180: g_bModificationSoumissionsElec = rstGroupe.Fields("ModificationSoumissionsElec").Value
185: g_bModificationProjetsElec = rstGroupe.Fields("ModificationProjetsElec").Value
190: g_bModificationBC = rstGroupe.Fields("ModificationBonsCommandes").Value
195: g_bModificationCatalogueElec = rstGroupe.Fields("ModificationCatalogueElec").Value
200: g_bModificationCatalogueMec = rstGroupe.Fields("ModificationCatalogueMec").Value
205: g_bModificationPunchEmployes = rstGroupe.Fields("ModificationPunchEmployes").Value
210: g_bSuppressionProjets = rstGroupe.Fields("SuppressionProjets").Value
215: g_bModificationReception = rstGroupe.Fields("ModificationReception").Value
220: g_bModificationRetourMarchandise = rstGroupe.Fields("ModificationRetourMarchandise").Value
225: g_bModificationListeDistribution = rstGroupe.Fields("ListeDistribution").Value
230: g_bPunchSemaineAnterieure = rstGroupe.Fields("PunchSemaineAntérieure").Value
235: g_bVerrouillageTempsProjet = rstGroupe.Fields("VerrouillageTempsProjet").Value
240: g_bDeverrouillageTempsProjet = rstGroupe.Fields("DéverrouillageTempsProjet").Value
		
245: Call rstGroupe.Close()
250: 'UPGRADE_NOTE: Object rstGroupe may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstGroupe = Nothing
		
255: Exit Sub
		
AfficherErreur: 
		
260: Call AfficherErreur("ModuleMain", "InitialiserVariablesGroupe", Err, Erl())
	End Sub
	
	Public Sub InitialiserVariablesConfiguration()
		'lorsque la form est loader on transfert
		'les donnes pour fixer la valeur des variables
		
5: On Error GoTo AfficherErreur
		
10: CheminBD = GetSetting("GRB", "Config", "CheminBD", S_CHEMIN_DEFAUT)
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("ModuleMain", "InitialiserVariablesConfiguration", Err, Erl())
	End Sub
	
	Public Function EnumWindowProc(ByVal hwnd As Integer, ByVal lParam As Integer) As Integer
		'working vars
		
5: On Error GoTo AfficherErreur
		
10: Dim sTitle As New VB6.FixedLengthString(80)
		
		'eliminate windows that are not top-level.
15: If GetParent(hwnd) = 0 And IsWindowVisible(hwnd) Then
20: Call GetWindowText(hwnd, sTitle.Value, Len(sTitle.Value))
			
25: If InStr(1, sTitle.Value, My.Application.Info.Title) > 0 Then
30: m_iCmpApp = m_iCmpApp + 1
35: End If
40: End If
		
45: If m_iCmpApp > 1 Then
50: EnumWindowProc = 0
55: Else
60: EnumWindowProc = 1
65: End If
		
70: Exit Function
		
AfficherErreur: 
		
75: Call AfficherErreur("ModuleMain", "EnumWindowProc", Err, Erl())
	End Function
	
	Public Function ComboContient(ByVal cmbSource As System.Windows.Forms.ComboBox, ByVal sRecherche As String) As Boolean
		'retourne vrai si le combo contient le texte à rechercher
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: ComboContient = False
		
20: For iCompteur = 0 To cmbSource.Items.Count - 1
25: If UCase(Trim(VB6.GetItemString(cmbSource, iCompteur))) = UCase(Trim(sRecherche)) Then
30: ComboContient = True
				
35: Exit For
40: End If
45: Next 
		
50: Exit Function
		
AfficherErreur: 
		
55: Call AfficherErreur("ModuleMain", "ComboContient", Err, Erl())
	End Function
	
	Public Function ConvertDate(ByVal datDate As Date) As String
		'Pour avoir la date sous forme AAAA-MM-JJ
		
5: On Error GoTo AfficherErreur
		
10: ConvertDate = Year(datDate) & "-" & Right("0" & Month(datDate), 2) & "-" & Right("0" & VB.Day(datDate), 2)
		
15: Exit Function
		
AfficherErreur: 
		
20: Call AfficherErreur("ModuleMain", "ConvertDate", Err, Erl())
	End Function
	
	Public Sub OuvrirForm(ByVal frmSource As System.Windows.Forms.Form, ByVal bModal As Boolean)
		'Procédure qui empêche d'ouvrir un form plusieurs fois
		
5: On Error GoTo AfficherErreur
		
10: Dim objForm As System.Windows.Forms.Form
15: Dim bDejaOuvert As Boolean
		
20: For	Each objForm In My.Application.OpenForms
25: If objForm.Name = frmSource.Name Then
30: bDejaOuvert = True
				
35: Exit For
40: End If
45: Next objForm
		
50: If bDejaOuvert = False Then
55: If bModal = True Then
60: Call frmSource.ShowDialog()
65: Else
70: Call frmSource.Show()
75: End If
80: Else
85: objForm.WindowState = System.Windows.Forms.FormWindowState.Normal
			
90: 'UPGRADE_WARNING: Form method objForm.ZOrder has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			Call objForm.BringToFront()
95: End If
		
105: Exit Sub
		
AfficherErreur: 
		
110: Call AfficherErreur("ModuleMain", "OuvrirForm", Err, Erl())
	End Sub
	
	'UPGRADE_NOTE: Conversion was upgraded to Conversion_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Function Conversion_Renamed(ByVal sValeur As String, ByVal eConvert As enumConvert, Optional ByVal o_iNbreDecimal As Short = 2) As String
		
5: On Error GoTo AfficherErreur
		
10: Dim sRetour As String
		
15: If Trim(sValeur) = "" Then
20: Conversion_Renamed = ""
			
25: Exit Function
30: End If
		
35: sValeur = Replace(sValeur, ".", ",")
40: sValeur = Replace(sValeur, "$", "")
45: sValeur = Replace(sValeur, "%", "")
		
50: Select Case eConvert
			Case enumConvert.MODE_PAS_FORMAT
55: If InStr(1, sValeur, "$") > 0 Or InStr(1, sValeur, "%") > 1 Then
60: sRetour = Left(sValeur, Len(sValeur) - 1)
65: Else
70: sRetour = sValeur
75: End If
				
80: Case enumConvert.MODE_DECIMAL
85: sValeur = CStr(System.Math.Round(CDbl(sValeur), o_iNbreDecimal))
				
90: If InStr(1, sValeur, ",") > 0 Then
95: sRetour = Left(sValeur & New String("0", o_iNbreDecimal), InStr(1, sValeur, ",") + o_iNbreDecimal)
100: Else
105: sRetour = sValeur & "," & New String("0", o_iNbreDecimal)
110: End If
				
115: sRetour = CStr(System.Math.Round(CDbl(sRetour), o_iNbreDecimal))
				
120: If InStr(1, sRetour, ",") > 0 Then
125: If Len(Mid(sRetour, InStr(1, sRetour, ",") + 1, Len(sRetour) - InStr(1, sRetour, ",") + 1)) < 2 Then
130: sRetour = sRetour & "0"
135: End If
140: End If
				
145: Case enumConvert.MODE_ARGENT
150: sValeur = CStr(System.Math.Round(CDbl(sValeur), o_iNbreDecimal))
				
155: If InStr(1, sValeur, ",") > 0 Then
160: sRetour = Left(sValeur & New String("0", o_iNbreDecimal), InStr(1, sValeur, ",") + o_iNbreDecimal)
165: Else
170: sRetour = sValeur & "," & New String("0", o_iNbreDecimal)
175: End If
				
180: sRetour = CStr(System.Math.Round(CDbl(sRetour), o_iNbreDecimal))
				
185: If InStr(1, sRetour, ",") > 0 Then
190: If Len(Mid(sRetour, InStr(1, sRetour, ",") + 1, Len(sRetour) - InStr(1, sRetour, ","))) < 2 Then
195: sRetour = sRetour & "0" & "$"
200: Else
205: sRetour = sRetour & "$"
210: End If
215: Else
220: sRetour = sRetour & ",00$"
225: End If
				
230: Case enumConvert.MODE_POURCENT
235: If CDbl(sValeur) < 1 Then
240: sValeur = CStr(CDbl(sValeur) * 100)
245: End If
				
250: sValeur = CStr(System.Math.Round(CDbl(sValeur), o_iNbreDecimal))
				
255: If InStr(1, sValeur, ",") > 0 Then
260: sRetour = Left(sValeur & New String("0", o_iNbreDecimal), InStr(1, sValeur, ",") + o_iNbreDecimal) & "%"
265: Else
270: sRetour = sValeur & "," & New String("0", o_iNbreDecimal) & "%"
275: End If
280: End Select
		
285: Conversion_Renamed = sRetour
		
290: Exit Function
		
AfficherErreur: 
		
295: Call AfficherErreur("ModuleMain", "Conversion", Err, Erl())
	End Function
	
	Public Sub AfficherErreur(ByVal sSourceName As String, ByVal sMethode As String, ByVal Erreur As ErrObject, ByVal iNoLigne As Short, Optional ByVal o_sParams As String = "")
		Dim rstErreur As ADODB.Recordset
		Dim datNow As Date
		Dim lNoErr As Integer
		Dim sDescription As String
		Dim sSource As String
		
		datNow = Now
		
		lNoErr = Err.Number
		sDescription = Err.Description
		sSource = Erreur.Source
		
		Call MsgBox("Une erreur est survenue!" & vbNewLine & vbNewLine & "Erreur numéro " & lNoErr & vbNewLine & vbNewLine & "Description : " & sDescription, MsgBoxStyle.OKOnly, "Erreur")
		
		rstErreur = New ADODB.Recordset
		
		Call rstErreur.Open("SELECT * FROM GRB_Erreurs", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		Call rstErreur.AddNew()
		
		If g_sEmploye <> vbNullString Then
			rstErreur.Fields("Qui").Value = g_sEmploye
		End If
		
		rstErreur.Fields("Date").Value = ConvertDate(datNow)
		rstErreur.Fields("Heure").Value = Right("0" & Hour(datNow), 2) & ":" & Right("0" & Minute(datNow), 2) & ":" & Right("0" & Second(datNow), 2)
		rstErreur.Fields("Form").Value = sSourceName
		rstErreur.Fields("Methode").Value = sMethode
		rstErreur.Fields("NoLigne").Value = iNoLigne
		rstErreur.Fields("NoErreur").Value = lNoErr
		rstErreur.Fields("Description").Value = sDescription
		rstErreur.Fields("Source").Value = sSource
		
		'UPGRADE_NOTE: IsMissing() was changed to IsNothing(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
		If Not IsNothing(o_sParams) Then
			rstErreur.Fields("Params").Value = o_sParams
		End If
		
		Call rstErreur.Update()
		
		Call rstErreur.Close()
		'UPGRADE_NOTE: Object rstErreur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstErreur = Nothing
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
	End Sub
	
	Public Function OuvrirOutlook(ByRef bDejaOuvert As Boolean) As Outlook.Application
		
5: On Error Resume Next
		
10: Dim otlApp As Outlook.Application
		
15: bDejaOuvert = True
		
20: otlApp = GetObject( , "Outlook.Application")
		
25: If Err.Number = 429 Then
30: Call Err.Clear()
			
35: bDejaOuvert = False
			
40: otlApp = CreateObject("Outlook.Application")
45: End If
		
50: OuvrirOutlook = otlApp
	End Function
	
	Public Function GetFolder(ByVal otlApp As Outlook.Application, ByVal sFolderName As String) As Outlook.MAPIFolder
		
5: On Error GoTo AfficherErreur
		
10: Dim oNS As Outlook.NameSpace
15: Dim oPublicFolders As Outlook.MAPIFolder
20: Dim oAllPublicFolders As Outlook.MAPIFolder
25: Dim oFolder As Outlook.MAPIFolder
30: Dim bFolderFound As Boolean
		
35: oNS = otlApp.GetNamespace("MAPI")
		
40: For	Each oPublicFolders In oNS.Folders
			'45        If UCase(oPublicFolders.Name) = "ARCHIVE FOLDERS" Or UCase(oPublicFolders.Name) = "PUBLIC FOLDERS" Or UCase(oPublicFolders.Name) = "DOSSIERS PUBLICS" Then 'Commenté le 2016-08-24 1.02.37, Raphaël Aubin
45: If UCase(oPublicFolders.Name) = "ARCHIVE FOLDERS" Or UCase(oPublicFolders.Name) = "PUBLIC FOLDERS" Or UCase(oPublicFolders.Name) = "DOSSIERS PUBLICS" Or InStr(UCase(oPublicFolders.Name), "DOSSIERS PUBLICS") > 0 Or InStr(UCase(oPublicFolders.Name), "PUBLIC FOLDERS") > 0 Then
50: For	Each oAllPublicFolders In oPublicFolders.Folders
55: If UCase(oAllPublicFolders.Name) = "ALL PUBLIC FOLDERS" Or UCase(oAllPublicFolders.Name) = "TOUS LES DOSSIERS PUBLICS" Then
60: For	Each oFolder In oAllPublicFolders.Folders
65: If UCase(oFolder.Name) = UCase(sFolderName) Then
70: bFolderFound = True
								
75: Exit For
80: End If
85: Next oFolder
90: End If
					
95: If bFolderFound = True Then
100: Exit For
105: End If
110: Next oAllPublicFolders
115: End If
			
120: If bFolderFound = True Then
125: Exit For
130: End If
135: Next oPublicFolders
		
140: GetFolder = oFolder
		
145: Exit Function
		
AfficherErreur: 
		
150: Call AfficherErreur("ModuleMain", "GetFolder", Err, Erl())
	End Function
	
	Public Function GetFirstDay(ByVal datDate As Date) As Date
		'Procédure pour avoir la date du dimanche
5: On Error GoTo AfficherErreur
		
10: Dim iNoJour As Short
		
15: iNoJour = WeekDay(datDate)
		
20: Do While iNoJour > 1
25: iNoJour = iNoJour - 1
			
30: datDate = System.Date.FromOADate(datDate.ToOADate - TimeSerial(24, 0, 0).ToOADate)
35: Loop 
		
40: GetFirstDay = datDate
		
45: Exit Function
		
AfficherErreur: 
		
50: Call AfficherErreur("ModuleMain", "GetFirstDay", Err, Erl())
	End Function
	
	Public Function GetLastDay(ByVal datDate As Date) As Date
		
5: On Error GoTo AfficherErreur
		'Procédure pour avoir la date du samedi
		
10: Dim iNoJour As Short
		
15: iNoJour = WeekDay(datDate)
		
20: Do While iNoJour < 7
25: iNoJour = iNoJour + 1
			
30: datDate = System.Date.FromOADate(datDate.ToOADate + TimeSerial(24, 0, 0).ToOADate)
35: Loop 
		
40: GetLastDay = datDate
		
45: Exit Function
		
AfficherErreur: 
		
50: Call AfficherErreur("ModuleMain", "GetLastDay", Err, Erl())
	End Function
	
	Public Function GetDateTexte(ByVal datDate As Date) As String
		
5: On Error GoTo AfficherErreur
		
		'Procédure pour avoir la date en texte pour afficher "Semaine du ..."
10: Dim sMonth As String
		
15: sMonth = MonthName(Month(datDate))
		
20: GetDateTexte = VB.Day(datDate) & " " & sMonth & " " & Year(datDate)
		
25: Exit Function
		
AfficherErreur: 
		
30: Call AfficherErreur("ModuleMain", "GetDateTexte", Err, Erl())
	End Function
	
	Public Function ValiderFormatNumeroProjSoum(ByVal sNoProjSoum As String) As Boolean
		
5: On Error GoTo AfficherErreur
		
10: Dim bNoValide As Boolean
15: Dim sErreurMsg As String
		
20: bNoValide = True
		
25: If Len(sNoProjSoum) <> 9 Then
30: bNoValide = False
			
35: sErreurMsg = "Le numéro doit contenir 9 caractères!"
40: End If
		
45: If bNoValide = True Then
50: If UCase(Left(sNoProjSoum, 1)) <> "M" And UCase(Left(sNoProjSoum, 1)) <> "E" Then
55: bNoValide = False
				
60: sErreurMsg = "Le numéro doit commencé par : " & vbNewLine & vbNewLine & "      E pour les soumissions et projets électriques" & vbNewLine & "      M pour les soumissions et projets mécaniques"
65: End If
70: End If
		
75: If bNoValide = True Then
80: If Not IsNumeric(Mid(sNoProjSoum, 2, 5)) Then
85: bNoValide = False
				
90: sErreurMsg = "Format invalide !"
95: End If
100: End If
		
105: If bNoValide = True Then
110: If Not IsNumeric(Right(sNoProjSoum, 2)) Then
115: bNoValide = False
				
120: sErreurMsg = "Format invalide !"
125: End If
130: End If
		
135: If bNoValide = True Then
140: If Mid(sNoProjSoum, 7, 1) <> "-" Then
145: bNoValide = False
				
150: sErreurMsg = "Format invalide !"
155: End If
160: End If
		
165: If bNoValide = True Then
170: If CDbl(Mid(sNoProjSoum, 3, 1)) = 0 Then
175: bNoValide = False
				
180: sErreurMsg = "Le 3e caractère ne peut pas être '0' !"
185: End If
190: End If
		
195: If bNoValide = True Then
200: If Right(sNoProjSoum, 2) = "99" Or Right(sNoProjSoum, 2) = "00" Then
205: bNoValide = False
				
210: sErreurMsg = "L'extension doit être comprise entre 01 et 98"
215: End If
220: End If
		
225: If bNoValide = False Then
230: Call MsgBox(sErreurMsg, MsgBoxStyle.OKOnly, "Erreur")
235: End If
		
240: ValiderFormatNumeroProjSoum = bNoValide
		
245: Exit Function
		
AfficherErreur: 
		
250: Call AfficherErreur("ModuleMain", "ValiderFormatNumeroProjSoum", Err, Erl())
	End Function
End Module