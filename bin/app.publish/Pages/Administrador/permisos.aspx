<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="permisos.aspx.vb" Inherits="TranscoldPruebasWeb2.permisos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
    <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Permisos</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>
                    </div>
                    <div class="card-body">


                        <div class="row">
                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlUsuario" CssClass="js-example-theme-single form-control  " AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <asp:UpdatePanel ID="upDescripcionPermisos" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:HiddenField ID="hfID" runat="server" />
                                <asp:HiddenField ID="hfquery" runat="server" />
                                <asp:HiddenField ID="hfIDUsuario" runat="server" />
                                <div>
                                    <div class="row">
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlApartados" runat="server" CssClass="js-example-theme-single  form-control" AutoPostBack="false">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-2">
                                            <sm>Escritura</sm>
                                            <asp:CheckBox ID="cbEscritura" runat="server" />
                                        </div>
                                        <div class="col-sm-2">
                                            <sm>Actualizacion</sm>
                                            <asp:CheckBox ID="cbEditar" runat="server" />
                                        </div>
                                        <div class="col-sm-2">
                                            <sm>Eliminar</sm>
                                            <asp:CheckBox ID="cbEliminar" runat="server" />
                                        </div>
                                        
                                        <div class="col-sm-2">
                                            <asp:LinkButton ID="lbtnGuardarPermisos" OnClick="lbtnGuardarPermisos_Click" CssClass="fa fa-2x fa-save" runat="server"></asp:LinkButton>
                                            <asp:LinkButton ID="lbntCancelar" OnClick="lbntCancelar_Click" CssClass="fa fa-2x fa-minus" runat="server"></asp:LinkButton>

                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="table-responsive">
                                    <table class="table-bordered table  table-sm ">
                                        <thead class="bg-gradient-navy">
                                            <th>---
                                            </th>
                                            <th>Rol
                                            </th>
                                            <th>Escritura
                                            </th>
                                            <th>Modificación
                                            </th>
                                            <th>Eliminar
                                            </th>
                                            <th>Estado
                                            </th>

                                        </thead>
                                        <asp:Repeater ID="repeaterPermisos" runat="server" OnItemCommand="repeaterPermisos_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>




                                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="fa fa-edit" CommandName="Edit" CommandArgument='<%# Eval("ID") %>'> </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="fa fa-trash" OnClientClick="return confirm('¿Realmente desea eliminar el registro?')" CommandName="Eli" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>

                                                        </div>
                                                
                                                
                                                    </td>


                                                    <td><%# Eval("Apartado") %></td>
                                                    <td><%# if(Eval("Agregar") = "0", "Inactivo", "Activo") %></td>
                                                    <td><%# if(Eval("Modificar") = "0", "Inactivo", "Activo") %></td>
                                                    <td><%# if(Eval("Eliminar") = "0", "Inactivo", "Activo") %></td>
                                                    <td><%# if(Eval("Estado") = "0", "Inactivo", "Activo") %></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlUsuario" EventName="SelectedIndexChanged" />

                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardarPermisos" EventName="Click" />

                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

        </section>
    </div>
</asp:Content>
