<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmValiderSuppression
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
	Public WithEvents txtValidation As System.Windows.Forms.TextBox
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents cmdValider As System.Windows.Forms.Button
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents lblValidation As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblNumero As System.Windows.Forms.Label
	Public WithEvents lblAction As System.Windows.Forms.Label
	Public WithEvents lblProjSoum As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmValiderSuppression))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.txtValidation = New System.Windows.Forms.TextBox
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.cmdValider = New System.Windows.Forms.Button
		Me.Label3 = New System.Windows.Forms.Label
		Me.lblValidation = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.lblNumero = New System.Windows.Forms.Label
		Me.lblAction = New System.Windows.Forms.Label
		Me.lblProjSoum = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.ControlBox = False
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.ClientSize = New System.Drawing.Size(394, 269)
		Me.Location = New System.Drawing.Point(1, 1)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmValiderSuppression"
		Me.txtValidation.AutoSize = False
		Me.txtValidation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.txtValidation.Size = New System.Drawing.Size(65, 25)
		Me.txtValidation.Location = New System.Drawing.Point(200, 176)
		Me.txtValidation.TabIndex = 7
		Me.txtValidation.AcceptsReturn = True
		Me.txtValidation.BackColor = System.Drawing.SystemColors.Window
		Me.txtValidation.CausesValidation = True
		Me.txtValidation.Enabled = True
		Me.txtValidation.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtValidation.HideSelection = True
		Me.txtValidation.ReadOnly = False
		Me.txtValidation.Maxlength = 0
		Me.txtValidation.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtValidation.MultiLine = False
		Me.txtValidation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtValidation.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtValidation.TabStop = True
		Me.txtValidation.Visible = True
		Me.txtValidation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtValidation.Name = "txtValidation"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(73, 33)
		Me.cmdAnnuler.Location = New System.Drawing.Point(48, 224)
		Me.cmdAnnuler.TabIndex = 4
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.cmdValider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdValider.Text = "Valider"
		Me.AcceptButton = Me.cmdValider
		Me.cmdValider.Size = New System.Drawing.Size(73, 33)
		Me.cmdValider.Location = New System.Drawing.Point(264, 224)
		Me.cmdValider.TabIndex = 3
		Me.cmdValider.BackColor = System.Drawing.SystemColors.Control
		Me.cmdValider.CausesValidation = True
		Me.cmdValider.Enabled = True
		Me.cmdValider.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdValider.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdValider.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdValider.TabStop = True
		Me.cmdValider.Name = "cmdValider"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label3.Text = "SUPPRIMER"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(105, 25)
		Me.Label3.Location = New System.Drawing.Point(152, 16)
		Me.Label3.TabIndex = 8
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Enabled = True
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.lblValidation.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblValidation.BackColor = System.Drawing.Color.White
		Me.lblValidation.Size = New System.Drawing.Size(65, 25)
		Me.lblValidation.Location = New System.Drawing.Point(120, 176)
		Me.lblValidation.TabIndex = 6
		Me.lblValidation.Enabled = True
		Me.lblValidation.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblValidation.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblValidation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblValidation.UseMnemonic = True
		Me.lblValidation.Visible = True
		Me.lblValidation.AutoSize = False
		Me.lblValidation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblValidation.Name = "lblValidation"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label2.Text = "Veuillez réécrire le code de gauche dans la case de droite."
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(377, 25)
		Me.Label2.Location = New System.Drawing.Point(8, 136)
		Me.Label2.TabIndex = 5
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label1.Text = "Voulez-vous vraiment continuer ?"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(377, 25)
		Me.Label1.Location = New System.Drawing.Point(8, 96)
		Me.Label1.TabIndex = 2
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.lblNumero.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblNumero.Text = "M73000-06"
		Me.lblNumero.ForeColor = System.Drawing.Color.White
		Me.lblNumero.Size = New System.Drawing.Size(377, 25)
		Me.lblNumero.Location = New System.Drawing.Point(8, 40)
		Me.lblNumero.TabIndex = 1
		Me.lblNumero.BackColor = System.Drawing.Color.Transparent
		Me.lblNumero.Enabled = True
		Me.lblNumero.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblNumero.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblNumero.UseMnemonic = True
		Me.lblNumero.Visible = True
		Me.lblNumero.AutoSize = False
		Me.lblNumero.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblNumero.Name = "lblNumero"
		Me.lblAction.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.lblAction.Text = "Cette action va"
		Me.lblAction.ForeColor = System.Drawing.Color.White
		Me.lblAction.Size = New System.Drawing.Size(137, 25)
		Me.lblAction.Location = New System.Drawing.Point(8, 16)
		Me.lblAction.TabIndex = 0
		Me.lblAction.BackColor = System.Drawing.Color.Transparent
		Me.lblAction.Enabled = True
		Me.lblAction.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblAction.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblAction.UseMnemonic = True
		Me.lblAction.Visible = True
		Me.lblAction.AutoSize = False
		Me.lblAction.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblAction.Name = "lblAction"
		Me.lblProjSoum.Text = "la soumission"
		Me.lblProjSoum.ForeColor = System.Drawing.Color.White
		Me.lblProjSoum.Size = New System.Drawing.Size(121, 25)
		Me.lblProjSoum.Location = New System.Drawing.Point(264, 16)
		Me.lblProjSoum.TabIndex = 9
		Me.lblProjSoum.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblProjSoum.BackColor = System.Drawing.Color.Transparent
		Me.lblProjSoum.Enabled = True
		Me.lblProjSoum.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblProjSoum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblProjSoum.UseMnemonic = True
		Me.lblProjSoum.Visible = True
		Me.lblProjSoum.AutoSize = False
		Me.lblProjSoum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblProjSoum.Name = "lblProjSoum"
		Me.Controls.Add(txtValidation)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(cmdValider)
		Me.Controls.Add(Label3)
		Me.Controls.Add(lblValidation)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Controls.Add(lblNumero)
		Me.Controls.Add(lblAction)
		Me.Controls.Add(lblProjSoum)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class