﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carelinkAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public Opholdssted Opholdssted { get; set; }
    }
}
