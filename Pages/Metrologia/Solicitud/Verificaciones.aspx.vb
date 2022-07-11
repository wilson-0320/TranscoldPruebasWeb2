Public Class Verificaciones
    Inherits MiPageN
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            chargeListCatalogosMetrologia()
            chargeListInstrumentos()
            chargeListMagnitud()
            inicializar()
            cargarResumenVerificaciones("consultarfiltro", -1)
            Try

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub inicializar()

        tbP1.Text = ""
        tbP2.Text = ""
        tbP3.Text = ""
        tbP4.Text = ""
        tbComentarios.Text = ""
        hfID.Value = "-1"
        tbCodigo.Text = ""
        hfQuery.Value = "Insertar"
        lbtnCancelar.Visible = False
        lbtnGuardar.Enabled = Roles("Administrador,JefeLab,JefeRefri,SupMet,SupLab", 1)

    End Sub

    Private Sub controlesRepeater()
        Dim mod1 As Boolean = Roles("Administrador,JefeLab,JefeRefri,SupMet,SupLab", 2)
        Dim eli1 As Boolean = Roles("Administrador,JefeLab,JefeRefri,SupMet,SupLab", 3)

        For index As Integer = 0 To RepeaterTabla.Items.Count - 1 Step 1

            CType(RepeaterTabla.Items(index).FindControl("lbtnEliminarRepeat"), LinkButton).Visible = eli1
            'Eliminar
            CType(RepeaterTabla.Items(index).FindControl("lbtnModificarRepeat"), LinkButton).Visible = mod1
        Next


    End Sub

    Private Sub msjNot()
        If Not BLL.Solicitud_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Solicitud_BLL.MsjError, 4, True)
        Else
            MuestraErrorToast("Se completo la operacion.", 1, True)
        End If
    End Sub

    Private Function validar() As Boolean

        For Each CampoTexto As TextBox In New TextBox() {
            tbCodigo, tbComentarios, tbP1, tbP2, tbP3, tbP4
            }

            If CampoTexto.Text = "" Then
                MuestraErrorToast("Debe especificar el valor del campo enfocado " + CampoTexto.ToolTip, 3, True)
                CampoTexto.Focus()

                Return False
            End If


        Next
        Return True

    End Function

    Private Sub cargarResumenVerificaciones(ByVal query As String, ByVal ID As Int32)

        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Verificacion_Solicitud_ABCD", New Object() {
                                                                   New Object() {"@query", query},
                                                                    New Object() {"@Codigo", tbCodigoFiltro.Text},
                                                                    New Object() {"@ID_Ubicacion", ddlCamaraFiltro.SelectedValue},
                                                                     New Object() {"@ID_Magnitud", ddlMagnitudFiltro.SelectedValue},
                                                                    New Object() {"@ID", ID}
                                                                     }, CommandType.StoredProcedure).Tables(0)



        If (query.Equals("consultar_por_id")) Then
            hfID.Value = DTOrig.Rows(0).Item(0)
            tbCodigo.Text = DTOrig.Rows(0).Item(1)
            ddlEstacionCamara.SelectedValue = DTOrig.Rows(0).Item(2)
            ddlInstrumentos.SelectedValue = DTOrig.Rows(0).Item(3)
            tbP1.Text = DTOrig.Rows(0).Item(4).ToString().Replace(".", ",")
            tbP2.Text = DTOrig.Rows(0).Item(5).ToString().Replace(".", ",")
            tbP3.Text = DTOrig.Rows(0).Item(6).ToString().Replace(".", ",")
            tbP4.Text = DTOrig.Rows(0).Item(7).ToString().Replace(".", ",")
            tbComentarios.Text = DTOrig.Rows(0).Item(8).ToString.TrimEnd
            ddlTipoEntrada.SelectedValue = DTOrig.Rows(0).Item(9).ToString().TrimEnd

            lbtnGuardar.Enabled = Roles("Administrador,JefeLab,JefeRefri,SupLab,SupMet", 1)



            Else
            RepeaterTabla.DataSource = DTOrig
            RepeaterTabla.DataBind()
            controlesRepeater()
        End If


    End Sub

    Private Sub chargeListCatalogosMetrologia()

        Dim DTOrig As DataTable = BLL.Met_Catalogo_BLL.consultar_por_tipo("Asignaciones Físicas")



        ddlEstacionCamara.DataSource = DTOrig
        ddlEstacionCamara.DataTextField = "valor"
        ddlEstacionCamara.DataValueField = "id"
        ddlEstacionCamara.DataBind()

        ddlCamaraFiltro.DataSource = DTOrig
        ddlCamaraFiltro.DataTextField = "valor"
        ddlCamaraFiltro.DataValueField = "id"
        ddlCamaraFiltro.DataBind()

    End Sub

    Private Sub chargeListMagnitud()


        Dim DTOrig As DataTable = BLL.Met_Magnitud_BLL.consultar()


        ddlTipoEntrada.DataSource = DTOrig
        ddlTipoEntrada.DataTextField = "magnitud"
        ddlTipoEntrada.DataValueField = "id"
        ddlTipoEntrada.DataBind()

        ddlMagnitudFiltro.DataSource = DTOrig
        ddlMagnitudFiltro.DataTextField = "magnitud"
        ddlMagnitudFiltro.DataValueField = "id"
        ddlMagnitudFiltro.DataBind()
    End Sub

    Private Sub chargeListInstrumentos()


        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Met_Instrumento_ABCD", New Object() {
                                                                   New Object() {"@query", "listado"},
                                                                   New Object() {"@con_vacio", 0}
                                                                   }, CommandType.StoredProcedure).Tables(0)


        ddlInstrumentos.DataSource = DTOrig
        ddlInstrumentos.DataTextField = "instrumento"
        ddlInstrumentos.DataValueField = "id"
        ddlInstrumentos.DataBind()
    End Sub


    Protected Sub btnGenerar_Click(sender As Object, e As EventArgs)
        cargarResumenVerificaciones("consultarfiltro", -1)
        MuestraErrorToast("Campos inicializados", 0, True)
    End Sub

    Protected Sub lbtnCancelar_Click(sender As Object, e As EventArgs)
        inicializar()
        MuestraErrorToast("Campos inicializados", 0, True)
    End Sub

    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        Try


            If (validar()) Then

                BLL.Pru_Verificacion_Solicitud_BLL.crud(hfQuery.Value, Int32.Parse(hfID.Value), ddlEstacionCamara.SelectedValue, ddlInstrumentos.SelectedValue, tbCodigo.Text,
    tbComentarios.Text, Session("Usuario").ToString, ddlTipoEntrada.SelectedValue, tbP1.Text, tbP2.Text, tbP3.Text, tbP4.Text)

                msjNot()


                tbCodigoFiltro.Text = tbCodigo.Text
                cargarResumenVerificaciones("consultarfiltro", -1)
                inicializar()

            End If
        Catch ex As Exception
            MuestraErrorToast(ex.Message, 1, True)
        End Try

    End Sub



    Protected Sub RepeaterTabla_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Edi") Then

            lbtnGuardar.Visible = True
            hfQuery.Value = "Modificar"
            lbtnCancelar.Visible = True
            tbComentarios.Focus()
            hfID.Value = e.CommandArgument

            cargarResumenVerificaciones("consultar_por_id", Int32.Parse(e.CommandArgument))
            MuestraErrorToast("Realizado", 0, True)

        ElseIf e.CommandName = "Eli" Then
            BLL.Pru_Verificacion_Solicitud_BLL.eliminar(Int32.Parse(e.CommandArgument))
            cargarResumenVerificaciones("consultarfiltro", -1)
            msjNot()
        End If


    End Sub
End Class