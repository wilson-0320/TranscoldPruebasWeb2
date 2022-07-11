Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Pru_Termopar_BLL
        Inherits Base_BLL

        Public Shared Function guarda(cod_solicitud As String, dt As DataTable, stFecha As String, usuario As String) As String
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Termopar_sp", New Object() { _
                                                New Object() {"@query", "guarda"}, _
                                                New Object() {"@cod_solicitud", cod_solicitud}, _
                                                trsql.ObtParamLista("@tbl", "dbo.Pru_Termopar_tbl", dt), _
                                                New Object() {"@stFecha", stFecha}, _
                                                New Object() {"@usuario", usuario} _
                                            }, CommandType.StoredProcedure).Tables(0).Rows(0)(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Sub eliminar(cod_solicitud As String, stFecha As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Termopar_sp", New Object() {
                                                New Object() {"@query", "eliminar"},
                                                New Object() {"@cod_solicitud", cod_solicitud},
                                                New Object() {"@stFecha", stFecha}
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub


        Public Shared Sub validar(cod_solicitud As String, stFecha As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Termopar_sp", New Object() {
                                                New Object() {"@query", "validar"},
                                                New Object() {"@cod_solicitud", cod_solicitud},
                                                New Object() {"@stFecha", stFecha}
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub guardar_fecha(cod_solicitud As String, stFecha As String, fecha As DateTime, usuario As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Termopar_sp", New Object() { _
                                                New Object() {"@query", "guardar_fecha"}, _
                                                New Object() {"@cod_solicitud", cod_solicitud}, _
                                                New Object() {"@stFecha", stFecha}, _
                                                New Object() {"@fecha", fecha}, _
                                                New Object() {"@usuario", usuario} _
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consulta_fechas(cod_solicitud As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Termopar_sp", New Object() { _
                                            New Object() {"@query", "consulta_fechas"}, _
                                            New Object() {"@cod_solicitud", cod_solicitud} _
                                        }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consulta(cod_solicitud As String, stFecha As String, fila As Nullable(Of Integer), posicion_ini As Nullable(Of Integer), posicion_fin As Nullable(Of Integer)) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Termopar_sp", New Object() { _
                                            New Object() {"@query", "consulta"}, _
                                            New Object() {"@cod_solicitud", cod_solicitud}, _
                                            New Object() {"@stFecha", stFecha}, _
                                            New Object() {"@fila", fila}, _
                                            New Object() {"@posicion_ini", posicion_ini}, _
                                            New Object() {"@posicion_fin", posicion_fin} _
                                        }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

    End Class

End Namespace
