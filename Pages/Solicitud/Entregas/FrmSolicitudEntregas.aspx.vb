Public Class FrmSolicitudEntregas
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            cargarReporteEntregas()
            cargarddlEntregas()


        End If
    End Sub

    Private Sub cargarReporteEntregas()
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Entrega_sp", New Object() {
                                                                 New Object() {"@query", "consultar_reporte_temp"}
                                                             }, CommandType.StoredProcedure).Tables(0)
        repeaterReporte.DataSource = DTOrig
        repeaterReporte.DataBind()
    End Sub

    Private Sub cargarddlEntregas()
        Dim DTOrigin As DataTable = BLL.Pru_Entrega_BLL.consultar()
        ddlEntregas.DataSource = DTOrigin
        ddlEntregas.DataTextField = "Entrega"
        ddlEntregas.DataValueField = "id"
        ddlEntregas.DataBind()
    End Sub

    Protected Sub lbtnSiguiente_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub repeaterReporte_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Subir") Then

            Dim key As String = Guid.NewGuid.ToString
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), key, "abrir()", True)
            MuestraErrorToast("Listo", 0, True)
        End If
    End Sub



End Class