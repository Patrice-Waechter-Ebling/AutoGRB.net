<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FrmContact
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
	Public WithEvents cmdMailList As System.Windows.Forms.Button
	Public WithEvents lblEtatOutlook As System.Windows.Forms.Label
	Public WithEvents fraEtatOutlook As System.Windows.Forms.Panel
	Public WithEvents txtNomContact As System.Windows.Forms.TextBox
	Public WithEvents cmbContact As System.Windows.Forms.ComboBox
	Public WithEvents txtTitre As System.Windows.Forms.TextBox
	Public WithEvents txtCommentaire As System.Windows.Forms.TextBox
	Public WithEvents cmdFax As System.Windows.Forms.Button
	Public WithEvents cmdCopier As System.Windows.Forms.Button
	Public WithEvents txtTelDomicile As System.Windows.Forms.TextBox
	Public WithEvents cmdRafraichir As System.Windows.Forms.Button
	Public WithEvents cmdRechercher As System.Windows.Forms.Button
	Public WithEvents cmdreport As System.Windows.Forms.Button
	Public WithEvents txtPoste As System.Windows.Forms.TextBox
	Public WithEvents txtRechercher As System.Windows.Forms.TextBox
	Public WithEvents CmdModif As System.Windows.Forms.Button
	Public WithEvents txtEmail As System.Windows.Forms.TextBox
	Public WithEvents txtPagette As System.Windows.Forms.TextBox
	Public WithEvents txtFax As System.Windows.Forms.TextBox
	Public WithEvents txtCellulaire As System.Windows.Forms.TextBox
	Public WithEvents txtTelephone As System.Windows.Forms.TextBox
	Public WithEvents txtCompagnie As System.Windows.Forms.TextBox
	Public WithEvents CmdSupp As System.Windows.Forms.Button
	Public WithEvents CmdAdd As System.Windows.Forms.Button
	Public WithEvents CmdQuit As System.Windows.Forms.Button
	Public WithEvents mskTelephone As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskCellulaire As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskFax As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskPagette As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskTelDomicile As System.Windows.Forms.MaskedTextBox
	Public WithEvents CmdAnul As System.Windows.Forms.Button
	Public WithEvents CmdEnr As System.Windows.Forms.Button
	Public WithEvents _Label1_10 As System.Windows.Forms.Label
	Public WithEvents _Label1_9 As System.Windows.Forms.Label
	Public WithEvents lblUserModification As System.Windows.Forms.Label
	Public WithEvents lblUserCreation As System.Windows.Forms.Label
	Public WithEvents lblDateModification As System.Windows.Forms.Label
	Public WithEvents lblDateCreation As System.Windows.Forms.Label
	Public WithEvents _Label12_3 As System.Windows.Forms.Label
	Public WithEvents _Label12_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_8 As System.Windows.Forms.Label
	Public WithEvents _Label1_7 As System.Windows.Forms.Label
	Public WithEvents lblRechercher As System.Windows.Forms.Label
	Public WithEvents _Label1_6 As System.Windows.Forms.Label
	Public WithEvents _Label1_5 As System.Windows.Forms.Label
	Public WithEvents _Label1_4 As System.Windows.Forms.Label
	Public WithEvents _Label1_3 As System.Windows.Forms.Label
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents Shape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Label12 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmContact))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.cmdMailList = New System.Windows.Forms.Button
		Me.fraEtatOutlook = New System.Windows.Forms.Panel
		Me.lblEtatOutlook = New System.Windows.Forms.Label
		Me.txtNomContact = New System.Windows.Forms.TextBox
		Me.cmbContact = New System.Windows.Forms.ComboBox
		Me.txtTitre = New System.Windows.Forms.TextBox
		Me.txtCommentaire = New System.Windows.Forms.TextBox
		Me.cmdFax = New System.Windows.Forms.Button
		Me.cmdCopier = New System.Windows.Forms.Button
		Me.txtTelDomicile = New System.Windows.Forms.TextBox
		Me.cmdRafraichir = New System.Windows.Forms.Button
		Me.cmdRechercher = New System.Windows.Forms.Button
		Me.cmdreport = New System.Windows.Forms.Button
		Me.txtPoste = New System.Windows.Forms.TextBox
		Me.txtRechercher = New System.Windows.Forms.TextBox
		Me.CmdModif = New System.Windows.Forms.Button
		Me.txtEmail = New System.Windows.Forms.TextBox
		Me.txtPagette = New System.Windows.Forms.TextBox
		Me.txtFax = New System.Windows.Forms.TextBox
		Me.txtCellulaire = New System.Windows.Forms.TextBox
		Me.txtTelephone = New System.Windows.Forms.TextBox
		Me.txtCompagnie = New System.Windows.Forms.TextBox
		Me.CmdSupp = New System.Windows.Forms.Button
		Me.CmdAdd = New System.Windows.Forms.Button
		Me.CmdQuit = New System.Windows.Forms.Button
		Me.mskTelephone = New System.Windows.Forms.MaskedTextBox
		Me.mskCellulaire = New System.Windows.Forms.MaskedTextBox
		Me.mskFax = New System.Windows.Forms.MaskedTextBox
		Me.mskPagette = New System.Windows.Forms.MaskedTextBox
		Me.mskTelDomicile = New System.Windows.Forms.MaskedTextBox
		Me.CmdAnul = New System.Windows.Forms.Button
		Me.CmdEnr = New System.Windows.Forms.Button
		Me._Label1_10 = New System.Windows.Forms.Label
		Me._Label1_9 = New System.Windows.Forms.Label
		Me.lblUserModification = New System.Windows.Forms.Label
		Me.lblUserCreation = New System.Windows.Forms.Label
		Me.lblDateModification = New System.Windows.Forms.Label
		Me.lblDateCreation = New System.Windows.Forms.Label
		Me._Label12_3 = New System.Windows.Forms.Label
		Me._Label12_2 = New System.Windows.Forms.Label
		Me._Label1_8 = New System.Windows.Forms.Label
		Me._Label1_7 = New System.Windows.Forms.Label
		Me.lblRechercher = New System.Windows.Forms.Label
		Me._Label1_6 = New System.Windows.Forms.Label
		Me._Label1_5 = New System.Windows.Forms.Label
		Me._Label1_4 = New System.Windows.Forms.Label
		Me._Label1_3 = New System.Windows.Forms.Label
		Me._Label1_2 = New System.Windows.Forms.Label
		Me._Label1_1 = New System.Windows.Forms.Label
		Me._Label1_0 = New System.Windows.Forms.Label
		Me.Shape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Label12 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.fraEtatOutlook.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Contacts"
		Me.ClientSize = New System.Drawing.Size(636, 503)
		Me.Location = New System.Drawing.Point(222, 178)
		Me.Icon = CType(resources.GetObject("FrmContact.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("FrmContact.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "FrmContact"
		Me.cmdMailList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMailList.Text = "Ajouter au mailing list"
		Me.cmdMailList.Size = New System.Drawing.Size(113, 33)
		Me.cmdMailList.Location = New System.Drawing.Point(368, 464)
		Me.cmdMailList.TabIndex = 49
		Me.cmdMailList.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMailList.CausesValidation = True
		Me.cmdMailList.Enabled = True
		Me.cmdMailList.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMailList.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMailList.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMailList.TabStop = True
		Me.cmdMailList.Name = "cmdMailList"
		Me.fraEtatOutlook.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.fraEtatOutlook.Size = New System.Drawing.Size(553, 145)
		Me.fraEtatOutlook.Location = New System.Drawing.Point(40, 192)
		Me.fraEtatOutlook.TabIndex = 14
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
		Me.lblEtatOutlook.TabIndex = 15
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
		Me.txtNomContact.AutoSize = False
		Me.txtNomContact.BackColor = System.Drawing.Color.White
		Me.txtNomContact.Size = New System.Drawing.Size(409, 20)
		Me.txtNomContact.Location = New System.Drawing.Point(96, 88)
		Me.txtNomContact.ReadOnly = True
		Me.txtNomContact.TabIndex = 5
		Me.txtNomContact.Text = "Text1"
		Me.txtNomContact.AcceptsReturn = True
		Me.txtNomContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNomContact.CausesValidation = True
		Me.txtNomContact.Enabled = True
		Me.txtNomContact.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNomContact.HideSelection = True
		Me.txtNomContact.Maxlength = 0
		Me.txtNomContact.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNomContact.MultiLine = False
		Me.txtNomContact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNomContact.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNomContact.TabStop = True
		Me.txtNomContact.Visible = True
		Me.txtNomContact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNomContact.Name = "txtNomContact"
		Me.cmbContact.BackColor = System.Drawing.Color.White
		Me.cmbContact.Size = New System.Drawing.Size(425, 21)
		Me.cmbContact.Location = New System.Drawing.Point(96, 88)
		Me.cmbContact.Sorted = True
		Me.cmbContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbContact.TabIndex = 4
		Me.cmbContact.CausesValidation = True
		Me.cmbContact.Enabled = True
		Me.cmbContact.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbContact.IntegralHeight = True
		Me.cmbContact.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbContact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbContact.TabStop = True
		Me.cmbContact.Visible = True
		Me.cmbContact.Name = "cmbContact"
		Me.txtTitre.AutoSize = False
		Me.txtTitre.BackColor = System.Drawing.Color.White
		Me.txtTitre.Size = New System.Drawing.Size(393, 20)
		Me.txtTitre.Location = New System.Drawing.Point(96, 160)
		Me.txtTitre.ReadOnly = True
		Me.txtTitre.TabIndex = 8
		Me.txtTitre.Text = "Text1"
		Me.txtTitre.AcceptsReturn = True
		Me.txtTitre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTitre.CausesValidation = True
		Me.txtTitre.Enabled = True
		Me.txtTitre.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTitre.HideSelection = True
		Me.txtTitre.Maxlength = 0
		Me.txtTitre.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTitre.MultiLine = False
		Me.txtTitre.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTitre.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTitre.TabStop = True
		Me.txtTitre.Visible = True
		Me.txtTitre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTitre.Name = "txtTitre"
		Me.txtCommentaire.AutoSize = False
		Me.txtCommentaire.BackColor = System.Drawing.Color.White
		Me.txtCommentaire.Size = New System.Drawing.Size(393, 43)
		Me.txtCommentaire.Location = New System.Drawing.Point(96, 352)
		Me.txtCommentaire.ReadOnly = True
		Me.txtCommentaire.MultiLine = True
		Me.txtCommentaire.TabIndex = 33
		Me.txtCommentaire.AcceptsReturn = True
		Me.txtCommentaire.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCommentaire.CausesValidation = True
		Me.txtCommentaire.Enabled = True
		Me.txtCommentaire.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCommentaire.HideSelection = True
		Me.txtCommentaire.Maxlength = 0
		Me.txtCommentaire.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCommentaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCommentaire.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCommentaire.TabStop = True
		Me.txtCommentaire.Visible = True
		Me.txtCommentaire.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCommentaire.Name = "txtCommentaire"
		Me.cmdFax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFax.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFax.Text = "Envoyer Fax"
		Me.cmdFax.Size = New System.Drawing.Size(73, 33)
		Me.cmdFax.Location = New System.Drawing.Point(488, 464)
		Me.cmdFax.TabIndex = 47
		Me.cmdFax.CausesValidation = True
		Me.cmdFax.Enabled = True
		Me.cmdFax.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFax.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFax.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFax.TabStop = True
		Me.cmdFax.Name = "cmdFax"
		Me.cmdCopier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCopier.Text = "&Copier"
		Me.cmdCopier.Size = New System.Drawing.Size(65, 33)
		Me.cmdCopier.Location = New System.Drawing.Point(96, 464)
		Me.cmdCopier.TabIndex = 41
		Me.cmdCopier.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCopier.CausesValidation = True
		Me.cmdCopier.Enabled = True
		Me.cmdCopier.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCopier.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCopier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCopier.TabStop = True
		Me.cmdCopier.Name = "cmdCopier"
		Me.txtTelDomicile.AutoSize = False
		Me.txtTelDomicile.BackColor = System.Drawing.Color.White
		Me.txtTelDomicile.Size = New System.Drawing.Size(393, 20)
		Me.txtTelDomicile.Location = New System.Drawing.Point(96, 232)
		Me.txtTelDomicile.ReadOnly = True
		Me.txtTelDomicile.TabIndex = 18
		Me.txtTelDomicile.Text = "Text1"
		Me.txtTelDomicile.AcceptsReturn = True
		Me.txtTelDomicile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTelDomicile.CausesValidation = True
		Me.txtTelDomicile.Enabled = True
		Me.txtTelDomicile.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTelDomicile.HideSelection = True
		Me.txtTelDomicile.Maxlength = 0
		Me.txtTelDomicile.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTelDomicile.MultiLine = False
		Me.txtTelDomicile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTelDomicile.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTelDomicile.TabStop = True
		Me.txtTelDomicile.Visible = True
		Me.txtTelDomicile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTelDomicile.Name = "txtTelDomicile"
		Me.cmdRafraichir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRafraichir.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRafraichir.Text = "Rafraîchir"
		Me.cmdRafraichir.Size = New System.Drawing.Size(65, 17)
		Me.cmdRafraichir.Location = New System.Drawing.Point(112, 72)
		Me.cmdRafraichir.TabIndex = 3
		Me.cmdRafraichir.CausesValidation = True
		Me.cmdRafraichir.Enabled = True
		Me.cmdRafraichir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRafraichir.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRafraichir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRafraichir.TabStop = True
		Me.cmdRafraichir.Name = "cmdRafraichir"
		Me.cmdRechercher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRechercher.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercher.Text = "Rechercher"
		Me.AcceptButton = Me.cmdRechercher
		Me.cmdRechercher.Enabled = False
		Me.cmdRechercher.Size = New System.Drawing.Size(73, 25)
		Me.cmdRechercher.Location = New System.Drawing.Point(448, 40)
		Me.cmdRechercher.TabIndex = 1
		Me.cmdRechercher.CausesValidation = True
		Me.cmdRechercher.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercher.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercher.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercher.TabStop = True
		Me.cmdRechercher.Name = "cmdRechercher"
		Me.cmdreport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdreport.BackColor = System.Drawing.SystemColors.Control
		Me.cmdreport.Text = "&Impression"
		Me.cmdreport.Size = New System.Drawing.Size(73, 33)
		Me.cmdreport.Location = New System.Drawing.Point(8, 464)
		Me.cmdreport.TabIndex = 40
		Me.cmdreport.CausesValidation = True
		Me.cmdreport.Enabled = True
		Me.cmdreport.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdreport.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdreport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdreport.TabStop = True
		Me.cmdreport.Name = "cmdreport"
		Me.txtPoste.AutoSize = False
		Me.txtPoste.BackColor = System.Drawing.Color.White
		Me.txtPoste.Size = New System.Drawing.Size(393, 20)
		Me.txtPoste.Location = New System.Drawing.Point(96, 208)
		Me.txtPoste.ReadOnly = True
		Me.txtPoste.TabIndex = 17
		Me.txtPoste.Text = "Text1"
		Me.txtPoste.AcceptsReturn = True
		Me.txtPoste.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPoste.CausesValidation = True
		Me.txtPoste.Enabled = True
		Me.txtPoste.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPoste.HideSelection = True
		Me.txtPoste.Maxlength = 0
		Me.txtPoste.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPoste.MultiLine = False
		Me.txtPoste.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPoste.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPoste.TabStop = True
		Me.txtPoste.Visible = True
		Me.txtPoste.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPoste.Name = "txtPoste"
		Me.txtRechercher.AutoSize = False
		Me.txtRechercher.BackColor = System.Drawing.Color.White
		Me.txtRechercher.Size = New System.Drawing.Size(113, 25)
		Me.txtRechercher.Location = New System.Drawing.Point(320, 48)
		Me.txtRechercher.TabIndex = 2
		Me.txtRechercher.AcceptsReturn = True
		Me.txtRechercher.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtRechercher.CausesValidation = True
		Me.txtRechercher.Enabled = True
		Me.txtRechercher.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtRechercher.HideSelection = True
		Me.txtRechercher.ReadOnly = False
		Me.txtRechercher.Maxlength = 0
		Me.txtRechercher.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtRechercher.MultiLine = False
		Me.txtRechercher.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtRechercher.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtRechercher.TabStop = True
		Me.txtRechercher.Visible = True
		Me.txtRechercher.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtRechercher.Name = "txtRechercher"
		Me.CmdModif.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdModif.BackColor = System.Drawing.SystemColors.Control
		Me.CmdModif.Text = "&Modifier"
		Me.CmdModif.Size = New System.Drawing.Size(57, 33)
		Me.CmdModif.Location = New System.Drawing.Point(304, 464)
		Me.CmdModif.TabIndex = 46
		Me.CmdModif.CausesValidation = True
		Me.CmdModif.Enabled = True
		Me.CmdModif.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdModif.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdModif.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdModif.TabStop = True
		Me.CmdModif.Name = "CmdModif"
		Me.txtEmail.AutoSize = False
		Me.txtEmail.BackColor = System.Drawing.Color.White
		Me.txtEmail.Size = New System.Drawing.Size(393, 20)
		Me.txtEmail.Location = New System.Drawing.Point(96, 328)
		Me.txtEmail.ReadOnly = True
		Me.txtEmail.TabIndex = 31
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
		Me.txtPagette.AutoSize = False
		Me.txtPagette.BackColor = System.Drawing.Color.White
		Me.txtPagette.Size = New System.Drawing.Size(393, 20)
		Me.txtPagette.Location = New System.Drawing.Point(96, 304)
		Me.txtPagette.ReadOnly = True
		Me.txtPagette.TabIndex = 28
		Me.txtPagette.Text = "Text1"
		Me.txtPagette.AcceptsReturn = True
		Me.txtPagette.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPagette.CausesValidation = True
		Me.txtPagette.Enabled = True
		Me.txtPagette.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPagette.HideSelection = True
		Me.txtPagette.Maxlength = 0
		Me.txtPagette.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPagette.MultiLine = False
		Me.txtPagette.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPagette.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPagette.TabStop = True
		Me.txtPagette.Visible = True
		Me.txtPagette.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPagette.Name = "txtPagette"
		Me.txtFax.AutoSize = False
		Me.txtFax.BackColor = System.Drawing.Color.White
		Me.txtFax.Size = New System.Drawing.Size(393, 20)
		Me.txtFax.Location = New System.Drawing.Point(96, 280)
		Me.txtFax.ReadOnly = True
		Me.txtFax.TabIndex = 25
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
		Me.txtCellulaire.AutoSize = False
		Me.txtCellulaire.BackColor = System.Drawing.Color.White
		Me.txtCellulaire.Size = New System.Drawing.Size(393, 20)
		Me.txtCellulaire.Location = New System.Drawing.Point(96, 256)
		Me.txtCellulaire.ReadOnly = True
		Me.txtCellulaire.TabIndex = 21
		Me.txtCellulaire.Text = "Text1"
		Me.txtCellulaire.AcceptsReturn = True
		Me.txtCellulaire.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCellulaire.CausesValidation = True
		Me.txtCellulaire.Enabled = True
		Me.txtCellulaire.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCellulaire.HideSelection = True
		Me.txtCellulaire.Maxlength = 0
		Me.txtCellulaire.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCellulaire.MultiLine = False
		Me.txtCellulaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCellulaire.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCellulaire.TabStop = True
		Me.txtCellulaire.Visible = True
		Me.txtCellulaire.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCellulaire.Name = "txtCellulaire"
		Me.txtTelephone.AutoSize = False
		Me.txtTelephone.BackColor = System.Drawing.Color.White
		Me.txtTelephone.Size = New System.Drawing.Size(393, 20)
		Me.txtTelephone.Location = New System.Drawing.Point(96, 184)
		Me.txtTelephone.ReadOnly = True
		Me.txtTelephone.TabIndex = 13
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
		Me.txtCompagnie.AutoSize = False
		Me.txtCompagnie.BackColor = System.Drawing.Color.White
		Me.txtCompagnie.Size = New System.Drawing.Size(393, 20)
		Me.txtCompagnie.Location = New System.Drawing.Point(96, 136)
		Me.txtCompagnie.ReadOnly = True
		Me.txtCompagnie.TabIndex = 7
		Me.txtCompagnie.Text = "Text1"
		Me.txtCompagnie.AcceptsReturn = True
		Me.txtCompagnie.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCompagnie.CausesValidation = True
		Me.txtCompagnie.Enabled = True
		Me.txtCompagnie.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCompagnie.HideSelection = True
		Me.txtCompagnie.Maxlength = 0
		Me.txtCompagnie.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCompagnie.MultiLine = False
		Me.txtCompagnie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCompagnie.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCompagnie.TabStop = True
		Me.txtCompagnie.Visible = True
		Me.txtCompagnie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCompagnie.Name = "txtCompagnie"
		Me.CmdSupp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdSupp.BackColor = System.Drawing.SystemColors.Control
		Me.CmdSupp.Text = "&Supprimer"
		Me.CmdSupp.Size = New System.Drawing.Size(65, 33)
		Me.CmdSupp.Location = New System.Drawing.Point(232, 464)
		Me.CmdSupp.TabIndex = 45
		Me.CmdSupp.CausesValidation = True
		Me.CmdSupp.Enabled = True
		Me.CmdSupp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdSupp.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdSupp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdSupp.TabStop = True
		Me.CmdSupp.Name = "CmdSupp"
		Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdAdd.BackColor = System.Drawing.SystemColors.Control
		Me.CmdAdd.Text = "&Ajouter"
		Me.CmdAdd.Size = New System.Drawing.Size(57, 33)
		Me.CmdAdd.Location = New System.Drawing.Point(168, 464)
		Me.CmdAdd.TabIndex = 44
		Me.CmdAdd.CausesValidation = True
		Me.CmdAdd.Enabled = True
		Me.CmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdAdd.TabStop = True
		Me.CmdAdd.Name = "CmdAdd"
		Me.CmdQuit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdQuit.BackColor = System.Drawing.SystemColors.Control
		Me.CmdQuit.Text = "&Fermer"
		Me.CmdQuit.Size = New System.Drawing.Size(65, 33)
		Me.CmdQuit.Location = New System.Drawing.Point(568, 464)
		Me.CmdQuit.TabIndex = 48
		Me.CmdQuit.CausesValidation = True
		Me.CmdQuit.Enabled = True
		Me.CmdQuit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdQuit.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdQuit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdQuit.TabStop = True
		Me.CmdQuit.Name = "CmdQuit"
		Me.mskTelephone.AllowPromptAsInput = False
		Me.mskTelephone.Size = New System.Drawing.Size(393, 19)
		Me.mskTelephone.Location = New System.Drawing.Point(96, 184)
		Me.mskTelephone.TabIndex = 12
		Me.mskTelephone.Visible = False
		Me.mskTelephone.PromptChar = "_"
		Me.mskTelephone.Name = "mskTelephone"
		Me.mskCellulaire.AllowPromptAsInput = False
		Me.mskCellulaire.Size = New System.Drawing.Size(393, 19)
		Me.mskCellulaire.Location = New System.Drawing.Point(96, 256)
		Me.mskCellulaire.TabIndex = 22
		Me.mskCellulaire.Visible = False
		Me.mskCellulaire.PromptChar = "_"
		Me.mskCellulaire.Name = "mskCellulaire"
		Me.mskFax.AllowPromptAsInput = False
		Me.mskFax.Size = New System.Drawing.Size(393, 19)
		Me.mskFax.Location = New System.Drawing.Point(96, 280)
		Me.mskFax.TabIndex = 24
		Me.mskFax.Visible = False
		Me.mskFax.PromptChar = "_"
		Me.mskFax.Name = "mskFax"
		Me.mskPagette.AllowPromptAsInput = False
		Me.mskPagette.Size = New System.Drawing.Size(393, 19)
		Me.mskPagette.Location = New System.Drawing.Point(96, 304)
		Me.mskPagette.TabIndex = 27
		Me.mskPagette.Visible = False
		Me.mskPagette.PromptChar = "_"
		Me.mskPagette.Name = "mskPagette"
		Me.mskTelDomicile.AllowPromptAsInput = False
		Me.mskTelDomicile.Size = New System.Drawing.Size(393, 19)
		Me.mskTelDomicile.Location = New System.Drawing.Point(96, 232)
		Me.mskTelDomicile.TabIndex = 19
		Me.mskTelDomicile.Visible = False
		Me.mskTelDomicile.PromptChar = "_"
		Me.mskTelDomicile.Name = "mskTelDomicile"
		Me.CmdAnul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdAnul.Text = "A&nnuler"
		Me.CmdAnul.Size = New System.Drawing.Size(57, 33)
		Me.CmdAnul.Location = New System.Drawing.Point(168, 464)
		Me.CmdAnul.TabIndex = 43
		Me.CmdAnul.Visible = False
		Me.CmdAnul.BackColor = System.Drawing.SystemColors.Control
		Me.CmdAnul.CausesValidation = True
		Me.CmdAnul.Enabled = True
		Me.CmdAnul.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdAnul.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdAnul.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdAnul.TabStop = True
		Me.CmdAnul.Name = "CmdAnul"
		Me.CmdEnr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdEnr.Text = "&Enregistrer"
		Me.CmdEnr.Size = New System.Drawing.Size(65, 33)
		Me.CmdEnr.Location = New System.Drawing.Point(96, 464)
		Me.CmdEnr.TabIndex = 42
		Me.CmdEnr.Visible = False
		Me.CmdEnr.BackColor = System.Drawing.SystemColors.Control
		Me.CmdEnr.CausesValidation = True
		Me.CmdEnr.Enabled = True
		Me.CmdEnr.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdEnr.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdEnr.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdEnr.TabStop = True
		Me.CmdEnr.Name = "CmdEnr"
		Me._Label1_10.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._Label1_10.Text = "Titre :"
		Me._Label1_10.ForeColor = System.Drawing.Color.White
		Me._Label1_10.Size = New System.Drawing.Size(73, 17)
		Me._Label1_10.Location = New System.Drawing.Point(16, 160)
		Me._Label1_10.TabIndex = 11
		Me._Label1_10.BackColor = System.Drawing.Color.Transparent
		Me._Label1_10.Enabled = True
		Me._Label1_10.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_10.UseMnemonic = True
		Me._Label1_10.Visible = True
		Me._Label1_10.AutoSize = False
		Me._Label1_10.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_10.Name = "_Label1_10"
		Me._Label1_9.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._Label1_9.Text = "Commentaire :"
		Me._Label1_9.ForeColor = System.Drawing.Color.White
		Me._Label1_9.Size = New System.Drawing.Size(81, 17)
		Me._Label1_9.Location = New System.Drawing.Point(8, 352)
		Me._Label1_9.TabIndex = 32
		Me._Label1_9.BackColor = System.Drawing.Color.Transparent
		Me._Label1_9.Enabled = True
		Me._Label1_9.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_9.UseMnemonic = True
		Me._Label1_9.Visible = True
		Me._Label1_9.AutoSize = False
		Me._Label1_9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_9.Name = "_Label1_9"
		Me.lblUserModification.Text = "Par :"
		Me.lblUserModification.ForeColor = System.Drawing.Color.White
		Me.lblUserModification.Size = New System.Drawing.Size(89, 17)
		Me.lblUserModification.Location = New System.Drawing.Point(168, 425)
		Me.lblUserModification.TabIndex = 39
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
		Me.lblUserCreation.Text = "Par :"
		Me.lblUserCreation.ForeColor = System.Drawing.Color.White
		Me.lblUserCreation.Size = New System.Drawing.Size(89, 17)
		Me.lblUserCreation.Location = New System.Drawing.Point(168, 400)
		Me.lblUserCreation.TabIndex = 36
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
		Me.lblDateModification.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblDateModification.BackColor = System.Drawing.Color.White
		Me.lblDateModification.Text = "2004-09-14"
		Me.lblDateModification.Size = New System.Drawing.Size(65, 19)
		Me.lblDateModification.Location = New System.Drawing.Point(96, 424)
		Me.lblDateModification.TabIndex = 38
		Me.lblDateModification.Enabled = True
		Me.lblDateModification.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDateModification.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDateModification.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDateModification.UseMnemonic = True
		Me.lblDateModification.Visible = True
		Me.lblDateModification.AutoSize = False
		Me.lblDateModification.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDateModification.Name = "lblDateModification"
		Me.lblDateCreation.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblDateCreation.BackColor = System.Drawing.Color.White
		Me.lblDateCreation.Text = "2004-09-14"
		Me.lblDateCreation.Size = New System.Drawing.Size(65, 19)
		Me.lblDateCreation.Location = New System.Drawing.Point(96, 400)
		Me.lblDateCreation.TabIndex = 35
		Me.lblDateCreation.Enabled = True
		Me.lblDateCreation.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDateCreation.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDateCreation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDateCreation.UseMnemonic = True
		Me.lblDateCreation.Visible = True
		Me.lblDateCreation.AutoSize = False
		Me.lblDateCreation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDateCreation.Name = "lblDateCreation"
		Me._Label12_3.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._Label12_3.Text = "Modification :"
		Me._Label12_3.ForeColor = System.Drawing.Color.White
		Me._Label12_3.Size = New System.Drawing.Size(81, 17)
		Me._Label12_3.Location = New System.Drawing.Point(8, 424)
		Me._Label12_3.TabIndex = 37
		Me._Label12_3.BackColor = System.Drawing.Color.Transparent
		Me._Label12_3.Enabled = True
		Me._Label12_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label12_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label12_3.UseMnemonic = True
		Me._Label12_3.Visible = True
		Me._Label12_3.AutoSize = False
		Me._Label12_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label12_3.Name = "_Label12_3"
		Me._Label12_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._Label12_2.Text = "Création :"
		Me._Label12_2.ForeColor = System.Drawing.Color.White
		Me._Label12_2.Size = New System.Drawing.Size(73, 17)
		Me._Label12_2.Location = New System.Drawing.Point(16, 400)
		Me._Label12_2.TabIndex = 34
		Me._Label12_2.BackColor = System.Drawing.Color.Transparent
		Me._Label12_2.Enabled = True
		Me._Label12_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label12_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label12_2.UseMnemonic = True
		Me._Label12_2.Visible = True
		Me._Label12_2.AutoSize = False
		Me._Label12_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label12_2.Name = "_Label12_2"
		Me._Label1_8.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._Label1_8.Text = "Domicile :"
		Me._Label1_8.ForeColor = System.Drawing.Color.White
		Me._Label1_8.Size = New System.Drawing.Size(73, 17)
		Me._Label1_8.Location = New System.Drawing.Point(16, 232)
		Me._Label1_8.TabIndex = 30
		Me._Label1_8.BackColor = System.Drawing.Color.Transparent
		Me._Label1_8.Enabled = True
		Me._Label1_8.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_8.UseMnemonic = True
		Me._Label1_8.Visible = True
		Me._Label1_8.AutoSize = False
		Me._Label1_8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_8.Name = "_Label1_8"
		Me._Label1_7.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._Label1_7.Text = "Poste :"
		Me._Label1_7.ForeColor = System.Drawing.Color.White
		Me._Label1_7.Size = New System.Drawing.Size(73, 17)
		Me._Label1_7.Location = New System.Drawing.Point(16, 208)
		Me._Label1_7.TabIndex = 16
		Me._Label1_7.BackColor = System.Drawing.Color.Transparent
		Me._Label1_7.Enabled = True
		Me._Label1_7.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_7.UseMnemonic = True
		Me._Label1_7.Visible = True
		Me._Label1_7.AutoSize = False
		Me._Label1_7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_7.Name = "_Label1_7"
		Me.lblRechercher.Text = "Rechercher"
		Me.lblRechercher.ForeColor = System.Drawing.Color.White
		Me.lblRechercher.Size = New System.Drawing.Size(97, 17)
		Me.lblRechercher.Location = New System.Drawing.Point(328, 24)
		Me.lblRechercher.TabIndex = 0
		Me.lblRechercher.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblRechercher.BackColor = System.Drawing.Color.Transparent
		Me.lblRechercher.Enabled = True
		Me.lblRechercher.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblRechercher.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblRechercher.UseMnemonic = True
		Me.lblRechercher.Visible = True
		Me.lblRechercher.AutoSize = False
		Me.lblRechercher.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblRechercher.Name = "lblRechercher"
		Me._Label1_6.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._Label1_6.Text = "Contact :"
		Me._Label1_6.ForeColor = System.Drawing.Color.White
		Me._Label1_6.Size = New System.Drawing.Size(81, 17)
		Me._Label1_6.Location = New System.Drawing.Point(8, 88)
		Me._Label1_6.TabIndex = 10
		Me._Label1_6.BackColor = System.Drawing.Color.Transparent
		Me._Label1_6.Enabled = True
		Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_6.UseMnemonic = True
		Me._Label1_6.Visible = True
		Me._Label1_6.AutoSize = False
		Me._Label1_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_6.Name = "_Label1_6"
		Me._Label1_5.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._Label1_5.Text = "E-Mail :"
		Me._Label1_5.ForeColor = System.Drawing.Color.White
		Me._Label1_5.Size = New System.Drawing.Size(65, 17)
		Me._Label1_5.Location = New System.Drawing.Point(24, 328)
		Me._Label1_5.TabIndex = 29
		Me._Label1_5.BackColor = System.Drawing.Color.Transparent
		Me._Label1_5.Enabled = True
		Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_5.UseMnemonic = True
		Me._Label1_5.Visible = True
		Me._Label1_5.AutoSize = False
		Me._Label1_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_5.Name = "_Label1_5"
		Me._Label1_4.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._Label1_4.Text = "Pagette :"
		Me._Label1_4.ForeColor = System.Drawing.Color.White
		Me._Label1_4.Size = New System.Drawing.Size(65, 17)
		Me._Label1_4.Location = New System.Drawing.Point(24, 304)
		Me._Label1_4.TabIndex = 26
		Me._Label1_4.BackColor = System.Drawing.Color.Transparent
		Me._Label1_4.Enabled = True
		Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_4.UseMnemonic = True
		Me._Label1_4.Visible = True
		Me._Label1_4.AutoSize = False
		Me._Label1_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_4.Name = "_Label1_4"
		Me._Label1_3.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._Label1_3.Text = "Fax :"
		Me._Label1_3.ForeColor = System.Drawing.Color.White
		Me._Label1_3.Size = New System.Drawing.Size(65, 17)
		Me._Label1_3.Location = New System.Drawing.Point(24, 280)
		Me._Label1_3.TabIndex = 23
		Me._Label1_3.BackColor = System.Drawing.Color.Transparent
		Me._Label1_3.Enabled = True
		Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_3.UseMnemonic = True
		Me._Label1_3.Visible = True
		Me._Label1_3.AutoSize = False
		Me._Label1_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_3.Name = "_Label1_3"
		Me._Label1_2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._Label1_2.Text = "Cellulaire :"
		Me._Label1_2.ForeColor = System.Drawing.Color.White
		Me._Label1_2.Size = New System.Drawing.Size(65, 17)
		Me._Label1_2.Location = New System.Drawing.Point(24, 256)
		Me._Label1_2.TabIndex = 20
		Me._Label1_2.BackColor = System.Drawing.Color.Transparent
		Me._Label1_2.Enabled = True
		Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_2.UseMnemonic = True
		Me._Label1_2.Visible = True
		Me._Label1_2.AutoSize = False
		Me._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_2.Name = "_Label1_2"
		Me._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._Label1_1.Text = "Téléphone :"
		Me._Label1_1.ForeColor = System.Drawing.Color.White
		Me._Label1_1.Size = New System.Drawing.Size(73, 17)
		Me._Label1_1.Location = New System.Drawing.Point(16, 184)
		Me._Label1_1.TabIndex = 9
		Me._Label1_1.BackColor = System.Drawing.Color.Transparent
		Me._Label1_1.Enabled = True
		Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_1.UseMnemonic = True
		Me._Label1_1.Visible = True
		Me._Label1_1.AutoSize = False
		Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_1.Name = "_Label1_1"
		Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._Label1_0.Text = "Compagnie :"
		Me._Label1_0.ForeColor = System.Drawing.Color.White
		Me._Label1_0.Size = New System.Drawing.Size(73, 17)
		Me._Label1_0.Location = New System.Drawing.Point(16, 136)
		Me._Label1_0.TabIndex = 6
		Me._Label1_0.BackColor = System.Drawing.Color.Transparent
		Me._Label1_0.Enabled = True
		Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_0.UseMnemonic = True
		Me._Label1_0.Visible = True
		Me._Label1_0.AutoSize = False
		Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_0.Name = "_Label1_0"
		Me.Shape1.BackColor = System.Drawing.Color.FromARGB(0, 0, 128)
		Me.Shape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me.Shape1.Size = New System.Drawing.Size(129, 65)
		Me.Shape1.Location = New System.Drawing.Point(312, 16)
		Me.Shape1.CornerRadius = 8
		Me.Shape1.BorderColor = System.Drawing.SystemColors.WindowText
		Me.Shape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Shape1.BorderWidth = 1
		Me.Shape1.FillColor = System.Drawing.Color.Black
		Me.Shape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me.Shape1.Visible = True
		Me.Shape1.Name = "Shape1"
		Me.Controls.Add(cmdMailList)
		Me.Controls.Add(fraEtatOutlook)
		Me.Controls.Add(txtNomContact)
		Me.Controls.Add(cmbContact)
		Me.Controls.Add(txtTitre)
		Me.Controls.Add(txtCommentaire)
		Me.Controls.Add(cmdFax)
		Me.Controls.Add(cmdCopier)
		Me.Controls.Add(txtTelDomicile)
		Me.Controls.Add(cmdRafraichir)
		Me.Controls.Add(cmdRechercher)
		Me.Controls.Add(cmdreport)
		Me.Controls.Add(txtPoste)
		Me.Controls.Add(txtRechercher)
		Me.Controls.Add(CmdModif)
		Me.Controls.Add(txtEmail)
		Me.Controls.Add(txtPagette)
		Me.Controls.Add(txtFax)
		Me.Controls.Add(txtCellulaire)
		Me.Controls.Add(txtTelephone)
		Me.Controls.Add(txtCompagnie)
		Me.Controls.Add(CmdSupp)
		Me.Controls.Add(CmdAdd)
		Me.Controls.Add(CmdQuit)
		Me.Controls.Add(mskTelephone)
		Me.Controls.Add(mskCellulaire)
		Me.Controls.Add(mskFax)
		Me.Controls.Add(mskPagette)
		Me.Controls.Add(mskTelDomicile)
		Me.Controls.Add(CmdAnul)
		Me.Controls.Add(CmdEnr)
		Me.Controls.Add(_Label1_10)
		Me.Controls.Add(_Label1_9)
		Me.Controls.Add(lblUserModification)
		Me.Controls.Add(lblUserCreation)
		Me.Controls.Add(lblDateModification)
		Me.Controls.Add(lblDateCreation)
		Me.Controls.Add(_Label12_3)
		Me.Controls.Add(_Label12_2)
		Me.Controls.Add(_Label1_8)
		Me.Controls.Add(_Label1_7)
		Me.Controls.Add(lblRechercher)
		Me.Controls.Add(_Label1_6)
		Me.Controls.Add(_Label1_5)
		Me.Controls.Add(_Label1_4)
		Me.Controls.Add(_Label1_3)
		Me.Controls.Add(_Label1_2)
		Me.Controls.Add(_Label1_1)
		Me.Controls.Add(_Label1_0)
		Me.ShapeContainer1.Shapes.Add(Shape1)
		Me.Controls.Add(ShapeContainer1)
		Me.fraEtatOutlook.Controls.Add(lblEtatOutlook)
		Me.Label1.SetIndex(_Label1_10, CType(10, Short))
		Me.Label1.SetIndex(_Label1_9, CType(9, Short))
		Me.Label1.SetIndex(_Label1_8, CType(8, Short))
		Me.Label1.SetIndex(_Label1_7, CType(7, Short))
		Me.Label1.SetIndex(_Label1_6, CType(6, Short))
		Me.Label1.SetIndex(_Label1_5, CType(5, Short))
		Me.Label1.SetIndex(_Label1_4, CType(4, Short))
		Me.Label1.SetIndex(_Label1_3, CType(3, Short))
		Me.Label1.SetIndex(_Label1_2, CType(2, Short))
		Me.Label1.SetIndex(_Label1_1, CType(1, Short))
		Me.Label1.SetIndex(_Label1_0, CType(0, Short))
		Me.Label12.SetIndex(_Label12_3, CType(3, Short))
		Me.Label12.SetIndex(_Label12_2, CType(2, Short))
		CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.fraEtatOutlook.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class