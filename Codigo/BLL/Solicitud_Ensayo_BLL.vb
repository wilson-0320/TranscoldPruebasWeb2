Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Solicitud_Ensayo_BLL
        Inherits Base_BLL

        Public Shared Function consultar(ByVal Solicitud_Cod As String, ByVal Tipo As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Ensayo_ABCD", New Object() { _
                                              New Object() {"@query", "consultar"}, _
                                              New Object() {"@Solicitud_Cod", Solicitud_Cod}, _
                                              New Object() {"@Tipo", Tipo} _
                                              }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Sub eliminar(ByVal id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Ensayo_ABCD", New Object() { _
                                            New Object() {"@query", "eliminar"}, _
                                            New Object() {"@id", id} _
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub insertar(ByVal Solicitud_Cod As String, ByVal Tipo As String, ByVal Ensayo_ID As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Ensayo_ABCD", New Object() { _
                                            New Object() {"@query", "insertar"}, _
                                            New Object() {"@Solicitud_Cod", Solicitud_Cod}, _
                                            New Object() {"@Tipo", Tipo}, _
                                            New Object() {"@Ensayo_ID", Ensayo_ID} _
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub modificar(ByVal ID As Integer, ByVal Prueba As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Ensayo_ABCD", New Object() { _
                                            New Object() {"@query", "modificar"}, _
                                            New Object() {"@ID", ID}, _
                                            New Object() {"@Prueba", Prueba} _
                                            }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

    End Class

End Namespace

