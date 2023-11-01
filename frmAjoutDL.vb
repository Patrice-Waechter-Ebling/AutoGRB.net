Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmAjoutDL
	Inherits System.Windows.Forms.Form
	Private m_rstData As ADODB.Recordset
	
	Private Const I_OPT_CONTACTS As Short = 0
	Private Const I_OPT_CLIENTS As Short = 1
	Private Const I_OPT_CLIENTS_FACTURES As Short = 2
	Private Const I_OPT_FRS As Short = 3
	Private Const I_OPT_GROUPEMENT As Short = 4
	Private Const I_OPT_MEAT_PROCESSING As Short = 5
	
	Private Const I_OPT_DOSSIER_CONTACTS As Short = 0
	Private Const I_OPT_DOSSIER_CLIENTS As Short = 1
	Private Const I_OPT_DOSSIER_FRS As Short = 2
	
	Private m_otlApp As Outlook.Application
	Private m_bDejaOuvert As Boolean
	Private m_arr_sException() As String
	
	Private Sub cmdCreer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCreer.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim folDestination As Outlook.MAPIFolder
15: Dim folSource As Outlook.MAPIFolder
20: Dim itmContact As Outlook.ContactItem
25: Dim otlDistList As Outlook.DistListItem
30: Dim otlRecipient As Outlook.Recipient
35: Dim myItems As Outlook.Items
40: Dim objItem As Object
45: Dim iIndexListe As Short
50: Dim rstData As ADODB.Recordset
		
55: If optChoix(0).Checked = True Or optChoix(1).Checked = True Or optChoix(2).Checked = True Or optChoix(3).Checked = True Or optChoix(4).Checked = True Or optChoix(5).Checked = True Then
60: If optChoixDossier(0).Checked = True Or optChoixDossier(1).Checked = True Or optChoixDossier(2).Checked = True Then
65: If Trim(txtPrefixe.Text) <> "" Then
70: fraChoixListe.Enabled = False
75: fraChoixDossier.Enabled = False
80: cmdCreer.Enabled = False
85: cmdExceptions.Enabled = False
90: txtPrefixe.Enabled = False
					
95: Call RemplirArrayExceptions()
					
100: If optChoix(I_OPT_CLIENTS_FACTURES).Checked = True Then
105: Call MsgBox("Veuillez noter que cette liste peut prendre plusieurs minutes avant de débuter!", MsgBoxStyle.Information)
110: End If
					
115: If optChoix(I_OPT_GROUPEMENT).Checked = True Or optChoix(I_OPT_MEAT_PROCESSING).Checked = True Then
120: Call AjouterGroupementMeatProcessing()
						
125: fraChoixListe.Enabled = True
130: fraChoixDossier.Enabled = True
135: cmdCreer.Enabled = True
140: cmdExceptions.Enabled = True
145: txtPrefixe.Enabled = True
						
150: Exit Sub
155: End If
					
160: rstData = New ADODB.Recordset
					
165: rstData.CursorLocation = ADODB.CursorLocationEnum.adUseClient
					
170: If optChoix(I_OPT_CONTACTS).Checked = True Then
175: Call rstData.Open("SELECT * FROM GRB_Contact WHERE [E-mail] Is Not null And [E-mail] <> '' ORDER BY NomContact", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
						
180: folSource = GetFolder(m_otlApp, "Contacts GRB")
185: Else
190: If optChoix(I_OPT_FRS).Checked = True Then
195: Call rstData.Open("SELECT * FROM GRB_Fournisseur WHERE [E-mail] Is Not null And [E-mail] <> '' ORDER BY NomFournisseur", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
							
200: folSource = GetFolder(m_otlApp, "Fournisseurs GRB")
205: Else
210: If optChoix(I_OPT_CLIENTS).Checked = True Then
215: Call rstData.Open("SELECT * FROM GRB_Client WHERE Email Is Not null And Email <> '' ORDER BY NomClient", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
220: Else
225: Call rstData.Open("SELECT DISTINCT(GRB_Punch.NoClient), GRB_Client.NomClient FROM GRB_Punch INNER JOIN GRB_Client ON CInt(GRB_Punch.NoClient) = CInt(GRB_Client.IDClient) WHERE GRB_Punch.NoClient <> '' AND GRB_Punch.NoClient Is Not Null AND GRB_Punch.Facturé = True AND Email Is Not null And Email <> '' ORDER BY GRB_Client.NomClient", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
230: End If
							
235: folSource = GetFolder(m_otlApp, "Clients GRB")
240: End If
245: End If
					
250: If optChoixDossier(I_OPT_CONTACTS).Checked = True Then
255: folDestination = GetFolder(m_otlApp, "Contacts GRB")
260: Else
265: If optChoixDossier(I_OPT_CLIENTS).Checked = True Then
270: folDestination = GetFolder(m_otlApp, "Clients GRB")
275: Else
280: folDestination = GetFolder(m_otlApp, "Fournisseurs GRB")
285: End If
290: End If
					
295: pgb.Minimum = 0
300: pgb.Maximum = rstData.RecordCount
305: pgb.Value = 0
					
310: iIndexListe = 1
					
315: Do While Not rstData.EOF
320: 'UPGRADE_NOTE: Object otlDistList may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						otlDistList = Nothing
						
325: myItems = folDestination.Items.Restrict("[MessageClass] = 'IPM.DistList'")
						
330: For	Each objItem In myItems
335: 'UPGRADE_WARNING: Couldn't resolve default property of object objItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If objItem = txtPrefixe.Text & VB.Right("00" & iIndexListe, 3) Then
340: otlDistList = objItem
								
345: Exit For
350: End If
355: Next objItem
						
360: If otlDistList Is Nothing Then
365: otlDistList = folDestination.Items.Add(Outlook.OlItemType.olDistributionListItem)
							
370: otlDistList.DLName = txtPrefixe.Text & VB.Right("00" & iIndexListe, 3)
							
375: Call otlDistList.Save()
380: Else
385: If otlDistList.MemberCount = 10 Then
390: iIndexListe = iIndexListe + 1
								
395: otlDistList = folDestination.Items.Add(Outlook.OlItemType.olDistributionListItem)
								
400: otlDistList.DLName = txtPrefixe.Text & VB.Right("00" & iIndexListe, 3)
								
405: Call otlDistList.Save()
410: End If
415: End If
						
420: If optChoix(I_OPT_CONTACTS).Checked = True Then
425: itmContact = folSource.Items.Find("[User1] = " & rstData.Fields("IDContact").Value)
430: Else
435: If optChoix(I_OPT_FRS).Checked = True Then
440: itmContact = folSource.Items.Find("[User1]= " & rstData.Fields("IDFRS").Value)
445: Else
450: If optChoix(I_OPT_CLIENTS).Checked = True Then
455: itmContact = folSource.Items.Find("[User1] = " & rstData.Fields("IDClient").Value)
460: Else
465: itmContact = folSource.Items.Find("[User1] = " & rstData.Fields("NoClient").Value)
470: End If
475: End If
480: End If
						
485: If Not itmContact Is Nothing Then
490: If IsException(itmContact.Email1Address) = False Then
495: otlRecipient = m_otlApp.Session.CreateRecipient(itmContact.Email1DisplayName)
								
500: If otlRecipient.Resolve = True Then
505: Call otlDistList.AddMember(otlRecipient)
									
510: Call otlDistList.Save()
515: End If
520: End If
525: Else
530: If optChoix(I_OPT_CONTACTS).Checked = True Then
535: Call MsgBox("Le contact " & rstData.Fields("NomContact").Value & " n'a pas été trouvé dans outlook.")
540: Else
545: If optChoix(I_OPT_FRS).Checked = True Then
550: Call MsgBox("Le fournisseur " & rstData.Fields("NomFournisseur").Value & " n'a pas été trouvé dans outlook.")
555: Else
560: Call MsgBox("Le client " & rstData.Fields("NomClient").Value & " n'a pas été trouvé dans outlook.")
565: End If
570: End If
575: End If
						
580: pgb.Value = pgb.Value + 1
						
585: System.Windows.Forms.Application.DoEvents()
						
590: Call rstData.MoveNext()
595: Loop 
					
600: Call rstData.Close()
605: 'UPGRADE_NOTE: Object rstData may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					rstData = Nothing
					
610: Call MsgBox("Terminé!")
					
615: fraChoixDossier.Enabled = True
620: fraChoixListe.Enabled = True
625: cmdCreer.Enabled = True
630: cmdExceptions.Enabled = True
635: txtPrefixe.Enabled = True
640: Else
645: Call MsgBox("Le préfixe de la liste à créer ne doit pas être vide!", MsgBoxStyle.OKOnly, "Erreur")
650: End If
655: Else
660: Call MsgBox("Vous devez choisir un dossier de destination dans Outlook!", MsgBoxStyle.OKOnly, "Erreur")
665: End If
670: Else
675: Call MsgBox("Vous devez choisir une liste à faire!", MsgBoxStyle.OKOnly, "Erreur")
680: End If
		
685: Exit Sub
		
AfficherErreur: 
		
690: Call AfficherErreur("frmAjoutDL", "cmdCreer_Click", Err, Erl())
	End Sub
	
	Private Sub AjouterGroupementMeatProcessing()
		
5: On Error GoTo AfficherErreur
		
10: Dim folContact As Outlook.MAPIFolder
15: Dim folClient As Outlook.MAPIFolder
20: Dim folDestination As Outlook.MAPIFolder
25: Dim itmContact As Outlook.ContactItem
30: Dim otlDistList As Outlook.DistListItem
35: Dim otlRecipient As Outlook.Recipient
40: Dim myItems As Outlook.Items
45: Dim objItem As Object
50: Dim iIndexListe As Short
55: Dim rstData As ADODB.Recordset
		
60: rstData = New ADODB.Recordset
		
65: rstData.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		
		'E-mail = Courriel du contact
		'Email = Courriel du client
70: If optChoix(I_OPT_GROUPEMENT).Checked = True Then
75: Call rstData.Open("SELECT IDContact, [E-mail], IDClient, Email FROM (GRB_ContactClient INNER JOIN GRB_Client ON GRB_ContactClient.noclient = GRB_Client.IDClient) INNER JOIN GRB_contact ON GRB_ContactClient.nocontact = GRB_contact.IDContact WHERE (INSTR(Titre,'(Groupement des chefs') > 0) AND ([E-mail] <> '' OR Email <> '') ORDER BY GRB_Contact.NomContact", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
80: Else
85: Call rstData.Open("SELECT IDContact, [E-mail], IDClient, Email FROM (GRB_ContactClient INNER JOIN GRB_Client ON GRB_ContactClient.noclient = GRB_Client.IDClient) INNER JOIN GRB_contact ON GRB_ContactClient.nocontact = GRB_contact.IDContact WHERE (INSTR(Titre,'(Meat Processing)') > 0) AND ([E-mail] <> '' OR Email <> '') ORDER BY GRB_Contact.NomContact", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
90: End If
		
95: folContact = GetFolder(m_otlApp, "Contacts GRB")
100: folClient = GetFolder(m_otlApp, "Clients GRB")
		
105: If optChoixDossier(I_OPT_DOSSIER_CONTACTS).Checked = True Then
110: folDestination = folContact
115: Else
120: If optChoixDossier(I_OPT_DOSSIER_CLIENTS).Checked = True Then
125: folDestination = folClient
130: Else
135: folDestination = GetFolder(m_otlApp, "Fournisseurs GRB")
140: End If
145: End If
		
150: pgb.Minimum = 0
155: pgb.Maximum = rstData.RecordCount
160: pgb.Value = 0
		
165: iIndexListe = 1
		
170: Do While Not rstData.EOF
175: 'UPGRADE_NOTE: Object otlDistList may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			otlDistList = Nothing
			
180: myItems = folDestination.Items.Restrict("[MessageClass] = 'IPM.DistList'")
			
185: For	Each objItem In myItems
190: 'UPGRADE_WARNING: Couldn't resolve default property of object objItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If objItem = txtPrefixe.Text & VB.Right("00" & iIndexListe, 3) Then
195: otlDistList = objItem
					
200: Exit For
205: End If
210: Next objItem
			
215: If otlDistList Is Nothing Then
220: otlDistList = folDestination.Items.Add(Outlook.OlItemType.olDistributionListItem)
				
225: otlDistList.DLName = txtPrefixe.Text & VB.Right("00" & iIndexListe, 3)
				
230: Call otlDistList.Save()
235: Else
240: If otlDistList.MemberCount = 10 Then
245: iIndexListe = iIndexListe + 1
					
250: otlDistList = folDestination.Items.Add(Outlook.OlItemType.olDistributionListItem)
					
255: otlDistList.DLName = txtPrefixe.Text & VB.Right("00" & iIndexListe, 3)
					
260: Call otlDistList.Save()
265: End If
270: End If
			
275: If rstData.Fields("E-mail").Value <> "" Then 'Si le contact a un e-mail then
280: itmContact = folContact.Items.Find("[User1] = " & rstData.Fields("IDContact").Value)
285: Else
				'Sinon, on prend le courriel du client
290: itmContact = folClient.Items.Find("[User1] = " & rstData.Fields("IDClient").Value)
295: End If
			
300: If Not itmContact Is Nothing Then
305: If IsException(itmContact.Email1Address) = False Then
310: otlRecipient = m_otlApp.Session.CreateRecipient(itmContact.Email1DisplayName)
					
315: If otlRecipient.Resolve = True Then
320: Call otlDistList.AddMember(otlRecipient)
						
325: Call otlDistList.Save()
330: End If
335: End If
340: End If
			
345: pgb.Value = pgb.Value + 1
			
350: System.Windows.Forms.Application.DoEvents()
			
355: Call rstData.MoveNext()
360: Loop 
		
365: Call rstData.Close()
370: 'UPGRADE_NOTE: Object rstData may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstData = Nothing
		
375: Call MsgBox("Terminé!")
		
380: Exit Sub
		
AfficherErreur: 
		
385: Call AfficherErreur("frmAjoutDL", "AjouterGroupementMeatProcessing", Err, Erl())
	End Sub
	
	Private Sub cmdExceptions_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExceptions.Click
		
5: On Error GoTo AfficherErreur
		
10: Call OuvrirForm(frmExceptionsDL, False)
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmAjoutDL", "cmdExceptions_Click", Err, Erl())
	End Sub
	
	Private Sub frmAjoutDL_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: m_otlApp = OuvrirOutlook(m_bDejaOuvert)
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmAjoutDL", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub frmAjoutDL_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		
5: On Error GoTo AfficherErreur
		
10: If m_bDejaOuvert = False Then
15: Call m_otlApp.Quit()
20: End If
		
25: 'UPGRADE_NOTE: Object m_otlApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		m_otlApp = Nothing
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmAjoutDL", "Form_Load", Err, Erl())
	End Sub
	
	Private Function IsException(ByVal sAdresse As String) As Boolean
		
5: On Error GoTo AfficherErreur
		
10: Dim iCompteur As Short
		
15: For iCompteur = 0 To UBound(m_arr_sException)
20: If m_arr_sException(iCompteur) = sAdresse Then
25: IsException = True
				
30: Exit For
35: End If
40: Next 
		
45: Exit Function
		
AfficherErreur: 
		
50: Call AfficherErreur("frmAjoutDL", "IsException", Err, Erl())
	End Function
	
	Private Sub RemplirArrayExceptions()
		
5: On Error GoTo AfficherErreur
		
10: Dim rstExceptions As ADODB.Recordset
15: Dim iNombre As Short
		
20: ReDim m_arr_sException(0)
		
25: rstExceptions = New ADODB.Recordset
		
30: Call rstExceptions.Open("SELECT * FROM GRB_ExceptionsDL", g_connData, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		
35: Do While Not rstExceptions.EOF
40: ReDim Preserve m_arr_sException(iNombre)
			
45: m_arr_sException(iNombre) = rstExceptions.Fields("Exception").Value
			
50: iNombre = iNombre + 1
			
55: Call rstExceptions.MoveNext()
60: Loop 
		
65: Call rstExceptions.Close()
70: 'UPGRADE_NOTE: Object rstExceptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstExceptions = Nothing
		
75: Exit Sub
		
AfficherErreur: 
		
80: Call AfficherErreur("frmAjoutDL", "RemplirArrayExceptions", Err, Erl())
	End Sub
End Class