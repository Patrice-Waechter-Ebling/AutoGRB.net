<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCédule
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
	Public WithEvents mvwSelection As AxMSComCtl2.AxMonthView
	Public WithEvents cmbfinprojet As System.Windows.Forms.ComboBox
	Public WithEvents __lstjoursemaine_1_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lstjoursemaine_1_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lstjoursemaine_1_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstjoursemaine_1 As System.Windows.Forms.ListView
	Public WithEvents __lstjoursemaine_2_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lstjoursemaine_2_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lstjoursemaine_2_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstjoursemaine_2 As System.Windows.Forms.ListView
	Public WithEvents __lstjoursemaine_3_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lstjoursemaine_3_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lstjoursemaine_3_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstjoursemaine_3 As System.Windows.Forms.ListView
	Public WithEvents __lstjoursemaine_4_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lstjoursemaine_4_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lstjoursemaine_4_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstjoursemaine_4 As System.Windows.Forms.ListView
	Public WithEvents __lstjoursemaine_5_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lstjoursemaine_5_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lstjoursemaine_5_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstjoursemaine_5 As System.Windows.Forms.ListView
	Public WithEvents __lstjoursemaine_6_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lstjoursemaine_6_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lstjoursemaine_6_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstjoursemaine_6 As System.Windows.Forms.ListView
	Public WithEvents __lstjoursemaine_7_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lstjoursemaine_7_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents __lstjoursemaine_7_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lstjoursemaine_7 As System.Windows.Forms.ListView
	Public WithEvents _lbljour_6 As System.Windows.Forms.Label
	Public WithEvents _lbljour_5 As System.Windows.Forms.Label
	Public WithEvents _lbljour_4 As System.Windows.Forms.Label
	Public WithEvents _lbljour_3 As System.Windows.Forms.Label
	Public WithEvents _lbljour_2 As System.Windows.Forms.Label
	Public WithEvents _lbljour_1 As System.Windows.Forms.Label
	Public WithEvents _lbljour_0 As System.Windows.Forms.Label
	Public WithEvents Line1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line6 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line5 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line4 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line3 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Line2 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents _lbljourstr_6 As System.Windows.Forms.Label
	Public WithEvents _lbljourstr_5 As System.Windows.Forms.Label
	Public WithEvents _lbljourstr_4 As System.Windows.Forms.Label
	Public WithEvents _lbljourstr_3 As System.Windows.Forms.Label
	Public WithEvents _lbljourstr_2 As System.Windows.Forms.Label
	Public WithEvents _lbljourstr_1 As System.Windows.Forms.Label
	Public WithEvents _lbljourstr_0 As System.Windows.Forms.Label
	Public WithEvents frasemaine As System.Windows.Forms.GroupBox
	Public WithEvents cmdAjouterAlarme As System.Windows.Forms.Button
	Public WithEvents mvwChoixDate As AxMSComCtl2.AxMonthView
	Public WithEvents cmdCopier As System.Windows.Forms.Button
	Public WithEvents cmdAjouterCédule As System.Windows.Forms.Button
	Public WithEvents cmdsupprimer As System.Windows.Forms.Button
	Public WithEvents _Lstjour_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _Lstjour_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _Lstjour_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _Lstjour_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _Lstjour_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _Lstjour_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents Lstjour As System.Windows.Forms.ListView
	Public WithEvents Label18 As System.Windows.Forms.Label
	Public WithEvents Label16 As System.Windows.Forms.Label
	Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents fraliste As System.Windows.Forms.GroupBox
	Public WithEvents cmdEnregistrerAlarme As System.Windows.Forms.Button
	Public WithEvents cmdAnnulerAlarme As System.Windows.Forms.Button
	Public WithEvents txtMessage As System.Windows.Forms.TextBox
	Public WithEvents mskHeure As System.Windows.Forms.MaskedTextBox
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents fraAlarme As System.Windows.Forms.GroupBox
	Public WithEvents cmdRafraichir As System.Windows.Forms.Button
	Public WithEvents cmdRechercher As System.Windows.Forms.Button
	Public WithEvents txtnoprojet As System.Windows.Forms.TextBox
	Public WithEvents chkfin As System.Windows.Forms.CheckBox
	Public WithEvents cmbclient As System.Windows.Forms.ComboBox
	Public WithEvents cmdtransport As System.Windows.Forms.Button
	Public WithEvents cmbtransport As System.Windows.Forms.ComboBox
	Public WithEvents cmdAnnulerCédule As System.Windows.Forms.Button
	Public WithEvents cmdEnregistrerCédule As System.Windows.Forms.Button
	Public WithEvents cmbheurefin As System.Windows.Forms.ComboBox
	Public WithEvents cmbheuredébut As System.Windows.Forms.ComboBox
	Public WithEvents cmbemployé As System.Windows.Forms.ComboBox
	Public WithEvents lblprojet As System.Windows.Forms.Label
	Public WithEvents lbltransport As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents frajour As System.Windows.Forms.GroupBox
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents lbljour As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lbljourstr As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lstjoursemaine As Microsoft.VisualBasic.Compatibility.VB6.ListViewArray
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCédule))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.mvwSelection = New AxMSComCtl2.AxMonthView
		Me.cmbfinprojet = New System.Windows.Forms.ComboBox
		Me.frasemaine = New System.Windows.Forms.GroupBox
		Me._lstjoursemaine_1 = New System.Windows.Forms.ListView
		Me.__lstjoursemaine_1_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.__lstjoursemaine_1_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me.__lstjoursemaine_1_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lstjoursemaine_2 = New System.Windows.Forms.ListView
		Me.__lstjoursemaine_2_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.__lstjoursemaine_2_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me.__lstjoursemaine_2_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lstjoursemaine_3 = New System.Windows.Forms.ListView
		Me.__lstjoursemaine_3_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.__lstjoursemaine_3_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me.__lstjoursemaine_3_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lstjoursemaine_4 = New System.Windows.Forms.ListView
		Me.__lstjoursemaine_4_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.__lstjoursemaine_4_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me.__lstjoursemaine_4_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lstjoursemaine_5 = New System.Windows.Forms.ListView
		Me.__lstjoursemaine_5_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.__lstjoursemaine_5_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me.__lstjoursemaine_5_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lstjoursemaine_6 = New System.Windows.Forms.ListView
		Me.__lstjoursemaine_6_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.__lstjoursemaine_6_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me.__lstjoursemaine_6_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lstjoursemaine_7 = New System.Windows.Forms.ListView
		Me.__lstjoursemaine_7_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.__lstjoursemaine_7_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me.__lstjoursemaine_7_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lbljour_6 = New System.Windows.Forms.Label
		Me._lbljour_5 = New System.Windows.Forms.Label
		Me._lbljour_4 = New System.Windows.Forms.Label
		Me._lbljour_3 = New System.Windows.Forms.Label
		Me._lbljour_2 = New System.Windows.Forms.Label
		Me._lbljour_1 = New System.Windows.Forms.Label
		Me._lbljour_0 = New System.Windows.Forms.Label
		Me.Line1 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me.Line6 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me.Line5 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me.Line4 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me.Line3 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me.Line2 = New Microsoft.VisualBasic.PowerPacks.LineShape
		Me._lbljourstr_6 = New System.Windows.Forms.Label
		Me._lbljourstr_5 = New System.Windows.Forms.Label
		Me._lbljourstr_4 = New System.Windows.Forms.Label
		Me._lbljourstr_3 = New System.Windows.Forms.Label
		Me._lbljourstr_2 = New System.Windows.Forms.Label
		Me._lbljourstr_1 = New System.Windows.Forms.Label
		Me._lbljourstr_0 = New System.Windows.Forms.Label
		Me.fraliste = New System.Windows.Forms.GroupBox
		Me.cmdAjouterAlarme = New System.Windows.Forms.Button
		Me.mvwChoixDate = New AxMSComCtl2.AxMonthView
		Me.cmdCopier = New System.Windows.Forms.Button
		Me.cmdAjouterCédule = New System.Windows.Forms.Button
		Me.cmdsupprimer = New System.Windows.Forms.Button
		Me.Lstjour = New System.Windows.Forms.ListView
		Me._Lstjour_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._Lstjour_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._Lstjour_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._Lstjour_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._Lstjour_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._Lstjour_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me.Label18 = New System.Windows.Forms.Label
		Me.Label16 = New System.Windows.Forms.Label
		Me.Label15 = New System.Windows.Forms.Label
		Me.Label14 = New System.Windows.Forms.Label
		Me.Label13 = New System.Windows.Forms.Label
		Me.fraAlarme = New System.Windows.Forms.GroupBox
		Me.cmdEnregistrerAlarme = New System.Windows.Forms.Button
		Me.cmdAnnulerAlarme = New System.Windows.Forms.Button
		Me.txtMessage = New System.Windows.Forms.TextBox
		Me.mskHeure = New System.Windows.Forms.MaskedTextBox
		Me.Label9 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.frajour = New System.Windows.Forms.GroupBox
		Me.cmdRafraichir = New System.Windows.Forms.Button
		Me.cmdRechercher = New System.Windows.Forms.Button
		Me.txtnoprojet = New System.Windows.Forms.TextBox
		Me.chkfin = New System.Windows.Forms.CheckBox
		Me.cmbclient = New System.Windows.Forms.ComboBox
		Me.cmdtransport = New System.Windows.Forms.Button
		Me.cmbtransport = New System.Windows.Forms.ComboBox
		Me.cmdAnnulerCédule = New System.Windows.Forms.Button
		Me.cmdEnregistrerCédule = New System.Windows.Forms.Button
		Me.cmbheurefin = New System.Windows.Forms.ComboBox
		Me.cmbheuredébut = New System.Windows.Forms.ComboBox
		Me.cmbemployé = New System.Windows.Forms.ComboBox
		Me.lblprojet = New System.Windows.Forms.Label
		Me.lbltransport = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label11 = New System.Windows.Forms.Label
		Me.lbljour = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.lbljourstr = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.lstjoursemaine = New Microsoft.VisualBasic.Compatibility.VB6.ListViewArray(components)
		Me.frasemaine.SuspendLayout()
		Me._lstjoursemaine_1.SuspendLayout()
		Me._lstjoursemaine_2.SuspendLayout()
		Me._lstjoursemaine_3.SuspendLayout()
		Me._lstjoursemaine_4.SuspendLayout()
		Me._lstjoursemaine_5.SuspendLayout()
		Me._lstjoursemaine_6.SuspendLayout()
		Me._lstjoursemaine_7.SuspendLayout()
		Me.fraliste.SuspendLayout()
		Me.Lstjour.SuspendLayout()
		Me.fraAlarme.SuspendLayout()
		Me.frajour.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.mvwSelection, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.mvwChoixDate, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.lbljour, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.lbljourstr, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Cédule"
		Me.ClientSize = New System.Drawing.Size(730, 505)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.Icon = CType(resources.GetObject("frmCédule.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmCédule.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "frmCédule"
		mvwSelection.OcxState = CType(resources.GetObject("mvwSelection.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwSelection.Size = New System.Drawing.Size(299, 268)
		Me.mvwSelection.Location = New System.Drawing.Point(16, 56)
		Me.mvwSelection.TabIndex = 39
		Me.mvwSelection.Name = "mvwSelection"
		Me.cmbfinprojet.BackColor = System.Drawing.Color.White
		Me.cmbfinprojet.Size = New System.Drawing.Size(121, 21)
		Me.cmbfinprojet.Location = New System.Drawing.Point(208, 24)
		Me.cmbfinprojet.TabIndex = 1
		Me.cmbfinprojet.Text = "cmbfinprojet"
		Me.cmbfinprojet.CausesValidation = True
		Me.cmbfinprojet.Enabled = True
		Me.cmbfinprojet.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbfinprojet.IntegralHeight = True
		Me.cmbfinprojet.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbfinprojet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbfinprojet.Sorted = False
		Me.cmbfinprojet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbfinprojet.TabStop = True
		Me.cmbfinprojet.Visible = True
		Me.cmbfinprojet.Name = "cmbfinprojet"
		Me.frasemaine.BackColor = System.Drawing.Color.FromARGB(64, 64, 64)
		Me.frasemaine.Size = New System.Drawing.Size(729, 177)
		Me.frasemaine.Location = New System.Drawing.Point(0, 328)
		Me.frasemaine.TabIndex = 40
		Me.frasemaine.Enabled = True
		Me.frasemaine.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frasemaine.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frasemaine.Visible = True
		Me.frasemaine.Padding = New System.Windows.Forms.Padding(0)
		Me.frasemaine.Name = "frasemaine"
		Me._lstjoursemaine_1.Size = New System.Drawing.Size(105, 127)
		Me._lstjoursemaine_1.Location = New System.Drawing.Point(0, 48)
		Me._lstjoursemaine_1.TabIndex = 55
		Me._lstjoursemaine_1.View = System.Windows.Forms.View.Details
		Me._lstjoursemaine_1.LabelEdit = False
		Me._lstjoursemaine_1.LabelWrap = True
		Me._lstjoursemaine_1.HideSelection = True
		Me._lstjoursemaine_1.FullRowSelect = True
		Me._lstjoursemaine_1.GridLines = True
		Me._lstjoursemaine_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lstjoursemaine_1.BackColor = System.Drawing.Color.White
		Me._lstjoursemaine_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lstjoursemaine_1.Name = "_lstjoursemaine_1"
		Me.__lstjoursemaine_1_ColumnHeader_1.Text = "no"
		Me.__lstjoursemaine_1_ColumnHeader_1.Width = 0
		Me.__lstjoursemaine_1_ColumnHeader_2.Text = "nom"
		Me.__lstjoursemaine_1_ColumnHeader_2.Width = 53
		Me.__lstjoursemaine_1_ColumnHeader_3.Text = "heure"
		Me.__lstjoursemaine_1_ColumnHeader_3.Width = 118
		Me._lstjoursemaine_2.Size = New System.Drawing.Size(105, 127)
		Me._lstjoursemaine_2.Location = New System.Drawing.Point(104, 48)
		Me._lstjoursemaine_2.TabIndex = 56
		Me._lstjoursemaine_2.View = System.Windows.Forms.View.Details
		Me._lstjoursemaine_2.LabelEdit = False
		Me._lstjoursemaine_2.LabelWrap = True
		Me._lstjoursemaine_2.HideSelection = True
		Me._lstjoursemaine_2.FullRowSelect = True
		Me._lstjoursemaine_2.GridLines = True
		Me._lstjoursemaine_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lstjoursemaine_2.BackColor = System.Drawing.Color.White
		Me._lstjoursemaine_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lstjoursemaine_2.Name = "_lstjoursemaine_2"
		Me.__lstjoursemaine_2_ColumnHeader_1.Text = "no"
		Me.__lstjoursemaine_2_ColumnHeader_1.Width = 0
		Me.__lstjoursemaine_2_ColumnHeader_2.Text = "nom"
		Me.__lstjoursemaine_2_ColumnHeader_2.Width = 53
		Me.__lstjoursemaine_2_ColumnHeader_3.Text = "heure"
		Me.__lstjoursemaine_2_ColumnHeader_3.Width = 118
		Me._lstjoursemaine_3.Size = New System.Drawing.Size(105, 127)
		Me._lstjoursemaine_3.Location = New System.Drawing.Point(208, 48)
		Me._lstjoursemaine_3.TabIndex = 57
		Me._lstjoursemaine_3.View = System.Windows.Forms.View.Details
		Me._lstjoursemaine_3.LabelEdit = False
		Me._lstjoursemaine_3.LabelWrap = True
		Me._lstjoursemaine_3.HideSelection = True
		Me._lstjoursemaine_3.FullRowSelect = True
		Me._lstjoursemaine_3.GridLines = True
		Me._lstjoursemaine_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lstjoursemaine_3.BackColor = System.Drawing.Color.White
		Me._lstjoursemaine_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lstjoursemaine_3.Name = "_lstjoursemaine_3"
		Me.__lstjoursemaine_3_ColumnHeader_1.Text = "no"
		Me.__lstjoursemaine_3_ColumnHeader_1.Width = 0
		Me.__lstjoursemaine_3_ColumnHeader_2.Text = "nom"
		Me.__lstjoursemaine_3_ColumnHeader_2.Width = 53
		Me.__lstjoursemaine_3_ColumnHeader_3.Text = "heure"
		Me.__lstjoursemaine_3_ColumnHeader_3.Width = 118
		Me._lstjoursemaine_4.Size = New System.Drawing.Size(105, 127)
		Me._lstjoursemaine_4.Location = New System.Drawing.Point(312, 48)
		Me._lstjoursemaine_4.TabIndex = 58
		Me._lstjoursemaine_4.View = System.Windows.Forms.View.Details
		Me._lstjoursemaine_4.LabelEdit = False
		Me._lstjoursemaine_4.LabelWrap = True
		Me._lstjoursemaine_4.HideSelection = True
		Me._lstjoursemaine_4.FullRowSelect = True
		Me._lstjoursemaine_4.GridLines = True
		Me._lstjoursemaine_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lstjoursemaine_4.BackColor = System.Drawing.Color.White
		Me._lstjoursemaine_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lstjoursemaine_4.Name = "_lstjoursemaine_4"
		Me.__lstjoursemaine_4_ColumnHeader_1.Text = "no"
		Me.__lstjoursemaine_4_ColumnHeader_1.Width = 0
		Me.__lstjoursemaine_4_ColumnHeader_2.Text = "nom"
		Me.__lstjoursemaine_4_ColumnHeader_2.Width = 53
		Me.__lstjoursemaine_4_ColumnHeader_3.Text = "heure"
		Me.__lstjoursemaine_4_ColumnHeader_3.Width = 118
		Me._lstjoursemaine_5.Size = New System.Drawing.Size(105, 127)
		Me._lstjoursemaine_5.Location = New System.Drawing.Point(416, 48)
		Me._lstjoursemaine_5.TabIndex = 59
		Me._lstjoursemaine_5.View = System.Windows.Forms.View.Details
		Me._lstjoursemaine_5.LabelEdit = False
		Me._lstjoursemaine_5.LabelWrap = True
		Me._lstjoursemaine_5.HideSelection = True
		Me._lstjoursemaine_5.FullRowSelect = True
		Me._lstjoursemaine_5.GridLines = True
		Me._lstjoursemaine_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lstjoursemaine_5.BackColor = System.Drawing.Color.White
		Me._lstjoursemaine_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lstjoursemaine_5.Name = "_lstjoursemaine_5"
		Me.__lstjoursemaine_5_ColumnHeader_1.Text = "no"
		Me.__lstjoursemaine_5_ColumnHeader_1.Width = 0
		Me.__lstjoursemaine_5_ColumnHeader_2.Text = "nom"
		Me.__lstjoursemaine_5_ColumnHeader_2.Width = 53
		Me.__lstjoursemaine_5_ColumnHeader_3.Text = "heure"
		Me.__lstjoursemaine_5_ColumnHeader_3.Width = 118
		Me._lstjoursemaine_6.Size = New System.Drawing.Size(105, 127)
		Me._lstjoursemaine_6.Location = New System.Drawing.Point(520, 48)
		Me._lstjoursemaine_6.TabIndex = 60
		Me._lstjoursemaine_6.View = System.Windows.Forms.View.Details
		Me._lstjoursemaine_6.LabelEdit = False
		Me._lstjoursemaine_6.LabelWrap = True
		Me._lstjoursemaine_6.HideSelection = True
		Me._lstjoursemaine_6.FullRowSelect = True
		Me._lstjoursemaine_6.GridLines = True
		Me._lstjoursemaine_6.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lstjoursemaine_6.BackColor = System.Drawing.Color.White
		Me._lstjoursemaine_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lstjoursemaine_6.Name = "_lstjoursemaine_6"
		Me.__lstjoursemaine_6_ColumnHeader_1.Text = "no"
		Me.__lstjoursemaine_6_ColumnHeader_1.Width = 0
		Me.__lstjoursemaine_6_ColumnHeader_2.Text = "nom"
		Me.__lstjoursemaine_6_ColumnHeader_2.Width = 53
		Me.__lstjoursemaine_6_ColumnHeader_3.Text = "heure"
		Me.__lstjoursemaine_6_ColumnHeader_3.Width = 118
		Me._lstjoursemaine_7.Size = New System.Drawing.Size(105, 127)
		Me._lstjoursemaine_7.Location = New System.Drawing.Point(624, 48)
		Me._lstjoursemaine_7.TabIndex = 61
		Me._lstjoursemaine_7.View = System.Windows.Forms.View.Details
		Me._lstjoursemaine_7.LabelEdit = False
		Me._lstjoursemaine_7.LabelWrap = True
		Me._lstjoursemaine_7.HideSelection = True
		Me._lstjoursemaine_7.FullRowSelect = True
		Me._lstjoursemaine_7.GridLines = True
		Me._lstjoursemaine_7.ForeColor = System.Drawing.SystemColors.WindowText
		Me._lstjoursemaine_7.BackColor = System.Drawing.Color.White
		Me._lstjoursemaine_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._lstjoursemaine_7.Name = "_lstjoursemaine_7"
		Me.__lstjoursemaine_7_ColumnHeader_1.Text = "no"
		Me.__lstjoursemaine_7_ColumnHeader_1.Width = 0
		Me.__lstjoursemaine_7_ColumnHeader_2.Text = "nom"
		Me.__lstjoursemaine_7_ColumnHeader_2.Width = 53
		Me.__lstjoursemaine_7_ColumnHeader_3.Text = "heure"
		Me.__lstjoursemaine_7_ColumnHeader_3.Width = 118
		Me._lbljour_6.ForeColor = System.Drawing.Color.White
		Me._lbljour_6.Size = New System.Drawing.Size(33, 17)
		Me._lbljour_6.Location = New System.Drawing.Point(669, 24)
		Me._lbljour_6.TabIndex = 53
		Me._lbljour_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbljour_6.BackColor = System.Drawing.Color.Transparent
		Me._lbljour_6.Enabled = True
		Me._lbljour_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbljour_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbljour_6.UseMnemonic = True
		Me._lbljour_6.Visible = True
		Me._lbljour_6.AutoSize = False
		Me._lbljour_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbljour_6.Name = "_lbljour_6"
		Me._lbljour_5.ForeColor = System.Drawing.Color.White
		Me._lbljour_5.Size = New System.Drawing.Size(33, 17)
		Me._lbljour_5.Location = New System.Drawing.Point(565, 24)
		Me._lbljour_5.TabIndex = 51
		Me._lbljour_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbljour_5.BackColor = System.Drawing.Color.Transparent
		Me._lbljour_5.Enabled = True
		Me._lbljour_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbljour_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbljour_5.UseMnemonic = True
		Me._lbljour_5.Visible = True
		Me._lbljour_5.AutoSize = False
		Me._lbljour_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbljour_5.Name = "_lbljour_5"
		Me._lbljour_4.ForeColor = System.Drawing.Color.White
		Me._lbljour_4.Size = New System.Drawing.Size(33, 17)
		Me._lbljour_4.Location = New System.Drawing.Point(461, 24)
		Me._lbljour_4.TabIndex = 49
		Me._lbljour_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbljour_4.BackColor = System.Drawing.Color.Transparent
		Me._lbljour_4.Enabled = True
		Me._lbljour_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbljour_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbljour_4.UseMnemonic = True
		Me._lbljour_4.Visible = True
		Me._lbljour_4.AutoSize = False
		Me._lbljour_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbljour_4.Name = "_lbljour_4"
		Me._lbljour_3.ForeColor = System.Drawing.Color.White
		Me._lbljour_3.Size = New System.Drawing.Size(33, 17)
		Me._lbljour_3.Location = New System.Drawing.Point(357, 24)
		Me._lbljour_3.TabIndex = 47
		Me._lbljour_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbljour_3.BackColor = System.Drawing.Color.Transparent
		Me._lbljour_3.Enabled = True
		Me._lbljour_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbljour_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbljour_3.UseMnemonic = True
		Me._lbljour_3.Visible = True
		Me._lbljour_3.AutoSize = False
		Me._lbljour_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbljour_3.Name = "_lbljour_3"
		Me._lbljour_2.ForeColor = System.Drawing.Color.White
		Me._lbljour_2.Size = New System.Drawing.Size(33, 17)
		Me._lbljour_2.Location = New System.Drawing.Point(253, 24)
		Me._lbljour_2.TabIndex = 46
		Me._lbljour_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbljour_2.BackColor = System.Drawing.Color.Transparent
		Me._lbljour_2.Enabled = True
		Me._lbljour_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbljour_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbljour_2.UseMnemonic = True
		Me._lbljour_2.Visible = True
		Me._lbljour_2.AutoSize = False
		Me._lbljour_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbljour_2.Name = "_lbljour_2"
		Me._lbljour_1.ForeColor = System.Drawing.Color.White
		Me._lbljour_1.Size = New System.Drawing.Size(33, 17)
		Me._lbljour_1.Location = New System.Drawing.Point(149, 24)
		Me._lbljour_1.TabIndex = 43
		Me._lbljour_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbljour_1.BackColor = System.Drawing.Color.Transparent
		Me._lbljour_1.Enabled = True
		Me._lbljour_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbljour_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbljour_1.UseMnemonic = True
		Me._lbljour_1.Visible = True
		Me._lbljour_1.AutoSize = False
		Me._lbljour_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbljour_1.Name = "_lbljour_1"
		Me._lbljour_0.ForeColor = System.Drawing.Color.White
		Me._lbljour_0.Size = New System.Drawing.Size(33, 17)
		Me._lbljour_0.Location = New System.Drawing.Point(45, 24)
		Me._lbljour_0.TabIndex = 42
		Me._lbljour_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbljour_0.BackColor = System.Drawing.Color.Transparent
		Me._lbljour_0.Enabled = True
		Me._lbljour_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbljour_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbljour_0.UseMnemonic = True
		Me._lbljour_0.Visible = True
		Me._lbljour_0.AutoSize = False
		Me._lbljour_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbljour_0.Name = "_lbljour_0"
		Me.Line1.BorderColor = System.Drawing.Color.White
		Me.Line1.X1 = 104
		Me.Line1.X2 = 104
		Me.Line1.Y1 = 11
		Me.Line1.Y2 = 155
		Me.Line1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Line1.BorderWidth = 1
		Me.Line1.Visible = True
		Me.Line1.Name = "Line1"
		Me.Line6.BorderColor = System.Drawing.Color.White
		Me.Line6.X1 = 624
		Me.Line6.X2 = 624
		Me.Line6.Y1 = 11
		Me.Line6.Y2 = 155
		Me.Line6.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Line6.BorderWidth = 1
		Me.Line6.Visible = True
		Me.Line6.Name = "Line6"
		Me.Line5.BorderColor = System.Drawing.Color.White
		Me.Line5.X1 = 520
		Me.Line5.X2 = 520
		Me.Line5.Y1 = 11
		Me.Line5.Y2 = 155
		Me.Line5.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Line5.BorderWidth = 1
		Me.Line5.Visible = True
		Me.Line5.Name = "Line5"
		Me.Line4.BorderColor = System.Drawing.Color.White
		Me.Line4.X1 = 416
		Me.Line4.X2 = 416
		Me.Line4.Y1 = 11
		Me.Line4.Y2 = 155
		Me.Line4.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Line4.BorderWidth = 1
		Me.Line4.Visible = True
		Me.Line4.Name = "Line4"
		Me.Line3.BorderColor = System.Drawing.Color.White
		Me.Line3.X1 = 312
		Me.Line3.X2 = 312
		Me.Line3.Y1 = 11
		Me.Line3.Y2 = 155
		Me.Line3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Line3.BorderWidth = 1
		Me.Line3.Visible = True
		Me.Line3.Name = "Line3"
		Me.Line2.BorderColor = System.Drawing.Color.White
		Me.Line2.X1 = 208
		Me.Line2.X2 = 208
		Me.Line2.Y1 = 11
		Me.Line2.Y2 = 155
		Me.Line2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Line2.BorderWidth = 1
		Me.Line2.Visible = True
		Me.Line2.Name = "Line2"
		Me._lbljourstr_6.Text = "Sam"
		Me._lbljourstr_6.ForeColor = System.Drawing.Color.White
		Me._lbljourstr_6.Size = New System.Drawing.Size(41, 17)
		Me._lbljourstr_6.Location = New System.Drawing.Point(632, 24)
		Me._lbljourstr_6.TabIndex = 54
		Me._lbljourstr_6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbljourstr_6.BackColor = System.Drawing.Color.Transparent
		Me._lbljourstr_6.Enabled = True
		Me._lbljourstr_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbljourstr_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbljourstr_6.UseMnemonic = True
		Me._lbljourstr_6.Visible = True
		Me._lbljourstr_6.AutoSize = False
		Me._lbljourstr_6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbljourstr_6.Name = "_lbljourstr_6"
		Me._lbljourstr_5.Text = "Ven"
		Me._lbljourstr_5.ForeColor = System.Drawing.Color.White
		Me._lbljourstr_5.Size = New System.Drawing.Size(41, 17)
		Me._lbljourstr_5.Location = New System.Drawing.Point(528, 24)
		Me._lbljourstr_5.TabIndex = 52
		Me._lbljourstr_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbljourstr_5.BackColor = System.Drawing.Color.Transparent
		Me._lbljourstr_5.Enabled = True
		Me._lbljourstr_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbljourstr_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbljourstr_5.UseMnemonic = True
		Me._lbljourstr_5.Visible = True
		Me._lbljourstr_5.AutoSize = False
		Me._lbljourstr_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbljourstr_5.Name = "_lbljourstr_5"
		Me._lbljourstr_4.Text = "Jeu"
		Me._lbljourstr_4.ForeColor = System.Drawing.Color.White
		Me._lbljourstr_4.Size = New System.Drawing.Size(41, 17)
		Me._lbljourstr_4.Location = New System.Drawing.Point(424, 24)
		Me._lbljourstr_4.TabIndex = 50
		Me._lbljourstr_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbljourstr_4.BackColor = System.Drawing.Color.Transparent
		Me._lbljourstr_4.Enabled = True
		Me._lbljourstr_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbljourstr_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbljourstr_4.UseMnemonic = True
		Me._lbljourstr_4.Visible = True
		Me._lbljourstr_4.AutoSize = False
		Me._lbljourstr_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbljourstr_4.Name = "_lbljourstr_4"
		Me._lbljourstr_3.Text = "Mer"
		Me._lbljourstr_3.ForeColor = System.Drawing.Color.White
		Me._lbljourstr_3.Size = New System.Drawing.Size(41, 17)
		Me._lbljourstr_3.Location = New System.Drawing.Point(320, 24)
		Me._lbljourstr_3.TabIndex = 48
		Me._lbljourstr_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbljourstr_3.BackColor = System.Drawing.Color.Transparent
		Me._lbljourstr_3.Enabled = True
		Me._lbljourstr_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbljourstr_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbljourstr_3.UseMnemonic = True
		Me._lbljourstr_3.Visible = True
		Me._lbljourstr_3.AutoSize = False
		Me._lbljourstr_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbljourstr_3.Name = "_lbljourstr_3"
		Me._lbljourstr_2.Text = "Mar"
		Me._lbljourstr_2.ForeColor = System.Drawing.Color.White
		Me._lbljourstr_2.Size = New System.Drawing.Size(41, 17)
		Me._lbljourstr_2.Location = New System.Drawing.Point(216, 24)
		Me._lbljourstr_2.TabIndex = 45
		Me._lbljourstr_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbljourstr_2.BackColor = System.Drawing.Color.Transparent
		Me._lbljourstr_2.Enabled = True
		Me._lbljourstr_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbljourstr_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbljourstr_2.UseMnemonic = True
		Me._lbljourstr_2.Visible = True
		Me._lbljourstr_2.AutoSize = False
		Me._lbljourstr_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbljourstr_2.Name = "_lbljourstr_2"
		Me._lbljourstr_1.Text = "Lun"
		Me._lbljourstr_1.ForeColor = System.Drawing.Color.White
		Me._lbljourstr_1.Size = New System.Drawing.Size(41, 17)
		Me._lbljourstr_1.Location = New System.Drawing.Point(112, 24)
		Me._lbljourstr_1.TabIndex = 44
		Me._lbljourstr_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbljourstr_1.BackColor = System.Drawing.Color.Transparent
		Me._lbljourstr_1.Enabled = True
		Me._lbljourstr_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbljourstr_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbljourstr_1.UseMnemonic = True
		Me._lbljourstr_1.Visible = True
		Me._lbljourstr_1.AutoSize = False
		Me._lbljourstr_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbljourstr_1.Name = "_lbljourstr_1"
		Me._lbljourstr_0.Text = "Dim"
		Me._lbljourstr_0.ForeColor = System.Drawing.Color.White
		Me._lbljourstr_0.Size = New System.Drawing.Size(41, 17)
		Me._lbljourstr_0.Location = New System.Drawing.Point(8, 24)
		Me._lbljourstr_0.TabIndex = 41
		Me._lbljourstr_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lbljourstr_0.BackColor = System.Drawing.Color.Transparent
		Me._lbljourstr_0.Enabled = True
		Me._lbljourstr_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lbljourstr_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lbljourstr_0.UseMnemonic = True
		Me._lbljourstr_0.Visible = True
		Me._lbljourstr_0.AutoSize = False
		Me._lbljourstr_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lbljourstr_0.Name = "_lbljourstr_0"
		Me.fraliste.BackColor = System.Drawing.Color.FromARGB(192, 192, 192)
		Me.fraliste.Size = New System.Drawing.Size(393, 297)
		Me.fraliste.Location = New System.Drawing.Point(336, 24)
		Me.fraliste.TabIndex = 2
		Me.fraliste.Enabled = True
		Me.fraliste.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraliste.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraliste.Visible = True
		Me.fraliste.Padding = New System.Windows.Forms.Padding(0)
		Me.fraliste.Name = "fraliste"
		Me.cmdAjouterAlarme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAjouterAlarme.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAjouterAlarme.Text = "Ajouter Alarme"
		Me.cmdAjouterAlarme.Size = New System.Drawing.Size(97, 33)
		Me.cmdAjouterAlarme.Location = New System.Drawing.Point(8, 256)
		Me.cmdAjouterAlarme.TabIndex = 10
		Me.cmdAjouterAlarme.CausesValidation = True
		Me.cmdAjouterAlarme.Enabled = True
		Me.cmdAjouterAlarme.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAjouterAlarme.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAjouterAlarme.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAjouterAlarme.TabStop = True
		Me.cmdAjouterAlarme.Name = "cmdAjouterAlarme"
		mvwChoixDate.OcxState = CType(resources.GetObject("mvwChoixDate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwChoixDate.Size = New System.Drawing.Size(222, 188)
		Me.mvwChoixDate.Location = New System.Drawing.Point(104, 40)
		Me.mvwChoixDate.TabIndex = 9
		Me.mvwChoixDate.Visible = False
		Me.mvwChoixDate.Name = "mvwChoixDate"
		Me.cmdCopier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCopier.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCopier.Text = "Copier"
		Me.cmdCopier.Size = New System.Drawing.Size(81, 33)
		Me.cmdCopier.Location = New System.Drawing.Point(304, 256)
		Me.cmdCopier.TabIndex = 13
		Me.cmdCopier.CausesValidation = True
		Me.cmdCopier.Enabled = True
		Me.cmdCopier.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCopier.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCopier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCopier.TabStop = True
		Me.cmdCopier.Name = "cmdCopier"
		Me.cmdAjouterCédule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAjouterCédule.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAjouterCédule.Text = "Ajouter Cédule"
		Me.cmdAjouterCédule.Size = New System.Drawing.Size(97, 33)
		Me.cmdAjouterCédule.Location = New System.Drawing.Point(112, 256)
		Me.cmdAjouterCédule.TabIndex = 11
		Me.cmdAjouterCédule.CausesValidation = True
		Me.cmdAjouterCédule.Enabled = True
		Me.cmdAjouterCédule.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAjouterCédule.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAjouterCédule.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAjouterCédule.TabStop = True
		Me.cmdAjouterCédule.Name = "cmdAjouterCédule"
		Me.cmdsupprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdsupprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdsupprimer.Text = "Supprimer"
		Me.cmdsupprimer.Size = New System.Drawing.Size(81, 33)
		Me.cmdsupprimer.Location = New System.Drawing.Point(216, 256)
		Me.cmdsupprimer.TabIndex = 12
		Me.cmdsupprimer.CausesValidation = True
		Me.cmdsupprimer.Enabled = True
		Me.cmdsupprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdsupprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdsupprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdsupprimer.TabStop = True
		Me.cmdsupprimer.Name = "cmdsupprimer"
		Me.Lstjour.Size = New System.Drawing.Size(393, 225)
		Me.Lstjour.Location = New System.Drawing.Point(0, 24)
		Me.Lstjour.TabIndex = 8
		Me.Lstjour.View = System.Windows.Forms.View.Details
		Me.Lstjour.LabelEdit = False
		Me.Lstjour.MultiSelect = True
		Me.Lstjour.LabelWrap = True
		Me.Lstjour.HideSelection = True
		Me.Lstjour.FullRowSelect = True
		Me.Lstjour.GridLines = True
		Me.Lstjour.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Lstjour.BackColor = System.Drawing.Color.White
		Me.Lstjour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Lstjour.Name = "Lstjour"
		Me._Lstjour_ColumnHeader_1.Text = "no"
		Me._Lstjour_ColumnHeader_1.Width = 0
		Me._Lstjour_ColumnHeader_2.Text = "nom"
		Me._Lstjour_ColumnHeader_2.Width = 89
		Me._Lstjour_ColumnHeader_3.Text = "début"
		Me._Lstjour_ColumnHeader_3.Width = 89
		Me._Lstjour_ColumnHeader_4.Text = "fin"
		Me._Lstjour_ColumnHeader_4.Width = 89
		Me._Lstjour_ColumnHeader_5.Text = "client"
		Me._Lstjour_ColumnHeader_5.Width = 247
		Me._Lstjour_ColumnHeader_6.Text = "Tansport"
		Me._Lstjour_ColumnHeader_6.Width = 170
		Me.Label18.Text = "Transport / Projet"
		Me.Label18.ForeColor = System.Drawing.Color.Black
		Me.Label18.Size = New System.Drawing.Size(89, 17)
		Me.Label18.Location = New System.Drawing.Point(304, 8)
		Me.Label18.TabIndex = 7
		Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label18.BackColor = System.Drawing.Color.Transparent
		Me.Label18.Enabled = True
		Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label18.UseMnemonic = True
		Me.Label18.Visible = True
		Me.Label18.AutoSize = False
		Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label18.Name = "Label18"
		Me.Label16.Text = "Client"
		Me.Label16.ForeColor = System.Drawing.Color.Black
		Me.Label16.Size = New System.Drawing.Size(49, 17)
		Me.Label16.Location = New System.Drawing.Point(200, 8)
		Me.Label16.TabIndex = 6
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
		Me.Label15.Text = "Fin"
		Me.Label15.ForeColor = System.Drawing.Color.Black
		Me.Label15.Size = New System.Drawing.Size(49, 17)
		Me.Label15.Location = New System.Drawing.Point(112, 8)
		Me.Label15.TabIndex = 5
		Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label15.BackColor = System.Drawing.Color.Transparent
		Me.Label15.Enabled = True
		Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label15.UseMnemonic = True
		Me.Label15.Visible = True
		Me.Label15.AutoSize = False
		Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label15.Name = "Label15"
		Me.Label14.Text = "Début"
		Me.Label14.ForeColor = System.Drawing.Color.Black
		Me.Label14.Size = New System.Drawing.Size(49, 17)
		Me.Label14.Location = New System.Drawing.Point(56, 8)
		Me.Label14.TabIndex = 4
		Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label14.BackColor = System.Drawing.Color.Transparent
		Me.Label14.Enabled = True
		Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label14.UseMnemonic = True
		Me.Label14.Visible = True
		Me.Label14.AutoSize = False
		Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label14.Name = "Label14"
		Me.Label13.Text = "Nom"
		Me.Label13.ForeColor = System.Drawing.Color.Black
		Me.Label13.Size = New System.Drawing.Size(49, 17)
		Me.Label13.Location = New System.Drawing.Point(8, 8)
		Me.Label13.TabIndex = 3
		Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label13.BackColor = System.Drawing.Color.Transparent
		Me.Label13.Enabled = True
		Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label13.UseMnemonic = True
		Me.Label13.Visible = True
		Me.Label13.AutoSize = False
		Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label13.Name = "Label13"
		Me.fraAlarme.Size = New System.Drawing.Size(393, 297)
		Me.fraAlarme.Location = New System.Drawing.Point(336, 24)
		Me.fraAlarme.TabIndex = 32
		Me.fraAlarme.Visible = False
		Me.fraAlarme.BackColor = System.Drawing.SystemColors.Control
		Me.fraAlarme.Enabled = True
		Me.fraAlarme.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraAlarme.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraAlarme.Padding = New System.Windows.Forms.Padding(0)
		Me.fraAlarme.Name = "fraAlarme"
		Me.cmdEnregistrerAlarme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEnregistrerAlarme.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEnregistrerAlarme.Text = "Enregistrer"
		Me.cmdEnregistrerAlarme.Size = New System.Drawing.Size(97, 33)
		Me.cmdEnregistrerAlarme.Location = New System.Drawing.Point(16, 248)
		Me.cmdEnregistrerAlarme.TabIndex = 37
		Me.cmdEnregistrerAlarme.CausesValidation = True
		Me.cmdEnregistrerAlarme.Enabled = True
		Me.cmdEnregistrerAlarme.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEnregistrerAlarme.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEnregistrerAlarme.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEnregistrerAlarme.TabStop = True
		Me.cmdEnregistrerAlarme.Name = "cmdEnregistrerAlarme"
		Me.cmdAnnulerAlarme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnulerAlarme.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnulerAlarme.Text = "Annuler"
		Me.cmdAnnulerAlarme.Size = New System.Drawing.Size(97, 33)
		Me.cmdAnnulerAlarme.Location = New System.Drawing.Point(240, 248)
		Me.cmdAnnulerAlarme.TabIndex = 38
		Me.cmdAnnulerAlarme.CausesValidation = True
		Me.cmdAnnulerAlarme.Enabled = True
		Me.cmdAnnulerAlarme.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnulerAlarme.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnulerAlarme.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnulerAlarme.TabStop = True
		Me.cmdAnnulerAlarme.Name = "cmdAnnulerAlarme"
		Me.txtMessage.AutoSize = False
		Me.txtMessage.Size = New System.Drawing.Size(257, 67)
		Me.txtMessage.Location = New System.Drawing.Point(80, 64)
		Me.txtMessage.MultiLine = True
		Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtMessage.TabIndex = 35
		Me.txtMessage.AcceptsReturn = True
		Me.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMessage.BackColor = System.Drawing.SystemColors.Window
		Me.txtMessage.CausesValidation = True
		Me.txtMessage.Enabled = True
		Me.txtMessage.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMessage.HideSelection = True
		Me.txtMessage.ReadOnly = False
		Me.txtMessage.Maxlength = 0
		Me.txtMessage.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMessage.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMessage.TabStop = True
		Me.txtMessage.Visible = True
		Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMessage.Name = "txtMessage"
		Me.mskHeure.AllowPromptAsInput = False
		Me.mskHeure.Size = New System.Drawing.Size(73, 17)
		Me.mskHeure.Location = New System.Drawing.Point(80, 32)
		Me.mskHeure.TabIndex = 34
		Me.mskHeure.PromptChar = "_"
		Me.mskHeure.Name = "mskHeure"
		Me.Label9.Text = "Message :"
		Me.Label9.Size = New System.Drawing.Size(57, 17)
		Me.Label9.Location = New System.Drawing.Point(24, 64)
		Me.Label9.TabIndex = 36
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label9.BackColor = System.Drawing.SystemColors.Control
		Me.Label9.Enabled = True
		Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label9.UseMnemonic = True
		Me.Label9.Visible = True
		Me.Label9.AutoSize = False
		Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label9.Name = "Label9"
		Me.Label7.Text = "Heure :"
		Me.Label7.ForeColor = System.Drawing.Color.Black
		Me.Label7.Size = New System.Drawing.Size(41, 17)
		Me.Label7.Location = New System.Drawing.Point(24, 32)
		Me.Label7.TabIndex = 33
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
		Me.frajour.Size = New System.Drawing.Size(393, 297)
		Me.frajour.Location = New System.Drawing.Point(336, 24)
		Me.frajour.TabIndex = 14
		Me.frajour.Visible = False
		Me.frajour.BackColor = System.Drawing.SystemColors.Control
		Me.frajour.Enabled = True
		Me.frajour.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frajour.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frajour.Padding = New System.Windows.Forms.Padding(0)
		Me.frajour.Name = "frajour"
		Me.cmdRafraichir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRafraichir.Text = "Rafraîchir"
		Me.cmdRafraichir.Size = New System.Drawing.Size(73, 19)
		Me.cmdRafraichir.Location = New System.Drawing.Point(312, 208)
		Me.cmdRafraichir.TabIndex = 64
		Me.cmdRafraichir.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRafraichir.CausesValidation = True
		Me.cmdRafraichir.Enabled = True
		Me.cmdRafraichir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRafraichir.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRafraichir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRafraichir.TabStop = True
		Me.cmdRafraichir.Name = "cmdRafraichir"
		Me.cmdRechercher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRechercher.Text = "Rechercher"
		Me.cmdRechercher.Size = New System.Drawing.Size(73, 19)
		Me.cmdRechercher.Location = New System.Drawing.Point(312, 184)
		Me.cmdRechercher.TabIndex = 63
		Me.cmdRechercher.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRechercher.CausesValidation = True
		Me.cmdRechercher.Enabled = True
		Me.cmdRechercher.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRechercher.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRechercher.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRechercher.TabStop = True
		Me.cmdRechercher.Name = "cmdRechercher"
		Me.txtnoprojet.AutoSize = False
		Me.txtnoprojet.BackColor = System.Drawing.Color.White
		Me.txtnoprojet.Size = New System.Drawing.Size(145, 19)
		Me.txtnoprojet.Location = New System.Drawing.Point(72, 112)
		Me.txtnoprojet.TabIndex = 24
		Me.txtnoprojet.AcceptsReturn = True
		Me.txtnoprojet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtnoprojet.CausesValidation = True
		Me.txtnoprojet.Enabled = True
		Me.txtnoprojet.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtnoprojet.HideSelection = True
		Me.txtnoprojet.ReadOnly = False
		Me.txtnoprojet.Maxlength = 0
		Me.txtnoprojet.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtnoprojet.MultiLine = False
		Me.txtnoprojet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtnoprojet.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtnoprojet.TabStop = True
		Me.txtnoprojet.Visible = True
		Me.txtnoprojet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtnoprojet.Name = "txtnoprojet"
		Me.chkfin.Text = "Fin Projet"
		Me.chkfin.ForeColor = System.Drawing.Color.Black
		Me.chkfin.Size = New System.Drawing.Size(57, 25)
		Me.chkfin.Location = New System.Drawing.Point(272, 112)
		Me.chkfin.TabIndex = 27
		Me.chkfin.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkfin.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkfin.BackColor = System.Drawing.SystemColors.Control
		Me.chkfin.CausesValidation = True
		Me.chkfin.Enabled = True
		Me.chkfin.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkfin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkfin.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkfin.TabStop = True
		Me.chkfin.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkfin.Visible = True
		Me.chkfin.Name = "chkfin"
		Me.cmbclient.BackColor = System.Drawing.Color.White
		Me.cmbclient.Size = New System.Drawing.Size(313, 21)
		Me.cmbclient.Location = New System.Drawing.Point(72, 152)
		Me.cmbclient.TabIndex = 28
		Me.cmbclient.CausesValidation = True
		Me.cmbclient.Enabled = True
		Me.cmbclient.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbclient.IntegralHeight = True
		Me.cmbclient.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbclient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbclient.Sorted = False
		Me.cmbclient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbclient.TabStop = True
		Me.cmbclient.Visible = True
		Me.cmbclient.Name = "cmbclient"
		Me.cmdtransport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdtransport.Text = "..."
		Me.cmdtransport.Size = New System.Drawing.Size(25, 19)
		Me.cmdtransport.Location = New System.Drawing.Point(232, 112)
		Me.cmdtransport.TabIndex = 26
		Me.cmdtransport.BackColor = System.Drawing.SystemColors.Control
		Me.cmdtransport.CausesValidation = True
		Me.cmdtransport.Enabled = True
		Me.cmdtransport.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdtransport.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdtransport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdtransport.TabStop = True
		Me.cmdtransport.Name = "cmdtransport"
		Me.cmbtransport.Size = New System.Drawing.Size(145, 21)
		Me.cmbtransport.Location = New System.Drawing.Point(72, 112)
		Me.cmbtransport.Items.AddRange(New Object(){"Ford", "RAM", "Tracker"})
		Me.cmbtransport.Sorted = True
		Me.cmbtransport.TabIndex = 25
		Me.cmbtransport.Text = "cmbtransport"
		Me.cmbtransport.BackColor = System.Drawing.SystemColors.Window
		Me.cmbtransport.CausesValidation = True
		Me.cmbtransport.Enabled = True
		Me.cmbtransport.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbtransport.IntegralHeight = True
		Me.cmbtransport.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbtransport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbtransport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbtransport.TabStop = True
		Me.cmbtransport.Visible = True
		Me.cmbtransport.Name = "cmbtransport"
		Me.cmdAnnulerCédule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnulerCédule.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnulerCédule.Text = "Annuler"
		Me.cmdAnnulerCédule.Size = New System.Drawing.Size(97, 33)
		Me.cmdAnnulerCédule.Location = New System.Drawing.Point(216, 256)
		Me.cmdAnnulerCédule.TabIndex = 31
		Me.cmdAnnulerCédule.CausesValidation = True
		Me.cmdAnnulerCédule.Enabled = True
		Me.cmdAnnulerCédule.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnulerCédule.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnulerCédule.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnulerCédule.TabStop = True
		Me.cmdAnnulerCédule.Name = "cmdAnnulerCédule"
		Me.cmdEnregistrerCédule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEnregistrerCédule.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEnregistrerCédule.Text = "Enregistrer"
		Me.cmdEnregistrerCédule.Size = New System.Drawing.Size(97, 33)
		Me.cmdEnregistrerCédule.Location = New System.Drawing.Point(8, 256)
		Me.cmdEnregistrerCédule.TabIndex = 30
		Me.cmdEnregistrerCédule.CausesValidation = True
		Me.cmdEnregistrerCédule.Enabled = True
		Me.cmdEnregistrerCédule.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEnregistrerCédule.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEnregistrerCédule.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEnregistrerCédule.TabStop = True
		Me.cmdEnregistrerCédule.Name = "cmdEnregistrerCédule"
		Me.cmbheurefin.BackColor = System.Drawing.Color.White
		Me.cmbheurefin.Size = New System.Drawing.Size(73, 21)
		Me.cmbheurefin.Location = New System.Drawing.Point(184, 72)
		Me.cmbheurefin.Items.AddRange(New Object(){"0:00", "0:30", "1:00", "1:30", "2:00", "2:30", "3:00", "3:30", "4:00", "4:30", "5:00", "5:30", "6:00", "6:30", "7:00", "7:30", "8:00", "8:30", "9:00", "9:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00", "20:30", "21:00", "21:30", "22:00", "22:30", "23:00", "23:30"})
		Me.cmbheurefin.TabIndex = 21
		Me.cmbheurefin.CausesValidation = True
		Me.cmbheurefin.Enabled = True
		Me.cmbheurefin.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbheurefin.IntegralHeight = True
		Me.cmbheurefin.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbheurefin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbheurefin.Sorted = False
		Me.cmbheurefin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbheurefin.TabStop = True
		Me.cmbheurefin.Visible = True
		Me.cmbheurefin.Name = "cmbheurefin"
		Me.cmbheuredébut.BackColor = System.Drawing.Color.White
		Me.cmbheuredébut.Size = New System.Drawing.Size(73, 21)
		Me.cmbheuredébut.Location = New System.Drawing.Point(88, 72)
		Me.cmbheuredébut.Items.AddRange(New Object(){"0:00", "0:30", "1:00", "1:30", "2:00", "2:30", "3:00", "3:30", "4:00", "4:30", "5:00", "5:30", "6:00", "6:30", "7:00", "7:30", "8:00", "8:30", "9:00", "9:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00", "20:30", "21:00", "21:30", "22:00", "22:30", "23:00", "23:30"})
		Me.cmbheuredébut.TabIndex = 18
		Me.cmbheuredébut.CausesValidation = True
		Me.cmbheuredébut.Enabled = True
		Me.cmbheuredébut.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbheuredébut.IntegralHeight = True
		Me.cmbheuredébut.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbheuredébut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbheuredébut.Sorted = False
		Me.cmbheuredébut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbheuredébut.TabStop = True
		Me.cmbheuredébut.Visible = True
		Me.cmbheuredébut.Name = "cmbheuredébut"
		Me.cmbemployé.BackColor = System.Drawing.Color.White
		Me.cmbemployé.Size = New System.Drawing.Size(241, 21)
		Me.cmbemployé.Location = New System.Drawing.Point(72, 24)
		Me.cmbemployé.TabIndex = 16
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
		Me.lblprojet.Text = "No. Projet"
		Me.lblprojet.ForeColor = System.Drawing.Color.Black
		Me.lblprojet.Size = New System.Drawing.Size(49, 17)
		Me.lblprojet.Location = New System.Drawing.Point(16, 112)
		Me.lblprojet.TabIndex = 22
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
		Me.lbltransport.Text = "Transport"
		Me.lbltransport.Size = New System.Drawing.Size(73, 17)
		Me.lbltransport.Location = New System.Drawing.Point(16, 112)
		Me.lbltransport.TabIndex = 23
		Me.lbltransport.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbltransport.BackColor = System.Drawing.SystemColors.Control
		Me.lbltransport.Enabled = True
		Me.lbltransport.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lbltransport.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbltransport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbltransport.UseMnemonic = True
		Me.lbltransport.Visible = True
		Me.lbltransport.AutoSize = False
		Me.lbltransport.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbltransport.Name = "lbltransport"
		Me.Label5.Text = "à"
		Me.Label5.ForeColor = System.Drawing.Color.Black
		Me.Label5.Size = New System.Drawing.Size(17, 17)
		Me.Label5.Location = New System.Drawing.Point(168, 72)
		Me.Label5.TabIndex = 20
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.SystemColors.Control
		Me.Label5.Enabled = True
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.Text = "de"
		Me.Label4.ForeColor = System.Drawing.Color.Black
		Me.Label4.Size = New System.Drawing.Size(17, 17)
		Me.Label4.Location = New System.Drawing.Point(72, 72)
		Me.Label4.TabIndex = 19
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
		Me.Label3.Text = "Client"
		Me.Label3.ForeColor = System.Drawing.Color.Black
		Me.Label3.Size = New System.Drawing.Size(73, 17)
		Me.Label3.Location = New System.Drawing.Point(16, 152)
		Me.Label3.TabIndex = 29
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
		Me.Label2.Text = "Cédulé"
		Me.Label2.ForeColor = System.Drawing.Color.Black
		Me.Label2.Size = New System.Drawing.Size(65, 17)
		Me.Label2.Location = New System.Drawing.Point(16, 72)
		Me.Label2.TabIndex = 17
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "Employé"
		Me.Label1.ForeColor = System.Drawing.Color.Black
		Me.Label1.Size = New System.Drawing.Size(57, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 24)
		Me.Label1.TabIndex = 15
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
		Me.Label6.Text = "Fin des projets"
		Me.Label6.ForeColor = System.Drawing.Color.White
		Me.Label6.Size = New System.Drawing.Size(105, 17)
		Me.Label6.Location = New System.Drawing.Point(208, 8)
		Me.Label6.TabIndex = 0
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
		Me.Label11.Text = "Mar"
		Me.Label11.Size = New System.Drawing.Size(41, 17)
		Me.Label11.Location = New System.Drawing.Point(368, 336)
		Me.Label11.TabIndex = 62
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label11.BackColor = System.Drawing.SystemColors.Control
		Me.Label11.Enabled = True
		Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label11.UseMnemonic = True
		Me.Label11.Visible = True
		Me.Label11.AutoSize = False
		Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label11.Name = "Label11"
		Me.Controls.Add(mvwSelection)
		Me.Controls.Add(cmbfinprojet)
		Me.Controls.Add(frasemaine)
		Me.Controls.Add(fraliste)
		Me.Controls.Add(fraAlarme)
		Me.Controls.Add(frajour)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label11)
		Me.frasemaine.Controls.Add(_lstjoursemaine_1)
		Me.frasemaine.Controls.Add(_lstjoursemaine_2)
		Me.frasemaine.Controls.Add(_lstjoursemaine_3)
		Me.frasemaine.Controls.Add(_lstjoursemaine_4)
		Me.frasemaine.Controls.Add(_lstjoursemaine_5)
		Me.frasemaine.Controls.Add(_lstjoursemaine_6)
		Me.frasemaine.Controls.Add(_lstjoursemaine_7)
		Me.frasemaine.Controls.Add(_lbljour_6)
		Me.frasemaine.Controls.Add(_lbljour_5)
		Me.frasemaine.Controls.Add(_lbljour_4)
		Me.frasemaine.Controls.Add(_lbljour_3)
		Me.frasemaine.Controls.Add(_lbljour_2)
		Me.frasemaine.Controls.Add(_lbljour_1)
		Me.frasemaine.Controls.Add(_lbljour_0)
		Me.ShapeContainer1.Shapes.Add(Line1)
		Me.ShapeContainer1.Shapes.Add(Line6)
		Me.ShapeContainer1.Shapes.Add(Line5)
		Me.ShapeContainer1.Shapes.Add(Line4)
		Me.ShapeContainer1.Shapes.Add(Line3)
		Me.ShapeContainer1.Shapes.Add(Line2)
		Me.frasemaine.Controls.Add(_lbljourstr_6)
		Me.frasemaine.Controls.Add(_lbljourstr_5)
		Me.frasemaine.Controls.Add(_lbljourstr_4)
		Me.frasemaine.Controls.Add(_lbljourstr_3)
		Me.frasemaine.Controls.Add(_lbljourstr_2)
		Me.frasemaine.Controls.Add(_lbljourstr_1)
		Me.frasemaine.Controls.Add(_lbljourstr_0)
		Me.frasemaine.Controls.Add(ShapeContainer1)
		Me._lstjoursemaine_1.Columns.Add(__lstjoursemaine_1_ColumnHeader_1)
		Me._lstjoursemaine_1.Columns.Add(__lstjoursemaine_1_ColumnHeader_2)
		Me._lstjoursemaine_1.Columns.Add(__lstjoursemaine_1_ColumnHeader_3)
		Me._lstjoursemaine_2.Columns.Add(__lstjoursemaine_2_ColumnHeader_1)
		Me._lstjoursemaine_2.Columns.Add(__lstjoursemaine_2_ColumnHeader_2)
		Me._lstjoursemaine_2.Columns.Add(__lstjoursemaine_2_ColumnHeader_3)
		Me._lstjoursemaine_3.Columns.Add(__lstjoursemaine_3_ColumnHeader_1)
		Me._lstjoursemaine_3.Columns.Add(__lstjoursemaine_3_ColumnHeader_2)
		Me._lstjoursemaine_3.Columns.Add(__lstjoursemaine_3_ColumnHeader_3)
		Me._lstjoursemaine_4.Columns.Add(__lstjoursemaine_4_ColumnHeader_1)
		Me._lstjoursemaine_4.Columns.Add(__lstjoursemaine_4_ColumnHeader_2)
		Me._lstjoursemaine_4.Columns.Add(__lstjoursemaine_4_ColumnHeader_3)
		Me._lstjoursemaine_5.Columns.Add(__lstjoursemaine_5_ColumnHeader_1)
		Me._lstjoursemaine_5.Columns.Add(__lstjoursemaine_5_ColumnHeader_2)
		Me._lstjoursemaine_5.Columns.Add(__lstjoursemaine_5_ColumnHeader_3)
		Me._lstjoursemaine_6.Columns.Add(__lstjoursemaine_6_ColumnHeader_1)
		Me._lstjoursemaine_6.Columns.Add(__lstjoursemaine_6_ColumnHeader_2)
		Me._lstjoursemaine_6.Columns.Add(__lstjoursemaine_6_ColumnHeader_3)
		Me._lstjoursemaine_7.Columns.Add(__lstjoursemaine_7_ColumnHeader_1)
		Me._lstjoursemaine_7.Columns.Add(__lstjoursemaine_7_ColumnHeader_2)
		Me._lstjoursemaine_7.Columns.Add(__lstjoursemaine_7_ColumnHeader_3)
		Me.fraliste.Controls.Add(cmdAjouterAlarme)
		Me.fraliste.Controls.Add(mvwChoixDate)
		Me.fraliste.Controls.Add(cmdCopier)
		Me.fraliste.Controls.Add(cmdAjouterCédule)
		Me.fraliste.Controls.Add(cmdsupprimer)
		Me.fraliste.Controls.Add(Lstjour)
		Me.fraliste.Controls.Add(Label18)
		Me.fraliste.Controls.Add(Label16)
		Me.fraliste.Controls.Add(Label15)
		Me.fraliste.Controls.Add(Label14)
		Me.fraliste.Controls.Add(Label13)
		Me.Lstjour.Columns.Add(_Lstjour_ColumnHeader_1)
		Me.Lstjour.Columns.Add(_Lstjour_ColumnHeader_2)
		Me.Lstjour.Columns.Add(_Lstjour_ColumnHeader_3)
		Me.Lstjour.Columns.Add(_Lstjour_ColumnHeader_4)
		Me.Lstjour.Columns.Add(_Lstjour_ColumnHeader_5)
		Me.Lstjour.Columns.Add(_Lstjour_ColumnHeader_6)
		Me.fraAlarme.Controls.Add(cmdEnregistrerAlarme)
		Me.fraAlarme.Controls.Add(cmdAnnulerAlarme)
		Me.fraAlarme.Controls.Add(txtMessage)
		Me.fraAlarme.Controls.Add(mskHeure)
		Me.fraAlarme.Controls.Add(Label9)
		Me.fraAlarme.Controls.Add(Label7)
		Me.frajour.Controls.Add(cmdRafraichir)
		Me.frajour.Controls.Add(cmdRechercher)
		Me.frajour.Controls.Add(txtnoprojet)
		Me.frajour.Controls.Add(chkfin)
		Me.frajour.Controls.Add(cmbclient)
		Me.frajour.Controls.Add(cmdtransport)
		Me.frajour.Controls.Add(cmbtransport)
		Me.frajour.Controls.Add(cmdAnnulerCédule)
		Me.frajour.Controls.Add(cmdEnregistrerCédule)
		Me.frajour.Controls.Add(cmbheurefin)
		Me.frajour.Controls.Add(cmbheuredébut)
		Me.frajour.Controls.Add(cmbemployé)
		Me.frajour.Controls.Add(lblprojet)
		Me.frajour.Controls.Add(lbltransport)
		Me.frajour.Controls.Add(Label5)
		Me.frajour.Controls.Add(Label4)
		Me.frajour.Controls.Add(Label3)
		Me.frajour.Controls.Add(Label2)
		Me.frajour.Controls.Add(Label1)
		Me.lbljour.SetIndex(_lbljour_6, CType(6, Short))
		Me.lbljour.SetIndex(_lbljour_5, CType(5, Short))
		Me.lbljour.SetIndex(_lbljour_4, CType(4, Short))
		Me.lbljour.SetIndex(_lbljour_3, CType(3, Short))
		Me.lbljour.SetIndex(_lbljour_2, CType(2, Short))
		Me.lbljour.SetIndex(_lbljour_1, CType(1, Short))
		Me.lbljour.SetIndex(_lbljour_0, CType(0, Short))
		Me.lbljourstr.SetIndex(_lbljourstr_6, CType(6, Short))
		Me.lbljourstr.SetIndex(_lbljourstr_5, CType(5, Short))
		Me.lbljourstr.SetIndex(_lbljourstr_4, CType(4, Short))
		Me.lbljourstr.SetIndex(_lbljourstr_3, CType(3, Short))
		Me.lbljourstr.SetIndex(_lbljourstr_2, CType(2, Short))
		Me.lbljourstr.SetIndex(_lbljourstr_1, CType(1, Short))
		Me.lbljourstr.SetIndex(_lbljourstr_0, CType(0, Short))
		Me.lstjoursemaine.SetIndex(_lstjoursemaine_1, CType(1, Short))
		Me.lstjoursemaine.SetIndex(_lstjoursemaine_2, CType(2, Short))
		Me.lstjoursemaine.SetIndex(_lstjoursemaine_3, CType(3, Short))
		Me.lstjoursemaine.SetIndex(_lstjoursemaine_4, CType(4, Short))
		Me.lstjoursemaine.SetIndex(_lstjoursemaine_5, CType(5, Short))
		Me.lstjoursemaine.SetIndex(_lstjoursemaine_6, CType(6, Short))
		Me.lstjoursemaine.SetIndex(_lstjoursemaine_7, CType(7, Short))
		CType(Me.lbljourstr, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.lbljour, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mvwChoixDate, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.mvwSelection, System.ComponentModel.ISupportInitialize).EndInit()
		Me.frasemaine.ResumeLayout(False)
		Me._lstjoursemaine_1.ResumeLayout(False)
		Me._lstjoursemaine_2.ResumeLayout(False)
		Me._lstjoursemaine_3.ResumeLayout(False)
		Me._lstjoursemaine_4.ResumeLayout(False)
		Me._lstjoursemaine_5.ResumeLayout(False)
		Me._lstjoursemaine_6.ResumeLayout(False)
		Me._lstjoursemaine_7.ResumeLayout(False)
		Me.fraliste.ResumeLayout(False)
		Me.Lstjour.ResumeLayout(False)
		Me.fraAlarme.ResumeLayout(False)
		Me.frajour.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class