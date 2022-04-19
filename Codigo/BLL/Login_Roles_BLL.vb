Imports Microsoft.VisualBasic
Imports System.Data


Public Class Login_Roles_BLL

    Inherits Base_BLL
    Public Shared Function CrudRoles(ByVal query As String, ByVal ID As Integer, ByVal ID_Usuario As Integer, ByVal ID_Catalogos As Integer,
                                      ByVal Agregar As Boolean, ByVal Modificar As Boolean, ByVal Eliminar As Boolean, ByVal Ver As Boolean
                                     ) As String

        Try
            Dim trsql As New TransacSQL
            Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Usuarios_Roles_ABCD", New Object() {
                                           New Object() {"@query", query},
                                            New Object() {"@ID", ID},
                                            New Object() {"@ID_Usuario", ID_Usuario},
                                            New Object() {"@ID_Catalogo", ID_Catalogos},
                                            New Object() {"@Agregar", Agregar},
                                            New Object() {"@Modificar", Modificar},
                                            New Object() {"@Eliminar", Eliminar},
                                            New Object() {"@Ver", Ver}
                                            }, Data.CommandType.StoredProcedure).Tables(0).Rows(0).Item(0)

        Catch ex As Exception

            Return ex.ToString
        End Try

    End Function


    Public Shared Function Eliminar(ByVal ID As Integer) As String

        Try
            Dim trsql As New TransacSQL
            Dim msj As String = trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Usuarios_Roles_ABCD", New Object() {
                                           New Object() {"@query", "Eliminar"},
                                            New Object() {"@ID", ID}
                                            }, Data.CommandType.StoredProcedure).Tables(0).Rows(0).Item(0)
            Return msj
        Catch ex As Exception
            colocaError(ex)
        End Try

    End Function
End Class
