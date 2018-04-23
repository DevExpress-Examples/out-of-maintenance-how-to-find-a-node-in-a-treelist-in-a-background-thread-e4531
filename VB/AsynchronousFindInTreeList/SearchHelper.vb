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
	Public Class SearchHelper
		Private privateTable As DataTable
		Public Property Table() As DataTable
			Get
				Return privateTable
			End Get
			Set(ByVal value As DataTable)
				privateTable = value
			End Set
		End Property
		Private privateKeyFieldName As String
		Public Property KeyFieldName() As String
			Get
				Return privateKeyFieldName
			End Get
			Set(ByVal value As String)
				privateKeyFieldName = value
			End Set
		End Property
		Private privateParentFieldName As String
		Public Property ParentFieldName() As String
			Get
				Return privateParentFieldName
			End Get
			Set(ByVal value As String)
				privateParentFieldName = value
			End Set
		End Property
		Private privateFindText As String
		Public Property FindText() As String
			Get
				Return privateFindText
			End Get
			Set(ByVal value As String)
				privateFindText = value
			End Set
		End Property
	End Class
End Namespace
