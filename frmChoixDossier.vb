Option Strict Off
Option Explicit On
Friend Class frmChoixDossier
	Inherits System.Windows.Forms.Form
	
	Private Enum enumType
		ELECTRIQUE = 0
		MECANIQUE = 1
	End Enum
	
	Private m_eType As enumType
	
	Public Sub Afficher(ByVal frmSource As System.Windows.Forms.Form)
		
5: On Error GoTo AfficherErreur
		
10: If frmSource.Name = "FrmProjSoumElec" Then
15: m_eType = enumType.ELECTRIQUE
20: Else
25: m_eType = enumType.MECANIQUE
30: End If
		
35: Call Me.ShowDialog()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmChoixDossier", "Afficher", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.ELECTRIQUE Then
15: FrmProjSoumElec.m_bAnnulerChemin = False
20: FrmProjSoumElec.m_sChemin = dirCheminPhotos.Path
25: Else
30: FrmProjSoumMec.m_bAnnulerChemin = False
35: FrmProjSoumMec.m_sChemin = dirCheminPhotos.Path
40: End If
		
45: Call Me.Close()
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmChoixDossier", "cmdOK_Click", Err, Erl())
	End Sub
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: If m_eType = enumType.ELECTRIQUE Then
15: FrmProjSoumElec.m_bAnnulerChemin = True
20: FrmProjSoumElec.m_sChemin = vbNullString
25: Else
30: FrmProjSoumElec.m_bAnnulerChemin = True
35: FrmProjSoumElec.m_sChemin = vbNullString
40: End If
		
45: Call Me.Close()
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmChoixDossier", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub drvCheminPhotos_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles drvCheminPhotos.SelectedIndexChanged
		
5: On Error GoTo AfficherErreur
		
10: dirCheminPhotos.Path = drvCheminPhotos.Drive
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixDossier", "drvCheminPhotos_Change", Err, Erl())
	End Sub
End Class