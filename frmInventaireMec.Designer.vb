<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmInventaireMec
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
	Public WithEvents cmdexporter As System.Windows.Forms.Button
	Public WithEvents _chkChoix_2 As System.Windows.Forms.CheckBox
	Public WithEvents cmdAfficherHistorique As System.Windows.Forms.Button
	Public WithEvents _chkChoix_1 As System.Windows.Forms.CheckBox
	Public WithEvents _chkChoix_0 As System.Windows.Forms.CheckBox
	Public WithEvents cmdImprimer As System.Windows.Forms.Button
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	Public WithEvents _lvwHistorique_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwHistorique_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwHistorique_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwHistorique_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwHistorique_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwHistorique As System.Windows.Forms.ListView
	Public WithEvents txtNoPiece As System.Windows.Forms.TextBox
	Public WithEvents fraPiece As System.Windows.Forms.GroupBox
	Public WithEvents txtNoProjet As System.Windows.Forms.TextBox
	Public WithEvents fraProjet As System.Windows.Forms.GroupBox
	Public WithEvents mskDateDebut As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskDateFin As System.Windows.Forms.MaskedTextBox
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents fraDate As System.Windows.Forms.GroupBox
	Public WithEvents lblTitrePlusMoins As System.Windows.Forms.Label
	Public WithEvents chkChoix As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmInventaireMec))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdexporter = New System.Windows.Forms.Button
		Me._chkChoix_2 = New System.Windows.Forms.CheckBox
		Me.cmdAfficherHistorique = New System.Windows.Forms.Button
		Me._chkChoix_1 = New System.Windows.Forms.CheckBox
		Me._chkChoix_0 = New System.Windows.Forms.CheckBox
		Me.cmdImprimer = New System.Windows.Forms.Button
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.lvwHistorique = New System.Windows.Forms.ListView
		Me._lvwHistorique_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwHistorique_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwHistorique_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwHistorique_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwHistorique_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me.fraPiece = New System.Windows.Forms.GroupBox
		Me.txtNoPiece = New System.Windows.Forms.TextBox
		Me.fraProjet = New System.Windows.Forms.GroupBox
		Me.txtNoProjet = New System.Windows.Forms.TextBox
		Me.fraDate = New System.Windows.Forms.GroupBox
		Me.mskDateDebut = New System.Windows.Forms.MaskedTextBox
		Me.mskDateFin = New System.Windows.Forms.MaskedTextBox
		Me.Label12 = New System.Windows.Forms.Label
		Me.Label15 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.lblTitrePlusMoins = New System.Windows.Forms.Label
		Me.chkChoix = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
		Me.lvwHistorique.SuspendLayout()
		Me.fraPiece.SuspendLayout()
		Me.fraProjet.SuspendLayout()
		Me.fraDate.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.chkChoix, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Inventaire mécanique"
		Me.ClientSize = New System.Drawing.Size(666, 441)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmInventaireMec.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "frmInventaireMec"
		Me.cmdexporter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdexporter.Text = "Export vers excel"
		Me.cmdexporter.Size = New System.Drawing.Size(113, 25)
		Me.cmdexporter.Location = New System.Drawing.Point(104, 408)
		Me.cmdexporter.TabIndex = 18
		Me.cmdexporter.BackColor = System.Drawing.SystemColors.Control
		Me.cmdexporter.CausesValidation = True
		Me.cmdexporter.Enabled = True
		Me.cmdexporter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdexporter.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdexporter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdexporter.TabStop = True
		Me.cmdexporter.Name = "cmdexporter"
		Me._chkChoix_2.BackColor = System.Drawing.Color.Black
		Me._chkChoix_2.Text = "Date"
		Me._chkChoix_2.ForeColor = System.Drawing.Color.White
		Me._chkChoix_2.Size = New System.Drawing.Size(44, 17)
		Me._chkChoix_2.Location = New System.Drawing.Point(408, 56)
		Me._chkChoix_2.TabIndex = 7
		Me._chkChoix_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._chkChoix_2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._chkChoix_2.CausesValidation = True
		Me._chkChoix_2.Enabled = True
		Me._chkChoix_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkChoix_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkChoix_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkChoix_2.TabStop = True
		Me._chkChoix_2.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkChoix_2.Visible = True
		Me._chkChoix_2.Name = "_chkChoix_2"
		Me.cmdAfficherHistorique.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAfficherHistorique.Text = "Afficher"
		Me.AcceptButton = Me.cmdAfficherHistorique
		Me.cmdAfficherHistorique.Size = New System.Drawing.Size(57, 25)
		Me.cmdAfficherHistorique.Location = New System.Drawing.Point(600, 88)
		Me.cmdAfficherHistorique.TabIndex = 14
		Me.cmdAfficherHistorique.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAfficherHistorique.CausesValidation = True
		Me.cmdAfficherHistorique.Enabled = True
		Me.cmdAfficherHistorique.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAfficherHistorique.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAfficherHistorique.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAfficherHistorique.TabStop = True
		Me.cmdAfficherHistorique.Name = "cmdAfficherHistorique"
		Me._chkChoix_1.BackColor = System.Drawing.Color.Black
		Me._chkChoix_1.Text = "Pièce"
		Me._chkChoix_1.ForeColor = System.Drawing.Color.White
		Me._chkChoix_1.Size = New System.Drawing.Size(49, 17)
		Me._chkChoix_1.Location = New System.Drawing.Point(200, 56)
		Me._chkChoix_1.TabIndex = 4
		Me._chkChoix_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._chkChoix_1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._chkChoix_1.CausesValidation = True
		Me._chkChoix_1.Enabled = True
		Me._chkChoix_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkChoix_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkChoix_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkChoix_1.TabStop = True
		Me._chkChoix_1.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkChoix_1.Visible = True
		Me._chkChoix_1.Name = "_chkChoix_1"
		Me._chkChoix_0.BackColor = System.Drawing.Color.Black
		Me._chkChoix_0.Text = "Projet"
		Me._chkChoix_0.ForeColor = System.Drawing.Color.White
		Me._chkChoix_0.Size = New System.Drawing.Size(49, 17)
		Me._chkChoix_0.Location = New System.Drawing.Point(16, 56)
		Me._chkChoix_0.TabIndex = 3
		Me._chkChoix_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._chkChoix_0.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._chkChoix_0.CausesValidation = True
		Me._chkChoix_0.Enabled = True
		Me._chkChoix_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._chkChoix_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._chkChoix_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._chkChoix_0.TabStop = True
		Me._chkChoix_0.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._chkChoix_0.Visible = True
		Me._chkChoix_0.Name = "_chkChoix_0"
		Me.cmdImprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdImprimer.Text = "Imprimer"
		Me.cmdImprimer.Size = New System.Drawing.Size(89, 25)
		Me.cmdImprimer.Location = New System.Drawing.Point(8, 408)
		Me.cmdImprimer.TabIndex = 16
		Me.cmdImprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdImprimer.CausesValidation = True
		Me.cmdImprimer.Enabled = True
		Me.cmdImprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdImprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdImprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdImprimer.TabStop = True
		Me.cmdImprimer.Name = "cmdImprimer"
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(73, 25)
		Me.cmdFermer.Location = New System.Drawing.Point(584, 408)
		Me.cmdFermer.TabIndex = 17
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.lvwHistorique.Size = New System.Drawing.Size(649, 281)
		Me.lvwHistorique.Location = New System.Drawing.Point(8, 120)
		Me.lvwHistorique.TabIndex = 15
		Me.lvwHistorique.View = System.Windows.Forms.View.Details
		Me.lvwHistorique.LabelEdit = False
		Me.lvwHistorique.LabelWrap = True
		Me.lvwHistorique.HideSelection = True
		Me.lvwHistorique.FullRowSelect = True
		Me.lvwHistorique.GridLines = True
		Me.lvwHistorique.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwHistorique.BackColor = System.Drawing.SystemColors.Window
		Me.lvwHistorique.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwHistorique.Name = "lvwHistorique"
		Me._lvwHistorique_ColumnHeader_1.Text = "Date"
		Me._lvwHistorique_ColumnHeader_1.Width = 112
		Me._lvwHistorique_ColumnHeader_2.Text = "Utilisateur"
		Me._lvwHistorique_ColumnHeader_2.Width = 105
		Me._lvwHistorique_ColumnHeader_3.Text = "Projet"
		Me._lvwHistorique_ColumnHeader_3.Width = 124
		Me._lvwHistorique_ColumnHeader_4.Text = "Pièce"
		Me._lvwHistorique_ColumnHeader_4.Width = 172
		Me._lvwHistorique_ColumnHeader_5.Text = "Quantité"
		Me._lvwHistorique_ColumnHeader_5.Width = 99
		Me.fraPiece.BackColor = System.Drawing.Color.Black
		Me.fraPiece.Enabled = False
		Me.fraPiece.ForeColor = System.Drawing.Color.White
		Me.fraPiece.Size = New System.Drawing.Size(201, 57)
		Me.fraPiece.Location = New System.Drawing.Point(192, 56)
		Me.fraPiece.TabIndex = 5
		Me.fraPiece.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraPiece.Visible = True
		Me.fraPiece.Padding = New System.Windows.Forms.Padding(0)
		Me.fraPiece.Name = "fraPiece"
		Me.txtNoPiece.AutoSize = False
		Me.txtNoPiece.Size = New System.Drawing.Size(185, 19)
		Me.txtNoPiece.Location = New System.Drawing.Point(8, 32)
		Me.txtNoPiece.TabIndex = 6
		Me.txtNoPiece.AcceptsReturn = True
		Me.txtNoPiece.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoPiece.BackColor = System.Drawing.SystemColors.Window
		Me.txtNoPiece.CausesValidation = True
		Me.txtNoPiece.Enabled = True
		Me.txtNoPiece.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNoPiece.HideSelection = True
		Me.txtNoPiece.ReadOnly = False
		Me.txtNoPiece.Maxlength = 0
		Me.txtNoPiece.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNoPiece.MultiLine = False
		Me.txtNoPiece.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNoPiece.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNoPiece.TabStop = True
		Me.txtNoPiece.Visible = True
		Me.txtNoPiece.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoPiece.Name = "txtNoPiece"
		Me.fraProjet.BackColor = System.Drawing.Color.Black
		Me.fraProjet.Enabled = False
		Me.fraProjet.ForeColor = System.Drawing.Color.White
		Me.fraProjet.Size = New System.Drawing.Size(177, 57)
		Me.fraProjet.Location = New System.Drawing.Point(8, 56)
		Me.fraProjet.TabIndex = 1
		Me.fraProjet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraProjet.Visible = True
		Me.fraProjet.Padding = New System.Windows.Forms.Padding(0)
		Me.fraProjet.Name = "fraProjet"
		Me.txtNoProjet.AutoSize = False
		Me.txtNoProjet.Size = New System.Drawing.Size(161, 19)
		Me.txtNoProjet.Location = New System.Drawing.Point(8, 32)
		Me.txtNoProjet.TabIndex = 2
		Me.txtNoProjet.AcceptsReturn = True
		Me.txtNoProjet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoProjet.BackColor = System.Drawing.SystemColors.Window
		Me.txtNoProjet.CausesValidation = True
		Me.txtNoProjet.Enabled = True
		Me.txtNoProjet.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNoProjet.HideSelection = True
		Me.txtNoProjet.ReadOnly = False
		Me.txtNoProjet.Maxlength = 0
		Me.txtNoProjet.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNoProjet.MultiLine = False
		Me.txtNoProjet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNoProjet.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNoProjet.TabStop = True
		Me.txtNoProjet.Visible = True
		Me.txtNoProjet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoProjet.Name = "txtNoProjet"
		Me.fraDate.BackColor = System.Drawing.Color.Black
		Me.fraDate.Enabled = False
		Me.fraDate.ForeColor = System.Drawing.Color.White
		Me.fraDate.Size = New System.Drawing.Size(193, 57)
		Me.fraDate.Location = New System.Drawing.Point(400, 56)
		Me.fraDate.TabIndex = 8
		Me.fraDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraDate.Visible = True
		Me.fraDate.Padding = New System.Windows.Forms.Padding(0)
		Me.fraDate.Name = "fraDate"
		Me.mskDateDebut.AllowPromptAsInput = False
		Me.mskDateDebut.Size = New System.Drawing.Size(65, 17)
		Me.mskDateDebut.Location = New System.Drawing.Point(64, 16)
		Me.mskDateDebut.TabIndex = 10
		Me.mskDateDebut.PromptChar = "_"
		Me.mskDateDebut.Name = "mskDateDebut"
		Me.mskDateFin.AllowPromptAsInput = False
		Me.mskDateFin.Size = New System.Drawing.Size(65, 17)
		Me.mskDateFin.Location = New System.Drawing.Point(64, 36)
		Me.mskDateFin.TabIndex = 13
		Me.mskDateFin.PromptChar = "_"
		Me.mskDateFin.Name = "mskDateFin"
		Me.Label12.Text = "Au :"
		Me.Label12.ForeColor = System.Drawing.Color.White
		Me.Label12.Size = New System.Drawing.Size(25, 17)
		Me.Label12.Location = New System.Drawing.Point(32, 36)
		Me.Label12.TabIndex = 12
		Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label12.BackColor = System.Drawing.Color.Transparent
		Me.Label12.Enabled = True
		Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label12.UseMnemonic = True
		Me.Label12.Visible = True
		Me.Label12.AutoSize = False
		Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label12.Name = "Label12"
		Me.Label15.Text = "Du :"
		Me.Label15.ForeColor = System.Drawing.Color.White
		Me.Label15.Size = New System.Drawing.Size(25, 17)
		Me.Label15.Location = New System.Drawing.Point(32, 16)
		Me.Label15.TabIndex = 9
		Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label15.BackColor = System.Drawing.Color.Transparent
		Me.Label15.Enabled = True
		Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label15.UseMnemonic = True
		Me.Label15.Visible = True
		Me.Label15.AutoSize = False
		Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label15.Name = "Label15"
		Me.Label6.Text = "AA-MM-JJ"
		Me.Label6.ForeColor = System.Drawing.Color.White
		Me.Label6.Size = New System.Drawing.Size(49, 17)
		Me.Label6.Location = New System.Drawing.Point(136, 24)
		Me.Label6.TabIndex = 11
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.BackColor = System.Drawing.Color.Transparent
		Me.Label6.Enabled = True
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = False
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.lblTitrePlusMoins.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblTitrePlusMoins.Text = "Historique de l'inventaire"
		Me.lblTitrePlusMoins.ForeColor = System.Drawing.Color.White
		Me.lblTitrePlusMoins.Size = New System.Drawing.Size(449, 25)
		Me.lblTitrePlusMoins.Location = New System.Drawing.Point(208, 16)
		Me.lblTitrePlusMoins.TabIndex = 0
		Me.lblTitrePlusMoins.BackColor = System.Drawing.Color.Transparent
		Me.lblTitrePlusMoins.Enabled = True
		Me.lblTitrePlusMoins.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTitrePlusMoins.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTitrePlusMoins.UseMnemonic = True
		Me.lblTitrePlusMoins.Visible = True
		Me.lblTitrePlusMoins.AutoSize = False
		Me.lblTitrePlusMoins.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTitrePlusMoins.Name = "lblTitrePlusMoins"
		Me.Controls.Add(cmdexporter)
		Me.Controls.Add(_chkChoix_2)
		Me.Controls.Add(cmdAfficherHistorique)
		Me.Controls.Add(_chkChoix_1)
		Me.Controls.Add(_chkChoix_0)
		Me.Controls.Add(cmdImprimer)
		Me.Controls.Add(cmdFermer)
		Me.Controls.Add(lvwHistorique)
		Me.Controls.Add(fraPiece)
		Me.Controls.Add(fraProjet)
		Me.Controls.Add(fraDate)
		Me.Controls.Add(lblTitrePlusMoins)
		Me.lvwHistorique.Columns.Add(_lvwHistorique_ColumnHeader_1)
		Me.lvwHistorique.Columns.Add(_lvwHistorique_ColumnHeader_2)
		Me.lvwHistorique.Columns.Add(_lvwHistorique_ColumnHeader_3)
		Me.lvwHistorique.Columns.Add(_lvwHistorique_ColumnHeader_4)
		Me.lvwHistorique.Columns.Add(_lvwHistorique_ColumnHeader_5)
		Me.fraPiece.Controls.Add(txtNoPiece)
		Me.fraProjet.Controls.Add(txtNoProjet)
		Me.fraDate.Controls.Add(mskDateDebut)
		Me.fraDate.Controls.Add(mskDateFin)
		Me.fraDate.Controls.Add(Label12)
		Me.fraDate.Controls.Add(Label15)
		Me.fraDate.Controls.Add(Label6)
		Me.chkChoix.SetIndex(_chkChoix_2, CType(2, Short))
		Me.chkChoix.SetIndex(_chkChoix_1, CType(1, Short))
		Me.chkChoix.SetIndex(_chkChoix_0, CType(0, Short))
		CType(Me.chkChoix, System.ComponentModel.ISupportInitialize).EndInit()
		Me.lvwHistorique.ResumeLayout(False)
		Me.fraPiece.ResumeLayout(False)
		Me.fraProjet.ResumeLayout(False)
		Me.fraDate.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class