Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Laboratorios_Calibracion_BLL
        Inherits Base_BLL



        Public Shared Function crud(ByVal query As String, ByVal id As Integer, ByVal idInstrumento As Integer, ByVal idCatalogo As Integer) As String
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Dim msj As String = trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Laboratorio_Calibracion_ABCD", New Object() {
                                            New Object() {"@query", query},
                                            New Object() {"@ID", id},
                                            New Object() {"@ID_Instrumento", idInstrumento},
                                            New Object() {"@ID_Laboratorio", idCatalogo}
                                            }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)


                Return msj
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function



    End Class

End Namespace

