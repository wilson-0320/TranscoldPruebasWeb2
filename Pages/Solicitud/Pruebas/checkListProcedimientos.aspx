<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="checkListProcedimientos.aspx.vb" Inherits="TranscoldPruebasWeb2.checkListProcedimientos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
    <div class="content-wrapper">
        <section class="content">

            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">

                          <a href="../../Administrador/Catalogo/FrmRequerimientosPruebas.aspx">Agregar requerimientos</a>
                        <div class="card-tools">
                            <b class="text-info">Pruebas</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>
                          
                        </div>


                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="upPanelCheck" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:HiddenField ID="hfID" runat="server" />
                                 <asp:HiddenField ID="hfIDElemento" runat="server" />
                                 <asp:HiddenField ID="hfQuery" runat="server" />
                            
                        <div class="row">

                        
                        <div class="col-sm-2">

                            <small>Pruebas</small>
                            <asp:TextBox ID="tbCodigo" AutoPostBack="true" CssClass="form-control" OnTextChanged="tbCodigo_TextChanged" runat="server"></asp:TextBox>

                        </div>
                            
                        <div class="col-sm-2">

                            <small>Ensayos</small>
                            <asp:DropDownList ID="ddlEnsayos" CssClass=" js-example-theme-single form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlEnsayos_SelectedIndexChanged" runat="server"></asp:DropDownList>

                        </div>
                            <div class="col-sm-1">
                                <small>Tipo</small>
                                <asp:DropDownList ID="ddlTipo" runat="server" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" AutoPostBack="true" CssClass="js-example-theme-single form-control" >
                                    <asp:ListItem>INICIO</asp:ListItem>
                                    <asp:ListItem>FIN</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        <div class="col-sm-2">

                            <small>Valores</small>
                            <asp:DropDownList ID="ddlValores" CssClass="form-control"  runat="server"></asp:DropDownList>

                        </div>
                        <div class="col-sm-1 form-inline" style="display:none;">



                            <asp:LinkButton ID="lbtnGuardarSolicitud" runat="server" CssClass="fa fa-2x fa-save" ToolTip="Guardar Solicitud" OnClick="lbtnGuardarSolicitud_Click"></asp:LinkButton>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                          
                              <asp:LinkButton ID="lbtnLimpiar" runat="server" CssClass="fa fa-2x fa-minus" ToolTip="Limpiar" OnClick="lbtnLimpiar_Click"></asp:LinkButton>

                        </div>

                        </div>
                                <hr />
                        <div class="col-sm-12 table-responsive">
                           <table id="tt" class="table table-bordered table-hover">
                               <thead class="bg-gradient-navy">
                                   <tr>
                                       <th></th>
                                       <th>Requisito</th>
                                       <th>Opciones</th>
                                       <th>Usuario</th>
                                       <th>Fecha</th>
                                       <th>Estado</th>



                                   </tr>
                               </thead>
                               <tbody>
                                   <asp:HiddenField ID="hfOrdenRepeater" Value="0" runat="server" />
                                   <asp:Repeater ID="repeaterCheck"  runat="server" OnItemCommand="repeaterCheck_ItemCommand"  >
                                       <ItemTemplate>
                                           <tr  >
                                                <td>
                                                    
                                                                        <asp:LinkButton ID="LinkButton3"  CommandName="Check" CommandArgument='<%# Eval("IDcheck").ToString + "|" + Eval("ID").ToString + "|" + Eval("Valores") + "|" + Eval("Descripcion") + "|" + Eval("IDEvento")  %>' CssClass="fa fa-check" runat="server" ></asp:LinkButton>
                                                      <asp:LinkButton ID="LinkButton2"  CommandName="Close" Style="color:red;" CommandArgument='<%# Eval("IDcheck").ToString + "|" + Eval("ID").ToString + "|" + Eval("Valores") + "|" + Eval("Descripcion") + "|" + Eval("IDEvento")  %>' CssClass="fa fa-angle-double-down" runat="server" ></asp:LinkButton>
                                                                                          
                                                    <asp:LinkButton ID="LinkButton1" Visible="false" CommandName="Edit" CommandArgument='<%#  Eval("Descripcion").ToString.TrimEnd + "|" + Eval("IDcheck").ToString + "|" + Eval("ID").ToString + "|" + Eval("Valores").ToString.TrimEnd + "|" + Eval("Descripcion").ToString %>' CssClass="fa fa-edit" runat="server" ></asp:LinkButton>
                                                


                                                   </td>
                                              
                                               <td><%# Eval("Requisito") %></td>
                                               <td>   
                                                   <asp:HiddenField ID="hfValores" Value='<%# Bind("Descripcion") %>' runat="server" />
                                                   <asp:HiddenField ID="hfDescripcion" Value='<%# Eval("Valores") %>' runat="server" />
                                              <% retornarListado() %>
                                               <asp:TextBox ID="tbOpcionesListado" runat="server"></asp:TextBox>
                                               <asp:ListBox ID="ddlOpcionesListado" Enabled="false" CssClass="js-example-theme-single form-control"  SelectionMode="Multiple"   multiple="multiple" runat="server"></asp:ListBox>
                                               </td>
                                              
                                               <td><%# Eval("Usuario") %></td>
                                               <td><%# Eval("Fecha") %></td>
                                               <td class='<%# If(Eval("Estado").ToString.TrimEnd.Equals("Finalizado"), "bg-success", "bg-danger")  %>'> 
                                                 
                                                   <asp:Label ID="lblOpcionesListado" runat="server" Text='<%# Eval("Estado") %>'></asp:Label>

                                               </td>
                                           </tr>
                                           
                                       </ItemTemplate>
                                   </asp:Repeater>
                                   
                               </tbody>
                           </table>
                            </div>
                                </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="tbCodigo" EventName="TextChanged" />
                                <asp:AsyncPostBackTrigger ControlID="repeaterCheck" EventName="ItemCommand" />
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardarSolicitud" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="lbtnLimpiar" EventName="Click" />
                          
                                <asp:AsyncPostBackTrigger ControlID="ddlEnsayos" EventName="SelectedIndexChanged" />
                          
                                <asp:AsyncPostBackTrigger ControlID="ddlTipo" EventName="SelectedIndexChanged" />
                          
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
