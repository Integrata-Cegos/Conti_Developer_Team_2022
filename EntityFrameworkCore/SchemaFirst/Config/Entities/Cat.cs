﻿using System;
using System.Collections.Generic;

namespace SchemaFirst.config.Entities
{
    public partial class Cat
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Coatcolor { get; set; }
        public double? Weight { get; set; }
    }
}
