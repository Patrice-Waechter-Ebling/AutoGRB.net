<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmAlarme
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents mvwDate As AxMSComCtl2.AxMonthView
	Public WithEvents cmdDate As System.Windows.Forms.Button
	Public WithEvents txtDate As System.Windows.Forms.TextBox
	Public WithEvents chkRemind As System.Windows.Forms.CheckBox
	Public WithEvents mskHeure As System.Windows.Forms.MaskedTextBox
	Public WithEvents txtMessage As System.Windows.Forms.TextBox
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAlarme))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdOK = New System.Windows.Forms.Button
		Me.mvwDate = New AxMSComCtl2.AxMonthView
		Me.cmdDate = New System.Windows.Forms.Button
		Me.txtDate = New System.Windows.Forms.TextBox
		Me.chkRemind = New System.Windows.Forms.CheckBox
		Me.mskHeure = New System.Windows.Forms.MaskedTextBox
		Me.txtMessage = New System.Windows.Forms.TextBox
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Alarme"
		Me.ClientSize = New System.Drawing.Size(281, 263)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.Icon = CType(resources.GetObject("frmAlarme.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmAlarme.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmAlarme"
		Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOK.Text = "OK"
		Me.cmdOK.Size = New System.Drawing.Size(65, 25)
		Me.cmdOK.Location = New System.Drawing.Point(208, 232)
		Me.cmdOK.TabIndex = 9
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		mvwDate.OcxState = CType(resources.GetObject("mvwDate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwDate.Size = New System.Drawing.Size(176, 158)
		Me.mvwDate.Location = New System.Drawing.Point(104, 80)
		Me.mvwDate.TabIndex = 1
		Me.mvwDate.Visible = False
		Me.mvwDate.Name = "mvwDate"
		Me.cmdDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDate.Text = "..."
		Me.cmdDate.Size = New System.Drawing.Size(25, 17)
		Me.cmdDate.Location = New System.Drawing.Point(240, 168)
		Me.cmdDate.TabIndex = 6
		Me.cmdDate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDate.CausesValidation = True
		Me.cmdDate.Enabled = True
		Me.cmdDate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDate.TabStop = True
		Me.cmdDate.Name = "cmdDate"
		Me.txtDate.AutoSize = False
		Me.txtDate.Size = New System.Drawing.Size(73, 19)
		Me.txtDate.Location = New System.Drawing.Point(160, 168)
		Me.txtDate.ReadOnly = True
		Me.txtDate.TabIndex = 4
		Me.txtDate.AcceptsReturn = True
		Me.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDate.BackColor = System.Drawing.SystemColors.Window
		Me.txtDate.CausesValidation = True
		Me.txtDate.Enabled = True
		Me.txtDate.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDate.HideSelection = True
		Me.txtDate.Maxlength = 0
		Me.txtDate.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDate.MultiLine = False
		Me.txtDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDate.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDate.TabStop = True
		Me.txtDate.Visible = True
		Me.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDate.Name = "txtDate"
		Me.chkRemind.BackColor = System.Drawing.Color.Black
		Me.chkRemind.Text = "Me le rappeler le :"
		Me.chkRemind.ForeColor = System.Drawing.Color.White
		Me.chkRemind.Size = New System.Drawing.Size(105, 17)
		Me.chkRemind.Location = New System.Drawing.Point(8, 168)
		Me.chkRemind.TabIndex = 3
		Me.chkRemind.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkRemind.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkRemind.CausesValidation = True
		Me.chkRemind.Enabled = True
		Me.chkRemind.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkRemind.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkRemind.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkRemind.TabStop = True
		Me.chkRemind.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkRemind.Visible = True
		Me.chkRemind.Name = "chkRemind"
		Me.mskHeure.AllowPromptAsInput = False
		Me.mskHeure.Size = New System.Drawing.Size(73, 17)
		Me.mskHeure.Location = New System.Drawing.Point(160, 200)
		Me.mskHeure.TabIndex = 8
		Me.mskHeure.PromptChar = "_"
		Me.mskHeure.Name = "mskHeure"
		Me.txtMessage.AutoSize = False
		Me.txtMessage.Size = New System.Drawing.Size(265, 65)
		Me.txtMessage.Location = New System.Drawing.Point(8, 96)
		Me.txtMessage.ReadOnly = True
		Me.txtMessage.MultiLine = True
		Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtMessage.TabIndex = 2
		Me.txtMessage.AcceptsReturn = True
		Me.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMessage.BackColor = System.Drawing.SystemColors.Window
		Me.txtMessage.CausesValidation = True
		Me.txtMessage.Enabled = True
		Me.txtMessage.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMessage.HideSelection = True
		Me.txtMessage.Maxlength = 0
		Me.txtMessage.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMessage.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMessage.TabStop = True
		Me.txtMessage.Visible = True
		Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMessage.Name = "txtMessage"
		Me.Label4.Text = "Heure :"
		Me.Label4.ForeColor = System.Drawing.Color.White
		Me.Label4.Size = New System.Drawing.Size(41, 17)
		Me.Label4.Location = New System.Drawing.Point(120, 200)
		Me.Label4.TabIndex = 7
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.Color.Transparent
		Me.Label4.Enabled = True
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.Text = "Date :"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(41, 17)
		Me.Label3.Location = New System.Drawing.Point(120, 168)
		Me.Label3.TabIndex = 5
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Enabled = True
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label1.Text = "Vous avez une alarme!"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(265, 25)
		Me.Label1.Location = New System.Drawing.Point(8, 72)
		Me.Label1.TabIndex = 0
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(cmdOK)
		Me.Controls.Add(mvwDate)
		Me.Controls.Add(cmdDate)
		Me.Controls.Add(txtDate)
		Me.Controls.Add(chkRemind)
		Me.Controls.Add(mskHeure)
		Me.Controls.Add(txtMessage)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label1)
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class