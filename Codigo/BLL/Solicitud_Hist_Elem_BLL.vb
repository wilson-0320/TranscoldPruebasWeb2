Imports Microsoft.VisualBasic

Namespace BLL

    Public Class Solicitud_Hist_Elem_BLL
        Inherits Base_BLL

        Public Shared Sub ModificarValor(ID As Integer, Valor As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Pru_Solicitud_Hist_Elem_Actualiza", New Object() {
                                            New Object() {"@Tipo", "ModificarValor"},
                                            New Object() {"@ID", ID},
                                            New Object() {"@Valor", Valor}
                                        }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub


        Public Shared Function modificarEliminarHistorico(ByVal tipo As String, ByVal ID As Int32, ByVal Elemento_ID As Integer, ByVal Valor As String, ByVal Cantidad As String,
                       ByVal Precio As String, ByVal Comentario As String, ByVal EsExterno As Boolean, ByVal FechaEnviado As DateTime, ByVal FechaRevisado As DateTime) As String
            Dim TrSql As New TransacSQL
            Dim msj As String = TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Hist_Elem_Actualiza", New Object() {
                                   New Object() {"@Tipo", tipo},
                                   New Object() {"@ID", ID},
                                   New Object() {"@Elemento_ID", Elemento_ID},
                                   New Object() {"@Valor", Valor},
                                   New Object() {"@Cantidad", Cantidad},
                                   New Object() {"@Precio", Precio},
                                   New Object() {"@Comentario", Comentario},
                                   New Object() {"@EsExterno", EsExterno},
                                   New Object() {"@FechaEnviado", FechaEnviado},
                                   New Object() {"@FechaRevisado", FechaRevisado}}, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)
            '  New Object() {"@usuario", HttpContext.Current.User.Identity.Name} _

            Return msj
        End Function

    End Class

End Namespace
