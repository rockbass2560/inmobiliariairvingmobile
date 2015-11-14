var maskString = "$ 9?99999999";
$(document).ready(function() {
    $("#divFiltro :text").each(function() {
        $(this).slider();
        //$(this).blur(changeText);
        //$(this).mask(maskString);
    });
});

function changeText(text) {
    $(text).change(changeText);
}