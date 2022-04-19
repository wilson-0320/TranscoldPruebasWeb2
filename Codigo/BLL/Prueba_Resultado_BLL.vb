Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Prueba_Resultado_BLL
        Inherits Base_BLL

        Public Shared Sub insertar(ByVal prueba_id, ByVal tipo_ensayo, ByVal TR1, ByVal TR2, ByVal TR3, ByVal TR4, ByVal TR5, ByVal TR6, ByVal TR7, ByVal usuario)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Prueba_Resultado_ABCD", New Object() { _
                                            New Object() {"@query", "insertar"}, _
                                            New Object() {"@prueba_id", prueba_id}, _
                                            New Object() {"@tipo_ensayo", tipo_ensayo}, _
                                            New Object() {"@tr1", TR1}, _
                                            New Object() {"@tr2", TR2}, _
                                            New Object() {"@tr3", TR3}, _
                                            New Object() {"@tr4", TR4}, _
                                            New Object() {"@tr5", TR5}, _
                                            New Object() {"@tr6", TR6}, _
                                            New Object() {"@tr7", TR7}, _
                                            New Object() {"@usuario", usuario} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub modificar(ByVal id, ByVal TR1, ByVal TR2, ByVal TR3, ByVal TR4, ByVal TR5, ByVal TR6, ByVal TR7, ByVal usuario)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Prueba_Resultado_ABCD", New Object() { _
                                            New Object() {"@query", "modificar"}, _
                                            New Object() {"@id", id}, _
                                            New Object() {"@tr1", TR1}, _
                                            New Object() {"@tr2", TR2}, _
                                            New Object() {"@tr3", TR3}, _
                                            New Object() {"@tr4", TR4}, _
                                            New Object() {"@tr5", TR5}, _
                                            New Object() {"@tr6", TR6}, _
                                            New Object() {"@tr7", TR7}, _
                                            New Object() {"@usuario", usuario} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub eliminar(ByVal id, ByVal usuario)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Prueba_Resultado_ABCD", New Object() { _
                                            New Object() {"@query", "eliminar"}, _
                                            New Object() {"@id", id}, _
                                            New Object() {"@usuario", usuario} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar(ByVal prueba_id As Integer) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Prueba_Resultado_ABCD", New Object() { _
                                              New Object() {"@query", "consultar"}, _
                                              New Object() {"@prueba_id", prueba_id} _
                                              }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function ConsultaEncTr(ByVal tipo_ensayo As String) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Prueba_Resultado_ABCD", New Object() { _
                                              New Object() {"@query", "ConsultaEncTr"}, _
                                              New Object() {"@tipo_ensayo", tipo_ensayo} _
                                              }, CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function TitulosPorColumnaPruebaRes(col As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Prueba_Resultado_ABCD", New Object() { _
                                              New Object() {"@query", "TitulosPorColumnaPruebaRes"}, _
                                              New Object() {"@col", col} _
                                              }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

    End Class

End Namespace
