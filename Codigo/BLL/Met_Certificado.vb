Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Met_Certificado_BLL
        Inherits Base_BLL



        Public Shared Sub crud(ByVal query As String, ByVal id As Integer, ByVal idInstrumento As Integer, ByVal idLab As Integer,
                                    ByVal Guiae As String, ByVal Guiar As String, ByVal certificado As String, ByVal certificadoLink As String,
                               ByVal Fcal As Date, ByVal fprox As Date, ByVal usuario As String, ByVal vigente As Boolean)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Met_Certificado_ABCD", New Object() {
                                            New Object() {"@query", query},
                                            New Object() {"@ID", id},
                                            New Object() {"@ID_Instrumento", idInstrumento},
                                            New Object() {"@ID_Laboratorio", idLab},
                                            New Object() {"@Guiae", Guiae.TrimEnd},
                                            New Object() {"@Guiar", Guiar.TrimEnd},
                                            New Object() {"@Certificado", certificado.TrimEnd},
                                            New Object() {"@CertificadosLink", certificadoLink.TrimEnd},
                                            New Object() {"@FCal", Fcal},
                                            New Object() {"@FProx", fprox},
                                            New Object() {"@Usuario", usuario}, New Object() {"@Vigente", vigente}
                                            }, Data.CommandType.StoredProcedure)



            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Sub Eliminar(ByVal id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Met_Certificado_ABCD", New Object() {
                                            New Object() {"@query", "Eliminar"},
                                            New Object() {"@ID", id}
                                            }, Data.CommandType.StoredProcedure)



            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub


        Public Shared Function consultar_por_id(ByVal id As Integer) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Met_Certificado_ABCD", New Object() {
                                            New Object() {"@query", "consultar_por_id"},
                                            New Object() {"@ID", id}
                                            }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)



            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function


        Public Shared Function consultar_por_instrumento(ByVal idInstrumento As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Met_Certificado_ABCD", New Object() {
                                            New Object() {"@query", "consultar_por_instrumentos"},
                                            New Object() {"@ID_instrumento", idInstrumento}
                                            }, Data.CommandType.StoredProcedure)



            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function


    End Class

End Namespace

