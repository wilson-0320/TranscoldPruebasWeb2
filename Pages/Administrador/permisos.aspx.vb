Public Class permisos
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            iniciarControles()
            hf()
            cargarddlUsuario()
            cargarddlCatalogo()


            Try

            Catch ex As Exception
            End Try


        End If
    End Sub
    Private Sub hf()
        hfID.Value = "-1"
        hfIDUsuario.Value = "-1"
        hfquery.Value = "insertar"
    End Sub

    Private Sub iniciarControles()
        cbEditar.Checked = False
        cbEliminar.Checked = False
        cbEscritura.Checked = False
        cbLectura.Checked = False
        lbtnGuardarPermisos.Enabled = Roles("Administrador", 1)
        lbntCancelar.Visible = False

    End Sub

    Protected Sub ddlUsuario_SelectedIndexChanged(sender As Object, e As EventArgs)

        If (sender.SelectedValue > 0) Then
            MuestraErrorToast("", 0, True)
            cargarTablaElementos(1, Int32.Parse(sender.SelectedValue), "consulta", hfID.Value)
            hfIDUsuario.Value = sender.SelectedValue

        End If

    End Sub



    Private Sub cargarTablaElementos(ByVal tipo As Int32, ByVal IDUsuario As Int32, ByVal query As String, ByVal ID As Int32)

        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Usuarios_Roles_ABCD", New Object() {
                                                                    New Object() {"@query", query},
                                                                     New Object() {"@ID_Usuario", IDUsuario},
                                                                      New Object() {"@ID", ID}
                                                                    }, CommandType.StoredProcedure).Tables(0)

        Select Case tipo
            Case 1
                repeaterPermisos.DataSource = DTOrig
                repeaterPermisos.DataBind()
            Case 2
                ddlApartados.SelectedValue = DTOrig.Rows(0).Item(0)
                cbEscritura.Checked = DTOrig.Rows(0).Item(2)
                cbEditar.Checked = DTOrig.Rows(0).Item(3)
                cbEliminar.Checked = DTOrig.Rows(0).Item(4)
                cbLectura.Checked = DTOrig.Rows(0).Item(5)


        End Select

    End Sub

    Private Sub cargarddlUsuario()

        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Usuario_ABCD", New Object() {
                                                                    New Object() {"@query", "enlistar"}
                                                                    }, CommandType.StoredProcedure).Tables(0)
        ddlUsuario.DataSource = DTOrig
        ddlUsuario.DataValueField = "ID"
        ddlUsuario.DataTextField = "Usuario"
        ddlUsuario.DataBind()


    End Sub
    Private Sub cargarddlCatalogo()
        '16 es la categoria de apartados
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Catalogo_Actualiza", New Object() {
                                                                    New Object() {"@Tipo", "consultarCat"},
                                                                    New Object() {"@Categoria_ID", 16}
                                                                    }, CommandType.StoredProcedure).Tables(0)
        ddlApartados.DataSource = DTOrig
        ddlApartados.DataValueField = "ID"
        ddlApartados.DataTextField = "Descripcion"
        ddlApartados.DataBind()


    End Sub

    Protected Sub lbtnGuardarPermisos_Click(sender As Object, e As EventArgs)


        MuestraErrorToast(Login_Roles_BLL.CrudRoles(hfquery.Value, Int32.Parse(hfID.Value), Int32.Parse(hfIDUsuario.Value), Int32.Parse(ddlApartados.SelectedValue), cbEscritura.Checked, cbEditar.Checked,
                                  cbEliminar.Checked, cbLectura.Checked), 2, True)
        cargarTablaElementos(1, hfIDUsuario.Value, "consulta", hfID.Value)

    End Sub

    Protected Sub repeaterPermisos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Edit") And Roles("Administrador", 2) Then

            cargarTablaElementos(2, hfIDUsuario.Value, "consulta_ID", Integer.Parse(e.CommandArgument))
            hfID.Value = e.CommandArgument
            lbtnGuardarPermisos.Enabled = Roles("Administrador", 2)
            lbntCancelar.Visible = True
            hfquery.Value = "modificar"
            MuestraErrorToast("Listo", -1, True)

        ElseIf e.CommandName = "Eli" And Roles("Administrador", 3) Then

            MuestraErrorToast(Login_Roles_BLL.Eliminar(Integer.Parse(e.CommandArgument)), 2, True)
            cargarTablaElementos(1, Int32.Parse(hfIDUsuario.Value), "consulta", hfID.Value)
        End If


    End Sub

    Protected Sub lbntCancelar_Click(sender As Object, e As EventArgs)
        iniciarControles()
        MuestraErrorToast("Listo", -1, True)
    End Sub
End Class