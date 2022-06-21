Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Met_Instrumento_Proveedor_BLL
        Inherits Base_BLL



        Public Shared Sub crud(ByVal query As String, ByVal id As Integer, ByVal idInstrumento As Integer, ByVal idLaboratorio As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Met_Instrumento_Proveedor_ABCD", New Object() {
                                            New Object() {"@query", query},
                                            New Object() {"@ID", id},
                                            New Object() {"@instrumento_id", idInstrumento},
                                            New Object() {"@proveedor_id", idLaboratorio}
                                            }, Data.CommandType.StoredProcedure)



            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub


        Public Shared Sub Eliminar(ByVal id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Met_Instrumento_Proveedor_ABCD", New Object() {
                                            New Object() {"@query", "Eliminar"},
                                            New Object() {"@ID", id}
                                            }, Data.CommandType.StoredProcedure)



            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar(ByVal idInstrumento As Integer) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Met_Instrumento_Proveedor_ABCD", New Object() {
                                            New Object() {"@query", "POR Met_Instrumento"},
                                            New Object() {"@instrumento_id", idInstrumento}
                                            }, Data.CommandType.StoredProcedure).Tables(0)



            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function



    End Class

End Namespace

