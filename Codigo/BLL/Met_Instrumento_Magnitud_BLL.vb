Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Met_Instrumento_Magnitud_BLL
        Inherits Base_BLL

        Public Shared Sub crud(ByVal query As String, ByVal id As Integer, ByVal instrumento As Integer, ByVal exactitud As String,
                               ByVal resolucion As Double, ByVal puntos As String, ByVal rango_ini As Double,
                                ByVal rango_fin As Double,
                               ByVal id_magnitud As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Met_Instrumento_Magnitud_ABCD", New Object() {
                                            New Object() {"@query", query},
                                            New Object() {"@id", id},
                                            New Object() {"@instrumento_id", instrumento},
                                            New Object() {"@magnitud_id", id_magnitud},
                                            New Object() {"@exactitud", exactitud},
                                            New Object() {"@resolucion", resolucion},
                                            New Object() {"@puntos_calibracion", puntos},
                                            New Object() {"@rango_ini", rango_ini},
                                            New Object() {"@rango_fin", rango_fin}
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub


        Public Shared Sub eliminar(ByVal id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Met_Instrumento_Magnitud_ABCD", New Object() {
                                            New Object() {"@query", "ELIMINAR"},
                                            New Object() {"@id", id}
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar(ByVal idInstrumento As Integer) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Met_Instrumento_Magnitud_ABCD", New Object() {
                                                New Object() {"@query", "PorMetInstrumento"},
                                                 New Object() {"@instrumento_id", idInstrumento}
                                                }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function



        Public Shared Function consultar_por_id(ByVal id As String) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Met_Instrumento_Magnitud_ABCD", New Object() {
                                                New Object() {"@query", "POR LLAVE"},
                                                New Object() {"@id", id}
                                                }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function




    End Class

End Namespace

