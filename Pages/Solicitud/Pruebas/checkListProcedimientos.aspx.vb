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


    Protected Sub repeaterCheck_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Edit") Then
            hfIDElemento.Value = e.CommandArgument.ToString.Split("|")(2)
            hfID.Value = e.CommandArgument.ToString.Split("|")(1)
            Dim DTOrigin As String() = e.CommandArgument.ToString.Split("|")(3).Split(",")


            Dim dt As DataTable = New DataTable()
            dt.Columns.Add(New DataColumn("ID", GetType(String)))
            dt.Columns.Add(New DataColumn("Elementos", GetType(String)))
            For Each datos As String In DTOrigin
                dt.Rows.Add(CreateRow(datos, datos, dt))
            Next


            ddlValores.DataSource = dt
            ddlValores.DataTextField = "ID".TrimEnd
            ddlValores.DataValueField = "ID".TrimEnd
            ddlValores.DataBind()
            If (Integer.Parse(hfID.Value) > 0) Then
                hfQuery.Value = "Modificar"

                Try
                    ddlValores.SelectedValue = e.CommandArgument.ToString.Split("|")(0).TrimEnd


                Catch ex As Exception

                End Try


            End If
            lbtnLimpiar.Visible = True

            '  cargarRepeatCheck()
        ElseIf (e.CommandName = "Check") Then
            Dim datosArgumento As String() = e.CommandArgument.ToString.Split("|")
            BLL.Solicitud_Check_Req_BLL.inserta_actualiza_elimina_("Insertar", datosArgumento(0), tbCodigo.Text, datosArgumento(1), 0, "Realizado", "Usuario")
            '  cargarReporteDetalles(Integer.Parse(e.CommandArgument))
            cargarRepeatCheck()
        End If
        MuestraErrorToast("", 0, True)
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
End Class