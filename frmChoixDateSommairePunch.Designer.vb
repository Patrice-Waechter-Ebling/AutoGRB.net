<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixDateSommairePunch
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
	Public WithEvents cmdDateFin As System.Windows.Forms.Button
	Public WithEvents cmdDateDebut As System.Windows.Forms.Button
	Public WithEvents mskDateDebut As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskDateFin As System.Windows.Forms.MaskedTextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Frame3 As System.Windows.Forms.GroupBox
	Public WithEvents _lvwFamille_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwFamille As System.Windows.Forms.ListView
	Public WithEvents fraFamille As System.Windows.Forms.GroupBox
	Public WithEvents _optProjets_2 As System.Windows.Forms.RadioButton
	Public WithEvents _optProjets_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optProjets_0 As System.Windows.Forms.RadioButton
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents cmdImprimer As System.Windows.Forms.Button
	Public WithEvents optProjets As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixDateSommairePunch))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.mvwDate = New AxMSComCtl2.AxMonthView
		Me.Frame3 = New System.Windows.Forms.GroupBox
		Me.cmdDateFin = New System.Windows.Forms.Button
		Me.cmdDateDebut = New System.Windows.Forms.Button
		Me.mskDateDebut = New System.Windows.Forms.MaskedTextBox
		Me.mskDateFin = New System.Windows.Forms.MaskedTextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.fraFamille = New System.Windows.Forms.GroupBox
		Me.lvwFamille = New System.Windows.Forms.ListView
		Me._lvwFamille_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me._optProjets_2 = New System.Windows.Forms.RadioButton
		Me._optProjets_1 = New System.Windows.Forms.RadioButton
		Me._optProjets_0 = New System.Windows.Forms.RadioButton
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.cmdImprimer = New System.Windows.Forms.Button
		Me.optProjets = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.Frame3.SuspendLayout()
		Me.fraFamille.SuspendLayout()
		Me.lvwFamille.SuspendLayout()
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optProjets, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Sommaire des projets"
		Me.ClientSize = New System.Drawing.Size(520, 246)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixDateSommairePunch.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmChoixDateSommairePunch"
		mvwDate.OcxState = CType(resources.GetObject("mvwDate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwDate.Size = New System.Drawing.Size(176, 158)
		Me.mvwDate.Location = New System.Drawing.Point(336, 48)
		Me.mvwDate.TabIndex = 14
		Me.mvwDate.Visible = False
		Me.mvwDate.Name = "mvwDate"
		Me.Frame3.BackColor = System.Drawing.Color.Black
		Me.Frame3.Text = "Date"
		Me.Frame3.ForeColor = System.Drawing.Color.White
		Me.Frame3.Size = New System.Drawing.Size(193, 137)
		Me.Frame3.Location = New System.Drawing.Point(320, 64)
		Me.Frame3.TabIndex = 6
		Me.Frame3.Enabled = True
		Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame3.Visible = True
		Me.Frame3.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame3.Name = "Frame3"
		Me.cmdDateFin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDateFin.Text = "..."
		Me.cmdDateFin.Size = New System.Drawing.Size(25, 17)
		Me.cmdDateFin.Location = New System.Drawing.Point(152, 72)
		Me.cmdDateFin.TabIndex = 10
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
		Me.cmdDateDebut.Location = New System.Drawing.Point(152, 40)
		Me.cmdDateDebut.TabIndex = 7
		Me.cmdDateDebut.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDateDebut.CausesValidation = True
		Me.cmdDateDebut.Enabled = True
		Me.cmdDateDebut.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDateDebut.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDateDebut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDateDebut.TabStop = True
		Me.cmdDateDebut.Name = "cmdDateDebut"
		Me.mskDateDebut.AllowPromptAsInput = False
		Me.mskDateDebut.Size = New System.Drawing.Size(81, 17)
		Me.mskDateDebut.Location = New System.Drawing.Point(64, 40)
		Me.mskDateDebut.TabIndex = 8
		Me.mskDateDebut.PromptChar = "_"
		Me.mskDateDebut.Name = "mskDateDebut"
		Me.mskDateFin.AllowPromptAsInput = False
		Me.mskDateFin.Size = New System.Drawing.Size(81, 17)
		Me.mskDateFin.Location = New System.Drawing.Point(64, 72)
		Me.mskDateFin.TabIndex = 9
		Me.mskDateFin.PromptChar = "_"
		Me.mskDateFin.Name = "mskDateFin"
		Me.Label1.Text = "Début :"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(49, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 40)
		Me.Label1.TabIndex = 13
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
		Me.Label2.Text = "Fin :"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(49, 17)
		Me.Label2.Location = New System.Drawing.Point(16, 72)
		Me.Label2.TabIndex = 12
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
		Me.Label3.Text = "AA-MM-JJ"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(73, 17)
		Me.Label3.Location = New System.Drawing.Point(72, 24)
		Me.Label3.TabIndex = 11
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
		Me.fraFamille.BackColor = System.Drawing.Color.Black
		Me.fraFamille.Text = "Famille"
		Me.fraFamille.ForeColor = System.Drawing.Color.White
		Me.fraFamille.Size = New System.Drawing.Size(153, 137)
		Me.fraFamille.Location = New System.Drawing.Point(160, 64)
		Me.fraFamille.TabIndex = 5
		Me.fraFamille.Enabled = True
		Me.fraFamille.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraFamille.Visible = True
		Me.fraFamille.Padding = New System.Windows.Forms.Padding(0)
		Me.fraFamille.Name = "fraFamille"
		Me.lvwFamille.Size = New System.Drawing.Size(137, 105)
		Me.lvwFamille.Location = New System.Drawing.Point(8, 24)
		Me.lvwFamille.TabIndex = 15
		Me.lvwFamille.View = System.Windows.Forms.View.Details
		Me.lvwFamille.LabelEdit = False
		Me.lvwFamille.LabelWrap = True
		Me.lvwFamille.HideSelection = True
		Me.lvwFamille.Checkboxes = True
		Me.lvwFamille.FullRowSelect = True
		Me.lvwFamille.GridLines = True
		Me.lvwFamille.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwFamille.BackColor = System.Drawing.SystemColors.Window
		Me.lvwFamille.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwFamille.Name = "lvwFamille"
		Me._lvwFamille_ColumnHeader_1.Text = "Famille"
		Me._lvwFamille_ColumnHeader_1.Width = 236
		Me.Frame1.BackColor = System.Drawing.Color.Black
		Me.Frame1.Text = "Projets"
		Me.Frame1.ForeColor = System.Drawing.Color.White
		Me.Frame1.Size = New System.Drawing.Size(145, 137)
		Me.Frame1.Location = New System.Drawing.Point(8, 64)
		Me.Frame1.TabIndex = 2
		Me.Frame1.Enabled = True
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame1.Name = "Frame1"
		Me._optProjets_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optProjets_2.BackColor = System.Drawing.Color.Black
		Me._optProjets_2.Text = "Sommaire des heures"
		Me._optProjets_2.ForeColor = System.Drawing.Color.White
		Me._optProjets_2.Size = New System.Drawing.Size(135, 17)
		Me._optProjets_2.Location = New System.Drawing.Point(8, 96)
		Me._optProjets_2.TabIndex = 16
		Me._optProjets_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optProjets_2.CausesValidation = True
		Me._optProjets_2.Enabled = True
		Me._optProjets_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._optProjets_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optProjets_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optProjets_2.TabStop = True
		Me._optProjets_2.Checked = False
		Me._optProjets_2.Visible = True
		Me._optProjets_2.Name = "_optProjets_2"
		Me._optProjets_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optProjets_1.BackColor = System.Drawing.Color.Black
		Me._optProjets_1.Text = "Projets GRB seulement"
		Me._optProjets_1.ForeColor = System.Drawing.Color.White
		Me._optProjets_1.Size = New System.Drawing.Size(135, 17)
		Me._optProjets_1.Location = New System.Drawing.Point(8, 64)
		Me._optProjets_1.TabIndex = 4
		Me._optProjets_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optProjets_1.CausesValidation = True
		Me._optProjets_1.Enabled = True
		Me._optProjets_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optProjets_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optProjets_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optProjets_1.TabStop = True
		Me._optProjets_1.Checked = False
		Me._optProjets_1.Visible = True
		Me._optProjets_1.Name = "_optProjets_1"
		Me._optProjets_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optProjets_0.BackColor = System.Drawing.Color.Black
		Me._optProjets_0.Text = "Tous les projets"
		Me._optProjets_0.ForeColor = System.Drawing.Color.White
		Me._optProjets_0.Size = New System.Drawing.Size(135, 17)
		Me._optProjets_0.Location = New System.Drawing.Point(8, 32)
		Me._optProjets_0.TabIndex = 3
		Me._optProjets_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optProjets_0.CausesValidation = True
		Me._optProjets_0.Enabled = True
		Me._optProjets_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optProjets_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optProjets_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optProjets_0.TabStop = True
		Me._optProjets_0.Checked = False
		Me._optProjets_0.Visible = True
		Me._optProjets_0.Name = "_optProjets_0"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(73, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(352, 208)
		Me.cmdAnnuler.TabIndex = 0
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
		Me.AcceptButton = Me.cmdImprimer
		Me.cmdImprimer.Size = New System.Drawing.Size(73, 25)
		Me.cmdImprimer.Location = New System.Drawing.Point(432, 208)
		Me.cmdImprimer.TabIndex = 1
		Me.cmdImprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdImprimer.CausesValidation = True
		Me.cmdImprimer.Enabled = True
		Me.cmdImprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdImprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdImprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdImprimer.TabStop = True
		Me.cmdImprimer.Name = "cmdImprimer"
		Me.Controls.Add(mvwDate)
		Me.Controls.Add(Frame3)
		Me.Controls.Add(fraFamille)
		Me.Controls.Add(Frame1)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(cmdImprimer)
		Me.Frame3.Controls.Add(cmdDateFin)
		Me.Frame3.Controls.Add(cmdDateDebut)
		Me.Frame3.Controls.Add(mskDateDebut)
		Me.Frame3.Controls.Add(mskDateFin)
		Me.Frame3.Controls.Add(Label1)
		Me.Frame3.Controls.Add(Label2)
		Me.Frame3.Controls.Add(Label3)
		Me.fraFamille.Controls.Add(lvwFamille)
		Me.lvwFamille.Columns.Add(_lvwFamille_ColumnHeader_1)
		Me.Frame1.Controls.Add(_optProjets_2)
		Me.Frame1.Controls.Add(_optProjets_1)
		Me.Frame1.Controls.Add(_optProjets_0)
		Me.optProjets.SetIndex(_optProjets_2, CType(2, Short))
		Me.optProjets.SetIndex(_optProjets_1, CType(1, Short))
		Me.optProjets.SetIndex(_optProjets_0, CType(0, Short))
		CType(Me.optProjets, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Frame3.ResumeLayout(False)
		Me.fraFamille.ResumeLayout(False)
		Me.lvwFamille.ResumeLayout(False)
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class