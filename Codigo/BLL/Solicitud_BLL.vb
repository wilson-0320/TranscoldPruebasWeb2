Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Solicitud_BLL
        Inherits Base_BLL

        Public Shared Function Busqueda(ByVal Codigo As String, ByVal Posterior_a As String, ByVal Anterior_a As String, ByVal Modelo As String, _
                                        ByVal Consecutivo As String, ByVal WO As String, ByVal Serie As String, ByVal LiderProyID As Integer, _
                                        ByVal Objetivos As String, ByVal Estado As String) As DataTable
            MsjError = Nothing
            Dim TrSql As New TransacSQL
            Try
                Return TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_ABCD", New Object() { _
                                       New Object() {"@query", "Busqueda"}, _
                                       New Object() {"@Codigo", Codigo}, _
                                       New Object() {"@Posterior_a", Posterior_a}, _
                                       New Object() {"@Anterior_a", Anterior_a}, _
                                       New Object() {"@Modelo", Modelo}, _
                                       New Object() {"@Consecutivo", Consecutivo}, _
                                       New Object() {"@WO", WO}, _
                                       New Object() {"@Serie", Serie}, _
                                       New Object() {"@LiderProyID", LiderProyID}, _
                                       New Object() {"@Objetivos", Objetivos}, _
                                       New Object() {"@Estado", Estado} _
                                       }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Sub actu_estado(ByVal Codigo As String, ByVal Estado As String, ByVal Usuario As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_ABCD", New Object() { _
                                            New Object() {"@query", "actu_estado"}, _
                                            New Object() {"@Codigo", Codigo}, _
                                            New Object() {"@Estado", Estado}, _
                                            New Object() {"@Usuario", Usuario} _
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub guarda_fecha_finaliz(ByVal Codigo As String, ByVal Fecha As Object, ByVal Usuario As String)
            MsjError = Nothing
            Try
                Try
                    Fecha = DateTime.ParseExact(Fecha, "dd/MM/yyyy", Nothing)
                Catch ex As Exception
                    Throw New Exception("Formato de fecha incorrecto")
                End Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_ABCD", New Object() {
                                            New Object() {"@query", "guarda_fecha_finaliz"},
                                            New Object() {"@Codigo", Codigo},
                                            New Object() {"@Fecha", Fecha},
                                            New Object() {"@Usuario", Usuario}
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub


        Public Shared Function crudSolicitud(ByVal Estado As String, ByVal Codigo As String, ByVal Usuario As String,
                                        ByVal LiderProyID As Integer, ByVal Modelo As String, ByVal EncargadoEquipo As String,
                                             ByVal Objetivos As String, ByVal Cantidad As String, ByVal refProv As String,
                                             ByVal refFogel As String, ByVal NomTecnico As String, ByVal Serie As String,
                                             ByVal WO As String, ByVal FechaEntrega As String, ByVal TipoCargaID As String,
                                             ByVal DatosTermostato As String, ByVal DisposionFinal As String,
                                             ByVal ObservacionesPrueba As String, ByVal ObservacionesPruebas As String,
                                             ByVal ObservacionesRevision As String, ByVal Locaciones As String)
            MsjError = Nothing
            Dim TrSql As New TransacSQL
            Try



                TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Actualiza2", New Object() {
                                                       New Object() {"@Estado", Estado.TrimEnd},
                                                       New Object() {"@Codigo", Codigo.TrimEnd},
                                                       New Object() {"@Usuario", Usuario},
                                                       New Object() {"@Lider_Proyecto_ID", LiderProyID},
                                                       New Object() {"@Modelo", Modelo.TrimEnd},
                                                       New Object() {"@Encargado_Equipo_ID", EncargadoEquipo},
                                                       New Object() {"@Objetivos", Objetivos.TrimEnd},
                                                       New Object() {"@Cantidad", Cantidad},
                                                       New Object() {"@Referencia_Proveedor", refProv},
                                                       New Object() {"@Referencia_Fogel", refFogel},
                                                       New Object() {"@NomTecnico", NomTecnico.TrimEnd},
                                                       New Object() {"@Serie", Serie.TrimEnd},
                                                       New Object() {"@WO", WO.TrimEnd},
                                                       New Object() {"@Fecha_Entrega", FechaEntrega},
                                                       New Object() {"@Tipo_Carga_Ref_ID", TipoCargaID},
                                                       New Object() {"@Datos_Termostato", DatosTermostato},
                                                       New Object() {"@Disposicion_Final", DisposionFinal},
                                                       New Object() {"@Observaciones_Pruebas", ObservacionesPrueba},
                                                       New Object() {"@Observaciones_Prueba", ObservacionesPruebas},
                                                       New Object() {"@Observaciones_Revision", ObservacionesRevision},
                                                       New Object() {"@Locacion", Locaciones}
                                                       }, CommandType.StoredProcedure)


            Catch ex As Exception
                Dim B = ex.Message
            End Try

        End Function


        Public Shared Function Eliminar(ByVal Codigo As String, ByVal Estado As String) As String
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL

                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_ABCD", New Object() {
                                            New Object() {"@query", Estado},
                                            New Object() {"@Codigo", Codigo.TrimEnd}
                                            }, CommandType.StoredProcedure)
                Return "Listo"
            Catch ex As Exception
                colocaError(ex)
                Return ex.Message
            End Try
        End Function


    End Class

End Namespace
