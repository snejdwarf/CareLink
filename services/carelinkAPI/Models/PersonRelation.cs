using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carelinkAPI.Models
{
    public class PersonRelation
    {
        public int Id { get; set; }
        public Person PersonA { get; set; }
        public Person PersonB { get; set; }


    }
}
