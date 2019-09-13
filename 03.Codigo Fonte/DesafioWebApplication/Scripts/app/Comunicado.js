
$(document).on('blur', "#TipoAssunto", function () {

    if (this.value == "Administrativo") {
        $('#administradoras').show();
        $('#responsaveis').hide();
    }

    if (this.value != "Administrativo") {
        $('#responsaveis').show();
        $('#administradoras').hide();
    }

});