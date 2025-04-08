using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carelinkAPI.Models.DTO
{
    public class AddPersonDto
    {
        public string Navn { get; set; }
        public int? Opholdsstedid { get; set; }
    }
}
