Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraSplashScreen

Namespace AsynchronousFindInTreeList
	Partial Public Class SplashScreen1
		Inherits SplashScreen
		Public Sub New()
			InitializeComponent()
		End Sub

		#Region "Overrides"

		Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
			MyBase.ProcessCommand(cmd, arg)
		End Sub

		#End Region

        'Public Enum SplashScreenCommand
        'End Enum
	End Class
End Namespace