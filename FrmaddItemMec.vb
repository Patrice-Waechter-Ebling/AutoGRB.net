Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FrmaddItemMec
	Inherits System.Windows.Forms.Form
	
	Private Sub cmbCategorie_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles cmbCategorie.KeyUp
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: For iCompteur = 0 To cmbcategorie.Items.Count - 1
20: If UCase(VB6.GetItemString(cmbcategorie, iCompteur)) = UCase(cmbcategorie.Text) Then
25: cmbcategorie.SelectedIndex = iCompteur
				
30: Exit For
35: End If
40: Next 
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("FrmaddItemMec", "cmbProjSoum_KeyUp", Err, Erl())
	End Sub
	
	Private Sub RemplirComboCategorie()
		
5: On Error GoTo AfficherErreur
		
		'Remplir le combo categorie
10: Dim rstCatalogueMec As ADODB.Recordset
		
		'Il faut vider le combo avant de le remplir
15: Call cmbcategorie.Items.Clear()
		
20: rstCatalogueMec = New ADODB.Recordset
		
		'Cette méthode crée un recordset contenant les categorie
		'le nom de toutes les tables de la BD
25: Call rstCatalogueMec.Open("SELECT DISTINCT Categorie FROM GRB_CatalogueMec ORDER BY Categorie", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Tant que ce n'est pas la fin des enregistrements
30: Do While Not rstCatalogueMec.EOF
35: Call cmbcategorie.Items.Add(rstCatalogueMec.Fields("categorie").Value)
			
40: Call rstCatalogueMec.MoveNext()
45: Loop 
		
50: Call rstCatalogueMec.Close()
55: 'UPGRADE_NOTE: Object rstCatalogueMec may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstCatalogueMec = Nothing
		
		'Si le combo n'est pas vide, on sélectionne la catégorie sélectionnée dans
		'le catalogue
60: If cmbcategorie.Items.Count > 0 Then
65: cmbcategorie.Text = FrmCatalogueMec.cmbcategorie.Text
70: End If
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("FrmaddItemMec", "RemplirComboCategorie", Err, Erl())
	End Sub
	
	Private Sub cmbFabricant_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cmbFabricant.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
5: On Error GoTo AfficherErreur
		
		'Pour mettre les lettres en majuscule
10: If KeyAscii <= 122 And KeyAscii >= 97 Then
15: KeyAscii = KeyAscii - 32
20: End If
		
25: GoTo EventExitSub
		
AfficherErreur: 
		
30: Call AfficherErreur("FrmaddItemMec", "cmbFabricant_KeyPress", Err, Erl())
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
		'fermeture de la fenêtre
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("FrmaddItemMec", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub FrmaddItemMec_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
		'Affiche les numéros suivants
		
10: Call AfficherNoAcier()
		
15: Call AfficherNoPlastique()
		
20: Call AfficherNoStainless()
25: 
		Call AfficherNoAluminium()
		
		'Sur l'ouverture, il faut remplir les combos
		
30: Call RemplirComboCategorie()
35: 
		Call RemplirComboManufacturier()
		
40: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("FrmaddItemMec", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub AfficherNoAcier()
		'Affiche le numéro de la prochaine pièce ACIER
5: On Error GoTo AfficherErreur
		
10: Dim rstAcier As ADODB.Recordset
15: Dim sNoAcier As String
20: Dim iNoAcier As Short
		Dim iNoAcierNow As Short
25: rstAcier = New ADODB.Recordset
		iNoAcier = 0
30: Call rstAcier.Open("SELECT PIECE FROM GRB_CatalogueMec WHERE PIECE LIKE 'ACIER%' ORDER BY PIECE", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
35: Do While Not rstAcier.EOF
40: sNoAcier = VB.Right(rstAcier.Fields("PIECE").Value, Len(rstAcier.Fields("PIECE").Value) - 5)
			sNoAcier = VB.Left(sNoAcier, 4)
			If IsNumeric(sNoAcier) Then iNoAcierNow = CShort(sNoAcier)
45: If iNoAcierNow > iNoAcier Then iNoAcier = iNoAcierNow
			Call rstAcier.MoveNext()
		Loop 
		
		
		
55: lblAcier.Text = "ACIER : " & iNoAcier + 1
		
		
75: Call rstAcier.Close()
80: 'UPGRADE_NOTE: Object rstAcier may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAcier = Nothing
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("FrmaddItemMec", "AfficherNoAcier", Err, Erl())
	End Sub
	
	Private Sub AfficherNoPlastique()
		'Affiche le numéro de la prochaine pièce ACIER
5: On Error GoTo AfficherErreur
		
10: Dim rstPlastique As ADODB.Recordset
15: Dim sNoPlastique As String
20: Dim iNoPlastique As Short
		Dim iNoPlastiqueNow As Short
25: rstPlastique = New ADODB.Recordset
		
30: Call rstPlastique.Open("SELECT PIECE FROM GRB_CatalogueMec WHERE PIECE LIKE 'PLASTIQUE%' ORDER BY PIECE", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
35: Do While Not rstPlastique.EOF
40: 
			
45: sNoPlastique = VB.Right(rstPlastique.Fields("PIECE").Value, Len(rstPlastique.Fields("PIECE").Value) - 9)
			sNoPlastique = VB.Left(sNoPlastique, 4)
			If IsNumeric(sNoPlastique) Then iNoPlastiqueNow = CShort(sNoPlastique)
			If iNoPlastiqueNow > iNoPlastique Then iNoPlastique = iNoPlastiqueNow
			Call rstPlastique.MoveNext()
		Loop 
		
55: lblPlastique.Text = "PLASTIQUE : " & iNoPlastique + 1
		
		
75: Call rstPlastique.Close()
80: 'UPGRADE_NOTE: Object rstPlastique may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPlastique = Nothing
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("FrmaddItemMec", "AfficherNoPlastique", Err, Erl())
	End Sub
	
	Private Sub AfficherNoStainless()
		'Affiche le numéro de la prochaine pièce ACIER
5: On Error GoTo AfficherErreur
		
10: Dim rstStainless As ADODB.Recordset
15: Dim sNoStainless As String
20: Dim iNoStainless As Short
		Dim iNoStainlessNow As Short
25: rstStainless = New ADODB.Recordset
		
30: Call rstStainless.Open("SELECT PIECE FROM GRB_CatalogueMec WHERE PIECE LIKE 'STAINLESS%' ORDER BY PIECE", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
35: Do While Not rstStainless.EOF
40: sNoStainless = VB.Right(rstStainless.Fields("PIECE").Value, Len(rstStainless.Fields("PIECE").Value) - 9)
			If IsNumeric(sNoStainless) Then iNoStainlessNow = CShort(sNoStainless)
45: If iNoStainlessNow > iNoStainless Then iNoStainless = iNoStainlessNow
			Call rstStainless.MoveNext()
		Loop 
50: 
		
55: lblStainless.Text = "STAINLESS : " & iNoStainless + 1
		
		
75: Call rstStainless.Close()
80: 'UPGRADE_NOTE: Object rstStainless may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstStainless = Nothing
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("FrmaddItemMec", "AfficherNoStainless", Err, Erl())
	End Sub
	
	Private Sub AfficherNoAluminium()
		'Affiche le numéro de la prochaine pièce ACIER
5: On Error GoTo AfficherErreur
		
10: Dim rstAluminium As ADODB.Recordset
15: Dim sNoAluminium As String
20: Dim iNoAluminium As Short
		Dim inoAluminiumNow As Short
25: rstAluminium = New ADODB.Recordset
		iNoAluminium = 0
30: Call rstAluminium.Open("SELECT PIECE FROM GRB_CatalogueMec WHERE PIECE LIKE 'ALUMINIUM%' ORDER BY PIECE", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
35: Do While Not rstAluminium.EOF
40: 
			
45: sNoAluminium = VB.Right(rstAluminium.Fields("PIECE").Value, Len(rstAluminium.Fields("PIECE").Value) - 9)
			sNoAluminium = VB.Left(sNoAluminium, 4)
50: If IsNumeric(sNoAluminium) Then inoAluminiumNow = CShort(sNoAluminium)
			If inoAluminiumNow > iNoAluminium Then iNoAluminium = inoAluminiumNow
			Call rstAluminium.MoveNext()
		Loop 
55: lblAluminium.Text = "ALUMINIUM : " & iNoAluminium + 1
		
75: Call rstAluminium.Close()
80: 'UPGRADE_NOTE: Object rstAluminium may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAluminium = Nothing
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("FrmaddItemMec", "AfficherNoAluminium", Err, Erl())
	End Sub
	
	Private Sub RemplirComboManufacturier()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le combo des manufacturiers selon la table choisie
10: Dim rstManufacturier As ADODB.Recordset
		
15: rstManufacturier = New ADODB.Recordset
		
20: Call rstManufacturier.Open("SELECT DISTINCT FABRICANT FROM GRB_CatalogueMec", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
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
		
70: Call AfficherErreur("FrmaddItemMec", "RemplirComboManufacturier", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
		'Proc qui permet dajouter un item a la BD
10: Dim rstItem As ADODB.Recordset
15: Dim rstFRS As ADODB.Recordset
20: Dim rstPieceFRS As ADODB.Recordset
25: Dim iCompteur As Short
30: Dim iFRS As Short
35: Dim sPieceModif As String
40: Dim sLettre As String
		
		'Si aucun champs est vide
45: If Trim(txtNoItem.Text) <> vbNullString And Trim(cmbFabricant.Text) <> vbNullString And Trim(cmbcategorie.Text) <> vbNullString Then
50: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
55: rstItem = New ADODB.Recordset
			
60: Call rstItem.Open("SELECT * FROM GRB_CatalogueMec WHERE PIECE = '" & Replace(txtNoItem.Text, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
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
				
100: rstItem.Fields("CATEGORIE").Value = cmbcategorie.Text
105: rstItem.Fields("FABRICANT").Value = cmbFabricant.Text
110: rstItem.Fields("PIECE").Value = Trim(txtNoItem.Text)
				
115: For iCompteur = 1 To Len(Trim(txtNoItem.Text))
120: sLettre = Mid(Trim(txtNoItem.Text), iCompteur, 1)
					
125: If (Asc(sLettre) >= 48 And Asc(sLettre) <= 57) Or (Asc(sLettre) >= 65 And Asc(sLettre) <= 90) Or (Asc(sLettre) >= 97 And Asc(sLettre) <= 122) Then
130: sPieceModif = sPieceModif & sLettre
135: End If
140: Next 
				
145: rstItem.Fields("PIECE_MODIF").Value = sPieceModif
150: rstItem.Fields("PIECE_GRB").Value = Trim(txtNoItem.Text) & "GRB"
				
155: Call rstItem.Update()
				
160: Call rstItem.Close()
165: 'UPGRADE_NOTE: Object rstItem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstItem = Nothing
				
170: rstFRS = New ADODB.Recordset
				
175: Call rstFRS.Open("SELECT * FROM GRB_Fournisseur WHERE NomFournisseur = 'FOURNI PAR LE CLIENT'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
180: iFRS = rstFRS.Fields("IDFRS").Value
				
185: Call rstFRS.Close()
190: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstFRS = Nothing
				
195: rstPieceFRS = New ADODB.Recordset
				
200: Call rstPieceFRS.Open("SELECT * FROM GRB_PiecesFRS", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
				'Ajout du fournisseur 'FOURNI PAR LE CLIENT'
205: Call rstPieceFRS.AddNew()
				
210: rstPieceFRS.Fields("IDFRS").Value = iFRS
215: rstPieceFRS.Fields("PIECE").Value = Trim(txtNoItem.Text)
220: rstPieceFRS.Fields("PRIX_LIST").Value = 0
225: rstPieceFRS.Fields("ESCOMPTE").Value = 0
230: rstPieceFRS.Fields("PRIX_NET").Value = 0
235: rstPieceFRS.Fields("DATE").Value = ConvertDate(Today)
240: rstPieceFRS.Fields("ENTRER_PAR").Value = g_sInitiale
245: rstPieceFRS.Fields("DeviseMonétaire").Value = "CAN"
250: rstPieceFRS.Fields("Type").Value = "M"
				
255: Call rstPieceFRS.Update()
				
				'Ajout du fournisseur 'SOLUTION GRB INC.'
260: Call rstPieceFRS.AddNew()
				
265: rstPieceFRS.Fields("IDFRS").Value = 717
270: rstPieceFRS.Fields("PIECE").Value = Trim(txtNoItem.Text)
275: rstPieceFRS.Fields("PRIX_LIST").Value = 0
280: rstPieceFRS.Fields("ESCOMPTE").Value = 0
285: rstPieceFRS.Fields("PRIX_NET").Value = 0
290: rstPieceFRS.Fields("DATE").Value = ConvertDate(Today)
295: rstPieceFRS.Fields("ENTRER_PAR").Value = g_sInitiale
300: rstPieceFRS.Fields("DeviseMonétaire").Value = "CAN"
305: rstPieceFRS.Fields("Type").Value = "M"
				
310: Call rstPieceFRS.Update()
				
315: Call rstPieceFRS.Close()
320: 'UPGRADE_NOTE: Object rstPieceFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstPieceFRS = Nothing
				
330: FrmCatalogueMec.m_sSelectCategorie = cmbcategorie.Text
335: FrmCatalogueMec.m_sSelectFabricant = cmbFabricant.Text
340: FrmCatalogueMec.m_sSelectNoItem = txtNoItem.Text
				
				'Remplis le combo catégorie dans le form catalogue mécanique
325: Call FrmCatalogueMec.RemplirComboCategorie()
				
				'Montre seulement les boutons pour enregistrer
345: Call FrmCatalogueMec.MontrerControles(FrmCatalogueMec.enumModeCatalogueMec.MODE_AJOUT_MODIF_MEC)
				
350: FrmCatalogueMec.txtNoItemGRB.Text = txtNoItem.Text & "GRB"
				
355: FrmCatalogueMec.txtDescriptionFR.Text = vbNullString
				
360: Call FrmCatalogueMec.BarrerChamps_piece(False)
				
				'On redonne le focus au catalogue
365: Call Me.Close()
370: End If
375: Else
380: Call MsgBox("Vous devez remplir tous les champs", MsgBoxStyle.OKOnly, "Erreur")
385: End If
		
390: Exit Sub
		
AfficherErreur: 
		
395: Call AfficherErreur("FrmaddItemMec", "cmdOK_Click", Err, Erl())
	End Sub
End Class