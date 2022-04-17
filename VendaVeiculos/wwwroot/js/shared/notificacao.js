$(document).ready(function () {
    let tipo = $('#tipo-notificacao').val();
    let titulo = $('#titulo-notificacao');
    let notificacao = $('#div-notificacao');

    switch (tipo) {
        case 'Sucesso':
            titulo.html('Sucesso.');
            notificacao.addClass('alert-success');
            break;

        case 'Falha':
            titulo.html('Falha.');
            notificacao.addClass('alert-danger');
            break;

        case 'Aviso':
            titulo.html('Aviso.');
            notificacao.addClass('alert-alert');
            break;

        case 'Informação':
            titulo.html('Informação.');
            notificacao.addClass('alert-info');
            break;
    }

    setTimeout(function () {
        $('#fechar-notificacao').click();
    }, 5000);
})