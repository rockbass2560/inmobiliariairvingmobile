var divs = new Array();
var fieldDireccion, fieldDatos, fieldMedidas, fieldPlus;
var botonAtras, botonSiguiente;
var action;
var hiddenField;

function mostrarCarga() {
    $("#divCarga").show();
    $("#divCatalogo").hide();
}

function esconderCarga() {
    $("#divCarga").hide();
    $("#divCatalogo").show();
}

$(document).ready(function () {
    /*window.onbeforeunload = function () {
        $.ajax("Catalogo.aspx?eS=t");
        //return false;
    };*/

    //Obtener divs
    divs["fieldDireccion"] = $("#fieldDireccion");
    divs["fieldDatos"] = $("#fieldDatos");
    divs["fieldMedidas"] = $("#fieldMedidas");
    divs["fieldPlus"] = $("#fieldPlus");

    botonAtras = $("#botonAtras");
    botonSiguiente = $("#botonSiguiente");

    hiddenField = $("#hiddenField");

    action = $("#hiddenAction").val();

    changePage(hiddenField.val());
});

function changePage(div) {
    changeDiv(div);
    hiddenField.val(div);
    switch (div) {
        case "fieldDireccion":
            botonAtras.attr("disabled", "disabled");
            botonSiguiente.click(function () {
                changePage('fieldDatos');
            });
            break;
        case "fieldDatos":
            botonAtras.removeAttr("disabled");
            botonAtras.click(function () {
                changePage('fieldDireccion');
            });
            botonSiguiente.click(function () {
                changePage('fieldMedidas');
            });
            break;
        case "fieldMedidas":
            botonAtras.click(function () {
                changePage("fieldDatos");
            });
            botonSiguiente.click(function () {
                changePage("fieldPlus");
            });

            botonSiguiente.parent().show();

            $("#divBotones").hide();
            break;
        case "fieldPlus":
            botonAtras.click(function () {
                changePage("fieldMedidas");
            });
            botonSiguiente.parent().hide();
            $("#divBotones").show();
            break;
        default:
            break;
    }
}

function changeDiv(div) {
    for (var item in divs) {
        item = $("#"+item);
        if (item.attr("id") == div)
            item.css("display", "block");
        else
            item.css("display", "none");
    }
}

function chargeImage(url, nombreArchivo) {
    var imagen = new Image();
    imagen = $(imagen);
    imagen.attr("id", "fotografiaCasa");
    imagen.attr("src", url).load(function () {
        var fotografia = $("#fotografiaCasa");
        var parentFotografia = fotografia.parent();

        fotografia.remove();
        parentFotografia.append(imagen);

        $.ajax("remover.aspx?file=" + nombreArchivo);
    });
}

//function ShowImage() {
//    var srcFotografia = $("#hdnFotografia").val();
//    $("#uploadFotografia").attr("src", srcFotografia);
//}