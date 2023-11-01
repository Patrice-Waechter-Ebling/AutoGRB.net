<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmemploye
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
	Public WithEvents cmbFamille As System.Windows.Forms.ComboBox
	Public WithEvents txtFamille As System.Windows.Forms.TextBox
	Public WithEvents cmdAnnulEmploye As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents cmbAjoutEmploye As System.Windows.Forms.ComboBox
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents fraEmploye As System.Windows.Forms.GroupBox
	Public WithEvents cmdSupprimePunch As System.Windows.Forms.Button
	Public WithEvents cmdAjoutPunch As System.Windows.Forms.Button
	Public WithEvents chkActif As System.Windows.Forms.CheckBox
	Public WithEvents cmbEmployePunch As System.Windows.Forms.ComboBox
	Public WithEvents mskPagette As System.Windows.Forms.MaskedTextBox
	Public WithEvents cmdConfig As System.Windows.Forms.Button
	Public WithEvents cmbGroupe As System.Windows.Forms.ComboBox
	Public WithEvents txtpage As System.Windows.Forms.TextBox
	Public WithEvents cmdmodifier As System.Windows.Forms.Button
	Public WithEvents cmdannuler As System.Windows.Forms.Button
	Public WithEvents txtinitiale As System.Windows.Forms.TextBox
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	Public WithEvents txtconfirme As System.Windows.Forms.TextBox
	Public WithEvents cmdsupprimer As System.Windows.Forms.Button
	Public WithEvents cmdajouter As System.Windows.Forms.Button
	Public WithEvents txtpasswd As System.Windows.Forms.TextBox
	Public WithEvents txtuserid As System.Windows.Forms.TextBox
	Public WithEvents cmbEmploye As System.Windows.Forms.ComboBox
	Public WithEvents cmdenregistré As System.Windows.Forms.Button
	Public WithEvents txtemployé As System.Windows.Forms.TextBox
	Public WithEvents txtGroupe As System.Windows.Forms.TextBox
	Public WithEvents mskTelephone As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskCellulaire As System.Windows.Forms.MaskedTextBox
	Public WithEvents txtCell As System.Windows.Forms.TextBox
	Public WithEvents txtTel As System.Windows.Forms.TextBox
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents lblPunchPour As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents lblconfirme As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents lbl As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmemploye))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmbFamille = New System.Windows.Forms.ComboBox
		Me.txtFamille = New System.Windows.Forms.TextBox
		Me.fraEmploye = New System.Windows.Forms.GroupBox
		Me.cmdAnnulEmploye = New System.Windows.Forms.Button
		Me.cmdOK = New System.Windows.Forms.Button
		Me.cmbAjoutEmploye = New System.Windows.Forms.ComboBox
		Me.Label9 = New System.Windows.Forms.Label
		Me.cmdSupprimePunch = New System.Windows.Forms.Button
		Me.cmdAjoutPunch = New System.Windows.Forms.Button
		Me.chkActif = New System.Windows.Forms.CheckBox
		Me.cmbEmployePunch = New System.Windows.Forms.ComboBox
		Me.mskPagette = New System.Windows.Forms.MaskedTextBox
		Me.cmdConfig = New System.Windows.Forms.Button
		Me.cmbGroupe = New System.Windows.Forms.ComboBox
		Me.txtpage = New System.Windows.Forms.TextBox
		Me.cmdmodifier = New System.Windows.Forms.Button
		Me.cmdannuler = New System.Windows.Forms.Button
		Me.txtinitiale = New System.Windows.Forms.TextBox
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.txtconfirme = New System.Windows.Forms.TextBox
		Me.cmdsupprimer = New System.Windows.Forms.Button
		Me.cmdajouter = New System.Windows.Forms.Button
		Me.txtpasswd = New System.Windows.Forms.TextBox
		Me.txtuserid = New System.Windows.Forms.TextBox
		Me.cmbEmploye = New System.Windows.Forms.ComboBox
		Me.cmdenregistré = New System.Windows.Forms.Button
		Me.txtemployé = New System.Windows.Forms.TextBox
		Me.txtGroupe = New System.Windows.Forms.TextBox
		Me.mskTelephone = New System.Windows.Forms.MaskedTextBox
		Me.mskCellulaire = New System.Windows.Forms.MaskedTextBox
		Me.txtCell = New System.Windows.Forms.TextBox
		Me.txtTel = New System.Windows.Forms.TextBox
		Me.Label10 = New System.Windows.Forms.Label
		Me.lblPunchPour = New System.Windows.Forms.Label
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.lblconfirme = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.lbl = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.fraEmploye.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Employés"
		Me.ClientSize = New System.Drawing.Size(390, 426)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.Icon = CType(resources.GetObject("frmemploye.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmemploye.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "frmemploye"
		Me.cmbFamille.BackColor = System.Drawing.Color.White
		Me.cmbFamille.Size = New System.Drawing.Size(177, 21)
		Me.cmbFamille.Location = New System.Drawing.Point(120, 168)
		Me.cmbFamille.Sorted = True
		Me.cmbFamille.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbFamille.TabIndex = 8
		Me.cmbFamille.CausesValidation = True
		Me.cmbFamille.Enabled = True
		Me.cmbFamille.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbFamille.IntegralHeight = True
		Me.cmbFamille.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbFamille.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbFamille.TabStop = True
		Me.cmbFamille.Visible = True
		Me.cmbFamille.Name = "cmbFamille"
		Me.txtFamille.AutoSize = False
		Me.txtFamille.BackColor = System.Drawing.Color.White
		Me.txtFamille.Size = New System.Drawing.Size(169, 19)
		Me.txtFamille.Location = New System.Drawing.Point(120, 168)
		Me.txtFamille.TabIndex = 7
		Me.txtFamille.Visible = False
		Me.txtFamille.AcceptsReturn = True
		Me.txtFamille.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtFamille.CausesValidation = True
		Me.txtFamille.Enabled = True
		Me.txtFamille.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtFamille.HideSelection = True
		Me.txtFamille.ReadOnly = False
		Me.txtFamille.Maxlength = 0
		Me.txtFamille.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtFamille.MultiLine = False
		Me.txtFamille.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtFamille.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtFamille.TabStop = True
		Me.txtFamille.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtFamille.Name = "txtFamille"
		Me.fraEmploye.BackColor = System.Drawing.Color.Black
		Me.fraEmploye.Text = "Ajout d'employé"
		Me.fraEmploye.ForeColor = System.Drawing.Color.White
		Me.fraEmploye.Size = New System.Drawing.Size(273, 105)
		Me.fraEmploye.Location = New System.Drawing.Point(104, 224)
		Me.fraEmploye.TabIndex = 32
		Me.fraEmploye.Visible = False
		Me.fraEmploye.Enabled = True
		Me.fraEmploye.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraEmploye.Padding = New System.Windows.Forms.Padding(0)
		Me.fraEmploye.Name = "fraEmploye"
		Me.cmdAnnulEmploye.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnulEmploye.Text = "Annuler"
		Me.cmdAnnulEmploye.Size = New System.Drawing.Size(65, 25)
		Me.cmdAnnulEmploye.Location = New System.Drawing.Point(112, 72)
		Me.cmdAnnulEmploye.TabIndex = 16
		Me.cmdAnnulEmploye.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnulEmploye.CausesValidation = True
		Me.cmdAnnulEmploye.Enabled = True
		Me.cmdAnnulEmploye.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnulEmploye.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnulEmploye.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnulEmploye.TabStop = True
		Me.cmdAnnulEmploye.Name = "cmdAnnulEmploye"
		Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOK.Text = "OK"
		Me.cmdOK.Size = New System.Drawing.Size(65, 25)
		Me.cmdOK.Location = New System.Drawing.Point(184, 72)
		Me.cmdOK.TabIndex = 17
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me.cmbAjoutEmploye.BackColor = System.Drawing.Color.White
		Me.cmbAjoutEmploye.Size = New System.Drawing.Size(169, 21)
		Me.cmbAjoutEmploye.Location = New System.Drawing.Point(80, 32)
		Me.cmbAjoutEmploye.Sorted = True
		Me.cmbAjoutEmploye.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbAjoutEmploye.TabIndex = 15
		Me.cmbAjoutEmploye.CausesValidation = True
		Me.cmbAjoutEmploye.Enabled = True
		Me.cmbAjoutEmploye.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbAjoutEmploye.IntegralHeight = True
		Me.cmbAjoutEmploye.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbAjoutEmploye.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbAjoutEmploye.TabStop = True
		Me.cmbAjoutEmploye.Visible = True
		Me.cmbAjoutEmploye.Name = "cmbAjoutEmploye"
		Me.Label9.Text = "Employé"
		Me.Label9.ForeColor = System.Drawing.Color.White
		Me.Label9.Size = New System.Drawing.Size(65, 17)
		Me.Label9.Location = New System.Drawing.Point(8, 32)
		Me.Label9.TabIndex = 33
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
		Me.cmdSupprimePunch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSupprimePunch.Text = "Supprimer"
		Me.cmdSupprimePunch.Size = New System.Drawing.Size(73, 25)
		Me.cmdSupprimePunch.Location = New System.Drawing.Point(304, 296)
		Me.cmdSupprimePunch.TabIndex = 14
		Me.cmdSupprimePunch.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSupprimePunch.CausesValidation = True
		Me.cmdSupprimePunch.Enabled = True
		Me.cmdSupprimePunch.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSupprimePunch.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSupprimePunch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSupprimePunch.TabStop = True
		Me.cmdSupprimePunch.Name = "cmdSupprimePunch"
		Me.cmdAjoutPunch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAjoutPunch.Text = "Ajouter"
		Me.cmdAjoutPunch.Size = New System.Drawing.Size(73, 25)
		Me.cmdAjoutPunch.Location = New System.Drawing.Point(304, 272)
		Me.cmdAjoutPunch.TabIndex = 13
		Me.cmdAjoutPunch.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAjoutPunch.CausesValidation = True
		Me.cmdAjoutPunch.Enabled = True
		Me.cmdAjoutPunch.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAjoutPunch.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAjoutPunch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAjoutPunch.TabStop = True
		Me.cmdAjoutPunch.Name = "cmdAjoutPunch"
		Me.chkActif.BackColor = System.Drawing.Color.Black
		Me.chkActif.Text = "Actif"
		Me.chkActif.Enabled = False
		Me.chkActif.ForeColor = System.Drawing.Color.White
		Me.chkActif.Size = New System.Drawing.Size(73, 17)
		Me.chkActif.Location = New System.Drawing.Point(232, 104)
		Me.chkActif.TabIndex = 3
		Me.chkActif.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkActif.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkActif.CausesValidation = True
		Me.chkActif.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkActif.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkActif.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkActif.TabStop = True
		Me.chkActif.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkActif.Visible = True
		Me.chkActif.Name = "chkActif"
		Me.cmbEmployePunch.BackColor = System.Drawing.Color.White
		Me.cmbEmployePunch.Size = New System.Drawing.Size(161, 21)
		Me.cmbEmployePunch.Location = New System.Drawing.Point(128, 272)
		Me.cmbEmployePunch.Sorted = True
		Me.cmbEmployePunch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbEmployePunch.TabIndex = 12
		Me.cmbEmployePunch.CausesValidation = True
		Me.cmbEmployePunch.Enabled = True
		Me.cmbEmployePunch.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbEmployePunch.IntegralHeight = True
		Me.cmbEmployePunch.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbEmployePunch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbEmployePunch.TabStop = True
		Me.cmbEmployePunch.Visible = True
		Me.cmbEmployePunch.Name = "cmbEmployePunch"
		Me.mskPagette.AllowPromptAsInput = False
		Me.mskPagette.Size = New System.Drawing.Size(121, 19)
		Me.mskPagette.Location = New System.Drawing.Point(120, 304)
		Me.mskPagette.TabIndex = 18
		Me.mskPagette.Visible = False
		Me.mskPagette.PromptChar = "_"
		Me.mskPagette.Name = "mskPagette"
		Me.cmdConfig.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdConfig.BackColor = System.Drawing.SystemColors.Control
		Me.cmdConfig.Text = "Configuration"
		Me.cmdConfig.Size = New System.Drawing.Size(73, 25)
		Me.cmdConfig.Location = New System.Drawing.Point(304, 136)
		Me.cmdConfig.TabIndex = 6
		Me.cmdConfig.CausesValidation = True
		Me.cmdConfig.Enabled = True
		Me.cmdConfig.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdConfig.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdConfig.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdConfig.TabStop = True
		Me.cmdConfig.Name = "cmdConfig"
		Me.cmbGroupe.BackColor = System.Drawing.Color.White
		Me.cmbGroupe.Size = New System.Drawing.Size(177, 21)
		Me.cmbGroupe.Location = New System.Drawing.Point(120, 136)
		Me.cmbGroupe.Sorted = True
		Me.cmbGroupe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbGroupe.TabIndex = 5
		Me.cmbGroupe.CausesValidation = True
		Me.cmbGroupe.Enabled = True
		Me.cmbGroupe.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbGroupe.IntegralHeight = True
		Me.cmbGroupe.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbGroupe.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbGroupe.TabStop = True
		Me.cmbGroupe.Visible = True
		Me.cmbGroupe.Name = "cmbGroupe"
		Me.txtpage.AutoSize = False
		Me.txtpage.BackColor = System.Drawing.Color.White
		Me.txtpage.Size = New System.Drawing.Size(121, 19)
		Me.txtpage.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.txtpage.Location = New System.Drawing.Point(120, 304)
		Me.txtpage.ReadOnly = True
		Me.txtpage.TabIndex = 37
		Me.txtpage.AcceptsReturn = True
		Me.txtpage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtpage.CausesValidation = True
		Me.txtpage.Enabled = True
		Me.txtpage.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtpage.HideSelection = True
		Me.txtpage.Maxlength = 0
		Me.txtpage.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtpage.MultiLine = False
		Me.txtpage.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtpage.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtpage.TabStop = True
		Me.txtpage.Visible = True
		Me.txtpage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtpage.Name = "txtpage"
		Me.cmdmodifier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdmodifier.BackColor = System.Drawing.SystemColors.Control
		Me.cmdmodifier.Text = "Modifier"
		Me.cmdmodifier.Size = New System.Drawing.Size(81, 33)
		Me.cmdmodifier.Location = New System.Drawing.Point(104, 384)
		Me.cmdmodifier.TabIndex = 24
		Me.cmdmodifier.CausesValidation = True
		Me.cmdmodifier.Enabled = True
		Me.cmdmodifier.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdmodifier.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdmodifier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdmodifier.TabStop = True
		Me.cmdmodifier.Name = "cmdmodifier"
		Me.cmdannuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdannuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdannuler.Text = "Annuler"
		Me.cmdannuler.Size = New System.Drawing.Size(81, 33)
		Me.cmdannuler.Location = New System.Drawing.Point(104, 384)
		Me.cmdannuler.TabIndex = 23
		Me.cmdannuler.CausesValidation = True
		Me.cmdannuler.Enabled = True
		Me.cmdannuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdannuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdannuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdannuler.TabStop = True
		Me.cmdannuler.Name = "cmdannuler"
		Me.txtinitiale.AutoSize = False
		Me.txtinitiale.BackColor = System.Drawing.Color.White
		Me.txtinitiale.Size = New System.Drawing.Size(49, 19)
		Me.txtinitiale.Location = New System.Drawing.Point(120, 104)
		Me.txtinitiale.ReadOnly = True
		Me.txtinitiale.Maxlength = 3
		Me.txtinitiale.TabIndex = 2
		Me.txtinitiale.AcceptsReturn = True
		Me.txtinitiale.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtinitiale.CausesValidation = True
		Me.txtinitiale.Enabled = True
		Me.txtinitiale.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtinitiale.HideSelection = True
		Me.txtinitiale.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtinitiale.MultiLine = False
		Me.txtinitiale.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtinitiale.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtinitiale.TabStop = True
		Me.txtinitiale.Visible = True
		Me.txtinitiale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtinitiale.Name = "txtinitiale"
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(81, 33)
		Me.cmdFermer.Location = New System.Drawing.Point(296, 384)
		Me.cmdFermer.TabIndex = 26
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.txtconfirme.AutoSize = False
		Me.txtconfirme.BackColor = System.Drawing.Color.White
		Me.txtconfirme.Size = New System.Drawing.Size(161, 19)
		Me.txtconfirme.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.txtconfirme.Location = New System.Drawing.Point(120, 248)
		Me.txtconfirme.PasswordChar = ChrW(42)
		Me.txtconfirme.TabIndex = 11
		Me.txtconfirme.Visible = False
		Me.txtconfirme.AcceptsReturn = True
		Me.txtconfirme.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtconfirme.CausesValidation = True
		Me.txtconfirme.Enabled = True
		Me.txtconfirme.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtconfirme.HideSelection = True
		Me.txtconfirme.ReadOnly = False
		Me.txtconfirme.Maxlength = 0
		Me.txtconfirme.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtconfirme.MultiLine = False
		Me.txtconfirme.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtconfirme.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtconfirme.TabStop = True
		Me.txtconfirme.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtconfirme.Name = "txtconfirme"
		Me.cmdsupprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdsupprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdsupprimer.Text = "Supprimer"
		Me.cmdsupprimer.Size = New System.Drawing.Size(81, 33)
		Me.cmdsupprimer.Location = New System.Drawing.Point(200, 384)
		Me.cmdsupprimer.TabIndex = 25
		Me.cmdsupprimer.CausesValidation = True
		Me.cmdsupprimer.Enabled = True
		Me.cmdsupprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdsupprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdsupprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdsupprimer.TabStop = True
		Me.cmdsupprimer.Name = "cmdsupprimer"
		Me.cmdajouter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdajouter.BackColor = System.Drawing.SystemColors.Control
		Me.cmdajouter.Text = "Ajouter"
		Me.cmdajouter.Size = New System.Drawing.Size(81, 33)
		Me.cmdajouter.Location = New System.Drawing.Point(8, 384)
		Me.cmdajouter.TabIndex = 22
		Me.cmdajouter.CausesValidation = True
		Me.cmdajouter.Enabled = True
		Me.cmdajouter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdajouter.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdajouter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdajouter.TabStop = True
		Me.cmdajouter.Name = "cmdajouter"
		Me.txtpasswd.AutoSize = False
		Me.txtpasswd.BackColor = System.Drawing.Color.White
		Me.txtpasswd.Size = New System.Drawing.Size(161, 19)
		Me.txtpasswd.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.txtpasswd.Location = New System.Drawing.Point(120, 224)
		Me.txtpasswd.ReadOnly = True
		Me.txtpasswd.PasswordChar = ChrW(42)
		Me.txtpasswd.TabIndex = 10
		Me.txtpasswd.AcceptsReturn = True
		Me.txtpasswd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtpasswd.CausesValidation = True
		Me.txtpasswd.Enabled = True
		Me.txtpasswd.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtpasswd.HideSelection = True
		Me.txtpasswd.Maxlength = 0
		Me.txtpasswd.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtpasswd.MultiLine = False
		Me.txtpasswd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtpasswd.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtpasswd.TabStop = True
		Me.txtpasswd.Visible = True
		Me.txtpasswd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtpasswd.Name = "txtpasswd"
		Me.txtuserid.AutoSize = False
		Me.txtuserid.BackColor = System.Drawing.Color.White
		Me.txtuserid.Size = New System.Drawing.Size(161, 19)
		Me.txtuserid.Location = New System.Drawing.Point(120, 200)
		Me.txtuserid.ReadOnly = True
		Me.txtuserid.TabIndex = 9
		Me.txtuserid.AcceptsReturn = True
		Me.txtuserid.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtuserid.CausesValidation = True
		Me.txtuserid.Enabled = True
		Me.txtuserid.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtuserid.HideSelection = True
		Me.txtuserid.Maxlength = 0
		Me.txtuserid.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtuserid.MultiLine = False
		Me.txtuserid.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtuserid.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtuserid.TabStop = True
		Me.txtuserid.Visible = True
		Me.txtuserid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtuserid.Name = "txtuserid"
		Me.cmbEmploye.BackColor = System.Drawing.Color.White
		Me.cmbEmploye.Size = New System.Drawing.Size(169, 21)
		Me.cmbEmploye.Location = New System.Drawing.Point(120, 72)
		Me.cmbEmploye.TabIndex = 1
		Me.cmbEmploye.Text = "cmbEmploye"
		Me.cmbEmploye.CausesValidation = True
		Me.cmbEmploye.Enabled = True
		Me.cmbEmploye.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbEmploye.IntegralHeight = True
		Me.cmbEmploye.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbEmploye.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbEmploye.Sorted = False
		Me.cmbEmploye.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbEmploye.TabStop = True
		Me.cmbEmploye.Visible = True
		Me.cmbEmploye.Name = "cmbEmploye"
		Me.cmdenregistré.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdenregistré.Text = "Enregistrer"
		Me.cmdenregistré.Size = New System.Drawing.Size(81, 33)
		Me.cmdenregistré.Location = New System.Drawing.Point(8, 384)
		Me.cmdenregistré.TabIndex = 21
		Me.cmdenregistré.Visible = False
		Me.cmdenregistré.BackColor = System.Drawing.SystemColors.Control
		Me.cmdenregistré.CausesValidation = True
		Me.cmdenregistré.Enabled = True
		Me.cmdenregistré.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdenregistré.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdenregistré.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdenregistré.TabStop = True
		Me.cmdenregistré.Name = "cmdenregistré"
		Me.txtemployé.AutoSize = False
		Me.txtemployé.BackColor = System.Drawing.Color.White
		Me.txtemployé.Size = New System.Drawing.Size(161, 19)
		Me.txtemployé.Location = New System.Drawing.Point(120, 72)
		Me.txtemployé.TabIndex = 0
		Me.txtemployé.Visible = False
		Me.txtemployé.AcceptsReturn = True
		Me.txtemployé.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtemployé.CausesValidation = True
		Me.txtemployé.Enabled = True
		Me.txtemployé.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtemployé.HideSelection = True
		Me.txtemployé.ReadOnly = False
		Me.txtemployé.Maxlength = 0
		Me.txtemployé.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtemployé.MultiLine = False
		Me.txtemployé.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtemployé.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtemployé.TabStop = True
		Me.txtemployé.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtemployé.Name = "txtemployé"
		Me.txtGroupe.AutoSize = False
		Me.txtGroupe.BackColor = System.Drawing.Color.White
		Me.txtGroupe.Size = New System.Drawing.Size(169, 19)
		Me.txtGroupe.Location = New System.Drawing.Point(120, 136)
		Me.txtGroupe.TabIndex = 4
		Me.txtGroupe.Visible = False
		Me.txtGroupe.AcceptsReturn = True
		Me.txtGroupe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtGroupe.CausesValidation = True
		Me.txtGroupe.Enabled = True
		Me.txtGroupe.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtGroupe.HideSelection = True
		Me.txtGroupe.ReadOnly = False
		Me.txtGroupe.Maxlength = 0
		Me.txtGroupe.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtGroupe.MultiLine = False
		Me.txtGroupe.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtGroupe.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtGroupe.TabStop = True
		Me.txtGroupe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtGroupe.Name = "txtGroupe"
		Me.mskTelephone.AllowPromptAsInput = False
		Me.mskTelephone.Size = New System.Drawing.Size(121, 19)
		Me.mskTelephone.Location = New System.Drawing.Point(120, 328)
		Me.mskTelephone.TabIndex = 19
		Me.mskTelephone.Visible = False
		Me.mskTelephone.PromptChar = "_"
		Me.mskTelephone.Name = "mskTelephone"
		Me.mskCellulaire.AllowPromptAsInput = False
		Me.mskCellulaire.Size = New System.Drawing.Size(121, 19)
		Me.mskCellulaire.Location = New System.Drawing.Point(120, 352)
		Me.mskCellulaire.TabIndex = 20
		Me.mskCellulaire.Visible = False
		Me.mskCellulaire.PromptChar = "_"
		Me.mskCellulaire.Name = "mskCellulaire"
		Me.txtCell.AutoSize = False
		Me.txtCell.BackColor = System.Drawing.Color.White
		Me.txtCell.Size = New System.Drawing.Size(121, 19)
		Me.txtCell.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.txtCell.Location = New System.Drawing.Point(120, 352)
		Me.txtCell.ReadOnly = True
		Me.txtCell.TabIndex = 41
		Me.txtCell.AcceptsReturn = True
		Me.txtCell.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCell.CausesValidation = True
		Me.txtCell.Enabled = True
		Me.txtCell.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCell.HideSelection = True
		Me.txtCell.Maxlength = 0
		Me.txtCell.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCell.MultiLine = False
		Me.txtCell.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCell.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCell.TabStop = True
		Me.txtCell.Visible = True
		Me.txtCell.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCell.Name = "txtCell"
		Me.txtTel.AutoSize = False
		Me.txtTel.BackColor = System.Drawing.Color.White
		Me.txtTel.Size = New System.Drawing.Size(121, 19)
		Me.txtTel.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.txtTel.Location = New System.Drawing.Point(120, 328)
		Me.txtTel.ReadOnly = True
		Me.txtTel.TabIndex = 39
		Me.txtTel.AcceptsReturn = True
		Me.txtTel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTel.CausesValidation = True
		Me.txtTel.Enabled = True
		Me.txtTel.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTel.HideSelection = True
		Me.txtTel.Maxlength = 0
		Me.txtTel.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTel.MultiLine = False
		Me.txtTel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTel.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTel.TabStop = True
		Me.txtTel.Visible = True
		Me.txtTel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTel.Name = "txtTel"
		Me.Label10.Text = "Famille"
		Me.Label10.ForeColor = System.Drawing.Color.White
		Me.Label10.Size = New System.Drawing.Size(73, 17)
		Me.Label10.Location = New System.Drawing.Point(40, 168)
		Me.Label10.TabIndex = 42
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
		Me.lblPunchPour.Text = "Puncher pour :"
		Me.lblPunchPour.ForeColor = System.Drawing.Color.White
		Me.lblPunchPour.Size = New System.Drawing.Size(113, 17)
		Me.lblPunchPour.Location = New System.Drawing.Point(40, 276)
		Me.lblPunchPour.TabIndex = 35
		Me.lblPunchPour.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPunchPour.BackColor = System.Drawing.Color.Transparent
		Me.lblPunchPour.Enabled = True
		Me.lblPunchPour.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPunchPour.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPunchPour.UseMnemonic = True
		Me.lblPunchPour.Visible = True
		Me.lblPunchPour.AutoSize = False
		Me.lblPunchPour.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPunchPour.Name = "lblPunchPour"
		Me.Label8.Text = "Groupe"
		Me.Label8.ForeColor = System.Drawing.Color.White
		Me.Label8.Size = New System.Drawing.Size(73, 17)
		Me.Label8.Location = New System.Drawing.Point(40, 136)
		Me.Label8.TabIndex = 29
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
		Me.Label7.Text = "Cellulaire"
		Me.Label7.ForeColor = System.Drawing.Color.White
		Me.Label7.Size = New System.Drawing.Size(73, 17)
		Me.Label7.Location = New System.Drawing.Point(40, 352)
		Me.Label7.TabIndex = 40
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label7.BackColor = System.Drawing.Color.Transparent
		Me.Label7.Enabled = True
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = False
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Label6.Text = "Téléphone"
		Me.Label6.ForeColor = System.Drawing.Color.White
		Me.Label6.Size = New System.Drawing.Size(73, 17)
		Me.Label6.Location = New System.Drawing.Point(40, 328)
		Me.Label6.TabIndex = 38
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
		Me.Label5.Text = "Pagette"
		Me.Label5.ForeColor = System.Drawing.Color.White
		Me.Label5.Size = New System.Drawing.Size(73, 17)
		Me.Label5.Location = New System.Drawing.Point(40, 304)
		Me.Label5.TabIndex = 36
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
		Me.Label3.Text = "Initiale"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(73, 17)
		Me.Label3.Location = New System.Drawing.Point(40, 104)
		Me.Label3.TabIndex = 28
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
		Me.lblconfirme.Text = "Confirmation"
		Me.lblconfirme.ForeColor = System.Drawing.Color.White
		Me.lblconfirme.Size = New System.Drawing.Size(73, 17)
		Me.lblconfirme.Location = New System.Drawing.Point(40, 248)
		Me.lblconfirme.TabIndex = 34
		Me.lblconfirme.Visible = False
		Me.lblconfirme.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblconfirme.BackColor = System.Drawing.Color.Transparent
		Me.lblconfirme.Enabled = True
		Me.lblconfirme.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblconfirme.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblconfirme.UseMnemonic = True
		Me.lblconfirme.AutoSize = False
		Me.lblconfirme.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblconfirme.Name = "lblconfirme"
		Me.Label2.Text = "Passwd"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(73, 17)
		Me.Label2.Location = New System.Drawing.Point(40, 224)
		Me.Label2.TabIndex = 31
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
		Me.lbl.Text = "User id"
		Me.lbl.ForeColor = System.Drawing.Color.White
		Me.lbl.Size = New System.Drawing.Size(73, 17)
		Me.lbl.Location = New System.Drawing.Point(40, 200)
		Me.lbl.TabIndex = 30
		Me.lbl.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbl.BackColor = System.Drawing.Color.Transparent
		Me.lbl.Enabled = True
		Me.lbl.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbl.UseMnemonic = True
		Me.lbl.Visible = True
		Me.lbl.AutoSize = False
		Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbl.Name = "lbl"
		Me.Label1.Text = "Employé"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(65, 17)
		Me.Label1.Location = New System.Drawing.Point(40, 72)
		Me.Label1.TabIndex = 27
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(cmbFamille)
		Me.Controls.Add(txtFamille)
		Me.Controls.Add(fraEmploye)
		Me.Controls.Add(cmdSupprimePunch)
		Me.Controls.Add(cmdAjoutPunch)
		Me.Controls.Add(chkActif)
		Me.Controls.Add(cmbEmployePunch)
		Me.Controls.Add(mskPagette)
		Me.Controls.Add(cmdConfig)
		Me.Controls.Add(cmbGroupe)
		Me.Controls.Add(txtpage)
		Me.Controls.Add(cmdmodifier)
		Me.Controls.Add(cmdannuler)
		Me.Controls.Add(txtinitiale)
		Me.Controls.Add(cmdFermer)
		Me.Controls.Add(txtconfirme)
		Me.Controls.Add(cmdsupprimer)
		Me.Controls.Add(cmdajouter)
		Me.Controls.Add(txtpasswd)
		Me.Controls.Add(txtuserid)
		Me.Controls.Add(cmbEmploye)
		Me.Controls.Add(cmdenregistré)
		Me.Controls.Add(txtemployé)
		Me.Controls.Add(txtGroupe)
		Me.Controls.Add(mskTelephone)
		Me.Controls.Add(mskCellulaire)
		Me.Controls.Add(txtCell)
		Me.Controls.Add(txtTel)
		Me.Controls.Add(Label10)
		Me.Controls.Add(lblPunchPour)
		Me.Controls.Add(Label8)
		Me.Controls.Add(Label7)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label3)
		Me.Controls.Add(lblconfirme)
		Me.Controls.Add(Label2)
		Me.Controls.Add(lbl)
		Me.Controls.Add(Label1)
		Me.fraEmploye.Controls.Add(cmdAnnulEmploye)
		Me.fraEmploye.Controls.Add(cmdOK)
		Me.fraEmploye.Controls.Add(cmbAjoutEmploye)
		Me.fraEmploye.Controls.Add(Label9)
		Me.fraEmploye.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class