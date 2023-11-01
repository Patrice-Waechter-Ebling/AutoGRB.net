<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmFacturation
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
	Public WithEvents cmd_export As System.Windows.Forms.Button
	Public WithEvents txtDescription As System.Windows.Forms.TextBox
	Public WithEvents _optType_2 As System.Windows.Forms.RadioButton
	Public WithEvents _optType_0 As System.Windows.Forms.RadioButton
	Public WithEvents _optType_1 As System.Windows.Forms.RadioButton
	Public WithEvents fraType As System.Windows.Forms.GroupBox
	Public WithEvents cmdVerrouiller As System.Windows.Forms.Button
	Public WithEvents cmdSommaire As System.Windows.Forms.Button
	Public WithEvents txtDateOuverture As System.Windows.Forms.TextBox
	Public WithEvents cmdCommentaire As System.Windows.Forms.Button
	Public WithEvents cmdModifier As System.Windows.Forms.Button
	Public WithEvents cmdNCRectifier As System.Windows.Forms.Button
	Public WithEvents cmdReouverture As System.Windows.Forms.Button
	Public WithEvents cmdImprimer As System.Windows.Forms.Button
	Public WithEvents txtRaisonFermeture As System.Windows.Forms.TextBox
	Public WithEvents txtDateFermeture As System.Windows.Forms.TextBox
	Public WithEvents txtClient As System.Windows.Forms.TextBox
	Public WithEvents cmdSupprimer As System.Windows.Forms.Button
	Public WithEvents _optMontrer_2 As System.Windows.Forms.RadioButton
	Public WithEvents _optMontrer_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optMontrer_0 As System.Windows.Forms.RadioButton
	Public WithEvents fraMontrer As System.Windows.Forms.GroupBox
	Public WithEvents cmdOuvrirProjSoum As System.Windows.Forms.Button
	Public WithEvents cmdFermerProjSoum As System.Windows.Forms.Button
	Public WithEvents cmbProjSoum As System.Windows.Forms.ComboBox
	Public WithEvents cmdFacturerRectifier As System.Windows.Forms.Button
	Public WithEvents cmbNoProjSoum As System.Windows.Forms.ComboBox
	Public WithEvents _lvwProjets_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjets_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjets_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjets_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjets_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjets_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjets_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjets_ColumnHeader_8 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwProjets As System.Windows.Forms.ListView
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	Public WithEvents txtNoProjSoum As System.Windows.Forms.TextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblRaisonFermeture As System.Windows.Forms.Label
	Public WithEvents lblDateFermeture As System.Windows.Forms.Label
	Public WithEvents lblDateOuverture As System.Windows.Forms.Label
	Public WithEvents lblClient As System.Windows.Forms.Label
	Public WithEvents lblHeuresNonFacturees As System.Windows.Forms.Label
	Public WithEvents lblHeuresFacturees As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents lblTitreProjSoum As System.Windows.Forms.Label
	Public WithEvents optMontrer As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	Public WithEvents optType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFacturation))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmd_export = New System.Windows.Forms.Button
		Me.txtDescription = New System.Windows.Forms.TextBox
		Me.fraType = New System.Windows.Forms.GroupBox
		Me._optType_2 = New System.Windows.Forms.RadioButton
		Me._optType_0 = New System.Windows.Forms.RadioButton
		Me._optType_1 = New System.Windows.Forms.RadioButton
		Me.cmdVerrouiller = New System.Windows.Forms.Button
		Me.cmdSommaire = New System.Windows.Forms.Button
		Me.txtDateOuverture = New System.Windows.Forms.TextBox
		Me.cmdCommentaire = New System.Windows.Forms.Button
		Me.cmdModifier = New System.Windows.Forms.Button
		Me.cmdNCRectifier = New System.Windows.Forms.Button
		Me.cmdReouverture = New System.Windows.Forms.Button
		Me.cmdImprimer = New System.Windows.Forms.Button
		Me.txtRaisonFermeture = New System.Windows.Forms.TextBox
		Me.txtDateFermeture = New System.Windows.Forms.TextBox
		Me.txtClient = New System.Windows.Forms.TextBox
		Me.cmdSupprimer = New System.Windows.Forms.Button
		Me.fraMontrer = New System.Windows.Forms.GroupBox
		Me._optMontrer_2 = New System.Windows.Forms.RadioButton
		Me._optMontrer_1 = New System.Windows.Forms.RadioButton
		Me._optMontrer_0 = New System.Windows.Forms.RadioButton
		Me.cmdOuvrirProjSoum = New System.Windows.Forms.Button
		Me.cmdFermerProjSoum = New System.Windows.Forms.Button
		Me.cmbProjSoum = New System.Windows.Forms.ComboBox
		Me.cmdFacturerRectifier = New System.Windows.Forms.Button
		Me.cmbNoProjSoum = New System.Windows.Forms.ComboBox
		Me.lvwProjets = New System.Windows.Forms.ListView
		Me._lvwProjets_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjets_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjets_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjets_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjets_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjets_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjets_ColumnHeader_7 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjets_ColumnHeader_8 = New System.Windows.Forms.ColumnHeader
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.txtNoProjSoum = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.lblRaisonFermeture = New System.Windows.Forms.Label
		Me.lblDateFermeture = New System.Windows.Forms.Label
		Me.lblDateOuverture = New System.Windows.Forms.Label
		Me.lblClient = New System.Windows.Forms.Label
		Me.lblHeuresNonFacturees = New System.Windows.Forms.Label
		Me.lblHeuresFacturees = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.lblTitreProjSoum = New System.Windows.Forms.Label
		Me.optMontrer = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.optType = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.fraType.SuspendLayout()
		Me.fraMontrer.SuspendLayout()
		Me.lvwProjets.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.optMontrer, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optType, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Facturation"
		Me.ClientSize = New System.Drawing.Size(624, 568)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmFacturation.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmFacturation"
		Me.cmd_export.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmd_export.Text = "Exporter vers Excel"
		Me.cmd_export.Size = New System.Drawing.Size(137, 25)
		Me.cmd_export.Location = New System.Drawing.Point(8, 416)
		Me.cmd_export.TabIndex = 39
		Me.cmd_export.BackColor = System.Drawing.SystemColors.Control
		Me.cmd_export.CausesValidation = True
		Me.cmd_export.Enabled = True
		Me.cmd_export.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmd_export.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmd_export.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmd_export.TabStop = True
		Me.cmd_export.Name = "cmd_export"
		Me.txtDescription.AutoSize = False
		Me.txtDescription.Size = New System.Drawing.Size(241, 33)
		Me.txtDescription.Location = New System.Drawing.Point(376, 56)
		Me.txtDescription.ReadOnly = True
		Me.txtDescription.TabIndex = 37
		Me.txtDescription.AcceptsReturn = True
		Me.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDescription.BackColor = System.Drawing.SystemColors.Window
		Me.txtDescription.CausesValidation = True
		Me.txtDescription.Enabled = True
		Me.txtDescription.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDescription.HideSelection = True
		Me.txtDescription.Maxlength = 0
		Me.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDescription.MultiLine = False
		Me.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDescription.TabStop = True
		Me.txtDescription.Visible = True
		Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDescription.Name = "txtDescription"
		Me.fraType.BackColor = System.Drawing.Color.Black
		Me.fraType.Text = "Type"
		Me.fraType.ForeColor = System.Drawing.Color.White
		Me.fraType.Size = New System.Drawing.Size(113, 73)
		Me.fraType.Location = New System.Drawing.Point(104, 72)
		Me.fraType.TabIndex = 33
		Me.fraType.Enabled = True
		Me.fraType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraType.Visible = True
		Me.fraType.Padding = New System.Windows.Forms.Padding(0)
		Me.fraType.Name = "fraType"
		Me._optType_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_2.BackColor = System.Drawing.Color.Black
		Me._optType_2.Text = "Tous"
		Me._optType_2.ForeColor = System.Drawing.Color.White
		Me._optType_2.Size = New System.Drawing.Size(97, 17)
		Me._optType_2.Location = New System.Drawing.Point(8, 48)
		Me._optType_2.TabIndex = 36
		Me._optType_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_2.CausesValidation = True
		Me._optType_2.Enabled = True
		Me._optType_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._optType_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optType_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optType_2.TabStop = True
		Me._optType_2.Checked = False
		Me._optType_2.Visible = True
		Me._optType_2.Name = "_optType_2"
		Me._optType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_0.BackColor = System.Drawing.Color.Black
		Me._optType_0.Text = "Électrique"
		Me._optType_0.ForeColor = System.Drawing.Color.White
		Me._optType_0.Size = New System.Drawing.Size(97, 17)
		Me._optType_0.Location = New System.Drawing.Point(8, 16)
		Me._optType_0.TabIndex = 35
		Me._optType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_0.CausesValidation = True
		Me._optType_0.Enabled = True
		Me._optType_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optType_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optType_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optType_0.TabStop = True
		Me._optType_0.Checked = False
		Me._optType_0.Visible = True
		Me._optType_0.Name = "_optType_0"
		Me._optType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_1.BackColor = System.Drawing.Color.Black
		Me._optType_1.Text = "Mécanique"
		Me._optType_1.ForeColor = System.Drawing.Color.White
		Me._optType_1.Size = New System.Drawing.Size(81, 17)
		Me._optType_1.Location = New System.Drawing.Point(8, 32)
		Me._optType_1.TabIndex = 34
		Me._optType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optType_1.CausesValidation = True
		Me._optType_1.Enabled = True
		Me._optType_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optType_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optType_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optType_1.TabStop = True
		Me._optType_1.Checked = False
		Me._optType_1.Visible = True
		Me._optType_1.Name = "_optType_1"
		Me.cmdVerrouiller.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdVerrouiller.Text = "Verrouiller Soum"
		Me.cmdVerrouiller.Size = New System.Drawing.Size(121, 25)
		Me.cmdVerrouiller.Location = New System.Drawing.Point(192, 416)
		Me.cmdVerrouiller.TabIndex = 32
		Me.cmdVerrouiller.BackColor = System.Drawing.SystemColors.Control
		Me.cmdVerrouiller.CausesValidation = True
		Me.cmdVerrouiller.Enabled = True
		Me.cmdVerrouiller.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdVerrouiller.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdVerrouiller.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdVerrouiller.TabStop = True
		Me.cmdVerrouiller.Name = "cmdVerrouiller"
		Me.cmdSommaire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSommaire.Text = "Sommaire"
		Me.cmdSommaire.Size = New System.Drawing.Size(81, 25)
		Me.cmdSommaire.Location = New System.Drawing.Point(320, 416)
		Me.cmdSommaire.TabIndex = 31
		Me.cmdSommaire.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSommaire.CausesValidation = True
		Me.cmdSommaire.Enabled = True
		Me.cmdSommaire.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSommaire.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSommaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSommaire.TabStop = True
		Me.cmdSommaire.Name = "cmdSommaire"
		Me.txtDateOuverture.AutoSize = False
		Me.txtDateOuverture.Size = New System.Drawing.Size(65, 19)
		Me.txtDateOuverture.Location = New System.Drawing.Point(304, 32)
		Me.txtDateOuverture.ReadOnly = True
		Me.txtDateOuverture.TabIndex = 30
		Me.txtDateOuverture.AcceptsReturn = True
		Me.txtDateOuverture.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDateOuverture.BackColor = System.Drawing.SystemColors.Window
		Me.txtDateOuverture.CausesValidation = True
		Me.txtDateOuverture.Enabled = True
		Me.txtDateOuverture.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDateOuverture.HideSelection = True
		Me.txtDateOuverture.Maxlength = 0
		Me.txtDateOuverture.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDateOuverture.MultiLine = False
		Me.txtDateOuverture.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDateOuverture.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDateOuverture.TabStop = True
		Me.txtDateOuverture.Visible = True
		Me.txtDateOuverture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDateOuverture.Name = "txtDateOuverture"
		Me.cmdCommentaire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCommentaire.Text = "Commentaires"
		Me.cmdCommentaire.Size = New System.Drawing.Size(81, 25)
		Me.cmdCommentaire.Location = New System.Drawing.Point(144, 384)
		Me.cmdCommentaire.TabIndex = 29
		Me.cmdCommentaire.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCommentaire.CausesValidation = True
		Me.cmdCommentaire.Enabled = True
		Me.cmdCommentaire.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCommentaire.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCommentaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCommentaire.TabStop = True
		Me.cmdCommentaire.Name = "cmdCommentaire"
		Me.cmdModifier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdModifier.Text = "Modifier"
		Me.cmdModifier.Size = New System.Drawing.Size(65, 25)
		Me.cmdModifier.Location = New System.Drawing.Point(552, 8)
		Me.cmdModifier.TabIndex = 28
		Me.cmdModifier.BackColor = System.Drawing.SystemColors.Control
		Me.cmdModifier.CausesValidation = True
		Me.cmdModifier.Enabled = True
		Me.cmdModifier.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdModifier.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdModifier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdModifier.TabStop = True
		Me.cmdModifier.Name = "cmdModifier"
		Me.cmdNCRectifier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNCRectifier.Text = "NC"
		Me.cmdNCRectifier.Size = New System.Drawing.Size(65, 25)
		Me.cmdNCRectifier.Location = New System.Drawing.Point(552, 384)
		Me.cmdNCRectifier.TabIndex = 21
		Me.cmdNCRectifier.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNCRectifier.CausesValidation = True
		Me.cmdNCRectifier.Enabled = True
		Me.cmdNCRectifier.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNCRectifier.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNCRectifier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNCRectifier.TabStop = True
		Me.cmdNCRectifier.Name = "cmdNCRectifier"
		Me.cmdReouverture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdReouverture.Text = "Annuler Fermeture"
		Me.cmdReouverture.Size = New System.Drawing.Size(105, 25)
		Me.cmdReouverture.Location = New System.Drawing.Point(440, 432)
		Me.cmdReouverture.TabIndex = 24
		Me.cmdReouverture.BackColor = System.Drawing.SystemColors.Control
		Me.cmdReouverture.CausesValidation = True
		Me.cmdReouverture.Enabled = True
		Me.cmdReouverture.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdReouverture.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdReouverture.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdReouverture.TabStop = True
		Me.cmdReouverture.Name = "cmdReouverture"
		Me.cmdImprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdImprimer.Text = "Imprimer"
		Me.cmdImprimer.Size = New System.Drawing.Size(81, 25)
		Me.cmdImprimer.Location = New System.Drawing.Point(8, 384)
		Me.cmdImprimer.TabIndex = 16
		Me.cmdImprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdImprimer.CausesValidation = True
		Me.cmdImprimer.Enabled = True
		Me.cmdImprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdImprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdImprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdImprimer.TabStop = True
		Me.cmdImprimer.Name = "cmdImprimer"
		Me.txtRaisonFermeture.AutoSize = False
		Me.txtRaisonFermeture.Size = New System.Drawing.Size(145, 33)
		Me.txtRaisonFermeture.Location = New System.Drawing.Point(224, 96)
		Me.txtRaisonFermeture.ReadOnly = True
		Me.txtRaisonFermeture.TabIndex = 11
		Me.txtRaisonFermeture.AcceptsReturn = True
		Me.txtRaisonFermeture.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtRaisonFermeture.BackColor = System.Drawing.SystemColors.Window
		Me.txtRaisonFermeture.CausesValidation = True
		Me.txtRaisonFermeture.Enabled = True
		Me.txtRaisonFermeture.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtRaisonFermeture.HideSelection = True
		Me.txtRaisonFermeture.Maxlength = 0
		Me.txtRaisonFermeture.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtRaisonFermeture.MultiLine = False
		Me.txtRaisonFermeture.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtRaisonFermeture.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtRaisonFermeture.TabStop = True
		Me.txtRaisonFermeture.Visible = True
		Me.txtRaisonFermeture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtRaisonFermeture.Name = "txtRaisonFermeture"
		Me.txtDateFermeture.AutoSize = False
		Me.txtDateFermeture.Size = New System.Drawing.Size(65, 19)
		Me.txtDateFermeture.Location = New System.Drawing.Point(304, 56)
		Me.txtDateFermeture.ReadOnly = True
		Me.txtDateFermeture.TabIndex = 4
		Me.txtDateFermeture.AcceptsReturn = True
		Me.txtDateFermeture.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDateFermeture.BackColor = System.Drawing.SystemColors.Window
		Me.txtDateFermeture.CausesValidation = True
		Me.txtDateFermeture.Enabled = True
		Me.txtDateFermeture.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDateFermeture.HideSelection = True
		Me.txtDateFermeture.Maxlength = 0
		Me.txtDateFermeture.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDateFermeture.MultiLine = False
		Me.txtDateFermeture.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDateFermeture.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDateFermeture.TabStop = True
		Me.txtDateFermeture.Visible = True
		Me.txtDateFermeture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDateFermeture.Name = "txtDateFermeture"
		Me.txtClient.AutoSize = False
		Me.txtClient.Size = New System.Drawing.Size(241, 19)
		Me.txtClient.Location = New System.Drawing.Point(304, 8)
		Me.txtClient.ReadOnly = True
		Me.txtClient.TabIndex = 0
		Me.txtClient.AcceptsReturn = True
		Me.txtClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtClient.BackColor = System.Drawing.SystemColors.Window
		Me.txtClient.CausesValidation = True
		Me.txtClient.Enabled = True
		Me.txtClient.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtClient.HideSelection = True
		Me.txtClient.Maxlength = 0
		Me.txtClient.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtClient.MultiLine = False
		Me.txtClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtClient.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtClient.TabStop = True
		Me.txtClient.Visible = True
		Me.txtClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtClient.Name = "txtClient"
		Me.cmdSupprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSupprimer.Text = "Supprimer"
		Me.cmdSupprimer.Size = New System.Drawing.Size(65, 25)
		Me.cmdSupprimer.Location = New System.Drawing.Point(408, 384)
		Me.cmdSupprimer.TabIndex = 19
		Me.cmdSupprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSupprimer.CausesValidation = True
		Me.cmdSupprimer.Enabled = True
		Me.cmdSupprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSupprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSupprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSupprimer.TabStop = True
		Me.cmdSupprimer.Name = "cmdSupprimer"
		Me.fraMontrer.BackColor = System.Drawing.Color.Black
		Me.fraMontrer.Text = "Soumissions"
		Me.fraMontrer.ForeColor = System.Drawing.Color.White
		Me.fraMontrer.Size = New System.Drawing.Size(89, 73)
		Me.fraMontrer.Location = New System.Drawing.Point(8, 72)
		Me.fraMontrer.TabIndex = 5
		Me.fraMontrer.Enabled = True
		Me.fraMontrer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraMontrer.Visible = True
		Me.fraMontrer.Padding = New System.Windows.Forms.Padding(0)
		Me.fraMontrer.Name = "fraMontrer"
		Me._optMontrer_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optMontrer_2.BackColor = System.Drawing.Color.Black
		Me._optMontrer_2.Text = "Fermées"
		Me._optMontrer_2.ForeColor = System.Drawing.Color.White
		Me._optMontrer_2.Size = New System.Drawing.Size(65, 17)
		Me._optMontrer_2.Location = New System.Drawing.Point(8, 32)
		Me._optMontrer_2.TabIndex = 8
		Me._optMontrer_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optMontrer_2.CausesValidation = True
		Me._optMontrer_2.Enabled = True
		Me._optMontrer_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._optMontrer_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optMontrer_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optMontrer_2.TabStop = True
		Me._optMontrer_2.Checked = False
		Me._optMontrer_2.Visible = True
		Me._optMontrer_2.Name = "_optMontrer_2"
		Me._optMontrer_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optMontrer_1.BackColor = System.Drawing.Color.Black
		Me._optMontrer_1.Text = "Ouvertes"
		Me._optMontrer_1.ForeColor = System.Drawing.Color.White
		Me._optMontrer_1.Size = New System.Drawing.Size(65, 17)
		Me._optMontrer_1.Location = New System.Drawing.Point(8, 16)
		Me._optMontrer_1.TabIndex = 7
		Me._optMontrer_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optMontrer_1.CausesValidation = True
		Me._optMontrer_1.Enabled = True
		Me._optMontrer_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optMontrer_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optMontrer_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optMontrer_1.TabStop = True
		Me._optMontrer_1.Checked = False
		Me._optMontrer_1.Visible = True
		Me._optMontrer_1.Name = "_optMontrer_1"
		Me._optMontrer_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optMontrer_0.BackColor = System.Drawing.Color.Black
		Me._optMontrer_0.Text = "Toutes"
		Me._optMontrer_0.ForeColor = System.Drawing.Color.White
		Me._optMontrer_0.Size = New System.Drawing.Size(57, 17)
		Me._optMontrer_0.Location = New System.Drawing.Point(8, 48)
		Me._optMontrer_0.TabIndex = 6
		Me._optMontrer_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optMontrer_0.CausesValidation = True
		Me._optMontrer_0.Enabled = True
		Me._optMontrer_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optMontrer_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optMontrer_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optMontrer_0.TabStop = True
		Me._optMontrer_0.Checked = False
		Me._optMontrer_0.Visible = True
		Me._optMontrer_0.Name = "_optMontrer_0"
		Me.cmdOuvrirProjSoum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOuvrirProjSoum.Text = "Ouvrir Soum"
		Me.cmdOuvrirProjSoum.Size = New System.Drawing.Size(81, 25)
		Me.cmdOuvrirProjSoum.Location = New System.Drawing.Point(320, 384)
		Me.cmdOuvrirProjSoum.TabIndex = 18
		Me.cmdOuvrirProjSoum.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOuvrirProjSoum.CausesValidation = True
		Me.cmdOuvrirProjSoum.Enabled = True
		Me.cmdOuvrirProjSoum.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOuvrirProjSoum.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOuvrirProjSoum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOuvrirProjSoum.TabStop = True
		Me.cmdOuvrirProjSoum.Name = "cmdOuvrirProjSoum"
		Me.cmdFermerProjSoum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermerProjSoum.Text = "Fermer Soum"
		Me.cmdFermerProjSoum.Size = New System.Drawing.Size(81, 25)
		Me.cmdFermerProjSoum.Location = New System.Drawing.Point(232, 384)
		Me.cmdFermerProjSoum.TabIndex = 17
		Me.cmdFermerProjSoum.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermerProjSoum.CausesValidation = True
		Me.cmdFermerProjSoum.Enabled = True
		Me.cmdFermerProjSoum.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermerProjSoum.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermerProjSoum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermerProjSoum.TabStop = True
		Me.cmdFermerProjSoum.Name = "cmdFermerProjSoum"
		Me.cmbProjSoum.Size = New System.Drawing.Size(97, 21)
		Me.cmbProjSoum.Location = New System.Drawing.Point(400, 120)
		Me.cmbProjSoum.Items.AddRange(New Object(){"Projet", "Soumission"})
		Me.cmbProjSoum.Sorted = True
		Me.cmbProjSoum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbProjSoum.TabIndex = 12
		Me.cmbProjSoum.BackColor = System.Drawing.SystemColors.Window
		Me.cmbProjSoum.CausesValidation = True
		Me.cmbProjSoum.Enabled = True
		Me.cmbProjSoum.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbProjSoum.IntegralHeight = True
		Me.cmbProjSoum.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbProjSoum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbProjSoum.TabStop = True
		Me.cmbProjSoum.Visible = True
		Me.cmbProjSoum.Name = "cmbProjSoum"
		Me.cmdFacturerRectifier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFacturerRectifier.Text = "Facturer"
		Me.cmdFacturerRectifier.Size = New System.Drawing.Size(65, 25)
		Me.cmdFacturerRectifier.Location = New System.Drawing.Point(480, 384)
		Me.cmdFacturerRectifier.TabIndex = 20
		Me.cmdFacturerRectifier.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFacturerRectifier.CausesValidation = True
		Me.cmdFacturerRectifier.Enabled = True
		Me.cmdFacturerRectifier.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFacturerRectifier.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFacturerRectifier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFacturerRectifier.TabStop = True
		Me.cmdFacturerRectifier.Name = "cmdFacturerRectifier"
		Me.cmbNoProjSoum.Size = New System.Drawing.Size(105, 21)
		Me.cmbNoProjSoum.Location = New System.Drawing.Point(512, 120)
		Me.cmbNoProjSoum.TabIndex = 14
		Me.cmbNoProjSoum.Text = "cmbNoProjSoum"
		Me.cmbNoProjSoum.BackColor = System.Drawing.SystemColors.Window
		Me.cmbNoProjSoum.CausesValidation = True
		Me.cmbNoProjSoum.Enabled = True
		Me.cmbNoProjSoum.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbNoProjSoum.IntegralHeight = True
		Me.cmbNoProjSoum.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbNoProjSoum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbNoProjSoum.Sorted = False
		Me.cmbNoProjSoum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbNoProjSoum.TabStop = True
		Me.cmbNoProjSoum.Visible = True
		Me.cmbNoProjSoum.Name = "cmbNoProjSoum"
		Me.lvwProjets.Size = New System.Drawing.Size(609, 225)
		Me.lvwProjets.Location = New System.Drawing.Point(8, 152)
		Me.lvwProjets.TabIndex = 15
		Me.lvwProjets.View = System.Windows.Forms.View.Details
		Me.lvwProjets.LabelEdit = False
		Me.lvwProjets.MultiSelect = True
		Me.lvwProjets.LabelWrap = True
		Me.lvwProjets.HideSelection = True
		Me.lvwProjets.FullRowSelect = True
		Me.lvwProjets.GridLines = True
		Me.lvwProjets.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwProjets.BackColor = System.Drawing.SystemColors.Window
		Me.lvwProjets.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwProjets.Name = "lvwProjets"
		Me._lvwProjets_ColumnHeader_1.Text = "Employé"
		Me._lvwProjets_ColumnHeader_1.Width = 92
		Me._lvwProjets_ColumnHeader_2.Text = "Date"
		Me._lvwProjets_ColumnHeader_2.Width = 117
		Me._lvwProjets_ColumnHeader_3.Text = "Début"
		Me._lvwProjets_ColumnHeader_3.Width = 73
		Me._lvwProjets_ColumnHeader_4.Text = "Fin"
		Me._lvwProjets_ColumnHeader_4.Width = 73
		Me._lvwProjets_ColumnHeader_5.Text = "Description"
		Me._lvwProjets_ColumnHeader_5.Width = 456
		Me._lvwProjets_ColumnHeader_6.Text = "Total"
		Me._lvwProjets_ColumnHeader_6.Width = 83
		Me._lvwProjets_ColumnHeader_7.Text = "No. Facture"
		Me._lvwProjets_ColumnHeader_7.Width = 120
		Me._lvwProjets_ColumnHeader_8.Text = "Type"
		Me._lvwProjets_ColumnHeader_8.Width = 200
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(65, 25)
		Me.cmdFermer.Location = New System.Drawing.Point(552, 432)
		Me.cmdFermer.TabIndex = 25
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.txtNoProjSoum.AutoSize = False
		Me.txtNoProjSoum.Size = New System.Drawing.Size(105, 19)
		Me.txtNoProjSoum.Location = New System.Drawing.Point(512, 120)
		Me.txtNoProjSoum.TabIndex = 13
		Me.txtNoProjSoum.Text = "Text1"
		Me.txtNoProjSoum.Visible = False
		Me.txtNoProjSoum.AcceptsReturn = True
		Me.txtNoProjSoum.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoProjSoum.BackColor = System.Drawing.SystemColors.Window
		Me.txtNoProjSoum.CausesValidation = True
		Me.txtNoProjSoum.Enabled = True
		Me.txtNoProjSoum.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNoProjSoum.HideSelection = True
		Me.txtNoProjSoum.ReadOnly = False
		Me.txtNoProjSoum.Maxlength = 0
		Me.txtNoProjSoum.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNoProjSoum.MultiLine = False
		Me.txtNoProjSoum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNoProjSoum.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNoProjSoum.TabStop = True
		Me.txtNoProjSoum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoProjSoum.Name = "txtNoProjSoum"
		Me.Label1.Text = "Description :"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(113, 17)
		Me.Label1.Location = New System.Drawing.Point(376, 40)
		Me.Label1.TabIndex = 38
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
		Me.lblRaisonFermeture.Text = "Raison de la fermeture :"
		Me.lblRaisonFermeture.ForeColor = System.Drawing.Color.White
		Me.lblRaisonFermeture.Size = New System.Drawing.Size(113, 17)
		Me.lblRaisonFermeture.Location = New System.Drawing.Point(224, 80)
		Me.lblRaisonFermeture.TabIndex = 9
		Me.lblRaisonFermeture.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblRaisonFermeture.BackColor = System.Drawing.Color.Transparent
		Me.lblRaisonFermeture.Enabled = True
		Me.lblRaisonFermeture.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblRaisonFermeture.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblRaisonFermeture.UseMnemonic = True
		Me.lblRaisonFermeture.Visible = True
		Me.lblRaisonFermeture.AutoSize = False
		Me.lblRaisonFermeture.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblRaisonFermeture.Name = "lblRaisonFermeture"
		Me.lblDateFermeture.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDateFermeture.Text = "Date de fermeture : "
		Me.lblDateFermeture.ForeColor = System.Drawing.Color.White
		Me.lblDateFermeture.Size = New System.Drawing.Size(97, 17)
		Me.lblDateFermeture.Location = New System.Drawing.Point(208, 56)
		Me.lblDateFermeture.TabIndex = 3
		Me.lblDateFermeture.BackColor = System.Drawing.Color.Transparent
		Me.lblDateFermeture.Enabled = True
		Me.lblDateFermeture.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDateFermeture.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDateFermeture.UseMnemonic = True
		Me.lblDateFermeture.Visible = True
		Me.lblDateFermeture.AutoSize = False
		Me.lblDateFermeture.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDateFermeture.Name = "lblDateFermeture"
		Me.lblDateOuverture.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDateOuverture.Text = "Date d'ouverture : "
		Me.lblDateOuverture.ForeColor = System.Drawing.Color.White
		Me.lblDateOuverture.Size = New System.Drawing.Size(97, 17)
		Me.lblDateOuverture.Location = New System.Drawing.Point(208, 32)
		Me.lblDateOuverture.TabIndex = 2
		Me.lblDateOuverture.BackColor = System.Drawing.Color.Transparent
		Me.lblDateOuverture.Enabled = True
		Me.lblDateOuverture.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDateOuverture.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDateOuverture.UseMnemonic = True
		Me.lblDateOuverture.Visible = True
		Me.lblDateOuverture.AutoSize = False
		Me.lblDateOuverture.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDateOuverture.Name = "lblDateOuverture"
		Me.lblClient.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblClient.Text = "Client : "
		Me.lblClient.ForeColor = System.Drawing.Color.White
		Me.lblClient.Size = New System.Drawing.Size(49, 17)
		Me.lblClient.Location = New System.Drawing.Point(256, 8)
		Me.lblClient.TabIndex = 1
		Me.lblClient.BackColor = System.Drawing.Color.Transparent
		Me.lblClient.Enabled = True
		Me.lblClient.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblClient.UseMnemonic = True
		Me.lblClient.Visible = True
		Me.lblClient.AutoSize = False
		Me.lblClient.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblClient.Name = "lblClient"
		Me.lblHeuresNonFacturees.BackColor = System.Drawing.Color.White
		Me.lblHeuresNonFacturees.ForeColor = System.Drawing.Color.Black
		Me.lblHeuresNonFacturees.Size = New System.Drawing.Size(57, 17)
		Me.lblHeuresNonFacturees.Location = New System.Drawing.Point(128, 472)
		Me.lblHeuresNonFacturees.TabIndex = 27
		Me.lblHeuresNonFacturees.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblHeuresNonFacturees.Enabled = True
		Me.lblHeuresNonFacturees.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblHeuresNonFacturees.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblHeuresNonFacturees.UseMnemonic = True
		Me.lblHeuresNonFacturees.Visible = True
		Me.lblHeuresNonFacturees.AutoSize = False
		Me.lblHeuresNonFacturees.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblHeuresNonFacturees.Name = "lblHeuresNonFacturees"
		Me.lblHeuresFacturees.BackColor = System.Drawing.Color.White
		Me.lblHeuresFacturees.ForeColor = System.Drawing.Color.Black
		Me.lblHeuresFacturees.Size = New System.Drawing.Size(57, 17)
		Me.lblHeuresFacturees.Location = New System.Drawing.Point(128, 448)
		Me.lblHeuresFacturees.TabIndex = 23
		Me.lblHeuresFacturees.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblHeuresFacturees.Enabled = True
		Me.lblHeuresFacturees.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblHeuresFacturees.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblHeuresFacturees.UseMnemonic = True
		Me.lblHeuresFacturees.Visible = True
		Me.lblHeuresFacturees.AutoSize = False
		Me.lblHeuresFacturees.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblHeuresFacturees.Name = "lblHeuresFacturees"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label3.Text = "Heures non facturées :"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(113, 17)
		Me.Label3.Location = New System.Drawing.Point(8, 472)
		Me.Label3.TabIndex = 26
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
		Me.Label2.Text = "Heures facturées :"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(105, 17)
		Me.Label2.Location = New System.Drawing.Point(16, 448)
		Me.Label2.TabIndex = 22
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.lblTitreProjSoum.Text = "Numéro de projet :"
		Me.lblTitreProjSoum.ForeColor = System.Drawing.Color.White
		Me.lblTitreProjSoum.Size = New System.Drawing.Size(121, 17)
		Me.lblTitreProjSoum.Location = New System.Drawing.Point(512, 104)
		Me.lblTitreProjSoum.TabIndex = 10
		Me.lblTitreProjSoum.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTitreProjSoum.BackColor = System.Drawing.Color.Transparent
		Me.lblTitreProjSoum.Enabled = True
		Me.lblTitreProjSoum.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTitreProjSoum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTitreProjSoum.UseMnemonic = True
		Me.lblTitreProjSoum.Visible = True
		Me.lblTitreProjSoum.AutoSize = False
		Me.lblTitreProjSoum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTitreProjSoum.Name = "lblTitreProjSoum"
		Me.Controls.Add(cmd_export)
		Me.Controls.Add(txtDescription)
		Me.Controls.Add(fraType)
		Me.Controls.Add(cmdVerrouiller)
		Me.Controls.Add(cmdSommaire)
		Me.Controls.Add(txtDateOuverture)
		Me.Controls.Add(cmdCommentaire)
		Me.Controls.Add(cmdModifier)
		Me.Controls.Add(cmdNCRectifier)
		Me.Controls.Add(cmdReouverture)
		Me.Controls.Add(cmdImprimer)
		Me.Controls.Add(txtRaisonFermeture)
		Me.Controls.Add(txtDateFermeture)
		Me.Controls.Add(txtClient)
		Me.Controls.Add(cmdSupprimer)
		Me.Controls.Add(fraMontrer)
		Me.Controls.Add(cmdOuvrirProjSoum)
		Me.Controls.Add(cmdFermerProjSoum)
		Me.Controls.Add(cmbProjSoum)
		Me.Controls.Add(cmdFacturerRectifier)
		Me.Controls.Add(cmbNoProjSoum)
		Me.Controls.Add(lvwProjets)
		Me.Controls.Add(cmdFermer)
		Me.Controls.Add(txtNoProjSoum)
		Me.Controls.Add(Label1)
		Me.Controls.Add(lblRaisonFermeture)
		Me.Controls.Add(lblDateFermeture)
		Me.Controls.Add(lblDateOuverture)
		Me.Controls.Add(lblClient)
		Me.Controls.Add(lblHeuresNonFacturees)
		Me.Controls.Add(lblHeuresFacturees)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(lblTitreProjSoum)
		Me.fraType.Controls.Add(_optType_2)
		Me.fraType.Controls.Add(_optType_0)
		Me.fraType.Controls.Add(_optType_1)
		Me.fraMontrer.Controls.Add(_optMontrer_2)
		Me.fraMontrer.Controls.Add(_optMontrer_1)
		Me.fraMontrer.Controls.Add(_optMontrer_0)
		Me.lvwProjets.Columns.Add(_lvwProjets_ColumnHeader_1)
		Me.lvwProjets.Columns.Add(_lvwProjets_ColumnHeader_2)
		Me.lvwProjets.Columns.Add(_lvwProjets_ColumnHeader_3)
		Me.lvwProjets.Columns.Add(_lvwProjets_ColumnHeader_4)
		Me.lvwProjets.Columns.Add(_lvwProjets_ColumnHeader_5)
		Me.lvwProjets.Columns.Add(_lvwProjets_ColumnHeader_6)
		Me.lvwProjets.Columns.Add(_lvwProjets_ColumnHeader_7)
		Me.lvwProjets.Columns.Add(_lvwProjets_ColumnHeader_8)
		Me.optMontrer.SetIndex(_optMontrer_2, CType(2, Short))
		Me.optMontrer.SetIndex(_optMontrer_1, CType(1, Short))
		Me.optMontrer.SetIndex(_optMontrer_0, CType(0, Short))
		Me.optType.SetIndex(_optType_2, CType(2, Short))
		Me.optType.SetIndex(_optType_0, CType(0, Short))
		Me.optType.SetIndex(_optType_1, CType(1, Short))
		CType(Me.optType, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.optMontrer, System.ComponentModel.ISupportInitialize).EndInit()
		Me.fraType.ResumeLayout(False)
		Me.fraMontrer.ResumeLayout(False)
		Me.lvwProjets.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class