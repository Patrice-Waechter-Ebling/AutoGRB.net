Option Strict Off
Option Explicit On
Friend Class frmChoixCatalogue
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdElectrique_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdElectrique.Click
		
5: On Error GoTo AfficherErreur
		
		'Pour ouvrir le catalogue électrique
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(FrmCatalogueElec, False)
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixCatalogue", "cmdElectrique_Click", Err, Erl())
	End Sub
	
	Private Sub cmdMecanique_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMecanique.Click
		
5: On Error GoTo AfficherErreur
		
		'Pour ouvrir le catalogue mécanique
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(FrmCatalogueMec, False)
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixCatalogue", "cmdMecanique_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixCatalogue", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixCatalogue_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Call ActiverBoutonsGroupe()
		
15: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmChoixCatalogue", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub ActiverBoutonsGroupe()
		
5: On Error GoTo AfficherErreur
		
10: If g_bAffichageCatalogueMec = True Then
15: cmdMecanique.Enabled = True
20: Else
25: cmdMecanique.Enabled = False
30: End If
		
35: If g_bAffichageCatalogueElec = True Then
40: cmdElectrique.Enabled = True
45: Else
50: cmdElectrique.Enabled = False
55: End If
		
60: Exit Sub
		
AfficherErreur: 
		
65: Call AfficherErreur("frmChoixCatalogue", "ActiverBoutonsGroupe", Err, Erl())
	End Sub
End Class