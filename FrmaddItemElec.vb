Option Strict Off
Option Explicit On
Friend Class FrmaddItemElec
	Inherits System.Windows.Forms.Form
	
	Private Sub cmbCategorie_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles cmbCategorie.KeyUp
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: For iCompteur = 0 To cmbCategorie.Items.Count - 1
20: If UCase(VB6.GetItemString(cmbCategorie, iCompteur)) = UCase(cmbCategorie.Text) Then
25: cmbCategorie.SelectedIndex = iCompteur
				
30: Exit For
35: End If
40: Next 
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("FrmaddItemElec", "cmbProjSoum_KeyUp", Err, Erl())
	End Sub
	
	Private Sub cmbFabricant_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cmbFabricant.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
5: On Error GoTo AfficherErreur
		
10: If KeyAscii <= 122 And KeyAscii >= 97 Then
15: KeyAscii = KeyAscii - 32
20: End If
		
25: GoTo EventExitSub
		
AfficherErreur: 
		
30: Call AfficherErreur("FrmaddItemElec", "cmbFabricant_KeyPress", Err, Erl())
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
		'Fermeture de la fenêtre
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("FrmaddItemElec", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub FrmaddItemElec_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des catégories avec le nom des tables
10: Call RemplirComboCategorie()
		
		'Sur l'ouverture, il faut remplir le combo des manufacturiers
15: Call RemplirComboManufacturier()
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("FrmaddItemElec", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub RemplirComboCategorie()
		
5: On Error GoTo AfficherErreur
		
		'Remplir le combo catégorie
10: Dim rstCatalogueElec As ADODB.Recordset
		
		'Il faut vider le combo avant de le remplir
15: Call cmbCategorie.Items.Clear()
		
20: rstCatalogueElec = New ADODB.Recordset
		
		'Cette méthode crée un recordset contenant les categorie
		'le nom de toutes les tables de la BD
25: Call rstCatalogueElec.Open("SELECT DISTINCT CATEGORIE FROM GRB_CatalogueElec ORDER BY Categorie", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
30: Do While Not rstCatalogueElec.EOF
35: Call cmbCategorie.Items.Add(rstCatalogueElec.Fields("CATEGORIE").Value)
			
40: Call rstCatalogueElec.MoveNext()
45: Loop 
		
50: Call rstCatalogueElec.Close()
55: 'UPGRADE_NOTE: Object rstCatalogueElec may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstCatalogueElec = Nothing
		
		'Si le combo n'est pas vide, on sélectionne la catégorie sélectionnée dans
		'le catalogue
60: If cmbCategorie.Items.Count > 0 Then
65: cmbCategorie.Text = FrmCatalogueElec.cmbCategorie.Text
70: End If
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("FrmAddItemElec", "RemplirComboCategorie", Err, Erl())
	End Sub
	
	Private Sub RemplirComboManufacturier()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des manufacturiers selon la table choisie
10: Dim rstManufacturier As ADODB.Recordset
		
15: rstManufacturier = New ADODB.Recordset
		
20: Call rstManufacturier.Open("SELECT DISTINCT FABRICANT FROM GRB_CatalogueElec", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que c'est pas la fin des enregistrements
25: Do While Not rstManufacturier.EOF
30: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstManufacturier.Fields("FABRICANT").Value) Then
				'Ajout du nom du manufacturier au Combo
35: Call cmbFabricant.Items.Add(rstManufacturier.Fields("FABRICANT").Value)
40: End If
			
45: Call rstManufacturier.MoveNext()
50: Loop 
		
55: Call rstManufacturier.Close()
60: 'UPGRADE_NOTE: Object rstManufacturier may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstManufacturier = Nothing
		
65: Exit Sub
		
AfficherErreur: 
		
70: Call AfficherErreur("FrmaddItemElec", "RemplirComboManufacturier", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
		'Proc qui permet d'ajouter un item a la BD
10: Dim rstItem As ADODB.Recordset
15: Dim rstFRS As ADODB.Recordset
20: Dim rstPieceFRS As ADODB.Recordset
25: Dim iCompteur As Short
30: Dim iFRS As Short
35: Dim sPieceModif As String
40: Dim sLettre As String
		
		'Si aucun champs est vide
45: If Trim(txtNoItem.Text) <> vbNullString And Trim(cmbFabricant.Text) <> vbNullString And Trim(cmbCategorie.Text) <> vbNullString Then
50: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
55: rstItem = New ADODB.Recordset
			
60: Call rstItem.Open("SELECT * FROM GRB_CatalogueElec WHERE PIECE = '" & Replace(txtNoItem.Text, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
65: If Not rstItem.EOF Then
70: Call MsgBox("Attention! L'item # " & txtNoItem.Text & " existe déjà!", MsgBoxStyle.OKOnly, "Erreur")
				
75: Call rstItem.Close()
80: 'UPGRADE_NOTE: Object rstItem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstItem = Nothing
				
85: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
90: Else
				'Si elle n'existe pas
				'On l'ajoute
95: Call rstItem.AddNew()
				
100: rstItem.Fields("CATEGORIE").Value = cmbCategorie.Text
105: rstItem.Fields("FABRICANT").Value = Trim(cmbFabricant.Text)
110: rstItem.Fields("PIECE").Value = Trim(txtNoItem.Text)
				
115: For iCompteur = 1 To Len(Trim(txtNoItem.Text))
120: sLettre = Mid(Trim(txtNoItem.Text), iCompteur, 1)
					
125: If (Asc(sLettre) >= 48 And Asc(sLettre) <= 57) Or (Asc(sLettre) >= 65 And Asc(sLettre) <= 90) Or (Asc(sLettre) >= 97 And Asc(sLettre) <= 122) Then
130: sPieceModif = sPieceModif & sLettre
135: End If
140: Next 
				
145: rstItem.Fields("PIECE_MODIF").Value = sPieceModif
150: rstItem.Fields("PIECE_GRB").Value = Trim(txtNoItem.Text) & "GRB"
155: rstItem.Fields("TEMPS").Value = 0
				
160: Call rstItem.Update()
				
165: Call rstItem.Close()
170: 'UPGRADE_NOTE: Object rstItem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstItem = Nothing
				
175: rstFRS = New ADODB.Recordset
				
180: Call rstFRS.Open("SELECT * FROM GRB_Fournisseur WHERE NomFournisseur = 'FOURNI PAR LE CLIENT'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
185: iFRS = rstFRS.Fields("IDFRS").Value
				
190: Call rstFRS.Close()
195: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstFRS = Nothing
				
200: rstPieceFRS = New ADODB.Recordset
				
205: Call rstPieceFRS.Open("SELECT * FROM GRB_PiecesFRS", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
				'Ajout du fournisseur 'FOURNI PAR LE CLIENT'
210: Call rstPieceFRS.AddNew()
				
215: rstPieceFRS.Fields("IDFRS").Value = iFRS
220: rstPieceFRS.Fields("PIECE").Value = Trim(txtNoItem.Text)
225: rstPieceFRS.Fields("PRIX_LIST").Value = 0
230: rstPieceFRS.Fields("ESCOMPTE").Value = 0
235: rstPieceFRS.Fields("PRIX_NET").Value = 0
240: rstPieceFRS.Fields("DATE").Value = ConvertDate(Today)
245: rstPieceFRS.Fields("ENTRER_PAR").Value = g_sInitiale
250: rstPieceFRS.Fields("DeviseMonétaire").Value = "CAN"
255: rstPieceFRS.Fields("Type").Value = "E"
				
260: Call rstPieceFRS.Update()
				
				'Ajout du fournisseur 'SOLUTION GRB INC.'
265: Call rstPieceFRS.AddNew()
				
270: rstPieceFRS.Fields("IDFRS").Value = 717
275: rstPieceFRS.Fields("PIECE").Value = Trim(txtNoItem.Text)
280: rstPieceFRS.Fields("PRIX_LIST").Value = 0
285: rstPieceFRS.Fields("ESCOMPTE").Value = 0
290: rstPieceFRS.Fields("PRIX_NET").Value = 0
295: rstPieceFRS.Fields("DATE").Value = ConvertDate(Today)
300: rstPieceFRS.Fields("ENTRER_PAR").Value = g_sInitiale
305: rstPieceFRS.Fields("DeviseMonétaire").Value = "CAN"
310: rstPieceFRS.Fields("Type").Value = "E"
				
315: Call rstPieceFRS.Update()
				
320: Call rstPieceFRS.Close()
325: 'UPGRADE_NOTE: Object rstPieceFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstPieceFRS = Nothing
				
335: FrmCatalogueElec.m_sSelectCategorie = cmbCategorie.Text
340: FrmCatalogueElec.m_sSelectFabricant = cmbFabricant.Text
345: FrmCatalogueElec.m_sSelectNoItem = txtNoItem.Text
				
				'Remplis le combo catégorie dans le form électrique
330: Call FrmCatalogueElec.RemplirComboCategorie()
				
				'Montre seulement les boutons pour enregistrer
350: Call FrmCatalogueElec.MontrerControles(FrmCatalogueElec.enumModeCatalogueElec.MODE_AJOUT_MODIF_ELEC)
				
355: FrmCatalogueElec.txtNoItemGRB.Text = txtNoItem.Text & "GRB"
				
360: FrmCatalogueElec.txtDescriptionFR.Text = vbNullString
				
365: Call FrmCatalogueElec.BarrerChamps_piece(False)
				
				'on redonne le controle au catalogue
370: Call Me.Close()
375: End If
380: Else
385: Call MsgBox("Vous devez remplir tous les champs", MsgBoxStyle.OKOnly, "Erreur")
390: End If
		
395: Exit Sub
		
AfficherErreur: 
		
400: Call AfficherErreur("FrmaddItemElec", "cmdOK_Click", Err, Erl())
	End Sub
End Class