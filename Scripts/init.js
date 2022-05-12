

$(function () {

    console.log("Cargando Scripts");
    //select2 themes
    $(".js-example-theme-single").select2({
        theme: "classic"
    });

    $('#summernotehtml').trumbowyg({ resetCss: true, imageWidthModalEdit: true, defaultLinkTarget: '_blank' });
    $(".js-example-theme-multiple").select2({
        theme: "classic"
    });
    // multi select box
    $('.multi-select').select2();

    try {
        $('#tt').DataTable({
        });
        console.log("Cargado datatable");
    } catch (error) {
        console.log(error);
        // expected output: ReferenceError: nonExistentFunction is not defined
        // Note - error messages will vary depending on browser
    }

   

});

function abrirReportes(all)
{

   
   var Compu = $(".NombreCompu").val();

    var PathRep = all;

    var jqxhr = $.get("https://www.fogelonline.com/TranscoldPruebasWeb/Publico/Servicios/TransWebService.asmx/AbreReporte", { Compu: Compu, PathReporte: PathRep })
            .done(function () {
                alert("Colocado " + PathRep);
            })
            .fail(function () {
                alert("Error");
            })
   


}

function metodo(mensaje,tipo) {
    console.log("Cargando Scripts-en metodo");
    var tipos = parseInt(tipo);
    $(".js-example-theme-single").select2({
        theme: "classic"
    });

    $('.multi-select').select2();

    $(".js-example-theme-multiple").select2({
        theme: "classic"
    });

    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });
    $('#tt').DataTable({
    });

    console.log("Mensaje:" + mensaje);

    $('#summernotehtml').trumbowyg({ resetCss: true, imageWidthModalEdit: true, defaultLinkTarget: '_blank' });
    switch (tipos) {
        case 1:
            Toast.fire({
                icon: 'success',
                title: mensaje
            })
            break;
        case 2:
            Toast.fire({
                icon: 'info',
                title: mensaje
            })
            break;
        case 3:
            Toast.fire({
                icon: 'warning',
                title: mensaje
            })
            break;
        case 4:
            Toast.fire({
                icon: 'error',
                title: mensaje
            })
            break;
        case 5:
            Toast.fire({
                icon: 'question',
                title: mensaje
            })
            break;

            
    }
        
    


}


