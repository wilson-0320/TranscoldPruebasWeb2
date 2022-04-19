Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Solicitud_Division_BLL
        Inherits Base_BLL

        Public Shared Sub insertar(ByVal Codigo As String, ByVal Descripcion As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Division_ABCD", New Object() { _
                                            New Object() {"@query", "insertar"}, _
                                            New Object() {"@codigo", Codigo}, _
                                            New Object() {"@descripcion", Descripcion} _
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub modificar(ByVal id As Integer, ByVal Descripcion As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Division_ABCD", New Object() { _
                                            New Object() {"@query", "modificar"}, _
                                            New Object() {"@id", id}, _
                                            New Object() {"@descripcion", Descripcion} _
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub eliminar(ByVal id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Division_ABCD", New Object() { _
                                            New Object() {"@query", "eliminar"}, _
                                            New Object() {"@id", id} _
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar_por_id(ByVal id As Integer) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Division_ABCD", New Object() { _
                                            New Object() {"@query", "consultar_por_id"}, _
                                            New Object() {"@id", id} _
                                            }, CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_por_codigo(ByVal Codigo As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Division_ABCD", New Object() { _
                                            New Object() {"@query", "consultar_por_codigo"}, _
                                            New Object() {"@Codigo", Codigo} _
                                            }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

    End Class

End Namespace

