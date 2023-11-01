<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmFeuilleTemps
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
	Public WithEvents CmdModifier As System.Windows.Forms.Button
	Public WithEvents cmdexcel As System.Windows.Forms.Button
	Public WithEvents mvwDate As AxMSComCtl2.AxMonthView
	Public WithEvents _optTypePunch_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optTypePunch_0 As System.Windows.Forms.RadioButton
	Public WithEvents cmdExporter As System.Windows.Forms.Button
	Public WithEvents chkKM As System.Windows.Forms.CheckBox
	Public WithEvents txtSemaine As System.Windows.Forms.TextBox
	Public WithEvents cmdDateSemaine As System.Windows.Forms.Button
	Public WithEvents cmdImprimer As System.Windows.Forms.Button
	Public WithEvents cmdDate As System.Windows.Forms.Button
	Public WithEvents txtCommentaires As System.Windows.Forms.TextBox
	Public WithEvents cmbEmployé As System.Windows.Forms.ComboBox
	Public WithEvents cmdEnregistrer As System.Windows.Forms.Button
	Public WithEvents _lvwPunch_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPunch_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPunch_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPunch_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPunch_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPunch_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPunch_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwPunch As System.Windows.Forms.ListView
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	Public WithEvents mskHeureFin As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskDate As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskHeureDebut As System.Windows.Forms.MaskedTextBox
	Public WithEvents cmdAjouter As System.Windows.Forms.Button
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents mskNoProjet As System.Windows.Forms.MaskedTextBox
	Public WithEvents txtKM As System.Windows.Forms.TextBox
	Public WithEvents txtClient As System.Windows.Forms.TextBox
	Public WithEvents cmbType As System.Windows.Forms.ComboBox
	Public WithEvents lblType As System.Windows.Forms.Label
	Public WithEvents lblPrefixe As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents lblSemaine As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents optTypePunch As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFeuilleTemps))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.CmdModifier = New System.Windows.Forms.Button
		Me.cmdexcel = New System.Windows.Forms.Button
		Me.mvwDate = New AxMSComCtl2.AxMonthView
		Me._optTypePunch_1 = New System.Windows.Forms.RadioButton
		Me._optTypePunch_0 = New System.Windows.Forms.RadioButton
		Me.cmdExporter = New System.Windows.Forms.Button
		Me.chkKM = New System.Windows.Forms.CheckBox
		Me.txtSemaine = New System.Windows.Forms.TextBox
		Me.cmdDateSemaine = New System.Windows.Forms.Button
		Me.cmdImprimer = New System.Windows.Forms.Button
		Me.cmdDate = New System.Windows.Forms.Button
		Me.txtCommentaires = New System.Windows.Forms.TextBox
		Me.cmbEmployé = New System.Windows.Forms.ComboBox
		Me.cmdEnregistrer = New System.Windows.Forms.Button
		Me.lvwPunch = New System.Windows.Forms.ListView
		Me._lvwPunch_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwPunch_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwPunch_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwPunch_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwPunch_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvwPunch_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me._lvwPunch_ColumnHeader_7 = New System.Windows.Forms.ColumnHeader
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.mskHeureFin = New System.Windows.Forms.MaskedTextBox
		Me.mskDate = New System.Windows.Forms.MaskedTextBox
		Me.mskHeureDebut = New System.Windows.Forms.MaskedTextBox
		Me.cmdAjouter = New System.Windows.Forms.Button
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.mskNoProjet = New System.Windows.Forms.MaskedTextBox
		Me.txtKM = New System.Windows.Forms.TextBox
		Me.txtClient = New System.Windows.Forms.TextBox
		Me.cmbType = New System.Windows.Forms.ComboBox
		Me.lblType = New System.Windows.Forms.Label
		Me.lblPrefixe = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label8 = New System.Windows.Forms.Label
		Me.lblSemaine = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.optTypePunch = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.lvwPunch.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optTypePunch, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Feuilles de temps"
		Me.ClientSize = New System.Drawing.Size(563, 523)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmFeuilleTemps.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmFeuilleTemps"
		Me.CmdModifier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdModifier.Text = "Modifier Type"
		Me.CmdModifier.Size = New System.Drawing.Size(73, 33)
		Me.CmdModifier.Location = New System.Drawing.Point(400, 480)
		Me.CmdModifier.TabIndex = 34
		Me.CmdModifier.BackColor = System.Drawing.SystemColors.Control
		Me.CmdModifier.CausesValidation = True
		Me.CmdModifier.Enabled = True
		Me.CmdModifier.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdModifier.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdModifier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdModifier.TabStop = True
		Me.CmdModifier.Name = "CmdModifier"
		Me.cmdexcel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdexcel.Text = "Excel"
		Me.cmdexcel.Size = New System.Drawing.Size(73, 33)
		Me.cmdexcel.Location = New System.Drawing.Point(164, 480)
		Me.cmdexcel.TabIndex = 33
		Me.cmdexcel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdexcel.CausesValidation = True
		Me.cmdexcel.Enabled = True
		Me.cmdexcel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdexcel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdexcel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdexcel.TabStop = True
		Me.cmdexcel.Name = "cmdexcel"
		mvwDate.OcxState = CType(resources.GetObject("mvwDate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwDate.Size = New System.Drawing.Size(176, 158)
		Me.mvwDate.Location = New System.Drawing.Point(64, 176)
		Me.mvwDate.TabIndex = 7
		Me.mvwDate.Visible = False
		Me.mvwDate.Name = "mvwDate"
		Me._optTypePunch_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optTypePunch_1.BackColor = System.Drawing.Color.Black
		Me._optTypePunch_1.Text = "Mécanique"
		Me._optTypePunch_1.ForeColor = System.Drawing.Color.White
		Me._optTypePunch_1.Size = New System.Drawing.Size(73, 17)
		Me._optTypePunch_1.Location = New System.Drawing.Point(104, 320)
		Me._optTypePunch_1.TabIndex = 30
		Me._optTypePunch_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optTypePunch_1.CausesValidation = True
		Me._optTypePunch_1.Enabled = True
		Me._optTypePunch_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optTypePunch_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optTypePunch_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optTypePunch_1.TabStop = True
		Me._optTypePunch_1.Checked = False
		Me._optTypePunch_1.Visible = True
		Me._optTypePunch_1.Name = "_optTypePunch_1"
		Me._optTypePunch_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optTypePunch_0.BackColor = System.Drawing.Color.Black
		Me._optTypePunch_0.Text = "Électrique"
		Me._optTypePunch_0.ForeColor = System.Drawing.Color.White
		Me._optTypePunch_0.Size = New System.Drawing.Size(73, 17)
		Me._optTypePunch_0.Location = New System.Drawing.Point(104, 304)
		Me._optTypePunch_0.TabIndex = 29
		Me._optTypePunch_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optTypePunch_0.CausesValidation = True
		Me._optTypePunch_0.Enabled = True
		Me._optTypePunch_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optTypePunch_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optTypePunch_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optTypePunch_0.TabStop = True
		Me._optTypePunch_0.Checked = False
		Me._optTypePunch_0.Visible = True
		Me._optTypePunch_0.Name = "_optTypePunch_0"
		Me.cmdExporter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExporter.Text = "Exporter"
		Me.cmdExporter.Size = New System.Drawing.Size(73, 33)
		Me.cmdExporter.Location = New System.Drawing.Point(8, 480)
		Me.cmdExporter.TabIndex = 28
		Me.cmdExporter.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExporter.CausesValidation = True
		Me.cmdExporter.Enabled = True
		Me.cmdExporter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExporter.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExporter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExporter.TabStop = True
		Me.cmdExporter.Name = "cmdExporter"
		Me.chkKM.BackColor = System.Drawing.Color.Black
		Me.chkKM.Text = "KM :"
		Me.chkKM.ForeColor = System.Drawing.Color.White
		Me.chkKM.Size = New System.Drawing.Size(49, 17)
		Me.chkKM.Location = New System.Drawing.Point(48, 440)
		Me.chkKM.TabIndex = 19
		Me.chkKM.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkKM.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkKM.CausesValidation = True
		Me.chkKM.Enabled = True
		Me.chkKM.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkKM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkKM.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkKM.TabStop = True
		Me.chkKM.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkKM.Visible = True
		Me.chkKM.Name = "chkKM"
		Me.txtSemaine.AutoSize = False
		Me.txtSemaine.Size = New System.Drawing.Size(105, 19)
		Me.txtSemaine.Location = New System.Drawing.Point(416, 64)
		Me.txtSemaine.ReadOnly = True
		Me.txtSemaine.TabIndex = 2
		Me.txtSemaine.AcceptsReturn = True
		Me.txtSemaine.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtSemaine.BackColor = System.Drawing.SystemColors.Window
		Me.txtSemaine.CausesValidation = True
		Me.txtSemaine.Enabled = True
		Me.txtSemaine.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSemaine.HideSelection = True
		Me.txtSemaine.Maxlength = 0
		Me.txtSemaine.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSemaine.MultiLine = False
		Me.txtSemaine.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSemaine.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtSemaine.TabStop = True
		Me.txtSemaine.Visible = True
		Me.txtSemaine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtSemaine.Name = "txtSemaine"
		Me.cmdDateSemaine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDateSemaine.Text = "..."
		Me.cmdDateSemaine.Size = New System.Drawing.Size(25, 21)
		Me.cmdDateSemaine.Location = New System.Drawing.Point(528, 64)
		Me.cmdDateSemaine.TabIndex = 4
		Me.cmdDateSemaine.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDateSemaine.CausesValidation = True
		Me.cmdDateSemaine.Enabled = True
		Me.cmdDateSemaine.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDateSemaine.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDateSemaine.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDateSemaine.TabStop = True
		Me.cmdDateSemaine.Name = "cmdDateSemaine"
		Me.cmdImprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdImprimer.Text = "Imprimer"
		Me.cmdImprimer.Size = New System.Drawing.Size(73, 33)
		Me.cmdImprimer.Location = New System.Drawing.Point(86, 480)
		Me.cmdImprimer.TabIndex = 23
		Me.cmdImprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdImprimer.CausesValidation = True
		Me.cmdImprimer.Enabled = True
		Me.cmdImprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdImprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdImprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdImprimer.TabStop = True
		Me.cmdImprimer.Name = "cmdImprimer"
		Me.cmdDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDate.Text = "..."
		Me.cmdDate.Size = New System.Drawing.Size(25, 17)
		Me.cmdDate.Location = New System.Drawing.Point(192, 368)
		Me.cmdDate.TabIndex = 13
		Me.cmdDate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDate.CausesValidation = True
		Me.cmdDate.Enabled = True
		Me.cmdDate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDate.TabStop = True
		Me.cmdDate.Name = "cmdDate"
		Me.txtCommentaires.AutoSize = False
		Me.txtCommentaires.Size = New System.Drawing.Size(249, 51)
		Me.txtCommentaires.Location = New System.Drawing.Point(304, 408)
		Me.txtCommentaires.MultiLine = True
		Me.txtCommentaires.TabIndex = 20
		Me.txtCommentaires.AcceptsReturn = True
		Me.txtCommentaires.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCommentaires.BackColor = System.Drawing.SystemColors.Window
		Me.txtCommentaires.CausesValidation = True
		Me.txtCommentaires.Enabled = True
		Me.txtCommentaires.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCommentaires.HideSelection = True
		Me.txtCommentaires.ReadOnly = False
		Me.txtCommentaires.Maxlength = 0
		Me.txtCommentaires.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCommentaires.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCommentaires.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCommentaires.TabStop = True
		Me.txtCommentaires.Visible = True
		Me.txtCommentaires.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCommentaires.Name = "txtCommentaires"
		Me.cmbEmployé.Size = New System.Drawing.Size(129, 21)
		Me.cmbEmployé.Location = New System.Drawing.Point(56, 64)
		Me.cmbEmployé.Sorted = True
		Me.cmbEmployé.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbEmployé.TabIndex = 1
		Me.cmbEmployé.BackColor = System.Drawing.SystemColors.Window
		Me.cmbEmployé.CausesValidation = True
		Me.cmbEmployé.Enabled = True
		Me.cmbEmployé.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbEmployé.IntegralHeight = True
		Me.cmbEmployé.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbEmployé.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbEmployé.TabStop = True
		Me.cmbEmployé.Visible = True
		Me.cmbEmployé.Name = "cmbEmployé"
		Me.cmdEnregistrer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEnregistrer.Text = "Enregistrer"
		Me.cmdEnregistrer.Enabled = False
		Me.cmdEnregistrer.Size = New System.Drawing.Size(73, 33)
		Me.cmdEnregistrer.Location = New System.Drawing.Point(320, 480)
		Me.cmdEnregistrer.TabIndex = 25
		Me.cmdEnregistrer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEnregistrer.CausesValidation = True
		Me.cmdEnregistrer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEnregistrer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEnregistrer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEnregistrer.TabStop = True
		Me.cmdEnregistrer.Name = "cmdEnregistrer"
		Me.lvwPunch.Size = New System.Drawing.Size(545, 201)
		Me.lvwPunch.Location = New System.Drawing.Point(8, 96)
		Me.lvwPunch.TabIndex = 5
		Me.lvwPunch.View = System.Windows.Forms.View.Details
		Me.lvwPunch.LabelEdit = False
		Me.lvwPunch.LabelWrap = True
		Me.lvwPunch.HideSelection = True
		Me.lvwPunch.FullRowSelect = True
		Me.lvwPunch.GridLines = True
		Me.lvwPunch.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwPunch.BackColor = System.Drawing.SystemColors.Window
		Me.lvwPunch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwPunch.Name = "lvwPunch"
		Me._lvwPunch_ColumnHeader_1.Text = "Projet"
		Me._lvwPunch_ColumnHeader_1.Width = 106
		Me._lvwPunch_ColumnHeader_2.Text = "Date"
		Me._lvwPunch_ColumnHeader_2.Width = 177
		Me._lvwPunch_ColumnHeader_3.Text = "Début"
		Me._lvwPunch_ColumnHeader_3.Width = 71
		Me._lvwPunch_ColumnHeader_4.Text = "Fin"
		Me._lvwPunch_ColumnHeader_4.Width = 71
		Me._lvwPunch_ColumnHeader_5.Text = "Client"
		Me._lvwPunch_ColumnHeader_5.Width = 260
		Me._lvwPunch_ColumnHeader_6.Text = "Type"
		Me._lvwPunch_ColumnHeader_6.Width = 170
		Me._lvwPunch_ColumnHeader_7.Text = "Commentaire"
		Me._lvwPunch_ColumnHeader_7.Width = 184
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(73, 33)
		Me.cmdFermer.Location = New System.Drawing.Point(480, 480)
		Me.cmdFermer.TabIndex = 27
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.mskHeureFin.AllowPromptAsInput = False
		Me.mskHeureFin.Size = New System.Drawing.Size(105, 17)
		Me.mskHeureFin.Location = New System.Drawing.Point(104, 416)
		Me.mskHeureFin.TabIndex = 18
		Me.mskHeureFin.PromptChar = "_"
		Me.mskHeureFin.Name = "mskHeureFin"
		Me.mskDate.AllowPromptAsInput = False
		Me.mskDate.Size = New System.Drawing.Size(81, 17)
		Me.mskDate.Location = New System.Drawing.Point(104, 368)
		Me.mskDate.TabIndex = 12
		Me.mskDate.PromptChar = "_"
		Me.mskDate.Name = "mskDate"
		Me.mskHeureDebut.AllowPromptAsInput = False
		Me.mskHeureDebut.Size = New System.Drawing.Size(105, 17)
		Me.mskHeureDebut.Location = New System.Drawing.Point(104, 392)
		Me.mskHeureDebut.TabIndex = 15
		Me.mskHeureDebut.PromptChar = "_"
		Me.mskHeureDebut.Name = "mskHeureDebut"
		Me.cmdAjouter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAjouter.Text = "Ajouter"
		Me.cmdAjouter.Size = New System.Drawing.Size(73, 33)
		Me.cmdAjouter.Location = New System.Drawing.Point(240, 480)
		Me.cmdAjouter.TabIndex = 24
		Me.cmdAjouter.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAjouter.CausesValidation = True
		Me.cmdAjouter.Enabled = True
		Me.cmdAjouter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAjouter.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAjouter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAjouter.TabStop = True
		Me.cmdAjouter.Name = "cmdAjouter"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(73, 33)
		Me.cmdAnnuler.Location = New System.Drawing.Point(480, 480)
		Me.cmdAnnuler.TabIndex = 26
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.mskNoProjet.AllowPromptAsInput = False
		Me.mskNoProjet.Size = New System.Drawing.Size(65, 19)
		Me.mskNoProjet.Location = New System.Drawing.Point(120, 344)
		Me.mskNoProjet.TabIndex = 8
		Me.mskNoProjet.MaxLength = 8
		Me.mskNoProjet.Mask = "#####-##"
		Me.mskNoProjet.PromptChar = "_"
		Me.mskNoProjet.Name = "mskNoProjet"
		Me.txtKM.AutoSize = False
		Me.txtKM.Enabled = False
		Me.txtKM.Size = New System.Drawing.Size(41, 19)
		Me.txtKM.Location = New System.Drawing.Point(104, 440)
		Me.txtKM.MultiLine = True
		Me.txtKM.TabIndex = 21
		Me.txtKM.AcceptsReturn = True
		Me.txtKM.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtKM.BackColor = System.Drawing.SystemColors.Window
		Me.txtKM.CausesValidation = True
		Me.txtKM.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtKM.HideSelection = True
		Me.txtKM.ReadOnly = False
		Me.txtKM.Maxlength = 0
		Me.txtKM.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtKM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtKM.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtKM.TabStop = True
		Me.txtKM.Visible = True
		Me.txtKM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtKM.Name = "txtKM"
		Me.txtClient.AutoSize = False
		Me.txtClient.Size = New System.Drawing.Size(249, 19)
		Me.txtClient.Location = New System.Drawing.Point(304, 328)
		Me.txtClient.ReadOnly = True
		Me.txtClient.TabIndex = 10
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
		Me.cmbType.Size = New System.Drawing.Size(249, 21)
		Me.cmbType.Location = New System.Drawing.Point(304, 368)
		Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbType.TabIndex = 35
		Me.cmbType.BackColor = System.Drawing.SystemColors.Window
		Me.cmbType.CausesValidation = True
		Me.cmbType.Enabled = True
		Me.cmbType.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbType.IntegralHeight = True
		Me.cmbType.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbType.Sorted = False
		Me.cmbType.TabStop = True
		Me.cmbType.Visible = True
		Me.cmbType.Name = "cmbType"
		Me.lblType.Text = "Type :"
		Me.lblType.ForeColor = System.Drawing.Color.White
		Me.lblType.Size = New System.Drawing.Size(33, 17)
		Me.lblType.Location = New System.Drawing.Point(304, 352)
		Me.lblType.TabIndex = 32
		Me.lblType.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblType.BackColor = System.Drawing.Color.Transparent
		Me.lblType.Enabled = True
		Me.lblType.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblType.UseMnemonic = True
		Me.lblType.Visible = True
		Me.lblType.AutoSize = False
		Me.lblType.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblType.Name = "lblType"
		Me.lblPrefixe.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblPrefixe.Size = New System.Drawing.Size(17, 19)
		Me.lblPrefixe.Location = New System.Drawing.Point(104, 344)
		Me.lblPrefixe.TabIndex = 31
		Me.lblPrefixe.BackColor = System.Drawing.SystemColors.Control
		Me.lblPrefixe.Enabled = True
		Me.lblPrefixe.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPrefixe.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPrefixe.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPrefixe.UseMnemonic = True
		Me.lblPrefixe.Visible = True
		Me.lblPrefixe.AutoSize = False
		Me.lblPrefixe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblPrefixe.Name = "lblPrefixe"
		Me.Label4.Text = "Km"
		Me.Label4.ForeColor = System.Drawing.Color.White
		Me.Label4.Size = New System.Drawing.Size(41, 17)
		Me.Label4.Location = New System.Drawing.Point(152, 440)
		Me.Label4.TabIndex = 22
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
		Me.Label8.Text = "Client :"
		Me.Label8.ForeColor = System.Drawing.Color.White
		Me.Label8.Size = New System.Drawing.Size(89, 17)
		Me.Label8.Location = New System.Drawing.Point(304, 312)
		Me.Label8.TabIndex = 9
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
		Me.lblSemaine.Text = "Semaine du :"
		Me.lblSemaine.ForeColor = System.Drawing.Color.White
		Me.lblSemaine.Size = New System.Drawing.Size(65, 17)
		Me.lblSemaine.Location = New System.Drawing.Point(352, 64)
		Me.lblSemaine.TabIndex = 3
		Me.lblSemaine.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblSemaine.BackColor = System.Drawing.Color.Transparent
		Me.lblSemaine.Enabled = True
		Me.lblSemaine.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblSemaine.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblSemaine.UseMnemonic = True
		Me.lblSemaine.Visible = True
		Me.lblSemaine.AutoSize = False
		Me.lblSemaine.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblSemaine.Name = "lblSemaine"
		Me.Label7.Text = "Commentaires :"
		Me.Label7.ForeColor = System.Drawing.Color.White
		Me.Label7.Size = New System.Drawing.Size(89, 17)
		Me.Label7.Location = New System.Drawing.Point(304, 392)
		Me.Label7.TabIndex = 16
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
		Me.Label6.Text = "Employé :"
		Me.Label6.ForeColor = System.Drawing.Color.White
		Me.Label6.Size = New System.Drawing.Size(73, 17)
		Me.Label6.Location = New System.Drawing.Point(8, 64)
		Me.Label6.TabIndex = 0
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
		Me.Label5.Text = "Heure de fin :"
		Me.Label5.ForeColor = System.Drawing.Color.White
		Me.Label5.Size = New System.Drawing.Size(89, 17)
		Me.Label5.Location = New System.Drawing.Point(8, 416)
		Me.Label5.TabIndex = 17
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
		Me.Label3.Text = "Heure de début :"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(89, 17)
		Me.Label3.Location = New System.Drawing.Point(8, 392)
		Me.Label3.TabIndex = 14
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
		Me.Label2.Text = "Date (AA-MM-JJ):"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(89, 17)
		Me.Label2.Location = New System.Drawing.Point(8, 368)
		Me.Label2.TabIndex = 11
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
		Me.Label1.Text = "Numéro de projet :"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(89, 17)
		Me.Label1.Location = New System.Drawing.Point(8, 344)
		Me.Label1.TabIndex = 6
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
		Me.Controls.Add(CmdModifier)
		Me.Controls.Add(cmdexcel)
		Me.Controls.Add(mvwDate)
		Me.Controls.Add(_optTypePunch_1)
		Me.Controls.Add(_optTypePunch_0)
		Me.Controls.Add(cmdExporter)
		Me.Controls.Add(chkKM)
		Me.Controls.Add(txtSemaine)
		Me.Controls.Add(cmdDateSemaine)
		Me.Controls.Add(cmdImprimer)
		Me.Controls.Add(cmdDate)
		Me.Controls.Add(txtCommentaires)
		Me.Controls.Add(cmbEmployé)
		Me.Controls.Add(cmdEnregistrer)
		Me.Controls.Add(lvwPunch)
		Me.Controls.Add(cmdFermer)
		Me.Controls.Add(mskHeureFin)
		Me.Controls.Add(mskDate)
		Me.Controls.Add(mskHeureDebut)
		Me.Controls.Add(cmdAjouter)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(mskNoProjet)
		Me.Controls.Add(txtKM)
		Me.Controls.Add(txtClient)
		Me.Controls.Add(cmbType)
		Me.Controls.Add(lblType)
		Me.Controls.Add(lblPrefixe)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label8)
		Me.Controls.Add(lblSemaine)
		Me.Controls.Add(Label7)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.lvwPunch.Columns.Add(_lvwPunch_ColumnHeader_1)
		Me.lvwPunch.Columns.Add(_lvwPunch_ColumnHeader_2)
		Me.lvwPunch.Columns.Add(_lvwPunch_ColumnHeader_3)
		Me.lvwPunch.Columns.Add(_lvwPunch_ColumnHeader_4)
		Me.lvwPunch.Columns.Add(_lvwPunch_ColumnHeader_5)
		Me.lvwPunch.Columns.Add(_lvwPunch_ColumnHeader_6)
		Me.lvwPunch.Columns.Add(_lvwPunch_ColumnHeader_7)
		Me.optTypePunch.SetIndex(_optTypePunch_1, CType(1, Short))
		Me.optTypePunch.SetIndex(_optTypePunch_0, CType(0, Short))
		CType(Me.optTypePunch, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).EndInit()
		Me.lvwPunch.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class