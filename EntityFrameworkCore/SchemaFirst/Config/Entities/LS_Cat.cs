using System;
using System.Collections.Generic;

namespace SchemaFirst.Config.Entities
{
    public partial class LS_Cat
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Coatcolor { get; set; }
        public double? Weight { get; set; }
    }
}
