<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixDemande
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
	Public WithEvents _lvwCategorie_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwCategorie As System.Windows.Forms.ListView
	Public WithEvents _lvwPiece_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPiece_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPiece_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPiece_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPiece_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwPiece As System.Windows.Forms.ListView
	Public WithEvents cmdDeselectAll As System.Windows.Forms.Button
	Public WithEvents cmdSelectAll As System.Windows.Forms.Button
	Public WithEvents cmbTri As System.Windows.Forms.ComboBox
	Public WithEvents cmdRechercher As System.Windows.Forms.Button
	Public WithEvents txtRechercher As System.Windows.Forms.TextBox
	Public WithEvents cmdRafraichir As System.Windows.Forms.Button
	Public WithEvents cmdTri As System.Windows.Forms.Button
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	Public WithEvents txtCommentaire As System.Windows.Forms.TextBox
	Public WithEvents txtNoGRB As System.Windows.Forms.TextBox
	Public WithEvents mskDateRequise As System.Windows.Forms.MaskedTextBox
	Public WithEvents cmdLangage As System.Windows.Forms.Button
	Public WithEvents cmbCategorie As System.Windows.Forms.ComboBox
	Public WithEvents cmdImprimer As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents cmbManufacturier As System.Windows.Forms.ComboBox
	Public WithEvents txtNoPiece As System.Windows.Forms.TextBox
	Public WithEvents txtDescription As System.Windows.Forms.TextBox
	Public WithEvents cmdAjouter As System.Windows.Forms.Button
	Public WithEvents _lvwManufacturier_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwManufacturier As System.Windows.Forms.ListView
	Public WithEvents _lvwNouvellesPieces_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwNouvellesPieces_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwNouvellesPieces_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwNouvellesPieces_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwNouvellesPieces_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwNouvellesPieces As System.Windows.Forms.ListView
	Public WithEvents _lvwFournisseur_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwFournisseur As System.Windows.Forms.ListView
	Public WithEvents lblFormatDate As System.Windows.Forms.Label
	Public WithEvents lblDescription As System.Windows.Forms.Label
	Public WithEvents lblManufacturier As System.Windows.Forms.Label
	Public WithEvents lblNoPiece As System.Windows.Forms.Label
	Public WithEvents lblCommentaire As System.Windows.Forms.Label
	Public WithEvents lblNoGRB As System.Windows.Forms.Label
	Public WithEvents lblDateRequise As System.Windows.Forms.Label
	Public WithEvents lblCategorie As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixDemande))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.lvwCategorie = New System.Windows.Forms.ListView
		Me._lvwCategorie_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.lvwPiece = New System.Windows.Forms.ListView
		Me._lvwPiece_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwPiece_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwPiece_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwPiece_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwPiece_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me.cmdDeselectAll = New System.Windows.Forms.Button
		Me.cmdSelectAll = New System.Windows.Forms.Button
		Me.cmbTri = New System.Windows.Forms.ComboBox
		Me.cmdRechercher = New System.Windows.Forms.Button
		Me.txtRechercher = New System.Windows.Forms.TextBox
		Me.cmdRafraichir = New System.Windows.Forms.Button
		Me.cmdTri = New System.Windows.Forms.Button
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.txtCommentaire = New System.Windows.Forms.TextBox
		Me.txtNoGRB = New System.Windows.Forms.TextBox
		Me.mskDateRequise = New System.Windows.Forms.MaskedTextBox
		Me.cmdLangage = New System.Windows.Forms.Button
		Me.cmbCategorie = New System.Windows.Forms.ComboBox
		Me.cmdImprimer = New System.Windows.Forms.Button
		Me.cmdOK = New System.Windows.Forms.Button
		Me.cmbManufacturier = New System.Windows.Forms.ComboBox
		Me.txtNoPiece = New System.Windows.Forms.TextBox
		Me.txtDescription = New System.Windows.Forms.TextBox
		Me.cmdAjouter = New System.Windows.Forms.Button
		Me.lvwManufacturier = New System.Windows.Forms.ListView
		Me._lvwManufacturier_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.lvwNouvellesPieces = New System.Windows.Forms.ListView
		Me._lvwNouvellesPieces_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwNouvellesPieces_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwNouvellesPieces_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwNouvellesPieces_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwNouvellesPieces_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me.lvwFournisseur = New System.Windows.Forms.ListView
		Me._lvwFournisseur_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me.lblFormatDate = New System.Windows.Forms.Label
		Me.lblDescription = New System.Windows.Forms.Label
		Me.lblManufacturier = New System.Windows.Forms.Label
		Me.lblNoPiece = New System.Windows.Forms.Label
		Me.lblCommentaire = New System.Windows.Forms.Label
		Me.lblNoGRB = New System.Windows.Forms.Label
		Me.lblDateRequise = New System.Windows.Forms.Label
		Me.lblCategorie = New System.Windows.Forms.Label
		Me.lvwCategorie.SuspendLayout()
		Me.lvwPiece.SuspendLayout()
		Me.lvwManufacturier.SuspendLayout()
		Me.lvwNouvellesPieces.SuspendLayout()
		Me.lvwFournisseur.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Demande de prix"
		Me.ClientSize = New System.Drawing.Size(584, 432)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixDemande.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "frmChoixDemande"
		Me.lvwCategorie.Size = New System.Drawing.Size(569, 289)
		Me.lvwCategorie.Location = New System.Drawing.Point(8, 48)
		Me.lvwCategorie.TabIndex = 6
		Me.lvwCategorie.View = System.Windows.Forms.View.Details
		Me.lvwCategorie.LabelEdit = False
		Me.lvwCategorie.LabelWrap = True
		Me.lvwCategorie.HideSelection = True
		Me.lvwCategorie.Checkboxes = True
		Me.lvwCategorie.FullRowSelect = True
		Me.lvwCategorie.GridLines = True
		Me.lvwCategorie.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwCategorie.BackColor = System.Drawing.SystemColors.Window
		Me.lvwCategorie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwCategorie.Name = "lvwCategorie"
		Me._lvwCategorie_ColumnHeader_1.Text = "Catégorie"
		Me._lvwCategorie_ColumnHeader_1.Width = 821
		Me.lvwPiece.Size = New System.Drawing.Size(569, 265)
		Me.lvwPiece.Location = New System.Drawing.Point(8, 72)
		Me.lvwPiece.TabIndex = 13
		Me.lvwPiece.View = System.Windows.Forms.View.Details
		Me.lvwPiece.LabelEdit = False
		Me.lvwPiece.LabelWrap = True
		Me.lvwPiece.HideSelection = True
		Me.lvwPiece.Checkboxes = True
		Me.lvwPiece.FullRowSelect = True
		Me.lvwPiece.GridLines = True
		Me.lvwPiece.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwPiece.BackColor = System.Drawing.SystemColors.Window
		Me.lvwPiece.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwPiece.Name = "lvwPiece"
		Me._lvwPiece_ColumnHeader_1.Text = "Quantité"
		Me._lvwPiece_ColumnHeader_1.Width = 170
		Me._lvwPiece_ColumnHeader_2.Text = "Pièce"
		Me._lvwPiece_ColumnHeader_2.Width = 170
		Me._lvwPiece_ColumnHeader_3.Text = "Description française"
		Me._lvwPiece_ColumnHeader_3.Width = 170
		Me._lvwPiece_ColumnHeader_4.Text = "Description anglaise"
		Me._lvwPiece_ColumnHeader_4.Width = 170
		Me._lvwPiece_ColumnHeader_5.Text = "Fabricant"
		Me._lvwPiece_ColumnHeader_5.Width = 170
		Me.cmdDeselectAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDeselectAll.Text = "Aucun"
		Me.cmdDeselectAll.Size = New System.Drawing.Size(49, 25)
		Me.cmdDeselectAll.Location = New System.Drawing.Point(64, 344)
		Me.cmdDeselectAll.TabIndex = 20
		Me.cmdDeselectAll.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDeselectAll.CausesValidation = True
		Me.cmdDeselectAll.Enabled = True
		Me.cmdDeselectAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDeselectAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDeselectAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDeselectAll.TabStop = True
		Me.cmdDeselectAll.Name = "cmdDeselectAll"
		Me.cmdSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSelectAll.Text = "Tous"
		Me.cmdSelectAll.Size = New System.Drawing.Size(49, 25)
		Me.cmdSelectAll.Location = New System.Drawing.Point(8, 344)
		Me.cmdSelectAll.TabIndex = 19
		Me.cmdSelectAll.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSelectAll.CausesValidation = True
		Me.cmdSelectAll.Enabled = True
		Me.cmdSelectAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSelectAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSelectAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSelectAll.TabStop = True
		Me.cmdSelectAll.Name = "cmdSelectAll"
		Me.cmbTri.Size = New System.Drawing.Size(129, 21)
		Me.cmbTri.Location = New System.Drawing.Point(296, 48)
		Me.cmbTri.Items.AddRange(New Object(){"Pièce", "Desc. Fr", "Desc. An", "Fabricant"})
		Me.cmbTri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbTri.TabIndex = 4
		Me.cmbTri.BackColor = System.Drawing.SystemColors.Window
		Me.cmbTri.CausesValidation = True
		Me.cmbTri.Enabled = True
		Me.cmbTri.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbTri.IntegralHeight = True
		Me.cmbTri.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbTri.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbTri.Sorted = False
		Me.cmbTri.TabStop = True
		Me.cmbTri.Visible = True
		Me.cmbTri.Name = "cmbTri"
		Me.cmdRechercher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRechercher.Text = "Rechercher"
		Me.cmdRechercher.Size = New System.Drawing.Size(73, 25)
		Me.cmdRechercher.Location = New System.Drawing.Point(504, 20)
		Me.cmdRechercher.TabIndex = 1
		Me.cmdRechercher.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercher.CausesValidation = True
		Me.cmdRechercher.Enabled = True
		Me.cmdRechercher.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercher.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercher.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercher.TabStop = True
		Me.cmdRechercher.Name = "cmdRechercher"
		Me.txtRechercher.AutoSize = False
		Me.txtRechercher.Size = New System.Drawing.Size(121, 19)
		Me.txtRechercher.Location = New System.Drawing.Point(376, 24)
		Me.txtRechercher.TabIndex = 3
		Me.txtRechercher.AcceptsReturn = True
		Me.txtRechercher.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtRechercher.BackColor = System.Drawing.SystemColors.Window
		Me.txtRechercher.CausesValidation = True
		Me.txtRechercher.Enabled = True
		Me.txtRechercher.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtRechercher.HideSelection = True
		Me.txtRechercher.ReadOnly = False
		Me.txtRechercher.Maxlength = 0
		Me.txtRechercher.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtRechercher.MultiLine = False
		Me.txtRechercher.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtRechercher.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtRechercher.TabStop = True
		Me.txtRechercher.Visible = True
		Me.txtRechercher.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtRechercher.Name = "txtRechercher"
		Me.cmdRafraichir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRafraichir.Text = "Rafraichir"
		Me.cmdRafraichir.Size = New System.Drawing.Size(65, 21)
		Me.cmdRafraichir.Location = New System.Drawing.Point(512, 48)
		Me.cmdRafraichir.TabIndex = 7
		Me.cmdRafraichir.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRafraichir.CausesValidation = True
		Me.cmdRafraichir.Enabled = True
		Me.cmdRafraichir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRafraichir.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRafraichir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRafraichir.TabStop = True
		Me.cmdRafraichir.Name = "cmdRafraichir"
		Me.cmdTri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdTri.Text = "Trier"
		Me.cmdTri.Size = New System.Drawing.Size(65, 21)
		Me.cmdTri.Location = New System.Drawing.Point(440, 48)
		Me.cmdTri.TabIndex = 5
		Me.cmdTri.BackColor = System.Drawing.SystemColors.Control
		Me.cmdTri.CausesValidation = True
		Me.cmdTri.Enabled = True
		Me.cmdTri.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdTri.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdTri.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdTri.TabStop = True
		Me.cmdTri.Name = "cmdTri"
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(73, 25)
		Me.cmdFermer.Location = New System.Drawing.Point(504, 400)
		Me.cmdFermer.TabIndex = 31
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.txtCommentaire.AutoSize = False
		Me.txtCommentaire.Size = New System.Drawing.Size(313, 33)
		Me.txtCommentaire.Location = New System.Drawing.Point(104, 392)
		Me.txtCommentaire.MultiLine = True
		Me.txtCommentaire.TabIndex = 29
		Me.txtCommentaire.AcceptsReturn = True
		Me.txtCommentaire.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCommentaire.BackColor = System.Drawing.SystemColors.Window
		Me.txtCommentaire.CausesValidation = True
		Me.txtCommentaire.Enabled = True
		Me.txtCommentaire.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCommentaire.HideSelection = True
		Me.txtCommentaire.ReadOnly = False
		Me.txtCommentaire.Maxlength = 0
		Me.txtCommentaire.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCommentaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCommentaire.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCommentaire.TabStop = True
		Me.txtCommentaire.Visible = True
		Me.txtCommentaire.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCommentaire.Name = "txtCommentaire"
		Me.txtNoGRB.AutoSize = False
		Me.txtNoGRB.Size = New System.Drawing.Size(81, 19)
		Me.txtNoGRB.Location = New System.Drawing.Point(336, 368)
		Me.txtNoGRB.TabIndex = 27
		Me.txtNoGRB.AcceptsReturn = True
		Me.txtNoGRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoGRB.BackColor = System.Drawing.SystemColors.Window
		Me.txtNoGRB.CausesValidation = True
		Me.txtNoGRB.Enabled = True
		Me.txtNoGRB.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNoGRB.HideSelection = True
		Me.txtNoGRB.ReadOnly = False
		Me.txtNoGRB.Maxlength = 0
		Me.txtNoGRB.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNoGRB.MultiLine = False
		Me.txtNoGRB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNoGRB.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNoGRB.TabStop = True
		Me.txtNoGRB.Visible = True
		Me.txtNoGRB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoGRB.Name = "txtNoGRB"
		Me.mskDateRequise.AllowPromptAsInput = False
		Me.mskDateRequise.Size = New System.Drawing.Size(81, 17)
		Me.mskDateRequise.Location = New System.Drawing.Point(336, 344)
		Me.mskDateRequise.TabIndex = 23
		Me.mskDateRequise.PromptChar = "_"
		Me.mskDateRequise.Name = "mskDateRequise"
		Me.cmdLangage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdLangage.Text = "En anglais"
		Me.cmdLangage.Size = New System.Drawing.Size(89, 25)
		Me.cmdLangage.Location = New System.Drawing.Point(152, 344)
		Me.cmdLangage.TabIndex = 21
		Me.cmdLangage.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLangage.CausesValidation = True
		Me.cmdLangage.Enabled = True
		Me.cmdLangage.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLangage.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLangage.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLangage.TabStop = True
		Me.cmdLangage.Name = "cmdLangage"
		Me.cmbCategorie.Size = New System.Drawing.Size(281, 21)
		Me.cmbCategorie.Location = New System.Drawing.Point(296, 24)
		Me.cmbCategorie.TabIndex = 2
		Me.cmbCategorie.Text = "cmbCategorie"
		Me.cmbCategorie.BackColor = System.Drawing.SystemColors.Window
		Me.cmbCategorie.CausesValidation = True
		Me.cmbCategorie.Enabled = True
		Me.cmbCategorie.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbCategorie.IntegralHeight = True
		Me.cmbCategorie.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbCategorie.Sorted = False
		Me.cmbCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbCategorie.TabStop = True
		Me.cmbCategorie.Visible = True
		Me.cmbCategorie.Name = "cmbCategorie"
		Me.cmdImprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdImprimer.Text = "Imprimer"
		Me.cmdImprimer.Size = New System.Drawing.Size(73, 25)
		Me.cmdImprimer.Location = New System.Drawing.Point(424, 400)
		Me.cmdImprimer.TabIndex = 30
		Me.cmdImprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdImprimer.CausesValidation = True
		Me.cmdImprimer.Enabled = True
		Me.cmdImprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdImprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdImprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdImprimer.TabStop = True
		Me.cmdImprimer.Name = "cmdImprimer"
		Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOK.Text = "OK"
		Me.cmdOK.Size = New System.Drawing.Size(73, 25)
		Me.cmdOK.Location = New System.Drawing.Point(504, 344)
		Me.cmdOK.TabIndex = 25
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me.cmbManufacturier.Size = New System.Drawing.Size(145, 21)
		Me.cmbManufacturier.Location = New System.Drawing.Point(176, 96)
		Me.cmbManufacturier.Sorted = True
		Me.cmbManufacturier.TabIndex = 17
		Me.cmbManufacturier.BackColor = System.Drawing.SystemColors.Window
		Me.cmbManufacturier.CausesValidation = True
		Me.cmbManufacturier.Enabled = True
		Me.cmbManufacturier.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbManufacturier.IntegralHeight = True
		Me.cmbManufacturier.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbManufacturier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbManufacturier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbManufacturier.TabStop = True
		Me.cmbManufacturier.Visible = True
		Me.cmbManufacturier.Name = "cmbManufacturier"
		Me.txtNoPiece.AutoSize = False
		Me.txtNoPiece.Size = New System.Drawing.Size(145, 19)
		Me.txtNoPiece.Location = New System.Drawing.Point(176, 64)
		Me.txtNoPiece.Maxlength = 37
		Me.txtNoPiece.TabIndex = 11
		Me.txtNoPiece.AcceptsReturn = True
		Me.txtNoPiece.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoPiece.BackColor = System.Drawing.SystemColors.Window
		Me.txtNoPiece.CausesValidation = True
		Me.txtNoPiece.Enabled = True
		Me.txtNoPiece.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNoPiece.HideSelection = True
		Me.txtNoPiece.ReadOnly = False
		Me.txtNoPiece.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNoPiece.MultiLine = False
		Me.txtNoPiece.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNoPiece.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNoPiece.TabStop = True
		Me.txtNoPiece.Visible = True
		Me.txtNoPiece.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoPiece.Name = "txtNoPiece"
		Me.txtDescription.AutoSize = False
		Me.txtDescription.Size = New System.Drawing.Size(153, 35)
		Me.txtDescription.Location = New System.Drawing.Point(336, 80)
		Me.txtDescription.Maxlength = 61
		Me.txtDescription.MultiLine = True
		Me.txtDescription.TabIndex = 16
		Me.txtDescription.AcceptsReturn = True
		Me.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDescription.BackColor = System.Drawing.SystemColors.Window
		Me.txtDescription.CausesValidation = True
		Me.txtDescription.Enabled = True
		Me.txtDescription.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDescription.HideSelection = True
		Me.txtDescription.ReadOnly = False
		Me.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDescription.TabStop = True
		Me.txtDescription.Visible = True
		Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDescription.Name = "txtDescription"
		Me.cmdAjouter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAjouter.Text = "Ajouter"
		Me.cmdAjouter.Size = New System.Drawing.Size(73, 25)
		Me.cmdAjouter.Location = New System.Drawing.Point(504, 88)
		Me.cmdAjouter.TabIndex = 14
		Me.cmdAjouter.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAjouter.CausesValidation = True
		Me.cmdAjouter.Enabled = True
		Me.cmdAjouter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAjouter.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAjouter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAjouter.TabStop = True
		Me.cmdAjouter.Name = "cmdAjouter"
		Me.lvwManufacturier.Size = New System.Drawing.Size(569, 289)
		Me.lvwManufacturier.Location = New System.Drawing.Point(8, 48)
		Me.lvwManufacturier.TabIndex = 8
		Me.lvwManufacturier.View = System.Windows.Forms.View.Details
		Me.lvwManufacturier.LabelEdit = False
		Me.lvwManufacturier.LabelWrap = True
		Me.lvwManufacturier.HideSelection = True
		Me.lvwManufacturier.Checkboxes = True
		Me.lvwManufacturier.FullRowSelect = True
		Me.lvwManufacturier.GridLines = True
		Me.lvwManufacturier.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwManufacturier.BackColor = System.Drawing.SystemColors.Window
		Me.lvwManufacturier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwManufacturier.Name = "lvwManufacturier"
		Me._lvwManufacturier_ColumnHeader_1.Text = "Manufacturier"
		Me._lvwManufacturier_ColumnHeader_1.Width = 586
		Me.lvwNouvellesPieces.Size = New System.Drawing.Size(569, 217)
		Me.lvwNouvellesPieces.Location = New System.Drawing.Point(8, 120)
		Me.lvwNouvellesPieces.TabIndex = 18
		Me.lvwNouvellesPieces.View = System.Windows.Forms.View.Details
		Me.lvwNouvellesPieces.LabelEdit = False
		Me.lvwNouvellesPieces.LabelWrap = True
		Me.lvwNouvellesPieces.HideSelection = True
		Me.lvwNouvellesPieces.FullRowSelect = True
		Me.lvwNouvellesPieces.GridLines = True
		Me.lvwNouvellesPieces.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwNouvellesPieces.BackColor = System.Drawing.SystemColors.Window
		Me.lvwNouvellesPieces.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwNouvellesPieces.Name = "lvwNouvellesPieces"
		Me._lvwNouvellesPieces_ColumnHeader_1.Text = "Quantité"
		Me._lvwNouvellesPieces_ColumnHeader_1.Width = 170
		Me._lvwNouvellesPieces_ColumnHeader_2.Text = "Pièce"
		Me._lvwNouvellesPieces_ColumnHeader_2.Width = 170
		Me._lvwNouvellesPieces_ColumnHeader_3.Text = "Description"
		Me._lvwNouvellesPieces_ColumnHeader_3.Width = 170
		Me._lvwNouvellesPieces_ColumnHeader_4.Text = "Manufacturier"
		Me._lvwNouvellesPieces_ColumnHeader_4.Width = 170
		Me._lvwNouvellesPieces_ColumnHeader_5.Text = "Catégorie"
		Me._lvwNouvellesPieces_ColumnHeader_5.Width = 170
		Me.lvwFournisseur.Size = New System.Drawing.Size(569, 289)
		Me.lvwFournisseur.Location = New System.Drawing.Point(8, 48)
		Me.lvwFournisseur.TabIndex = 9
		Me.lvwFournisseur.View = System.Windows.Forms.View.Details
		Me.lvwFournisseur.LabelEdit = False
		Me.lvwFournisseur.LabelWrap = True
		Me.lvwFournisseur.HideSelection = True
		Me.lvwFournisseur.Checkboxes = True
		Me.lvwFournisseur.FullRowSelect = True
		Me.lvwFournisseur.GridLines = True
		Me.lvwFournisseur.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwFournisseur.BackColor = System.Drawing.SystemColors.Window
		Me.lvwFournisseur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwFournisseur.Name = "lvwFournisseur"
		Me._lvwFournisseur_ColumnHeader_1.Text = "Nom Fournisseur"
		Me._lvwFournisseur_ColumnHeader_1.Width = 586
		Me._lvwFournisseur_ColumnHeader_2.Text = "Langage de la demande"
		Me._lvwFournisseur_ColumnHeader_2.Width = 226
		Me.lblFormatDate.Text = "AA-MM-JJ"
		Me.lblFormatDate.ForeColor = System.Drawing.Color.White
		Me.lblFormatDate.Size = New System.Drawing.Size(57, 17)
		Me.lblFormatDate.Location = New System.Drawing.Point(424, 344)
		Me.lblFormatDate.TabIndex = 24
		Me.lblFormatDate.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblFormatDate.BackColor = System.Drawing.Color.Transparent
		Me.lblFormatDate.Enabled = True
		Me.lblFormatDate.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblFormatDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblFormatDate.UseMnemonic = True
		Me.lblFormatDate.Visible = True
		Me.lblFormatDate.AutoSize = False
		Me.lblFormatDate.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblFormatDate.Name = "lblFormatDate"
		Me.lblDescription.Text = "Description :"
		Me.lblDescription.ForeColor = System.Drawing.Color.White
		Me.lblDescription.Size = New System.Drawing.Size(73, 17)
		Me.lblDescription.Location = New System.Drawing.Point(336, 64)
		Me.lblDescription.TabIndex = 12
		Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDescription.BackColor = System.Drawing.Color.Transparent
		Me.lblDescription.Enabled = True
		Me.lblDescription.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDescription.UseMnemonic = True
		Me.lblDescription.Visible = True
		Me.lblDescription.AutoSize = False
		Me.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDescription.Name = "lblDescription"
		Me.lblManufacturier.Text = "Manufacturier :"
		Me.lblManufacturier.ForeColor = System.Drawing.Color.White
		Me.lblManufacturier.Size = New System.Drawing.Size(73, 17)
		Me.lblManufacturier.Location = New System.Drawing.Point(96, 96)
		Me.lblManufacturier.TabIndex = 15
		Me.lblManufacturier.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblManufacturier.BackColor = System.Drawing.Color.Transparent
		Me.lblManufacturier.Enabled = True
		Me.lblManufacturier.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblManufacturier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblManufacturier.UseMnemonic = True
		Me.lblManufacturier.Visible = True
		Me.lblManufacturier.AutoSize = False
		Me.lblManufacturier.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblManufacturier.Name = "lblManufacturier"
		Me.lblNoPiece.Text = "No de pièce :"
		Me.lblNoPiece.ForeColor = System.Drawing.Color.White
		Me.lblNoPiece.Size = New System.Drawing.Size(73, 17)
		Me.lblNoPiece.Location = New System.Drawing.Point(96, 64)
		Me.lblNoPiece.TabIndex = 10
		Me.lblNoPiece.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblNoPiece.BackColor = System.Drawing.Color.Transparent
		Me.lblNoPiece.Enabled = True
		Me.lblNoPiece.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblNoPiece.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblNoPiece.UseMnemonic = True
		Me.lblNoPiece.Visible = True
		Me.lblNoPiece.AutoSize = False
		Me.lblNoPiece.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblNoPiece.Name = "lblNoPiece"
		Me.lblCommentaire.Text = "Commentaire"
		Me.lblCommentaire.ForeColor = System.Drawing.Color.White
		Me.lblCommentaire.Size = New System.Drawing.Size(81, 17)
		Me.lblCommentaire.Location = New System.Drawing.Point(104, 376)
		Me.lblCommentaire.TabIndex = 28
		Me.lblCommentaire.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblCommentaire.BackColor = System.Drawing.Color.Transparent
		Me.lblCommentaire.Enabled = True
		Me.lblCommentaire.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblCommentaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblCommentaire.UseMnemonic = True
		Me.lblCommentaire.Visible = True
		Me.lblCommentaire.AutoSize = False
		Me.lblCommentaire.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblCommentaire.Name = "lblCommentaire"
		Me.lblNoGRB.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblNoGRB.Text = "# GRB :"
		Me.lblNoGRB.ForeColor = System.Drawing.Color.White
		Me.lblNoGRB.Size = New System.Drawing.Size(81, 17)
		Me.lblNoGRB.Location = New System.Drawing.Point(248, 368)
		Me.lblNoGRB.TabIndex = 26
		Me.lblNoGRB.BackColor = System.Drawing.Color.Transparent
		Me.lblNoGRB.Enabled = True
		Me.lblNoGRB.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblNoGRB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblNoGRB.UseMnemonic = True
		Me.lblNoGRB.Visible = True
		Me.lblNoGRB.AutoSize = False
		Me.lblNoGRB.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblNoGRB.Name = "lblNoGRB"
		Me.lblDateRequise.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblDateRequise.Text = "Date Requise :"
		Me.lblDateRequise.ForeColor = System.Drawing.Color.White
		Me.lblDateRequise.Size = New System.Drawing.Size(81, 17)
		Me.lblDateRequise.Location = New System.Drawing.Point(248, 344)
		Me.lblDateRequise.TabIndex = 22
		Me.lblDateRequise.BackColor = System.Drawing.Color.Transparent
		Me.lblDateRequise.Enabled = True
		Me.lblDateRequise.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDateRequise.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDateRequise.UseMnemonic = True
		Me.lblDateRequise.Visible = True
		Me.lblDateRequise.AutoSize = False
		Me.lblDateRequise.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDateRequise.Name = "lblDateRequise"
		Me.lblCategorie.Text = "Categorie de pièce :"
		Me.lblCategorie.ForeColor = System.Drawing.Color.White
		Me.lblCategorie.Size = New System.Drawing.Size(105, 17)
		Me.lblCategorie.Location = New System.Drawing.Point(296, 8)
		Me.lblCategorie.TabIndex = 0
		Me.lblCategorie.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblCategorie.BackColor = System.Drawing.Color.Transparent
		Me.lblCategorie.Enabled = True
		Me.lblCategorie.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblCategorie.UseMnemonic = True
		Me.lblCategorie.Visible = True
		Me.lblCategorie.AutoSize = False
		Me.lblCategorie.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblCategorie.Name = "lblCategorie"
		Me.Controls.Add(lvwCategorie)
		Me.Controls.Add(lvwPiece)
		Me.Controls.Add(cmdDeselectAll)
		Me.Controls.Add(cmdSelectAll)
		Me.Controls.Add(cmbTri)
		Me.Controls.Add(cmdRechercher)
		Me.Controls.Add(txtRechercher)
		Me.Controls.Add(cmdRafraichir)
		Me.Controls.Add(cmdTri)
		Me.Controls.Add(cmdFermer)
		Me.Controls.Add(txtCommentaire)
		Me.Controls.Add(txtNoGRB)
		Me.Controls.Add(mskDateRequise)
		Me.Controls.Add(cmdLangage)
		Me.Controls.Add(cmbCategorie)
		Me.Controls.Add(cmdImprimer)
		Me.Controls.Add(cmdOK)
		Me.Controls.Add(cmbManufacturier)
		Me.Controls.Add(txtNoPiece)
		Me.Controls.Add(txtDescription)
		Me.Controls.Add(cmdAjouter)
		Me.Controls.Add(lvwManufacturier)
		Me.Controls.Add(lvwNouvellesPieces)
		Me.Controls.Add(lvwFournisseur)
		Me.Controls.Add(lblFormatDate)
		Me.Controls.Add(lblDescription)
		Me.Controls.Add(lblManufacturier)
		Me.Controls.Add(lblNoPiece)
		Me.Controls.Add(lblCommentaire)
		Me.Controls.Add(lblNoGRB)
		Me.Controls.Add(lblDateRequise)
		Me.Controls.Add(lblCategorie)
		Me.lvwCategorie.Columns.Add(_lvwCategorie_ColumnHeader_1)
		Me.lvwPiece.Columns.Add(_lvwPiece_ColumnHeader_1)
		Me.lvwPiece.Columns.Add(_lvwPiece_ColumnHeader_2)
		Me.lvwPiece.Columns.Add(_lvwPiece_ColumnHeader_3)
		Me.lvwPiece.Columns.Add(_lvwPiece_ColumnHeader_4)
		Me.lvwPiece.Columns.Add(_lvwPiece_ColumnHeader_5)
		Me.lvwManufacturier.Columns.Add(_lvwManufacturier_ColumnHeader_1)
		Me.lvwNouvellesPieces.Columns.Add(_lvwNouvellesPieces_ColumnHeader_1)
		Me.lvwNouvellesPieces.Columns.Add(_lvwNouvellesPieces_ColumnHeader_2)
		Me.lvwNouvellesPieces.Columns.Add(_lvwNouvellesPieces_ColumnHeader_3)
		Me.lvwNouvellesPieces.Columns.Add(_lvwNouvellesPieces_ColumnHeader_4)
		Me.lvwNouvellesPieces.Columns.Add(_lvwNouvellesPieces_ColumnHeader_5)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_1)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_2)
		Me.lvwCategorie.ResumeLayout(False)
		Me.lvwPiece.ResumeLayout(False)
		Me.lvwManufacturier.ResumeLayout(False)
		Me.lvwNouvellesPieces.ResumeLayout(False)
		Me.lvwFournisseur.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class