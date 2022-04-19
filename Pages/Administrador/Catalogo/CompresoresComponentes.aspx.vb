Public Class CompresoresComponentes
    Inherits MiPageN

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                inicializar()
                cargarRepeaterCompresorComponentes("Consultar", 0)

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub inicializar()
        tbCaballaje.Text = ""
        tbCodigoComp.Text = ""
        tbCompresor.Text = ""
        tbVoltaje.Text = ""
        tbRelay.Text = ""
        tbProtectorTermico.Text = ""
        tbCapacitor.Text = ""
        hfID.Value = "-1"
        hfQuery.Value = "Insertar"
        lbtnGuardar.Enabled = Roles("Administrador", 1)
        lbtnCancelar.Visible = False
    End Sub

    Private Function validarCrud() As Boolean

        For Each CampoTexto As TextBox In New TextBox() {
            tbVoltaje, tbCompresor, tbCaballaje, tbCapacitor, tbCodigoComp, tbRelay
            }

            If CampoTexto.Text = "" Then
                MuestraErrorToast("Debe especificar el valor del campo " + CampoTexto.ToolTip, 3, True)
                Return False
            End If


        Next
        Return True

    End Function


    Protected Sub lbtnGuardar_Click(sender As Object, e As EventArgs)
        If (validarCrud()) Then
            BLL.Componentes_Compresor_BLL.insertar_modificar(hfQuery.Value, tbVoltaje.Text, tbCodigoComp.Text, tbCompresor.Text,
tbCaballaje.Text, tbRelay.Text, tbProtectorTermico.Text, tbCapacitor.Text, hfID.Value)
            inicializar()
            cargarRepeaterCompresorComponentes("Consultar", 0)
            MuestraErrorToast("Listo", 1, True)
        End If
    End Sub

    Protected Sub lbtnCancelar_Click(sender As Object, e As EventArgs)
        inicializar()
        MuestraErrorToast("", 0, True)
    End Sub

    Private Sub cargarRepeaterCompresorComponentes(ByVal quer As String, ByVal ID As Integer)
        Dim DTOrig As DataTable = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Compresor_Componentes_ABCD", New Object() {
                                                                New Object() {"@query", quer.TrimEnd},
                                                                New Object() {"@ID", ID}
                                                                }, CommandType.StoredProcedure).Tables(0)

        If (quer.TrimEnd.Equals("Consultar")) Then
            repeaterComponentes.DataSource = DTOrig
            repeaterComponentes.DataBind()
        Else
            hfID.Value = DTOrig.Rows(0).Item(0)
            tbVoltaje.Text = DTOrig.Rows(0).Item(1).ToString.TrimEnd
            tbCodigoComp.Text = DTOrig.Rows(0).Item(2).ToString.TrimEnd
            tbCompresor.Text = DTOrig.Rows(0).Item(3).ToString.TrimEnd
            tbCaballaje.Text = DTOrig.Rows(0).Item(4).ToString.TrimEnd
            tbRelay.Text = DTOrig.Rows(0).Item(5).ToString.TrimEnd
            tbProtectorTermico.Text = DTOrig.Rows(0).Item(6).ToString.TrimEnd
            tbCapacitor.Text = DTOrig.Rows(0).Item(7).ToString.TrimEnd
        End If
    End Sub

    Protected Sub repeaterComponentes_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If (e.CommandName = "Eli" And Roles("Administrador", 3)) Then
            BLL.Componentes_Compresor_BLL.eliminar((Integer.Parse(e.CommandArgument)))
            cargarRepeaterCompresorComponentes("Consultar", Integer.Parse(hfID.Value))
            MuestraErrorToast("Listo", 1, True)
        ElseIf (e.CommandName = "Edit") Then
            hfID.Value = (e.CommandArgument)
            hfQuery.Value = "Actualizar"
            lbtnCancelar.Visible = True
            lbtnGuardar.Enabled = Roles("Administrador", 2)
            cargarRepeaterCompresorComponentes("Consultar_por_id", Integer.Parse(hfID.Value))
            MuestraErrorToast("", 0, True)
        End If
    End Sub

End Class