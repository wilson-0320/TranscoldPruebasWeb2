<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="checkList.aspx.vb" Inherits="TranscoldPruebasWeb2.checkList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">

         <asp:UpdatePanel ID="upCrud" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
    <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Recepcion</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>
                    </div>
                    <div class="card-body">
                   


                                <div class="card">
                                    <div class="card-header bg-gradient-navy">

                                        <div class="row">

                                            <div class="col-lg-2">
                                                
                                                <small>Solicitud</small>
                                                    <asp:TextBox ID="tbCodigoFiltro" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="col-lg-2">
                                                <small>Modelo</small>

                                                    <asp:TextBox ID="tbModeloFiltro" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>

                                            <div class="col-lg-1">

                                                <br />
                                                    <asp:LinkButton ID="btnGenerar" runat="server" ToolTip="Filtrar" CssClass="fa  fa-2x fa-retweet" OnClick="btnGenerar_Click">
                                       </asp:LinkButton>

                                            </div>
                                        </div>



                                    </div>
                                    <div class="card-body">
                                        <asp:HiddenField ID="hfQuery" runat="server" />
                                        <asp:HiddenField ID="hfID" runat="server" />
                                        <div class="row">
                                            <div class="col-lg-2">
                                                <asp:Label ID="lblCliente" CssClass="text-sm" runat="server" Text="Cliente:"></asp:Label>
                                                <asp:TextBox ID="tbCliente" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="lblPais" CssClass="text-sm"  runat="server" Text="Pais origen:"></asp:Label>
                                                <asp:TextBox ID="tbPais" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="lblSolicitado" CssClass="text-sm"  runat="server" Text="Solicitado por:"></asp:Label>
                                                <asp:TextBox ID="tbSolicitado" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                            <div class="col-lg-2">

                                                <asp:Label ID="lblTipo" CssClass="text-sm"  runat="server" Text="Tipo"></asp:Label>
                                                <asp:DropDownList ID="dplTipo" runat="server" CssClass="form-control">
                                                    <asp:ListItem>Recepcion</asp:ListItem>
                                                    <asp:ListItem>Entrega</asp:ListItem>
                                                </asp:DropDownList>

                                            </div>
                                             <div class="col-lg-2">

                                                <asp:Label ID="lblSolicitud" CssClass="text-sm" runat="server" Text="Codigo de solicitud:"></asp:Label>

                                                <asp:TextBox ID="tbCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="lblModelo" CssClass="text-sm" runat="server" Text="Modelo:"></asp:Label>
                                                <asp:TextBox ID="tbModelo" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-lg-2">
                                                <asp:Label ID="lblwo" CssClass="text-sm" runat="server" Text="Word order:"></asp:Label>
                                                <asp:TextBox ID="tbWorkOrder" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="lblNoSerie" CssClass="text-sm" runat="server" Text="No. Serie:"></asp:Label>
                                                <asp:TextBox ID="tbSerie" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="lblUsuarioOperador" CssClass="text-sm" runat="server" Text="Usuario de laboratorio"></asp:Label>
                                                <asp:Label ID="lblUser" runat="server" Text="" CssClass="form-control"></asp:Label>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="lblUsuarioDespacho" CssClass="text-sm" runat="server" Text="Empleado despacho"></asp:Label>
                                                <asp:TextBox ID="tbDespachos" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            
                                           
                                        </div>


                                        <div class="row">
                                            <div class="col-lg-2">
                                                <asp:Label ID="lblParillas" CssClass="text-sm" runat="server" Text="Parillas:"></asp:Label>
                                                <asp:TextBox ID="tbParrillas" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="lblClips"  CssClass="text-sm" runat="server" Text="Clips:"></asp:Label>
                                                <asp:TextBox ID="tbClips" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="lblLamparas" CssClass="text-sm" runat="server" Text="Lamparas"></asp:Label>
                                                <asp:TextBox ID="tbLamparas" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>

                                            </div>
                                            <div class="col-lg-2">

                                                <asp:Label ID="lblRotulo" CssClass="text-sm" runat="server" Text="Rotulo"></asp:Label>
                                                <asp:CheckBox ID="cbRotulo" CssClass="form-check" runat="server" />


                                            </div>
                                            <div class="col-lg-2">

                                                <asp:Label ID="lblCubremotor" CssClass="text-sm" runat="server" Text="Cubremotor:"></asp:Label>
                                                <asp:CheckBox ID="cbCubremotor" CssClass="form-check" runat="server" />


                                            </div>
                                            <div class="col-lg-2">

                                                <asp:Label ID="lblCertificado" CssClass="text-sm" runat="server" Text="Cert. Prueba:"></asp:Label>
                                                <asp:CheckBox ID="cbCertificado" CssClass="form-check" runat="server" />


                                            </div>


                                        </div>

                                        <div class="row">
                                            <div class="col-lg-2">

                                                <asp:Label ID="lblEtiqueta" CssClass="text-sm" runat="server" Text="Etiq.Serie:"></asp:Label>
                                                <asp:CheckBox ID="cbEtiquetaSerie" CssClass="form-check" runat="server" />


                                            </div>
                                            <div class="col-lg-2">

                                                <asp:Label ID="lblMan1" CssClass="text-sm" runat="server" Text="Manual Operacion:"></asp:Label>
                                                <asp:CheckBox ID="cbManOpe" CssClass="form-check" runat="server" />


                                            </div>
                                            <div class="col-lg-2">

                                                <asp:Label ID="lblManIns" CssClass="text-sm" runat="server" Text="Manual Instalacion:"></asp:Label>
                                                <asp:CheckBox ID="cbManIns" CssClass="form-check" runat="server" />


                                            </div>
                                            <div class="col-lg-2">

                                                <asp:Label ID="lblCal" CssClass="text-sm" runat="server" Text="Calcomania:"></asp:Label>
                                                <asp:CheckBox ID="cbCalcomania" CssClass="form-check" runat="server" />


                                            </div>
                                            <div class="col-lg-2">

                                                <asp:Label ID="lblDiagrama" CssClass="text-sm" runat="server" Text="Diagrama:"></asp:Label>
                                                <asp:CheckBox ID="cbDiagrama" CssClass="form-check" runat="server" />


                                            </div>
                                            <div class="col-lg-2">

                                                <asp:Label ID="lblFunciona" CssClass="text-sm" runat="server" Text="Funcionamiento:"></asp:Label>
                                                <asp:CheckBox ID="cbFuncionamiento" CssClass="form-check" runat="server" />


                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-lg-2">

                                                <asp:Label ID="lblParTrasera"  CssClass="text-sm" runat="server" Text="Parillas Trasera:"></asp:Label>
                                                <asp:CheckBox ID="cbParrillasTraseras" CssClass="form-check" runat="server" />


                                            </div>
                                            <div class="col-lg-2">

                                                <asp:Label ID="lblHalador" CssClass="text-sm" runat="server" Text="Haladores:"></asp:Label>
                                                <asp:CheckBox ID="cbHalador" CssClass="form-check" runat="server" />


                                            </div>
                                            <div class="col-lg-2">

                                                <asp:Label ID="lblGolpes"  CssClass="text-sm" runat="server" Text="Golpes:"></asp:Label>
                                                <asp:TextBox ID="tbGolpes" runat="server" CssClass="form-control"></asp:TextBox>


                                            </div>
                                            <div class="col-lg-2">

                                                <asp:Label ID="lblRayon" CssClass="text-sm" runat="server" Text="Rayones:"></asp:Label>
                                                <asp:TextBox ID="tbRayones" runat="server" CssClass="form-control"></asp:TextBox>


                                            </div>
                                            <div class="col-lg-2">

                                                <asp:Label ID="lblComentarios" CssClass="text-sm" runat="server" Text="Comentarios:"></asp:Label>
                                                <asp:TextBox ID="tbComentarios" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="col-lg-2">
                                                <br />
                                                <asp:LinkButton ID="lbtnGuardar" runat="server" CssClass="fa fa-2x fa-save" OnClick="lbtnGuardar_Click">
                         
                                                </asp:LinkButton>

                                                <asp:LinkButton ID="lbtnCancelar" runat="server" CssClass="fa fa-2x fa-minus" OnClick="lbtnCancelar_Click">
                         
                                                </asp:LinkButton>
                                            </div>
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
                            <b class="text-info">Listado</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>
                    </div>
                    <div class="card-body">


            <div class="row">
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Repeater ID="RepeaterRecepcion" runat="server" OnItemCommand="RepeaterRecepcion_ItemCommand">

                        <ItemTemplate>



                            <table class="table-bordered table-hover ">

                                <tr>
                                    <td class="bg-gradient-navy">
                                        <asp:LinkButton ID="LinkButton1" runat="server" ToolTip="Modificar" CssClass=" fa fa-2x fa-edit" CommandArgument='<%# Eval("ID") %>' CommandName="ModificarRecepcion">
                                        </asp:LinkButton>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


              <asp:LinkButton ID="lbtnEliminarCrud" runat="server" ToolTip="Eliminar" CssClass=" fa fa-2x fa-trash" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('¿Realmente desea eliminar el registro?')" CommandName="EliminarRecepcion">
                                     

              </asp:LinkButton>

                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Fecha de operacion </td>
                                    <td><%# Eval("FechaCreacion") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Cliente </td>
                                    <td class="text-center"><%# Eval("Cliente") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Tipo </td>
                                    <td class="text-center"><%# Eval("Tipo_Operacion") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Codigo </td>
                                    <td class="text-center"><%# Eval("Codigo") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Pais de origen </td>
                                    <td class="text-center"><%# Eval("PaisOrigen") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Solicitado por </td>
                                    <td class="text-center"><%# Eval("Solicitado") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">W.O. </td>
                                    <td class="text-center"><%# Eval("Work_Order") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Serie </td>
                                    <td class="text-center"><%# Eval("Numero_Serie") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Modelo </td>
                                    <td class="text-center"><%# Eval("Modelo") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Parillas </td>
                                    <td class="text-center"><%# Eval("Parillas") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Clips </td>
                                    <td class="text-center"><%# Eval("Clip") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Lamparas </td>
                                    <td class="text-center"><%# Eval("Lamparas") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Observaciones </td>
                                    <td class="text-center"><%# Eval("Observaciones") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Rayones</td>
                                    <td class="text-center"><%# Eval("Rayones") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Golpes</td>
                                    <td class="text-center"><%# Eval("Golpes") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Rotulo</td>
                                    <td class="text-center"><%# if(Eval("Rotulo") = 0, "No", "Si") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Cubremotor</td>
                                    <td class="text-center"><%#If(Eval("Cubremotor") = 0, "No", "Si") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Certificado</td>
                                    <td class="text-center"><%#If(Eval("Certificado") = 0, "No", "Si") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Etiqueta de serie</td>
                                    <td class="text-center"><%#If(Eval("Etiq_Serie") = 0, "No", "Si") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Calcomanias</td>
                                    <td class="text-center"><%#If(Eval("Calcomanias") = 0, "No", "Si") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Manual de operacion</td>
                                    <td class="text-center"><%#If(Eval("Man_Oper") = 0, "No", "Si") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Manual de Instalacion</td>
                                    <td class="text-center"><%#If(Eval("Man_Ins") = 0, "No", "Si") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Diagrama</td>
                                    <td class="text-center"><%#If(Eval("Diagrama") = 0, "No", "Si") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Funcionamiento</td>
                                    <td class="text-center"><%#If(Eval("Funcionamiento") = 0, "No", "Si") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Parilla Trasera</td>
                                    <td class="text-center"><%#If(Eval("Parilla_Trasera") = 0, "No", "Si") %></td>
                                </tr>

                                <tr>
                                    <td class="bg-gradient-navy">Parilla Trasera</td>
                                    <td class="text-center"><%#If(Eval("Haladores") = 0, "No", "Si") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Operador de laboratorio</td>
                                    <td class="text-center"><%#Eval("Usuario_Laboratorio") %></td>
                                </tr>
                                <tr>
                                    <td class="bg-gradient-navy">Operador de Despachos</td>
                                    <td class="text-center"><%#Eval("Usuario_Entrega") %></td>
                                </tr>

                            </table>


                            &nbsp;&nbsp;&nbsp;&nbsp;




                        </ItemTemplate>
                    </asp:Repeater>

            </div>
       
                        </div>
                     </div>
                 </div>
            </section>
             </div>
                                   </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="RepeaterRecepcion" EventName="ItemCommand" />
                                <asp:AsyncPostBackTrigger ControlID="lbtnCancelar" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>

</asp:Content>
