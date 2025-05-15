namespace App.Domain.Models
{
    public class ConfigDataTablesEditor
    {
        /// <summary>
        /// Coluna que será afetada a edição (Inicia com zero)
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Tipo do input
        /// </summary>
        public string InputType { get; set; }

        /// <summary>
        /// Classe ou classes css para aplicar
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// Opcional para tipo texto
        /// </summary>
        public int? MaxLength { get; set; }

        /// <summary>
        /// Opcional para tipo numero
        /// </summary>
        public int? MaxNumber { get; set; }

        /// <summary>
        /// Valores para cada opção do Select
        /// </summary>
        public List<string>? OptionsValues { get; set; }

        /// <summary>
        /// Textos para cada opção do Select
        /// </summary>
        public List<string>? OptionsTexts { get; set; }

        public bool? TemDoisInputs { get; set; }
    }
}
