<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixInventaire
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
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	Public WithEvents cmdOutils As System.Windows.Forms.Button
	Public WithEvents cmdElectrique As System.Windows.Forms.Button
	Public WithEvents cmdMecanique As System.Windows.Forms.Button
	Public WithEvents cmdSortie As System.Windows.Forms.Button
	Public WithEvents cmdRetour As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixInventaire))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.cmdOutils = New System.Windows.Forms.Button
		Me.cmdElectrique = New System.Windows.Forms.Button
		Me.cmdMecanique = New System.Windows.Forms.Button
		Me.cmdSortie = New System.Windows.Forms.Button
		Me.cmdRetour = New System.Windows.Forms.Button
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Inventaire"
		Me.ClientSize = New System.Drawing.Size(217, 250)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixInventaire.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmChoixInventaire"
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(121, 25)
		Me.cmdFermer.Location = New System.Drawing.Point(48, 200)
		Me.cmdFermer.TabIndex = 5
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.cmdOutils.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOutils.Text = "Outils"
		Me.cmdOutils.Size = New System.Drawing.Size(121, 25)
		Me.cmdOutils.Location = New System.Drawing.Point(48, 136)
		Me.cmdOutils.TabIndex = 2
		Me.cmdOutils.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOutils.CausesValidation = True
		Me.cmdOutils.Enabled = True
		Me.cmdOutils.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOutils.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOutils.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOutils.TabStop = True
		Me.cmdOutils.Name = "cmdOutils"
		Me.cmdElectrique.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdElectrique.Text = "Électrique"
		Me.cmdElectrique.Size = New System.Drawing.Size(121, 25)
		Me.cmdElectrique.Location = New System.Drawing.Point(48, 72)
		Me.cmdElectrique.TabIndex = 0
		Me.cmdElectrique.BackColor = System.Drawing.SystemColors.Control
		Me.cmdElectrique.CausesValidation = True
		Me.cmdElectrique.Enabled = True
		Me.cmdElectrique.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdElectrique.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdElectrique.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdElectrique.TabStop = True
		Me.cmdElectrique.Name = "cmdElectrique"
		Me.cmdMecanique.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMecanique.Text = "Mécanique"
		Me.cmdMecanique.Size = New System.Drawing.Size(121, 25)
		Me.cmdMecanique.Location = New System.Drawing.Point(48, 104)
		Me.cmdMecanique.TabIndex = 1
		Me.cmdMecanique.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMecanique.CausesValidation = True
		Me.cmdMecanique.Enabled = True
		Me.cmdMecanique.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMecanique.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMecanique.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMecanique.TabStop = True
		Me.cmdMecanique.Name = "cmdMecanique"
		Me.cmdSortie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSortie.Text = "Sortie de matériel"
		Me.cmdSortie.Size = New System.Drawing.Size(121, 25)
		Me.cmdSortie.Location = New System.Drawing.Point(48, 168)
		Me.cmdSortie.TabIndex = 3
		Me.cmdSortie.Visible = False
		Me.cmdSortie.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSortie.CausesValidation = True
		Me.cmdSortie.Enabled = True
		Me.cmdSortie.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSortie.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSortie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSortie.TabStop = True
		Me.cmdSortie.Name = "cmdSortie"
		Me.cmdRetour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRetour.Text = "Retour de matériel"
		Me.cmdRetour.Size = New System.Drawing.Size(121, 25)
		Me.cmdRetour.Location = New System.Drawing.Point(48, 200)
		Me.cmdRetour.TabIndex = 4
		Me.cmdRetour.Visible = False
		Me.cmdRetour.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRetour.CausesValidation = True
		Me.cmdRetour.Enabled = True
		Me.cmdRetour.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRetour.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRetour.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRetour.TabStop = True
		Me.cmdRetour.Name = "cmdRetour"
		Me.Controls.Add(cmdFermer)
		Me.Controls.Add(cmdOutils)
		Me.Controls.Add(cmdElectrique)
		Me.Controls.Add(cmdMecanique)
		Me.Controls.Add(cmdSortie)
		Me.Controls.Add(cmdRetour)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class