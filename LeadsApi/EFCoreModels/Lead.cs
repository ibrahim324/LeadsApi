using System;
using System.Collections.Generic;

namespace LeadsApi.EFCoreModels
{
    public partial class Lead
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? ZipCode { get; set; }
        public double? ConversionProb { get; set; }
    }
}
