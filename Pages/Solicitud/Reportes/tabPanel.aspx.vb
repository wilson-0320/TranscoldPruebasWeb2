Public Class tabPanel
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Request.QueryString("Codigo") Is Nothing Then
            hfCodigo.Value = Request.QueryString("Codigo")
            hfConsecutivo.Value = Request.QueryString("Consecutivo")
            hfDivision.Value = Request.QueryString("Division")
            If (validarParametros()) Then
                cargarResumenVerificaciones()

                ' cargarRepeaterHistoricalCambios("ValidacionCamara")
                ' llamarFuncionesJavascript("La consulta ha finalizado.", "Satisfactorio")
                cargarRepeaterPruebas()
                cargarReportRecepcion()
                cargarRepeaterHistoricalCambios("ContadorCambios")
                cargarRepeaterHistoricalCambios("CargaProducto")
                informacionPrincipal()
                ' funcionesvarias(" google.charts.setOnLoadCallback(drawChart); ", False)
            End If


            ' cargarReportRepeatet("LineaTiempoIntegradoPruebas")




        End If
    End Sub

    Private Function validarParametros() As Boolean
        Dim DTOrig As Integer = Integer.Parse(New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Select count(Codigo) from Pru_Solicitud_Enc_Historico where Codigo=@Codigo ", New Object() {
                                                                New Object() {"@Codigo", hfCodigo.Value}
                                                                }, CommandType.Text).Tables(0).Rows(0).Item(0))

        If (DTOrig > 0) Then
            Return True
        Else
            Return False
        End If


    End Function

    Private Function informacionPrincipal()
        lblInfo.Text = ""
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Select Codigo,Fecha_Creacion,Usuario_Creacion,Modelo,Objetivos,Serie,WO from Pru_Solicitud_Enc_Historico where Codigo=@Codigo", New Object() {
                                                                New Object() {"@Codigo", hfCodigo.Value}
                                                                }, CommandType.Text).Tables(0)
        Dim titulo As String = ""
        For index As Integer = 0 To DTOrig.Columns().Count - 2 Step 1
            Select Case index
                Case 1
                    titulo = "Fecha de creacion:"
                Case 2
                    titulo = "Usuario Creador:"
                Case 3
                    titulo = "Modelo:"
                Case 4
                    titulo = "Objetivos:"
                Case 5
                    titulo = "Serie:"
                Case 6
                    titulo = "WO.:"

            End Select
            lblInfo.Text = lblInfo.Text + titulo + " " + DTOrig.Rows(0).Item(index) + "<br>"
            ' Debug.Write(index.ToString & " ")
        Next

    End Function



    Private Sub cargarRepeaterPruebas()

        Dim DTorigin As DataTable = BLL.Prueba_BLL.consultar("", "", "", "", "", "", "", "", "", "", "", "", "",
                                                             "", "Ambos", "", "", "", "", hfCodigo.Value)


        repeaterPruebas.DataSource = DTorigin
        repeaterPruebas.DataBind()


        '' Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Ensayo_ABCD", New Object() {
        ''                                                            New Object() {"@query", "consultarEstadoPrueba"},
        ''                                                           New Object() {"@Solicitud_Cod", hfCodigo.Value}
        ''                                                          }, CommandType.StoredProcedure).Tables(0)
        ''repeaterPruebas.DataSource = DTOrig
        '' repeaterPruebas.DataBind()
    End Sub

    Private Sub cargarRepeaterHistoricalCambios(ByVal CualRep As String)
        Try
            Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Reporte_LineaTiempo", New Object() {
                                                                   New Object() {"@Codigo", hfCodigo.Value},
                                                                   New Object() {"@CualRep", CualRep},
                                                                   New Object() {"@Rango_Inicio", 0},
                                                                   New Object() {"@Rango_Fin", 0},
                                                                   New Object() {"@minutos", 1440},
                                                                   New Object() {"@TiposRegistro", "Cambios,Estatus,Comentarios,Eventos,Archivos,"}
                                                                   }, CommandType.StoredProcedure).Tables(0)

            If (CualRep.Equals("ContadorCambios")) Then
                repeaterContadoCambios.DataSource = DTOrig
                repeaterContadoCambios.DataBind()
            ElseIf (CualRep.Equals("CargaProducto")) Then
                repeaterCargaEquipo.DataSource = DTOrig
                repeaterCargaEquipo.DataBind()

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cargarReportRecepcion()
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Recepcion_ABCD", New Object() {
                                                                 New Object() {"@query", "consultar_por_codigo"},
                                                                 New Object() {"@ID", 0},
                                                                 New Object() {"@tipo", 0},
                                                                  New Object() {"@codigo", hfCodigo.Value},
                                                                  New Object() {"@modelo", ""}
                                                                }, CommandType.StoredProcedure).Tables(0)

        RepeaterRecepcion.DataSource = DTOrig

        RepeaterRecepcion.DataBind()
    End Sub

    Private Sub cargarResumenVerificaciones()

        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Verificacion_Solicitud_ABCD", New Object() {
                                                                   New Object() {"@query", "consultarfiltro"},
                                                                    New Object() {"@Codigo", hfCodigo.Value}
                                                                    }, CommandType.StoredProcedure).Tables(0)


        RepeaterValidaciones.DataSource = DTOrig
        RepeaterValidaciones.DataBind()


    End Sub
End Class