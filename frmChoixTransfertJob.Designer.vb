<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixTransfertJob
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
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents cmdCreer As System.Windows.Forms.Button
	Public WithEvents _lvwPiece_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPiece_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPiece_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPiece_ColumnHeader_4 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwPiece_ColumnHeader_5 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwPiece As System.Windows.Forms.ListView
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixTransfertJob))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdDeselectAll = New System.Windows.Forms.Button
		Me.cmdSelectAll = New System.Windows.Forms.Button
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.cmdCreer = New System.Windows.Forms.Button
		Me.lvwPiece = New System.Windows.Forms.ListView
		Me._lvwPiece_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwPiece_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwPiece_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me._lvwPiece_ColumnHeader_4 = New System.Windows.Forms.ColumnHeader
		Me._lvwPiece_ColumnHeader_5 = New System.Windows.Forms.ColumnHeader
		Me.lvwPiece.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Choix des pièces à transférer dans le projet"
		Me.ClientSize = New System.Drawing.Size(821, 621)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixTransfertJob.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "frmChoixTransfertJob"
		Me.cmdDeselectAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDeselectAll.Text = "Aucun"
		Me.cmdDeselectAll.Size = New System.Drawing.Size(73, 25)
		Me.cmdDeselectAll.Location = New System.Drawing.Point(88, 584)
		Me.cmdDeselectAll.TabIndex = 2
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
		Me.cmdSelectAll.Location = New System.Drawing.Point(8, 584)
		Me.cmdSelectAll.TabIndex = 1
		Me.cmdSelectAll.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSelectAll.CausesValidation = True
		Me.cmdSelectAll.Enabled = True
		Me.cmdSelectAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSelectAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSelectAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSelectAll.TabStop = True
		Me.cmdSelectAll.Name = "cmdSelectAll"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(81, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(640, 584)
		Me.cmdAnnuler.TabIndex = 3
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.cmdCreer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCreer.Text = "Créer le projet"
		Me.cmdCreer.Size = New System.Drawing.Size(81, 25)
		Me.cmdCreer.Location = New System.Drawing.Point(728, 584)
		Me.cmdCreer.TabIndex = 4
		Me.cmdCreer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCreer.CausesValidation = True
		Me.cmdCreer.Enabled = True
		Me.cmdCreer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCreer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCreer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCreer.TabStop = True
		Me.cmdCreer.Name = "cmdCreer"
		Me.lvwPiece.Size = New System.Drawing.Size(801, 489)
		Me.lvwPiece.Location = New System.Drawing.Point(8, 80)
		Me.lvwPiece.TabIndex = 0
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
		Me.Controls.Add(cmdDeselectAll)
		Me.Controls.Add(cmdSelectAll)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(cmdCreer)
		Me.Controls.Add(lvwPiece)
		Me.lvwPiece.Columns.Add(_lvwPiece_ColumnHeader_1)
		Me.lvwPiece.Columns.Add(_lvwPiece_ColumnHeader_2)
		Me.lvwPiece.Columns.Add(_lvwPiece_ColumnHeader_3)
		Me.lvwPiece.Columns.Add(_lvwPiece_ColumnHeader_4)
		Me.lvwPiece.Columns.Add(_lvwPiece_ColumnHeader_5)
		Me.lvwPiece.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class