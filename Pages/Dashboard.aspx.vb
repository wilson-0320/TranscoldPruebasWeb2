Public Class Dashboard
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            MuestraErrorToast("Bienvenido: ", 2, False)
            cargarReporteRepeat()

        End If
    End Sub

    Private Sub cargarReporteRepeat()
        Dim DTOrig As DataTable = BLL.Solicitud_BLL.Busqueda("", "", "", "", "", "", "", -1, "", "Pruebas")
        repeaterPruebas.DataSource = DTOrig
        repeaterPruebas.DataBind()
    End Sub

End Class