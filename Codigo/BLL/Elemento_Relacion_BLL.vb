Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Elemento_Relacion_DAL
        Inherits Base_BLL

        Public Shared Sub insertar(ByVal elemento_id As Integer, ByVal elemento_rel_id As Integer, ByVal valor As String, ByVal valor_rel As String)
            MsjError = "Realizado"
            If elemento_id = -1 Then
                MsjError = "Debe escoger el elemento"
            ElseIf elemento_rel_id = -1 Then
                MsjError = "Debe escoger el elemento relacionado"
            ElseIf elemento_id = elemento_rel_id Then
                MsjError = "El elemento y el elemento relacionado no pueden ser iguales"
            Else
                Dim TrSql As New TransacSQL
                Try
                    TrSql.EjecutarActualizacion("TranscoldPruebas", "Pru_Elemento_Relacion_ABCD", New Object() {
                                                New Object() {"@query", "insertar"},
                                                New Object() {"@elemento_id", elemento_id},
                                                New Object() {"@elemento_rel_id", elemento_rel_id},
                                                New Object() {"@valor", valor},
                                                New Object() {"@valor_rel", valor_rel}
                                                }, Data.CommandType.StoredProcedure)
                Catch ex As Exception
                    colocaError(ex)
                End Try
            End If

        End Sub

        Public Shared Sub modificar(ByVal id As Integer, ByVal valor As String, ByVal valor_rel As String)
            MsjError = Nothing
            Dim TrSql As New TransacSQL
            Try
                TrSql.EjecutarActualizacion("TranscoldPruebas", "Pru_Elemento_Relacion_ABCD", New Object() {
                                            New Object() {"@query", "modificar"},
                                            New Object() {"@id", id},
                                            New Object() {"@valor", valor},
                                            New Object() {"@valor_rel", valor_rel}
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try

        End Sub

        Public Shared Sub eliminar(ByVal id As Integer)
            MsjError = Nothing
            Dim TrSql As New TransacSQL
            Try
                TrSql.EjecutarActualizacion("TranscoldPruebas", "Pru_Elemento_Relacion_ABCD", New Object() {
                                            New Object() {"@query", "eliminar"},
                                            New Object() {"@id", id}
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar_por_id(ByVal id As Integer) As DataRow
            MsjError = Nothing
            Dim TrSql As New TransacSQL
            Try
                Return TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Elemento_Relacion_ABCD", New Object() { _
                                                New Object() {"@query", "consultar_por_id"}, _
                                                New Object() {"@id", id} _
                                                }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_por_filtro(ByVal elemento_id As Integer, ByVal elemento_rel_id As Integer) As DataTable
            MsjError = Nothing
            Dim TrSql As New TransacSQL
            Try
                Return TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Elemento_Relacion_ABCD", New Object() { _
                                                New Object() {"@query", "consultar_por_filtro"}, _
                                                New Object() {"@elemento_id", elemento_id}, _
                                                New Object() {"@elemento_rel_id", elemento_rel_id} _
                                                }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

    End Class

End Namespace
