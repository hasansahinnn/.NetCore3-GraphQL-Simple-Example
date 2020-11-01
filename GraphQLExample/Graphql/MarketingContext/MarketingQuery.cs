using GraphQL;
using GraphQL.Types;
using GraphQLExample.Graphql.Types;
using GraphQLExample.Helpers;

namespace GraphQLExample.Graphql
{
    public class MarketingQuery : ObjectGraphType<object>
    {
        public MarketingQuery(MarketingContext _marketingContext)
        {
            Name = "Marketing_Query";

            Field<ListGraphType<MaterialType>>("Materials", //Endpoint ->  Example Request: {"query": "query{ materials{id,name} }" }
            resolve: ctx => _marketingContext.GetMaterials());
            Field<ListGraphType<MaterialType>>("MeterialByBrandId", //Endpoint ->  Example Request: {"query": "query{ meterialByBrandId(id:1){id,name} }" }
            arguments: new QueryArguments
            {
             new QueryArgument<IntGraphType>{Name="Id",Description="Brand Id"}
            },
             resolve: ctx => _marketingContext.GetMaterialsByBrandId(ctx.GetArgument<int>("Id")));
            Field<ListGraphType<BrandType>>("Brands", resolve: ctx => _marketingContext.GetBrands());
        }
    }
}