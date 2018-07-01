$(document).ready(function () {

    $(function () {
        $("#datepicker").datepicker();
    });

    $("#txtMod_edad").keypress(function (e) {
        var keynum = window.event ? window.event.keyCode : e.which;

        if (!((keynum >= 48) && (keynum <= 57))) {
            generarMensaje("Ingrese una edad en numeros", "rojo");
        }

        return /\d/.test(String.fromCharCode(keynum));
    });
    document.onkeypress = function (e) {
        if (e.keyCode == 13) {
           
            enviarPeticion();
        }
          
            }; 
        $("#btn_modificar").click(function () {
           
            enviarPeticion();

    });

    function enviarPeticion() {
        var data = { cod: $("#txtMod_cod").val(), nombre: $("#txtMod_nombre").val(), apellido: $("#txtMod_apellido").val(), edad: $("#txtMod_edad").val(), fecha_alta: $("#datepicker").val() }

        $.ajax({
            type: 'POST',
            url: '/Home/Modificar',
            data: data,
            success: function (result) {
                $(".contenedorPrincipal").html(result);
                console.log(result);
                generarMensaje("Registro modificado", "verde");
            },
            error: function (result) {
                generarMensaje("Ingrese una fecha/edad valida", "rojo")
            }
        });
    }
    $("#btn_cancelar").click(function () {
        $.ajax({
            url: '/Home/VerListado',
            type: 'GET',
            success: function (result) {
                $(".contenedorPrincipal").html(result);
            }
           
        });
    });
              
    });