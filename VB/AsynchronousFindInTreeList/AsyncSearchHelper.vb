Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms

Namespace AsynchronousFindInTreeList
	Public Class AsyncSearchHelper
		Public Event AsyncOperationIsComplete As EventHandler
		Private _treeList As TreeList
		Private bgwTextFinder As BackgroundWorker
		Private Shared FindText As String

		Public Sub New(ByVal treeList As TreeList)
			_treeList = treeList
			InitializeBackgroundWorker()
		End Sub
		Public Sub AsyncSearch(ByVal table As DataTable, ByVal text As String)
			Dim h As New SearchHelper() With {.Table = table, .FindText = text, .KeyFieldName = _treeList.KeyFieldName, .ParentFieldName = _treeList.ParentFieldName}
			_treeList.Enabled = False
			bgwTextFinder.RunWorkerAsync(h)
		End Sub
		Private Sub InitializeBackgroundWorker()
			bgwTextFinder = New BackgroundWorker()
			AddHandler bgwTextFinder.DoWork, AddressOf bgwTextFinder_DoWork
			AddHandler bgwTextFinder.RunWorkerCompleted, AddressOf bgwTextFinder_RunWorkerCompleted
			bgwTextFinder.WorkerReportsProgress = True
		End Sub
		Private Sub bgwTextFinder_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
			Dim helper As SearchHelper = TryCast(e.Argument, SearchHelper)
			Dim searchResult As List(Of Integer) = SearchInDataSet(helper.Table, helper.KeyFieldName, helper.ParentFieldName, helper.FindText)
			e.Result = searchResult
		End Sub
		Private Sub bgwTextFinder_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
			Dim res As List(Of Integer) = TryCast(e.Result, List(Of Integer))
			If res Is Nothing Then
				Return
			End If
			Dim iterator As New ExpandingToSpecificNode(res)
			CType(New Thread(New ThreadStart(Function() AnonymousMethod1(iterator, iterator))), Thread).Start()
		End Sub
		
        Private Function AnonymousMethod1(ByVal iterator As ExpandingToSpecificNode, ByVal _iterator As ExpandingToSpecificNode) As Boolean
            _treeList.BeginUpdate()
            Try
                _treeList.NodesIterator.DoOperation(iterator)
            Finally
                _treeList.Invoke(New MethodInvoker(Function() AnonymousMethod2(_iterator)))
            End Try
            Return True
        End Function
		
		Private Function AnonymousMethod2(ByVal iterator As ExpandingToSpecificNode) As Boolean
			_treeList.EndUpdate()
			_treeList.Enabled = True
			Me.RaiseAsyncOperationIsComplete()
			iterator.SelectedNode.Selected = True
			Return True
		End Function
		Private Function SearchInDataSet(ByVal table As DataTable, ByVal keyFieldName As String, ByVal parentFieldName As String, ByVal findText As String) As List(Of Integer)
			If table Is Nothing OrElse keyFieldName Is Nothing OrElse parentFieldName Is Nothing OrElse findText Is Nothing Then
				Return Nothing
			End If
			AsyncSearchHelper.FindText = findText
			Dim result As New List(Of Integer)()
			Dim foundRow As DataRow = table.AsEnumerable().ToList().Find(AddressOf FindRow)
			If foundRow IsNot Nothing Then
				Dim id As Integer = Convert.ToInt32(foundRow.Field(Of Double)(keyFieldName))
				Do While id <> 0
					result.Add(id)
					Dim query As IEnumerable(Of DataRow) = _
						From product In table.AsEnumerable() _
						Where product.Field(Of Double)(keyFieldName) = id _
						Select product
					id = Convert.ToInt32(query.ToArray()(0).Field(Of Double)(parentFieldName))
				Loop
			Else
				Console.WriteLine("Nothing was found...")
				Return Nothing
			End If
			result.Sort()
			Return result
		End Function

		Private Shared Function FindRow(ByVal row As DataRow) As Boolean
			Dim colNames As New List(Of String)()
			For Each item In row.ItemArray
				If item.ToString().Equals(FindText) Then
					Return True
				End If
			Next item
			Return False
		End Function
		Private Sub RaiseAsyncOperationIsComplete()
			RaiseEvent AsyncOperationIsComplete(Me, New EventArgs())
		End Sub
	End Class
End Namespace