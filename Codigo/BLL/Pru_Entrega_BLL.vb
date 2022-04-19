Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Pru_Entrega_BLL
        Inherits Base_BLL

        Public Shared Sub insertar(ByVal N As Integer, ByVal Entrega As String, ByVal Dias As Object, ByVal Activa As Boolean, ByVal usuario As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                            New Object() {"@query", "insertar"}, _
                                            New Object() {"@N", N}, _
                                            New Object() {"@Entrega", Entrega}, _
                                            New Object() {"@Dias", IIf(String.IsNullOrEmpty(Dias), DBNull.Value, Dias)}, _
                                            New Object() {"@Activa", Activa}, _
                                            New Object() {"@usuario", usuario} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub modificar(ByVal id As Integer, ByVal N As Integer, ByVal Entrega As String, ByVal Dias As Object, ByVal Activa As Boolean, ByVal usuario As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                            New Object() {"@query", "modificar"}, _
                                            New Object() {"@id", id}, _
                                            New Object() {"@N", N}, _
                                            New Object() {"@Entrega", Entrega}, _
                                            New Object() {"@Dias", IIf(String.IsNullOrEmpty(Dias), DBNull.Value, Dias)}, _
                                            New Object() {"@Activa", Activa}, _
                                            New Object() {"@usuario", usuario} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub eliminar(ByVal id As Integer, ByVal usuario As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                            New Object() {"@query", "eliminar"}, _
                                            New Object() {"@id", id}, _
                                            New Object() {"@usuario", usuario} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar() As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                                New Object() {"@query", "consultar"} _
                                                }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_activas(ByVal con_vacio As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                                New Object() {"@query", "consultar_activas"}, _
                                                New Object() {"@con_vacio", con_vacio} _
                                                }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_por_entrega(ByVal Entrega As String) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                                New Object() {"@query", "consultar_por_entrega"}, _
                                                New Object() {"@Entrega", Entrega} _
                                                }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        ' ------------------------------------------------------ Pru_Entrega_Usuario ------------------------------------------------------

        Public Shared Sub guardar_entrega_usuario(ByVal Entrega_id As Integer, ByVal UserName As String, ByVal incluir As Boolean, ByVal usuario As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                            New Object() {"@query", "guardar_entrega_usuario"}, _
                                            New Object() {"@Entrega_id", Entrega_id}, _
                                            New Object() {"@UserName", UserName}, _
                                            New Object() {"@incluir", incluir}, _
                                            New Object() {"@usuario", usuario} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar_entrega_usuario(ByVal Entrega_id As Integer, ByVal UserName As String, ByVal solo_con As Boolean) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                                New Object() {"@query", "consultar_entrega_usuario"}, _
                                                New Object() {"@Entrega_id", Entrega_id}, _
                                                New Object() {"@UserName", UserName}, _
                                                New Object() {"@solo_con", solo_con} _
                                                }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_usuarios() As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                                New Object() {"@query", "consultar_usuarios"} _
                                                }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        ' ------------------------------------------------------ Pru_Entrega_Solicitud ------------------------------------------------------

        Public Shared Sub guardar_entrega_solicitud(ByVal cod_solicitud As String, ByVal Entrega_id As Integer, ByVal incluir As Boolean, ByVal usuario As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                            New Object() {"@query", "guardar_entrega_solicitud"}, _
                                            New Object() {"@cod_solicitud", cod_solicitud}, _
                                            New Object() {"@Entrega_id", Entrega_id}, _
                                            New Object() {"@incluir", incluir}, _
                                            New Object() {"@usuario", usuario} _
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub guarda_realiza_entrega_solicitud(ByVal cod_solicitud As String, ByVal Entrega_id As Integer, ByVal usuario As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                            New Object() {"@query", "guarda_realiza_entrega_solicitud"}, _
                                            New Object() {"@cod_solicitud", cod_solicitud}, _
                                            New Object() {"@Entrega_id", Entrega_id}, _
                                            New Object() {"@usuario", usuario} _
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub guarda_entrega_solicitud_link_reporte(ByVal id As Integer, ByVal Link_Reporte As String, fecha_realiza As Nullable(Of DateTime), ByVal usuario As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                            New Object() {"@query", "guarda_entrega_solicitud_link_reporte"}, _
                                            New Object() {"@id", id}, _
                                            New Object() {"@Link_Reporte", Link_Reporte}, _
                                            New Object() {"@fecha_realiza", fecha_realiza}, _
                                            New Object() {"@usuario", usuario} _
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar_solicitudes(ByVal buscar As String, ByVal fecha_ini As Object, ByVal fecha_fin As Object, ByVal Entrega_id As Integer, ByVal UserName As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                              New Object() {"@query", "consultar_solicitudes"}, _
                                              New Object() {"@buscar", buscar}, _
                                              New Object() {"@fecha_ini", FechaONulo(fecha_ini)}, _
                                              New Object() {"@fecha_fin", FechaONulo(fecha_fin)}, _
                                              New Object() {"@Entrega_id", Entrega_id}, _
                                              New Object() {"@UserName", UserName} _
                                              }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_solicitud_entregas(ByVal cod_solicitud As String, ByVal UserName As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                              New Object() {"@query", "consultar_solicitud_entregas"}, _
                                              New Object() {"@cod_solicitud", cod_solicitud}, _
                                              New Object() {"@UserName", UserName} _
                                              }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_solicitud_entrega_por_id(ByVal id As Integer) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                              New Object() {"@query", "consultar_solicitud_entrega_por_id"}, _
                                              New Object() {"@id", id} _
                                              }, CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_reporte(ByVal buscar As String, ByVal fecha_ini As Object, ByVal fecha_fin As Object, ByVal Entrega_id As Integer, ByVal UserName As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                              New Object() {"@query", "consultar_reporte"}, _
                                              New Object() {"@buscar", buscar}, _
                                              New Object() {"@fecha_ini", FechaONulo(fecha_ini)}, _
                                              New Object() {"@fecha_fin", FechaONulo(fecha_fin)}, _
                                              New Object() {"@Entrega_id", Entrega_id}, _
                                              New Object() {"@UserName", UserName} _
                                              }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        ' ------------------------------------------------------ Edita Solicitud ------------------------------------------------------

        Public Shared Sub editar_solicitud(ByVal cod_solicitud As String, ByVal Link_Reporte As String, ByVal usuario As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                            New Object() {"@query", "editar_solicitud"}, _
                                            New Object() {"@cod_solicitud", cod_solicitud}, _
                                            New Object() {"@Link_Reporte", Link_Reporte}, _
                                            New Object() {"@usuario", usuario} _
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar_solicitud(ByVal cod_solicitud As String) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                              New Object() {"@query", "consultar_solicitud"}, _
                                              New Object() {"@cod_solicitud", cod_solicitud} _
                                              }, CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

    End Class

End Namespace

