<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="webRepPruebas.aspx.vb" Inherits="TranscoldPruebasWeb2.webRepPruebas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
    <div class="content-wrapper">

        
        <section class="content">
            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header border-dark ">

                        <div class="card-tools">
                            <b class="text-info">Historico de pruebas</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>
                        </div>
                    </div>

                    <div class="card-body">
                        <div class="row">
                            <div class="col-12 card-header border-danger">
                                <div class="row border-danger">

                                    <asp:HiddenField ID="hfLimites" runat="server" />
                                    
                                    <div class="col-sm-3">
                                        <small>Ruta.</small>
                                        <asp:TextBox ID="tbRuta" CssClass="form-control" runat="server" Text=""></asp:TextBox>

                                    </div>
                                     <div class="col-sm-2">
                                        <small>Modelo</small>
                                        <asp:TextBox ID="tbModelo" CssClass="form-control" runat="server" Text=""></asp:TextBox>

                                    </div>
                                    <div class="col-sm-2">
                                        <small>Serie</small>
                                        <asp:TextBox ID="tbSerie" CssClass="form-control" runat="server" Text=""> </asp:TextBox>

                                    </div>
                                    <div class="col-sm-1">
                                        <br />
                                        <asp:LinkButton ID="lbtnRefrescar" runat="server" CssClass="fa fa-2x fa-chart-line" OnClick="lbtnRefrescar_Click"></asp:LinkButton>
                                    </div>

                                </div>

                            </div>

                        </div>


                    </div>
                </div>

                <div class="card card-default">
                    <div class="row">
                        <div class="col-sm-1">
                            <small>Tiempo min</small>
                            <input type="text" id="inicio" value="00:00" class="form-control" onchange="filterData()" />

                        </div>
                        <div class="col-sm-1">
                            <small>Tiempo Max</small>
                            <input type="text" id="final" value="06:00" class="form-control" onchange="filterData()" />
                        </div>
                        <div class="col-sm-1">
                            <small>Min. Temp.</small>
                            <input type="text" id="ejeymin" value="-40" class="form-control" onchange="filterData()" />

                        </div>
                        <div class="col-sm-1">
                            <small>Max. Temp</small>
                            <input type="text" id="ejeymax" value="30" class="form-control" onchange="filterData()" />
                        </div>
                         <div class="col-sm-1">
                            <small>Min. A.</small>
                            <input type="text" id="ejey1min" value="0" class="form-control" onchange="filterData()" />

                        </div>
                        <div class="col-sm-1">
                            <small>Max. A.</small>
                            <input type="text" id="ejey1max" value="20" class="form-control" onchange="filterData()" />
                        </div>
                        <div class="col-sm-2">
                            <small>Tiempo de cursor</small>
                            <input type="text" id="tbCursor" value="" class="form-control" />
                        </div>

                        
                       
                        <div class="col-sm-1">
                            <small>°C/°F</small>
                            <input type="checkbox" id="cbTipoFC" onchange="convertirFarCel();" class="form-check" />
                        </div>
                        

                    </div>
                    <div class="card-body">



                        <div class="row">
                            <div class="col-10">
                                
                               <div class="col-12 text-sm">
                                   <div class="row border-bottom border-info">
                                      <div class="col-sm-4 text-left">
                                          <img src="../../Content/Estaticos/LOGO-FOGEL-NEGRO.png" width="300"/>

                                      </div>
                                       <div class="col-sm-4 text-center" style="display:none;">
                                           <small>FOGEL DE CENTROAMERICA S.A</small><br />
                                           <small>3a. Ave. 8-92, Zona 3, Lotificación El Rosario, Mixco</small><br />
                                           <small>Telefono: PBX:(502)24105800</small><br />
                                           <small>Fax: (502) 2438 0960 - (502) 24380948</small><br />
                                           <small>E-mail: Customerservice@fogel-group.com</small><br />
                                           </div>
                                       <div class="col-sm-8 text-right">
                                           <h5 class="text-right">R-DC-27-01</h5>
                                       </div>
                                       
                                   </div>
                                   
                                   <h2 class="text-center">Certificado de Calidad</h2>
                                   <p class="justify-content-around">
                                       Este equipo de refrigeración fue sometido a una prueba de funcionamiento para garantizar y certificar que opera dentro de las especificaciones de diseño.
                                   </p>
                                   <p >
                                       Esta prueba se efectura por medio de un sistema de medición computarizado con sensores electrónicos de circuito integrado de alta exactitud conectados 
                                       a un software que permite analizar las gráficas de temperatura y consumo de corriente en tiempo real, Esta tecnología fue desarrollada específicamente para 
                                       certificar el funcionamiento de equipos de refrigeración.
                                      
                                   </p> 
                                   <p >Las gráficas mostradas en este certificado indica la corriente en amperios que consume su unidad, y la temperatura de trabajo en función del tiempo.</p>
                              
                                   <p>Apreciamos su preferencia por nuestro producto FOGEL</p>
                                   </div>
                                
                                
                                <canvas id="myChartSysteRefry1" style="width: 100px; height: 40px; display: block;"></canvas>
                                <canvas id="myChartElectric" style="width: 100px; height: 10px; display: none;"></canvas>

                            </div>
                            <div class="col-2 text-sm ">


                                <div id="contenedor" class="text-sm"></div>
                                <hr />
                                <div id="variablesElectricas" class="text-sm">
                                    <div class="row border-danger">
                                        <table class="table-bordered">
                                             <tr>
                                                <td>Temp. Corte</td>
                                                <td>
                                                    <input type="text" id="tbCorte" value="" /></td>
                                            </tr>
                                            <tr>
                                                <td>Temp. Arranque</td>
                                                <td>
                                                    <input type="text" id="tbArranque" value="" /></td>
                                            </tr>
                                             <tr>
                                                <td>Temp. Ctr. geo.</td>
                                                <td>
                                                    <input type="text" id="tbTemperatura" value="" /></td>
                                            </tr>
                                            
                                             <tr>
                                                <td>Corriente</td>
                                                <td>
                                                    <input type="text" id="tbCorriente" value="" /></td>
                                            </tr>
                                            <tr>
                                                <td>Voltaje</td>
                                                <td>
                                                    <input type="text" id="tbVoltaje" value="" /></td>
                                            </tr>
                                            <tr>
                                                <td>Limit.</td>
                                                <td>
                                                    <input type="text" id="limite" value="2.5" /></td>
                                            </tr>
                                            <tr>
                                                <td>min Total</td>
                                                <td>
                                                    <input type="text" id="minTotal" class="bg-gradient-navy" /></td>
                                            </tr>
                                            <tr>
                                                <td>min On</td>
                                                <td>
                                                    <input type="text" id="minOn" class="bg-gradient-navy" /></td>
                                            </tr>
                                            <tr>
                                                <td>min Off</td>
                                                <td><input type="text" id="minOff" class="bg-gradient-navy" /></td>
                                            </tr>
                                            <tr>
                                                <td>Hora Inicio</td>
                                                <td>
                                                    <input type="text" id="horaInicio" value="00:00:00" /></td>
                                            </tr>
                                            <tr>
                                                <td>Hora Final</td>
                                                <td>
                                                    <input type="text" id="horaFin" value="00:00:00" /></td>
                                            </tr>
                                            
                                            <tr>
                                                <td>Tasa de trabajo</td>
                                                <td>
                                                    <input type="text" id="tasa" class="bg-gradient-navy" /></td>
                                            </tr>
                                            <tr>
                                                <td>Ciclos Total</td>
                                                <td>
                                                    <input type="text" id="ciclos" class="bg-gradient-navy" /></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <button class="btn btn-default" onclick=" return calcularConsumo();">Calcular</button></td>
                                            </tr>
                                            
                                            <tr>
                                                <td>Cursor Grafica</td>
                                                <td><input type="text" id="tbCursorGrafica" /></td>
                                            </tr>
                                            <tr>
                                                <td>Minimo</td>
                                                <td><input type="text" id="tbLMin" class="bg-info" /></td>
                                            </tr>
                                            
                                            <tr>
                                                <td>Maximo</td>
                                                <td><input type="text" id="tbLMax" class="bg-danger" /></td>
                                            </tr>
                                        </table>
                                    </div>

                                </div>
                            </div>

                        </div>
                    

                    </div>
                </div>
            </div>
        </section>
    </div>


    <script type="text/javascript" src="/Scripts/plugins/chart.js/chart/chart.js"></script>
    <script src="/Scripts/plugins/chart.js/chart/hammerjs@2.0.8.js"></script>
    
    <script>

       <%= datosPrueba() %>

        //  alert()
        //const data
      


        $(function () {
            $("#tbLMin").val(limiteMinimo);
            $("#tbLMax").val(limiteMaximo);
            
            $("#tbCorte").val(tempCorte);
            $("#tbArranque").val(tempArranque);

           filterData();
            asignacionEscalaCorrienteGrafica();
        });

        function asignacionEscalaCorrienteGrafica()
        {
            
            var corrienteAlcanzada = parseInt(myChartSysRef1.config.data.datasets[1].data[20]);
            
            myChartSysRef1.config.options.scales.y1.max = (corrienteAlcanzada * 10);
            myChartSysRef1.update();


        }
        function calcularTiempoMaximoPrueba() {
          
            try {
              
                const labelGrafico = DataT.labels[DataT.labels.length-1].toString().split(":");
               
                const labelTB = $('#final').val().toString().split(":");


                const ejexG = (labelGrafico[0] *360) + parseInt(labelGrafico[1] * 6);
                const ejexTB = (labelTB[0] * 360) + parseInt(labelTB[1] * 6);
                
                if (parseInt(labelTB[1]) < 60) {
                    if (ejexG < ejexTB) {
                        if ((labelGrafico[1]-5) >= 10) {
                            $("#horaInicio").val("00:30:00");

                            
                            $('#final').val(labelGrafico[0] + ":" + (parseInt(labelGrafico[1]) - 5));
                            
                        } else {
                            $("#horaInicio").val("00:30:00");

                            
                            $('#final').val(labelGrafico[0] + ":0" + (parseInt(labelGrafico[1]) - 5));
                            $("#horaFin").val(labelGrafico[0] + ":0" + (parseInt(labelGrafico[1]) - 5) + ":00");
                        }
                       
                    }
                }
                else {
                    metodo("Por favor, ingresa el dato de minutos valido", 2);
                }
            } catch (ex)

            {
            }
          
        }
       
        function calcularConsumo() {
            try {

                var contadorOn = 0;
                var contadoOff = 0;
                var contadorCiclos = 0;
                var limite = $("#limite").val();
                var valor = 0;
                var banderaOff = 0;


                var inicio = $("#horaInicio").val().split(":");

                var final = $("#horaFin").val().split(":");

                var inicioIndice = (inicio[0] * 360) + (inicio[1] * 6);
                var finalIndice = (final[0] * 360) + (final[1] * 6);
                var minutosTotal = (finalIndice - inicioIndice) / 6;
                for (var i = inicioIndice; i < finalIndice; i++) {
                    valor = myChartSysRef1.config.data.datasets[1].data[i];

                    if (valor >= limite) {
                        contadorOn = contadorOn + 1;
                        banderaOff = 1;
                    } else {
                        contadoOff = contadoOff + 1;
                        if (banderaOff == 1) {
                            banderaOff = 0;
                            contadorCiclos = contadorCiclos + 1;
                        }
                    }
                }

                contadorOn = contadorOn / 6;
                contadoOff = contadoOff / 6;
                $("#minOn").val(contadorOn.toString().substring(0,5));
                $("#minOff").val(contadoOff.toString().substring(0, 5));
                $("#ciclos").val(contadorCiclos);
                $("#minTotal").val(minutosTotal);
                $("#tasa").val(((minutosTotal-contadoOff)/(minutosTotal*0.01)).toString().substring(0,4)+"%");
            } catch (Exceptcion) {
            }

            return false;
        }
        
        function convertirFarCel()
        {
            var tipo = $("#cbTipoFC").prop('checked');
            var ejeymin1 = 0;
            var ejeymax1 = 0;
            
            
            if (tipo === true)
            {
                 ejeymin1 = ($("#ejeymin").val()*1.8)+32;
                 ejeymax1 = ($("#ejeymax").val()*1.8)+32;
                $("#ejeymin").val(ejeymin1.toString().substring(0,3));
                $("#ejeymax").val(ejeymax1.toString().substring(0, 3));
                myChartSysRef1.config.options.scales.y.title.text = 'Fahrenheit (°F)';
                try {
                for (var i = 0; i < myChartSysRef1.config.data.datasets[0].data.length; i++) {

                    

                        myChartSysRef1.config.data.datasets[0].data[i] = ((myChartSysRef1.config.data.datasets[0].data[i] * 1.8) + 32);
                            
                       
                    }
                } catch (ex) { }
                
                var minimosLimite = ($("#tbLMin").val()*1.8)+32;
                $("#tbLMin").val(minimosLimite.toString().substring(0, 5));

                var maximosLimite = ($("#tbLMax").val() * 1.8) + 32;
                $("#tbLMax").val(maximosLimite.toString().substring(0, 5));

                
                
                
            } else
            {

                ejeymin1 = ($("#ejeymin").val() -32) / 1.8;
                ejeymax1 = ($("#ejeymax").val() -32) / 1.8;
                $("#ejeymin").val(ejeymin1.toString().substring(0, 3));
                $("#ejeymax").val(ejeymax1.toString().substring(0, 3));
                myChartSysRef1.config.options.scales.y.title.text = 'Celcius (°C)';
            try {
                for (var i = 0; i < myChartSysRef1.config.data.datasets[0].data.length; i++) {


                        myChartSysRef1.config.data.datasets[0].data[i] = ((myChartSysRef1.config.data.datasets[0].data[i] - 32) / 1.8);
                      
                }
                } catch (ex) { }
                
                var minimosLimite = ($("#tbLMin").val() -32) /1.8;
                $("#tbLMin").val(minimosLimite.toString().substring(0, 5));

                var maximosLimite = ($("#tbLMax").val() -32) /1.8;
                $("#tbLMax").val(maximosLimite.toString().substring(0, 5));

              

            }
            

            myChartSysRef1.config.options.scales.y.min = parseInt($("#ejeymin").val());
            myChartSysRef1.config.options.scales.y.max = parseInt($("#ejeymax").val());
            myChartSysRef1.update();
        }

        
        function limiteGrafica(chart, temperatura,color) {
            
            const {canvas,ctx,data ,chartArea: { left, right, top, bottom }, scales: {x, y } } = chart;
            //chart.update('none');
           // const coorY = mousemove.offsetY;
            var area = bottom - top;

            const ejeymin = $('#ejeymin').val();
            const ejeymax = $('#ejeymax').val();

            var valorTotal = (ejeymax) - (ejeymin);
            var cantidadEnPorcentaje = ejeymax - temperatura;
            var porcentajeLimite = (100 - ((valorTotal) - (cantidadEnPorcentaje)) / (0.01 * valorTotal));
            const coordenaday = parseInt(area * (0.01 * porcentajeLimite) + top);

          

            ctx.restore();
            canvas.style.cursor = 'crosshair';
            ctx.lineWidth = 1;
            chart.ctx.strokeStyle = color;
            ctx.setLineDash([3, 3]);
            ctx.beginPath();
            chart.ctx.moveTo(left, coordenaday);
            chart.ctx.lineTo(right, coordenaday);
            chart.ctx.stroke();
            chart.ctx.closePath();
                     
        }
        
        function cursorGrafica(ubicacion,chart)
        {
            const { chartArea: { left, right, top, bottom } } = chart;
            chart.update('none');

            chart.ctx.restore();
            
            chart.canvas.style.cursor = 'crosshair';
               
            chart.ctx.strokeStyle = "#FF0000";
            chart.ctx.lineWidth = 2;
            chart.ctx.setLineDash([0, 0]);
            chart.ctx.beginPath();

                chart.ctx.moveTo(ubicacion, top);
                chart.ctx.lineTo(ubicacion, bottom);
                chart.ctx.stroke();
                
            chart.ctx.closePath();
        }
        
        function crosshairLine(chart, mousemove,  chart2) {

            const { chartArea: { left, right, top, bottom } } = chart;
            const coorX = mousemove.offsetX;
            const coorY = mousemove.offsetY;
            var banderaalto = false;
            const ejexminS = $('#inicio').val().toString().split(":");
            const ejexmaxS = $('#final').val().toString().split(":");

            var ejexmin = (ejexminS[0] * 360) + parseInt(ejexminS[1] * 6);
            
            const ejexmax = (ejexmaxS[0] * 360) + parseInt(ejexmaxS[1] * 6);
           
            var posPor = ((coorX - left) * 100) / ((right) - (left));
            
            const indice = parseInt((((ejexmax) - (ejexmin)) * posPor) / 100);
            ejexmin = ejexmin +1;
            const segundoss = (indice) * 10;

            const minutosInicio = ejexmin / 6;


            chart.update('none');

            chart.ctx.restore();
            if (coorX >= left && coorX <= right && coorY >= top && coorY <= bottom) {
                chart.canvas.style.cursor = 'crosshair';
                banderaalto = true;
            }
            else {
                chart.canvas.style.cursor = 'default';

            }
           // chart.ctx.strokeStyle = "#FF0000";
            chart.ctx.lineWidth = 2;
            chart.ctx.setLineDash([0, 0]);
            chart.ctx.beginPath();

            if (coorX >= left && coorX <= right) {
                chart.ctx.moveTo(coorX, top);
                chart.ctx.lineTo(coorX, bottom);
                chart.ctx.stroke();
                banderaalto = true;

            }

           

            chart.ctx.closePath();
            if (banderaalto === true) {
                cursorGrafica(coorX, myChartElecV, banderaalto);
            }
            try {
                
                var fechaI2 = new Date(fechaInicio);
                    fechaI2.setMinutes(minutosInicio)
                    fechaI2.setSeconds(segundoss);
                    //  tbCursor
                    $("#tbCursor").val(fechaI2.toLocaleString());
                
            } catch (Exception) {
                // console.log(e);
            }
             try { $("#tbTemperatura").val(chart.config.data.datasets[0].data[indice + ejexmin].toString().substring(0,6)); }
            catch (Exception) { }

            try { $("#tbAmbiente").val(DataA.data.datasets[0].data[indice + ejexmin]); }
            catch (Exception) { }

            $("#tbCursorGrafica").val(chart2.config.data.labels[indice + ejexmin]);
           // console.log(chart2.config.data.labels[indice]);
            
            $("#tbVoltaje").val(chart2.config.data.datasets[0].data[indice + ejexmin]);
            $("#tbCorriente").val(chart.config.data.datasets[1].data[indice + ejexmin]);

            limiteGrafica(myChartSysRef1, $("#tbLMin").val(), "#00AAFF");
            limiteGrafica(myChartSysRef1, $("#tbLMax").val(), "#FF0000");

        }
        
        const scales = {
            y: {
                min: 110
                , max: 135,
                //   title: { display: true, text: 'Voltaje' }}
            }
        };

        // config 
        //Refrgeracion.
        //chart.config.options.scales.y.title.text=''
        const config1 = {
            type: 'line',

            data: DataT,
            options: {
                scales: {
                    y: {
                        min: -30,
                        max: 110,
                        type: 'linear',
                        display: true,
                        
                        position: 'left',
                        title: {display:true,text:'Temperatura (°C)'}
                    },
                    y1: {
                        min: 0,
                        max:20,
                        type: 'linear',
                        display: true,
                        position: 'right',
                        title: { display: true, text: 'Amperios (A)' }

                        
                    },
                }
            }
        };
       
        //Electrico
        const config8 = {
            type: 'line',

            data: DataC,
            options: {

                scales: scales,
            },
        };




        const myChartSysRef1 = new Chart(
            document.getElementById('myChartSysteRefry1'),
            config1
        );
      
        const myChartElecV = new Chart(
            document.getElementById('myChartElectric'),
            config8
        );
        
       
        function filterData() {

            calcularTiempoMaximoPrueba();
            //console.log(datesfiltrer);
          //  const startInicio = document.getElementById('inicio');
            //   const endFinal = document.getElementById('final');
            try {
                if ($('#inicio').val().toString().Contains(":")) {
                } else {
                    $('#inicio').val($('#inicio').val() + ":00");
                }

                if ($('#final').val().toString().Contains(":")) {
                } else {
                    $('#final').val($('#final').val() + ":00");
                }
            } catch (Ex) { }
            
          
            
            const ejexminS = $('#inicio').val().toString().split(":");
            const ejexmaxS = $('#final').val().toString().split(":");


            const ejexmin = (ejexminS[0] * 360) + parseInt(ejexminS[1] * 6);
            const ejexmax = (ejexmaxS[0] * 360) + parseInt(ejexmaxS[1] * 6);
          //  const indexstart = labels.indexOf(startInicio.value);
         //   const indexend = labels.indexOf(endFinal.value);

            const ejeymin = parseInt(document.getElementById('ejeymin').value);
            const ejeymax = parseInt(document.getElementById('ejeymax').value);
            const ejey1min = parseInt(document.getElementById('ejey1min').value);
            const ejey1max = parseInt(document.getElementById('ejey1max').value);

            if (ejexmin< ejexmax & ejeymin < ejeymax) {
             //   const filterX = labels.slice(indexstart, indexend);
                
              //  myChartSysRef1.config.data.labels = filterX;
                try {
                myChartSysRef1.config.options.scales.x.min = ejexmin;
                myChartSysRef1.config.options.scales.x.max = ejexmax;
                myChartSysRef1.config.options.scales.y.min = ejeymin;
                myChartSysRef1.config.options.scales.y.max = ejeymax;
                myChartSysRef1.config.options.scales.y1.min = ejey1min;
                myChartSysRef1.config.options.scales.y1.max = ejey1max;
                myChartSysRef1.update();
                myChartSysRef1.ctx.closePath();
            } catch (ex) { }
            

                
               
            }


            calcularConsumo();
        }
        
        myChartSysRef1.canvas.addEventListener('click', (e) => {
            crosshairLine(myChartSysRef1, e,  myChartElecV);
         //   limiteGrafica(myChartSysRef1, e);
        });
        

    </script>
</asp:Content>
