Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Componentes_Compresor_BLL
        Inherits Base_BLL

        Public Shared Sub crudComponente(ByVal query As String,
                                       ByVal Voltaje As String,
                                        ByVal Codigo As String,
                                        ByVal Compresor As String,
                                        ByVal Caballaje As String,
                                        ByVal Relay As String,
                                        ByVal Protector As String,
                                        ByVal Capacitor As String,
                                        ByVal ID As Int32
                                          )
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Compresor_Componentes_ABCD", New Object() {
                                                New Object() {"@query", query.TrimEnd},
                                                       New Object() {"@Voltaje", Voltaje},
                                                        New Object() {"@CodigoComp", Codigo},
                                                         New Object() {"@Compresor", Compresor},
                                                          New Object() {"@Caballaje", Caballaje},
                                                          New Object() {"@Relay", Relay},
                                                          New Object() {"@Protector", Protector},
                                                          New Object() {"@Capacitor", Capacitor},
                                                           New Object() {"@ID", ID}
                                                  }, Data.CommandType.StoredProcedure)
            Catch ex As Exception

                colocaError(ex)
            End Try

        End Sub


        Public Shared Function consultar(ByVal query As String,
                               ByVal Voltaje As String,
                                ByVal Codigo As String,
                                ByVal Compresor As String,
                                ByVal Caballaje As String,
                                ByVal Relay As String,
                                ByVal Protector As String,
                                ByVal Capacitor As String,
                                ByVal ID As Int32
                                  ) As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Compresor_Componentes_ABCD", New Object() {
                                                New Object() {"@query", query.TrimEnd},
                                                       New Object() {"@Voltaje", Voltaje},
                                                        New Object() {"@CodigoComp", Codigo},
                                                         New Object() {"@Compresor", Compresor},
                                                          New Object() {"@Caballaje", Caballaje},
                                                          New Object() {"@Relay", Relay},
                                                          New Object() {"@Protector", Protector},
                                                          New Object() {"@Capacitor", Capacitor},
                                                           New Object() {"@ID", ID}
                                                  }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception

                colocaError(ex)
            End Try

        End Function





    End Class

End Namespace

