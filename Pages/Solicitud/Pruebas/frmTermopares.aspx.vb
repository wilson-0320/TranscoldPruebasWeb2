Public Class frmTermopares
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            hfCodigo.Value = Request.QueryString("codigo")
            cargarDllFechas()
            inicializar()
            '   hlCodSolicitud.NavigateUrl = "Solicitud.aspx?Correlativo=" + Request.QueryString("codigo")
            '  ViewState("usuario") = User.Identity.Name
            ' tabControl.ActiveTabIndex = 0
            ' ddlFecha.DataBind()
            ' If ddlFecha.Items.Count > 0 Then
            'ddlFecha.SelectedIndex = 0
            'End If
        End If
        For Each wuc As wucTermopar In ObtWucsTermopar()
            wuc.codigo = Request.QueryString("codigo")
            wuc.stFecha = ddlFecha.SelectedValue
        Next
    End Sub

    Private Sub inicializar()
        panelEditorFecha.Visible = False
    End Sub


    Private Sub cargarDllFechas()

        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Termopar_sp", New Object() {
                                                                    New Object() {"@query", "consulta_fechas"},
                                                                    New Object() {"@cod_solicitud", hfCodigo.Value}
                                                                    }, CommandType.StoredProcedure).Tables(0)

        ddlFecha.DataSource = DTOrig
        ddlFecha.DataValueField = "stFecha"
        ddlFecha.DataTextField = "muestra"
        ddlFecha.DataBind()

        RepeaterFechas.DataSource = DTOrig
        RepeaterFechas.DataBind()



    End Sub


    Private Function ObtWucsTermopar() As List(Of wucTermopar)
        Dim l As New List(Of wucTermopar)
        ',"divRefrSystem1", "divRefrSystem2"
        Dim nombres As String() = {"tabProdTemp", "divRefrSystem1", "divRefrSystem2", "tabGlassDoor", "divEvaporatorPan", "divElectrIndivM", "divStationParams", "divValoresAdicionales"}
        ', "divRefrSystem2", "tabGlassDoor", "divEvaporatorPan", "divElectrIndivM", "divStationParams", "divValoresAdicionales"

        For Each tab As String In nombres
            Dim divName As String = "div" + Right(tab, tab.Length - 3)
            Dim wucName As String = "wuc" + Right(tab, tab.Length - 3)


            'Content1
            Dim wuc As wucTermopar = pnlTodo.FindControl(divName).FindControl(wucName)
            '
            ' Dim wuc As wucTermopar = pnlTodo.FindControl("divRefrSystem1").FindControl("wucRefrSystem1")
            If Not wuc Is Nothing Then
                l.Add(wuc)
            End If
        Next
        Return l
    End Function
    Private Sub CargarTodo()
        gvFilas.DataBind()
        For Each wuc As wucTermopar In ObtWucsTermopar()
            wuc.CargarDatos()
        Next
    End Sub

    ' ---------------------------------------------------------------- PRODUCT TEMPERATURES ----------------------------------------------------------------

    Private Sub ObtieneProductTemperatures(ByRef dt As DataTable)
        For fila As Integer = 1 To gvFilas.Rows.Count
            Dim row As GridViewRow = gvFilas.Rows(fila - 1)
            Dim repColumnas As Repeater = row.FindControl("repColumnas")
            For col As Integer = 1 To repColumnas.Items.Count
                Dim tblPosicion As HtmlTable = repColumnas.Items(col - 1).FindControl("tblPosicion")
                Dim hfPosicion As HiddenField = tblPosicion.FindControl("hfPosicion")
                Dim chbParticipaProm As CheckBox = tblPosicion.FindControl("chbParticipaProm")
                Dim tbNumCanal As TextBox = tblPosicion.FindControl("tbNumCanal")
                dt.Rows.Add(hfPosicion.Value, tbNumCanal.Text, chbParticipaProm.Checked, "", Nothing)
            Next
        Next
    End Sub


    Protected Sub gvFilas_PreRender(sender As Object, e As EventArgs) Handles gvFilas.PreRender
        For rowIndex As Integer = 0 To gvFilas.Rows.Count - 1
            Dim row As GridViewRow = gvFilas.Rows(rowIndex)
            row.BorderColor = Drawing.Color.Transparent

            If rowIndex = 0 Then
                row.Style("border-top") = "black"
            End If

            If (rowIndex + 1) Mod 3 = 0 Then
                row.Style("border-bottom") = "black"
            End If

            For Each cell As TableCell In row.Cells
                cell.Style("padding") = "0px"
            Next
        Next
    End Sub
    Protected Sub dsTermoparFila_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs) Handles dsTermoparFila.Selecting
        Dim dt As New DataTable
        dt.Columns.Add("fila", GetType(Integer))
        dt.Columns.Add("fila_de_3", GetType(String))
        For i As Integer = 1 To 24
            dt.Rows.Add(i, IIf((i - 2) Mod 3 = 0, 9 - ((i - 2) / 3 + 1), ""))
        Next
        e.InputParameters("dt") = dt
    End Sub

    Protected Sub repColumnas_PreRender(sender As Object, e As EventArgs)
        Dim repColumnas As Repeater = sender
        For colIndex As Integer = 0 To repColumnas.Items.Count - 1
            Dim col As RepeaterItem = repColumnas.Items(colIndex)
            Dim tblPosicion As HtmlTable = col.FindControl("tblPosicion")
            Dim hfPosicion As HiddenField = tblPosicion.FindControl("hfPosicion")
            Dim posicion As Integer = hfPosicion.Value

            If (posicion - 1) Mod 9 = 0 Then
                tblPosicion.Attributes("style") = "border-left: 1px solid black;"
            End If
            If (posicion - 1) Mod 3 = 0 Then
                tblPosicion.Rows(0).Cells(0).Attributes("style") = "padding-left: 5px;"
            End If
            If posicion Mod 3 = 0 Then
                tblPosicion.Attributes("style") = "border-right: 1px solid black;"
                tblPosicion.Rows(0).Cells(tblPosicion.Rows(0).Cells.Count - 1).Attributes("style") = "padding-right: 5px;"
            End If
        Next

    End Sub

    Private Sub Guardar(stFecha As String)
        Dim dt As New DataTable
        dt.Columns.Add("posicion", GetType(Integer))
        dt.Columns.Add("num_canal", GetType(String))
        dt.Columns.Add("participa_prom", GetType(Boolean))
        dt.Columns.Add("num", GetType(String))
        dt.Columns.Add("nombre", GetType(String))
        Try
            ObtieneProductTemperatures(dt)
            For Each wuc As wucTermopar In ObtWucsTermopar()
                wuc.AgregaADt(dt)
            Next
        Catch ex As Exception
            Alerta(ex.Message, True)
            Exit Sub
        End Try

        stFecha = BLL.Pru_Termopar_BLL.guarda(hfCodigo.Value, dt, stFecha, Session("Usuario").ToString)
        If Not BLL.Pru_Termopar_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Pru_Termopar_BLL.MsjError, 4, True)

        Else
            MuestraErrorToast("Registros realizados", 1, True)
            panelEditorFecha.Visible = False
            cargarDllFechas()
            Try
                ddlFecha.SelectedValue = stFecha
            Catch ex As Exception

            End Try

            CargarTodo()
        End If
    End Sub

    Private Sub eliminar(stFecha As String)


        BLL.Pru_Termopar_BLL.eliminar(hfCodigo.Value, stFecha)
        If Not BLL.Pru_Termopar_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Pru_Termopar_BLL.MsjError, 4, True)

        Else
            MuestraErrorToast("Registros realizados", 1, True)
            panelEditorFecha.Visible = False
            cargarDllFechas()
            Try
                ddlFecha.SelectedValue = stFecha
            Catch ex As Exception

            End Try

            CargarTodo()
        End If
    End Sub

    Private Sub validar(stFecha As String)


        BLL.Pru_Termopar_BLL.validar(hfCodigo.Value, stFecha)
        If Not BLL.Pru_Termopar_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Pru_Termopar_BLL.MsjError, 4, True)

        Else
            MuestraErrorToast("Registros realizados", 1, True)
            panelEditorFecha.Visible = False
            cargarDllFechas()
            Try
                ddlFecha.SelectedValue = stFecha
            Catch ex As Exception

            End Try

            CargarTodo()
        End If
    End Sub



    Protected Sub lbtnModificarFecha_Click(sender As Object, e As EventArgs)
        If panelEditorFecha.Visible Then
            panelEditorFecha.Visible = False
        Else
            If String.IsNullOrEmpty(ddlFecha.SelectedValue) Then
                MuestraErrorToast("No ha seleccionado una fecha", 4, True)
            Else
                panelEditorFecha.Visible = True
                Dim hora As String() = Left(ddlFecha.SelectedValue, 16).Split(" ")
                Dim fechas As String() = Left(ddlFecha.SelectedValue, 10).Split("T")
                ' yyyyMMdd THHmm
                ''  tbFechaReemplazo.Text = fechas(2) + "-" + fechas(1) + "-" + fechas(0) + "T" + hora(1)
                tbFechaReemplazo.Text = Left(ddlFecha.SelectedValue, 16).Replace(" ", "T")
                'MuestraErrorToast(tbFechaReemplazo.Text, 4, True)
            End If
        End If
    End Sub

    Protected Sub lbtnFiltrar_Click(sender As Object, e As EventArgs)
        CargarTodo()
    End Sub


    Protected Sub lbtnModificar_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(ddlFecha.SelectedValue) Then
            MuestraErrorToast("No ha seleccionado una fecha", 4, True)
        Else
            Guardar(ddlFecha.SelectedValue)
        End If
    End Sub

    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        Guardar("")
    End Sub

    Protected Sub ddlFecha_SelectedIndexChanged(sender As Object, e As EventArgs)
        panelEditorFecha.Visible = False
        CargarTodo()
    End Sub

    Protected Sub lbtnGuardarFecha_Click(sender As Object, e As EventArgs)
        If tbFechaReemplazo.Text Is Nothing Then
            MuestraErrorToast("No coloco una fecha", 4, True)
        Else
            BLL.Pru_Termopar_BLL.guardar_fecha(hfCodigo.Value, ddlFecha.SelectedValue, tbFechaReemplazo.Text, Session("Usuario").ToString)
            If Not BLL.Pru_Termopar_BLL.MsjError Is Nothing Then
                ' Alerta(BLL.Pru_Termopar_BLL.MsjError, True)
                MuestraErrorToast(BLL.Pru_Termopar_BLL.MsjError, 4, True)
            Else
                panelEditorFecha.Visible = False
                cargarDllFechas()
                ddlFecha.SelectedValue = CType(tbFechaReemplazo.Text, DateTime).ToString("yyy-MM-dd HH:mm:ss.fff")
            End If
        End If
    End Sub

    Protected Sub lbtnCancelarGuardarFecha_Click(sender As Object, e As EventArgs)
        panelEditorFecha.Visible = False
        MuestraErrorToast(tbFechaReemplazo.Text, 0, True)
    End Sub

    Protected Sub RepeaterFechas_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If e.CommandName = "eli" Then

            eliminar(e.CommandArgument)

        ElseIf e.CommandName = "val" Then
            validar(e.CommandArgument)
        End If

    End Sub
End Class