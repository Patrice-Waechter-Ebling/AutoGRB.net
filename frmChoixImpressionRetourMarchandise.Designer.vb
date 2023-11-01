<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixImpressionRetourMarchandise
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
	Public WithEvents optDemande As System.Windows.Forms.RadioButton
	Public WithEvents optRetour As System.Windows.Forms.RadioButton
	Public WithEvents cmdImprimer As System.Windows.Forms.Button
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixImpressionRetourMarchandise))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.optDemande = New System.Windows.Forms.RadioButton
		Me.optRetour = New System.Windows.Forms.RadioButton
		Me.cmdImprimer = New System.Windows.Forms.Button
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Choix d'impression"
		Me.ClientSize = New System.Drawing.Size(281, 144)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixImpressionRetourMarchandise.BackgroundImage"), System.Drawing.Image)
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmChoixImpressionRetourMarchandise"
		Me.optDemande.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optDemande.BackColor = System.Drawing.Color.Black
		Me.optDemande.Text = "Demande de retour de marchandise"
		Me.optDemande.ForeColor = System.Drawing.Color.White
		Me.optDemande.Size = New System.Drawing.Size(193, 17)
		Me.optDemande.Location = New System.Drawing.Point(8, 72)
		Me.optDemande.TabIndex = 1
		Me.optDemande.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optDemande.CausesValidation = True
		Me.optDemande.Enabled = True
		Me.optDemande.Cursor = System.Windows.Forms.Cursors.Default
		Me.optDemande.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optDemande.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optDemande.TabStop = True
		Me.optDemande.Checked = False
		Me.optDemande.Visible = True
		Me.optDemande.Name = "optDemande"
		Me.optRetour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optRetour.BackColor = System.Drawing.Color.Black
		Me.optRetour.Text = "Retour de marchandise"
		Me.optRetour.ForeColor = System.Drawing.Color.White
		Me.optRetour.Size = New System.Drawing.Size(193, 17)
		Me.optRetour.Location = New System.Drawing.Point(8, 96)
		Me.optRetour.TabIndex = 2
		Me.optRetour.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optRetour.CausesValidation = True
		Me.optRetour.Enabled = True
		Me.optRetour.Cursor = System.Windows.Forms.Cursors.Default
		Me.optRetour.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optRetour.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optRetour.TabStop = True
		Me.optRetour.Checked = False
		Me.optRetour.Visible = True
		Me.optRetour.Name = "optRetour"
		Me.cmdImprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdImprimer.Text = "Imprimer"
		Me.cmdImprimer.Size = New System.Drawing.Size(65, 25)
		Me.cmdImprimer.Location = New System.Drawing.Point(208, 64)
		Me.cmdImprimer.TabIndex = 0
		Me.cmdImprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdImprimer.CausesValidation = True
		Me.cmdImprimer.Enabled = True
		Me.cmdImprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdImprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdImprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdImprimer.TabStop = True
		Me.cmdImprimer.Name = "cmdImprimer"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(65, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(208, 96)
		Me.cmdAnnuler.TabIndex = 3
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.Controls.Add(optDemande)
		Me.Controls.Add(optRetour)
		Me.Controls.Add(cmdImprimer)
		Me.Controls.Add(cmdAnnuler)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class