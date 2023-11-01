<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmFeuilleTempsCalendrier
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
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents mvwDate As AxMSComCtl2.AxMonthView
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFeuilleTempsCalendrier))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdOk = New System.Windows.Forms.Button
		Me.mvwDate = New AxMSComCtl2.AxMonthView
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.ControlBox = False
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
		Me.ClientSize = New System.Drawing.Size(248, 158)
		Me.Location = New System.Drawing.Point(4, 4)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmFeuilleTempsCalendrier"
		Me.cmdOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOk.Text = "OK"
		Me.cmdOk.Size = New System.Drawing.Size(57, 33)
		Me.cmdOk.Location = New System.Drawing.Point(184, 88)
		Me.cmdOk.TabIndex = 1
		Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOk.CausesValidation = True
		Me.cmdOk.Enabled = True
		Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOk.TabStop = True
		Me.cmdOk.Name = "cmdOk"
		mvwDate.OcxState = CType(resources.GetObject("mvwDate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.mvwDate.Size = New System.Drawing.Size(176, 158)
		Me.mvwDate.Location = New System.Drawing.Point(0, 0)
		Me.mvwDate.TabIndex = 0
		Me.mvwDate.Visible = False
		Me.mvwDate.Name = "mvwDate"
		Me.Controls.Add(cmdOk)
		Me.Controls.Add(mvwDate)
		CType(Me.mvwDate, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class