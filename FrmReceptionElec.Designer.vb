<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FrmReceptionElec
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
	Public WithEvents cmdNonRecu As System.Windows.Forms.Button
	Public WithEvents mvwReception As AxMSComCtl2.AxMonthView
	Public WithEvents mvwDateRequise As AxMSComCtl2.AxMonthView
	Public WithEvents chkProjetAchat As System.Windows.Forms.CheckBox
	Public WithEvents chkDateRequise As System.Windows.Forms.CheckBox
	Public WithEvents txtProjetAchat As System.Windows.Forms.TextBox
	Public WithEvents cmdImprimerPieces As System.Windows.Forms.Button
	Public WithEvents cmdFermerPieces As System.Windows.Forms.Button
	Public WithEvents cmdAfficher As System.Windows.Forms.Button
	Public WithEvents _lvwPieces_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwPieces As System.Windows.Forms.ListView
	Public WithEvents txtDateRequise As System.Windows.Forms.TextBox
	Public WithEvents cmdDateRequise As System.Windows.Forms.Button
	Public WithEvents fraPiecesNonRecues As System.Windows.Forms.GroupBox
	Public WithEvents cmdImprimer As System.Windows.Forms.Button
	Public WithEvents cmbType As System.Windows.Forms.ComboBox
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents cmbNoProjet As System.Windows.Forms.ComboBox
	Public WithEvents txtNoProjet As System.Windows.Forms.TextBox
	Public WithEvents _lvwProjet_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjet_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjet_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjet_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjet_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjet_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjet_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjet_ColumnHeader_8 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwProjet As System.Windows.Forms.ListView
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	Public WithEvents cmdDate As System.Windows.Forms.Button
	Public WithEvents txtDateReception As System.Windows.Forms.TextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmReceptionElec))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdNonRecu = New System.Windows.Forms.Button
		Me.mvwReception = New AxMSComCtl2.AxMonthView
		Me.fraPiecesNonRecues = New System.Windows.Forms.GroupBox
		Me.mvwDateRequise = New AxMSComCtl2.AxMonthView
		Me.chkProjetAchat = New System.Windows.Forms.CheckBox
		Me.chkDateRequise = New System.Windows.Forms.CheckBox
		Me.txtProjetAchat = New System.Windows.Forms.TextBox
		Me.cmdImprimerPieces = New System.Windows.Forms.Button
		Me.cmdFermerPieces = New System.Windows.Forms.Button
		Me.cmdAfficher = New System.Windows.Forms.Button
		Me.lvwPieces = New System.Windows.Forms.ListView
		Me._lvwPieces_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_7 = New System.Windows.Forms.ColumnHeader
		Me.txtDateRequise = New System.Windows.Forms.TextBox
		Me.cmdDateRequise = New System.Windows.Forms.Button
		Me.cmdImprimer = New System.Windows.Forms.Button
		Me.cmbType = New System.Windows.Forms.ComboBox
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.cmbNoProjet = New System.Windows.Forms.ComboBox
		Me.txtNoProjet = New System.Windows.Forms.TextBox
		Me.lvwProjet = New System.Windows.Forms.ListView
		Me._lvwProjet_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjet_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjet_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjet_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjet_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjet_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjet_ColumnHeader_7 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjet_ColumnHeader_8 = New System.Windows.Forms.ColumnHeader
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.cmdDate = New System.Windows.Forms.Button
		Me.txtDateReception = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.fraPiecesNonRecues.SuspendLayout()
		Me.lvwPieces.SuspendLayout()
		Me.lvwProjet.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.mvwReception, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.mvwDateRequise, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Réception électrique"
		Me.ClientSize = New System.Drawing.Size(793, 517)
		Me.Location = New System.Drawing.Point(14, 42)
		Me.Icon = CType(resources.GetObject("FrmReceptionElec.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("FrmReceptionElec.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "FrmReceptionElec"
		Me.cmdNonRecu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNonRecu.Text = "Pièces non recues"
		Me.cmdNonRecu.Size = New System.Drawing.Size(113, 25)
		Me.cmdNonRecu.Location = New System.Drawing.Point(240, 488)
		Me.cmdNonRecu.TabIndex = 18
		Me.cmdNonRecu.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNonRecu.CausesValidation = True
		Me.cmdNonRecu.Enabled = True
		Me.cmdNonRecu.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNonRecu.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNonRecu.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNonRecu.TabStop = True
		Me.cmdNonRecu.Name = "cmdNonRecu"
		mvwReception.OcxState = CType(resources.GetObject("mvwReception.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwReception.Size = New System.Drawing.Size(176, 158)
		Me.mvwReception.Location = New System.Drawing.Point(616, 8)
		Me.mvwReception.TabIndex = 3
		Me.mvwReception.Visible = False
		Me.mvwReception.Name = "mvwReception"
		Me.fraPiecesNonRecues.BackColor = System.Drawing.Color.Black
		Me.fraPiecesNonRecues.Size = New System.Drawing.Size(777, 417)
		Me.fraPiecesNonRecues.Location = New System.Drawing.Point(8, 64)
		Me.fraPiecesNonRecues.TabIndex = 7
		Me.fraPiecesNonRecues.Visible = False
		Me.fraPiecesNonRecues.Enabled = True
		Me.fraPiecesNonRecues.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraPiecesNonRecues.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraPiecesNonRecues.Padding = New System.Windows.Forms.Padding(0)
		Me.fraPiecesNonRecues.Name = "fraPiecesNonRecues"
		mvwDateRequise.OcxState = CType(resources.GetObject("mvwDateRequise.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwDateRequise.Size = New System.Drawing.Size(176, 158)
		Me.mvwDateRequise.Location = New System.Drawing.Point(184, 0)
		Me.mvwDateRequise.TabIndex = 8
		Me.mvwDateRequise.Visible = False
		Me.mvwDateRequise.Name = "mvwDateRequise"
		Me.chkProjetAchat.BackColor = System.Drawing.Color.Black
		Me.chkProjetAchat.Text = "Projet :"
		Me.chkProjetAchat.ForeColor = System.Drawing.Color.White
		Me.chkProjetAchat.Size = New System.Drawing.Size(105, 17)
		Me.chkProjetAchat.Location = New System.Drawing.Point(8, 48)
		Me.chkProjetAchat.TabIndex = 22
		Me.chkProjetAchat.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkProjetAchat.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkProjetAchat.CausesValidation = True
		Me.chkProjetAchat.Enabled = True
		Me.chkProjetAchat.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkProjetAchat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkProjetAchat.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkProjetAchat.TabStop = True
		Me.chkProjetAchat.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkProjetAchat.Visible = True
		Me.chkProjetAchat.Name = "chkProjetAchat"
		Me.chkDateRequise.BackColor = System.Drawing.Color.Black
		Me.chkDateRequise.Text = "Date Requise :"
		Me.chkDateRequise.ForeColor = System.Drawing.Color.White
		Me.chkDateRequise.Size = New System.Drawing.Size(105, 17)
		Me.chkDateRequise.Location = New System.Drawing.Point(8, 16)
		Me.chkDateRequise.TabIndex = 21
		Me.chkDateRequise.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkDateRequise.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkDateRequise.CausesValidation = True
		Me.chkDateRequise.Enabled = True
		Me.chkDateRequise.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkDateRequise.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkDateRequise.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkDateRequise.TabStop = True
		Me.chkDateRequise.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkDateRequise.Visible = True
		Me.chkDateRequise.Name = "chkDateRequise"
		Me.txtProjetAchat.AutoSize = False
		Me.txtProjetAchat.Enabled = False
		Me.txtProjetAchat.Size = New System.Drawing.Size(97, 19)
		Me.txtProjetAchat.Location = New System.Drawing.Point(112, 48)
		Me.txtProjetAchat.TabIndex = 20
		Me.txtProjetAchat.AcceptsReturn = True
		Me.txtProjetAchat.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtProjetAchat.BackColor = System.Drawing.SystemColors.Window
		Me.txtProjetAchat.CausesValidation = True
		Me.txtProjetAchat.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtProjetAchat.HideSelection = True
		Me.txtProjetAchat.ReadOnly = False
		Me.txtProjetAchat.Maxlength = 0
		Me.txtProjetAchat.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtProjetAchat.MultiLine = False
		Me.txtProjetAchat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtProjetAchat.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtProjetAchat.TabStop = True
		Me.txtProjetAchat.Visible = True
		Me.txtProjetAchat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtProjetAchat.Name = "txtProjetAchat"
		Me.cmdImprimerPieces.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdImprimerPieces.Text = "Imprimer"
		Me.cmdImprimerPieces.Size = New System.Drawing.Size(105, 25)
		Me.cmdImprimerPieces.Location = New System.Drawing.Point(8, 384)
		Me.cmdImprimerPieces.TabIndex = 13
		Me.cmdImprimerPieces.BackColor = System.Drawing.SystemColors.Control
		Me.cmdImprimerPieces.CausesValidation = True
		Me.cmdImprimerPieces.Enabled = True
		Me.cmdImprimerPieces.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdImprimerPieces.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdImprimerPieces.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdImprimerPieces.TabStop = True
		Me.cmdImprimerPieces.Name = "cmdImprimerPieces"
		Me.cmdFermerPieces.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermerPieces.Text = "Fermer"
		Me.cmdFermerPieces.Size = New System.Drawing.Size(105, 25)
		Me.cmdFermerPieces.Location = New System.Drawing.Point(664, 384)
		Me.cmdFermerPieces.TabIndex = 14
		Me.cmdFermerPieces.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermerPieces.CausesValidation = True
		Me.cmdFermerPieces.Enabled = True
		Me.cmdFermerPieces.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermerPieces.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermerPieces.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermerPieces.TabStop = True
		Me.cmdFermerPieces.Name = "cmdFermerPieces"
		Me.cmdAfficher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAfficher.Text = "Afficher"
		Me.cmdAfficher.Size = New System.Drawing.Size(73, 27)
		Me.cmdAfficher.Location = New System.Drawing.Point(272, 32)
		Me.cmdAfficher.TabIndex = 11
		Me.cmdAfficher.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAfficher.CausesValidation = True
		Me.cmdAfficher.Enabled = True
		Me.cmdAfficher.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAfficher.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAfficher.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAfficher.TabStop = True
		Me.cmdAfficher.Name = "cmdAfficher"
		Me.lvwPieces.Size = New System.Drawing.Size(761, 297)
		Me.lvwPieces.Location = New System.Drawing.Point(8, 80)
		Me.lvwPieces.TabIndex = 12
		Me.lvwPieces.View = System.Windows.Forms.View.Details
		Me.lvwPieces.LabelEdit = False
		Me.lvwPieces.LabelWrap = True
		Me.lvwPieces.HideSelection = True
		Me.lvwPieces.FullRowSelect = True
		Me.lvwPieces.GridLines = True
		Me.lvwPieces.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwPieces.BackColor = System.Drawing.SystemColors.Window
		Me.lvwPieces.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwPieces.Name = "lvwPieces"
		Me._lvwPieces_ColumnHeader_1.Text = "# Projet"
		Me._lvwPieces_ColumnHeader_1.Width = 106
		Me._lvwPieces_ColumnHeader_2.Text = "Qté"
		Me._lvwPieces_ColumnHeader_2.Width = 71
		Me._lvwPieces_ColumnHeader_3.Text = "# Item"
		Me._lvwPieces_ColumnHeader_3.Width = 247
		Me._lvwPieces_ColumnHeader_4.Text = "Description"
		Me._lvwPieces_ColumnHeader_4.Width = 471
		Me._lvwPieces_ColumnHeader_5.Text = "Fournisseur"
		Me._lvwPieces_ColumnHeader_5.Width = 318
		Me._lvwPieces_ColumnHeader_6.Text = "Date Commande"
		Me._lvwPieces_ColumnHeader_6.Width = 161
		Me._lvwPieces_ColumnHeader_7.Text = "Date Requise"
		Me._lvwPieces_ColumnHeader_7.Width = 161
		Me.txtDateRequise.AutoSize = False
		Me.txtDateRequise.Enabled = False
		Me.txtDateRequise.Size = New System.Drawing.Size(97, 19)
		Me.txtDateRequise.Location = New System.Drawing.Point(112, 16)
		Me.txtDateRequise.ReadOnly = True
		Me.txtDateRequise.TabIndex = 9
		Me.txtDateRequise.AcceptsReturn = True
		Me.txtDateRequise.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDateRequise.BackColor = System.Drawing.SystemColors.Window
		Me.txtDateRequise.CausesValidation = True
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
		Me.cmdDateRequise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDateRequise.Text = "..."
		Me.cmdDateRequise.Enabled = False
		Me.cmdDateRequise.Size = New System.Drawing.Size(25, 19)
		Me.cmdDateRequise.Location = New System.Drawing.Point(216, 16)
		Me.cmdDateRequise.TabIndex = 10
		Me.cmdDateRequise.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDateRequise.CausesValidation = True
		Me.cmdDateRequise.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDateRequise.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDateRequise.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDateRequise.TabStop = True
		Me.cmdDateRequise.Name = "cmdDateRequise"
		Me.cmdImprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdImprimer.Text = "Imprimer"
		Me.cmdImprimer.Size = New System.Drawing.Size(105, 25)
		Me.cmdImprimer.Location = New System.Drawing.Point(8, 488)
		Me.cmdImprimer.TabIndex = 16
		Me.cmdImprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdImprimer.CausesValidation = True
		Me.cmdImprimer.Enabled = True
		Me.cmdImprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdImprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdImprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdImprimer.TabStop = True
		Me.cmdImprimer.Name = "cmdImprimer"
		Me.cmbType.Size = New System.Drawing.Size(97, 21)
		Me.cmbType.Location = New System.Drawing.Point(208, 8)
		Me.cmbType.Items.AddRange(New Object(){"Projet", "Achat"})
		Me.cmbType.TabIndex = 0
		Me.cmbType.BackColor = System.Drawing.SystemColors.Window
		Me.cmbType.CausesValidation = True
		Me.cmbType.Enabled = True
		Me.cmbType.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbType.IntegralHeight = True
		Me.cmbType.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbType.Sorted = False
		Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbType.TabStop = True
		Me.cmbType.Visible = True
		Me.cmbType.Name = "cmbType"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler la réception"
		Me.cmdAnnuler.Size = New System.Drawing.Size(113, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(120, 488)
		Me.cmdAnnuler.TabIndex = 17
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.cmbNoProjet.Size = New System.Drawing.Size(145, 21)
		Me.cmbNoProjet.Location = New System.Drawing.Point(320, 8)
		Me.cmbNoProjet.TabIndex = 1
		Me.cmbNoProjet.BackColor = System.Drawing.SystemColors.Window
		Me.cmbNoProjet.CausesValidation = True
		Me.cmbNoProjet.Enabled = True
		Me.cmbNoProjet.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbNoProjet.IntegralHeight = True
		Me.cmbNoProjet.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbNoProjet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbNoProjet.Sorted = False
		Me.cmbNoProjet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbNoProjet.TabStop = True
		Me.cmbNoProjet.Visible = True
		Me.cmbNoProjet.Name = "cmbNoProjet"
		Me.txtNoProjet.AutoSize = False
		Me.txtNoProjet.Size = New System.Drawing.Size(145, 19)
		Me.txtNoProjet.Location = New System.Drawing.Point(320, 8)
		Me.txtNoProjet.ReadOnly = True
		Me.txtNoProjet.TabIndex = 2
		Me.txtNoProjet.Visible = False
		Me.txtNoProjet.AcceptsReturn = True
		Me.txtNoProjet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoProjet.BackColor = System.Drawing.SystemColors.Window
		Me.txtNoProjet.CausesValidation = True
		Me.txtNoProjet.Enabled = True
		Me.txtNoProjet.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNoProjet.HideSelection = True
		Me.txtNoProjet.Maxlength = 0
		Me.txtNoProjet.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNoProjet.MultiLine = False
		Me.txtNoProjet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNoProjet.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNoProjet.TabStop = True
		Me.txtNoProjet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoProjet.Name = "txtNoProjet"
		Me.lvwProjet.Size = New System.Drawing.Size(777, 417)
		Me.lvwProjet.Location = New System.Drawing.Point(8, 64)
		Me.lvwProjet.TabIndex = 15
		Me.lvwProjet.View = System.Windows.Forms.View.Details
		Me.lvwProjet.LabelEdit = False
		Me.lvwProjet.LabelWrap = True
		Me.lvwProjet.HideSelection = True
		Me.lvwProjet.FullRowSelect = True
		Me.lvwProjet.GridLines = True
		Me.lvwProjet.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwProjet.BackColor = System.Drawing.SystemColors.Window
		Me.lvwProjet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwProjet.Name = "lvwProjet"
		Me._lvwProjet_ColumnHeader_1.Text = "Qté"
		Me._lvwProjet_ColumnHeader_1.Width = 77
		Me._lvwProjet_ColumnHeader_2.Text = "No. Item"
		Me._lvwProjet_ColumnHeader_2.Width = 216
		Me._lvwProjet_ColumnHeader_3.Text = "Description"
		Me._lvwProjet_ColumnHeader_3.Width = 448
		Me._lvwProjet_ColumnHeader_4.Text = "Manufacturier"
		Me._lvwProjet_ColumnHeader_4.Width = 136
		Me._lvwProjet_ColumnHeader_5.Text = "Distributeur"
		Me._lvwProjet_ColumnHeader_5.Width = 119
		Me._lvwProjet_ColumnHeader_6.Text = "Date Réception"
		Me._lvwProjet_ColumnHeader_6.Width = 170
		Me._lvwProjet_ColumnHeader_7.Text = "Date Commande"
		Me._lvwProjet_ColumnHeader_7.Width = 170
		Me._lvwProjet_ColumnHeader_8.Text = "Date Requise"
		Me._lvwProjet_ColumnHeader_8.Width = 170
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(81, 25)
		Me.cmdFermer.Location = New System.Drawing.Point(704, 488)
		Me.cmdFermer.TabIndex = 19
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
		Me.cmdDate.Location = New System.Drawing.Point(744, 32)
		Me.cmdDate.TabIndex = 6
		Me.cmdDate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDate.CausesValidation = True
		Me.cmdDate.Enabled = True
		Me.cmdDate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDate.TabStop = True
		Me.cmdDate.Name = "cmdDate"
		Me.txtDateReception.AutoSize = False
		Me.txtDateReception.Size = New System.Drawing.Size(97, 19)
		Me.txtDateReception.Location = New System.Drawing.Point(640, 32)
		Me.txtDateReception.ReadOnly = True
		Me.txtDateReception.TabIndex = 5
		Me.txtDateReception.AcceptsReturn = True
		Me.txtDateReception.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDateReception.BackColor = System.Drawing.SystemColors.Window
		Me.txtDateReception.CausesValidation = True
		Me.txtDateReception.Enabled = True
		Me.txtDateReception.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDateReception.HideSelection = True
		Me.txtDateReception.Maxlength = 0
		Me.txtDateReception.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDateReception.MultiLine = False
		Me.txtDateReception.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDateReception.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDateReception.TabStop = True
		Me.txtDateReception.Visible = True
		Me.txtDateReception.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDateReception.Name = "txtDateReception"
		Me.Label1.Text = "Date de réception :"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(97, 19)
		Me.Label1.Location = New System.Drawing.Point(544, 32)
		Me.Label1.TabIndex = 4
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
		Me.Controls.Add(cmdNonRecu)
		Me.Controls.Add(mvwReception)
		Me.Controls.Add(fraPiecesNonRecues)
		Me.Controls.Add(cmdImprimer)
		Me.Controls.Add(cmbType)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(cmbNoProjet)
		Me.Controls.Add(txtNoProjet)
		Me.Controls.Add(lvwProjet)
		Me.Controls.Add(cmdFermer)
		Me.Controls.Add(cmdDate)
		Me.Controls.Add(txtDateReception)
		Me.Controls.Add(Label1)
		Me.fraPiecesNonRecues.Controls.Add(mvwDateRequise)
		Me.fraPiecesNonRecues.Controls.Add(chkProjetAchat)
		Me.fraPiecesNonRecues.Controls.Add(chkDateRequise)
		Me.fraPiecesNonRecues.Controls.Add(txtProjetAchat)
		Me.fraPiecesNonRecues.Controls.Add(cmdImprimerPieces)
		Me.fraPiecesNonRecues.Controls.Add(cmdFermerPieces)
		Me.fraPiecesNonRecues.Controls.Add(cmdAfficher)
		Me.fraPiecesNonRecues.Controls.Add(lvwPieces)
		Me.fraPiecesNonRecues.Controls.Add(txtDateRequise)
		Me.fraPiecesNonRecues.Controls.Add(cmdDateRequise)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_1)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_2)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_3)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_4)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_5)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_6)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_7)
		Me.lvwProjet.Columns.Add(_lvwProjet_ColumnHeader_1)
		Me.lvwProjet.Columns.Add(_lvwProjet_ColumnHeader_2)
		Me.lvwProjet.Columns.Add(_lvwProjet_ColumnHeader_3)
		Me.lvwProjet.Columns.Add(_lvwProjet_ColumnHeader_4)
		Me.lvwProjet.Columns.Add(_lvwProjet_ColumnHeader_5)
		Me.lvwProjet.Columns.Add(_lvwProjet_ColumnHeader_6)
		Me.lvwProjet.Columns.Add(_lvwProjet_ColumnHeader_7)
		Me.lvwProjet.Columns.Add(_lvwProjet_ColumnHeader_8)
		CType(Me.mvwDateRequise, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mvwReception, System.ComponentModel.ISupportInitialize).EndInit()
		Me.fraPiecesNonRecues.ResumeLayout(False)
		Me.lvwPieces.ResumeLayout(False)
		Me.lvwProjet.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class