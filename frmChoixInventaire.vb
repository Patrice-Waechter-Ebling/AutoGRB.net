Option Strict Off
Option Explicit On
Friend Class frmChoixInventaire
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdElectrique_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdElectrique.Click
		
5: On Error GoTo AfficherErreur
		
		'Pour ouvrir l'inventaire électrique
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(frmInventaireElec, False)
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixInventaire", "cmdElectrique_Click", Err, Erl())
	End Sub
	
	Private Sub cmdMecanique_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMecanique.Click
		
5: On Error GoTo AfficherErreur
		
		'Pour ouvrir l'inventaire mécanique
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(frmInventaireMec, False)
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
60: Call AfficherErreur("frmChoixInventaire", "cmdMecanique_Click", Err, Erl())
	End Sub
	
	Private Sub cmdOutils_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOutils.Click
		
5: On Error GoTo AfficherErreur
		
		'Inventaire des outils
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
15: Call OuvrirForm(FrmOutils_InOut, False)
		
20: Call Me.Close()
		
25: Exit Sub
		
AfficherErreur: 
		
30: Call AfficherErreur("frmChoixInventaire", "cmdOutils_Click", Err, Erl())
	End Sub
	
	Private Sub cmdFermer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFermer.Click
		
5: On Error GoTo AfficherErreur
		
10: Call Me.Close()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixInventaire", "cmdFermer_Click", Err, Erl())
	End Sub
	
	Private Sub cmdRetour_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRetour.Click
		
5: On Error GoTo AfficherErreur
		
10: Call frmChoixRetourMateriel.ShowDialog()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixInventaire", "cmdRetour_Click", Err, Erl())
	End Sub
	
	Private Sub cmdsortie_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdsortie.Click
		
5: On Error GoTo AfficherErreur
		
10: Call frmChoixSortieMateriel.ShowDialog()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixInventaire", "cmdSortie_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixInventaire_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: 'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixInventaire", "Form_Load", Err, Erl())
	End Sub
End Class