<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FrmaddItemMec
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
	Public WithEvents cmbcategorie As System.Windows.Forms.ComboBox
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents txtNoItem As System.Windows.Forms.TextBox
	Public WithEvents cmbFabricant As System.Windows.Forms.ComboBox
	Public WithEvents lblStainless As System.Windows.Forms.Label
	Public WithEvents lblAluminium As System.Windows.Forms.Label
	Public WithEvents lblPlastique As System.Windows.Forms.Label
	Public WithEvents lblAcier As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents lblTitre As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmaddItemMec))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmbcategorie = New System.Windows.Forms.ComboBox
		Me.cmdOk = New System.Windows.Forms.Button
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.txtNoItem = New System.Windows.Forms.TextBox
		Me.cmbFabricant = New System.Windows.Forms.ComboBox
		Me.lblStainless = New System.Windows.Forms.Label
		Me.lblAluminium = New System.Windows.Forms.Label
		Me.lblPlastique = New System.Windows.Forms.Label
		Me.lblAcier = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.lblTitre = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "."
		Me.ClientSize = New System.Drawing.Size(387, 298)
		Me.Location = New System.Drawing.Point(238, 216)
		Me.ControlBox = False
		Me.Icon = CType(resources.GetObject("FrmaddItemMec.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("FrmaddItemMec.BackgroundImage"), System.Drawing.Image)
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "FrmaddItemMec"
		Me.cmbcategorie.BackColor = System.Drawing.Color.White
		Me.cmbcategorie.Size = New System.Drawing.Size(265, 21)
		Me.cmbcategorie.Location = New System.Drawing.Point(104, 200)
		Me.cmbcategorie.TabIndex = 0
		Me.cmbcategorie.CausesValidation = True
		Me.cmbcategorie.Enabled = True
		Me.cmbcategorie.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbcategorie.IntegralHeight = True
		Me.cmbcategorie.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbcategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbcategorie.Sorted = False
		Me.cmbcategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbcategorie.TabStop = True
		Me.cmbcategorie.Visible = True
		Me.cmbcategorie.Name = "cmbcategorie"
		Me.cmdOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOk.Text = "OK"
		Me.AcceptButton = Me.cmdOk
		Me.cmdOk.Size = New System.Drawing.Size(81, 25)
		Me.cmdOk.Location = New System.Drawing.Point(288, 232)
		Me.cmdOk.TabIndex = 3
		Me.cmdOk.CausesValidation = True
		Me.cmdOk.Enabled = True
		Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOk.TabStop = True
		Me.cmdOk.Name = "cmdOk"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(81, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(288, 264)
		Me.cmdAnnuler.TabIndex = 4
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.txtNoItem.AutoSize = False
		Me.txtNoItem.BackColor = System.Drawing.Color.White
		Me.txtNoItem.Size = New System.Drawing.Size(161, 20)
		Me.txtNoItem.Location = New System.Drawing.Point(104, 232)
		Me.txtNoItem.TabIndex = 1
		Me.txtNoItem.AcceptsReturn = True
		Me.txtNoItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoItem.CausesValidation = True
		Me.txtNoItem.Enabled = True
		Me.txtNoItem.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNoItem.HideSelection = True
		Me.txtNoItem.ReadOnly = False
		Me.txtNoItem.Maxlength = 0
		Me.txtNoItem.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNoItem.MultiLine = False
		Me.txtNoItem.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNoItem.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNoItem.TabStop = True
		Me.txtNoItem.Visible = True
		Me.txtNoItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoItem.Name = "txtNoItem"
		Me.cmbFabricant.BackColor = System.Drawing.Color.White
		Me.cmbFabricant.Size = New System.Drawing.Size(161, 21)
		Me.cmbFabricant.Location = New System.Drawing.Point(104, 264)
		Me.cmbFabricant.TabIndex = 2
		Me.cmbFabricant.CausesValidation = True
		Me.cmbFabricant.Enabled = True
		Me.cmbFabricant.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbFabricant.IntegralHeight = True
		Me.cmbFabricant.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbFabricant.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbFabricant.Sorted = False
		Me.cmbFabricant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbFabricant.TabStop = True
		Me.cmbFabricant.Visible = True
		Me.cmbFabricant.Name = "cmbFabricant"
		Me.lblStainless.Text = "STAINLESS : "
		Me.lblStainless.ForeColor = System.Drawing.Color.White
		Me.lblStainless.Size = New System.Drawing.Size(121, 17)
		Me.lblStainless.Location = New System.Drawing.Point(152, 144)
		Me.lblStainless.TabIndex = 9
		Me.lblStainless.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblStainless.BackColor = System.Drawing.Color.Transparent
		Me.lblStainless.Enabled = True
		Me.lblStainless.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblStainless.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblStainless.UseMnemonic = True
		Me.lblStainless.Visible = True
		Me.lblStainless.AutoSize = False
		Me.lblStainless.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblStainless.Name = "lblStainless"
		Me.lblAluminium.Text = "ALUMINIUM : "
		Me.lblAluminium.ForeColor = System.Drawing.Color.White
		Me.lblAluminium.Size = New System.Drawing.Size(121, 17)
		Me.lblAluminium.Location = New System.Drawing.Point(152, 160)
		Me.lblAluminium.TabIndex = 10
		Me.lblAluminium.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblAluminium.BackColor = System.Drawing.Color.Transparent
		Me.lblAluminium.Enabled = True
		Me.lblAluminium.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblAluminium.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblAluminium.UseMnemonic = True
		Me.lblAluminium.Visible = True
		Me.lblAluminium.AutoSize = False
		Me.lblAluminium.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblAluminium.Name = "lblAluminium"
		Me.lblPlastique.Text = "PLASTIQUE : "
		Me.lblPlastique.ForeColor = System.Drawing.Color.White
		Me.lblPlastique.Size = New System.Drawing.Size(121, 17)
		Me.lblPlastique.Location = New System.Drawing.Point(152, 128)
		Me.lblPlastique.TabIndex = 8
		Me.lblPlastique.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPlastique.BackColor = System.Drawing.Color.Transparent
		Me.lblPlastique.Enabled = True
		Me.lblPlastique.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPlastique.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPlastique.UseMnemonic = True
		Me.lblPlastique.Visible = True
		Me.lblPlastique.AutoSize = False
		Me.lblPlastique.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPlastique.Name = "lblPlastique"
		Me.lblAcier.Text = "ACIER : "
		Me.lblAcier.ForeColor = System.Drawing.Color.White
		Me.lblAcier.Size = New System.Drawing.Size(121, 17)
		Me.lblAcier.Location = New System.Drawing.Point(152, 112)
		Me.lblAcier.TabIndex = 7
		Me.lblAcier.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblAcier.BackColor = System.Drawing.Color.Transparent
		Me.lblAcier.Enabled = True
		Me.lblAcier.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblAcier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblAcier.UseMnemonic = True
		Me.lblAcier.Visible = True
		Me.lblAcier.AutoSize = False
		Me.lblAcier.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblAcier.Name = "lblAcier"
		Me.Label1.Text = "Prochain numéro pour :"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(121, 17)
		Me.Label1.Location = New System.Drawing.Point(32, 112)
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
		Me.Label4.Text = "Catégorie :"
		Me.Label4.ForeColor = System.Drawing.Color.White
		Me.Label4.Size = New System.Drawing.Size(97, 17)
		Me.Label4.Location = New System.Drawing.Point(8, 200)
		Me.Label4.TabIndex = 11
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
		Me.Label2.Text = "Numero d'item :"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(97, 17)
		Me.Label2.Location = New System.Drawing.Point(8, 232)
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
		Me.Label3.Text = "Manufacturier :"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(97, 17)
		Me.Label3.Location = New System.Drawing.Point(8, 264)
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
		Me.lblTitre.Text = "Veuillez entrez la catégorie, un numero d'item et ensuite un manufacturier (vous pouvez en ajouter un qui ne figure pas déjà dans la liste)"
		Me.lblTitre.ForeColor = System.Drawing.Color.White
		Me.lblTitre.Size = New System.Drawing.Size(361, 49)
		Me.lblTitre.Location = New System.Drawing.Point(8, 64)
		Me.lblTitre.TabIndex = 5
		Me.lblTitre.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTitre.BackColor = System.Drawing.Color.Transparent
		Me.lblTitre.Enabled = True
		Me.lblTitre.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTitre.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTitre.UseMnemonic = True
		Me.lblTitre.Visible = True
		Me.lblTitre.AutoSize = False
		Me.lblTitre.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTitre.Name = "lblTitre"
		Me.Controls.Add(cmbcategorie)
		Me.Controls.Add(cmdOk)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(txtNoItem)
		Me.Controls.Add(cmbFabricant)
		Me.Controls.Add(lblStainless)
		Me.Controls.Add(lblAluminium)
		Me.Controls.Add(lblPlastique)
		Me.Controls.Add(lblAcier)
		Me.Controls.Add(Label1)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label3)
		Me.Controls.Add(lblTitre)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class