Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmAchat
	Inherits System.Windows.Forms.Form
	
	'Index des colonnes de lvwAchat
	Private Const I_COL_ACHAT_QUANTITE As Short = 0
	Private Const I_COL_ACHAT_PIECE As Short = 1
	Private Const I_COL_ACHAT_DESCR As Short = 2
	Private Const I_COL_ACHAT_MANUFACT As Short = 3
	Private Const I_COL_ACHAT_PRIX_LIST As Short = 4
	Private Const I_COL_ACHAT_ESCOMPTE As Short = 5
	Private Const I_COL_ACHAT_PRIX_NET As Short = 6
	Private Const I_COL_ACHAT_DISTRIB As Short = 7
	Private Const I_COL_ACHAT_TOTAL As Short = 8
	Private Const I_COL_ACHAT_DATE_COMMANDE As Short = 9
	Private Const I_COL_ACHAT_DATE_REQUISE As Short = 10
	
	'Index des colonnes de lvwPieces
	Private Const I_COL_PIECES_PIECE_GRB As Short = 0
	Private Const I_COL_PIECES_NO_ITEM As Short = 1
	Private Const I_COL_PIECES_MANUFACT As Short = 2
	Private Const I_COL_PIECES_DESCR_FR As Short = 3
	Private Const I_COL_PIECES_DESCR_EN As Short = 4
	Private Const I_COL_PIECES_COMMENT As Short = 5
	
	'Index des colonnes de lvwPieceTrouve
	Private Const I_COL_RECH_PIECE_GRB As Short = 0
	Private Const I_COL_RECH_NO_ITEM As Short = 1
	Private Const I_COL_RECH_CATEGORIE As Short = 2
	Private Const I_COL_RECH_MANUFACT As Short = 3
	Private Const I_COL_RECH_DESCR_FR As Short = 4
	Private Const I_COL_RECH_DESCR_EN As Short = 5
	
	'Index des colonnes de lvwInventaire
	Private Const I_COL_INV_NO_ITEM As Short = 0
	Private Const I_COL_INV_MANUFACT As Short = 1
	Private Const I_COL_INV_DESCR As Short = 2
	Private Const I_COL_INV_COMMENT As Short = 3
	Private Const I_COL_INV_QTE_STOCK As Short = 4
	Private Const I_COL_INV_QTE_MINIMUM As Short = 5
	Private Const I_COL_INV_QTE_COMMANDE As Short = 6
	
	'Index des colonnes de lvwFournisseur
	Private Const I_COL_FRS_FRS As Short = 0
	Private Const I_COL_FRS_PERS_RESS As Short = 1
	Private Const I_COL_FRS_DATE As Short = 2
	Private Const I_COL_FRS_ENTRER_PAR As Short = 3
	Private Const I_COL_FRS_VALIDE As Short = 4
	Private Const I_COL_FRS_PRIX_LIST As Short = 5
	Private Const I_COL_FRS_ESCOMPTE As Short = 6
	Private Const I_COL_FRS_PRIX_NET As Short = 7
	Private Const I_COL_FRS_PRIX_SP As Short = 8
	Private Const I_COL_FRS_QUOTER As Short = 9
	
	'Index de cmbTri
	Private Const I_CMB_PIECE_GRB As Short = 0
	Private Const I_CMB_PIECE As Short = 1
	Private Const I_CMB_FABRICANT As Short = 2
	Private Const I_CMB_DESCR_FR As Short = 3
	Private Const I_CMB_DESCR_EN As Short = 4
	
	'Valeur servant au grandeur du lvwSoumission si en mode modif ou inactif
	Private Const I_TOP_AJOUT_MODIF As Short = 4320
	Private Const I_HEIGHT_AJOUT_MODIF As Short = 2535
	Private Const I_TOP_INACTIF As Short = 1680
	Private Const I_HEIGHT_INACTIF As Short = 5175
	
	'Width de cmbCategorie
	Private Const I_WIDTH_CATEGORIE_ELEC As Short = 1695
	Private Const I_WIDTH_CATEGORIE_MEC As Short = 5175
	
	'Énumération servant à savoir si le form est en mode modif/ajout ou en mode
	'inactif (affichage seulement)
	Private Enum enumMode
		MODE_AJOUT_MODIF = 0
		MODE_INACTIF = 1
	End Enum
	
	'Pour la recherche de pièce dans lvwPieces
	Private m_sTri As String
	
	'Pour savoir quelle colonne trier
	Private m_iCol As Short
	
	'Modes du form
	Private m_bModeAjout As Boolean
	Private m_bModeAffichage As Boolean
	
	'Pour pouvoir afficher le dernier achat visualisé
	Private m_sAncienAchat As String
	
	Public m_sNoAchat As String
	
	Public m_bAnnuler As Boolean
	
	Private m_eMode As enumMode
	
	Private m_eCatalogue As ModuleMain.enumCatalogue
	
	Private m_bInventaire As Boolean
	
	Private m_sQuantite As String
	
	Private m_bRecherchePiece As Boolean
	
	Private m_bPieceInutile As Boolean
	
	'Pour savoir si le changement de prix a été appelé à partir
	'du bouton "Mauvais Prix"
	Private m_bMauvaisPrix As Boolean
	
	Private m_bMonthViewHasFocus As Boolean
	
	Private Sub AnnulerCommande()
		
5: On Error GoTo AfficherErreur
		
10: Dim itmAvant As System.Windows.Forms.ListViewItem
15: Dim itmAnnulation As System.Windows.Forms.ListViewItem
		
20: itmAvant = lvwAchat.FocusedItem
25: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation = lvwAchat.Items.Insert(itmAvant.Index + 1, "")
		
30: itmAnnulation.Checked = itmAvant.Checked
		
		'Quantité
35: itmAnnulation.Text = "-" & itmAvant.Text
		
		'On met l'id de la section dans le tag du listItem
40: itmAnnulation.Tag = itmAvant.Tag
		
		'No d'item
45: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmAnnulation.SubItems.Count > I_COL_ACHAT_PIECE Then
			itmAnnulation.SubItems(I_COL_ACHAT_PIECE).Text = itmAvant.SubItems(I_COL_ACHAT_PIECE).Text
		Else
			itmAnnulation.SubItems.Insert(I_COL_ACHAT_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_PIECE).Text))
		End If
		
		'On met le nom de la sous-section dans le tag du no d'item
50: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_PIECE).Tag = itmAvant.SubItems.Item(I_COL_ACHAT_PIECE).Tag
		
		'On met la description en francais dans la colonne et la description en anglais
		'dans le tag
55: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmAnnulation.SubItems.Count > I_COL_ACHAT_DESCR Then
			itmAnnulation.SubItems(I_COL_ACHAT_DESCR).Text = itmAvant.SubItems(I_COL_ACHAT_DESCR).Text
		Else
			itmAnnulation.SubItems.Insert(I_COL_ACHAT_DESCR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_DESCR).Text))
		End If
60: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_DESCR).Tag = itmAvant.SubItems.Item(I_COL_ACHAT_DESCR).Tag
		
		'On met le nom du fabricant dans la col-nne et l'ordre de la section dans le tag
65: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmAnnulation.SubItems.Count > I_COL_ACHAT_MANUFACT Then
			itmAnnulation.SubItems(I_COL_ACHAT_MANUFACT).Text = itmAvant.SubItems(I_COL_ACHAT_MANUFACT).Text
		Else
			itmAnnulation.SubItems.Insert(I_COL_ACHAT_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_MANUFACT).Text))
		End If
70: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_MANUFACT).Tag = itmAvant.SubItems.Item(I_COL_ACHAT_MANUFACT).Tag
		
		'Prix listé
75: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmAnnulation.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
			itmAnnulation.SubItems(I_COL_ACHAT_PRIX_LIST).Text = itmAvant.SubItems(I_COL_ACHAT_PRIX_LIST).Text
		Else
			itmAnnulation.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_PRIX_LIST).Text))
		End If
		
80: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Tag = itmAvant.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Tag
		
85: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmAnnulation.SubItems.Count > I_COL_ACHAT_ESCOMPTE Then
			itmAnnulation.SubItems(I_COL_ACHAT_ESCOMPTE).Text = itmAvant.SubItems(I_COL_ACHAT_ESCOMPTE).Text
		Else
			itmAnnulation.SubItems.Insert(I_COL_ACHAT_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_ESCOMPTE).Text))
		End If
		
90: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmAnnulation.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
			itmAnnulation.SubItems(I_COL_ACHAT_PRIX_NET).Text = itmAvant.SubItems(I_COL_ACHAT_PRIX_NET).Text
		Else
			itmAnnulation.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_PRIX_NET).Text))
		End If
		
		'On met le fournisseur dans la colonne et l'id dans le tag
95: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmAnnulation.SubItems.Count > I_COL_ACHAT_DISTRIB Then
			itmAnnulation.SubItems(I_COL_ACHAT_DISTRIB).Text = itmAvant.SubItems(I_COL_ACHAT_DISTRIB).Text
		Else
			itmAnnulation.SubItems.Insert(I_COL_ACHAT_DISTRIB, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_DISTRIB).Text))
		End If
100: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_DISTRIB).Tag = itmAvant.SubItems.Item(I_COL_ACHAT_DISTRIB).Tag
		
		'Pour le prix total, il faut faire la quantité * prix net * pourcentage de profit
105: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmAnnulation.SubItems.Count > I_COL_ACHAT_TOTAL Then
			itmAnnulation.SubItems(I_COL_ACHAT_TOTAL).Text = "-" & itmAvant.SubItems(I_COL_ACHAT_TOTAL).Text
		Else
			itmAnnulation.SubItems.Insert(I_COL_ACHAT_TOTAL, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "-" & itmAvant.SubItems(I_COL_ACHAT_TOTAL).Text))
		End If
		
110: itmAnnulation.ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_VERT_FORET)
115: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_PIECE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_VERT_FORET)
120: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_DESCR).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_VERT_FORET)
125: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_DISTRIB).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_VERT_FORET)
130: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_ESCOMPTE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_VERT_FORET)
135: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_MANUFACT).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_VERT_FORET)
140: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_PRIX_LIST).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_VERT_FORET)
145: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_PRIX_NET).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_VERT_FORET)
150: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_TOTAL).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_VERT_FORET)
		
155: itmAnnulation.Font = VB6.FontChangeBold(itmAnnulation.Font, True)
160: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_PIECE).Font = VB6.FontChangeBold(itmAnnulation.SubItems.Item(I_COL_ACHAT_PIECE).Font, True)
165: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_DESCR).Font = VB6.FontChangeBold(itmAnnulation.SubItems.Item(I_COL_ACHAT_DESCR).Font, True)
170: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_DISTRIB).Font = VB6.FontChangeBold(itmAnnulation.SubItems.Item(I_COL_ACHAT_DISTRIB).Font, True)
175: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_ESCOMPTE).Font = VB6.FontChangeBold(itmAnnulation.SubItems.Item(I_COL_ACHAT_ESCOMPTE).Font, True)
180: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_MANUFACT).Font = VB6.FontChangeBold(itmAnnulation.SubItems.Item(I_COL_ACHAT_MANUFACT).Font, True)
185: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Font = VB6.FontChangeBold(itmAnnulation.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Font, True)
190: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_PRIX_NET).Font = VB6.FontChangeBold(itmAnnulation.SubItems.Item(I_COL_ACHAT_PRIX_NET).Font, True)
195: 'UPGRADE_WARNING: Lower bound of collection itmAnnulation.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAnnulation.SubItems.Item(I_COL_ACHAT_TOTAL).Font = VB6.FontChangeBold(itmAnnulation.SubItems.Item(I_COL_ACHAT_TOTAL).Font, True)
		
200: itmAvant.ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
205: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAvant.SubItems.Item(I_COL_ACHAT_PIECE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
210: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAvant.SubItems.Item(I_COL_ACHAT_DESCR).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
215: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAvant.SubItems.Item(I_COL_ACHAT_DISTRIB).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
220: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAvant.SubItems.Item(I_COL_ACHAT_ESCOMPTE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
225: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAvant.SubItems.Item(I_COL_ACHAT_MANUFACT).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
230: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAvant.SubItems.Item(I_COL_ACHAT_PRIX_LIST).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
235: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAvant.SubItems.Item(I_COL_ACHAT_PRIX_NET).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
240: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAvant.SubItems.Item(I_COL_ACHAT_TOTAL).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
245: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAvant.SubItems.Item(I_COL_ACHAT_DATE_COMMANDE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
250: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAvant.SubItems.Item(I_COL_ACHAT_DATE_REQUISE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
		
255: Call lvwAchat.Refresh()
		
260: Call CalculerPrix()
		
265: Exit Sub
		
AfficherErreur: 
		
270: Call AfficherErreur("frmAchat", "AnnulerCommande", Err, Erl())
	End Sub
	
	Public Sub Afficher(ByVal eCatalogue As ModuleMain.enumCatalogue)
		
5: On Error GoTo AfficherErreur
		
10: Call frmChoixProjSoum.Close()
		
15: m_eCatalogue = eCatalogue
		
20: Select Case eCatalogue
			'Si c'est électrique
			Case ModuleMain.enumCatalogue.ELECTRIQUE
25: Me.Text = "Achat électrique"
30: cmbCategorie.Width = VB6.TwipsToPixelsX(I_WIDTH_CATEGORIE_ELEC)
				
			Case ModuleMain.enumCatalogue.MECANIQUE
35: Me.Text = "Achat mécanique"
40: cmbCategorie.Width = VB6.TwipsToPixelsX(I_WIDTH_CATEGORIE_MEC)
45: End Select
		
		'Initialise le tri à PIECE_GRB
50: cmbTri.SelectedIndex = I_CMB_PIECE
		
55: Call RemplirComboAchat(vbNullString)
		
		'Rempli le combo des catégories de pièce
60: Call RemplirComboCategorie()
		
65: Call AfficherControles(enumMode.MODE_INACTIF)
		
70: Call Me.Show()
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmAchat", "Afficher", Err, Erl())
	End Sub
	
	Private Sub AfficherControles(ByVal eMode As enumMode)
		
5: On Error GoTo AfficherErreur
		
		'Affichage des boutons selon si c'est un ajout/modif ou un affichage
10: Dim bAjouter As Boolean
15: Dim bModifier As Boolean
20: Dim bSupprimer As Boolean
25: Dim bEnregistrer As Boolean
30: Dim bAnnuler As Boolean
35: Dim bFermer As Boolean
40: Dim bImprimer As Boolean
45: Dim bBonCommande As Boolean
50: Dim bTri As Boolean
55: Dim bCmbAchat As Boolean
60: Dim bDemandePrix As Boolean
65: Dim bRetour As Boolean
70: Dim bInventaire As Boolean
75: Dim bInutile As Boolean
80: Dim bPrix As Boolean
85: Dim bPieces As Boolean
90: Dim bReception As Boolean
		
95: m_eMode = eMode
		
100: Select Case eMode
			Case enumMode.MODE_AJOUT_MODIF
105: bEnregistrer = True
110: bAnnuler = True
115: bPieces = True
120: bTri = True
125: bInventaire = True
130: bPrix = True
135: bInutile = True
				
			Case enumMode.MODE_INACTIF
140: bModifier = True
145: bFermer = True
150: bImprimer = True
155: bAjouter = True
160: bBonCommande = True
165: bSupprimer = True
170: bCmbAchat = True
175: bDemandePrix = True
180: bRetour = True
185: bReception = True
190: End Select
		
195: cmbNoAchat.Visible = bCmbAchat
200: txtNoAchat.Visible = Not bCmbAchat
		
205: Cmdajouter.Visible = bAjouter
210: cmdModifier.Visible = bModifier
215: cmdsupprimer.Visible = bSupprimer
220: cmdEnregistrer.Visible = bEnregistrer
225: cmdAnnuler.Visible = bAnnuler
230: Cmdfermer.Visible = bFermer
235: cmdImprimer.Visible = bImprimer
240: cmdBonCommande.Visible = bBonCommande
245: cmdDemande.Visible = bDemandePrix
250: cmdRetour.Visible = bRetour
255: cmdInventaire.Visible = bInventaire
260: cmdReception.Visible = bReception
265: lblCategorie.Visible = bPieces
270: cmbCategorie.Visible = bPieces
275: lvwPieces.Visible = bPieces
		
280: lblTri.Visible = bTri
285: cmbTri.Visible = bTri
290: cmdTri.Visible = bTri
295: cmdRafraichir.Visible = bTri
		
		'Exception puisqu'il y en a qu'un seul
300: If m_eMode = enumMode.MODE_AJOUT_MODIF Then
305: txtRaison.ReadOnly = False
310: Else
315: txtRaison.ReadOnly = True
320: End If
		
325: If m_eMode = enumMode.MODE_AJOUT_MODIF Then
330: lvwAchat.Top = VB6.TwipsToPixelsY(I_TOP_AJOUT_MODIF)
335: lvwAchat.Height = VB6.TwipsToPixelsY(I_HEIGHT_AJOUT_MODIF)
340: Else
345: lvwAchat.Top = VB6.TwipsToPixelsY(I_TOP_INACTIF)
350: lvwAchat.Height = VB6.TwipsToPixelsY(I_HEIGHT_INACTIF)
355: End If
		
360: Exit Sub
		
AfficherErreur: 
		
365: Call AfficherErreur("frmAchat", "AfficherControles", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbCategorie.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbCategorie_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbCategorie.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		'Rempli lvwPieces selon la catégorie de pièce choisie
10: Call RemplirListViewPieces()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmAchat", "cmbCategorie_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbNoAchat.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbNoAchat_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbNoAchat.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: Dim sNomClient As String
15: Dim sNomContact As String
20: Dim iCompteur As Short
25: Dim rstAchat As ADODB.Recordset
30: Dim sIDAchat As String
35: Dim iIndexAchat As Short
		
40: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
45: txtNoAchat.Text = cmbNoAchat.Text
		
		'Rempli les valeurs de l'achat sélectionné
50: Call RemplirAchat()
		
55: sIDAchat = Trim(VB.Left(txtNoAchat.Text, InStr(1, txtNoAchat.Text, "-") + 2))
60: iIndexAchat = CShort(Trim(VB.Right(txtNoAchat.Text, Len(txtNoAchat.Text) - InStrRev(txtNoAchat.Text, "-"))))
		
65: rstAchat = New ADODB.Recordset
		
70: Call rstAchat.Open("SELECT Modification, Par FROM GRB_Achat WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
75: If rstAchat.Fields("Modification").Value = True And rstAchat.Fields("Par").Value = g_sEmploye Then
80: cmdReset.Visible = True
85: Else
90: cmdReset.Visible = False
95: End If
		
100: Call rstAchat.Close()
105: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAchat = Nothing
		
110: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
115: Exit Sub
		
AfficherErreur: 
		
120: Call AfficherErreur("frmAchat", "cmbNoAchat_Click", Err, Erl())
	End Sub
	
	Private Sub RemplirAchat()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstAchat As ADODB.Recordset
15: Dim rstEmploye As ADODB.Recordset
20: Dim sNoAchat As String
25: Dim iIndexAchat As Short
		
30: sNoAchat = VB.Left(txtNoAchat.Text, 9)
		
35: iIndexAchat = CShort(VB.Right(txtNoAchat.Text, 3))
		
40: rstAchat = New ADODB.Recordset
45: rstEmploye = New ADODB.Recordset
		
50: Call rstAchat.Open("SELECT * FROM GRB_Achat WHERE IDAchat = '" & sNoAchat & "' AND IndexAchat = " & iIndexAchat, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
55: Call rstEmploye.Open("SELECT Employe FROM GRB_Employés WHERE noEmploye = " & rstAchat.Fields("Acheteur").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
60: txtAcheteur.Text = rstEmploye.Fields("employe").Value
65: txtAcheteur.Tag = rstAchat.Fields("Acheteur").Value
		
70: Call rstEmploye.Close()
75: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstEmploye = Nothing
		
80: txtRaison.Text = rstAchat.Fields("Raison").Value
85: txtDate.Text = rstAchat.Fields("DateAchat").Value
		
90: txtPrixTotal.Text = Conversion_Renamed(rstAchat.Fields("PrixTotal"), ModuleMain.enumConvert.MODE_ARGENT)
		
95: Call rstAchat.Close()
100: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAchat = Nothing
		
105: Call RemplirListViewAchat()
		
110: Exit Sub
		
AfficherErreur: 
		
115: Call AfficherErreur("frmAchat", "RemplirAchat", Err, Erl())
	End Sub
	
	Private Sub cmbNoAchat_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles cmbNoAchat.KeyUp
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: For iCompteur = 0 To cmbNoAchat.Items.Count - 1
20: If UCase(VB6.GetItemString(cmbNoAchat, iCompteur)) = UCase(cmbNoAchat.Text) Then
25: cmbNoAchat.SelectedIndex = iCompteur
				
30: Exit For
35: End If
40: Next 
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmAchat", "cmbNoAchat_KeyUp", Err, Erl())
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim sChamps As String
15: Dim sTable As String
20: Dim sTablePiece As String
		
25: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'Initialisation des variables booléennes
30: m_bInventaire = False
35: m_bMauvaisPrix = False
40: m_bPieceInutile = False
45: m_bRecherchePiece = False
		
		'Remet en mode inactif
50: Call AfficherControles(enumMode.MODE_INACTIF)
		
55: Call OuvrirAchat(False)
		
60: Call RemplirComboAchat(m_sAncienAchat)
		
65: m_bModeAjout = False
		
70: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmAchat", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnulerDateRequise_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnulerDateRequise.Click
		
5: On Error GoTo AfficherErreur
		
10: fraDateRequise.Visible = False
		
15: m_bMonthViewHasFocus = False
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmAchat", "cmdAnnulerDateRequise_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnulerDateRequise_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdAnnulerDateRequise.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdAnnulerDateRequise_Click(cmdAnnulerDateRequise, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmAchat", "cmdAnnulerDateRequise_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdAnnulerInventaire_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnulerInventaire.Click
		
5: On Error GoTo AfficherErreur
		
10: fraInventaire.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmAchat", "cmdAnnulerInventaire_Click", Err, Erl())
	End Sub
	
	Private Sub cmdBonCommande_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBonCommande.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstAchat As ADODB.Recordset
		
15: rstAchat = New ADODB.Recordset
		
20: Call rstAchat.Open("SELECT Modification, Par FROM GRB_Achat WHERE IDAchat = '" & VB.Left(txtNoAchat.Text, 9) & "' AND IndexAchat = " & CShort(VB.Right(txtNoAchat.Text, 3)), g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: If rstAchat.Fields("Modification").Value = False Then
30: If lvwAchat.Items.Count > 0 Then
35: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
40: Call frmChoixBonCommande.AfficherAchat(VB.Left(txtNoAchat.Text, 9), CShort(VB.Right(txtNoAchat.Text, 3)), ModuleMain.enumCatalogue.ELECTRIQUE)
45: Else
50: Call frmChoixBonCommande.AfficherAchat(VB.Left(txtNoAchat.Text, 9), CShort(VB.Right(txtNoAchat.Text, 3)), ModuleMain.enumCatalogue.MECANIQUE)
55: End If
60: Else
65: Call MsgBox("Il n'y a pas de pièces à commander pour cet achat!", MsgBoxStyle.OKOnly, "Erreur")
70: End If
75: Else
80: Call MsgBox("Ce projet est en modification par " & rstAchat.Fields("Par").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
85: End If
		
90: Call rstAchat.Close()
95: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAchat = Nothing
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmAchat", "cmdBonCommande_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDemande_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDemande.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstAchat As ADODB.Recordset
15: Dim sIDAchat As String
20: Dim iIndexAchat As Short
		
25: sIDAchat = Trim(VB.Left(txtNoAchat.Text, InStr(1, txtNoAchat.Text, "-") + 2))
30: iIndexAchat = CShort(Trim(VB.Right(txtNoAchat.Text, Len(txtNoAchat.Text) - InStrRev(txtNoAchat.Text, "-"))))
		
35: rstAchat = New ADODB.Recordset
		
40: Call rstAchat.Open("SELECT Modification, Par FROM GRB_Achat WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
45: If rstAchat.Fields("Modification").Value = False Then
50: Call frmChoixDemande.AfficherAchat(txtNoAchat.Text, m_eCatalogue, frmChoixDemande.enumModeDemande.MODE_PIECE)
55: Else
60: Call MsgBox("Cet achat est en modification par " & rstAchat.Fields("Par").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
65: End If
		
70: Call rstAchat.Close()
75: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAchat = Nothing
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmAchat", "cmdDemande_Click", Err, Erl())
	End Sub
	
	Private Sub cmdImprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImprimer.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstAchat As ADODB.Recordset
15: Dim sIDAchat As String
20: Dim iIndexAchat As Short
		
25: sIDAchat = Trim(VB.Left(txtNoAchat.Text, InStr(1, txtNoAchat.Text, "-") + 2))
30: iIndexAchat = CShort(Trim(VB.Right(txtNoAchat.Text, Len(txtNoAchat.Text) - InStrRev(txtNoAchat.Text, "-"))))
		
35: rstAchat = New ADODB.Recordset
		
40: Call rstAchat.Open("SELECT Modification, Par FROM GRB_Achat WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
45: If rstAchat.Fields("Modification").Value = False Then
50: Call frmChoixImpressionAchat.Afficher(m_eCatalogue)
55: Else
60: Call MsgBox("Cet achat est en modification par " & rstAchat.Fields("Par").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
65: End If
		
70: Call rstAchat.Close()
75: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAchat = Nothing
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmAchat", "cmdImprimer_Click", Err, Erl())
	End Sub
	
	Private Sub cmdInventaire_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdInventaire.Click
		
5: On Error GoTo AfficherErreur
		
10: Call RemplirListViewInventaire()
		
15: fraInventaire.Visible = True
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmAchat", "cmdInventaire_Click", Err, Erl())
	End Sub
	
	Private Sub cmdOKDateRequise_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOKDateRequise.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If lvwAchat.FocusedItem.SubItems.Count > I_COL_ACHAT_DATE_REQUISE Then
			lvwAchat.FocusedItem.SubItems(I_COL_ACHAT_DATE_REQUISE).Text = ConvertDate(mvwDateRequise.Value)
		Else
			lvwAchat.FocusedItem.SubItems.Insert(I_COL_ACHAT_DATE_REQUISE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ConvertDate(mvwDateRequise.Value)))
		End If
		
15: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		lvwAchat.FocusedItem.SubItems.Item(I_COL_ACHAT_DATE_REQUISE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_ORANGE)
		
20: fraDateRequise.Visible = False
		
25: m_bMonthViewHasFocus = False
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmAchat", "cmdOKDateRequise_Click", Err, Erl())
	End Sub
	
	Private Sub cmdOKDateRequise_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdOKDateRequise.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: If m_bMonthViewHasFocus = True Then
15: Call cmdOKDateRequise_Click(cmdOKDateRequise, New System.EventArgs())
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmAchat", "cmdOKDateRequise_MouseUp", Err, Erl())
	End Sub
	
	Private Sub cmdOKInventaire_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOKInventaire.Click
		
5: On Error GoTo AfficherErreur
		
		'On affiche lvwFournisseur selon la pièce choisie
		'Rempli les fournisseurs de la pièce choisie
10: m_bInventaire = True
15: m_bRecherchePiece = False
		
20: Call AfficherListeFournisseurs()
		
		'Si le listview n'est pas vide
25: If lvwfournisseur.Items.Count = 1 Then
30: If MsgBox("Il n'y a aucun fournisseur pour cette pièce!" & vbNewLine & "Voulez-vous en ajouter?", MsgBoxStyle.YesNo, "Erreur") = MsgBoxResult.Yes Then
35: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
				'On ouvre le catalogue sur cet enregistrement
40: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
45: 'UPGRADE_WARNING: Lower bound of collection lvwInventaire.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call FrmCatalogueElec.AfficherForm(cmbCategorie.Text, lvwInventaire.FocusedItem.SubItems(I_COL_INV_MANUFACT).Text, lvwInventaire.FocusedItem.Text)
50: Else
55: 'UPGRADE_WARNING: Lower bound of collection lvwInventaire.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call FrmCatalogueMec.AfficherForm(cmbCategorie.Text, lvwInventaire.FocusedItem.SubItems(I_COL_INV_MANUFACT).Text, lvwInventaire.FocusedItem.Text)
60: End If
				
65: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
				
				'On rappelle la méthode
70: Call AfficherListeFournisseurs()
75: End If
80: End If
		
85: fraInventaire.Visible = False
		
90: Exit Sub
		
AfficherErreur: 
		
95: Call AfficherErreur("frmAchat", "cmdOKInventaire_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRafraichir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRafraichir.Click
		
5: On Error GoTo AfficherErreur
		
10: If m_sTri <> vbNullString Then
15: m_sTri = vbNullString
			
20: Call RemplirListViewPieces()
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmAchat", "cmdRafraichir_Click", Err, Erl())
	End Sub
	
	Private Sub cmdReset_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdReset.Click
		'Permet d'effacer le champs Modification et Par si c'est le user actuel
5: On Error GoTo AfficherErreur
		
10: Dim rstAchat As ADODB.Recordset
15: Dim sIDAchat As String
20: Dim iIndexAchat As Short
		
25: If MsgBox("Êtes-vous certains de ne pas être en modification sur un autre ordinateur?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
30: sIDAchat = Trim(VB.Left(txtNoAchat.Text, InStr(1, txtNoAchat.Text, "-") + 2))
35: iIndexAchat = CShort(Trim(VB.Right(txtNoAchat.Text, Len(txtNoAchat.Text) - InStrRev(txtNoAchat.Text, "-"))))
			
40: rstAchat = New ADODB.Recordset
			
45: Call rstAchat.Open("SELECT Modification, Par FROM GRB_Achat WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
50: rstAchat.Fields("Modification").Value = False
55: rstAchat.Fields("Par").Value = ""
			
60: Call rstAchat.Update()
			
65: Call rstAchat.Close()
70: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstAchat = Nothing
			
75: cmdReset.Visible = False
80: End If
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("frmAchat", "cmdReset_Click", Err, Erl())
	End Sub
	
	Private Sub cmdTri_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTri.Click
		
5: On Error GoTo AfficherErreur
		
10: m_sTri = InputBox("Quel est le texte à trier?")
		
15: m_iCol = cmbTri.SelectedIndex
		
20: If m_sTri <> vbNullString Then
25: Call RemplirListViewPieces()
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmAchat", "cmdTri_Click", Err, Erl())
	End Sub
	
	Private Sub lvwAchat_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwAchat.DoubleClick
		
5: On Error GoTo AfficherErreur
		
		'Si en mode ajout ou modif
10: If m_eMode = enumMode.MODE_AJOUT_MODIF Then
			'Si la liste n'est pas vide
15: If lvwAchat.Items.Count > 0 Then
				'Si la pièce n'a pas de fournisseur
20: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If Trim(lvwAchat.FocusedItem.SubItems(I_COL_ACHAT_DISTRIB).Text) = vbNullString Then
25: Call ViderChamps_frs()
					
30: 'UPGRADE_ISSUE: ComboBox property cmbfrs.Locked was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					cmbfrs.Locked = False
					
35: m_bMauvaisPrix = False
					
					'Rempli le combo des fournisseurs
40: Call RemplirComboFournisseur()
					
					'Montre le frame
45: fraPrixPiece.Visible = True
					
					'Met le numéro de la pièce dans le tag
50: fraPrixPiece.Tag = lvwAchat.FocusedItem.Index
					
					'Donne le focus au combo
55: Call cmbfrs.Focus()
60: Else
65: 'Si le listItem est orange
70: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If System.Drawing.ColorTranslator.ToOle(lvwAchat.FocusedItem.SubItems.Item(I_COL_ACHAT_PIECE).ForeColor) = COLOR_ORANGE Then
75: If MsgBox("Voulez-vous annuler cette commande?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
80: Call AnnulerCommande()
85: End If
90: End If
95: End If
100: End If
105: End If
		
110: Exit Sub
		
AfficherErreur: 
		
115: Call AfficherErreur("frmAchat", "lvwAchat_DblClick", Err, Erl())
	End Sub
	
	Private Sub lvwAchat_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles lvwAchat.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
5: On Error GoTo AfficherErreur
		
10: Dim iNbreSelected As Short
15: Dim iIndexSelected As Short
20: Dim iCompteur As Short
25: Dim bAfficherMenu As Boolean
		
30: If m_eMode = enumMode.MODE_AJOUT_MODIF Then
35: If Button = VB6.MouseButtonConstants.RightButton Then
40: If lvwAchat.Items.Count > 0 Then
					'S'il y a plusieurs items de sélectionnés, c'est parce que l'utilisateur
					'a sélectionné plusieurs items
					'Donc, on ne désélectionne pas
45: For iCompteur = 1 To lvwAchat.Items.Count
50: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If lvwAchat.Items.Item(iCompteur).Selected = True Then
55: iNbreSelected = iNbreSelected + 1
							
60: iIndexSelected = iCompteur
65: End If
70: Next 
					
75: If iNbreSelected = 1 Then
80: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						lvwAchat.Items.Item(iIndexSelected).Selected = False
85: End If
					
90: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwAchat.DropHighlight was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					lvwAchat.DropHighlight = lvwAchat.GetItemAt(X, Y)
					
95: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwAchat.DropHighlight was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					If Not lvwAchat.DropHighlight Is Nothing Then
100: If iNbreSelected = 1 Then
105: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwAchat.DropHighlight was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
							lvwAchat.DropHighlight.Selected = True
							
110: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwAchat.DropHighlight was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
							'UPGRADE_WARNING: Lower bound of collection lvwAchat.DropHighlight has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If lvwAchat.DropHighlight.SubItems(I_COL_ACHAT_DATE_REQUISE).Text = "" Then
115: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwAchat.DropHighlight was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
								'UPGRADE_WARNING: Lower bound of collection lvwAchat.DropHighlight has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If lvwAchat.DropHighlight.SubItems.Count > I_COL_ACHAT_DATE_REQUISE Then
									lvwAchat.DropHighlight.SubItems(I_COL_ACHAT_DATE_REQUISE).Text = " "
								Else
									lvwAchat.DropHighlight.SubItems.Insert(I_COL_ACHAT_DATE_REQUISE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
								End If
120: End If
							
125: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwAchat.DropHighlight was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
							'UPGRADE_WARNING: Lower bound of collection lvwAchat.DropHighlight.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If System.Drawing.ColorTranslator.ToOle(lvwAchat.DropHighlight.SubItems.Item(I_COL_ACHAT_DATE_REQUISE).ForeColor) = COLOR_ORANGE Then
130: bAfficherMenu = True
135: Else
140: bAfficherMenu = False
145: End If
150: Else
155: bAfficherMenu = False
160: End If
165: Else
170: bAfficherMenu = False
175: End If
					
180: If bAfficherMenu = True Then
185: Call RemplirOptionsMenuRightClick(iNbreSelected)
						
190: 'UPGRADE_ISSUE: Form method frmAchat.PopupMenu was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						Call PopupMenu(mnuRightClick)
195: End If
200: End If
205: Else
210: If Shift <> VB6.ShiftConstants.CtrlMask And Shift <> VB6.ShiftConstants.ShiftMask Then
215: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwAchat.DropHighlight was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					'UPGRADE_NOTE: Object lvwAchat.DropHighlight may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					lvwAchat.DropHighlight = Nothing
220: End If
225: End If
230: End If
		
235: Exit Sub
		
AfficherErreur: 
		
240: Call AfficherErreur("frmAchat", "lvwAchat_MouseDown", Err, Erl())
	End Sub
	
	Private Sub RemplirOptionsMenuRightClick(ByVal iNbreSelected As Short)
		
5: On Error GoTo AfficherErreur
		
10: Dim bDateRequise As Boolean
		
15: If iNbreSelected = 1 Then
			'Si c'est une sous-section
20: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Select Case System.Drawing.ColorTranslator.ToOle(lvwAchat.FocusedItem.SubItems.Item(I_COL_ACHAT_PIECE).ForeColor)
				Case COLOR_ORANGE
25: bDateRequise = True
30: End Select
35: End If
		
		'Pour empeche que tous les éléments deviennent invisible, je les mets visible au
		'début
40: mnuDateRequise.Visible = True
		
45: mnuDateRequise.Visible = bDateRequise
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmAchat", "RemplirOptionsMenuRightClick", Err, Erl())
	End Sub
	
	Private Sub lvwPieces_ColumnClick(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ColumnClickEventArgs) Handles lvwPieces.ColumnClick
		Dim ColumnHeader As System.Windows.Forms.ColumnHeader = lvwPieces.Columns(eventArgs.Column)
		
5: On Error GoTo AfficherErreur
		
10: Dim sTexte As String
		
15: sTexte = InputBox("Quel est le texte à rechercher?")
		
20: If Trim(sTexte) <> vbNullString Then
25: If Len(Trim(sTexte)) >= 2 Then
30: Call RemplirListViewRecherche(ColumnHeader.Index - 1, sTexte)
				
35: If lvwPieceTrouve.Items.Count > 0 Then
40: fraPieceTrouve.Visible = True
45: Else
50: Call MsgBox("Aucun enregistrements trouvés!", MsgBoxStyle.OKOnly, "Erreur")
55: End If
60: Else
65: Call MsgBox("Il faut un minimum de 2 caractères pour rechercher!", MsgBoxStyle.OKOnly, "Erreur")
70: End If
75: End If
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmAchat", "lvwPieces_ColumnClick", Err, Erl())
	End Sub
	
	Private Sub RechercherPiece(ByVal iCol As Short, ByVal sTexte As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim sValeur As String
15: Dim rstcat As ADODB.Recordset
20: Dim iCompteur As Short
25: Dim bTrouverLvw As Boolean
30: Dim bTrouverRst As Boolean
35: Dim iIndexCat As Short
40: Dim sChamps As String
45: Dim sCategorie As String
		
50: For iCompteur = 1 To lvwPieces.Items.Count
55: If iCol > 0 Then
60: 'UPGRADE_WARNING: Lower bound of collection lvwPieces.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwPieces.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				sValeur = lvwPieces.Items.Item(iCompteur).SubItems(iCol).Text
65: Else
70: 'UPGRADE_WARNING: Lower bound of collection lvwPieces.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				sValeur = lvwPieces.Items.Item(iCompteur).Text
75: End If
			
80: sValeur = UCase(sValeur)
85: sTexte = UCase(sTexte)
			
90: If InStr(1, sValeur, sTexte) > 0 Then
95: 'UPGRADE_WARNING: Lower bound of collection lvwPieces.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvwPieces.Items.Item(iCompteur).Selected = True
				
100: 'UPGRADE_WARNING: MSComctlLib.IListItem method lvwPieces.SelectedItem.EnsureVisible has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				Call lvwPieces.FocusedItem.EnsureVisible()
				
105: bTrouverLvw = True
110: End If
			
115: If bTrouverLvw = True Then
120: Exit For
125: End If
130: Next 
		
135: Select Case iCol
			Case I_COL_PIECES_PIECE_GRB : sChamps = "PIECE_GRB"
140: Case I_COL_PIECES_NO_ITEM : sChamps = "PIECE"
145: Case I_COL_PIECES_MANUFACT : sChamps = "FABRICANT"
150: Case I_COL_PIECES_DESCR_FR : sChamps = "DESC_FR"
155: Case I_COL_PIECES_DESCR_EN : sChamps = "DESC_EN"
160: End Select
		
165: iIndexCat = cmbCategorie.SelectedIndex
		
170: If bTrouverLvw = False Then
175: rstcat = New ADODB.Recordset
			
180: For iCompteur = iIndexCat + 1 To cmbCategorie.Items.Count - 1
185: sCategorie = Replace(VB6.GetItemString(cmbCategorie, iCompteur), "'", "''")
				
190: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
195: Call rstcat.Open("SELECT * FROM GRB_CatalogueElec WHERE INSTR(1, " & sChamps & ", '" & sTexte & "') > 0 AND CATEGORIE = '" & sCategorie & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
200: Else
205: Call rstcat.Open("SELECT * FROM GRB_CatalogueMec WHERE INSTR(1, " & sChamps & ", '" & sTexte & "') > 0 AND CATEGORIE = '" & sCategorie & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
210: End If
				
215: If Not rstcat.EOF Then
220: bTrouverRst = True
					
225: cmbCategorie.SelectedIndex = iCompteur
					
230: Call RechercherPiece(iCol, sTexte)
					
235: Exit For
240: End If
				
245: Call rstcat.Close()
250: Next 
			
255: If bTrouverRst = False Then
260: For iCompteur = 0 To iIndexCat - 1
265: sCategorie = Replace(VB6.GetItemString(cmbCategorie, iCompteur), "'", "''")
					
270: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
275: Call rstcat.Open("SELECT * FROM GRB_CatalogueElec WHERE INSTR(1, " & sChamps & ", '" & sTexte & "') > 0 AND CATEGORIE = '" & sCategorie & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
280: Else
285: Call rstcat.Open("SELECT * FROM GRB_CatalogueMec WHERE INSTR(1, " & sChamps & ", '" & sTexte & "') > 0 AND CATEGORIE = '" & sCategorie & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
290: End If
					
295: If Not rstcat.EOF Then
300: bTrouverRst = True
						
305: cmbCategorie.SelectedIndex = iCompteur
						
310: Call RechercherPiece(iCol, sTexte)
						
315: Exit For
320: End If
					
325: Call rstcat.Close()
330: Next 
				
335: If bTrouverRst = False Then
340: Call MsgBox("Aucun enregistrements trouvés!", MsgBoxStyle.OKOnly, "Erreur")
345: End If
350: End If
			
355: 'UPGRADE_NOTE: Object rstcat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstcat = Nothing
360: End If
		
365: Exit Sub
		
AfficherErreur: 
		
370: Call AfficherErreur("frmAchat", "RechercherPiece", Err, Erl())
	End Sub
	
	Private Sub lvwPieces_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lvwPieces.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: Dim sTexte As String
		
15: If Shift = VB6.ShiftConstants.CtrlMask Then
20: If KeyCode = System.Windows.Forms.Keys.F Then
25: sTexte = InputBox("Quel est le texte à rechercher?")
				
30: If Trim(sTexte) <> vbNullString Then
35: If Len(Trim(sTexte)) >= 3 Then
40: Call RechercherPiece(I_COL_PIECES_NO_ITEM, sTexte)
45: Else
50: Call MsgBox("Il faut un minimum de 3 caractères pour rechercher!", MsgBoxStyle.OKOnly, "Erreur")
55: End If
60: End If
65: End If
70: End If
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmAchat", "lvwPieces_KeyDown", Err, Erl())
	End Sub
	
	Private Sub cmdEnregistrer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEnregistrer.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim objControl As System.Windows.Forms.Control
15: Dim iIndexAchat As Short
		
		'Vérification des textbox
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
25: For	Each objControl In Me.Controls
30: 'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If TypeOf objControl Is System.Windows.Forms.TextBox Then
35: If objControl.Visible = True Then
40: If Trim(objControl.Text) = vbNullString Then
45: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
						System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
						
50: Call MsgBox("Vous devez remplir tous les champs!", MsgBoxStyle.OKOnly, "Erreur")
						
55: Exit Sub
60: End If
65: End If
70: End If
75: Next objControl
		
80: If BackupPieces(txtNoAchat.Text) = False Then
85: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			
90: If MsgBox("Une erreur est survenue lors de la copie de sauvegarde de l'achat en cours!" & vbNewLine & vbNewLine & "Voulez-vous continuer?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
95: Exit Sub
100: Else
105: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
110: End If
115: End If
		
		'Enregistre l'achat
120: Call EnregistrerAchat(txtNoAchat.Text)
		
		'Initialisation des variables booléennes
125: m_bInventaire = False
130: m_bMauvaisPrix = False
135: m_bPieceInutile = False
140: m_bRecherchePiece = False
		
145: Call OuvrirAchat(False)
		
		'Remet en mode inactif
150: Call AfficherControles(enumMode.MODE_INACTIF)
		
		'Affiche l'achat actuel
155: If Len(txtNoAchat.Text) = 9 Then
160: iIndexAchat = TrouverNouvelIndex
165: End If
		
170: If iIndexAchat > 0 Then
175: Call AfficherAchat(txtNoAchat.Text & "-" & VB.Right("00" & iIndexAchat, 3))
180: Else
185: Call AfficherAchat(txtNoAchat.Text)
190: End If
		
195: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
200: Exit Sub
		
AfficherErreur: 
		
205: Call AfficherErreur("frmAchat", "cmdEnregistrer_Click", Err, Erl())
	End Sub
	
	Private Function BackupPieces(ByVal sNoAchat As String) As Boolean
		
5: On Error GoTo AfficherErreur
		
10: Dim rstAchat As ADODB.Recordset
15: Dim rstAchatBackup As ADODB.Recordset
20: Dim sDateCopie As String
25: Dim sIDAchat As String
30: Dim iIndexAchat As Short
		
35: If m_bModeAjout = False Then
40: sIDAchat = VB.Left(sNoAchat, 9)
			
45: iIndexAchat = CShort(VB.Right(sNoAchat, 3))
50: Else
55: BackupPieces = True
			
60: Exit Function
65: End If
		
70: rstAchat = New ADODB.Recordset
75: rstAchatBackup = New ADODB.Recordset
		
80: Call rstAchat.Open("SELECT * FROM GRB_Achat_Pieces WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat, g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
85: Call rstAchatBackup.Open("SELECT * FROM GRB_Achat_Pieces_Tampon", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
90: sDateCopie = ConvertDate(Today) & " " & TimeOfDay
		
95: Do While Not rstAchat.EOF
100: Call rstAchatBackup.AddNew()
			
105: rstAchatBackup.Fields("DateCopie").Value = sDateCopie
			
110: rstAchatBackup.Fields("IDAchat").Value = rstAchat.Fields("IDAchat").Value
115: rstAchatBackup.Fields("IndexAchat").Value = rstAchat.Fields("IndexAchat").Value
			
120: rstAchatBackup.Fields("Initiales").Value = g_sInitiale
125: rstAchatBackup.Fields("PIECE").Value = rstAchat.Fields("PIECE").Value
130: rstAchatBackup.Fields("NuméroLigne").Value = rstAchat.Fields("NuméroLigne").Value
135: rstAchatBackup.Fields("Qté").Value = rstAchat.Fields("Qté").Value
140: rstAchatBackup.Fields("Desc_FR").Value = rstAchat.Fields("Desc_FR").Value
145: rstAchatBackup.Fields("Desc_EN").Value = rstAchat.Fields("Desc_EN").Value
150: rstAchatBackup.Fields("Manufact").Value = rstAchat.Fields("Manufact").Value
155: rstAchatBackup.Fields("Prix_list").Value = rstAchat.Fields("Prix_list").Value
160: rstAchatBackup.Fields("Escompte").Value = rstAchat.Fields("Escompte").Value
165: rstAchatBackup.Fields("Prix_net").Value = rstAchat.Fields("Prix_net").Value
170: rstAchatBackup.Fields("IDFRS").Value = rstAchat.Fields("IDFRS").Value
175: rstAchatBackup.Fields("Prix_total").Value = rstAchat.Fields("Prix_total").Value
180: rstAchatBackup.Fields("Type").Value = rstAchat.Fields("Type").Value
185: rstAchatBackup.Fields("Commandé").Value = rstAchat.Fields("Commandé").Value
190: rstAchatBackup.Fields("Retour").Value = rstAchat.Fields("Retour").Value
195: rstAchatBackup.Fields("NoRetour").Value = rstAchat.Fields("NoRetour").Value
200: rstAchatBackup.Fields("Recu").Value = rstAchat.Fields("Recu").Value
205: rstAchatBackup.Fields("DateRéception").Value = rstAchat.Fields("DateRéception").Value
210: rstAchatBackup.Fields("QuantitéRecue").Value = rstAchat.Fields("QuantitéRecue").Value
215: rstAchatBackup.Fields("DateCommande").Value = rstAchat.Fields("DateCommande").Value
220: rstAchatBackup.Fields("DateRequise").Value = rstAchat.Fields("DateRequise").Value
225: rstAchatBackup.Fields("Inutile").Value = rstAchat.Fields("Inutile").Value
230: rstAchatBackup.Fields("CommandeAnnulée").Value = rstAchat.Fields("CommandeAnnulée").Value
235: rstAchatBackup.Fields("DateRetour").Value = rstAchat.Fields("DateRetour").Value
240: rstAchatBackup.Fields("PrixOrigine").Value = rstAchat.Fields("PrixOrigine").Value
245: rstAchatBackup.Fields("Devise").Value = rstAchat.Fields("Devise").Value
			
250: Call rstAchatBackup.Update()
			
255: Call rstAchat.MoveNext()
260: Loop 
		
265: Call rstAchat.Close()
270: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAchat = Nothing
		
275: Call rstAchatBackup.Close()
280: 'UPGRADE_NOTE: Object rstAchatBackup may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAchatBackup = Nothing
		
285: BackupPieces = True
		
290: Exit Function
		
AfficherErreur: 
		
295: Call AfficherErreur("frmAchat", "BackupPieces", Err, Erl())
	End Function
	
	Private Function TrouverNouvelIndex() As Short
		
5: On Error GoTo AfficherErreur
		
10: Dim rstMax As ADODB.Recordset
15: Dim iIndex As Short
		
20: rstMax = New ADODB.Recordset
		
25: Call rstMax.Open("SELECT MAX(IndexAchat) AS MaxIndex FROM GRB_Achat WHERE IDAchat = '" & txtNoAchat.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
30: iIndex = rstMax.Fields("MaxIndex").Value
		
35: Call rstMax.Close()
40: 'UPGRADE_NOTE: Object rstMax may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstMax = Nothing
		
45: TrouverNouvelIndex = iIndex
		
50: Exit Function
		
AfficherErreur: 
		
55: Call AfficherErreur("frmAchat", "TrouverNouvelIndex", Err, Erl())
	End Function
	
	Private Sub EnregistrerAchat(ByVal sNoAchat As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstAchat As ADODB.Recordset
15: Dim rstPiece As ADODB.Recordset
20: Dim rstMax As ADODB.Recordset
25: Dim itmPiece As System.Windows.Forms.ListViewItem
30: Dim dblPrixTotal As Double
35: Dim sIDAchat As String
40: Dim iIndexAchat As Short
45: Dim iCompteur As Short
		Dim testgll As String
50: sIDAchat = VB.Left(sNoAchat, 9)
		
55: rstAchat = New ADODB.Recordset
		
		'Si c'est un ajout
60: If m_bModeAjout = True Then
			'On ouvre le recordset
65: Call rstAchat.Open("SELECT * FROM GRB_Achat", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'Ajouter une nouvelle achat
70: Call rstAchat.AddNew()
			
75: m_bModeAjout = False
80: Else
85: iIndexAchat = CShort(VB.Right(sNoAchat, 3))
			
90: Call rstAchat.Open("SELECT * FROM GRB_Achat WHERE IDAchat" & " = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'Si c'est une modification, il faut effacer les pieces et remplir les nouvelles
95: Call g_connData.Execute("DELETE * FROM GRB_Achat_Pieces WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat)
100: End If
		
		'Enregistrement de l'achat
		
		'IDAchat
105: rstAchat.Fields("IDAchat").Value = sIDAchat
		
		'IndexAchat
110: If iIndexAchat = 0 Then
115: rstMax = New ADODB.Recordset
			
			'Pour avoir le dernier index
120: Call rstMax.Open("SELECT MAX(IndexAchat) As MaxAchat FROM GRB_Achat WHERE IDAchat = '" & sNoAchat & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
125: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstMax.Fields("MaxAchat").Value) Then
130: rstAchat.Fields("IndexAchat").Value = rstMax.Fields("MaxAchat").Value + 1
135: Else
140: rstAchat.Fields("IndexAchat").Value = 1
145: End If
			
150: Call rstMax.Close()
155: 'UPGRADE_NOTE: Object rstMax may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstMax = Nothing
160: Else
165: rstAchat.Fields("IndexAchat").Value = iIndexAchat
170: End If
		
175: rstAchat.Fields("Raison").Value = txtRaison.Text
180: rstAchat.Fields("DateAchat").Value = txtDate.Text
185: rstAchat.Fields("Acheteur").Value = txtAcheteur.Tag
		
190: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
195: rstAchat.Fields("Type").Value = "E"
200: Else
205: rstAchat.Fields("Type").Value = "M"
210: End If
		
215: rstPiece = New ADODB.Recordset
		
220: Call rstPiece.Open("SELECT * FROM GRB_Achat_Pieces", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Enregistrement des pièces
225: For iCompteur = 1 To lvwAchat.Items.Count
230: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmPiece = lvwAchat.Items.Item(iCompteur)
			
235: Call rstPiece.AddNew()
			
240: rstPiece.Fields("IDAchat").Value = rstAchat.Fields("IDAchat").Value
245: rstPiece.Fields("IndexAchat").Value = rstAchat.Fields("IndexAchat").Value
			
			
250: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			rstPiece.Fields("PIECE").Value = itmPiece.SubItems(I_COL_ACHAT_PIECE).Text
255: rstPiece.Fields("NuméroLigne").Value = iCompteur
260: rstPiece.Fields("Qté").Value = itmPiece.Text
265: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			rstPiece.Fields("Desc_FR").Value = itmPiece.SubItems(I_COL_ACHAT_DESCR).Text
270: 'UPGRADE_WARNING: Lower bound of collection itmPiece.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object itmPiece.ListSubItems().Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rstPiece.Fields("Desc_EN").Value = itmPiece.SubItems.Item(I_COL_ACHAT_DESCR).Tag
275: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			rstPiece.Fields("Manufact").Value = itmPiece.SubItems(I_COL_ACHAT_MANUFACT).Text
280: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			rstPiece.Fields("Prix_list").Value = Conversion_Renamed(itmPiece.SubItems(I_COL_ACHAT_PRIX_LIST).Text, ModuleMain.enumConvert.MODE_PAS_FORMAT, 4)
			
285: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPiece.SubItems(I_COL_ACHAT_PRIX_LIST).Text <> vbNullString Then
290: 'UPGRADE_WARNING: Lower bound of collection itmPiece.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Tag <> vbNullString Then
295: 'UPGRADE_WARNING: Lower bound of collection itmPiece.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					rstPiece.Fields("PrixOrigine").Value = Replace(CStr(System.Math.Round(CDbl(Replace(itmPiece.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Tag, ".", ",")), 4)), ".", ",")
300: Else
305: rstPiece.Fields("PrixOrigine").Value = "0"
310: End If
315: Else
320: rstPiece.Fields("PrixOrigine").Value = "0"
325: End If
			
330: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPiece.SubItems(I_COL_ACHAT_TOTAL).Text <> "" Then
335: 'UPGRADE_WARNING: Lower bound of collection itmPiece.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Couldn't resolve default property of object itmPiece.ListSubItems().Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				rstPiece.Fields("Devise").Value = itmPiece.SubItems.Item(I_COL_ACHAT_TOTAL).Tag
340: Else
345: rstPiece.Fields("Devise").Value = ""
350: End If
			
355: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If Trim(itmPiece.SubItems(I_COL_ACHAT_ESCOMPTE).Text) <> "" Then
360: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				rstPiece.Fields("Escompte").Value = Conversion_Renamed(CDbl(Replace(itmPiece.SubItems(I_COL_ACHAT_ESCOMPTE).Text, "%", "")) / 100, ModuleMain.enumConvert.MODE_PAS_FORMAT)
365: Else
370: rstPiece.Fields("Escompte").Value = ""
375: End If
			
380: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			rstPiece.Fields("Prix_net").Value = Conversion_Renamed(itmPiece.SubItems(I_COL_ACHAT_PRIX_NET).Text, ModuleMain.enumConvert.MODE_PAS_FORMAT, 4)
385: 'UPGRADE_WARNING: Couldn't resolve default property of object itmPiece.Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rstPiece.Fields("DateRéception").Value = itmPiece.Tag
390: 'UPGRADE_WARNING: Lower bound of collection itmPiece.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object itmPiece.ListSubItems().Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rstPiece.Fields("NoRetour").Value = itmPiece.SubItems.Item(I_COL_ACHAT_MANUFACT).Tag
			
395: 'UPGRADE_WARNING: Lower bound of collection itmPiece.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPiece.SubItems.Item(I_COL_ACHAT_DISTRIB).Tag <> "" Then
400: 'UPGRADE_WARNING: Lower bound of collection itmPiece.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Couldn't resolve default property of object itmPiece.ListSubItems().Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				rstPiece.Fields("IDFRS").Value = itmPiece.SubItems.Item(I_COL_ACHAT_DISTRIB).Tag
405: Else
410: rstPiece.Fields("IDFRS").Value = 0
415: End If
			
420: 'UPGRADE_WARNING: Lower bound of collection itmPiece.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If System.Drawing.ColorTranslator.ToOle(itmPiece.SubItems.Item(I_COL_ACHAT_PIECE).ForeColor) = COLOR_ORANGE Then
425: rstPiece.Fields("Commandé").Value = True
430: Else
435: rstPiece.Fields("Commandé").Value = False
440: End If
			
445: 'UPGRADE_WARNING: Lower bound of collection itmPiece.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If System.Drawing.ColorTranslator.ToOle(itmPiece.SubItems.Item(I_COL_ACHAT_PIECE).ForeColor) = COLOR_BLEU Or System.Drawing.ColorTranslator.ToOle(itmPiece.SubItems.Item(I_COL_ACHAT_PIECE).ForeColor) = COLOR_GRIS Then
450: rstPiece.Fields("Recu").Value = True
455: Else
460: rstPiece.Fields("Recu").Value = False
465: End If
			
470: 'UPGRADE_WARNING: Lower bound of collection itmPiece.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If System.Drawing.ColorTranslator.ToOle(itmPiece.SubItems.Item(I_COL_ACHAT_PIECE).ForeColor) = COLOR_ROUGE Then
475: rstPiece.Fields("Retour").Value = True
480: Else
485: rstPiece.Fields("Retour").Value = False
490: End If
			
495: 'UPGRADE_WARNING: Lower bound of collection itmPiece.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If System.Drawing.ColorTranslator.ToOle(itmPiece.SubItems.Item(I_COL_ACHAT_PIECE).ForeColor) = COLOR_BRUN Then
500: rstPiece.Fields("Inutile").Value = True
505: Else
510: rstPiece.Fields("Inutile").Value = False
515: End If
			
520: 'UPGRADE_WARNING: Lower bound of collection itmPiece.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If System.Drawing.ColorTranslator.ToOle(itmPiece.SubItems.Item(I_COL_ACHAT_PIECE).ForeColor) = COLOR_VERT_FORET Then
525: rstPiece.Fields("CommandeAnnulée").Value = True
530: Else
535: rstPiece.Fields("CommandeAnnulée").Value = False
540: End If
			
545: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			rstPiece.Fields("Prix_Total").Value = Conversion_Renamed(itmPiece.SubItems(I_COL_ACHAT_TOTAL).Text, ModuleMain.enumConvert.MODE_PAS_FORMAT)
			
550: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPiece.SubItems(I_COL_ACHAT_DATE_COMMANDE).Text <> "" Then
555: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				rstPiece.Fields("DateCommande").Value = itmPiece.SubItems(I_COL_ACHAT_DATE_COMMANDE).Text
560: Else
565: rstPiece.Fields("DateCommande").Value = ""
570: End If
			
575: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPiece.SubItems(I_COL_ACHAT_DATE_REQUISE).Text <> "" Then
580: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				rstPiece.Fields("DateRequise").Value = itmPiece.SubItems(I_COL_ACHAT_DATE_REQUISE).Text
585: Else
590: rstPiece.Fields("DateRequise").Value = ""
595: End If
			
600: Call rstPiece.Update()
			
605: If rstPiece.Fields("Prix_Total").Value <> vbNullString Then
610: dblPrixTotal = dblPrixTotal + rstPiece.Fields("Prix_Total").Value
615: End If
620: Next 
		
625: rstAchat.Fields("PrixTotal").Value = CStr(dblPrixTotal)
		
630: Call rstAchat.Update()
		
635: Call rstAchat.Close()
640: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAchat = Nothing
		
645: Call rstPiece.Close()
650: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
655: Exit Sub
		
AfficherErreur: 
		
660: Call AfficherErreur("frmAchat", "EnregistrerAchat", Err, Erl())
		
665: If Erl() >= 230 And Erl() <= 615 Then
670: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Call MsgBox("La pièce " & itmPiece.SubItems(I_COL_ACHAT_PIECE).Text & " risque de contenir des erreurs." & vbNewLine & "Il se peut qu'elle ne soit plus présente dans la liste.")
675: End If
		
680: Resume Next
	End Sub
	
	Private Sub AfficherAchat(ByVal sNoAchat As String)
		
5: On Error GoTo AfficherErreur
		
		'Remet en mode affichage le projet ou l'achat voulue
10: m_bModeAffichage = True
		
		'Vide les champs
15: Call ViderChamps()
		
		'Rempli le combo
20: Call RemplirComboAchat(sNoAchat)
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmAchat", "AfficherAchat", Err, Erl())
	End Sub
	
	Private Sub Cmdfermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cmdfermer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmAchat", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub Cmdajouter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cmdajouter.Click
		
5: On Error GoTo AfficherErreur
		
		'Ajoute une achat
10: Dim rstEmploye As ADODB.Recordset
		
		'Initialisation des variables booléennes
15: m_bInventaire = False
20: m_bMauvaisPrix = False
25: m_bPieceInutile = False
30: m_bRecherchePiece = False
		
35: Call frmAjoutAchat.Afficher(m_eCatalogue)
		
40: If m_bAnnuler = False Then
45: If m_sNoAchat <> vbNullString Then
				'Vide les champs
50: Call ViderChamps()
				
55: txtAcheteur.Text = g_sEmploye
				
60: rstEmploye = New ADODB.Recordset
				
65: Call rstEmploye.Open("SELECT NoEmploye FROM GRB_Employés WHERE Initiale = '" & g_sInitiale & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
70: txtAcheteur.Tag = rstEmploye.Fields("NoEmploye").Value
				
75: Call rstEmploye.Close()
80: 'UPGRADE_NOTE: Object rstEmploye may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstEmploye = Nothing
				
85: txtDate.Text = ConvertDate(Today)
				
				'Pour pouvoir réafficher l'élément affiché avant l'ajout au cas où la personne
				'annule l'ajout
90: m_sAncienAchat = txtNoAchat.Text
				
				'Affiche le nouveau numéro
95: txtNoAchat.Text = m_sNoAchat
				
100: m_bModeAjout = True
105: m_bModeAffichage = False
				
				'Met le form en mode ajout/modif
110: Call AfficherControles(enumMode.MODE_AJOUT_MODIF)
115: End If
120: End If
		
125: Exit Sub
		
AfficherErreur: 
		
130: Call AfficherErreur("frmAchat", "cmdAjouter_Click", Err, Erl())
	End Sub
	
	Private Sub RemplirComboCategorie()
		
5: On Error GoTo AfficherErreur
		
		'Remplir le combo des tables (Pièces)
10: Dim rstCategorie As ADODB.Recordset
15: Dim sNomTable As String
		
		'Il faut vider le combo avant de le remplir
20: Call cmbCategorie.Items.Clear()
		
25: rstCategorie = New ADODB.Recordset
		
		'On rempli le recordset avec le nom de chaque catégorie
30: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
35: Call rstCategorie.Open("SELECT DISTINCT CATEGORIE FROM GRB_CatalogueElec", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
40: Else
45: Call rstCategorie.Open("SELECT DISTINCT CATEGORIE FROM GRB_CatalogueMec", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
50: End If
		
		'Tant que ce n'est pas la fin des enregistrements
55: Do While Not rstCategorie.EOF
60: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstCategorie.Fields("CATEGORIE").Value) Then
				'On ajoute le nom de la catégorie dans le combo
65: Call cmbCategorie.Items.Add(rstCategorie.Fields("CATEGORIE").Value)
70: End If
			
75: Call rstCategorie.MoveNext()
80: Loop 
		
85: Call rstCategorie.Close()
90: 'UPGRADE_NOTE: Object rstCategorie may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstCategorie = Nothing
		
95: If cmbCategorie.Items.Count > 0 Then
100: cmbCategorie.SelectedIndex = 0
105: End If
		
110: Exit Sub
		
AfficherErreur: 
		
115: Call AfficherErreur("frmAchat", "RemplirComboCategorie", Err, Erl())
	End Sub
	
	Private Sub cmdModifier_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdModifier.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstAchat As ADODB.Recordset
15: Dim sIDAchat As String
20: Dim iIndexAchat As Short
		
		'Modifier un achat
		
		'Initialisation des variables booléennes
25: m_bInventaire = False
30: m_bMauvaisPrix = False
35: m_bPieceInutile = False
40: m_bRecherchePiece = False
		
45: If cmbNoAchat.SelectedIndex > -1 Then
50: sIDAchat = Trim(VB.Left(txtNoAchat.Text, InStr(1, txtNoAchat.Text, "-") + 2))
55: iIndexAchat = CShort(Trim(VB.Right(txtNoAchat.Text, Len(txtNoAchat.Text) - InStrRev(txtNoAchat.Text, "-"))))
			
60: rstAchat = New ADODB.Recordset
			
65: Call rstAchat.Open("SELECT Modification, Par FROM GRB_Achat WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
70: If rstAchat.Fields("Modification").Value = False Then
75: Call rstAchat.Close()
80: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstAchat = Nothing
				
85: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
				'Pour pouvoir afficher le dernier enregistrement affiché quand la personne va
				'enregistrer ou annuler
90: m_sAncienAchat = txtNoAchat.Text
				
95: m_bModeAjout = False
100: m_bModeAffichage = False
				
105: Call OuvrirAchat(True)
				
110: Call AfficherControles(enumMode.MODE_AJOUT_MODIF)
				
115: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
120: Else
125: Call MsgBox("Cet achat est en modification par " & rstAchat.Fields("Par").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
				
130: Call rstAchat.Close()
135: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstAchat = Nothing
140: End If
145: End If
		
150: Exit Sub
		
AfficherErreur: 
		
155: Call AfficherErreur("frmAchat", "cmdModifier_Click", Err, Erl())
	End Sub
	
	Private Sub cmdsupprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdsupprimer.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iReponse As Short
15: Dim sIDAchat As String
20: Dim iIndexAchat As Short
25: Dim rstAchat As ADODB.Recordset
		
30: If cmbNoAchat.Items.Count > 0 Then
35: sIDAchat = Trim(VB.Left(txtNoAchat.Text, InStr(1, txtNoAchat.Text, "-") + 2))
40: iIndexAchat = CShort(Trim(VB.Right(txtNoAchat.Text, Len(txtNoAchat.Text) - InStrRev(txtNoAchat.Text, "-"))))
			
45: rstAchat = New ADODB.Recordset
			
50: Call rstAchat.Open("SELECT Modification, Par FROM GRB_Achat WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
55: If rstAchat.Fields("Modification").Value = False Then
60: Call rstAchat.Close()
65: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstAchat = Nothing
				
				'Valider le choix
70: iReponse = MsgBox("Voulez-vous vraiment effacer l'achat " & txtNoAchat.Text & "?", MsgBoxStyle.YesNo)
				
				'Si il veut vraiment effacer
75: If iReponse = MsgBoxResult.Yes Then
					'Efface les pièces
80: sIDAchat = VB.Left(txtNoAchat.Text, 9)
					
85: iIndexAchat = CShort(VB.Right(txtNoAchat.Text, 3))
					
					'Efface les pièces
90: Call g_connData.Execute("DELETE * FROM GRB_Achat_Pieces WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat)
					
					'Efface l'achat
95: Call g_connData.Execute("DELETE * FROM GRB_Achat WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat)
					
100: 'Affiche la premiere achat
105: Call RemplirComboAchat(vbNullString)
110: End If
115: Else
120: Call MsgBox("Cet achat est en modification par " & rstAchat.Fields("Par").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
				
125: Call rstAchat.Close()
130: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstAchat = Nothing
135: End If
140: End If
		
145: Exit Sub
		
AfficherErreur: 
		
150: Call AfficherErreur("frmAchat", "cmdSupprimer_Click", Err, Erl())
	End Sub
	
	Private Sub ViderChamps()
		
5: On Error GoTo AfficherErreur
		
		'Méthode qui initialise les champs
10: txtPrixTotal.Text = CStr(0)
15: txtDate.Text = vbNullString
20: txtRaison.Text = vbNullString
25: txtAcheteur.Text = vbNullString
		
30: Call lvwAchat.Items.Clear()
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmAchat", "ViderChamps", Err, Erl())
	End Sub
	
	Private Sub RemplirComboAchat(ByVal sNoAchat As String)
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des achats
10: Dim rstAchat As ADODB.Recordset
15: Dim sType As String
20: Dim iCompteur As Short
		
		'Il faut vider le combo avant de le remplir
25: Call cmbNoAchat.Items.Clear()
		
30: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
35: sType = "E"
40: Else
45: sType = "M"
50: End If
		
55: rstAchat = New ADODB.Recordset
		
60: Call rstAchat.Open("SELECT * FROM GRB_Achat WHERE Type = '" & sType & "' ORDER BY IDAchat DESC, IndexAchat DESC", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
65: Do While Not rstAchat.EOF
			'On met le numéro de l'achat dans le combo des achats
70: Call cmbNoAchat.Items.Add(rstAchat.Fields("IDAchat").Value & "-" & VB.Right("00" & rstAchat.Fields("IndexAchat").Value, 3))
			
75: Call rstAchat.MoveNext()
80: Loop 
		
85: Call rstAchat.Close()
90: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAchat = Nothing
		
		'Si le combo n'est pas vide, on sélectionne l'item voulu ou le premier
95: If cmbNoAchat.Items.Count > 0 Then
100: If sNoAchat <> vbNullString Then
105: For iCompteur = 0 To cmbNoAchat.Items.Count - 1
110: If VB6.GetItemString(cmbNoAchat, iCompteur) = sNoAchat Then
115: cmbNoAchat.SelectedIndex = iCompteur
						
120: Exit For
125: End If
130: Next 
135: Else
140: cmbNoAchat.SelectedIndex = 0
145: End If
150: Else
155: Call ViderChamps()
160: End If
		
165: Exit Sub
		
AfficherErreur: 
		
170: Call AfficherErreur("frmAchat", "RemplirComboAchat", Err, Erl())
	End Sub
	
	Private Sub CalculerPrixReel(ByVal sNoItem As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPieceFRS As ADODB.Recordset
15: Dim rstConfig As ADODB.Recordset
20: Dim sPrixCalcul As String
25: Dim sTauxUSA As String
30: Dim sTauxSPA As String
35: Dim sType As String
		
40: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
45: sType = "E"
50: Else
55: sType = "M"
60: End If
		
65: rstConfig = New ADODB.Recordset
		
70: Call rstConfig.Open("SELECT TauxAmericain, TauxEspagnol FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
75: sTauxUSA = rstConfig.Fields("TauxAmericain").Value
80: sTauxSPA = rstConfig.Fields("TauxEspagnol").Value
		
85: Call rstConfig.Close()
90: 'UPGRADE_NOTE: Object rstConfig may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstConfig = Nothing
		
95: rstPieceFRS = New ADODB.Recordset
		
100: rstPieceFRS.CursorLocation = ADODB.CursorLocationEnum.adUseServer
		
105: Call rstPieceFRS.Open("SELECT PrixReel, PRIX_NET, PRIX_SP, DeviseMonétaire FROM GRB_PiecesFRS WHERE PIECE = '" & Replace(sNoItem, "'", "''") & "' AND Type = '" & sType & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
110: Do While Not rstPieceFRS.EOF
115: If rstPieceFRS.Fields("PRIX_NET").Value <> vbNullString Then
120: sPrixCalcul = rstPieceFRS.Fields("PRIX_NET").Value
125: Else
130: If rstPieceFRS.Fields("PRIX_SP").Value <> vbNullString Then
135: sPrixCalcul = rstPieceFRS.Fields("PRIX_SP").Value
140: End If
145: End If
			
150: sPrixCalcul = Replace(sPrixCalcul, ".", ",")
			
155: If rstPieceFRS.Fields("DeviseMonétaire").Value = "USA" Then
160: rstPieceFRS.Fields("PrixReel").Value = Conversion_Renamed(CStr(System.Math.Round(CDbl(sPrixCalcul) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_DECIMAL, 4)
165: Else
170: If rstPieceFRS.Fields("DeviseMonétaire").Value = "SPA" Then
175: rstPieceFRS.Fields("PrixReel").Value = Conversion_Renamed(CStr(System.Math.Round(CDbl(sPrixCalcul) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_DECIMAL, 4)
180: Else
185: rstPieceFRS.Fields("PrixReel").Value = Conversion_Renamed(sPrixCalcul, ModuleMain.enumConvert.MODE_DECIMAL, 4)
190: End If
195: End If
			
200: Call rstPieceFRS.Update()
			
205: Call rstPieceFRS.MoveNext()
210: Loop 
		
215: Call rstPieceFRS.Close()
220: 'UPGRADE_NOTE: Object rstPieceFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPieceFRS = Nothing
		
225: Exit Sub
		
AfficherErreur: 
		
230: Call AfficherErreur("frmAchat", "CalculerPrixReel", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewFournisseur()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le listview des distributeur pour une pièce choisie
10: Dim rstPieceFRS As ADODB.Recordset
15: Dim rstContact As ADODB.Recordset
20: Dim rstFRS As ADODB.Recordset
25: Dim iCompteur As Short
30: Dim itmFRS As System.Windows.Forms.ListViewItem
35: Dim sDevise As String
40: Dim iNoClient As Short
45: Dim lColor As Integer
50: Dim sType As String
		
55: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
60: sType = "E"
65: Else
70: sType = "M"
75: End If
		
		'vide le lister
80: Call lvwfournisseur.Items.Clear()
		
85: rstPieceFRS = New ADODB.Recordset
		
90: If m_bPieceInutile = True Then
95: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Call CalculerPrixReel(Trim(lvwAchat.FocusedItem.SubItems(I_COL_ACHAT_PIECE).Text))
			
100: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			Call rstPieceFRS.Open("SELECT GRB_PiecesFRS.*, GRB_Fournisseur.NomFournisseur FROM GRB_PiecesFRS INNER JOIN GRB_Fournisseur ON GRB_PiecesFRS.IDFRS = GRB_Fournisseur.IDFRS WHERE PIECE = '" & Trim(Replace(lvwAchat.FocusedItem.SubItems(I_COL_ACHAT_PIECE).Text, "'", "''")) & "' AND Type = '" & sType & "' ORDER BY PrixReel", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
105: Else
110: If m_bInventaire = True Then
115: Call CalculerPrixReel(Trim(lvwInventaire.FocusedItem.Text))
				
120: Call rstPieceFRS.Open("SELECT GRB_PiecesFRS.*, GRB_Fournisseur.NomFournisseur FROM GRB_PiecesFRS INNER JOIN GRB_Fournisseur ON GRB_PiecesFRS.IDFRS = GRB_Fournisseur.IDFRS WHERE PIECE = '" & Trim(Replace(lvwInventaire.FocusedItem.Text, "'", "''")) & "' AND Type = '" & sType & "' ORDER BY PrixReel", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
125: Else
130: If m_bRecherchePiece = True Then
135: 'UPGRADE_WARNING: Lower bound of collection lvwPieceTrouve.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call CalculerPrixReel(Trim(lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_NO_ITEM).Text))
					
140: 'UPGRADE_WARNING: Lower bound of collection lvwPieceTrouve.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call rstPieceFRS.Open("SELECT GRB_PiecesFRS.*, GRB_Fournisseur.NomFournisseur FROM GRB_PiecesFRS INNER JOIN GRB_Fournisseur ON GRB_PiecesFRS.IDFRS = GRB_Fournisseur.IDFRS WHERE PIECE = '" & Trim(Replace(lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_NO_ITEM).Text, "'", "''")) & "' AND Type = '" & sType & "' ORDER BY PrixReel", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
145: Else
150: 'UPGRADE_WARNING: Lower bound of collection lvwPieces.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call CalculerPrixReel(Trim(lvwPieces.FocusedItem.SubItems(I_COL_PIECES_NO_ITEM).Text))
					
155: 'UPGRADE_WARNING: Lower bound of collection lvwPieces.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call rstPieceFRS.Open("SELECT GRB_PiecesFRS.*, GRB_Fournisseur.NomFournisseur FROM GRB_PiecesFRS INNER JOIN GRB_Fournisseur ON GRB_PiecesFRS.IDFRS = GRB_Fournisseur.IDFRS WHERE PIECE = '" & Trim(Replace(lvwPieces.FocusedItem.SubItems(I_COL_PIECES_NO_ITEM).Text, "'", "''")) & "' AND Type = '" & sType & "' ORDER BY PrixReel", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
160: End If
165: End If
170: End If
		
175: rstFRS = New ADODB.Recordset
		
180: Call rstFRS.Open("SELECT IDFRS FROM GRB_Fournisseur WHERE NomFournisseur = 'FOURNI PAR LE CLIENT'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
185: iNoClient = rstFRS.Fields("IDFRS").Value
		
190: Call rstFRS.Close()
195: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
		
		'tant il y a des fournisseur de la piece, ajoute dans lister
200: Do While Not rstPieceFRS.EOF
205: If rstPieceFRS.Fields("IDFRS").Value = iNoClient Then
210: Call rstPieceFRS.MoveNext()
				
215: If rstPieceFRS.EOF Then
220: Exit Do
225: End If
230: End If
			
			'on change la couleur de l'enregistrement selon la devise monétaire.
			'CAN = noir, USA ou ESP = bleu
235: If rstPieceFRS.Fields("DeviseMonétaire").Value = "CAN" Then
240: sDevise = "CAN"
245: lColor = COLOR_NOIR
250: Else
255: If rstPieceFRS.Fields("DeviseMonétaire").Value = "USA" Then
260: sDevise = "USA"
265: lColor = COLOR_BLEU
270: Else
275: sDevise = "SPA"
280: lColor = COLOR_BLEU
285: End If
290: End If
			
295: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwfournisseur.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmFRS = lvwfournisseur.Items.Add()
			
300: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmFRS.SubItems.Count > I_COL_FRS_PRIX_LIST Then
				itmFRS.SubItems(I_COL_FRS_PRIX_LIST).Text = " "
			Else
				itmFRS.SubItems.Insert(I_COL_FRS_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
			End If
305: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmFRS.SubItems.Count > I_COL_FRS_ESCOMPTE Then
				itmFRS.SubItems(I_COL_FRS_ESCOMPTE).Text = " "
			Else
				itmFRS.SubItems.Insert(I_COL_FRS_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
			End If
310: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmFRS.SubItems.Count > I_COL_FRS_PRIX_NET Then
				itmFRS.SubItems(I_COL_FRS_PRIX_NET).Text = " "
			Else
				itmFRS.SubItems.Insert(I_COL_FRS_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
			End If
315: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmFRS.SubItems.Count > I_COL_FRS_PRIX_SP Then
				itmFRS.SubItems(I_COL_FRS_PRIX_SP).Text = " "
			Else
				itmFRS.SubItems.Insert(I_COL_FRS_PRIX_SP, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
			End If
			
			'Nom du FRS
320: itmFRS.Text = rstPieceFRS.Fields("NomFournisseur").Value
			
325: itmFRS.Tag = rstPieceFRS.Fields("IDFRS").Value
			
330: itmFRS.ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'Personne ressource
335: If Trim(rstPieceFRS.Fields("PERS_RESS").Value) <> vbNullString Then
340: rstContact = New ADODB.Recordset
				
345: Call rstContact.Open("SELECT NomContact FROM GRB_Contact WHERE IDContact = " & rstPieceFRS.Fields("PERS_RESS").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
350: If Not rstContact.EOF Then
355: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmFRS.SubItems.Count > I_COL_FRS_PERS_RESS Then
						itmFRS.SubItems(I_COL_FRS_PERS_RESS).Text = rstContact.Fields("NomContact").Value
					Else
						itmFRS.SubItems.Insert(I_COL_FRS_PERS_RESS, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstContact.Fields("NomContact").Value))
					End If
					
360: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmFRS.SubItems.Item(I_COL_FRS_PERS_RESS).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
365: Else
370: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmFRS.SubItems.Count > I_COL_FRS_PERS_RESS Then
						itmFRS.SubItems(I_COL_FRS_PERS_RESS).Text = ""
					Else
						itmFRS.SubItems.Insert(I_COL_FRS_PERS_RESS, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
					End If
375: End If
				
380: Call rstContact.Close()
385: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstContact = Nothing
390: End If
			
			'Date
395: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieceFRS.Fields("Date").Value) Then
400: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_DATE Then
					itmFRS.SubItems(I_COL_FRS_DATE).Text = rstPieceFRS.Fields("Date").Value
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_DATE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieceFRS.Fields("Date").Value))
				End If
				
405: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmFRS.SubItems.Item(I_COL_FRS_DATE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
410: Else
415: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_DATE Then
					itmFRS.SubItems(I_COL_FRS_DATE).Text = vbNullString
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_DATE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
420: End If
			
			'Entrer par
425: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieceFRS.Fields("Entrer_Par").Value) Then
430: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_ENTRER_PAR Then
					itmFRS.SubItems(I_COL_FRS_ENTRER_PAR).Text = rstPieceFRS.Fields("Entrer_Par").Value
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_ENTRER_PAR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieceFRS.Fields("Entrer_Par").Value))
				End If
				
435: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmFRS.SubItems.Item(I_COL_FRS_ENTRER_PAR).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
440: Else
445: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_ENTRER_PAR Then
					itmFRS.SubItems(I_COL_FRS_ENTRER_PAR).Text = vbNullString
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_ENTRER_PAR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
450: End If
			
			'Valide
455: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieceFRS.Fields("Valide").Value) Then
460: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_VALIDE Then
					itmFRS.SubItems(I_COL_FRS_VALIDE).Text = rstPieceFRS.Fields("Valide").Value
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_VALIDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieceFRS.Fields("Valide").Value))
				End If
				
465: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmFRS.SubItems.Item(I_COL_FRS_VALIDE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
470: Else
475: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_VALIDE Then
					itmFRS.SubItems(I_COL_FRS_VALIDE).Text = vbNullString
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_VALIDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
480: End If
			
			'Prix listé
485: If rstPieceFRS.Fields("PRIX_LIST").Value <> vbNullString Then
490: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_PRIX_LIST Then
					itmFRS.SubItems(I_COL_FRS_PRIX_LIST).Text = Conversion_Renamed(System.Math.Round(CDbl(Replace(rstPieceFRS.Fields("PRIX_LIST").Value, ".", ",")), 4), ModuleMain.enumConvert.MODE_ARGENT, 4)
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(System.Math.Round(CDbl(Replace(rstPieceFRS.Fields("PRIX_LIST").Value, ".", ",")), 4), ModuleMain.enumConvert.MODE_ARGENT, 4)))
				End If
				
495: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmFRS.SubItems.Item(I_COL_FRS_PRIX_LIST).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
500: End If
			
			'Escompte
505: If rstPieceFRS.Fields("ESCOMPTE").Value <> vbNullString Then
510: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_ESCOMPTE Then
					itmFRS.SubItems(I_COL_FRS_ESCOMPTE).Text = Conversion_Renamed(CDbl(Replace(Replace(rstPieceFRS.Fields("ESCOMPTE").Value, "_", vbNullString), ".", ",")) * 100, ModuleMain.enumConvert.MODE_POURCENT)
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CDbl(Replace(Replace(rstPieceFRS.Fields("ESCOMPTE").Value, "_", vbNullString), ".", ",")) * 100, ModuleMain.enumConvert.MODE_POURCENT)))
				End If
				
515: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmFRS.SubItems.Item(I_COL_FRS_ESCOMPTE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
520: End If
			
			'Prix net
525: If rstPieceFRS.Fields("PRIX_NET").Value <> vbNullString Then
530: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_PRIX_NET Then
					itmFRS.SubItems(I_COL_FRS_PRIX_NET).Text = Conversion_Renamed(System.Math.Round(CDbl(Replace(rstPieceFRS.Fields("PRIX_NET").Value, ".", ",")), 4), ModuleMain.enumConvert.MODE_ARGENT, 4)
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(System.Math.Round(CDbl(Replace(rstPieceFRS.Fields("PRIX_NET").Value, ".", ",")), 4), ModuleMain.enumConvert.MODE_ARGENT, 4)))
				End If
				
535: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmFRS.SubItems.Item(I_COL_FRS_PRIX_NET).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
540: End If
			
			'Prix spécial
545: If rstPieceFRS.Fields("PRIX_SP").Value <> vbNullString Then
550: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_PRIX_SP Then
					itmFRS.SubItems(I_COL_FRS_PRIX_SP).Text = Conversion_Renamed(System.Math.Round(rstPieceFRS.Fields("PRIX_SP").Value, 4), ModuleMain.enumConvert.MODE_ARGENT, 4)
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_PRIX_SP, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(System.Math.Round(rstPieceFRS.Fields("PRIX_SP").Value, 4), ModuleMain.enumConvert.MODE_ARGENT, 4)))
				End If
				
555: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmFRS.SubItems.Item(I_COL_FRS_PRIX_SP).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
560: End If
			
			'Quoter
565: If rstPieceFRS.Fields("QUOTER").Value = True Then
570: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_QUOTER Then
					itmFRS.SubItems(I_COL_FRS_QUOTER).Text = "Oui"
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_QUOTER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Oui"))
				End If
575: Else
580: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_QUOTER Then
					itmFRS.SubItems(I_COL_FRS_QUOTER).Text = "Non"
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_QUOTER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Non"))
				End If
585: End If
			
590: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmFRS.SubItems.Item(I_COL_FRS_QUOTER).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'Pour garder en mémoire le prix d'origine, je le mets dans le
			'tag de la colonne Prix Listé
595: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmFRS.SubItems(I_COL_FRS_PRIX_LIST).Text = vbNullString Then
600: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_PRIX_LIST Then
					itmFRS.SubItems(I_COL_FRS_PRIX_LIST).Text = " "
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
				End If
605: End If
			
610: If rstPieceFRS.Fields("PRIX_NET").Value <> vbNullString Then
615: If rstPieceFRS.Fields("PRIX_LIST").Value = "0,00" Or rstPieceFRS.Fields("PRIX_LIST").Value = "0" Then
620: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmFRS.SubItems.Item(I_COL_FRS_PRIX_LIST).Tag = Replace(rstPieceFRS.Fields("PRIX_NET").Value, ".", ",")
625: Else
630: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmFRS.SubItems.Item(I_COL_FRS_PRIX_LIST).Tag = Replace(rstPieceFRS.Fields("PRIX_LIST").Value, ".", ",")
635: End If
640: Else
645: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmFRS.SubItems.Item(I_COL_FRS_PRIX_LIST).Tag = Replace(rstPieceFRS.Fields("PRIX_SP").Value, ".", ",")
650: End If
			
655: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmFRS.SubItems(I_COL_FRS_PERS_RESS).Text = "" Then
660: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_PERS_RESS Then
					itmFRS.SubItems(I_COL_FRS_PERS_RESS).Text = " "
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_PERS_RESS, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
				End If
665: End If
			
670: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmFRS.SubItems.Item(I_COL_FRS_PERS_RESS).Tag = sDevise
			
675: Call rstPieceFRS.MoveNext()
680: Loop 
		
		'ferme la table
685: Call rstPieceFRS.Close()
690: 'UPGRADE_NOTE: Object rstPieceFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPieceFRS = Nothing
		
695: If m_bPieceInutile = False Then
700: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwfournisseur.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmFRS = lvwfournisseur.Items.Add()
			
705: itmFRS.Text = "CHOISIR ULTÉRIEUREMENT"
			
710: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmFRS.SubItems.Count > I_COL_FRS_PRIX_LIST Then
				itmFRS.SubItems(I_COL_FRS_PRIX_LIST).Text = " "
			Else
				itmFRS.SubItems.Insert(I_COL_FRS_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
			End If
715: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmFRS.SubItems.Count > I_COL_FRS_ESCOMPTE Then
				itmFRS.SubItems(I_COL_FRS_ESCOMPTE).Text = " "
			Else
				itmFRS.SubItems.Insert(I_COL_FRS_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
			End If
720: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmFRS.SubItems.Count > I_COL_FRS_PRIX_NET Then
				itmFRS.SubItems(I_COL_FRS_PRIX_NET).Text = " "
			Else
				itmFRS.SubItems.Insert(I_COL_FRS_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
			End If
725: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmFRS.SubItems.Count > I_COL_FRS_PRIX_SP Then
				itmFRS.SubItems(I_COL_FRS_PRIX_SP).Text = " "
			Else
				itmFRS.SubItems.Insert(I_COL_FRS_PRIX_SP, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
			End If
730: End If
		
735: Exit Sub
		
AfficherErreur: 
		
740: Call AfficherErreur("frmAchat", "RemplirListViewFournisseur", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewInventaire()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le listview des pièces à commander dans l'inventaire
10: Dim rstInv As ADODB.Recordset
15: Dim itmInv As System.Windows.Forms.ListViewItem
20: Dim lStock As Integer
25: Dim lMinimum As Integer
		
		'Il faut vider le ListView avant de le remplir
30: Call lvwInventaire.Items.Clear()
		
35: rstInv = New ADODB.Recordset
		
40: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
45: Call rstInv.Open("SELECT * FROM GRB_InventaireElec WHERE Minimum = True ORDER BY NoItem", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
50: Else
55: Call rstInv.Open("SELECT * FROM GRB_InventaireMec WHERE Minimum = True ORDER BY NoItem", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
60: End If
		
		'Tant que ce n'est pas la fin des enregistrements
65: Do While Not rstInv.EOF
70: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstInv.Fields("QuantitéStock").Value) Then
75: lStock = CInt(Replace(rstInv.Fields("QuantitéStock").Value, ".", ","))
80: Else
85: lStock = 0
90: End If
			
95: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstInv.Fields("QuantitéMinimum").Value) Then
100: lMinimum = rstInv.Fields("QuantitéMinimum").Value
105: Else
110: lMinimum = 0
115: End If
			
120: If lStock < lMinimum Then
				'On l'ajoute
125: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwInventaire.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmInv = lvwInventaire.Items.Add()
				
				'No piece
130: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstInv.Fields("NoItem").Value) Then
135: itmInv.Text = rstInv.Fields("NoItem").Value
140: Else
145: itmInv.Text = vbNullString
150: End If
				
				'Fabricant
155: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstInv.Fields("Manufacturier").Value) Then
160: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmInv.SubItems.Count > I_COL_INV_MANUFACT Then
						itmInv.SubItems(I_COL_INV_MANUFACT).Text = rstInv.Fields("Manufacturier").Value
					Else
						itmInv.SubItems.Insert(I_COL_INV_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstInv.Fields("Manufacturier").Value))
					End If
165: Else
170: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmInv.SubItems.Count > I_COL_INV_MANUFACT Then
						itmInv.SubItems(I_COL_INV_MANUFACT).Text = vbNullString
					Else
						itmInv.SubItems.Insert(I_COL_INV_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
175: End If
				
				'Description
180: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstInv.Fields("Description").Value) Then
185: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmInv.SubItems.Count > I_COL_INV_DESCR Then
						itmInv.SubItems(I_COL_INV_DESCR).Text = rstInv.Fields("Description").Value
					Else
						itmInv.SubItems.Insert(I_COL_INV_DESCR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstInv.Fields("Description").Value))
					End If
190: Else
195: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmInv.SubItems.Count > I_COL_INV_DESCR Then
						itmInv.SubItems(I_COL_INV_DESCR).Text = vbNullString
					Else
						itmInv.SubItems.Insert(I_COL_INV_DESCR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
200: End If
				
				'Commentaire
205: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstInv.Fields("Commentaires").Value) Then
210: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmInv.SubItems.Count > I_COL_INV_COMMENT Then
						itmInv.SubItems(I_COL_INV_COMMENT).Text = rstInv.Fields("Commentaires").Value
					Else
						itmInv.SubItems.Insert(I_COL_INV_COMMENT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstInv.Fields("Commentaires").Value))
					End If
215: Else
220: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmInv.SubItems.Count > I_COL_INV_COMMENT Then
						itmInv.SubItems(I_COL_INV_COMMENT).Text = ""
					Else
						itmInv.SubItems.Insert(I_COL_INV_COMMENT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
					End If
225: End If
				
				'Quantité en stock
230: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmInv.SubItems.Count > I_COL_INV_QTE_STOCK Then
					itmInv.SubItems(I_COL_INV_QTE_STOCK).Text = CStr(lStock)
				Else
					itmInv.SubItems.Insert(I_COL_INV_QTE_STOCK, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, CStr(lStock)))
				End If
				
				'Quantité minimum
235: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmInv.SubItems.Count > I_COL_INV_QTE_MINIMUM Then
					itmInv.SubItems(I_COL_INV_QTE_MINIMUM).Text = CStr(lMinimum)
				Else
					itmInv.SubItems.Insert(I_COL_INV_QTE_MINIMUM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, CStr(lMinimum)))
				End If
				
				'Quantité à commander
240: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstInv.Fields("Commande").Value) Then
245: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmInv.SubItems.Count > I_COL_INV_QTE_COMMANDE Then
						itmInv.SubItems(I_COL_INV_QTE_COMMANDE).Text = rstInv.Fields("Commande").Value
					Else
						itmInv.SubItems.Insert(I_COL_INV_QTE_COMMANDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstInv.Fields("Commande").Value))
					End If
250: Else
255: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmInv.SubItems.Count > I_COL_INV_QTE_COMMANDE Then
						itmInv.SubItems(I_COL_INV_QTE_COMMANDE).Text = vbNullString
					Else
						itmInv.SubItems.Insert(I_COL_INV_QTE_COMMANDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
260: End If
265: End If
			
270: Call rstInv.MoveNext()
275: Loop 
		
280: Call rstInv.Close()
285: 'UPGRADE_NOTE: Object rstInv may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstInv = Nothing
		
290: Exit Sub
		
AfficherErreur: 
		
295: Call AfficherErreur("frmAchat", "RemplirListViewInventaire", Err, Erl())
	End Sub
	
	
	Private Sub RemplirListViewPieces()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le listview des pièces selon la catégorie de pièce choisit
10: Dim rstPieces As ADODB.Recordset
15: Dim itmPieces As System.Windows.Forms.ListViewItem
20: Dim iIndex As Short
25: Dim bDebut As Boolean
30: Dim sTri As String
35: Dim sOrderBy As String
40: Dim sCategorie As String
		
45: sTri = m_sTri
		
		'Il faut vider le ListView avant de le remplir
50: Call lvwPieces.Items.Clear()
		
55: rstPieces = New ADODB.Recordset
		
60: Select Case cmbTri.SelectedIndex
			Case I_CMB_PIECE_GRB : sOrderBy = "PIECE_GRB"
65: Case I_CMB_PIECE : sOrderBy = "PIECE"
70: Case I_CMB_FABRICANT : sOrderBy = "FABRICANT"
75: Case I_CMB_DESCR_FR : sOrderBy = "DESC_FR"
80: Case I_CMB_DESCR_EN : sOrderBy = "DESC_EN"
85: End Select
		
90: sCategorie = Replace(cmbCategorie.Text, "'", "''")
		
95: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
100: Call rstPieces.Open("SELECT * FROM GRB_CatalogueElec WHERE CATEGORIE = '" & sCategorie & "' ORDER BY " & sOrderBy, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
105: Else
110: Call rstPieces.Open("SELECT * FROM GRB_CatalogueMec WHERE CATEGORIE = '" & sCategorie & "' ORDER BY " & sOrderBy, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
115: End If
		
120: iIndex = 1
		
		'Tant que ce n'est pas la fin des enregistrements
125: Do While Not rstPieces.EOF
130: If rstPieces.Fields("PIECE").Value <> vbNullString And rstPieces.Fields("FABRICANT").Value <> vbNullString Then
				'Si il y a une recherche à faire
135: If sTri <> vbNullString Then
140: bDebut = False
					
					'Selon la colonne
145: Select Case m_iCol
						'Si c'est la colonne PIECE_GRB
						Case I_COL_PIECES_PIECE_GRB
							'Si la PIECE_GRB contient la recherche
150: If InStr(1, UCase(rstPieces.Fields("PIECE_GRB").Value), UCase(sTri)) > 0 Then
								'On met la variable à true pour l'ajouter au début
155: bDebut = True
160: End If
							
							'Si c'est la colonne No. d'item
165: Case I_COL_PIECES_NO_ITEM
							'Si le no. d'item contient la recherche
170: If InStr(1, UCase(rstPieces.Fields("PIECE").Value), UCase(sTri)) > 0 Then
								'On met la variable à true pour l'ajouter au début
175: bDebut = True
180: End If
							
							'Si c'est la colonne Manufacturier
185: Case I_COL_PIECES_MANUFACT
							'Si le manufacturier contient la recherche
190: If InStr(1, UCase(rstPieces.Fields("FABRICANT").Value), UCase(sTri)) > 0 Then
								'On met la variable à true pour l'ajouter au début
195: bDebut = True
200: End If
							
							'Si c'est la colonne No. d'item
205: Case I_COL_PIECES_DESCR_FR
							'Si la description française contient la recherche
210: If InStr(1, UCase(rstPieces.Fields("DESC_FR").Value), UCase(sTri)) > 0 Then
								'On met la variable à true pour l'ajouter au début
215: bDebut = True
220: End If
							
							'Si c'est la colonne No. d'item
225: Case I_COL_PIECES_DESCR_EN
							'Si la description anglaise contient la recherche
230: If InStr(1, UCase(rstPieces.Fields("DESC_EN").Value), UCase(sTri)) > 0 Then
								'On met la variable à true pour l'ajouter au début
235: bDebut = True
240: End If
245: End Select
					
250: If bDebut = True Then
255: 'UPGRADE_WARNING: Lower bound of collection lvwPieces.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						itmPieces = lvwPieces.Items.Insert(iIndex, "")
						
260: iIndex = iIndex + 1
265: Else
270: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPieces.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						itmPieces = lvwPieces.Items.Add()
275: End If
280: Else
285: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPieces.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					itmPieces = lvwPieces.Items.Add()
290: End If
				
				'Piece_GRB
295: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPieces.Fields("PIECE_GRB").Value) Then
300: itmPieces.Text = rstPieces.Fields("PIECE_GRB").Value
305: Else
310: itmPieces.Text = vbNullString
315: End If
				
				'No piece
320: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPieces.Fields("PIECE").Value) Then
325: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_PIECES_NO_ITEM Then
						itmPieces.SubItems(I_COL_PIECES_NO_ITEM).Text = rstPieces.Fields("PIECE").Value
					Else
						itmPieces.SubItems.Insert(I_COL_PIECES_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieces.Fields("PIECE").Value))
					End If
330: Else
335: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_PIECES_NO_ITEM Then
						itmPieces.SubItems(I_COL_PIECES_NO_ITEM).Text = vbNullString
					Else
						itmPieces.SubItems.Insert(I_COL_PIECES_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
340: End If
				
				'Fabricant
345: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPieces.Fields("FABRICANT").Value) Then
350: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_PIECES_MANUFACT Then
						itmPieces.SubItems(I_COL_PIECES_MANUFACT).Text = rstPieces.Fields("FABRICANT").Value
					Else
						itmPieces.SubItems.Insert(I_COL_PIECES_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieces.Fields("FABRICANT").Value))
					End If
355: Else
360: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_PIECES_MANUFACT Then
						itmPieces.SubItems(I_COL_PIECES_MANUFACT).Text = vbNullString
					Else
						itmPieces.SubItems.Insert(I_COL_PIECES_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
365: End If
				
				'Description en francais
370: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPieces.Fields("DESC_FR").Value) Then
375: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_PIECES_DESCR_FR Then
						itmPieces.SubItems(I_COL_PIECES_DESCR_FR).Text = rstPieces.Fields("DESC_FR").Value
					Else
						itmPieces.SubItems.Insert(I_COL_PIECES_DESCR_FR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieces.Fields("DESC_FR").Value))
					End If
380: Else
385: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_PIECES_DESCR_FR Then
						itmPieces.SubItems(I_COL_PIECES_DESCR_FR).Text = vbNullString
					Else
						itmPieces.SubItems.Insert(I_COL_PIECES_DESCR_FR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
390: End If
				
				'Description en anglais
395: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPieces.Fields("DESC_EN").Value) Then
400: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_PIECES_DESCR_EN Then
						itmPieces.SubItems(I_COL_PIECES_DESCR_EN).Text = rstPieces.Fields("DESC_EN").Value
					Else
						itmPieces.SubItems.Insert(I_COL_PIECES_DESCR_EN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieces.Fields("DESC_EN").Value))
					End If
405: Else
410: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_PIECES_DESCR_EN Then
						itmPieces.SubItems(I_COL_PIECES_DESCR_EN).Text = vbNullString
					Else
						itmPieces.SubItems.Insert(I_COL_PIECES_DESCR_EN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
415: End If
420: End If
			
			'Commentaire
425: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieces.Fields("COMMENTAIRE").Value) Then
430: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPieces.SubItems.Count > I_COL_PIECES_COMMENT Then
					itmPieces.SubItems(I_COL_PIECES_COMMENT).Text = rstPieces.Fields("COMMENTAIRE").Value
				Else
					itmPieces.SubItems.Insert(I_COL_PIECES_COMMENT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieces.Fields("COMMENTAIRE").Value))
				End If
435: Else
440: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPieces.SubItems.Count > I_COL_PIECES_COMMENT Then
					itmPieces.SubItems(I_COL_PIECES_COMMENT).Text = ""
				Else
					itmPieces.SubItems.Insert(I_COL_PIECES_COMMENT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
				End If
445: End If
			
450: Call rstPieces.MoveNext()
455: Loop 
		
460: Call rstPieces.Close()
465: 'UPGRADE_NOTE: Object rstPieces may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPieces = Nothing
		
470: Exit Sub
		
AfficherErreur: 
		
475: Call AfficherErreur("frmAchat", "RemplirListViewPieces", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewAchat()
		
5: On Error GoTo AfficherErreur
		
		'Remplis les pièces de l'achat avec la BD
10: Dim rstAchat As ADODB.Recordset
15: Dim rstFRS As ADODB.Recordset
20: Dim itmAchat As System.Windows.Forms.ListViewItem
25: Dim sIDAchat As String
30: Dim iIndexAchat As Short
35: Dim lColor As Integer
40: Dim bBold As Boolean
		
45: Call lvwAchat.Items.Clear()
		
50: sIDAchat = VB.Left(txtNoAchat.Text, 9)
		
55: iIndexAchat = CShort(VB.Right(txtNoAchat.Text, 3))
		
60: rstAchat = New ADODB.Recordset
		
65: Call rstAchat.Open("SELECT * FROM GRB_Achat_Pieces WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat & " ORDER BY NuméroLigne", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
70: Do While Not rstAchat.EOF
75: bBold = False
			
80: If rstAchat.Fields("Retour").Value = True Then
85: lColor = COLOR_ROUGE
90: Else
95: If rstAchat.Fields("Recu").Value = True Then
100: lColor = COLOR_GRIS 'Gris
105: Else
110: If rstAchat.Fields("Inutile").Value = True Then
115: lColor = COLOR_BRUN
120: Else
125: If rstAchat.Fields("IDFRS").Value = 0 Then
130: lColor = COLOR_MAGENTA
135: Else
140: If rstAchat.Fields("Commandé").Value = True Then
145: lColor = COLOR_ORANGE 'COLOR_ORANGE
150: Else
155: If rstAchat.Fields("CommandeAnnulée").Value = True Then
160: lColor = COLOR_VERT_FORET
165: bBold = True
170: Else
175: lColor = COLOR_NOIR
180: End If
185: End If
190: End If
195: End If
200: End If
205: End If
			
210: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwAchat.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmAchat = lvwAchat.Items.Add()
			
			'Quantité
215: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("Qté").Value) Then
220: itmAchat.Text = rstAchat.Fields("Qté").Value
225: Else
230: itmAchat.Text = vbNullString
235: End If
			
240: itmAchat.ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
245: itmAchat.Font = VB6.FontChangeBold(itmAchat.Font, bBold)
			
250: itmAchat.Tag = rstAchat.Fields("DateRéception").Value
			
			'Numéro d'item
255: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("PIECE").Value) Then
260: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_PIECE Then
					itmAchat.SubItems(I_COL_ACHAT_PIECE).Text = rstAchat.Fields("PIECE").Value
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("PIECE").Value))
				End If
265: Else
270: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_PIECE Then
					itmAchat.SubItems(I_COL_ACHAT_PIECE).Text = vbNullString
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
275: End If
			
280: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_PIECE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
285: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_PIECE).Font = VB6.FontChangeBold(itmAchat.SubItems.Item(I_COL_ACHAT_PIECE).Font, bBold)
			
			'Description en francais
290: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("DESC_FR").Value) Then
295: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_DESCR Then
					itmAchat.SubItems(I_COL_ACHAT_DESCR).Text = rstAchat.Fields("DESC_FR").Value
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_DESCR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("DESC_FR").Value))
				End If
300: Else
305: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_DESCR Then
					itmAchat.SubItems(I_COL_ACHAT_DESCR).Text = vbNullString
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_DESCR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
310: End If
			
315: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DESCR).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
320: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DESCR).Font = VB6.FontChangeBold(itmAchat.SubItems.Item(I_COL_ACHAT_DESCR).Font, bBold)
			
			'On met la description en anglais dans le tag de la description en francais
325: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("Desc_EN").Value) Then
330: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_ACHAT_DESCR).Tag = rstAchat.Fields("Desc_EN").Value
335: Else
340: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_ACHAT_DESCR).Tag = vbNullString
345: End If
			
			'Fabricant
350: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("Manufact").Value) Then
355: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_MANUFACT Then
					itmAchat.SubItems(I_COL_ACHAT_MANUFACT).Text = rstAchat.Fields("Manufact").Value
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("Manufact").Value))
				End If
360: Else
365: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_MANUFACT Then
					itmAchat.SubItems(I_COL_ACHAT_MANUFACT).Text = vbNullString
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
370: End If
			
375: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_MANUFACT).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
380: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_MANUFACT).Font = VB6.FontChangeBold(itmAchat.SubItems.Item(I_COL_ACHAT_MANUFACT).Font, bBold)
			
385: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_MANUFACT).Tag = rstAchat.Fields("NoRetour").Value
			
			'Prix listé
390: If Trim(rstAchat.Fields("Prix_List").Value) <> vbNullString Then
395: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
					itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = Conversion_Renamed(rstAchat.Fields("Prix_list"), ModuleMain.enumConvert.MODE_ARGENT, 4)
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(rstAchat.Fields("Prix_list"), ModuleMain.enumConvert.MODE_ARGENT, 4)))
				End If
400: Else
405: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
					itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = " "
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
				End If
410: End If
			
415: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_LIST).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
420: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Font = VB6.FontChangeBold(itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Font, bBold)
			
425: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Tag = rstAchat.Fields("PrixOrigine").Value
			
			'Escompte
430: If Trim(rstAchat.Fields("Escompte").Value) <> vbNullString Then
435: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_ESCOMPTE Then
					itmAchat.SubItems(I_COL_ACHAT_ESCOMPTE).Text = Conversion_Renamed(rstAchat.Fields("Escompte"), ModuleMain.enumConvert.MODE_POURCENT)
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(rstAchat.Fields("Escompte"), ModuleMain.enumConvert.MODE_POURCENT)))
				End If
440: Else
445: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_ESCOMPTE Then
					itmAchat.SubItems(I_COL_ACHAT_ESCOMPTE).Text = " "
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
				End If
450: End If
			
455: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_ESCOMPTE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
460: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_ESCOMPTE).Font = VB6.FontChangeBold(itmAchat.SubItems.Item(I_COL_ACHAT_ESCOMPTE).Font, bBold)
			
			'Prix net
465: If Trim(rstAchat.Fields("Prix_net").Value) <> vbNullString Then
470: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
					itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(rstAchat.Fields("Prix_net"), ModuleMain.enumConvert.MODE_ARGENT, 4)
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(rstAchat.Fields("Prix_net"), ModuleMain.enumConvert.MODE_ARGENT, 4)))
				End If
475: Else
480: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
					itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = " "
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
				End If
485: End If
			
490: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_NET).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
495: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_NET).Font = VB6.FontChangeBold(itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_NET).Font, bBold)
			
			'Fournisseur
500: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("IDFRS").Value) Then
505: If rstAchat.Fields("IDFRS").Value <> 0 Then
510: rstFRS = New ADODB.Recordset
					
515: Call rstFRS.Open("SELECT NomFournisseur FROM GRB_Fournisseur WHERE IDFRS = " & rstAchat.Fields("IDFRS").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
					'On affiche le nom dans la colonne
520: If Not rstFRS.EOF Then
525: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmAchat.SubItems.Count > I_COL_ACHAT_DISTRIB Then
							itmAchat.SubItems(I_COL_ACHAT_DISTRIB).Text = rstFRS.Fields("NomFournisseur").Value
						Else
							itmAchat.SubItems.Insert(I_COL_ACHAT_DISTRIB, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstFRS.Fields("NomFournisseur").Value))
						End If
530: Else
535: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmAchat.SubItems.Count > I_COL_ACHAT_DISTRIB Then
							itmAchat.SubItems(I_COL_ACHAT_DISTRIB).Text = ""
						Else
							itmAchat.SubItems.Insert(I_COL_ACHAT_DISTRIB, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
						End If
540: End If
					
					'On affiche l'Id dans le tag
545: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat.SubItems.Item(I_COL_ACHAT_DISTRIB).Tag = rstAchat.Fields("IDFRS").Value
					
550: Call rstFRS.Close()
555: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstFRS = Nothing
560: Else
565: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_ACHAT_DISTRIB Then
						itmAchat.SubItems(I_COL_ACHAT_DISTRIB).Text = " "
					Else
						itmAchat.SubItems.Insert(I_COL_ACHAT_DISTRIB, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
					End If
570: End If
575: Else
580: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_DISTRIB Then
					itmAchat.SubItems(I_COL_ACHAT_DISTRIB).Text = vbNullString
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_DISTRIB, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
585: End If
			
590: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DISTRIB).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
595: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DISTRIB).Font = VB6.FontChangeBold(itmAchat.SubItems.Item(I_COL_ACHAT_DISTRIB).Font, bBold)
			
			'Prix total
600: If rstAchat.Fields("Prix_total").Value <> vbNullString Then
605: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_TOTAL Then
					itmAchat.SubItems(I_COL_ACHAT_TOTAL).Text = Conversion_Renamed(System.Math.Round(rstAchat.Fields("Prix_total").Value, 2), ModuleMain.enumConvert.MODE_ARGENT)
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_TOTAL, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(System.Math.Round(rstAchat.Fields("Prix_total").Value, 2), ModuleMain.enumConvert.MODE_ARGENT)))
				End If
610: Else
615: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_TOTAL Then
					itmAchat.SubItems(I_COL_ACHAT_TOTAL).Text = " "
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_TOTAL, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
				End If
620: End If
			
625: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_TOTAL).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
630: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_TOTAL).Font = VB6.FontChangeBold(itmAchat.SubItems.Item(I_COL_ACHAT_TOTAL).Font, bBold)
			
635: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_TOTAL).Tag = rstAchat.Fields("Devise").Value
			
			'Date Commande
640: If rstAchat.Fields("DateCommande").Value <> vbNullString Then
645: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_DATE_COMMANDE Then
					itmAchat.SubItems(I_COL_ACHAT_DATE_COMMANDE).Text = rstAchat.Fields("DateCommande").Value
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_DATE_COMMANDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("DateCommande").Value))
				End If
650: Else
655: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_DATE_COMMANDE Then
					itmAchat.SubItems(I_COL_ACHAT_DATE_COMMANDE).Text = ""
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_DATE_COMMANDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
				End If
660: End If
			
665: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DATE_COMMANDE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
670: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DATE_COMMANDE).Font = VB6.FontChangeBold(itmAchat.SubItems.Item(I_COL_ACHAT_DATE_COMMANDE).Font, bBold)
			
			'Date Requise
675: If rstAchat.Fields("DateRequise").Value <> vbNullString Then
680: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_DATE_REQUISE Then
					itmAchat.SubItems(I_COL_ACHAT_DATE_REQUISE).Text = rstAchat.Fields("DateRequise").Value
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_DATE_REQUISE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("DateRequise").Value))
				End If
685: Else
690: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_DATE_REQUISE Then
					itmAchat.SubItems(I_COL_ACHAT_DATE_REQUISE).Text = ""
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_DATE_REQUISE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
				End If
695: End If
			
700: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DATE_REQUISE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
705: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DATE_REQUISE).Font = VB6.FontChangeBold(itmAchat.SubItems.Item(I_COL_ACHAT_DATE_REQUISE).Font, bBold)
			
710: Call rstAchat.MoveNext()
715: Loop 
		
720: Call rstAchat.Close()
725: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAchat = Nothing
		
730: Exit Sub
		
AfficherErreur: 
		
735: Call AfficherErreur("frmAchat", "RemplirListViewAchat", Err, Erl())
	End Sub
	
	Private Sub lvwFournisseur_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwFournisseur.DoubleClick
		
5: On Error GoTo AfficherErreur
		
10: If m_bPieceInutile = True Then
15: Call ChoisirFournisseurMateriel()
20: Else
25: Call ChoisirFournisseur()
30: End If
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmAchat", "lvwFournisseur_DblClick", Err, Erl())
	End Sub
	
	Private Sub ChoisirFournisseur()
		
5: On Error GoTo AfficherErreur
		
		'On ajoute la pièce dans lvwAchat
10: Dim rstConfig As ADODB.Recordset
15: Dim sTauxUSA As String
20: Dim sTauxSPA As String
25: Dim sQuantite As String
30: Dim itmAchat As System.Windows.Forms.ListViewItem
35: Dim lColor As Integer
		
		'Saisie de la quantité
40: sQuantite = InputBox("Quelle est la quantité?",  , m_sQuantite)
		
45: sQuantite = Replace(sQuantite, ".", ",")
		
50: rstConfig = New ADODB.Recordset
		
55: Call rstConfig.Open("SELECT TauxAmericain, TauxEspagnol FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
60: sTauxUSA = rstConfig.Fields("TauxAmericain").Value
65: sTauxSPA = rstConfig.Fields("TauxEspagnol").Value
		
70: Call rstConfig.Close()
75: 'UPGRADE_NOTE: Object rstConfig may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstConfig = Nothing
		
80: If sQuantite <> vbNullString Then
85: If Not IsNumeric(sQuantite) Then
90: Call MsgBox("Quantité non numérique!", MsgBoxStyle.OKOnly, "Erreur")
				
95: Exit Sub
100: End If
105: Else
110: Exit Sub
115: End If
		
120: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwAchat.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		itmAchat = lvwAchat.Items.Add()
		
125: If lvwfournisseur.FocusedItem.Text = "CHOISIR ULTÉRIEUREMENT" Then
130: lColor = COLOR_MAGENTA
135: Else
140: lColor = COLOR_NOIR
145: End If
		
		'Quantité
150: itmAchat.Text = sQuantite
155: itmAchat.ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
		
		'Numéro d'item
160: If m_bRecherchePiece = True Then
165: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwPieceTrouve.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_PIECE Then
				itmAchat.SubItems(I_COL_ACHAT_PIECE).Text = lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_NO_ITEM).Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_NO_ITEM).Text))
			End If
170: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwPieceTrouve.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_DESCR Then
				itmAchat.SubItems(I_COL_ACHAT_DESCR).Text = lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_DESCR_FR).Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_DESCR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_DESCR_FR).Text))
			End If
175: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwPieceTrouve.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_MANUFACT Then
				itmAchat.SubItems(I_COL_ACHAT_MANUFACT).Text = lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_MANUFACT).Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_MANUFACT).Text))
			End If
180: 'UPGRADE_WARNING: Lower bound of collection lvwPieceTrouve.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DESCR).Tag = lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_DESCR_EN).Text
185: Else
190: If m_bInventaire = True Then
195: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_PIECE Then
					itmAchat.SubItems(I_COL_ACHAT_PIECE).Text = lvwInventaire.FocusedItem.Text
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, lvwInventaire.FocusedItem.Text))
				End If
200: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwInventaire.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_DESCR Then
					itmAchat.SubItems(I_COL_ACHAT_DESCR).Text = lvwInventaire.FocusedItem.SubItems(I_COL_INV_DESCR).Text
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_DESCR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, lvwInventaire.FocusedItem.SubItems(I_COL_INV_DESCR).Text))
				End If
205: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwInventaire.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_MANUFACT Then
					itmAchat.SubItems(I_COL_ACHAT_MANUFACT).Text = lvwInventaire.FocusedItem.SubItems(I_COL_INV_MANUFACT).Text
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, lvwInventaire.FocusedItem.SubItems(I_COL_INV_MANUFACT).Text))
				End If
210: Else
215: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwPieces.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_PIECE Then
					itmAchat.SubItems(I_COL_ACHAT_PIECE).Text = lvwPieces.FocusedItem.SubItems(I_COL_PIECES_NO_ITEM).Text
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, lvwPieces.FocusedItem.SubItems(I_COL_PIECES_NO_ITEM).Text))
				End If
220: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwPieces.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_DESCR Then
					itmAchat.SubItems(I_COL_ACHAT_DESCR).Text = lvwPieces.FocusedItem.SubItems(I_COL_PIECES_DESCR_FR).Text
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_DESCR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, lvwPieces.FocusedItem.SubItems(I_COL_PIECES_DESCR_FR).Text))
				End If
225: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwPieces.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_MANUFACT Then
					itmAchat.SubItems(I_COL_ACHAT_MANUFACT).Text = lvwPieces.FocusedItem.SubItems(I_COL_PIECES_MANUFACT).Text
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, lvwPieces.FocusedItem.SubItems(I_COL_PIECES_MANUFACT).Text))
				End If
230: 'UPGRADE_WARNING: Lower bound of collection lvwPieces.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_ACHAT_DESCR).Tag = lvwPieces.FocusedItem.SubItems(I_COL_PIECES_DESCR_EN).Text
235: End If
240: End If
		
245: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAchat.SubItems.Item(I_COL_ACHAT_PIECE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
250: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAchat.SubItems.Item(I_COL_ACHAT_DESCR).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
255: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAchat.SubItems.Item(I_COL_ACHAT_MANUFACT).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
		
		'Prix listé
260: 'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If Trim(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_LIST).Text) <> vbNullString Then
265: 'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwfournisseur.FocusedItem.SubItems.Item(I_COL_FRS_PERS_RESS).Tag = "USA" Then
270: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
					itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_LIST).Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_LIST).Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
				End If
275: Else
280: 'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwfournisseur.FocusedItem.SubItems.Item(I_COL_FRS_PERS_RESS).Tag = "SPA" Then
285: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
						itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_LIST).Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
					Else
						itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_LIST).Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
					End If
290: Else
295: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
						itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = Conversion_Renamed(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_LIST).Text, ModuleMain.enumConvert.MODE_ARGENT, 4)
					Else
						itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_LIST).Text, ModuleMain.enumConvert.MODE_ARGENT, 4)))
					End If
300: End If
305: End If
310: Else
315: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
				itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT, 4)
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT, 4)))
			End If
320: End If
		
325: 'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Tag = lvwfournisseur.FocusedItem.SubItems.Item(I_COL_FRS_PRIX_LIST).Tag
		
330: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_LIST).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
		
335: 'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If Trim(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_NET).Text) <> vbNullString Then
340: 'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If Trim(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_ESCOMPTE).Text) <> vbNullString Then
345: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_ESCOMPTE Then
					itmAchat.SubItems(I_COL_ACHAT_ESCOMPTE).Text = Conversion_Renamed(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_ESCOMPTE).Text, ModuleMain.enumConvert.MODE_POURCENT)
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_ESCOMPTE).Text, ModuleMain.enumConvert.MODE_POURCENT)))
				End If
350: Else
355: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_ESCOMPTE Then
					itmAchat.SubItems(I_COL_ACHAT_ESCOMPTE).Text = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_POURCENT)
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed("0", ModuleMain.enumConvert.MODE_POURCENT)))
				End If
360: End If
			
365: 'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwfournisseur.FocusedItem.SubItems.Item(I_COL_FRS_PERS_RESS).Tag = "USA" Then
370: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
					itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_NET).Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_NET).Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
				End If
375: Else
380: 'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwfournisseur.FocusedItem.SubItems.Item(I_COL_FRS_PERS_RESS).Tag = "SPA" Then
385: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
						itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_NET).Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
					Else
						itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_NET).Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
					End If
390: Else
395: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
						itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_NET).Text, ModuleMain.enumConvert.MODE_ARGENT, 4)
					Else
						itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_NET).Text, ModuleMain.enumConvert.MODE_ARGENT, 4)))
					End If
400: End If
405: End If
410: Else
415: 'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If Trim(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_SP).Text) <> vbNullString Then
420: 'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwfournisseur.FocusedItem.SubItems.Item(I_COL_FRS_PERS_RESS).Tag = "USA" Then
425: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
						itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_SP).Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
					Else
						itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_SP).Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
					End If
430: Else
435: 'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvwfournisseur.FocusedItem.SubItems.Item(I_COL_FRS_PERS_RESS).Tag = "SPA" Then
440: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
							itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_SP).Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
						Else
							itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_SP).Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
						End If
445: Else
450: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
							itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_SP).Text, ModuleMain.enumConvert.MODE_ARGENT, 4)
						Else
							itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_SP).Text, ModuleMain.enumConvert.MODE_ARGENT, 4)))
						End If
455: End If
460: End If
465: Else
470: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_ESCOMPTE Then
					itmAchat.SubItems(I_COL_ACHAT_ESCOMPTE).Text = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_POURCENT)
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed("0", ModuleMain.enumConvert.MODE_POURCENT)))
				End If
475: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
					itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT, 4)
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT, 4)))
				End If
480: End If
485: End If
		
490: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAchat.SubItems.Item(I_COL_ACHAT_ESCOMPTE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
495: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_NET).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
		
500: If lvwfournisseur.FocusedItem.Text = "CHOISIR ULTÉRIEUREMENT" Then
505: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_DISTRIB Then
				itmAchat.SubItems(I_COL_ACHAT_DISTRIB).Text = " "
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_DISTRIB, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
			End If
510: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DISTRIB).Tag = CStr(0)
515: Else
520: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_DISTRIB Then
				itmAchat.SubItems(I_COL_ACHAT_DISTRIB).Text = lvwfournisseur.FocusedItem.Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_DISTRIB, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, lvwfournisseur.FocusedItem.Text))
			End If
525: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DISTRIB).Tag = lvwfournisseur.FocusedItem.Tag
530: End If
		
535: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAchat.SubItems.Item(I_COL_ACHAT_DISTRIB).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
		
		'Prix total
540: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmAchat.SubItems.Count > I_COL_ACHAT_TOTAL Then
			itmAchat.SubItems(I_COL_ACHAT_TOTAL).Text = Conversion_Renamed(System.Math.Round(CDbl(itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text) * CDbl(itmAchat.Text), 2), ModuleMain.enumConvert.MODE_ARGENT)
		Else
			itmAchat.SubItems.Insert(I_COL_ACHAT_TOTAL, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(System.Math.Round(CDbl(itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text) * CDbl(itmAchat.Text), 2), ModuleMain.enumConvert.MODE_ARGENT)))
		End If
545: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmAchat.SubItems.Item(I_COL_ACHAT_TOTAL).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
		
		'Calcul des prix
550: Call CalculerPrix()
		
		'On cache le listview
555: frafournisseur.Visible = False
		
560: Exit Sub
		
AfficherErreur: 
		
565: Call AfficherErreur("frmAchat", "ChoisirFournisseur", Err, Erl())
	End Sub
	
	Private Sub ChoisirFournisseurMateriel()
		
5: On Error GoTo AfficherErreur
		
		'On ajoute la pièce en négatif dans le listview
10: Dim sQuantite As String
15: Dim itmAncien As System.Windows.Forms.ListViewItem
20: Dim itmNouveau As System.Windows.Forms.ListViewItem
		
		'Saisie de la quantité
25: sQuantite = InputBox("Quelle est la quantité?")
		
30: sQuantite = Replace(sQuantite, ".", ",")
		
35: If sQuantite <> vbNullString Then
40: If Not IsNumeric(sQuantite) Then
45: Call MsgBox("Quantité non numérique!", MsgBoxStyle.OKOnly, "Erreur")
				
50: Exit Sub
55: End If
60: Else
65: Exit Sub
70: End If
		
75: If CDbl(sQuantite) <= CDbl(lvwAchat.FocusedItem.Text) Then
80: itmAncien = lvwAchat.FocusedItem
85: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmNouveau = lvwAchat.Items.Insert(itmAncien.Index + 1, "")
			
90: itmNouveau.Checked = itmAncien.Checked
			
95: itmNouveau.Text = "-" & sQuantite
			
			'No d'item
100: 'UPGRADE_WARNING: Lower bound of collection itmNouveau has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAncien has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmNouveau.SubItems.Count > I_COL_ACHAT_PIECE Then
				itmNouveau.SubItems(I_COL_ACHAT_PIECE).Text = itmAncien.SubItems(I_COL_ACHAT_PIECE).Text
			Else
				itmNouveau.SubItems.Insert(I_COL_ACHAT_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAncien.SubItems(I_COL_ACHAT_PIECE).Text))
			End If
			
			'On met la description en francais dans la colonne et la description en anglais
			'dans le tag
105: 'UPGRADE_WARNING: Lower bound of collection itmNouveau has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAncien has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmNouveau.SubItems.Count > I_COL_ACHAT_DESCR Then
				itmNouveau.SubItems(I_COL_ACHAT_DESCR).Text = itmAncien.SubItems(I_COL_ACHAT_DESCR).Text
			Else
				itmNouveau.SubItems.Insert(I_COL_ACHAT_DESCR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAncien.SubItems(I_COL_ACHAT_DESCR).Text))
			End If
110: 'UPGRADE_WARNING: Lower bound of collection itmAncien.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmNouveau.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmNouveau.SubItems.Item(I_COL_ACHAT_DESCR).Tag = itmAncien.SubItems.Item(I_COL_ACHAT_DESCR).Tag
			
			'On met le nom du fabricant dans la colonne et l'ordre de la section dans le tag
115: 'UPGRADE_WARNING: Lower bound of collection itmNouveau has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAncien has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmNouveau.SubItems.Count > I_COL_ACHAT_MANUFACT Then
				itmNouveau.SubItems(I_COL_ACHAT_MANUFACT).Text = itmAncien.SubItems(I_COL_ACHAT_MANUFACT).Text
			Else
				itmNouveau.SubItems.Insert(I_COL_ACHAT_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAncien.SubItems(I_COL_ACHAT_MANUFACT).Text))
			End If
			
			'Prix listé
120: 'UPGRADE_WARNING: Lower bound of collection itmNouveau has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAncien has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmNouveau.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
				itmNouveau.SubItems(I_COL_ACHAT_PRIX_LIST).Text = itmAncien.SubItems(I_COL_ACHAT_PRIX_LIST).Text
			Else
				itmNouveau.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAncien.SubItems(I_COL_ACHAT_PRIX_LIST).Text))
			End If
			
125: 'UPGRADE_WARNING: Lower bound of collection itmAncien.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmNouveau.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmNouveau.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Tag = itmAncien.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Tag
			
130: 'UPGRADE_WARNING: Lower bound of collection itmNouveau has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAncien has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmNouveau.SubItems.Count > I_COL_ACHAT_ESCOMPTE Then
				itmNouveau.SubItems(I_COL_ACHAT_ESCOMPTE).Text = itmAncien.SubItems(I_COL_ACHAT_ESCOMPTE).Text
			Else
				itmNouveau.SubItems.Insert(I_COL_ACHAT_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAncien.SubItems(I_COL_ACHAT_ESCOMPTE).Text))
			End If
			
135: 'UPGRADE_WARNING: Lower bound of collection itmNouveau has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAncien has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmNouveau.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
				itmNouveau.SubItems(I_COL_ACHAT_PRIX_NET).Text = itmAncien.SubItems(I_COL_ACHAT_PRIX_NET).Text
			Else
				itmNouveau.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAncien.SubItems(I_COL_ACHAT_PRIX_NET).Text))
			End If
			
			'On met le fournisseur dans la colonne et l'id dans le tag
140: 'UPGRADE_WARNING: Lower bound of collection itmNouveau has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmNouveau.SubItems.Count > I_COL_ACHAT_DISTRIB Then
				itmNouveau.SubItems(I_COL_ACHAT_DISTRIB).Text = lvwfournisseur.FocusedItem.Text
			Else
				itmNouveau.SubItems.Insert(I_COL_ACHAT_DISTRIB, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, lvwfournisseur.FocusedItem.Text))
			End If
145: 'UPGRADE_WARNING: Lower bound of collection itmNouveau.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmNouveau.SubItems.Item(I_COL_ACHAT_DISTRIB).Tag = lvwfournisseur.FocusedItem.Tag
			
150: 'UPGRADE_WARNING: Lower bound of collection itmNouveau has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmNouveau.SubItems.Count > I_COL_ACHAT_TOTAL Then
				itmNouveau.SubItems(I_COL_ACHAT_TOTAL).Text = Conversion_Renamed(System.Math.Round(CDbl(itmNouveau.Text) * CDbl(itmNouveau.SubItems(I_COL_ACHAT_PRIX_NET).Text), 2), ModuleMain.enumConvert.MODE_ARGENT)
			Else
				itmNouveau.SubItems.Insert(I_COL_ACHAT_TOTAL, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(System.Math.Round(CDbl(itmNouveau.Text) * CDbl(itmNouveau.SubItems(I_COL_ACHAT_PRIX_NET).Text), 2), ModuleMain.enumConvert.MODE_ARGENT)))
			End If
			
155: 'UPGRADE_WARNING: Lower bound of collection itmNouveau has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmNouveau.SubItems.Count > I_COL_ACHAT_DATE_COMMANDE Then
				itmNouveau.SubItems(I_COL_ACHAT_DATE_COMMANDE).Text = " "
			Else
				itmNouveau.SubItems.Insert(I_COL_ACHAT_DATE_COMMANDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
			End If
160: 'UPGRADE_WARNING: Lower bound of collection itmNouveau has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmNouveau.SubItems.Count > I_COL_ACHAT_DATE_REQUISE Then
				itmNouveau.SubItems(I_COL_ACHAT_DATE_REQUISE).Text = " "
			Else
				itmNouveau.SubItems.Insert(I_COL_ACHAT_DATE_REQUISE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
			End If
			
165: itmNouveau.ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_BRUN)
170: 'UPGRADE_WARNING: Lower bound of collection itmNouveau.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmNouveau.SubItems.Item(I_COL_ACHAT_DATE_COMMANDE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_BRUN)
175: 'UPGRADE_WARNING: Lower bound of collection itmNouveau.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmNouveau.SubItems.Item(I_COL_ACHAT_DATE_REQUISE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_BRUN)
180: 'UPGRADE_WARNING: Lower bound of collection itmNouveau.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmNouveau.SubItems.Item(I_COL_ACHAT_DESCR).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_BRUN)
185: 'UPGRADE_WARNING: Lower bound of collection itmNouveau.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmNouveau.SubItems.Item(I_COL_ACHAT_DISTRIB).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_BRUN)
190: 'UPGRADE_WARNING: Lower bound of collection itmNouveau.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmNouveau.SubItems.Item(I_COL_ACHAT_ESCOMPTE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_BRUN)
195: 'UPGRADE_WARNING: Lower bound of collection itmNouveau.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmNouveau.SubItems.Item(I_COL_ACHAT_MANUFACT).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_BRUN)
200: 'UPGRADE_WARNING: Lower bound of collection itmNouveau.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmNouveau.SubItems.Item(I_COL_ACHAT_PIECE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_BRUN)
205: 'UPGRADE_WARNING: Lower bound of collection itmNouveau.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmNouveau.SubItems.Item(I_COL_ACHAT_PRIX_LIST).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_BRUN)
210: 'UPGRADE_WARNING: Lower bound of collection itmNouveau.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmNouveau.SubItems.Item(I_COL_ACHAT_PRIX_NET).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_BRUN)
215: 'UPGRADE_WARNING: Lower bound of collection itmNouveau.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmNouveau.SubItems.Item(I_COL_ACHAT_TOTAL).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_BRUN)
			
			'Calcul des prix
220: Call CalculerPrix()
			
			'On cache le listview
225: frafournisseur.Visible = False
			
230: m_bPieceInutile = False
			
			'Resélectionne le premier élément du listview
235: If lvwAchat.Items.Count > 0 Then
240: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvwAchat.Items.Item(1).Selected = True
245: End If
250: Else
255: Call MsgBox("Quantité trop grande!", MsgBoxStyle.OKOnly, "Erreur")
260: End If
		
265: Exit Sub
		
AfficherErreur: 
		
270: Call AfficherErreur("frmAchat", "ChoisirFournisseurMateriel", Err, Erl())
	End Sub
	
	Private Sub CalculerPrix()
		
5: On Error GoTo AfficherErreur
		
10: Dim dblTotal As Double
15: Dim iCompteur As Short
		
20: If lvwAchat.Items.Count > 0 Then
25: For iCompteur = 1 To lvwAchat.Items.Count
30: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				dblTotal = dblTotal + CDbl(Conversion_Renamed(lvwAchat.Items.Item(iCompteur).SubItems(I_COL_ACHAT_TOTAL).Text, ModuleMain.enumConvert.MODE_PAS_FORMAT))
35: Next 
			
40: txtPrixTotal.Text = Conversion_Renamed(dblTotal, ModuleMain.enumConvert.MODE_ARGENT)
45: Else
50: txtPrixTotal.Text = Conversion_Renamed(0, ModuleMain.enumConvert.MODE_ARGENT)
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmAchat", "CalculerPrix", Err, Erl())
	End Sub
	
	Private Sub lvwFournisseur_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwFournisseur.Leave
		
5: On Error GoTo AfficherErreur
		
		'On cache le Frame contenant le ListView si le ListView perd le focus
10: frafournisseur.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmAchat", "lvwFournisseur_LostFocus", Err, Erl())
	End Sub
	
	Private Sub lvwPieces_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwPieces.DoubleClick
		
5: On Error GoTo AfficherErreur
		
10: m_bInventaire = False
15: m_bRecherchePiece = -CShort(False)
		
		'On affiche lvwFournisseur selon la pièce choisie
		'Rempli les fournisseurs de la pièce choisie
20: Call AfficherListeFournisseurs()
		
		'Si le listview n'est pas vide
25: If lvwfournisseur.Items.Count = 0 Then
30: If MsgBox("Il n'y a aucun fournisseur pour cette pièce!" & vbNewLine & "Voulez-vous en ajouter?", MsgBoxStyle.YesNo, "Erreur") = MsgBoxResult.Yes Then
35: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
				'On ouvre le catalogue sur cet enregistrement
40: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
45: 'UPGRADE_WARNING: Lower bound of collection lvwPieces.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call FrmCatalogueElec.AfficherForm(cmbCategorie.Text, lvwPieces.FocusedItem.SubItems(I_COL_PIECES_MANUFACT).Text, lvwPieces.FocusedItem.SubItems(I_COL_PIECES_NO_ITEM).Text)
50: Else
55: 'UPGRADE_WARNING: Lower bound of collection lvwPieces.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call FrmCatalogueMec.AfficherForm(cmbCategorie.Text, lvwPieces.FocusedItem.SubItems(I_COL_PIECES_MANUFACT).Text, lvwPieces.FocusedItem.SubItems(I_COL_PIECES_NO_ITEM).Text)
60: End If
				
65: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
				
				'On rappelle la méthode
70: Call AfficherListeFournisseurs()
75: End If
80: End If
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("frmAchat", "lvwPieces_DblClick", Err, Erl())
	End Sub
	
	Private Sub lvwInventaire_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwInventaire.DoubleClick
		
5: On Error GoTo AfficherErreur
		
		'On affiche lvwFournisseur selon la pièce choisie
		'Rempli les fournisseurs de la pièce choisie
		
10: m_bInventaire = True
15: m_bRecherchePiece = False
		
20: Call AfficherListeFournisseurs()
		
		'Si le listview n'est pas vide
25: If lvwfournisseur.Items.Count = 1 Then
30: If MsgBox("Il n'y a aucun fournisseur pour cette pièce!" & vbNewLine & "Voulez-vous en ajouter?", MsgBoxStyle.YesNo, "Erreur") = MsgBoxResult.Yes Then
35: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
				'On ouvre le catalogue sur cet enregistrement
40: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
45: 'UPGRADE_WARNING: Lower bound of collection lvwInventaire.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call FrmCatalogueElec.AfficherForm(cmbCategorie.Text, lvwInventaire.FocusedItem.SubItems(I_COL_INV_MANUFACT).Text, lvwInventaire.FocusedItem.SubItems(I_COL_INV_NO_ITEM).Text)
50: Else
55: 'UPGRADE_WARNING: Lower bound of collection lvwInventaire.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call FrmCatalogueMec.AfficherForm(cmbCategorie.Text, lvwInventaire.FocusedItem.SubItems(I_COL_INV_MANUFACT).Text, lvwInventaire.FocusedItem.SubItems(I_COL_INV_NO_ITEM).Text)
60: End If
				
65: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
				
				'On rappelle la méthode
70: Call AfficherListeFournisseurs()
75: End If
80: End If
		
85: fraInventaire.Visible = False
		
90: Exit Sub
		
AfficherErreur: 
		
95: Call AfficherErreur("frmAchat", "lvwInventaire_DblClick", Err, Erl())
	End Sub
	
	Private Sub AfficherListeFournisseurs()
		
5: On Error GoTo AfficherErreur
		
		'Méthode qui sert à afficher la liste des fournisseurs
		'Affiche le frame seulement s'il y a des items dans le ListView
10: Call RemplirListViewFournisseur()
		
15: If m_bInventaire = True Then
20: 'UPGRADE_WARNING: Lower bound of collection lvwInventaire.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			m_sQuantite = lvwInventaire.FocusedItem.SubItems(I_COL_INV_QTE_COMMANDE).Text
25: Else
30: m_sQuantite = vbNullString
35: End If
		
40: If lvwfournisseur.Items.Count > 1 Then
45: If m_bRecherchePiece = True Then
50: fraPieceTrouve.Visible = False
55: End If
			
60: frafournisseur.Visible = True
65: Call lvwfournisseur.Focus()
70: End If
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmAchat", "AfficherListeFournisseurs", Err, Erl())
	End Sub
	
	Private Sub lvwAchat_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lvwAchat.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
		'S'il est en mode ajout ou modif
10: If m_eMode = enumMode.MODE_AJOUT_MODIF Then
			'Si le listView n'est pas vide
15: If lvwAchat.Items.Count > 0 Then
				'Si la touche pesée est Delete
20: If KeyCode = System.Windows.Forms.Keys.Delete Then
					'On l'efface
25: Call lvwAchat.Items.RemoveAt(lvwAchat.FocusedItem.Index)
					
30: Call CalculerPrix()
35: End If
40: End If
45: End If
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmAchat", "lvwAchat_KeyDown", Err, Erl())
	End Sub
	
	Private Sub cmdAnnulerPrix_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnulerPrix.Click
		
5: On Error GoTo AfficherErreur
		
10: fraPrixPiece.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmAchat", "cmdAnnulerPrix_Click", Err, Erl())
	End Sub
	
	Private Sub cmdOKPrix_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOKPrix.Click
		'Écrit les prix dans le listview
5: On Error GoTo AfficherErreur
		
10: Dim rstConfig As ADODB.Recordset
15: Dim itmAchat As System.Windows.Forms.ListViewItem
20: Dim itmAvant As System.Windows.Forms.ListViewItem
25: Dim bPrixSpecial As Boolean
30: Dim lColor As Integer
35: Dim iCompteur As Short
40: Dim sQuantite As String
45: Dim sPiece As String
50: Dim sTauxUSA As String
55: Dim sTauxSPA As String
		
60: rstConfig = New ADODB.Recordset
		
65: Call rstConfig.Open("SELECT TauxAmericain, TauxEspagnol FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
70: sTauxUSA = rstConfig.Fields("TauxAmericain").Value
75: sTauxSPA = rstConfig.Fields("TauxEspagnol").Value
		
80: Call rstConfig.Close()
85: 'UPGRADE_NOTE: Object rstConfig may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstConfig = Nothing
		
90: If m_bMauvaisPrix = False Then
95: If cmbfrs.SelectedIndex = -1 Then
100: Call MsgBox("Vous devez choisir un fournisseur!", MsgBoxStyle.OKOnly, "Erreur")
				
105: Exit Sub
110: End If
115: End If
		
120: If Trim(txtPrixList.Text) = vbNullString Then
125: If Trim(txtPrixSpecial.Text) = vbNullString Then
130: Call MsgBox("Vous devez remplir le prix listé!", MsgBoxStyle.OKOnly, "Erreur")
				
135: Exit Sub
140: End If
145: End If
		
150: If Trim(txtPrixNet.Text) = vbNullString And Trim(txtPrixSpecial.Text) = vbNullString Then
155: Call MsgBox("Vous devez choisir un prix!", MsgBoxStyle.OKOnly, "Erreur")
			
160: Exit Sub
165: Else
170: If Trim(txtPrixNet.Text) <> vbNullString Then
175: bPrixSpecial = False
180: Else
185: bPrixSpecial = True
190: End If
195: End If
		
200: If m_bMauvaisPrix = True Then
205: sQuantite = InputBox("Quelle est la quantité!")
			
210: If sQuantite <> "" Then
215: If Not IsNumeric(sQuantite) Then
220: Exit Sub
225: End If
230: Else
235: Exit Sub
240: End If
			
245: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAvant = lvwAchat.Items.Item(CShort(fraPrixPiece.Tag))
250: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat = lvwAchat.Items.Insert(CShort(fraPrixPiece.Tag) + 1, "")
			
255: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lColor = System.Drawing.ColorTranslator.ToOle(itmAvant.SubItems.Item(I_COL_ACHAT_PIECE).ForeColor)
			
260: itmAchat.Checked = itmAvant.Checked
			
			'Quantité
265: itmAchat.Text = "-" & itmAvant.Text
			
			'No d'item
270: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_PIECE Then
				itmAchat.SubItems(I_COL_ACHAT_PIECE).Text = itmAvant.SubItems(I_COL_ACHAT_PIECE).Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_PIECE).Text))
			End If
			
			'On met la description en francais dans la colonne et la description en anglais
			'dans le tag
275: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_DESCR Then
				itmAchat.SubItems(I_COL_ACHAT_DESCR).Text = itmAvant.SubItems(I_COL_ACHAT_DESCR).Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_DESCR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_DESCR).Text))
			End If
280: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DESCR).Tag = itmAvant.SubItems.Item(I_COL_ACHAT_DESCR).Tag
			
			'On met le nom du fabricant dans la col-nne et l'ordre de la section dans le tag
285: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_MANUFACT Then
				itmAchat.SubItems(I_COL_ACHAT_MANUFACT).Text = itmAvant.SubItems(I_COL_ACHAT_MANUFACT).Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_MANUFACT).Text))
			End If
			
			'Prix listé
290: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
				itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = itmAvant.SubItems(I_COL_ACHAT_PRIX_LIST).Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_PRIX_LIST).Text))
			End If
			
295: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Tag = itmAvant.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Tag
			
300: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_ESCOMPTE Then
				itmAchat.SubItems(I_COL_ACHAT_ESCOMPTE).Text = itmAvant.SubItems(I_COL_ACHAT_ESCOMPTE).Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_ESCOMPTE).Text))
			End If
			
305: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
				itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = itmAvant.SubItems(I_COL_ACHAT_PRIX_NET).Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_PRIX_NET).Text))
			End If
			
			'On met le fournisseur dans la colonne et l'id dans le tag
310: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_DISTRIB Then
				itmAchat.SubItems(I_COL_ACHAT_DISTRIB).Text = itmAvant.SubItems(I_COL_ACHAT_DISTRIB).Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_DISTRIB, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_DISTRIB).Text))
			End If
315: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DISTRIB).Tag = itmAvant.SubItems.Item(I_COL_ACHAT_DISTRIB).Tag
			
			'Pour le prix total, il faut faire la quantité * prix net * pourcentage de profit
320: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_TOTAL Then
				itmAchat.SubItems(I_COL_ACHAT_TOTAL).Text = "-" & itmAvant.SubItems(I_COL_ACHAT_TOTAL).Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_TOTAL, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "-" & itmAvant.SubItems(I_COL_ACHAT_TOTAL).Text))
			End If
			
			'Ajout de l'enregistrement avec le nouveau prix
325: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat = lvwAchat.Items.Insert(CShort(fraPrixPiece.Tag) + 2, "")
			
330: itmAchat.Checked = itmAvant.Checked
			
			'Quantité
335: itmAchat.Text = sQuantite
			
340: itmAchat.ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'No d'item
345: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_PIECE Then
				itmAchat.SubItems(I_COL_ACHAT_PIECE).Text = itmAvant.SubItems(I_COL_ACHAT_PIECE).Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_PIECE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_PIECE).Text))
			End If
			
350: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_PIECE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'On met la description en francais dans la colonne et la description en anglais
			'dans le tag
355: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_DESCR Then
				itmAchat.SubItems(I_COL_ACHAT_DESCR).Text = itmAvant.SubItems(I_COL_ACHAT_DESCR).Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_DESCR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_DESCR).Text))
			End If
360: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DESCR).Tag = itmAvant.SubItems.Item(I_COL_ACHAT_DESCR).Tag
			
365: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DESCR).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'On met le nom du fabricant dans la colonne et l'ordre de la section dans le tag
370: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_MANUFACT Then
				itmAchat.SubItems(I_COL_ACHAT_MANUFACT).Text = itmAvant.SubItems(I_COL_ACHAT_MANUFACT).Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_MANUFACT).Text))
			End If
375: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_MANUFACT).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
380: If bPrixSpecial = False Then
385: If optUSA.Checked = True Then
390: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
						itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixList.Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
					Else
						itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixList.Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
					End If
395: Else
400: If optSpain.Checked = True Then
405: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
							itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixList.Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
						Else
							itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixList.Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
						End If
410: Else
415: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
							itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = Conversion_Renamed(txtPrixList.Text, ModuleMain.enumConvert.MODE_ARGENT, 4)
						Else
							itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(txtPrixList.Text, ModuleMain.enumConvert.MODE_ARGENT, 4)))
						End If
420: End If
425: End If
				
430: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Tag = txtPrixList.Text
				
435: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_LIST).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
				
				'Escompte
440: If mskEscompte.Text <> vbNullString Then
445: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_ACHAT_ESCOMPTE Then
						itmAchat.SubItems(I_COL_ACHAT_ESCOMPTE).Text = Conversion_Renamed(mskEscompte.Text, ModuleMain.enumConvert.MODE_POURCENT)
					Else
						itmAchat.SubItems.Insert(I_COL_ACHAT_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(mskEscompte.Text, ModuleMain.enumConvert.MODE_POURCENT)))
					End If
450: Else
455: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_ACHAT_ESCOMPTE Then
						itmAchat.SubItems(I_COL_ACHAT_ESCOMPTE).Text = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_POURCENT)
					Else
						itmAchat.SubItems.Insert(I_COL_ACHAT_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed("0", ModuleMain.enumConvert.MODE_POURCENT)))
					End If
460: End If
				
465: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_ACHAT_ESCOMPTE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
				
				'Prix net
470: If optUSA.Checked = True Then
475: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
						itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixNet.Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
					Else
						itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixNet.Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
					End If
480: Else
485: If optSpain.Checked = True Then
490: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
							itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixNet.Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
						Else
							itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixNet.Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
						End If
495: Else
500: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
							itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(txtPrixNet.Text, ModuleMain.enumConvert.MODE_ARGENT, 4)
						Else
							itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(txtPrixNet.Text, ModuleMain.enumConvert.MODE_ARGENT, 4)))
						End If
505: End If
510: End If
				
515: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_NET).Tag = itmAvant.SubItems.Item(I_COL_ACHAT_PRIX_NET).Tag
				
520: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_NET).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
525: Else
530: If optUSA.Checked = True Then
535: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
						itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixSpecial.Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
					Else
						itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixSpecial.Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
					End If
540: Else
545: If optSpain.Checked = True Then
550: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
							itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixSpecial.Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
						Else
							itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixSpecial.Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
						End If
555: Else
560: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
							itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = Conversion_Renamed(txtPrixSpecial.Text, ModuleMain.enumConvert.MODE_ARGENT, 4)
						Else
							itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(txtPrixSpecial.Text, ModuleMain.enumConvert.MODE_ARGENT, 4)))
						End If
565: End If
570: End If
				
575: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Tag = txtPrixSpecial.Text
				
580: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_LIST).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
				
585: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_ACHAT_ESCOMPTE Then
					itmAchat.SubItems(I_COL_ACHAT_ESCOMPTE).Text = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_POURCENT)
				Else
					itmAchat.SubItems.Insert(I_COL_ACHAT_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed("0", ModuleMain.enumConvert.MODE_POURCENT)))
				End If
				
590: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_ACHAT_ESCOMPTE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
				
595: If optUSA.Checked = True Then
600: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
						itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixSpecial.Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
					Else
						itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixSpecial.Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
					End If
605: Else
610: If optSpain.Checked = True Then
615: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
							itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixSpecial.Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
						Else
							itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixSpecial.Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
						End If
620: Else
625: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
							itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(txtPrixSpecial.Text, ModuleMain.enumConvert.MODE_ARGENT, 4)
						Else
							itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(txtPrixSpecial.Text, ModuleMain.enumConvert.MODE_ARGENT, 4)))
						End If
630: End If
635: End If
				
640: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_NET).Tag = itmAvant.SubItems.Item(I_COL_ACHAT_PRIX_NET).Tag
				
645: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_NET).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
650: End If
			
			'On met le fournisseur dans la colonne et l'id dans le tag
655: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_DISTRIB Then
				itmAchat.SubItems(I_COL_ACHAT_DISTRIB).Text = itmAvant.SubItems(I_COL_ACHAT_DISTRIB).Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_DISTRIB, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_DISTRIB).Text))
			End If
660: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DISTRIB).Tag = itmAvant.SubItems.Item(I_COL_ACHAT_DISTRIB).Tag
			
665: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DISTRIB).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'Pour le prix total, il faut faire la quantité * prix net * pourcentage de profit
670: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_TOTAL Then
				itmAchat.SubItems(I_COL_ACHAT_TOTAL).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(itmAchat.Text) * CDbl(itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text), 2)), ModuleMain.enumConvert.MODE_ARGENT)
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_TOTAL, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(itmAchat.Text) * CDbl(itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text), 2)), ModuleMain.enumConvert.MODE_ARGENT)))
			End If
			
675: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_TOTAL).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
680: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_DATE_COMMANDE Then
				itmAchat.SubItems(I_COL_ACHAT_DATE_COMMANDE).Text = itmAvant.SubItems(I_COL_ACHAT_DATE_COMMANDE).Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_DATE_COMMANDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_DATE_COMMANDE).Text))
			End If
685: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DATE_COMMANDE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
690: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAchat.SubItems.Count > I_COL_ACHAT_DATE_REQUISE Then
				itmAchat.SubItems(I_COL_ACHAT_DATE_REQUISE).Text = itmAvant.SubItems(I_COL_ACHAT_DATE_REQUISE).Text
			Else
				itmAchat.SubItems.Insert(I_COL_ACHAT_DATE_REQUISE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmAvant.SubItems(I_COL_ACHAT_DATE_REQUISE).Text))
			End If
695: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_ACHAT_DATE_REQUISE).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
700: 'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAvant.SubItems(I_COL_ACHAT_DATE_COMMANDE).Text <> "" Then
705: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAvant.SubItems.Item(I_COL_ACHAT_DATE_COMMANDE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
710: End If
			
715: 'UPGRADE_WARNING: Lower bound of collection itmAvant has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmAvant.SubItems(I_COL_ACHAT_DATE_REQUISE).Text <> "" Then
720: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAvant.SubItems.Item(I_COL_ACHAT_DATE_REQUISE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
725: End If
			
730: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAvant.SubItems.Item(I_COL_ACHAT_DESCR).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
735: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAvant.SubItems.Item(I_COL_ACHAT_DISTRIB).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
740: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAvant.SubItems.Item(I_COL_ACHAT_ESCOMPTE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
745: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAvant.SubItems.Item(I_COL_ACHAT_MANUFACT).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
750: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAvant.SubItems.Item(I_COL_ACHAT_PIECE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
755: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAvant.SubItems.Item(I_COL_ACHAT_PRIX_LIST).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
760: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAvant.SubItems.Item(I_COL_ACHAT_PRIX_NET).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
765: itmAvant.ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
770: 'UPGRADE_WARNING: Lower bound of collection itmAvant.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAvant.SubItems.Item(I_COL_ACHAT_TOTAL).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
			
			'Resélectionne le premier élément du listview
775: If lvwAchat.Items.Count > 0 Then
780: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lvwAchat.Items.Item(1).Selected = True
785: End If
			
790: m_bMauvaisPrix = False
			
795: 'UPGRADE_ISSUE: ComboBox property cmbfrs.Locked was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			cmbfrs.Locked = False
800: Else
805: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			sPiece = lvwAchat.Items.Item(CShort(fraPrixPiece.Tag)).SubItems(I_COL_ACHAT_PIECE).Text
			
810: For iCompteur = 1 To lvwAchat.Items.Count
815: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwAchat.Items.Item(iCompteur).SubItems(I_COL_ACHAT_PIECE).Text = sPiece And System.Drawing.ColorTranslator.ToOle(lvwAchat.Items.Item(iCompteur).SubItems.Item(I_COL_ACHAT_PIECE).ForeColor) = COLOR_MAGENTA Then
820: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat = lvwAchat.Items.Item(iCompteur)
					
825: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat.SubItems.Item(I_COL_ACHAT_PIECE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
830: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat.SubItems.Item(I_COL_ACHAT_DESCR).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
835: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat.SubItems.Item(I_COL_ACHAT_DISTRIB).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
840: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat.SubItems.Item(I_COL_ACHAT_ESCOMPTE).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
845: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat.SubItems.Item(I_COL_ACHAT_MANUFACT).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
850: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_LIST).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
855: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_NET).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
860: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat.SubItems.Item(I_COL_ACHAT_TOTAL).ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
865: itmAchat.ForeColor = System.Drawing.ColorTranslator.FromOle(COLOR_NOIR)
					
870: Call lvwAchat.Refresh()
					
875: If bPrixSpecial = False Then
						'Prix listé
880: If optUSA.Checked = True Then
885: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
								itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixList.Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
							Else
								itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixList.Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
							End If
890: Else
895: If optSpain.Checked = True Then
900: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
									itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixList.Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
								Else
									itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixList.Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
								End If
905: Else
910: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
									itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = Conversion_Renamed(txtPrixList.Text, ModuleMain.enumConvert.MODE_ARGENT, 4)
								Else
									itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(txtPrixList.Text, ModuleMain.enumConvert.MODE_ARGENT, 4)))
								End If
915: End If
920: End If
						
925: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Tag = txtPrixList.Text
						
						'Escompte
930: If mskEscompte.Text <> vbNullString Then
935: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If itmAchat.SubItems.Count > I_COL_ACHAT_ESCOMPTE Then
								itmAchat.SubItems(I_COL_ACHAT_ESCOMPTE).Text = Conversion_Renamed(mskEscompte.Text, ModuleMain.enumConvert.MODE_POURCENT)
							Else
								itmAchat.SubItems.Insert(I_COL_ACHAT_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(mskEscompte.Text, ModuleMain.enumConvert.MODE_POURCENT)))
							End If
940: Else
945: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If itmAchat.SubItems.Count > I_COL_ACHAT_ESCOMPTE Then
								itmAchat.SubItems(I_COL_ACHAT_ESCOMPTE).Text = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_POURCENT)
							Else
								itmAchat.SubItems.Insert(I_COL_ACHAT_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed("0", ModuleMain.enumConvert.MODE_POURCENT)))
							End If
950: End If
						
						'Prix net
955: If optUSA.Checked = True Then
960: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
								itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixNet.Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
							Else
								itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixNet.Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
							End If
965: Else
970: If optSpain.Checked = True Then
975: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
									itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixNet.Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
								Else
									itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixNet.Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
								End If
980: Else
985: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
									itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(txtPrixNet.Text, ModuleMain.enumConvert.MODE_ARGENT, 4)
								Else
									itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(txtPrixNet.Text, ModuleMain.enumConvert.MODE_ARGENT, 4)))
								End If
990: End If
995: End If
1000: Else
1005: If optUSA.Checked = True Then
1010: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
								itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixSpecial.Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
							Else
								itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixSpecial.Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
							End If
1015: Else
1020: If optSpain.Checked = True Then
1025: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
									itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixSpecial.Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
								Else
									itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixSpecial.Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
								End If
1030: Else
1035: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_LIST Then
									itmAchat.SubItems(I_COL_ACHAT_PRIX_LIST).Text = Conversion_Renamed(txtPrixSpecial.Text, ModuleMain.enumConvert.MODE_ARGENT, 4)
								Else
									itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(txtPrixSpecial.Text, ModuleMain.enumConvert.MODE_ARGENT, 4)))
								End If
1040: End If
1045: End If
						
1050: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						itmAchat.SubItems.Item(I_COL_ACHAT_PRIX_LIST).Tag = txtPrixSpecial.Text
						
1055: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmAchat.SubItems.Count > I_COL_ACHAT_ESCOMPTE Then
							itmAchat.SubItems(I_COL_ACHAT_ESCOMPTE).Text = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_POURCENT)
						Else
							itmAchat.SubItems.Insert(I_COL_ACHAT_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed("0", ModuleMain.enumConvert.MODE_POURCENT)))
						End If
						
1060: If optUSA.Checked = True Then
1065: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
								itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixSpecial.Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
							Else
								itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixSpecial.Text) / CDbl(sTauxUSA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
							End If
1070: Else
1075: If optSpain.Checked = True Then
1080: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
									itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixSpecial.Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
								Else
									itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(txtPrixSpecial.Text) / CDbl(sTauxSPA), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
								End If
1085: Else
1090: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								If itmAchat.SubItems.Count > I_COL_ACHAT_PRIX_NET Then
									itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text = Conversion_Renamed(txtPrixSpecial.Text, ModuleMain.enumConvert.MODE_ARGENT, 4)
								Else
									itmAchat.SubItems.Insert(I_COL_ACHAT_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(txtPrixSpecial.Text, ModuleMain.enumConvert.MODE_ARGENT, 4)))
								End If
1095: End If
1100: End If
1105: End If
					
					'On met le fournisseur dans la colonne et l'id dans le tag
1110: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_ACHAT_DISTRIB Then
						itmAchat.SubItems(I_COL_ACHAT_DISTRIB).Text = VB6.GetItemString(cmbfrs, cmbfrs.SelectedIndex)
					Else
						itmAchat.SubItems.Insert(I_COL_ACHAT_DISTRIB, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, VB6.GetItemString(cmbfrs, cmbfrs.SelectedIndex)))
					End If
					
1115: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat.SubItems.Item(I_COL_ACHAT_DISTRIB).Tag = CStr(VB6.GetItemData(cmbfrs, cmbfrs.SelectedIndex))
					
					'Pour le prix total, il faut faire la quantité * prix net * pourcentage de profit
1120: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_ACHAT_TOTAL Then
						itmAchat.SubItems(I_COL_ACHAT_TOTAL).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(Replace(itmAchat.Text, "*", "")) * CDbl(itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text), 2)), ModuleMain.enumConvert.MODE_ARGENT)
					Else
						itmAchat.SubItems.Insert(I_COL_ACHAT_TOTAL, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(Replace(itmAchat.Text, "*", "")) * CDbl(itmAchat.SubItems(I_COL_ACHAT_PRIX_NET).Text), 2)), ModuleMain.enumConvert.MODE_ARGENT)))
					End If
					
1125: If optUSA.Checked = True Then
1130: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						itmAchat.SubItems.Item(I_COL_ACHAT_TOTAL).Tag = "USA"
1135: Else
1140: If optSpain.Checked = True Then
1145: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							itmAchat.SubItems.Item(I_COL_ACHAT_TOTAL).Tag = "SPA"
1150: Else
1155: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							itmAchat.SubItems.Item(I_COL_ACHAT_TOTAL).Tag = "CAN"
1160: End If
1165: End If
					
1170: End If
1175: Next 
1180: End If
		
1185: Call ModifierPrixCatalogue()
		
1190: fraPrixPiece.Visible = False
		
1195: Call CalculerPrix()
		
1200: Exit Sub
		
AfficherErreur: 
		
1205: Call AfficherErreur("frmAchat", "cmdOKPrix_Click", Err, Erl())
	End Sub
	
	Private Sub RemplirComboFournisseur()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstFRS As ADODB.Recordset
		
		'Il faut vider le combo avant de le remplir
15: Call cmbfrs.Items.Clear()
		
20: rstFRS = New ADODB.Recordset
		
25: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		Call rstFRS.Open("SELECT GRB_PiecesFRS.*, GRB_Fournisseur.NomFournisseur FROM GRB_PiecesFRS INNER JOIN GRB_Fournisseur ON GRB_PiecesFRS.IDFRS = GRB_Fournisseur.IDFRS WHERE PIECE = '" & Replace(lvwAchat.FocusedItem.SubItems(I_COL_ACHAT_PIECE).Text, "'", "''") & "' ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
30: Do While Not rstFRS.EOF
35: Call cmbfrs.Items.Add(rstFRS.Fields("NomFournisseur").Value)
			
40: 'UPGRADE_ISSUE: ComboBox property cmbfrs.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbfrs, cmbfrs.NewIndex, rstFRS.Fields("IDFRS").Value)
			
45: Call rstFRS.MoveNext()
50: Loop 
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmAchat", "RemplirComboFournisseur", Err, Erl())
	End Sub
	
	Public Sub mnuDateRequise_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDateRequise.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If Trim(lvwAchat.FocusedItem.SubItems(I_COL_ACHAT_DATE_REQUISE).Text) = "" Then
15: mvwDateRequise.Year = Year(Today)
20: mvwDateRequise.Month = Month(Today)
25: mvwDateRequise.Day = VB.Day(Today)
30: Else
35: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			mvwDateRequise.Year = CShort(VB.Left(lvwAchat.FocusedItem.SubItems(I_COL_ACHAT_DATE_REQUISE).Text, 4))
40: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			mvwDateRequise.Month = CShort(Mid(lvwAchat.FocusedItem.SubItems(I_COL_ACHAT_DATE_REQUISE).Text, 6, 2))
45: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			mvwDateRequise.Day = CShort(VB.Right(lvwAchat.FocusedItem.SubItems(I_COL_ACHAT_DATE_REQUISE).Text, 2))
50: End If
		
55: fraDateRequise.Top = lvwAchat.Top
		
60: fraDateRequise.Visible = True
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("frmAchat", "mnuDateRequise_Click", Err, Erl())
	End Sub
	
	Private Sub mvwDateRequise_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mvwDateRequise.Enter
		
5: On Error GoTo AfficherErreur
		
10: m_bMonthViewHasFocus = True
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmAchat", "mvwDateRequise_GotFocus", Err, Erl())
	End Sub
	
	Private Sub txtPrixList_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrixList.Leave
		
5: On Error GoTo AfficherErreur
		
10: If txtPrixList.Text <> vbNullString Then
15: txtPrixList.Text = Replace(txtPrixList.Text, ".", ",")
			
20: If IsNumeric(txtPrixList.Text) Then
25: Call CalculerPrixNet()
30: Else
35: Call MsgBox("Valeur non numérique!", MsgBoxStyle.OKOnly, "Erreur")
40: txtPrixList.Text = vbNullString
45: End If
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmAchat", "txtPrixList_LostFocus", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtPrixNet.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtPrixNet_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrixNet.TextChanged
		
5: On Error GoTo AfficherErreur
		
		'Quand le contenu du prix net change
		
		'Si la longueur du texte écrit est plus grand que 0
10: If Len(txtPrixNet.Text) > 0 Then
			'On vide le prix spécial et on le désactive
15: txtPrixSpecial.Text = vbNullString
20: txtPrixSpecial.Enabled = False
25: Else
			'Sinon, on active le prix spécial
30: txtPrixSpecial.Enabled = True
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmAchat", "txtPrixNet_Change", Err, Erl())
	End Sub
	
	Private Sub txtPrixNet_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrixNet.Enter
		
5: On Error GoTo AfficherErreur
		
		'Si le prix net prend le focus
10: Call CalculerPrixNet()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmAchat", "txtPrixNet_GotFocus", Err, Erl())
	End Sub
	
	Private Sub CalculerPrixNet()
		
5: On Error GoTo AfficherErreur
		
10: Dim dblEscompte As Double
15: Dim dblPrix As Double
		
		'Si le prix net n'est pas barré.. ie.. si le prix spécial est vide
20: If txtPrixNet.ReadOnly = False Then
25: mskEscompte.Text = Replace(mskEscompte.Text, "_", vbNullString)
			
30: mskEscompte.Text = Replace(mskEscompte.Text, ".", ",")
			
35: If mskEscompte.Text <> vbNullString Then
40: dblEscompte = CDbl(mskEscompte.Text)
45: Else
50: dblEscompte = 0
55: End If
			
60: If txtPrixList.Text <> vbNullString Then
65: dblPrix = CDbl(Replace(txtPrixList.Text, ".", ","))
70: Else
75: dblPrix = 0
80: End If
			
			'Calcul du prix net
85: txtPrixNet.Text = CStr(System.Math.Round((dblPrix) * (1 - dblEscompte), 4))
			
90: txtPrixNet.Text = Replace(txtPrixNet.Text, ".", ",")
95: End If
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmAchat", "CalculerPrixNet", Err, Erl())
	End Sub
	
	Private Sub txtPrixNet_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrixNet.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtPrixNet.Text = Replace(txtPrixNet.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmAchat", "txtPrixNet_LostFocus", Err, Erl())
	End Sub
	
	Private Sub ViderChamps_frs()
		
5: On Error GoTo AfficherErreur
		
		'Vide les champs pieces
10: txtPrixList.Text = vbNullString
15: mskEscompte.Text = vbNullString
20: txtPrixNet.Text = vbNullString
		
25: optCAN.Checked = True
		
30: Call AfficherDrapeau()
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmAchat", "ViderChamps_frs", Err, Erl())
	End Sub
	
	Private Sub ModifierPrixCatalogue()
		'Enregistrement du prix de la pièce
5: On Error GoTo AfficherErreur
		
10: Dim rstPrix As ADODB.Recordset
15: Dim dblPrixList As Double
20: Dim dblEscompte As Double
25: Dim dblPrixNet As Double
		
30: If Trim(txtPrixList.Text) <> "" Then
35: dblPrixList = CDbl(txtPrixList.Text)
40: Else
45: dblPrixList = 0
50: End If
		
55: If mskEscompte.Text <> vbNullString Then
60: dblEscompte = CDbl(mskEscompte.Text)
65: Else
70: dblEscompte = 0
75: End If
		
80: If Trim(txtPrixNet.Text) <> "" Then
85: dblPrixNet = CDbl(txtPrixNet.Text)
90: Else
95: dblPrixNet = CDbl(txtPrixSpecial.Text)
100: End If
		
105: rstPrix = New ADODB.Recordset
		
		'Ouverture du recordset
110: 'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_WARNING: Lower bound of collection lvwAchat.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		Call rstPrix.Open("SELECT * FROM GRB_PiecesFRS WHERE PIECE = '" & Replace(lvwAchat.Items.Item(CShort(fraPrixPiece.Tag)).SubItems(I_COL_ACHAT_PIECE).Text, "'", "''") & "' AND IDFRS = " & VB6.GetItemData(cmbfrs, cmbfrs.SelectedIndex), g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
115: rstPrix.Fields("PRIX_LIST").Value = dblPrixList
120: rstPrix.Fields("ESCOMPTE").Value = dblEscompte
125: rstPrix.Fields("PRIX_NET").Value = dblPrixNet
130: rstPrix.Fields("DATE").Value = ConvertDate(Today)
135: rstPrix.Fields("ENTRER_PAR").Value = g_sInitiale
		
140: If optCAN.Checked = True Then
145: rstPrix.Fields("DeviseMonétaire").Value = "CAN"
150: Else
155: If optUSA.Checked = True Then
160: rstPrix.Fields("DeviseMonétaire").Value = "USA"
165: Else
170: rstPrix.Fields("DeviseMonétaire").Value = "SPA"
175: End If
180: End If
		
185: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
190: rstPrix.Fields("Type").Value = "E"
195: Else
200: rstPrix.Fields("Type").Value = "M"
205: End If
		
210: Call rstPrix.Update()
		
215: Call rstPrix.Close()
220: 'UPGRADE_NOTE: Object rstPrix may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPrix = Nothing
		
225: Exit Sub
		
AfficherErreur: 
		
230: Call AfficherErreur("frmAchat", "ModifierPrixCatalogue", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event optCAN.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optCAN_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optCAN.CheckedChanged
		If eventSender.Checked Then
			
5: On Error GoTo AfficherErreur
			
			'Dépendant la devise, affiche le drapeau
10: Call AfficherDrapeau()
			
15: Exit Sub
			
AfficherErreur: 
			
20: Call AfficherErreur("frmAchat", "optCAN_Click", Err, Erl())
		End If
	End Sub
	
	Private Sub AfficherDrapeau()
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''''''''''
		'dependant la devise, affiche le drapeau
		'''''''''''''''''''''''''''''''''''''
10: If optCAN.Checked = True Then
15: imgCanada.Visible = True
20: imgEU.Visible = False
25: imgSpain.Visible = False
30: Else
35: If optUSA.Checked = True Then
40: imgEU.Visible = True
45: imgCanada.Visible = False
50: imgSpain.Visible = False
55: Else
60: imgSpain.Visible = True
65: imgCanada.Visible = False
70: imgEU.Visible = False
75: End If
80: End If
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("frmAchat", "AfficherDrapeau", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event optSpain.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optSpain_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optSpain.CheckedChanged
		If eventSender.Checked Then
			
5: On Error GoTo AfficherErreur
			
			'dependant la devise, affiche le drapeau
10: Call AfficherDrapeau()
			
15: Exit Sub
			
AfficherErreur: 
			
20: Call AfficherErreur("frmAchat", "optSpain_Click", Err, Erl())
		End If
	End Sub
	
	'UPGRADE_WARNING: Event optUSA.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optUSA_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optUSA.CheckedChanged
		If eventSender.Checked Then
			
5: On Error GoTo AfficherErreur
			
			'dependant la devise, affiche le drapeau
10: Call AfficherDrapeau()
			
15: Exit Sub
			
AfficherErreur: 
			
20: Call AfficherErreur("frmAchat", "optUSA_Click", Err, Erl())
		End If
	End Sub
	
	Private Sub mskEscompte_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskEscompte.Enter
		
5: On Error GoTo AfficherErreur
		
		'Quand le maskEdit prend le focus, on set le masque
10: If mskEscompte.Enabled = True Then
15: mskEscompte.Mask = "0,####"
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmAchat", "mskEscompte_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskEscompte_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskEscompte.Leave
		
5: On Error GoTo AfficherErreur
		
		'Quand le maskEdit perd le focus, on enlève le mask
10: mskEscompte.Mask = vbNullString
		
		'Si le champs contient 0,____, c'est parce que rien n'a été entré
15: If mskEscompte.Text = "0,____" Then
			'Donc, on le vide
20: mskEscompte.Text = vbNullString
25: End If
		
30: Call CalculerPrixNet()
		
35: Exit Sub
		
AfficherErreur: 
		
40: Call AfficherErreur("frmAchat", "mskEscompte_LostFocus", Err, Erl())
	End Sub
	
	Public Sub Commande()
		Dim DR_Commande As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPiece As ADODB.Recordset
15: Dim rstBCPiece As ADODB.Recordset
20: Dim rstBC As ADODB.Recordset
25: Dim rstFRS As ADODB.Recordset
30: Dim iIDFRS As Short
35: Dim sFRS As String
40: Dim sNoBC As String
45: Dim sWhere As String
50: Dim sWherePiece As String
55: Dim sWhereNoLigne As String
60: Dim sDateRequise As String
65: Dim sNoLigne As String
70: Dim bPremier As Boolean
75: Dim bPremierNoLigne As Boolean
		
80: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sFRS = DR_Commande.Sections("Section2").Controls("lblFournisseur").Caption
85: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Commande.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sNoBC = DR_Commande.Sections("Section2").Controls("lblNoBC").Caption
		
90: rstBC = New ADODB.Recordset
95: rstFRS = New ADODB.Recordset
100: rstPiece = New ADODB.Recordset
105: rstBCPiece = New ADODB.Recordset
		
110: Call rstBC.Open("SELECT * FROM GRB_BonsCommandes WHERE NoBonCommande = '" & sNoBC & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
115: Do While Not rstBC.EOF
120: Call rstFRS.Open("SELECT IDFRS, NomFournisseur FROM GRB_Fournisseur WHERE IDFRS = " & rstBC.Fields("NoFournisseur").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
125: If rstFRS.Fields("NomFournisseur").Value = sFRS Then
130: iIDFRS = rstFRS.Fields("IDFRS").Value
				
135: sDateRequise = rstBC.Fields("DateRequise").Value
				
140: Call rstFRS.Close()
				
145: Exit Do
150: End If
			
155: Call rstFRS.Close()
			
160: Call rstBC.MoveNext()
165: Loop 
		
170: Call rstBC.Close()
175: 'UPGRADE_NOTE: Object rstBC may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBC = Nothing
		
180: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
		
		'Ouverture du recordset du Bon de commande pour savoir quelles pièces
		'ont été commandées
185: Call rstBCPiece.Open("SELECT NoItem, NuméroLigne FROM GRB_BonsCommandes_Pieces WHERE NoFournisseur = " & iIDFRS & " AND NoBonCommande = '" & sNoBC & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
190: sWhere = "(IDAchat = '" & VB.Left(txtNoAchat.Text, 9) & "' AND IndexAchat = " & Int(CDbl(VB.Right(txtNoAchat.Text, 3))) & ")"
		
195: sWherePiece = "PIECE In ("
200: sWhereNoLigne = "NuméroLigne In ("
		
205: bPremier = True
		
210: Do While Not rstBCPiece.EOF
215: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstBCPiece.Fields("NoItem").Value) Then
220: sNoLigne = rstBCPiece.Fields("NuméroLigne").Value
				
225: If bPremier = True Then
230: If InStr(1, sNoLigne, ",") = 0 Then
235: sWherePiece = sWherePiece & "'" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
240: sWhereNoLigne = sWhereNoLigne & rstBCPiece.Fields("NuméroLigne").Value
245: Else
250: bPremierNoLigne = True
						
255: Do While InStr(1, sNoLigne, ",") > 0
260: If bPremierNoLigne = True Then
265: sWherePiece = sWherePiece & "'" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
270: sWhereNoLigne = sWhereNoLigne & VB.Left(sNoLigne, InStr(1, sNoLigne, ",") - 1)
								
275: bPremierNoLigne = False
280: Else
285: sWherePiece = sWherePiece & ", '" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
290: sWhereNoLigne = sWhereNoLigne & ", " & VB.Left(sNoLigne, InStr(1, sNoLigne, ",") - 1)
295: End If
							
300: sNoLigne = VB.Right(sNoLigne, Len(sNoLigne) - (InStr(1, sNoLigne, ",") + 1))
305: Loop 
						
310: If Trim(sNoLigne) <> "" Then
315: sWherePiece = sWherePiece & ", '" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
320: sWhereNoLigne = sWhereNoLigne & ", " & sNoLigne
325: End If
330: End If
					
335: bPremier = False
340: Else
345: If InStr(1, sNoLigne, ",") = 0 Then
350: sWherePiece = sWherePiece & ", '" & rstBCPiece.Fields("NoItem").Value & "'"
355: sWhereNoLigne = sWhereNoLigne & ", " & rstBCPiece.Fields("NuméroLigne").Value
360: Else
365: Do While InStr(1, sNoLigne, ",") > 0
370: sWherePiece = sWherePiece & ", '" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
375: sWhereNoLigne = sWhereNoLigne & ", " & VB.Left(sNoLigne, InStr(1, sNoLigne, ",") - 1)
							
380: sNoLigne = VB.Right(sNoLigne, Len(sNoLigne) - (InStr(1, sNoLigne, ",") + 1))
385: Loop 
						
390: If Trim(sNoLigne) <> "" Then
395: sWherePiece = sWherePiece & ", '" & Replace(rstBCPiece.Fields("NoItem").Value, "'", "''") & "'"
400: sWhereNoLigne = sWhereNoLigne & ", " & sNoLigne
405: End If
410: End If
415: End If
420: End If
			
425: Call rstBCPiece.MoveNext()
430: Loop 
		
435: sWherePiece = sWherePiece & ")"
440: sWhereNoLigne = sWhereNoLigne & ")"
		
445: sWhere = sWhere & " AND " & sWherePiece & " AND " & sWhereNoLigne
		
450: Call rstBCPiece.Close()
455: 'UPGRADE_NOTE: Object rstBCPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstBCPiece = Nothing
		
460: Call rstPiece.Open("SELECT * FROM GRB_Achat_Pieces WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
465: Do While Not rstPiece.EOF
470: rstPiece.Fields("Commandé").Value = True
			
475: rstPiece.Fields("DateCommande").Value = ConvertDate(Today)
			
480: rstPiece.Fields("DateRequise").Value = sDateRequise
			
485: Call rstPiece.Update()
			
490: Call rstPiece.MoveNext()
495: Loop 
		
500: Call rstPiece.Close()
505: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
510: Call RemplirListViewAchat()
		
515: Exit Sub
		
AfficherErreur: 
		
520: Call AfficherErreur("frmAchat", "Commande", Err, Erl())
	End Sub
	
	Private Sub cmdRetour_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRetour.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim sIDAchat As String
15: Dim iIndexAchat As Short
20: Dim rstAchat As ADODB.Recordset
		
25: If cmbNoAchat.Items.Count > 0 Then
30: sIDAchat = Trim(VB.Left(txtNoAchat.Text, InStr(1, txtNoAchat.Text, "-") + 2))
35: iIndexAchat = CShort(Trim(VB.Right(txtNoAchat.Text, Len(txtNoAchat.Text) - InStrRev(txtNoAchat.Text, "-"))))
			
40: rstAchat = New ADODB.Recordset
			
45: Call rstAchat.Open("SELECT Modification, Par FROM GRB_Achat WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
50: If rstAchat.Fields("Modification").Value = False Then
55: Call rstAchat.Close()
60: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstAchat = Nothing
				
65: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
70: iIndexAchat = CShort(VB.Right(txtNoAchat.Text, 3))
				
75: Call frmRetourMarchandise.AfficherAchat(sIDAchat, iIndexAchat, g_sUserID)
				
80: Call cmbNoAchat_SelectedIndexChanged(cmbNoAchat, New System.EventArgs())
				
85: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
90: Else
95: Call MsgBox("Cet achat est en modification par " & rstAchat.Fields("Par").Value & "!", MsgBoxStyle.OKOnly, "Erreur")
				
100: Call rstAchat.Close()
105: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstAchat = Nothing
110: End If
115: End If
		
120: Exit Sub
		
AfficherErreur: 
		
125: Call AfficherErreur("frmAchat", "cmdRetour_Click", Err, Erl())
	End Sub
	
	Private Sub OuvrirAchat(ByVal bOuvrir As Boolean)
		'Remplit ou vide les champs Modification et Par
5: On Error GoTo AfficherErreur
		
10: Dim rstAchat As ADODB.Recordset
15: Dim sIDAchat As String
20: Dim iIndexAchat As Short
		
25: sIDAchat = Trim(VB.Left(txtNoAchat.Text, InStr(1, txtNoAchat.Text, "-") + 2))
30: iIndexAchat = CShort(Trim(VB.Right(txtNoAchat.Text, Len(txtNoAchat.Text) - InStrRev(txtNoAchat.Text, "-"))))
		
35: rstAchat = New ADODB.Recordset
		
40: rstAchat.CursorLocation = ADODB.CursorLocationEnum.adUseServer
		
45: Call rstAchat.Open("SELECT Modification, Par FROM GRB_Achat WHERE IDAchat = '" & sIDAchat & "' AND IndexAchat = " & iIndexAchat, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
50: Do While Not rstAchat.EOF
55: If bOuvrir = True Then
60: rstAchat.Fields("Modification").Value = True
65: rstAchat.Fields("Par").Value = g_sEmploye
70: Else
75: rstAchat.Fields("Modification").Value = False
80: rstAchat.Fields("Par").Value = ""
85: End If
			
90: Call rstAchat.Update()
			
95: Call rstAchat.MoveNext()
100: Loop 
		
105: Call rstAchat.Close()
110: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAchat = Nothing
		
115: Exit Sub
		
AfficherErreur: 
		
120: Call AfficherErreur("frmAchat", "OuvrirAchat", Err, Erl())
	End Sub
	
	Private Sub lvwPieceTrouve_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwPieceTrouve.DoubleClick
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: m_bRecherchePiece = True
20: m_bInventaire = False
		
		'On affiche lvwFournisseur selon la pièce choisie
		'Rempli les fournisseurs de la pièce choisie
25: Call AfficherListeFournisseurs()
		
		'si le listview n'est pas vide
30: If lvwfournisseur.Items.Count = 1 Then
35: If MsgBox("Il n'y a aucun fournisseur pour cette pièce!" & vbNewLine & "Voulez-vous en ajouter?", MsgBoxStyle.YesNo, "Erreur") = MsgBoxResult.Yes Then
40: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
				'On ouvre le catalogue sur cet enregistrement
45: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
50: 'UPGRADE_WARNING: Lower bound of collection lvwPieceTrouve.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call FrmCatalogueElec.AfficherForm(lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_CATEGORIE).Text, lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_MANUFACT).Text, lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_NO_ITEM).Text)
55: Else
60: 'UPGRADE_WARNING: Lower bound of collection lvwPieceTrouve.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call FrmCatalogueMec.AfficherForm(lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_CATEGORIE).Text, lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_MANUFACT).Text, lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_NO_ITEM).Text)
65: End If
				
70: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
				
				'On rappelle la méthode
75: Call AfficherListeFournisseurs()
80: End If
85: End If
		
90: Exit Sub
		
AfficherErreur: 
		
95: Call AfficherErreur("frmAchat", "lvwPieceTrouve_DblClick", Err, Erl())
	End Sub
	
	Private Sub cmdOKPieceTrouve_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOKPieceTrouve.Click
		
5: On Error GoTo AfficherErreur
		
10: m_bRecherchePiece = True
15: m_bInventaire = False
		
		'On affiche lvwFournisseur selon la pièce choisie
		'Rempli les fournisseurs de la pièce choisie
20: Call AfficherListeFournisseurs()
		
		'si le listview n'est pas vide
25: If lvwfournisseur.Items.Count = 1 Then
30: If MsgBox("Il n'y a aucun fournisseur pour cette pièce!" & vbNewLine & "Voulez-vous en ajouter?", MsgBoxStyle.YesNo, "Erreur") = MsgBoxResult.Yes Then
35: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
				'On ouvre le catalogue sur cet enregistrement
40: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
45: 'UPGRADE_WARNING: Lower bound of collection lvwPieceTrouve.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call FrmCatalogueElec.AfficherForm(lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_CATEGORIE).Text, lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_MANUFACT).Text, lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_NO_ITEM).Text)
50: Else
55: 'UPGRADE_WARNING: Lower bound of collection lvwPieceTrouve.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call FrmCatalogueMec.AfficherForm(lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_CATEGORIE).Text, lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_MANUFACT).Text, lvwPieceTrouve.FocusedItem.SubItems(I_COL_RECH_NO_ITEM).Text)
60: End If
				
65: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
				
				'On rappelle la méthode
70: Call AfficherListeFournisseurs()
75: End If
80: End If
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("frmAchat", "cmdOKPieceTrouve_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnulerPieceTrouve_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnulerPieceTrouve.Click
		
5: On Error GoTo AfficherErreur
		
10: fraPieceTrouve.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmAchat", "cmdAnnulerPieceTrouve", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewRecherche(ByVal iIndexColumn As Short, ByVal sTexte As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPiece As ADODB.Recordset
15: Dim itmPiece As System.Windows.Forms.ListViewItem
20: Dim iCompteur As Short
25: Dim sChamps As String
30: Dim sRecherche As String
35: Dim sLettre As String
		
40: Call lvwPieceTrouve.Items.Clear()
		
45: If iIndexColumn = I_COL_PIECES_NO_ITEM Then
50: For iCompteur = 1 To Len(sTexte)
55: sLettre = Mid(sTexte, iCompteur, 1)
				
60: If (Asc(sLettre) >= 48 And Asc(sLettre) <= 57) Or (Asc(sLettre) >= 65 And Asc(sLettre) <= 90) Or (Asc(sLettre) >= 97 And Asc(sLettre) <= 122) Then
65: sRecherche = sRecherche & sLettre
70: End If
75: Next 
80: End If
		
		'Attribue le nom du champs selon la colonne cliquée
85: Select Case iIndexColumn
			Case I_COL_PIECES_PIECE_GRB : sChamps = "PIECE_GRB"
90: Case I_COL_PIECES_NO_ITEM : sChamps = "PIECE_MODIF"
95: Case I_COL_PIECES_DESCR_EN : sChamps = "DESC_EN"
100: Case I_COL_PIECES_DESCR_FR : sChamps = "DESC_FR"
105: Case I_COL_PIECES_MANUFACT : sChamps = "FABRICANT"
110: End Select
		
115: rstPiece = New ADODB.Recordset
		
120: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
125: If iIndexColumn = I_COL_PIECES_NO_ITEM Then
130: Call rstPiece.Open("SELECT * FROM GRB_CatalogueElec WHERE INSTR(1, " & sChamps & ", '" & sRecherche & "') > 0", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
135: Else
140: Call rstPiece.Open("SELECT * FROM GRB_CatalogueElec WHERE INSTR(1, " & sChamps & ", '" & sTexte & "') > 0", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
145: End If
150: Else
155: If iIndexColumn = I_COL_PIECES_NO_ITEM Then
160: Call rstPiece.Open("SELECT * FROM GRB_CatalogueMec WHERE INSTR(1, " & sChamps & ", '" & sRecherche & "') > 0", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
165: Else
170: Call rstPiece.Open("SELECT * FROM GRB_CatalogueMec WHERE INSTR(1, " & sChamps & ", '" & sTexte & "') > 0", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
175: End If
180: End If
		
		'Pour chaque enregistrement
185: Do While Not rstPiece.EOF
			'On ajoute dans le ListView
190: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPieceTrouve.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmPiece = lvwPieceTrouve.Items.Add()
			
195: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
200: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPiece.Fields("TEMPS").Value) Then
205: itmPiece.Tag = rstPiece.Fields("TEMPS").Value
210: Else
215: itmPiece.Tag = vbNullString
220: End If
225: End If
			
230: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPiece.Fields("PIECE_GRB").Value) Then
235: itmPiece.Text = rstPiece.Fields("PIECE_GRB").Value
240: Else
245: itmPiece.Text = ""
250: End If
			
255: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPiece.SubItems.Count > I_COL_RECH_NO_ITEM Then
				itmPiece.SubItems(I_COL_RECH_NO_ITEM).Text = rstPiece.Fields("PIECE").Value
			Else
				itmPiece.SubItems.Insert(I_COL_RECH_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("PIECE").Value))
			End If
260: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmPiece.SubItems.Count > I_COL_RECH_CATEGORIE Then
				itmPiece.SubItems(I_COL_RECH_CATEGORIE).Text = VB6.GetItemString(cmbCategorie, iCompteur)
			Else
				itmPiece.SubItems.Insert(I_COL_RECH_CATEGORIE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, VB6.GetItemString(cmbCategorie, iCompteur)))
			End If
			
265: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPiece.Fields("FABRICANT").Value) Then
270: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_RECH_MANUFACT Then
					itmPiece.SubItems(I_COL_RECH_MANUFACT).Text = rstPiece.Fields("FABRICANT").Value
				Else
					itmPiece.SubItems.Insert(I_COL_RECH_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("FABRICANT").Value))
				End If
275: Else
280: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_RECH_MANUFACT Then
					itmPiece.SubItems(I_COL_RECH_MANUFACT).Text = ""
				Else
					itmPiece.SubItems.Insert(I_COL_RECH_MANUFACT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
				End If
285: End If
			
290: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPiece.Fields("DESC_EN").Value) Then
295: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_RECH_DESCR_EN Then
					itmPiece.SubItems(I_COL_RECH_DESCR_EN).Text = rstPiece.Fields("DESC_EN").Value
				Else
					itmPiece.SubItems.Insert(I_COL_RECH_DESCR_EN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("DESC_EN").Value))
				End If
300: Else
305: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_RECH_DESCR_EN Then
					itmPiece.SubItems(I_COL_RECH_DESCR_EN).Text = ""
				Else
					itmPiece.SubItems.Insert(I_COL_RECH_DESCR_EN, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
				End If
310: End If
			
315: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPiece.Fields("DESC_FR").Value) Then
320: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_RECH_DESCR_FR Then
					itmPiece.SubItems(I_COL_RECH_DESCR_FR).Text = rstPiece.Fields("DESC_FR").Value
				Else
					itmPiece.SubItems.Insert(I_COL_RECH_DESCR_FR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPiece.Fields("DESC_FR").Value))
				End If
325: Else
330: 'UPGRADE_WARNING: Lower bound of collection itmPiece has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPiece.SubItems.Count > I_COL_RECH_DESCR_FR Then
					itmPiece.SubItems(I_COL_RECH_DESCR_FR).Text = ""
				Else
					itmPiece.SubItems.Insert(I_COL_RECH_DESCR_FR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
				End If
335: End If
			
340: Call rstPiece.MoveNext()
345: Loop 
		
350: Call rstPiece.Close()
355: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
360: Exit Sub
		
AfficherErreur: 
		
365: Call AfficherErreur("frmAchat", "RemplirListViewRecherche", Err, Erl())
	End Sub
	
	Private Sub cmdMaterielInutile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMaterielInutile.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim itmAchat As System.Windows.Forms.ListViewItem
		
15: If lvwAchat.Items.Count > 0 Then
20: itmAchat = lvwAchat.FocusedItem
			
			'Si la quantité est plus grande que 0
25: If CDbl(itmAchat.Text) > 0 Then
30: m_bPieceInutile = True
35: m_bRecherchePiece = False
				
40: Call AfficherListeFournisseurs()
				
45: If lvwfournisseur.Items.Count = 0 Then
50: Call MsgBox("Il n'y a aucun fournisseur pour cette pièce!", MsgBoxStyle.OKOnly, "Erreur")
					
55: Exit Sub
60: Else
65: frafournisseur.Visible = True
70: End If
75: Else
80: Call MsgBox("La quantité est déjà dans le négatif!", MsgBoxStyle.OKOnly, "Erreur")
85: End If
90: End If
		
95: Exit Sub
		
AfficherErreur: 
		
100: Call AfficherErreur("frmAchat", "cmdMaterielInutile_Click", Err, Erl())
	End Sub
	
	Private Sub cmdMauvaisPrix_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMauvaisPrix.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim itmAchat As System.Windows.Forms.ListViewItem
		
20: If lvwAchat.Items.Count > 0 Then
25: itmAchat = lvwAchat.FocusedItem
			
			'Si la quantité est plus grande que 0
30: If CDbl(itmAchat.Text) > 0 Then
35: Call ViderChamps_frs()
				
40: Call RemplirComboFournisseur()
				
45: For iCompteur = 0 To cmbfrs.Items.Count - 1
50: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If VB6.GetItemData(cmbfrs, iCompteur) = itmAchat.SubItems.Item(I_COL_ACHAT_DISTRIB).Tag Then
55: cmbfrs.SelectedIndex = iCompteur
						
60: Exit For
65: End If
70: Next 
				
75: 'UPGRADE_ISSUE: ComboBox property cmbfrs.Locked was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				cmbfrs.Locked = True
				
80: fraPrixPiece.Tag = itmAchat.Index
				
85: m_bMauvaisPrix = True
				
90: fraPrixPiece.Visible = True
95: Else
100: Call MsgBox("La quantité est déjà dans le négatif!", MsgBoxStyle.OKOnly, "Erreur")
105: End If
110: End If
		
115: Exit Sub
		
AfficherErreur: 
		
120: Call AfficherErreur("frmAchat", "cmdMauvaisPrix_Click", Err, Erl())
	End Sub
	
	Private Sub cmdReception_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdReception.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
15: Dim bOuvert As Boolean
		
20: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
25: For iCompteur = 0 To My.Application.OpenForms.Count - 1
30: If My.Application.OpenForms.Item(iCompteur).Name = "FrmReceptionElec" Then
35: bOuvert = True
					
40: Exit For
45: End If
50: Next 
			
55: If bOuvert = True Then
60: Call FrmReceptionElec.Close()
65: End If
			
70: Call FrmReceptionElec.AfficherAchat(g_sUserID, txtNoAchat.Text)
			
75: Call RemplirListViewAchat()
80: Else
85: For iCompteur = 0 To My.Application.OpenForms.Count - 1
90: If My.Application.OpenForms.Item(iCompteur).Name = "FrmReceptionMec" Then
95: bOuvert = True
					
100: Exit For
105: End If
110: Next 
			
115: If bOuvert = True Then
120: Call FrmReceptionMec.Close()
125: End If
			
130: Call FrmReceptionMec.AfficherAchat(g_sUserID, txtNoAchat.Text)
			
135: Call RemplirListViewAchat()
140: End If
		
145: Exit Sub
		
AfficherErreur: 
		
150: Call AfficherErreur("frmAchat", "cmdReception_Click", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event txtPrixSpecial.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtPrixSpecial_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrixSpecial.TextChanged
		
5: On Error GoTo AfficherErreur
		'Quand le contenu du prix spécial change
		
		'Si la longueur du texte écrit est plus grand que 0
10: If Len(txtPrixSpecial.Text) > 0 Then
			'On vide l'escompte, le prix net et on les désactive
15: mskEscompte.Text = vbNullString
20: txtPrixNet.Text = vbNullString
			
25: mskEscompte.Enabled = False
30: txtPrixNet.Enabled = False
35: Else
			'Sinon, on active escompte et prix net
40: mskEscompte.Enabled = True
45: txtPrixNet.Enabled = True
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmAchat", "txtPrixSpecial_Change", Err, Erl())
	End Sub
	
	Private Sub txtPrixSpecial_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrixSpecial.Leave
		
5: On Error GoTo AfficherErreur
		
10: txtPrixSpecial.Text = Replace(txtPrixSpecial.Text, ".", ",")
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmAchat", "txtPrixSpecial_LostFocus", Err, Erl())
	End Sub
End Class