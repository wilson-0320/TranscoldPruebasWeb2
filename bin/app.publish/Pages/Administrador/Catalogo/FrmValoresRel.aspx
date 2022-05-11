<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="FrmValoresRel.aspx.vb" Inherits="TranscoldPruebasWeb2.FrmValoresRel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
         <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Valores relacionados</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>

                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="upElementosRelacionados" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:HiddenField ID="hfID" runat="server" />
                                <asp:HiddenField ID="hfQuery" runat="server" />
                                <asp:HiddenField ID="hfIDCategoria" runat="server" />
                                <asp:HiddenField ID="hfIDElemento" runat="server" />
                          
                        <div class="row">
                            <div class="col-sm-3">
                                <small>Categoria</small>
                                <asp:DropDownList ID="ddlCategoria" CssClass="js-example-theme-single form-control" AutoPostBack="true"  OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-sm-2">
                                <small>Elemento</small>
                                <asp:DropDownList ID="ddlElemento" CssClass="js-example-theme-single form-control" AutoPostBack="true"  OnSelectedIndexChanged="ddlElemento_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-sm-2">
                                <small>Valor</small>
                                <asp:TextBox ID="tbValor" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <small>Valor_ relacionado</small>
                                <asp:TextBox ID="tbValorRelacionado" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                                <br />
                                <asp:LinkButton ID="lbtnGuardar" runat="server" CssClass="fa fa-2x fa-save" OnClick="lbtnGuardar_Click"></asp:LinkButton>
                                 <asp:LinkButton ID="lbtnCancelar" runat="server" CssClass="fa fa-2x fa-minus" OnClick="lbtnCancelar_Click"></asp:LinkButton>
                            </div>
                        </div>
                                <br />
                        <div class="table-responsive">
                            <table id="tt" class="table table-sm table-bordered">
                                <thead class="bg-gradient-navy">
                                    <tr>
                                        <th></th>
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
                                                       
                                                        <asp:LinkButton ID="LinkButton3" runat="server"  OnClientClick="return confirm('¿Realmente desea eliminar el registro?')" CommandArgument='<%# Eval("ID") %>' CommandName="Eli" CssClass="fa fa-trash" ></asp:LinkButton>
                                                      
                                                </td>
                                                <td><%# Eval("valor") %></td>
                                                 <td><%# Eval("valor_rel") %></td>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    
                                    </tbody>
                            </table>
                        </div>
                                  </ContentTemplate>
                            <Triggers>
                              
                                <asp:AsyncPostBackTrigger ControlID="lbtnCancelar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="repeaterElementos" EventName="ItemCommand" />
                                <asp:AsyncPostBackTrigger ControlID="ddlCategoria" EventName="SelectedIndexChanged" />
                              
                            </Triggers>
                        </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </section>
         </div>
</asp:Content>
