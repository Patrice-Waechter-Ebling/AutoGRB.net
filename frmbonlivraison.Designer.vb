<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmbonlivraison
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
	Public WithEvents CmdQuit As System.Windows.Forms.Button
	Public WithEvents CmdSupp As System.Windows.Forms.Button
	Public WithEvents CmdAdd As System.Windows.Forms.Button
	Public WithEvents txtManufacturier As System.Windows.Forms.TextBox
	Public WithEvents txtQteBo As System.Windows.Forms.TextBox
	Public WithEvents txtQteCom As System.Windows.Forms.TextBox
	Public WithEvents cmdSave As System.Windows.Forms.Button
	Public WithEvents cmdFermerQte As System.Windows.Forms.Button
	Public WithEvents txtQteLivr As System.Windows.Forms.TextBox
	Public WithEvents txtDescription As System.Windows.Forms.TextBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents label2 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents fraqte As System.Windows.Forms.GroupBox
	Public WithEvents _lvwBonLivraison_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwBonLivraison_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwBonLivraison_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwBonLivraison_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwBonLivraison_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwBonLivraison As System.Windows.Forms.ListView
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmbonlivraison))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.CmdQuit = New System.Windows.Forms.Button
		Me.CmdSupp = New System.Windows.Forms.Button
		Me.CmdAdd = New System.Windows.Forms.Button
		Me.fraqte = New System.Windows.Forms.GroupBox
		Me.txtManufacturier = New System.Windows.Forms.TextBox
		Me.txtQteBo = New System.Windows.Forms.TextBox
		Me.txtQteCom = New System.Windows.Forms.TextBox
		Me.cmdSave = New System.Windows.Forms.Button
		Me.cmdFermerQte = New System.Windows.Forms.Button
		Me.txtQteLivr = New System.Windows.Forms.TextBox
		Me.txtDescription = New System.Windows.Forms.TextBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.label2 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label10 = New System.Windows.Forms.Label
		Me.lvwBonLivraison = New System.Windows.Forms.ListView
		Me._lvwBonLivraison_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwBonLivraison_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwBonLivraison_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwBonLivraison_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwBonLivraison_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me.fraqte.SuspendLayout()
		Me.lvwBonLivraison.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Bon livraison"
		Me.ClientSize = New System.Drawing.Size(531, 323)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmbonlivraison"
		Me.CmdQuit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdQuit.Text = "&Fermer"
		Me.CmdQuit.Size = New System.Drawing.Size(97, 33)
		Me.CmdQuit.Location = New System.Drawing.Point(232, 280)
		Me.CmdQuit.TabIndex = 16
		Me.CmdQuit.BackColor = System.Drawing.SystemColors.Control
		Me.CmdQuit.CausesValidation = True
		Me.CmdQuit.Enabled = True
		Me.CmdQuit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdQuit.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdQuit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdQuit.TabStop = True
		Me.CmdQuit.Name = "CmdQuit"
		Me.CmdSupp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdSupp.Text = "&Supprimer tout"
		Me.CmdSupp.Size = New System.Drawing.Size(97, 33)
		Me.CmdSupp.Location = New System.Drawing.Point(112, 280)
		Me.CmdSupp.TabIndex = 14
		Me.CmdSupp.BackColor = System.Drawing.SystemColors.Control
		Me.CmdSupp.CausesValidation = True
		Me.CmdSupp.Enabled = True
		Me.CmdSupp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdSupp.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdSupp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdSupp.TabStop = True
		Me.CmdSupp.Name = "CmdSupp"
		Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdAdd.Text = "&Ajouter"
		Me.CmdAdd.Size = New System.Drawing.Size(97, 33)
		Me.CmdAdd.Location = New System.Drawing.Point(16, 280)
		Me.CmdAdd.TabIndex = 15
		Me.CmdAdd.BackColor = System.Drawing.SystemColors.Control
		Me.CmdAdd.CausesValidation = True
		Me.CmdAdd.Enabled = True
		Me.CmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdAdd.TabStop = True
		Me.CmdAdd.Name = "CmdAdd"
		Me.fraqte.Text = "QTE"
		Me.fraqte.Size = New System.Drawing.Size(497, 209)
		Me.fraqte.Location = New System.Drawing.Point(16, 48)
		Me.fraqte.TabIndex = 0
		Me.fraqte.Visible = False
		Me.fraqte.BackColor = System.Drawing.SystemColors.Control
		Me.fraqte.Enabled = True
		Me.fraqte.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraqte.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraqte.Padding = New System.Windows.Forms.Padding(0)
		Me.fraqte.Name = "fraqte"
		Me.txtManufacturier.AutoSize = False
		Me.txtManufacturier.Size = New System.Drawing.Size(193, 19)
		Me.txtManufacturier.Location = New System.Drawing.Point(288, 48)
		Me.txtManufacturier.TabIndex = 8
		Me.txtManufacturier.AcceptsReturn = True
		Me.txtManufacturier.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtManufacturier.BackColor = System.Drawing.SystemColors.Window
		Me.txtManufacturier.CausesValidation = True
		Me.txtManufacturier.Enabled = True
		Me.txtManufacturier.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtManufacturier.HideSelection = True
		Me.txtManufacturier.ReadOnly = False
		Me.txtManufacturier.Maxlength = 0
		Me.txtManufacturier.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtManufacturier.MultiLine = False
		Me.txtManufacturier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtManufacturier.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtManufacturier.TabStop = True
		Me.txtManufacturier.Visible = True
		Me.txtManufacturier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtManufacturier.Name = "txtManufacturier"
		Me.txtQteBo.AutoSize = False
		Me.txtQteBo.Size = New System.Drawing.Size(81, 19)
		Me.txtQteBo.Location = New System.Drawing.Point(200, 48)
		Me.txtQteBo.TabIndex = 7
		Me.txtQteBo.AcceptsReturn = True
		Me.txtQteBo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtQteBo.BackColor = System.Drawing.SystemColors.Window
		Me.txtQteBo.CausesValidation = True
		Me.txtQteBo.Enabled = True
		Me.txtQteBo.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtQteBo.HideSelection = True
		Me.txtQteBo.ReadOnly = False
		Me.txtQteBo.Maxlength = 0
		Me.txtQteBo.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtQteBo.MultiLine = False
		Me.txtQteBo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtQteBo.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtQteBo.TabStop = True
		Me.txtQteBo.Visible = True
		Me.txtQteBo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtQteBo.Name = "txtQteBo"
		Me.txtQteCom.AutoSize = False
		Me.txtQteCom.Size = New System.Drawing.Size(73, 19)
		Me.txtQteCom.Location = New System.Drawing.Point(32, 48)
		Me.txtQteCom.TabIndex = 5
		Me.txtQteCom.AcceptsReturn = True
		Me.txtQteCom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtQteCom.BackColor = System.Drawing.SystemColors.Window
		Me.txtQteCom.CausesValidation = True
		Me.txtQteCom.Enabled = True
		Me.txtQteCom.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtQteCom.HideSelection = True
		Me.txtQteCom.ReadOnly = False
		Me.txtQteCom.Maxlength = 0
		Me.txtQteCom.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtQteCom.MultiLine = False
		Me.txtQteCom.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtQteCom.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtQteCom.TabStop = True
		Me.txtQteCom.Visible = True
		Me.txtQteCom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtQteCom.Name = "txtQteCom"
		Me.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSave.Text = "Sauvegarde"
		Me.cmdSave.Size = New System.Drawing.Size(113, 33)
		Me.cmdSave.Location = New System.Drawing.Point(176, 168)
		Me.cmdSave.TabIndex = 11
		Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSave.CausesValidation = True
		Me.cmdSave.Enabled = True
		Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSave.TabStop = True
		Me.cmdSave.Name = "cmdSave"
		Me.cmdFermerQte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermerQte.Text = "Fermer"
		Me.cmdFermerQte.Size = New System.Drawing.Size(97, 33)
		Me.cmdFermerQte.Location = New System.Drawing.Point(296, 168)
		Me.cmdFermerQte.TabIndex = 12
		Me.cmdFermerQte.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermerQte.CausesValidation = True
		Me.cmdFermerQte.Enabled = True
		Me.cmdFermerQte.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermerQte.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermerQte.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermerQte.TabStop = True
		Me.cmdFermerQte.Name = "cmdFermerQte"
		Me.txtQteLivr.AutoSize = False
		Me.txtQteLivr.Size = New System.Drawing.Size(81, 19)
		Me.txtQteLivr.Location = New System.Drawing.Point(112, 48)
		Me.txtQteLivr.TabIndex = 6
		Me.txtQteLivr.AcceptsReturn = True
		Me.txtQteLivr.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtQteLivr.BackColor = System.Drawing.SystemColors.Window
		Me.txtQteLivr.CausesValidation = True
		Me.txtQteLivr.Enabled = True
		Me.txtQteLivr.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtQteLivr.HideSelection = True
		Me.txtQteLivr.ReadOnly = False
		Me.txtQteLivr.Maxlength = 0
		Me.txtQteLivr.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtQteLivr.MultiLine = False
		Me.txtQteLivr.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtQteLivr.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtQteLivr.TabStop = True
		Me.txtQteLivr.Visible = True
		Me.txtQteLivr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtQteLivr.Name = "txtQteLivr"
		Me.txtDescription.AutoSize = False
		Me.txtDescription.Size = New System.Drawing.Size(233, 35)
		Me.txtDescription.Location = New System.Drawing.Point(32, 112)
		Me.txtDescription.TabIndex = 10
		Me.txtDescription.AcceptsReturn = True
		Me.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDescription.BackColor = System.Drawing.SystemColors.Window
		Me.txtDescription.CausesValidation = True
		Me.txtDescription.Enabled = True
		Me.txtDescription.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDescription.HideSelection = True
		Me.txtDescription.ReadOnly = False
		Me.txtDescription.Maxlength = 0
		Me.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDescription.MultiLine = False
		Me.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDescription.TabStop = True
		Me.txtDescription.Visible = True
		Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDescription.Name = "txtDescription"
		Me.Label3.Text = "Manufacturier"
		Me.Label3.Size = New System.Drawing.Size(113, 17)
		Me.Label3.Location = New System.Drawing.Point(288, 32)
		Me.Label3.TabIndex = 3
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
		Me.Label1.Text = "Qte bo"
		Me.Label1.Size = New System.Drawing.Size(113, 17)
		Me.Label1.Location = New System.Drawing.Point(200, 32)
		Me.Label1.TabIndex = 4
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
		Me.label2.Text = "Qte com"
		Me.label2.Size = New System.Drawing.Size(65, 17)
		Me.label2.Location = New System.Drawing.Point(32, 32)
		Me.label2.TabIndex = 1
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
		Me.Label5.Text = "Qte livr"
		Me.Label5.Size = New System.Drawing.Size(113, 17)
		Me.Label5.Location = New System.Drawing.Point(112, 32)
		Me.Label5.TabIndex = 2
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
		Me.Label10.Text = "Description"
		Me.Label10.Size = New System.Drawing.Size(113, 17)
		Me.Label10.Location = New System.Drawing.Point(32, 96)
		Me.Label10.TabIndex = 9
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
		Me.lvwBonLivraison.Size = New System.Drawing.Size(529, 145)
		Me.lvwBonLivraison.Location = New System.Drawing.Point(0, 80)
		Me.lvwBonLivraison.TabIndex = 13
		Me.lvwBonLivraison.View = System.Windows.Forms.View.Details
		Me.lvwBonLivraison.LabelEdit = False
		Me.lvwBonLivraison.LabelWrap = True
		Me.lvwBonLivraison.HideSelection = True
		Me.lvwBonLivraison.FullRowSelect = True
		Me.lvwBonLivraison.GridLines = True
		Me.lvwBonLivraison.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwBonLivraison.BackColor = System.Drawing.SystemColors.Window
		Me.lvwBonLivraison.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwBonLivraison.Name = "lvwBonLivraison"
		Me._lvwBonLivraison_ColumnHeader_1.Text = "qte com"
		Me._lvwBonLivraison_ColumnHeader_1.Width = 118
		Me._lvwBonLivraison_ColumnHeader_2.Text = "qte livr"
		Me._lvwBonLivraison_ColumnHeader_2.Width = 118
		Me._lvwBonLivraison_ColumnHeader_3.Text = "qte bo"
		Me._lvwBonLivraison_ColumnHeader_3.Width = 118
		Me._lvwBonLivraison_ColumnHeader_4.Text = "description"
		Me._lvwBonLivraison_ColumnHeader_4.Width = 353
		Me._lvwBonLivraison_ColumnHeader_5.Text = "manufacturier"
		Me._lvwBonLivraison_ColumnHeader_5.Width = 177
		Me.Controls.Add(CmdQuit)
		Me.Controls.Add(CmdSupp)
		Me.Controls.Add(CmdAdd)
		Me.Controls.Add(fraqte)
		Me.Controls.Add(lvwBonLivraison)
		Me.fraqte.Controls.Add(txtManufacturier)
		Me.fraqte.Controls.Add(txtQteBo)
		Me.fraqte.Controls.Add(txtQteCom)
		Me.fraqte.Controls.Add(cmdSave)
		Me.fraqte.Controls.Add(cmdFermerQte)
		Me.fraqte.Controls.Add(txtQteLivr)
		Me.fraqte.Controls.Add(txtDescription)
		Me.fraqte.Controls.Add(Label3)
		Me.fraqte.Controls.Add(Label1)
		Me.fraqte.Controls.Add(label2)
		Me.fraqte.Controls.Add(Label5)
		Me.fraqte.Controls.Add(Label10)
		Me.lvwBonLivraison.Columns.Add(_lvwBonLivraison_ColumnHeader_1)
		Me.lvwBonLivraison.Columns.Add(_lvwBonLivraison_ColumnHeader_2)
		Me.lvwBonLivraison.Columns.Add(_lvwBonLivraison_ColumnHeader_3)
		Me.lvwBonLivraison.Columns.Add(_lvwBonLivraison_ColumnHeader_4)
		Me.lvwBonLivraison.Columns.Add(_lvwBonLivraison_ColumnHeader_5)
		Me.fraqte.ResumeLayout(False)
		Me.lvwBonLivraison.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class