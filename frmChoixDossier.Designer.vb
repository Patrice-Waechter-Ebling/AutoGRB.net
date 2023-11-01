<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixDossier
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
	Public WithEvents drvCheminPhotos As Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents dirCheminPhotos As Microsoft.VisualBasic.Compatibility.VB6.DirListBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixDossier))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.drvCheminPhotos = New Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.cmdOK = New System.Windows.Forms.Button
		Me.dirCheminPhotos = New Microsoft.VisualBasic.Compatibility.VB6.DirListBox
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.Text = "Choix du dossier"
		Me.ClientSize = New System.Drawing.Size(270, 284)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.ControlBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixDossier.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmChoixDossier"
		Me.drvCheminPhotos.Size = New System.Drawing.Size(241, 21)
		Me.drvCheminPhotos.Location = New System.Drawing.Point(16, 56)
		Me.drvCheminPhotos.TabIndex = 0
		Me.drvCheminPhotos.BackColor = System.Drawing.SystemColors.Window
		Me.drvCheminPhotos.CausesValidation = True
		Me.drvCheminPhotos.Enabled = True
		Me.drvCheminPhotos.ForeColor = System.Drawing.SystemColors.WindowText
		Me.drvCheminPhotos.Cursor = System.Windows.Forms.Cursors.Default
		Me.drvCheminPhotos.TabStop = True
		Me.drvCheminPhotos.Visible = True
		Me.drvCheminPhotos.Name = "drvCheminPhotos"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(65, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(120, 256)
		Me.cmdAnnuler.TabIndex = 2
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOK.Text = "OK"
		Me.cmdOK.Size = New System.Drawing.Size(65, 25)
		Me.cmdOK.Location = New System.Drawing.Point(192, 256)
		Me.cmdOK.TabIndex = 3
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me.dirCheminPhotos.Size = New System.Drawing.Size(241, 171)
		Me.dirCheminPhotos.Location = New System.Drawing.Point(16, 80)
		Me.dirCheminPhotos.TabIndex = 1
		Me.dirCheminPhotos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.dirCheminPhotos.BackColor = System.Drawing.SystemColors.Window
		Me.dirCheminPhotos.CausesValidation = True
		Me.dirCheminPhotos.Enabled = True
		Me.dirCheminPhotos.ForeColor = System.Drawing.SystemColors.WindowText
		Me.dirCheminPhotos.Cursor = System.Windows.Forms.Cursors.Default
		Me.dirCheminPhotos.TabStop = True
		Me.dirCheminPhotos.Visible = True
		Me.dirCheminPhotos.Name = "dirCheminPhotos"
		Me.Controls.Add(drvCheminPhotos)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(cmdOK)
		Me.Controls.Add(dirCheminPhotos)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class