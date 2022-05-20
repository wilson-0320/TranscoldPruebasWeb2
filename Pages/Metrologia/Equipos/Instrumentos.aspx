<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="Instrumentos.aspx.vb" Inherits="TranscoldPruebasWeb2.Instrumentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">

      <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Instrumentos</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>

                    </div>
                    <asp:UpdatePanel ID="upCatalogo" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                   
                        
                                <asp:HiddenField ID="hfID" runat="server" />
                                  <asp:HiddenField ID="hfIDCategoria" runat="server" />
                                <div class="table-responsive">
                                    <table id="tt" class="table table-sm table-bordered">
                                        <thead class="bg-gradient-navy">
                                            <tr>
                                            <th></th>
                                            <th>Num</th>
                                            <th>Descripcion</th>
                                            <th>Vigente</th>
                                                </tr>
                                        </thead>
                                        <tbody>

                                            <asp:Repeater ID="repeaterCatalogo" runat="server" OnItemCommand="repeaterCatalogo_ItemCommand">
                                                <ItemTemplate>
                                                   
                                                </ItemTemplate>
                                            </asp:Repeater>



                                        </tbody>
                                    </table>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lbtnGuardar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="ddlCategoria" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="repeaterCatalogo" EventName="ItemCommand" />
                            </Triggers>
                        </asp:UpdatePanel>


                    
                </div>
            </div>
        </section>
    </div>
</asp:Content>
