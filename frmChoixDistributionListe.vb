Option Strict Off
Option Explicit On
Friend Class frmChoixMailList
	Inherits System.Windows.Forms.Form
	Private Const I_LVW_LISTE As Short = 0
	Private Const I_LVW_NOMBRE As Short = 1
	Private Const I_LVW_DOSSIER As Short = 2
	
	Private m_frmSource As System.Windows.Forms.Form
	Private m_otlApp As Outlook.Application
	
	Public Sub Afficher(ByVal frmSource As System.Windows.Forms.Form, ByVal otlApp As Outlook.Application)
		
5: On Error GoTo AfficherErreur
		
10: m_frmSource = frmSource
		
15: m_otlApp = otlApp
		
20: Call Me.ShowDialog()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixMailList", "Afficher", Err, Erl())
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_ISSUE: Control m_bAnnulerDistList could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
		m_frmSource.m_bAnnulerDistList = True
		
15: Call Me.Close()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmChoixMailList", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
10: Dim objItem As Object
15: Dim folGRB As Outlook.MAPIFolder
20: Dim myItems As Outlook.Items
		
25: If lvwDistList.Items.Count > 0 Then
30: 'UPGRADE_ISSUE: Control m_bAnnulerDistList could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
			m_frmSource.m_bAnnulerDistList = False
			
35: 'UPGRADE_WARNING: Lower bound of collection lvwDistList.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			folGRB = GetFolder(m_otlApp, lvwDistList.FocusedItem.SubItems(I_LVW_DOSSIER).Text)
			
40: myItems = folGRB.Items.Restrict("[MessageClass] = 'IPM.DistList'")
			
45: For	Each objItem In folGRB.Items
50: 'UPGRADE_WARNING: Couldn't resolve default property of object objItem.Class. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If objItem.Class = Outlook.OlObjectClass.olDistributionList Then
55: 'UPGRADE_WARNING: Couldn't resolve default property of object objItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If objItem = lvwDistList.FocusedItem.Text Then
60: 'UPGRADE_ISSUE: Control m_otlDistList could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
						m_frmSource.m_otlDistList = objItem
						
65: Exit For
70: End If
75: End If
80: Next objItem
			
85: Call Me.Close()
90: Else
95: Call MsgBox("Il n'y a aucune liste de distribution!", MsgBoxStyle.OKOnly, "Erreur")
100: End If
		
105: Exit Sub
		
AfficherErreur: 
		
110: Call AfficherErreur("frmChoixMailList", "cmdOK_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixMailList_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Dim folGRB As Outlook.MAPIFolder
15: Dim myItems As Outlook.Items
20: Dim objItem As Object
25: Dim itmDL As System.Windows.Forms.ListViewItem
		
30: folGRB = GetFolder(m_otlApp, "Contacts GRB")
		
35: myItems = folGRB.Items.Restrict("[MessageClass] = 'IPM.DistList'")
		
40: For	Each objItem In myItems
45: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwDistList.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmDL = lvwDistList.Items.Add()
			
50: 'UPGRADE_WARNING: Couldn't resolve default property of object objItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			itmDL.Text = objItem
55: 'UPGRADE_WARNING: Lower bound of collection itmDL has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object objItem.MemberCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If itmDL.SubItems.Count > I_LVW_NOMBRE Then
				itmDL.SubItems(I_LVW_NOMBRE).Text = objItem.MemberCount
			Else
				itmDL.SubItems.Insert(I_LVW_NOMBRE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, objItem.MemberCount))
			End If
60: 'UPGRADE_WARNING: Lower bound of collection itmDL has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmDL.SubItems.Count > I_LVW_DOSSIER Then
				itmDL.SubItems(I_LVW_DOSSIER).Text = "Contacts GRB"
			Else
				itmDL.SubItems.Insert(I_LVW_DOSSIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Contacts GRB"))
			End If
65: Next objItem
		
70: folGRB = GetFolder(m_otlApp, "Clients GRB")
		
75: myItems = folGRB.Items.Restrict("[MessageClass] = 'IPM.DistList'")
		
80: For	Each objItem In myItems
85: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwDistList.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmDL = lvwDistList.Items.Add()
			
90: 'UPGRADE_WARNING: Couldn't resolve default property of object objItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			itmDL.Text = objItem
95: 'UPGRADE_WARNING: Lower bound of collection itmDL has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object objItem.MemberCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If itmDL.SubItems.Count > I_LVW_NOMBRE Then
				itmDL.SubItems(I_LVW_NOMBRE).Text = objItem.MemberCount
			Else
				itmDL.SubItems.Insert(I_LVW_NOMBRE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, objItem.MemberCount))
			End If
100: 'UPGRADE_WARNING: Lower bound of collection itmDL has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmDL.SubItems.Count > I_LVW_DOSSIER Then
				itmDL.SubItems(I_LVW_DOSSIER).Text = "Clients GRB"
			Else
				itmDL.SubItems.Insert(I_LVW_DOSSIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Clients GRB"))
			End If
105: Next objItem
		
110: folGRB = GetFolder(m_otlApp, "Fournisseurs GRB")
		
115: myItems = folGRB.Items.Restrict("[MessageClass] = 'IPM.DistList'")
		
120: For	Each objItem In myItems
125: 'UPGRADE_ISSUE: MSComctlLib.ListItems method lvwDistList.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			itmDL = lvwDistList.Items.Add()
			
130: 'UPGRADE_WARNING: Couldn't resolve default property of object objItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			itmDL.Text = objItem
135: 'UPGRADE_WARNING: Lower bound of collection itmDL has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object objItem.MemberCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If itmDL.SubItems.Count > I_LVW_NOMBRE Then
				itmDL.SubItems(I_LVW_NOMBRE).Text = objItem.MemberCount
			Else
				itmDL.SubItems.Insert(I_LVW_NOMBRE, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, objItem.MemberCount))
			End If
140: 'UPGRADE_WARNING: Lower bound of collection itmDL has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If itmDL.SubItems.Count > I_LVW_DOSSIER Then
				itmDL.SubItems(I_LVW_DOSSIER).Text = "Fournisseurs GRB"
			Else
				itmDL.SubItems.Insert(I_LVW_DOSSIER, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Fournisseurs GRB"))
			End If
145: Next objItem
		
150: 'UPGRADE_ISSUE: Control fraEtatOutlook could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
		m_frmSource.fraEtatOutlook.Visible = False
		
155: Exit Sub
		
AfficherErreur: 
		
160: Call AfficherErreur("frmChoixMailList", "Form_Load", Err, Erl())
	End Sub
End Class