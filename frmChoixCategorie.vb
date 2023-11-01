Option Strict Off
Option Explicit On
Friend Class frmChoixCategorie
	Inherits System.Windows.Forms.Form
	
	Private m_eCatalogue As ModuleMain.enumCatalogue
	
	Private Sub cmdAnnuler_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAnnuler.Click
		
5: On Error GoTo AfficherErreur
		
10: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
15: FrmCatalogueElec.m_bAnnulerCopie = True
20: Else
25: FrmCatalogueMec.m_bAnnulerCopie = True
30: End If
		
35: Call Me.Close()
		
40: Exit Sub
		
AfficherErreur: 
		
45: Call AfficherErreur("frmChoixCategorie", "cmdAnnuler_Click", Err, Erl())
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
5: On Error GoTo AfficherErreur
		
10: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
15: FrmCatalogueElec.m_bAnnulerCopie = False
20: FrmCatalogueElec.m_sCategorieCopie = cmbCategorie.Text
25: Else
30: FrmCatalogueMec.m_bAnnulerCopie = False
35: FrmCatalogueMec.m_sCategorieCopie = cmbCategorie.Text
40: End If
		
45: Call Me.Close()
		
50: Exit Sub
		
AfficherErreur: 
		
55: Call AfficherErreur("frmChoixCategorie", "cmdOK_Click", Err, Erl())
	End Sub
	
	Private Sub frmChoixCategorie_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
5: On Error GoTo AfficherErreur
		
10: Call RemplirComboCategorie()
		
15: Exit Sub
		
AfficherErreur: 
		
20: Call AfficherErreur("frmChoixCategorie", "Form_Load", Err, Erl())
	End Sub
	
	Private Sub RemplirComboCategorie()
		
5: On Error GoTo AfficherErreur
		
		'Remplir le combo des catégories
10: Dim rstCategorie As ADODB.Recordset
		
		'Il faut vider le combo avant de le remplir
15: Call cmbCategorie.Items.Clear()
		
20: rstCategorie = New ADODB.Recordset
		
25: If m_eCatalogue = ModuleMain.enumCatalogue.ELECTRIQUE Then
30: Call rstCategorie.Open("SELECT DISTINCT CATEGORIE FROM GRB_CatalogueElec ORDER BY CATEGORIE", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
35: Else
40: Call rstCategorie.Open("SELECT DISTINCT CATEGORIE FROM GRB_CatalogueMec ORDER BY CATEGORIE", g_connData, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
45: End If
		
		'Tant que ce n'est pas la fin des enregistrements
50: Do While Not rstCategorie.EOF
55: Call cmbCategorie.Items.Add(rstCategorie.Fields("CATEGORIE").Value)
			
60: Call rstCategorie.MoveNext()
65: Loop 
		
70: Call rstCategorie.Close()
75: 'UPGRADE_NOTE: Object rstCategorie may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstCategorie = Nothing
		
		'Si le combo n'est pas vide, on sélectionne le premier
80: If cmbCategorie.Items.Count > 0 Then
85: cmbCategorie.SelectedIndex = 0
90: End If
		
95: Exit Sub
		
AfficherErreur: 
		
100: Call AfficherErreur("frmChoixCategorie", "RemplirComboCategorie", Err, Erl())
	End Sub
	
	Public Sub Afficher(ByVal eCatalogue As ModuleMain.enumCatalogue)
		
5: On Error GoTo AfficherErreur
		
10: m_eCatalogue = eCatalogue
		
15: Call Me.ShowDialog()
		
20: Exit Sub
		
AfficherErreur: 
		
25: Call AfficherErreur("frmChoixCategorie", "Afficher", Err, Erl())
	End Sub
End Class