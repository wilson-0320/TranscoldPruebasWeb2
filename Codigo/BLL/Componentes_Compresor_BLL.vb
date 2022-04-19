Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Componentes_Compresor_BLL
        Inherits Base_BLL

        Public Shared Function insertar_modificar(ByVal query As String,
                                       ByVal Voltaje As String,
                                        ByVal Codigo As String,
                                        ByVal Compresor As String,
                                        ByVal Caballaje As String,
                                        ByVal Relay As String,
                                        ByVal Protector As String,
                                        ByVal Capacitor As String,
                                        ByVal ID As Int32
                                          ) As String
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Dim msj As String = trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Compresor_Componentes_ABCD", New Object() {
                                                New Object() {"@query", query.TrimEnd},
                                                       New Object() {"@Voltaje", Voltaje},
                                                        New Object() {"@CodigoComp", Codigo},
                                                         New Object() {"@Compresor", Compresor},
                                                          New Object() {"@Caballaje", Caballaje},
                                                          New Object() {"@Relay", Relay},
                                                          New Object() {"@Protector", Protector},
                                                          New Object() {"@Capacitor", Capacitor},
                                                           New Object() {"@ID", ID}
                                                  }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)
                Return msj '    Dim a As Int16 = ex + codigo
            Catch ex As Exception
                Return ex.ToString '
                ' colocaError(ex)
            End Try
        End Function


        Public Shared Function eliminar(ByVal ID As Integer) As String
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Dim msj As String = trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Compresor_Componentes_ABCD", New Object() {
                                                New Object() {"@query", "Eliminar"},
                                                           New Object() {"@ID", ID}
                                                  }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)
                Return msj '    Dim a As Int16 = ex + codigo
            Catch ex As Exception
                Return "Error:" + +ex.ToString '
                ' colocaError(ex)
            End Try
        End Function


    End Class

End Namespace

