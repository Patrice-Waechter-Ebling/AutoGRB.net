<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmExportToOutLook
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
	Public WithEvents lblnbre As System.Windows.Forms.Label
	Public WithEvents lblEtatOutlook As System.Windows.Forms.Label
	Public WithEvents fraEtatOutlook As System.Windows.Forms.GroupBox
	Public WithEvents ckFRS As System.Windows.Forms.CheckBox
	Public WithEvents ckClient As System.Windows.Forms.CheckBox
	Public WithEvents ckContact As System.Windows.Forms.CheckBox
	Public WithEvents CancelButton_Renamed As System.Windows.Forms.Button
	Public WithEvents OKButton As System.Windows.Forms.Button
	Public WithEvents Shape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmExportToOutLook))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
		Me.fraEtatOutlook = New System.Windows.Forms.GroupBox
		Me.lblnbre = New System.Windows.Forms.Label
		Me.lblEtatOutlook = New System.Windows.Forms.Label
		Me.ckFRS = New System.Windows.Forms.CheckBox
		Me.ckClient = New System.Windows.Forms.CheckBox
		Me.ckContact = New System.Windows.Forms.CheckBox
		Me.CancelButton_Renamed = New System.Windows.Forms.Button
		Me.OKButton = New System.Windows.Forms.Button
		Me.Shape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.fraEtatOutlook.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Export to Outlook"
		Me.ClientSize = New System.Drawing.Size(402, 213)
		Me.Location = New System.Drawing.Point(184, 250)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmExportToOutLook"
		Me.fraEtatOutlook.Text = "Tranfère en cours"
		Me.fraEtatOutlook.Size = New System.Drawing.Size(377, 153)
		Me.fraEtatOutlook.Location = New System.Drawing.Point(8, 8)
		Me.fraEtatOutlook.TabIndex = 9
		Me.fraEtatOutlook.Visible = False
		Me.fraEtatOutlook.BackColor = System.Drawing.SystemColors.Control
		Me.fraEtatOutlook.Enabled = True
		Me.fraEtatOutlook.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraEtatOutlook.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraEtatOutlook.Padding = New System.Windows.Forms.Padding(0)
		Me.fraEtatOutlook.Name = "fraEtatOutlook"
		Me.lblnbre.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblnbre.Text = "Label5"
		Me.lblnbre.Size = New System.Drawing.Size(345, 25)
		Me.lblnbre.Location = New System.Drawing.Point(16, 112)
		Me.lblnbre.TabIndex = 11
		Me.lblnbre.BackColor = System.Drawing.SystemColors.Control
		Me.lblnbre.Enabled = True
		Me.lblnbre.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblnbre.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblnbre.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblnbre.UseMnemonic = True
		Me.lblnbre.Visible = True
		Me.lblnbre.AutoSize = False
		Me.lblnbre.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblnbre.Name = "lblnbre"
		Me.lblEtatOutlook.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblEtatOutlook.Text = "export data"
		Me.lblEtatOutlook.ForeColor = System.Drawing.Color.Red
		Me.lblEtatOutlook.Size = New System.Drawing.Size(345, 57)
		Me.lblEtatOutlook.Location = New System.Drawing.Point(16, 40)
		Me.lblEtatOutlook.TabIndex = 10
		Me.lblEtatOutlook.BackColor = System.Drawing.SystemColors.Control
		Me.lblEtatOutlook.Enabled = True
		Me.lblEtatOutlook.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblEtatOutlook.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblEtatOutlook.UseMnemonic = True
		Me.lblEtatOutlook.Visible = True
		Me.lblEtatOutlook.AutoSize = False
		Me.lblEtatOutlook.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblEtatOutlook.Name = "lblEtatOutlook"
		Me.ckFRS.Text = "Check1"
		Me.ckFRS.Size = New System.Drawing.Size(17, 17)
		Me.ckFRS.Location = New System.Drawing.Point(16, 120)
		Me.ckFRS.TabIndex = 4
		Me.ckFRS.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ckFRS.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.ckFRS.BackColor = System.Drawing.SystemColors.Control
		Me.ckFRS.CausesValidation = True
		Me.ckFRS.Enabled = True
		Me.ckFRS.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ckFRS.Cursor = System.Windows.Forms.Cursors.Default
		Me.ckFRS.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ckFRS.Appearance = System.Windows.Forms.Appearance.Normal
		Me.ckFRS.TabStop = True
		Me.ckFRS.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.ckFRS.Visible = True
		Me.ckFRS.Name = "ckFRS"
		Me.ckClient.Text = "Check1"
		Me.ckClient.Size = New System.Drawing.Size(17, 17)
		Me.ckClient.Location = New System.Drawing.Point(16, 88)
		Me.ckClient.TabIndex = 3
		Me.ckClient.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ckClient.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.ckClient.BackColor = System.Drawing.SystemColors.Control
		Me.ckClient.CausesValidation = True
		Me.ckClient.Enabled = True
		Me.ckClient.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ckClient.Cursor = System.Windows.Forms.Cursors.Default
		Me.ckClient.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ckClient.Appearance = System.Windows.Forms.Appearance.Normal
		Me.ckClient.TabStop = True
		Me.ckClient.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.ckClient.Visible = True
		Me.ckClient.Name = "ckClient"
		Me.ckContact.Text = "Check1"
		Me.ckContact.Size = New System.Drawing.Size(17, 17)
		Me.ckContact.Location = New System.Drawing.Point(16, 56)
		Me.ckContact.TabIndex = 2
		Me.ckContact.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ckContact.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.ckContact.BackColor = System.Drawing.SystemColors.Control
		Me.ckContact.CausesValidation = True
		Me.ckContact.Enabled = True
		Me.ckContact.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ckContact.Cursor = System.Windows.Forms.Cursors.Default
		Me.ckContact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ckContact.Appearance = System.Windows.Forms.Appearance.Normal
		Me.ckContact.TabStop = True
		Me.ckContact.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.ckContact.Visible = True
		Me.ckContact.Name = "ckContact"
		Me.CancelButton_Renamed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CancelButton_Renamed.Text = "&Fermer"
		Me.CancelButton_Renamed.Size = New System.Drawing.Size(81, 25)
		Me.CancelButton_Renamed.Location = New System.Drawing.Point(304, 176)
		Me.CancelButton_Renamed.TabIndex = 1
		Me.CancelButton_Renamed.BackColor = System.Drawing.SystemColors.Control
		Me.CancelButton_Renamed.CausesValidation = True
		Me.CancelButton_Renamed.Enabled = True
		Me.CancelButton_Renamed.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CancelButton_Renamed.Cursor = System.Windows.Forms.Cursors.Default
		Me.CancelButton_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CancelButton_Renamed.TabStop = True
		Me.CancelButton_Renamed.Name = "CancelButton_Renamed"
		Me.OKButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.OKButton.Text = "&Exécuter"
		Me.OKButton.Size = New System.Drawing.Size(81, 25)
		Me.OKButton.Location = New System.Drawing.Point(216, 176)
		Me.OKButton.TabIndex = 0
		Me.OKButton.BackColor = System.Drawing.SystemColors.Control
		Me.OKButton.CausesValidation = True
		Me.OKButton.Enabled = True
		Me.OKButton.ForeColor = System.Drawing.SystemColors.ControlText
		Me.OKButton.Cursor = System.Windows.Forms.Cursors.Default
		Me.OKButton.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OKButton.TabStop = True
		Me.OKButton.Name = "OKButton"
		Me.Shape1.Size = New System.Drawing.Size(377, 97)
		Me.Shape1.Location = New System.Drawing.Point(8, 48)
		Me.Shape1.BackColor = System.Drawing.SystemColors.Window
		Me.Shape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent
		Me.Shape1.BorderColor = System.Drawing.SystemColors.WindowText
		Me.Shape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
		Me.Shape1.BorderWidth = 1
		Me.Shape1.FillColor = System.Drawing.Color.Black
		Me.Shape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
		Me.Shape1.Visible = True
		Me.Shape1.Name = "Shape1"
		Me.Label3.Text = "Exporter les Fournisseurs"
		Me.Label3.Size = New System.Drawing.Size(337, 33)
		Me.Label3.Location = New System.Drawing.Point(48, 120)
		Me.Label3.TabIndex = 7
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "Exporter les Clients"
		Me.Label2.Size = New System.Drawing.Size(337, 25)
		Me.Label2.Location = New System.Drawing.Point(48, 88)
		Me.Label2.TabIndex = 6
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "Exporter les Contacts"
		Me.Label1.Size = New System.Drawing.Size(337, 25)
		Me.Label1.Location = New System.Drawing.Point(48, 56)
		Me.Label1.TabIndex = 5
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Label4.Text = "Choisir les listes à exporter."
		Me.Label4.Size = New System.Drawing.Size(353, 41)
		Me.Label4.Location = New System.Drawing.Point(16, 8)
		Me.Label4.TabIndex = 8
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.Color.Transparent
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Controls.Add(fraEtatOutlook)
		Me.Controls.Add(ckFRS)
		Me.Controls.Add(ckClient)
		Me.Controls.Add(ckContact)
		Me.Controls.Add(CancelButton_Renamed)
		Me.Controls.Add(OKButton)
		Me.ShapeContainer1.Shapes.Add(Shape1)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Controls.Add(Label4)
		Me.Controls.Add(ShapeContainer1)
		Me.fraEtatOutlook.Controls.Add(lblnbre)
		Me.fraEtatOutlook.Controls.Add(lblEtatOutlook)
		Me.fraEtatOutlook.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class