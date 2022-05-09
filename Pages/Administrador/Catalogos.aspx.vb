Public Class Catalogos
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                inicializar()

                cargarddlCategorias()
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub inicializar()
        tbDescripcion.Text = ""
        cbVigente.Checked = True
        hfID.Value = "-1"
        hfIDCategoria.Value = "-1"
        lbtnCancelar.Visible = False
        lbtnGuardar.Enabled = Roles("Administrador", 1)


    End Sub

    Private Sub controlesRepeater()
        Dim mod1 As Boolean = Roles("Administrador", 2)
        Dim eli1 As Boolean = Roles("Administrador", 1)

        For index As Integer = 0 To repeaterCatalogo.Items.Count - 1 Step 1
            'Modificar
            CType(repeaterCatalogo.Items(index).FindControl("LinkButton1"), LinkButton).Visible = mod1

            'Eliminar
            CType(repeaterCatalogo.Items(index).FindControl("LinkButton3"), LinkButton).Visible = eli1
        Next


    End Sub

    '''''''''''Carga de repeat y listados ''''''''''''''''''''''''''''
    Private Sub cargarddlCategorias()
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Catalogo_Categoria_ABCD", New Object() {
                                                                  New Object() {"@Tipo", "Consultar"}
                                                                  }, CommandType.StoredProcedure).Tables(0)


        ddlCategoria.DataSource = DTOrig
        ddlCategoria.DataTextField = "Descripcion"
        ddlCategoria.DataValueField = "ID"
        ddlCategoria.DataBind()

    End Sub

    Private Sub cargarRepeatCatalogoCategorias(ByVal idCatalogo As Integer, ByVal tipo As String)
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Catalogo_Actualiza", New Object() {
                                                                 New Object() {"@Tipo", tipo},
                                                                 New Object() {"@Categoria_ID", idCatalogo},
                                                                 New Object() {"@ID", idCatalogo}
                                                                 }, CommandType.StoredProcedure).Tables(0)

        If (tipo.Equals("Cons_id")) Then
            tbDescripcion.Text = DTOrig.Rows(0).Item(0)
            cbVigente.Checked = DTOrig.Rows(0).Item(1)
            hfID.Value = DTOrig.Rows(0).Item(2)
        Else
            repeaterCatalogo.DataSource = DTOrig
            repeaterCatalogo.DataBind()
            controlesRepeater()
        End If

    End Sub
    ''''''''''''''''''''''''Click de botones ''''''''''''''''''''''''''''
    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        Dim UltID, ext As String
        ext = Nothing
        If fuArchivo.HasFile Then
            If fuArchivo.FileName.Contains(".") Then
                Dim v As String() = fuArchivo.FileName.Split(".")
                ext = "." + v(v.Length - 1)
            Else
                ext = ""
            End If
        End If
        If Integer.Parse(hfID.Value) <> -1 Then
            UltID = BLL.Catalogo_Categoria_BLL.insertar("Actualizar", hfID.Value, hfIDCategoria.Value, tbDescripcion.Text, cbVigente.Checked, ext)
            ' UltID = CatalogoGridView.SelectedValue.ToString
        Else
            UltID = BLL.Catalogo_Categoria_BLL.insertar("Insertar", hfID.Value, hfIDCategoria.Value, tbDescripcion.Text, cbVigente.Checked, ext)

        End If
        If fuArchivo.HasFile Then
            Try
                Dim Path As String = "E:\\EstaticosWeb\\TranscoldPruebasWeb\\Catalogo\\"
                fuArchivo.SaveAs(Path + "\\" + UltID + ext)
            Catch ex As Exception
                'Alerta(ex.Message)
            End Try
        End If
        cargarRepeatCatalogoCategorias(ddlCategoria.SelectedValue, "Con_ID_Cat2")
        inicializar()
        hfIDCategoria.Value = ddlCategoria.SelectedValue
        MuestraErrorToast("Listo", 1, True)
    End Sub

    Protected Sub lbtnCancelar_Click(sender As Object, e As EventArgs)
        inicializar()
        MuestraErrorToast("", 0, True)
    End Sub

    Protected Sub ddlCategoria_SelectedIndexChanged(sender As Object, e As EventArgs)

        If (sender.SelectedValue > 0) Then
            hfIDCategoria.Value = sender.SelectedValue
            cargarRepeatCatalogoCategorias(sender.SelectedValue, "Con_ID_Cat2")

        End If
        MuestraErrorToast("", 0, True)
    End Sub

    Protected Sub repeaterCatalogo_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") Then
            BLL.Catalogo_Categoria_BLL.eliminar(Int32.Parse(e.CommandArgument))
            cargarRepeatCatalogoCategorias(hfIDCategoria.Value, "Con_ID_Cat2")

            MuestraErrorToast("Si el elemento no fue eliminado, el registro tiene registros vinculados", 2, True)
        ElseIf (e.CommandName = "Edit") Then
            lbtnCancelar.Visible = True
            lbtnGuardar.Enabled = True
            cargarRepeatCatalogoCategorias(Int32.Parse(e.CommandArgument), "Cons_id")
            MuestraErrorToast("", 0, True)

        End If


    End Sub
End Class