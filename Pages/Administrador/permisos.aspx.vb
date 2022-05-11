Public Class permisos
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            iniciarControles()
            hf()
            cargarddlUsuario()
            cargarddlRoles()


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

    Private Sub controlesRepeater()
        Dim mod1 As Boolean = Roles("Administrador", 2)
        Dim eli1 As Boolean = Roles("Administrador", 3)

        For index As Integer = 0 To repeaterPermisos.Items.Count - 1 Step 1
            'Modificar
            CType(repeaterPermisos.Items(index).FindControl("LinkButton1"), LinkButton).Visible = mod1
            'Eliminar
            CType(repeaterPermisos.Items(index).FindControl("LinkButton2"), LinkButton).Visible = eli1
        Next


    End Sub

    Private Sub iniciarControles()
        cbEditar.Checked = False
        cbEliminar.Checked = False
        cbEscritura.Checked = False
        lbtnGuardarPermisos.Enabled = Roles("Administrador", 1)
        lbntCancelar.Visible = False

    End Sub

    Private Sub msjNot()
        If Not Pag_Usuarios_Permisos_BLL.MsjError Is Nothing Then
            MuestraErrorToast(Pag_Usuarios_Permisos_BLL.MsjError, 4, True)
        Else
            MuestraErrorToast("", 0, True)
        End If
    End Sub

    Protected Sub ddlUsuario_SelectedIndexChanged(sender As Object, e As EventArgs)

        If (sender.SelectedValue > 0) Then
            MuestraErrorToast("", 0, True)
            cargarTablaElementos(1, Int32.Parse(sender.SelectedValue), "consulta", hfID.Value)
            hfIDUsuario.Value = sender.SelectedValue

        End If

    End Sub



    Private Sub cargarTablaElementos(ByVal tipo As Int32, ByVal IDUsuario As Int32, ByVal query As String, ByVal ID As Int32)

        Dim DTOrig As DataTable = Pag_Usuarios_Permisos_BLL.consultar(query, ID, IDUsuario, 0)


        Select Case tipo
            Case 1
                repeaterPermisos.DataSource = DTOrig
                repeaterPermisos.DataBind()
                controlesRepeater()
            Case 2
                ddlApartados.SelectedValue = DTOrig.Rows(0).Item(0)
                cbEscritura.Checked = DTOrig.Rows(0).Item(2)
                cbEditar.Checked = DTOrig.Rows(0).Item(3)
                cbEliminar.Checked = DTOrig.Rows(0).Item(4)


        End Select

    End Sub

    Private Sub cargarddlUsuario()

        Dim DTOrig As DataTable = Login_BLL.consulta("enlistar", "", "", "", False)

        ddlUsuario.DataSource = DTOrig
        ddlUsuario.DataValueField = "ID"
        ddlUsuario.DataTextField = "Usuario"
        ddlUsuario.DataBind()


    End Sub
    Private Sub cargarddlRoles()
        '16 es la categoria de apartados
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pag_Roles_ABCD", New Object() {
                                                                    New Object() {"@query", "ddlListaRol"}
                                                                    }, CommandType.StoredProcedure).Tables(0)
        ddlApartados.DataSource = DTOrig
        ddlApartados.DataValueField = "ID"
        ddlApartados.DataTextField = "Descripcion"
        ddlApartados.DataBind()


    End Sub

    Protected Sub lbtnGuardarPermisos_Click(sender As Object, e As EventArgs)


        Pag_Usuarios_Permisos_BLL.crudPermisos(hfquery.Value, Int32.Parse(hfID.Value), Int32.Parse(hfIDUsuario.Value), Int32.Parse(ddlApartados.SelectedValue), cbEscritura.Checked, cbEditar.Checked, cbEliminar.Checked)
        cargarTablaElementos(1, hfIDUsuario.Value, "consulta", hfID.Value)
        msjNot()


    End Sub

    Protected Sub repeaterPermisos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Edit") Then

            cargarTablaElementos(2, hfIDUsuario.Value, "consulta_ID", Integer.Parse(e.CommandArgument))
            hfID.Value = e.CommandArgument
            lbntCancelar.Visible = True
            hfquery.Value = "modificar"
            MuestraErrorToast("Listo", -1, True)

        ElseIf e.CommandName = "Eli" Then

            Pag_Usuarios_Permisos_BLL.crudPermisos("Eliminar", Integer.Parse(e.CommandArgument), 0, 0, False, False, False)
            cargarTablaElementos(1, Int32.Parse(hfIDUsuario.Value), "consulta", hfID.Value)
            msjNot()
        End If


    End Sub

    Protected Sub lbntCancelar_Click(sender As Object, e As EventArgs)
        iniciarControles()
        MuestraErrorToast("Listo", -1, True)
    End Sub
End Class