Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Validacion_BLL
        Inherits Base_BLL

        Public Shared Function insertar(ByVal query As String,
                                        ByVal ID As Int32,
                                        ByVal filtro1 As String,
                                        ByVal Id_Catalogo As Int32,
                                        ByVal Id_Instrumento As Int32,
                                        ByVal codigo As String,
                                         ByVal comentarios As String,
                                         ByVal tecnico As String,
                                         ByVal tipo As String,
                                         ByVal p1 As Double,
                                        ByVal p2 As Double,
                                        ByVal p3 As Double,
                                        ByVal p4 As Double,
                                        ByVal p5 As Double,
                                        ByVal p6 As Double,
                                        ByVal p7 As Double,
                                        ByVal p8 As Double,
                                        ByVal p9 As Double) As String
            MsjError = "Realizado"
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Verificacion_ABCD", New Object() {
                                                New Object() {"@query", query.TrimEnd},
                                                New Object() {"@Id_Catalogo", Id_Catalogo},
                                                 New Object() {"@Id_Instrumento", Id_Instrumento},
                                                  New Object() {"@Codigo", codigo.TrimEnd},
                                                  New Object() {"@ID", ID},
                                                   New Object() {"@P1", p1},
                                                    New Object() {"@P2", p2},
                                                     New Object() {"@P3", p3},
                                                      New Object() {"@P4", p4},
                                                       New Object() {"@P5", p5},
                                                        New Object() {"@P6", p6},
                                                         New Object() {"@P7", p7},
                                                          New Object() {"@P8", p8},
                                                           New Object() {"@P9", p9},
                                                            New Object() {"@Comentario", comentarios.TrimEnd},
                                                             New Object() {"@Tecnico", tecnico},
                                                              New Object() {"@TipoEntrada", tipo.TrimEnd}
                                                  }, Data.CommandType.StoredProcedure)

            Catch ex As Exception
                Return ex.ToString '
                colocaError(ex)
            End Try
            Return MsjError
        End Function


        Public Shared Function eliminar(ByVal ID As Int32) As String
            MsjError = "Realizado"
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Verificacion_ABCD", New Object() {
                                                New Object() {"@query", "eliminar"},
                                                New Object() {"@ID", ID}
                                                  }, Data.CommandType.StoredProcedure)

            Catch ex As Exception

                colocaError(ex)
            End Try
            Return MsjError
        End Function


    End Class

End Namespace

