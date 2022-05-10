Imports System.Security.Cryptography

Public Class Registrar
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub

    Protected Sub lbtnRegistrar_Click(sender As Object, e As EventArgs)

        If (tbPassword.Text.Equals(tbPassVerificar.Text) And tbPassword.Text.Length > 0) Then
            Dim pass As String = AES_Encriptacion.AES_Encrypt("TranscoldPruebasWeb", tbPassword.Text)
            ' Dim errdr As Int16 = Int16.Parse(pass)
            Login_BLL.crud("insertar", tbUsuario.Text, pass, "", True)

            If Not Login_BLL.MsjError Is Nothing Then
                MuestraErrorToast(Login_BLL.MsjError, 4, True)
            Else
                MuestraErrorToast("Usuario creado", 1, True)
            End If


        End If

    End Sub


End Class