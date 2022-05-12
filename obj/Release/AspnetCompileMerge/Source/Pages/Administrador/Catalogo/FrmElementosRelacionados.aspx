<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="FrmElementosRelacionados.aspx.vb" Inherits="TranscoldPruebasWeb2.FrmElementosRelacionados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
     <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Elementos relacionados</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>

                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="upElementosRelacionados" runat="server">
                            <ContentTemplate>
                                <asp:HiddenField ID="hfID" runat="server" />
                                <asp:HiddenField ID="hfQuery" runat="server" />
                                <asp:HiddenField ID="hfIDElemento" runat="server" />
                                <asp:HiddenField ID="hfIDElementoRelacionado" runat="server" />
                          
                        <div class="row">
                            <div class="col-sm-3">
                                <small>Elemento</small>
                                <asp:DropDownList ID="ddlElemento" CssClass="js-example-theme-single form-control" AutoPostBack="true"  OnSelectedIndexChanged="ddlElemento_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-sm-3">
                                <small>Elemento Rel.</small>
                                <asp:DropDownList ID="ddlElementoRelacionado" CssClass="js-example-theme-single form-control" AutoPostBack="true"  OnSelectedIndexChanged="ddlElementoRelacionado_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-sm-2">
                                <small>Elemento</small>
                                <asp:TextBox ID="tbValor" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                                <small>Elemento</small>
                                <asp:TextBox ID="tbValorRelacionado" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                                <br />
                                <asp:LinkButton ID="lbtnGuardar" runat="server" CssClass="fa fa-2x fa-save" OnClick="lbtnGuardar_Click"></asp:LinkButton>
                                 <asp:LinkButton ID="lbtnCancelar" runat="server" CssClass="fa fa-2x fa-minus" OnClick="lbtnCancelar_Click"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="table-responsive">
                            <table id="tt" class="table table-sm table-bordered">
                                <thead class="bg-gradient-navy">
                                    <tr>
                                        <th></th>
                                        <th>Elemento</th>
                                        <th>Elemento relacionado</th>
                                        <th>Valor</th>
                                        <th>Valor relacionado</th>
                                    </tr>
                                    
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="repeaterElementos" runat="server" OnItemCommand="repeaterElementos_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                       <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" CssClass="fa  fa-edit" ></asp:LinkButton>
                                                       
                                                        <asp:LinkButton ID="LinkButton3" runat="server"  OnClientClick="return confirm('¿Realmente desea eliminar el registro?')" CommandArgument='<%# Eval("ID") %>' CommandName="Eli" CssClass="fa  fa-trash" ></asp:LinkButton>
                                                      
                                                </td>
                                                <td><%# Eval("elemento") %></td>
                                                 <td><%# Eval("elemento_rel") %></td>
                                                 <td><%# Eval("valor") %></td>
                                                 <td><%# Eval("valor_rel") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    
                                    </tbody>
                            </table>
                        </div>
                                  </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="lbtnCancelar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="ddlElemento" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlElementoRelacionado" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="repeaterElementos" EventName="ItemCommand" />
                            </Triggers>
                        </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </section>
         </div>
</asp:Content>
