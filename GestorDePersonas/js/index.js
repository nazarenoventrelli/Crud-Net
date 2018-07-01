$(document).ready(function () {

        $("#btn_agregar").click(function () {
            $.ajax({
                url: '/Home/Alta',
                type: 'GET',
                success: function (result) {
                    $(".contenedorPrincipal").html(result);
                }

            });
        });

        $("#btn_ver").click(function () {

            $.ajax({
                url: '/Home/VerListado',
                type: 'GET',
                success: function (result) {
                    $(".contenedorPrincipal").html(result);
                }
            });
        });

    });