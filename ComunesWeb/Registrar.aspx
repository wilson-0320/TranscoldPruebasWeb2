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

        <div class="input-group mb-3">
       <asp:TextBox ID="tbUsuario" CssClass="form-control" MaxLength="10" placeholder="Ingrese el usuario" runat="server" ValidateRequestMode="Enabled" ></asp:TextBox>
       
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-user"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
              <asp:TextBox ID="tbPassword"  CssClass="form-control" placeholder="Ingrese su clave" runat="server" TextMode="Password"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>

        <div class="input-group mb-3">
              <asp:TextBox ID="tbPassVerificar" CssClass="form-control" placeholder="repita la clave" runat="server" TextMode="Password"></asp:TextBox>
          
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
              <asp:Button ID="lbtnRegistrar" runat="server" Text="Ingresar" OnClick="lbtnRegistrar_Click" CssClass="btn btn-primary btn-block" />
           
          </div>
     
        </div>
      
     
    </div>

  </div>
</div>

    </div>

     <div class="card card-success card-outline">
              <div class="card-header">
                <h3 class="card-title">
                  <i class="fas fa-edit"></i>
                  SweetAlert2 Examples
                </h3>
              </div>
              <div class="card-body">
                <button type="button" class="btn btn-success swalDefaultSuccess">
                  Launch Success Toast
                </button>
                <button type="button" class="btn btn-info swalDefaultInfo">
                  Launch Info Toast
                </button>
                <button type="button" class="btn btn-danger swalDefaultError">
                  Launch Error Toast
                </button>
                <button type="button" class="btn btn-warning swalDefaultWarning">
                  Launch Warning Toast
                </button>
                <button type="button" class="btn btn-default swalDefaultQuestion">
                  Launch Question Toast
                </button>
                <div class="text-muted mt-3">
                  For more examples look at <a href="https://sweetalert2.github.io/">https://sweetalert2.github.io/</a>
                </div>
              </div>
              <!-- /.card -->
            </div>
    <script>
        $(function () {
            alert("AQ78");
            var Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 3000
            });

        });

            $('.swalDefaultSuccess').click(function () {
                alert("AQ78");
                Toast.fire({
                    icon: 'success',
                    title: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
        $('.swalDefaultInfo').click(function () {
            alert("AQ78");
                Toast.fire({
                    icon: 'info',
                    title: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
            $('.swalDefaultError').click(function () {
                Toast.fire({
                    icon: 'error',
                    title: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
            $('.swalDefaultWarning').click(function () {
                Toast.fire({
                    icon: 'warning',
                    title: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
            $('.swalDefaultQuestion').click(function () {
                Toast.fire({
                    icon: 'question',
                    title: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });

    </script>
</asp:Content>
