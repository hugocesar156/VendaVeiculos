$(document).ready(function () {
    TratarSituacao($('#situacao').val());
    CarregarSeletorFabricante($('#tipo').val());
})

function CarregarSeletorAnoModelo(tipo, fabricante, modelo) {

    $.getJSON(`https://parallelum.com.br/fipe/api/v1/${TratarTipo(tipo)}/marcas/${fabricante}/modelos/${modelo}/anos`, function (lista) {
        $(lista).each(function (index, ano) {
            if (!ano.codigo.includes('32000')) {
                if (ano.nome.split(' ')[0].includes($('#input-ano-modelo').val())) {
                    $('#input-id-ano-modelo').val(ano.codigo);
                }

                $('#ano-modelo').append(
                    `<option value="${ano.codigo}">${ano.nome.split(' ')[0]}</option>`
                );
            }
        })

        $('#ano-modelo').selectpicker('refresh');

        if ($('#input-id-ano-modelo').val() != null)
            $('#ano-modelo').selectpicker('val', $('#input-id-ano-modelo').val());

        ValidaSeletores();
    });
}

function CarregarSeletorFabricante(tipo) {
    $.getJSON(`https://parallelum.com.br/fipe/api/v1/${TratarTipo(tipo)}/marcas`, function (lista) {
        $(lista).each(function (index, fabricante) {
            if (fabricante.nome.toLowerCase().includes($('#input-fabricante').val().toLowerCase())) {
                $('#input-id-fabricante').val(fabricante.codigo);
            }

            $('#fabricante').append(
                `<option value="${fabricante.codigo}" class="text-capitalize">${fabricante.nome}</option>`
            );
        })

        $('#fabricante').selectpicker('refresh');
        $('#fabricante').selectpicker('val', $('#input-id-fabricante').val());

        CarregarSeletorModelo($('#tipo').val(), $('#input-id-fabricante').val());
    });
}

function CarregarSeletorModelo(tipo, fabricante) {
    $.getJSON(`https://parallelum.com.br/fipe/api/v1/${TratarTipo(tipo)}/marcas/${fabricante}/modelos`, function (lista) {
        $(lista.modelos).each(function (index, modelo) {
            if (modelo.nome.toLowerCase().includes($('#input-modelo').val().toLowerCase())) {
                $('#input-id-modelo').val(modelo.codigo);
            }

            $('#modelo').append(
                `<option value="${modelo.codigo}" class="text-capitalize">${modelo.nome}</option>`
            );
        })

        $('#modelo').selectpicker('refresh');
        $('#modelo').selectpicker('val', $('#input-id-modelo').val());

        CarregarSeletorAnoModelo($('#tipo').val(), $('#input-id-fabricante').val(), $('#input-id-modelo').val());
    });
}

function ValidaSeletores() {
    if ($('#input-fabricante').val() == '') {
        $('#fabricante').html('');
        $('#fabricante').selectpicker('refresh');

        $('#modelo').html('');
        $('#modelo').selectpicker('refresh');

        $('#ano-modelo').html('');
        $('#ano-modelo').selectpicker('refresh');

        $('#input-id-fabricante').val('');
        BuscarFabricantes($('#tipo').val());
    }

    if ($('#input-modelo').val() == '') {
        $('#modelo').html('');
        $('#modelo').selectpicker('refresh');

        $('#ano-modelo').html('');
        $('#ano-modelo').selectpicker('refresh');

        $('#input-id-modelo').val('');
        BuscarModelos($('#fabricante').val());
    }

    if ($('#input-ano-modelo').val() == '') {
        $('#ano-modelo').html('');
        $('#ano-modelo').selectpicker('refresh');

        $('#input-id-ano-modelo').val('');
        BuscarAnosModelo($('#modelo').val());
    }
}