<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmAjoutDL
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
	Public WithEvents cmdExceptions As System.Windows.Forms.Button
	Public WithEvents _optChoixDossier_2 As System.Windows.Forms.RadioButton
	Public WithEvents _optChoixDossier_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optChoixDossier_0 As System.Windows.Forms.RadioButton
	Public WithEvents Picture1 As System.Windows.Forms.Panel
	Public WithEvents fraChoixDossier As System.Windows.Forms.GroupBox
	Public WithEvents _optChoix_5 As System.Windows.Forms.RadioButton
	Public WithEvents _optChoix_3 As System.Windows.Forms.RadioButton
	Public WithEvents _optChoix_0 As System.Windows.Forms.RadioButton
	Public WithEvents _optChoix_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optChoix_2 As System.Windows.Forms.RadioButton
	Public WithEvents _optChoix_4 As System.Windows.Forms.RadioButton
	Public WithEvents fraChoixListe As System.Windows.Forms.GroupBox
	Public WithEvents pgb As System.Windows.Forms.ProgressBar
	Public WithEvents txtPrefixe As System.Windows.Forms.TextBox
	Public WithEvents cmdCreer As System.Windows.Forms.Button
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents optChoix As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	Public WithEvents optChoixDossier As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAjoutDL))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdExceptions = New System.Windows.Forms.Button
		Me.fraChoixDossier = New System.Windows.Forms.GroupBox
		Me.Picture1 = New System.Windows.Forms.Panel
		Me._optChoixDossier_2 = New System.Windows.Forms.RadioButton
		Me._optChoixDossier_1 = New System.Windows.Forms.RadioButton
		Me._optChoixDossier_0 = New System.Windows.Forms.RadioButton
		Me.fraChoixListe = New System.Windows.Forms.GroupBox
		Me._optChoix_5 = New System.Windows.Forms.RadioButton
		Me._optChoix_3 = New System.Windows.Forms.RadioButton
		Me._optChoix_0 = New System.Windows.Forms.RadioButton
		Me._optChoix_1 = New System.Windows.Forms.RadioButton
		Me._optChoix_2 = New System.Windows.Forms.RadioButton
		Me._optChoix_4 = New System.Windows.Forms.RadioButton
		Me.pgb = New System.Windows.Forms.ProgressBar
		Me.txtPrefixe = New System.Windows.Forms.TextBox
		Me.cmdCreer = New System.Windows.Forms.Button
		Me.Label1 = New System.Windows.Forms.Label
		Me.optChoix = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.optChoixDossier = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.fraChoixDossier.SuspendLayout()
		Me.Picture1.SuspendLayout()
		Me.fraChoixListe.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.optChoix, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optChoixDossier, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.Text = "Création des listes de distribution"
		Me.ClientSize = New System.Drawing.Size(644, 483)
		Me.Location = New System.Drawing.Point(11, 17)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmAjoutDL.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmAjoutDL"
		Me.cmdExceptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExceptions.Text = "Liste des exceptions ..."
		Me.cmdExceptions.Size = New System.Drawing.Size(193, 33)
		Me.cmdExceptions.Location = New System.Drawing.Point(384, 280)
		Me.cmdExceptions.TabIndex = 16
		Me.cmdExceptions.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExceptions.CausesValidation = True
		Me.cmdExceptions.Enabled = True
		Me.cmdExceptions.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExceptions.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExceptions.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExceptions.TabStop = True
		Me.cmdExceptions.Name = "cmdExceptions"
		Me.fraChoixDossier.BackColor = System.Drawing.Color.Black
		Me.fraChoixDossier.Text = "Choix du dossier dans Outlook"
		Me.fraChoixDossier.ForeColor = System.Drawing.Color.White
		Me.fraChoixDossier.Size = New System.Drawing.Size(289, 177)
		Me.fraChoixDossier.Location = New System.Drawing.Point(336, 88)
		Me.fraChoixDossier.TabIndex = 10
		Me.fraChoixDossier.Enabled = True
		Me.fraChoixDossier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraChoixDossier.Visible = True
		Me.fraChoixDossier.Padding = New System.Windows.Forms.Padding(0)
		Me.fraChoixDossier.Name = "fraChoixDossier"
		Me.Picture1.BackColor = System.Drawing.Color.Black
		Me.Picture1.Size = New System.Drawing.Size(257, 121)
		Me.Picture1.Location = New System.Drawing.Point(24, 24)
		Me.Picture1.TabIndex = 11
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
		Me._optChoixDossier_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoixDossier_2.BackColor = System.Drawing.Color.Black
		Me._optChoixDossier_2.Text = "Fournisseurs GRB"
		Me._optChoixDossier_2.ForeColor = System.Drawing.Color.White
		Me._optChoixDossier_2.Size = New System.Drawing.Size(145, 17)
		Me._optChoixDossier_2.Location = New System.Drawing.Point(8, 96)
		Me._optChoixDossier_2.TabIndex = 14
		Me._optChoixDossier_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoixDossier_2.CausesValidation = True
		Me._optChoixDossier_2.Enabled = True
		Me._optChoixDossier_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChoixDossier_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChoixDossier_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optChoixDossier_2.TabStop = True
		Me._optChoixDossier_2.Checked = False
		Me._optChoixDossier_2.Visible = True
		Me._optChoixDossier_2.Name = "_optChoixDossier_2"
		Me._optChoixDossier_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoixDossier_1.BackColor = System.Drawing.Color.Black
		Me._optChoixDossier_1.Text = "Clients GRB"
		Me._optChoixDossier_1.ForeColor = System.Drawing.Color.White
		Me._optChoixDossier_1.Size = New System.Drawing.Size(113, 17)
		Me._optChoixDossier_1.Location = New System.Drawing.Point(8, 56)
		Me._optChoixDossier_1.TabIndex = 13
		Me._optChoixDossier_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoixDossier_1.CausesValidation = True
		Me._optChoixDossier_1.Enabled = True
		Me._optChoixDossier_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChoixDossier_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChoixDossier_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optChoixDossier_1.TabStop = True
		Me._optChoixDossier_1.Checked = False
		Me._optChoixDossier_1.Visible = True
		Me._optChoixDossier_1.Name = "_optChoixDossier_1"
		Me._optChoixDossier_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoixDossier_0.BackColor = System.Drawing.Color.Black
		Me._optChoixDossier_0.Text = "Contacts GRB"
		Me._optChoixDossier_0.ForeColor = System.Drawing.Color.White
		Me._optChoixDossier_0.Size = New System.Drawing.Size(113, 17)
		Me._optChoixDossier_0.Location = New System.Drawing.Point(8, 16)
		Me._optChoixDossier_0.TabIndex = 12
		Me._optChoixDossier_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoixDossier_0.CausesValidation = True
		Me._optChoixDossier_0.Enabled = True
		Me._optChoixDossier_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChoixDossier_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChoixDossier_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optChoixDossier_0.TabStop = True
		Me._optChoixDossier_0.Checked = False
		Me._optChoixDossier_0.Visible = True
		Me._optChoixDossier_0.Name = "_optChoixDossier_0"
		Me.fraChoixListe.BackColor = System.Drawing.Color.Black
		Me.fraChoixListe.Text = "Choix de la liste"
		Me.fraChoixListe.ForeColor = System.Drawing.Color.White
		Me.fraChoixListe.Size = New System.Drawing.Size(289, 233)
		Me.fraChoixListe.Location = New System.Drawing.Point(24, 88)
		Me.fraChoixListe.TabIndex = 4
		Me.fraChoixListe.Enabled = True
		Me.fraChoixListe.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraChoixListe.Visible = True
		Me.fraChoixListe.Padding = New System.Windows.Forms.Padding(0)
		Me.fraChoixListe.Name = "fraChoixListe"
		Me._optChoix_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoix_5.BackColor = System.Drawing.Color.Black
		Me._optChoix_5.Text = "Tous les membres du Meat Processing"
		Me._optChoix_5.ForeColor = System.Drawing.Color.White
		Me._optChoix_5.Size = New System.Drawing.Size(257, 33)
		Me._optChoix_5.Location = New System.Drawing.Point(16, 152)
		Me._optChoix_5.TabIndex = 15
		Me._optChoix_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoix_5.CausesValidation = True
		Me._optChoix_5.Enabled = True
		Me._optChoix_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChoix_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChoix_5.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optChoix_5.TabStop = True
		Me._optChoix_5.Checked = False
		Me._optChoix_5.Visible = True
		Me._optChoix_5.Name = "_optChoix_5"
		Me._optChoix_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoix_3.BackColor = System.Drawing.Color.Black
		Me._optChoix_3.Text = "Tous les fournisseurs"
		Me._optChoix_3.ForeColor = System.Drawing.Color.White
		Me._optChoix_3.Size = New System.Drawing.Size(129, 17)
		Me._optChoix_3.Location = New System.Drawing.Point(136, 40)
		Me._optChoix_3.TabIndex = 9
		Me._optChoix_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoix_3.CausesValidation = True
		Me._optChoix_3.Enabled = True
		Me._optChoix_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChoix_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChoix_3.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optChoix_3.TabStop = True
		Me._optChoix_3.Checked = False
		Me._optChoix_3.Visible = True
		Me._optChoix_3.Name = "_optChoix_3"
		Me._optChoix_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoix_0.BackColor = System.Drawing.Color.Black
		Me._optChoix_0.Text = "Tous les contacts"
		Me._optChoix_0.ForeColor = System.Drawing.Color.White
		Me._optChoix_0.Size = New System.Drawing.Size(113, 17)
		Me._optChoix_0.Location = New System.Drawing.Point(16, 40)
		Me._optChoix_0.TabIndex = 8
		Me._optChoix_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoix_0.CausesValidation = True
		Me._optChoix_0.Enabled = True
		Me._optChoix_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChoix_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChoix_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optChoix_0.TabStop = True
		Me._optChoix_0.Checked = False
		Me._optChoix_0.Visible = True
		Me._optChoix_0.Name = "_optChoix_0"
		Me._optChoix_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoix_1.BackColor = System.Drawing.Color.Black
		Me._optChoix_1.Text = "Tous les clients"
		Me._optChoix_1.ForeColor = System.Drawing.Color.White
		Me._optChoix_1.Size = New System.Drawing.Size(113, 17)
		Me._optChoix_1.Location = New System.Drawing.Point(16, 80)
		Me._optChoix_1.TabIndex = 7
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
		Me._optChoix_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoix_2.BackColor = System.Drawing.Color.Black
		Me._optChoix_2.Text = "Tous les clients facturés"
		Me._optChoix_2.ForeColor = System.Drawing.Color.White
		Me._optChoix_2.Size = New System.Drawing.Size(145, 17)
		Me._optChoix_2.Location = New System.Drawing.Point(136, 80)
		Me._optChoix_2.TabIndex = 6
		Me._optChoix_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoix_2.CausesValidation = True
		Me._optChoix_2.Enabled = True
		Me._optChoix_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChoix_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChoix_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optChoix_2.TabStop = True
		Me._optChoix_2.Checked = False
		Me._optChoix_2.Visible = True
		Me._optChoix_2.Name = "_optChoix_2"
		Me._optChoix_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoix_4.BackColor = System.Drawing.Color.Black
		Me._optChoix_4.Text = "Tous les membres du groupement des chefs d'entreprise"
		Me._optChoix_4.ForeColor = System.Drawing.Color.White
		Me._optChoix_4.Size = New System.Drawing.Size(257, 33)
		Me._optChoix_4.Location = New System.Drawing.Point(16, 112)
		Me._optChoix_4.TabIndex = 5
		Me._optChoix_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optChoix_4.CausesValidation = True
		Me._optChoix_4.Enabled = True
		Me._optChoix_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._optChoix_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optChoix_4.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optChoix_4.TabStop = True
		Me._optChoix_4.Checked = False
		Me._optChoix_4.Visible = True
		Me._optChoix_4.Name = "_optChoix_4"
		Me.pgb.Size = New System.Drawing.Size(601, 25)
		Me.pgb.Location = New System.Drawing.Point(24, 384)
		Me.pgb.TabIndex = 3
		Me.pgb.Name = "pgb"
		Me.txtPrefixe.AutoSize = False
		Me.txtPrefixe.Size = New System.Drawing.Size(257, 27)
		Me.txtPrefixe.Location = New System.Drawing.Point(280, 336)
		Me.txtPrefixe.TabIndex = 2
		Me.txtPrefixe.AcceptsReturn = True
		Me.txtPrefixe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPrefixe.BackColor = System.Drawing.SystemColors.Window
		Me.txtPrefixe.CausesValidation = True
		Me.txtPrefixe.Enabled = True
		Me.txtPrefixe.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPrefixe.HideSelection = True
		Me.txtPrefixe.ReadOnly = False
		Me.txtPrefixe.Maxlength = 0
		Me.txtPrefixe.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPrefixe.MultiLine = False
		Me.txtPrefixe.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPrefixe.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPrefixe.TabStop = True
		Me.txtPrefixe.Visible = True
		Me.txtPrefixe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPrefixe.Name = "txtPrefixe"
		Me.cmdCreer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCreer.Text = "Créer la liste"
		Me.cmdCreer.Size = New System.Drawing.Size(193, 33)
		Me.cmdCreer.Location = New System.Drawing.Point(224, 432)
		Me.cmdCreer.TabIndex = 0
		Me.cmdCreer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCreer.CausesValidation = True
		Me.cmdCreer.Enabled = True
		Me.cmdCreer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCreer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCreer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCreer.TabStop = True
		Me.cmdCreer.Name = "cmdCreer"
		Me.Label1.Text = "Préfixe de la liste de distribution :"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(249, 17)
		Me.Label1.Location = New System.Drawing.Point(24, 340)
		Me.Label1.TabIndex = 1
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
		Me.Controls.Add(cmdExceptions)
		Me.Controls.Add(fraChoixDossier)
		Me.Controls.Add(fraChoixListe)
		Me.Controls.Add(pgb)
		Me.Controls.Add(txtPrefixe)
		Me.Controls.Add(cmdCreer)
		Me.Controls.Add(Label1)
		Me.fraChoixDossier.Controls.Add(Picture1)
		Me.Picture1.Controls.Add(_optChoixDossier_2)
		Me.Picture1.Controls.Add(_optChoixDossier_1)
		Me.Picture1.Controls.Add(_optChoixDossier_0)
		Me.fraChoixListe.Controls.Add(_optChoix_5)
		Me.fraChoixListe.Controls.Add(_optChoix_3)
		Me.fraChoixListe.Controls.Add(_optChoix_0)
		Me.fraChoixListe.Controls.Add(_optChoix_1)
		Me.fraChoixListe.Controls.Add(_optChoix_2)
		Me.fraChoixListe.Controls.Add(_optChoix_4)
		Me.optChoix.SetIndex(_optChoix_5, CType(5, Short))
		Me.optChoix.SetIndex(_optChoix_3, CType(3, Short))
		Me.optChoix.SetIndex(_optChoix_0, CType(0, Short))
		Me.optChoix.SetIndex(_optChoix_1, CType(1, Short))
		Me.optChoix.SetIndex(_optChoix_2, CType(2, Short))
		Me.optChoix.SetIndex(_optChoix_4, CType(4, Short))
		Me.optChoixDossier.SetIndex(_optChoixDossier_2, CType(2, Short))
		Me.optChoixDossier.SetIndex(_optChoixDossier_1, CType(1, Short))
		Me.optChoixDossier.SetIndex(_optChoixDossier_0, CType(0, Short))
		CType(Me.optChoixDossier, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.optChoix, System.ComponentModel.ISupportInitialize).EndInit()
		Me.fraChoixDossier.ResumeLayout(False)
		Me.Picture1.ResumeLayout(False)
		Me.fraChoixListe.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class