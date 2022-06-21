Public Class webRepPruebas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub lbtnRefrescar_Click(sender As Object, e As EventArgs)

    End Sub

    Public Function datosPrueba() As String



        Return areaPruebas()
    End Function

    Private Function areaPruebas() As String

        Dim clsM As DLL2.metodos = New DLL2.metodos()

        clsM.labPruebasSCOAnalisi("", "111112078", "", "")
        Return clsM.LabPruebasSCO("", "111112078", "", "") + limites()
    End Function
    Private Function limites() As String



        Try
            '   Dim DTOrig As DataRow = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Reporte_LineaTiempo", New Object() {
            '                                                       New Object() {"@CualRep", "Limites"},
            '                                                     New Object() {"@Codigo", codigo},
            '                                                     New Object() {"@Rango_Inicio", tbFecha.Text}
            '                                                   }, CommandType.StoredProcedure).Tables(0).Rows(0)

            Dim retorno As String = "const limiteMinimo=0;   const limiteMaximo=7.2;"
            Dim limiteComa As String() = hfLimites.Value().ToString.Split(",")
            Dim validacion As Int32 = 0
            validacion = Int32.Parse(limiteComa(0))
            validacion = Int32.Parse(limiteComa(1)) + validacion

            retorno = "const limiteMinimo=" + limiteComa(0) + ";   const limiteMaximo=" + limiteComa(1) + ";"
            Return retorno
        Catch ex As Exception
            Return "const limiteMinimo=0;   const limiteMaximo=7.2;"
        End Try


    End Function
End Class