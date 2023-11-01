<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FrmCatalogueMec
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
	Public WithEvents cmdRechercheCategorie As System.Windows.Forms.Button
	Public WithEvents _lvwRechercheAchat_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwRechercheAchat_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwRechercheAchat As System.Windows.Forms.ListView
	Public WithEvents _lvwRechercheJob_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwRechercheJob_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwRechercheJob As System.Windows.Forms.ListView
	Public WithEvents cmdRechercheJob As System.Windows.Forms.Button
	Public WithEvents cmdCopier As System.Windows.Forms.Button
	Public WithEvents cmdTotal As System.Windows.Forms.Button
	Public WithEvents cmdRechercheInventaire As System.Windows.Forms.Button
	Public WithEvents _lvwFabricant_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFabricant_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFabricant_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFabricant_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwFabricant As System.Windows.Forms.ListView
	Public WithEvents _lvwPieces_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwPieces As System.Windows.Forms.ListView
	Public WithEvents cmdChangerCategorie As System.Windows.Forms.Button
	Public WithEvents cmdDemande As System.Windows.Forms.Button
	Public WithEvents _lvwDescription_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwDescription_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwDescription_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwDescription_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwDescription As System.Windows.Forms.ListView
	Public WithEvents cmdRechercheDescrFR As System.Windows.Forms.Button
	Public WithEvents txtTauxChange As System.Windows.Forms.TextBox
	Public WithEvents _lvwfournisseur_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwfournisseur_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwfournisseur_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwfournisseur_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwfournisseur_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwfournisseur_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwfournisseur_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwfournisseur_ColumnHeader_8 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwfournisseur_ColumnHeader_9 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwfournisseur_ColumnHeader_10 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwfournisseur As System.Windows.Forms.ListView
	Public WithEvents cmdAddFrs As System.Windows.Forms.Button
	Public WithEvents cmdSuppFrs As System.Windows.Forms.Button
	Public WithEvents cmdModifFrs As System.Windows.Forms.Button
	Public WithEvents chkquoter As System.Windows.Forms.CheckBox
	Public WithEvents optUSA As System.Windows.Forms.RadioButton
	Public WithEvents optCAN As System.Windows.Forms.RadioButton
	Public WithEvents txtPrixList As System.Windows.Forms.TextBox
	Public WithEvents txtPrixNet As System.Windows.Forms.TextBox
	Public WithEvents txtPrixSpecial As System.Windows.Forms.TextBox
	Public WithEvents mskValide As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskEscompte As System.Windows.Forms.MaskedTextBox
	Public WithEvents cmdEnrFrs As System.Windows.Forms.Button
	Public WithEvents cmdAnnulFrs As System.Windows.Forms.Button
	Public WithEvents cmbfrs As System.Windows.Forms.ComboBox
	Public WithEvents cmbPersRess As System.Windows.Forms.ComboBox
	Public WithEvents optSpain As System.Windows.Forms.RadioButton
	Public WithEvents lblDevise1 As System.Windows.Forms.Label
	Public WithEvents lblDevise2 As System.Windows.Forms.Label
	Public WithEvents _Label1_5 As System.Windows.Forms.Label
	Public WithEvents imgCanada As System.Windows.Forms.PictureBox
	Public WithEvents imgEU As System.Windows.Forms.PictureBox
	Public WithEvents _Label1_14 As System.Windows.Forms.Label
	Public WithEvents _Label1_16 As System.Windows.Forms.Label
	Public WithEvents _Label1_19 As System.Windows.Forms.Label
	Public WithEvents _Label1_24 As System.Windows.Forms.Label
	Public WithEvents _Label1_20 As System.Windows.Forms.Label
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_23 As System.Windows.Forms.Label
	Public WithEvents imgSpain As System.Windows.Forms.PictureBox
	Public WithEvents frafournisseur As System.Windows.Forms.GroupBox
	Public WithEvents cmbCategorie As System.Windows.Forms.ComboBox
	Public WithEvents txtNoItemGRB As System.Windows.Forms.TextBox
	Public WithEvents cmbNoItem As System.Windows.Forms.ComboBox
	Public WithEvents CmdModif As System.Windows.Forms.Button
	Public WithEvents CmdFerme As System.Windows.Forms.Button
	Public WithEvents CmdSupp As System.Windows.Forms.Button
	Public WithEvents CmdAdd As System.Windows.Forms.Button
	Public WithEvents txtComment As System.Windows.Forms.TextBox
	Public WithEvents cmbFabricant As System.Windows.Forms.ComboBox
	Public WithEvents txtFabricant As System.Windows.Forms.TextBox
	Public WithEvents txtDescriptionEN As System.Windows.Forms.TextBox
	Public WithEvents txtDescriptionFR As System.Windows.Forms.TextBox
	Public WithEvents txtNoItem As System.Windows.Forms.TextBox
	Public WithEvents CmdAnul As System.Windows.Forms.Button
	Public WithEvents CmdEnr As System.Windows.Forms.Button
	Public WithEvents txtCategorie As System.Windows.Forms.TextBox
	Public WithEvents cmdRechercherPiece As System.Windows.Forms.Button
	Public WithEvents cmbDescriptionFR As System.Windows.Forms.ComboBox
	Public WithEvents cmdRechercherManufact As System.Windows.Forms.Button
	Public WithEvents chkInventaire As System.Windows.Forms.CheckBox
	Public WithEvents txtQuantiteCommande As System.Windows.Forms.TextBox
	Public WithEvents chkMinimum As System.Windows.Forms.CheckBox
	Public WithEvents txtQuantiteStock As System.Windows.Forms.TextBox
	Public WithEvents txtQuantiteMinimum As System.Windows.Forms.TextBox
	Public WithEvents txtQuantitéBoite As System.Windows.Forms.TextBox
	Public WithEvents chkBoite As System.Windows.Forms.CheckBox
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents fraQuantité As System.Windows.Forms.GroupBox
	Public WithEvents cmbLocalisation As System.Windows.Forms.ComboBox
	Public WithEvents txtLocalisation As System.Windows.Forms.TextBox
	Public WithEvents cmdRechercheAchat As System.Windows.Forms.Button
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents _Label1_25 As System.Windows.Forms.Label
	Public WithEvents _Label1_6 As System.Windows.Forms.Label
	Public WithEvents _Label1_4 As System.Windows.Forms.Label
	Public WithEvents _Label1_3 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmCatalogueMec))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.lvwCategorie = New System.Windows.Forms.ListView
		Me._lvwCategorie_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.cmdRechercheCategorie = New System.Windows.Forms.Button
		Me.lvwRechercheAchat = New System.Windows.Forms.ListView
		Me._lvwRechercheAchat_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwRechercheAchat_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me.lvwRechercheJob = New System.Windows.Forms.ListView
		Me._lvwRechercheJob_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwRechercheJob_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me.cmdRechercheJob = New System.Windows.Forms.Button
		Me.cmdCopier = New System.Windows.Forms.Button
		Me.cmdTotal = New System.Windows.Forms.Button
		Me.cmdRechercheInventaire = New System.Windows.Forms.Button
		Me.lvwFabricant = New System.Windows.Forms.ListView
		Me._lvwFabricant_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwFabricant_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwFabricant_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwFabricant_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me.lvwPieces = New System.Windows.Forms.ListView
		Me._lvwPieces_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me.cmdChangerCategorie = New System.Windows.Forms.Button
		Me.cmdDemande = New System.Windows.Forms.Button
		Me.lvwDescription = New System.Windows.Forms.ListView
		Me._lvwDescription_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwDescription_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwDescription_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwDescription_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me.cmdRechercheDescrFR = New System.Windows.Forms.Button
		Me.frafournisseur = New System.Windows.Forms.GroupBox
		Me.txtTauxChange = New System.Windows.Forms.TextBox
		Me.lvwfournisseur = New System.Windows.Forms.ListView
		Me._lvwfournisseur_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwfournisseur_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwfournisseur_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwfournisseur_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwfournisseur_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvwfournisseur_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me._lvwfournisseur_ColumnHeader_7 = New System.Windows.Forms.ColumnHeader
		Me._lvwfournisseur_ColumnHeader_8 = New System.Windows.Forms.ColumnHeader
		Me._lvwfournisseur_ColumnHeader_9 = New System.Windows.Forms.ColumnHeader
		Me._lvwfournisseur_ColumnHeader_10 = New System.Windows.Forms.ColumnHeader
		Me.cmdAddFrs = New System.Windows.Forms.Button
		Me.cmdSuppFrs = New System.Windows.Forms.Button
		Me.cmdModifFrs = New System.Windows.Forms.Button
		Me.chkquoter = New System.Windows.Forms.CheckBox
		Me.optUSA = New System.Windows.Forms.RadioButton
		Me.optCAN = New System.Windows.Forms.RadioButton
		Me.txtPrixList = New System.Windows.Forms.TextBox
		Me.txtPrixNet = New System.Windows.Forms.TextBox
		Me.txtPrixSpecial = New System.Windows.Forms.TextBox
		Me.mskValide = New System.Windows.Forms.MaskedTextBox
		Me.mskEscompte = New System.Windows.Forms.MaskedTextBox
		Me.cmdEnrFrs = New System.Windows.Forms.Button
		Me.cmdAnnulFrs = New System.Windows.Forms.Button
		Me.cmbfrs = New System.Windows.Forms.ComboBox
		Me.cmbPersRess = New System.Windows.Forms.ComboBox
		Me.optSpain = New System.Windows.Forms.RadioButton
		Me.lblDevise1 = New System.Windows.Forms.Label
		Me.lblDevise2 = New System.Windows.Forms.Label
		Me._Label1_5 = New System.Windows.Forms.Label
		Me.imgCanada = New System.Windows.Forms.PictureBox
		Me.imgEU = New System.Windows.Forms.PictureBox
		Me._Label1_14 = New System.Windows.Forms.Label
		Me._Label1_16 = New System.Windows.Forms.Label
		Me._Label1_19 = New System.Windows.Forms.Label
		Me._Label1_24 = New System.Windows.Forms.Label
		Me._Label1_20 = New System.Windows.Forms.Label
		Me._Label1_2 = New System.Windows.Forms.Label
		Me._Label1_23 = New System.Windows.Forms.Label
		Me.imgSpain = New System.Windows.Forms.PictureBox
		Me.cmbCategorie = New System.Windows.Forms.ComboBox
		Me.txtNoItemGRB = New System.Windows.Forms.TextBox
		Me.cmbNoItem = New System.Windows.Forms.ComboBox
		Me.CmdModif = New System.Windows.Forms.Button
		Me.CmdFerme = New System.Windows.Forms.Button
		Me.CmdSupp = New System.Windows.Forms.Button
		Me.CmdAdd = New System.Windows.Forms.Button
		Me.txtComment = New System.Windows.Forms.TextBox
		Me.cmbFabricant = New System.Windows.Forms.ComboBox
		Me.txtFabricant = New System.Windows.Forms.TextBox
		Me.txtDescriptionEN = New System.Windows.Forms.TextBox
		Me.txtDescriptionFR = New System.Windows.Forms.TextBox
		Me.txtNoItem = New System.Windows.Forms.TextBox
		Me.CmdAnul = New System.Windows.Forms.Button
		Me.CmdEnr = New System.Windows.Forms.Button
		Me.txtCategorie = New System.Windows.Forms.TextBox
		Me.cmdRechercherPiece = New System.Windows.Forms.Button
		Me.cmbDescriptionFR = New System.Windows.Forms.ComboBox
		Me.cmdRechercherManufact = New System.Windows.Forms.Button
		Me.chkInventaire = New System.Windows.Forms.CheckBox
		Me.fraQuantité = New System.Windows.Forms.GroupBox
		Me.txtQuantiteCommande = New System.Windows.Forms.TextBox
		Me.chkMinimum = New System.Windows.Forms.CheckBox
		Me.txtQuantiteStock = New System.Windows.Forms.TextBox
		Me.txtQuantiteMinimum = New System.Windows.Forms.TextBox
		Me.txtQuantitéBoite = New System.Windows.Forms.TextBox
		Me.chkBoite = New System.Windows.Forms.CheckBox
		Me.Label11 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.cmbLocalisation = New System.Windows.Forms.ComboBox
		Me.txtLocalisation = New System.Windows.Forms.TextBox
		Me.cmdRechercheAchat = New System.Windows.Forms.Button
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me._Label1_25 = New System.Windows.Forms.Label
		Me._Label1_6 = New System.Windows.Forms.Label
		Me._Label1_4 = New System.Windows.Forms.Label
		Me._Label1_3 = New System.Windows.Forms.Label
		Me._Label1_1 = New System.Windows.Forms.Label
		Me._Label1_0 = New System.Windows.Forms.Label
		Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.lvwCategorie.SuspendLayout()
		Me.lvwRechercheAchat.SuspendLayout()
		Me.lvwRechercheJob.SuspendLayout()
		Me.lvwFabricant.SuspendLayout()
		Me.lvwPieces.SuspendLayout()
		Me.lvwDescription.SuspendLayout()
		Me.frafournisseur.SuspendLayout()
		Me.lvwfournisseur.SuspendLayout()
		Me.fraQuantité.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.SystemColors.ControlText
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Catalogue Mécanique"
		Me.ClientSize = New System.Drawing.Size(694, 441)
		Me.Location = New System.Drawing.Point(97, 68)
		Me.Icon = CType(resources.GetObject("FrmCatalogueMec.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("FrmCatalogueMec.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "FrmCatalogueMec"
		Me.lvwCategorie.Size = New System.Drawing.Size(281, 129)
		Me.lvwCategorie.Location = New System.Drawing.Point(352, 8)
		Me.lvwCategorie.TabIndex = 82
		Me.lvwCategorie.Visible = False
		Me.lvwCategorie.View = System.Windows.Forms.View.Details
		Me.lvwCategorie.LabelEdit = False
		Me.lvwCategorie.LabelWrap = True
		Me.lvwCategorie.HideSelection = True
		Me.lvwCategorie.FullRowSelect = True
		Me.lvwCategorie.GridLines = True
		Me.lvwCategorie.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwCategorie.BackColor = System.Drawing.SystemColors.Window
		Me.lvwCategorie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwCategorie.Name = "lvwCategorie"
		Me._lvwCategorie_ColumnHeader_1.Text = "Catégorie"
		Me._lvwCategorie_ColumnHeader_1.Width = 447
		Me.cmdRechercheCategorie.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdRechercheCategorie.Size = New System.Drawing.Size(25, 25)
		Me.cmdRechercheCategorie.Location = New System.Drawing.Point(664, 8)
		Me.cmdRechercheCategorie.Image = CType(resources.GetObject("cmdRechercheCategorie.Image"), System.Drawing.Image)
		Me.cmdRechercheCategorie.TabIndex = 81
		Me.cmdRechercheCategorie.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercheCategorie.CausesValidation = True
		Me.cmdRechercheCategorie.Enabled = True
		Me.cmdRechercheCategorie.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercheCategorie.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercheCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercheCategorie.TabStop = True
		Me.cmdRechercheCategorie.Name = "cmdRechercheCategorie"
		Me.lvwRechercheAchat.Size = New System.Drawing.Size(553, 129)
		Me.lvwRechercheAchat.Location = New System.Drawing.Point(104, 64)
		Me.lvwRechercheAchat.TabIndex = 79
		Me.lvwRechercheAchat.Visible = False
		Me.lvwRechercheAchat.View = System.Windows.Forms.View.Details
		Me.lvwRechercheAchat.LabelEdit = False
		Me.lvwRechercheAchat.LabelWrap = True
		Me.lvwRechercheAchat.HideSelection = True
		Me.lvwRechercheAchat.FullRowSelect = True
		Me.lvwRechercheAchat.GridLines = True
		Me.lvwRechercheAchat.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwRechercheAchat.BackColor = System.Drawing.SystemColors.Window
		Me.lvwRechercheAchat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwRechercheAchat.Name = "lvwRechercheAchat"
		Me._lvwRechercheAchat_ColumnHeader_1.Text = "No. Job"
		Me._lvwRechercheAchat_ColumnHeader_1.Width = 170
		Me._lvwRechercheAchat_ColumnHeader_2.Text = "Nbre fois"
		Me._lvwRechercheAchat_ColumnHeader_2.Width = 170
		Me.lvwRechercheJob.Size = New System.Drawing.Size(545, 129)
		Me.lvwRechercheJob.Location = New System.Drawing.Point(104, 64)
		Me.lvwRechercheJob.TabIndex = 15
		Me.lvwRechercheJob.Visible = False
		Me.lvwRechercheJob.View = System.Windows.Forms.View.Details
		Me.lvwRechercheJob.LabelEdit = False
		Me.lvwRechercheJob.LabelWrap = True
		Me.lvwRechercheJob.HideSelection = True
		Me.lvwRechercheJob.FullRowSelect = True
		Me.lvwRechercheJob.GridLines = True
		Me.lvwRechercheJob.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwRechercheJob.BackColor = System.Drawing.SystemColors.Window
		Me.lvwRechercheJob.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwRechercheJob.Name = "lvwRechercheJob"
		Me._lvwRechercheJob_ColumnHeader_1.Text = "No. Job"
		Me._lvwRechercheJob_ColumnHeader_1.Width = 170
		Me._lvwRechercheJob_ColumnHeader_2.Text = "Nbre fois"
		Me._lvwRechercheJob_ColumnHeader_2.Width = 170
		Me.cmdRechercheJob.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRechercheJob.Text = "Recherche dans jobs / soums"
		Me.cmdRechercheJob.Size = New System.Drawing.Size(89, 33)
		Me.cmdRechercheJob.Location = New System.Drawing.Point(72, 200)
		Me.cmdRechercheJob.TabIndex = 38
		Me.cmdRechercheJob.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercheJob.CausesValidation = True
		Me.cmdRechercheJob.Enabled = True
		Me.cmdRechercheJob.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercheJob.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercheJob.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercheJob.TabStop = True
		Me.cmdRechercheJob.Name = "cmdRechercheJob"
		Me.cmdCopier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCopier.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCopier.Text = "&Copier"
		Me.cmdCopier.Size = New System.Drawing.Size(89, 33)
		Me.cmdCopier.Location = New System.Drawing.Point(216, 400)
		Me.cmdCopier.TabIndex = 69
		Me.cmdCopier.CausesValidation = True
		Me.cmdCopier.Enabled = True
		Me.cmdCopier.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCopier.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCopier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCopier.TabStop = True
		Me.cmdCopier.Name = "cmdCopier"
		Me.cmdTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdTotal.Text = "Total"
		Me.cmdTotal.Size = New System.Drawing.Size(57, 25)
		Me.cmdTotal.Location = New System.Drawing.Point(8, 200)
		Me.cmdTotal.TabIndex = 37
		Me.cmdTotal.BackColor = System.Drawing.SystemColors.Control
		Me.cmdTotal.CausesValidation = True
		Me.cmdTotal.Enabled = True
		Me.cmdTotal.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdTotal.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdTotal.TabStop = True
		Me.cmdTotal.Name = "cmdTotal"
		Me.cmdRechercheInventaire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRechercheInventaire.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercheInventaire.Text = "Inventaire"
		Me.cmdRechercheInventaire.Size = New System.Drawing.Size(97, 33)
		Me.cmdRechercheInventaire.Location = New System.Drawing.Point(8, 400)
		Me.cmdRechercheInventaire.TabIndex = 67
		Me.cmdRechercheInventaire.CausesValidation = True
		Me.cmdRechercheInventaire.Enabled = True
		Me.cmdRechercheInventaire.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercheInventaire.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercheInventaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercheInventaire.TabStop = True
		Me.cmdRechercheInventaire.Name = "cmdRechercheInventaire"
		Me.lvwFabricant.Size = New System.Drawing.Size(553, 129)
		Me.lvwFabricant.Location = New System.Drawing.Point(104, 64)
		Me.lvwFabricant.TabIndex = 4
		Me.lvwFabricant.Visible = False
		Me.lvwFabricant.View = System.Windows.Forms.View.Details
		Me.lvwFabricant.LabelEdit = False
		Me.lvwFabricant.LabelWrap = True
		Me.lvwFabricant.HideSelection = True
		Me.lvwFabricant.FullRowSelect = True
		Me.lvwFabricant.GridLines = True
		Me.lvwFabricant.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwFabricant.BackColor = System.Drawing.SystemColors.Window
		Me.lvwFabricant.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwFabricant.Name = "lvwFabricant"
		Me._lvwFabricant_ColumnHeader_1.Text = "Manufacturier"
		Me._lvwFabricant_ColumnHeader_1.Width = 140
		Me._lvwFabricant_ColumnHeader_2.Text = "No. Pièce"
		Me._lvwFabricant_ColumnHeader_2.Width = 217
		Me._lvwFabricant_ColumnHeader_3.Text = "Description française"
		Me._lvwFabricant_ColumnHeader_3.Width = 410
		Me._lvwFabricant_ColumnHeader_4.Text = "Description anglaise"
		Me._lvwFabricant_ColumnHeader_4.Width = 410
		Me.lvwPieces.Size = New System.Drawing.Size(553, 129)
		Me.lvwPieces.Location = New System.Drawing.Point(104, 64)
		Me.lvwPieces.TabIndex = 5
		Me.lvwPieces.Visible = False
		Me.lvwPieces.View = System.Windows.Forms.View.Details
		Me.lvwPieces.LabelEdit = False
		Me.lvwPieces.LabelWrap = True
		Me.lvwPieces.HideSelection = True
		Me.lvwPieces.FullRowSelect = True
		Me.lvwPieces.GridLines = True
		Me.lvwPieces.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwPieces.BackColor = System.Drawing.SystemColors.Window
		Me.lvwPieces.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwPieces.Name = "lvwPieces"
		Me._lvwPieces_ColumnHeader_1.Text = "No Pièce"
		Me._lvwPieces_ColumnHeader_1.Width = 217
		Me._lvwPieces_ColumnHeader_2.Text = "Manufacturier"
		Me._lvwPieces_ColumnHeader_2.Width = 140
		Me._lvwPieces_ColumnHeader_3.Text = "Description française"
		Me._lvwPieces_ColumnHeader_3.Width = 410
		Me._lvwPieces_ColumnHeader_4.Text = "Description anglaise"
		Me._lvwPieces_ColumnHeader_4.Width = 410
		Me.cmdChangerCategorie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdChangerCategorie.Text = "Changer de catégorie"
		Me.cmdChangerCategorie.Size = New System.Drawing.Size(121, 25)
		Me.cmdChangerCategorie.Location = New System.Drawing.Point(512, 32)
		Me.cmdChangerCategorie.TabIndex = 3
		Me.cmdChangerCategorie.BackColor = System.Drawing.SystemColors.Control
		Me.cmdChangerCategorie.CausesValidation = True
		Me.cmdChangerCategorie.Enabled = True
		Me.cmdChangerCategorie.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdChangerCategorie.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdChangerCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdChangerCategorie.TabStop = True
		Me.cmdChangerCategorie.Name = "cmdChangerCategorie"
		Me.cmdDemande.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDemande.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDemande.Text = "Demande de prix"
		Me.cmdDemande.Size = New System.Drawing.Size(97, 33)
		Me.cmdDemande.Location = New System.Drawing.Point(112, 400)
		Me.cmdDemande.TabIndex = 68
		Me.cmdDemande.CausesValidation = True
		Me.cmdDemande.Enabled = True
		Me.cmdDemande.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDemande.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDemande.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDemande.TabStop = True
		Me.cmdDemande.Name = "cmdDemande"
		Me.lvwDescription.Size = New System.Drawing.Size(553, 129)
		Me.lvwDescription.Location = New System.Drawing.Point(104, 64)
		Me.lvwDescription.TabIndex = 6
		Me.lvwDescription.Visible = False
		Me.lvwDescription.View = System.Windows.Forms.View.Details
		Me.lvwDescription.LabelEdit = False
		Me.lvwDescription.LabelWrap = True
		Me.lvwDescription.HideSelection = True
		Me.lvwDescription.FullRowSelect = True
		Me.lvwDescription.GridLines = True
		Me.lvwDescription.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwDescription.BackColor = System.Drawing.SystemColors.Window
		Me.lvwDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwDescription.Name = "lvwDescription"
		Me._lvwDescription_ColumnHeader_1.Text = "Description française"
		Me._lvwDescription_ColumnHeader_1.Width = 410
		Me._lvwDescription_ColumnHeader_2.Text = "Description anglais"
		Me._lvwDescription_ColumnHeader_2.Width = 410
		Me._lvwDescription_ColumnHeader_3.Text = "Manufacturier"
		Me._lvwDescription_ColumnHeader_3.Width = 140
		Me._lvwDescription_ColumnHeader_4.Text = "NoItem"
		Me._lvwDescription_ColumnHeader_4.Width = 217
		Me.cmdRechercheDescrFR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdRechercheDescrFR.Size = New System.Drawing.Size(25, 25)
		Me.cmdRechercheDescrFR.Location = New System.Drawing.Point(664, 60)
		Me.cmdRechercheDescrFR.Image = CType(resources.GetObject("cmdRechercheDescrFR.Image"), System.Drawing.Image)
		Me.cmdRechercheDescrFR.TabIndex = 9
		Me.cmdRechercheDescrFR.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercheDescrFR.CausesValidation = True
		Me.cmdRechercheDescrFR.Enabled = True
		Me.cmdRechercheDescrFR.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercheDescrFR.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercheDescrFR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercheDescrFR.TabStop = True
		Me.cmdRechercheDescrFR.Name = "cmdRechercheDescrFR"
		Me.frafournisseur.BackColor = System.Drawing.Color.Black
		Me.frafournisseur.Text = "Fournisseur"
		Me.frafournisseur.ForeColor = System.Drawing.Color.White
		Me.frafournisseur.Size = New System.Drawing.Size(681, 161)
		Me.frafournisseur.Location = New System.Drawing.Point(8, 232)
		Me.frafournisseur.TabIndex = 41
		Me.frafournisseur.Enabled = True
		Me.frafournisseur.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frafournisseur.Visible = True
		Me.frafournisseur.Padding = New System.Windows.Forms.Padding(0)
		Me.frafournisseur.Name = "frafournisseur"
		Me.txtTauxChange.AutoSize = False
		Me.txtTauxChange.BackColor = System.Drawing.Color.White
		Me.txtTauxChange.Size = New System.Drawing.Size(57, 19)
		Me.txtTauxChange.Location = New System.Drawing.Point(576, 128)
		Me.txtTauxChange.TabIndex = 76
		Me.txtTauxChange.Visible = False
		Me.txtTauxChange.AcceptsReturn = True
		Me.txtTauxChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTauxChange.CausesValidation = True
		Me.txtTauxChange.Enabled = True
		Me.txtTauxChange.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTauxChange.HideSelection = True
		Me.txtTauxChange.ReadOnly = False
		Me.txtTauxChange.Maxlength = 0
		Me.txtTauxChange.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTauxChange.MultiLine = False
		Me.txtTauxChange.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTauxChange.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTauxChange.TabStop = True
		Me.txtTauxChange.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTauxChange.Name = "txtTauxChange"
		Me.lvwfournisseur.Size = New System.Drawing.Size(665, 105)
		Me.lvwfournisseur.Location = New System.Drawing.Point(8, 16)
		Me.lvwfournisseur.TabIndex = 42
		Me.lvwfournisseur.View = System.Windows.Forms.View.Details
		Me.lvwfournisseur.LabelEdit = False
		Me.lvwfournisseur.LabelWrap = True
		Me.lvwfournisseur.HideSelection = True
		Me.lvwfournisseur.FullRowSelect = True
		Me.lvwfournisseur.GridLines = True
		Me.lvwfournisseur.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwfournisseur.BackColor = System.Drawing.SystemColors.Window
		Me.lvwfournisseur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwfournisseur.Name = "lvwfournisseur"
		Me._lvwfournisseur_ColumnHeader_1.Text = "Fournisseur"
		Me._lvwfournisseur_ColumnHeader_1.Width = 236
		Me._lvwfournisseur_ColumnHeader_2.Text = "Pers. Ress."
		Me._lvwfournisseur_ColumnHeader_2.Width = 133
		Me._lvwfournisseur_ColumnHeader_3.Text = "Date"
		Me._lvwfournisseur_ColumnHeader_3.Width = 117
		Me._lvwfournisseur_ColumnHeader_4.Text = "Par"
		Me._lvwfournisseur_ColumnHeader_4.Width = 54
		Me._lvwfournisseur_ColumnHeader_5.Text = "Valide"
		Me._lvwfournisseur_ColumnHeader_5.Width = 117
		Me._lvwfournisseur_ColumnHeader_6.Text = "Prix listé"
		Me._lvwfournisseur_ColumnHeader_6.Width = 108
		Me._lvwfournisseur_ColumnHeader_7.Text = "Escompte"
		Me._lvwfournisseur_ColumnHeader_7.Width = 105
		Me._lvwfournisseur_ColumnHeader_8.Text = "Prix net"
		Me._lvwfournisseur_ColumnHeader_8.Width = 108
		Me._lvwfournisseur_ColumnHeader_9.Text = "Prix spécial"
		Me._lvwfournisseur_ColumnHeader_9.Width = 115
		Me._lvwfournisseur_ColumnHeader_10.Text = "Quoter"
		Me._lvwfournisseur_ColumnHeader_10.Width = 80
		Me.cmdAddFrs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAddFrs.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAddFrs.Text = "&Ajouter"
		Me.cmdAddFrs.Size = New System.Drawing.Size(73, 25)
		Me.cmdAddFrs.Location = New System.Drawing.Point(8, 128)
		Me.cmdAddFrs.TabIndex = 62
		Me.cmdAddFrs.CausesValidation = True
		Me.cmdAddFrs.Enabled = True
		Me.cmdAddFrs.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAddFrs.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAddFrs.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAddFrs.TabStop = True
		Me.cmdAddFrs.Name = "cmdAddFrs"
		Me.cmdSuppFrs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSuppFrs.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSuppFrs.Text = "&Supprimer"
		Me.cmdSuppFrs.Size = New System.Drawing.Size(73, 25)
		Me.cmdSuppFrs.Location = New System.Drawing.Point(88, 128)
		Me.cmdSuppFrs.TabIndex = 65
		Me.cmdSuppFrs.CausesValidation = True
		Me.cmdSuppFrs.Enabled = True
		Me.cmdSuppFrs.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSuppFrs.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSuppFrs.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSuppFrs.TabStop = True
		Me.cmdSuppFrs.Name = "cmdSuppFrs"
		Me.cmdModifFrs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdModifFrs.BackColor = System.Drawing.SystemColors.Control
		Me.cmdModifFrs.Text = "&Modifier"
		Me.cmdModifFrs.Size = New System.Drawing.Size(73, 25)
		Me.cmdModifFrs.Location = New System.Drawing.Point(168, 128)
		Me.cmdModifFrs.TabIndex = 66
		Me.cmdModifFrs.CausesValidation = True
		Me.cmdModifFrs.Enabled = True
		Me.cmdModifFrs.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdModifFrs.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdModifFrs.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdModifFrs.TabStop = True
		Me.cmdModifFrs.Name = "cmdModifFrs"
		Me.chkquoter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkquoter.BackColor = System.Drawing.Color.Black
		Me.chkquoter.Text = "Quoter :"
		Me.chkquoter.ForeColor = System.Drawing.Color.White
		Me.chkquoter.Size = New System.Drawing.Size(89, 17)
		Me.chkquoter.Location = New System.Drawing.Point(8, 96)
		Me.chkquoter.TabIndex = 61
		Me.chkquoter.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkquoter.CausesValidation = True
		Me.chkquoter.Enabled = True
		Me.chkquoter.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkquoter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkquoter.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkquoter.TabStop = True
		Me.chkquoter.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkquoter.Visible = True
		Me.chkquoter.Name = "chkquoter"
		Me.optUSA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optUSA.BackColor = System.Drawing.Color.Black
		Me.optUSA.Text = "USA"
		Me.optUSA.ForeColor = System.Drawing.Color.White
		Me.optUSA.Size = New System.Drawing.Size(49, 17)
		Me.optUSA.Location = New System.Drawing.Point(576, 24)
		Me.optUSA.TabIndex = 56
		Me.optUSA.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optUSA.CausesValidation = True
		Me.optUSA.Enabled = True
		Me.optUSA.Cursor = System.Windows.Forms.Cursors.Default
		Me.optUSA.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optUSA.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optUSA.TabStop = True
		Me.optUSA.Checked = False
		Me.optUSA.Visible = True
		Me.optUSA.Name = "optUSA"
		Me.optCAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optCAN.BackColor = System.Drawing.Color.Black
		Me.optCAN.Text = "CAN"
		Me.optCAN.ForeColor = System.Drawing.Color.White
		Me.optCAN.Size = New System.Drawing.Size(49, 17)
		Me.optCAN.Location = New System.Drawing.Point(528, 24)
		Me.optCAN.TabIndex = 55
		Me.optCAN.Checked = True
		Me.optCAN.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optCAN.CausesValidation = True
		Me.optCAN.Enabled = True
		Me.optCAN.Cursor = System.Windows.Forms.Cursors.Default
		Me.optCAN.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optCAN.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optCAN.TabStop = True
		Me.optCAN.Visible = True
		Me.optCAN.Name = "optCAN"
		Me.txtPrixList.AutoSize = False
		Me.txtPrixList.BackColor = System.Drawing.Color.White
		Me.txtPrixList.Size = New System.Drawing.Size(73, 19)
		Me.txtPrixList.Location = New System.Drawing.Point(424, 24)
		Me.txtPrixList.TabIndex = 48
		Me.txtPrixList.AcceptsReturn = True
		Me.txtPrixList.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPrixList.CausesValidation = True
		Me.txtPrixList.Enabled = True
		Me.txtPrixList.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPrixList.HideSelection = True
		Me.txtPrixList.ReadOnly = False
		Me.txtPrixList.Maxlength = 0
		Me.txtPrixList.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPrixList.MultiLine = False
		Me.txtPrixList.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPrixList.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPrixList.TabStop = True
		Me.txtPrixList.Visible = True
		Me.txtPrixList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPrixList.Name = "txtPrixList"
		Me.txtPrixNet.AutoSize = False
		Me.txtPrixNet.BackColor = System.Drawing.Color.White
		Me.txtPrixNet.Size = New System.Drawing.Size(57, 19)
		Me.txtPrixNet.Location = New System.Drawing.Point(424, 72)
		Me.txtPrixNet.TabIndex = 52
		Me.txtPrixNet.AcceptsReturn = True
		Me.txtPrixNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPrixNet.CausesValidation = True
		Me.txtPrixNet.Enabled = True
		Me.txtPrixNet.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPrixNet.HideSelection = True
		Me.txtPrixNet.ReadOnly = False
		Me.txtPrixNet.Maxlength = 0
		Me.txtPrixNet.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPrixNet.MultiLine = False
		Me.txtPrixNet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPrixNet.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPrixNet.TabStop = True
		Me.txtPrixNet.Visible = True
		Me.txtPrixNet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPrixNet.Name = "txtPrixNet"
		Me.txtPrixSpecial.AutoSize = False
		Me.txtPrixSpecial.BackColor = System.Drawing.Color.White
		Me.txtPrixSpecial.Size = New System.Drawing.Size(57, 19)
		Me.txtPrixSpecial.Location = New System.Drawing.Point(424, 96)
		Me.txtPrixSpecial.TabIndex = 54
		Me.txtPrixSpecial.AcceptsReturn = True
		Me.txtPrixSpecial.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPrixSpecial.CausesValidation = True
		Me.txtPrixSpecial.Enabled = True
		Me.txtPrixSpecial.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPrixSpecial.HideSelection = True
		Me.txtPrixSpecial.ReadOnly = False
		Me.txtPrixSpecial.Maxlength = 0
		Me.txtPrixSpecial.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPrixSpecial.MultiLine = False
		Me.txtPrixSpecial.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPrixSpecial.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPrixSpecial.TabStop = True
		Me.txtPrixSpecial.Visible = True
		Me.txtPrixSpecial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPrixSpecial.Name = "txtPrixSpecial"
		Me.mskValide.AllowPromptAsInput = False
		Me.mskValide.Size = New System.Drawing.Size(81, 17)
		Me.mskValide.Location = New System.Drawing.Point(104, 72)
		Me.mskValide.TabIndex = 46
		Me.mskValide.PromptChar = "_"
		Me.mskValide.Name = "mskValide"
		Me.mskEscompte.AllowPromptAsInput = False
		Me.mskEscompte.Size = New System.Drawing.Size(57, 17)
		Me.mskEscompte.Location = New System.Drawing.Point(424, 48)
		Me.mskEscompte.TabIndex = 50
		Me.mskEscompte.PromptChar = "_"
		Me.mskEscompte.Name = "mskEscompte"
		Me.cmdEnrFrs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEnrFrs.Text = "&Enregistre"
		Me.cmdEnrFrs.Size = New System.Drawing.Size(73, 25)
		Me.cmdEnrFrs.Location = New System.Drawing.Point(8, 128)
		Me.cmdEnrFrs.TabIndex = 63
		Me.cmdEnrFrs.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEnrFrs.CausesValidation = True
		Me.cmdEnrFrs.Enabled = True
		Me.cmdEnrFrs.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEnrFrs.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEnrFrs.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEnrFrs.TabStop = True
		Me.cmdEnrFrs.Name = "cmdEnrFrs"
		Me.cmdAnnulFrs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnulFrs.Text = "A&nnuler"
		Me.cmdAnnulFrs.Size = New System.Drawing.Size(73, 25)
		Me.cmdAnnulFrs.Location = New System.Drawing.Point(88, 128)
		Me.cmdAnnulFrs.TabIndex = 64
		Me.cmdAnnulFrs.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnulFrs.CausesValidation = True
		Me.cmdAnnulFrs.Enabled = True
		Me.cmdAnnulFrs.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnulFrs.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnulFrs.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnulFrs.TabStop = True
		Me.cmdAnnulFrs.Name = "cmdAnnulFrs"
		Me.cmbfrs.Size = New System.Drawing.Size(185, 21)
		Me.cmbfrs.Location = New System.Drawing.Point(104, 24)
		Me.cmbfrs.TabIndex = 44
		Me.cmbfrs.BackColor = System.Drawing.SystemColors.Window
		Me.cmbfrs.CausesValidation = True
		Me.cmbfrs.Enabled = True
		Me.cmbfrs.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbfrs.IntegralHeight = True
		Me.cmbfrs.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbfrs.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbfrs.Sorted = False
		Me.cmbfrs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbfrs.TabStop = True
		Me.cmbfrs.Visible = True
		Me.cmbfrs.Name = "cmbfrs"
		Me.cmbPersRess.Size = New System.Drawing.Size(145, 21)
		Me.cmbPersRess.Location = New System.Drawing.Point(104, 48)
		Me.cmbPersRess.TabIndex = 45
		Me.cmbPersRess.BackColor = System.Drawing.SystemColors.Window
		Me.cmbPersRess.CausesValidation = True
		Me.cmbPersRess.Enabled = True
		Me.cmbPersRess.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbPersRess.IntegralHeight = True
		Me.cmbPersRess.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbPersRess.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbPersRess.Sorted = False
		Me.cmbPersRess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbPersRess.TabStop = True
		Me.cmbPersRess.Visible = True
		Me.cmbPersRess.Name = "cmbPersRess"
		Me.optSpain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optSpain.BackColor = System.Drawing.Color.Black
		Me.optSpain.Text = "SPA"
		Me.optSpain.ForeColor = System.Drawing.Color.White
		Me.optSpain.Size = New System.Drawing.Size(49, 17)
		Me.optSpain.Location = New System.Drawing.Point(624, 24)
		Me.optSpain.TabIndex = 57
		Me.optSpain.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optSpain.CausesValidation = True
		Me.optSpain.Enabled = True
		Me.optSpain.Cursor = System.Windows.Forms.Cursors.Default
		Me.optSpain.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optSpain.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optSpain.TabStop = True
		Me.optSpain.Checked = False
		Me.optSpain.Visible = True
		Me.optSpain.Name = "optSpain"
		Me.lblDevise1.Text = "1$ CAN ="
		Me.lblDevise1.ForeColor = System.Drawing.Color.White
		Me.lblDevise1.Size = New System.Drawing.Size(57, 17)
		Me.lblDevise1.Location = New System.Drawing.Point(520, 128)
		Me.lblDevise1.TabIndex = 78
		Me.lblDevise1.Visible = False
		Me.lblDevise1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDevise1.BackColor = System.Drawing.Color.Transparent
		Me.lblDevise1.Enabled = True
		Me.lblDevise1.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDevise1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDevise1.UseMnemonic = True
		Me.lblDevise1.AutoSize = False
		Me.lblDevise1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDevise1.Name = "lblDevise1"
		Me.lblDevise2.Text = "$ USA"
		Me.lblDevise2.ForeColor = System.Drawing.Color.White
		Me.lblDevise2.Size = New System.Drawing.Size(38, 17)
		Me.lblDevise2.Location = New System.Drawing.Point(637, 128)
		Me.lblDevise2.TabIndex = 77
		Me.lblDevise2.Visible = False
		Me.lblDevise2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDevise2.BackColor = System.Drawing.Color.Transparent
		Me.lblDevise2.Enabled = True
		Me.lblDevise2.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDevise2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDevise2.UseMnemonic = True
		Me.lblDevise2.AutoSize = False
		Me.lblDevise2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDevise2.Name = "lblDevise2"
		Me._Label1_5.Text = "AA-MM-JJ"
		Me._Label1_5.ForeColor = System.Drawing.Color.White
		Me._Label1_5.Size = New System.Drawing.Size(65, 17)
		Me._Label1_5.Location = New System.Drawing.Point(192, 72)
		Me._Label1_5.TabIndex = 60
		Me._Label1_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_5.BackColor = System.Drawing.Color.Transparent
		Me._Label1_5.Enabled = True
		Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_5.UseMnemonic = True
		Me._Label1_5.Visible = True
		Me._Label1_5.AutoSize = False
		Me._Label1_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_5.Name = "_Label1_5"
		Me.imgCanada.Size = New System.Drawing.Size(112, 71)
		Me.imgCanada.Location = New System.Drawing.Point(544, 48)
		Me.imgCanada.Image = CType(resources.GetObject("imgCanada.Image"), System.Drawing.Image)
		Me.imgCanada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.imgCanada.Visible = False
		Me.imgCanada.Enabled = True
		Me.imgCanada.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgCanada.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.imgCanada.Name = "imgCanada"
		Me.imgEU.Size = New System.Drawing.Size(112, 71)
		Me.imgEU.Location = New System.Drawing.Point(544, 48)
		Me.imgEU.Image = CType(resources.GetObject("imgEU.Image"), System.Drawing.Image)
		Me.imgEU.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.imgEU.Visible = False
		Me.imgEU.Enabled = True
		Me.imgEU.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgEU.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.imgEU.Name = "imgEU"
		Me._Label1_14.Text = "Distributeur :"
		Me._Label1_14.ForeColor = System.Drawing.Color.White
		Me._Label1_14.Size = New System.Drawing.Size(81, 17)
		Me._Label1_14.Location = New System.Drawing.Point(8, 24)
		Me._Label1_14.TabIndex = 43
		Me._Label1_14.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_14.BackColor = System.Drawing.Color.Transparent
		Me._Label1_14.Enabled = True
		Me._Label1_14.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_14.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_14.UseMnemonic = True
		Me._Label1_14.Visible = True
		Me._Label1_14.AutoSize = False
		Me._Label1_14.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_14.Name = "_Label1_14"
		Me._Label1_16.Text = "Prix Listé :"
		Me._Label1_16.ForeColor = System.Drawing.Color.White
		Me._Label1_16.Size = New System.Drawing.Size(65, 17)
		Me._Label1_16.Location = New System.Drawing.Point(344, 24)
		Me._Label1_16.TabIndex = 47
		Me._Label1_16.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_16.BackColor = System.Drawing.Color.Transparent
		Me._Label1_16.Enabled = True
		Me._Label1_16.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_16.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_16.UseMnemonic = True
		Me._Label1_16.Visible = True
		Me._Label1_16.AutoSize = False
		Me._Label1_16.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_16.Name = "_Label1_16"
		Me._Label1_19.Text = "Escompte :"
		Me._Label1_19.ForeColor = System.Drawing.Color.White
		Me._Label1_19.Size = New System.Drawing.Size(73, 17)
		Me._Label1_19.Location = New System.Drawing.Point(344, 48)
		Me._Label1_19.TabIndex = 49
		Me._Label1_19.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_19.BackColor = System.Drawing.Color.Transparent
		Me._Label1_19.Enabled = True
		Me._Label1_19.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_19.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_19.UseMnemonic = True
		Me._Label1_19.Visible = True
		Me._Label1_19.AutoSize = False
		Me._Label1_19.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_19.Name = "_Label1_19"
		Me._Label1_24.Text = "Pers. Ress :"
		Me._Label1_24.ForeColor = System.Drawing.Color.White
		Me._Label1_24.Size = New System.Drawing.Size(105, 17)
		Me._Label1_24.Location = New System.Drawing.Point(8, 48)
		Me._Label1_24.TabIndex = 58
		Me._Label1_24.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_24.BackColor = System.Drawing.Color.Transparent
		Me._Label1_24.Enabled = True
		Me._Label1_24.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_24.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_24.UseMnemonic = True
		Me._Label1_24.Visible = True
		Me._Label1_24.AutoSize = False
		Me._Label1_24.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_24.Name = "_Label1_24"
		Me._Label1_20.Text = "Prix Net :"
		Me._Label1_20.ForeColor = System.Drawing.Color.White
		Me._Label1_20.Size = New System.Drawing.Size(73, 17)
		Me._Label1_20.Location = New System.Drawing.Point(344, 72)
		Me._Label1_20.TabIndex = 51
		Me._Label1_20.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_20.BackColor = System.Drawing.Color.Transparent
		Me._Label1_20.Enabled = True
		Me._Label1_20.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_20.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_20.UseMnemonic = True
		Me._Label1_20.Visible = True
		Me._Label1_20.AutoSize = False
		Me._Label1_20.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_20.Name = "_Label1_20"
		Me._Label1_2.Text = "Prix Spécial :"
		Me._Label1_2.ForeColor = System.Drawing.Color.White
		Me._Label1_2.Size = New System.Drawing.Size(81, 17)
		Me._Label1_2.Location = New System.Drawing.Point(344, 96)
		Me._Label1_2.TabIndex = 53
		Me._Label1_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_2.BackColor = System.Drawing.Color.Transparent
		Me._Label1_2.Enabled = True
		Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_2.UseMnemonic = True
		Me._Label1_2.Visible = True
		Me._Label1_2.AutoSize = False
		Me._Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_2.Name = "_Label1_2"
		Me._Label1_23.Text = "Valide jusqu'au :"
		Me._Label1_23.ForeColor = System.Drawing.Color.White
		Me._Label1_23.Size = New System.Drawing.Size(97, 17)
		Me._Label1_23.Location = New System.Drawing.Point(8, 72)
		Me._Label1_23.TabIndex = 59
		Me._Label1_23.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_23.BackColor = System.Drawing.Color.Transparent
		Me._Label1_23.Enabled = True
		Me._Label1_23.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_23.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_23.UseMnemonic = True
		Me._Label1_23.Visible = True
		Me._Label1_23.AutoSize = False
		Me._Label1_23.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_23.Name = "_Label1_23"
		Me.imgSpain.Size = New System.Drawing.Size(112, 71)
		Me.imgSpain.Location = New System.Drawing.Point(544, 48)
		Me.imgSpain.Image = CType(resources.GetObject("imgSpain.Image"), System.Drawing.Image)
		Me.imgSpain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.imgSpain.Visible = False
		Me.imgSpain.Enabled = True
		Me.imgSpain.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgSpain.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.imgSpain.Name = "imgSpain"
		Me.cmbCategorie.BackColor = System.Drawing.Color.White
		Me.cmbCategorie.Size = New System.Drawing.Size(281, 21)
		Me.cmbCategorie.Location = New System.Drawing.Point(352, 8)
		Me.cmbCategorie.TabIndex = 0
		Me.cmbCategorie.Text = "cmbCategorie"
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
		Me.txtNoItemGRB.AutoSize = False
		Me.txtNoItemGRB.BackColor = System.Drawing.Color.White
		Me.txtNoItemGRB.Size = New System.Drawing.Size(129, 19)
		Me.txtNoItemGRB.Location = New System.Drawing.Point(104, 152)
		Me.txtNoItemGRB.TabIndex = 24
		Me.txtNoItemGRB.AcceptsReturn = True
		Me.txtNoItemGRB.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoItemGRB.CausesValidation = True
		Me.txtNoItemGRB.Enabled = True
		Me.txtNoItemGRB.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNoItemGRB.HideSelection = True
		Me.txtNoItemGRB.ReadOnly = False
		Me.txtNoItemGRB.Maxlength = 0
		Me.txtNoItemGRB.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNoItemGRB.MultiLine = False
		Me.txtNoItemGRB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNoItemGRB.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNoItemGRB.TabStop = True
		Me.txtNoItemGRB.Visible = True
		Me.txtNoItemGRB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoItemGRB.Name = "txtNoItemGRB"
		Me.cmbNoItem.BackColor = System.Drawing.Color.White
		Me.cmbNoItem.Size = New System.Drawing.Size(129, 21)
		Me.cmbNoItem.Location = New System.Drawing.Point(104, 120)
		Me.cmbNoItem.TabIndex = 17
		Me.cmbNoItem.Text = "cmbNoItem"
		Me.cmbNoItem.Visible = False
		Me.cmbNoItem.CausesValidation = True
		Me.cmbNoItem.Enabled = True
		Me.cmbNoItem.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbNoItem.IntegralHeight = True
		Me.cmbNoItem.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbNoItem.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbNoItem.Sorted = False
		Me.cmbNoItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbNoItem.TabStop = True
		Me.cmbNoItem.Name = "cmbNoItem"
		Me.CmdModif.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdModif.BackColor = System.Drawing.SystemColors.Control
		Me.CmdModif.Text = "&Modifier"
		Me.CmdModif.Size = New System.Drawing.Size(89, 33)
		Me.CmdModif.Location = New System.Drawing.Point(504, 400)
		Me.CmdModif.TabIndex = 74
		Me.CmdModif.CausesValidation = True
		Me.CmdModif.Enabled = True
		Me.CmdModif.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdModif.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdModif.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdModif.TabStop = True
		Me.CmdModif.Name = "CmdModif"
		Me.CmdFerme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdFerme.BackColor = System.Drawing.SystemColors.Control
		Me.CmdFerme.Text = "&Fermer"
		Me.CmdFerme.Size = New System.Drawing.Size(89, 33)
		Me.CmdFerme.Location = New System.Drawing.Point(600, 400)
		Me.CmdFerme.TabIndex = 75
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
		Me.CmdSupp.Size = New System.Drawing.Size(89, 33)
		Me.CmdSupp.Location = New System.Drawing.Point(408, 400)
		Me.CmdSupp.TabIndex = 72
		Me.CmdSupp.CausesValidation = True
		Me.CmdSupp.Enabled = True
		Me.CmdSupp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdSupp.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdSupp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdSupp.TabStop = True
		Me.CmdSupp.Name = "CmdSupp"
		Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdAdd.BackColor = System.Drawing.SystemColors.Control
		Me.CmdAdd.Text = "&Ajouter"
		Me.CmdAdd.Size = New System.Drawing.Size(89, 33)
		Me.CmdAdd.Location = New System.Drawing.Point(312, 400)
		Me.CmdAdd.TabIndex = 71
		Me.CmdAdd.CausesValidation = True
		Me.CmdAdd.Enabled = True
		Me.CmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdAdd.TabStop = True
		Me.CmdAdd.Name = "CmdAdd"
		Me.txtComment.AutoSize = False
		Me.txtComment.BackColor = System.Drawing.Color.White
		Me.txtComment.Size = New System.Drawing.Size(305, 19)
		Me.txtComment.Location = New System.Drawing.Point(352, 128)
		Me.txtComment.ReadOnly = True
		Me.txtComment.Maxlength = 100
		Me.txtComment.TabIndex = 25
		Me.txtComment.AcceptsReturn = True
		Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtComment.CausesValidation = True
		Me.txtComment.Enabled = True
		Me.txtComment.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtComment.HideSelection = True
		Me.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtComment.MultiLine = False
		Me.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtComment.TabStop = True
		Me.txtComment.Visible = True
		Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtComment.Name = "txtComment"
		Me.cmbFabricant.BackColor = System.Drawing.Color.White
		Me.cmbFabricant.Size = New System.Drawing.Size(129, 21)
		Me.cmbFabricant.Location = New System.Drawing.Point(104, 64)
		Me.cmbFabricant.TabIndex = 10
		Me.cmbFabricant.Text = "cmbFabricant"
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
		Me.txtFabricant.AutoSize = False
		Me.txtFabricant.BackColor = System.Drawing.SystemColors.ControlLightLight
		Me.txtFabricant.Enabled = False
		Me.txtFabricant.Size = New System.Drawing.Size(129, 19)
		Me.txtFabricant.Location = New System.Drawing.Point(104, 88)
		Me.txtFabricant.TabIndex = 8
		Me.txtFabricant.AcceptsReturn = True
		Me.txtFabricant.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtFabricant.CausesValidation = True
		Me.txtFabricant.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtFabricant.HideSelection = True
		Me.txtFabricant.ReadOnly = False
		Me.txtFabricant.Maxlength = 0
		Me.txtFabricant.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtFabricant.MultiLine = False
		Me.txtFabricant.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtFabricant.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtFabricant.TabStop = True
		Me.txtFabricant.Visible = True
		Me.txtFabricant.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtFabricant.Name = "txtFabricant"
		Me.txtDescriptionEN.AutoSize = False
		Me.txtDescriptionEN.BackColor = System.Drawing.Color.White
		Me.txtDescriptionEN.Size = New System.Drawing.Size(305, 19)
		Me.txtDescriptionEN.Location = New System.Drawing.Point(352, 96)
		Me.txtDescriptionEN.ReadOnly = True
		Me.txtDescriptionEN.Maxlength = 100
		Me.txtDescriptionEN.TabIndex = 21
		Me.txtDescriptionEN.AcceptsReturn = True
		Me.txtDescriptionEN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDescriptionEN.CausesValidation = True
		Me.txtDescriptionEN.Enabled = True
		Me.txtDescriptionEN.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDescriptionEN.HideSelection = True
		Me.txtDescriptionEN.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDescriptionEN.MultiLine = False
		Me.txtDescriptionEN.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDescriptionEN.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDescriptionEN.TabStop = True
		Me.txtDescriptionEN.Visible = True
		Me.txtDescriptionEN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDescriptionEN.Name = "txtDescriptionEN"
		Me.txtDescriptionFR.AutoSize = False
		Me.txtDescriptionFR.BackColor = System.Drawing.Color.White
		Me.txtDescriptionFR.Size = New System.Drawing.Size(305, 21)
		Me.txtDescriptionFR.Location = New System.Drawing.Point(352, 64)
		Me.txtDescriptionFR.ReadOnly = True
		Me.txtDescriptionFR.Maxlength = 100
		Me.txtDescriptionFR.TabIndex = 14
		Me.txtDescriptionFR.AcceptsReturn = True
		Me.txtDescriptionFR.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDescriptionFR.CausesValidation = True
		Me.txtDescriptionFR.Enabled = True
		Me.txtDescriptionFR.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDescriptionFR.HideSelection = True
		Me.txtDescriptionFR.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDescriptionFR.MultiLine = False
		Me.txtDescriptionFR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDescriptionFR.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDescriptionFR.TabStop = True
		Me.txtDescriptionFR.Visible = True
		Me.txtDescriptionFR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDescriptionFR.Name = "txtDescriptionFR"
		Me.txtNoItem.AutoSize = False
		Me.txtNoItem.Size = New System.Drawing.Size(129, 19)
		Me.txtNoItem.Location = New System.Drawing.Point(104, 120)
		Me.txtNoItem.ReadOnly = True
		Me.txtNoItem.TabIndex = 18
		Me.txtNoItem.AcceptsReturn = True
		Me.txtNoItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoItem.BackColor = System.Drawing.SystemColors.Window
		Me.txtNoItem.CausesValidation = True
		Me.txtNoItem.Enabled = True
		Me.txtNoItem.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNoItem.HideSelection = True
		Me.txtNoItem.Maxlength = 0
		Me.txtNoItem.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNoItem.MultiLine = False
		Me.txtNoItem.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNoItem.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNoItem.TabStop = True
		Me.txtNoItem.Visible = True
		Me.txtNoItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoItem.Name = "txtNoItem"
		Me.CmdAnul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdAnul.Text = "A&nnuler"
		Me.CmdAnul.Size = New System.Drawing.Size(89, 33)
		Me.CmdAnul.Location = New System.Drawing.Point(408, 400)
		Me.CmdAnul.TabIndex = 73
		Me.CmdAnul.BackColor = System.Drawing.SystemColors.Control
		Me.CmdAnul.CausesValidation = True
		Me.CmdAnul.Enabled = True
		Me.CmdAnul.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdAnul.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdAnul.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdAnul.TabStop = True
		Me.CmdAnul.Name = "CmdAnul"
		Me.CmdEnr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdEnr.Text = "&Enregistre"
		Me.AcceptButton = Me.CmdEnr
		Me.CmdEnr.Size = New System.Drawing.Size(89, 33)
		Me.CmdEnr.Location = New System.Drawing.Point(312, 400)
		Me.CmdEnr.TabIndex = 70
		Me.CmdEnr.BackColor = System.Drawing.SystemColors.Control
		Me.CmdEnr.CausesValidation = True
		Me.CmdEnr.Enabled = True
		Me.CmdEnr.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdEnr.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdEnr.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdEnr.TabStop = True
		Me.CmdEnr.Name = "CmdEnr"
		Me.txtCategorie.AutoSize = False
		Me.txtCategorie.Size = New System.Drawing.Size(281, 19)
		Me.txtCategorie.Location = New System.Drawing.Point(352, 8)
		Me.txtCategorie.ReadOnly = True
		Me.txtCategorie.TabIndex = 2
		Me.txtCategorie.AcceptsReturn = True
		Me.txtCategorie.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCategorie.BackColor = System.Drawing.SystemColors.Window
		Me.txtCategorie.CausesValidation = True
		Me.txtCategorie.Enabled = True
		Me.txtCategorie.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCategorie.HideSelection = True
		Me.txtCategorie.Maxlength = 0
		Me.txtCategorie.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCategorie.MultiLine = False
		Me.txtCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCategorie.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCategorie.TabStop = True
		Me.txtCategorie.Visible = True
		Me.txtCategorie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCategorie.Name = "txtCategorie"
		Me.cmdRechercherPiece.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdRechercherPiece.Size = New System.Drawing.Size(25, 25)
		Me.cmdRechercherPiece.Location = New System.Drawing.Point(240, 120)
		Me.cmdRechercherPiece.Image = CType(resources.GetObject("cmdRechercherPiece.Image"), System.Drawing.Image)
		Me.cmdRechercherPiece.TabIndex = 19
		Me.cmdRechercherPiece.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercherPiece.CausesValidation = True
		Me.cmdRechercherPiece.Enabled = True
		Me.cmdRechercherPiece.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercherPiece.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercherPiece.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercherPiece.TabStop = True
		Me.cmdRechercherPiece.Name = "cmdRechercherPiece"
		Me.cmbDescriptionFR.Size = New System.Drawing.Size(305, 21)
		Me.cmbDescriptionFR.Location = New System.Drawing.Point(352, 64)
		Me.cmbDescriptionFR.TabIndex = 13
		Me.cmbDescriptionFR.BackColor = System.Drawing.SystemColors.Window
		Me.cmbDescriptionFR.CausesValidation = True
		Me.cmbDescriptionFR.Enabled = True
		Me.cmbDescriptionFR.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbDescriptionFR.IntegralHeight = True
		Me.cmbDescriptionFR.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbDescriptionFR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbDescriptionFR.Sorted = False
		Me.cmbDescriptionFR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbDescriptionFR.TabStop = True
		Me.cmbDescriptionFR.Visible = True
		Me.cmbDescriptionFR.Name = "cmbDescriptionFR"
		Me.cmdRechercherManufact.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdRechercherManufact.Size = New System.Drawing.Size(25, 25)
		Me.cmdRechercherManufact.Location = New System.Drawing.Point(240, 64)
		Me.cmdRechercherManufact.Image = CType(resources.GetObject("cmdRechercherManufact.Image"), System.Drawing.Image)
		Me.cmdRechercherManufact.TabIndex = 11
		Me.cmdRechercherManufact.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercherManufact.CausesValidation = True
		Me.cmdRechercherManufact.Enabled = True
		Me.cmdRechercherManufact.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercherManufact.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercherManufact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercherManufact.TabStop = True
		Me.cmdRechercherManufact.Name = "cmdRechercherManufact"
		Me.chkInventaire.BackColor = System.Drawing.Color.Black
		Me.chkInventaire.Text = "Présent dans l'inventaire"
		Me.chkInventaire.ForeColor = System.Drawing.Color.White
		Me.chkInventaire.Size = New System.Drawing.Size(89, 25)
		Me.chkInventaire.Location = New System.Drawing.Point(352, 152)
		Me.chkInventaire.TabIndex = 26
		Me.chkInventaire.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkInventaire.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkInventaire.CausesValidation = True
		Me.chkInventaire.Enabled = True
		Me.chkInventaire.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkInventaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkInventaire.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkInventaire.TabStop = True
		Me.chkInventaire.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkInventaire.Visible = True
		Me.chkInventaire.Name = "chkInventaire"
		Me.fraQuantité.BackColor = System.Drawing.Color.Black
		Me.fraQuantité.Text = "Quantité"
		Me.fraQuantité.ForeColor = System.Drawing.Color.White
		Me.fraQuantité.Size = New System.Drawing.Size(233, 65)
		Me.fraQuantité.Location = New System.Drawing.Point(456, 152)
		Me.fraQuantité.TabIndex = 28
		Me.fraQuantité.Enabled = True
		Me.fraQuantité.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraQuantité.Visible = True
		Me.fraQuantité.Padding = New System.Windows.Forms.Padding(0)
		Me.fraQuantité.Name = "fraQuantité"
		Me.txtQuantiteCommande.AutoSize = False
		Me.txtQuantiteCommande.Enabled = False
		Me.txtQuantiteCommande.Size = New System.Drawing.Size(33, 19)
		Me.txtQuantiteCommande.Location = New System.Drawing.Point(192, 40)
		Me.txtQuantiteCommande.TabIndex = 36
		Me.txtQuantiteCommande.AcceptsReturn = True
		Me.txtQuantiteCommande.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtQuantiteCommande.BackColor = System.Drawing.SystemColors.Window
		Me.txtQuantiteCommande.CausesValidation = True
		Me.txtQuantiteCommande.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtQuantiteCommande.HideSelection = True
		Me.txtQuantiteCommande.ReadOnly = False
		Me.txtQuantiteCommande.Maxlength = 0
		Me.txtQuantiteCommande.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtQuantiteCommande.MultiLine = False
		Me.txtQuantiteCommande.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtQuantiteCommande.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtQuantiteCommande.TabStop = True
		Me.txtQuantiteCommande.Visible = True
		Me.txtQuantiteCommande.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtQuantiteCommande.Name = "txtQuantiteCommande"
		Me.chkMinimum.BackColor = System.Drawing.Color.Black
		Me.chkMinimum.Text = "Minimum :"
		Me.chkMinimum.ForeColor = System.Drawing.Color.White
		Me.chkMinimum.Size = New System.Drawing.Size(71, 17)
		Me.chkMinimum.Location = New System.Drawing.Point(120, 16)
		Me.chkMinimum.TabIndex = 31
		Me.chkMinimum.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkMinimum.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkMinimum.CausesValidation = True
		Me.chkMinimum.Enabled = True
		Me.chkMinimum.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkMinimum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkMinimum.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkMinimum.TabStop = True
		Me.chkMinimum.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkMinimum.Visible = True
		Me.chkMinimum.Name = "chkMinimum"
		Me.txtQuantiteStock.AutoSize = False
		Me.txtQuantiteStock.Size = New System.Drawing.Size(33, 19)
		Me.txtQuantiteStock.Location = New System.Drawing.Point(80, 40)
		Me.txtQuantiteStock.TabIndex = 33
		Me.txtQuantiteStock.AcceptsReturn = True
		Me.txtQuantiteStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtQuantiteStock.BackColor = System.Drawing.SystemColors.Window
		Me.txtQuantiteStock.CausesValidation = True
		Me.txtQuantiteStock.Enabled = True
		Me.txtQuantiteStock.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtQuantiteStock.HideSelection = True
		Me.txtQuantiteStock.ReadOnly = False
		Me.txtQuantiteStock.Maxlength = 0
		Me.txtQuantiteStock.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtQuantiteStock.MultiLine = False
		Me.txtQuantiteStock.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtQuantiteStock.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtQuantiteStock.TabStop = True
		Me.txtQuantiteStock.Visible = True
		Me.txtQuantiteStock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtQuantiteStock.Name = "txtQuantiteStock"
		Me.txtQuantiteMinimum.AutoSize = False
		Me.txtQuantiteMinimum.Enabled = False
		Me.txtQuantiteMinimum.Size = New System.Drawing.Size(33, 19)
		Me.txtQuantiteMinimum.Location = New System.Drawing.Point(192, 16)
		Me.txtQuantiteMinimum.TabIndex = 32
		Me.txtQuantiteMinimum.AcceptsReturn = True
		Me.txtQuantiteMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtQuantiteMinimum.BackColor = System.Drawing.SystemColors.Window
		Me.txtQuantiteMinimum.CausesValidation = True
		Me.txtQuantiteMinimum.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtQuantiteMinimum.HideSelection = True
		Me.txtQuantiteMinimum.ReadOnly = False
		Me.txtQuantiteMinimum.Maxlength = 0
		Me.txtQuantiteMinimum.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtQuantiteMinimum.MultiLine = False
		Me.txtQuantiteMinimum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtQuantiteMinimum.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtQuantiteMinimum.TabStop = True
		Me.txtQuantiteMinimum.Visible = True
		Me.txtQuantiteMinimum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtQuantiteMinimum.Name = "txtQuantiteMinimum"
		Me.txtQuantitéBoite.AutoSize = False
		Me.txtQuantitéBoite.Enabled = False
		Me.txtQuantitéBoite.Size = New System.Drawing.Size(33, 19)
		Me.txtQuantitéBoite.Location = New System.Drawing.Point(80, 16)
		Me.txtQuantitéBoite.TabIndex = 30
		Me.txtQuantitéBoite.AcceptsReturn = True
		Me.txtQuantitéBoite.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtQuantitéBoite.BackColor = System.Drawing.SystemColors.Window
		Me.txtQuantitéBoite.CausesValidation = True
		Me.txtQuantitéBoite.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtQuantitéBoite.HideSelection = True
		Me.txtQuantitéBoite.ReadOnly = False
		Me.txtQuantitéBoite.Maxlength = 0
		Me.txtQuantitéBoite.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtQuantitéBoite.MultiLine = False
		Me.txtQuantitéBoite.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtQuantitéBoite.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtQuantitéBoite.TabStop = True
		Me.txtQuantitéBoite.Visible = True
		Me.txtQuantitéBoite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtQuantitéBoite.Name = "txtQuantitéBoite"
		Me.chkBoite.BackColor = System.Drawing.Color.Black
		Me.chkBoite.Text = "Par Boîte :"
		Me.chkBoite.ForeColor = System.Drawing.Color.White
		Me.chkBoite.Size = New System.Drawing.Size(73, 17)
		Me.chkBoite.Location = New System.Drawing.Point(8, 16)
		Me.chkBoite.TabIndex = 29
		Me.chkBoite.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkBoite.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkBoite.CausesValidation = True
		Me.chkBoite.Enabled = True
		Me.chkBoite.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkBoite.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkBoite.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkBoite.TabStop = True
		Me.chkBoite.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkBoite.Visible = True
		Me.chkBoite.Name = "chkBoite"
		Me.Label11.Text = "À commander :"
		Me.Label11.ForeColor = System.Drawing.Color.White
		Me.Label11.Size = New System.Drawing.Size(73, 17)
		Me.Label11.Location = New System.Drawing.Point(120, 40)
		Me.Label11.TabIndex = 35
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label11.BackColor = System.Drawing.Color.Transparent
		Me.Label11.Enabled = True
		Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label11.UseMnemonic = True
		Me.Label11.Visible = True
		Me.Label11.AutoSize = False
		Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label11.Name = "Label11"
		Me.Label5.Text = "Stock :"
		Me.Label5.ForeColor = System.Drawing.Color.White
		Me.Label5.Size = New System.Drawing.Size(73, 17)
		Me.Label5.Location = New System.Drawing.Point(8, 40)
		Me.Label5.TabIndex = 34
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
		Me.cmbLocalisation.Size = New System.Drawing.Size(105, 21)
		Me.cmbLocalisation.Location = New System.Drawing.Point(344, 200)
		Me.cmbLocalisation.TabIndex = 39
		Me.cmbLocalisation.BackColor = System.Drawing.SystemColors.Window
		Me.cmbLocalisation.CausesValidation = True
		Me.cmbLocalisation.Enabled = True
		Me.cmbLocalisation.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbLocalisation.IntegralHeight = True
		Me.cmbLocalisation.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbLocalisation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbLocalisation.Sorted = False
		Me.cmbLocalisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbLocalisation.TabStop = True
		Me.cmbLocalisation.Visible = True
		Me.cmbLocalisation.Name = "cmbLocalisation"
		Me.txtLocalisation.AutoSize = False
		Me.txtLocalisation.Size = New System.Drawing.Size(105, 19)
		Me.txtLocalisation.Location = New System.Drawing.Point(344, 200)
		Me.txtLocalisation.ReadOnly = True
		Me.txtLocalisation.TabIndex = 40
		Me.txtLocalisation.Text = "Text1"
		Me.txtLocalisation.AcceptsReturn = True
		Me.txtLocalisation.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtLocalisation.BackColor = System.Drawing.SystemColors.Window
		Me.txtLocalisation.CausesValidation = True
		Me.txtLocalisation.Enabled = True
		Me.txtLocalisation.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtLocalisation.HideSelection = True
		Me.txtLocalisation.Maxlength = 0
		Me.txtLocalisation.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtLocalisation.MultiLine = False
		Me.txtLocalisation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtLocalisation.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtLocalisation.TabStop = True
		Me.txtLocalisation.Visible = True
		Me.txtLocalisation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtLocalisation.Name = "txtLocalisation"
		Me.cmdRechercheAchat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRechercheAchat.Text = "Recherche dans achats"
		Me.cmdRechercheAchat.Size = New System.Drawing.Size(89, 33)
		Me.cmdRechercheAchat.Location = New System.Drawing.Point(168, 200)
		Me.cmdRechercheAchat.TabIndex = 80
		Me.cmdRechercheAchat.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercheAchat.CausesValidation = True
		Me.cmdRechercheAchat.Enabled = True
		Me.cmdRechercheAchat.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercheAchat.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercheAchat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercheAchat.TabStop = True
		Me.cmdRechercheAchat.Name = "cmdRechercheAchat"
		Me.Label4.Text = "Localisation :"
		Me.Label4.ForeColor = System.Drawing.Color.White
		Me.Label4.Size = New System.Drawing.Size(65, 17)
		Me.Label4.Location = New System.Drawing.Point(344, 184)
		Me.Label4.TabIndex = 27
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
		Me.Label2.Text = "Catégorie de pièce :"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(121, 17)
		Me.Label2.Location = New System.Drawing.Point(232, 8)
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
		Me._Label1_25.Text = "Pièce GRB :"
		Me._Label1_25.ForeColor = System.Drawing.Color.White
		Me._Label1_25.Size = New System.Drawing.Size(113, 17)
		Me._Label1_25.Location = New System.Drawing.Point(8, 152)
		Me._Label1_25.TabIndex = 23
		Me._Label1_25.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_25.BackColor = System.Drawing.Color.Transparent
		Me._Label1_25.Enabled = True
		Me._Label1_25.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_25.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_25.UseMnemonic = True
		Me._Label1_25.Visible = True
		Me._Label1_25.AutoSize = False
		Me._Label1_25.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_25.Name = "_Label1_25"
		Me._Label1_6.Text = "Commentaire :"
		Me._Label1_6.ForeColor = System.Drawing.Color.White
		Me._Label1_6.Size = New System.Drawing.Size(81, 17)
		Me._Label1_6.Location = New System.Drawing.Point(272, 128)
		Me._Label1_6.TabIndex = 22
		Me._Label1_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_6.BackColor = System.Drawing.Color.Transparent
		Me._Label1_6.Enabled = True
		Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_6.UseMnemonic = True
		Me._Label1_6.Visible = True
		Me._Label1_6.AutoSize = False
		Me._Label1_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_6.Name = "_Label1_6"
		Me._Label1_4.Text = "Desc. EN :"
		Me._Label1_4.ForeColor = System.Drawing.Color.White
		Me._Label1_4.Size = New System.Drawing.Size(73, 17)
		Me._Label1_4.Location = New System.Drawing.Point(272, 96)
		Me._Label1_4.TabIndex = 20
		Me._Label1_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_4.BackColor = System.Drawing.Color.Transparent
		Me._Label1_4.Enabled = True
		Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_4.UseMnemonic = True
		Me._Label1_4.Visible = True
		Me._Label1_4.AutoSize = False
		Me._Label1_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_4.Name = "_Label1_4"
		Me._Label1_3.Text = "Desc. FR :"
		Me._Label1_3.ForeColor = System.Drawing.Color.White
		Me._Label1_3.Size = New System.Drawing.Size(73, 17)
		Me._Label1_3.Location = New System.Drawing.Point(272, 64)
		Me._Label1_3.TabIndex = 12
		Me._Label1_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_3.BackColor = System.Drawing.Color.Transparent
		Me._Label1_3.Enabled = True
		Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_3.UseMnemonic = True
		Me._Label1_3.Visible = True
		Me._Label1_3.AutoSize = False
		Me._Label1_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_3.Name = "_Label1_3"
		Me._Label1_1.Text = "Manufacturier :"
		Me._Label1_1.ForeColor = System.Drawing.Color.White
		Me._Label1_1.Size = New System.Drawing.Size(89, 17)
		Me._Label1_1.Location = New System.Drawing.Point(8, 64)
		Me._Label1_1.TabIndex = 7
		Me._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_1.BackColor = System.Drawing.Color.Transparent
		Me._Label1_1.Enabled = True
		Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_1.UseMnemonic = True
		Me._Label1_1.Visible = True
		Me._Label1_1.AutoSize = False
		Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_1.Name = "_Label1_1"
		Me._Label1_0.Text = "Pièce :"
		Me._Label1_0.ForeColor = System.Drawing.Color.White
		Me._Label1_0.Size = New System.Drawing.Size(73, 17)
		Me._Label1_0.Location = New System.Drawing.Point(8, 120)
		Me._Label1_0.TabIndex = 16
		Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_0.BackColor = System.Drawing.Color.Transparent
		Me._Label1_0.Enabled = True
		Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_0.UseMnemonic = True
		Me._Label1_0.Visible = True
		Me._Label1_0.AutoSize = False
		Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_0.Name = "_Label1_0"
		Me.Controls.Add(lvwCategorie)
		Me.Controls.Add(cmdRechercheCategorie)
		Me.Controls.Add(lvwRechercheAchat)
		Me.Controls.Add(lvwRechercheJob)
		Me.Controls.Add(cmdRechercheJob)
		Me.Controls.Add(cmdCopier)
		Me.Controls.Add(cmdTotal)
		Me.Controls.Add(cmdRechercheInventaire)
		Me.Controls.Add(lvwFabricant)
		Me.Controls.Add(lvwPieces)
		Me.Controls.Add(cmdChangerCategorie)
		Me.Controls.Add(cmdDemande)
		Me.Controls.Add(lvwDescription)
		Me.Controls.Add(cmdRechercheDescrFR)
		Me.Controls.Add(frafournisseur)
		Me.Controls.Add(cmbCategorie)
		Me.Controls.Add(txtNoItemGRB)
		Me.Controls.Add(cmbNoItem)
		Me.Controls.Add(CmdModif)
		Me.Controls.Add(CmdFerme)
		Me.Controls.Add(CmdSupp)
		Me.Controls.Add(CmdAdd)
		Me.Controls.Add(txtComment)
		Me.Controls.Add(cmbFabricant)
		Me.Controls.Add(txtFabricant)
		Me.Controls.Add(txtDescriptionEN)
		Me.Controls.Add(txtDescriptionFR)
		Me.Controls.Add(txtNoItem)
		Me.Controls.Add(CmdAnul)
		Me.Controls.Add(CmdEnr)
		Me.Controls.Add(txtCategorie)
		Me.Controls.Add(cmdRechercherPiece)
		Me.Controls.Add(cmbDescriptionFR)
		Me.Controls.Add(cmdRechercherManufact)
		Me.Controls.Add(chkInventaire)
		Me.Controls.Add(fraQuantité)
		Me.Controls.Add(cmbLocalisation)
		Me.Controls.Add(txtLocalisation)
		Me.Controls.Add(cmdRechercheAchat)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label2)
		Me.Controls.Add(_Label1_25)
		Me.Controls.Add(_Label1_6)
		Me.Controls.Add(_Label1_4)
		Me.Controls.Add(_Label1_3)
		Me.Controls.Add(_Label1_1)
		Me.Controls.Add(_Label1_0)
		Me.lvwCategorie.Columns.Add(_lvwCategorie_ColumnHeader_1)
		Me.lvwRechercheAchat.Columns.Add(_lvwRechercheAchat_ColumnHeader_1)
		Me.lvwRechercheAchat.Columns.Add(_lvwRechercheAchat_ColumnHeader_2)
		Me.lvwRechercheJob.Columns.Add(_lvwRechercheJob_ColumnHeader_1)
		Me.lvwRechercheJob.Columns.Add(_lvwRechercheJob_ColumnHeader_2)
		Me.lvwFabricant.Columns.Add(_lvwFabricant_ColumnHeader_1)
		Me.lvwFabricant.Columns.Add(_lvwFabricant_ColumnHeader_2)
		Me.lvwFabricant.Columns.Add(_lvwFabricant_ColumnHeader_3)
		Me.lvwFabricant.Columns.Add(_lvwFabricant_ColumnHeader_4)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_1)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_2)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_3)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_4)
		Me.lvwDescription.Columns.Add(_lvwDescription_ColumnHeader_1)
		Me.lvwDescription.Columns.Add(_lvwDescription_ColumnHeader_2)
		Me.lvwDescription.Columns.Add(_lvwDescription_ColumnHeader_3)
		Me.lvwDescription.Columns.Add(_lvwDescription_ColumnHeader_4)
		Me.frafournisseur.Controls.Add(txtTauxChange)
		Me.frafournisseur.Controls.Add(lvwfournisseur)
		Me.frafournisseur.Controls.Add(cmdAddFrs)
		Me.frafournisseur.Controls.Add(cmdSuppFrs)
		Me.frafournisseur.Controls.Add(cmdModifFrs)
		Me.frafournisseur.Controls.Add(chkquoter)
		Me.frafournisseur.Controls.Add(optUSA)
		Me.frafournisseur.Controls.Add(optCAN)
		Me.frafournisseur.Controls.Add(txtPrixList)
		Me.frafournisseur.Controls.Add(txtPrixNet)
		Me.frafournisseur.Controls.Add(txtPrixSpecial)
		Me.frafournisseur.Controls.Add(mskValide)
		Me.frafournisseur.Controls.Add(mskEscompte)
		Me.frafournisseur.Controls.Add(cmdEnrFrs)
		Me.frafournisseur.Controls.Add(cmdAnnulFrs)
		Me.frafournisseur.Controls.Add(cmbfrs)
		Me.frafournisseur.Controls.Add(cmbPersRess)
		Me.frafournisseur.Controls.Add(optSpain)
		Me.frafournisseur.Controls.Add(lblDevise1)
		Me.frafournisseur.Controls.Add(lblDevise2)
		Me.frafournisseur.Controls.Add(_Label1_5)
		Me.frafournisseur.Controls.Add(imgCanada)
		Me.frafournisseur.Controls.Add(imgEU)
		Me.frafournisseur.Controls.Add(_Label1_14)
		Me.frafournisseur.Controls.Add(_Label1_16)
		Me.frafournisseur.Controls.Add(_Label1_19)
		Me.frafournisseur.Controls.Add(_Label1_24)
		Me.frafournisseur.Controls.Add(_Label1_20)
		Me.frafournisseur.Controls.Add(_Label1_2)
		Me.frafournisseur.Controls.Add(_Label1_23)
		Me.frafournisseur.Controls.Add(imgSpain)
		Me.lvwfournisseur.Columns.Add(_lvwfournisseur_ColumnHeader_1)
		Me.lvwfournisseur.Columns.Add(_lvwfournisseur_ColumnHeader_2)
		Me.lvwfournisseur.Columns.Add(_lvwfournisseur_ColumnHeader_3)
		Me.lvwfournisseur.Columns.Add(_lvwfournisseur_ColumnHeader_4)
		Me.lvwfournisseur.Columns.Add(_lvwfournisseur_ColumnHeader_5)
		Me.lvwfournisseur.Columns.Add(_lvwfournisseur_ColumnHeader_6)
		Me.lvwfournisseur.Columns.Add(_lvwfournisseur_ColumnHeader_7)
		Me.lvwfournisseur.Columns.Add(_lvwfournisseur_ColumnHeader_8)
		Me.lvwfournisseur.Columns.Add(_lvwfournisseur_ColumnHeader_9)
		Me.lvwfournisseur.Columns.Add(_lvwfournisseur_ColumnHeader_10)
		Me.fraQuantité.Controls.Add(txtQuantiteCommande)
		Me.fraQuantité.Controls.Add(chkMinimum)
		Me.fraQuantité.Controls.Add(txtQuantiteStock)
		Me.fraQuantité.Controls.Add(txtQuantiteMinimum)
		Me.fraQuantité.Controls.Add(txtQuantitéBoite)
		Me.fraQuantité.Controls.Add(chkBoite)
		Me.fraQuantité.Controls.Add(Label11)
		Me.fraQuantité.Controls.Add(Label5)
		Me.Label1.SetIndex(_Label1_5, CType(5, Short))
		Me.Label1.SetIndex(_Label1_14, CType(14, Short))
		Me.Label1.SetIndex(_Label1_16, CType(16, Short))
		Me.Label1.SetIndex(_Label1_19, CType(19, Short))
		Me.Label1.SetIndex(_Label1_24, CType(24, Short))
		Me.Label1.SetIndex(_Label1_20, CType(20, Short))
		Me.Label1.SetIndex(_Label1_2, CType(2, Short))
		Me.Label1.SetIndex(_Label1_23, CType(23, Short))
		Me.Label1.SetIndex(_Label1_25, CType(25, Short))
		Me.Label1.SetIndex(_Label1_6, CType(6, Short))
		Me.Label1.SetIndex(_Label1_4, CType(4, Short))
		Me.Label1.SetIndex(_Label1_3, CType(3, Short))
		Me.Label1.SetIndex(_Label1_1, CType(1, Short))
		Me.Label1.SetIndex(_Label1_0, CType(0, Short))
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.lvwCategorie.ResumeLayout(False)
		Me.lvwRechercheAchat.ResumeLayout(False)
		Me.lvwRechercheJob.ResumeLayout(False)
		Me.lvwFabricant.ResumeLayout(False)
		Me.lvwPieces.ResumeLayout(False)
		Me.lvwDescription.ResumeLayout(False)
		Me.frafournisseur.ResumeLayout(False)
		Me.lvwfournisseur.ResumeLayout(False)
		Me.fraQuantité.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class