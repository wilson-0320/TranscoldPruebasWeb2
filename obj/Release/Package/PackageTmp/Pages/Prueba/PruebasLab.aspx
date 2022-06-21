<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="PruebasLab.aspx.vb" Inherits="TranscoldPruebasWeb2.PruebasLab" %>

<%@ Register Src="~/Pages/Solicitud/Pruebas/PaginasTermopar/wucRefrigHTML.ascx" TagPrefix="uc1" TagName="wucRefrigHTML" %>
<%@ Register Src="~/Pages/Solicitud/Pruebas/PaginasTermopar/wucRefrigHTML2.ascx" TagPrefix="uc1" TagName="wucRefrigHTML2" %>
<%@ Register Src="~/Pages/Solicitud/Pruebas/PaginasTermopar/wucVidriosHTML.ascx" TagPrefix="uc1" TagName="wucVidriosHTML" %>
<%@ Register Src="~/Pages/Solicitud/Pruebas/PaginasTermopar/wucPanaEvaporadorHTML.ascx" TagPrefix="uc1" TagName="wucPanaEvaporadorHTML" %>







<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
    <asp:DropDownList ID="ddlFecha" CssClass="form-control" Style="display: none;" runat="server"></asp:DropDownList>

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
                            <div class="col-12 card-header border-danger">
                                <div class="row border-danger">

                                    <asp:HiddenField ID="hfCodigo" runat="server" />
                                    <asp:HiddenField ID="hfLimites" runat="server" />
                                    <div class="col-sm-2">
                                        <small>Codigo</small>
                                        <asp:TextBox ID="tbCodigo" CssClass="form-control" runat="server" Text=""></asp:TextBox>

                                    </div>
                                    <div class="col-sm-2">
                                        <small>Fecha</small>
                                        <asp:TextBox ID="tbFecha" CssClass="form-control" runat="server" Text="" TextMode="DateTimeLocal"> </asp:TextBox>

                                    </div>
                                    <div class="col-sm-1">
                                        <small>Dias</small>
                                        <asp:TextBox ID="tbDias" CssClass="form-control" runat="server" TextMode="Number" Text="1"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>Act./Hist.</small>
                                        <asp:CheckBox ID="cbTipo" runat="server" CssClass="form-check" />
                                       <asp:TextBox ID="tbTipo" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3">
                                        <small>Ruta.</small>
                                        <asp:TextBox ID="tbRuta" CssClass="form-control" runat="server" Text=""></asp:TextBox>

                                    </div>
                                    <div class="col-sm-1">
                                        <br />
                                        <asp:LinkButton ID="lbtnRefrescar" runat="server" CssClass="fa fa-2x fa-chart-line" OnClick="lbtnRefrescar_Click"></asp:LinkButton>
                                    </div>

                                </div>


                                <div class="row">


                                    <div class="col-sm-2">
                                        <small>Modelo</small>
                                        <asp:TextBox ID="tbModelo" CssClass="form-control" runat="server" Text=""></asp:TextBox>

                                    </div>
                                    <div class="col-sm-2">
                                        <small>Serie</small>
                                        <asp:TextBox ID="tbSerie" CssClass="form-control" runat="server" Text=""> </asp:TextBox>

                                    </div>
                                    <div class="col-sm-2">
                                        <small>Prueba</small>
                                        <asp:TextBox ID="tbPrueba" CssClass="form-control" runat="server"></asp:TextBox>
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
                            <input type="text" id="inicio" value="04:00" class="form-control" onchange="filterData()" />

                        </div>
                        <div class="col-sm-1">
                            <small>Tiempo Max</small>
                            <input type="text" id="final" value="06:00" class="form-control" onchange="filterData()" />
                        </div>
                        <div class="col-sm-1">
                            <small>Min y</small>
                            <input type="text" id="ejeymin" value="-40" class="form-control" onchange="filterData()" />

                        </div>
                        <div class="col-sm-1">
                            <small>Max y</small>
                            <input type="text" id="ejeymax" value="40" class="form-control" onchange="filterData()" />
                        </div>
                        <div class="col-sm-2">
                            <small>Tiempo de cursor</small>
                            <input type="text" id="tbCursor" value="" class="form-control" />
                        </div>

                        <div class="col-sm-2">
                            <small>Pantalla</small>
                            <select class="form-control" id="monitor" onchange="cambiarPantalla();">

                                <option value="1">Sis. Refrigeración 1</option>
                                <option value="0">Producto</option>
                                <option value="3">Electrico</option>
                                <option value="4">Presiones</option>
                            </select>
                        </div>
                        <div class="col-sm-2">
                            <small>Mapa</small>
                            <select class="form-control " id="mapa" onchange="cambiarPantalla();">

                                <option value="1">Sis. Refrigeración 1</option>
                                <option value="2">Sis. Refrigeración 2</option>
                                <option value="0">Producto</option>
                                <option value="3">Vidrios</option>
                                <option value="4">Pana</option>
                                <option value="5">Ficha Tecnica</option>
                            </select>
                        </div>
                        <div class="col-sm-1">
                            <small>°C/°F</small>
                            <input type="checkbox" id="cbTipoFC" onchange="convertirFarCel();" class="form-check" />
                        </div>
                        <div class="col-sm-1">
                            <button class="btn-default" onclick="return abrirModal1();">Mapa</button>
                        </div>

                    </div>
                    <div class="card-body">



                        <div class="row">
                            <div class="col-10">
                                <canvas id="myChartHumidity" style="width: 100px; height: 8px; display: block;"></canvas>
                                
                                <canvas id="myChartElectric" style="width: 100px; height: 40px; display: none;"></canvas>
                                <canvas id="myChartSysteRefry1" style="width: 100px; height: 40px; display: block;"></canvas>
                                <canvas id="myChartProducto" style="width: 100px; height: 40px; display: none;"></canvas>
                                <canvas id="myChartPresiones1" style="width: 100px; height: 40px; display: none;"></canvas>
                                <canvas id="myChartCurrent" style="width: 100px; height: 11px; display: block;"></canvas>

                            </div>
                            <div class="col-2 text-sm ">


                                <div id="contenedor" class="text-sm"></div>
                                <hr />
                                <div id="variablesElectricas" class="text-sm">
                                    <div class="row border-danger">
                                        <table class="table-bordered">
                                             <tr>
                                                <td>Humedad (%HR)</td>
                                                <td>
                                                    <input type="text" id="tbHumedad" value="" /></td>
                                            </tr>
                                             <tr>
                                                <td>Temp. Amb.</td>
                                                <td>
                                                    <input type="text" id="tbTemperatura" value="" /></td>
                                            </tr>
                                            <tr>
                                                <td>Dew point.</td>
                                                <td>
                                                    <input type="text" class="bg-gradient-navy" id="tbDew" value="" /></td>
                                            </tr>
                                             <tr>
                                                <td>Corriente</td>
                                                <td>
                                                    <input type="text" id="tbCorriente" value="" /></td>
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
                                                <td>Resultado kw h</td>
                                                <td>
                                                    <input type="text" id="resultado" class="bg-gradient-navy" /></td>
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
                                                <td>Cursor Inicio</td>
                                                <td><input type="text" id="tbCursorI" /></td>
                                            </tr>
                                            <tr>
                                                <td>Cursor Fin</td>
                                                <td><input type="text" id="tbCursorF" /></td>
                                            </tr>
                                            <tr>
                                                <td>Resultado</td>
                                                <td><input type="text" id="tbCursorR" class="bg-gradient-navy" /></td>
                                            </tr>
                                            <tr>
                                                <td><input type="text" value="1" id="tbCursorEstado" style="display:none;" /></td>
                                                <td><button class="btn btn-default" onclick="return cursorActualizar();">Guardar</button></td>
                                            </tr>
                                            <tr>
                                                <td>Minimo</td>
                                                <td><input type="text" id="tbLMin" class="bg-info" /></td>
                                            </tr>
                                            <tr>
                                                <td>Promedio</td>
                                                <td><input type="text" id="tbLPro" class="bg-warning" /></td>
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
                        <div class="modal fade" id="modalCheck" name="modal" data-backdrop="static">
                            <div class="modal-dialog modal-xl">
                                <div class="modal-content">
                                    <div class="modal-header">

                                        <h4 class="modal-title">Pantalla</h4>
                                        <div class="text-right">
                                            <button class="btn btn-danger " id="btnL" onclick="return cambiarPantalla('2');"><span class="fa fa-arrow-alt-circle-left" ></span></button>
                                               <button class="btn btn-danger" id="btnR" onclick="return cambiarPantalla('1');"><span class="fa fa-arrow-alt-circle-right"></span></button>
                                            <input  type="number" id="selector" value="0" style="display:none;"/>
                                            </div>
                                        <p class="text-danger" id="encabezado"> </p>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                        
                                    </div>
                                    <div class="modal-body">
                                        
                                        <div class="row">
                                            
                                            <div id="divProdTemp" name="divProdTemp" style="display: none;">
                                                <asp:GridView runat="server" ID="gvFilas" Width="100%" DataSourceID="dsTermoparFila" AutoGenerateColumns="False" ShowHeader="False">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>

                                                                <asp:HiddenField runat="server" ID="hfFila" Value='<%# Eval("fila")%>' />
                                                                <div runat="server" id="divPosicion" style="width: 100%; display: flex; border-left: 1px solid; padding-left: 12px;">
                                                                    <asp:Label runat="server" ID="lblFilaDe3" Text='<%# Eval("fila_de_3")%>' Width="24px" Font-Bold="true"></asp:Label>
                                                                    <asp:Repeater runat="server" ID="repColumnas" DataSourceID="dsColumnas" OnPreRender="repColumnas_PreRender">
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField runat="server" ID="hfPosicion" Value='<%# Eval("posicion")%>' />
                                                                            <table runat="server" id="tblPosicion" class="tblPosicion">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CheckBox runat="server" ID="chbParticipaProm" Style="display: none;" Checked='<%# Eval("participa_prom")%>' />
                                                                                        <input type="checkbox" id="cb<%# Eval("posicion")%>" onchange="graficarPromedio();" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="tbNumCanal" Width="50px" Text='<%# Eval("num_canal")%>' Style="display: none;"></asp:TextBox>
                                                                                        <input type="text" id='tb<%# Eval("posicion")%>' value="" style="width: 50px;" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                    <asp:ObjectDataSource ID="dsColumnas" runat="server" SelectMethod="consulta" TypeName="TranscoldPruebasWeb2.BLL.Pru_Termopar_BLL">
                                                                        <SelectParameters>
                                                                            <asp:QueryStringParameter Name="cod_solicitud" QueryStringField="codigo" Type="String" />
                                                                            <asp:ControlParameter ControlID="ddlFecha" Name="stFecha" PropertyName="SelectedValue" Type="String" />
                                                                            <asp:ControlParameter ControlID="hfFila" Name="fila" PropertyName="Value" Type="Int32" DefaultValue="-2" />
                                                                            <asp:Parameter DefaultValue="-1" Name="posicion_ini" Type="Int32" />
                                                                            <asp:Parameter DefaultValue="-1" Name="posicion_fin" Type="Int32" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>

                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>










                                                <asp:ObjectDataSource ID="dsTermoparFila" runat="server" SelectMethod="ObtieneDataTable" TypeName="TranscoldPruebasWeb2.Base_BLL">
                                                    <SelectParameters>
                                                        <asp:Parameter Name="dt" Type="Object" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>


                                            </div>


                                            <div id="refry1" style="display: block; position: relative;">
                                                <uc1:wucRefrigHTML runat="server" ID="wucRefrigHTML" style="position: relative; width: 880px; height: 790px;" />
                                            </div>
                                            <div id="refry2" style="display: none;">
                                                <uc1:wucRefrigHTML2 runat="server" ID="wucRefrigHTML2" style=" width: 1760px; height: 790px;" />
                                            </div>
                                            <div id="vidrios" style="display: none;">
                                                <uc1:wucVidriosHTML runat="server" ID="wucVidriosHTML" />
                                            </div>
                                            <div id="pana" style="display: none;">
                                                <uc1:wucPanaEvaporadorHTML runat="server" ID="wucPanaEvaporadorHTML"  />
                                            </div>
                                            <div id="ficha" style="display: none;">
                                                <asp:TextBox ID="tbFicha" runat="server" CssClass="form-control" Rows="20" Columns="70" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>

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

        <%= labTestConsulta() %>

        //  alert()
        //const data
        function abrirModal1() {

            try {
                $('#modalCheck').modal('show');
            } catch (e) {
                alert(e + "");
            }
            return false;
        }


        $(function () {
            const valores = window.location.search;
            //const limiteMinimo=5;  const limitePromedio=8; const limiteMaximo=11;
            $("#tbLMin").val(limiteMinimo);
            $("#tbLMax").val(limiteMaximo);
            $("#tbLPro").val(limitePromedio);
            try {
                const urlParams = new URLSearchParams(valores);
                var codigo = urlParams.get('CodigoSol');
                if (codigo.length > 0) {

                    $('#inicio').val("00:00");
                    // codigo = codigo.substring(21, 2);
                    $('#final').val(codigo.split("-")[4].substring(0, 2) + ":00");

                }
            } catch (ex) { }
            
            filterData();
            participacionPromedio();
            graficarPromedio();
          

        });

        const frio = "#127ECE";
        const frio2 = "#1BA967";
        
        const calor = "#FF0000";
        const calor2 = "#FF8300";
        
        const intermedio = "#00FF7C";
        const valorCalor = 15;
        const valorCalor2 = 4;
        const valorFrio = -4;
        const valorFrio2 = 0;

        function cursorActualizar()
        {
            //horaInicio
            //horaFin
            var estadoCursor = parseInt($("#tbCursorEstado").val());
            var cursorHora = $("#tbCursorGrafica").val();
            switch (estadoCursor) {
                case 1:
                    $("#tbCursorI").val(cursorHora);
                    estadoCursor = estadoCursor + 1;
                    $("#tbCursorEstado").val(estadoCursor);

                    $("#horaInicio").val(cursorHora+":00");
                    break;
                case 2:
                    $("#tbCursorF").val(cursorHora);
                    estadoCursor = estadoCursor -1 ;
                    $("#tbCursorEstado").val(estadoCursor);
                    $("#horaFin").val(cursorHora + ":00");
                    var cursorF = $("#tbCursorF").val().toString().split(":");
                    var cursorI = $("#tbCursorI").val().toString().split(":");
                    
                    var horaFinales = parseInt(cursorF[0]);
                    var horaIniciales = parseInt(cursorI[0]);
                    var resultados = "";
                    var minutosI = parseInt(cursorI[1]);
                    var minutosF = parseInt(cursorF[1]);
                    var minutorResultado = minutosF - minutosI;
                    
                    if (minutorResultado < 0) {
                        minutosF = minutosF + 60;
                        horaFinales = horaFinales - 1;
                    } else if (minutorResultado > -1 & minutorResultado < 10)
                    {
                        resultados = "0";
                    }
                    
                    $("#tbCursorR").val((horaFinales-horaIniciales)+":"+resultados+(minutosF-minutosI));
                    calcularConsumo();
                    break;
            }
            return false;
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

                var inicioIndice = (inicio[0] * 120) + (inicio[1] * 2);
                var finalIndice = (final[0] * 120) + (final[1] * 2);
                var minutosTotal = (finalIndice - inicioIndice) / 2;
                for (var i = inicioIndice; i < finalIndice; i++) {
                    valor = myChartElecV.config.data.datasets[1].data[i];

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

                contadorOn = contadorOn / 2;
                contadoOff = contadoOff / 2;
                $("#minOn").val(contadorOn);
                $("#minOff").val(contadoOff);
                $("#ciclos").val(contadorCiclos);
                $("#minTotal").val(minutosTotal);
                $("#tasa").val(((minutosTotal-contadoOff)/(minutosTotal*0.01)).toString().substring(0,4)+"%");
                $("#resultado").val(((myChartElecV.config.data.datasets[3].data[finalIndice]) - (myChartElecV.config.data.datasets[3].data[inicioIndice])).toString().substring(0, 5))
            } catch (Exceptcion) {
            }

            return false;

            //  chart6.config.data.datasets[0].data[indice]

            // myChartElecV.config.data.datasets[col].data[indice]
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
                try {
                    for (var i = 0; i < indicesTermopares[0].data.length; i++) {

                        for (var h = 0; h < indicesTermopares.length; h++) {

                            if (indicesTermopares[h].indexx >= 1 & indicesTermopares[h].indexx <= 236) {
                                // return (5/9) * (fahrenheit-32);
                                indicesTermopares[h].data[i] = ((indicesTermopares[h].data[i] * 1.8) + 32);

                            }
                        }
                    }
                } catch (ex) { }
                try {
                for (var i = 0; i < myChartSysRef1.config.data.datasets[0].data.length; i++) {

                    for (var h = 0; h < myChartSysRef1.config.data.datasets.length; h++) {

                                // return (5/9) * (fahrenheit-32);
                        myChartSysRef1.config.data.datasets[h].data[i] = ((myChartSysRef1.config.data.datasets[h].data[i] * 1.8) + 32);
                        

                       // $("#tbLMin").val((($("#tbLMin").val() *1.8) +32));
                        //$("#tbLMax").val((($("#tbLMax").val() *1.8) +32));
                        //$("#tbLPro").val((($("#tbLPro").val() *1.8) +32));
                            
                        }

               

                    }
                } catch (ex) { }
                
                var minimosLimite = ($("#tbLMin").val()*1.8)+32;
                $("#tbLMin").val(minimosLimite.toString().substring(0, 5));

                var maximosLimite = ($("#tbLMax").val() * 1.8) + 32;
                $("#tbLMax").val(maximosLimite.toString().substring(0, 5));

                var promediosLimite = ($("#tbLPro").val() * 1.8) + 32;
                $("#tbLPro").val(promediosLimite.toString().substring(0, 5));
                
                
            } else
            {
                ejeymin1 = ($("#ejeymin").val() -32) / 1.8;
                ejeymax1 = ($("#ejeymax").val() -32) / 1.8;
                $("#ejeymin").val(ejeymin1.toString().substring(0, 3));
                $("#ejeymax").val(ejeymax1.toString().substring(0, 3));
            
            try {
                for (var i = 0; i < indicesTermopares[0].data.length; i++) {

                    for (var h = 0; h < indicesTermopares.length; h++) {

                        if (indicesTermopares[h].indexx >= 1 & indicesTermopares[h].indexx <= 216) {
                            // return (5/9) * (fahrenheit-32);
                            indicesTermopares[h].data[i] = ((indicesTermopares[h].data[i] - 32) / 1.8) ;

                        }
                    }



                }
            } catch (ex) { }
            try {
                for (var i = 0; i < myChartSysRef1.config.data.datasets[0].data.length; i++) {

                    for (var h = 0; h < myChartSysRef1.config.data.datasets.length; h++) {

                        // return (5/9) * (fahrenheit-32);
                        myChartSysRef1.config.data.datasets[h].data[i] = ((myChartSysRef1.config.data.datasets[h].data[i] - 32) / 1.8);
                        
                        //((parseFloat(($("#tbLMin").val()) - 32) /1.8));
                      //  $("#tbLMax").val((($("#tbLMax").val() - 32) / 1.8));
                        //$("#tbLPro").val((($("#tbLPro").val() - 32) / 1.8));

                    }



                }
                } catch (ex) { }
                
                var minimosLimite = ($("#tbLMin").val() -32) /1.8;
                $("#tbLMin").val(minimosLimite.toString().substring(0, 5));

                var maximosLimite = ($("#tbLMax").val() -32) /1.8;
                $("#tbLMax").val(maximosLimite.toString().substring(0, 5));

                var promediosLimite = ($("#tbLPro").val() -32) /1.8;
                $("#tbLPro").val(promediosLimite.toString().substring(0, 5));

            }
            
            myChartproducto.config.options.scales.y.min = parseInt($("#ejeymin").val());
            myChartproducto.config.options.scales.y.max = parseInt( $("#ejeymax").val());
            graficarPromedio();

            myChartSysRef1.config.options.scales.y.min = parseInt($("#ejeymin").val());
            myChartSysRef1.config.options.scales.y.max = parseInt($("#ejeymax").val());
            myChartSysRef1.update();
        }

        function graficarPromedio() {


            var valor = 0;
            var minimos = 100;
            var maximas = -100;
            var suma = 0;
            var promedio = 0;

            var StringPromedio = "";
            var StringMax = "";
            var StringMin = "";
            var ciclos = 0;

            var umin = "";
            var umax = "";

            var participacion = false;
            for (var i = 0; i < indicesTermopares[0].data.length; i++) {
                minimos = 100;
                ciclos = 0;
                maximas = -100;
                suma = 0;
                umin = "";
                umax = "";
                for (var h = 0; h < indicesTermopares.length; h++) {

                    if (indicesTermopares[h].indexx >= 1 & indicesTermopares[h].indexx <= 216) {
                        participacion = $("#cb" + indicesTermopares[h].indexx).prop('checked');
                        try { 
                        //participacion = parseInt(indicesTermopares[h].participa);
                        if (participacion === true) {

                            valor = indicesTermopares[h].data[i];
                            if (valor > maximas) {
                                maximas = valor;

                                umax = (indicesTermopares[h].nombre);
                            }
                            if (valor < minimos) {
                                minimos = valor;

                                umin = (indicesTermopares[h].nombre);
                            }

                            suma = suma + valor;
                            ciclos = ciclos + 1;
                        } else {
                            
                        }
                        } catch (e) { }
                    }
                }

                promedio = suma / ciclos;

                StringPromedio = StringPromedio + promedio + ",";
                StringMax = StringMax + maximas + ",";
                StringMin = StringMin + minimos + ",";
                myChartproducto.config.data.datasets[0].data[i] = minimos;
                myChartproducto.config.data.datasets[0].nombreU[i] = umin;
                myChartproducto.config.data.datasets[2].nombreU[i] = umax;

                myChartproducto.config.data.datasets[2].data[i] = maximas;
                myChartproducto.config.data.datasets[1].data[i] = promedio;






            }
            myChartproducto.config.data.labels = myChartPress1.config.data.labels;
            myChartproducto.update();

            return false;
        }

        function participacionPromedio() {


            for (var h = 0; h < indicesTermopares.length; h++) {

                if (indicesTermopares[h].indexx >= 1 & indicesTermopares[h].indexx <= 216) {


                    var participacion = parseInt(indicesTermopares[h].participa);
                    if (participacion === 1) {
                        $("#cb" + indicesTermopares[h].indexx).prop('checked', true);

                    } else {
                        $("#cb" + indicesTermopares[h].indexx).prop('checked', false);
                    }

                }



            }

        }

        function dewPoint() {
            var temperatura = $("#tbTemperatura").val();
            var humedad = $("#tbHumedad").val();
            var dew = (temperatura - ((100 - humedad) / 5)).toString().substring(0,4);
            $("#tbDew").val(dew);

            //T-(100-RH/5)

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
            //ctx.save();
           
            

           
        }

        function cursorGrafica(ubicacion,chart,alto)
        {
            const { chartArea: { left, right, top, bottom } } = chart;
            chart.update('none');

            chart.ctx.restore();
            if (alto == true)
            {
                chart.canvas.style.cursor = 'crosshair';
               
            }
            else {
                chart.canvas.style.cursor = 'default';

            }
            chart.ctx.strokeStyle = "#FF0000";
            chart.ctx.lineWidth = 2;
            chart.ctx.setLineDash([0, 0]);
            chart.ctx.beginPath();

            if (alto==true) {
                chart.ctx.moveTo(ubicacion, top);
                chart.ctx.lineTo(ubicacion, bottom);
                chart.ctx.stroke();
                

            }


            chart.ctx.closePath();
        }

        function crosshairLine(chart, mousemove, chart1, chart2, chart3, char4, chart5, chart6) {

            const { chartArea: { left, right, top, bottom } } = chart;
            const coorX = mousemove.offsetX;
            const coorY = mousemove.offsetY;

            const ejexminS = $('#inicio').val().toString().split(":");
            const ejexmaxS = $('#final').val().toString().split(":");

            var ejexmin = (ejexminS[0] * 120) + parseInt(ejexminS[1] * 2)
            const ejexmax = (ejexmaxS[0] * 120) + parseInt(ejexmaxS[1] * 2)
            var posPor = ((coorX - left) * 100) / ((right) - (left));
            
            const indice = parseInt((((ejexmax) - (ejexmin)) * posPor) / 100);
            ejexmin = ejexmin +1;
            const segundoss = (indice) * 30;

            const minutosInicio = ejexmin / 2;


            chart.update('none');

            chart.ctx.restore();
            if (coorX >= left && coorX <= right && coorY >= top && coorY <= bottom) {
                chart.canvas.style.cursor = 'crosshair';
                banderaalto = true;
            }
            else {
                chart.canvas.style.cursor = 'default';

            }
            chart.ctx.strokeStyle = "#FF0000";
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
                cursorGrafica(coorX, myChartElec, banderaalto);
                cursorGrafica(coorX, myChartHum, banderaalto);
            }
            try {
                var tipo = $("#cbTipoFC").prop('checked');
                var vvalorCalor = valorCalor;
                var vvalorCalor2 = valorCalor;
                var vvalorFrio = valorFrio;
                var vvalorFrio2 = valorFrio2;
                if (tipo === true) {
                    vvalorCalor = 59;
                    vvalorCalor2 = 39.2;
                    vvalorFrio = 24.8;
                    vvalorFrio2 = 32;
                } 

                var colorInput = "";
                for (var h = 0; h < indicesTermopares.length; h++) {
                    var temperatura = parseInt(indicesTermopares[h].data[indice + ejexmin]);
                    if (temperatura >= vvalorCalor) {
                        colorInput = calor;
                    } else if (temperatura >= vvalorCalor2 & temperatura < vvalorCalor) {
                        colorInput = calor2;
                    }
                    else if (temperatura >= vvalorFrio2 & temperatura < vvalorCalor2) {
                        colorInput = frio2;
                    } else {
                        colorInput = frio;
                    }
                    if (indicesTermopares[h].indexx < 217 || indicesTermopares[h].indexx > 260) {
                        $("#tb" + indicesTermopares[h].indexx).css("background-color", colorInput);
                    }

                    $("#tb" + indicesTermopares[h].indexx).val(indicesTermopares[h].data[indice+ejexmin].toString().substring(0, 5));
                    var fechaI2 = new Date(horaInicio);
                    fechaI2.setMinutes(minutosInicio)
                    fechaI2.setSeconds(segundoss);
                    //  tbCursor
                    $("#tbCursor").val(fechaI2.toLocaleString());
                }
                //   indicesTempalres.indexx
                //    chart.config.data.datasets[col].data[indice]);
                //   tablaGeneral = tablaGeneral + "<tr><td class='btn-primary'>" + chart.config.data.datasets[col].label + "</td><td style='display:none;'>rr</td><td>" + chart.config.data.datasets[col].data[indice] + "</td></tr>";

            } catch (Exception) {
                // console.log(e);
            }
            var tablaGeneral = "<table  class='table table-bordered table-hover table-sm'><thead><tr><th>Nombre</th><th style='display:none;'></th><th>Valor</th></tr></thead><tbody>";
            //H  tablaGeneral = tablaGeneral + "<tr><td class='btn-primary'>" + chart1.config.data.datasets[0].label + "</td><td style='display:none;'>hh</td><td>" + chart1.config.data.datasets[0].data[indice] + "</td></tr>";
            //C  tablaGeneral = tablaGeneral + "<tr><td class='btn-success'>" + chart2.config.data.datasets[0].label + "</td><td style='display:none;'>aa</td><td>" + chart2.config.data.datasets[0].data[indice] + "</td></tr>";
            //tablaGeneral = tablaGeneral + "<tr><td class='btn-success'>" + indice + "</td><td style='display:none;'>aa</td><td>" + labels[indice]+ "</td></tr>";
            try { $("#tbTemperatura").val(config6.data.datasets[0].data[indice + ejexmin]); }
            catch (Exception) { }
            $("#tbCursorGrafica").val(chart2.config.data.labels[indice + ejexmin]);
           // console.log(chart2.config.data.labels[indice]);
            $("#tbCorriente").val(chart2.config.data.datasets[0].data[indice + ejexmin]);
            $("#tbHumedad").val(chart1.config.data.datasets[0].data[indice + ejexmin]);
         dewPoint();
            try {
                tablaGeneral = tablaGeneral + "<tr><td class='btn-info'>" + chart6.config.data.datasets[0].label + "</td><td style='display:none;'>hh</td><td>" + chart6.config.data.datasets[0].data[indice + ejexmin].toString().substring(0, 4) + "</td><td>" + chart6.config.data.datasets[0].nombreU[indice + ejexmin] + "</td></tr>";
                tablaGeneral = tablaGeneral + "<tr><td class='btn-warning'>" + chart6.config.data.datasets[1].label + "</td><td style='display:none;'>hh</td><td>" + chart6.config.data.datasets[1].data[indice + ejexmin].toString().substring(0, 4) + "</td></tr>";
                tablaGeneral = tablaGeneral + "<tr><td class='btn-danger'>" + chart6.config.data.datasets[2].label + "</td><td style='display:none;'>hh</td><td>" + chart6.config.data.datasets[2].data[indice + ejexmin].toString().substring(0, 4) + "</td><td>" + chart6.config.data.datasets[2].nombreU[indice + ejexmin] + "</td></tr>";

            } catch (Exception) { }


            tablaGeneral = tablaGeneral + "</tbody></table>"
            $("#contenedor").empty();
            $("#contenedor").append(tablaGeneral);


            limiteGrafica(myChartproducto, $("#tbLMin").val(), "#00AAFF");//Minuimo
            limiteGrafica(myChartproducto, $("#tbLPro").val(), "#FFC100");
            limiteGrafica(myChartproducto, $("#tbLMax").val(), "#FF0000");

          

        }

        const scales = {
            y: { min: -30, max: 40 }
        };

        // config 
        //Refrgeracion.
        const config1 = {
            type: 'line',

            data: data1,
            options: {
                scales: scales,

            }
        };
        //Presiones
        const config2 = {
            type: 'line',

            data: data2,
            options: {
                scales: scales,

            }
        };
        ///Corriente
        const config3 = {
            type: 'line',

            data: data10,
            options: {
                scales: scales,

            }
        };
        ////Ambiente
        const config6 = {
            type: 'line',

            data: data4,
            options: {
                scales: scales,

            }
        };

        ///Corriente
        const config5 = {
            type: 'line',

            data: data5,
            options: {
                scales: { y: { min: 0, max: 6 } }

            },
        };
        ///HUUMEDAD
        const config7 = {
            type: 'line',

            data: data7,
            options: {
                scales: { y: { min: 30, max: 90 } }


            },


        };
        //Electrico
        const config8 = {
            type: 'line',

            data: data8,
            options: {

                scales: scales,
            },
        };




        // render init block
        const myChartHum = new Chart(
            document.getElementById('myChartHumidity'),
            config7
        );
        const myChartSysRef1 = new Chart(
            document.getElementById('myChartSysteRefry1'),
            config1
        );
        const myChartElec = new Chart(
            document.getElementById('myChartCurrent'),
            config5
        );

        const myChartElecV = new Chart(
            document.getElementById('myChartElectric'),
            config8
        );

        const myChartPress1 = new Chart(
            document.getElementById('myChartPresiones1'),
            config2
        );


        const myChartproducto = new Chart(
            document.getElementById('myChartProducto'),
            config3
        );

        //myChartSysteRefry1

        function filterData() {

            const filtro = [...labels];
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


            const ejexmin = (ejexminS[0] * 120) + parseInt(ejexminS[1] * 2)
            const ejexmax = (ejexmaxS[0] * 120) + parseInt(ejexmaxS[1] * 2)
          //  const indexstart = labels.indexOf(startInicio.value);
         //   const indexend = labels.indexOf(endFinal.value);

            const ejeymin = parseInt(document.getElementById('ejeymin').value);
            const ejeymax = parseInt(document.getElementById('ejeymax').value);

            if (ejexmin< ejexmax & ejeymin < ejeymax) {
             //   const filterX = labels.slice(indexstart, indexend);
                
              //  myChartSysRef1.config.data.labels = filterX;
                try {
                myChartSysRef1.config.options.scales.x.min = ejexmin;
                myChartSysRef1.config.options.scales.x.max = ejexmax;
                myChartSysRef1.config.options.scales.y.min = ejeymin;
                myChartSysRef1.config.options.scales.y.max = ejeymax;
                
                myChartSysRef1.update();
                myChartSysRef1.ctx.closePath();
            } catch (ex) { }
            

//                myChartPress1.config.data.labels = filterX;
                try {
                    myChartPress1.config.options.scales.x.min = ejexmin;
                    myChartPress1.config.options.scales.x.max = ejexmax;
                    myChartPress1.config.options.scales.y.min = ejeymin;
                    myChartPress1.config.options.scales.y.max = ejeymax;
                    myChartPress1.update();
                    myChartPress1.ctx.closePath();
                } catch (ex) { }

               
                try {
               // myChartproducto.config.data.labels = filterX;
               myChartproducto.config.options.scales.x.min = ejexmin;
                myChartproducto.config.options.scales.x.max = ejexmax;
                myChartproducto.config.options.scales.y.min = ejeymin;
                myChartproducto.config.options.scales.y.max = ejeymax;
                myChartproducto.update();
                myChartproducto.ctx.closePath();
                } catch (ex) { }
                try {
                myChartElecV.config.options.scales.x.min = ejexmin;
                myChartElecV.config.options.scales.x.max = ejexmax;
             //   myChartElecV.config.data.labels = filterX;
                myChartElecV.config.options.scales.y.min = ejeymin;
                myChartElecV.config.options.scales.y.max = ejeymax;
                myChartElecV.update();
                myChartElecV.ctx.closePath();
                } catch (ex) { }
                try {


                myChartElec.config.options.scales.x.min = ejexmin;
                myChartElec.config.options.scales.x.max = ejexmax;
               // myChartElec.config.data.labels = filterX;
                myChartElec.update();
                myChartElec.ctx.closePath();
                } catch (ex) { }
                try {
              //  myChartHum.config.data.labels = filterX;
                myChartHum.config.options.scales.x.min = ejexmin;
                myChartHum.config.options.scales.x.max = ejexmax;
                myChartHum.update();
                myChartHum.ctx.closePath();
                } catch (ex) { }
                
               // limiteGrafica(myChartproducto, $("#tbLMin").val(), "#00AAFF");//Minuimo
                //limiteGrafica(myChartproducto, $("#tbLPro").val(), "#FFC100");
                //limiteGrafica(myChartproducto, $("#tbLMax").val(), "#FF0000");
            }


            


        }

        myChartSysRef1.canvas.addEventListener('click', (e) => {
            crosshairLine(myChartSysRef1, e, myChartHum, myChartElec, myChartPress1, myChartElecV, myChartproducto, myChartproducto);
         //   limiteGrafica(myChartSysRef1, e);
        });

        myChartElecV.canvas.addEventListener('click', (e) => {
            crosshairLine(myChartElecV, e, myChartHum, myChartElec, myChartPress1, myChartSysRef1, myChartproducto, myChartproducto)
        });
        myChartPress1.canvas.addEventListener('click', (e) => {
            crosshairLine(myChartPress1, e, myChartHum, myChartElec, myChartSysRef1, myChartElecV, myChartproducto, myChartproducto)
        });

        myChartproducto.canvas.addEventListener('click', (e) => {
            crosshairLine(myChartproducto, e, myChartHum, myChartElec, myChartSysRef1, myChartPress1, myChartElecV, myChartproducto)
        });


        function cambiarPantalla(thisID) {
            
            var seleccion = parseInt($("#monitor").val());
            
            

            switch (seleccion) {

                case 0:
                    $("#myChartProducto").css("display", "block");
                    $("#myChartSysteRefry1").css("display", "none");
                    $("#myChartPresiones1").css("display", "none");
                    $("#myChartElectric").css("display", "none");

                    break;
                case 1:

                    $("#myChartProducto").css("display", "none");

                    $("#myChartSysteRefry1").css("display", "block");
                    $("#myChartPresiones1").css("display", "none");
                    $("#myChartElectric").css("display", "none");

                    //Refrigeracion
                    break;

                case 2:

                    $("#myChartProducto").css("display", "none");

                    $("#myChartSysteRefry1").css("display", "block");
                    $("#myChartPresiones1").css("display", "none");
                    $("#myChartElectric").css("display", "none");

                    //
                    //Refrigeracion
                    break;
                case 3:

                    $("#myChartProducto").css("display", "none");
                    $("#myChartSysteRefry1").css("display", "none");
                    $("#myChartPresiones1").css("display", "none");
                    $("#myChartElectric").css("display", "block");
                    //Electrico
                    break;
                case 4:

                    $("#myChartProducto").css("display", "none");
                    $("#myChartSysteRefry1").css("display", "none");
                    $("#myChartPresiones1").css("display", "block");
                    $("#myChartElectric").css("display", "none");
                    ///Presiones
                    break;
                case 5:
                    ///Vidrios
                    break;
            }
            seleccion = parseInt($("#mapa").val());
            try { 
            var seleccion2 = parseInt($("#selector").val());
             if (seleccion2 === 5)
            {
                seleccion2 = 4;
                }
                var botton = parseInt(thisID);
                switch (botton) {
                    case 1: seleccion2 = seleccion2 + 1; seleccion = seleccion2; break;
                    case 2:
                        if (seleccion2 === 0) {
                            
                        } else {
                            seleccion2 = seleccion2 - 1; seleccion = seleccion2;
                        }
                        break;
                } 
                
                console.log(seleccion);
                $("#selector").val(seleccion);
            $("#mapa option[value='"+seleccion+"']").attr("selected", true);
            } catch (Exception) { console.log(Exception); }

            
            switch (seleccion) {
                //$("#id"). css("display", "none");
                case 0:
                    $("#encabezado").val("Producto")
                    $("#divProdTemp").css("display", "inline-block");
                    $("#refry1").css("display", "none");
                    $("#refry2").css("display", "none");
                    $("#vidrios").css("display", "none");
                    $("#pana").css("display", "none");
                    $("#ficha").css("display", "none");
                    // inline-block
                    //divProdTemp
                    ///Producto
                    break;
                case 1:


                    $("#encabezado").val("Sistema de refrigeración 1")
                    $("#divProdTemp").css("display", "none");
                    $("#refry1").css("display", "block");
                    $("#refry2").css("display", "none");
                    $("#vidrios").css("display", "none");
                    $("#pana").css("display", "none");
                    $("#ficha").css("display", "none");
                    //
                    //Refrigeracion
                    break;

                case 2:


                    $("#encabezado").val("Sistema de refrigeración 2")
                    $("#divProdTemp").css("display", "none");
                    $("#refry1").css("display", "none");
                    $("#refry2").css("display", "block");
                    $("#vidrios").css("display", "none");
                    $("#pana").css("display", "none");
                    $("#ficha").css("display", "none");
                    //
                    //Refrigeracion
                    break;
                
                case 3:
                    ///Vidrios
                    $("#encabezado").val("Vidrios")
                    $("#vidrios").css("display", "block");
                    $("#divProdTemp").css("display", "none");
                    $("#refry1").css("display", "none");
                    $("#refry2").css("display", "none");
                    $("#pana").css("display", "none");
                    $("#ficha").css("display", "none");
                    break;
                case 4:
                    ///Vidrios
                    $("#encabezado").val("Pana")
                    $("#vidrios").css("display", "none");
                    $("#divProdTemp").css("display", "none");
                    $("#refry1").css("display", "none");
                    $("#refry2").css("display", "none");
                    $("#pana").css("display", "block");
                    $("#ficha").css("display", "none");
                    break;
                case 5:
                    ///Vidrios
                    $("#encabezado").val("Pana")
                    $("#vidrios").css("display", "none");
                    $("#divProdTemp").css("display", "none");
                    $("#refry1").css("display", "none");
                    $("#refry2").css("display", "none");
                    $("#pana").css("display", "none");
                    $("#ficha").css("display", "block");
                    break;
            }
            return false;
        }

    </script>


</asp:Content>
