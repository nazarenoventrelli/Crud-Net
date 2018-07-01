
$(document).ready(function () {
    $("#txtEdad").keypress(function (e){
        var keynum = window.event ? window.event.keyCode : e.which;

        if(!((keynum >= 48) && (keynum <= 57))) {
            generarMensaje("Ingrese una edad en numeros", "rojo");
        }

    return /\d/.test(String.fromCharCode(keynum));
    });

    $("#btn_enviarFormulario").click(function () {

        enviarPeticion();

    });
    document.onkeypress = function (e) {
        if (e.keyCode == 13) {

            enviarPeticion();
        }
    }
    function enviarPeticion(){
        var data = { nombre: $("#txtNombre").val(), apellido: $("#txtAp").val(), edad: $("#txtEdad").val() }

        $.ajax({
            type: 'POST',
            url: '/Home/Alta',
            data: data,
            success: function (result) {
                $(".contenedorPrincipal").html(result);
                generarMensaje("Registro agregado", "verde");
            },
            error: function (result) {
                generarMensaje("Ingrese una edad valida", "rojo")
            }
        })
    }

    });