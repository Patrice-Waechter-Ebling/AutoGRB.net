<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmLoginPrincipal
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
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents txtpasswd As System.Windows.Forms.TextBox
	Public WithEvents txtlogin As System.Windows.Forms.TextBox
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLoginPrincipal))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdOK = New System.Windows.Forms.Button
		Me.txtpasswd = New System.Windows.Forms.TextBox
		Me.txtlogin = New System.Windows.Forms.TextBox
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Login"
		Me.ClientSize = New System.Drawing.Size(312, 176)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmLoginPrincipal.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmLoginPrincipal"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(65, 33)
		Me.cmdCancel.Location = New System.Drawing.Point(208, 136)
		Me.cmdCancel.TabIndex = 5
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.Text = "OK"
		Me.AcceptButton = Me.cmdOK
		Me.cmdOK.Size = New System.Drawing.Size(65, 33)
		Me.cmdOK.Location = New System.Drawing.Point(96, 136)
		Me.cmdOK.TabIndex = 4
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me.txtpasswd.AutoSize = False
		Me.txtpasswd.BackColor = System.Drawing.Color.White
		Me.txtpasswd.Size = New System.Drawing.Size(169, 19)
		Me.txtpasswd.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.txtpasswd.Location = New System.Drawing.Point(104, 96)
		Me.txtpasswd.PasswordChar = ChrW(42)
		Me.txtpasswd.TabIndex = 3
		Me.txtpasswd.AcceptsReturn = True
		Me.txtpasswd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtpasswd.CausesValidation = True
		Me.txtpasswd.Enabled = True
		Me.txtpasswd.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtpasswd.HideSelection = True
		Me.txtpasswd.ReadOnly = False
		Me.txtpasswd.Maxlength = 0
		Me.txtpasswd.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtpasswd.MultiLine = False
		Me.txtpasswd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtpasswd.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtpasswd.TabStop = True
		Me.txtpasswd.Visible = True
		Me.txtpasswd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtpasswd.Name = "txtpasswd"
		Me.txtlogin.AutoSize = False
		Me.txtlogin.BackColor = System.Drawing.Color.White
		Me.txtlogin.Size = New System.Drawing.Size(169, 19)
		Me.txtlogin.Location = New System.Drawing.Point(104, 64)
		Me.txtlogin.TabIndex = 1
		Me.txtlogin.AcceptsReturn = True
		Me.txtlogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtlogin.CausesValidation = True
		Me.txtlogin.Enabled = True
		Me.txtlogin.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtlogin.HideSelection = True
		Me.txtlogin.ReadOnly = False
		Me.txtlogin.Maxlength = 0
		Me.txtlogin.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtlogin.MultiLine = False
		Me.txtlogin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtlogin.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtlogin.TabStop = True
		Me.txtlogin.Visible = True
		Me.txtlogin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtlogin.Name = "txtlogin"
		Me.Label2.Text = "Mot de passe:"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(81, 17)
		Me.Label2.Location = New System.Drawing.Point(16, 96)
		Me.Label2.TabIndex = 2
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
		Me.Label1.Text = "Utilisateur:"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(73, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 64)
		Me.Label1.TabIndex = 0
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
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(cmdOK)
		Me.Controls.Add(txtpasswd)
		Me.Controls.Add(txtlogin)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class