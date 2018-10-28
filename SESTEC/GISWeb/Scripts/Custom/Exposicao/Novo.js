jQuery(function ($) {
    

    if ($("#ContinuoID").click(function () {

        if ($(this).is(':checked')) {
        $("#IntermitenteID").prop("disabled", true);
        $('#EventualID').prop("disabled", true);
        }
                    
        else{
        $("#IntermitenteID").prop("disabled", false);
        $('#EventualID').prop("disabled", false);

        }
    }));
    if ($("#IntermitenteID").click(function () {

        if ($(this).is(':checked')) {
            $("#ContinuoID").prop("disabled", true);
            $('#EventualID').prop("disabled", true);

        } else {
            $("#ContinuoID").prop("disabled", false);
            $('#EventualID').prop("disabled", false);

        }
    }));

    if ($("#EventualID").click(function () {

        if ($(this).is(':checked')) {
            $("#ContinuoID").prop("disabled", true);
            $('#IntermitenteID').prop("disabled", true);

        } else {
            $("#ContinuoID").prop("disabled", false);
            $('#IntermitenteID').prop("disabled", false);

        }

    }));
    
});
//function Novo(IDAtividadesDoEstabelecimento) {

//    $(".LoadingLayout").show();

//    $.ajax({
//        method: "POST",
//        url: "/Exposicao/Novo",
//        data: { IDAtividadesDoEstabelecimento: IDAtividadesDoEstabelecimento },
//        error: function (erro) {
//            $(".LoadingLayout").hide();
//            ExibirMensagemGritter('Oops! Erro inesperado', erro.responseText, 'gritter-error')
//        },
//        success: function (content) {
//            $(".LoadingLayout").hide();

//            if (content.data != null) {
//                bootbox.dialog({
//                    message: content.data,
//                    title: "<span class='bigger-110'>Cadastrar Exposição</span>",
//                    backdrop: true,
//                    locale: "br",
//                    buttons: {},
//                    onEscape: true
//                });
//            }
//            else {
//                TratarResultadoJSON(content.resultado);
//            }

//        }
//    });

//}

  

function OnSuccessCadastrarExposicao(data) {
    $('#formCadastroExposicao').removeAttr('style');
    $(".LoadingLayout").hide();
    $('#btnSalvar').show();
    TratarResultadoJSON(data.resultado);
    ExibirMsgGritter(data.resultado);
}

function OnBeginCadastrarExposicao() {
    $(".LoadingLayout").show();
    $('#blnSalvar').hide();
    $("#formCadastroExposicao").css({ opacity: "0.5" });
}