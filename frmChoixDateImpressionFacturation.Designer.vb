<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixDateImpressionFacturation
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
	Public WithEvents _optChoix_1 As System.Windows.Forms.RadioButton
	Public WithEvents cmdDateFin As System.Windows.Forms.Button
	Public WithEvents cmdDateDebut As System.Windows.Forms.Button
	Public WithEvents mskDateDebut As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskDateFin As System.Windows.Forms.MaskedTextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents fra2Dates As System.Windows.Forms.GroupBox
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents cmdImprimer As System.Windows.Forms.Button
	Public WithEvents _optChoixProjetEntier_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optChoixProjetEntier_0 As System.Windows.Forms.RadioButton
	Public WithEvents Picture1 As System.Windows.Forms.Panel
	Public WithEvents fraProjetEntier As System.Windows.Forms.GroupBox
	Public WithEvents _optChoix_0 As System.Windows.Forms.RadioButton
	Public WithEvents optChoix As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	Public WithEvents optChoixProjetEntier As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixDateImpressionFacturation))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.mvwDate = New AxMSComCtl2.AxMonthView
		Me._optChoix_1 = New System.Windows.Forms.RadioButton
		Me.fra2Dates = New System.Windows.Forms.GroupBox
		Me.cmdDateFin = New System.Windows.Forms.Button
		Me.cmdDateDebut = New System.Windows.Forms.Button
		Me.mskDateDebut = New System.Windows.Forms.MaskedTextBox
		Me.mskDateFin = New System.Windows.Forms.MaskedTextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.cmdImprimer = New System.Windows.Forms.Button
		Me.fraProjetEntier = New System.Windows.Forms.GroupBox
		Me.Picture1 = New System.Windows.Forms.Panel
		Me._optChoixProjetEntier_1 = New System.Windows.Forms.RadioButton
		Me._optChoixProjetEntier_0 = New System.Windows.Forms.RadioButton
		Me._optChoix_0 = New System.Windows.Forms.RadioButton
		Me.optChoix = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.optChoixProjetEntier = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.fra2Dates.SuspendLayout()
		Me.fraProjetEntier.SuspendLayout()
		Me.Picture1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optChoix, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optChoixProjetEntier, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Exportation feuilles de temps"
		Me.ClientSize = New System.Drawing.Size(436, 261)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixDateImpressionFacturation.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmChoixDateImpressionFacturation"
		mvwDate.OcxState = CType(resources.GetObject("mvwDate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwDate.Size = New System.Drawing.Size(173, 158)
		Me.mvwDate.Location = New System.Drawing.Point(248, 56)
		Me.mvwDate.TabIndex = 0
		Me.mvwDate.Visible = False
		Me.mvwDate.Name = "mvwDate"
		Me._optChoix_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoix_1.BackColor = System.Drawing.Color.Black
		Me._optChoix_1.Text = "Entre 2 dates"
		Me._optChoix_1.ForeColor = System.Drawing.Color.White
		Me._optChoix_1.Size = New System.Drawing.Size(99, 17)
		Me._optChoix_1.Location = New System.Drawing.Point(216, 104)
		Me._optChoix_1.TabIndex = 11
		Me._optChoix_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoix_1.CausesValidation = True
		Me._optChoix_1.Enabled = True
		Me._optChoix_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChoix_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChoix_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optChoix_1.TabStop = True
		Me._optChoix_1.Checked = False
		Me._optChoix_1.Visible = True
		Me._optChoix_1.Name = "_optChoix_1"
		Me.fra2Dates.BackColor = System.Drawing.Color.Black
		Me.fra2Dates.Enabled = False
		Me.fra2Dates.ForeColor = System.Drawing.Color.White
		Me.fra2Dates.Size = New System.Drawing.Size(217, 89)
		Me.fra2Dates.Location = New System.Drawing.Point(208, 104)
		Me.fra2Dates.TabIndex = 3
		Me.fra2Dates.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fra2Dates.Visible = True
		Me.fra2Dates.Padding = New System.Windows.Forms.Padding(0)
		Me.fra2Dates.Name = "fra2Dates"
		Me.cmdDateFin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDateFin.Text = "..."
		Me.cmdDateFin.Size = New System.Drawing.Size(25, 17)
		Me.cmdDateFin.Location = New System.Drawing.Point(184, 64)
		Me.cmdDateFin.TabIndex = 7
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
		Me.cmdDateDebut.Location = New System.Drawing.Point(184, 32)
		Me.cmdDateDebut.TabIndex = 4
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
		Me.mskDateDebut.Location = New System.Drawing.Point(96, 32)
		Me.mskDateDebut.TabIndex = 5
		Me.mskDateDebut.PromptChar = "_"
		Me.mskDateDebut.Name = "mskDateDebut"
		Me.mskDateFin.AllowPromptAsInput = False
		Me.mskDateFin.Size = New System.Drawing.Size(81, 17)
		Me.mskDateFin.Location = New System.Drawing.Point(96, 64)
		Me.mskDateFin.TabIndex = 6
		Me.mskDateFin.PromptChar = "_"
		Me.mskDateFin.Name = "mskDateFin"
		Me.Label1.Text = "Date début :"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(65, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 32)
		Me.Label1.TabIndex = 10
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
		Me.Label2.Text = "Date fin :"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(65, 17)
		Me.Label2.Location = New System.Drawing.Point(16, 64)
		Me.Label2.TabIndex = 9
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
		Me.Label3.Size = New System.Drawing.Size(81, 17)
		Me.Label3.Location = New System.Drawing.Point(96, 16)
		Me.Label3.TabIndex = 8
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
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(73, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(272, 224)
		Me.cmdAnnuler.TabIndex = 1
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
		Me.cmdImprimer.Location = New System.Drawing.Point(352, 224)
		Me.cmdImprimer.TabIndex = 2
		Me.cmdImprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdImprimer.CausesValidation = True
		Me.cmdImprimer.Enabled = True
		Me.cmdImprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdImprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdImprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdImprimer.TabStop = True
		Me.cmdImprimer.Name = "cmdImprimer"
		Me.fraProjetEntier.BackColor = System.Drawing.Color.Black
		Me.fraProjetEntier.Text = "Choix de l'impression"
		Me.fraProjetEntier.ForeColor = System.Drawing.Color.White
		Me.fraProjetEntier.Size = New System.Drawing.Size(185, 121)
		Me.fraProjetEntier.Location = New System.Drawing.Point(8, 72)
		Me.fraProjetEntier.TabIndex = 12
		Me.fraProjetEntier.Enabled = True
		Me.fraProjetEntier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraProjetEntier.Visible = True
		Me.fraProjetEntier.Padding = New System.Windows.Forms.Padding(0)
		Me.fraProjetEntier.Name = "fraProjetEntier"
		Me.Picture1.BackColor = System.Drawing.Color.Black
		Me.Picture1.Size = New System.Drawing.Size(161, 97)
		Me.Picture1.Location = New System.Drawing.Point(8, 16)
		Me.Picture1.TabIndex = 13
		Me.Picture1.Dock = System.Windows.Forms.DockStyle.None
		Me.Picture1.CausesValidation = True
		Me.Picture1.Enabled = True
		Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture1.TabStop = True
		Me.Picture1.Visible = True
		Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Picture1.Name = "Picture1"
		Me._optChoixProjetEntier_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoixProjetEntier_1.BackColor = System.Drawing.Color.Black
		Me._optChoixProjetEntier_1.Text = "Prix coûtant du projet"
		Me._optChoixProjetEntier_1.ForeColor = System.Drawing.Color.White
		Me._optChoixProjetEntier_1.Size = New System.Drawing.Size(121, 17)
		Me._optChoixProjetEntier_1.Location = New System.Drawing.Point(24, 64)
		Me._optChoixProjetEntier_1.TabIndex = 15
		Me._optChoixProjetEntier_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoixProjetEntier_1.CausesValidation = True
		Me._optChoixProjetEntier_1.Enabled = True
		Me._optChoixProjetEntier_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChoixProjetEntier_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChoixProjetEntier_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optChoixProjetEntier_1.TabStop = True
		Me._optChoixProjetEntier_1.Checked = False
		Me._optChoixProjetEntier_1.Visible = True
		Me._optChoixProjetEntier_1.Name = "_optChoixProjetEntier_1"
		Me._optChoixProjetEntier_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoixProjetEntier_0.BackColor = System.Drawing.Color.Black
		Me._optChoixProjetEntier_0.Text = "Liste des punchs"
		Me._optChoixProjetEntier_0.ForeColor = System.Drawing.Color.White
		Me._optChoixProjetEntier_0.Size = New System.Drawing.Size(105, 17)
		Me._optChoixProjetEntier_0.Location = New System.Drawing.Point(24, 24)
		Me._optChoixProjetEntier_0.TabIndex = 14
		Me._optChoixProjetEntier_0.Checked = True
		Me._optChoixProjetEntier_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoixProjetEntier_0.CausesValidation = True
		Me._optChoixProjetEntier_0.Enabled = True
		Me._optChoixProjetEntier_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChoixProjetEntier_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChoixProjetEntier_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optChoixProjetEntier_0.TabStop = True
		Me._optChoixProjetEntier_0.Visible = True
		Me._optChoixProjetEntier_0.Name = "_optChoixProjetEntier_0"
		Me._optChoix_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoix_0.BackColor = System.Drawing.Color.Black
		Me._optChoix_0.Text = "Projet entier"
		Me._optChoix_0.ForeColor = System.Drawing.Color.White
		Me._optChoix_0.Size = New System.Drawing.Size(129, 17)
		Me._optChoix_0.Location = New System.Drawing.Point(216, 72)
		Me._optChoix_0.TabIndex = 16
		Me._optChoix_0.Checked = True
		Me._optChoix_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoix_0.CausesValidation = True
		Me._optChoix_0.Enabled = True
		Me._optChoix_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChoix_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChoix_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optChoix_0.TabStop = True
		Me._optChoix_0.Visible = True
		Me._optChoix_0.Name = "_optChoix_0"
		Me.Controls.Add(mvwDate)
		Me.Controls.Add(_optChoix_1)
		Me.Controls.Add(fra2Dates)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(cmdImprimer)
		Me.Controls.Add(fraProjetEntier)
		Me.Controls.Add(_optChoix_0)
		Me.fra2Dates.Controls.Add(cmdDateFin)
		Me.fra2Dates.Controls.Add(cmdDateDebut)
		Me.fra2Dates.Controls.Add(mskDateDebut)
		Me.fra2Dates.Controls.Add(mskDateFin)
		Me.fra2Dates.Controls.Add(Label1)
		Me.fra2Dates.Controls.Add(Label2)
		Me.fra2Dates.Controls.Add(Label3)
		Me.fraProjetEntier.Controls.Add(Picture1)
		Me.Picture1.Controls.Add(_optChoixProjetEntier_1)
		Me.Picture1.Controls.Add(_optChoixProjetEntier_0)
		Me.optChoix.SetIndex(_optChoix_1, CType(1, Short))
		Me.optChoix.SetIndex(_optChoix_0, CType(0, Short))
		Me.optChoixProjetEntier.SetIndex(_optChoixProjetEntier_1, CType(1, Short))
		Me.optChoixProjetEntier.SetIndex(_optChoixProjetEntier_0, CType(0, Short))
		CType(Me.optChoixProjetEntier, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.optChoix, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).EndInit()
		Me.fra2Dates.ResumeLayout(False)
		Me.fraProjetEntier.ResumeLayout(False)
		Me.Picture1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class