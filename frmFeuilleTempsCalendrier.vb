Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmFeuilleTempsCalendrier
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
		'Ajout de la date
		
10: frmFeuilleTemps.txtSemaine.Text = GetDateTexte(GetFirstDay(mvwDate.Value))
		
15: frmFeuilleTemps.m_datSemaine = mvwDate.Value
		
		'Rempli le listview
20: Call frmFeuilleTemps.RemplirListView()
		
25: Call Me.Close()
		
30: Exit Sub
		
AfficherErreur: 
		
35: Call AfficherErreur("frmFeuilleTempsCalendrier", "cmdOK_Click", Err, Erl())
	End Sub
	
	Private Sub frmFeuilleTempsCalendrier_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
		'Ouverture de la fenêtre
10: Dim datDate As Date
15: Dim sDate As String
20: Dim sYear As String
25: Dim sMonth As String
30: Dim sDay As String
		
35: sDate = frmFeuilleTemps.txtSemaine.Text
		
		'Année
40: sYear = VB.Right(sDate, 4)
		
		'Pour enlever l'année de la date
45: sDate = VB.Left(sDate, Len(sDate) - 4)
		
		'Jour
50: sDay = Trim(VB.Left(sDate, 2))
		
		'Pour enlever le jour de la date
55: sDate = VB.Right(sDate, Len(sDate) - 2)
		
		'Pour avoir le no du mois
60: sMonth = CStr(GetNoMois(Trim(sDate)))
		
		'Conversion en date
65: datDate = DateSerial(CInt(sYear), CInt(sMonth), CInt(sDay))
		
		'Met la date actuelle comme valeur
70: mvwDate.Value = datDate
		
75: Call SelectionnerLigne(datDate)
		
80: Exit Sub
		
AfficherErreur: 
		
85: Call AfficherErreur("frmFeuilleTempsCalendrier", "Form_Load", Err, Erl())
	End Sub
	
	Private Function GetNoMois(ByVal sMois As String) As Short
		
5: On Error GoTo AfficherErreur
		
		'Procédure pour avoir le numéro du mois
10: Dim iNoMois As Short
		
15: sMois = UCase(sMois)
		
20: Select Case sMois
			Case "JANVIER" : iNoMois = 1
			Case "FÉVRIER" : iNoMois = 2
			Case "MARS" : iNoMois = 3
			Case "AVRIL" : iNoMois = 4
			Case "MAI" : iNoMois = 5
			Case "JUIN" : iNoMois = 6
			Case "JUILLET" : iNoMois = 7
			Case "AOÛT" : iNoMois = 8
			Case "SEPTEMBRE" : iNoMois = 9
			Case "OCTOBRE" : iNoMois = 10
			Case "NOVEMBRE" : iNoMois = 11
			Case "DÉCEMBRE" : iNoMois = 12
25: End Select
		
30: GetNoMois = iNoMois
		
35: Exit Function
		
AfficherErreur: 
		
40: Call AfficherErreur("frmFeuilleTempsCalendrier", "GetNoMois", Err, Erl())
	End Function
	
	Private Sub SelectionnerLigne(ByVal DateClicked As Date)
		
5: On Error GoTo AfficherErreur
		'Procédure pour sélectionner la ligne au complet
10: Dim datDim As Date
15: Dim datSam As Date
		
20: mvwDate.MultiSelect = True
		
25: datDim = GetFirstDay(DateClicked)
		
30: datSam = GetLastDay(DateClicked)
		
35: mvwDate.Value = datDim
		
40: mvwDate.SelStart = datDim
		
45: mvwDate.SelEnd = datSam
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmFeuilleTempsCalendrier", "SelectionnerLigne", Err, Erl())
	End Sub
	
	Private Sub mvwDate_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mvwDate.ClickEvent
		
5: On Error GoTo AfficherErreur
		'Sélectionner la semaine au complet
10: mvwDate.MultiSelect = False
		
15: Call SelectionnerLigne(mvwDate.Value)
		
20: Call cmdOK.Focus()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmFeuilleTempsCalendrier", "mvwDate_Click", Err, Erl())
	End Sub
End Class