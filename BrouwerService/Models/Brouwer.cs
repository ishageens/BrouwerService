using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BrouwerService.Models
{
    [DataContract(Name = "brouwer", Namespace = "")]
    public class Brouwer
    {
        [DataMember(Name = "id", Order = 1)]
        public int Id { get; set; }
        [DataMember(Name = "naam", Order = 2)]
        public string Naam { get; set; }
        [DataMember(Name = "postcode", Order = 3)]
        public int Postcode { get; set; }
        [DataMember(Name = "gemeente", Order = 4)]
        public string Gemeente { get; set; }
    }
}
