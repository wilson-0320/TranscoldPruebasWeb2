Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Valor_Rel_BLL
        Inherits Base_BLL

        Public Shared Sub insertar_modificar(ByVal querys As String, ByVal elemento_id As Integer, ByVal valor As String, ByVal valor_rel As String, ByVal ID As Integer)
            MsjError = Nothing
            Try
                Dim TrSql As New TransacSQL
                TrSql.EjecutarActualizacion("TranscoldPruebas", "Pru_Valor_Relacionado_ABCD", New Object() {
                                            New Object() {"@query", querys},
                                            New Object() {"@elemento_id", elemento_id},
                                            New Object() {"@valor", valor},
                                            New Object() {"@valor_rel", valor_rel},
                                            New Object() {"@id", ID}
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub modificar(ByVal id As Integer, ByVal valor As String, ByVal valor_rel As String)
            MsjError = Nothing
            Try
                Dim TrSql As New TransacSQL
                TrSql.EjecutarActualizacion("TranscoldPruebas", "Pru_Valor_Relacionado_ABCD", New Object() {
                                            New Object() {"@query", "modificar"},
                                            New Object() {"@id", id},
                                            New Object() {"@valor", valor},
                                            New Object() {"@valor_rel", valor_rel}
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub eliminar(ByVal id As Integer)
            MsjError = Nothing
            Try
                Dim TrSql As New TransacSQL
                TrSql.EjecutarActualizacion("TranscoldPruebas", "Pru_Valor_Relacionado_ABCD", New Object() { _
                                            New Object() {"@query", "eliminar"}, _
                                            New Object() {"@id", id} _
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar_categorias() As DataTable
            MsjError = Nothing
            Try
                Dim TrSql As New TransacSQL
                Return TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Valor_Relacionado_ABCD", New Object() { _
                                            New Object() {"@query", "consultar_categorias"} _
                                            }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_elementos(ByVal categoria_id As Integer) As DataTable
            MsjError = Nothing
            Try
                Dim TrSql As New TransacSQL
                Return TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Valor_Relacionado_ABCD", New Object() { _
                                            New Object() {"@query", "consultar_elementos"}, _
                                            New Object() {"@categoria_id", categoria_id} _
                                            }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar(ByVal elemento_id As Integer) As DataTable
            MsjError = Nothing
            Try
                Dim TrSql As New TransacSQL
                Return TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Valor_Relacionado_ABCD", New Object() { _
                                            New Object() {"@query", "consultar"}, _
                                            New Object() {"@elemento_id", elemento_id} _
                                            }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

    End Class

End Namespace


