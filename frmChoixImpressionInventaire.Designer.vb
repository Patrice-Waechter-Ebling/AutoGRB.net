<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixImpressionInventaire
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
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents cmdImprimer As System.Windows.Forms.Button
	Public WithEvents optValeurComptable As System.Windows.Forms.RadioButton
	Public WithEvents optAjustementInventaire As System.Windows.Forms.RadioButton
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixImpressionInventaire))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.cmdImprimer = New System.Windows.Forms.Button
		Me.optValeurComptable = New System.Windows.Forms.RadioButton
		Me.optAjustementInventaire = New System.Windows.Forms.RadioButton
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Quelle impression ?"
		Me.ClientSize = New System.Drawing.Size(258, 144)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixImpressionInventaire.BackgroundImage"), System.Drawing.Image)
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmChoixImpressionInventaire"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(65, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(184, 96)
		Me.cmdAnnuler.TabIndex = 3
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.cmdImprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdImprimer.Text = "Imprimer"
		Me.cmdImprimer.Size = New System.Drawing.Size(65, 25)
		Me.cmdImprimer.Location = New System.Drawing.Point(184, 64)
		Me.cmdImprimer.TabIndex = 0
		Me.cmdImprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdImprimer.CausesValidation = True
		Me.cmdImprimer.Enabled = True
		Me.cmdImprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdImprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdImprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdImprimer.TabStop = True
		Me.cmdImprimer.Name = "cmdImprimer"
		Me.optValeurComptable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optValeurComptable.BackColor = System.Drawing.Color.Black
		Me.optValeurComptable.Text = "Valeurs comptables"
		Me.optValeurComptable.ForeColor = System.Drawing.Color.White
		Me.optValeurComptable.Size = New System.Drawing.Size(129, 17)
		Me.optValeurComptable.Location = New System.Drawing.Point(16, 96)
		Me.optValeurComptable.TabIndex = 2
		Me.optValeurComptable.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optValeurComptable.CausesValidation = True
		Me.optValeurComptable.Enabled = True
		Me.optValeurComptable.Cursor = System.Windows.Forms.Cursors.Default
		Me.optValeurComptable.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optValeurComptable.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optValeurComptable.TabStop = True
		Me.optValeurComptable.Checked = False
		Me.optValeurComptable.Visible = True
		Me.optValeurComptable.Name = "optValeurComptable"
		Me.optAjustementInventaire.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optAjustementInventaire.BackColor = System.Drawing.Color.Black
		Me.optAjustementInventaire.Text = "Ajustement de l'inventaire"
		Me.optAjustementInventaire.ForeColor = System.Drawing.Color.White
		Me.optAjustementInventaire.Size = New System.Drawing.Size(145, 17)
		Me.optAjustementInventaire.Location = New System.Drawing.Point(16, 72)
		Me.optAjustementInventaire.TabIndex = 1
		Me.optAjustementInventaire.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optAjustementInventaire.CausesValidation = True
		Me.optAjustementInventaire.Enabled = True
		Me.optAjustementInventaire.Cursor = System.Windows.Forms.Cursors.Default
		Me.optAjustementInventaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optAjustementInventaire.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optAjustementInventaire.TabStop = True
		Me.optAjustementInventaire.Checked = False
		Me.optAjustementInventaire.Visible = True
		Me.optAjustementInventaire.Name = "optAjustementInventaire"
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(cmdImprimer)
		Me.Controls.Add(optValeurComptable)
		Me.Controls.Add(optAjustementInventaire)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class