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
Imports DevExpress.XtraTreeList.Nodes.Operations

Namespace AsynchronousFindInTreeList
	Public Class ExpandingToSpecificNode
		Inherits TreeListOperation
		Private _idsToExpand As List(Of Integer)
		Private currentNodeIndexInList As Integer
		Private needsVisitChildren_Renamed As Boolean
		Private privateSelectedNode As TreeListNode
		Public Property SelectedNode() As TreeListNode
			Get
				Return privateSelectedNode
			End Get
			Set(ByVal value As TreeListNode)
				privateSelectedNode = value
			End Set
		End Property
		Public Sub New(ByVal idsToExpand As List(Of Integer))
			MyBase.New()
				needsVisitChildren_Renamed = True
			currentNodeIndexInList = 0
			SelectedNode = Nothing
			_idsToExpand = idsToExpand
		End Sub
		Public Overrides Sub Execute(ByVal node As TreeListNode)
			If currentNodeIndexInList > _idsToExpand.Count - 1 Then
				Return
			End If
			Dim idColumnValue As Integer = Convert.ToInt32(node.GetValue("ID"))
			If idColumnValue = _idsToExpand(currentNodeIndexInList) Then
				node.Expanded = True
				currentNodeIndexInList += 1
				If currentNodeIndexInList >= _idsToExpand.Count Then
					SelectedNode = node
					needsVisitChildren_Renamed = False
				End If
			End If
		End Sub
		Public Overrides Function NeedsVisitChildren(ByVal node As TreeListNode) As Boolean
			Return True
		End Function
		Public Overrides ReadOnly Property NeedsFullIteration() As Boolean
			Get
				Return needsVisitChildren_Renamed
			End Get
		End Property
	End Class
End Namespace
