Option Strict Off
Option Explicit On
Friend Class frmChoixRetourMateriel
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdElectrique_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdElectrique.Click
		
5: On Error GoTo AfficherErreur
		
		'Pour ouvrir le catalogue électrique
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call frmRetourMateriel.Afficher(ModuleMain.enumCatalogue.ELECTRIQUE)
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixRetourMateriel", "cmdElectrique_Click", Err, Erl())
	End Sub
	
	Private Sub cmdMecanique_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMecanique.Click
		
5: On Error GoTo AfficherErreur
		
		'Pour ouvrir le catalogue mécanique
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call frmRetourMateriel.Afficher(ModuleMain.enumCatalogue.MECANIQUE)
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixRetourMateriel", "cmdMecanique_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixRetourMateriel", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixRetourMateriel_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Call frmChoixInventaire.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixRetourMateriel", "Form_Load", Err, Erl())
	End Sub
End Class