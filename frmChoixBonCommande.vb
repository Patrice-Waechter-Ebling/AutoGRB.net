Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmChoixBonCommande
	Inherits System.Windows.Forms.Form
	
	'Index des colonnes de lvwPiece
	Private Const I_COL_QTE As Short = 0
	Private Const I_COL_NO_ITEM As Short = 1
	Private Const I_COL_DESCRIPTION As Short = 2
	Private Const I_COL_MANUFACTURIER As Short = 3
	Private Const I_COL_FOURNISSEUR As Short = 4
	Private Const I_COL_QTE_STOCK As Short = 5
	
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
	
	'Énumération servant à savoir si le form est en anglais ou en francais
	Private Enum enumLangage
		FRANCAIS = 0
		ANGLAIS = 1
	End Enum
	
	Private m_sNoProjet As String
	Private m_frmSource As System.Windows.Forms.Form
	Private m_sType As String
	
	Private m_sIDAchat As String
	Private m_iIndexAchat As Short
	
	Private m_collPiece As Collection
	Private m_collNoLigne As Collection
	
	Private m_eLangage As enumLangage
	
	Private m_collNoLigneFRS As Collection
	Private m_collPrixList As Collection
	Private m_collPrixOrigine As Collection
	Private m_collPrixNet As Collection
	Private m_collEscompte As Collection
	Private m_collPrixSP As Collection
	
	Public Sub AfficherAchat(ByVal sIDAchat As String, ByVal iIndexAchat As Short, ByVal eType As ModuleMain.enumCatalogue)
		
5: On Error GoTo AfficherErreur
		
10: m_sIDAchat = sIDAchat
		
15: m_iIndexAchat = iIndexAchat
		
20: m_frmSource = frmAchat
		
25: cmdSelectAll.Visible = True
		
30: If eType = ModuleMain.enumCatalogue.ELECTRIQUE Then
35: m_sType = "E"
40: Else
45: m_sType = "M"
50: End If
		
55: Call lvwPiece.Columns.RemoveAt(I_COL_QTE_STOCK)
		
60: Call RemplirListViewPieceAchat()
		
65: Call Me.ShowDialog()
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmChoixBonCommande", "AfficherAchat", Err, Erl())
	End Sub
	
	Public Sub Afficher(ByVal sNoProjet As String, ByVal frmSource As System.Windows.Forms.Form, ByVal iLangage As Short)
		
5: On Error GoTo AfficherErreur
		
		'Méthode pour afficher le form
10: m_sNoProjet = sNoProjet
		
15: m_eLangage = iLangage
		
20: m_frmSource = frmSource
		
25: If frmSource.Name = "FrmProjSoumElec" Then
30: m_sType = "E"
35: Else
40: m_sType = "M"
45: End If
		
50: Call RemplirListViewPieces()
		
55: Call Me.ShowDialog()
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmChoixBonCommande", "Afficher", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewPieceAchat()
		
5: On Error GoTo AfficherErreur
		
		'Remplis les pièces de l'achat avec la BD
10: Dim rstAchat As ADODB.Recordset
15: Dim rstFRS As ADODB.Recordset
20: Dim itmAchat As System.Windows.Forms.ListViewItem
25: Dim lColor As Integer
		
30: Call lvwPiece.Items.Clear()
		
35: rstFRS = New ADODB.Recordset
40: rstAchat = New ADODB.Recordset
		
45: Call rstAchat.Open("SELECT * FROM GRB_Achat_Pieces WHERE IDAchat = '" & m_sIDAchat & "' AND IndexAchat = " & m_iIndexAchat & " ORDER BY NuméroLigne", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
50: Do While Not rstAchat.EOF
55: If rstAchat.Fields("Recu").Value = True Then
60: lColor = COLOR_GRIS 'Gris
65: Else
70: If rstAchat.Fields("Commandé").Value = True Then
75: lColor = COLOR_ORANGE 'COLOR_ORANGE
80: Else
85: lColor = COLOR_NOIR
90: End If
95: End If
			
100: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPiece.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmAchat = lvwPiece.Items.Add()
			
			'Quantité
105: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("Qté").Value) Then
110: itmAchat.Text = rstAchat.Fields("Qté").Value
115: Else
120: itmAchat.Text = vbNullString
125: End If
			
130: itmAchat.ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
135: itmAchat.Tag = rstAchat.Fields("DateRéception").Value
			
			'Numéro d'item
140: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("PIECE").Value) Then
145: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_NO_ITEM Then
					itmAchat.SubItems(I_COL_NO_ITEM).Text = rstAchat.Fields("PIECE").Value
				Else
					itmAchat.SubItems.Insert(I_COL_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("PIECE").Value))
				End If
150: Else
155: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_NO_ITEM Then
					itmAchat.SubItems(I_COL_NO_ITEM).Text = vbNullString
				Else
					itmAchat.SubItems.Insert(I_COL_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
160: End If
			
165: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_NO_ITEM).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
170: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_NO_ITEM).Tag = rstAchat.Fields("NuméroLigne").Value
			
			'Description en francais
175: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("DESC_FR").Value) Then
180: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_DESCRIPTION Then
					itmAchat.SubItems(I_COL_DESCRIPTION).Text = rstAchat.Fields("DESC_FR").Value
				Else
					itmAchat.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("DESC_FR").Value))
				End If
185: Else
190: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_DESCRIPTION Then
					itmAchat.SubItems(I_COL_DESCRIPTION).Text = vbNullString
				Else
					itmAchat.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
195: End If
			
200: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_DESCRIPTION).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
			'On met la description en anglais dans le tag de la description en francais
205: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("Desc_EN").Value) Then
210: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_DESCRIPTION).Tag = rstAchat.Fields("Desc_EN").Value
215: Else
220: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmAchat.SubItems.Item(I_COL_DESCRIPTION).Tag = vbNullString
225: End If
			
			'Fabricant
230: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("Manufact").Value) Then
235: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_MANUFACTURIER Then
					itmAchat.SubItems(I_COL_MANUFACTURIER).Text = rstAchat.Fields("Manufact").Value
				Else
					itmAchat.SubItems.Insert(I_COL_MANUFACTURIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstAchat.Fields("Manufact").Value))
				End If
240: Else
245: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_MANUFACTURIER Then
					itmAchat.SubItems(I_COL_MANUFACTURIER).Text = vbNullString
				Else
					itmAchat.SubItems.Insert(I_COL_MANUFACTURIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
250: End If
			
255: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_MANUFACTURIER).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
260: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_MANUFACTURIER).Tag = rstAchat.Fields("NoRetour").Value
			
			'Fournisseur
265: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstAchat.Fields("IDFRS").Value) Then
270: If rstAchat.Fields("IDFRS").Value <> 0 Then
275: Call rstFRS.Open("SELECT NomFournisseur FROM GRB_Fournisseur WHERE IDFRS = " & rstAchat.Fields("IDFRS").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
					'On affiche le nom dans la colonne
280: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_FOURNISSEUR Then
						itmAchat.SubItems(I_COL_FOURNISSEUR).Text = rstFRS.Fields("NomFournisseur").Value
					Else
						itmAchat.SubItems.Insert(I_COL_FOURNISSEUR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstFRS.Fields("NomFournisseur").Value))
					End If
					
					'On affiche l'Id dans le tag
285: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmAchat.SubItems.Item(I_COL_FOURNISSEUR).Tag = rstAchat.Fields("IDFRS").Value
					
290: Call rstFRS.Close()
295: Else
300: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmAchat.SubItems.Count > I_COL_FOURNISSEUR Then
						itmAchat.SubItems(I_COL_FOURNISSEUR).Text = " "
					Else
						itmAchat.SubItems.Insert(I_COL_FOURNISSEUR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
					End If
305: End If
310: Else
315: 'UPGRADE_WARNING: Lower bound of collection itmAchat has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmAchat.SubItems.Count > I_COL_FOURNISSEUR Then
					itmAchat.SubItems(I_COL_FOURNISSEUR).Text = vbNullString
				Else
					itmAchat.SubItems.Insert(I_COL_FOURNISSEUR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
320: End If
			
325: 'UPGRADE_WARNING: Lower bound of collection itmAchat.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmAchat.SubItems.Item(I_COL_FOURNISSEUR).ForeColor = System.Drawing.ColorTranslator.FromOle(lColor)
			
330: Call rstAchat.MoveNext()
335: Loop 
		
340: Call rstAchat.Close()
345: 'UPGRADE_NOTE: Object rstAchat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstAchat = Nothing
		
350: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
		
355: Exit Sub
		
AfficherErreur: 
		
360: Call AfficherErreur("frmChoixBonCommande", "RemplirListViewAchat", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewPieces()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le ListView selon le no. du projet
10: Dim rstPieces As ADODB.Recordset
15: Dim rstSection As ADODB.Recordset
20: Dim rstInventaire As ADODB.Recordset
25: Dim rstFRS As ADODB.Recordset
30: Dim itmPieces As System.Windows.Forms.ListViewItem
35: Dim iCompteur As Short
40: Dim bPremierEnr As Boolean
45: Dim iOrdreSection As Short
50: Dim sSousSection As String
55: Dim sSection As String
60: Dim lCouleur As Integer
		
65: bPremierEnr = True
		
70: If m_eLangage = enumLangage.ANGLAIS Then
75: sSection = "NomSectionEN"
80: Else
85: sSection = "NomSectionFR"
90: End If
		
95: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwPiece.Sorted was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		lvwPiece.Sorted = False
		
100: rstFRS = New ADODB.Recordset
105: rstPieces = New ADODB.Recordset
110: rstSection = New ADODB.Recordset
115: rstInventaire = New ADODB.Recordset
		
		'Ouverture du recordset
120: Call rstPieces.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = '" & m_sNoProjet & "' AND Type = '" & m_sType & "' AND PieceExtraChargeable = False AND PieceExtraNonChargeable = False ORDER BY NuméroLigne", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
125: Do While Not rstPieces.EOF
130: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPiece.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmPieces = lvwPiece.Items.Add()
			
			'Si c'est le premier enregistrement, il faut ajouter la section et la sous-section
135: If bPremierEnr = True Then
140: sSousSection = rstPieces.Fields("SousSection").Value
145: iOrdreSection = rstPieces.Fields("OrdreSection").Value
				
				'Pour avoir le nom de la section
				'Si c'est un projet électrique
150: If m_sType = "E" Then
155: Call rstSection.Open("SELECT " & sSection & " FROM GRB_SoumProjSectionElec WHERE IDSection = " & rstPieces.Fields("IDSection").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
160: Else
165: Call rstSection.Open("SELECT " & sSection & " FROM GRB_SoumProjSectionMec WHERE IDSection = " & rstPieces.Fields("IDSection").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
170: End If
				
				'Ajout du nom de la section
175: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSection.Fields(sSection).Value) Then
180: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_NO_ITEM Then
						itmPieces.SubItems(I_COL_NO_ITEM).Text = rstSection.Fields(sSection).Value
					Else
						itmPieces.SubItems.Insert(I_COL_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstSection.Fields(sSection).Value))
					End If
185: Else
190: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_NO_ITEM Then
						itmPieces.SubItems(I_COL_NO_ITEM).Text = vbNullString
					Else
						itmPieces.SubItems.Insert(I_COL_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
195: End If
				
200: 'UPGRADE_WARNING: Lower bound of collection itmPieces.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmPieces.SubItems.Item(I_COL_NO_ITEM).Font = VB6.FontChangeBold(itmPieces.SubItems.Item(I_COL_NO_ITEM).Font, True)
				
205: Call rstSection.Close()
				
210: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPiece.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmPieces = lvwPiece.Items.Add()
				
				'Ajout du nom de la sous-section
215: If sSousSection = "PAS DE SOUS-SECTION" Then
220: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
						itmPieces.SubItems(I_COL_DESCRIPTION).Text = vbNullString
					Else
						itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
225: Else
230: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
						itmPieces.SubItems(I_COL_DESCRIPTION).Text = sSousSection
					Else
						itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sSousSection))
					End If
235: End If
				
240: itmPieces.Tag = "PAS UNE SECTION"
				
245: 'UPGRADE_WARNING: Lower bound of collection itmPieces.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmPieces.SubItems.Item(I_COL_DESCRIPTION).Font = VB6.FontChangeBold(itmPieces.SubItems.Item(I_COL_DESCRIPTION).Font, True)
				
250: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPiece.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmPieces = lvwPiece.Items.Add()
				
255: bPremierEnr = False
260: Else
				'Si c'est pas le premier enregistrement, il faut vérifier avec l'ancienne section
265: If iOrdreSection <> rstPieces.Fields("OrdreSection").Value Then
270: iOrdreSection = rstPieces.Fields("OrdreSection").Value
					
275: If m_sType = "E" Then
280: Call rstSection.Open("SELECT " & sSection & " FROM GRB_SoumProjSectionElec WHERE IDSection = " & rstPieces.Fields("IDSection").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
285: Else
290: Call rstSection.Open("SELECT " & sSection & " FROM GRB_SoumProjSectionMec WHERE IDSection = " & rstPieces.Fields("IDSection").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
295: End If
					
300: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstSection.Fields(sSection).Value) Then
305: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmPieces.SubItems.Count > I_COL_NO_ITEM Then
							itmPieces.SubItems(I_COL_NO_ITEM).Text = rstSection.Fields(sSection).Value
						Else
							itmPieces.SubItems.Insert(I_COL_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstSection.Fields(sSection).Value))
						End If
310: Else
315: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmPieces.SubItems.Count > I_COL_NO_ITEM Then
							itmPieces.SubItems(I_COL_NO_ITEM).Text = vbNullString
						Else
							itmPieces.SubItems.Insert(I_COL_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
						End If
320: End If
					
325: 'UPGRADE_WARNING: Lower bound of collection itmPieces.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmPieces.SubItems.Item(I_COL_NO_ITEM).Font = VB6.FontChangeBold(itmPieces.SubItems.Item(I_COL_NO_ITEM).Font, True)
					
330: Call rstSection.Close()
					
335: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPiece.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					itmPieces = lvwPiece.Items.Add()
					
340: sSousSection = rstPieces.Fields("SousSection").Value
					
345: If sSousSection = "PAS DE SOUS-SECTION" Then
350: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
							itmPieces.SubItems(I_COL_DESCRIPTION).Text = vbNullString
						Else
							itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
						End If
355: Else
360: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
							itmPieces.SubItems(I_COL_DESCRIPTION).Text = rstPieces.Fields("SousSection").Value
						Else
							itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieces.Fields("SousSection").Value))
						End If
365: End If
					
370: itmPieces.Tag = "PAS UNE SECTION"
					
375: 'UPGRADE_WARNING: Lower bound of collection itmPieces.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmPieces.SubItems.Item(I_COL_DESCRIPTION).Font = VB6.FontChangeBold(itmPieces.SubItems.Item(I_COL_DESCRIPTION).Font, True)
					
380: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPiece.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					itmPieces = lvwPiece.Items.Add()
385: Else
					'il faut vérifier avec l'ancienne sous-section
390: If sSousSection <> rstPieces.Fields("SousSection").Value Then
395: sSousSection = rstPieces.Fields("SousSection").Value
						
400: If sSousSection = "PAS DE SOUS-SECTION" Then
405: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
								itmPieces.SubItems(I_COL_DESCRIPTION).Text = vbNullString
							Else
								itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
							End If
410: Else
415: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
								itmPieces.SubItems(I_COL_DESCRIPTION).Text = sSousSection
							Else
								itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sSousSection))
							End If
420: End If
						
425: 'UPGRADE_WARNING: Lower bound of collection itmPieces.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						itmPieces.SubItems.Item(I_COL_DESCRIPTION).Font = VB6.FontChangeBold(itmPieces.SubItems.Item(I_COL_DESCRIPTION).Font, True)
						
430: itmPieces.Tag = "PAS UNE SECTION"
						
435: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPiece.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						itmPieces = lvwPiece.Items.Add()
440: End If
445: End If
450: End If
			
455: If rstPieces.Fields("Commandé").Value = True Then
460: lCouleur = COLOR_ORANGE
465: Else
470: If rstPieces.Fields("Recu").Value = True Then
475: lCouleur = COLOR_GRIS
480: Else
485: lCouleur = COLOR_NOIR
490: End If
495: End If
			
			'Quantité
500: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieces.Fields("Qté").Value) Then
505: itmPieces.Text = rstPieces.Fields("Qté").Value
510: Else
515: itmPieces.Text = vbNullString
520: End If
			
525: itmPieces.ForeColor = System.Drawing.ColorTranslator.FromOle(lCouleur)
			
530: itmPieces.Tag = "PAS UNE SECTION"
			
			'Numéro d'item
535: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieces.Fields("NumItem").Value) Then
540: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPieces.SubItems.Count > I_COL_NO_ITEM Then
					itmPieces.SubItems(I_COL_NO_ITEM).Text = rstPieces.Fields("NumItem").Value
				Else
					itmPieces.SubItems.Insert(I_COL_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieces.Fields("NumItem").Value))
				End If
545: Else
550: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPieces.SubItems.Count > I_COL_NO_ITEM Then
					itmPieces.SubItems(I_COL_NO_ITEM).Text = vbNullString
				Else
					itmPieces.SubItems.Insert(I_COL_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
555: End If
			
560: 'UPGRADE_WARNING: Lower bound of collection itmPieces.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmPieces.SubItems.Item(I_COL_NO_ITEM).ForeColor = System.Drawing.ColorTranslator.FromOle(lCouleur)
			
565: 'UPGRADE_WARNING: Lower bound of collection itmPieces.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmPieces.SubItems.Item(I_COL_NO_ITEM).Tag = rstPieces.Fields("NuméroLigne").Value
			
570: If m_eLangage = enumLangage.FRANCAIS Then
				'Description en francais
575: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPieces.Fields("Desc_FR").Value) Then
580: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
						itmPieces.SubItems(I_COL_DESCRIPTION).Text = rstPieces.Fields("Desc_FR").Value
					Else
						itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieces.Fields("Desc_FR").Value))
					End If
585: Else
590: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
						itmPieces.SubItems(I_COL_DESCRIPTION).Text = vbNullString
					Else
						itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
595: End If
600: Else
				'Description en anglais
605: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPieces.Fields("Desc_EN").Value) Then
610: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
						itmPieces.SubItems(I_COL_DESCRIPTION).Text = rstPieces.Fields("Desc_EN").Value
					Else
						itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieces.Fields("Desc_EN").Value))
					End If
615: Else
620: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
						itmPieces.SubItems(I_COL_DESCRIPTION).Text = vbNullString
					Else
						itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
625: End If
630: End If
			
635: 'UPGRADE_WARNING: Lower bound of collection itmPieces.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmPieces.SubItems.Item(I_COL_DESCRIPTION).ForeColor = System.Drawing.ColorTranslator.FromOle(lCouleur)
			
			'Fabricant
640: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieces.Fields("Manufact").Value) Then
645: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPieces.SubItems.Count > I_COL_MANUFACTURIER Then
					itmPieces.SubItems(I_COL_MANUFACTURIER).Text = rstPieces.Fields("Manufact").Value
				Else
					itmPieces.SubItems.Insert(I_COL_MANUFACTURIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieces.Fields("Manufact").Value))
				End If
650: Else
655: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPieces.SubItems.Count > I_COL_MANUFACTURIER Then
					itmPieces.SubItems(I_COL_MANUFACTURIER).Text = vbNullString
				Else
					itmPieces.SubItems.Insert(I_COL_MANUFACTURIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
660: End If
			
665: 'UPGRADE_WARNING: Lower bound of collection itmPieces.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmPieces.SubItems.Item(I_COL_MANUFACTURIER).ForeColor = System.Drawing.ColorTranslator.FromOle(lCouleur)
			
			'Fournisseur
670: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieces.Fields("IDFRS").Value) And rstPieces.Fields("IDFRS").Value > 0 Then
675: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPieces.SubItems(I_COL_NO_ITEM).Text <> "Texte" Then
680: Call rstFRS.Open("SELECT NomFournisseur FROM GRB_Fournisseur WHERE IDFRS = " & rstPieces.Fields("IDFRS").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
					'On affiche le nom dans la colonne
685: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_FOURNISSEUR Then
						itmPieces.SubItems(I_COL_FOURNISSEUR).Text = rstFRS.Fields("NomFournisseur").Value
					Else
						itmPieces.SubItems.Insert(I_COL_FOURNISSEUR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstFRS.Fields("NomFournisseur").Value))
					End If
					
690: Call rstFRS.Close()
695: End If
700: Else
705: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPieces.SubItems.Count > I_COL_FOURNISSEUR Then
					itmPieces.SubItems(I_COL_FOURNISSEUR).Text = vbNullString
				Else
					itmPieces.SubItems.Insert(I_COL_FOURNISSEUR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
710: End If
			
715: 'UPGRADE_WARNING: Lower bound of collection itmPieces.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmPieces.SubItems.Item(I_COL_FOURNISSEUR).ForeColor = System.Drawing.ColorTranslator.FromOle(lCouleur)
			
720: If m_sType = "E" Then
725: Call rstInventaire.Open("SELECT * FROM GRB_InventaireElec WHERE NoItem = '" & Replace(rstPieces.Fields("NumItem").Value, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
730: Else
735: Call rstInventaire.Open("SELECT * FROM GRB_InventaireMec WHERE NoItem = '" & Replace(rstPieces.Fields("NumItem").Value, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
740: End If
			
745: If Not rstInventaire.EOF Then
750: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPieces.SubItems.Count > I_COL_QTE_STOCK Then
					itmPieces.SubItems(I_COL_QTE_STOCK).Text = rstInventaire.Fields("QuantitéStock").Value
				Else
					itmPieces.SubItems.Insert(I_COL_QTE_STOCK, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstInventaire.Fields("QuantitéStock").Value))
				End If
755: End If
			
760: Call rstInventaire.Close()
			
765: Call rstPieces.MoveNext()
770: Loop 
		
775: Call rstPieces.Close()
780: 'UPGRADE_NOTE: Object rstPieces may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPieces = Nothing
		
785: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
790: 'UPGRADE_NOTE: Object rstInventaire may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstInventaire = Nothing
795: 'UPGRADE_NOTE: Object rstSection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstSection = Nothing
		
800: Exit Sub
		
AfficherErreur: 
		
805: Call AfficherErreur("frmChoixBonCommande", "RemplirListViewPieces", Err, Erl())
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixBonCommande", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdCommander_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCommander.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim bChecked As Boolean
15: Dim iCompteur As Short
20: Dim sNoBC As String
25: Dim rstProjet As ADODB.Recordset
		
30: bChecked = False
		
35: For iCompteur = 1 To lvwPiece.Items.Count
40: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwPiece.Items.Item(iCompteur).Checked = True Then
45: bChecked = True
				
50: Exit For
55: End If
60: Next 
		
65: If bChecked = True Then
70: m_collPiece = New Collection
75: m_collNoLigne = New Collection
			
80: If m_frmSource.Name <> "frmAchat" Then
85: Call ModifierFournisseurBD()
90: End If
			
95: For iCompteur = 1 To lvwPiece.Items.Count
100: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwPiece.Items.Item(iCompteur).Checked = True Then
105: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call m_collPiece.Add(lvwPiece.Items.Item(iCompteur).SubItems(I_COL_NO_ITEM).Text)
110: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call m_collNoLigne.Add(lvwPiece.Items.Item(iCompteur).SubItems.Item(I_COL_NO_ITEM).Tag)
115: End If
120: Next 
			
125: If m_frmSource.Name <> "frmAchat" Then
130: rstProjet = New ADODB.Recordset
				
135: If m_sType = "E" Then
140: Call rstProjet.Open("SELECT ProchaineCommande FROM GRB_ProjetElec WHERE IDProjet = '" & m_sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
145: Else
150: Call rstProjet.Open("SELECT ProchaineCommande FROM GRB_ProjetMec WHERE IDProjet = '" & m_sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
155: End If
				
160: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstProjet.Fields("ProchaineCommande").Value) Then
165: sNoBC = m_sNoProjet & "-" & VB.Right("00" & rstProjet.Fields("ProchaineCommande").Value, 3)
170: Else
175: sNoBC = m_sNoProjet
180: End If
				
185: Call rstProjet.Close()
190: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstProjet = Nothing
195: Else
200: sNoBC = m_sIDAchat & "-" & VB.Right("00" & m_iIndexAchat, 3)
205: End If
			
210: If sNoBC <> vbNullString Then
215: If m_frmSource.Name = "FrmProjSoumElec" Then
220: Call frmBonCommande.AfficherFormProjetAchat(m_sNoProjet, sNoBC, m_collPiece, m_collNoLigne, frmBonCommande.enumFormSource.I_PROJET_ELEC, m_eLangage)
225: Else
230: If m_frmSource.Name = "FrmProjSoumMec" Then
235: Call frmBonCommande.AfficherFormProjetAchat(m_sNoProjet, sNoBC, m_collPiece, m_collNoLigne, frmBonCommande.enumFormSource.I_PROJET_MEC, m_eLangage)
240: Else
245: If m_sType = "E" Then
250: Call frmBonCommande.AfficherFormProjetAchat(m_sIDAchat & "-" & VB.Right("00" & m_iIndexAchat, 3), sNoBC, m_collPiece, m_collNoLigne, frmBonCommande.enumFormSource.I_ACHAT_ELEC, 0)
255: Else
							
260: Call frmBonCommande.AfficherFormProjetAchat(m_sIDAchat & "-" & VB.Right("00" & m_iIndexAchat, 3), sNoBC, m_collPiece, m_collNoLigne, frmBonCommande.enumFormSource.I_ACHAT_MEC, 0)
265: End If
270: End If
275: End If
				
280: Call Me.Close()
285: End If
290: Else
295: Call MsgBox("Aucune pièce n'est sélectionnée!", MsgBoxStyle.OKOnly, "Erreur")
300: End If
		
305: Exit Sub
		
AfficherErreur: 
		
310: Call AfficherErreur("frmChoixBonCommande", "cmdCommander_Click", Err, Erl())
	End Sub
	
	Private Sub cmdSelectAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelectAll.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: For iCompteur = 1 To lvwPiece.Items.Count
20: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwPiece.Items.Item(iCompteur).SubItems(I_COL_NO_ITEM).Text <> "Texte" And lvwPiece.Items.Item(iCompteur).SubItems(I_COL_NO_ITEM).Text <> "Text" Then
25: If m_frmSource.Name <> "frmAchat" Then
30: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvwPiece.Items.Item(iCompteur).Tag <> vbNullString Then
35: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If lvwPiece.Items.Item(iCompteur).SubItems(I_COL_NO_ITEM).Text <> vbNullString Then
40: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If CDbl(lvwPiece.Items.Item(iCompteur).Text) > 0 Then
45: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								lvwPiece.Items.Item(iCompteur).Checked = True
50: End If
55: End If
60: End If
65: Else
70: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If CDbl(lvwPiece.Items.Item(iCompteur).Text) > 0 Then
75: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						lvwPiece.Items.Item(iCompteur).Checked = True
80: End If
85: End If
90: End If
95: Next 
		
100: Exit Sub
		
AfficherErreur: 
		
105: Call AfficherErreur("frmChoixBonCommande", "cmdSelectAll_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDeSelectAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDeSelectAll.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: For iCompteur = 1 To lvwPiece.Items.Count
20: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lvwPiece.Items.Item(iCompteur).Checked = False
25: Next 
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixBonCommande", "cmdDeselectAll_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixBonCommande_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: m_collNoLigneFRS = New Collection
15: m_collEscompte = New Collection
20: m_collPrixList = New Collection
25: m_collPrixNet = New Collection
30: m_collPrixOrigine = New Collection
35: m_collPrixSP = New Collection
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmChoixBonCommande", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub lvwPiece_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwPiece.DoubleClick
		
5: On Error GoTo AfficherErreur
		
		
10: If m_frmSource.Name <> "frmAchat" Then
			'Si ce n'est pas une section
15: If lvwPiece.FocusedItem.Tag <> "" Then
				'Si ce n'est pas une sous-section
20: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwPiece.FocusedItem.SubItems(I_COL_NO_ITEM).Text <> "" Then
25: Call ChangerFournisseur()
30: End If
35: End If
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmChoixBonCommande", "lvwPiece_DblClick", Err, Erl())
	End Sub
	
	Private Sub lvwPiece_ItemCheck(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ItemCheckEventArgs) Handles lvwPiece.ItemCheck
		Dim Item As System.Windows.Forms.ListViewItem = lvwPiece.Items(eventArgs.Index)
		
5: On Error GoTo AfficherErreur
		
10: If m_frmSource.Name <> "frmAchat" Then
			'Si c'est du texte
15: 'UPGRADE_WARNING: Lower bound of collection Item has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If Item.SubItems(I_COL_NO_ITEM).Text = "Texte" Or Item.Tag = vbNullString Or Item.SubItems(I_COL_NO_ITEM).Text = vbNullString Then
				'On enlève le check
20: Item.Checked = False
25: Else
30: If CDbl(Replace(Item.Text, "*", "")) <= 0 Then
35: 'On enlève le check
40: Item.Checked = False
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmChoixBonCommande", "lvwPiece_ItemCheck", Err, Erl())
	End Sub
	
	Private Sub ChangerFournisseur()
		
5: On Error GoTo AfficherErreur
		
10: Call AfficherListeFournisseurs()
		
15: If lvwfournisseur.Items.Count = 0 Then
20: Call MsgBox("Il n'y a aucun fournisseur pour cette pièce!", MsgBoxStyle.OKOnly, "Erreur")
			
25: Exit Sub
30: Else
35: frafournisseur.Visible = True
40: End If
		
45: Exit Sub
		
AfficherErreur: 
		
50: Call AfficherErreur("frmChoixBonCommande", "ChangerFournisseur", Err, Erl())
	End Sub
	
	Private Sub AfficherListeFournisseurs()
		
5: On Error GoTo AfficherErreur
		
		'Méthode qui sert à afficher la liste des fournisseurs
		'Affiche le frame seulement s'il y a des items dans le ListView
10: Call RemplirListViewFournisseur()
		
15: If lvwfournisseur.Items.Count > 1 Then
25: frafournisseur.Visible = True
30: Call lvwfournisseur.Focus()
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmChoixBonCommande", "AfficherListeFournisseurs", Err, Erl())
	End Sub
	
	Private Sub lvwFournisseur_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwFournisseur.DoubleClick
		
5: On Error GoTo AfficherErreur
		
10: Call ChoisirFournisseur()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixBonCommande", "lvwFournisseur_DblClick", Err, Erl())
	End Sub
	
	Private Sub ChoisirFournisseur()
		
5: On Error GoTo AfficherErreur
		
10: Dim itmBC As System.Windows.Forms.ListViewItem
15: Dim itmFRS As System.Windows.Forms.ListViewItem
		
20: itmBC = lvwPiece.FocusedItem
25: itmFRS = lvwfournisseur.FocusedItem
		
30: 'UPGRADE_WARNING: Lower bound of collection itmBC has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If itmBC.SubItems.Count > I_COL_FOURNISSEUR Then
			itmBC.SubItems(I_COL_FOURNISSEUR).Text = itmFRS.Text
		Else
			itmBC.SubItems.Insert(I_COL_FOURNISSEUR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, itmFRS.Text))
		End If
		
35: 'UPGRADE_WARNING: Lower bound of collection itmBC.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		itmBC.SubItems.Item(I_COL_FOURNISSEUR).Tag = itmFRS.Tag
		
40: 'UPGRADE_WARNING: Lower bound of collection itmBC.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		Call m_collNoLigneFRS.Add(itmBC.SubItems.Item(I_COL_NO_ITEM).Tag)
45: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		Call m_collEscompte.Add(itmFRS.SubItems(I_COL_FRS_ESCOMPTE).Text)
50: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		Call m_collPrixList.Add(itmFRS.SubItems(I_COL_FRS_PRIX_LIST).Text)
55: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		Call m_collPrixNet.Add(itmFRS.SubItems(I_COL_FRS_PRIX_NET).Text)
60: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		Call m_collPrixOrigine.Add(itmFRS.SubItems.Item(I_COL_FRS_PRIX_LIST).Tag)
65: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		Call m_collPrixSP.Add(itmFRS.SubItems(I_COL_FRS_PRIX_SP).Text)
		
		'On cache le listview
70: frafournisseur.Visible = False
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmChoixBonCommande", "ChoisirFournisseur", Err, Erl())
	End Sub
	
	Private Sub cmdOKFRS_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOKFRS.Click
		
5: On Error GoTo AfficherErreur
		
10: Call ChoisirFournisseur()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixBonCommande", "cmdOKFRS_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnulerFRS_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnulerFRS.Click
		
5: On Error GoTo AfficherErreur
		
10: frafournisseur.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixBonCommande", "cmdAnnulerFRS_Click", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewFournisseur()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le listview des distributeur pour une pièce choisie
10: Dim rstPieceFRS As ADODB.Recordset
15: Dim rstContact As ADODB.Recordset
20: Dim rstFRS As ADODB.Recordset
25: Dim iCompteur As Short
30: Dim itmFRS As System.Windows.Forms.ListViewItem
35: Dim iNoClient As Short
40: Dim sDevise As String
		
		'vide le lister
45: Call lvwfournisseur.Items.Clear()
		
50: rstPieceFRS = New ADODB.Recordset
55: rstContact = New ADODB.Recordset
60: rstFRS = New ADODB.Recordset
		
65: Call rstFRS.Open("SELECT IDFRS FROM GRB_Fournisseur WHERE NomFournisseur = 'FOURNI PAR LE CLIENT'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
70: iNoClient = rstFRS.Fields("IDFRS").Value
		
75: Call rstFRS.Close()
80: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
		
85: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		Call rstPieceFRS.Open("SELECT GRB_PiecesFRS.*, GRB_Fournisseur.NomFournisseur FROM GRB_PiecesFRS INNER JOIN GRB_Fournisseur ON GRB_PiecesFRS.IDFRS = GRB_Fournisseur.IDFRS WHERE PIECE = '" & Replace(lvwPiece.FocusedItem.SubItems(I_COL_NO_ITEM).Text, "'", "''") & "' AND Type = '" & m_sType & "' ORDER BY PrixReel", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'tant il y a des fournisseur de la piece , ajoute dans lister
90: Do While Not rstPieceFRS.EOF
			'on change la couleur de l'enregistrement selon la devise monétaire.
			'CAN = rouge, USA ou ESP = bleu
95: If rstPieceFRS.Fields("DeviseMonétaire").Value = "CAN" Then
100: sDevise = "CAN"
105: Else
110: If rstPieceFRS.Fields("DeviseMonétaire").Value = "USA" Then
115: sDevise = "USA"
120: Else
125: sDevise = "SPA"
130: End If
135: End If
			
140: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwfournisseur.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmFRS = lvwfournisseur.Items.Add()
			
145: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmFRS.SubItems.Count > I_COL_FRS_PRIX_LIST Then
				itmFRS.SubItems(I_COL_FRS_PRIX_LIST).Text = " "
			Else
				itmFRS.SubItems.Insert(I_COL_FRS_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
			End If
150: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmFRS.SubItems.Count > I_COL_FRS_ESCOMPTE Then
				itmFRS.SubItems(I_COL_FRS_ESCOMPTE).Text = " "
			Else
				itmFRS.SubItems.Insert(I_COL_FRS_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
			End If
155: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmFRS.SubItems.Count > I_COL_FRS_PRIX_NET Then
				itmFRS.SubItems(I_COL_FRS_PRIX_NET).Text = " "
			Else
				itmFRS.SubItems.Insert(I_COL_FRS_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
			End If
160: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmFRS.SubItems.Count > I_COL_FRS_PRIX_SP Then
				itmFRS.SubItems(I_COL_FRS_PRIX_SP).Text = " "
			Else
				itmFRS.SubItems.Insert(I_COL_FRS_PRIX_SP, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
			End If
			
			'Nom du FRS
165: itmFRS.Text = rstPieceFRS.Fields("NomFournisseur").Value
			
170: itmFRS.Tag = rstPieceFRS.Fields("IDFRS").Value
			
			'Personne ressource
175: If Trim(rstPieceFRS.Fields("PERS_RESS").Value) <> vbNullString Then
180: Call rstContact.Open("SELECT NomContact FROM GRB_Contact WHERE IDContact = " & rstPieceFRS.Fields("PERS_RESS").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
185: If Not rstContact.EOF Then
190: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmFRS.SubItems.Count > I_COL_FRS_PERS_RESS Then
						itmFRS.SubItems(I_COL_FRS_PERS_RESS).Text = rstContact.Fields("NomContact").Value
					Else
						itmFRS.SubItems.Insert(I_COL_FRS_PERS_RESS, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstContact.Fields("NomContact").Value))
					End If
195: End If
				
200: Call rstContact.Close()
205: End If
			
			'Date
210: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieceFRS.Fields("Date").Value) Then
215: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_DATE Then
					itmFRS.SubItems(I_COL_FRS_DATE).Text = rstPieceFRS.Fields("Date").Value
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_DATE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieceFRS.Fields("Date").Value))
				End If
220: Else
225: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_DATE Then
					itmFRS.SubItems(I_COL_FRS_DATE).Text = vbNullString
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_DATE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
230: End If
			
			'Entrer par
235: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieceFRS.Fields("Entrer_Par").Value) Then
240: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_ENTRER_PAR Then
					itmFRS.SubItems(I_COL_FRS_ENTRER_PAR).Text = rstPieceFRS.Fields("Entrer_Par").Value
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_ENTRER_PAR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieceFRS.Fields("Entrer_Par").Value))
				End If
245: Else
250: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_ENTRER_PAR Then
					itmFRS.SubItems(I_COL_FRS_ENTRER_PAR).Text = vbNullString
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_ENTRER_PAR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
255: End If
			
			'Valide
260: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieceFRS.Fields("Valide").Value) Then
265: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_VALIDE Then
					itmFRS.SubItems(I_COL_FRS_VALIDE).Text = rstPieceFRS.Fields("Valide").Value
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_VALIDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieceFRS.Fields("Valide").Value))
				End If
270: Else
275: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_VALIDE Then
					itmFRS.SubItems(I_COL_FRS_VALIDE).Text = vbNullString
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_VALIDE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
280: End If
			
			'Prix listé
285: If rstPieceFRS.Fields("PRIX_LIST").Value <> vbNullString Then
290: If sDevise = "USA" Then
295: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmFRS.SubItems.Count > I_COL_FRS_PRIX_LIST Then
						itmFRS.SubItems(I_COL_FRS_PRIX_LIST).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(rstPieceFRS.Fields("PRIX_LIST").Value), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
					Else
						itmFRS.SubItems.Insert(I_COL_FRS_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(rstPieceFRS.Fields("PRIX_LIST").Value), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
					End If
300: Else
305: If sDevise = "SPA" Then
310: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmFRS.SubItems.Count > I_COL_FRS_PRIX_LIST Then
							itmFRS.SubItems(I_COL_FRS_PRIX_LIST).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(rstPieceFRS.Fields("PRIX_LIST").Value), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
						Else
							itmFRS.SubItems.Insert(I_COL_FRS_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(rstPieceFRS.Fields("PRIX_LIST").Value), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
						End If
315: Else
320: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmFRS.SubItems.Count > I_COL_FRS_PRIX_LIST Then
							itmFRS.SubItems(I_COL_FRS_PRIX_LIST).Text = Conversion_Renamed(System.Math.Round(CDbl(Replace(rstPieceFRS.Fields("PRIX_LIST").Value, ".", ",")), 4), ModuleMain.enumConvert.MODE_ARGENT, 4)
						Else
							itmFRS.SubItems.Insert(I_COL_FRS_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(System.Math.Round(CDbl(Replace(rstPieceFRS.Fields("PRIX_LIST").Value, ".", ",")), 4), ModuleMain.enumConvert.MODE_ARGENT, 4)))
						End If
325: End If
330: End If
335: End If
			
			'Escompte
340: If rstPieceFRS.Fields("ESCOMPTE").Value <> vbNullString Then
345: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_ESCOMPTE Then
					itmFRS.SubItems(I_COL_FRS_ESCOMPTE).Text = Conversion_Renamed(CDbl(Replace(Replace(rstPieceFRS.Fields("ESCOMPTE").Value, "_", vbNullString), ".", ",")) * 100, ModuleMain.enumConvert.MODE_POURCENT)
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_ESCOMPTE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CDbl(Replace(Replace(rstPieceFRS.Fields("ESCOMPTE").Value, "_", vbNullString), ".", ",")) * 100, ModuleMain.enumConvert.MODE_POURCENT)))
				End If
350: End If
			
			'Prix net
355: If rstPieceFRS.Fields("PRIX_NET").Value <> vbNullString Then
360: If sDevise = "USA" Then
365: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmFRS.SubItems.Count > I_COL_FRS_PRIX_NET Then
						itmFRS.SubItems(I_COL_FRS_PRIX_NET).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(rstPieceFRS.Fields("PRIX_NET").Value), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
					Else
						itmFRS.SubItems.Insert(I_COL_FRS_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(rstPieceFRS.Fields("PRIX_NET").Value), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
					End If
370: Else
375: If sDevise = "SPA" Then
380: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmFRS.SubItems.Count > I_COL_FRS_PRIX_NET Then
							itmFRS.SubItems(I_COL_FRS_PRIX_NET).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(rstPieceFRS.Fields("PRIX_NET").Value), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
						Else
							itmFRS.SubItems.Insert(I_COL_FRS_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(rstPieceFRS.Fields("PRIX_NET").Value), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
						End If
385: Else
390: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmFRS.SubItems.Count > I_COL_FRS_PRIX_NET Then
							itmFRS.SubItems(I_COL_FRS_PRIX_NET).Text = Conversion_Renamed(System.Math.Round(CDbl(Replace(rstPieceFRS.Fields("PRIX_NET").Value, ".", ",")), 4), ModuleMain.enumConvert.MODE_ARGENT, 4)
						Else
							itmFRS.SubItems.Insert(I_COL_FRS_PRIX_NET, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(System.Math.Round(CDbl(Replace(rstPieceFRS.Fields("PRIX_NET").Value, ".", ",")), 4), ModuleMain.enumConvert.MODE_ARGENT, 4)))
						End If
395: End If
400: End If
405: End If
			
			'Prix spécial
410: If rstPieceFRS.Fields("PRIX_SP").Value <> vbNullString Then
415: If sDevise = "USA" Then
420: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmFRS.SubItems.Count > I_COL_FRS_PRIX_SP Then
						itmFRS.SubItems(I_COL_FRS_PRIX_SP).Text = Conversion_Renamed(CStr(System.Math.Round(CDbl(rstPieceFRS.Fields("PRIX_SP").Value), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)
					Else
						itmFRS.SubItems.Insert(I_COL_FRS_PRIX_SP, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(CStr(System.Math.Round(CDbl(rstPieceFRS.Fields("PRIX_SP").Value), 4)), ModuleMain.enumConvert.MODE_ARGENT, 4)))
					End If
425: Else
430: If sDevise = "SPA" Then
435: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmFRS.SubItems.Count > I_COL_FRS_PRIX_SP Then
							itmFRS.SubItems(I_COL_FRS_PRIX_SP).Text = Conversion_Renamed(System.Math.Round(CDbl(rstPieceFRS.Fields("PRIX_SP").Value), 4), ModuleMain.enumConvert.MODE_ARGENT, 4)
						Else
							itmFRS.SubItems.Insert(I_COL_FRS_PRIX_SP, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(System.Math.Round(CDbl(rstPieceFRS.Fields("PRIX_SP").Value), 4), ModuleMain.enumConvert.MODE_ARGENT, 4)))
						End If
440: Else
445: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmFRS.SubItems.Count > I_COL_FRS_PRIX_SP Then
							itmFRS.SubItems(I_COL_FRS_PRIX_SP).Text = Conversion_Renamed(System.Math.Round(rstPieceFRS.Fields("PRIX_SP").Value, 4), ModuleMain.enumConvert.MODE_ARGENT, 4)
						Else
							itmFRS.SubItems.Insert(I_COL_FRS_PRIX_SP, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Conversion_Renamed(System.Math.Round(rstPieceFRS.Fields("PRIX_SP").Value, 4), ModuleMain.enumConvert.MODE_ARGENT, 4)))
						End If
450: End If
455: End If
460: End If
			
			'Quoter
465: If rstPieceFRS.Fields("QUOTER").Value = True Then
470: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_QUOTER Then
					itmFRS.SubItems(I_COL_FRS_QUOTER).Text = "Oui"
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_QUOTER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Oui"))
				End If
475: Else
480: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_QUOTER Then
					itmFRS.SubItems(I_COL_FRS_QUOTER).Text = "Non"
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_QUOTER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Non"))
				End If
485: End If
			
			'Pour garder en mémoire le prix d'origine, je le mets dans le
			'tag de la colonne Prix Listé
490: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmFRS.SubItems(I_COL_FRS_PRIX_LIST).Text = vbNullString Then
495: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_PRIX_LIST Then
					itmFRS.SubItems(I_COL_FRS_PRIX_LIST).Text = " "
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_PRIX_LIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
				End If
500: End If
			
505: If rstPieceFRS.Fields("PRIX_NET").Value <> vbNullString Then
510: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmFRS.SubItems.Item(I_COL_FRS_PRIX_LIST).Tag = Replace(rstPieceFRS.Fields("PRIX_NET").Value, ".", ",")
515: Else
520: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmFRS.SubItems.Item(I_COL_FRS_PRIX_LIST).Tag = Replace(rstPieceFRS.Fields("PRIX_SP").Value, ".", ",")
525: End If
			
530: 'Pour avoir le no d'enregistrement de PiecesFRS
			
535: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmFRS.SubItems(I_COL_FRS_ENTRER_PAR).Text = vbNullString Then
540: 'UPGRADE_WARNING: Lower bound of collection itmFRS has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmFRS.SubItems.Count > I_COL_FRS_ENTRER_PAR Then
					itmFRS.SubItems(I_COL_FRS_ENTRER_PAR).Text = " "
				Else
					itmFRS.SubItems.Insert(I_COL_FRS_ENTRER_PAR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, " "))
				End If
545: End If
			
550: 'UPGRADE_WARNING: Lower bound of collection itmFRS.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmFRS.SubItems.Item(I_COL_FRS_ENTRER_PAR).Tag = rstPieceFRS.Fields("NoEnreg").Value
			
555: Call rstPieceFRS.MoveNext()
560: Loop 
		
		'ferme la table
565: Call rstPieceFRS.Close()
570: 'UPGRADE_NOTE: Object rstPieceFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPieceFRS = Nothing
		
575: Exit Sub
		
AfficherErreur: 
		
580: Call AfficherErreur("frmChoixBonCommande", "RemplirListViewFournisseur", Err, Erl())
	End Sub
	
	Private Sub CalculerTotalRecordsetElec(ByVal sNoProjSoum As String)
		
5: On Error GoTo AfficherErreur
		
		'Méthode pour calculer le prix
10: Dim rstProjet As ADODB.Recordset
15: Dim rstPiece As ADODB.Recordset
20: Dim rstPunch As ADODB.Recordset
25: Dim dblTotalDessin As Double
30: Dim dblTotalFabrication As Double
35: Dim dblTotalAssemblage As Double
40: Dim dblTotalProgInterface As Double
45: Dim dblTotalProgAutomate As Double
50: Dim dblTotalProgRobot As Double
55: Dim dblTotalVision As Double
60: Dim dblTotalTest As Double
65: Dim dblTotalInstallation As Double
70: Dim dblTotalMiseService As Double
75: Dim dblTotalFormation As Double
80: Dim dblTotalGestion As Double
85: Dim dblTotalShipping As Double
90: Dim dblHebergement As Double
95: Dim dblRepas As Double
100: Dim dblTransport As Double
105: Dim dblUniteMobile As Double
110: Dim dblPrixEmballage As Double
115: Dim dblTotalResteTemps As Double
120: Dim dblPrixPieces As Double
125: Dim dblPrixTotal As Double
130: Dim dblCommission As Double
135: Dim dblTotalTemps As Double
140: Dim dblProfit As Double
145: Dim dblTotalManuel As Double
150: Dim dblTotalPieceImprevue As Double
155: Dim dblGrandTotal As Double
160: Dim sDateDebut As String
165: Dim sDateFin As String
170: Dim sTotal As String
		
175: rstProjet = New ADODB.Recordset
		
180: Call rstProjet.Open("SELECT * FROM GRB_ProjetElec WHERE IDProjet = '" & sNoProjSoum & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
185: If Not rstProjet.EOF Then
190: rstPunch = New ADODB.Recordset
			
			'Total des temps
195: sDateDebut = "TIMESERIAL(Left(GRB_Punch.HeureDébut,2),RIGHT(GRB_Punch.HeureDébut,2),0)"
			
200: sDateFin = "TIMESERIAL(Left(GRB_Punch.HeureFin,2),RIGHT(GRB_Punch.HeureFin,2),0)"
			
205: sTotal = "(SUM(" & sDateFin & " - " & sDateDebut & ")* 24) As Total"
			
			
210: Call rstPunch.Open("SELECT Type, " & sTotal & " FROM GRB_Punch WHERE NoProjet = '" & sNoProjSoum & "' And HeureFin is not null AND HeureDébut is not null GROUP BY Type", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
215: dblTotalDessin = 0
220: dblTotalFabrication = 0
225: dblTotalAssemblage = 0
230: dblTotalProgInterface = 0
235: dblTotalProgAutomate = 0
240: dblTotalProgRobot = 0
245: dblTotalVision = 0
250: dblTotalTest = 0
255: dblTotalInstallation = 0
260: dblTotalMiseService = 0
265: dblTotalFormation = 0
270: dblTotalGestion = 0
275: dblTotalShipping = 0
			
280: Do While Not rstPunch.EOF
285: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPunch.Fields("Total").Value) Then
290: Select Case rstPunch.Fields("Type").Value
						Case "Dessin" : dblTotalDessin = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxDessin").Value)
295: Case "Fabrication" : dblTotalFabrication = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxFabrication").Value)
300: Case "Assemblage" : dblTotalAssemblage = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxAssemblage").Value)
305: Case "ProgInterface" : dblTotalProgInterface = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxProgInterface").Value)
310: Case "ProgAutomate" : dblTotalProgAutomate = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxProgAutomate").Value)
315: Case "ProgRobot" : dblTotalProgRobot = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxProgRobot").Value)
320: Case "Vision" : dblTotalVision = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxVision").Value)
325: Case "Test" : dblTotalTest = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxTest").Value)
330: Case "Installation" : dblTotalInstallation = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxInstallation").Value)
335: Case "MiseService" : dblTotalMiseService = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxMiseService").Value)
340: Case "Formation" : dblTotalFormation = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxFormation").Value)
345: Case "Gestion" : dblTotalGestion = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxGestion").Value)
350: Case "Shipping" : dblTotalShipping = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxShipping").Value)
355: End Select
360: End If
				
365: Call rstPunch.MoveNext()
370: Loop 
			
375: Call rstPunch.Close()
380: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstPunch = Nothing
			
385: dblTotalTemps = dblTotalDessin + dblTotalFabrication + dblTotalAssemblage + dblTotalProgInterface + dblTotalProgAutomate + dblTotalProgRobot + dblTotalVision + dblTotalTest + dblTotalInstallation + dblTotalMiseService + dblTotalFormation + dblTotalGestion + dblTotalShipping
			
390: rstPiece = New ADODB.Recordset
			
395: Call rstPiece.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = '" & sNoProjSoum & "' AND Type = 'E'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'Pour chaque élément du recordset
400: Do While Not rstPiece.EOF
405: If Trim(rstPiece.Fields("Prix_total").Value) <> vbNullString Then
					'On additionne le prix total
410: dblPrixPieces = dblPrixPieces + CDbl(rstPiece.Fields("Prix_total").Value) - CDbl(rstPiece.Fields("Profit_Argent").Value)
					
					'On additionne le profit
415: dblProfit = dblProfit + CDbl(rstPiece.Fields("Profit_Argent").Value)
420: End If
				
425: Call rstPiece.MoveNext()
430: Loop 
			
435: Call rstPiece.Close()
440: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstPiece = Nothing
			
445: dblHebergement = 0
450: dblRepas = 0
455: dblTransport = 0
460: dblUniteMobile = 0
			
			'Correction d'un bug de Type Incompatible
465: If IsNumeric(rstProjet.Fields("PrixEmballage").Value) Then
470: dblPrixEmballage = CDbl(rstProjet.Fields("PrixEmballage").Value)
475: Else
480: dblPrixEmballage = 0
485: End If
			
490: dblTotalResteTemps = dblHebergement + dblRepas + dblTransport + dblUniteMobile + dblPrixEmballage
			
495: If IsNumeric(rstProjet.Fields("total_manuel").Value) Then
500: dblTotalManuel = CDbl(rstProjet.Fields("total_manuel").Value)
505: Else
510: dblTotalManuel = 0
515: End If
			
520: dblTotalPieceImprevue = (dblPrixPieces + dblProfit) * (1 + CDbl(rstProjet.Fields("Imprevue").Value))
			
525: dblPrixTotal = dblTotalTemps + dblTotalManuel + dblTotalPieceImprevue + dblTotalResteTemps
			
			'Le calcul de la commission est sur les manuels (Nbre de page * prix par pages * nbre de copies) + (prix des pièces * pourcentage d'imprévus) + total des temps
530: dblCommission = dblPrixTotal * CDbl(rstProjet.Fields("Commission").Value)
			
			'Le prix total est le calcul des manuels (Nbre de page * prix par pages * nbre de copies) + (prix des pièces * pourcentage d'imprévus) + total des temps + total de la commission
535: dblGrandTotal = dblPrixTotal + dblCommission
			
			'Format monétaires avec 2 chiffres après la virgule
540: rstProjet.Fields("total_commission").Value = dblCommission
545: rstProjet.Fields("Total_manuel").Value = dblTotalManuel
550: rstProjet.Fields("Total_temps").Value = dblTotalTemps
555: rstProjet.Fields("total_imprevue").Value = dblTotalPieceImprevue - (dblPrixPieces + dblProfit)
560: rstProjet.Fields("total_piece").Value = dblPrixPieces
565: rstProjet.Fields("Total_Commission").Value = Conversion_Renamed(CStr(System.Math.Round(dblCommission, 2)), ModuleMain.enumConvert.MODE_ARGENT)
570: rstProjet.Fields("PrixTotal").Value = Conversion_Renamed(CStr(System.Math.Round(dblGrandTotal, 2)), ModuleMain.enumConvert.MODE_ARGENT)
575: rstProjet.Fields("Total_Profit").Value = Conversion_Renamed(CStr(System.Math.Round(dblProfit, 2)), ModuleMain.enumConvert.MODE_ARGENT)
			
580: Call rstProjet.Update()
585: Else
590: Call MsgBox("Le projet " & sNoProjSoum & " est inexistant!", MsgBoxStyle.OKOnly, "Erreur")
595: End If
		
600: Call rstProjet.Close()
605: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjet = Nothing
		
610: Exit Sub
		
AfficherErreur: 
		
615: Call AfficherErreur("frmChoixBonCommande", "CalculerTotalRecordset", Err, Erl())
	End Sub
	
	Private Sub CalculerTotalRecordsetMec(ByVal sNoProjSoum As String)
		
5: On Error GoTo AfficherErreur
		
		'Méthode pour calculer le prix
10: Dim rstProjet As ADODB.Recordset
15: Dim rstPiece As ADODB.Recordset
20: Dim rstPunch As ADODB.Recordset
25: Dim dblPrixPieces As Double
30: Dim dblPrixTotal As Double
35: Dim dblCommission As Double
40: Dim dblTotalTemps As Double
45: Dim dblProfit As Double
50: Dim dblTotalManuel As Double
55: Dim dblTotalImprevue As Double
60: Dim dblGrandTotal As Double
65: Dim dblTotalDessin As Double
70: Dim dblTotalCoupe As Double
75: Dim dblTotalMachinage As Double
80: Dim dblTotalSoudure As Double
85: Dim dblTotalAssemblage As Double
90: Dim dblTotalPeinture As Double
95: Dim dblTotalTest As Double
100: Dim dblTotalInstallation As Double
105: Dim dblTotalFormation As Double
110: Dim dblTotalGestion As Double
115: Dim dblTotalShipping As Double
120: Dim dblPrixEmballage As Double
125: Dim dblTotalResteTemps As Double
130: Dim sDateDebut As String
135: Dim sDateFin As String
140: Dim sTotal As String
		
145: rstProjet = New ADODB.Recordset
		
150: Call rstProjet.Open("SELECT * FROM GRB_ProjetMec WHERE IDProjet = '" & sNoProjSoum & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
155: If Not rstProjet.EOF Then
160: rstPiece = New ADODB.Recordset
			
165: Call rstPiece.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = '" & sNoProjSoum & "' AND Type = 'M'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'Pour chaque élément du recordset
170: Do While Not rstPiece.EOF
175: If Trim(rstPiece.Fields("Prix_total").Value) <> vbNullString Then
					'On additionne le prix total
180: dblPrixPieces = dblPrixPieces + rstPiece.Fields("Prix_total").Value - rstPiece.Fields("Profit_Argent").Value
					
					'On additionne le profit
185: dblProfit = dblProfit + rstPiece.Fields("Profit_Argent").Value
190: End If
				
195: Call rstPiece.MoveNext()
200: Loop 
			
			'Total des temps
205: sDateDebut = "TIMESERIAL(Left(GRB_Punch.HeureDébut,2),RIGHT(GRB_Punch.HeureDébut,2),0)"
			
210: sDateFin = "TIMESERIAL(Left(GRB_Punch.HeureFin,2),RIGHT(GRB_Punch.HeureFin,2),0)"
			
215: sTotal = "(SUM(" & sDateFin & " - " & sDateDebut & ")* 24) As Total"
			
220: rstPunch = New ADODB.Recordset
			
225: Call rstPunch.Open("SELECT Type, " & sTotal & " FROM GRB_Punch WHERE NoProjet = '" & sNoProjSoum & "' And HeureFin is not null AND HeureDébut is not null GROUP BY Type", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
230: dblTotalDessin = 0
235: dblTotalCoupe = 0
240: dblTotalMachinage = 0
245: dblTotalSoudure = 0
250: dblTotalAssemblage = 0
255: dblTotalPeinture = 0
260: dblTotalTest = 0
265: dblTotalInstallation = 0
270: dblTotalFormation = 0
275: dblTotalGestion = 0
280: dblTotalShipping = 0
			
285: Do While Not rstPunch.EOF
290: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstPunch.Fields("Total").Value) Then
295: Select Case rstPunch.Fields("Type").Value
						Case "Dessin" : dblTotalDessin = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxDessin").Value)
300: Case "Coupe" : dblTotalCoupe = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxCoupe").Value)
305: Case "Machinage" : dblTotalMachinage = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxMachinage").Value)
310: Case "Soudure" : dblTotalSoudure = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxSoudure").Value)
315: Case "Assemblage" : dblTotalAssemblage = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxAssemblage").Value)
320: Case "Peinture" : dblTotalPeinture = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxPeinture").Value)
325: Case "Test" : dblTotalTest = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxTest").Value)
330: Case "Installation" : dblTotalInstallation = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxInstallation").Value)
335: Case "Formation" : dblTotalFormation = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxFormation").Value)
340: Case "Gestion" : dblTotalGestion = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxGestion").Value)
345: Case "Shipping" : dblTotalShipping = CDbl(rstPunch.Fields("Total").Value) * CDbl(rstProjet.Fields("TauxShipping").Value)
350: End Select
355: End If
				
360: Call rstPunch.MoveNext()
365: Loop 
			
370: Call rstPunch.Close()
375: 'UPGRADE_NOTE: Object rstPunch may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstPunch = Nothing
			
380: dblTotalTemps = dblTotalDessin + dblTotalCoupe + dblTotalMachinage + dblTotalSoudure + dblTotalAssemblage + dblTotalPeinture + dblTotalTest + dblTotalInstallation + dblTotalFormation + dblTotalGestion + dblTotalShipping
			
			'Correction d'un bug de Type Incompatible
385: If IsNumeric(rstProjet.Fields("PrixEmballage").Value) Then
390: dblPrixEmballage = CDbl(rstProjet.Fields("PrixEmballage").Value)
395: Else
400: dblPrixEmballage = 0
405: End If
			
410: dblTotalResteTemps = dblPrixEmballage
			
415: If IsNumeric(rstProjet.Fields("total_manuel").Value) Then
420: dblTotalManuel = CDbl(rstProjet.Fields("total_manuel").Value)
425: Else
430: dblTotalManuel = 0
435: End If
			
440: dblTotalImprevue = System.Math.Round((dblPrixPieces + dblProfit) * CDbl(rstProjet.Fields("Imprevue").Value), 2)
			
445: dblPrixTotal = dblPrixPieces + dblProfit + dblTotalTemps + dblTotalImprevue + dblTotalManuel + dblTotalResteTemps
			
			'Le calcul de la commission est sur les manuels (Nbre de page * prix par pages * nbre de copies) + (prix des pièces * pourcentage d'imprévus) + total des temps
450: dblCommission = System.Math.Round(dblPrixTotal * CDbl(rstProjet.Fields("Commission").Value), 2)
			
			'Le prix total est le calcul des manuels (Nbre de page * prix par pages * nbre de copies) + (prix des pièces * pourcentage d'imprévus) + total des temps + total de la commission
455: dblGrandTotal = dblPrixTotal + dblCommission
			
			'Format monétaires avec 2 chiffres après la virgule
460: rstProjet.Fields("Total_Piece").Value = Conversion_Renamed(CStr(System.Math.Round(dblPrixPieces, 2)), ModuleMain.enumConvert.MODE_ARGENT)
465: rstProjet.Fields("Total_Temps").Value = Conversion_Renamed(CStr(System.Math.Round(dblTotalTemps, 2)), ModuleMain.enumConvert.MODE_ARGENT)
470: rstProjet.Fields("PrixTotal").Value = Conversion_Renamed(CStr(System.Math.Round(dblGrandTotal, 2)), ModuleMain.enumConvert.MODE_ARGENT)
475: rstProjet.Fields("total_Imprevue").Value = Conversion_Renamed(CStr(System.Math.Round(dblTotalImprevue, 2)), ModuleMain.enumConvert.MODE_ARGENT)
480: rstProjet.Fields("total_commission").Value = Conversion_Renamed(CStr(System.Math.Round(dblCommission, 2)), ModuleMain.enumConvert.MODE_ARGENT)
485: rstProjet.Fields("total_profit").Value = Conversion_Renamed(CStr(System.Math.Round(dblProfit, 2)), ModuleMain.enumConvert.MODE_ARGENT)
			
490: Call rstProjet.Update()
			
495: Call rstPiece.Close()
500: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstPiece = Nothing
505: Else
510: Call MsgBox("Le projet " & sNoProjSoum & " est inexistant!", MsgBoxStyle.OKOnly, "Erreur")
515: End If
		
520: Call rstProjet.Close()
525: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjet = Nothing
		
530: Exit Sub
		
AfficherErreur: 
		
535: Call AfficherErreur("frmChoixBonCommande", "CalculerTotalRecordset", Err, Erl())
	End Sub
	
	Private Sub ModifierFournisseurBD()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstPiece As ADODB.Recordset
15: Dim rstProjet As ADODB.Recordset
20: Dim sProfit As String
25: Dim iCompteur As Short
30: Dim bModif As Boolean
35: Dim iCompteurColl As Short
40: Dim iIndexColl As Short
45: Dim sLiaison As String
		
50: rstProjet = New ADODB.Recordset
		
55: If m_sType = "E" Then
60: Call rstProjet.Open("SELECT Profit, LiaisonChargeable FROM GRB_ProjetElec WHERE IDProjet = '" & m_sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
65: Else
70: Call rstProjet.Open("SELECT Profit, LiaisonChargeable FROM GRB_ProjetMec WHERE IDProjet = '" & m_sNoProjet & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
75: End If
		
80: sProfit = rstProjet.Fields("Profit").Value
		
85: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(rstProjet.Fields("LiaisonChargeable").Value) Then
90: sLiaison = rstProjet.Fields("LiaisonChargeable").Value
95: Else
100: sLiaison = ""
105: End If
		
110: Call rstProjet.Close()
115: 'UPGRADE_NOTE: Object rstProjet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstProjet = Nothing
		
120: rstPiece = New ADODB.Recordset
		
125: For iCompteur = 1 To lvwPiece.Items.Count
130: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwPiece.Items.Item(iCompteur).Checked = True Then
135: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwPiece.Items.Item(iCompteur).SubItems.Item(I_COL_FOURNISSEUR).Tag <> "" Then
140: bModif = True
					
145: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					Call rstPiece.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = '" & m_sNoProjet & "' AND NuméroLigne = " & lvwPiece.Items.Item(iCompteur).SubItems.Item(I_COL_NO_ITEM).Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
150: For iCompteurColl = 1 To m_collNoLigneFRS.Count()
155: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Couldn't resolve default property of object lvwPiece.ListItems(iCompteur).ListSubItems(I_COL_NO_ITEM).Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: Couldn't resolve default property of object m_collNoLigneFRS(iCompteurColl). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If m_collNoLigneFRS.Item(iCompteurColl) = lvwPiece.Items.Item(iCompteur).SubItems.Item(I_COL_NO_ITEM).Tag Then
160: iIndexColl = iCompteurColl
							
165: Exit For
170: End If
175: Next 
					
180: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					'UPGRADE_WARNING: Couldn't resolve default property of object lvwPiece.ListItems().ListSubItems().Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					rstPiece.Fields("IDFRS").Value = lvwPiece.Items.Item(iCompteur).SubItems.Item(I_COL_FOURNISSEUR).Tag
					
					'Prix listé
185: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPrixList(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Trim(m_collPrixList.Item(iIndexColl)) = vbNullString Then
190: rstPiece.Fields("PRIX_LIST").Value = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_PAS_FORMAT, 4)
195: Else
200: rstPiece.Fields("PRIX_LIST").Value = Conversion_Renamed(m_collPrixList.Item(iIndexColl), ModuleMain.enumConvert.MODE_PAS_FORMAT, 4)
205: rstPiece.Fields("PrixOrigine").Value = Conversion_Renamed(m_collPrixOrigine.Item(iIndexColl), ModuleMain.enumConvert.MODE_PAS_FORMAT, 4)
210: End If
					
					'S'il y a un prix net, on le met l'escompte et le prix net sinon, on prend le prix
					'spécial pour mettre dans le prix net
215: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPrixNet(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Trim(m_collPrixNet.Item(iIndexColl)) <> vbNullString Then
220: rstPiece.Fields("ESCOMPTE").Value = Conversion_Renamed(m_collEscompte.Item(iIndexColl), ModuleMain.enumConvert.MODE_PAS_FORMAT)
225: rstPiece.Fields("PRIX_NET").Value = Conversion_Renamed(m_collPrixNet.Item(iIndexColl), ModuleMain.enumConvert.MODE_PAS_FORMAT, 4)
230: Else
235: 'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If Trim(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_SP).Text) <> vbNullString Then
240: rstPiece.Fields("PRIX_NET").Value = Conversion_Renamed(m_collPrixSP.Item(iIndexColl), ModuleMain.enumConvert.MODE_PAS_FORMAT, 4)
245: Else
250: rstPiece.Fields("ESCOMPTE").Value = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_PAS_FORMAT)
255: rstPiece.Fields("PRIX_NET").Value = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_PAS_FORMAT, 4)
260: End If
265: End If
					
					'Pour le prix total, il faut faire la quantité * prix net * pourcentage de profit
270: rstPiece.Fields("Prix_Total").Value = Conversion_Renamed(CStr(System.Math.Round(CDbl(Replace(rstPiece.Fields("Qté").Value, "*", vbNullString)) * rstPiece.Fields("PRIX_NET").Value * CSng(sProfit), 2)), ModuleMain.enumConvert.MODE_PAS_FORMAT)
					
					'Pour le profit, c'est le prix total - (prix net * quantité)
275: rstPiece.Fields("Profit_argent").Value = Conversion_Renamed(CStr(System.Math.Round(rstPiece.Fields("Prix_Total").Value - (rstPiece.Fields("PRIX_NET").Value * CDbl(Replace(rstPiece.Fields("Qté").Value, "*", vbNullString))), 2)), ModuleMain.enumConvert.MODE_PAS_FORMAT)
					
280: Call rstPiece.Update()
					
285: Call rstPiece.Close()
					
290: If sLiaison <> "" Then
295: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						Call rstPiece.Open("SELECT * FROM GRB_Projet_Pieces WHERE IDProjet = '" & VB.Left(m_sNoProjet, Len(m_sNoProjet) - 2) & sLiaison & "' AND Provenance = '" & VB.Right(m_sNoProjet, 2) & "' AND NumItem = '" & lvwPiece.Items.Item(iCompteur).SubItems(I_COL_NO_ITEM).Text & "' AND Qté = '" & lvwPiece.Items.Item(iCompteur).Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
						
300: For iCompteurColl = 1 To m_collNoLigneFRS.Count()
305: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							'UPGRADE_WARNING: Couldn't resolve default property of object lvwPiece.ListItems(iCompteur).ListSubItems(I_COL_NO_ITEM).Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: Couldn't resolve default property of object m_collNoLigneFRS(iCompteurColl). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If m_collNoLigneFRS.Item(iCompteurColl) = lvwPiece.Items.Item(iCompteur).SubItems.Item(I_COL_NO_ITEM).Tag Then
310: iIndexColl = iCompteurColl
								
315: Exit For
320: End If
325: Next 
						
330: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems().ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						'UPGRADE_WARNING: Couldn't resolve default property of object lvwPiece.ListItems().ListSubItems().Tag. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						rstPiece.Fields("IDFRS").Value = lvwPiece.Items.Item(iCompteur).SubItems.Item(I_COL_FOURNISSEUR).Tag
						
						'Prix listé
335: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPrixList(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If Trim(m_collPrixList.Item(iIndexColl)) = vbNullString Then
340: rstPiece.Fields("PRIX_LIST").Value = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_PAS_FORMAT, 4)
345: Else
350: rstPiece.Fields("PRIX_LIST").Value = Conversion_Renamed(m_collPrixList.Item(iIndexColl), ModuleMain.enumConvert.MODE_PAS_FORMAT, 4)
355: rstPiece.Fields("PrixOrigine").Value = Conversion_Renamed(m_collPrixOrigine.Item(iIndexColl), ModuleMain.enumConvert.MODE_PAS_FORMAT, 4)
360: End If
						
						'S'il y a un prix net, on le met l'escompte et le prix net sinon, on prend le prix
						'spécial pour mettre dans le prix net
365: 'UPGRADE_WARNING: Couldn't resolve default property of object m_collPrixNet(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If Trim(m_collPrixNet.Item(iIndexColl)) <> vbNullString Then
370: rstPiece.Fields("ESCOMPTE").Value = Conversion_Renamed(m_collEscompte.Item(iIndexColl), ModuleMain.enumConvert.MODE_PAS_FORMAT)
375: rstPiece.Fields("PRIX_NET").Value = Conversion_Renamed(m_collPrixNet.Item(iIndexColl), ModuleMain.enumConvert.MODE_PAS_FORMAT, 4)
380: Else
385: 'UPGRADE_WARNING: Lower bound of collection lvwfournisseur.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If Trim(lvwfournisseur.FocusedItem.SubItems(I_COL_FRS_PRIX_SP).Text) <> vbNullString Then
390: rstPiece.Fields("PRIX_NET").Value = Conversion_Renamed(m_collPrixSP.Item(iIndexColl), ModuleMain.enumConvert.MODE_PAS_FORMAT, 4)
395: Else
400: rstPiece.Fields("ESCOMPTE").Value = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_PAS_FORMAT)
405: rstPiece.Fields("PRIX_NET").Value = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_PAS_FORMAT, 4)
410: End If
415: End If
						
						'Pour le prix total, il faut faire la quantité * prix net * pourcentage de profit
420: rstPiece.Fields("Prix_Total").Value = Conversion_Renamed(CStr(System.Math.Round(CDbl(Replace(rstPiece.Fields("Qté").Value, "*", vbNullString)) * rstPiece.Fields("PRIX_NET").Value * CSng(sProfit), 2)), ModuleMain.enumConvert.MODE_PAS_FORMAT)
						
						'Pour le profit, c'est le prix total - (prix net * quantité)
425: rstPiece.Fields("Profit_argent").Value = Conversion_Renamed(CStr(System.Math.Round(rstPiece.Fields("Prix_Total").Value - (rstPiece.Fields("PRIX_NET").Value * CDbl(Replace(rstPiece.Fields("Qté").Value, "*", vbNullString))), 2)), ModuleMain.enumConvert.MODE_PAS_FORMAT)
						
430: Call rstPiece.Update()
						
435: Call rstPiece.Close()
440: End If
445: End If
450: End If
455: Next 
		
460: 'UPGRADE_NOTE: Object rstPiece may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPiece = Nothing
		
465: If bModif = True Then
470: If m_sType = "E" Then
475: Call CalculerTotalRecordsetElec(m_sNoProjet)
				
480: If sLiaison <> "" Then
485: Call CalculerTotalRecordsetElec(VB.Left(m_sNoProjet, Len(m_sNoProjet) - 2) & sLiaison)
490: End If
				
495: FrmProjSoumElec.m_bModifFournisseurBC = True
500: Else
505: Call CalculerTotalRecordsetMec(m_sNoProjet)
				
510: If sLiaison <> "" Then
515: Call CalculerTotalRecordsetMec(VB.Left(m_sNoProjet, Len(m_sNoProjet) - 2) & sLiaison)
520: End If
				
525: FrmProjSoumMec.m_bModifFournisseurBC = True
530: End If
535: Else
540: If m_sType = "E" Then
545: FrmProjSoumElec.m_bModifFournisseurBC = False
550: Else
555: FrmProjSoumMec.m_bModifFournisseurBC = False
560: End If
565: End If
		
570: Exit Sub
		
AfficherErreur: 
		
575: Call AfficherErreur("frmChoixBonCommande", "ModifierFournisseurBD", Err, Erl())
	End Sub
End Class