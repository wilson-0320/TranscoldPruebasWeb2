

(function ($) {
  //  toastr.success("mensjae");
})


function cargar(mensaje, tipo)
{

    var a=parseInt(tipo)

    switch (tipo) {
        case 1:
            toastr.success(mensaje);
        case 2:
            toastr.info(mensaje);
        case 3:
            toastr.error(mensaje);
        case 4:
            toastr.warning(mensaje);
        default:

            break;


    }

}
