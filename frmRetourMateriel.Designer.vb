<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRetourMateriel
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
	Public WithEvents cmdEnregistrer As System.Windows.Forms.Button
	Public WithEvents chkMecanique As System.Windows.Forms.CheckBox
	Public WithEvents cmbEmployé As System.Windows.Forms.ComboBox
	Public WithEvents txtQte As System.Windows.Forms.TextBox
	Public WithEvents _lvwRecherche_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwRecherche_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwRecherche_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwRecherche As System.Windows.Forms.ListView
	Public WithEvents txtRecherche As System.Windows.Forms.TextBox
	Public WithEvents cmbRecherche As System.Windows.Forms.ComboBox
	Public WithEvents cmdRechercher As System.Windows.Forms.Button
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents fraRecherche As System.Windows.Forms.GroupBox
	Public WithEvents txtNoItem As System.Windows.Forms.TextBox
	Public WithEvents mskNoProjet As System.Windows.Forms.MaskedTextBox
	Public WithEvents lblprojet As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents fraAjout As System.Windows.Forms.Panel
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRetourMateriel))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.cmdEnregistrer = New System.Windows.Forms.Button
		Me.fraAjout = New System.Windows.Forms.Panel
		Me.chkMecanique = New System.Windows.Forms.CheckBox
		Me.cmbEmployé = New System.Windows.Forms.ComboBox
		Me.txtQte = New System.Windows.Forms.TextBox
		Me.fraRecherche = New System.Windows.Forms.GroupBox
		Me.lvwRecherche = New System.Windows.Forms.ListView
		Me._lvwRecherche_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwRecherche_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwRecherche_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me.txtRecherche = New System.Windows.Forms.TextBox
		Me.cmbRecherche = New System.Windows.Forms.ComboBox
		Me.cmdRechercher = New System.Windows.Forms.Button
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.txtNoItem = New System.Windows.Forms.TextBox
		Me.mskNoProjet = New System.Windows.Forms.MaskedTextBox
		Me.lblprojet = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.fraAjout.SuspendLayout()
		Me.fraRecherche.SuspendLayout()
		Me.lvwRecherche.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Retour de matériel"
		Me.ClientSize = New System.Drawing.Size(550, 384)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmRetourMateriel.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "frmRetourMateriel"
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(81, 25)
		Me.cmdFermer.Location = New System.Drawing.Point(456, 352)
		Me.cmdFermer.TabIndex = 19
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.cmdEnregistrer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEnregistrer.Text = "Enregistrer"
		Me.cmdEnregistrer.Size = New System.Drawing.Size(81, 25)
		Me.cmdEnregistrer.Location = New System.Drawing.Point(368, 352)
		Me.cmdEnregistrer.TabIndex = 18
		Me.cmdEnregistrer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEnregistrer.CausesValidation = True
		Me.cmdEnregistrer.Enabled = True
		Me.cmdEnregistrer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEnregistrer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEnregistrer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEnregistrer.TabStop = True
		Me.cmdEnregistrer.Name = "cmdEnregistrer"
		Me.fraAjout.BackColor = System.Drawing.Color.Black
		Me.fraAjout.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.fraAjout.Text = "Frame1"
		Me.fraAjout.Size = New System.Drawing.Size(529, 273)
		Me.fraAjout.Location = New System.Drawing.Point(8, 72)
		Me.fraAjout.TabIndex = 0
		Me.fraAjout.Enabled = True
		Me.fraAjout.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraAjout.Cursor = System.Windows.Forms.Cursors.Default
		Me.fraAjout.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraAjout.Visible = True
		Me.fraAjout.Name = "fraAjout"
		Me.chkMecanique.BackColor = System.Drawing.Color.Black
		Me.chkMecanique.Text = "Mécanique"
		Me.chkMecanique.ForeColor = System.Drawing.Color.White
		Me.chkMecanique.Size = New System.Drawing.Size(105, 17)
		Me.chkMecanique.Location = New System.Drawing.Point(64, 168)
		Me.chkMecanique.TabIndex = 10
		Me.chkMecanique.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkMecanique.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkMecanique.CausesValidation = True
		Me.chkMecanique.Enabled = True
		Me.chkMecanique.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkMecanique.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkMecanique.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkMecanique.TabStop = True
		Me.chkMecanique.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkMecanique.Visible = True
		Me.chkMecanique.Name = "chkMecanique"
		Me.cmbEmployé.Size = New System.Drawing.Size(145, 21)
		Me.cmbEmployé.Location = New System.Drawing.Point(64, 16)
		Me.cmbEmployé.Sorted = True
		Me.cmbEmployé.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbEmployé.TabIndex = 2
		Me.cmbEmployé.BackColor = System.Drawing.SystemColors.Window
		Me.cmbEmployé.CausesValidation = True
		Me.cmbEmployé.Enabled = True
		Me.cmbEmployé.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbEmployé.IntegralHeight = True
		Me.cmbEmployé.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbEmployé.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbEmployé.TabStop = True
		Me.cmbEmployé.Visible = True
		Me.cmbEmployé.Name = "cmbEmployé"
		Me.txtQte.AutoSize = False
		Me.txtQte.Size = New System.Drawing.Size(65, 19)
		Me.txtQte.Location = New System.Drawing.Point(88, 112)
		Me.txtQte.TabIndex = 7
		Me.txtQte.AcceptsReturn = True
		Me.txtQte.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtQte.BackColor = System.Drawing.SystemColors.Window
		Me.txtQte.CausesValidation = True
		Me.txtQte.Enabled = True
		Me.txtQte.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtQte.HideSelection = True
		Me.txtQte.ReadOnly = False
		Me.txtQte.Maxlength = 0
		Me.txtQte.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtQte.MultiLine = False
		Me.txtQte.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtQte.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtQte.TabStop = True
		Me.txtQte.Visible = True
		Me.txtQte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtQte.Name = "txtQte"
		Me.fraRecherche.BackColor = System.Drawing.Color.Black
		Me.fraRecherche.Text = "Recherche"
		Me.fraRecherche.ForeColor = System.Drawing.Color.White
		Me.fraRecherche.Size = New System.Drawing.Size(353, 209)
		Me.fraRecherche.Location = New System.Drawing.Point(176, 56)
		Me.fraRecherche.TabIndex = 11
		Me.fraRecherche.Enabled = True
		Me.fraRecherche.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraRecherche.Visible = True
		Me.fraRecherche.Padding = New System.Windows.Forms.Padding(0)
		Me.fraRecherche.Name = "fraRecherche"
		Me.lvwRecherche.Size = New System.Drawing.Size(337, 129)
		Me.lvwRecherche.Location = New System.Drawing.Point(8, 72)
		Me.lvwRecherche.TabIndex = 17
		Me.lvwRecherche.View = System.Windows.Forms.View.Details
		Me.lvwRecherche.LabelEdit = False
		Me.lvwRecherche.LabelWrap = True
		Me.lvwRecherche.HideSelection = True
		Me.lvwRecherche.FullRowSelect = True
		Me.lvwRecherche.GridLines = True
		Me.lvwRecherche.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwRecherche.BackColor = System.Drawing.SystemColors.Window
		Me.lvwRecherche.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwRecherche.Name = "lvwRecherche"
		Me._lvwRecherche_ColumnHeader_1.Text = "No Item"
		Me._lvwRecherche_ColumnHeader_1.Width = 170
		Me._lvwRecherche_ColumnHeader_2.Text = "Description"
		Me._lvwRecherche_ColumnHeader_2.Width = 170
		Me._lvwRecherche_ColumnHeader_3.Text = "Manufacturier"
		Me._lvwRecherche_ColumnHeader_3.Width = 170
		Me.txtRecherche.AutoSize = False
		Me.txtRecherche.Size = New System.Drawing.Size(105, 19)
		Me.txtRecherche.Location = New System.Drawing.Point(8, 40)
		Me.txtRecherche.TabIndex = 14
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
		Me.cmbRecherche.Size = New System.Drawing.Size(89, 21)
		Me.cmbRecherche.Location = New System.Drawing.Point(144, 40)
		Me.cmbRecherche.Items.AddRange(New Object(){"No. Item", "Description", "Manufacturier"})
		Me.cmbRecherche.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbRecherche.TabIndex = 15
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
		Me.cmdRechercher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRechercher.Text = "Afficher"
		Me.cmdRechercher.Size = New System.Drawing.Size(81, 25)
		Me.cmdRechercher.Location = New System.Drawing.Point(264, 40)
		Me.cmdRechercher.TabIndex = 16
		Me.cmdRechercher.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercher.CausesValidation = True
		Me.cmdRechercher.Enabled = True
		Me.cmdRechercher.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercher.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercher.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercher.TabStop = True
		Me.cmdRechercher.Name = "cmdRechercher"
		Me.Label5.Text = "Texte à rechercher : "
		Me.Label5.ForeColor = System.Drawing.Color.White
		Me.Label5.Size = New System.Drawing.Size(105, 17)
		Me.Label5.Location = New System.Drawing.Point(8, 24)
		Me.Label5.TabIndex = 12
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
		Me.Label6.Text = "Rechercher dans : "
		Me.Label6.ForeColor = System.Drawing.Color.White
		Me.Label6.Size = New System.Drawing.Size(89, 17)
		Me.Label6.Location = New System.Drawing.Point(144, 24)
		Me.Label6.TabIndex = 13
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
		Me.txtNoItem.AutoSize = False
		Me.txtNoItem.Size = New System.Drawing.Size(89, 19)
		Me.txtNoItem.Location = New System.Drawing.Point(64, 80)
		Me.txtNoItem.TabIndex = 5
		Me.txtNoItem.AcceptsReturn = True
		Me.txtNoItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoItem.BackColor = System.Drawing.SystemColors.Window
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
		Me.mskNoProjet.AllowPromptAsInput = False
		Me.mskNoProjet.Size = New System.Drawing.Size(81, 17)
		Me.mskNoProjet.Location = New System.Drawing.Point(72, 144)
		Me.mskNoProjet.TabIndex = 9
		Me.mskNoProjet.MaxLength = 8
		Me.mskNoProjet.Mask = "#####-##"
		Me.mskNoProjet.PromptChar = "_"
		Me.mskNoProjet.Name = "mskNoProjet"
		Me.lblprojet.BackColor = System.Drawing.Color.Black
		Me.lblprojet.Text = "No. Projet :"
		Me.lblprojet.ForeColor = System.Drawing.Color.White
		Me.lblprojet.Size = New System.Drawing.Size(57, 17)
		Me.lblprojet.Location = New System.Drawing.Point(8, 144)
		Me.lblprojet.TabIndex = 8
		Me.lblprojet.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblprojet.Enabled = True
		Me.lblprojet.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblprojet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblprojet.UseMnemonic = True
		Me.lblprojet.Visible = True
		Me.lblprojet.AutoSize = False
		Me.lblprojet.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblprojet.Name = "lblprojet"
		Me.Label4.Text = "Employé : "
		Me.Label4.ForeColor = System.Drawing.Color.White
		Me.Label4.Size = New System.Drawing.Size(65, 17)
		Me.Label4.Location = New System.Drawing.Point(8, 16)
		Me.Label4.TabIndex = 1
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
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label3.Text = "---->"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(41, 17)
		Me.Label3.Location = New System.Drawing.Point(144, 80)
		Me.Label3.TabIndex = 4
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Enabled = True
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "Qté retournée :"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(73, 17)
		Me.Label2.Location = New System.Drawing.Point(8, 112)
		Me.Label2.TabIndex = 6
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
		Me.Label1.Text = "No. Item : "
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(65, 17)
		Me.Label1.Location = New System.Drawing.Point(8, 80)
		Me.Label1.TabIndex = 3
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
		Me.Controls.Add(cmdFermer)
		Me.Controls.Add(cmdEnregistrer)
		Me.Controls.Add(fraAjout)
		Me.fraAjout.Controls.Add(chkMecanique)
		Me.fraAjout.Controls.Add(cmbEmployé)
		Me.fraAjout.Controls.Add(txtQte)
		Me.fraAjout.Controls.Add(fraRecherche)
		Me.fraAjout.Controls.Add(txtNoItem)
		Me.fraAjout.Controls.Add(mskNoProjet)
		Me.fraAjout.Controls.Add(lblprojet)
		Me.fraAjout.Controls.Add(Label4)
		Me.fraAjout.Controls.Add(Label3)
		Me.fraAjout.Controls.Add(Label2)
		Me.fraAjout.Controls.Add(Label1)
		Me.fraRecherche.Controls.Add(lvwRecherche)
		Me.fraRecherche.Controls.Add(txtRecherche)
		Me.fraRecherche.Controls.Add(cmbRecherche)
		Me.fraRecherche.Controls.Add(cmdRechercher)
		Me.fraRecherche.Controls.Add(Label5)
		Me.fraRecherche.Controls.Add(Label6)
		Me.lvwRecherche.Columns.Add(_lvwRecherche_ColumnHeader_1)
		Me.lvwRecherche.Columns.Add(_lvwRecherche_ColumnHeader_2)
		Me.lvwRecherche.Columns.Add(_lvwRecherche_ColumnHeader_3)
		Me.fraAjout.ResumeLayout(False)
		Me.fraRecherche.ResumeLayout(False)
		Me.lvwRecherche.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class