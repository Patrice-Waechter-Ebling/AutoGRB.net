<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmvendeur
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
	Public WithEvents _lstclient_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents lstclient As System.Windows.Forms.ListView
	Public WithEvents cmdrechercheclient As System.Windows.Forms.Button
	Public WithEvents CmdExporter As System.Windows.Forms.Button
	Public WithEvents cmdcherche As System.Windows.Forms.Button
	Public WithEvents mskDateCherche As System.Windows.Forms.MaskedTextBox
	Public WithEvents cmbClient As System.Windows.Forms.ComboBox
	Public WithEvents CmdAdd As System.Windows.Forms.Button
	Public WithEvents CmdSupp As System.Windows.Forms.Button
	Public WithEvents CmdQuit As System.Windows.Forms.Button
	Public WithEvents cmbtype As System.Windows.Forms.ComboBox
	Public WithEvents txtNomCompagny As System.Windows.Forms.TextBox
	Public WithEvents txtdate As System.Windows.Forms.MaskedTextBox
	Public WithEvents txtcommentaire As System.Windows.Forms.TextBox
	Public WithEvents txtcontact As System.Windows.Forms.TextBox
	Public WithEvents cmdfermercontact As System.Windows.Forms.Button
	Public WithEvents cmdsave As System.Windows.Forms.Button
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents lblNomcompagnie As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents label2 As System.Windows.Forms.Label
	Public WithEvents fracontact As System.Windows.Forms.GroupBox
	Public WithEvents _lister_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lister_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lister_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lister_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lister_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lister_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents lister As System.Windows.Forms.ListView
	Public WithEvents lbladresse As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents lbltelephone As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmvendeur))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.lstclient = New System.Windows.Forms.ListView
		Me._lstclient_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.cmdrechercheclient = New System.Windows.Forms.Button
		Me.CmdExporter = New System.Windows.Forms.Button
		Me.cmdcherche = New System.Windows.Forms.Button
		Me.mskDateCherche = New System.Windows.Forms.MaskedTextBox
		Me.cmbClient = New System.Windows.Forms.ComboBox
		Me.CmdAdd = New System.Windows.Forms.Button
		Me.CmdSupp = New System.Windows.Forms.Button
		Me.CmdQuit = New System.Windows.Forms.Button
		Me.fracontact = New System.Windows.Forms.GroupBox
		Me.cmbtype = New System.Windows.Forms.ComboBox
		Me.txtNomCompagny = New System.Windows.Forms.TextBox
		Me.txtdate = New System.Windows.Forms.MaskedTextBox
		Me.txtcommentaire = New System.Windows.Forms.TextBox
		Me.txtcontact = New System.Windows.Forms.TextBox
		Me.cmdfermercontact = New System.Windows.Forms.Button
		Me.cmdsave = New System.Windows.Forms.Button
		Me.Label4 = New System.Windows.Forms.Label
		Me.lblNomcompagnie = New System.Windows.Forms.Label
		Me.Label10 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.label2 = New System.Windows.Forms.Label
		Me.lister = New System.Windows.Forms.ListView
		Me._lister_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lister_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lister_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lister_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lister_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lister_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me.lbladresse = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.lbltelephone = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.lstclient.SuspendLayout()
		Me.fracontact.SuspendLayout()
		Me.lister.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Contacts pour vendeurs"
		Me.ClientSize = New System.Drawing.Size(540, 423)
		Me.Location = New System.Drawing.Point(10, 29)
		Me.Icon = CType(resources.GetObject("frmvendeur.Icon"), System.Drawing.Icon)
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
		Me.Name = "frmvendeur"
		Me.lstclient.Size = New System.Drawing.Size(193, 121)
		Me.lstclient.Location = New System.Drawing.Point(80, 8)
		Me.lstclient.TabIndex = 24
		Me.lstclient.Visible = False
		Me.lstclient.View = System.Windows.Forms.View.Details
		Me.lstclient.LabelEdit = False
		Me.lstclient.LabelWrap = True
		Me.lstclient.HideSelection = True
		Me.lstclient.FullRowSelect = True
		Me.lstclient.GridLines = True
		Me.lstclient.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstclient.BackColor = System.Drawing.SystemColors.Window
		Me.lstclient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstclient.Name = "lstclient"
		Me._lstclient_ColumnHeader_1.Text = "Catalogue"
		Me._lstclient_ColumnHeader_1.Width = 299
		Me.cmdrechercheclient.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdrechercheclient.Size = New System.Drawing.Size(25, 25)
		Me.cmdrechercheclient.Location = New System.Drawing.Point(272, 8)
		Me.cmdrechercheclient.Image = CType(resources.GetObject("cmdrechercheclient.Image"), System.Drawing.Image)
		Me.cmdrechercheclient.TabIndex = 23
		Me.cmdrechercheclient.BackColor = System.Drawing.SystemColors.Control
		Me.cmdrechercheclient.CausesValidation = True
		Me.cmdrechercheclient.Enabled = True
		Me.cmdrechercheclient.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdrechercheclient.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdrechercheclient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdrechercheclient.TabStop = True
		Me.cmdrechercheclient.Name = "cmdrechercheclient"
		Me.CmdExporter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdExporter.Text = "&Exporter vers Excel"
		Me.CmdExporter.Size = New System.Drawing.Size(145, 33)
		Me.CmdExporter.Location = New System.Drawing.Point(352, 384)
		Me.CmdExporter.TabIndex = 22
		Me.CmdExporter.BackColor = System.Drawing.SystemColors.Control
		Me.CmdExporter.CausesValidation = True
		Me.CmdExporter.Enabled = True
		Me.CmdExporter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdExporter.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdExporter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdExporter.TabStop = True
		Me.CmdExporter.Name = "CmdExporter"
		Me.cmdcherche.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdcherche.Text = "Cherche par date"
		Me.cmdcherche.Size = New System.Drawing.Size(97, 25)
		Me.cmdcherche.Location = New System.Drawing.Point(432, 8)
		Me.cmdcherche.TabIndex = 4
		Me.cmdcherche.BackColor = System.Drawing.SystemColors.Control
		Me.cmdcherche.CausesValidation = True
		Me.cmdcherche.Enabled = True
		Me.cmdcherche.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdcherche.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdcherche.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdcherche.TabStop = True
		Me.cmdcherche.Name = "cmdcherche"
		Me.mskDateCherche.AllowPromptAsInput = False
		Me.mskDateCherche.Size = New System.Drawing.Size(73, 25)
		Me.mskDateCherche.Location = New System.Drawing.Point(352, 8)
		Me.mskDateCherche.TabIndex = 3
		Me.mskDateCherche.PromptChar = "_"
		Me.mskDateCherche.Name = "mskDateCherche"
		Me.cmbClient.Size = New System.Drawing.Size(193, 21)
		Me.cmbClient.Location = New System.Drawing.Point(80, 8)
		Me.cmbClient.Sorted = True
		Me.cmbClient.TabIndex = 1
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
		Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdAdd.Text = "&Ajouter"
		Me.CmdAdd.Size = New System.Drawing.Size(97, 33)
		Me.CmdAdd.Location = New System.Drawing.Point(24, 384)
		Me.CmdAdd.TabIndex = 17
		Me.CmdAdd.BackColor = System.Drawing.SystemColors.Control
		Me.CmdAdd.CausesValidation = True
		Me.CmdAdd.Enabled = True
		Me.CmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdAdd.TabStop = True
		Me.CmdAdd.Name = "CmdAdd"
		Me.CmdSupp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdSupp.Text = "&Supprimer"
		Me.CmdSupp.Size = New System.Drawing.Size(89, 33)
		Me.CmdSupp.Location = New System.Drawing.Point(136, 384)
		Me.CmdSupp.TabIndex = 18
		Me.CmdSupp.BackColor = System.Drawing.SystemColors.Control
		Me.CmdSupp.CausesValidation = True
		Me.CmdSupp.Enabled = True
		Me.CmdSupp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdSupp.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdSupp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdSupp.TabStop = True
		Me.CmdSupp.Name = "CmdSupp"
		Me.CmdQuit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdQuit.Text = "&Fermer"
		Me.CmdQuit.Size = New System.Drawing.Size(97, 33)
		Me.CmdQuit.Location = New System.Drawing.Point(240, 384)
		Me.CmdQuit.TabIndex = 19
		Me.CmdQuit.BackColor = System.Drawing.SystemColors.Control
		Me.CmdQuit.CausesValidation = True
		Me.CmdQuit.Enabled = True
		Me.CmdQuit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdQuit.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdQuit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdQuit.TabStop = True
		Me.CmdQuit.Name = "CmdQuit"
		Me.fracontact.Text = "Contact"
		Me.fracontact.Size = New System.Drawing.Size(529, 257)
		Me.fracontact.Location = New System.Drawing.Point(8, 120)
		Me.fracontact.TabIndex = 8
		Me.fracontact.Visible = False
		Me.fracontact.BackColor = System.Drawing.SystemColors.Control
		Me.fracontact.Enabled = True
		Me.fracontact.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fracontact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fracontact.Padding = New System.Windows.Forms.Padding(0)
		Me.fracontact.Name = "fracontact"
		Me.cmbtype.Size = New System.Drawing.Size(217, 21)
		Me.cmbtype.Location = New System.Drawing.Point(272, 40)
		Me.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbtype.TabIndex = 27
		Me.cmbtype.BackColor = System.Drawing.SystemColors.Window
		Me.cmbtype.CausesValidation = True
		Me.cmbtype.Enabled = True
		Me.cmbtype.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbtype.IntegralHeight = True
		Me.cmbtype.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbtype.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbtype.Sorted = False
		Me.cmbtype.TabStop = True
		Me.cmbtype.Visible = True
		Me.cmbtype.Name = "cmbtype"
		Me.txtNomCompagny.AutoSize = False
		Me.txtNomCompagny.Enabled = False
		Me.txtNomCompagny.Size = New System.Drawing.Size(153, 25)
		Me.txtNomCompagny.Location = New System.Drawing.Point(32, 80)
		Me.txtNomCompagny.TabIndex = 20
		Me.txtNomCompagny.AcceptsReturn = True
		Me.txtNomCompagny.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNomCompagny.BackColor = System.Drawing.SystemColors.Window
		Me.txtNomCompagny.CausesValidation = True
		Me.txtNomCompagny.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNomCompagny.HideSelection = True
		Me.txtNomCompagny.ReadOnly = False
		Me.txtNomCompagny.Maxlength = 0
		Me.txtNomCompagny.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNomCompagny.MultiLine = False
		Me.txtNomCompagny.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNomCompagny.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNomCompagny.TabStop = True
		Me.txtNomCompagny.Visible = True
		Me.txtNomCompagny.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNomCompagny.Name = "txtNomCompagny"
		Me.txtdate.AllowPromptAsInput = False
		Me.txtdate.Size = New System.Drawing.Size(81, 25)
		Me.txtdate.Location = New System.Drawing.Point(32, 40)
		Me.txtdate.TabIndex = 11
		Me.txtdate.Enabled = False
		Me.txtdate.PromptChar = "_"
		Me.txtdate.Name = "txtdate"
		Me.txtcommentaire.AutoSize = False
		Me.txtcommentaire.Size = New System.Drawing.Size(465, 91)
		Me.txtcommentaire.Location = New System.Drawing.Point(32, 120)
		Me.txtcommentaire.TabIndex = 14
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
		Me.txtcommentaire.MultiLine = False
		Me.txtcommentaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtcommentaire.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtcommentaire.TabStop = True
		Me.txtcommentaire.Visible = True
		Me.txtcommentaire.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtcommentaire.Name = "txtcommentaire"
		Me.txtcontact.AutoSize = False
		Me.txtcontact.Size = New System.Drawing.Size(217, 25)
		Me.txtcontact.Location = New System.Drawing.Point(280, 80)
		Me.txtcontact.TabIndex = 12
		Me.txtcontact.AcceptsReturn = True
		Me.txtcontact.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtcontact.BackColor = System.Drawing.SystemColors.Window
		Me.txtcontact.CausesValidation = True
		Me.txtcontact.Enabled = True
		Me.txtcontact.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtcontact.HideSelection = True
		Me.txtcontact.ReadOnly = False
		Me.txtcontact.Maxlength = 0
		Me.txtcontact.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtcontact.MultiLine = False
		Me.txtcontact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtcontact.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtcontact.TabStop = True
		Me.txtcontact.Visible = True
		Me.txtcontact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtcontact.Name = "txtcontact"
		Me.cmdfermercontact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdfermercontact.Text = "Fermer"
		Me.cmdfermercontact.Size = New System.Drawing.Size(105, 33)
		Me.cmdfermercontact.Location = New System.Drawing.Point(392, 216)
		Me.cmdfermercontact.TabIndex = 16
		Me.cmdfermercontact.BackColor = System.Drawing.SystemColors.Control
		Me.cmdfermercontact.CausesValidation = True
		Me.cmdfermercontact.Enabled = True
		Me.cmdfermercontact.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdfermercontact.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdfermercontact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdfermercontact.TabStop = True
		Me.cmdfermercontact.Name = "cmdfermercontact"
		Me.cmdsave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdsave.Text = "Sauvegarde"
		Me.cmdsave.Size = New System.Drawing.Size(113, 33)
		Me.cmdsave.Location = New System.Drawing.Point(264, 216)
		Me.cmdsave.TabIndex = 15
		Me.cmdsave.BackColor = System.Drawing.SystemColors.Control
		Me.cmdsave.CausesValidation = True
		Me.cmdsave.Enabled = True
		Me.cmdsave.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdsave.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdsave.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdsave.TabStop = True
		Me.cmdsave.Name = "cmdsave"
		Me.Label4.Text = "État"
		Me.Label4.Size = New System.Drawing.Size(113, 17)
		Me.Label4.Location = New System.Drawing.Point(272, 24)
		Me.Label4.TabIndex = 26
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.lblNomcompagnie.Text = "Nom de Compagnie"
		Me.lblNomcompagnie.Size = New System.Drawing.Size(97, 17)
		Me.lblNomcompagnie.Location = New System.Drawing.Point(32, 64)
		Me.lblNomcompagnie.TabIndex = 21
		Me.lblNomcompagnie.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblNomcompagnie.BackColor = System.Drawing.SystemColors.Control
		Me.lblNomcompagnie.Enabled = True
		Me.lblNomcompagnie.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblNomcompagnie.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblNomcompagnie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblNomcompagnie.UseMnemonic = True
		Me.lblNomcompagnie.Visible = True
		Me.lblNomcompagnie.AutoSize = False
		Me.lblNomcompagnie.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblNomcompagnie.Name = "lblNomcompagnie"
		Me.Label10.Text = "Commentaire"
		Me.Label10.Size = New System.Drawing.Size(113, 17)
		Me.Label10.Location = New System.Drawing.Point(32, 104)
		Me.Label10.TabIndex = 13
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label10.BackColor = System.Drawing.SystemColors.Control
		Me.Label10.Enabled = True
		Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label10.UseMnemonic = True
		Me.Label10.Visible = True
		Me.Label10.AutoSize = False
		Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label10.Name = "Label10"
		Me.Label5.Text = "Contact"
		Me.Label5.Size = New System.Drawing.Size(113, 17)
		Me.Label5.Location = New System.Drawing.Point(272, 64)
		Me.Label5.TabIndex = 10
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.SystemColors.Control
		Me.Label5.Enabled = True
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.label2.Text = "Date"
		Me.label2.Size = New System.Drawing.Size(113, 17)
		Me.label2.Location = New System.Drawing.Point(32, 24)
		Me.label2.TabIndex = 9
		Me.label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.label2.BackColor = System.Drawing.SystemColors.Control
		Me.label2.Enabled = True
		Me.label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label2.UseMnemonic = True
		Me.label2.Visible = True
		Me.label2.AutoSize = False
		Me.label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.label2.Name = "label2"
		Me.lister.Size = New System.Drawing.Size(529, 257)
		Me.lister.Location = New System.Drawing.Point(8, 120)
		Me.lister.TabIndex = 7
		Me.lister.View = System.Windows.Forms.View.Details
		Me.lister.LabelEdit = False
		Me.lister.LabelWrap = True
		Me.lister.HideSelection = True
		Me.lister.FullRowSelect = True
		Me.lister.GridLines = True
		Me.lister.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lister.BackColor = System.Drawing.SystemColors.Window
		Me.lister.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lister.Name = "lister"
		Me._lister_ColumnHeader_1.Text = "Date"
		Me._lister_ColumnHeader_1.Width = 118
		Me._lister_ColumnHeader_2.Text = "Nom de Compagnie"
		Me._lister_ColumnHeader_2.Width = 236
		Me._lister_ColumnHeader_3.Text = "Contact"
		Me._lister_ColumnHeader_3.Width = 236
		Me._lister_ColumnHeader_4.Text = "État"
		Me._lister_ColumnHeader_4.Width = 170
		Me._lister_ColumnHeader_5.Text = "Commentaire"
		Me._lister_ColumnHeader_5.Width = 706
		Me._lister_ColumnHeader_6.Text = "Enregistrer par"
		Me._lister_ColumnHeader_6.Width = 170
		Me.lbladresse.Text = "lbladresse"
		Me.lbladresse.Size = New System.Drawing.Size(449, 33)
		Me.lbladresse.Location = New System.Drawing.Point(80, 48)
		Me.lbladresse.TabIndex = 25
		Me.lbladresse.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbladresse.BackColor = System.Drawing.SystemColors.Control
		Me.lbladresse.Enabled = True
		Me.lbladresse.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lbladresse.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbladresse.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbladresse.UseMnemonic = True
		Me.lbladresse.Visible = True
		Me.lbladresse.AutoSize = False
		Me.lbladresse.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbladresse.Name = "lbladresse"
		Me.Label3.Text = "Date  AA-MM-JJ"
		Me.Label3.Size = New System.Drawing.Size(49, 25)
		Me.Label3.Location = New System.Drawing.Point(304, 8)
		Me.Label3.TabIndex = 2
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.lbltelephone.Text = "lblTELEPHONE"
		Me.lbltelephone.Size = New System.Drawing.Size(521, 33)
		Me.lbltelephone.Location = New System.Drawing.Point(8, 88)
		Me.lbltelephone.TabIndex = 6
		Me.lbltelephone.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbltelephone.BackColor = System.Drawing.SystemColors.Control
		Me.lbltelephone.Enabled = True
		Me.lbltelephone.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lbltelephone.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbltelephone.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbltelephone.UseMnemonic = True
		Me.lbltelephone.Visible = True
		Me.lbltelephone.AutoSize = False
		Me.lbltelephone.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbltelephone.Name = "lbltelephone"
		Me.Label1.Text = "NomClient"
		Me.Label1.Size = New System.Drawing.Size(65, 17)
		Me.Label1.Location = New System.Drawing.Point(8, 8)
		Me.Label1.TabIndex = 0
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Label6.Text = "Adresse"
		Me.Label6.Size = New System.Drawing.Size(65, 17)
		Me.Label6.Location = New System.Drawing.Point(8, 48)
		Me.Label6.TabIndex = 5
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.BackColor = System.Drawing.SystemColors.Control
		Me.Label6.Enabled = True
		Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = False
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.Controls.Add(lstclient)
		Me.Controls.Add(cmdrechercheclient)
		Me.Controls.Add(CmdExporter)
		Me.Controls.Add(cmdcherche)
		Me.Controls.Add(mskDateCherche)
		Me.Controls.Add(cmbClient)
		Me.Controls.Add(CmdAdd)
		Me.Controls.Add(CmdSupp)
		Me.Controls.Add(CmdQuit)
		Me.Controls.Add(fracontact)
		Me.Controls.Add(lister)
		Me.Controls.Add(lbladresse)
		Me.Controls.Add(Label3)
		Me.Controls.Add(lbltelephone)
		Me.Controls.Add(Label1)
		Me.Controls.Add(Label6)
		Me.lstclient.Columns.Add(_lstclient_ColumnHeader_1)
		Me.fracontact.Controls.Add(cmbtype)
		Me.fracontact.Controls.Add(txtNomCompagny)
		Me.fracontact.Controls.Add(txtdate)
		Me.fracontact.Controls.Add(txtcommentaire)
		Me.fracontact.Controls.Add(txtcontact)
		Me.fracontact.Controls.Add(cmdfermercontact)
		Me.fracontact.Controls.Add(cmdsave)
		Me.fracontact.Controls.Add(Label4)
		Me.fracontact.Controls.Add(lblNomcompagnie)
		Me.fracontact.Controls.Add(Label10)
		Me.fracontact.Controls.Add(Label5)
		Me.fracontact.Controls.Add(label2)
		Me.lister.Columns.Add(_lister_ColumnHeader_1)
		Me.lister.Columns.Add(_lister_ColumnHeader_2)
		Me.lister.Columns.Add(_lister_ColumnHeader_3)
		Me.lister.Columns.Add(_lister_ColumnHeader_4)
		Me.lister.Columns.Add(_lister_ColumnHeader_5)
		Me.lister.Columns.Add(_lister_ColumnHeader_6)
		Me.lstclient.ResumeLayout(False)
		Me.fracontact.ResumeLayout(False)
		Me.lister.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class