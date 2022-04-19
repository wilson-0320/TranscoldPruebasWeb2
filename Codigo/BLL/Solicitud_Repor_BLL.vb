Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Solicitud_Repor_BLL
        Inherits Base_BLL

        Public Shared Sub guardar(ByVal Codigo As String, ByVal Repor_Estado As String, ByVal Repor_Reg_de_Entrada As String, ByVal Repor_Fecha_Fin_Prueba As Nullable(Of DateTime), ByVal Usuario As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Repor_proc", New Object() { _
                                            New Object() {"@query", "guardar"}, _
                                            New Object() {"@Codigo", Codigo}, _
                                            New Object() {"@Repor_Estado", Repor_Estado}, _
                                            New Object() {"@Repor_Reg_de_Entrada", Repor_Reg_de_Entrada}, _
                                            New Object() {"@Repor_Fecha_Fin_Prueba", Repor_Fecha_Fin_Prueba}, _
                                            New Object() {"@Usuario", Usuario} _
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar(ByVal fecha_ini As Nullable(Of DateTime), ByVal fecha_fin As Nullable(Of DateTime), ByVal Repor_Estado As String, ByVal Codigo As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Repor_proc", New Object() { _
                                              New Object() {"@query", "consultar"}, _
                                              New Object() {"@fecha_ini", fecha_ini}, _
                                              New Object() {"@fecha_fin", fecha_fin}, _
                                              New Object() {"@Repor_Estado", Repor_Estado}, _
                                              New Object() {"@Codigo", Codigo} _
                                              }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

    End Class

End Namespace

