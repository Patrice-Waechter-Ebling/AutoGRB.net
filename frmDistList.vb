Option Strict Off
Option Explicit On
Friend Class frmDistList
	Inherits System.Windows.Forms.Form
	Private Const I_COL_DISTLIST_NOM As Short = 0
	Private Const I_COL_DISTLIST_DOSSIER As Short = 1
	Private Const I_COL_DISTLIST_NBRE As Short = 2
	
	Private Const I_COL_CONTACT_NOM As Short = 0
	Private Const I_COL_CONTACT_COURRIEL As Short = 1
	Private Const I_COL_CONTACT_DISTLIST As Short = 2
	
	Private Const I_ITM_TOUTES_LISTES As Short = 1
	
	Private m_otlApp As Outlook.Application
	Private m_bDejaOuvert As Boolean
	
	Private m_folClients As Outlook.MAPIFolder
	Private m_folContacts As Outlook.MAPIFolder
	Private m_folFRS As Outlook.MAPIFolder
	
	Private Sub RemplirListViewContacts()
		
5: On Error GoTo AfficherErreur
		
10: Dim otlDistList As Outlook.DistListItem
15: Dim myRecipient As Outlook.Recipient
20: Dim itmContact As System.Windows.Forms.ListViewItem
25: Dim sDistList As String
30: Dim iCompteur As Short
35: Dim iListe As Short
40: Dim bAfficher As Boolean
		
45: Call lvwContacts.Items.Clear()
		
50: If lvwDistList.Items.Count > 0 Then
55: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
60: lvwDistList.Enabled = False
65: cmdCreerListe.Enabled = False
70: cmdRafraichir.Enabled = False
75: cmdAfficher.Enabled = False
			
80: For iListe = 2 To lvwDistList.Items.Count
85: bAfficher = False
				
90: 'UPGRADE_WARNING: Lower bound of collection lvwDistList.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvwDistList.Items.Item(I_ITM_TOUTES_LISTES).Selected = True Then
95: bAfficher = True
100: Else
105: 'UPGRADE_WARNING: Lower bound of collection lvwDistList.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvwDistList.Items.Item(iListe).Selected = True Then
110: bAfficher = True
115: End If
120: End If
				
125: If bAfficher = True Then
130: 'UPGRADE_WARNING: Lower bound of collection lvwDistList.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					sDistList = lvwDistList.Items.Item(iListe).Text
					
135: 'UPGRADE_WARNING: Lower bound of collection lvwDistList.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					otlDistList = m_otlApp.GetNamespace("MAPI").GetItemFromID(lvwDistList.Items.Item(iListe).Tag)
					
140: For iCompteur = 1 To otlDistList.MemberCount
145: myRecipient = otlDistList.GetMember(iCompteur)
						
150: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwContacts.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						itmContact = lvwContacts.Items.Add()
						
155: itmContact.Text = myRecipient.Name
160: 'UPGRADE_WARNING: Lower bound of collection itmContact has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmContact.SubItems.Count > I_COL_CONTACT_COURRIEL Then
							itmContact.SubItems(I_COL_CONTACT_COURRIEL).Text = myRecipient.Address
						Else
							itmContact.SubItems.Insert(I_COL_CONTACT_COURRIEL, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, myRecipient.Address))
						End If
165: 'UPGRADE_WARNING: Lower bound of collection itmContact has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If itmContact.SubItems.Count > I_COL_CONTACT_DISTLIST Then
							itmContact.SubItems(I_COL_CONTACT_DISTLIST).Text = sDistList
						Else
							itmContact.SubItems.Insert(I_COL_CONTACT_DISTLIST, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, sDistList))
						End If
170: Next 
					
175: System.Windows.Forms.Application.DoEvents()
180: End If
185: Next 
			
190: lvwDistList.Enabled = True
195: cmdCreerListe.Enabled = True
200: cmdRafraichir.Enabled = True
205: cmdAfficher.Enabled = True
			
210: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
215: End If
		
220: Exit Sub
		
AfficherErreur: 
		
225: Call AfficherErreur("frmDistList", "RemplirListViewContacts", Err, Erl())
	End Sub
	
	Private Sub RemplirListViewDistList()
		
5: On Error GoTo AfficherErreur
		
10: Dim folGRB As Outlook.MAPIFolder
15: Dim myItems As Outlook.Items
20: Dim objItem As Object
25: Dim itmDL As System.Windows.Forms.ListViewItem
30: Dim dblTotal As Double
		
35: Call lvwDistList.Items.Clear()
		
40: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwDistList.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		itmDL = lvwDistList.Items.Add()
		
45: itmDL.Text = "(Toutes les listes)"
		
50: folGRB = m_folContacts
		
55: myItems = folGRB.Items.Restrict("[MessageClass] = 'IPM.DistList'")
		
60: For	Each objItem In myItems
65: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwDistList.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmDL = lvwDistList.Items.Add()
			
70: 'UPGRADE_WARNING: Couldn't resolve default property of object objItem.EntryID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			itmDL.Tag = objItem.EntryID
75: 'UPGRADE_WARNING: Couldn't resolve default property of object objItem.DLName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			itmDL.Text = objItem.DLName
80: 'UPGRADE_WARNING: Lower bound of collection itmDL has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmDL.SubItems.Count > I_COL_DISTLIST_DOSSIER Then
				itmDL.SubItems(I_COL_DISTLIST_DOSSIER).Text = "Contacts GRB"
			Else
				itmDL.SubItems.Insert(I_COL_DISTLIST_DOSSIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Contacts GRB"))
			End If
85: 'UPGRADE_WARNING: Lower bound of collection itmDL has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object objItem.MemberCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If itmDL.SubItems.Count > I_COL_DISTLIST_NBRE Then
				itmDL.SubItems(I_COL_DISTLIST_NBRE).Text = objItem.MemberCount
			Else
				itmDL.SubItems.Insert(I_COL_DISTLIST_NBRE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, objItem.MemberCount))
			End If
			
90: 'UPGRADE_WARNING: Couldn't resolve default property of object objItem.MemberCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = dblTotal + objItem.MemberCount
95: Next objItem
		
100: folGRB = m_folClients
		
105: myItems = folGRB.Items.Restrict("[MessageClass] = 'IPM.DistList'")
		
110: For	Each objItem In myItems
115: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwDistList.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmDL = lvwDistList.Items.Add()
			
120: 'UPGRADE_WARNING: Couldn't resolve default property of object objItem.EntryID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			itmDL.Tag = objItem.EntryID
125: 'UPGRADE_WARNING: Couldn't resolve default property of object objItem.DLName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			itmDL.Text = objItem.DLName
130: 'UPGRADE_WARNING: Lower bound of collection itmDL has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmDL.SubItems.Count > I_COL_DISTLIST_DOSSIER Then
				itmDL.SubItems(I_COL_DISTLIST_DOSSIER).Text = "Clients GRB"
			Else
				itmDL.SubItems.Insert(I_COL_DISTLIST_DOSSIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Clients GRB"))
			End If
135: 'UPGRADE_WARNING: Lower bound of collection itmDL has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object objItem.MemberCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If itmDL.SubItems.Count > I_COL_DISTLIST_NBRE Then
				itmDL.SubItems(I_COL_DISTLIST_NBRE).Text = objItem.MemberCount
			Else
				itmDL.SubItems.Insert(I_COL_DISTLIST_NBRE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, objItem.MemberCount))
			End If
			
140: 'UPGRADE_WARNING: Couldn't resolve default property of object objItem.MemberCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = dblTotal + objItem.MemberCount
145: Next objItem
		
150: folGRB = m_folFRS
		
155: myItems = folGRB.Items.Restrict("[MessageClass] = 'IPM.DistList'")
		
160: For	Each objItem In myItems
165: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwDistList.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmDL = lvwDistList.Items.Add()
			
170: 'UPGRADE_WARNING: Couldn't resolve default property of object objItem.EntryID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			itmDL.Tag = objItem.EntryID
175: 'UPGRADE_WARNING: Couldn't resolve default property of object objItem.DLName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			itmDL.Text = objItem.DLName
180: 'UPGRADE_WARNING: Lower bound of collection itmDL has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmDL.SubItems.Count > I_COL_DISTLIST_DOSSIER Then
				itmDL.SubItems(I_COL_DISTLIST_DOSSIER).Text = "Fournisseurs GRB"
			Else
				itmDL.SubItems.Insert(I_COL_DISTLIST_DOSSIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Fournisseurs GRB"))
			End If
185: 'UPGRADE_WARNING: Lower bound of collection itmDL has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object objItem.MemberCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If itmDL.SubItems.Count > I_COL_DISTLIST_NBRE Then
				itmDL.SubItems(I_COL_DISTLIST_NBRE).Text = objItem.MemberCount
			Else
				itmDL.SubItems.Insert(I_COL_DISTLIST_NBRE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, objItem.MemberCount))
			End If
			
190: 'UPGRADE_WARNING: Couldn't resolve default property of object objItem.MemberCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dblTotal = dblTotal + objItem.MemberCount
195: Next objItem
		
200: 'UPGRADE_WARNING: Lower bound of collection lvwDistList.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		'UPGRADE_WARNING: Lower bound of collection lvwDistList.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If lvwDistList.Items.Item(1).SubItems.Count > I_COL_DISTLIST_NBRE Then
			lvwDistList.Items.Item(1).SubItems(I_COL_DISTLIST_NBRE).Text = CStr(dblTotal)
		Else
			lvwDistList.Items.Item(1).SubItems.Insert(I_COL_DISTLIST_NBRE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, CStr(dblTotal)))
		End If
		
205: Exit Sub
		
AfficherErreur: 
		
210: Call AfficherErreur("frmDistList", "RemplirListViewDistList", Err, Erl())
	End Sub
	
	Private Sub cmdAfficher_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAfficher.Click
		
5: On Error GoTo AfficherErreur
		
10: Call RemplirListViewContacts()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmDistList", "cmdAfficher_Click", Err, Erl())
	End Sub
	
	Private Sub cmdCreerListe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCreerListe.Click
		
5: On Error GoTo AfficherErreur
		
10: Call OuvrirForm(frmAjoutDL, False)
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmDistList", "cmdCreerListe_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRafraichir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRafraichir.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call RemplirListViewDistList()
		
20: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmDistList", "cmdRafraichir_Click", Err, Erl())
	End Sub
	
	Private Sub frmDistList_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: m_otlApp = OuvrirOutlook(m_bDejaOuvert)
		
15: m_folClients = GetFolder(m_otlApp, "Clients GRB")
20: m_folContacts = GetFolder(m_otlApp, "Contacts GRB")
25: m_folFRS = GetFolder(m_otlApp, "Fournisseurs GRB")
		
30: Call RemplirListViewDistList()
		
35: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmDistList", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub lvwContacts_ColumnClick(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ColumnClickEventArgs) Handles lvwContacts.ColumnClick
		Dim ColumnHeader As System.Windows.Forms.ColumnHeader = lvwContacts.Columns(eventArgs.Column)
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwContacts.Sorted was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		lvwContacts.Sorted = False
		
15: 'UPGRADE_ISSUE: MSComctlLib.ListView property lvwContacts.SortKey was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		lvwContacts.SortKey = ColumnHeader.Index - 1
		
20: If lvwContacts.Sorting = System.Windows.Forms.SortOrder.Ascending Then
25: lvwContacts.Sorting = System.Windows.Forms.SortOrder.Descending
30: Else
35: lvwContacts.Sorting = System.Windows.Forms.SortOrder.Ascending
40: End If
		
45: lvwContacts.Sort()
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmDistList", "lvwContacts_ColumnClick", Err, Erl())
	End Sub
	
	Private Sub lvwDistList_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvwDistList.DoubleClick
		
5: On Error GoTo AfficherErreur
		
10: Call RemplirListViewContacts()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmDistList", "lvwDistList_DblClick", Err, Erl())
	End Sub
	
	Private Sub lvwContacts_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lvwContacts.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
5: On Error GoTo AfficherErreur
		
10: Dim otlDistList As Outlook.DistListItem
15: Dim iIndex As Short
20: Dim iCompteur As Short
25: Dim sAdresse As String
		
30: If lvwContacts.Items.Count > 0 Then
35: If KeyCode = System.Windows.Forms.Keys.Delete Then
40: If MsgBox("Voulez-vous vraiment effacer l'enregistrement '" & lvwContacts.FocusedItem.Text & "' ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
45: If lvwDistList.FocusedItem.Index = 1 Then
50: For iCompteur = 2 To lvwDistList.Items.Count
55: 'UPGRADE_WARNING: Lower bound of collection lvwContacts.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							'UPGRADE_WARNING: Lower bound of collection lvwDistList.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							If lvwDistList.Items.Item(iCompteur).Text = lvwContacts.FocusedItem.SubItems(I_COL_CONTACT_DISTLIST).Text Then
60: 'UPGRADE_WARNING: Lower bound of collection lvwDistList.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
								otlDistList = m_otlApp.GetNamespace("MAPI").GetItemFromID(lvwDistList.Items.Item(iCompteur).Tag)
								
65: Exit For
70: End If
75: Next 
80: Else
85: otlDistList = m_otlApp.GetNamespace("MAPI").GetItemFromID(lvwDistList.FocusedItem.Tag)
90: End If
					
95: iIndex = lvwContacts.FocusedItem.Index
					
100: 'UPGRADE_WARNING: Lower bound of collection lvwContacts.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					sAdresse = lvwContacts.FocusedItem.SubItems(I_COL_CONTACT_COURRIEL).Text
					
105: Call otlDistList.RemoveMember(otlDistList.GetMember(iIndex))
					
110: Call otlDistList.Save()
					
115: 'UPGRADE_WARNING: Lower bound of collection lvwDistList.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lvwDistList.FocusedItem.SubItems.Count > I_COL_DISTLIST_NBRE Then
						lvwDistList.FocusedItem.SubItems(I_COL_DISTLIST_NBRE).Text = CStr(otlDistList.MemberCount)
					Else
						lvwDistList.FocusedItem.SubItems.Insert(I_COL_DISTLIST_NBRE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, CStr(otlDistList.MemberCount)))
					End If
					
120: If MsgBox("Voulez-vous ajouter ce contact à la liste des exceptions ? " & vbNewLine & vbNewLine & "Ceci évitera de l'ajouter lors de la création de nouvelles listes.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
125: Call AjouterException(sAdresse)
130: End If
					
135: Call RemplirListViewContacts()
					
140: If iIndex > lvwContacts.Items.Count Then
145: If lvwContacts.Items.Count > 0 Then
150: 'UPGRADE_WARNING: Lower bound of collection lvwContacts.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
							lvwContacts.Items.Item(lvwContacts.Items.Count).Selected = True
155: End If
160: Else
165: 'UPGRADE_WARNING: Lower bound of collection lvwContacts.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						lvwContacts.Items.Item(iIndex).Selected = True
170: End If
175: End If
180: End If
185: End If
		
190: Exit Sub
		
AfficherErreur: 
		
195: Call AfficherErreur("frmDistList", "lvwDistList_KeyDown", Err, Erl())
	End Sub
	
	Private Sub AjouterException(ByVal sAdresse As String)
		
5: On Error GoTo AfficherErreur
		
10: Dim rstExceptions As ADODB.Recordset
		
15: rstExceptions = New ADODB.Recordset
		
20: Call rstExceptions.Open("SELECT * FROM GRB_ExceptionsDL WHERE [Exception] = '" & Replace(sAdresse, "'", "''") & "'", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
25: If rstExceptions.EOF Then
30: Call rstExceptions.AddNew()
			
35: rstExceptions.Fields("Exception").Value = sAdresse
			
40: Call rstExceptions.Update()
45: End If
		
50: Call rstExceptions.Close()
55: 'UPGRADE_NOTE: Object rstExceptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstExceptions = Nothing
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmDistList", "AjouterException", Err, Erl())
	End Sub
End Class