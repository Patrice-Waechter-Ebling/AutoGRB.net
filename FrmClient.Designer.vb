<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FrmClient
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
	Public WithEvents lblEtatOutlook As System.Windows.Forms.Label
	Public WithEvents fraEtatOutlook As System.Windows.Forms.Panel
	Public WithEvents txtCategorie As System.Windows.Forms.TextBox
	Public WithEvents cmdMailListClient As System.Windows.Forms.Button
	Public WithEvents txtEmail As System.Windows.Forms.TextBox
	Public WithEvents cmdFax As System.Windows.Forms.Button
	Public WithEvents txtSiteWeb As System.Windows.Forms.TextBox
	Public WithEvents txtNomClient As System.Windows.Forms.TextBox
	Public WithEvents cmdRechercher As System.Windows.Forms.Button
	Public WithEvents cmdRafraichir As System.Windows.Forms.Button
	Public WithEvents TxtRechercher As System.Windows.Forms.TextBox
	Public WithEvents cmdMailListContact As System.Windows.Forms.Button
	Public WithEvents txtContactTitre As System.Windows.Forms.TextBox
	Public WithEvents CmdAddCont As System.Windows.Forms.Button
	Public WithEvents txtcontact_dom As System.Windows.Forms.TextBox
	Public WithEvents cmdsupcontact As System.Windows.Forms.Button
	Public WithEvents txtcontact_cell As System.Windows.Forms.TextBox
	Public WithEvents txtcontact_fax As System.Windows.Forms.TextBox
	Public WithEvents CmdRefCont As System.Windows.Forms.Button
	Public WithEvents cmbcontact As System.Windows.Forms.ComboBox
	Public WithEvents txtcontact_tel As System.Windows.Forms.TextBox
	Public WithEvents txtcontact_poste As System.Windows.Forms.TextBox
	Public WithEvents txtcontact_email As System.Windows.Forms.TextBox
	Public WithEvents txtcontact_page As System.Windows.Forms.TextBox
	Public WithEvents cmdanulcontact As System.Windows.Forms.Button
	Public WithEvents txtContact As System.Windows.Forms.TextBox
	Public WithEvents mskContactPage As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskContactFax As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskContactCell As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskContactDom As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskContactTel As System.Windows.Forms.MaskedTextBox
	Public WithEvents _Label1_8 As System.Windows.Forms.Label
	Public WithEvents _Label1_6 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_3 As System.Windows.Forms.Label
	Public WithEvents _Label1_4 As System.Windows.Forms.Label
	Public WithEvents _Label1_5 As System.Windows.Forms.Label
	Public WithEvents _Label1_7 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents fraContact As System.Windows.Forms.GroupBox
	Public WithEvents cmdreport As System.Windows.Forms.Button
	Public WithEvents cmdRenommer As System.Windows.Forms.Button
	Public WithEvents CmdAdd As System.Windows.Forms.Button
	Public WithEvents CmdSupp As System.Windows.Forms.Button
	Public WithEvents CmdQuit As System.Windows.Forms.Button
	Public WithEvents CmdEnr As System.Windows.Forms.Button
	Public WithEvents CmdAnul As System.Windows.Forms.Button
	Public WithEvents CmdModif As System.Windows.Forms.Button
	Public WithEvents txtPays As System.Windows.Forms.TextBox
	Public WithEvents txtCP As System.Windows.Forms.TextBox
	Public WithEvents txtProvEtat As System.Windows.Forms.TextBox
	Public WithEvents txtVille As System.Windows.Forms.TextBox
	Public WithEvents txtAdresse As System.Windows.Forms.TextBox
	Public WithEvents txtCommentaire As System.Windows.Forms.TextBox
	Public WithEvents txtContactGRB As System.Windows.Forms.TextBox
	Public WithEvents txtFax As System.Windows.Forms.TextBox
	Public WithEvents txtTelephone As System.Windows.Forms.TextBox
	Public WithEvents cmbClient As System.Windows.Forms.ComboBox
	Public WithEvents mskTelephone As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskFax As System.Windows.Forms.MaskedTextBox
	Public WithEvents cmdCategorie As System.Windows.Forms.Button
	Public WithEvents chkClientPotentiel As System.Windows.Forms.CheckBox
	Public WithEvents fraPotentiel As System.Windows.Forms.Panel
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents _Label12_2 As System.Windows.Forms.Label
	Public WithEvents _Label12_3 As System.Windows.Forms.Label
	Public WithEvents lblDateCreation As System.Windows.Forms.Label
	Public WithEvents lblDateModification As System.Windows.Forms.Label
	Public WithEvents lblUserCreation As System.Windows.Forms.Label
	Public WithEvents lblUserModification As System.Windows.Forms.Label
	Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label17 As System.Windows.Forms.Label
	Public WithEvents Shape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents _Label12_0 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Label12 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmClient))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.fraEtatOutlook = New System.Windows.Forms.Panel
		Me.lblEtatOutlook = New System.Windows.Forms.Label
		Me.txtCategorie = New System.Windows.Forms.TextBox
		Me.cmdMailListClient = New System.Windows.Forms.Button
		Me.txtEmail = New System.Windows.Forms.TextBox
		Me.cmdFax = New System.Windows.Forms.Button
		Me.txtSiteWeb = New System.Windows.Forms.TextBox
		Me.txtNomClient = New System.Windows.Forms.TextBox
		Me.cmdRechercher = New System.Windows.Forms.Button
		Me.cmdRafraichir = New System.Windows.Forms.Button
		Me.TxtRechercher = New System.Windows.Forms.TextBox
		Me.fraContact = New System.Windows.Forms.GroupBox
		Me.cmdMailListContact = New System.Windows.Forms.Button
		Me.txtContactTitre = New System.Windows.Forms.TextBox
		Me.CmdAddCont = New System.Windows.Forms.Button
		Me.txtcontact_dom = New System.Windows.Forms.TextBox
		Me.cmdsupcontact = New System.Windows.Forms.Button
		Me.txtcontact_cell = New System.Windows.Forms.TextBox
		Me.txtcontact_fax = New System.Windows.Forms.TextBox
		Me.CmdRefCont = New System.Windows.Forms.Button
		Me.cmbcontact = New System.Windows.Forms.ComboBox
		Me.txtcontact_tel = New System.Windows.Forms.TextBox
		Me.txtcontact_poste = New System.Windows.Forms.TextBox
		Me.txtcontact_email = New System.Windows.Forms.TextBox
		Me.txtcontact_page = New System.Windows.Forms.TextBox
		Me.cmdanulcontact = New System.Windows.Forms.Button
		Me.txtContact = New System.Windows.Forms.TextBox
		Me.mskContactPage = New System.Windows.Forms.MaskedTextBox
		Me.mskContactFax = New System.Windows.Forms.MaskedTextBox
		Me.mskContactCell = New System.Windows.Forms.MaskedTextBox
		Me.mskContactDom = New System.Windows.Forms.MaskedTextBox
		Me.mskContactTel = New System.Windows.Forms.MaskedTextBox
		Me._Label1_8 = New System.Windows.Forms.Label
		Me._Label1_6 = New System.Windows.Forms.Label
		Me._Label1_1 = New System.Windows.Forms.Label
		Me._Label1_2 = New System.Windows.Forms.Label
		Me._Label1_3 = New System.Windows.Forms.Label
		Me._Label1_4 = New System.Windows.Forms.Label
		Me._Label1_5 = New System.Windows.Forms.Label
		Me._Label1_7 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.cmdreport = New System.Windows.Forms.Button
		Me.cmdRenommer = New System.Windows.Forms.Button
		Me.CmdAdd = New System.Windows.Forms.Button
		Me.CmdSupp = New System.Windows.Forms.Button
		Me.CmdQuit = New System.Windows.Forms.Button
		Me.CmdEnr = New System.Windows.Forms.Button
		Me.CmdAnul = New System.Windows.Forms.Button
		Me.CmdModif = New System.Windows.Forms.Button
		Me.txtPays = New System.Windows.Forms.TextBox
		Me.txtCP = New System.Windows.Forms.TextBox
		Me.txtProvEtat = New System.Windows.Forms.TextBox
		Me.txtVille = New System.Windows.Forms.TextBox
		Me.txtAdresse = New System.Windows.Forms.TextBox
		Me.txtCommentaire = New System.Windows.Forms.TextBox
		Me.txtContactGRB = New System.Windows.Forms.TextBox
		Me.txtFax = New System.Windows.Forms.TextBox
		Me.txtTelephone = New System.Windows.Forms.TextBox
		Me.cmbClient = New System.Windows.Forms.ComboBox
		Me.mskTelephone = New System.Windows.Forms.MaskedTextBox
		Me.mskFax = New System.Windows.Forms.MaskedTextBox
		Me.cmdCategorie = New System.Windows.Forms.Button
		Me.fraPotentiel = New System.Windows.Forms.Panel
		Me.chkClientPotentiel = New System.Windows.Forms.CheckBox
		Me.Label6 = New System.Windows.Forms.Label
		Me._Label12_2 = New System.Windows.Forms.Label
		Me._Label12_3 = New System.Windows.Forms.Label
		Me.lblDateCreation = New System.Windows.Forms.Label
		Me.lblDateModification = New System.Windows.Forms.Label
		Me.lblUserCreation = New System.Windows.Forms.Label
		Me.lblUserModification = New System.Windows.Forms.Label
		Me.Label15 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label17 = New System.Windows.Forms.Label
		Me.Shape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label14 = New System.Windows.Forms.Label
		Me.Label13 = New System.Windows.Forms.Label
		Me._Label12_0 = New System.Windows.Forms.Label
		Me.Label11 = New System.Windows.Forms.Label
		Me.Label10 = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me._Label1_0 = New System.Windows.Forms.Label
		Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Label12 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.fraEtatOutlook.SuspendLayout()
		Me.fraContact.SuspendLayout()
		Me.fraPotentiel.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Clients"
		Me.ClientSize = New System.Drawing.Size(616, 559)
		Me.Location = New System.Drawing.Point(144, 68)
		Me.Icon = CType(resources.GetObject("FrmClient.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("FrmClient.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "FrmClient"
		Me.fraEtatOutlook.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.fraEtatOutlook.Size = New System.Drawing.Size(505, 145)
		Me.fraEtatOutlook.Location = New System.Drawing.Point(48, 192)
		Me.fraEtatOutlook.TabIndex = 16
		Me.fraEtatOutlook.Visible = False
		Me.fraEtatOutlook.BackColor = System.Drawing.SystemColors.Control
		Me.fraEtatOutlook.Enabled = True
		Me.fraEtatOutlook.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraEtatOutlook.Cursor = System.Windows.Forms.Cursors.Default
		Me.fraEtatOutlook.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraEtatOutlook.Name = "fraEtatOutlook"
		Me.lblEtatOutlook.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblEtatOutlook.Text = "Recherche du client dans Outlook ..."
		Me.lblEtatOutlook.Size = New System.Drawing.Size(433, 25)
		Me.lblEtatOutlook.Location = New System.Drawing.Point(16, 56)
		Me.lblEtatOutlook.TabIndex = 17
		Me.lblEtatOutlook.BackColor = System.Drawing.SystemColors.Control
		Me.lblEtatOutlook.Enabled = True
		Me.lblEtatOutlook.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblEtatOutlook.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblEtatOutlook.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblEtatOutlook.UseMnemonic = True
		Me.lblEtatOutlook.Visible = True
		Me.lblEtatOutlook.AutoSize = False
		Me.lblEtatOutlook.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblEtatOutlook.Name = "lblEtatOutlook"
		Me.txtCategorie.AutoSize = False
		Me.txtCategorie.BackColor = System.Drawing.Color.White
		Me.txtCategorie.Size = New System.Drawing.Size(257, 20)
		Me.txtCategorie.Location = New System.Drawing.Point(96, 152)
		Me.txtCategorie.ReadOnly = True
		Me.txtCategorie.TabIndex = 80
		Me.txtCategorie.AcceptsReturn = True
		Me.txtCategorie.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCategorie.CausesValidation = True
		Me.txtCategorie.Enabled = True
		Me.txtCategorie.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCategorie.HideSelection = True
		Me.txtCategorie.Maxlength = 0
		Me.txtCategorie.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCategorie.MultiLine = False
		Me.txtCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCategorie.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCategorie.TabStop = True
		Me.txtCategorie.Visible = True
		Me.txtCategorie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCategorie.Name = "txtCategorie"
		Me.cmdMailListClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMailListClient.Text = "Ajouter au mailing list"
		Me.cmdMailListClient.Size = New System.Drawing.Size(113, 33)
		Me.cmdMailListClient.Location = New System.Drawing.Point(416, 520)
		Me.cmdMailListClient.TabIndex = 77
		Me.cmdMailListClient.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMailListClient.CausesValidation = True
		Me.cmdMailListClient.Enabled = True
		Me.cmdMailListClient.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMailListClient.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMailListClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMailListClient.TabStop = True
		Me.cmdMailListClient.Name = "cmdMailListClient"
		Me.txtEmail.AutoSize = False
		Me.txtEmail.BackColor = System.Drawing.Color.White
		Me.txtEmail.Size = New System.Drawing.Size(129, 20)
		Me.txtEmail.Location = New System.Drawing.Point(96, 432)
		Me.txtEmail.ReadOnly = True
		Me.txtEmail.TabIndex = 33
		Me.txtEmail.Text = "Text1"
		Me.txtEmail.AcceptsReturn = True
		Me.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtEmail.CausesValidation = True
		Me.txtEmail.Enabled = True
		Me.txtEmail.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtEmail.HideSelection = True
		Me.txtEmail.Maxlength = 0
		Me.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtEmail.MultiLine = False
		Me.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtEmail.TabStop = True
		Me.txtEmail.Visible = True
		Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtEmail.Name = "txtEmail"
		Me.cmdFax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFax.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFax.Text = "Envoyer Fax"
		Me.cmdFax.Size = New System.Drawing.Size(73, 33)
		Me.cmdFax.Location = New System.Drawing.Point(336, 520)
		Me.cmdFax.TabIndex = 76
		Me.cmdFax.CausesValidation = True
		Me.cmdFax.Enabled = True
		Me.cmdFax.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFax.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFax.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFax.TabStop = True
		Me.cmdFax.Name = "cmdFax"
		Me.txtSiteWeb.AutoSize = False
		Me.txtSiteWeb.BackColor = System.Drawing.Color.White
		Me.txtSiteWeb.Size = New System.Drawing.Size(129, 20)
		Me.txtSiteWeb.Location = New System.Drawing.Point(96, 404)
		Me.txtSiteWeb.ReadOnly = True
		Me.txtSiteWeb.TabIndex = 31
		Me.txtSiteWeb.Text = "Text1"
		Me.txtSiteWeb.AcceptsReturn = True
		Me.txtSiteWeb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtSiteWeb.CausesValidation = True
		Me.txtSiteWeb.Enabled = True
		Me.txtSiteWeb.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSiteWeb.HideSelection = True
		Me.txtSiteWeb.Maxlength = 0
		Me.txtSiteWeb.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSiteWeb.MultiLine = False
		Me.txtSiteWeb.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSiteWeb.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtSiteWeb.TabStop = True
		Me.txtSiteWeb.Visible = True
		Me.txtSiteWeb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtSiteWeb.Name = "txtSiteWeb"
		Me.txtNomClient.AutoSize = False
		Me.txtNomClient.BackColor = System.Drawing.Color.White
		Me.txtNomClient.Size = New System.Drawing.Size(273, 19)
		Me.txtNomClient.Location = New System.Drawing.Point(96, 104)
		Me.txtNomClient.ReadOnly = True
		Me.txtNomClient.TabIndex = 8
		Me.txtNomClient.Visible = False
		Me.txtNomClient.AcceptsReturn = True
		Me.txtNomClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNomClient.CausesValidation = True
		Me.txtNomClient.Enabled = True
		Me.txtNomClient.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNomClient.HideSelection = True
		Me.txtNomClient.Maxlength = 0
		Me.txtNomClient.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNomClient.MultiLine = False
		Me.txtNomClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNomClient.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNomClient.TabStop = True
		Me.txtNomClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNomClient.Name = "txtNomClient"
		Me.cmdRechercher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRechercher.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercher.Text = "Rechercher"
		Me.AcceptButton = Me.cmdRechercher
		Me.cmdRechercher.Enabled = False
		Me.cmdRechercher.Size = New System.Drawing.Size(73, 25)
		Me.cmdRechercher.Location = New System.Drawing.Point(496, 40)
		Me.cmdRechercher.TabIndex = 2
		Me.cmdRechercher.CausesValidation = True
		Me.cmdRechercher.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercher.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercher.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercher.TabStop = True
		Me.cmdRechercher.Name = "cmdRechercher"
		Me.cmdRafraichir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRafraichir.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRafraichir.Text = "Rafraîchir"
		Me.cmdRafraichir.Size = New System.Drawing.Size(65, 17)
		Me.cmdRafraichir.Location = New System.Drawing.Point(104, 88)
		Me.cmdRafraichir.TabIndex = 3
		Me.cmdRafraichir.CausesValidation = True
		Me.cmdRafraichir.Enabled = True
		Me.cmdRafraichir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRafraichir.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRafraichir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRafraichir.TabStop = True
		Me.cmdRafraichir.Name = "cmdRafraichir"
		Me.TxtRechercher.AutoSize = False
		Me.TxtRechercher.BackColor = System.Drawing.Color.White
		Me.TxtRechercher.Size = New System.Drawing.Size(145, 29)
		Me.TxtRechercher.Location = New System.Drawing.Point(336, 40)
		Me.TxtRechercher.TabIndex = 1
		Me.TxtRechercher.AcceptsReturn = True
		Me.TxtRechercher.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtRechercher.CausesValidation = True
		Me.TxtRechercher.Enabled = True
		Me.TxtRechercher.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtRechercher.HideSelection = True
		Me.TxtRechercher.ReadOnly = False
		Me.TxtRechercher.Maxlength = 0
		Me.TxtRechercher.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtRechercher.MultiLine = False
		Me.TxtRechercher.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtRechercher.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtRechercher.TabStop = True
		Me.TxtRechercher.Visible = True
		Me.TxtRechercher.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtRechercher.Name = "TxtRechercher"
		Me.fraContact.BackColor = System.Drawing.Color.Black
		Me.fraContact.Text = "Contact"
		Me.fraContact.ForeColor = System.Drawing.Color.White
		Me.fraContact.Size = New System.Drawing.Size(297, 305)
		Me.fraContact.Location = New System.Drawing.Point(312, 184)
		Me.fraContact.TabIndex = 37
		Me.fraContact.Enabled = True
		Me.fraContact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraContact.Visible = True
		Me.fraContact.Padding = New System.Windows.Forms.Padding(0)
		Me.fraContact.Name = "fraContact"
		Me.cmdMailListContact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMailListContact.Text = "Ajouter au mailing list"
		Me.cmdMailListContact.Size = New System.Drawing.Size(121, 33)
		Me.cmdMailListContact.Location = New System.Drawing.Point(168, 264)
		Me.cmdMailListContact.TabIndex = 66
		Me.cmdMailListContact.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMailListContact.CausesValidation = True
		Me.cmdMailListContact.Enabled = True
		Me.cmdMailListContact.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMailListContact.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMailListContact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMailListContact.TabStop = True
		Me.cmdMailListContact.Name = "cmdMailListContact"
		Me.txtContactTitre.AutoSize = False
		Me.txtContactTitre.BackColor = System.Drawing.Color.White
		Me.txtContactTitre.Size = New System.Drawing.Size(105, 20)
		Me.txtContactTitre.Location = New System.Drawing.Point(72, 64)
		Me.txtContactTitre.ReadOnly = True
		Me.txtContactTitre.TabIndex = 45
		Me.txtContactTitre.AcceptsReturn = True
		Me.txtContactTitre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtContactTitre.CausesValidation = True
		Me.txtContactTitre.Enabled = True
		Me.txtContactTitre.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtContactTitre.HideSelection = True
		Me.txtContactTitre.Maxlength = 0
		Me.txtContactTitre.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtContactTitre.MultiLine = False
		Me.txtContactTitre.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtContactTitre.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtContactTitre.TabStop = True
		Me.txtContactTitre.Visible = True
		Me.txtContactTitre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtContactTitre.Name = "txtContactTitre"
		Me.CmdAddCont.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdAddCont.Text = "Ajouter"
		Me.CmdAddCont.Size = New System.Drawing.Size(73, 33)
		Me.CmdAddCont.Location = New System.Drawing.Point(8, 264)
		Me.CmdAddCont.TabIndex = 62
		Me.CmdAddCont.BackColor = System.Drawing.SystemColors.Control
		Me.CmdAddCont.CausesValidation = True
		Me.CmdAddCont.Enabled = True
		Me.CmdAddCont.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdAddCont.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdAddCont.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdAddCont.TabStop = True
		Me.CmdAddCont.Name = "CmdAddCont"
		Me.txtcontact_dom.AutoSize = False
		Me.txtcontact_dom.BackColor = System.Drawing.Color.White
		Me.txtcontact_dom.Size = New System.Drawing.Size(105, 20)
		Me.txtcontact_dom.Location = New System.Drawing.Point(72, 112)
		Me.txtcontact_dom.ReadOnly = True
		Me.txtcontact_dom.TabIndex = 49
		Me.txtcontact_dom.AcceptsReturn = True
		Me.txtcontact_dom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtcontact_dom.CausesValidation = True
		Me.txtcontact_dom.Enabled = True
		Me.txtcontact_dom.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtcontact_dom.HideSelection = True
		Me.txtcontact_dom.Maxlength = 0
		Me.txtcontact_dom.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtcontact_dom.MultiLine = False
		Me.txtcontact_dom.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtcontact_dom.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtcontact_dom.TabStop = True
		Me.txtcontact_dom.Visible = True
		Me.txtcontact_dom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtcontact_dom.Name = "txtcontact_dom"
		Me.cmdsupcontact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdsupcontact.BackColor = System.Drawing.SystemColors.Control
		Me.cmdsupcontact.Text = "Supprimer"
		Me.cmdsupcontact.Size = New System.Drawing.Size(73, 33)
		Me.cmdsupcontact.Location = New System.Drawing.Point(88, 264)
		Me.cmdsupcontact.TabIndex = 65
		Me.cmdsupcontact.CausesValidation = True
		Me.cmdsupcontact.Enabled = True
		Me.cmdsupcontact.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdsupcontact.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdsupcontact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdsupcontact.TabStop = True
		Me.cmdsupcontact.Name = "cmdsupcontact"
		Me.txtcontact_cell.AutoSize = False
		Me.txtcontact_cell.BackColor = System.Drawing.Color.White
		Me.txtcontact_cell.Size = New System.Drawing.Size(105, 20)
		Me.txtcontact_cell.Location = New System.Drawing.Point(72, 160)
		Me.txtcontact_cell.ReadOnly = True
		Me.txtcontact_cell.TabIndex = 51
		Me.txtcontact_cell.AcceptsReturn = True
		Me.txtcontact_cell.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtcontact_cell.CausesValidation = True
		Me.txtcontact_cell.Enabled = True
		Me.txtcontact_cell.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtcontact_cell.HideSelection = True
		Me.txtcontact_cell.Maxlength = 0
		Me.txtcontact_cell.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtcontact_cell.MultiLine = False
		Me.txtcontact_cell.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtcontact_cell.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtcontact_cell.TabStop = True
		Me.txtcontact_cell.Visible = True
		Me.txtcontact_cell.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtcontact_cell.Name = "txtcontact_cell"
		Me.txtcontact_fax.AutoSize = False
		Me.txtcontact_fax.BackColor = System.Drawing.Color.White
		Me.txtcontact_fax.Size = New System.Drawing.Size(105, 20)
		Me.txtcontact_fax.Location = New System.Drawing.Point(72, 184)
		Me.txtcontact_fax.ReadOnly = True
		Me.txtcontact_fax.TabIndex = 55
		Me.txtcontact_fax.AcceptsReturn = True
		Me.txtcontact_fax.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtcontact_fax.CausesValidation = True
		Me.txtcontact_fax.Enabled = True
		Me.txtcontact_fax.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtcontact_fax.HideSelection = True
		Me.txtcontact_fax.Maxlength = 0
		Me.txtcontact_fax.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtcontact_fax.MultiLine = False
		Me.txtcontact_fax.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtcontact_fax.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtcontact_fax.TabStop = True
		Me.txtcontact_fax.Visible = True
		Me.txtcontact_fax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtcontact_fax.Name = "txtcontact_fax"
		Me.CmdRefCont.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdRefCont.Text = "Enregistrer"
		Me.CmdRefCont.Size = New System.Drawing.Size(73, 33)
		Me.CmdRefCont.Location = New System.Drawing.Point(8, 264)
		Me.CmdRefCont.TabIndex = 63
		Me.CmdRefCont.BackColor = System.Drawing.SystemColors.Control
		Me.CmdRefCont.CausesValidation = True
		Me.CmdRefCont.Enabled = True
		Me.CmdRefCont.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdRefCont.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdRefCont.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdRefCont.TabStop = True
		Me.CmdRefCont.Name = "CmdRefCont"
		Me.cmbcontact.BackColor = System.Drawing.Color.White
		Me.cmbcontact.Size = New System.Drawing.Size(217, 21)
		Me.cmbcontact.Location = New System.Drawing.Point(72, 24)
		Me.cmbcontact.TabIndex = 40
		Me.cmbcontact.CausesValidation = True
		Me.cmbcontact.Enabled = True
		Me.cmbcontact.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbcontact.IntegralHeight = True
		Me.cmbcontact.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbcontact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbcontact.Sorted = False
		Me.cmbcontact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbcontact.TabStop = True
		Me.cmbcontact.Visible = True
		Me.cmbcontact.Name = "cmbcontact"
		Me.txtcontact_tel.AutoSize = False
		Me.txtcontact_tel.BackColor = System.Drawing.Color.White
		Me.txtcontact_tel.Size = New System.Drawing.Size(105, 20)
		Me.txtcontact_tel.Location = New System.Drawing.Point(72, 88)
		Me.txtcontact_tel.ReadOnly = True
		Me.txtcontact_tel.TabIndex = 46
		Me.txtcontact_tel.AcceptsReturn = True
		Me.txtcontact_tel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtcontact_tel.CausesValidation = True
		Me.txtcontact_tel.Enabled = True
		Me.txtcontact_tel.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtcontact_tel.HideSelection = True
		Me.txtcontact_tel.Maxlength = 0
		Me.txtcontact_tel.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtcontact_tel.MultiLine = False
		Me.txtcontact_tel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtcontact_tel.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtcontact_tel.TabStop = True
		Me.txtcontact_tel.Visible = True
		Me.txtcontact_tel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtcontact_tel.Name = "txtcontact_tel"
		Me.txtcontact_poste.AutoSize = False
		Me.txtcontact_poste.BackColor = System.Drawing.Color.White
		Me.txtcontact_poste.Size = New System.Drawing.Size(49, 20)
		Me.txtcontact_poste.Location = New System.Drawing.Point(72, 136)
		Me.txtcontact_poste.ReadOnly = True
		Me.txtcontact_poste.TabIndex = 50
		Me.txtcontact_poste.AcceptsReturn = True
		Me.txtcontact_poste.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtcontact_poste.CausesValidation = True
		Me.txtcontact_poste.Enabled = True
		Me.txtcontact_poste.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtcontact_poste.HideSelection = True
		Me.txtcontact_poste.Maxlength = 0
		Me.txtcontact_poste.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtcontact_poste.MultiLine = False
		Me.txtcontact_poste.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtcontact_poste.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtcontact_poste.TabStop = True
		Me.txtcontact_poste.Visible = True
		Me.txtcontact_poste.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtcontact_poste.Name = "txtcontact_poste"
		Me.txtcontact_email.AutoSize = False
		Me.txtcontact_email.BackColor = System.Drawing.Color.White
		Me.txtcontact_email.Size = New System.Drawing.Size(217, 20)
		Me.txtcontact_email.Location = New System.Drawing.Point(72, 232)
		Me.txtcontact_email.ReadOnly = True
		Me.txtcontact_email.TabIndex = 60
		Me.txtcontact_email.AcceptsReturn = True
		Me.txtcontact_email.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtcontact_email.CausesValidation = True
		Me.txtcontact_email.Enabled = True
		Me.txtcontact_email.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtcontact_email.HideSelection = True
		Me.txtcontact_email.Maxlength = 0
		Me.txtcontact_email.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtcontact_email.MultiLine = False
		Me.txtcontact_email.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtcontact_email.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtcontact_email.TabStop = True
		Me.txtcontact_email.Visible = True
		Me.txtcontact_email.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtcontact_email.Name = "txtcontact_email"
		Me.txtcontact_page.AutoSize = False
		Me.txtcontact_page.BackColor = System.Drawing.Color.White
		Me.txtcontact_page.Size = New System.Drawing.Size(105, 20)
		Me.txtcontact_page.Location = New System.Drawing.Point(72, 208)
		Me.txtcontact_page.ReadOnly = True
		Me.txtcontact_page.TabIndex = 57
		Me.txtcontact_page.AcceptsReturn = True
		Me.txtcontact_page.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtcontact_page.CausesValidation = True
		Me.txtcontact_page.Enabled = True
		Me.txtcontact_page.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtcontact_page.HideSelection = True
		Me.txtcontact_page.Maxlength = 0
		Me.txtcontact_page.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtcontact_page.MultiLine = False
		Me.txtcontact_page.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtcontact_page.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtcontact_page.TabStop = True
		Me.txtcontact_page.Visible = True
		Me.txtcontact_page.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtcontact_page.Name = "txtcontact_page"
		Me.cmdanulcontact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdanulcontact.BackColor = System.Drawing.SystemColors.Control
		Me.cmdanulcontact.Text = "A&nnuler"
		Me.cmdanulcontact.Size = New System.Drawing.Size(73, 33)
		Me.cmdanulcontact.Location = New System.Drawing.Point(88, 264)
		Me.cmdanulcontact.TabIndex = 64
		Me.cmdanulcontact.CausesValidation = True
		Me.cmdanulcontact.Enabled = True
		Me.cmdanulcontact.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdanulcontact.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdanulcontact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdanulcontact.TabStop = True
		Me.cmdanulcontact.Name = "cmdanulcontact"
		Me.txtContact.AutoSize = False
		Me.txtContact.BackColor = System.Drawing.Color.White
		Me.txtContact.Size = New System.Drawing.Size(217, 19)
		Me.txtContact.Location = New System.Drawing.Point(72, 24)
		Me.txtContact.ReadOnly = True
		Me.txtContact.TabIndex = 39
		Me.txtContact.Visible = False
		Me.txtContact.AcceptsReturn = True
		Me.txtContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtContact.CausesValidation = True
		Me.txtContact.Enabled = True
		Me.txtContact.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtContact.HideSelection = True
		Me.txtContact.Maxlength = 0
		Me.txtContact.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtContact.MultiLine = False
		Me.txtContact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtContact.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtContact.TabStop = True
		Me.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtContact.Name = "txtContact"
		Me.mskContactPage.AllowPromptAsInput = False
		Me.mskContactPage.Size = New System.Drawing.Size(105, 19)
		Me.mskContactPage.Location = New System.Drawing.Point(72, 208)
		Me.mskContactPage.TabIndex = 58
		Me.mskContactPage.Visible = False
		Me.mskContactPage.PromptChar = "_"
		Me.mskContactPage.Name = "mskContactPage"
		Me.mskContactFax.AllowPromptAsInput = False
		Me.mskContactFax.Size = New System.Drawing.Size(105, 19)
		Me.mskContactFax.Location = New System.Drawing.Point(72, 184)
		Me.mskContactFax.TabIndex = 54
		Me.mskContactFax.Visible = False
		Me.mskContactFax.PromptChar = "_"
		Me.mskContactFax.Name = "mskContactFax"
		Me.mskContactCell.AllowPromptAsInput = False
		Me.mskContactCell.Size = New System.Drawing.Size(105, 19)
		Me.mskContactCell.Location = New System.Drawing.Point(72, 160)
		Me.mskContactCell.TabIndex = 53
		Me.mskContactCell.Visible = False
		Me.mskContactCell.PromptChar = "_"
		Me.mskContactCell.Name = "mskContactCell"
		Me.mskContactDom.AllowPromptAsInput = False
		Me.mskContactDom.Size = New System.Drawing.Size(105, 19)
		Me.mskContactDom.Location = New System.Drawing.Point(72, 112)
		Me.mskContactDom.TabIndex = 48
		Me.mskContactDom.Visible = False
		Me.mskContactDom.PromptChar = "_"
		Me.mskContactDom.Name = "mskContactDom"
		Me.mskContactTel.AllowPromptAsInput = False
		Me.mskContactTel.Size = New System.Drawing.Size(105, 19)
		Me.mskContactTel.Location = New System.Drawing.Point(72, 88)
		Me.mskContactTel.TabIndex = 47
		Me.mskContactTel.Visible = False
		Me.mskContactTel.PromptChar = "_"
		Me.mskContactTel.Name = "mskContactTel"
		Me._Label1_8.Text = "Titre "
		Me._Label1_8.ForeColor = System.Drawing.Color.White
		Me._Label1_8.Size = New System.Drawing.Size(73, 17)
		Me._Label1_8.Location = New System.Drawing.Point(8, 64)
		Me._Label1_8.TabIndex = 44
		Me._Label1_8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_8.BackColor = System.Drawing.Color.Transparent
		Me._Label1_8.Enabled = True
		Me._Label1_8.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_8.UseMnemonic = True
		Me._Label1_8.Visible = True
		Me._Label1_8.AutoSize = False
		Me._Label1_8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_8.Name = "_Label1_8"
		Me._Label1_6.Text = "Domicile"
		Me._Label1_6.ForeColor = System.Drawing.Color.White
		Me._Label1_6.Size = New System.Drawing.Size(73, 17)
		Me._Label1_6.Location = New System.Drawing.Point(8, 112)
		Me._Label1_6.TabIndex = 42
		Me._Label1_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_6.BackColor = System.Drawing.Color.Transparent
		Me._Label1_6.Enabled = True
		Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_6.UseMnemonic = True
		Me._Label1_6.Visible = True
		Me._Label1_6.AutoSize = False
		Me._Label1_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_6.Name = "_Label1_6"
		Me._Label1_1.Text = "Telephone"
		Me._Label1_1.ForeColor = System.Drawing.Color.White
		Me._Label1_1.Size = New System.Drawing.Size(73, 17)
		Me._Label1_1.Location = New System.Drawing.Point(8, 88)
		Me._Label1_1.TabIndex = 41
		Me._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_1.BackColor = System.Drawing.Color.Transparent
		Me._Label1_1.Enabled = True
		Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_1.UseMnemonic = True
		Me._Label1_1.Visible = True
		Me._Label1_1.AutoSize = False
		Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_1.Name = "_Label1_1"
		Me._Label1_2.Text = "Cellulaire"
		Me._Label1_2.ForeColor = System.Drawing.Color.White
		Me._Label1_2.Size = New System.Drawing.Size(65, 17)
		Me._Label1_2.Location = New System.Drawing.Point(8, 160)
		Me._Label1_2.TabIndex = 52
		Me._Label1_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_2.BackColor = System.Drawing.Color.Transparent
		Me._Label1_2.Enabled = True
		Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_2.UseMnemonic = True
		Me._Label1_2.Visible = True
		Me._Label1_2.AutoSize = False
		Me._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_2.Name = "_Label1_2"
		Me._Label1_3.Text = "Fax"
		Me._Label1_3.ForeColor = System.Drawing.Color.White
		Me._Label1_3.Size = New System.Drawing.Size(65, 17)
		Me._Label1_3.Location = New System.Drawing.Point(8, 184)
		Me._Label1_3.TabIndex = 56
		Me._Label1_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_3.BackColor = System.Drawing.Color.Transparent
		Me._Label1_3.Enabled = True
		Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_3.UseMnemonic = True
		Me._Label1_3.Visible = True
		Me._Label1_3.AutoSize = False
		Me._Label1_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_3.Name = "_Label1_3"
		Me._Label1_4.Text = "Pagette"
		Me._Label1_4.ForeColor = System.Drawing.Color.White
		Me._Label1_4.Size = New System.Drawing.Size(65, 17)
		Me._Label1_4.Location = New System.Drawing.Point(8, 208)
		Me._Label1_4.TabIndex = 59
		Me._Label1_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_4.BackColor = System.Drawing.Color.Transparent
		Me._Label1_4.Enabled = True
		Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_4.UseMnemonic = True
		Me._Label1_4.Visible = True
		Me._Label1_4.AutoSize = False
		Me._Label1_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_4.Name = "_Label1_4"
		Me._Label1_5.Text = "E-Mail"
		Me._Label1_5.ForeColor = System.Drawing.Color.White
		Me._Label1_5.Size = New System.Drawing.Size(65, 17)
		Me._Label1_5.Location = New System.Drawing.Point(8, 232)
		Me._Label1_5.TabIndex = 61
		Me._Label1_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_5.BackColor = System.Drawing.Color.Transparent
		Me._Label1_5.Enabled = True
		Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_5.UseMnemonic = True
		Me._Label1_5.Visible = True
		Me._Label1_5.AutoSize = False
		Me._Label1_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_5.Name = "_Label1_5"
		Me._Label1_7.Text = "Poste"
		Me._Label1_7.ForeColor = System.Drawing.Color.White
		Me._Label1_7.Size = New System.Drawing.Size(73, 17)
		Me._Label1_7.Location = New System.Drawing.Point(8, 136)
		Me._Label1_7.TabIndex = 43
		Me._Label1_7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_7.BackColor = System.Drawing.Color.Transparent
		Me._Label1_7.Enabled = True
		Me._Label1_7.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_7.UseMnemonic = True
		Me._Label1_7.Visible = True
		Me._Label1_7.AutoSize = False
		Me._Label1_7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_7.Name = "_Label1_7"
		Me.Label5.Text = "Contact"
		Me.Label5.ForeColor = System.Drawing.Color.White
		Me.Label5.Size = New System.Drawing.Size(57, 17)
		Me.Label5.Location = New System.Drawing.Point(8, 24)
		Me.Label5.TabIndex = 38
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.Color.Transparent
		Me.Label5.Enabled = True
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.cmdreport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdreport.BackColor = System.Drawing.SystemColors.Control
		Me.cmdreport.Text = "&Impression"
		Me.cmdreport.Size = New System.Drawing.Size(73, 33)
		Me.cmdreport.Location = New System.Drawing.Point(8, 520)
		Me.cmdreport.TabIndex = 70
		Me.cmdreport.CausesValidation = True
		Me.cmdreport.Enabled = True
		Me.cmdreport.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdreport.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdreport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdreport.TabStop = True
		Me.cmdreport.Name = "cmdreport"
		Me.cmdRenommer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRenommer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRenommer.Text = "Renommer"
		Me.cmdRenommer.Size = New System.Drawing.Size(65, 17)
		Me.cmdRenommer.Location = New System.Drawing.Point(168, 88)
		Me.cmdRenommer.TabIndex = 4
		Me.cmdRenommer.CausesValidation = True
		Me.cmdRenommer.Enabled = True
		Me.cmdRenommer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRenommer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRenommer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRenommer.TabStop = True
		Me.cmdRenommer.Name = "cmdRenommer"
		Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdAdd.BackColor = System.Drawing.SystemColors.Control
		Me.CmdAdd.Text = "&Ajouter"
		Me.CmdAdd.Size = New System.Drawing.Size(73, 33)
		Me.CmdAdd.Location = New System.Drawing.Point(96, 520)
		Me.CmdAdd.TabIndex = 71
		Me.CmdAdd.CausesValidation = True
		Me.CmdAdd.Enabled = True
		Me.CmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdAdd.TabStop = True
		Me.CmdAdd.Name = "CmdAdd"
		Me.CmdSupp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdSupp.BackColor = System.Drawing.SystemColors.Control
		Me.CmdSupp.Text = "&Supprimer"
		Me.CmdSupp.Size = New System.Drawing.Size(73, 33)
		Me.CmdSupp.Location = New System.Drawing.Point(176, 520)
		Me.CmdSupp.TabIndex = 74
		Me.CmdSupp.CausesValidation = True
		Me.CmdSupp.Enabled = True
		Me.CmdSupp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdSupp.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdSupp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdSupp.TabStop = True
		Me.CmdSupp.Name = "CmdSupp"
		Me.CmdQuit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdQuit.BackColor = System.Drawing.SystemColors.Control
		Me.CmdQuit.Text = "&Fermer"
		Me.CmdQuit.Size = New System.Drawing.Size(73, 33)
		Me.CmdQuit.Location = New System.Drawing.Point(536, 520)
		Me.CmdQuit.TabIndex = 78
		Me.CmdQuit.CausesValidation = True
		Me.CmdQuit.Enabled = True
		Me.CmdQuit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdQuit.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdQuit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdQuit.TabStop = True
		Me.CmdQuit.Name = "CmdQuit"
		Me.CmdEnr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdEnr.Text = "Enregistrer"
		Me.CmdEnr.Size = New System.Drawing.Size(73, 33)
		Me.CmdEnr.Location = New System.Drawing.Point(96, 520)
		Me.CmdEnr.TabIndex = 72
		Me.CmdEnr.BackColor = System.Drawing.SystemColors.Control
		Me.CmdEnr.CausesValidation = True
		Me.CmdEnr.Enabled = True
		Me.CmdEnr.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdEnr.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdEnr.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdEnr.TabStop = True
		Me.CmdEnr.Name = "CmdEnr"
		Me.CmdAnul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdAnul.Text = "A&nnuler"
		Me.CmdAnul.Size = New System.Drawing.Size(73, 33)
		Me.CmdAnul.Location = New System.Drawing.Point(176, 520)
		Me.CmdAnul.TabIndex = 73
		Me.CmdAnul.BackColor = System.Drawing.SystemColors.Control
		Me.CmdAnul.CausesValidation = True
		Me.CmdAnul.Enabled = True
		Me.CmdAnul.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdAnul.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdAnul.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdAnul.TabStop = True
		Me.CmdAnul.Name = "CmdAnul"
		Me.CmdModif.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdModif.BackColor = System.Drawing.SystemColors.Control
		Me.CmdModif.Text = "&Modifier"
		Me.CmdModif.Size = New System.Drawing.Size(73, 33)
		Me.CmdModif.Location = New System.Drawing.Point(256, 520)
		Me.CmdModif.TabIndex = 75
		Me.CmdModif.CausesValidation = True
		Me.CmdModif.Enabled = True
		Me.CmdModif.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdModif.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdModif.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdModif.TabStop = True
		Me.CmdModif.Name = "CmdModif"
		Me.txtPays.AutoSize = False
		Me.txtPays.BackColor = System.Drawing.Color.White
		Me.txtPays.Size = New System.Drawing.Size(129, 20)
		Me.txtPays.Location = New System.Drawing.Point(96, 348)
		Me.txtPays.ReadOnly = True
		Me.txtPays.TabIndex = 27
		Me.txtPays.Text = "Text1"
		Me.txtPays.AcceptsReturn = True
		Me.txtPays.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPays.CausesValidation = True
		Me.txtPays.Enabled = True
		Me.txtPays.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPays.HideSelection = True
		Me.txtPays.Maxlength = 0
		Me.txtPays.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPays.MultiLine = False
		Me.txtPays.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPays.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPays.TabStop = True
		Me.txtPays.Visible = True
		Me.txtPays.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPays.Name = "txtPays"
		Me.txtCP.AutoSize = False
		Me.txtCP.BackColor = System.Drawing.Color.White
		Me.txtCP.Size = New System.Drawing.Size(129, 20)
		Me.txtCP.Location = New System.Drawing.Point(96, 376)
		Me.txtCP.ReadOnly = True
		Me.txtCP.TabIndex = 29
		Me.txtCP.Text = "Text1"
		Me.txtCP.AcceptsReturn = True
		Me.txtCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCP.CausesValidation = True
		Me.txtCP.Enabled = True
		Me.txtCP.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCP.HideSelection = True
		Me.txtCP.Maxlength = 0
		Me.txtCP.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCP.MultiLine = False
		Me.txtCP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCP.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCP.TabStop = True
		Me.txtCP.Visible = True
		Me.txtCP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCP.Name = "txtCP"
		Me.txtProvEtat.AutoSize = False
		Me.txtProvEtat.BackColor = System.Drawing.Color.White
		Me.txtProvEtat.Size = New System.Drawing.Size(129, 20)
		Me.txtProvEtat.Location = New System.Drawing.Point(96, 320)
		Me.txtProvEtat.ReadOnly = True
		Me.txtProvEtat.TabIndex = 25
		Me.txtProvEtat.Text = "Text1"
		Me.txtProvEtat.AcceptsReturn = True
		Me.txtProvEtat.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtProvEtat.CausesValidation = True
		Me.txtProvEtat.Enabled = True
		Me.txtProvEtat.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtProvEtat.HideSelection = True
		Me.txtProvEtat.Maxlength = 0
		Me.txtProvEtat.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtProvEtat.MultiLine = False
		Me.txtProvEtat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtProvEtat.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtProvEtat.TabStop = True
		Me.txtProvEtat.Visible = True
		Me.txtProvEtat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtProvEtat.Name = "txtProvEtat"
		Me.txtVille.AutoSize = False
		Me.txtVille.BackColor = System.Drawing.Color.White
		Me.txtVille.Size = New System.Drawing.Size(129, 20)
		Me.txtVille.Location = New System.Drawing.Point(96, 292)
		Me.txtVille.ReadOnly = True
		Me.txtVille.TabIndex = 23
		Me.txtVille.Text = "Text1"
		Me.txtVille.AcceptsReturn = True
		Me.txtVille.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtVille.CausesValidation = True
		Me.txtVille.Enabled = True
		Me.txtVille.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtVille.HideSelection = True
		Me.txtVille.Maxlength = 0
		Me.txtVille.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtVille.MultiLine = False
		Me.txtVille.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtVille.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtVille.TabStop = True
		Me.txtVille.Visible = True
		Me.txtVille.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtVille.Name = "txtVille"
		Me.txtAdresse.AutoSize = False
		Me.txtAdresse.BackColor = System.Drawing.Color.White
		Me.txtAdresse.Size = New System.Drawing.Size(169, 20)
		Me.txtAdresse.Location = New System.Drawing.Point(96, 264)
		Me.txtAdresse.ReadOnly = True
		Me.txtAdresse.TabIndex = 21
		Me.txtAdresse.Text = "Text1"
		Me.txtAdresse.AcceptsReturn = True
		Me.txtAdresse.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtAdresse.CausesValidation = True
		Me.txtAdresse.Enabled = True
		Me.txtAdresse.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAdresse.HideSelection = True
		Me.txtAdresse.Maxlength = 0
		Me.txtAdresse.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAdresse.MultiLine = False
		Me.txtAdresse.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAdresse.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtAdresse.TabStop = True
		Me.txtAdresse.Visible = True
		Me.txtAdresse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAdresse.Name = "txtAdresse"
		Me.txtCommentaire.AutoSize = False
		Me.txtCommentaire.BackColor = System.Drawing.Color.White
		Me.txtCommentaire.Size = New System.Drawing.Size(177, 49)
		Me.txtCommentaire.Location = New System.Drawing.Point(432, 104)
		Me.txtCommentaire.ReadOnly = True
		Me.txtCommentaire.MultiLine = True
		Me.txtCommentaire.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtCommentaire.TabIndex = 9
		Me.txtCommentaire.Text = "Text2"
		Me.txtCommentaire.AcceptsReturn = True
		Me.txtCommentaire.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCommentaire.CausesValidation = True
		Me.txtCommentaire.Enabled = True
		Me.txtCommentaire.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCommentaire.HideSelection = True
		Me.txtCommentaire.Maxlength = 0
		Me.txtCommentaire.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCommentaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCommentaire.TabStop = True
		Me.txtCommentaire.Visible = True
		Me.txtCommentaire.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCommentaire.Name = "txtCommentaire"
		Me.txtContactGRB.AutoSize = False
		Me.txtContactGRB.BackColor = System.Drawing.Color.White
		Me.txtContactGRB.Size = New System.Drawing.Size(129, 20)
		Me.txtContactGRB.Location = New System.Drawing.Point(96, 236)
		Me.txtContactGRB.ReadOnly = True
		Me.txtContactGRB.TabIndex = 19
		Me.txtContactGRB.Text = "Text1"
		Me.txtContactGRB.AcceptsReturn = True
		Me.txtContactGRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtContactGRB.CausesValidation = True
		Me.txtContactGRB.Enabled = True
		Me.txtContactGRB.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtContactGRB.HideSelection = True
		Me.txtContactGRB.Maxlength = 0
		Me.txtContactGRB.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtContactGRB.MultiLine = False
		Me.txtContactGRB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtContactGRB.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtContactGRB.TabStop = True
		Me.txtContactGRB.Visible = True
		Me.txtContactGRB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtContactGRB.Name = "txtContactGRB"
		Me.txtFax.AutoSize = False
		Me.txtFax.BackColor = System.Drawing.Color.White
		Me.txtFax.Size = New System.Drawing.Size(129, 20)
		Me.txtFax.Location = New System.Drawing.Point(96, 208)
		Me.txtFax.ReadOnly = True
		Me.txtFax.TabIndex = 14
		Me.txtFax.Text = "Text1"
		Me.txtFax.AcceptsReturn = True
		Me.txtFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtFax.CausesValidation = True
		Me.txtFax.Enabled = True
		Me.txtFax.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtFax.HideSelection = True
		Me.txtFax.Maxlength = 0
		Me.txtFax.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtFax.MultiLine = False
		Me.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtFax.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtFax.TabStop = True
		Me.txtFax.Visible = True
		Me.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtFax.Name = "txtFax"
		Me.txtTelephone.AutoSize = False
		Me.txtTelephone.BackColor = System.Drawing.Color.White
		Me.txtTelephone.Size = New System.Drawing.Size(129, 20)
		Me.txtTelephone.Location = New System.Drawing.Point(96, 180)
		Me.txtTelephone.ReadOnly = True
		Me.txtTelephone.TabIndex = 12
		Me.txtTelephone.Text = "Text1"
		Me.txtTelephone.AcceptsReturn = True
		Me.txtTelephone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTelephone.CausesValidation = True
		Me.txtTelephone.Enabled = True
		Me.txtTelephone.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTelephone.HideSelection = True
		Me.txtTelephone.Maxlength = 0
		Me.txtTelephone.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTelephone.MultiLine = False
		Me.txtTelephone.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTelephone.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTelephone.TabStop = True
		Me.txtTelephone.Visible = True
		Me.txtTelephone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTelephone.Name = "txtTelephone"
		Me.cmbClient.BackColor = System.Drawing.Color.White
		Me.cmbClient.Size = New System.Drawing.Size(289, 21)
		Me.cmbClient.Location = New System.Drawing.Point(96, 104)
		Me.cmbClient.Sorted = True
		Me.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbClient.TabIndex = 7
		Me.cmbClient.CausesValidation = True
		Me.cmbClient.Enabled = True
		Me.cmbClient.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbClient.IntegralHeight = True
		Me.cmbClient.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbClient.TabStop = True
		Me.cmbClient.Visible = True
		Me.cmbClient.Name = "cmbClient"
		Me.mskTelephone.AllowPromptAsInput = False
		Me.mskTelephone.Size = New System.Drawing.Size(129, 19)
		Me.mskTelephone.Location = New System.Drawing.Point(96, 180)
		Me.mskTelephone.TabIndex = 11
		Me.mskTelephone.Visible = False
		Me.mskTelephone.PromptChar = "_"
		Me.mskTelephone.Name = "mskTelephone"
		Me.mskFax.AllowPromptAsInput = False
		Me.mskFax.Size = New System.Drawing.Size(129, 19)
		Me.mskFax.Location = New System.Drawing.Point(96, 208)
		Me.mskFax.TabIndex = 15
		Me.mskFax.Visible = False
		Me.mskFax.PromptChar = "_"
		Me.mskFax.Name = "mskFax"
		Me.cmdCategorie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCategorie.Text = "..."
		Me.cmdCategorie.Size = New System.Drawing.Size(25, 20)
		Me.cmdCategorie.Location = New System.Drawing.Point(360, 152)
		Me.cmdCategorie.TabIndex = 79
		Me.cmdCategorie.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCategorie.CausesValidation = True
		Me.cmdCategorie.Enabled = True
		Me.cmdCategorie.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCategorie.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCategorie.TabStop = True
		Me.cmdCategorie.Name = "cmdCategorie"
		Me.fraPotentiel.BackColor = System.Drawing.Color.Black
		Me.fraPotentiel.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.fraPotentiel.Size = New System.Drawing.Size(161, 41)
		Me.fraPotentiel.Location = New System.Drawing.Point(416, 152)
		Me.fraPotentiel.TabIndex = 82
		Me.fraPotentiel.Enabled = True
		Me.fraPotentiel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraPotentiel.Cursor = System.Windows.Forms.Cursors.Default
		Me.fraPotentiel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraPotentiel.Visible = True
		Me.fraPotentiel.Name = "fraPotentiel"
		Me.chkClientPotentiel.BackColor = System.Drawing.Color.Black
		Me.chkClientPotentiel.Text = "Client Potentiel      "
		Me.chkClientPotentiel.ForeColor = System.Drawing.Color.White
		Me.chkClientPotentiel.Size = New System.Drawing.Size(129, 17)
		Me.chkClientPotentiel.Location = New System.Drawing.Point(16, 8)
		Me.chkClientPotentiel.TabIndex = 83
		Me.chkClientPotentiel.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkClientPotentiel.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkClientPotentiel.CausesValidation = True
		Me.chkClientPotentiel.Enabled = True
		Me.chkClientPotentiel.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkClientPotentiel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkClientPotentiel.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkClientPotentiel.TabStop = True
		Me.chkClientPotentiel.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkClientPotentiel.Visible = True
		Me.chkClientPotentiel.Name = "chkClientPotentiel"
		Me.Label6.Text = "Categorie"
		Me.Label6.ForeColor = System.Drawing.Color.White
		Me.Label6.Size = New System.Drawing.Size(73, 17)
		Me.Label6.Location = New System.Drawing.Point(16, 152)
		Me.Label6.TabIndex = 81
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
		Me._Label12_2.Text = "Création :"
		Me._Label12_2.ForeColor = System.Drawing.Color.White
		Me._Label12_2.Size = New System.Drawing.Size(73, 17)
		Me._Label12_2.Location = New System.Drawing.Point(16, 464)
		Me._Label12_2.TabIndex = 36
		Me._Label12_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label12_2.BackColor = System.Drawing.Color.Transparent
		Me._Label12_2.Enabled = True
		Me._Label12_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label12_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label12_2.UseMnemonic = True
		Me._Label12_2.Visible = True
		Me._Label12_2.AutoSize = False
		Me._Label12_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label12_2.Name = "_Label12_2"
		Me._Label12_3.Text = "Modification :"
		Me._Label12_3.ForeColor = System.Drawing.Color.White
		Me._Label12_3.Size = New System.Drawing.Size(81, 17)
		Me._Label12_3.Location = New System.Drawing.Point(16, 492)
		Me._Label12_3.TabIndex = 69
		Me._Label12_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label12_3.BackColor = System.Drawing.Color.Transparent
		Me._Label12_3.Enabled = True
		Me._Label12_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label12_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label12_3.UseMnemonic = True
		Me._Label12_3.Visible = True
		Me._Label12_3.AutoSize = False
		Me._Label12_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label12_3.Name = "_Label12_3"
		Me.lblDateCreation.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblDateCreation.BackColor = System.Drawing.Color.White
		Me.lblDateCreation.Text = "2004-09-14"
		Me.lblDateCreation.Size = New System.Drawing.Size(65, 19)
		Me.lblDateCreation.Location = New System.Drawing.Point(96, 460)
		Me.lblDateCreation.TabIndex = 34
		Me.lblDateCreation.Enabled = True
		Me.lblDateCreation.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDateCreation.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDateCreation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDateCreation.UseMnemonic = True
		Me.lblDateCreation.Visible = True
		Me.lblDateCreation.AutoSize = False
		Me.lblDateCreation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDateCreation.Name = "lblDateCreation"
		Me.lblDateModification.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblDateModification.BackColor = System.Drawing.Color.White
		Me.lblDateModification.Text = "2004-09-14"
		Me.lblDateModification.Size = New System.Drawing.Size(65, 19)
		Me.lblDateModification.Location = New System.Drawing.Point(96, 488)
		Me.lblDateModification.TabIndex = 67
		Me.lblDateModification.Enabled = True
		Me.lblDateModification.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDateModification.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDateModification.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDateModification.UseMnemonic = True
		Me.lblDateModification.Visible = True
		Me.lblDateModification.AutoSize = False
		Me.lblDateModification.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDateModification.Name = "lblDateModification"
		Me.lblUserCreation.Text = "Par :"
		Me.lblUserCreation.ForeColor = System.Drawing.Color.White
		Me.lblUserCreation.Size = New System.Drawing.Size(89, 17)
		Me.lblUserCreation.Location = New System.Drawing.Point(168, 460)
		Me.lblUserCreation.TabIndex = 35
		Me.lblUserCreation.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblUserCreation.BackColor = System.Drawing.Color.Transparent
		Me.lblUserCreation.Enabled = True
		Me.lblUserCreation.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblUserCreation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblUserCreation.UseMnemonic = True
		Me.lblUserCreation.Visible = True
		Me.lblUserCreation.AutoSize = False
		Me.lblUserCreation.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblUserCreation.Name = "lblUserCreation"
		Me.lblUserModification.Text = "Par :"
		Me.lblUserModification.ForeColor = System.Drawing.Color.White
		Me.lblUserModification.Size = New System.Drawing.Size(89, 17)
		Me.lblUserModification.Location = New System.Drawing.Point(168, 489)
		Me.lblUserModification.TabIndex = 68
		Me.lblUserModification.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblUserModification.BackColor = System.Drawing.Color.Transparent
		Me.lblUserModification.Enabled = True
		Me.lblUserModification.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblUserModification.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblUserModification.UseMnemonic = True
		Me.lblUserModification.Visible = True
		Me.lblUserModification.AutoSize = False
		Me.lblUserModification.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblUserModification.Name = "lblUserModification"
		Me.Label15.Text = "E-Mail"
		Me.Label15.ForeColor = System.Drawing.Color.White
		Me.Label15.Size = New System.Drawing.Size(65, 17)
		Me.Label15.Location = New System.Drawing.Point(16, 432)
		Me.Label15.TabIndex = 32
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
		Me.Label2.Text = "Site Web"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(57, 17)
		Me.Label2.Location = New System.Drawing.Point(16, 404)
		Me.Label2.TabIndex = 30
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label17.Text = "Rechercher"
		Me.Label17.ForeColor = System.Drawing.Color.White
		Me.Label17.Size = New System.Drawing.Size(113, 17)
		Me.Label17.Location = New System.Drawing.Point(352, 16)
		Me.Label17.TabIndex = 0
		Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label17.BackColor = System.Drawing.Color.Transparent
		Me.Label17.Enabled = True
		Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label17.UseMnemonic = True
		Me.Label17.Visible = True
		Me.Label17.AutoSize = False
		Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label17.Name = "Label17"
		Me.Shape1.BackColor = System.Drawing.Color.FromARGB(0, 0, 128)
		Me.Shape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me.Shape1.Size = New System.Drawing.Size(161, 73)
		Me.Shape1.Location = New System.Drawing.Point(328, 8)
		Me.Shape1.CornerRadius = 9
		Me.Shape1.BorderColor = System.Drawing.SystemColors.WindowText
		Me.Shape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Shape1.BorderWidth = 1
		Me.Shape1.FillColor = System.Drawing.Color.Black
		Me.Shape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me.Shape1.Visible = True
		Me.Shape1.Name = "Shape1"
		Me.Label8.Text = "ContactGRB"
		Me.Label8.ForeColor = System.Drawing.Color.White
		Me.Label8.Size = New System.Drawing.Size(73, 17)
		Me.Label8.Location = New System.Drawing.Point(16, 236)
		Me.Label8.TabIndex = 18
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label8.BackColor = System.Drawing.Color.Transparent
		Me.Label8.Enabled = True
		Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label8.UseMnemonic = True
		Me.Label8.Visible = True
		Me.Label8.AutoSize = False
		Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label8.Name = "Label8"
		Me.Label14.Text = "Pays"
		Me.Label14.ForeColor = System.Drawing.Color.White
		Me.Label14.Size = New System.Drawing.Size(65, 17)
		Me.Label14.Location = New System.Drawing.Point(16, 348)
		Me.Label14.TabIndex = 26
		Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label14.BackColor = System.Drawing.Color.Transparent
		Me.Label14.Enabled = True
		Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label14.UseMnemonic = True
		Me.Label14.Visible = True
		Me.Label14.AutoSize = False
		Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label14.Name = "Label14"
		Me.Label13.Text = "Code Postal"
		Me.Label13.ForeColor = System.Drawing.Color.White
		Me.Label13.Size = New System.Drawing.Size(81, 17)
		Me.Label13.Location = New System.Drawing.Point(16, 376)
		Me.Label13.TabIndex = 28
		Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label13.BackColor = System.Drawing.Color.Transparent
		Me.Label13.Enabled = True
		Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label13.UseMnemonic = True
		Me.Label13.Visible = True
		Me.Label13.AutoSize = False
		Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label13.Name = "Label13"
		Me._Label12_0.Text = "Prov/Etat"
		Me._Label12_0.ForeColor = System.Drawing.Color.White
		Me._Label12_0.Size = New System.Drawing.Size(73, 17)
		Me._Label12_0.Location = New System.Drawing.Point(16, 320)
		Me._Label12_0.TabIndex = 24
		Me._Label12_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label12_0.BackColor = System.Drawing.Color.Transparent
		Me._Label12_0.Enabled = True
		Me._Label12_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label12_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label12_0.UseMnemonic = True
		Me._Label12_0.Visible = True
		Me._Label12_0.AutoSize = False
		Me._Label12_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label12_0.Name = "_Label12_0"
		Me.Label11.Text = "Ville"
		Me.Label11.ForeColor = System.Drawing.Color.White
		Me.Label11.Size = New System.Drawing.Size(65, 17)
		Me.Label11.Location = New System.Drawing.Point(16, 292)
		Me.Label11.TabIndex = 22
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label11.BackColor = System.Drawing.Color.Transparent
		Me.Label11.Enabled = True
		Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label11.UseMnemonic = True
		Me.Label11.Visible = True
		Me.Label11.AutoSize = False
		Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label11.Name = "Label11"
		Me.Label10.Text = "Adresse"
		Me.Label10.ForeColor = System.Drawing.Color.White
		Me.Label10.Size = New System.Drawing.Size(65, 17)
		Me.Label10.Location = New System.Drawing.Point(16, 264)
		Me.Label10.TabIndex = 20
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label10.BackColor = System.Drawing.Color.Transparent
		Me.Label10.Enabled = True
		Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label10.UseMnemonic = True
		Me.Label10.Visible = True
		Me.Label10.AutoSize = False
		Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label10.Name = "Label10"
		Me.Label9.Text = "Commentaires"
		Me.Label9.ForeColor = System.Drawing.Color.White
		Me.Label9.Size = New System.Drawing.Size(81, 17)
		Me.Label9.Location = New System.Drawing.Point(432, 88)
		Me.Label9.TabIndex = 5
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label9.BackColor = System.Drawing.Color.Transparent
		Me.Label9.Enabled = True
		Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label9.UseMnemonic = True
		Me.Label9.Visible = True
		Me.Label9.AutoSize = False
		Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label9.Name = "Label9"
		Me.Label4.Text = "Fax"
		Me.Label4.ForeColor = System.Drawing.Color.White
		Me.Label4.Size = New System.Drawing.Size(65, 17)
		Me.Label4.Location = New System.Drawing.Point(16, 208)
		Me.Label4.TabIndex = 13
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
		Me.Label3.Text = "Telephone"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(73, 17)
		Me.Label3.Location = New System.Drawing.Point(16, 180)
		Me.Label3.TabIndex = 10
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
		Me._Label1_0.Text = "Client"
		Me._Label1_0.ForeColor = System.Drawing.Color.White
		Me._Label1_0.Size = New System.Drawing.Size(65, 17)
		Me._Label1_0.Location = New System.Drawing.Point(16, 104)
		Me._Label1_0.TabIndex = 6
		Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_0.BackColor = System.Drawing.Color.Transparent
		Me._Label1_0.Enabled = True
		Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_0.UseMnemonic = True
		Me._Label1_0.Visible = True
		Me._Label1_0.AutoSize = False
		Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_0.Name = "_Label1_0"
		Me.Controls.Add(fraEtatOutlook)
		Me.Controls.Add(txtCategorie)
		Me.Controls.Add(cmdMailListClient)
		Me.Controls.Add(txtEmail)
		Me.Controls.Add(cmdFax)
		Me.Controls.Add(txtSiteWeb)
		Me.Controls.Add(txtNomClient)
		Me.Controls.Add(cmdRechercher)
		Me.Controls.Add(cmdRafraichir)
		Me.Controls.Add(TxtRechercher)
		Me.Controls.Add(fraContact)
		Me.Controls.Add(cmdreport)
		Me.Controls.Add(cmdRenommer)
		Me.Controls.Add(CmdAdd)
		Me.Controls.Add(CmdSupp)
		Me.Controls.Add(CmdQuit)
		Me.Controls.Add(CmdEnr)
		Me.Controls.Add(CmdAnul)
		Me.Controls.Add(CmdModif)
		Me.Controls.Add(txtPays)
		Me.Controls.Add(txtCP)
		Me.Controls.Add(txtProvEtat)
		Me.Controls.Add(txtVille)
		Me.Controls.Add(txtAdresse)
		Me.Controls.Add(txtCommentaire)
		Me.Controls.Add(txtContactGRB)
		Me.Controls.Add(txtFax)
		Me.Controls.Add(txtTelephone)
		Me.Controls.Add(cmbClient)
		Me.Controls.Add(mskTelephone)
		Me.Controls.Add(mskFax)
		Me.Controls.Add(cmdCategorie)
		Me.Controls.Add(fraPotentiel)
		Me.Controls.Add(Label6)
		Me.Controls.Add(_Label12_2)
		Me.Controls.Add(_Label12_3)
		Me.Controls.Add(lblDateCreation)
		Me.Controls.Add(lblDateModification)
		Me.Controls.Add(lblUserCreation)
		Me.Controls.Add(lblUserModification)
		Me.Controls.Add(Label15)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label17)
		Me.ShapeContainer1.Shapes.Add(Shape1)
		Me.Controls.Add(Label8)
		Me.Controls.Add(Label14)
		Me.Controls.Add(Label13)
		Me.Controls.Add(_Label12_0)
		Me.Controls.Add(Label11)
		Me.Controls.Add(Label10)
		Me.Controls.Add(Label9)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(_Label1_0)
		Me.Controls.Add(ShapeContainer1)
		Me.fraEtatOutlook.Controls.Add(lblEtatOutlook)
		Me.fraContact.Controls.Add(cmdMailListContact)
		Me.fraContact.Controls.Add(txtContactTitre)
		Me.fraContact.Controls.Add(CmdAddCont)
		Me.fraContact.Controls.Add(txtcontact_dom)
		Me.fraContact.Controls.Add(cmdsupcontact)
		Me.fraContact.Controls.Add(txtcontact_cell)
		Me.fraContact.Controls.Add(txtcontact_fax)
		Me.fraContact.Controls.Add(CmdRefCont)
		Me.fraContact.Controls.Add(cmbcontact)
		Me.fraContact.Controls.Add(txtcontact_tel)
		Me.fraContact.Controls.Add(txtcontact_poste)
		Me.fraContact.Controls.Add(txtcontact_email)
		Me.fraContact.Controls.Add(txtcontact_page)
		Me.fraContact.Controls.Add(cmdanulcontact)
		Me.fraContact.Controls.Add(txtContact)
		Me.fraContact.Controls.Add(mskContactPage)
		Me.fraContact.Controls.Add(mskContactFax)
		Me.fraContact.Controls.Add(mskContactCell)
		Me.fraContact.Controls.Add(mskContactDom)
		Me.fraContact.Controls.Add(mskContactTel)
		Me.fraContact.Controls.Add(_Label1_8)
		Me.fraContact.Controls.Add(_Label1_6)
		Me.fraContact.Controls.Add(_Label1_1)
		Me.fraContact.Controls.Add(_Label1_2)
		Me.fraContact.Controls.Add(_Label1_3)
		Me.fraContact.Controls.Add(_Label1_4)
		Me.fraContact.Controls.Add(_Label1_5)
		Me.fraContact.Controls.Add(_Label1_7)
		Me.fraContact.Controls.Add(Label5)
		Me.fraPotentiel.Controls.Add(chkClientPotentiel)
		Me.Label1.SetIndex(_Label1_8, CType(8, Short))
		Me.Label1.SetIndex(_Label1_6, CType(6, Short))
		Me.Label1.SetIndex(_Label1_1, CType(1, Short))
		Me.Label1.SetIndex(_Label1_2, CType(2, Short))
		Me.Label1.SetIndex(_Label1_3, CType(3, Short))
		Me.Label1.SetIndex(_Label1_4, CType(4, Short))
		Me.Label1.SetIndex(_Label1_5, CType(5, Short))
		Me.Label1.SetIndex(_Label1_7, CType(7, Short))
		Me.Label1.SetIndex(_Label1_0, CType(0, Short))
		Me.Label12.SetIndex(_Label12_2, CType(2, Short))
		Me.Label12.SetIndex(_Label12_3, CType(3, Short))
		Me.Label12.SetIndex(_Label12_0, CType(0, Short))
		CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.fraEtatOutlook.ResumeLayout(False)
		Me.fraContact.ResumeLayout(False)
		Me.fraPotentiel.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class