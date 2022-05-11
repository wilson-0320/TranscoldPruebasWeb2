Public Class FrmElementosRelacionados
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Try
                inicializar()
                cargarddlElementos()
                cargarRepeaterRelaciones("consultar_por_filtro", 0)
            Catch ex As Exception

            End Try
        End If


    End Sub

    Private Sub inicializar()
        tbValor.Text = ""
        tbValorRelacionado.Text = ""
        hfID.Value = "-1"
        hfQuery.Value = "-1"
        hfIDElementoRelacionado.Value = "-1"
        hfIDElemento.Value = "-1"
        lbtnCancelar.Visible = False
        lbtnGuardar.Enabled = Roles("Administrador", 1)

    End Sub

    Private Function validarCrud() As Boolean

        For Each CampoTexto As TextBox In New TextBox() {
            tbValor, tbValorRelacionado
            }

            If CampoTexto.Text = "" Then
                MuestraErrorToast("Debe especificar el valor del campo " + CampoTexto.ToolTip, 3, True)
                CampoTexto.Focus()
                Return False
            End If


        Next
        Return True

    End Function

    Private Sub controlesRepeater()
        Dim mod1 As Boolean = Roles("Administrador", 2)
        Dim eli1 As Boolean = Roles("Administrador", 3)
        For index As Integer = 0 To repeaterElementos.Items.Count - 1 Step 1
            'Modificar
            CType(repeaterElementos.Items(index).FindControl("LinkButton1"), LinkButton).Visible = mod1
            'Eliminar
            CType(repeaterElementos.Items(index).FindControl("LinkButton3"), LinkButton).Visible = eli1
        Next

    End Sub
    Private Sub msjNot()
        If Not BLL.Elemento_Relacion_DAL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Elemento_Relacion_DAL.MsjError, 4, True)
        Else
            MuestraErrorToast("", 0, True)
        End If
    End Sub
    Private Sub cargarddlElementos()
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Elemento_Consulta", New Object() {
                                                                 New Object() {"@Tipo", "ConTitulosCat"}
                                                                 }, CommandType.StoredProcedure).Tables(0)

        ddlElemento.DataSource = DTOrig
        ddlElemento.DataTextField = "Muestra"
        ddlElemento.DataValueField = "ID"
        ddlElemento.DataBind()

        ddlElementoRelacionado.DataSource = DTOrig
        ddlElementoRelacionado.DataTextField = "Muestra"
        ddlElementoRelacionado.DataValueField = "ID"
        ddlElementoRelacionado.DataBind()
    End Sub

    Private Sub cargarRepeaterRelaciones(ByVal querys As String, ByVal ID As Integer)
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Elemento_Relacion_ABCD", New Object() {
                                                          New Object() {"@query", querys},
                                                          New Object() {"@id", ID},
                                                          New Object() {"@elemento_id", hfIDElemento.Value},
                                                          New Object() {"@elemento_rel_id", hfIDElementoRelacionado.Value}
                                                          }, CommandType.StoredProcedure).Tables(0)
        If (querys.Equals("consultar_por_filtro")) Then
            repeaterElementos.DataSource = DTOrig
            repeaterElementos.DataBind()
            controlesRepeater()
        Else
            hfID.Value = DTOrig.Rows(0).Item(0)
            ddlElemento.SelectedValue = DTOrig.Rows(0).Item(1)
            hfIDElemento.Value = DTOrig.Rows(0).Item(1)
            ddlElementoRelacionado.SelectedValue = DTOrig.Rows(0).Item(2)
            hfIDElementoRelacionado.Value = DTOrig.Rows(0).Item(2)
            tbValor.Text = DTOrig.Rows(0).Item(3)
            tbValorRelacionado.Text = DTOrig.Rows(0).Item(4)

        End If

    End Sub
    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        If (validarCrud()) Then
            If (hfQuery.Value.Equals("Actualizar")) Then
                BLL.Elemento_Relacion_DAL.modificar(hfID.Value, tbValor.Text, tbValorRelacionado.Text)
            Else
                BLL.Elemento_Relacion_DAL.insertar(ddlElemento.SelectedValue, ddlElementoRelacionado.SelectedValue, tbValor.Text, tbValorRelacionado.Text)
            End If
            msjNot()
            cargarRepeaterRelaciones("consultar_por_filtro", 0)
            inicializar()
            hfIDElemento.Value = ddlElemento.SelectedValue
            hfIDElementoRelacionado.Value = ddlElementoRelacionado.SelectedValue

        End If

    End Sub
    Protected Sub lbtnCancelar_Click(sender As Object, e As EventArgs)
        inicializar()
        MuestraErrorToast("", 0, True)
    End Sub



    Protected Sub ddlElemento_SelectedIndexChanged(sender As Object, e As EventArgs)
        If (sender.SelectedValue > 0) Then
            hfIDElemento.Value = sender.SelectedValue
            cargarRepeaterRelaciones("consultar_por_filtro", 0)
            MuestraErrorToast("", 0, True)
        End If


    End Sub

    Protected Sub ddlElementoRelacionado_SelectedIndexChanged(sender As Object, e As EventArgs)
        If (sender.SelectedValue > 0) Then
            hfIDElementoRelacionado.Value = sender.SelectedValue
            cargarRepeaterRelaciones("consultar_por_filtro", 0)
            MuestraErrorToast("listo", 0, True)
        End If
    End Sub

    Protected Sub repeaterElementos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") Then
            BLL.Elemento_Relacion_DAL.eliminar(Integer.Parse(e.CommandArgument))
            msjNot()
            cargarRepeaterRelaciones("consultar_por_filtro", 0)
            MuestraErrorToast("listo", 1, True)
        ElseIf (e.CommandName = "Edit") Then

            hfID.Value = (e.CommandArgument)
            hfQuery.Value = "Actualizar"
            lbtnGuardar.Enabled = True
            lbtnCancelar.Visible = True
            cargarRepeaterRelaciones("consultar_por_id", Integer.Parse(e.CommandArgument))
            MuestraErrorToast("", 0, True)
        End If
    End Sub
End Class