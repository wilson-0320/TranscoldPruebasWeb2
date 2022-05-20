<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="MetProveedor.aspx.vb" Inherits="TranscoldPruebasWeb2.MetProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
      <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Proveedores de servicio de calibración.</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>

                    </div>
                    <asp:UpdatePanel ID="upPanel" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                    <div class="card-body">
                      
                                
                                <div class="table-responsive">
                                    <asp:Repeater ID="repeaterMetProveedores" DataSourceID="ODSBLL_Met_Proveedores" runat="server">

                                    </asp:Repeater>
                                    
                                    <asp:ObjectDataSource ID="ODSBLL_Met_Proveedores" runat="server" SelectMethod="consultar" TypeName="TranscoldPruebasWeb2.BLL.Met_Proveedores_BLL"></asp:ObjectDataSource>
                                </div>
                           </div>
                            </ContentTemplate>
                            <Triggers>
                              
                            </Triggers>
                        </asp:UpdatePanel>


                    
                </div>
            </div>
        </section>
    </div>


            <div class="modal fade" id="modalCheck" name="modal" data-backdrop="static">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title"></h4>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <asp:HiddenField ID="hfID" runat="server" />
                                         <asp:HiddenField ID="hfQuery" runat="server" />

                                        <asp:UpdatePanel ID="upCheck" runat="server" UpdateMode="Conditional">
                                         <ContentTemplate>

                                         <small>Nombre</small>
                                        <asp:TextBox ID="tbNombre" runat="server" CssClass="form-control" MaxLength="200"></asp:TextBox>
                                        <small>Direccion</small>
                                        <asp:TextBox ID="tbDireccion" runat="server" CssClass="form-control" MaxLength="200"></asp:TextBox>
                                        <small>Pais</small>
                                        <asp:TextBox ID="tbPais" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                                        <small>Contacto</small>
                                        <asp:TextBox ID="tbContacto" runat="server" CssClass="form-control" MaxLength="200"></asp:TextBox>
                                        <small>Correo</small>
                                        <asp:TextBox ID="tbCorrreo" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                        <small>tbTelefono</small>
                                        <asp:TextBox ID="tbTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                                        <div class="row">
                                            <div class="col-sm-4">
                                                <small>Calibración</small>
                                                <asp:CheckBox ID="cbCalibracion" runat="server" CssClass="form-check" />
                                            </div>
                                            <div class="col-sm-4">
                                                <small>Suministro</small>
                                                <asp:CheckBox ID="cbSuministros" runat="server" CssClass="form-check" />
                                            </div>
                                        </div>
                                        
                                                <div class="modal-footer ">
                                                    <div class="justify-content-md-end">
                                                        <asp:Button ID="btnGuardar" CssClass="btn btn-success " OnClick="btnGuardar_Click"  runat="server" Text="Guardar" />     &nbps;&nbps;&nbps; 
                                                          <asp:Button ID="Button1" CssClass="btn btn-warning " OnClick="btnGuardar_Click"  runat="server" Text="Cancelar" />
                                                    </div>

                                                </div>

                                            </ContentTemplate>

                                            <Triggers>
                                             
                                            </Triggers>

                                        </asp:UpdatePanel>
                                    </div>

                                </div>
                            </div>
                        </div>


</asp:Content>
