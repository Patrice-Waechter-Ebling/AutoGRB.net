Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmChoixDateImpressionReception
	Inherits System.Windows.Forms.Form
	
	Private Enum enumDate
		AUCUNE = 0
		DEBUT = 1
		Fin = 2
	End Enum
	
	Public Enum enumTypeReception
		PROJET = 0
		ACHAT = 1
	End Enum
	
	Private m_eDate As enumDate
	Private m_eCatalogue As ModuleMain.enumCatalogue
	Private m_eTypeReception As enumTypeReception
	Private m_sNoProjet As String
	Private m_sIDAchat As String
	Private m_iIndexAchat As Short
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDateImpressionReception", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdImprimer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImprimer.Click
		Dim DR_Reception As Object
		
5: On Error GoTo AfficherErreur
		
10: Dim rstReception As ADODB.Recordset
15: Dim rstTotal As ADODB.Recordset
		
16: If Len(mskDateDebut.Text) = 8 Then
17: Call mskDateDebut_Leave(mskDateDebut, New System.EventArgs())
18: End If
		
19: If Len(mskDateFin.Text) = 8 Then
20: Call mskDateFin_Leave(mskDateFin, New System.EventArgs())
21: End If
		
22: If ValiderDate(mskDateDebut.Text) = False Then
25: Call MsgBox("Date de début invalide!", MsgBoxStyle.OKOnly, "Erreur")
			
30: Exit Sub
35: End If
		
40: If ValiderDate(mskDateFin.Text) = False Then
45: Call MsgBox("Date de fin invalide!", MsgBoxStyle.OKOnly, "Erreur")
			
50: Exit Sub
55: End If
		
60: If mskDateFin.Text < mskDateDebut.Text Then
65: Call MsgBox("La date de fin doit être plus grande que la date de début!", MsgBoxStyle.OKOnly, "Erreur")
			
70: Exit Sub
75: End If
		
80: rstReception = New ADODB.Recordset
		
85: If m_eTypeReception = enumTypeReception.PROJET Then
90: Call rstReception.Open("SELECT GRB_Projet_Pieces.*, (Escompte / 100) As ModifEscompte, (Prix_Net * Qté) As TotalReception FROM GRB_Projet_Pieces WHERE IDProjet = '" & m_sNoProjet & "' AND ((Recu = True AND DateRéception BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "') OR (Retour = True AND DateRetour BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'))", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
95: Else
100: Call rstReception.Open("SELECT GRB_Achat_Pieces.*, (Escompte / 100) As ModifEscompte, (Prix_Net * Qté) As TotalReception FROM GRB_Achat_Pieces WHERE IDAchat = '" & m_sIDAchat & "' AND IndexAchat = " & m_iIndexAchat & " AND ((Recu = True AND DateRéception BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "') OR (Retour = True AND DateRetour BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'))", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
105: End If
		
110: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Reception.DataSource = rstReception
		
115: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DR_Reception.Sections("Section4").Controls("lblDate").Caption = "Du " & mskDateDebut.Text & " Au " & mskDateFin.Text
		
120: rstTotal = New ADODB.Recordset
		
125: If m_eTypeReception = enumTypeReception.ACHAT Then
130: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section4").Controls("lblTitreProjetAchat").Caption = "Achat :"
135: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section4").Controls("lblProjetAchat").Caption = m_sIDAchat & "-" & VB.Right("00" & m_iIndexAchat, 3)
			
140: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section1").Controls("txtDate").DataField = "DateRéception"
145: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section1").Controls("txtQuantite").DataField = "Qté"
150: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section1").Controls("txtPiece").DataField = "PIECE"
155: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section1").Controls("txtPrixListe").DataField = "Prix_List"
160: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section1").Controls("txtEscompte").DataField = "ModifEscompte"
165: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section1").Controls("txtPrixNet").DataField = "Prix_Net"
170: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section1").Controls("txtTotal").DataField = "TotalReception"
			
175: Call rstTotal.Open("SELECT SUM(Qté * Prix_Net) As Total FROM GRB_Achat_Pieces WHERE IDAchat = '" & m_sIDAchat & "' AND IndexAchat = " & m_iIndexAchat & " AND ((Recu = True AND DateRéception BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "') OR (Retour = True AND DateRetour BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'))", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
180: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstTotal.Fields("Total").Value) Then
185: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Reception.Sections("Section5").Controls("lblTotal").Caption = Conversion_Renamed(rstTotal.Fields("Total"), ModuleMain.enumConvert.MODE_ARGENT)
190: Else
195: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Reception.Sections("Section5").Controls("lblTotal").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
200: End If
205: Else
210: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section4").Controls("lblTitreProjetAchat").Caption = "Projet :"
215: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section4").Controls("lblProjetAchat").Caption = m_sNoProjet
			
220: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section1").Controls("txtDate").DataField = "DateRéception"
225: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section1").Controls("txtQuantite").DataField = "Qté"
230: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section1").Controls("txtPiece").DataField = "NumItem"
235: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section1").Controls("txtPrixListe").DataField = "Prix_List"
240: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section1").Controls("txtEscompte").DataField = "ModifEscompte"
245: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section1").Controls("txtPrixNet").DataField = "Prix_Net"
250: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DR_Reception.Sections("Section1").Controls("txtTotal").DataField = "TotalReception"
			
255: Call rstTotal.Open("SELECT SUM(Qté * Prix_Net) As Total FROM GRB_Projet_Pieces WHERE IDProjet = '" & m_sNoProjet & "' AND ((Recu = True AND DateRéception BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "') OR (Retour = True AND DateRetour BETWEEN '" & mskDateDebut.Text & "' AND '" & mskDateFin.Text & "'))", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
			
260: 'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(rstTotal.Fields("Total").Value) Then
265: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Reception.Sections("Section5").Controls("lblTotal").Caption = Conversion_Renamed(rstTotal.Fields("Total"), ModuleMain.enumConvert.MODE_ARGENT)
270: Else
275: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Sections. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DR_Reception.Sections("Section5").Controls("lblTotal").Caption = Conversion_Renamed("0", ModuleMain.enumConvert.MODE_ARGENT)
280: End If
285: End If
		
290: Call rstTotal.Close()
295: 'UPGRADE_NOTE: Object rstTotal may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstTotal = Nothing
		
300: 'UPGRADE_WARNING: Couldn't resolve default property of object DR_Reception.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call DR_Reception.Show(VB6.FormShowConstants.Modal)
		
305: Call Me.Close()
		
310: Exit Sub
		
AfficherErreur: 
		
315: Call AfficherErreur("frmChoixDateImpressionReception", "cmdImprimer_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixDateImpressionReception_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Click
		
5: On Error GoTo AfficherErreur
		
10: mvwDate.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDateImpressionReception", "Form_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixDateImpressionReception_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: m_eDate = enumDate.AUCUNE
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDateImpressionReception", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub mvwDate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mvwDate.Leave
		
5: On Error GoTo AfficherErreur
		
10: mvwDate.Visible = False
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDateImpressionReception", "mvwDate_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mvwDate_DateClick(ByVal eventSender As System.Object, ByVal eventArgs As AxMSComCtl2.DMonthViewEvents_DateClickEvent) Handles mvwDate.DateClick
		
5: On Error GoTo AfficherErreur
		
10: Select Case m_eDate
			Case enumDate.DEBUT : mskDateDebut.Text = ConvertDate(eventArgs.DateClicked)
			Case enumDate.Fin : mskDateFin.Text = ConvertDate(eventArgs.DateClicked)
15: End Select
		
20: m_eDate = enumDate.AUCUNE
		
		'Enlever le calendrier
25: mvwDate.Visible = False
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixDateImpressionReception", "mvwDate_DateClick", Err, Erl())
	End Sub
	
	Private Sub mskDateDebut_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateDebut.Enter
		
5: On Error GoTo AfficherErreur
		
		'Met l'année sur 2 chiffres
10: If Len(mskDateDebut.Text) = 10 Then
15: mskDateDebut.Text = VB.Right(mskDateDebut.Text, 8)
20: End If
		
25: mskDateDebut.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixDateImpressionReception", "mskDateDebut_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateFin_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateFin.Enter
		
5: On Error GoTo AfficherErreur
		
		'Met l'année sur 2 chiffres
10: If Len(mskDateFin.Text) = 10 Then
15: mskDateFin.Text = VB.Right(mskDateFin.Text, 8)
20: End If
		
25: mskDateFin.Mask = "##-##-##"
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmChoixDateImpressionReception", "mskDateFin_GotFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateDebut_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateDebut.Leave
		
5: On Error GoTo AfficherErreur
		
		'Enlève le mask
10: mskDateDebut.Mask = vbNullString
		
		'Vide le champs si l'utilisateur n'a rien écrit
15: If mskDateDebut.Text = "__-__-__" Then
20: mskDateDebut.Text = vbNullString
25: Else
			'Remet l'année sur 8 chiffres
30: If Len(mskDateDebut.Text) = 8 Then
35: If IsDate(mskDateDebut.Text) Then
40: mskDateDebut.Text = Year(DateSerial(CInt(VB.Left(mskDateDebut.Text, 2)), CInt(Mid(mskDateDebut.Text, 4, 2)), CInt(VB.Right(mskDateDebut.Text, 2)))) & Mid(mskDateDebut.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmChoixDateImpressionReception", "mskDateDebut_LostFocus", Err, Erl())
	End Sub
	
	Private Sub mskDateFin_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mskDateFin.Leave
		
5: On Error GoTo AfficherErreur
		
		'Enlève le mask
10: mskDateFin.Mask = vbNullString
		
		'Vide le champs si l'utilisateur n'a rien écrit
15: If mskDateFin.Text = "__-__-__" Then
20: mskDateFin.Text = vbNullString
25: Else
			'Remet l'année sur 8 chiffres
30: If Len(mskDateFin.Text) = 8 Then
35: If IsDate(mskDateFin.Text) Then
40: mskDateFin.Text = Year(DateSerial(CInt(VB.Left(mskDateFin.Text, 2)), CInt(Mid(mskDateFin.Text, 4, 2)), CInt(VB.Right(mskDateFin.Text, 2)))) & Mid(mskDateFin.Text, 3, 8)
45: End If
50: End If
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmChoixDateImpressionReception", "mskDateFin_LostFocus", Err, Erl())
	End Sub
	
	Private Sub cmdDateDebut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDateDebut.Click
		
5: On Error GoTo AfficherErreur
		'Ouverture du calendrier
		
		'Si il y a une date valide, la date par défaut est celle-ci, sinon c'est la date
		'd'aujourd'hui
10: If Trim(mskDateDebut.Text) <> vbNullString Then
15: If ValiderDate(mskDateDebut.Text) = True Then
20: mvwDate.Value = CDate(mskDateDebut.Text)
25: Else
30: mvwDate.Value = Today
35: End If
40: Else
45: mvwDate.Value = Today
50: End If
		
55: m_eDate = enumDate.DEBUT
		
60: mvwDate.Visible = True
		
65: Call mvwDate.Focus()
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmChoixDateImpressionReception", "cmdDateDebut_Click", Err, Erl())
	End Sub
	
	Private Sub cmdDateFin_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDateFin.Click
		
5: On Error GoTo AfficherErreur
		'Ouverture du calendrier
		
		'Si il y a une date valide, la date par défaut est celle-ci, sinon c'est la date
		'd'aujourd'hui
10: If Trim(mskDateFin.Text) <> vbNullString Then
15: If ValiderDate(mskDateFin.Text) = True Then
20: mvwDate.Value = CDate(mskDateFin.Text)
25: Else
30: mvwDate.Value = Today
35: End If
40: Else
45: mvwDate.Value = Today
50: End If
		
55: m_eDate = enumDate.Fin
		
60: mvwDate.Visible = True
		
65: Call mvwDate.Focus()
		
70: Exit Sub
		
AfficherErreur: 
		
75: Call AfficherErreur("frmChoixDateImpressionReception", "cmdDateFin_Click", Err, Erl())
	End Sub
	
	Private Function ValiderDate(ByVal sDate As String) As Boolean
		
5: On Error GoTo AfficherErreur
		
		'Validation des dates
10: If Not IsDate(sDate) Then
15: ValiderDate = False
20: Else
25: ValiderDate = True
30: End If
		
35: Exit Function
		
AfficherErreur: 
		
40: Call AfficherErreur("frmChoixDateImpressionReception", "ValiderDate", Err, Erl())
	End Function
	
	Public Sub Afficher(ByVal sNoProjet As String, ByVal eCatalogue As ModuleMain.enumCatalogue, ByVal eTypeReception As enumTypeReception)
		
5: On Error GoTo AfficherErreur
		
10: m_eTypeReception = eTypeReception
		
15: Select Case eTypeReception
			Case enumTypeReception.PROJET
20: m_sNoProjet = sNoProjet
				
25: Case enumTypeReception.ACHAT
30: m_sIDAchat = VB.Left(sNoProjet, 9)
35: m_iIndexAchat = CShort(VB.Right(sNoProjet, 3))
40: End Select
		
45: m_eCatalogue = eCatalogue
		
50: Call Me.ShowDialog()
		
55: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmChoixDateImpressionReception", "Afficher", Err, Erl())
	End Sub
End Class