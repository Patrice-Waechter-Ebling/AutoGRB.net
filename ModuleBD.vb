Option Strict Off
Option Explicit On
Module ModuleBD
	
	'Public Const S_CHEMIN_DEFAUT  As String = "\\Serveur\bdgrb\SEEGRB\Data.mdb"
	'Public Const S_CHEMIN_DEFAUT  As String = "C:\Documents and Settings\Gaetan\Desktop\Organi-tek\GRBinc\Data.mdb"
	
	Public g_connData As ADODB.Connection
	'Ouverture de la base de donné Actuel
	Public Function OuvrirConnection() As Boolean
		
10: Dim sdsn As String
15: Dim fso As Scripting.FileSystemObject
		
		'Si la connexion n'est pas ouverte
20: If g_connData Is Nothing Then
25: fso = CreateObject("Scripting.FileSystemObject")
			
			'Si le fichier de base de donnée existe
30: If fso.FileExists(CheminBD) Then
35: g_connData = New ADODB.Connection
				
				'Pour Access 2000, il faut utiliser Microsoft Jet 4.0
40: sdsn = "Provider=Microsoft.Jet.OLEDB.4.0;User ID = Admin;Data Source=" & CheminBD & ";Persist Security Info=False"
				
				'Ouverture de la connexion
45: Call g_connData.Open(sdsn)
				
50: OuvrirConnection = True
55: Else
60: Call MsgBox("La base de donnée est introuvable!" & vbNewLine & "Vérifiez votre connexion réseau!", MsgBoxStyle.OKOnly, "Erreur")
				
65: OuvrirConnection = False
70: End If
75: Else
80: OuvrirConnection = True
85: End If
		
	End Function
	
	Public Sub FermerConnection()
		
10: If Not g_connData Is Nothing Then
15: Call g_connData.Close()
20: 'UPGRADE_NOTE: Object g_connData may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			g_connData = Nothing
25: End If
		
	End Sub
	'Ouverture de la Vielle Base de Donnée
	Public Function OuvrirOldConnection() As Object
		Dim sdsn As String
		Dim fso As Scripting.FileSystemObject
		'Si la connexion n'est pas ouverte
20: If g_connData Is Nothing Then
25: fso = CreateObject("Scripting.FileSystemObject")
			
			'Si le fichier de base de donnée existe
30: If fso.FileExists(CheminOldBd) Then
35: g_connData = New ADODB.Connection
				
				'Pour Access 2000, il faut utiliser Microsoft Jet 4.0
40: sdsn = "Provider=Microsoft.Jet.OLEDB.4.0;User ID = Admin;Data Source=" & CheminOldBd & ";Persist Security Info=False"
				
				'Ouverture de la connexion
45: Call g_connData.Open(sdsn)
				
50: 'UPGRADE_WARNING: Couldn't resolve default property of object OuvrirOldConnection. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OuvrirOldConnection = True
55: Else
60: Call MsgBox("La base de donnée est introuvable!" & vbNewLine & "Vérifiez votre connexion réseau!", MsgBoxStyle.OKOnly, "Erreur")
				
65: 'UPGRADE_WARNING: Couldn't resolve default property of object OuvrirOldConnection. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OuvrirOldConnection = False
70: End If
75: Else
80: 'UPGRADE_WARNING: Couldn't resolve default property of object OuvrirOldConnection. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			OuvrirOldConnection = True
85: End If
		
		
		
	End Function
End Module