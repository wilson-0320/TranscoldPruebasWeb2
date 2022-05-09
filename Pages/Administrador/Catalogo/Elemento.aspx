<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="Elemento.aspx.vb" Inherits="TranscoldPruebasWeb2.Elemento" %>
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
                    <div class="card-body">
                        <asp:UpdatePanel ID="updateGeneral" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:HiddenField ID="hfID" runat="server" />
                                <asp:HiddenField ID="hfIDElementos" runat="server" />
                                <asp:HiddenField ID="hfQuery" runat="server" />

                            
                        <div class="row">
                            <div class="col-sm-3">
                                <small>Tipo</small>
                                <asp:DropDownList ID="ddlCatalogo" CssClass="js-example-theme-single form-control" runat="server" OnSelectedIndexChanged="ddlCatalogo_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            </div>
                            <div class="col-sm-3">
                                <small>Descripcion</small>
                                <asp:TextBox ID="tbDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-1">
                                <small>Tipo</small>
                               <asp:DropDownList ID="ddlTipo" CssClass="form-control" runat="server">
                                   <asp:ListItem>Prueba</asp:ListItem>
                                   <asp:ListItem>Diseño</asp:ListItem>
                               </asp:DropDownList>
                            </div>
                            <div class="col-sm-1">
                                <small>Precio</small>
                                <asp:CheckBox ID="cbPrecio" runat="server" CssClass="form-check" />
                            </div>
                            <div class="col-sm-1">
                                <small>Cant.</small>
                                <asp:CheckBox ID="cbCantidad" runat="server" CssClass="form-check" />
                            </div>
                            <div class="col-sm-1">
                                <small>Unico</small>
                                <asp:CheckBox ID="cbUnico" runat="server" CssClass="form-check" />
                            </div>
                            <div class="col-sm-1">
                                <small>Exactus</small>
                                <asp:CheckBox ID="cbExactus" runat="server" CssClass="form-check" />
                            </div>
                        </div>
                        <div class="row">
                             <div class="col-sm-6">
                                <small>Valores</small>
                                <asp:TextBox ID="tbValores" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                             
                            <div class="col-sm-2">
                                <br />
                                <asp:LinkButton ID="lbtnGuardar" runat="server" CssClass="fa fa-2x fa-save" OnClick="lbtnGuardar_Click" ></asp:LinkButton>
                               <asp:LinkButton ID="lbtnCancelar" runat="server" CssClass="fa fa-2x fa-minus" OnClick="lbtnCancelar_Click" ></asp:LinkButton>
                           
                            </div>

                        </div>
                        <div class="table-responsive">
                            <br />
                            <table id="tt" class="table-sm table table-bordered tt">
                                <thead class="bg-gradient-navy">
                                    <th></th>
                                    <th>Descripcion</th>
                                    <th>Tipo</th>
                                    <th>Precio</th>
                                    <th>Cantidad</th>
                                    <th>Unico</th>
                                    <th>Exactus</th>
                                    <th>Valores</th>
                                    <th>Estado</th>
                                    <th></th>
                                    

                                </thead>
                                <tbody>
                                    <asp:Repeater ID="repeaterRegistrosProtitpos" OnItemCommand="repeaterRegistrosProtitpos_ItemCommand" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" CssClass="fa fa-edit" ></asp:LinkButton>
                                                       
                                                            <asp:LinkButton ID="LinkButton3" runat="server"  OnClientClick="return confirm('¿Realmente desea eliminar el registro?')" CommandArgument='<%# Eval("ID") %>' CommandName="Eli" CssClass="fa fa-trash" ></asp:LinkButton>
                                                      

                                                </td>
                                                <td><%# Eval("Descripcion")  %></td>
                                                <td><%# Eval("Tipo")  %></td>
                                                 <td><input type="checkbox"  <%# if(Eval("Precio"), "Checked", "")  %>/>  </td>
                                                <td><input type="checkbox"  class="form-check" <%# if(Eval("Cantidad") = "1", "Checked", "")  %>/>  </td>
                                                <td><input type="checkbox"  class="form-check" <%# if(Eval("Unico") = "1", "Checked", "") %>/>  </td>
                                                <td><input type="checkbox"  class="form-check" <%# if(Eval("CodigoEnExactus") = "1", "Checked", "")  %>/> </td>
                                               
                                                <td><%# Eval("Valores")  %></td>
                                                <td><input type="checkbox"  class="form-check" <%# if(Eval("Estado") = "1", "Checked", "")  %>/>  </td>
                                               <td>      
                                                    <asp:LinkButton ID="LinkButton2" runat="server"  CommandArgument='<%# Eval("ID")  %>' CommandName="Arriba" CssClass="fa fa-arrow-up" ></asp:LinkButton>
                                                       &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="LinkButton4" runat="server"  CommandArgument='<%# Eval("ID")  %>' CommandName="Abajo" CssClass="fa fa-arrow-down" ></asp:LinkButton>
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
                                <asp:AsyncPostBackTrigger ControlID="repeaterRegistrosProtitpos" EventName="ItemCommand" />
                                <asp:AsyncPostBackTrigger ControlID="ddlCatalogo" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="lbtnCancelar" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    </div>
                </div>
            </section>
         </div>
</asp:Content>
