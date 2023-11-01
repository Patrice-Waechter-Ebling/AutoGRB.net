<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FrmDispatch
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
	Public WithEvents CmdChangerDB As System.Windows.Forms.Button
	Public WithEvents cmdDistList As System.Windows.Forms.Button
	Public WithEvents cmdFormulaire As System.Windows.Forms.Button
	Public WithEvents cmdEmploye As System.Windows.Forms.Button
	Public WithEvents cmdContact As System.Windows.Forms.Button
	Public WithEvents cmdFournisseur As System.Windows.Forms.Button
	Public WithEvents tmrAlarme As System.Windows.Forms.Timer
	Public WithEvents cmdInventaire As System.Windows.Forms.Button
	Public WithEvents cmdPunch As System.Windows.Forms.Button
	Public WithEvents cmdConfiguration As System.Windows.Forms.Button
	Public WithEvents cmdCedule As System.Windows.Forms.Button
	Public WithEvents cmdVendeur As System.Windows.Forms.Button
	Public WithEvents cmdquitter As System.Windows.Forms.Button
	Public WithEvents cmdClient As System.Windows.Forms.Button
	Public WithEvents cmdCatalogue As System.Windows.Forms.Button
	Public WithEvents cmdProjSoum As System.Windows.Forms.Button
	Public WithEvents lbldb As System.Windows.Forms.Label
	Public WithEvents lblDerniereVersion As System.Windows.Forms.Label
	Public WithEvents lblVersion As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmDispatch))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.CmdChangerDB = New System.Windows.Forms.Button
		Me.cmdDistList = New System.Windows.Forms.Button
		Me.cmdFormulaire = New System.Windows.Forms.Button
		Me.cmdEmploye = New System.Windows.Forms.Button
		Me.cmdContact = New System.Windows.Forms.Button
		Me.cmdFournisseur = New System.Windows.Forms.Button
		Me.tmrAlarme = New System.Windows.Forms.Timer(components)
		Me.cmdInventaire = New System.Windows.Forms.Button
		Me.cmdPunch = New System.Windows.Forms.Button
		Me.cmdConfiguration = New System.Windows.Forms.Button
		Me.cmdCedule = New System.Windows.Forms.Button
		Me.cmdVendeur = New System.Windows.Forms.Button
		Me.cmdquitter = New System.Windows.Forms.Button
		Me.cmdClient = New System.Windows.Forms.Button
		Me.cmdCatalogue = New System.Windows.Forms.Button
		Me.cmdProjSoum = New System.Windows.Forms.Button
		Me.lbldb = New System.Windows.Forms.Label
		Me.lblDerniereVersion = New System.Windows.Forms.Label
		Me.lblVersion = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Automation GRB"
		Me.ClientSize = New System.Drawing.Size(505, 300)
		Me.Location = New System.Drawing.Point(-10, -16)
		Me.Icon = CType(resources.GetObject("FrmDispatch.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("FrmDispatch.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "FrmDispatch"
		Me.CmdChangerDB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdChangerDB.BackColor = System.Drawing.SystemColors.Control
		Me.CmdChangerDB.Text = "Changer de base de données"
		Me.CmdChangerDB.Size = New System.Drawing.Size(155, 33)
		Me.CmdChangerDB.Location = New System.Drawing.Point(176, 256)
		Me.CmdChangerDB.TabIndex = 17
		Me.CmdChangerDB.CausesValidation = True
		Me.CmdChangerDB.Enabled = True
		Me.CmdChangerDB.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdChangerDB.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdChangerDB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdChangerDB.TabStop = True
		Me.CmdChangerDB.Name = "CmdChangerDB"
		Me.cmdDistList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDistList.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDistList.Text = "Listes de distribution"
		Me.cmdDistList.Size = New System.Drawing.Size(155, 33)
		Me.cmdDistList.Location = New System.Drawing.Point(176, 208)
		Me.cmdDistList.TabIndex = 15
		Me.cmdDistList.CausesValidation = True
		Me.cmdDistList.Enabled = True
		Me.cmdDistList.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDistList.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDistList.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDistList.TabStop = True
		Me.cmdDistList.Name = "cmdDistList"
		Me.cmdFormulaire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFormulaire.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFormulaire.Text = "&Rapports"
		Me.cmdFormulaire.Enabled = False
		Me.cmdFormulaire.Size = New System.Drawing.Size(153, 33)
		Me.cmdFormulaire.Location = New System.Drawing.Point(8, 256)
		Me.cmdFormulaire.TabIndex = 13
		Me.cmdFormulaire.CausesValidation = True
		Me.cmdFormulaire.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFormulaire.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFormulaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFormulaire.TabStop = True
		Me.cmdFormulaire.Name = "cmdFormulaire"
		Me.cmdEmploye.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEmploye.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEmploye.Text = "&Employés"
		Me.cmdEmploye.Enabled = False
		Me.cmdEmploye.Size = New System.Drawing.Size(153, 33)
		Me.cmdEmploye.Location = New System.Drawing.Point(8, 208)
		Me.cmdEmploye.TabIndex = 11
		Me.cmdEmploye.CausesValidation = True
		Me.cmdEmploye.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEmploye.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEmploye.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEmploye.TabStop = True
		Me.cmdEmploye.Name = "cmdEmploye"
		Me.cmdContact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdContact.BackColor = System.Drawing.SystemColors.Control
		Me.cmdContact.Text = "Co&ntacts"
		Me.cmdContact.Enabled = False
		Me.cmdContact.Size = New System.Drawing.Size(153, 33)
		Me.cmdContact.Location = New System.Drawing.Point(8, 160)
		Me.cmdContact.TabIndex = 8
		Me.cmdContact.CausesValidation = True
		Me.cmdContact.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdContact.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdContact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdContact.TabStop = True
		Me.cmdContact.Name = "cmdContact"
		Me.cmdFournisseur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFournisseur.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFournisseur.Text = "&Fournisseurs"
		Me.cmdFournisseur.Enabled = False
		Me.cmdFournisseur.Size = New System.Drawing.Size(153, 33)
		Me.cmdFournisseur.Location = New System.Drawing.Point(8, 112)
		Me.cmdFournisseur.TabIndex = 5
		Me.cmdFournisseur.CausesValidation = True
		Me.cmdFournisseur.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFournisseur.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFournisseur.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFournisseur.TabStop = True
		Me.cmdFournisseur.Name = "cmdFournisseur"
		Me.tmrAlarme.Interval = 5000
		Me.tmrAlarme.Enabled = True
		Me.cmdInventaire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdInventaire.BackColor = System.Drawing.SystemColors.Control
		Me.cmdInventaire.Text = "&Inventaire"
		Me.cmdInventaire.Size = New System.Drawing.Size(153, 33)
		Me.cmdInventaire.Location = New System.Drawing.Point(344, 64)
		Me.cmdInventaire.TabIndex = 4
		Me.cmdInventaire.CausesValidation = True
		Me.cmdInventaire.Enabled = True
		Me.cmdInventaire.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdInventaire.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdInventaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdInventaire.TabStop = True
		Me.cmdInventaire.Name = "cmdInventaire"
		Me.cmdPunch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPunch.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPunch.Text = "&Punch"
		Me.cmdPunch.Size = New System.Drawing.Size(153, 33)
		Me.cmdPunch.Location = New System.Drawing.Point(176, 64)
		Me.cmdPunch.TabIndex = 3
		Me.cmdPunch.CausesValidation = True
		Me.cmdPunch.Enabled = True
		Me.cmdPunch.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPunch.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPunch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPunch.TabStop = True
		Me.cmdPunch.Name = "cmdPunch"
		Me.cmdConfiguration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdConfiguration.BackColor = System.Drawing.SystemColors.Control
		Me.cmdConfiguration.Text = "Confi&guration"
		Me.cmdConfiguration.Size = New System.Drawing.Size(153, 33)
		Me.cmdConfiguration.Location = New System.Drawing.Point(344, 208)
		Me.cmdConfiguration.TabIndex = 12
		Me.cmdConfiguration.CausesValidation = True
		Me.cmdConfiguration.Enabled = True
		Me.cmdConfiguration.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdConfiguration.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdConfiguration.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdConfiguration.TabStop = True
		Me.cmdConfiguration.Name = "cmdConfiguration"
		Me.cmdCedule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCedule.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCedule.Text = "Cé&dule"
		Me.cmdCedule.Enabled = False
		Me.cmdCedule.Size = New System.Drawing.Size(153, 33)
		Me.cmdCedule.Location = New System.Drawing.Point(176, 112)
		Me.cmdCedule.TabIndex = 6
		Me.cmdCedule.CausesValidation = True
		Me.cmdCedule.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCedule.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCedule.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCedule.TabStop = True
		Me.cmdCedule.Name = "cmdCedule"
		Me.cmdVendeur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdVendeur.BackColor = System.Drawing.SystemColors.Control
		Me.cmdVendeur.Text = "Contacts pour &vendeurs"
		Me.cmdVendeur.Size = New System.Drawing.Size(155, 33)
		Me.cmdVendeur.Location = New System.Drawing.Point(176, 160)
		Me.cmdVendeur.TabIndex = 9
		Me.cmdVendeur.CausesValidation = True
		Me.cmdVendeur.Enabled = True
		Me.cmdVendeur.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdVendeur.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdVendeur.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdVendeur.TabStop = True
		Me.cmdVendeur.Name = "cmdVendeur"
		Me.cmdquitter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdquitter.BackColor = System.Drawing.SystemColors.Control
		Me.cmdquitter.Text = "&Quitter"
		Me.cmdquitter.Size = New System.Drawing.Size(153, 33)
		Me.cmdquitter.Location = New System.Drawing.Point(344, 256)
		Me.cmdquitter.TabIndex = 14
		Me.cmdquitter.CausesValidation = True
		Me.cmdquitter.Enabled = True
		Me.cmdquitter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdquitter.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdquitter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdquitter.TabStop = True
		Me.cmdquitter.Name = "cmdquitter"
		Me.cmdClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClient.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClient.Text = "&Clients"
		Me.cmdClient.Enabled = False
		Me.cmdClient.Size = New System.Drawing.Size(153, 33)
		Me.cmdClient.Location = New System.Drawing.Point(8, 64)
		Me.cmdClient.TabIndex = 2
		Me.cmdClient.CausesValidation = True
		Me.cmdClient.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClient.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClient.TabStop = True
		Me.cmdClient.Name = "cmdClient"
		Me.cmdCatalogue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCatalogue.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCatalogue.Text = "C&atalogue"
		Me.cmdCatalogue.Enabled = False
		Me.cmdCatalogue.Size = New System.Drawing.Size(153, 33)
		Me.cmdCatalogue.Location = New System.Drawing.Point(344, 112)
		Me.cmdCatalogue.TabIndex = 7
		Me.cmdCatalogue.CausesValidation = True
		Me.cmdCatalogue.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCatalogue.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCatalogue.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCatalogue.TabStop = True
		Me.cmdCatalogue.Name = "cmdCatalogue"
		Me.cmdProjSoum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdProjSoum.BackColor = System.Drawing.SystemColors.Control
		Me.cmdProjSoum.Text = "Projets / &Soumissions"
		Me.cmdProjSoum.Size = New System.Drawing.Size(153, 33)
		Me.cmdProjSoum.Location = New System.Drawing.Point(344, 160)
		Me.cmdProjSoum.TabIndex = 10
		Me.cmdProjSoum.CausesValidation = True
		Me.cmdProjSoum.Enabled = True
		Me.cmdProjSoum.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdProjSoum.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdProjSoum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdProjSoum.TabStop = True
		Me.cmdProjSoum.Name = "cmdProjSoum"
		Me.lbldb.BackColor = System.Drawing.Color.Black
		Me.lbldb.Text = "Base de donné:"
		Me.lbldb.ForeColor = System.Drawing.Color.White
		Me.lbldb.Size = New System.Drawing.Size(281, 17)
		Me.lbldb.Location = New System.Drawing.Point(208, 24)
		Me.lbldb.TabIndex = 16
		Me.lbldb.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbldb.Enabled = True
		Me.lbldb.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbldb.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbldb.UseMnemonic = True
		Me.lbldb.Visible = True
		Me.lbldb.AutoSize = False
		Me.lbldb.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbldb.Name = "lbldb"
		Me.lblDerniereVersion.BackColor = System.Drawing.Color.Black
		Me.lblDerniereVersion.Text = "Dernière Version : "
		Me.lblDerniereVersion.ForeColor = System.Drawing.Color.White
		Me.lblDerniereVersion.Size = New System.Drawing.Size(145, 17)
		Me.lblDerniereVersion.Location = New System.Drawing.Point(208, 0)
		Me.lblDerniereVersion.TabIndex = 0
		Me.lblDerniereVersion.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDerniereVersion.Enabled = True
		Me.lblDerniereVersion.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDerniereVersion.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDerniereVersion.UseMnemonic = True
		Me.lblDerniereVersion.Visible = True
		Me.lblDerniereVersion.AutoSize = False
		Me.lblDerniereVersion.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDerniereVersion.Name = "lblDerniereVersion"
		Me.lblVersion.BackColor = System.Drawing.Color.Black
		Me.lblVersion.Text = "Version "
		Me.lblVersion.ForeColor = System.Drawing.Color.White
		Me.lblVersion.Size = New System.Drawing.Size(89, 17)
		Me.lblVersion.Location = New System.Drawing.Point(416, 0)
		Me.lblVersion.TabIndex = 1
		Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblVersion.Enabled = True
		Me.lblVersion.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblVersion.UseMnemonic = True
		Me.lblVersion.Visible = True
		Me.lblVersion.AutoSize = False
		Me.lblVersion.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblVersion.Name = "lblVersion"
		Me.Controls.Add(CmdChangerDB)
		Me.Controls.Add(cmdDistList)
		Me.Controls.Add(cmdFormulaire)
		Me.Controls.Add(cmdEmploye)
		Me.Controls.Add(cmdContact)
		Me.Controls.Add(cmdFournisseur)
		Me.Controls.Add(cmdInventaire)
		Me.Controls.Add(cmdPunch)
		Me.Controls.Add(cmdConfiguration)
		Me.Controls.Add(cmdCedule)
		Me.Controls.Add(cmdVendeur)
		Me.Controls.Add(cmdquitter)
		Me.Controls.Add(cmdClient)
		Me.Controls.Add(cmdCatalogue)
		Me.Controls.Add(cmdProjSoum)
		Me.Controls.Add(lbldb)
		Me.Controls.Add(lblDerniereVersion)
		Me.Controls.Add(lblVersion)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class