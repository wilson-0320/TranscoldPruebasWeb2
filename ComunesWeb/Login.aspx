<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/Site.Master" CodeBehind="Login.aspx.vb" Inherits="TranscoldPruebasWeb2.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main1" runat="server">
      <!-- /.login-logo -->
   
<div class="hold-transition login-page">
<div class="login-box">
  <div class="login-logo">
    <img style="width:75px;height:75px;border-radius:150px;" src="../Content/Estaticos/TIG.png" />
  </div>
  <!-- /.login-logo -->
  <div class="card">
    <div class="card-body login-card-body">
      <p class="login-box-msg">Laboratorio TIG.</p>


        <div class="input-group mb-3">
       <asp:TextBox ID="tbUsuario" CssClass="form-control" runat="server"></asp:TextBox>
       
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-user"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
              <asp:TextBox ID="tbPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
          
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-8">
           
          </div>
          <!-- /.col -->
          <div class="col-4">
              <asp:Button ID="Button1" runat="server" Text="Ingresar" CssClass="btn btn-primary btn-block" />
           
          </div>
          <!-- /.col -->
        </div>
      
     
    </div>
    <!-- /.login-card-body -->
  </div>
</div>
<!-- /.login-box -->
    </div>

  

</asp:Content>
