<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ComunesWeb/menu.Master" CodeBehind="RepGaleria.aspx.vb" Inherits="TranscoldPruebasWeb2.RepGaleria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main2" runat="server">
      <link rel="stylesheet" href="/Scripts/plugins/ekko-lightbox/ekko-lightbox.css">
    <div class="content-wrapper">
        <section class="content">

            <div class="container-fluid">
                <div class="card card-default">
                    <div class="card-header ">


                        <div class="card-tools">
                            <b class="text-info">Galeria</b>
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>

                        </div>

                    </div>
                    <div class="card-body">

                      <div class="row">
                  <div class="col-sm-2">
                    <a href="https://via.placeholder.com/1200/FFFFFF.png?text=1" data-toggle="lightbox" data-title="sample 1 - white" data-gallery="gallery">
                      <img src="https://via.placeholder.com/300/FFFFFF?text=1" class="img-fluid mb-2" alt="white sample"/>
                    </a>
                      </div>
                  </div>
                      
                  
                    </div>

                </div>
            </div>
        </section>
    </div>


    
<script src="/Scripts/plugins/ekko-lightbox/ekko-lightbox.min.js"></script>
    <script>
  $(function () {
    $(document).on('click', '[data-toggle="lightbox"]', function(event) {
      event.preventDefault();
      $(this).ekkoLightbox({
        alwaysShowClose: true
      });
    });

    $('.filter-container').filterizr({gutterPixels: 3});
    $('.btn[data-filter]').on('click', function() {
      $('.btn[data-filter]').removeClass('active');
      $(this).addClass('active');
    });
  })
    </script>


</asp:Content>
