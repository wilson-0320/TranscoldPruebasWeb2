Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Solicitud_Division_BLL
        Inherits Base_BLL

        Public Shared Function insertar(ByVal Codigo As String, ByVal Descripcion As String) As String
            MsjError = "Realizado"
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Division_ABCD", New Object() {
                                            New Object() {"@query", "insertar"},
                                            New Object() {"@codigo", Codigo},
                                            New Object() {"@descripcion", Descripcion}
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
            Return MsjError
        End Function

        Public Shared Function modificar(ByVal id As Integer, ByVal Descripcion As String) As String
            MsjError = "Realizado"
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Division_ABCD", New Object() {
                                            New Object() {"@query", "modificar"},
                                            New Object() {"@id", id},
                                            New Object() {"@descripcion", Descripcion}
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
            Return MsjError
        End Function

        Public Shared Function eliminar(ByVal id As Integer) As String
            MsjError = "Realizado"
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Division_ABCD", New Object() {
                                            New Object() {"@query", "eliminar"},
                                            New Object() {"@id", id}
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
            Return MsjError
        End Function

        Public Shared Function consultar_por_id(ByVal id As Integer) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Division_ABCD", New Object() { _
                                            New Object() {"@query", "consultar_por_id"}, _
                                            New Object() {"@id", id} _
                                            }, CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_por_codigo(ByVal Codigo As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Division_ABCD", New Object() { _
                                            New Object() {"@query", "consultar_por_codigo"}, _
                                            New Object() {"@Codigo", Codigo} _
                                            }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

    End Class

End Namespace

