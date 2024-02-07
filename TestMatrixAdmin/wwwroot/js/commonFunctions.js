
// Esta funci�n habilita o deshabilita el bot�n "Siguiente" en el asistente de formularios.
function enableNextButton(enable) {
    var form = $("#example-form");
    var nextButton = form.find("a[href='#next']");
    var originalHref = nextButton.attr('href');

    if (enable) {
        nextButton.removeClass("disabled");
        nextButton.attr('href', originalHref); // Restablecer el href para habilitar el enlace
        nextButton.css('cursor', ''); // Restablecer el cursor si fue cambiado
    } else {
        nextButton.addClass("disabled");
        nextButton.removeAttr('href'); // Quitar el href para deshabilitar el enlace
        nextButton.css('cursor', 'not-allowed'); // Cambiar el cursor a 'no permitido'
    }
}

function initializeCommonFeatures() {
    // Configuraciones de validaci�n, eventos y mas
}

// Ejecuta la inicializaci�n de caracter�sticas comunes cuando el documento est� listo.
$(document).ready(function () {
    initializeCommonFeatures();
});
