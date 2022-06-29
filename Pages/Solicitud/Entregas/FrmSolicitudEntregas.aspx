<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="FrmSolicitudEntregas.aspx.vb" Inherits="TranscoldPruebasWeb2.FrmSolicitudEntregas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
     <script>
         function abrirModalReporte(tipo) {
             var tipoAdquirido = tipo;
            try {
                $('#modal').modal('show');
            } catch (e) {
         
             }
             
             var tipoSplit = tipoAdquirido.split("$%$%#");
       
             if (tipoSplit[0]===("div1")) {
                 $("#divReporte1").css("display", "block");
                 $("#divReporte2").css("display", "none");
                 $("#Main1_Main2_tbLink").val(tipoSplit[4]);
                 $("#Main1_Main2_tbUsuario").val(tipoSplit[6]);
                 $("#Main1_Main2_tbEntrega").val(tipoSplit[7]);
                
                 tipoSplit[5] = tipoSplit[5].replaceAll("/", "-");
                // alert(tipoSplit[5]);
                // 31 / 05 / 2022 14: 07: 24
                 var horas = tipoSplit[5].split(" ");
                 var fechas = horas[0].split("-");

                 
                 $("#Main1_Main2_tbID").val(tipoSplit[1]);
                 $("#Main1_Main2_tbCodigoReporte").val(tipoSplit[2]);
                 $("#Main1_Main2_tbIDEntrega").val(tipoSplit[3]);
                 
                 $("#Main1_Main2_tbQuery").val("ReporteEditEntregas");
                 //
                 $("#Main1_Main2_tbFecha").val(fechas[2] + "-" + fechas[1] + "-" + fechas[0] + "T"+horas[1]);

             } else {

                 $("#divReporte1").css("display", "block");
                 $("#divReporte2").css("display", "none");
             }
           
           
           

            return false;
        }

     </script>
    <div class="content-wrapper">
        <asp:HiddenField ID="hfUsuarioName"  runat="server" />
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
                
              
                      

                <asp:ObjectDataSource ID="dsEntregas1" runat="server" SelectMethod="consultar_activas" TypeName="TranscoldPruebasWeb2.BLL.Pru_Entrega_BLL">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="" Name="con_vacio" Type="String" />
                    </SelectParameters>

                </asp:ObjectDataSource>
                


                <div class="card-body">
                    <div class="row">
     
                
                       
                        <div class="col-sm-1">
                             <small>Buscar:</small>
           
                <asp:TextBox runat="server" ID="tbBuscar" CssClass="form-control" Width="80px">
                </asp:TextBox>
           
                        </div>
                         <div class="col-sm-1">
                            <small>Desde:</small>
                               <asp:TextBox runat="server" ID="tbFechaIni" CssClass="form-control" Width="80px" ></asp:TextBox>
                        </div>
                        <div class="col-sm-1">
                            <small>Hasta:</small>
                             <asp:TextBox runat="server" ID="tbFechaFin" CssClass="form-control" Width="80px" ></asp:TextBox>
                        </div>
                         <div class="col-sm-1">
                            <small>Pend:</small>
<asp:DropDownList ID="ddlEntrega" runat="server" DataSourceID="dsEntregas1" 
                    DataTextField="entrega" DataValueField="id" Width="96px" CssClass="form-control">
                </asp:DropDownList>
                        </div>
                         <div class="col-sm-1">
                             <small>Para mi:</small>
                 <asp:CheckBox ID="chbSoloMios" CssClass="form-check" runat="server"   Width="134px" />
                        </div>
                        
                        <div class="col-sm-1">
                            
 <asp:Button  runat="server" ID="btnRefrescar" AutoPostBack="true" OnClick="btnRefrescar_Click" CssClass="btn btn-primary" Text="Filtrar"/>
                        </div>
                    </div>

  
                      <asp:ObjectDataSource ID="dsSolicitudes" runat="server" 
        SelectMethod="consultar_solicitudes" TypeName="BLL.Pru_Entrega_BLL">
        <SelectParameters>
            <asp:ControlParameter ControlID="tbBuscar" Name="buscar" 
                PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="tbFechaIni" Name="fecha_ini" 
                PropertyName="Text" Type="Object" />
            <asp:ControlParameter ControlID="tbFechaFin" Name="fecha_fin" 
                PropertyName="Text" Type="Object" />
            <asp:ControlParameter ControlID="ddlEntrega" DefaultValue="-1" 
                Name="Entrega_id" PropertyName="SelectedValue" Type="Int32" />
            <asp:Parameter Name="UserName" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

                    <asp:ObjectDataSource ID="dsSolicitudes1" runat="server" SelectMethod="consultar_solicitudes" TypeName="TranscoldPruebasWeb2.BLL.Pru_Entrega_BLL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="tbBuscar" Name="buscar" PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="tbFechaIni" Name="fecha_ini" PropertyName="Text" Type="Object" />
                            <asp:ControlParameter ControlID="tbFechaFin" Name="fecha_fin" PropertyName="Text" Type="Object" />
                            <asp:ControlParameter ControlID="ddlEntrega" DefaultValue="-1" Name="Entrega_id" PropertyName="SelectedValue" Type="Int32" />
                            <asp:Parameter Name="UserName" Type="String" />
                        </SelectParameters>

                    </asp:ObjectDataSource>

                    <asp:UpdatePanel ID="upReporte" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                      
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
                                <asp:Repeater ID="repeaterReporte" runat="server" DataSourceID="dsSolicitudes1" OnItemCommand="repeaterReporte_ItemCommand">
                                    <ItemTemplate>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="hfUsuarioRealiza" runat="server" />
                 <asp:TextBox runat="server" ID="tbCodSolicitud" Text='<%# Eval("Codigo") %>' Visible="false"></asp:TextBox>
                <asp:TextBox runat="server" ID="tbCodigo" Text='<%# Eval("Codigo") %>' Visible="false"></asp:TextBox>

                                        <tr>
                                            <td>
                                        <asp:LinkButton ID="LinkButton3" CommandName="Agregar" Text='<%# Eval("Codigo") %>' CommandArgument='<%# Eval("Codigo") %>'   CssClass="fa fa-edit" runat="server"></asp:LinkButton></td>
                                            
                                            <td><%# Eval("Codigo") %></td>
                                            <td><%# Eval("Modelo") %></td>
                                            <td><%# Eval("Fecha_Creacion") %></td>
                                            <td><%# Eval("Fecha_Finalizacion") %></td>
                                            <td><%# Eval("DifPrecio") %></td>
                                            <td><%# Eval("NumCambios") %></td>
                                            <td>
                                            
                                            
                                            
                                                  <asp:Repeater runat="server" ID="rptSolEntregas" DataSourceID="dsSolEntregas2" OnItemCommand="rptSolEntregas_ItemCommand" >
                        <HeaderTemplate>
                            <asp:Literal runat="server" ID="litGvSolHeader" Text=" &lt;table style='margin: 0'&gt; &lt;tr&gt;"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:UpdatePanel ID="upApartado" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>

                               
                                    <td style="padding: 0; border-style: hidden;">
                                        <table style="margin: 0">
                                            <tr>
                                                <td style="padding: 0; border-style: hidden;">
                                                    <asp:LinkButton ID="btnIncluir" runat="server" 
                                                        AutoPostBack="false" 
                                                       CommandName="incluir"
                                                        
                                                        CssClass=' <%# If(Eval("incluir") = True, "fa-2x fa fa-check", " fa fa-2x fa-exclamation-triangle") %>'
                                                        CommandArgument='<%# Eval("CssClassBtn") %>'
                                                       ToolTip='<%# Eval("msj_tooltip") %>'>
                                                        </asp:LinkButton>
                                                   
                                                   
                                                        
                                                </td>
                                                <td style="padding: 0; border-style: hidden;">
                                                    <asp:LinkButton ID="btnEntrega" runat="server" Text='<%# Eval("Entrega") %>' AutoPostBack="false"
                                                        CssClass='<%# Eval("CssClassBtn") + " btn" %>' Enabled='<%# Eval("habilitado") %>'
                                                        CommandName="entregar"
                                                       CommandArgument='<%# Eval("CssClassBtn") %>'>

                                                        </asp:LinkButton>
                                                   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" >
                                                    <a href='<%# Eval("Link_Reporte") %>' target="_blank"><%#Eval("msj_abajo")%></a>
                                                    <asp:LinkButton   runat="server" ID="btnEditarEntregaLink" CssClass='<%# "btnImg |" + Eval("id").ToString() + "| FlotaDer fa fa-edit" %>'
                                                        AutoPostBack="false" Visible='<%# Not Eval("id") Is DBNull.Value %>'
                                                        CommandName="editar"
                                                        CommandArgument='<%# Eval("id") %>'
                                                         >
                                                        </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                     </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="rptSolEntregas" EventName="ItemCommand"/>
                                </Triggers>
                            </asp:UpdatePanel>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Literal runat="server" ID="litGvSolFooter" Text=" &lt;/tr&gt; &lt;/table&gt;"></asp:Literal>
                        </FooterTemplate>
                    </asp:Repeater>
    <asp:ObjectDataSource ID="dsSolEntregas2" runat="server" SelectMethod="consultar_solicitud_entregas" TypeName="TranscoldPruebasWeb2.BLL.Pru_Entrega_BLL"  onselecting="dsSolEntregas_Selecting">
        <SelectParameters>
            <asp:ControlParameter ControlID="tbCodigo" DefaultValue="-" Name="cod_solicitud" PropertyName="Text" Type="String" />
                 <asp:Parameter Name="UserName" Type="String" ConvertEmptyStringToNull="false" DefaultValue="" />
                      
        </SelectParameters>
     </asp:ObjectDataSource>  
                                                  

                                            </td>
                                        </tr>

                                    </ItemTemplate>

                                </asp:Repeater>
                                
                                
                            </tbody>
                        </table>
                    </div>
                              </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnRefrescar" EventName="Click"/>
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="repeaterReporte" EventName="ItemCommand"/>

                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                    </div>
            </div>
        </section>
    </div>
   
             
                      

    <div class="modal fade" id="modal" name="modal">
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
                            
                             <asp:TextBox ID="tbQuery" Style="display:none;" runat="server"></asp:TextBox>
                              <asp:TextBox ID="tbIDEntrega" Style="display:none;" runat="server"></asp:TextBox>
                            <asp:TextBox ID="tbID"  runat="server" Style="display:none;" ></asp:TextBox>
                            <div class="row" id="divReporte1" >
                                <div class="col-sm-4">
                                   <asp:TextBox ID="tbCodigoReporte" name="tbCodigoReporte" Enabled="false"   CssClass="form-control" runat="server"></asp:TextBox>
                             </div>
                                <div class="col-sm-10">

                                   <small>Entrega</small>
                                    <asp:TextBox ID="tbEntrega" Enabled="false" name="tbEntrega"   CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-10">

                                   <small>Usuario</small>
                                    <asp:TextBox ID="tbUsuario" Enabled="false" name="tbUsuario"  CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-10">

                                    <small>Link</small>
                                    <asp:TextBox ID="tbLink" CssClass="form-control" name="tbLink" runat="server"></asp:TextBox>

                                   
                                </div>
                                 <div class="col-sm-6">
                                     <small>Fecha Entrega</small>
                                        <asp:TextBox ID="tbFecha"   CssClass="form-control" name="tbFecha" runat="server" TextMode="DateTimeLocal"></asp:TextBox>

                                    </div>


                                <hr />
                                </div>
                            <div class="row" id="divReporte2" >
                               
                                <div class="col-sm-5">

                                    <small>Link</small>
                                    <asp:TextBox ID="tbLinkReporte" CssClass="form-control" runat="server"></asp:TextBox>

                                   
                                </div>
                                 <div class="col-sm-5">
                                     <small>Fecha Entrega</small>
                                        <asp:TextBox ID="tbFechaReporte" CssClass="form-control" runat="server" TextMode="DateTimeLocal"></asp:TextBox>

                                    </div>


                                <hr />
                                </div>


                                <div class="modal-footer ">

                                    <div class="justify-content-md-end">


                                        <asp:LinkButton ID="lbtnGuardar" OnClick="lbtnGuardar_Click" CssClass="fa fa-2x  fa-save" runat="server"></asp:LinkButton>
                                    </div>

                                </div>
                        </ContentTemplate>

                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="repeaterReporte" EventName="ItemCommand" />
                        </Triggers>

                    </asp:UpdatePanel>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
