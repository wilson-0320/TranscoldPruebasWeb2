Public Class frmNotificaciones
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then


            Try
                inicializar()

            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub inicializar()
        tbMax.Text = "0"
        tbMin.Text = "0"
        hfIDCat.Value = "-1"
        hfID.Value = "-1"
        hfQuery.Value = "INSERTAR"
        lblTipo.Text = ""
    End Sub

    Private Function validar() As Boolean
        For Each CampoTexto As TextBox In New TextBox() {
            tbMax, tbMin
            }

            If CampoTexto.Text = "" Then
                MuestraErrorToast("Debe especificar el valor del campo enfocado " + CampoTexto.ToolTip, 3, True)
                CampoTexto.Focus()

                Return False
            End If


        Next
        Return True


    End Function

    Private Sub msjNot()
        If Not BLL.Pru_Not_Sol_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Pru_Not_Sol_BLL.MsjError, 4, True)
        Else
            MuestraErrorToast("Realizado", 1, True)
        End If
    End Sub
    Private Sub cargarDllCatalogo()
        ddlCatalogoDisponible.Items.Clear()
        Dim DTOrigin = BLL.Pru_Not_Sol_BLL.consultar_por_codigo("Por_Pendientes", tbCodigo.Text)
        ddlCatalogoDisponible.DataSource = DTOrigin
        ddlCatalogoDisponible.DataTextField = "Descripcion"
        ddlCatalogoDisponible.DataValueField = "ID"
        ddlCatalogoDisponible.DataBind()
    End Sub


    Private Sub cargarRepeatNotificaciones()
        Dim DTOrigin = BLL.Pru_Not_Sol_BLL.consultar_por_codigo("Por_Codigo", tbCodigo.Text)
        repeaterNotificaciones.DataSource = DTOrigin
        repeaterNotificaciones.DataBind()
    End Sub

    Protected Sub repeaterNotificaciones_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") Then

            BLL.Pru_Not_Sol_BLL.guardar("ELIMINAR", tbCodigo.Text, e.CommandArgument, 0, 0, 0, Session("Usuario"))
            msjNot()

            cargarDllCatalogo()
            cargarRepeatNotificaciones()
        ElseIf (e.CommandName = "Edi") Then
            Dim DTOrigin As DataRow = BLL.Pru_Not_Sol_BLL.consultar_por_llave(e.CommandArgument)
            hfQuery.Value = "MODIFICAR"
            hfIDCat.Value = DTOrigin.Item(2)
            hfID.Value = DTOrigin.Item(0)
            tbMax.Text = DTOrigin.Item(3)
            tbMin.Text = DTOrigin.Item(4)
            lblTipo.Text = DTOrigin.Item(6)
            Dim key As String = Guid.NewGuid.ToString
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), key, "abrirModal('modalNot')", True)
            MuestraErrorToast("", 0, True)
        End If
    End Sub

    Protected Sub tbCodigo_TextChanged(sender As Object, e As EventArgs)
        cargarDllCatalogo()
        cargarRepeatNotificaciones()
        MuestraErrorToast("", 0, True)
    End Sub

    Protected Sub lbtnAgregar_Click(sender As Object, e As EventArgs)
        Try
            If (ddlCatalogoDisponible.SelectedValue > 0) Then
                hfIDCat.Value = ddlCatalogoDisponible.SelectedValue
                Dim key As String = Guid.NewGuid.ToString
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), key, "abrirModal('modalNot')", True)
                MuestraErrorToast("", 0, True)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        If (validar()) Then
            BLL.Pru_Not_Sol_BLL.guardar(hfQuery.Value, tbCodigo.Text, hfID.Value, hfIDCat.Value, tbMax.Text, tbMin.Text, Session("Usuario"))
            msjNot()
            cargarDllCatalogo()
            cargarRepeatNotificaciones()
            inicializar()
        End If

    End Sub

    Protected Sub lbtnCancelar_Click(sender As Object, e As EventArgs)
        inicializar()
        Dim key As String = Guid.NewGuid.ToString
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), key, "cerrarModal('modalNot')", True)
        MuestraErrorToast("", 0, True)
    End Sub
End Class