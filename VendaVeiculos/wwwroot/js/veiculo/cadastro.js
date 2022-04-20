$(document).ready(function () {
    TratarSituacao($('#situacao').val());

    let tipo = $('#tipo').val();
    let fabricante = $('#input-id-fabricante').val();
    let modelo = $('#input-id-modelo').val();

    if (tipo != null && tipo != '')
        AtualizaSeletorFabricante(tipo);

    if (fabricante != null && fabricante != '')
        AtualizaSeletorModelo(tipo, fabricante);

    if (modelo != null && modelo != '')
        AtualizaSeletorAnoModelo(tipo, fabricante, modelo);
})

function AtualizaSeletorAnoModelo(tipo, fabricante, modelo) {
    $.getJSON(`https://parallelum.com.br/fipe/api/v1/${TratarTipo(tipo)}/marcas/${fabricante}/modelos/${modelo}/anos`, function (lista) {
        $(lista).each(function (index, ano) {
            if (!ano.codigo.includes('32000')) {
                $('#ano-modelo').append(
                    `<option value="${ano.codigo}">${ano.nome.split(' ')[0]}</option>`
                );
            }
        })

        $('#ano-modelo').selectpicker('refresh');

        if ($('#input-id-ano-modelo').val() != null) {
            $('#ano-modelo').selectpicker('val', $('#input-id-ano-modelo').val());
            BuscarValor($('#ano-modelo').val());
        }
    });
}

function AtualizaSeletorFabricante(tipo) {
    $.getJSON(`https://parallelum.com.br/fipe/api/v1/${TratarTipo(tipo)}/marcas`, function (lista) {
        $(lista).each(function (index, fabricante) {
            $('#fabricante').append(
                `<option value="${fabricante.codigo}" class="text-capitalize">${fabricante.nome}</option>`
            );
        })

        $('#fabricante').selectpicker('refresh');

        if ($('#input-id-fabricante').val() != null) {
            $('#fabricante').selectpicker('val', $('#input-id-fabricante').val());
        }
    });
}

function AtualizaSeletorModelo(tipo, fabricante) {
    $.getJSON(`https://parallelum.com.br/fipe/api/v1/${TratarTipo(tipo)}/marcas/${fabricante}/modelos`, function (lista) {
        $(lista.modelos).each(function (index, modelo) {
            $('#modelo').append(
                `<option value="${modelo.codigo}" class="text-capitalize">${modelo.nome}</option>`
            );
        })

        $('#modelo').selectpicker('refresh');

        if ($('#input-id-modelo').val() != null) {
            $('#modelo').selectpicker('val', $('#input-id-modelo').val());
        }
    });
}

function BuscarAnosModelo(modelo) {
    $('#input-modelo').val($('#modelo option:selected').html());

    $('#ano-modelo').html('');
    $('#input-ano-modelo').val('');

    $('#codigo-fipe').val('');
    $('#valor-fipe').val('');

    let tipo = $('#tipo').val();
    let fabricante = $('#fabricante').val();

    AtualizaSeletorAnoModelo(tipo, fabricante, modelo);
}

function BuscarModelos(fabricante) {
    $('#input-fabricante').val($('#fabricante option:selected').html());

    $('#modelo').html('');
    $('#input-modelo').val('');

    $('#ano-modelo').html('');
    $('#input-ano-modelo').val('');
    $('#ano-modelo').selectpicker('refresh');

    $('#codigo-fipe').val('');
    $('#valor-fipe').val('');

    let tipo = $('#tipo').val();

    AtualizaSeletorModelo(tipo, fabricante);
}

function BuscarFabricantes(tipo) {
    $('#fabricante').html('');
    $('#input-fabricante').val('');

    $('#modelo').html('');
    $('#input-modelo').val('');
    $('#modelo').selectpicker('refresh');

    $('#ano-modelo').html('');
    $('#input-ano-modelo').val('');
    $('#ano-modelo').selectpicker('refresh');

    $('#codigo-fipe').val('');
    $('#valor-fipe').val('');

    AtualizaSeletorFabricante(tipo);
}

function BuscarValor(anoModelo) {
    $('#input-id-ano-modelo').val(anoModelo);
    $('#input-ano-modelo').val($('#ano-modelo option:selected').html());

    let tipo = $('#tipo').val();
    let fabricante = $('#fabricante').val();
    let modelo = $('#modelo').val();

    $.getJSON(`https://parallelum.com.br/fipe/api/v1/${TratarTipo(tipo)}/marcas/${fabricante}/modelos/${modelo}/anos/${anoModelo}`, function (veiculo) {
        $('#codigo-fipe').val(veiculo.CodigoFipe);
        $('#valor-fipe').val(veiculo.Valor.replace('R$ ', ''));
    });
}

function TratarSituacao(situacao) {
    if (situacao == '1') {
        $('#placa').val('');
        $('#placa').attr('readonly', true);
        $('#placa').attr('title', 'Campo para veículos semi-novos e usados');
        $('#placa ~ span').html('');

        $('#odometro').val('');
        $('#odometro').attr('readonly', true);
        $('#odometro').attr('title', 'Campo para veículos semi-novos e usados');
        $('#odometro ~ span').html('');
    }
    else {
        $('#placa').removeAttr('readonly');
        $('#placa').attr('title', 'Placa do veículo');

        $('#odometro').removeAttr('readonly');
        $('#odometro').attr('title', 'Quilometragem do veículo');
    }
}

function TratarTipo(tipo) {
    switch (tipo) {
        case '1':
            return 'carros';
        case '2':
            return 'motos';
    }
}