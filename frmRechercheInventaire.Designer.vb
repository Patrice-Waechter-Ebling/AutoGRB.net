<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRechercheInventaire
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
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	Public WithEvents cmbCategorie As System.Windows.Forms.ComboBox
	Public WithEvents cmdAfficher As System.Windows.Forms.Button
	Public WithEvents cmbRecherche As System.Windows.Forms.ComboBox
	Public WithEvents txtRecherche As System.Windows.Forms.TextBox
	Public WithEvents _lvwInventaire_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwInventaire_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwInventaire_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwInventaire_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwInventaire_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwInventaire_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwInventaire_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwInventaire_ColumnHeader_8 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwInventaire_ColumnHeader_9 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwInventaire_ColumnHeader_10 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwInventaire As System.Windows.Forms.ListView
	Public WithEvents lblTotal As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents lblTitreRecherche As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRechercheInventaire))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.cmbCategorie = New System.Windows.Forms.ComboBox
		Me.cmdAfficher = New System.Windows.Forms.Button
		Me.cmbRecherche = New System.Windows.Forms.ComboBox
		Me.txtRecherche = New System.Windows.Forms.TextBox
		Me.lvwInventaire = New System.Windows.Forms.ListView
		Me._lvwInventaire_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwInventaire_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwInventaire_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwInventaire_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwInventaire_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvwInventaire_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me._lvwInventaire_ColumnHeader_7 = New System.Windows.Forms.ColumnHeader
		Me._lvwInventaire_ColumnHeader_8 = New System.Windows.Forms.ColumnHeader
		Me._lvwInventaire_ColumnHeader_9 = New System.Windows.Forms.ColumnHeader
		Me._lvwInventaire_ColumnHeader_10 = New System.Windows.Forms.ColumnHeader
		Me.lblTotal = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.lblTitreRecherche = New System.Windows.Forms.Label
		Me.lvwInventaire.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Recherche d'inventaire"
		Me.ClientSize = New System.Drawing.Size(617, 437)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmRechercheInventaire.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "frmRechercheInventaire"
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(89, 25)
		Me.cmdFermer.Location = New System.Drawing.Point(520, 408)
		Me.cmdFermer.TabIndex = 9
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.cmbCategorie.Size = New System.Drawing.Size(257, 21)
		Me.cmbCategorie.Location = New System.Drawing.Point(96, 72)
		Me.cmbCategorie.Sorted = True
		Me.cmbCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbCategorie.TabIndex = 3
		Me.cmbCategorie.BackColor = System.Drawing.SystemColors.Window
		Me.cmbCategorie.CausesValidation = True
		Me.cmbCategorie.Enabled = True
		Me.cmbCategorie.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbCategorie.IntegralHeight = True
		Me.cmbCategorie.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbCategorie.TabStop = True
		Me.cmbCategorie.Visible = True
		Me.cmbCategorie.Name = "cmbCategorie"
		Me.cmdAfficher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAfficher.Text = "Afficher"
		Me.AcceptButton = Me.cmdAfficher
		Me.cmdAfficher.Size = New System.Drawing.Size(89, 25)
		Me.cmdAfficher.Location = New System.Drawing.Point(512, 68)
		Me.cmdAfficher.TabIndex = 2
		Me.cmdAfficher.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAfficher.CausesValidation = True
		Me.cmdAfficher.Enabled = True
		Me.cmdAfficher.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAfficher.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAfficher.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAfficher.TabStop = True
		Me.cmdAfficher.Name = "cmdAfficher"
		Me.cmbRecherche.Size = New System.Drawing.Size(129, 21)
		Me.cmbRecherche.Location = New System.Drawing.Point(368, 72)
		Me.cmbRecherche.Items.AddRange(New Object(){"No.Item", "Fabricant", "Description", "Categorie"})
		Me.cmbRecherche.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbRecherche.TabIndex = 5
		Me.cmbRecherche.BackColor = System.Drawing.SystemColors.Window
		Me.cmbRecherche.CausesValidation = True
		Me.cmbRecherche.Enabled = True
		Me.cmbRecherche.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbRecherche.IntegralHeight = True
		Me.cmbRecherche.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbRecherche.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbRecherche.Sorted = False
		Me.cmbRecherche.TabStop = True
		Me.cmbRecherche.Visible = True
		Me.cmbRecherche.Name = "cmbRecherche"
		Me.txtRecherche.AutoSize = False
		Me.txtRecherche.Size = New System.Drawing.Size(257, 21)
		Me.txtRecherche.Location = New System.Drawing.Point(96, 72)
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
		Me.lvwInventaire.Size = New System.Drawing.Size(601, 281)
		Me.lvwInventaire.Location = New System.Drawing.Point(8, 96)
		Me.lvwInventaire.TabIndex = 6
		Me.lvwInventaire.View = System.Windows.Forms.View.Details
		Me.lvwInventaire.LabelEdit = False
		Me.lvwInventaire.LabelWrap = True
		Me.lvwInventaire.HideSelection = True
		Me.lvwInventaire.FullRowSelect = True
		Me.lvwInventaire.GridLines = True
		Me.lvwInventaire.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwInventaire.BackColor = System.Drawing.SystemColors.Window
		Me.lvwInventaire.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwInventaire.Name = "lvwInventaire"
		Me._lvwInventaire_ColumnHeader_1.Text = "Qté"
		Me._lvwInventaire_ColumnHeader_1.Width = 170
		Me._lvwInventaire_ColumnHeader_2.Text = "No.Item"
		Me._lvwInventaire_ColumnHeader_2.Width = 170
		Me._lvwInventaire_ColumnHeader_3.Text = "Fabricant"
		Me._lvwInventaire_ColumnHeader_3.Width = 170
		Me._lvwInventaire_ColumnHeader_4.Text = "Description"
		Me._lvwInventaire_ColumnHeader_4.Width = 170
		Me._lvwInventaire_ColumnHeader_5.Text = "Catégorie"
		Me._lvwInventaire_ColumnHeader_5.Width = 170
		Me._lvwInventaire_ColumnHeader_6.Text = "Localisation"
		Me._lvwInventaire_ColumnHeader_6.Width = 170
		Me._lvwInventaire_ColumnHeader_7.Text = "Prix listé"
		Me._lvwInventaire_ColumnHeader_7.Width = 170
		Me._lvwInventaire_ColumnHeader_8.Text = "Escompte"
		Me._lvwInventaire_ColumnHeader_8.Width = 170
		Me._lvwInventaire_ColumnHeader_9.Text = "Prix net"
		Me._lvwInventaire_ColumnHeader_9.Width = 170
		Me._lvwInventaire_ColumnHeader_10.Text = "Total"
		Me._lvwInventaire_ColumnHeader_10.Width = 170
		Me.lblTotal.BackColor = System.Drawing.Color.White
		Me.lblTotal.ForeColor = System.Drawing.Color.Black
		Me.lblTotal.Size = New System.Drawing.Size(65, 17)
		Me.lblTotal.Location = New System.Drawing.Point(544, 384)
		Me.lblTotal.TabIndex = 8
		Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTotal.Enabled = True
		Me.lblTotal.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTotal.UseMnemonic = True
		Me.lblTotal.Visible = True
		Me.lblTotal.AutoSize = False
		Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotal.Name = "lblTotal"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label3.Text = "TOTAL  :"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(105, 17)
		Me.Label3.Location = New System.Drawing.Point(432, 384)
		Me.Label3.TabIndex = 7
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Enabled = True
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "Rechercher dans :"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(105, 17)
		Me.Label2.Location = New System.Drawing.Point(368, 56)
		Me.Label2.TabIndex = 1
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
		Me.lblTitreRecherche.Text = "Texte à rechercher :"
		Me.lblTitreRecherche.ForeColor = System.Drawing.Color.White
		Me.lblTitreRecherche.Size = New System.Drawing.Size(129, 17)
		Me.lblTitreRecherche.Location = New System.Drawing.Point(96, 56)
		Me.lblTitreRecherche.TabIndex = 0
		Me.lblTitreRecherche.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTitreRecherche.BackColor = System.Drawing.Color.Transparent
		Me.lblTitreRecherche.Enabled = True
		Me.lblTitreRecherche.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTitreRecherche.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTitreRecherche.UseMnemonic = True
		Me.lblTitreRecherche.Visible = True
		Me.lblTitreRecherche.AutoSize = False
		Me.lblTitreRecherche.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTitreRecherche.Name = "lblTitreRecherche"
		Me.Controls.Add(cmdFermer)
		Me.Controls.Add(cmbCategorie)
		Me.Controls.Add(cmdAfficher)
		Me.Controls.Add(cmbRecherche)
		Me.Controls.Add(txtRecherche)
		Me.Controls.Add(lvwInventaire)
		Me.Controls.Add(lblTotal)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(lblTitreRecherche)
		Me.lvwInventaire.Columns.Add(_lvwInventaire_ColumnHeader_1)
		Me.lvwInventaire.Columns.Add(_lvwInventaire_ColumnHeader_2)
		Me.lvwInventaire.Columns.Add(_lvwInventaire_ColumnHeader_3)
		Me.lvwInventaire.Columns.Add(_lvwInventaire_ColumnHeader_4)
		Me.lvwInventaire.Columns.Add(_lvwInventaire_ColumnHeader_5)
		Me.lvwInventaire.Columns.Add(_lvwInventaire_ColumnHeader_6)
		Me.lvwInventaire.Columns.Add(_lvwInventaire_ColumnHeader_7)
		Me.lvwInventaire.Columns.Add(_lvwInventaire_ColumnHeader_8)
		Me.lvwInventaire.Columns.Add(_lvwInventaire_ColumnHeader_9)
		Me.lvwInventaire.Columns.Add(_lvwInventaire_ColumnHeader_10)
		Me.lvwInventaire.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class