using App.Domain.Exceptions;
using App.Domain.Models;
using Gridify;
using System.Globalization;
using System.Text;
using System.Web;

namespace App.Utility
{
    public static class Conversoes
    {
        public static string StringParaUrl(string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        public static string UrlParaString(string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        public static string ByteArrayParaString(byte[] arr)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                builder.Append(arr[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public static string DataBrasileira(DateTime? data, string defaultNullReturn = "")
        {
            if (data == null)
                return "";

            return data.Value.ToString("dd/MM/yyyy HH:mm:ss");
        }

        public static string MesPorExtensoAnoNumerico(DateTime? data)
        {
            if (data is null)
                return "";

            return new CultureInfo("pt-BR").TextInfo.ToTitleCase(data.Value.ToString("MMM/yy", new CultureInfo("pt-BR")));
        }

        public static string Dinheiro(decimal? dinheiro, string defaultNullReturn = "", bool inverterValor = false)
        {
            if (dinheiro == null)
                return defaultNullReturn;

            if (inverterValor)
                dinheiro *= -1;

            var nfi = new CultureInfo("pt-BR").NumberFormat;
            return dinheiro.Value.ToString("C", nfi);
        }

        public static string Porcentagem(decimal? porcentagem, string defaultNullReturn = "", bool inverterValor = false)
        {
            if (porcentagem == null)
                return defaultNullReturn;

            if (inverterValor)
                porcentagem *= -1;

            var nfi = new CultureInfo("pt-BR").NumberFormat;
            return porcentagem.Value.ToString("C", nfi).Replace("R$ ", "") + "%";
        }

        public static string PorcentagemInt(int? porcentagem, string defaultNullReturn = "", bool inverterValor = false)
        {
            if (porcentagem == null)
                return defaultNullReturn;

            if (inverterValor)
                porcentagem *= -1;

            var nfi = new CultureInfo("pt-BR").NumberFormat;
            nfi.NumberDecimalDigits = 0;
            nfi.PercentDecimalDigits = 0;
            nfi.CurrencyDecimalDigits = 0;
            return porcentagem.Value.ToString("C", nfi).Replace("R$ ", "") + "%";
        }

        public static string PorcentagemSnippet(decimal? porcentagem, string defaultNullReturn = "")
        {
            if (porcentagem == null)
                return defaultNullReturn;

            var nfi = new CultureInfo("pt-BR").NumberFormat;
            return porcentagem.Value.ToString("C", nfi).Replace("R$ ", "") + "%";
        }

        public static string FormatarCNPJ(string CNPJ)
        {
            return Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string FormatarCPF(string CPF)
        {
            return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }

        public static string FormatarCPFCNPJ(string entrada)
        {
            if (string.IsNullOrWhiteSpace(entrada))
                return "";

            entrada = entrada.Trim();

            if (entrada.Length > 11)
                return FormatarCNPJ(entrada);
            else
                return FormatarCPF(entrada);
        }

        public static string FormatarData(DateTime? data, string defaultNullReturn = "")
        {
            if (data == null)
                return "";

            return data.Value.ToString("dd/MM/yyyy");
        }

        public static string TextoSeparado(string[] arr, string separador)
        {
            if (arr == null || arr.Length == 0)
                return "";

            var arr2 = arr.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            return string.Join(separador, arr2);
        }

        public static string SomenteNumeros(string texto)
        {
            return string.Join("", System.Text.RegularExpressions.Regex.Split(texto, @"[^\d]"));
        }

        public static string FormatarValor(this decimal valor)
        {
            decimal numero = 0;
            string novoValor = "";
            try
            {
                var culture = new CultureInfo("pt-BR");
                var nfi = NumberFormatInfo.GetInstance(culture);
                nfi.CurrencyPositivePattern = 2;
                culture.NumberFormat = nfi;

                numero = Convert.ToDecimal(valor, nfi);
                novoValor = numero.ToString("C", culture);

            }
            catch
            {
                novoValor = "0";
            }

            return novoValor;
        }

        public static string FormatarValor(this decimal? valor)
        {
            decimal numero = 0;
            string novoValor = "";
            try
            {
                var culture = new CultureInfo("pt-BR");
                var nfi = NumberFormatInfo.GetInstance(culture);
                nfi.CurrencyPositivePattern = 2;
                culture.NumberFormat = nfi;

                numero = Convert.ToDecimal(valor, nfi);
                novoValor = numero.ToString("C", culture);

            }
            catch
            {
                novoValor = "0";
            }

            return novoValor;
        }

        public static string FormatarPorcentagem(this decimal? porcentagem, string defaultNullReturn = "")
        {
            if (porcentagem == null)
                return defaultNullReturn;

            var nfi = new CultureInfo("pt-BR").NumberFormat;
            return porcentagem.Value.ToString("C", nfi).Replace("R$ ", "") + "%";
        }

        public static decimal MascaraDinheiroParaDecimal(string valor)
        {
            var valorNovo = valor.Replace(" ", "").Replace("R$", "").Replace(".", "").Replace(",", ".").Trim();

            return Convert.ToDecimal(valorNovo, new CultureInfo("en-US"));
        }

        public static decimal MascaraPorcentagemParaDecimal(string valor)
        {
            var valorNovo = valor.Replace(" ", "").Replace("%", "").Replace(".", "").Replace(",", ".").Trim();

            return Convert.ToDecimal(valorNovo, new CultureInfo("en-US"));
        }

        public static string MascaraNumero(long? entrada, string defaultNullReturn = "")
        {
            if (entrada is null)
                return defaultNullReturn;

            var numero = entrada.ToString();
            int tamanho = numero.Length;
            int partes = (int)Math.Ceiling((double)tamanho / 3);

            char[] chars = new char[tamanho + partes - 1];
            int charIndex = chars.Length - 1;
            int digitCount = 0;

            for (int i = tamanho - 1; i >= 0; i--)
            {
                chars[charIndex--] = numero[i];
                digitCount++;

                if (digitCount == 3 && charIndex >= 0)
                {
                    chars[charIndex--] = '.';
                    digitCount = 0;
                }
            }

            return new string(chars);
        }

        public static string FormatarNumero6Dígitos(int numero)
        {
            string numeroFormatado = numero.ToString("000\\.000");
            return numeroFormatado;
        }

        public static string FormatarNumeroMilhares(long numero)
        {
            return numero.ToString("N0", new CultureInfo("pt-BR"));
        }


        public static decimal PorcentagemEquivalenciaValores(decimal valorCheio, decimal valorParcial)
        {
            if (valorCheio == 0)
            {
                throw new ValidationException("O valor cheio não pode ser zero.");
            }

            decimal porcentagem = (valorParcial / valorCheio) * 100;
            return porcentagem;
        }

        public static string PorcentagemRetornoZero(decimal? porcentagem, bool inverterValor = false)
        {
            if (porcentagem == null)
                return "0,00%";

            if (inverterValor)
                porcentagem *= -1;

            var nfi = new CultureInfo("pt-BR").NumberFormat;
            return porcentagem.Value.ToString("C", nfi).Replace("R$ ", "") + "%";
        }

        public static string DinheiroRetornoZero(decimal? dinheiro, bool inverterValor = false)
        {
            if (dinheiro == null)
                return "R$ 0,00";

            if (inverterValor)
                dinheiro *= -1;

            var nfi = new CultureInfo("pt-BR").NumberFormat;
            return dinheiro.Value.ToString("C", nfi);
        }

        public static string DinheiroSemPrefix(decimal? dinheiro, string defaultNullReturn = "-", bool isConsiderarZeroNull = false)
        {
            if (dinheiro == null || (isConsiderarZeroNull && dinheiro == 0))
                return defaultNullReturn;

            NumberFormatInfo formatInfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = ",",
                NumberGroupSeparator = ".",
                NumberDecimalDigits = 2
            };

            return dinheiro.Value.ToString("N", formatInfo);
        }

        public static GridifyQuery DatatableModelParaGridifyQuery(DataTableAjax datatableModel)
        {
            return new GridifyQuery
            {
                Page = (datatableModel.start / datatableModel.length) + 1,
                PageSize = datatableModel.length
            };
        }
    }
}
