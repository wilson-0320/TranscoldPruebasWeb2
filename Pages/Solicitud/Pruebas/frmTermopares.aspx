<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="frmTermopares.aspx.vb" Inherits="TranscoldPruebasWeb2.frmTermopares" %>


<%@ Register Src="~/Pages/Solicitud/Pruebas/PaginasTermopar/wucRefrig.ascx" TagPrefix="uc1" TagName="wucRefrig" %>
<%@ Register Src="~/Pages/Solicitud/Pruebas/PaginasTermopar/wucVidrios.ascx" TagPrefix="uc2" TagName="wucVidrios" %>
<%@ Register Src="~/Pages/Solicitud/Pruebas/PaginasTermopar/wucPanaEvaporador.ascx" TagPrefix="uc3" TagName="wucPanaEvaporador" %>
<%@ Register Src="~/Pages/Solicitud/Pruebas/PaginasTermopar/wucElectric.ascx" TagPrefix="uc4" TagName="wucElectric" %>
<%@ Register Src="~/Pages/Solicitud/Pruebas/PaginasTermopar/wucEstacionPruebas.ascx" TagPrefix="uc5" TagName="wucEstacionPruebas" %>
<%@ Register Src="~/Pages/Solicitud/Pruebas/PaginasTermopar/wucAdicionales.ascx" TagPrefix="uc6" TagName="wucAdicionales" %>






<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
    <asp:HiddenField ID="hfCodigo" runat="server" />
    <style>
        input {
            font-size: 75%;
        }
    </style>

    <script>
        function mostrarOpcion(id) {

            var element1 = document.getElementById(id);
            console.log("Iniciando");
            var divs = ["Main1_Main2_divProdTemp", "Main1_Main2_divRefrSystem1", "Main1_Main2_divRefrSystem2", "Main1_Main2_divGlassDoor",
                "Main1_Main2_divEvaporatorPan", "Main1_Main2_divElectrIndivM", "Main1_Main2_divStationParams", "Main1_Main2_divValoresAdicionales"];

            var element2 = document.getElementsByName(divs[id]);

            console.log(element2);
            for (var i = 0; i < divs.length; i++) {
                if (i == id) {
                    if (i == 0) {
                        document.getElementById(divs[id]).style.display = "inline-block";
                    } else {
                        document.getElementById(divs[id]).style.display = "block";
                    }
                    element1.className = "btn btn-primary ";



                } else {
                    document.getElementById(i + "").className = "btn btn-default ";
                    document.getElementById(divs[i]).style.display = "none";
                }

            }
            console.log("Finaliza portal");
            return false;
        }
    </script>

    <div class="content-wrapper">

        <section class="content">


            <div class="col-sm-12">


                <div class="container-fluid">
                    <div class="card card-default">
                        <div class="card-header ">


                            <div class="card-tools">
                                &nbsp; &nbsp; &nbsp;
                                <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                    <i class="fas fa-minus"></i>
                                </button>

                            </div>
                            <div class="col-sm-12 text-sm">
                                <br />
                                <button class="btn-primary btn  " name="0" id="0" onclick="return mostrarOpcion(this.id)">
                                    Product Temp.
                                </button>
                                &nbsp;&nbsp;&nbsp;
                                      <button class="btn-default btn" name="1" id="1" onclick="return mostrarOpcion(this.id)">
                                          Refrig. Sys1
                                      </button>
                                &nbsp;&nbsp;&nbsp;
                                    <button class="btn-default btn " name="2" id="2" onclick="return mostrarOpcion(this.id)">
                                        Refrig. Sys2
                                    </button>
                                &nbsp;&nbsp;&nbsp;
                                    <button class="btn-default btn " name="3" id="3" onclick="return mostrarOpcion(this.id)">
                                        Glass Door
                                    </button>
                                &nbsp;&nbsp;&nbsp;
                                    <button class="btn-default btn " name="4" id="4" onclick="return mostrarOpcion(this.id)">
                                        Evaporator Pan
                                    </button>
                                &nbsp;&nbsp;&nbsp;
                                     <button class="btn-default btn " name="5" id="5" onclick="return mostrarOpcion(this.id)">
                                         Electric Mesurements
                                     </button>
                                &nbsp;&nbsp;&nbsp;
                                      <button class="btn-default btn " name="6" id="6" onclick="return mostrarOpcion(this.id)">
                                          Station Parameters
                                      </button>
                              
                                      <button class="btn-default btn " name="7" id="7" onclick="return mostrarOpcion(this.id)">
                                          Val. Adicionales
                                      </button>
                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <button type="button" class="btn btn-dark" onclick="abrirModal('modal');">
                                                <i class="fas fa-plus"></i>
                                            </button>
                                     

                            </div>



                        </div>


                        <div class="card-body ">


                            <asp:UpdatePanel ID="pnlTodo" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>

                                    <div class="row">
                                        <div class="col-sm-11">



                                            <div id="divProdTemp" name="divProdTemp" style="display: inline-block" runat="server">
                                                <asp:GridView runat="server" ID="gvFilas" Width="100%" DataSourceID="dsTermoparFila" AutoGenerateColumns="False" ShowHeader="False">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>

                                                                <asp:HiddenField runat="server" ID="hfFila" Value='<%# Eval("fila")%>' />
                                                                <div runat="server" id="divPosicion" style="width: 100%; display: flex; border-left: 1px solid; padding-left: 12px;">
                                                                    <asp:Label runat="server" ID="lblFilaDe3" Text='<%# Eval("fila_de_3")%>' Width="24px" Font-Bold="true"></asp:Label>
                                                                    <asp:Repeater runat="server" ID="repColumnas" DataSourceID="dsColumnas" OnPreRender="repColumnas_PreRender">
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField runat="server" ID="hfPosicion" Value='<%# Eval("posicion")%>' />
                                                                            <table runat="server" id="tblPosicion" class="tblPosicion">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CheckBox runat="server" ID="chbParticipaProm" Checked='<%# Eval("participa_prom")%>' />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="tbNumCanal" Width="50px" Text='<%# Eval("num_canal")%>'></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                    <asp:ObjectDataSource ID="dsColumnas" runat="server" SelectMethod="consulta" TypeName="TranscoldPruebasWeb2.BLL.Pru_Termopar_BLL">
                                                                        <SelectParameters>
                                                                            <asp:QueryStringParameter Name="cod_solicitud" QueryStringField="codigo" Type="String" />
                                                                            <asp:ControlParameter ControlID="ddlFecha" Name="stFecha" PropertyName="SelectedValue" Type="String" />
                                                                            <asp:ControlParameter ControlID="hfFila" Name="fila" PropertyName="Value" Type="Int32" DefaultValue="-2" />
                                                                            <asp:Parameter DefaultValue="-1" Name="posicion_ini" Type="Int32" />
                                                                            <asp:Parameter DefaultValue="-1" Name="posicion_fin" Type="Int32" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>

                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>










                                                <asp:ObjectDataSource ID="dsTermoparFila" runat="server" SelectMethod="ObtieneDataTable" TypeName="TranscoldPruebasWeb2.Base_BLL">
                                                    <SelectParameters>
                                                        <asp:Parameter Name="dt" Type="Object" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>


                                            </div>
                                            <div runat="server" id="divRefrSystem1" name="divRefrSystem1" style="display: none; position: relative; width: 880px; height: 790px;">
                                                <uc1:wucRefrig runat="server" ID="wucRefrSystem1" codigo="" stFecha="" tb_ini="217" posicion_ini="217" posicion_fin="238" />
                                            </div>
                                            <div runat="server" id="divRefrSystem2" name="divRefrSystem2" style="display: none; position: relative; width: 880px; height: 790px;">
                                                <uc1:wucRefrig ID="wucRefrSystem2" runat="server" codigo="" stFecha="" tb_ini="217" posicion_ini="239" posicion_fin="260" />
                                            </div>
                                            <div runat="server" id="divGlassDoor" name="divGlassDoor" style="display: none; position: relative;">
                                                <uc2:wucVidrios runat="server" ID="wucGlassDoor" codigo="" stFecha="" tb_ini="261" posicion_ini="261" posicion_fin="287" />
                                            </div>
                                            <div runat="server" id="divEvaporatorPan" name="divEvaporatorPan" style="display: none; position: relative;">
                                                <uc3:wucPanaEvaporador ID="wucEvaporatorPan" runat="server" codigo="" stFecha="" tb_ini="288" posicion_ini="288" posicion_fin="293" />
                                            </div>
                                            <div runat="server" id="divElectrIndivM" name="divElectrIndivM" style="display: none; position: relative;">
                                                <uc4:wucElectric ID="wucElectrIndivM" runat="server" codigo="" stFecha="" tb_ini="294" posicion_ini="294" posicion_fin="311" />
                                            </div>
                                            <div runat="server" id="divStationParams" name="divStationParams" style="display: none; position: relative;">
                                                <uc5:wucEstacionPruebas ID="wucStationParams" runat="server" codigo="" stFecha="" tb_ini="312" posicion_ini="312" posicion_fin="316" />
                                            </div>
                                            <div runat="server" id="divValoresAdicionales" name="divValoresAdicionales" style="display: none; position: relative;">
                                                <uc6:wucAdicionales ID="wucValoresAdicionales" runat="server" codigo="" stFecha="" tb_ini="317" posicion_ini="317" posicion_fin="356" />
                                            </div>
                                            

                                        </div>
                                       
                                      
                                    </div>

                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="lbtnModificar" EventName="Click" />

                                    <asp:AsyncPostBackTrigger ControlID="ddlFecha" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>


                    </div>
                </div>
            </div>

        </section>
    </div>


      <div class="modal fade" id="modal" name="modal" data-backdrop="static">
                                            <div class="modal-dialog modal-xl">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h4 class="modal-title">CheckList</h4>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">

                                                        <asp:UpdatePanel ID="upFechas" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>

                                                           
                                                        <div class="row">
                                                            <div class="col-12 ">



                                                                <small>Fechas</small>
                                                                <asp:DropDownList ID="ddlFecha" CssClass="form-control" OnSelectedIndexChanged="ddlFecha_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                                <asp:Repeater ID="RepeaterFechas" OnItemCommand="RepeaterFechas_ItemCommand" runat="server">
                                                                   <HeaderTemplate>
                                                                       <table class="table table-bordered table-sm">
                                                                           <thead class="bg-gradient-navy">
                                                                               <tr>
                                                                                   <th></th>
                                                                                   <th>Fechas</th>
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
                                                                                <asp:LinkButton ID="LinkButton1" Visible='<%# If(Eval("estadoT") = True, False, True) %>' CommandArgument='<%# Eval("stFecha") %>' CommandName="val" CssClass=" fa fa-check"  runat="server"></asp:LinkButton>
                                                                                <asp:LinkButton ID="LinkButton2" Visible='<%# If(Eval("estadoT") = False, False, True) %>'  CommandArgument='<%# Eval("stFecha") %>' CommandName="eli" CssClass="fa fa-exclamation-triangle"  runat="server"></asp:LinkButton>
                                                                            </td>
                                                                            <td>
                                                                                <%# Eval("stFecha") %>
                                                                            </td>
                                                                        </tr>

                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </div>
                                                            <div class="col-sm-12 ">
                                                                <asp:Panel ID="panelEditorFecha" runat="server">
                                                                    <asp:TextBox ID="tbFechaReemplazo" runat="server" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="lbtnGuardarFecha" OnClick="lbtnGuardarFecha_Click" runat="server" CssClass="fa fa-save"></asp:LinkButton>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;        
                                    <asp:LinkButton ID="lbtnCancelarGuardarFecha" OnClick="lbtnCancelarGuardarFecha_Click" runat="server" CssClass="fa fa-minus"></asp:LinkButton>

                                                                </asp:Panel>
                                                            </div>
                                                        </div>
                                                                 </ContentTemplate>

                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="lbtnCancelarGuardarFecha" EventName="Click" />
                                                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardarFecha" EventName="Click" />
                                                                <asp:AsyncPostBackTrigger ControlID="RepeaterFechas" EventName="ItemCommand" />

                                                                   <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                                                                <asp:AsyncPostBackTrigger ControlID="ddlFecha" EventName="SelectedIndexChanged" />
                                                                <asp:AsyncPostBackTrigger ControlID="lbtnModificarFecha" EventName="Click" />
                                                            </Triggers>

                                                        </asp:UpdatePanel>
                                                        <br />
                                                        <hr />
                                                        <div class="row">
                                                           

                                                                <asp:LinkButton ID="lbtnModificarFecha" OnClick="lbtnModificarFecha_Click" CssClass="fa btn-sm btn btn-default" runat="server">Modificar fecha</asp:LinkButton>
                                                           
                                                   
                                                                &nbsp;&nbsp;&nbsp;&nbsp;   
                                                     <asp:LinkButton ID="lbtnModificar" OnClick="lbtnModificar_Click" CssClass="fa btn-sm btn btn-default " runat="server">Editar en fecha</asp:LinkButton>
                                                         
                                                           
                                                                &nbsp;&nbsp;&nbsp;&nbsp;  
                                                      <asp:LinkButton ID="lbtnGuardar" OnClick="lbtnGuardar_Click" CssClass="fa btn-sm btn btn-default" runat="server">Guardar nuevo</asp:LinkButton>
                                                            </div>
                                                        


                                                    </div>

                                                </div>
                                            </div>
                                        </div>

</asp:Content>
