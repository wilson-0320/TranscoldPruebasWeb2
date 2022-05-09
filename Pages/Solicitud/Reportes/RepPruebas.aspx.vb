Public Class RepPruebas
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Try
                inicializar()
                cargarddlCatalogo(3)
                cargarddlCatalogo(12)
                If Not Request.QueryString("Codigo") Is Nothing Then
                    tbCodigo.Text = Request.QueryString("Codigo")
                    cargarReportePruebas(0)

                End If
            Catch ex As Exception

            End Try


        End If

    End Sub
    Private Sub controlesRepeater()
        Dim mod1 As Boolean = Roles("Administrador,JefeLab,JefeRefri,SupLab,SupMet", 2)
        Dim eli1 As Boolean = Roles("Administrador,JefeLab,JefeRefri,SupLab,SupMet", 3)

        For index As Integer = 0 To repeaterPruebas.Items.Count - 1 Step 1
            'Modificar
            CType(repeaterPruebas.Items(index).FindControl("LinkButton1"), LinkButton).Visible = mod1
            'Eliminar
            CType(repeaterPruebas.Items(index).FindControl("LinkButton2"), LinkButton).Visible = eli1
        Next


    End Sub

    Private Sub inicializar()
        tbCodigo.Text = ""
        tbFecha.Text = ""
        tbPrueba.Text = ""
        tbWO.Text = ""
        tbSerie.Text = ""
        tbModelo.Text = ""
        tbCompresor.Text = ""
        tbEvaporador.Text = ""
        tbCondensador.Text = ""
        tbTermostato.Text = ""
        tbVoltaje.Text = ""
        tbRelay.Text = ""
        tbTipoEv.Text = ""
        tbTipoCon.Text = ""
        tbCapilar.Text = ""
        tbCapacitor.Text = ""
        tbProtector.Text = ""
        tbMae.Text = ""
        tbMac.Text = ""
        tbRefrigerante.Text = ""
        tbCodigoCompresor.Text = ""
        tbPrueba2.Text = ""
        tbCarga.Text = ""
        tbEstado.Text = ""
        tbComentarios.Text = ""
        hfID.Value = "-1"

        lbtnGuardar.Enabled = Roles("Administrador,JefeLab,JefeRefri,SupLab,SupMet", 1)
        lbtnCancelar.Visible = False
        Try
            ddlAprobado.SelectedValue = ""
            ddlTipoPrueba.SelectedValue = ""
            ddlCamara.SelectedValue = ""
        Catch ex As Exception

        End Try


    End Sub

    Private Sub cargarddlCatalogo(ByVal ID_Categoria As Integer)

        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Catalogo_Actualiza", New Object() {
                                                                  New Object() {"@Tipo", "consultarCat"},
                                                                  New Object() {"@Categoria_ID", ID_Categoria}
                                                                  }, CommandType.StoredProcedure).Tables(0)

        Select Case ID_Categoria
            Case 12
                ddlCamara.DataSource = DTOrig
                ddlCamara.DataTextField = "Descripcion"
                ddlCamara.DataValueField = "Descripcion"
                ddlCamara.DataBind()
            Case 3
                ddlTipoPrueba.DataSource = DTOrig
                ddlTipoPrueba.DataTextField = "Descripcion"
                ddlTipoPrueba.DataValueField = "Descripcion"
                ddlTipoPrueba.DataBind()

        End Select



    End Sub

    Private Function validarCrud() As Boolean

        For Each CampoTexto As TextBox In New TextBox() {
            tbCodigo, tbVoltaje, tbPrueba, tbFecha, tbCompresor
            }

            If CampoTexto.Text = "" Then
                MuestraErrorToast("Debe especificar el valor del campo " + CampoTexto.ToolTip, 3, True)
                CampoTexto.CssClass = "border-danger form-control"
                CampoTexto.Focus()
                Return False
            End If


        Next
        Return True

    End Function

    Private Sub cargarReportePruebas(ByVal ID As Integer)
        If (ID = 0) Then
            Dim DTorigin As DataTable = BLL.Prueba_BLL.consultar(tbPrueba.Text, tbWO.Text, tbSerie.Text, tbModelo.Text, tbCompresor.Text, ddlTipoPrueba.SelectedValue, tbEvaporador.Text,
                                                   tbCondensador.Text, tbTermostato.Text, tbVoltaje.Text, tbRelay.Text, tbTipoEv.Text, tbTipoCon.Text, tbCapilar.Text,
ddlAntiguo.SelectedValue, tbMae.Text, tbMac.Text, tbRefrigerante.Text, ddlAprobado.SelectedValue, tbCodigo.Text)


            repeaterPruebas.DataSource = DTorigin
            repeaterPruebas.DataBind()
            controlesRepeater()
        Else
            Dim DTorigin As DataRow = BLL.Prueba_BLL.PorPruebaId(ID)

            hfID.Value = DTorigin.Item(0)
            tbPrueba.Text = DTorigin.Item(1) + ""
            tbWO.Text = DTorigin.Item(2) + ""
            tbSerie.Text = DTorigin.Item(3) + ""

            tbModelo.Text = DTorigin.Item(5) + ""
            tbCompresor.Text = DTorigin.Item(6) + ""

            Try
                ddlTipoPrueba.SelectedValue = DTorigin.Item(40) + ""
            Catch ex As Exception

            End Try


            tbEvaporador.Text = DTorigin.Item(10) + ""
            tbCondensador.Text = DTorigin.Item(11) + ""
            tbTermostato.Text = DTorigin.Item(12) + ""
            tbVoltaje.Text = DTorigin.Item(13) + ""
            tbRelay.Text = DTorigin.Item(14) + ""
            tbTipoEv.Text = DTorigin.Item(15) + ""
            tbTipoCon.Text = DTorigin.Item(16) + ""
            tbCapilar.Text = DTorigin.Item(17) + ""
            tbPrueba.Text = DTorigin.Item(18) + ""
            Try
                ddlCamara.Text = DTorigin.Item(19) + ""
            Catch ex As Exception

            End Try

            Try
                ddlTipoPrueba.SelectedValue = DTorigin.Item(9) + ""
            Catch ex As Exception

            End Try

            tbCapacitor.Text = DTorigin.Item(20) + ""
            tbProtector.Text = DTorigin.Item(21) + ""
            tbMae.Text = DTorigin.Item(22) + ""
            tbMac.Text = DTorigin.Item(23) + ""
            tbRefrigerante.Text = DTorigin.Item(24) + ""
            Try
                DTorigin.Item(38) = DTorigin.Item(38).ToString.Replace("#", "")
                Dim fechas As String() = DTorigin.Item(38).ToString.Split("/")
                tbFecha.Text = (fechas(2).Split(" "))(0) + "/" + fechas(1) + "/" + fechas(0) + " " + (fechas(2).Split(" "))(1)
            Catch ex As Exception

            End Try

            tbCodigo.Text = DTorigin.Item(28) + ""
            tbCodigoCompresor.Text = DTorigin.Item(29) + ""
            tbPrueba2.Text = tbCodigo.Text
            tbCarga.Text = DTorigin.Item(24) + ""
            tbComentarios.Text = DTorigin.Item(37) + ""
            ' tbFecha.Text = DTorigin.Item(38) + ""
            ddlAprobado.SelectedValue = DTorigin.Item(39)
            If (DTorigin.Item(39).ToString.Length > 0) Then
                If (Boolean.Parse(DTorigin.Item(39))) Then
                    ddlAprobado.SelectedValue = "Si"
                Else
                    ddlAprobado.SelectedValue = "No"


                End If
            End If





        End If

    End Sub

    Private Sub cargarReporteDetalles(ByVal ID As Integer)
        Dim DTOrigin As DataTable = BLL.Prueba_BLL.PorPruebaDetalle(ID)
        repeaterResumen.DataSource = DTOrigin
        repeaterResumen.DataBind()
    End Sub
    Protected Sub lbtnFiltrar_Click(sender As Object, e As EventArgs)
        cargarReportePruebas(0)
    End Sub

    Protected Sub lbtnCancelar_Click(sender As Object, e As EventArgs)
        inicializar()
    End Sub

    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        Dim aprobacion As Boolean = False
        If (ddlAprobado.SelectedValue.Equals("Si")) Then
            aprobacion = True
        Else
            aprobacion = False
        End If


        If (validarCrud() And ddlCamara.SelectedValue.Length > 0 And ddlTipoPrueba.SelectedValue.Length > 0) Then
            MuestraErrorToast(BLL.Prueba_BLL.Guardar(hfID.Value, tbPrueba.Text, tbWO.Text, tbSerie.Text, tbModelo.Text,
tbCompresor.Text, "Archivo MPLV a la fecha", ddlTipoPrueba.SelectedValue, tbEvaporador.Text, tbCondensador.Text,
tbTermostato.Text, tbVoltaje.Text, tbRelay.Text, tbTipoEv.Text, tbTipoCon.Text,
tbCapilar.Text, tbPrueba.Text, ddlCamara.SelectedValue, tbCapacitor.Text, tbProtector.Text,
tbMae.Text, tbMac.Text, tbRefrigerante.Text, aprobacion, tbComentarios.Text, tbCodigo.Text, tbFecha.Text, ""), 1, True)
            Dim texto As String = tbCodigo.Text
            inicializar()
            tbCodigo.Text = texto
            cargarReportePruebas(0)
        End If
        'Session("Usuario")
    End Sub

    Protected Sub repeaterPruebas_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") Then
            MuestraErrorToast(BLL.Prueba_BLL.Eliminar(Integer.Parse(e.CommandArgument)), 1, True)
            cargarReportePruebas(0)
        ElseIf (e.CommandName = "Edit") Then
            lbtnCancelar.Visible = True
            lbtnGuardar.Enabled = True
            cargarReportePruebas(Integer.Parse(e.CommandArgument))
        ElseIf (e.CommandName = "Reporte") Then
            cargarReporteDetalles(Integer.Parse(e.CommandArgument))
        End If
    End Sub

    Protected Sub btnFiltro_Click(sender As Object, e As EventArgs)
        If (tbCodigo.Text.Length > 0 And tbFecha.Text.Length > 0) Then


            Dim clsC = New DLL2.modelos.consultasExternas()
            Try
                Dim fichaTec As String() = clsC.especificaciones(tbCodigo.Text, tbFecha.Text).Split("|")
                For index As Integer = 0 To fichaTec.Length Step 1
                    Select Case index
                        Case 0
                            tbModelo.Text = fichaTec(index)
                        Case 1
                            tbWO.Text = fichaTec(index)
                        Case 2

                        Case 3
                            tbCompresor.Text = fichaTec(index)
                        Case 4
                            tbCodigoCompresor.Text = fichaTec(index)
                        Case 5
                            tbEvaporador.Text = fichaTec(index)
                        Case 6
                            tbCondensador.Text = fichaTec(index)
                        Case 7
                            tbTermostato.Text = fichaTec(index)
                        Case 8
                            tbSerie.Text = fichaTec(index)
                        Case 9
                            tbVoltaje.Text = fichaTec(index)
                        Case 10
                            tbRelay.Text = fichaTec(index)
                        Case 12
                            tbTipoEv.Text = fichaTec(index)
                        Case 13
                            tbTipoCon.Text = fichaTec(index)
                        Case 14
                            tbCapilar.Text = fichaTec(index)
                        Case 15
                            Try
                                  ddlCamara.Text = fichaTec(index)
                            Catch ex As Exception

                            End Try
                        '
                        Case 17
                            tbCapacitor.Text = fichaTec(index)
                        Case 20
                            tbProtector.Text = fichaTec(index)
                        Case 21
                            tbMae.Text = fichaTec(index)
                        Case 22
                            tbMac.Text = fichaTec(index)
                        Case 23
                            tbRefrigerante.Text = fichaTec(index)
                            tbCarga.Text = fichaTec(index)
                        Case 26
                            tbComentarios.Text = fichaTec(index)

                    End Select
                Next


            Catch ex As Exception

            End Try
        End If


    End Sub

End Class