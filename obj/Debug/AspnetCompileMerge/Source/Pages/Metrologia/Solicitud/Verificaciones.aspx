<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="Verificaciones.aspx.vb" Inherits="TranscoldPruebasWeb2.Verificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">

    <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Recepcion</b>
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
                                    <small>Modelo</small>
                                    <asp:TextBox ID="tbModeloFiltro" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                                <div class="col-lg-2">
                                    <small>WO.</small>
                                    <asp:TextBox ID="tbWOFiltro" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                                <div class="col-lg-2">
                                    <small>Serie</small>
                                    <asp:TextBox ID="tbSerieFiltro" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                                <div class="col-lg-2">
                                    <small>Camara</small>

                                    <asp:TextBox ID="tbCamaraFiltro" runat="server" CssClass="form-control"></asp:TextBox>

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
                                            <small>Tipo</small>
                                            <asp:DropDownList ID="ddlTipoEntrada" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoEntrada_SelectedIndexChanged">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>Electrico</asp:ListItem>
                                                <asp:ListItem>Flujo de aire</asp:ListItem>

                                            </asp:DropDownList>

                                        </div>

                                        <div class="col-lg-2">

                                            <small>Solicitud</small>
                                            <asp:TextBox ID="tbCodigo" runat="server"  CssClass="form-control"></asp:TextBox>

                                        </div>

                                        <div class="col-lg-3">

                                            <small>Equipo</small>
                                            <asp:DropDownList runat="server"
                                                CssClass="js-example-theme-single form-control"
                                                ID="ddlInstrumentos" AutoPostBack="False" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-3">
                                            <small>Camara</small>
                                            <asp:DropDownList runat="server"
                                                CssClass="js-example-theme-single form-control"
                                                ID="ddlEstacionCamara" AutoPostBack="False" AppendDataBoundItems="True">
                                            </asp:DropDownList>


                                        </div>
                                    </div>
                                    <hr />

                                    <div class="row">
                                        <div class="col-lg-2">
                                            <asp:Label ID="lblP1" CssClass="text-sm" runat="server"></asp:Label>
                                            <asp:TextBox ID="tbP1" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>

                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Label ID="lblP2" CssClass="text-sm" runat="server"></asp:Label>
                                            <asp:TextBox ID="tbP2" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>

                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Label ID="lblP3" CssClass="text-sm" runat="server"></asp:Label>
                                            <asp:TextBox ID="tbP3" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>

                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Label ID="lblP4" CssClass="text-sm" runat="server"></asp:Label>
                                            <asp:TextBox ID="tbP4" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>

                                        </div>



                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-lg-2">
                                            <asp:Label ID="lblP5" CssClass="text-sm" runat="server"></asp:Label>
                                            <asp:TextBox ID="tbP5" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>

                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Label ID="lblP6" CssClass="text-sm" runat="server"></asp:Label>
                                            <asp:TextBox ID="tbP6" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>

                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Label ID="lblP7" CssClass="text-sm" runat="server"></asp:Label>
                                            <asp:TextBox ID="tbP7" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>

                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Label ID="lblP8" CssClass="text-sm" runat="server"></asp:Label>
                                            <asp:TextBox ID="tbP8" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>

                                        </div>

                                        <div class="col-lg-2">
                                            <asp:Label ID="lblP9" CssClass="text-sm" runat="server"></asp:Label>
                                            <asp:TextBox ID="tbP9" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>

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

                                <div class="card-body text-sm">
                                    <table  class="table-responsive table table-bordered table-hover table-sm">

                                        <tbody>

                                            <asp:Repeater ID="RepeaterTabla" runat="server" OnItemCommand="RepeaterTabla_ItemCommand">
                                                <ItemTemplate>


                                                    <tr class="bg-gradient-navy text-white" runat="server" visible='<%# If(Eval("ID") = "0", True, False)%>'>
                                                        <td></td>
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


                                                    <tr class="bg-gradient-navy text-white" runat="server" visible='<%# If(Eval("ID") = "-1", True, False)%>'>
                                                        <td></td>
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
                                                        <td>
                                                            <asp:LinkButton runat="server" CssClass="fa  fa-trash" ID="lbtnEliminarRepeat" CommandArgument='<%# Eval("ID") %>' CommandName="eliminarVerificacion" OnClientClick="return confirm('¿Realmente desea eliminar el registro?')">

                                                            </asp:LinkButton>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:LinkButton runat="server" CssClass="fa  fa-edit " ID="lbtnModificarRepeat" CommandArgument='<%# Eval("ID") %>' CommandName="editarVerificacion">

                       </asp:LinkButton>


                                                        </td>
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
                                                        <td>
                                                            <asp:LinkButton runat="server" CssClass="fa  fa-trash" ID="LinkButton1" CommandArgument='<%# Eval("ID") %>' CommandName="eliminarVerificacion" OnClientClick="return confirm('¿Realmente desea eliminar el registro?')">

                                                            </asp:LinkButton>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:LinkButton runat="server" CssClass="fa  fa-edit " ID="LinkButton2" CommandArgument='<%# Eval("ID") %>' CommandName="editarVerificacion">

                       </asp:LinkButton>


                                                        </td>
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

                                        </tbody>
                                        <table />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="lbtnCancelar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="ddlTipoEntrada" EventName="SelectedIndexChanged" />
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
