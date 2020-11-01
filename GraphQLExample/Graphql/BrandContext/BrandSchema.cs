using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace GraphQLExample.Graphql
{

    public class BrandSchema : Schema
    {
        public BrandSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<BrandQuery>();
            Mutation = resolver.Resolve<BrandMutation>();
        }
    }
}