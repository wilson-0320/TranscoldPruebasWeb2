<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="lecturas.aspx.vb" Inherits="TranscoldPruebasWeb2.lecturas" %>

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

          data.addRows(<%=datos()%>);

         
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
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
      

            <div class="row">
                <div class="col-sm-6">
                    <div class="container-fluid">
                        <div class="card card-default">
                            <div class="card-header ">


                                <div class="card-tools">
                                    <b class="text-info">Catalogos</b>
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>

                                </div>

                            </div>
                            <div class="card-body">
                                  <div  id="chart_div"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="container-fluid">
                        <div class="card card-default">
                            <div class="card-header ">


                                <div class="card-tools">
                                    <b class="text-info">Catalogos</b>
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>

                                </div>

                            </div>
                            <div class="card-body">
                                  <div  id="chart_div2"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </section>
    </div>
</asp:Content>
