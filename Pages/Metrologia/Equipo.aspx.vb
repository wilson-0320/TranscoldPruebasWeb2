Public Class Equipo
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            chargeListCatalogos(12)
            chargeListCatalogos(13)
            cargarRepeaterInstrumentos("consultarGeneral", -1)
            chargeListCatalogos(14)
            chargeListCatalogos(15)

            Try
                inicializar()

            Catch ex As Exception

            End Try


        End If
    End Sub

    Private Sub inicializar()
        hfQuery.Value = "insertar"
        hfID.Value = "-1"
        tbNombre.Text = ""
        tbFabricante.Text = ""
        tbModelo.Text = ""
        tbSerie.Text = ""
        tbSoftware.Text = ""
        tbIntervalo.Text = ""
        tbResolucion.Text = ""
        tbRango.Text = ""
        tbNoPuntos.Text = ""
        'tbUbicacion.Text = ""
        lbtnCancelar.Visible = False
        hfIDCertificados.Value = "-1"
        hfQueryCertificados.Value = "insertar"
        hfIDInstrumento.Value = "-1"

        lbtnCancelarCertificado.Visible = False
        lbtnGuardarCertificado.Enabled = Roles("Administrador,JefeLab,SupMet", 1)
        lbtnGuardarLaboratorios.Enabled = Roles("Administrador,JefeLab,SupMet", 1)
        lbtnGuardar.Enabled = Roles("Administrador,JefeLab,SupMet", 1)
    End Sub

    Private Sub chargeListCatalogos(ByVal ID_Categoria As Integer)

        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Catalogo_Actualiza", New Object() {
                                                                  New Object() {"@Tipo", "consultarCat"},
                                                                  New Object() {"@Categoria_ID", ID_Categoria}
                                                                  }, CommandType.StoredProcedure).Tables(0)

        Select Case ID_Categoria
            Case 12
                ddlCamaras.DataSource = DTOrig
                ddlCamaras.DataTextField = "Descripcion"
                ddlCamaras.DataValueField = "Descripcion"
                ddlCamaras.DataBind()
            Case 13
                ddlMarca.DataSource = DTOrig
                ddlMarca.DataTextField = "Descripcion"
                ddlMarca.DataValueField = "ID"
                ddlMarca.DataBind()
            Case 14
                ddlMagnitud.DataSource = DTOrig
                ddlMagnitud.DataTextField = "Descripcion"
                ddlMagnitud.DataValueField = "ID"
                ddlMagnitud.DataBind()
            Case 15
                ddlLaboratorios.DataSource = DTOrig
                ddlLaboratorios.DataTextField = "Descripcion"
                ddlLaboratorios.DataValueField = "ID"
                ddlLaboratorios.DataBind()

        End Select



    End Sub

    Private Sub cargarRepeaterInstrumentos(ByVal query As String, ByVal ID As String)
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Instrumentos_ABCD", New Object() {
                                                                 New Object() {"@query", query},
                                                                  New Object() {"@ID", ID}
                                                                 }, CommandType.StoredProcedure).Tables(0)

        If (query.Equals("consultar_por_id")) Then


            tbNombre.Text = DTOrig.Rows(0).Item(1).ToString.TrimEnd
            ddlTipoEquipo.SelectedValue = DTOrig.Rows(0).Item(3).ToString.TrimEnd
            tbFabricante.Text = DTOrig.Rows(0).Item(4).ToString.TrimEnd
            ddlMarca.SelectedValue = DTOrig.Rows(0).Item(5).ToString.TrimEnd
            tbModelo.Text = DTOrig.Rows(0).Item(6).ToString.TrimEnd
            tbSerie.Text = DTOrig.Rows(0).Item(7).ToString.TrimEnd
            tbSoftware.Text = DTOrig.Rows(0).Item(8).ToString.TrimEnd
            tbIntervalo.Text = DTOrig.Rows(0).Item(9).ToString.TrimEnd
            tbResolucion.Text = DTOrig.Rows(0).Item(10).ToString.TrimEnd
            tbRango.Text = DTOrig.Rows(0).Item(11).ToString.TrimEnd
            tbResolucion.Text = DTOrig.Rows(0).Item(10).ToString.TrimEnd
            tbRango.Text = DTOrig.Rows(0).Item(11).ToString.TrimEnd
            tbNoPuntos.Text = DTOrig.Rows(0).Item(12).ToString.TrimEnd
            ddlCamaras.SelectedValue = DTOrig.Rows(0).Item(13).ToString.TrimEnd
        Else
            repeaterInstrumentos.DataSource = DTOrig
            repeaterInstrumentos.DataBind()

        End If


    End Sub

    Protected Sub chargeRepeatLaboratorios()
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Laboratorio_Calibracion_ABCD", New Object() {
                                                                  New Object() {"@query", "consultar"},
                                                                   New Object() {"@ID_Instrumento", hfIDInstrumento.Value}
                                                                  }, CommandType.StoredProcedure).Tables(0)

        repeaterLaboratorios.DataSource = DTOrig
        repeaterLaboratorios.DataBind()
        ddlLaboratoriosAsignados.Items.Clear()
        ddlLaboratoriosAsignados.DataSource = DTOrig
        ddlLaboratoriosAsignados.DataTextField = "Descripcion"
        ddlLaboratoriosAsignados.DataValueField = "ID"
        ddlLaboratoriosAsignados.DataBind()

    End Sub

    Protected Sub chargeRepeatCertificados(ByVal query As String, ByVal ID As Integer)
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Certificados_Equipos_ABCD", New Object() {
                                                                  New Object() {"@query", query},
                                                                   New Object() {"@ID_Instrumento", hfIDInstrumento.Value},
                                                                   New Object() {"@ID", hfIDCertificados.Value}
                                                                  }, CommandType.StoredProcedure).Tables(0)
        If (query.Equals("consultar_por_id")) Then
            ddlLaboratoriosAsignados.SelectedValue = DTOrig.Rows(0).Item(1).ToString.TrimEnd
            tbGuiaEnvio.Text = DTOrig.Rows(0).Item(2).ToString.TrimEnd
            tbGuiaRetorno.Text = DTOrig.Rows(0).Item(3).ToString.TrimEnd
            tbCertificado.Text = DTOrig.Rows(0).Item(4).ToString.TrimEnd

            If ((DTOrig.Rows(0).Item(5).ToString().Length) > 0) Then
                Dim fechas() As String = Split((DTOrig.Rows(0).Item(5)).ToString.Substring(0, DTOrig.Rows(0).Item(5).ToString.IndexOf(" ")).Replace("/", "-"), "-")

                tbFechaCal.Text = fechas(2) + "-" + fechas(1) + "-" + fechas(0)

            End If

            If ((DTOrig.Rows(0).Item(6).ToString().Length) > 0) Then
                Dim fechas() As String = Split((DTOrig.Rows(0).Item(6)).ToString.Substring(0, DTOrig.Rows(0).Item(6).ToString.IndexOf(" ")).Replace("/", "-"), "-")

                tbFechaProx.Text = fechas(2) + "-" + fechas(1) + "-" + fechas(0)

            End If



        Else
            repeaterCertificados.DataSource = DTOrig
            repeaterCertificados.DataBind()

        End If


    End Sub
    Protected Sub lbtnCancelar_Click(sender As Object, e As EventArgs)
        inicializar()
        MuestraErrorToast("Listo", 0, True)
    End Sub

    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        If (tbNombre.Text.Length > 0 And tbModelo.Text.Length > 0 And tbSoftware.Text.Length > 0 And
    tbIntervalo.Text.Length > 0 And tbResolucion.Text.Length > 0 And tbRango.Text.Length > 0 And
    tbNoPuntos.Text.Length > 0 And ddlCamaras.SelectedValue.Length > 0) Then

            Dim msj As String = BLL.Equipos_BLL.insertar(hfQuery.Value, ddlTipoEquipo.SelectedValue, hfID.Value, tbNombre.Text, tbFabricante.Text,
tbSerie.Text, tbModelo.Text, ddlMagnitud.SelectedValue, Int32.Parse(ddlMarca.SelectedValue), tbSoftware.Text, tbIntervalo.Text,
tbResolucion.Text, tbRango.Text, tbNoPuntos.Text, ddlCamaras.SelectedValue)

            cargarRepeaterInstrumentos("consultarGeneral", -1)
            inicializar()
            MuestraErrorToast("Listo", 1, True)
        Else
            'Comentario

        End If
    End Sub

    Protected Sub lbtnGuardarLaboratorios_Click(sender As Object, e As EventArgs)
        Dim msj As String = BLL.Laboratorios_Calibracion_BLL.crud(hfQueryLab.Value, -1, Integer.Parse(hfIDInstrumento.Value), Integer.Parse(ddlLaboratorios.SelectedValue))

        chargeRepeatLaboratorios()
        chargeRepeatCertificados("consultar", -1)

        MuestraErrorToast("Listo", 2, True)
    End Sub


    Protected Sub lbtnCancelarCertificado_Click(sender As Object, e As EventArgs)
        lbtnCancelarCertificado.Visible = False
        hfQueryCertificados.Value = "insertar"
        hfIDCertificados.Value = "-1"
        MuestraErrorToast("Listo", 2, True)
    End Sub

    Protected Sub lbtnGuardarCertificado_Click(sender As Object, e As EventArgs)
        If (tbFechaCal.Text.Length < 1) Then
            tbFechaCal.Text = DateTime.Now.ToString
        End If
        If (tbFechaProx.Text.Length < 1) Then
            tbFechaProx.Text = DateTime.Now.ToString
        End If
        Try


            Dim msj As String = BLL.Certificados_Calibracion_BLL.crud(hfQueryCertificados.Value,
                                                                      Integer.Parse(hfIDCertificados.Value),
                                                                     Integer.Parse(hfIDInstrumento.Value),
                                                                     Integer.Parse(ddlLaboratoriosAsignados.SelectedValue), tbGuiaEnvio.Text, tbGuiaRetorno.Text, tbCertificado.Text, Convert.ToDateTime(tbFechaCal.Text), Convert.ToDateTime(tbFechaProx.Text))
            chargeRepeatCertificados("consultar", -1)
            tbGuiaEnvio.Text = ""
            tbGuiaRetorno.Text = ""
            tbCertificado.Text = ""
            tbFechaCal.Text = ""
            tbFechaProx.Text = ""
            hfIDCertificados.Value = "-1"
            hfQueryCertificados.Value = "insertar"
            MuestraErrorToast("Listo", 2, True)
            'men
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub repeaterInstrumentos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "editarInstrumento") Then
            lbtnGuardar.Visible = True
            hfQuery.Value = "modificar"
            lbtnCancelar.Visible = True
            tbNombre.Focus()
            hfID.Value = e.CommandArgument
            cargarRepeaterInstrumentos("consultar_por_id", Int32.Parse(hfID.Value))
            cargarRepeaterInstrumentos("consultarGeneral", -1)
            hfQueryLab.Value = "insertar"
            hfQueryCertificados.Value = "insertar"
            hfIDInstrumento.Value = e.CommandArgument
            chargeRepeatLaboratorios()
            chargeRepeatCertificados("consultar", -1)
            MuestraErrorToast("Listo", 0, True)

        ElseIf e.CommandName = "eliminarInstrumento" Then

            Dim msj As String = BLL.Equipos_BLL.eliminar((Int32.Parse(e.CommandArgument)))
            cargarRepeaterInstrumentos("consultarGeneral", -1)
            inicializar()
            'Comentarios
            MuestraErrorToast("Listo", 2, True)

        ElseIf e.CommandName = "aprobarInstrumento" Then

            Dim msj As String = BLL.Equipos_BLL.aprobar((Int32.Parse(e.CommandArgument)))
            cargarRepeaterInstrumentos("consultarGeneral", -1)
            inicializar()
            MuestraErrorToast("Listo", 2, True)
            '
            '

        End If
    End Sub



    Protected Sub repeaterCertificados_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (tbFechaCal.Text.Length < 1) Then
            tbFechaCal.Text = DateTime.Now.ToString
        End If
        If (tbFechaProx.Text.Length < 1) Then
            tbFechaProx.Text = DateTime.Now.ToString
        End If

        If e.CommandName = "eliminarCertificado" And Roles("Administrador,JefeLab,SupMet", 3) Then

            Dim msj As String = BLL.Certificados_Calibracion_BLL.crud("eliminar", (Int32.Parse(e.CommandArgument)), -1, -1, "", "", "", "01-01-2022", "01-01-2022")
            chargeRepeatCertificados("consultar", -1)
            tbGuiaEnvio.Text = ""
            tbGuiaRetorno.Text = ""
            tbCertificado.Text = ""
            tbFechaCal.Text = ""
            tbFechaProx.Text = ""
            hfIDCertificados.Value = "-1"
            hfQueryCertificados.Value = "insertar"
            If msj.StartsWith("Error:") Then
            Else
            End If
            MuestraErrorToast("Listo", 2, True)
        ElseIf e.CommandName = "modificarCertificado" Then
            hfIDCertificados.Value = (Int32.Parse(e.CommandArgument))
            lbtnCancelarCertificado.Visible = True
            hfQueryCertificados.Value = "modificar"
            lbtnGuardarCertificado.Enabled = Roles("Administrador,JefeLab,SupMet", 2)
            chargeRepeatCertificados("consultar_por_id", (Int32.Parse(e.CommandArgument)))
            MuestraErrorToast("Listo", 0, True)
        End If
    End Sub

    Protected Sub repeaterLaboratorios_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If e.CommandName = "eliminarLaboratorio" And Roles("Administrador,JefeLab,SupMet", 3) Then

            Dim msj As String = BLL.Laboratorios_Calibracion_BLL.crud("eliminar", (Int32.Parse(e.CommandArgument)), -1, -1)

            chargeRepeatLaboratorios()

            If msj.StartsWith("Error:") Then
            Else
            End If
        End If
    End Sub
End Class