<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="CompresoresComponentes.aspx.vb" Inherits="TranscoldPruebasWeb2.CompresoresComponentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
     <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Componentes de compresor</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>

                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="upCompresorComponentes" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:HiddenField ID="hfID" runat="server" />
                                <asp:HiddenField ID="hfQuery" runat="server" />

                            
                        <div class="row">
                            <div class="col-sm-2">
                                <small>Voltaje</small>
                                <asp:TextBox ID="tbVoltaje" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                             <div class="col-sm-3">
                                 <small>Cod. Comp.</small>
                                <asp:TextBox ID="tbCodigoComp" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                             <div class="col-sm-3">
                                 <small>Compresor</small>
                                <asp:TextBox ID="tbCompresor" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                             <div class="col-sm-2">
                                 <small>Caballaje</small>
                                <asp:TextBox ID="tbCaballaje" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                             <div class="col-sm-2">
                                 <small>relay</small>
                                <asp:TextBox ID="tbRelay" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                             
                        </div>
                        <div class="row">
                            <div class="col-sm-3">
                                <small>Protector Ter.</small>
                                <asp:TextBox ID="tbProtectorTermico" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                             <div class="col-sm-3">
                                 <small>Capacitor</small>
                                <asp:TextBox ID="tbCapacitor" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                            <div class="col-sm-2">
                                <br />
                                <asp:LinkButton ID="lbtnGuardar" runat="server" OnClick="lbtnGuardar_Click" CssClass="fa fa-2x fa-save"></asp:LinkButton>
                                <asp:LinkButton ID="lbtnCancelar" runat="server" OnClick="lbtnCancelar_Click" CssClass=" fa fa-2x fa-minus"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="table-responsive">
                            <table id="tt" class="table table-sm table-bordered">
                                <thead class="bg-gradient-navy">
                                    <tr>
                                    <th></th>
                                    <th>Voltaje</th>
                                    <th>Codigo compresor</th>
                                    <th>Compresor</th>
                                    <th>Caballaje</th>
                                    <th>Relay</th>
                                    <th>Protector termico</th>
                                    <th>Capacitor</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="repeaterComponentes"  OnItemCommand="repeaterComponentes_ItemCommand" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                     <td>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" CssClass="fa fa-edit" ></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton3" runat="server"  OnClientClick="return confirm('¿Realmente desea eliminar el registro?')" CommandArgument='<%# Eval("ID") %>' CommandName="Eli" CssClass="fa fa-trash" ></asp:LinkButton>
                                                     </td>
                                                <td><%# Eval("Voltaje") %></td>
                                                <td><%# Eval("Codigo_Compresor") %></td>
                                                <td><%# Eval("Compresor") %></td>
                                                <td><%# Eval("Caballaje") %></td>
                                                <td><%# Eval("Relay") %></td>
                                                <td><%# Eval("Protector_Term") %></td>
                                                <td><%# Eval("Capacitor") %></td>
                                        </tr>
                                        </ItemTemplate>
                                        
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                                </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lbtnCancelar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="repeaterComponentes" EventName="ItemCommand" />
                            </Triggers>
                        </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </section>
         </div>
</asp:Content>
