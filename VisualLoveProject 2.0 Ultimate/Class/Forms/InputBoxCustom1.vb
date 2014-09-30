Public Class InputBoxCustom1

    Dim Text1 As String = ""
    Dim Title1 As String = ""
    Dim DefaultResponse As String = ""
    Public Respose As Boolean = False

    Private Sub InputBoxCustom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSetting()
    End Sub

    Private Sub LoadSetting()
        Me.Lb_Text.Text = Text1
        Me.Text = Title1
        Me.TB_Text.Text = DefaultResponse
    End Sub

    Public Function IntputBox(ByVal Text As String, ByVal Title As String, ByVal DefaultRespose As String)
        Text1 = Text
        Title1 = Title
        DefaultResponse = DefaultRespose
        Me.ShowDialog()
    End Function

    Private Sub Bt_Accept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Accept.Click
        Respose = True
        Me.Close()
    End Sub

    Private Sub Bt_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cancel.Click
        Respose = False
        Me.Close()
    End Sub

    Private Sub TB_Text_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_Text.KeyDown

        If e.KeyCode = Keys.Enter Then
            Respose = True
            Me.Close()
        End If

    End Sub

End Class