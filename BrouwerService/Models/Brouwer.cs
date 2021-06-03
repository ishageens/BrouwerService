using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrouwerService.Models
{
    public class Brouwer
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int Postcode { get; set; }
        public string Gemeente { get; set; }
    }
}
