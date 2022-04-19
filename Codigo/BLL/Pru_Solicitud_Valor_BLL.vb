Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Pru_Solicitud_Valor_BLL
        Inherits Base_BLL

        Public Shared Sub guardar(ByVal CodSolicitud As String, ByVal Categoria As String, ByVal Propiedad As String, ByVal Valor As String, ByVal usuario As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                            New Object() {"@query", "guardar"}, _
                                            New Object() {"@CodSolicitud", CodSolicitud}, _
                                            New Object() {"@Categoria", Categoria}, _
                                            New Object() {"@Propiedad", Propiedad}, _
                                            New Object() {"@Valor", Valor}, _
                                            New Object() {"@usuario", usuario} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function eliminar(ByVal CodSolicitud As String, ByVal Categoria As String, ByVal Propiedad As String, ByVal usuario As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                                New Object() {"@query", "eliminar"}, _
                                                New Object() {"@CodSolicitud", CodSolicitud}, _
                                                New Object() {"@Categoria", Categoria}, _
                                                New Object() {"@Propiedad", Propiedad}, _
                                                New Object() {"@usuario", usuario} _
                                                }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar(ByVal CodSolicitud As String, ByVal Categoria As String, ByVal Propiedad As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Entrega_sp", New Object() { _
                                                New Object() {"@query", "eliminar"}, _
                                                New Object() {"@CodSolicitud", CodSolicitud}, _
                                                New Object() {"@Categoria", Categoria}, _
                                                New Object() {"@Propiedad", Propiedad} _
                                                }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

    End Class

End Namespace

