Public Class Instrumentos1
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            inicializar()
            cargarDDLCatalogo("Marcas")
            cargarDDLCatalogo("Asignaciones Físicas")

        End If
    End Sub
    Private Sub inicializar()
        tbComentarios.Text = ""
        tbDescripcion.Text = ""
        tbDescripcionI.Text = ""
        tbInstrumento.Text = ""
        tbModelo.Text = ""
        tbPerCal.Text = ""
        tbPerRev.Text = ""
        tbSerie.Text = ""

        hfID.Value = "-1"
        hfQuery.Value = "INSERTAR"
        lbtnCancelar.Visible = False
        lbtnGuardar.Enabled = Roles("Administrador", 1)

    End Sub
    Private Sub msjNot()
        If Not BLL.Met_Instrumento_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Met_Instrumento_BLL.MsjError, 4, True)
        Else
            MuestraErrorToast("Listo", 1, True)
        End If
    End Sub
    Private Sub controlesRepeater()
        Dim mod1 As Boolean = Roles("SupMet,JefeLab", 2)
        Dim eli1 As Boolean = Roles("SupMet,JefeLab", 3)

        For index As Integer = 0 To repeaterMet.Items.Count - 1 Step 1
            'Modificar
            CType(repeaterMet.Items(index).FindControl("LinkButton1"), LinkButton).Visible = mod1


        Next


    End Sub
    Private Sub cargarDDLCatalogo(ByVal tipos As String)
        Dim DTOrigin As DataTable = BLL.Met_Catalogo_BLL.consultar_por_tipo(tipos)
        If (tipos.Equals("Marcas")) Then
            ddlMarca.DataSource = DTOrigin
            ddlMarca.DataTextField = "valor"
            ddlMarca.DataValueField = "id"
            ddlMarca.DataBind()
        Else
            ddlArea.DataSource = DTOrigin
            ddlArea.DataTextField = "valor"
            ddlArea.DataValueField = "id"
            ddlArea.DataBind()
        End If

    End Sub

    Private Function validarCampos()

        For Each CampoTexto As TextBox In New TextBox() {
            tbComentarios, tbDescripcion, tbDescripcionI, tbInstrumento, tbModelo, tbPerCal, tbPerRev, tbSerie, tbRangoMax
            }

            If CampoTexto.Text = "" Then
                MuestraErrorToast("Debe especificar el valor del campo enfocado " + CampoTexto.ToolTip, 3, True)
                CampoTexto.Focus()

                Return False
            End If

        Next
        Return True
    End Function

    Private Sub llenarCampos()
        Dim DTOrigin As DataRow = BLL.Met_Instrumento_BLL.consultar_por_id(hfID.Value)
        tbInstrumento.Text = DTOrigin.Item(1)
        tbDescripcion.Text = DTOrigin.Item(2)
        tbDescripcionI.Text = DTOrigin.Item(3)
        Try
            ddlMarca.SelectedValue = DTOrigin.Item(4)
            ddlArea.SelectedValue = DTOrigin.Item(12)
        Catch ex As Exception

        End Try

        tbModelo.Text = DTOrigin.Item(5)
        tbSerie.Text = DTOrigin.Item(6)
        tbRangoMax.Text = DTOrigin.Item(7)
        cbVigente.Text = DTOrigin.Item(8)
        tbPerCal.Text = DTOrigin.Item(9)
        tbPerRev.Text = DTOrigin.Item(10)
        tbComentarios.Text = DTOrigin.Item(11)
    End Sub

    Protected Sub repeaterMet_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Det") Then
            Response.Redirect("~/Pages/Metrologia/Detalle/panelMetrologia.aspx?Cod=" + e.CommandArgument + "")
        ElseIf (e.CommandName = "Edit") Then
            hfID.Value = e.CommandArgument
            hfQuery.Value = "MODIFICAR"
            lbtnCancelar.Visible = True
            llenarCampos()
            funcionJavascript("abrirModal('modal')")

            MuestraErrorToast("", 0, True)
        End If
    End Sub

    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        If (validarCampos()) Then
            BLL.Met_Instrumento_BLL.crud(hfQuery.Value, hfID.Value, tbInstrumento.Text, tbDescripcion.Text, tbDescripcionI.Text,
tbRangoMax.Text, ddlMarca.SelectedValue, tbModelo.Text, tbSerie.Text, cbVigente.Checked, tbPerCal.Text, tbPerRev.Text, tbComentarios.Text, ddlArea.SelectedValue)

            repeaterMet.DataBind()
            controlesRepeater()
            msjNot()
        End If
    End Sub

    Protected Sub lbtnCancelar_Click(sender As Object, e As EventArgs)
        inicializar()
        MuestraErrorToast("", 0, True)

    End Sub
End Class