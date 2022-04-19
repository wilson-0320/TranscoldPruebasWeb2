Public Class HistorialSolicitudes
    Inherits MiPageN
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            cargarddlUsuario()
            cargarReporteRepeat()

            iniciarControles()
        End If

    End Sub

    Private Sub iniciarControles()
        tbConsecutivo.Text = "-1"
    End Sub


    Private Sub cargarReporteRepeat()
        Dim DTOrig As DataTable = BLL.Solicitud_BLL.Busqueda(tbCodigo.Text, tbPosterior.Text, tbAnterior.Text, tbModelo.Text, tbConsecutivo.Text, tbWO.Text, tbSerie.Text, ddlLider.SelectedValue, tbObjetivos.Text, ddlEstado.SelectedValue)
        repeaterPruebas.DataSource = DTOrig
        repeaterPruebas.DataBind()
    End Sub

    Protected Sub lbtnFiltrar_Click(sender As Object, e As EventArgs)
        cargarReporteRepeat()
        MuestraErrorToast("", 0, True)
    End Sub

    Private Sub cargarddlUsuario()

        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Catalogo_Actualiza", New Object() {
                                                                    New Object() {"@Tipo", "consultarCat"},
                                                                     New Object() {"@Categoria_ID", 1}
                                                                    }, CommandType.StoredProcedure).Tables(0)

        ddlLider.DataSource = DTOrig
        ddlLider.DataValueField = "ID"
        ddlLider.DataTextField = "Descripcion"
        ddlLider.DataBind()


    End Sub
End Class