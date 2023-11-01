<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmChoixClient
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
	Public WithEvents txtDescription As System.Windows.Forms.TextBox
	Public WithEvents cmdRafraichir As System.Windows.Forms.Button
	Public WithEvents cmdRecherche As System.Windows.Forms.Button
	Public WithEvents txtRecherche As System.Windows.Forms.TextBox
	Public WithEvents fraRecherche As System.Windows.Forms.GroupBox
	Public WithEvents cmbClient As System.Windows.Forms.ComboBox
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChoixClient))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.txtDescription = New System.Windows.Forms.TextBox
		Me.fraRecherche = New System.Windows.Forms.GroupBox
		Me.cmdRafraichir = New System.Windows.Forms.Button
		Me.cmdRecherche = New System.Windows.Forms.Button
		Me.txtRecherche = New System.Windows.Forms.TextBox
		Me.cmbClient = New System.Windows.Forms.ComboBox
		Me.cmdOK = New System.Windows.Forms.Button
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.fraRecherche.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.Text = "Choix du client"
		Me.ClientSize = New System.Drawing.Size(240, 338)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmChoixClient.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmChoixClient"
		Me.txtDescription.AutoSize = False
		Me.txtDescription.Size = New System.Drawing.Size(225, 43)
		Me.txtDescription.Location = New System.Drawing.Point(8, 248)
		Me.txtDescription.MultiLine = True
		Me.txtDescription.TabIndex = 8
		Me.txtDescription.AcceptsReturn = True
		Me.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDescription.BackColor = System.Drawing.SystemColors.Window
		Me.txtDescription.CausesValidation = True
		Me.txtDescription.Enabled = True
		Me.txtDescription.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDescription.HideSelection = True
		Me.txtDescription.ReadOnly = False
		Me.txtDescription.Maxlength = 0
		Me.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDescription.TabStop = True
		Me.txtDescription.Visible = True
		Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDescription.Name = "txtDescription"
		Me.fraRecherche.BackColor = System.Drawing.Color.Black
		Me.fraRecherche.Text = "Recherche"
		Me.fraRecherche.ForeColor = System.Drawing.Color.White
		Me.fraRecherche.Size = New System.Drawing.Size(169, 81)
		Me.fraRecherche.Location = New System.Drawing.Point(32, 80)
		Me.fraRecherche.TabIndex = 1
		Me.fraRecherche.Enabled = True
		Me.fraRecherche.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraRecherche.Visible = True
		Me.fraRecherche.Padding = New System.Windows.Forms.Padding(0)
		Me.fraRecherche.Name = "fraRecherche"
		Me.cmdRafraichir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRafraichir.Text = "Rafraichir"
		Me.cmdRafraichir.Size = New System.Drawing.Size(57, 25)
		Me.cmdRafraichir.Location = New System.Drawing.Point(48, 48)
		Me.cmdRafraichir.TabIndex = 3
		Me.cmdRafraichir.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRafraichir.CausesValidation = True
		Me.cmdRafraichir.Enabled = True
		Me.cmdRafraichir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRafraichir.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRafraichir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRafraichir.TabStop = True
		Me.cmdRafraichir.Name = "cmdRafraichir"
		Me.cmdRecherche.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRecherche.Text = "OK"
		Me.cmdRecherche.Size = New System.Drawing.Size(49, 25)
		Me.cmdRecherche.Location = New System.Drawing.Point(112, 48)
		Me.cmdRecherche.TabIndex = 4
		Me.cmdRecherche.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRecherche.CausesValidation = True
		Me.cmdRecherche.Enabled = True
		Me.cmdRecherche.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRecherche.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRecherche.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRecherche.TabStop = True
		Me.cmdRecherche.Name = "cmdRecherche"
		Me.txtRecherche.AutoSize = False
		Me.txtRecherche.Size = New System.Drawing.Size(153, 19)
		Me.txtRecherche.Location = New System.Drawing.Point(8, 24)
		Me.txtRecherche.TabIndex = 2
		Me.txtRecherche.AcceptsReturn = True
		Me.txtRecherche.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtRecherche.BackColor = System.Drawing.SystemColors.Window
		Me.txtRecherche.CausesValidation = True
		Me.txtRecherche.Enabled = True
		Me.txtRecherche.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtRecherche.HideSelection = True
		Me.txtRecherche.ReadOnly = False
		Me.txtRecherche.Maxlength = 0
		Me.txtRecherche.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtRecherche.MultiLine = False
		Me.txtRecherche.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtRecherche.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtRecherche.TabStop = True
		Me.txtRecherche.Visible = True
		Me.txtRecherche.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtRecherche.Name = "txtRecherche"
		Me.cmbClient.Size = New System.Drawing.Size(225, 21)
		Me.cmbClient.Location = New System.Drawing.Point(8, 184)
		Me.cmbClient.Sorted = True
		Me.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbClient.TabIndex = 5
		Me.cmbClient.BackColor = System.Drawing.SystemColors.Window
		Me.cmbClient.CausesValidation = True
		Me.cmbClient.Enabled = True
		Me.cmbClient.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbClient.IntegralHeight = True
		Me.cmbClient.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbClient.TabStop = True
		Me.cmbClient.Visible = True
		Me.cmbClient.Name = "cmbClient"
		Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOK.Text = "OK"
		Me.cmdOK.Size = New System.Drawing.Size(65, 25)
		Me.cmdOK.Location = New System.Drawing.Point(168, 304)
		Me.cmdOK.TabIndex = 6
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me.Label2.Text = "Description :"
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Size = New System.Drawing.Size(89, 17)
		Me.Label2.Location = New System.Drawing.Point(8, 224)
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
		Me.Label1.Text = "Pour quel client ?"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(89, 17)
		Me.Label1.Location = New System.Drawing.Point(8, 56)
		Me.Label1.TabIndex = 0
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
		Me.Controls.Add(txtDescription)
		Me.Controls.Add(fraRecherche)
		Me.Controls.Add(cmbClient)
		Me.Controls.Add(cmdOK)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.fraRecherche.Controls.Add(cmdRafraichir)
		Me.fraRecherche.Controls.Add(cmdRecherche)
		Me.fraRecherche.Controls.Add(txtRecherche)
		Me.fraRecherche.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class