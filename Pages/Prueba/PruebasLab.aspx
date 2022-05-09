<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="PruebasLab.aspx.vb" Inherits="TranscoldPruebasWeb2.PruebasLab" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
     <div class="content-wrapper">

        <!-- Main content -->
        <section class="content">
            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header border-dark ">


                        <div class="card-tools">
                            <b class="text-info">Solicitud de prueba R-ID-00-002</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-6 card-header border-danger">
                                <div class="row">


                                    <div class="col-sm-4">
                                        <asp:TextBox ID="tbCodigo" CssClass="form-control" runat="server" Text="22/0035"></asp:TextBox>

                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="tbFecha" CssClass="form-control" runat="server" Text="2022/05/03 21:30"> </asp:TextBox>

                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="tbDias" CssClass="form-control" runat="server" TextMode="Number" Text="1"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="col-6 border-success card-header">
                                <div class="row">
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" Text="22/0035"></asp:TextBox>

                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" Text="2022/05/03 21:30"> </asp:TextBox>

                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" TextMode="Number" Text="1"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                        </div>
                        <div class="row">
                            <div class="col-sm-1">
                                <small>Min</small>
                                <input type="text" id="inicio" value="1" class="form-control" onchange="filterData()" />

                            </div>
                            <div class="col-sm-1">
                                <small>Max</small>
                                <input type="text" id="final" value="300" class="form-control" onchange="filterData()" />
                            </div>
                            <div class="col-sm-1">
                                <small>Min y</small>
                                <input type="text" id="ejey" value="-5" class="form-control" onchange="filterData()" />

                            </div>
                            <div class="col-sm-1">
                                <small>Max y</small>
                                <input type="text" id="ejeyy" value="300" class="form-control" onchange="filterData()" />
                            </div>
                        </div>
         
                    </div>
                </div>

                 <div class="card card-default">
                    <div class="card-header border-dark ">


                        <div class="card-tools">
                         

                        </div>
                    </div>
                    <div class="card-body">
                     
                           
                        
                        <div class="row">
                            <div class="col-10">
                              <canvas id="myChartHumidity" style="width: 100px; height: 30px;"></canvas>
                              <canvas id="myChartElectric" style="width: 100px; height: 40px;"></canvas>
                              <canvas id="myChartSysteRefry1" style="width: 100px; height: 40px;"></canvas>
                              <canvas id="myChartSysteRefry2" style="width: 100px; height: 40px;"></canvas>
                              <canvas id="myChartProducto" style="width: 100px; height: 40px;"></canvas>
                                 <canvas id="myChartPresiones1" style="width: 100px; height: 30px;"></canvas>
                                <canvas id="myChartPresiones2" style="width: 100px; height: 30px;"></canvas>
                            </div>
                            <div class="col-2">
                                 
                            </div>

                        </div>
                        
                         <div class="row">
                            <div class="col-6">

                             

                            </div>
                            <div class="col-6">
                                  
                            </div>

                        </div>
                        
                        
                    </div>
                </div>
            </div>
        </section>
    </div>


    <asp:TextBox ID="tbRuta" CssClass="form-control" runat="server" TextMode="Number" Text="D:\lmpv\"></asp:TextBox>



    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/hammerjs@2.0.8"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/chartjs-plugin-zoom/1.0.1/chartjs-plugin-zoom.min.js"></script>
<script>

    <%= labTestConsulta() %>
    
    const tooltipLine =
    {
        id: 'tooltipLine',
       beforeDraw: chart => {
            if (chart.tooltip._active && chart.tooltip._active.length) {
                 const ctx = chart.ctx;
             //   ctx.save();
                ctx.restore();
                  const activePoint = chart.tooltip._active[0];
                console.log(chart.chartArea);
                ctx.beginPath();
                ctx.setLineDash([5, 7]);
                ctx.moveTo(activePoint.element.x, 0);
                ctx.lineTo(activePoint.element.x,1000);
                ctx.lineWidth = 2;
                ctx.strokeStyle = 'red';
                ctx.stroke();
                ctx.setLineDash([0, 0]);
             


           }
       }

    };



  

    function crosshairLine(chart, mousemove)
    {
        const { canvas, ctx, chartArea: { left, right, top, bottom } } = chart;
        const coorX = mousemove.offsetX;
        const coorY = mousemove.offsetY;
        chart.update('none');
        ctx.restore();
        if (coorX >= left && coorX <= right && coorY >= top &&   coorY <= bottom)
        {
            canvas.style.cursor = 'crosshair';
        }
        else
            {
                canvas.style.cursor ='default' ;

        }
        ctx.strokeStyle = "#FF0000";
        ctx.lineWidth = 2;
        
        ctx.setLineDash([0, 0]);



       
        ctx.beginPath();
        if (coorX >= left && coorX <= right) {
            ctx.moveTo(coorX, top);
            ctx.lineTo(coorX, bottom);
            ctx.stroke();
        }
        ctx.closePath();
        //const indexend = labels.indexOf(endFinal.value);

    //    console.log(chart.config.data.datasets[0].data[chart.config.labels]);
        console.log(chart.tooltip._active[0].element);
    }
        
    

    
    const scales = {

    };
   // Object.keys(scales).forEach(scale => Object.assign(scales[scale], scaleOpts));


    // config 
    const config1 = {
        type: 'line',

        data: data1,
        options: {
            
            scales: {
               
                y: {
                    min: 0,
                    max: 50,
                }
            },
            plugins:
            {
                
      
                title: {
                    display: true,
                    //  text: (ctx) => zoomStatus(ctx.chart)
                },

            },
            transitions: {
                zoom: {
                    animation: {
                        duration: 100
                    }
                }
            },
           // tooltipLine,
        }
    };
    const config2 = {
        type: 'line',

        data: data2,
        options: {
            scales: scales,
            plugins: {
               
                title: {
                    display: true,
                    //  text: (ctx) => zoomStatus(ctx.chart)
                }
            },
            transitions: {
                zoom: {
                    animation: {
                        duration: 100
                    }
                }
            }
        }
    };
    const config3 = {
        type: 'line',

        data: data3,
        options: {
            scales: scales,
            plugins: {
                
                title: {
                    display: true,
                    //  text: (ctx) => zoomStatus(ctx.chart)
                }
            },
            transitions: {
                zoom: {
                    animation: {
                        duration: 100
                    }
                }
            }
        }
    };
    const config4 = {
        type: 'line',

        data: data4,
        options: {
            scales: scales,
            plugins: {
               
                title: {
                    display: true,
                    //  text: (ctx) => zoomStatus(ctx.chart)
                }
            },
            transitions: {
                zoom: {
                    animation: {
                        duration: 100
                    }
                }
            }
        }
    };
    const config5 = {
        type: 'line',

        data: data5,
        options: {
            scales: {
                y: {
                    type: 'linear',
                    display: true,
                    position: 'left',
                },
                y1: {
                    type: 'linear',
                    display: true,
                    position: 'right',
                    min: 0,
                    max: 5,
                }
            },
            plugins: {
             
                title: {
                    display: true,
                    //  text: (ctx) => zoomStatus(ctx.chart)
                }
            },
            transitions: {
                zoom: {
                    animation: {
                        duration: 100
                    }
                }
            }
        }
    };
    const config7 = {
        type: 'line',

        data: data7,
        options: {
            scales: scales,
            
            
            transitions: {
                zoom: {
                    animation: {
                        duration: 100
                    }
                }
            }
        },
       
           // plugins: [tooltipLine]
        
    };
    const config8 = {
        type: 'line',

        data: data8,
        options: {
            scales: scales,
            plugins: {
            
                
            }
        }, plugins: [tooltipLine]
    };
    const config6 = {
        type: 'line',

        data: data7,
        options: {
            scales: scales,
            plugins: {
          
                title: {
                    display: true,
                    //  text: (ctx) => zoomStatus(ctx.chart)
                }
            },
            
        }
    };



    // render init block
    const myChartSysRef1 = new Chart(
        document.getElementById('myChartSysteRefry1'),
        config1
    );
    const myChartHum = new Chart(
        document.getElementById('myChartHumidity'),
        config7
    );

    const myChartPress1 = new Chart(
        document.getElementById('myChartPresiones1'),
        config2
    );
    const myChartSysRef2 = new Chart(
        document.getElementById('myChartSysteRefry2'),
        config3
    );
    const myChartPress2 = new Chart(
        document.getElementById('myChartPresiones2'),
        config4
    );
    const myChartproducto = new Chart(
        document.getElementById('myChartProducto'),
        config5
    );
    const myChartElec = new Chart(
        document.getElementById('myChartElectric'),
        config8
    );
    //myChartSysteRefry1

    function filterData() {
        const filtro = [...labels];
        //console.log(datesfiltrer);
        const startInicio = document.getElementById('inicio');
        const endFinal = document.getElementById('final');

        const indexstart = labels.indexOf(startInicio.value);
        const indexend = labels.indexOf(endFinal.value);

        const filterX = labels.slice(indexstart, indexend + 1);
        //   myChartElec.config.data.labels = filterX;
        //     myChartElec.update();
       // myChartHum.config.data.labels = filterX;
       // myChartHum.options.scales.y.min = indexstart;
     //   myChartHum.update();




    }

    myChartHum.canvas.addEventListener('mousemove', (e) => {
        crosshairLine(myChartHum, e)
    });

</script>


</asp:Content>
