<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="Informe.aspx.vb" Inherits="TranscoldPruebasWeb2.Informe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {


            $(".LinkGuardaReporte").click(function () {
                var Compu = $(".NombreCompu").val();
                var PathRep = $(this).html();
                var jqxhr = $.get("/TranscoldPruebasWeb/Publico/Servicios/TransWebService.asmx/AbreReporte", { Compu: Compu, PathReporte: PathRep })
                    .done(function () {
                        alert("Colocado " + PathRep);
                    })
                    .fail(function () {
                        alert("Error");
                    })
            });



            //$(".PanelContenedorReportViewer").find("iframe").contents().find('span[class*="ConAlerta|"]').each(function (i, e) {
            //    var comentario = $(this).attr('class').split('ConAlerta|')[1].split('|')[0]
            //    $(this).attr('title', comentario);
            //});
        });
    </script>

    <script type="text/javascript">
        function convertirHTML() {

            var convertir = $('#summernotehtml').trumbowyg('html');
            // $("#summernotehtml").html();
            
            convertir = convertir.replaceAll("¡", " ");
            convertir = convertir.replaceAll("\"", "'");
            convertir = convertir.replaceAll("!", " ");
            convertir = convertir.replaceAll("3*", " ");


            convertir = convertir.replaceAll("<", "¡");
            convertir = convertir.replaceAll(">", "!");
            convertir = convertir.replaceAll("/", "3*");

            $('#<%= __tbCodigoEditorCrud.ClientID %>').val(convertir);
        }

        function inicializaAutoComp()
        {
            $.get('https://fogelonline.com/TranscoldPruebasWeb/Publico/Servicios/jsonArticulos.aspx?term=EL-303-E')
                .done(function (data) {
                    var content = JSON.parse(data);
                    console.log(content)
                    
                });
        }

    </script>

    <div class="content-wrapper">
        <section class="content">
            <div class="row">
                <div class="col-sm-8">


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
                                        <asp:CheckBox ID="cbPresentacion" CssClass="checked" runat="server" />
                                    </div>

                                </div>
                            </div>
                            <div class="card-body text-sm">

                                <!---3 Modulo de edicion de cambios --->

                                <asp:UpdatePanel ID="upCrud" runat="server" UpdateMode="Conditional">



                                    <ContentTemplate>
                                    <!--    <Panel ID="panelCrud" >-->



                                            <asp:HiddenField ID="hfIDElmentoCrud" runat="server" />
                                            <asp:HiddenField ID="hfListElemento" runat="server" />
                                            <asp:HiddenField ID="hfTipoCrud" runat="server" />

                                            <asp:HiddenField ID="hfElementID" runat="server" />
                                            <asp:HiddenField ID="hfTipoImagen" runat="server" />
                                             <asp:HiddenField ID="hfUsuario" runat="server" />
                                            <asp:TextBox ID="__tbCodigoEditorCrud" runat="server" CssClass="form-control" TextMode="MultiLine" Style="display: none;"></asp:TextBox>



                                        <asp:DropDownList ID="ddlDivision" runat="server" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">

                                        </asp:DropDownList>



                                            <asp:Panel ID="panelHistorico" runat="server">

                                                <div class="row ">

                                                    <div class="col-sm-5 form-inline btn-default ">
                                                        <small class="form-inline">Fecha enviado: </small>&nbsp;&nbsp;&nbsp;
                                                        <asp:Label ID="lblUserPrueba"  runat="server" Text="" CssClass="form-inline text-black-50"></asp:Label>
                                                        &nbsp;&nbsp;&nbsp;
                                                        <asp:TextBox ID="fnEnviado"  CssClass="form-inline"  runat="server"></asp:TextBox>

                                                    </div>
                                                    <div class="col-sm-5 form-inline btn-default ">
                                                        <small>Fecha Revisado: </small><br /> &nbsp;&nbsp;&nbsp;
                                                        <asp:Label ID="lblUserRevisado" runat="server"  Text=""></asp:Label>&nbsp;&nbsp;&nbsp;
                                       

                                            <asp:TextBox ID="fnRevisado" runat="server" CssClass="form-inline"></asp:TextBox>

                                                    </div>
                                                    <div class="col-sm-2 form-inline btn-outline-success">
                                                        <asp:Label ID="lblEstadoTransaccion" runat="server" Text=""></asp:Label>
                                                    </div>

                                                </div>
                                            </asp:Panel>
                                            <hr />
                                            <div>
                                                <div class="row">

                                                    <div class="col-sm-10 form-inline">

                                                        <asp:DropDownList runat="server"
                                                            CssClass="js-example-theme-single" OnSelectedIndexChanged="listElemento_SelectedIndexChanged"
                                                            ID="listElemento" AutoPostBack="True" AppendDataBoundItems="True">
                                                        </asp:DropDownList>


                                                    </div>
                                                    <div class="col-sm-2">
                                                         <tr>
                                                        <td>
                                                            <asp:LinkButton ID="btnGuardarCrud" runat="server" CssClass="fa-2x fa fa-save" OnClientClick="convertirHTML();" OnClick="btnGuardarCrud_Click" ToolTip="Guardar">
                                       
                                                            </asp:LinkButton>

                                                          

                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                      
                                            <asp:LinkButton ID="btnEliminarCrud" runat="server" CssClass=" fa-2x fa fa-trash" OnClientClick="return confirm('¿Realmente desea eliminar el registro?')" OnClick="btnEliminarCrud_Click">
                                        
                                            </asp:LinkButton>

                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                      
                                            <asp:LinkButton ID="btnCancelarModificacion" OnClick="btnCancelarModificacion_Click" runat="server" CssClass="fa-2x fa fa-minus ">
                                       
                                            </asp:LinkButton>




                                                        </td>
                                                    </tr>
                                                    </div>

                                                </div>
                                                <hr />
                                                <div class="row">
                                                    <div class="col-sm-3">
                                                        <small>Codigo:</small>

                                                        <asp:TextBox ID="tbCodigoCrud" runat="server" OnTextChanged="tbCodigoCrud_TextChanged" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                                                        <asp:DropDownList ID="listCodigoCrud" runat="server" CssClass="js-example-theme-single form-control"></asp:DropDownList>

                                                    </div>
                                                    <div class="col-sm-1">

                                                        <asp:CheckBox ID="cbExterno" runat="server" ToolTip="Es Externo" CssClass="form-check-inline" Text="Ex." />


                                                    </div>

                                                    <div class="col-sm-2">

                                                        <small>Cantidad:</small>
                                                        <asp:TextBox ID="tbCantidadCrud" runat="server" Placeholder="Cantidad" CssClass="form-control"></asp:TextBox>


                                                        <asp:DropDownList ID="ddlCargaRefrigerante" OnSelectedIndexChanged="ddlCargaRefrigerante_SelectedIndexChanged" runat="server" AutoPostBack="true">
                                                            <asp:ListItem></asp:ListItem>
                                                            <asp:ListItem>Oz-&gt;Lbs</asp:ListItem>
                                                            <asp:ListItem>Gr-&gt;Lbs</asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>

                                                    <div class="col-sm-2">
                                                        <small>Precio</small>
                                                        <asp:TextBox ID="tbPrecioCrud" runat="server" CssClass="form-control input-danger" TextMode="Number"></asp:TextBox>

                                                    </div>
                                                    <div class="col-sm-4">


                                                        <asp:TextBox ID="tbComentariosObservacionesCrud" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>


                                                    </div>
                                                </div>
                                                <hr />
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <asp:Panel ID="panelTxtEnriquecido" runat="server">

                                                            <div class="trumbowyg-dark">
                                                                <textarea id="summernotehtml"><%= __tbCodigoEditorCrud.Text().Replace("¡", "<")   %></textarea>
                                                            </div>

                                                        </asp:Panel>

                                                    </div>
                                                </div>
                                              
                                            </div>


                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="listElemento" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlCargaRefrigerante" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="repeaterReporte" EventName="ItemCommand" />
                                        <asp:AsyncPostBackTrigger ControlID="btnCancelarModificacion" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnEliminarCrud" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="repeaterPendienteRevision" EventName="ItemCommand" />
                                        <asp:AsyncPostBackTrigger ControlID="btnGenerar" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnGuardarCrud" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="tbCodigoCrud" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>


                                <!---3 Fin de edicion --->
                                <hr />



                            </div>



                        </div>
                    </div>
                </div>
                <div class="col-sm-4">




                    <div class="col-sm-12">




                        <div class="container-fluid">
                            <div class="card card-default">
                                <div class="card-header ">


                                    <div class="card-tools">
                                        <b class="text-info">Carga de imagenes</b>
                                        <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                            <i class="fas fa-minus"></i>
                                        </button>

                                    </div>

                                </div>
                                <div class="card-body">
                                    <asp:UpdatePanel ID="upImagenesUpload" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            

                                                <div class="row">


                                                    <div class="col-sm-6">
                                                        <small>Descripcion</small>
                                                        <asp:TextBox ID="tbDescripcionFoto" runat="server" Placeholder="Descripcion" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    </div>


                                                    <div class="col-sm-4">
                                                        <small>File</small>
                                                        <asp:FileUpload ID="fuArchivos" type="file" multiple="multiple" CssClass="form-control" name="fuArchivos" runat="server" />
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <br />
                                                        <asp:LinkButton ID="btnGuardarFoto" runat="server" CssClass=" fa fa-2x fa-save" ToolTip="Guardar fotos" OnClick="btnGuardarFoto_Click">
                                       

                                                        </asp:LinkButton>
                                                    </div>
                                                </div>

                                                <div class="col-sm-12">
                                                    <div class="table-responsive">
                                                        
                                                        <table class="table table-sm table-bordered">
                                                    <thead class="bg-gradient-navy">
                                                        <th></th>
                                                        <th>Descripcion</th>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Repeater ID="repeaterImagenes" OnItemCommand="repeaterImagenes_ItemCommand" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:LinkButton CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('¿Realmente desea eliminar el registro?')" CommandName="Eli" CssClass=" fa fa-trash " runat="server"></asp:LinkButton>

                                                                    </td>
                                                                    <td>
                                                                        <%# Eval("Descripcion") %>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        </tbody>
                                                            </table>
                                                    </div>
                                                </div>


                                        </ContentTemplate>
                                        <Triggers>

                                            <asp:PostBackTrigger ControlID="btnGuardarFoto" />
                                            <asp:AsyncPostBackTrigger ControlID="repeaterReporte" EventName="ItemCommand" />
                                            <asp:AsyncPostBackTrigger ControlID="repeaterImagenes" EventName="ItemCommand" />
                                            <asp:AsyncPostBackTrigger ControlID="btnGenerar" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnEliminarCrud" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnGuardarCrud" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnCancelarModificacion" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="repeaterPendienteRevision" EventName="ItemCommand" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-12">
                        <div class="container-fluid">
                            <div class="card card-default">
                                <div class="card-header ">


                                    <div class="card-tools">
                                        <b class="text-info">Pendiente de enviar a revision</b>
                                        <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                            <i class="fas fa-minus"></i>
                                        </button>

                                    </div>

                                </div>
                                <div class="card-body">
                                    <!--4 pendientes de enviar a revision-->
                                    <asp:UpdatePanel ID="upGVpendienteRevision" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>


                                            <asp:LinkButton ID="btnEnviarRevision" runat="server" OnClick="btnEnviarRevision_Click" ToolTip="Enviar a revision" CssClass="fa fa-share"></asp:LinkButton>
                                            <div class="table-responsive">
                                                <table class="table table-sm table-bordered">
                                                    <thead class="bg-gradient-navy">
                                                        <th></th>
                                                        <th>Categoria</th>
                                                        <th>Elemento</th>
                                                        <th>Valor</th>
                                                        <th>Cantidad</th>
                                                        <th>Precio</th>
                                                        <th>Comentario</th>
                                                        <th>Es Externo</th>
                                                    </thead>
                                                    <tbody>


                                                        <asp:Repeater ID="repeaterPendienteRevision" OnItemCommand="repeaterPendienteRevision_ItemCommand" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:LinkButton CommandArgument='<%# Eval("ID") %>' CommandName="Editar" CssClass=" fa  fa-edit " runat="server"></asp:LinkButton>
                                                                        <asp:LinkButton CommandArgument='<%# Eval("ID") %>' CommandName="Eliminar" CssClass=" fa  fa-trash " runat="server" OnClientClick="return confirm('¿Realmente desea eliminar el registro?')"></asp:LinkButton>


                                                                    </td>

                                                                    <td><%# Eval("Categoria") %></td>
                                                                    <td><%# Eval("Elemento") %></td>
                                                                    <td><%# Eval("Valor") %></td>
                                                                    <td><%# Eval("Cantidad") %></td>
                                                                    <td><%# Eval("Precio") %></td>
                                                                    <td><%# Eval("Comentario") %></td>
                                                                    <td>
                                                                        <input type="checkbox" "c<%# if(Eval("EsExterno") = "1", "Checked", "") %>"/>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </ContentTemplate>

                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnEnviarRevision" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnGenerar" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnEliminarCrud" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnGuardarCrud" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="repeaterPendienteRevision" EventName="ItemCommand" />
                                        </Triggers>

                                    </asp:UpdatePanel>



                                    <!---Fin de pendientes-->
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Linea de tiempo</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>

                    </div>
                    <div class="card-body">
                        <!---2 Inicio de linea de tiempo --->


                        <asp:UpdatePanel ID="upLinea" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>





                                <asp:Panel ID="panelLineaTiempo" runat="server">

                                    <div class="card-body border-secondary">
                                        <asp:HiddenField ID="hfCodigo" runat="server" />
                                        <asp:HiddenField ID="hfDivision" runat="server" />
                                        <asp:HiddenField ID="hfSolicitud" runat="server" />

                                        <div class="timeline">

                                            <asp:Repeater ID="repeaterReporte" OnItemCommand="repeaterReporte_ItemCommand" runat="server">


                                                <ItemTemplate>

                                                  <!-- timeline time label -->
                                                    <div class="time-label " style="display:none;">
                                                    </div>
                                                    <!-- /.timeline-label -->
                                                    <!-- timeline item -->
                                                    <div runat="server"  Style='<%# If(Eval("Observaciones_Revision") Is DBNull.Value, "display:none;", "display:Block;")%>'>

                                                        <i class="  <%#If(Eval("Estado").Equals("Aprobado") Or Eval("Estado").Equals("Revisada"), " fa fa-check bg-success", "fas  fa-exclamation-triangle  bg-danger")  %>"></i>
                                                        <div class="timeline-item">

                                                            <span class="time"><i class="fas fa-clock"></i><%# Eval("Fecha_Enviado", "{0:dd/MM/yyyy hh:mm tt}")%> <%#  Eval("Observaciones_Revision") %></span>
                                                            <h3 class="timeline-header"><%# Eval("cat") %></h3>
                                                            <div class="timeline-body">
                                                            
                                                                    <div class="col-sm-10">

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
                                                                                <a href='https://www.fogelonline.com<%# Eval("Arch")%>' target="_blank">  
                                                                                    <%# Eval("ArchDescr")%>                

                                                                                </a>


                                                                            </td>

                                                                        </tr>
                                                                        <tr runat="server"   id="trAbre" visible='<%# Not Eval("elem") Is DBNull.Value AndAlso (Left(Eval("elem"), 6) = "INICIO" Or Left(Eval("elem"), 3) = "FIN")%>'>
                                                                            <td style="border-left-style: solid;"></td>
                                                                            <td colspan="3" style="color: #00DF00" onclick="abrirReportes();" class="LinkGuardaReporte"><button class="btn btn-sm text-primary " onclick="abrirReportes('<%# Eval("Folder")%>');"  ><%# Eval("Folder")%></button></td>
                                                                            
                                                                        </tr>
                                                                    </div>
                                                                <div class="col-sm-2">

                                                                        <!--
                                                                       
                                                                        -->
                                                                        <tr runat="server" id="tr3" visible='<%# cbPresentacion.Checked %>'>
                                                                            <td>
                                                                                <asp:LinkButton CommandArgument='<%# Eval("ID") %>' CommandName="editarHistoricos" CssClass=" fa fa-2x fa-edit btn btn-warning" runat="server"></asp:LinkButton>


                                                                                &nbsp;&nbsp;
                                                    
                                                          <tr runat="server" id="tr1" visible='<%# Eval("Estado") = "Aprobado"%>'>
                                                              <td>
                                                                  <asp:LinkButton CommandArgument='<%# Eval("ID") %>' CommandName="rechazarHistorico" CssClass=" fa fa-2x fa-exclamation-triangle" runat="server"></asp:LinkButton>

                                                              </td>
                                                          </tr>
                                                                                <tr runat="server" id="tr2" visible='<%#  Eval("Estado") = "Ingresado"%>'>
                                                                                    <td>
                                                                                        <asp:LinkButton CommandArgument='<%# Eval("ID") %>' CommandName="aprobarHistorico" CssClass=" fa fa-2x fa-check " runat="server"></asp:LinkButton>


                                                                                    </td>
                                                                                </tr>

                                                                            </td>
                                                                        </tr>

                                                                    </div>
                                                                   

                                                            </div>
                                                        </div>
                                                    </div>


                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </div>


                                    </div>
                                </asp:Panel>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnGenerar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btnEnviarRevision" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="repeaterReporte" EventName="ItemCommand" />
                                <asp:AsyncPostBackTrigger ControlID="btnEliminarCrud" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btnGuardarCrud" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <!---2 Fin de linea de tiempo --->
                    </div>
                </div>
            </div>


        </section>
    </div>
</asp:Content>
