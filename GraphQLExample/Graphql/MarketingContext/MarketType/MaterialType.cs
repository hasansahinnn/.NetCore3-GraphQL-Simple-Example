using GraphQL.Types;
using GraphQLExample.Models;

namespace GraphQLExample.Graphql.Types
{
    public class MaterialType : ObjectGraphType<Material>
    {
        public MaterialType()
        {
            Name = "Material";
            Field(p => p.Id);
            Field(p => p.Name);
            Field<BrandType>("Brand", resolve: _ => _.Source.Brand);
        }
    }

}