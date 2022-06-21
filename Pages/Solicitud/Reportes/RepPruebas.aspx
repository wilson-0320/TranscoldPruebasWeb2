<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="RepPruebas.aspx.vb" Inherits="TranscoldPruebasWeb2.RepPruebas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
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


                    <asp:UpdatePanel ID="upPruebas" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="card-body">
                                <div class="row">
                            <div class="col-sm-3">
                                <small>Codigo</small>
                                <asp:TextBox ID="tbCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <small>Fecha en el formato: YYYY/MM/dd HH:mm:ss</small>
                                <asp:TextBox ID="tbFecha" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <br />
                                <asp:Button ID="btnFiltro" OnClick="btnFiltro_Click" CssClass="btn btn-default" runat="server" Text="Consultar" /> &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lbtnFiltrar" OnClick="lbtnFiltrar_Click" CssClass="fa  fa-filter" runat="server"></asp:LinkButton>
                            </div>
                        </div>
                                <asp:HiddenField ID="hfID"  runat="server" />
                                <div class="row">
                                    <div class="col-sm-2">
                                        <small>Prueba</small>
                                        <asp:TextBox ID="tbPrueba" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>WO</small>
                                        <asp:TextBox ID="tbWO" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>Serie</small>
                                        <asp:TextBox ID="tbSerie" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>Modelo</small>
                                        <asp:TextBox ID="tbModelo" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>Compresor</small>
                                        <asp:TextBox ID="tbCompresor" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>Evaporador</small>
                                        <asp:TextBox ID="tbEvaporador" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>Condensador</small>
                                        <asp:TextBox ID="tbCondensador" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>Termostato</small>
                                        <asp:TextBox ID="tbTermostato" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>Voltaje</small>
                                        <asp:TextBox ID="tbVoltaje" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>Relay</small>
                                        <asp:TextBox ID="tbRelay" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>Tipo.Evap.</small>
                                        <asp:TextBox ID="tbTipoEv" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-sm-1">
                                        <small>Tipo Cond.</small>
                                        <asp:TextBox ID="tbTipoCon" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>

                                    <div class="col-sm-1">
                                        <small>Capilar</small>
                                        <asp:TextBox ID="tbCapilar" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>

                                    <div class="col-sm-1">
                                        <small>Capacitor</small>
                                        <asp:TextBox ID="tbCapacitor" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>Protector Ter.</small>
                                        <asp:TextBox ID="tbProtector" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>MAE</small>
                                        <asp:TextBox ID="tbMae" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>MAC</small>
                                        <asp:TextBox ID="tbMac" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>Refrigerante</small>
                                        <asp:TextBox ID="tbRefrigerante" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>Cod. Compr.</small>
                                        <asp:TextBox ID="tbCodigoCompresor" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>


                                    <div class="col-sm-1">
                                        <small>Prueba NO.</small>
                                        <asp:TextBox ID="tbPrueba2" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>Carga Gas.</small>
                                        <asp:TextBox ID="tbCarga" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <small>Estado</small>
                                        <asp:TextBox ID="tbEstado" runat="server" CssClass="form-control" Text="Modificada"></asp:TextBox>
                                    </div>


                                </div>
                                <div class="row">
                                     <div class="col-sm-1">

                                        <small>Antiguo</small>

                                        <asp:DropDownList ID="ddlAntiguo" CssClass="form-control" runat="server">
                                            <asp:ListItem>Ambos</asp:ListItem>
                                            <asp:ListItem>Si</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                     <div class="col-sm-1">

                                        <small>Aprobado</small>
                                         <asp:DropDownList ID="ddlAprobado" CssClass="form-control" runat="server">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Si</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                             </asp:DropDownList>
                                         
                                    </div>
                                    <div class="col-sm-2">

                                        <small>Camara</small>

                                        <asp:DropDownList ID="ddlCamara" CssClass="js-example-theme-single form-control"  runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-sm-2">

                                        <small>Tipo Prueba</small>
                                        <asp:DropDownList ID="ddlTipoPrueba" CssClass="js-example-theme-single form-control"  runat ="server"></asp:DropDownList>

                                    </div>
                                    <div class="col-sm-2">

                                        <small>Comentarios</small>
                                        <asp:TextBox ID="tbComentarios" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>

                                    </div>
                                    <div class="col-sm-2">
                                        <br />
                                        <asp:LinkButton ID="lbtnGuardar" CssClass="fa fa-2x fa-save" runat="server" OnClick="lbtnGuardar_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                               
                                             <asp:LinkButton ID="lbtnCancelar" CssClass="fa fa-2x fa-minus" runat="server" OnClick="lbtnCancelar_Click"></asp:LinkButton>

                                    </div>
                                </div>
                                <hr />
                                <hr />

                                <div class="row">
                                    <div class="col-sm-6 bg-transparent table-responsive">
                                        <div class="card ">
                                            <div class="table-responsive text-sm">
                                                <table id="tt" class="table table-sm table-bordered table-hover table-avatar">
                                                    <thead class="bg-gradient-navy">
                                                        <tr>
                                                            <th></th>
                                                            <th>Solicitud</th>
                                                            <th>Prueba</th>
                                                            <th>Fecha</th>
                                                            <th>Modelo</th>
                                                            <th>Tipo prueba</th>
                                                            <th>Notas</th>
                                                            <th>Aprobado</th>

                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Repeater ID="repeaterPruebas" runat="server" OnItemCommand="repeaterPruebas_ItemCommand" >
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                         <small>  <a  class="text-purple" target="_blank" href="/Pages/Prueba/PruebasLab.aspx?CodigoSol=<%#Eval("Prueba") %>"><span class="fa fa-2x fa-chart-line"></span></a></small><br />
                                                                        <asp:LinkButton ID="LinkButton3" CommandName="Reporte" CommandArgument='<%# Eval("Prueba_ID") %>' CssClass="fa fa-play" runat="server" ></asp:LinkButton>
                                                                        <asp:LinkButton ID="LinkButton1" CommandName="Edit" CommandArgument='<%# Eval("Prueba_ID") %>' CssClass="fa fa-edit" runat="server" ></asp:LinkButton>
                                                                        <asp:LinkButton ID="LinkButton2" CommandName="Eli" CommandArgument='<%# Eval("Prueba_ID") %>' CssClass="fa fa-trash" runat="server" OnClientClick="return confirm('¿Realmente desea eliminar el registro?')" ></asp:LinkButton>
                                                                    </td>
                                                                    <td><%# Eval("CodSolicitud") %></td>
                                                                    <td><%# Eval("Prueba") %></td>
                                                                    <td><%# Eval("Fecha") %></td>
                                                                    <td><%# Eval("Modelo") %></td>
                                                                    <td><%# Eval("TipoPrueba") %></td>
                                                                    <td><%# Eval("Notas") %></td>
                                                                    <td><%# if(Eval("Aprobada") = "1", "Aprobado", "Fallida") %></td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>

                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 text-sm  bg-light">
                                        <div class="card ">
                                            <asp:Repeater ID="repeaterResumen" runat="server">
                                                <ItemTemplate>

<big>
                                                    <div class="row">

                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">WO</small><br />
                                                            <small class="text-blue"><%# Eval("WO") %></small>
                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Serie</small><br />
                                                            <small class="text-blue"><%# Eval("Serie") %></small>

                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Modelo</small><br />
                                                            <small class="text-blue"><%# Eval("Modelo") %></small>


                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Fecha</small><br />
                                                            <small class="text-blue"><%# Eval("Fecha") %></small>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Compresor</small><br />
                                                            <small class="text-blue"><%# Eval("Compresor") %></small>

                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Tipo Prueba</small><br />
                                                            <small class="text-blue"><%# Eval("TipoPrueba") %></small>

                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Evaporador</small><br />
                                                            <small class="text-blue"><%# Eval("Evaporador") %></small>


                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Tipo Evaporador</small><br />
                                                            <small class="text-blue"><%# Eval("TipoEvaporador") %></small>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Condensador</small><br />
                                                            <small class="text-blue"><%# Eval("Condensador") %></small>

                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Tipo Condensador</small><br />
                                                            <small class="text-blue"><%# Eval("TipoCondensador") %></small>

                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Capacitor</small><br />
                                                            <small class="text-blue"><%# Eval("Capacitor") %></small>


                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Capilar</small><br />
                                                            <small class="text-blue"><%# Eval("Capilar") %></small>


                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Camara ambiental</small><br />
                                                            <small class="text-blue"><%# Eval("CamaraAmbiental") %></small>

                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Prueba NO.</small><br />
                                                            <small class="text-blue"><%# Eval("PruebaNo") %></small>

                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">MAE</small><br />
                                                            <small class="text-blue"><%# Eval("MAE") %></small>

                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">MAC</small><br />
                                                            <small class="text-blue"><%# Eval("MAC") %></small>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Voltaje</small><br />
                                                            <small class="text-blue"><%# Eval("Voltaje") %></small>

                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Relay</small><br />
                                                            <small class="text-blue"><%# Eval("Relay") %></small>

                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Refrigerante</small><br />
                                                            <small class="text-blue"><%# Eval("Refrigerante") %></small>

                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Termostato</small><br />
                                                            <small class="text-blue"><%# Eval("Termostato") %></small>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Estado</small><br />
                                                            <small class="text-blue"><%# Eval("Estado") %></small>

                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Usuario</small><br />
                                                            <small class="text-blue"><%# Eval("Usuario") %></small>

                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Protector termico</small><br />
                                                            <small class="text-blue"><%# Eval("ProtectorTermico") %></small>

                                                        </div>
                                                        <div class="col-sm-3 btn-default">
                                                            <small class="text-dark">Folder</small><br />
                                                            <small class="text-blue"><%# Eval("Folder") %></small>

                                                        </div>
                                                    </div>
    <div class="row">
        <div class="col-sm-12 btn-default">
                                                            <small class="text-dark">Descripcion</small><br />
                                                            <small class="text-blue"><%# Eval("Descripcion") %></small>

                                                        </div>
    </div>
    </big>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnFiltro" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="lbtnCancelar" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="lbtnFiltrar" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="repeaterPruebas" EventName="ItemCommand" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
            </div>

        </section>
    </div>
</asp:Content>
