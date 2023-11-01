<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixImpressionFT
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
	Public WithEvents cmdImprimer As System.Windows.Forms.Button
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents cmdAucun As System.Windows.Forms.Button
	Public WithEvents cmdTous As System.Windows.Forms.Button
	Public WithEvents _lvwEmploye_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwEmploye As System.Windows.Forms.ListView
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixImpressionFT))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdImprimer = New System.Windows.Forms.Button
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.cmdAucun = New System.Windows.Forms.Button
		Me.cmdTous = New System.Windows.Forms.Button
		Me.lvwEmploye = New System.Windows.Forms.ListView
		Me._lvwEmploye_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.lvwEmploye.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Impression des feuilles de temps"
		Me.ClientSize = New System.Drawing.Size(284, 449)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixImpressionFT.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmChoixImpressionFT"
		Me.cmdImprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdImprimer.Text = "Imprimer"
		Me.cmdImprimer.Size = New System.Drawing.Size(73, 33)
		Me.cmdImprimer.Location = New System.Drawing.Point(200, 408)
		Me.cmdImprimer.TabIndex = 4
		Me.cmdImprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdImprimer.CausesValidation = True
		Me.cmdImprimer.Enabled = True
		Me.cmdImprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdImprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdImprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdImprimer.TabStop = True
		Me.cmdImprimer.Name = "cmdImprimer"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(73, 33)
		Me.cmdAnnuler.Location = New System.Drawing.Point(120, 408)
		Me.cmdAnnuler.TabIndex = 3
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.cmdAucun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAucun.Text = "Aucun"
		Me.cmdAucun.Size = New System.Drawing.Size(65, 25)
		Me.cmdAucun.Location = New System.Drawing.Point(80, 368)
		Me.cmdAucun.TabIndex = 2
		Me.cmdAucun.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAucun.CausesValidation = True
		Me.cmdAucun.Enabled = True
		Me.cmdAucun.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAucun.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAucun.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAucun.TabStop = True
		Me.cmdAucun.Name = "cmdAucun"
		Me.cmdTous.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdTous.Text = "Tous"
		Me.cmdTous.Size = New System.Drawing.Size(65, 25)
		Me.cmdTous.Location = New System.Drawing.Point(8, 368)
		Me.cmdTous.TabIndex = 1
		Me.cmdTous.BackColor = System.Drawing.SystemColors.Control
		Me.cmdTous.CausesValidation = True
		Me.cmdTous.Enabled = True
		Me.cmdTous.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdTous.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdTous.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdTous.TabStop = True
		Me.cmdTous.Name = "cmdTous"
		Me.lvwEmploye.Size = New System.Drawing.Size(265, 297)
		Me.lvwEmploye.Location = New System.Drawing.Point(8, 64)
		Me.lvwEmploye.TabIndex = 0
		Me.lvwEmploye.View = System.Windows.Forms.View.Details
		Me.lvwEmploye.LabelEdit = False
		Me.lvwEmploye.LabelWrap = True
		Me.lvwEmploye.HideSelection = True
		Me.lvwEmploye.Checkboxes = True
		Me.lvwEmploye.FullRowSelect = True
		Me.lvwEmploye.GridLines = True
		Me.lvwEmploye.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwEmploye.BackColor = System.Drawing.SystemColors.Window
		Me.lvwEmploye.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwEmploye.Name = "lvwEmploye"
		Me._lvwEmploye_ColumnHeader_1.Text = "Nom"
		Me._lvwEmploye_ColumnHeader_1.Width = 459
		Me.Controls.Add(cmdImprimer)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(cmdAucun)
		Me.Controls.Add(cmdTous)
		Me.Controls.Add(lvwEmploye)
		Me.lvwEmploye.Columns.Add(_lvwEmploye_ColumnHeader_1)
		Me.lvwEmploye.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class