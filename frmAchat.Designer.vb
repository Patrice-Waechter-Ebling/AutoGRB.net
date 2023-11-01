<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmAchat
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
	Public WithEvents mnuDateRequise As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuRightClick As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	Public WithEvents cmdOKDateRequise As System.Windows.Forms.Button
	Public WithEvents cmdAnnulerDateRequise As System.Windows.Forms.Button
	Public WithEvents mvwDateRequise As AxMSComCtl2.AxMonthView
	Public WithEvents fraDateRequise As System.Windows.Forms.GroupBox
	Public WithEvents cmdOKPieceTrouve As System.Windows.Forms.Button
	Public WithEvents cmdAnnulerPieceTrouve As System.Windows.Forms.Button
	Public WithEvents _lvwPieceTrouve_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieceTrouve_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieceTrouve_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieceTrouve_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieceTrouve_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieceTrouve_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwPieceTrouve As System.Windows.Forms.ListView
	Public WithEvents fraPieceTrouve As System.Windows.Forms.GroupBox
	Public WithEvents cmdAnnulerPrix As System.Windows.Forms.Button
	Public WithEvents cmdOKPrix As System.Windows.Forms.Button
	Public WithEvents optSpain As System.Windows.Forms.RadioButton
	Public WithEvents optCAN As System.Windows.Forms.RadioButton
	Public WithEvents optUSA As System.Windows.Forms.RadioButton
	Public WithEvents cmbfrs As System.Windows.Forms.ComboBox
	Public WithEvents txtPrixNet As System.Windows.Forms.TextBox
	Public WithEvents txtPrixList As System.Windows.Forms.TextBox
	Public WithEvents txtPrixSpecial As System.Windows.Forms.TextBox
	Public WithEvents mskEscompte As System.Windows.Forms.MaskedTextBox
	Public WithEvents imgEU As System.Windows.Forms.PictureBox
	Public WithEvents imgSpain As System.Windows.Forms.PictureBox
	Public WithEvents _Label1_5 As System.Windows.Forms.Label
	Public WithEvents _Label1_4 As System.Windows.Forms.Label
	Public WithEvents _Label1_3 As System.Windows.Forms.Label
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents imgCanada As System.Windows.Forms.PictureBox
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents fraPrixPiece As System.Windows.Forms.GroupBox
	Public WithEvents cmdReception As System.Windows.Forms.Button
	Public WithEvents cmdAnnulerInventaire As System.Windows.Forms.Button
	Public WithEvents cmdOKInventaire As System.Windows.Forms.Button
	Public WithEvents _lvwInventaire_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwInventaire_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwInventaire_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwInventaire_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwInventaire_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwInventaire_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwInventaire_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwInventaire As System.Windows.Forms.ListView
	Public WithEvents fraInventaire As System.Windows.Forms.GroupBox
	Public WithEvents cmdInventaire As System.Windows.Forms.Button
	Public WithEvents cmdReset As System.Windows.Forms.Button
	Public WithEvents cmdRetour As System.Windows.Forms.Button
	Public WithEvents cmdDemande As System.Windows.Forms.Button
	Public WithEvents cmdTri As System.Windows.Forms.Button
	Public WithEvents txtPrixTotal As System.Windows.Forms.TextBox
	Public WithEvents cmdRafraichir As System.Windows.Forms.Button
	Public WithEvents cmbTri As System.Windows.Forms.ComboBox
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	Public WithEvents cmdAjouter As System.Windows.Forms.Button
	Public WithEvents cmbCategorie As System.Windows.Forms.ComboBox
	Public WithEvents txtRaison As System.Windows.Forms.TextBox
	Public WithEvents cmbNoAchat As System.Windows.Forms.ComboBox
	Public WithEvents _lvwFournisseur_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_8 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_9 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_10 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwFournisseur As System.Windows.Forms.ListView
	Public WithEvents fraFournisseur As System.Windows.Forms.GroupBox
	Public WithEvents cmdModifier As System.Windows.Forms.Button
	Public WithEvents cmdSupprimer As System.Windows.Forms.Button
	Public WithEvents cmdImprimer As System.Windows.Forms.Button
	Public WithEvents txtAcheteur As System.Windows.Forms.TextBox
	Public WithEvents cmdBonCommande As System.Windows.Forms.Button
	Public WithEvents _lvwAchat_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwAchat_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwAchat_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwAchat_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwAchat_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwAchat_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwAchat_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwAchat_ColumnHeader_8 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwAchat_ColumnHeader_9 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwAchat_ColumnHeader_10 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwAchat_ColumnHeader_11 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwAchat As System.Windows.Forms.ListView
	Public WithEvents _lvwPieces_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwPieces As System.Windows.Forms.ListView
	Public WithEvents txtNoAchat As System.Windows.Forms.TextBox
	Public WithEvents txtDate As System.Windows.Forms.TextBox
	Public WithEvents cmdEnregistrer As System.Windows.Forms.Button
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents cmdMaterielInutile As System.Windows.Forms.Button
	Public WithEvents cmdMauvaisPrix As System.Windows.Forms.Button
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents lblPrixTotal As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents lblTri As System.Windows.Forms.Label
	Public WithEvents lblRaison As System.Windows.Forms.Label
	Public WithEvents lblCategorie As System.Windows.Forms.Label
	Public WithEvents lblNoSoumission As System.Windows.Forms.Label
	Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAchat))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.MainMenu1 = New System.Windows.Forms.MenuStrip
		Me.mnuRightClick = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuDateRequise = New System.Windows.Forms.ToolStripMenuItem
		Me.fraDateRequise = New System.Windows.Forms.GroupBox
		Me.cmdOKDateRequise = New System.Windows.Forms.Button
		Me.cmdAnnulerDateRequise = New System.Windows.Forms.Button
		Me.mvwDateRequise = New AxMSComCtl2.AxMonthView
		Me.fraPieceTrouve = New System.Windows.Forms.GroupBox
		Me.cmdOKPieceTrouve = New System.Windows.Forms.Button
		Me.cmdAnnulerPieceTrouve = New System.Windows.Forms.Button
		Me.lvwPieceTrouve = New System.Windows.Forms.ListView
		Me._lvwPieceTrouve_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieceTrouve_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieceTrouve_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieceTrouve_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieceTrouve_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieceTrouve_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me.fraPrixPiece = New System.Windows.Forms.GroupBox
		Me.cmdAnnulerPrix = New System.Windows.Forms.Button
		Me.cmdOKPrix = New System.Windows.Forms.Button
		Me.optSpain = New System.Windows.Forms.RadioButton
		Me.optCAN = New System.Windows.Forms.RadioButton
		Me.optUSA = New System.Windows.Forms.RadioButton
		Me.cmbfrs = New System.Windows.Forms.ComboBox
		Me.txtPrixNet = New System.Windows.Forms.TextBox
		Me.txtPrixList = New System.Windows.Forms.TextBox
		Me.txtPrixSpecial = New System.Windows.Forms.TextBox
		Me.mskEscompte = New System.Windows.Forms.MaskedTextBox
		Me.imgEU = New System.Windows.Forms.PictureBox
		Me.imgSpain = New System.Windows.Forms.PictureBox
		Me._Label1_5 = New System.Windows.Forms.Label
		Me._Label1_4 = New System.Windows.Forms.Label
		Me._Label1_3 = New System.Windows.Forms.Label
		Me._Label1_2 = New System.Windows.Forms.Label
		Me.imgCanada = New System.Windows.Forms.PictureBox
		Me._Label1_1 = New System.Windows.Forms.Label
		Me.cmdReception = New System.Windows.Forms.Button
		Me.fraInventaire = New System.Windows.Forms.GroupBox
		Me.cmdAnnulerInventaire = New System.Windows.Forms.Button
		Me.cmdOKInventaire = New System.Windows.Forms.Button
		Me.lvwInventaire = New System.Windows.Forms.ListView
		Me._lvwInventaire_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwInventaire_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwInventaire_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwInventaire_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwInventaire_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvwInventaire_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me._lvwInventaire_ColumnHeader_7 = New System.Windows.Forms.ColumnHeader
		Me.cmdInventaire = New System.Windows.Forms.Button
		Me.cmdReset = New System.Windows.Forms.Button
		Me.cmdRetour = New System.Windows.Forms.Button
		Me.cmdDemande = New System.Windows.Forms.Button
		Me.cmdTri = New System.Windows.Forms.Button
		Me.txtPrixTotal = New System.Windows.Forms.TextBox
		Me.cmdRafraichir = New System.Windows.Forms.Button
		Me.cmbTri = New System.Windows.Forms.ComboBox
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.cmdAjouter = New System.Windows.Forms.Button
		Me.cmbCategorie = New System.Windows.Forms.ComboBox
		Me.txtRaison = New System.Windows.Forms.TextBox
		Me.cmbNoAchat = New System.Windows.Forms.ComboBox
		Me.fraFournisseur = New System.Windows.Forms.GroupBox
		Me.lvwFournisseur = New System.Windows.Forms.ListView
		Me._lvwFournisseur_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_7 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_8 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_9 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_10 = New System.Windows.Forms.ColumnHeader
		Me.cmdModifier = New System.Windows.Forms.Button
		Me.cmdSupprimer = New System.Windows.Forms.Button
		Me.cmdImprimer = New System.Windows.Forms.Button
		Me.txtAcheteur = New System.Windows.Forms.TextBox
		Me.cmdBonCommande = New System.Windows.Forms.Button
		Me.lvwAchat = New System.Windows.Forms.ListView
		Me._lvwAchat_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwAchat_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwAchat_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwAchat_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwAchat_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvwAchat_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me._lvwAchat_ColumnHeader_7 = New System.Windows.Forms.ColumnHeader
		Me._lvwAchat_ColumnHeader_8 = New System.Windows.Forms.ColumnHeader
		Me._lvwAchat_ColumnHeader_9 = New System.Windows.Forms.ColumnHeader
		Me._lvwAchat_ColumnHeader_10 = New System.Windows.Forms.ColumnHeader
		Me._lvwAchat_ColumnHeader_11 = New System.Windows.Forms.ColumnHeader
		Me.lvwPieces = New System.Windows.Forms.ListView
		Me._lvwPieces_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me.txtNoAchat = New System.Windows.Forms.TextBox
		Me.txtDate = New System.Windows.Forms.TextBox
		Me.cmdEnregistrer = New System.Windows.Forms.Button
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.cmdMaterielInutile = New System.Windows.Forms.Button
		Me.cmdMauvaisPrix = New System.Windows.Forms.Button
		Me.Label2 = New System.Windows.Forms.Label
		Me.lblPrixTotal = New System.Windows.Forms.Label
		Me._Label1_0 = New System.Windows.Forms.Label
		Me.lblTri = New System.Windows.Forms.Label
		Me.lblRaison = New System.Windows.Forms.Label
		Me.lblCategorie = New System.Windows.Forms.Label
		Me.lblNoSoumission = New System.Windows.Forms.Label
		Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.MainMenu1.SuspendLayout()
		Me.fraDateRequise.SuspendLayout()
		Me.fraPieceTrouve.SuspendLayout()
		Me.lvwPieceTrouve.SuspendLayout()
		Me.fraPrixPiece.SuspendLayout()
		Me.fraInventaire.SuspendLayout()
		Me.lvwInventaire.SuspendLayout()
		Me.fraFournisseur.SuspendLayout()
		Me.lvwFournisseur.SuspendLayout()
		Me.lvwAchat.SuspendLayout()
		Me.lvwPieces.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.mvwDateRequise, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.ClientSize = New System.Drawing.Size(894, 519)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmAchat.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "frmAchat"
		Me.mnuRightClick.Name = "mnuRightClick"
		Me.mnuRightClick.Text = ""
		Me.mnuRightClick.Visible = False
		Me.mnuRightClick.Checked = False
		Me.mnuRightClick.Enabled = True
		Me.mnuDateRequise.Name = "mnuDateRequise"
		Me.mnuDateRequise.Text = "Modifier la date requise"
		Me.mnuDateRequise.Checked = False
		Me.mnuDateRequise.Enabled = True
		Me.mnuDateRequise.Visible = True
		Me.fraDateRequise.BackColor = System.Drawing.Color.Black
		Me.fraDateRequise.Text = "Date Requise"
		Me.fraDateRequise.ForeColor = System.Drawing.Color.White
		Me.fraDateRequise.Size = New System.Drawing.Size(321, 193)
		Me.fraDateRequise.Location = New System.Drawing.Point(296, 304)
		Me.fraDateRequise.TabIndex = 60
		Me.fraDateRequise.Visible = False
		Me.fraDateRequise.Enabled = True
		Me.fraDateRequise.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraDateRequise.Padding = New System.Windows.Forms.Padding(0)
		Me.fraDateRequise.Name = "fraDateRequise"
		Me.cmdOKDateRequise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOKDateRequise.Text = "OK"
		Me.cmdOKDateRequise.Size = New System.Drawing.Size(73, 25)
		Me.cmdOKDateRequise.Location = New System.Drawing.Point(232, 48)
		Me.cmdOKDateRequise.TabIndex = 62
		Me.cmdOKDateRequise.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOKDateRequise.CausesValidation = True
		Me.cmdOKDateRequise.Enabled = True
		Me.cmdOKDateRequise.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOKDateRequise.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOKDateRequise.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOKDateRequise.TabStop = True
		Me.cmdOKDateRequise.Name = "cmdOKDateRequise"
		Me.cmdAnnulerDateRequise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnulerDateRequise.Text = "Annuler"
		Me.cmdAnnulerDateRequise.Size = New System.Drawing.Size(73, 25)
		Me.cmdAnnulerDateRequise.Location = New System.Drawing.Point(232, 80)
		Me.cmdAnnulerDateRequise.TabIndex = 61
		Me.cmdAnnulerDateRequise.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnulerDateRequise.CausesValidation = True
		Me.cmdAnnulerDateRequise.Enabled = True
		Me.cmdAnnulerDateRequise.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnulerDateRequise.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnulerDateRequise.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnulerDateRequise.TabStop = True
		Me.cmdAnnulerDateRequise.Name = "cmdAnnulerDateRequise"
		mvwDateRequise.OcxState = CType(resources.GetObject("mvwDateRequise.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwDateRequise.Size = New System.Drawing.Size(176, 158)
		Me.mvwDateRequise.Location = New System.Drawing.Point(40, 24)
		Me.mvwDateRequise.TabIndex = 63
		Me.mvwDateRequise.Name = "mvwDateRequise"
		Me.fraPieceTrouve.BackColor = System.Drawing.Color.Black
		Me.fraPieceTrouve.Text = "Pièces trouvées"
		Me.fraPieceTrouve.ForeColor = System.Drawing.Color.White
		Me.fraPieceTrouve.Size = New System.Drawing.Size(689, 185)
		Me.fraPieceTrouve.Location = New System.Drawing.Point(104, 104)
		Me.fraPieceTrouve.TabIndex = 13
		Me.fraPieceTrouve.Visible = False
		Me.fraPieceTrouve.Enabled = True
		Me.fraPieceTrouve.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraPieceTrouve.Padding = New System.Windows.Forms.Padding(0)
		Me.fraPieceTrouve.Name = "fraPieceTrouve"
		Me.cmdOKPieceTrouve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOKPieceTrouve.Text = "OK"
		Me.cmdOKPieceTrouve.Size = New System.Drawing.Size(73, 25)
		Me.cmdOKPieceTrouve.Location = New System.Drawing.Point(608, 152)
		Me.cmdOKPieceTrouve.TabIndex = 16
		Me.cmdOKPieceTrouve.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOKPieceTrouve.CausesValidation = True
		Me.cmdOKPieceTrouve.Enabled = True
		Me.cmdOKPieceTrouve.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOKPieceTrouve.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOKPieceTrouve.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOKPieceTrouve.TabStop = True
		Me.cmdOKPieceTrouve.Name = "cmdOKPieceTrouve"
		Me.cmdAnnulerPieceTrouve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnulerPieceTrouve.Text = "Annuler"
		Me.cmdAnnulerPieceTrouve.Size = New System.Drawing.Size(73, 25)
		Me.cmdAnnulerPieceTrouve.Location = New System.Drawing.Point(528, 152)
		Me.cmdAnnulerPieceTrouve.TabIndex = 15
		Me.cmdAnnulerPieceTrouve.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnulerPieceTrouve.CausesValidation = True
		Me.cmdAnnulerPieceTrouve.Enabled = True
		Me.cmdAnnulerPieceTrouve.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnulerPieceTrouve.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnulerPieceTrouve.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnulerPieceTrouve.TabStop = True
		Me.cmdAnnulerPieceTrouve.Name = "cmdAnnulerPieceTrouve"
		Me.lvwPieceTrouve.Size = New System.Drawing.Size(673, 129)
		Me.lvwPieceTrouve.Location = New System.Drawing.Point(8, 16)
		Me.lvwPieceTrouve.TabIndex = 14
		Me.lvwPieceTrouve.View = System.Windows.Forms.View.Details
		Me.lvwPieceTrouve.LabelEdit = False
		Me.lvwPieceTrouve.LabelWrap = True
		Me.lvwPieceTrouve.HideSelection = True
		Me.lvwPieceTrouve.FullRowSelect = True
		Me.lvwPieceTrouve.GridLines = True
		Me.lvwPieceTrouve.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwPieceTrouve.BackColor = System.Drawing.SystemColors.Window
		Me.lvwPieceTrouve.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwPieceTrouve.Name = "lvwPieceTrouve"
		Me._lvwPieceTrouve_ColumnHeader_1.Text = "PIECE_GRB"
		Me._lvwPieceTrouve_ColumnHeader_1.Width = 161
		Me._lvwPieceTrouve_ColumnHeader_2.Text = "No. d'item"
		Me._lvwPieceTrouve_ColumnHeader_2.Width = 217
		Me._lvwPieceTrouve_ColumnHeader_3.Text = "Catégorie"
		Me._lvwPieceTrouve_ColumnHeader_3.Width = 170
		Me._lvwPieceTrouve_ColumnHeader_4.Text = "Manufacturier"
		Me._lvwPieceTrouve_ColumnHeader_4.Width = 136
		Me._lvwPieceTrouve_ColumnHeader_5.Text = "Description française"
		Me._lvwPieceTrouve_ColumnHeader_5.Width = 477
		Me._lvwPieceTrouve_ColumnHeader_6.Text = "Description anglaise"
		Me._lvwPieceTrouve_ColumnHeader_6.Width = 477
		Me.fraPrixPiece.BackColor = System.Drawing.Color.Black
		Me.fraPrixPiece.Text = "Fournisseurs"
		Me.fraPrixPiece.ForeColor = System.Drawing.Color.White
		Me.fraPrixPiece.Size = New System.Drawing.Size(593, 153)
		Me.fraPrixPiece.Location = New System.Drawing.Point(56, 320)
		Me.fraPrixPiece.TabIndex = 44
		Me.fraPrixPiece.Visible = False
		Me.fraPrixPiece.Enabled = True
		Me.fraPrixPiece.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraPrixPiece.Padding = New System.Windows.Forms.Padding(0)
		Me.fraPrixPiece.Name = "fraPrixPiece"
		Me.cmdAnnulerPrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnulerPrix.Text = "Annuler"
		Me.cmdAnnulerPrix.Size = New System.Drawing.Size(73, 25)
		Me.cmdAnnulerPrix.Location = New System.Drawing.Point(416, 120)
		Me.cmdAnnulerPrix.TabIndex = 53
		Me.cmdAnnulerPrix.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnulerPrix.CausesValidation = True
		Me.cmdAnnulerPrix.Enabled = True
		Me.cmdAnnulerPrix.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnulerPrix.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnulerPrix.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnulerPrix.TabStop = True
		Me.cmdAnnulerPrix.Name = "cmdAnnulerPrix"
		Me.cmdOKPrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOKPrix.Text = "OK"
		Me.cmdOKPrix.Size = New System.Drawing.Size(73, 25)
		Me.cmdOKPrix.Location = New System.Drawing.Point(496, 120)
		Me.cmdOKPrix.TabIndex = 52
		Me.cmdOKPrix.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOKPrix.CausesValidation = True
		Me.cmdOKPrix.Enabled = True
		Me.cmdOKPrix.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOKPrix.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOKPrix.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOKPrix.TabStop = True
		Me.cmdOKPrix.Name = "cmdOKPrix"
		Me.optSpain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optSpain.BackColor = System.Drawing.Color.Black
		Me.optSpain.Text = "SPA"
		Me.optSpain.ForeColor = System.Drawing.Color.White
		Me.optSpain.Size = New System.Drawing.Size(49, 17)
		Me.optSpain.Location = New System.Drawing.Point(536, 16)
		Me.optSpain.TabIndex = 51
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
		Me.optCAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optCAN.BackColor = System.Drawing.Color.Black
		Me.optCAN.Text = "CAN"
		Me.optCAN.ForeColor = System.Drawing.Color.White
		Me.optCAN.Size = New System.Drawing.Size(49, 17)
		Me.optCAN.Location = New System.Drawing.Point(440, 16)
		Me.optCAN.TabIndex = 50
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
		Me.optUSA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optUSA.BackColor = System.Drawing.Color.Black
		Me.optUSA.Text = "USA"
		Me.optUSA.ForeColor = System.Drawing.Color.White
		Me.optUSA.Size = New System.Drawing.Size(49, 17)
		Me.optUSA.Location = New System.Drawing.Point(488, 16)
		Me.optUSA.TabIndex = 49
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
		Me.cmbfrs.Size = New System.Drawing.Size(185, 21)
		Me.cmbfrs.Location = New System.Drawing.Point(16, 32)
		Me.cmbfrs.TabIndex = 48
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
		Me.txtPrixNet.AutoSize = False
		Me.txtPrixNet.BackColor = System.Drawing.Color.White
		Me.txtPrixNet.Size = New System.Drawing.Size(57, 19)
		Me.txtPrixNet.Location = New System.Drawing.Point(328, 80)
		Me.txtPrixNet.TabIndex = 47
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
		Me.txtPrixList.AutoSize = False
		Me.txtPrixList.BackColor = System.Drawing.Color.White
		Me.txtPrixList.Size = New System.Drawing.Size(73, 19)
		Me.txtPrixList.Location = New System.Drawing.Point(328, 32)
		Me.txtPrixList.TabIndex = 46
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
		Me.txtPrixSpecial.AutoSize = False
		Me.txtPrixSpecial.BackColor = System.Drawing.Color.White
		Me.txtPrixSpecial.Size = New System.Drawing.Size(57, 19)
		Me.txtPrixSpecial.Location = New System.Drawing.Point(328, 104)
		Me.txtPrixSpecial.TabIndex = 45
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
		Me.mskEscompte.AllowPromptAsInput = False
		Me.mskEscompte.Size = New System.Drawing.Size(57, 17)
		Me.mskEscompte.Location = New System.Drawing.Point(328, 56)
		Me.mskEscompte.TabIndex = 54
		Me.mskEscompte.PromptChar = "_"
		Me.mskEscompte.Name = "mskEscompte"
		Me.imgEU.Size = New System.Drawing.Size(112, 71)
		Me.imgEU.Location = New System.Drawing.Point(456, 40)
		Me.imgEU.Image = CType(resources.GetObject("imgEU.Image"), System.Drawing.Image)
		Me.imgEU.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.imgEU.Visible = False
		Me.imgEU.Enabled = True
		Me.imgEU.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgEU.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.imgEU.Name = "imgEU"
		Me.imgSpain.Size = New System.Drawing.Size(112, 71)
		Me.imgSpain.Location = New System.Drawing.Point(456, 40)
		Me.imgSpain.Image = CType(resources.GetObject("imgSpain.Image"), System.Drawing.Image)
		Me.imgSpain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.imgSpain.Visible = False
		Me.imgSpain.Enabled = True
		Me.imgSpain.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgSpain.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.imgSpain.Name = "imgSpain"
		Me._Label1_5.Text = "Prix Net :"
		Me._Label1_5.ForeColor = System.Drawing.Color.White
		Me._Label1_5.Size = New System.Drawing.Size(73, 17)
		Me._Label1_5.Location = New System.Drawing.Point(248, 80)
		Me._Label1_5.TabIndex = 59
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
		Me._Label1_4.Text = "Escompte :"
		Me._Label1_4.ForeColor = System.Drawing.Color.White
		Me._Label1_4.Size = New System.Drawing.Size(73, 17)
		Me._Label1_4.Location = New System.Drawing.Point(248, 56)
		Me._Label1_4.TabIndex = 58
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
		Me._Label1_3.Text = "Prix Listé :"
		Me._Label1_3.ForeColor = System.Drawing.Color.White
		Me._Label1_3.Size = New System.Drawing.Size(65, 17)
		Me._Label1_3.Location = New System.Drawing.Point(248, 32)
		Me._Label1_3.TabIndex = 57
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
		Me._Label1_2.Text = "Distributeur :"
		Me._Label1_2.ForeColor = System.Drawing.Color.White
		Me._Label1_2.Size = New System.Drawing.Size(81, 17)
		Me._Label1_2.Location = New System.Drawing.Point(16, 16)
		Me._Label1_2.TabIndex = 56
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
		Me.imgCanada.Size = New System.Drawing.Size(112, 71)
		Me.imgCanada.Location = New System.Drawing.Point(456, 40)
		Me.imgCanada.Image = CType(resources.GetObject("imgCanada.Image"), System.Drawing.Image)
		Me.imgCanada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.imgCanada.Visible = False
		Me.imgCanada.Enabled = True
		Me.imgCanada.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgCanada.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.imgCanada.Name = "imgCanada"
		Me._Label1_1.Text = "Prix Spécial :"
		Me._Label1_1.ForeColor = System.Drawing.Color.White
		Me._Label1_1.Size = New System.Drawing.Size(81, 17)
		Me._Label1_1.Location = New System.Drawing.Point(248, 104)
		Me._Label1_1.TabIndex = 55
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
		Me.cmdReception.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdReception.Text = "Réception"
		Me.cmdReception.Size = New System.Drawing.Size(65, 25)
		Me.cmdReception.Location = New System.Drawing.Point(176, 488)
		Me.cmdReception.TabIndex = 43
		Me.cmdReception.BackColor = System.Drawing.SystemColors.Control
		Me.cmdReception.CausesValidation = True
		Me.cmdReception.Enabled = True
		Me.cmdReception.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdReception.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdReception.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdReception.TabStop = True
		Me.cmdReception.Name = "cmdReception"
		Me.fraInventaire.BackColor = System.Drawing.Color.Black
		Me.fraInventaire.Text = "Inventaire à commander"
		Me.fraInventaire.ForeColor = System.Drawing.Color.White
		Me.fraInventaire.Size = New System.Drawing.Size(881, 209)
		Me.fraInventaire.Location = New System.Drawing.Point(8, 104)
		Me.fraInventaire.TabIndex = 18
		Me.fraInventaire.Visible = False
		Me.fraInventaire.Enabled = True
		Me.fraInventaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraInventaire.Padding = New System.Windows.Forms.Padding(0)
		Me.fraInventaire.Name = "fraInventaire"
		Me.cmdAnnulerInventaire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnulerInventaire.Text = "Annuler"
		Me.cmdAnnulerInventaire.Size = New System.Drawing.Size(81, 25)
		Me.cmdAnnulerInventaire.Location = New System.Drawing.Point(704, 176)
		Me.cmdAnnulerInventaire.TabIndex = 20
		Me.cmdAnnulerInventaire.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnulerInventaire.CausesValidation = True
		Me.cmdAnnulerInventaire.Enabled = True
		Me.cmdAnnulerInventaire.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnulerInventaire.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnulerInventaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnulerInventaire.TabStop = True
		Me.cmdAnnulerInventaire.Name = "cmdAnnulerInventaire"
		Me.cmdOKInventaire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOKInventaire.Text = "OK"
		Me.cmdOKInventaire.Size = New System.Drawing.Size(81, 25)
		Me.cmdOKInventaire.Location = New System.Drawing.Point(792, 176)
		Me.cmdOKInventaire.TabIndex = 21
		Me.cmdOKInventaire.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOKInventaire.CausesValidation = True
		Me.cmdOKInventaire.Enabled = True
		Me.cmdOKInventaire.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOKInventaire.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOKInventaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOKInventaire.TabStop = True
		Me.cmdOKInventaire.Name = "cmdOKInventaire"
		Me.lvwInventaire.Size = New System.Drawing.Size(865, 153)
		Me.lvwInventaire.Location = New System.Drawing.Point(8, 16)
		Me.lvwInventaire.TabIndex = 19
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
		Me._lvwInventaire_ColumnHeader_1.Text = "No. d'item"
		Me._lvwInventaire_ColumnHeader_1.Width = 217
		Me._lvwInventaire_ColumnHeader_2.Text = "Manufacturier"
		Me._lvwInventaire_ColumnHeader_2.Width = 136
		Me._lvwInventaire_ColumnHeader_3.Text = "Description"
		Me._lvwInventaire_ColumnHeader_3.Width = 477
		Me._lvwInventaire_ColumnHeader_4.Text = "Commentaire"
		Me._lvwInventaire_ColumnHeader_4.Width = 170
		Me._lvwInventaire_ColumnHeader_5.Text = "Qté en stock"
		Me._lvwInventaire_ColumnHeader_5.Width = 170
		Me._lvwInventaire_ColumnHeader_6.Text = "Qté minimum"
		Me._lvwInventaire_ColumnHeader_6.Width = 170
		Me._lvwInventaire_ColumnHeader_7.Text = "Qté à commander"
		Me._lvwInventaire_ColumnHeader_7.Width = 170
		Me.cmdInventaire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdInventaire.Text = "Inventaire à commander"
		Me.cmdInventaire.Size = New System.Drawing.Size(137, 25)
		Me.cmdInventaire.Location = New System.Drawing.Point(752, 112)
		Me.cmdInventaire.TabIndex = 24
		Me.cmdInventaire.BackColor = System.Drawing.SystemColors.Control
		Me.cmdInventaire.CausesValidation = True
		Me.cmdInventaire.Enabled = True
		Me.cmdInventaire.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdInventaire.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdInventaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdInventaire.TabStop = True
		Me.cmdInventaire.Name = "cmdInventaire"
		Me.cmdReset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdReset.Text = "Reset"
		Me.cmdReset.Size = New System.Drawing.Size(65, 25)
		Me.cmdReset.Location = New System.Drawing.Point(96, 488)
		Me.cmdReset.TabIndex = 31
		Me.cmdReset.BackColor = System.Drawing.SystemColors.Control
		Me.cmdReset.CausesValidation = True
		Me.cmdReset.Enabled = True
		Me.cmdReset.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdReset.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdReset.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdReset.TabStop = True
		Me.cmdReset.Name = "cmdReset"
		Me.cmdRetour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRetour.Text = "Retour"
		Me.cmdRetour.Size = New System.Drawing.Size(65, 25)
		Me.cmdRetour.Location = New System.Drawing.Point(248, 488)
		Me.cmdRetour.TabIndex = 32
		Me.cmdRetour.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRetour.CausesValidation = True
		Me.cmdRetour.Enabled = True
		Me.cmdRetour.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRetour.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRetour.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRetour.TabStop = True
		Me.cmdRetour.Name = "cmdRetour"
		Me.cmdDemande.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDemande.Text = "Demande de prix"
		Me.cmdDemande.Size = New System.Drawing.Size(105, 25)
		Me.cmdDemande.Location = New System.Drawing.Point(320, 488)
		Me.cmdDemande.TabIndex = 33
		Me.cmdDemande.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDemande.CausesValidation = True
		Me.cmdDemande.Enabled = True
		Me.cmdDemande.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDemande.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDemande.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDemande.TabStop = True
		Me.cmdDemande.Name = "cmdDemande"
		Me.cmdTri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdTri.Text = "Trier"
		Me.cmdTri.Size = New System.Drawing.Size(65, 21)
		Me.cmdTri.Location = New System.Drawing.Point(496, 116)
		Me.cmdTri.TabIndex = 25
		Me.cmdTri.BackColor = System.Drawing.SystemColors.Control
		Me.cmdTri.CausesValidation = True
		Me.cmdTri.Enabled = True
		Me.cmdTri.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdTri.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdTri.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdTri.TabStop = True
		Me.cmdTri.Name = "cmdTri"
		Me.txtPrixTotal.AutoSize = False
		Me.txtPrixTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtPrixTotal.BackColor = System.Drawing.Color.White
		Me.txtPrixTotal.ForeColor = System.Drawing.Color.Red
		Me.txtPrixTotal.Size = New System.Drawing.Size(89, 20)
		Me.txtPrixTotal.Location = New System.Drawing.Point(600, 80)
		Me.txtPrixTotal.ReadOnly = True
		Me.txtPrixTotal.TabIndex = 6
		Me.txtPrixTotal.Text = "0"
		Me.txtPrixTotal.AcceptsReturn = True
		Me.txtPrixTotal.CausesValidation = True
		Me.txtPrixTotal.Enabled = True
		Me.txtPrixTotal.HideSelection = True
		Me.txtPrixTotal.Maxlength = 0
		Me.txtPrixTotal.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPrixTotal.MultiLine = False
		Me.txtPrixTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPrixTotal.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPrixTotal.TabStop = True
		Me.txtPrixTotal.Visible = True
		Me.txtPrixTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPrixTotal.Name = "txtPrixTotal"
		Me.cmdRafraichir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRafraichir.Text = "Rafraichir"
		Me.cmdRafraichir.Size = New System.Drawing.Size(65, 21)
		Me.cmdRafraichir.Location = New System.Drawing.Point(496, 96)
		Me.cmdRafraichir.TabIndex = 12
		Me.cmdRafraichir.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRafraichir.CausesValidation = True
		Me.cmdRafraichir.Enabled = True
		Me.cmdRafraichir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRafraichir.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRafraichir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRafraichir.TabStop = True
		Me.cmdRafraichir.Name = "cmdRafraichir"
		Me.cmbTri.Size = New System.Drawing.Size(113, 21)
		Me.cmbTri.Location = New System.Drawing.Point(376, 112)
		Me.cmbTri.Items.AddRange(New Object(){"PIECE_GRB", "No. d'item", "Manufacturier", "Description française", "Description anglaise"})
		Me.cmbTri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbTri.TabIndex = 23
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
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(81, 25)
		Me.cmdFermer.Location = New System.Drawing.Point(808, 488)
		Me.cmdFermer.TabIndex = 42
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.cmdAjouter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAjouter.Text = "Ajouter"
		Me.cmdAjouter.Size = New System.Drawing.Size(81, 25)
		Me.cmdAjouter.Location = New System.Drawing.Point(544, 488)
		Me.cmdAjouter.TabIndex = 36
		Me.cmdAjouter.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAjouter.CausesValidation = True
		Me.cmdAjouter.Enabled = True
		Me.cmdAjouter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAjouter.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAjouter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAjouter.TabStop = True
		Me.cmdAjouter.Name = "cmdAjouter"
		Me.cmbCategorie.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbCategorie.Size = New System.Drawing.Size(113, 21)
		Me.cmbCategorie.Location = New System.Drawing.Point(8, 112)
		Me.cmbCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbCategorie.TabIndex = 22
		Me.cmbCategorie.Visible = False
		Me.cmbCategorie.BackColor = System.Drawing.SystemColors.Window
		Me.cmbCategorie.CausesValidation = True
		Me.cmbCategorie.Enabled = True
		Me.cmbCategorie.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbCategorie.IntegralHeight = True
		Me.cmbCategorie.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbCategorie.Sorted = False
		Me.cmbCategorie.TabStop = True
		Me.cmbCategorie.Name = "cmbCategorie"
		Me.txtRaison.AutoSize = False
		Me.txtRaison.Size = New System.Drawing.Size(385, 19)
		Me.txtRaison.Location = New System.Drawing.Point(304, 56)
		Me.txtRaison.Maxlength = 255
		Me.txtRaison.TabIndex = 8
		Me.txtRaison.AcceptsReturn = True
		Me.txtRaison.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtRaison.BackColor = System.Drawing.SystemColors.Window
		Me.txtRaison.CausesValidation = True
		Me.txtRaison.Enabled = True
		Me.txtRaison.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtRaison.HideSelection = True
		Me.txtRaison.ReadOnly = False
		Me.txtRaison.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtRaison.MultiLine = False
		Me.txtRaison.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtRaison.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtRaison.TabStop = True
		Me.txtRaison.Visible = True
		Me.txtRaison.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtRaison.Name = "txtRaison"
		Me.cmbNoAchat.Size = New System.Drawing.Size(153, 21)
		Me.cmbNoAchat.Location = New System.Drawing.Point(304, 32)
		Me.cmbNoAchat.TabIndex = 1
		Me.cmbNoAchat.BackColor = System.Drawing.SystemColors.Window
		Me.cmbNoAchat.CausesValidation = True
		Me.cmbNoAchat.Enabled = True
		Me.cmbNoAchat.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbNoAchat.IntegralHeight = True
		Me.cmbNoAchat.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbNoAchat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbNoAchat.Sorted = False
		Me.cmbNoAchat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbNoAchat.TabStop = True
		Me.cmbNoAchat.Visible = True
		Me.cmbNoAchat.Name = "cmbNoAchat"
		Me.fraFournisseur.BackColor = System.Drawing.Color.Black
		Me.fraFournisseur.Text = "Fournisseurs"
		Me.fraFournisseur.ForeColor = System.Drawing.Color.White
		Me.fraFournisseur.Size = New System.Drawing.Size(729, 121)
		Me.fraFournisseur.Location = New System.Drawing.Point(88, 144)
		Me.fraFournisseur.TabIndex = 27
		Me.fraFournisseur.Visible = False
		Me.fraFournisseur.Enabled = True
		Me.fraFournisseur.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraFournisseur.Padding = New System.Windows.Forms.Padding(0)
		Me.fraFournisseur.Name = "fraFournisseur"
		Me.lvwFournisseur.Size = New System.Drawing.Size(713, 97)
		Me.lvwFournisseur.Location = New System.Drawing.Point(8, 16)
		Me.lvwFournisseur.TabIndex = 28
		Me.lvwFournisseur.View = System.Windows.Forms.View.Details
		Me.lvwFournisseur.LabelEdit = False
		Me.lvwFournisseur.LabelWrap = True
		Me.lvwFournisseur.HideSelection = True
		Me.lvwFournisseur.FullRowSelect = True
		Me.lvwFournisseur.GridLines = True
		Me.lvwFournisseur.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwFournisseur.BackColor = System.Drawing.SystemColors.Window
		Me.lvwFournisseur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwFournisseur.Name = "lvwFournisseur"
		Me._lvwFournisseur_ColumnHeader_1.Text = "Fournisseur"
		Me._lvwFournisseur_ColumnHeader_1.Width = 236
		Me._lvwFournisseur_ColumnHeader_2.Text = "Pers. Ress."
		Me._lvwFournisseur_ColumnHeader_2.Width = 133
		Me._lvwFournisseur_ColumnHeader_3.Text = "Date"
		Me._lvwFournisseur_ColumnHeader_3.Width = 117
		Me._lvwFournisseur_ColumnHeader_4.Text = "Par"
		Me._lvwFournisseur_ColumnHeader_4.Width = 54
		Me._lvwFournisseur_ColumnHeader_5.Text = "Valide"
		Me._lvwFournisseur_ColumnHeader_5.Width = 117
		Me._lvwFournisseur_ColumnHeader_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._lvwFournisseur_ColumnHeader_6.Text = "Prix listé"
		Me._lvwFournisseur_ColumnHeader_6.Width = 108
		Me._lvwFournisseur_ColumnHeader_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._lvwFournisseur_ColumnHeader_7.Text = "Escompte"
		Me._lvwFournisseur_ColumnHeader_7.Width = 105
		Me._lvwFournisseur_ColumnHeader_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._lvwFournisseur_ColumnHeader_8.Text = "Prix net"
		Me._lvwFournisseur_ColumnHeader_8.Width = 108
		Me._lvwFournisseur_ColumnHeader_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._lvwFournisseur_ColumnHeader_9.Text = "Prix spécial"
		Me._lvwFournisseur_ColumnHeader_9.Width = 115
		Me._lvwFournisseur_ColumnHeader_10.Text = "Quoter"
		Me._lvwFournisseur_ColumnHeader_10.Width = 80
		Me.cmdModifier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdModifier.Text = "Modifier"
		Me.cmdModifier.Size = New System.Drawing.Size(81, 25)
		Me.cmdModifier.Location = New System.Drawing.Point(720, 488)
		Me.cmdModifier.TabIndex = 41
		Me.cmdModifier.BackColor = System.Drawing.SystemColors.Control
		Me.cmdModifier.CausesValidation = True
		Me.cmdModifier.Enabled = True
		Me.cmdModifier.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdModifier.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdModifier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdModifier.TabStop = True
		Me.cmdModifier.Name = "cmdModifier"
		Me.cmdSupprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSupprimer.Text = "Supprimer"
		Me.cmdSupprimer.Size = New System.Drawing.Size(81, 25)
		Me.cmdSupprimer.Location = New System.Drawing.Point(632, 488)
		Me.cmdSupprimer.TabIndex = 39
		Me.cmdSupprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSupprimer.CausesValidation = True
		Me.cmdSupprimer.Enabled = True
		Me.cmdSupprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSupprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSupprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSupprimer.TabStop = True
		Me.cmdSupprimer.Name = "cmdSupprimer"
		Me.cmdImprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdImprimer.Text = "Imprimer"
		Me.cmdImprimer.Size = New System.Drawing.Size(81, 25)
		Me.cmdImprimer.Location = New System.Drawing.Point(8, 488)
		Me.cmdImprimer.TabIndex = 30
		Me.cmdImprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdImprimer.CausesValidation = True
		Me.cmdImprimer.Enabled = True
		Me.cmdImprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdImprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdImprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdImprimer.TabStop = True
		Me.cmdImprimer.Name = "cmdImprimer"
		Me.txtAcheteur.AutoSize = False
		Me.txtAcheteur.Size = New System.Drawing.Size(121, 20)
		Me.txtAcheteur.Location = New System.Drawing.Point(568, 32)
		Me.txtAcheteur.ReadOnly = True
		Me.txtAcheteur.TabIndex = 4
		Me.txtAcheteur.AcceptsReturn = True
		Me.txtAcheteur.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtAcheteur.BackColor = System.Drawing.SystemColors.Window
		Me.txtAcheteur.CausesValidation = True
		Me.txtAcheteur.Enabled = True
		Me.txtAcheteur.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAcheteur.HideSelection = True
		Me.txtAcheteur.Maxlength = 0
		Me.txtAcheteur.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAcheteur.MultiLine = False
		Me.txtAcheteur.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAcheteur.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtAcheteur.TabStop = True
		Me.txtAcheteur.Visible = True
		Me.txtAcheteur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAcheteur.Name = "txtAcheteur"
		Me.cmdBonCommande.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBonCommande.Text = "Bon de commande"
		Me.cmdBonCommande.Size = New System.Drawing.Size(105, 25)
		Me.cmdBonCommande.Location = New System.Drawing.Point(432, 488)
		Me.cmdBonCommande.TabIndex = 34
		Me.cmdBonCommande.Visible = False
		Me.cmdBonCommande.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBonCommande.CausesValidation = True
		Me.cmdBonCommande.Enabled = True
		Me.cmdBonCommande.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBonCommande.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBonCommande.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBonCommande.TabStop = True
		Me.cmdBonCommande.Name = "cmdBonCommande"
		Me.lvwAchat.Size = New System.Drawing.Size(881, 169)
		Me.lvwAchat.Location = New System.Drawing.Point(8, 312)
		Me.lvwAchat.TabIndex = 29
		Me.lvwAchat.View = System.Windows.Forms.View.Details
		Me.lvwAchat.LabelEdit = False
		Me.lvwAchat.LabelWrap = True
		Me.lvwAchat.HideSelection = True
		Me.lvwAchat.FullRowSelect = True
		Me.lvwAchat.GridLines = True
		Me.lvwAchat.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwAchat.BackColor = System.Drawing.SystemColors.Window
		Me.lvwAchat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwAchat.Name = "lvwAchat"
		Me._lvwAchat_ColumnHeader_1.Text = "Qté"
		Me._lvwAchat_ColumnHeader_1.Width = 53
		Me._lvwAchat_ColumnHeader_2.Text = "No. d'item"
		Me._lvwAchat_ColumnHeader_2.Width = 216
		Me._lvwAchat_ColumnHeader_3.Text = "Description"
		Me._lvwAchat_ColumnHeader_3.Width = 448
		Me._lvwAchat_ColumnHeader_4.Text = "Manufacturier"
		Me._lvwAchat_ColumnHeader_4.Width = 136
		Me._lvwAchat_ColumnHeader_5.Text = "Prix listé"
		Me._lvwAchat_ColumnHeader_5.Width = 109
		Me._lvwAchat_ColumnHeader_6.Text = "Escompte"
		Me._lvwAchat_ColumnHeader_6.Width = 105
		Me._lvwAchat_ColumnHeader_7.Text = "Prix net"
		Me._lvwAchat_ColumnHeader_7.Width = 109
		Me._lvwAchat_ColumnHeader_8.Text = "Distributeur"
		Me._lvwAchat_ColumnHeader_8.Width = 119
		Me._lvwAchat_ColumnHeader_9.Text = "TOTAL"
		Me._lvwAchat_ColumnHeader_9.Width = 130
		Me._lvwAchat_ColumnHeader_10.Text = "Date Commande"
		Me._lvwAchat_ColumnHeader_10.Width = 170
		Me._lvwAchat_ColumnHeader_11.Text = "Date Requise"
		Me._lvwAchat_ColumnHeader_11.Width = 170
		Me.lvwPieces.Size = New System.Drawing.Size(881, 169)
		Me.lvwPieces.Location = New System.Drawing.Point(8, 136)
		Me.lvwPieces.TabIndex = 26
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
		Me._lvwPieces_ColumnHeader_1.Text = "PIECE_GRB"
		Me._lvwPieces_ColumnHeader_1.Width = 161
		Me._lvwPieces_ColumnHeader_2.Text = "No. d'item"
		Me._lvwPieces_ColumnHeader_2.Width = 217
		Me._lvwPieces_ColumnHeader_3.Text = "Manufacturier"
		Me._lvwPieces_ColumnHeader_3.Width = 136
		Me._lvwPieces_ColumnHeader_4.Text = "Description française"
		Me._lvwPieces_ColumnHeader_4.Width = 477
		Me._lvwPieces_ColumnHeader_5.Text = "Description anglaise"
		Me._lvwPieces_ColumnHeader_5.Width = 477
		Me._lvwPieces_ColumnHeader_6.Text = "Commentaire"
		Me._lvwPieces_ColumnHeader_6.Width = 170
		Me.txtNoAchat.AutoSize = False
		Me.txtNoAchat.Size = New System.Drawing.Size(153, 19)
		Me.txtNoAchat.Location = New System.Drawing.Point(304, 32)
		Me.txtNoAchat.ReadOnly = True
		Me.txtNoAchat.TabIndex = 2
		Me.txtNoAchat.Visible = False
		Me.txtNoAchat.AcceptsReturn = True
		Me.txtNoAchat.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoAchat.BackColor = System.Drawing.SystemColors.Window
		Me.txtNoAchat.CausesValidation = True
		Me.txtNoAchat.Enabled = True
		Me.txtNoAchat.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNoAchat.HideSelection = True
		Me.txtNoAchat.Maxlength = 0
		Me.txtNoAchat.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNoAchat.MultiLine = False
		Me.txtNoAchat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNoAchat.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNoAchat.TabStop = True
		Me.txtNoAchat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoAchat.Name = "txtNoAchat"
		Me.txtDate.AutoSize = False
		Me.txtDate.Size = New System.Drawing.Size(65, 20)
		Me.txtDate.Location = New System.Drawing.Point(304, 80)
		Me.txtDate.ReadOnly = True
		Me.txtDate.TabIndex = 10
		Me.txtDate.AcceptsReturn = True
		Me.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDate.BackColor = System.Drawing.SystemColors.Window
		Me.txtDate.CausesValidation = True
		Me.txtDate.Enabled = True
		Me.txtDate.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDate.HideSelection = True
		Me.txtDate.Maxlength = 0
		Me.txtDate.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDate.MultiLine = False
		Me.txtDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDate.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDate.TabStop = True
		Me.txtDate.Visible = True
		Me.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDate.Name = "txtDate"
		Me.cmdEnregistrer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEnregistrer.Text = "Enregistrer"
		Me.cmdEnregistrer.Size = New System.Drawing.Size(81, 25)
		Me.cmdEnregistrer.Location = New System.Drawing.Point(632, 488)
		Me.cmdEnregistrer.TabIndex = 38
		Me.cmdEnregistrer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEnregistrer.CausesValidation = True
		Me.cmdEnregistrer.Enabled = True
		Me.cmdEnregistrer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEnregistrer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEnregistrer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEnregistrer.TabStop = True
		Me.cmdEnregistrer.Name = "cmdEnregistrer"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(81, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(720, 488)
		Me.cmdAnnuler.TabIndex = 40
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.cmdMaterielInutile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMaterielInutile.Text = "Inutile"
		Me.cmdMaterielInutile.Size = New System.Drawing.Size(81, 25)
		Me.cmdMaterielInutile.Location = New System.Drawing.Point(544, 488)
		Me.cmdMaterielInutile.TabIndex = 37
		Me.cmdMaterielInutile.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMaterielInutile.CausesValidation = True
		Me.cmdMaterielInutile.Enabled = True
		Me.cmdMaterielInutile.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMaterielInutile.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMaterielInutile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMaterielInutile.TabStop = True
		Me.cmdMaterielInutile.Name = "cmdMaterielInutile"
		Me.cmdMauvaisPrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMauvaisPrix.Text = "Prix"
		Me.cmdMauvaisPrix.Size = New System.Drawing.Size(81, 25)
		Me.cmdMauvaisPrix.Location = New System.Drawing.Point(456, 488)
		Me.cmdMauvaisPrix.TabIndex = 35
		Me.cmdMauvaisPrix.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMauvaisPrix.CausesValidation = True
		Me.cmdMauvaisPrix.Enabled = True
		Me.cmdMauvaisPrix.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMauvaisPrix.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMauvaisPrix.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMauvaisPrix.TabStop = True
		Me.cmdMauvaisPrix.Name = "cmdMauvaisPrix"
		Me.Label2.Text = "Date                    AA-MM-JJ"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(81, 25)
		Me.Label2.Location = New System.Drawing.Point(256, 80)
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
		Me.lblPrixTotal.Text = "Prix Total"
		Me.lblPrixTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPrixTotal.ForeColor = System.Drawing.Color.White
		Me.lblPrixTotal.Size = New System.Drawing.Size(50, 12)
		Me.lblPrixTotal.Location = New System.Drawing.Point(544, 80)
		Me.lblPrixTotal.TabIndex = 5
		Me.lblPrixTotal.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPrixTotal.BackColor = System.Drawing.Color.Transparent
		Me.lblPrixTotal.Enabled = True
		Me.lblPrixTotal.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPrixTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPrixTotal.UseMnemonic = True
		Me.lblPrixTotal.Visible = True
		Me.lblPrixTotal.AutoSize = True
		Me.lblPrixTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPrixTotal.Name = "lblPrixTotal"
		Me._Label1_0.Text = "Numéro"
		Me._Label1_0.ForeColor = System.Drawing.Color.White
		Me._Label1_0.Size = New System.Drawing.Size(41, 17)
		Me._Label1_0.Location = New System.Drawing.Point(256, 32)
		Me._Label1_0.TabIndex = 0
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
		Me.lblTri.Text = "Trier par :"
		Me.lblTri.ForeColor = System.Drawing.Color.White
		Me.lblTri.Size = New System.Drawing.Size(57, 17)
		Me.lblTri.Location = New System.Drawing.Point(376, 96)
		Me.lblTri.TabIndex = 17
		Me.lblTri.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTri.BackColor = System.Drawing.Color.Transparent
		Me.lblTri.Enabled = True
		Me.lblTri.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTri.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTri.UseMnemonic = True
		Me.lblTri.Visible = True
		Me.lblTri.AutoSize = False
		Me.lblTri.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTri.Name = "lblTri"
		Me.lblRaison.Text = "Raison "
		Me.lblRaison.ForeColor = System.Drawing.Color.White
		Me.lblRaison.Size = New System.Drawing.Size(41, 17)
		Me.lblRaison.Location = New System.Drawing.Point(256, 56)
		Me.lblRaison.TabIndex = 7
		Me.lblRaison.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblRaison.BackColor = System.Drawing.Color.Transparent
		Me.lblRaison.Enabled = True
		Me.lblRaison.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblRaison.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblRaison.UseMnemonic = True
		Me.lblRaison.Visible = True
		Me.lblRaison.AutoSize = False
		Me.lblRaison.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblRaison.Name = "lblRaison"
		Me.lblCategorie.Text = "Catégorie :"
		Me.lblCategorie.ForeColor = System.Drawing.Color.White
		Me.lblCategorie.Size = New System.Drawing.Size(65, 17)
		Me.lblCategorie.Location = New System.Drawing.Point(8, 96)
		Me.lblCategorie.TabIndex = 11
		Me.lblCategorie.Visible = False
		Me.lblCategorie.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblCategorie.BackColor = System.Drawing.Color.Transparent
		Me.lblCategorie.Enabled = True
		Me.lblCategorie.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblCategorie.UseMnemonic = True
		Me.lblCategorie.AutoSize = False
		Me.lblCategorie.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblCategorie.Name = "lblCategorie"
		Me.lblNoSoumission.Text = "Acheteur"
		Me.lblNoSoumission.ForeColor = System.Drawing.Color.White
		Me.lblNoSoumission.Size = New System.Drawing.Size(49, 17)
		Me.lblNoSoumission.Location = New System.Drawing.Point(512, 32)
		Me.lblNoSoumission.TabIndex = 3
		Me.lblNoSoumission.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblNoSoumission.BackColor = System.Drawing.Color.Transparent
		Me.lblNoSoumission.Enabled = True
		Me.lblNoSoumission.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblNoSoumission.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblNoSoumission.UseMnemonic = True
		Me.lblNoSoumission.Visible = True
		Me.lblNoSoumission.AutoSize = False
		Me.lblNoSoumission.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblNoSoumission.Name = "lblNoSoumission"
		Me.Controls.Add(fraDateRequise)
		Me.Controls.Add(fraPieceTrouve)
		Me.Controls.Add(fraPrixPiece)
		Me.Controls.Add(cmdReception)
		Me.Controls.Add(fraInventaire)
		Me.Controls.Add(cmdInventaire)
		Me.Controls.Add(cmdReset)
		Me.Controls.Add(cmdRetour)
		Me.Controls.Add(cmdDemande)
		Me.Controls.Add(cmdTri)
		Me.Controls.Add(txtPrixTotal)
		Me.Controls.Add(cmdRafraichir)
		Me.Controls.Add(cmbTri)
		Me.Controls.Add(cmdFermer)
		Me.Controls.Add(cmdAjouter)
		Me.Controls.Add(cmbCategorie)
		Me.Controls.Add(txtRaison)
		Me.Controls.Add(cmbNoAchat)
		Me.Controls.Add(fraFournisseur)
		Me.Controls.Add(cmdModifier)
		Me.Controls.Add(cmdSupprimer)
		Me.Controls.Add(cmdImprimer)
		Me.Controls.Add(txtAcheteur)
		Me.Controls.Add(cmdBonCommande)
		Me.Controls.Add(lvwAchat)
		Me.Controls.Add(lvwPieces)
		Me.Controls.Add(txtNoAchat)
		Me.Controls.Add(txtDate)
		Me.Controls.Add(cmdEnregistrer)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(cmdMaterielInutile)
		Me.Controls.Add(cmdMauvaisPrix)
		Me.Controls.Add(Label2)
		Me.Controls.Add(lblPrixTotal)
		Me.Controls.Add(_Label1_0)
		Me.Controls.Add(lblTri)
		Me.Controls.Add(lblRaison)
		Me.Controls.Add(lblCategorie)
		Me.Controls.Add(lblNoSoumission)
		Me.fraDateRequise.Controls.Add(cmdOKDateRequise)
		Me.fraDateRequise.Controls.Add(cmdAnnulerDateRequise)
		Me.fraDateRequise.Controls.Add(mvwDateRequise)
		Me.fraPieceTrouve.Controls.Add(cmdOKPieceTrouve)
		Me.fraPieceTrouve.Controls.Add(cmdAnnulerPieceTrouve)
		Me.fraPieceTrouve.Controls.Add(lvwPieceTrouve)
		Me.lvwPieceTrouve.Columns.Add(_lvwPieceTrouve_ColumnHeader_1)
		Me.lvwPieceTrouve.Columns.Add(_lvwPieceTrouve_ColumnHeader_2)
		Me.lvwPieceTrouve.Columns.Add(_lvwPieceTrouve_ColumnHeader_3)
		Me.lvwPieceTrouve.Columns.Add(_lvwPieceTrouve_ColumnHeader_4)
		Me.lvwPieceTrouve.Columns.Add(_lvwPieceTrouve_ColumnHeader_5)
		Me.lvwPieceTrouve.Columns.Add(_lvwPieceTrouve_ColumnHeader_6)
		Me.fraPrixPiece.Controls.Add(cmdAnnulerPrix)
		Me.fraPrixPiece.Controls.Add(cmdOKPrix)
		Me.fraPrixPiece.Controls.Add(optSpain)
		Me.fraPrixPiece.Controls.Add(optCAN)
		Me.fraPrixPiece.Controls.Add(optUSA)
		Me.fraPrixPiece.Controls.Add(cmbfrs)
		Me.fraPrixPiece.Controls.Add(txtPrixNet)
		Me.fraPrixPiece.Controls.Add(txtPrixList)
		Me.fraPrixPiece.Controls.Add(txtPrixSpecial)
		Me.fraPrixPiece.Controls.Add(mskEscompte)
		Me.fraPrixPiece.Controls.Add(imgEU)
		Me.fraPrixPiece.Controls.Add(imgSpain)
		Me.fraPrixPiece.Controls.Add(_Label1_5)
		Me.fraPrixPiece.Controls.Add(_Label1_4)
		Me.fraPrixPiece.Controls.Add(_Label1_3)
		Me.fraPrixPiece.Controls.Add(_Label1_2)
		Me.fraPrixPiece.Controls.Add(imgCanada)
		Me.fraPrixPiece.Controls.Add(_Label1_1)
		Me.fraInventaire.Controls.Add(cmdAnnulerInventaire)
		Me.fraInventaire.Controls.Add(cmdOKInventaire)
		Me.fraInventaire.Controls.Add(lvwInventaire)
		Me.lvwInventaire.Columns.Add(_lvwInventaire_ColumnHeader_1)
		Me.lvwInventaire.Columns.Add(_lvwInventaire_ColumnHeader_2)
		Me.lvwInventaire.Columns.Add(_lvwInventaire_ColumnHeader_3)
		Me.lvwInventaire.Columns.Add(_lvwInventaire_ColumnHeader_4)
		Me.lvwInventaire.Columns.Add(_lvwInventaire_ColumnHeader_5)
		Me.lvwInventaire.Columns.Add(_lvwInventaire_ColumnHeader_6)
		Me.lvwInventaire.Columns.Add(_lvwInventaire_ColumnHeader_7)
		Me.fraFournisseur.Controls.Add(lvwFournisseur)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_1)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_2)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_3)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_4)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_5)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_6)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_7)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_8)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_9)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_10)
		Me.lvwAchat.Columns.Add(_lvwAchat_ColumnHeader_1)
		Me.lvwAchat.Columns.Add(_lvwAchat_ColumnHeader_2)
		Me.lvwAchat.Columns.Add(_lvwAchat_ColumnHeader_3)
		Me.lvwAchat.Columns.Add(_lvwAchat_ColumnHeader_4)
		Me.lvwAchat.Columns.Add(_lvwAchat_ColumnHeader_5)
		Me.lvwAchat.Columns.Add(_lvwAchat_ColumnHeader_6)
		Me.lvwAchat.Columns.Add(_lvwAchat_ColumnHeader_7)
		Me.lvwAchat.Columns.Add(_lvwAchat_ColumnHeader_8)
		Me.lvwAchat.Columns.Add(_lvwAchat_ColumnHeader_9)
		Me.lvwAchat.Columns.Add(_lvwAchat_ColumnHeader_10)
		Me.lvwAchat.Columns.Add(_lvwAchat_ColumnHeader_11)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_1)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_2)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_3)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_4)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_5)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_6)
		Me.Label1.SetIndex(_Label1_5, CType(5, Short))
		Me.Label1.SetIndex(_Label1_4, CType(4, Short))
		Me.Label1.SetIndex(_Label1_3, CType(3, Short))
		Me.Label1.SetIndex(_Label1_2, CType(2, Short))
		Me.Label1.SetIndex(_Label1_1, CType(1, Short))
		Me.Label1.SetIndex(_Label1_0, CType(0, Short))
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mvwDateRequise, System.ComponentModel.ISupportInitialize).EndInit()
		MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuRightClick})
		mnuRightClick.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuDateRequise})
		Me.Controls.Add(MainMenu1)
		Me.MainMenu1.ResumeLayout(False)
		Me.fraDateRequise.ResumeLayout(False)
		Me.fraPieceTrouve.ResumeLayout(False)
		Me.lvwPieceTrouve.ResumeLayout(False)
		Me.fraPrixPiece.ResumeLayout(False)
		Me.fraInventaire.ResumeLayout(False)
		Me.lvwInventaire.ResumeLayout(False)
		Me.fraFournisseur.ResumeLayout(False)
		Me.lvwFournisseur.ResumeLayout(False)
		Me.lvwAchat.ResumeLayout(False)
		Me.lvwPieces.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class