namespace LayoutPadrao.ViewModels
{
    public class SelectViewModel
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string? Default {  get; set; }
        public bool? Disabled { get; set; }
        public bool? Required { get; set; }
        public Option[] Options { get; set; }
    }

    public class Option
    {
        public string Texto { get; set; }
        public string Valor { get; set; }
    }
}
