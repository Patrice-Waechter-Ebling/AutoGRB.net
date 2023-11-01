<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmreport
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
	Public WithEvents cmbFournisseur2 As System.Windows.Forms.ComboBox
	Public WithEvents cmdRechercherFRS2 As System.Windows.Forms.Button
	Public WithEvents txtMsg As System.Windows.Forms.TextBox
	Public WithEvents chkProblemes As System.Windows.Forms.CheckBox
	Public WithEvents txtObjet As System.Windows.Forms.TextBox
	Public WithEvents cmdMsg As System.Windows.Forms.Button
	Public WithEvents txtDe As System.Windows.Forms.TextBox
	Public WithEvents txtPage As System.Windows.Forms.TextBox
	Public WithEvents chkFaxAnglais As System.Windows.Forms.CheckBox
	Public WithEvents chkFaxFrancais As System.Windows.Forms.CheckBox
	Public WithEvents chkBonLivraison As System.Windows.Forms.CheckBox
	Public WithEvents cmdSelect As System.Windows.Forms.Button
	Public WithEvents ChkFinFab As System.Windows.Forms.CheckBox
	Public WithEvents ChkFabFerm As System.Windows.Forms.CheckBox
	Public WithEvents ChkFabFermMéca As System.Windows.Forms.CheckBox
	Public WithEvents ChkProg As System.Windows.Forms.CheckBox
	Public WithEvents ChkConcept As System.Windows.Forms.CheckBox
	Public WithEvents ChkFourn As System.Windows.Forms.CheckBox
	Public WithEvents ChkClient As System.Windows.Forms.CheckBox
	Public WithEvents ChkBonTravail As System.Windows.Forms.CheckBox
	Public WithEvents lblObjet As System.Windows.Forms.Label
	Public WithEvents lblDe As System.Windows.Forms.Label
	Public WithEvents lblPage As System.Windows.Forms.Label
	Public WithEvents fraChoixRapport As System.Windows.Forms.GroupBox
	Public WithEvents cmbContactFRS As System.Windows.Forms.ComboBox
	Public WithEvents cmdRechercherFRS As System.Windows.Forms.Button
	Public WithEvents cmdRechercherClient2 As System.Windows.Forms.Button
	Public WithEvents cmdRechercherClient As System.Windows.Forms.Button
	Public WithEvents mskDateTravaux As System.Windows.Forms.MaskedTextBox
	Public WithEvents txtProjetClient As System.Windows.Forms.TextBox
	Public WithEvents cmdReport As System.Windows.Forms.Button
	Public WithEvents cmbFournisseur As System.Windows.Forms.ComboBox
	Public WithEvents mskDateLivraison As System.Windows.Forms.MaskedTextBox
	Public WithEvents txtTransport As System.Windows.Forms.TextBox
	Public WithEvents txtNomProjet As System.Windows.Forms.TextBox
	Public WithEvents txtNoCommande As System.Windows.Forms.TextBox
	Public WithEvents txtNoProjet As System.Windows.Forms.TextBox
	Public WithEvents txtNoSoumission As System.Windows.Forms.TextBox
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	Public WithEvents cmbGRB As System.Windows.Forms.ComboBox
	Public WithEvents cmbContact As System.Windows.Forms.ComboBox
	Public WithEvents cmbClient As System.Windows.Forms.ComboBox
	Public WithEvents cmbClient2 As System.Windows.Forms.ComboBox
	Public WithEvents mskDateCommande As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskDate As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskHeureTravaux As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskDateDue As System.Windows.Forms.MaskedTextBox
	Public WithEvents lblFournisseur2 As System.Windows.Forms.Label
	Public WithEvents lblDateDue As System.Windows.Forms.Label
	Public WithEvents lblFormatHeurePrevue As System.Windows.Forms.Label
	Public WithEvents lblFormatDateTravaux As System.Windows.Forms.Label
	Public WithEvents lblFormatDateCommande As System.Windows.Forms.Label
	Public WithEvents lblContactFRS As System.Windows.Forms.Label
	Public WithEvents lblHeureTravaux As System.Windows.Forms.Label
	Public WithEvents lblProjetClient As System.Windows.Forms.Label
	Public WithEvents lblFournisseur As System.Windows.Forms.Label
	Public WithEvents lblDateLivraison As System.Windows.Forms.Label
	Public WithEvents lblTransport As System.Windows.Forms.Label
	Public WithEvents lblClient2 As System.Windows.Forms.Label
	Public WithEvents lblClient As System.Windows.Forms.Label
	Public WithEvents lblDate As System.Windows.Forms.Label
	Public WithEvents lblDateTravaux As System.Windows.Forms.Label
	Public WithEvents lblNomProjet As System.Windows.Forms.Label
	Public WithEvents lblDateCommande As System.Windows.Forms.Label
	Public WithEvents lblNoCommande As System.Windows.Forms.Label
	Public WithEvents lblNoProjet As System.Windows.Forms.Label
	Public WithEvents lblNoSoumission As System.Windows.Forms.Label
	Public WithEvents lblGRB As System.Windows.Forms.Label
	Public WithEvents lblContact As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmreport))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmbFournisseur2 = New System.Windows.Forms.ComboBox
		Me.cmdRechercherFRS2 = New System.Windows.Forms.Button
		Me.fraChoixRapport = New System.Windows.Forms.GroupBox
		Me.txtMsg = New System.Windows.Forms.TextBox
		Me.chkProblemes = New System.Windows.Forms.CheckBox
		Me.txtObjet = New System.Windows.Forms.TextBox
		Me.cmdMsg = New System.Windows.Forms.Button
		Me.txtDe = New System.Windows.Forms.TextBox
		Me.txtPage = New System.Windows.Forms.TextBox
		Me.chkFaxAnglais = New System.Windows.Forms.CheckBox
		Me.chkFaxFrancais = New System.Windows.Forms.CheckBox
		Me.chkBonLivraison = New System.Windows.Forms.CheckBox
		Me.cmdSelect = New System.Windows.Forms.Button
		Me.ChkFinFab = New System.Windows.Forms.CheckBox
		Me.ChkFabFerm = New System.Windows.Forms.CheckBox
		Me.ChkFabFermMéca = New System.Windows.Forms.CheckBox
		Me.ChkProg = New System.Windows.Forms.CheckBox
		Me.ChkConcept = New System.Windows.Forms.CheckBox
		Me.ChkFourn = New System.Windows.Forms.CheckBox
		Me.ChkClient = New System.Windows.Forms.CheckBox
		Me.ChkBonTravail = New System.Windows.Forms.CheckBox
		Me.lblObjet = New System.Windows.Forms.Label
		Me.lblDe = New System.Windows.Forms.Label
		Me.lblPage = New System.Windows.Forms.Label
		Me.cmbContactFRS = New System.Windows.Forms.ComboBox
		Me.cmdRechercherFRS = New System.Windows.Forms.Button
		Me.cmdRechercherClient2 = New System.Windows.Forms.Button
		Me.cmdRechercherClient = New System.Windows.Forms.Button
		Me.mskDateTravaux = New System.Windows.Forms.MaskedTextBox
		Me.txtProjetClient = New System.Windows.Forms.TextBox
		Me.cmdReport = New System.Windows.Forms.Button
		Me.cmbFournisseur = New System.Windows.Forms.ComboBox
		Me.mskDateLivraison = New System.Windows.Forms.MaskedTextBox
		Me.txtTransport = New System.Windows.Forms.TextBox
		Me.txtNomProjet = New System.Windows.Forms.TextBox
		Me.txtNoCommande = New System.Windows.Forms.TextBox
		Me.txtNoProjet = New System.Windows.Forms.TextBox
		Me.txtNoSoumission = New System.Windows.Forms.TextBox
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.cmbGRB = New System.Windows.Forms.ComboBox
		Me.cmbContact = New System.Windows.Forms.ComboBox
		Me.cmbClient = New System.Windows.Forms.ComboBox
		Me.cmbClient2 = New System.Windows.Forms.ComboBox
		Me.mskDateCommande = New System.Windows.Forms.MaskedTextBox
		Me.mskDate = New System.Windows.Forms.MaskedTextBox
		Me.mskHeureTravaux = New System.Windows.Forms.MaskedTextBox
		Me.mskDateDue = New System.Windows.Forms.MaskedTextBox
		Me.lblFournisseur2 = New System.Windows.Forms.Label
		Me.lblDateDue = New System.Windows.Forms.Label
		Me.lblFormatHeurePrevue = New System.Windows.Forms.Label
		Me.lblFormatDateTravaux = New System.Windows.Forms.Label
		Me.lblFormatDateCommande = New System.Windows.Forms.Label
		Me.lblContactFRS = New System.Windows.Forms.Label
		Me.lblHeureTravaux = New System.Windows.Forms.Label
		Me.lblProjetClient = New System.Windows.Forms.Label
		Me.lblFournisseur = New System.Windows.Forms.Label
		Me.lblDateLivraison = New System.Windows.Forms.Label
		Me.lblTransport = New System.Windows.Forms.Label
		Me.lblClient2 = New System.Windows.Forms.Label
		Me.lblClient = New System.Windows.Forms.Label
		Me.lblDate = New System.Windows.Forms.Label
		Me.lblDateTravaux = New System.Windows.Forms.Label
		Me.lblNomProjet = New System.Windows.Forms.Label
		Me.lblDateCommande = New System.Windows.Forms.Label
		Me.lblNoCommande = New System.Windows.Forms.Label
		Me.lblNoProjet = New System.Windows.Forms.Label
		Me.lblNoSoumission = New System.Windows.Forms.Label
		Me.lblGRB = New System.Windows.Forms.Label
		Me.lblContact = New System.Windows.Forms.Label
		Me.fraChoixRapport.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Rapports"
		Me.ClientSize = New System.Drawing.Size(593, 547)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.Icon = CType(resources.GetObject("frmreport.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmreport"
		Me.cmbFournisseur2.Size = New System.Drawing.Size(273, 21)
		Me.cmbFournisseur2.Location = New System.Drawing.Point(280, 512)
		Me.cmbFournisseur2.Sorted = True
		Me.cmbFournisseur2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbFournisseur2.TabIndex = 67
		Me.cmbFournisseur2.BackColor = System.Drawing.SystemColors.Window
		Me.cmbFournisseur2.CausesValidation = True
		Me.cmbFournisseur2.Enabled = True
		Me.cmbFournisseur2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbFournisseur2.IntegralHeight = True
		Me.cmbFournisseur2.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbFournisseur2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbFournisseur2.TabStop = True
		Me.cmbFournisseur2.Visible = True
		Me.cmbFournisseur2.Name = "cmbFournisseur2"
		Me.cmdRechercherFRS2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRechercherFRS2.Text = "..."
		Me.cmdRechercherFRS2.Size = New System.Drawing.Size(25, 21)
		Me.cmdRechercherFRS2.Location = New System.Drawing.Point(560, 512)
		Me.cmdRechercherFRS2.TabIndex = 66
		Me.cmdRechercherFRS2.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercherFRS2.CausesValidation = True
		Me.cmdRechercherFRS2.Enabled = True
		Me.cmdRechercherFRS2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercherFRS2.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercherFRS2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercherFRS2.TabStop = True
		Me.cmdRechercherFRS2.Name = "cmdRechercherFRS2"
		Me.fraChoixRapport.Text = "LISTE DE RAPPORT"
		Me.fraChoixRapport.Size = New System.Drawing.Size(265, 441)
		Me.fraChoixRapport.Location = New System.Drawing.Point(8, 8)
		Me.fraChoixRapport.TabIndex = 1
		Me.fraChoixRapport.BackColor = System.Drawing.SystemColors.Control
		Me.fraChoixRapport.Enabled = True
		Me.fraChoixRapport.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraChoixRapport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraChoixRapport.Visible = True
		Me.fraChoixRapport.Padding = New System.Windows.Forms.Padding(0)
		Me.fraChoixRapport.Name = "fraChoixRapport"
		Me.txtMsg.AutoSize = False
		Me.txtMsg.Size = New System.Drawing.Size(265, 241)
		Me.txtMsg.Location = New System.Drawing.Point(0, 16)
		Me.txtMsg.MultiLine = True
		Me.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.txtMsg.WordWrap = False
		Me.txtMsg.TabIndex = 2
		Me.txtMsg.Visible = False
		Me.txtMsg.AcceptsReturn = True
		Me.txtMsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMsg.BackColor = System.Drawing.SystemColors.Window
		Me.txtMsg.CausesValidation = True
		Me.txtMsg.Enabled = True
		Me.txtMsg.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMsg.HideSelection = True
		Me.txtMsg.ReadOnly = False
		Me.txtMsg.Maxlength = 0
		Me.txtMsg.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMsg.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMsg.TabStop = True
		Me.txtMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMsg.Name = "txtMsg"
		Me.chkProblemes.Text = "PROBLÈMES"
		Me.chkProblemes.Size = New System.Drawing.Size(137, 17)
		Me.chkProblemes.Location = New System.Drawing.Point(16, 240)
		Me.chkProblemes.TabIndex = 65
		Me.chkProblemes.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkProblemes.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkProblemes.BackColor = System.Drawing.SystemColors.Control
		Me.chkProblemes.CausesValidation = True
		Me.chkProblemes.Enabled = True
		Me.chkProblemes.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkProblemes.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkProblemes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkProblemes.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkProblemes.TabStop = True
		Me.chkProblemes.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkProblemes.Visible = True
		Me.chkProblemes.Name = "chkProblemes"
		Me.txtObjet.AutoSize = False
		Me.txtObjet.Size = New System.Drawing.Size(193, 19)
		Me.txtObjet.Location = New System.Drawing.Point(64, 360)
		Me.txtObjet.TabIndex = 19
		Me.txtObjet.AcceptsReturn = True
		Me.txtObjet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtObjet.BackColor = System.Drawing.SystemColors.Window
		Me.txtObjet.CausesValidation = True
		Me.txtObjet.Enabled = True
		Me.txtObjet.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtObjet.HideSelection = True
		Me.txtObjet.ReadOnly = False
		Me.txtObjet.Maxlength = 0
		Me.txtObjet.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtObjet.MultiLine = False
		Me.txtObjet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtObjet.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtObjet.TabStop = True
		Me.txtObjet.Visible = True
		Me.txtObjet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtObjet.Name = "txtObjet"
		Me.cmdMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMsg.Text = "Message"
		Me.cmdMsg.Size = New System.Drawing.Size(73, 25)
		Me.cmdMsg.Location = New System.Drawing.Point(184, 264)
		Me.cmdMsg.TabIndex = 14
		Me.cmdMsg.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMsg.CausesValidation = True
		Me.cmdMsg.Enabled = True
		Me.cmdMsg.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMsg.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMsg.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMsg.TabStop = True
		Me.cmdMsg.Name = "cmdMsg"
		Me.txtDe.AutoSize = False
		Me.txtDe.Size = New System.Drawing.Size(145, 19)
		Me.txtDe.Location = New System.Drawing.Point(64, 336)
		Me.txtDe.TabIndex = 17
		Me.txtDe.AcceptsReturn = True
		Me.txtDe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDe.BackColor = System.Drawing.SystemColors.Window
		Me.txtDe.CausesValidation = True
		Me.txtDe.Enabled = True
		Me.txtDe.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDe.HideSelection = True
		Me.txtDe.ReadOnly = False
		Me.txtDe.Maxlength = 0
		Me.txtDe.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDe.MultiLine = False
		Me.txtDe.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDe.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDe.TabStop = True
		Me.txtDe.Visible = True
		Me.txtDe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDe.Name = "txtDe"
		Me.txtPage.AutoSize = False
		Me.txtPage.Size = New System.Drawing.Size(49, 19)
		Me.txtPage.Location = New System.Drawing.Point(64, 312)
		Me.txtPage.TabIndex = 16
		Me.txtPage.AcceptsReturn = True
		Me.txtPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPage.BackColor = System.Drawing.SystemColors.Window
		Me.txtPage.CausesValidation = True
		Me.txtPage.Enabled = True
		Me.txtPage.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPage.HideSelection = True
		Me.txtPage.ReadOnly = False
		Me.txtPage.Maxlength = 0
		Me.txtPage.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPage.MultiLine = False
		Me.txtPage.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPage.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPage.TabStop = True
		Me.txtPage.Visible = True
		Me.txtPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPage.Name = "txtPage"
		Me.chkFaxAnglais.Text = "Fax Anglais"
		Me.chkFaxAnglais.Size = New System.Drawing.Size(81, 17)
		Me.chkFaxAnglais.Location = New System.Drawing.Point(104, 264)
		Me.chkFaxAnglais.TabIndex = 12
		Me.chkFaxAnglais.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkFaxAnglais.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkFaxAnglais.BackColor = System.Drawing.SystemColors.Control
		Me.chkFaxAnglais.CausesValidation = True
		Me.chkFaxAnglais.Enabled = True
		Me.chkFaxAnglais.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkFaxAnglais.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkFaxAnglais.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkFaxAnglais.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkFaxAnglais.TabStop = True
		Me.chkFaxAnglais.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkFaxAnglais.Visible = True
		Me.chkFaxAnglais.Name = "chkFaxAnglais"
		Me.chkFaxFrancais.Text = "Fax Français"
		Me.chkFaxFrancais.Size = New System.Drawing.Size(89, 17)
		Me.chkFaxFrancais.Location = New System.Drawing.Point(16, 264)
		Me.chkFaxFrancais.TabIndex = 13
		Me.chkFaxFrancais.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkFaxFrancais.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkFaxFrancais.BackColor = System.Drawing.SystemColors.Control
		Me.chkFaxFrancais.CausesValidation = True
		Me.chkFaxFrancais.Enabled = True
		Me.chkFaxFrancais.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkFaxFrancais.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkFaxFrancais.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkFaxFrancais.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkFaxFrancais.TabStop = True
		Me.chkFaxFrancais.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkFaxFrancais.Visible = True
		Me.chkFaxFrancais.Name = "chkFaxFrancais"
		Me.chkBonLivraison.Text = "BON DE LIVRAISON"
		Me.chkBonLivraison.Size = New System.Drawing.Size(137, 17)
		Me.chkBonLivraison.Location = New System.Drawing.Point(16, 48)
		Me.chkBonLivraison.TabIndex = 4
		Me.chkBonLivraison.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkBonLivraison.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkBonLivraison.BackColor = System.Drawing.SystemColors.Control
		Me.chkBonLivraison.CausesValidation = True
		Me.chkBonLivraison.Enabled = True
		Me.chkBonLivraison.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkBonLivraison.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkBonLivraison.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkBonLivraison.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkBonLivraison.TabStop = True
		Me.chkBonLivraison.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkBonLivraison.Visible = True
		Me.chkBonLivraison.Name = "chkBonLivraison"
		Me.cmdSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSelect.Text = "Sélectionner tout"
		Me.cmdSelect.Size = New System.Drawing.Size(137, 33)
		Me.cmdSelect.Location = New System.Drawing.Point(64, 392)
		Me.cmdSelect.TabIndex = 21
		Me.cmdSelect.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSelect.CausesValidation = True
		Me.cmdSelect.Enabled = True
		Me.cmdSelect.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSelect.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSelect.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSelect.TabStop = True
		Me.cmdSelect.Name = "cmdSelect"
		Me.ChkFinFab.Text = "FINS DE FABRICATION"
		Me.ChkFinFab.Size = New System.Drawing.Size(137, 17)
		Me.ChkFinFab.Location = New System.Drawing.Point(16, 216)
		Me.ChkFinFab.TabIndex = 11
		Me.ChkFinFab.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ChkFinFab.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.ChkFinFab.BackColor = System.Drawing.SystemColors.Control
		Me.ChkFinFab.CausesValidation = True
		Me.ChkFinFab.Enabled = True
		Me.ChkFinFab.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ChkFinFab.Cursor = System.Windows.Forms.Cursors.Default
		Me.ChkFinFab.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ChkFinFab.Appearance = System.Windows.Forms.Appearance.Normal
		Me.ChkFinFab.TabStop = True
		Me.ChkFinFab.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.ChkFinFab.Visible = True
		Me.ChkFinFab.Name = "ChkFinFab"
		Me.ChkFabFerm.Text = "FABRICATION - FERMETURE"
		Me.ChkFabFerm.Size = New System.Drawing.Size(233, 17)
		Me.ChkFabFerm.Location = New System.Drawing.Point(16, 192)
		Me.ChkFabFerm.TabIndex = 10
		Me.ChkFabFerm.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ChkFabFerm.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.ChkFabFerm.BackColor = System.Drawing.SystemColors.Control
		Me.ChkFabFerm.CausesValidation = True
		Me.ChkFabFerm.Enabled = True
		Me.ChkFabFerm.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ChkFabFerm.Cursor = System.Windows.Forms.Cursors.Default
		Me.ChkFabFerm.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ChkFabFerm.Appearance = System.Windows.Forms.Appearance.Normal
		Me.ChkFabFerm.TabStop = True
		Me.ChkFabFerm.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.ChkFabFerm.Visible = True
		Me.ChkFabFerm.Name = "ChkFabFerm"
		Me.ChkFabFermMéca.Text = "FABRICATION - FERMETURE MÉCANIQUE"
		Me.ChkFabFermMéca.Size = New System.Drawing.Size(241, 17)
		Me.ChkFabFermMéca.Location = New System.Drawing.Point(16, 168)
		Me.ChkFabFermMéca.TabIndex = 9
		Me.ChkFabFermMéca.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ChkFabFermMéca.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.ChkFabFermMéca.BackColor = System.Drawing.SystemColors.Control
		Me.ChkFabFermMéca.CausesValidation = True
		Me.ChkFabFermMéca.Enabled = True
		Me.ChkFabFermMéca.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ChkFabFermMéca.Cursor = System.Windows.Forms.Cursors.Default
		Me.ChkFabFermMéca.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ChkFabFermMéca.Appearance = System.Windows.Forms.Appearance.Normal
		Me.ChkFabFermMéca.TabStop = True
		Me.ChkFabFermMéca.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.ChkFabFermMéca.Visible = True
		Me.ChkFabFermMéca.Name = "ChkFabFermMéca"
		Me.ChkProg.Text = "PROGRAMMATION"
		Me.ChkProg.Size = New System.Drawing.Size(137, 17)
		Me.ChkProg.Location = New System.Drawing.Point(16, 144)
		Me.ChkProg.TabIndex = 8
		Me.ChkProg.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ChkProg.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.ChkProg.BackColor = System.Drawing.SystemColors.Control
		Me.ChkProg.CausesValidation = True
		Me.ChkProg.Enabled = True
		Me.ChkProg.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ChkProg.Cursor = System.Windows.Forms.Cursors.Default
		Me.ChkProg.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ChkProg.Appearance = System.Windows.Forms.Appearance.Normal
		Me.ChkProg.TabStop = True
		Me.ChkProg.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.ChkProg.Visible = True
		Me.ChkProg.Name = "ChkProg"
		Me.ChkConcept.Text = "CONCEPTION"
		Me.ChkConcept.Size = New System.Drawing.Size(137, 17)
		Me.ChkConcept.Location = New System.Drawing.Point(16, 120)
		Me.ChkConcept.TabIndex = 7
		Me.ChkConcept.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ChkConcept.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.ChkConcept.BackColor = System.Drawing.SystemColors.Control
		Me.ChkConcept.CausesValidation = True
		Me.ChkConcept.Enabled = True
		Me.ChkConcept.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ChkConcept.Cursor = System.Windows.Forms.Cursors.Default
		Me.ChkConcept.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ChkConcept.Appearance = System.Windows.Forms.Appearance.Normal
		Me.ChkConcept.TabStop = True
		Me.ChkConcept.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.ChkConcept.Visible = True
		Me.ChkConcept.Name = "ChkConcept"
		Me.ChkFourn.Text = "FOURNISSEUR"
		Me.ChkFourn.Size = New System.Drawing.Size(137, 17)
		Me.ChkFourn.Location = New System.Drawing.Point(16, 96)
		Me.ChkFourn.TabIndex = 6
		Me.ChkFourn.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ChkFourn.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.ChkFourn.BackColor = System.Drawing.SystemColors.Control
		Me.ChkFourn.CausesValidation = True
		Me.ChkFourn.Enabled = True
		Me.ChkFourn.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ChkFourn.Cursor = System.Windows.Forms.Cursors.Default
		Me.ChkFourn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ChkFourn.Appearance = System.Windows.Forms.Appearance.Normal
		Me.ChkFourn.TabStop = True
		Me.ChkFourn.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.ChkFourn.Visible = True
		Me.ChkFourn.Name = "ChkFourn"
		Me.ChkClient.Text = "CLIENT"
		Me.ChkClient.Size = New System.Drawing.Size(137, 17)
		Me.ChkClient.Location = New System.Drawing.Point(16, 72)
		Me.ChkClient.TabIndex = 5
		Me.ChkClient.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ChkClient.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.ChkClient.BackColor = System.Drawing.SystemColors.Control
		Me.ChkClient.CausesValidation = True
		Me.ChkClient.Enabled = True
		Me.ChkClient.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ChkClient.Cursor = System.Windows.Forms.Cursors.Default
		Me.ChkClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ChkClient.Appearance = System.Windows.Forms.Appearance.Normal
		Me.ChkClient.TabStop = True
		Me.ChkClient.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.ChkClient.Visible = True
		Me.ChkClient.Name = "ChkClient"
		Me.ChkBonTravail.Text = "BON DE TRAVAIL"
		Me.ChkBonTravail.Size = New System.Drawing.Size(137, 17)
		Me.ChkBonTravail.Location = New System.Drawing.Point(16, 24)
		Me.ChkBonTravail.TabIndex = 3
		Me.ChkBonTravail.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ChkBonTravail.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.ChkBonTravail.BackColor = System.Drawing.SystemColors.Control
		Me.ChkBonTravail.CausesValidation = True
		Me.ChkBonTravail.Enabled = True
		Me.ChkBonTravail.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ChkBonTravail.Cursor = System.Windows.Forms.Cursors.Default
		Me.ChkBonTravail.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ChkBonTravail.Appearance = System.Windows.Forms.Appearance.Normal
		Me.ChkBonTravail.TabStop = True
		Me.ChkBonTravail.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.ChkBonTravail.Visible = True
		Me.ChkBonTravail.Name = "ChkBonTravail"
		Me.lblObjet.Text = "Objet:"
		Me.lblObjet.Size = New System.Drawing.Size(33, 17)
		Me.lblObjet.Location = New System.Drawing.Point(32, 360)
		Me.lblObjet.TabIndex = 20
		Me.lblObjet.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblObjet.BackColor = System.Drawing.SystemColors.Control
		Me.lblObjet.Enabled = True
		Me.lblObjet.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblObjet.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblObjet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblObjet.UseMnemonic = True
		Me.lblObjet.Visible = True
		Me.lblObjet.AutoSize = False
		Me.lblObjet.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblObjet.Name = "lblObjet"
		Me.lblDe.Text = "De:"
		Me.lblDe.Size = New System.Drawing.Size(33, 17)
		Me.lblDe.Location = New System.Drawing.Point(32, 336)
		Me.lblDe.TabIndex = 18
		Me.lblDe.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDe.BackColor = System.Drawing.SystemColors.Control
		Me.lblDe.Enabled = True
		Me.lblDe.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDe.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDe.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDe.UseMnemonic = True
		Me.lblDe.Visible = True
		Me.lblDe.AutoSize = False
		Me.lblDe.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDe.Name = "lblDe"
		Me.lblPage.Text = "Pages"
		Me.lblPage.Size = New System.Drawing.Size(33, 17)
		Me.lblPage.Location = New System.Drawing.Point(32, 312)
		Me.lblPage.TabIndex = 15
		Me.lblPage.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPage.BackColor = System.Drawing.SystemColors.Control
		Me.lblPage.Enabled = True
		Me.lblPage.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPage.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPage.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPage.UseMnemonic = True
		Me.lblPage.Visible = True
		Me.lblPage.AutoSize = False
		Me.lblPage.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPage.Name = "lblPage"
		Me.cmbContactFRS.Size = New System.Drawing.Size(273, 21)
		Me.cmbContactFRS.Location = New System.Drawing.Point(280, 464)
		Me.cmbContactFRS.TabIndex = 64
		Me.cmbContactFRS.BackColor = System.Drawing.SystemColors.Window
		Me.cmbContactFRS.CausesValidation = True
		Me.cmbContactFRS.Enabled = True
		Me.cmbContactFRS.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbContactFRS.IntegralHeight = True
		Me.cmbContactFRS.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbContactFRS.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbContactFRS.Sorted = False
		Me.cmbContactFRS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbContactFRS.TabStop = True
		Me.cmbContactFRS.Visible = True
		Me.cmbContactFRS.Name = "cmbContactFRS"
		Me.cmdRechercherFRS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRechercherFRS.Text = "..."
		Me.cmdRechercherFRS.Size = New System.Drawing.Size(25, 21)
		Me.cmdRechercherFRS.Location = New System.Drawing.Point(560, 424)
		Me.cmdRechercherFRS.TabIndex = 60
		Me.cmdRechercherFRS.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercherFRS.CausesValidation = True
		Me.cmdRechercherFRS.Enabled = True
		Me.cmdRechercherFRS.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercherFRS.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercherFRS.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercherFRS.TabStop = True
		Me.cmdRechercherFRS.Name = "cmdRechercherFRS"
		Me.cmdRechercherClient2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRechercherClient2.Text = "..."
		Me.cmdRechercherClient2.Size = New System.Drawing.Size(25, 21)
		Me.cmdRechercherClient2.Location = New System.Drawing.Point(560, 344)
		Me.cmdRechercherClient2.TabIndex = 53
		Me.cmdRechercherClient2.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercherClient2.CausesValidation = True
		Me.cmdRechercherClient2.Enabled = True
		Me.cmdRechercherClient2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercherClient2.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercherClient2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercherClient2.TabStop = True
		Me.cmdRechercherClient2.Name = "cmdRechercherClient2"
		Me.cmdRechercherClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRechercherClient.Text = "..."
		Me.cmdRechercherClient.Size = New System.Drawing.Size(25, 21)
		Me.cmdRechercherClient.Location = New System.Drawing.Point(560, 16)
		Me.cmdRechercherClient.TabIndex = 23
		Me.cmdRechercherClient.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercherClient.CausesValidation = True
		Me.cmdRechercherClient.Enabled = True
		Me.cmdRechercherClient.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercherClient.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercherClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercherClient.TabStop = True
		Me.cmdRechercherClient.Name = "cmdRechercherClient"
		Me.mskDateTravaux.AllowPromptAsInput = False
		Me.mskDateTravaux.Size = New System.Drawing.Size(73, 17)
		Me.mskDateTravaux.Location = New System.Drawing.Point(280, 304)
		Me.mskDateTravaux.TabIndex = 47
		Me.mskDateTravaux.PromptChar = "_"
		Me.mskDateTravaux.Name = "mskDateTravaux"
		Me.txtProjetClient.AutoSize = False
		Me.txtProjetClient.Size = New System.Drawing.Size(177, 19)
		Me.txtProjetClient.Location = New System.Drawing.Point(392, 224)
		Me.txtProjetClient.TabIndex = 39
		Me.txtProjetClient.AcceptsReturn = True
		Me.txtProjetClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtProjetClient.BackColor = System.Drawing.SystemColors.Window
		Me.txtProjetClient.CausesValidation = True
		Me.txtProjetClient.Enabled = True
		Me.txtProjetClient.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtProjetClient.HideSelection = True
		Me.txtProjetClient.ReadOnly = False
		Me.txtProjetClient.Maxlength = 0
		Me.txtProjetClient.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtProjetClient.MultiLine = False
		Me.txtProjetClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtProjetClient.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtProjetClient.TabStop = True
		Me.txtProjetClient.Visible = True
		Me.txtProjetClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtProjetClient.Name = "txtProjetClient"
		Me.cmdReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdReport.Text = "Impression"
		Me.cmdReport.Size = New System.Drawing.Size(89, 41)
		Me.cmdReport.Location = New System.Drawing.Point(48, 464)
		Me.cmdReport.TabIndex = 61
		Me.cmdReport.BackColor = System.Drawing.SystemColors.Control
		Me.cmdReport.CausesValidation = True
		Me.cmdReport.Enabled = True
		Me.cmdReport.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdReport.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdReport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdReport.TabStop = True
		Me.cmdReport.Name = "cmdReport"
		Me.cmbFournisseur.Size = New System.Drawing.Size(273, 21)
		Me.cmbFournisseur.Location = New System.Drawing.Point(280, 424)
		Me.cmbFournisseur.TabIndex = 59
		Me.cmbFournisseur.Text = "cmbFournisseur"
		Me.cmbFournisseur.BackColor = System.Drawing.SystemColors.Window
		Me.cmbFournisseur.CausesValidation = True
		Me.cmbFournisseur.Enabled = True
		Me.cmbFournisseur.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbFournisseur.IntegralHeight = True
		Me.cmbFournisseur.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbFournisseur.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbFournisseur.Sorted = False
		Me.cmbFournisseur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbFournisseur.TabStop = True
		Me.cmbFournisseur.Visible = True
		Me.cmbFournisseur.Name = "cmbFournisseur"
		Me.mskDateLivraison.AllowPromptAsInput = False
		Me.mskDateLivraison.Size = New System.Drawing.Size(73, 21)
		Me.mskDateLivraison.Location = New System.Drawing.Point(464, 384)
		Me.mskDateLivraison.TabIndex = 57
		Me.mskDateLivraison.PromptChar = "_"
		Me.mskDateLivraison.Name = "mskDateLivraison"
		Me.txtTransport.AutoSize = False
		Me.txtTransport.Size = New System.Drawing.Size(177, 19)
		Me.txtTransport.Location = New System.Drawing.Point(280, 384)
		Me.txtTransport.TabIndex = 56
		Me.txtTransport.AcceptsReturn = True
		Me.txtTransport.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTransport.BackColor = System.Drawing.SystemColors.Window
		Me.txtTransport.CausesValidation = True
		Me.txtTransport.Enabled = True
		Me.txtTransport.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTransport.HideSelection = True
		Me.txtTransport.ReadOnly = False
		Me.txtTransport.Maxlength = 0
		Me.txtTransport.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTransport.MultiLine = False
		Me.txtTransport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTransport.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTransport.TabStop = True
		Me.txtTransport.Visible = True
		Me.txtTransport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTransport.Name = "txtTransport"
		Me.txtNomProjet.AutoSize = False
		Me.txtNomProjet.Size = New System.Drawing.Size(177, 19)
		Me.txtNomProjet.Location = New System.Drawing.Point(392, 184)
		Me.txtNomProjet.TabIndex = 35
		Me.txtNomProjet.AcceptsReturn = True
		Me.txtNomProjet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNomProjet.BackColor = System.Drawing.SystemColors.Window
		Me.txtNomProjet.CausesValidation = True
		Me.txtNomProjet.Enabled = True
		Me.txtNomProjet.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNomProjet.HideSelection = True
		Me.txtNomProjet.ReadOnly = False
		Me.txtNomProjet.Maxlength = 0
		Me.txtNomProjet.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNomProjet.MultiLine = False
		Me.txtNomProjet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNomProjet.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNomProjet.TabStop = True
		Me.txtNomProjet.Visible = True
		Me.txtNomProjet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNomProjet.Name = "txtNomProjet"
		Me.txtNoCommande.AutoSize = False
		Me.txtNoCommande.Size = New System.Drawing.Size(121, 17)
		Me.txtNoCommande.Location = New System.Drawing.Point(448, 264)
		Me.txtNoCommande.TabIndex = 44
		Me.txtNoCommande.AcceptsReturn = True
		Me.txtNoCommande.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoCommande.BackColor = System.Drawing.SystemColors.Window
		Me.txtNoCommande.CausesValidation = True
		Me.txtNoCommande.Enabled = True
		Me.txtNoCommande.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNoCommande.HideSelection = True
		Me.txtNoCommande.ReadOnly = False
		Me.txtNoCommande.Maxlength = 0
		Me.txtNoCommande.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNoCommande.MultiLine = False
		Me.txtNoCommande.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNoCommande.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNoCommande.TabStop = True
		Me.txtNoCommande.Visible = True
		Me.txtNoCommande.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoCommande.Name = "txtNoCommande"
		Me.txtNoProjet.AutoSize = False
		Me.txtNoProjet.Size = New System.Drawing.Size(81, 19)
		Me.txtNoProjet.Location = New System.Drawing.Point(280, 184)
		Me.txtNoProjet.TabIndex = 34
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
		Me.txtNoSoumission.AutoSize = False
		Me.txtNoSoumission.Size = New System.Drawing.Size(81, 19)
		Me.txtNoSoumission.Location = New System.Drawing.Point(280, 144)
		Me.txtNoSoumission.TabIndex = 30
		Me.txtNoSoumission.AcceptsReturn = True
		Me.txtNoSoumission.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoSoumission.BackColor = System.Drawing.SystemColors.Window
		Me.txtNoSoumission.CausesValidation = True
		Me.txtNoSoumission.Enabled = True
		Me.txtNoSoumission.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNoSoumission.HideSelection = True
		Me.txtNoSoumission.ReadOnly = False
		Me.txtNoSoumission.Maxlength = 0
		Me.txtNoSoumission.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNoSoumission.MultiLine = False
		Me.txtNoSoumission.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNoSoumission.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNoSoumission.TabStop = True
		Me.txtNoSoumission.Visible = True
		Me.txtNoSoumission.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoSoumission.Name = "txtNoSoumission"
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(89, 41)
		Me.cmdFermer.Location = New System.Drawing.Point(152, 464)
		Me.cmdFermer.TabIndex = 62
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.cmbGRB.Size = New System.Drawing.Size(273, 21)
		Me.cmbGRB.Location = New System.Drawing.Point(280, 96)
		Me.cmbGRB.TabIndex = 27
		Me.cmbGRB.BackColor = System.Drawing.SystemColors.Window
		Me.cmbGRB.CausesValidation = True
		Me.cmbGRB.Enabled = True
		Me.cmbGRB.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbGRB.IntegralHeight = True
		Me.cmbGRB.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbGRB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbGRB.Sorted = False
		Me.cmbGRB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbGRB.TabStop = True
		Me.cmbGRB.Visible = True
		Me.cmbGRB.Name = "cmbGRB"
		Me.cmbContact.Size = New System.Drawing.Size(273, 21)
		Me.cmbContact.Location = New System.Drawing.Point(280, 56)
		Me.cmbContact.TabIndex = 25
		Me.cmbContact.BackColor = System.Drawing.SystemColors.Window
		Me.cmbContact.CausesValidation = True
		Me.cmbContact.Enabled = True
		Me.cmbContact.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbContact.IntegralHeight = True
		Me.cmbContact.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbContact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbContact.Sorted = False
		Me.cmbContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbContact.TabStop = True
		Me.cmbContact.Visible = True
		Me.cmbContact.Name = "cmbContact"
		Me.cmbClient.Size = New System.Drawing.Size(273, 21)
		Me.cmbClient.Location = New System.Drawing.Point(280, 16)
		Me.cmbClient.Sorted = True
		Me.cmbClient.TabIndex = 22
		Me.cmbClient.Text = "cmbClient"
		Me.cmbClient.BackColor = System.Drawing.SystemColors.Window
		Me.cmbClient.CausesValidation = True
		Me.cmbClient.Enabled = True
		Me.cmbClient.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbClient.IntegralHeight = True
		Me.cmbClient.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbClient.TabStop = True
		Me.cmbClient.Visible = True
		Me.cmbClient.Name = "cmbClient"
		Me.cmbClient2.Size = New System.Drawing.Size(273, 21)
		Me.cmbClient2.Location = New System.Drawing.Point(280, 344)
		Me.cmbClient2.Sorted = True
		Me.cmbClient2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbClient2.TabIndex = 52
		Me.cmbClient2.BackColor = System.Drawing.SystemColors.Window
		Me.cmbClient2.CausesValidation = True
		Me.cmbClient2.Enabled = True
		Me.cmbClient2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbClient2.IntegralHeight = True
		Me.cmbClient2.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbClient2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbClient2.TabStop = True
		Me.cmbClient2.Visible = True
		Me.cmbClient2.Name = "cmbClient2"
		Me.mskDateCommande.AllowPromptAsInput = False
		Me.mskDateCommande.Size = New System.Drawing.Size(73, 17)
		Me.mskDateCommande.Location = New System.Drawing.Point(280, 264)
		Me.mskDateCommande.TabIndex = 42
		Me.mskDateCommande.PromptChar = "_"
		Me.mskDateCommande.Name = "mskDateCommande"
		Me.mskDate.AllowPromptAsInput = False
		Me.mskDate.Size = New System.Drawing.Size(73, 17)
		Me.mskDate.Location = New System.Drawing.Point(280, 224)
		Me.mskDate.TabIndex = 38
		Me.mskDate.PromptChar = "_"
		Me.mskDate.Name = "mskDate"
		Me.mskHeureTravaux.AllowPromptAsInput = False
		Me.mskHeureTravaux.Size = New System.Drawing.Size(73, 17)
		Me.mskHeureTravaux.Location = New System.Drawing.Point(448, 304)
		Me.mskHeureTravaux.TabIndex = 49
		Me.mskHeureTravaux.PromptChar = "_"
		Me.mskHeureTravaux.Name = "mskHeureTravaux"
		Me.mskDateDue.AllowPromptAsInput = False
		Me.mskDateDue.Size = New System.Drawing.Size(73, 17)
		Me.mskDateDue.Location = New System.Drawing.Point(392, 144)
		Me.mskDateDue.TabIndex = 31
		Me.mskDateDue.PromptChar = "_"
		Me.mskDateDue.Name = "mskDateDue"
		Me.lblFournisseur2.Text = "Fournisseur Expédié à"
		Me.lblFournisseur2.Size = New System.Drawing.Size(137, 17)
		Me.lblFournisseur2.Location = New System.Drawing.Point(280, 496)
		Me.lblFournisseur2.TabIndex = 68
		Me.lblFournisseur2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblFournisseur2.BackColor = System.Drawing.SystemColors.Control
		Me.lblFournisseur2.Enabled = True
		Me.lblFournisseur2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblFournisseur2.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblFournisseur2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblFournisseur2.UseMnemonic = True
		Me.lblFournisseur2.Visible = True
		Me.lblFournisseur2.AutoSize = False
		Me.lblFournisseur2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblFournisseur2.Name = "lblFournisseur2"
		Me.lblDateDue.Text = "Date dûe (AA-MM-JJ)"
		Me.lblDateDue.Size = New System.Drawing.Size(129, 17)
		Me.lblDateDue.Location = New System.Drawing.Point(392, 128)
		Me.lblDateDue.TabIndex = 29
		Me.lblDateDue.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDateDue.BackColor = System.Drawing.SystemColors.Control
		Me.lblDateDue.Enabled = True
		Me.lblDateDue.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDateDue.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDateDue.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDateDue.UseMnemonic = True
		Me.lblDateDue.Visible = True
		Me.lblDateDue.AutoSize = False
		Me.lblDateDue.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDateDue.Name = "lblDateDue"
		Me.lblFormatHeurePrevue.Text = "HH:MM"
		Me.lblFormatHeurePrevue.Size = New System.Drawing.Size(49, 17)
		Me.lblFormatHeurePrevue.Location = New System.Drawing.Point(528, 304)
		Me.lblFormatHeurePrevue.TabIndex = 50
		Me.lblFormatHeurePrevue.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblFormatHeurePrevue.BackColor = System.Drawing.SystemColors.Control
		Me.lblFormatHeurePrevue.Enabled = True
		Me.lblFormatHeurePrevue.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblFormatHeurePrevue.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblFormatHeurePrevue.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblFormatHeurePrevue.UseMnemonic = True
		Me.lblFormatHeurePrevue.Visible = True
		Me.lblFormatHeurePrevue.AutoSize = False
		Me.lblFormatHeurePrevue.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblFormatHeurePrevue.Name = "lblFormatHeurePrevue"
		Me.lblFormatDateTravaux.Text = "AA-MM-JJ"
		Me.lblFormatDateTravaux.Size = New System.Drawing.Size(65, 17)
		Me.lblFormatDateTravaux.Location = New System.Drawing.Point(360, 304)
		Me.lblFormatDateTravaux.TabIndex = 48
		Me.lblFormatDateTravaux.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblFormatDateTravaux.BackColor = System.Drawing.SystemColors.Control
		Me.lblFormatDateTravaux.Enabled = True
		Me.lblFormatDateTravaux.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblFormatDateTravaux.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblFormatDateTravaux.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblFormatDateTravaux.UseMnemonic = True
		Me.lblFormatDateTravaux.Visible = True
		Me.lblFormatDateTravaux.AutoSize = False
		Me.lblFormatDateTravaux.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblFormatDateTravaux.Name = "lblFormatDateTravaux"
		Me.lblFormatDateCommande.Text = "AA-MM-JJ"
		Me.lblFormatDateCommande.Size = New System.Drawing.Size(65, 17)
		Me.lblFormatDateCommande.Location = New System.Drawing.Point(360, 264)
		Me.lblFormatDateCommande.TabIndex = 43
		Me.lblFormatDateCommande.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblFormatDateCommande.BackColor = System.Drawing.SystemColors.Control
		Me.lblFormatDateCommande.Enabled = True
		Me.lblFormatDateCommande.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblFormatDateCommande.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblFormatDateCommande.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblFormatDateCommande.UseMnemonic = True
		Me.lblFormatDateCommande.Visible = True
		Me.lblFormatDateCommande.AutoSize = False
		Me.lblFormatDateCommande.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblFormatDateCommande.Name = "lblFormatDateCommande"
		Me.lblContactFRS.Text = "Contact"
		Me.lblContactFRS.Size = New System.Drawing.Size(57, 17)
		Me.lblContactFRS.Location = New System.Drawing.Point(280, 448)
		Me.lblContactFRS.TabIndex = 63
		Me.lblContactFRS.Visible = False
		Me.lblContactFRS.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblContactFRS.BackColor = System.Drawing.SystemColors.Control
		Me.lblContactFRS.Enabled = True
		Me.lblContactFRS.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblContactFRS.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblContactFRS.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblContactFRS.UseMnemonic = True
		Me.lblContactFRS.AutoSize = False
		Me.lblContactFRS.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblContactFRS.Name = "lblContactFRS"
		Me.lblHeureTravaux.Text = "Heure prévue"
		Me.lblHeureTravaux.Size = New System.Drawing.Size(81, 17)
		Me.lblHeureTravaux.Location = New System.Drawing.Point(448, 288)
		Me.lblHeureTravaux.TabIndex = 46
		Me.lblHeureTravaux.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblHeureTravaux.BackColor = System.Drawing.SystemColors.Control
		Me.lblHeureTravaux.Enabled = True
		Me.lblHeureTravaux.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblHeureTravaux.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblHeureTravaux.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblHeureTravaux.UseMnemonic = True
		Me.lblHeureTravaux.Visible = True
		Me.lblHeureTravaux.AutoSize = False
		Me.lblHeureTravaux.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblHeureTravaux.Name = "lblHeureTravaux"
		Me.lblProjetClient.Text = "Projet Client"
		Me.lblProjetClient.Size = New System.Drawing.Size(177, 17)
		Me.lblProjetClient.Location = New System.Drawing.Point(392, 208)
		Me.lblProjetClient.TabIndex = 37
		Me.lblProjetClient.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblProjetClient.BackColor = System.Drawing.SystemColors.Control
		Me.lblProjetClient.Enabled = True
		Me.lblProjetClient.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblProjetClient.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblProjetClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblProjetClient.UseMnemonic = True
		Me.lblProjetClient.Visible = True
		Me.lblProjetClient.AutoSize = False
		Me.lblProjetClient.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblProjetClient.Name = "lblProjetClient"
		Me.lblFournisseur.Text = "Fournisseur"
		Me.lblFournisseur.Size = New System.Drawing.Size(73, 17)
		Me.lblFournisseur.Location = New System.Drawing.Point(280, 408)
		Me.lblFournisseur.TabIndex = 58
		Me.lblFournisseur.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblFournisseur.BackColor = System.Drawing.SystemColors.Control
		Me.lblFournisseur.Enabled = True
		Me.lblFournisseur.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblFournisseur.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblFournisseur.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblFournisseur.UseMnemonic = True
		Me.lblFournisseur.Visible = True
		Me.lblFournisseur.AutoSize = False
		Me.lblFournisseur.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblFournisseur.Name = "lblFournisseur"
		Me.lblDateLivraison.Text = "Date livraison (AA-MM-JJ)"
		Me.lblDateLivraison.Size = New System.Drawing.Size(153, 17)
		Me.lblDateLivraison.Location = New System.Drawing.Point(440, 368)
		Me.lblDateLivraison.TabIndex = 55
		Me.lblDateLivraison.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDateLivraison.BackColor = System.Drawing.SystemColors.Control
		Me.lblDateLivraison.Enabled = True
		Me.lblDateLivraison.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDateLivraison.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDateLivraison.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDateLivraison.UseMnemonic = True
		Me.lblDateLivraison.Visible = True
		Me.lblDateLivraison.AutoSize = False
		Me.lblDateLivraison.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDateLivraison.Name = "lblDateLivraison"
		Me.lblTransport.Text = "Transport"
		Me.lblTransport.Size = New System.Drawing.Size(65, 17)
		Me.lblTransport.Location = New System.Drawing.Point(280, 368)
		Me.lblTransport.TabIndex = 54
		Me.lblTransport.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTransport.BackColor = System.Drawing.SystemColors.Control
		Me.lblTransport.Enabled = True
		Me.lblTransport.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTransport.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTransport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTransport.UseMnemonic = True
		Me.lblTransport.Visible = True
		Me.lblTransport.AutoSize = False
		Me.lblTransport.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTransport.Name = "lblTransport"
		Me.lblClient2.Text = "Client Expédié à"
		Me.lblClient2.Size = New System.Drawing.Size(105, 17)
		Me.lblClient2.Location = New System.Drawing.Point(280, 328)
		Me.lblClient2.TabIndex = 51
		Me.lblClient2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblClient2.BackColor = System.Drawing.SystemColors.Control
		Me.lblClient2.Enabled = True
		Me.lblClient2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblClient2.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblClient2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblClient2.UseMnemonic = True
		Me.lblClient2.Visible = True
		Me.lblClient2.AutoSize = False
		Me.lblClient2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblClient2.Name = "lblClient2"
		Me.lblClient.Text = "Client"
		Me.lblClient.Size = New System.Drawing.Size(41, 17)
		Me.lblClient.Location = New System.Drawing.Point(280, 0)
		Me.lblClient.TabIndex = 0
		Me.lblClient.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblClient.BackColor = System.Drawing.SystemColors.Control
		Me.lblClient.Enabled = True
		Me.lblClient.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblClient.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblClient.UseMnemonic = True
		Me.lblClient.Visible = True
		Me.lblClient.AutoSize = False
		Me.lblClient.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblClient.Name = "lblClient"
		Me.lblDate.Text = "Date (AA-MM-JJ)"
		Me.lblDate.Size = New System.Drawing.Size(105, 17)
		Me.lblDate.Location = New System.Drawing.Point(280, 208)
		Me.lblDate.TabIndex = 36
		Me.lblDate.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDate.BackColor = System.Drawing.SystemColors.Control
		Me.lblDate.Enabled = True
		Me.lblDate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDate.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDate.UseMnemonic = True
		Me.lblDate.Visible = True
		Me.lblDate.AutoSize = False
		Me.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDate.Name = "lblDate"
		Me.lblDateTravaux.Text = "Date travaux"
		Me.lblDateTravaux.Size = New System.Drawing.Size(81, 17)
		Me.lblDateTravaux.Location = New System.Drawing.Point(280, 288)
		Me.lblDateTravaux.TabIndex = 45
		Me.lblDateTravaux.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDateTravaux.BackColor = System.Drawing.SystemColors.Control
		Me.lblDateTravaux.Enabled = True
		Me.lblDateTravaux.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDateTravaux.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDateTravaux.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDateTravaux.UseMnemonic = True
		Me.lblDateTravaux.Visible = True
		Me.lblDateTravaux.AutoSize = False
		Me.lblDateTravaux.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDateTravaux.Name = "lblDateTravaux"
		Me.lblNomProjet.Text = "Nom Projet"
		Me.lblNomProjet.Size = New System.Drawing.Size(177, 17)
		Me.lblNomProjet.Location = New System.Drawing.Point(392, 168)
		Me.lblNomProjet.TabIndex = 33
		Me.lblNomProjet.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblNomProjet.BackColor = System.Drawing.SystemColors.Control
		Me.lblNomProjet.Enabled = True
		Me.lblNomProjet.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblNomProjet.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblNomProjet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblNomProjet.UseMnemonic = True
		Me.lblNomProjet.Visible = True
		Me.lblNomProjet.AutoSize = False
		Me.lblNomProjet.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblNomProjet.Name = "lblNomProjet"
		Me.lblDateCommande.Text = "Date Commande"
		Me.lblDateCommande.Size = New System.Drawing.Size(105, 17)
		Me.lblDateCommande.Location = New System.Drawing.Point(280, 248)
		Me.lblDateCommande.TabIndex = 40
		Me.lblDateCommande.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDateCommande.BackColor = System.Drawing.SystemColors.Control
		Me.lblDateCommande.Enabled = True
		Me.lblDateCommande.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDateCommande.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDateCommande.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDateCommande.UseMnemonic = True
		Me.lblDateCommande.Visible = True
		Me.lblDateCommande.AutoSize = False
		Me.lblDateCommande.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDateCommande.Name = "lblDateCommande"
		Me.lblNoCommande.Text = "No. Commande Client"
		Me.lblNoCommande.Size = New System.Drawing.Size(122, 17)
		Me.lblNoCommande.Location = New System.Drawing.Point(448, 248)
		Me.lblNoCommande.TabIndex = 41
		Me.lblNoCommande.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblNoCommande.BackColor = System.Drawing.SystemColors.Control
		Me.lblNoCommande.Enabled = True
		Me.lblNoCommande.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblNoCommande.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblNoCommande.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblNoCommande.UseMnemonic = True
		Me.lblNoCommande.Visible = True
		Me.lblNoCommande.AutoSize = False
		Me.lblNoCommande.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblNoCommande.Name = "lblNoCommande"
		Me.lblNoProjet.Text = "No. Projet"
		Me.lblNoProjet.Size = New System.Drawing.Size(81, 17)
		Me.lblNoProjet.Location = New System.Drawing.Point(280, 168)
		Me.lblNoProjet.TabIndex = 32
		Me.lblNoProjet.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblNoProjet.BackColor = System.Drawing.SystemColors.Control
		Me.lblNoProjet.Enabled = True
		Me.lblNoProjet.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblNoProjet.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblNoProjet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblNoProjet.UseMnemonic = True
		Me.lblNoProjet.Visible = True
		Me.lblNoProjet.AutoSize = False
		Me.lblNoProjet.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblNoProjet.Name = "lblNoProjet"
		Me.lblNoSoumission.Text = "No. Soumission"
		Me.lblNoSoumission.Size = New System.Drawing.Size(89, 17)
		Me.lblNoSoumission.Location = New System.Drawing.Point(280, 128)
		Me.lblNoSoumission.TabIndex = 28
		Me.lblNoSoumission.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblNoSoumission.BackColor = System.Drawing.SystemColors.Control
		Me.lblNoSoumission.Enabled = True
		Me.lblNoSoumission.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblNoSoumission.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblNoSoumission.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblNoSoumission.UseMnemonic = True
		Me.lblNoSoumission.Visible = True
		Me.lblNoSoumission.AutoSize = False
		Me.lblNoSoumission.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblNoSoumission.Name = "lblNoSoumission"
		Me.lblGRB.Text = "Représentant GRB"
		Me.lblGRB.Size = New System.Drawing.Size(113, 17)
		Me.lblGRB.Location = New System.Drawing.Point(280, 80)
		Me.lblGRB.TabIndex = 26
		Me.lblGRB.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblGRB.BackColor = System.Drawing.SystemColors.Control
		Me.lblGRB.Enabled = True
		Me.lblGRB.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblGRB.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblGRB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblGRB.UseMnemonic = True
		Me.lblGRB.Visible = True
		Me.lblGRB.AutoSize = False
		Me.lblGRB.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblGRB.Name = "lblGRB"
		Me.lblContact.Text = "Contact"
		Me.lblContact.Size = New System.Drawing.Size(49, 17)
		Me.lblContact.Location = New System.Drawing.Point(280, 40)
		Me.lblContact.TabIndex = 24
		Me.lblContact.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblContact.BackColor = System.Drawing.SystemColors.Control
		Me.lblContact.Enabled = True
		Me.lblContact.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblContact.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblContact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblContact.UseMnemonic = True
		Me.lblContact.Visible = True
		Me.lblContact.AutoSize = False
		Me.lblContact.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblContact.Name = "lblContact"
		Me.Controls.Add(cmbFournisseur2)
		Me.Controls.Add(cmdRechercherFRS2)
		Me.Controls.Add(fraChoixRapport)
		Me.Controls.Add(cmbContactFRS)
		Me.Controls.Add(cmdRechercherFRS)
		Me.Controls.Add(cmdRechercherClient2)
		Me.Controls.Add(cmdRechercherClient)
		Me.Controls.Add(mskDateTravaux)
		Me.Controls.Add(txtProjetClient)
		Me.Controls.Add(cmdReport)
		Me.Controls.Add(cmbFournisseur)
		Me.Controls.Add(mskDateLivraison)
		Me.Controls.Add(txtTransport)
		Me.Controls.Add(txtNomProjet)
		Me.Controls.Add(txtNoCommande)
		Me.Controls.Add(txtNoProjet)
		Me.Controls.Add(txtNoSoumission)
		Me.Controls.Add(cmdFermer)
		Me.Controls.Add(cmbGRB)
		Me.Controls.Add(cmbContact)
		Me.Controls.Add(cmbClient)
		Me.Controls.Add(cmbClient2)
		Me.Controls.Add(mskDateCommande)
		Me.Controls.Add(mskDate)
		Me.Controls.Add(mskHeureTravaux)
		Me.Controls.Add(mskDateDue)
		Me.Controls.Add(lblFournisseur2)
		Me.Controls.Add(lblDateDue)
		Me.Controls.Add(lblFormatHeurePrevue)
		Me.Controls.Add(lblFormatDateTravaux)
		Me.Controls.Add(lblFormatDateCommande)
		Me.Controls.Add(lblContactFRS)
		Me.Controls.Add(lblHeureTravaux)
		Me.Controls.Add(lblProjetClient)
		Me.Controls.Add(lblFournisseur)
		Me.Controls.Add(lblDateLivraison)
		Me.Controls.Add(lblTransport)
		Me.Controls.Add(lblClient2)
		Me.Controls.Add(lblClient)
		Me.Controls.Add(lblDate)
		Me.Controls.Add(lblDateTravaux)
		Me.Controls.Add(lblNomProjet)
		Me.Controls.Add(lblDateCommande)
		Me.Controls.Add(lblNoCommande)
		Me.Controls.Add(lblNoProjet)
		Me.Controls.Add(lblNoSoumission)
		Me.Controls.Add(lblGRB)
		Me.Controls.Add(lblContact)
		Me.fraChoixRapport.Controls.Add(txtMsg)
		Me.fraChoixRapport.Controls.Add(chkProblemes)
		Me.fraChoixRapport.Controls.Add(txtObjet)
		Me.fraChoixRapport.Controls.Add(cmdMsg)
		Me.fraChoixRapport.Controls.Add(txtDe)
		Me.fraChoixRapport.Controls.Add(txtPage)
		Me.fraChoixRapport.Controls.Add(chkFaxAnglais)
		Me.fraChoixRapport.Controls.Add(chkFaxFrancais)
		Me.fraChoixRapport.Controls.Add(chkBonLivraison)
		Me.fraChoixRapport.Controls.Add(cmdSelect)
		Me.fraChoixRapport.Controls.Add(ChkFinFab)
		Me.fraChoixRapport.Controls.Add(ChkFabFerm)
		Me.fraChoixRapport.Controls.Add(ChkFabFermMéca)
		Me.fraChoixRapport.Controls.Add(ChkProg)
		Me.fraChoixRapport.Controls.Add(ChkConcept)
		Me.fraChoixRapport.Controls.Add(ChkFourn)
		Me.fraChoixRapport.Controls.Add(ChkClient)
		Me.fraChoixRapport.Controls.Add(ChkBonTravail)
		Me.fraChoixRapport.Controls.Add(lblObjet)
		Me.fraChoixRapport.Controls.Add(lblDe)
		Me.fraChoixRapport.Controls.Add(lblPage)
		Me.fraChoixRapport.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class