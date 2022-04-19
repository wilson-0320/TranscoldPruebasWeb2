Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Solicitud_Hist_BLL
        Inherits Base_BLL

        Const PathBase As String = "E:\\EstaticosWeb\\TranscoldPruebasWeb\\"

        Public Shared Function ActuEstado(ByVal Solicitud_Cod As String, ByVal Estado As String, ByVal Observaciones As String, ByVal Usuario As String, ByVal Division_ID As Integer, Optional ByVal ID As Integer = -1) As String
            Dim TrSql As New TransacSQL
            Dim msj As String = TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Hist_Actualiza", New Object() {
                                   New Object() {"@Tipo", "Estado2"},
                                   New Object() {"@ID", ID},
                                   New Object() {"@Estado", Estado},
                                   New Object() {"@Solicitud_Cod", Solicitud_Cod.TrimEnd},
                                   New Object() {"@Observaciones", Observaciones},
                                   New Object() {"@Usuario", Usuario},
                                   New Object() {"@Division_ID", Division_ID}
                                   }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)
            If Estado = "Enviada" And Not msj.StartsWith("Error:") Then
                Dim valores As String()


                '  For Each valoresSt As String In msj.Split("/")
                ' If valoresSt <> "" Then
                '  valores = valoresSt.Split("|")
                '  Dim sourcePath As String = PathBase + "ElemSol\\" + valores(0) + "\\"
                '  Dim destPath As String = PathBase + "ElemHist\\" + valores(1) + "\\"
                '  Dim nomArch As String = valores(2)
                'ArchivosLib.MoverArchivoADirectorio(sourcePath, destPath, nomArch)
                ' End If
                '  Next
            End If
            Return msj
        End Function

        Public Shared Function GuardaFechaEnviado(ByVal ID As Integer, ByVal Fecha_Enviado As DateTime) As String
            Dim TrSql As New TransacSQL
            Dim msj As String = TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Hist_Actualiza", New Object() { _
                                   New Object() {"@Tipo", "GuardaFechaEnviado"}, _
                                   New Object() {"@ID", ID}, _
                                   New Object() {"@Fecha_Enviado", Fecha_Enviado} _
                                   }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)
            Return msj
        End Function

        Public Shared Function Eliminar(ByVal ID As Integer) As String
            Dim TrSql As New TransacSQL
            Dim msj As String = TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Hist_Actualiza", New Object() { _
                                   New Object() {"@Tipo", "Eliminar"}, _
                                   New Object() {"@ID", ID} _
                                   }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)
            Return msj
        End Function

        Public Shared Function Eliminar2(ByVal ID As Integer) As String
            Dim TrSql As New TransacSQL
            Dim msj As String = TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Elemento_Actualiza", New Object() {
                                   New Object() {"@Tipo", "Eliminar"},
                                   New Object() {"@ID", ID}
                                   }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)
            Return msj
        End Function
        Public Shared Function consultar_por_codigo_estado_division(ByVal codigo As String, ByVal estado As String, ByVal division_id As Integer) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Hist_ABCD", New Object() { _
                                              New Object() {"@query", "consultar_por_codigo_estado_division"}, _
                                              New Object() {"@codigo", codigo}, _
                                              New Object() {"@estado", estado}, _
                                              New Object() {"@division_id", division_id} _
                                              }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_por_codigo_locacion_estado(ByVal codigo As String, ByVal locacion As String, ByVal estado As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Hist_ABCD", New Object() {
                                              New Object() {"@query", "consultar_por_codigo_locacion_estado"},
                                              New Object() {"@codigo", codigo},
                                              New Object() {"@estado", estado},
                                              New Object() {"@locacion", locacion}
                                              }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function revisar_y_aprobar(ByVal id As Int32, ByVal usuario As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Hist_ABCD", New Object() {
                                              New Object() {"@query", "aprobar"},
                                              New Object() {"@id", id},
                                              New Object() {"@usuario", usuario}
                                              }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function rechazar(ByVal id As Int32, ByVal usuario As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Hist_ABCD", New Object() {
                                              New Object() {"@query", "rechazar"},
                                              New Object() {"@id", id},
                                              New Object() {"@usuario", usuario}
                                              }, CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

    End Class

End Namespace
