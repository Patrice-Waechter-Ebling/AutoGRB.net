<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FrmBonCommande_Instruction
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
	Public WithEvents txtPays As System.Windows.Forms.TextBox
	Public WithEvents txtAdresse As System.Windows.Forms.TextBox
	Public WithEvents txtCompagnie As System.Windows.Forms.TextBox
	Public WithEvents lblPays As System.Windows.Forms.Label
	Public WithEvents lblAdresse As System.Windows.Forms.Label
	Public WithEvents lblcompagnie As System.Windows.Forms.Label
	Public WithEvents fraLabel As System.Windows.Forms.GroupBox
	Public WithEvents txtAssistance As System.Windows.Forms.TextBox
	Public WithEvents txtEtat As System.Windows.Forms.TextBox
	Public WithEvents CmdEnr As System.Windows.Forms.Button
	Public WithEvents CmdFerme As System.Windows.Forms.Button
	Public WithEvents lblassistance As System.Windows.Forms.Label
	Public WithEvents lblEtat As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmBonCommande_Instruction))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.fraLabel = New System.Windows.Forms.GroupBox
		Me.txtPays = New System.Windows.Forms.TextBox
		Me.txtAdresse = New System.Windows.Forms.TextBox
		Me.txtCompagnie = New System.Windows.Forms.TextBox
		Me.lblPays = New System.Windows.Forms.Label
		Me.lblAdresse = New System.Windows.Forms.Label
		Me.lblcompagnie = New System.Windows.Forms.Label
		Me.txtAssistance = New System.Windows.Forms.TextBox
		Me.txtEtat = New System.Windows.Forms.TextBox
		Me.CmdEnr = New System.Windows.Forms.Button
		Me.CmdFerme = New System.Windows.Forms.Button
		Me.lblassistance = New System.Windows.Forms.Label
		Me.lblEtat = New System.Windows.Forms.Label
		Me.fraLabel.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Bon Commande - Configuration Instruction"
		Me.ClientSize = New System.Drawing.Size(395, 292)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("FrmBonCommande_Instruction.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "FrmBonCommande_Instruction"
		Me.fraLabel.BackColor = System.Drawing.Color.Black
		Me.fraLabel.Text = "Étiquette"
		Me.fraLabel.ForeColor = System.Drawing.Color.White
		Me.fraLabel.Size = New System.Drawing.Size(377, 113)
		Me.fraLabel.Location = New System.Drawing.Point(8, 64)
		Me.fraLabel.TabIndex = 0
		Me.fraLabel.Enabled = True
		Me.fraLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraLabel.Visible = True
		Me.fraLabel.Padding = New System.Windows.Forms.Padding(0)
		Me.fraLabel.Name = "fraLabel"
		Me.txtPays.AutoSize = False
		Me.txtPays.Size = New System.Drawing.Size(273, 19)
		Me.txtPays.Location = New System.Drawing.Point(96, 80)
		Me.txtPays.TabIndex = 6
		Me.txtPays.AcceptsReturn = True
		Me.txtPays.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPays.BackColor = System.Drawing.SystemColors.Window
		Me.txtPays.CausesValidation = True
		Me.txtPays.Enabled = True
		Me.txtPays.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPays.HideSelection = True
		Me.txtPays.ReadOnly = False
		Me.txtPays.Maxlength = 0
		Me.txtPays.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPays.MultiLine = False
		Me.txtPays.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPays.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPays.TabStop = True
		Me.txtPays.Visible = True
		Me.txtPays.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPays.Name = "txtPays"
		Me.txtAdresse.AutoSize = False
		Me.txtAdresse.Size = New System.Drawing.Size(273, 19)
		Me.txtAdresse.Location = New System.Drawing.Point(96, 56)
		Me.txtAdresse.TabIndex = 4
		Me.txtAdresse.AcceptsReturn = True
		Me.txtAdresse.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtAdresse.BackColor = System.Drawing.SystemColors.Window
		Me.txtAdresse.CausesValidation = True
		Me.txtAdresse.Enabled = True
		Me.txtAdresse.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAdresse.HideSelection = True
		Me.txtAdresse.ReadOnly = False
		Me.txtAdresse.Maxlength = 0
		Me.txtAdresse.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAdresse.MultiLine = False
		Me.txtAdresse.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAdresse.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtAdresse.TabStop = True
		Me.txtAdresse.Visible = True
		Me.txtAdresse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAdresse.Name = "txtAdresse"
		Me.txtCompagnie.AutoSize = False
		Me.txtCompagnie.Size = New System.Drawing.Size(273, 19)
		Me.txtCompagnie.Location = New System.Drawing.Point(96, 32)
		Me.txtCompagnie.TabIndex = 1
		Me.txtCompagnie.AcceptsReturn = True
		Me.txtCompagnie.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCompagnie.BackColor = System.Drawing.SystemColors.Window
		Me.txtCompagnie.CausesValidation = True
		Me.txtCompagnie.Enabled = True
		Me.txtCompagnie.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCompagnie.HideSelection = True
		Me.txtCompagnie.ReadOnly = False
		Me.txtCompagnie.Maxlength = 0
		Me.txtCompagnie.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCompagnie.MultiLine = False
		Me.txtCompagnie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCompagnie.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCompagnie.TabStop = True
		Me.txtCompagnie.Visible = True
		Me.txtCompagnie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCompagnie.Name = "txtCompagnie"
		Me.lblPays.Text = "Pays"
		Me.lblPays.ForeColor = System.Drawing.Color.White
		Me.lblPays.Size = New System.Drawing.Size(65, 17)
		Me.lblPays.Location = New System.Drawing.Point(8, 80)
		Me.lblPays.TabIndex = 5
		Me.lblPays.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPays.BackColor = System.Drawing.Color.Transparent
		Me.lblPays.Enabled = True
		Me.lblPays.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPays.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPays.UseMnemonic = True
		Me.lblPays.Visible = True
		Me.lblPays.AutoSize = False
		Me.lblPays.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPays.Name = "lblPays"
		Me.lblAdresse.Text = "Adresse"
		Me.lblAdresse.ForeColor = System.Drawing.Color.White
		Me.lblAdresse.Size = New System.Drawing.Size(73, 17)
		Me.lblAdresse.Location = New System.Drawing.Point(8, 56)
		Me.lblAdresse.TabIndex = 3
		Me.lblAdresse.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblAdresse.BackColor = System.Drawing.Color.Transparent
		Me.lblAdresse.Enabled = True
		Me.lblAdresse.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblAdresse.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblAdresse.UseMnemonic = True
		Me.lblAdresse.Visible = True
		Me.lblAdresse.AutoSize = False
		Me.lblAdresse.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblAdresse.Name = "lblAdresse"
		Me.lblcompagnie.Text = "Compagnie"
		Me.lblcompagnie.ForeColor = System.Drawing.Color.White
		Me.lblcompagnie.Size = New System.Drawing.Size(89, 17)
		Me.lblcompagnie.Location = New System.Drawing.Point(8, 32)
		Me.lblcompagnie.TabIndex = 2
		Me.lblcompagnie.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblcompagnie.BackColor = System.Drawing.Color.Transparent
		Me.lblcompagnie.Enabled = True
		Me.lblcompagnie.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblcompagnie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblcompagnie.UseMnemonic = True
		Me.lblcompagnie.Visible = True
		Me.lblcompagnie.AutoSize = False
		Me.lblcompagnie.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblcompagnie.Name = "lblcompagnie"
		Me.txtAssistance.AutoSize = False
		Me.txtAssistance.Size = New System.Drawing.Size(273, 19)
		Me.txtAssistance.Location = New System.Drawing.Point(104, 216)
		Me.txtAssistance.TabIndex = 9
		Me.txtAssistance.AcceptsReturn = True
		Me.txtAssistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtAssistance.BackColor = System.Drawing.SystemColors.Window
		Me.txtAssistance.CausesValidation = True
		Me.txtAssistance.Enabled = True
		Me.txtAssistance.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAssistance.HideSelection = True
		Me.txtAssistance.ReadOnly = False
		Me.txtAssistance.Maxlength = 0
		Me.txtAssistance.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAssistance.MultiLine = False
		Me.txtAssistance.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAssistance.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtAssistance.TabStop = True
		Me.txtAssistance.Visible = True
		Me.txtAssistance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAssistance.Name = "txtAssistance"
		Me.txtEtat.AutoSize = False
		Me.txtEtat.Size = New System.Drawing.Size(113, 19)
		Me.txtEtat.Location = New System.Drawing.Point(104, 192)
		Me.txtEtat.TabIndex = 7
		Me.txtEtat.AcceptsReturn = True
		Me.txtEtat.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtEtat.BackColor = System.Drawing.SystemColors.Window
		Me.txtEtat.CausesValidation = True
		Me.txtEtat.Enabled = True
		Me.txtEtat.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtEtat.HideSelection = True
		Me.txtEtat.ReadOnly = False
		Me.txtEtat.Maxlength = 0
		Me.txtEtat.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtEtat.MultiLine = False
		Me.txtEtat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtEtat.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtEtat.TabStop = True
		Me.txtEtat.Visible = True
		Me.txtEtat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtEtat.Name = "txtEtat"
		Me.CmdEnr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdEnr.Text = "&Enregistrer"
		Me.CmdEnr.Size = New System.Drawing.Size(97, 33)
		Me.CmdEnr.Location = New System.Drawing.Point(184, 256)
		Me.CmdEnr.TabIndex = 11
		Me.CmdEnr.BackColor = System.Drawing.SystemColors.Control
		Me.CmdEnr.CausesValidation = True
		Me.CmdEnr.Enabled = True
		Me.CmdEnr.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdEnr.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdEnr.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdEnr.TabStop = True
		Me.CmdEnr.Name = "CmdEnr"
		Me.CmdFerme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdFerme.BackColor = System.Drawing.SystemColors.Control
		Me.CmdFerme.Text = "&Fermer"
		Me.CmdFerme.Size = New System.Drawing.Size(97, 33)
		Me.CmdFerme.Location = New System.Drawing.Point(288, 256)
		Me.CmdFerme.TabIndex = 12
		Me.CmdFerme.CausesValidation = True
		Me.CmdFerme.Enabled = True
		Me.CmdFerme.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdFerme.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdFerme.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdFerme.TabStop = True
		Me.CmdFerme.Name = "CmdFerme"
		Me.lblassistance.Text = "Assistance"
		Me.lblassistance.ForeColor = System.Drawing.Color.White
		Me.lblassistance.Size = New System.Drawing.Size(121, 17)
		Me.lblassistance.Location = New System.Drawing.Point(16, 216)
		Me.lblassistance.TabIndex = 10
		Me.lblassistance.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblassistance.BackColor = System.Drawing.Color.Transparent
		Me.lblassistance.Enabled = True
		Me.lblassistance.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblassistance.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblassistance.UseMnemonic = True
		Me.lblassistance.Visible = True
		Me.lblassistance.AutoSize = False
		Me.lblassistance.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblassistance.Name = "lblassistance"
		Me.lblEtat.Text = "État"
		Me.lblEtat.ForeColor = System.Drawing.Color.White
		Me.lblEtat.Size = New System.Drawing.Size(121, 17)
		Me.lblEtat.Location = New System.Drawing.Point(16, 192)
		Me.lblEtat.TabIndex = 8
		Me.lblEtat.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblEtat.BackColor = System.Drawing.Color.Transparent
		Me.lblEtat.Enabled = True
		Me.lblEtat.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblEtat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblEtat.UseMnemonic = True
		Me.lblEtat.Visible = True
		Me.lblEtat.AutoSize = False
		Me.lblEtat.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblEtat.Name = "lblEtat"
		Me.Controls.Add(fraLabel)
		Me.Controls.Add(txtAssistance)
		Me.Controls.Add(txtEtat)
		Me.Controls.Add(CmdEnr)
		Me.Controls.Add(CmdFerme)
		Me.Controls.Add(lblassistance)
		Me.Controls.Add(lblEtat)
		Me.fraLabel.Controls.Add(txtPays)
		Me.fraLabel.Controls.Add(txtAdresse)
		Me.fraLabel.Controls.Add(txtCompagnie)
		Me.fraLabel.Controls.Add(lblPays)
		Me.fraLabel.Controls.Add(lblAdresse)
		Me.fraLabel.Controls.Add(lblcompagnie)
		Me.fraLabel.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class