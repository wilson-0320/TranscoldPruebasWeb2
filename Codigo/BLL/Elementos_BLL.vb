Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Elemento_BLL
        Inherits Base_BLL

        Public Shared Sub insertar_actualizar(ByVal querys As String, ByVal ID As Integer, ByVal idCategoria As Integer, ByVal Descripcion As String,
                                   ByVal Precio As Boolean, ByVal Cantidad As Boolean, ByVal Unico As Boolean,
                                        ByVal Valores As String, ByVal Exactus As Boolean, ByVal Tipo As String)
            MsjError = Nothing
            Dim TrSql As New TransacSQL
            Try
                TrSql.EjecutarActualizacion("TranscoldPruebas", "Pru_Elemento_Actualiza", New Object() {
                                                      New Object() {"@Tipo", querys},
                                                     New Object() {"@ID", ID},
                                                    New Object() {"@Categoria_ID", idCategoria},
                                                  New Object() {"@Descripcion", Descripcion},
                                                  New Object() {"@Precio", Precio},
                                                 New Object() {"@Cantidad", Cantidad},
                                                 New Object() {"@Unico", Unico},
                                                 New Object() {"@Valores", Valores},
                                                 New Object() {"@CodigoEnExactus", Exactus},
                                                 New Object() {"@Tipo_", Tipo}
                                               }, CommandType.StoredProcedure)



            Catch ex As Exception
                colocaError(ex)
            End Try

        End Sub





        Public Shared Sub eliminar(ByVal id As Integer)
            MsjError = Nothing
            Try
                Dim TrSql As New TransacSQL
                TrSql.EjecutarActualizacion("TranscoldPruebas", "Pru_Elemento_Actualiza", New Object() {
                                            New Object() {"@Tipo", "Eliminar"},
                                            New Object() {"@ID", id}
                                            }, Data.CommandType.StoredProcedure)

            Catch ex As Exception
                colocaError(ex)
            End Try



        End Sub

    End Class

End Namespace
