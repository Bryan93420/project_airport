using GraphQL.Types;
using JC.MyAirport.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JC.MyAirport.GraphQL
{
    public class AirportQuery : ObjectGraphType
    {
        public AirportQuery(MyAirportContext db)
        {
            Field<ListGraphType<BagageType>>(
                "bagages",
                resolve: context => db.Bagages.ToList());
            //Field<ListGraphType<BagageType>>(
            //    "bagage",
            //    arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "BagageId" }),
            //    resolve: context => db.Bagages.First(b => b.BagageId == context.GetArgument<int>("BagageId"))); 
        }
    }
}
