Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Core_Dictionary_Module
Imports neXt_Window_Managment_System

Public Class ToolForm
    Private _currentSelectedPath As String = ""
    Dim xela As New Main()
    Private drag As neXt_Window_Managment_System.Window ' Create variable to hold instance of neXt Window class

    Private Sub ToolForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        drag = New neXt_Window_Managment_System.Window(Me) ' Create new instance of the neXt Window class
        drag.AddControl(Window_Panel) ' Add the panel that will act as the title bar
        drag.AddControl(Form_Label) ' Add the label that will also act as the title bar

        xela.AutoTree(File_Tree, Main.ObjectLevel.Root)
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

    Private Sub File_Tree_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles File_Tree.NodeMouseDoubleClick
        If e.Node.Tag IsNot Nothing Then
            LoadTree(e.Node.Tag.ToString())
        End If
    End Sub

    Private Sub GetDataContent_Button_Click(sender As Object, e As EventArgs) Handles GetDataContent_Button.Click
        If File_Tree.SelectedNode IsNot Nothing AndAlso File_Tree.SelectedNode.Tag IsNot Nothing Then
            LoadTree(File_Tree.SelectedNode.Tag.ToString())
        Else
            MessageBox.Show("Please select an object first.")
        End If
    End Sub

    Private Sub LoadTree(filePath As String)
        _currentSelectedPath = filePath
        If File.Exists(filePath) Then
            Dim info As New FileInfo(filePath)

            Object_Label.Text = info.Name
            SizeInfo_Label.Text = "Size - " & info.Length.ToString("N0") & " Bytes"
            Date_Label.Text = info.LastWriteTime.ToString("dd.MM.yyyy - HH:mm:ss")

            Dim content As Object = Nothing

            If filePath.EndsWith(".word") Then
                content = xela.MRead_String(filePath)
                Type_Label.Text = "Content Type - String"
            ElseIf filePath.EndsWith(".val") Then
                content = xela.MRead_Integer(filePath)
                Type_Label.Text = "Content Type - Value"
            ElseIf filePath.EndsWith(".sta") Then
                content = xela.MRead_Boolean(filePath)
                Type_Label.Text = "Content Type - Boolean"
            End If

            If content IsNot Nothing Then
                Content_Box.Text = content.ToString()
            Else
                Content_Box.Text = String.Empty
            End If

        ElseIf Directory.Exists(filePath) Then
            Dim info As New DirectoryInfo(filePath)
            Dim sizeInKB As Double = DirectorySize(filePath)

            Object_Label.Text = Path.GetFileName(filePath.TrimEnd("\"c))
            SizeInfo_Label.Text = "Size - " & sizeInKB.ToString("N2") & " KB"
            Date_Label.Text = info.LastWriteTime.ToString("dd.MM.yyyy - HH:mm:ss")
            Type_Label.Text = "Content Type - Directory"
            Content_Box.Text = String.Empty
        End If
    End Sub

    Private Function DirectorySize(path As String) As Double
        Try
            Dim dirInfo As New DirectoryInfo(path)
            Dim files = dirInfo.GetFiles("*.*", SearchOption.AllDirectories)
            Dim totalBytes As Long = files.Sum(Function(f) f.Length)
            Return totalBytes / 1024
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class