






function OnSuccessCadastrarTipoDeRisco(data) {
    $('#formCadastroTipoDeRisco').removeAttr('style');
    $(".LoadingLayout").hide();
    $('#btnSalvar').show();
    TratarResultadoJSON(data.resultado);
}

function OnBeginCadastrarTipoDeRisco() {
    $(".LoadingLayout").show();
    $('#btnSalvar').hide();
    $("#formCadastroTipoDeRisco").css({ opacity: "0.5" });
}