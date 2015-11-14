function eliminarCasa(id, enVenta) {
    enVenta = !enVenta;

    if (confirm("¿Esta seguro que desea cambiar el estatus En Venta de la Casa con ID : " + id + " ?")) {

        PageMethods.CambiarEstadoEnVentaCasa(id, enVenta,
        function (result) {
            //Funcion que genera resultado cuando todo salio correctamente
            if (result) {
                //Obtenemos el tr de la tabla (contiene el anchor)
                var tr = obtenerNodo(id);
                //Obtenemos el amchor
                var a = tr.find("a[data-icon='delete']");
                //Obtenemos el span que contiene el texto
                var span = a.find("span:eq(1)");

                var texto = span.text();
                var link = "";

                if (texto == "Habilitar") {
                    texto = "Deshabilitar";
                } else if (texto == "Deshabilitar") {
                    texto = "Habilitar";
                }
                link = "javascript:eliminarCasa(" + id + "," + enVenta + ")"

                a.attr("href", link);
                span.text(texto);
            } else {
                mensajeError();
            }
        },
        function (result) { //funcion en caso de error
            mensajeError();
        });
    }
}

function mensajeError() {
    alert("A ocurrido un error al querer cambiar el estatus de la casa, porfavor contacte el administrador");
}

function obtenerNodo(number){
    var nodo="";
    $("#gridCasas tr td:contains('"+number+"')").each(function(){
        if ($(this).text()==number)
            nodo=$(this).parent();
    });
    return nodo;
}