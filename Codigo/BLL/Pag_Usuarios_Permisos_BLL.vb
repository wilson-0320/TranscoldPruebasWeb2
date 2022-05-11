Imports Microsoft.VisualBasic
Imports System.Data


Public Class Pag_Usuarios_Permisos_BLL

    Inherits Base_BLL
    Public Shared Sub crudPermisos(ByVal query As String, ByVal ID As Integer, ByVal ID_Usuario As Integer, ByVal ID_Rol As Integer,
                                      ByVal Agregar As Boolean, ByVal Modificar As Boolean, ByVal Eliminar As Boolean)
        MsjError = Nothing
        Try
            Dim trsql As New TransacSQL
            trsql.EjecutarActualizacion("TranscoldPruebas", "Pag_Usuarios_Permisos_ABCD", New Object() {
                                           New Object() {"@query", query},
                                            New Object() {"@ID", ID},
                                            New Object() {"@ID_Usuario", ID_Usuario},
                                            New Object() {"@ID_Rol", ID_Rol},
                                            New Object() {"@Agregar", Agregar},
                                            New Object() {"@Modificar", Modificar},
                                            New Object() {"@Eliminar", Eliminar}
                                            }, Data.CommandType.StoredProcedure)

        Catch ex As Exception

            colocaError(ex)
        End Try

    End Sub




    Public Shared Function consultar(ByVal query As String, ByVal ID As Integer, ByVal ID_Usuario As Integer, ByVal ID_Rol As Integer) As DataTable
        MsjError = Nothing
        Try
            Dim trsql As New TransacSQL
            Return trsql.EjecutarConsulta("TranscoldPruebas", "Pag_Usuarios_Permisos_ABCD", New Object() {
                                           New Object() {"@query", query},
                                            New Object() {"@ID", ID},
                                            New Object() {"@ID_Usuario", ID_Usuario},
                                            New Object() {"@ID_Rol", ID_Rol}
                                            }, Data.CommandType.StoredProcedure).Tables(0)

        Catch ex As Exception

            colocaError(ex)
        End Try

    End Function
End Class
