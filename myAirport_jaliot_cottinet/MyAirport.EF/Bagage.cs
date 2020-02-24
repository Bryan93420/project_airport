using System;
using System.Collections.Generic;
using System.Text;

namespace JC.MyAirport.EF
{
    class Bagage
    {
        public int id_bagage { get; set; }
        
        public Vol vol { get; set; }
        public int id_vol { get; set; }
        public string code_iata { get; set; }
        public DateTime date_creation { get; set; }
        public string classe { get; set; }
        public Boolean prioritaire { get; set; }
        public string sta { get; set; }
        public string ssur { get; set; }
        public string destination { get; set; }
        public string escale { get; set; }

    }
}
