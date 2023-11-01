<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixCommentaire
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
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents tvwCommentaire As System.Windows.Forms.TreeView
	Public WithEvents lblNoProjSoum As System.Windows.Forms.Label
	Public WithEvents lblTitreNoProjSoum As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixCommentaire))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdOK = New System.Windows.Forms.Button
		Me.tvwCommentaire = New System.Windows.Forms.TreeView
		Me.lblNoProjSoum = New System.Windows.Forms.Label
		Me.lblTitreNoProjSoum = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Commentaires"
		Me.ClientSize = New System.Drawing.Size(662, 626)
		Me.Location = New System.Drawing.Point(238, 216)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixCommentaire.BackgroundImage"), System.Drawing.Image)
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmChoixCommentaire"
		Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOK.Text = "OK"
		Me.cmdOK.Size = New System.Drawing.Size(105, 33)
		Me.cmdOK.Location = New System.Drawing.Point(552, 584)
		Me.cmdOK.TabIndex = 1
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me.tvwCommentaire.CausesValidation = True
		Me.tvwCommentaire.Size = New System.Drawing.Size(649, 505)
		Me.tvwCommentaire.Location = New System.Drawing.Point(8, 64)
		Me.tvwCommentaire.TabIndex = 0
		Me.tvwCommentaire.LabelEdit = False
		Me.tvwCommentaire.CheckBoxes = True
		Me.tvwCommentaire.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.tvwCommentaire.Name = "tvwCommentaire"
		Me.lblNoProjSoum.ForeColor = System.Drawing.Color.White
		Me.lblNoProjSoum.Size = New System.Drawing.Size(225, 17)
		Me.lblNoProjSoum.Location = New System.Drawing.Point(392, 8)
		Me.lblNoProjSoum.TabIndex = 3
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
		Me.lblTitreNoProjSoum.Text = "Numéro :"
		Me.lblTitreNoProjSoum.ForeColor = System.Drawing.Color.White
		Me.lblTitreNoProjSoum.Size = New System.Drawing.Size(105, 17)
		Me.lblTitreNoProjSoum.Location = New System.Drawing.Point(272, 8)
		Me.lblTitreNoProjSoum.TabIndex = 2
		Me.lblTitreNoProjSoum.BackColor = System.Drawing.Color.Transparent
		Me.lblTitreNoProjSoum.Enabled = True
		Me.lblTitreNoProjSoum.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblTitreNoProjSoum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblTitreNoProjSoum.UseMnemonic = True
		Me.lblTitreNoProjSoum.Visible = True
		Me.lblTitreNoProjSoum.AutoSize = False
		Me.lblTitreNoProjSoum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblTitreNoProjSoum.Name = "lblTitreNoProjSoum"
		Me.Controls.Add(cmdOK)
		Me.Controls.Add(tvwCommentaire)
		Me.Controls.Add(lblNoProjSoum)
		Me.Controls.Add(lblTitreNoProjSoum)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class