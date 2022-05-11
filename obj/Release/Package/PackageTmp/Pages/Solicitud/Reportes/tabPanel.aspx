<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/Menu.Master" CodeBehind="tabPanel.aspx.vb" Inherits="TranscoldPruebasWeb2.tabPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
    <script>
        google.charts.load('current', { 'packages': ['line', 'corechart'] });
        google.charts.setOnLoadCallback(drawChart);
        function drawChart() {
       
            var button = document.getElementById('change-chart');
            var chartDiv = document.getElementById('chart_div');

            var data = new google.visualization.DataTable();
            data.addColumn('number', 'Minutos');
            data.addColumn('number', "Temperatura");
            data.addColumn('number', "Humedad");

            data.addRows(<%=datos2()%>);


            var materialOptions = {
                chart: {
                    title: 'Average Temperatures and Daylight in Iceland Throughout the Year'
                },
                width: 600,
                height: 350,
                series: {
                    // Gives each series an axis name that matches the Y-axis below.
                    0: { axis: 'Temps' },
                    1: { axis: 'Daylight' }
                },
                axes: {
                    // Adds labels to each axis; they don't have to match the axis names.
                    y: {
                        Temps: { label: 'Temps (Celsius)' },
                        Daylight: { label: 'Daylight' }
                    }
                }
            };



            var classicOptions = {
                title: 'Temperatura y Humudad de camara climatica seleccionada',
                width: 600,
                height: 400,
                // Gives each series an axis that matches the vAxes number below.
                series: {
                    0: { targetAxisIndex: 0 },
                    1: { targetAxisIndex: 1 }
                },
                vAxes: {
                    // Adds titles to each axis.
                    0: { title: 'Temperatura (~C)' },
                    1: { title: 'Humedad (%HR)' }
                },
                hAxis: {

                },
                vAxis: {
                    viewWindowMode: 'explicit',
                    viewWindow: {
                        max: 90,
                        min: 10
                    }
                }
            };


            function drawMaterialChart() {
                var materialChart = new google.charts.Line(chartDiv);
                materialChart.draw(data, materialOptions);
                button.innerText = 'Change to Classic';
                button.onclick = drawClassicChart;
            }

            function drawClassicChart() {
                var classicChart = new google.visualization.LineChart(chartDiv);
                classicChart.draw(data, classicOptions);
                button.innerText = 'Change to Material';
                button.onclick = drawMaterialChart;
            }

            drawClassicChart()

        }




    </script>
    <div class="content-wrapper">
        <section class="content">

            <div class="row">
                <div class="col-sm-6">
                    <tr>
                        <td>
                            <div class="container-fluid">
                                <div class="card card-default">
                                    <div class="card-header ">


                                        <div class="card-tools">
                                            <b class="text-info">Datos principales</b>
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>

                                        </div>

                                    </div>
                                    <div class="card-body">
                                        <asp:Label ID="lblInfo" CssClass="text-sm" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>

                            <div class="container-fluid">
                                <div class="card card-default">
                                    <div class="card-header ">


                                        <div class="card-tools">
                                            <b class="text-info">Validaciones realizadas</b>
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>

                                        </div>

                                    </div>
                                    <div class="card-body">




                                        <div class="table-responsive">
                                            <table id="tt" class="table tt table-sm table-bordered ">

                                                <asp:Repeater ID="RepeaterValidaciones" runat="server">
                                                    <ItemTemplate>


                                                        <tr class="bg-dark text-white" runat="server" visible='<%# If(Eval("ID") = "0", True, False)%>'>

                                                            <td>Codigo </td>
                                                            <td>Camara</td>
                                                            <td>Modelo </td>
                                                            <td>WO</td>
                                                            <td>Serie</td>

                                                            <td>Equipo</td>
                                                            <td>Amperios ON Patron</td>
                                                            <td>Amperios Off Patron</td>
                                                            <td>Amperios On Equipo</td>
                                                            <td>Amperios Off Equipo</td>
                                                            <td>Voltaje On Patron</td>
                                                            <td>Voltaje Off Patron</td>
                                                            <td>Voltaje On Equipo</td>
                                                            <td>Voltaje Off Equipo</td>


                                                            <td>Comentario</td>
                                                            <td>Tipo</td>
                                                            <td>Tecnico</td>
                                                            <td>Creado</td>

                                                        </tr>


                                                        <tr class="bg-dark text-white" runat="server" visible='<%# If(Eval("ID") = "-1", True, False)%>'>

                                                            <td>Codigo </td>
                                                            <td>Camara</td>
                                                            <td>Modelo </td>
                                                            <td>WO</td>
                                                            <td>Serie</td>

                                                            <td>Equipo</td>
                                                            <td colspan="3">ft/min</td>
                                                            <td colspan="3">ft/min</td>
                                                            <td colspan="2">ft/min</td>


                                                            <td>Comentario</td>
                                                            <td>Tipo</td>
                                                            <td>Tecnico</td>
                                                            <td>Creado</td>

                                                        </tr>


                                                        <tr runat="server" visible='<%# If(Eval("Tipo_Entrada").ToString.TrimEnd = "Electrico", True, False)%>'>

                                                            <td><%# Eval("Codigo") %> </td>
                                                            <td><%# Eval("Camara") %></td>
                                                            <td><%# Eval("Modelo") %></td>
                                                            <td><%# Eval("WO") %></td>
                                                            <td><%# Eval("Serie") %></td>
                                                            <td><%# Eval("Equipo") %></td>
                                                            <td><%# Eval("P1") %></td>
                                                            <td><%# Eval("P2") %></td>
                                                            <td><%# Eval("P3") %></td>
                                                            <td><%# Eval("P4") %></td>
                                                            <td><%# Eval("P5") %></td>
                                                            <td><%# Eval("P6") %></td>
                                                            <td><%# Eval("P7") %></td>
                                                            <td><%# Eval("P8") %></td>
                                                            <td><%# Eval("Comentario") %></td>
                                                            <td><%# Eval("Tipo_Entrada") %></td>
                                                            <td><%# Eval("Tecnico") %></td>
                                                            <td><%# Eval("Fecha_Creacion") %></td>

                                                        </tr>

                                                        <tr runat="server" visible='<%# If(Eval("Tipo_Entrada").ToString.TrimEnd = "Flujo de aire", True, False)%>'>

                                                            <td><%# Eval("Codigo") %> </td>
                                                            <td><%# Eval("Camara") %></td>
                                                            <td><%# Eval("Modelo") %></td>
                                                            <td><%# Eval("WO") %></td>
                                                            <td><%# Eval("Serie") %></td>
                                                            <td><%# Eval("Equipo") %></td>
                                                            <td colspan="3"><%# Eval("P1") %></td>
                                                            <td colspan="3"><%# Eval("P2") %></td>
                                                            <td colspan="2"><%# Eval("P3") %></td>
                                                            <td><%# Eval("Comentario") %></td>
                                                            <td><%# Eval("Tipo_Entrada") %></td>
                                                            <td><%# Eval("Tecnico") %></td>
                                                            <td><%# Eval("Fecha_Creacion") %></td>

                                                        </tr>





                                                    </ItemTemplate>
                                                </asp:Repeater>

                                            </table>
                                        </div>

                                    </div>

                                </div>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="container-fluid">
                                <div class="card card-default">
                                    <div class="card-header ">


                                        <div class="card-tools">
                                            <b class="text-info">Listado de pruebas</b>
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>

                                        </div>

                                    </div>
                                    <div class="card-body">

                                        <table class="table table-bordered table-sm table-hover">
                                            <asp:Repeater ID="repeaterPruebas" runat="server">
                                                <HeaderTemplate>

                                                    <thead class="thead-dark">
                                                        <th>Prueba
                                                        </th>
                                                        <th>Inicio
                                                        </th>
                                                        <th>Fin
                                                        </th>
                                                        <th>Comentario
                                                        </th>
                                                    </thead>
                                                </HeaderTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <tr class="alert-<%# If(Eval("FechaInicio") Is DBNull.Value, "danger", "sucess")  %>">
                                                        <td>
                                                            <%# Eval("descripcion") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("FechaInicio") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("FechaFinalizacion") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("prueba") %>
                                                        </td>

                                                    </tr>




                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>



                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="container-fluid">
                                <div class="card card-default">
                                    <div class="card-header ">


                                        <div class="card-tools">
                                            <b class="text-info">Datos principales</b>
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>

                                        </div>

                                    </div>


                                    <div class="card-body table-responsive">


                                        <asp:Repeater ID="RepeaterRecepcion" runat="server">

                                            <ItemTemplate>

                                                <th>
                                                    <div class="col-lg-12">
                                                        <div class="col-lg-8">


                                                            <table class="">


                                                                <tr>
                                                                    <td>
                                                                        <small class="text-capitalize form-inline text-bold text-lightblue  ">Fecha de operacion: </small>
                                                                    </td>
                                                                  
                                                                    <td>
                                                                        <small class="text-dark text-center"><%# Eval("FechaCreacion") %></small>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Cliente:  </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Cliente") %></small>    </td>
                                                                </tr>
                                                                  <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Tipo:  </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Tipo_Operacion") %></small>    </td>
                                                                </tr>
                                                                   <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Codigo:  </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Codigo") %></small>    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Pais origen:  </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("PaisOrigen") %></small>    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Solitado por:  </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Solicitado") %></small>    </td>
                                                                </tr>

                                                                
                                                               
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">W.O. </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Work_Order") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Serie </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Numero_Serie") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Modelo </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Modelo") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Parillas </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Parillas") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Clips </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Clip") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Lamparas </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Lamparas") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Observaciones </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Observaciones") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Rayones</small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Rayones") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Golpes</small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Golpes") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Rotulo</small></td>
                                                                    <td><small class="text-dark text-center"><%# if(Eval("Rotulo") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Cubremotor</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Cubremotor") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Certificado</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Certificado") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Etiqueta de serie</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Etiq_Serie") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Calcomanias</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Calcomanias") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Manual de operacion</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Man_Oper") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Manual de Instalacion</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Man_Ins") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Diagrama</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Diagrama") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Funcionamiento</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Funcionamiento") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Parilla Trasera</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Parilla_Trasera") = 0, "No", "Si") %></small></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Parilla Trasera</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Haladores") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Operador de laboratorio</small></td>
                                                                    <td><small class="text-dark text-center"><%#Eval("Usuario_Laboratorio") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Operador de Despachos</small></td>
                                                                    <td><small class="text-dark text-center"><%#Eval("Usuario_Entrega") %></small></td>
                                                                </tr>

                                                            </table>





                                                        </div>
                                                    </div>
                                                </th>


                                            </ItemTemplate>
                                        </asp:Repeater>




                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </div>
                <div class="col-sm-6">
                    <tr>
                        <td>
                            <div class="container-fluid">
                                <div class="card card-default">
                                    <div class="card-header ">


                                        <div class="card-tools">
                                            <b class="text-info">Condiciones ambientales</b>
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>

                                        </div>

                                    </div>
                                    <div class="card-body">
                                        <div id="chart_div"></div>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="container-fluid">
                                <div class="card card-default">
                                    <div class="card-header ">


                                        <div class="card-tools">
                                            <b class="text-info">Configuracion de carga</b>
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>

                                        </div>

                                    </div>
                                    <div class="card-body">

                                        <asp:Repeater ID="repeaterCargaEquipo" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><small>Realizado: <%# Eval("Fecha_Enviado") %>, Realizó: <%# Eval("Usuario_Prueba") %>  </small></td>
                                                </tr>
                                                <br />
                                                <tr>
                                                    <td><small>Aprobado: <%# Eval("Fecha_Revisado") %>, Aprobó: <%# Eval("Usuario_Revision") %>  </small></td>
                                                </tr>
                                                <br />

                                                <tr>
                                                    <td>
                                                        <%# Eval("Valor") %>
                                                        <br />
                                                        <small>
                                                            <%# Eval("Descripcion") %> 
                                                        </small>
                                                        <br />
                                                        <div class="text-center">
                                                            <img src='https://www.fogelonline.com/ESTATICOSWEB/TRANSCOLDPRUEBASWEB/ELEMHIST/66544/IMG_20220222_103754.JPG' width="325" />
                                                        </div>

                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>

                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="container-fluid">
                                <div class="card card-default">
                                    <div class="card-header ">


                                        <div class="card-tools">
                                            <b class="text-info">Historial de cambios</b>
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>

                                        </div>

                                    </div>
                                    <div class="card-body">
                                        <asp:Repeater ID="repeaterContadoCambios" runat="server">
                                            <ItemTemplate>


                                                <tr runat="server" visible='<%# Not Eval("contar") Is DBNull.Value AndAlso Eval("contar") = "0" %>'>
                                                    <td>

                                                        <h4 class=""><%# Eval("descripcion") %></h4>
                                                    </td>
                                                </tr>


                                                <tr runat="server" visible='<%# Not Eval("contar") Is DBNull.Value AndAlso Eval("contar") <> "0" %>'>
                                                    <td>

                                                        <div class="progress">

                                                            <div class="progress-bar progress-bar-striped bg-success" role="progressbar" <%#"Style=' Width:" + (Double.Parse(Eval("contar")) * 4).ToString + "%;'" %> aria-valuenow="<%# Eval("contar").ToString %>"
                                                                aria-valuemin="0" aria-valuemax="10">
                                                                <%# Eval("descripcion") %> -  <%# Eval("contar") %>
                                                            </div>

                                                        </div>
                                                    </td>
                                                </tr>
                                                <br />
                                            </ItemTemplate>
                                        </asp:Repeater>


                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </div>


            </div>
            <asp:HiddenField ID="hfDivision" runat="server" />
            <asp:HiddenField ID="hfConsecutivo" runat="server" />
            <asp:HiddenField ID="hfCodigo" runat="server" />



        </section>
    </div>
</asp:Content>
