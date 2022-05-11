Public Class Elemento
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                inicializar()
                cargarddlCatalogo()

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub inicializar()
        tbDescripcion.Text = ""
        cbPrecio.Checked = False
        cbCantidad.Checked = False
        cbUnico.Checked = False
        cbExactus.Checked = False
        tbValores.Text = ""
        hfID.Value = "-1"
        hfIDElementos.Value = "-1"
        hfQuery.Value = "Insertar"
        lbtnCancelar.Visible = False
        lbtnGuardar.Enabled = Roles("Administrador", 1)
    End Sub
    Private Sub controlesRepeater()
        Dim mod1 As Boolean = Roles("Administrador", 2)
        Dim eli1 As Boolean = Roles("Administrador", 3)

        For index As Integer = 0 To repeaterRegistrosProtitpos.Items.Count - 1 Step 1
            'Modificar
            CType(repeaterRegistrosProtitpos.Items(index).FindControl("LinkButton1"), LinkButton).Visible = mod1
            'Eliminar
            CType(repeaterRegistrosProtitpos.Items(index).FindControl("LinkButton3"), LinkButton).Visible = eli1
        Next


    End Sub
    Private Sub msjNot()
        If Not BLL.Elemento_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Elemento_BLL.MsjError, 4, True)
        Else
            MuestraErrorToast("", 0, True)
        End If
    End Sub

    Private Function validarCrud() As Boolean

        For Each CampoTexto As TextBox In New TextBox() {
            tbDescripcion
            }

            If CampoTexto.Text = "" Then
                MuestraErrorToast("Debe especificar el valor del campo " + CampoTexto.ToolTip, 3, True)
                CampoTexto.Focus()
                Return False
            End If


        Next
        Return True

    End Function

    Private Sub cargarddlCatalogo()
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Catalogo_Actualiza", New Object() {
                                                                  New Object() {"@Tipo", "consultarCat"},
                                                                  New Object() {"@Categoria_ID", 5}
                                                                  }, CommandType.StoredProcedure).Tables(0)

        'Categoria de refrigeracion de protoispos
        ddlCatalogo.DataSource = DTOrig
        ddlCatalogo.DataTextField = "Descripcion"
        ddlCatalogo.DataValueField = "ID"
        ddlCatalogo.DataBind()
    End Sub

    Private Sub cargarRepeatElementos(ByVal querys As String, ByVal ID As Integer, ByVal ID_Catalogo As String)
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Elemento_Actualiza", New Object() {
                                                                 New Object() {"@Tipo", querys.TrimEnd},
                                                                 New Object() {"@Categoria_ID", ID_Catalogo},
                                                                 New Object() {"@ID", ID}
                                                                 }, CommandType.StoredProcedure).Tables(0)

        If (querys.TrimEnd.Equals("Consultar")) Then
            repeaterRegistrosProtitpos.DataSource = DTOrig
            repeaterRegistrosProtitpos.DataBind()
            controlesRepeater()
        Else
            hfID.Value = DTOrig.Rows(0).Item(0)
            tbDescripcion.Text = DTOrig.Rows(0).Item(1).ToString.TrimEnd
            ddlTipo.SelectedValue = DTOrig.Rows(0).Item(2).ToString.TrimEnd
            cbPrecio.Checked = DTOrig.Rows(0).Item(3)
            cbCantidad.Checked = DTOrig.Rows(0).Item(4)
            cbUnico.Checked = DTOrig.Rows(0).Item(5)
            tbValores.Text = DTOrig.Rows(0).Item(6).ToString.TrimEnd
            cbExactus.Checked = DTOrig.Rows(0).Item(7)
            tbValores.Focus()
        End If



    End Sub

    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        If (validarCrud()) Then
            BLL.Elemento_BLL.insertar_actualizar(hfQuery.Value, hfID.Value, hfIDElementos.Value, tbDescripcion.Text, cbPrecio.Checked, cbCantidad.Checked, cbUnico.Checked, tbValores.Text, cbExactus.Checked, ddlTipo.SelectedValue)
            cargarRepeatElementos("Consultar", 0, hfIDElementos.Value)
            inicializar()
            hfIDElementos.Value = ddlCatalogo.SelectedValue
            msjNot()
        End If
    End Sub
    Protected Sub lbtnCancelar_Click(sender As Object, e As EventArgs)
        inicializar()
        MuestraErrorToast("", 0, True)
    End Sub


    Protected Sub ddlCatalogo_SelectedIndexChanged(sender As Object, e As EventArgs)

        If (sender.SelectedValue > 0) Then
            hfIDElementos.Value = sender.SelectedValue
            cargarRepeatElementos("Consultar", 0, sender.SelectedValue)
            lbtnGuardar.Enabled = True
        End If
        MuestraErrorToast("", 0, True)
    End Sub
    Protected Sub repeaterRegistrosProtitpos_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") Then


            BLL.Elemento_BLL.eliminar(Integer.Parse(e.CommandArgument))
            msjNot()
            BLL.Elemento_BLL.insertar_actualizar("Reordenar", Integer.Parse(e.CommandArgument), ddlCatalogo.SelectedValue, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            cargarRepeatElementos("Consultar", Integer.Parse(hfID.Value), Integer.Parse(hfIDElementos.Value))

        ElseIf (e.CommandName = "Edit") Then
            lbtnCancelar.Visible = True
            lbtnGuardar.Enabled = True
            hfID.Value = (e.CommandArgument).ToString.TrimEnd
            hfQuery.Value = "Actualizar"
            cargarRepeatElementos("Consultar_id", Integer.Parse(hfID.Value), Integer.Parse(hfIDElementos.Value))
            MuestraErrorToast("", 0, True)
        ElseIf (e.CommandName = ("Arriba") Or e.CommandName = "Abajo") Then
            BLL.Elemento_BLL.insertar_actualizar(e.CommandName, Integer.Parse(e.CommandArgument), ddlCatalogo.SelectedValue, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            cargarRepeatElementos("Consultar", Integer.Parse(hfID.Value), Integer.Parse(hfIDElementos.Value))
            msjNot()
        End If

    End Sub


End Class