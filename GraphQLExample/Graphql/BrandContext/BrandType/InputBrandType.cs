using GraphQL.Types;
using GraphQLExample.Models;

namespace GraphQLExample.Graphql.Types
{
    public class InputBrandType : InputObjectGraphType<Brand>
    {
        public InputBrandType()
        {
            Name = "InputBrandType";
            Field(p => p.Id);
            Field(p => p.Name);
        }
    }
}