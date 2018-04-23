Imports Microsoft.VisualBasic
Imports System
Namespace AsynchronousFindInTreeList
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim splashScreenManager1 As New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.AsynchronousFindInTreeList.SplashScreen1), True, True)
			Me.treeList1 = New DevExpress.XtraTreeList.TreeList()
			Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
			Me.textEdit1 = New DevExpress.XtraEditors.TextEdit()
			Me.sampleDBDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
			Me.testTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.textEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.sampleDBDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.testTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' treeList1
			' 
			Me.treeList1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.treeList1.Location = New System.Drawing.Point(12, 12)
			Me.treeList1.Name = "treeList1"
			Me.treeList1.Size = New System.Drawing.Size(530, 340)
			Me.treeList1.TabIndex = 0
			' 
			' simpleButton1
			' 
			Me.simpleButton1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.simpleButton1.Location = New System.Drawing.Point(118, 358)
			Me.simpleButton1.Name = "simpleButton1"
			Me.simpleButton1.Size = New System.Drawing.Size(116, 23)
			Me.simpleButton1.TabIndex = 1
			Me.simpleButton1.Text = "Find asynchronyosly"
'			Me.simpleButton1.Click += New System.EventHandler(Me.simpleButton1_Click);
			' 
			' textEdit1
			' 
			Me.textEdit1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.textEdit1.Location = New System.Drawing.Point(12, 361)
			Me.textEdit1.Name = "textEdit1"
			Me.textEdit1.Size = New System.Drawing.Size(100, 20)
			Me.textEdit1.TabIndex = 2
			' 
			' testTableBindingSource
			' 
			Me.testTableBindingSource.DataMember = "TestTable"
			Me.testTableBindingSource.DataSource = Me.sampleDBDataSetBindingSource
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(554, 393)
			Me.Controls.Add(Me.textEdit1)
			Me.Controls.Add(Me.simpleButton1)
			Me.Controls.Add(Me.treeList1)
			Me.Name = "Form1"
			Me.Text = "Async search in TreeList"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.textEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.sampleDBDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		   ' ((System.ComponentModel.ISupportInitialize)(this.testTableBindingSource)).EndInit();
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private treeList1 As DevExpress.XtraTreeList.TreeList
		Private WithEvents simpleButton1 As DevExpress.XtraEditors.SimpleButton
		Private textEdit1 As DevExpress.XtraEditors.TextEdit
		Private sampleDBDataSetBindingSource As System.Windows.Forms.BindingSource
		Private testTableBindingSource As System.Windows.Forms.BindingSource
	End Class
End Namespace

