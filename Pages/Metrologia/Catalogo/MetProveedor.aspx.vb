Public Class MetProveedor
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub inicializar()
        tbContacto.Text = ""
        tbCorrreo.Text = ""
        tbNombre.Text = ""
        tbDireccion.Text = ""
        tbPais.Text = ""
        tbTelefono.Text = ""
        cbCalibracion.Checked = False
        cbSuministros.Checked = False
        hfID.Value = "-1"
        hfQuery.Value = "INSERTAR"

    End Sub

    Private Function validarCampos()

        For Each CampoTexto As TextBox In New TextBox() {
            tbTelefono, tbPais, tbNombre, tbDireccion, tbCorrreo, tbContacto
            }

            If CampoTexto.Text = "" Then
                MuestraErrorToast("Debe especificar el valor del campo enfocado " + CampoTexto.ToolTip, 3, True)
                CampoTexto.Focus()

                Return False
            End If

        Next
        Return True
    End Function

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        If (validarCampos()) Then
            BLL.Met_Proveedores_BLL.crud("", 0, cbCalibracion.Checked, cbSuministros.Checked, tbNombre.Text, tbDireccion.Text, tbPais.Text,
tbContacto.Text, tbCorrreo.Text, tbTelefono.Text, "")
        End If
    End Sub
End Class