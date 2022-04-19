Public Class Login
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)


        Dim msj As String = Login_BLL.login("login", tbUsuario.Text, AES_Encriptacion.AES_Encrypt("TranscoldPruebasWeb", tbPassword.Text), False)

        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Usuario_ABCD", New Object() {
                                                                  New Object() {"@query", "login"},
                                                                  New Object() {"@Usuario", tbUsuario.Text},
                                                                  New Object() {"@Pass", AES_Encriptacion.AES_Encrypt("TranscoldPruebasWeb", tbPassword.Text)}
                                                                  }, CommandType.StoredProcedure).Tables(0)

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
            MuestraErrorToast("Error", 3, True)
        End Try



    End Sub









End Class