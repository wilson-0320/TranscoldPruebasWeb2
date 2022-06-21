<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="FrmRequerimientosPruebas.aspx.vb" Inherits="TranscoldPruebasWeb2.FrmRequerimientosPruebas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
            <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Requerimientos de pruebas</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>

                    </div>
                    <div class="card-body">
                         <div class="col-sm-5">
                                <small class="text-danger">Ensayo (funcion unicamente como filtro)</small>
                                <asp:DropDownList ID="ddlEnsayo" runat="server" OnSelectedIndexChanged="ddlEnsayo_SelectedIndexChanged" AutoPostBack="true" CssClass="js-example-theme-single form-control" ></asp:DropDownList>
                            </div>
                        <asp:UpdatePanel ID="updateGeneral" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:HiddenField ID="hfID" runat="server" />
                                <asp:HiddenField ID="hfIDElementos" runat="server" />
                                <asp:HiddenField ID="hfQuery" runat="server" />

                            
                        <div class="row">
                            <div class="col-sm-4">
                                <small>Ensayo</small>
                                
                                <asp:ListBox ID="lbxCatalogo" runat="server" AutoPostBack="false" CssClass="multi-select form-control" name="states[]" multiple="multiple" SelectionMode="Multiple" > </asp:ListBox>

                            </div>
                           
                            <div class="col-sm-1">
                                <small>Tipo</small>
                                <asp:DropDownList ID="ddlTipo" runat="server" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" AutoPostBack="true" CssClass="js-example-theme-single form-control" >
                                    <asp:ListItem>INICIO</asp:ListItem>
                                    <asp:ListItem>FIN</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3">
                                <small>Descripcion</small>
                                <asp:TextBox ID="tbDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            
                            
                              
                          <div class="col-sm-3">
                                <small>Valores</small>
                                <asp:TextBox ID="tbValores" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                                   
                             
                            <div class="col-sm-1">
                                <br />
                                <asp:LinkButton ID="lbtnGuardar" runat="server" CssClass="fa fa-2x fa-save" OnClick="lbtnGuardar_Click"  OnClientClick="return confirm('¿Esta seguro de aplicar los cambios para todos los ensayos seleccionados?')"></asp:LinkButton>
                               <asp:LinkButton ID="lbtnCancelar" runat="server" CssClass="fa fa-2x fa-minus" OnClick="lbtnCancelar_Click" ></asp:LinkButton>
                           
                            </div>
                        </div>
                        <hr />
                        <div class="table-responsive">
                            <br />
                            <table id="tt" class="table-sm table table-bordered tt">
                                <thead class="bg-gradient-navy">
                                    <th></th>
                                    <th>Descripcion</th>
                                    <th>Valores</th>
                                    <th>Estado</th>
                                    <th></th>
                                    

                                </thead>
                                <tbody>
                                    <asp:Repeater ID="repeaterRegistrosPruebas" OnItemCommand="repeaterRegistrosPruebas_ItemCommand" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" CssClass="fa fa-edit" ></asp:LinkButton>
                                                       
                                                            <asp:LinkButton ID="LinkButton3" runat="server"  OnClientClick="return confirm('¿Realmente desea eliminar el registro?')" CommandArgument='<%# Eval("ID") %>' CommandName="Eli" CssClass="fa fa-trash" ></asp:LinkButton>
                                                      

                                                </td>
                                                <td><%# Eval("Descripcion")  %></td>
                                               
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
                                
                                <asp:AsyncPostBackTrigger ControlID="lbtnCancelar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="repeaterRegistrosPruebas" EventName="ItemCommand" />
                                
                                
                                <asp:AsyncPostBackTrigger ControlID="ddlEnsayo" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlTipo" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    </div>
                </div>
            </section>
         </div>
</asp:Content>
