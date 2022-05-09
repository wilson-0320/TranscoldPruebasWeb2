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
                    '   Session.Abandon()
                    '  Dim v1 As String = Request.Url.AbsoluteUri
                    '    Response.Redirect("~/ComunesWeb/Login.aspx?responder=" + v1)

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

        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Paginas_ABCD", New Object() {
                                                                    New Object() {"@query", "consultar"},
                                                                    New Object() {"@op1", PermisosDetalle(0)},
                                                                     New Object() {"@op2", PermisosDetalle(1)},
                                                                      New Object() {"@op3", PermisosDetalle(2)},
                                                                       New Object() {"@op4", PermisosDetalle(3)},
                                                                        New Object() {"@op5", PermisosDetalle(4)},
                                                                        New Object() {"@op6", PermisosDetalle(5)}
                                                                    }, CommandType.StoredProcedure).Tables(0)

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
        ' Session.Abandon()

        ' Response.Redirect("~/ComunesWeb/Login.aspx")
    End Sub
End Class