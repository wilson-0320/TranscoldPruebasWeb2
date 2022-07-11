Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Pru_Not_Sol_BLL
        Inherits Base_BLL

        Public Shared Sub guardar(querySp As String, cod_solicitud As String, id As Integer, idCatalogo As Integer, mayorA As Decimal, menorA As Decimal, usuario As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Notificaciones_Sol", New Object() {
                                                New Object() {"@query", querySp},
                                                New Object() {"@id", id},
                                                New Object() {"@Codigo", cod_solicitud},
                                                New Object() {"@id_Catalogo", idCatalogo},
                                                New Object() {"@mayorA", mayorA},
                                                New Object() {"@menorA", menorA},
                                                New Object() {"@usuario", usuario}
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub


        Public Shared Function consultar_por_codigo(querySp As String, cod_solicitud As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Notificaciones_Sol", New Object() {
                                                New Object() {"@query", querySp},
                                                New Object() {"@Codigo", cod_solicitud}
                                            }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function
        Public Shared Function consultar_por_llave(id As Integer) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Notificaciones_Sol", New Object() {
                                                New Object() {"@query", "por_llave"},
                                                New Object() {"@id", id}
                                            }, CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function




    End Class

End Namespace
