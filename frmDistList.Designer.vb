<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmDistList
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
	Public WithEvents cmdCreerListe As System.Windows.Forms.Button
	Public WithEvents _lvwContacts_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwContacts_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwContacts_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwContacts As System.Windows.Forms.ListView
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents cmdAfficher As System.Windows.Forms.Button
	Public WithEvents cmdRafraichir As System.Windows.Forms.Button
	Public WithEvents _lvwDistList_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwDistList_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lvwDistList_ColumnHeader_3 As System.Windows.Forms.ColumnHeader
	Public WithEvents lvwDistList As System.Windows.Forms.ListView
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDistList))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdCreerListe = New System.Windows.Forms.Button
		Me.Frame2 = New System.Windows.Forms.GroupBox
		Me.lvwContacts = New System.Windows.Forms.ListView
		Me._lvwContacts_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwContacts_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwContacts_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.cmdAfficher = New System.Windows.Forms.Button
		Me.cmdRafraichir = New System.Windows.Forms.Button
		Me.lvwDistList = New System.Windows.Forms.ListView
		Me._lvwDistList_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lvwDistList_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me._lvwDistList_ColumnHeader_3 = New System.Windows.Forms.ColumnHeader
		Me.Frame2.SuspendLayout()
		Me.lvwContacts.SuspendLayout()
		Me.Frame1.SuspendLayout()
		Me.lvwDistList.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Listes de distribution"
		Me.ClientSize = New System.Drawing.Size(875, 758)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmDistList.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "frmDistList"
		Me.cmdCreerListe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCreerListe.Text = "Recréer les listes"
		Me.cmdCreerListe.Size = New System.Drawing.Size(137, 25)
		Me.cmdCreerListe.Location = New System.Drawing.Point(728, 720)
		Me.cmdCreerListe.TabIndex = 4
		Me.cmdCreerListe.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCreerListe.CausesValidation = True
		Me.cmdCreerListe.Enabled = True
		Me.cmdCreerListe.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCreerListe.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCreerListe.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCreerListe.TabStop = True
		Me.cmdCreerListe.Name = "cmdCreerListe"
		Me.Frame2.BackColor = System.Drawing.Color.Black
		Me.Frame2.Text = "Contacts"
		Me.Frame2.ForeColor = System.Drawing.Color.White
		Me.Frame2.Size = New System.Drawing.Size(849, 401)
		Me.Frame2.Location = New System.Drawing.Point(16, 304)
		Me.Frame2.TabIndex = 1
		Me.Frame2.Enabled = True
		Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame2.Visible = True
		Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame2.Name = "Frame2"
		Me.lvwContacts.Size = New System.Drawing.Size(833, 369)
		Me.lvwContacts.Location = New System.Drawing.Point(8, 24)
		Me.lvwContacts.TabIndex = 3
		Me.lvwContacts.View = System.Windows.Forms.View.Details
		Me.lvwContacts.LabelEdit = False
		Me.lvwContacts.LabelWrap = True
		Me.lvwContacts.HideSelection = True
		Me.lvwContacts.FullRowSelect = True
		Me.lvwContacts.GridLines = True
		Me.lvwContacts.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwContacts.BackColor = System.Drawing.SystemColors.Window
		Me.lvwContacts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwContacts.Name = "lvwContacts"
		Me._lvwContacts_ColumnHeader_1.Text = "Nom"
		Me._lvwContacts_ColumnHeader_1.Width = 718
		Me._lvwContacts_ColumnHeader_2.Text = "Courriel"
		Me._lvwContacts_ColumnHeader_2.Width = 463
		Me._lvwContacts_ColumnHeader_3.Text = "Liste"
		Me._lvwContacts_ColumnHeader_3.Width = 237
		Me.Frame1.BackColor = System.Drawing.Color.Black
		Me.Frame1.Text = "Listes"
		Me.Frame1.ForeColor = System.Drawing.Color.White
		Me.Frame1.Size = New System.Drawing.Size(785, 217)
		Me.Frame1.Location = New System.Drawing.Point(16, 72)
		Me.Frame1.TabIndex = 0
		Me.Frame1.Enabled = True
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame1.Name = "Frame1"
		Me.cmdAfficher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAfficher.Text = "Afficher"
		Me.cmdAfficher.Size = New System.Drawing.Size(137, 25)
		Me.cmdAfficher.Location = New System.Drawing.Point(632, 64)
		Me.cmdAfficher.TabIndex = 6
		Me.cmdAfficher.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAfficher.CausesValidation = True
		Me.cmdAfficher.Enabled = True
		Me.cmdAfficher.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAfficher.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAfficher.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAfficher.TabStop = True
		Me.cmdAfficher.Name = "cmdAfficher"
		Me.cmdRafraichir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRafraichir.Text = "Rafraîchir"
		Me.cmdRafraichir.Size = New System.Drawing.Size(137, 25)
		Me.cmdRafraichir.Location = New System.Drawing.Point(632, 24)
		Me.cmdRafraichir.TabIndex = 5
		Me.cmdRafraichir.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRafraichir.CausesValidation = True
		Me.cmdRafraichir.Enabled = True
		Me.cmdRafraichir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRafraichir.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRafraichir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRafraichir.TabStop = True
		Me.cmdRafraichir.Name = "cmdRafraichir"
		Me.lvwDistList.Size = New System.Drawing.Size(609, 177)
		Me.lvwDistList.Location = New System.Drawing.Point(8, 24)
		Me.lvwDistList.TabIndex = 2
		Me.lvwDistList.View = System.Windows.Forms.View.Details
		Me.lvwDistList.LabelEdit = False
		Me.lvwDistList.MultiSelect = True
		Me.lvwDistList.LabelWrap = True
		Me.lvwDistList.HideSelection = True
		Me.lvwDistList.FullRowSelect = True
		Me.lvwDistList.GridLines = True
		Me.lvwDistList.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lvwDistList.BackColor = System.Drawing.SystemColors.Window
		Me.lvwDistList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lvwDistList.Name = "lvwDistList"
		Me._lvwDistList_ColumnHeader_1.Text = "Nom de la liste"
		Me._lvwDistList_ColumnHeader_1.Width = 353
		Me._lvwDistList_ColumnHeader_2.Text = "Dossier Outlook"
		Me._lvwDistList_ColumnHeader_2.Width = 236
		Me._lvwDistList_ColumnHeader_3.Text = "Nombre de membres"
		Me._lvwDistList_ColumnHeader_3.Width = 294
		Me.Controls.Add(cmdCreerListe)
		Me.Controls.Add(Frame2)
		Me.Controls.Add(Frame1)
		Me.Frame2.Controls.Add(lvwContacts)
		Me.lvwContacts.Columns.Add(_lvwContacts_ColumnHeader_1)
		Me.lvwContacts.Columns.Add(_lvwContacts_ColumnHeader_2)
		Me.lvwContacts.Columns.Add(_lvwContacts_ColumnHeader_3)
		Me.Frame1.Controls.Add(cmdAfficher)
		Me.Frame1.Controls.Add(cmdRafraichir)
		Me.Frame1.Controls.Add(lvwDistList)
		Me.lvwDistList.Columns.Add(_lvwDistList_ColumnHeader_1)
		Me.lvwDistList.Columns.Add(_lvwDistList_ColumnHeader_2)
		Me.lvwDistList.Columns.Add(_lvwDistList_ColumnHeader_3)
		Me.Frame2.ResumeLayout(False)
		Me.lvwContacts.ResumeLayout(False)
		Me.Frame1.ResumeLayout(False)
		Me.lvwDistList.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class