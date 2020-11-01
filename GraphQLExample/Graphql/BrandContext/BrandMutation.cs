using GraphQL;
using GraphQL.Types;
using GraphQLExample.Graphql.Types;
using GraphQLExample.Helpers;
using GraphQLExample.Models;

namespace GraphQLExample.Graphql
{
    public class BrandMutation : ObjectGraphType<object>
    {

        /*  Create Example
         
            

        */
        
        public BrandMutation(MarketingContext _marketingContext)
        {
            Name = "Brand_Mutation";

            Field<BrandType>("createUser", resolve: ctx => {
                var user = ctx.GetArgument<Brand>("user");
                _marketingContext.AddBrand(user);
                return user;
            }, arguments: new QueryArguments() {
            new QueryArgument<InputBrandType>{ Name="user"}
        });

            /*  Delete Example

              mutation {
                  deleteUser(id:5) {
                  name
                  id
                  }
              }

           */

            Field<BrandType>("deleteUser", resolve: ctx => {
                var id = (int)ctx.Arguments["id"];
                return _marketingContext.RemoveBrand(id);
            }, arguments: new QueryArguments() {
            new QueryArgument<IntGraphType> { Name="id"}
        });

          

        }
    }
}