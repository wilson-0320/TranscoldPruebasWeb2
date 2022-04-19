Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Equipos_BLL
        Inherits Base_BLL

        Public Shared Function insertar(ByVal query As String,
                                       ByVal estadoEquipo As String,
                                        ByVal ID As Int32,
                                        ByVal nombre As String,
                                        ByVal fabricante As String,
                                        ByVal serie As String,
                                        ByVal modelo As String,
                                        ByVal codigo As String,
                                        ByVal idMarca As Int32,
                                         ByVal firmware As String,
                                         ByVal intervalo As String,
                                         ByVal resolucion As String,
                                         ByVal rango As String,
                                         ByVal puntosCalibraicon As String,
                                         ByVal ubicacion As String
                                          ) As String
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Dim msj As String = trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Instrumentos_ABCD", New Object() {
                                                New Object() {"@query", query},
                                                New Object() {"@Tipo", estadoEquipo.TrimEnd},
                                                New Object() {"@ID", ID},
                                                New Object() {"@Serie", serie.TrimEnd},
                                                New Object() {"@Modelo", modelo.TrimEnd},
                                                New Object() {"@Codigo", codigo},
                                                New Object() {"@Nombre", nombre.TrimEnd},
                                                New Object() {"@Fabricante", fabricante.TrimEnd},
                                                New Object() {"@Fir_Sof", firmware.TrimEnd},
                                                New Object() {"@Intervalo", intervalo.TrimEnd},
                                                New Object() {"@Resolucion", resolucion.TrimEnd},
                                                New Object() {"@Rango_Calibracion", rango.TrimEnd},
                                                New Object() {"@No_Puntos", puntosCalibraicon.TrimEnd},
                                                New Object() {"@Ubicacion", ubicacion.TrimEnd},
                                                New Object() {"@Estado_Equipo", ""},
                                                New Object() {"@ID_Marca", idMarca}
                                                  }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)
                Return msj '    Dim a As Int16 = ex + codigo
            Catch ex As Exception
                Return ex.ToString '
                ' colocaError(ex)
            End Try
        End Function

        Public Shared Function eliminar(ByVal ID As Int32) As String
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Dim msj As String = trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Instrumentos_ABCD", New Object() {
                                                New Object() {"@query", "eliminar"},
                                                New Object() {"@ID", ID}
                                                  }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)
                Return msj '    Dim a As Int16 = ex + codigo
            Catch ex As Exception
                Return ex.ToString '
                ' colocaError(ex)
            End Try
        End Function

        Public Shared Function aprobar(ByVal ID As Int32) As String
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Dim msj As String = trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Instrumentos_ABCD", New Object() {
                                                New Object() {"@query", "aprobar"},
                                                New Object() {"@ID", ID}
                                                  }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)
                Return msj '    Dim a As Int16 = ex + codigo
            Catch ex As Exception
                Return ex.ToString '
                ' colocaError(ex)
            End Try
        End Function



    End Class

End Namespace

