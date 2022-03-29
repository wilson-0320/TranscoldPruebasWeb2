Imports Microsoft.VisualBasic
Imports System.Data


Public Class Login_BLL


    Public Shared Function login(ByVal query As String, ByVal usuario As String, ByVal Pass As String, ByVal Estado As Boolean) As String

        Try
            Dim trsql As New TransacSQL
            Dim msj As String = trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Usuario_ABCD", New Object() {
                                           New Object() {"@query", query},
                                            New Object() {"@Usuario", usuario},
                                            New Object() {"@Pass", Pass},
                                            New Object() {"@Estado", Estado}
                                            }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)
            Return msj
        Catch ex As Exception

            Return ex.Message
        End Try

    End Function
End Class
