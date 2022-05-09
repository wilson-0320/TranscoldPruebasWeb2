Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Pru_Eventos_BLL
        Inherits Base_BLL

        Public Shared Function evento_inicio_fin(CodSolicitud As String, Descriptor As String, Tipo As String, Path As String, Fecha As Nullable(Of DateTime), Ensayo_ID As Object, Usuario As String) As String
            MsjError = "-Realizado"
            Try
                Dim trsql As New TransacSQL
                ' Return
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Eventos_sp", New Object() {
                                            New Object() {"@query", "evento_inicio_fin"},
                                            New Object() {"@CodSolicitud", CodSolicitud},
                                            New Object() {"@Descriptor", Descriptor},
                                            New Object() {"@Tipo", Tipo},
                                            New Object() {"@Path", Path},
                                            New Object() {"@Fecha", Fecha},
                                            New Object() {"@Ensayo_ID", Ensayo_ID},
                                            New Object() {"@Usuario", Usuario}
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try

            Return MsjError
        End Function

        Public Shared Function eliminar_evento_inicio_fin(id As Integer, Usuario As String) As String
            MsjError = "-Realizado"
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Eventos_sp", New Object() {
                                            New Object() {"@query", "eliminar_evento_inicio_fin"},
                                            New Object() {"@id", id},
                                            New Object() {"@Usuario", Usuario}
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)

            End Try


            Return MsjError
        End Function

        Public Shared Function consultar_pruebas_y_eventos(CodSolicitud As String) As DataTable
            Dim trsql As New TransacSQL
            Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Eventos_sp", New Object() {
                                          New Object() {"@query", "consultar_pruebas_y_eventos"},
                                          New Object() {"@CodSolicitud", CodSolicitud}
                                      }, CommandType.StoredProcedure).Tables(0)
        End Function


        Public Shared Function consultar_pruebas_y_eventos_2(CodSolicitud As String, tipo As String) As DataTable
            Dim trsql As New TransacSQL
            Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Eventos_sp", New Object() {
                                      New Object() {"@query", "consultar_eventos_tipo"},
                                      New Object() {"@CodSolicitud", CodSolicitud},
                                       New Object() {"@Descriptor", tipo}
                                  }, CommandType.StoredProcedure).Tables(0)
        End Function

    End Class

End Namespace
