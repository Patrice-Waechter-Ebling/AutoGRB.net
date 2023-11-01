<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmoutils
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
	Public WithEvents cmdRechercher As System.Windows.Forms.Button
	Public WithEvents txtRecherche As System.Windows.Forms.TextBox
	Public WithEvents cmbdepartement As System.Windows.Forms.ComboBox
	Public WithEvents CmdAdd As System.Windows.Forms.Button
	Public WithEvents CmdSupp As System.Windows.Forms.Button
	Public WithEvents CmdFerme As System.Windows.Forms.Button
	Public WithEvents CmdModif As System.Windows.Forms.Button
	Public WithEvents cmdreport As System.Windows.Forms.Button
	Public WithEvents CmdEnr As System.Windows.Forms.Button
	Public WithEvents CmdAnul As System.Windows.Forms.Button
	Public WithEvents mvwDate As AxMSComCtl2.AxMonthView
	Public WithEvents cmdDateAchat As System.Windows.Forms.Button
	Public WithEvents cmdDateHorsfonction As System.Windows.Forms.Button
	Public WithEvents txtno As System.Windows.Forms.TextBox
	Public WithEvents cmbetiquette As System.Windows.Forms.ComboBox
	Public WithEvents cmbdepartement_modif As System.Windows.Forms.ComboBox
	Public WithEvents txtcommentaire As System.Windows.Forms.TextBox
	Public WithEvents txtoutils As System.Windows.Forms.TextBox
	Public WithEvents txtcout As System.Windows.Forms.MaskedTextBox
	Public WithEvents txthorsfonction As System.Windows.Forms.MaskedTextBox
	Public WithEvents txtachat As System.Windows.Forms.MaskedTextBox
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents fraModif As System.Windows.Forms.GroupBox
	Public WithEvents _lstoutils_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstoutils_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstoutils_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstoutils_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstoutils_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstoutils_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstoutils_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents lstoutils As System.Windows.Forms.ListView
	Public WithEvents lblRecherche As System.Windows.Forms.Label
	Public WithEvents lbldepartement As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmoutils))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdRechercher = New System.Windows.Forms.Button
		Me.txtRecherche = New System.Windows.Forms.TextBox
		Me.cmbdepartement = New System.Windows.Forms.ComboBox
		Me.CmdAdd = New System.Windows.Forms.Button
		Me.CmdSupp = New System.Windows.Forms.Button
		Me.CmdFerme = New System.Windows.Forms.Button
		Me.CmdModif = New System.Windows.Forms.Button
		Me.cmdreport = New System.Windows.Forms.Button
		Me.CmdEnr = New System.Windows.Forms.Button
		Me.CmdAnul = New System.Windows.Forms.Button
		Me.fraModif = New System.Windows.Forms.GroupBox
		Me.mvwDate = New AxMSComCtl2.AxMonthView
		Me.cmdDateAchat = New System.Windows.Forms.Button
		Me.cmdDateHorsfonction = New System.Windows.Forms.Button
		Me.txtno = New System.Windows.Forms.TextBox
		Me.cmbetiquette = New System.Windows.Forms.ComboBox
		Me.cmbdepartement_modif = New System.Windows.Forms.ComboBox
		Me.txtcommentaire = New System.Windows.Forms.TextBox
		Me.txtoutils = New System.Windows.Forms.TextBox
		Me.txtcout = New System.Windows.Forms.MaskedTextBox
		Me.txthorsfonction = New System.Windows.Forms.MaskedTextBox
		Me.txtachat = New System.Windows.Forms.MaskedTextBox
		Me.Label10 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.lstoutils = New System.Windows.Forms.ListView
		Me._lstoutils_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lstoutils_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lstoutils_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lstoutils_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lstoutils_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lstoutils_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me._lstoutils_ColumnHeader_7 = New System.Windows.Forms.ColumnHeader
		Me.lblRecherche = New System.Windows.Forms.Label
		Me.lbldepartement = New System.Windows.Forms.Label
		Me.fraModif.SuspendLayout()
		Me.lstoutils.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Machinerie & Outillage"
		Me.ClientSize = New System.Drawing.Size(526, 391)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmoutils.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmoutils"
		Me.cmdRechercher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRechercher.Text = "Rechercher"
		Me.cmdRechercher.Size = New System.Drawing.Size(73, 25)
		Me.cmdRechercher.Location = New System.Drawing.Point(440, 72)
		Me.cmdRechercher.TabIndex = 2
		Me.cmdRechercher.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercher.CausesValidation = True
		Me.cmdRechercher.Enabled = True
		Me.cmdRechercher.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercher.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercher.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercher.TabStop = True
		Me.cmdRechercher.Name = "cmdRechercher"
		Me.txtRecherche.AutoSize = False
		Me.txtRecherche.Size = New System.Drawing.Size(121, 19)
		Me.txtRecherche.Location = New System.Drawing.Point(304, 80)
		Me.txtRecherche.TabIndex = 4
		Me.txtRecherche.AcceptsReturn = True
		Me.txtRecherche.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtRecherche.BackColor = System.Drawing.SystemColors.Window
		Me.txtRecherche.CausesValidation = True
		Me.txtRecherche.Enabled = True
		Me.txtRecherche.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtRecherche.HideSelection = True
		Me.txtRecherche.ReadOnly = False
		Me.txtRecherche.Maxlength = 0
		Me.txtRecherche.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtRecherche.MultiLine = False
		Me.txtRecherche.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtRecherche.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtRecherche.TabStop = True
		Me.txtRecherche.Visible = True
		Me.txtRecherche.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtRecherche.Name = "txtRecherche"
		Me.cmbdepartement.Size = New System.Drawing.Size(145, 21)
		Me.cmbdepartement.Location = New System.Drawing.Point(8, 80)
		Me.cmbdepartement.Sorted = True
		Me.cmbdepartement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbdepartement.TabIndex = 3
		Me.cmbdepartement.BackColor = System.Drawing.SystemColors.Window
		Me.cmbdepartement.CausesValidation = True
		Me.cmbdepartement.Enabled = True
		Me.cmbdepartement.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbdepartement.IntegralHeight = True
		Me.cmbdepartement.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbdepartement.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbdepartement.TabStop = True
		Me.cmbdepartement.Visible = True
		Me.cmbdepartement.Name = "cmbdepartement"
		Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdAdd.BackColor = System.Drawing.SystemColors.Control
		Me.CmdAdd.Text = "&Ajouter"
		Me.CmdAdd.Size = New System.Drawing.Size(97, 33)
		Me.CmdAdd.Location = New System.Drawing.Point(112, 352)
		Me.CmdAdd.TabIndex = 28
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
		Me.CmdSupp.Size = New System.Drawing.Size(97, 33)
		Me.CmdSupp.Location = New System.Drawing.Point(216, 352)
		Me.CmdSupp.TabIndex = 31
		Me.CmdSupp.CausesValidation = True
		Me.CmdSupp.Enabled = True
		Me.CmdSupp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdSupp.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdSupp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdSupp.TabStop = True
		Me.CmdSupp.Name = "CmdSupp"
		Me.CmdFerme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdFerme.BackColor = System.Drawing.SystemColors.Control
		Me.CmdFerme.Text = "&Fermer"
		Me.CmdFerme.Size = New System.Drawing.Size(97, 33)
		Me.CmdFerme.Location = New System.Drawing.Point(424, 352)
		Me.CmdFerme.TabIndex = 33
		Me.CmdFerme.CausesValidation = True
		Me.CmdFerme.Enabled = True
		Me.CmdFerme.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdFerme.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdFerme.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdFerme.TabStop = True
		Me.CmdFerme.Name = "CmdFerme"
		Me.CmdModif.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdModif.BackColor = System.Drawing.SystemColors.Control
		Me.CmdModif.Text = "&Modifier"
		Me.CmdModif.Size = New System.Drawing.Size(97, 33)
		Me.CmdModif.Location = New System.Drawing.Point(320, 352)
		Me.CmdModif.TabIndex = 32
		Me.CmdModif.CausesValidation = True
		Me.CmdModif.Enabled = True
		Me.CmdModif.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdModif.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdModif.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdModif.TabStop = True
		Me.CmdModif.Name = "CmdModif"
		Me.cmdreport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdreport.BackColor = System.Drawing.SystemColors.Control
		Me.cmdreport.Text = "&Impression"
		Me.cmdreport.Size = New System.Drawing.Size(97, 33)
		Me.cmdreport.Location = New System.Drawing.Point(8, 352)
		Me.cmdreport.TabIndex = 27
		Me.cmdreport.CausesValidation = True
		Me.cmdreport.Enabled = True
		Me.cmdreport.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdreport.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdreport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdreport.TabStop = True
		Me.cmdreport.Name = "cmdreport"
		Me.CmdEnr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdEnr.Text = "&Enregistrer"
		Me.CmdEnr.Size = New System.Drawing.Size(97, 33)
		Me.CmdEnr.Location = New System.Drawing.Point(112, 352)
		Me.CmdEnr.TabIndex = 29
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
		Me.CmdAnul.Size = New System.Drawing.Size(97, 33)
		Me.CmdAnul.Location = New System.Drawing.Point(216, 352)
		Me.CmdAnul.TabIndex = 30
		Me.CmdAnul.BackColor = System.Drawing.SystemColors.Control
		Me.CmdAnul.CausesValidation = True
		Me.CmdAnul.Enabled = True
		Me.CmdAnul.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdAnul.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdAnul.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdAnul.TabStop = True
		Me.CmdAnul.Name = "CmdAnul"
		Me.fraModif.BackColor = System.Drawing.Color.Black
		Me.fraModif.ForeColor = System.Drawing.Color.White
		Me.fraModif.Size = New System.Drawing.Size(513, 241)
		Me.fraModif.Location = New System.Drawing.Point(8, 104)
		Me.fraModif.TabIndex = 5
		Me.fraModif.Visible = False
		Me.fraModif.Enabled = True
		Me.fraModif.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraModif.Padding = New System.Windows.Forms.Padding(0)
		Me.fraModif.Name = "fraModif"
		mvwDate.OcxState = CType(resources.GetObject("mvwDate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwDate.Size = New System.Drawing.Size(176, 158)
		Me.mvwDate.Location = New System.Drawing.Point(120, 48)
		Me.mvwDate.TabIndex = 11
		Me.mvwDate.Visible = False
		Me.mvwDate.Name = "mvwDate"
		Me.cmdDateAchat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDateAchat.Text = "..."
		Me.cmdDateAchat.Size = New System.Drawing.Size(25, 17)
		Me.cmdDateAchat.Location = New System.Drawing.Point(176, 136)
		Me.cmdDateAchat.TabIndex = 19
		Me.cmdDateAchat.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDateAchat.CausesValidation = True
		Me.cmdDateAchat.Enabled = True
		Me.cmdDateAchat.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDateAchat.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDateAchat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDateAchat.TabStop = True
		Me.cmdDateAchat.Name = "cmdDateAchat"
		Me.cmdDateHorsfonction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDateHorsfonction.Text = "..."
		Me.cmdDateHorsfonction.Size = New System.Drawing.Size(25, 17)
		Me.cmdDateHorsfonction.Location = New System.Drawing.Point(176, 160)
		Me.cmdDateHorsfonction.TabIndex = 23
		Me.cmdDateHorsfonction.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDateHorsfonction.CausesValidation = True
		Me.cmdDateHorsfonction.Enabled = True
		Me.cmdDateHorsfonction.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDateHorsfonction.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDateHorsfonction.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDateHorsfonction.TabStop = True
		Me.cmdDateHorsfonction.Name = "cmdDateHorsfonction"
		Me.txtno.AutoSize = False
		Me.txtno.Size = New System.Drawing.Size(73, 19)
		Me.txtno.Location = New System.Drawing.Point(96, 64)
		Me.txtno.TabIndex = 12
		Me.txtno.AcceptsReturn = True
		Me.txtno.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtno.BackColor = System.Drawing.SystemColors.Window
		Me.txtno.CausesValidation = True
		Me.txtno.Enabled = True
		Me.txtno.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtno.HideSelection = True
		Me.txtno.ReadOnly = False
		Me.txtno.Maxlength = 0
		Me.txtno.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtno.MultiLine = False
		Me.txtno.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtno.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtno.TabStop = True
		Me.txtno.Visible = True
		Me.txtno.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtno.Name = "txtno"
		Me.cmbetiquette.Size = New System.Drawing.Size(169, 21)
		Me.cmbetiquette.Location = New System.Drawing.Point(96, 40)
		Me.cmbetiquette.TabIndex = 9
		Me.cmbetiquette.BackColor = System.Drawing.SystemColors.Window
		Me.cmbetiquette.CausesValidation = True
		Me.cmbetiquette.Enabled = True
		Me.cmbetiquette.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbetiquette.IntegralHeight = True
		Me.cmbetiquette.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbetiquette.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbetiquette.Sorted = False
		Me.cmbetiquette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbetiquette.TabStop = True
		Me.cmbetiquette.Visible = True
		Me.cmbetiquette.Name = "cmbetiquette"
		Me.cmbdepartement_modif.Size = New System.Drawing.Size(169, 21)
		Me.cmbdepartement_modif.Location = New System.Drawing.Point(96, 16)
		Me.cmbdepartement_modif.TabIndex = 7
		Me.cmbdepartement_modif.BackColor = System.Drawing.SystemColors.Window
		Me.cmbdepartement_modif.CausesValidation = True
		Me.cmbdepartement_modif.Enabled = True
		Me.cmbdepartement_modif.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbdepartement_modif.IntegralHeight = True
		Me.cmbdepartement_modif.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbdepartement_modif.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbdepartement_modif.Sorted = False
		Me.cmbdepartement_modif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbdepartement_modif.TabStop = True
		Me.cmbdepartement_modif.Visible = True
		Me.cmbdepartement_modif.Name = "cmbdepartement_modif"
		Me.txtcommentaire.AutoSize = False
		Me.txtcommentaire.Size = New System.Drawing.Size(393, 43)
		Me.txtcommentaire.Location = New System.Drawing.Point(96, 184)
		Me.txtcommentaire.MultiLine = True
		Me.txtcommentaire.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtcommentaire.TabIndex = 25
		Me.txtcommentaire.AcceptsReturn = True
		Me.txtcommentaire.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtcommentaire.BackColor = System.Drawing.SystemColors.Window
		Me.txtcommentaire.CausesValidation = True
		Me.txtcommentaire.Enabled = True
		Me.txtcommentaire.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtcommentaire.HideSelection = True
		Me.txtcommentaire.ReadOnly = False
		Me.txtcommentaire.Maxlength = 0
		Me.txtcommentaire.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtcommentaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtcommentaire.TabStop = True
		Me.txtcommentaire.Visible = True
		Me.txtcommentaire.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtcommentaire.Name = "txtcommentaire"
		Me.txtoutils.AutoSize = False
		Me.txtoutils.Size = New System.Drawing.Size(321, 19)
		Me.txtoutils.Location = New System.Drawing.Point(96, 88)
		Me.txtoutils.TabIndex = 14
		Me.txtoutils.AcceptsReturn = True
		Me.txtoutils.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtoutils.BackColor = System.Drawing.SystemColors.Window
		Me.txtoutils.CausesValidation = True
		Me.txtoutils.Enabled = True
		Me.txtoutils.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtoutils.HideSelection = True
		Me.txtoutils.ReadOnly = False
		Me.txtoutils.Maxlength = 0
		Me.txtoutils.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtoutils.MultiLine = False
		Me.txtoutils.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtoutils.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtoutils.TabStop = True
		Me.txtoutils.Visible = True
		Me.txtoutils.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtoutils.Name = "txtoutils"
		Me.txtcout.AllowPromptAsInput = False
		Me.txtcout.Size = New System.Drawing.Size(65, 20)
		Me.txtcout.Location = New System.Drawing.Point(96, 112)
		Me.txtcout.TabIndex = 16
		Me.txtcout.PromptChar = "_"
		Me.txtcout.Name = "txtcout"
		Me.txthorsfonction.AllowPromptAsInput = False
		Me.txthorsfonction.Size = New System.Drawing.Size(73, 20)
		Me.txthorsfonction.Location = New System.Drawing.Point(96, 160)
		Me.txthorsfonction.TabIndex = 22
		Me.txthorsfonction.PromptChar = "_"
		Me.txthorsfonction.Name = "txthorsfonction"
		Me.txtachat.AllowPromptAsInput = False
		Me.txtachat.Size = New System.Drawing.Size(73, 20)
		Me.txtachat.Location = New System.Drawing.Point(96, 136)
		Me.txtachat.TabIndex = 18
		Me.txtachat.PromptChar = "_"
		Me.txtachat.Name = "txtachat"
		Me.Label10.Text = "AA-MM-JJ"
		Me.Label10.ForeColor = System.Drawing.Color.White
		Me.Label10.Size = New System.Drawing.Size(81, 17)
		Me.Label10.Location = New System.Drawing.Point(24, 148)
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
		Me.Label2.Text = "No. Outil"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(73, 17)
		Me.Label2.Location = New System.Drawing.Point(8, 64)
		Me.Label2.TabIndex = 10
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
		Me.Label9.Text = "Commentaire"
		Me.Label9.ForeColor = System.Drawing.Color.White
		Me.Label9.Size = New System.Drawing.Size(73, 17)
		Me.Label9.Location = New System.Drawing.Point(8, 184)
		Me.Label9.TabIndex = 24
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
		Me.Label8.Text = "Disposition"
		Me.Label8.ForeColor = System.Drawing.Color.White
		Me.Label8.Size = New System.Drawing.Size(81, 17)
		Me.Label8.Location = New System.Drawing.Point(8, 160)
		Me.Label8.TabIndex = 21
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
		Me.Label7.Text = "Date achat"
		Me.Label7.ForeColor = System.Drawing.Color.White
		Me.Label7.Size = New System.Drawing.Size(73, 17)
		Me.Label7.Location = New System.Drawing.Point(8, 136)
		Me.Label7.TabIndex = 17
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
		Me.Label6.Text = "Étiquette"
		Me.Label6.ForeColor = System.Drawing.Color.White
		Me.Label6.Size = New System.Drawing.Size(73, 17)
		Me.Label6.Location = New System.Drawing.Point(8, 40)
		Me.Label6.TabIndex = 8
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
		Me.Label5.Text = "Coût"
		Me.Label5.ForeColor = System.Drawing.Color.White
		Me.Label5.Size = New System.Drawing.Size(73, 17)
		Me.Label5.Location = New System.Drawing.Point(8, 112)
		Me.Label5.TabIndex = 15
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
		Me.Label4.Text = "Département"
		Me.Label4.ForeColor = System.Drawing.Color.White
		Me.Label4.Size = New System.Drawing.Size(73, 17)
		Me.Label4.Location = New System.Drawing.Point(8, 16)
		Me.Label4.TabIndex = 6
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
		Me.Label3.Text = "Outil"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(73, 17)
		Me.Label3.Location = New System.Drawing.Point(8, 88)
		Me.Label3.TabIndex = 13
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
		Me.lstoutils.Size = New System.Drawing.Size(513, 225)
		Me.lstoutils.Location = New System.Drawing.Point(8, 112)
		Me.lstoutils.TabIndex = 26
		Me.lstoutils.View = System.Windows.Forms.View.Details
		Me.lstoutils.LabelEdit = False
		Me.lstoutils.LabelWrap = True
		Me.lstoutils.HideSelection = True
		Me.lstoutils.FullRowSelect = True
		Me.lstoutils.GridLines = True
		Me.lstoutils.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstoutils.BackColor = System.Drawing.SystemColors.Window
		Me.lstoutils.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstoutils.Name = "lstoutils"
		Me._lstoutils_ColumnHeader_1.Text = "No"
		Me._lstoutils_ColumnHeader_1.Width = 59
		Me._lstoutils_ColumnHeader_2.Text = "Nom"
		Me._lstoutils_ColumnHeader_2.Width = 353
		Me._lstoutils_ColumnHeader_3.Text = "Achat"
		Me._lstoutils_ColumnHeader_3.Width = 118
		Me._lstoutils_ColumnHeader_4.Text = "Disposition"
		Me._lstoutils_ColumnHeader_4.Width = 118
		Me._lstoutils_ColumnHeader_5.Text = "Coût"
		Me._lstoutils_ColumnHeader_5.Width = 118
		Me._lstoutils_ColumnHeader_6.Text = "Étiquette"
		Me._lstoutils_ColumnHeader_6.Width = 118
		Me._lstoutils_ColumnHeader_7.Text = "Commentaire"
		Me._lstoutils_ColumnHeader_7.Width = 236
		Me.lblRecherche.Text = "Recherche :"
		Me.lblRecherche.ForeColor = System.Drawing.Color.White
		Me.lblRecherche.Size = New System.Drawing.Size(73, 17)
		Me.lblRecherche.Location = New System.Drawing.Point(304, 64)
		Me.lblRecherche.TabIndex = 1
		Me.lblRecherche.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblRecherche.BackColor = System.Drawing.Color.Transparent
		Me.lblRecherche.Enabled = True
		Me.lblRecherche.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblRecherche.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblRecherche.UseMnemonic = True
		Me.lblRecherche.Visible = True
		Me.lblRecherche.AutoSize = False
		Me.lblRecherche.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblRecherche.Name = "lblRecherche"
		Me.lbldepartement.Text = "Département"
		Me.lbldepartement.ForeColor = System.Drawing.Color.White
		Me.lbldepartement.Size = New System.Drawing.Size(137, 17)
		Me.lbldepartement.Location = New System.Drawing.Point(8, 64)
		Me.lbldepartement.TabIndex = 0
		Me.lbldepartement.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbldepartement.BackColor = System.Drawing.Color.Transparent
		Me.lbldepartement.Enabled = True
		Me.lbldepartement.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbldepartement.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbldepartement.UseMnemonic = True
		Me.lbldepartement.Visible = True
		Me.lbldepartement.AutoSize = False
		Me.lbldepartement.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbldepartement.Name = "lbldepartement"
		Me.Controls.Add(cmdRechercher)
		Me.Controls.Add(txtRecherche)
		Me.Controls.Add(cmbdepartement)
		Me.Controls.Add(CmdAdd)
		Me.Controls.Add(CmdSupp)
		Me.Controls.Add(CmdFerme)
		Me.Controls.Add(CmdModif)
		Me.Controls.Add(cmdreport)
		Me.Controls.Add(CmdEnr)
		Me.Controls.Add(CmdAnul)
		Me.Controls.Add(fraModif)
		Me.Controls.Add(lstoutils)
		Me.Controls.Add(lblRecherche)
		Me.Controls.Add(lbldepartement)
		Me.fraModif.Controls.Add(mvwDate)
		Me.fraModif.Controls.Add(cmdDateAchat)
		Me.fraModif.Controls.Add(cmdDateHorsfonction)
		Me.fraModif.Controls.Add(txtno)
		Me.fraModif.Controls.Add(cmbetiquette)
		Me.fraModif.Controls.Add(cmbdepartement_modif)
		Me.fraModif.Controls.Add(txtcommentaire)
		Me.fraModif.Controls.Add(txtoutils)
		Me.fraModif.Controls.Add(txtcout)
		Me.fraModif.Controls.Add(txthorsfonction)
		Me.fraModif.Controls.Add(txtachat)
		Me.fraModif.Controls.Add(Label10)
		Me.fraModif.Controls.Add(Label2)
		Me.fraModif.Controls.Add(Label9)
		Me.fraModif.Controls.Add(Label8)
		Me.fraModif.Controls.Add(Label7)
		Me.fraModif.Controls.Add(Label6)
		Me.fraModif.Controls.Add(Label5)
		Me.fraModif.Controls.Add(Label4)
		Me.fraModif.Controls.Add(Label3)
		Me.lstoutils.Columns.Add(_lstoutils_ColumnHeader_1)
		Me.lstoutils.Columns.Add(_lstoutils_ColumnHeader_2)
		Me.lstoutils.Columns.Add(_lstoutils_ColumnHeader_3)
		Me.lstoutils.Columns.Add(_lstoutils_ColumnHeader_4)
		Me.lstoutils.Columns.Add(_lstoutils_ColumnHeader_5)
		Me.lstoutils.Columns.Add(_lstoutils_ColumnHeader_6)
		Me.lstoutils.Columns.Add(_lstoutils_ColumnHeader_7)
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).EndInit()
		Me.fraModif.ResumeLayout(False)
		Me.lstoutils.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class