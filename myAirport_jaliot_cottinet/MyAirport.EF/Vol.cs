using System;
using System.Collections.Generic;
using System.Text;

namespace JC.MyAirport.EF
{
    public class Vol
    {
        public int VolId { get; set; }
        public string Cie { get; set; }
        public string Lig { get; set; }
        public DateTime Dhc { get; set; }
        public string? Pkg { get; set; }
        public string? Imm { get; set; }
        public int? Pax { get; set; }
        public string? Des { get; set; }

        public IEnumerable<Bagage> Bagages { get; set; }


        public Vol() { }
        public Vol(string compagnie, string ligne, DateTime dhc)
        {
            Cie = compagnie;
            Lig = ligne;
            Dhc = dhc;
            Bagages = new List<Bagage>();
        }
    }
}
