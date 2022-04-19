Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Lec_BLL
        Inherits Base_BLL

        Public Shared Sub insertar_subcategoria(ByVal categ_id As Integer, ByVal descripcion As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "insertar_subcategoria"}, _
                                            New Object() {"@descripcion", descripcion}, _
                                            New Object() {"@categ_id", categ_id} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub modificar_subcategoria(ByVal id As Integer, ByVal descripcion As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "modificar_subcategoria"}, _
                                            New Object() {"@id", id}, _
                                            New Object() {"@descripcion", descripcion} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub eliminar_subcategoria(ByVal id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "eliminar_subcategoria"}, _
                                            New Object() {"@id", id} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar_subcategorias_por_categoria(ByVal categ_id As Integer) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                              New Object() {"@query", "consultar_subcategorias_por_categoria"}, _
                                              New Object() {"@categ_id", categ_id} _
                                              }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_subcategoria_por_id(ByVal id As Integer) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                              New Object() {"@query", "consultar_subcategoria_por_id"}, _
                                              New Object() {"@id", id} _
                                              }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_subcategorias() As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "consultar_subcategorias"} _
                                            }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Sub insertar_lectura(ByVal descripcion As String, ByVal sub_cat_id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "insertar_lectura"}, _
                                            New Object() {"@descripcion", descripcion}, _
                                            New Object() {"@sub_cat_id", sub_cat_id} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub modificar_lectura(ByVal id As Integer, ByVal descripcion As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "modificar_lectura"}, _
                                            New Object() {"@id", id}, _
                                            New Object() {"@descripcion", descripcion} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub eliminar_lectura(ByVal id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "eliminar_lectura"}, _
                                            New Object() {"@id", id} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar_lecturas_por_sub_cat_id(ByVal sub_cat_id As Integer) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "consultar_lecturas_por_sub_cat_id"}, _
                                            New Object() {"@sub_cat_id", sub_cat_id} _
                                            }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_lectura_por_id(ByVal id As Integer) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "consultar_lectura_por_id"}, _
                                            New Object() {"@id", id} _
                                            }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_lecturas() As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "consultar_lecturas"} _
                                            }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Sub insertar_canal(ByVal camara_id As Integer, ByVal serie As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "insertar_canal"}, _
                                            New Object() {"@camara_id", camara_id}, _
                                            New Object() {"@serie", serie} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub modificar_canal(ByVal id As Integer, ByVal serie As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "modificar_canal"}, _
                                            New Object() {"@id", id}, _
                                            New Object() {"@serie", serie} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub eliminar_canal(ByVal id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "eliminar_canal"}, _
                                            New Object() {"@id", id} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar_canales_por_camara_id(ByVal camara_id As Integer) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                              New Object() {"@query", "consultar_canales_por_camara_id"}, _
                                              New Object() {"@camara_id", camara_id} _
                                              }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_canal_por_id(ByVal id As Integer) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                              New Object() {"@query", "consultar_canal_por_id"}, _
                                              New Object() {"@id", id} _
                                              }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_canal_por_serie(ByVal serie As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                              New Object() {"@query", "consultar_canal_por_serie"}, _
                                              New Object() {"@serie", serie} _
                                              }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Sub insertar_cable(ByVal serie As String, ByVal serie_canal As String)
            MsjError = Nothing
            Try
                Dim canal_id As Object = DBNull.Value
                If serie_canal <> "" Then
                    Dim dt As DataTable = consultar_canal_por_serie(serie_canal)
                    If Not MsjError Is Nothing Then
                        Throw New Exception("Error al consultar la existencia del canal: " + MsjError)
                    ElseIf dt.Rows.Count = 0 Then
                        Throw New Exception("No existe esa serie de canal")
                    End If
                    canal_id = dt.Rows(0)("id")
                End If
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "insertar_cable"}, _
                                            New Object() {"@serie", serie}, _
                                            New Object() {"@canal_id", canal_id} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub modificar_cable(ByVal id As Integer, ByVal serie As String, ByVal serie_canal As String)
            MsjError = Nothing
            Try
                Dim canal_id As Object = DBNull.Value
                If serie_canal <> "" Then
                    Dim dt As DataTable = consultar_canal_por_serie(serie_canal)
                    If Not MsjError Is Nothing Then
                        Throw New Exception("Error al consultar la existencia del canal: " + MsjError)
                    ElseIf dt.Rows.Count = 0 Then
                        Throw New Exception("No existe esa serie de canal")
                    End If
                    canal_id = dt.Rows(0)("id")
                End If
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "modificar_cable"}, _
                                            New Object() {"@id", id}, _
                                            New Object() {"@serie", serie}, _
                                            New Object() {"@canal_id", canal_id} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub eliminar_cable(ByVal id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "eliminar_cable"}, _
                                            New Object() {"@id", id} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar_cables(ByVal serie As String, ByVal cnl_serie As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "consultar_cables"}, _
                                            New Object() {"@serie", serie}, _
                                            New Object() {"@cnl_serie", cnl_serie} _
                                            }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_cable_por_id(ByVal id As Integer) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "consultar_cable_por_id"}, _
                                            New Object() {"@id", id} _
                                            }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_cable_por_serie(ByVal serie As String) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "consultar_cable_por_serie"}, _
                                            New Object() {"@serie", serie} _
                                            }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Sub insertar_punto(ByVal serie As String, ByVal tipo As String, ByVal cable_id As Nullable(Of Integer))
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "insertar_punto"}, _
                                            New Object() {"@serie", serie}, _
                                            New Object() {"@tipo", tipo}, _
                                            New Object() {"@cable_id", cable_id} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub modificar_punto(ByVal id As Integer, ByVal serie As String, ByVal tipo As String, ByVal cable_id As Nullable(Of Integer))
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "modificar_punto"}, _
                                            New Object() {"@id", id}, _
                                            New Object() {"@serie", serie}, _
                                            New Object() {"@tipo", tipo}, _
                                            New Object() {"@cable_id", cable_id} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub eliminar_punto(ByVal id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "eliminar_punto"}, _
                                            New Object() {"@id", id} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar_puntos(ByVal serie As String, ByVal tipo As String, ByVal c_serie As String, ByVal cnl_serie As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "consultar_puntos"}, _
                                            New Object() {"@serie", serie}, _
                                            New Object() {"@tipo", tipo}, _
                                            New Object() {"@c_serie", c_serie}, _
                                            New Object() {"@cnl_serie", cnl_serie} _
                                            }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_punto_por_id(ByVal id As Integer) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                              New Object() {"@query", "consultar_punto_por_id"}, _
                                              New Object() {"@id", id} _
                                              }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Sub limpiar_conexiones(ByVal cod_solicitud As String, Optional ByVal sub_cat_id As Integer = -1)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "limpiar_conexiones"}, _
                                            New Object() {"@cod_solicitud", cod_solicitud}, _
                                            New Object() {"@sub_cat_id", sub_cat_id} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar_conexiones(ByVal cod_solicitud As String, ByVal sub_cat_id As Integer) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                              New Object() {"@query", "consultar_conexiones"}, _
                                              New Object() {"@cod_solicitud", cod_solicitud}, _
                                              New Object() {"@sub_cat_id", sub_cat_id} _
                                              }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Sub guardar_lectura_conexion(ByVal cod_solicitud As String, ByVal sub_cat_id As Integer, ByVal dt As DataTable)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Lec_ABCD", New Object() { _
                                            New Object() {"@query", "guardar_lectura_conexion"}, _
                                            New Object() {"@cod_solicitud", cod_solicitud}, _
                                            New Object() {"@sub_cat_id", sub_cat_id}, _
                                            trsql.ObtParamLista("@l_con", "dbo.tbl_lec_conexiones", dt) _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

    End Class

End Namespace
