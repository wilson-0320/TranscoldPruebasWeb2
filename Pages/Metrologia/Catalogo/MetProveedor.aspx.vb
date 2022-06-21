Public Class MetProveedor
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            inicializar()
            cargarTabla(1)

        End If

    End Sub

    Private Sub inicializar()
        tbContacto.Text = ""
        tbCorrreo.Text = ""
        tbNombre.Text = ""
        tbDireccion.Text = ""
        tbPais.Text = ""
        tbTelefono.Text = ""
        cbCalibracion.Checked = False
        cbSuministros.Checked = False
        hfID.Value = "-1"
        hfQuery.Value = "INSERTAR"
        lbtnCancelar.Visible = False
        lbtnGuardar.Enabled = Roles("Administrador", 1)

    End Sub
    Private Sub msjNot()
        If Not BLL.Met_Proveedores_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Met_Proveedores_BLL.MsjError, 4, True)
        Else
            MuestraErrorToast("Listo", 1, True)
        End If
    End Sub
    Private Sub controlesRepeater()
        Dim mod1 As Boolean = Roles("SupMet,JefeLab", 2)
        Dim eli1 As Boolean = Roles("SupMet,JefeLab", 3)

        For index As Integer = 0 To repeaterMetProveedores.Items.Count - 1 Step 1
            'Modificar
            CType(repeaterMetProveedores.Items(index).FindControl("LinkButton1"), LinkButton).Visible = mod1

            'Eliminar
            CType(repeaterMetProveedores.Items(index).FindControl("LinkButton2"), LinkButton).Visible = eli1
        Next


    End Sub

    Private Function validarCampos()

        For Each CampoTexto As TextBox In New TextBox() {
            tbTelefono, tbPais, tbNombre, tbDireccion, tbCorrreo, tbContacto
            }

            If CampoTexto.Text = "" Then
                MuestraErrorToast("Debe especificar el valor del campo enfocado " + CampoTexto.ToolTip, 3, True)
                CampoTexto.Focus()

                Return False
            End If

        Next
        Return True
    End Function

    Private Sub cargarTabla(ByVal tipo As Integer)

        If (tipo = 1) Then
            repeaterMetProveedores.DataBind()
            controlesRepeater()
        Else
            Dim DTOrigin As DataRow = BLL.Met_Proveedores_BLL.consultar_por_id(hfID.Value)

            hfID.Value = DTOrigin.Item(0)
            cbCalibracion.Checked = DTOrigin.Item(1)
            cbSuministros.Checked = DTOrigin.Item(2)
            tbNombre.Text = DTOrigin.Item(3).ToString.TrimEnd
            tbDireccion.Text = DTOrigin.Item(4).ToString.TrimEnd
            tbPais.Text = DTOrigin.Item(5).ToString.TrimEnd
            tbContacto.Text = DTOrigin.Item(6).ToString.TrimEnd
            tbCorrreo.Text = DTOrigin.Item(7).ToString.TrimEnd
            tbTelefono.Text = DTOrigin.Item(8).ToString.TrimEnd



        End If



    End Sub

    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        If (validarCampos()) Then
            BLL.Met_Proveedores_BLL.crud(hfQuery.Value, hfID.Value, cbCalibracion.Checked, cbSuministros.Checked, tbNombre.Text, tbDireccion.Text, tbPais.Text,
tbContacto.Text, tbCorrreo.Text, tbTelefono.Text, "")
            repeaterMetProveedores.DataBind()
            controlesRepeater()
            msjNot()
        End If

    End Sub

    Protected Sub lbtnCancelar_Click(sender As Object, e As EventArgs)
        inicializar()
        funcionJavascript("cerrarModal('modal')")
        MuestraErrorToast("", 0, True)
    End Sub

    Protected Sub repeaterMetProveedores_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") Then
            BLL.Met_Proveedores_BLL.eliminar(Integer.Parse(e.CommandArgument))
            cargarTabla(1)
            msjNot()

        ElseIf (e.CommandName = "Edit") Then
            hfID.Value = e.CommandArgument
            hfQuery.Value = "MODIFICAR"
            lbtnCancelar.Visible = True
            cargarTabla(0)
            funcionJavascript("abrirModal('modal')")

            MuestraErrorToast("", 0, True)
        End If
    End Sub


End Class