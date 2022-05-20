<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="FrmSolicitudEntregas.aspx.vb" Inherits="TranscoldPruebasWeb2.FrmSolicitudEntregas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
     <script>
       function abrir() {

            try {
                $('#modalCheck').modal('show');
            } catch (e) {
         
            }

            return false;
        }

     </script>
    <div class="content-wrapper">
        <section class="content">

            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Pruebas</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>


                    </div>
                </div>
              
                                          
                <div class="card-body">
                    <div class="table-responsive text-sm">
                        <table id="tt" class="table table-bordered table-hover table-sm">
                            <thead class="bg-gradient-navy">
                                <tr>
                                    <th></th>
                                    <th>Solicitud</th>
                                    <th>Modelo</th>
                                    <th>F. Fecha Creacion</th>
                                    <th>F. Finalizacion</th>
                                    <th>Dif. Precio</th>
                                    <th>Num. Cambios</th>
                                    <th>Detalles</th>
                                </tr>

                            </thead>
                            <tbody>
                                <asp:Repeater ID="repeaterReporte" runat="server" OnItemCommand="repeaterReporte_ItemCommand">
                                    <ItemTemplate>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="hfUsuarioRealiza" runat="server" />
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="LinkButton3" CommandName="Subir" CommandArgument='<%# Eval("Codigo") %>' CssClass="fa fa-play" runat="server"></asp:LinkButton></td>
                                            <asp:HiddenField ID="hfCodigo" runat="server" />
                                            <td><%# Eval("Codigo") %></td>
                                            <td><%# Eval("Modelo") %></td>
                                            <td><%# Eval("Fecha_Creacion") %></td>
                                            <td><%# Eval("Fecha_Finalizacion") %></td>
                                            <td><%# Eval("Link_Reporte") %></td>
                                            <td><%# Eval("DifCosto") %></td>
                                            <td><%# Eval("NumCambios") %></td>
                                            <td>
                                                <asp:Repeater ID="repeaterDetalle" runat="server" DataSourceID="ObjectDataSourceDetalle"  >
                                                    <ItemTemplate>

                                                    </ItemTemplate>
                                                </asp:Repeater>
                                               
                               <asp:ObjectDataSource ID="ObjectDataSourceDetalle" runat="server" SelectMethod="consultar_solicitud_entregas" TypeName="TranscoldPruebasWeb2.BLL.Pru_Entrega_BLL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hfCodigo" Name="cod_solicitud" PropertyName="Value" Type="String" />
                                        <asp:ControlParameter ControlID="hfUsuarioRealiza" Name="UserName" PropertyName="Value" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>

                                    </ItemTemplate>

                                </asp:Repeater>
                                <asp:Button ID="btnClick" CssClass="btn-success" runat="server" Text="-------" />
                                 
                                
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <div class="modal fade" id="modalCheck" name="modal">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Entregas</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="upEntregas" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:HiddenField ID="hfQuery" runat="server" />

                            <div class="row">


                                <div class="col-sm-4">

                                    <small>Ensayos</small><br />
                                    <asp:DropDownList ID="ddlEntregas" CssClass="form-control " runat="server"></asp:DropDownList>

                                </div>
                                <div class="col-sm-5">

                                    <small>Link</small>
                                    <asp:TextBox ID="tbLink" CssClass="form-control" runat="server"></asp:TextBox>

                                   
                                </div>
                                 <div class="col-sm-2">
                                     <small>Fecha Entrega</small>
                                        <asp:TextBox ID="tbFecha" CssClass="form-control" runat="server" TextMode="DateTimeLocal"></asp:TextBox>

                                    </div>


                                <hr />
                                </div>

                                <div class="modal-footer ">

                                    <div class="justify-content-md-end">


                                        <asp:LinkButton ID="lbtnSiguiente" OnClick="lbtnSiguiente_Click" CssClass="fa fa-2x  fa-arrow-alt-circle-right" runat="server"></asp:LinkButton>
                                    </div>

                                </div>
                        </ContentTemplate>

                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lbtnSiguiente" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="repeaterReporte" EventName="ItemCommand" />
                        </Triggers>

                    </asp:UpdatePanel>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
