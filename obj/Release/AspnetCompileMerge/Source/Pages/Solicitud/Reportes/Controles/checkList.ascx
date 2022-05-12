<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="checkList.ascx.vb" Inherits="TranscoldPruebasWeb2.checkList1" %>

<script>



</script>

                                      <div class="modal fade" id="modal" name="modal">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">QR</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
                <asp:Repeater ID="repeaterCheck" runat="server">
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
                <asp:LinkButton ID="lbtnGuardar" OnClick="lbtnGuardar_Click"  runat="server">LinkButton</asp:LinkButton>
            </div>
          </div>
        </div>
      </div>
       
