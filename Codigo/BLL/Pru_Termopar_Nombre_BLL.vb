Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Pru_Termopar_Nombre_BLL
        Inherits Base_BLL

        Public Shared Sub guardar(posicion As Integer, nom_estandar As String, usuario As String)
            Dim trsql As New TransacSQL
            trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Termopar_Nombre_sp", New Object() { _
                                            New Object() {"@query", "guardar"}, _
                                            New Object() {"@posicion", posicion}, _
                                            New Object() {"@nom_estandar", nom_estandar}, _
                                            New Object() {"@usuario", usuario} _
                                        }, CommandType.StoredProcedure)
        End Sub

        Public Shared Function consultar(categoria As String) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Termopar_Nombre_sp", New Object() { _
                                            New Object() {"@query", "consultar"}, _
                                            New Object() {"@categoria", categoria} _
                                        }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

        Public Shared Function consultar_categorias() As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Termopar_Nombre_sp", New Object() { _
                                            New Object() {"@query", "consultar_categorias"} _
                                        }, CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function

    End Class

End Namespace
