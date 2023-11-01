<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPhotoProjSoum
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
	Public WithEvents cmdPrécédent As System.Windows.Forms.Button
	Public WithEvents cmdSuivant As System.Windows.Forms.Button
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	Public WithEvents filPhotos As Microsoft.VisualBasic.Compatibility.VB6.FileListBox
	Public WithEvents imgProjSoum As System.Windows.Forms.PictureBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPhotoProjSoum))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdPrécédent = New System.Windows.Forms.Button
		Me.cmdSuivant = New System.Windows.Forms.Button
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.filPhotos = New Microsoft.VisualBasic.Compatibility.VB6.FileListBox
		Me.imgProjSoum = New System.Windows.Forms.PictureBox
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Photos"
		Me.ClientSize = New System.Drawing.Size(494, 382)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmPhotoProjSoum.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "frmPhotoProjSoum"
		Me.cmdPrécédent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPrécédent.Text = "Précédente"
		Me.cmdPrécédent.Size = New System.Drawing.Size(73, 25)
		Me.cmdPrécédent.Location = New System.Drawing.Point(112, 320)
		Me.cmdPrécédent.TabIndex = 1
		Me.cmdPrécédent.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrécédent.CausesValidation = True
		Me.cmdPrécédent.Enabled = True
		Me.cmdPrécédent.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrécédent.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrécédent.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrécédent.TabStop = True
		Me.cmdPrécédent.Name = "cmdPrécédent"
		Me.cmdSuivant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSuivant.Text = "Suivante"
		Me.cmdSuivant.Size = New System.Drawing.Size(73, 25)
		Me.cmdSuivant.Location = New System.Drawing.Point(304, 320)
		Me.cmdSuivant.TabIndex = 2
		Me.cmdSuivant.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSuivant.CausesValidation = True
		Me.cmdSuivant.Enabled = True
		Me.cmdSuivant.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSuivant.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSuivant.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSuivant.TabStop = True
		Me.cmdSuivant.Name = "cmdSuivant"
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(73, 25)
		Me.cmdFermer.Location = New System.Drawing.Point(416, 352)
		Me.cmdFermer.TabIndex = 3
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.filPhotos.Size = New System.Drawing.Size(73, 19)
		Me.filPhotos.Location = New System.Drawing.Point(208, 8)
		Me.filPhotos.TabIndex = 0
		Me.filPhotos.Visible = False
		Me.filPhotos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.filPhotos.Archive = True
		Me.filPhotos.BackColor = System.Drawing.SystemColors.Window
		Me.filPhotos.CausesValidation = True
		Me.filPhotos.Enabled = True
		Me.filPhotos.ForeColor = System.Drawing.SystemColors.WindowText
		Me.filPhotos.Hidden = False
		Me.filPhotos.Cursor = System.Windows.Forms.Cursors.Default
		Me.filPhotos.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.filPhotos.Normal = True
		Me.filPhotos.Pattern = "*.*"
		Me.filPhotos.ReadOnly = True
		Me.filPhotos.System = False
		Me.filPhotos.TabStop = True
		Me.filPhotos.TopIndex = 0
		Me.filPhotos.Name = "filPhotos"
		Me.imgProjSoum.Size = New System.Drawing.Size(481, 265)
		Me.imgProjSoum.Location = New System.Drawing.Point(8, 48)
		Me.imgProjSoum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.imgProjSoum.Enabled = True
		Me.imgProjSoum.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgProjSoum.Visible = True
		Me.imgProjSoum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.imgProjSoum.Name = "imgProjSoum"
		Me.Controls.Add(cmdPrécédent)
		Me.Controls.Add(cmdSuivant)
		Me.Controls.Add(cmdFermer)
		Me.Controls.Add(filPhotos)
		Me.Controls.Add(imgProjSoum)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class