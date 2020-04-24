using GraphQL.Types;
using JC.MyAirport.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JC.MyAirport.GraphQL
{
    public class BagageType: ObjectGraphType<Bagage>
    {
        public BagageType()
        {
            Field(x => x.BagageId);
            Field(x => x.Classe);
            Field(x => x.CodeIata);
            Field(x => x.DateCreation);
            Field(x => x.Destination);
            Field(x => x.Escale);
            Field(x => x.Prioritaire);
            Field(x => x.Sta);
            Field(x => x.Ssur);
            Field(x => x.VolId, nullable: true);
        }
        

    }
}
