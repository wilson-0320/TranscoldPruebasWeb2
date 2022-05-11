Imports Microsoft.VisualBasic
Imports System.Data


Public Class Pag_Paginas_BLL

    Inherits Base_BLL
    Public Shared Function consulta(ByVal query As String, ByVal ID As Integer, ByVal ID_Usuario As Integer, ByVal urls As String,
                                      ByVal nombre As String, ByVal menus As Integer) As DataTable
        MsjError = Nothing
        Try
            Dim trsql As New TransacSQL
            Return trsql.EjecutarConsulta("TranscoldPruebas", "Pag_Paginas_sp", New Object() {
                                           New Object() {"@query", query},
                                            New Object() {"@ID", ID},
                                            New Object() {"@ID_Usuario", ID_Usuario},
                                            New Object() {"@Urls", urls},
                                            New Object() {"@Nombre", nombre},
                                            New Object() {"@Menu", menus}
                                            }, Data.CommandType.StoredProcedure).Tables(0)

        Catch ex As Exception

            colocaError(ex)
        End Try

    End Function


End Class
