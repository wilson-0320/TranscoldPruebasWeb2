Public Class MetCatalogo
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            iniciarlizar()
            repeaterMetCatalogo.DataBind()
            controlesRepeater()
        End If

    End Sub

    Private Sub iniciarlizar()
        tbTipo.Text = ""
        tbValor.Text = ""
        hfID.Value = "-1"
        hfQuery.Value = "INSERTAR"
        lbtnCancelar.Visible = False
        lbtnGuardar.Visible = Roles("SupMet,JefeLab", 1)

    End Sub
    Private Sub msjNot()
        If Not BLL.Met_Catalogo_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Met_Catalogo_BLL.MsjError, 4, True)
        Else
            MuestraErrorToast("Listo", 1, True)
        End If
    End Sub
    Private Sub controlesRepeater()
        Dim mod1 As Boolean = Roles("SupMet,JefeLab", 2)
        Dim eli1 As Boolean = Roles("SupMet,JefeLab", 3)

        For index As Integer = 0 To repeaterMetCatalogo.Items.Count - 1 Step 1
            'Modificar
            CType(repeaterMetCatalogo.Items(index).FindControl("LinkButton1"), LinkButton).Visible = mod1

            'Eliminar
            CType(repeaterMetCatalogo.Items(index).FindControl("LinkButton2"), LinkButton).Visible = eli1
        Next


    End Sub

    Private Function validarCampos()

        For Each CampoTexto As TextBox In New TextBox() {
            tbTipo, tbValor
            }

            If CampoTexto.Text = "" Then
                MuestraErrorToast("Debe especificar el valor del campo enfocado " + CampoTexto.ToolTip, 3, True)
                CampoTexto.Focus()

                Return False
            End If

        Next
        Return True
    End Function

    Private Sub llenarCampos()
        Dim DTOrigin As DataRow = BLL.Met_Catalogo_BLL.consultar_por_id(hfID.Value)
        tbTipo.Text = DTOrigin.Item(1)
        tbValor.Text = DTOrigin.Item(2)
    End Sub

    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        If (validarCampos()) Then
            BLL.Met_Catalogo_BLL.crud(hfQuery.Value, hfID.Value, tbValor.Text, tbTipo.Text)

            repeaterMetCatalogo.DataBind()
            controlesRepeater()
            msjNot()
        End If
    End Sub

    Protected Sub lbtnCancelar_Click(sender As Object, e As EventArgs)
        iniciarlizar()
        MuestraErrorToast("", 0, True)
    End Sub
    Protected Sub repeaterMetCatalogo_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") Then
            BLL.Met_Catalogo_BLL.eliminar(Integer.Parse(e.CommandArgument))
            msjNot()
            repeaterMetCatalogo.DataBind()
            controlesRepeater()

        ElseIf (e.CommandName = "Edit") Then
            hfID.Value = e.CommandArgument
            hfQuery.Value = "MODIFICAR"
            lbtnCancelar.Visible = True
            llenarCampos()
            funcionJavascript("abrirModal('modal')")

            MuestraErrorToast("", 0, True)
        End If
    End Sub


End Class