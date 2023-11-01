<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmDetailTemps
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
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents _lvwTemps_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwTemps_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwTemps_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwTemps As System.Windows.Forms.ListView
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDetailTemps))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdImprimer = New System.Windows.Forms.Button
		Me.cmdOK = New System.Windows.Forms.Button
		Me.lvwTemps = New System.Windows.Forms.ListView
		Me._lvwTemps_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwTemps_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwTemps_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me.lvwTemps.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Détail des temps"
		Me.ClientSize = New System.Drawing.Size(455, 331)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmDetailTemps"
		Me.cmdImprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdImprimer.Text = "Imprimer"
		Me.cmdImprimer.Size = New System.Drawing.Size(73, 25)
		Me.cmdImprimer.Location = New System.Drawing.Point(296, 296)
		Me.cmdImprimer.TabIndex = 2
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
		Me.cmdOK.Location = New System.Drawing.Point(376, 296)
		Me.cmdOK.TabIndex = 1
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me.lvwTemps.Size = New System.Drawing.Size(441, 273)
		Me.lvwTemps.Location = New System.Drawing.Point(8, 16)
		Me.lvwTemps.TabIndex = 0
		Me.lvwTemps.View = System.Windows.Forms.View.Details
		Me.lvwTemps.LabelEdit = False
		Me.lvwTemps.LabelWrap = True
		Me.lvwTemps.HideSelection = True
		Me.lvwTemps.FullRowSelect = True
		Me.lvwTemps.GridLines = True
		Me.lvwTemps.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwTemps.BackColor = System.Drawing.SystemColors.Window
		Me.lvwTemps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwTemps.Name = "lvwTemps"
		Me._lvwTemps_ColumnHeader_1.Text = "Employé"
		Me._lvwTemps_ColumnHeader_1.Width = 403
		Me._lvwTemps_ColumnHeader_2.Text = "Type"
		Me._lvwTemps_ColumnHeader_2.Width = 236
		Me._lvwTemps_ColumnHeader_3.Text = "Heures"
		Me._lvwTemps_ColumnHeader_3.Width = 366
		Me.Controls.Add(cmdImprimer)
		Me.Controls.Add(cmdOK)
		Me.Controls.Add(lvwTemps)
		Me.lvwTemps.Columns.Add(_lvwTemps_ColumnHeader_1)
		Me.lvwTemps.Columns.Add(_lvwTemps_ColumnHeader_2)
		Me.lvwTemps.Columns.Add(_lvwTemps_ColumnHeader_3)
		Me.lvwTemps.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class