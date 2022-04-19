<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="Equipo.aspx.vb" Inherits="TranscoldPruebasWeb2.Equipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
    <div class="content-wrapper">
        <section class="content">

            <div class="row">
                <div class="col-sm-12">
              
           
            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Tab Panel</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>

                    </div>

                  
                    <div class="card-body">
                        <asp:UpdatePanel ID="upInstrumentos" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                                            <table id="tt" class="table table-responsive tt table-sm table-bordered">
                                                <thead class="bg-gradient-navy">
                                                    <th></th>
                                                    <th>Nombre
                                                    </th>
                                                    <th>Codigo
                                                    </th>

                                                    <th>Tipo
                                                    </th>

                                                    <th>Fabricante
                                                    </th>

                                                    <th>Marca
                                                    </th>

                                                    <th>Modelo
                                                    </th>

                                                    <th>Serie
                                                    </th>

                                                    <th>Firmware/Software
                                                    </th>

                                                    <th>Intevalo
                                                    </th>

                                                    <th>Resolucion
                                                    </th>
                                                    <th>Rango de calibracion
                                                    </th>
                                                    <th>No. de puntos a calibrar
                                                    </th>
                                                    <th>Ubicacion
                                                    </th>
                                                    <th>Estado de equipo
                                                    </th>
                                                    <th>Certificado
                                                    </th>
                                                    <th>Fecha de calibracion
                                                    </th>
                                                    <th>Proxima fecha de calibracion
                                                    </th>
                                                </thead>
                                                <tbody>

                                                    <asp:Repeater ID="repeaterInstrumentos" runat="server" OnItemCommand="repeaterInstrumentos_ItemCommand" >
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                  
                                                                            <asp:LinkButton ID="LinkButton1" Visible='<%# Eval("Estado") %>' runat="server" CssClass=" fa  fa-trash" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('¿Realmente desea eliminar el registro?')" CommandName="eliminarInstrumento"></asp:LinkButton>
                                                                     <asp:LinkButton ID="LinkButton2" Visible='<%#If(Eval("Estado") = "0", True, False) %>' runat="server" CssClass=" fa  fa-check" CommandArgument='<%# Eval("ID") %>' CommandName="aprobarInstrumento"></asp:LinkButton>
                                                                   
                                                                        
                                                                             <asp:LinkButton ID="LinkButton3" runat="server" CssClass=" fa   fa-edit" CommandArgument='<%# Eval("ID") %>' CommandName="editarInstrumento"></asp:LinkButton>
                                                                   
                                                                    
                                                                    
                                                                </td>
                                                                <td><%# Eval("Nombre") %></td>
                                                                <td><%# Eval("Codigo") %></td>
                                                                <td><%# Eval("Tipo") %>  </td>
                                                                <td>
                                                                    <%# Eval("Fabricante") %>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("Marca") %>

                                                                </td>
                                                                <td>
                                                                    <%# Eval("Modelo") %>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("Serie") %>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("Firmware_Software") %>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("Intervalo") %>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("Resolucion") %>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("Rango_Calibracion") %>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("No_Puntos_Calibracion") %>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("Ubicacion") %>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("Estado_Equipo") %>
                                                                </td>
                                                                <td><a target="_blank" href="<%# Eval("Certificado") %>">Certificado digital</a>  </td>
                                                                <td>
                                                                    <%# Eval("Fecha_Calibracion") %>
                                                                <td>
                                                                    <%# Eval("Proxima_Calibracion") %>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </table>
                                        

                             
                           
                                   

                            


                            </ContentTemplate>
                            <Triggers>
                              
                                <asp:AsyncPostBackTrigger ControlID="lbtnCancelar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardarCertificado" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="repeaterCertificados" EventName="ItemCommand" />
                                <asp:AsyncPostBackTrigger ControlID="repeaterInstrumentos" EventName="ItemCommand" />
                              
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
                    </div>
                
                 </div>


            <div class="row">
                  <div class="col-sm-4">
             <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Ingreso de equipos</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>

                    </div>
                    
                                        <div class="card-body">
                                            <asp:UpdatePanel ID="upCrudEquipo" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>

                                                
                                            <div class="row">
                                                <asp:HiddenField ID="hfQuery" runat="server" />
                                                <asp:HiddenField ID="hfID" runat="server" />
                                                <div class="col-sm-3">
                                                    <small>Nombre</small>
                                                    <asp:TextBox ID="tbNombre" runat="server"  ToolTip="Nombre o descripcion del equipo" CssClass="form-control"></asp:TextBox>

                                                </div>
                                                <div class="col-sm-3">

                                                    <small>Fabricante</small>
                                                    <asp:TextBox ID="tbFabricante" runat="server"  ToolTip="Fabricante del equipo" CssClass="form-control"></asp:TextBox>

                                                </div>
                                                <div class="col-sm-3">
                                                    <small>Modelo</small>
                                                    <asp:TextBox ID="tbModelo" runat="server"  ToolTip="Modelo del equipo" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3">

                                                    <small>Serie</small>
                                                    <asp:TextBox ID="tbSerie" runat="server"  ToolTip="Serie del equipo" CssClass="form-control"></asp:TextBox>


                                                </div>
                                                
                                            </div>
                                                    <hr />
                                            <div class="row">
                                                <div class="col-sm-3">

                                                    <small>Software</small>

                                                    <asp:TextBox ID="tbSoftware" runat="server"  ToolTip="Firmware/Sofware del equipo" CssClass="form-control"></asp:TextBox>

                                                </div>
                                                <div class="col-sm-5">

                                                    <small>Intervalo</small>

                                                    <asp:TextBox ID="tbIntervalo" runat="server"  ToolTip="Intervalo del equipo" CssClass="form-control"></asp:TextBox>

                                                </div>
                                                <div class="col-sm-4">

                                                    <small>Resolucion</small>

                                                    <asp:TextBox ID="tbResolucion" runat="server" ToolTip="Resolucion del equipo" CssClass="form-control"></asp:TextBox>
                                                </div>
                                               
                                            </div>
                                            <hr />
                                            <div class="row">
                                                 <div class="col-sm-5">

                                                    <small>Rango</small>
                                                    <asp:TextBox ID="tbRango" runat="server"  ToolTip="Rango de calibración del equipo" CssClass="form-control"></asp:TextBox>

                                                </div>
                                                <div class="col-sm-5">
                                                    <small>Puntos cal</small>
                                                    <asp:TextBox ID="tbNoPuntos" runat="server"  ToolTip="Puntos de calibración del equipo" CssClass="form-control"></asp:TextBox>

                                                </div>
                                                <div class="col-sm-2">

                                                    <small>Tipo.</small>
                                                    <asp:DropDownList ID="ddlTipoEquipo" runat="server" CssClass="form-control">
                                                        <asp:ListItem>Patron</asp:ListItem>
                                                        <asp:ListItem>Instrumento de referencia</asp:ListItem>
                                                        <asp:ListItem>Instrumento de medición</asp:ListItem>


                                                    </asp:DropDownList>
                                                </div>
                                               
                                                 </div>
                                            <hr />
                                            <div class="row">
                                                 <div class="col-sm-4">
                                                    <small>Ubicacion</small>
                                                     <asp:DropDownList ID="ddlCamaras" CssClass="js-example-theme-single form-control" ToolTip="Camaras" runat="server"></asp:DropDownList>
                                                   


                                                </div>
                                                
                                                <div class="col-sm-3">
                                                    <small>Magnitud</small>

                                                    <asp:DropDownList runat="server"
                                                        CssClass="js-example-theme-single form-control" ToolTip="Magnitud"
                                                        ID="ddlMagnitud" AutoPostBack="false" AppendDataBoundItems="True">
                                                    </asp:DropDownList>
                                                </div>
                                                
                                                <div class="col-sm-3">

                                                    <small>Marca</small>
                                                    <asp:DropDownList runat="server"
                                                        CssClass="js-example-theme-single form-control" ToolTip="Marca"
                                                        ID="ddlMarca" AutoPostBack="false" AppendDataBoundItems="True">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-2">
                                                    <br />
                                                    <asp:LinkButton ID="lbtnGuardar" runat="server" ToolTip="Guardar" CssClass="fa fa-2x  fa-save " OnClick="lbtnGuardar_Click">
                                        

                                                    </asp:LinkButton>


                                                    <asp:LinkButton ID="lbtnCancelar" runat="server" ToolTip="cancelar" CssClass="fa fa-2x  fa-close " OnClick="lbtnCancelar_Click">
                                        

                                                    </asp:LinkButton>
                                                </div>
                                            </div>

                                                    </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="repeaterInstrumentos" EventName="ItemCommand" />
                                                    <asp:AsyncPostBackTrigger ControlID="lbtnCancelar" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            

                                        </div>
                    </div>
                 </div>
                      </div>
                <div class="col-sm-4">
                    <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Laboratorio acreditados</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>
                        </div>
                        <div class="card-body">
                        <asp:UpdatePanel ID="upLaboratorios" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            
                        
                            <asp:HiddenField ID="hfQueryLab" runat="server" />
                            <asp:HiddenField ID="hfIDInstrumento" runat="server" />
                            <div class="row">
                                
                                <div class="col-lg-8">
                                    <small>Laboratorios con alcance</small>
                                    <asp:DropDownList runat="server"
                                        CssClass="js-example-theme-single form-control" ToolTip="Marca"
                                        ID="ddlLaboratorios" AutoPostBack="False" AppendDataBoundItems="True">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-2 form-inline">
                                    <asp:LinkButton ID="lbtnGuardarLaboratorios" runat="server" ToolTip="Guardar" OnClick="lbtnGuardarLaboratorios_Click" CssClass="fa fa-2x  fa-save " >
                                        

                                    </asp:LinkButton>
                                </div>
                            </div>
                            <br />
                       

                        <div class="table-responsive">
                            <table class="table table-bordered table-sm table-hover">
                                <thead class="bg-gradient-navy">
                                    <th></th>
                                    <th>Laboratorio</th>
                                </thead>
                                <tbody>


                                    <asp:Repeater ID="repeaterLaboratorios" runat="server" OnItemCommand="repeaterLaboratorios_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass=" fa  fa-trash" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('¿Realmente desea eliminar el registro?')" CommandName="eliminarLaboratorio"></asp:LinkButton>

                                                </td>
                                                <td><%# Eval("Descripcion") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    
               
        </ContentTemplate>
       
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardarLaboratorios" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="repeaterLaboratorios" EventName="ItemCommand" />
                                <asp:AsyncPostBackTrigger ControlID="repeaterInstrumentos" EventName="ItemCommand" />
                            </Triggers>
       
    </asp:UpdatePanel>
                             </div>
                 
                    </div>
                   </div>
                </div>

                <div class="col-sm-4">
                    <div class="container-fluid">
                        <div class="card card-default">
                            <div class="card-header ">


                                <div class="card-tools">
                                    <b class="text-info">Servicio de certificados</b>
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>

                                </div>
                            </div>
                            <div class="card-body">
                                 <asp:UpdatePanel ID="upCertificados" runat="server" UpdateMode="Conditional">
       <ContentTemplate>
             <div class="card-body">
                    <asp:HiddenField ID="hfQueryCertificados" runat="server" />
                    <asp:HiddenField ID="hfIDCertificados" runat="server" />

                    <div class="row">
                        <div class="col-sm-3">
                              <small>Lab. enviado</small>   
                            <asp:DropDownList runat="server"
                                                CssClass="form-control" ToolTip="Magnitud"
                                                ID="ddlLaboratoriosAsignados" AutoPostBack="True" AppendDataBoundItems="True">
                                            </asp:DropDownList>

                        </div>
                          <div class="col-sm-3">
                                <small>Guia envio</small>   
    <asp:TextBox ID="tbGuiaEnvio" runat="server"  CssClass="form-control"></asp:TextBox>

                                        
                        
                    </div>
                        <div class="col-sm-3">
                                <small>Guia retorno</small>   
    <asp:TextBox ID="tbGuiaRetorno" runat="server"  CssClass="form-control"></asp:TextBox>

                                        
                        
                    </div>
                        <div class="col-sm-3">
                          <small>Certificado</small>        
    <asp:TextBox ID="tbCertificado" runat="server"  CssClass="form-control"></asp:TextBox>

                                        
                        
                    </div>
                        </div>
                 <div class="row">
                        <div class="col-sm-4">
             <small>Fecha de calibración</small>                 
    <asp:TextBox ID="tbFechaCal" runat="server" Placeholder="" CssClass="form-control"  TextMode="date"></asp:TextBox>

                                        
                        
                    </div>
                         <div class="col-sm-4">
                              <small>Proxima calibracion.</small>  
    <asp:TextBox ID="tbFechaProx" runat="server" Placeholder="" CssClass="form-control" TextMode="date"></asp:TextBox>

                                        
                        
                    </div>
                         <div class="col-sm-2 form-inline">
                              <asp:LinkButton ID="lbtnGuardarCertificado" runat="server" ToolTip="Guardar" OnClick="lbtnGuardarCertificado_Click" CssClass="fa  fa-2x fa-save "  >
                                        

                                        </asp:LinkButton>
                                    &nbsp;&nbsp
                                   
                                        <asp:LinkButton ID="lbtnCancelarCertificado" runat="server" OnClick="lbtnCancelarCertificado_Click" ToolTip="cancelar" CssClass="fa fa-2x  fa-close "  >
                                        

                                        </asp:LinkButton>
                             </div>
                             
                </div>
                  <div class="table-responsive">
                      <table class="table table-bordered table-sm table-hover">
                                <thead class="bg-gradient-navy">
                                    <th></th>
                                    <th>Laboratorio</th>
                                    <th>Guia de envio</th>
                                    <th>Guia de retorno</th>
                                    <th>Certificado</th>
                                    <th>Fecha de calibracion</th>
                                    <th>Proxima fecha de calibracion.</th>
                                </thead>
                                <tbody>

                                    <asp:Repeater ID="repeaterCertificados" runat="server" OnItemCommand="repeaterCertificados_ItemCommand" >
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                  <asp:LinkButton ID="LinkButton1" runat="server" CssClass=" fa  fa-trash" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('¿Realmente desea eliminar el registro?')" CommandName="eliminarCertificado"></asp:LinkButton>
                                                    
                                                  <asp:LinkButton ID="LinkButton5" runat="server" CssClass=" fa  fa-edit" CommandArgument='<%# Eval("ID") %>'  CommandName="modificarCertificado"></asp:LinkButton>
                                                
                                                </td>
                                                <td>
                                                    <%# Eval("Equipo") %>
                                                </td>
                                                
                                                <td>
                                                    <%# Eval("Guia_Envio") %>
                                                </td>
                                                <td>
                                                    <%# Eval("Guia_Retorno") %>
                                                </td>
                                                <td>
                                                  <a target="_blank" href="<%# Eval("Certificado") %>">Certificado digital</a>  
                                                </td>
                                                 <td>
                                                    <%# Eval("Fecha_Calibracion") %>
                                                      <td>
                                                    <%# Eval("Proxima_Calibracion") %>
                                                </td>
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
         
            <asp:AsyncPostBackTrigger ControlID="repeaterInstrumentos" EventName="ItemCommand" />
            <asp:AsyncPostBackTrigger ControlID="lbtnGuardarCertificado" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="lbtnCancelarCertificado" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="repeaterCertificados" EventName="ItemCommand" />
            <asp:AsyncPostBackTrigger ControlID="repeaterLaboratorios" EventName="ItemCommand" />
         
            <asp:AsyncPostBackTrigger ControlID="lbtnGuardarLaboratorios" EventName="Click" />
         
        </Triggers>
    </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
               

               
        </section>
    </div>
</asp:Content>
