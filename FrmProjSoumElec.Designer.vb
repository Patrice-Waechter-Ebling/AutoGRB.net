<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FrmProjSoumElec
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
	Public WithEvents mnuFacturer As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuNC As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuDateRequise As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuCommentaire As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuID As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuMauvaisPrix As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuInutile As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuTexte As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuChangerSS As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuFournisseur As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuAnnulerCommande As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuSupprimer As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuAjouterPrix As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuSortieMagasin As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuQuantite As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuRightClick As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	Public WithEvents cmbOuvertFerme As System.Windows.Forms.ComboBox
	Public dlgExcelOpen As System.Windows.Forms.OpenFileDialog
	Public dlgExcelSave As System.Windows.Forms.SaveFileDialog
	Public dlgExcelFont As System.Windows.Forms.FontDialog
	Public dlgExcelColor As System.Windows.Forms.ColorDialog
	Public dlgExcelPrint As System.Windows.Forms.PrintDialog
	Public WithEvents cmdOKFRS As System.Windows.Forms.Button
	Public WithEvents cmdAnnulerFRS As System.Windows.Forms.Button
	Public WithEvents cmdSupprimerFRS As System.Windows.Forms.Button
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
	Public WithEvents _lvwFournisseur_ColumnHeader_11 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwFournisseur As System.Windows.Forms.ListView
	Public WithEvents fraFournisseur As System.Windows.Forms.GroupBox
	Public WithEvents cmdAnnulerPieceTrouve As System.Windows.Forms.Button
	Public WithEvents cmdOKPieceTrouve As System.Windows.Forms.Button
	Public WithEvents _lvwPieceTrouve_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieceTrouve_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieceTrouve_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieceTrouve_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieceTrouve_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieceTrouve_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwPieceTrouve As System.Windows.Forms.ListView
	Public WithEvents fraPieceTrouve As System.Windows.Forms.GroupBox
	Public WithEvents _lvwHistorique_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwHistorique_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwHistorique_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwHistorique_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwHistorique As System.Windows.Forms.ListView
	Public WithEvents _lvwBavard_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwBavard_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwBavard_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwBavard_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwBavard_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwBavard As System.Windows.Forms.ListView
	Public WithEvents mvwDateFacturation As AxMSComCtl2.AxMonthView
	Public WithEvents mvwDate As AxMSComCtl2.AxMonthView
	Public WithEvents cmdAnnulerDateRequise As System.Windows.Forms.Button
	Public WithEvents cmdOKDateRequise As System.Windows.Forms.Button
	Public WithEvents mvwDateRequise As AxMSComCtl2.AxMonthView
	Public WithEvents fraDateRequise As System.Windows.Forms.GroupBox
	Public WithEvents txtCommentaire As System.Windows.Forms.TextBox
	Public WithEvents cmdOKCommentaire As System.Windows.Forms.Button
	Public WithEvents cmdAnnulerCommentaire As System.Windows.Forms.Button
	Public WithEvents fraCommentaire As System.Windows.Forms.GroupBox
	Public WithEvents txtPrixSpecial As System.Windows.Forms.TextBox
	Public WithEvents txtPrixList As System.Windows.Forms.TextBox
	Public WithEvents txtPrixNet As System.Windows.Forms.TextBox
	Public WithEvents cmbfrs As System.Windows.Forms.ComboBox
	Public WithEvents optUSA As System.Windows.Forms.RadioButton
	Public WithEvents optCAN As System.Windows.Forms.RadioButton
	Public WithEvents optSpain As System.Windows.Forms.RadioButton
	Public WithEvents cmdOKPrix As System.Windows.Forms.Button
	Public WithEvents cmdAnnulerPrix As System.Windows.Forms.Button
	Public WithEvents mskEscompte As System.Windows.Forms.MaskedTextBox
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents imgCanada As System.Windows.Forms.PictureBox
	Public WithEvents _Label1_14 As System.Windows.Forms.Label
	Public WithEvents _Label1_16 As System.Windows.Forms.Label
	Public WithEvents _Label1_19 As System.Windows.Forms.Label
	Public WithEvents _Label1_20 As System.Windows.Forms.Label
	Public WithEvents imgSpain As System.Windows.Forms.PictureBox
	Public WithEvents imgEU As System.Windows.Forms.PictureBox
	Public WithEvents fraPrixPiece As System.Windows.Forms.GroupBox
	Public WithEvents cmdAnglaisFrancais As System.Windows.Forms.Button
	Public WithEvents cmdReset As System.Windows.Forms.Button
	Public WithEvents cmdRapportFACT As System.Windows.Forms.Button
	Public WithEvents cmdTexte As System.Windows.Forms.Button
	Public WithEvents cmdDemande As System.Windows.Forms.Button
	Public WithEvents cmdSortieMagasin As System.Windows.Forms.Button
	Public WithEvents cmdMauvaisPrix As System.Windows.Forms.Button
	Public WithEvents cmdMaterielInutile As System.Windows.Forms.Button
	Public WithEvents cmdCreerProjet As System.Windows.Forms.Button
	Public WithEvents cmdCatalogue As System.Windows.Forms.Button
	Public WithEvents cmdBonCommande As System.Windows.Forms.Button
	Public WithEvents cmdRetour As System.Windows.Forms.Button
	Public WithEvents cmdExtra As System.Windows.Forms.Button
	Public WithEvents cmdCopier As System.Windows.Forms.Button
	Public WithEvents cmdImprimer As System.Windows.Forms.Button
	Public WithEvents cmdAjouter As System.Windows.Forms.Button
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents cmdEnregistrer As System.Windows.Forms.Button
	Public WithEvents cmdModifier As System.Windows.Forms.Button
	Public WithEvents cmdSupprimer As System.Windows.Forms.Button
	Public WithEvents chkUR As System.Windows.Forms.CheckBox
	Public WithEvents chkCE As System.Windows.Forms.CheckBox
	Public WithEvents chkCUR As System.Windows.Forms.CheckBox
	Public WithEvents chkUL As System.Windows.Forms.CheckBox
	Public WithEvents chkCUL As System.Windows.Forms.CheckBox
	Public WithEvents chkCSA As System.Windows.Forms.CheckBox
	Public WithEvents picApprob As System.Windows.Forms.Panel
	Public WithEvents txtDelais As System.Windows.Forms.TextBox
	Public WithEvents cmdDate As System.Windows.Forms.Button
	Public WithEvents Label21 As System.Windows.Forms.Label
	Public WithEvents fraCertifDelais As System.Windows.Forms.Panel
	Public WithEvents txtPrixSoumission As System.Windows.Forms.TextBox
	Public WithEvents cmbTransport As System.Windows.Forms.ComboBox
	Public WithEvents txtTransport As System.Windows.Forms.TextBox
	Public WithEvents txtPrixReception As System.Windows.Forms.TextBox
	Public WithEvents lblPrixSoumission As System.Windows.Forms.Label
	Public WithEvents lblPrixReception As System.Windows.Forms.Label
	Public WithEvents Label26 As System.Windows.Forms.Label
	Public WithEvents fraFsTransMarq As System.Windows.Forms.Panel
	Public WithEvents cmdRafraichir As System.Windows.Forms.Button
	Public WithEvents cmdTri As System.Windows.Forms.Button
	Public WithEvents txtTotalTemps As System.Windows.Forms.TextBox
	Public WithEvents txtTotalPieces As System.Windows.Forms.TextBox
	Public WithEvents txtProfit As System.Windows.Forms.TextBox
	Public WithEvents txtImprevus As System.Windows.Forms.TextBox
	Public WithEvents txtCommission As System.Windows.Forms.TextBox
	Public WithEvents txtPrixTotal As System.Windows.Forms.TextBox
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents lblTotalPieces As System.Windows.Forms.Label
	Public WithEvents lblImprevus As System.Windows.Forms.Label
	Public WithEvents lblTotalTemps As System.Windows.Forms.Label
	Public WithEvents fraPrix As System.Windows.Forms.Panel
	Public WithEvents cmbTri As System.Windows.Forms.ComboBox
	Public WithEvents cmbPieces As System.Windows.Forms.ComboBox
	Public WithEvents txtCheminPhotos As System.Windows.Forms.TextBox
	Public WithEvents cmdBrowse As System.Windows.Forms.Button
	Public WithEvents cmdPhotos As System.Windows.Forms.Button
	Public WithEvents txtProjet As System.Windows.Forms.TextBox
	Public WithEvents cmbContact As System.Windows.Forms.ComboBox
	Public WithEvents txtContact As System.Windows.Forms.TextBox
	Public WithEvents cmbClient As System.Windows.Forms.ComboBox
	Public WithEvents txtClient As System.Windows.Forms.TextBox
	Public WithEvents txtNoSoumission As System.Windows.Forms.TextBox
	Public WithEvents cmbProjSoum As System.Windows.Forms.ComboBox
	Public WithEvents txtNoProjSoum As System.Windows.Forms.TextBox
	Public WithEvents cmbChoix As System.Windows.Forms.ComboBox
	Public WithEvents txtChoix As System.Windows.Forms.TextBox
	Public WithEvents tmrTemps As System.Windows.Forms.Timer
	Public WithEvents cmdHistorique As System.Windows.Forms.Button
	Public WithEvents cmdLegende As System.Windows.Forms.Button
	Public WithEvents cmdBavards As System.Windows.Forms.Button
	Public WithEvents cmdAjouterSection As System.Windows.Forms.Button
	Public WithEvents cmbSections As System.Windows.Forms.ComboBox
	Public WithEvents cmdDateFacturation As System.Windows.Forms.Button
	Public WithEvents txtDateFacturation As System.Windows.Forms.TextBox
	Public WithEvents cmdTemps As System.Windows.Forms.Button
	Public WithEvents txtForfait As System.Windows.Forms.TextBox
	Public WithEvents cmdForfait As System.Windows.Forms.Button
	Public WithEvents cmdEffacerForfait As System.Windows.Forms.Button
	Public WithEvents _lvwPieces_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPieces_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwPieces As System.Windows.Forms.ListView
	Public WithEvents lvwSoumission As System.Windows.Forms.ListView
	Public WithEvents cmdExport As System.Windows.Forms.Button
	Public WithEvents cmdReception As System.Windows.Forms.Button
	Public WithEvents cmdRechercherClient As System.Windows.Forms.Button
	Public WithEvents txtNbreManuel As System.Windows.Forms.TextBox
	Public WithEvents txtPrixManuel As System.Windows.Forms.TextBox
	Public WithEvents Label23 As System.Windows.Forms.Label
	Public WithEvents Label22 As System.Windows.Forms.Label
	Public WithEvents fraManuel As System.Windows.Forms.GroupBox
	Public WithEvents lblForfaitInitiale As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents lblDateFacturation As System.Windows.Forms.Label
	Public WithEvents lblPasTemps As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents lblNoSoumission As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents lblSections As System.Windows.Forms.Label
	Public WithEvents lblPiece As System.Windows.Forms.Label
	Public WithEvents lblProjet As System.Windows.Forms.Label
	Public WithEvents lblTri As System.Windows.Forms.Label
	Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmProjSoumElec))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.MainMenu1 = New System.Windows.Forms.MenuStrip
		Me.mnuRightClick = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFacturer = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuNC = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuDateRequise = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuCommentaire = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuID = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuMauvaisPrix = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuInutile = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuTexte = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuChangerSS = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuFournisseur = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuAnnulerCommande = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSupprimer = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuAjouterPrix = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuSortieMagasin = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuQuantite = New System.Windows.Forms.ToolStripMenuItem
		Me.cmbOuvertFerme = New System.Windows.Forms.ComboBox
		Me.dlgExcelOpen = New System.Windows.Forms.OpenFileDialog
		Me.dlgExcelSave = New System.Windows.Forms.SaveFileDialog
		Me.dlgExcelFont = New System.Windows.Forms.FontDialog
		Me.dlgExcelColor = New System.Windows.Forms.ColorDialog
		Me.dlgExcelPrint = New System.Windows.Forms.PrintDialog
		Me.fraFournisseur = New System.Windows.Forms.GroupBox
		Me.cmdOKFRS = New System.Windows.Forms.Button
		Me.cmdAnnulerFRS = New System.Windows.Forms.Button
		Me.cmdSupprimerFRS = New System.Windows.Forms.Button
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
		Me._lvwFournisseur_ColumnHeader_11 = New System.Windows.Forms.ColumnHeader
		Me.fraPieceTrouve = New System.Windows.Forms.GroupBox
		Me.cmdAnnulerPieceTrouve = New System.Windows.Forms.Button
		Me.cmdOKPieceTrouve = New System.Windows.Forms.Button
		Me.lvwPieceTrouve = New System.Windows.Forms.ListView
		Me._lvwPieceTrouve_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieceTrouve_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieceTrouve_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieceTrouve_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieceTrouve_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieceTrouve_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me.lvwHistorique = New System.Windows.Forms.ListView
		Me._lvwHistorique_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwHistorique_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwHistorique_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwHistorique_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me.lvwBavard = New System.Windows.Forms.ListView
		Me._lvwBavard_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwBavard_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwBavard_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwBavard_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwBavard_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me.mvwDateFacturation = New AxMSComCtl2.AxMonthView
		Me.mvwDate = New AxMSComCtl2.AxMonthView
		Me.fraDateRequise = New System.Windows.Forms.GroupBox
		Me.cmdAnnulerDateRequise = New System.Windows.Forms.Button
		Me.cmdOKDateRequise = New System.Windows.Forms.Button
		Me.mvwDateRequise = New AxMSComCtl2.AxMonthView
		Me.fraCommentaire = New System.Windows.Forms.GroupBox
		Me.txtCommentaire = New System.Windows.Forms.TextBox
		Me.cmdOKCommentaire = New System.Windows.Forms.Button
		Me.cmdAnnulerCommentaire = New System.Windows.Forms.Button
		Me.fraPrixPiece = New System.Windows.Forms.GroupBox
		Me.txtPrixSpecial = New System.Windows.Forms.TextBox
		Me.txtPrixList = New System.Windows.Forms.TextBox
		Me.txtPrixNet = New System.Windows.Forms.TextBox
		Me.cmbfrs = New System.Windows.Forms.ComboBox
		Me.optUSA = New System.Windows.Forms.RadioButton
		Me.optCAN = New System.Windows.Forms.RadioButton
		Me.optSpain = New System.Windows.Forms.RadioButton
		Me.cmdOKPrix = New System.Windows.Forms.Button
		Me.cmdAnnulerPrix = New System.Windows.Forms.Button
		Me.mskEscompte = New System.Windows.Forms.MaskedTextBox
		Me._Label1_0 = New System.Windows.Forms.Label
		Me.imgCanada = New System.Windows.Forms.PictureBox
		Me._Label1_14 = New System.Windows.Forms.Label
		Me._Label1_16 = New System.Windows.Forms.Label
		Me._Label1_19 = New System.Windows.Forms.Label
		Me._Label1_20 = New System.Windows.Forms.Label
		Me.imgSpain = New System.Windows.Forms.PictureBox
		Me.imgEU = New System.Windows.Forms.PictureBox
		Me.cmdAnglaisFrancais = New System.Windows.Forms.Button
		Me.cmdReset = New System.Windows.Forms.Button
		Me.cmdRapportFACT = New System.Windows.Forms.Button
		Me.cmdTexte = New System.Windows.Forms.Button
		Me.cmdDemande = New System.Windows.Forms.Button
		Me.cmdSortieMagasin = New System.Windows.Forms.Button
		Me.cmdMauvaisPrix = New System.Windows.Forms.Button
		Me.cmdMaterielInutile = New System.Windows.Forms.Button
		Me.cmdCreerProjet = New System.Windows.Forms.Button
		Me.cmdCatalogue = New System.Windows.Forms.Button
		Me.cmdBonCommande = New System.Windows.Forms.Button
		Me.cmdRetour = New System.Windows.Forms.Button
		Me.cmdExtra = New System.Windows.Forms.Button
		Me.cmdCopier = New System.Windows.Forms.Button
		Me.cmdImprimer = New System.Windows.Forms.Button
		Me.cmdAjouter = New System.Windows.Forms.Button
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.cmdEnregistrer = New System.Windows.Forms.Button
		Me.cmdModifier = New System.Windows.Forms.Button
		Me.cmdSupprimer = New System.Windows.Forms.Button
		Me.fraCertifDelais = New System.Windows.Forms.Panel
		Me.picApprob = New System.Windows.Forms.Panel
		Me.chkUR = New System.Windows.Forms.CheckBox
		Me.chkCE = New System.Windows.Forms.CheckBox
		Me.chkCUR = New System.Windows.Forms.CheckBox
		Me.chkUL = New System.Windows.Forms.CheckBox
		Me.chkCUL = New System.Windows.Forms.CheckBox
		Me.chkCSA = New System.Windows.Forms.CheckBox
		Me.txtDelais = New System.Windows.Forms.TextBox
		Me.cmdDate = New System.Windows.Forms.Button
		Me.Label21 = New System.Windows.Forms.Label
		Me.fraFsTransMarq = New System.Windows.Forms.Panel
		Me.txtPrixSoumission = New System.Windows.Forms.TextBox
		Me.cmbTransport = New System.Windows.Forms.ComboBox
		Me.txtTransport = New System.Windows.Forms.TextBox
		Me.txtPrixReception = New System.Windows.Forms.TextBox
		Me.lblPrixSoumission = New System.Windows.Forms.Label
		Me.lblPrixReception = New System.Windows.Forms.Label
		Me.Label26 = New System.Windows.Forms.Label
		Me.cmdRafraichir = New System.Windows.Forms.Button
		Me.cmdTri = New System.Windows.Forms.Button
		Me.fraPrix = New System.Windows.Forms.Panel
		Me.txtTotalTemps = New System.Windows.Forms.TextBox
		Me.txtTotalPieces = New System.Windows.Forms.TextBox
		Me.txtProfit = New System.Windows.Forms.TextBox
		Me.txtImprevus = New System.Windows.Forms.TextBox
		Me.txtCommission = New System.Windows.Forms.TextBox
		Me.txtPrixTotal = New System.Windows.Forms.TextBox
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.lblTotalPieces = New System.Windows.Forms.Label
		Me.lblImprevus = New System.Windows.Forms.Label
		Me.lblTotalTemps = New System.Windows.Forms.Label
		Me.cmbTri = New System.Windows.Forms.ComboBox
		Me.cmbPieces = New System.Windows.Forms.ComboBox
		Me.txtCheminPhotos = New System.Windows.Forms.TextBox
		Me.cmdBrowse = New System.Windows.Forms.Button
		Me.cmdPhotos = New System.Windows.Forms.Button
		Me.txtProjet = New System.Windows.Forms.TextBox
		Me.cmbContact = New System.Windows.Forms.ComboBox
		Me.txtContact = New System.Windows.Forms.TextBox
		Me.cmbClient = New System.Windows.Forms.ComboBox
		Me.txtClient = New System.Windows.Forms.TextBox
		Me.txtNoSoumission = New System.Windows.Forms.TextBox
		Me.cmbProjSoum = New System.Windows.Forms.ComboBox
		Me.txtNoProjSoum = New System.Windows.Forms.TextBox
		Me.cmbChoix = New System.Windows.Forms.ComboBox
		Me.txtChoix = New System.Windows.Forms.TextBox
		Me.tmrTemps = New System.Windows.Forms.Timer(components)
		Me.cmdHistorique = New System.Windows.Forms.Button
		Me.cmdLegende = New System.Windows.Forms.Button
		Me.cmdBavards = New System.Windows.Forms.Button
		Me.cmdAjouterSection = New System.Windows.Forms.Button
		Me.cmbSections = New System.Windows.Forms.ComboBox
		Me.cmdDateFacturation = New System.Windows.Forms.Button
		Me.txtDateFacturation = New System.Windows.Forms.TextBox
		Me.cmdTemps = New System.Windows.Forms.Button
		Me.txtForfait = New System.Windows.Forms.TextBox
		Me.cmdForfait = New System.Windows.Forms.Button
		Me.cmdEffacerForfait = New System.Windows.Forms.Button
		Me.lvwPieces = New System.Windows.Forms.ListView
		Me._lvwPieces_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwPieces_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me.lvwSoumission = New System.Windows.Forms.ListView
		Me.cmdExport = New System.Windows.Forms.Button
		Me.cmdReception = New System.Windows.Forms.Button
		Me.cmdRechercherClient = New System.Windows.Forms.Button
		Me.fraManuel = New System.Windows.Forms.GroupBox
		Me.txtNbreManuel = New System.Windows.Forms.TextBox
		Me.txtPrixManuel = New System.Windows.Forms.TextBox
		Me.Label23 = New System.Windows.Forms.Label
		Me.Label22 = New System.Windows.Forms.Label
		Me.lblForfaitInitiale = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.lblDateFacturation = New System.Windows.Forms.Label
		Me.lblPasTemps = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.lblNoSoumission = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.lblSections = New System.Windows.Forms.Label
		Me.lblPiece = New System.Windows.Forms.Label
		Me.lblProjet = New System.Windows.Forms.Label
		Me.lblTri = New System.Windows.Forms.Label
		Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.MainMenu1.SuspendLayout()
		Me.fraFournisseur.SuspendLayout()
		Me.lvwFournisseur.SuspendLayout()
		Me.fraPieceTrouve.SuspendLayout()
		Me.lvwPieceTrouve.SuspendLayout()
		Me.lvwHistorique.SuspendLayout()
		Me.lvwBavard.SuspendLayout()
		Me.fraDateRequise.SuspendLayout()
		Me.fraCommentaire.SuspendLayout()
		Me.fraPrixPiece.SuspendLayout()
		Me.fraCertifDelais.SuspendLayout()
		Me.picApprob.SuspendLayout()
		Me.fraFsTransMarq.SuspendLayout()
		Me.fraPrix.SuspendLayout()
		Me.lvwPieces.SuspendLayout()
		Me.fraManuel.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.mvwDateFacturation, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.mvwDateRequise, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.Text = "Projets / Soumissions Électriques"
		Me.ClientSize = New System.Drawing.Size(892, 575)
		Me.Location = New System.Drawing.Point(15, 43)
		Me.Icon = CType(resources.GetObject("FrmProjSoumElec.Icon"), System.Drawing.Icon)
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("FrmProjSoumElec.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.Name = "FrmProjSoumElec"
		Me.mnuRightClick.Name = "mnuRightClick"
		Me.mnuRightClick.Text = ""
		Me.mnuRightClick.Visible = False
		Me.mnuRightClick.Checked = False
		Me.mnuRightClick.Enabled = True
		Me.mnuFacturer.Name = "mnuFacturer"
		Me.mnuFacturer.Text = "Facturer"
		Me.mnuFacturer.Checked = False
		Me.mnuFacturer.Enabled = True
		Me.mnuFacturer.Visible = True
		Me.mnuNC.Name = "mnuNC"
		Me.mnuNC.Text = "NC"
		Me.mnuNC.Checked = False
		Me.mnuNC.Enabled = True
		Me.mnuNC.Visible = True
		Me.mnuDateRequise.Name = "mnuDateRequise"
		Me.mnuDateRequise.Text = "Modifier la date requise"
		Me.mnuDateRequise.Checked = False
		Me.mnuDateRequise.Enabled = True
		Me.mnuDateRequise.Visible = True
		Me.mnuCommentaire.Name = "mnuCommentaire"
		Me.mnuCommentaire.Text = "Ajouter / Modifier le commentaire"
		Me.mnuCommentaire.Checked = False
		Me.mnuCommentaire.Enabled = True
		Me.mnuCommentaire.Visible = True
		Me.mnuID.Name = "mnuID"
		Me.mnuID.Text = "Ajouter / Modifier l'ID"
		Me.mnuID.Checked = False
		Me.mnuID.Enabled = True
		Me.mnuID.Visible = True
		Me.mnuMauvaisPrix.Name = "mnuMauvaisPrix"
		Me.mnuMauvaisPrix.Text = "Mauvais prix"
		Me.mnuMauvaisPrix.Checked = False
		Me.mnuMauvaisPrix.Enabled = True
		Me.mnuMauvaisPrix.Visible = True
		Me.mnuInutile.Name = "mnuInutile"
		Me.mnuInutile.Text = "Matériel inutile"
		Me.mnuInutile.Checked = False
		Me.mnuInutile.Enabled = True
		Me.mnuInutile.Visible = True
		Me.mnuTexte.Name = "mnuTexte"
		Me.mnuTexte.Text = "Modifier le texte"
		Me.mnuTexte.Checked = False
		Me.mnuTexte.Enabled = True
		Me.mnuTexte.Visible = True
		Me.mnuChangerSS.Name = "mnuChangerSS"
		Me.mnuChangerSS.Text = "Modifier la sous-section"
		Me.mnuChangerSS.Checked = False
		Me.mnuChangerSS.Enabled = True
		Me.mnuChangerSS.Visible = True
		Me.mnuFournisseur.Name = "mnuFournisseur"
		Me.mnuFournisseur.Text = "Modifier le fournisseur"
		Me.mnuFournisseur.Checked = False
		Me.mnuFournisseur.Enabled = True
		Me.mnuFournisseur.Visible = True
		Me.mnuAnnulerCommande.Name = "mnuAnnulerCommande"
		Me.mnuAnnulerCommande.Text = "Annuler la commande"
		Me.mnuAnnulerCommande.Checked = False
		Me.mnuAnnulerCommande.Enabled = True
		Me.mnuAnnulerCommande.Visible = True
		Me.mnuSupprimer.Name = "mnuSupprimer"
		Me.mnuSupprimer.Text = "Supprimer"
		Me.mnuSupprimer.Checked = False
		Me.mnuSupprimer.Enabled = True
		Me.mnuSupprimer.Visible = True
		Me.mnuAjouterPrix.Name = "mnuAjouterPrix"
		Me.mnuAjouterPrix.Text = "Ajouter le prix"
		Me.mnuAjouterPrix.Checked = False
		Me.mnuAjouterPrix.Enabled = True
		Me.mnuAjouterPrix.Visible = True
		Me.mnuSortieMagasin.Name = "mnuSortieMagasin"
		Me.mnuSortieMagasin.Text = "Sorti du magasin"
		Me.mnuSortieMagasin.Checked = False
		Me.mnuSortieMagasin.Enabled = True
		Me.mnuSortieMagasin.Visible = True
		Me.mnuQuantite.Name = "mnuQuantite"
		Me.mnuQuantite.Text = "Changer la quantité"
		Me.mnuQuantite.Checked = False
		Me.mnuQuantite.Enabled = True
		Me.mnuQuantite.Visible = True
		Me.cmbOuvertFerme.Size = New System.Drawing.Size(81, 21)
		Me.cmbOuvertFerme.Location = New System.Drawing.Point(304, 32)
		Me.cmbOuvertFerme.Items.AddRange(New Object(){"Ouverts", "Fermés"})
		Me.cmbOuvertFerme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbOuvertFerme.TabIndex = 140
		Me.cmbOuvertFerme.BackColor = System.Drawing.SystemColors.Window
		Me.cmbOuvertFerme.CausesValidation = True
		Me.cmbOuvertFerme.Enabled = True
		Me.cmbOuvertFerme.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbOuvertFerme.IntegralHeight = True
		Me.cmbOuvertFerme.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbOuvertFerme.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbOuvertFerme.Sorted = False
		Me.cmbOuvertFerme.TabStop = True
		Me.cmbOuvertFerme.Visible = True
		Me.cmbOuvertFerme.Name = "cmbOuvertFerme"
		Me.fraFournisseur.BackColor = System.Drawing.Color.Black
		Me.fraFournisseur.Text = "Fournisseurs"
		Me.fraFournisseur.ForeColor = System.Drawing.Color.White
		Me.fraFournisseur.Size = New System.Drawing.Size(761, 161)
		Me.fraFournisseur.Location = New System.Drawing.Point(24, 64)
		Me.fraFournisseur.TabIndex = 20
		Me.fraFournisseur.Visible = False
		Me.fraFournisseur.Enabled = True
		Me.fraFournisseur.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraFournisseur.Padding = New System.Windows.Forms.Padding(0)
		Me.fraFournisseur.Name = "fraFournisseur"
		Me.cmdOKFRS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOKFRS.Text = "OK"
		Me.cmdOKFRS.Size = New System.Drawing.Size(73, 25)
		Me.cmdOKFRS.Location = New System.Drawing.Point(680, 128)
		Me.cmdOKFRS.TabIndex = 24
		Me.cmdOKFRS.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOKFRS.CausesValidation = True
		Me.cmdOKFRS.Enabled = True
		Me.cmdOKFRS.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOKFRS.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOKFRS.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOKFRS.TabStop = True
		Me.cmdOKFRS.Name = "cmdOKFRS"
		Me.cmdAnnulerFRS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnulerFRS.Text = "Annuler"
		Me.cmdAnnulerFRS.Size = New System.Drawing.Size(73, 25)
		Me.cmdAnnulerFRS.Location = New System.Drawing.Point(600, 128)
		Me.cmdAnnulerFRS.TabIndex = 23
		Me.cmdAnnulerFRS.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnulerFRS.CausesValidation = True
		Me.cmdAnnulerFRS.Enabled = True
		Me.cmdAnnulerFRS.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnulerFRS.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnulerFRS.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnulerFRS.TabStop = True
		Me.cmdAnnulerFRS.Name = "cmdAnnulerFRS"
		Me.cmdSupprimerFRS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSupprimerFRS.Text = "Supprimer"
		Me.cmdSupprimerFRS.Size = New System.Drawing.Size(65, 25)
		Me.cmdSupprimerFRS.Location = New System.Drawing.Point(8, 128)
		Me.cmdSupprimerFRS.TabIndex = 22
		Me.cmdSupprimerFRS.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSupprimerFRS.CausesValidation = True
		Me.cmdSupprimerFRS.Enabled = True
		Me.cmdSupprimerFRS.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSupprimerFRS.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSupprimerFRS.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSupprimerFRS.TabStop = True
		Me.cmdSupprimerFRS.Name = "cmdSupprimerFRS"
		Me.lvwFournisseur.Size = New System.Drawing.Size(745, 105)
		Me.lvwFournisseur.Location = New System.Drawing.Point(8, 16)
		Me.lvwFournisseur.TabIndex = 21
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
		Me._lvwFournisseur_ColumnHeader_11.Text = "Stock"
		Me._lvwFournisseur_ColumnHeader_11.Width = 100
		Me.fraPieceTrouve.BackColor = System.Drawing.Color.Black
		Me.fraPieceTrouve.Text = "Pièces trouvées"
		Me.fraPieceTrouve.ForeColor = System.Drawing.Color.White
		Me.fraPieceTrouve.Size = New System.Drawing.Size(689, 185)
		Me.fraPieceTrouve.Location = New System.Drawing.Point(24, 64)
		Me.fraPieceTrouve.TabIndex = 15
		Me.fraPieceTrouve.Visible = False
		Me.fraPieceTrouve.Enabled = True
		Me.fraPieceTrouve.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraPieceTrouve.Padding = New System.Windows.Forms.Padding(0)
		Me.fraPieceTrouve.Name = "fraPieceTrouve"
		Me.cmdAnnulerPieceTrouve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnulerPieceTrouve.Text = "Annuler"
		Me.cmdAnnulerPieceTrouve.Size = New System.Drawing.Size(73, 25)
		Me.cmdAnnulerPieceTrouve.Location = New System.Drawing.Point(528, 152)
		Me.cmdAnnulerPieceTrouve.TabIndex = 17
		Me.cmdAnnulerPieceTrouve.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnulerPieceTrouve.CausesValidation = True
		Me.cmdAnnulerPieceTrouve.Enabled = True
		Me.cmdAnnulerPieceTrouve.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnulerPieceTrouve.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnulerPieceTrouve.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnulerPieceTrouve.TabStop = True
		Me.cmdAnnulerPieceTrouve.Name = "cmdAnnulerPieceTrouve"
		Me.cmdOKPieceTrouve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOKPieceTrouve.Text = "OK"
		Me.cmdOKPieceTrouve.Size = New System.Drawing.Size(73, 25)
		Me.cmdOKPieceTrouve.Location = New System.Drawing.Point(608, 152)
		Me.cmdOKPieceTrouve.TabIndex = 18
		Me.cmdOKPieceTrouve.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOKPieceTrouve.CausesValidation = True
		Me.cmdOKPieceTrouve.Enabled = True
		Me.cmdOKPieceTrouve.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOKPieceTrouve.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOKPieceTrouve.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOKPieceTrouve.TabStop = True
		Me.cmdOKPieceTrouve.Name = "cmdOKPieceTrouve"
		Me.lvwPieceTrouve.Size = New System.Drawing.Size(673, 129)
		Me.lvwPieceTrouve.Location = New System.Drawing.Point(8, 16)
		Me.lvwPieceTrouve.TabIndex = 16
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
		Me.lvwHistorique.Size = New System.Drawing.Size(321, 105)
		Me.lvwHistorique.Location = New System.Drawing.Point(8, 112)
		Me.lvwHistorique.TabIndex = 55
		Me.lvwHistorique.Visible = False
		Me.lvwHistorique.View = System.Windows.Forms.View.Details
		Me.lvwHistorique.LabelEdit = False
		Me.lvwHistorique.LabelWrap = True
		Me.lvwHistorique.HideSelection = True
		Me.lvwHistorique.FullRowSelect = True
		Me.lvwHistorique.GridLines = True
		Me.lvwHistorique.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwHistorique.BackColor = System.Drawing.SystemColors.Window
		Me.lvwHistorique.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwHistorique.Name = "lvwHistorique"
		Me._lvwHistorique_ColumnHeader_1.Text = "Nom de l'employé"
		Me._lvwHistorique_ColumnHeader_1.Width = 214
		Me._lvwHistorique_ColumnHeader_2.Text = "Date"
		Me._lvwHistorique_ColumnHeader_2.Width = 117
		Me._lvwHistorique_ColumnHeader_3.Text = "Heure"
		Me._lvwHistorique_ColumnHeader_3.Width = 129
		Me._lvwHistorique_ColumnHeader_4.Width = 170
		Me.lvwBavard.Size = New System.Drawing.Size(321, 105)
		Me.lvwBavard.Location = New System.Drawing.Point(8, 112)
		Me.lvwBavard.TabIndex = 54
		Me.lvwBavard.Visible = False
		Me.lvwBavard.View = System.Windows.Forms.View.Details
		Me.lvwBavard.LabelEdit = False
		Me.lvwBavard.LabelWrap = True
		Me.lvwBavard.HideSelection = True
		Me.lvwBavard.FullRowSelect = True
		Me.lvwBavard.GridLines = True
		Me.lvwBavard.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwBavard.BackColor = System.Drawing.SystemColors.Window
		Me.lvwBavard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwBavard.Name = "lvwBavard"
		Me._lvwBavard_ColumnHeader_1.Text = "Nom de l'employé"
		Me._lvwBavard_ColumnHeader_1.Width = 214
		Me._lvwBavard_ColumnHeader_2.Text = "Date"
		Me._lvwBavard_ColumnHeader_2.Width = 117
		Me._lvwBavard_ColumnHeader_3.Text = "Heure"
		Me._lvwBavard_ColumnHeader_3.Width = 129
		Me._lvwBavard_ColumnHeader_4.Text = "Qté"
		Me._lvwBavard_ColumnHeader_4.Width = 170
		Me._lvwBavard_ColumnHeader_5.Text = "No. Item"
		Me._lvwBavard_ColumnHeader_5.Width = 170
		mvwDateFacturation.OcxState = CType(resources.GetObject("mvwDateFacturation.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwDateFacturation.Size = New System.Drawing.Size(173, 158)
		Me.mvwDateFacturation.Location = New System.Drawing.Point(48, 64)
		Me.mvwDateFacturation.TabIndex = 19
		Me.mvwDateFacturation.Visible = False
		Me.mvwDateFacturation.Name = "mvwDateFacturation"
		mvwDate.OcxState = CType(resources.GetObject("mvwDate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwDate.Size = New System.Drawing.Size(173, 158)
		Me.mvwDate.Location = New System.Drawing.Point(624, 72)
		Me.mvwDate.TabIndex = 41
		Me.mvwDate.Visible = False
		Me.mvwDate.Name = "mvwDate"
		Me.fraDateRequise.BackColor = System.Drawing.Color.Black
		Me.fraDateRequise.Text = "Date Requise"
		Me.fraDateRequise.ForeColor = System.Drawing.Color.White
		Me.fraDateRequise.Size = New System.Drawing.Size(321, 193)
		Me.fraDateRequise.Location = New System.Drawing.Point(240, 328)
		Me.fraDateRequise.TabIndex = 89
		Me.fraDateRequise.Visible = False
		Me.fraDateRequise.Enabled = True
		Me.fraDateRequise.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraDateRequise.Padding = New System.Windows.Forms.Padding(0)
		Me.fraDateRequise.Name = "fraDateRequise"
		Me.cmdAnnulerDateRequise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnulerDateRequise.Text = "Annuler"
		Me.cmdAnnulerDateRequise.Size = New System.Drawing.Size(73, 25)
		Me.cmdAnnulerDateRequise.Location = New System.Drawing.Point(232, 80)
		Me.cmdAnnulerDateRequise.TabIndex = 95
		Me.cmdAnnulerDateRequise.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnulerDateRequise.CausesValidation = True
		Me.cmdAnnulerDateRequise.Enabled = True
		Me.cmdAnnulerDateRequise.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnulerDateRequise.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnulerDateRequise.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnulerDateRequise.TabStop = True
		Me.cmdAnnulerDateRequise.Name = "cmdAnnulerDateRequise"
		Me.cmdOKDateRequise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOKDateRequise.Text = "OK"
		Me.cmdOKDateRequise.Size = New System.Drawing.Size(73, 25)
		Me.cmdOKDateRequise.Location = New System.Drawing.Point(232, 48)
		Me.cmdOKDateRequise.TabIndex = 93
		Me.cmdOKDateRequise.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOKDateRequise.CausesValidation = True
		Me.cmdOKDateRequise.Enabled = True
		Me.cmdOKDateRequise.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOKDateRequise.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOKDateRequise.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOKDateRequise.TabStop = True
		Me.cmdOKDateRequise.Name = "cmdOKDateRequise"
		mvwDateRequise.OcxState = CType(resources.GetObject("mvwDateRequise.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwDateRequise.Size = New System.Drawing.Size(173, 158)
		Me.mvwDateRequise.Location = New System.Drawing.Point(40, 24)
		Me.mvwDateRequise.TabIndex = 91
		Me.mvwDateRequise.Name = "mvwDateRequise"
		Me.fraCommentaire.BackColor = System.Drawing.Color.Black
		Me.fraCommentaire.Text = "Commentaire"
		Me.fraCommentaire.ForeColor = System.Drawing.Color.White
		Me.fraCommentaire.Size = New System.Drawing.Size(321, 193)
		Me.fraCommentaire.Location = New System.Drawing.Point(240, 328)
		Me.fraCommentaire.TabIndex = 96
		Me.fraCommentaire.Visible = False
		Me.fraCommentaire.Enabled = True
		Me.fraCommentaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraCommentaire.Padding = New System.Windows.Forms.Padding(0)
		Me.fraCommentaire.Name = "fraCommentaire"
		Me.txtCommentaire.AutoSize = False
		Me.txtCommentaire.Size = New System.Drawing.Size(217, 161)
		Me.txtCommentaire.Location = New System.Drawing.Point(16, 24)
		Me.txtCommentaire.MultiLine = True
		Me.txtCommentaire.TabIndex = 97
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
		Me.cmdOKCommentaire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOKCommentaire.Text = "OK"
		Me.cmdOKCommentaire.Size = New System.Drawing.Size(73, 25)
		Me.cmdOKCommentaire.Location = New System.Drawing.Point(240, 48)
		Me.cmdOKCommentaire.TabIndex = 98
		Me.cmdOKCommentaire.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOKCommentaire.CausesValidation = True
		Me.cmdOKCommentaire.Enabled = True
		Me.cmdOKCommentaire.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOKCommentaire.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOKCommentaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOKCommentaire.TabStop = True
		Me.cmdOKCommentaire.Name = "cmdOKCommentaire"
		Me.cmdAnnulerCommentaire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnulerCommentaire.Text = "Annuler"
		Me.cmdAnnulerCommentaire.Size = New System.Drawing.Size(73, 25)
		Me.cmdAnnulerCommentaire.Location = New System.Drawing.Point(240, 80)
		Me.cmdAnnulerCommentaire.TabIndex = 99
		Me.cmdAnnulerCommentaire.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnulerCommentaire.CausesValidation = True
		Me.cmdAnnulerCommentaire.Enabled = True
		Me.cmdAnnulerCommentaire.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnulerCommentaire.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnulerCommentaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnulerCommentaire.TabStop = True
		Me.cmdAnnulerCommentaire.Name = "cmdAnnulerCommentaire"
		Me.fraPrixPiece.BackColor = System.Drawing.Color.Black
		Me.fraPrixPiece.Text = "Fournisseurs"
		Me.fraPrixPiece.ForeColor = System.Drawing.Color.White
		Me.fraPrixPiece.Size = New System.Drawing.Size(593, 153)
		Me.fraPrixPiece.Location = New System.Drawing.Point(56, 328)
		Me.fraPrixPiece.TabIndex = 76
		Me.fraPrixPiece.Visible = False
		Me.fraPrixPiece.Enabled = True
		Me.fraPrixPiece.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraPrixPiece.Padding = New System.Windows.Forms.Padding(0)
		Me.fraPrixPiece.Name = "fraPrixPiece"
		Me.txtPrixSpecial.AutoSize = False
		Me.txtPrixSpecial.BackColor = System.Drawing.Color.White
		Me.txtPrixSpecial.Size = New System.Drawing.Size(57, 19)
		Me.txtPrixSpecial.Location = New System.Drawing.Point(328, 104)
		Me.txtPrixSpecial.TabIndex = 86
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
		Me.txtPrixList.AutoSize = False
		Me.txtPrixList.BackColor = System.Drawing.Color.White
		Me.txtPrixList.Size = New System.Drawing.Size(73, 19)
		Me.txtPrixList.Location = New System.Drawing.Point(328, 32)
		Me.txtPrixList.TabIndex = 80
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
		Me.txtPrixNet.Location = New System.Drawing.Point(328, 80)
		Me.txtPrixNet.TabIndex = 84
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
		Me.cmbfrs.Size = New System.Drawing.Size(185, 21)
		Me.cmbfrs.Location = New System.Drawing.Point(16, 32)
		Me.cmbfrs.TabIndex = 78
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
		Me.optUSA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optUSA.BackColor = System.Drawing.Color.Black
		Me.optUSA.Text = "USA"
		Me.optUSA.ForeColor = System.Drawing.Color.White
		Me.optUSA.Size = New System.Drawing.Size(49, 17)
		Me.optUSA.Location = New System.Drawing.Point(488, 16)
		Me.optUSA.TabIndex = 88
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
		Me.optCAN.Location = New System.Drawing.Point(440, 16)
		Me.optCAN.TabIndex = 87
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
		Me.optSpain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optSpain.BackColor = System.Drawing.Color.Black
		Me.optSpain.Text = "SPA"
		Me.optSpain.ForeColor = System.Drawing.Color.White
		Me.optSpain.Size = New System.Drawing.Size(49, 17)
		Me.optSpain.Location = New System.Drawing.Point(536, 16)
		Me.optSpain.TabIndex = 90
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
		Me.cmdOKPrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOKPrix.Text = "OK"
		Me.cmdOKPrix.Size = New System.Drawing.Size(73, 25)
		Me.cmdOKPrix.Location = New System.Drawing.Point(496, 120)
		Me.cmdOKPrix.TabIndex = 94
		Me.cmdOKPrix.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOKPrix.CausesValidation = True
		Me.cmdOKPrix.Enabled = True
		Me.cmdOKPrix.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOKPrix.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOKPrix.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOKPrix.TabStop = True
		Me.cmdOKPrix.Name = "cmdOKPrix"
		Me.cmdAnnulerPrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnulerPrix.Text = "Annuler"
		Me.cmdAnnulerPrix.Size = New System.Drawing.Size(73, 25)
		Me.cmdAnnulerPrix.Location = New System.Drawing.Point(416, 120)
		Me.cmdAnnulerPrix.TabIndex = 92
		Me.cmdAnnulerPrix.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnulerPrix.CausesValidation = True
		Me.cmdAnnulerPrix.Enabled = True
		Me.cmdAnnulerPrix.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnulerPrix.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnulerPrix.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnulerPrix.TabStop = True
		Me.cmdAnnulerPrix.Name = "cmdAnnulerPrix"
		Me.mskEscompte.AllowPromptAsInput = False
		Me.mskEscompte.Size = New System.Drawing.Size(57, 17)
		Me.mskEscompte.Location = New System.Drawing.Point(328, 56)
		Me.mskEscompte.TabIndex = 82
		Me.mskEscompte.PromptChar = "_"
		Me.mskEscompte.Name = "mskEscompte"
		Me._Label1_0.Text = "Prix Spécial :"
		Me._Label1_0.ForeColor = System.Drawing.Color.White
		Me._Label1_0.Size = New System.Drawing.Size(81, 17)
		Me._Label1_0.Location = New System.Drawing.Point(248, 104)
		Me._Label1_0.TabIndex = 85
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
		Me.imgCanada.Size = New System.Drawing.Size(112, 71)
		Me.imgCanada.Location = New System.Drawing.Point(456, 40)
		Me.imgCanada.Image = CType(resources.GetObject("imgCanada.Image"), System.Drawing.Image)
		Me.imgCanada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.imgCanada.Visible = False
		Me.imgCanada.Enabled = True
		Me.imgCanada.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgCanada.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.imgCanada.Name = "imgCanada"
		Me._Label1_14.Text = "Distributeur :"
		Me._Label1_14.ForeColor = System.Drawing.Color.White
		Me._Label1_14.Size = New System.Drawing.Size(81, 17)
		Me._Label1_14.Location = New System.Drawing.Point(16, 16)
		Me._Label1_14.TabIndex = 77
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
		Me._Label1_16.Location = New System.Drawing.Point(248, 32)
		Me._Label1_16.TabIndex = 79
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
		Me._Label1_19.Location = New System.Drawing.Point(248, 56)
		Me._Label1_19.TabIndex = 81
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
		Me._Label1_20.Text = "Prix Net :"
		Me._Label1_20.ForeColor = System.Drawing.Color.White
		Me._Label1_20.Size = New System.Drawing.Size(73, 17)
		Me._Label1_20.Location = New System.Drawing.Point(248, 80)
		Me._Label1_20.TabIndex = 83
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
		Me.imgSpain.Size = New System.Drawing.Size(112, 71)
		Me.imgSpain.Location = New System.Drawing.Point(456, 40)
		Me.imgSpain.Image = CType(resources.GetObject("imgSpain.Image"), System.Drawing.Image)
		Me.imgSpain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.imgSpain.Visible = False
		Me.imgSpain.Enabled = True
		Me.imgSpain.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgSpain.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.imgSpain.Name = "imgSpain"
		Me.imgEU.Size = New System.Drawing.Size(112, 71)
		Me.imgEU.Location = New System.Drawing.Point(456, 40)
		Me.imgEU.Image = CType(resources.GetObject("imgEU.Image"), System.Drawing.Image)
		Me.imgEU.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.imgEU.Visible = False
		Me.imgEU.Enabled = True
		Me.imgEU.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgEU.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.imgEU.Name = "imgEU"
		Me.cmdAnglaisFrancais.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnglaisFrancais.Text = "Anglais"
		Me.cmdAnglaisFrancais.Size = New System.Drawing.Size(65, 25)
		Me.cmdAnglaisFrancais.Location = New System.Drawing.Point(80, 512)
		Me.cmdAnglaisFrancais.TabIndex = 102
		Me.cmdAnglaisFrancais.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnglaisFrancais.CausesValidation = True
		Me.cmdAnglaisFrancais.Enabled = True
		Me.cmdAnglaisFrancais.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnglaisFrancais.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnglaisFrancais.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnglaisFrancais.TabStop = True
		Me.cmdAnglaisFrancais.Name = "cmdAnglaisFrancais"
		Me.cmdReset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdReset.Text = "Reset"
		Me.cmdReset.Size = New System.Drawing.Size(65, 25)
		Me.cmdReset.Location = New System.Drawing.Point(224, 512)
		Me.cmdReset.TabIndex = 107
		Me.cmdReset.Visible = False
		Me.cmdReset.BackColor = System.Drawing.SystemColors.Control
		Me.cmdReset.CausesValidation = True
		Me.cmdReset.Enabled = True
		Me.cmdReset.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdReset.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdReset.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdReset.TabStop = True
		Me.cmdReset.Name = "cmdReset"
		Me.cmdRapportFACT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRapportFACT.Text = "Fact"
		Me.cmdRapportFACT.Size = New System.Drawing.Size(65, 25)
		Me.cmdRapportFACT.Location = New System.Drawing.Point(152, 512)
		Me.cmdRapportFACT.TabIndex = 106
		Me.cmdRapportFACT.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRapportFACT.CausesValidation = True
		Me.cmdRapportFACT.Enabled = True
		Me.cmdRapportFACT.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRapportFACT.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRapportFACT.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRapportFACT.TabStop = True
		Me.cmdRapportFACT.Name = "cmdRapportFACT"
		Me.cmdTexte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdTexte.Text = "Texte"
		Me.cmdTexte.Size = New System.Drawing.Size(65, 25)
		Me.cmdTexte.Location = New System.Drawing.Point(8, 512)
		Me.cmdTexte.TabIndex = 101
		Me.cmdTexte.BackColor = System.Drawing.SystemColors.Control
		Me.cmdTexte.CausesValidation = True
		Me.cmdTexte.Enabled = True
		Me.cmdTexte.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdTexte.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdTexte.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdTexte.TabStop = True
		Me.cmdTexte.Name = "cmdTexte"
		Me.cmdDemande.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDemande.Text = "Demande"
		Me.cmdDemande.Size = New System.Drawing.Size(65, 25)
		Me.cmdDemande.Location = New System.Drawing.Point(152, 512)
		Me.cmdDemande.TabIndex = 103
		Me.cmdDemande.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDemande.CausesValidation = True
		Me.cmdDemande.Enabled = True
		Me.cmdDemande.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDemande.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDemande.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDemande.TabStop = True
		Me.cmdDemande.Name = "cmdDemande"
		Me.cmdSortieMagasin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSortieMagasin.Text = "Magasin"
		Me.cmdSortieMagasin.Size = New System.Drawing.Size(65, 25)
		Me.cmdSortieMagasin.Location = New System.Drawing.Point(360, 512)
		Me.cmdSortieMagasin.TabIndex = 111
		Me.cmdSortieMagasin.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSortieMagasin.CausesValidation = True
		Me.cmdSortieMagasin.Enabled = True
		Me.cmdSortieMagasin.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSortieMagasin.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSortieMagasin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSortieMagasin.TabStop = True
		Me.cmdSortieMagasin.Name = "cmdSortieMagasin"
		Me.cmdMauvaisPrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMauvaisPrix.Text = "Prix"
		Me.cmdMauvaisPrix.Size = New System.Drawing.Size(65, 25)
		Me.cmdMauvaisPrix.Location = New System.Drawing.Point(216, 512)
		Me.cmdMauvaisPrix.TabIndex = 105
		Me.cmdMauvaisPrix.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMauvaisPrix.CausesValidation = True
		Me.cmdMauvaisPrix.Enabled = True
		Me.cmdMauvaisPrix.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMauvaisPrix.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMauvaisPrix.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMauvaisPrix.TabStop = True
		Me.cmdMauvaisPrix.Name = "cmdMauvaisPrix"
		Me.cmdMaterielInutile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMaterielInutile.Text = "Inutile"
		Me.cmdMaterielInutile.Size = New System.Drawing.Size(65, 25)
		Me.cmdMaterielInutile.Location = New System.Drawing.Point(360, 512)
		Me.cmdMaterielInutile.TabIndex = 113
		Me.cmdMaterielInutile.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMaterielInutile.CausesValidation = True
		Me.cmdMaterielInutile.Enabled = True
		Me.cmdMaterielInutile.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMaterielInutile.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMaterielInutile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMaterielInutile.TabStop = True
		Me.cmdMaterielInutile.Name = "cmdMaterielInutile"
		Me.cmdCreerProjet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCreerProjet.Text = "Créer proj."
		Me.cmdCreerProjet.Size = New System.Drawing.Size(65, 25)
		Me.cmdCreerProjet.Location = New System.Drawing.Point(288, 512)
		Me.cmdCreerProjet.TabIndex = 109
		Me.cmdCreerProjet.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCreerProjet.CausesValidation = True
		Me.cmdCreerProjet.Enabled = True
		Me.cmdCreerProjet.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCreerProjet.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCreerProjet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCreerProjet.TabStop = True
		Me.cmdCreerProjet.Name = "cmdCreerProjet"
		Me.cmdCatalogue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCatalogue.Text = "Catalogue"
		Me.cmdCatalogue.Size = New System.Drawing.Size(65, 25)
		Me.cmdCatalogue.Location = New System.Drawing.Point(360, 512)
		Me.cmdCatalogue.TabIndex = 112
		Me.cmdCatalogue.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCatalogue.CausesValidation = True
		Me.cmdCatalogue.Enabled = True
		Me.cmdCatalogue.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCatalogue.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCatalogue.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCatalogue.TabStop = True
		Me.cmdCatalogue.Name = "cmdCatalogue"
		Me.cmdBonCommande.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBonCommande.Text = "Bon Com."
		Me.cmdBonCommande.Size = New System.Drawing.Size(65, 25)
		Me.cmdBonCommande.Location = New System.Drawing.Point(224, 512)
		Me.cmdBonCommande.TabIndex = 110
		Me.cmdBonCommande.Visible = False
		Me.cmdBonCommande.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBonCommande.CausesValidation = True
		Me.cmdBonCommande.Enabled = True
		Me.cmdBonCommande.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBonCommande.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBonCommande.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBonCommande.TabStop = True
		Me.cmdBonCommande.Name = "cmdBonCommande"
		Me.cmdRetour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRetour.Text = "Retour"
		Me.cmdRetour.Size = New System.Drawing.Size(65, 25)
		Me.cmdRetour.Location = New System.Drawing.Point(360, 512)
		Me.cmdRetour.TabIndex = 114
		Me.cmdRetour.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRetour.CausesValidation = True
		Me.cmdRetour.Enabled = True
		Me.cmdRetour.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRetour.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRetour.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRetour.TabStop = True
		Me.cmdRetour.Name = "cmdRetour"
		Me.cmdExtra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExtra.Text = "Extra"
		Me.cmdExtra.Size = New System.Drawing.Size(65, 25)
		Me.cmdExtra.Location = New System.Drawing.Point(152, 512)
		Me.cmdExtra.TabIndex = 104
		Me.cmdExtra.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExtra.CausesValidation = True
		Me.cmdExtra.Enabled = True
		Me.cmdExtra.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExtra.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExtra.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExtra.TabStop = True
		Me.cmdExtra.Name = "cmdExtra"
		Me.cmdCopier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCopier.Text = "Copier"
		Me.cmdCopier.Size = New System.Drawing.Size(65, 25)
		Me.cmdCopier.Location = New System.Drawing.Point(432, 512)
		Me.cmdCopier.TabIndex = 115
		Me.cmdCopier.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCopier.CausesValidation = True
		Me.cmdCopier.Enabled = True
		Me.cmdCopier.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCopier.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCopier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCopier.TabStop = True
		Me.cmdCopier.Name = "cmdCopier"
		Me.cmdImprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdImprimer.Text = "Imprimer"
		Me.cmdImprimer.Size = New System.Drawing.Size(65, 25)
		Me.cmdImprimer.Location = New System.Drawing.Point(8, 512)
		Me.cmdImprimer.TabIndex = 100
		Me.cmdImprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdImprimer.CausesValidation = True
		Me.cmdImprimer.Enabled = True
		Me.cmdImprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdImprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdImprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdImprimer.TabStop = True
		Me.cmdImprimer.Name = "cmdImprimer"
		Me.cmdAjouter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAjouter.Text = "Ajouter"
		Me.cmdAjouter.Size = New System.Drawing.Size(65, 25)
		Me.cmdAjouter.Location = New System.Drawing.Point(504, 512)
		Me.cmdAjouter.TabIndex = 116
		Me.cmdAjouter.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAjouter.CausesValidation = True
		Me.cmdAjouter.Enabled = True
		Me.cmdAjouter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAjouter.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAjouter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAjouter.TabStop = True
		Me.cmdAjouter.Name = "cmdAjouter"
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(65, 25)
		Me.cmdFermer.Location = New System.Drawing.Point(720, 512)
		Me.cmdFermer.TabIndex = 121
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(65, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(648, 512)
		Me.cmdAnnuler.TabIndex = 119
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.cmdEnregistrer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEnregistrer.Text = "Enregistrer"
		Me.cmdEnregistrer.Size = New System.Drawing.Size(65, 25)
		Me.cmdEnregistrer.Location = New System.Drawing.Point(576, 512)
		Me.cmdEnregistrer.TabIndex = 117
		Me.cmdEnregistrer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEnregistrer.CausesValidation = True
		Me.cmdEnregistrer.Enabled = True
		Me.cmdEnregistrer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEnregistrer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEnregistrer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEnregistrer.TabStop = True
		Me.cmdEnregistrer.Name = "cmdEnregistrer"
		Me.cmdModifier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdModifier.Text = "Modifier"
		Me.cmdModifier.Size = New System.Drawing.Size(65, 25)
		Me.cmdModifier.Location = New System.Drawing.Point(648, 512)
		Me.cmdModifier.TabIndex = 120
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
		Me.cmdSupprimer.Size = New System.Drawing.Size(65, 25)
		Me.cmdSupprimer.Location = New System.Drawing.Point(576, 512)
		Me.cmdSupprimer.TabIndex = 118
		Me.cmdSupprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSupprimer.CausesValidation = True
		Me.cmdSupprimer.Enabled = True
		Me.cmdSupprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSupprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSupprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSupprimer.TabStop = True
		Me.cmdSupprimer.Name = "cmdSupprimer"
		Me.fraCertifDelais.BackColor = System.Drawing.Color.Black
		Me.fraCertifDelais.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.fraCertifDelais.Text = "Frame1"
		Me.fraCertifDelais.Size = New System.Drawing.Size(145, 73)
		Me.fraCertifDelais.Location = New System.Drawing.Point(640, 144)
		Me.fraCertifDelais.TabIndex = 42
		Me.fraCertifDelais.Enabled = True
		Me.fraCertifDelais.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraCertifDelais.Cursor = System.Windows.Forms.Cursors.Default
		Me.fraCertifDelais.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraCertifDelais.Visible = True
		Me.fraCertifDelais.Name = "fraCertifDelais"
		Me.picApprob.BackColor = System.Drawing.Color.Black
		Me.picApprob.Size = New System.Drawing.Size(153, 33)
		Me.picApprob.Location = New System.Drawing.Point(0, 8)
		Me.picApprob.TabIndex = 43
		Me.picApprob.Dock = System.Windows.Forms.DockStyle.None
		Me.picApprob.CausesValidation = True
		Me.picApprob.Enabled = True
		Me.picApprob.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picApprob.Cursor = System.Windows.Forms.Cursors.Default
		Me.picApprob.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picApprob.TabStop = True
		Me.picApprob.Visible = True
		Me.picApprob.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picApprob.Name = "picApprob"
		Me.chkUR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkUR.BackColor = System.Drawing.Color.Black
		Me.chkUR.Text = "UR"
		Me.chkUR.ForeColor = System.Drawing.Color.White
		Me.chkUR.Size = New System.Drawing.Size(41, 17)
		Me.chkUR.Location = New System.Drawing.Point(104, 0)
		Me.chkUR.TabIndex = 46
		Me.chkUR.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkUR.CausesValidation = True
		Me.chkUR.Enabled = True
		Me.chkUR.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkUR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkUR.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkUR.TabStop = True
		Me.chkUR.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkUR.Visible = True
		Me.chkUR.Name = "chkUR"
		Me.chkCE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkCE.BackColor = System.Drawing.Color.Black
		Me.chkCE.Text = "CE"
		Me.chkCE.ForeColor = System.Drawing.Color.White
		Me.chkCE.Size = New System.Drawing.Size(41, 17)
		Me.chkCE.Location = New System.Drawing.Point(104, 16)
		Me.chkCE.TabIndex = 49
		Me.chkCE.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkCE.CausesValidation = True
		Me.chkCE.Enabled = True
		Me.chkCE.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkCE.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkCE.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkCE.TabStop = True
		Me.chkCE.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkCE.Visible = True
		Me.chkCE.Name = "chkCE"
		Me.chkCUR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkCUR.BackColor = System.Drawing.Color.Black
		Me.chkCUR.Text = "cUR"
		Me.chkCUR.ForeColor = System.Drawing.Color.White
		Me.chkCUR.Size = New System.Drawing.Size(49, 17)
		Me.chkCUR.Location = New System.Drawing.Point(48, 16)
		Me.chkCUR.TabIndex = 47
		Me.chkCUR.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkCUR.CausesValidation = True
		Me.chkCUR.Enabled = True
		Me.chkCUR.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkCUR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkCUR.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkCUR.TabStop = True
		Me.chkCUR.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkCUR.Visible = True
		Me.chkCUR.Name = "chkCUR"
		Me.chkUL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkUL.BackColor = System.Drawing.Color.Black
		Me.chkUL.Text = "UL"
		Me.chkUL.ForeColor = System.Drawing.Color.White
		Me.chkUL.Size = New System.Drawing.Size(41, 17)
		Me.chkUL.Location = New System.Drawing.Point(56, 0)
		Me.chkUL.TabIndex = 45
		Me.chkUL.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkUL.CausesValidation = True
		Me.chkUL.Enabled = True
		Me.chkUL.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkUL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkUL.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkUL.TabStop = True
		Me.chkUL.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkUL.Visible = True
		Me.chkUL.Name = "chkUL"
		Me.chkCUL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkCUL.BackColor = System.Drawing.Color.Black
		Me.chkCUL.Text = "cUL"
		Me.chkCUL.ForeColor = System.Drawing.Color.White
		Me.chkCUL.Size = New System.Drawing.Size(49, 17)
		Me.chkCUL.Location = New System.Drawing.Point(0, 16)
		Me.chkCUL.TabIndex = 48
		Me.chkCUL.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkCUL.CausesValidation = True
		Me.chkCUL.Enabled = True
		Me.chkCUL.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkCUL.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkCUL.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkCUL.TabStop = True
		Me.chkCUL.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkCUL.Visible = True
		Me.chkCUL.Name = "chkCUL"
		Me.chkCSA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chkCSA.BackColor = System.Drawing.Color.Black
		Me.chkCSA.Text = "CSA"
		Me.chkCSA.ForeColor = System.Drawing.Color.White
		Me.chkCSA.Size = New System.Drawing.Size(49, 17)
		Me.chkCSA.Location = New System.Drawing.Point(0, 0)
		Me.chkCSA.TabIndex = 44
		Me.chkCSA.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkCSA.CausesValidation = True
		Me.chkCSA.Enabled = True
		Me.chkCSA.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkCSA.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkCSA.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkCSA.TabStop = True
		Me.chkCSA.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkCSA.Visible = True
		Me.chkCSA.Name = "chkCSA"
		Me.txtDelais.AutoSize = False
		Me.txtDelais.Size = New System.Drawing.Size(65, 20)
		Me.txtDelais.Location = New System.Drawing.Point(48, 52)
		Me.txtDelais.ReadOnly = True
		Me.txtDelais.TabIndex = 50
		Me.txtDelais.AcceptsReturn = True
		Me.txtDelais.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDelais.BackColor = System.Drawing.SystemColors.Window
		Me.txtDelais.CausesValidation = True
		Me.txtDelais.Enabled = True
		Me.txtDelais.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDelais.HideSelection = True
		Me.txtDelais.Maxlength = 0
		Me.txtDelais.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDelais.MultiLine = False
		Me.txtDelais.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDelais.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDelais.TabStop = True
		Me.txtDelais.Visible = True
		Me.txtDelais.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDelais.Name = "txtDelais"
		Me.cmdDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDate.Text = "..."
		Me.cmdDate.Size = New System.Drawing.Size(25, 21)
		Me.cmdDate.Location = New System.Drawing.Point(120, 52)
		Me.cmdDate.TabIndex = 52
		Me.cmdDate.Visible = False
		Me.cmdDate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDate.CausesValidation = True
		Me.cmdDate.Enabled = True
		Me.cmdDate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDate.TabStop = True
		Me.cmdDate.Name = "cmdDate"
		Me.Label21.Text = "Delais"
		Me.Label21.ForeColor = System.Drawing.Color.White
		Me.Label21.Size = New System.Drawing.Size(33, 17)
		Me.Label21.Location = New System.Drawing.Point(16, 52)
		Me.Label21.TabIndex = 51
		Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label21.BackColor = System.Drawing.Color.Transparent
		Me.Label21.Enabled = True
		Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label21.UseMnemonic = True
		Me.Label21.Visible = True
		Me.Label21.AutoSize = False
		Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label21.Name = "Label21"
		Me.fraFsTransMarq.BackColor = System.Drawing.Color.Black
		Me.fraFsTransMarq.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.fraFsTransMarq.Size = New System.Drawing.Size(137, 81)
		Me.fraFsTransMarq.Location = New System.Drawing.Point(664, 32)
		Me.fraFsTransMarq.TabIndex = 33
		Me.fraFsTransMarq.Enabled = True
		Me.fraFsTransMarq.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraFsTransMarq.Cursor = System.Windows.Forms.Cursors.Default
		Me.fraFsTransMarq.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraFsTransMarq.Visible = True
		Me.fraFsTransMarq.Name = "fraFsTransMarq"
		Me.txtPrixSoumission.AutoSize = False
		Me.txtPrixSoumission.Size = New System.Drawing.Size(65, 19)
		Me.txtPrixSoumission.Location = New System.Drawing.Point(72, 56)
		Me.txtPrixSoumission.ReadOnly = True
		Me.txtPrixSoumission.TabIndex = 40
		Me.txtPrixSoumission.AcceptsReturn = True
		Me.txtPrixSoumission.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPrixSoumission.BackColor = System.Drawing.SystemColors.Window
		Me.txtPrixSoumission.CausesValidation = True
		Me.txtPrixSoumission.Enabled = True
		Me.txtPrixSoumission.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPrixSoumission.HideSelection = True
		Me.txtPrixSoumission.Maxlength = 0
		Me.txtPrixSoumission.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPrixSoumission.MultiLine = False
		Me.txtPrixSoumission.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPrixSoumission.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPrixSoumission.TabStop = True
		Me.txtPrixSoumission.Visible = True
		Me.txtPrixSoumission.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPrixSoumission.Name = "txtPrixSoumission"
		Me.cmbTransport.Size = New System.Drawing.Size(73, 21)
		Me.cmbTransport.Location = New System.Drawing.Point(64, 0)
		Me.cmbTransport.Items.AddRange(New Object(){"Client", "Fab Granby"})
		Me.cmbTransport.Sorted = True
		Me.cmbTransport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbTransport.TabIndex = 34
		Me.cmbTransport.Visible = False
		Me.cmbTransport.BackColor = System.Drawing.SystemColors.Window
		Me.cmbTransport.CausesValidation = True
		Me.cmbTransport.Enabled = True
		Me.cmbTransport.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbTransport.IntegralHeight = True
		Me.cmbTransport.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbTransport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbTransport.TabStop = True
		Me.cmbTransport.Name = "cmbTransport"
		Me.txtTransport.AutoSize = False
		Me.txtTransport.Size = New System.Drawing.Size(73, 19)
		Me.txtTransport.Location = New System.Drawing.Point(64, 0)
		Me.txtTransport.ReadOnly = True
		Me.txtTransport.TabIndex = 35
		Me.txtTransport.Text = "Text1"
		Me.txtTransport.AcceptsReturn = True
		Me.txtTransport.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTransport.BackColor = System.Drawing.SystemColors.Window
		Me.txtTransport.CausesValidation = True
		Me.txtTransport.Enabled = True
		Me.txtTransport.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTransport.HideSelection = True
		Me.txtTransport.Maxlength = 0
		Me.txtTransport.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTransport.MultiLine = False
		Me.txtTransport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTransport.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTransport.TabStop = True
		Me.txtTransport.Visible = True
		Me.txtTransport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTransport.Name = "txtTransport"
		Me.txtPrixReception.AutoSize = False
		Me.txtPrixReception.Size = New System.Drawing.Size(65, 19)
		Me.txtPrixReception.Location = New System.Drawing.Point(72, 32)
		Me.txtPrixReception.ReadOnly = True
		Me.txtPrixReception.TabIndex = 38
		Me.txtPrixReception.AcceptsReturn = True
		Me.txtPrixReception.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPrixReception.BackColor = System.Drawing.SystemColors.Window
		Me.txtPrixReception.CausesValidation = True
		Me.txtPrixReception.Enabled = True
		Me.txtPrixReception.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPrixReception.HideSelection = True
		Me.txtPrixReception.Maxlength = 0
		Me.txtPrixReception.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPrixReception.MultiLine = False
		Me.txtPrixReception.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPrixReception.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPrixReception.TabStop = True
		Me.txtPrixReception.Visible = True
		Me.txtPrixReception.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPrixReception.Name = "txtPrixReception"
		Me.lblPrixSoumission.Text = "$ Soumission : "
		Me.lblPrixSoumission.ForeColor = System.Drawing.Color.White
		Me.lblPrixSoumission.Size = New System.Drawing.Size(81, 17)
		Me.lblPrixSoumission.Location = New System.Drawing.Point(0, 56)
		Me.lblPrixSoumission.TabIndex = 39
		Me.lblPrixSoumission.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPrixSoumission.BackColor = System.Drawing.Color.Transparent
		Me.lblPrixSoumission.Enabled = True
		Me.lblPrixSoumission.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPrixSoumission.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPrixSoumission.UseMnemonic = True
		Me.lblPrixSoumission.Visible = True
		Me.lblPrixSoumission.AutoSize = False
		Me.lblPrixSoumission.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPrixSoumission.Name = "lblPrixSoumission"
		Me.lblPrixReception.Text = "$ Réception : "
		Me.lblPrixReception.ForeColor = System.Drawing.Color.White
		Me.lblPrixReception.Size = New System.Drawing.Size(81, 17)
		Me.lblPrixReception.Location = New System.Drawing.Point(0, 32)
		Me.lblPrixReception.TabIndex = 37
		Me.lblPrixReception.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPrixReception.BackColor = System.Drawing.Color.Transparent
		Me.lblPrixReception.Enabled = True
		Me.lblPrixReception.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPrixReception.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPrixReception.UseMnemonic = True
		Me.lblPrixReception.Visible = True
		Me.lblPrixReception.AutoSize = False
		Me.lblPrixReception.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPrixReception.Name = "lblPrixReception"
		Me.Label26.Text = "Transport"
		Me.Label26.ForeColor = System.Drawing.Color.White
		Me.Label26.Size = New System.Drawing.Size(57, 17)
		Me.Label26.Location = New System.Drawing.Point(8, 0)
		Me.Label26.TabIndex = 36
		Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label26.BackColor = System.Drawing.Color.Transparent
		Me.Label26.Enabled = True
		Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label26.UseMnemonic = True
		Me.Label26.Visible = True
		Me.Label26.AutoSize = False
		Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label26.Name = "Label26"
		Me.cmdRafraichir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRafraichir.Text = "Rafraichir"
		Me.cmdRafraichir.Size = New System.Drawing.Size(65, 21)
		Me.cmdRafraichir.Location = New System.Drawing.Point(552, 184)
		Me.cmdRafraichir.TabIndex = 66
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
		Me.cmdTri.Location = New System.Drawing.Point(552, 204)
		Me.cmdTri.TabIndex = 73
		Me.cmdTri.BackColor = System.Drawing.SystemColors.Control
		Me.cmdTri.CausesValidation = True
		Me.cmdTri.Enabled = True
		Me.cmdTri.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdTri.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdTri.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdTri.TabStop = True
		Me.cmdTri.Name = "cmdTri"
		Me.fraPrix.BackColor = System.Drawing.Color.Black
		Me.fraPrix.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.fraPrix.Text = "Frame1"
		Me.fraPrix.Size = New System.Drawing.Size(177, 161)
		Me.fraPrix.Location = New System.Drawing.Point(824, 32)
		Me.fraPrix.TabIndex = 53
		Me.fraPrix.Enabled = True
		Me.fraPrix.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraPrix.Cursor = System.Windows.Forms.Cursors.Default
		Me.fraPrix.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraPrix.Visible = True
		Me.fraPrix.Name = "fraPrix"
		Me.txtTotalTemps.AutoSize = False
		Me.txtTotalTemps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtTotalTemps.Size = New System.Drawing.Size(89, 20)
		Me.txtTotalTemps.Location = New System.Drawing.Point(80, 8)
		Me.txtTotalTemps.ReadOnly = True
		Me.txtTotalTemps.TabIndex = 128
		Me.txtTotalTemps.AcceptsReturn = True
		Me.txtTotalTemps.BackColor = System.Drawing.SystemColors.Window
		Me.txtTotalTemps.CausesValidation = True
		Me.txtTotalTemps.Enabled = True
		Me.txtTotalTemps.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTotalTemps.HideSelection = True
		Me.txtTotalTemps.Maxlength = 0
		Me.txtTotalTemps.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTotalTemps.MultiLine = False
		Me.txtTotalTemps.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTotalTemps.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTotalTemps.TabStop = True
		Me.txtTotalTemps.Visible = True
		Me.txtTotalTemps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTotalTemps.Name = "txtTotalTemps"
		Me.txtTotalPieces.AutoSize = False
		Me.txtTotalPieces.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtTotalPieces.Size = New System.Drawing.Size(89, 20)
		Me.txtTotalPieces.Location = New System.Drawing.Point(80, 32)
		Me.txtTotalPieces.ReadOnly = True
		Me.txtTotalPieces.TabIndex = 127
		Me.txtTotalPieces.AcceptsReturn = True
		Me.txtTotalPieces.BackColor = System.Drawing.SystemColors.Window
		Me.txtTotalPieces.CausesValidation = True
		Me.txtTotalPieces.Enabled = True
		Me.txtTotalPieces.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTotalPieces.HideSelection = True
		Me.txtTotalPieces.Maxlength = 0
		Me.txtTotalPieces.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTotalPieces.MultiLine = False
		Me.txtTotalPieces.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTotalPieces.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTotalPieces.TabStop = True
		Me.txtTotalPieces.Visible = True
		Me.txtTotalPieces.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTotalPieces.Name = "txtTotalPieces"
		Me.txtProfit.AutoSize = False
		Me.txtProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtProfit.Size = New System.Drawing.Size(89, 20)
		Me.txtProfit.Location = New System.Drawing.Point(80, 56)
		Me.txtProfit.ReadOnly = True
		Me.txtProfit.TabIndex = 126
		Me.txtProfit.AcceptsReturn = True
		Me.txtProfit.BackColor = System.Drawing.SystemColors.Window
		Me.txtProfit.CausesValidation = True
		Me.txtProfit.Enabled = True
		Me.txtProfit.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtProfit.HideSelection = True
		Me.txtProfit.Maxlength = 0
		Me.txtProfit.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtProfit.MultiLine = False
		Me.txtProfit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtProfit.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtProfit.TabStop = True
		Me.txtProfit.Visible = True
		Me.txtProfit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtProfit.Name = "txtProfit"
		Me.txtImprevus.AutoSize = False
		Me.txtImprevus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtImprevus.Size = New System.Drawing.Size(89, 20)
		Me.txtImprevus.Location = New System.Drawing.Point(80, 80)
		Me.txtImprevus.ReadOnly = True
		Me.txtImprevus.TabIndex = 125
		Me.txtImprevus.AcceptsReturn = True
		Me.txtImprevus.BackColor = System.Drawing.SystemColors.Window
		Me.txtImprevus.CausesValidation = True
		Me.txtImprevus.Enabled = True
		Me.txtImprevus.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtImprevus.HideSelection = True
		Me.txtImprevus.Maxlength = 0
		Me.txtImprevus.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtImprevus.MultiLine = False
		Me.txtImprevus.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtImprevus.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtImprevus.TabStop = True
		Me.txtImprevus.Visible = True
		Me.txtImprevus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtImprevus.Name = "txtImprevus"
		Me.txtCommission.AutoSize = False
		Me.txtCommission.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtCommission.Size = New System.Drawing.Size(89, 20)
		Me.txtCommission.Location = New System.Drawing.Point(80, 104)
		Me.txtCommission.ReadOnly = True
		Me.txtCommission.TabIndex = 124
		Me.txtCommission.AcceptsReturn = True
		Me.txtCommission.BackColor = System.Drawing.SystemColors.Window
		Me.txtCommission.CausesValidation = True
		Me.txtCommission.Enabled = True
		Me.txtCommission.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCommission.HideSelection = True
		Me.txtCommission.Maxlength = 0
		Me.txtCommission.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCommission.MultiLine = False
		Me.txtCommission.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCommission.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCommission.TabStop = True
		Me.txtCommission.Visible = True
		Me.txtCommission.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCommission.Name = "txtCommission"
		Me.txtPrixTotal.AutoSize = False
		Me.txtPrixTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtPrixTotal.BackColor = System.Drawing.Color.White
		Me.txtPrixTotal.ForeColor = System.Drawing.Color.Red
		Me.txtPrixTotal.Size = New System.Drawing.Size(89, 20)
		Me.txtPrixTotal.Location = New System.Drawing.Point(80, 128)
		Me.txtPrixTotal.ReadOnly = True
		Me.txtPrixTotal.TabIndex = 123
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
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label8.Text = "Administration"
		Me.Label8.ForeColor = System.Drawing.Color.White
		Me.Label8.Size = New System.Drawing.Size(65, 13)
		Me.Label8.Location = New System.Drawing.Point(8, 104)
		Me.Label8.TabIndex = 134
		Me.Label8.BackColor = System.Drawing.Color.Transparent
		Me.Label8.Enabled = True
		Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label8.UseMnemonic = True
		Me.Label8.Visible = True
		Me.Label8.AutoSize = True
		Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label8.Name = "Label8"
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label7.Text = "Prix Total"
		Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.ForeColor = System.Drawing.Color.White
		Me.Label7.Size = New System.Drawing.Size(59, 12)
		Me.Label7.Location = New System.Drawing.Point(16, 128)
		Me.Label7.TabIndex = 133
		Me.Label7.BackColor = System.Drawing.Color.Transparent
		Me.Label7.Enabled = True
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = True
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label5.Text = "Profit"
		Me.Label5.ForeColor = System.Drawing.Color.White
		Me.Label5.Size = New System.Drawing.Size(59, 13)
		Me.Label5.Location = New System.Drawing.Point(16, 56)
		Me.Label5.TabIndex = 132
		Me.Label5.BackColor = System.Drawing.Color.Transparent
		Me.Label5.Enabled = True
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = True
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.lblTotalPieces.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTotalPieces.Text = "Total Pièces"
		Me.lblTotalPieces.ForeColor = System.Drawing.Color.White
		Me.lblTotalPieces.Size = New System.Drawing.Size(59, 13)
		Me.lblTotalPieces.Location = New System.Drawing.Point(16, 32)
		Me.lblTotalPieces.TabIndex = 131
		Me.lblTotalPieces.BackColor = System.Drawing.Color.Transparent
		Me.lblTotalPieces.Enabled = True
		Me.lblTotalPieces.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTotalPieces.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTotalPieces.UseMnemonic = True
		Me.lblTotalPieces.Visible = True
		Me.lblTotalPieces.AutoSize = True
		Me.lblTotalPieces.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTotalPieces.Name = "lblTotalPieces"
		Me.lblImprevus.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblImprevus.Text = "Imprévus"
		Me.lblImprevus.ForeColor = System.Drawing.Color.White
		Me.lblImprevus.Size = New System.Drawing.Size(59, 13)
		Me.lblImprevus.Location = New System.Drawing.Point(16, 80)
		Me.lblImprevus.TabIndex = 130
		Me.lblImprevus.BackColor = System.Drawing.Color.Transparent
		Me.lblImprevus.Enabled = True
		Me.lblImprevus.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblImprevus.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblImprevus.UseMnemonic = True
		Me.lblImprevus.Visible = True
		Me.lblImprevus.AutoSize = True
		Me.lblImprevus.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblImprevus.Name = "lblImprevus"
		Me.lblTotalTemps.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTotalTemps.Text = "Total Temps"
		Me.lblTotalTemps.ForeColor = System.Drawing.Color.White
		Me.lblTotalTemps.Size = New System.Drawing.Size(59, 13)
		Me.lblTotalTemps.Location = New System.Drawing.Point(16, 8)
		Me.lblTotalTemps.TabIndex = 129
		Me.lblTotalTemps.BackColor = System.Drawing.Color.Transparent
		Me.lblTotalTemps.Enabled = True
		Me.lblTotalTemps.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTotalTemps.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTotalTemps.UseMnemonic = True
		Me.lblTotalTemps.Visible = True
		Me.lblTotalTemps.AutoSize = True
		Me.lblTotalTemps.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTotalTemps.Name = "lblTotalTemps"
		Me.cmbTri.Size = New System.Drawing.Size(113, 21)
		Me.cmbTri.Location = New System.Drawing.Point(432, 200)
		Me.cmbTri.Items.AddRange(New Object(){"PIECE_GRB", "No. d'item", "Manufacturier", "Description française", "Description anglaise"})
		Me.cmbTri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbTri.TabIndex = 72
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
		Me.cmbPieces.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbPieces.Size = New System.Drawing.Size(97, 21)
		Me.cmbPieces.Location = New System.Drawing.Point(320, 200)
		Me.cmbPieces.TabIndex = 71
		Me.cmbPieces.Visible = False
		Me.cmbPieces.BackColor = System.Drawing.SystemColors.Window
		Me.cmbPieces.CausesValidation = True
		Me.cmbPieces.Enabled = True
		Me.cmbPieces.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbPieces.IntegralHeight = True
		Me.cmbPieces.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbPieces.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbPieces.Sorted = False
		Me.cmbPieces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbPieces.TabStop = True
		Me.cmbPieces.Name = "cmbPieces"
		Me.txtCheminPhotos.AutoSize = False
		Me.txtCheminPhotos.Size = New System.Drawing.Size(153, 19)
		Me.txtCheminPhotos.Location = New System.Drawing.Point(48, 76)
		Me.txtCheminPhotos.TabIndex = 25
		Me.txtCheminPhotos.AcceptsReturn = True
		Me.txtCheminPhotos.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCheminPhotos.BackColor = System.Drawing.SystemColors.Window
		Me.txtCheminPhotos.CausesValidation = True
		Me.txtCheminPhotos.Enabled = True
		Me.txtCheminPhotos.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCheminPhotos.HideSelection = True
		Me.txtCheminPhotos.ReadOnly = False
		Me.txtCheminPhotos.Maxlength = 0
		Me.txtCheminPhotos.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCheminPhotos.MultiLine = False
		Me.txtCheminPhotos.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCheminPhotos.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCheminPhotos.TabStop = True
		Me.txtCheminPhotos.Visible = True
		Me.txtCheminPhotos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCheminPhotos.Name = "txtCheminPhotos"
		Me.cmdBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBrowse.Text = "..."
		Me.cmdBrowse.Size = New System.Drawing.Size(17, 17)
		Me.cmdBrowse.Location = New System.Drawing.Point(208, 76)
		Me.cmdBrowse.TabIndex = 27
		Me.cmdBrowse.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBrowse.CausesValidation = True
		Me.cmdBrowse.Enabled = True
		Me.cmdBrowse.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBrowse.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBrowse.TabStop = True
		Me.cmdBrowse.Name = "cmdBrowse"
		Me.cmdPhotos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPhotos.Text = "Afficher"
		Me.cmdPhotos.Size = New System.Drawing.Size(57, 17)
		Me.cmdPhotos.Location = New System.Drawing.Point(232, 76)
		Me.cmdPhotos.TabIndex = 28
		Me.cmdPhotos.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPhotos.CausesValidation = True
		Me.cmdPhotos.Enabled = True
		Me.cmdPhotos.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPhotos.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPhotos.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPhotos.TabStop = True
		Me.cmdPhotos.Name = "cmdPhotos"
		Me.txtProjet.AutoSize = False
		Me.txtProjet.Size = New System.Drawing.Size(249, 19)
		Me.txtProjet.Location = New System.Drawing.Point(400, 112)
		Me.txtProjet.TabIndex = 11
		Me.txtProjet.AcceptsReturn = True
		Me.txtProjet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtProjet.BackColor = System.Drawing.SystemColors.Window
		Me.txtProjet.CausesValidation = True
		Me.txtProjet.Enabled = True
		Me.txtProjet.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtProjet.HideSelection = True
		Me.txtProjet.ReadOnly = False
		Me.txtProjet.Maxlength = 0
		Me.txtProjet.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtProjet.MultiLine = False
		Me.txtProjet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtProjet.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtProjet.TabStop = True
		Me.txtProjet.Visible = True
		Me.txtProjet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtProjet.Name = "txtProjet"
		Me.cmbContact.Size = New System.Drawing.Size(177, 21)
		Me.cmbContact.Location = New System.Drawing.Point(400, 88)
		Me.cmbContact.Sorted = True
		Me.cmbContact.TabIndex = 13
		Me.cmbContact.BackColor = System.Drawing.SystemColors.Window
		Me.cmbContact.CausesValidation = True
		Me.cmbContact.Enabled = True
		Me.cmbContact.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbContact.IntegralHeight = True
		Me.cmbContact.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbContact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbContact.TabStop = True
		Me.cmbContact.Visible = True
		Me.cmbContact.Name = "cmbContact"
		Me.txtContact.AutoSize = False
		Me.txtContact.Size = New System.Drawing.Size(177, 19)
		Me.txtContact.Location = New System.Drawing.Point(400, 88)
		Me.txtContact.ReadOnly = True
		Me.txtContact.TabIndex = 14
		Me.txtContact.Text = "Text1"
		Me.txtContact.AcceptsReturn = True
		Me.txtContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtContact.BackColor = System.Drawing.SystemColors.Window
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
		Me.txtContact.Visible = True
		Me.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtContact.Name = "txtContact"
		Me.cmbClient.Size = New System.Drawing.Size(177, 21)
		Me.cmbClient.Location = New System.Drawing.Point(400, 64)
		Me.cmbClient.Sorted = True
		Me.cmbClient.TabIndex = 8
		Me.cmbClient.BackColor = System.Drawing.SystemColors.Window
		Me.cmbClient.CausesValidation = True
		Me.cmbClient.Enabled = True
		Me.cmbClient.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbClient.IntegralHeight = True
		Me.cmbClient.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbClient.TabStop = True
		Me.cmbClient.Visible = True
		Me.cmbClient.Name = "cmbClient"
		Me.txtClient.AutoSize = False
		Me.txtClient.Size = New System.Drawing.Size(177, 19)
		Me.txtClient.Location = New System.Drawing.Point(400, 64)
		Me.txtClient.ReadOnly = True
		Me.txtClient.TabIndex = 6
		Me.txtClient.Text = "Text1"
		Me.txtClient.AcceptsReturn = True
		Me.txtClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtClient.BackColor = System.Drawing.SystemColors.Window
		Me.txtClient.CausesValidation = True
		Me.txtClient.Enabled = True
		Me.txtClient.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtClient.HideSelection = True
		Me.txtClient.Maxlength = 0
		Me.txtClient.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtClient.MultiLine = False
		Me.txtClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtClient.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtClient.TabStop = True
		Me.txtClient.Visible = True
		Me.txtClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtClient.Name = "txtClient"
		Me.txtNoSoumission.AutoSize = False
		Me.txtNoSoumission.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.txtNoSoumission.Size = New System.Drawing.Size(73, 20)
		Me.txtNoSoumission.Location = New System.Drawing.Point(576, 32)
		Me.txtNoSoumission.ReadOnly = True
		Me.txtNoSoumission.TabIndex = 5
		Me.txtNoSoumission.AcceptsReturn = True
		Me.txtNoSoumission.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoSoumission.BackColor = System.Drawing.SystemColors.Window
		Me.txtNoSoumission.CausesValidation = True
		Me.txtNoSoumission.Enabled = True
		Me.txtNoSoumission.HideSelection = True
		Me.txtNoSoumission.Maxlength = 0
		Me.txtNoSoumission.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNoSoumission.MultiLine = False
		Me.txtNoSoumission.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNoSoumission.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNoSoumission.TabStop = True
		Me.txtNoSoumission.Visible = True
		Me.txtNoSoumission.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoSoumission.Name = "txtNoSoumission"
		Me.cmbProjSoum.Size = New System.Drawing.Size(113, 21)
		Me.cmbProjSoum.Location = New System.Drawing.Point(400, 32)
		Me.cmbProjSoum.TabIndex = 3
		Me.cmbProjSoum.Text = "cmbProjSoum"
		Me.cmbProjSoum.BackColor = System.Drawing.SystemColors.Window
		Me.cmbProjSoum.CausesValidation = True
		Me.cmbProjSoum.Enabled = True
		Me.cmbProjSoum.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbProjSoum.IntegralHeight = True
		Me.cmbProjSoum.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbProjSoum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbProjSoum.Sorted = False
		Me.cmbProjSoum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbProjSoum.TabStop = True
		Me.cmbProjSoum.Visible = True
		Me.cmbProjSoum.Name = "cmbProjSoum"
		Me.txtNoProjSoum.AutoSize = False
		Me.txtNoProjSoum.Size = New System.Drawing.Size(113, 19)
		Me.txtNoProjSoum.Location = New System.Drawing.Point(400, 32)
		Me.txtNoProjSoum.ReadOnly = True
		Me.txtNoProjSoum.TabIndex = 2
		Me.txtNoProjSoum.Visible = False
		Me.txtNoProjSoum.AcceptsReturn = True
		Me.txtNoProjSoum.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoProjSoum.BackColor = System.Drawing.SystemColors.Window
		Me.txtNoProjSoum.CausesValidation = True
		Me.txtNoProjSoum.Enabled = True
		Me.txtNoProjSoum.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNoProjSoum.HideSelection = True
		Me.txtNoProjSoum.Maxlength = 0
		Me.txtNoProjSoum.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNoProjSoum.MultiLine = False
		Me.txtNoProjSoum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNoProjSoum.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNoProjSoum.TabStop = True
		Me.txtNoProjSoum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoProjSoum.Name = "txtNoProjSoum"
		Me.cmbChoix.Size = New System.Drawing.Size(81, 21)
		Me.cmbChoix.Location = New System.Drawing.Point(216, 32)
		Me.cmbChoix.Items.AddRange(New Object(){"Soumission", "Projet"})
		Me.cmbChoix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbChoix.TabIndex = 0
		Me.cmbChoix.BackColor = System.Drawing.SystemColors.Window
		Me.cmbChoix.CausesValidation = True
		Me.cmbChoix.Enabled = True
		Me.cmbChoix.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbChoix.IntegralHeight = True
		Me.cmbChoix.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbChoix.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbChoix.Sorted = False
		Me.cmbChoix.TabStop = True
		Me.cmbChoix.Visible = True
		Me.cmbChoix.Name = "cmbChoix"
		Me.txtChoix.AutoSize = False
		Me.txtChoix.Size = New System.Drawing.Size(81, 19)
		Me.txtChoix.Location = New System.Drawing.Point(216, 32)
		Me.txtChoix.ReadOnly = True
		Me.txtChoix.TabIndex = 1
		Me.txtChoix.Text = "Text1"
		Me.txtChoix.AcceptsReturn = True
		Me.txtChoix.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtChoix.BackColor = System.Drawing.SystemColors.Window
		Me.txtChoix.CausesValidation = True
		Me.txtChoix.Enabled = True
		Me.txtChoix.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtChoix.HideSelection = True
		Me.txtChoix.Maxlength = 0
		Me.txtChoix.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtChoix.MultiLine = False
		Me.txtChoix.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtChoix.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtChoix.TabStop = True
		Me.txtChoix.Visible = True
		Me.txtChoix.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtChoix.Name = "txtChoix"
		Me.tmrTemps.Enabled = False
		Me.tmrTemps.Interval = 1000
		Me.cmdHistorique.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdHistorique.Text = "Historique des modifications"
		Me.cmdHistorique.Size = New System.Drawing.Size(97, 33)
		Me.cmdHistorique.Location = New System.Drawing.Point(8, 168)
		Me.cmdHistorique.TabIndex = 59
		Me.cmdHistorique.BackColor = System.Drawing.SystemColors.Control
		Me.cmdHistorique.CausesValidation = True
		Me.cmdHistorique.Enabled = True
		Me.cmdHistorique.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdHistorique.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdHistorique.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdHistorique.TabStop = True
		Me.cmdHistorique.Name = "cmdHistorique"
		Me.cmdLegende.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdLegende.Text = "Légende"
		Me.cmdLegende.Size = New System.Drawing.Size(57, 25)
		Me.cmdLegende.Location = New System.Drawing.Point(112, 168)
		Me.cmdLegende.TabIndex = 60
		Me.cmdLegende.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLegende.CausesValidation = True
		Me.cmdLegende.Enabled = True
		Me.cmdLegende.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLegende.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLegende.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLegende.TabStop = True
		Me.cmdLegende.Name = "cmdLegende"
		Me.cmdBavards.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBavards.Text = "Bavard"
		Me.cmdBavards.Size = New System.Drawing.Size(57, 25)
		Me.cmdBavards.Location = New System.Drawing.Point(176, 168)
		Me.cmdBavards.TabIndex = 61
		Me.cmdBavards.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBavards.CausesValidation = True
		Me.cmdBavards.Enabled = True
		Me.cmdBavards.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBavards.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBavards.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBavards.TabStop = True
		Me.cmdBavards.Name = "cmdBavards"
		Me.cmdAjouterSection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAjouterSection.Text = "..."
		Me.cmdAjouterSection.Size = New System.Drawing.Size(25, 21)
		Me.cmdAjouterSection.Location = New System.Drawing.Point(224, 200)
		Me.cmdAjouterSection.TabIndex = 69
		Me.cmdAjouterSection.Visible = False
		Me.cmdAjouterSection.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAjouterSection.CausesValidation = True
		Me.cmdAjouterSection.Enabled = True
		Me.cmdAjouterSection.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAjouterSection.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAjouterSection.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAjouterSection.TabStop = True
		Me.cmdAjouterSection.Name = "cmdAjouterSection"
		Me.cmbSections.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbSections.Size = New System.Drawing.Size(145, 21)
		Me.cmbSections.Location = New System.Drawing.Point(72, 200)
		Me.cmbSections.Items.AddRange(New Object(){"cmbSections"})
		Me.cmbSections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbSections.TabIndex = 67
		Me.cmbSections.Visible = False
		Me.cmbSections.BackColor = System.Drawing.SystemColors.Window
		Me.cmbSections.CausesValidation = True
		Me.cmbSections.Enabled = True
		Me.cmbSections.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbSections.IntegralHeight = True
		Me.cmbSections.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbSections.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbSections.Sorted = False
		Me.cmbSections.TabStop = True
		Me.cmbSections.Name = "cmbSections"
		Me.cmdDateFacturation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDateFacturation.Text = "..."
		Me.cmdDateFacturation.Size = New System.Drawing.Size(25, 21)
		Me.cmdDateFacturation.Location = New System.Drawing.Point(80, 176)
		Me.cmdDateFacturation.TabIndex = 64
		Me.cmdDateFacturation.Visible = False
		Me.cmdDateFacturation.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDateFacturation.CausesValidation = True
		Me.cmdDateFacturation.Enabled = True
		Me.cmdDateFacturation.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDateFacturation.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDateFacturation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDateFacturation.TabStop = True
		Me.cmdDateFacturation.Name = "cmdDateFacturation"
		Me.txtDateFacturation.AutoSize = False
		Me.txtDateFacturation.Size = New System.Drawing.Size(65, 20)
		Me.txtDateFacturation.Location = New System.Drawing.Point(8, 176)
		Me.txtDateFacturation.ReadOnly = True
		Me.txtDateFacturation.TabIndex = 63
		Me.txtDateFacturation.AcceptsReturn = True
		Me.txtDateFacturation.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDateFacturation.BackColor = System.Drawing.SystemColors.Window
		Me.txtDateFacturation.CausesValidation = True
		Me.txtDateFacturation.Enabled = True
		Me.txtDateFacturation.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDateFacturation.HideSelection = True
		Me.txtDateFacturation.Maxlength = 0
		Me.txtDateFacturation.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDateFacturation.MultiLine = False
		Me.txtDateFacturation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDateFacturation.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDateFacturation.TabStop = True
		Me.txtDateFacturation.Visible = True
		Me.txtDateFacturation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDateFacturation.Name = "txtDateFacturation"
		Me.cmdTemps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdTemps.Text = "Temps"
		Me.cmdTemps.Size = New System.Drawing.Size(57, 25)
		Me.cmdTemps.Location = New System.Drawing.Point(8, 104)
		Me.cmdTemps.TabIndex = 29
		Me.cmdTemps.BackColor = System.Drawing.SystemColors.Control
		Me.cmdTemps.CausesValidation = True
		Me.cmdTemps.Enabled = True
		Me.cmdTemps.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdTemps.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdTemps.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdTemps.TabStop = True
		Me.cmdTemps.Name = "cmdTemps"
		Me.txtForfait.AutoSize = False
		Me.txtForfait.Size = New System.Drawing.Size(65, 19)
		Me.txtForfait.Location = New System.Drawing.Point(112, 104)
		Me.txtForfait.ReadOnly = True
		Me.txtForfait.TabIndex = 31
		Me.txtForfait.AcceptsReturn = True
		Me.txtForfait.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtForfait.BackColor = System.Drawing.SystemColors.Window
		Me.txtForfait.CausesValidation = True
		Me.txtForfait.Enabled = True
		Me.txtForfait.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtForfait.HideSelection = True
		Me.txtForfait.Maxlength = 0
		Me.txtForfait.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtForfait.MultiLine = False
		Me.txtForfait.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtForfait.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtForfait.TabStop = True
		Me.txtForfait.Visible = True
		Me.txtForfait.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtForfait.Name = "txtForfait"
		Me.cmdForfait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdForfait.Text = "..."
		Me.cmdForfait.Size = New System.Drawing.Size(25, 19)
		Me.cmdForfait.Location = New System.Drawing.Point(112, 128)
		Me.cmdForfait.TabIndex = 56
		Me.ToolTip1.SetToolTip(Me.cmdForfait, "Ajoute un forfait")
		Me.cmdForfait.BackColor = System.Drawing.SystemColors.Control
		Me.cmdForfait.CausesValidation = True
		Me.cmdForfait.Enabled = True
		Me.cmdForfait.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdForfait.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdForfait.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdForfait.TabStop = True
		Me.cmdForfait.Name = "cmdForfait"
		Me.cmdEffacerForfait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEffacerForfait.Text = "Effacer"
		Me.cmdEffacerForfait.Size = New System.Drawing.Size(57, 19)
		Me.cmdEffacerForfait.Location = New System.Drawing.Point(144, 128)
		Me.cmdEffacerForfait.TabIndex = 57
		Me.ToolTip1.SetToolTip(Me.cmdEffacerForfait, "Efface le forfait")
		Me.cmdEffacerForfait.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEffacerForfait.CausesValidation = True
		Me.cmdEffacerForfait.Enabled = True
		Me.cmdEffacerForfait.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEffacerForfait.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEffacerForfait.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEffacerForfait.TabStop = True
		Me.cmdEffacerForfait.Name = "cmdEffacerForfait"
		Me.lvwPieces.Size = New System.Drawing.Size(777, 129)
		Me.lvwPieces.Location = New System.Drawing.Point(8, 224)
		Me.lvwPieces.TabIndex = 74
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
		Me.lvwSoumission.Size = New System.Drawing.Size(777, 281)
		Me.lvwSoumission.Location = New System.Drawing.Point(8, 224)
		Me.lvwSoumission.TabIndex = 75
		Me.lvwSoumission.View = System.Windows.Forms.View.Details
		Me.lvwSoumission.LabelEdit = False
		Me.lvwSoumission.MultiSelect = True
		Me.lvwSoumission.LabelWrap = True
		Me.lvwSoumission.HideSelection = True
		Me.lvwSoumission.Checkboxes = True
		Me.lvwSoumission.FullRowSelect = True
		Me.lvwSoumission.GridLines = True
		Me.lvwSoumission.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwSoumission.BackColor = System.Drawing.SystemColors.Window
		Me.lvwSoumission.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwSoumission.Name = "lvwSoumission"
		Me.cmdExport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExport.Text = "Exporter"
		Me.cmdExport.Size = New System.Drawing.Size(57, 25)
		Me.cmdExport.Location = New System.Drawing.Point(240, 168)
		Me.cmdExport.TabIndex = 62
		Me.cmdExport.Visible = False
		Me.cmdExport.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExport.CausesValidation = True
		Me.cmdExport.Enabled = True
		Me.cmdExport.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExport.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExport.TabStop = True
		Me.cmdExport.Name = "cmdExport"
		Me.cmdReception.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdReception.Text = "Réception"
		Me.cmdReception.Size = New System.Drawing.Size(65, 25)
		Me.cmdReception.Location = New System.Drawing.Point(216, 512)
		Me.cmdReception.TabIndex = 108
		Me.cmdReception.BackColor = System.Drawing.SystemColors.Control
		Me.cmdReception.CausesValidation = True
		Me.cmdReception.Enabled = True
		Me.cmdReception.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdReception.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdReception.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdReception.TabStop = True
		Me.cmdReception.Name = "cmdReception"
		Me.cmdRechercherClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRechercherClient.Text = "..."
		Me.cmdRechercherClient.Size = New System.Drawing.Size(25, 21)
		Me.cmdRechercherClient.Location = New System.Drawing.Point(584, 64)
		Me.cmdRechercherClient.TabIndex = 122
		Me.cmdRechercherClient.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercherClient.CausesValidation = True
		Me.cmdRechercherClient.Enabled = True
		Me.cmdRechercherClient.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercherClient.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercherClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercherClient.TabStop = True
		Me.cmdRechercherClient.Name = "cmdRechercherClient"
		Me.fraManuel.BackColor = System.Drawing.Color.Black
		Me.fraManuel.Text = "Manuels"
		Me.fraManuel.ForeColor = System.Drawing.Color.White
		Me.fraManuel.Size = New System.Drawing.Size(129, 41)
		Me.fraManuel.Location = New System.Drawing.Point(344, 144)
		Me.fraManuel.TabIndex = 135
		Me.fraManuel.Enabled = True
		Me.fraManuel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraManuel.Visible = True
		Me.fraManuel.Padding = New System.Windows.Forms.Padding(0)
		Me.fraManuel.Name = "fraManuel"
		Me.txtNbreManuel.AutoSize = False
		Me.txtNbreManuel.Size = New System.Drawing.Size(25, 20)
		Me.txtNbreManuel.Location = New System.Drawing.Point(32, 16)
		Me.txtNbreManuel.Maxlength = 4
		Me.txtNbreManuel.TabIndex = 137
		Me.txtNbreManuel.Text = "0"
		Me.txtNbreManuel.AcceptsReturn = True
		Me.txtNbreManuel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNbreManuel.BackColor = System.Drawing.SystemColors.Window
		Me.txtNbreManuel.CausesValidation = True
		Me.txtNbreManuel.Enabled = True
		Me.txtNbreManuel.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNbreManuel.HideSelection = True
		Me.txtNbreManuel.ReadOnly = False
		Me.txtNbreManuel.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNbreManuel.MultiLine = False
		Me.txtNbreManuel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNbreManuel.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNbreManuel.TabStop = True
		Me.txtNbreManuel.Visible = True
		Me.txtNbreManuel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNbreManuel.Name = "txtNbreManuel"
		Me.txtPrixManuel.AutoSize = False
		Me.txtPrixManuel.Size = New System.Drawing.Size(33, 20)
		Me.txtPrixManuel.Location = New System.Drawing.Point(88, 16)
		Me.txtPrixManuel.TabIndex = 136
		Me.txtPrixManuel.Text = "0"
		Me.txtPrixManuel.AcceptsReturn = True
		Me.txtPrixManuel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPrixManuel.BackColor = System.Drawing.SystemColors.Window
		Me.txtPrixManuel.CausesValidation = True
		Me.txtPrixManuel.Enabled = True
		Me.txtPrixManuel.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPrixManuel.HideSelection = True
		Me.txtPrixManuel.ReadOnly = False
		Me.txtPrixManuel.Maxlength = 0
		Me.txtPrixManuel.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPrixManuel.MultiLine = False
		Me.txtPrixManuel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPrixManuel.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPrixManuel.TabStop = True
		Me.txtPrixManuel.Visible = True
		Me.txtPrixManuel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPrixManuel.Name = "txtPrixManuel"
		Me.Label23.Text = "Nbre"
		Me.Label23.ForeColor = System.Drawing.Color.White
		Me.Label23.Size = New System.Drawing.Size(33, 17)
		Me.Label23.Location = New System.Drawing.Point(8, 16)
		Me.Label23.TabIndex = 139
		Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label23.BackColor = System.Drawing.Color.Transparent
		Me.Label23.Enabled = True
		Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label23.UseMnemonic = True
		Me.Label23.Visible = True
		Me.Label23.AutoSize = False
		Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label23.Name = "Label23"
		Me.Label22.Text = "Prix"
		Me.Label22.ForeColor = System.Drawing.Color.White
		Me.Label22.Size = New System.Drawing.Size(41, 17)
		Me.Label22.Location = New System.Drawing.Point(64, 16)
		Me.Label22.TabIndex = 138
		Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label22.BackColor = System.Drawing.Color.Transparent
		Me.Label22.Enabled = True
		Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label22.UseMnemonic = True
		Me.Label22.Visible = True
		Me.Label22.AutoSize = False
		Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label22.Name = "Label22"
		Me.lblForfaitInitiale.Text = "Par : "
		Me.lblForfaitInitiale.ForeColor = System.Drawing.Color.White
		Me.lblForfaitInitiale.Size = New System.Drawing.Size(41, 17)
		Me.lblForfaitInitiale.Location = New System.Drawing.Point(184, 104)
		Me.lblForfaitInitiale.TabIndex = 32
		Me.lblForfaitInitiale.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblForfaitInitiale.BackColor = System.Drawing.Color.Transparent
		Me.lblForfaitInitiale.Enabled = True
		Me.lblForfaitInitiale.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblForfaitInitiale.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblForfaitInitiale.UseMnemonic = True
		Me.lblForfaitInitiale.Visible = True
		Me.lblForfaitInitiale.AutoSize = False
		Me.lblForfaitInitiale.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblForfaitInitiale.Name = "lblForfaitInitiale"
		Me.Label3.Text = "Forfait :"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(41, 17)
		Me.Label3.Location = New System.Drawing.Point(72, 104)
		Me.Label3.TabIndex = 30
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
		Me.lblDateFacturation.Text = "Date facturation"
		Me.lblDateFacturation.ForeColor = System.Drawing.Color.White
		Me.lblDateFacturation.Size = New System.Drawing.Size(76, 13)
		Me.lblDateFacturation.Location = New System.Drawing.Point(8, 160)
		Me.lblDateFacturation.TabIndex = 58
		Me.lblDateFacturation.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDateFacturation.BackColor = System.Drawing.Color.Transparent
		Me.lblDateFacturation.Enabled = True
		Me.lblDateFacturation.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDateFacturation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDateFacturation.UseMnemonic = True
		Me.lblDateFacturation.Visible = True
		Me.lblDateFacturation.AutoSize = True
		Me.lblDateFacturation.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDateFacturation.Name = "lblDateFacturation"
		Me.lblPasTemps.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblPasTemps.Text = "Vérifier le temps"
		Me.lblPasTemps.ForeColor = System.Drawing.Color.Red
		Me.lblPasTemps.Size = New System.Drawing.Size(209, 25)
		Me.lblPasTemps.Location = New System.Drawing.Point(0, 48)
		Me.lblPasTemps.TabIndex = 9
		Me.lblPasTemps.Visible = False
		Me.lblPasTemps.BackColor = System.Drawing.Color.Transparent
		Me.lblPasTemps.Enabled = True
		Me.lblPasTemps.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPasTemps.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPasTemps.UseMnemonic = True
		Me.lblPasTemps.AutoSize = False
		Me.lblPasTemps.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPasTemps.Name = "lblPasTemps"
		Me.Label2.Text = "Photos : "
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(42, 13)
		Me.Label2.Location = New System.Drawing.Point(8, 76)
		Me.Label2.TabIndex = 26
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = True
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.lblNoSoumission.Text = "Soumission"
		Me.lblNoSoumission.ForeColor = System.Drawing.Color.White
		Me.lblNoSoumission.Size = New System.Drawing.Size(57, 17)
		Me.lblNoSoumission.Location = New System.Drawing.Point(520, 32)
		Me.lblNoSoumission.TabIndex = 4
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
		Me.Label6.BackColor = System.Drawing.Color.Transparent
		Me.Label6.Text = "Contact"
		Me.Label6.ForeColor = System.Drawing.Color.White
		Me.Label6.Size = New System.Drawing.Size(41, 17)
		Me.Label6.Location = New System.Drawing.Point(360, 88)
		Me.Label6.TabIndex = 12
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.Enabled = True
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = False
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.Label4.BackColor = System.Drawing.Color.Transparent
		Me.Label4.Text = "Client"
		Me.Label4.ForeColor = System.Drawing.Color.White
		Me.Label4.Size = New System.Drawing.Size(33, 17)
		Me.Label4.Location = New System.Drawing.Point(368, 64)
		Me.Label4.TabIndex = 7
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.Enabled = True
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.lblSections.Text = "Sections :"
		Me.lblSections.ForeColor = System.Drawing.Color.White
		Me.lblSections.Size = New System.Drawing.Size(73, 17)
		Me.lblSections.Location = New System.Drawing.Point(8, 200)
		Me.lblSections.TabIndex = 68
		Me.lblSections.Visible = False
		Me.lblSections.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblSections.BackColor = System.Drawing.Color.Transparent
		Me.lblSections.Enabled = True
		Me.lblSections.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblSections.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblSections.UseMnemonic = True
		Me.lblSections.AutoSize = False
		Me.lblSections.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblSections.Name = "lblSections"
		Me.lblPiece.Text = "Catégorie :"
		Me.lblPiece.ForeColor = System.Drawing.Color.White
		Me.lblPiece.Size = New System.Drawing.Size(65, 17)
		Me.lblPiece.Location = New System.Drawing.Point(256, 200)
		Me.lblPiece.TabIndex = 70
		Me.lblPiece.Visible = False
		Me.lblPiece.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPiece.BackColor = System.Drawing.Color.Transparent
		Me.lblPiece.Enabled = True
		Me.lblPiece.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPiece.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPiece.UseMnemonic = True
		Me.lblPiece.AutoSize = False
		Me.lblPiece.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPiece.Name = "lblPiece"
		Me.lblProjet.Text = "Description"
		Me.lblProjet.ForeColor = System.Drawing.Color.White
		Me.lblProjet.Size = New System.Drawing.Size(57, 17)
		Me.lblProjet.Location = New System.Drawing.Point(336, 112)
		Me.lblProjet.TabIndex = 10
		Me.lblProjet.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblProjet.BackColor = System.Drawing.Color.Transparent
		Me.lblProjet.Enabled = True
		Me.lblProjet.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblProjet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblProjet.UseMnemonic = True
		Me.lblProjet.Visible = True
		Me.lblProjet.AutoSize = False
		Me.lblProjet.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblProjet.Name = "lblProjet"
		Me.lblTri.Text = "Trier par :"
		Me.lblTri.ForeColor = System.Drawing.Color.White
		Me.lblTri.Size = New System.Drawing.Size(57, 17)
		Me.lblTri.Location = New System.Drawing.Point(432, 184)
		Me.lblTri.TabIndex = 65
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
		Me.Controls.Add(cmbOuvertFerme)
		Me.Controls.Add(fraFournisseur)
		Me.Controls.Add(fraPieceTrouve)
		Me.Controls.Add(lvwHistorique)
		Me.Controls.Add(lvwBavard)
		Me.Controls.Add(mvwDateFacturation)
		Me.Controls.Add(mvwDate)
		Me.Controls.Add(fraDateRequise)
		Me.Controls.Add(fraCommentaire)
		Me.Controls.Add(fraPrixPiece)
		Me.Controls.Add(cmdAnglaisFrancais)
		Me.Controls.Add(cmdReset)
		Me.Controls.Add(cmdRapportFACT)
		Me.Controls.Add(cmdTexte)
		Me.Controls.Add(cmdDemande)
		Me.Controls.Add(cmdSortieMagasin)
		Me.Controls.Add(cmdMauvaisPrix)
		Me.Controls.Add(cmdMaterielInutile)
		Me.Controls.Add(cmdCreerProjet)
		Me.Controls.Add(cmdCatalogue)
		Me.Controls.Add(cmdBonCommande)
		Me.Controls.Add(cmdRetour)
		Me.Controls.Add(cmdExtra)
		Me.Controls.Add(cmdCopier)
		Me.Controls.Add(cmdImprimer)
		Me.Controls.Add(cmdAjouter)
		Me.Controls.Add(cmdFermer)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(cmdEnregistrer)
		Me.Controls.Add(cmdModifier)
		Me.Controls.Add(cmdSupprimer)
		Me.Controls.Add(fraCertifDelais)
		Me.Controls.Add(fraFsTransMarq)
		Me.Controls.Add(cmdRafraichir)
		Me.Controls.Add(cmdTri)
		Me.Controls.Add(fraPrix)
		Me.Controls.Add(cmbTri)
		Me.Controls.Add(cmbPieces)
		Me.Controls.Add(txtCheminPhotos)
		Me.Controls.Add(cmdBrowse)
		Me.Controls.Add(cmdPhotos)
		Me.Controls.Add(txtProjet)
		Me.Controls.Add(cmbContact)
		Me.Controls.Add(txtContact)
		Me.Controls.Add(cmbClient)
		Me.Controls.Add(txtClient)
		Me.Controls.Add(txtNoSoumission)
		Me.Controls.Add(cmbProjSoum)
		Me.Controls.Add(txtNoProjSoum)
		Me.Controls.Add(cmbChoix)
		Me.Controls.Add(txtChoix)
		Me.Controls.Add(cmdHistorique)
		Me.Controls.Add(cmdLegende)
		Me.Controls.Add(cmdBavards)
		Me.Controls.Add(cmdAjouterSection)
		Me.Controls.Add(cmbSections)
		Me.Controls.Add(cmdDateFacturation)
		Me.Controls.Add(txtDateFacturation)
		Me.Controls.Add(cmdTemps)
		Me.Controls.Add(txtForfait)
		Me.Controls.Add(cmdForfait)
		Me.Controls.Add(cmdEffacerForfait)
		Me.Controls.Add(lvwPieces)
		Me.Controls.Add(lvwSoumission)
		Me.Controls.Add(cmdExport)
		Me.Controls.Add(cmdReception)
		Me.Controls.Add(cmdRechercherClient)
		Me.Controls.Add(fraManuel)
		Me.Controls.Add(lblForfaitInitiale)
		Me.Controls.Add(Label3)
		Me.Controls.Add(lblDateFacturation)
		Me.Controls.Add(lblPasTemps)
		Me.Controls.Add(Label2)
		Me.Controls.Add(lblNoSoumission)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label4)
		Me.Controls.Add(lblSections)
		Me.Controls.Add(lblPiece)
		Me.Controls.Add(lblProjet)
		Me.Controls.Add(lblTri)
		Me.fraFournisseur.Controls.Add(cmdOKFRS)
		Me.fraFournisseur.Controls.Add(cmdAnnulerFRS)
		Me.fraFournisseur.Controls.Add(cmdSupprimerFRS)
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
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_11)
		Me.fraPieceTrouve.Controls.Add(cmdAnnulerPieceTrouve)
		Me.fraPieceTrouve.Controls.Add(cmdOKPieceTrouve)
		Me.fraPieceTrouve.Controls.Add(lvwPieceTrouve)
		Me.lvwPieceTrouve.Columns.Add(_lvwPieceTrouve_ColumnHeader_1)
		Me.lvwPieceTrouve.Columns.Add(_lvwPieceTrouve_ColumnHeader_2)
		Me.lvwPieceTrouve.Columns.Add(_lvwPieceTrouve_ColumnHeader_3)
		Me.lvwPieceTrouve.Columns.Add(_lvwPieceTrouve_ColumnHeader_4)
		Me.lvwPieceTrouve.Columns.Add(_lvwPieceTrouve_ColumnHeader_5)
		Me.lvwPieceTrouve.Columns.Add(_lvwPieceTrouve_ColumnHeader_6)
		Me.lvwHistorique.Columns.Add(_lvwHistorique_ColumnHeader_1)
		Me.lvwHistorique.Columns.Add(_lvwHistorique_ColumnHeader_2)
		Me.lvwHistorique.Columns.Add(_lvwHistorique_ColumnHeader_3)
		Me.lvwHistorique.Columns.Add(_lvwHistorique_ColumnHeader_4)
		Me.lvwBavard.Columns.Add(_lvwBavard_ColumnHeader_1)
		Me.lvwBavard.Columns.Add(_lvwBavard_ColumnHeader_2)
		Me.lvwBavard.Columns.Add(_lvwBavard_ColumnHeader_3)
		Me.lvwBavard.Columns.Add(_lvwBavard_ColumnHeader_4)
		Me.lvwBavard.Columns.Add(_lvwBavard_ColumnHeader_5)
		Me.fraDateRequise.Controls.Add(cmdAnnulerDateRequise)
		Me.fraDateRequise.Controls.Add(cmdOKDateRequise)
		Me.fraDateRequise.Controls.Add(mvwDateRequise)
		Me.fraCommentaire.Controls.Add(txtCommentaire)
		Me.fraCommentaire.Controls.Add(cmdOKCommentaire)
		Me.fraCommentaire.Controls.Add(cmdAnnulerCommentaire)
		Me.fraPrixPiece.Controls.Add(txtPrixSpecial)
		Me.fraPrixPiece.Controls.Add(txtPrixList)
		Me.fraPrixPiece.Controls.Add(txtPrixNet)
		Me.fraPrixPiece.Controls.Add(cmbfrs)
		Me.fraPrixPiece.Controls.Add(optUSA)
		Me.fraPrixPiece.Controls.Add(optCAN)
		Me.fraPrixPiece.Controls.Add(optSpain)
		Me.fraPrixPiece.Controls.Add(cmdOKPrix)
		Me.fraPrixPiece.Controls.Add(cmdAnnulerPrix)
		Me.fraPrixPiece.Controls.Add(mskEscompte)
		Me.fraPrixPiece.Controls.Add(_Label1_0)
		Me.fraPrixPiece.Controls.Add(imgCanada)
		Me.fraPrixPiece.Controls.Add(_Label1_14)
		Me.fraPrixPiece.Controls.Add(_Label1_16)
		Me.fraPrixPiece.Controls.Add(_Label1_19)
		Me.fraPrixPiece.Controls.Add(_Label1_20)
		Me.fraPrixPiece.Controls.Add(imgSpain)
		Me.fraPrixPiece.Controls.Add(imgEU)
		Me.fraCertifDelais.Controls.Add(picApprob)
		Me.fraCertifDelais.Controls.Add(txtDelais)
		Me.fraCertifDelais.Controls.Add(cmdDate)
		Me.fraCertifDelais.Controls.Add(Label21)
		Me.picApprob.Controls.Add(chkUR)
		Me.picApprob.Controls.Add(chkCE)
		Me.picApprob.Controls.Add(chkCUR)
		Me.picApprob.Controls.Add(chkUL)
		Me.picApprob.Controls.Add(chkCUL)
		Me.picApprob.Controls.Add(chkCSA)
		Me.fraFsTransMarq.Controls.Add(txtPrixSoumission)
		Me.fraFsTransMarq.Controls.Add(cmbTransport)
		Me.fraFsTransMarq.Controls.Add(txtTransport)
		Me.fraFsTransMarq.Controls.Add(txtPrixReception)
		Me.fraFsTransMarq.Controls.Add(lblPrixSoumission)
		Me.fraFsTransMarq.Controls.Add(lblPrixReception)
		Me.fraFsTransMarq.Controls.Add(Label26)
		Me.fraPrix.Controls.Add(txtTotalTemps)
		Me.fraPrix.Controls.Add(txtTotalPieces)
		Me.fraPrix.Controls.Add(txtProfit)
		Me.fraPrix.Controls.Add(txtImprevus)
		Me.fraPrix.Controls.Add(txtCommission)
		Me.fraPrix.Controls.Add(txtPrixTotal)
		Me.fraPrix.Controls.Add(Label8)
		Me.fraPrix.Controls.Add(Label7)
		Me.fraPrix.Controls.Add(Label5)
		Me.fraPrix.Controls.Add(lblTotalPieces)
		Me.fraPrix.Controls.Add(lblImprevus)
		Me.fraPrix.Controls.Add(lblTotalTemps)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_1)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_2)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_3)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_4)
		Me.lvwPieces.Columns.Add(_lvwPieces_ColumnHeader_5)
		Me.fraManuel.Controls.Add(txtNbreManuel)
		Me.fraManuel.Controls.Add(txtPrixManuel)
		Me.fraManuel.Controls.Add(Label23)
		Me.fraManuel.Controls.Add(Label22)
		Me.Label1.SetIndex(_Label1_0, CType(0, Short))
		Me.Label1.SetIndex(_Label1_14, CType(14, Short))
		Me.Label1.SetIndex(_Label1_16, CType(16, Short))
		Me.Label1.SetIndex(_Label1_19, CType(19, Short))
		Me.Label1.SetIndex(_Label1_20, CType(20, Short))
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mvwDateRequise, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mvwDateFacturation, System.ComponentModel.ISupportInitialize).EndInit()
		MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuRightClick})
		mnuRightClick.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnuFacturer, Me.mnuNC, Me.mnuDateRequise, Me.mnuCommentaire, Me.mnuID, Me.mnuMauvaisPrix, Me.mnuInutile, Me.mnuTexte, Me.mnuChangerSS, Me.mnuFournisseur, Me.mnuAnnulerCommande, Me.mnuSupprimer, Me.mnuAjouterPrix, Me.mnuSortieMagasin, Me.mnuQuantite})
		Me.Controls.Add(MainMenu1)
		Me.MainMenu1.ResumeLayout(False)
		Me.fraFournisseur.ResumeLayout(False)
		Me.lvwFournisseur.ResumeLayout(False)
		Me.fraPieceTrouve.ResumeLayout(False)
		Me.lvwPieceTrouve.ResumeLayout(False)
		Me.lvwHistorique.ResumeLayout(False)
		Me.lvwBavard.ResumeLayout(False)
		Me.fraDateRequise.ResumeLayout(False)
		Me.fraCommentaire.ResumeLayout(False)
		Me.fraPrixPiece.ResumeLayout(False)
		Me.fraCertifDelais.ResumeLayout(False)
		Me.picApprob.ResumeLayout(False)
		Me.fraFsTransMarq.ResumeLayout(False)
		Me.fraPrix.ResumeLayout(False)
		Me.lvwPieces.ResumeLayout(False)
		Me.fraManuel.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class