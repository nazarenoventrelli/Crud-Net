function generarMensaje(texto, color) {
    //elimina cualquier clase previa
    contenedorAlerta.classList.remove("alert-info", "alert-danger", "alert-success", "alert-warning");

    //setea el texto de mensaje
    $("#msjeAlerta").text(texto);

    //añade al contenedor la correspondiente clase
    switch (color) {
        case "rojo":
            contenedorAlerta.classList.add("alert-danger");
            break;

        case "azul":
            contenedorAlerta.classList.add("alert-info");
            break;

        case "verde":
            contenedorAlerta.classList.add("alert-success");
            break;
        case "amarillo":
            contenedorAlerta.classList.add("alert-warning");
            break;

    }


    mostrarAlerta();
}

function mostrarAlerta() {

    //para las animaciones setea la opacidad en 1
    $(".alert").stop().css({ opacity: 1, display: 'block' });

    //muestra el alerta y resetea sus atributos para poder volverla a mostrar
    $(".alert").stop().fadeTo(1000, 1).slideUp(1000).removeAttr('style');

}