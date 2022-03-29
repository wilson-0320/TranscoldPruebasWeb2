Imports System.Security.Cryptography

Public Class Registrar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub

    Protected Sub lbtnRegistrar_Click(sender As Object, e As EventArgs)

        If (tbPassword.Text.Equals(tbPassVerificar.Text)) Then
            Dim pass As String = AES_Encriptacion.AES_Encrypt("TranscoldPruebasWeb", tbPassword.Text)
            ' Dim errdr As Int16 = Int16.Parse(pass)
            Dim msj As String = Login_BLL.login("insertar", tbUsuario.Text, pass, True)
            If msj.StartsWith("Error:") Then
                llamarFuncionesJavascript(msj, "4")
            Else
                llamarFuncionesJavascript(msj, "1")
            End If

        End If

    End Sub

    Private Sub llamarFuncionesJavascript(ByVal mensaje As String, ByVal titulo As String)
        Dim funcion As String = ("cargar('" + mensaje + "','" + titulo + "');")

        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "funcion", funcion, True)
    End Sub
End Class