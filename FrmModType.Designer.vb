<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FrmModType
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
	Public WithEvents txtAdd As System.Windows.Forms.TextBox
	Public WithEvents Combo1 As System.Windows.Forms.ComboBox
	Public WithEvents FrmADD As System.Windows.Forms.GroupBox
	Public WithEvents OptElec As System.Windows.Forms.RadioButton
	Public WithEvents OptMec As System.Windows.Forms.RadioButton
	Public WithEvents Opttous As System.Windows.Forms.RadioButton
	Public WithEvents Afficher As System.Windows.Forms.GroupBox
	Public WithEvents Cmdfermer As System.Windows.Forms.Button
	Public WithEvents CmdValider As System.Windows.Forms.Button
	Public WithEvents cmdsupprimer As System.Windows.Forms.Button
	Public WithEvents CmdCancel As System.Windows.Forms.Button
	Public WithEvents Cmdajouter As System.Windows.Forms.Button
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents _lsttype_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _lsttype_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents lsttype As System.Windows.Forms.ListView
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmModType))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.FrmADD = New System.Windows.Forms.GroupBox
		Me.txtAdd = New System.Windows.Forms.TextBox
		Me.Combo1 = New System.Windows.Forms.ComboBox
		Me.Afficher = New System.Windows.Forms.GroupBox
		Me.OptElec = New System.Windows.Forms.RadioButton
		Me.OptMec = New System.Windows.Forms.RadioButton
		Me.Opttous = New System.Windows.Forms.RadioButton
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.Cmdfermer = New System.Windows.Forms.Button
		Me.CmdValider = New System.Windows.Forms.Button
		Me.cmdsupprimer = New System.Windows.Forms.Button
		Me.CmdCancel = New System.Windows.Forms.Button
		Me.Cmdajouter = New System.Windows.Forms.Button
		Me.lsttype = New System.Windows.Forms.ListView
		Me._lsttype_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._lsttype_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me.FrmADD.SuspendLayout()
		Me.Afficher.SuspendLayout()
		Me.Frame1.SuspendLayout()
		Me.lsttype.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Modifier les Types "
		Me.ClientSize = New System.Drawing.Size(368, 287)
		Me.Location = New System.Drawing.Point(576, 449)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "FrmModType"
		Me.FrmADD.Text = "Ajouter"
		Me.FrmADD.Size = New System.Drawing.Size(241, 49)
		Me.FrmADD.Location = New System.Drawing.Point(16, 16)
		Me.FrmADD.TabIndex = 9
		Me.FrmADD.Visible = False
		Me.FrmADD.BackColor = System.Drawing.SystemColors.Control
		Me.FrmADD.Enabled = True
		Me.FrmADD.ForeColor = System.Drawing.SystemColors.ControlText
		Me.FrmADD.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.FrmADD.Padding = New System.Windows.Forms.Padding(0)
		Me.FrmADD.Name = "FrmADD"
		Me.txtAdd.AutoSize = False
		Me.txtAdd.Size = New System.Drawing.Size(161, 19)
		Me.txtAdd.Location = New System.Drawing.Point(64, 16)
		Me.txtAdd.TabIndex = 11
		Me.txtAdd.Text = "Entré le Nom Ici"
		Me.txtAdd.AcceptsReturn = True
		Me.txtAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtAdd.BackColor = System.Drawing.SystemColors.Window
		Me.txtAdd.CausesValidation = True
		Me.txtAdd.Enabled = True
		Me.txtAdd.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAdd.HideSelection = True
		Me.txtAdd.ReadOnly = False
		Me.txtAdd.Maxlength = 0
		Me.txtAdd.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAdd.MultiLine = False
		Me.txtAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAdd.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtAdd.TabStop = True
		Me.txtAdd.Visible = True
		Me.txtAdd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAdd.Name = "txtAdd"
		Me.Combo1.Size = New System.Drawing.Size(41, 21)
		Me.Combo1.Location = New System.Drawing.Point(16, 16)
		Me.Combo1.Items.AddRange(New Object(){"E", "M"})
		Me.Combo1.TabIndex = 10
		Me.Combo1.Text = "E"
		Me.Combo1.BackColor = System.Drawing.SystemColors.Window
		Me.Combo1.CausesValidation = True
		Me.Combo1.Enabled = True
		Me.Combo1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Combo1.IntegralHeight = True
		Me.Combo1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Combo1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Combo1.Sorted = False
		Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.Combo1.TabStop = True
		Me.Combo1.Visible = True
		Me.Combo1.Name = "Combo1"
		Me.Afficher.BackColor = System.Drawing.Color.Black
		Me.Afficher.Text = "Afficher"
		Me.Afficher.ForeColor = System.Drawing.SystemColors.Control
		Me.Afficher.Size = New System.Drawing.Size(97, 129)
		Me.Afficher.Location = New System.Drawing.Point(256, 144)
		Me.Afficher.TabIndex = 0
		Me.Afficher.Enabled = True
		Me.Afficher.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Afficher.Visible = True
		Me.Afficher.Padding = New System.Windows.Forms.Padding(0)
		Me.Afficher.Name = "Afficher"
		Me.OptElec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptElec.BackColor = System.Drawing.Color.Black
		Me.OptElec.Text = "Électrique"
		Me.OptElec.ForeColor = System.Drawing.SystemColors.Control
		Me.OptElec.Size = New System.Drawing.Size(81, 33)
		Me.OptElec.Location = New System.Drawing.Point(8, 88)
		Me.OptElec.TabIndex = 3
		Me.OptElec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptElec.CausesValidation = True
		Me.OptElec.Enabled = True
		Me.OptElec.Cursor = System.Windows.Forms.Cursors.Default
		Me.OptElec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OptElec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.OptElec.TabStop = True
		Me.OptElec.Checked = False
		Me.OptElec.Visible = True
		Me.OptElec.Name = "OptElec"
		Me.OptMec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptMec.BackColor = System.Drawing.Color.Black
		Me.OptMec.Text = "Mecanique"
		Me.OptMec.ForeColor = System.Drawing.SystemColors.Control
		Me.OptMec.Size = New System.Drawing.Size(81, 33)
		Me.OptMec.Location = New System.Drawing.Point(8, 56)
		Me.OptMec.TabIndex = 2
		Me.OptMec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptMec.CausesValidation = True
		Me.OptMec.Enabled = True
		Me.OptMec.Cursor = System.Windows.Forms.Cursors.Default
		Me.OptMec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OptMec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.OptMec.TabStop = True
		Me.OptMec.Checked = False
		Me.OptMec.Visible = True
		Me.OptMec.Name = "OptMec"
		Me.Opttous.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.Opttous.BackColor = System.Drawing.Color.Black
		Me.Opttous.Text = "Tous"
		Me.Opttous.ForeColor = System.Drawing.SystemColors.Control
		Me.Opttous.Size = New System.Drawing.Size(81, 33)
		Me.Opttous.Location = New System.Drawing.Point(8, 24)
		Me.Opttous.TabIndex = 1
		Me.Opttous.Checked = True
		Me.Opttous.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.Opttous.CausesValidation = True
		Me.Opttous.Enabled = True
		Me.Opttous.Cursor = System.Windows.Forms.Cursors.Default
		Me.Opttous.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Opttous.Appearance = System.Windows.Forms.Appearance.Normal
		Me.Opttous.TabStop = True
		Me.Opttous.Visible = True
		Me.Opttous.Name = "Opttous"
		Me.Frame1.BackColor = System.Drawing.Color.Black
		Me.Frame1.ForeColor = System.Drawing.SystemColors.Control
		Me.Frame1.Size = New System.Drawing.Size(97, 141)
		Me.Frame1.Location = New System.Drawing.Point(256, 8)
		Me.Frame1.TabIndex = 5
		Me.Frame1.Enabled = True
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame1.Name = "Frame1"
		Me.Cmdfermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Cmdfermer.Text = "Fermer"
		Me.Cmdfermer.Size = New System.Drawing.Size(81, 33)
		Me.Cmdfermer.Location = New System.Drawing.Point(8, 96)
		Me.Cmdfermer.TabIndex = 8
		Me.Cmdfermer.BackColor = System.Drawing.SystemColors.Control
		Me.Cmdfermer.CausesValidation = True
		Me.Cmdfermer.Enabled = True
		Me.Cmdfermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Cmdfermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.Cmdfermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Cmdfermer.TabStop = True
		Me.Cmdfermer.Name = "Cmdfermer"
		Me.CmdValider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdValider.Text = "Valider"
		Me.CmdValider.Size = New System.Drawing.Size(81, 33)
		Me.CmdValider.Location = New System.Drawing.Point(8, 16)
		Me.CmdValider.TabIndex = 12
		Me.CmdValider.Visible = False
		Me.CmdValider.BackColor = System.Drawing.SystemColors.Control
		Me.CmdValider.CausesValidation = True
		Me.CmdValider.Enabled = True
		Me.CmdValider.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdValider.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdValider.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdValider.TabStop = True
		Me.CmdValider.Name = "CmdValider"
		Me.cmdsupprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdsupprimer.Text = "Supprimer"
		Me.cmdsupprimer.Enabled = False
		Me.cmdsupprimer.Size = New System.Drawing.Size(81, 33)
		Me.cmdsupprimer.Location = New System.Drawing.Point(8, 56)
		Me.cmdsupprimer.TabIndex = 7
		Me.cmdsupprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdsupprimer.CausesValidation = True
		Me.cmdsupprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdsupprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdsupprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdsupprimer.TabStop = True
		Me.cmdsupprimer.Name = "cmdsupprimer"
		Me.CmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdCancel.Text = "Annuler"
		Me.CmdCancel.Size = New System.Drawing.Size(81, 33)
		Me.CmdCancel.Location = New System.Drawing.Point(8, 56)
		Me.CmdCancel.TabIndex = 13
		Me.CmdCancel.Visible = False
		Me.CmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.CmdCancel.CausesValidation = True
		Me.CmdCancel.Enabled = True
		Me.CmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdCancel.TabStop = True
		Me.CmdCancel.Name = "CmdCancel"
		Me.Cmdajouter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Cmdajouter.Text = "Ajouter"
		Me.Cmdajouter.Size = New System.Drawing.Size(81, 33)
		Me.Cmdajouter.Location = New System.Drawing.Point(8, 16)
		Me.Cmdajouter.TabIndex = 6
		Me.Cmdajouter.BackColor = System.Drawing.SystemColors.Control
		Me.Cmdajouter.CausesValidation = True
		Me.Cmdajouter.Enabled = True
		Me.Cmdajouter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Cmdajouter.Cursor = System.Windows.Forms.Cursors.Default
		Me.Cmdajouter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Cmdajouter.TabStop = True
		Me.Cmdajouter.Name = "Cmdajouter"
		Me.lsttype.Size = New System.Drawing.Size(240, 257)
		Me.lsttype.Location = New System.Drawing.Point(16, 16)
		Me.lsttype.TabIndex = 4
		Me.lsttype.View = System.Windows.Forms.View.Details
		Me.lsttype.LabelEdit = False
		Me.lsttype.LabelWrap = True
		Me.lsttype.HideSelection = False
		Me.lsttype.FullRowSelect = True
		Me.lsttype.GridLines = True
		Me.lsttype.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lsttype.BackColor = System.Drawing.SystemColors.Window
		Me.lsttype.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lsttype.Name = "lsttype"
		Me._lsttype_ColumnHeader_1.Text = "E/M"
		Me._lsttype_ColumnHeader_1.Width = 95
		Me._lsttype_ColumnHeader_2.Text = "Type"
		Me._lsttype_ColumnHeader_2.Width = 330
		Me.Controls.Add(FrmADD)
		Me.Controls.Add(Afficher)
		Me.Controls.Add(Frame1)
		Me.Controls.Add(lsttype)
		Me.FrmADD.Controls.Add(txtAdd)
		Me.FrmADD.Controls.Add(Combo1)
		Me.Afficher.Controls.Add(OptElec)
		Me.Afficher.Controls.Add(OptMec)
		Me.Afficher.Controls.Add(Opttous)
		Me.Frame1.Controls.Add(Cmdfermer)
		Me.Frame1.Controls.Add(CmdValider)
		Me.Frame1.Controls.Add(cmdsupprimer)
		Me.Frame1.Controls.Add(CmdCancel)
		Me.Frame1.Controls.Add(Cmdajouter)
		Me.lsttype.Columns.Add(_lsttype_ColumnHeader_1)
		Me.lsttype.Columns.Add(_lsttype_ColumnHeader_2)
		Me.FrmADD.ResumeLayout(False)
		Me.Afficher.ResumeLayout(False)
		Me.Frame1.ResumeLayout(False)
		Me.lsttype.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class