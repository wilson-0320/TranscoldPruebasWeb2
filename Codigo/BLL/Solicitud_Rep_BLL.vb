Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Solicitud_Rep_BLL
        Inherits Base_BLL

        Public Shared Sub insertar(ByVal cod_solicitud As String, ByVal tipo_prueba As String, ByVal descripcion As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Rep_ABCD", New Object() { _
                                            New Object() {"@query", "insertar"}, _
                                            New Object() {"@cod_solicitud", cod_solicitud}, _
                                            New Object() {"@tipo_prueba", tipo_prueba}, _
                                            New Object() {"@descripcion", descripcion} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub modificar(ByVal id As Integer, ByVal tipo_prueba As String, ByVal descripcion As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Rep_ABCD", New Object() { _
                                            New Object() {"@query", "modificar"}, _
                                            New Object() {"@id", id}, _
                                            New Object() {"@tipo_prueba", tipo_prueba}, _
                                            New Object() {"@descripcion", descripcion} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub eliminar(ByVal id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Rep_ABCD", New Object() { _
                                            New Object() {"@query", "eliminar"}, _
                                            New Object() {"@id", id} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar(ByVal cod_solicitud As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Rep_ABCD", New Object() { _
                                              New Object() {"@query", "consultar"}, _
                                              New Object() {"@cod_solicitud", cod_solicitud} _
                                              }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_por_id(ByVal id As Integer) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Rep_ABCD", New Object() { _
                                              New Object() {"@query", "consultar_por_id"}, _
                                              New Object() {"@id", id} _
                                              }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Sub actu_prueba_inc(ByVal sol_rep_id As Integer, ByVal prueba_id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Rep_ABCD", New Object() { _
                                            New Object() {"@query", "actu_prueba_inc"}, _
                                            New Object() {"@id", sol_rep_id}, _
                                            New Object() {"@prueba_id", prueba_id} _
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar_pruebas(ByVal cod_solicitud As String, ByVal sol_rep_id As Integer) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Rep_ABCD", New Object() { _
                                              New Object() {"@query", "consultar_pruebas"}, _
                                              New Object() {"@cod_solicitud", cod_solicitud}, _
                                              New Object() {"@id", sol_rep_id} _
                                              }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

    End Class

End Namespace
