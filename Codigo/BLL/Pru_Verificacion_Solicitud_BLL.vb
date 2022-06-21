Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Pru_Verificacion_Solicitud_BLL
        Inherits Base_BLL

        Public Shared Sub crud(ByVal query As String,
                                        ByVal ID As Int32,
                                        ByVal Id_Ubicacion As Int32,
                                        ByVal Id_Instrumento As Int32,
                                        ByVal codigo As String,
                                         ByVal comentarios As String,
                                         ByVal tecnico As String,
                                         ByVal Id_Magnitud As Integer,
                                         ByVal p1 As Decimal,
                                        ByVal p2 As Decimal,
                                        ByVal p3 As Decimal,
                                        ByVal p4 As Decimal)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Verificacion_Solicitud_ABCD", New Object() {
                                                New Object() {"@query", query.TrimEnd},
                                                New Object() {"@ID_Ubicacion", Id_Ubicacion},
                                                 New Object() {"@Id_Instrumento", Id_Instrumento},
                                                  New Object() {"@Codigo", codigo.TrimEnd},
                                                  New Object() {"@ID", ID},
                                                   New Object() {"@P1", p1.ToString.TrimEnd},
                                                    New Object() {"@P2", p2.ToString.TrimEnd},
                                                     New Object() {"@P3", p3.ToString.TrimEnd},
                                                      New Object() {"@P4", p4.ToString.TrimEnd},
                                                            New Object() {"@Comentario", comentarios.TrimEnd},
                                                             New Object() {"@Tecnico", tecnico},
                                                              New Object() {"@ID_Magnitud", Id_Magnitud}
                                                  }, Data.CommandType.StoredProcedure)

            Catch ex As Exception

                colocaError(ex)
            End Try

        End Sub


        Public Shared Sub eliminar(ByVal ID As Int32)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Verificacion_Solicitud_ABCD", New Object() {
                                                New Object() {"@query", "Eliminar"},
                                                New Object() {"@ID", ID}
                                                  }, Data.CommandType.StoredProcedure)

            Catch ex As Exception

                colocaError(ex)
            End Try

        End Sub





    End Class

End Namespace

