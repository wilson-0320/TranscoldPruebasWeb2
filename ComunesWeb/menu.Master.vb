Imports System.Data
Public Class menu
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then
            If (Session("Roles") Is Nothing) Then


                Session.Abandon()
                Dim v As String = Request.Url.AbsoluteUri
                Dim RetornoUrl As String = v(0) + "//" + v(1) +
                   "/" + v(2) + "/" + v(3) + "/" + v(4)
                '  Response.Redirect("~/ComunesWeb/Login.aspx?responder=" + v)
            Else
                Session("Roles") = Session("Roles").ToString

                If (repeatMenu(Session("Roles").ToString)) Then
                Else
                    Session.Abandon()
                    ' Dim v1 As String = Request.Url.AbsoluteUri
                    Response.Redirect("~/ComunesWeb/Login.aspx")

                End If

            End If
        End If




    End Sub

    Private Function repeatMenu(ByVal permisosvarios As String) As Boolean

        Dim PermisosA() As String
        Dim PermisosDetalle(150) As String
        PermisosDetalle(0) = "A"
        PermisosDetalle(1) = "false"
        PermisosDetalle(2) = "false"
        PermisosDetalle(3) = "false"
        PermisosA = Session("Roles").ToString.Split("$")
                    For index As Integer = 0 To PermisosA.Length - 2 Step 1


            PermisosDetalle(index) = PermisosA(index).Substring(0, PermisosA(index).IndexOf("!"))

        Next
        Dim v As String = Request.Url.AbsoluteUri

        Dim DTOrig As DataTable = Pag_Paginas_BLL.consulta("consultar", 0, Integer.Parse(Session("ID").ToString), "", "", 0)


        repeaterMenu.DataSource = DTOrig
        repeaterMenu.DataBind()
        For index As Integer = 0 To DTOrig.Rows().Count - 1 Step 1

            If ((v.Contains(DTOrig.Rows(index).Item(1).ToString.TrimEnd))) Then

                Return True
            End If
        Next

        Return False

    End Function

    Protected Sub lbtnSalir_Click(sender As Object, e As EventArgs)
        Session.Abandon()

        Response.Redirect("~/ComunesWeb/Login.aspx")
    End Sub
End Class