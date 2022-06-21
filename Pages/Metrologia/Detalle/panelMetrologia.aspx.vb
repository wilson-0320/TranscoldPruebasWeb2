Public Class panelMetrologia
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            inicializar()

            If Not Request.QueryString("Cod") Is Nothing Then
                hfInstrumento.Value = Request.QueryString("Cod").TrimEnd
                repeaterMet.DataBind()
                repeaterLaboratorios.DataBind()
                repeaterCertificado.DataBind()
                cargarDDLLaboratorios()
                cargarDDLMagnitud()
                cargarDDLLaboratorioAsignado()
            End If

        End If
    End Sub

    Private Sub inicializar()
        tbCertificado.Text = ""
        tbExactitud.Text = ""
        tbFechaCal.Text = ""
        tbFechaProx.Text = ""
        tbGuiaEnvio.Text = ""
        tbGuiaRetorno.Text = ""
        tbLinkCertificado.Text = ""
        tbPuntosCal.Text = ""
        tbRangoFin.Text = ""
        tbRangoIni.Text = ""
        tbResolucion.Text = ""
        hfID.Value = "-1"
        hfIDCal.Value = "-1"
        hfQuery.Value = "INSERTAR"
        hfQueryCal.Value = "Insertar"
        CbVigente.Checked = False

    End Sub

    Private Sub msjNotDetalle()
        If Not BLL.Met_Instrumento_Magnitud_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Met_Instrumento_Magnitud_BLL.MsjError, 4, True)
        Else
            MuestraErrorToast("Listo", 1, True)
        End If
    End Sub

    Private Sub msjNotCertificado()
        If Not BLL.Met_Certificado_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Met_Certificado_BLL.MsjError, 4, True)
        Else
            MuestraErrorToast("Listo", 1, True)
        End If
    End Sub

    Private Sub msjNotLaboratorios()
        If Not BLL.Met_Instrumento_Proveedor_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Met_Instrumento_Proveedor_BLL.MsjError, 4, True)
        Else
            MuestraErrorToast("Listo", 1, True)
        End If
    End Sub


    Private Sub controlesRepeater()
        Dim mod1 As Boolean = Roles("SupMet,JefeLab,Admin,SupLab", 2)
        Dim eli1 As Boolean = Roles("SupMet,JefeLab,Admin,SupLab", 3)

        For index As Integer = 0 To repeaterMet.Items.Count - 1 Step 1
            'Modificar
            CType(repeaterMet.Items(index).FindControl("LinkButton1"), LinkButton).Visible = mod1


        Next
    End Sub

    Private Sub cargarDDLLaboratorios()
        Dim DTOrigin As DataTable = BLL.Met_Proveedores_BLL.consultar()
        ddlLaboratorios.DataSource = DTOrigin
        ddlLaboratorios.DataTextField = "nombre"
        ddlLaboratorios.DataValueField = "id"
        ddlLaboratorios.DataBind()
    End Sub
    Private Sub cargarDDLMagnitud()
        Dim DTOrigin As DataTable = BLL.Met_Magnitud_BLL.consultar()
        ddlMagnitud.DataSource = DTOrigin
        ddlMagnitud.DataTextField = "magnitud"
        ddlMagnitud.DataValueField = "id"
        ddlMagnitud.DataBind()
    End Sub
    Private Sub cargarDDLLaboratorioAsignado()
        Dim DTOrigin As DataTable = BLL.Met_Instrumento_Proveedor_BLL.consultar(hfInstrumento.Value)
        ddlLaboratoriosAsignados.DataSource = DTOrigin
        ddlLaboratoriosAsignados.DataTextField = "nombre"
        ddlLaboratoriosAsignados.DataValueField = "id"
        ddlLaboratoriosAsignados.DataBind()
    End Sub

    Private Function validarCertificado() As Boolean
        For Each CampoTexto As TextBox In New TextBox() {
           tbCertificado, tbFechaCal, tbFechaProx, tbGuiaEnvio, tbGuiaRetorno, tbLinkCertificado
            }

            If CampoTexto.Text = "" Then
                MuestraErrorToast("Debe especificar el valor del campo enfocado " + CampoTexto.ToolTip, 3, True)
                CampoTexto.Focus()

                Return False
            End If

        Next
        Return True
    End Function

    Private Function validarDetalles() As Boolean
        For Each CampoTexto As TextBox In New TextBox() {
           tbExactitud, tbRangoFin, tbRangoIni, tbResolucion, tbPuntosCal
            }

            If CampoTexto.Text = "" Then
                MuestraErrorToast("Debe especificar el valor del campo enfocado " + CampoTexto.ToolTip, 3, True)
                CampoTexto.Focus()

                Return False
            End If

        Next
        Return True
    End Function

    Private Sub llenarCamposCertificado()
        Dim DTOring As DataRow = BLL.Met_Certificado_BLL.consultar_por_id(hfIDCal.Value)
        Try
            ddlLaboratoriosAsignados.SelectedValue = DTOring.Item(2)
            tbGuiaEnvio.Text = DTOring.Item(3)
            tbGuiaRetorno.Text = DTOring.Item(4)
            tbCertificado.Text = DTOring.Item(5)
            tbLinkCertificado.Text = DTOring.Item(6)
            CbVigente.Checked = DTOring.Item(9)
            Try
                If ((DTOring.Item(7).ToString().Length) > 0) Then
                    Dim fechas() As String = Split((DTOring.Item(7)).ToString.Substring(0, DTOring.Item(7).ToString.IndexOf(" ")).Replace("/", "-"), "-")

                    tbFechaCal.Text = fechas(2) + "-" + fechas(1) + "-" + fechas(0)

                End If

                If ((DTOring.Item(8).ToString().Length) > 0) Then
                    Dim fechas() As String = Split((DTOring.Item(8)).ToString.Substring(0, DTOring.Item(8).ToString.IndexOf(" ")).Replace("/", "-"), "-")

                    tbFechaProx.Text = fechas(2) + "-" + fechas(1) + "-" + fechas(0)

                End If
            Catch ex As Exception

            End Try



        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenarCamposDetalles()
        Dim DTOring As DataRow = BLL.Met_Instrumento_Magnitud_BLL.consultar_por_id(hfID.Value)
        Try
            ddlMagnitud.SelectedValue = DTOring.Item(2)
            tbExactitud.Text = DTOring.Item(3)
            Try
                tbResolucion.Text = DTOring.Item(4).ToString.Replace(",", ".")
                tbRangoIni.Text = DTOring.Item(7).ToString.Replace(",", ".")
                tbRangoFin.Text = DTOring.Item(8).ToString.Replace(",", ".")
            Catch ex As Exception

            End Try

            tbPuntosCal.Text = DTOring.Item(5)


        Catch ex As Exception

        End Try
    End Sub


    Protected Sub lbtnGuardarCer_Click(sender As Object, e As EventArgs)
        If (validarCertificado()) Then
            BLL.Met_Certificado_BLL.crud(hfQueryCal.Value, hfIDCal.Value, hfInstrumento.Value, ddlLaboratoriosAsignados.SelectedValue,
tbGuiaEnvio.Text, tbGuiaRetorno.Text, tbCertificado.Text, tbLinkCertificado.Text, tbFechaCal.Text, tbFechaProx.Text, Session("Usuario").ToString, CbVigente.Checked)
            msjNotDetalle()
            repeaterCertificado.DataBind()
        End If
    End Sub

    Protected Sub lbtnCancelarCer_Click(sender As Object, e As EventArgs)
        inicializar()
        MuestraErrorToast("Listo", 0, True)
    End Sub

    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        If (validarDetalles()) Then
            BLL.Met_Instrumento_Magnitud_BLL.crud(hfQuery.Value, hfID.Value, hfInstrumento.Value, tbExactitud.Text, tbResolucion.Text,
tbPuntosCal.Text, tbRangoIni.Text, tbRangoFin.Text, ddlMagnitud.SelectedValue)
            msjNotDetalle()
            repeaterMet.DataBind()
        End If
    End Sub

    Protected Sub lbtnCancelar_Click(sender As Object, e As EventArgs)
        inicializar()
        MuestraErrorToast("Listo", 0, True)
    End Sub

    Protected Sub lbtnGuardarLaboratorios_Click(sender As Object, e As EventArgs)
        BLL.Met_Instrumento_Proveedor_BLL.crud("INSERTAR", 0, hfInstrumento.Value, ddlLaboratorios.SelectedValue)
        msjNotLaboratorios()
        repeaterLaboratorios.DataBind()
    End Sub
    Protected Sub repeaterMet_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") Then
            BLL.Met_Instrumento_Magnitud_BLL.eliminar(e.CommandArgument)
            repeaterMet.DataBind()
            msjNotDetalle()
        ElseIf (e.CommandName = "Edi") Then
            hfID.Value = e.CommandArgument
            hfQuery.Value = "MODIFICAR"
            lbtnCancelar.Visible = True
            llenarCamposDetalles()
            funcionJavascript("abrirModal('modal')")

            MuestraErrorToast("", 0, True)
        End If
    End Sub

    Protected Sub repeaterLaboratorios_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") Then
            BLL.Met_Instrumento_Proveedor_BLL.Eliminar(e.CommandArgument)
            repeaterLaboratorios.DataBind()
            msjNotLaboratorios()
        End If
    End Sub

    Protected Sub repeaterCertificado_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") Then
            BLL.Met_Certificado_BLL.Eliminar(e.CommandArgument)
            repeaterCertificado.DataBind()
            msjNotCertificado()
        ElseIf (e.CommandName = "Edi") Then
            hfIDCal.Value = e.CommandArgument
            hfQueryCal.Value = "MODIFICAR"
            lbtnCancelarCer.Visible = True
            llenarCamposCertificado()
            funcionJavascript("abrirModal('modalCertificados')")

            MuestraErrorToast("", 0, True)
        End If
    End Sub


End Class