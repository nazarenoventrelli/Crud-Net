
        $(document).ready(function () {

            $(".btn_modificar").click(function () {

                var modId = $(this).attr('value');
                peticionModificar(modId);
            });

            $(".btn_borrar").click(function () {

                var borrarId = $(this).attr('value');
                peticionBorrar(borrarId);

            });

            $("#btn_buscar").click(function () {
                var nombre = $("#buscar_nom").val();
                var apellido = $("#buscar_ap").val();

                peticionBuscar(nombre,apellido)
            });

            function peticionModificar(modId) {
                $.ajax({
                    type: 'GET',
                    url: '/Home/VerModificar',
                    data: { cod: modId },
                    success: function (result) {
                        $(".contenedorPrincipal").html(result);
                    }
                });
            }

            function peticionBorrar(borrarId) {
                $.ajax({
                    type: 'POST',
                    url: '/Home/Borrar',
                    data: { cod: borrarId },
                    success: function (result) {
                        $(".contenedorPrincipal").html(result);
                        generarMensaje("Registro borrado", "amarillo");
                        console.log("borrado");
                    }
                });
            }

            function peticionBuscar(nombre,apellido) {
                var data = { nombre: nombre, apellido: apellido };
                
                $.ajax({
                    type: 'GET',
                    url: '/Home/Buscar',
                    data: data,
                    success: function (result) {
                        $(".contenedorPrincipal").html(result);
                    }
                })
            }
          

        });

