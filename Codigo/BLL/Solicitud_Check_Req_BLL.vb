Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Solicitud_Check_Req_BLL


        Public Shared Function inserta_actualiza_elimina_(ByVal Tipo As String, ByVal ID As Integer, ByVal Solicitud_Cod As String, ByVal Elemento_ID As Integer, ByVal id_Evento As Integer, ByVal Descripcion As String, ByVal Usuario As String) As String
            Dim TrSql As New TransacSQL
            Dim msj As String = TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Check_Pruebas_ABCD", New Object() {
                                   New Object() {"@Tipo", Tipo},
                                   New Object() {"@Codigo", Solicitud_Cod.TrimEnd},
                                   New Object() {"@ID_Elemento_Req", Elemento_ID},
                                   New Object() {"@ID_Evento", id_Evento},
                                   New Object() {"@Descripcion", Descripcion},
                                   New Object() {"@ID", ID},
                                   New Object() {"@Usuario", Usuario}
                                   }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)

            Return msj
        End Function

        Public Shared Function consulta_reporte(ByVal Tipo As String, ByVal ID As Integer, ByVal Solicitud_Cod As String, ByVal Elemento_ID As Integer, ByVal id_Catalogo As Integer, ByVal Tipo_ As String) As DataTable
            Dim TrSql As New TransacSQL
            Return TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Check_Pruebas_ABCD", New Object() {
                                   New Object() {"@Tipo", Tipo},
                                   New Object() {"@Codigo", Solicitud_Cod.TrimEnd},
                                   New Object() {"@ID_Elemento_Req", Elemento_ID},
                                   New Object() {"@ID_Evento", id_Catalogo},
                                   New Object() {"@ID", ID},
                                   New Object() {"@Tipo_", Tipo_}
                                   }, Data.CommandType.StoredProcedure).Tables(0)


        End Function

        Public Shared Function consulta_secuencia(ByVal Tipo As String, ByVal ID As Integer, ByVal Solicitud_Cod As String, ByVal Num As Integer, ByVal id_Catalogo As Integer, ByVal Tipo_ As String) As DataTable
            Dim TrSql As New TransacSQL
            Return TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Check_Pruebas_ABCD", New Object() {
                                   New Object() {"@Tipo", Tipo},
                                   New Object() {"@Codigo", Solicitud_Cod.TrimEnd},
                                   New Object() {"@Num", Num},
                                   New Object() {"@ID_Evento", id_Catalogo},
                                   New Object() {"@ID", ID},
                                   New Object() {"@Tipo_", Tipo_}
                                   }, Data.CommandType.StoredProcedure).Tables(0)


        End Function




    End Class

End Namespace
