Option Strict Off
Option Explicit On
Friend Class frmRechercheInventaire
	Inherits System.Windows.Forms.Form
	
	Private Const I_CMB_NO_ITEM As Short = 0
	Private Const I_CMB_FABRICANT As Short = 1
	Private Const I_CMB_DESCRIPTION As Short = 2
	Private Const I_CMB_CATEGORIE As Short = 3
	
	Private Const I_COL_QTE As Short = 0
	Private Const I_COL_NO_ITEM As Short = 1
	Private Const I_COL_FABRICANT As Short = 2
	Private Const I_COL_DESCRIPTION As Short = 3
	Private Const I_COL_CATEGORIE As Short = 4
	Private Const I_COL_LOCALISATION As Short = 5
	Private Const I_COL_PRIX_LIST As Short = 6
	Private Const I_COL_ESCOMPTE As Short = 7
	Private Const I_COL_PRIX_NET As Short = 8
	Private Const I_COL_TOTAL As Short = 9
	
	Private m_eCatalogue As ModuleMain.enumCatalogue
	
	Private Sub RemplirComboCategories()
		
5: On Error GoTo AfficherErreur
		
		'Remplir le combo des catégories
10: Dim rstCategorie As ADODB.Recordset
15: Dim sNomCategorie As String
		
20: rstCategorie = New ADODB.Recordset
		
25: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
30: Call rstCategorie.Open("SELECT DISTINCT Categorie FROM GRB_CatalogueElec", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
35: Else
40: Call rstCategorie.Open("SELECT DISTINCT Categorie FROM GRB_CatalogueMec", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
45: End If
		
50: Do While Not rstCategorie.EOF
55: sNomCategorie = rstCategorie.Fields("Categorie").Value
			
60: Call cmbCategorie.Items.Add(sNomCategorie)
			
65: Call rstCategorie.MoveNext()
70: Loop 
		
75: Call rstCategorie.Close()
80: 'UPGRADE_NOTE: Object rstCategorie may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstCategorie = Nothing
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("frmRechercheInventaire", "RemplirComboCategories", Err, Erl())
	End Sub
	
	Public Sub Afficher(ByVal eCatalogue As ModuleMain.enumCatalogue)
		
5: On Error GoTo AfficherErreur
		
10: m_eCatalogue = eCatalogue
		
15: Call RemplirComboCategories()
		
20: cmbRecherche.SelectedIndex = I_CMB_NO_ITEM
		
25: Call Me.Show()
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmRechercheInventaire", "Afficher", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbRecherche.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbRecherche_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbRecherche.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: If cmbRecherche.SelectedIndex = I_CMB_CATEGORIE Then
15: txtRecherche.Visible = False
20: cmbCategorie.Visible = True
25: lblTitreRecherche.Text = "Catégorie à rechercher"
30: Else
35: cmbCategorie.Visible = False
40: txtRecherche.Visible = True
45: lblTitreRecherche.Text = "Texte à rechercher"
50: End If
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmRechercheInventaire", "cmbRecherche_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAfficher_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAfficher.Click
		
5: On Error GoTo AfficherErreur
		
10: Call RemplirListView()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmRechercheInventaire", "cmdAfficher_Click", Err, Erl())
	End Sub
	
	Private Sub RemplirListView()
		
5: On Error GoTo AfficherErreur
		
10: Dim sWhere As String
15: Dim rstInv As ADODB.Recordset
20: Dim rstCatalogue As ADODB.Recordset
25: Dim iCompteur As Short
		
30: If (cmbRecherche.SelectedIndex <> I_CMB_CATEGORIE And txtRecherche.Text <> "") Or (cmbRecherche.SelectedIndex = I_CMB_CATEGORIE And cmbCategorie.SelectedIndex > -1) Then
35: Select Case cmbRecherche.SelectedIndex
				Case I_CMB_NO_ITEM
40: sWhere = "INSTR(1, PIECE, '" & txtRecherche.Text & "') > 0"
					
45: Case I_CMB_FABRICANT
50: sWhere = "INSTR(1, FABRICANT, '" & txtRecherche.Text & "') > 0"
					
55: Case I_CMB_DESCRIPTION
60: sWhere = "INSTR(1, DESC_FR, '" & txtRecherche.Text & "') > 0"
					
65: Case I_CMB_CATEGORIE
70: sWhere = "INSTR(1, CATEGORIE, '" & Replace(cmbCategorie.Text, "'", "''") & "') > 0"
75: End Select
			
80: rstCatalogue = New ADODB.Recordset
85: rstInv = New ADODB.Recordset
			
90: Call lvwInventaire.Items.Clear()
			
95: lblTotal.Text = ""
			
100: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
105: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
110: Call rstCatalogue.Open("SELECT * FROM GRB_CatalogueElec WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
115: Else
120: Call rstCatalogue.Open("SELECT * FROM GRB_CatalogueMec WHERE " & sWhere, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
125: End If
			
130: Do While Not rstCatalogue.EOF
135: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
140: Call rstInv.Open("SELECT * FROM GRB_InventaireElec WHERE NoItem = '" & Replace(rstCatalogue.Fields("PIECE").Value, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
145: Else
150: Call rstInv.Open("SELECT * FROM GRB_InventaireMec WHERE NoItem = '" & Replace(rstCatalogue.Fields("PIECE").Value, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
155: End If
				
160: If Not rstInv.EOF Then
165: Call AjouterItemListView(rstInv, rstCatalogue.Fields("CATEGORIE").Value)
170: End If
				
175: Call rstInv.Close()
				
180: Call rstCatalogue.MoveNext()
				
185: System.Windows.Forms.Application.DoEvents()
190: Loop 
			
195: Call CalculerTotal()
			
200: Call rstCatalogue.Close()
			
205: 'UPGRADE_NOTE: Object rstCatalogue may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstCatalogue = Nothing
210: 'UPGRADE_NOTE: Object rstInv may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstInv = Nothing
			
215: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
220: Else
225: If cmbRecherche.SelectedIndex = I_CMB_CATEGORIE Then
230: Call MsgBox("La catégorie à rechercher est obligatoire!", MsgBoxStyle.OKOnly, "Erreur")
235: Else
240: Call MsgBox("Le texte à rechercher ne doit pas être vide!", MsgBoxStyle.OKOnly, "Erreur")
245: End If
250: End If
		
255: Exit Sub
		
AfficherErreur: 
		
260: Call AfficherErreur("frmRechercheInventaire", "RemplirListView", Err, Erl())
	End Sub
	
	Private Sub AjouterItemListView(ByVal rstInv As ADODB.Recordset, ByVal sCategorie As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim itmInv As System.Windows.Forms.ListViewItem
		
15: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwInventaire.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		itmInv = lvwInventaire.Items.Add()
		
20: itmInv.Text = rstInv.Fields("QuantitéStock").Value
25: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmInv.SubItems.Count > I_COL_NO_ITEM Then
			itmInv.SubItems(I_COL_NO_ITEM).Text = rstInv.Fields("NoItem").Value
		Else
			itmInv.SubItems.Insert(I_COL_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstInv.Fields("NoItem").Value))
		End If
30: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmInv.SubItems.Count > I_COL_FABRICANT Then
			itmInv.SubItems(I_COL_FABRICANT).Text = rstInv.Fields("Manufacturier").Value
		Else
			itmInv.SubItems.Insert(I_COL_FABRICANT, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstInv.Fields("Manufacturier").Value))
		End If
35: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmInv.SubItems.Count > I_COL_DESCRIPTION Then
			itmInv.SubItems(I_COL_DESCRIPTION).Text = rstInv.Fields("Description").Value
		Else
			itmInv.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstInv.Fields("Description").Value))
		End If
40: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmInv.SubItems.Count > I_COL_CATEGORIE Then
			itmInv.SubItems(I_COL_CATEGORIE).Text = sCategorie
		Else
			itmInv.SubItems.Insert(I_COL_CATEGORIE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sCategorie))
		End If
45: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmInv.SubItems.Count > I_COL_LOCALISATION Then
			itmInv.SubItems(I_COL_LOCALISATION).Text = rstInv.Fields("Localisation").Value
		Else
			itmInv.SubItems.Insert(I_COL_LOCALISATION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstInv.Fields("Localisation").Value))
		End If
50: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmInv.SubItems.Count > I_COL_PRIX_LIST Then
			itmInv.SubItems(I_COL_PRIX_LIST).Text = Conversion_Renamed(rstInv.Fields("Prix Liste"), ModuleMain.enumConvert.MODE_ARGENT, 4)
		Else
			itmInv.SubItems.Insert(I_COL_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(rstInv.Fields("Prix Liste"), ModuleMain.enumConvert.MODE_ARGENT, 4)))
		End If
55: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmInv.SubItems.Count > I_COL_ESCOMPTE Then
			itmInv.SubItems(I_COL_ESCOMPTE).Text = Conversion_Renamed(rstInv.Fields("Escompte"), ModuleMain.enumConvert.MODE_POURCENT)
		Else
			itmInv.SubItems.Insert(I_COL_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(rstInv.Fields("Escompte"), ModuleMain.enumConvert.MODE_POURCENT)))
		End If
60: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmInv.SubItems.Count > I_COL_PRIX_NET Then
			itmInv.SubItems(I_COL_PRIX_NET).Text = Conversion_Renamed(rstInv.Fields("Prix net"), ModuleMain.enumConvert.MODE_ARGENT, 4)
		Else
			itmInv.SubItems.Insert(I_COL_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(rstInv.Fields("Prix net"), ModuleMain.enumConvert.MODE_ARGENT, 4)))
		End If
65: 'UPGRADE_WARNING: Lower bound of collection itmInv has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmInv.SubItems.Count > I_COL_TOTAL Then
			itmInv.SubItems(I_COL_TOTAL).Text = Conversion_Renamed(CDbl(Replace(rstInv.Fields("Prix net").Value, ".", ",")) * CDbl(Replace(rstInv.Fields("QuantitéStock").Value, ".", ",")), ModuleMain.enumConvert.MODE_ARGENT)
		Else
			itmInv.SubItems.Insert(I_COL_TOTAL, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CDbl(Replace(rstInv.Fields("Prix net").Value, ".", ",")) * CDbl(Replace(rstInv.Fields("QuantitéStock").Value, ".", ",")), ModuleMain.enumConvert.MODE_ARGENT)))
		End If
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmRechercheInventaire", "AjouterItemListView", Err, Erl())
	End Sub
	
	Private Sub CalculerTotal()
		
5: On Error GoTo AfficherErreur
		
10: Dim dblTotal As Double
15: Dim iCompteur As Short
		
20: For iCompteur = 1 To lvwInventaire.Items.Count
25: 'UPGRADE_WARNING: Lower bound of collection lvwInventaire.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwInventaire.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			dblTotal = dblTotal + CDbl(lvwInventaire.Items.Item(iCompteur).SubItems(I_COL_TOTAL).Text)
30: Next 
		
35: lblTotal.Text = Conversion_Renamed(dblTotal, ModuleMain.enumConvert.MODE_ARGENT)
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmRechercheInventaire", "CalculerTotal", Err, Erl())
	End Sub
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmRechercheInventaire", "cmdFermer_Click", Err, Erl())
	End Sub
End Class