Public Class Login
    Inherits MiPageN
    Dim TAF As New TAF

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)

        Try



            Dim DTOrig1 As DataTable = New TransacSQL().EjecutarConsulta("aspnetdb3", "select u.UserName, m.Password from aspnet_Users u, aspnet_Membership m, aspnet_Applications a " +
                                                          "where u.UserId = m.UserId And u.ApplicationId = a.ApplicationId and m.IsLockedOut = 0 " +
                                                         "and a.ApplicationName = @AppName and u.UserName = @UserName and m.Password = @Password", New Object() {
                                                                     New Object() {"@AppName", "TranscoldPruebasWeb"},
                                                                   New Object() {"@UserName", tbUsuario.Text},
                                                                  New Object() {"@Password", tbPassword.Text}
                                                                 }, CommandType.Text).Tables(0)

            ' If () Then
            If (DTOrig1.Rows(0).Item(0).ToString.Length > 0) Then
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
                            roles = roles + DTOrig.Rows(index).Item(2).ToString.TrimEnd + "!" + DTOrig.Rows(index).Item(3).ToString + "!" + DTOrig.Rows(index).Item(4).ToString + "!" + DTOrig.Rows(index).Item(5).ToString + "$"
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
            Else
                MuestraErrorToast("No existen las credenciales de inicio de sesion", 3, True)
            End If
        Catch ex As Exception
            MuestraErrorToast("No existen las credenciales de inicio de sesion", 3, True)
        End Try





    End Sub









End Class