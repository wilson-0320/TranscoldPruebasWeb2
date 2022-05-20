Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Recepcion_BLL
        Inherits Base_BLL

        Public Shared Sub insertar(ByVal query As String,
                                       ByVal tipo As String,
                                        ByVal ID As Int32,
                                        ByVal cliente As String,
                                        ByVal pais As String,
                                        ByVal solicitado As String,
                                        ByVal wo As String,
                                        ByVal serie As String,
                                        ByVal modelo As String,
                                        ByVal codigo As String,
                                        ByVal parillas As Int32,
                                         ByVal clips As Int32,
                                         ByVal lamparas As Int32,
                                        ByVal rotulo As Boolean,
                                         ByVal cubremotor As Boolean,
                                         ByVal certificado As Boolean,
                                         ByVal etiquetaSerie As Boolean,
                                         ByVal manualOperacion As Boolean,
                                         ByVal manualIns As Boolean,
                                         ByVal calcomania As Boolean,
                                         ByVal diagrama As Boolean,
                                         ByVal funcionamiento As Boolean,
                                         ByVal parillaTrasera As Boolean,
                                         ByVal haladores As Boolean,
                                         ByVal golpes As String,
                                         ByVal rayones As String,
                                         ByVal comentarios As String,
                                         ByVal usuarioLaboratorio As String,
                                         ByVal usuarioDespachos As String
                                          )
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Dim msj As String = trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Recepcion_ABCD", New Object() {
                                                New Object() {"@query", query},
                                                New Object() {"@tipo", tipo.TrimEnd},
                                                New Object() {"@ID", ID},
                                                New Object() {"@cliente", cliente.TrimEnd},
                                                New Object() {"@pais", pais.TrimEnd},
                                                New Object() {"@solicitado", solicitado.TrimEnd},
                                                New Object() {"@wo", wo.TrimEnd},
                                                New Object() {"@serie", serie.TrimEnd},
                                                New Object() {"@modelo", modelo.TrimEnd},
                                                New Object() {"@codigo", codigo},
                                                New Object() {"@parillas", parillas},
                                                New Object() {"@clips", clips},
                                                New Object() {"@lamparas", lamparas},
                                                New Object() {"@rotulo", rotulo},
                                                New Object() {"@cubremotor", cubremotor},
                                                New Object() {"@certificado", certificado},
                                                New Object() {"@etiquetaSerie", etiquetaSerie},
                                                New Object() {"@manualOperacion", manualOperacion},
                                                New Object() {"@manualIns", manualIns},
                                                New Object() {"@calcomania", calcomania},
                                                 New Object() {"@diagrama", diagrama},
                                                  New Object() {"@funcionamiento", funcionamiento},
                                                   New Object() {"@parillaTrasera", parillaTrasera},
                                                   New Object() {"@haladores", haladores},
                                                    New Object() {"@golpes", golpes},
                                                     New Object() {"@rayones", rayones},
                                                      New Object() {"@comentarios", comentarios.TrimEnd},
                                                       New Object() {"@usuarioLaboratorio", usuarioLaboratorio.TrimEnd},
                                                       New Object() {"@usuarioDespachos", usuarioDespachos.TrimEnd}
                                                  }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)
                '    Dim a As Int16 = ex + codigo
            Catch ex As Exception

                colocaError(ex)
            End Try
        End Sub


    End Class

End Namespace

