Public Class checkList
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            iniciarlizar()
            Try
            Catch ex As Exception

            End Try


        End If
    End Sub


    Private Sub iniciarlizar()

        hfQuery.Value = "insertar"
        hfID.Value = "-1"
        tbCliente.Text = ""
        tbCodigo.Text = ""
        tbPais.Text = ""
        tbSolicitado.Text = ""
        tbWorkOrder.Text = ""
        tbSerie.Text = ""
        tbModelo.Text = ""
        tbParrillas.Text = "0"
        tbClips.Text = "0"
        tbLamparas.Text = "0"
        tbComentarios.Text = ""
        tbRayones.Text = ""
        tbGolpes.Text = ""
        '/**Editar aca *//
        Try
             lblUser.Text = Session("Usuario")
        Catch ex As Exception

        End Try

        tbDespachos.Text = ""
        cbRotulo.Checked = False
        cbCubremotor.Checked = False
        cbCertificado.Checked = False
        cbEtiquetaSerie.Checked = False
        cbCalcomania.Checked = False
        cbManOpe.Checked = False
        cbManIns.Checked = False
        cbDiagrama.Checked = False
        cbFuncionamiento.Checked = False
        cbParrillasTraseras.Checked = False
        cbHalador.Checked = False
        lbtnCancelar.Visible = False
        lbtnGuardar.Enabled = True
    End Sub

    Private Sub llenarReportRecepcion()
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Recepcion_ABCD", New Object() {
                                                                 New Object() {"@query", "consultar_por_codigo"},
                                                                 New Object() {"@ID", 0},
                                                                 New Object() {"@tipo", 0},
                                                                  New Object() {"@codigo", tbCodigoFiltro.Text},
                                                                   New Object() {"@modelo", tbModeloFiltro.Text}
                                                                }, CommandType.StoredProcedure).Tables(0)

        RepeaterRecepcion.DataSource = DTOrig

        RepeaterRecepcion.DataBind()
    End Sub
    Private Sub llenarCrud(ByVal ID As Integer)
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Recepcion_ABCD", New Object() {
                                                                New Object() {"@query", "consultar_por_id"},
                                                                New Object() {"@ID", ID}
                                                                }, CommandType.StoredProcedure).Tables(0)
        hfQuery.Value = "actualizar"
        hfID.Value = DTOrig.Rows(0).Item(0)
        tbCliente.Text = DTOrig.Rows(0).Item(1)
        tbCodigo.Text = DTOrig.Rows(0).Item(2)
        tbPais.Text = DTOrig.Rows(0).Item(3)
        tbSolicitado.Text = DTOrig.Rows(0).Item(4)
        tbWorkOrder.Text = DTOrig.Rows(0).Item(5)
        tbSerie.Text = DTOrig.Rows(0).Item(6)
        tbModelo.Text = DTOrig.Rows(0).Item(7)
        tbParrillas.Text = DTOrig.Rows(0).Item(8)
        tbClips.Text = DTOrig.Rows(0).Item(9)
        tbLamparas.Text = DTOrig.Rows(0).Item(10)
        tbComentarios.Text = DTOrig.Rows(0).Item(11)
        dplTipo.SelectedValue = DTOrig.Rows(0).Item(12)
        tbRayones.Text = DTOrig.Rows(0).Item(13)
        tbGolpes.Text = DTOrig.Rows(0).Item(14)
        lblUser.Text = DTOrig.Rows(0).Item(15).ToString.TrimEnd
        tbDespachos.Text = DTOrig.Rows(0).Item(16)
        cbRotulo.Checked = DTOrig.Rows(0).Item(18)
        cbCubremotor.Checked = DTOrig.Rows(0).Item(19)
        cbCertificado.Checked = DTOrig.Rows(0).Item(20)
        cbEtiquetaSerie.Checked = DTOrig.Rows(0).Item(21)
        cbCalcomania.Checked = DTOrig.Rows(0).Item(22)
        cbManOpe.Checked = DTOrig.Rows(0).Item(23)
        cbManIns.Checked = DTOrig.Rows(0).Item(24)
        cbDiagrama.Checked = DTOrig.Rows(0).Item(25)
        cbFuncionamiento.Checked = DTOrig.Rows(0).Item(26)
        cbParrillasTraseras.Checked = DTOrig.Rows(0).Item(27)
        cbHalador.Checked = DTOrig.Rows(0).Item(28)

        If (User.Identity.Name.Equals(lblUser.Text)) Then
            lbtnGuardar.Enabled = True
        Else
            lbtnGuardar.Enabled = False
            '   llamarFuncionesJavascript("No podras realizar modificaciones, tu no has creado el registro.", "Error")
        End If



    End Sub
    Protected Sub btnGenerar_Click(sender As Object, e As EventArgs)
        If (tbCodigoFiltro.Text.Length > 0 Or tbModeloFiltro.Text.Length > 0) Then
            llenarReportRecepcion()
            '  llamarFuncionesJavascript("Consulta finalizada.", "Satisfactorio")
        End If

    End Sub

    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        If (tbCliente.Text.Length > 0 And tbPais.Text.Length > 0 And tbSolicitado.Text.Length > 0 And tbWorkOrder.Text.Length > 0 And
tbSerie.Text.Length > 0 And tbModelo.Text.Length > 0 And tbCodigo.Text.Length > 0) Then
            Dim mensaje As String = BLL.Recepcion_BLL.insertar(hfQuery.Value, dplTipo.SelectedValue, hfID.Value, tbCliente.Text, tbPais.Text, tbSolicitado.Text, tbWorkOrder.Text,
tbSerie.Text, tbModelo.Text, tbCodigo.Text, tbParrillas.Text, tbClips.Text, tbLamparas.Text, cbRotulo.Checked, cbCubremotor.Checked,
cbCertificado.Checked, cbEtiquetaSerie.Checked, cbManOpe.Checked, cbManIns.Checked, cbCalcomania.Checked, cbDiagrama.Checked,
cbFuncionamiento.Checked, cbParrillasTraseras.Checked, cbHalador.Checked, tbGolpes.Text, tbRayones.Text, tbComentarios.Text, lblUser.Text, tbDespachos.Text)

            tbCodigoFiltro.Text = tbCodigo.Text
            llenarReportRecepcion()

            If mensaje.StartsWith("Error:") Then

                '    llamarFuncionesJavascript("" + mensaje + "", "Error")

            Else
                iniciarlizar()
                '    llamarFuncionesJavascript("Se realizo el cambio", "Satisfactorio")

            End If
        Else
            'llamarFuncionesJavascript("Debes llenar los campos requeridos.", "Error")

        End If

    End Sub

    Protected Sub lbtnCancelar_Click(sender As Object, e As EventArgs)
        iniciarlizar()
    End Sub

    Protected Sub RepeaterRecepcion_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "ModificarRecepcion") Then


            llenarCrud(Integer.Parse(e.CommandArgument))

            lbtnCancelar.Visible = True

        ElseIf e.CommandName = "EliminarRecepcion" Then
            Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Recepcion_ABCD", New Object() {
                                                                New Object() {"@query", "eliminar"},
                                                                New Object() {"@ID", Integer.Parse(e.CommandArgument)}
                                                                        }, CommandType.StoredProcedure).Tables(0)
            iniciarlizar()
            llenarReportRecepcion()

        End If
    End Sub
End Class