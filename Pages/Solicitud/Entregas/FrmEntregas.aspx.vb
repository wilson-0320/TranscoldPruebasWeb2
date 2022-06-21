Public Class FrmEntregas
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            inicializar()

            cargarRepeatUsuario()
            cargarRepeatEntregas()
            cargarddlUsuarios()
            cargarddlEntregas()
        End If

    End Sub

    Private Sub inicializar()
        tbDias.Text = ""
        tbEntrega.Text = ""
        tbNum.Text = ""
        lbtnCancelarEntrega.Visible = False
        lbtnCancelarUsuario.Visible = False


    End Sub

    Private Sub msjNot()
        If Not BLL.Pru_Entrega_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Pru_Entrega_BLL.MsjError, 4, True)
        Else
            MuestraErrorToast("Se completo la operacion.", 1, True)
        End If
    End Sub

    Private Function validarCrud() As Boolean

        For Each CampoTexto As TextBox In New TextBox() {
            tbNum, tbEntrega, tbDias
            }

            If CampoTexto.Text = "" Then
                MuestraErrorToast("Debe especificar el valor del campo enfocado " + CampoTexto.ToolTip, 3, True)
                CampoTexto.Focus()

                Return False
            End If


        Next
        Return True

    End Function
    Private Sub llenarCuadrosEntregas()
        Dim DTOrigin As DataRow = BLL.Pru_Entrega_BLL.consultar_llave_Entrega(hfIDEntregas.Value)
        tbNum.Text = DTOrigin.Item(1)
        tbEntrega.Text = DTOrigin.Item(2)
        tbDias.Text = DTOrigin.Item(3)
        cbEstado.Checked = DTOrigin.Item(4)

    End Sub

    Private Sub llenarCuadrosUsuarios()
        Dim DTOrigin As DataRow = BLL.Pru_Entrega_BLL.consultar_llave_Usuario(hfIDUsuarioEntrega.Value)
        ddlEntregas.SelectedValue = DTOrigin.Item(1).ToString.TrimEnd
        ddlUsuario.SelectedValue = DTOrigin.Item(2).ToString.TrimEnd
        cbIncluir.Checked = True
    End Sub

    Private Sub cargarRepeatUsuario()
        Dim DTOrigin As DataTable = BLL.Pru_Entrega_BLL.consultar_usuario()
        RepeaterUsuarioEntrega.DataSource = DTOrigin
        RepeaterUsuarioEntrega.DataBind()

    End Sub

    Private Sub cargarRepeatEntregas()
        Dim DTOrigin As DataTable = BLL.Pru_Entrega_BLL.consultar()
        RepeaterEntregas.DataSource = DTOrigin
        RepeaterEntregas.DataBind()

    End Sub

    Private Sub cargarddlUsuarios()
        Dim DTOrigin As DataTable = BLL.Pru_Entrega_BLL.consultar_usuarios()
        ddlUsuario.DataSource = DTOrigin
        ddlUsuario.DataTextField = "UserName"
        ddlUsuario.DataValueField = "UserName"
        ddlUsuario.DataBind()

    End Sub
    Private Sub cargarddlEntregas()
        Dim DTOrigin As DataTable = BLL.Pru_Entrega_BLL.consultar()
        ddlEntregas.DataSource = DTOrigin
        ddlEntregas.DataTextField = "Entrega"
        ddlEntregas.DataValueField = "id"
        ddlEntregas.DataBind()

    End Sub
    Protected Sub lbtnGuardarUsuario_Click(sender As Object, e As EventArgs)
        If (ddlEntregas.SelectedValue.Length > 0 And
            ddlUsuario.SelectedValue.Length > 0) Then

            BLL.Pru_Entrega_BLL.guardar_entrega_usuario(ddlEntregas.SelectedValue, ddlUsuario.SelectedValue, cbIncluir.Checked, Session("Usuario").ToString)
            msjNot()
            RepeaterUsuarioEntrega.DataBind()
        End If
    End Sub

    Protected Sub lbtnCancelarUsuario_Click(sender As Object, e As EventArgs)
        inicializar()
        MuestraErrorToast("Listo", 0, True)
    End Sub

    Protected Sub lbtnGuardarEntrega_Click(sender As Object, e As EventArgs)
        If (validarCrud()) Then
            BLL.Pru_Entrega_BLL.insertar(tbNum.Text, tbEntrega.Text, tbNum, cbEstado.Checked, Session("Usuario").ToString)
            msjNot()
            RepeaterEntregas.DataBind()
        End If
    End Sub

    Protected Sub lbtnCancelarEntrega_Click(sender As Object, e As EventArgs)
        inicializar()
        MuestraErrorToast("Listo", 0, True)
    End Sub

    Protected Sub RepeaterUsuarioEntrega_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Edi") Then
            hfIDUsuarioEntrega.Value = (e.CommandArgument)
            llenarCuadrosUsuarios()
        End If
    End Sub

    Protected Sub RepeaterEntregas_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Edi") Then
            hfIDEntregas.Value = (e.CommandArgument)
            llenarCuadrosEntregas()
        End If
    End Sub
End Class