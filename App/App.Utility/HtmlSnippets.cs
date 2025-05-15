using App.Domain.Models;
using Newtonsoft.Json;

namespace App.Utility
{
    public static class HtmlSnippets
    {
        public static string CriarBotoesEdicaoDataTables(string urlSave, List<ConfigDataTablesEditor> config,
            string customAction = "", bool temUmSelect = false)
        {
            var htm = "<button class=\"edit-button " + (temUmSelect ? "edit-button-select" : "") +
                      " btn btn-sm btn-default\" data-bs-toggle=\"tooltip\" data-bs-placement=\"top\" data-bs-original-title=\"Editar\" data-json-config=\"" +
                      JsonConvert.SerializeObject(config).Replace("\"", "&quot;") +
                      "\"><i class=\"bi bi-pen\"></i></button>";
            htm += "<button data-url-save=\"" + urlSave + "\" data-customaction=\"" + customAction +
                   "\" class=\"save-button btn btn-sm btn-default text-success\" style=\"display:none;\"><i class=\"bi bi-check-lg\"></i></button>";
            htm +=
                "<button class=\"cancel-button btn btn-sm btn-default text-danger\" style=\"display:none;\"><i class=\"bi bi-x-lg\"></i></button>";

            return htm;
        }

        public static string CriarBotaoExcluirDataTables(string onClick)
        {
            var htm =
                $"<button class=\"btn btn-sm btn-default\" data-bs-toggle=\"tooltip\" data-bs-placement=\"top\" data-bs-original-title=\"Remover\" onclick=\"{onClick}\" type=\"button\"><i class=\"bi bi-trash\"></i></button>";

            return htm;
        }

        public static string CriarBotaoCanetaDataTables(string onClick)
        {
            var htm =
                $"<button class=\"btn btn-sm btn-default\" data-bs-toggle=\"tooltip\" data-bs-placement=\"top\" data-bs-original-title=\"Editar\" onclick=\"{onClick}\" type=\"button\"><i class=\"bi bi-pen\"></i></button>";

            return htm;
        }

        public static string CriarSwitchDataTables(bool isAtivo, string onClick,Guid id)
        {
            var htm =
                $"<div class=\"form-check form-switch switch switch-reverse\">" +
                $"<input {(isAtivo ? "checked" : "")} class=\"form-check-input\" id=\"ativoInativos\" onclick=\"{onClick}\" type=\"checkbox\">" +
                $"</div>";
            return htm;
        }
    }
}