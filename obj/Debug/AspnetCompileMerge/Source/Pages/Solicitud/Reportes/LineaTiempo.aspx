<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="LineaTiempo.aspx.vb" Inherits="TranscoldPruebasWeb2.LineaTiempo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
      <div class="content-wrapper">
        <section class="content">
         
            


                    <div class="container-fluid">
                        <div class="card card-default">
                            <div class="card-header ">


                                <div class="card-tools">
                                    <b class="text-info">Cambios</b>
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>

                                </div>

                            </div>

                            <div class="card-header bg-gradient-navy">
                                <div class="row">

                                    <div class="col-sm-2">
                                        <small>Codigo</small>
                                        <asp:TextBox ID="tbCodigo" runat="server" name="tbCodigo" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-2">
                                        <small>Computadora</small>
                                        <asp:TextBox ID="tbComputadora" placeholder="Computadora" runat="server" CssClass="NombreCompu form-control "></asp:TextBox>

                                    </div>
                                    <div class="col-sm-5">
                                        <small>Opciones</small>
                                        <asp:ListBox ID="listOpciones" runat="server" CssClass="multi-select form-control" name="states[]" multiple="multiple" SelectionMode="Multiple">
                                            <asp:ListItem Selected="true">Cambios</asp:ListItem>
                                            <asp:ListItem Selected="true">Eventos</asp:ListItem>
                                            <asp:ListItem Selected="True">Estatus</asp:ListItem>
                                            <asp:ListItem>Comentarios</asp:ListItem>
                                            <asp:ListItem>Archivos</asp:ListItem>
                                        </asp:ListBox>

                                    </div>

                                    <div class="col-sm-2">
                                        <br />
                                        <asp:LinkButton ID="btnGenerar" OnClick="btnGenerar_Click" runat="server" CssClass="fa fa-2x fa-retweet" ToolTip="Generar linea de tiempo">
                                       

                                        </asp:LinkButton>
                                    </div>

                                </div>
                            </div>
                           
                        <div class="card-body">
                              <!---2 Inicio de linea de tiempo --->


                        <asp:UpdatePanel ID="upLinea" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>


                                        <div class="timeline">

                                            <asp:Repeater ID="repeaterReporte" runat="server">


                                                <ItemTemplate>

                                                    <!-- timeline time label -->
                                                    <div class="time-label ">
                                                    </div>
                                                    <!-- /.timeline-label -->
                                                    <!-- timeline item -->
                                                    <div>

                                                        <i class="  <%#If(Eval("Estado").Equals("Aprobado"), " fa fa-check bg-success", "fas  fa-exclamation-triangle  bg-danger")  %>"></i>
                                                        <div class="timeline-item">

                                                            <span class="time"><i class="fas fa-clock"></i><%# Eval("Fecha_Enviado", "{0:dd/MM/yyyy hh:mm tt}")%> <%#  Eval("Observaciones_Revision") %></span>
                                                            <h3 class="timeline-header"><%# Eval("cat") %></h3>
                                                            <div class="timeline-body">
                                                            
                                                                    <div class="col-sm-12">

                                                                        <%#  Eval("elem")  %>

                                                                        <tr runat="server" id="trArch" class="table-responsive-sm" visible='<%# Not Eval("Arch") Is DBNull.Value AndAlso Eval("Arch") <> ""%>'>
                                                                            <td>

                                                                                <div class="row">
                                                                                    <div class="col-lg-5">
                                                                                    </div>
                                                                                    <div class="col-lg-7">

                                                                                        <img src='https://www.fogelonline.com<%# Eval("Arch")%>' width="225" />

                                                                                    </div>
                                                                                </div>


                                                                            </td>

                                                                        </tr>
                                                                        <tr runat="server" id="trAbre" visible='<%# Not Eval("elem") Is DBNull.Value AndAlso (Left(Eval("elem"), 6) = "INICIO" Or Left(Eval("elem"), 3) = "FIN")%>'>
                                                                            <td style="border-left-style: solid;"></td>
                                                                            <td colspan="3" style="color: #00DF00" class="LinkGuardaReporte"><%# Eval("Folder")%></td>
                                                                        </tr>
                                                                    </div>
                                                                   

                                                            </div>
                                                        </div>
                                                    </div>




                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </div>

                               

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnGenerar" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <!---2 Fin de linea de tiempo --->
                        </div>    
                        </div>
                        </div>

                        </section>
            </div>

</asp:Content>
