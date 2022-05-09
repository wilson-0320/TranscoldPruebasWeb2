Public Class FrmRequerimientosPruebas
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                inicializar()
                cargarddlCatalogo(3)

            Catch ex As Exception

            End Try
        End If
    End Sub


    Private Sub inicializar()
        tbDescripcion.Text = ""
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
        For index As Integer = 0 To repeaterRegistrosPruebas.Items.Count - 1 Step 1
            'Modificar
            CType(repeaterRegistrosPruebas.Items(index).FindControl("LinkButton1"), LinkButton).Visible = mod1
            'Eliminar
            CType(repeaterRegistrosPruebas.Items(index).FindControl("LinkButton3"), LinkButton).Visible = eli1
        Next

    End Sub
    Private Function validarCrud() As Boolean

        For Each CampoTexto As TextBox In New TextBox() {
            tbDescripcion
            }

            If CampoTexto.Text = "" Then
                MuestraErrorToast("Debe especificar el valor del campo " + CampoTexto.ToolTip, 3, True)
                Return False
            End If


        Next
        Return True

    End Function


    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        If (validarCrud()) Then

            guardarMultiple()

            inicializar()

            cargarRepeatElementos("Consultar", Integer.Parse(hfID.Value), ddlEnsayo.SelectedValue, ddlTipo.SelectedValue)

            MuestraErrorToast("Listo", 1, True)
        End If
    End Sub
    Protected Sub lbtnCancelar_Click(sender As Object, e As EventArgs)
        inicializar()
        MuestraErrorToast("", 0, True)
    End Sub

    Private Sub cargarddlCatalogo(ByVal Categoria_ID)

        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Catalogo_Actualiza", New Object() {
                                                                    New Object() {"@Tipo", "consultarCat2"},
                                                                    New Object() {"@Categoria_ID", Categoria_ID}
                                                                    }, CommandType.StoredProcedure).Tables(0)
        '3: Ensayos
        '4 Tipo de carga
        '1 Personal
        Select Case (Categoria_ID)

            Case 3

                'Categoria de refrigeracion de protoispos
                lbxCatalogo.DataSource = DTOrig
                lbxCatalogo.DataTextField = "Descripcion"
                lbxCatalogo.DataValueField = "ID"
                lbxCatalogo.DataBind()

                ddlEnsayo.DataSource = DTOrig
                ddlEnsayo.DataTextField = "Descripcion"
                ddlEnsayo.DataValueField = "ID"
                ddlEnsayo.DataBind()
        End Select


    End Sub

    Private Sub cargarRepeatElementos(ByVal querys As String, ByVal ID As Integer, ByVal ID_Catalogo As String, ByVal Tipo As String)
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Elemento_Requerimientos_Actualiza", New Object() {
                                                                 New Object() {"@Tipo", querys.TrimEnd},
                                                                 New Object() {"@Categoria_ID", ID_Catalogo},
                                                                 New Object() {"@Tipo_", Tipo.TrimEnd},
                                                                 New Object() {"@ID", ID}
                                                                 }, CommandType.StoredProcedure).Tables(0)

        If (querys.TrimEnd.Equals("Consultar")) Then
            repeaterRegistrosPruebas.DataSource = DTOrig
            repeaterRegistrosPruebas.DataBind()
            controlesRepeater()

        Else
        hfID.Value = DTOrig.Rows(0).Item(0)
        tbDescripcion.Text = DTOrig.Rows(0).Item(1).ToString.TrimEnd
        tbValores.Text = DTOrig.Rows(0).Item(2).ToString.TrimEnd
        End If



    End Sub
    Protected Sub ddlTipo_SelectedIndexChanged(sender As Object, e As EventArgs)

        hfIDElementos.Value = ddlEnsayo.SelectedValue
        cargarRepeatElementos("Consultar", 0, Integer.Parse(hfIDElementos.Value), sender.SelectedValue)
        MuestraErrorToast("", 0, True)
    End Sub

    Protected Sub ddlEnsayo_SelectedIndexChanged(sender As Object, e As EventArgs)
        If (sender.SelectedValue > 0) Then
            hfIDElementos.Value = sender.SelectedValue
            cargarRepeatElementos("Consultar", 0, sender.SelectedValue, ddlTipo.SelectedValue)

        End If
        MuestraErrorToast("", 0, True)
    End Sub

    Private Function guardarMultiple() As Boolean
        Dim l As New List(Of String)
        For Each li As ListItem In lbxCatalogo.Items
            If li.Selected Then
                Try
                    BLL.Elemento_Requerimientos_BLL.insertar_actualizar(hfQuery.Value, hfID.Value, li.Value, tbDescripcion.Text, tbValores.Text, ddlTipo.SelectedValue)

                Catch ex As Exception
                    ' Return False
                End Try

                'l.Add(li.Value)
            End If
        Next
        Return True
    End Function
    Protected Sub repeaterRegistrosPruebas_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") Then
            MuestraErrorToast(BLL.Elemento_Requerimientos_BLL.eliminar(Integer.Parse(e.CommandArgument)), 1, True)
            BLL.Elemento_Requerimientos_BLL.subir_bajar(ddlEnsayo.SelectedValue, Nothing, "Reordenar")
            cargarRepeatElementos("Consultar", Integer.Parse(hfID.Value), Integer.Parse(hfIDElementos.Value), ddlTipo.SelectedValue)


        ElseIf (e.CommandName = "Edit") Then
            lbtnCancelar.Visible = True
            hfID.Value = (e.CommandArgument).ToString.TrimEnd
            hfQuery.Value = "Modificar"
            lbtnGuardar.Enabled = True
            cargarRepeatElementos("Consultar_id", Integer.Parse(hfID.Value), Integer.Parse(hfIDElementos.Value), ddlTipo.SelectedValue)
            MuestraErrorToast("", 0, True)
        ElseIf (e.CommandName = ("Arriba") Or e.CommandName = "Abajo") Then
            BLL.Elemento_Requerimientos_BLL.subir_bajar(ddlEnsayo.SelectedValue, Integer.Parse(e.CommandArgument), e.CommandName)
            cargarRepeatElementos("Consultar", Integer.Parse(hfID.Value), Integer.Parse(hfIDElementos.Value), ddlTipo.SelectedValue)
            MuestraErrorToast("Listo", 1, True)
        End If
    End Sub


End Class