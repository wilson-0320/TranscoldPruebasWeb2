Public Class RepSolicitud
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Request.QueryString("Codigo") Is Nothing Then
                tbCodigo.Text = Request.QueryString("Codigo")
                ' cargarRepeatReporte()
            End If
        End If
    End Sub

    Protected Sub tbCodigo_TextChanged(sender As Object, e As EventArgs)
        cargarRepeatReporte()
        Dim key As String = Guid.NewGuid.ToString
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), key, "agruparTabla()", True)
    End Sub

    Public Sub cargarRepeatReporte()
        Try
            Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Reporte", New Object() {
                                                                    New Object() {"@Reporte", "Solicitud1"},
                                                                    New Object() {"@Codigo", tbCodigo.Text}
                                                                    }, CommandType.StoredProcedure).Tables(0)


            repeaterPruebas.DataSource = DTOrig
            repeaterPruebas.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnFiltrar_Click(sender As Object, e As EventArgs)
        cargarRepeatReporte()
        Dim key As String = Guid.NewGuid.ToString
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), key, "agruparTabla();", True)

    End Sub


End Class