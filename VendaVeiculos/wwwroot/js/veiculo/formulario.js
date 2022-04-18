function BuscarAnosModelo(modelo) {
    $('#ano-modelo').html('');

    $('#codigo-fipe').val('');
    $('#valor-fipe').val('');

    let tipo = $('#tipo').val();
    let fabricante = $('#fabricante').val();

    $.getJSON(`https://parallelum.com.br/fipe/api/v1/${TratarTipo(tipo)}/marcas/${fabricante}/modelos/${modelo}/anos`, function (lista) {
        $('#ano-modelo').html('<option class="d-none" selected></option>');

        $(lista).each(function (index, ano) {
            $('#ano-modelo').append(
                `<option value="${ano.codigo}">${ano.nome.split(' ')[0]}</option>`
            );
        })
    });
}

function BuscarModelos(fabricante) {
    $('#modelo').html('');
    $('#ano-modelo').html('');

    $('#codigo-fipe').val('');
    $('#valor-fipe').val('');

    let tipo = $('#tipo').val();

    $.getJSON(`https://parallelum.com.br/fipe/api/v1/${TratarTipo(tipo)}/marcas/${fabricante}/modelos`, function (lista) {
        $('#modelo').html('<option class="d-none" selected></option>');

        $(lista.modelos).each(function (index, modelo) {
            $('#modelo').append(
                `<option value="${modelo.codigo}">${modelo.nome}</option>`
            );
        })
    });
}

function BuscarFabricantes(tipo) {
    $('#fabricante').html('');
    $('#modelo').html('');
    $('#ano-modelo').html('');

    $('#codigo-fipe').val('');
    $('#valor-fipe').val('');

    $.getJSON(`https://parallelum.com.br/fipe/api/v1/${TratarTipo(tipo)}/marcas`, function (lista) {
        $('#fabricante').html('<option class="d-none" selected></option>');

        $(lista).each(function (index, fabricante) {
            $('#fabricante').append(
                `<option value="${fabricante.codigo}">${fabricante.nome}</option>`
            );
        })
    });
}

function BuscarValor(anoModelo) {
    let tipo = $('#tipo').val();
    let fabricante = $('#fabricante').val();
    let modelo = $('#modelo').val();

    $.getJSON(`https://parallelum.com.br/fipe/api/v1/${TratarTipo(tipo)}/marcas/${fabricante}/modelos/${modelo}/anos/${anoModelo}`, function (veiculo) {
        $('#codigo-fipe').val(veiculo.CodigoFipe);
        $('#valor-fipe').val(veiculo.Valor);
    });
}

function TratarTipo(tipo) {
    switch (tipo) {
        case '1':
            return 'carros';
        case '2':
            return 'motos';
    }
}