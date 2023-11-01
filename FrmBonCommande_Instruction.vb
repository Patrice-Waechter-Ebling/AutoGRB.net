Option Strict Off
Option Explicit On
Friend Class FrmBonCommande_Instruction
	Inherits System.Windows.Forms.Form
	
	Private Sub CmdEnr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdEnr.Click
		
5: On Error GoTo AfficherErreur
		
		''''''''''''''''''''''''''''
		'Enregistrement d'une modif
		''''''''''''''''''''''''''''
10: Dim rstConfig As ADODB.Recordset
		
15: If txtCompagnie.Text <> vbNullString And txtAdresse.Text <> vbNullString And txtEtat.Text <> vbNullString And txtAssistance.Text <> vbNullString Then
20: rstConfig = New ADODB.Recordset
			
25: Call rstConfig.Open("SELECT * FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
			'enreg les donnees
30: rstConfig.Fields("parcel_label_line1").Value = txtCompagnie.Text
35: rstConfig.Fields("parcel_label_line2").Value = txtAdresse.Text
40: rstConfig.Fields("parcel_label_line3").Value = txtPays.Text
45: rstConfig.Fields("parcelassist").Value = txtAssistance.Text
50: rstConfig.Fields("parceletat").Value = txtEtat.Text
			
55: Call rstConfig.Update()
			
			'ferme table
60: Call rstConfig.Close()
65: 'UPGRADE_NOTE: Object rstConfig may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rstConfig = Nothing
70: Else
75: Call MsgBox("Champs vides!",  , "Erreur")
80: End If
		
85: Exit Sub
		
AfficherErreur: 
		
90: Call AfficherErreur("frmBonCommande_Instruction", "CmdEnr_Click", Err, Erl())
	End Sub
	
	Private Sub CmdFerme_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdFerme.Click
		
5: On Error GoTo AfficherErreur
		
		'quitte le form
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmBonCommande_Instruction", "CmdFerme_Click", Err, Erl())
	End Sub
	
	Private Sub AfficherDonnees()
		
5: On Error GoTo AfficherErreur
		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		'Affiche les données pour le rapport bon commande instruction
		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
10: Dim rstConfig As ADODB.Recordset
		
15: rstConfig = New ADODB.Recordset
		
20: Call rstConfig.Open("SELECT * FROM GRB_Config", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		
		'met les donnees dans les controls
25: txtCompagnie.Text = rstConfig.Fields("parcel_label_line1").Value
30: txtAdresse.Text = rstConfig.Fields("parcel_label_line2").Value
35: txtPays.Text = rstConfig.Fields("parcel_label_line3").Value
40: txtAssistance.Text = rstConfig.Fields("parcelassist").Value
45: txtEtat.Text = rstConfig.Fields("parceletat").Value
		
		'ferme table
50: Call rstConfig.Close()
55: 'UPGRADE_NOTE: Object rstConfig may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstConfig = Nothing
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmBonCommande_Instruction", "AfficherDonnees", Err, Erl())
	End Sub
	
	Private Sub FrmBonCommande_Instruction_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
		'affichage en mode visualisation
10: Call AfficherDonnees()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmBonCommande_Instruction", "Form_Load", Err, Erl())
	End Sub
End Class