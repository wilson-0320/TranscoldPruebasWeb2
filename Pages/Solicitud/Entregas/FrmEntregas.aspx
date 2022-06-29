<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="FrmEntregas.aspx.vb" Inherits="TranscoldPruebasWeb2.FrmEntregas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
    <div class="content-wrapper">
        <section class="content">

            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Mantenimientos de Entregas</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>


                    </div>
                


                <div class="card-body">
                <asp:UpdatePanel ID="upCatalogoEntregas" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>

                        
                            <div class="row">
                                <div class="col-sm-6">

                                    <div class="table-responsive text-sm">
                                        <div class="row">
                                            <asp:HiddenField ID="hfIDEntregas" runat="server" />
                                            <div class="col-sm-3">
                                                <small>Entrega</small>
                                                <asp:TextBox ID="tbEntrega" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-2">
                                                <small>Dias</small>
                                                <asp:TextBox ID="tbDias" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-2">
                                                <small>Num</small>
                                                <asp:TextBox ID="tbNum" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-2">
                                                <small>Estado
                                                </small>
                                                <asp:CheckBox ID="cbEstado" CssClass="form-check" runat="server" />
                                            </div>
                                            <div class="col-sm-3">
                                                <br />
                                                <asp:LinkButton ID="lbtnGuardarEntrega" CssClass="fa fa-2x fa-save" OnClick="lbtnGuardarEntrega_Click" runat="server"></asp:LinkButton>
                                                <asp:LinkButton ID="lbtnCancelarEntrega" CssClass="fa fa-2x fa-minus" OnClick="lbtnCancelarEntrega_Click" runat="server"></asp:LinkButton>
                                            </div>
                                        </div>
                                        <asp:Repeater ID="RepeaterEntregas" runat="server"  OnItemCommand="RepeaterEntregas_ItemCommand">
                                            <HeaderTemplate>
                                                <table class="table table-bordered table-hover table-sm">
                                                    <thead class="bg-gradient-navy">
                                                        <tr>
                                                            <th></th>
                                                            <th>Entrega</th>
                                                            <th>Dias</th>
                                                            <th>Num</th>

                                                        </tr>

                                                    </thead>
                                                    <tbody>
                                            </HeaderTemplate>
                                            <FooterTemplate>
                                                </tbody>
                        </table>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edi" CommandArgument='<%# Eval("id") %>' CssClass="fa fa-edit"></asp:LinkButton>

                                                    </td>
                                                    <td><%# Eval("Entrega") %></td>
                                                    <td><%# Eval("Dias") %></td>
                                                    <td><%# Eval("N") %></td>


                                                </tr>

                                            </ItemTemplate>
                                        </asp:Repeater>



                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row">
                                        <asp:HiddenField ID="hfIDUsuarioEntrega" runat="server" />
                                        <div class="col-sm-4">
                                            <small>Entrega</small>
                                            <asp:DropDownList ID="ddlEntregas" CssClass="js-example-theme-single form-control" runat="server"></asp:DropDownList>
                                        </div>
                                        <div class="col-sm-4">
                                            <small>Usuarios</small>
                                            <asp:DropDownList ID="ddlUsuario" CssClass="js-example-theme-single form-control" runat="server"></asp:DropDownList>
                                        </div>
                                        <div class="col-sm-2">
                                            <small>Incluir
                                            </small>
                                            <asp:CheckBox ID="cbIncluir" CssClass="form-check" runat="server" />
                                        </div>
                                        <div class="col-sm-2">
                                            <br />
                                            <asp:LinkButton ID="lbtnGuardarUsuario" CssClass=" fa fa-2x fa-save" OnClick="lbtnGuardarUsuario_Click" runat="server"></asp:LinkButton>
                                            <asp:LinkButton ID="lbtnCancelarUsuario" CssClass=" fa fa-2x fa-minus" OnClick="lbtnCancelarUsuario_Click" runat="server"></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="table-responsive text-sm">

                                        <asp:Repeater ID="RepeaterUsuarioEntrega" runat="server" OnItemCommand="RepeaterUsuarioEntrega_ItemCommand">
                                            <HeaderTemplate>
                                                <table class="table table-bordered table-hover table-sm">
                                                    <thead class="bg-gradient-navy">
                                                        <tr>
                                                            <th></th>
                                                            <th>Usuario</th>
                                                            <th>Entrega</th>
                                                        </tr>

                                                    </thead>
                                                    <tbody>
                                            </HeaderTemplate>
                                            <FooterTemplate>
                                                </tbody>
                        </table>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edi" CommandArgument='<%# Eval("id") %>' CssClass="fa fa-edit"></asp:LinkButton>

                                                    </td>
                                                    <td><%# Eval("UserName") %></td>
                                                    <td><%# Eval("Entrega") %></td>



                                                </tr>

                                            </ItemTemplate>
                                        </asp:Repeater>
                                       


                                    </div>
                                </div>
                            </div>
                        
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="RepeaterEntregas" EventName="ItemCommand" />
                        <asp:AsyncPostBackTrigger ControlID="RepeaterUsuarioEntrega" EventName="ItemCommand" />
                        <asp:AsyncPostBackTrigger ControlID="lbtnGuardarUsuario" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lbtnGuardarEntrega" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lbtnCancelarUsuario" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lbtnCancelarEntrega" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                </div>
                </div>
           </div>

        </section>
    </div>
</asp:Content>
