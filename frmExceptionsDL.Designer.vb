<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmExceptionsDL
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
	Public WithEvents cmdSupprimer As System.Windows.Forms.Button
	Public WithEvents cmdAjouter As System.Windows.Forms.Button
	Public WithEvents _lvwExceptions_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwExceptions As System.Windows.Forms.ListView
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmExceptionsDL))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdSupprimer = New System.Windows.Forms.Button
		Me.cmdAjouter = New System.Windows.Forms.Button
		Me.lvwExceptions = New System.Windows.Forms.ListView
		Me._lvwExceptions_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.lvwExceptions.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Exceptions des listes de distribution"
		Me.ClientSize = New System.Drawing.Size(422, 383)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmExceptionsDL.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmExceptionsDL"
		Me.cmdSupprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSupprimer.Text = "Supprimer"
		Me.cmdSupprimer.Size = New System.Drawing.Size(97, 25)
		Me.cmdSupprimer.Location = New System.Drawing.Point(312, 136)
		Me.cmdSupprimer.TabIndex = 1
		Me.cmdSupprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSupprimer.CausesValidation = True
		Me.cmdSupprimer.Enabled = True
		Me.cmdSupprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSupprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSupprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSupprimer.TabStop = True
		Me.cmdSupprimer.Name = "cmdSupprimer"
		Me.cmdAjouter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAjouter.Text = "Ajouter"
		Me.cmdAjouter.Size = New System.Drawing.Size(97, 25)
		Me.cmdAjouter.Location = New System.Drawing.Point(312, 96)
		Me.cmdAjouter.TabIndex = 0
		Me.cmdAjouter.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAjouter.CausesValidation = True
		Me.cmdAjouter.Enabled = True
		Me.cmdAjouter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAjouter.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAjouter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAjouter.TabStop = True
		Me.cmdAjouter.Name = "cmdAjouter"
		Me.lvwExceptions.Size = New System.Drawing.Size(281, 281)
		Me.lvwExceptions.Location = New System.Drawing.Point(16, 88)
		Me.lvwExceptions.TabIndex = 2
		Me.lvwExceptions.View = System.Windows.Forms.View.Details
		Me.lvwExceptions.LabelEdit = False
		Me.lvwExceptions.LabelWrap = True
		Me.lvwExceptions.HideSelection = True
		Me.lvwExceptions.FullRowSelect = True
		Me.lvwExceptions.GridLines = True
		Me.lvwExceptions.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwExceptions.BackColor = System.Drawing.SystemColors.Window
		Me.lvwExceptions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwExceptions.Name = "lvwExceptions"
		Me._lvwExceptions_ColumnHeader_1.Text = "Courriel"
		Me._lvwExceptions_ColumnHeader_1.Width = 447
		Me.Controls.Add(cmdSupprimer)
		Me.Controls.Add(cmdAjouter)
		Me.Controls.Add(lvwExceptions)
		Me.lvwExceptions.Columns.Add(_lvwExceptions_ColumnHeader_1)
		Me.lvwExceptions.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class