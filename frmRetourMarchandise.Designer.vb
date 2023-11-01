<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRetourMarchandise
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
	Public WithEvents mvwRetour As AxMSComCtl2.AxMonthView
	Public WithEvents txtDateRetour As System.Windows.Forms.TextBox
	Public WithEvents cmdDate As System.Windows.Forms.Button
	Public WithEvents cmdImprimer As System.Windows.Forms.Button
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	Public WithEvents cmbNoProjet As System.Windows.Forms.ComboBox
	Public WithEvents _lvwProjet_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjet_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjet_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjet_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjet_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjet_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwProjet_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwProjet As System.Windows.Forms.ListView
	Public WithEvents txtNoProjet As System.Windows.Forms.TextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRetourMarchandise))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.mvwRetour = New AxMSComCtl2.AxMonthView
		Me.txtDateRetour = New System.Windows.Forms.TextBox
		Me.cmdDate = New System.Windows.Forms.Button
		Me.cmdImprimer = New System.Windows.Forms.Button
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.cmbNoProjet = New System.Windows.Forms.ComboBox
		Me.lvwProjet = New System.Windows.Forms.ListView
		Me._lvwProjet_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjet_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjet_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjet_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjet_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjet_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me._lvwProjet_ColumnHeader_7 = New System.Windows.Forms.ColumnHeader
		Me.txtNoProjet = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.lvwProjet.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.mvwRetour, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Retour de marchandise"
		Me.ClientSize = New System.Drawing.Size(793, 512)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmRetourMarchandise.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "frmRetourMarchandise"
		mvwRetour.OcxState = CType(resources.GetObject("mvwRetour.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwRetour.Size = New System.Drawing.Size(176, 158)
		Me.mvwRetour.Location = New System.Drawing.Point(608, 0)
		Me.mvwRetour.TabIndex = 2
		Me.mvwRetour.Visible = False
		Me.mvwRetour.Name = "mvwRetour"
		Me.txtDateRetour.AutoSize = False
		Me.txtDateRetour.Size = New System.Drawing.Size(97, 19)
		Me.txtDateRetour.Location = New System.Drawing.Point(656, 24)
		Me.txtDateRetour.ReadOnly = True
		Me.txtDateRetour.TabIndex = 3
		Me.txtDateRetour.AcceptsReturn = True
		Me.txtDateRetour.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDateRetour.BackColor = System.Drawing.SystemColors.Window
		Me.txtDateRetour.CausesValidation = True
		Me.txtDateRetour.Enabled = True
		Me.txtDateRetour.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDateRetour.HideSelection = True
		Me.txtDateRetour.Maxlength = 0
		Me.txtDateRetour.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDateRetour.MultiLine = False
		Me.txtDateRetour.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDateRetour.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDateRetour.TabStop = True
		Me.txtDateRetour.Visible = True
		Me.txtDateRetour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDateRetour.Name = "txtDateRetour"
		Me.cmdDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDate.Text = "..."
		Me.cmdDate.Size = New System.Drawing.Size(25, 19)
		Me.cmdDate.Location = New System.Drawing.Point(760, 24)
		Me.cmdDate.TabIndex = 5
		Me.cmdDate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDate.CausesValidation = True
		Me.cmdDate.Enabled = True
		Me.cmdDate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDate.TabStop = True
		Me.cmdDate.Name = "cmdDate"
		Me.cmdImprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdImprimer.Text = "Imprimer"
		Me.cmdImprimer.Size = New System.Drawing.Size(73, 25)
		Me.cmdImprimer.Location = New System.Drawing.Point(8, 480)
		Me.cmdImprimer.TabIndex = 7
		Me.cmdImprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdImprimer.CausesValidation = True
		Me.cmdImprimer.Enabled = True
		Me.cmdImprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdImprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdImprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdImprimer.TabStop = True
		Me.cmdImprimer.Name = "cmdImprimer"
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(81, 25)
		Me.cmdFermer.Location = New System.Drawing.Point(704, 480)
		Me.cmdFermer.TabIndex = 8
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.cmbNoProjet.Size = New System.Drawing.Size(145, 21)
		Me.cmbNoProjet.Location = New System.Drawing.Point(224, 8)
		Me.cmbNoProjet.Sorted = True
		Me.cmbNoProjet.TabIndex = 1
		Me.cmbNoProjet.BackColor = System.Drawing.SystemColors.Window
		Me.cmbNoProjet.CausesValidation = True
		Me.cmbNoProjet.Enabled = True
		Me.cmbNoProjet.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbNoProjet.IntegralHeight = True
		Me.cmbNoProjet.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbNoProjet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbNoProjet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbNoProjet.TabStop = True
		Me.cmbNoProjet.Visible = True
		Me.cmbNoProjet.Name = "cmbNoProjet"
		Me.lvwProjet.Size = New System.Drawing.Size(777, 417)
		Me.lvwProjet.Location = New System.Drawing.Point(8, 56)
		Me.lvwProjet.TabIndex = 6
		Me.lvwProjet.View = System.Windows.Forms.View.Details
		Me.lvwProjet.LabelEdit = False
		Me.lvwProjet.LabelWrap = True
		Me.lvwProjet.HideSelection = True
		Me.lvwProjet.Checkboxes = True
		Me.lvwProjet.FullRowSelect = True
		Me.lvwProjet.GridLines = True
		Me.lvwProjet.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwProjet.BackColor = System.Drawing.SystemColors.Window
		Me.lvwProjet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwProjet.Name = "lvwProjet"
		Me._lvwProjet_ColumnHeader_1.Text = "Qté"
		Me._lvwProjet_ColumnHeader_1.Width = 77
		Me._lvwProjet_ColumnHeader_2.Text = "No. Item"
		Me._lvwProjet_ColumnHeader_2.Width = 216
		Me._lvwProjet_ColumnHeader_3.Text = "Description"
		Me._lvwProjet_ColumnHeader_3.Width = 448
		Me._lvwProjet_ColumnHeader_4.Text = "Manufacturier"
		Me._lvwProjet_ColumnHeader_4.Width = 136
		Me._lvwProjet_ColumnHeader_5.Text = "Distributeur"
		Me._lvwProjet_ColumnHeader_5.Width = 119
		Me._lvwProjet_ColumnHeader_6.Text = "No. Retour"
		Me._lvwProjet_ColumnHeader_6.Width = 170
		Me._lvwProjet_ColumnHeader_7.Text = "Date"
		Me._lvwProjet_ColumnHeader_7.Width = 170
		Me.txtNoProjet.AutoSize = False
		Me.txtNoProjet.Size = New System.Drawing.Size(145, 19)
		Me.txtNoProjet.Location = New System.Drawing.Point(224, 8)
		Me.txtNoProjet.ReadOnly = True
		Me.txtNoProjet.TabIndex = 0
		Me.txtNoProjet.Visible = False
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
		Me.txtNoProjet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoProjet.Name = "txtNoProjet"
		Me.Label1.Text = "Date de retour :"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(97, 19)
		Me.Label1.Location = New System.Drawing.Point(560, 24)
		Me.Label1.TabIndex = 4
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
		Me.Controls.Add(mvwRetour)
		Me.Controls.Add(txtDateRetour)
		Me.Controls.Add(cmdDate)
		Me.Controls.Add(cmdImprimer)
		Me.Controls.Add(cmdFermer)
		Me.Controls.Add(cmbNoProjet)
		Me.Controls.Add(lvwProjet)
		Me.Controls.Add(txtNoProjet)
		Me.Controls.Add(Label1)
		Me.lvwProjet.Columns.Add(_lvwProjet_ColumnHeader_1)
		Me.lvwProjet.Columns.Add(_lvwProjet_ColumnHeader_2)
		Me.lvwProjet.Columns.Add(_lvwProjet_ColumnHeader_3)
		Me.lvwProjet.Columns.Add(_lvwProjet_ColumnHeader_4)
		Me.lvwProjet.Columns.Add(_lvwProjet_ColumnHeader_5)
		Me.lvwProjet.Columns.Add(_lvwProjet_ColumnHeader_6)
		Me.lvwProjet.Columns.Add(_lvwProjet_ColumnHeader_7)
		CType(Me.mvwRetour, System.ComponentModel.ISupportInitialize).EndInit()
		Me.lvwProjet.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class