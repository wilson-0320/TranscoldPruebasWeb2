<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="Dashboard.aspx.vb" Inherits="TranscoldPruebasWeb2.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
      <div class="content-wrapper">
    <section class="content">
        <div class="container-fluid">
            <div class="card card-default">
                <div class="card-header ">


                    <div class="card-tools">
                        <b class="text-info">Pruebas activas</b>
                        <button type="button" class="btn btn-tool" data-card-widget="collapse">
                            <i class="fas fa-minus"></i>
                        </button>

                    </div>
                    </div>
                
            <div class="card-body">
                   <div class=" table-responsive text-sm">
                        <table id="tt" class="table table-bordered table-sm tt" >
                            <thead class="bg-gradient-navy">
                                <tr>
                                <th></th>
                                <th>Codigo</th>
                                <th>Fecha Creacion</th>
                                <th>Lider Proyecto</th>
                                <th>Objetivos</th>
                                <th>Referencia Proveedor</th>
                                <th>Referencia Fogel</th>
                                <th>Serie</th>
                                <th>WO</th>
                                    </tr>
                            </thead>
                            <tbody>
                            <asp:Repeater ID="repeaterPruebas" runat="server">
                                <ItemTemplate>
                                    <tr>
                                    <td>
                                        
                                      <small>  <a  class="text-purple" target="_blank" href="/Pages/Solicitud/Solicitud.aspx?Codigo=<%#Eval("Codigo") %>"><span class="fa fa-2x fa-desktop"></span></a></small><br />
                                            <small>  <a  class="text-purple" target="_blank" href="/Pages/Prueba/PruebasLab.aspx?Codigo=<%#Eval("Codigo") %>"><span class="fa fa-2x fa-chart-line"></span></a></small><br />
                                              
                                        
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

            </div>
                </div>
            </div>
        </section>
        </div>
</asp:Content>
