Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmExportToOutLook
	Inherits System.Windows.Forms.Form
	
	
	Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
		Me.Close()
	End Sub
	
	Private Sub frmExportToOutLook_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Me.ckClient.CheckState = False
		Me.ckContact.CheckState = False
		Me.ckFRS.CheckState = False
		
	End Sub
	
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		
		If Me.ckContact.CheckState = 1 Then
			'export les contacts
			If VerifierSiBesoinExport("SELECT * FROM GRB_Contact", "Contacts GRB") Then
				Call SupprimerContactExchange("Contacts GRB", "contacts")
				Call ExportContactExchange("SELECT * FROM GRB_Contact", "Contacts GRB")
			End If
		End If
		If Me.ckClient.CheckState = 1 Then
			'export les clients
			If VerifierSiBesoinExport("SELECT * FROM GRB_Client", "Clients GRB") Then
				Call SupprimerContactExchange("Clients GRB", "clients")
				Call ExportClientExchange("SELECT * FROM GRB_Client", "Clients GRB")
			End If
		End If
		If Me.ckFRS.CheckState = 1 Then
			'export les fournisseurs
			If VerifierSiBesoinExport("SELECT * FROM GRB_Fournisseur", "Fournisseurs GRB") Then
				Call SupprimerContactExchange("Fournisseurs GRB", "fournisseurs")
				Call ExportFournisseursExchange("SELECT * FROM GRB_Fournisseur", "Fournisseurs GRB")
			End If
		End If
		
		MsgBox("Exportation des données réussi.")
		
		
	End Sub
	Private Function VerifierSiBesoinExport(ByVal strQuery As String, ByVal strFolder As String) As Boolean
		
5: On Error GoTo AfficherErreur
		
6: VerifierSiBesoinExport = False
		
7: Dim dummie As Short
		
10: Dim otlApp As Outlook.Application
15: Dim otlContact As Outlook.ContactItem
20: Dim folContact As Outlook.MAPIFolder
25: Dim bDejaOuvert As Boolean
30: Dim sNom() As String
31: Dim rstContact As ADODB.Recordset
32: Dim i As Short
33: Dim Y As Short
		
		
34: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
35: lblEtatOutlook.Text = "Validation ..."
36: lblnbre.Text = "Vérifier si nous avons besoin de faire l'exportation."
37: fraEtatOutlook.Visible = True
		
40: rstContact = New ADODB.Recordset
41: Call rstContact.Open(strQuery, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
43: 'nombre total de records dans GRB
44: i = 0
45: rstContact.MoveFirst()
46: Do While Not rstContact.EOF
47: i = i + 1
48: rstContact.MoveNext()
49: Loop 
		
64: 'nombre total de records dans Outlook
65: Y = 0
66: otlApp = OuvrirOutlook(bDejaOuvert)
70: folContact = GetFolder(otlApp, strFolder)
71: Y = folContact.Items.Count
		
		
80: dummie = MsgBox("Nous avons " & i & " records dans GRB et " & Y & " records dans Outlook." & Chr(13) & Chr(13) & "Désirez-vous toujours faire l'exportation dans Outlook?", MsgBoxStyle.YesNo, "Exportation dans Outlook")
		
85: If dummie = MsgBoxResult.Yes Then
86: VerifierSiBesoinExport = True
87: Else
88: VerifierSiBesoinExport = False
89: End If
		
		
320: Call rstContact.Close()
325: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
330: If bDejaOuvert = False Then
335: Call otlApp.Quit()
340: End If
		
341: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		otlApp = Nothing
		
342: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
343: fraEtatOutlook.Visible = False
		
345: System.Windows.Forms.Application.DoEvents()
		
350: Exit Function
		
		
		
		
AfficherErreur: 
		
355: Call AfficherErreur("frmExportToOutlook", "VerifierSiBesoinExport", Err, Erl())
356: Call rstContact.Close()
357: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
	End Function
	Private Function ExportContactExchange(ByVal strQuery As String, ByVal strFolder As String) As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim otlContact As Outlook.ContactItem
20: Dim folContact As Outlook.MAPIFolder
25: Dim bDejaOuvert As Boolean
30: Dim sNom() As String
35: Dim rstContact As ADODB.Recordset
36: Dim i As Short
		
37: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
40: rstContact = New ADODB.Recordset
45: Call rstContact.Open(strQuery, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
42: i = 0
43: rstContact.MoveFirst()
46: Do While Not rstContact.EOF
47: i = i + 1
48: rstContact.MoveNext()
49: Loop 
		
50: lblEtatOutlook.Text = "Ajout des contacts dans Outlook ..."
55: lblnbre.Text = "Nombre de contact restant à transférer : " & i
60: fraEtatOutlook.Visible = True
		
65: otlApp = OuvrirOutlook(bDejaOuvert)
70: folContact = GetFolder(otlApp, strFolder)
		
90: rstContact.MoveFirst()
100: Do While Not rstContact.EOF
			
120: otlContact = folContact.Items.Add(Outlook.OlItemType.olContactItem)
			
130: otlContact.User1 = rstContact.Fields("IDContact").Value
			
131: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("NomContact").Value) Then
135: sNom = Split(Trim(rstContact.Fields("NomContact").Value), " ")
				
140: Select Case UBound(sNom)
					Case 0
145: otlContact.FirstName = sNom(0)
						
					Case 1
150: otlContact.FirstName = sNom(0)
155: otlContact.LastName = sNom(1)
						
					Case 2
160: otlContact.FirstName = sNom(0)
165: otlContact.MiddleName = sNom(1)
170: otlContact.LastName = sNom(2)
175: End Select
176: End If
			
180: otlContact.Title = ""
			
181: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("Compagnie").Value) Then
184: otlContact.CompanyName = rstContact.Fields("Compagnie").Value
185: End If
186: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("Titre").Value) Or Not rstContact.Fields("Titre").Value = "" Then
190: otlContact.JobTitle = rstContact.Fields("Titre").Value
191: End If
			
195: If rstContact.Fields("Telephonne").Value <> "(___) ___-____" Then
				'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(rstContact.Fields("NoPoste").Value) Then
200: If Trim(rstContact.Fields("NoPoste").Value) <> "" Then
205: otlContact.BusinessTelephoneNumber = rstContact.Fields("Telephonne").Value & " Ext : " & rstContact.Fields("NoPoste").Value
210: Else
215: otlContact.BusinessTelephoneNumber = rstContact.Fields("Telephonne").Value
220: End If
				Else
					otlContact.BusinessTelephoneNumber = rstContact.Fields("Telephonne").Value
				End If
225: End If
			
230: If rstContact.Fields("Fax").Value <> "(___) ___-____" Then
235: otlContact.BusinessFaxNumber = rstContact.Fields("Fax").Value
240: End If
			
245: If rstContact.Fields("Cellulaire").Value <> "(___) ___-____" Then
250: otlContact.MobileTelephoneNumber = rstContact.Fields("Cellulaire").Value
255: End If
			
260: If rstContact.Fields("Pagette").Value <> "(___) ___-____" Then
265: otlContact.PagerNumber = rstContact.Fields("Pagette").Value
270: End If
			
274: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstContact.Fields("E-mail").Value) And Not rstContact.Fields("E-mail").Value = "" Then
275: otlContact.Email1Address = rstContact.Fields("E-mail").Value
276: End If
			
280: If rstContact.Fields("TelDomicile").Value <> "(___) ___-____" Then
285: otlContact.HomeTelephoneNumber = rstContact.Fields("TelDomicile").Value
290: End If
			
295: If rstContact.Fields("Commentaire").Value <> "" Then
300: otlContact.Body = rstContact.Fields("Commentaire").Value
305: End If
			
309: Call otlContact.Save()
			
310: rstContact.Fields("DateModification").Value = ConvertDate(Today)
311: rstContact.Fields("UserModification").Value = g_sInitiale
			
312: rstContact.Fields("EntryIDOutlook").Value = otlContact.EntryID
313: rstContact.Update()
			
315: rstContact.MoveNext()
316: i = i - 1
317: lblnbre.Text = "Nombre de contact restant à transférer : " & i
318: Me.Refresh()
319: Loop 
		
320: Call rstContact.Close()
325: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
		
330: If bDejaOuvert = False Then
335: Call otlApp.Quit()
340: End If
		
341: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		otlApp = Nothing
		
342: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
343: fraEtatOutlook.Visible = False
		
345: System.Windows.Forms.Application.DoEvents()
		
350: Exit Function
		
AfficherErreur: 
		
355: Call AfficherErreur("frmExportToOutlook", "ExportContactExchange", Err, Erl(), "iContactID = " & rstContact.Fields("IDContact").Value)
356: Call rstContact.Close()
357: 'UPGRADE_NOTE: Object rstContact may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstContact = Nothing
360: fraEtatOutlook.Visible = False
	End Function
	Private Function ExportClientExchange(ByVal strQuery As String, ByVal strFolder As String) As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim otlClient As Outlook.ContactItem
20: Dim folClient As Outlook.MAPIFolder
25: Dim bDejaOuvert As Boolean
30: Dim sNom() As String
35: Dim rstClient As ADODB.Recordset
36: Dim i As Short
		
37: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
40: rstClient = New ADODB.Recordset
41: Call rstClient.Open(strQuery, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
42: i = 0
43: rstClient.MoveFirst()
46: Do While Not rstClient.EOF
47: i = i + 1
48: rstClient.MoveNext()
49: Loop 
		
50: lblEtatOutlook.Text = "Ajout des clients dans Outlook ..."
55: lblnbre.Text = "Nombre de client restant à transférer : " & i
60: fraEtatOutlook.Visible = True
		
65: otlApp = OuvrirOutlook(bDejaOuvert)
70: folClient = GetFolder(otlApp, strFolder)
		
90: rstClient.MoveFirst()
100: Do While Not rstClient.EOF
			
120: otlClient = folClient.Items.Add(Outlook.OlItemType.olContactItem)
			
130: otlClient.User1 = rstClient.Fields("IDClient").Value
			
131: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstClient.Fields("NomClient").Value) Then
132: otlClient.CompanyName = rstClient.Fields("NomClient").Value
133: End If
			
135: If rstClient.Fields("Telephonne").Value <> "(___) ___-____" Then
140: otlClient.BusinessTelephoneNumber = rstClient.Fields("Telephonne").Value
145: End If
			
150: If rstClient.Fields("Fax").Value <> "(___) ___-____" Then
155: otlClient.BusinessFaxNumber = rstClient.Fields("Fax").Value
160: End If
164: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstClient.Fields("Email").Value) Then
165: otlClient.Email1Address = rstClient.Fields("Email").Value
166: End If
169: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstClient.Fields("AdresseLiv").Value) Then
170: otlClient.BusinessAddressStreet = rstClient.Fields("AdresseLiv").Value
171: End If
174: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstClient.Fields("VilleLiv").Value) Then
175: otlClient.BusinessAddressCity = rstClient.Fields("VilleLiv").Value
176: End If
179: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstClient.Fields("Prov/EtatLiv").Value) Then
180: otlClient.BusinessAddressState = rstClient.Fields("Prov/EtatLiv").Value
181: End If
184: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstClient.Fields("PaysLiv").Value) Then
185: otlClient.BusinessAddressCountry = rstClient.Fields("PaysLiv").Value
186: End If
189: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstClient.Fields("CodePostalLiv").Value) Then
190: otlClient.BusinessAddressPostalCode = rstClient.Fields("CodePostalLiv").Value
191: End If
194: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstClient.Fields("Commentaire").Value) Then
195: otlClient.Body = rstClient.Fields("Commentaire").Value
196: End If
199: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstClient.Fields("SiteWeb").Value) Then
200: otlClient.WebPage = rstClient.Fields("SiteWeb").Value
201: End If
			
309: Call otlClient.Save()
			
310: rstClient.Fields("DateModification").Value = ConvertDate(Today)
311: rstClient.Fields("UserModification").Value = g_sInitiale
			
312: rstClient.Fields("EntryIDOutlook").Value = otlClient.EntryID
313: rstClient.Update()
			
315: rstClient.MoveNext()
316: i = i - 1
317: lblnbre.Text = "Nombre de client restant à transférer : " & i
318: Me.Refresh()
319: Loop 
		
320: Call rstClient.Close()
325: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient = Nothing
		
330: If bDejaOuvert = False Then
335: Call otlApp.Quit()
340: End If
		
341: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		otlApp = Nothing
		
342: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
343: fraEtatOutlook.Visible = False
		
345: System.Windows.Forms.Application.DoEvents()
		
350: Exit Function
		
AfficherErreur: 
		
355: Call AfficherErreur("frmExportToOutlook", "ExportClientExchange", Err, Erl(), "iClientID = " & rstClient.Fields("IDClient").Value)
356: Call rstClient.Close()
357: 'UPGRADE_NOTE: Object rstClient may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstClient = Nothing
360: fraEtatOutlook.Visible = False
	End Function
	Private Function ExportFournisseursExchange(ByVal strQuery As String, ByVal strFolder As String) As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim otlFRS As Outlook.ContactItem
20: Dim folFRS As Outlook.MAPIFolder
25: Dim bDejaOuvert As Boolean
30: Dim sNom() As String
35: Dim rstFRS As ADODB.Recordset
36: Dim i As Short
		
37: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
40: rstFRS = New ADODB.Recordset
41: Call rstFRS.Open(strQuery, g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
42: i = 0
43: rstFRS.MoveFirst()
46: Do While Not rstFRS.EOF
47: i = i + 1
48: rstFRS.MoveNext()
49: Loop 
		
50: lblEtatOutlook.Text = "Ajout des fournisseurs dans Outlook ..."
55: lblnbre.Text = "Nombre de fournisseur restant à transférer : " & i
60: fraEtatOutlook.Visible = True
		
65: otlApp = OuvrirOutlook(bDejaOuvert)
70: folFRS = GetFolder(otlApp, strFolder)
		
90: rstFRS.MoveFirst()
100: Do While Not rstFRS.EOF
			
120: otlFRS = folFRS.Items.Add(Outlook.OlItemType.olContactItem)
130: otlFRS.User1 = rstFRS.Fields("IDFRS").Value
			
131: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstFRS.Fields("NomFournisseur").Value) Then
132: otlFRS.CompanyName = rstFRS.Fields("NomFournisseur").Value
133: End If
			
135: If rstFRS.Fields("Telephonne").Value <> "(___) ___-____" Then
140: otlFRS.BusinessTelephoneNumber = rstFRS.Fields("Telephonne").Value
145: End If
			
150: If rstFRS.Fields("Fax").Value <> "(___) ___-____" Then
155: otlFRS.BusinessFaxNumber = rstFRS.Fields("Fax").Value
160: End If
164: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstFRS.Fields("E-mail").Value) Then
165: otlFRS.Email1Address = rstFRS.Fields("E-mail").Value
166: End If
169: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstFRS.Fields("Adresse").Value) Then
170: otlFRS.BusinessAddressStreet = rstFRS.Fields("Adresse").Value
171: End If
174: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstFRS.Fields("Ville").Value) Then
175: otlFRS.BusinessAddressCity = rstFRS.Fields("Ville").Value
176: End If
179: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstFRS.Fields("Prov/Etat").Value) Then
180: otlFRS.BusinessAddressState = rstFRS.Fields("Prov/Etat").Value
181: End If
184: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstFRS.Fields("Pays").Value) Then
185: otlFRS.BusinessAddressCountry = rstFRS.Fields("Pays").Value
186: End If
189: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstFRS.Fields("CodePostal").Value) Then
190: otlFRS.BusinessAddressPostalCode = rstFRS.Fields("CodePostal").Value
191: End If
194: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstFRS.Fields("Commentaire").Value) Then
195: otlFRS.Body = rstFRS.Fields("Commentaire").Value
196: End If
199: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstFRS.Fields("SiteWeb").Value) Then
200: otlFRS.WebPage = rstFRS.Fields("SiteWeb").Value
201: End If
			
309: Call otlFRS.Save()
			
310: rstFRS.Fields("DateModification").Value = ConvertDate(Today)
311: rstFRS.Fields("UserModification").Value = g_sInitiale
			
312: rstFRS.Fields("EntryIDOutlook").Value = otlFRS.EntryID
313: rstFRS.Update()
			
315: rstFRS.MoveNext()
316: i = i - 1
317: lblnbre.Text = "Nombre de fournisseur restant à transférer : " & i
318: Me.Refresh()
319: Loop 
		
320: Call rstFRS.Close()
325: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
		
330: If bDejaOuvert = False Then
335: Call otlApp.Quit()
340: End If
		
341: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		otlApp = Nothing
		
342: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
343: fraEtatOutlook.Visible = False
		
345: System.Windows.Forms.Application.DoEvents()
		
350: Exit Function
		
AfficherErreur: 
		
355: Call AfficherErreur("frmExportToOutlook", "ExportClientExchange", Err, Erl(), "iFRSID = " & rstFRS.Fields("IDFRS").Value)
356: Call rstFRS.Close()
357: 'UPGRADE_NOTE: Object rstFRS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstFRS = Nothing
360: fraEtatOutlook.Visible = False
	End Function
	
	Private Function SupprimerContactExchange(ByVal strFolder As String, ByVal strName As String) As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim otlApp As Outlook.Application
15: Dim otlContact As Outlook.ContactItem
20: Dim folContact As Outlook.MAPIFolder
25: Dim bDejaOuvert As Boolean
26: Dim i As Short
		
28: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
30: lblEtatOutlook.Text = "Suppression des " & strName & " dans Outlook ..."
35: fraEtatOutlook.Visible = True
		
40: otlApp = OuvrirOutlook(bDejaOuvert)
		
45: folContact = GetFolder(otlApp, strFolder)
		
47: i = folContact.Items.Count
48: Do While Not folContact.Items.Count = 0
			otlContact = folContact.Items.GetFirst
54: Call otlContact.Delete()
55: i = i - 1
57: lblnbre.Text = i & " " & strName & " restant à supprimer."
58: Me.Refresh()
60: Loop 
70: If bDejaOuvert = False Then
75: Call otlApp.Quit()
80: End If
		
85: 'UPGRADE_NOTE: Object otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		otlApp = Nothing
		
87: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
90: fraEtatOutlook.Visible = False
		
95: System.Windows.Forms.Application.DoEvents()
		
100: Exit Function
		
AfficherErreur: 
		
105: Call AfficherErreur("frmExportToOutlook", "SupprimerContactExchange", Err, Erl())
		
110: fraEtatOutlook.Visible = False
	End Function
End Class