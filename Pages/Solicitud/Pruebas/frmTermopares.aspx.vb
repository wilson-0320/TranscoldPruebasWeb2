Public Class frmTermopares
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '    hlCodSolicitud.Text = Request.QueryString("codigo")
            '   hlCodSolicitud.NavigateUrl = "Solicitud.aspx?Correlativo=" + Request.QueryString("codigo")
            '  ViewState("usuario") = User.Identity.Name
            ' tabControl.ActiveTabIndex = 0
            ' ddlFecha.DataBind()
            ' If ddlFecha.Items.Count > 0 Then
            'ddlFecha.SelectedIndex = 0
            'End If
        End If
        For Each wuc As wucTermopar In ObtWucsTermopar()
            wuc.codigo = "22/0001"
            wuc.stFecha = ddlFecha.SelectedValue
        Next
    End Sub

    Private Function ObtWucsTermopar() As List(Of wucTermopar)
        Dim l As New List(Of wucTermopar)
        Dim nombres As String() = {"divRefrSystem1", "divRefrSystem2", "divGlassDoor", "divEvaporatorPan", "divElectrIndivM", "divStationParams", "divValoresAdicionales"}


        For Each tab As String In nombres
            Dim divName As String = "div" + Right(tab, tab.Length - 3)
            Dim wucName As String = "wuc" + Right(tab, tab.Length - 3)
            'Content1
            ' Dim wuc As wucTermopar = pnlTodo.FindControl("divRefrSystem1").FindControl("wucRefrSystem1")
            '
            Dim wuc As wucTermopar = pnlTodo.FindControl("divRefrSystem1").FindControl("wucRefrSystem1")
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


    Private Sub test()

    End Sub

    Protected Sub lbtnModificarFecha_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub lbtnFiltrar_Click(sender As Object, e As EventArgs)

    End Sub


    Protected Sub lbtnModificar_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)

    End Sub
End Class