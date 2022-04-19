Public Class Dashboard
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            MuestraErrorToast("Bienvenido: ", 2, False)
        End If
    End Sub

End Class