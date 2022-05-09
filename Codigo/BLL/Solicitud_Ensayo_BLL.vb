Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Solicitud_Ensayo_BLL
        Inherits Base_BLL

        Public Shared Function consultar(ByVal Solicitud_Cod As String, ByVal Tipo As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Ensayo_ABCD", New Object() { _
                                              New Object() {"@query", "consultar"}, _
                                              New Object() {"@Solicitud_Cod", Solicitud_Cod}, _
                                              New Object() {"@Tipo", Tipo} _
                                              }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function eliminar(ByVal id As Integer) As String
            MsjError = "Realizado"
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Ensayo_ABCD", New Object() {
                                            New Object() {"@query", "eliminar"},
                                            New Object() {"@id", id}
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
            Return MsjError
        End Function

        Public Shared Function insertar(ByVal Solicitud_Cod As String, ByVal Tipo As String, ByVal Ensayo_ID As Integer) As String
            MsjError = "Realizado"
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Ensayo_ABCD", New Object() {
                                            New Object() {"@query", "insertar"},
                                            New Object() {"@Solicitud_Cod", Solicitud_Cod},
                                            New Object() {"@Tipo", Tipo},
                                            New Object() {"@Ensayo_ID", Ensayo_ID}
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
            Return MsjError
        End Function

        Public Shared Function cmodificar(ByVal ID As Integer, ByVal Prueba As String) As String
            MsjError = "Realizado"
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Ensayo_ABCD", New Object() {
                                            New Object() {"@query", "modificar"},
                                            New Object() {"@ID", ID},
                                            New Object() {"@Prueba", Prueba}
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
            Return MsjError
        End Function

    End Class

End Namespace

