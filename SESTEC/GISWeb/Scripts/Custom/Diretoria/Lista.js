jQuery(function ($) {

    AplicajQdataTable("dynamic-table", [{ "bSortable": false },null,null, { "bSortable": false }], false, 20);

});


function DeletarDiretoria(IDDiretoria, Nome) {

    var callback = function () {
        $('.LoadingLayout').show();
        $('#dynamic-table').css({ opacity: "0.5" });

        $.ajax({
            method: "POST",
            url: "/Diretoria/TerminarComRedirect",
            data: { IDDiretoria: IDDiretoria },
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
                    $("#linha-" + IDAdmissao).remove();
                }
            }
        });
    };



    ExibirMensagemDeConfirmacaoSimples("Tem certeza que deseja excluir esta Diretoria?", "Exclusão de Diretoria", callback, "btn-danger");

   
}
