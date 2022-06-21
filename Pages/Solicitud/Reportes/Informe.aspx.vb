Public Class Informe
    Inherits MiPageN
    Dim TAF As New TAF
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            chargeListElementos()
            limpiaEnControles()

            If Not Request.QueryString("Codigo") Is Nothing Then
                hfCodigo.Value = Request.QueryString("Codigo")
                tbCodigo.Text = hfCodigo.Value
                Try
                    hfElementID.Value = Session("Usuario").ToString()
                Catch ex As Exception

                End Try


                cargarReportRepeatet("LineaTiempoIntegrado2")

                cargarPendienteRevision()
                cargarImagenes(hfElementID.Value, "ElemSol")
                consultarFechaFin()
                cargarDivisionReporte()

            End If
            'Agregar:
            'ViewState("usuario") = User.Identity.Name


            Try
                Dim computer_name As String() = System.Net.Dns.GetHostEntry(Request.ServerVariables("remote_addr")).HostName.Split(New Char() {"."})
                tbComputadora.Text = computer_name(0).ToString()
            Catch ex As Exception
                tbComputadora.Text = "NoLeíble"
            End Try

            Page.Form.Attributes.Add("enctype", "multipart/form-data")
        End If



    End Sub


    Private Sub reiniciarControles()

        tbCodigoCrud.Visible = False
        panelHistorico.Visible = False

        listCodigoCrud.Visible = False

        btnEliminarCrud.Visible = False
        ddlCargaRefrigerante.Visible = False
        tbCantidadCrud.Visible = False
        tbPrecioCrud.Visible = False
        panelTxtEnriquecido.Visible = False
        btnGuardarCrud.Visible = True
        btnCancelarModificacion.Visible = False
        externoBoolean()
        cbExterno.Checked = False
        ''Fase
        'If (Integer.Parse(hfRoles.Value) = 1) Then


        cbPresentacion.Enabled = Roles("Administrador,JefeLab,JefeRefri", 2)
        cbPresentacion.Checked = Roles("Administrador,JefeLab,JefeRefri", 2)
        btnEliminarCrud.Enabled = Roles("Administrador,JefeLab,JefeRefri,SupLab,SupMet,Pruebas", 2)
        btnGuardarCrud.Enabled = Roles("Administrador,JefeLab,JefeRefri,SupLab,SupMet,Pruebas", 1)
        btnEliminarCrud.Enabled = Roles("Administrador,JefeLab,JefeRefri,SupLab,SupMet,Pruebas", 3)
        btnEnviarRevision.Enabled = Roles("Administrador,JefeLab,JefeRefri,SupLab,SupMet,Pruebas", 1)
        btnGuardarFoto.Enabled = Roles("Administrador,JefeLab,JefeRefri,SupLab,SupMet,Pruebas", 1)




    End Sub
    Private Sub MandaCorreosSolicitudEnviada()
        Dim Asunto As String = "Se envió una solicitud para la Solicitud " + hfCodigo.Value
        Dim DT As DataTable = TAF.TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Consulta", New Object() {
                                                         New Object() {"@Consulta", "CorreosEnvSol"},
                                                         New Object() {"@Filtro1", hfCodigo.Value}
                                                         }, CommandType.StoredProcedure).Tables(0)
        For Each Row As DataRow In DT.Rows
            TAF.Varios.Enviar_Mail(New String() {Row("Correo")}, Asunto, Row("Texto"), Nothing, True)
        Next
    End Sub

    Private Sub reiniciarListas()
        Try
            listElemento.SelectedValue = ""
            listCodigoCrud.SelectedValue = ""
            ddlCargaRefrigerante.SelectedValue = ""
        Catch ex As Exception

        End Try

    End Sub
    Private Sub limpiaEnControles()
        ' listElemento.SelectedValue = listElemento.Items(0).Value

        tbCodigoCrud.Text = ""
        cbExterno.Checked = False
        __tbCodigoEditorCrud.Text = ""
        tbDescripcionFoto.Text = ""
        tbComentariosObservacionesCrud.Text = ""
        tbPrecioCrud.Text = ""
        tbCantidadCrud.Text = ""
        hfTipoCrud.Value = "insertar"
        fnEnviado.Text = ""
        fnRevisado.Text = ""
        hfElementID.Value = tbCodigo.Text

        hfTipoImagen.Value = "ElemSol"
        reiniciarControles()
        reiniciarListas()



    End Sub

    Private Sub consultarFechaFin()
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Select Estado From Pru_Solicitud where Codigo=@Codigo", New Object() {
                                                                 New Object() {"@Codigo", tbCodigo.Text}
                                                                 }, CommandType.Text).Tables(0)

        Dim fin As String = DTOrig.Rows(0).Item(0).ToString

        If (fin.Equals("Finalizada")) Then

            btnGuardarCrud.Enabled = False
            btnEnviarRevision.Enabled = False
            cbPresentacion.Enabled = False
            cbPresentacion.Checked = False
            btnGuardarFoto.Enabled = False
        Else
            btnGuardarCrud.Enabled = True
            btnEnviarRevision.Enabled = True

        End If

    End Sub
    Function CreateRow(Text As String, Value As String, dt As DataTable) As DataRow

        Dim dr As DataRow = dt.NewRow()
        dr(0) = Text
        dr(1) = Value

        Return dr

    End Function
    Private Function obtTiposReg() As String
        Dim l As New List(Of String)
        For Each li As ListItem In listOpciones.Items
            If li.Selected Then
                l.Add(li.Value)
            End If
        Next
        Return String.Join(",", l.ToArray)
    End Function
    Private Function externoBoolean()
        If (cbExterno.Checked) Then

            cbExterno.Checked = True
            Return True

        Else
            cbExterno.Checked = False
            Return False
        End If
    End Function


    Private Sub cargarDivisionReporte()
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Division_ABCD", New Object() {
                                                                    New Object() {"@query", "consultar_por_codigo2"},
                                                                    New Object() {"@codigo", tbCodigo.Text}
                                                                    }, CommandType.StoredProcedure).Tables(0)
        ddlDivision.DataSource = DTOrig
        ddlDivision.DataTextField = "Descripcion"
        ddlDivision.DataValueField = "id"
        ddlDivision.DataBind()




    End Sub
    Private Sub chargeListElementos()


        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Elemento_Consulta", New Object() {
                                                                   New Object() {"@Tipo", "ConTitulosCat"}
                                                                   }, CommandType.StoredProcedure).Tables(0)

        listElemento.DataSource = DTOrig
        listElemento.DataTextField = "Muestra"
        listElemento.DataValueField = "ID"
        listElemento.DataBind()
    End Sub



    Private Sub cargarReportRepeatet(ByVal cualRep As String)

        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Reporte_LineaTiempo", New Object() {
                                                                    New Object() {"@Codigo", hfCodigo.Value},
                                                                    New Object() {"@CualRep", cualRep},
                                                                    New Object() {"@Rango_Inicio", 0},
                                                                    New Object() {"@Rango_Fin", 0},
                                                                    New Object() {"@minutos", 1440},
                                                                    New Object() {"@TiposRegistro", obtTiposReg()}
                                                                    }, CommandType.StoredProcedure).Tables(0)
        If (cualRep.Equals("LineaTiempoIntegrado2")) Then
            repeaterReporte.DataSource = DTOrig
            repeaterReporte.DataBind()
        Else

        End If




    End Sub

    Protected Sub ddlDivision_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Protected Sub listElemento_SelectedIndexChanged(sender As Object, e As EventArgs)
        If sender.SelectedValue < -1 Then ' Menor que 0 (es titulo) y no es -1 (vacio)
            sender.SelectedValue = -sender.SelectedValue

        End If
        If (sender.SelectedValue > 0) Then
            tbCodigoCrud.Text = ""
            tbPrecioCrud.Text = "0"
            tbCantidadCrud.Text = "0"
            ElementoAlterado(sender.SelectedValue)
            visiblidad(sender.SelectedValue)
            hfListElemento.Value = sender.SelectedValue

        End If
        MuestraErrorToast("", 0, True)
    End Sub
    Private Sub ElementoAlterado(ByVal elementoId As Integer)
        If elementoId = -1 Then

        Else
            Try
                'Este es el procedimiento: Pru_Elemento_Valor_Consulta
                Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Elemento_Valor_Consulta2", New Object() {
                                                            New Object() {"@Elemento_ID", elementoId}
                                                            }, CommandType.StoredProcedure).Tables(0)




                If (DTOrig.Rows(0).Item(0).ToString.Contains(",")) Then
                        Dim DTOriginValores As String() = DTOrig.Rows(0).Item(0).ToString.Split(",")


                        listCodigoCrud.Visible = True
                        tbCodigoCrud.Visible = False

                        Dim dt As DataTable = New DataTable()
                        dt.Columns.Add(New DataColumn("valores", GetType(String)))
                    dt.Columns.Add(New DataColumn("ids", GetType(String)))
                    For Each datos As String In DTOriginValores
                            dt.Rows.Add(CreateRow(datos, datos.TrimEnd, dt))
                        Next


                    listCodigoCrud.DataSource = dt
                    listCodigoCrud.DataTextField = "valores".TrimEnd
                        listCodigoCrud.DataValueField = "valores".TrimEnd
                        listCodigoCrud.DataBind()


                    Else
                        listCodigoCrud.DataSource = DTOrig
                        listCodigoCrud.DataTextField = "valores"
                        listCodigoCrud.DataValueField = "valores"
                        listCodigoCrud.DataBind()

                        listCodigoCrud.Visible = True
                        tbCodigoCrud.Visible = False


                    End If





                Catch ex As Exception
                listCodigoCrud.Visible = False
                tbCodigoCrud.Visible = True

            End Try



        End If

    End Sub
    Protected Sub btnGenerar_Click(sender As Object, e As EventArgs)
        If (tbCodigo.Text().Length > 0) Then


            hfCodigo.Value = tbCodigo.Text
            hfElementID.Value = tbCodigo.Text
            panelLineaTiempo.Visible = True


            '  llamarFuncionesJavascript("", "")
            cargarReportRepeatet("LineaTiempoIntegrado2")
            consultarFechaFin()
            cargarPendienteRevision()
            cargarImagenes(hfElementID.Value, hfTipoImagen.Value)
            btnGuardarCrud.Visible = True
            cargarDivisionReporte()


            limpiaEnControles()

        Else

            MuestraErrorToast("", 0, True)


        End If
    End Sub
    Private Sub cargarPendienteRevision()

        Try
            'Este es el procedimiento: Pru_Elemento_Valor_Consulta
            Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Elemento_Consulta", New Object() {
                                                            New Object() {"@Solicitud_Cod", tbCodigo.Text}
                                                            }, CommandType.StoredProcedure).Tables(0)

            repeaterPendienteRevision.DataSource = DTOrig
            repeaterPendienteRevision.DataBind()
        Catch ex As Exception


        End Try

    End Sub

    Private Sub cargarImagenes(ByVal elementoId As String, ByVal Tipo As String)

        Try

            'Este es el procedimiento: Pru_Elemento_Valor_Consulta
            Dim DTOrig As DataTable = BLL.Archivo_BLL.consultar(Tipo, elementoId)



            repeaterImagenes.DataSource = DTOrig
            repeaterImagenes.DataBind()
        Catch ex As Exception


        End Try

    End Sub

    Private Sub visiblidad(ByVal elementoId As Integer)

        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Select Precio,Cantidad,Unico,CodigoEnExactus from [TranscoldPruebas].[dbo].[Pru_Elemento] where ID=@Elemento_ID;", New Object() {
                                                           New Object() {"@Elemento_ID", elementoId}
                                                           }, CommandType.Text
                                                           ).Tables(0)

        tbCodigoCrud.Enabled = True

        If (DTOrig.Rows(0).Item(0) = False And DTOrig.Rows(0).Item(1) = False And DTOrig.Rows(0).Item(2) = False) Then
            'panelCrud.Visible = False



            tbCodigoCrud.Enabled = False
            panelTxtEnriquecido.Visible = True


        Else
            panelTxtEnriquecido.Visible = False

        End If

        tbPrecioCrud.Visible = DTOrig.Rows(0).Item(0)
        tbCantidadCrud.Visible = DTOrig.Rows(0).Item(1)
        cbExterno.Visible = DTOrig.Rows(0).Item(3)
        cbExterno.Checked = DTOrig.Rows(0).Item(3)

        If (elementoId = 136) Then
            ddlCargaRefrigerante.Visible = True
        Else
            ddlCargaRefrigerante.Visible = False
        End If


    End Sub

    Protected Sub btnGuardarFoto_Click(sender As Object, e As EventArgs)
        If Request.Files.Count > 0 Then
            GuardaArchivo(Request.Files.Count)
        End If
        cargarImagenes(hfElementID.Value, hfTipoImagen.Value)

        tbDescripcionFoto.Text = ""
    End Sub

    Private Sub GuardaArchivo(ByVal IdArch_ As Integer)

        'Quitar:
        '   Dim Path As String = "D:\EstaticosWeb\TranscoldPruebasWeb\"
        Dim path As String = "\EstaticosWeb\TranscoldPruebasWeb\"
        'Dim Path As String = "C:\Users\Inspiron 5577\Pictures\Saved Pictures\"
        path += hfTipoImagen.Value
        path += "\" + hfElementID.Value

        'pathBD += hfCodigo.Value.Replace("/", "-")
        ' pathBD += "\"

        If Not System.IO.Directory.Exists(Path) Then
            System.IO.Directory.CreateDirectory(Path)
        End If
        Dim IdArch As Integer
        Dim uploadedFiles As HttpFileCollection = Request.Files
        'Dim contar As Integer
        Try


            For i As Integer = 0 To uploadedFiles.Count - 1
                Dim userPostedFile As HttpPostedFile = uploadedFiles(i)
                Dim nomArch As String = UI_Lib.htmlSeguro(userPostedFile.FileName)
                Dim ArchPath As String = ""
                If userPostedFile.ContentLength > 0 Then
                    ArchPath = Path + "\" + nomArch
                    userPostedFile.SaveAs(ArchPath)
                    'If IdArch_ = -1 Then
                    BLL.Archivo_BLL.insertar(hfTipoImagen.Value.TrimEnd, hfElementID.Value.TrimEnd, nomArch + "-" + tbDescripcionFoto.Text, nomArch)

                    IdArch = BLL.Archivo_BLL.ultimo_id(0)
                    '  Else
                    '     IdArch = IdArch_
                    '   End If
                End If

                cargarImagenes(hfElementID.Value, hfTipoImagen.Value)
                ArchivosLib.CreaThumbnail(ArchPath)
            Next

        Catch ex As Exception
            MuestraErrorToast("Error al cargar el archivo", 4, True)
        End Try
    End Sub

    Protected Sub ddlCargaRefrigerante_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try

            If ddlCargaRefrigerante.SelectedValue = "Oz->Lbs" Then
                tbCantidadCrud.Text = tbCantidadCrud.Text / 16.0
            ElseIf ddlCargaRefrigerante.SelectedValue = "Gr->Lbs" Then
                tbCantidadCrud.Text = tbCantidadCrud.Text / 453.6
            End If
            tbCantidadCrud.Text = tbCantidadCrud.Text.Replace(",", ".")
        Catch ex As Exception

        End Try
        MuestraErrorToast("", 0, True)
        ddlCargaRefrigerante.SelectedValue = ""
    End Sub

    Protected Sub btnEnviarRevision_Click(sender As Object, e As EventArgs)
        enviarRevision()
    End Sub



    Protected Sub btnGuardarCrud_Click(sender As Object, e As EventArgs)
        validacionCrud()
        cargarImagenes(hfElementID.Value, hfTipoImagen.Value)
        limpiaEnControles()
        cargarReportRepeatet("LineaTiempoIntegrado2")
    End Sub
    Protected Sub btnCancelarModificacion_Click(sender As Object, e As EventArgs)
        limpiaEnControles()
        MuestraErrorToast("", 0, True)
        cargarImagenes(hfElementID.Value, hfTipoImagen.Value)
    End Sub

    Protected Sub btnEliminarCrud_Click(sender As Object, e As EventArgs)

        hfTipoCrud.Value = "eliminarHistorico"
        validacionCrud()

        limpiaEnControles()
        cargarPendienteRevision()
        cargarReportRepeatet("LineaTiempoIntegrado2")
        cargarImagenes(hfElementID.Value, hfTipoImagen.Value)

    End Sub
    Private Sub enviarRevision()

        Dim msj As String = ""
        'TAF.QueriesTA.Pru_Solicitud_Hist_Actualiza(Nothing, "Estado", CorrelativoLabel.Text, "Enviada", ObservacionesPruebaTextBox.Text, User.Identity.Name, msj)
        'msj = BLL.Solicitud_Hist_BLL.ActuEstado(hfCodigo.Value, "Enviada", "", User.Identity.Name, 0)
        'Modo pruebas
        If (Session("Usuario") Is Nothing) Then
        Else
            msj = BLL.Solicitud_Hist_BLL.ActuEstado(hfCodigo.Value, "Enviada2", "", Session("Usuario").ToString, ddlDivision.SelectedValue)

        End If

        If Not BLL.Solicitud_Hist_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Solicitud_Hist_BLL.MsjError, 4, True)
        Else
            cargarPendienteRevision()
            MandaCorreosSolicitudEnviada()
            cargarReportRepeatet("LineaTiempoIntegrado2")
            MuestraErrorToast("Listo", 1, True)
        End If

    End Sub


    Private Sub validacionCrud()
        Dim tipo As String = hfTipoCrud.Value
        Dim valores As String = ""
        ' tbCodigoCrud.Text = listCodigoCrud.Text + tbCodigoEditorCrud.Text + tbCodigoCrud.Text
        If (tbCodigoCrud.Visible And tbCodigoCrud.Enabled) Then
            valores = (tbCodigoCrud.Text)

        ElseIf (listCodigoCrud.Visible) Then
            valores = listCodigoCrud.Text

        ElseIf (panelTxtEnriquecido.Visible) Then

            valores = __tbCodigoEditorCrud.Text.Replace("¡", "<")
            valores = valores.Replace("!", ">")
            valores = valores.Replace("3*", "/")


        End If
        Dim bandera As Boolean = True
        Try
            If (tbPrecioCrud.Visible) Then
                If (Convert.ToDouble(tbPrecioCrud.Text) > 0) Then
                    ' bandera = True
                Else
                    bandera = False
                End If

            End If
            If (tbCantidadCrud.Visible) Then
                If (Convert.ToDouble(tbCantidadCrud.Text) > 0) Then
                    'bandera = True
                Else
                    bandera = False
                End If
            End If

        Catch ex As Exception
            bandera = False

        End Try


        Dim msj As String = ""

        If ((valores.Length > 0 And bandera) Or tipo.Equals("eliminarHistorico")) Then


            If (tipo.Equals("insertar")) Then
                msj = BLL.Solicitud_Elemento_BLL.Inserta(hfCodigo.Value, listElemento.SelectedValue, valores, tbCantidadCrud.Text, tbPrecioCrud.Text, tbComentariosObservacionesCrud.Text, externoBoolean(), Session("Usuario").ToString)
            ElseIf (tipo.Equals("modificarElemento")) Then
                msj = BLL.Solicitud_Elemento_BLL.modificarEliminar("Modificar2", hfCodigo.Value, Int32.Parse(hfIDElmentoCrud.Value), listElemento.SelectedValue, valores, tbCantidadCrud.Text, tbPrecioCrud.Text, tbComentariosObservacionesCrud.Text, externoBoolean(), Session("Usuario").ToString)
            ElseIf (tipo.Equals("modificarHistorico")) Then
                If (fnRevisado.Text.Length < 1) Then
                    fnRevisado.Text = fnEnviado.Text
                End If
                msj = BLL.Solicitud_Hist_Elem_BLL.modificarEliminarHistorico("ModificarCompleto", Int32.Parse(hfIDElmentoCrud.Value), listElemento.SelectedValue, valores, tbCantidadCrud.Text, tbPrecioCrud.Text, tbComentariosObservacionesCrud.Text, externoBoolean(), Convert.ToDateTime(fnEnviado.Text), Convert.ToDateTime(fnRevisado.Text))
            ElseIf (tipo.Equals("eliminarHistorico")) Then
                If (fnRevisado.Text.Length < 1) Then
                    fnRevisado.Text = fnEnviado.Text
                End If
                msj = BLL.Solicitud_Hist_Elem_BLL.modificarEliminarHistorico("Eliminar", Int32.Parse(hfIDElmentoCrud.Value), listElemento.SelectedValue, valores, tbCantidadCrud.Text, tbPrecioCrud.Text, tbComentariosObservacionesCrud.Text, externoBoolean(), Convert.ToDateTime(fnEnviado.Text), Convert.ToDateTime(fnRevisado.Text))

            End If


            If msj.StartsWith("Error:") Then
                '  alerta.Text = msj + ""
                MuestraErrorToast(msj, 4, True)

            Else

                ' limpiaEnControles()
                cargarPendienteRevision()
                MuestraErrorToast("Listo", 1, True)

            End If
        Else
            MuestraErrorToast("Listo", 2, True)
        End If

        tbComentariosObservacionesCrud.Text = msj + ""




    End Sub


    Private Sub llenarFormualrioEdicion(ByVal opcion As String, ByVal idTabla As Int32)


        Dim DTOrig As DataTable

        If (opcion.Equals("temporal")) Then
            DTOrig = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Elemento_Actualiza", New Object() {
                                                         New Object() {"@Tipo", "consultaElemento"},
                                                         New Object() {"@ID", idTabla},
                                                         New Object() {"@Solicitud_Cod", ""},
                                                         New Object() {"@Elemento_ID", ""},
                                                         New Object() {"@Valor", ""},
                                                         New Object() {"@Cantidad", 0},
                                                         New Object() {"@Precio", 0},
                                                         New Object() {"@Comentario", ""},
                                                         New Object() {"@EsExterno", True},
                                                         New Object() {"@usuario", ""}
                                                         }, CommandType.StoredProcedure).Tables(0)
            hfTipoCrud.Value = "modificarElemento"
            hfTipoImagen.Value = "ElemSol"
        ElseIf (opcion.Equals("Historico")) Then
            DTOrig = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Elemento_Actualiza", New Object() {
                                                         New Object() {"@Tipo", "consultaHistorico"},
                                                         New Object() {"@ID", idTabla},
                                                         New Object() {"@Solicitud_Cod", ""},
                                                         New Object() {"@Elemento_ID", ""},
                                                         New Object() {"@Valor", ""},
                                                         New Object() {"@Cantidad", 0},
                                                         New Object() {"@Precio", 0},
                                                         New Object() {"@Comentario", ""},
                                                         New Object() {"@EsExterno", True},
                                                         New Object() {"@usuario", ""}
                                                         }, CommandType.StoredProcedure).Tables(0)
            hfTipoCrud.Value = "modificarHistorico"
            hfTipoImagen.Value = "ElemHist"

            lblUserPrueba.Text = DTOrig.Rows(0).Item(10) + ""
            lblUserRevisado.Text = DTOrig.Rows(0).Item(11) + ""

            fnEnviado.Text = DTOrig.Rows(0).Item(8) + ""
            fnRevisado.Text = DTOrig.Rows(0).Item(9) + ""
            lblEstadoTransaccion.Text = DTOrig.Rows(0).Item(7)



        End If



        Try
            hfIDElmentoCrud.Value = DTOrig.Rows(0).Item(0)
            hfElementID.Value = DTOrig.Rows(0).Item(0)


            'hfElementID.Value = DTOrig.Rows(0).Item(2)

            listElemento.SelectedValue = DTOrig.Rows(0).Item(1)
            ElementoAlterado(DTOrig.Rows(0).Item(1))
            visiblidad(DTOrig.Rows(0).Item(1))
            'hfListElemento.Value = DTOrig.Rows(0).Item(2)
            'listElemento.SelectedIndex = DTOrig.Rows(0).Item(2)

            '4
            Try
                tbCantidadCrud.Text = DTOrig.Rows(0).Item(3).ToString().Replace(",", ".")
                tbPrecioCrud.Text = DTOrig.Rows(0).Item(4).ToString().Replace(",", ".")
            Catch ex As Exception

            End Try

            tbComentariosObservacionesCrud.Text = DTOrig.Rows(0).Item(5)
            cbExterno.Checked = DTOrig.Rows(0).Item(6)


            If (listCodigoCrud.Visible) Then
                listCodigoCrud.SelectedValue = DTOrig.Rows(0).Item(2)

            ElseIf (tbCodigoCrud.Visible And tbCodigoCrud.Enabled) Then
                tbCodigoCrud.Text = DTOrig.Rows(0).Item(2)
            ElseIf (panelTxtEnriquecido.Visible) Then
                __tbCodigoEditorCrud.Text = DTOrig.Rows(0).Item(2).ToString.Replace("<", "¡")



            End If


        Catch ex As Exception

        End Try



        btnCancelarModificacion.Visible = True
        MuestraErrorToast("", 0, True)




    End Sub


    Protected Sub repeaterReporte_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "editarHistoricos") Then

            btnEliminarCrud.Visible = True

            btnCancelarModificacion.Visible = True

            llenarFormualrioEdicion("Historico", Int32.Parse(e.CommandArgument))
            hfElementID.Value = Int32.Parse(e.CommandArgument)
            hfTipoImagen.Value = "ElemHist"
            cargarImagenes(e.CommandArgument, hfTipoImagen.Value)
            btnCancelarModificacion.Visible = True
            panelHistorico.Visible = True
            tbComentariosObservacionesCrud.Focus()
            consultarFechaFin()

        ElseIf e.CommandName = "rechazarHistorico" Then

            BLL.Solicitud_Hist_BLL.rechazar(Integer.Parse(e.CommandArgument), Session("Usuario").ToString)
            cargarReportRepeatet("LineaTiempoIntegrado2")


        ElseIf e.CommandName = "aprobarHistorico" Then
            BLL.Solicitud_Hist_BLL.revisar_y_aprobar(Integer.Parse(e.CommandArgument), Session("Usuario").ToString)
            ''  TAF.SolHistElemTA.UpdateEstado("Aprobado", Integer.Parse(e.CommandArgument))
            ' TAF.SolHistTA.Update(hfCodigo.Value, Now, Now, "", "", "", "", "Revisada.", Integer.Parse(e.CommandArgument))
            cargarReportRepeatet("LineaTiempoIntegrado2")



        End If
        MuestraErrorToast("", 2, True)
    End Sub

    Protected Sub repeaterPendienteRevision_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Editar") Then
            MuestraErrorToast("", 0, True)
            llenarFormualrioEdicion("temporal", Integer.Parse(e.CommandArgument))

            cargarImagenes(e.CommandArgument, hfTipoImagen.Value)
        ElseIf e.CommandName = "Eliminar" Then

            BLL.Solicitud_Hist_BLL.Eliminar2(Integer.Parse(e.CommandArgument))
            MuestraErrorToast("Listo", 2, True)
            cargarReportRepeatet("LineaTiempoIntegrado2")
            cargarPendienteRevision()



        End If

    End Sub

    Protected Sub repeaterImagenes_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If e.CommandName = "Eli" Then

            BLL.Archivo_BLL.eliminar(Integer.Parse(e.CommandArgument))
            MuestraErrorToast("Listo", 2, True)
            cargarImagenes(hfElementID.Value, hfTipoImagen.Value)



        End If
    End Sub

    Protected Sub tbCodigoCrud_TextChanged(sender As Object, e As EventArgs)
        If (cbExterno.Checked And tbCodigoCrud.Text.Length > 0) Then
            listadoArticulos()
        End If
    End Sub
    Public Sub listadoArticulos()



        Dim TrSql As New TransacSQL
        Dim DT As DataTable = TrSql.EjecutarConsulta("refrigua",
                                                         "select 'Articulo: '+rf.articulo+ +'. Descripcion: '+rf.descripcion, rf.costo_std_dol costo " +
                                                         "from refrigua.refrigua.articulo rf " +
                                                         "where rf.articulo = @LikeTerm", New Object() {
                                                         New Object() {"@LikeTerm", tbCodigoCrud.Text}
                                                         }).Tables(0)
        Try
            tbPrecioCrud.Text = DT.Rows(0).Item(1)
            MuestraErrorToast(DT.Rows(0).Item(0).ToString, 2, True)
        Catch ex As Exception
            MuestraErrorToast(ex.Message, 4, True)
        End Try


    End Sub
End Class