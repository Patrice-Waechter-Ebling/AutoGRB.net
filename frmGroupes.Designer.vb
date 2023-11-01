<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGroupes
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
	Public WithEvents lstUser As System.Windows.Forms.ListBox
	Public WithEvents cmdFermer As System.Windows.Forms.Button
	Public WithEvents cmdSupprimer As System.Windows.Forms.Button
	Public WithEvents cmdModifier As System.Windows.Forms.Button
	Public WithEvents cmdAjouter As System.Windows.Forms.Button
	Public WithEvents chkDeverrouillageTempsProjet As System.Windows.Forms.CheckBox
	Public WithEvents chkVerrouillageTempsProjet As System.Windows.Forms.CheckBox
	Public WithEvents chkPunchSemaineAnterieure As System.Windows.Forms.CheckBox
	Public WithEvents chkMailingList As System.Windows.Forms.CheckBox
	Public WithEvents chkRetourMarchandise As System.Windows.Forms.CheckBox
	Public WithEvents chkReception As System.Windows.Forms.CheckBox
	Public WithEvents chkSupprimerProjets As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationPunchEmployes As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationInventaireMec As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationInventaireElec As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationCatalogueElec As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationCatalogueMec As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationBonsCommandes As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationSoumissionElec As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationProjetElec As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationProjetMec As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationSoumissionMec As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationFacturation As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationOutils As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationFeuillesTemps As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationGroupes As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationEmployes As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationContacts As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationFRS As System.Windows.Forms.CheckBox
	Public WithEvents chkModificationClients As System.Windows.Forms.CheckBox
	Public WithEvents fraModification As System.Windows.Forms.GroupBox
	Public WithEvents cmbGroupe As System.Windows.Forms.ComboBox
	Public WithEvents chkAchat As System.Windows.Forms.CheckBox
	Public WithEvents chkInventaireMec As System.Windows.Forms.CheckBox
	Public WithEvents chkInventaireElec As System.Windows.Forms.CheckBox
	Public WithEvents chkCatalogueElec As System.Windows.Forms.CheckBox
	Public WithEvents chkSoumissionElec As System.Windows.Forms.CheckBox
	Public WithEvents chkProjetElec As System.Windows.Forms.CheckBox
	Public WithEvents chkProjetMec As System.Windows.Forms.CheckBox
	Public WithEvents chkSoumissionMec As System.Windows.Forms.CheckBox
	Public WithEvents chkOutils As System.Windows.Forms.CheckBox
	Public WithEvents chkPunch As System.Windows.Forms.CheckBox
	Public WithEvents chkConfiguration As System.Windows.Forms.CheckBox
	Public WithEvents chkCedule As System.Windows.Forms.CheckBox
	Public WithEvents chkEmployes As System.Windows.Forms.CheckBox
	Public WithEvents chkCatalogueMec As System.Windows.Forms.CheckBox
	Public WithEvents chkRapports As System.Windows.Forms.CheckBox
	Public WithEvents chkContactsVendeurs As System.Windows.Forms.CheckBox
	Public WithEvents chkContacts As System.Windows.Forms.CheckBox
	Public WithEvents chkFournisseurs As System.Windows.Forms.CheckBox
	Public WithEvents chkClients As System.Windows.Forms.CheckBox
	Public WithEvents fraAffichage As System.Windows.Forms.GroupBox
	Public WithEvents cmdEnregistrer As System.Windows.Forms.Button
	Public WithEvents cmdAnnuler As System.Windows.Forms.Button
	Public WithEvents txtGroupe As System.Windows.Forms.TextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblGroupes As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGroupes))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.lstUser = New System.Windows.Forms.ListBox
		Me.cmdFermer = New System.Windows.Forms.Button
		Me.cmdSupprimer = New System.Windows.Forms.Button
		Me.cmdModifier = New System.Windows.Forms.Button
		Me.cmdAjouter = New System.Windows.Forms.Button
		Me.fraModification = New System.Windows.Forms.GroupBox
		Me.chkDeverrouillageTempsProjet = New System.Windows.Forms.CheckBox
		Me.chkVerrouillageTempsProjet = New System.Windows.Forms.CheckBox
		Me.chkPunchSemaineAnterieure = New System.Windows.Forms.CheckBox
		Me.chkMailingList = New System.Windows.Forms.CheckBox
		Me.chkRetourMarchandise = New System.Windows.Forms.CheckBox
		Me.chkReception = New System.Windows.Forms.CheckBox
		Me.chkSupprimerProjets = New System.Windows.Forms.CheckBox
		Me.chkModificationPunchEmployes = New System.Windows.Forms.CheckBox
		Me.chkModificationInventaireMec = New System.Windows.Forms.CheckBox
		Me.chkModificationInventaireElec = New System.Windows.Forms.CheckBox
		Me.chkModificationCatalogueElec = New System.Windows.Forms.CheckBox
		Me.chkModificationCatalogueMec = New System.Windows.Forms.CheckBox
		Me.chkModificationBonsCommandes = New System.Windows.Forms.CheckBox
		Me.chkModificationSoumissionElec = New System.Windows.Forms.CheckBox
		Me.chkModificationProjetElec = New System.Windows.Forms.CheckBox
		Me.chkModificationProjetMec = New System.Windows.Forms.CheckBox
		Me.chkModificationSoumissionMec = New System.Windows.Forms.CheckBox
		Me.chkModificationFacturation = New System.Windows.Forms.CheckBox
		Me.chkModificationOutils = New System.Windows.Forms.CheckBox
		Me.chkModificationFeuillesTemps = New System.Windows.Forms.CheckBox
		Me.chkModificationGroupes = New System.Windows.Forms.CheckBox
		Me.chkModificationEmployes = New System.Windows.Forms.CheckBox
		Me.chkModificationContacts = New System.Windows.Forms.CheckBox
		Me.chkModificationFRS = New System.Windows.Forms.CheckBox
		Me.chkModificationClients = New System.Windows.Forms.CheckBox
		Me.cmbGroupe = New System.Windows.Forms.ComboBox
		Me.fraAffichage = New System.Windows.Forms.GroupBox
		Me.chkAchat = New System.Windows.Forms.CheckBox
		Me.chkInventaireMec = New System.Windows.Forms.CheckBox
		Me.chkInventaireElec = New System.Windows.Forms.CheckBox
		Me.chkCatalogueElec = New System.Windows.Forms.CheckBox
		Me.chkSoumissionElec = New System.Windows.Forms.CheckBox
		Me.chkProjetElec = New System.Windows.Forms.CheckBox
		Me.chkProjetMec = New System.Windows.Forms.CheckBox
		Me.chkSoumissionMec = New System.Windows.Forms.CheckBox
		Me.chkOutils = New System.Windows.Forms.CheckBox
		Me.chkPunch = New System.Windows.Forms.CheckBox
		Me.chkConfiguration = New System.Windows.Forms.CheckBox
		Me.chkCedule = New System.Windows.Forms.CheckBox
		Me.chkEmployes = New System.Windows.Forms.CheckBox
		Me.chkCatalogueMec = New System.Windows.Forms.CheckBox
		Me.chkRapports = New System.Windows.Forms.CheckBox
		Me.chkContactsVendeurs = New System.Windows.Forms.CheckBox
		Me.chkContacts = New System.Windows.Forms.CheckBox
		Me.chkFournisseurs = New System.Windows.Forms.CheckBox
		Me.chkClients = New System.Windows.Forms.CheckBox
		Me.cmdEnregistrer = New System.Windows.Forms.Button
		Me.cmdAnnuler = New System.Windows.Forms.Button
		Me.txtGroupe = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.lblGroupes = New System.Windows.Forms.Label
		Me.fraModification.SuspendLayout()
		Me.fraAffichage.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.SystemColors.MenuText
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Configuration des groupes de sécurité"
		Me.ClientSize = New System.Drawing.Size(748, 504)
		Me.Location = New System.Drawing.Point(327, 163)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("frmGroupes.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmGroupes"
		Me.lstUser.BackColor = System.Drawing.Color.White
		Me.lstUser.Size = New System.Drawing.Size(121, 85)
		Me.lstUser.Location = New System.Drawing.Point(616, 8)
		Me.lstUser.TabIndex = 4
		Me.lstUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstUser.CausesValidation = True
		Me.lstUser.Enabled = True
		Me.lstUser.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstUser.IntegralHeight = True
		Me.lstUser.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstUser.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstUser.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstUser.Sorted = False
		Me.lstUser.TabStop = True
		Me.lstUser.Visible = True
		Me.lstUser.MultiColumn = False
		Me.lstUser.Name = "lstUser"
		Me.cmdFermer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdFermer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFermer.Text = "Fermer"
		Me.cmdFermer.Size = New System.Drawing.Size(105, 25)
		Me.cmdFermer.Location = New System.Drawing.Point(632, 472)
		Me.cmdFermer.TabIndex = 53
		Me.cmdFermer.CausesValidation = True
		Me.cmdFermer.Enabled = True
		Me.cmdFermer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFermer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFermer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFermer.TabStop = True
		Me.cmdFermer.Name = "cmdFermer"
		Me.cmdSupprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSupprimer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSupprimer.Text = "Supprimer"
		Me.cmdSupprimer.Size = New System.Drawing.Size(105, 25)
		Me.cmdSupprimer.Location = New System.Drawing.Point(408, 472)
		Me.cmdSupprimer.TabIndex = 50
		Me.cmdSupprimer.CausesValidation = True
		Me.cmdSupprimer.Enabled = True
		Me.cmdSupprimer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSupprimer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSupprimer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSupprimer.TabStop = True
		Me.cmdSupprimer.Name = "cmdSupprimer"
		Me.cmdModifier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdModifier.BackColor = System.Drawing.SystemColors.Control
		Me.cmdModifier.Text = "Modifier"
		Me.cmdModifier.Size = New System.Drawing.Size(105, 25)
		Me.cmdModifier.Location = New System.Drawing.Point(520, 472)
		Me.cmdModifier.TabIndex = 52
		Me.cmdModifier.CausesValidation = True
		Me.cmdModifier.Enabled = True
		Me.cmdModifier.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdModifier.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdModifier.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdModifier.TabStop = True
		Me.cmdModifier.Name = "cmdModifier"
		Me.cmdAjouter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAjouter.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAjouter.Text = "Ajouter"
		Me.cmdAjouter.Size = New System.Drawing.Size(105, 25)
		Me.cmdAjouter.Location = New System.Drawing.Point(296, 472)
		Me.cmdAjouter.TabIndex = 49
		Me.cmdAjouter.CausesValidation = True
		Me.cmdAjouter.Enabled = True
		Me.cmdAjouter.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAjouter.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAjouter.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAjouter.TabStop = True
		Me.cmdAjouter.Name = "cmdAjouter"
		Me.fraModification.BackColor = System.Drawing.SystemColors.MenuText
		Me.fraModification.Text = "Modification"
		Me.fraModification.ForeColor = System.Drawing.Color.White
		Me.fraModification.Size = New System.Drawing.Size(393, 361)
		Me.fraModification.Location = New System.Drawing.Point(344, 96)
		Me.fraModification.TabIndex = 25
		Me.fraModification.Enabled = True
		Me.fraModification.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraModification.Visible = True
		Me.fraModification.Padding = New System.Windows.Forms.Padding(0)
		Me.fraModification.Name = "fraModification"
		Me.chkDeverrouillageTempsProjet.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkDeverrouillageTempsProjet.Text = "Déverrouillage du temps de projet"
		Me.chkDeverrouillageTempsProjet.ForeColor = System.Drawing.Color.White
		Me.chkDeverrouillageTempsProjet.Size = New System.Drawing.Size(185, 17)
		Me.chkDeverrouillageTempsProjet.Location = New System.Drawing.Point(184, 264)
		Me.chkDeverrouillageTempsProjet.TabIndex = 56
		Me.ToolTip1.SetToolTip(Me.chkDeverrouillageTempsProjet, "Permet de faire les retours de marchandise")
		Me.chkDeverrouillageTempsProjet.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkDeverrouillageTempsProjet.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkDeverrouillageTempsProjet.CausesValidation = True
		Me.chkDeverrouillageTempsProjet.Enabled = True
		Me.chkDeverrouillageTempsProjet.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkDeverrouillageTempsProjet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkDeverrouillageTempsProjet.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkDeverrouillageTempsProjet.TabStop = True
		Me.chkDeverrouillageTempsProjet.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkDeverrouillageTempsProjet.Visible = True
		Me.chkDeverrouillageTempsProjet.Name = "chkDeverrouillageTempsProjet"
		Me.chkVerrouillageTempsProjet.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkVerrouillageTempsProjet.Text = "Verrouillage du temps de projet"
		Me.chkVerrouillageTempsProjet.ForeColor = System.Drawing.Color.White
		Me.chkVerrouillageTempsProjet.Size = New System.Drawing.Size(169, 17)
		Me.chkVerrouillageTempsProjet.Location = New System.Drawing.Point(184, 240)
		Me.chkVerrouillageTempsProjet.TabIndex = 55
		Me.ToolTip1.SetToolTip(Me.chkVerrouillageTempsProjet, "Permet de faire les retours de marchandise")
		Me.chkVerrouillageTempsProjet.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkVerrouillageTempsProjet.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkVerrouillageTempsProjet.CausesValidation = True
		Me.chkVerrouillageTempsProjet.Enabled = True
		Me.chkVerrouillageTempsProjet.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkVerrouillageTempsProjet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkVerrouillageTempsProjet.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkVerrouillageTempsProjet.TabStop = True
		Me.chkVerrouillageTempsProjet.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkVerrouillageTempsProjet.Visible = True
		Me.chkVerrouillageTempsProjet.Name = "chkVerrouillageTempsProjet"
		Me.chkPunchSemaineAnterieure.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkPunchSemaineAnterieure.Text = "Punchs dans une semaine antérieure"
		Me.chkPunchSemaineAnterieure.ForeColor = System.Drawing.Color.White
		Me.chkPunchSemaineAnterieure.Size = New System.Drawing.Size(201, 17)
		Me.chkPunchSemaineAnterieure.Location = New System.Drawing.Point(184, 216)
		Me.chkPunchSemaineAnterieure.TabIndex = 54
		Me.ToolTip1.SetToolTip(Me.chkPunchSemaineAnterieure, "Permet de faire les retours de marchandise")
		Me.chkPunchSemaineAnterieure.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkPunchSemaineAnterieure.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkPunchSemaineAnterieure.CausesValidation = True
		Me.chkPunchSemaineAnterieure.Enabled = True
		Me.chkPunchSemaineAnterieure.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkPunchSemaineAnterieure.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkPunchSemaineAnterieure.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkPunchSemaineAnterieure.TabStop = True
		Me.chkPunchSemaineAnterieure.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkPunchSemaineAnterieure.Visible = True
		Me.chkPunchSemaineAnterieure.Name = "chkPunchSemaineAnterieure"
		Me.chkMailingList.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkMailingList.Text = "Liste de distribution Outlook"
		Me.chkMailingList.ForeColor = System.Drawing.Color.White
		Me.chkMailingList.Size = New System.Drawing.Size(153, 17)
		Me.chkMailingList.Location = New System.Drawing.Point(184, 192)
		Me.chkMailingList.TabIndex = 47
		Me.ToolTip1.SetToolTip(Me.chkMailingList, "Permet de faire les retours de marchandise")
		Me.chkMailingList.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkMailingList.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkMailingList.CausesValidation = True
		Me.chkMailingList.Enabled = True
		Me.chkMailingList.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkMailingList.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkMailingList.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkMailingList.TabStop = True
		Me.chkMailingList.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkMailingList.Visible = True
		Me.chkMailingList.Name = "chkMailingList"
		Me.chkRetourMarchandise.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkRetourMarchandise.Text = "Retour de marchandise"
		Me.chkRetourMarchandise.ForeColor = System.Drawing.Color.White
		Me.chkRetourMarchandise.Size = New System.Drawing.Size(145, 17)
		Me.chkRetourMarchandise.Location = New System.Drawing.Point(184, 168)
		Me.chkRetourMarchandise.TabIndex = 45
		Me.ToolTip1.SetToolTip(Me.chkRetourMarchandise, "Permet de faire les retours de marchandise")
		Me.chkRetourMarchandise.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkRetourMarchandise.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkRetourMarchandise.CausesValidation = True
		Me.chkRetourMarchandise.Enabled = True
		Me.chkRetourMarchandise.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkRetourMarchandise.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkRetourMarchandise.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkRetourMarchandise.TabStop = True
		Me.chkRetourMarchandise.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkRetourMarchandise.Visible = True
		Me.chkRetourMarchandise.Name = "chkRetourMarchandise"
		Me.chkReception.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkReception.Text = "Réception"
		Me.chkReception.ForeColor = System.Drawing.Color.White
		Me.chkReception.Size = New System.Drawing.Size(129, 17)
		Me.chkReception.Location = New System.Drawing.Point(184, 144)
		Me.chkReception.TabIndex = 43
		Me.ToolTip1.SetToolTip(Me.chkReception, "Permet de faire la réception de marchandise")
		Me.chkReception.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkReception.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkReception.CausesValidation = True
		Me.chkReception.Enabled = True
		Me.chkReception.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkReception.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkReception.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkReception.TabStop = True
		Me.chkReception.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkReception.Visible = True
		Me.chkReception.Name = "chkReception"
		Me.chkSupprimerProjets.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkSupprimerProjets.Text = "Suppression de projets"
		Me.chkSupprimerProjets.ForeColor = System.Drawing.Color.White
		Me.chkSupprimerProjets.Size = New System.Drawing.Size(129, 17)
		Me.chkSupprimerProjets.Location = New System.Drawing.Point(184, 120)
		Me.chkSupprimerProjets.TabIndex = 41
		Me.ToolTip1.SetToolTip(Me.chkSupprimerProjets, "Permet de supprimer les projets")
		Me.chkSupprimerProjets.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkSupprimerProjets.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkSupprimerProjets.CausesValidation = True
		Me.chkSupprimerProjets.Enabled = True
		Me.chkSupprimerProjets.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkSupprimerProjets.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkSupprimerProjets.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkSupprimerProjets.TabStop = True
		Me.chkSupprimerProjets.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkSupprimerProjets.Visible = True
		Me.chkSupprimerProjets.Name = "chkSupprimerProjets"
		Me.chkModificationPunchEmployes.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationPunchEmployes.Text = "Punch employés"
		Me.chkModificationPunchEmployes.ForeColor = System.Drawing.Color.White
		Me.chkModificationPunchEmployes.Size = New System.Drawing.Size(113, 17)
		Me.chkModificationPunchEmployes.Location = New System.Drawing.Point(8, 240)
		Me.chkModificationPunchEmployes.TabIndex = 44
		Me.ToolTip1.SetToolTip(Me.chkModificationPunchEmployes, "Permet de modifier la liste des employés pour qui on peut puncher")
		Me.chkModificationPunchEmployes.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationPunchEmployes.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationPunchEmployes.CausesValidation = True
		Me.chkModificationPunchEmployes.Enabled = True
		Me.chkModificationPunchEmployes.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationPunchEmployes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationPunchEmployes.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationPunchEmployes.TabStop = True
		Me.chkModificationPunchEmployes.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationPunchEmployes.Visible = True
		Me.chkModificationPunchEmployes.Name = "chkModificationPunchEmployes"
		Me.chkModificationInventaireMec.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationInventaireMec.Text = "Inventaire mécanique"
		Me.chkModificationInventaireMec.ForeColor = System.Drawing.Color.White
		Me.chkModificationInventaireMec.Size = New System.Drawing.Size(129, 17)
		Me.chkModificationInventaireMec.Location = New System.Drawing.Point(8, 264)
		Me.chkModificationInventaireMec.TabIndex = 46
		Me.ToolTip1.SetToolTip(Me.chkModificationInventaireMec, "Modification de l'inventaire mécanique")
		Me.chkModificationInventaireMec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationInventaireMec.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationInventaireMec.CausesValidation = True
		Me.chkModificationInventaireMec.Enabled = True
		Me.chkModificationInventaireMec.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationInventaireMec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationInventaireMec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationInventaireMec.TabStop = True
		Me.chkModificationInventaireMec.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationInventaireMec.Visible = True
		Me.chkModificationInventaireMec.Name = "chkModificationInventaireMec"
		Me.chkModificationInventaireElec.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationInventaireElec.Text = "Inventaire électrique"
		Me.chkModificationInventaireElec.ForeColor = System.Drawing.Color.White
		Me.chkModificationInventaireElec.Size = New System.Drawing.Size(129, 17)
		Me.chkModificationInventaireElec.Location = New System.Drawing.Point(184, 24)
		Me.chkModificationInventaireElec.TabIndex = 32
		Me.ToolTip1.SetToolTip(Me.chkModificationInventaireElec, "Modification de l'inventaire électrique")
		Me.chkModificationInventaireElec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationInventaireElec.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationInventaireElec.CausesValidation = True
		Me.chkModificationInventaireElec.Enabled = True
		Me.chkModificationInventaireElec.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationInventaireElec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationInventaireElec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationInventaireElec.TabStop = True
		Me.chkModificationInventaireElec.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationInventaireElec.Visible = True
		Me.chkModificationInventaireElec.Name = "chkModificationInventaireElec"
		Me.chkModificationCatalogueElec.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationCatalogueElec.Text = "Catalogue électrique"
		Me.chkModificationCatalogueElec.ForeColor = System.Drawing.Color.White
		Me.chkModificationCatalogueElec.Size = New System.Drawing.Size(129, 17)
		Me.chkModificationCatalogueElec.Location = New System.Drawing.Point(184, 48)
		Me.chkModificationCatalogueElec.TabIndex = 35
		Me.ToolTip1.SetToolTip(Me.chkModificationCatalogueElec, "Modication du catalogue électrique")
		Me.chkModificationCatalogueElec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationCatalogueElec.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationCatalogueElec.CausesValidation = True
		Me.chkModificationCatalogueElec.Enabled = True
		Me.chkModificationCatalogueElec.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationCatalogueElec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationCatalogueElec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationCatalogueElec.TabStop = True
		Me.chkModificationCatalogueElec.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationCatalogueElec.Visible = True
		Me.chkModificationCatalogueElec.Name = "chkModificationCatalogueElec"
		Me.chkModificationCatalogueMec.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationCatalogueMec.Text = "Catalogue mécanique"
		Me.chkModificationCatalogueMec.ForeColor = System.Drawing.Color.White
		Me.chkModificationCatalogueMec.Size = New System.Drawing.Size(129, 17)
		Me.chkModificationCatalogueMec.Location = New System.Drawing.Point(8, 288)
		Me.chkModificationCatalogueMec.TabIndex = 27
		Me.ToolTip1.SetToolTip(Me.chkModificationCatalogueMec, "Modification du catalogue mécanique")
		Me.chkModificationCatalogueMec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationCatalogueMec.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationCatalogueMec.CausesValidation = True
		Me.chkModificationCatalogueMec.Enabled = True
		Me.chkModificationCatalogueMec.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationCatalogueMec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationCatalogueMec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationCatalogueMec.TabStop = True
		Me.chkModificationCatalogueMec.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationCatalogueMec.Visible = True
		Me.chkModificationCatalogueMec.Name = "chkModificationCatalogueMec"
		Me.chkModificationBonsCommandes.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationBonsCommandes.Text = "Bons de commandes"
		Me.chkModificationBonsCommandes.ForeColor = System.Drawing.Color.White
		Me.chkModificationBonsCommandes.Size = New System.Drawing.Size(121, 17)
		Me.chkModificationBonsCommandes.Location = New System.Drawing.Point(8, 216)
		Me.chkModificationBonsCommandes.TabIndex = 42
		Me.ToolTip1.SetToolTip(Me.chkModificationBonsCommandes, "Modification des bons de commandes")
		Me.chkModificationBonsCommandes.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationBonsCommandes.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationBonsCommandes.CausesValidation = True
		Me.chkModificationBonsCommandes.Enabled = True
		Me.chkModificationBonsCommandes.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationBonsCommandes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationBonsCommandes.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationBonsCommandes.TabStop = True
		Me.chkModificationBonsCommandes.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationBonsCommandes.Visible = True
		Me.chkModificationBonsCommandes.Name = "chkModificationBonsCommandes"
		Me.chkModificationSoumissionElec.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationSoumissionElec.Text = "Soumissions électriques"
		Me.chkModificationSoumissionElec.ForeColor = System.Drawing.Color.White
		Me.chkModificationSoumissionElec.Size = New System.Drawing.Size(137, 17)
		Me.chkModificationSoumissionElec.Location = New System.Drawing.Point(184, 72)
		Me.chkModificationSoumissionElec.TabIndex = 37
		Me.ToolTip1.SetToolTip(Me.chkModificationSoumissionElec, "Modification des soumissions électriques")
		Me.chkModificationSoumissionElec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationSoumissionElec.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationSoumissionElec.CausesValidation = True
		Me.chkModificationSoumissionElec.Enabled = True
		Me.chkModificationSoumissionElec.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationSoumissionElec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationSoumissionElec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationSoumissionElec.TabStop = True
		Me.chkModificationSoumissionElec.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationSoumissionElec.Visible = True
		Me.chkModificationSoumissionElec.Name = "chkModificationSoumissionElec"
		Me.chkModificationProjetElec.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationProjetElec.Text = "Projets électriques"
		Me.chkModificationProjetElec.ForeColor = System.Drawing.Color.White
		Me.chkModificationProjetElec.Size = New System.Drawing.Size(113, 17)
		Me.chkModificationProjetElec.Location = New System.Drawing.Point(184, 96)
		Me.chkModificationProjetElec.TabIndex = 39
		Me.ToolTip1.SetToolTip(Me.chkModificationProjetElec, "Modification des projets électriques")
		Me.chkModificationProjetElec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationProjetElec.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationProjetElec.CausesValidation = True
		Me.chkModificationProjetElec.Enabled = True
		Me.chkModificationProjetElec.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationProjetElec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationProjetElec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationProjetElec.TabStop = True
		Me.chkModificationProjetElec.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationProjetElec.Visible = True
		Me.chkModificationProjetElec.Name = "chkModificationProjetElec"
		Me.chkModificationProjetMec.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationProjetMec.Text = "Projets mécaniques"
		Me.chkModificationProjetMec.ForeColor = System.Drawing.Color.White
		Me.chkModificationProjetMec.Size = New System.Drawing.Size(113, 17)
		Me.chkModificationProjetMec.Location = New System.Drawing.Point(8, 336)
		Me.chkModificationProjetMec.TabIndex = 31
		Me.ToolTip1.SetToolTip(Me.chkModificationProjetMec, "Modification des projets mécaniques")
		Me.chkModificationProjetMec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationProjetMec.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationProjetMec.CausesValidation = True
		Me.chkModificationProjetMec.Enabled = True
		Me.chkModificationProjetMec.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationProjetMec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationProjetMec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationProjetMec.TabStop = True
		Me.chkModificationProjetMec.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationProjetMec.Visible = True
		Me.chkModificationProjetMec.Name = "chkModificationProjetMec"
		Me.chkModificationSoumissionMec.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationSoumissionMec.Text = "Soumissions mécaniques"
		Me.chkModificationSoumissionMec.ForeColor = System.Drawing.Color.White
		Me.chkModificationSoumissionMec.Size = New System.Drawing.Size(138, 17)
		Me.chkModificationSoumissionMec.Location = New System.Drawing.Point(8, 312)
		Me.chkModificationSoumissionMec.TabIndex = 28
		Me.ToolTip1.SetToolTip(Me.chkModificationSoumissionMec, "Modification des soumissions mécaniques mécaniques")
		Me.chkModificationSoumissionMec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationSoumissionMec.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationSoumissionMec.CausesValidation = True
		Me.chkModificationSoumissionMec.Enabled = True
		Me.chkModificationSoumissionMec.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationSoumissionMec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationSoumissionMec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationSoumissionMec.TabStop = True
		Me.chkModificationSoumissionMec.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationSoumissionMec.Visible = True
		Me.chkModificationSoumissionMec.Name = "chkModificationSoumissionMec"
		Me.chkModificationFacturation.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationFacturation.Text = "Facturation"
		Me.chkModificationFacturation.ForeColor = System.Drawing.Color.White
		Me.chkModificationFacturation.Size = New System.Drawing.Size(81, 17)
		Me.chkModificationFacturation.Location = New System.Drawing.Point(8, 192)
		Me.chkModificationFacturation.TabIndex = 40
		Me.ToolTip1.SetToolTip(Me.chkModificationFacturation, "Modification de la facturation")
		Me.chkModificationFacturation.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationFacturation.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationFacturation.CausesValidation = True
		Me.chkModificationFacturation.Enabled = True
		Me.chkModificationFacturation.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationFacturation.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationFacturation.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationFacturation.TabStop = True
		Me.chkModificationFacturation.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationFacturation.Visible = True
		Me.chkModificationFacturation.Name = "chkModificationFacturation"
		Me.chkModificationOutils.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationOutils.Text = "Outils et machinerie"
		Me.chkModificationOutils.ForeColor = System.Drawing.Color.White
		Me.chkModificationOutils.Size = New System.Drawing.Size(113, 17)
		Me.chkModificationOutils.Location = New System.Drawing.Point(8, 168)
		Me.chkModificationOutils.TabIndex = 38
		Me.ToolTip1.SetToolTip(Me.chkModificationOutils, "Modification des outils et machinerie")
		Me.chkModificationOutils.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationOutils.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationOutils.CausesValidation = True
		Me.chkModificationOutils.Enabled = True
		Me.chkModificationOutils.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationOutils.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationOutils.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationOutils.TabStop = True
		Me.chkModificationOutils.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationOutils.Visible = True
		Me.chkModificationOutils.Name = "chkModificationOutils"
		Me.chkModificationFeuillesTemps.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationFeuillesTemps.Text = "Feuilles de temps"
		Me.chkModificationFeuillesTemps.ForeColor = System.Drawing.Color.White
		Me.chkModificationFeuillesTemps.Size = New System.Drawing.Size(105, 17)
		Me.chkModificationFeuillesTemps.Location = New System.Drawing.Point(8, 144)
		Me.chkModificationFeuillesTemps.TabIndex = 36
		Me.ToolTip1.SetToolTip(Me.chkModificationFeuillesTemps, "Modification des feuilles de temps")
		Me.chkModificationFeuillesTemps.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationFeuillesTemps.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationFeuillesTemps.CausesValidation = True
		Me.chkModificationFeuillesTemps.Enabled = True
		Me.chkModificationFeuillesTemps.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationFeuillesTemps.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationFeuillesTemps.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationFeuillesTemps.TabStop = True
		Me.chkModificationFeuillesTemps.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationFeuillesTemps.Visible = True
		Me.chkModificationFeuillesTemps.Name = "chkModificationFeuillesTemps"
		Me.chkModificationGroupes.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationGroupes.Text = "Groupes de sécurité"
		Me.chkModificationGroupes.ForeColor = System.Drawing.Color.White
		Me.chkModificationGroupes.Size = New System.Drawing.Size(129, 17)
		Me.chkModificationGroupes.Location = New System.Drawing.Point(8, 120)
		Me.chkModificationGroupes.TabIndex = 34
		Me.ToolTip1.SetToolTip(Me.chkModificationGroupes, "Modification des groupes de sécurité")
		Me.chkModificationGroupes.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationGroupes.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationGroupes.CausesValidation = True
		Me.chkModificationGroupes.Enabled = True
		Me.chkModificationGroupes.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationGroupes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationGroupes.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationGroupes.TabStop = True
		Me.chkModificationGroupes.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationGroupes.Visible = True
		Me.chkModificationGroupes.Name = "chkModificationGroupes"
		Me.chkModificationEmployes.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationEmployes.Text = "Employés"
		Me.chkModificationEmployes.ForeColor = System.Drawing.Color.White
		Me.chkModificationEmployes.Size = New System.Drawing.Size(137, 17)
		Me.chkModificationEmployes.Location = New System.Drawing.Point(8, 96)
		Me.chkModificationEmployes.TabIndex = 33
		Me.ToolTip1.SetToolTip(Me.chkModificationEmployes, "Modification des employés")
		Me.chkModificationEmployes.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationEmployes.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationEmployes.CausesValidation = True
		Me.chkModificationEmployes.Enabled = True
		Me.chkModificationEmployes.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationEmployes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationEmployes.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationEmployes.TabStop = True
		Me.chkModificationEmployes.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationEmployes.Visible = True
		Me.chkModificationEmployes.Name = "chkModificationEmployes"
		Me.chkModificationContacts.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationContacts.Text = "Contacts"
		Me.chkModificationContacts.ForeColor = System.Drawing.Color.White
		Me.chkModificationContacts.Size = New System.Drawing.Size(137, 17)
		Me.chkModificationContacts.Location = New System.Drawing.Point(8, 72)
		Me.chkModificationContacts.TabIndex = 30
		Me.ToolTip1.SetToolTip(Me.chkModificationContacts, "Modification des contacts")
		Me.chkModificationContacts.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationContacts.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationContacts.CausesValidation = True
		Me.chkModificationContacts.Enabled = True
		Me.chkModificationContacts.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationContacts.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationContacts.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationContacts.TabStop = True
		Me.chkModificationContacts.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationContacts.Visible = True
		Me.chkModificationContacts.Name = "chkModificationContacts"
		Me.chkModificationFRS.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationFRS.Text = "Fournisseurs"
		Me.chkModificationFRS.ForeColor = System.Drawing.Color.White
		Me.chkModificationFRS.Size = New System.Drawing.Size(137, 17)
		Me.chkModificationFRS.Location = New System.Drawing.Point(8, 48)
		Me.chkModificationFRS.TabIndex = 29
		Me.ToolTip1.SetToolTip(Me.chkModificationFRS, "Modification des fournisseurs")
		Me.chkModificationFRS.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationFRS.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationFRS.CausesValidation = True
		Me.chkModificationFRS.Enabled = True
		Me.chkModificationFRS.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationFRS.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationFRS.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationFRS.TabStop = True
		Me.chkModificationFRS.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationFRS.Visible = True
		Me.chkModificationFRS.Name = "chkModificationFRS"
		Me.chkModificationClients.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkModificationClients.Text = "Clients"
		Me.chkModificationClients.ForeColor = System.Drawing.Color.White
		Me.chkModificationClients.Size = New System.Drawing.Size(137, 17)
		Me.chkModificationClients.Location = New System.Drawing.Point(8, 24)
		Me.chkModificationClients.TabIndex = 26
		Me.ToolTip1.SetToolTip(Me.chkModificationClients, "Modification des clients")
		Me.chkModificationClients.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkModificationClients.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkModificationClients.CausesValidation = True
		Me.chkModificationClients.Enabled = True
		Me.chkModificationClients.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkModificationClients.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkModificationClients.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkModificationClients.TabStop = True
		Me.chkModificationClients.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkModificationClients.Visible = True
		Me.chkModificationClients.Name = "chkModificationClients"
		Me.cmbGroupe.BackColor = System.Drawing.Color.White
		Me.cmbGroupe.Size = New System.Drawing.Size(137, 21)
		Me.cmbGroupe.Location = New System.Drawing.Point(248, 24)
		Me.cmbGroupe.TabIndex = 2
		Me.cmbGroupe.Text = "cmbGroupe"
		Me.cmbGroupe.CausesValidation = True
		Me.cmbGroupe.Enabled = True
		Me.cmbGroupe.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbGroupe.IntegralHeight = True
		Me.cmbGroupe.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbGroupe.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbGroupe.Sorted = False
		Me.cmbGroupe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbGroupe.TabStop = True
		Me.cmbGroupe.Visible = True
		Me.cmbGroupe.Name = "cmbGroupe"
		Me.fraAffichage.BackColor = System.Drawing.SystemColors.MenuText
		Me.fraAffichage.Text = "Affichage"
		Me.fraAffichage.ForeColor = System.Drawing.Color.White
		Me.fraAffichage.Size = New System.Drawing.Size(329, 361)
		Me.fraAffichage.Location = New System.Drawing.Point(8, 96)
		Me.fraAffichage.TabIndex = 5
		Me.fraAffichage.Enabled = True
		Me.fraAffichage.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fraAffichage.Visible = True
		Me.fraAffichage.Padding = New System.Windows.Forms.Padding(0)
		Me.fraAffichage.Name = "fraAffichage"
		Me.chkAchat.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkAchat.Text = "Achats"
		Me.chkAchat.ForeColor = System.Drawing.Color.White
		Me.chkAchat.Size = New System.Drawing.Size(113, 17)
		Me.chkAchat.Location = New System.Drawing.Point(184, 120)
		Me.chkAchat.TabIndex = 23
		Me.ToolTip1.SetToolTip(Me.chkAchat, "Affichage des achats")
		Me.chkAchat.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkAchat.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkAchat.CausesValidation = True
		Me.chkAchat.Enabled = True
		Me.chkAchat.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkAchat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkAchat.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkAchat.TabStop = True
		Me.chkAchat.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkAchat.Visible = True
		Me.chkAchat.Name = "chkAchat"
		Me.chkInventaireMec.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkInventaireMec.Text = "Inventaire mécanique"
		Me.chkInventaireMec.ForeColor = System.Drawing.Color.White
		Me.chkInventaireMec.Size = New System.Drawing.Size(145, 17)
		Me.chkInventaireMec.Location = New System.Drawing.Point(8, 264)
		Me.chkInventaireMec.TabIndex = 7
		Me.ToolTip1.SetToolTip(Me.chkInventaireMec, "Affichage de l'inventaire mécanique")
		Me.chkInventaireMec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkInventaireMec.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkInventaireMec.CausesValidation = True
		Me.chkInventaireMec.Enabled = True
		Me.chkInventaireMec.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkInventaireMec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkInventaireMec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkInventaireMec.TabStop = True
		Me.chkInventaireMec.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkInventaireMec.Visible = True
		Me.chkInventaireMec.Name = "chkInventaireMec"
		Me.chkInventaireElec.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkInventaireElec.Text = "Inventaire électrique"
		Me.chkInventaireElec.ForeColor = System.Drawing.Color.White
		Me.chkInventaireElec.Size = New System.Drawing.Size(129, 17)
		Me.chkInventaireElec.Location = New System.Drawing.Point(184, 24)
		Me.chkInventaireElec.TabIndex = 15
		Me.ToolTip1.SetToolTip(Me.chkInventaireElec, "Affichage de l'inventaire électrique")
		Me.chkInventaireElec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkInventaireElec.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkInventaireElec.CausesValidation = True
		Me.chkInventaireElec.Enabled = True
		Me.chkInventaireElec.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkInventaireElec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkInventaireElec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkInventaireElec.TabStop = True
		Me.chkInventaireElec.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkInventaireElec.Visible = True
		Me.chkInventaireElec.Name = "chkInventaireElec"
		Me.chkCatalogueElec.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkCatalogueElec.Text = "Catalogue électrique"
		Me.chkCatalogueElec.ForeColor = System.Drawing.Color.White
		Me.chkCatalogueElec.Size = New System.Drawing.Size(129, 17)
		Me.chkCatalogueElec.Location = New System.Drawing.Point(184, 48)
		Me.chkCatalogueElec.TabIndex = 17
		Me.ToolTip1.SetToolTip(Me.chkCatalogueElec, "Affichage du catalogue électrique")
		Me.chkCatalogueElec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkCatalogueElec.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkCatalogueElec.CausesValidation = True
		Me.chkCatalogueElec.Enabled = True
		Me.chkCatalogueElec.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkCatalogueElec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkCatalogueElec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkCatalogueElec.TabStop = True
		Me.chkCatalogueElec.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkCatalogueElec.Visible = True
		Me.chkCatalogueElec.Name = "chkCatalogueElec"
		Me.chkSoumissionElec.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkSoumissionElec.Text = "Soumissions électriques"
		Me.chkSoumissionElec.ForeColor = System.Drawing.Color.White
		Me.chkSoumissionElec.Size = New System.Drawing.Size(137, 17)
		Me.chkSoumissionElec.Location = New System.Drawing.Point(184, 72)
		Me.chkSoumissionElec.TabIndex = 19
		Me.ToolTip1.SetToolTip(Me.chkSoumissionElec, "Affichage des soumissions électriques")
		Me.chkSoumissionElec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkSoumissionElec.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkSoumissionElec.CausesValidation = True
		Me.chkSoumissionElec.Enabled = True
		Me.chkSoumissionElec.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkSoumissionElec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkSoumissionElec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkSoumissionElec.TabStop = True
		Me.chkSoumissionElec.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkSoumissionElec.Visible = True
		Me.chkSoumissionElec.Name = "chkSoumissionElec"
		Me.chkProjetElec.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkProjetElec.Text = "Projets électriques"
		Me.chkProjetElec.ForeColor = System.Drawing.Color.White
		Me.chkProjetElec.Size = New System.Drawing.Size(113, 17)
		Me.chkProjetElec.Location = New System.Drawing.Point(184, 96)
		Me.chkProjetElec.TabIndex = 21
		Me.ToolTip1.SetToolTip(Me.chkProjetElec, "Affichage des projets électriques")
		Me.chkProjetElec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkProjetElec.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkProjetElec.CausesValidation = True
		Me.chkProjetElec.Enabled = True
		Me.chkProjetElec.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkProjetElec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkProjetElec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkProjetElec.TabStop = True
		Me.chkProjetElec.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkProjetElec.Visible = True
		Me.chkProjetElec.Name = "chkProjetElec"
		Me.chkProjetMec.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkProjetMec.Text = "Projets mécaniques"
		Me.chkProjetMec.ForeColor = System.Drawing.Color.White
		Me.chkProjetMec.Size = New System.Drawing.Size(145, 17)
		Me.chkProjetMec.Location = New System.Drawing.Point(8, 336)
		Me.chkProjetMec.TabIndex = 13
		Me.ToolTip1.SetToolTip(Me.chkProjetMec, "Affichage des projets mécaniques")
		Me.chkProjetMec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkProjetMec.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkProjetMec.CausesValidation = True
		Me.chkProjetMec.Enabled = True
		Me.chkProjetMec.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkProjetMec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkProjetMec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkProjetMec.TabStop = True
		Me.chkProjetMec.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkProjetMec.Visible = True
		Me.chkProjetMec.Name = "chkProjetMec"
		Me.chkSoumissionMec.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkSoumissionMec.Text = "Soumissions mécaniques"
		Me.chkSoumissionMec.ForeColor = System.Drawing.Color.White
		Me.chkSoumissionMec.Size = New System.Drawing.Size(145, 17)
		Me.chkSoumissionMec.Location = New System.Drawing.Point(8, 312)
		Me.chkSoumissionMec.TabIndex = 11
		Me.ToolTip1.SetToolTip(Me.chkSoumissionMec, "Affichage des soumissions mécaniques")
		Me.chkSoumissionMec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkSoumissionMec.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkSoumissionMec.CausesValidation = True
		Me.chkSoumissionMec.Enabled = True
		Me.chkSoumissionMec.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkSoumissionMec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkSoumissionMec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkSoumissionMec.TabStop = True
		Me.chkSoumissionMec.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkSoumissionMec.Visible = True
		Me.chkSoumissionMec.Name = "chkSoumissionMec"
		Me.chkOutils.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkOutils.Text = "Outils entrée-sortie"
		Me.chkOutils.ForeColor = System.Drawing.Color.White
		Me.chkOutils.Size = New System.Drawing.Size(137, 17)
		Me.chkOutils.Location = New System.Drawing.Point(8, 240)
		Me.chkOutils.TabIndex = 24
		Me.ToolTip1.SetToolTip(Me.chkOutils, "Affichage du magasin")
		Me.chkOutils.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkOutils.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkOutils.CausesValidation = True
		Me.chkOutils.Enabled = True
		Me.chkOutils.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkOutils.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkOutils.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkOutils.TabStop = True
		Me.chkOutils.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkOutils.Visible = True
		Me.chkOutils.Name = "chkOutils"
		Me.chkPunch.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkPunch.Text = "Punch"
		Me.chkPunch.ForeColor = System.Drawing.Color.White
		Me.chkPunch.Size = New System.Drawing.Size(145, 17)
		Me.chkPunch.Location = New System.Drawing.Point(8, 216)
		Me.chkPunch.TabIndex = 22
		Me.ToolTip1.SetToolTip(Me.chkPunch, "Affichage du punch")
		Me.chkPunch.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkPunch.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkPunch.CausesValidation = True
		Me.chkPunch.Enabled = True
		Me.chkPunch.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkPunch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkPunch.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkPunch.TabStop = True
		Me.chkPunch.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkPunch.Visible = True
		Me.chkPunch.Name = "chkPunch"
		Me.chkConfiguration.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkConfiguration.Text = "Configuration"
		Me.chkConfiguration.ForeColor = System.Drawing.Color.White
		Me.chkConfiguration.Size = New System.Drawing.Size(153, 17)
		Me.chkConfiguration.Location = New System.Drawing.Point(8, 192)
		Me.chkConfiguration.TabIndex = 20
		Me.ToolTip1.SetToolTip(Me.chkConfiguration, "Affichage de la configuration")
		Me.chkConfiguration.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkConfiguration.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkConfiguration.CausesValidation = True
		Me.chkConfiguration.Enabled = True
		Me.chkConfiguration.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkConfiguration.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkConfiguration.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkConfiguration.TabStop = True
		Me.chkConfiguration.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkConfiguration.Visible = True
		Me.chkConfiguration.Name = "chkConfiguration"
		Me.chkCedule.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkCedule.Text = "Cédule"
		Me.chkCedule.ForeColor = System.Drawing.Color.White
		Me.chkCedule.Size = New System.Drawing.Size(129, 17)
		Me.chkCedule.Location = New System.Drawing.Point(8, 168)
		Me.chkCedule.TabIndex = 18
		Me.ToolTip1.SetToolTip(Me.chkCedule, "Affichage de la cédule")
		Me.chkCedule.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkCedule.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkCedule.CausesValidation = True
		Me.chkCedule.Enabled = True
		Me.chkCedule.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkCedule.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkCedule.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkCedule.TabStop = True
		Me.chkCedule.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkCedule.Visible = True
		Me.chkCedule.Name = "chkCedule"
		Me.chkEmployes.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkEmployes.Text = "Employés"
		Me.chkEmployes.ForeColor = System.Drawing.Color.White
		Me.chkEmployes.Size = New System.Drawing.Size(129, 17)
		Me.chkEmployes.Location = New System.Drawing.Point(8, 144)
		Me.chkEmployes.TabIndex = 16
		Me.ToolTip1.SetToolTip(Me.chkEmployes, "Affichage des employés")
		Me.chkEmployes.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkEmployes.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkEmployes.CausesValidation = True
		Me.chkEmployes.Enabled = True
		Me.chkEmployes.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkEmployes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkEmployes.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkEmployes.TabStop = True
		Me.chkEmployes.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkEmployes.Visible = True
		Me.chkEmployes.Name = "chkEmployes"
		Me.chkCatalogueMec.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkCatalogueMec.Text = "Catalogue mécanique"
		Me.chkCatalogueMec.ForeColor = System.Drawing.Color.White
		Me.chkCatalogueMec.Size = New System.Drawing.Size(145, 17)
		Me.chkCatalogueMec.Location = New System.Drawing.Point(8, 288)
		Me.chkCatalogueMec.TabIndex = 9
		Me.ToolTip1.SetToolTip(Me.chkCatalogueMec, "Affichage du catalogue mécaniqe")
		Me.chkCatalogueMec.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkCatalogueMec.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkCatalogueMec.CausesValidation = True
		Me.chkCatalogueMec.Enabled = True
		Me.chkCatalogueMec.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkCatalogueMec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkCatalogueMec.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkCatalogueMec.TabStop = True
		Me.chkCatalogueMec.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkCatalogueMec.Visible = True
		Me.chkCatalogueMec.Name = "chkCatalogueMec"
		Me.chkRapports.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkRapports.Text = "Rapports"
		Me.chkRapports.ForeColor = System.Drawing.Color.White
		Me.chkRapports.Size = New System.Drawing.Size(129, 17)
		Me.chkRapports.Location = New System.Drawing.Point(8, 120)
		Me.chkRapports.TabIndex = 14
		Me.ToolTip1.SetToolTip(Me.chkRapports, "Affichage des rapports")
		Me.chkRapports.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkRapports.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkRapports.CausesValidation = True
		Me.chkRapports.Enabled = True
		Me.chkRapports.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkRapports.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkRapports.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkRapports.TabStop = True
		Me.chkRapports.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkRapports.Visible = True
		Me.chkRapports.Name = "chkRapports"
		Me.chkContactsVendeurs.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkContactsVendeurs.Text = "Contacts pour vendeur"
		Me.chkContactsVendeurs.ForeColor = System.Drawing.Color.White
		Me.chkContactsVendeurs.Size = New System.Drawing.Size(137, 17)
		Me.chkContactsVendeurs.Location = New System.Drawing.Point(8, 96)
		Me.chkContactsVendeurs.TabIndex = 12
		Me.ToolTip1.SetToolTip(Me.chkContactsVendeurs, "Affichage des contacts pour les vendeurs")
		Me.chkContactsVendeurs.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkContactsVendeurs.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkContactsVendeurs.CausesValidation = True
		Me.chkContactsVendeurs.Enabled = True
		Me.chkContactsVendeurs.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkContactsVendeurs.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkContactsVendeurs.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkContactsVendeurs.TabStop = True
		Me.chkContactsVendeurs.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkContactsVendeurs.Visible = True
		Me.chkContactsVendeurs.Name = "chkContactsVendeurs"
		Me.chkContacts.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkContacts.Text = "Contacts"
		Me.chkContacts.ForeColor = System.Drawing.Color.White
		Me.chkContacts.Size = New System.Drawing.Size(113, 17)
		Me.chkContacts.Location = New System.Drawing.Point(8, 72)
		Me.chkContacts.TabIndex = 10
		Me.ToolTip1.SetToolTip(Me.chkContacts, "Affichage des contacts")
		Me.chkContacts.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkContacts.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkContacts.CausesValidation = True
		Me.chkContacts.Enabled = True
		Me.chkContacts.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkContacts.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkContacts.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkContacts.TabStop = True
		Me.chkContacts.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkContacts.Visible = True
		Me.chkContacts.Name = "chkContacts"
		Me.chkFournisseurs.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkFournisseurs.Text = "Fournisseurs"
		Me.chkFournisseurs.ForeColor = System.Drawing.Color.White
		Me.chkFournisseurs.Size = New System.Drawing.Size(113, 17)
		Me.chkFournisseurs.Location = New System.Drawing.Point(8, 48)
		Me.chkFournisseurs.TabIndex = 8
		Me.ToolTip1.SetToolTip(Me.chkFournisseurs, "Affichage des fournisseurs")
		Me.chkFournisseurs.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkFournisseurs.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkFournisseurs.CausesValidation = True
		Me.chkFournisseurs.Enabled = True
		Me.chkFournisseurs.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkFournisseurs.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkFournisseurs.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkFournisseurs.TabStop = True
		Me.chkFournisseurs.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkFournisseurs.Visible = True
		Me.chkFournisseurs.Name = "chkFournisseurs"
		Me.chkClients.BackColor = System.Drawing.SystemColors.ControlText
		Me.chkClients.Text = "Clients"
		Me.chkClients.ForeColor = System.Drawing.Color.White
		Me.chkClients.Size = New System.Drawing.Size(113, 17)
		Me.chkClients.Location = New System.Drawing.Point(8, 24)
		Me.chkClients.TabIndex = 6
		Me.ToolTip1.SetToolTip(Me.chkClients, "Affichage des clients")
		Me.chkClients.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkClients.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkClients.CausesValidation = True
		Me.chkClients.Enabled = True
		Me.chkClients.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkClients.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkClients.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkClients.TabStop = True
		Me.chkClients.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkClients.Visible = True
		Me.chkClients.Name = "chkClients"
		Me.cmdEnregistrer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEnregistrer.Text = "Enregistrer"
		Me.cmdEnregistrer.Size = New System.Drawing.Size(105, 25)
		Me.cmdEnregistrer.Location = New System.Drawing.Point(296, 472)
		Me.cmdEnregistrer.TabIndex = 48
		Me.cmdEnregistrer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEnregistrer.CausesValidation = True
		Me.cmdEnregistrer.Enabled = True
		Me.cmdEnregistrer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEnregistrer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEnregistrer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEnregistrer.TabStop = True
		Me.cmdEnregistrer.Name = "cmdEnregistrer"
		Me.cmdAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAnnuler.Text = "Annuler"
		Me.cmdAnnuler.Size = New System.Drawing.Size(105, 25)
		Me.cmdAnnuler.Location = New System.Drawing.Point(408, 472)
		Me.cmdAnnuler.TabIndex = 51
		Me.cmdAnnuler.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAnnuler.CausesValidation = True
		Me.cmdAnnuler.Enabled = True
		Me.cmdAnnuler.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAnnuler.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAnnuler.TabStop = True
		Me.cmdAnnuler.Name = "cmdAnnuler"
		Me.txtGroupe.AutoSize = False
		Me.txtGroupe.Size = New System.Drawing.Size(137, 19)
		Me.txtGroupe.Location = New System.Drawing.Point(248, 24)
		Me.txtGroupe.TabIndex = 3
		Me.txtGroupe.AcceptsReturn = True
		Me.txtGroupe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtGroupe.BackColor = System.Drawing.SystemColors.Window
		Me.txtGroupe.CausesValidation = True
		Me.txtGroupe.Enabled = True
		Me.txtGroupe.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtGroupe.HideSelection = True
		Me.txtGroupe.ReadOnly = False
		Me.txtGroupe.Maxlength = 0
		Me.txtGroupe.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtGroupe.MultiLine = False
		Me.txtGroupe.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtGroupe.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtGroupe.TabStop = True
		Me.txtGroupe.Visible = True
		Me.txtGroupe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtGroupe.Name = "txtGroupe"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label1.Text = "Liste des employés dans le groupe :"
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Size = New System.Drawing.Size(105, 33)
		Me.Label1.Location = New System.Drawing.Point(504, 8)
		Me.Label1.TabIndex = 1
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.lblGroupes.Text = "Groupes"
		Me.lblGroupes.ForeColor = System.Drawing.Color.White
		Me.lblGroupes.Size = New System.Drawing.Size(49, 17)
		Me.lblGroupes.Location = New System.Drawing.Point(248, 8)
		Me.lblGroupes.TabIndex = 0
		Me.lblGroupes.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblGroupes.BackColor = System.Drawing.Color.Transparent
		Me.lblGroupes.Enabled = True
		Me.lblGroupes.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblGroupes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblGroupes.UseMnemonic = True
		Me.lblGroupes.Visible = True
		Me.lblGroupes.AutoSize = False
		Me.lblGroupes.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblGroupes.Name = "lblGroupes"
		Me.Controls.Add(lstUser)
		Me.Controls.Add(cmdFermer)
		Me.Controls.Add(cmdSupprimer)
		Me.Controls.Add(cmdModifier)
		Me.Controls.Add(cmdAjouter)
		Me.Controls.Add(fraModification)
		Me.Controls.Add(cmbGroupe)
		Me.Controls.Add(fraAffichage)
		Me.Controls.Add(cmdEnregistrer)
		Me.Controls.Add(cmdAnnuler)
		Me.Controls.Add(txtGroupe)
		Me.Controls.Add(Label1)
		Me.Controls.Add(lblGroupes)
		Me.fraModification.Controls.Add(chkDeverrouillageTempsProjet)
		Me.fraModification.Controls.Add(chkVerrouillageTempsProjet)
		Me.fraModification.Controls.Add(chkPunchSemaineAnterieure)
		Me.fraModification.Controls.Add(chkMailingList)
		Me.fraModification.Controls.Add(chkRetourMarchandise)
		Me.fraModification.Controls.Add(chkReception)
		Me.fraModification.Controls.Add(chkSupprimerProjets)
		Me.fraModification.Controls.Add(chkModificationPunchEmployes)
		Me.fraModification.Controls.Add(chkModificationInventaireMec)
		Me.fraModification.Controls.Add(chkModificationInventaireElec)
		Me.fraModification.Controls.Add(chkModificationCatalogueElec)
		Me.fraModification.Controls.Add(chkModificationCatalogueMec)
		Me.fraModification.Controls.Add(chkModificationBonsCommandes)
		Me.fraModification.Controls.Add(chkModificationSoumissionElec)
		Me.fraModification.Controls.Add(chkModificationProjetElec)
		Me.fraModification.Controls.Add(chkModificationProjetMec)
		Me.fraModification.Controls.Add(chkModificationSoumissionMec)
		Me.fraModification.Controls.Add(chkModificationFacturation)
		Me.fraModification.Controls.Add(chkModificationOutils)
		Me.fraModification.Controls.Add(chkModificationFeuillesTemps)
		Me.fraModification.Controls.Add(chkModificationGroupes)
		Me.fraModification.Controls.Add(chkModificationEmployes)
		Me.fraModification.Controls.Add(chkModificationContacts)
		Me.fraModification.Controls.Add(chkModificationFRS)
		Me.fraModification.Controls.Add(chkModificationClients)
		Me.fraAffichage.Controls.Add(chkAchat)
		Me.fraAffichage.Controls.Add(chkInventaireMec)
		Me.fraAffichage.Controls.Add(chkInventaireElec)
		Me.fraAffichage.Controls.Add(chkCatalogueElec)
		Me.fraAffichage.Controls.Add(chkSoumissionElec)
		Me.fraAffichage.Controls.Add(chkProjetElec)
		Me.fraAffichage.Controls.Add(chkProjetMec)
		Me.fraAffichage.Controls.Add(chkSoumissionMec)
		Me.fraAffichage.Controls.Add(chkOutils)
		Me.fraAffichage.Controls.Add(chkPunch)
		Me.fraAffichage.Controls.Add(chkConfiguration)
		Me.fraAffichage.Controls.Add(chkCedule)
		Me.fraAffichage.Controls.Add(chkEmployes)
		Me.fraAffichage.Controls.Add(chkCatalogueMec)
		Me.fraAffichage.Controls.Add(chkRapports)
		Me.fraAffichage.Controls.Add(chkContactsVendeurs)
		Me.fraAffichage.Controls.Add(chkContacts)
		Me.fraAffichage.Controls.Add(chkFournisseurs)
		Me.fraAffichage.Controls.Add(chkClients)
		Me.fraModification.ResumeLayout(False)
		Me.fraAffichage.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class