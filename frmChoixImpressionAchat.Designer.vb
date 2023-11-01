<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixImpressionAchat
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
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents cmdImprimer As System.Windows.Forms.Button
	Public WithEvents cmdDateFin As System.Windows.Forms.Button
	Public WithEvents cmdDateDebut As System.Windows.Forms.Button
	Public WithEvents mskDateDebut As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskDateFin As System.Windows.Forms.MaskedTextBox
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents fraDate As System.Windows.Forms.GroupBox
	Public WithEvents _optCategorie_2 As System.Windows.Forms.RadioButton
	Public WithEvents _optCategorie_7 As System.Windows.Forms.RadioButton
	Public WithEvents _optCategorie_6 As System.Windows.Forms.RadioButton
	Public WithEvents _optCategorie_5 As System.Windows.Forms.RadioButton
	Public WithEvents _optCategorie_4 As System.Windows.Forms.RadioButton
	Public WithEvents _optCategorie_3 As System.Windows.Forms.RadioButton
	Public WithEvents _optCategorie_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optCategorie_0 As System.Windows.Forms.RadioButton
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label28 As System.Windows.Forms.Label
	Public WithEvents Label27 As System.Windows.Forms.Label
	Public WithEvents Label26 As System.Windows.Forms.Label
	Public WithEvents Label25 As System.Windows.Forms.Label
	Public WithEvents Label24 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents fraCategorie As System.Windows.Forms.GroupBox
	Public WithEvents optCategorie As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixImpressionAchat))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.mvwDate = New AxMSComCtl2.AxMonthView
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.cmdImprimer = New System.Windows.Forms.Button
		Me.fraDate = New System.Windows.Forms.GroupBox
		Me.cmdDateFin = New System.Windows.Forms.Button
		Me.cmdDateDebut = New System.Windows.Forms.Button
		Me.mskDateDebut = New System.Windows.Forms.MaskedTextBox
		Me.mskDateFin = New System.Windows.Forms.MaskedTextBox
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.fraCategorie = New System.Windows.Forms.GroupBox
		Me._optCategorie_2 = New System.Windows.Forms.RadioButton
		Me._optCategorie_7 = New System.Windows.Forms.RadioButton
		Me._optCategorie_6 = New System.Windows.Forms.RadioButton
		Me._optCategorie_5 = New System.Windows.Forms.RadioButton
		Me._optCategorie_4 = New System.Windows.Forms.RadioButton
		Me._optCategorie_3 = New System.Windows.Forms.RadioButton
		Me._optCategorie_1 = New System.Windows.Forms.RadioButton
		Me._optCategorie_0 = New System.Windows.Forms.RadioButton
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label28 = New System.Windows.Forms.Label
		Me.Label27 = New System.Windows.Forms.Label
		Me.Label26 = New System.Windows.Forms.Label
		Me.Label25 = New System.Windows.Forms.Label
		Me.Label24 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.optCategorie = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.fraDate.SuspendLayout()
		Me.fraCategorie.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optCategorie, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Impression des achats"
		Me.ClientSize = New System.Drawing.Size(285, 345)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixImpressionAchat.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "frmChoixImpressionAchat"
		mvwDate.OcxState = CType(resources.GetObject("mvwDate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwDate.Size = New System.Drawing.Size(176, 158)
		Me.mvwDate.Location = New System.Drawing.Point(96, 176)
		Me.mvwDate.TabIndex = 17
		Me.mvwDate.Visible = False
		Me.mvwDate.Name = "mvwDate"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(89, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(88, 312)
		Me.cmdAnnuler.TabIndex = 25
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.cmdImprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdImprimer.Text = "Imprimer"
		Me.cmdImprimer.Size = New System.Drawing.Size(89, 25)
		Me.cmdImprimer.Location = New System.Drawing.Point(184, 312)
		Me.cmdImprimer.TabIndex = 26
		Me.cmdImprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdImprimer.CausesValidation = True
		Me.cmdImprimer.Enabled = True
		Me.cmdImprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdImprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdImprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdImprimer.TabStop = True
		Me.cmdImprimer.Name = "cmdImprimer"
		Me.fraDate.BackColor = System.Drawing.Color.Black
		Me.fraDate.Text = "Date (AA-MM-JJ)"
		Me.fraDate.ForeColor = System.Drawing.Color.White
		Me.fraDate.Size = New System.Drawing.Size(265, 81)
		Me.fraDate.Location = New System.Drawing.Point(8, 224)
		Me.fraDate.TabIndex = 18
		Me.fraDate.Enabled = True
		Me.fraDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraDate.Visible = True
		Me.fraDate.Padding = New System.Windows.Forms.Padding(0)
		Me.fraDate.Name = "fraDate"
		Me.cmdDateFin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDateFin.Text = "..."
		Me.cmdDateFin.Size = New System.Drawing.Size(25, 17)
		Me.cmdDateFin.Location = New System.Drawing.Point(144, 56)
		Me.cmdDateFin.TabIndex = 24
		Me.cmdDateFin.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDateFin.CausesValidation = True
		Me.cmdDateFin.Enabled = True
		Me.cmdDateFin.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDateFin.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDateFin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDateFin.TabStop = True
		Me.cmdDateFin.Name = "cmdDateFin"
		Me.cmdDateDebut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDateDebut.Text = "..."
		Me.cmdDateDebut.Size = New System.Drawing.Size(25, 17)
		Me.cmdDateDebut.Location = New System.Drawing.Point(144, 24)
		Me.cmdDateDebut.TabIndex = 21
		Me.cmdDateDebut.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDateDebut.CausesValidation = True
		Me.cmdDateDebut.Enabled = True
		Me.cmdDateDebut.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDateDebut.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDateDebut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDateDebut.TabStop = True
		Me.cmdDateDebut.Name = "cmdDateDebut"
		Me.mskDateDebut.AllowPromptAsInput = False
		Me.mskDateDebut.Size = New System.Drawing.Size(73, 17)
		Me.mskDateDebut.Location = New System.Drawing.Point(64, 24)
		Me.mskDateDebut.TabIndex = 20
		Me.mskDateDebut.PromptChar = "_"
		Me.mskDateDebut.Name = "mskDateDebut"
		Me.mskDateFin.AllowPromptAsInput = False
		Me.mskDateFin.Size = New System.Drawing.Size(73, 17)
		Me.mskDateFin.Location = New System.Drawing.Point(64, 56)
		Me.mskDateFin.TabIndex = 23
		Me.mskDateFin.PromptChar = "_"
		Me.mskDateFin.Name = "mskDateFin"
		Me.Label4.BackColor = System.Drawing.Color.Black
		Me.Label4.Text = "Au :"
		Me.Label4.ForeColor = System.Drawing.Color.White
		Me.Label4.Size = New System.Drawing.Size(25, 17)
		Me.Label4.Location = New System.Drawing.Point(32, 56)
		Me.Label4.TabIndex = 22
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.Enabled = True
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.BackColor = System.Drawing.Color.Black
		Me.Label3.Text = "Du :"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(25, 17)
		Me.Label3.Location = New System.Drawing.Point(32, 24)
		Me.Label3.TabIndex = 19
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.Enabled = True
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.fraCategorie.BackColor = System.Drawing.Color.Black
		Me.fraCategorie.Text = "Catégories d'achat"
		Me.fraCategorie.ForeColor = System.Drawing.Color.White
		Me.fraCategorie.Size = New System.Drawing.Size(265, 161)
		Me.fraCategorie.Location = New System.Drawing.Point(8, 56)
		Me.fraCategorie.TabIndex = 0
		Me.fraCategorie.Enabled = True
		Me.fraCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraCategorie.Visible = True
		Me.fraCategorie.Padding = New System.Windows.Forms.Padding(0)
		Me.fraCategorie.Name = "fraCategorie"
		Me._optCategorie_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCategorie_2.BackColor = System.Drawing.Color.Black
		Me._optCategorie_2.Text = "Formation"
		Me._optCategorie_2.ForeColor = System.Drawing.Color.White
		Me._optCategorie_2.Size = New System.Drawing.Size(137, 17)
		Me._optCategorie_2.Location = New System.Drawing.Point(24, 56)
		Me._optCategorie_2.TabIndex = 5
		Me._optCategorie_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCategorie_2.CausesValidation = True
		Me._optCategorie_2.Enabled = True
		Me._optCategorie_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._optCategorie_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optCategorie_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optCategorie_2.TabStop = True
		Me._optCategorie_2.Checked = False
		Me._optCategorie_2.Visible = True
		Me._optCategorie_2.Name = "_optCategorie_2"
		Me._optCategorie_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCategorie_7.BackColor = System.Drawing.Color.Black
		Me._optCategorie_7.Text = "Équipement && outillage"
		Me._optCategorie_7.ForeColor = System.Drawing.Color.White
		Me._optCategorie_7.Size = New System.Drawing.Size(137, 17)
		Me._optCategorie_7.Location = New System.Drawing.Point(24, 136)
		Me._optCategorie_7.TabIndex = 15
		Me._optCategorie_7.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCategorie_7.CausesValidation = True
		Me._optCategorie_7.Enabled = True
		Me._optCategorie_7.Cursor = System.Windows.Forms.Cursors.Default
		Me._optCategorie_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optCategorie_7.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optCategorie_7.TabStop = True
		Me._optCategorie_7.Checked = False
		Me._optCategorie_7.Visible = True
		Me._optCategorie_7.Name = "_optCategorie_7"
		Me._optCategorie_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCategorie_6.BackColor = System.Drawing.Color.Black
		Me._optCategorie_6.Text = "Équipement && outillage PPE"
		Me._optCategorie_6.ForeColor = System.Drawing.Color.White
		Me._optCategorie_6.Size = New System.Drawing.Size(153, 17)
		Me._optCategorie_6.Location = New System.Drawing.Point(24, 120)
		Me._optCategorie_6.TabIndex = 13
		Me._optCategorie_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCategorie_6.CausesValidation = True
		Me._optCategorie_6.Enabled = True
		Me._optCategorie_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._optCategorie_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optCategorie_6.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optCategorie_6.TabStop = True
		Me._optCategorie_6.Checked = False
		Me._optCategorie_6.Visible = True
		Me._optCategorie_6.Name = "_optCategorie_6"
		Me._optCategorie_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCategorie_5.BackColor = System.Drawing.Color.Black
		Me._optCategorie_5.Text = "Équipement de bureau"
		Me._optCategorie_5.ForeColor = System.Drawing.Color.White
		Me._optCategorie_5.Size = New System.Drawing.Size(137, 17)
		Me._optCategorie_5.Location = New System.Drawing.Point(24, 104)
		Me._optCategorie_5.TabIndex = 11
		Me._optCategorie_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCategorie_5.CausesValidation = True
		Me._optCategorie_5.Enabled = True
		Me._optCategorie_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._optCategorie_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optCategorie_5.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optCategorie_5.TabStop = True
		Me._optCategorie_5.Checked = False
		Me._optCategorie_5.Visible = True
		Me._optCategorie_5.Name = "_optCategorie_5"
		Me._optCategorie_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCategorie_4.BackColor = System.Drawing.Color.Black
		Me._optCategorie_4.Text = "Bâtiment"
		Me._optCategorie_4.ForeColor = System.Drawing.Color.White
		Me._optCategorie_4.Size = New System.Drawing.Size(137, 17)
		Me._optCategorie_4.Location = New System.Drawing.Point(24, 88)
		Me._optCategorie_4.TabIndex = 9
		Me._optCategorie_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCategorie_4.CausesValidation = True
		Me._optCategorie_4.Enabled = True
		Me._optCategorie_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._optCategorie_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optCategorie_4.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optCategorie_4.TabStop = True
		Me._optCategorie_4.Checked = False
		Me._optCategorie_4.Visible = True
		Me._optCategorie_4.Name = "_optCategorie_4"
		Me._optCategorie_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCategorie_3.BackColor = System.Drawing.Color.Black
		Me._optCategorie_3.Text = "Logiciel interne"
		Me._optCategorie_3.ForeColor = System.Drawing.Color.White
		Me._optCategorie_3.Size = New System.Drawing.Size(137, 17)
		Me._optCategorie_3.Location = New System.Drawing.Point(24, 72)
		Me._optCategorie_3.TabIndex = 7
		Me._optCategorie_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCategorie_3.CausesValidation = True
		Me._optCategorie_3.Enabled = True
		Me._optCategorie_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._optCategorie_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optCategorie_3.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optCategorie_3.TabStop = True
		Me._optCategorie_3.Checked = False
		Me._optCategorie_3.Visible = True
		Me._optCategorie_3.Name = "_optCategorie_3"
		Me._optCategorie_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCategorie_1.BackColor = System.Drawing.Color.Black
		Me._optCategorie_1.Text = "Réparation outils GRB"
		Me._optCategorie_1.ForeColor = System.Drawing.Color.White
		Me._optCategorie_1.Size = New System.Drawing.Size(137, 17)
		Me._optCategorie_1.Location = New System.Drawing.Point(24, 40)
		Me._optCategorie_1.TabIndex = 3
		Me._optCategorie_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCategorie_1.CausesValidation = True
		Me._optCategorie_1.Enabled = True
		Me._optCategorie_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optCategorie_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optCategorie_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optCategorie_1.TabStop = True
		Me._optCategorie_1.Checked = False
		Me._optCategorie_1.Visible = True
		Me._optCategorie_1.Name = "_optCategorie_1"
		Me._optCategorie_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCategorie_0.BackColor = System.Drawing.Color.Black
		Me._optCategorie_0.Text = "Stocks plancher"
		Me._optCategorie_0.ForeColor = System.Drawing.Color.White
		Me._optCategorie_0.Size = New System.Drawing.Size(121, 17)
		Me._optCategorie_0.Location = New System.Drawing.Point(24, 24)
		Me._optCategorie_0.TabIndex = 1
		Me._optCategorie_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optCategorie_0.CausesValidation = True
		Me._optCategorie_0.Enabled = True
		Me._optCategorie_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optCategorie_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optCategorie_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optCategorie_0.TabStop = True
		Me._optCategorie_0.Checked = False
		Me._optCategorie_0.Visible = True
		Me._optCategorie_0.Name = "_optCategorie_0"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label5.BackColor = System.Drawing.Color.Black
		Me.Label5.Text = "83"
		Me.Label5.ForeColor = System.Drawing.Color.White
		Me.Label5.Size = New System.Drawing.Size(57, 17)
		Me.Label5.Location = New System.Drawing.Point(200, 56)
		Me.Label5.TabIndex = 6
		Me.Label5.Enabled = True
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label28.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label28.BackColor = System.Drawing.Color.Black
		Me.Label28.Text = "99"
		Me.Label28.ForeColor = System.Drawing.Color.White
		Me.Label28.Size = New System.Drawing.Size(57, 17)
		Me.Label28.Location = New System.Drawing.Point(200, 136)
		Me.Label28.TabIndex = 16
		Me.Label28.Enabled = True
		Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label28.UseMnemonic = True
		Me.Label28.Visible = True
		Me.Label28.AutoSize = False
		Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label28.Name = "Label28"
		Me.Label27.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label27.BackColor = System.Drawing.Color.Black
		Me.Label27.Text = "98"
		Me.Label27.ForeColor = System.Drawing.Color.White
		Me.Label27.Size = New System.Drawing.Size(57, 17)
		Me.Label27.Location = New System.Drawing.Point(200, 120)
		Me.Label27.TabIndex = 14
		Me.Label27.Enabled = True
		Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label27.UseMnemonic = True
		Me.Label27.Visible = True
		Me.Label27.AutoSize = False
		Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label27.Name = "Label27"
		Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label26.BackColor = System.Drawing.Color.Black
		Me.Label26.Text = "97"
		Me.Label26.ForeColor = System.Drawing.Color.White
		Me.Label26.Size = New System.Drawing.Size(57, 17)
		Me.Label26.Location = New System.Drawing.Point(200, 104)
		Me.Label26.TabIndex = 12
		Me.Label26.Enabled = True
		Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label26.UseMnemonic = True
		Me.Label26.Visible = True
		Me.Label26.AutoSize = False
		Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label26.Name = "Label26"
		Me.Label25.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label25.BackColor = System.Drawing.Color.Black
		Me.Label25.Text = "95"
		Me.Label25.ForeColor = System.Drawing.Color.White
		Me.Label25.Size = New System.Drawing.Size(57, 17)
		Me.Label25.Location = New System.Drawing.Point(200, 88)
		Me.Label25.TabIndex = 10
		Me.Label25.Enabled = True
		Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label25.UseMnemonic = True
		Me.Label25.Visible = True
		Me.Label25.AutoSize = False
		Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label25.Name = "Label25"
		Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label24.BackColor = System.Drawing.Color.Black
		Me.Label24.Text = "85"
		Me.Label24.ForeColor = System.Drawing.Color.White
		Me.Label24.Size = New System.Drawing.Size(57, 17)
		Me.Label24.Location = New System.Drawing.Point(200, 72)
		Me.Label24.TabIndex = 8
		Me.Label24.Enabled = True
		Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label24.UseMnemonic = True
		Me.Label24.Visible = True
		Me.Label24.AutoSize = False
		Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label24.Name = "Label24"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label2.BackColor = System.Drawing.Color.Black
		Me.Label2.Text = "80"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(57, 17)
		Me.Label2.Location = New System.Drawing.Point(200, 40)
		Me.Label2.TabIndex = 4
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label1.BackColor = System.Drawing.Color.Black
		Me.Label1.Text = "01 à 12"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(57, 17)
		Me.Label1.Location = New System.Drawing.Point(200, 24)
		Me.Label1.TabIndex = 2
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(mvwDate)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(cmdImprimer)
		Me.Controls.Add(fraDate)
		Me.Controls.Add(fraCategorie)
		Me.fraDate.Controls.Add(cmdDateFin)
		Me.fraDate.Controls.Add(cmdDateDebut)
		Me.fraDate.Controls.Add(mskDateDebut)
		Me.fraDate.Controls.Add(mskDateFin)
		Me.fraDate.Controls.Add(Label4)
		Me.fraDate.Controls.Add(Label3)
		Me.fraCategorie.Controls.Add(_optCategorie_2)
		Me.fraCategorie.Controls.Add(_optCategorie_7)
		Me.fraCategorie.Controls.Add(_optCategorie_6)
		Me.fraCategorie.Controls.Add(_optCategorie_5)
		Me.fraCategorie.Controls.Add(_optCategorie_4)
		Me.fraCategorie.Controls.Add(_optCategorie_3)
		Me.fraCategorie.Controls.Add(_optCategorie_1)
		Me.fraCategorie.Controls.Add(_optCategorie_0)
		Me.fraCategorie.Controls.Add(Label5)
		Me.fraCategorie.Controls.Add(Label28)
		Me.fraCategorie.Controls.Add(Label27)
		Me.fraCategorie.Controls.Add(Label26)
		Me.fraCategorie.Controls.Add(Label25)
		Me.fraCategorie.Controls.Add(Label24)
		Me.fraCategorie.Controls.Add(Label2)
		Me.fraCategorie.Controls.Add(Label1)
		Me.optCategorie.SetIndex(_optCategorie_2, CType(2, Short))
		Me.optCategorie.SetIndex(_optCategorie_7, CType(7, Short))
		Me.optCategorie.SetIndex(_optCategorie_6, CType(6, Short))
		Me.optCategorie.SetIndex(_optCategorie_5, CType(5, Short))
		Me.optCategorie.SetIndex(_optCategorie_4, CType(4, Short))
		Me.optCategorie.SetIndex(_optCategorie_3, CType(3, Short))
		Me.optCategorie.SetIndex(_optCategorie_1, CType(1, Short))
		Me.optCategorie.SetIndex(_optCategorie_0, CType(0, Short))
		CType(Me.optCategorie, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).EndInit()
		Me.fraDate.ResumeLayout(False)
		Me.fraCategorie.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class