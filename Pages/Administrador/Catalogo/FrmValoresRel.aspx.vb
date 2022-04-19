Public Class FrmValoresRel
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                inicializar()
                cargarddlCategorias()
                cargarddlElementos(ddlCategoria.SelectedValue)

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub inicializar()
        tbValor.Text = ""
        tbValorRelacionado.Text = ""
        hfQuery.Value = "Insertar"
        hfID.Value = "-1"
        hfIDElemento.Value = "-1"
        hfIDCategoria.Value = "-1"

        lbtnCancelar.Visible = False
        lbtnGuardar.Enabled = Roles("Administrador", 1)
    End Sub

    Private Sub cargarddlCategorias()
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Catalogo_Actualiza", New Object() {
                                                                 New Object() {"@Tipo", "consultarCat"},
                                                                 New Object() {"@Categoria_ID", 5}
                                                                 }, CommandType.StoredProcedure).Tables(0)


        ddlCategoria.DataSource = DTOrig
        ddlCategoria.DataTextField = "Descripcion"
        ddlCategoria.DataValueField = "ID"
        ddlCategoria.DataBind()

    End Sub
    Private Sub cargarddlElementos(ByVal idCategoria As Integer)
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Elemento_Actualiza", New Object() {
                                                                 New Object() {"@Tipo", "Consultar"},
                                                                 New Object() {"@Categoria_ID", idCategoria}
                                                                 }, CommandType.StoredProcedure).Tables(0)


        ddlElemento.DataSource = DTOrig
        ddlElemento.DataTextField = "Descripcion"
        ddlElemento.DataValueField = "ID"
        ddlElemento.DataBind()

    End Sub

    Private Sub cargarRepeatValores(ByVal querys As String)
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Valor_Relacionado_ABCD", New Object() {
                                                                 New Object() {"@query", querys},
                                                                 New Object() {"@elemento_id", hfIDElemento.Value},
                                                                  New Object() {"@id", hfID.Value}
                                                                 }, CommandType.StoredProcedure).Tables(0)

        If (querys.Equals("consultar")) Then
            repeaterElementos.DataSource = DTOrig
            repeaterElementos.DataBind()
        Else
            tbValor.Text = DTOrig.Rows(0).Item(1)
            tbValorRelacionado.Text = DTOrig.Rows(0).Item(2)


        End If

    End Sub

    Private Function validarCrud() As Boolean

        For Each CampoTexto As TextBox In New TextBox() {
            tbValor, tbValorRelacionado
            }

            If CampoTexto.Text = "" Then
                MuestraErrorToast("Debe especificar el valor del campo " + CampoTexto.ToolTip, 3, True)
                Return False
            End If


        Next
        Return True

    End Function

    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        If (validarCrud() And ddlElemento.SelectedValue > 0) Then
            BLL.Valor_Rel_BLL.insertar_modificar(hfQuery.Value, hfIDElemento.Value, tbValor.Text, tbValorRelacionado.Text, hfID.Value)
            cargarRepeatValores("consultar")
            inicializar()
            hfIDElemento.Value = ddlElemento.SelectedValue
            MuestraErrorToast("Listo", 1, True)
        End If

    End Sub

    Protected Sub lbtnCancelar_Click(sender As Object, e As EventArgs)
        inicializar()
        hfIDElemento.Value = ddlElemento.SelectedValue
        MuestraErrorToast("", 0, True)
    End Sub


    Protected Sub ddlCategoria_SelectedIndexChanged(sender As Object, e As EventArgs)
        If (sender.selectedValue > 0) Then
            hfIDCategoria.Value = sender.selectedValue
            cargarddlElementos(sender.selectedValue)
            hfIDElemento.Value = ddlElemento.SelectedValue
            cargarRepeatValores("consultar")

        End If
        MuestraErrorToast("", 0, True)
    End Sub

    Protected Sub ddlElemento_SelectedIndexChanged(sender As Object, e As EventArgs)
        If (sender.selectedValue > 0) Then
            hfIDElemento.Value = sender.selectedValue
            cargarRepeatValores("consultar")

        End If
        MuestraErrorToast("", 0, True)
    End Sub



    Protected Sub repeaterElementos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli" And Roles("Administrador", 3)) Then
            BLL.Valor_Rel_BLL.eliminar(Integer.Parse(e.CommandArgument))
            cargarRepeatValores("consultar")
            '  cargarRepeatElementos("Consultar", Integer.Parse(hfID.Value), Integer.Parse(hfIDElementos.Value))
            MuestraErrorToast("Listo", 1, True)
        ElseIf (e.CommandName = "Edit") Then

            hfID.Value = (e.CommandArgument)
            hfQuery.Value = "modificar"
            lbtnCancelar.Visible = True
            lbtnGuardar.Enabled = Roles("Administrador", 2)
            cargarRepeatValores("consultar_id")
            MuestraErrorToast("", 0, True)
        End If
    End Sub
End Class