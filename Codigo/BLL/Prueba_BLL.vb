Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Prueba_BLL
        Inherits Base_BLL

        Public Shared Sub Guardar(ByVal Prueba_id, ByVal Prueba, ByVal WO, ByVal Serie, ByVal Modelo, ByVal Compresor, ByVal Folder, ByVal TipoPrueba, ByVal Evaporador,
                                    ByVal Condensador, ByVal Termostato, ByVal Voltaje, ByVal Relay, ByVal TipoEvaporador, ByVal TipoCondensador, ByVal Capilar, ByVal PruebaNo,
                                    ByVal CamaraAmbiental, ByVal Capacitor, ByVal ProtectorTermico, ByVal MAE, ByVal MAC, ByVal Refrigerante, ByVal Aprobada, ByVal Notas, ByVal CodSolicitud,
                                    ByVal Fecha, ByVal Usuario)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Prueba_ABCD", New Object() {
                                            New Object() {"@Tipo", "Guardar"},
                                            New Object() {"@ID", Prueba_id},
                                            New Object() {"@Prueba", Prueba},
                                            New Object() {"@WO", WO},
                                            New Object() {"@Serie", Serie},
                                            New Object() {"@Modelo", Modelo},
                                            New Object() {"@Compresor", Compresor},
                                            New Object() {"@Folder", Folder},
                                            New Object() {"@TipoPrueba", TipoPrueba},
                                            New Object() {"@Evaporador", Evaporador},
                                            New Object() {"@Condensador", Condensador},
                                            New Object() {"@Termostato", Termostato},
                                            New Object() {"@Voltaje", Voltaje},
                                            New Object() {"@Relay", Relay},
                                            New Object() {"@TipoEvaporador", TipoEvaporador},
                                            New Object() {"@TipoCondensador", TipoCondensador},
                                            New Object() {"@Capilar", Capilar},
                                            New Object() {"@PruebaNo", PruebaNo},
                                            New Object() {"@CamaraAmbiental", CamaraAmbiental},
                                            New Object() {"@Capacitor", Capacitor},
                                            New Object() {"@ProtectorTermico", ProtectorTermico},
                                            New Object() {"@MAE", MAE},
                                            New Object() {"@MAC", MAC},
                                            New Object() {"@Refrigerante", Refrigerante},
                                            New Object() {"@Notas", Notas},
                                            New Object() {"@Aprobada", Aprobada},
                                            New Object() {"@CodSolicitud", CodSolicitud},
                                             New Object() {"@Usuario", Usuario},
                                            New Object() {"@Fecha", DateTime.Parse(Fecha)}
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Prueba_ABCD", New Object() {
                                            New Object() {"@Tipo", "Eliminar"},
                                            New Object() {"@ID", id}
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try

        End Sub

        Public Shared Function PorPruebaId(ByVal prueba_id As Integer) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Prueba_ABCD", New Object() {
                                              New Object() {"@Tipo", "PorPruebaId"},
                                              New Object() {"@id", prueba_id}
                                              }, CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function PorPruebaDetalle(ByVal prueba_id As Integer) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Prueba_ABCD", New Object() {
                                              New Object() {"@Tipo", "ConsultarDetalle"},
                                              New Object() {"@ID", prueba_id}
                                              }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function



        Public Shared Function consultar(ByVal Prueba, ByVal WO, ByVal Serie, ByVal Modelo, ByVal Compresor, ByVal TipoPrueba, ByVal Evaporador,
                                   ByVal Condensador, ByVal Termostato, ByVal Voltaje, ByVal Relay, ByVal TipoEvaporador, ByVal TipoCondensador, ByVal Capilar,
                                   ByVal Antiguo, ByVal MAE, ByVal MAC, ByVal Refrigerante, ByVal Aprobada, ByVal CodSolicitud) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Prueba_Consulta", New Object() {
                                            New Object() {"@Prueba", Prueba},
                                            New Object() {"@Modelo", Modelo},
                                            New Object() {"@Serie", Serie},
                                            New Object() {"@WO", WO},
                                            New Object() {"@Compresor", Compresor},
                                            New Object() {"@TipoPrueba", TipoPrueba},
                                            New Object() {"@Evaporador", Evaporador},
                                            New Object() {"@Condensador", Condensador},
                                            New Object() {"@Termostato", Termostato},
                                            New Object() {"@MAE", MAE},
                                            New Object() {"@MAC", MAC},
                                            New Object() {"@Refrigerante", Refrigerante},
                                            New Object() {"@TipoEv", TipoEvaporador},
                                            New Object() {"@TipoCond", TipoCondensador},
                                            New Object() {"@Relay", Relay},
                                            New Object() {"@Voltaje", Voltaje},
                                            New Object() {"@Capilar", Capilar},
                                            New Object() {"@Antiguo", Antiguo},
                                            New Object() {"@Aprobada", Aprobada},
                                            New Object() {"@Solicitud", CodSolicitud}
                                            }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function
    End Class
End Namespace