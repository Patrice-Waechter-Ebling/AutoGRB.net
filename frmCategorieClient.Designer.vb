<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCategorieClient
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
	Public WithEvents chkProduitsChimiques As System.Windows.Forms.CheckBox
	Public WithEvents chkICPI As System.Windows.Forms.CheckBox
	Public WithEvents chkAsphalte As System.Windows.Forms.CheckBox
	Public WithEvents chkConsultant As System.Windows.Forms.CheckBox
	Public WithEvents chkBeton As System.Windows.Forms.CheckBox
	Public WithEvents chkPave As System.Windows.Forms.CheckBox
	Public WithEvents chkPharmaceutique As System.Windows.Forms.CheckBox
	Public WithEvents chkMeuble As System.Windows.Forms.CheckBox
	Public WithEvents chkMeunerie As System.Windows.Forms.CheckBox
	Public WithEvents chkAgroalimentaire As System.Windows.Forms.CheckBox
	Public WithEvents chkManufacturier As System.Windows.Forms.CheckBox
	Public WithEvents chkAutre As System.Windows.Forms.CheckBox
	Public WithEvents fraCategories As System.Windows.Forms.Panel
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCategorieClient))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.fraCategories = New System.Windows.Forms.Panel
		Me.chkProduitsChimiques = New System.Windows.Forms.CheckBox
		Me.chkICPI = New System.Windows.Forms.CheckBox
		Me.chkAsphalte = New System.Windows.Forms.CheckBox
		Me.chkConsultant = New System.Windows.Forms.CheckBox
		Me.chkBeton = New System.Windows.Forms.CheckBox
		Me.chkPave = New System.Windows.Forms.CheckBox
		Me.chkPharmaceutique = New System.Windows.Forms.CheckBox
		Me.chkMeuble = New System.Windows.Forms.CheckBox
		Me.chkMeunerie = New System.Windows.Forms.CheckBox
		Me.chkAgroalimentaire = New System.Windows.Forms.CheckBox
		Me.chkManufacturier = New System.Windows.Forms.CheckBox
		Me.chkAutre = New System.Windows.Forms.CheckBox
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.fraCategories.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.Black
		Me.Text = "Catégories"
		Me.ClientSize = New System.Drawing.Size(453, 323)
		Me.Location = New System.Drawing.Point(4, 30)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmCategorieClient.BackgroundImage"), System.Drawing.Image)
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
		Me.Name = "frmCategorieClient"
		Me.fraCategories.BackColor = System.Drawing.Color.Black
		Me.fraCategories.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.fraCategories.Size = New System.Drawing.Size(433, 185)
		Me.fraCategories.Location = New System.Drawing.Point(8, 88)
		Me.fraCategories.TabIndex = 1
		Me.fraCategories.Enabled = True
		Me.fraCategories.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fraCategories.Cursor = System.Windows.Forms.Cursors.Default
		Me.fraCategories.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraCategories.Visible = True
		Me.fraCategories.Name = "fraCategories"
		Me.chkProduitsChimiques.BackColor = System.Drawing.Color.Black
		Me.chkProduitsChimiques.Text = "Produits chimiques"
		Me.chkProduitsChimiques.ForeColor = System.Drawing.Color.White
		Me.chkProduitsChimiques.Size = New System.Drawing.Size(193, 17)
		Me.chkProduitsChimiques.Location = New System.Drawing.Point(232, 128)
		Me.chkProduitsChimiques.TabIndex = 13
		Me.chkProduitsChimiques.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkProduitsChimiques.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkProduitsChimiques.CausesValidation = True
		Me.chkProduitsChimiques.Enabled = True
		Me.chkProduitsChimiques.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkProduitsChimiques.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkProduitsChimiques.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkProduitsChimiques.TabStop = True
		Me.chkProduitsChimiques.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkProduitsChimiques.Visible = True
		Me.chkProduitsChimiques.Name = "chkProduitsChimiques"
		Me.chkICPI.BackColor = System.Drawing.Color.Black
		Me.chkICPI.Text = "ICPI"
		Me.chkICPI.ForeColor = System.Drawing.Color.White
		Me.chkICPI.Size = New System.Drawing.Size(193, 17)
		Me.chkICPI.Location = New System.Drawing.Point(232, 104)
		Me.chkICPI.TabIndex = 12
		Me.chkICPI.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkICPI.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkICPI.CausesValidation = True
		Me.chkICPI.Enabled = True
		Me.chkICPI.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkICPI.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkICPI.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkICPI.TabStop = True
		Me.chkICPI.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkICPI.Visible = True
		Me.chkICPI.Name = "chkICPI"
		Me.chkAsphalte.BackColor = System.Drawing.Color.Black
		Me.chkAsphalte.Text = "Asphalte"
		Me.chkAsphalte.ForeColor = System.Drawing.Color.White
		Me.chkAsphalte.Size = New System.Drawing.Size(193, 17)
		Me.chkAsphalte.Location = New System.Drawing.Point(232, 80)
		Me.chkAsphalte.TabIndex = 11
		Me.chkAsphalte.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkAsphalte.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkAsphalte.CausesValidation = True
		Me.chkAsphalte.Enabled = True
		Me.chkAsphalte.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkAsphalte.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkAsphalte.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkAsphalte.TabStop = True
		Me.chkAsphalte.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkAsphalte.Visible = True
		Me.chkAsphalte.Name = "chkAsphalte"
		Me.chkConsultant.BackColor = System.Drawing.Color.Black
		Me.chkConsultant.Text = "Consultant"
		Me.chkConsultant.ForeColor = System.Drawing.Color.White
		Me.chkConsultant.Size = New System.Drawing.Size(193, 17)
		Me.chkConsultant.Location = New System.Drawing.Point(232, 56)
		Me.chkConsultant.TabIndex = 10
		Me.chkConsultant.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkConsultant.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkConsultant.CausesValidation = True
		Me.chkConsultant.Enabled = True
		Me.chkConsultant.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkConsultant.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkConsultant.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkConsultant.TabStop = True
		Me.chkConsultant.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkConsultant.Visible = True
		Me.chkConsultant.Name = "chkConsultant"
		Me.chkBeton.BackColor = System.Drawing.Color.Black
		Me.chkBeton.Text = "Béton"
		Me.chkBeton.ForeColor = System.Drawing.Color.White
		Me.chkBeton.Size = New System.Drawing.Size(193, 17)
		Me.chkBeton.Location = New System.Drawing.Point(32, 32)
		Me.chkBeton.TabIndex = 9
		Me.chkBeton.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkBeton.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkBeton.CausesValidation = True
		Me.chkBeton.Enabled = True
		Me.chkBeton.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkBeton.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkBeton.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkBeton.TabStop = True
		Me.chkBeton.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkBeton.Visible = True
		Me.chkBeton.Name = "chkBeton"
		Me.chkPave.BackColor = System.Drawing.Color.Black
		Me.chkPave.Text = "Pavé"
		Me.chkPave.ForeColor = System.Drawing.Color.White
		Me.chkPave.Size = New System.Drawing.Size(193, 17)
		Me.chkPave.Location = New System.Drawing.Point(32, 56)
		Me.chkPave.TabIndex = 8
		Me.chkPave.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkPave.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkPave.CausesValidation = True
		Me.chkPave.Enabled = True
		Me.chkPave.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkPave.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkPave.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkPave.TabStop = True
		Me.chkPave.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkPave.Visible = True
		Me.chkPave.Name = "chkPave"
		Me.chkPharmaceutique.BackColor = System.Drawing.Color.Black
		Me.chkPharmaceutique.Text = "Pharmaceutique"
		Me.chkPharmaceutique.ForeColor = System.Drawing.Color.White
		Me.chkPharmaceutique.Size = New System.Drawing.Size(193, 17)
		Me.chkPharmaceutique.Location = New System.Drawing.Point(32, 80)
		Me.chkPharmaceutique.TabIndex = 7
		Me.chkPharmaceutique.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkPharmaceutique.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkPharmaceutique.CausesValidation = True
		Me.chkPharmaceutique.Enabled = True
		Me.chkPharmaceutique.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkPharmaceutique.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkPharmaceutique.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkPharmaceutique.TabStop = True
		Me.chkPharmaceutique.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkPharmaceutique.Visible = True
		Me.chkPharmaceutique.Name = "chkPharmaceutique"
		Me.chkMeuble.BackColor = System.Drawing.Color.Black
		Me.chkMeuble.Text = "Meuble"
		Me.chkMeuble.ForeColor = System.Drawing.Color.White
		Me.chkMeuble.Size = New System.Drawing.Size(193, 17)
		Me.chkMeuble.Location = New System.Drawing.Point(32, 128)
		Me.chkMeuble.TabIndex = 6
		Me.chkMeuble.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkMeuble.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkMeuble.CausesValidation = True
		Me.chkMeuble.Enabled = True
		Me.chkMeuble.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkMeuble.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkMeuble.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkMeuble.TabStop = True
		Me.chkMeuble.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkMeuble.Visible = True
		Me.chkMeuble.Name = "chkMeuble"
		Me.chkMeunerie.BackColor = System.Drawing.Color.Black
		Me.chkMeunerie.Text = "Meunerie, grain, engrais"
		Me.chkMeunerie.ForeColor = System.Drawing.Color.White
		Me.chkMeunerie.Size = New System.Drawing.Size(193, 17)
		Me.chkMeunerie.Location = New System.Drawing.Point(32, 152)
		Me.chkMeunerie.TabIndex = 5
		Me.chkMeunerie.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkMeunerie.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkMeunerie.CausesValidation = True
		Me.chkMeunerie.Enabled = True
		Me.chkMeunerie.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkMeunerie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkMeunerie.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkMeunerie.TabStop = True
		Me.chkMeunerie.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkMeunerie.Visible = True
		Me.chkMeunerie.Name = "chkMeunerie"
		Me.chkAgroalimentaire.BackColor = System.Drawing.Color.Black
		Me.chkAgroalimentaire.Text = "Agroalimentaire"
		Me.chkAgroalimentaire.ForeColor = System.Drawing.Color.White
		Me.chkAgroalimentaire.Size = New System.Drawing.Size(193, 17)
		Me.chkAgroalimentaire.Location = New System.Drawing.Point(32, 104)
		Me.chkAgroalimentaire.TabIndex = 4
		Me.chkAgroalimentaire.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkAgroalimentaire.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkAgroalimentaire.CausesValidation = True
		Me.chkAgroalimentaire.Enabled = True
		Me.chkAgroalimentaire.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkAgroalimentaire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkAgroalimentaire.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkAgroalimentaire.TabStop = True
		Me.chkAgroalimentaire.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkAgroalimentaire.Visible = True
		Me.chkAgroalimentaire.Name = "chkAgroalimentaire"
		Me.chkManufacturier.BackColor = System.Drawing.Color.Black
		Me.chkManufacturier.Text = "Manufacturier"
		Me.chkManufacturier.ForeColor = System.Drawing.Color.White
		Me.chkManufacturier.Size = New System.Drawing.Size(193, 17)
		Me.chkManufacturier.Location = New System.Drawing.Point(232, 32)
		Me.chkManufacturier.TabIndex = 3
		Me.chkManufacturier.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkManufacturier.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkManufacturier.CausesValidation = True
		Me.chkManufacturier.Enabled = True
		Me.chkManufacturier.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkManufacturier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkManufacturier.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkManufacturier.TabStop = True
		Me.chkManufacturier.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkManufacturier.Visible = True
		Me.chkManufacturier.Name = "chkManufacturier"
		Me.chkAutre.BackColor = System.Drawing.Color.Black
		Me.chkAutre.Text = "Autre"
		Me.chkAutre.ForeColor = System.Drawing.Color.White
		Me.chkAutre.Size = New System.Drawing.Size(193, 17)
		Me.chkAutre.Location = New System.Drawing.Point(232, 152)
		Me.chkAutre.TabIndex = 2
		Me.chkAutre.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkAutre.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkAutre.CausesValidation = True
		Me.chkAutre.Enabled = True
		Me.chkAutre.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkAutre.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkAutre.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkAutre.TabStop = True
		Me.chkAutre.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkAutre.Visible = True
		Me.chkAutre.Name = "chkAutre"
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(89, 33)
		Me.cmdFermer.Location = New System.Drawing.Point(352, 280)
		Me.cmdFermer.TabIndex = 0
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.Controls.Add(fraCategories)
		Me.Controls.Add(cmdFermer)
		Me.fraCategories.Controls.Add(chkProduitsChimiques)
		Me.fraCategories.Controls.Add(chkICPI)
		Me.fraCategories.Controls.Add(chkAsphalte)
		Me.fraCategories.Controls.Add(chkConsultant)
		Me.fraCategories.Controls.Add(chkBeton)
		Me.fraCategories.Controls.Add(chkPave)
		Me.fraCategories.Controls.Add(chkPharmaceutique)
		Me.fraCategories.Controls.Add(chkMeuble)
		Me.fraCategories.Controls.Add(chkMeunerie)
		Me.fraCategories.Controls.Add(chkAgroalimentaire)
		Me.fraCategories.Controls.Add(chkManufacturier)
		Me.fraCategories.Controls.Add(chkAutre)
		Me.fraCategories.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class