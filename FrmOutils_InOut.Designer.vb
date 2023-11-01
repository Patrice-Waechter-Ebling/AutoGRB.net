<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FrmOutils_InOut
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
	Public WithEvents chknonRetour As System.Windows.Forms.CheckBox
	Public WithEvents cmdsortie As System.Windows.Forms.Button
	Public WithEvents cmbemployé As System.Windows.Forms.ComboBox
	Public WithEvents cmdConfig As System.Windows.Forms.Button
	Public WithEvents CmdFerme As System.Windows.Forms.Button
	Public WithEvents _lstoutils_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstoutils_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstoutils_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstoutils_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstoutils_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstoutils_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstoutils_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents lstoutils As System.Windows.Forms.ListView
	Public WithEvents cmdreport As System.Windows.Forms.Button
	Public WithEvents cmdretour As System.Windows.Forms.Button
	Public WithEvents txtcommentaire As System.Windows.Forms.TextBox
	Public WithEvents txtemploye As System.Windows.Forms.TextBox
	Public WithEvents CmdAnul As System.Windows.Forms.Button
	Public WithEvents CmdEnr As System.Windows.Forms.Button
	Public WithEvents txtdepartement As System.Windows.Forms.TextBox
	Public WithEvents txtsortie As System.Windows.Forms.TextBox
	Public WithEvents txtdepart As System.Windows.Forms.TextBox
	Public WithEvents txtnom As System.Windows.Forms.TextBox
	Public WithEvents txtno As System.Windows.Forms.TextBox
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents fraOutils As System.Windows.Forms.GroupBox
	Public WithEvents lblemployé As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmOutils_InOut))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.chknonRetour = New System.Windows.Forms.CheckBox
		Me.cmdsortie = New System.Windows.Forms.Button
		Me.cmbemployé = New System.Windows.Forms.ComboBox
		Me.cmdConfig = New System.Windows.Forms.Button
		Me.CmdFerme = New System.Windows.Forms.Button
		Me.lstoutils = New System.Windows.Forms.ListView
		Me._lstoutils_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lstoutils_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lstoutils_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lstoutils_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lstoutils_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lstoutils_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me._lstoutils_ColumnHeader_7 = New System.Windows.Forms.ColumnHeader
		Me.cmdreport = New System.Windows.Forms.Button
		Me.cmdretour = New System.Windows.Forms.Button
		Me.fraOutils = New System.Windows.Forms.GroupBox
		Me.txtcommentaire = New System.Windows.Forms.TextBox
		Me.txtemploye = New System.Windows.Forms.TextBox
		Me.CmdAnul = New System.Windows.Forms.Button
		Me.CmdEnr = New System.Windows.Forms.Button
		Me.txtdepartement = New System.Windows.Forms.TextBox
		Me.txtsortie = New System.Windows.Forms.TextBox
		Me.txtdepart = New System.Windows.Forms.TextBox
		Me.txtnom = New System.Windows.Forms.TextBox
		Me.txtno = New System.Windows.Forms.TextBox
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.lblemployé = New System.Windows.Forms.Label
		Me.lstoutils.SuspendLayout()
		Me.fraOutils.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Magasin"
		Me.ClientSize = New System.Drawing.Size(621, 382)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.Icon = CType(resources.GetObject("FrmOutils_InOut.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("FrmOutils_InOut.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "FrmOutils_InOut"
		Me.chknonRetour.BackColor = System.Drawing.Color.Black
		Me.chknonRetour.Text = "Outils non retournés"
		Me.chknonRetour.ForeColor = System.Drawing.Color.White
		Me.chknonRetour.Size = New System.Drawing.Size(137, 25)
		Me.chknonRetour.Location = New System.Drawing.Point(464, 56)
		Me.chknonRetour.TabIndex = 19
		Me.chknonRetour.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chknonRetour.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chknonRetour.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chknonRetour.CausesValidation = True
		Me.chknonRetour.Enabled = True
		Me.chknonRetour.Cursor = System.Windows.Forms.Cursors.Default
		Me.chknonRetour.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chknonRetour.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chknonRetour.TabStop = True
		Me.chknonRetour.Visible = True
		Me.chknonRetour.Name = "chknonRetour"
		Me.cmdsortie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdsortie.BackColor = System.Drawing.SystemColors.Control
		Me.cmdsortie.Text = "&Sortie Outils"
		Me.cmdsortie.Size = New System.Drawing.Size(97, 33)
		Me.cmdsortie.Location = New System.Drawing.Point(112, 336)
		Me.cmdsortie.TabIndex = 22
		Me.cmdsortie.CausesValidation = True
		Me.cmdsortie.Enabled = True
		Me.cmdsortie.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdsortie.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdsortie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdsortie.TabStop = True
		Me.cmdsortie.Name = "cmdsortie"
		Me.cmbemployé.Size = New System.Drawing.Size(145, 21)
		Me.cmbemployé.Location = New System.Drawing.Point(296, 56)
		Me.cmbemployé.Sorted = True
		Me.cmbemployé.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbemployé.TabIndex = 18
		Me.cmbemployé.BackColor = System.Drawing.SystemColors.Window
		Me.cmbemployé.CausesValidation = True
		Me.cmbemployé.Enabled = True
		Me.cmbemployé.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbemployé.IntegralHeight = True
		Me.cmbemployé.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbemployé.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbemployé.TabStop = True
		Me.cmbemployé.Visible = True
		Me.cmbemployé.Name = "cmbemployé"
		Me.cmdConfig.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdConfig.BackColor = System.Drawing.SystemColors.Control
		Me.cmdConfig.Text = "&Configuration Outils"
		Me.cmdConfig.Size = New System.Drawing.Size(113, 33)
		Me.cmdConfig.Location = New System.Drawing.Point(384, 336)
		Me.cmdConfig.TabIndex = 24
		Me.cmdConfig.CausesValidation = True
		Me.cmdConfig.Enabled = True
		Me.cmdConfig.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdConfig.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdConfig.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdConfig.TabStop = True
		Me.cmdConfig.Name = "cmdConfig"
		Me.CmdFerme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdFerme.BackColor = System.Drawing.SystemColors.Control
		Me.CmdFerme.Text = "&Fermer"
		Me.CmdFerme.Size = New System.Drawing.Size(97, 33)
		Me.CmdFerme.Location = New System.Drawing.Point(512, 336)
		Me.CmdFerme.TabIndex = 25
		Me.CmdFerme.CausesValidation = True
		Me.CmdFerme.Enabled = True
		Me.CmdFerme.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdFerme.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdFerme.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdFerme.TabStop = True
		Me.CmdFerme.Name = "CmdFerme"
		Me.lstoutils.Size = New System.Drawing.Size(601, 225)
		Me.lstoutils.Location = New System.Drawing.Point(8, 96)
		Me.lstoutils.TabIndex = 20
		Me.lstoutils.View = System.Windows.Forms.View.Details
		Me.lstoutils.LabelEdit = False
		Me.lstoutils.MultiSelect = True
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
		Me._lstoutils_ColumnHeader_3.Text = "Employé"
		Me._lstoutils_ColumnHeader_3.Width = 236
		Me._lstoutils_ColumnHeader_4.Text = "Sortie"
		Me._lstoutils_ColumnHeader_4.Width = 189
		Me._lstoutils_ColumnHeader_5.Text = "Retour"
		Me._lstoutils_ColumnHeader_5.Width = 189
		Me._lstoutils_ColumnHeader_6.Text = "Département"
		Me._lstoutils_ColumnHeader_6.Width = 170
		Me._lstoutils_ColumnHeader_7.Text = "Commentaire"
		Me._lstoutils_ColumnHeader_7.Width = 353
		Me.cmdreport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdreport.BackColor = System.Drawing.SystemColors.Control
		Me.cmdreport.Text = "&Impression"
		Me.cmdreport.Size = New System.Drawing.Size(97, 33)
		Me.cmdreport.Location = New System.Drawing.Point(8, 336)
		Me.cmdreport.TabIndex = 21
		Me.cmdreport.CausesValidation = True
		Me.cmdreport.Enabled = True
		Me.cmdreport.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdreport.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdreport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdreport.TabStop = True
		Me.cmdreport.Name = "cmdreport"
		Me.cmdretour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdretour.BackColor = System.Drawing.SystemColors.Control
		Me.cmdretour.Text = "&Retour Outils"
		Me.cmdretour.Size = New System.Drawing.Size(97, 33)
		Me.cmdretour.Location = New System.Drawing.Point(216, 336)
		Me.cmdretour.TabIndex = 23
		Me.cmdretour.CausesValidation = True
		Me.cmdretour.Enabled = True
		Me.cmdretour.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdretour.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdretour.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdretour.TabStop = True
		Me.cmdretour.Name = "cmdretour"
		Me.fraOutils.BackColor = System.Drawing.Color.Black
		Me.fraOutils.ForeColor = System.Drawing.Color.White
		Me.fraOutils.Size = New System.Drawing.Size(601, 281)
		Me.fraOutils.Location = New System.Drawing.Point(8, 40)
		Me.fraOutils.TabIndex = 1
		Me.fraOutils.Visible = False
		Me.fraOutils.Enabled = True
		Me.fraOutils.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraOutils.Padding = New System.Windows.Forms.Padding(0)
		Me.fraOutils.Name = "fraOutils"
		Me.txtcommentaire.AutoSize = False
		Me.txtcommentaire.Size = New System.Drawing.Size(305, 51)
		Me.txtcommentaire.Location = New System.Drawing.Point(128, 216)
		Me.txtcommentaire.MultiLine = True
		Me.txtcommentaire.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtcommentaire.TabIndex = 17
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
		Me.txtemploye.AutoSize = False
		Me.txtemploye.Enabled = False
		Me.txtemploye.Size = New System.Drawing.Size(121, 19)
		Me.txtemploye.Location = New System.Drawing.Point(128, 184)
		Me.txtemploye.TabIndex = 15
		Me.txtemploye.AcceptsReturn = True
		Me.txtemploye.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtemploye.BackColor = System.Drawing.SystemColors.Window
		Me.txtemploye.CausesValidation = True
		Me.txtemploye.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtemploye.HideSelection = True
		Me.txtemploye.ReadOnly = False
		Me.txtemploye.Maxlength = 0
		Me.txtemploye.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtemploye.MultiLine = False
		Me.txtemploye.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtemploye.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtemploye.TabStop = True
		Me.txtemploye.Visible = True
		Me.txtemploye.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtemploye.Name = "txtemploye"
		Me.CmdAnul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdAnul.Text = "&Afficher liste"
		Me.CmdAnul.Size = New System.Drawing.Size(97, 33)
		Me.CmdAnul.Location = New System.Drawing.Point(472, 120)
		Me.CmdAnul.TabIndex = 11
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
		Me.CmdEnr.Size = New System.Drawing.Size(97, 33)
		Me.CmdEnr.Location = New System.Drawing.Point(472, 80)
		Me.CmdEnr.TabIndex = 8
		Me.CmdEnr.BackColor = System.Drawing.SystemColors.Control
		Me.CmdEnr.CausesValidation = True
		Me.CmdEnr.Enabled = True
		Me.CmdEnr.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdEnr.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdEnr.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdEnr.TabStop = True
		Me.CmdEnr.Name = "CmdEnr"
		Me.txtdepartement.AutoSize = False
		Me.txtdepartement.Enabled = False
		Me.txtdepartement.Size = New System.Drawing.Size(121, 19)
		Me.txtdepartement.Location = New System.Drawing.Point(128, 88)
		Me.txtdepartement.TabIndex = 6
		Me.txtdepartement.AcceptsReturn = True
		Me.txtdepartement.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtdepartement.BackColor = System.Drawing.SystemColors.Window
		Me.txtdepartement.CausesValidation = True
		Me.txtdepartement.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtdepartement.HideSelection = True
		Me.txtdepartement.ReadOnly = False
		Me.txtdepartement.Maxlength = 0
		Me.txtdepartement.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtdepartement.MultiLine = False
		Me.txtdepartement.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtdepartement.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtdepartement.TabStop = True
		Me.txtdepartement.Visible = True
		Me.txtdepartement.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtdepartement.Name = "txtdepartement"
		Me.txtsortie.AutoSize = False
		Me.txtsortie.Enabled = False
		Me.txtsortie.Size = New System.Drawing.Size(121, 19)
		Me.txtsortie.Location = New System.Drawing.Point(128, 152)
		Me.txtsortie.TabIndex = 13
		Me.txtsortie.AcceptsReturn = True
		Me.txtsortie.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtsortie.BackColor = System.Drawing.SystemColors.Window
		Me.txtsortie.CausesValidation = True
		Me.txtsortie.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtsortie.HideSelection = True
		Me.txtsortie.ReadOnly = False
		Me.txtsortie.Maxlength = 0
		Me.txtsortie.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtsortie.MultiLine = False
		Me.txtsortie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtsortie.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtsortie.TabStop = True
		Me.txtsortie.Visible = True
		Me.txtsortie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtsortie.Name = "txtsortie"
		Me.txtdepart.AutoSize = False
		Me.txtdepart.Enabled = False
		Me.txtdepart.Size = New System.Drawing.Size(121, 19)
		Me.txtdepart.Location = New System.Drawing.Point(128, 120)
		Me.txtdepart.TabIndex = 9
		Me.txtdepart.AcceptsReturn = True
		Me.txtdepart.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtdepart.BackColor = System.Drawing.SystemColors.Window
		Me.txtdepart.CausesValidation = True
		Me.txtdepart.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtdepart.HideSelection = True
		Me.txtdepart.ReadOnly = False
		Me.txtdepart.Maxlength = 0
		Me.txtdepart.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtdepart.MultiLine = False
		Me.txtdepart.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtdepart.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtdepart.TabStop = True
		Me.txtdepart.Visible = True
		Me.txtdepart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtdepart.Name = "txtdepart"
		Me.txtnom.AutoSize = False
		Me.txtnom.Enabled = False
		Me.txtnom.Size = New System.Drawing.Size(321, 19)
		Me.txtnom.Location = New System.Drawing.Point(128, 56)
		Me.txtnom.TabIndex = 4
		Me.txtnom.AcceptsReturn = True
		Me.txtnom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtnom.BackColor = System.Drawing.SystemColors.Window
		Me.txtnom.CausesValidation = True
		Me.txtnom.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtnom.HideSelection = True
		Me.txtnom.ReadOnly = False
		Me.txtnom.Maxlength = 0
		Me.txtnom.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtnom.MultiLine = False
		Me.txtnom.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtnom.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtnom.TabStop = True
		Me.txtnom.Visible = True
		Me.txtnom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtnom.Name = "txtnom"
		Me.txtno.AutoSize = False
		Me.txtno.Size = New System.Drawing.Size(65, 19)
		Me.txtno.Location = New System.Drawing.Point(128, 24)
		Me.txtno.Maxlength = 4
		Me.txtno.TabIndex = 3
		Me.txtno.AcceptsReturn = True
		Me.txtno.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtno.BackColor = System.Drawing.SystemColors.Window
		Me.txtno.CausesValidation = True
		Me.txtno.Enabled = True
		Me.txtno.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtno.HideSelection = True
		Me.txtno.ReadOnly = False
		Me.txtno.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtno.MultiLine = False
		Me.txtno.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtno.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtno.TabStop = True
		Me.txtno.Visible = True
		Me.txtno.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtno.Name = "txtno"
		Me.Label7.Text = "Commentaire"
		Me.Label7.ForeColor = System.Drawing.Color.White
		Me.Label7.Size = New System.Drawing.Size(137, 17)
		Me.Label7.Location = New System.Drawing.Point(40, 216)
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
		Me.Label6.Text = "Employé"
		Me.Label6.ForeColor = System.Drawing.Color.White
		Me.Label6.Size = New System.Drawing.Size(137, 17)
		Me.Label6.Location = New System.Drawing.Point(40, 184)
		Me.Label6.TabIndex = 14
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
		Me.Label5.Text = "Département"
		Me.Label5.ForeColor = System.Drawing.Color.White
		Me.Label5.Size = New System.Drawing.Size(137, 17)
		Me.Label5.Location = New System.Drawing.Point(40, 88)
		Me.Label5.TabIndex = 7
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
		Me.Label4.Text = "Retour"
		Me.Label4.ForeColor = System.Drawing.Color.White
		Me.Label4.Size = New System.Drawing.Size(137, 17)
		Me.Label4.Location = New System.Drawing.Point(40, 152)
		Me.Label4.TabIndex = 12
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
		Me.Label3.Text = "Sortie"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(137, 17)
		Me.Label3.Location = New System.Drawing.Point(40, 120)
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
		Me.Label2.Text = "Nom"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(137, 17)
		Me.Label2.Location = New System.Drawing.Point(40, 56)
		Me.Label2.TabIndex = 5
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
		Me.Label1.Text = "No Outil"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(137, 17)
		Me.Label1.Location = New System.Drawing.Point(40, 24)
		Me.Label1.TabIndex = 2
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
		Me.lblemployé.Text = "Employé"
		Me.lblemployé.ForeColor = System.Drawing.Color.White
		Me.lblemployé.Size = New System.Drawing.Size(137, 17)
		Me.lblemployé.Location = New System.Drawing.Point(296, 40)
		Me.lblemployé.TabIndex = 0
		Me.lblemployé.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblemployé.BackColor = System.Drawing.Color.Transparent
		Me.lblemployé.Enabled = True
		Me.lblemployé.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblemployé.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblemployé.UseMnemonic = True
		Me.lblemployé.Visible = True
		Me.lblemployé.AutoSize = False
		Me.lblemployé.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblemployé.Name = "lblemployé"
		Me.Controls.Add(chknonRetour)
		Me.Controls.Add(cmdsortie)
		Me.Controls.Add(cmbemployé)
		Me.Controls.Add(cmdConfig)
		Me.Controls.Add(CmdFerme)
		Me.Controls.Add(lstoutils)
		Me.Controls.Add(cmdreport)
		Me.Controls.Add(cmdretour)
		Me.Controls.Add(fraOutils)
		Me.Controls.Add(lblemployé)
		Me.lstoutils.Columns.Add(_lstoutils_ColumnHeader_1)
		Me.lstoutils.Columns.Add(_lstoutils_ColumnHeader_2)
		Me.lstoutils.Columns.Add(_lstoutils_ColumnHeader_3)
		Me.lstoutils.Columns.Add(_lstoutils_ColumnHeader_4)
		Me.lstoutils.Columns.Add(_lstoutils_ColumnHeader_5)
		Me.lstoutils.Columns.Add(_lstoutils_ColumnHeader_6)
		Me.lstoutils.Columns.Add(_lstoutils_ColumnHeader_7)
		Me.fraOutils.Controls.Add(txtcommentaire)
		Me.fraOutils.Controls.Add(txtemploye)
		Me.fraOutils.Controls.Add(CmdAnul)
		Me.fraOutils.Controls.Add(CmdEnr)
		Me.fraOutils.Controls.Add(txtdepartement)
		Me.fraOutils.Controls.Add(txtsortie)
		Me.fraOutils.Controls.Add(txtdepart)
		Me.fraOutils.Controls.Add(txtnom)
		Me.fraOutils.Controls.Add(txtno)
		Me.fraOutils.Controls.Add(Label7)
		Me.fraOutils.Controls.Add(Label6)
		Me.fraOutils.Controls.Add(Label5)
		Me.fraOutils.Controls.Add(Label4)
		Me.fraOutils.Controls.Add(Label3)
		Me.fraOutils.Controls.Add(Label2)
		Me.fraOutils.Controls.Add(Label1)
		Me.lstoutils.ResumeLayout(False)
		Me.fraOutils.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class