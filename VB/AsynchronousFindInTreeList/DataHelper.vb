Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports DevExpress.XtraSplashScreen

Namespace AsynchronousFindInTreeList
	Public NotInheritable Class DataHelper
		Private Shared ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=../../sampleDB.mdb"
		Private Sub New()
		End Sub
		Public Shared Sub GenegateData(ByVal recordCount As Integer, ByVal newRootRecordInterval As Integer)
			Dim conn As New OleDbConnection(ConnectionString)
			conn.Open()
			Try
				Dim cmd As OleDbCommand = conn.CreateCommand()
				For i As Integer = 1 To recordCount - 1
					Dim command As String = String.Format("INSERT INTO TESTTABLE VALUES ({0}, {1}, {2}, '{3}', '{4}')", i,If(i Mod newRootRecordInterval = 0, 0, i - 1), 0, "root_" & i, "root_i_" & i)
					cmd.CommandText = command
					cmd.ExecuteNonQuery()
				Next i
				conn.Close()
			Finally
				conn.Close()
			End Try
		End Sub
		Public Shared Function GetDataTable() As DataTable
			Dim query As String = "Select * from TESTTABLE"
			Dim dt As New DataTable("TESTTABLE")
			Using cnn = New OleDbConnection(ConnectionString)
				cnn.Open()
				Using da = New OleDbDataAdapter()
					da.SelectCommand = New OleDbCommand(query, cnn)
					da.Fill(dt)
				End Using
			End Using
			Return dt
		End Function
	End Class
End Namespace
