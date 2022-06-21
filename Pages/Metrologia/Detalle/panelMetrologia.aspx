<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="panelMetrologia.aspx.vb" Inherits="TranscoldPruebasWeb2.panelMetrologia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
    <asp:HiddenField ID="hfInstrumento" runat="server" />
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
                            <button onclick="return abrirModal('modal');" class="btn btn-success"><span class="fa fa-plus"></span></button>
                        </div>

                    </div>
                    <asp:UpdatePanel ID="upPanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="card-body">


                                <div class="table-responsive text-sm">
                                    <asp:Repeater ID="repeaterMet" DataSourceID="ODSBLL_Met_Instrumentos_Magnitud" runat="server" OnItemCommand="repeaterMet_ItemCommand">
                                        <HeaderTemplate>
                                            <table  class="table table-sm table-bordered">
                                                <thead class="bg-gradient-navy">
                                                    <tr>
                                                        <th></th>
                                                        <th>Magnitud</th>
                                                        <th>Exactitud</th>
                                                        <th>Resolucion</th>
                                                        <th>puntos_calibracion</th>
                                                        <th>rango_ini</th>
                                                        <th>rango_fin</th>
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
                                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Eli" CommandArgument='<%# Eval("id") %>' CssClass="fa fa-trash" OnClientClick="return confirm('¿Realmente desea eliminar el registro?')" ></asp:LinkButton>

                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edi" CommandArgument='<%# Eval("id") %>' CssClass="fa fa-edit"></asp:LinkButton>
                                                </td>
                                                <td><%# Eval("magnitud") %></td>
                                                <td><%# Eval("exactitud") %></td>
                                                <td><%# Eval("resolucion") %></td>
                                                <td><%# Eval("puntos_calibracion") %></td>
                                                <td><%# Eval("rango_ini") %></td>
                                                <td><%# Eval("rango_fin") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>


                                    <asp:ObjectDataSource ID="ODSBLL_Met_Instrumentos_Magnitud" runat="server" SelectMethod="consultar" TypeName="TranscoldPruebasWeb2.BLL.Met_Instrumento_Magnitud_BLL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="hfInstrumento" DefaultValue="-1" Name="idInstrumento" PropertyName="Value" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </div>


                                <hr />
                                <div class="table-responsive text-sm">
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <asp:DropDownList ID="ddlLaboratorios" runat="server" CssClass="js-example-theme-single form-control"></asp:DropDownList>
                                        </div>
                                        <div class="cols-sm-4">
                                            <asp:LinkButton ID="lbtnGuardarLaboratorios" OnClick="lbtnGuardarLaboratorios_Click" CssClass=" fa fa-save fa-2x"  runat="server"></asp:LinkButton>
                                        </div>
                                    </div>
                                    <asp:Repeater ID="repeaterLaboratorios" DataSourceID="ODSBLL_Met_Proveedor_Instrumentos" runat="server" OnItemCommand="repeaterLaboratorios_ItemCommand">
                                        <HeaderTemplate>
                                            <table  class="table table-sm table-bordered">
                                                <thead class="bg-gradient-navy">
                                                    <tr>
                                                        <th></th>
                                                        <th>Laboratorio</th>
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
                                                   <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Eli" CommandArgument='<%# Eval("id") %>' CssClass="fa fa-trash" OnClientClick="return confirm('¿Realmente desea eliminar el registro?')" ></asp:LinkButton>

                                                </td>
                                                <td><%# Eval("nombre") %></td>

                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>


                                    <asp:ObjectDataSource ID="ODSBLL_Met_Proveedor_Instrumentos" runat="server" SelectMethod="consultar" TypeName="TranscoldPruebasWeb2.BLL.Met_Instrumento_Proveedor_BLL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="hfInstrumento" DefaultValue="-1" Name="idInstrumento" PropertyName="Value" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </div>
                                <hr />

                                 <div class="table-responsive text-sm">
                                     <hr />
                                     <div class="text-right">
                                           <button onclick="return abrirModal('modalCertificados');" class="btn btn-success"><span class="fa fa-plus"></span></button>
                             

                                     </div>
                                       
                                    <asp:Repeater ID="repeaterCertificado" DataSourceID="ODSBLL_Met_Certificado" runat="server" OnItemCommand="repeaterCertificado_ItemCommand">
                                        <HeaderTemplate>
                                            <table id="tt" class="table table-sm table-bordered">
                                                <thead class="bg-gradient-navy">
                                                    <tr>
                                                        <th></th>
                                                        <th>Laboratorio</th>
                                                        <th>Envio</th>
                                                        <th>Retorno</th>
                                                        <th>Certificado</th>
                                                        <th>Link de certificado</th>
                                                        <th>Fecha_Calibración</th>
                                                        <th>Proxima_Calibración</th>
                                                        <th>Usuario</th>
                                                        <th>Vigente</th>
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
                                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Eli" CommandArgument='<%# Eval("ID") %>' CssClass="fa fa-trash" OnClientClick="return confirm('¿Realmente desea eliminar el registro?')" ></asp:LinkButton>

                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edi" CommandArgument='<%# Eval("ID") %>' CssClass="fa fa-edit"></asp:LinkButton>
                                                </td>
                                                <td><%# Eval("nombre") %></td>
                                                <td><%# Eval("Guia_Envio") %></td>
                                                <td><%# Eval("Guia_Retorno") %></td>
                                                <td><%# Eval("Certificado") %></td>
                                                <td><%# Eval("Link_Certificado") %></td>
                                                <td><%# Eval("Fecha_Cal") %></td>
                                                <td><%# Eval("Proxima_Cal") %></td>
                                                 <td><%# Eval("Usuario") %></td>
                                                <td><%# Eval("Vigente") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>


                                    <asp:ObjectDataSource ID="ODSBLL_Met_Certificado" runat="server" SelectMethod="consultar_por_instrumento" TypeName="TranscoldPruebasWeb2.BLL.Met_Certificado_BLL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="hfInstrumento" DefaultValue="-1" Name="idInstrumento" PropertyName="Value" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </div>


                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lbtnGuardarLaboratorios" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="lbtnCancelar" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="repeaterMet" EventName="ItemCommand" />
                            <asp:AsyncPostBackTrigger ControlID="repeaterLaboratorios" EventName="ItemCommand" />
                            <asp:AsyncPostBackTrigger ControlID="lbtnGuardarCer" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="lbtnCancelarCer" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="repeaterCertificado" EventName="ItemCommand" />
                            <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
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

                                    <small>Exactitud</small>
                                    <asp:TextBox ID="tbExactitud" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                    <small>Resolución</small>
                                    <asp:TextBox ID="tbResolucion" runat="server" CssClass="form-control" ></asp:TextBox>
                                    <small>Puntos_Calibración</small>
                                    <asp:TextBox ID="tbPuntosCal" runat="server" CssClass="form-control" MaxLength="300"></asp:TextBox>
                                    <small>Rango Inicio</small>
                                    <asp:TextBox ID="tbRangoIni" runat="server" CssClass="form-control" ></asp:TextBox>
                                    <small>Rango Fin</small>
                                    <asp:TextBox ID="tbRangoFin" runat="server" CssClass="form-control" ></asp:TextBox>


                                    
                                        <small>Magnitud</small>
                                        <asp:DropDownList ID="ddlMagnitud" CssClass="js-example-theme-single form-control" runat="server"></asp:DropDownList>
                                  



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


            <div class="modal fade" id="modalCertificados" name="modal" data-backdrop="static">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title"></h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="hfIDCal" runat="server" />
                            <asp:HiddenField ID="hfQueryCal" runat="server" />

                            <asp:UpdatePanel ID="upCrudCertificado" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>



                                    <small>Lab. enviado</small>
                                    <asp:DropDownList runat="server"
                                        CssClass="form-control" ID="ddlLaboratoriosAsignados">
                                    </asp:DropDownList>


                                    <small>Guia envio</small>
                                    <asp:TextBox ID="tbGuiaEnvio" runat="server" CssClass="form-control"></asp:TextBox>



                                    <small>Guia retorno</small>
                                    <asp:TextBox ID="tbGuiaRetorno" runat="server" CssClass="form-control"></asp:TextBox>

                                    <small>Vigencia</small>
                                    <asp:CheckBox ID="CbVigente" CssClass="form-check" runat="server" />



                                    <div class="row">
                                        <div class="col-sm-4">
                                            <small>Certificado</small>
                                            <asp:TextBox ID="tbCertificado" runat="server" CssClass="form-control"></asp:TextBox>


                                        </div>
                                        <div class="col-sm-4">
                                            <small>Certificado link</small>
                                            <asp:TextBox ID="tbLinkCertificado" runat="server" CssClass="form-control"></asp:TextBox>


                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-sm-4">
                                            <small>Fecha de calibración</small>
                                            <asp:TextBox ID="tbFechaCal" runat="server" Placeholder="" CssClass="form-control" TextMode="date"></asp:TextBox>



                                        </div>
                                        <div class="col-sm-4">
                                            <small>Proxima calibracion.</small>
                                            <asp:TextBox ID="tbFechaProx" runat="server" Placeholder="" CssClass="form-control" TextMode="date"></asp:TextBox>



                                        </div>
                                    </div>



                                    <div class="modal-footer ">
                                        <div class="justify-content-md-end">
                                            <asp:LinkButton ID="lbtnGuardarCer" OnClick="lbtnGuardarCer_Click" runat="server" CssClass="fa fa-2x fa-save"></asp:LinkButton>
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton ID="lbtnCancelarCer" OnClick="lbtnCancelarCer_Click" OnClientClick="cerrarModal('modalCertificados');" runat="server" CssClass="fa fa-2x fa-minus"></asp:LinkButton>
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
            <asp:AsyncPostBackTrigger ControlID="lbtnCancelarCer" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="repeaterMet" EventName="ItemCommand" />
            <asp:AsyncPostBackTrigger ControlID="repeaterCertificado" EventName="ItemCommand" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
