using GraphQL.Types;
using GraphQLExample.Models;

namespace GraphQLExample.Graphql.Types
{
    public class BrandType : ObjectGraphType<Brand>
    {
        public BrandType()
        {
            Name = "Brand";
            Field(p => p.Id).Name("id").Description("Brand id.");
            Field(p => p.Name).Name("name").Description("Brand Name.");
        }
    }
}