Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Certificados_Calibracion_BLL
        Inherits Base_BLL



        Public Shared Function crud(ByVal query As String, ByVal id As Integer, ByVal idInstrumento As Integer, ByVal idLab As Integer,
                                    ByVal Guiae As String, ByVal Guiar As String, ByVal certificado As String, ByVal Fcal As Date, ByVal fprox As Date) As String
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Dim msj As String = trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Certificados_Equipos_ABCD", New Object() {
                                            New Object() {"@query", query},
                                            New Object() {"@ID", id},
                                            New Object() {"@ID_Instrumento", idInstrumento},
                                            New Object() {"@ID_Laboratorio", idLab},
                                            New Object() {"@Guiae", Guiae.TrimEnd},
                                             New Object() {"@Guiar", Guiar.TrimEnd},
                                              New Object() {"@Certificados", certificado.TrimEnd},
                                               New Object() {"@FCal", Fcal},
                                                New Object() {"@FProx", fprox}
                                            }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)


                Return msj
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function



    End Class

End Namespace

