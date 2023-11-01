<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCommentairesProjSoum
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
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	Public WithEvents cmdCopier As System.Windows.Forms.Button
	Public WithEvents cmdSupprimerTout As System.Windows.Forms.Button
	Public WithEvents cmdVider As System.Windows.Forms.Button
	Public WithEvents cmdAjouter As System.Windows.Forms.Button
	Public WithEvents txtAjout As System.Windows.Forms.TextBox
	Public WithEvents tvwCommentaire As System.Windows.Forms.TreeView
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents lblNoProjSoum As System.Windows.Forms.Label
	Public WithEvents lblTitreNoProjSoum As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCommentairesProjSoum))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.cmdCopier = New System.Windows.Forms.Button
		Me.cmdSupprimerTout = New System.Windows.Forms.Button
		Me.cmdVider = New System.Windows.Forms.Button
		Me.cmdAjouter = New System.Windows.Forms.Button
		Me.txtAjout = New System.Windows.Forms.TextBox
		Me.tvwCommentaire = New System.Windows.Forms.TreeView
		Me.Label2 = New System.Windows.Forms.Label
		Me.lblNoProjSoum = New System.Windows.Forms.Label
		Me.lblTitreNoProjSoum = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Commentaires"
		Me.ClientSize = New System.Drawing.Size(662, 676)
		Me.Location = New System.Drawing.Point(238, 216)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmCommentairesProjSoum.BackgroundImage"), System.Drawing.Image)
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmCommentairesProjSoum"
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(105, 33)
		Me.cmdFermer.Location = New System.Drawing.Point(552, 632)
		Me.cmdFermer.TabIndex = 10
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.cmdCopier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCopier.Text = "Copier en bas"
		Me.cmdCopier.Size = New System.Drawing.Size(105, 33)
		Me.cmdCopier.Location = New System.Drawing.Point(8, 352)
		Me.cmdCopier.TabIndex = 8
		Me.cmdCopier.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCopier.CausesValidation = True
		Me.cmdCopier.Enabled = True
		Me.cmdCopier.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCopier.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCopier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCopier.TabStop = True
		Me.cmdCopier.Name = "cmdCopier"
		Me.cmdSupprimerTout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSupprimerTout.Text = "Supprimer tout"
		Me.cmdSupprimerTout.Size = New System.Drawing.Size(105, 33)
		Me.cmdSupprimerTout.Location = New System.Drawing.Point(552, 352)
		Me.cmdSupprimerTout.TabIndex = 7
		Me.cmdSupprimerTout.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSupprimerTout.CausesValidation = True
		Me.cmdSupprimerTout.Enabled = True
		Me.cmdSupprimerTout.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSupprimerTout.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSupprimerTout.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSupprimerTout.TabStop = True
		Me.cmdSupprimerTout.Name = "cmdSupprimerTout"
		Me.cmdVider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdVider.Text = "Vider"
		Me.cmdVider.Size = New System.Drawing.Size(105, 33)
		Me.cmdVider.Location = New System.Drawing.Point(440, 584)
		Me.cmdVider.TabIndex = 4
		Me.cmdVider.BackColor = System.Drawing.SystemColors.Control
		Me.cmdVider.CausesValidation = True
		Me.cmdVider.Enabled = True
		Me.cmdVider.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdVider.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdVider.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdVider.TabStop = True
		Me.cmdVider.Name = "cmdVider"
		Me.cmdAjouter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAjouter.Text = "Ajouter"
		Me.cmdAjouter.Size = New System.Drawing.Size(105, 33)
		Me.cmdAjouter.Location = New System.Drawing.Point(552, 584)
		Me.cmdAjouter.TabIndex = 2
		Me.cmdAjouter.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAjouter.CausesValidation = True
		Me.cmdAjouter.Enabled = True
		Me.cmdAjouter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAjouter.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAjouter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAjouter.TabStop = True
		Me.cmdAjouter.Name = "cmdAjouter"
		Me.txtAjout.AutoSize = False
		Me.txtAjout.Size = New System.Drawing.Size(649, 177)
		Me.txtAjout.Location = New System.Drawing.Point(8, 400)
		Me.txtAjout.MultiLine = True
		Me.txtAjout.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtAjout.TabIndex = 1
		Me.txtAjout.AcceptsReturn = True
		Me.txtAjout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtAjout.BackColor = System.Drawing.SystemColors.Window
		Me.txtAjout.CausesValidation = True
		Me.txtAjout.Enabled = True
		Me.txtAjout.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAjout.HideSelection = True
		Me.txtAjout.ReadOnly = False
		Me.txtAjout.Maxlength = 0
		Me.txtAjout.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAjout.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAjout.TabStop = True
		Me.txtAjout.Visible = True
		Me.txtAjout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAjout.Name = "txtAjout"
		Me.tvwCommentaire.CausesValidation = True
		Me.tvwCommentaire.Size = New System.Drawing.Size(649, 281)
		Me.tvwCommentaire.Location = New System.Drawing.Point(8, 64)
		Me.tvwCommentaire.TabIndex = 0
		Me.tvwCommentaire.LabelEdit = False
		Me.tvwCommentaire.FullRowSelect = True
		Me.tvwCommentaire.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.tvwCommentaire.Name = "tvwCommentaire"
		Me.Label2.Text = "Les lignes commencées par ""--"" seront des sous-sections"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(225, 33)
		Me.Label2.Location = New System.Drawing.Point(8, 624)
		Me.Label2.TabIndex = 9
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
		Me.lblNoProjSoum.ForeColor = System.Drawing.Color.White
		Me.lblNoProjSoum.Size = New System.Drawing.Size(225, 17)
		Me.lblNoProjSoum.Location = New System.Drawing.Point(392, 8)
		Me.lblNoProjSoum.TabIndex = 6
		Me.lblNoProjSoum.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblNoProjSoum.BackColor = System.Drawing.Color.Transparent
		Me.lblNoProjSoum.Enabled = True
		Me.lblNoProjSoum.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblNoProjSoum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblNoProjSoum.UseMnemonic = True
		Me.lblNoProjSoum.Visible = True
		Me.lblNoProjSoum.AutoSize = False
		Me.lblNoProjSoum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblNoProjSoum.Name = "lblNoProjSoum"
		Me.lblTitreNoProjSoum.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblTitreNoProjSoum.Text = "# Projet :"
		Me.lblTitreNoProjSoum.ForeColor = System.Drawing.Color.White
		Me.lblTitreNoProjSoum.Size = New System.Drawing.Size(105, 17)
		Me.lblTitreNoProjSoum.Location = New System.Drawing.Point(272, 8)
		Me.lblTitreNoProjSoum.TabIndex = 5
		Me.lblTitreNoProjSoum.BackColor = System.Drawing.Color.Transparent
		Me.lblTitreNoProjSoum.Enabled = True
		Me.lblTitreNoProjSoum.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTitreNoProjSoum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTitreNoProjSoum.UseMnemonic = True
		Me.lblTitreNoProjSoum.Visible = True
		Me.lblTitreNoProjSoum.AutoSize = False
		Me.lblTitreNoProjSoum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTitreNoProjSoum.Name = "lblTitreNoProjSoum"
		Me.Label1.Text = "Les lignes commencées par ""-"" seront des sections"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(225, 33)
		Me.Label1.Location = New System.Drawing.Point(8, 584)
		Me.Label1.TabIndex = 3
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
		Me.Controls.Add(cmdFermer)
		Me.Controls.Add(cmdCopier)
		Me.Controls.Add(cmdSupprimerTout)
		Me.Controls.Add(cmdVider)
		Me.Controls.Add(cmdAjouter)
		Me.Controls.Add(txtAjout)
		Me.Controls.Add(tvwCommentaire)
		Me.Controls.Add(Label2)
		Me.Controls.Add(lblNoProjSoum)
		Me.Controls.Add(lblTitreNoProjSoum)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class