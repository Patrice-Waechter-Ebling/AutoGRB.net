Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmvendeur
	Inherits System.Windows.Forms.Form
	
	Private Enum enumModeCherche
		MODE_DATE = 0
		MODE_CLIENT = 1
	End Enum
	
	Private m_bModeAjouter As Boolean
	Private m_eModeCherche As enumModeCherche
	Private numéroCompagnie As Short
	Private FieldOk As Boolean
	'UPGRADE_NOTE: Name was upgraded to Name_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub FindFieldsExist(ByRef Name_Renamed As String)
		On Error GoTo AfficherErreur
		Dim strName As String
		Dim Findfield As ADODB.Recordset
		
		Dim i As Short
		FieldOk = False
		Findfield = New ADODB.Recordset
		Call Findfield.Open("Select * from Grb_Vendeur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		For i = 0 To Findfield.Fields.Count - 1
			strName = Findfield.Fields(i).Name
			If strName = Name_Renamed Then
				FieldOk = True
				Call Findfield.Close()
				'UPGRADE_NOTE: Object Findfield may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				Findfield = Nothing
				Exit Sub
			End If
		Next 
		Call Findfield.Close()
		'UPGRADE_NOTE: Object Findfield may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Findfield = Nothing
		Call g_connData.Execute("ALTER TABLE GRB_Vendeur Add " & Name_Renamed & " Text(25);")
		FieldOk = False
		Exit Sub
AfficherErreur: 
		Call AfficherErreur("frmvendeur", "FindFieldsExist()", Err, Erl())
	End Sub
	
	
	
	
	Private Sub remplir_lister()
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''',
		'rempli le lister
		''''''''''''''''''''',
10: Dim rstVendeur As ADODB.Recordset
15: Dim itmVendeur As System.Windows.Forms.ListViewItem
		
		Call FindFieldsExist("EnregPar")
		Call FindFieldsExist("Etat")
20: m_eModeCherche = enumModeCherche.MODE_CLIENT
		
25: CmdAdd.Visible = True
		
		'vide lister
30: Call lister.Items.Clear()
		
		'ouvre la table pour client
35: rstVendeur = New ADODB.Recordset
		
40: Call rstVendeur.Open("SELECT * FROM GRB_vendeur WHERE IDClient = " & numéroCompagnie & " ORDER BY no", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'temp que pas a la fin de la table
45: Do While Not rstVendeur.EOF
			'ajoute au lister
50: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lister.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmVendeur = lister.Items.Add()
			
			'no du client
55: itmVendeur.Tag = rstVendeur.Fields("no").Value
			
			'vérifie les champs vide avant d'inséré
			'date
60: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstVendeur.Fields("Date").Value) Then
65: itmVendeur.Text = " "
70: Else
75: itmVendeur.Text = ConvertDate(DateSerial(CInt(VB.Left(rstVendeur.Fields("Date").Value, 2)), CInt(Mid(rstVendeur.Fields("Date").Value, 4, 2)), CInt(VB.Right(rstVendeur.Fields("Date").Value, 2))))
80: End If
			'
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstVendeur.Fields("Contact").Value) And IsDbNull(rstVendeur.Fields("commentaire").Value) And IsDbNull(rstVendeur.Fields("Date").Value) Then
				Call itmVendeur.SubItems.Add(vbNullString)
			Else
				Call itmVendeur.SubItems.Add(cmbclient.Text)
			End If
			
			
			
			
			
			
			'contact
85: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstVendeur.Fields("Contact").Value) Then
90: Call itmVendeur.SubItems.Add(vbNullString)
95: Else
100: Call itmVendeur.SubItems.Add(rstVendeur.Fields("Contact").Value)
105: End If
			
			'Type
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstVendeur.Fields("Etat").Value) Then
				Call itmVendeur.SubItems.Add(vbNullString)
			Else
				Call itmVendeur.SubItems.Add(rstVendeur.Fields("Etat").Value)
			End If
			
			
			'commentaire
110: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstVendeur.Fields("commentaire").Value) Then
115: Call itmVendeur.SubItems.Add(vbNullString)
120: Else
125: Call itmVendeur.SubItems.Add(rstVendeur.Fields("commentaire").Value)
130: End If
			'Enregistrer par
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstVendeur.Fields("EnregPar").Value) Then
				Call itmVendeur.SubItems.Add(vbNullString)
			Else
				Call itmVendeur.SubItems.Add(rstVendeur.Fields("EnregPar").Value)
			End If
			
			
			
			'prochaine enreg
135: Call rstVendeur.MoveNext()
140: Loop 
		
		'fermeture table et bd
145: Call rstVendeur.Close()
150: 'UPGRADE_NOTE: Object rstVendeur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstVendeur = Nothing
		
155: Exit Sub
		
AfficherErreur: 
		
160: Call AfficherErreur("frmvendeur", "remplir_lister", Err, Erl())
	End Sub
	
	'UPGRADE_WARNING: Event cmbclient.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbclient_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbclient.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''''''''''
		'lorsque on select un client
		'''''''''''''''''''''''''''''
10: Dim rstClient As ADODB.Recordset
		
15: If cmbclient.SelectedIndex <> -1 Then
			
			'met visible fenetre pour ajouter
20: fracontact.Visible = False
			
			'mode ajouter ou editer
25: m_bModeAjouter = False
			
			'set le rapport
30: rstClient = New ADODB.Recordset
			
35: Call rstClient.Open("SELECT * FROM GRB_Client WHERE IDClient = " & VB6.GetItemData(cmbclient, cmbclient.SelectedIndex) & " ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'initialise label adress et teleph
40: lblAdresse.Text = vbNullString
45: lbltelephone.Text = vbNullString
			
			numéroCompagnie = rstClient.Fields("idclient").Value
			'si client existe
			''''''''''''''''''''''''''''''''''''''''''''
			'rempli adresse pays ville prov et codepostal si pas vide
			'''''''''''''''''''''''''''''''''''''''''''''
			'adresse
50: If Not rstClient.Fields("adresseliv").Value = "" Then
55: lblAdresse.Text = lblAdresse.Text + rstClient.Fields("adresseliv").Value
60: End If
			
			'ville
65: If Not rstClient.Fields("villeliv").Value = "" Then
70: lblAdresse.Text = lblAdresse.Text & ", " + rstClient.Fields("villeliv").Value
75: End If
			
			'pays
80: If Not rstClient.Fields("paysliv").Value = "" Then
85: lblAdresse.Text = lblAdresse.Text & ", " + rstClient.Fields("paysliv").Value
90: End If
			
			'province
95: If Not rstClient.Fields("prov/etatliv").Value = "" Then
100: lblAdresse.Text = lblAdresse.Text & ", " + rstClient.Fields("prov/etatliv").Value
105: End If
			
			'codepostal
110: If Not rstClient.Fields("codepostalliv").Value = "" Then
115: lblAdresse.Text = lblAdresse.Text & ", " + rstClient.Fields("codepostalliv").Value
120: End If
			
			''''''''''''''''''''''''''''''''''
			'rempli tel fax pagette cell email si pas vide
			''''''''''''''''''''''''''''''''''
			'telephone
125: If Not rstClient.Fields("telephonne").Value = "" Then
130: lbltelephone.Text = lbltelephone.Text & "TÉL: " + rstClient.Fields("telephonne").Value
135: End If
			
			'fax
140: If Not rstClient.Fields("fax").Value = "" Then
145: lbltelephone.Text = lbltelephone.Text & "      FAX: " + rstClient.Fields("fax").Value
150: End If
			
			'pagette
155: If Not rstClient.Fields("pagette").Value = "" Then
160: lbltelephone.Text = lbltelephone.Text & "      PAGE: " + rstClient.Fields("pagette").Value
165: End If
			
			'cellulaire
170: If Not rstClient.Fields("cellulaire").Value = "" Then
175: lbltelephone.Text = lbltelephone.Text & "      CELL: " + rstClient.Fields("cellulaire").Value
180: End If
			
			'email
185: If Not rstClient.Fields("email").Value = "" Then
190: lbltelephone.Text = lbltelephone.Text & "      EMAIL: " + rstClient.Fields("email").Value
195: End If
			txtNomCompagny.Text = rstClient.Fields("NomClient").Value
200: Call rstClient.Close()
205: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstClient = Nothing
			
			'rempli le lister
			
210: Call remplir_lister()
215: End If
		
220: Exit Sub
		
AfficherErreur: 
		
225: Call AfficherErreur("frmvendeur", "cmbclient_Click", Err, Erl())
	End Sub
	
	
	
	
	
	Private Sub CmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdAdd.Click
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''''''''''''''
		'ajoute un contact
		''''''''''''''''''''''''''''''''
		'met visible fenetre pour ajouter
10: fracontact.Visible = True
15: fracontact.Tag = numéroCompagnie
		'mode ajouter ou editer
20: m_bModeAjouter = True
		
		'valeur par defaut sur l'ouverture
25: txtDate.Text = Year(Today) & "-" & VB.Right("0" & Month(Today), 2) & "-" & VB.Right("0" & VB.Day(Today), 2)
		txtNomCompagny.Text = cmbclient.Text
30: txtcommentaire.Text = vbNullString
35: txtcontact.Text = vbNullString
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmvendeur", "CmdAdd_Click", Err, Erl())
	End Sub
	
	Private Sub cmdcherche_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdcherche.Click
		
5: On Error GoTo AfficherErreur
		fracontact.Visible = False
		
10: Call remplir_lister_date()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmvendeur", "cmdcherche_Click", Err, Erl())
	End Sub
	
	Private Sub cmdExporter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExporter.Click
		Dim xlworksheet As Excel.Workbook
		Dim xlsheet As Excel.Application
		Dim info As ADODB.Recordset
		Dim row As Short
		Dim i As Short
		
		
		
		xlsheet = New Excel.Application
		xlworksheet = xlsheet.Workbooks.Add
		row = 1
		
		
		If m_eModeCherche = enumModeCherche.MODE_CLIENT Then
			row = 6
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(1, 1) = "Client:"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(2, 1) = "Adresse:"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(3, 1) = "Téléphone:"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(2, 3) = "Ville:"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(3, 3) = "Fax:"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(2, 5) = "Pays:"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(3, 5) = "Page:"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(2, 7) = "Province/État:"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(3, 7) = "Cell:"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(2, 9) = "Codepostal:"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(3, 9) = "Email:"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(5, 1) = "Date:"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(5, 2) = "Nom de la Compagnie"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(5, 3) = "Nom du Contact"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(5, 4) = "État"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(5, 5) = "Commentaire"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(5, 9) = "Enregister Par"
			
			With xlsheet.Range("A1:A3;C2:C3;E2:E3;G2:G3;I2:I3")
				.Font.Bold = True
				.HorizontalAlignment = Excel.Constants.xlRight
				.Font.Size = 11
			End With
			With xlsheet.Range("A5:I5")
				.Font.Bold = True
				.HorizontalAlignment = Excel.Constants.xlLeft
				.Font.Size = 11
			End With
			
			
			
			
			
			info = New ADODB.Recordset
			Call info.Open("Select * From Grb_client where IDClient = " & numéroCompagnie, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			Do While Not info.EOF
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(1, 2) = info.Fields("Nomclient").Value
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(2, 2) = info.Fields("AdresseLiv").Value
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(3, 2) = info.Fields("Telephonne").Value
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(2, 4) = info.Fields("VilleLiv").Value
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(3, 4) = info.Fields("Fax").Value
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(2, 6) = info.Fields("PaysLiv").Value
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(3, 6) = info.Fields("Pagette").Value
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(2, 8) = info.Fields("Prov/EtatLiv").Value
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(3, 8) = info.Fields("Cellulaire").Value
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(3, 10) = info.Fields("CodePostalLiv").Value
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(3, 10) = info.Fields("Email").Value
				Call info.MoveNext()
			Loop 
			For i = 1 To lister.Items.Count
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(row, 1) = lister.Items.Item(i).Text
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(row, 2) = lister.Items.Item(i).SubItems(1).Text
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(row, 3) = lister.Items.Item(i).SubItems(2).Text
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(row, 4) = lister.Items.Item(i).SubItems(3).Text
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(row, 5) = lister.Items.Item(i).SubItems(4).Text
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(row, 9) = lister.Items.Item(i).SubItems(5).Text
				xlsheet.Range("E" & row & ":H" & row).Merge()
				row = row + 1
			Next 
			xlsheet.Range("A:J").Columns.AutoFit()
			info.Close()
			'UPGRADE_NOTE: Object info may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			info = Nothing
		Else
			If lister.Items.Count <= 0 Then Exit Sub
			row = 3
			xlsheet.Range("A1:D1").Merge()
			'UPGRADE_WARNING: Lower bound of collection lister.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(1, 1) = "Liste des contacts en date du " & lister.Items.Item(1).Text
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(2, 1) = "Date:"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(2, 2) = "Nom de la Compagnie"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(2, 3) = "Nom du Contact"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(2, 4) = "État"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(2, 5) = "Commentaire"
			'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			xlsheet.Cells._Default(2, 6) = "Enregister Par"
			With xlsheet.Range("A1;A2;A2:F2")
				.Font.Bold = True
				.Font.Size = 11
			End With
			For i = 1 To lister.Items.Count
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(row, 1) = lister.Items.Item(i).Text
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(row, 2) = lister.Items.Item(i).SubItems(1).Text
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(row, 3) = lister.Items.Item(i).SubItems(2).Text
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(row, 4) = lister.Items.Item(i).SubItems(3).Text
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(row, 5) = lister.Items.Item(i).SubItems(4).Text
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Lower bound of collection lister.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_WARNING: Couldn't resolve default property of object xlsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				xlsheet.Cells._Default(row, 6) = lister.Items.Item(i).SubItems(5).Text
				row = row + 1
			Next 
			xlsheet.Range("A:F").Columns.AutoFit()
		End If
		
		
		
		
		xlsheet.Visible = True
		
		
		
	End Sub
	
	Private Sub cmdfermercontact_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdfermercontact.Click
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''
		'Quitte liste contact'
		''''''''''''''''''''''
		'cache fenêtre
10: fracontact.Visible = False
15: If m_eModeCherche = enumModeCherche.MODE_CLIENT Then
20: Call remplir_lister()
25: Else
30: Call remplir_lister_date()
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmvendeur", "cmdfermercontact_Click", Err, Erl())
	End Sub
	
	Private Sub cmdquit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdquit.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmvendeur", "cmdquit_Click", Err, Erl())
	End Sub
	
	Private Sub cmdrechercheclient_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdrechercheclient.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstcatalog As ADODB.Recordset
15: Dim sDescription As String
20: Dim itmDescription As System.Windows.Forms.ListViewItem
		
25: sDescription = InputBox("Quelle est la description à rechercher")
		
30: If sDescription <> vbNullString Then
35: Call lstclient.Items.Clear()
			
40: sDescription = Replace(sDescription, "'", "''")
			
45: sDescription = "%" & sDescription & "%"
			
50: rstcatalog = New ADODB.Recordset
			
55: 
			Call rstcatalog.Open("SELECT DISTINCT NomClient FROM GRB_Client WHERE  NomClient LIKE '" & sDescription & "'  ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
60: Do While Not rstcatalog.EOF
65: itmDescription = lstclient.Items.Add("")
				
70: itmDescription.Tag = rstcatalog.Fields("NomClient").Value
				itmDescription.Text = rstcatalog.Fields("NomClient").Value
				
155: Call rstcatalog.MoveNext()
160: Loop 
			
165: Call rstcatalog.Close()
170: 'UPGRADE_NOTE: Object rstcatalog may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstcatalog = Nothing
			
175: If lstclient.Items.Count > 0 Then
180: lstclient.Visible = True
				
185: Call lstclient.Focus()
190: Else
195: Call MsgBox("Aucun enregistrement trouvé!")
200: End If
205: End If
		
210: Exit Sub
		
AfficherErreur: 
		
215: Call AfficherErreur("frmvendeur", "cmdrechercheclient_Click", Err, Erl())
		
		
	End Sub
	
	Private Sub cmdsave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdsave.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim rstVendeur As ADODB.Recordset
		
		'table vendeur ouvert
15: rstVendeur = New ADODB.Recordset
		Call FindFieldsExist("Enregistrerpar")
		Call FindFieldsExist("Type")
		
20: If m_bModeAjouter = True Then
25: Call rstVendeur.Open("SELECT * FROM GRB_vendeur", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
30: Call rstVendeur.AddNew()
			
35: m_bModeAjouter = False
40: Else
45: Call rstVendeur.Open("SELECT * FROM GRB_Vendeur WHERE [no] = " & lister.FocusedItem.Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
50: End If
		
		
		
		
55: rstVendeur.Fields("IDClient").Value = fracontact.Tag
60: rstVendeur.Fields("Date").Value = VB.Right(txtDate.Text, 8)
65: rstVendeur.Fields("Contact").Value = txtcontact.Text
70: rstVendeur.Fields("commentaire").Value = txtcommentaire.Text
		rstVendeur.Fields("EnregPar").Value = CStr(g_sUserID)
		rstVendeur.Fields("Etat").Value = CStr(cmbType.Text)
		
75: Call rstVendeur.Update()
		
		'ferme la table
80: Call rstVendeur.Close()
85: 'UPGRADE_NOTE: Object rstVendeur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstVendeur = Nothing
		
90: fracontact.Visible = False
		
		'rempli le lister
95: If m_eModeCherche = enumModeCherche.MODE_CLIENT Then
100: Call remplir_lister()
105: Else
110: Call remplir_lister_date()
115: End If
		
120: Exit Sub
		
AfficherErreur: 
		
125: Call AfficherErreur("frmvendeur", "cmdsave_Click", Err, Erl())
	End Sub
	
	Private Sub CmdSupp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdSupp.Click
		
5: On Error GoTo AfficherErreur
		
		'Supprime l'enregistrement sélectionné
10: If lister.Items.Count > 0 Then
15: Call g_connData.Execute("DELETE * FROM GRB_Vendeur WHERE [no] = " & lister.FocusedItem.Tag)
			
20: Call remplir_lister()
25: End If
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmvendeur", "CmdSupp_Click", Err, Erl())
	End Sub
	
	Private Sub frmvendeur_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
		'initialise les labels adresse et telephone
10: lblAdresse.Text = vbNullString
15: lbltelephone.Text = vbNullString
		
		cmbType.Items.Add(("Piste de vente"))
		cmbType.Items.Add(("Opportunité"))
		cmbType.Items.Add(("Soumission"))
		cmbType.Items.Add(("Gagner"))
		cmbType.Items.Add(("Perdu"))
		cmbType.Items.Add(("En attente"))
		cmbType.SelectedIndex = 0
		
		
		'rempli le comboclient et lister
20: Call remplir_comboclient()
		
25: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmvendeur", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub lister_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lister.DoubleClick
		
5: On Error GoTo AfficherErreur
		
		'Sur DblClick, affiche fenêtre pour modifié l'enreg selectionné dans lister
10: Dim rstVendeur As ADODB.Recordset
		
15: If lister.Items.Count <> 0 Then
20: If m_eModeCherche = enumModeCherche.MODE_CLIENT Then
				'si lister pas vide
				'met fenetre visible
25: fracontact.Visible = True
				
				'affiche les valeur dans la fenetre pour modifié
30: fracontact.Tag = numéroCompagnie
				'UPGRADE_WARNING: Lower bound of collection lister.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				txtNomCompagny.Text = lister.FocusedItem.SubItems(1).Text
35: txtDate.Text = lister.FocusedItem.Text
40: 'UPGRADE_WARNING: Lower bound of collection lister.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				txtcontact.Text = lister.FocusedItem.SubItems(2).Text
				'UPGRADE_WARNING: Lower bound of collection lister.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lister.FocusedItem.SubItems(3).Text = "" Then
					cmbType.SelectedIndex = 0
				Else
					'UPGRADE_WARNING: Lower bound of collection lister.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					cmbType.Text = lister.FocusedItem.SubItems(3).Text
45: End If
				'UPGRADE_WARNING: Lower bound of collection lister.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				txtcommentaire.Text = lister.FocusedItem.SubItems(4).Text
				
				'met en mode edition
50: m_bModeAjouter = False
55: Else
				'trouve le client pour afficher information
60: rstVendeur = New ADODB.Recordset
				
65: Call rstVendeur.Open("SELECT grb_vendeur.etat , grb_vendeur.no ,grb_vendeur.idclient , grb_vendeur.date ,grb_vendeur.contact, grb_vendeur.commentaire, grb_client.nomclient FROM GRB_vendeur inner join grb_client on grb_vendeur.idclient = grb_client.idclient WHERE [no] = " & lister.FocusedItem.Tag, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
				
70: fracontact.Visible = True
				
75: fracontact.Tag = rstVendeur.Fields("idclient").Value
80: txtDate.Text = rstVendeur.Fields("Date").Value
				txtNomCompagny.Text = rstVendeur.Fields("nomClient").Value
85: txtcontact.Text = rstVendeur.Fields("Contact").Value
90: txtcommentaire.Text = rstVendeur.Fields("commentaire").Value
				'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If IsDbNull(rstVendeur.Fields("Etat").Value) Then
					cmbType.SelectedIndex = 0
				Else
					cmbType.Text = rstVendeur.Fields("Etat").Value
				End If
				
				
100: Call rstVendeur.Close()
105: 'UPGRADE_NOTE: Object rstVendeur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rstVendeur = Nothing
110: End If
115: End If
		
120: Exit Sub
		
AfficherErreur: 
		
125: Call AfficherErreur("frmvendeur", "lister_DblClick", Err, Erl())
	End Sub
	
	Private Sub lister_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lister.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
		'Supprime l'enregistrement sélectionné
10: If lister.Items.Count > 0 Then
15: If KeyCode = System.Windows.Forms.Keys.Delete Then
20: Call g_connData.Execute("DELETE * FROM GRB_Vendeur WHERE [no] = " & lister.FocusedItem.Tag)
				
25: Call remplir_lister()
30: End If
35: End If
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmvendeur", "lister_KeyDown", Err, Erl())
	End Sub
	
	
	
	Private Sub lstclient_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstclient.DoubleClick
10: 
15: Dim iCompteur As Short
		Dim rstclientinfo As ADODB.Recordset
		Dim rstVendeur As ADODB.Recordset
		
		
		fracontact.Visible = False
20: Dim itmvendeurrec As System.Windows.Forms.ListViewItem
		If lstclient.Items.Count > 0 Then
25: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
30: 
			
			
65: cmbclient.Text = lstclient.FocusedItem.Text
75: 
			
			
80: lstclient.Visible = False
			rstclientinfo = New ADODB.Recordset
			Call rstclientinfo.Open("Select * From Grb_client where nomclient= '" & lstclient.FocusedItem.Text & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			lblAdresse.Text = vbNullString
			lbltelephone.Text = vbNullString
			If Not rstclientinfo.EOF Then numéroCompagnie = rstclientinfo.Fields("Idclient").Value
			'Ajoute les information de la base de donné au lbl correspondant
			Do While Not rstclientinfo.EOF
				'adresse
				'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstclientinfo.Fields("AdresseLiv").Value) Then lblAdresse.Text = lblAdresse.Text + rstclientinfo.Fields("AdresseLiv").Value
				'Ville
				'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstclientinfo.Fields("VilleLiv").Value) Then lblAdresse.Text = lblAdresse.Text & ", " + rstclientinfo.Fields("VilleLiv").Value
				'Pays
				'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstclientinfo.Fields("PaysLiv").Value) Then lblAdresse.Text = lblAdresse.Text & ", " + rstclientinfo.Fields("PaysLiv").Value
				'Prov
				'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstclientinfo.Fields("Prov/EtatLiv").Value) Then lblAdresse.Text = lblAdresse.Text & ", " + rstclientinfo.Fields("Prov/EtatLiv").Value
				'code postale
				'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstclientinfo.Fields("CodePostalLiv").Value) Then lblAdresse.Text = lblAdresse.Text & ", " + rstclientinfo.Fields("CodePostalLiv").Value
				'Téléphone
				If Not rstclientinfo.Fields("Telephonne").Value = "" Then lbltelephone.Text = lbltelephone.Text & "Tél: " + rstclientinfo.Fields("Telephonne").Value
				'Fax
				If Not rstclientinfo.Fields("Fax").Value = "" Then lbltelephone.Text = lbltelephone.Text & " Fax: " + rstclientinfo.Fields("Fax").Value
				'Pagette
				If Not rstclientinfo.Fields("Pagette").Value = "" Then lbltelephone.Text = lbltelephone.Text & " Page: " + rstclientinfo.Fields("Pagette").Value
				'Cellulaire
				If Not rstclientinfo.Fields("Cellulaire").Value = "" Then lbltelephone.Text = lbltelephone.Text & " Cell: " + rstclientinfo.Fields("Cellulaire").Value
				'Email
				If Not rstclientinfo.Fields("Email").Value = "" Then lbltelephone.Text = lbltelephone.Text & " Email: " + rstclientinfo.Fields("Email").Value
				Call rstclientinfo.MoveNext()
			Loop 
			
			
			
			
			
			
			'vide lister
			Call lister.Items.Clear()
			m_eModeCherche = enumModeCherche.MODE_CLIENT
			
			CmdAdd.Visible = True
			
			'ouvre la table pour client
			rstVendeur = New ADODB.Recordset
			
			Call rstVendeur.Open("SELECT grb_vendeur.etat , grb_vendeur.EnregPar, grb_vendeur.Contact, grb_vendeur.commentaire, grb_vendeur.no, grb_vendeur.Date FROM GRB_vendeur INNER JOIN GRB_Client ON Grb_Client.IDClient = grb_vendeur.IDclient where nomclient= '" & lstclient.FocusedItem.Text & "' ORDER BY no", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'temp que pas a la fin de la table
			Do While Not rstVendeur.EOF
				'ajoute au lister
				'UPGRADE_ISSUE: MSComctlLib.ListItems method lister.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				itmvendeurrec = lister.Items.Add()
				
				'no du client
				itmvendeurrec.Tag = rstVendeur.Fields("no").Value
				
				'vérifie les champs vide avant d'inséré
				'date
				'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If IsDbNull(rstVendeur.Fields("Date").Value) Then
					itmvendeurrec.Text = " "
				Else
					itmvendeurrec.Text = ConvertDate(DateSerial(CInt(VB.Left(rstVendeur.Fields("Date").Value, 2)), CInt(Mid(rstVendeur.Fields("Date").Value, 4, 2)), CInt(VB.Right(rstVendeur.Fields("Date").Value, 2))))
				End If
				'
				'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If IsDbNull(rstVendeur.Fields("Contact").Value) And IsDbNull(rstVendeur.Fields("commentaire").Value) And IsDbNull(rstVendeur.Fields("Date").Value) Then
					Call itmvendeurrec.SubItems.Add(vbNullString)
				Else
					Call itmvendeurrec.SubItems.Add(cmbclient.Text)
				End If
				'contact
				'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If IsDbNull(rstVendeur.Fields("Contact").Value) Then
					Call itmvendeurrec.SubItems.Add(vbNullString)
				Else
					Call itmvendeurrec.SubItems.Add(rstVendeur.Fields("Contact").Value)
				End If
				'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If IsDbNull(rstVendeur.Fields("etat").Value) Then
					Call itmvendeurrec.SubItems.Add(vbNullString)
				Else
					Call itmvendeurrec.SubItems.Add(rstVendeur.Fields("etat").Value)
				End If
				
				
				'commentaire
				'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If IsDbNull(rstVendeur.Fields("commentaire").Value) Then
					Call itmvendeurrec.SubItems.Add(vbNullString)
				Else
					Call itmvendeurrec.SubItems.Add(rstVendeur.Fields("commentaire").Value)
				End If
				
				'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If IsDbNull(rstVendeur.Fields("EnregPar").Value) Then
					Call itmvendeurrec.SubItems.Add(vbNullString)
				Else
					Call itmvendeurrec.SubItems.Add("Enregpar")
				End If
				
				
				
				'prochaine enreg
				Call rstVendeur.MoveNext()
			Loop 
			
			'fermeture table et bd
			Call rstVendeur.Close()
			'UPGRADE_NOTE: Object rstVendeur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstVendeur = Nothing
			
			Call rstclientinfo.Close()
			'UPGRADE_NOTE: Object rstclientinfo may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstclientinfo = Nothing
			
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		End If
	End Sub
	
	Private Sub lstClient_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstClient.Leave
		lstclient.Visible = False
	End Sub
	
	Private Sub mskDateCherche_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateCherche.Enter
		
5: On Error GoTo AfficherErreur
		
10: If Len(mskDateCherche.Text) = 10 Then
15: mskDateCherche.Text = VB.Right(mskDateCherche.Text, 8)
20: End If
		
25: mskDateCherche.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmvendeur", "mskDateCherche_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateCherche_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateCherche.Leave
		
5: On Error GoTo AfficherErreur
		
10: mskDateCherche.Mask = vbNullString
		
15: If mskDateCherche.Text = "__-__-__" Then
20: mskDateCherche.Text = vbNullString
25: Else
30: If Len(mskDateCherche.Text) = 8 Then
35: If IsDate(mskDateCherche.Text) Then
40: mskDateCherche.Text = Year(DateSerial(CInt(VB.Left(mskDateCherche.Text, 2)), CInt(Mid(mskDateCherche.Text, 4, 2)), CInt(VB.Right(mskDateCherche.Text, 2)))) & Mid(mskDateCherche.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmvendeur", "mskDateCherche_LostFocus", Err, Erl())
	End Sub
	
	Private Sub remplir_comboclient()
		
5: On Error GoTo AfficherErreur
		
		'''''''''''''''''''''''''
		'rempli le combo client '
		'''''''''''''''''''''''''
		
10: Dim rstClient As ADODB.Recordset
		
		'Set les tables
15: rstClient = New ADODB.Recordset
		
20: Call rstClient.Open("SELECT * FROM GRB_Client WHERE Supprimé = False ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'Vide combo
25: Call cmbclient.Items.Clear()
		If Not rstClient.EOF Then numéroCompagnie = rstClient.Fields("idclient").Value
		
		'Rempli les combo tant que pas fin d'enregistrement
30: Do While Not rstClient.EOF
35: Call cmbclient.Items.Add(rstClient.Fields("NomClient").Value)
			
40: 'UPGRADE_ISSUE: ComboBox property cmbclient.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(cmbclient, cmbclient.NewIndex, rstClient.Fields("IDClient").Value)
			
			'Prochaine enreg
45: Call rstClient.MoveNext()
50: Loop 
		
		'Ferme table
55: Call rstClient.Close()
60: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient = Nothing
		
65: If cmbclient.Items.Count > 0 Then
70: cmbclient.SelectedIndex = 0
			
75: End If
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmvendeur", "remplir_comboclient", Err, Erl())
	End Sub
	Private Sub remplir_lister_date()
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''
		' rempli le lister '
		''''''''''''''''''''
10: Dim itmVendeur As System.Windows.Forms.ListViewItem
15: Dim rstVendeur As ADODB.Recordset
		
20: m_eModeCherche = enumModeCherche.MODE_DATE
		
25: CmdAdd.Visible = False
		
		'vide lister
30: Call lister.Items.Clear()
		
		'ouvre la table pour client
35: rstVendeur = New ADODB.Recordset
		
40: Call rstVendeur.Open("SELECT grb_vendeur.no , grb_vendeur.date , grb_vendeur.etat , grb_vendeur.EnregPar , grb_vendeur.Contact , grb_vendeur.commentaire , grb_client.NomClient FROM GRB_client Inner join grb_vendeur on grb_vendeur.IDClient = grb_client.IDClient WHERE grb_vendeur.Date = '" & VB.Right(mskDateCherche.Text, 8) & "' ORDER BY grb_vendeur.no", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'temp que pas a la fin de la table
45: Do While Not rstVendeur.EOF
			'ajoute au lister
50: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lister.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmVendeur = lister.Items.Add()
			
			'no du client
55: itmVendeur.Tag = rstVendeur.Fields("no").Value
			
			'vérifie les champs vide avant d'inséré
			'date
60: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstVendeur.Fields("Date").Value) Then
65: itmVendeur.Text = vbNullString
70: Else
75: itmVendeur.Text = ConvertDate(DateSerial(CInt(VB.Left(rstVendeur.Fields("Date").Value, 2)), CInt(Mid(rstVendeur.Fields("Date").Value, 4, 2)), CInt(VB.Right(rstVendeur.Fields("Date").Value, 2))))
80: End If
			'Nom Compagnie
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstVendeur.Fields("nomclient").Value) Then
				Call itmVendeur.SubItems.Add(vbNullString)
			Else
				Call itmVendeur.SubItems.Add(rstVendeur.Fields("nomclient").Value)
			End If
			
			
			
			'contact
85: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstVendeur.Fields("Contact").Value) Then
90: Call itmVendeur.SubItems.Add(vbNullString)
95: Else
100: Call itmVendeur.SubItems.Add(rstVendeur.Fields("Contact").Value)
105: End If
			'État
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstVendeur.Fields("etat").Value) Then
				Call itmVendeur.SubItems.Add(vbNullString)
			Else
				Call itmVendeur.SubItems.Add(rstVendeur.Fields("etat").Value)
			End If
			
			'commentaire
110: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstVendeur.Fields("commentaire").Value) Then
115: Call itmVendeur.SubItems.Add(vbNullString)
120: Else
125: Call itmVendeur.SubItems.Add(rstVendeur.Fields("commentaire").Value)
130: End If
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rstVendeur.Fields("EnregPar").Value) Then
				Call itmVendeur.SubItems.Add(vbNullString)
			Else
				Call itmVendeur.SubItems.Add(rstVendeur.Fields("EnregPar").Value)
			End If
			
			'prochaine enreg
135: Call rstVendeur.MoveNext()
140: Loop 
		
		'fermeture table et bd
145: Call rstVendeur.Close()
150: 'UPGRADE_NOTE: Object rstVendeur may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstVendeur = Nothing
		
155: Exit Sub
		
AfficherErreur: 
		
160: Call AfficherErreur("frmvendeur", "remplir_lister_date", Err, Erl())
	End Sub
End Class