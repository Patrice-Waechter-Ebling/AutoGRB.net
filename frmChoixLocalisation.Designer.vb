<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixLocalisation
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
	Public WithEvents cmbLocalisation As System.Windows.Forms.ComboBox
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents lblQuestion As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixLocalisation))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmbLocalisation = New System.Windows.Forms.ComboBox
		Me.cmdOK = New System.Windows.Forms.Button
		Me.lblQuestion = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Text = "Form1"
		Me.ClientSize = New System.Drawing.Size(259, 160)
		Me.Location = New System.Drawing.Point(0, 0)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixLocalisation.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "frmChoixLocalisation"
		Me.cmbLocalisation.Size = New System.Drawing.Size(241, 21)
		Me.cmbLocalisation.Location = New System.Drawing.Point(8, 96)
		Me.cmbLocalisation.TabIndex = 1
		Me.cmbLocalisation.BackColor = System.Drawing.SystemColors.Window
		Me.cmbLocalisation.CausesValidation = True
		Me.cmbLocalisation.Enabled = True
		Me.cmbLocalisation.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbLocalisation.IntegralHeight = True
		Me.cmbLocalisation.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbLocalisation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbLocalisation.Sorted = False
		Me.cmbLocalisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbLocalisation.TabStop = True
		Me.cmbLocalisation.Visible = True
		Me.cmbLocalisation.Name = "cmbLocalisation"
		Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOK.Text = "OK"
		Me.cmdOK.Size = New System.Drawing.Size(65, 25)
		Me.cmdOK.Location = New System.Drawing.Point(184, 128)
		Me.cmdOK.TabIndex = 2
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me.lblQuestion.Text = "Dans quelle localisation ?"
		Me.lblQuestion.ForeColor = System.Drawing.Color.White
		Me.lblQuestion.Size = New System.Drawing.Size(241, 33)
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
		Me.Controls.Add(cmbLocalisation)
		Me.Controls.Add(cmdOK)
		Me.Controls.Add(lblQuestion)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class