Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Token_BLL
        Inherits Base_BLL

        Public Shared Function generar(ByVal fecha_fin As DateTime, ByVal data1 As String, Optional ByVal data2 As String = Nothing, Optional ByVal data3 As String = Nothing, Optional ByVal data4 As String = Nothing, Optional ByVal data5 As String = Nothing) As String
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("aspnetdb3", "global_Token_sp", New Object() { _
                                            New Object() {"@query", "generar"}, _
                                            New Object() {"@fecha_fin", fecha_fin}, _
                                            New Object() {"@data1", data1}, _
                                            New Object() {"@data2", data2}, _
                                            New Object() {"@data3", data3}, _
                                            New Object() {"@data4", data4}, _
                                            New Object() {"@data5", data5} _
                                            }, CommandType.StoredProcedure).Tables(0).Rows(0)(0)
            Catch ex As Exception
                ColocaError(ex)
            End Try
            Return Nothing
        End Function

        Public Shared Function consultar(ByVal token As String) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("aspnetdb3", "global_Token_sp", New Object() { _
                                              New Object() {"@query", "consultar"}, _
                                              New Object() {"@token", token} _
                                          }, CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                ColocaError(ex)
            End Try
            Return Nothing
        End Function
    End Class

End Namespace

