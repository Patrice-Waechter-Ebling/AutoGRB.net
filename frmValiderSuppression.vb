Option Strict Off
Option Explicit On
Friend Class frmValiderSuppression
	Inherits System.Windows.Forms.Form
	Private m_frmSource As System.Windows.Forms.Form
	
	Public Sub Afficher(ByVal bProjet As Boolean, ByVal sNumero As String, ByVal frmSource As System.Windows.Forms.Form)
		If bProjet = True Then
			lblProjSoum.Text = "le projet"
		Else
			lblProjSoum.Text = "la soumission"
		End If
		
		lblNumero.Text = sNumero
		
		m_frmSource = frmSource
		
		Call AfficherNoValidation()
		
		Call Me.ShowDialog()
	End Sub
	
	Private Sub AfficherNoValidation()
		Dim iRandom As Short
		Dim iCompteur As Short
		Dim sValidation As String
		
		Call Randomize()
		
		For iCompteur = 1 To 3
			iRandom = Int(Rnd() * 26) + 1
			
			Select Case iRandom
				Case 1 : sValidation = sValidation & "A"
				Case 2 : sValidation = sValidation & "B"
				Case 3 : sValidation = sValidation & "C"
				Case 4 : sValidation = sValidation & "D"
				Case 5 : sValidation = sValidation & "E"
				Case 6 : sValidation = sValidation & "F"
				Case 7 : sValidation = sValidation & "G"
				Case 8 : sValidation = sValidation & "H"
				Case 9 : sValidation = sValidation & "I"
				Case 10 : sValidation = sValidation & "J"
				Case 11 : sValidation = sValidation & "K"
				Case 12 : sValidation = sValidation & "L"
				Case 13 : sValidation = sValidation & "M"
				Case 14 : sValidation = sValidation & "N"
				Case 15 : sValidation = sValidation & "O"
				Case 16 : sValidation = sValidation & "P"
				Case 17 : sValidation = sValidation & "Q"
				Case 18 : sValidation = sValidation & "R"
				Case 19 : sValidation = sValidation & "S"
				Case 20 : sValidation = sValidation & "T"
				Case 21 : sValidation = sValidation & "U"
				Case 22 : sValidation = sValidation & "V"
				Case 23 : sValidation = sValidation & "W"
				Case 24 : sValidation = sValidation & "X"
				Case 25 : sValidation = sValidation & "Y"
				Case 26 : sValidation = sValidation & "Z"
			End Select
		Next 
		
		lblValidation.Text = sValidation
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		'UPGRADE_ISSUE: Control m_bValide could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
		m_frmSource.m_bValide = False
		
		Call Me.Close()
	End Sub
	
	Private Sub cmdValider_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdValider.Click
		If UCase(lblValidation.Text) = UCase(txtValidation.Text) Then
			'UPGRADE_ISSUE: Control m_bValide could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
			m_frmSource.m_bValide = True
			
			Call Me.Close()
		Else
			Call MsgBox("Le code de validation est incorrect!", MsgBoxStyle.OKOnly, "Erreur")
		End If
	End Sub
	
	'UPGRADE_WARNING: Form event frmValiderSuppression.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub frmValiderSuppression_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		Call txtValidation.Focus()
	End Sub
	
	Private Sub frmValiderSuppression_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'  Call txtValidation.SetFocus
	End Sub
	'
End Class