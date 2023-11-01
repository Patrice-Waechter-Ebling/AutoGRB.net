<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixBonCommande
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
	Public WithEvents cmdDeselectAll As System.Windows.Forms.Button
	Public WithEvents cmdSelectAll As System.Windows.Forms.Button
	Public WithEvents cmdAnnulerFRS As System.Windows.Forms.Button
	Public WithEvents cmdOKFRS As System.Windows.Forms.Button
	Public WithEvents _lvwFournisseur_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_7 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_8 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_9 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwFournisseur_ColumnHeader_10 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwFournisseur As System.Windows.Forms.ListView
	Public WithEvents fraFournisseur As System.Windows.Forms.GroupBox
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents cmdCommander As System.Windows.Forms.Button
	Public WithEvents _lvwPiece_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPiece_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPiece_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPiece_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPiece_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPiece_ColumnHeader_6 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwPiece As System.Windows.Forms.ListView
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixBonCommande))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdDeselectAll = New System.Windows.Forms.Button
		Me.cmdSelectAll = New System.Windows.Forms.Button
		Me.fraFournisseur = New System.Windows.Forms.GroupBox
		Me.cmdAnnulerFRS = New System.Windows.Forms.Button
		Me.cmdOKFRS = New System.Windows.Forms.Button
		Me.lvwFournisseur = New System.Windows.Forms.ListView
		Me._lvwFournisseur_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_7 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_8 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_9 = New System.Windows.Forms.ColumnHeader
		Me._lvwFournisseur_ColumnHeader_10 = New System.Windows.Forms.ColumnHeader
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.cmdCommander = New System.Windows.Forms.Button
		Me.lvwPiece = New System.Windows.Forms.ListView
		Me._lvwPiece_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwPiece_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwPiece_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwPiece_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwPiece_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me._lvwPiece_ColumnHeader_6 = New System.Windows.Forms.ColumnHeader
		Me.fraFournisseur.SuspendLayout()
		Me.lvwFournisseur.SuspendLayout()
		Me.lvwPiece.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Choix des pièces à commander"
		Me.ClientSize = New System.Drawing.Size(692, 434)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixBonCommande.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "frmChoixBonCommande"
		Me.cmdDeselectAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDeselectAll.Text = "Aucun"
		Me.cmdDeselectAll.Size = New System.Drawing.Size(73, 25)
		Me.cmdDeselectAll.Location = New System.Drawing.Point(88, 400)
		Me.cmdDeselectAll.TabIndex = 6
		Me.cmdDeselectAll.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDeselectAll.CausesValidation = True
		Me.cmdDeselectAll.Enabled = True
		Me.cmdDeselectAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDeselectAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDeselectAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDeselectAll.TabStop = True
		Me.cmdDeselectAll.Name = "cmdDeselectAll"
		Me.cmdSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSelectAll.Text = "Tous"
		Me.cmdSelectAll.Size = New System.Drawing.Size(73, 25)
		Me.cmdSelectAll.Location = New System.Drawing.Point(8, 400)
		Me.cmdSelectAll.TabIndex = 5
		Me.cmdSelectAll.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSelectAll.CausesValidation = True
		Me.cmdSelectAll.Enabled = True
		Me.cmdSelectAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSelectAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSelectAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSelectAll.TabStop = True
		Me.cmdSelectAll.Name = "cmdSelectAll"
		Me.fraFournisseur.BackColor = System.Drawing.Color.Black
		Me.fraFournisseur.Text = "Fournisseurs"
		Me.fraFournisseur.ForeColor = System.Drawing.Color.White
		Me.fraFournisseur.Size = New System.Drawing.Size(673, 161)
		Me.fraFournisseur.Location = New System.Drawing.Point(8, 56)
		Me.fraFournisseur.TabIndex = 0
		Me.fraFournisseur.Visible = False
		Me.fraFournisseur.Enabled = True
		Me.fraFournisseur.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraFournisseur.Padding = New System.Windows.Forms.Padding(0)
		Me.fraFournisseur.Name = "fraFournisseur"
		Me.cmdAnnulerFRS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnulerFRS.Text = "Annuler"
		Me.cmdAnnulerFRS.Size = New System.Drawing.Size(73, 25)
		Me.cmdAnnulerFRS.Location = New System.Drawing.Point(512, 128)
		Me.cmdAnnulerFRS.TabIndex = 2
		Me.cmdAnnulerFRS.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnulerFRS.CausesValidation = True
		Me.cmdAnnulerFRS.Enabled = True
		Me.cmdAnnulerFRS.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnulerFRS.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnulerFRS.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnulerFRS.TabStop = True
		Me.cmdAnnulerFRS.Name = "cmdAnnulerFRS"
		Me.cmdOKFRS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOKFRS.Text = "OK"
		Me.cmdOKFRS.Size = New System.Drawing.Size(73, 25)
		Me.cmdOKFRS.Location = New System.Drawing.Point(592, 128)
		Me.cmdOKFRS.TabIndex = 3
		Me.cmdOKFRS.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOKFRS.CausesValidation = True
		Me.cmdOKFRS.Enabled = True
		Me.cmdOKFRS.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOKFRS.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOKFRS.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOKFRS.TabStop = True
		Me.cmdOKFRS.Name = "cmdOKFRS"
		Me.lvwFournisseur.Size = New System.Drawing.Size(657, 105)
		Me.lvwFournisseur.Location = New System.Drawing.Point(8, 16)
		Me.lvwFournisseur.TabIndex = 1
		Me.lvwFournisseur.View = System.Windows.Forms.View.Details
		Me.lvwFournisseur.LabelEdit = False
		Me.lvwFournisseur.LabelWrap = True
		Me.lvwFournisseur.HideSelection = True
		Me.lvwFournisseur.FullRowSelect = True
		Me.lvwFournisseur.GridLines = True
		Me.lvwFournisseur.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwFournisseur.BackColor = System.Drawing.SystemColors.Window
		Me.lvwFournisseur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwFournisseur.Name = "lvwFournisseur"
		Me._lvwFournisseur_ColumnHeader_1.Text = "Fournisseur"
		Me._lvwFournisseur_ColumnHeader_1.Width = 236
		Me._lvwFournisseur_ColumnHeader_2.Text = "Pers. Ress."
		Me._lvwFournisseur_ColumnHeader_2.Width = 133
		Me._lvwFournisseur_ColumnHeader_3.Text = "Date"
		Me._lvwFournisseur_ColumnHeader_3.Width = 117
		Me._lvwFournisseur_ColumnHeader_4.Text = "Par"
		Me._lvwFournisseur_ColumnHeader_4.Width = 54
		Me._lvwFournisseur_ColumnHeader_5.Text = "Valide"
		Me._lvwFournisseur_ColumnHeader_5.Width = 117
		Me._lvwFournisseur_ColumnHeader_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._lvwFournisseur_ColumnHeader_6.Text = "Prix listé"
		Me._lvwFournisseur_ColumnHeader_6.Width = 108
		Me._lvwFournisseur_ColumnHeader_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._lvwFournisseur_ColumnHeader_7.Text = "Escompte"
		Me._lvwFournisseur_ColumnHeader_7.Width = 105
		Me._lvwFournisseur_ColumnHeader_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._lvwFournisseur_ColumnHeader_8.Text = "Prix net"
		Me._lvwFournisseur_ColumnHeader_8.Width = 108
		Me._lvwFournisseur_ColumnHeader_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._lvwFournisseur_ColumnHeader_9.Text = "Prix spécial"
		Me._lvwFournisseur_ColumnHeader_9.Width = 115
		Me._lvwFournisseur_ColumnHeader_10.Text = "Quoter"
		Me._lvwFournisseur_ColumnHeader_10.Width = 80
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(73, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(528, 400)
		Me.cmdAnnuler.TabIndex = 7
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.cmdCommander.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCommander.Text = "Commander"
		Me.cmdCommander.Size = New System.Drawing.Size(73, 25)
		Me.cmdCommander.Location = New System.Drawing.Point(608, 400)
		Me.cmdCommander.TabIndex = 8
		Me.cmdCommander.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCommander.CausesValidation = True
		Me.cmdCommander.Enabled = True
		Me.cmdCommander.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCommander.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCommander.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCommander.TabStop = True
		Me.cmdCommander.Name = "cmdCommander"
		Me.lvwPiece.Size = New System.Drawing.Size(673, 337)
		Me.lvwPiece.Location = New System.Drawing.Point(8, 56)
		Me.lvwPiece.TabIndex = 4
		Me.lvwPiece.View = System.Windows.Forms.View.Details
		Me.lvwPiece.LabelEdit = False
		Me.lvwPiece.LabelWrap = True
		Me.lvwPiece.HideSelection = True
		Me.lvwPiece.Checkboxes = True
		Me.lvwPiece.FullRowSelect = True
		Me.lvwPiece.GridLines = True
		Me.lvwPiece.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwPiece.BackColor = System.Drawing.SystemColors.Window
		Me.lvwPiece.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwPiece.Name = "lvwPiece"
		Me._lvwPiece_ColumnHeader_1.Text = "Qté"
		Me._lvwPiece_ColumnHeader_1.Width = 53
		Me._lvwPiece_ColumnHeader_2.Text = "No. Item"
		Me._lvwPiece_ColumnHeader_2.Width = 216
		Me._lvwPiece_ColumnHeader_3.Text = "Description"
		Me._lvwPiece_ColumnHeader_3.Width = 448
		Me._lvwPiece_ColumnHeader_4.Text = "Manufacturier"
		Me._lvwPiece_ColumnHeader_4.Width = 136
		Me._lvwPiece_ColumnHeader_5.Text = "Fournisseur"
		Me._lvwPiece_ColumnHeader_5.Width = 170
		Me._lvwPiece_ColumnHeader_6.Text = "Stock"
		Me._lvwPiece_ColumnHeader_6.Width = 170
		Me.Controls.Add(cmdDeselectAll)
		Me.Controls.Add(cmdSelectAll)
		Me.Controls.Add(fraFournisseur)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(cmdCommander)
		Me.Controls.Add(lvwPiece)
		Me.fraFournisseur.Controls.Add(cmdAnnulerFRS)
		Me.fraFournisseur.Controls.Add(cmdOKFRS)
		Me.fraFournisseur.Controls.Add(lvwFournisseur)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_1)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_2)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_3)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_4)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_5)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_6)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_7)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_8)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_9)
		Me.lvwFournisseur.Columns.Add(_lvwFournisseur_ColumnHeader_10)
		Me.lvwPiece.Columns.Add(_lvwPiece_ColumnHeader_1)
		Me.lvwPiece.Columns.Add(_lvwPiece_ColumnHeader_2)
		Me.lvwPiece.Columns.Add(_lvwPiece_ColumnHeader_3)
		Me.lvwPiece.Columns.Add(_lvwPiece_ColumnHeader_4)
		Me.lvwPiece.Columns.Add(_lvwPiece_ColumnHeader_5)
		Me.lvwPiece.Columns.Add(_lvwPiece_ColumnHeader_6)
		Me.fraFournisseur.ResumeLayout(False)
		Me.lvwFournisseur.ResumeLayout(False)
		Me.lvwPiece.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class