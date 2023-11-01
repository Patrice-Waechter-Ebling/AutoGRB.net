<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixMailList
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
	Public WithEvents _lvwDistList_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwDistList_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwDistList_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwDistList As System.Windows.Forms.ListView
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixMailList))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.lvwDistList = New System.Windows.Forms.ListView
		Me._lvwDistList_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwDistList_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwDistList_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.cmdOK = New System.Windows.Forms.Button
		Me.Label1 = New System.Windows.Forms.Label
		Me.lvwDistList.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.Text = "Choix de la liste de distribution"
		Me.ClientSize = New System.Drawing.Size(446, 271)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.ControlBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixMailList.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
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
		Me.Name = "frmChoixMailList"
		Me.lvwDistList.Size = New System.Drawing.Size(417, 113)
		Me.lvwDistList.Location = New System.Drawing.Point(16, 104)
		Me.lvwDistList.TabIndex = 3
		Me.lvwDistList.View = System.Windows.Forms.View.Details
		Me.lvwDistList.LabelEdit = False
		Me.lvwDistList.LabelWrap = True
		Me.lvwDistList.HideSelection = True
		Me.lvwDistList.FullRowSelect = True
		Me.lvwDistList.GridLines = True
		Me.lvwDistList.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwDistList.BackColor = System.Drawing.SystemColors.Window
		Me.lvwDistList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwDistList.Name = "lvwDistList"
		Me._lvwDistList_ColumnHeader_1.Text = "Liste"
		Me._lvwDistList_ColumnHeader_1.Width = 293
		Me._lvwDistList_ColumnHeader_2.Text = "Nombre de contacts"
		Me._lvwDistList_ColumnHeader_2.Width = 191
		Me._lvwDistList_ColumnHeader_3.Text = "Dossier"
		Me._lvwDistList_ColumnHeader_3.Width = 212
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(81, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(256, 232)
		Me.cmdAnnuler.TabIndex = 1
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
		Me.cmdOK.Size = New System.Drawing.Size(81, 25)
		Me.cmdOK.Location = New System.Drawing.Point(352, 232)
		Me.cmdOK.TabIndex = 2
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label1.Text = "Dans quelle liste de distribution voulez-vous l'ajouter ?"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(433, 33)
		Me.Label1.Location = New System.Drawing.Point(8, 72)
		Me.Label1.TabIndex = 0
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(lvwDistList)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(cmdOK)
		Me.Controls.Add(Label1)
		Me.lvwDistList.Columns.Add(_lvwDistList_ColumnHeader_1)
		Me.lvwDistList.Columns.Add(_lvwDistList_ColumnHeader_2)
		Me.lvwDistList.Columns.Add(_lvwDistList_ColumnHeader_3)
		Me.lvwDistList.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class