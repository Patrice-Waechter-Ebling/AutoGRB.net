<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FrmaddItemElec
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
	Public WithEvents cmbCategorie As System.Windows.Forms.ComboBox
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents txtNoItem As System.Windows.Forms.TextBox
	Public WithEvents cmbFabricant As System.Windows.Forms.ComboBox
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmaddItemElec))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmbCategorie = New System.Windows.Forms.ComboBox
		Me.cmdOk = New System.Windows.Forms.Button
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.txtNoItem = New System.Windows.Forms.TextBox
		Me.cmbFabricant = New System.Windows.Forms.ComboBox
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Ajout d'items"
		Me.ClientSize = New System.Drawing.Size(393, 230)
		Me.Location = New System.Drawing.Point(238, 216)
		Me.ControlBox = False
		Me.Icon = CType(resources.GetObject("FrmaddItemElec.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("FrmaddItemElec.BackgroundImage"), System.Drawing.Image)
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "FrmaddItemElec"
		Me.cmbCategorie.BackColor = System.Drawing.Color.White
		Me.cmbCategorie.Size = New System.Drawing.Size(161, 21)
		Me.cmbCategorie.Location = New System.Drawing.Point(104, 128)
		Me.cmbCategorie.Sorted = True
		Me.cmbCategorie.TabIndex = 0
		Me.cmbCategorie.CausesValidation = True
		Me.cmbCategorie.Enabled = True
		Me.cmbCategorie.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbCategorie.IntegralHeight = True
		Me.cmbCategorie.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbCategorie.TabStop = True
		Me.cmbCategorie.Visible = True
		Me.cmbCategorie.Name = "cmbCategorie"
		Me.cmdOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOk.Text = "OK"
		Me.AcceptButton = Me.cmdOk
		Me.cmdOk.Size = New System.Drawing.Size(81, 25)
		Me.cmdOk.Location = New System.Drawing.Point(288, 160)
		Me.cmdOk.TabIndex = 3
		Me.cmdOk.CausesValidation = True
		Me.cmdOk.Enabled = True
		Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOk.TabStop = True
		Me.cmdOk.Name = "cmdOk"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(81, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(288, 192)
		Me.cmdAnnuler.TabIndex = 4
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.txtNoItem.AutoSize = False
		Me.txtNoItem.BackColor = System.Drawing.Color.White
		Me.txtNoItem.Size = New System.Drawing.Size(161, 20)
		Me.txtNoItem.Location = New System.Drawing.Point(104, 160)
		Me.txtNoItem.Maxlength = 37
		Me.txtNoItem.TabIndex = 1
		Me.txtNoItem.AcceptsReturn = True
		Me.txtNoItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNoItem.CausesValidation = True
		Me.txtNoItem.Enabled = True
		Me.txtNoItem.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNoItem.HideSelection = True
		Me.txtNoItem.ReadOnly = False
		Me.txtNoItem.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNoItem.MultiLine = False
		Me.txtNoItem.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNoItem.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNoItem.TabStop = True
		Me.txtNoItem.Visible = True
		Me.txtNoItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNoItem.Name = "txtNoItem"
		Me.cmbFabricant.BackColor = System.Drawing.Color.White
		Me.cmbFabricant.Size = New System.Drawing.Size(161, 21)
		Me.cmbFabricant.Location = New System.Drawing.Point(104, 192)
		Me.cmbFabricant.Sorted = True
		Me.cmbFabricant.TabIndex = 2
		Me.cmbFabricant.CausesValidation = True
		Me.cmbFabricant.Enabled = True
		Me.cmbFabricant.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbFabricant.IntegralHeight = True
		Me.cmbFabricant.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbFabricant.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbFabricant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbFabricant.TabStop = True
		Me.cmbFabricant.Visible = True
		Me.cmbFabricant.Name = "cmbFabricant"
		Me.Label4.Text = "Catégorie"
		Me.Label4.ForeColor = System.Drawing.Color.White
		Me.Label4.Size = New System.Drawing.Size(81, 25)
		Me.Label4.Location = New System.Drawing.Point(8, 128)
		Me.Label4.TabIndex = 6
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.Color.Transparent
		Me.Label4.Enabled = True
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label2.Text = "Numero d'item:"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(97, 25)
		Me.Label2.Location = New System.Drawing.Point(8, 160)
		Me.Label2.TabIndex = 7
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label3.Text = "Manufacturier"
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Size = New System.Drawing.Size(81, 25)
		Me.Label3.Location = New System.Drawing.Point(8, 192)
		Me.Label3.TabIndex = 8
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Enabled = True
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label1.Text = "Veuillez entrez un numero d'item et ensuite choisir un manufacturier parmis ceux dans la liste déroulante (vous pouvez en ajouter un qui ne figure pas déjà dans la liste)"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(361, 49)
		Me.Label1.Location = New System.Drawing.Point(8, 64)
		Me.Label1.TabIndex = 5
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(cmbCategorie)
		Me.Controls.Add(cmdOk)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(txtNoItem)
		Me.Controls.Add(cmbFabricant)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class