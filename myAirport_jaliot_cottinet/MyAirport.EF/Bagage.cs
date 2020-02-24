using System;
using System.Collections.Generic;
using System.Text;

namespace JC.MyAirport.EF
{
    public class Bagage
    {
        public int BagageId { get; set; }
        public Vol Vol { get; set; }
        public int VolId { get; set; }
        public string CodeIata { get; set; }
        public DateTime DateCreation { get; set; }
        public string Classe { get; set; }
        public Boolean Prioritaire { get; set; }
        public string Sta { get; set; }
        public string Ssur { get; set; }
        public string Destination { get; set; }
        public string Escale { get; set; }

    }
}
