<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="Instrumentos.aspx.vb" Inherits="TranscoldPruebasWeb2.Instrumentos1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
      <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Instrumentos</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>
                     <button onclick="return abrirModal('modal');" class="btn btn-success"> <span class="fa fa-plus"></span></button>
                        </div>
                      
                    </div>
                    <asp:UpdatePanel ID="upPanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card-body">


                                <div class="table-responsive text-sm">
                                    <asp:Repeater ID="repeaterMet" DataSourceID="ODSBLL_Met_Instrumentos" runat="server" OnItemCommand="repeaterMet_ItemCommand">
                                       <HeaderTemplate>
                                           <table id="tt" class="table table-sm table-bordered">
                                               <thead class="bg-gradient-navy">
                                                   <tr>
                                                       <th></th>
                                                       <th>Instrumento</th>
                                                       <th>Descripcion</th>
                                                   
                                                       <th>Modelo</th>
                                                       <th>Serie</th>
                                                        <th>rango_maximo</th>
                                                       <th>Periodo de calibracion</th>
                                                       <th>Periodo de revision</th>
                                                       <th>Marca</th>
                                                       <th>Ubicacion</th>
                                                        <th>Calibracion</th>
                                                        <th>Proxima calibracion</th>
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
                                                   <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Det"  CommandArgument='<%# Eval("id") %>' CssClass="fa fa-play-circle"></asp:LinkButton>
                                               
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" CommandArgument='<%# Eval("id") %>' CssClass="fa fa-edit"></asp:LinkButton>
                                                  </td>
                                                <td><%# Eval("instrumento") %></td>
                                                <td  ><%# Eval("descripcion") %></td>
                                                <td><%# Eval("modelo") %></td>
                                                <td><%# Eval("serie") %></td>
                                                <td><%# Eval("rango_maximo") %></td>
                                                <td><%# Eval("periodo_calibracion") %></td>
                                                <td><%# Eval("periodo_revision") %></td>
                                                <td><%# Eval("marca") %></td>
                                                <td><%# Eval("ubicacion") %></td>
                                                <td>
                                                <a href="<%# Eval("linkC") %>" target="_blank"><%# Eval("calibracion") %></a>
                                               </td>
                                                <td class="<%# Eval("cssClass") %>"><%# Eval("prox") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>


                                    <asp:ObjectDataSource ID="ODSBLL_Met_Instrumentos" runat="server" SelectMethod="consultar" TypeName="TranscoldPruebasWeb2.BLL.Met_Instrumento_BLL"></asp:ObjectDataSource>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="lbtnCancelar" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="repeaterMet" EventName="ItemCommand" />
                        </Triggers>
                    </asp:UpdatePanel>



                </div>
            </div>
        </section>
    </div>
    <asp:UpdatePanel ID="updatePanelCrud" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <div class="modal fade" id="modal" name="modal" data-backdrop="static">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title"></h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="hfID" runat="server" />
                            <asp:HiddenField ID="hfQuery" runat="server" />

                            <asp:UpdatePanel ID="upCrud" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>

                                    <small>Instrumento</small>
                                    <asp:TextBox ID="tbInstrumento" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                    <small>descripcion</small>
                                    <asp:TextBox ID="tbDescripcion" runat="server" CssClass="form-control" MaxLength="200"></asp:TextBox>
                                     <small>descripcion Ingles.</small>
                                    <asp:TextBox ID="tbDescripcionI" runat="server" CssClass="form-control" MaxLength="200"></asp:TextBox>
                                   
                                    
                                    <small>Modelo</small>
                                    <asp:TextBox ID="tbModelo" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                    <small>Serie</small>
                                    <asp:TextBox ID="tbSerie" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                    <small>Serie</small>
                                    <asp:TextBox ID="tbRangoMax" runat="server" CssClass="form-control" TextMode="Number" ></asp:TextBox>
                                    <small>Periodo de calibracion</small>
                                    <asp:TextBox ID="tbPerCal" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                     <small>Periodo de revision</small>
                                    <asp:TextBox ID="tbPerRev" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                     <small>Comentarios</small>
                                    <asp:TextBox ID="tbComentarios" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                   <div class="row">
                                        <div class="col-sm-6">
                                            <small>Marca</small>
                                            <asp:DropDownList ID="ddlMarca" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                       <div class="col-sm-6">
                                            <small>Area asignada</small>
                                            <asp:DropDownList ID="ddlArea" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-4">
                                            <small>Vigente</small>
                                            <asp:CheckBox ID="cbVigente" runat="server" CssClass="form-check" />
                                        </div>
                                    </div>

                                    <div class="modal-footer ">
                                        <div class="justify-content-md-end">
                                            <asp:LinkButton ID="lbtnGuardar" OnClick="lbtnGuardar_Click" runat="server" CssClass="fa fa-2x fa-save"></asp:LinkButton>
                                           &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton ID="lbtnCancelar" OnClick="lbtnCancelar_Click" OnClientClick="cerrarModal('modal');" runat="server" CssClass="fa fa-2x fa-minus"></asp:LinkButton>
                                        </div>

                                    </div>

                                </ContentTemplate>

                                <Triggers>
                                </Triggers>

                            </asp:UpdatePanel>
                        </div>

                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
           
            <asp:AsyncPostBackTrigger ControlID="lbtnCancelar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="repeaterMet" EventName="ItemCommand" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
