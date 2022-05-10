Imports Microsoft.VisualBasic
Imports System.Data


Public Class Login_BLL
    Inherits Base_BLL


    Public Shared Function consulta(ByVal query As String, ByVal usuario As String, ByVal Pass As String, ByVal Color As String, ByVal Estado As Boolean) As DataTable

        Try
            Dim trsql As New TransacSQL
            Return trsql.EjecutarConsulta("TranscoldPruebas", "Pag_Usuario_ABCD", New Object() {
                                           New Object() {"@query", query},
                                            New Object() {"@Usuario", usuario},
                                            New Object() {"@Pass", Pass},
                                            New Object() {"@Color", Color},
                                            New Object() {"@Estado", Estado}
                                            }, Data.CommandType.StoredProcedure).Tables(0)
        Catch ex As Exception

            colocaError(ex)
        End Try
    End Function


    Public Shared Sub crud(ByVal query As String, ByVal usuario As String, ByVal Pass As String, ByVal Color As String, ByVal Estado As Boolean)
        MsjError = Nothing
        Try
            Dim trsql As New TransacSQL
            trsql.EjecutarActualizacion("TranscoldPruebas", "Pag_Usuario_ABCD", New Object() {
                                           New Object() {"@query", query},
                                            New Object() {"@Usuario", usuario},
                                            New Object() {"@Pass", Pass},
                                            New Object() {"@Color", Color},
                                            New Object() {"@Estado", Estado}
                                            }, Data.CommandType.StoredProcedure)
        Catch ex As Exception

            colocaError(ex)
        End Try
    End Sub
End Class
