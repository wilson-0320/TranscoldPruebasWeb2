<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="Catalogos.aspx.vb" Inherits="TranscoldPruebasWeb2.Catalogos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
    <div class="content-wrapper">
        <section class="content">
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
                    <asp:UpdatePanel ID="upCatalogo" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-sm-6">
                                <small>Categoria</small>
                                <asp:DropDownList ID="ddlCategoria"  CssClass="js-example-theme-single form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <small>Descripcion</small>
                                    <asp:TextBox ID="tbDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    <small>Archivos</small>
                                    <asp:FileUpload ID="fuArchivo" runat="server" CssClass="form-control" />
                                </div>
                                <div class="col-sm-1">
                                    <small>Vigente</small>
                                    <asp:CheckBox ID="cbVigente" CssClass="form-check" runat="server" />
                                </div>
                                <div class="col-sm-2">
                                    <br />
                                    <asp:LinkButton ID="lbtnGuardar" OnClick="lbtnGuardar_Click" CssClass="fa fa-2x fa-save" runat="server"></asp:LinkButton>
                                    &nbsp;
                                    &nbsp;
                                    <asp:LinkButton ID="lbtnCancelar" OnClick="lbtnCancelar_Click" CssClass="fa fa-2x fa-minus" runat="server"></asp:LinkButton>
                                </div>
                            </div>

                        </div>
                        
                                <asp:HiddenField ID="hfID" runat="server" />
                                  <asp:HiddenField ID="hfIDCategoria" runat="server" />
                                <div class="table-responsive">
                                    <table id="tt" class="table table-sm table-bordered">
                                        <thead class="bg-gradient-navy">
                                            <tr>
                                            <th></th>
                                            <th>Num</th>
                                            <th>Descripcion</th>
                                            <th>Vigente</th>
                                                </tr>
                                        </thead>
                                        <tbody>

                                            <asp:Repeater ID="repeaterCatalogo" runat="server" OnItemCommand="repeaterCatalogo_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" CssClass="fa  fa-edit" ></asp:LinkButton>
                                                       
                                                            <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Eli"  OnClientClick="return confirm('¿Realmente desea eliminar el registro?')" CssClass="fa fa-trash" ></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Num") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Descripcion") %>
                                                        </td>
                                                        <td>
                                                            <input type="checkbox"  <%# if(Eval("Vigente") = "1", "Checked", "") %> />
                                                        </td>
                                                        
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>



                                        </tbody>
                                    </table>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="ddlCategoria" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="repeaterCatalogo" EventName="ItemCommand" />
                            </Triggers>
                        </asp:UpdatePanel>


                    
                </div>
            </div>
        </section>
    </div>
</asp:Content>
