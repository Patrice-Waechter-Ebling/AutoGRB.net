Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmChoixDemande
	Inherits System.Windows.Forms.Form
	
	'Index de cmbTri
	Private Const I_CMB_PIECE As Short = 0
	Private Const I_CMB_DESCRIPTION_FR As Short = 1
	Private Const I_CMB_DESCRIPTION_EN As Short = 2
	Private Const I_CMB_FABRICANT As Short = 3
	
	'Index des colonnes de lvwPiece
	Private Const I_COL_QUANTITE As Short = 0
	Private Const I_COL_PIECE As Short = 1
	Private Const I_COL_DESC_FR As Short = 2
	Private Const I_COL_DESC_EN As Short = 3
	Private Const I_COL_FABRICANT As Short = 4
	
	'Index des colonnes de lvwFournisseur
	Private Const I_COL_NOM_FRS As Short = 0
	Private Const I_COL_LANGAGE As Short = 1
	
	'Index des colonnes de lvwNouvellesPieces
	Private Const I_COL_QTE As Short = 0
	Private Const I_COL_NO_PIECE As Short = 1
	Private Const I_COL_DESCRIPTION As Short = 2
	Private Const I_COL_MANUFACT As Short = 3
	Private Const I_COL_CATEGORIE As Short = 4
	
	'Caption du bouton cmdLangage
	Private Const S_DEMANDE_FRANCAIS As String = "En français"
	Private Const S_DEMANDE_ANGLAIS As String = "En anglais"
	
	'Texte de la colonne Langage de la demande de lvwFournisseur
	Private Const S_FRANCAIS As String = "Français"
	Private Const S_ANGLAIS As String = "Anglais"
	
	'Pour savoir si l'appel de la demande a été fait à partir d'une soumission
	'ou d'un projet
	Private Enum enumType
		TYPE_PROJET = 0
		TYPE_SOUMISSION = 1
	End Enum
	
	'Pour savoir quel ListView est affiché
	Private Enum enumMode
		Fournisseur = 0
		PIECE = 1
		Categorie = 2
		NOUVELLE_PIECE = 3
		Manufacturier = 4
	End Enum
	
	Public Enum enumModeDemande
		MODE_PIECE = 0 'Pour une pièce
		MODE_FOURNISSEUR = 1 'Pour toutes les pièces d'un fournisseur
		MODE_CATEGORIE = 2 'Pour catégorie
		MODE_NOUVELLE = 3
	End Enum
	
	Private m_eMode As enumMode
	
	Private m_eDemande As enumModeDemande
	
	'Contient la valeur électrique ou mécanique
	Private m_eCatalogue As ModuleMain.enumCatalogue
	
	'Pour conserver en mémoire les pièces choisies
	Private m_collPiece As Collection
	Private m_collQuantite As Collection
	Private m_collDescriptionFR As Collection
	Private m_collDescriptionEN As Collection
	Private m_collCategorie As Collection
	Private m_collManufacturier As Collection
	
	'Pour savoir si les fournisseurs sont affichés après avoir choisit des pièces
	Private m_bPiece As Boolean
	
	'Pour savoir si la catégorie a changé ou non,
	'sert également pour mettre dans m_collCategorie
	Private m_sCategorie As String
	
	Private m_sLangage As String
	
	'Pour savoir si la demande a été fait à partir des Projets / Soumissions
	Private m_bProjSoum As Boolean
	
	'Pour savoir si la demande a été fait à partir des achats
	Private m_bAchat As Boolean
	
	'Contient le numéro du projet si la demande à été fait à partir d'un Projet
	Private m_sNoProjSoum As String
	
	'Contient le numéro de l'achat si la demande a été fait à partir des achats
	Private m_sNoAchat As String
	
	'Contient l'index de l'achat si la demande a été fait à partir des achats
	Private m_iIndexAchat As Short
	
	'Pour savoir à quel index la rechercher est rendu
	Private m_iIndexRecherche As Short
	
	'Pour savoir par quoi trier le ListView
	Private m_sTri As String
	
	'Pour savoir si c'est une soumission ou un projet
	Private m_eType As enumType
	
	Public m_bAnnulerContact As Boolean
	Public m_sContact As String
	
	Public Sub Afficher(ByVal eCatalogue As ModuleMain.enumCatalogue, ByVal eDemande As enumModeDemande)
		
5: On Error GoTo AfficherErreur
		
10: m_eCatalogue = eCatalogue
15: m_eDemande = eDemande
20: m_bProjSoum = False
		
25: Select Case eDemande
			Case enumModeDemande.MODE_FOURNISSEUR
30: Call RemplirListViewFournisseur(False)
				
35: Call AfficherControles(enumMode.Fournisseur)
				
40: Case enumModeDemande.MODE_PIECE
45: Call RemplirComboCategorie()
				
50: Call AfficherControles(enumMode.PIECE)
				
55: Case enumModeDemande.MODE_CATEGORIE
60: Call RemplirListViewCatalogue()
				
65: Call AfficherControles(enumMode.Categorie)
				
70: Case enumModeDemande.MODE_NOUVELLE
75: Call RemplirComboCategorie()
				
80: Call AfficherControles(enumMode.NOUVELLE_PIECE)
				
85: If m_eDemande = enumModeDemande.MODE_NOUVELLE Then
90: Call RemplirComboManufacturiers()
95: End If
100: End Select
		
105: Call ShowDialog()
		
110: Exit Sub
		
AfficherErreur: 
		
115: Call AfficherErreur("frmChoixDemande", "Afficher", Err, Erl())
	End Sub
	
	Public Sub AfficherProjetSoumission(ByVal sNoProjSoum As String, ByVal eCatalogue As ModuleMain.enumCatalogue, ByVal eDemande As enumModeDemande, ByVal iType As Short)
		
5: On Error GoTo AfficherErreur
		
10: m_eCatalogue = eCatalogue
15: m_eDemande = eDemande
20: m_sNoProjSoum = sNoProjSoum
25: m_eType = iType
		
30: txtNoGRB.Text = sNoProjSoum
		
35: Call RemplirListViewPieceProjetSoumission()
		
40: Call AfficherControles(enumMode.PIECE)
		
45: cmbTri.Visible = False
50: cmdTri.Visible = False
55: cmdRafraichir.Visible = False
		
60: cmbCategorie.Visible = False
65: lblCategorie.Visible = False
		
70: m_bProjSoum = True
		
75: Call Me.ShowDialog()
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmChoixDemande", "AfficherProjet", Err, Erl())
	End Sub
	
	Public Sub AfficherAchat(ByVal sNoAchat As String, ByVal eCatalogue As ModuleMain.enumCatalogue, ByVal eDemande As enumModeDemande)
		
5: On Error GoTo AfficherErreur
		
10: m_eCatalogue = eCatalogue
15: m_eDemande = eDemande
		
20: txtNoGRB.Text = sNoAchat
		
25: m_sNoAchat = VB.Left(sNoAchat, 9)
30: m_iIndexAchat = CShort(VB.Right(sNoAchat, 3))
		
35: Call RemplirListViewPieceAchat()
		
40: Call AfficherControles(enumMode.PIECE)
		
45: cmbTri.Visible = False
50: cmdTri.Visible = False
55: cmdRafraichir.Visible = False
		
60: cmbCategorie.Visible = False
65: lblCategorie.Visible = False
		
70: m_bAchat = True
		
75: Call ShowDialog()
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmChoixDemande", "AfficherProjet", Err, Erl())
	End Sub
	
	Private Sub AfficherControles(ByVal eMode As enumMode)
		
5: On Error GoTo AfficherErreur
		
10: Dim bCategorie As Boolean
15: Dim bLvwPiece As Boolean
20: Dim bLvwFournisseur As Boolean
25: Dim bLvwCategorie As Boolean
30: Dim bLvwManufacturier As Boolean
35: Dim bLvwNouvelle As Boolean
40: Dim bCmdOK As Boolean
45: Dim bCmdImprimer As Boolean
50: Dim bCmdLangage As Boolean
55: Dim bNoGRB As Boolean
60: Dim bDate As Boolean
65: Dim bCommentaire As Boolean
70: Dim bNoPiece As Boolean
75: Dim bManufact As Boolean
80: Dim bDescription As Boolean
85: Dim bCmdAjouter As Boolean
90: Dim iHeight As Short
95: Dim bRechercher As Boolean
100: Dim bTri As Boolean
105: Dim bSelectAll As Boolean
110: Dim bDeselectAll As Boolean
		
115: m_eMode = eMode
		
120: Select Case eMode
			Case enumMode.Fournisseur
125: bLvwFournisseur = True
130: bCmdImprimer = True
135: bCmdLangage = True
140: bNoGRB = True
145: bDate = True
150: bCommentaire = True
155: bRechercher = True
160: bSelectAll = True
165: bDeselectAll = True
				
170: iHeight = 6855
				
			Case enumMode.PIECE
175: bCategorie = True
180: bLvwPiece = True
185: bCmdOK = True
190: bTri = True
195: bSelectAll = True
200: bDeselectAll = True
				
205: iHeight = 6150
				
			Case enumMode.Manufacturier
210: bLvwManufacturier = True
215: bCmdOK = True
				
220: bSelectAll = True
225: bDeselectAll = True
				
230: iHeight = 6150
				
			Case enumMode.Categorie
235: bLvwCategorie = True
240: bCmdOK = True
245: bSelectAll = True
250: bDeselectAll = True
				
255: iHeight = 6150
				
			Case enumMode.NOUVELLE_PIECE
260: bLvwNouvelle = True
265: bNoPiece = True
270: bManufact = True
275: bDescription = True
280: bCategorie = True
285: bCmdOK = True
290: bCmdAjouter = True
				
295: iHeight = 6150
300: End Select
		
305: Me.Height = VB6.TwipsToPixelsY(iHeight)
		
310: lblCategorie.Visible = bCategorie
315: cmbCategorie.Visible = bCategorie
		
320: lvwPiece.Visible = bLvwPiece
325: lvwFournisseur.Visible = bLvwFournisseur
330: lvwCategorie.Visible = bLvwCategorie
335: lvwNouvellesPieces.Visible = bLvwNouvelle
340: lvwManufacturier.Visible = bLvwManufacturier
		
345: cmdSelectAll.Visible = bSelectAll
350: cmdDeselectAll.Visible = bDeselectAll
		
355: cmdOK.Visible = bCmdOK
		
360: lblNoPiece.Visible = bNoPiece
365: txtNoPiece.Visible = bNoPiece
		
370: lblManufacturier.Visible = bManufact
375: cmbManufacturier.Visible = bManufact
		
380: lblDescription.Visible = bDescription
385: txtDescription.Visible = bDescription
		
390: cmdAjouter.Visible = bCmdAjouter
		
395: cmdImprimer.Visible = bCmdImprimer
400: cmdLangage.Visible = bCmdLangage
		
405: lblNoGRB.Visible = bNoGRB
410: txtNoGRB.Visible = bNoGRB
		
415: lblDateRequise.Visible = bDate
420: mskDateRequise.Visible = bDate
425: lblFormatDate.Visible = bDate
		
430: lblCommentaire.Visible = bCommentaire
435: txtcommentaire.Visible = bCommentaire
		
440: txtRechercher.Visible = bRechercher
445: cmdRechercher.Visible = bRechercher
		
450: cmbTri.Visible = bTri
455: cmdRafraichir.Visible = bTri
460: cmdTri.Visible = bTri
		
465: Exit Sub
		
AfficherErreur: 
		
470: Call AfficherErreur("frmChoixDemande", "AfficherControles", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewManufacturier()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstManufact As ADODB.Recordset
15: Dim sWhere As String
20: Dim iCompteur As Short
		
25: Call lvwManufacturier.Items.Clear()
		
30: lvwManufacturier.Sort()
35: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwManufacturier.SortKey was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		lvwManufacturier.SortKey = 0
		
40: sWhere = "CATEGORIE In ("
		
45: For iCompteur = 1 To m_collCategorie.Count()
50: If iCompteur <> m_collCategorie.Count() Then
55: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collCategorie(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWhere = sWhere & "'" & Replace(m_collCategorie.Item(iCompteur), "'", "''") & "',"
60: Else
65: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collCategorie(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sWhere = sWhere & "'" & Replace(m_collCategorie.Item(iCompteur), "'", "''") & "')"
70: End If
75: Next 
		
80: rstManufact = New ADODB.Recordset
		
85: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
90: Call rstManufact.Open("SELECT DISTINCT FABRICANT FROM GRB_CatalogueElec WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
95: Else
100: Call rstManufact.Open("SELECT DISTINCT FABRICANT FROM GRB_CatalogueMec WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
105: End If
		
110: Do While Not rstManufact.EOF
115: Call lvwManufacturier.Items.Add(rstManufact.Fields("FABRICANT").Value)
			
120: Call rstManufact.MoveNext()
125: Loop 
		
130: Call rstManufact.Close()
135: 'UPGRADE_NOTE: Object rstManufact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstManufact = Nothing
		
140: Exit Sub
		
AfficherErreur: 
		
145: Call AfficherErreur("frmChoixDemande", "RemplirListViewManufacturier", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewFournisseur(ByVal bPiece As Boolean)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstFRS As ADODB.Recordset
15: Dim itmFRS As System.Windows.Forms.ListViewItem
20: Dim sWhere As String
25: Dim iCompteur As Short
		
30: m_bPiece = bPiece
		
35: Call lvwFournisseur.Items.Clear()
		
40: rstFRS = New ADODB.Recordset
		
45: If bPiece = False Then
50: Call rstFRS.Open("SELECT NomFournisseur, IDFRS FROM GRB_Fournisseur WHERE Supprimé = False ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
55: Else
60: sWhere = "PIECE In ("
			
65: For iCompteur = 1 To m_collPiece.Count()
70: If iCompteur <> m_collPiece.Count() Then
75: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPiece(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sWhere = sWhere & "'" & Replace(m_collPiece.Item(iCompteur), "'", "''") & "',"
80: Else
85: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPiece(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sWhere = sWhere & "'" & Replace(m_collPiece.Item(iCompteur), "'", "''") & "')"
90: End If
95: Next 
			
100: Call rstFRS.Open("SELECT DISTINCT GRB_Fournisseur.NomFournisseur, GRB_Fournisseur.IDFRS FROM GRB_PiecesFRS INNER JOIN GRB_Fournisseur ON GRB_PiecesFRS.IDFRS = GRB_Fournisseur.IDFRS WHERE " & sWhere & " ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
105: End If
		
110: Do While Not rstFRS.EOF
115: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwFournisseur.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmFRS = lvwFournisseur.Items.Add()
			
120: itmFRS.Text = rstFRS.Fields("NomFournisseur").Value
			
125: itmFRS.Tag = rstFRS.Fields("IDFRS").Value
			
130: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmFRS.SubItems.Count > I_COL_LANGAGE Then
				itmFRS.SubItems(I_COL_LANGAGE).Text = S_FRANCAIS
			Else
				itmFRS.SubItems.Insert(I_COL_LANGAGE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, S_FRANCAIS))
			End If
			
135: Call rstFRS.MoveNext()
140: Loop 
		
145: Call rstFRS.Close()
150: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
		
155: Exit Sub
		
AfficherErreur: 
		
160: Call AfficherErreur("frmChoixDemande", "RemplirListViewFournisseur", Err, Erl())
	End Sub
	
	Private Sub RemplirComboCategorie()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstCategorie As ADODB.Recordset
		
15: Call cmbCategorie.Items.Clear()
		
20: rstCategorie = New ADODB.Recordset
		
25: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
30: Call rstCategorie.Open("SELECT DISTINCT CATEGORIE FROM GRB_CatalogueElec ORDER BY Categorie", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
35: Else
40: Call rstCategorie.Open("SELECT DISTINCT CATEGORIE FROM GRB_CatalogueMec ORDER BY Categorie", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
45: End If
		
50: Do While Not rstCategorie.EOF
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstCategorie.Fields("CATEGORIE").Value) Then
60: Call cmbCategorie.Items.Add(rstCategorie.Fields("CATEGORIE").Value)
65: End If
			
70: Call rstCategorie.MoveNext()
75: Loop 
		
80: Call rstCategorie.Close()
85: 'UPGRADE_NOTE: Object rstCategorie may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstCategorie = Nothing
		
90: If cmbCategorie.Items.Count > 0 Then
95: cmbCategorie.SelectedIndex = 0
100: End If
		
105: Exit Sub
		
AfficherErreur: 
		
110: Call AfficherErreur("frmChoixDemande", "RemplirComboCategorie", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewCatalogue()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstCategorie As ADODB.Recordset
		
15: Call lvwCategorie.Items.Clear()
		
20: rstCategorie = New ADODB.Recordset
		
25: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
30: Call rstCategorie.Open("SELECT DISTINCT CATEGORIE FROM GRB_CatalogueElec ORDER BY CATEGORIE", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
35: Else
40: Call rstCategorie.Open("SELECT DISTINCT CATEGORIE FROM GRB_CatalogueMec ORDER BY CATEGORIE", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
45: End If
		
50: Do While Not rstCategorie.EOF
55: Call lvwCategorie.Items.Add(rstCategorie.Fields("CATEGORIE").Value)
			
60: Call rstCategorie.MoveNext()
65: Loop 
		
70: Call rstCategorie.Close()
75: 'UPGRADE_NOTE: Object rstCategorie may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstCategorie = Nothing
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmChoixDemande", "RemplirListViewCatalogue", Err, Erl())
	End Sub
	
	Private Function TrouverIndexPiece(ByVal sPiece As String, ByVal sDescriptionFR As String, ByVal sDescriptionEN As String, ByVal sFabricant As String, ByVal iIndexActuel As Short) As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim iIndex As Short
15: Dim sTri As String
20: Dim bDebut As Boolean
		
25: sTri = UCase(m_sTri)
		
30: sPiece = UCase(sPiece)
35: sDescriptionFR = UCase(sDescriptionFR)
40: sDescriptionEN = UCase(sDescriptionEN)
45: sFabricant = UCase(sFabricant)
		
50: If sTri <> vbNullString Then
55: bDebut = False
			
			'Selon le tri
60: Select Case cmbTri.SelectedIndex
				'Si c'est trier par PIECE
				Case I_CMB_PIECE
					'Si la PIECE contient la recherche
65: If InStr(1, sPiece, sTri) > 0 Then
						'On met la variable à true pour l'ajouter au début
70: bDebut = True
75: End If
					
					'Si c'est trier par DESCR_FR
				Case I_CMB_DESCRIPTION_FR
					'Si la description contient la recherche
80: If InStr(1, sDescriptionFR, sTri) > 0 Then
						'On met la variable à true pour l'ajouter au début
85: bDebut = True
90: End If
					
					'Si c'est trier par DESCR_EN
				Case I_CMB_DESCRIPTION_EN
					'Si la description contient la recherche
95: If InStr(1, sDescriptionEN, sTri) > 0 Then
						'On met la variable à true pour l'ajouter au début
100: bDebut = True
105: End If
					
					'Si c'est la colonne Manufacturier
				Case I_CMB_FABRICANT
					'Si le manufacturier contient la recherche
110: If InStr(1, sFabricant, sTri) > 0 Then
						'On met la variable à true pour l'ajouter au début
115: bDebut = True
120: End If
125: End Select
			
130: If bDebut = True Then
135: iIndex = iIndexActuel + 1
140: Else
145: iIndex = 0
150: End If
155: Else
160: iIndex = 0
165: End If
		
170: 'UPGRADE_WARNING: Couldn't resolve default property of object TrouverIndexPiece. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		TrouverIndexPiece = iIndex
		
175: Exit Function
		
AfficherErreur: 
		
180: Call AfficherErreur("frmChoixDemande", "TrouverIndexPiece", Err, Erl())
	End Function
	
	Private Sub RemplirListViewPiece()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPiece As ADODB.Recordset
15: Dim itmPiece As System.Windows.Forms.ListViewItem
20: Dim sCategorie As String
25: Dim sOrderBy As String
30: Dim iIndex As Short
35: Dim iCompteur As Short
		
40: sCategorie = Replace(cmbCategorie.Text, "'", "''")
		
45: Call lvwPiece.Items.Clear()
		
		'Pour savoir par quoi trier le recordset
50: Select Case cmbTri.SelectedIndex
			Case I_CMB_PIECE : sOrderBy = "PIECE"
55: Case I_CMB_DESCRIPTION_FR : sOrderBy = "DESC_FR"
60: Case I_CMB_DESCRIPTION_EN : sOrderBy = "DESC_EN"
65: Case I_CMB_FABRICANT : sOrderBy = "FABRICANT"
70: End Select
		
75: rstPiece = New ADODB.Recordset
		
80: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
85: Call rstPiece.Open("SELECT * FROM GRB_CatalogueElec WHERE CATEGORIE = '" & sCategorie & "' ORDER BY " & sOrderBy, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
90: Else
95: Call rstPiece.Open("SELECT * FROM GRB_CatalogueMec WHERE CATEGORIE = '" & sCategorie & "' ORDER BY " & sOrderBy, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
100: End If
		
105: Do While Not rstPiece.EOF
110: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPiece.Fields("DESC_FR").Value) And Not IsDbNull(rstPiece.Fields("DESC_EN").Value) Then
115: 'UPGRADE_WARNING: Couldn't resolve default property of object TrouverIndexPiece(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				iIndex = TrouverIndexPiece(rstPiece.Fields("PIECE").Value, rstPiece.Fields("DESC_FR").Value, rstPiece.Fields("DESC_EN").Value, rstPiece.Fields("FABRICANT").Value, iIndex)
120: Else
125: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPiece.Fields("DESC_FR").Value) Then
130: 'UPGRADE_WARNING: Couldn't resolve default property of object TrouverIndexPiece(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					iIndex = TrouverIndexPiece(rstPiece.Fields("PIECE").Value, rstPiece.Fields("DESC_FR").Value, vbNullString, rstPiece.Fields("FABRICANT").Value, iIndex)
135: Else
140: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstPiece.Fields("DESC_EN").Value) Then
145: 'UPGRADE_WARNING: Couldn't resolve default property of object TrouverIndexPiece(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						iIndex = TrouverIndexPiece(rstPiece.Fields("PIECE").Value, vbNullString, rstPiece.Fields("DESC_EN").Value, rstPiece.Fields("FABRICANT").Value, iIndex)
150: Else
155: 'UPGRADE_WARNING: Couldn't resolve default property of object TrouverIndexPiece(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						iIndex = TrouverIndexPiece(rstPiece.Fields("PIECE").Value, vbNullString, vbNullString, rstPiece.Fields("FABRICANT").Value, iIndex)
160: End If
165: End If
170: End If
			
175: If iIndex = 0 Then
180: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPiece.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmPiece = lvwPiece.Items.Add()
185: Else
190: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmPiece = lvwPiece.Items.Insert(iIndex, "")
195: End If
			
200: For iCompteur = 1 To m_collPiece.Count()
205: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collCategorie(iCompteur). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If m_collCategorie.Item(iCompteur) = cmbCategorie.Text Then
210: If m_collPiece.Item(iCompteur) = rstPiece.Fields("PIECE").Value Then
215: If m_collDescriptionFR.Item(iCompteur) = rstPiece.Fields("DESC_FR").Value Then
220: If m_collDescriptionEN.Item(iCompteur) = rstPiece.Fields("DESC_EN").Value Then
225: If m_collManufacturier.Item(iCompteur) = rstPiece.Fields("FABRICANT").Value Then
230: itmPiece.Checked = True
									
235: Exit For
240: End If
245: End If
250: End If
255: End If
260: End If
265: Next 
			
270: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPiece.SubItems.Count > I_COL_PIECE Then
				itmPiece.SubItems(I_COL_PIECE).Text = rstPiece.Fields("PIECE").Value
			Else
				itmPiece.SubItems.Insert(I_COL_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("PIECE").Value))
			End If
			
275: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPiece.Fields("DESC_FR").Value) Then
280: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_DESC_FR Then
					itmPiece.SubItems(I_COL_DESC_FR).Text = rstPiece.Fields("DESC_FR").Value
				Else
					itmPiece.SubItems.Insert(I_COL_DESC_FR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("DESC_FR").Value))
				End If
285: Else
290: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_DESC_FR Then
					itmPiece.SubItems(I_COL_DESC_FR).Text = vbNullString
				Else
					itmPiece.SubItems.Insert(I_COL_DESC_FR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
295: End If
			
300: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPiece.Fields("DESC_EN").Value) Then
305: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_DESC_EN Then
					itmPiece.SubItems(I_COL_DESC_EN).Text = rstPiece.Fields("DESC_EN").Value
				Else
					itmPiece.SubItems.Insert(I_COL_DESC_EN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("DESC_EN").Value))
				End If
310: Else
315: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_DESC_EN Then
					itmPiece.SubItems(I_COL_DESC_EN).Text = vbNullString
				Else
					itmPiece.SubItems.Insert(I_COL_DESC_EN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
320: End If
			
325: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPiece.SubItems.Count > I_COL_FABRICANT Then
				itmPiece.SubItems(I_COL_FABRICANT).Text = rstPiece.Fields("FABRICANT").Value
			Else
				itmPiece.SubItems.Insert(I_COL_FABRICANT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("FABRICANT").Value))
			End If
			
330: Call rstPiece.MoveNext()
335: Loop 
		
340: Call rstPiece.Close()
345: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
350: Exit Sub
		
AfficherErreur: 
		
355: Call AfficherErreur("frmChoixDemande", "RemplirListViewPiece", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewPieceProjetSoumission()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPiece As ADODB.Recordset
15: Dim itmPiece As System.Windows.Forms.ListViewItem
		
20: Call lvwPiece.Items.Clear()
		
25: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwPiece.Sorted was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		lvwPiece.Sorted = False
		
30: rstPiece = New ADODB.Recordset
		
		'Si c'est un projet
35: If m_eType = enumType.TYPE_PROJET Then
40: Call rstPiece.Open("SELECT Qté, NumItem, Desc_FR, Desc_EN, Manufact, IDFRS, PieceExtraChargeable, PieceExtraNonChargeable FROM GRB_Projet_Pieces WHERE (IDProjet = '" & m_sNoProjSoum & "') AND (IDFRS = 0 AND NumItem <> 'Texte') ORDER BY NuméroLigne", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
45: Else
			'Si c'est une soumission
50: Call rstPiece.Open("SELECT Qté, NumItem, Desc_FR, Desc_En, Manufact, IDFRS, PieceExtraChargeable, PieceExtraNonChargeable FROM GRB_Soumission_Pieces WHERE (IDSoumission = '" & m_sNoProjSoum & "') AND (IDFRS = 0 AND NumItem <> 'Texte') ORDER BY NuméroLigne", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
55: End If
		
60: Do While Not rstPiece.EOF
65: If rstPiece.Fields("PieceExtraChargeable").Value = False And rstPiece.Fields("PieceExtraNonChargeable").Value = False Then
70: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPiece.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmPiece = lvwPiece.Items.Add()
				
75: itmPiece.Text = rstPiece.Fields("Qté").Value
				
80: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_PIECE Then
					itmPiece.SubItems(I_COL_PIECE).Text = rstPiece.Fields("NumItem").Value
				Else
					itmPiece.SubItems.Insert(I_COL_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("NumItem").Value))
				End If
				
85: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPiece.Fields("Desc_FR").Value) Then
90: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_DESC_FR Then
						itmPiece.SubItems(I_COL_DESC_FR).Text = rstPiece.Fields("Desc_FR").Value
					Else
						itmPiece.SubItems.Insert(I_COL_DESC_FR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("Desc_FR").Value))
					End If
95: Else
100: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_DESC_FR Then
						itmPiece.SubItems(I_COL_DESC_FR).Text = vbNullString
					Else
						itmPiece.SubItems.Insert(I_COL_DESC_FR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
105: End If
				
110: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPiece.Fields("Desc_En").Value) Then
115: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_DESC_EN Then
						itmPiece.SubItems(I_COL_DESC_EN).Text = rstPiece.Fields("Desc_En").Value
					Else
						itmPiece.SubItems.Insert(I_COL_DESC_EN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("Desc_En").Value))
					End If
120: Else
125: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPiece.SubItems.Count > I_COL_DESC_EN Then
						itmPiece.SubItems(I_COL_DESC_EN).Text = vbNullString
					Else
						itmPiece.SubItems.Insert(I_COL_DESC_EN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
130: End If
				
135: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_FABRICANT Then
					itmPiece.SubItems(I_COL_FABRICANT).Text = rstPiece.Fields("Manufact").Value
				Else
					itmPiece.SubItems.Insert(I_COL_FABRICANT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("Manufact").Value))
				End If
140: End If
			
145: Call rstPiece.MoveNext()
150: Loop 
		
155: Call rstPiece.Close()
160: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
165: Exit Sub
		
AfficherErreur: 
		
170: Call AfficherErreur("frmChoixDemande", "RemplirListViewPieceProjet", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewPieceAchat()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPiece As ADODB.Recordset
15: Dim itmPiece As System.Windows.Forms.ListViewItem
		
20: Call lvwPiece.Items.Clear()
		
25: rstPiece = New ADODB.Recordset
		
30: Call rstPiece.Open("SELECT Qté, PIECE, Desc_FR, Desc_EN, Manufact, IDFRS FROM GRB_Achat_Pieces WHERE IDAchat = '" & m_sNoAchat & "' AND IndexAchat = " & m_iIndexAchat & " AND IDFRS = 0 ORDER BY NuméroLigne", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
35: Do While Not rstPiece.EOF
40: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPiece.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmPiece = lvwPiece.Items.Add()
			
45: itmPiece.Text = rstPiece.Fields("Qté").Value
			
50: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPiece.SubItems.Count > I_COL_PIECE Then
				itmPiece.SubItems(I_COL_PIECE).Text = rstPiece.Fields("PIECE").Value
			Else
				itmPiece.SubItems.Insert(I_COL_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("PIECE").Value))
			End If
			
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPiece.Fields("Desc_FR").Value) Then
60: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_DESC_FR Then
					itmPiece.SubItems(I_COL_DESC_FR).Text = rstPiece.Fields("Desc_FR").Value
				Else
					itmPiece.SubItems.Insert(I_COL_DESC_FR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("Desc_FR").Value))
				End If
65: Else
70: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_DESC_FR Then
					itmPiece.SubItems(I_COL_DESC_FR).Text = vbNullString
				Else
					itmPiece.SubItems.Insert(I_COL_DESC_FR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
75: End If
			
80: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPiece.Fields("Desc_En").Value) Then
85: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_DESC_EN Then
					itmPiece.SubItems(I_COL_DESC_EN).Text = rstPiece.Fields("Desc_En").Value
				Else
					itmPiece.SubItems.Insert(I_COL_DESC_EN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("Desc_En").Value))
				End If
90: Else
95: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_DESC_EN Then
					itmPiece.SubItems(I_COL_DESC_EN).Text = vbNullString
				Else
					itmPiece.SubItems.Insert(I_COL_DESC_EN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
100: End If
			
105: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPiece.SubItems.Count > I_COL_FABRICANT Then
				itmPiece.SubItems(I_COL_FABRICANT).Text = rstPiece.Fields("Manufact").Value
			Else
				itmPiece.SubItems.Insert(I_COL_FABRICANT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("Manufact").Value))
			End If
			
110: Call rstPiece.MoveNext()
115: Loop 
		
120: Call rstPiece.Close()
125: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
130: Exit Sub
		
AfficherErreur: 
		
135: Call AfficherErreur("frmChoixDemande", "RemplirListViewPieceProjet", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbCategorie.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbCategorie_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbCategorie.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: Call AjouterPieceCollection()
		
15: m_sCategorie = cmbCategorie.Text
		
20: Call RemplirListViewPiece()
		
25: Call CocherCases()
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixDemande", "cmbCategorie_Click", Err, Erl())
	End Sub
	
	Private Sub RemplirComboManufacturiers()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPiece As ADODB.Recordset
		
15: Call cmbManufacturier.Items.Clear()
		
20: rstPiece = New ADODB.Recordset
		
25: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
30: Call rstPiece.Open("SELECT DISTINCT FABRICANT FROM GRB_CatalogueElec", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
35: Else
40: Call rstPiece.Open("SELECT DISTINCT FABRICANT FROM GRB_CatalogueMec", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
45: End If
		
50: Do While Not rstPiece.EOF
55: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPiece.Fields("FABRICANT").Value) Then
60: Call cmbManufacturier.Items.Add(rstPiece.Fields("FABRICANT").Value)
65: End If
			
70: Call rstPiece.MoveNext()
75: Loop 
		
80: Call rstPiece.Close()
85: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
90: Exit Sub
		
AfficherErreur: 
		
95: Call AfficherErreur("frmChoixDemande", "RemplirComboManufacturiers", Err, Erl())
	End Sub
	
	Private Sub CocherCases()
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim iCompteur2 As Short
		
20: For iCompteur = 1 To m_collCategorie.Count()
25: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collCategorie(iCompteur). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If m_collCategorie.Item(iCompteur) = cmbCategorie.Text Then
30: For iCompteur2 = 1 To lvwPiece.Items.Count
35: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPiece(iCompteur). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvwPiece.Items.Item(iCompteur2).SubItems(I_COL_PIECE).Text = m_collPiece.Item(iCompteur) Then
40: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						lvwPiece.Items.Item(iCompteur2).Checked = True
45: End If
50: Next iCompteur2
55: End If
60: Next iCompteur
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmChoixDemande", "CocherCases", Err, Erl())
	End Sub
	
	Private Sub cmbManufacturier_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cmbManufacturier.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
5: On Error GoTo AfficherErreur
		
10: If KeyAscii <= 122 And KeyAscii >= 97 Then
15: KeyAscii = KeyAscii - 32
20: End If
		
25: GoTo EventExitSub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixDemande", "cmbManufacturier_KeyPress", Err, Erl())
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub cmdAjouter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAjouter.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPiece As ADODB.Recordset
15: Dim iCompteur As Short
20: Dim bTrouver As Boolean
25: Dim itmPiece As System.Windows.Forms.ListViewItem
30: Dim sQuantite As String
		
35: If txtNoPiece.Text = vbNullString Or cmbManufacturier.Text = vbNullString Or txtDescription.Text = vbNullString Then
40: Call MsgBox("Vous devez absolument remplir tous les champs!", MsgBoxStyle.OKOnly, "Erreur")
			
45: Exit Sub
50: End If
		
55: If InStr(1, txtNoPiece.Text, "'") > 0 Then
60: Call MsgBox("Numéro invalide! Le numéro ne doit pas contenir d'appostrophes!", MsgBoxStyle.OKOnly, "Erreur")
			
65: Exit Sub
70: End If
		
75: rstPiece = New ADODB.Recordset
		
80: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
85: Call rstPiece.Open("SELECT * FROM GRB_CatalogueElec WHERE PIECE = '" & Replace(txtNoPiece.Text, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
90: Else
95: Call rstPiece.Open("SELECT * FROM GRB_CatalogueMec WHERE PIECE = '" & Replace(txtNoPiece.Text, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
100: End If
		
105: If rstPiece.EOF = False Then
110: bTrouver = True
115: End If
		
120: Call rstPiece.Close()
125: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
135: If bTrouver = True Then
140: Call MsgBox("Le numéro de pièce existe déjà!", MsgBoxStyle.OKOnly, "Erreur")
			
145: Exit Sub
150: End If
		
155: sQuantite = InputBox("Quelle est la quantité?")
		
160: If sQuantite <> vbNullString Then
165: If Not IsNumeric(sQuantite) Then
170: Call MsgBox("Quantité non numérique!", MsgBoxStyle.OKOnly, "Erreur")
				
175: Exit Sub
180: End If
185: Else
190: sQuantite = "1"
195: End If
		
200: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwNouvellesPieces.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		itmPiece = lvwNouvellesPieces.Items.Add()
		
205: itmPiece.Text = sQuantite
210: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmPiece.SubItems.Count > I_COL_NO_PIECE Then
			itmPiece.SubItems(I_COL_NO_PIECE).Text = txtNoPiece.Text
		Else
			itmPiece.SubItems.Insert(I_COL_NO_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, txtNoPiece.Text))
		End If
215: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmPiece.SubItems.Count > I_COL_DESCRIPTION Then
			itmPiece.SubItems(I_COL_DESCRIPTION).Text = txtDescription.Text
		Else
			itmPiece.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, txtDescription.Text))
		End If
220: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmPiece.SubItems.Count > I_COL_MANUFACT Then
			itmPiece.SubItems(I_COL_MANUFACT).Text = cmbManufacturier.Text
		Else
			itmPiece.SubItems.Insert(I_COL_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, cmbManufacturier.Text))
		End If
225: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmPiece.SubItems.Count > I_COL_CATEGORIE Then
			itmPiece.SubItems(I_COL_CATEGORIE).Text = cmbCategorie.Text
		Else
			itmPiece.SubItems.Insert(I_COL_CATEGORIE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, cmbCategorie.Text))
		End If
		
230: Exit Sub
		
AfficherErreur: 
		
235: Call AfficherErreur("frmChoixDemande", "cmdAjouter_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDemande", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub cmdImprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImprimer.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim itmFRS As System.Windows.Forms.ListViewItem
		
20: If lvwFournisseur.Items.Count > 0 Then
25: If VerifierSiChecked = True Then
30: For iCompteur = 1 To lvwFournisseur.Items.Count
35: 'UPGRADE_WARNING: Lower bound of collection lvwFournisseur.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvwFournisseur.Items.Item(iCompteur).Checked = True Then
40: 'UPGRADE_WARNING: Lower bound of collection lvwFournisseur.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						itmFRS = lvwFournisseur.Items.Item(iCompteur)
						
45: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						m_sLangage = itmFRS.SubItems(I_COL_LANGAGE).Text
						
50: Call frmChoixContactFRS.Afficher(itmFRS.Tag)
						
55: If m_bAnnulerContact = False Then
60: If m_eDemande = enumModeDemande.MODE_NOUVELLE Then
65: Call EnregistrerDemandePrixNouvellesPieces()
70: Else
75: Call EnregistrerDemandePrix(itmFRS.Tag)
80: End If
							
85: Call ImprimerDemandePrix(itmFRS.Tag)
90: End If
95: End If
100: Next 
				
105: If m_eDemande = enumModeDemande.MODE_NOUVELLE Then
110: Call EnregistrerPieces()
115: End If
120: End If
125: End If
		
130: Exit Sub
		
AfficherErreur: 
		
135: Call AfficherErreur("frmChoixDemande", "cmdImprimer_Click", Err, Erl())
	End Sub
	
	Private Sub EnregistrerPieces()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPiece As ADODB.Recordset
15: Dim rstPiecesFRS As ADODB.Recordset
20: Dim iCompteurPieces As Short
25: Dim iCompteurFRS As Short
		
30: rstPiece = New ADODB.Recordset
35: rstPiecesFRS = New ADODB.Recordset
		
40: For iCompteurPieces = 1 To m_collPiece.Count()
45: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
50: Call rstPiece.Open("SELECT * FROM GRB_CatalogueElec", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
55: Else
60: Call rstPiece.Open("SELECT * FROM GRB_CatalogueMec", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
65: End If
			
70: Call rstPiece.AddNew()
			
75: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPiece(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rstPiece.Fields("PIECE").Value = m_collPiece.Item(iCompteurPieces)
80: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPiece(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rstPiece.Fields("PIECE_GRB").Value = m_collPiece.Item(iCompteurPieces) & "GRB"
85: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collDescriptionFR(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rstPiece.Fields("DESC_FR").Value = m_collDescriptionFR.Item(iCompteurPieces)
90: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collManufacturier(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rstPiece.Fields("FABRICANT").Value = m_collManufacturier.Item(iCompteurPieces)
95: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collCategorie(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rstPiece.Fields("CATEGORIE").Value = m_collCategorie.Item(iCompteurPieces)
			
100: Call rstPiece.Update()
			
105: Call rstPiecesFRS.Open("SELECT * FROM GRB_PiecesFRS", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
110: For iCompteurFRS = 1 To lvwFournisseur.Items.Count
115: 'UPGRADE_WARNING: Lower bound of collection lvwFournisseur.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwFournisseur.Items.Item(iCompteurFRS).Checked = True Then
120: Call rstPiecesFRS.AddNew()
					
125: 'UPGRADE_WARNING: Lower bound of collection lvwFournisseur.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Couldn't resolve default property of object lvwFournisseur.ListItems().Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					rstPiecesFRS.Fields("IDFRS").Value = lvwFournisseur.Items.Item(iCompteurFRS).Tag
130: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPiece(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					rstPiecesFRS.Fields("PIECE").Value = m_collPiece.Item(iCompteurPieces)
135: rstPiecesFRS.Fields("DATE").Value = ConvertDate(Today)
140: rstPiecesFRS.Fields("ENTRER_PAR").Value = g_sInitiale
145: rstPiecesFRS.Fields("PRIX_SP").Value = vbNullString
150: rstPiecesFRS.Fields("PERS_RESS").Value = vbNullString
155: rstPiecesFRS.Fields("PRIX_LIST").Value = "0"
160: rstPiecesFRS.Fields("ESCOMPTE").Value = "0"
165: rstPiecesFRS.Fields("PRIX_NET").Value = "0"
170: rstPiecesFRS.Fields("DeviseMonétaire").Value = "CAN"
175: rstPiecesFRS.Fields("PrixReel").Value = "0"
180: rstPiecesFRS.Fields("Type").Value = "M"
					
185: Call rstPiecesFRS.Update()
190: End If
195: Next 
			
200: Call rstPiecesFRS.Close()
			
205: Call rstPiece.Close()
210: Next 
		
215: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
220: 'UPGRADE_NOTE: Object rstPiecesFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiecesFRS = Nothing
		
225: Exit Sub
		
AfficherErreur: 
		
230: Call AfficherErreur("frmChoixDemande", "EnregistrerPieces", Err, Erl())
	End Sub
	
	Private Sub cmdLangage_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLangage.Click
		
5: On Error GoTo AfficherErreur
		
10: If cmdLangage.Text = S_DEMANDE_FRANCAIS Then
15: 'UPGRADE_WARNING: Lower bound of collection lvwFournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwFournisseur.FocusedItem.SubItems.Count > I_COL_LANGAGE Then
				lvwFournisseur.FocusedItem.SubItems(I_COL_LANGAGE).Text = S_FRANCAIS
			Else
				lvwFournisseur.FocusedItem.SubItems.Insert(I_COL_LANGAGE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, S_FRANCAIS))
			End If
			
20: cmdLangage.Text = S_DEMANDE_ANGLAIS
25: Else
30: 'UPGRADE_WARNING: Lower bound of collection lvwFournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwFournisseur.FocusedItem.SubItems.Count > I_COL_LANGAGE Then
				lvwFournisseur.FocusedItem.SubItems(I_COL_LANGAGE).Text = S_ANGLAIS
			Else
				lvwFournisseur.FocusedItem.SubItems.Insert(I_COL_LANGAGE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, S_ANGLAIS))
			End If
			
35: cmdLangage.Text = S_DEMANDE_FRANCAIS
40: End If
		
45: Call lvwFournisseur.Focus()
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmChoixDemande", "cmdLangage_Click", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
10: If m_eMode = enumMode.PIECE Then
15: Call AjouterPieceCollection()
			
20: Call AfficherFournisseur()
25: Else
30: If m_eMode = enumMode.NOUVELLE_PIECE Then
35: Call AjouterNouvellePieceCollection()
				
40: Call RemplirListViewFournisseur(False)
				
45: Call AfficherControles(enumMode.Fournisseur)
50: Else
55: If m_eMode = enumMode.Manufacturier Then
60: Call AjouterManufacturierCollection()
					
65: Call RemplirListViewFournisseur(False)
					
70: Call AfficherControles(enumMode.Fournisseur)
75: Else
80: Call AjouterCategorieCollection()
					
85: If VerifierSiChecked = True Then
90: Call RemplirListViewManufacturier()
						
95: Call AfficherControles(enumMode.Manufacturier)
100: End If
105: End If
110: End If
115: End If
		
120: Exit Sub
		
AfficherErreur: 
		
125: Call AfficherErreur("frmChoixDemande", "cmdOK_Click", Err, Erl())
	End Sub
	
	Private Sub AjouterNouvellePieceCollection()
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim itmPiece As System.Windows.Forms.ListViewItem
		
20: For iCompteur = 1 To lvwNouvellesPieces.Items.Count
25: 'UPGRADE_WARNING: Lower bound of collection lvwNouvellesPieces.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmPiece = lvwNouvellesPieces.Items.Item(iCompteur)
			
30: Call m_collQuantite.Add(itmPiece.Text)
35: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Call m_collPiece.Add(itmPiece.SubItems(I_COL_NO_PIECE).Text)
40: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Call m_collDescriptionFR.Add(itmPiece.SubItems(I_COL_DESCRIPTION).Text)
45: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Call m_collManufacturier.Add(itmPiece.SubItems(I_COL_MANUFACT).Text)
50: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Call m_collCategorie.Add(itmPiece.SubItems(I_COL_CATEGORIE).Text)
55: Next 
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmChoixDemande", "AjouterNouvellePieceCollection", Err, Erl())
	End Sub
	
	Private Sub AjouterManufacturierCollection()
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: For iCompteur = 1 To lvwManufacturier.Items.Count
20: 'UPGRADE_WARNING: Lower bound of collection lvwManufacturier.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwManufacturier.Items.Item(iCompteur).Checked = True Then
25: 'UPGRADE_WARNING: Lower bound of collection lvwManufacturier.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				Call m_collManufacturier.Add(lvwManufacturier.Items.Item(iCompteur).Text)
30: End If
35: Next 
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmChoixDemande", "AjouterManufacturierCollection", Err, Erl())
	End Sub
	
	Private Sub AjouterCategorieCollection()
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: For iCompteur = 1 To lvwCategorie.Items.Count
20: 'UPGRADE_WARNING: Lower bound of collection lvwCategorie.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwCategorie.Items.Item(iCompteur).Checked = True Then
25: 'UPGRADE_WARNING: Lower bound of collection lvwCategorie.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				Call m_collCategorie.Add(lvwCategorie.Items.Item(iCompteur).Text)
30: End If
35: Next 
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmChoixDemande", "AjouterCategorieCollection", Err, Erl())
	End Sub
	
	Private Sub cmdRechercher_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRechercher.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim bTrouver As Boolean
		
		'Si le texte du bouton est rechercher
20: If cmdRechercher.Text = "Rechercher" Then
			'Pour chaque élément du listview
25: For iCompteur = 1 To lvwFournisseur.Items.Count
				'si le nom du fournisseur contient le texte à rechercher
30: 'UPGRADE_WARNING: Lower bound of collection lvwFournisseur.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If InStr(1, UCase(lvwFournisseur.Items.Item(iCompteur).Text), UCase(txtRechercher.Text)) > 0 Then
35: bTrouver = True
					
40: 'UPGRADE_WARNING: Lower bound of collection lvwFournisseur.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					lvwFournisseur.Items.Item(iCompteur).Selected = True
					
45: 'UPGRADE_WARNING: Lower bound of collection lvwFournisseur.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: MSComctlLib.IListItem method lvwFournisseur.ListItems.EnsureVisible has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
					Call lvwFournisseur.Items.Item(iCompteur).EnsureVisible()
					
50: Call lvwFournisseur.Focus()
					
55: m_iIndexRecherche = iCompteur
					
60: Exit For
65: End If
70: Next 
			
75: If bTrouver = True Then
80: cmdRechercher.Text = "Suivant"
85: Else
90: Call MsgBox("Aucun fournisseur trouvé!", MsgBoxStyle.OKOnly)
95: End If
100: Else
			'Pour chaque élément restant du listview
105: For iCompteur = m_iIndexRecherche + 1 To lvwFournisseur.Items.Count
				'Si le nom du fournisseur contient le texte à rechercher
110: 'UPGRADE_WARNING: Lower bound of collection lvwFournisseur.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If InStr(1, UCase(lvwFournisseur.Items.Item(iCompteur).Text), UCase(txtRechercher.Text)) > 0 Then
115: bTrouver = True
					
120: 'UPGRADE_WARNING: Lower bound of collection lvwFournisseur.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					lvwFournisseur.Items.Item(iCompteur).Selected = True
					
125: 'UPGRADE_WARNING: Lower bound of collection lvwFournisseur.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: MSComctlLib.IListItem method lvwFournisseur.ListItems.EnsureVisible has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
					Call lvwFournisseur.Items.Item(iCompteur).EnsureVisible()
					
130: Call lvwFournisseur.Focus()
					
135: m_iIndexRecherche = iCompteur
					
140: Exit For
145: End If
150: Next 
			
155: If bTrouver = False Then
160: Call MsgBox("Aucun fournisseur trouvé!", MsgBoxStyle.OKOnly)
				
165: cmdRechercher.Text = "Rechercher"
170: End If
175: End If
		
180: Exit Sub
		
AfficherErreur: 
		
185: Call AfficherErreur("frmChoixDemande", "cmdRechercher_Click", Err, Erl())
	End Sub
	
	Private Sub cmdSelectAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelectAll.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim lvwSource As System.Windows.Forms.ListView
15: Dim iCompteur As Short
		
		Select Case m_eMode
			Case enumMode.PIECE : lvwSource = lvwPiece
			Case enumMode.Categorie : lvwSource = lvwCategorie
			Case enumMode.Fournisseur : lvwSource = lvwFournisseur
			Case enumMode.Manufacturier : lvwSource = lvwManufacturier
		End Select
		
20: For iCompteur = 1 To lvwSource.Items.Count
25: 'UPGRADE_WARNING: Lower bound of collection lvwSource.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwSource.Items.Item(iCompteur).Checked = True
30: Next 
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmChoixDemande", "cmdSelectAll_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDeSelectAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDeSelectAll.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim lvwSource As System.Windows.Forms.ListView
15: Dim iCompteur As Short
		
		Select Case m_eMode
			Case enumMode.PIECE : lvwSource = lvwPiece
			Case enumMode.Categorie : lvwSource = lvwCategorie
			Case enumMode.Fournisseur : lvwSource = lvwFournisseur
			Case enumMode.Manufacturier : lvwSource = lvwManufacturier
		End Select
		
20: For iCompteur = 1 To lvwSource.Items.Count
25: 'UPGRADE_WARNING: Lower bound of collection lvwSource.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwSource.Items.Item(iCompteur).Checked = False
30: Next 
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmChoixDemande", "cmdSelectAll_Click", Err, Erl())
	End Sub
	
	
	Private Sub cmdTri_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTri.Click
		
5: On Error GoTo AfficherErreur
		
10: m_sTri = InputBox("Quel est la pièce à trier?")
		
15: If m_sTri <> vbNullString Then
20: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwCategorie.Sorted was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			lvwCategorie.Sorted = False
25: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwPiece.Sorted was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			lvwPiece.Sorted = False
30: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwFournisseur.Sorted was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			lvwFournisseur.Sorted = False
35: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwNouvellesPieces.Sorted was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			lvwNouvellesPieces.Sorted = False
			
40: Call AjouterPieceCollection()
			
45: Call RemplirListViewPiece()
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmChoixDemande", "cmdTri_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRafraichir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRafraichir.Click
		
5: On Error GoTo AfficherErreur
		
10: If m_sTri <> vbNullString Then
15: m_sTri = vbNullString
			
20: Call RemplirListViewPiece()
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixDemande", "cmdRafraichir_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixDemande_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: m_collPiece = New Collection
15: m_collQuantite = New Collection
20: m_collDescriptionFR = New Collection
25: m_collDescriptionEN = New Collection
30: m_collCategorie = New Collection
35: m_collManufacturier = New Collection
		
40: cmbTri.SelectedIndex = I_CMB_PIECE
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmChoixDemande", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub frmChoixDemande_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		
5: On Error GoTo AfficherErreur
		
10: m_sTri = vbNullString
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDemande", "Form_Unload", Err, Erl())
	End Sub
	
	Private Sub lvwCategorie_ColumnClick(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ColumnClickEventArgs) Handles lvwCategorie.ColumnClick
		Dim ColumnHeader As System.Windows.Forms.ColumnHeader = lvwCategorie.Columns(eventArgs.Column)
		
5: On Error GoTo AfficherErreur
		
10: lvwCategorie.Sort()
		
15: If lvwCategorie.Sorting = System.Windows.Forms.SortOrder.Ascending Then
20: lvwCategorie.Sorting = System.Windows.Forms.SortOrder.Descending
25: Else
30: lvwCategorie.Sorting = System.Windows.Forms.SortOrder.Ascending
35: End If
		
40: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwCategorie.SortKey was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		lvwCategorie.SortKey = ColumnHeader.Index - 1
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmChoixDemande", "lvwCategorie_ColumnClick", Err, Erl())
	End Sub
	
	Private Sub lvwFournisseur_ColumnClick(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ColumnClickEventArgs) Handles lvwFournisseur.ColumnClick
		Dim ColumnHeader As System.Windows.Forms.ColumnHeader = lvwFournisseur.Columns(eventArgs.Column)
		
5: On Error GoTo AfficherErreur
		
10: lvwFournisseur.Sort()
		
15: If lvwFournisseur.Sorting = System.Windows.Forms.SortOrder.Ascending Then
20: lvwFournisseur.Sorting = System.Windows.Forms.SortOrder.Descending
25: Else
30: lvwFournisseur.Sorting = System.Windows.Forms.SortOrder.Ascending
35: End If
		
40: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwFournisseur.SortKey was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		lvwFournisseur.SortKey = ColumnHeader.Index - 1
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmChoixDemande", "lvwFournisseur_ColumnClick", Err, Erl())
	End Sub
	
	'UPGRADE_ISSUE: MSComctlLib.ListView event lvwFournisseur.ItemClick was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub lvwFournisseur_ItemClick(ByVal Item As System.Windows.Forms.ListViewItem)
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Lower bound of collection Item has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If Item.SubItems(I_COL_LANGAGE).Text = S_FRANCAIS Then
15: cmdLangage.Text = S_DEMANDE_ANGLAIS
20: Else
25: cmdLangage.Text = S_DEMANDE_FRANCAIS
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmChoixDemande", "lvwFournisseur_ItemClick", Err, Erl())
	End Sub
	
	Private Sub lvwNouvellesPieces_ColumnClick(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ColumnClickEventArgs) Handles lvwNouvellesPieces.ColumnClick
		Dim ColumnHeader As System.Windows.Forms.ColumnHeader = lvwNouvellesPieces.Columns(eventArgs.Column)
		
5: On Error GoTo AfficherErreur
		
10: lvwNouvellesPieces.Sort()
		
15: If lvwNouvellesPieces.Sorting = System.Windows.Forms.SortOrder.Ascending Then
20: lvwNouvellesPieces.Sorting = System.Windows.Forms.SortOrder.Descending
25: Else
30: lvwNouvellesPieces.Sorting = System.Windows.Forms.SortOrder.Ascending
35: End If
		
40: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwNouvellesPieces.SortKey was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		lvwNouvellesPieces.SortKey = ColumnHeader.Index - 1
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmChoixDemande", "lvwNouvellesPieces_ColumnClick", Err, Erl())
	End Sub
	
	Private Sub lvwNouvellesPieces_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lvwNouvellesPieces.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: If KeyCode = System.Windows.Forms.Keys.Delete Then
15: Call lvwNouvellesPieces.Items.RemoveAt(lvwNouvellesPieces.FocusedItem.Index)
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixDemande", "lvwNouvellesPieces_KeyDown", Err, Erl())
	End Sub
	
	Private Sub lvwPiece_ColumnClick(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ColumnClickEventArgs) Handles lvwPiece.ColumnClick
		Dim ColumnHeader As System.Windows.Forms.ColumnHeader = lvwPiece.Columns(eventArgs.Column)
		
5: On Error GoTo AfficherErreur
		
10: lvwPiece.Sort()
		
15: If lvwPiece.Sorting = System.Windows.Forms.SortOrder.Ascending Then
20: lvwPiece.Sorting = System.Windows.Forms.SortOrder.Descending
25: Else
30: lvwPiece.Sorting = System.Windows.Forms.SortOrder.Ascending
35: End If
		
40: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwPiece.SortKey was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		lvwPiece.SortKey = ColumnHeader.Index - 1
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmChoixDemande", "lvwPiece_ColumnClick", Err, Erl())
	End Sub
	
	Private Sub lvwPiece_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwPiece.DoubleClick
		
5: On Error GoTo AfficherErreur
		
10: Dim sQuantite As String
		
15: If lvwPiece.Items.Count > 0 Then
20: sQuantite = InputBox("Quelle est la quantité?")
			
25: If sQuantite <> vbNullString Then
30: If IsNumeric(sQuantite) Then
35: lvwPiece.FocusedItem.Text = sQuantite
40: End If
45: End If
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmChoixDemande", "lvwPiece_DblClick", Err, Erl())
	End Sub
	
	Private Sub AfficherFournisseur()
		
5: On Error GoTo AfficherErreur
		
10: If lvwPiece.Items.Count > 0 Then
15: If VerifierSiChecked = True Then
				
20: Call RemplirListViewFournisseur(True)
				
25: If lvwFournisseur.Items.Count > 0 Then
30: Call AfficherControles(enumMode.Fournisseur)
35: Else
40: Call MsgBox("Il n'y a aucun fournisseur pour cette pièce!", MsgBoxStyle.OKOnly, "Erreur")
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmChoixDemande", "AfficherFournisseur", Err, Erl())
	End Sub
	
	Private Sub AjouterPieceCollection()
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim iCompteur2 As Short
20: Dim bPieceExiste As Boolean
25: Dim iQuantite As Short
30: Dim rstTempDP As ADODB.Recordset
		
35: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
40: Call g_connData.Execute("DELETE * FROM GRB_TempDP WHERE TYPE = 'E'")
45: Else
50: Call g_connData.Execute("DELETE * FROM GRB_TempDP WHERE TYPE = 'M'")
55: End If
		
60: rstTempDP = New ADODB.Recordset
		
65: Call rstTempDP.Open("SELECT * FROM GRB_TempDP", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
70: For iCompteur = 1 To lvwPiece.Items.Count
75: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwPiece.Items.Item(iCompteur).Checked = True Then
80: bPieceExiste = False
				
85: For iCompteur2 = 1 To m_collPiece.Count()
90: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPiece(iCompteur2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvwPiece.Items.Item(iCompteur).SubItems(I_COL_PIECE).Text = m_collPiece.Item(iCompteur2) Then
95: bPieceExiste = True
						
100: Exit For
105: End If
110: Next iCompteur2
				
115: If bPieceExiste = False Then
120: Call m_collCategorie.Add(m_sCategorie)
125: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call m_collPiece.Add(lvwPiece.Items.Item(iCompteur).SubItems(I_COL_PIECE).Text)
130: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call m_collDescriptionFR.Add(lvwPiece.Items.Item(iCompteur).SubItems(I_COL_DESC_FR).Text)
135: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call m_collDescriptionEN.Add(lvwPiece.Items.Item(iCompteur).SubItems(I_COL_DESC_EN).Text)
140: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call m_collManufacturier.Add(lvwPiece.Items.Item(iCompteur).SubItems(I_COL_FABRICANT).Text)
					
145: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvwPiece.Items.Item(iCompteur).Text <> vbNullString Then
150: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						Call m_collQuantite.Add(lvwPiece.Items.Item(iCompteur).Text)
155: Else
160: Call m_collQuantite.Add("1")
165: End If
					
170: Call rstTempDP.AddNew()
					
175: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					rstTempDP.Fields("PIECE").Value = lvwPiece.Items.Item(iCompteur).SubItems(I_COL_PIECE).Text
180: rstTempDP.Fields("ORDRE").Value = iCompteur
					
185: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
190: rstTempDP.Fields("TYPE").Value = "E"
195: Else
200: rstTempDP.Fields("TYPE").Value = "M"
205: End If
					
210: Call rstTempDP.Update()
215: Else
					'Ajoute la quantité si c'est une demande de prix à partir d'un projet
220: If m_bProjSoum = True Then
225: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Couldn't resolve default property of object m_collQuantite(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						iQuantite = Val(m_collQuantite.Item(iCompteur2)) + Val(lvwPiece.Items.Item(iCompteur).Text)
						
230: Call m_collQuantite.Remove(iCompteur2)
						
235: If m_collQuantite.Count() > 0 Then
240: If m_collQuantite.Count() < iCompteur2 Then
245: Call m_collQuantite.Add(iQuantite)
250: Else
255: If iCompteur2 > 1 Then
260: Call m_collQuantite.Add(iQuantite,  ,  , iCompteur2 - 1)
265: Else
270: Call m_collQuantite.Add(iQuantite,  ,  , 1)
275: End If
280: End If
285: Else
290: Call m_collQuantite.Add(iQuantite)
295: End If
300: End If
305: End If
310: End If
315: Next iCompteur
		
320: Call rstTempDP.Close()
325: 'UPGRADE_NOTE: Object rstTempDP may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstTempDP = Nothing
		
330: Exit Sub
		
AfficherErreur: 
		
335: Call AfficherErreur("frmChoixDemande", "AjouterPieceCollection", Err, Erl())
	End Sub
	
	Private Function VerifierSiChecked() As Boolean
		
5: On Error GoTo AfficherErreur
		
10: Dim lvwSource As System.Windows.Forms.ListView
15: Dim iCompteur As Short
		
20: If lvwPiece.Visible = True Then
25: lvwSource = lvwPiece
30: Else
35: If lvwFournisseur.Visible = True Then
40: lvwSource = lvwFournisseur
45: Else
50: lvwSource = lvwCategorie
55: End If
60: End If
		
65: VerifierSiChecked = False
		
70: For iCompteur = 1 To lvwSource.Items.Count
75: 'UPGRADE_WARNING: Lower bound of collection lvwSource.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwSource.Items.Item(iCompteur).Checked = True Then
80: VerifierSiChecked = True
				
85: Exit For
90: End If
95: Next 
		
100: Exit Function
		
AfficherErreur: 
		
105: Call AfficherErreur("frmChoixDemande", "VerifierSiChecked", Err, Erl())
	End Function
	
	Private Sub EnregistrerDemandePrixNouvellesPieces()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstImpDP As ADODB.Recordset
15: Dim sNomTable As String
20: Dim iCompteur As Short
		
25: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
30: sNomTable = "GRB_ImpressionDemandePrixElec"
35: Else
40: sNomTable = "GRB_ImpressionDemandePrixMec"
45: End If
		
50: rstImpDP = New ADODB.Recordset
		
55: rstImpDP.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		
60: Call rstImpDP.Open("SELECT * FROM " & sNomTable, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
65: For iCompteur = 1 To m_collPiece.Count()
70: Call rstImpDP.AddNew()
			
75: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPiece(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rstImpDP.Fields("NoPiece").Value = m_collPiece.Item(iCompteur)
80: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collQuantite(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rstImpDP.Fields("Qte").Value = m_collQuantite.Item(iCompteur)
85: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collDescriptionFR(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rstImpDP.Fields("Description").Value = m_collDescriptionFR.Item(iCompteur)
90: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collManufacturier(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rstImpDP.Fields("Manufacturier").Value = m_collManufacturier.Item(iCompteur)
			
95: Call rstImpDP.Update()
100: Next 
		
105: Call rstImpDP.Requery()
		
110: For iCompteur = 15 To rstImpDP.RecordCount Step -1
115: Call rstImpDP.AddNew()
			
120: rstImpDP.Fields("NoPiece").Value = vbNullString
125: rstImpDP.Fields("Qte").Value = vbNullString
130: rstImpDP.Fields("Description").Value = vbNullString
135: rstImpDP.Fields("Manufacturier").Value = vbNullString
			
140: Call rstImpDP.Update()
145: Next 
		
150: Call rstImpDP.Close()
155: 'UPGRADE_NOTE: Object rstImpDP may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstImpDP = Nothing
		
160: Exit Sub
		
AfficherErreur: 
		
165: Call AfficherErreur("frmChoixDemande", "EnregistrerDemandePrixNouvellesPieces", Err, Erl())
	End Sub
	
	Private Sub EnregistrerDemandePrix(ByVal iIDFRS As Short)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstImpDP As ADODB.Recordset
15: Dim rstPieceFRS As ADODB.Recordset
20: Dim rstPiece As ADODB.Recordset
25: Dim sNomTable As String
30: Dim sWhere As String
35: Dim sCategorie As String
40: Dim iCompteur As Short
		
45: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
50: sNomTable = "GRB_ImpressionDemandePrixElec"
55: Else
60: sNomTable = "GRB_ImpressionDemandePrixMec"
65: End If
		
70: rstImpDP = New ADODB.Recordset
75: rstPiece = New ADODB.Recordset
80: rstPieceFRS = New ADODB.Recordset
		
85: rstImpDP.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		
90: Call rstImpDP.Open("SELECT * FROM " & sNomTable, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
95: If m_eDemande <> enumModeDemande.MODE_PIECE Then
100: Select Case m_eDemande
				Case enumModeDemande.MODE_FOURNISSEUR
105: Call rstPieceFRS.Open("SELECT * FROM GRB_PiecesFRS WHERE IDFRS = " & iIDFRS & " ORDER BY PIECE", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
110: Case enumModeDemande.MODE_CATEGORIE
115: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
120: sWhere = " AND GRB_CatalogueElec.CATEGORIE In ("
125: Else
130: sWhere = " AND GRB_CatalogueMec.CATEGORIE In ("
135: End If
					
140: For iCompteur = 1 To m_collCategorie.Count()
145: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collCategorie(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						sCategorie = Replace(m_collCategorie.Item(iCompteur), "'", "''")
						
150: If iCompteur <> m_collCategorie.Count() Then
155: sWhere = sWhere & "'" & sCategorie & "',"
160: Else
165: sWhere = sWhere & "'" & sCategorie & "')"
170: End If
175: Next 
					
180: Call rstPieceFRS.Open("SELECT GRB_PiecesFRS.* FROM GRB_PiecesFRS INNER JOIN GRB_CatalogueMec ON GRB_PiecesFRS.PIECE = GRB_CatalogueMec.PIECE WHERE GRB_PiecesFRS.IDFRS = " & iIDFRS & sWhere & " ORDER BY GRB_PiecesFRS.PIECE", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
185: End Select
			
190: Do While Not rstPieceFRS.EOF
195: If rstPieceFRS.Fields("Type").Value = "M" Then
200: Call rstPiece.Open("SELECT FABRICANT, DESC_FR, DESC_EN FROM GRB_CatalogueElec WHERE PIECE = '" & Replace(rstPieceFRS.Fields("PIECE").Value, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
205: Else
210: Call rstPiece.Open("SELECT FABRICANT, DESC_FR, DESC_EN FROM GRB_CatalogueMec WHERE PIECE = '" & Replace(rstPieceFRS.Fields("PIECE").Value, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
215: End If
				
220: If Not rstPiece.EOF Then
225: If m_collManufacturier.Count() > 0 Then
230: For iCompteur = 1 To m_collManufacturier.Count()
235: If m_collManufacturier.Item(iCompteur) = rstPiece.Fields("FABRICANT").Value Then
240: Call rstImpDP.AddNew()
								
245: rstImpDP.Fields("NoPiece").Value = rstPieceFRS.Fields("PIECE").Value
250: rstImpDP.Fields("Qte").Value = "1"
255: 
260: If m_sLangage = S_FRANCAIS Then
265: rstImpDP.Fields("Description").Value = rstPiece.Fields("DESC_FR").Value
270: Else
275: rstImpDP.Fields("Description").Value = rstPiece.Fields("DESC_EN").Value
280: End If
								
285: rstImpDP.Fields("Manufacturier").Value = rstPiece.Fields("FABRICANT").Value
								
290: Call rstImpDP.Update()
295: End If
300: Next 
305: Else
310: Call rstImpDP.AddNew()
						
315: rstImpDP.Fields("NoPiece").Value = rstPieceFRS.Fields("PIECE").Value
320: rstImpDP.Fields("Qte").Value = "1"
						
325: If m_sLangage = S_FRANCAIS Then
330: rstImpDP.Fields("Description").Value = rstPiece.Fields("DESC_FR").Value
335: Else
340: rstImpDP.Fields("Description").Value = rstPiece.Fields("DESC_EN").Value
345: End If
						
350: rstImpDP.Fields("Manufacturier").Value = rstPiece.Fields("FABRICANT").Value
						
355: Call rstImpDP.Update()
360: End If
365: Else
370: Call rstPieceFRS.Delete()
375: End If
				
380: Call rstPiece.Close()
				
385: Call rstPieceFRS.MoveNext()
390: Loop 
			
395: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstPiece = Nothing
			
400: Call rstPieceFRS.Close()
405: 'UPGRADE_NOTE: Object rstPieceFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstPieceFRS = Nothing
410: Else
415: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
420: Call rstPieceFRS.Open("SELECT GRB_PiecesFRS.PIECE FROM GRB_PiecesFRS INNER JOIN GRB_TempDP ON GRB_PiecesFRS.PIECE = GRB_TempDP.PIECE WHERE GRB_PiecesFRS.IDFRS = " & iIDFRS & " AND GRB_TempDP.TYPE = 'E' GROUP BY GRB_PiecesFRS.PIECE, ORDRE ORDER BY GRB_TempDP.ORDRE", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
425: Else
430: Call rstPieceFRS.Open("SELECT GRB_PiecesFRS.PIECE FROM GRB_PiecesFRS INNER JOIN GRB_TempDP ON GRB_PiecesFRS.PIECE = GRB_TempDP.PIECE WHERE GRB_PiecesFRS.IDFRS = " & iIDFRS & " AND GRB_TempDP.TYPE = 'M' GROUP BY GRB_PiecesFRS.PIECE, ORDRE ORDER BY GRB_TempDP.ORDRE", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
435: End If
			
440: Do While Not rstPieceFRS.EOF
445: For iCompteur = 1 To m_collPiece.Count()
450: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPiece(iCompteur). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If m_collPiece.Item(iCompteur) = Trim(rstPieceFRS.Fields("PIECE").Value) Then
455: Call rstImpDP.AddNew()
						
460: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPiece(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						rstImpDP.Fields("NoPiece").Value = m_collPiece.Item(iCompteur)
						
465: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collQuantite(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						rstImpDP.Fields("Qte").Value = m_collQuantite.Item(iCompteur)
						
470: If m_sLangage = S_FRANCAIS Then
475: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collDescriptionFR(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rstImpDP.Fields("Description").Value = m_collDescriptionFR.Item(iCompteur)
480: Else
485: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collDescriptionEN(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							rstImpDP.Fields("Description").Value = m_collDescriptionEN.Item(iCompteur)
490: End If
						
495: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collManufacturier(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						rstImpDP.Fields("Manufacturier").Value = m_collManufacturier.Item(iCompteur)
						
500: Call rstImpDP.Update()
						
505: Exit For
510: End If
515: Next 
				
520: Call rstPieceFRS.MoveNext()
525: Loop 
			
530: Call rstPieceFRS.Close()
535: 'UPGRADE_NOTE: Object rstPieceFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstPieceFRS = Nothing
540: End If
		
545: Call rstImpDP.Requery()
		
550: For iCompteur = 15 To (rstImpDP.RecordCount + 1) Step -1
555: Call rstImpDP.AddNew()
			
560: rstImpDP.Fields("NoPiece").Value = vbNullString
565: rstImpDP.Fields("Qte").Value = vbNullString
570: rstImpDP.Fields("Description").Value = vbNullString
575: rstImpDP.Fields("Manufacturier").Value = vbNullString
			
580: Call rstImpDP.Update()
585: Next 
		
590: Call rstImpDP.Close()
595: 'UPGRADE_NOTE: Object rstImpDP may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstImpDP = Nothing
		
600: Exit Sub
		
AfficherErreur: 
		
605: Call AfficherErreur("frmChoixDemande", "EnregistrerDemandePrix", Err, Erl())
	End Sub
	
	Private Sub ImprimerDemandePrix(ByVal iIDFRS As Short)
		Dim DR_DemandePrix As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstImpDP As ADODB.Recordset
15: Dim rstFRS As ADODB.Recordset
20: Dim sNomTable As String
		
25: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
30: sNomTable = "GRB_ImpressionDemandePrixElec"
35: Else
40: sNomTable = "GRB_ImpressionDemandePrixMec"
45: End If
		
50: rstFRS = New ADODB.Recordset
55: rstImpDP = New ADODB.Recordset
		
60: Call rstFRS.Open("SELECT * FROM GRB_Fournisseur WHERE IDFRS = " & iIDFRS, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
65: Call rstImpDP.Open("SELECT * FROM " & sNomTable, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
70: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_DemandePrix.DataSource = rstImpDP
		
		'Entête
		'Vérifie si c'est Anglais ou Francais
		'On modifie seulement si c'est Anglais
75: If m_sLangage = S_ANGLAIS Then
80: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitreDemande").Caption = "Price and Delivery Request"
85: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitreFournisseur").Caption = "Supplier :"
90: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitreContact").Caption = "Contact :"
95: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitreTransport").Caption = "Transport :"
100: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitreDateReq").Caption = "Required Date :"
105: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitreNoSoum").Caption = "Your Ref # :"
110: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitreTel").Caption = "Telephone :"
115: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitreFax").Caption = "Fax :"
120: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitreNoGRB").Caption = "OUR # :"
125: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitreDate").Caption = "Date :"
130: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitreComPar").Caption = "Purchaser :"
135: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitrePage").Caption = "Page :"
140: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitreQte").Caption = "Qty"
145: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitrePiece").Caption = "Part Number"
150: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitreDescription").Caption = "Description"
155: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitreManufact").Caption = "Manufacturer"
160: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitrePrix").Caption = "Unit Price"
165: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTitreDelais").Caption = "Delay"
170: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section3").Controls("lblTitreCommentaire").Caption = "Comments :"
175: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section3").Controls("lblPrixValide").Caption = "Valid price for"
180: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section3").Controls("lblJours").Caption = "Days"
185: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section3").Controls("lblPiedPage").Caption = "THIS IS NOT AN ORDER"
			
190: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("imgLogoFrancais").Visible = False
195: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("imgLogoAnglais").Visible = True
200: End If
		
205: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_DemandePrix.Sections("Section2").Controls("lblFournisseur").Caption = rstFRS.Fields("NomFournisseur").Value
210: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_DemandePrix.Sections("Section2").Controls("lblContact").Caption = m_sContact
		
215: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstFRS.Fields("CondTransport").Value) Then
220: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTransport").Caption = rstFRS.Fields("CondTransport").Value
225: Else
230: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_DemandePrix.Sections("Section2").Controls("lblTransport").Caption = ""
235: End If
		
240: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_DemandePrix.Sections("Section2").Controls("lblDateRequise").Caption = mskDateRequise.Text
245: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_DemandePrix.Sections("Section2").Controls("lblTel").Caption = rstFRS.Fields("Telephonne").Value
250: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_DemandePrix.Sections("Section2").Controls("lblFax").Caption = rstFRS.Fields("Fax").Value
255: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_DemandePrix.Sections("Section2").Controls("lblNoGRB").Caption = txtNoGRB.Text
260: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_DemandePrix.Sections("Section2").Controls("lblDate").Caption = ConvertDate(Today)
265: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_DemandePrix.Sections("Section2").Controls("lblCommandePar").Caption = g_sEmploye
270: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_DemandePrix.Sections("Section3").Controls("lblCommentaire").Caption = txtcommentaire.Text
		
275: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Orientation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_DemandePrix.Orientation = MSDataReportLib.OrientationConstants.rptOrientLandscape
		
280: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_DemandePrix.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_DemandePrix.Show(VB6.FormShowConstants.Modal)
		
285: Call g_connData.Execute("DELETE * FROM " & sNomTable)
		
290: Call rstImpDP.Close()
295: 'UPGRADE_NOTE: Object rstImpDP may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstImpDP = Nothing
		
300: Call rstFRS.Close()
305: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
		
310: Exit Sub
		
AfficherErreur: 
		
315: Call AfficherErreur("frmChoixDemande", "ImprimerDemandePrix", Err, Erl())
	End Sub
	
	Private Sub mskDateRequise_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateRequise.Enter
		
5: On Error GoTo AfficherErreur
		
10: If Len(mskDateRequise.Text) = 10 Then
15: mskDateRequise.Text = VB.Right(mskDateRequise.Text, 8)
20: End If
		
25: mskDateRequise.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixDemande", "mskDateRequise_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateRequise_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateRequise.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskDateRequise.Mask = vbNullString
		
15: If mskDateRequise.Text = "__-__-__" Then
20: mskDateRequise.Text = vbNullString
25: Else
30: If Len(mskDateRequise.Text) = 8 Then
35: If IsDate(mskDateRequise.Text) Then
40: mskDateRequise.Text = Year(DateSerial(CInt(VB.Left(mskDateRequise.Text, 2)), CInt(Mid(mskDateRequise.Text, 4, 2)), CInt(VB.Right(mskDateRequise.Text, 2)))) & Mid(mskDateRequise.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmChoixDemande", "mskDateRequise_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtRechercher.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtRechercher_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtRechercher.TextChanged
		
5: On Error GoTo AfficherErreur
		
10: cmdRechercher.Text = "Rechercher"
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDemande", "txtRechercher_Change", Err, Erl())
	End Sub
End Class