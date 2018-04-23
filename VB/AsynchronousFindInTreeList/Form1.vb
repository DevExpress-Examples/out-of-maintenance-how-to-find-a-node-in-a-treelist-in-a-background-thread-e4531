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
	Partial Public Class Form1
		Inherits Form
		Private helper As AsyncSearchHelper
		Public Sub New()
			InitializeComponent()
			helper = New AsyncSearchHelper(treeList1)
			AddHandler helper.AsyncOperationIsComplete, AddressOf helper_AsyncOperationIsComplete
		End Sub

		Private Sub helper_AsyncOperationIsComplete(ByVal sender As Object, ByVal e As EventArgs)
			If SplashScreenManager.Default IsNot Nothing Then
				SplashScreenManager.CloseForm()
			End If
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim dt As DataTable = DataHelper.GetDataTable()
			If dt.Rows.Count = 0 Then
				Dim result As DialogResult = MessageBox.Show("Would you like to generate data?", "DataTable is empty", MessageBoxButtons.YesNo)
				If result = System.Windows.Forms.DialogResult.Yes Then
					SplashScreenManager.ShowForm(GetType(SplashScreen1))
					'DataHelper.GenegateData(records_count, interval_for_new_root_node);
					DataHelper.GenegateData(5000, 20)
					CustomizeTreeListFields()
					treeList1.DataSource = DataHelper.GetDataTable()
					SplashScreenManager.CloseForm()
				Else
					MessageBox.Show("DataTable is empty")
				End If
			Else
				CustomizeTreeListFields()
				treeList1.DataSource = dt
			End If
		End Sub
		Private Sub CustomizeTreeListFields()
			treeList1.KeyFieldName = "ID"
			treeList1.ParentFieldName = "PARENTID"
			treeList1.ImageIndexFieldName = "IMAGEINDEX"
		End Sub

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			SplashScreenManager.ShowForm(GetType(WaitForm1))
			helper.AsyncSearch(DataHelper.GetDataTable(), textEdit1.Text)
		End Sub
	End Class
End Namespace
