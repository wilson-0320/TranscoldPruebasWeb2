Public Class PrubasLab
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function laboratorioTest() As String
        Dim Aleatorios As Random = New Random()
        Dim clsM As DLL2.metodos = New DLL2.metodos()
        Dim minimo As Double = 100.0
        Dim maxima As Double = -100.0
        Dim promedio As Double = 0.0
        Dim indiceProducto As Integer = 0
        Dim suma As Double = 0.0
        Dim valor As Double = 0.0
        Dim tipoProducto As Integer = 0


        Dim fase1 As String(,) = clsM.LabPruebasActivasWeb(tbCodigo.Text, tbRuta.Text, tbDias.Text, tbFecha.Text)
        '

        Dim retorno((fase1.GetLength(1)), (4)) As String
        Dim grupos(9, 2) As String
        Dim indexGrupo As Integer
        Dim indexGrupoAmperios As Integer
        Dim retornoReal As String = ""
        Dim retornoLabel As String = ""
        Dim guardarCantidadProducto As Integer = 0
        retornoLabel = retornoLabel + "const labels = ["
        ''Columnas
        For indexa As Integer = 0 To fase1.GetLength(0) - 2000 Step 1
            retornoLabel = retornoLabel + "'" + indexa.ToString + "',"
            ''Filas
            tipoProducto = 0

            minimo = 100
            maxima = -100
            suma = 0
            For indexb As Integer = 0 To fase1.GetLength(1) - 2 Step 1



                If (indexa < 4) Then
                    If (Integer.Parse(fase1(0, indexb)) >= 1 And Integer.Parse(fase1(0, indexb)) <= 216) Then
                        If (tipoProducto >= 0 And tipoProducto <= 2) Then
                            If (indiceProducto = 0) Then
                                indiceProducto = 0
                            End If

                            retorno(indiceProducto, 0) = "Minimo" 'Nombre
                            retorno(indiceProducto, 1) = "1"   'indice
                            retorno(indiceProducto, 2) = "------"
                            retorno(indiceProducto + 1, 0) = "Promedio" 'Nombre
                            retorno(indiceProducto + 1, 1) = "2"   'indice
                            retorno(indiceProducto + 1, 2) = "------"
                            retorno(indiceProducto + 2, 0) = "Maximo" 'Nombre
                            retorno(indiceProducto + 2, 1) = "3"   'indice
                            retorno(indiceProducto + 2, 2) = "------"


                        Else
                            retorno(indexb, 0) = fase1(2, indexb) 'Nombre
                            retorno(indexb, 1) = fase1(0, indexb)  'indice
                            retorno(indexb, 2) = fase1(indexa, fase1.GetLength(1) - 1)
                        End If





                        tipoProducto = tipoProducto + 1
                        guardarCantidadProducto = tipoProducto
                    Else
                        retorno(indexb, 0) = fase1(2, indexb) 'Nombre
                        retorno(indexb, 1) = fase1(0, indexb)  'indice
                        retorno(indexb, 2) = fase1(indexa, fase1.GetLength(1) - 1)
                    End If


                Else
                    If (Integer.Parse(fase1(0, indexb)) >= 1 And Integer.Parse(fase1(0, indexb)) <= 216) Then
                        valor = CDbl(fase1(indexa, indexb).Replace(".", ","))
                        suma = suma + valor

                        If (valor <= minimo) Then
                            minimo = valor
                        End If
                        If (valor >= maxima) Then
                            maxima = valor
                        End If

                    Else
                        retorno(indexb, 3) = retorno(indexb, 3) + fase1(indexa, indexb) + ","
                    End If

                End If




            Next

            If (indexa > 3) Then
                promedio = (suma / guardarCantidadProducto)
                retorno(indiceProducto, 3) = retorno(indiceProducto, 3) + "" + minimo.ToString.Replace(",", ".") + ","
                retorno(indiceProducto + 1, 3) = retorno(indiceProducto + 1, 3) + "" + promedio.ToString.Replace(",", ".") + ","
                retorno(indiceProducto + 2, 3) = retorno(indiceProducto + 2, 3) + "" + maxima.ToString.Replace(",", ".") + ","

            End If


        Next
        Dim colorHex As String = ""
        'labels: labels,

        ' retornoReal = retornoReal + "datasets: ["
        Dim hora As Double = 0
        '6
        For indexd As Integer = 0 To retorno.GetLength(0) - 4 Step 1

            If (Integer.Parse(retorno(indexd, 1)) = 385) Then
                indexGrupoAmperios = 5
            Else
                indexGrupoAmperios = 0
            End If
            If Integer.Parse(retorno(indexd, 1)) >= 217 And Integer.Parse(retorno(indexd, 1)) <= 224 Or Integer.Parse(retorno(indexd, 1)) >= 226 And Integer.Parse(retorno(indexd, 1)) <= 227 Or Integer.Parse(retorno(indexd, 1)) = 232 Then
                indexGrupo = 1
            ElseIf Integer.Parse(retorno(indexd, 1)) = 395 Then
                indexGrupo = 7
            ElseIf Integer.Parse(retorno(indexd, 1)) >= 239 And Integer.Parse(retorno(indexd, 1)) <= 246 Or Integer.Parse(retorno(indexd, 1)) >= 248 And Integer.Parse(retorno(indexd, 1)) <= 249 Or Integer.Parse(retorno(indexd, 1)) = 254 Then
                indexGrupo = 3
            ElseIf Integer.Parse(retorno(indexd, 1)) = 237 Or Integer.Parse(retorno(indexd, 1)) = 238 Then
                indexGrupo = 2
            ElseIf Integer.Parse(retorno(indexd, 1)) = 259 Or Integer.Parse(retorno(indexd, 1)) = 260 Then
                indexGrupo = 4
            ElseIf Integer.Parse(retorno(indexd, 1)) >= 1 And Integer.Parse(retorno(indexd, 1)) <= 3 Then
                indexGrupo = 5
            ElseIf Integer.Parse(retorno(indexd, 1)) >= 384 And Integer.Parse(retorno(indexd, 1)) <= 391 Then
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
                            If (indexGrupo = 5) Then
                                grupos(indexGrupo, 0) = grupos(indexGrupo, 0) + "  yAxisID: 'y',"
                            ElseIf (indexGrupoAmperios = 5) Then
                                grupos(indexGrupoAmperios, 0) = grupos(indexGrupoAmperios, 0) + "  borderColor: '#" + colorHex + "',"
                                grupos(indexGrupoAmperios, 0) = grupos(indexGrupoAmperios, 0) + "  backgroundColor: '#" + colorHex + "',"
                                grupos(indexGrupoAmperios, 0) = grupos(indexGrupoAmperios, 0) + "  pointStyle: 'Circle',pointRadius: 1,"
                                grupos(indexGrupoAmperios, 0) = grupos(indexGrupoAmperios, 0) + "  backgroundColor: '#" + colorHex + "',"
                                grupos(indexGrupoAmperios, 0) = grupos(indexGrupoAmperios, 0) + "  yAxisID: 'y1',"
                            Else

                            End If
                            ' retornoReal = retornoReal + " borderColor: '#" + colorHex + "',"
                            ' retornoReal = retornoReal + "  backgroundColor: '#" + colorHex + "',"
                            ' retornoReal = retornoReal + "  pointStyle: 'Circle',pointRadius: 1,"
                           ' retornoReal = retornoReal + "  backgroundColor: '#" + colorHex + "',"

                        Case 2
                            grupos(indexGrupo, 0) = grupos(indexGrupo, 0) + "  data: [" + retorno(indexd, 3) + "]},"
                            If (indexGrupoAmperios = 5) Then
                                grupos(indexGrupoAmperios, 0) = grupos(indexGrupoAmperios, 0) + "  data: [" + retorno(indexd, 3) + "]},"

                            End If

                        '   retornoReal = retornoReal + "  data: [" + retorno(indexd, 3) + "]},"
                        Case 3



                    End Select

                Next
            End If
            hora = hora + 0.5
        Next
        retornoLabel = retornoLabel + "]; "
        '"datasets: ["
        For indexf As Integer = 0 To grupos.GetLength(0) - 1 Step 1
            grupos(indexf, 0) = "datasets: [" + grupos(indexf, 0) + "]"
            retornoReal = retornoReal + "const data" + indexf.ToString + " = { labels : labels," + grupos(indexf, 0) + "};"
        Next

        'retornoLabel = retornoLabel + "], "
        retornoReal = retornoLabel + retornoReal
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

End Class