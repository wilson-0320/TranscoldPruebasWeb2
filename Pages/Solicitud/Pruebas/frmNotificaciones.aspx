<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="frmNotificaciones.aspx.vb" Inherits="TranscoldPruebasWeb2.frmNotificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
    <div class="content-wrapper">
        <section class="content">

            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Programación de notificaciones</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>


                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="upPanelNotificaciones" runat="server" UpdateMode="Conditional">

                            <ContentTemplate>
                        <div class="row">
                            <div class="col-sm-3">
                                <small>Codigo</small>
                                <asp:TextBox ID="tbCodigo" OnTextChanged="tbCodigo_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                            </div>
                            <div class="col-sm-3">
                                <small>Catalogo</small>
                                <asp:DropDownList ID="ddlCatalogoDisponible"
                                    runat="server" CssClass="js-example-theme-single  form-control"
                                    AutoPostBack="false" AppendDataBoundItems="True" ></asp:DropDownList>

                            </div>
                            <div class="col-sm-2">
                                <asp:LinkButton ID="lbtnAgregar" OnClick="lbtnAgregar_Click" CssClass="fa fa-save fa-2x" runat="server"></asp:LinkButton>

                            </div>
                        </div>

                        
                                <asp:Repeater ID="repeaterNotificaciones" OnItemCommand="repeaterNotificaciones_ItemCommand" runat="server">
                                    <HeaderTemplate>
                                        <table id="tt" class="table table-sm table-bordered">
                                            <thead class="bg-gradient-navy">
                                                
                                                <tr>
                                                    <th></th>
                                                <th>tipo
                                                </th>
                                                <th>minimo
                                                </th>
                                                <th>maximo
                                                </th>
                                                    <th>Fecha
                                                </th>
                                                    <th>Usuario
                                                </th>
                                                    <th>Estado
                                                </th>
                                                    </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="LinkButton1" runat="server"
                                                    CommandName="Edi"
                                                    CommandArgument='<%# Eval("id") %>'
                                                    CssClass="fa fa-edit">

                                                </asp:LinkButton>

                                                <asp:LinkButton ID="LinkButton2" runat="server"
                                                    CommandName="Eli"
                                                    CommandArgument='<%# Eval("id") %>'
                                                    CssClass="fa fa-trash">

                                                </asp:LinkButton>
                                            </td>
                                            <td>
                                                <%# Eval("tipo") %>
                                            </td>
                                            <td>
                                                <%# Eval("menorA") %>
                                            </td>
                                            <td>
                                                <%# Eval("mayorA") %>
                                            </td>
                                            <td>
                                                <%# Eval("fecha") %>
                                            </td>
                                            <td>
                                                <%# Eval("usuario") %>
                                            </td>
                                            <td>
                                                <%# Eval("estado") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>

                            

                    </div>
                                </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="tbCodigo" EventName="TextChanged" />
                                <asp:AsyncPostBackTrigger ControlID="lbtnAgregar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="lbtnCancelar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="repeaterNotificaciones" EventName="ItemCommand" />
                            </Triggers>

                        </asp:UpdatePanel>
                </div>
            </div>
        </section>
    </div>

    <div class="modal fade" id="modalNot" name="modal" data-backdrop="static">
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
                            <asp:HiddenField ID="hfID" runat="server" />
                            <asp:HiddenField ID="hfIDCat" runat="server" />
                            <asp:HiddenField ID="hfQuery" runat="server" />

                            <div class="row">
                                <div class="col-sm-4">
                                    <small>Tipo</small><br />
                                    <asp:Label ID="lblTipo" CssClass="small" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <small>Minimo</small>
                                        <asp:TextBox ID="tbMin" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <small>Maximo</small>
                                        <asp:TextBox ID="tbMax" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                </div>
                            </div>


                            <div class="modal-footer ">

                                <div class="justify-content-md-end">
                                    <asp:LinkButton ID="lbtnGuardar" OnClick="lbtnGuardar_Click" CssClass="fa fa-2x  fa-save" runat="server"></asp:LinkButton>

                                    &nbsp;&nbsp;&nbsp;
                                                      <asp:LinkButton ID="lbtnCancelar" OnClick="lbtnCancelar_Click" CssClass="fa fa-minus fa-2x" runat="server"></asp:LinkButton>
                                </div>

                            </div>


                        </ContentTemplate>

                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="lbtnCancelar" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="repeaterNotificaciones" EventName="ItemCommand" />
                            <asp:AsyncPostBackTrigger ControlID="lbtnAgregar" EventName="Click" />
                        </Triggers>

                    </asp:UpdatePanel>
                </div>

            </div>
        </div>
    </div>

</asp:Content>

