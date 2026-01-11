Imports neXt_Window_Managment_System

Public Class ToolForm

    Private drag As Window ' Create variable to hold instance of neXt Window class

    Private Sub ToolForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        drag = New Window(Me) ' Create new instance of the neXt Window class
        drag.AddControl(Window_Panel) ' Add the panel that will act as the title bar
        drag.AddControl(Form_Label) ' Add the label that will also act as the title bar
    End Sub

    Private Sub Maximize_Button_Click(sender As Object, e As EventArgs) Handles Maximize_Button.Click
        If drag._isMaxed Then
            drag.OriginalSize()
        Else
            drag.MaximizeFull()
        End If
    End Sub

    Private Sub Close_Button_Click(sender As Object, e As EventArgs) Handles Close_Button.Click
        Me.Close()
    End Sub

    Private Sub Minimize_Button_Click(sender As Object, e As EventArgs) Handles Minimize_Button.Click
        WindowState = FormWindowState.Minimized
    End Sub
End Class