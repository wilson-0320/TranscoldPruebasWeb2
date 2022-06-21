<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/Menu.Master" CodeBehind="tabPanel.aspx.vb" Inherits="TranscoldPruebasWeb2.tabPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">

    <div class="content-wrapper">
        <section class="content">

            <div class="row">
                <div class="col-sm-6">
                    <tr>
                        <td>
                            <div class="container-fluid">
                                <div class="card card-default">
                                    <div class="card-header ">


                                        <div class="card-tools">
                                            <b class="text-info">Datos principales</b>
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>

                                        </div>

                                    </div>
                                    <div class="card-body">
                                        <asp:Label ID="lblInfo" CssClass="text-sm" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>

                            <div class="container-fluid">
                                <div class="card card-default">
                                    <div class="card-header ">


                                        <div class="card-tools">
                                            <b class="text-info">Validaciones realizadas</b>
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>

                                        </div>

                                    </div>
                                    <div class="card-body">




                                        <div class="table-responsive text-sm">
                                            <table class="table tt table-sm table-bordered ">
                                                 <thead class="bg-gradient-navy">
                                            <tr><th>Solicitud</th>
                                                <th>Ubicación</th><th>Magnitud</th><th>Equipo Patron</th>
                                                <th>Medición 1</th><th>Medición 2</th><th>Medición 3</th><th>Medición 4</th>
                                                <th>Comentario</th><th>Tecnico</th><th>Realizado</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                                <asp:Repeater ID="RepeaterValidaciones" runat="server">
                                                    <ItemTemplate>
                                                        <tr >
                                                        
                                                        <td><%# Eval("Codigo") %> </td>
                                                        <td><%# Eval("valor") %></td>
                                                        <td><%# Eval("magnitud") %></td>
                                                        <td><%# Eval("descripcion") %></td>
                                                        <td><%# Eval("Dato1") %></td>
                                                        <td><%# Eval("Dato2") %></td>
                                                        <td><%# Eval("Dato3") %></td>
                                                        <td><%# Eval("Dato4") %></td>
                                                        <td><%# Eval("Comentario") %></td>
                                                        <td><%# Eval("Usuario") %></td>
                                                        <td><%# Eval("FechaRealiza") %></td>

                                                    </tr>






                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                            </table>
                                        </div>

                                    </div>

                                </div>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="container-fluid">
                                <div class="card card-default">
                                    <div class="card-header ">


                                        <div class="card-tools">
                                            <b class="text-info">Listado de pruebas</b>
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>

                                        </div>

                                    </div>
                                    <div class="card-body">

                                       <div class="table-responsive text-sm">
                                                <table class="table table-sm table-bordered table-hover table-avatar">
                                                    <thead class="bg-gradient-navy">
                                                        <tr>
                                                           
                                                            <th>Solicitud</th>
                                                            <th>Prueba</th>
                                                            <th>Fecha</th>
                                                            <th>Tipo prueba</th>
                                                            <th>Notas</th>
                                                            <th>Decision</th>

                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Repeater ID="repeaterPruebas" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                   
                                                                    <td><%# Eval("CodSolicitud") %></td>
                                                                    <td><%# Eval("Prueba") %></td>
                                                                    <td><%# Eval("Fecha") %></td>
                                                                    <td><%# Eval("TipoPrueba") %></td>
                                                                    <td><%# Eval("Notas") %></td>
                                                                    <td><%# if(Eval("Aprobada") = "1", "Aprobado", "Fallida") %></td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>

                                                    </tbody>
                                                </table>
                                            </div>


                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="container-fluid">
                                <div class="card card-default">
                                    <div class="card-header ">


                                        <div class="card-tools">
                                            <b class="text-info">Datos de ingreso</b>
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>

                                        </div>

                                    </div>


                                    <div class="card-body table-responsive">
                                        <div class="table-responsive">
                                        <div class="row">
                                            
                                        <asp:Repeater ID="RepeaterRecepcion" runat="server">

                                            <ItemTemplate>

                                                <th>
                                                    
                                                        <div class="col-lg-6">


                                                            <table class="">


                                                                <tr>
                                                                    <td>
                                                                        <small class="text-capitalize form-inline text-bold text-lightblue  ">Fecha de operacion: </small>
                                                                    </td>
                                                                  
                                                                    <td>
                                                                        <small class="text-dark text-center"><%# Eval("FechaCreacion") %></small>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Cliente:  </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Cliente") %></small>    </td>
                                                                </tr>
                                                                  <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Tipo:  </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Tipo_Operacion") %></small>    </td>
                                                                </tr>
                                                                   <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Codigo:  </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Codigo") %></small>    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Pais origen:  </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("PaisOrigen") %></small>    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Solitado por:  </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Solicitado") %></small>    </td>
                                                                </tr>

                                                                
                                                               
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">W.O. </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Work_Order") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Serie </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Numero_Serie") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Modelo </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Modelo") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Parillas </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Parillas") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Clips </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Clip") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Lamparas </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Lamparas") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Observaciones </small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Observaciones") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Rayones</small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Rayones") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Golpes</small></td>
                                                                    <td><small class="text-dark text-center"><%# Eval("Golpes") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Rotulo</small></td>
                                                                    <td><small class="text-dark text-center"><%# if(Eval("Rotulo") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Cubremotor</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Cubremotor") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Certificado</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Certificado") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Etiqueta de serie</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Etiq_Serie") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Calcomanias</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Calcomanias") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Manual de operacion</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Man_Oper") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Manual de Instalacion</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Man_Ins") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Diagrama</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Diagrama") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Funcionamiento</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Funcionamiento") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Parilla Trasera</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Parilla_Trasera") = 0, "No", "Si") %></small></td>
                                                                </tr>

                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Parilla Trasera</small></td>
                                                                    <td><small class="text-dark text-center"><%#If(Eval("Haladores") = 0, "No", "Si") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Operador de laboratorio</small></td>
                                                                    <td><small class="text-dark text-center"><%#Eval("Usuario_Laboratorio") %></small></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><small class="text-capitalize form-inline text-bold text-lightblue  ">Operador de Despachos</small></td>
                                                                    <td><small class="text-dark text-center"><%#Eval("Usuario_Entrega") %></small></td>
                                                                </tr>

                                                            </table>





                                                        </div>
                                                    
                                                </th>


                                            </ItemTemplate>
                                        </asp:Repeater>
                                                </div>

                                        </div>


                                    </div>
                                </div>
                            </div>
                        </td>
                
                    </tr>
                </div>
                <div class="col-sm-6">
                   
                    <tr>
                        <td>
                            <div class="container-fluid">
                                <div class="card card-default">
                                    <div class="card-header ">


                                        <div class="card-tools">
                                            <b class="text-info">Configuracion de carga</b>
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>

                                        </div>

                                    </div>
                                    <div class="card-body">

                                        <asp:Repeater ID="repeaterCargaEquipo" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><small>Realizado: <%# Eval("Fecha_Enviado") %>, Realizó: <%# Eval("Usuario_Prueba") %>  </small></td>
                                                </tr>
                                                <br />
                                                <tr>
                                                    <td><small>Aprobado: <%# Eval("Fecha_Revisado") %>, Aprobó: <%# Eval("Usuario_Revision") %>  </small></td>
                                                </tr>
                                                <br />

                                                <tr>
                                                    <td>
                                                        <%# Eval("Valor") %>
                                                        <br />
                                                        <small>
                                                            <%# Eval("Descripcion") %> 
                                                        </small>
                                                        <br />
                                                        <div class="text-center">
                                                            <img src='https://www.fogelonline.com/<%# Eval("Archivo") %>' width="325" />
                                                        </div>

                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>

                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="container-fluid">
                                <div class="card card-default">
                                    <div class="card-header ">


                                        <div class="card-tools">
                                            <b class="text-info">Historial de cambios</b>
                                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>

                                        </div>

                                    </div>
                                    <div class="card-body">
                                        <asp:Repeater ID="repeaterContadoCambios" runat="server">
                                            <ItemTemplate>


                                                <tr runat="server" visible='<%# Not Eval("contar") Is DBNull.Value AndAlso Eval("contar") = "0" %>'>
                                                    <td>

                                                        <h4 class=""><%# Eval("descripcion") %></h4>
                                                    </td>
                                                </tr>


                                                <tr runat="server" visible='<%# Not Eval("contar") Is DBNull.Value AndAlso Eval("contar") <> "0" %>'>
                                                    <td>

                                                        <div class="progress">

                                                            <div class="progress-bar progress-bar-striped bg-success" role="progressbar" <%#"Style=' Width:" + (Double.Parse(Eval("contar")) * 4).ToString + "%;'" %> aria-valuenow="<%# Eval("contar").ToString %>"
                                                                aria-valuemin="0" aria-valuemax="10">
                                                                <%# Eval("descripcion") %> -  <%# Eval("contar") %>
                                                            </div>

                                                        </div>
                                                    </td>
                                                </tr>
                                                <br />
                                            </ItemTemplate>
                                        </asp:Repeater>


                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </div>


            </div>
            <asp:HiddenField ID="hfDivision" runat="server" />
            <asp:HiddenField ID="hfConsecutivo" runat="server" />
            <asp:HiddenField ID="hfCodigo" runat="server" />



        </section>
    </div>
</asp:Content>
