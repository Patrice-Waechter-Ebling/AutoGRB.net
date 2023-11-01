<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSoumissionSectionElec
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
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents txtAnglais As System.Windows.Forms.TextBox
	Public WithEvents txtFrancais As System.Windows.Forms.TextBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents fraAjout As System.Windows.Forms.GroupBox
	Public WithEvents cmdModifier As System.Windows.Forms.Button
	Public WithEvents _lvwSection_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwSection_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwSection As System.Windows.Forms.ListView
	Public WithEvents CmdAdd As System.Windows.Forms.Button
	Public WithEvents cmdDown As System.Windows.Forms.Button
	Public WithEvents cmdUp As System.Windows.Forms.Button
	Public WithEvents CmdFerme As System.Windows.Forms.Button
	Public WithEvents CmdSupp As System.Windows.Forms.Button
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSoumissionSectionElec))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.fraAjout = New System.Windows.Forms.GroupBox
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.cmdOK = New System.Windows.Forms.Button
		Me.txtAnglais = New System.Windows.Forms.TextBox
		Me.txtFrancais = New System.Windows.Forms.TextBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.cmdModifier = New System.Windows.Forms.Button
		Me.lvwSection = New System.Windows.Forms.ListView
		Me._lvwSection_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwSection_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me.CmdAdd = New System.Windows.Forms.Button
		Me.cmdDown = New System.Windows.Forms.Button
		Me.cmdUp = New System.Windows.Forms.Button
		Me.CmdFerme = New System.Windows.Forms.Button
		Me.CmdSupp = New System.Windows.Forms.Button
		Me._Label1_0 = New System.Windows.Forms.Label
		Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.fraAjout.SuspendLayout()
		Me.lvwSection.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Sections électriques"
		Me.ClientSize = New System.Drawing.Size(401, 274)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmSoumissionSectionElec.BackgroundImage"), System.Drawing.Image)
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmSoumissionSectionElec"
		Me.fraAjout.BackColor = System.Drawing.Color.Black
		Me.fraAjout.Text = "Ajout de nouvelles sections"
		Me.fraAjout.ForeColor = System.Drawing.Color.White
		Me.fraAjout.Size = New System.Drawing.Size(305, 81)
		Me.fraAjout.Location = New System.Drawing.Point(16, 120)
		Me.fraAjout.TabIndex = 3
		Me.fraAjout.Visible = False
		Me.fraAjout.Enabled = True
		Me.fraAjout.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraAjout.Padding = New System.Windows.Forms.Padding(0)
		Me.fraAjout.Name = "fraAjout"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(57, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(232, 16)
		Me.cmdAnnuler.TabIndex = 4
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOK.Text = "OK"
		Me.cmdOK.Size = New System.Drawing.Size(57, 25)
		Me.cmdOK.Location = New System.Drawing.Point(232, 48)
		Me.cmdOK.TabIndex = 9
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me.txtAnglais.AutoSize = False
		Me.txtAnglais.Size = New System.Drawing.Size(153, 19)
		Me.txtAnglais.Location = New System.Drawing.Point(64, 48)
		Me.txtAnglais.TabIndex = 8
		Me.txtAnglais.AcceptsReturn = True
		Me.txtAnglais.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtAnglais.BackColor = System.Drawing.SystemColors.Window
		Me.txtAnglais.CausesValidation = True
		Me.txtAnglais.Enabled = True
		Me.txtAnglais.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAnglais.HideSelection = True
		Me.txtAnglais.ReadOnly = False
		Me.txtAnglais.Maxlength = 0
		Me.txtAnglais.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAnglais.MultiLine = False
		Me.txtAnglais.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAnglais.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtAnglais.TabStop = True
		Me.txtAnglais.Visible = True
		Me.txtAnglais.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAnglais.Name = "txtAnglais"
		Me.txtFrancais.AutoSize = False
		Me.txtFrancais.Size = New System.Drawing.Size(153, 19)
		Me.txtFrancais.Location = New System.Drawing.Point(64, 24)
		Me.txtFrancais.TabIndex = 6
		Me.txtFrancais.AcceptsReturn = True
		Me.txtFrancais.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtFrancais.BackColor = System.Drawing.SystemColors.Window
		Me.txtFrancais.CausesValidation = True
		Me.txtFrancais.Enabled = True
		Me.txtFrancais.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtFrancais.HideSelection = True
		Me.txtFrancais.ReadOnly = False
		Me.txtFrancais.Maxlength = 0
		Me.txtFrancais.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtFrancais.MultiLine = False
		Me.txtFrancais.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtFrancais.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtFrancais.TabStop = True
		Me.txtFrancais.Visible = True
		Me.txtFrancais.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtFrancais.Name = "txtFrancais"
		Me.Label3.Text = "Anglais"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(41, 17)
		Me.Label3.Location = New System.Drawing.Point(16, 48)
		Me.Label3.TabIndex = 7
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
		Me.Label2.Text = "Français"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(41, 17)
		Me.Label2.Location = New System.Drawing.Point(16, 24)
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
		Me.cmdModifier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdModifier.BackColor = System.Drawing.SystemColors.Control
		Me.cmdModifier.Text = "&Modifier"
		Me.cmdModifier.Size = New System.Drawing.Size(97, 33)
		Me.cmdModifier.Location = New System.Drawing.Point(296, 152)
		Me.cmdModifier.TabIndex = 11
		Me.cmdModifier.CausesValidation = True
		Me.cmdModifier.Enabled = True
		Me.cmdModifier.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdModifier.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdModifier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdModifier.TabStop = True
		Me.cmdModifier.Name = "cmdModifier"
		Me.lvwSection.Size = New System.Drawing.Size(241, 193)
		Me.lvwSection.Location = New System.Drawing.Point(48, 72)
		Me.lvwSection.TabIndex = 13
		Me.lvwSection.View = System.Windows.Forms.View.Details
		Me.lvwSection.LabelEdit = False
		Me.lvwSection.LabelWrap = True
		Me.lvwSection.HideSelection = True
		Me.lvwSection.FullRowSelect = True
		Me.lvwSection.GridLines = True
		Me.lvwSection.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwSection.BackColor = System.Drawing.SystemColors.Window
		Me.lvwSection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwSection.Name = "lvwSection"
		Me._lvwSection_ColumnHeader_1.Text = "Français"
		Me._lvwSection_ColumnHeader_1.Width = 195
		Me._lvwSection_ColumnHeader_2.Text = "Anglais"
		Me._lvwSection_ColumnHeader_2.Width = 195
		Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdAdd.BackColor = System.Drawing.SystemColors.Control
		Me.CmdAdd.Text = "&Ajouter"
		Me.CmdAdd.Size = New System.Drawing.Size(97, 33)
		Me.CmdAdd.Location = New System.Drawing.Point(296, 72)
		Me.CmdAdd.TabIndex = 1
		Me.CmdAdd.CausesValidation = True
		Me.CmdAdd.Enabled = True
		Me.CmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdAdd.TabStop = True
		Me.CmdAdd.Name = "CmdAdd"
		Me.cmdDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDown.Text = "È"
		Me.cmdDown.Font = New System.Drawing.Font("Wingdings 3", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
		Me.cmdDown.Size = New System.Drawing.Size(33, 33)
		Me.cmdDown.Location = New System.Drawing.Point(8, 176)
		Me.cmdDown.TabIndex = 12
		Me.cmdDown.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDown.CausesValidation = True
		Me.cmdDown.Enabled = True
		Me.cmdDown.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDown.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDown.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDown.TabStop = True
		Me.cmdDown.Name = "cmdDown"
		Me.cmdUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdUp.Text = "Ç"
		Me.cmdUp.Font = New System.Drawing.Font("Wingdings 3", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
		Me.cmdUp.Size = New System.Drawing.Size(33, 33)
		Me.cmdUp.Location = New System.Drawing.Point(8, 128)
		Me.cmdUp.TabIndex = 10
		Me.cmdUp.BackColor = System.Drawing.SystemColors.Control
		Me.cmdUp.CausesValidation = True
		Me.cmdUp.Enabled = True
		Me.cmdUp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdUp.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdUp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdUp.TabStop = True
		Me.cmdUp.Name = "cmdUp"
		Me.CmdFerme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdFerme.BackColor = System.Drawing.SystemColors.Control
		Me.CmdFerme.Text = "&Fermer"
		Me.CmdFerme.Size = New System.Drawing.Size(97, 33)
		Me.CmdFerme.Location = New System.Drawing.Point(296, 232)
		Me.CmdFerme.TabIndex = 14
		Me.CmdFerme.CausesValidation = True
		Me.CmdFerme.Enabled = True
		Me.CmdFerme.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdFerme.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdFerme.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdFerme.TabStop = True
		Me.CmdFerme.Name = "CmdFerme"
		Me.CmdSupp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdSupp.BackColor = System.Drawing.SystemColors.Control
		Me.CmdSupp.Text = "&Supprimer"
		Me.CmdSupp.Size = New System.Drawing.Size(97, 33)
		Me.CmdSupp.Location = New System.Drawing.Point(296, 112)
		Me.CmdSupp.TabIndex = 2
		Me.CmdSupp.CausesValidation = True
		Me.CmdSupp.Enabled = True
		Me.CmdSupp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdSupp.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdSupp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdSupp.TabStop = True
		Me.CmdSupp.Name = "CmdSupp"
		Me._Label1_0.BackColor = System.Drawing.Color.Black
		Me._Label1_0.Text = "Section"
		Me._Label1_0.ForeColor = System.Drawing.Color.White
		Me._Label1_0.Size = New System.Drawing.Size(89, 17)
		Me._Label1_0.Location = New System.Drawing.Point(48, 56)
		Me._Label1_0.TabIndex = 0
		Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_0.Enabled = True
		Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_0.UseMnemonic = True
		Me._Label1_0.Visible = True
		Me._Label1_0.AutoSize = False
		Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_0.Name = "_Label1_0"
		Me.Controls.Add(fraAjout)
		Me.Controls.Add(cmdModifier)
		Me.Controls.Add(lvwSection)
		Me.Controls.Add(CmdAdd)
		Me.Controls.Add(cmdDown)
		Me.Controls.Add(cmdUp)
		Me.Controls.Add(CmdFerme)
		Me.Controls.Add(CmdSupp)
		Me.Controls.Add(_Label1_0)
		Me.fraAjout.Controls.Add(cmdAnnuler)
		Me.fraAjout.Controls.Add(cmdOK)
		Me.fraAjout.Controls.Add(txtAnglais)
		Me.fraAjout.Controls.Add(txtFrancais)
		Me.fraAjout.Controls.Add(Label3)
		Me.fraAjout.Controls.Add(Label2)
		Me.lvwSection.Columns.Add(_lvwSection_ColumnHeader_1)
		Me.lvwSection.Columns.Add(_lvwSection_ColumnHeader_2)
		Me.Label1.SetIndex(_Label1_0, CType(0, Short))
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.fraAjout.ResumeLayout(False)
		Me.lvwSection.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class