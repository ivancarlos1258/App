const utility = {
    dataParaString(data) {
        const dia = data.getDate().toString().padStart(2, '0')
        const mes = (data.getMonth() + 1).toString().padStart(2, '0')
        const ano = data.getFullYear()
        return `${dia}/${mes}/${ano}`
    },

    dataParaStringAbreviada(data) {
        const meses = ["Jan", "Feb", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"]
        const mes = meses[data.getMonth()]
        const ano = data.getFullYear().toString().slice(-2)
        return `${mes}./${ano}`
    },

    decimalParaDinheiro(valor) {
        let valorString = valor.toFixed(2).toString().replaceAll('.', ',')
        let stringFormatada = this.local.formatarStringDeNumero(valorString)
        return `R$ ${stringFormatada}`
    },

    decimalParaPorcentagem(valor) {
        let valorString = valor.toFixed(2).toString().replaceAll('.', ',')
        let stringFormatada = this.local.formatarStringDeNumero(valorString)
        return `${stringFormatada}%`
    },

    decimalParaString(valor) {
        var stringNumero = valor.toFixed(2).toString().replace('.', ',')

        return this.local.formatarStringDeNumero(stringNumero)
    },

    documentoParaString(valor) {
        return valor.replaceAll(',', '').replaceAll('.', '').replaceAll('-', '').replaceAll('/', '')
    },

    obterDataAtualCompleta() {
        const hoje = new Date()

        const stringData  = `${hoje.toLocaleDateString()} ${hoje.toLocaleTimeString('en-US', {hour12: false, hour: 'numeric', minute: 'numeric'})}`

        return stringData.replaceAll('/', '-').replace(':', '-')
    },

    removerMascaraNumero(valor) {
        let valorSemMascara = valor.replaceAll('R$', '').replaceAll('%', '').replaceAll(/[a-zA-Z]/g, '')
            .replaceAll('.', '').replaceAll(' ', '').replaceAll(',', '.')

        return Number(valorSemMascara).toFixed(2)
    },

    removerMascaraNumeroInteiro(valor) {
        let valorSemMascara = valor.replaceAll('R$', '').replaceAll('%', '').replaceAll(/[a-zA-Z]/g, '')
            .replaceAll('.', '').replaceAll(' ', '').replaceAll(',', '.')

        return Number(valorSemMascara).toFixed(0)
    },

    local: {
        formatarStringDeNumero(string) {
            let substrings = string.replaceAll('R$', '').replaceAll('%', '').replaceAll(' ', '').split(',')
            let substringPraFormatar = substrings[0]
            let decimais = substrings[1]

            let substringPraFormatarInvertida = this.inverterString(substringPraFormatar)
            let charsStringFormatada = []
            for (let i = 0; i < substringPraFormatarInvertida.length; i++) {
                let char = substringPraFormatarInvertida[i]
                charsStringFormatada.push(char)
                if ((i + 1) % 3 == 0 && (i + 1) < substringPraFormatar.length) charsStringFormatada.push('.')
            }
            charsStringFormatada.reverse()

            let stringFormatada = charsStringFormatada.join('')

            return stringFormatada + ',' + decimais
        },

        inverterString(string) {
            let arrChars = string.split('')
            arrChars.reverse()
            let stringInvertida = arrChars.join('')
            return stringInvertida
        }
    }
}