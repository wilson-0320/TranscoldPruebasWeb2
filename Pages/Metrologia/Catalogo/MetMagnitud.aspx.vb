Public Class MetMagnitud
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                inicializar()
                repeaterMetMagnitud.DataBind()
                controlesRepeater()
            Catch ex As Exception

            End Try
        End If

    End Sub
    Private Sub inicializar()
        tbMagnitud.Text = ""
        hfID.Value = "-1"
        hfQuery.Value = "INSERTAR"
        lbtnCancelar.Visible = False
        lbtnGuardar.Enabled = Roles("Administrador", 1)

    End Sub
    Private Sub msjNot()
        If Not BLL.Met_Magnitud_BLL.MsjError Is Nothing Then
            MuestraErrorToast(BLL.Met_Magnitud_BLL.MsjError, 4, True)
        Else
            MuestraErrorToast("Listo", 1, True)
        End If
    End Sub
    Private Sub controlesRepeater()
        Dim mod1 As Boolean = Roles("SupMet,JefeLab", 2)
        Dim eli1 As Boolean = Roles("SupMet,JefeLab", 3)

        For index As Integer = 0 To repeaterMetMagnitud.Items.Count - 1 Step 1
            'Modificar
            CType(repeaterMetMagnitud.Items(index).FindControl("LinkButton1"), LinkButton).Visible = mod1

            'Eliminar
            CType(repeaterMetMagnitud.Items(index).FindControl("LinkButton2"), LinkButton).Visible = eli1
        Next


    End Sub

    Private Function validarCampos()

        For Each CampoTexto As TextBox In New TextBox() {
            tbMagnitud
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
        Dim DTOrigin As DataRow = BLL.Met_Magnitud_BLL.consultar_por_id(hfID.Value)
        tbMagnitud.Text = DTOrigin.Item(1)
    End Sub
    Protected Sub repeaterMetMagnitud_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli") Then
            BLL.Met_Magnitud_BLL.eliminar(Integer.Parse(e.CommandArgument))
            msjNot()
            repeaterMetMagnitud.DataBind()
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

    Protected Sub lbtnCancelar_Click(sender As Object, e As EventArgs)
        inicializar()
        MuestraErrorToast("", 0, True)
    End Sub

    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        If (validarCampos()) Then
            BLL.Met_Magnitud_BLL.crud(hfQuery.Value, hfID.Value, tbMagnitud.Text)

            repeaterMetMagnitud.DataBind()
            controlesRepeater()
            msjNot()
        End If
    End Sub
End Class