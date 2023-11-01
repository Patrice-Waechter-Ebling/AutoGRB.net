Option Strict Off
Option Explicit On
Friend Class frmChoixTransfertJob
	Inherits System.Windows.Forms.Form
	
	'Index des colonnes de lvwPiece
	Private Const I_COL_QTE As Short = 0
	Private Const I_COL_NO_ITEM As Short = 1
	Private Const I_COL_DESCRIPTION As Short = 2
	Private Const I_COL_MANUFACTURIER As Short = 3
	Private Const I_COL_FOURNISSEUR As Short = 4
	
	Private m_sNoSoumission As String
	Private m_sType As String
	
	Public Sub Afficher(ByVal sNoSoumission As String, ByVal sType As String)
		
5: On Error GoTo AfficherErreur
		
		'Méthode pour afficher le form
10: m_sNoSoumission = sNoSoumission
		
15: m_sType = sType
		
20: Call RemplirListViewPieces()
		
25: Call Me.ShowDialog()
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixTransfertJob", "Afficher", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewPieces()
		
5: On Error GoTo AfficherErreur
		
		'Rempli le ListView selon le no. du projet
10: Dim rstPieces As ADODB.Recordset
15: Dim rstSection As ADODB.Recordset
20: Dim rstFRS As ADODB.Recordset
25: Dim itmPieces As System.Windows.Forms.ListViewItem
30: Dim bPremierEnr As Boolean
35: Dim iOrdreSection As Short
40: Dim sSousSection As String
		
45: bPremierEnr = True
		
50: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwPiece.Sorted was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		lvwPiece.Sorted = False
		
55: rstFRS = New ADODB.Recordset
60: rstPieces = New ADODB.Recordset
65: rstSection = New ADODB.Recordset
		
		'Ouverture du recordset
70: Call rstPieces.Open("SELECT * FROM GRB_Soumission_Pieces WHERE IDSoumission = '" & m_sNoSoumission & "' AND Type = '" & m_sType & "' AND PieceExtraChargeable = False AND PieceExtraNonChargeable = False ORDER BY NuméroLigne", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
75: Do While Not rstPieces.EOF
80: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPiece.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmPieces = lvwPiece.Items.Add()
			
			'Si c'est le premier enregistrement, il faut ajouter la section et la sous-section
85: If bPremierEnr = True Then
90: sSousSection = rstPieces.Fields("SousSection").Value
95: iOrdreSection = rstPieces.Fields("OrdreSection").Value
				
				'Pour avoir le nom de la section
				'Si c'est un projet électrique
100: If m_sType = "E" Then
105: Call rstSection.Open("SELECT NomSectionFR FROM GRB_SoumProjSectionElec WHERE IDSection = " & rstPieces.Fields("IDSection").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
110: Else
115: Call rstSection.Open("SELECT NomSectionFR FROM GRB_SoumProjSectionMec WHERE IDSection = " & rstPieces.Fields("IDSection").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
120: End If
				
				'Ajout du nom de la section
125: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstSection.Fields("NomSectionFR").Value) Then
130: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_NO_ITEM Then
						itmPieces.SubItems(I_COL_NO_ITEM).Text = rstSection.Fields("NomSectionFR").Value
					Else
						itmPieces.SubItems.Insert(I_COL_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstSection.Fields("NomSectionFR").Value))
					End If
135: Else
140: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_NO_ITEM Then
						itmPieces.SubItems(I_COL_NO_ITEM).Text = vbNullString
					Else
						itmPieces.SubItems.Insert(I_COL_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
145: End If
				
150: 'UPGRADE_WARNING: Lower bound of collection itmPieces.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmPieces.SubItems.Item(I_COL_NO_ITEM).Font = VB6.FontChangeBold(itmPieces.SubItems.Item(I_COL_NO_ITEM).Font, True)
				
155: Call rstSection.Close()
				
160: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPiece.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmPieces = lvwPiece.Items.Add()
				
				'Ajout du nom de la sous-section
165: If sSousSection = "PAS DE SOUS-SECTION" Then
170: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
						itmPieces.SubItems(I_COL_DESCRIPTION).Text = vbNullString
					Else
						itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
					End If
175: Else
180: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
						itmPieces.SubItems(I_COL_DESCRIPTION).Text = sSousSection
					Else
						itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sSousSection))
					End If
185: End If
				
190: 'UPGRADE_WARNING: Lower bound of collection itmPieces.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				itmPieces.SubItems.Item(I_COL_DESCRIPTION).Font = VB6.FontChangeBold(itmPieces.SubItems.Item(I_COL_DESCRIPTION).Font, True)
				
195: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPiece.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmPieces = lvwPiece.Items.Add()
				
200: bPremierEnr = False
205: Else
				'Si c'est pas le premier enregistrement, il faut vérifier avec l'ancienne section
210: If iOrdreSection <> rstPieces.Fields("OrdreSection").Value Then
215: iOrdreSection = rstPieces.Fields("OrdreSection").Value
					
220: If m_sType = "E" Then
225: Call rstSection.Open("SELECT NomSectionFR FROM GRB_SoumProjSectionElec WHERE IDSection = " & rstPieces.Fields("IDSection").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
230: Else
235: Call rstSection.Open("SELECT NomSectionFR FROM GRB_SoumProjSectionMec WHERE IDSection = " & rstPieces.Fields("IDSection").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
240: End If
					
245: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(rstSection.Fields("NomSectionFR").Value) Then
250: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmPieces.SubItems.Count > I_COL_NO_ITEM Then
							itmPieces.SubItems(I_COL_NO_ITEM).Text = rstSection.Fields("NomSectionFR").Value
						Else
							itmPieces.SubItems.Insert(I_COL_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstSection.Fields("NomSectionFR").Value))
						End If
255: Else
260: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmPieces.SubItems.Count > I_COL_NO_ITEM Then
							itmPieces.SubItems(I_COL_NO_ITEM).Text = vbNullString
						Else
							itmPieces.SubItems.Insert(I_COL_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
						End If
265: End If
					
270: 'UPGRADE_WARNING: Lower bound of collection itmPieces.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmPieces.SubItems.Item(I_COL_NO_ITEM).Font = VB6.FontChangeBold(itmPieces.SubItems.Item(I_COL_NO_ITEM).Font, True)
					
275: Call rstSection.Close()
					
280: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPiece.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					itmPieces = lvwPiece.Items.Add()
					
285: sSousSection = rstPieces.Fields("SousSection").Value
					
290: If sSousSection = "PAS DE SOUS-SECTION" Then
295: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
							itmPieces.SubItems(I_COL_DESCRIPTION).Text = vbNullString
						Else
							itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
						End If
300: Else
305: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
							itmPieces.SubItems(I_COL_DESCRIPTION).Text = rstPieces.Fields("SousSection").Value
						Else
							itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieces.Fields("SousSection").Value))
						End If
310: End If
					
315: 'UPGRADE_WARNING: Lower bound of collection itmPieces.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					itmPieces.SubItems.Item(I_COL_DESCRIPTION).Font = VB6.FontChangeBold(itmPieces.SubItems.Item(I_COL_DESCRIPTION).Font, True)
					
320: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPiece.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					itmPieces = lvwPiece.Items.Add()
325: Else
					'il faut vérifier avec l'ancienne sous-section
330: If sSousSection <> rstPieces.Fields("SousSection").Value Then
335: sSousSection = rstPieces.Fields("SousSection").Value
						
340: If sSousSection = "PAS DE SOUS-SECTION" Then
345: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
								itmPieces.SubItems(I_COL_DESCRIPTION).Text = vbNullString
							Else
								itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
							End If
350: Else
355: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
								itmPieces.SubItems(I_COL_DESCRIPTION).Text = sSousSection
							Else
								itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sSousSection))
							End If
360: End If
						
365: 'UPGRADE_WARNING: Lower bound of collection itmPieces.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						itmPieces.SubItems.Item(I_COL_DESCRIPTION).Font = VB6.FontChangeBold(itmPieces.SubItems.Item(I_COL_DESCRIPTION).Font, True)
						
370: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwPiece.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						itmPieces = lvwPiece.Items.Add()
375: End If
380: End If
385: End If
			
			'Quantité
390: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieces.Fields("Qté").Value) Then
395: itmPieces.Text = rstPieces.Fields("Qté").Value
400: Else
405: itmPieces.Text = vbNullString
410: End If
			
415: itmPieces.Tag = rstPieces.Fields("NoEnreg").Value
			
			'Numéro d'item
420: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieces.Fields("NumItem").Value) Then
425: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPieces.SubItems.Count > I_COL_NO_ITEM Then
					itmPieces.SubItems(I_COL_NO_ITEM).Text = rstPieces.Fields("NumItem").Value
				Else
					itmPieces.SubItems.Insert(I_COL_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieces.Fields("NumItem").Value))
				End If
430: Else
435: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPieces.SubItems.Count > I_COL_NO_ITEM Then
					itmPieces.SubItems(I_COL_NO_ITEM).Text = vbNullString
				Else
					itmPieces.SubItems.Insert(I_COL_NO_ITEM, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
440: End If
			
445: 'UPGRADE_WARNING: Lower bound of collection itmPieces.ListSubItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			itmPieces.SubItems.Item(I_COL_NO_ITEM).Tag = rstPieces.Fields("NuméroLigne").Value
			
			'Description en francais
450: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieces.Fields("Desc_FR").Value) Then
455: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
					itmPieces.SubItems(I_COL_DESCRIPTION).Text = rstPieces.Fields("Desc_FR").Value
				Else
					itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieces.Fields("Desc_FR").Value))
				End If
460: Else
465: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPieces.SubItems.Count > I_COL_DESCRIPTION Then
					itmPieces.SubItems(I_COL_DESCRIPTION).Text = vbNullString
				Else
					itmPieces.SubItems.Insert(I_COL_DESCRIPTION, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
470: End If
			
			'Fabricant
475: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieces.Fields("Manufact").Value) Then
480: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPieces.SubItems.Count > I_COL_MANUFACTURIER Then
					itmPieces.SubItems(I_COL_MANUFACTURIER).Text = rstPieces.Fields("Manufact").Value
				Else
					itmPieces.SubItems.Insert(I_COL_MANUFACTURIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstPieces.Fields("Manufact").Value))
				End If
485: Else
490: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPieces.SubItems.Count > I_COL_MANUFACTURIER Then
					itmPieces.SubItems(I_COL_MANUFACTURIER).Text = vbNullString
				Else
					itmPieces.SubItems.Insert(I_COL_MANUFACTURIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
495: End If
			
			'Fournisseur
500: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstPieces.Fields("IDFRS").Value) And rstPieces.Fields("IDFRS").Value > 0 Then
505: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPieces.SubItems(I_COL_NO_ITEM).Text <> "Texte" Then
510: Call rstFRS.Open("SELECT NomFournisseur FROM GRB_Fournisseur WHERE IDFRS = " & rstPieces.Fields("IDFRS").Value, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
					
					'On affiche le nom dans la colonne
515: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If itmPieces.SubItems.Count > I_COL_FOURNISSEUR Then
						itmPieces.SubItems(I_COL_FOURNISSEUR).Text = rstFRS.Fields("NomFournisseur").Value
					Else
						itmPieces.SubItems.Insert(I_COL_FOURNISSEUR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rstFRS.Fields("NomFournisseur").Value))
					End If
					
520: Call rstFRS.Close()
525: End If
530: Else
535: 'UPGRADE_WARNING: Lower bound of collection itmPieces has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If itmPieces.SubItems.Count > I_COL_FOURNISSEUR Then
					itmPieces.SubItems(I_COL_FOURNISSEUR).Text = vbNullString
				Else
					itmPieces.SubItems.Insert(I_COL_FOURNISSEUR, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, vbNullString))
				End If
540: End If
			
545: Call rstPieces.MoveNext()
550: Loop 
		
555: Call rstPieces.Close()
560: 'UPGRADE_NOTE: Object rstPieces may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstPieces = Nothing
		
565: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
570: 'UPGRADE_NOTE: Object rstSection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstSection = Nothing
		
575: Exit Sub
		
AfficherErreur: 
		
580: Call AfficherErreur("frmChoixTransfertJob", "RemplirListViewPieces", Err, Erl())
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: If m_sType = "E" Then
15: FrmProjSoumElec.m_bTransfertJobCancel = True
20: Else
25: FrmProjSoumMec.m_bTransfertJobCancel = True
30: End If
		
35: Call Me.Close()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmChoixTransfertJob", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdCreer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCreer.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstSoum As ADODB.Recordset
15: Dim iCompteur As Short
		
20: rstSoum = New ADODB.Recordset
		
25: Call rstSoum.Open("SELECT * FROM GRB_Soumission_Pieces WHERE IDSoumission = '" & m_sNoSoumission & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
30: Do While Not rstSoum.EOF
35: For iCompteur = 1 To lvwPiece.Items.Count
40: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwPiece.Items.Item(iCompteur).Tag = rstSoum.Fields("NoEnreg").Value Then
45: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvwPiece.Items.Item(iCompteur).Checked = True Then
50: rstSoum.Fields("TransfertJob").Value = True
55: Else
60: rstSoum.Fields("TransfertJob").Value = False
65: End If
					
70: Call rstSoum.Update()
					
75: Exit For
80: End If
85: Next 
			
90: Call rstSoum.MoveNext()
95: Loop 
		
100: Call rstSoum.Close()
105: 'UPGRADE_NOTE: Object rstSoum may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstSoum = Nothing
		
110: If m_sType = "E" Then
115: FrmProjSoumElec.m_bTransfertJobCancel = False
120: Else
125: FrmProjSoumMec.m_bTransfertJobCancel = False
130: End If
		
135: Call Me.Close()
		
140: Exit Sub
		
AfficherErreur: 
		
145: Call AfficherErreur("frmChoixTransfertJob", "cmdCreer_Click", Err, Erl())
	End Sub
	
	Private Sub cmdSelectAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelectAll.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: For iCompteur = 1 To lvwPiece.Items.Count
20: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lvwPiece.Items.Item(iCompteur).Tag <> vbNullString Then
25: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwPiece.Items.Item(iCompteur).SubItems(I_COL_NO_ITEM).Text <> vbNullString Then
30: 'UPGRADE_WARNING: Lower bound of collection lvwPiece.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					lvwPiece.Items.Item(iCompteur).Checked = True
35: End If
40: End If
45: Next 
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmChoixTransfertJob", "cmdSelectAll_Click", Err, Erl())
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
		
35: Call AfficherErreur("frmChoixTransfertJob", "cmdDeselectAll_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixTransfertJob_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixTransfertJob", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub lvwPiece_ItemCheck(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ItemCheckEventArgs) Handles lvwPiece.ItemCheck
		Dim Item As System.Windows.Forms.ListViewItem = lvwPiece.Items(eventArgs.Index)
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Lower bound of collection Item has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If Item.Tag = vbNullString Or Item.SubItems(I_COL_NO_ITEM).Text = vbNullString Then
			'On enlève le check
15: Item.Checked = False
20: End If
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixTransfertJob", "lvwPiece_ItemCheck", Err, Erl())
	End Sub
End Class