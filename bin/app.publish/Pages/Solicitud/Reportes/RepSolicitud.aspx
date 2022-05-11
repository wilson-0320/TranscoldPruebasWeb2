<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="RepSolicitud.aspx.vb" Inherits="TranscoldPruebasWeb2.RepSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
       <style>
        tr.group,
tr.group:hover {
    background-color: #A6ACAF !important;
}
    </style>
    <script>
        $(function () {

            console.log("Cargando Scripts");
            

            $('#example tbody').on('click', 'tr.group', function () {
                var currentOrder = table.order()[0];
                if (currentOrder[0] === groupColumn && currentOrder[1] === 'asc') {
                    table.order([groupColumn, 'desc']).draw();
                }
                else {
                    table.order([groupColumn, 'asc']).draw();
                }
            });
        });

        function agruparTabla()
        {
            try {
                var groupColumn = 0;
                var table = $('#tt').DataTable({
                    "columnDefs": [
                        { "visible": false, "targets": groupColumn }
                    ],
                    "order": [[groupColumn, 'asc']],
                    "displayLength": 100,
                    "drawCallback": function (settings) {
                        var api = this.api();
                        var rows = api.rows({ page: 'current' }).nodes();
                        var last = null;

                        api.column(groupColumn, { page: 'current' }).data().each(function (group, i) {
                            if (last !== group) {
                                $(rows).eq(i).before(
                                    '<tr class="group"><td colspan="6">' + group + '</td></tr>'
                                );

                                last = group;
                            }
                        });
                    }


                });
            } catch (ex) {

            }
        }

            
    </script>
     <div class="content-wrapper">
        <section class="content">

                
            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Tab Panel</b>
                            <button type="button" class="btn btn-tool"  data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>

                    </div>
                    
                    
                    <div class="card-body text-sm text">
                        <div class="row">
                        <div class="col-sm-2">
                            <small>Codigo</small>
                            <asp:TextBox ID="tbCodigo" OnTextChanged="tbCodigo_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                            <div class="col-sm-2">
                            <br />
                                <asp:Button ID="btnFiltrar" OnClick="btnFiltrar_Click" CssClass="btn btn-default" runat="server" Text="Reporte" />
                        </div>
                    </div>
                        <hr />
                        <asp:UpdatePanel ID="upReporte" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                            
                        <table id="tt" class="table table-bordered table-sm table-hover ">
                            <thead class="bg-gradient-navy">
                                <tr><th>Descripcion</th>
                                    <th>Valor</th>
                                    <th>Cantidad</th>
                                    <th>Precio</th>
                                    <th>Comentario</th>
                                    <th>Estado</th>
                                    <th>Fecha</th>
                                </tr>
                               <tbody>

                               
                        <asp:Repeater ID="repeaterPruebas" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td> <%# Eval("Descripcion") %> </td>
                                    <td> <%# Eval("Valor") %> </td>
                                    <td> <%# Eval("Cantidad") %> </td>
                                    <td> <%# Eval("Precio") %> </td>
                                    <td> <%# Eval("Comentario") %> </td>
                                    <td> <%# Eval("Estado") %> </td>
                                    <td> <%# Eval("Fecha_Enviado") %> </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                                   </tbody>
                            </thead>
                        </table>
                                </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="tbCodigo" EventName="TextChanged" />
                                <asp:AsyncPostBackTrigger ControlID="btnFiltrar" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </section>
            </div>
</asp:Content>
