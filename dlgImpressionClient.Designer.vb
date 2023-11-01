<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class dlgImpressionClient
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
	Public WithEvents cmdFacturer As System.Windows.Forms.Button
	Public WithEvents cmdPotentiel As System.Windows.Forms.Button
	Public WithEvents cmdCategorie As System.Windows.Forms.Button
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents cmdTous As System.Windows.Forms.Button
	Public WithEvents cmdVille As System.Windows.Forms.Button
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(dlgImpressionClient))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdFacturer = New System.Windows.Forms.Button
		Me.cmdPotentiel = New System.Windows.Forms.Button
		Me.cmdCategorie = New System.Windows.Forms.Button
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.cmdTous = New System.Windows.Forms.Button
		Me.cmdVille = New System.Windows.Forms.Button
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Impression des clients"
		Me.ClientSize = New System.Drawing.Size(558, 95)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "dlgImpressionClient"
		Me.cmdFacturer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFacturer.Text = "Clients Facturés"
		Me.cmdFacturer.Size = New System.Drawing.Size(89, 25)
		Me.cmdFacturer.Location = New System.Drawing.Point(272, 64)
		Me.cmdFacturer.TabIndex = 6
		Me.cmdFacturer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFacturer.CausesValidation = True
		Me.cmdFacturer.Enabled = True
		Me.cmdFacturer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFacturer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFacturer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFacturer.TabStop = True
		Me.cmdFacturer.Name = "cmdFacturer"
		Me.cmdPotentiel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPotentiel.Text = "Clients Potentiels"
		Me.cmdPotentiel.Size = New System.Drawing.Size(97, 25)
		Me.cmdPotentiel.Location = New System.Drawing.Point(168, 64)
		Me.cmdPotentiel.TabIndex = 5
		Me.cmdPotentiel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPotentiel.CausesValidation = True
		Me.cmdPotentiel.Enabled = True
		Me.cmdPotentiel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPotentiel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPotentiel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPotentiel.TabStop = True
		Me.cmdPotentiel.Name = "cmdPotentiel"
		Me.cmdCategorie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCategorie.Text = "Catégorie"
		Me.cmdCategorie.Size = New System.Drawing.Size(73, 25)
		Me.cmdCategorie.Location = New System.Drawing.Point(88, 64)
		Me.cmdCategorie.TabIndex = 2
		Me.cmdCategorie.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCategorie.CausesValidation = True
		Me.cmdCategorie.Enabled = True
		Me.cmdCategorie.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCategorie.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCategorie.TabStop = True
		Me.cmdCategorie.Name = "cmdCategorie"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(89, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(464, 64)
		Me.cmdAnnuler.TabIndex = 4
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.cmdTous.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdTous.Text = "Tous les clients"
		Me.cmdTous.Size = New System.Drawing.Size(89, 25)
		Me.cmdTous.Location = New System.Drawing.Point(368, 64)
		Me.cmdTous.TabIndex = 3
		Me.cmdTous.BackColor = System.Drawing.SystemColors.Control
		Me.cmdTous.CausesValidation = True
		Me.cmdTous.Enabled = True
		Me.cmdTous.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdTous.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdTous.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdTous.TabStop = True
		Me.cmdTous.Name = "cmdTous"
		Me.cmdVille.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdVille.Text = "Ville"
		Me.cmdVille.Size = New System.Drawing.Size(73, 25)
		Me.cmdVille.Location = New System.Drawing.Point(8, 64)
		Me.cmdVille.TabIndex = 1
		Me.cmdVille.BackColor = System.Drawing.SystemColors.Control
		Me.cmdVille.CausesValidation = True
		Me.cmdVille.Enabled = True
		Me.cmdVille.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdVille.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdVille.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdVille.TabStop = True
		Me.cmdVille.Name = "cmdVille"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label1.Text = "Quel est le tri de l'impression des clients ?"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(529, 41)
		Me.Label1.Location = New System.Drawing.Point(16, 8)
		Me.Label1.TabIndex = 0
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(cmdFacturer)
		Me.Controls.Add(cmdPotentiel)
		Me.Controls.Add(cmdCategorie)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(cmdTous)
		Me.Controls.Add(cmdVille)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class