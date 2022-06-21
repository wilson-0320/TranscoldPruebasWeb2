<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="Verificaciones.aspx.vb" Inherits="TranscoldPruebasWeb2.Verificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">

    <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Verificación de estaciones.</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>
                    </div>
                    <div class="card-body">


                        <div class="card-header bg-gradient-navy ">
                            <div class="row">

                                <div class="col-lg-1">
                                    <small>Codigo</small>

                                    <asp:TextBox ID="tbCodigoFiltro" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                                
                                
                                <div class="col-lg-2">
                                    <small>Camara</small>

                                    <asp:DropDownList ID="ddlCamaraFiltro" 
                                        CssClass="js-example-theme-single form-control"
                                        runat="server"></asp:DropDownList>

                                </div>
                                <div class="col-lg-2">
                                    <small>Magnitud</small>

                                    <asp:DropDownList ID="ddlMagnitudFiltro" 
                                        CssClass="js-example-theme-single form-control"
                                        runat="server"></asp:DropDownList>

                                </div>
                                


                                <div class="col-lg-1">
                                    <br />
                                    <asp:LinkButton ID="btnGenerar" runat="server" ToolTip="Filtrar" CssClass="fa fa-2x fa-retweet" OnClick="btnGenerar_Click">
                                        

                                    </asp:LinkButton>


                                    &nbsp;&nbsp;&nbsp;

                                   
                                </div>



                            </div>
                        </div>

                        <asp:UpdatePanel ID="upCrudVerificacion" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                                <asp:HiddenField ID="hfCodigo" runat="server" />
                                <asp:HiddenField ID="hfID" runat="server" />
                                <asp:HiddenField ID="hfQuery" runat="server" />

                                <div class="card-body">

                                    <div class="row">
                                        <div class="col-lg-2">

                                            <small>Solicitud</small>
                                            <asp:TextBox ID="tbCodigo" runat="server" CssClass="form-control"></asp:TextBox>

                                        </div>
                                        <div class="col-lg-2">
                                            <small>Magnitud</small>
                                            <asp:DropDownList ID="ddlTipoEntrada"
                                                CssClass="js-example-theme-single form-control"
                                                runat="server" >
                                            </asp:DropDownList>

                                        </div>

                                        

                                        <div class="col-lg-3">

                                            <small>Equipo</small>
                                            <asp:DropDownList runat="server"
                                                CssClass="js-example-theme-single form-control"
                                                ID="ddlInstrumentos" AutoPostBack="False" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-3">
                                            <small>Ubicación</small>
                                            <asp:DropDownList runat="server"
                                                CssClass="js-example-theme-single form-control"
                                                ID="ddlEstacionCamara" AutoPostBack="False" AppendDataBoundItems="True">
                                            </asp:DropDownList>


                                        </div>
                                    </div>
                                    <hr />

                                    <div class="row">
                                        <div class="col-lg-2">
                                            <asp:Label ID="lblP1" CssClass="text-sm" runat="server" Text="Dato medido patron"></asp:Label>
                                            <asp:TextBox ID="tbP1" CssClass="form-control" runat="server" ></asp:TextBox>

                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Label ID="lblP2" CssClass="text-sm" runat="server" Text="Dato medido Equipo" ></asp:Label>
                                            <asp:TextBox ID="tbP2" CssClass="form-control" runat="server" ></asp:TextBox>

                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Label ID="lblP3" CssClass="text-sm" runat="server" Text="Dato medido patron"></asp:Label>
                                            <asp:TextBox ID="tbP3" CssClass="form-control" runat="server" ></asp:TextBox>

                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Label ID="lblP4" CssClass="text-sm" runat="server" Text="Dato medido Equipo" ></asp:Label>
                                            <asp:TextBox ID="tbP4" CssClass="form-control" runat="server" ></asp:TextBox>

                                        </div>



                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <asp:TextBox ID="tbComentarios" runat="server" CssClass="form-control" Placeholder="comentario" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <br />
                                            <asp:LinkButton ID="lbtnGuardar" runat="server" CssClass=" fa fa-2x fa-save" OnClick="lbtnGuardar_Click">
                       
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="lbtnCancelar" runat="server" CssClass=" fa fa-2x fa-minus" OnClick="lbtnCancelar_Click">
                   
                                            </asp:LinkButton>
                                        </div>

                                    </div>
                                </div>

                                <div class="card-body text-sm ">
                                    <small>En el caso de Corriente y voltaje, realizarlo tal y como indica el encabezado, para flujo de aire ingresar los datos en orden( Izquierdo, centro y derecho)</small>
                                    <table id="tt" class="table-responsive table table-bordered table-hover table-sm">
                                        <thead class="bg-gradient-navy">
                                            <tr> <th></th><th>Solicitud</th>
                                                <th>Ubicación</th><th>Magnitud</th><th>Equipo Patron</th>
                                                <th>Medición 1</th><th>Medición 2</th><th>Medición 3</th><th>Medición 4</th>
                                                <th>Comentario</th><th>Tecnico</th><th>Realizado</th>
                                            </tr>
                                        </thead>
                                        <tbody>

                                            <asp:Repeater ID="RepeaterTabla" runat="server" OnItemCommand="RepeaterTabla_ItemCommand">
                                                <ItemTemplate>



                                                    <tr >
                                                        <td>
                                                            <asp:LinkButton runat="server" CssClass="fa  fa-trash" ID="lbtnEliminarRepeat" CommandArgument='<%# Eval("ID") %>' CommandName="Eli" OnClientClick="return confirm('¿Realmente desea eliminar el registro?')">

                                                            </asp:LinkButton>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:LinkButton runat="server" CssClass="fa  fa-edit " ID="lbtnModificarRepeat" CommandArgument='<%# Eval("ID") %>' CommandName="Edi">

                       </asp:LinkButton>


                                                        </td>
                                                        <td><%# Eval("Codigo") %> </td>
                                                        <td><%# Eval("valor") %></td>
                                                        <td><%# Eval("magnitud") %></td>
                                                        <td><%# Eval("descripcion") %></td>
                                                        <td><%# Eval("Dato1") %></td>
                                                        <td><%# Eval("Dato2") %></td>
                                                        <td><%# Eval("Dato3") %></td>
                                                        <td><%# Eval("Dato4") %></td>
                                                        <td><%# Eval("Comentario") %></td>
                                                        <td><%# Eval("Usuario") %></td>
                                                        <td><%# Eval("FechaRealiza") %></td>

                                                    </tr>



                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </tbody>
                                        <table />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="lbtnCancelar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="RepeaterTabla" EventName="ItemCommand" />

                                <asp:AsyncPostBackTrigger ControlID="btnGenerar" EventName="Click" />

                            </Triggers>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>
        </section>
    </div>


</asp:Content>
