<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="HistorialSolicitudes.aspx.vb" Inherits="TranscoldPruebasWeb2.HistorialSolicitudes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
    <div class="content-wrapper">


        <!-- Main content -->
        <section class="content">
            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Listado de pruebas</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>
                    </div>
                    <div class="card-body">
                    <div class="card-header bg-gradient-dark">
                        <div class="row">
                            <div class="col-sm-2">
                                <small>Codigo</small>
                                <asp:TextBox ID="tbCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                                <small>Posterior a:</small>
                                <asp:TextBox ID="tbPosterior"  CssClass="form-control"  runat="server" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                                <small>Anterior a:</small>
                                <asp:TextBox ID="tbAnterior"  CssClass="form-control"  runat="server" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                                <small>Modelo:</small>
                                <asp:TextBox ID="tbModelo"  CssClass="form-control"  runat="server" ></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                                <small>Consecutivo:</small>
                                <asp:TextBox ID="tbConsecutivo"  CssClass="form-control"  runat="server" ></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                                <small>WO:</small>
                                <asp:TextBox ID="tbWO"  runat="server" CssClass="form-control"  ></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2">
                                <small>Estado:</small>
                                <asp:DropDownList ID="ddlEstado" runat="server"  CssClass="form-control" >
                                    <asp:ListItem>TODAS</asp:ListItem>
                                    <asp:ListItem>Ingresada</asp:ListItem>
                                    <asp:ListItem>Pruebas</asp:ListItem>
                                    <asp:ListItem>Finalizada</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-2">
                                <small>Serie:</small>
                                <asp:TextBox ID="tbSerie" runat="server" CssClass="form-control"  ></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <small>Lider:</small>
                                <asp:DropDownList ID="ddlLider" runat="server"  CssClass="form-control" >
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-4">
                                <small>Objetivos:</small>
                                 <asp:TextBox ID="tbObjetivos" runat="server" CssClass="form-control"  ></asp:TextBox>
                            </div>
                            <div class="col-sm-1 text-center">
                                <br />
                                <asp:LinkButton ID="lbtnFiltrar" OnClick="lbtnFiltrar_Click" runat="server" CssClass="fa fa-2x fa-filter"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    

                          
                    <asp:UpdatePanel ID="upTablaPruebas" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class=" table-responsive text-sm">
                        <table id="tt" class="table table-bordered table-sm tt" >
                            <thead class="bg-gradient-navy">
                                <th></th>
                                <th>Codigo</th>
                                <th>Fecha Creacion</th>
                                <th>Lider Proyecto</th>
                                <th>Objetivos</th>
                                <th>Referencia Proveedor</th>
                                <th>Referencia Fogel</th>
                                <th>Serie</th>
                                <th>WO</th>
                            </thead>
                            <tbody>
                            <asp:Repeater ID="repeaterPruebas" runat="server">
                                <ItemTemplate>
                                    <tr>
                                    <td>
                                        
                                      <small>  <a  class="text-purple" target="_blank" href="/Pages/Solicitud/Solicitud.aspx?Codigo=<%#Eval("Codigo") %>"><span class="fa fa-1x fa-desktop"></span></a></small><br />
                                           
                                              
                                        
                                    </td>
                                    <td>
                                        <%# Eval("Codigo") %>
                                    </td>
                                        <td>
                                        <%# Eval("Fecha_Creacion") %>
                                    </td>
                                        <td>
                                        <%# Eval("Lider Proyecto") %>
                                    </td>
                                        <td>
                                        <%# Eval("Objetivos") %>
                                    </td>
                                        <td>
                                        <%# Eval("Referencia_Proveedor") %>
                                    </td>
                                        <td>
                                        <%# Eval("Referencia_Fogel") %>
                                    </td>
                                         <td>
                                        <%# Eval("Serie") %>
                                    </td>
                                         <td>
                                        <%# Eval("WO") %>
                                    </td>

                                </tr>
                                </ItemTemplate>
                                
                            </asp:Repeater>
                                 </tbody>
                        </table>
                        </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lbtnFiltrar" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                            </div>     
                    </div>
                </div>
            </section>
        </div>
</asp:Content>
