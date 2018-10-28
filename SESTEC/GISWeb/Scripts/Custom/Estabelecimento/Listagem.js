﻿jQuery(function ($) {

    AplicajQdataTable("dynamic-table", [{ "bSortable": false }, null, null, null,null,null, { "bSortable": false }], false, 20);

});

function BuscarDetalhesEstabelecimentoImagens(IDEstabelecimentoImagens) {

    $(".LoadingLayout").show();

    $.ajax({
        method: "POST",
        url: "/EstabelecimentoImagens/BuscarDetalhesEstabelecimentoImagens",
        data: { idEstabelecimento: IDEstabelecimentoImagens },
        error: function (erro) {
            $(".LoadingLayout").hide();
            ExibirMensagemGritter('Oops! Erro inesperado', erro.responseText, 'gritter-error')
        },
        success: function (content) {
            $(".LoadingLayout").hide();

            if (content.data != null) {
                bootbox.dialog({
                    message: content.data,
                    title: "<span class='bigger-110'>Detalhes do Estabelecimento</span>",
                    backdrop: true,
                    locale: "br",
                    buttons: {},
                    onEscape: true
                });
            }
            else {
                TratarResultadoJSON(content.resultado);
            }

        }
    });

}

function BuscarDetalhesDosRiscos(IDEstabelecimentoImagens) {

    $(".LoadingLayout").show();

    $.ajax({
        method: "POST",
        url: "/AtividadesDoEstabelecimento/BuscarDetalhesDosRiscos",
        data: { idEstabelecimento: IDEstabelecimentoImagens },
        error: function (erro) {
            $(".LoadingLayout").hide();
            ExibirMensagemGritter('Oops! Erro inesperado', erro.responseText, 'gritter-error')
        },
        success: function (content) {
            $(".LoadingLayout").hide();

            if (content.data != null) {
                bootbox.dialog({
                    message: content.data,
                    title: "<span class='bigger-110'>Detalhes do Ambiente</span>",
                    backdrop: true,
                    locale: "br",
                    buttons: {},
                    onEscape: true
                });
            }
            else {
                TratarResultadoJSON(content.resultado);
            }

        }
    });

}

function BuscarDetalhesDeMedidasDeControle(IDEstabelecimentoImagens) {

    $(".LoadingLayout").show();

    $.ajax({
        method: "POST",
        url: "/MedidasDeControle/BuscarDetalhesDeMedidasDeControle",
        data: { idEstabelecimento: IDEstabelecimentoImagens },
        error: function (erro) {
            $(".LoadingLayout").hide();
            ExibirMensagemGritter('Oops! Erro inesperado', erro.responseText, 'gritter-error')
        },
        success: function (content) {
            $(".LoadingLayout").hide();

            if (content.data != null) {
                bootbox.dialog({
                    message: content.data,
                    title: "<span class='bigger-110'>Detalhes do Ambiente</span>",
                    backdrop: true,
                    locale: "br",
                    buttons: {},
                    onEscape: true
                });
            }
            else {
                TratarResultadoJSON(content.resultado);
            }

        }
    });

}




function BuscarDetalhesEmpresa(IDEmpresa) {
    
    $(".LoadingLayout").show();

    $.ajax({
        method: "POST",
        url: "/Estabelecimento/BuscarEstabelecimentoPorID",
        data: { idEstabelecimento: IDEstabelecimento },
        error: function (erro) {
            $(".LoadingLayout").hide();
            ExibirMensagemGritter('Oops! Erro inesperado', erro.responseText, 'gritter-error')
        },
        success: function (content) {
            $(".LoadingLayout").hide();
            
            if (content.data != null) {
                bootbox.dialog({
                    message: content.data,
                    title: "<span class='bigger-110'>Detalhes da Empresa</span>",
                    backdrop: true,
                    locale: "br",
                    buttons: {},
                    onEscape: true
                });
            }
            else {
                TratarResultadoJSON(content.resultado);
            }

        }
    });

}

function DeletarEmpresa(IDEmpresa, Nome) {
    
    var callback = function () {
        $('.LoadingLayout').show();
        $('#dynamic-table').css({ opacity: "0.5" });

        $.ajax({
            method: "POST",
            url: "/Empresa/Terminar",
            data: { IDEmpresa: IDEmpresa },
            error: function (erro) {
                $(".LoadingLayout").hide();
                $("#dynamic-table").css({ opacity: '' });
                ExibirMensagemGritter('Oops! Erro inesperado', erro.responseText, 'gritter-error')
            },
            success: function (content) {
                $('.LoadingLayout').hide();
                $("#dynamic-table").css({ opacity: '' });

                TratarResultadoJSON(content.resultado);

                if (content.resultado.Sucesso != null && content.resultado.Sucesso != "") {
                    $("#linha-" + IDEmpresa).remove();
                }
            }
        });
    };

    ExibirMensagemDeConfirmacaoSimples("Tem certeza que deseja excluir a empresa '" + Nome + "'?", "Exclusão de Empresa", callback, "btn-danger");

}