Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Catalogo_Categoria_BLL
        Inherits Base_BLL

        Public Shared Function insertar(ByVal query As String, ByVal ID As Integer, ByVal idCatalogo As Integer, ByVal Descripcion As String,
                                   ByVal vigente As String, ByVal extension As String) As Integer

            Dim TrSql As New TransacSQL
            Try
                '       Dim DtOrigin As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Catalogo_Actualiza", New Object() {
                '                                      New Object() {"@Tipo", query},
                '                                     New Object() {"@ID", ID},
                '                                    New Object() {"@Categoria_ID", idCatalogo},
                '                                   New Object() {"@Descripcion", Descripcion},
                '                                  New Object() {"@Ext", extension},
                '                                 New Object() {"@Estado", vigente}
                '                                }, CommandType.StoredProcedure).Tables(0)

                Return Integer.Parse(New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Catalogo_Actualiza", New Object() {
                                               New Object() {"@Tipo", query},
                                               New Object() {"@ID", ID},
                                               New Object() {"@Categoria_ID", idCatalogo},
                                               New Object() {"@Descripcion", Descripcion},
                                               New Object() {"@Ext", extension},
                                               New Object() {"@Estado", vigente}
                                               }, CommandType.StoredProcedure).Tables(0).Rows(0).Item(0))

            Catch ex As Exception
                colocaError(ex)
            End Try

        End Function



        Public Shared Sub eliminar(ByVal id As Integer)
            MsjError = Nothing
            Dim TrSql As New TransacSQL
            Try
                TrSql.EjecutarActualizacion("TranscoldPruebas", "Pru_Catalogo_Actualiza", New Object() {
                                            New Object() {"@Tipo", "Eliminar"},
                                            New Object() {"@ID", id}
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

    End Class

End Namespace
