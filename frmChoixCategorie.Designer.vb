<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixCategorie
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
	Public WithEvents cmbCategorie As System.Windows.Forms.ComboBox
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixCategorie))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmbCategorie = New System.Windows.Forms.ComboBox
		Me.cmdOK = New System.Windows.Forms.Button
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Text = "Form1"
		Me.ClientSize = New System.Drawing.Size(257, 160)
		Me.Location = New System.Drawing.Point(0, 0)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixCategorie.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "frmChoixCategorie"
		Me.cmbCategorie.Size = New System.Drawing.Size(225, 21)
		Me.cmbCategorie.Location = New System.Drawing.Point(16, 88)
		Me.cmbCategorie.TabIndex = 1
		Me.cmbCategorie.Text = "cmbCategorie"
		Me.cmbCategorie.BackColor = System.Drawing.SystemColors.Window
		Me.cmbCategorie.CausesValidation = True
		Me.cmbCategorie.Enabled = True
		Me.cmbCategorie.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbCategorie.IntegralHeight = True
		Me.cmbCategorie.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbCategorie.Sorted = False
		Me.cmbCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbCategorie.TabStop = True
		Me.cmbCategorie.Visible = True
		Me.cmbCategorie.Name = "cmbCategorie"
		Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOK.Text = "OK"
		Me.cmdOK.Size = New System.Drawing.Size(65, 25)
		Me.cmdOK.Location = New System.Drawing.Point(176, 128)
		Me.cmdOK.TabIndex = 3
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(65, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(104, 128)
		Me.cmdAnnuler.TabIndex = 2
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.Label1.Text = "Dans quelle catégorie ?"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(161, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 56)
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
		Me.Controls.Add(cmbCategorie)
		Me.Controls.Add(cmdOK)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class