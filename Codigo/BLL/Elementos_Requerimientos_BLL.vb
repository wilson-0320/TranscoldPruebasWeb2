Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Elemento_Requerimientos_BLL
        Inherits Base_BLL

        Public Shared Function insertar_actualizar(ByVal querys As String, ByVal ID As Integer, ByVal idCategoria As Integer, ByVal Descripcion As String, ByVal Valores As String, ByVal Tipo As String) As String
            MsjError = "Realizado"
            Dim TrSql As New TransacSQL
            Try
                TrSql.EjecutarActualizacion("TranscoldPruebas", "Pru_Elemento_Requerimientos_Actualiza", New Object() {
                                                      New Object() {"@Tipo", querys},
                                                     New Object() {"@ID", ID},
                                                    New Object() {"@Categoria_ID", idCategoria},
                                                  New Object() {"@Descripcion", Descripcion},
                                                    New Object() {"@Tipo_", Tipo.TrimEnd},
                                                 New Object() {"@Valores", Valores}
                                               }, CommandType.StoredProcedure)



            Catch ex As Exception
                colocaError(ex)
            End Try
            Return MsjError
        End Function





        Public Shared Function eliminar(ByVal id As Integer) As String
            MsjError = "Realizado"
            Try
                Dim TrSql As New TransacSQL

                TrSql.EjecutarActualizacion("TranscoldPruebas", "Pru_Elemento_Requerimientos_Actualiza", New Object() {
                                                New Object() {"@Tipo", "Eliminar"},
                                                New Object() {"@ID", id}
                                                }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
            Return MsjError


        End Function



        Public Shared Function subir_bajar(ByVal Catalogo_ID As Integer, ByVal ID As Integer, ByVal opcion As String) As String
            MsjError = "Realizado"
            Try
                Dim TrSql As New TransacSQL

                TrSql.EjecutarActualizacion("TranscoldPruebas", "Pru_Elemento_Requerimientos_Actualiza", New Object() {
                                            New Object() {"@Tipo", opcion},
                                            New Object() {"@ID", ID},
                                            New Object() {"@Categoria_ID", Catalogo_ID}
                                            }, Data.CommandType.StoredProcedure)

            Catch ex As Exception
                colocaError(ex)
            End Try
            Return MsjError

        End Function

    End Class

End Namespace
