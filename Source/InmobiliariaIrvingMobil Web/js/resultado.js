var divMobil;
var divFull;
var tableFull;
var tableMobil;
var lastSize = "";
var resolucion = 960;

function getSize() {
    var size;
    if ($(window).width() > resolucion)
        size = "full";
    else
        size = "mobil";

    return size;
}

function changeWindow() {
    if (getSize() != lastSize) {
        initialWindows();
    }
};

function initialWindows() {
    switch (getSize()) {
        case "full":
            $("#divMobil").hide();
            $("#divFull").show();
            lastSize = getSize();
            break;
        case "mobil":
            $("#divMobil").show();
            $("#divFull").hide();
            lastSize = getSize();
            break;
    }
}



$(document).ready(function() {
    $("#divFull").hide();
    $("#divMobil").hide();
    tableFull = $("#tableFull");
    tableMobil = $("#tableMobil");

    $(window).resize(function() {
        if (this.resizeTO)
            clearTimeout(this.resizeTO);
        this.resizeTO = setTimeout(function() {
            $(this).trigger('resizeEnd');
        }, 1);
    });

    $(window).bind('resizeEnd', changeWindow);

    var prop = { "bFilter": false, "bLengthChange": false };

    //tableFull.dataTable(prop);
    //tableMobil.dataTable(prop);

    initialWindows();
});

function formatString(value) {
    var valueFinal;
    if (value.length > 60) {
        valueFinal = value.substring(0, 60) + " ...";
    } else {
        valueFinal = value + " ...";
    }

    return valueFinal;
}

function createTable() {
    //Creamos copia DOM
    tableMobil = tableFull.clone(true);
    tableMobil.attr("id", "tableMobil");
        
    var tablas = tableMobil.find("table");

    tablas.each(function() {
        //tabla padre
        var tableParent = $(this);
        //Buscmaos el nodo td
        var nodo = tableParent.find("td:first()");
        var nodoID = tableParent.find(".trID");
        nodo.attr("rowspan", 0);
        //Se formatea la seccion de comentarios
        var comments = tableParent.find("#comentarios");
        comments.text(formatString(comments.text()));
        //Lo removemos ambos nodos
        nodo.remove();
        nodoID.remove();

        //Creamos un tr para la tabla
        var tr = document.createElement("tr");
        tr = $(tr);
        //Se agrega el antiguo valor del nodo
        $(tr).prepend(nodoID);
        $(tr).prepend(nodo);

        //Por ultimo se agrega el valor de la tabla padre
        tableParent.prepend(tr);
    });

    $("#divMobil").prepend(tableMobil);

    $("#divMobil").hide();
}