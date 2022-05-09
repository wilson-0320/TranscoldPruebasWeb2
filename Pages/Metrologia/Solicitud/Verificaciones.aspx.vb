Public Class Verificaciones
    Inherits MiPageN
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            chargeListCatalogos(12)
            chargeListInstrumentos()
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
        tbP5.Text = ""
        tbP6.Text = ""
        tbP7.Text = ""
        tbP8.Text = ""
        tbP9.Text = ""
        tbComentarios.Text = ""
        hfID.Value = "-1"
        tbCodigo.Text = ""
        hfQuery.Value = "insertar"
        lbtnCancelar.Visible = False
        lbtnGuardar.Enabled = Roles("Administrador,JefeLab,JefeRefri,SupMet,SupLab", 1)



    End Sub

    Private Sub controlesRepeater()
        Dim mod1 As Boolean = Roles("Administrador,JefeLab,JefeRefri,SupMet,SupLab", 2)
        Dim eli1 As Boolean = Roles("Administrador,JefeLab,JefeRefri,SupMet,SupLab", 3)

        For index As Integer = 0 To RepeaterTabla.Items.Count - 1 Step 1
            'Modificar
            CType(RepeaterTabla.Items(index).FindControl("LinkButton1"), LinkButton).Visible = eli1
            'Eliminar
            CType(RepeaterTabla.Items(index).FindControl("LinkButton2"), LinkButton).Visible = mod1

            CType(RepeaterTabla.Items(index).FindControl("lbtnEliminarRepeat"), LinkButton).Visible = eli1
            'Eliminar
            CType(RepeaterTabla.Items(index).FindControl("lbtnModificarRepeat"), LinkButton).Visible = mod1
        Next


    End Sub

    Private Sub cargarResumenVerificaciones(ByVal query As String, ByVal ID As Int32)

        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Verificacion_ABCD", New Object() {
                                                                   New Object() {"@query", query},
                                                                    New Object() {"@Codigo", tbCodigoFiltro.Text},
                                                                    New Object() {"@filtro1", tbModeloFiltro.Text},
                                                                    New Object() {"@filtro2", tbSerieFiltro.Text},
                                                                    New Object() {"@filtro3", tbWOFiltro.Text},
                                                                    New Object() {"@camara", tbCamaraFiltro.Text},
                                                                    New Object() {"@ID", ID}
                                                                     }, CommandType.StoredProcedure).Tables(0)



        If (query.Equals("consultar_por_id")) Then
            hfID.Value = DTOrig.Rows(0).Item(0)
            tbCodigo.Text = DTOrig.Rows(0).Item(1)
            ddlEstacionCamara.SelectedValue = DTOrig.Rows(0).Item(2)
            ddlInstrumentos.SelectedValue = DTOrig.Rows(0).Item(3)
            changeListEleccion(DTOrig.Rows(0).Item(14).ToString.TrimEnd)
            tbP1.Text = DTOrig.Rows(0).Item(4)
            tbP2.Text = DTOrig.Rows(0).Item(5)
            tbP3.Text = DTOrig.Rows(0).Item(6)
            tbP4.Text = DTOrig.Rows(0).Item(7)
            tbP5.Text = DTOrig.Rows(0).Item(8)
            tbP6.Text = DTOrig.Rows(0).Item(9)
            tbP7.Text = DTOrig.Rows(0).Item(10)
            tbP8.Text = DTOrig.Rows(0).Item(11)
            tbP9.Text = DTOrig.Rows(0).Item(12)
            tbComentarios.Text = DTOrig.Rows(0).Item(13).ToString.TrimEnd
            ddlTipoEntrada.SelectedValue = DTOrig.Rows(0).Item(14).ToString().TrimEnd

            lbtnGuardar.Enabled = Roles("Administrador,JefeLab,JefeRefri,SupLab,SupMet", 1)



            Else
            RepeaterTabla.DataSource = DTOrig
            RepeaterTabla.DataBind()
            ' llamarFuncionesJavascript("", "")
        End If


    End Sub

    Private Sub chargeListCatalogos(ByVal ID_Categoria As Integer)

        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Catalogo_Actualiza", New Object() {
                                                                  New Object() {"@Tipo", "consultarCat"},
                                                                  New Object() {"@Categoria_ID", ID_Categoria}
                                                                  }, CommandType.StoredProcedure).Tables(0)

        Select Case ID_Categoria
            Case 12
                ddlEstacionCamara.DataSource = DTOrig
                ddlEstacionCamara.DataTextField = "Descripcion"
                ddlEstacionCamara.DataValueField = "ID"
                ddlEstacionCamara.DataBind()

        End Select

    End Sub

    Private Sub chargeListInstrumentos()


        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Instrumentos_ABCD", New Object() {
                                                                   New Object() {"@query", "consultar"}
                                                                   }, CommandType.StoredProcedure).Tables(0)

        ddlInstrumentos.DataSource = DTOrig
        ddlInstrumentos.DataTextField = "Equipo"
        ddlInstrumentos.DataValueField = "ID"
        ddlInstrumentos.DataBind()
    End Sub

    Private Sub changeListEleccion(ByVal eleccion As String)
        If (eleccion = "Electrico") Then
            lblP1.Text = "Corriente Patron On (A)"
            lblP2.Text = "Corriente Patron Off (A)"
            lblP3.Text = "Corriente Equipo On (A)"
            lblP4.Text = "Corriente Equipo Off (A)"

            lblP5.Text = "Voltaje Patron On (V)"
            lblP6.Text = "Voltaje Patron Off (V)"
            lblP7.Text = "Voltaje Equipo On (V)"
            lblP8.Text = "Voltaje Equipo Off (V)"
            lblP9.Visible = False
            tbP9.Text = "0"
            tbP9.Visible = False
            lblP4.Visible = True
            lblP5.Visible = True
            lblP6.Visible = True
            lblP7.Visible = True
            lblP8.Visible = True
            tbP4.Visible = True
            tbP5.Visible = True
            tbP6.Visible = True
            tbP7.Visible = True
            tbP8.Visible = True



        ElseIf (eleccion = "Flujo de aire") Then
            lblP1.Text = "punto Flujo 1 (ft/min)"
            lblP2.Text = "punto Flujo 2 (ft/min)"
            lblP3.Text = "punto Flujo 3 (ft/min)"
            lblP4.Visible = False
            lblP5.Visible = False
            lblP6.Visible = False
            lblP7.Visible = False
            lblP8.Visible = False
            tbP4.Visible = False
            tbP5.Visible = False
            tbP6.Visible = False
            tbP7.Visible = False
            tbP8.Visible = False

            lblP9.Visible = False
            tbP9.Visible = False
            tbP4.Text = "01"
            tbP5.Text = "01"
            tbP6.Text = "01"
            tbP7.Text = "01"
            tbP8.Text = "01"
            tbP9.Text = "01"

        End If
        MuestraErrorToast("Campos inicializados", 0, True)
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


            If (tbCodigo.Text.Length > 0 And ddlEstacionCamara.SelectedValue.Length > 0 And
         ddlInstrumentos.SelectedValue.Length > 0 And ddlTipoEntrada.SelectedValue.Length > 0 And
         tbP1.Text > 0 And tbP2.Text > 0 And tbP3.Text > 0 And tbP4.Text > 0 And tbP5.Text > 0 And
         tbP6.Text > 0 And tbP7.Text > 0 And tbP8.Text > 0) Then

                MuestraErrorToast(BLL.Validacion_BLL.insertar(hfQuery.Value, Int32.Parse(hfID.Value), "", ddlEstacionCamara.SelectedValue, ddlInstrumentos.SelectedValue, tbCodigo.Text,
    tbComentarios.Text, Session("Usuario").ToString, ddlTipoEntrada.SelectedValue, tbP1.Text, tbP2.Text, tbP3.Text, tbP4.Text, tbP5.Text, tbP6.Text, tbP7.Text, tbP8.Text, tbP9.Text), 1, True)

                'llamarFuncionesJavascript("Se realizo el cambio", "Satisfactorio")
                tbCodigoFiltro.Text = tbCodigo.Text
                cargarResumenVerificaciones("consultarfiltro", -1)
                inicializar()



            Else
                MuestraErrorToast("Complete los campos", 1, True)
            End If
        Catch ex As Exception
            MuestraErrorToast(ex.Message, 1, True)
        End Try

    End Sub

    Protected Sub ddlTipoEntrada_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            If sender.SelectedValue = "" Then
                sender.SelectedValue = "Electrico"

            End If
            changeListEleccion(sender.SelectedValue.ToString)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub RepeaterTabla_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "editarVerificacion") Then

            lbtnGuardar.Visible = True
            hfQuery.Value = "modificar"
            lbtnCancelar.Visible = True
            tbComentarios.Focus()
            hfID.Value = e.CommandArgument

            cargarResumenVerificaciones("consultar_por_id", Int32.Parse(e.CommandArgument))
            MuestraErrorToast("Realizado", 0, True)

        ElseIf e.CommandName = "eliminarVerificacion" Then
            MuestraErrorToast(BLL.Validacion_BLL.eliminar(Int32.Parse(e.CommandArgument)), 1, True)
            cargarResumenVerificaciones("consultarfiltro", -1)
        End If


    End Sub
End Class