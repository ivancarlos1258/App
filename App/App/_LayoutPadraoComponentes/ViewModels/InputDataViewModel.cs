using System;

namespace LayoutPadrao.ViewModels
{
    public class InputDataViewModel
    {
        public string Id { get; set; }
        public string Label { get; set; }

        public bool? Disabled { get; set; }
        public DateTime? Max { get; set; }
        public DateTime? Min { get; set; }
        public bool? Required { get; set; }
        public DateTime? Value { get; set; }
    }
}
