Public Class FrmSolicitudEntregas
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        '   cargarReporteEntregas()
        'cargarddlEntregas()
        If Not Page.IsPostBack Then
            If Request.QueryString("cod_solicitud") Is Nothing Then
                tbFechaIni.Text = Today.AddDays(-60).ToString("dd/MM/yyyy")
                tbFechaFin.Text = Today.ToString("dd/MM/yyyy")
            Else
                tbBuscar.Text = Request.QueryString("cod_solicitud")
            End If
        End If

    End Sub

    Private Sub msjNot()
        If Not BLL.Pru_Entrega_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Pru_Entrega_BLL.MsjError, 4, True)
        Else
            MuestraErrorToast("Listo", 1, True)
        End If
    End Sub



    Private Sub EnviaNotifEntregaRealizada(cod_solicitud As String, entrega As String)
        Dim destinatarios As New List(Of String)
        For Each dr As DataRow In BLL.Consulta_BLL.CatalogoPorCategoria(13).Rows
            destinatarios.Add(dr("Descripcion"))
        Next
        Dim varios As New Varios
        'destinatarios = New List(Of String)(New String() {"redwins@fogel-group.com"})
        Dim s = "La entrega """ + entrega + """ fue realizada a la solicitud " + cod_solicitud
        varios.Enviar_Mail(destinatarios, s,
                           s + "<br/><br/>https://www.fogelonline.com/TranscoldPruebasWeb/Solicitud/FrmSolicitudEntregas.aspx?cod_solicitud=" + cod_solicitud, Nothing, True)
    End Sub



    Protected Sub repeaterReporte_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Agregar") Then
            tbCodigoReporte.Text = e.CommandArgument()
            Dim key As String = Guid.NewGuid.ToString

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), key, "return abrirModalReporte();", True)

            MuestraErrorToast("Listo", 0, True)
            '    ElseIf (e.CommandName = "entrega") Then

        End If
    End Sub
    Protected Sub dsSolEntregas_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs)
        e.InputParameters("UserName") = Session("Usuario").ToString.TrimEnd
    End Sub


    Protected Sub rptSolEntregas_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "incluir") Then
            Dim v As String() = e.CommandArgument().Split(",")
            If (v(3) = 1) Then
                v(3) = "False"
            Else
                v(3) = "True"
            End If
            Dim key As String = Guid.NewGuid.ToString

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), key, "return abrirModalReporte();", True)
            BLL.Pru_Entrega_BLL.guardar_entrega_solicitud(v(1), v(2), Boolean.Parse(v(3)), Session("Usuario"))
            MuestraErrorToast("Listo", 1, True)
            '    ElseIf (e.CommandName = "entrega") Then
            repeaterReporte.DataBind()
        ElseIf (e.CommandName = "entregar") Then
            Dim v As String() = e.CommandArgument().Split(",")
            BLL.Pru_Entrega_BLL.guarda_realiza_entrega_solicitud(v(1), v(2), Session("Usuario"))
            msjNot()
            '   EnviaNotifEntregaRealizada(v(1), v(3))
            repeaterReporte.DataBind()



        ElseIf (e.CommandName = "editar") Then
            Dim dtOrigin As DataRow = BLL.Pru_Entrega_BLL.consultar_llave_entregas_solicitud(e.CommandArgument)


            Dim key As String = Guid.NewGuid.ToString
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), key, "abrirModalReporte('div1$%$%#" + dtOrigin.Item(0) + "$%$%#" + dtOrigin.Item(1) + "$%$%#" + dtOrigin.Item(2) + "$%$%#" + dtOrigin.Item(3) + "$%$%#" + dtOrigin.Item(4) + "$%$%#" + dtOrigin.Item(5) + "$%$%#" + dtOrigin.Item(6) + "');", True)

            MuestraErrorToast("Inicie la edición", 2, True)
        ElseIf (e.CommandName = "editarReporte") Then
            Dim key As String = Guid.NewGuid.ToString
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), key, "abrirModalReporte('div2');", True)
            Dim dtOrigin As DataRow = BLL.Pru_Entrega_BLL.consultar_llave_entregas_solicitud(e.CommandArgument)


            MuestraErrorToast("Listo", 0, True)
        End If
    End Sub

    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        BLL.Pru_Entrega_BLL.guarda_entrega_solicitud_link_reporte(tbID.Text, tbLink.Text, tbFecha.Text.Replace("T", " "), Session("Usuario"))
        msjNot()
        repeaterReporte.DataBind()
    End Sub

    Protected Sub btnRefrescar_Click(sender As Object, e As EventArgs)
        repeaterReporte.DataBind()
        MuestraErrorToast("Refrescando...", 2, True)
        ' Response.Redirect("~/Pages/Solicitud/Entregas/FrmSolicitudEntregas.aspx?cod_solicitud=" + tbBuscar.Text + "")

    End Sub
End Class