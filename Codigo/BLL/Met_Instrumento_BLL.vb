Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Met_Instrumento_BLL
        Inherits Base_BLL

        Public Shared Sub crud(ByVal query As String, ByVal id As Int32, ByVal instrumento As String, ByVal descripcion As String,
                               ByVal descripcion_ing As String, ByVal rango_maximo As String,
                               ByVal marca_id As Integer, ByVal modelo As String, ByVal serie As String, ByVal vigente As Boolean,
                               ByVal periodo_calibracion As Integer, ByVal periodo_revision As Integer, ByVal comentarios As String,
                               ByVal asig_fisica_id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Met_Instrumento_ABCD", New Object() {
                                            New Object() {"@query", query},
                                            New Object() {"@id", id},
                                            New Object() {"@instrumento", instrumento},
                                            New Object() {"@descripcion", descripcion},
                                            New Object() {"@descripcion_ing", descripcion_ing},
                                            New Object() {"@marca_id", marca_id},
                                            New Object() {"@modelo", modelo},
                                            New Object() {"@serie", serie},
                                            New Object() {"@rango_maximo", rango_maximo},
                                            New Object() {"@vigente", vigente},
                                            New Object() {"@periodo_calibracion", periodo_calibracion},
                                            New Object() {"@periodo_revision", periodo_revision},
                                            New Object() {"@comentarios", comentarios},
                                            New Object() {"@asig_fisica_id", asig_fisica_id}
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub


        Public Shared Sub eliminar(ByVal id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Met_Instrumento_ABCD", New Object() {
                                            New Object() {"@query", "ELIMINAR"},
                                            New Object() {"@id", id}
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar() As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Met_Instrumento_ABCD", New Object() {
                                                New Object() {"@query", "TODOS"}
                                                }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function



        Public Shared Function consultar_por_id(ByVal id As String) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Met_Instrumento_ABCD", New Object() {
                                                New Object() {"@query", "POR LLAVE"},
                                                New Object() {"@id", id}
                                                }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function




    End Class

End Namespace

