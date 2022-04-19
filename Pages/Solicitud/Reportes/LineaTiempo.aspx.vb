Public Class LineaTiempo
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If Not Request.QueryString("Codigo") Is Nothing Then
                tbCodigo.Text = Request.QueryString("Codigo")


                cargarReportRepeatet("LineaTiempoIntegradoPruebas")


            End If



            Try
                Dim computer_name As String() = System.Net.Dns.GetHostEntry(Request.ServerVariables("remote_addr")).HostName.Split(New Char() {"."})
                tbComputadora.Text = computer_name(0).ToString()
            Catch ex As Exception
                tbComputadora.Text = "NoLeíble"
            End Try

        End If


    End Sub


    Private Sub cargarReportRepeatet(ByVal cualRep As String)

        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Reporte_LineaTiempo", New Object() {
                                                                    New Object() {"@Codigo", tbCodigo.Text},
                                                                    New Object() {"@CualRep", cualRep},
                                                                    New Object() {"@Rango_Inicio", 0},
                                                                    New Object() {"@Rango_Fin", 0},
                                                                    New Object() {"@minutos", 1440},
                                                                    New Object() {"@TiposRegistro", obtTiposReg()}
                                                                    }, CommandType.StoredProcedure).Tables(0)
        If (cualRep.Equals("LineaTiempoIntegradoPruebas")) Then
            repeaterReporte.DataSource = DTOrig
            repeaterReporte.DataBind()
        Else

        End If

    End Sub

    Private Function obtTiposReg() As String
        Dim l As New List(Of String)
        For Each li As ListItem In listOpciones.Items
            If li.Selected Then
                l.Add(li.Value)
            End If
        Next
        Return String.Join(",", l.ToArray)
    End Function

    Protected Sub btnGenerar_Click(sender As Object, e As EventArgs)
        If (tbCodigo.Text().Length > 0) Then


            cargarReportRepeatet("LineaTiempoIntegradoPruebas")

        Else
            MuestraErrorToast("", 0, True)


        End If
    End Sub
End Class