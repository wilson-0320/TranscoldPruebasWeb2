Imports MessagingToolkit.QRCode.Codec
Imports System.Drawing
Imports System.IO

Public Class Solicitud
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

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

        Dim fin As String = DTOrig.Rows(0).Item(0).ToString
        'Si fin tienen texto, quiere decir que ya hay una fecha final
        If (fin.Length > 5) Then

            lbtnGuardarDivision.Enabled = False
            lbtnGuardarEnsayos.Enabled = False
            lbtnGuardarEnsayosContratos.Enabled = False
            lbtnGuardarSolicitud.Enabled = False
            lbtnEliminar.Enabled = False
            Return False

        Else
            '   lbtnGuardarDivision.Enabled = True
            '   lbtnGuardarEnsayos.Enabled = True
            ' lbtnGuardarEnsayosContratos.Enabled = True
            'lbtnGuardarSolicitud.Enabled = True
            'lbtnEliminar.Enabled = True
            Return True

        End If

    End Function


    Private Sub iniciarControles(ByVal bandera As Boolean, ByVal Codigo As String)
        Dim agregarP As Boolean = Roles("Administrador,JefeLab,JefeRefri", 1)
        Dim eliminarP As Boolean = Roles("Administrador,JefeLab,JefeRefri", 3)
        Dim modificarP As Boolean = Roles("Administrador,JefeLab,JefeRefri", 2)
        'Si se recibe un codigo de prueba es true

        If (bandera) Then
            Try


                Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Actualiza2", New Object() {
                                                                    New Object() {"@Estado", "consulta"},
                                                                    New Object() {"@Codigo", Codigo}
                                                                    }, CommandType.StoredProcedure).Tables(0)

                lblConsectivo.Text = DTOrig.Rows(0).Item(19)
                lblCodigo.Text = DTOrig.Rows(0).Item(0)
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

                ddlCarga.SelectedValue = DTOrig.Rows(0).Item(13)
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

            '   MuestraErrorToast(Roles("Administrador,JefeLab,JefeRefri", 3).ToString, 3, True)

        End If



        lbtnEliminar.Enabled = eliminarP
        lbtnGuardarSolicitud.Enabled = agregarP
        lbtnGuardarEnsayos.Enabled = agregarP
        lbtnGuardarDivision.Enabled = agregarP
        lbtnGuardarEnsayosContratos.Enabled = agregarP


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
                ddlCarga.DataSource = DTOrig

                ddlCarga.DataValueField = "ID"
                ddlCarga.DataTextField = "Descripcion"
                ddlCarga.DataBind()

        End Select


    End Sub
    'Devuelve el correlativo correspondiente
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
        MuestraErrorToast("Listo", 1, True)
    End Sub

    Protected Sub lbtnGuardarSolicitud_Click(sender As Object, e As EventArgs)
        If validarCrud() Then
            guardarCrudSolicitud("Nuevo")
            MuestraErrorToast("Listo", 1, True)
        End If
    End Sub
    Protected Sub lbtnGuardarEnsayos_Click(sender As Object, e As EventArgs)
        If (lblConsectivo.Text.Length > 0) Then
            BLL.Solicitud_Ensayo_BLL.insertar(lblCodigo.Text, "Sol", ddlEnsayos.SelectedValue)
            cargarEnsayosRepeater(1, "Sol")
            MuestraErrorToast("Listo", 1, True)
        Else
            MuestraErrorToast("No es posible", 3, True)
        End If

    End Sub
    Protected Sub lbtnGuardarEnsayosContratos_Click(sender As Object, e As EventArgs)
        If (lblConsectivo.Text.Length > 0) Then
            BLL.Solicitud_Ensayo_BLL.insertar(lblCodigo.Text, "Ofr", ddlEnsayosOfrecidos.SelectedValue)
            cargarEnsayosRepeater(2, "Ofr")
            MuestraErrorToast("Listo", 1, True)
        Else
            MuestraErrorToast("No es posible", 3, True)
        End If

    End Sub

    Protected Sub lbtnGuardarDivision_Click(sender As Object, e As EventArgs)
        If (lblConsectivo.Text.Length > 0) Then
            BLL.Solicitud_Division_BLL.insertar(lblCodigo.Text, tbDivision.Text)
            cargarDivisionReporte()
            MuestraErrorToast("Listo", 1, True)
        Else
            MuestraErrorToast("No es posible", 3, True)

        End If
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

        MuestraErrorToast(BLL.Solicitud_BLL.Eliminar(lblCodigo.Text, "eliminar"), 1, True)
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
            MuestraErrorToast("Listo", 1, True)

        End If
    End Sub
    Protected Sub repeaterEnsayos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") And Roles("Administrador,JefeLab,JefeRefri", 3) And consultarFechaFin() Then
            BLL.Solicitud_Ensayo_BLL.eliminar(Integer.Parse(e.CommandArgument))
            cargarEnsayosRepeater(1, "Sol")
            MuestraErrorToast("Listo", 1, True)

        End If
    End Sub

    Protected Sub repeaterDivision_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") And Roles("Administrador,JefeLab,JefeRefri", 3) And consultarFechaFin() Then
            BLL.Solicitud_Division_BLL.eliminar(Integer.Parse(e.CommandArgument))
            cargarDivisionReporte()
            MuestraErrorToast("Listo", 1, True)
        ElseIf (e.CommandName = "QR") Then
            Codigoqr(e.CommandArgument)
        End If
    End Sub


    Private Sub Codigoqr(ByVal division As String)
        Dim encoder As QRCodeEncoder = New QRCodeEncoder()
        Dim img As Bitmap
        img = encoder.Encode("www.fogelonline.com/TranscoldPruebasWeb2/Pages/Solicitud/Reportes/tabPanel.aspx?Codigo=" + lblCodigo.Text.TrimEnd + "&Division=" + division + "&Consecutivo=" + lblConsectivo.Text.TrimEnd)
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
End Class