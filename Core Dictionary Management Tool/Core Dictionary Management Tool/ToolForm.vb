Imports neXt_Window_Managment_System

Public Class ToolForm

    Private drag As Window

    Private Sub ToolForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        drag = New Window(Window_Panel, Me) ' Make the panel draggable - custom form border
        drag = New Window(Form_Label, Me) ' make the label draggable - custom form border
    End Sub

    Private Sub Close_Button_Click(sender As Object, e As EventArgs) Handles Close_Button.Click
        Me.Close()
    End Sub
End Class