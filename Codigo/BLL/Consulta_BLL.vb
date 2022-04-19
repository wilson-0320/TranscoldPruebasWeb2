Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Consulta_BLL
        Inherits Base_BLL

        Public Shared Function CatalogoPorCategoria(ByVal categ_id As Integer) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Consulta", New Object() { _
                                              New Object() {"@Consulta", "CatalogoPorCategoria"}, _
                                              New Object() {"@Filtro1", categ_id} _
                                              }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function insertaCarpetaId(ByVal carpeta As String, ByVal Upload As Boolean, ByVal AllowCopy As Boolean, ByVal AllowCreate As Boolean, ByVal AllowDelete As Boolean, _
                                                ByVal AllowDownload As Boolean, ByVal AllowMove As Boolean, ByVal AllowRename As Boolean, _
                                                ByVal fecha_fin As Nullable(Of DateTime), Optional ByVal path_actual As String = Nothing, _
                                                Optional ByVal raiz_web As String = Nothing, Optional ByVal raiz_de_raiz As String = Nothing, _
                                                Optional ByVal crear_si_no_ex As Object = Nothing, Optional ByVal conf_sobreescr As Object = Nothing, _
                                                Optional ByVal guardar_reg As Object = Nothing, Optional ByVal ap_reg As String = Nothing, Optional ByVal tipo_reg As String = Nothing, _
                                                Optional ByVal id_reg As String = Nothing) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("aspnetdb3", "Por_Carpeta_ABCD", New Object() { _
                                                New Object() {"@query", "inserta"}, _
                                                New Object() {"@carpeta", carpeta}, _
                                                New Object() {"@Upload", Upload}, _
                                                New Object() {"@AllowCopy", AllowCopy}, _
                                                New Object() {"@AllowCreate", AllowCreate}, _
                                                New Object() {"@AllowDelete", AllowDelete}, _
                                                New Object() {"@AllowDownload", AllowDownload}, _
                                                New Object() {"@AllowMove", AllowMove}, _
                                                New Object() {"@AllowRename", AllowRename}, _
                                                New Object() {"@fecha_fin", fecha_fin}, _
                                                New Object() {"@path_actual", path_actual}, _
                                                New Object() {"@raiz_web", raiz_web}, _
                                                New Object() {"@raiz_de_raiz", raiz_de_raiz}, _
                                                New Object() {"@crear_si_no_ex", crear_si_no_ex}, _
                                                New Object() {"@conf_sobreescr", conf_sobreescr}, _
                                                New Object() {"@guardar_reg", guardar_reg}, _
                                                New Object() {"@ap_reg", ap_reg}, _
                                                New Object() {"@tipo_reg", tipo_reg}, _
                                                New Object() {"@id_reg", id_reg} _
                                            }, CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

    End Class

End Namespace

