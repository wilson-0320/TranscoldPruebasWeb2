<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/Site.Master" CodeBehind="Registrar.aspx.vb" Inherits="TranscoldPruebasWeb2.Registrar" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Main1" runat="server">
       
<div class="hold-transition login-page">

<div class="login-box">
  <div class="login-logo">
    <img style="width:75px;height:75px;border-radius:150px;" src="../Content/Estaticos/TIG.png" />
  </div>

  <div class="card">
    <div class="card-body login-card-body">
      <p class="login-box-msg">Laboratorio TIG.</p>
        <br />
        <p class="login-box-msg">Registro de usuarios</p>
        <label>Usuario:</label>
        <div class="input-group mb-3">
       <asp:TextBox ID="tbUsuario" CssClass="form-control" MaxLength="10" runat="server" ValidateRequestMode="Enabled" ></asp:TextBox>
       
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-user"></span>
            </div>
          </div>
        </div>
        <label>Clave de seguridad:</label>
        <div class="input-group mb-3">
              <asp:TextBox ID="tbPassword"  CssClass="form-control"  runat="server" TextMode="Password"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <label>Verificacion de clave:</label>
        <div class="input-group mb-3">
              <asp:TextBox ID="tbPassVerificar" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
          
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-8">
           
          </div>
        
          <div class="col-4">
              <asp:Button ID="btnRegistrar" runat="server" Text="Crear" OnClick="lbtnRegistrar_Click" CssClass="btn btn-primary btn-block" />
           
          </div>
     
        </div>
        <div><a href="Login.aspx">Login</a></div>
      
     
    </div>

  </div>
</div>

    </div>



</asp:Content>
