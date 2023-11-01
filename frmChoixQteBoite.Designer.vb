<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixQteBoite
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
	Public WithEvents txtQteBoite As System.Windows.Forms.TextBox
	Public WithEvents chkQteBoite As System.Windows.Forms.CheckBox
	Public WithEvents lblQuestion As System.Windows.Forms.Label
	Public WithEvents lblQteBoite As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixQteBoite))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdOK = New System.Windows.Forms.Button
		Me.txtQteBoite = New System.Windows.Forms.TextBox
		Me.chkQteBoite = New System.Windows.Forms.CheckBox
		Me.lblQuestion = New System.Windows.Forms.Label
		Me.lblQteBoite = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.ControlBox = False
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.ClientSize = New System.Drawing.Size(259, 186)
		Me.Location = New System.Drawing.Point(0, 0)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixQteBoite.BackgroundImage"), System.Drawing.Image)
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmChoixQteBoite"
		Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOK.Text = "OK"
		Me.cmdOK.Size = New System.Drawing.Size(65, 25)
		Me.cmdOK.Location = New System.Drawing.Point(168, 152)
		Me.cmdOK.TabIndex = 4
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me.txtQteBoite.AutoSize = False
		Me.txtQteBoite.Enabled = False
		Me.txtQteBoite.Size = New System.Drawing.Size(65, 19)
		Me.txtQteBoite.Location = New System.Drawing.Point(120, 120)
		Me.txtQteBoite.TabIndex = 3
		Me.txtQteBoite.AcceptsReturn = True
		Me.txtQteBoite.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtQteBoite.BackColor = System.Drawing.SystemColors.Window
		Me.txtQteBoite.CausesValidation = True
		Me.txtQteBoite.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtQteBoite.HideSelection = True
		Me.txtQteBoite.ReadOnly = False
		Me.txtQteBoite.Maxlength = 0
		Me.txtQteBoite.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtQteBoite.MultiLine = False
		Me.txtQteBoite.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtQteBoite.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtQteBoite.TabStop = True
		Me.txtQteBoite.Visible = True
		Me.txtQteBoite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtQteBoite.Name = "txtQteBoite"
		Me.chkQteBoite.BackColor = System.Drawing.Color.Black
		Me.chkQteBoite.Text = "Commande par boîte"
		Me.chkQteBoite.ForeColor = System.Drawing.Color.White
		Me.chkQteBoite.Size = New System.Drawing.Size(145, 17)
		Me.chkQteBoite.Location = New System.Drawing.Point(56, 96)
		Me.chkQteBoite.TabIndex = 1
		Me.chkQteBoite.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkQteBoite.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkQteBoite.CausesValidation = True
		Me.chkQteBoite.Enabled = True
		Me.chkQteBoite.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkQteBoite.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkQteBoite.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkQteBoite.TabStop = True
		Me.chkQteBoite.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkQteBoite.Visible = True
		Me.chkQteBoite.Name = "chkQteBoite"
		Me.lblQuestion.Text = "Quelle est la quantité par boîte pour la pièce ?"
		Me.lblQuestion.ForeColor = System.Drawing.Color.White
		Me.lblQuestion.Size = New System.Drawing.Size(241, 25)
		Me.lblQuestion.Location = New System.Drawing.Point(8, 64)
		Me.lblQuestion.TabIndex = 0
		Me.lblQuestion.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblQuestion.BackColor = System.Drawing.Color.Transparent
		Me.lblQuestion.Enabled = True
		Me.lblQuestion.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblQuestion.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblQuestion.UseMnemonic = True
		Me.lblQuestion.Visible = True
		Me.lblQuestion.AutoSize = False
		Me.lblQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblQuestion.Name = "lblQuestion"
		Me.lblQteBoite.Text = "Quantité :"
		Me.lblQteBoite.ForeColor = System.Drawing.Color.White
		Me.lblQteBoite.Size = New System.Drawing.Size(57, 17)
		Me.lblQteBoite.Location = New System.Drawing.Point(56, 120)
		Me.lblQteBoite.TabIndex = 2
		Me.lblQteBoite.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblQteBoite.BackColor = System.Drawing.Color.Transparent
		Me.lblQteBoite.Enabled = True
		Me.lblQteBoite.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblQteBoite.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblQteBoite.UseMnemonic = True
		Me.lblQteBoite.Visible = True
		Me.lblQteBoite.AutoSize = False
		Me.lblQteBoite.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblQteBoite.Name = "lblQteBoite"
		Me.Controls.Add(cmdOK)
		Me.Controls.Add(txtQteBoite)
		Me.Controls.Add(chkQteBoite)
		Me.Controls.Add(lblQuestion)
		Me.Controls.Add(lblQteBoite)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class