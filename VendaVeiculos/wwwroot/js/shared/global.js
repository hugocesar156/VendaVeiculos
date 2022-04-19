$(document).ready(function () {
    $('.cep').mask('00000-000');
    $('.cnpj').mask('00.000.000/0000-00');
    $('.cpf').mask('000.000.000-00');
    $('.num-4').mask('0000');
    $('.num-6').mask('000000');
    $('.real').mask('0.000.000,00', { reverse: true });
    $('.renavam').mask('0000000000-0');
    $('.telefone').mask('00 000000000');

    $('.selectpicker').selectpicker({
        noneResultsText: 'Nenhum registro encontrado'
    });
})

function BuscarEndereco(cep) {
    cep = cep.replace('-', '');

    if (cep.length === 8) {
        $.getJSON(`https://viacep.com.br/ws/${cep}/json/?callback=?`, function (endereco) {
            if (!('erro' in endereco)) {
                $('#logradouro').val(endereco.logradouro);
                $('#bairro').val(endereco.bairro);
                $('#cidade').val(endereco.localidade);
                $('#uf').selectpicker('val', endereco.uf);
                $('#numero').val('');
            }
        });
    }
}