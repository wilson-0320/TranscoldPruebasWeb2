<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="Solicitud.aspx.vb" Inherits="TranscoldPruebasWeb2.Solicitud" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
    
    <div class="content-wrapper">

        <!-- Main content -->
        <section class="content">
            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Solicitud de prueba R-ID-00-002</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>
                        <div class="row">
                            <div class="cols-sm-2 btn btn-default">
                                <small>Cambios</small><br />
                                <asp:ImageButton ID="ibtnCambios" runat="server" ImageUrl="~/Content/Estaticos/cambios.png" OnClick="ibtnCambios_Click" ToolTip="linea de tiempo" />

                            </div>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                         <div class="cols-sm-2 btn btn-default">
                             <small>Linea de tiempo</small><br />
                             <asp:ImageButton ID="ibtnLinea" runat="server" ImageUrl="~/Content/Estaticos/linea.png" OnClick="ibtnLinea_Click" ToolTip="linea de tiempo" />

                         </div>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                         <div class="cols-sm-2 btn btn-default">
                             <small>Termopares</small><br />
                             <asp:ImageButton ID="ibtnTermopares" OnClick="ibtnTermopares_Click" runat="server" ImageUrl="~/Content/Estaticos/termopares.png" ToolTip="Asignacion de termopares" />

                         </div>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                         <div class="cols-sm-2 btn btn-default">
                             <small>Panel</small><br />
                             <asp:ImageButton ID="ibtnTab" runat="server" OnClick="ibtnTab_Click" ImageUrl="~/Content/Estaticos/dashboard.png" ToolTip="Tab Panel" />

                         </div>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        <div class="cols-sm-2 btn btn-default">
                            <small>Rep. Prueba</small><br />
                            <asp:ImageButton ID="ibtnReportePruebas" runat="server" OnClick="ibtnReportePruebas_Click" ImageUrl="~/Content/Estaticos/reportePruebas.png" ToolTip="Visor de pruebas" />

                        </div>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                         <div class="cols-sm-2 btn btn-default">
                             <small>Rep. Solicitud</small><br />
                             <asp:ImageButton ID="ibtnReporteSolicitud" runat="server" OnClick="ibtnReporteSolicitud_Click" ImageUrl="~/Content/Estaticos/reporteSolicitud.jpg" ToolTip="reporte solicitud" />

                         </div>
                       
                         <div class="cols-sm-2 btn btn-default" style="display:none;">
                             <small>Pruebas</small><br />
                             <asp:ImageButton ID="ibtnGraficas" runat="server" Visible="false" OnClick="ibtnGraficas_Click" ImageUrl="~/Content/Estaticos/02.jpg" ToolTip="Visor de pruebas" />

                         </div>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        <div class="cols-sm-2 btn btn-default">
                            <small>CheckList</small><br />
                            <asp:ImageButton ID="ibtnCheck" data-target="#modal-default" runat="server" OnClick="ibtnCheck_Click" ImageUrl="~/Content/Estaticos/reportePruebas.png" ToolTip="Check list de procedimientos" />


                        </div>


                        </div>


                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="upSolicitud" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                
                                <div class="row">

                                    <div class="col-sm-2">
                                        <small>Codigo</small>
                                        <asp:Label ID="lblCodigo" runat="server" Text="-" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>Estado</small>

                                        <asp:DropDownList ID="ddlEstadoB" runat="server" OnSelectedIndexChanged="ddlEstadoB_SelectedIndexChanged" CssClass="form-control" AutoPostBack="True" AppendDataBoundItems="True">
                                            <asp:ListItem>Nueva</asp:ListItem>
                                            <asp:ListItem>Pruebas</asp:ListItem>
                                            <asp:ListItem>Finalizada</asp:ListItem>
                                        </asp:DropDownList>


                                    </div>
                                    <div class="col-sm-2">
                                        <small>Locacion</small>
                                        <asp:DropDownList ID="LocacionDropDownList" runat="server" Width="115px"
                                            Enabled="False">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem Selected="True">Guatemala</asp:ListItem>
                                            <asp:ListItem>Colombia</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4 form-inline">


                                        <asp:LinkButton ID="lbtnNotificarCreacion" Visible="FALSE" runat="server" CssClass="fa fa-2x fa-mail-bulk" ToolTip="Notificar Creacion"></asp:LinkButton>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton ID="lbtnNotificarModificacion" Visible="FALSE" runat="server" CssClass="fa fa-2x fa-mail-bulk" ToolTip="Notificar Modificacion"></asp:LinkButton>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton ID="lbtnLimpiar" runat="server" CssClass="fa fa-2x fa-minus" ToolTip="Limpiar" OnClick="lbtnLimpiar_Click"></asp:LinkButton>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton ID="lbtnGuardarSolicitud" runat="server" CssClass="fa fa-2x fa-save" ToolTip="Guardar Solicitud" OnClick="lbtnGuardarSolicitud_Click"></asp:LinkButton>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton ID="lbtnEliminar" runat="server" CssClass="fa fa-2x fa-trash " ToolTip="Eliminar" OnClick="lbtnEliminar_Click"></asp:LinkButton>

                                    </div>




                                </div>

                                <div class="row">

                                    <div class="col-sm-1">
                                        <small>Consec.</small>
                                        <asp:Label ID="lblConsectivo" runat="server" Text="-" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <small>Fecha Solicitud</small>
                                        <asp:Label ID="lblFechaCreacion" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <small>Modelo</small>
                                        <asp:TextBox ID="tbModelo" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3">
                                        <small>Lider de proy.</small>
                                        <asp:DropDownList ID="ddlLider" runat="server" CssClass="js-example-theme-single form-control" AutoPostBack="false" AppendDataBoundItems="True">
                                        </asp:DropDownList>
                                    </div>
                                    &nbsp;&nbsp;&nbsp;
                            <div class="col-sm-3">
                                <small>Encargado</small>
                                <asp:DropDownList ID="ddlEncargado" runat="server" CssClass="js-example-theme-single  form-control" AutoPostBack="false" AppendDataBoundItems="True">
                                </asp:DropDownList>

                            </div>

                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <small>Objetivos de solicitud</small>
                                        <asp:TextBox ID="tbObjetivosSolicitud" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-2">
                                        <small>Cantidad</small>
                                        <asp:TextBox ID="tbCantidad" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-2">
                                        <small>Ref. de proveedor.</small>
                                        <asp:TextBox ID="tbRProveedor" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-2">
                                        <small>Ref. de Fogel.</small>
                                        <asp:TextBox ID="tbRFogel" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-4">
                                        <small>Modelo/Serie/W.O. de la muestra</small>
                                        <div class="row">
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="tbModeloM" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="col-sm-4">
                                                <asp:TextBox ID="tbSerieM" OnTextChanged="tbSerieM_TextChanged" AutoPostBack="true" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="tbWoM" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <small>Fecha de entrega</small>
                                        <asp:TextBox ID="tbFechaEntrega" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <small>CÓDIGO Y PARÁMETROS DEL TERMOSTATO PARA LA PRUEBA: (SET POINTS, DIFERENCIAL, POSICIÓN PERILLA, ETC.)
Descripción precisa es requerida. Evite descripciones tales como "la del estándar", "la tradicional", etc.</small>
                                        <asp:TextBox ID="tbParametroTermostato" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <small>Disposición final de la(s) muestra(s) o del equipo sometidos a pruebas:</small>
                                        <asp:TextBox ID="tbDisposisionFinal" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <small>Comentarios, observaciones y condiciones especiales de las muestras, equipos o pruebas:</small>
                                        <asp:TextBox ID="tbComentariosEspeciales" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <small>Tipo de carga a usar en pruebas de refrigeracion (Si aplica):</small>
                                        <asp:DropDownList ID="ddlCarga" runat="server" CssClass="js-example-theme-single" AutoPostBack="False" AppendDataBoundItems="True"></asp:DropDownList>



                                    </div>
                                </div>

                                <br />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardarSolicitud" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="lbtnLimpiar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="tbSerieM" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <asp:UpdatePanel ID="upEnsayos" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:HiddenField ID="hfQueryEnsayos" runat="server" />
                                <div>
                                    <div class="row">
                                        <small class="text-info">Ensayos solicitudos (Según Anexo 1)</small>
                                        <div class="col-sm-12">
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <small>Ensayos:</small>
                                                    <asp:DropDownList ID="ddlEnsayos" runat="server" CssClass="js-example-theme-single" AutoPostBack="false" AppendDataBoundItems="True"></asp:DropDownList>
                                                </div>
                                                <div class="col-sm-2">
                                                    <asp:LinkButton ID="lbtnGuardarEnsayos" OnClick="lbtnGuardarEnsayos_Click" runat="server" CssClass="fa fa-2x fa-save">
                                                    </asp:LinkButton>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row table-responsive">
                                        <table class="table table-sm table-bordered">
                                            <thead class="bg-gradient-navy">
                                                <th></th>
                                                <th>Descripcion</th>
                                                <th>Prueba</th>
                                                <th>Archivo</th>
                                            </thead>
                                            <tbody>


                                                <asp:Repeater ID="repeaterEnsayos" runat="server" OnItemCommand="repeaterEnsayos_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Eli" CommandArgument='<%# Eval("ID") %>' CssClass="fa fa-trash"></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <%# Eval("Descripcion") %>
                                                            </td>
                                                            <td>
                                                                <%# Eval("Prueba") %>
                                                            </td>
                                                            <td>
                                                                <a href="<%# Eval("Archivo") %>" target="_blank">Archivo</a>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardarEnsayosContratos" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="repeaterEnsayos" EventName="ItemCommand" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <br />
                        <asp:UpdatePanel ID="upEnsayosOfrecidos" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div>
                                    <div class="row">
                                        <small class="text-info">Contrato de ensayo (Elaborado por el Jefe de I&D) Ensayos ofrecidos</small>
                                        <div class="col-sm-12">
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <small>Ensayos:</small>
                                                    <asp:DropDownList ID="ddlEnsayosOfrecidos" runat="server" CssClass="js-example-theme-single" AutoPostBack="false" AppendDataBoundItems="True">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-2">
                                                    <asp:LinkButton ID="lbtnGuardarEnsayosContratos" OnClick="lbtnGuardarEnsayosContratos_Click" runat="server" CssClass="fa fa-2x fa-save">
                                            
                                                    </asp:LinkButton>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row table-responsive">
                                        <table class="table table-sm table-bordered">
                                            <thead class="bg-gradient-navy">
                                                <th></th>
                                                <th>Descripcion</th>
                                                <th>Prueba</th>
                                                <th>Archivo</th>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="repeaterEnsayosContratados" OnItemCommand="repeaterEnsayosContratados_ItemCommand" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Eli" CommandArgument='<%# Eval("ID") %>' CssClass="fa  fa-trash"></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <%# Eval("Descripcion") %>
                                                            </td>
                                                            <td>
                                                                <%# Eval("Prueba") %>
                                                            </td>
                                                            <td>
                                                                <a href="<%# Eval("Archivo") %>" target="_blank">Archivo</a>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardarEnsayosContratos" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="repeaterEnsayosContratados" EventName="ItemCommand" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <br />
                        <asp:UpdatePanel ID="upDivision" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>


                                <div>
                                    <div class="row">
                                        <small class="text-info">Divisiones de equipo</small>
                                        <div class="col-sm-12">
                                            <div class="row">
                                                <div class="col-sm-1 form-inline">

                                                    <small>Division:</small>
                                                </div>
                                                <div class="col-sm-5">
                                                    <asp:TextBox ID="tbDivision" runat="server" CssClass="form-control"></asp:TextBox>


                                                </div>
                                                <div class="col-sm-2">
                                                    <asp:LinkButton ID="lbtnGuardarDivision" OnClick="lbtnGuardarDivision_Click" runat="server" CssClass="fa fa-2x fa-save ">
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row table-responsive">
                                        <table class="table table-sm table-bordered">
                                            <thead class="bg-gradient-navy">
                                                <tr>
                                                    <th></th>
                                                    <th>Division</th>
                                                    <th>QR</th>
                                                </tr>
                                            </thead>
                                            <tbody>


                                                <asp:Repeater ID="repeaterDivision" OnItemCommand="repeaterDivision_ItemCommand" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="fa fa-trash" CommandArgument='<%# Eval("id") %>' CommandName="Eli"></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <%# Eval("Descripcion") %>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="LinkButton3" runat="server" CssClass="fa fa-qrcode" data-target="#modal-default" CommandArgument='<%# Eval("id") %>' CommandName="QR"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>

                                <div class="modal fade" id="modal" name="modal">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h4 class="modal-title">QR</h4>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body text-center">
                                                <h5><%= lblCodigo.Text %></h5>
                                                <small><%= tbModeloM.Text %></small>
                                                <br />
                                                <small><%= tbSerieM.Text %></small>
                                                <br />
                                                <asp:Image ID="imgqr" runat="server" />
                                            </div>
                                            <div class="modal-footer justify-content-between">
                                                <small class="text-danger">Recorta la imagen, imprime y pega en el equipo</small>
                                            </div>
                                        </div>
                                    </div>
                                </div>





                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardarDivision" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="repeaterDivision" EventName="ItemCommand" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <div class="modal fade" id="modalCheck" name="modal" data-backdrop="static">
                            <div class="modal-dialog modal-xl">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">CheckList</h4>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <asp:UpdatePanel ID="upCheck" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:HiddenField ID="hfIDEnsayoPrueba" runat="server" />
                                                <asp:HiddenField ID="hfTipoInicioFin" runat="server" />
                                                <asp:HiddenField ID="hfNum" runat="server" />
                                                <asp:HiddenField ID="hfIDRequerimiento" runat="server" />
                                                <asp:HiddenField ID="hfIDCheck" runat="server" />
                                                <asp:HiddenField ID="hfQueryCheck" runat="server" />
                                                <div id="0">
                                                    <div class="row">


                                                        <div class="col-sm-7">

                                                            <small>Ensayos</small>
                                                            <asp:DropDownList ID="ddlPruebasEventos" CssClass="js-example-theme-single form-control " runat="server"></asp:DropDownList>

                                                        </div>
                                                        <div class="col-sm-3">
                                                            <small>Tipo</small>
                                                            <asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="true" CssClass="js-example-theme-single form-control" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged">
                                                                <asp:ListItem>INICIO</asp:ListItem>
                                                                <asp:ListItem>FIN</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-2">

                                                            <asp:LinkButton ID="lbtnProcesar" OnClick="lbtnProcesar_Click" runat="server" CssClass="fa fa-2x fa-running"></asp:LinkButton>
                                                        </div>

                                                    </div>
                                                </div>
                                                <hr />
                                                <div class="row">
                                                    <div class="col-sm-10">
                                                        <asp:Label ID="lblRequisito" CssClass="text-sm text-info" runat="server" Text=""></asp:Label>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <asp:Label ID="lblEstadoCheck" CssClass="text-sm text-success" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <asp:ListBox ID="lbOpciones" CssClass="js-example-theme-single form-control"  SelectionMode="Multiple"   multiple="multiple"   runat="server"></asp:ListBox>
                                                        <asp:TextBox ID="tbOpciones" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <small>Elección realizada: </small>
                                                        <asp:Label ID="lblEleccion" runat="server" CssClass="text-sm text-danger" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;
                                                        <small>Usuario: </small>
                                                        <asp:Label ID="lblUsuarioCheck" runat="server" CssClass="text-sm text-primary" Text=""></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="modal-footer ">
                                                    <div class="justify-content-between">


                                                        <asp:LinkButton ID="lbtnAnterior" OnClick="lbtnAnterior_Click" CssClass="fa fa-2x  fa-arrow-alt-circle-left" runat="server"></asp:LinkButton>
                                                    </div>
                                                    <div class="justify-content-md-end">


                                                        <asp:LinkButton ID="lbtnSiguiente" OnClick="lbtnSiguiente_Click" CssClass="fa fa-2x  fa-arrow-alt-circle-right" runat="server"></asp:LinkButton>
                                                    </div>

                                                </div>


                                            </ContentTemplate>

                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ibtnCheck" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="lbtnProcesar" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="lbtnSiguiente" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlTipo" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="lbtnAnterior" EventName="Click" />
                                            </Triggers>

                                        </asp:UpdatePanel>
                                    </div>

                                </div>
                            </div>
                        </div>



                    </div>
                </div>



            </div>

        </section>

    </div>


</asp:Content>
