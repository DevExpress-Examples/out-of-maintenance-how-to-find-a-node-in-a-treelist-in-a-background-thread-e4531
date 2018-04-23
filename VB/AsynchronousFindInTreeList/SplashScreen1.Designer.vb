Imports Microsoft.VisualBasic
Imports System
Namespace AsynchronousFindInTreeList
	Partial Public Class SplashScreen1
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen1))
			Me.marqueeProgressBarControl1 = New DevExpress.XtraEditors.MarqueeProgressBarControl()
			Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
			Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
			Me.pictureEdit2 = New DevExpress.XtraEditors.PictureEdit()
			Me.pictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
			CType(Me.marqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.pictureEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.pictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' marqueeProgressBarControl1
			' 
			Me.marqueeProgressBarControl1.EditValue = 0
			Me.marqueeProgressBarControl1.Location = New System.Drawing.Point(23, 231)
			Me.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1"
			Me.marqueeProgressBarControl1.Size = New System.Drawing.Size(404, 12)
			Me.marqueeProgressBarControl1.TabIndex = 5
			' 
			' labelControl1
			' 
			Me.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
			Me.labelControl1.Location = New System.Drawing.Point(23, 286)
			Me.labelControl1.Name = "labelControl1"
			Me.labelControl1.Size = New System.Drawing.Size(115, 13)
			Me.labelControl1.TabIndex = 6
			Me.labelControl1.Text = "Copyright © 1998-2011"
			' 
			' labelControl2
			' 
			Me.labelControl2.Location = New System.Drawing.Point(23, 206)
			Me.labelControl2.Name = "labelControl2"
			Me.labelControl2.Size = New System.Drawing.Size(50, 13)
			Me.labelControl2.TabIndex = 7
			Me.labelControl2.Text = "Starting..."
			' 
			' pictureEdit2
			' 
			Me.pictureEdit2.EditValue = (CObj(resources.GetObject("pictureEdit2.EditValue")))
			Me.pictureEdit2.Location = New System.Drawing.Point(12, 12)
			Me.pictureEdit2.Name = "pictureEdit2"
			Me.pictureEdit2.Properties.AllowFocused = False
			Me.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
			Me.pictureEdit2.Properties.Appearance.Options.UseBackColor = True
			Me.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
			Me.pictureEdit2.Properties.ShowMenu = False
			Me.pictureEdit2.Size = New System.Drawing.Size(426, 180)
			Me.pictureEdit2.TabIndex = 9
			' 
			' pictureEdit1
			' 
			Me.pictureEdit1.EditValue = (CObj(resources.GetObject("pictureEdit1.EditValue")))
			Me.pictureEdit1.Location = New System.Drawing.Point(278, 268)
			Me.pictureEdit1.Name = "pictureEdit1"
			Me.pictureEdit1.Properties.AllowFocused = False
			Me.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
			Me.pictureEdit1.Properties.Appearance.Options.UseBackColor = True
			Me.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
			Me.pictureEdit1.Properties.ShowMenu = False
			Me.pictureEdit1.Size = New System.Drawing.Size(155, 48)
			Me.pictureEdit1.TabIndex = 8
			' 
			' SplashScreen
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(450, 320)
			Me.Controls.Add(Me.pictureEdit2)
			Me.Controls.Add(Me.pictureEdit1)
			Me.Controls.Add(Me.labelControl2)
			Me.Controls.Add(Me.labelControl1)
			Me.Controls.Add(Me.marqueeProgressBarControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.marqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.pictureEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.pictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()
		End Sub

		#End Region

		Private marqueeProgressBarControl1 As DevExpress.XtraEditors.MarqueeProgressBarControl
		Private labelControl1 As DevExpress.XtraEditors.LabelControl
		Private labelControl2 As DevExpress.XtraEditors.LabelControl
		Private pictureEdit1 As DevExpress.XtraEditors.PictureEdit
		Private pictureEdit2 As DevExpress.XtraEditors.PictureEdit
	End Class
End Namespace
