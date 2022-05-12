<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="PruEventos.aspx.vb" Inherits="TranscoldPruebasWeb2.PruEventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
    <div class="content-wrapper">
        <section class="content">

            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">

                        
                        <div class="card-tools">
                            <b class="text-info">Eventos de prueba</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>
                          
                        </div>


                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="upEventos" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                           
                        <div class="row">
                            <div class="col-sm-2">
                                <small>Cod. Solicitud</small>
                                <asp:TextBox ID="tbCodigo" CssClass="form-control" OnTextChanged="tbCodigo_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                            </div>
                             <div class="col-sm-2">
                                <small>Evento</small>
                                 <asp:DropDownList ID="ddlEventos" CssClass="form-control" runat="server">
                                     <asp:ListItem>INICIO</asp:ListItem>
                                     <asp:ListItem>FIN</asp:ListItem>
                                 </asp:DropDownList>
                              </div>
                             <div class="col-sm-2">
                                <small>Fechas</small>
                                 <asp:TextBox ID="tbFecha" CssClass="form-control" TextMode="DateTimeLocal" runat="server"></asp:TextBox>
                              </div>
                            <div class="col-sm-3">
                                <small>Tipo Ensayo</small>
                                 <asp:DropDownList ID="ddlEnsayo" CssClass="form-control" runat="server">
                                 </asp:DropDownList>
                              </div>
                            <div class="col-sm-2">
                                <br />
                                <asp:LinkButton ID="lbtnGuardar" CssClass="fa fa-2x fa-save "  OnClick="lbtnGuardar_Click" runat="server"></asp:LinkButton>
                                
                             </div>
                        </div>
                                <div class="table-responsive row">
                                    <table id="tt" class="table-sm table-bordered table-hover table">
                                        <thead class="bg-gradient-navy">
                                            <tr>
                                                <th></th>
                                                <th>Tipo</th>
                                                <th>Tipo Ensayo</th>
                                                <th>Fecha</th>
                                                <th>Usuario</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="repeaterPruebas" OnItemCommand="repeaterPruebas_ItemCommand" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="LinkButton1" CssClass="fa fa-trash" runat="server" CommandName="Eli" CommandArgument='<%# Eval("id") %>'  OnClientClick="return confirm('¿Esta seguro de eliminar este registro?')" ></asp:LinkButton>
                                                        </td>
                                                        <td><%# Eval("Descriptor") %></td>
                                                        <td><%# Eval("Tipo_Ensayo") %></td>
                                                        <td><%# Eval("Fecha") %></td>
                                                        <td><%# Eval("Usuario") %></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                                 </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="tbCodigo" EventName="TextChanged" />
                                <asp:AsyncPostBackTrigger ControlID="repeaterPruebas" EventName="ItemCommand" />
                            </Triggers>
                        </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </section>
        </div>
</asp:Content>
