<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FrmFRS
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
	Public WithEvents cmdcatmod As System.Windows.Forms.Button
	Public WithEvents cmb_modAnu As System.Windows.Forms.Button
	Public WithEvents cmdCatAdd As System.Windows.Forms.Button
	Public WithEvents cmdcatval As System.Windows.Forms.Button
	Public WithEvents txtmodcat As System.Windows.Forms.TextBox
	Public WithEvents FrmCatMod As System.Windows.Forms.GroupBox
	Public WithEvents cmdAnnuller As System.Windows.Forms.Button
	Public WithEvents cmdcatenr As System.Windows.Forms.Button
	Public WithEvents _Lst_Cat_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents Lst_Cat As System.Windows.Forms.ListView
	Public WithEvents frm_Categorie As System.Windows.Forms.GroupBox
	Public WithEvents cmb_modCat As System.Windows.Forms.Button
	Public WithEvents cmbcatégorie As System.Windows.Forms.ComboBox
	Public WithEvents cmdMailListFournisseur As System.Windows.Forms.Button
	Public WithEvents lblEtatOutlook As System.Windows.Forms.Label
	Public WithEvents fraEtatOutlook As System.Windows.Forms.Panel
	Public WithEvents cmdFax As System.Windows.Forms.Button
	Public WithEvents txtFax As System.Windows.Forms.TextBox
	Public WithEvents cmdMailListContact As System.Windows.Forms.Button
	Public WithEvents txtContactTitre As System.Windows.Forms.TextBox
	Public WithEvents txtContactPage As System.Windows.Forms.TextBox
	Public WithEvents txtContactEmail As System.Windows.Forms.TextBox
	Public WithEvents txtContactPoste As System.Windows.Forms.TextBox
	Public WithEvents txtContactTel As System.Windows.Forms.TextBox
	Public WithEvents cmbcontact As System.Windows.Forms.ComboBox
	Public WithEvents txtContactFax As System.Windows.Forms.TextBox
	Public WithEvents txtContactCell As System.Windows.Forms.TextBox
	Public WithEvents cmdsupcontact As System.Windows.Forms.Button
	Public WithEvents txtContactDom As System.Windows.Forms.TextBox
	Public WithEvents CmdAddCont As System.Windows.Forms.Button
	Public WithEvents cmdEnregistrerContact As System.Windows.Forms.Button
	Public WithEvents cmdAnnulerContact As System.Windows.Forms.Button
	Public WithEvents mskContactPage As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskContactFax As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskContactCell As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskContactDom As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskContactTel As System.Windows.Forms.MaskedTextBox
	Public WithEvents txtContact As System.Windows.Forms.TextBox
	Public WithEvents _Label1_8 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents _Label1_7 As System.Windows.Forms.Label
	Public WithEvents _Label1_5 As System.Windows.Forms.Label
	Public WithEvents _Label1_4 As System.Windows.Forms.Label
	Public WithEvents _Label1_3 As System.Windows.Forms.Label
	Public WithEvents _Label1_2 As System.Windows.Forms.Label
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents _Label1_6 As System.Windows.Forms.Label
	Public WithEvents fraContact As System.Windows.Forms.GroupBox
	Public WithEvents cmdRechercher As System.Windows.Forms.Button
	Public WithEvents cmdRafraichir As System.Windows.Forms.Button
	Public WithEvents cmdreport As System.Windows.Forms.Button
	Public WithEvents txtSiteWeb As System.Windows.Forms.TextBox
	Public WithEvents cmdrenommer As System.Windows.Forms.Button
	Public WithEvents txtCommentaire As System.Windows.Forms.TextBox
	Public WithEvents txtRechercher As System.Windows.Forms.TextBox
	Public WithEvents CmdModif As System.Windows.Forms.Button
	Public WithEvents txtEmail As System.Windows.Forms.TextBox
	Public WithEvents txtTelephone As System.Windows.Forms.TextBox
	Public WithEvents txtCP As System.Windows.Forms.TextBox
	Public WithEvents txtPays As System.Windows.Forms.TextBox
	Public WithEvents txtProvEtat As System.Windows.Forms.TextBox
	Public WithEvents txtVille As System.Windows.Forms.TextBox
	Public WithEvents txtAdresse As System.Windows.Forms.TextBox
	Public WithEvents CmdFerme As System.Windows.Forms.Button
	Public WithEvents CmdSupp As System.Windows.Forms.Button
	Public WithEvents CmdAdd As System.Windows.Forms.Button
	Public WithEvents mskTelephone As System.Windows.Forms.MaskedTextBox
	Public WithEvents CmdEnr As System.Windows.Forms.Button
	Public WithEvents CmdAnul As System.Windows.Forms.Button
	Public WithEvents txtNomFournisseur As System.Windows.Forms.TextBox
	Public WithEvents cmbFournisseur As System.Windows.Forms.ComboBox
	Public WithEvents mskFax As System.Windows.Forms.MaskedTextBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents lblUserModification As System.Windows.Forms.Label
	Public WithEvents lblUserCreation As System.Windows.Forms.Label
	Public WithEvents lblDateModification As System.Windows.Forms.Label
	Public WithEvents lblDateCreation As System.Windows.Forms.Label
	Public WithEvents _Label12_3 As System.Windows.Forms.Label
	Public WithEvents _Label12_2 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents _Label12_1 As System.Windows.Forms.Label
	Public WithEvents Label16 As System.Windows.Forms.Label
	Public WithEvents lblRechercher As System.Windows.Forms.Label
	Public WithEvents _Label12_0 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents Shape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Label12 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmFRS))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.frm_Categorie = New System.Windows.Forms.GroupBox
		Me.cmdcatmod = New System.Windows.Forms.Button
		Me.cmb_modAnu = New System.Windows.Forms.Button
		Me.cmdCatAdd = New System.Windows.Forms.Button
		Me.cmdcatval = New System.Windows.Forms.Button
		Me.FrmCatMod = New System.Windows.Forms.GroupBox
		Me.txtmodcat = New System.Windows.Forms.TextBox
		Me.cmdAnnuller = New System.Windows.Forms.Button
		Me.cmdcatenr = New System.Windows.Forms.Button
		Me.Lst_Cat = New System.Windows.Forms.ListView
		Me._Lst_Cat_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.cmb_modCat = New System.Windows.Forms.Button
		Me.cmbcatégorie = New System.Windows.Forms.ComboBox
		Me.cmdMailListFournisseur = New System.Windows.Forms.Button
		Me.fraEtatOutlook = New System.Windows.Forms.Panel
		Me.lblEtatOutlook = New System.Windows.Forms.Label
		Me.cmdFax = New System.Windows.Forms.Button
		Me.txtFax = New System.Windows.Forms.TextBox
		Me.fraContact = New System.Windows.Forms.GroupBox
		Me.cmdMailListContact = New System.Windows.Forms.Button
		Me.txtContactTitre = New System.Windows.Forms.TextBox
		Me.txtContactPage = New System.Windows.Forms.TextBox
		Me.txtContactEmail = New System.Windows.Forms.TextBox
		Me.txtContactPoste = New System.Windows.Forms.TextBox
		Me.txtContactTel = New System.Windows.Forms.TextBox
		Me.cmbcontact = New System.Windows.Forms.ComboBox
		Me.txtContactFax = New System.Windows.Forms.TextBox
		Me.txtContactCell = New System.Windows.Forms.TextBox
		Me.cmdsupcontact = New System.Windows.Forms.Button
		Me.txtContactDom = New System.Windows.Forms.TextBox
		Me.CmdAddCont = New System.Windows.Forms.Button
		Me.cmdEnregistrerContact = New System.Windows.Forms.Button
		Me.cmdAnnulerContact = New System.Windows.Forms.Button
		Me.mskContactPage = New System.Windows.Forms.MaskedTextBox
		Me.mskContactFax = New System.Windows.Forms.MaskedTextBox
		Me.mskContactCell = New System.Windows.Forms.MaskedTextBox
		Me.mskContactDom = New System.Windows.Forms.MaskedTextBox
		Me.mskContactTel = New System.Windows.Forms.MaskedTextBox
		Me.txtContact = New System.Windows.Forms.TextBox
		Me._Label1_8 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me._Label1_7 = New System.Windows.Forms.Label
		Me._Label1_5 = New System.Windows.Forms.Label
		Me._Label1_4 = New System.Windows.Forms.Label
		Me._Label1_3 = New System.Windows.Forms.Label
		Me._Label1_2 = New System.Windows.Forms.Label
		Me._Label1_1 = New System.Windows.Forms.Label
		Me._Label1_6 = New System.Windows.Forms.Label
		Me.cmdRechercher = New System.Windows.Forms.Button
		Me.cmdRafraichir = New System.Windows.Forms.Button
		Me.cmdreport = New System.Windows.Forms.Button
		Me.txtSiteWeb = New System.Windows.Forms.TextBox
		Me.cmdrenommer = New System.Windows.Forms.Button
		Me.txtCommentaire = New System.Windows.Forms.TextBox
		Me.txtRechercher = New System.Windows.Forms.TextBox
		Me.CmdModif = New System.Windows.Forms.Button
		Me.txtEmail = New System.Windows.Forms.TextBox
		Me.txtTelephone = New System.Windows.Forms.TextBox
		Me.txtCP = New System.Windows.Forms.TextBox
		Me.txtPays = New System.Windows.Forms.TextBox
		Me.txtProvEtat = New System.Windows.Forms.TextBox
		Me.txtVille = New System.Windows.Forms.TextBox
		Me.txtAdresse = New System.Windows.Forms.TextBox
		Me.CmdFerme = New System.Windows.Forms.Button
		Me.CmdSupp = New System.Windows.Forms.Button
		Me.CmdAdd = New System.Windows.Forms.Button
		Me.mskTelephone = New System.Windows.Forms.MaskedTextBox
		Me.CmdEnr = New System.Windows.Forms.Button
		Me.CmdAnul = New System.Windows.Forms.Button
		Me.txtNomFournisseur = New System.Windows.Forms.TextBox
		Me.cmbFournisseur = New System.Windows.Forms.ComboBox
		Me.mskFax = New System.Windows.Forms.MaskedTextBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.lblUserModification = New System.Windows.Forms.Label
		Me.lblUserCreation = New System.Windows.Forms.Label
		Me.lblDateModification = New System.Windows.Forms.Label
		Me.lblDateCreation = New System.Windows.Forms.Label
		Me._Label12_3 = New System.Windows.Forms.Label
		Me._Label12_2 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me._Label12_1 = New System.Windows.Forms.Label
		Me.Label16 = New System.Windows.Forms.Label
		Me.lblRechercher = New System.Windows.Forms.Label
		Me._Label12_0 = New System.Windows.Forms.Label
		Me.Label10 = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me._Label1_0 = New System.Windows.Forms.Label
		Me.Shape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Label12 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.frm_Categorie.SuspendLayout()
		Me.FrmCatMod.SuspendLayout()
		Me.Lst_Cat.SuspendLayout()
		Me.fraEtatOutlook.SuspendLayout()
		Me.fraContact.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Fournisseurs"
		Me.ClientSize = New System.Drawing.Size(615, 496)
		Me.Location = New System.Drawing.Point(184, 130)
		Me.Icon = CType(resources.GetObject("FrmFRS.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("FrmFRS.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "FrmFRS"
		Me.frm_Categorie.Text = "Frame1"
		Me.frm_Categorie.Size = New System.Drawing.Size(457, 441)
		Me.frm_Categorie.Location = New System.Drawing.Point(0, 56)
		Me.frm_Categorie.TabIndex = 79
		Me.frm_Categorie.Visible = False
		Me.frm_Categorie.BackColor = System.Drawing.SystemColors.Control
		Me.frm_Categorie.Enabled = True
		Me.frm_Categorie.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frm_Categorie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frm_Categorie.Padding = New System.Windows.Forms.Padding(0)
		Me.frm_Categorie.Name = "frm_Categorie"
		Me.cmdcatmod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdcatmod.Text = "Modifier"
		Me.cmdcatmod.Enabled = False
		Me.cmdcatmod.Size = New System.Drawing.Size(97, 25)
		Me.cmdcatmod.Location = New System.Drawing.Point(344, 56)
		Me.cmdcatmod.TabIndex = 83
		Me.cmdcatmod.BackColor = System.Drawing.SystemColors.Control
		Me.cmdcatmod.CausesValidation = True
		Me.cmdcatmod.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdcatmod.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdcatmod.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdcatmod.TabStop = True
		Me.cmdcatmod.Name = "cmdcatmod"
		Me.cmb_modAnu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmb_modAnu.Text = "Annuller"
		Me.cmb_modAnu.Size = New System.Drawing.Size(97, 25)
		Me.cmb_modAnu.Location = New System.Drawing.Point(344, 56)
		Me.cmb_modAnu.TabIndex = 89
		Me.cmb_modAnu.BackColor = System.Drawing.SystemColors.Control
		Me.cmb_modAnu.CausesValidation = True
		Me.cmb_modAnu.Enabled = True
		Me.cmb_modAnu.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmb_modAnu.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmb_modAnu.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmb_modAnu.TabStop = True
		Me.cmb_modAnu.Name = "cmb_modAnu"
		Me.cmdCatAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCatAdd.Text = "Ajouter"
		Me.cmdCatAdd.Size = New System.Drawing.Size(97, 25)
		Me.cmdCatAdd.Location = New System.Drawing.Point(344, 24)
		Me.cmdCatAdd.TabIndex = 82
		Me.cmdCatAdd.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCatAdd.CausesValidation = True
		Me.cmdCatAdd.Enabled = True
		Me.cmdCatAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCatAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCatAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCatAdd.TabStop = True
		Me.cmdCatAdd.Name = "cmdCatAdd"
		Me.cmdcatval.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdcatval.Text = "Accepter"
		Me.cmdcatval.Size = New System.Drawing.Size(97, 25)
		Me.cmdcatval.Location = New System.Drawing.Point(344, 24)
		Me.cmdcatval.TabIndex = 88
		Me.cmdcatval.Visible = False
		Me.cmdcatval.BackColor = System.Drawing.SystemColors.Control
		Me.cmdcatval.CausesValidation = True
		Me.cmdcatval.Enabled = True
		Me.cmdcatval.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdcatval.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdcatval.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdcatval.TabStop = True
		Me.cmdcatval.Name = "cmdcatval"
		Me.FrmCatMod.Text = "Frame1"
		Me.FrmCatMod.Size = New System.Drawing.Size(193, 49)
		Me.FrmCatMod.Location = New System.Drawing.Point(144, 16)
		Me.FrmCatMod.TabIndex = 86
		Me.FrmCatMod.Visible = False
		Me.FrmCatMod.BackColor = System.Drawing.SystemColors.Control
		Me.FrmCatMod.Enabled = True
		Me.FrmCatMod.ForeColor = System.Drawing.SystemColors.ControlText
		Me.FrmCatMod.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.FrmCatMod.Padding = New System.Windows.Forms.Padding(0)
		Me.FrmCatMod.Name = "FrmCatMod"
		Me.txtmodcat.AutoSize = False
		Me.txtmodcat.Size = New System.Drawing.Size(145, 19)
		Me.txtmodcat.Location = New System.Drawing.Point(24, 16)
		Me.txtmodcat.TabIndex = 87
		Me.txtmodcat.Text = "Text1"
		Me.txtmodcat.AcceptsReturn = True
		Me.txtmodcat.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtmodcat.BackColor = System.Drawing.SystemColors.Window
		Me.txtmodcat.CausesValidation = True
		Me.txtmodcat.Enabled = True
		Me.txtmodcat.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtmodcat.HideSelection = True
		Me.txtmodcat.ReadOnly = False
		Me.txtmodcat.Maxlength = 0
		Me.txtmodcat.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtmodcat.MultiLine = False
		Me.txtmodcat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtmodcat.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtmodcat.TabStop = True
		Me.txtmodcat.Visible = True
		Me.txtmodcat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtmodcat.Name = "txtmodcat"
		Me.cmdAnnuller.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuller.Text = "Annuller"
		Me.cmdAnnuller.Size = New System.Drawing.Size(97, 25)
		Me.cmdAnnuller.Location = New System.Drawing.Point(344, 120)
		Me.cmdAnnuller.TabIndex = 85
		Me.cmdAnnuller.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuller.CausesValidation = True
		Me.cmdAnnuller.Enabled = True
		Me.cmdAnnuller.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuller.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuller.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuller.TabStop = True
		Me.cmdAnnuller.Name = "cmdAnnuller"
		Me.cmdcatenr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdcatenr.Text = "Enregistrer"
		Me.cmdcatenr.Size = New System.Drawing.Size(97, 25)
		Me.cmdcatenr.Location = New System.Drawing.Point(344, 88)
		Me.cmdcatenr.TabIndex = 84
		Me.cmdcatenr.BackColor = System.Drawing.SystemColors.Control
		Me.cmdcatenr.CausesValidation = True
		Me.cmdcatenr.Enabled = True
		Me.cmdcatenr.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdcatenr.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdcatenr.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdcatenr.TabStop = True
		Me.cmdcatenr.Name = "cmdcatenr"
		Me.Lst_Cat.Size = New System.Drawing.Size(337, 401)
		Me.Lst_Cat.Location = New System.Drawing.Point(0, 16)
		Me.Lst_Cat.TabIndex = 80
		Me.Lst_Cat.View = System.Windows.Forms.View.Details
		Me.Lst_Cat.LabelEdit = False
		Me.Lst_Cat.LabelWrap = True
		Me.Lst_Cat.HideSelection = True
		Me.Lst_Cat.Checkboxes = True
		Me.Lst_Cat.GridLines = True
		Me.Lst_Cat.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Lst_Cat.BackColor = System.Drawing.SystemColors.Window
		Me.Lst_Cat.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Lst_Cat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Lst_Cat.Name = "Lst_Cat"
		Me._Lst_Cat_ColumnHeader_1.Text = "Actif"
		Me._Lst_Cat_ColumnHeader_1.Width = 170
		Me.cmb_modCat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmb_modCat.Text = "Modifier"
		Me.cmb_modCat.Size = New System.Drawing.Size(137, 25)
		Me.cmb_modCat.Location = New System.Drawing.Point(96, 120)
		Me.cmb_modCat.TabIndex = 81
		Me.cmb_modCat.Visible = False
		Me.cmb_modCat.BackColor = System.Drawing.SystemColors.Control
		Me.cmb_modCat.CausesValidation = True
		Me.cmb_modCat.Enabled = True
		Me.cmb_modCat.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmb_modCat.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmb_modCat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmb_modCat.TabStop = True
		Me.cmb_modCat.Name = "cmb_modCat"
		Me.cmbcatégorie.Size = New System.Drawing.Size(137, 21)
		Me.cmbcatégorie.Location = New System.Drawing.Point(96, 120)
		Me.cmbcatégorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbcatégorie.TabIndex = 77
		Me.cmbcatégorie.BackColor = System.Drawing.SystemColors.Window
		Me.cmbcatégorie.CausesValidation = True
		Me.cmbcatégorie.Enabled = True
		Me.cmbcatégorie.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbcatégorie.IntegralHeight = True
		Me.cmbcatégorie.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbcatégorie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbcatégorie.Sorted = False
		Me.cmbcatégorie.TabStop = True
		Me.cmbcatégorie.Visible = True
		Me.cmbcatégorie.Name = "cmbcatégorie"
		Me.cmdMailListFournisseur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMailListFournisseur.Text = "Ajouter au mailing list"
		Me.cmdMailListFournisseur.Size = New System.Drawing.Size(113, 33)
		Me.cmdMailListFournisseur.Location = New System.Drawing.Point(416, 456)
		Me.cmdMailListFournisseur.TabIndex = 75
		Me.cmdMailListFournisseur.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMailListFournisseur.CausesValidation = True
		Me.cmdMailListFournisseur.Enabled = True
		Me.cmdMailListFournisseur.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMailListFournisseur.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMailListFournisseur.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMailListFournisseur.TabStop = True
		Me.cmdMailListFournisseur.Name = "cmdMailListFournisseur"
		Me.fraEtatOutlook.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.fraEtatOutlook.Size = New System.Drawing.Size(505, 145)
		Me.fraEtatOutlook.Location = New System.Drawing.Point(48, 184)
		Me.fraEtatOutlook.TabIndex = 16
		Me.fraEtatOutlook.Visible = False
		Me.fraEtatOutlook.BackColor = System.Drawing.SystemColors.Control
		Me.fraEtatOutlook.Enabled = True
		Me.fraEtatOutlook.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraEtatOutlook.Cursor = System.Windows.Forms.Cursors.Default
		Me.fraEtatOutlook.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraEtatOutlook.Name = "fraEtatOutlook"
		Me.lblEtatOutlook.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblEtatOutlook.Text = "Liaison du contact avec le fournisseur dans Outlook ..."
		Me.lblEtatOutlook.Size = New System.Drawing.Size(505, 25)
		Me.lblEtatOutlook.Location = New System.Drawing.Point(0, 56)
		Me.lblEtatOutlook.TabIndex = 17
		Me.lblEtatOutlook.BackColor = System.Drawing.SystemColors.Control
		Me.lblEtatOutlook.Enabled = True
		Me.lblEtatOutlook.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblEtatOutlook.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblEtatOutlook.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblEtatOutlook.UseMnemonic = True
		Me.lblEtatOutlook.Visible = True
		Me.lblEtatOutlook.AutoSize = False
		Me.lblEtatOutlook.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblEtatOutlook.Name = "lblEtatOutlook"
		Me.cmdFax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFax.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFax.Text = "Envoyer Fax"
		Me.cmdFax.Size = New System.Drawing.Size(73, 33)
		Me.cmdFax.Location = New System.Drawing.Point(336, 456)
		Me.cmdFax.TabIndex = 73
		Me.cmdFax.CausesValidation = True
		Me.cmdFax.Enabled = True
		Me.cmdFax.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFax.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFax.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFax.TabStop = True
		Me.cmdFax.Name = "cmdFax"
		Me.txtFax.AutoSize = False
		Me.txtFax.BackColor = System.Drawing.Color.White
		Me.txtFax.Size = New System.Drawing.Size(137, 20)
		Me.txtFax.Location = New System.Drawing.Point(96, 176)
		Me.txtFax.ReadOnly = True
		Me.txtFax.TabIndex = 14
		Me.txtFax.Text = "Text1"
		Me.txtFax.AcceptsReturn = True
		Me.txtFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtFax.CausesValidation = True
		Me.txtFax.Enabled = True
		Me.txtFax.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtFax.HideSelection = True
		Me.txtFax.Maxlength = 0
		Me.txtFax.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtFax.MultiLine = False
		Me.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtFax.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtFax.TabStop = True
		Me.txtFax.Visible = True
		Me.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtFax.Name = "txtFax"
		Me.fraContact.BackColor = System.Drawing.Color.Black
		Me.fraContact.Text = "Contact"
		Me.fraContact.ForeColor = System.Drawing.Color.White
		Me.fraContact.Size = New System.Drawing.Size(297, 305)
		Me.fraContact.Location = New System.Drawing.Point(312, 144)
		Me.fraContact.TabIndex = 37
		Me.fraContact.Enabled = True
		Me.fraContact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraContact.Visible = True
		Me.fraContact.Padding = New System.Windows.Forms.Padding(0)
		Me.fraContact.Name = "fraContact"
		Me.cmdMailListContact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMailListContact.Text = "Ajouter au mailing list"
		Me.cmdMailListContact.Size = New System.Drawing.Size(121, 33)
		Me.cmdMailListContact.Location = New System.Drawing.Point(168, 264)
		Me.cmdMailListContact.TabIndex = 76
		Me.cmdMailListContact.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMailListContact.CausesValidation = True
		Me.cmdMailListContact.Enabled = True
		Me.cmdMailListContact.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMailListContact.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMailListContact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMailListContact.TabStop = True
		Me.cmdMailListContact.Name = "cmdMailListContact"
		Me.txtContactTitre.AutoSize = False
		Me.txtContactTitre.BackColor = System.Drawing.Color.White
		Me.txtContactTitre.Size = New System.Drawing.Size(105, 20)
		Me.txtContactTitre.Location = New System.Drawing.Point(72, 64)
		Me.txtContactTitre.ReadOnly = True
		Me.txtContactTitre.TabIndex = 42
		Me.txtContactTitre.AcceptsReturn = True
		Me.txtContactTitre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtContactTitre.CausesValidation = True
		Me.txtContactTitre.Enabled = True
		Me.txtContactTitre.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtContactTitre.HideSelection = True
		Me.txtContactTitre.Maxlength = 0
		Me.txtContactTitre.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtContactTitre.MultiLine = False
		Me.txtContactTitre.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtContactTitre.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtContactTitre.TabStop = True
		Me.txtContactTitre.Visible = True
		Me.txtContactTitre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtContactTitre.Name = "txtContactTitre"
		Me.txtContactPage.AutoSize = False
		Me.txtContactPage.BackColor = System.Drawing.Color.White
		Me.txtContactPage.Size = New System.Drawing.Size(105, 20)
		Me.txtContactPage.Location = New System.Drawing.Point(72, 208)
		Me.txtContactPage.ReadOnly = True
		Me.txtContactPage.TabIndex = 57
		Me.txtContactPage.AcceptsReturn = True
		Me.txtContactPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtContactPage.CausesValidation = True
		Me.txtContactPage.Enabled = True
		Me.txtContactPage.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtContactPage.HideSelection = True
		Me.txtContactPage.Maxlength = 0
		Me.txtContactPage.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtContactPage.MultiLine = False
		Me.txtContactPage.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtContactPage.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtContactPage.TabStop = True
		Me.txtContactPage.Visible = True
		Me.txtContactPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtContactPage.Name = "txtContactPage"
		Me.txtContactEmail.AutoSize = False
		Me.txtContactEmail.BackColor = System.Drawing.Color.White
		Me.txtContactEmail.Size = New System.Drawing.Size(217, 20)
		Me.txtContactEmail.Location = New System.Drawing.Point(72, 232)
		Me.txtContactEmail.ReadOnly = True
		Me.txtContactEmail.TabIndex = 61
		Me.txtContactEmail.AcceptsReturn = True
		Me.txtContactEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtContactEmail.CausesValidation = True
		Me.txtContactEmail.Enabled = True
		Me.txtContactEmail.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtContactEmail.HideSelection = True
		Me.txtContactEmail.Maxlength = 0
		Me.txtContactEmail.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtContactEmail.MultiLine = False
		Me.txtContactEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtContactEmail.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtContactEmail.TabStop = True
		Me.txtContactEmail.Visible = True
		Me.txtContactEmail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtContactEmail.Name = "txtContactEmail"
		Me.txtContactPoste.AutoSize = False
		Me.txtContactPoste.BackColor = System.Drawing.Color.White
		Me.txtContactPoste.Size = New System.Drawing.Size(49, 20)
		Me.txtContactPoste.Location = New System.Drawing.Point(72, 136)
		Me.txtContactPoste.ReadOnly = True
		Me.txtContactPoste.TabIndex = 51
		Me.txtContactPoste.AcceptsReturn = True
		Me.txtContactPoste.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtContactPoste.CausesValidation = True
		Me.txtContactPoste.Enabled = True
		Me.txtContactPoste.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtContactPoste.HideSelection = True
		Me.txtContactPoste.Maxlength = 0
		Me.txtContactPoste.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtContactPoste.MultiLine = False
		Me.txtContactPoste.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtContactPoste.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtContactPoste.TabStop = True
		Me.txtContactPoste.Visible = True
		Me.txtContactPoste.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtContactPoste.Name = "txtContactPoste"
		Me.txtContactTel.AutoSize = False
		Me.txtContactTel.BackColor = System.Drawing.Color.White
		Me.txtContactTel.Size = New System.Drawing.Size(105, 20)
		Me.txtContactTel.Location = New System.Drawing.Point(72, 88)
		Me.txtContactTel.ReadOnly = True
		Me.txtContactTel.TabIndex = 43
		Me.txtContactTel.AcceptsReturn = True
		Me.txtContactTel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtContactTel.CausesValidation = True
		Me.txtContactTel.Enabled = True
		Me.txtContactTel.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtContactTel.HideSelection = True
		Me.txtContactTel.Maxlength = 0
		Me.txtContactTel.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtContactTel.MultiLine = False
		Me.txtContactTel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtContactTel.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtContactTel.TabStop = True
		Me.txtContactTel.Visible = True
		Me.txtContactTel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtContactTel.Name = "txtContactTel"
		Me.cmbcontact.BackColor = System.Drawing.Color.White
		Me.cmbcontact.Size = New System.Drawing.Size(217, 21)
		Me.cmbcontact.Location = New System.Drawing.Point(72, 24)
		Me.cmbcontact.TabIndex = 39
		Me.cmbcontact.CausesValidation = True
		Me.cmbcontact.Enabled = True
		Me.cmbcontact.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbcontact.IntegralHeight = True
		Me.cmbcontact.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbcontact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbcontact.Sorted = False
		Me.cmbcontact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbcontact.TabStop = True
		Me.cmbcontact.Visible = True
		Me.cmbcontact.Name = "cmbcontact"
		Me.txtContactFax.AutoSize = False
		Me.txtContactFax.BackColor = System.Drawing.Color.White
		Me.txtContactFax.Size = New System.Drawing.Size(105, 20)
		Me.txtContactFax.Location = New System.Drawing.Point(72, 184)
		Me.txtContactFax.ReadOnly = True
		Me.txtContactFax.TabIndex = 55
		Me.txtContactFax.AcceptsReturn = True
		Me.txtContactFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtContactFax.CausesValidation = True
		Me.txtContactFax.Enabled = True
		Me.txtContactFax.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtContactFax.HideSelection = True
		Me.txtContactFax.Maxlength = 0
		Me.txtContactFax.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtContactFax.MultiLine = False
		Me.txtContactFax.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtContactFax.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtContactFax.TabStop = True
		Me.txtContactFax.Visible = True
		Me.txtContactFax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtContactFax.Name = "txtContactFax"
		Me.txtContactCell.AutoSize = False
		Me.txtContactCell.BackColor = System.Drawing.Color.White
		Me.txtContactCell.Size = New System.Drawing.Size(105, 20)
		Me.txtContactCell.Location = New System.Drawing.Point(72, 160)
		Me.txtContactCell.ReadOnly = True
		Me.txtContactCell.TabIndex = 52
		Me.txtContactCell.AcceptsReturn = True
		Me.txtContactCell.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtContactCell.CausesValidation = True
		Me.txtContactCell.Enabled = True
		Me.txtContactCell.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtContactCell.HideSelection = True
		Me.txtContactCell.Maxlength = 0
		Me.txtContactCell.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtContactCell.MultiLine = False
		Me.txtContactCell.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtContactCell.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtContactCell.TabStop = True
		Me.txtContactCell.Visible = True
		Me.txtContactCell.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtContactCell.Name = "txtContactCell"
		Me.cmdsupcontact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdsupcontact.BackColor = System.Drawing.SystemColors.Control
		Me.cmdsupcontact.Text = "Supprimer"
		Me.cmdsupcontact.Size = New System.Drawing.Size(73, 33)
		Me.cmdsupcontact.Location = New System.Drawing.Point(88, 264)
		Me.cmdsupcontact.TabIndex = 64
		Me.cmdsupcontact.CausesValidation = True
		Me.cmdsupcontact.Enabled = True
		Me.cmdsupcontact.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdsupcontact.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdsupcontact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdsupcontact.TabStop = True
		Me.cmdsupcontact.Name = "cmdsupcontact"
		Me.txtContactDom.AutoSize = False
		Me.txtContactDom.BackColor = System.Drawing.Color.White
		Me.txtContactDom.Size = New System.Drawing.Size(105, 20)
		Me.txtContactDom.Location = New System.Drawing.Point(72, 112)
		Me.txtContactDom.ReadOnly = True
		Me.txtContactDom.TabIndex = 47
		Me.txtContactDom.AcceptsReturn = True
		Me.txtContactDom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtContactDom.CausesValidation = True
		Me.txtContactDom.Enabled = True
		Me.txtContactDom.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtContactDom.HideSelection = True
		Me.txtContactDom.Maxlength = 0
		Me.txtContactDom.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtContactDom.MultiLine = False
		Me.txtContactDom.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtContactDom.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtContactDom.TabStop = True
		Me.txtContactDom.Visible = True
		Me.txtContactDom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtContactDom.Name = "txtContactDom"
		Me.CmdAddCont.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdAddCont.Text = "Ajouter"
		Me.CmdAddCont.Size = New System.Drawing.Size(73, 33)
		Me.CmdAddCont.Location = New System.Drawing.Point(8, 264)
		Me.CmdAddCont.TabIndex = 63
		Me.CmdAddCont.BackColor = System.Drawing.SystemColors.Control
		Me.CmdAddCont.CausesValidation = True
		Me.CmdAddCont.Enabled = True
		Me.CmdAddCont.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdAddCont.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdAddCont.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdAddCont.TabStop = True
		Me.CmdAddCont.Name = "CmdAddCont"
		Me.cmdEnregistrerContact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEnregistrerContact.Text = "Enregistrer"
		Me.cmdEnregistrerContact.Size = New System.Drawing.Size(73, 33)
		Me.cmdEnregistrerContact.Location = New System.Drawing.Point(8, 264)
		Me.cmdEnregistrerContact.TabIndex = 62
		Me.cmdEnregistrerContact.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEnregistrerContact.CausesValidation = True
		Me.cmdEnregistrerContact.Enabled = True
		Me.cmdEnregistrerContact.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEnregistrerContact.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEnregistrerContact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEnregistrerContact.TabStop = True
		Me.cmdEnregistrerContact.Name = "cmdEnregistrerContact"
		Me.cmdAnnulerContact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnulerContact.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnulerContact.Text = "A&nnuler"
		Me.cmdAnnulerContact.Size = New System.Drawing.Size(73, 33)
		Me.cmdAnnulerContact.Location = New System.Drawing.Point(88, 264)
		Me.cmdAnnulerContact.TabIndex = 65
		Me.cmdAnnulerContact.CausesValidation = True
		Me.cmdAnnulerContact.Enabled = True
		Me.cmdAnnulerContact.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnulerContact.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnulerContact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnulerContact.TabStop = True
		Me.cmdAnnulerContact.Name = "cmdAnnulerContact"
		Me.mskContactPage.AllowPromptAsInput = False
		Me.mskContactPage.Size = New System.Drawing.Size(105, 19)
		Me.mskContactPage.Location = New System.Drawing.Point(72, 208)
		Me.mskContactPage.TabIndex = 58
		Me.mskContactPage.Visible = False
		Me.mskContactPage.PromptChar = "_"
		Me.mskContactPage.Name = "mskContactPage"
		Me.mskContactFax.AllowPromptAsInput = False
		Me.mskContactFax.Size = New System.Drawing.Size(105, 19)
		Me.mskContactFax.Location = New System.Drawing.Point(72, 184)
		Me.mskContactFax.TabIndex = 56
		Me.mskContactFax.Visible = False
		Me.mskContactFax.PromptChar = "_"
		Me.mskContactFax.Name = "mskContactFax"
		Me.mskContactCell.AllowPromptAsInput = False
		Me.mskContactCell.Size = New System.Drawing.Size(105, 19)
		Me.mskContactCell.Location = New System.Drawing.Point(72, 160)
		Me.mskContactCell.TabIndex = 53
		Me.mskContactCell.Visible = False
		Me.mskContactCell.PromptChar = "_"
		Me.mskContactCell.Name = "mskContactCell"
		Me.mskContactDom.AllowPromptAsInput = False
		Me.mskContactDom.Size = New System.Drawing.Size(105, 19)
		Me.mskContactDom.Location = New System.Drawing.Point(72, 112)
		Me.mskContactDom.TabIndex = 48
		Me.mskContactDom.Visible = False
		Me.mskContactDom.PromptChar = "_"
		Me.mskContactDom.Name = "mskContactDom"
		Me.mskContactTel.AllowPromptAsInput = False
		Me.mskContactTel.Size = New System.Drawing.Size(105, 19)
		Me.mskContactTel.Location = New System.Drawing.Point(72, 88)
		Me.mskContactTel.TabIndex = 44
		Me.mskContactTel.Visible = False
		Me.mskContactTel.PromptChar = "_"
		Me.mskContactTel.Name = "mskContactTel"
		Me.txtContact.AutoSize = False
		Me.txtContact.BackColor = System.Drawing.Color.White
		Me.txtContact.Size = New System.Drawing.Size(217, 20)
		Me.txtContact.Location = New System.Drawing.Point(72, 24)
		Me.txtContact.ReadOnly = True
		Me.txtContact.TabIndex = 40
		Me.txtContact.Text = "Text1"
		Me.txtContact.Visible = False
		Me.txtContact.AcceptsReturn = True
		Me.txtContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtContact.CausesValidation = True
		Me.txtContact.Enabled = True
		Me.txtContact.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtContact.HideSelection = True
		Me.txtContact.Maxlength = 0
		Me.txtContact.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtContact.MultiLine = False
		Me.txtContact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtContact.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtContact.TabStop = True
		Me.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtContact.Name = "txtContact"
		Me._Label1_8.Text = "Titre "
		Me._Label1_8.ForeColor = System.Drawing.Color.White
		Me._Label1_8.Size = New System.Drawing.Size(73, 17)
		Me._Label1_8.Location = New System.Drawing.Point(8, 64)
		Me._Label1_8.TabIndex = 41
		Me._Label1_8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_8.BackColor = System.Drawing.Color.Transparent
		Me._Label1_8.Enabled = True
		Me._Label1_8.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_8.UseMnemonic = True
		Me._Label1_8.Visible = True
		Me._Label1_8.AutoSize = False
		Me._Label1_8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_8.Name = "_Label1_8"
		Me.Label2.Text = "Contact"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(73, 17)
		Me.Label2.Location = New System.Drawing.Point(8, 24)
		Me.Label2.TabIndex = 38
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
		Me._Label1_7.Text = "Poste"
		Me._Label1_7.ForeColor = System.Drawing.Color.White
		Me._Label1_7.Size = New System.Drawing.Size(73, 17)
		Me._Label1_7.Location = New System.Drawing.Point(8, 136)
		Me._Label1_7.TabIndex = 50
		Me._Label1_7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_7.BackColor = System.Drawing.Color.Transparent
		Me._Label1_7.Enabled = True
		Me._Label1_7.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_7.UseMnemonic = True
		Me._Label1_7.Visible = True
		Me._Label1_7.AutoSize = False
		Me._Label1_7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_7.Name = "_Label1_7"
		Me._Label1_5.Text = "E-Mail"
		Me._Label1_5.ForeColor = System.Drawing.Color.White
		Me._Label1_5.Size = New System.Drawing.Size(65, 17)
		Me._Label1_5.Location = New System.Drawing.Point(8, 232)
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
		Me._Label1_4.Text = "Pagette"
		Me._Label1_4.ForeColor = System.Drawing.Color.White
		Me._Label1_4.Size = New System.Drawing.Size(65, 17)
		Me._Label1_4.Location = New System.Drawing.Point(8, 208)
		Me._Label1_4.TabIndex = 59
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
		Me._Label1_3.Text = "Fax"
		Me._Label1_3.ForeColor = System.Drawing.Color.White
		Me._Label1_3.Size = New System.Drawing.Size(65, 17)
		Me._Label1_3.Location = New System.Drawing.Point(8, 184)
		Me._Label1_3.TabIndex = 54
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
		Me._Label1_2.Text = "Cellulaire"
		Me._Label1_2.ForeColor = System.Drawing.Color.White
		Me._Label1_2.Size = New System.Drawing.Size(65, 17)
		Me._Label1_2.Location = New System.Drawing.Point(8, 160)
		Me._Label1_2.TabIndex = 49
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
		Me._Label1_1.Text = "Telephone"
		Me._Label1_1.ForeColor = System.Drawing.Color.White
		Me._Label1_1.Size = New System.Drawing.Size(73, 17)
		Me._Label1_1.Location = New System.Drawing.Point(8, 88)
		Me._Label1_1.TabIndex = 45
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
		Me._Label1_6.Text = "Domicile"
		Me._Label1_6.ForeColor = System.Drawing.Color.White
		Me._Label1_6.Size = New System.Drawing.Size(73, 17)
		Me._Label1_6.Location = New System.Drawing.Point(8, 112)
		Me._Label1_6.TabIndex = 46
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
		Me.cmdRechercher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRechercher.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercher.Text = "Rechercher"
		Me.AcceptButton = Me.cmdRechercher
		Me.cmdRechercher.Size = New System.Drawing.Size(81, 25)
		Me.cmdRechercher.Location = New System.Drawing.Point(480, 40)
		Me.cmdRechercher.TabIndex = 2
		Me.cmdRechercher.CausesValidation = True
		Me.cmdRechercher.Enabled = True
		Me.cmdRechercher.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercher.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercher.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercher.TabStop = True
		Me.cmdRechercher.Name = "cmdRechercher"
		Me.cmdRafraichir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRafraichir.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRafraichir.Text = "Rafraîchir"
		Me.cmdRafraichir.Size = New System.Drawing.Size(65, 17)
		Me.cmdRafraichir.Location = New System.Drawing.Point(112, 72)
		Me.cmdRafraichir.TabIndex = 3
		Me.cmdRafraichir.CausesValidation = True
		Me.cmdRafraichir.Enabled = True
		Me.cmdRafraichir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRafraichir.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRafraichir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRafraichir.TabStop = True
		Me.cmdRafraichir.Name = "cmdRafraichir"
		Me.cmdreport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdreport.BackColor = System.Drawing.SystemColors.Control
		Me.cmdreport.Text = "&Impression"
		Me.cmdreport.Size = New System.Drawing.Size(73, 33)
		Me.cmdreport.Location = New System.Drawing.Point(8, 456)
		Me.cmdreport.TabIndex = 67
		Me.cmdreport.CausesValidation = True
		Me.cmdreport.Enabled = True
		Me.cmdreport.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdreport.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdreport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdreport.TabStop = True
		Me.cmdreport.Name = "cmdreport"
		Me.txtSiteWeb.AutoSize = False
		Me.txtSiteWeb.BackColor = System.Drawing.Color.White
		Me.txtSiteWeb.Size = New System.Drawing.Size(137, 20)
		Me.txtSiteWeb.Location = New System.Drawing.Point(96, 372)
		Me.txtSiteWeb.ReadOnly = True
		Me.txtSiteWeb.TabIndex = 30
		Me.txtSiteWeb.Text = "Text1"
		Me.txtSiteWeb.AcceptsReturn = True
		Me.txtSiteWeb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtSiteWeb.CausesValidation = True
		Me.txtSiteWeb.Enabled = True
		Me.txtSiteWeb.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSiteWeb.HideSelection = True
		Me.txtSiteWeb.Maxlength = 0
		Me.txtSiteWeb.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSiteWeb.MultiLine = False
		Me.txtSiteWeb.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSiteWeb.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtSiteWeb.TabStop = True
		Me.txtSiteWeb.Visible = True
		Me.txtSiteWeb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtSiteWeb.Name = "txtSiteWeb"
		Me.cmdrenommer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdrenommer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdrenommer.Text = "Renommer"
		Me.cmdrenommer.Size = New System.Drawing.Size(65, 17)
		Me.cmdrenommer.Location = New System.Drawing.Point(176, 72)
		Me.cmdrenommer.TabIndex = 4
		Me.cmdrenommer.CausesValidation = True
		Me.cmdrenommer.Enabled = True
		Me.cmdrenommer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdrenommer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdrenommer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdrenommer.TabStop = True
		Me.cmdrenommer.Name = "cmdrenommer"
		Me.txtCommentaire.AutoSize = False
		Me.txtCommentaire.BackColor = System.Drawing.Color.White
		Me.txtCommentaire.Size = New System.Drawing.Size(177, 43)
		Me.txtCommentaire.Location = New System.Drawing.Point(432, 104)
		Me.txtCommentaire.ReadOnly = True
		Me.txtCommentaire.Maxlength = 1000
		Me.txtCommentaire.MultiLine = True
		Me.txtCommentaire.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtCommentaire.TabIndex = 9
		Me.txtCommentaire.Text = "Text1"
		Me.txtCommentaire.AcceptsReturn = True
		Me.txtCommentaire.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCommentaire.CausesValidation = True
		Me.txtCommentaire.Enabled = True
		Me.txtCommentaire.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCommentaire.HideSelection = True
		Me.txtCommentaire.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCommentaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCommentaire.TabStop = True
		Me.txtCommentaire.Visible = True
		Me.txtCommentaire.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCommentaire.Name = "txtCommentaire"
		Me.txtRechercher.AutoSize = False
		Me.txtRechercher.BackColor = System.Drawing.Color.White
		Me.txtRechercher.Size = New System.Drawing.Size(129, 25)
		Me.txtRechercher.Location = New System.Drawing.Point(336, 40)
		Me.txtRechercher.TabIndex = 1
		Me.txtRechercher.AcceptsReturn = True
		Me.txtRechercher.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
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
		Me.CmdModif.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdModif.BackColor = System.Drawing.SystemColors.Control
		Me.CmdModif.Text = "&Modifier"
		Me.CmdModif.Size = New System.Drawing.Size(73, 33)
		Me.CmdModif.Location = New System.Drawing.Point(256, 456)
		Me.CmdModif.TabIndex = 72
		Me.CmdModif.CausesValidation = True
		Me.CmdModif.Enabled = True
		Me.CmdModif.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdModif.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdModif.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdModif.TabStop = True
		Me.CmdModif.Name = "CmdModif"
		Me.txtEmail.AutoSize = False
		Me.txtEmail.BackColor = System.Drawing.Color.White
		Me.txtEmail.Size = New System.Drawing.Size(137, 20)
		Me.txtEmail.Location = New System.Drawing.Point(96, 204)
		Me.txtEmail.ReadOnly = True
		Me.txtEmail.TabIndex = 19
		Me.txtEmail.Text = "Text1"
		Me.txtEmail.AcceptsReturn = True
		Me.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtEmail.CausesValidation = True
		Me.txtEmail.Enabled = True
		Me.txtEmail.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtEmail.HideSelection = True
		Me.txtEmail.Maxlength = 0
		Me.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtEmail.MultiLine = False
		Me.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtEmail.TabStop = True
		Me.txtEmail.Visible = True
		Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtEmail.Name = "txtEmail"
		Me.txtTelephone.AutoSize = False
		Me.txtTelephone.BackColor = System.Drawing.Color.White
		Me.txtTelephone.Size = New System.Drawing.Size(137, 20)
		Me.txtTelephone.Location = New System.Drawing.Point(96, 148)
		Me.txtTelephone.ReadOnly = True
		Me.txtTelephone.TabIndex = 12
		Me.txtTelephone.Text = "Text1"
		Me.txtTelephone.AcceptsReturn = True
		Me.txtTelephone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTelephone.CausesValidation = True
		Me.txtTelephone.Enabled = True
		Me.txtTelephone.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTelephone.HideSelection = True
		Me.txtTelephone.Maxlength = 0
		Me.txtTelephone.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTelephone.MultiLine = False
		Me.txtTelephone.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTelephone.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTelephone.TabStop = True
		Me.txtTelephone.Visible = True
		Me.txtTelephone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTelephone.Name = "txtTelephone"
		Me.txtCP.AutoSize = False
		Me.txtCP.BackColor = System.Drawing.Color.White
		Me.txtCP.Size = New System.Drawing.Size(137, 20)
		Me.txtCP.Location = New System.Drawing.Point(96, 344)
		Me.txtCP.ReadOnly = True
		Me.txtCP.TabIndex = 29
		Me.txtCP.Text = "Text1"
		Me.txtCP.AcceptsReturn = True
		Me.txtCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCP.CausesValidation = True
		Me.txtCP.Enabled = True
		Me.txtCP.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCP.HideSelection = True
		Me.txtCP.Maxlength = 0
		Me.txtCP.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCP.MultiLine = False
		Me.txtCP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCP.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCP.TabStop = True
		Me.txtCP.Visible = True
		Me.txtCP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCP.Name = "txtCP"
		Me.txtPays.AutoSize = False
		Me.txtPays.BackColor = System.Drawing.Color.White
		Me.txtPays.Size = New System.Drawing.Size(137, 20)
		Me.txtPays.Location = New System.Drawing.Point(96, 316)
		Me.txtPays.ReadOnly = True
		Me.txtPays.TabIndex = 27
		Me.txtPays.Text = "Text1"
		Me.txtPays.AcceptsReturn = True
		Me.txtPays.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPays.CausesValidation = True
		Me.txtPays.Enabled = True
		Me.txtPays.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPays.HideSelection = True
		Me.txtPays.Maxlength = 0
		Me.txtPays.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPays.MultiLine = False
		Me.txtPays.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPays.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPays.TabStop = True
		Me.txtPays.Visible = True
		Me.txtPays.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPays.Name = "txtPays"
		Me.txtProvEtat.AutoSize = False
		Me.txtProvEtat.BackColor = System.Drawing.Color.White
		Me.txtProvEtat.Size = New System.Drawing.Size(137, 20)
		Me.txtProvEtat.Location = New System.Drawing.Point(96, 288)
		Me.txtProvEtat.ReadOnly = True
		Me.txtProvEtat.TabIndex = 25
		Me.txtProvEtat.Text = "Text1"
		Me.txtProvEtat.AcceptsReturn = True
		Me.txtProvEtat.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtProvEtat.CausesValidation = True
		Me.txtProvEtat.Enabled = True
		Me.txtProvEtat.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtProvEtat.HideSelection = True
		Me.txtProvEtat.Maxlength = 0
		Me.txtProvEtat.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtProvEtat.MultiLine = False
		Me.txtProvEtat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtProvEtat.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtProvEtat.TabStop = True
		Me.txtProvEtat.Visible = True
		Me.txtProvEtat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtProvEtat.Name = "txtProvEtat"
		Me.txtVille.AutoSize = False
		Me.txtVille.BackColor = System.Drawing.Color.White
		Me.txtVille.Size = New System.Drawing.Size(137, 20)
		Me.txtVille.Location = New System.Drawing.Point(96, 260)
		Me.txtVille.ReadOnly = True
		Me.txtVille.TabIndex = 23
		Me.txtVille.Text = "Text1"
		Me.txtVille.AcceptsReturn = True
		Me.txtVille.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtVille.CausesValidation = True
		Me.txtVille.Enabled = True
		Me.txtVille.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtVille.HideSelection = True
		Me.txtVille.Maxlength = 0
		Me.txtVille.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtVille.MultiLine = False
		Me.txtVille.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtVille.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtVille.TabStop = True
		Me.txtVille.Visible = True
		Me.txtVille.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtVille.Name = "txtVille"
		Me.txtAdresse.AutoSize = False
		Me.txtAdresse.BackColor = System.Drawing.Color.White
		Me.txtAdresse.Size = New System.Drawing.Size(137, 20)
		Me.txtAdresse.Location = New System.Drawing.Point(96, 232)
		Me.txtAdresse.ReadOnly = True
		Me.txtAdresse.TabIndex = 21
		Me.txtAdresse.Text = "Text1"
		Me.txtAdresse.AcceptsReturn = True
		Me.txtAdresse.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtAdresse.CausesValidation = True
		Me.txtAdresse.Enabled = True
		Me.txtAdresse.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAdresse.HideSelection = True
		Me.txtAdresse.Maxlength = 0
		Me.txtAdresse.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAdresse.MultiLine = False
		Me.txtAdresse.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAdresse.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtAdresse.TabStop = True
		Me.txtAdresse.Visible = True
		Me.txtAdresse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAdresse.Name = "txtAdresse"
		Me.CmdFerme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdFerme.BackColor = System.Drawing.SystemColors.Control
		Me.CmdFerme.Text = "&Fermer"
		Me.CmdFerme.Size = New System.Drawing.Size(73, 33)
		Me.CmdFerme.Location = New System.Drawing.Point(536, 456)
		Me.CmdFerme.TabIndex = 74
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
		Me.CmdSupp.Size = New System.Drawing.Size(73, 33)
		Me.CmdSupp.Location = New System.Drawing.Point(176, 456)
		Me.CmdSupp.TabIndex = 71
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
		Me.CmdAdd.Size = New System.Drawing.Size(73, 33)
		Me.CmdAdd.Location = New System.Drawing.Point(96, 456)
		Me.CmdAdd.TabIndex = 68
		Me.CmdAdd.CausesValidation = True
		Me.CmdAdd.Enabled = True
		Me.CmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdAdd.TabStop = True
		Me.CmdAdd.Name = "CmdAdd"
		Me.mskTelephone.AllowPromptAsInput = False
		Me.mskTelephone.Size = New System.Drawing.Size(137, 19)
		Me.mskTelephone.Location = New System.Drawing.Point(96, 148)
		Me.mskTelephone.TabIndex = 11
		Me.mskTelephone.PromptChar = "_"
		Me.mskTelephone.Name = "mskTelephone"
		Me.CmdEnr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdEnr.Text = "&Enregistrer"
		Me.CmdEnr.Size = New System.Drawing.Size(73, 33)
		Me.CmdEnr.Location = New System.Drawing.Point(96, 456)
		Me.CmdEnr.TabIndex = 69
		Me.CmdEnr.BackColor = System.Drawing.SystemColors.Control
		Me.CmdEnr.CausesValidation = True
		Me.CmdEnr.Enabled = True
		Me.CmdEnr.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdEnr.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdEnr.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdEnr.TabStop = True
		Me.CmdEnr.Name = "CmdEnr"
		Me.CmdAnul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdAnul.Text = "A&nnuler"
		Me.CmdAnul.Size = New System.Drawing.Size(73, 33)
		Me.CmdAnul.Location = New System.Drawing.Point(176, 456)
		Me.CmdAnul.TabIndex = 70
		Me.CmdAnul.BackColor = System.Drawing.SystemColors.Control
		Me.CmdAnul.CausesValidation = True
		Me.CmdAnul.Enabled = True
		Me.CmdAnul.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdAnul.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdAnul.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdAnul.TabStop = True
		Me.CmdAnul.Name = "CmdAnul"
		Me.txtNomFournisseur.AutoSize = False
		Me.txtNomFournisseur.BackColor = System.Drawing.Color.White
		Me.txtNomFournisseur.Size = New System.Drawing.Size(273, 20)
		Me.txtNomFournisseur.Location = New System.Drawing.Point(96, 88)
		Me.txtNomFournisseur.ReadOnly = True
		Me.txtNomFournisseur.TabIndex = 7
		Me.txtNomFournisseur.Text = "Text1"
		Me.txtNomFournisseur.Visible = False
		Me.txtNomFournisseur.AcceptsReturn = True
		Me.txtNomFournisseur.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNomFournisseur.CausesValidation = True
		Me.txtNomFournisseur.Enabled = True
		Me.txtNomFournisseur.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNomFournisseur.HideSelection = True
		Me.txtNomFournisseur.Maxlength = 0
		Me.txtNomFournisseur.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNomFournisseur.MultiLine = False
		Me.txtNomFournisseur.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNomFournisseur.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNomFournisseur.TabStop = True
		Me.txtNomFournisseur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNomFournisseur.Name = "txtNomFournisseur"
		Me.cmbFournisseur.BackColor = System.Drawing.Color.White
		Me.cmbFournisseur.Size = New System.Drawing.Size(289, 21)
		Me.cmbFournisseur.Location = New System.Drawing.Point(96, 88)
		Me.cmbFournisseur.Sorted = True
		Me.cmbFournisseur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbFournisseur.TabIndex = 6
		Me.cmbFournisseur.CausesValidation = True
		Me.cmbFournisseur.Enabled = True
		Me.cmbFournisseur.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbFournisseur.IntegralHeight = True
		Me.cmbFournisseur.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbFournisseur.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbFournisseur.TabStop = True
		Me.cmbFournisseur.Visible = True
		Me.cmbFournisseur.Name = "cmbFournisseur"
		Me.mskFax.AllowPromptAsInput = False
		Me.mskFax.Size = New System.Drawing.Size(137, 19)
		Me.mskFax.Location = New System.Drawing.Point(96, 176)
		Me.mskFax.TabIndex = 15
		Me.mskFax.PromptChar = "_"
		Me.mskFax.Name = "mskFax"
		Me.Label3.Text = "Catégorie"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(73, 17)
		Me.Label3.Location = New System.Drawing.Point(8, 120)
		Me.Label3.TabIndex = 78
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
		Me.lblUserModification.Text = "Par :"
		Me.lblUserModification.ForeColor = System.Drawing.Color.White
		Me.lblUserModification.Size = New System.Drawing.Size(89, 17)
		Me.lblUserModification.Location = New System.Drawing.Point(168, 428)
		Me.lblUserModification.TabIndex = 36
		Me.lblUserModification.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblUserModification.BackColor = System.Drawing.Color.Transparent
		Me.lblUserModification.Enabled = True
		Me.lblUserModification.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblUserModification.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblUserModification.UseMnemonic = True
		Me.lblUserModification.Visible = True
		Me.lblUserModification.AutoSize = False
		Me.lblUserModification.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblUserModification.Name = "lblUserModification"
		Me.lblUserCreation.Text = "Par :"
		Me.lblUserCreation.ForeColor = System.Drawing.Color.White
		Me.lblUserCreation.Size = New System.Drawing.Size(89, 17)
		Me.lblUserCreation.Location = New System.Drawing.Point(168, 400)
		Me.lblUserCreation.TabIndex = 33
		Me.lblUserCreation.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblUserCreation.BackColor = System.Drawing.Color.Transparent
		Me.lblUserCreation.Enabled = True
		Me.lblUserCreation.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblUserCreation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblUserCreation.UseMnemonic = True
		Me.lblUserCreation.Visible = True
		Me.lblUserCreation.AutoSize = False
		Me.lblUserCreation.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblUserCreation.Name = "lblUserCreation"
		Me.lblDateModification.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblDateModification.BackColor = System.Drawing.Color.White
		Me.lblDateModification.Text = "2004-09-14"
		Me.lblDateModification.Size = New System.Drawing.Size(65, 19)
		Me.lblDateModification.Location = New System.Drawing.Point(96, 428)
		Me.lblDateModification.TabIndex = 35
		Me.lblDateModification.Enabled = True
		Me.lblDateModification.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDateModification.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDateModification.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDateModification.UseMnemonic = True
		Me.lblDateModification.Visible = True
		Me.lblDateModification.AutoSize = False
		Me.lblDateModification.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDateModification.Name = "lblDateModification"
		Me.lblDateCreation.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblDateCreation.BackColor = System.Drawing.Color.White
		Me.lblDateCreation.Text = "2004-09-14"
		Me.lblDateCreation.Size = New System.Drawing.Size(65, 19)
		Me.lblDateCreation.Location = New System.Drawing.Point(96, 400)
		Me.lblDateCreation.TabIndex = 32
		Me.lblDateCreation.Enabled = True
		Me.lblDateCreation.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDateCreation.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDateCreation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDateCreation.UseMnemonic = True
		Me.lblDateCreation.Visible = True
		Me.lblDateCreation.AutoSize = False
		Me.lblDateCreation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblDateCreation.Name = "lblDateCreation"
		Me._Label12_3.Text = "Modification :"
		Me._Label12_3.ForeColor = System.Drawing.Color.White
		Me._Label12_3.Size = New System.Drawing.Size(81, 17)
		Me._Label12_3.Location = New System.Drawing.Point(8, 432)
		Me._Label12_3.TabIndex = 66
		Me._Label12_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label12_3.BackColor = System.Drawing.Color.Transparent
		Me._Label12_3.Enabled = True
		Me._Label12_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label12_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label12_3.UseMnemonic = True
		Me._Label12_3.Visible = True
		Me._Label12_3.AutoSize = False
		Me._Label12_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label12_3.Name = "_Label12_3"
		Me._Label12_2.Text = "Création :"
		Me._Label12_2.ForeColor = System.Drawing.Color.White
		Me._Label12_2.Size = New System.Drawing.Size(73, 17)
		Me._Label12_2.Location = New System.Drawing.Point(8, 404)
		Me._Label12_2.TabIndex = 34
		Me._Label12_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label12_2.BackColor = System.Drawing.Color.Transparent
		Me._Label12_2.Enabled = True
		Me._Label12_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label12_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label12_2.UseMnemonic = True
		Me._Label12_2.Visible = True
		Me._Label12_2.AutoSize = False
		Me._Label12_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label12_2.Name = "_Label12_2"
		Me.Label4.Text = "Fax"
		Me.Label4.ForeColor = System.Drawing.Color.White
		Me.Label4.Size = New System.Drawing.Size(73, 17)
		Me.Label4.Location = New System.Drawing.Point(8, 176)
		Me.Label4.TabIndex = 13
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
		Me._Label12_1.Text = "Site web"
		Me._Label12_1.ForeColor = System.Drawing.Color.White
		Me._Label12_1.Size = New System.Drawing.Size(73, 17)
		Me._Label12_1.Location = New System.Drawing.Point(8, 376)
		Me._Label12_1.TabIndex = 31
		Me._Label12_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label12_1.BackColor = System.Drawing.Color.Transparent
		Me._Label12_1.Enabled = True
		Me._Label12_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label12_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label12_1.UseMnemonic = True
		Me._Label12_1.Visible = True
		Me._Label12_1.AutoSize = False
		Me._Label12_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label12_1.Name = "_Label12_1"
		Me.Label16.Text = "Commentaires"
		Me.Label16.ForeColor = System.Drawing.Color.White
		Me.Label16.Size = New System.Drawing.Size(81, 17)
		Me.Label16.Location = New System.Drawing.Point(432, 88)
		Me.Label16.TabIndex = 5
		Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label16.BackColor = System.Drawing.Color.Transparent
		Me.Label16.Enabled = True
		Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label16.UseMnemonic = True
		Me.Label16.Visible = True
		Me.Label16.AutoSize = False
		Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label16.Name = "Label16"
		Me.lblRechercher.Text = "Rechercher"
		Me.lblRechercher.ForeColor = System.Drawing.Color.White
		Me.lblRechercher.Size = New System.Drawing.Size(129, 25)
		Me.lblRechercher.Location = New System.Drawing.Point(352, 16)
		Me.lblRechercher.TabIndex = 0
		Me.lblRechercher.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblRechercher.BackColor = System.Drawing.Color.Transparent
		Me.lblRechercher.Enabled = True
		Me.lblRechercher.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblRechercher.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblRechercher.UseMnemonic = True
		Me.lblRechercher.Visible = True
		Me.lblRechercher.AutoSize = False
		Me.lblRechercher.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblRechercher.Name = "lblRechercher"
		Me._Label12_0.Text = "E-mail"
		Me._Label12_0.ForeColor = System.Drawing.Color.White
		Me._Label12_0.Size = New System.Drawing.Size(73, 17)
		Me._Label12_0.Location = New System.Drawing.Point(8, 204)
		Me._Label12_0.TabIndex = 18
		Me._Label12_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label12_0.BackColor = System.Drawing.Color.Transparent
		Me._Label12_0.Enabled = True
		Me._Label12_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label12_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label12_0.UseMnemonic = True
		Me._Label12_0.Visible = True
		Me._Label12_0.AutoSize = False
		Me._Label12_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label12_0.Name = "_Label12_0"
		Me.Label10.Text = "Telephone"
		Me.Label10.ForeColor = System.Drawing.Color.White
		Me.Label10.Size = New System.Drawing.Size(73, 17)
		Me.Label10.Location = New System.Drawing.Point(8, 148)
		Me.Label10.TabIndex = 10
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label10.BackColor = System.Drawing.Color.Transparent
		Me.Label10.Enabled = True
		Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label10.UseMnemonic = True
		Me.Label10.Visible = True
		Me.Label10.AutoSize = False
		Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label10.Name = "Label10"
		Me.Label9.Text = "CodePostal"
		Me.Label9.ForeColor = System.Drawing.Color.White
		Me.Label9.Size = New System.Drawing.Size(73, 17)
		Me.Label9.Location = New System.Drawing.Point(8, 344)
		Me.Label9.TabIndex = 28
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label9.BackColor = System.Drawing.Color.Transparent
		Me.Label9.Enabled = True
		Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label9.UseMnemonic = True
		Me.Label9.Visible = True
		Me.Label9.AutoSize = False
		Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label9.Name = "Label9"
		Me.Label8.Text = "Pays"
		Me.Label8.ForeColor = System.Drawing.Color.White
		Me.Label8.Size = New System.Drawing.Size(49, 17)
		Me.Label8.Location = New System.Drawing.Point(8, 316)
		Me.Label8.TabIndex = 26
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label8.BackColor = System.Drawing.Color.Transparent
		Me.Label8.Enabled = True
		Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label8.UseMnemonic = True
		Me.Label8.Visible = True
		Me.Label8.AutoSize = False
		Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label8.Name = "Label8"
		Me.Label7.Text = "Prov/Etat"
		Me.Label7.ForeColor = System.Drawing.Color.White
		Me.Label7.Size = New System.Drawing.Size(73, 17)
		Me.Label7.Location = New System.Drawing.Point(8, 288)
		Me.Label7.TabIndex = 24
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label7.BackColor = System.Drawing.Color.Transparent
		Me.Label7.Enabled = True
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = False
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Label6.Text = "Ville"
		Me.Label6.ForeColor = System.Drawing.Color.White
		Me.Label6.Size = New System.Drawing.Size(41, 17)
		Me.Label6.Location = New System.Drawing.Point(8, 260)
		Me.Label6.TabIndex = 22
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
		Me.Label5.Text = "Adresse"
		Me.Label5.ForeColor = System.Drawing.Color.White
		Me.Label5.Size = New System.Drawing.Size(57, 17)
		Me.Label5.Location = New System.Drawing.Point(8, 232)
		Me.Label5.TabIndex = 20
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
		Me._Label1_0.Text = "Fournisseur"
		Me._Label1_0.ForeColor = System.Drawing.Color.White
		Me._Label1_0.Size = New System.Drawing.Size(105, 17)
		Me._Label1_0.Location = New System.Drawing.Point(8, 96)
		Me._Label1_0.TabIndex = 8
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
		Me.Shape1.BackColor = System.Drawing.Color.FromARGB(0, 0, 128)
		Me.Shape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
		Me.Shape1.Size = New System.Drawing.Size(145, 73)
		Me.Shape1.Location = New System.Drawing.Point(328, 8)
		Me.Shape1.CornerRadius = 9
		Me.Shape1.BorderColor = System.Drawing.SystemColors.WindowText
		Me.Shape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Shape1.BorderWidth = 1
		Me.Shape1.FillColor = System.Drawing.Color.Black
		Me.Shape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me.Shape1.Visible = True
		Me.Shape1.Name = "Shape1"
		Me.Controls.Add(frm_Categorie)
		Me.Controls.Add(cmb_modCat)
		Me.Controls.Add(cmbcatégorie)
		Me.Controls.Add(cmdMailListFournisseur)
		Me.Controls.Add(fraEtatOutlook)
		Me.Controls.Add(cmdFax)
		Me.Controls.Add(txtFax)
		Me.Controls.Add(fraContact)
		Me.Controls.Add(cmdRechercher)
		Me.Controls.Add(cmdRafraichir)
		Me.Controls.Add(cmdreport)
		Me.Controls.Add(txtSiteWeb)
		Me.Controls.Add(cmdrenommer)
		Me.Controls.Add(txtCommentaire)
		Me.Controls.Add(txtRechercher)
		Me.Controls.Add(CmdModif)
		Me.Controls.Add(txtEmail)
		Me.Controls.Add(txtTelephone)
		Me.Controls.Add(txtCP)
		Me.Controls.Add(txtPays)
		Me.Controls.Add(txtProvEtat)
		Me.Controls.Add(txtVille)
		Me.Controls.Add(txtAdresse)
		Me.Controls.Add(CmdFerme)
		Me.Controls.Add(CmdSupp)
		Me.Controls.Add(CmdAdd)
		Me.Controls.Add(mskTelephone)
		Me.Controls.Add(CmdEnr)
		Me.Controls.Add(CmdAnul)
		Me.Controls.Add(txtNomFournisseur)
		Me.Controls.Add(cmbFournisseur)
		Me.Controls.Add(mskFax)
		Me.Controls.Add(Label3)
		Me.Controls.Add(lblUserModification)
		Me.Controls.Add(lblUserCreation)
		Me.Controls.Add(lblDateModification)
		Me.Controls.Add(lblDateCreation)
		Me.Controls.Add(_Label12_3)
		Me.Controls.Add(_Label12_2)
		Me.Controls.Add(Label4)
		Me.Controls.Add(_Label12_1)
		Me.Controls.Add(Label16)
		Me.Controls.Add(lblRechercher)
		Me.Controls.Add(_Label12_0)
		Me.Controls.Add(Label10)
		Me.Controls.Add(Label9)
		Me.Controls.Add(Label8)
		Me.Controls.Add(Label7)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label5)
		Me.Controls.Add(_Label1_0)
		Me.ShapeContainer1.Shapes.Add(Shape1)
		Me.Controls.Add(ShapeContainer1)
		Me.frm_Categorie.Controls.Add(cmdcatmod)
		Me.frm_Categorie.Controls.Add(cmb_modAnu)
		Me.frm_Categorie.Controls.Add(cmdCatAdd)
		Me.frm_Categorie.Controls.Add(cmdcatval)
		Me.frm_Categorie.Controls.Add(FrmCatMod)
		Me.frm_Categorie.Controls.Add(cmdAnnuller)
		Me.frm_Categorie.Controls.Add(cmdcatenr)
		Me.frm_Categorie.Controls.Add(Lst_Cat)
		Me.FrmCatMod.Controls.Add(txtmodcat)
		Me.Lst_Cat.Columns.Add(_Lst_Cat_ColumnHeader_1)
		Me.fraEtatOutlook.Controls.Add(lblEtatOutlook)
		Me.fraContact.Controls.Add(cmdMailListContact)
		Me.fraContact.Controls.Add(txtContactTitre)
		Me.fraContact.Controls.Add(txtContactPage)
		Me.fraContact.Controls.Add(txtContactEmail)
		Me.fraContact.Controls.Add(txtContactPoste)
		Me.fraContact.Controls.Add(txtContactTel)
		Me.fraContact.Controls.Add(cmbcontact)
		Me.fraContact.Controls.Add(txtContactFax)
		Me.fraContact.Controls.Add(txtContactCell)
		Me.fraContact.Controls.Add(cmdsupcontact)
		Me.fraContact.Controls.Add(txtContactDom)
		Me.fraContact.Controls.Add(CmdAddCont)
		Me.fraContact.Controls.Add(cmdEnregistrerContact)
		Me.fraContact.Controls.Add(cmdAnnulerContact)
		Me.fraContact.Controls.Add(mskContactPage)
		Me.fraContact.Controls.Add(mskContactFax)
		Me.fraContact.Controls.Add(mskContactCell)
		Me.fraContact.Controls.Add(mskContactDom)
		Me.fraContact.Controls.Add(mskContactTel)
		Me.fraContact.Controls.Add(txtContact)
		Me.fraContact.Controls.Add(_Label1_8)
		Me.fraContact.Controls.Add(Label2)
		Me.fraContact.Controls.Add(_Label1_7)
		Me.fraContact.Controls.Add(_Label1_5)
		Me.fraContact.Controls.Add(_Label1_4)
		Me.fraContact.Controls.Add(_Label1_3)
		Me.fraContact.Controls.Add(_Label1_2)
		Me.fraContact.Controls.Add(_Label1_1)
		Me.fraContact.Controls.Add(_Label1_6)
		Me.Label1.SetIndex(_Label1_8, CType(8, Short))
		Me.Label1.SetIndex(_Label1_7, CType(7, Short))
		Me.Label1.SetIndex(_Label1_5, CType(5, Short))
		Me.Label1.SetIndex(_Label1_4, CType(4, Short))
		Me.Label1.SetIndex(_Label1_3, CType(3, Short))
		Me.Label1.SetIndex(_Label1_2, CType(2, Short))
		Me.Label1.SetIndex(_Label1_1, CType(1, Short))
		Me.Label1.SetIndex(_Label1_6, CType(6, Short))
		Me.Label1.SetIndex(_Label1_0, CType(0, Short))
		Me.Label12.SetIndex(_Label12_3, CType(3, Short))
		Me.Label12.SetIndex(_Label12_2, CType(2, Short))
		Me.Label12.SetIndex(_Label12_1, CType(1, Short))
		Me.Label12.SetIndex(_Label12_0, CType(0, Short))
		CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.frm_Categorie.ResumeLayout(False)
		Me.FrmCatMod.ResumeLayout(False)
		Me.Lst_Cat.ResumeLayout(False)
		Me.fraEtatOutlook.ResumeLayout(False)
		Me.fraContact.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class