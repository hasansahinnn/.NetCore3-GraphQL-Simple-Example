using GraphQL;
using GraphQL.Types;
using GraphQLExample.Graphql.Types;
using GraphQLExample.Helpers;

namespace GraphQLExample.Graphql
{
    public class BrandQuery : ObjectGraphType<object>
    {
        public BrandQuery(MarketingContext _marketingContext)
        {
            Name = "Brand_Query";
            
            Field<ListGraphType<BrandType>>("Brands", //TODO: Endpoint Name
            resolve: ctx => _marketingContext.GetBrands());
            Field<ListGraphType<BrandType>>("BrandByBrandId",
            arguments: new QueryArguments
            {
             new QueryArgument<IntGraphType>{ //TODO: Endpoint Paramater
                 Name="Id",
                 Description="Brand Id"
             }
            },
             resolve: ctx => _marketingContext.GetByBrandId(ctx.GetArgument<int>("Id")));
        }
    }
}