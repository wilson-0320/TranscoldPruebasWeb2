Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Archivo_BLL
        Inherits Base_BLL

        Public Shared Function insertar(ByVal tipo As String, ByVal idelem As String, ByVal descripcion As String, ByVal archivo As String) As Integer
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Archivo_ABCD", New Object() { _
                                            New Object() {"@query", "insertar"}, _
                                            New Object() {"@tipo", tipo}, _
                                            New Object() {"@idelem", idelem}, _
                                            New Object() {"@descripcion", descripcion}, _
                                            New Object() {"@archivo", archivo} _
                                            }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Sub modificar(ByVal id As Integer, ByVal descripcion As String, ByVal archivo As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Archivo_ABCD", New Object() { _
                                            New Object() {"@query", "modificar"}, _
                                            New Object() {"@id", id}, _
                                            New Object() {"@descripcion", descripcion}, _
                                            New Object() {"@archivo", archivo} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub eliminar(ByVal id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Archivo_ABCD", New Object() { _
                                            New Object() {"@query", "eliminar"}, _
                                            New Object() {"@id", id} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar(ByVal tipo As String, ByVal idelem As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Archivo_ABCD", New Object() { _
                                              New Object() {"@query", "consultar"}, _
                                              New Object() {"@tipo", tipo}, _
                                              New Object() {"@idelem", idelem} _
                                              }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_por_id(ByVal id As Integer) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Archivo_ABCD", New Object() { _
                                              New Object() {"@query", "consultar_por_id"}, _
                                              New Object() {"@id", id} _
                                              }, CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

    End Class

End Namespace

