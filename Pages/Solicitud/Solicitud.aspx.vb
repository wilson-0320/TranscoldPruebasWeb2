Imports MessagingToolkit.QRCode.Codec
Imports System.Drawing
Imports System.IO

Public Class Solicitud
    Inherits MiPageN
    Dim rutaQR As String = "http://fogelonline.com/TranscoldPruebasWeb2/Pages/Solicitud/Reportes/tabPanel.aspx?Codigo="


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            '   check.r

            If Not Request.QueryString("Codigo") Is Nothing Then
                lblCodigo.Text = Request.QueryString("Codigo")
                iniciarControles(True, lblCodigo.Text)
                consultarFechaFin()
            Else
                iniciarControles(False, "")
                cargarCodigoSolicitud()
            End If
            cargarddlCatalogo(3)
            cargarddlCatalogo(4)
            cargarddlCatalogo(1)

            Try

            Catch ex As Exception
            End Try


        End If
        Page.Form.Attributes.Add("enctype", "multipart/form-data")

    End Sub

    Private Function consultarFechaFin() As Boolean
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Select Fecha_Finalizacion From Pru_Solicitud where Codigo=@Codigo", New Object() {
                                                                 New Object() {"@Codigo", lblCodigo.Text}
                                                                 }, CommandType.Text).Tables(0)

        Dim fin As String = ""

        Try
            fin = DTOrig.Rows(0).Item(0).ToString
        Catch ex As Exception

        End Try

        'Si fin tienen texto, quiere decir que ya hay una fecha final
        If (fin.Length > 5) Then

            lbtnGuardarDivision.Enabled = False
            lbtnGuardarEnsayos.Enabled = False
            lbtnGuardarEnsayosContratos.Enabled = False
            lbtnGuardarSolicitud.Enabled = False
            lbtnEliminar.Enabled = False
            Return False

        Else
            Return True

        End If

    End Function
    Private Sub msjNot()
        If Not BLL.Solicitud_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Solicitud_BLL.MsjError, 4, True)
        Else
            MuestraErrorToast("Se completo la operacion.", 1, True)
        End If
    End Sub

    Private Sub iniciarControles(ByVal bandera As Boolean, ByVal Codigo As String)
        Dim agregarP As Boolean = Roles("Administrador,JefeLab,JefeRefri", 1)
        Dim eliminarP As Boolean = Roles("Administrador,JefeLab,JefeRefri", 3)
        Dim modificarP As Boolean = Roles("Administrador,JefeLab,JefeRefri", 2)
        'Si se recibe un codigo de prueba es true

        If (bandera) Then
            Try


                Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Actualiza2", New Object() {
                                                                    New Object() {"@Estado", "consulta"},
                                                                    New Object() {"@Codigo", Codigo.TrimEnd}
                                                                    }, CommandType.StoredProcedure).Tables(0)

                lblConsectivo.Text = DTOrig.Rows(0).Item(19)
                lblCodigo.Text = DTOrig.Rows(0).Item(0)
                Try
                    ddlEstadoB.SelectedValue = DTOrig.Rows(0).Item(20)
                Catch ex As Exception

                End Try

                lblFechaCreacion.Text = DTOrig.Rows(0).Item(1)
                ddlLider.SelectedValue = DTOrig.Rows(0).Item(2)
                tbModelo.Text = DTOrig.Rows(0).Item(3)
                ddlEncargado.SelectedValue = DTOrig.Rows(0).Item(4)
                tbObjetivosSolicitud.Text = DTOrig.Rows(0).Item(5)
                tbCantidad.Text = DTOrig.Rows(0).Item(6)
                tbRProveedor.Text = DTOrig.Rows(0).Item(7)
                tbRFogel.Text = DTOrig.Rows(0).Item(8)
                tbModeloM.Text = DTOrig.Rows(0).Item(9)
                tbSerieM.Text = DTOrig.Rows(0).Item(10)
                tbWoM.Text = DTOrig.Rows(0).Item(11)

                If ((DTOrig.Rows(0).Item(12).ToString().Length) > 0) Then
                    Dim fechas() As String = Split((DTOrig.Rows(0).Item(12)).ToString.Substring(0, DTOrig.Rows(0).Item(12).ToString.IndexOf(" ")).Replace("/", "-"), "-")

                    tbFechaEntrega.Text = fechas(2) + "-" + fechas(1) + "-" + fechas(0)

                End If
                Try
                    ddlCarga.SelectedValue = DTOrig.Rows(0).Item(13)
                Catch ex As Exception

                End Try

                tbParametroTermostato.Text = DTOrig.Rows(0).Item(14)
                tbDisposisionFinal.Text = DTOrig.Rows(0).Item(15)
                tbComentariosEspeciales.Text = DTOrig.Rows(0).Item(16)


                cargarEnsayosRepeater(2, "Ofr")
                cargarEnsayosRepeater(1, "Sol")
                cargarDivisionReporte()
                lbtnEliminar.Visible = False

                ibtnCambios.Enabled = True
                ibtnLinea.Enabled = True
                ibtnTermopares.Enabled = True
                ibtnTab.Enabled = True
                ibtnGraficas.Enabled = True
                ibtnReporteSolicitud.Enabled = True
                ibtnReportePruebas.Enabled = True
                lbtnEliminar.Visible = True
                ddlEstadoB.Enabled = modificarP
            Catch ex As Exception

            End Try
            'tbDivision.Text = ""
        Else
            lblConsectivo.Text = ""
            Dim thisDate As Date
            thisDate = Today
            lblFechaCreacion.Text = Today
            tbModelo.Text = ""
            tbObjetivosSolicitud.Text = ""
            tbCantidad.Text = ""
            tbRProveedor.Text = ""
            tbRFogel.Text = ""
            tbModeloM.Text = ""
            tbSerieM.Text = ""
            tbWoM.Text = ""
            tbFechaEntrega.Text = ""
            tbParametroTermostato.Text = ""
            tbDisposisionFinal.Text = ""
            tbComentariosEspeciales.Text = ""
            tbDivision.Text = ""


            ddlEstadoB.Enabled = False


            hfQueryEnsayos.Value = "insertar"
            ibtnCambios.Enabled = False
            ibtnLinea.Enabled = False
            ibtnTermopares.Enabled = False
            ibtnTab.Enabled = False
            ibtnGraficas.Enabled = False
            ibtnReporteSolicitud.Enabled = False
            ibtnReportePruebas.Enabled = False
            lbtnEliminar.Visible = False

        End If



        lbtnEliminar.Enabled = eliminarP
        lbtnGuardarSolicitud.Enabled = agregarP
        lbtnGuardarEnsayos.Enabled = agregarP
        lbtnGuardarDivision.Enabled = agregarP
        lbtnGuardarEnsayosContratos.Enabled = agregarP

        ''''''''''''''''''check list '''''''''''''''''''''
        hfNum.Value = "1"
        hfIDEnsayoPrueba.Value = "-1"
        hfTipoInicioFin.Value = "INICIO"
        hfIDRequerimiento.Value = "-1"
        hfIDCheck.Value = "-1"
        tbOpciones.Visible = False
        lbOpciones.Visible = False
        lblRequisito.Text = False
        lbtnSiguiente.Visible = False

    End Sub

    Private Sub cargarddlCatalogo(ByVal Categoria_ID)

        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Catalogo_Actualiza", New Object() {
                                                                    New Object() {"@Tipo", "consultarCat2"},
                                                                    New Object() {"@Categoria_ID", Categoria_ID}
                                                                    }, CommandType.StoredProcedure).Tables(0)
        '3: Ensayos
        '4 Tipo de carga
        '1 Personal
        Select Case (Categoria_ID)
            Case 1
                ddlEncargado.DataSource = DTOrig
                ddlEncargado.DataValueField = "ID"
                ddlEncargado.DataTextField = "Descripcion"
                ddlEncargado.DataBind()

                ddlLider.DataSource = DTOrig
                ddlLider.DataValueField = "ID"
                ddlLider.DataTextField = "Descripcion"
                ddlLider.DataBind()
            Case 3
                ddlEnsayos.DataSource = DTOrig
                ddlEnsayos.DataValueField = "ID"
                ddlEnsayos.DataTextField = "Descripcion"
                ddlEnsayos.DataBind()

                ddlEnsayosOfrecidos.DataSource = DTOrig

                ddlEnsayosOfrecidos.DataValueField = "ID"
                ddlEnsayosOfrecidos.DataTextField = "Descripcion"
                ddlEnsayosOfrecidos.DataBind()
            Case 4
                Try
                    ddlCarga.DataSource = DTOrig

                    ddlCarga.DataValueField = "ID"
                    ddlCarga.DataTextField = "Descripcion"
                    ddlCarga.DataBind()
                Catch ex As Exception

                End Try


        End Select


    End Sub
    '''''''''''''''''''''''''''''Devolucion de codigo de solicitud'''''''''''''''''''''''''''''''''
    Private Sub cargarCodigoSolicitud()
        Try
            Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Consulta", New Object() {
                                                                    New Object() {"@Tipo", "Codigo"}
                                                                    }, CommandType.StoredProcedure).Tables(0)


            Dim codigoSum As Int32 = Int32.Parse(DTOrig.Rows(0).Item(0).ToString.Substring(4)) + 1
            If (DTOrig.Rows(0).Item(0).ToString.Substring(0, 2).Equals(Now.Year().ToString.Substring(2, 2))) Then

            Else
                codigoSum = 1
            End If

            If (codigoSum > 999) Then
                lblCodigo.Text = Now.Year().ToString.Substring(2, 2) + "/" + codigoSum.ToString
            ElseIf (codigoSum > 99 And codigoSum < 1000) Then
                lblCodigo.Text = Now.Year().ToString.Substring(2, 2) + "/0" + codigoSum.ToString
            ElseIf (codigoSum > 9 And codigoSum < 100) Then
                lblCodigo.Text = Now.Year().ToString.Substring(2, 2) + "/00" + codigoSum.ToString
            ElseIf (codigoSum > 0 And codigoSum < 10) Then
                lblCodigo.Text = Now.Year().ToString.Substring(2, 2) + "/000" + codigoSum.ToString
            End If
            '  lblCodigo.Text = "22/0037"
        Catch ex As Exception

        End Try


    End Sub

    Private Sub cargarEnsayosRepeater(ByVal opcion As Integer, ByVal tipo As String)
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Ensayo_ABCD", New Object() {
                                                                    New Object() {"@query", "consultar"},
                                                                    New Object() {"@Solicitud_Cod", lblCodigo.Text},
                                                                    New Object() {"@Tipo", tipo}
                                                                    }, CommandType.StoredProcedure).Tables(0)
        Select Case opcion
            Case 1
                repeaterEnsayos.DataSource = DTOrig
                repeaterEnsayos.DataBind()

            Case 2
                repeaterEnsayosContratados.DataSource = DTOrig
                repeaterEnsayosContratados.DataBind()


        End Select



    End Sub

    Private Sub cargarDivisionReporte()
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Division_ABCD", New Object() {
                                                                    New Object() {"@query", "consultar_por_codigo2"},
                                                                    New Object() {"@codigo", lblCodigo.Text}
                                                                    }, CommandType.StoredProcedure).Tables(0)
        repeaterDivision.DataSource = DTOrig
        repeaterDivision.DataBind()



    End Sub

    Private Function validarCrud() As Boolean

        For Each CampoTexto As TextBox In New TextBox() {
            tbModelo, tbObjetivosSolicitud, tbCantidad, tbRProveedor, tbRFogel, tbModeloM, tbSerieM, tbWoM,
            tbFechaEntrega, tbParametroTermostato, tbDisposisionFinal, tbComentariosEspeciales
            }

            If CampoTexto.Text = "" Then
                MuestraErrorToast("Debe especificar el valor del campo enfocado " + CampoTexto.ToolTip, 3, True)
                CampoTexto.Focus()

                Return False
            End If


        Next
        Return True

    End Function


    'Click que inserta y modifica

    Private Sub guardarCrudSolicitud(ByVal Estado As String)


        If (ddlEstadoB.Enabled) Then
            Estado = ddlEstadoB.SelectedValue.TrimEnd
        End If
        BLL.Solicitud_BLL.crudSolicitud(Estado.TrimEnd, lblCodigo.Text, Session("Usuario").ToString, ddlLider.SelectedValue,
tbModelo.Text, ddlEncargado.SelectedValue, tbObjetivosSolicitud.Text, tbCantidad.Text, tbRProveedor.Text, tbRFogel.Text,
tbModeloM.Text, tbSerieM.Text, tbWoM.Text, tbFechaEntrega.Text, ddlCarga.SelectedValue, tbParametroTermostato.Text,
tbDisposisionFinal.Text, tbComentariosEspeciales.Text, "", "", LocacionDropDownList.SelectedValue)
        iniciarControles(True, lblCodigo.Text)
        msjNot()
    End Sub

    Protected Sub lbtnGuardarSolicitud_Click(sender As Object, e As EventArgs)
        If validarCrud() Then
            guardarCrudSolicitud("Nueva")
        End If
    End Sub
    Protected Sub lbtnGuardarEnsayos_Click(sender As Object, e As EventArgs)

        BLL.Solicitud_Ensayo_BLL.insertar(lblCodigo.Text, "Sol", ddlEnsayos.SelectedValue)
        cargarEnsayosRepeater(1, "Sol")
        If Not BLL.Solicitud_Ensayo_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Solicitud_Ensayo_BLL.MsjError, 4, True)
        Else
            MuestraErrorToast("Listo", 1, True)
        End If

    End Sub
    Protected Sub lbtnGuardarEnsayosContratos_Click(sender As Object, e As EventArgs)
        BLL.Solicitud_Ensayo_BLL.insertar(lblCodigo.Text, "Ofr", ddlEnsayos.SelectedValue)
        cargarEnsayosRepeater(2, "Ofr")
        If Not BLL.Solicitud_Ensayo_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Solicitud_Ensayo_BLL.MsjError, 4, True)
        Else
            MuestraErrorToast("Listo", 1, True)
        End If

    End Sub

    Protected Sub lbtnGuardarDivision_Click(sender As Object, e As EventArgs)
        MuestraErrorToast(BLL.Solicitud_Division_BLL.insertar(lblCodigo.Text, tbDivision.Text), 1, True)
        cargarDivisionReporte()
    End Sub

    Protected Sub lbtnLimpiar_Click(sender As Object, e As EventArgs)
        If (lblConsectivo.Text.Length > 0) Then
            iniciarControles(True, lblCodigo.Text)
        Else
            iniciarControles(False, "")
        End If
        MuestraErrorToast("Campos inicializados", 2, True)
    End Sub

    Protected Sub lbtnEliminar_Click(sender As Object, e As EventArgs)

        BLL.Solicitud_BLL.Eliminar(lblCodigo.Text, "eliminar")
        msjNot()
        Try
            iniciarControles(True, "")
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub tbSerieM_TextChanged(sender As Object, e As EventArgs)
        'Dim ModeloOrdProd As String = "||"
        Try
            Dim ModeloOrdProd As String = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "select dbo.Pru_Consulta_Valor('DatosDeSerie', @Serie)", New Object() {
                                                           New Object() {"@Serie", tbSerieM.Text}
                                                          }, CommandType.Text).Tables(0).Rows(0)(0)
            Dim Modelo As String = ModeloOrdProd.Split("|")(0)
            Dim OrdProd As String = ModeloOrdProd.Split("|")(1)
            If Modelo <> "" Then
                tbModeloM.Text = Modelo
            End If
            If OrdProd <> "" Then
                tbWoM.Text = OrdProd
            End If
            MuestraErrorToast("", 0, True)
        Catch ex As Exception
            MuestraErrorToast("Ha ocurrido un error en la consulta del modelo", 3, True)
        End Try

    End Sub

    Protected Sub ddlEstadoB_SelectedIndexChanged(sender As Object, e As EventArgs)
        guardarCrudSolicitud(ddlEstadoB.SelectedValue)
    End Sub


    Protected Sub repeaterEnsayosContratados_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") And Roles("Administrador,JefeLab,JefeRefri", 3) And consultarFechaFin() Then
            BLL.Solicitud_Ensayo_BLL.eliminar(Integer.Parse(e.CommandArgument))
            cargarEnsayosRepeater(2, "Ofr")
            If Not BLL.Solicitud_Ensayo_BLL.MsjError Is Nothing Then
                MuestraErrorToast(BLL.Solicitud_Ensayo_BLL.MsjError, 4, True)
            Else
                MuestraErrorToast("Listo", 1, True)
            End If


        End If
    End Sub
    Protected Sub repeaterEnsayos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") And Roles("Administrador,JefeLab,JefeRefri", 3) And consultarFechaFin() Then
            BLL.Solicitud_Ensayo_BLL.eliminar(Integer.Parse(e.CommandArgument))

            cargarEnsayosRepeater(1, "Sol")
            If Not BLL.Solicitud_Ensayo_BLL.MsjError Is Nothing Then
                MuestraErrorToast(BLL.Solicitud_Ensayo_BLL.MsjError, 4, True)
            Else
                MuestraErrorToast("Listo", 1, True)
            End If

        End If
    End Sub

    Protected Sub repeaterDivision_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") And Roles("Administrador,JefeLab,JefeRefri", 3) And consultarFechaFin() Then
            MuestraErrorToast(BLL.Solicitud_Division_BLL.eliminar(Integer.Parse(e.CommandArgument)), 1, True)
            cargarDivisionReporte()
        ElseIf (e.CommandName = "QR") Then
            Codigoqr(e.CommandArgument)
        End If
    End Sub

    '''G''''''''''''''''Generacion de codigo QR
    Private Sub Codigoqr(ByVal division As String)
        Dim encoder As QRCodeEncoder = New QRCodeEncoder()
        Dim img As Bitmap
        img = encoder.Encode(rutaQR + lblCodigo.Text.TrimEnd + "&Division=" + division + "&Consecutivo=" + lblConsectivo.Text.TrimEnd)
        Dim qr As System.Drawing.Image
        qr = img


        Dim ms As New MemoryStream

        Using (ms)
            qr.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim imageBytes As Byte() = ms.ToArray()
            imgqr.ImageUrl = "data:image/gif;base64," + Convert.ToBase64String(imageBytes)
            imgqr.Width = 200
            imgqr.Height = 200
            Dim key As String = Guid.NewGuid.ToString
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), key, "abrirModal()", True)


        End Using

    End Sub



    Protected Sub ibtnLinea_Click(sender As Object, e As ImageClickEventArgs)
        Response.Redirect("~/Pages/Solicitud/Reportes/LineaTiempo.aspx?Codigo=" + lblCodigo.Text.TrimEnd)
        '  ibtnLinea.
    End Sub


    Protected Sub ibtnCambios_Click(sender As Object, e As ImageClickEventArgs)
        Response.Redirect("~/Pages/Solicitud/Reportes/Informe.aspx?Codigo=" + lblCodigo.Text + "")
    End Sub

    Protected Sub ibtnTermopares_Click(sender As Object, e As ImageClickEventArgs)
        Response.Redirect("~/Pages/Solicitud/Pruebas/frmTermopares.aspx?Codigo=" + lblCodigo.Text + "")
    End Sub



    Protected Sub ibtnTab_Click(sender As Object, e As ImageClickEventArgs)
        Response.Redirect("~/Pages/Solicitud/Reportes/tabPanel.aspx?Codigo=" + lblCodigo.Text + "")
    End Sub

    Protected Sub ibtnGraficas_Click(sender As Object, e As ImageClickEventArgs)
        ' Response.Redirect("~/Pages/Solicitud/Reportes/Informe.aspx?Codigo=" + lblCodigo.Text + "")
    End Sub

    Protected Sub ibtnReportePruebas_Click(sender As Object, e As ImageClickEventArgs)
        Response.Redirect("~/Pages/Solicitud/Reportes/RepPruebas.aspx?Codigo=" + lblCodigo.Text + "")
    End Sub


    Protected Sub ibtnReporteSolicitud_Click(sender As Object, e As ImageClickEventArgs)
        Response.Redirect("~/Pages/Solicitud/Reportes/RepSolicitud.aspx?Codigo=" + lblCodigo.Text + "")
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''INICIO DE CHECK LIST '''''''''''''''''''''''''''''''''''''''''
    Function CreateRow(Text As String, Value As String, dt As DataTable) As DataRow

        Dim dr As DataRow = dt.NewRow()
        dr(0) = Text
        dr(1) = Value

        Return dr

    End Function
    Private Sub cargarddlPruebas()
        Dim DTOrigin As DataTable = BLL.Pru_Eventos_BLL.consultar_pruebas_y_eventos_2(lblCodigo.Text, ddlTipo.SelectedValue)
        ddlPruebasEventos.DataSource = DTOrigin
        ddlPruebasEventos.DataTextField = "Tipo_Ensayo"
        ddlPruebasEventos.DataValueField = "id"
        ddlPruebasEventos.DataBind()


    End Sub
    Private Sub cargarCheck()
        Dim DTOrigin As DataTable = BLL.Solicitud_Check_Req_BLL.consulta_secuencia("consultar_secuencia", 0, lblCodigo.Text, hfNum.Value, hfIDEnsayoPrueba.Value, ddlTipo.SelectedValue)


        Try
            lblRequisito.Text = DTOrigin.Rows(0).Item(4)

            If (DTOrigin.Rows(0).Item(3).ToString.Contains(",")) Then
                Dim DTOriginValores As String() = DTOrigin.Rows(0).Item(3).ToString.Split(",")
                lbOpciones.Visible = True
                tbOpciones.Visible = False

                Dim dt As DataTable = New DataTable()
                dt.Columns.Add(New DataColumn("ID", GetType(String)))
                dt.Columns.Add(New DataColumn("Elementos", GetType(String)))
                For Each datos As String In DTOriginValores
                    dt.Rows.Add(CreateRow(datos, datos.TrimEnd, dt))
                Next


                lbOpciones.DataSource = dt
                lbOpciones.DataTextField = "ID".TrimEnd
                lbOpciones.DataValueField = "ID".TrimEnd
                lbOpciones.DataBind()
                Try


                    Dim Seleccionar As String() = DTOrigin.Rows(0).Item(3).ToString.TrimEnd().Split(",")
                    lblEleccion.Text = DTOrigin.Rows(0).Item(3).ToString.TrimEnd()


                    For a As Integer = 0 To Seleccionar.Length Step 1

                        If (lbOpciones.Items(a).Selected = Seleccionar(a)) Then



                            Try
                                lbOpciones.Items(a).Selected = True
                            Catch ex As Exception

                            End Try
                        End If

                    Next
                Catch ex As Exception

                End Try




            Else
                tbOpciones.Text = DTOrigin.Rows(0).Item(3).ToString.TrimEnd
                lblEleccion.Text = DTOrigin.Rows(0).Item(3).ToString.TrimEnd()
                tbOpciones.Visible = True
                lbOpciones.Visible = False

            End If
            lbtnAnterior.Visible = True
            lblEstadoCheck.Visible = True
            lblRequisito.Visible = True

            hfIDRequerimiento.Value = DTOrigin.Rows(0).Item(0).ToString.TrimEnd
            hfIDCheck.Value = DTOrigin.Rows(0).Item(2).ToString.TrimEnd
            lblEstadoCheck.Text = DTOrigin.Rows(0).Item(9).ToString.TrimEnd
        Catch ex As Exception
            hfNum.Value = Integer.Parse(hfNum.Value) - 1
            MuestraErrorToast("Aun no existe requerimientos para este ensayo, dile al administrador que los agrege.", 3, True)
            lbtnSiguiente.Enabled = False
        End Try




    End Sub

    Protected Sub ibtnCheck_Click(sender As Object, e As ImageClickEventArgs)
        cargarddlPruebas()
        lbtnSiguiente.Visible = False
        lbtnAnterior.Visible = False
        lblEstadoCheck.Visible = False
        lblRequisito.Visible = False
        lbOpciones.Visible = False
        tbOpciones.Visible = False


        Dim key As String = Guid.NewGuid.ToString
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), key, "abrirModal('modalCheck')", True)
        MuestraErrorToast("Listo", 0, True)
    End Sub

    Protected Sub lbtnProcesar_Click(sender As Object, e As EventArgs)
        If (ddlPruebasEventos.SelectedValue.Length > 0) Then
            lbtnSiguiente.Visible = True
            hfIDEnsayoPrueba.Value = ddlPruebasEventos.SelectedValue.Split("|")(0)
            cargarCheck()
            hfTipoInicioFin.Value = ddlTipo.SelectedValue
            MuestraErrorToast("", 0, True)
        Else
            MuestraErrorToast("No es posible continuar sin elegir un ensayo", 3, True)
            lbOpciones.Visible = False
            tbOpciones.Visible = False
            lblRequisito.Visible = False
            lblEstadoCheck.Visible = False
            lbtnSiguiente.Visible = True


        End If

    End Sub

    Protected Sub lbtnSiguiente_Click(sender As Object, e As EventArgs)
        If (lblEstadoCheck.Text.Equals("Finalizado")) Then
            hfQueryCheck.Value = "Modificar"
        Else
            hfQueryCheck.Value = "Insertar"
        End If
        Dim opcion As String = ""
        If (lbOpciones.Visible) Then
            opcion = obtTiposReg()
        Else
            opcion = tbOpciones.Text.TrimEnd
        End If
        Try
            BLL.Solicitud_Check_Req_BLL.inserta_actualiza_elimina_(hfQueryCheck.Value, hfIDCheck.Value, lblCodigo.Text, hfIDRequerimiento.Value, ddlPruebasEventos.SelectedValue.Split("|")(0), opcion, Session("Usuario").ToString)

        Catch ex As Exception

        End Try
        hfNum.Value = Integer.Parse(hfNum.Value) + 1
        cargarCheck()

        MuestraErrorToast("Agrego el cambio", 1, True)
    End Sub

    Protected Sub ddlTipo_SelectedIndexChanged(sender As Object, e As EventArgs)

        cargarddlPruebas()
        MuestraErrorToast("Listo", 0, True)

    End Sub
    Private Function obtTiposReg() As String
        Dim l As New List(Of String)
        For Each li As ListItem In lbOpciones.Items
            If li.Selected Then
                l.Add(li.Value)
            End If
        Next
        Return String.Join(",", l.ToArray)
    End Function
    Protected Sub lbtnAnterior_Click(sender As Object, e As EventArgs)
        If (hfNum.Value.Equals("1")) Then
        Else
            hfNum.Value = Integer.Parse(hfNum.Value) - 1
        End If
        lbtnSiguiente.Enabled = True
        cargarCheck()
        MuestraErrorToast("Listo", 0, True)
    End Sub
End Class