Public Class Login
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)


        Dim DTOrig As DataTable = Login_BLL.consulta("login", tbUsuario.Text, AES_Encriptacion.AES_Encrypt("TranscoldPruebasWeb", tbPassword.Text), "", False)


        Try
            Dim retorno As String = ""
            If Not Request.QueryString("responder") Is Nothing Then
                retorno = Request.QueryString("responder")
            End If


            If (DTOrig.Rows(0).Item(0).ToString.Length > 0) Then
                Session("ID") = DTOrig.Rows(0).Item(0)
                Session("Usuario") = DTOrig.Rows(0).Item(1)
                Dim roles As String = ""
                For index As Int32 = 0 To DTOrig.Rows.Count - 1 Step 1
                    roles = roles + DTOrig.Rows(index).Item(2) + "!" + DTOrig.Rows(index).Item(3).ToString + "!" + DTOrig.Rows(index).Item(4).ToString + "!" + DTOrig.Rows(index).Item(5).ToString + "$"
                Next
                Session("Roles") = roles
                If (retorno.Length > 0) Then
                    Response.Redirect(retorno)
                Else
                    Response.Redirect("~/Pages/Dashboard.aspx")
                End If


            Else
                MuestraErrorToast("No existen las credenciales de inicio de sesion", 3, True)
            End If
        Catch ex As Exception
            MuestraErrorToast("No existen las credenciales de inicio de sesion", 3, True)
        End Try



    End Sub









End Class