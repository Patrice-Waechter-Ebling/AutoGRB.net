<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixDateImpressionFT
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
	Public WithEvents mvwDate As AxMSComCtl2.AxMonthView
	Public WithEvents cmdDateFin As System.Windows.Forms.Button
	Public WithEvents cmdDateDebut As System.Windows.Forms.Button
	Public WithEvents cmdExporter As System.Windows.Forms.Button
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
	Public CommonDialog1Save As System.Windows.Forms.SaveFileDialog
	Public CommonDialog1Font As System.Windows.Forms.FontDialog
	Public CommonDialog1Color As System.Windows.Forms.ColorDialog
	Public CommonDialog1Print As System.Windows.Forms.PrintDialog
	Public WithEvents mskDateDebut As System.Windows.Forms.MaskedTextBox
	Public WithEvents mskDateFin As System.Windows.Forms.MaskedTextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixDateImpressionFT))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.mvwDate = New AxMSComCtl2.AxMonthView
		Me.cmdDateFin = New System.Windows.Forms.Button
		Me.cmdDateDebut = New System.Windows.Forms.Button
		Me.cmdExporter = New System.Windows.Forms.Button
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog
		Me.CommonDialog1Save = New System.Windows.Forms.SaveFileDialog
		Me.CommonDialog1Font = New System.Windows.Forms.FontDialog
		Me.CommonDialog1Color = New System.Windows.Forms.ColorDialog
		Me.CommonDialog1Print = New System.Windows.Forms.PrintDialog
		Me.mskDateDebut = New System.Windows.Forms.MaskedTextBox
		Me.mskDateFin = New System.Windows.Forms.MaskedTextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Exportation feuille de temps"
		Me.ClientSize = New System.Drawing.Size(260, 219)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixDateImpressionFT.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmChoixDateImpressionFT"
		mvwDate.OcxState = CType(resources.GetObject("mvwDate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwDate.Size = New System.Drawing.Size(176, 158)
		Me.mvwDate.Location = New System.Drawing.Point(80, 24)
		Me.mvwDate.TabIndex = 2
		Me.mvwDate.Visible = False
		Me.mvwDate.Name = "mvwDate"
		Me.cmdDateFin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDateFin.Text = "..."
		Me.cmdDateFin.Size = New System.Drawing.Size(25, 17)
		Me.cmdDateFin.Location = New System.Drawing.Point(184, 136)
		Me.cmdDateFin.TabIndex = 6
		Me.cmdDateFin.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDateFin.CausesValidation = True
		Me.cmdDateFin.Enabled = True
		Me.cmdDateFin.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDateFin.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDateFin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDateFin.TabStop = True
		Me.cmdDateFin.Name = "cmdDateFin"
		Me.cmdDateDebut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDateDebut.Text = "..."
		Me.cmdDateDebut.Size = New System.Drawing.Size(25, 17)
		Me.cmdDateDebut.Location = New System.Drawing.Point(184, 104)
		Me.cmdDateDebut.TabIndex = 3
		Me.cmdDateDebut.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDateDebut.CausesValidation = True
		Me.cmdDateDebut.Enabled = True
		Me.cmdDateDebut.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDateDebut.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDateDebut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDateDebut.TabStop = True
		Me.cmdDateDebut.Name = "cmdDateDebut"
		Me.cmdExporter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExporter.Text = "Exporter"
		Me.AcceptButton = Me.cmdExporter
		Me.cmdExporter.Size = New System.Drawing.Size(73, 25)
		Me.cmdExporter.Location = New System.Drawing.Point(176, 184)
		Me.cmdExporter.TabIndex = 1
		Me.cmdExporter.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExporter.CausesValidation = True
		Me.cmdExporter.Enabled = True
		Me.cmdExporter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExporter.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExporter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExporter.TabStop = True
		Me.cmdExporter.Name = "cmdExporter"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(73, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(96, 184)
		Me.cmdAnnuler.TabIndex = 0
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.mskDateDebut.AllowPromptAsInput = False
		Me.mskDateDebut.Size = New System.Drawing.Size(81, 17)
		Me.mskDateDebut.Location = New System.Drawing.Point(96, 104)
		Me.mskDateDebut.TabIndex = 4
		Me.mskDateDebut.PromptChar = "_"
		Me.mskDateDebut.Name = "mskDateDebut"
		Me.mskDateFin.AllowPromptAsInput = False
		Me.mskDateFin.Size = New System.Drawing.Size(81, 17)
		Me.mskDateFin.Location = New System.Drawing.Point(96, 136)
		Me.mskDateFin.TabIndex = 5
		Me.mskDateFin.PromptChar = "_"
		Me.mskDateFin.Name = "mskDateFin"
		Me.Label1.Text = "Date début :"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(65, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 104)
		Me.Label1.TabIndex = 9
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
		Me.Label2.Text = "Date fin :"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(65, 17)
		Me.Label2.Location = New System.Drawing.Point(16, 136)
		Me.Label2.TabIndex = 8
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
		Me.Label3.Text = "AA-MM-JJ"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(81, 17)
		Me.Label3.Location = New System.Drawing.Point(96, 88)
		Me.Label3.TabIndex = 7
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
		Me.Controls.Add(mvwDate)
		Me.Controls.Add(cmdDateFin)
		Me.Controls.Add(cmdDateDebut)
		Me.Controls.Add(cmdExporter)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(mskDateDebut)
		Me.Controls.Add(mskDateFin)
		Me.Controls.Add(Label1)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label3)
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class