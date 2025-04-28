namespace LayoutPadrao.ViewModels
{
    public class InputViewModel
    {
        public string Id{ get; set; }
        public string Label { get; set; }

        public string? Classes { get; set; }
        public bool? Disabled { get; set; }
        public string? MaxLength { get; set; }
        public string? MinLength { get; set; }
        public bool? Required { get; set; }
        public string? Tipo { get; set; }
        public string? Value { get; set; }
    }
}
