<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmBonCommande
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
	Public WithEvents mvwDate As AxMSComCtl2.AxMonthView
	Public WithEvents txtTotal As System.Windows.Forms.TextBox
	Public WithEvents txtCommentaire As System.Windows.Forms.TextBox
	Public WithEvents cmdInstructions As System.Windows.Forms.Button
	Public WithEvents cmdImprimer As System.Windows.Forms.Button
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	Public WithEvents cmdDate As System.Windows.Forms.Button
	Public WithEvents chkAfficherInstructions As System.Windows.Forms.CheckBox
	Public WithEvents _optImpression_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optImpression_0 As System.Windows.Forms.RadioButton
	Public WithEvents fraImpression As System.Windows.Forms.GroupBox
	Public WithEvents txtComPar As System.Windows.Forms.TextBox
	Public WithEvents txtDate As System.Windows.Forms.TextBox
	Public WithEvents txtNoBC As System.Windows.Forms.TextBox
	Public WithEvents txtFax As System.Windows.Forms.TextBox
	Public WithEvents txtTelephone As System.Windows.Forms.TextBox
	Public WithEvents txtVotreNoSoum As System.Windows.Forms.TextBox
	Public WithEvents txtDateRequise As System.Windows.Forms.TextBox
	Public WithEvents txtTransport As System.Windows.Forms.TextBox
	Public WithEvents cmbContact As System.Windows.Forms.ComboBox
	Public WithEvents cmbFournisseur As System.Windows.Forms.ComboBox
	Public WithEvents _lvwBonCommande_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwBonCommande_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwBonCommande_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwBonCommande_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwBonCommande_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwBonCommande_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwBonCommande_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwBonCommande As System.Windows.Forms.ListView
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents lblNoBC As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents lblVotreNoSoum As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents optImpression As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBonCommande))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.mvwDate = New AxMSComCtl2.AxMonthView
		Me.txtTotal = New System.Windows.Forms.TextBox
		Me.txtCommentaire = New System.Windows.Forms.TextBox
		Me.cmdInstructions = New System.Windows.Forms.Button
		Me.cmdImprimer = New System.Windows.Forms.Button
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.cmdDate = New System.Windows.Forms.Button
		Me.chkAfficherInstructions = New System.Windows.Forms.CheckBox
		Me.fraImpression = New System.Windows.Forms.GroupBox
		Me._optImpression_1 = New System.Windows.Forms.RadioButton
		Me._optImpression_0 = New System.Windows.Forms.RadioButton
		Me.txtComPar = New System.Windows.Forms.TextBox
		Me.txtDate = New System.Windows.Forms.TextBox
		Me.txtNoBC = New System.Windows.Forms.TextBox
		Me.txtFax = New System.Windows.Forms.TextBox
		Me.txtTelephone = New System.Windows.Forms.TextBox
		Me.txtVotreNoSoum = New System.Windows.Forms.TextBox
		Me.txtDateRequise = New System.Windows.Forms.TextBox
		Me.txtTransport = New System.Windows.Forms.TextBox
		Me.cmbContact = New System.Windows.Forms.ComboBox
		Me.cmbFournisseur = New System.Windows.Forms.ComboBox
		Me.lvwBonCommande = New System.Windows.Forms.ListView
		Me._lvwBonCommande_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwBonCommande_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwBonCommande_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwBonCommande_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwBonCommande_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvwBonCommande_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me._lvwBonCommande_ColumnHeader_7 = New System.Windows.Forms.ColumnHeader
		Me.Label12 = New System.Windows.Forms.Label
		Me.Label11 = New System.Windows.Forms.Label
		Me.Label10 = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.lblNoBC = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.lblVotreNoSoum = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.optImpression = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.fraImpression.SuspendLayout()
		Me.lvwBonCommande.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optImpression, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Bon de commande"
		Me.ClientSize = New System.Drawing.Size(650, 523)
		Me.Location = New System.Drawing.Point(-1, -1)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmBonCommande.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmBonCommande"
		mvwDate.OcxState = CType(resources.GetObject("mvwDate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwDate.Size = New System.Drawing.Size(176, 158)
		Me.mvwDate.Location = New System.Drawing.Point(128, 56)
		Me.mvwDate.TabIndex = 1
		Me.mvwDate.Visible = False
		Me.mvwDate.Name = "mvwDate"
		Me.txtTotal.AutoSize = False
		Me.txtTotal.Size = New System.Drawing.Size(65, 19)
		Me.txtTotal.Location = New System.Drawing.Point(576, 448)
		Me.txtTotal.ReadOnly = True
		Me.txtTotal.TabIndex = 29
		Me.txtTotal.AcceptsReturn = True
		Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTotal.BackColor = System.Drawing.SystemColors.Window
		Me.txtTotal.CausesValidation = True
		Me.txtTotal.Enabled = True
		Me.txtTotal.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTotal.HideSelection = True
		Me.txtTotal.Maxlength = 0
		Me.txtTotal.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTotal.MultiLine = False
		Me.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTotal.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTotal.TabStop = True
		Me.txtTotal.Visible = True
		Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTotal.Name = "txtTotal"
		Me.txtCommentaire.AutoSize = False
		Me.txtCommentaire.Size = New System.Drawing.Size(361, 41)
		Me.txtCommentaire.Location = New System.Drawing.Point(8, 464)
		Me.txtCommentaire.MultiLine = True
		Me.txtCommentaire.TabIndex = 31
		Me.txtCommentaire.Text = "Text1"
		Me.txtCommentaire.AcceptsReturn = True
		Me.txtCommentaire.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCommentaire.BackColor = System.Drawing.SystemColors.Window
		Me.txtCommentaire.CausesValidation = True
		Me.txtCommentaire.Enabled = True
		Me.txtCommentaire.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCommentaire.HideSelection = True
		Me.txtCommentaire.ReadOnly = False
		Me.txtCommentaire.Maxlength = 0
		Me.txtCommentaire.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCommentaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCommentaire.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCommentaire.TabStop = True
		Me.txtCommentaire.Visible = True
		Me.txtCommentaire.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCommentaire.Name = "txtCommentaire"
		Me.cmdInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdInstructions.Text = "Modifier"
		Me.cmdInstructions.Size = New System.Drawing.Size(81, 25)
		Me.cmdInstructions.Location = New System.Drawing.Point(352, 184)
		Me.cmdInstructions.TabIndex = 26
		Me.cmdInstructions.BackColor = System.Drawing.SystemColors.Control
		Me.cmdInstructions.CausesValidation = True
		Me.cmdInstructions.Enabled = True
		Me.cmdInstructions.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdInstructions.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdInstructions.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdInstructions.TabStop = True
		Me.cmdInstructions.Name = "cmdInstructions"
		Me.cmdImprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdImprimer.Text = "Imprimer"
		Me.cmdImprimer.Size = New System.Drawing.Size(81, 25)
		Me.cmdImprimer.Location = New System.Drawing.Point(472, 488)
		Me.cmdImprimer.TabIndex = 32
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
		Me.cmdFermer.Size = New System.Drawing.Size(81, 25)
		Me.cmdFermer.Location = New System.Drawing.Point(560, 488)
		Me.cmdFermer.TabIndex = 33
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.cmdDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDate.Text = "..."
		Me.cmdDate.Size = New System.Drawing.Size(25, 19)
		Me.cmdDate.Location = New System.Drawing.Point(208, 168)
		Me.cmdDate.TabIndex = 21
		Me.cmdDate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDate.CausesValidation = True
		Me.cmdDate.Enabled = True
		Me.cmdDate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDate.TabStop = True
		Me.cmdDate.Name = "cmdDate"
		Me.chkAfficherInstructions.BackColor = System.Drawing.Color.Black
		Me.chkAfficherInstructions.Text = "Afficher les instructions de livraison"
		Me.chkAfficherInstructions.ForeColor = System.Drawing.Color.White
		Me.chkAfficherInstructions.Size = New System.Drawing.Size(185, 17)
		Me.chkAfficherInstructions.Location = New System.Drawing.Point(248, 168)
		Me.chkAfficherInstructions.TabIndex = 22
		Me.chkAfficherInstructions.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkAfficherInstructions.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkAfficherInstructions.CausesValidation = True
		Me.chkAfficherInstructions.Enabled = True
		Me.chkAfficherInstructions.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkAfficherInstructions.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkAfficherInstructions.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkAfficherInstructions.TabStop = True
		Me.chkAfficherInstructions.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkAfficherInstructions.Visible = True
		Me.chkAfficherInstructions.Name = "chkAfficherInstructions"
		Me.fraImpression.BackColor = System.Drawing.Color.Black
		Me.fraImpression.Text = "Impression"
		Me.fraImpression.ForeColor = System.Drawing.Color.White
		Me.fraImpression.Size = New System.Drawing.Size(169, 49)
		Me.fraImpression.Location = New System.Drawing.Point(472, 160)
		Me.fraImpression.TabIndex = 23
		Me.fraImpression.Enabled = True
		Me.fraImpression.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraImpression.Visible = True
		Me.fraImpression.Padding = New System.Windows.Forms.Padding(0)
		Me.fraImpression.Name = "fraImpression"
		Me._optImpression_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optImpression_1.BackColor = System.Drawing.Color.Black
		Me._optImpression_1.Text = "Anglais"
		Me._optImpression_1.ForeColor = System.Drawing.Color.White
		Me._optImpression_1.Size = New System.Drawing.Size(129, 13)
		Me._optImpression_1.Location = New System.Drawing.Point(16, 32)
		Me._optImpression_1.TabIndex = 25
		Me._optImpression_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optImpression_1.CausesValidation = True
		Me._optImpression_1.Enabled = True
		Me._optImpression_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optImpression_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optImpression_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optImpression_1.TabStop = True
		Me._optImpression_1.Checked = False
		Me._optImpression_1.Visible = True
		Me._optImpression_1.Name = "_optImpression_1"
		Me._optImpression_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optImpression_0.BackColor = System.Drawing.Color.Black
		Me._optImpression_0.Text = "Français"
		Me._optImpression_0.ForeColor = System.Drawing.Color.White
		Me._optImpression_0.Size = New System.Drawing.Size(129, 13)
		Me._optImpression_0.Location = New System.Drawing.Point(16, 16)
		Me._optImpression_0.TabIndex = 24
		Me._optImpression_0.Checked = True
		Me._optImpression_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optImpression_0.CausesValidation = True
		Me._optImpression_0.Enabled = True
		Me._optImpression_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optImpression_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optImpression_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optImpression_0.TabStop = True
		Me._optImpression_0.Visible = True
		Me._optImpression_0.Name = "_optImpression_0"
		Me.txtComPar.AutoSize = False
		Me.txtComPar.Size = New System.Drawing.Size(121, 19)
		Me.txtComPar.Location = New System.Drawing.Point(520, 136)
		Me.txtComPar.ReadOnly = True
		Me.txtComPar.TabIndex = 18
		Me.txtComPar.AcceptsReturn = True
		Me.txtComPar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtComPar.BackColor = System.Drawing.SystemColors.Window
		Me.txtComPar.CausesValidation = True
		Me.txtComPar.Enabled = True
		Me.txtComPar.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtComPar.HideSelection = True
		Me.txtComPar.Maxlength = 0
		Me.txtComPar.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtComPar.MultiLine = False
		Me.txtComPar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtComPar.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtComPar.TabStop = True
		Me.txtComPar.Visible = True
		Me.txtComPar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtComPar.Name = "txtComPar"
		Me.txtDate.AutoSize = False
		Me.txtDate.Size = New System.Drawing.Size(121, 19)
		Me.txtDate.Location = New System.Drawing.Point(520, 104)
		Me.txtDate.ReadOnly = True
		Me.txtDate.TabIndex = 12
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
		Me.txtNoBC.AutoSize = False
		Me.txtNoBC.Size = New System.Drawing.Size(121, 19)
		Me.txtNoBC.Location = New System.Drawing.Point(520, 72)
		Me.txtNoBC.ReadOnly = True
		Me.txtNoBC.TabIndex = 6
		Me.txtNoBC.AcceptsReturn = True
		Me.txtNoBC.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoBC.BackColor = System.Drawing.SystemColors.Window
		Me.txtNoBC.CausesValidation = True
		Me.txtNoBC.Enabled = True
		Me.txtNoBC.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNoBC.HideSelection = True
		Me.txtNoBC.Maxlength = 0
		Me.txtNoBC.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNoBC.MultiLine = False
		Me.txtNoBC.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNoBC.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNoBC.TabStop = True
		Me.txtNoBC.Visible = True
		Me.txtNoBC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoBC.Name = "txtNoBC"
		Me.txtFax.AutoSize = False
		Me.txtFax.Size = New System.Drawing.Size(121, 19)
		Me.txtFax.Location = New System.Drawing.Point(296, 136)
		Me.txtFax.ReadOnly = True
		Me.txtFax.TabIndex = 16
		Me.txtFax.AcceptsReturn = True
		Me.txtFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtFax.BackColor = System.Drawing.SystemColors.Window
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
		Me.txtTelephone.Size = New System.Drawing.Size(121, 19)
		Me.txtTelephone.Location = New System.Drawing.Point(296, 104)
		Me.txtTelephone.ReadOnly = True
		Me.txtTelephone.TabIndex = 10
		Me.txtTelephone.AcceptsReturn = True
		Me.txtTelephone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTelephone.BackColor = System.Drawing.SystemColors.Window
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
		Me.txtVotreNoSoum.AutoSize = False
		Me.txtVotreNoSoum.Size = New System.Drawing.Size(121, 19)
		Me.txtVotreNoSoum.Location = New System.Drawing.Point(296, 72)
		Me.txtVotreNoSoum.TabIndex = 4
		Me.txtVotreNoSoum.AcceptsReturn = True
		Me.txtVotreNoSoum.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtVotreNoSoum.BackColor = System.Drawing.SystemColors.Window
		Me.txtVotreNoSoum.CausesValidation = True
		Me.txtVotreNoSoum.Enabled = True
		Me.txtVotreNoSoum.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtVotreNoSoum.HideSelection = True
		Me.txtVotreNoSoum.ReadOnly = False
		Me.txtVotreNoSoum.Maxlength = 0
		Me.txtVotreNoSoum.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtVotreNoSoum.MultiLine = False
		Me.txtVotreNoSoum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtVotreNoSoum.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtVotreNoSoum.TabStop = True
		Me.txtVotreNoSoum.Visible = True
		Me.txtVotreNoSoum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtVotreNoSoum.Name = "txtVotreNoSoum"
		Me.txtDateRequise.AutoSize = False
		Me.txtDateRequise.Size = New System.Drawing.Size(121, 19)
		Me.txtDateRequise.Location = New System.Drawing.Point(80, 168)
		Me.txtDateRequise.ReadOnly = True
		Me.txtDateRequise.TabIndex = 20
		Me.txtDateRequise.AcceptsReturn = True
		Me.txtDateRequise.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDateRequise.BackColor = System.Drawing.SystemColors.Window
		Me.txtDateRequise.CausesValidation = True
		Me.txtDateRequise.Enabled = True
		Me.txtDateRequise.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDateRequise.HideSelection = True
		Me.txtDateRequise.Maxlength = 0
		Me.txtDateRequise.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDateRequise.MultiLine = False
		Me.txtDateRequise.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDateRequise.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDateRequise.TabStop = True
		Me.txtDateRequise.Visible = True
		Me.txtDateRequise.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDateRequise.Name = "txtDateRequise"
		Me.txtTransport.AutoSize = False
		Me.txtTransport.Size = New System.Drawing.Size(121, 19)
		Me.txtTransport.Location = New System.Drawing.Point(80, 136)
		Me.txtTransport.TabIndex = 14
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
		Me.cmbContact.Size = New System.Drawing.Size(121, 21)
		Me.cmbContact.Location = New System.Drawing.Point(80, 104)
		Me.cmbContact.TabIndex = 8
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
		Me.cmbFournisseur.Size = New System.Drawing.Size(121, 21)
		Me.cmbFournisseur.Location = New System.Drawing.Point(80, 72)
		Me.cmbFournisseur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbFournisseur.TabIndex = 2
		Me.cmbFournisseur.BackColor = System.Drawing.SystemColors.Window
		Me.cmbFournisseur.CausesValidation = True
		Me.cmbFournisseur.Enabled = True
		Me.cmbFournisseur.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbFournisseur.IntegralHeight = True
		Me.cmbFournisseur.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbFournisseur.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbFournisseur.Sorted = False
		Me.cmbFournisseur.TabStop = True
		Me.cmbFournisseur.Visible = True
		Me.cmbFournisseur.Name = "cmbFournisseur"
		Me.lvwBonCommande.Size = New System.Drawing.Size(633, 225)
		Me.lvwBonCommande.Location = New System.Drawing.Point(8, 216)
		Me.lvwBonCommande.TabIndex = 27
		Me.lvwBonCommande.View = System.Windows.Forms.View.Details
		Me.lvwBonCommande.LabelEdit = False
		Me.lvwBonCommande.LabelWrap = True
		Me.lvwBonCommande.HideSelection = True
		Me.lvwBonCommande.FullRowSelect = True
		Me.lvwBonCommande.GridLines = True
		Me.lvwBonCommande.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwBonCommande.BackColor = System.Drawing.SystemColors.Window
		Me.lvwBonCommande.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwBonCommande.Name = "lvwBonCommande"
		Me._lvwBonCommande_ColumnHeader_1.Text = "Qté"
		Me._lvwBonCommande_ColumnHeader_1.Width = 170
		Me._lvwBonCommande_ColumnHeader_2.Text = "No Item"
		Me._lvwBonCommande_ColumnHeader_2.Width = 170
		Me._lvwBonCommande_ColumnHeader_3.Text = "Description"
		Me._lvwBonCommande_ColumnHeader_3.Width = 170
		Me._lvwBonCommande_ColumnHeader_4.Text = "Manufact"
		Me._lvwBonCommande_ColumnHeader_4.Width = 170
		Me._lvwBonCommande_ColumnHeader_5.Text = "Prix"
		Me._lvwBonCommande_ColumnHeader_5.Width = 170
		Me._lvwBonCommande_ColumnHeader_6.Text = "Escompte"
		Me._lvwBonCommande_ColumnHeader_6.Width = 170
		Me._lvwBonCommande_ColumnHeader_7.Text = "Total"
		Me._lvwBonCommande_ColumnHeader_7.Width = 170
		Me.Label12.BackColor = System.Drawing.Color.Black
		Me.Label12.Text = "TOTAL :"
		Me.Label12.ForeColor = System.Drawing.Color.White
		Me.Label12.Size = New System.Drawing.Size(57, 17)
		Me.Label12.Location = New System.Drawing.Point(520, 448)
		Me.Label12.TabIndex = 30
		Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label12.Enabled = True
		Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label12.UseMnemonic = True
		Me.Label12.Visible = True
		Me.Label12.AutoSize = False
		Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label12.Name = "Label12"
		Me.Label11.BackColor = System.Drawing.Color.Black
		Me.Label11.Text = "Commentaires :"
		Me.Label11.ForeColor = System.Drawing.Color.White
		Me.Label11.Size = New System.Drawing.Size(105, 17)
		Me.Label11.Location = New System.Drawing.Point(8, 448)
		Me.Label11.TabIndex = 28
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label11.Enabled = True
		Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label11.UseMnemonic = True
		Me.Label11.Visible = True
		Me.Label11.AutoSize = False
		Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label11.Name = "Label11"
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label10.Text = "Commandé par :"
		Me.Label10.ForeColor = System.Drawing.Color.White
		Me.Label10.Size = New System.Drawing.Size(81, 17)
		Me.Label10.Location = New System.Drawing.Point(432, 136)
		Me.Label10.TabIndex = 17
		Me.Label10.BackColor = System.Drawing.Color.Transparent
		Me.Label10.Enabled = True
		Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label10.UseMnemonic = True
		Me.Label10.Visible = True
		Me.Label10.AutoSize = False
		Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label10.Name = "Label10"
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label9.Text = "Date :"
		Me.Label9.ForeColor = System.Drawing.Color.White
		Me.Label9.Size = New System.Drawing.Size(81, 17)
		Me.Label9.Location = New System.Drawing.Point(432, 104)
		Me.Label9.TabIndex = 11
		Me.Label9.BackColor = System.Drawing.Color.Transparent
		Me.Label9.Enabled = True
		Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label9.UseMnemonic = True
		Me.Label9.Visible = True
		Me.Label9.AutoSize = False
		Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label9.Name = "Label9"
		Me.lblNoBC.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblNoBC.Text = "# BC :"
		Me.lblNoBC.ForeColor = System.Drawing.Color.White
		Me.lblNoBC.Size = New System.Drawing.Size(81, 17)
		Me.lblNoBC.Location = New System.Drawing.Point(432, 72)
		Me.lblNoBC.TabIndex = 5
		Me.lblNoBC.BackColor = System.Drawing.Color.Transparent
		Me.lblNoBC.Enabled = True
		Me.lblNoBC.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblNoBC.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblNoBC.UseMnemonic = True
		Me.lblNoBC.Visible = True
		Me.lblNoBC.AutoSize = False
		Me.lblNoBC.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblNoBC.Name = "lblNoBC"
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label7.Text = "Fax :"
		Me.Label7.ForeColor = System.Drawing.Color.White
		Me.Label7.Size = New System.Drawing.Size(81, 17)
		Me.Label7.Location = New System.Drawing.Point(208, 136)
		Me.Label7.TabIndex = 15
		Me.Label7.BackColor = System.Drawing.Color.Transparent
		Me.Label7.Enabled = True
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = False
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label6.Text = "Téléphone :"
		Me.Label6.ForeColor = System.Drawing.Color.White
		Me.Label6.Size = New System.Drawing.Size(81, 17)
		Me.Label6.Location = New System.Drawing.Point(208, 104)
		Me.Label6.TabIndex = 9
		Me.Label6.BackColor = System.Drawing.Color.Transparent
		Me.Label6.Enabled = True
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = False
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.lblVotreNoSoum.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblVotreNoSoum.Text = "Votre # Soum :"
		Me.lblVotreNoSoum.ForeColor = System.Drawing.Color.White
		Me.lblVotreNoSoum.Size = New System.Drawing.Size(81, 17)
		Me.lblVotreNoSoum.Location = New System.Drawing.Point(208, 72)
		Me.lblVotreNoSoum.TabIndex = 3
		Me.lblVotreNoSoum.BackColor = System.Drawing.Color.Transparent
		Me.lblVotreNoSoum.Enabled = True
		Me.lblVotreNoSoum.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblVotreNoSoum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblVotreNoSoum.UseMnemonic = True
		Me.lblVotreNoSoum.Visible = True
		Me.lblVotreNoSoum.AutoSize = False
		Me.lblVotreNoSoum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblVotreNoSoum.Name = "lblVotreNoSoum"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label4.Text = "Date Requise :"
		Me.Label4.ForeColor = System.Drawing.Color.White
		Me.Label4.Size = New System.Drawing.Size(73, 17)
		Me.Label4.Location = New System.Drawing.Point(0, 168)
		Me.Label4.TabIndex = 19
		Me.Label4.BackColor = System.Drawing.Color.Transparent
		Me.Label4.Enabled = True
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label3.Text = "Transport :"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(73, 17)
		Me.Label3.Location = New System.Drawing.Point(0, 136)
		Me.Label3.TabIndex = 13
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Enabled = True
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label2.Text = "Contacts :"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(73, 17)
		Me.Label2.Location = New System.Drawing.Point(0, 104)
		Me.Label2.TabIndex = 7
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label1.Text = "Fournisseurs :"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(73, 17)
		Me.Label1.Location = New System.Drawing.Point(0, 72)
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
		Me.Controls.Add(mvwDate)
		Me.Controls.Add(txtTotal)
		Me.Controls.Add(txtCommentaire)
		Me.Controls.Add(cmdInstructions)
		Me.Controls.Add(cmdImprimer)
		Me.Controls.Add(cmdFermer)
		Me.Controls.Add(cmdDate)
		Me.Controls.Add(chkAfficherInstructions)
		Me.Controls.Add(fraImpression)
		Me.Controls.Add(txtComPar)
		Me.Controls.Add(txtDate)
		Me.Controls.Add(txtNoBC)
		Me.Controls.Add(txtFax)
		Me.Controls.Add(txtTelephone)
		Me.Controls.Add(txtVotreNoSoum)
		Me.Controls.Add(txtDateRequise)
		Me.Controls.Add(txtTransport)
		Me.Controls.Add(cmbContact)
		Me.Controls.Add(cmbFournisseur)
		Me.Controls.Add(lvwBonCommande)
		Me.Controls.Add(Label12)
		Me.Controls.Add(Label11)
		Me.Controls.Add(Label10)
		Me.Controls.Add(Label9)
		Me.Controls.Add(lblNoBC)
		Me.Controls.Add(Label7)
		Me.Controls.Add(Label6)
		Me.Controls.Add(lblVotreNoSoum)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.fraImpression.Controls.Add(_optImpression_1)
		Me.fraImpression.Controls.Add(_optImpression_0)
		Me.lvwBonCommande.Columns.Add(_lvwBonCommande_ColumnHeader_1)
		Me.lvwBonCommande.Columns.Add(_lvwBonCommande_ColumnHeader_2)
		Me.lvwBonCommande.Columns.Add(_lvwBonCommande_ColumnHeader_3)
		Me.lvwBonCommande.Columns.Add(_lvwBonCommande_ColumnHeader_4)
		Me.lvwBonCommande.Columns.Add(_lvwBonCommande_ColumnHeader_5)
		Me.lvwBonCommande.Columns.Add(_lvwBonCommande_ColumnHeader_6)
		Me.lvwBonCommande.Columns.Add(_lvwBonCommande_ColumnHeader_7)
		Me.optImpression.SetIndex(_optImpression_1, CType(1, Short))
		Me.optImpression.SetIndex(_optImpression_0, CType(0, Short))
		CType(Me.optImpression, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).EndInit()
		Me.fraImpression.ResumeLayout(False)
		Me.lvwBonCommande.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class