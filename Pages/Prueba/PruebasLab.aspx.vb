Public Class PruebasLab
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            llenarEncabezados()

            '2022/05/03 21:30
            'D:\lmpv\
            '22-0024-240422-1100-2600-3232 
            '  XX-XXXX: Código de solicitud 

            'DDMMYY:     Día, mes y año de inicio de prueba 

            'HHMM:       Hora inicial de consulta 

            'hhmm:       Tiempo de evaluación 

            'HHmm:       Tiempo de cursor 
            If Not Request.QueryString("Codigo") Is Nothing Then
                tbFecha.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm")
                If (Not Request.QueryString("Fecha") Is Nothing) Then

                    tbFecha.Text = Request.QueryString("Fecha")
                End If
                If (Not Request.QueryString("Dias") Is Nothing) Then
                    tbDias.Text = Request.QueryString("Dias")

                End If
                tbCodigo.Text = Request.QueryString("Codigo")
                hfCodigo.Value = tbCodigo.Text

                informacionPrincipal(tbCodigo.Text)
                    llenarEncabezados()
                    tbTipo.Text = "1"
                ElseIf Not Request.QueryString("CodigoSol") Is Nothing Then

                    tbCodigo.Text = Request.QueryString("CodigoSol")

                tbFecha.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm")

                Dim fechaHora1 As String = ""
                fechaHora1 = "20" + tbCodigo.Text().Substring(12, 2) + "/" + tbCodigo.Text().Substring(10, 2) + "/" + tbCodigo.Text().Substring(8, 2) + " " + tbCodigo.Text().Substring(15, 2) + ":" + tbCodigo.Text().Substring(17, 2)
                tbFecha.Text = fechaHora1
                llenarEncabezados()
                Try
                    informacionPrincipal(tbCodigo.Text.Substring(0, 6).Replace("-", "/"))
                    hfCodigo.Value = tbCodigo.Text.Substring(0, 6).Replace("-", "/")
                Catch ex As Exception

                End Try

                tbTipo.Text = "2"
            End If



            fichaTecnica()

        End If
    End Sub

    Private Sub llenarEncabezados()


        Dim DTOrig As DataRow = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Catalogo_Actualiza", New Object() {
                                                                    New Object() {"@Tipo", "Ruta"}
                                                                    }, CommandType.StoredProcedure).Tables(0).Rows(0)

        tbRuta.Text = DTOrig.Item(0)


    End Sub

    Private Function limites(codigo) As String



        Try
            '   Dim DTOrig As DataRow = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Pru_Reporte_LineaTiempo", New Object() {
            '                                                       New Object() {"@CualRep", "Limites"},
            '                                                     New Object() {"@Codigo", codigo},
            '                                                     New Object() {"@Rango_Inicio", tbFecha.Text}
            '                                                   }, CommandType.StoredProcedure).Tables(0).Rows(0)

            Dim retorno As String = "const limiteMinimo=0;  const limitePromedio=3.3; const limiteMaximo=7.2;"
            Dim limiteComa As String() = hfLimites.Value().ToString.Split(",")
            Dim validacion As Int32 = 0
            validacion = Int32.Parse(limiteComa(0))
            validacion = Int32.Parse(limiteComa(1)) + validacion
            validacion = Int32.Parse(limiteComa(2)) + validacion

            retorno = "const limiteMinimo=" + limiteComa(0) + ";  const limitePromedio=" + limiteComa(1) + "; const limiteMaximo=" + limiteComa(2) + ";"
            Return retorno
        Catch ex As Exception
            Return "const limiteMinimo=0;  const limitePromedio=3.3; const limiteMaximo=7.2;"
        End Try


    End Function

    Private Function informacionPrincipal(ByVal codigo As String)
        Try
            Dim DTOrig As DataRow = New TransacSQL().EjecutarConsulta("TranscoldPruebas", "Select Codigo,Fecha_Creacion,Usuario_Creacion,Modelo,Objetivos,Serie,WO from Pru_Solicitud_Enc_Historico where Codigo=@Codigo", New Object() {
                                                                            New Object() {"@Codigo", codigo}
                                                                            }, CommandType.Text).Tables(0).Rows(0)

            tbModelo.Text = DTOrig.Item(3)
            tbSerie.Text = DTOrig.Item(5)
        Catch ex As Exception

        End Try



    End Function

    Private Sub fichaTecnica()
        Dim clsC = New DLL2.modelos.consultasExternas()
        Try
            Dim fichaTec As String() = clsC.especificacionesNombre(hfCodigo.Value, tbFecha.Text + ":00").Split("|")
            For index As Integer = 0 To fichaTec.Length - 1 Step 1
                tbFicha.Text = tbFicha.Text + fichaTec(index)

            Next
            hfLimites.Value = tbFicha.Text().Split(":")(tbFicha.Text().Split(":").Length - 1)

        Catch ex As Exception

        End Try
    End Sub


    Public Function labTestConsulta() As String
        Try

            Dim clsM As DLL2.metodos = New DLL2.metodos()
            Dim fase1 As String(,)

            If tbTipo.Text.Equals("1") Then
                fase1 = clsM.LabPruebasActivasWeb(tbCodigo.Text, tbRuta.Text, tbDias.Text, tbFecha.Text)
                Return metodoProceamiento(fase1)
            ElseIf tbTipo.Text.Equals("2") Then
                fase1 = clsM.LabPruebasReportes(tbCodigo.Text, tbFecha.Text, tbRuta.Text, 3)
                Return metodoProceamiento(fase1)
            End If


        Catch ex As Exception
            Return ""
        End Try

    End Function

    Private Function metodoProceamiento(ByVal fase1 As String(,)) As String
        Dim Aleatorios As Random = New Random()

        Dim minimo As Double = 100.0
        Dim maxima As Double = -100.0
        Dim promedio As Double = 0.0
        Dim indiceProducto As Integer = 0
        Dim suma As Double = 0.0
        Dim valor As Double = 0.0
        Dim tipoProducto As Integer = 0

        Dim retorno((fase1.GetLength(1)), (5)) As String

        Dim retornoColumna As String = ""

        Dim grupos(9, 2) As String
        Dim indexGrupo As Integer
        Dim indexGrupoAmperios As Integer
        Dim retornoReal As String = ""
        Dim retornoLabel As String = ""
        Dim guardarCantidadProducto As Integer = 0
        Dim horaInicio As String = ""
        retornoLabel = retornoLabel + "const labels = ["

        'horas
        Dim horaS As Integer = 0
        Dim minutosS As Date
        minutosS = "#00:00:00#"



        ''Columnas
        For indexa As Integer = 0 To fase1.GetLength(0) - 10 Step 1







            If (indexa > 4) Then



                Dim ceros As String = ""
                Dim ceross As String = ""

                If (Minute(minutosS) < 10) Then
                    ceros = "0"
                Else
                    ceros = ""
                End If
                If (horaS < 10) Then
                    ceross = "0"
                End If
                retornoLabel = retornoLabel + "'" + Hour(minutosS).ToString() + ":" + ceros + Minute(minutosS).ToString() + "',"

                minutosS = minutosS.AddMinutes(0.5)
                If (Minute(minutosS) = 59 And Second(minutosS) = 0) Then
                    horaS = horaS + 1
                End If

            End If

            ''Filas
            tipoProducto = 0

            minimo = 100
            maxima = -100
            suma = 0
            Dim fechaTemporal = fase1(1, fase1.GetLength(1) - 1).Split(" ")(0).Split("-")
            horaInicio = fechaTemporal(1) + "-" + fechaTemporal(0) + "-" + fechaTemporal(2) + " " + fase1(1, fase1.GetLength(1) - 1).Split(" ")(1)
            For indexb As Integer = 0 To fase1.GetLength(1) - 2 Step 1

                retornoColumna = fase1(0, indexb) + ","


                If (indexa < 4) Then
                    '14-16-2022
                    '   horaInicio =
                    retorno(indexb, 0) = fase1(2, indexb) 'Nombre
                    retorno(indexb, 1) = fase1(0, indexb)  'indice
                    retorno(indexb, 2) = fase1(0, indexb)
                    retorno(indexb, 4) = fase1(3, indexb) 'Participa,promedio



                    'Validar participacion en promedio



                Else
                    '     If (Integer.Parse(fase1(0, indexb)) >= 1 And Integer.Parse(fase1(0, indexb)) <= 216) Then
                    '    valor = CDbl(fase1(indexa, indexb).Replace(".", ","))
                    '   suma = suma + valor
                    '
                    '  If (valor <= minimo) Then
                    '     minimo = valor
                    '  End If
                    '   If (valor >= maxima) Then
                    '        maxima = valor
                    '     End If
                    '      retorno(indexb, 3) = retorno(indexb, 3) + fase1(indexa, indexb) + ","
                    '    Else
                    retorno(indexb, 3) = retorno(indexb, 3) + fase1(indexa, indexb) + ","
                    ' retorno(indexb, 5) = retorno(indexb, 5) + "'" + fase1(indexa, fase1.GetLength(1) - 1) + "',"
                    '    End If

                End If




            Next

            '            If (indexa > 3) Then
            '           promedio = (suma / guardarCantidadProducto)
            '          retorno(indiceProducto, 3) = retorno(indiceProducto, 3) + "" + minimo.ToString.Replace(",", ".") + ","
            '         retorno(indiceProducto + 1, 3) = retorno(indiceProducto + 1, 3) + "" + promedio.ToString.Replace(",", ".") + ","
            '        retorno(indiceProducto + 2, 3) = retorno(indiceProducto + 2, 3) + "" + maxima.ToString.Replace(",", ".") + ","

            '  End If


        Next
        Dim colorHex As String = ""
        Dim mapaValores As String = ""
        For indexd As Integer = 0 To retorno.GetLength(0) - 3 Step 1


            mapaValores = mapaValores + "{ indexx:'" + (retorno(indexd, 1)) + "', participa:'" + (retorno(indexd, 4)) + "', nombre:'" + (retorno(indexd, 0)) + "', data:[" + retorno(indexd, 3) + "]},"
            If (Integer.Parse(retorno(indexd, 1)) = 385) Then
                indexGrupoAmperios = 5

            Else
                indexGrupoAmperios = 0
                '       indexGrupo = 0
            End If
            If Integer.Parse(retorno(indexd, 1)) = 218 Or Integer.Parse(retorno(indexd, 1)) = 220 Or Integer.Parse(retorno(indexd, 1)) = 222 Or Integer.Parse(retorno(indexd, 1)) = 222 Or Integer.Parse(retorno(indexd, 1)) = 224 Then
                '217*239
                indexGrupo = 1
            ElseIf Integer.Parse(retorno(indexd, 1)) = 394 Then
                indexGrupo = 4
            ElseIf Integer.Parse(retorno(indexd, 1)) = 395 Then
                indexGrupo = 7
            ElseIf Integer.Parse(retorno(indexd, 1)) = 240 Or Integer.Parse(retorno(indexd, 1)) = 242 Or Integer.Parse(retorno(indexd, 1)) = 244 Or Integer.Parse(retorno(indexd, 1)) = 222 Or Integer.Parse(retorno(indexd, 1)) = 246 Then
                indexGrupo = 1
            ElseIf Integer.Parse(retorno(indexd, 1)) = 237 Or Integer.Parse(retorno(indexd, 1)) = 238 Then
                indexGrupo = 2
            ElseIf Integer.Parse(retorno(indexd, 1)) = 259 Or Integer.Parse(retorno(indexd, 1)) = 260 Then
                indexGrupo = 2
            ElseIf Integer.Parse(retorno(indexd, 1)) >= 501 And Integer.Parse(retorno(indexd, 1)) <= 503 Then
                indexGrupo = 3
            ElseIf Integer.Parse(retorno(indexd, 1)) >= 384 And Integer.Parse(retorno(indexd, 1)) <= 387 Or Integer.Parse(retorno(indexd, 1)) = 391 Then
                indexGrupo = 8


            Else

                indexGrupo = 0
                '  indexGrupoAmperios = 0

            End If



            If (indexGrupo > 0) Then



                colorHex = ""

                ' retornoLabel = retornoLabel + hora + ","
                For indexe As Integer = 0 To 3 Step 1
                    colorHex = "" + generarLetra()
                    Select Case indexe
                        Case 0
                            grupos(indexGrupo, 0) = grupos(indexGrupo, 0) + "{ label: '" + retorno(indexd, 0) + "',"
                            If (indexGrupoAmperios = 5) Then
                                grupos(indexGrupoAmperios, 0) = grupos(indexGrupoAmperios, 0) + "  { label: '" + retorno(indexd, 0) + "',"

                            End If


                           ' retornoReal = retornoReal + "{ label: '" + retorno(indexd, 0) + "',"
                        Case 1
                            ' retornoReal = retornoReal + " borderColor: '#" + colorHex + "',"
                            grupos(indexGrupo, 0) = grupos(indexGrupo, 0) + "  borderColor: '#" + colorHex + "',"
                            grupos(indexGrupo, 0) = grupos(indexGrupo, 0) + "  backgroundColor: '#" + colorHex + "',"
                            grupos(indexGrupo, 0) = grupos(indexGrupo, 0) + "  pointStyle: 'Circle',pointRadius: 1,"
                            grupos(indexGrupo, 0) = grupos(indexGrupo, 0) + "  backgroundColor: '#" + colorHex + "',"
                            If (indexGrupoAmperios = 5) Then
                                grupos(indexGrupoAmperios, 0) = grupos(indexGrupoAmperios, 0) + "  borderColor: '#" + colorHex + "',"
                                grupos(indexGrupoAmperios, 0) = grupos(indexGrupoAmperios, 0) + "  backgroundColor: '#" + colorHex + "',"
                                grupos(indexGrupoAmperios, 0) = grupos(indexGrupoAmperios, 0) + "  pointStyle: 'Circle',pointRadius: 1,"
                                grupos(indexGrupoAmperios, 0) = grupos(indexGrupoAmperios, 0) + "  backgroundColor: '#" + colorHex + "',"

                            End If


                        Case 2
                            grupos(indexGrupo, 0) = grupos(indexGrupo, 0) + "  data: [" + retorno(indexd, 3) + "]},"
                            ' grupos(indexGrupo, 0) = grupos(indexGrupo, 0) + "  cursorTiempo: [" + retorno(indexd, 5) + "]},"
                            If (indexGrupoAmperios = 5) Then
                                grupos(indexGrupoAmperios, 0) = grupos(indexGrupoAmperios, 0) + "  data: [" + retorno(indexd, 3) + "]},"

                            End If

                        '   retornoReal = retornoReal + "  data: [" + retorno(indexd, 3) + "]},"
                        Case 3



                    End Select

                Next
            End If

        Next

        retornoLabel = retornoLabel + "]; "
        '"datasets: ["
        For indexf As Integer = 0 To grupos.GetLength(0) - 1 Step 1
            grupos(indexf, 0) = "datasets: [" + grupos(indexf, 0) + "]"
            retornoReal = retornoReal + "const data" + indexf.ToString + " = { labels : labels," + grupos(indexf, 0) + "};"
        Next

        'retornoLabel = retornoLabel + "], "
        retornoReal = retornoLabel + retornoReal
        Dim cadena As String = "datasets: [{label:'Minimo',nombreU:[],  borderColor: '#00AAFF', backgroundColor: '#00AAFF',pointStyle: 'Circle',pointRadius: 1,backgroundColor:'#00AAFF', data: [0,0]},"
        cadena = cadena + "{label:'Promedio', nombreU:[], borderColor: '#FFC100',backgroundColor:'#FFC100',pointStyle: 'Circle',pointRadius: 1,backgroundColor:'#FFC100',data: [0,0]},"
        cadena = cadena + "{label:'Maxima', nombreU:[], borderColor: '#FF0000',backgroundColor:'#FF0000',pointStyle: 'Circle',pointRadius: 1,backgroundColor:'#FF0000',data: [0,0]}]"
        retornoReal = retornoReal + "const data10 = {labesl:labels," + cadena + "};"
        retornoReal = retornoReal + " const indicesTermopares = [" + mapaValores + "];" + " const horaInicio ='" + horaInicio + "';" + limites(hfCodigo.Value)

        '' const data = {

        ''};
        Return retornoReal
    End Function

    Private Function generarLetra() As String
        Dim Aleatorios As Random = New Random()
        Dim letras() As String = {"a", "b", "c", "d", "e", "f", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
        Dim retorno As String = ""
        For indexf As Integer = 0 To 5 Step 1
            retorno = retorno + letras(Aleatorios.Next(15))
        Next
        System.Threading.Thread.Sleep(1) ' 1 segundo
        Return retorno

    End Function

    Private Sub ObtieneProductTemperatures(ByRef dt As DataTable)
        For fila As Integer = 1 To gvFilas.Rows.Count
            Dim row As GridViewRow = gvFilas.Rows(fila - 1)
            Dim repColumnas As Repeater = row.FindControl("repColumnas")
            For col As Integer = 1 To repColumnas.Items.Count
                Dim tblPosicion As HtmlTable = repColumnas.Items(col - 1).FindControl("tblPosicion")
                Dim hfPosicion As HiddenField = tblPosicion.FindControl("hfPosicion")
                Dim chbParticipaProm As CheckBox = tblPosicion.FindControl("chbParticipaProm")
                Dim tbNumCanal As TextBox = tblPosicion.FindControl("tbNumCanal")
                dt.Rows.Add(hfPosicion.Value, tbNumCanal.Text, chbParticipaProm.Checked, "", Nothing)
            Next
        Next
    End Sub

    Protected Sub gvFilas_PreRender(sender As Object, e As EventArgs) Handles gvFilas.PreRender
        For rowIndex As Integer = 0 To gvFilas.Rows.Count - 1
            Dim row As GridViewRow = gvFilas.Rows(rowIndex)
            row.BorderColor = Drawing.Color.Transparent

            If rowIndex = 0 Then
                row.Style("border-top") = "black"
            End If

            If (rowIndex + 1) Mod 3 = 0 Then
                row.Style("border-bottom") = "black"
            End If

            For Each cell As TableCell In row.Cells
                cell.Style("padding") = "0px"
            Next
        Next
    End Sub
    Protected Sub dsTermoparFila_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs) Handles dsTermoparFila.Selecting
        Dim dt As New DataTable
        dt.Columns.Add("fila", GetType(Integer))
        dt.Columns.Add("fila_de_3", GetType(String))
        For i As Integer = 1 To 24
            dt.Rows.Add(i, IIf((i - 2) Mod 3 = 0, 9 - ((i - 2) / 3 + 1), ""))
        Next
        e.InputParameters("dt") = dt
    End Sub

    Protected Sub repColumnas_PreRender(sender As Object, e As EventArgs)
        Dim repColumnas As Repeater = sender
        For colIndex As Integer = 0 To repColumnas.Items.Count - 1
            Dim col As RepeaterItem = repColumnas.Items(colIndex)
            Dim tblPosicion As HtmlTable = col.FindControl("tblPosicion")
            Dim hfPosicion As HiddenField = tblPosicion.FindControl("hfPosicion")
            Dim posicion As Integer = hfPosicion.Value

            If (posicion - 1) Mod 9 = 0 Then
                tblPosicion.Attributes("style") = "border-left: 1px solid black;"
            End If
            If (posicion - 1) Mod 3 = 0 Then
                tblPosicion.Rows(0).Cells(0).Attributes("style") = "padding-left: 5px;"
            End If
            If posicion Mod 3 = 0 Then
                tblPosicion.Attributes("style") = "border-right: 1px solid black;"
                tblPosicion.Rows(0).Cells(tblPosicion.Rows(0).Cells.Count - 1).Attributes("style") = "padding-right: 5px;"
            End If
        Next

    End Sub

    Protected Sub lbtnRefrescar_Click(sender As Object, e As EventArgs)
        Dim pruebas As String = tbFecha.Text.Replace("-", "/").Replace("T", " ")

        '2022/05/03 21:30
        If (cbTipo.Checked) Then
            If (tbFecha.Text.Length > 0) Then
                Response.Redirect("~/Pages/Prueba/PruebasLab.aspx?Codigo=" + tbCodigo.Text + "&Fecha=" + pruebas + "&Dias=" + tbDias.Text)

            End If
        Else
            Response.Redirect("~/Pages/Prueba/PruebasLab.aspx?Codigo=" + tbCodigo.Text + "&Dias=" + tbDias.Text)

        End If
    End Sub
End Class