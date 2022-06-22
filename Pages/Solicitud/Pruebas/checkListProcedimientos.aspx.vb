Public Class checkListProcedimientos
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            inicializar()
            Try

                If Not Request.QueryString("Codigo") Is Nothing Then
                    cargarddlEnsayos("Sol")
                End If
            Catch ex As Exception
            End Try


        End If
    End Sub

    Private Sub inicializar()
        lbtnLimpiar.Visible = False
        hfID.Value = "-1"
        hfIDElemento.Value = "-1"

        hfQuery.Value = "Insertar"
        Try
            ddlValores.Items.Clear()
        Catch ex As Exception
            Console.WriteLine("" + ex.Message)
        End Try

    End Sub

    Private Sub cargarddlEnsayos(ByVal tipo As String)

        Dim DTOrigin As DataTable = BLL.Pru_Eventos_BLL.consultar_pruebas_y_eventos_2(tbCodigo.Text, tipo)
        ddlEnsayos.DataSource = DTOrigin
        ddlEnsayos.DataTextField = "Tipo_Ensayo"
        ddlEnsayos.DataValueField = "id"
        ddlEnsayos.DataBind()



    End Sub

    Public Sub retornarListado()

        Dim Descripcion As String = CType(repeaterCheck.Items(Int32.Parse(hfOrdenRepeater.Value)).FindControl("hfValores"), HiddenField).Value.TrimEnd
        Dim Valores As String = CType(repeaterCheck.Items(Int32.Parse(hfOrdenRepeater.Value)).FindControl("hfDescripcion"), HiddenField).Value.TrimEnd
        Try
            If (Valores.Contains(",")) Then


                Dim DTOriginValores As String() = Valores.ToString.Split(",")

                'lbOpciones.Visible = True
                'tbOpciones.Visible = False
                CType(repeaterCheck.Items(Int32.Parse(hfOrdenRepeater.Value)).FindControl("tbOpcionesListado"), TextBox).Visible = False
                CType(repeaterCheck.Items(Int32.Parse(hfOrdenRepeater.Value)).FindControl("ddlOpcionesListado"), ListBox).Visible = True
                Dim dt As DataTable = New DataTable()
                dt.Columns.Add(New DataColumn("ID", GetType(String)))
                dt.Columns.Add(New DataColumn("Elementos", GetType(String)))
                For Each datos As String In DTOriginValores
                    dt.Rows.Add(CreateRow(datos.TrimEnd, datos.TrimEnd, dt))
                Next


                Dim Seleccionar As String() = Descripcion.TrimEnd().Split(",")
                CType(repeaterCheck.Items(Int32.Parse(hfOrdenRepeater.Value)).FindControl("ddlOpcionesListado"), ListBox).DataSource = dt
                CType(repeaterCheck.Items(Int32.Parse(hfOrdenRepeater.Value)).FindControl("ddlOpcionesListado"), ListBox).DataTextField = "ID".TrimEnd
                CType(repeaterCheck.Items(Int32.Parse(hfOrdenRepeater.Value)).FindControl("ddlOpcionesListado"), ListBox).DataValueField = "ID".TrimEnd
                CType(repeaterCheck.Items(Int32.Parse(hfOrdenRepeater.Value)).FindControl("ddlOpcionesListado"), ListBox).DataBind()

                For a As Integer = 0 To Seleccionar.Length - 1 Step 1
                    For b As Integer = 0 To CType(repeaterCheck.Items(Int32.Parse(hfOrdenRepeater.Value)).FindControl("ddlOpcionesListado"), ListBox).Items.Count - 1 Step 1
                        If (CType(repeaterCheck.Items(Int32.Parse(hfOrdenRepeater.Value)).FindControl("ddlOpcionesListado"), ListBox).Items(b).ToString.TrimEnd.Equals(Seleccionar(a).TrimEnd)) Then

                            Try
                                CType(repeaterCheck.Items(Int32.Parse(hfOrdenRepeater.Value)).FindControl("ddlOpcionesListado"), ListBox).Items(b).Selected = True
                            Catch ex As Exception

                            End Try
                        End If
                    Next
                Next
            Else
                CType(repeaterCheck.Items(Int32.Parse(hfOrdenRepeater.Value)).FindControl("tbOpcionesListado"), TextBox).Visible = True
                CType(repeaterCheck.Items(Int32.Parse(hfOrdenRepeater.Value)).FindControl("ddlOpcionesListado"), ListBox).Visible = False
                CType(repeaterCheck.Items(Int32.Parse(hfOrdenRepeater.Value)).FindControl("tbOpcionesListado"), TextBox).Text = Descripcion.TrimEnd
            End If
        Catch ex As Exception

        End Try



        hfOrdenRepeater.Value = Int32.Parse(hfOrdenRepeater.Value) + 1

    End Sub

    Private Sub cargarRepeatCheck()
        Try
            Dim DTOrigin = BLL.Solicitud_Check_Req_BLL.consulta_reporte("consultar", hfID.Value, tbCodigo.Text, hfIDElemento.Value, ddlEnsayos.SelectedValue.ToString.Split("|")(0), ddlTipo.SelectedValue)

            repeaterCheck.DataSource = DTOrigin
            repeaterCheck.DataBind()
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub lbtnGuardarSolicitud_Click(sender As Object, e As EventArgs)
        If (ddlValores.SelectedValue.Length > 0) Then
            Try
                BLL.Solicitud_Check_Req_BLL.inserta_actualiza_elimina_(hfQuery.Value, hfID.Value, tbCodigo.Text, hfIDElemento.Value, ddlEnsayos.SelectedValue.Split("|")(0), ddlValores.SelectedValue, Session("Usuario").ToString)

            Catch ex As Exception

            End Try
            cargarRepeatCheck()
        End If
        MuestraErrorToast("Listo", 1, True)
    End Sub

    Protected Sub lbtnLimpiar_Click(sender As Object, e As EventArgs)
        inicializar()
        MuestraErrorToast("", 0, True)
    End Sub
    Private Function obtTiposReg(ByVal numero As Integer) As String
        Dim l As New List(Of String)
        For Each li As ListItem In CType(repeaterCheck.Items(numero).FindControl("ddlOpcionesListado"), ListBox).Items
            If li.Selected Then
                l.Add(li.Value)
            End If
        Next
        Return String.Join(",", l.ToArray)
    End Function


    Protected Sub repeaterCheck_ItemCommand(source As Object, e As RepeaterCommandEventArgs)


        'If (e.CommandName = "Edit") Then
        'hfIDElemento.Value = e.CommandArgument.ToString.Split("|")(2)
        'hfID.Value = e.CommandArgument.ToString.Split("|")(1)
        'Dim DTOrigin As String() = e.CommandArgument.ToString.Split("|")(3).Split(",")
        '

        ' Dim dt As DataTable = New DataTable()
        'dt.Columns.Add(New DataColumn("ID", GetType(String)))
        'dt.Columns.Add(New DataColumn("Elementos", GetType(String)))
        'For Each datos As String In DTOrigin
        'dt.Rows.Add(CreateRow(datos, datos, dt))
        'Next


        'ddlValores.DataSource = dt
        'ddlValores.DataTextField = "ID".TrimEnd
        'ddlValores.DataValueField = "ID".TrimEnd
        'ddlValores.DataBind()

        'lblOpcionesListado
        '   If (Integer.Parse(hfID.Value) > 0) Then
        ''  hfQuery.Value = "Modificar"

        '  Try
        'ddlValores.SelectedValue = e.CommandArgument.ToString.Split("|")(0).TrimEnd
        '
        '
        'Catch ex As Exception

        '        End Try


        'End If
        'lbtnLimpiar.Visible = True

        '  cargarRepeatCheck()
        'Else
        If (e.CommandName = "Check") Then
            Dim s As String = CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).Text
            'e.Item.ItemIndex
            'CType(repeaterCheck.Items(Int32.Parse(hfOrdenRepeater.Value)).FindControl("ddlOpcionesListado"), DropDownList).DataBind()
            Dim queryCheck As String = ""
            If (CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("lblOpcionesListado"), Label).Text.TrimEnd.Equals("Finalizado")) Then
                queryCheck = "Modificar"
            Else
                queryCheck = "Insertar"
            End If
            Dim seleccion As String = CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).SelectedValue

            Dim datosArgumento As String() = e.CommandArgument.ToString.Split("|")
            Dim Descripcion As String = datosArgumento(3).TrimEnd
            Dim Valores As String = datosArgumento(2).TrimEnd
            Try
                If (Valores.Contains(",")) Then


                    Dim DTOriginValores As String() = Valores.ToString.Split(",")

                    'lbOpciones.Visible = True
                    'tbOpciones.Visible = False
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("tbOpcionesListado"), TextBox).Visible = False
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).Visible = True
                    Dim dt As DataTable = New DataTable()
                    dt.Columns.Add(New DataColumn("ID", GetType(String)))
                    dt.Columns.Add(New DataColumn("Elementos", GetType(String)))
                    For Each datos As String In DTOriginValores
                        dt.Rows.Add(CreateRow(datos.TrimEnd, datos.TrimEnd, dt))
                    Next


                    Dim Seleccionar As String() = Descripcion.TrimEnd().Split(",")
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).DataSource = dt
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).DataTextField = "ID".TrimEnd
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).DataValueField = "ID".TrimEnd
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).DataBind()


                Else
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("tbOpcionesListado"), TextBox).Visible = True
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).Visible = False
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("tbOpcionesListado"), TextBox).Text = Descripcion.TrimEnd
                End If
            Catch ex As Exception

            End Try







            Dim opcion As String = ""
            If (CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).Visible) Then
                Dim TEST As ListItemCollection = CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).Items
                Dim l As New List(Of String)
                For Each li As ListItem In TEST
                    If li.Selected Then
                        l.Add(li.Value)
                    End If
                Next
                opcion = String.Join(",", l.ToArray)
            Else
                opcion = CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("tbOpcionesListado"), TextBox).Text.TrimEnd
            End If



            Try

                BLL.Solicitud_Check_Req_BLL.inserta_actualiza_elimina_(queryCheck, datosArgumento(0), tbCodigo.Text, datosArgumento(1), datosArgumento(4), CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).Items(0).Value, Session("Usuario").ToString)

            Catch ex As Exception

            End Try
            ' hfNum.Value = Integer.Parse(hfNum.Value) + 1
            cargarRepeatCheck()

            MuestraErrorToast("Agrego el cambio", 1, True)




            ' BLL.Solicitud_Check_Req_BLL.inserta_actualiza_elimina_("Insertar", datosArgumento(0), tbCodigo.Text, datosArgumento(1), 0, "Realizado", "Usuario")
            '  cargarReporteDetalles(Integer.Parse(e.CommandArgument))
            ' cargarRepeatCheck()

        ElseIf (e.CommandName = "Close") Then
            Dim s As String = CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).Text
            'e.Item.ItemIndex
            'CType(repeaterCheck.Items(Int32.Parse(hfOrdenRepeater.Value)).FindControl("ddlOpcionesListado"), DropDownList).DataBind()
            Dim queryCheck As String = ""
            If (CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("lblOpcionesListado"), Label).Text.TrimEnd.Equals("Finalizado")) Then
                queryCheck = "Modificar"
            Else
                queryCheck = "Insertar"
            End If
            Dim seleccion As String = CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).SelectedValue

            Dim datosArgumento As String() = e.CommandArgument.ToString.Split("|")
            Dim Descripcion As String = datosArgumento(3).TrimEnd
            Dim Valores As String = datosArgumento(2).TrimEnd
            Try
                If (Valores.Contains(",")) Then


                    Dim DTOriginValores As String() = Valores.ToString.Split(",")

                    'lbOpciones.Visible = True
                    'tbOpciones.Visible = False
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("tbOpcionesListado"), TextBox).Visible = False
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).Visible = True
                    Dim dt As DataTable = New DataTable()
                    dt.Columns.Add(New DataColumn("ID", GetType(String)))
                    dt.Columns.Add(New DataColumn("Elementos", GetType(String)))
                    For Each datos As String In DTOriginValores
                        dt.Rows.Add(CreateRow(datos.TrimEnd, datos.TrimEnd, dt))
                    Next


                    Dim Seleccionar As String() = Descripcion.TrimEnd().Split(",")
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).DataSource = dt
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).DataTextField = "ID".TrimEnd
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).DataValueField = "ID".TrimEnd
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).DataBind()


                Else
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("tbOpcionesListado"), TextBox).Visible = True
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).Visible = False
                    CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("tbOpcionesListado"), TextBox).Text = Descripcion.TrimEnd
                End If
            Catch ex As Exception

            End Try







            Dim opcion As String = ""
            If (CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).Visible) Then
                Dim TEST As ListItemCollection = CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).Items
                Dim l As New List(Of String)
                For Each li As ListItem In TEST
                    If li.Selected Then
                        l.Add(li.Value)
                    End If
                Next
                opcion = String.Join(",", l.ToArray)
            Else
                opcion = CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("tbOpcionesListado"), TextBox).Text.TrimEnd
            End If



            Try

                BLL.Solicitud_Check_Req_BLL.inserta_actualiza_elimina_(queryCheck, datosArgumento(0), tbCodigo.Text, datosArgumento(1), datosArgumento(4), CType(repeaterCheck.Items(e.Item.ItemIndex).FindControl("ddlOpcionesListado"), ListBox).Items(1).Value, Session("Usuario").ToString)

            Catch ex As Exception

            End Try
            ' hfNum.Value = Integer.Parse(hfNum.Value) + 1
            cargarRepeatCheck()

            MuestraErrorToast("Agrego el cambio", 1, True)




            ' BLL.Solicitud_Check_Req_BLL.inserta_actualiza_elimina_("Insertar", datosArgumento(0), tbCodigo.Text, datosArgumento(1), 0, "Realizado", "Usuario")
            '  cargarReporteDetalles(Integer.Parse(e.CommandArgument))
            ' cargarRepeatCheck()
        End If




    End Sub


    Function CreateRow(Text As String, Value As String, dt As DataTable) As DataRow

        Dim dr As DataRow = dt.NewRow()
        dr(0) = Text
        dr(1) = Value

        Return dr

    End Function

    Protected Sub tbCodigo_TextChanged(sender As Object, e As EventArgs)
        cargarddlEnsayos(ddlTipo.SelectedValue)
        cargarRepeatCheck()
        MuestraErrorToast("", 0, True)
    End Sub

    Protected Sub ddlEnsayos_SelectedIndexChanged(sender As Object, e As EventArgs)
        cargarRepeatCheck()
        MuestraErrorToast("", 0, True)
    End Sub



    Protected Sub ddlTipo_SelectedIndexChanged(sender As Object, e As EventArgs)
        cargarddlEnsayos(sender.selectedValue)
        cargarRepeatCheck()
        MuestraErrorToast("", 0, True)
    End Sub

    Protected Sub ddlOpcionesListado_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim a As String = sender.Text
        Dim B As String = sender.SelectedValue
        Dim c As ListItemCollection = sender.Items()

    End Sub
End Class