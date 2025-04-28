$(document).ready(() => aplicarMascarasValores())

function aplicarMascarasValores() {
    // MONEY
    $('.money').maskMoney({
        prefix: 'R$ ',
        formatOnBlur: false,
        doubleClickSelection: true,
        decimal: ',',
        thousands: '.',
        precision: 2,
        allowNegative: true
    })

    $('.moneyZero').maskMoney({
        prefix: 'R$ ',
        formatOnBlur: false,
        doubleClickSelection: true,
        decimal: ',',
        thousands: '.',
        precision: 2,
        allowNegative: true,
        allowZero: true
    })

    $('.moneyPositive').maskMoney({
        prefix: 'R$ ',
        formatOnBlur: false,
        doubleClickSelection: true,
        decimal: ',',
        thousands: '.',
        precision: 2,
        allowNegative: false
    })

    $('.moneyPositiveZero').maskMoney({
        prefix: 'R$ ',
        formatOnBlur: false,
        doubleClickSelection: true,
        decimal: ',',
        thousands: '.',
        precision: 2,
        allowNegative: false,
        allowZero: true
    })

    // NUMERO
    $('.numeroInt1Char').mask("0")

    $('.numeroInt2Char').mask("00")

    $('.numeroInt3Char').mask("000")

    $('.numeroInt6Char').mask('000.000', { reverse: true })

    $('.numeroInt9Char').mask('000.000.000', { reverse: true })

    // PERCENT
    $('.percent').maskMoney({
        suffix: '%',
        formatOnBlur: false,
        doubleClickSelection: true,
        decimal: ',',
        thousands: '.',
        precision: 2,
        allowNegative: true
    })

    $('.percentZero').maskMoney({
        suffix: '%',
        formatOnBlur: false,
        doubleClickSelection: true,
        decimal: ',',
        thousands: '.',
        precision: 2,
        allowNegative: true,
        allowZero: true
    })

    $('.percentPositive').maskMoney({
        suffix: '%',
        formatOnBlur: false,
        doubleClickSelection: true,
        decimal: ',',
        thousands: '.',
        precision: 2,
        allowNegative: false
    })

    $('.percentPositiveZero').maskMoney({
        suffix: '%',
        formatOnBlur: false,
        doubleClickSelection: true,
        decimal: ',',
        thousands: '.',
        precision: 2,
        allowNegative: false,
        allowZero: true
    })

    $('.percentNegativeZero').maskMoney({
        suffix: '%',
        prefix: '-',
        formatOnBlur: false,
        doubleClickSelection: true,
        decimal: ',',
        thousands: '.',
        precision: 2,
        allowNegative: false,
        allowZero: true
    })

    $('.percentInt').maskMoney({
        suffix: '%',
        formatOnBlur: false,
        doubleClickSelection: true,
        decimal: ',',
        thousands: '.',
        precision: 0,
        allowNegative: true
    })

    $('.percentIntZero').maskMoney({
        suffix: '%',
        formatOnBlur: false,
        doubleClickSelection: true,
        decimal: ',',
        thousands: '.',
        precision: 0,
        allowNegative: true,
        allowZero: true
    })

    $('.percentIntPositive').maskMoney({
        suffix: '%',
        formatOnBlur: false,
        doubleClickSelection: true,
        decimal: ',',
        thousands: '.',
        precision: 0,
        allowNegative: false,
    })

    $('.percentIntPositiveZero').maskMoney({
        suffix: '%',
        formatOnBlur: false,
        doubleClickSelection: true,
        decimal: ',',
        thousands: '.',
        precision: 0,
        allowNegative: false,
        allowZero: true
    })

    // UTILIDADES
    $(".cep").mask("99999-999")
    $(".cnpj").mask("00.000.000/0000-00")
    $(".cpf").mask("000.000.000-00")
    $(".cpfcnpj").length ? $(".cpfcnpj").mask("00.000.000/0000-00", optionsCpfCnpj) > 11 : $(".cpfcnpj").mask("000.000.000-00#", optionsCpfCnpj)
    $('.telefone').mask(maskBehavior, optionsTelefone);
    $('.decimal').maskMoney({
        formatOnBlur: false,
        doubleClickSelection: true,
        decimal: ',',
        thousands: '.',
        precision: 2,
        allowNegative: false,
        allowZero: true
    })
    $('.coordenada').mask('Y99Z.99999999', {
        translation: {
            'Y': {
                pattern: /-/,
                optional: true
            },
            'Z': {
                pattern: /[0-9]/,
                optional: true
            }
        }
    });

    configurarSelect2()
}

var optionsCpfCnpj = {
    onKeyPress: function (n, p, e, a) {
        var s = ["000.000.000-000", "00.000.000/0000-00"]
        $(".cpfcnpj").mask(14 < n.length ? s[1] : s[0], a)
    }
}
var maskBehavior = function (val) {
    return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009'
}

optionsTelefone = {
    onKeyPress: function (val, e, field, optionsTelefone) {
        field.mask(maskBehavior.apply({}, arguments), optionsTelefone);
    }
}