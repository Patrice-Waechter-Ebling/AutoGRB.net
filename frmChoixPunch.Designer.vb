<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixPunch
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
	Public WithEvents cmdPunch As System.Windows.Forms.Button
	Public WithEvents cmdFeuilleTemps As System.Windows.Forms.Button
	Public WithEvents cmdFacturation As System.Windows.Forms.Button
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixPunch))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdPunch = New System.Windows.Forms.Button
		Me.cmdFeuilleTemps = New System.Windows.Forms.Button
		Me.cmdFacturation = New System.Windows.Forms.Button
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Punch"
		Me.ClientSize = New System.Drawing.Size(218, 246)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixPunch.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmChoixPunch"
		Me.cmdPunch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPunch.Text = "Punch"
		Me.cmdPunch.Size = New System.Drawing.Size(105, 25)
		Me.cmdPunch.Location = New System.Drawing.Point(56, 72)
		Me.cmdPunch.TabIndex = 0
		Me.cmdPunch.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPunch.CausesValidation = True
		Me.cmdPunch.Enabled = True
		Me.cmdPunch.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPunch.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPunch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPunch.TabStop = True
		Me.cmdPunch.Name = "cmdPunch"
		Me.cmdFeuilleTemps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFeuilleTemps.Text = "Feuilles de temps"
		Me.cmdFeuilleTemps.Size = New System.Drawing.Size(105, 25)
		Me.cmdFeuilleTemps.Location = New System.Drawing.Point(56, 104)
		Me.cmdFeuilleTemps.TabIndex = 1
		Me.cmdFeuilleTemps.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFeuilleTemps.CausesValidation = True
		Me.cmdFeuilleTemps.Enabled = True
		Me.cmdFeuilleTemps.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFeuilleTemps.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFeuilleTemps.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFeuilleTemps.TabStop = True
		Me.cmdFeuilleTemps.Name = "cmdFeuilleTemps"
		Me.cmdFacturation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFacturation.Text = "Facturation"
		Me.cmdFacturation.Size = New System.Drawing.Size(105, 25)
		Me.cmdFacturation.Location = New System.Drawing.Point(56, 136)
		Me.cmdFacturation.TabIndex = 2
		Me.cmdFacturation.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFacturation.CausesValidation = True
		Me.cmdFacturation.Enabled = True
		Me.cmdFacturation.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFacturation.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFacturation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFacturation.TabStop = True
		Me.cmdFacturation.Name = "cmdFacturation"
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(105, 25)
		Me.cmdFermer.Location = New System.Drawing.Point(56, 216)
		Me.cmdFermer.TabIndex = 3
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.Controls.Add(cmdPunch)
		Me.Controls.Add(cmdFeuilleTemps)
		Me.Controls.Add(cmdFacturation)
		Me.Controls.Add(cmdFermer)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class