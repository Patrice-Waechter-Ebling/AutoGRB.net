Option Strict Off
Option Explicit On
Friend Class FrmModType
	Inherits System.Windows.Forms.Form
	Private Sub Command1_Click()
		
	End Sub
	
	Private Sub Command3_Click()
		
	End Sub
	
	Private Sub Cmdajouter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cmdajouter.Click
		FrmADD.Visible = True
		Cmdajouter.Visible = False
		CmdValider.Visible = True
		cmdsupprimer.Visible = False
		CmdCancel.Visible = True
		cmdsupprimer.Enabled = False
		
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		FrmADD.Visible = False
		Cmdajouter.Visible = True
		CmdValider.Visible = False
		cmdsupprimer.Visible = True
		CmdCancel.Visible = False
	End Sub
	
	Private Sub Cmdfermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cmdfermer.Click
		Call Me.Close()
		
	End Sub
	
	Private Sub cmdsupprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdsupprimer.Click
		Dim strtest As String
		'UPGRADE_NOTE: Name was upgraded to Name_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim Name_Renamed As String
		'UPGRADE_WARNING: Lower bound of collection lsttype.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		Name_Renamed = lsttype.FocusedItem.SubItems(1).Text
		Name_Renamed = Replace(Name_Renamed, "'", "''")
		
		
		strtest = "DELETE * FROM TBL_Punch_Type WHERE mode = '" & lsttype.FocusedItem.Text & "' And name = '" & Name_Renamed & " ' "
		Call g_connData.Execute(strtest)
		If Opttous.Checked = True Then Call Opttous_CheckedChanged(Opttous, New System.EventArgs())
		If OptMec.Checked = True Then Call OptMec_CheckedChanged(OptMec, New System.EventArgs())
		If OptElec.Checked = True Then Call OptElec_CheckedChanged(OptElec, New System.EventArgs())
		
		cmdsupprimer.Enabled = False
	End Sub
	
	Private Sub CmdValider_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdValider.Click
		Dim strtest As String
		txtAdd.Text = Replace(txtAdd.Text, "'", "''")
		strtest = "Insert into TBL_Punch_Type (mode, Name) Values ('" & Combo1.Text & "','" & txtAdd.Text & "');"
		Call g_connData.Execute(strtest)
		CmdValider.Visible = False
		Cmdajouter.Visible = True
		FrmADD.Visible = False
		CmdCancel.Visible = False
		cmdsupprimer.Visible = True
		If Opttous.Checked = True Then Call Opttous_CheckedChanged(Opttous, New System.EventArgs())
		If OptMec.Checked = True Then Call OptMec_CheckedChanged(OptMec, New System.EventArgs())
		If OptElec.Checked = True Then Call OptElec_CheckedChanged(OptElec, New System.EventArgs())
		
		
		
	End Sub
	
	Private Sub FrmModType_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim tbltype As ADODB.Recordset
		Dim LIST As System.Windows.Forms.ListViewItem
		tbltype = New ADODB.Recordset
		Call tbltype.Open("Select * from Tbl_punch_Type Order by name ", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		Do While Not tbltype.EOF
			
			LIST = lsttype.Items.Add("")
			LIST.Text = tbltype.Fields("mode").Value
			Call LIST.SubItems.Add(tbltype.Fields("name").Value)
			
			
			Call tbltype.MoveNext()
		Loop 
		Call tbltype.Close()
		'UPGRADE_NOTE: Object tbltype may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		tbltype = Nothing
		
		
		
	End Sub
	
	Private Sub FrmModType_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		Call frmFeuilleTemps.RemplirComboType()
	End Sub
	
	Private Sub lsttype_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lsttype.Click
		cmdsupprimer.Enabled = True
		
		
		
	End Sub
	
	'UPGRADE_WARNING: Event OptElec.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub OptElec_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OptElec.CheckedChanged
		If eventSender.Checked Then
			OptMec.Checked = False
			cmdsupprimer.Enabled = False
			
			Opttous.Checked = False
			Dim tbltype As ADODB.Recordset
			Dim LIST As System.Windows.Forms.ListViewItem
			tbltype = New ADODB.Recordset
			lsttype.Items.Clear()
			Call tbltype.Open("Select * from Tbl_punch_Type where mode = 'E' Order by name ", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			Do While Not tbltype.EOF
				
				LIST = lsttype.Items.Add("")
				LIST.Text = tbltype.Fields("mode").Value
				Call LIST.SubItems.Add(tbltype.Fields("name").Value)
				
				
				Call tbltype.MoveNext()
			Loop 
			Call tbltype.Close()
			'UPGRADE_NOTE: Object tbltype may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			tbltype = Nothing
		End If
	End Sub
	
	'UPGRADE_WARNING: Event OptMec.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub OptMec_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OptMec.CheckedChanged
		If eventSender.Checked Then
			Opttous.Checked = False
			cmdsupprimer.Enabled = False
			OptElec.Checked = False
			Dim tbltype As ADODB.Recordset
			Dim LIST As System.Windows.Forms.ListViewItem
			tbltype = New ADODB.Recordset
			lsttype.Items.Clear()
			Call tbltype.Open("Select * from Tbl_punch_Type where mode = 'M' Order by name ", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			Do While Not tbltype.EOF
				
				LIST = lsttype.Items.Add("")
				LIST.Text = tbltype.Fields("mode").Value
				Call LIST.SubItems.Add(tbltype.Fields("name").Value)
				
				
				Call tbltype.MoveNext()
			Loop 
			Call tbltype.Close()
			'UPGRADE_NOTE: Object tbltype may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			tbltype = Nothing
		End If
	End Sub
	
	
	'UPGRADE_WARNING: Event Opttous.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Opttous_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Opttous.CheckedChanged
		If eventSender.Checked Then
			
			
			OptMec.Checked = False
			OptElec.Checked = False
			cmdsupprimer.Enabled = False
			Dim tbltype As ADODB.Recordset
			Dim LIST As System.Windows.Forms.ListViewItem
			tbltype = New ADODB.Recordset
			lsttype.Items.Clear()
			Call tbltype.Open("Select * from Tbl_punch_Type  Order by name ", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			Do While Not tbltype.EOF
				
				LIST = lsttype.Items.Add("")
				LIST.Text = tbltype.Fields("mode").Value
				Call LIST.SubItems.Add(tbltype.Fields("name").Value)
				
				
				Call tbltype.MoveNext()
			Loop 
			Call tbltype.Close()
			'UPGRADE_NOTE: Object tbltype may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			tbltype = Nothing
		End If
	End Sub
End Class