<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPunch
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
	Public WithEvents cmdPunchMultiple As System.Windows.Forms.Button
	Public WithEvents _lvwJour_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwJour_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwJour_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwJour_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwJour_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwJour_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwJour_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwJour_ColumnHeader_8 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwJour As System.Windows.Forms.ListView
	Public WithEvents cmdPunchOut As System.Windows.Forms.Button
	Public WithEvents cmdModifierPunchOut As System.Windows.Forms.Button
	Public WithEvents cmdPunchIn As System.Windows.Forms.Button
	Public WithEvents cmdModifierPunchIn As System.Windows.Forms.Button
	Public WithEvents fraJour As System.Windows.Forms.Panel
	Public WithEvents cmbPMType As System.Windows.Forms.ComboBox
	Public WithEvents _optPMHeureDiner_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optPMHeureDiner_0 As System.Windows.Forms.RadioButton
	Public WithEvents cmdBrowseCommentPM As System.Windows.Forms.Button
	Public WithEvents cmdPMOK As System.Windows.Forms.Button
	Public WithEvents mskPMHeureFin As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskPMHeureDebut As System.Windows.Forms.MaskedTextBox
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents txtPMCommentaire As System.Windows.Forms.TextBox
	Public WithEvents cmdPMAnnuler As System.Windows.Forms.Button
	Public WithEvents txtPMClient As System.Windows.Forms.TextBox
	Public WithEvents chkPMDiner As System.Windows.Forms.CheckBox
	Public WithEvents _lvwEmployes_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwEmployes As System.Windows.Forms.ListView
	Public WithEvents mskPMNoProjet As System.Windows.Forms.MaskedTextBox
	Public WithEvents _optPMTypePunch_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optPMTypePunch_0 As System.Windows.Forms.RadioButton
	Public WithEvents picTypePunch As System.Windows.Forms.Panel
	Public WithEvents lblPMTypePunch As System.Windows.Forms.Label
	Public WithEvents lblPMType As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents lblPMPrefixe As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents fraPunchMultiple As System.Windows.Forms.GroupBox
	Public WithEvents cmbHeureSemaine As System.Windows.Forms.ComboBox
	Public WithEvents __lvwJourSemaine_1_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lvwJourSemaine_1_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwJourSemaine_1 As System.Windows.Forms.ListView
	Public WithEvents __lvwJourSemaine_2_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lvwJourSemaine_2_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwJourSemaine_2 As System.Windows.Forms.ListView
	Public WithEvents __lvwJourSemaine_3_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lvwJourSemaine_3_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwJourSemaine_3 As System.Windows.Forms.ListView
	Public WithEvents __lvwJourSemaine_4_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lvwJourSemaine_4_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwJourSemaine_4 As System.Windows.Forms.ListView
	Public WithEvents __lvwJourSemaine_5_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lvwJourSemaine_5_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwJourSemaine_5 As System.Windows.Forms.ListView
	Public WithEvents __lvwJourSemaine_6_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lvwJourSemaine_6_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwJourSemaine_6 As System.Windows.Forms.ListView
	Public WithEvents __lvwJourSemaine_7_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lvwJourSemaine_7_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwJourSemaine_7 As System.Windows.Forms.ListView
	Public WithEvents _lblNomJour_0 As System.Windows.Forms.Label
	Public WithEvents _lblNomJour_1 As System.Windows.Forms.Label
	Public WithEvents _lblNomJour_2 As System.Windows.Forms.Label
	Public WithEvents _lblNomJour_3 As System.Windows.Forms.Label
	Public WithEvents _lblNomJour_4 As System.Windows.Forms.Label
	Public WithEvents _lblNomJour_5 As System.Windows.Forms.Label
	Public WithEvents _lblNomJour_6 As System.Windows.Forms.Label
	Public WithEvents Line2 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line3 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line4 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line5 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line6 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents _lblJour_0 As System.Windows.Forms.Label
	Public WithEvents _lblJour_1 As System.Windows.Forms.Label
	Public WithEvents _lblJour_2 As System.Windows.Forms.Label
	Public WithEvents _lblJour_3 As System.Windows.Forms.Label
	Public WithEvents _lblJour_4 As System.Windows.Forms.Label
	Public WithEvents _lblJour_5 As System.Windows.Forms.Label
	Public WithEvents _lblJour_6 As System.Windows.Forms.Label
	Public WithEvents fraSemaine As System.Windows.Forms.GroupBox
	Public WithEvents mvwSelection As AxMSComCtl2.AxMonthView
	Public WithEvents cmbType As System.Windows.Forms.ComboBox
	Public WithEvents _optTypePunch_0 As System.Windows.Forms.RadioButton
	Public WithEvents _optTypePunch_1 As System.Windows.Forms.RadioButton
	Public WithEvents picPMTypePunch As System.Windows.Forms.Panel
	Public WithEvents _optHeureDiner_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optHeureDiner_0 As System.Windows.Forms.RadioButton
	Public WithEvents cmdBrowseComment As System.Windows.Forms.Button
	Public WithEvents chkDiner As System.Windows.Forms.CheckBox
	Public WithEvents txtKM As System.Windows.Forms.TextBox
	Public WithEvents chkKM As System.Windows.Forms.CheckBox
	Public WithEvents txtClient As System.Windows.Forms.TextBox
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents txtCommentaires As System.Windows.Forms.TextBox
	Public WithEvents mskHeure As System.Windows.Forms.MaskedTextBox
	Public WithEvents _optHeure_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optHeure_0 As System.Windows.Forms.RadioButton
	Public WithEvents fraHeure As System.Windows.Forms.GroupBox
	Public WithEvents cmbemployé As System.Windows.Forms.ComboBox
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents txtEmploye As System.Windows.Forms.TextBox
	Public WithEvents txtNoProjet As System.Windows.Forms.TextBox
	Public WithEvents mskNoProjet As System.Windows.Forms.MaskedTextBox
	Public WithEvents lblTypePunch As System.Windows.Forms.Label
	Public WithEvents lblType As System.Windows.Forms.Label
	Public WithEvents lblPrefixe As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents lblprojet As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents fraPunch As System.Windows.Forms.GroupBox
	Public WithEvents lblNbreHeure As System.Windows.Forms.Label
	Public WithEvents lblTitreHeure As System.Windows.Forms.Label
	Public WithEvents lblJour As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblNomJour As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lvwJourSemaine As Microsoft.VisualBasic.Compatibility.VB6.ListViewArray
	Public WithEvents optHeure As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	Public WithEvents optHeureDiner As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	Public WithEvents optPMHeureDiner As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	Public WithEvents optPMTypePunch As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	Public WithEvents optTypePunch As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPunch))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.fraJour = New System.Windows.Forms.Panel
		Me.cmdPunchMultiple = New System.Windows.Forms.Button
		Me.lvwJour = New System.Windows.Forms.ListView
		Me._lvwJour_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwJour_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwJour_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwJour_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwJour_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvwJour_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me._lvwJour_ColumnHeader_7 = New System.Windows.Forms.ColumnHeader
		Me._lvwJour_ColumnHeader_8 = New System.Windows.Forms.ColumnHeader
		Me.cmdPunchOut = New System.Windows.Forms.Button
		Me.cmdModifierPunchOut = New System.Windows.Forms.Button
		Me.cmdPunchIn = New System.Windows.Forms.Button
		Me.cmdModifierPunchIn = New System.Windows.Forms.Button
		Me.fraPunchMultiple = New System.Windows.Forms.GroupBox
		Me.cmbPMType = New System.Windows.Forms.ComboBox
		Me._optPMHeureDiner_1 = New System.Windows.Forms.RadioButton
		Me._optPMHeureDiner_0 = New System.Windows.Forms.RadioButton
		Me.cmdBrowseCommentPM = New System.Windows.Forms.Button
		Me.cmdPMOK = New System.Windows.Forms.Button
		Me.Frame2 = New System.Windows.Forms.GroupBox
		Me.mskPMHeureFin = New System.Windows.Forms.MaskedTextBox
		Me.mskPMHeureDebut = New System.Windows.Forms.MaskedTextBox
		Me.Label10 = New System.Windows.Forms.Label
		Me.Label8 = New System.Windows.Forms.Label
		Me.txtPMCommentaire = New System.Windows.Forms.TextBox
		Me.cmdPMAnnuler = New System.Windows.Forms.Button
		Me.txtPMClient = New System.Windows.Forms.TextBox
		Me.chkPMDiner = New System.Windows.Forms.CheckBox
		Me.lvwEmployes = New System.Windows.Forms.ListView
		Me._lvwEmployes_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.mskPMNoProjet = New System.Windows.Forms.MaskedTextBox
		Me.picTypePunch = New System.Windows.Forms.Panel
		Me._optPMTypePunch_1 = New System.Windows.Forms.RadioButton
		Me._optPMTypePunch_0 = New System.Windows.Forms.RadioButton
		Me.lblPMTypePunch = New System.Windows.Forms.Label
		Me.lblPMType = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.lblPMPrefixe = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.cmbHeureSemaine = New System.Windows.Forms.ComboBox
		Me.fraSemaine = New System.Windows.Forms.GroupBox
		Me._lvwJourSemaine_1 = New System.Windows.Forms.ListView
		Me.__lvwJourSemaine_1_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.__lvwJourSemaine_1_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwJourSemaine_2 = New System.Windows.Forms.ListView
		Me.__lvwJourSemaine_2_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.__lvwJourSemaine_2_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwJourSemaine_3 = New System.Windows.Forms.ListView
		Me.__lvwJourSemaine_3_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.__lvwJourSemaine_3_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwJourSemaine_4 = New System.Windows.Forms.ListView
		Me.__lvwJourSemaine_4_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.__lvwJourSemaine_4_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwJourSemaine_5 = New System.Windows.Forms.ListView
		Me.__lvwJourSemaine_5_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.__lvwJourSemaine_5_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwJourSemaine_6 = New System.Windows.Forms.ListView
		Me.__lvwJourSemaine_6_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.__lvwJourSemaine_6_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwJourSemaine_7 = New System.Windows.Forms.ListView
		Me.__lvwJourSemaine_7_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.__lvwJourSemaine_7_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lblNomJour_0 = New System.Windows.Forms.Label
		Me._lblNomJour_1 = New System.Windows.Forms.Label
		Me._lblNomJour_2 = New System.Windows.Forms.Label
		Me._lblNomJour_3 = New System.Windows.Forms.Label
		Me._lblNomJour_4 = New System.Windows.Forms.Label
		Me._lblNomJour_5 = New System.Windows.Forms.Label
		Me._lblNomJour_6 = New System.Windows.Forms.Label
		Me.Line2 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me.Line3 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me.Line4 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me.Line5 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me.Line6 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me.Line1 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me._lblJour_0 = New System.Windows.Forms.Label
		Me._lblJour_1 = New System.Windows.Forms.Label
		Me._lblJour_2 = New System.Windows.Forms.Label
		Me._lblJour_3 = New System.Windows.Forms.Label
		Me._lblJour_4 = New System.Windows.Forms.Label
		Me._lblJour_5 = New System.Windows.Forms.Label
		Me._lblJour_6 = New System.Windows.Forms.Label
		Me.mvwSelection = New AxMSComCtl2.AxMonthView
		Me.fraPunch = New System.Windows.Forms.GroupBox
		Me.cmbType = New System.Windows.Forms.ComboBox
		Me.picPMTypePunch = New System.Windows.Forms.Panel
		Me._optTypePunch_0 = New System.Windows.Forms.RadioButton
		Me._optTypePunch_1 = New System.Windows.Forms.RadioButton
		Me._optHeureDiner_1 = New System.Windows.Forms.RadioButton
		Me._optHeureDiner_0 = New System.Windows.Forms.RadioButton
		Me.cmdBrowseComment = New System.Windows.Forms.Button
		Me.chkDiner = New System.Windows.Forms.CheckBox
		Me.txtKM = New System.Windows.Forms.TextBox
		Me.chkKM = New System.Windows.Forms.CheckBox
		Me.txtClient = New System.Windows.Forms.TextBox
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.txtCommentaires = New System.Windows.Forms.TextBox
		Me.fraHeure = New System.Windows.Forms.GroupBox
		Me.mskHeure = New System.Windows.Forms.MaskedTextBox
		Me._optHeure_1 = New System.Windows.Forms.RadioButton
		Me._optHeure_0 = New System.Windows.Forms.RadioButton
		Me.cmbemployé = New System.Windows.Forms.ComboBox
		Me.cmdOK = New System.Windows.Forms.Button
		Me.txtEmploye = New System.Windows.Forms.TextBox
		Me.txtNoProjet = New System.Windows.Forms.TextBox
		Me.mskNoProjet = New System.Windows.Forms.MaskedTextBox
		Me.lblTypePunch = New System.Windows.Forms.Label
		Me.lblType = New System.Windows.Forms.Label
		Me.lblPrefixe = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.lblprojet = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.lblNbreHeure = New System.Windows.Forms.Label
		Me.lblTitreHeure = New System.Windows.Forms.Label
		Me.lblJour = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.lblNomJour = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.lvwJourSemaine = New Microsoft.VisualBasic.Compatibility.VB6.ListViewArray(components)
		Me.optHeure = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.optHeureDiner = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.optPMHeureDiner = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.optPMTypePunch = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.optTypePunch = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.fraJour.SuspendLayout()
		Me.lvwJour.SuspendLayout()
		Me.fraPunchMultiple.SuspendLayout()
		Me.Frame2.SuspendLayout()
		Me.lvwEmployes.SuspendLayout()
		Me.picTypePunch.SuspendLayout()
		Me.fraSemaine.SuspendLayout()
		Me._lvwJourSemaine_1.SuspendLayout()
		Me._lvwJourSemaine_2.SuspendLayout()
		Me._lvwJourSemaine_3.SuspendLayout()
		Me._lvwJourSemaine_4.SuspendLayout()
		Me._lvwJourSemaine_5.SuspendLayout()
		Me._lvwJourSemaine_6.SuspendLayout()
		Me._lvwJourSemaine_7.SuspendLayout()
		Me.fraPunch.SuspendLayout()
		Me.picPMTypePunch.SuspendLayout()
		Me.fraHeure.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.mvwSelection, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.lblJour, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.lblNomJour, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optHeure, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optHeureDiner, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optPMHeureDiner, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optPMTypePunch, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optTypePunch, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Punch"
		Me.ClientSize = New System.Drawing.Size(932, 584)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmPunch.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "frmPunch"
		Me.fraJour.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.fraJour.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.fraJour.Size = New System.Drawing.Size(609, 353)
		Me.fraJour.Location = New System.Drawing.Point(320, 40)
		Me.fraJour.TabIndex = 0
		Me.fraJour.Enabled = True
		Me.fraJour.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraJour.Cursor = System.Windows.Forms.Cursors.Default
		Me.fraJour.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraJour.Visible = True
		Me.fraJour.Name = "fraJour"
		Me.cmdPunchMultiple.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPunchMultiple.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPunchMultiple.Text = "Punch multiple"
		Me.cmdPunchMultiple.Size = New System.Drawing.Size(81, 25)
		Me.cmdPunchMultiple.Location = New System.Drawing.Point(120, 320)
		Me.cmdPunchMultiple.TabIndex = 53
		Me.cmdPunchMultiple.CausesValidation = True
		Me.cmdPunchMultiple.Enabled = True
		Me.cmdPunchMultiple.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPunchMultiple.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPunchMultiple.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPunchMultiple.TabStop = True
		Me.cmdPunchMultiple.Name = "cmdPunchMultiple"
		Me.lvwJour.Size = New System.Drawing.Size(609, 313)
		Me.lvwJour.Location = New System.Drawing.Point(0, 0)
		Me.lvwJour.TabIndex = 1
		Me.lvwJour.View = System.Windows.Forms.View.Details
		Me.lvwJour.LabelEdit = False
		Me.lvwJour.LabelWrap = True
		Me.lvwJour.HideSelection = True
		Me.lvwJour.FullRowSelect = True
		Me.lvwJour.GridLines = True
		Me.lvwJour.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwJour.BackColor = System.Drawing.Color.White
		Me.lvwJour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwJour.Name = "lvwJour"
		Me._lvwJour_ColumnHeader_1.Text = "Nom"
		Me._lvwJour_ColumnHeader_1.Width = 62
		Me._lvwJour_ColumnHeader_2.Text = "Projet"
		Me._lvwJour_ColumnHeader_2.Width = 106
		Me._lvwJour_ColumnHeader_3.Text = "Début"
		Me._lvwJour_ColumnHeader_3.Width = 71
		Me._lvwJour_ColumnHeader_4.Text = "Fin"
		Me._lvwJour_ColumnHeader_4.Width = 71
		Me._lvwJour_ColumnHeader_5.Text = "Client"
		Me._lvwJour_ColumnHeader_5.Width = 260
		Me._lvwJour_ColumnHeader_6.Text = "Type"
		Me._lvwJour_ColumnHeader_6.Width = 170
		Me._lvwJour_ColumnHeader_7.Text = "Commentaire"
		Me._lvwJour_ColumnHeader_7.Width = 184
		Me._lvwJour_ColumnHeader_8.Text = "KM"
		Me._lvwJour_ColumnHeader_8.Width = 170
		Me.cmdPunchOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPunchOut.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPunchOut.Text = "Punch out"
		Me.cmdPunchOut.Size = New System.Drawing.Size(65, 25)
		Me.cmdPunchOut.Location = New System.Drawing.Point(488, 320)
		Me.cmdPunchOut.TabIndex = 5
		Me.cmdPunchOut.CausesValidation = True
		Me.cmdPunchOut.Enabled = True
		Me.cmdPunchOut.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPunchOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPunchOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPunchOut.TabStop = True
		Me.cmdPunchOut.Name = "cmdPunchOut"
		Me.cmdModifierPunchOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdModifierPunchOut.BackColor = System.Drawing.SystemColors.Control
		Me.cmdModifierPunchOut.Text = "Modifier punch out"
		Me.cmdModifierPunchOut.Size = New System.Drawing.Size(105, 25)
		Me.cmdModifierPunchOut.Location = New System.Drawing.Point(312, 320)
		Me.cmdModifierPunchOut.TabIndex = 3
		Me.cmdModifierPunchOut.CausesValidation = True
		Me.cmdModifierPunchOut.Enabled = True
		Me.cmdModifierPunchOut.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdModifierPunchOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdModifierPunchOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdModifierPunchOut.TabStop = True
		Me.cmdModifierPunchOut.Name = "cmdModifierPunchOut"
		Me.cmdPunchIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPunchIn.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPunchIn.Text = "Punch in"
		Me.cmdPunchIn.Size = New System.Drawing.Size(57, 25)
		Me.cmdPunchIn.Location = New System.Drawing.Point(424, 320)
		Me.cmdPunchIn.TabIndex = 4
		Me.cmdPunchIn.CausesValidation = True
		Me.cmdPunchIn.Enabled = True
		Me.cmdPunchIn.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPunchIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPunchIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPunchIn.TabStop = True
		Me.cmdPunchIn.Name = "cmdPunchIn"
		Me.cmdModifierPunchIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdModifierPunchIn.BackColor = System.Drawing.SystemColors.Control
		Me.cmdModifierPunchIn.Text = "Modifier punch in"
		Me.cmdModifierPunchIn.Size = New System.Drawing.Size(97, 25)
		Me.cmdModifierPunchIn.Location = New System.Drawing.Point(208, 320)
		Me.cmdModifierPunchIn.TabIndex = 2
		Me.cmdModifierPunchIn.CausesValidation = True
		Me.cmdModifierPunchIn.Enabled = True
		Me.cmdModifierPunchIn.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdModifierPunchIn.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdModifierPunchIn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdModifierPunchIn.TabStop = True
		Me.cmdModifierPunchIn.Name = "cmdModifierPunchIn"
		Me.fraPunchMultiple.Size = New System.Drawing.Size(561, 353)
		Me.fraPunchMultiple.Location = New System.Drawing.Point(320, 40)
		Me.fraPunchMultiple.TabIndex = 54
		Me.fraPunchMultiple.Visible = False
		Me.fraPunchMultiple.BackColor = System.Drawing.SystemColors.Control
		Me.fraPunchMultiple.Enabled = True
		Me.fraPunchMultiple.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraPunchMultiple.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraPunchMultiple.Padding = New System.Windows.Forms.Padding(0)
		Me.fraPunchMultiple.Name = "fraPunchMultiple"
		Me.cmbPMType.Size = New System.Drawing.Size(361, 21)
		Me.cmbPMType.Location = New System.Drawing.Point(184, 216)
		Me.cmbPMType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbPMType.TabIndex = 85
		Me.cmbPMType.BackColor = System.Drawing.SystemColors.Window
		Me.cmbPMType.CausesValidation = True
		Me.cmbPMType.Enabled = True
		Me.cmbPMType.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbPMType.IntegralHeight = True
		Me.cmbPMType.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbPMType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbPMType.Sorted = False
		Me.cmbPMType.TabStop = True
		Me.cmbPMType.Visible = True
		Me.cmbPMType.Name = "cmbPMType"
		Me._optPMHeureDiner_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optPMHeureDiner_1.Text = "1 heure"
		Me._optPMHeureDiner_1.Enabled = False
		Me._optPMHeureDiner_1.Size = New System.Drawing.Size(81, 13)
		Me._optPMHeureDiner_1.Location = New System.Drawing.Point(384, 296)
		Me._optPMHeureDiner_1.TabIndex = 75
		Me._optPMHeureDiner_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optPMHeureDiner_1.BackColor = System.Drawing.SystemColors.Control
		Me._optPMHeureDiner_1.CausesValidation = True
		Me._optPMHeureDiner_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optPMHeureDiner_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optPMHeureDiner_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optPMHeureDiner_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optPMHeureDiner_1.TabStop = True
		Me._optPMHeureDiner_1.Checked = False
		Me._optPMHeureDiner_1.Visible = True
		Me._optPMHeureDiner_1.Name = "_optPMHeureDiner_1"
		Me._optPMHeureDiner_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optPMHeureDiner_0.Text = "30 minutes"
		Me._optPMHeureDiner_0.Enabled = False
		Me._optPMHeureDiner_0.Size = New System.Drawing.Size(81, 13)
		Me._optPMHeureDiner_0.Location = New System.Drawing.Point(384, 280)
		Me._optPMHeureDiner_0.TabIndex = 74
		Me._optPMHeureDiner_0.Checked = True
		Me._optPMHeureDiner_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optPMHeureDiner_0.BackColor = System.Drawing.SystemColors.Control
		Me._optPMHeureDiner_0.CausesValidation = True
		Me._optPMHeureDiner_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optPMHeureDiner_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optPMHeureDiner_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optPMHeureDiner_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optPMHeureDiner_0.TabStop = True
		Me._optPMHeureDiner_0.Visible = True
		Me._optPMHeureDiner_0.Name = "_optPMHeureDiner_0"
		Me.cmdBrowseCommentPM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBrowseCommentPM.Text = "Choisir un commentaire"
		Me.cmdBrowseCommentPM.Size = New System.Drawing.Size(129, 25)
		Me.cmdBrowseCommentPM.Location = New System.Drawing.Point(216, 256)
		Me.cmdBrowseCommentPM.TabIndex = 70
		Me.cmdBrowseCommentPM.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBrowseCommentPM.CausesValidation = True
		Me.cmdBrowseCommentPM.Enabled = True
		Me.cmdBrowseCommentPM.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBrowseCommentPM.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBrowseCommentPM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBrowseCommentPM.TabStop = True
		Me.cmdBrowseCommentPM.Name = "cmdBrowseCommentPM"
		Me.cmdPMOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPMOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPMOK.Text = "OK"
		Me.cmdPMOK.Size = New System.Drawing.Size(73, 25)
		Me.cmdPMOK.Location = New System.Drawing.Point(480, 320)
		Me.cmdPMOK.TabIndex = 61
		Me.cmdPMOK.CausesValidation = True
		Me.cmdPMOK.Enabled = True
		Me.cmdPMOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPMOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPMOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPMOK.TabStop = True
		Me.cmdPMOK.Name = "cmdPMOK"
		Me.Frame2.Text = "Heure"
		Me.Frame2.Size = New System.Drawing.Size(137, 65)
		Me.Frame2.Location = New System.Drawing.Point(16, 160)
		Me.Frame2.TabIndex = 59
		Me.Frame2.BackColor = System.Drawing.SystemColors.Control
		Me.Frame2.Enabled = True
		Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame2.Visible = True
		Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame2.Name = "Frame2"
		Me.mskPMHeureFin.AllowPromptAsInput = False
		Me.mskPMHeureFin.Size = New System.Drawing.Size(65, 17)
		Me.mskPMHeureFin.Location = New System.Drawing.Point(56, 40)
		Me.mskPMHeureFin.TabIndex = 60
		Me.mskPMHeureFin.PromptChar = "_"
		Me.mskPMHeureFin.Name = "mskPMHeureFin"
		Me.mskPMHeureDebut.AllowPromptAsInput = False
		Me.mskPMHeureDebut.Size = New System.Drawing.Size(65, 17)
		Me.mskPMHeureDebut.Location = New System.Drawing.Point(56, 16)
		Me.mskPMHeureDebut.TabIndex = 66
		Me.mskPMHeureDebut.PromptChar = "_"
		Me.mskPMHeureDebut.Name = "mskPMHeureDebut"
		Me.Label10.Text = "Fin :"
		Me.Label10.ForeColor = System.Drawing.Color.Black
		Me.Label10.Size = New System.Drawing.Size(49, 17)
		Me.Label10.Location = New System.Drawing.Point(8, 40)
		Me.Label10.TabIndex = 68
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label10.BackColor = System.Drawing.SystemColors.Control
		Me.Label10.Enabled = True
		Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label10.UseMnemonic = True
		Me.Label10.Visible = True
		Me.Label10.AutoSize = False
		Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label10.Name = "Label10"
		Me.Label8.Text = "Début :"
		Me.Label8.ForeColor = System.Drawing.Color.Black
		Me.Label8.Size = New System.Drawing.Size(49, 17)
		Me.Label8.Location = New System.Drawing.Point(8, 16)
		Me.Label8.TabIndex = 67
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label8.BackColor = System.Drawing.SystemColors.Control
		Me.Label8.Enabled = True
		Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label8.UseMnemonic = True
		Me.Label8.Visible = True
		Me.Label8.AutoSize = False
		Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label8.Name = "Label8"
		Me.txtPMCommentaire.AutoSize = False
		Me.txtPMCommentaire.Size = New System.Drawing.Size(337, 57)
		Me.txtPMCommentaire.Location = New System.Drawing.Point(8, 288)
		Me.txtPMCommentaire.MultiLine = True
		Me.txtPMCommentaire.TabIndex = 58
		Me.txtPMCommentaire.AcceptsReturn = True
		Me.txtPMCommentaire.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPMCommentaire.BackColor = System.Drawing.SystemColors.Window
		Me.txtPMCommentaire.CausesValidation = True
		Me.txtPMCommentaire.Enabled = True
		Me.txtPMCommentaire.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPMCommentaire.HideSelection = True
		Me.txtPMCommentaire.ReadOnly = False
		Me.txtPMCommentaire.Maxlength = 0
		Me.txtPMCommentaire.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPMCommentaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPMCommentaire.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPMCommentaire.TabStop = True
		Me.txtPMCommentaire.Visible = True
		Me.txtPMCommentaire.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPMCommentaire.Name = "txtPMCommentaire"
		Me.cmdPMAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPMAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPMAnnuler.Text = "Annuler"
		Me.cmdPMAnnuler.Size = New System.Drawing.Size(73, 25)
		Me.cmdPMAnnuler.Location = New System.Drawing.Point(400, 320)
		Me.cmdPMAnnuler.TabIndex = 57
		Me.cmdPMAnnuler.CausesValidation = True
		Me.cmdPMAnnuler.Enabled = True
		Me.cmdPMAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPMAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPMAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPMAnnuler.TabStop = True
		Me.cmdPMAnnuler.Name = "cmdPMAnnuler"
		Me.txtPMClient.AutoSize = False
		Me.txtPMClient.Size = New System.Drawing.Size(361, 19)
		Me.txtPMClient.Location = New System.Drawing.Point(184, 176)
		Me.txtPMClient.ReadOnly = True
		Me.txtPMClient.TabIndex = 56
		Me.txtPMClient.AcceptsReturn = True
		Me.txtPMClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPMClient.BackColor = System.Drawing.SystemColors.Window
		Me.txtPMClient.CausesValidation = True
		Me.txtPMClient.Enabled = True
		Me.txtPMClient.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPMClient.HideSelection = True
		Me.txtPMClient.Maxlength = 0
		Me.txtPMClient.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPMClient.MultiLine = False
		Me.txtPMClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPMClient.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPMClient.TabStop = True
		Me.txtPMClient.Visible = True
		Me.txtPMClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPMClient.Name = "txtPMClient"
		Me.chkPMDiner.Text = "Heure de dîner"
		Me.chkPMDiner.Size = New System.Drawing.Size(97, 17)
		Me.chkPMDiner.Location = New System.Drawing.Point(352, 256)
		Me.chkPMDiner.TabIndex = 55
		Me.chkPMDiner.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkPMDiner.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkPMDiner.BackColor = System.Drawing.SystemColors.Control
		Me.chkPMDiner.CausesValidation = True
		Me.chkPMDiner.Enabled = True
		Me.chkPMDiner.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkPMDiner.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkPMDiner.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkPMDiner.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkPMDiner.TabStop = True
		Me.chkPMDiner.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkPMDiner.Visible = True
		Me.chkPMDiner.Name = "chkPMDiner"
		Me.lvwEmployes.Size = New System.Drawing.Size(561, 105)
		Me.lvwEmployes.Location = New System.Drawing.Point(0, 0)
		Me.lvwEmployes.TabIndex = 65
		Me.lvwEmployes.View = System.Windows.Forms.View.Details
		Me.lvwEmployes.LabelEdit = False
		Me.lvwEmployes.LabelWrap = True
		Me.lvwEmployes.HideSelection = True
		Me.lvwEmployes.Checkboxes = True
		Me.lvwEmployes.FullRowSelect = True
		Me.lvwEmployes.GridLines = True
		Me.lvwEmployes.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwEmployes.BackColor = System.Drawing.SystemColors.Window
		Me.lvwEmployes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwEmployes.Name = "lvwEmployes"
		Me._lvwEmployes_ColumnHeader_1.Text = "Employé"
		Me._lvwEmployes_ColumnHeader_1.Width = 741
		Me.mskPMNoProjet.AllowPromptAsInput = False
		Me.mskPMNoProjet.Size = New System.Drawing.Size(65, 17)
		Me.mskPMNoProjet.Location = New System.Drawing.Point(88, 120)
		Me.mskPMNoProjet.TabIndex = 69
		Me.mskPMNoProjet.MaxLength = 8
		Me.mskPMNoProjet.Mask = "#####-##"
		Me.mskPMNoProjet.PromptChar = "_"
		Me.mskPMNoProjet.Name = "mskPMNoProjet"
		Me.picTypePunch.Size = New System.Drawing.Size(89, 49)
		Me.picTypePunch.Location = New System.Drawing.Point(176, 112)
		Me.picTypePunch.TabIndex = 76
		Me.picTypePunch.Dock = System.Windows.Forms.DockStyle.None
		Me.picTypePunch.BackColor = System.Drawing.SystemColors.Control
		Me.picTypePunch.CausesValidation = True
		Me.picTypePunch.Enabled = True
		Me.picTypePunch.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picTypePunch.Cursor = System.Windows.Forms.Cursors.Default
		Me.picTypePunch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picTypePunch.TabStop = True
		Me.picTypePunch.Visible = True
		Me.picTypePunch.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picTypePunch.Name = "picTypePunch"
		Me._optPMTypePunch_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optPMTypePunch_1.Text = "Mécanique"
		Me._optPMTypePunch_1.Size = New System.Drawing.Size(73, 17)
		Me._optPMTypePunch_1.Location = New System.Drawing.Point(8, 20)
		Me._optPMTypePunch_1.TabIndex = 78
		Me._optPMTypePunch_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optPMTypePunch_1.BackColor = System.Drawing.SystemColors.Control
		Me._optPMTypePunch_1.CausesValidation = True
		Me._optPMTypePunch_1.Enabled = True
		Me._optPMTypePunch_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optPMTypePunch_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optPMTypePunch_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optPMTypePunch_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optPMTypePunch_1.TabStop = True
		Me._optPMTypePunch_1.Checked = False
		Me._optPMTypePunch_1.Visible = True
		Me._optPMTypePunch_1.Name = "_optPMTypePunch_1"
		Me._optPMTypePunch_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optPMTypePunch_0.Text = "Électrique"
		Me._optPMTypePunch_0.Size = New System.Drawing.Size(73, 17)
		Me._optPMTypePunch_0.Location = New System.Drawing.Point(8, 0)
		Me._optPMTypePunch_0.TabIndex = 77
		Me._optPMTypePunch_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optPMTypePunch_0.BackColor = System.Drawing.SystemColors.Control
		Me._optPMTypePunch_0.CausesValidation = True
		Me._optPMTypePunch_0.Enabled = True
		Me._optPMTypePunch_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optPMTypePunch_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optPMTypePunch_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optPMTypePunch_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optPMTypePunch_0.TabStop = True
		Me._optPMTypePunch_0.Checked = False
		Me._optPMTypePunch_0.Visible = True
		Me._optPMTypePunch_0.Name = "_optPMTypePunch_0"
		Me.lblPMTypePunch.ForeColor = System.Drawing.Color.Black
		Me.lblPMTypePunch.Size = New System.Drawing.Size(257, 17)
		Me.lblPMTypePunch.Location = New System.Drawing.Point(288, 112)
		Me.lblPMTypePunch.TabIndex = 88
		Me.lblPMTypePunch.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPMTypePunch.BackColor = System.Drawing.SystemColors.Control
		Me.lblPMTypePunch.Enabled = True
		Me.lblPMTypePunch.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPMTypePunch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPMTypePunch.UseMnemonic = True
		Me.lblPMTypePunch.Visible = True
		Me.lblPMTypePunch.AutoSize = False
		Me.lblPMTypePunch.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPMTypePunch.Name = "lblPMTypePunch"
		Me.lblPMType.Text = "Type"
		Me.lblPMType.ForeColor = System.Drawing.Color.Black
		Me.lblPMType.Size = New System.Drawing.Size(25, 17)
		Me.lblPMType.Location = New System.Drawing.Point(184, 200)
		Me.lblPMType.TabIndex = 84
		Me.lblPMType.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPMType.BackColor = System.Drawing.SystemColors.Control
		Me.lblPMType.Enabled = True
		Me.lblPMType.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPMType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPMType.UseMnemonic = True
		Me.lblPMType.Visible = True
		Me.lblPMType.AutoSize = False
		Me.lblPMType.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPMType.Name = "lblPMType"
		Me.Label9.Text = "Client"
		Me.Label9.ForeColor = System.Drawing.Color.Black
		Me.Label9.Size = New System.Drawing.Size(33, 17)
		Me.Label9.Location = New System.Drawing.Point(184, 160)
		Me.Label9.TabIndex = 64
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label9.BackColor = System.Drawing.SystemColors.Control
		Me.Label9.Enabled = True
		Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label9.UseMnemonic = True
		Me.Label9.Visible = True
		Me.Label9.AutoSize = False
		Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label9.Name = "Label9"
		Me.lblPMPrefixe.Size = New System.Drawing.Size(17, 17)
		Me.lblPMPrefixe.Location = New System.Drawing.Point(72, 120)
		Me.lblPMPrefixe.TabIndex = 82
		Me.lblPMPrefixe.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPMPrefixe.BackColor = System.Drawing.SystemColors.Control
		Me.lblPMPrefixe.Enabled = True
		Me.lblPMPrefixe.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPMPrefixe.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPMPrefixe.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPMPrefixe.UseMnemonic = True
		Me.lblPMPrefixe.Visible = True
		Me.lblPMPrefixe.AutoSize = False
		Me.lblPMPrefixe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblPMPrefixe.Name = "lblPMPrefixe"
		Me.Label7.Text = "No. Projet"
		Me.Label7.ForeColor = System.Drawing.Color.Black
		Me.Label7.Size = New System.Drawing.Size(49, 17)
		Me.Label7.Location = New System.Drawing.Point(16, 120)
		Me.Label7.TabIndex = 63
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label7.BackColor = System.Drawing.SystemColors.Control
		Me.Label7.Enabled = True
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = False
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Label6.Text = "Commentaires"
		Me.Label6.Size = New System.Drawing.Size(73, 17)
		Me.Label6.Location = New System.Drawing.Point(8, 272)
		Me.Label6.TabIndex = 62
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.BackColor = System.Drawing.SystemColors.Control
		Me.Label6.Enabled = True
		Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = False
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.cmbHeureSemaine.Size = New System.Drawing.Size(169, 21)
		Me.cmbHeureSemaine.Location = New System.Drawing.Point(576, 16)
		Me.cmbHeureSemaine.TabIndex = 51
		Me.cmbHeureSemaine.Text = "Combo1"
		Me.cmbHeureSemaine.BackColor = System.Drawing.SystemColors.Window
		Me.cmbHeureSemaine.CausesValidation = True
		Me.cmbHeureSemaine.Enabled = True
		Me.cmbHeureSemaine.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbHeureSemaine.IntegralHeight = True
		Me.cmbHeureSemaine.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbHeureSemaine.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbHeureSemaine.Sorted = False
		Me.cmbHeureSemaine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbHeureSemaine.TabStop = True
		Me.cmbHeureSemaine.Visible = True
		Me.cmbHeureSemaine.Name = "cmbHeureSemaine"
		Me.fraSemaine.BackColor = System.Drawing.Color.FromARGB(64, 64, 64)
		Me.fraSemaine.Size = New System.Drawing.Size(866, 177)
		Me.fraSemaine.Location = New System.Drawing.Point(8, 400)
		Me.fraSemaine.TabIndex = 28
		Me.fraSemaine.Enabled = True
		Me.fraSemaine.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraSemaine.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraSemaine.Visible = True
		Me.fraSemaine.Padding = New System.Windows.Forms.Padding(0)
		Me.fraSemaine.Name = "fraSemaine"
		Me._lvwJourSemaine_1.Size = New System.Drawing.Size(124, 127)
		Me._lvwJourSemaine_1.Location = New System.Drawing.Point(0, 48)
		Me._lvwJourSemaine_1.TabIndex = 43
		Me._lvwJourSemaine_1.View = System.Windows.Forms.View.Details
		Me._lvwJourSemaine_1.LabelEdit = False
		Me._lvwJourSemaine_1.LabelWrap = True
		Me._lvwJourSemaine_1.HideSelection = True
		Me._lvwJourSemaine_1.FullRowSelect = True
		Me._lvwJourSemaine_1.GridLines = True
		Me._lvwJourSemaine_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lvwJourSemaine_1.BackColor = System.Drawing.Color.White
		Me._lvwJourSemaine_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lvwJourSemaine_1.Name = "_lvwJourSemaine_1"
		Me.__lvwJourSemaine_1_ColumnHeader_1.Text = "nom"
		Me.__lvwJourSemaine_1_ColumnHeader_1.Width = 53
		Me.__lvwJourSemaine_1_ColumnHeader_2.Text = "heure"
		Me.__lvwJourSemaine_1_ColumnHeader_2.Width = 119
		Me._lvwJourSemaine_2.Size = New System.Drawing.Size(124, 127)
		Me._lvwJourSemaine_2.Location = New System.Drawing.Point(124, 48)
		Me._lvwJourSemaine_2.TabIndex = 44
		Me._lvwJourSemaine_2.View = System.Windows.Forms.View.Details
		Me._lvwJourSemaine_2.LabelEdit = False
		Me._lvwJourSemaine_2.LabelWrap = True
		Me._lvwJourSemaine_2.HideSelection = True
		Me._lvwJourSemaine_2.FullRowSelect = True
		Me._lvwJourSemaine_2.GridLines = True
		Me._lvwJourSemaine_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lvwJourSemaine_2.BackColor = System.Drawing.Color.White
		Me._lvwJourSemaine_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lvwJourSemaine_2.Name = "_lvwJourSemaine_2"
		Me.__lvwJourSemaine_2_ColumnHeader_1.Text = "nom"
		Me.__lvwJourSemaine_2_ColumnHeader_1.Width = 53
		Me.__lvwJourSemaine_2_ColumnHeader_2.Text = "heure"
		Me.__lvwJourSemaine_2_ColumnHeader_2.Width = 119
		Me._lvwJourSemaine_3.Size = New System.Drawing.Size(124, 127)
		Me._lvwJourSemaine_3.Location = New System.Drawing.Point(248, 48)
		Me._lvwJourSemaine_3.TabIndex = 45
		Me._lvwJourSemaine_3.View = System.Windows.Forms.View.Details
		Me._lvwJourSemaine_3.LabelEdit = False
		Me._lvwJourSemaine_3.LabelWrap = True
		Me._lvwJourSemaine_3.HideSelection = True
		Me._lvwJourSemaine_3.FullRowSelect = True
		Me._lvwJourSemaine_3.GridLines = True
		Me._lvwJourSemaine_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lvwJourSemaine_3.BackColor = System.Drawing.Color.White
		Me._lvwJourSemaine_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lvwJourSemaine_3.Name = "_lvwJourSemaine_3"
		Me.__lvwJourSemaine_3_ColumnHeader_1.Text = "nom"
		Me.__lvwJourSemaine_3_ColumnHeader_1.Width = 53
		Me.__lvwJourSemaine_3_ColumnHeader_2.Text = "heure"
		Me.__lvwJourSemaine_3_ColumnHeader_2.Width = 119
		Me._lvwJourSemaine_4.Size = New System.Drawing.Size(124, 127)
		Me._lvwJourSemaine_4.Location = New System.Drawing.Point(371, 48)
		Me._lvwJourSemaine_4.TabIndex = 46
		Me._lvwJourSemaine_4.View = System.Windows.Forms.View.Details
		Me._lvwJourSemaine_4.LabelEdit = False
		Me._lvwJourSemaine_4.LabelWrap = True
		Me._lvwJourSemaine_4.HideSelection = True
		Me._lvwJourSemaine_4.FullRowSelect = True
		Me._lvwJourSemaine_4.GridLines = True
		Me._lvwJourSemaine_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lvwJourSemaine_4.BackColor = System.Drawing.Color.White
		Me._lvwJourSemaine_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lvwJourSemaine_4.Name = "_lvwJourSemaine_4"
		Me.__lvwJourSemaine_4_ColumnHeader_1.Text = "nom"
		Me.__lvwJourSemaine_4_ColumnHeader_1.Width = 53
		Me.__lvwJourSemaine_4_ColumnHeader_2.Text = "heure"
		Me.__lvwJourSemaine_4_ColumnHeader_2.Width = 119
		Me._lvwJourSemaine_5.Size = New System.Drawing.Size(124, 127)
		Me._lvwJourSemaine_5.Location = New System.Drawing.Point(495, 48)
		Me._lvwJourSemaine_5.TabIndex = 47
		Me._lvwJourSemaine_5.View = System.Windows.Forms.View.Details
		Me._lvwJourSemaine_5.LabelEdit = False
		Me._lvwJourSemaine_5.LabelWrap = True
		Me._lvwJourSemaine_5.HideSelection = True
		Me._lvwJourSemaine_5.FullRowSelect = True
		Me._lvwJourSemaine_5.GridLines = True
		Me._lvwJourSemaine_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lvwJourSemaine_5.BackColor = System.Drawing.Color.White
		Me._lvwJourSemaine_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lvwJourSemaine_5.Name = "_lvwJourSemaine_5"
		Me.__lvwJourSemaine_5_ColumnHeader_1.Text = "nom"
		Me.__lvwJourSemaine_5_ColumnHeader_1.Width = 53
		Me.__lvwJourSemaine_5_ColumnHeader_2.Text = "heure"
		Me.__lvwJourSemaine_5_ColumnHeader_2.Width = 119
		Me._lvwJourSemaine_6.Size = New System.Drawing.Size(124, 127)
		Me._lvwJourSemaine_6.Location = New System.Drawing.Point(619, 48)
		Me._lvwJourSemaine_6.TabIndex = 48
		Me._lvwJourSemaine_6.View = System.Windows.Forms.View.Details
		Me._lvwJourSemaine_6.LabelEdit = False
		Me._lvwJourSemaine_6.LabelWrap = True
		Me._lvwJourSemaine_6.HideSelection = True
		Me._lvwJourSemaine_6.FullRowSelect = True
		Me._lvwJourSemaine_6.GridLines = True
		Me._lvwJourSemaine_6.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lvwJourSemaine_6.BackColor = System.Drawing.Color.White
		Me._lvwJourSemaine_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lvwJourSemaine_6.Name = "_lvwJourSemaine_6"
		Me.__lvwJourSemaine_6_ColumnHeader_1.Text = "nom"
		Me.__lvwJourSemaine_6_ColumnHeader_1.Width = 53
		Me.__lvwJourSemaine_6_ColumnHeader_2.Text = "heure"
		Me.__lvwJourSemaine_6_ColumnHeader_2.Width = 119
		Me._lvwJourSemaine_7.Size = New System.Drawing.Size(124, 127)
		Me._lvwJourSemaine_7.Location = New System.Drawing.Point(742, 48)
		Me._lvwJourSemaine_7.TabIndex = 49
		Me._lvwJourSemaine_7.View = System.Windows.Forms.View.Details
		Me._lvwJourSemaine_7.LabelEdit = False
		Me._lvwJourSemaine_7.LabelWrap = True
		Me._lvwJourSemaine_7.HideSelection = True
		Me._lvwJourSemaine_7.FullRowSelect = True
		Me._lvwJourSemaine_7.GridLines = True
		Me._lvwJourSemaine_7.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lvwJourSemaine_7.BackColor = System.Drawing.Color.White
		Me._lvwJourSemaine_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lvwJourSemaine_7.Name = "_lvwJourSemaine_7"
		Me.__lvwJourSemaine_7_ColumnHeader_1.Text = "nom"
		Me.__lvwJourSemaine_7_ColumnHeader_1.Width = 53
		Me.__lvwJourSemaine_7_ColumnHeader_2.Text = "heure"
		Me.__lvwJourSemaine_7_ColumnHeader_2.Width = 119
		Me._lblNomJour_0.Text = "Dim"
		Me._lblNomJour_0.ForeColor = System.Drawing.Color.White
		Me._lblNomJour_0.Size = New System.Drawing.Size(32, 17)
		Me._lblNomJour_0.Location = New System.Drawing.Point(8, 24)
		Me._lblNomJour_0.TabIndex = 30
		Me._lblNomJour_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblNomJour_0.BackColor = System.Drawing.Color.Transparent
		Me._lblNomJour_0.Enabled = True
		Me._lblNomJour_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblNomJour_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblNomJour_0.UseMnemonic = True
		Me._lblNomJour_0.Visible = True
		Me._lblNomJour_0.AutoSize = False
		Me._lblNomJour_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblNomJour_0.Name = "_lblNomJour_0"
		Me._lblNomJour_1.Text = "Lun"
		Me._lblNomJour_1.ForeColor = System.Drawing.Color.White
		Me._lblNomJour_1.Size = New System.Drawing.Size(32, 17)
		Me._lblNomJour_1.Location = New System.Drawing.Point(131, 24)
		Me._lblNomJour_1.TabIndex = 32
		Me._lblNomJour_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblNomJour_1.BackColor = System.Drawing.Color.Transparent
		Me._lblNomJour_1.Enabled = True
		Me._lblNomJour_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblNomJour_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblNomJour_1.UseMnemonic = True
		Me._lblNomJour_1.Visible = True
		Me._lblNomJour_1.AutoSize = False
		Me._lblNomJour_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblNomJour_1.Name = "_lblNomJour_1"
		Me._lblNomJour_2.Text = "Mar"
		Me._lblNomJour_2.ForeColor = System.Drawing.Color.White
		Me._lblNomJour_2.Size = New System.Drawing.Size(32, 17)
		Me._lblNomJour_2.Location = New System.Drawing.Point(255, 24)
		Me._lblNomJour_2.TabIndex = 34
		Me._lblNomJour_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblNomJour_2.BackColor = System.Drawing.Color.Transparent
		Me._lblNomJour_2.Enabled = True
		Me._lblNomJour_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblNomJour_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblNomJour_2.UseMnemonic = True
		Me._lblNomJour_2.Visible = True
		Me._lblNomJour_2.AutoSize = False
		Me._lblNomJour_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblNomJour_2.Name = "_lblNomJour_2"
		Me._lblNomJour_3.Text = "Mer"
		Me._lblNomJour_3.ForeColor = System.Drawing.Color.White
		Me._lblNomJour_3.Size = New System.Drawing.Size(32, 17)
		Me._lblNomJour_3.Location = New System.Drawing.Point(378, 24)
		Me._lblNomJour_3.TabIndex = 35
		Me._lblNomJour_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblNomJour_3.BackColor = System.Drawing.Color.Transparent
		Me._lblNomJour_3.Enabled = True
		Me._lblNomJour_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblNomJour_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblNomJour_3.UseMnemonic = True
		Me._lblNomJour_3.Visible = True
		Me._lblNomJour_3.AutoSize = False
		Me._lblNomJour_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblNomJour_3.Name = "_lblNomJour_3"
		Me._lblNomJour_4.Text = "Jeu"
		Me._lblNomJour_4.ForeColor = System.Drawing.Color.White
		Me._lblNomJour_4.Size = New System.Drawing.Size(32, 17)
		Me._lblNomJour_4.Location = New System.Drawing.Point(502, 24)
		Me._lblNomJour_4.TabIndex = 38
		Me._lblNomJour_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblNomJour_4.BackColor = System.Drawing.Color.Transparent
		Me._lblNomJour_4.Enabled = True
		Me._lblNomJour_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblNomJour_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblNomJour_4.UseMnemonic = True
		Me._lblNomJour_4.Visible = True
		Me._lblNomJour_4.AutoSize = False
		Me._lblNomJour_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblNomJour_4.Name = "_lblNomJour_4"
		Me._lblNomJour_5.Text = "Ven"
		Me._lblNomJour_5.ForeColor = System.Drawing.Color.White
		Me._lblNomJour_5.Size = New System.Drawing.Size(32, 17)
		Me._lblNomJour_5.Location = New System.Drawing.Point(625, 24)
		Me._lblNomJour_5.TabIndex = 39
		Me._lblNomJour_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblNomJour_5.BackColor = System.Drawing.Color.Transparent
		Me._lblNomJour_5.Enabled = True
		Me._lblNomJour_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblNomJour_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblNomJour_5.UseMnemonic = True
		Me._lblNomJour_5.Visible = True
		Me._lblNomJour_5.AutoSize = False
		Me._lblNomJour_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblNomJour_5.Name = "_lblNomJour_5"
		Me._lblNomJour_6.Text = "Sam"
		Me._lblNomJour_6.ForeColor = System.Drawing.Color.White
		Me._lblNomJour_6.Size = New System.Drawing.Size(32, 17)
		Me._lblNomJour_6.Location = New System.Drawing.Point(749, 24)
		Me._lblNomJour_6.TabIndex = 41
		Me._lblNomJour_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblNomJour_6.BackColor = System.Drawing.Color.Transparent
		Me._lblNomJour_6.Enabled = True
		Me._lblNomJour_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblNomJour_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblNomJour_6.UseMnemonic = True
		Me._lblNomJour_6.Visible = True
		Me._lblNomJour_6.AutoSize = False
		Me._lblNomJour_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblNomJour_6.Name = "_lblNomJour_6"
		Me.Line2.BorderColor = System.Drawing.Color.White
		Me.Line2.X1 = 248
		Me.Line2.X2 = 248
		Me.Line2.Y1 = 11
		Me.Line2.Y2 = 163
		Me.Line2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Line2.BorderWidth = 1
		Me.Line2.Visible = True
		Me.Line2.Name = "Line2"
		Me.Line3.BorderColor = System.Drawing.Color.White
		Me.Line3.X1 = 371
		Me.Line3.X2 = 371
		Me.Line3.Y1 = 11
		Me.Line3.Y2 = 163
		Me.Line3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Line3.BorderWidth = 1
		Me.Line3.Visible = True
		Me.Line3.Name = "Line3"
		Me.Line4.BorderColor = System.Drawing.Color.White
		Me.Line4.X1 = 495
		Me.Line4.X2 = 495
		Me.Line4.Y1 = 11
		Me.Line4.Y2 = 163
		Me.Line4.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Line4.BorderWidth = 1
		Me.Line4.Visible = True
		Me.Line4.Name = "Line4"
		Me.Line5.BorderColor = System.Drawing.Color.White
		Me.Line5.X1 = 619
		Me.Line5.X2 = 619
		Me.Line5.Y1 = 11
		Me.Line5.Y2 = 163
		Me.Line5.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Line5.BorderWidth = 1
		Me.Line5.Visible = True
		Me.Line5.Name = "Line5"
		Me.Line6.BorderColor = System.Drawing.Color.White
		Me.Line6.X1 = 742
		Me.Line6.X2 = 742
		Me.Line6.Y1 = 11
		Me.Line6.Y2 = 163
		Me.Line6.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Line6.BorderWidth = 1
		Me.Line6.Visible = True
		Me.Line6.Name = "Line6"
		Me.Line1.BorderColor = System.Drawing.Color.White
		Me.Line1.X1 = 124
		Me.Line1.X2 = 124
		Me.Line1.Y1 = 11
		Me.Line1.Y2 = 163
		Me.Line1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Line1.BorderWidth = 1
		Me.Line1.Visible = True
		Me.Line1.Name = "Line1"
		Me._lblJour_0.ForeColor = System.Drawing.Color.White
		Me._lblJour_0.Size = New System.Drawing.Size(32, 17)
		Me._lblJour_0.Location = New System.Drawing.Point(40, 24)
		Me._lblJour_0.TabIndex = 29
		Me._lblJour_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblJour_0.BackColor = System.Drawing.Color.Transparent
		Me._lblJour_0.Enabled = True
		Me._lblJour_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblJour_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblJour_0.UseMnemonic = True
		Me._lblJour_0.Visible = True
		Me._lblJour_0.AutoSize = False
		Me._lblJour_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblJour_0.Name = "_lblJour_0"
		Me._lblJour_1.ForeColor = System.Drawing.Color.White
		Me._lblJour_1.Size = New System.Drawing.Size(32, 17)
		Me._lblJour_1.Location = New System.Drawing.Point(163, 24)
		Me._lblJour_1.TabIndex = 31
		Me._lblJour_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblJour_1.BackColor = System.Drawing.Color.Transparent
		Me._lblJour_1.Enabled = True
		Me._lblJour_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblJour_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblJour_1.UseMnemonic = True
		Me._lblJour_1.Visible = True
		Me._lblJour_1.AutoSize = False
		Me._lblJour_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblJour_1.Name = "_lblJour_1"
		Me._lblJour_2.ForeColor = System.Drawing.Color.White
		Me._lblJour_2.Size = New System.Drawing.Size(32, 17)
		Me._lblJour_2.Location = New System.Drawing.Point(287, 24)
		Me._lblJour_2.TabIndex = 33
		Me._lblJour_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblJour_2.BackColor = System.Drawing.Color.Transparent
		Me._lblJour_2.Enabled = True
		Me._lblJour_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblJour_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblJour_2.UseMnemonic = True
		Me._lblJour_2.Visible = True
		Me._lblJour_2.AutoSize = False
		Me._lblJour_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblJour_2.Name = "_lblJour_2"
		Me._lblJour_3.ForeColor = System.Drawing.Color.White
		Me._lblJour_3.Size = New System.Drawing.Size(32, 17)
		Me._lblJour_3.Location = New System.Drawing.Point(410, 24)
		Me._lblJour_3.TabIndex = 36
		Me._lblJour_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblJour_3.BackColor = System.Drawing.Color.Transparent
		Me._lblJour_3.Enabled = True
		Me._lblJour_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblJour_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblJour_3.UseMnemonic = True
		Me._lblJour_3.Visible = True
		Me._lblJour_3.AutoSize = False
		Me._lblJour_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblJour_3.Name = "_lblJour_3"
		Me._lblJour_4.ForeColor = System.Drawing.Color.White
		Me._lblJour_4.Size = New System.Drawing.Size(32, 17)
		Me._lblJour_4.Location = New System.Drawing.Point(534, 24)
		Me._lblJour_4.TabIndex = 37
		Me._lblJour_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblJour_4.BackColor = System.Drawing.Color.Transparent
		Me._lblJour_4.Enabled = True
		Me._lblJour_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblJour_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblJour_4.UseMnemonic = True
		Me._lblJour_4.Visible = True
		Me._lblJour_4.AutoSize = False
		Me._lblJour_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblJour_4.Name = "_lblJour_4"
		Me._lblJour_5.ForeColor = System.Drawing.Color.White
		Me._lblJour_5.Size = New System.Drawing.Size(32, 17)
		Me._lblJour_5.Location = New System.Drawing.Point(657, 24)
		Me._lblJour_5.TabIndex = 40
		Me._lblJour_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblJour_5.BackColor = System.Drawing.Color.Transparent
		Me._lblJour_5.Enabled = True
		Me._lblJour_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblJour_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblJour_5.UseMnemonic = True
		Me._lblJour_5.Visible = True
		Me._lblJour_5.AutoSize = False
		Me._lblJour_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblJour_5.Name = "_lblJour_5"
		Me._lblJour_6.ForeColor = System.Drawing.Color.White
		Me._lblJour_6.Size = New System.Drawing.Size(32, 17)
		Me._lblJour_6.Location = New System.Drawing.Point(788, 24)
		Me._lblJour_6.TabIndex = 42
		Me._lblJour_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblJour_6.BackColor = System.Drawing.Color.Transparent
		Me._lblJour_6.Enabled = True
		Me._lblJour_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblJour_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblJour_6.UseMnemonic = True
		Me._lblJour_6.Visible = True
		Me._lblJour_6.AutoSize = False
		Me._lblJour_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblJour_6.Name = "_lblJour_6"
		mvwSelection.OcxState = CType(resources.GetObject("mvwSelection.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwSelection.Size = New System.Drawing.Size(299, 268)
		Me.mvwSelection.Location = New System.Drawing.Point(8, 80)
		Me.mvwSelection.TabIndex = 27
		Me.mvwSelection.Name = "mvwSelection"
		Me.fraPunch.Size = New System.Drawing.Size(561, 353)
		Me.fraPunch.Location = New System.Drawing.Point(320, 40)
		Me.fraPunch.TabIndex = 6
		Me.fraPunch.Visible = False
		Me.fraPunch.BackColor = System.Drawing.SystemColors.Control
		Me.fraPunch.Enabled = True
		Me.fraPunch.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraPunch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraPunch.Padding = New System.Windows.Forms.Padding(0)
		Me.fraPunch.Name = "fraPunch"
		Me.cmbType.Size = New System.Drawing.Size(385, 21)
		Me.cmbType.Location = New System.Drawing.Point(168, 168)
		Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbType.TabIndex = 87
		Me.cmbType.BackColor = System.Drawing.SystemColors.Window
		Me.cmbType.CausesValidation = True
		Me.cmbType.Enabled = True
		Me.cmbType.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbType.IntegralHeight = True
		Me.cmbType.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbType.Sorted = False
		Me.cmbType.TabStop = True
		Me.cmbType.Visible = True
		Me.cmbType.Name = "cmbType"
		Me.picPMTypePunch.Size = New System.Drawing.Size(81, 41)
		Me.picPMTypePunch.Location = New System.Drawing.Point(176, 56)
		Me.picPMTypePunch.TabIndex = 79
		Me.picPMTypePunch.Dock = System.Windows.Forms.DockStyle.None
		Me.picPMTypePunch.BackColor = System.Drawing.SystemColors.Control
		Me.picPMTypePunch.CausesValidation = True
		Me.picPMTypePunch.Enabled = True
		Me.picPMTypePunch.ForeColor = System.Drawing.SystemColors.ControlText
		Me.picPMTypePunch.Cursor = System.Windows.Forms.Cursors.Default
		Me.picPMTypePunch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picPMTypePunch.TabStop = True
		Me.picPMTypePunch.Visible = True
		Me.picPMTypePunch.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picPMTypePunch.Name = "picPMTypePunch"
		Me._optTypePunch_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optTypePunch_0.Text = "Électrique"
		Me._optTypePunch_0.Size = New System.Drawing.Size(73, 17)
		Me._optTypePunch_0.Location = New System.Drawing.Point(8, 0)
		Me._optTypePunch_0.TabIndex = 81
		Me._optTypePunch_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optTypePunch_0.BackColor = System.Drawing.SystemColors.Control
		Me._optTypePunch_0.CausesValidation = True
		Me._optTypePunch_0.Enabled = True
		Me._optTypePunch_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optTypePunch_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optTypePunch_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optTypePunch_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optTypePunch_0.TabStop = True
		Me._optTypePunch_0.Checked = False
		Me._optTypePunch_0.Visible = True
		Me._optTypePunch_0.Name = "_optTypePunch_0"
		Me._optTypePunch_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optTypePunch_1.Text = "Mécanique"
		Me._optTypePunch_1.Size = New System.Drawing.Size(73, 17)
		Me._optTypePunch_1.Location = New System.Drawing.Point(8, 20)
		Me._optTypePunch_1.TabIndex = 80
		Me._optTypePunch_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optTypePunch_1.BackColor = System.Drawing.SystemColors.Control
		Me._optTypePunch_1.CausesValidation = True
		Me._optTypePunch_1.Enabled = True
		Me._optTypePunch_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optTypePunch_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optTypePunch_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optTypePunch_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optTypePunch_1.TabStop = True
		Me._optTypePunch_1.Checked = False
		Me._optTypePunch_1.Visible = True
		Me._optTypePunch_1.Name = "_optTypePunch_1"
		Me._optHeureDiner_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optHeureDiner_1.Text = "1 heure"
		Me._optHeureDiner_1.Enabled = False
		Me._optHeureDiner_1.Size = New System.Drawing.Size(81, 13)
		Me._optHeureDiner_1.Location = New System.Drawing.Point(384, 288)
		Me._optHeureDiner_1.TabIndex = 73
		Me._optHeureDiner_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optHeureDiner_1.BackColor = System.Drawing.SystemColors.Control
		Me._optHeureDiner_1.CausesValidation = True
		Me._optHeureDiner_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optHeureDiner_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optHeureDiner_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optHeureDiner_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optHeureDiner_1.TabStop = True
		Me._optHeureDiner_1.Checked = False
		Me._optHeureDiner_1.Visible = True
		Me._optHeureDiner_1.Name = "_optHeureDiner_1"
		Me._optHeureDiner_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optHeureDiner_0.Text = "30 minutes"
		Me._optHeureDiner_0.Enabled = False
		Me._optHeureDiner_0.Size = New System.Drawing.Size(81, 13)
		Me._optHeureDiner_0.Location = New System.Drawing.Point(384, 272)
		Me._optHeureDiner_0.TabIndex = 72
		Me._optHeureDiner_0.Checked = True
		Me._optHeureDiner_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optHeureDiner_0.BackColor = System.Drawing.SystemColors.Control
		Me._optHeureDiner_0.CausesValidation = True
		Me._optHeureDiner_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optHeureDiner_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optHeureDiner_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optHeureDiner_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optHeureDiner_0.TabStop = True
		Me._optHeureDiner_0.Visible = True
		Me._optHeureDiner_0.Name = "_optHeureDiner_0"
		Me.cmdBrowseComment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBrowseComment.Text = "Choisir un commentaire"
		Me.cmdBrowseComment.Size = New System.Drawing.Size(137, 25)
		Me.cmdBrowseComment.Location = New System.Drawing.Point(184, 320)
		Me.cmdBrowseComment.TabIndex = 71
		Me.cmdBrowseComment.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBrowseComment.CausesValidation = True
		Me.cmdBrowseComment.Enabled = True
		Me.cmdBrowseComment.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBrowseComment.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBrowseComment.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBrowseComment.TabStop = True
		Me.cmdBrowseComment.Name = "cmdBrowseComment"
		Me.chkDiner.Text = "Heure de dîner"
		Me.chkDiner.Size = New System.Drawing.Size(97, 17)
		Me.chkDiner.Location = New System.Drawing.Point(336, 248)
		Me.chkDiner.TabIndex = 23
		Me.chkDiner.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkDiner.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkDiner.BackColor = System.Drawing.SystemColors.Control
		Me.chkDiner.CausesValidation = True
		Me.chkDiner.Enabled = True
		Me.chkDiner.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkDiner.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkDiner.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkDiner.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkDiner.TabStop = True
		Me.chkDiner.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkDiner.Visible = True
		Me.chkDiner.Name = "chkDiner"
		Me.txtKM.AutoSize = False
		Me.txtKM.Enabled = False
		Me.txtKM.Size = New System.Drawing.Size(41, 19)
		Me.txtKM.Location = New System.Drawing.Point(424, 224)
		Me.txtKM.TabIndex = 20
		Me.txtKM.AcceptsReturn = True
		Me.txtKM.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtKM.BackColor = System.Drawing.SystemColors.Window
		Me.txtKM.CausesValidation = True
		Me.txtKM.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtKM.HideSelection = True
		Me.txtKM.ReadOnly = False
		Me.txtKM.Maxlength = 0
		Me.txtKM.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtKM.MultiLine = False
		Me.txtKM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtKM.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtKM.TabStop = True
		Me.txtKM.Visible = True
		Me.txtKM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtKM.Name = "txtKM"
		Me.chkKM.Text = "Kilométrage :"
		Me.chkKM.Size = New System.Drawing.Size(81, 17)
		Me.chkKM.Location = New System.Drawing.Point(336, 224)
		Me.chkKM.TabIndex = 19
		Me.chkKM.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkKM.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkKM.BackColor = System.Drawing.SystemColors.Control
		Me.chkKM.CausesValidation = True
		Me.chkKM.Enabled = True
		Me.chkKM.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkKM.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkKM.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkKM.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkKM.TabStop = True
		Me.chkKM.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkKM.Visible = True
		Me.chkKM.Name = "chkKM"
		Me.txtClient.AutoSize = False
		Me.txtClient.Size = New System.Drawing.Size(385, 19)
		Me.txtClient.Location = New System.Drawing.Point(168, 124)
		Me.txtClient.ReadOnly = True
		Me.txtClient.TabIndex = 18
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
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(73, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(400, 320)
		Me.cmdAnnuler.TabIndex = 25
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.txtCommentaires.AutoSize = False
		Me.txtCommentaires.Size = New System.Drawing.Size(313, 65)
		Me.txtCommentaires.Location = New System.Drawing.Point(8, 248)
		Me.txtCommentaires.MultiLine = True
		Me.txtCommentaires.TabIndex = 24
		Me.txtCommentaires.AcceptsReturn = True
		Me.txtCommentaires.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCommentaires.BackColor = System.Drawing.SystemColors.Window
		Me.txtCommentaires.CausesValidation = True
		Me.txtCommentaires.Enabled = True
		Me.txtCommentaires.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCommentaires.HideSelection = True
		Me.txtCommentaires.ReadOnly = False
		Me.txtCommentaires.Maxlength = 0
		Me.txtCommentaires.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCommentaires.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCommentaires.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCommentaires.TabStop = True
		Me.txtCommentaires.Visible = True
		Me.txtCommentaires.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCommentaires.Name = "txtCommentaires"
		Me.fraHeure.Text = "Heure"
		Me.fraHeure.Size = New System.Drawing.Size(137, 65)
		Me.fraHeure.Location = New System.Drawing.Point(8, 112)
		Me.fraHeure.TabIndex = 13
		Me.fraHeure.BackColor = System.Drawing.SystemColors.Control
		Me.fraHeure.Enabled = True
		Me.fraHeure.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraHeure.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraHeure.Visible = True
		Me.fraHeure.Padding = New System.Windows.Forms.Padding(0)
		Me.fraHeure.Name = "fraHeure"
		Me.mskHeure.AllowPromptAsInput = False
		Me.mskHeure.Size = New System.Drawing.Size(65, 17)
		Me.mskHeure.Location = New System.Drawing.Point(24, 40)
		Me.mskHeure.TabIndex = 15
		Me.mskHeure.PromptChar = "_"
		Me.mskHeure.Name = "mskHeure"
		Me._optHeure_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optHeure_1.Text = "Système"
		Me._optHeure_1.Size = New System.Drawing.Size(17, 17)
		Me._optHeure_1.Location = New System.Drawing.Point(8, 40)
		Me._optHeure_1.TabIndex = 16
		Me._optHeure_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optHeure_1.BackColor = System.Drawing.SystemColors.Control
		Me._optHeure_1.CausesValidation = True
		Me._optHeure_1.Enabled = True
		Me._optHeure_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optHeure_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optHeure_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optHeure_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optHeure_1.TabStop = True
		Me._optHeure_1.Checked = False
		Me._optHeure_1.Visible = True
		Me._optHeure_1.Name = "_optHeure_1"
		Me._optHeure_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optHeure_0.Text = "Heure de l'ordinateur"
		Me._optHeure_0.Size = New System.Drawing.Size(121, 17)
		Me._optHeure_0.Location = New System.Drawing.Point(8, 16)
		Me._optHeure_0.TabIndex = 14
		Me._optHeure_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optHeure_0.BackColor = System.Drawing.SystemColors.Control
		Me._optHeure_0.CausesValidation = True
		Me._optHeure_0.Enabled = True
		Me._optHeure_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optHeure_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optHeure_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optHeure_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optHeure_0.TabStop = True
		Me._optHeure_0.Checked = False
		Me._optHeure_0.Visible = True
		Me._optHeure_0.Name = "_optHeure_0"
		Me.cmbemployé.BackColor = System.Drawing.Color.White
		Me.cmbemployé.Size = New System.Drawing.Size(233, 21)
		Me.cmbemployé.Location = New System.Drawing.Point(72, 24)
		Me.cmbemployé.TabIndex = 8
		Me.cmbemployé.Text = "cmbemployé"
		Me.cmbemployé.CausesValidation = True
		Me.cmbemployé.Enabled = True
		Me.cmbemployé.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbemployé.IntegralHeight = True
		Me.cmbemployé.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbemployé.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbemployé.Sorted = False
		Me.cmbemployé.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbemployé.TabStop = True
		Me.cmbemployé.Visible = True
		Me.cmbemployé.Name = "cmbemployé"
		Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.Text = "OK"
		Me.AcceptButton = Me.cmdOK
		Me.cmdOK.Size = New System.Drawing.Size(73, 25)
		Me.cmdOK.Location = New System.Drawing.Point(480, 320)
		Me.cmdOK.TabIndex = 26
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me.txtEmploye.AutoSize = False
		Me.txtEmploye.Size = New System.Drawing.Size(233, 19)
		Me.txtEmploye.Location = New System.Drawing.Point(72, 24)
		Me.txtEmploye.ReadOnly = True
		Me.txtEmploye.TabIndex = 9
		Me.txtEmploye.AcceptsReturn = True
		Me.txtEmploye.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtEmploye.BackColor = System.Drawing.SystemColors.Window
		Me.txtEmploye.CausesValidation = True
		Me.txtEmploye.Enabled = True
		Me.txtEmploye.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtEmploye.HideSelection = True
		Me.txtEmploye.Maxlength = 0
		Me.txtEmploye.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtEmploye.MultiLine = False
		Me.txtEmploye.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtEmploye.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtEmploye.TabStop = True
		Me.txtEmploye.Visible = True
		Me.txtEmploye.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtEmploye.Name = "txtEmploye"
		Me.txtNoProjet.AutoSize = False
		Me.txtNoProjet.Size = New System.Drawing.Size(81, 19)
		Me.txtNoProjet.Location = New System.Drawing.Point(80, 64)
		Me.txtNoProjet.ReadOnly = True
		Me.txtNoProjet.TabIndex = 12
		Me.txtNoProjet.AcceptsReturn = True
		Me.txtNoProjet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoProjet.BackColor = System.Drawing.SystemColors.Window
		Me.txtNoProjet.CausesValidation = True
		Me.txtNoProjet.Enabled = True
		Me.txtNoProjet.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNoProjet.HideSelection = True
		Me.txtNoProjet.Maxlength = 0
		Me.txtNoProjet.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNoProjet.MultiLine = False
		Me.txtNoProjet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNoProjet.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNoProjet.TabStop = True
		Me.txtNoProjet.Visible = True
		Me.txtNoProjet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoProjet.Name = "txtNoProjet"
		Me.mskNoProjet.AllowPromptAsInput = False
		Me.mskNoProjet.Size = New System.Drawing.Size(81, 17)
		Me.mskNoProjet.Location = New System.Drawing.Point(80, 64)
		Me.mskNoProjet.TabIndex = 11
		Me.mskNoProjet.MaxLength = 8
		Me.mskNoProjet.Mask = "#####-##"
		Me.mskNoProjet.PromptChar = "_"
		Me.mskNoProjet.Name = "mskNoProjet"
		Me.lblTypePunch.ForeColor = System.Drawing.Color.Black
		Me.lblTypePunch.Size = New System.Drawing.Size(265, 17)
		Me.lblTypePunch.Location = New System.Drawing.Point(280, 56)
		Me.lblTypePunch.TabIndex = 89
		Me.lblTypePunch.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTypePunch.BackColor = System.Drawing.SystemColors.Control
		Me.lblTypePunch.Enabled = True
		Me.lblTypePunch.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTypePunch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTypePunch.UseMnemonic = True
		Me.lblTypePunch.Visible = True
		Me.lblTypePunch.AutoSize = False
		Me.lblTypePunch.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTypePunch.Name = "lblTypePunch"
		Me.lblType.Text = "Type"
		Me.lblType.ForeColor = System.Drawing.Color.Black
		Me.lblType.Size = New System.Drawing.Size(33, 17)
		Me.lblType.Location = New System.Drawing.Point(168, 152)
		Me.lblType.TabIndex = 86
		Me.lblType.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblType.BackColor = System.Drawing.SystemColors.Control
		Me.lblType.Enabled = True
		Me.lblType.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblType.UseMnemonic = True
		Me.lblType.Visible = True
		Me.lblType.AutoSize = False
		Me.lblType.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblType.Name = "lblType"
		Me.lblPrefixe.Size = New System.Drawing.Size(17, 19)
		Me.lblPrefixe.Location = New System.Drawing.Point(64, 64)
		Me.lblPrefixe.TabIndex = 83
		Me.lblPrefixe.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPrefixe.BackColor = System.Drawing.SystemColors.Control
		Me.lblPrefixe.Enabled = True
		Me.lblPrefixe.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPrefixe.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPrefixe.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPrefixe.UseMnemonic = True
		Me.lblPrefixe.Visible = True
		Me.lblPrefixe.AutoSize = False
		Me.lblPrefixe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblPrefixe.Name = "lblPrefixe"
		Me.Label4.Text = "Km"
		Me.Label4.ForeColor = System.Drawing.Color.Black
		Me.Label4.Size = New System.Drawing.Size(17, 17)
		Me.Label4.Location = New System.Drawing.Point(472, 224)
		Me.Label4.TabIndex = 21
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label2.Text = "Commentaires"
		Me.Label2.Size = New System.Drawing.Size(73, 17)
		Me.Label2.Location = New System.Drawing.Point(8, 232)
		Me.Label2.TabIndex = 22
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.lblprojet.Text = "No. Projet"
		Me.lblprojet.ForeColor = System.Drawing.Color.Black
		Me.lblprojet.Size = New System.Drawing.Size(49, 17)
		Me.lblprojet.Location = New System.Drawing.Point(8, 64)
		Me.lblprojet.TabIndex = 10
		Me.lblprojet.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblprojet.BackColor = System.Drawing.SystemColors.Control
		Me.lblprojet.Enabled = True
		Me.lblprojet.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblprojet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblprojet.UseMnemonic = True
		Me.lblprojet.Visible = True
		Me.lblprojet.AutoSize = False
		Me.lblprojet.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblprojet.Name = "lblprojet"
		Me.Label1.Text = "Employé"
		Me.Label1.ForeColor = System.Drawing.Color.Black
		Me.Label1.Size = New System.Drawing.Size(57, 17)
		Me.Label1.Location = New System.Drawing.Point(8, 24)
		Me.Label1.TabIndex = 7
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Label3.Text = "Client"
		Me.Label3.ForeColor = System.Drawing.Color.Black
		Me.Label3.Size = New System.Drawing.Size(49, 17)
		Me.Label3.Location = New System.Drawing.Point(168, 108)
		Me.Label3.TabIndex = 17
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.lblNbreHeure.BackColor = System.Drawing.Color.White
		Me.lblNbreHeure.Size = New System.Drawing.Size(65, 17)
		Me.lblNbreHeure.Location = New System.Drawing.Point(760, 16)
		Me.lblNbreHeure.TabIndex = 52
		Me.lblNbreHeure.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblNbreHeure.Enabled = True
		Me.lblNbreHeure.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblNbreHeure.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblNbreHeure.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblNbreHeure.UseMnemonic = True
		Me.lblNbreHeure.Visible = True
		Me.lblNbreHeure.AutoSize = False
		Me.lblNbreHeure.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblNbreHeure.Name = "lblNbreHeure"
		Me.lblTitreHeure.Text = "Nombre d'heures dans la semaine pour :"
		Me.lblTitreHeure.ForeColor = System.Drawing.Color.White
		Me.lblTitreHeure.Size = New System.Drawing.Size(193, 17)
		Me.lblTitreHeure.Location = New System.Drawing.Point(376, 16)
		Me.lblTitreHeure.TabIndex = 50
		Me.lblTitreHeure.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblTitreHeure.BackColor = System.Drawing.Color.Transparent
		Me.lblTitreHeure.Enabled = True
		Me.lblTitreHeure.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTitreHeure.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTitreHeure.UseMnemonic = True
		Me.lblTitreHeure.Visible = True
		Me.lblTitreHeure.AutoSize = False
		Me.lblTitreHeure.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTitreHeure.Name = "lblTitreHeure"
		Me.Controls.Add(fraJour)
		Me.Controls.Add(fraPunchMultiple)
		Me.Controls.Add(cmbHeureSemaine)
		Me.Controls.Add(fraSemaine)
		Me.Controls.Add(mvwSelection)
		Me.Controls.Add(fraPunch)
		Me.Controls.Add(lblNbreHeure)
		Me.Controls.Add(lblTitreHeure)
		Me.fraJour.Controls.Add(cmdPunchMultiple)
		Me.fraJour.Controls.Add(lvwJour)
		Me.fraJour.Controls.Add(cmdPunchOut)
		Me.fraJour.Controls.Add(cmdModifierPunchOut)
		Me.fraJour.Controls.Add(cmdPunchIn)
		Me.fraJour.Controls.Add(cmdModifierPunchIn)
		Me.lvwJour.Columns.Add(_lvwJour_ColumnHeader_1)
		Me.lvwJour.Columns.Add(_lvwJour_ColumnHeader_2)
		Me.lvwJour.Columns.Add(_lvwJour_ColumnHeader_3)
		Me.lvwJour.Columns.Add(_lvwJour_ColumnHeader_4)
		Me.lvwJour.Columns.Add(_lvwJour_ColumnHeader_5)
		Me.lvwJour.Columns.Add(_lvwJour_ColumnHeader_6)
		Me.lvwJour.Columns.Add(_lvwJour_ColumnHeader_7)
		Me.lvwJour.Columns.Add(_lvwJour_ColumnHeader_8)
		Me.fraPunchMultiple.Controls.Add(cmbPMType)
		Me.fraPunchMultiple.Controls.Add(_optPMHeureDiner_1)
		Me.fraPunchMultiple.Controls.Add(_optPMHeureDiner_0)
		Me.fraPunchMultiple.Controls.Add(cmdBrowseCommentPM)
		Me.fraPunchMultiple.Controls.Add(cmdPMOK)
		Me.fraPunchMultiple.Controls.Add(Frame2)
		Me.fraPunchMultiple.Controls.Add(txtPMCommentaire)
		Me.fraPunchMultiple.Controls.Add(cmdPMAnnuler)
		Me.fraPunchMultiple.Controls.Add(txtPMClient)
		Me.fraPunchMultiple.Controls.Add(chkPMDiner)
		Me.fraPunchMultiple.Controls.Add(lvwEmployes)
		Me.fraPunchMultiple.Controls.Add(mskPMNoProjet)
		Me.fraPunchMultiple.Controls.Add(picTypePunch)
		Me.fraPunchMultiple.Controls.Add(lblPMTypePunch)
		Me.fraPunchMultiple.Controls.Add(lblPMType)
		Me.fraPunchMultiple.Controls.Add(Label9)
		Me.fraPunchMultiple.Controls.Add(lblPMPrefixe)
		Me.fraPunchMultiple.Controls.Add(Label7)
		Me.fraPunchMultiple.Controls.Add(Label6)
		Me.Frame2.Controls.Add(mskPMHeureFin)
		Me.Frame2.Controls.Add(mskPMHeureDebut)
		Me.Frame2.Controls.Add(Label10)
		Me.Frame2.Controls.Add(Label8)
		Me.lvwEmployes.Columns.Add(_lvwEmployes_ColumnHeader_1)
		Me.picTypePunch.Controls.Add(_optPMTypePunch_1)
		Me.picTypePunch.Controls.Add(_optPMTypePunch_0)
		Me.fraSemaine.Controls.Add(_lvwJourSemaine_1)
		Me.fraSemaine.Controls.Add(_lvwJourSemaine_2)
		Me.fraSemaine.Controls.Add(_lvwJourSemaine_3)
		Me.fraSemaine.Controls.Add(_lvwJourSemaine_4)
		Me.fraSemaine.Controls.Add(_lvwJourSemaine_5)
		Me.fraSemaine.Controls.Add(_lvwJourSemaine_6)
		Me.fraSemaine.Controls.Add(_lvwJourSemaine_7)
		Me.fraSemaine.Controls.Add(_lblNomJour_0)
		Me.fraSemaine.Controls.Add(_lblNomJour_1)
		Me.fraSemaine.Controls.Add(_lblNomJour_2)
		Me.fraSemaine.Controls.Add(_lblNomJour_3)
		Me.fraSemaine.Controls.Add(_lblNomJour_4)
		Me.fraSemaine.Controls.Add(_lblNomJour_5)
		Me.fraSemaine.Controls.Add(_lblNomJour_6)
		Me.ShapeContainer1.Shapes.Add(Line2)
		Me.ShapeContainer1.Shapes.Add(Line3)
		Me.ShapeContainer1.Shapes.Add(Line4)
		Me.ShapeContainer1.Shapes.Add(Line5)
		Me.ShapeContainer1.Shapes.Add(Line6)
		Me.ShapeContainer1.Shapes.Add(Line1)
		Me.fraSemaine.Controls.Add(_lblJour_0)
		Me.fraSemaine.Controls.Add(_lblJour_1)
		Me.fraSemaine.Controls.Add(_lblJour_2)
		Me.fraSemaine.Controls.Add(_lblJour_3)
		Me.fraSemaine.Controls.Add(_lblJour_4)
		Me.fraSemaine.Controls.Add(_lblJour_5)
		Me.fraSemaine.Controls.Add(_lblJour_6)
		Me.fraSemaine.Controls.Add(ShapeContainer1)
		Me._lvwJourSemaine_1.Columns.Add(__lvwJourSemaine_1_ColumnHeader_1)
		Me._lvwJourSemaine_1.Columns.Add(__lvwJourSemaine_1_ColumnHeader_2)
		Me._lvwJourSemaine_2.Columns.Add(__lvwJourSemaine_2_ColumnHeader_1)
		Me._lvwJourSemaine_2.Columns.Add(__lvwJourSemaine_2_ColumnHeader_2)
		Me._lvwJourSemaine_3.Columns.Add(__lvwJourSemaine_3_ColumnHeader_1)
		Me._lvwJourSemaine_3.Columns.Add(__lvwJourSemaine_3_ColumnHeader_2)
		Me._lvwJourSemaine_4.Columns.Add(__lvwJourSemaine_4_ColumnHeader_1)
		Me._lvwJourSemaine_4.Columns.Add(__lvwJourSemaine_4_ColumnHeader_2)
		Me._lvwJourSemaine_5.Columns.Add(__lvwJourSemaine_5_ColumnHeader_1)
		Me._lvwJourSemaine_5.Columns.Add(__lvwJourSemaine_5_ColumnHeader_2)
		Me._lvwJourSemaine_6.Columns.Add(__lvwJourSemaine_6_ColumnHeader_1)
		Me._lvwJourSemaine_6.Columns.Add(__lvwJourSemaine_6_ColumnHeader_2)
		Me._lvwJourSemaine_7.Columns.Add(__lvwJourSemaine_7_ColumnHeader_1)
		Me._lvwJourSemaine_7.Columns.Add(__lvwJourSemaine_7_ColumnHeader_2)
		Me.fraPunch.Controls.Add(cmbType)
		Me.fraPunch.Controls.Add(picPMTypePunch)
		Me.fraPunch.Controls.Add(_optHeureDiner_1)
		Me.fraPunch.Controls.Add(_optHeureDiner_0)
		Me.fraPunch.Controls.Add(cmdBrowseComment)
		Me.fraPunch.Controls.Add(chkDiner)
		Me.fraPunch.Controls.Add(txtKM)
		Me.fraPunch.Controls.Add(chkKM)
		Me.fraPunch.Controls.Add(txtClient)
		Me.fraPunch.Controls.Add(cmdAnnuler)
		Me.fraPunch.Controls.Add(txtCommentaires)
		Me.fraPunch.Controls.Add(fraHeure)
		Me.fraPunch.Controls.Add(cmbemployé)
		Me.fraPunch.Controls.Add(cmdOK)
		Me.fraPunch.Controls.Add(txtEmploye)
		Me.fraPunch.Controls.Add(txtNoProjet)
		Me.fraPunch.Controls.Add(mskNoProjet)
		Me.fraPunch.Controls.Add(lblTypePunch)
		Me.fraPunch.Controls.Add(lblType)
		Me.fraPunch.Controls.Add(lblPrefixe)
		Me.fraPunch.Controls.Add(Label4)
		Me.fraPunch.Controls.Add(Label2)
		Me.fraPunch.Controls.Add(lblprojet)
		Me.fraPunch.Controls.Add(Label1)
		Me.fraPunch.Controls.Add(Label3)
		Me.picPMTypePunch.Controls.Add(_optTypePunch_0)
		Me.picPMTypePunch.Controls.Add(_optTypePunch_1)
		Me.fraHeure.Controls.Add(mskHeure)
		Me.fraHeure.Controls.Add(_optHeure_1)
		Me.fraHeure.Controls.Add(_optHeure_0)
		Me.lblJour.SetIndex(_lblJour_0, CType(0, Short))
		Me.lblJour.SetIndex(_lblJour_1, CType(1, Short))
		Me.lblJour.SetIndex(_lblJour_2, CType(2, Short))
		Me.lblJour.SetIndex(_lblJour_3, CType(3, Short))
		Me.lblJour.SetIndex(_lblJour_4, CType(4, Short))
		Me.lblJour.SetIndex(_lblJour_5, CType(5, Short))
		Me.lblJour.SetIndex(_lblJour_6, CType(6, Short))
		Me.lblNomJour.SetIndex(_lblNomJour_0, CType(0, Short))
		Me.lblNomJour.SetIndex(_lblNomJour_1, CType(1, Short))
		Me.lblNomJour.SetIndex(_lblNomJour_2, CType(2, Short))
		Me.lblNomJour.SetIndex(_lblNomJour_3, CType(3, Short))
		Me.lblNomJour.SetIndex(_lblNomJour_4, CType(4, Short))
		Me.lblNomJour.SetIndex(_lblNomJour_5, CType(5, Short))
		Me.lblNomJour.SetIndex(_lblNomJour_6, CType(6, Short))
		Me.lvwJourSemaine.SetIndex(_lvwJourSemaine_1, CType(1, Short))
		Me.lvwJourSemaine.SetIndex(_lvwJourSemaine_2, CType(2, Short))
		Me.lvwJourSemaine.SetIndex(_lvwJourSemaine_3, CType(3, Short))
		Me.lvwJourSemaine.SetIndex(_lvwJourSemaine_4, CType(4, Short))
		Me.lvwJourSemaine.SetIndex(_lvwJourSemaine_5, CType(5, Short))
		Me.lvwJourSemaine.SetIndex(_lvwJourSemaine_6, CType(6, Short))
		Me.lvwJourSemaine.SetIndex(_lvwJourSemaine_7, CType(7, Short))
		Me.optHeure.SetIndex(_optHeure_1, CType(1, Short))
		Me.optHeure.SetIndex(_optHeure_0, CType(0, Short))
		Me.optHeureDiner.SetIndex(_optHeureDiner_1, CType(1, Short))
		Me.optHeureDiner.SetIndex(_optHeureDiner_0, CType(0, Short))
		Me.optPMHeureDiner.SetIndex(_optPMHeureDiner_1, CType(1, Short))
		Me.optPMHeureDiner.SetIndex(_optPMHeureDiner_0, CType(0, Short))
		Me.optPMTypePunch.SetIndex(_optPMTypePunch_1, CType(1, Short))
		Me.optPMTypePunch.SetIndex(_optPMTypePunch_0, CType(0, Short))
		Me.optTypePunch.SetIndex(_optTypePunch_0, CType(0, Short))
		Me.optTypePunch.SetIndex(_optTypePunch_1, CType(1, Short))
		CType(Me.optTypePunch, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.optPMTypePunch, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.optPMHeureDiner, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.optHeureDiner, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.optHeure, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.lblNomJour, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.lblJour, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mvwSelection, System.ComponentModel.ISupportInitialize).EndInit()
		Me.fraJour.ResumeLayout(False)
		Me.lvwJour.ResumeLayout(False)
		Me.fraPunchMultiple.ResumeLayout(False)
		Me.Frame2.ResumeLayout(False)
		Me.lvwEmployes.ResumeLayout(False)
		Me.picTypePunch.ResumeLayout(False)
		Me.fraSemaine.ResumeLayout(False)
		Me._lvwJourSemaine_1.ResumeLayout(False)
		Me._lvwJourSemaine_2.ResumeLayout(False)
		Me._lvwJourSemaine_3.ResumeLayout(False)
		Me._lvwJourSemaine_4.ResumeLayout(False)
		Me._lvwJourSemaine_5.ResumeLayout(False)
		Me._lvwJourSemaine_6.ResumeLayout(False)
		Me._lvwJourSemaine_7.ResumeLayout(False)
		Me.fraPunch.ResumeLayout(False)
		Me.picPMTypePunch.ResumeLayout(False)
		Me.fraHeure.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class