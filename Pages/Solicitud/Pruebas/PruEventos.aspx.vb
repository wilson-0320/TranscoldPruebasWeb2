Public Class PruEventos
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then


            Try
                inicializar()

            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub inicializar()
        tbFecha.Text = ""

    End Sub

    Private Sub msjNot()
        If Not BLL.Pru_Eventos_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Pru_Eventos_BLL.MsjError, 4, True)
        Else
            MuestraErrorToast("Realizado", 1, True)
        End If
    End Sub

    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)

        Try
            If (tbCodigo.Text.Length > 0 And tbFecha.Text.Length > 0 And ddlEnsayo.SelectedValue.Length > 0) Then
                BLL.Pru_Eventos_BLL.evento_inicio_fin(tbCodigo.Text, ddlEventos.SelectedValue, "Pruebas", "", tbFecha.Text, ddlEnsayo.SelectedValue, Session("Usuario"))
                msjNot()
                cargarRepeatPruebas()
            Else
                MuestraErrorToast("Complete los campos", 3, True)

            End If
        Catch ex As Exception

        End Try



    End Sub
    Protected Sub tbCodigo_TextChanged(sender As Object, e As EventArgs)
        cargarRepeatPruebas()
        cargarddlEnsayos("Sol")
        MuestraErrorToast("", 0, True)
    End Sub
    Private Sub cargarRepeatPruebas()
        Dim DTOrigin = BLL.Pru_Eventos_BLL.consultar_pruebas_y_eventos(tbCodigo.Text)

        repeaterPruebas.DataSource = DTOrigin
        repeaterPruebas.DataBind()
    End Sub

    Private Sub cargarddlEnsayos(ByVal tipo As String)
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Ensayo_ABCD", New Object() {
                                                                    New Object() {"@query", "consultar"},
                                                                    New Object() {"@Solicitud_Cod", tbCodigo.Text},
                                                                    New Object() {"@Tipo", tipo}
                                                                    }, CommandType.StoredProcedure).Tables(0)

        ddlEnsayo.DataSource = DTOrig
        ddlEnsayo.DataTextField = "Descripcion"
        ddlEnsayo.DataValueField = "Ensayo_ID"
        ddlEnsayo.DataBind()

    End Sub


    Protected Sub repeaterPruebas_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") Then

            BLL.Pru_Eventos_BLL.eliminar_evento_inicio_fin(e.CommandArgument, Session("Usuario").ToString)
                msjNot()

                cargarRepeatPruebas()
        End If
    End Sub
End Class