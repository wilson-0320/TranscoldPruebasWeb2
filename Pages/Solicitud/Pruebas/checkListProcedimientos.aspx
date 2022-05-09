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
                        <div class="col-sm-1 form-inline">



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
                                       <th>Comentario</th>
                                       <th>Usuario</th>
                                       <th>Fecha</th>
                                       <th>Estado</th>



                                   </tr>
                               </thead>
                               <tbody>
                                   <asp:Repeater ID="repeaterCheck" runat="server" OnItemCommand="repeaterCheck_ItemCommand">
                                       <ItemTemplate>
                                           <tr>
                                                <td>
                                                    
                                                                               <asp:LinkButton ID="LinkButton3" Visible='<%#If(Eval("Valores").ToString.TrimEnd = "", True, False) %>' CommandName="Check" CommandArgument='<%# Eval("IDcheck").ToString + "|" + Eval("ID").ToString + "|" + Eval("Valores") + "|" + Eval("Descripcion")  %>' CssClass="fa fa-check" runat="server" ></asp:LinkButton>
                                                                        <asp:LinkButton ID="LinkButton1" Visible='<%#If(Eval("Valores").ToString.TrimEnd = "", False, True) %>' CommandName="Edit" CommandArgument='<%#  Eval("Descripcion").ToString.TrimEnd + "|" + Eval("IDcheck").ToString + "|" + Eval("ID").ToString + "|" + Eval("Valores").ToString.TrimEnd + "|" + Eval("Descripcion").ToString %>' CssClass="fa fa-edit" runat="server" ></asp:LinkButton>
                                                


                                                   </td>
                                               <td><%# Eval("Requisito") %></td>
                                                <td><%# Eval("Descripcion") %></td>
                                               <td><%# Eval("Usuario") %></td>
                                               <td><%# Eval("Fecha") %></td>
                                               <td><%# Eval("Estado") %></td>
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
