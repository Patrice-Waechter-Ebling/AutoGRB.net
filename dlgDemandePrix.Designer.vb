<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class dlgDemandePrix
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
	Public WithEvents cmdNouveau As System.Windows.Forms.Button
	Public WithEvents cmdCategorie As System.Windows.Forms.Button
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents cmdFournisseur As System.Windows.Forms.Button
	Public WithEvents cmdPiece As System.Windows.Forms.Button
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(dlgDemandePrix))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdNouveau = New System.Windows.Forms.Button
		Me.cmdCategorie = New System.Windows.Forms.Button
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.cmdFournisseur = New System.Windows.Forms.Button
		Me.cmdPiece = New System.Windows.Forms.Button
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Demande de prix"
		Me.ClientSize = New System.Drawing.Size(530, 95)
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
		Me.Name = "dlgDemandePrix"
		Me.cmdNouveau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNouveau.Text = "Nouvelles pièces"
		Me.cmdNouveau.Size = New System.Drawing.Size(97, 25)
		Me.cmdNouveau.Location = New System.Drawing.Point(320, 64)
		Me.cmdNouveau.TabIndex = 4
		Me.cmdNouveau.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNouveau.CausesValidation = True
		Me.cmdNouveau.Enabled = True
		Me.cmdNouveau.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNouveau.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNouveau.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNouveau.TabStop = True
		Me.cmdNouveau.Name = "cmdNouveau"
		Me.cmdCategorie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCategorie.Text = "Une catégorie"
		Me.cmdCategorie.Size = New System.Drawing.Size(97, 25)
		Me.cmdCategorie.Location = New System.Drawing.Point(112, 64)
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
		Me.cmdAnnuler.Size = New System.Drawing.Size(97, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(424, 64)
		Me.cmdAnnuler.TabIndex = 5
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.cmdFournisseur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFournisseur.Text = "Toutes les pièces"
		Me.cmdFournisseur.Size = New System.Drawing.Size(97, 25)
		Me.cmdFournisseur.Location = New System.Drawing.Point(216, 64)
		Me.cmdFournisseur.TabIndex = 3
		Me.cmdFournisseur.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFournisseur.CausesValidation = True
		Me.cmdFournisseur.Enabled = True
		Me.cmdFournisseur.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFournisseur.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFournisseur.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFournisseur.TabStop = True
		Me.cmdFournisseur.Name = "cmdFournisseur"
		Me.cmdPiece.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPiece.Text = "Une pièce"
		Me.cmdPiece.Size = New System.Drawing.Size(97, 25)
		Me.cmdPiece.Location = New System.Drawing.Point(8, 64)
		Me.cmdPiece.TabIndex = 1
		Me.cmdPiece.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPiece.CausesValidation = True
		Me.cmdPiece.Enabled = True
		Me.cmdPiece.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPiece.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPiece.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPiece.TabStop = True
		Me.cmdPiece.Name = "cmdPiece"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label1.Text = "Voulez-vous faire une demande de prix pour tous les pièces d'un fournisseur, d'une catégorie ou pour une pièce en particulier?"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(481, 41)
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
		Me.Controls.Add(cmdNouveau)
		Me.Controls.Add(cmdCategorie)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(cmdFournisseur)
		Me.Controls.Add(cmdPiece)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class