Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Pru_Eventos_BLL
        Inherits Base_BLL

        Public Shared Sub evento_inicio_fin(CodSolicitud As String, Descriptor As String, Tipo As String, Path As String, Fecha As Nullable(Of DateTime), Ensayo_ID As Object, Usuario As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Eventos_sp", New Object() { _
                                            New Object() {"@query", "evento_inicio_fin"}, _
                                            New Object() {"@CodSolicitud", CodSolicitud}, _
                                            New Object() {"@Descriptor", Descriptor}, _
                                            New Object() {"@Tipo", Tipo}, _
                                            New Object() {"@Path", Path}, _
                                            New Object() {"@Fecha", Fecha}, _
                                            New Object() {"@Ensayo_ID", Ensayo_ID}, _
                                            New Object() {"@Usuario", Usuario} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub eliminar_evento_inicio_fin(id As Integer, Usuario As String)
            Dim trsql As New TransacSQL
            trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Eventos_sp", New Object() { _
                                        New Object() {"@query", "eliminar_evento_inicio_fin"}, _
                                        New Object() {"@id", id}, _
                                        New Object() {"@Usuario", Usuario} _
                                        }, Data.CommandType.StoredProcedure)
        End Sub

        Public Shared Function consultar_pruebas_y_eventos(CodSolicitud As String) As DataTable
            Dim trsql As New TransacSQL
            Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Eventos_sp", New Object() { _
                                          New Object() {"@query", "consultar_pruebas_y_eventos"}, _
                                          New Object() {"@CodSolicitud", CodSolicitud} _
                                      }, CommandType.StoredProcedure).Tables(0)
        End Function

    End Class

End Namespace
