<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="check.ascx.vb" Inherits="TranscoldPruebasWeb2.check" %>

<script>
    function abrir(id) {
   
            try {
                $('#modal2').modal('show');
            } catch (e) {
                alert(e + "");
            }

        return false;

      // abrirModal
        var elementblock = document.getElementById(id);
        var elementnone = id + 1;
        console.log(element2);



        document.getElementById(elementnone).style.display = "none";

        document.getElementById(elementblock).style.display = "block";



        console.log("Finaliza portal");
        
    }
</script>


<div class="modal fade" id="modal2" name="modal">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">CheckList</h4>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <div id="0">
                    <div class="row">

                 
                    <div class="col-sm-8">

                            <small>Ensayos</small>
                            <asp:DropDownList ID="ddlEnsayos" AutoPostBack="true" OnSelectedIndexChanged="ddlEnsayos_SelectedIndexChanged" CssClass="js-example-theme-single form-control" runat="server"></asp:DropDownList>

                        </div>
                            <div class="col-sm-4">
                                <small>Tipo</small>
                                <asp:DropDownList ID="ddlTipo" runat="server" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" AutoPostBack="true" CssClass="js-example-theme-single form-control" >
                                    <asp:ListItem>Inicio</asp:ListItem>
                                    <asp:ListItem>Transcurso</asp:ListItem>
                                    <asp:ListItem>Fin</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                           </div>
                </div>
                <hr />
                <asp:Repeater ID="repeaterCheck" runat="server" OnItemCommand="repeaterCheck_ItemCommand">
                    <ItemTemplate>
                        <div id="<%# Eval("Num") %>">
                            <small><%# Eval("Requisito") %></small>
                            <asp:DropDownList ID="ddlOpciones" OnLoad="ddlOpciones_Load" runat="server"></asp:DropDownList>
                            <asp:TextBox ID="tbOpciones" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="modal-footer justify-content-between">
                <asp:LinkButton ID="lbtnGuardar" OnClick="lbtnGuardar_Click" CssClass="fa fa-2x  fa-arrow-alt-circle-right" CommandName="Guardar" runat="server"></asp:LinkButton>
            </div>

        </div>
    </div>
</div>


